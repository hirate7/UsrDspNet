Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class FrmMemoEdit
    Private TargetCode As String = ""
    Private OldMemo As String = ""

    Public Sub LoadMemo(ByVal code As String, ByVal userTitle As String)
        TargetCode = GetNumAlp(code)
        lblUser.Text = userTitle
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

    Private Sub FrmMemoEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult <> DialogResult.OK AndAlso txtMemo.Text <> OldMemo Then
            If MessageBox.Show("データが更新されていますが、保存せずに終了してもいいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
