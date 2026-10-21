Imports System.Windows.Forms

Public Class FrmMessage
    Public Shared Sub MsgDisp(ByVal msg As String, Optional ByVal waitMs As Integer = 1500)
        Using dlg As New FrmMessage()
            dlg.lblMessage.Text = msg
            dlg.WaitTimer.Interval = Math.Max(300, waitMs)
            dlg.WaitTimer.Enabled = True
            dlg.ShowDialog()
        End Using
    End Sub

    Private Sub WaitTimer_Tick(sender As Object, e As EventArgs) Handles WaitTimer.Tick
        WaitTimer.Enabled = False
        Me.Close()
    End Sub

    Private Sub lblMessage_Click(sender As Object, e As EventArgs) Handles lblMessage.Click, MyBase.Click
        WaitTimer.Enabled = False
        Me.Close()
    End Sub

    Private Sub FrmMessage_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        WaitTimer.Enabled = False
        Me.Close()
    End Sub
End Class
