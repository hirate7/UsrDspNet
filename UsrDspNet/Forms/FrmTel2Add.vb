Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class FrmTel2Add
    Private TargetCode As String = ""
    Private OldTelEx(4) As String
    Private TelBoxes() As TextBox

    Public Sub LoadTelEx(ByVal code As String, ByVal userTitle As String)
        TargetCode = GetNumAlp(code)
        lblUser.Text = userTitle
        TelBoxes = New TextBox() {txtTelEx0, txtTelEx1, txtTelEx2, txtTelEx3, txtTelEx4}

        For i As Integer = 0 To 4
            TelBoxes(i).Text = ""
            OldTelEx(i) = ""
        Next

        Try
            If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    Dim dt As DataTable = QueryDataTable("SELECT * FROM 拡張データ WHERE コード = " & GetUcdSql(TargetCode), cnNt)
                    If dt.Rows.Count > 0 Then
                        Dim r As DataRow = dt.Rows(0)
                        For i As Integer = 0 To 4
                            TelBoxes(i).Text = TrimX(NulCut(r("電話番号追加分" & (i + 1).ToString())))
                        Next
                    End If
                End Using
            Else
                Dim dt As DataTable = QueryDataTable("SELECT * FROM 拡張データ WHERE コード = " & GetUcdSql(TargetCode), CnMplMdb)
                If dt.Rows.Count > 0 Then
                    Dim r As DataRow = dt.Rows(0)
                    For i As Integer = 0 To 4
                        TelBoxes(i).Text = TrimX(NulCut(r("電話番号追加分" & (i + 1).ToString())))
                    Next
                End If
            End If
        Catch
        End Try

        For i As Integer = 0 To 4
            OldTelEx(i) = TrimX(TelBoxes(i).Text)
        Next
    End Sub

    Private Sub UpsertTelExOnConnection(ByVal cn As OleDbConnection)
        If cn Is Nothing Then Return
        If cn.State <> ConnectionState.Open Then cn.Open()

        Dim dt As DataTable = QueryDataTable("SELECT ID FROM 拡張データ WHERE コード = " & GetUcdSql(TargetCode), cn)
        Dim vals(4) As String
        Dim stripped(4) As String
        For i As Integer = 0 To 4
            vals(i) = TrimX(TelBoxes(i).Text)
            stripped(i) = TrimX(CutHf(CnvZH3(vals(i))))
        Next

        If dt.Rows.Count > 0 Then
            Dim sqlUpd As String =
                "UPDATE 拡張データ SET " &
                "[電話番号追加分1] = ?, [電話番号追加分2] = ?, [電話番号追加分3] = ?, [電話番号追加分4] = ?, [電話番号追加分5] = ?, " &
                "[電話番号追加分1_] = ?, [電話番号追加分2_] = ?, [電話番号追加分3_] = ?, [電話番号追加分4_] = ?, [電話番号追加分5_] = ? " &
                "WHERE [コード] = ?"
            Using cmd As New OleDbCommand(sqlUpd, cn)
                For i As Integer = 0 To 4
                    cmd.Parameters.Add("t" & i.ToString(), OleDbType.VarWChar).Value = vals(i)
                Next
                For i As Integer = 0 To 4
                    cmd.Parameters.Add("s" & i.ToString(), OleDbType.VarWChar).Value = stripped(i)
                Next
                cmd.Parameters.Add("cd", OleDbType.VarWChar).Value = TargetCode
                cmd.ExecuteNonQuery()
            End Using
        Else
            Dim sqlIns As String =
                "INSERT INTO 拡張データ ([コード], [電話番号追加分1], [電話番号追加分2], [電話番号追加分3], [電話番号追加分4], [電話番号追加分5], " &
                "[電話番号追加分1_], [電話番号追加分2_], [電話番号追加分3_], [電話番号追加分4_], [電話番号追加分5_]) " &
                "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            Using cmd As New OleDbCommand(sqlIns, cn)
                cmd.Parameters.Add("cd", OleDbType.VarWChar).Value = TargetCode
                For i As Integer = 0 To 4
                    cmd.Parameters.Add("t" & i.ToString(), OleDbType.VarWChar).Value = vals(i)
                Next
                For i As Integer = 0 To 4
                    cmd.Parameters.Add("s" & i.ToString(), OleDbType.VarWChar).Value = stripped(i)
                Next
                cmd.ExecuteNonQuery()
            End Using
        End If
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If ModeDbLocation = CnModeLocal Then
            MessageBox.Show("ローカルモードでは無効です", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim changed As Boolean = False
        For i As Integer = 0 To 4
            If OldTelEx(i) <> TrimX(TelBoxes(i).Text) Then
                changed = True
                Exit For
            End If
        Next

        If changed Then
            Try
                ' 1. ネットワーク側 Mpl.mdb を更新
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    UpsertTelExOnConnection(cnNt)
                End Using

                ' 2. ローカル側 Mpl.mdb も即座に同期更新
                UpsertTelExOnConnection(CnMplMdb)

                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show("その他の電話番号の更新に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try
        End If

        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class
