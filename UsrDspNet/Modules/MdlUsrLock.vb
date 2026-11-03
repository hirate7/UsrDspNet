Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Module MdlUsrLock

    ''' <summary>
    ''' ロックの有効期限（分単位: 1時間 = 60分）
    ''' </summary>
    Public Const LockTimeoutMinutes As Integer = 60

    Public Enum LockResult
        Success
        AlreadyLocked
        DbError
    End Enum

    ''' <summary>
    ''' ユーザーデータテーブルに排他制御用のLockPC, LockUser, LockTime列が存在することを確認・作成
    ''' </summary>
    Public Sub EnsureLockColumns(ByVal cn As OleDbConnection)
        If cn Is Nothing Then Return
        Try
            If cn.State <> ConnectionState.Open Then cn.Open()
            Dim dt As New DataTable()
            Using da As New OleDbDataAdapter("SELECT TOP 1 * FROM ユーザーデータ", cn)
                da.Fill(dt)
            End Using
            If Not dt.Columns.Contains("LockPC") Then
                Using cmd As New OleDbCommand("ALTER TABLE ユーザーデータ ADD COLUMN LockPC VARCHAR(50)", cn)
                    cmd.ExecuteNonQuery()
                End Using
            End If
            If Not dt.Columns.Contains("LockUser") Then
                Using cmd As New OleDbCommand("ALTER TABLE ユーザーデータ ADD COLUMN LockUser VARCHAR(50)", cn)
                    cmd.ExecuteNonQuery()
                End Using
            End If
            If Not dt.Columns.Contains("LockTime") Then
                Using cmd As New OleDbCommand("ALTER TABLE ユーザーデータ ADD COLUMN LockTime DATETIME", cn)
                    cmd.ExecuteNonQuery()
                End Using
            End If
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("EnsureLockColumns error: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' ロック管理に使用するMDBへの接続を取得（ネットワークモード時はネットワークMDBを直接参照）
    ''' </summary>
    Private Function GetLockConnection() As OleDbConnection
        Dim cnStr As String
        If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
            cnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';"
        Else
            cnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionLcMplMdb & "';"
        End If

        Dim cn As New OleDbConnection(cnStr)
        cn.Open()
        EnsureLockColumns(cn)
        Return cn
    End Function

    ''' <summary>
    ''' 現在設定されている担当者名を取得
    ''' </summary>
    Private Function GetCurrentStaffName() As String
        If Not String.IsNullOrWhiteSpace(OptionDefaultSyainName) Then
            Return OptionDefaultSyainName
        End If
        Return Environment.UserName
    End Function

    ''' <summary>
    ''' 編集ロックの取得を試みる（アトミック更新により競合を100%防止）
    ''' </summary>
    Public Function TryAcquireUserLock(ByVal userCode As String, ByRef lockOwnerInfo As String) As LockResult
        Dim cleanCode As String = GetNumAlp(userCode)
        If String.IsNullOrWhiteSpace(cleanCode) Then Return LockResult.Success

        Dim myPc As String = Environment.MachineName
        Dim myUser As String = GetCurrentStaffName()
        Dim nowTime As DateTime = DateTime.Now
        Dim timeoutThreshold As DateTime = nowTime.AddMinutes(-LockTimeoutMinutes)

        Try
            Using cn As OleDbConnection = GetLockConnection()
                ' 1. 現在のロック状況を確認
                Dim sqlCheck As String = "SELECT LockPC, LockUser, LockTime FROM ユーザーデータ WHERE [コード] = ?"
                Using cmdCheck As New OleDbCommand(sqlCheck, cn)
                    cmdCheck.Parameters.AddWithValue("?", cleanCode)
                    Using dr As OleDbDataReader = cmdCheck.ExecuteReader()
                        If dr.Read() Then
                            Dim curPc As String = If(dr.IsDBNull(0), "", dr.GetString(0))
                            Dim curUser As String = If(dr.IsDBNull(1), "", dr.GetString(1))
                            Dim curTime As DateTime = If(dr.IsDBNull(2), DateTime.MinValue, dr.GetDateTime(2))

                            ' 空でなく、自分のPCでなく、かつ1時間以内の場合は他者がロック中
                            If Not String.IsNullOrWhiteSpace(curPc) AndAlso
                               Not curPc.Equals(myPc, StringComparison.OrdinalIgnoreCase) AndAlso
                               curTime > timeoutThreshold Then
                                lockOwnerInfo = $"担当: {curUser} (PC: {curPc}, ロック日時: {curTime:yyyy/MM/dd HH:mm})"
                                Return LockResult.AlreadyLocked
                            End If
                        End If
                    End Using
                End Using

                ' 2. 空、自PC、または1時間経過している場合、アトミックに条件付き更新でロックを取得
                Dim sqlAcquire As String = "UPDATE ユーザーデータ SET LockPC = ?, LockUser = ?, LockTime = ? " &
                                          "WHERE [コード] = ? AND (LockPC IS NULL OR LockPC = '' OR LockPC = ? OR LockTime IS NULL OR LockTime <= ?)"
                Using cmdAcquire As New OleDbCommand(sqlAcquire, cn)
                    cmdAcquire.Parameters.AddWithValue("?", myPc)
                    cmdAcquire.Parameters.AddWithValue("?", myUser)
                    cmdAcquire.Parameters.AddWithValue("?", nowTime)
                    cmdAcquire.Parameters.AddWithValue("?", cleanCode)
                    cmdAcquire.Parameters.AddWithValue("?", myPc)
                    cmdAcquire.Parameters.AddWithValue("?", timeoutThreshold)

                    Dim rowsAffected As Integer = cmdAcquire.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Return LockResult.Success
                    Else
                        ' 0件の場合、直前に他者が先にロックを取得した
                        Using cmdRecheck As New OleDbCommand(sqlCheck, cn)
                            cmdRecheck.Parameters.AddWithValue("?", cleanCode)
                            Using dr As OleDbDataReader = cmdRecheck.ExecuteReader()
                                If dr.Read() Then
                                    Dim curPc As String = If(dr.IsDBNull(0), "", dr.GetString(0))
                                    Dim curUser As String = If(dr.IsDBNull(1), "", dr.GetString(1))
                                    Dim curTime As DateTime = If(dr.IsDBNull(2), DateTime.MinValue, dr.GetDateTime(2))
                                    lockOwnerInfo = $"担当: {curUser} (PC: {curPc}, ロック日時: {curTime:yyyy/MM/dd HH:mm})"
                                End If
                            End Using
                        End Using
                        Return LockResult.AlreadyLocked
                    End If
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("TryAcquireUserLock error: " & ex.Message)
            lockOwnerInfo = ex.Message
            Return LockResult.DbError
        End Try
    End Function

    ''' <summary>
    ''' ロックを強制的に取得（他者のロックを上書き）
    ''' </summary>
    Public Function ForceAcquireUserLock(ByVal userCode As String) As Boolean
        Dim cleanCode As String = GetNumAlp(userCode)
        If String.IsNullOrWhiteSpace(cleanCode) Then Return True

        Dim myPc As String = Environment.MachineName
        Dim myUser As String = GetCurrentStaffName()
        Dim nowTime As DateTime = DateTime.Now

        Try
            Using cn As OleDbConnection = GetLockConnection()
                Dim sql As String = "UPDATE ユーザーデータ SET LockPC = ?, LockUser = ?, LockTime = ? WHERE [コード] = ?"
                Using cmd As New OleDbCommand(sql, cn)
                    cmd.Parameters.AddWithValue("?", myPc)
                    cmd.Parameters.AddWithValue("?", myUser)
                    cmd.Parameters.AddWithValue("?", nowTime)
                    cmd.Parameters.AddWithValue("?", cleanCode)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return True
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("ForceAcquireUserLock error: " & ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' 編集開始時のチェック＆ロック取得（UIダイアログ付き）
    ''' </summary>
    Public Function CheckAndAcquireUserLock(ByVal userCode As String, ByVal parent As IWin32Window) As Boolean
        Dim cleanCode As String = GetNumAlp(userCode)
        If String.IsNullOrWhiteSpace(cleanCode) Then Return True

        Dim lockInfo As String = ""
        Dim res As LockResult = TryAcquireUserLock(cleanCode, lockInfo)

        If res = LockResult.Success Then
            Return True
        ElseIf res = LockResult.AlreadyLocked Then
            Dim msg As String = "現在、以下の端末・ユーザーがこの顧客データを編集作業中です。" & Environment.NewLine & Environment.NewLine &
                               "　" & lockInfo & Environment.NewLine & Environment.NewLine &
                               "同時に編集すると、後から保存した内容で上書きされる可能性があります。" & Environment.NewLine & Environment.NewLine &
                               "編集作業を強制解除して開きますか？" & Environment.NewLine &
                               "（[はい] を押すと編集ロックを解除して開きます）"
            Dim dr As DialogResult = MessageBox.Show(parent, msg, "排他制御 - 編集中", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If dr = DialogResult.Yes Then
                Return ForceAcquireUserLock(cleanCode)
            Else
                Return False
            End If
        Else
            Dim msg As String = "排他ロック情報の確認中にエラーが発生しました。" & Environment.NewLine &
                               lockInfo & Environment.NewLine & Environment.NewLine &
                               "編集作業を続行しますか？"
            Dim dr As DialogResult = MessageBox.Show(parent, msg, "ロック確認エラー", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
            Return (dr = DialogResult.Yes)
        End If
    End Function

    ''' <summary>
    ''' ロックを解放（自分のPC名でロックされている場合のみNULLにする）
    ''' </summary>
    Public Sub ReleaseUserLock(ByVal userCode As String)
        Dim cleanCode As String = GetNumAlp(userCode)
        If String.IsNullOrWhiteSpace(cleanCode) Then Return

        Dim myPc As String = Environment.MachineName

        Try
            Using cn As OleDbConnection = GetLockConnection()
                Dim sql As String = "UPDATE ユーザーデータ SET LockPC = NULL, LockUser = NULL, LockTime = NULL " &
                                   "WHERE [コード] = ? AND LockPC = ?"
                Using cmd As New OleDbCommand(sql, cn)
                    cmd.Parameters.AddWithValue("?", cleanCode)
                    cmd.Parameters.AddWithValue("?", myPc)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("ReleaseUserLock error: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 保存直前にロックが有効か検証（自分のPC名かつ1時間以内）
    ''' </summary>
    Public Function ValidateUserLockForSave(ByVal userCode As String, ByVal parent As IWin32Window) As Boolean
        Dim cleanCode As String = GetNumAlp(userCode)
        If String.IsNullOrWhiteSpace(cleanCode) Then Return True

        Dim myPc As String = Environment.MachineName
        Dim nowTime As DateTime = DateTime.Now
        Dim timeoutThreshold As DateTime = nowTime.AddMinutes(-LockTimeoutMinutes)

        Try
            Using cn As OleDbConnection = GetLockConnection()
                Dim sql As String = "SELECT LockPC, LockUser, LockTime FROM ユーザーデータ WHERE [コード] = ?"
                Using cmd As New OleDbCommand(sql, cn)
                    cmd.Parameters.AddWithValue("?", cleanCode)
                    Using dr As OleDbDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            Dim curPc As String = If(dr.IsDBNull(0), "", dr.GetString(0))
                            Dim curUser As String = If(dr.IsDBNull(1), "", dr.GetString(1))
                            Dim curTime As DateTime = If(dr.IsDBNull(2), DateTime.MinValue, dr.GetDateTime(2))

                            ' 自分のPC名でない、または1時間経過している場合は無効
                            If String.IsNullOrWhiteSpace(curPc) OrElse
                               Not curPc.Equals(myPc, StringComparison.OrdinalIgnoreCase) OrElse
                               curTime <= timeoutThreshold Then

                                Dim info As String = If(String.IsNullOrWhiteSpace(curPc), "（ロック解除済み）", $"担当: {curUser} (PC: {curPc}, {curTime:yyyy/MM/dd HH:mm})")
                                Dim msg As String = "【保存エラー】編集セッションが無効です。" & Environment.NewLine & Environment.NewLine &
                                                   "タイムアウト（1時間経過）または他の端末によって編集ロックが解除されました。" & Environment.NewLine &
                                                   info & Environment.NewLine & Environment.NewLine &
                                                   "他のユーザーのデータを上書きするのを防ぐため、保存を中断しました。" & Environment.NewLine &
                                                   "最新データを読み直してください。"
                                MessageBox.Show(parent, msg, "排他制御 - 保存中断", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Return False
                            End If
                        End If
                    End Using
                End Using
            End Using
            Return True
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("ValidateUserLockForSave error: " & ex.Message)
            Dim dr As DialogResult = MessageBox.Show(parent, "排他ロック情報の確認中にエラーが発生しました。" & Environment.NewLine & ex.Message & Environment.NewLine & Environment.NewLine & "保存を強制実行しますか？", "保存確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Return (dr = DialogResult.Yes)
        End Try
    End Function

End Module
