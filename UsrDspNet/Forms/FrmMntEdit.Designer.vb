Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMntEdit
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

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitleId As Label
    Friend WithEvents LblID As Label
    Friend WithEvents lblTitleSakusei As Label
    Friend WithEvents LblSakusei As Label
    Friend WithEvents lblTitleUsr As Label
    Friend WithEvents LblUsrCd As Label
    Friend WithEvents LblSibu As Label
    Friend WithEvents LblSjName As Label
    Friend WithEvents LblJsName As Label

    Friend WithEvents lblTitleSagyou As Label
    Friend WithEvents TxtSagyou As TextBox
    Friend WithEvents TxtSagyouTime As TextBox

    Friend WithEvents lblTitleBunrui As Label
    Friend WithEvents CmbBunrui As ComboBox

    Friend WithEvents lblTitleSyain As Label
    Friend WithEvents LblSyainCD As Label
    Friend WithEvents CmbSyain As ComboBox

    Friend WithEvents lblTitleVisit As Label
    Friend WithEvents inmVisit As NumericUpDown

    Friend WithEvents lblTitleKijitsu As Label
    Friend WithEvents TxtKijitsu As TextBox
    Friend WithEvents CmdOnaji As Button
    Friend WithEvents CmdKongetsu As Button
    Friend WithEvents CmdRaigetsu As Button

    Friend WithEvents ChkKanryou As CheckBox

    Friend WithEvents lblTitleNaiyou As Label
    Friend WithEvents cmdNouhinTmp As Button
    Friend WithEvents cmdOldMac As Button
    Friend WithEvents cmdCopy As Button
    Friend WithEvents txtNaiyou As TextBox

    Friend WithEvents pnlBottom As Panel
    Friend WithEvents CmdDelete As Button
    Friend WithEvents CmdUpdate As Button
    Friend WithEvents cmdCancel As Button
    Friend WithEvents statusStrip1 As StatusStrip
    Friend WithEvents lblStatusGuide As ToolStripStatusLabel

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlHeader = New Panel()
        Me.lblTitleId = New Label()
        Me.LblID = New Label()
        Me.lblTitleSakusei = New Label()
        Me.LblSakusei = New Label()
        Me.lblTitleUsr = New Label()
        Me.LblUsrCd = New Label()
        Me.LblSibu = New Label()
        Me.LblSjName = New Label()
        Me.LblJsName = New Label()

        Me.lblTitleSagyou = New Label()
        Me.TxtSagyou = New TextBox()
        Me.TxtSagyouTime = New TextBox()

        Me.lblTitleBunrui = New Label()
        Me.CmbBunrui = New ComboBox()

        Me.lblTitleSyain = New Label()
        Me.LblSyainCD = New Label()
        Me.CmbSyain = New ComboBox()

        Me.lblTitleVisit = New Label()
        Me.inmVisit = New NumericUpDown()

        Me.lblTitleKijitsu = New Label()
        Me.TxtKijitsu = New TextBox()
        Me.CmdOnaji = New Button()
        Me.CmdKongetsu = New Button()
        Me.CmdRaigetsu = New Button()

        Me.ChkKanryou = New CheckBox()

        Me.lblTitleNaiyou = New Label()
        Me.cmdNouhinTmp = New Button()
        Me.cmdOldMac = New Button()
        Me.cmdCopy = New Button()
        Me.txtNaiyou = New TextBox()

        Me.pnlBottom = New Panel()
        Me.CmdDelete = New Button()
        Me.CmdUpdate = New Button()
        Me.cmdCancel = New Button()

        Me.statusStrip1 = New StatusStrip()
        Me.lblStatusGuide = New ToolStripStatusLabel()

        Me.pnlHeader.SuspendLayout()
        DirectCast(Me.inmVisit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()

        ' Form
        Me.AutoScaleDimensions = New SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(720, 560)
        Me.MinimumSize = New Size(680, 480)
        Me.Font = New Font("MS UI Gothic", 9.75!)
        Me.Name = "FrmMntEdit"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "メンテナンス記録の編集"

        ' pnlHeader
        Me.pnlHeader.Dock = DockStyle.Top
        Me.pnlHeader.Size = New Size(720, 175)
        Me.pnlHeader.Padding = New Padding(8)

        ' Row 1: ID & 作成日
        Me.lblTitleId.Text = "ID:"
        Me.lblTitleId.Location = New Point(12, 10)
        Me.lblTitleId.Size = New Size(35, 20)
        Me.lblTitleId.TextAlign = ContentAlignment.MiddleRight

        Me.LblID.BorderStyle = BorderStyle.Fixed3D
        Me.LblID.BackColor = Color.White
        Me.LblID.Location = New Point(52, 10)
        Me.LblID.Size = New Size(90, 22)
        Me.LblID.TextAlign = ContentAlignment.MiddleCenter

        Me.lblTitleSakusei.Text = "作成日:"
        Me.lblTitleSakusei.Location = New Point(155, 10)
        Me.lblTitleSakusei.Size = New Size(55, 20)
        Me.lblTitleSakusei.TextAlign = ContentAlignment.MiddleRight

        Me.LblSakusei.BorderStyle = BorderStyle.Fixed3D
        Me.LblSakusei.BackColor = Color.White
        Me.LblSakusei.Location = New Point(215, 10)
        Me.LblSakusei.Size = New Size(165, 22)
        Me.LblSakusei.TextAlign = ContentAlignment.MiddleCenter

        ' Row 2: ユーザー情報
        Me.lblTitleUsr.Text = "ユーザー:"
        Me.lblTitleUsr.Location = New Point(4, 38)
        Me.lblTitleUsr.Size = New Size(60, 22)
        Me.lblTitleUsr.TextAlign = ContentAlignment.MiddleRight

        Me.LblUsrCd.BorderStyle = BorderStyle.Fixed3D
        Me.LblUsrCd.BackColor = Color.FromArgb(255, 255, 220)
        Me.LblUsrCd.Font = New Font("MS UI Gothic", 10.0!, FontStyle.Bold)
        Me.LblUsrCd.Location = New Point(68, 38)
        Me.LblUsrCd.Size = New Size(70, 24)
        Me.LblUsrCd.TextAlign = ContentAlignment.MiddleCenter

        Me.LblSibu.BorderStyle = BorderStyle.Fixed3D
        Me.LblSibu.BackColor = Color.FromArgb(255, 255, 220)
        Me.LblSibu.Location = New Point(142, 38)
        Me.LblSibu.Size = New Size(90, 24)
        Me.LblSibu.TextAlign = ContentAlignment.MiddleLeft

        Me.LblSjName.BorderStyle = BorderStyle.Fixed3D
        Me.LblSjName.BackColor = Color.FromArgb(255, 255, 220)
        Me.LblSjName.Font = New Font("MS UI Gothic", 10.5!, FontStyle.Bold)
        Me.LblSjName.Location = New Point(236, 38)
        Me.LblSjName.Size = New Size(280, 24)
        Me.LblSjName.TextAlign = ContentAlignment.MiddleLeft

        Me.LblJsName.BorderStyle = BorderStyle.Fixed3D
        Me.LblJsName.BackColor = Color.FromArgb(255, 255, 220)
        Me.LblJsName.Location = New Point(520, 38)
        Me.LblJsName.Size = New Size(185, 24)
        Me.LblJsName.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Me.LblJsName.TextAlign = ContentAlignment.MiddleLeft

        ' Row 3: 作業日時 & 分類 & 訪問
        Me.lblTitleSagyou.Text = "作業日時:"
        Me.lblTitleSagyou.Location = New Point(4, 72)
        Me.lblTitleSagyou.Size = New Size(60, 22)
        Me.lblTitleSagyou.TextAlign = ContentAlignment.MiddleRight

        Me.TxtSagyou.Location = New Point(68, 72)
        Me.TxtSagyou.Size = New Size(95, 23)
        Me.TxtSagyou.ImeMode = ImeMode.Disable

        Me.TxtSagyouTime.Location = New Point(167, 72)
        Me.TxtSagyouTime.Size = New Size(60, 23)
        Me.TxtSagyouTime.ImeMode = ImeMode.Disable

        Me.lblTitleBunrui.Text = "分類:"
        Me.lblTitleBunrui.Location = New Point(235, 72)
        Me.lblTitleBunrui.Size = New Size(45, 22)
        Me.lblTitleBunrui.TextAlign = ContentAlignment.MiddleRight

        Me.CmbBunrui.Location = New Point(284, 72)
        Me.CmbBunrui.Size = New Size(150, 23)
        Me.CmbBunrui.ImeMode = ImeMode.On

        Me.lblTitleVisit.Text = "訪問:"
        Me.lblTitleVisit.Location = New Point(445, 72)
        Me.lblTitleVisit.Size = New Size(45, 22)
        Me.lblTitleVisit.TextAlign = ContentAlignment.MiddleRight

        Me.inmVisit.Location = New Point(494, 72)
        Me.inmVisit.Size = New Size(60, 23)
        Me.inmVisit.Minimum = 0
        Me.inmVisit.Maximum = 99

        ' Row 4: 担当社員 & 期日 & 完了
        Me.lblTitleSyain.Text = "担当者:"
        Me.lblTitleSyain.Location = New Point(4, 104)
        Me.lblTitleSyain.Size = New Size(60, 22)
        Me.lblTitleSyain.TextAlign = ContentAlignment.MiddleRight

        Me.LblSyainCD.BorderStyle = BorderStyle.Fixed3D
        Me.LblSyainCD.BackColor = Color.White
        Me.LblSyainCD.Location = New Point(68, 104)
        Me.LblSyainCD.Size = New Size(42, 23)
        Me.LblSyainCD.TextAlign = ContentAlignment.MiddleCenter

        Me.CmbSyain.DropDownStyle = ComboBoxStyle.DropDownList
        Me.CmbSyain.Location = New Point(114, 104)
        Me.CmbSyain.Size = New Size(135, 23)

        Me.lblTitleKijitsu.Text = "期日:"
        Me.lblTitleKijitsu.Location = New Point(255, 104)
        Me.lblTitleKijitsu.Size = New Size(40, 22)
        Me.lblTitleKijitsu.TextAlign = ContentAlignment.MiddleRight

        Me.TxtKijitsu.Location = New Point(299, 104)
        Me.TxtKijitsu.Size = New Size(95, 23)
        Me.TxtKijitsu.ImeMode = ImeMode.Disable

        Me.CmdOnaji.Text = "作業日と同日"
        Me.CmdOnaji.Location = New Point(398, 103)
        Me.CmdOnaji.Size = New Size(92, 25)

        Me.CmdKongetsu.Text = "今月中"
        Me.CmdKongetsu.Location = New Point(493, 103)
        Me.CmdKongetsu.Size = New Size(62, 25)

        Me.CmdRaigetsu.Text = "来月中"
        Me.CmdRaigetsu.Location = New Point(558, 103)
        Me.CmdRaigetsu.Size = New Size(62, 25)

        Me.ChkKanryou.Text = "完了"
        Me.ChkKanryou.Font = New Font("MS UI Gothic", 10.0!, FontStyle.Bold)
        Me.ChkKanryou.Location = New Point(632, 104)
        Me.ChkKanryou.Size = New Size(70, 24)

        ' Row 5: 内容ラベル & テンプレボタン
        Me.lblTitleNaiyou.Text = "内容:"
        Me.lblTitleNaiyou.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.lblTitleNaiyou.Location = New Point(12, 142)
        Me.lblTitleNaiyou.Size = New Size(55, 22)
        Me.lblTitleNaiyou.TextAlign = ContentAlignment.MiddleLeft

        Me.cmdNouhinTmp.Text = "納品時テンプレ挿入"
        Me.cmdNouhinTmp.Location = New Point(330, 138)
        Me.cmdNouhinTmp.Size = New Size(140, 28)
        Me.cmdNouhinTmp.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.cmdOldMac.Text = "前使用機種挿入"
        Me.cmdOldMac.Location = New Point(476, 138)
        Me.cmdOldMac.Size = New Size(125, 28)
        Me.cmdOldMac.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.cmdCopy.Text = "コピー"
        Me.cmdCopy.Location = New Point(607, 138)
        Me.cmdCopy.Size = New Size(98, 28)
        Me.cmdCopy.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.pnlHeader.Controls.AddRange(New Control() {
            Me.lblTitleId, Me.LblID, Me.lblTitleSakusei, Me.LblSakusei,
            Me.lblTitleUsr, Me.LblUsrCd, Me.LblSibu, Me.LblSjName, Me.LblJsName,
            Me.lblTitleSagyou, Me.TxtSagyou, Me.TxtSagyouTime,
            Me.lblTitleBunrui, Me.CmbBunrui, Me.lblTitleVisit, Me.inmVisit,
            Me.lblTitleSyain, Me.LblSyainCD, Me.CmbSyain,
            Me.lblTitleKijitsu, Me.TxtKijitsu, Me.CmdOnaji, Me.CmdKongetsu, Me.CmdRaigetsu, Me.ChkKanryou,
            Me.lblTitleNaiyou, Me.cmdNouhinTmp, Me.cmdOldMac, Me.cmdCopy
        })

        ' txtNaiyou
        Me.txtNaiyou.Dock = DockStyle.Fill
        Me.txtNaiyou.Multiline = True
        Me.txtNaiyou.ScrollBars = ScrollBars.Vertical
        Me.txtNaiyou.Font = New Font("ＭＳ ゴシック", 10.5!)
        Me.txtNaiyou.ImeMode = ImeMode.On

        ' pnlBottom
        Me.pnlBottom.Dock = DockStyle.Bottom
        Me.pnlBottom.Size = New Size(720, 48)

        Me.CmdDelete.Text = "削除(&D)"
        Me.CmdDelete.ForeColor = Color.DarkRed
        Me.CmdDelete.Location = New Point(12, 8)
        Me.CmdDelete.Size = New Size(105, 32)

        Me.CmdUpdate.Text = "更新(&U)"
        Me.CmdUpdate.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.CmdUpdate.Location = New Point(475, 8)
        Me.CmdUpdate.Size = New Size(110, 32)
        Me.CmdUpdate.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.cmdCancel.Text = "キャンセル(&C)"
        Me.cmdCancel.Location = New Point(595, 8)
        Me.cmdCancel.Size = New Size(110, 32)
        Me.cmdCancel.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.pnlBottom.Controls.AddRange(New Control() {Me.CmdDelete, Me.CmdUpdate, Me.cmdCancel})

        ' statusStrip1
        Me.statusStrip1.Items.AddRange(New ToolStripItem() {Me.lblStatusGuide})
        Me.lblStatusGuide.Spring = True
        Me.lblStatusGuide.TextAlign = ContentAlignment.MiddleLeft
        Me.lblStatusGuide.Text = "メンテナンス記録を入力してください"

        Me.Controls.Add(Me.txtNaiyou)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.statusStrip1)

        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        DirectCast(Me.inmVisit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
