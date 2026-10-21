Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMntFind
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
    Friend WithEvents lblKwTitle As Label
    Friend WithEvents txtFind0 As TextBox
    Friend WithEvents txtFind1 As TextBox
    Friend WithEvents txtFind2 As TextBox
    Friend WithEvents optFindAnd As RadioButton
    Friend WithEvents optFindOr As RadioButton
    Friend WithEvents cmdMakeSql As Button
    Friend WithEvents cmdFind As Button
    Friend WithEvents lblCnt As Label
    Friend WithEvents txtSql As TextBox

    Friend WithEvents splitResults As SplitContainer
    Friend WithEvents dgvMnt As DataGridView

    Friend WithEvents pnlMntHeader As Panel
    Friend WithEvents lblSagyou As Label
    Friend WithEvents txtSagyoubi As TextBox
    Friend WithEvents lblBunrui As Label
    Friend WithEvents txtBunrui As TextBox
    Friend WithEvents lblSyain As Label
    Friend WithEvents txtSyain As TextBox
    Friend WithEvents lblKijitu As Label
    Friend WithEvents txtKijitu As TextBox
    Friend WithEvents chkComp As CheckBox
    Friend WithEvents lblDeletedLog As Label
    Friend WithEvents cmdMarker As Button
    Friend WithEvents cmdEditMnt As Button

    Friend WithEvents rtbNaiyou As RichTextBox

    Friend WithEvents pnlUserInfo As Panel
    Friend WithEvents lblUsrTitle As Label
    Friend WithEvents txtUsrCode As TextBox
    Friend WithEvents txtSibu As TextBox
    Friend WithEvents txtYago As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents cmdDispUserData As Button
    Friend WithEvents lblHwInfo As Label
    Friend WithEvents txtPc As TextBox
    Friend WithEvents txtDisplay As TextBox
    Friend WithEvents txtPrinter As TextBox
    Friend WithEvents txtMiniPrinter As TextBox
    Friend WithEvents txtBCR As TextBox
    Friend WithEvents txtBkup As TextBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlTop = New Panel()
        Me.lblKwTitle = New Label()
        Me.txtFind0 = New TextBox()
        Me.txtFind1 = New TextBox()
        Me.txtFind2 = New TextBox()
        Me.optFindAnd = New RadioButton()
        Me.optFindOr = New RadioButton()
        Me.cmdMakeSql = New Button()
        Me.cmdFind = New Button()
        Me.lblCnt = New Label()
        Me.txtSql = New TextBox()

        Me.splitResults = New SplitContainer()
        Me.dgvMnt = New DataGridView()

        Me.pnlMntHeader = New Panel()
        Me.lblSagyou = New Label()
        Me.txtSagyoubi = New TextBox()
        Me.lblBunrui = New Label()
        Me.txtBunrui = New TextBox()
        Me.lblSyain = New Label()
        Me.txtSyain = New TextBox()
        Me.lblKijitu = New Label()
        Me.txtKijitu = New TextBox()
        Me.chkComp = New CheckBox()
        Me.lblDeletedLog = New Label()
        Me.cmdMarker = New Button()
        Me.cmdEditMnt = New Button()

        Me.rtbNaiyou = New RichTextBox()

        Me.pnlUserInfo = New Panel()
        Me.lblUsrTitle = New Label()
        Me.txtUsrCode = New TextBox()
        Me.txtSibu = New TextBox()
        Me.txtYago = New TextBox()
        Me.txtName = New TextBox()
        Me.cmdDispUserData = New Button()
        Me.lblHwInfo = New Label()
        Me.txtPc = New TextBox()
        Me.txtDisplay = New TextBox()
        Me.txtPrinter = New TextBox()
        Me.txtMiniPrinter = New TextBox()
        Me.txtBCR = New TextBox()
        Me.txtBkup = New TextBox()

        Me.pnlTop.SuspendLayout()
        DirectCast(Me.splitResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitResults.Panel1.SuspendLayout()
        Me.splitResults.Panel2.SuspendLayout()
        Me.splitResults.SuspendLayout()
        DirectCast(Me.dgvMnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMntHeader.SuspendLayout()
        Me.pnlUserInfo.SuspendLayout()
        Me.SuspendLayout()

        Me.AutoScaleDimensions = New SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(940, 720)
        Me.MinimumSize = New Size(820, 580)
        Me.Font = New Font("MS UI Gothic", 9.75!)
        Me.Name = "FrmMntFind"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "メンテナンス記録 全文検索"

        ' pnlTop
        Me.pnlTop.Dock = DockStyle.Top
        Me.pnlTop.Size = New Size(940, 128)

        Me.lblKwTitle.Text = "検索キーワード (最大3語):"
        Me.lblKwTitle.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.lblKwTitle.Location = New Point(10, 10)
        Me.lblKwTitle.Size = New Size(165, 22)
        Me.lblKwTitle.TextAlign = ContentAlignment.MiddleLeft

        Me.txtFind0.Location = New Point(178, 9)
        Me.txtFind0.Size = New Size(140, 23)
        Me.txtFind0.ForeColor = Color.FromArgb(&HAA, 0, 0)
        Me.txtFind0.Font = New Font("ＭＳ ゴシック", 10.0!, FontStyle.Bold)
        Me.txtFind0.ImeMode = ImeMode.On

        Me.txtFind1.Location = New Point(324, 9)
        Me.txtFind1.Size = New Size(140, 23)
        Me.txtFind1.ForeColor = Color.FromArgb(0, 0, &HBB)
        Me.txtFind1.Font = New Font("ＭＳ ゴシック", 10.0!, FontStyle.Bold)
        Me.txtFind1.ImeMode = ImeMode.On

        Me.txtFind2.Location = New Point(470, 9)
        Me.txtFind2.Size = New Size(140, 23)
        Me.txtFind2.ForeColor = Color.FromArgb(0, &H88, 0)
        Me.txtFind2.Font = New Font("ＭＳ ゴシック", 10.0!, FontStyle.Bold)
        Me.txtFind2.ImeMode = ImeMode.On

        Me.optFindAnd.Text = "AND"
        Me.optFindAnd.Location = New Point(620, 10)
        Me.optFindAnd.Size = New Size(55, 22)
        Me.optFindAnd.Checked = True

        Me.optFindOr.Text = "OR"
        Me.optFindOr.Location = New Point(678, 10)
        Me.optFindOr.Size = New Size(48, 22)

        Me.cmdFind.Text = "検索実行(&F)"
        Me.cmdFind.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.cmdFind.BackColor = Color.FromArgb(225, 240, 255)
        Me.cmdFind.Location = New Point(732, 6)
        Me.cmdFind.Size = New Size(105, 30)

        Me.lblCnt.Text = "0件"
        Me.lblCnt.Font = New Font("MS UI Gothic", 10.0!, FontStyle.Bold)
        Me.lblCnt.Location = New Point(844, 10)
        Me.lblCnt.Size = New Size(90, 22)
        Me.lblCnt.TextAlign = ContentAlignment.MiddleLeft

        Me.cmdMakeSql.Text = "SQL生成"
        Me.cmdMakeSql.Location = New Point(10, 40)
        Me.cmdMakeSql.Size = New Size(75, 26)

        Me.txtSql.Multiline = True
        Me.txtSql.ScrollBars = ScrollBars.Vertical
        Me.txtSql.Font = New Font("ＭＳ ゴシック", 9.0!)
        Me.txtSql.Location = New Point(92, 40)
        Me.txtSql.Size = New Size(838, 82)
        Me.txtSql.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        Me.pnlTop.Controls.AddRange(New Control() {
            Me.lblKwTitle, Me.txtFind0, Me.txtFind1, Me.txtFind2,
            Me.optFindAnd, Me.optFindOr, Me.cmdFind, Me.lblCnt,
            Me.cmdMakeSql, Me.txtSql
        })

        ' splitResults
        Me.splitResults.Dock = DockStyle.Fill
        Me.splitResults.Orientation = Orientation.Horizontal
        Me.splitResults.Size = New Size(940, 592)
        Me.splitResults.SplitterDistance = 230

        ' dgvMnt
        Me.dgvMnt.Dock = DockStyle.Fill
        Me.dgvMnt.AllowUserToAddRows = False
        Me.dgvMnt.AllowUserToDeleteRows = False
        Me.dgvMnt.AllowUserToResizeRows = False
        Me.dgvMnt.ReadOnly = True
        Me.dgvMnt.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Me.dgvMnt.MultiSelect = False
        Me.dgvMnt.RowHeadersVisible = False
        Me.dgvMnt.BackgroundColor = Color.White
        Me.splitResults.Panel1.Controls.Add(Me.dgvMnt)

        ' Panel2: Selected Record & User Info
        Me.pnlMntHeader.Dock = DockStyle.Top
        Me.pnlMntHeader.Size = New Size(940, 36)

        Me.lblSagyou.Text = "作業日:"
        Me.lblSagyou.Location = New Point(6, 8)
        Me.lblSagyou.Size = New Size(48, 20)
        Me.txtSagyoubi.ReadOnly = True
        Me.txtSagyoubi.BackColor = Color.White
        Me.txtSagyoubi.Location = New Point(56, 6)
        Me.txtSagyoubi.Size = New Size(88, 23)

        Me.lblBunrui.Text = "分類:"
        Me.lblBunrui.Location = New Point(150, 8)
        Me.lblBunrui.Size = New Size(38, 20)
        Me.txtBunrui.ReadOnly = True
        Me.txtBunrui.BackColor = Color.White
        Me.txtBunrui.Location = New Point(190, 6)
        Me.txtBunrui.Size = New Size(110, 23)

        Me.lblSyain.Text = "担当:"
        Me.lblSyain.Location = New Point(306, 8)
        Me.lblSyain.Size = New Size(38, 20)
        Me.txtSyain.ReadOnly = True
        Me.txtSyain.BackColor = Color.White
        Me.txtSyain.Location = New Point(346, 6)
        Me.txtSyain.Size = New Size(95, 23)

        Me.lblKijitu.Text = "期日:"
        Me.lblKijitu.Location = New Point(448, 8)
        Me.lblKijitu.Size = New Size(38, 20)
        Me.txtKijitu.ReadOnly = True
        Me.txtKijitu.BackColor = Color.White
        Me.txtKijitu.Location = New Point(488, 6)
        Me.txtKijitu.Size = New Size(88, 23)

        Me.chkComp.Text = "完了"
        Me.chkComp.Enabled = False
        Me.chkComp.Location = New Point(584, 7)
        Me.chkComp.Size = New Size(55, 22)

        Me.lblDeletedLog.Text = "【削除済】"
        Me.lblDeletedLog.ForeColor = Color.Red
        Me.lblDeletedLog.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.lblDeletedLog.Location = New Point(642, 8)
        Me.lblDeletedLog.Size = New Size(72, 20)
        Me.lblDeletedLog.Visible = False

        Me.cmdMarker.Text = "マーカー再表示"
        Me.cmdMarker.Location = New Point(720, 4)
        Me.cmdMarker.Size = New Size(100, 27)
        Me.cmdMarker.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.cmdEditMnt.Text = "記録を編集"
        Me.cmdEditMnt.Location = New Point(826, 4)
        Me.cmdEditMnt.Size = New Size(102, 27)
        Me.cmdEditMnt.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.pnlMntHeader.Controls.AddRange(New Control() {
            Me.lblSagyou, Me.txtSagyoubi, Me.lblBunrui, Me.txtBunrui,
            Me.lblSyain, Me.txtSyain, Me.lblKijitu, Me.txtKijitu,
            Me.chkComp, Me.lblDeletedLog, Me.cmdMarker, Me.cmdEditMnt
        })

        ' pnlUserInfo (Bottom)
        Me.pnlUserInfo.Dock = DockStyle.Bottom
        Me.pnlUserInfo.Size = New Size(940, 92)
        Me.pnlUserInfo.BackColor = Color.FromArgb(245, 245, 248)

        Me.lblUsrTitle.Text = "ユーザー:"
        Me.lblUsrTitle.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.lblUsrTitle.Location = New Point(6, 8)
        Me.lblUsrTitle.Size = New Size(62, 22)

        Me.txtUsrCode.ReadOnly = True
        Me.txtUsrCode.BackColor = Color.White
        Me.txtUsrCode.Location = New Point(70, 6)
        Me.txtUsrCode.Size = New Size(68, 23)

        Me.txtSibu.ReadOnly = True
        Me.txtSibu.BackColor = Color.White
        Me.txtSibu.Location = New Point(142, 6)
        Me.txtSibu.Size = New Size(95, 23)

        Me.txtYago.ReadOnly = True
        Me.txtYago.BackColor = Color.White
        Me.txtYago.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.txtYago.Location = New Point(241, 6)
        Me.txtYago.Size = New Size(290, 23)

        Me.txtName.ReadOnly = True
        Me.txtName.BackColor = Color.White
        Me.txtName.Location = New Point(535, 6)
        Me.txtName.Size = New Size(195, 23)

        Me.cmdDispUserData.Text = "ユーザーデータ表示(&U)"
        Me.cmdDispUserData.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.cmdDispUserData.BackColor = Color.FromArgb(255, 240, 200)
        Me.cmdDispUserData.Location = New Point(740, 4)
        Me.cmdDispUserData.Size = New Size(188, 28)
        Me.cmdDispUserData.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Me.cmdDispUserData.Enabled = False

        Me.lblHwInfo.Text = "機器構成:"
        Me.lblHwInfo.Location = New Point(6, 38)
        Me.lblHwInfo.Size = New Size(62, 22)

        Me.txtPc.ReadOnly = True
        Me.txtPc.BackColor = Color.White
        Me.txtPc.Location = New Point(70, 36)
        Me.txtPc.Size = New Size(280, 22)

        Me.txtDisplay.ReadOnly = True
        Me.txtDisplay.BackColor = Color.White
        Me.txtDisplay.Location = New Point(354, 36)
        Me.txtDisplay.Size = New Size(280, 22)

        Me.txtPrinter.ReadOnly = True
        Me.txtPrinter.BackColor = Color.White
        Me.txtPrinter.Location = New Point(638, 36)
        Me.txtPrinter.Size = New Size(290, 22)

        Me.txtMiniPrinter.ReadOnly = True
        Me.txtMiniPrinter.BackColor = Color.White
        Me.txtMiniPrinter.Location = New Point(70, 62)
        Me.txtMiniPrinter.Size = New Size(280, 22)

        Me.txtBCR.ReadOnly = True
        Me.txtBCR.BackColor = Color.White
        Me.txtBCR.Location = New Point(354, 62)
        Me.txtBCR.Size = New Size(280, 22)

        Me.txtBkup.ReadOnly = True
        Me.txtBkup.BackColor = Color.White
        Me.txtBkup.Location = New Point(638, 62)
        Me.txtBkup.Size = New Size(290, 22)

        Me.pnlUserInfo.Controls.AddRange(New Control() {
            Me.lblUsrTitle, Me.txtUsrCode, Me.txtSibu, Me.txtYago, Me.txtName, Me.cmdDispUserData,
            Me.lblHwInfo, Me.txtPc, Me.txtDisplay, Me.txtPrinter, Me.txtMiniPrinter, Me.txtBCR, Me.txtBkup
        })

        ' rtbNaiyou
        Me.rtbNaiyou.Dock = DockStyle.Fill
        Me.rtbNaiyou.ReadOnly = True
        Me.rtbNaiyou.BackColor = Color.White
        Me.rtbNaiyou.Font = New Font("ＭＳ ゴシック", 10.5!)

        Me.splitResults.Panel2.Controls.Add(Me.rtbNaiyou)
        Me.splitResults.Panel2.Controls.Add(Me.pnlMntHeader)
        Me.splitResults.Panel2.Controls.Add(Me.pnlUserInfo)

        Me.AcceptButton = Me.cmdFind
        Me.Controls.Add(Me.splitResults)
        Me.Controls.Add(Me.pnlTop)

        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.splitResults.Panel1.ResumeLayout(False)
        Me.splitResults.Panel2.ResumeLayout(False)
        DirectCast(Me.splitResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitResults.ResumeLayout(False)
        DirectCast(Me.dgvMnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMntHeader.ResumeLayout(False)
        Me.pnlMntHeader.PerformLayout()
        Me.pnlUserInfo.ResumeLayout(False)
        Me.pnlUserInfo.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
End Class
