Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPMemo
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
    Friend WithEvents cmdNow As Button
    Friend WithEvents cmdClear As Button
    Friend WithEvents txtPmemo As TextBox
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblMes As Label
    Friend WithEvents cmdWrite As Button
    Friend WithEvents cmdCancel As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlTop = New Panel()
        Me.lblUser = New Label()
        Me.cmdNow = New Button()
        Me.cmdClear = New Button()
        Me.txtPmemo = New TextBox()
        Me.pnlBottom = New Panel()
        Me.lblMes = New Label()
        Me.cmdWrite = New Button()
        Me.cmdCancel = New Button()
        Me.pnlTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()

        Me.AutoScaleDimensions = New SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(580, 380)
        Me.MinimumSize = New Size(450, 280)
        Me.Font = New Font("MS UI Gothic", 9.75!)
        Me.Name = "FrmPMemo"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "付箋メモ (Pメモ)"

        Me.pnlTop.Dock = DockStyle.Top
        Me.pnlTop.Size = New Size(580, 40)

        Me.lblUser.Location = New Point(8, 8)
        Me.lblUser.Size = New Size(375, 24)
        Me.lblUser.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Me.lblUser.Font = New Font("MS UI Gothic", 10.5!, FontStyle.Bold)
        Me.lblUser.TextAlign = ContentAlignment.MiddleLeft

        Me.cmdNow.Text = "日時挿入(&T)"
        Me.cmdNow.Location = New Point(392, 6)
        Me.cmdNow.Size = New Size(90, 28)
        Me.cmdNow.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.cmdClear.Text = "クリア"
        Me.cmdClear.Location = New Point(488, 6)
        Me.cmdClear.Size = New Size(80, 28)
        Me.cmdClear.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.pnlTop.Controls.AddRange(New Control() {Me.lblUser, Me.cmdNow, Me.cmdClear})

        Me.txtPmemo.Dock = DockStyle.Fill
        Me.txtPmemo.Multiline = True
        Me.txtPmemo.ScrollBars = ScrollBars.Vertical
        Me.txtPmemo.BackColor = Color.FromArgb(255, 255, 200)
        Me.txtPmemo.Font = New Font("ＭＳ ゴシック", 10.5!)
        Me.txtPmemo.ImeMode = ImeMode.On

        Me.pnlBottom.Dock = DockStyle.Bottom
        Me.pnlBottom.Size = New Size(580, 48)

        Me.lblMes.Text = "※ローカルモードでは書き込みできません"
        Me.lblMes.ForeColor = Color.Red
        Me.lblMes.Location = New Point(10, 14)
        Me.lblMes.Size = New Size(270, 22)
        Me.lblMes.Visible = False

        Me.cmdWrite.Text = "書き込み終了(&W)"
        Me.cmdWrite.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.cmdWrite.Location = New Point(332, 8)
        Me.cmdWrite.Size = New Size(120, 32)
        Me.cmdWrite.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.cmdCancel.Text = "キャンセル(&C)"
        Me.cmdCancel.Location = New Point(460, 8)
        Me.cmdCancel.Size = New Size(108, 32)
        Me.cmdCancel.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.pnlBottom.Controls.AddRange(New Control() {Me.lblMes, Me.cmdWrite, Me.cmdCancel})

        Me.Controls.Add(Me.txtPmemo)
        Me.Controls.Add(Me.pnlTop)
        Me.Controls.Add(Me.pnlBottom)

        Me.pnlTop.ResumeLayout(False)
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
