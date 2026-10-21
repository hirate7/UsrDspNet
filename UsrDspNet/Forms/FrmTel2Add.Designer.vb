Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTel2Add
    Inherits System.Windows.Forms.Form

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer
    Friend WithEvents lblUser As Label
    Friend WithEvents lblNote As Label
    Friend WithEvents lblTel1 As Label
    Friend WithEvents lblTel2 As Label
    Friend WithEvents lblTel3 As Label
    Friend WithEvents lblTel4 As Label
    Friend WithEvents lblTel5 As Label
    Friend WithEvents txtTelEx0 As TextBox
    Friend WithEvents txtTelEx1 As TextBox
    Friend WithEvents txtTelEx2 As TextBox
    Friend WithEvents txtTelEx3 As TextBox
    Friend WithEvents txtTelEx4 As TextBox
    Friend WithEvents cmdOk As Button
    Friend WithEvents cmdCancel As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblUser = New Label()
        Me.lblNote = New Label()
        Me.lblTel1 = New Label()
        Me.lblTel2 = New Label()
        Me.lblTel3 = New Label()
        Me.lblTel4 = New Label()
        Me.lblTel5 = New Label()
        Me.txtTelEx0 = New TextBox()
        Me.txtTelEx1 = New TextBox()
        Me.txtTelEx2 = New TextBox()
        Me.txtTelEx3 = New TextBox()
        Me.txtTelEx4 = New TextBox()
        Me.cmdOk = New Button()
        Me.cmdCancel = New Button()
        Me.SuspendLayout()

        Me.AutoScaleDimensions = New SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(440, 290)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Font = New Font("MS UI Gothic", 9.75!)
        Me.Name = "FrmTel2Add"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "その他の電話番号の編集"

        Me.lblUser.Location = New Point(12, 10)
        Me.lblUser.Size = New Size(416, 24)
        Me.lblUser.Font = New Font("MS UI Gothic", 10.5!, FontStyle.Bold)

        Me.lblNote.Text = "※電話番号と備考（自宅・携帯・FAXなど）を入力してください。"
        Me.lblNote.ForeColor = Color.FromArgb(60, 60, 60)
        Me.lblNote.Location = New Point(12, 36)
        Me.lblNote.Size = New Size(416, 20)

        Dim labels() As Label = {Me.lblTel1, Me.lblTel2, Me.lblTel3, Me.lblTel4, Me.lblTel5}
        Dim boxes() As TextBox = {Me.txtTelEx0, Me.txtTelEx1, Me.txtTelEx2, Me.txtTelEx3, Me.txtTelEx4}
        For i As Integer = 0 To 4
            labels(i).Text = "追加電話 " & (i + 1).ToString() & ":"
            labels(i).Location = New Point(12, 65 + i * 32)
            labels(i).Size = New Size(82, 23)
            labels(i).TextAlign = ContentAlignment.MiddleRight

            boxes(i).Location = New Point(100, 65 + i * 32)
            boxes(i).Size = New Size(320, 23)
            boxes(i).Font = New Font("ＭＳ ゴシック", 10.0!)
            Me.Controls.Add(labels(i))
            Me.Controls.Add(boxes(i))
        Next

        Me.cmdOk.Text = "更新終了(&U)"
        Me.cmdOk.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.cmdOk.Location = New Point(195, 240)
        Me.cmdOk.Size = New Size(110, 34)

        Me.cmdCancel.Text = "キャンセル(&C)"
        Me.cmdCancel.Location = New Point(315, 240)
        Me.cmdCancel.Size = New Size(105, 34)

        Me.Controls.AddRange(New Control() {Me.lblUser, Me.lblNote, Me.cmdOk, Me.cmdCancel})
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
