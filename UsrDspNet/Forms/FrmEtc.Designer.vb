Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEtc
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

    Friend WithEvents grpIme As GroupBox
    Friend WithEvents optIme0 As RadioButton
    Friend WithEvents optIme1 As RadioButton
    Friend WithEvents optIme2 As RadioButton
    Friend WithEvents lblImeNote As Label

    Friend WithEvents grpInput As GroupBox
    Friend WithEvents optInput0 As RadioButton
    Friend WithEvents optInput1 As RadioButton
    Friend WithEvents optInput2 As RadioButton
    Friend WithEvents optInput3 As RadioButton

    Friend WithEvents grpNet As GroupBox
    Friend WithEvents optNet0 As RadioButton
    Friend WithEvents optNet1 As RadioButton
    Friend WithEvents optNet2 As RadioButton
    Friend WithEvents optNet3 As RadioButton

    Friend WithEvents grpClick As GroupBox
    Friend WithEvents optClick0 As RadioButton
    Friend WithEvents optClick1 As RadioButton
    Friend WithEvents optClick2 As RadioButton

    Friend WithEvents grpGmapLink As GroupBox
    Friend WithEvents txtGMapLink0 As TextBox
    Friend WithEvents txtGMapLink1 As TextBox
    Friend WithEvents txtGMapLink2 As TextBox

    Friend WithEvents grpVupType As GroupBox
    Friend WithEvents optVup0 As RadioButton
    Friend WithEvents optVup1 As RadioButton
    Friend WithEvents optVup2 As RadioButton

    Friend WithEvents cmdOk As Button
    Friend WithEvents cmdCancel As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblUser = New Label()
        Me.grpIme = New GroupBox()
        Me.optIme0 = New RadioButton()
        Me.optIme1 = New RadioButton()
        Me.optIme2 = New RadioButton()
        Me.lblImeNote = New Label()

        Me.grpInput = New GroupBox()
        Me.optInput0 = New RadioButton()
        Me.optInput1 = New RadioButton()
        Me.optInput2 = New RadioButton()
        Me.optInput3 = New RadioButton()

        Me.grpNet = New GroupBox()
        Me.optNet0 = New RadioButton()
        Me.optNet1 = New RadioButton()
        Me.optNet2 = New RadioButton()
        Me.optNet3 = New RadioButton()

        Me.grpClick = New GroupBox()
        Me.optClick0 = New RadioButton()
        Me.optClick1 = New RadioButton()
        Me.optClick2 = New RadioButton()

        Me.grpGmapLink = New GroupBox()
        Me.txtGMapLink0 = New TextBox()
        Me.txtGMapLink1 = New TextBox()
        Me.txtGMapLink2 = New TextBox()

        Me.grpVupType = New GroupBox()
        Me.optVup0 = New RadioButton()
        Me.optVup1 = New RadioButton()
        Me.optVup2 = New RadioButton()

        Me.cmdOk = New Button()
        Me.cmdCancel = New Button()

        Me.grpIme.SuspendLayout()
        Me.grpInput.SuspendLayout()
        Me.grpNet.SuspendLayout()
        Me.grpClick.SuspendLayout()
        Me.grpGmapLink.SuspendLayout()
        Me.grpVupType.SuspendLayout()
        Me.SuspendLayout()

        Me.AutoScaleDimensions = New SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(470, 565)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Font = New Font("MS UI Gothic", 9.75!)
        Me.Name = "FrmEtc"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "その他の情報"

        Me.lblUser.Location = New Point(12, 10)
        Me.lblUser.Size = New Size(446, 26)
        Me.lblUser.Font = New Font("MS UI Gothic", 11.25!, FontStyle.Bold)

        ' grpIme
        Me.grpIme.Text = "IME"
        Me.grpIme.Location = New Point(12, 42)
        Me.grpIme.Size = New Size(216, 155)
        Me.optIme0.Text = "不明"
        Me.optIme0.Location = New Point(16, 22)
        Me.optIme0.Size = New Size(170, 24)
        Me.optIme0.Checked = True
        Me.optIme1.Text = "MS-IME"
        Me.optIme1.Location = New Point(16, 48)
        Me.optIme1.Size = New Size(170, 24)
        Me.optIme2.Text = "ATOK"
        Me.optIme2.Location = New Point(16, 74)
        Me.optIme2.Size = New Size(170, 24)
        Me.lblImeNote.Text = "※バージョンなどが必要な場合はメモ欄に記載してください。"
        Me.lblImeNote.Font = New Font("MS UI Gothic", 8.5!)
        Me.lblImeNote.Location = New Point(14, 105)
        Me.lblImeNote.Size = New Size(192, 42)
        Me.grpIme.Controls.AddRange(New Control() {Me.optIme0, Me.optIme1, Me.optIme2, Me.lblImeNote})

        ' grpInput
        Me.grpInput.Text = "入力方法"
        Me.grpInput.Location = New Point(242, 42)
        Me.grpInput.Size = New Size(216, 155)
        Me.optInput0.Text = "不明"
        Me.optInput0.Location = New Point(16, 22)
        Me.optInput0.Size = New Size(180, 24)
        Me.optInput0.Checked = True
        Me.optInput1.Text = "ローマ字入力"
        Me.optInput1.Location = New Point(16, 48)
        Me.optInput1.Size = New Size(180, 24)
        Me.optInput2.Text = "かな入力"
        Me.optInput2.Location = New Point(16, 74)
        Me.optInput2.Size = New Size(180, 24)
        Me.optInput3.Text = "切り替えて使用"
        Me.optInput3.Location = New Point(16, 100)
        Me.optInput3.Size = New Size(180, 24)
        Me.grpInput.Controls.AddRange(New Control() {Me.optInput0, Me.optInput1, Me.optInput2, Me.optInput3})

        ' grpNet
        Me.grpNet.Text = "ネット接続"
        Me.grpNet.Location = New Point(12, 206)
        Me.grpNet.Size = New Size(216, 145)
        Me.optNet0.Text = "不明"
        Me.optNet0.Location = New Point(16, 22)
        Me.optNet0.Size = New Size(192, 24)
        Me.optNet0.Checked = True
        Me.optNet1.Text = "有りBB（ADSL/FTTH/Cable）"
        Me.optNet1.Location = New Point(16, 48)
        Me.optNet1.Size = New Size(192, 24)
        Me.optNet2.Text = "有り（ISDN、他）"
        Me.optNet2.Location = New Point(16, 74)
        Me.optNet2.Size = New Size(192, 24)
        Me.optNet3.Text = "無し"
        Me.optNet3.Location = New Point(16, 100)
        Me.optNet3.Size = New Size(192, 24)
        Me.grpNet.Controls.AddRange(New Control() {Me.optNet0, Me.optNet1, Me.optNet2, Me.optNet3})

        ' grpClick
        Me.grpClick.Text = "クリックモード"
        Me.grpClick.Location = New Point(242, 206)
        Me.grpClick.Size = New Size(216, 145)
        Me.optClick0.Text = "不明"
        Me.optClick0.Location = New Point(16, 22)
        Me.optClick0.Size = New Size(180, 24)
        Me.optClick0.Checked = True
        Me.optClick1.Text = "シングルクリック"
        Me.optClick1.Location = New Point(16, 48)
        Me.optClick1.Size = New Size(180, 24)
        Me.optClick2.Text = "ダブルクリック"
        Me.optClick2.Location = New Point(16, 74)
        Me.optClick2.Size = New Size(180, 24)
        Me.grpClick.Controls.AddRange(New Control() {Me.optClick0, Me.optClick1, Me.optClick2})

        ' grpGmapLink
        Me.grpGmapLink.Text = "Google Map Link"
        Me.grpGmapLink.Location = New Point(12, 358)
        Me.grpGmapLink.Size = New Size(446, 95)
        Me.txtGMapLink0.Location = New Point(12, 18)
        Me.txtGMapLink0.Size = New Size(422, 22)
        Me.txtGMapLink1.Location = New Point(12, 43)
        Me.txtGMapLink1.Size = New Size(422, 22)
        Me.txtGMapLink2.Location = New Point(12, 68)
        Me.txtGMapLink2.Size = New Size(422, 22)
        Me.grpGmapLink.Controls.AddRange(New Control() {Me.txtGMapLink0, Me.txtGMapLink1, Me.txtGMapLink2})

        ' grpVupType
        Me.grpVupType.Text = "バージョンアップ方法 (VupType)"
        Me.grpVupType.Location = New Point(12, 460)
        Me.grpVupType.Size = New Size(446, 52)
        Me.optVup0.Text = "未定"
        Me.optVup0.Location = New Point(24, 20)
        Me.optVup0.Size = New Size(110, 24)
        Me.optVup0.Checked = True
        Me.optVup1.Text = "ネット"
        Me.optVup1.Location = New Point(160, 20)
        Me.optVup1.Size = New Size(110, 24)
        Me.optVup2.Text = "CD"
        Me.optVup2.Location = New Point(296, 20)
        Me.optVup2.Size = New Size(110, 24)
        Me.grpVupType.Controls.AddRange(New Control() {Me.optVup0, Me.optVup1, Me.optVup2})

        Me.cmdOk.Text = "更新終了(&U)"
        Me.cmdOk.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.cmdOk.Location = New Point(230, 520)
        Me.cmdOk.Size = New Size(110, 34)

        Me.cmdCancel.Text = "キャンセル(&C)"
        Me.cmdCancel.Location = New Point(348, 520)
        Me.cmdCancel.Size = New Size(110, 34)

        Me.Controls.AddRange(New Control() {
            Me.lblUser, Me.grpIme, Me.grpInput, Me.grpNet, Me.grpClick, Me.grpGmapLink, Me.grpVupType, Me.cmdOk, Me.cmdCancel
        })

        Me.grpIme.ResumeLayout(False)
        Me.grpInput.ResumeLayout(False)
        Me.grpNet.ResumeLayout(False)
        Me.grpClick.ResumeLayout(False)
        Me.grpGmapLink.ResumeLayout(False)
        Me.grpGmapLink.PerformLayout()
        Me.grpVupType.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
End Class
