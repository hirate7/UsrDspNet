Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class FrmMemoEdit
    Private TargetCode As String = ""
    Private OldMemo As String = ""

    Public Sub LoadMemo(ByVal code As String, ByVal userTitle As String)
        TargetCode = GetNumAlp(code)
        lblUser.Text = userTitle
        lblTantoInfo.Text = If(String.IsNullOrWhiteSpace(OptionDefaultSyainName), "担当: 未設定", $"担当: {OptionDefaultSyainName}")
        txtMemo.Text = ""

        Try
            Dim dt As DataTable = QueryDataTable("SELECT * FROM メモ WHERE UserCD = " & GetUcdSql(TargetCode), CnMntMdb)
            If dt.Rows.Count > 0 Then
                txtMemo.Text = NulCut(dt.Rows(0)("Memo"))
            End If
        Catch
        End Try

        OldMemo = txtMemo.Text
        txtMemo.SelectionStart = 0
        txtMemo.SelectionLength = 0

        If ModeDbLocation = CnModeLocal Then
            lblLocalWarn.Visible = True
        Else
            lblLocalWarn.Visible = False
        End If
    End Sub

    Private Sub cmdWrite_Click(sender As Object, e As EventArgs) Handles cmdWrite.Click
        If ModeDbLocation = CnModeLocal Then
            MessageBox.Show("ローカルモードでは無効です", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If txtMemo.Text <> OldMemo Then
            Try
                If CnMntMdb.State <> ConnectionState.Open Then CnMntMdb.Open()
                Dim dt As DataTable = QueryDataTable("SELECT ID FROM メモ WHERE UserCD = " & GetUcdSql(TargetCode), CnMntMdb)
                If dt.Rows.Count > 0 Then
                    Using cmd As New OleDbCommand("UPDATE メモ SET Memo = ? WHERE UserCD = ?", CnMntMdb)
                        cmd.Parameters.Add("Memo", OleDbType.LongVarWChar).Value = txtMemo.Text
                        cmd.Parameters.Add("UserCD", OleDbType.VarWChar).Value = TargetCode
                        cmd.ExecuteNonQuery()
                    End Using
                Else
                    Using cmd As New OleDbCommand("INSERT INTO メモ ([UserCD], [Memo]) VALUES (?, ?)", CnMntMdb)
                        cmd.Parameters.Add("UserCD", OleDbType.VarWChar).Value = TargetCode
                        cmd.Parameters.Add("Memo", OleDbType.LongVarWChar).Value = txtMemo.Text
                        cmd.ExecuteNonQuery()
                    End Using
                End If

                ' ユーザーデータの履歴列に差分を保存
                Dim changes As New List(Of UsrRrkChange)()
                AddChangeIfDifferent(changes, "共通メモ", OldMemo, txtMemo.Text)
                SaveUserHistoryChanges(TargetCode, changes)

                OldMemo = txtMemo.Text
                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show("メモの保存に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try
        End If
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Using dlg As New FrmUsrRrkViewer()
            dlg.ShowHistory(TargetCode, lblUser.Text, Me)
        End Using
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Alt Or Keys.W) Then
            cmdWrite.PerformClick()
            Return True
        ElseIf keyData = (Keys.Alt Or Keys.C) Then
            cmdCancel.PerformClick()
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

    Private Sub FrmMemoEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult <> DialogResult.OK AndAlso txtMemo.Text <> OldMemo Then
            If MessageBox.Show("データが更新されていますが、保存せずに終了してもいいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
