Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class FrmPMemo
    Private TargetCode As String = ""
    Private OldPMemo As String = ""

    Public Sub LoadPMemo(ByVal code As String, ByVal userTitle As String)
        TargetCode = GetNumAlp(code)
        lblUser.Text = userTitle
        lblTantoInfo.Text = If(String.IsNullOrWhiteSpace(OptionDefaultSyainName), "担当: 未設定", $"担当: {OptionDefaultSyainName}")
        txtPmemo.Text = ""

        Try
            Dim sql As String = "SELECT * FROM PMemo WHERE コード = " & GetUcdSql(TargetCode) & " AND PcName = '" & GetPcName().Replace("'", "''") & "'"
            Dim dt As DataTable = QueryDataTable(sql, CnMntMdb)
            If dt.Rows.Count > 0 Then
                txtPmemo.Text = NulCut(dt.Rows(0)("内容"))
            End If
        Catch
        End Try

        OldPMemo = txtPmemo.Text
        txtPmemo.SelectionStart = 0
        txtPmemo.SelectionLength = 0

        If ModeDbLocation = CnModeLocal Then
            lblMes.Visible = True
        Else
            lblMes.Visible = False
        End If
    End Sub

    Private Sub cmdClear_Click(sender As Object, e As EventArgs) Handles cmdClear.Click
        txtPmemo.Text = ""
    End Sub

    Private Sub cmdNow_Click(sender As Object, e As EventArgs) Handles cmdNow.Click
        Dim s As String = txtPmemo.Text
        Dim p As Integer = txtPmemo.SelectionStart
        If p < 0 OrElse p > s.Length Then p = s.Length
        Dim s0 As String = s.Substring(0, p)
        Dim s1 As String = s.Substring(p)

        Dim res As String = s0
        If TrimX(s0) <> "" Then
            res &= Environment.NewLine & "--------------------------------" & Environment.NewLine
        End If
        res &= "【" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & "】" & Environment.NewLine
        Dim newCaret As Integer = res.Length
        txtPmemo.Text = res & s1
        txtPmemo.SelectionStart = newCaret
        txtPmemo.Focus()
    End Sub

    Private Sub cmdWrite_Click(sender As Object, e As EventArgs) Handles cmdWrite.Click
        If ModeDbLocation = CnModeLocal Then
            MessageBox.Show("ローカルモードでは無効です", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If txtPmemo.Text <> OldPMemo Then
            Try
                If CnMntMdb.State <> ConnectionState.Open Then CnMntMdb.Open()
                Dim pcName As String = GetPcName()
                If TrimX(txtPmemo.Text) = "" Then
                    Using cmd As New OleDbCommand("DELETE FROM PMemo WHERE [コード] = ? AND [PcName] = ?", CnMntMdb)
                        cmd.Parameters.Add("コード", OleDbType.VarWChar).Value = TargetCode
                        cmd.Parameters.Add("PcName", OleDbType.VarWChar).Value = pcName
                        cmd.ExecuteNonQuery()
                    End Using
                Else
                    Dim sql As String = "SELECT id FROM PMemo WHERE コード = " & GetUcdSql(TargetCode) & " AND PcName = '" & pcName.Replace("'", "''") & "'"
                    Dim dt As DataTable = QueryDataTable(sql, CnMntMdb)
                    If dt.Rows.Count > 0 Then
                        Using cmd As New OleDbCommand("UPDATE PMemo SET [内容] = ? WHERE [コード] = ? AND [PcName] = ?", CnMntMdb)
                            cmd.Parameters.Add("内容", OleDbType.LongVarWChar).Value = txtPmemo.Text
                            cmd.Parameters.Add("コード", OleDbType.VarWChar).Value = TargetCode
                            cmd.Parameters.Add("PcName", OleDbType.VarWChar).Value = pcName
                            cmd.ExecuteNonQuery()
                        End Using
                    Else
                        Using cmd As New OleDbCommand("INSERT INTO PMemo ([コード], [PcName], [内容]) VALUES (?, ?, ?)", CnMntMdb)
                            cmd.Parameters.Add("コード", OleDbType.VarWChar).Value = TargetCode
                            cmd.Parameters.Add("PcName", OleDbType.VarWChar).Value = pcName
                            cmd.Parameters.Add("内容", OleDbType.LongVarWChar).Value = txtPmemo.Text
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                End If

                ' ユーザーデータの履歴列に差分を保存
                Dim changes As New List(Of UsrRrkChange)()
                AddChangeIfDifferent(changes, "Pメモ", OldPMemo, txtPmemo.Text)
                SaveUserHistoryChanges(TargetCode, changes)

                OldPMemo = txtPmemo.Text
                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show("Pメモの保存に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub FrmPMemo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult <> DialogResult.OK AndAlso txtPmemo.Text <> OldPMemo Then
            If MessageBox.Show("データが更新されていますが、保存せずに終了してもいいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
