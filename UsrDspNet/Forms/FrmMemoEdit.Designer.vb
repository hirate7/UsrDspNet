Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMemoEdit
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
    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblUser As Label
    Friend WithEvents txtMemo As TextBox
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblLocalWarn As Label
    Friend WithEvents cmdWrite As Button
    Friend WithEvents cmdCancel As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlTop = New Panel()
        Me.lblUser = New Label()
        Me.txtMemo = New TextBox()
        Me.pnlBottom = New Panel()
        Me.lblLocalWarn = New Label()
        Me.cmdWrite = New Button()
        Me.cmdCancel = New Button()
        Me.pnlTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()

        Me.AutoScaleDimensions = New SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(620, 420)
        Me.MinimumSize = New Size(450, 300)
        Me.Font = New Font("MS UI Gothic", 9.75!)
        Me.Name = "FrmMemoEdit"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "メモの編集"

        Me.pnlTop.Dock = DockStyle.Top
        Me.pnlTop.Size = New Size(620, 38)
        Me.lblUser.Dock = DockStyle.Fill
        Me.lblUser.Font = New Font("MS UI Gothic", 11.25!, FontStyle.Bold)
        Me.lblUser.Padding = New Padding(8, 0, 8, 0)
        Me.lblUser.TextAlign = ContentAlignment.MiddleLeft
        Me.pnlTop.Controls.Add(Me.lblUser)

        Me.txtMemo.Dock = DockStyle.Fill
        Me.txtMemo.Multiline = True
        Me.txtMemo.ScrollBars = ScrollBars.Vertical
        Me.txtMemo.Font = New Font("ＭＳ ゴシック", 10.5!)
        Me.txtMemo.ImeMode = ImeMode.On

        Me.pnlBottom.Dock = DockStyle.Bottom
        Me.pnlBottom.Size = New Size(620, 48)

        Me.lblLocalWarn.Text = "※ローカルモードでは書き込みできません"
        Me.lblLocalWarn.ForeColor = Color.Red
        Me.lblLocalWarn.Location = New Point(12, 14)
        Me.lblLocalWarn.Size = New Size(280, 22)
        Me.lblLocalWarn.Visible = False

        Me.cmdWrite.Text = "書き込み終了(&W)"
        Me.cmdWrite.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.cmdWrite.Location = New Point(370, 8)
        Me.cmdWrite.Size = New Size(120, 32)
        Me.cmdWrite.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.cmdCancel.Text = "キャンセル(&C)"
        Me.cmdCancel.Location = New Point(498, 8)
        Me.cmdCancel.Size = New Size(110, 32)
        Me.cmdCancel.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.pnlBottom.Controls.AddRange(New Control() {Me.lblLocalWarn, Me.cmdWrite, Me.cmdCancel})

        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlBottom)

        Me.pnlTop.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
