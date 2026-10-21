Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMnt
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
    Friend WithEvents pnlFilter As Panel
    Friend WithEvents lblSortTitle As Label
    Friend WithEvents cmbSort As ComboBox
    Friend WithEvents chkDspKanryou As CheckBox
    Friend WithEvents lblRangeTitle As Label
    Friend WithEvents txtKijitsuSt As TextBox
    Friend WithEvents lblRangeWave As Label
    Friend WithEvents txtKijitsuEd As TextBox
    Friend WithEvents btnRangeAll As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnOpt As Button
    Friend WithEvents lblCount As Label

    Friend WithEvents tabBunrui As TabControl
    Friend WithEvents tabSyuuri As TabPage
    Friend WithEvents tabKaihatsu As TabPage
    Friend WithEvents tabEigyou As TabPage
    Friend WithEvents tabHoka As TabPage
    Friend WithEvents tabSubete As TabPage

    Friend WithEvents splitMain As SplitContainer
    Friend WithEvents dgvMnt As DataGridView

    Friend WithEvents pnlDetailTop As Panel
    Friend WithEvents LblID As Label
    Friend WithEvents LblSakusei As Label
    Friend WithEvents LblUCode As Label
    Friend WithEvents LblSibu As Label
    Friend WithEvents LblSjName As Label
    Friend WithEvents LblJsName As Label
    Friend WithEvents LblSagyou As Label
    Friend WithEvents LblBunrui As Label
    Friend WithEvents LblSyain As Label
    Friend WithEvents LblKijitsu As Label
    Friend WithEvents ChkKanryou As CheckBox
    Friend WithEvents CmdEdit As Button
    Friend WithEvents CmdDispUser As Button
    Friend WithEvents TxtNaiyou As TextBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlFilter = New Panel()
        Me.lblSortTitle = New Label()
        Me.cmbSort = New ComboBox()
        Me.chkDspKanryou = New CheckBox()
        Me.lblRangeTitle = New Label()
        Me.txtKijitsuSt = New TextBox()
        Me.lblRangeWave = New Label()
        Me.txtKijitsuEd = New TextBox()
        Me.btnRangeAll = New Button()
        Me.btnRefresh = New Button()
        Me.btnPrint = New Button()
        Me.btnOpt = New Button()
        Me.lblCount = New Label()

        Me.tabBunrui = New TabControl()
        Me.tabSyuuri = New TabPage("修理")
        Me.tabKaihatsu = New TabPage("開発")
        Me.tabEigyou = New TabPage("営業")
        Me.tabHoka = New TabPage("他")
        Me.tabSubete = New TabPage("すべて")

        Me.splitMain = New SplitContainer()
        Me.dgvMnt = New DataGridView()

        Me.pnlDetailTop = New Panel()
        Me.LblID = New Label()
        Me.LblSakusei = New Label()
        Me.LblUCode = New Label()
        Me.LblSibu = New Label()
        Me.LblSjName = New Label()
        Me.LblJsName = New Label()
        Me.LblSagyou = New Label()
        Me.LblBunrui = New Label()
        Me.LblSyain = New Label()
        Me.LblKijitsu = New Label()
        Me.ChkKanryou = New CheckBox()
        Me.CmdEdit = New Button()
        Me.CmdDispUser = New Button()
        Me.TxtNaiyou = New TextBox()

        Me.pnlFilter.SuspendLayout()
        Me.tabBunrui.SuspendLayout()
        DirectCast(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        DirectCast(Me.dgvMnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetailTop.SuspendLayout()
        Me.SuspendLayout()

        Me.AutoScaleDimensions = New SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(980, 680)
        Me.MinimumSize = New Size(820, 520)
        Me.Font = New Font("MS UI Gothic", 9.75!)
        Me.Name = "FrmMnt"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "全ユーザー メンテナンス記録一覧"

        ' pnlFilter
        Me.pnlFilter.Dock = DockStyle.Top
        Me.pnlFilter.Size = New Size(980, 38)
        Me.pnlFilter.BackColor = Color.FromArgb(240, 244, 250)

        Me.lblSortTitle.Text = "並替:"
        Me.lblSortTitle.Location = New Point(8, 10)
        Me.lblSortTitle.Size = New Size(38, 20)

        Me.cmbSort.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbSort.Items.AddRange(New Object() {"作業日順", "期日順"})
        Me.cmbSort.Location = New Point(48, 7)
        Me.cmbSort.Size = New Size(95, 23)

        Me.chkDspKanryou.Text = "完了分も表示する"
        Me.chkDspKanryou.Location = New Point(155, 8)
        Me.chkDspKanryou.Size = New Size(135, 22)

        Me.lblRangeTitle.Text = "期日期間:"
        Me.lblRangeTitle.Location = New Point(298, 10)
        Me.lblRangeTitle.Size = New Size(65, 20)

        Me.txtKijitsuSt.Location = New Point(365, 7)
        Me.txtKijitsuSt.Size = New Size(88, 23)
        Me.txtKijitsuSt.ImeMode = ImeMode.Disable

        Me.lblRangeWave.Text = "～"
        Me.lblRangeWave.Location = New Point(455, 10)
        Me.lblRangeWave.Size = New Size(20, 20)

        Me.txtKijitsuEd.Location = New Point(477, 7)
        Me.txtKijitsuEd.Size = New Size(88, 23)
        Me.txtKijitsuEd.ImeMode = ImeMode.Disable

        Me.btnRangeAll.Text = "全期間"
        Me.btnRangeAll.Location = New Point(570, 6)
        Me.btnRangeAll.Size = New Size(62, 26)

        Me.btnRefresh.Text = "再表示(&R)"
        Me.btnRefresh.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.btnRefresh.Location = New Point(636, 5)
        Me.btnRefresh.Size = New Size(86, 28)

        Me.btnPrint.Text = "印刷(&P)"
        Me.btnPrint.Location = New Point(726, 5)
        Me.btnPrint.Size = New Size(72, 28)

        Me.btnOpt.Text = "設定(&O)"
        Me.btnOpt.Location = New Point(802, 5)
        Me.btnOpt.Size = New Size(68, 28)

        Me.lblCount.Text = "0件"
        Me.lblCount.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.lblCount.Location = New Point(876, 9)
        Me.lblCount.Size = New Size(98, 22)

        Me.pnlFilter.Controls.AddRange(New Control() {
            Me.lblSortTitle, Me.cmbSort, Me.chkDspKanryou,
            Me.lblRangeTitle, Me.txtKijitsuSt, Me.lblRangeWave, Me.txtKijitsuEd,
            Me.btnRangeAll, Me.btnRefresh, Me.btnPrint, Me.btnOpt, Me.lblCount
        })

        ' tabBunrui
        Me.tabBunrui.Dock = DockStyle.Top
        Me.tabBunrui.Size = New Size(980, 28)
        Me.tabBunrui.Font = New Font("MS UI Gothic", 10.0!, FontStyle.Bold)
        Me.tabBunrui.Controls.AddRange(New Control() {
            Me.tabSyuuri, Me.tabKaihatsu, Me.tabEigyou, Me.tabHoka, Me.tabSubete
        })

        ' splitMain
        Me.splitMain.Dock = DockStyle.Fill
        Me.splitMain.Orientation = Orientation.Horizontal
        Me.splitMain.Size = New Size(980, 614)
        Me.splitMain.SplitterDistance = 360

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
        Me.splitMain.Panel1.Controls.Add(Me.dgvMnt)

        ' pnlDetailTop
        Me.pnlDetailTop.Dock = DockStyle.Top
        Me.pnlDetailTop.Size = New Size(980, 66)
        Me.pnlDetailTop.BackColor = Color.FromArgb(245, 245, 248)

        Me.LblID.BorderStyle = BorderStyle.Fixed3D
        Me.LblID.BackColor = Color.White
        Me.LblID.Location = New Point(8, 6)
        Me.LblID.Size = New Size(70, 23)
        Me.LblID.TextAlign = ContentAlignment.MiddleCenter

        Me.LblSakusei.BorderStyle = BorderStyle.Fixed3D
        Me.LblSakusei.BackColor = Color.White
        Me.LblSakusei.Location = New Point(82, 6)
        Me.LblSakusei.Size = New Size(145, 23)
        Me.LblSakusei.TextAlign = ContentAlignment.MiddleCenter

        Me.LblUCode.BorderStyle = BorderStyle.Fixed3D
        Me.LblUCode.BackColor = Color.FromArgb(255, 255, 220)
        Me.LblUCode.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.LblUCode.Location = New Point(232, 6)
        Me.LblUCode.Size = New Size(68, 23)
        Me.LblUCode.TextAlign = ContentAlignment.MiddleCenter

        Me.LblSibu.BorderStyle = BorderStyle.Fixed3D
        Me.LblSibu.BackColor = Color.FromArgb(255, 255, 220)
        Me.LblSibu.Location = New Point(304, 6)
        Me.LblSibu.Size = New Size(90, 23)
        Me.LblSibu.TextAlign = ContentAlignment.MiddleLeft

        Me.LblSjName.BorderStyle = BorderStyle.Fixed3D
        Me.LblSjName.BackColor = Color.FromArgb(255, 255, 220)
        Me.LblSjName.Font = New Font("MS UI Gothic", 10.0!, FontStyle.Bold)
        Me.LblSjName.Location = New Point(398, 6)
        Me.LblSjName.Size = New Size(250, 23)
        Me.LblSjName.TextAlign = ContentAlignment.MiddleLeft

        Me.LblJsName.BorderStyle = BorderStyle.Fixed3D
        Me.LblJsName.BackColor = Color.FromArgb(255, 255, 220)
        Me.LblJsName.Location = New Point(652, 6)
        Me.LblJsName.Size = New Size(165, 23)
        Me.LblJsName.TextAlign = ContentAlignment.MiddleLeft

        Me.CmdDispUser.Text = "メインに表示(&U)"
        Me.CmdDispUser.BackColor = Color.FromArgb(255, 240, 200)
        Me.CmdDispUser.Font = New Font("MS UI Gothic", 9.0!, FontStyle.Bold)
        Me.CmdDispUser.Location = New Point(825, 4)
        Me.CmdDispUser.Size = New Size(142, 27)
        Me.CmdDispUser.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.LblSagyou.BorderStyle = BorderStyle.Fixed3D
        Me.LblSagyou.BackColor = Color.White
        Me.LblSagyou.Location = New Point(8, 36)
        Me.LblSagyou.Size = New Size(155, 23)
        Me.LblSagyou.TextAlign = ContentAlignment.MiddleLeft

        Me.LblBunrui.BorderStyle = BorderStyle.Fixed3D
        Me.LblBunrui.BackColor = Color.White
        Me.LblBunrui.Location = New Point(168, 36)
        Me.LblBunrui.Size = New Size(130, 23)
        Me.LblBunrui.TextAlign = ContentAlignment.MiddleLeft

        Me.LblSyain.BorderStyle = BorderStyle.Fixed3D
        Me.LblSyain.BackColor = Color.White
        Me.LblSyain.Location = New Point(304, 36)
        Me.LblSyain.Size = New Size(120, 23)
        Me.LblSyain.TextAlign = ContentAlignment.MiddleLeft

        Me.LblKijitsu.BorderStyle = BorderStyle.Fixed3D
        Me.LblKijitsu.BackColor = Color.White
        Me.LblKijitsu.Location = New Point(430, 36)
        Me.LblKijitsu.Size = New Size(130, 23)
        Me.LblKijitsu.TextAlign = ContentAlignment.MiddleLeft

        Me.ChkKanryou.Text = "完了"
        Me.ChkKanryou.Enabled = False
        Me.ChkKanryou.Location = New Point(570, 37)
        Me.ChkKanryou.Size = New Size(65, 22)

        Me.CmdEdit.Text = "編集(&E)"
        Me.CmdEdit.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.CmdEdit.Location = New Point(825, 34)
        Me.CmdEdit.Size = New Size(142, 27)
        Me.CmdEdit.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        Me.pnlDetailTop.Controls.AddRange(New Control() {
            Me.LblID, Me.LblSakusei, Me.LblUCode, Me.LblSibu, Me.LblSjName, Me.LblJsName, Me.CmdDispUser,
            Me.LblSagyou, Me.LblBunrui, Me.LblSyain, Me.LblKijitsu, Me.ChkKanryou, Me.CmdEdit
        })

        Me.TxtNaiyou.Dock = DockStyle.Fill
        Me.TxtNaiyou.Multiline = True
        Me.TxtNaiyou.ReadOnly = True
        Me.TxtNaiyou.ScrollBars = ScrollBars.Vertical
        Me.TxtNaiyou.BackColor = Color.White
        Me.TxtNaiyou.Font = New Font("ＭＳ ゴシック", 10.5!)

        Me.splitMain.Panel2.Controls.Add(Me.TxtNaiyou)
        Me.splitMain.Panel2.Controls.Add(Me.pnlDetailTop)

        Me.Controls.Add(Me.splitMain)
        Me.Controls.Add(Me.tabBunrui)
        Me.Controls.Add(Me.pnlFilter)

        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        Me.tabBunrui.ResumeLayout(False)
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        Me.splitMain.Panel2.PerformLayout()
        DirectCast(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        DirectCast(Me.dgvMnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetailTop.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub
End Class
