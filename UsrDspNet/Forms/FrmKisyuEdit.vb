Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class FrmKisyuEdit
    Private TargetCode As String = ""

    Private OldPc0 As String = ""
    Private OldPc1 As String = ""
    Private OldPrt0 As String = ""
    Private OldPrt1 As String = ""
    Private OldMn0 As String = ""
    Private OldMn1 As String = ""
    Private OldBcr0 As String = ""
    Private OldBcr1 As String = ""
    Private OldHdd0 As String = ""
    Private OldHdd1 As String = ""
    Private OldMiniPrt0 As String = ""
    Private OldMiniPrt1 As String = ""

    Public Function LoadKisyuInfo(ByVal code As String, ByVal userTitle As String) As Boolean
        TargetCode = GetNumAlp(code)
        If Not CheckAndAcquireUserLock(TargetCode, Me) Then Return False
        lblUser.Text = userTitle
        lblTantoInfo.Text = If(String.IsNullOrWhiteSpace(OptionDefaultSyainName), "担当: 未設定", $"担当: {OptionDefaultSyainName}")

        ' 接続先DBの列存在確認
        If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
            Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                cnNt.Open()
                EnsureKisyuColumns(cnNt)
                EnsureRrkColumn(cnNt)
            End Using
        End If
        EnsureKisyuColumns(CnMplMdb)
        EnsureRrkColumn(CnMplMdb)

        ' コンボボックスの選択肢読み込み（mpl.mdbから既存データを重複排除＆ソートして取得）
        PopulateCandidates(cmbPrt0, "プリンター機種名")
        PopulateCandidates(cmbBcr0, "BCR機種名")
        PopulateCandidates(cmbHdd0, "HDD機種名")
        PopulateCandidates(cmbMiniPrt0, "小型プリンター機種名")

        ' 現在のデータを取得
        Dim dt As DataTable = Nothing
        Try
            If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    dt = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(TargetCode), cnNt)
                End Using
            Else
                dt = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(TargetCode), CnMplMdb)
            End If

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                OldPc0 = NulCut(r("本体機種名"))
                OldPc1 = NulCut(r("本体SN"))
                OldPrt0 = NulCut(r("プリンター機種名"))
                OldPrt1 = NulCut(r("プリンターSN"))
                OldMn0 = NulCut(r("画面機種名"))
                OldMn1 = NulCut(r("画面SN"))
                OldBcr0 = NulCut(r("BCR機種名"))
                OldBcr1 = NulCut(r("BCRSN"))
                OldHdd0 = NulCut(r("HDD機種名"))
                OldHdd1 = NulCut(r("HDDSN"))
                OldMiniPrt0 = NulCut(r("小型プリンター機種名"))
                OldMiniPrt1 = NulCut(r("小型プリンターSN"))
            End If
        Catch ex As Exception
            MessageBox.Show("機種情報の取得に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        txtPc0.Text = OldPc0
        txtPc1.Text = OldPc1
        cmbPrt0.Text = OldPrt0
        txtPrt1.Text = OldPrt1
        txtMn0.Text = OldMn0
        txtMn1.Text = OldMn1
        cmbBcr0.Text = OldBcr0
        txtBcr1.Text = OldBcr1
        cmbHdd0.Text = OldHdd0
        txtHdd1.Text = OldHdd1
        cmbMiniPrt0.Text = OldMiniPrt0
        txtMiniPrt1.Text = OldMiniPrt1
        Return True
    End Function

    ''' <summary>
    ''' テーブルに必要なカラムが存在するか確認し、なければ追加
    ''' </summary>
    Private Sub EnsureKisyuColumns(ByVal cn As OleDbConnection)
        If cn Is Nothing Then Return
        If cn.State <> ConnectionState.Open Then cn.Open()

        Dim colsToCheck As String() = {
            "本体機種名", "本体SN",
            "プリンター機種名", "プリンターSN",
            "画面機種名", "画面SN",
            "BCR機種名", "BCRSN",
            "HDD機種名", "HDDSN",
            "小型プリンター機種名", "小型プリンターSN"
        }

        Try
            Dim dtCols As New DataTable()
            Using da As New OleDbDataAdapter("SELECT TOP 1 * FROM ユーザーデータ", cn)
                da.Fill(dtCols)
            End Using

            For Each col In colsToCheck
                If Not dtCols.Columns.Contains(col) Then
                    Try
                        Using cmd As New OleDbCommand($"ALTER TABLE ユーザーデータ ADD COLUMN [{col}] VARCHAR(50)", cn)
                            cmd.ExecuteNonQuery()
                        End Using
                    Catch
                    End Try
                End If
            Next
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' mpl.mdbから指定カラムの既存データを重複無くソートしてコンボボックスに設定
    ''' </summary>
    Private Sub PopulateCandidates(ByVal cmb As ComboBox, ByVal columnName As String)
        cmb.Items.Clear()
        Try
            Dim dt As DataTable = Nothing
            Dim sql As String = $"SELECT DISTINCT [{columnName}] FROM ユーザーデータ WHERE [{columnName}] IS NOT NULL AND [{columnName}] <> '' ORDER BY [{columnName}]"

            If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    dt = QueryDataTable(sql, cnNt)
                End Using
            Else
                dt = QueryDataTable(sql, CnMplMdb)
            End If

            If dt IsNot Nothing Then
                For Each row As DataRow In dt.Rows
                    Dim val As String = NulCut(row(0))
                    If val <> "" AndAlso Not cmb.Items.Contains(val) Then
                        cmb.Items.Add(val)
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateKisyuOnConnection(ByVal cn As OleDbConnection,
                                         ByVal pc0 As String, ByVal pc1 As String,
                                         ByVal prt0 As String, ByVal prt1 As String,
                                         ByVal mn0 As String, ByVal mn1 As String,
                                         ByVal bcr0 As String, ByVal bcr1 As String,
                                         ByVal hdd0 As String, ByVal hdd1 As String,
                                         ByVal miniPrt0 As String, ByVal miniPrt1 As String,
                                         ByVal historyJson As String)
        If cn Is Nothing Then Return
        If cn.State <> ConnectionState.Open Then cn.Open()
        EnsureKisyuColumns(cn)
        EnsureRrkColumn(cn)

        Dim sql As String = "UPDATE ユーザーデータ SET " &
            "[本体機種名] = ?, [本体SN] = ?, " &
            "[プリンター機種名] = ?, [プリンターSN] = ?, " &
            "[画面機種名] = ?, [画面SN] = ?, " &
            "[BCR機種名] = ?, [BCRSN] = ?, " &
            "[HDD機種名] = ?, [HDDSN] = ?, " &
            "[小型プリンター機種名] = ?, [小型プリンターSN] = ?, [履歴] = ? " &
            "WHERE [コード] = ?"

        Using cmd As New OleDbCommand(sql, cn)
            cmd.Parameters.Add("pc0", OleDbType.VarWChar).Value = ToDbStr(pc0)
            cmd.Parameters.Add("pc1", OleDbType.VarWChar).Value = ToDbStr(pc1)
            cmd.Parameters.Add("prt0", OleDbType.VarWChar).Value = ToDbStr(prt0)
            cmd.Parameters.Add("prt1", OleDbType.VarWChar).Value = ToDbStr(prt1)
            cmd.Parameters.Add("mn0", OleDbType.VarWChar).Value = ToDbStr(mn0)
            cmd.Parameters.Add("mn1", OleDbType.VarWChar).Value = ToDbStr(mn1)
            cmd.Parameters.Add("bcr0", OleDbType.VarWChar).Value = ToDbStr(bcr0)
            cmd.Parameters.Add("bcr1", OleDbType.VarWChar).Value = ToDbStr(bcr1)
            cmd.Parameters.Add("hdd0", OleDbType.VarWChar).Value = ToDbStr(hdd0)
            cmd.Parameters.Add("hdd1", OleDbType.VarWChar).Value = ToDbStr(hdd1)
            cmd.Parameters.Add("miniPrt0", OleDbType.VarWChar).Value = ToDbStr(miniPrt0)
            cmd.Parameters.Add("miniPrt1", OleDbType.VarWChar).Value = ToDbStr(miniPrt1)
            cmd.Parameters.Add("rrk", OleDbType.LongVarWChar).Value = ToDbStr(historyJson)
            cmd.Parameters.Add("cd", OleDbType.VarWChar).Value = TargetCode
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Not ValidateUserLockForSave(TargetCode, Me) Then Return
        If ModeDbLocation = CnModeLocal Then
            MessageBox.Show("ローカルモードでは更新できません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim pc0 As String = TrimX(txtPc0.Text)
        Dim pc1 As String = TrimX(txtPc1.Text)
        Dim prt0 As String = TrimX(cmbPrt0.Text)
        Dim prt1 As String = TrimX(txtPrt1.Text)
        Dim mn0 As String = TrimX(txtMn0.Text)
        Dim mn1 As String = TrimX(txtMn1.Text)
        Dim bcr0 As String = TrimX(cmbBcr0.Text)
        Dim bcr1 As String = TrimX(txtBcr1.Text)
        Dim hdd0 As String = TrimX(cmbHdd0.Text)
        Dim hdd1 As String = TrimX(txtHdd1.Text)
        Dim miniPrt0 As String = TrimX(cmbMiniPrt0.Text)
        Dim miniPrt1 As String = TrimX(txtMiniPrt1.Text)

        Dim changed As Boolean = (pc0 <> OldPc0) OrElse (pc1 <> OldPc1) OrElse
                                 (prt0 <> OldPrt0) OrElse (prt1 <> OldPrt1) OrElse
                                 (mn0 <> OldMn0) OrElse (mn1 <> OldMn1) OrElse
                                 (bcr0 <> OldBcr0) OrElse (bcr1 <> OldBcr1) OrElse
                                 (hdd0 <> OldHdd0) OrElse (hdd1 <> OldHdd1) OrElse
                                 (miniPrt0 <> OldMiniPrt0) OrElse (miniPrt1 <> OldMiniPrt1)

        If changed Then
            Dim changes As New List(Of UsrRrkChange)()
            AddChangeIfDifferent(changes, "本体機種名", OldPc0, pc0)
            AddChangeIfDifferent(changes, "本体SN", OldPc1, pc1)
            AddChangeIfDifferent(changes, "プリンタ機種名", OldPrt0, prt0)
            AddChangeIfDifferent(changes, "プリンタSN", OldPrt1, prt1)
            AddChangeIfDifferent(changes, "モニタ機種名", OldMn0, mn0)
            AddChangeIfDifferent(changes, "モニタSN", OldMn1, mn1)
            AddChangeIfDifferent(changes, "BCR機種名", OldBcr0, bcr0)
            AddChangeIfDifferent(changes, "BCRSN", OldBcr1, bcr1)
            AddChangeIfDifferent(changes, "HDD機種名", OldHdd0, hdd0)
            AddChangeIfDifferent(changes, "HDDSN", OldHdd1, hdd1)
            AddChangeIfDifferent(changes, "小型プリンタ機種名", OldMiniPrt0, miniPrt0)
            AddChangeIfDifferent(changes, "小型プリンタSN", OldMiniPrt1, miniPrt1)

            Dim existingJson As String = ""
            Try
                If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                    Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                        cnNt.Open()
                        existingJson = GetUserHistoryJson(TargetCode, cnNt)
                    End Using
                Else
                    existingJson = GetUserHistoryJson(TargetCode, CnMplMdb)
                End If
            Catch
            End Try

            Dim newHistoryJson As String = AppendHistoryJson(existingJson, OptionDefaultSyainCode, OptionDefaultSyainName, changes)

            Try
                If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                    Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                        cnNt.Open()
                        UpdateKisyuOnConnection(cnNt, pc0, pc1, prt0, prt1, mn0, mn1, bcr0, bcr1, hdd0, hdd1, miniPrt0, miniPrt1, newHistoryJson)
                    End Using
                End If

                UpdateKisyuOnConnection(CnMplMdb, pc0, pc1, prt0, prt1, mn0, mn1, bcr0, bcr1, hdd0, hdd1, miniPrt0, miniPrt1, newHistoryJson)

                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show("機種情報の更新に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try
        Else
            Me.DialogResult = DialogResult.Cancel
        End If

        Me.Close()
    End Sub

    Private Sub FrmKisyuEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ReleaseUserLock(TargetCode)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Using dlg As New FrmUsrRrkViewer()
            dlg.ShowHistory(TargetCode, lblUser.Text, Me)
        End Using
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Alt Or Keys.U) Then
            btnOk.PerformClick()
            Return True
        ElseIf keyData = (Keys.Alt Or Keys.C) Then
            btnCancel.PerformClick()
            Return True
        ElseIf keyData = (Keys.Alt Or Keys.H) Then
            btnHistory.PerformClick()
            Return True
        ElseIf keyData = Keys.Escape Then
            ' Escキーでの誤終了を防止
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
