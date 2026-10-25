<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
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

    ' MenuStrip
    Public WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Public WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuDbCopy As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSep1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuNetworkMode As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuLocalMode As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSep2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuView As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuDspNormal As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuDspSleep As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuDspDelete As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSearch As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFindName As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFindCode As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFindSibu As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFindTel As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFindPc As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuFindSn As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSep3 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuFindAll As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuMnt As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuMntList As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuMntFind As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSepMnt As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuMntAdd As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuMntEdit As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuMntMark As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOpt As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOptAll As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuOptBrowser As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPrt As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPrtList As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPrtEnv1 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuPrtEnv2 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSepPrt1 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuPrtMntUsr As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuSepPrt2 As System.Windows.Forms.ToolStripSeparator
    Public WithEvents mnuVupLabel As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuVupLabelExe As System.Windows.Forms.ToolStripMenuItem

    ' Top Toolbar Panel
    Public WithEvents pnlTopBar As System.Windows.Forms.Panel
    Public WithEvents btnFindName As System.Windows.Forms.Button
    Public WithEvents btnFindCode As System.Windows.Forms.Button
    Public WithEvents btnFindSibu As System.Windows.Forms.Button
    Public WithEvents btnFindTel As System.Windows.Forms.Button
    Public WithEvents btnFindPc As System.Windows.Forms.Button
    Public WithEvents btnFindSn As System.Windows.Forms.Button
    Public WithEvents btnShowAll As System.Windows.Forms.Button
    Public WithEvents btnMntFind As System.Windows.Forms.Button
    Public WithEvents btnMntList As System.Windows.Forms.Button
    Public WithEvents lblRrkTitle As System.Windows.Forms.Label
    Public WithEvents cmbRrk As System.Windows.Forms.ComboBox
    Public WithEvents lblModeBadge As System.Windows.Forms.Label

    ' StatusStrip
    Public WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Public WithEvents stlSearchCond As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents stlRecCount As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents stlDspMode As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents stlPcName As System.Windows.Forms.ToolStripStatusLabel

    ' SplitContainers
    Public WithEvents splitMain As System.Windows.Forms.SplitContainer
    Public WithEvents splitRight As System.Windows.Forms.SplitContainer

    ' Right Upper: User Grid
    Public WithEvents pnlUsrGridTop As System.Windows.Forms.Panel
    Public WithEvents lblUsrGridHeader As System.Windows.Forms.Label
    Public WithEvents dgvUsr As System.Windows.Forms.DataGridView

    ' Right Lower: Print List Grid
    Public WithEvents pnlPrtTop As System.Windows.Forms.Panel
    Public WithEvents lblPrtHeader As System.Windows.Forms.Label
    Public WithEvents btnPrtAdd As System.Windows.Forms.Button
    Public WithEvents btnPrtDel As System.Windows.Forms.Button
    Public WithEvents btnPrtAllDel As System.Windows.Forms.Button
    Public WithEvents btnPrtExec As System.Windows.Forms.Button
    Public WithEvents btnPrt1F As System.Windows.Forms.Button
    Public WithEvents btnPrt2F As System.Windows.Forms.Button
    Public WithEvents btnPrtOpt As System.Windows.Forms.Button
    Public WithEvents btnListExport As System.Windows.Forms.Button
    Public WithEvents dgvPrt As System.Windows.Forms.DataGridView

    ' Left: User Detail Header + Tabs
    Public WithEvents pnlRightHeader As System.Windows.Forms.Panel
    Public WithEvents lblCodeTitle As System.Windows.Forms.Label
    Public WithEvents txtCode As System.Windows.Forms.TextBox
    Public WithEvents lblVerTitle As System.Windows.Forms.Label
    Public WithEvents txtVer As System.Windows.Forms.TextBox
    Public WithEvents lblSibuTitle As System.Windows.Forms.Label
    Public WithEvents txtSibu As System.Windows.Forms.TextBox
    Public WithEvents lblPMemoBadge As System.Windows.Forms.Label

    Public WithEvents flpTags As System.Windows.Forms.FlowLayoutPanel

    Public WithEvents lblSjTitle As System.Windows.Forms.Label
    Public WithEvents txtSjNameF As System.Windows.Forms.TextBox
    Public WithEvents txtSjName As System.Windows.Forms.TextBox
    Public WithEvents lblJsTitle As System.Windows.Forms.Label
    Public WithEvents txtJsNameF As System.Windows.Forms.TextBox
    Public WithEvents txtJsName As System.Windows.Forms.TextBox
    Public WithEvents lblTelTitle As System.Windows.Forms.Label
    Public WithEvents txtTel As System.Windows.Forms.TextBox

    ' Extended status badges (Vertically stacked in middle column) & Copy button
    Public WithEvents lblImeBadge As System.Windows.Forms.Label
    Public WithEvents lblInputBadge As System.Windows.Forms.Label
    Public WithEvents lblNetBadge As System.Windows.Forms.Label
    Public WithEvents lblClickBadge As System.Windows.Forms.Label
    Public WithEvents btnCopyBracket As System.Windows.Forms.Button

    ' Detail TabControl
    Public WithEvents tabDetail As System.Windows.Forms.TabControl
    Public WithEvents tabSinryou As System.Windows.Forms.TabPage
    Public WithEvents tabKisyu As System.Windows.Forms.TabPage
    Public WithEvents tabJitaku As System.Windows.Forms.TabPage
    Public WithEvents tabMnt As System.Windows.Forms.TabPage
    Public WithEvents tabMemoMap As System.Windows.Forms.TabPage

    ' Tab 1: 住所・診療時間
    Public WithEvents lblAddTitle As System.Windows.Forms.Label
    Public WithEvents txtAdd As System.Windows.Forms.TextBox
    Public WithEvents btnGoogleMap As System.Windows.Forms.Button
    Public WithEvents btnGmapLink1 As System.Windows.Forms.Button
    Public WithEvents btnGmapLink2 As System.Windows.Forms.Button
    Public WithEvents btnGmapLink3 As System.Windows.Forms.Button
    Public WithEvents lblSinryouTitle As System.Windows.Forms.Label
    Public WithEvents txtSinryou As System.Windows.Forms.TextBox
    Public WithEvents lblBikouTitle As System.Windows.Forms.Label
    Public WithEvents txtMemo As System.Windows.Forms.TextBox
    Public WithEvents lblShareMemoTitle As System.Windows.Forms.Label
    Public WithEvents btnEditMemoTab1 As System.Windows.Forms.Button
    Public WithEvents txtMemo2 As System.Windows.Forms.TextBox
    Public WithEvents lblRecentMntTitle As System.Windows.Forms.Label
    Public WithEvents lstMntLog As System.Windows.Forms.ListBox

    ' Tab 2: 使用機種
    Public WithEvents lblPcTitle As System.Windows.Forms.Label
    Public WithEvents txtPc0 As System.Windows.Forms.TextBox
    Public WithEvents txtPc1 As System.Windows.Forms.TextBox
    Public WithEvents lblPrtTitle As System.Windows.Forms.Label
    Public WithEvents txtPrt0 As System.Windows.Forms.TextBox
    Public WithEvents txtPrt1 As System.Windows.Forms.TextBox
    Public WithEvents lblMnTitle As System.Windows.Forms.Label
    Public WithEvents txtMn0 As System.Windows.Forms.TextBox
    Public WithEvents txtMn1 As System.Windows.Forms.TextBox
    Public WithEvents lblBcrTitle As System.Windows.Forms.Label
    Public WithEvents txtBcr0 As System.Windows.Forms.TextBox
    Public WithEvents txtBcr1 As System.Windows.Forms.TextBox
    Public WithEvents lblHddTitle As System.Windows.Forms.Label
    Public WithEvents txtHdd0 As System.Windows.Forms.TextBox
    Public WithEvents txtHdd1 As System.Windows.Forms.TextBox
    Public WithEvents lblMiniPrtTitle As System.Windows.Forms.Label
    Public WithEvents txtMiniPrt0 As System.Windows.Forms.TextBox
    Public WithEvents txtMiniPrt1 As System.Windows.Forms.TextBox
    Public WithEvents lblNohinTitle As System.Windows.Forms.Label
    Public WithEvents txtNohin As System.Windows.Forms.TextBox
    Public WithEvents lblTantoTitle As System.Windows.Forms.Label
    Public WithEvents txtTanto As System.Windows.Forms.TextBox
    Public WithEvents lblLicenseTitle As System.Windows.Forms.Label
    Public WithEvents txtLicense As System.Windows.Forms.TextBox
    Public WithEvents lblLeaseTitle As System.Windows.Forms.Label
    Public WithEvents txtSiharai As System.Windows.Forms.TextBox
    Public WithEvents txtLeaseCo As System.Windows.Forms.TextBox
    Public WithEvents txtLeaseStDate As System.Windows.Forms.TextBox
    Public WithEvents txtLease1 As System.Windows.Forms.TextBox
    Public WithEvents txtLease2 As System.Windows.Forms.TextBox
    Public WithEvents btnCopyKisyu As System.Windows.Forms.Button

    ' Tab 3: 自宅・送付先
    Public WithEvents lblMhTelTitle As System.Windows.Forms.Label
    Public WithEvents txtMhTel As System.Windows.Forms.TextBox
    Public WithEvents lblMbTelTitle As System.Windows.Forms.Label
    Public WithEvents txtMbTel As System.Windows.Forms.TextBox
    Public WithEvents lblFaxTitle As System.Windows.Forms.Label
    Public WithEvents txtFax As System.Windows.Forms.TextBox
    Public WithEvents lblMhAddTitle As System.Windows.Forms.Label
    Public WithEvents txtMhAdd As System.Windows.Forms.TextBox
    Public WithEvents lblTelExTitle As System.Windows.Forms.Label
    Public WithEvents btnTelExEdit As System.Windows.Forms.Button
    Public WithEvents txtTelEx0 As System.Windows.Forms.TextBox
    Public WithEvents txtTelEx1 As System.Windows.Forms.TextBox
    Public WithEvents txtTelEx2 As System.Windows.Forms.TextBox
    Public WithEvents txtTelEx3 As System.Windows.Forms.TextBox
    Public WithEvents txtTelEx4 As System.Windows.Forms.TextBox
    Public WithEvents lblVupAddTitle As System.Windows.Forms.Label
    Public WithEvents txtVupAdd As System.Windows.Forms.TextBox
    Public WithEvents lblPcAddTitle As System.Windows.Forms.Label
    Public WithEvents txtPcAdd As System.Windows.Forms.TextBox

    ' Tab 4: メンテナンス
    Public WithEvents pnlMntTop As System.Windows.Forms.Panel
    Public WithEvents rdoMntSortSagyou As System.Windows.Forms.RadioButton
    Public WithEvents rdoMntSortKijitsu As System.Windows.Forms.RadioButton
    Public WithEvents chkMntKanryou As System.Windows.Forms.CheckBox
    Public WithEvents chkMntAutoScroll As System.Windows.Forms.CheckBox
    Public WithEvents lblMntCount As System.Windows.Forms.Label
    Public WithEvents btnMntAdd As System.Windows.Forms.Button
    Public WithEvents btnMntEdit As System.Windows.Forms.Button
    Public WithEvents btnMntMark As System.Windows.Forms.Button
    Public WithEvents btnMntFindTab As System.Windows.Forms.Button
    Public WithEvents btnMntListTab As System.Windows.Forms.Button
    Public WithEvents btnMntPrt As System.Windows.Forms.Button
    Public WithEvents btnMntOpt As System.Windows.Forms.Button
    Public WithEvents splitMnt As System.Windows.Forms.SplitContainer
    Public WithEvents dgvMntUsr As System.Windows.Forms.DataGridView
    Public WithEvents txtMntSelectedContent As System.Windows.Forms.TextBox

    ' Tab 5: メモ・地図
    Public WithEvents splitMemoMap As System.Windows.Forms.SplitContainer
    Public WithEvents lblTabMemoTitle As System.Windows.Forms.Label
    Public WithEvents btnEditMemo As System.Windows.Forms.Button
    Public WithEvents txtPmemo As System.Windows.Forms.TextBox
    Public WithEvents lblPcPMemoTitle As System.Windows.Forms.Label
    Public WithEvents btnEditPMemo As System.Windows.Forms.Button
    Public WithEvents txtPcPMemo As System.Windows.Forms.TextBox
    Public WithEvents pnlMapToolbar As System.Windows.Forms.Panel
    Public WithEvents lblMapStatus As System.Windows.Forms.Label
    Public WithEvents btnDispMap As System.Windows.Forms.Button
    Public WithEvents picMap As System.Windows.Forms.PictureBox

    ' Timer for viewing history (rrk.txt)
    Public WithEvents tmrRrk As System.Windows.Forms.Timer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDbCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuNetworkMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLocalMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSep2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuView = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDspNormal = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDspSleep = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDspDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFindName = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFindCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFindSibu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFindTel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFindPc = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFindSn = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSep3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFindAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMnt = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMntList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMntFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSepMnt = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuMntAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMntEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMntMark = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrt = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrtList = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrtEnv1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrtEnv2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSepPrt1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuPrtMntUsr = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSepPrt2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuVupLabel = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuVupLabelExe = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOpt = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptBrowser = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlTopBar = New System.Windows.Forms.Panel()
        Me.btnFindName = New System.Windows.Forms.Button()
        Me.btnFindCode = New System.Windows.Forms.Button()
        Me.btnFindSibu = New System.Windows.Forms.Button()
        Me.btnFindTel = New System.Windows.Forms.Button()
        Me.btnFindPc = New System.Windows.Forms.Button()
        Me.btnFindSn = New System.Windows.Forms.Button()
        Me.btnShowAll = New System.Windows.Forms.Button()
        Me.btnMntFind = New System.Windows.Forms.Button()
        Me.btnMntList = New System.Windows.Forms.Button()
        Me.lblRrkTitle = New System.Windows.Forms.Label()
        Me.cmbRrk = New System.Windows.Forms.ComboBox()
        Me.lblModeBadge = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.stlSearchCond = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stlRecCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stlDspMode = New System.Windows.Forms.ToolStripStatusLabel()
        Me.stlPcName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.tabDetail = New System.Windows.Forms.TabControl()
        Me.tabSinryou = New System.Windows.Forms.TabPage()
        Me.lblAddTitle = New System.Windows.Forms.Label()
        Me.txtAdd = New System.Windows.Forms.TextBox()
        Me.btnGoogleMap = New System.Windows.Forms.Button()
        Me.btnGmapLink1 = New System.Windows.Forms.Button()
        Me.btnGmapLink2 = New System.Windows.Forms.Button()
        Me.btnGmapLink3 = New System.Windows.Forms.Button()
        Me.lblSinryouTitle = New System.Windows.Forms.Label()
        Me.txtSinryou = New System.Windows.Forms.TextBox()
        Me.lblBikouTitle = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.lblShareMemoTitle = New System.Windows.Forms.Label()
        Me.btnEditMemoTab1 = New System.Windows.Forms.Button()
        Me.txtMemo2 = New System.Windows.Forms.TextBox()
        Me.lblRecentMntTitle = New System.Windows.Forms.Label()
        Me.lstMntLog = New System.Windows.Forms.ListBox()
        Me.tabKisyu = New System.Windows.Forms.TabPage()
        Me.btnCopyKisyu = New System.Windows.Forms.Button()
        Me.lblPcTitle = New System.Windows.Forms.Label()
        Me.txtPc0 = New System.Windows.Forms.TextBox()
        Me.txtPc1 = New System.Windows.Forms.TextBox()
        Me.lblPrtTitle = New System.Windows.Forms.Label()
        Me.txtPrt0 = New System.Windows.Forms.TextBox()
        Me.txtPrt1 = New System.Windows.Forms.TextBox()
        Me.lblMnTitle = New System.Windows.Forms.Label()
        Me.txtMn0 = New System.Windows.Forms.TextBox()
        Me.txtMn1 = New System.Windows.Forms.TextBox()
        Me.lblBcrTitle = New System.Windows.Forms.Label()
        Me.txtBcr0 = New System.Windows.Forms.TextBox()
        Me.txtBcr1 = New System.Windows.Forms.TextBox()
        Me.lblHddTitle = New System.Windows.Forms.Label()
        Me.txtHdd0 = New System.Windows.Forms.TextBox()
        Me.txtHdd1 = New System.Windows.Forms.TextBox()
        Me.lblMiniPrtTitle = New System.Windows.Forms.Label()
        Me.txtMiniPrt0 = New System.Windows.Forms.TextBox()
        Me.txtMiniPrt1 = New System.Windows.Forms.TextBox()
        Me.lblNohinTitle = New System.Windows.Forms.Label()
        Me.txtNohin = New System.Windows.Forms.TextBox()
        Me.lblTantoTitle = New System.Windows.Forms.Label()
        Me.txtTanto = New System.Windows.Forms.TextBox()
        Me.lblLicenseTitle = New System.Windows.Forms.Label()
        Me.txtLicense = New System.Windows.Forms.TextBox()
        Me.lblLeaseTitle = New System.Windows.Forms.Label()
        Me.txtSiharai = New System.Windows.Forms.TextBox()
        Me.txtLeaseCo = New System.Windows.Forms.TextBox()
        Me.txtLeaseStDate = New System.Windows.Forms.TextBox()
        Me.txtLease1 = New System.Windows.Forms.TextBox()
        Me.txtLease2 = New System.Windows.Forms.TextBox()
        Me.tabJitaku = New System.Windows.Forms.TabPage()
        Me.lblMhTelTitle = New System.Windows.Forms.Label()
        Me.txtMhTel = New System.Windows.Forms.TextBox()
        Me.lblMbTelTitle = New System.Windows.Forms.Label()
        Me.txtMbTel = New System.Windows.Forms.TextBox()
        Me.lblFaxTitle = New System.Windows.Forms.Label()
        Me.txtFax = New System.Windows.Forms.TextBox()
        Me.lblTelExTitle = New System.Windows.Forms.Label()
        Me.btnTelExEdit = New System.Windows.Forms.Button()
        Me.txtTelEx0 = New System.Windows.Forms.TextBox()
        Me.txtTelEx1 = New System.Windows.Forms.TextBox()
        Me.txtTelEx2 = New System.Windows.Forms.TextBox()
        Me.txtTelEx3 = New System.Windows.Forms.TextBox()
        Me.txtTelEx4 = New System.Windows.Forms.TextBox()
        Me.lblMhAddTitle = New System.Windows.Forms.Label()
        Me.txtMhAdd = New System.Windows.Forms.TextBox()
        Me.lblVupAddTitle = New System.Windows.Forms.Label()
        Me.txtVupAdd = New System.Windows.Forms.TextBox()
        Me.lblPcAddTitle = New System.Windows.Forms.Label()
        Me.txtPcAdd = New System.Windows.Forms.TextBox()
        Me.tabMnt = New System.Windows.Forms.TabPage()
        Me.splitMnt = New System.Windows.Forms.SplitContainer()
        Me.dgvMntUsr = New System.Windows.Forms.DataGridView()
        Me.txtMntSelectedContent = New System.Windows.Forms.TextBox()
        Me.pnlMntTop = New System.Windows.Forms.Panel()
        Me.rdoMntSortSagyou = New System.Windows.Forms.RadioButton()
        Me.rdoMntSortKijitsu = New System.Windows.Forms.RadioButton()
        Me.chkMntKanryou = New System.Windows.Forms.CheckBox()
        Me.chkMntAutoScroll = New System.Windows.Forms.CheckBox()
        Me.lblMntCount = New System.Windows.Forms.Label()
        Me.btnMntAdd = New System.Windows.Forms.Button()
        Me.btnMntEdit = New System.Windows.Forms.Button()
        Me.btnMntMark = New System.Windows.Forms.Button()
        Me.btnMntFindTab = New System.Windows.Forms.Button()
        Me.btnMntListTab = New System.Windows.Forms.Button()
        Me.btnMntPrt = New System.Windows.Forms.Button()
        Me.btnMntOpt = New System.Windows.Forms.Button()
        Me.tabMemoMap = New System.Windows.Forms.TabPage()
        Me.splitMemoMap = New System.Windows.Forms.SplitContainer()
        Me.lblTabMemoTitle = New System.Windows.Forms.Label()
        Me.btnEditMemo = New System.Windows.Forms.Button()
        Me.txtPmemo = New System.Windows.Forms.TextBox()
        Me.lblPcPMemoTitle = New System.Windows.Forms.Label()
        Me.btnEditPMemo = New System.Windows.Forms.Button()
        Me.txtPcPMemo = New System.Windows.Forms.TextBox()
        Me.picMap = New System.Windows.Forms.PictureBox()
        Me.pnlMapToolbar = New System.Windows.Forms.Panel()
        Me.btnDispMap = New System.Windows.Forms.Button()
        Me.lblMapStatus = New System.Windows.Forms.Label()
        Me.pnlRightHeader = New System.Windows.Forms.Panel()
        Me.lblCodeTitle = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.lblVerTitle = New System.Windows.Forms.Label()
        Me.txtVer = New System.Windows.Forms.TextBox()
        Me.lblSibuTitle = New System.Windows.Forms.Label()
        Me.txtSibu = New System.Windows.Forms.TextBox()
        Me.btnCopyBracket = New System.Windows.Forms.Button()
        Me.lblSjTitle = New System.Windows.Forms.Label()
        Me.txtSjNameF = New System.Windows.Forms.TextBox()
        Me.txtSjName = New System.Windows.Forms.TextBox()
        Me.lblJsTitle = New System.Windows.Forms.Label()
        Me.txtJsNameF = New System.Windows.Forms.TextBox()
        Me.txtJsName = New System.Windows.Forms.TextBox()
        Me.lblTelTitle = New System.Windows.Forms.Label()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.lblImeBadge = New System.Windows.Forms.Label()
        Me.lblInputBadge = New System.Windows.Forms.Label()
        Me.lblNetBadge = New System.Windows.Forms.Label()
        Me.lblClickBadge = New System.Windows.Forms.Label()
        Me.lblPMemoBadge = New System.Windows.Forms.Label()
        Me.flpTags = New System.Windows.Forms.FlowLayoutPanel()
        Me.splitRight = New System.Windows.Forms.SplitContainer()
        Me.dgvUsr = New System.Windows.Forms.DataGridView()
        Me.pnlUsrGridTop = New System.Windows.Forms.Panel()
        Me.lblUsrGridHeader = New System.Windows.Forms.Label()
        Me.dgvPrt = New System.Windows.Forms.DataGridView()
        Me.pnlPrtTop = New System.Windows.Forms.Panel()
        Me.lblPrtHeader = New System.Windows.Forms.Label()
        Me.btnPrtAdd = New System.Windows.Forms.Button()
        Me.btnPrtDel = New System.Windows.Forms.Button()
        Me.btnPrtAllDel = New System.Windows.Forms.Button()
        Me.btnPrtExec = New System.Windows.Forms.Button()
        Me.btnPrt1F = New System.Windows.Forms.Button()
        Me.btnPrt2F = New System.Windows.Forms.Button()
        Me.btnPrtOpt = New System.Windows.Forms.Button()
        Me.btnListExport = New System.Windows.Forms.Button()
        Me.tmrRrk = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.pnlTopBar.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.tabDetail.SuspendLayout()
        Me.tabSinryou.SuspendLayout()
        Me.tabKisyu.SuspendLayout()
        Me.tabJitaku.SuspendLayout()
        Me.tabMnt.SuspendLayout()
        CType(Me.splitMnt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMnt.Panel1.SuspendLayout()
        Me.splitMnt.Panel2.SuspendLayout()
        Me.splitMnt.SuspendLayout()
        CType(Me.dgvMntUsr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMntTop.SuspendLayout()
        Me.tabMemoMap.SuspendLayout()
        CType(Me.splitMemoMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMemoMap.Panel1.SuspendLayout()
        Me.splitMemoMap.Panel2.SuspendLayout()
        Me.splitMemoMap.SuspendLayout()
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMapToolbar.SuspendLayout()
        Me.pnlRightHeader.SuspendLayout()
        CType(Me.splitRight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitRight.Panel1.SuspendLayout()
        Me.splitRight.Panel2.SuspendLayout()
        Me.splitRight.SuspendLayout()
        CType(Me.dgvUsr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlUsrGridTop.SuspendLayout()
        CType(Me.dgvPrt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPrtTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuView, Me.mnuSearch, Me.mnuMnt, Me.mnuPrt, Me.mnuOpt})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1220, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDbCopy, Me.mnuSep1, Me.mnuNetworkMode, Me.mnuLocalMode, Me.mnuSep2, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(67, 20)
        Me.mnuFile.Text = "ファイル(&F)"
        '
        'mnuDbCopy
        '
        Me.mnuDbCopy.Name = "mnuDbCopy"
        Me.mnuDbCopy.Size = New System.Drawing.Size(201, 22)
        Me.mnuDbCopy.Text = "最新のデータに更新(&U)"
        '
        'mnuSep1
        '
        Me.mnuSep1.Name = "mnuSep1"
        Me.mnuSep1.Size = New System.Drawing.Size(198, 6)
        '
        'mnuNetworkMode
        '
        Me.mnuNetworkMode.Name = "mnuNetworkMode"
        Me.mnuNetworkMode.Size = New System.Drawing.Size(201, 22)
        Me.mnuNetworkMode.Text = "ネットワークモード(&N)"
        '
        'mnuLocalMode
        '
        Me.mnuLocalMode.Name = "mnuLocalMode"
        Me.mnuLocalMode.Size = New System.Drawing.Size(201, 22)
        Me.mnuLocalMode.Text = "ローカルモード(&L)"
        '
        'mnuSep2
        '
        Me.mnuSep2.Name = "mnuSep2"
        Me.mnuSep2.Size = New System.Drawing.Size(198, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(201, 22)
        Me.mnuExit.Text = "ユーザー検索を終了する(&X)"
        '
        'mnuView
        '
        Me.mnuView.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuDspNormal, Me.mnuDspSleep, Me.mnuDspDelete})
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(58, 20)
        Me.mnuView.Text = "表示(&V)"
        '
        'mnuDspNormal
        '
        Me.mnuDspNormal.Checked = True
        Me.mnuDspNormal.CheckOnClick = True
        Me.mnuDspNormal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuDspNormal.Name = "mnuDspNormal"
        Me.mnuDspNormal.Size = New System.Drawing.Size(162, 22)
        Me.mnuDspNormal.Text = "通常データ(&N)"
        '
        'mnuDspSleep
        '
        Me.mnuDspSleep.Checked = True
        Me.mnuDspSleep.CheckOnClick = True
        Me.mnuDspSleep.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuDspSleep.Name = "mnuDspSleep"
        Me.mnuDspSleep.Size = New System.Drawing.Size(162, 22)
        Me.mnuDspSleep.Text = "一時休止データ(&S)"
        '
        'mnuDspDelete
        '
        Me.mnuDspDelete.CheckOnClick = True
        Me.mnuDspDelete.Name = "mnuDspDelete"
        Me.mnuDspDelete.Size = New System.Drawing.Size(162, 22)
        Me.mnuDspDelete.Text = "削除データ(&D)"
        '
        'mnuSearch
        '
        Me.mnuSearch.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFindName, Me.mnuFindCode, Me.mnuFindSibu, Me.mnuFindTel, Me.mnuFindPc, Me.mnuFindSn, Me.mnuSep3, Me.mnuFindAll})
        Me.mnuSearch.Name = "mnuSearch"
        Me.mnuSearch.Size = New System.Drawing.Size(57, 20)
        Me.mnuSearch.Text = "検索(&S)"
        '
        'mnuFindName
        '
        Me.mnuFindName.Name = "mnuFindName"
        Me.mnuFindName.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.mnuFindName.Size = New System.Drawing.Size(214, 22)
        Me.mnuFindName.Text = "名前で検索(&N)"
        '
        'mnuFindCode
        '
        Me.mnuFindCode.Name = "mnuFindCode"
        Me.mnuFindCode.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mnuFindCode.Size = New System.Drawing.Size(214, 22)
        Me.mnuFindCode.Text = "コードで検索(&C)"
        '
        'mnuFindSibu
        '
        Me.mnuFindSibu.Name = "mnuFindSibu"
        Me.mnuFindSibu.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnuFindSibu.Size = New System.Drawing.Size(214, 22)
        Me.mnuFindSibu.Text = "支部名で検索(&B)"
        '
        'mnuFindTel
        '
        Me.mnuFindTel.Name = "mnuFindTel"
        Me.mnuFindTel.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.mnuFindTel.Size = New System.Drawing.Size(214, 22)
        Me.mnuFindTel.Text = "電話番号で検索(&T)"
        '
        'mnuFindPc
        '
        Me.mnuFindPc.Name = "mnuFindPc"
        Me.mnuFindPc.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.mnuFindPc.Size = New System.Drawing.Size(214, 22)
        Me.mnuFindPc.Text = "製品名で検索(&P)"
        '
        'mnuFindSn
        '
        Me.mnuFindSn.Name = "mnuFindSn"
        Me.mnuFindSn.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.mnuFindSn.Size = New System.Drawing.Size(214, 22)
        Me.mnuFindSn.Text = "シリアルナンバーで検索(&S)"
        '
        'mnuSep3
        '
        Me.mnuSep3.Name = "mnuSep3"
        Me.mnuSep3.Size = New System.Drawing.Size(211, 6)
        '
        'mnuFindAll
        '
        Me.mnuFindAll.Name = "mnuFindAll"
        Me.mnuFindAll.Size = New System.Drawing.Size(214, 22)
        Me.mnuFindAll.Text = "すべて表示(&A)"
        '
        'mnuMnt
        '
        Me.mnuMnt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMntList, Me.mnuMntFind, Me.mnuSepMnt, Me.mnuMntAdd, Me.mnuMntEdit, Me.mnuMntMark})
        Me.mnuMnt.Name = "mnuMnt"
        Me.mnuMnt.Size = New System.Drawing.Size(91, 20)
        Me.mnuMnt.Text = "メンテナンス(&M)"
        '
        'mnuMntList
        '
        Me.mnuMntList.Name = "mnuMntList"
        Me.mnuMntList.Size = New System.Drawing.Size(216, 22)
        Me.mnuMntList.Text = "全メンテナンス記録一覧(&L)"
        '
        'mnuMntFind
        '
        Me.mnuMntFind.Name = "mnuMntFind"
        Me.mnuMntFind.Size = New System.Drawing.Size(216, 22)
        Me.mnuMntFind.Text = "メンテナンス記録 全文検索(&F)"
        '
        'mnuSepMnt
        '
        Me.mnuSepMnt.Name = "mnuSepMnt"
        Me.mnuSepMnt.Size = New System.Drawing.Size(213, 6)
        '
        'mnuMntAdd
        '
        Me.mnuMntAdd.Name = "mnuMntAdd"
        Me.mnuMntAdd.Size = New System.Drawing.Size(216, 22)
        Me.mnuMntAdd.Text = "メンテナンス記録の追加(&A)"
        '
        'mnuMntEdit
        '
        Me.mnuMntEdit.Name = "mnuMntEdit"
        Me.mnuMntEdit.Size = New System.Drawing.Size(216, 22)
        Me.mnuMntEdit.Text = "メンテナンス記録の編集(&E)"
        '
        'mnuMntMark
        '
        Me.mnuMntMark.Name = "mnuMntMark"
        Me.mnuMntMark.Size = New System.Drawing.Size(216, 22)
        Me.mnuMntMark.Text = "キーワード強調検索(&K)"
        '
        'mnuPrt
        '
        Me.mnuPrt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrtList, Me.mnuPrtEnv1, Me.mnuPrtEnv2, Me.mnuSepPrt1, Me.mnuPrtMntUsr, Me.mnuSepPrt2, Me.mnuVupLabel, Me.mnuVupLabelExe})
        Me.mnuPrt.Name = "mnuPrt"
        Me.mnuPrt.Size = New System.Drawing.Size(58, 20)
        Me.mnuPrt.Text = "印刷(&P)"
        '
        'mnuPrtList
        '
        Me.mnuPrtList.Name = "mnuPrtList"
        Me.mnuPrtList.Size = New System.Drawing.Size(283, 22)
        Me.mnuPrtList.Text = "印刷リストの印刷(&P)"
        '
        'mnuPrtEnv1
        '
        Me.mnuPrtEnv1.Name = "mnuPrtEnv1"
        Me.mnuPrtEnv1.Size = New System.Drawing.Size(283, 22)
        Me.mnuPrtEnv1.Text = "封筒宛名印刷 1F [横](&1)"
        '
        'mnuPrtEnv2
        '
        Me.mnuPrtEnv2.Name = "mnuPrtEnv2"
        Me.mnuPrtEnv2.Size = New System.Drawing.Size(283, 22)
        Me.mnuPrtEnv2.Text = "封筒宛名印刷 2F [縦](&2)"
        '
        'mnuSepPrt1
        '
        Me.mnuSepPrt1.Name = "mnuSepPrt1"
        Me.mnuSepPrt1.Size = New System.Drawing.Size(303, 6)
        '
        'mnuPrtMntUsr
        '
        Me.mnuPrtMntUsr.Name = "mnuPrtMntUsr"
        Me.mnuPrtMntUsr.Size = New System.Drawing.Size(283, 22)
        Me.mnuPrtMntUsr.Text = "表示中ユーザーのカルテ・メンテ記録印刷(&M)"
        '
        'mnuSepPrt2
        '
        Me.mnuSepPrt2.Name = "mnuSepPrt2"
        Me.mnuSepPrt2.Size = New System.Drawing.Size(303, 6)
        '
        'mnuVupLabel
        '
        Me.mnuVupLabel.Name = "mnuVupLabel"
        Me.mnuVupLabel.Size = New System.Drawing.Size(283, 22)
        Me.mnuVupLabel.Text = "バージョンアップ用ラベル印刷(&V)"
        '
        'mnuVupLabelExe
        '
        Me.mnuVupLabelExe.Name = "mnuVupLabelExe"
        Me.mnuVupLabelExe.Size = New System.Drawing.Size(283, 22)
        Me.mnuVupLabelExe.Text = "ラベル印刷 [VupLabel.exe] (&L)"
        '
        'mnuOpt
        '
        Me.mnuOpt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptAll, Me.mnuOptBrowser})
        Me.mnuOpt.Name = "mnuOpt"
        Me.mnuOpt.Size = New System.Drawing.Size(60, 20)
        Me.mnuOpt.Text = "設定(&O)"
        '
        'mnuOptAll
        '
        Me.mnuOptAll.Name = "mnuOptAll"
        Me.mnuOptAll.Size = New System.Drawing.Size(180, 22)
        Me.mnuOptAll.Text = "環境設定(&O)..."
        '
        'mnuOptBrowser
        '
        Me.mnuOptBrowser.Name = "mnuOptBrowser"
        Me.mnuOptBrowser.Size = New System.Drawing.Size(180, 22)
        Me.mnuOptBrowser.Text = "ブラウザ設定(&B)..."
        '
        'pnlTopBar
        '
        Me.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlTopBar.Controls.Add(Me.btnFindName)
        Me.pnlTopBar.Controls.Add(Me.btnFindCode)
        Me.pnlTopBar.Controls.Add(Me.btnFindSibu)
        Me.pnlTopBar.Controls.Add(Me.btnFindTel)
        Me.pnlTopBar.Controls.Add(Me.btnFindPc)
        Me.pnlTopBar.Controls.Add(Me.btnFindSn)
        Me.pnlTopBar.Controls.Add(Me.btnShowAll)
        Me.pnlTopBar.Controls.Add(Me.btnMntFind)
        Me.pnlTopBar.Controls.Add(Me.btnMntList)
        Me.pnlTopBar.Controls.Add(Me.lblRrkTitle)
        Me.pnlTopBar.Controls.Add(Me.cmbRrk)
        Me.pnlTopBar.Controls.Add(Me.lblModeBadge)
        Me.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopBar.Location = New System.Drawing.Point(0, 24)
        Me.pnlTopBar.Name = "pnlTopBar"
        Me.pnlTopBar.Size = New System.Drawing.Size(1220, 40)
        Me.pnlTopBar.TabIndex = 1
        '
        'btnFindName
        '
        Me.btnFindName.Location = New System.Drawing.Point(8, 6)
        Me.btnFindName.Name = "btnFindName"
        Me.btnFindName.Size = New System.Drawing.Size(72, 28)
        Me.btnFindName.TabIndex = 0
        Me.btnFindName.Text = "名前(F1)"
        Me.btnFindName.UseVisualStyleBackColor = True
        '
        'btnFindCode
        '
        Me.btnFindCode.Location = New System.Drawing.Point(82, 6)
        Me.btnFindCode.Name = "btnFindCode"
        Me.btnFindCode.Size = New System.Drawing.Size(72, 28)
        Me.btnFindCode.TabIndex = 1
        Me.btnFindCode.Text = "コード(F2)"
        Me.btnFindCode.UseVisualStyleBackColor = True
        '
        'btnFindSibu
        '
        Me.btnFindSibu.Location = New System.Drawing.Point(156, 6)
        Me.btnFindSibu.Name = "btnFindSibu"
        Me.btnFindSibu.Size = New System.Drawing.Size(72, 28)
        Me.btnFindSibu.TabIndex = 2
        Me.btnFindSibu.Text = "支部(F3)"
        Me.btnFindSibu.UseVisualStyleBackColor = True
        '
        'btnFindTel
        '
        Me.btnFindTel.Location = New System.Drawing.Point(230, 6)
        Me.btnFindTel.Name = "btnFindTel"
        Me.btnFindTel.Size = New System.Drawing.Size(72, 28)
        Me.btnFindTel.TabIndex = 3
        Me.btnFindTel.Text = "電話(F4)"
        Me.btnFindTel.UseVisualStyleBackColor = True
        '
        'btnFindPc
        '
        Me.btnFindPc.Location = New System.Drawing.Point(304, 6)
        Me.btnFindPc.Name = "btnFindPc"
        Me.btnFindPc.Size = New System.Drawing.Size(72, 28)
        Me.btnFindPc.TabIndex = 4
        Me.btnFindPc.Text = "型名(F5)"
        Me.btnFindPc.UseVisualStyleBackColor = True
        '
        'btnFindSn
        '
        Me.btnFindSn.Location = New System.Drawing.Point(378, 6)
        Me.btnFindSn.Name = "btnFindSn"
        Me.btnFindSn.Size = New System.Drawing.Size(72, 28)
        Me.btnFindSn.TabIndex = 5
        Me.btnFindSn.Text = "S/N(F6)"
        Me.btnFindSn.UseVisualStyleBackColor = True
        '
        'btnShowAll
        '
        Me.btnShowAll.Location = New System.Drawing.Point(452, 6)
        Me.btnShowAll.Name = "btnShowAll"
        Me.btnShowAll.Size = New System.Drawing.Size(72, 28)
        Me.btnShowAll.TabIndex = 6
        Me.btnShowAll.Text = "全件表示"
        Me.btnShowAll.UseVisualStyleBackColor = True
        '
        'btnMntFind
        '
        Me.btnMntFind.Location = New System.Drawing.Point(530, 6)
        Me.btnMntFind.Name = "btnMntFind"
        Me.btnMntFind.Size = New System.Drawing.Size(82, 28)
        Me.btnMntFind.TabIndex = 7
        Me.btnMntFind.Text = "メンテ検索"
        Me.btnMntFind.UseVisualStyleBackColor = True
        '
        'btnMntList
        '
        Me.btnMntList.Location = New System.Drawing.Point(614, 6)
        Me.btnMntList.Name = "btnMntList"
        Me.btnMntList.Size = New System.Drawing.Size(74, 28)
        Me.btnMntList.TabIndex = 8
        Me.btnMntList.Text = "全メンテ"
        Me.btnMntList.UseVisualStyleBackColor = True
        '
        'lblRrkTitle
        '
        Me.lblRrkTitle.AutoSize = True
        Me.lblRrkTitle.Location = New System.Drawing.Point(694, 13)
        Me.lblRrkTitle.Name = "lblRrkTitle"
        Me.lblRrkTitle.Size = New System.Drawing.Size(36, 13)
        Me.lblRrkTitle.TabIndex = 9
        Me.lblRrkTitle.Text = "履歴:"
        '
        'cmbRrk
        '
        Me.cmbRrk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRrk.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRrk.Location = New System.Drawing.Point(732, 8)
        Me.cmbRrk.Name = "cmbRrk"
        Me.cmbRrk.Size = New System.Drawing.Size(328, 21)
        Me.cmbRrk.TabIndex = 10
        '
        'lblModeBadge
        '
        Me.lblModeBadge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblModeBadge.BackColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(210, Byte), Integer))
        Me.lblModeBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModeBadge.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblModeBadge.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblModeBadge.Location = New System.Drawing.Point(1068, 7)
        Me.lblModeBadge.Name = "lblModeBadge"
        Me.lblModeBadge.Size = New System.Drawing.Size(144, 26)
        Me.lblModeBadge.TabIndex = 11
        Me.lblModeBadge.Text = "ネットワーク接続"
        Me.lblModeBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stlSearchCond, Me.stlRecCount, Me.stlDspMode, Me.stlPcName})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 756)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1220, 24)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'stlSearchCond
        '
        Me.stlSearchCond.AutoSize = False
        Me.stlSearchCond.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.stlSearchCond.Name = "stlSearchCond"
        Me.stlSearchCond.Size = New System.Drawing.Size(260, 19)
        Me.stlSearchCond.Text = "検索条件: すべて"
        Me.stlSearchCond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stlRecCount
        '
        Me.stlRecCount.AutoSize = False
        Me.stlRecCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.stlRecCount.Name = "stlRecCount"
        Me.stlRecCount.Size = New System.Drawing.Size(140, 19)
        Me.stlRecCount.Text = "対象件数：0件"
        Me.stlRecCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stlDspMode
        '
        Me.stlDspMode.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.stlDspMode.Name = "stlDspMode"
        Me.stlDspMode.Size = New System.Drawing.Size(645, 19)
        Me.stlDspMode.Spring = True
        Me.stlDspMode.Text = "[通常データ:表示する]"
        Me.stlDspMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stlPcName
        '
        Me.stlPcName.AutoSize = False
        Me.stlPcName.Name = "stlPcName"
        Me.stlPcName.Size = New System.Drawing.Size(160, 19)
        '
        'splitMain
        '
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.Location = New System.Drawing.Point(0, 64)
        Me.splitMain.Name = "splitMain"
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.tabDetail)
        Me.splitMain.Panel1.Controls.Add(Me.pnlRightHeader)
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.splitRight)
        Me.splitMain.Size = New System.Drawing.Size(1220, 692)
        Me.splitMain.SplitterDistance = 600
        Me.splitMain.SplitterWidth = 6
        Me.splitMain.TabIndex = 2
        '
        'tabDetail
        '
        Me.tabDetail.Controls.Add(Me.tabSinryou)
        Me.tabDetail.Controls.Add(Me.tabKisyu)
        Me.tabDetail.Controls.Add(Me.tabJitaku)
        Me.tabDetail.Controls.Add(Me.tabMnt)
        Me.tabDetail.Controls.Add(Me.tabMemoMap)
        Me.tabDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabDetail.Location = New System.Drawing.Point(0, 178)
        Me.tabDetail.Name = "tabDetail"
        Me.tabDetail.SelectedIndex = 0
        Me.tabDetail.Size = New System.Drawing.Size(600, 514)
        Me.tabDetail.TabIndex = 1
        '
        'tabSinryou
        '
        Me.tabSinryou.Controls.Add(Me.lblAddTitle)
        Me.tabSinryou.Controls.Add(Me.txtAdd)
        Me.tabSinryou.Controls.Add(Me.btnGoogleMap)
        Me.tabSinryou.Controls.Add(Me.btnGmapLink1)
        Me.tabSinryou.Controls.Add(Me.btnGmapLink2)
        Me.tabSinryou.Controls.Add(Me.btnGmapLink3)
        Me.tabSinryou.Controls.Add(Me.lblSinryouTitle)
        Me.tabSinryou.Controls.Add(Me.txtSinryou)
        Me.tabSinryou.Controls.Add(Me.lblBikouTitle)
        Me.tabSinryou.Controls.Add(Me.txtMemo)
        Me.tabSinryou.Controls.Add(Me.lblShareMemoTitle)
        Me.tabSinryou.Controls.Add(Me.btnEditMemoTab1)
        Me.tabSinryou.Controls.Add(Me.txtMemo2)
        Me.tabSinryou.Controls.Add(Me.lblRecentMntTitle)
        Me.tabSinryou.Controls.Add(Me.lstMntLog)
        Me.tabSinryou.Location = New System.Drawing.Point(4, 23)
        Me.tabSinryou.Name = "tabSinryou"
        Me.tabSinryou.Size = New System.Drawing.Size(592, 487)
        Me.tabSinryou.TabIndex = 0
        Me.tabSinryou.Text = "住所・診療時間"
        Me.tabSinryou.UseVisualStyleBackColor = True
        '
        'lblAddTitle
        '
        Me.lblAddTitle.Location = New System.Drawing.Point(10, 14)
        Me.lblAddTitle.Name = "lblAddTitle"
        Me.lblAddTitle.Size = New System.Drawing.Size(58, 18)
        Me.lblAddTitle.TabIndex = 0
        Me.lblAddTitle.Text = "住所"
        '
        'txtAdd
        '
        Me.txtAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdd.BackColor = System.Drawing.Color.White
        Me.txtAdd.Location = New System.Drawing.Point(72, 10)
        Me.txtAdd.Multiline = True
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.ReadOnly = True
        Me.txtAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAdd.Size = New System.Drawing.Size(395, 58)
        Me.txtAdd.TabIndex = 1
        '
        'btnGoogleMap
        '
        Me.btnGoogleMap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGoogleMap.Location = New System.Drawing.Point(475, 10)
        Me.btnGoogleMap.Name = "btnGoogleMap"
        Me.btnGoogleMap.Size = New System.Drawing.Size(105, 28)
        Me.btnGoogleMap.TabIndex = 2
        Me.btnGoogleMap.Text = "GoogleMap"
        Me.btnGoogleMap.UseVisualStyleBackColor = True
        '
        'btnGmapLink1
        '
        Me.btnGmapLink1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGmapLink1.Location = New System.Drawing.Point(475, 42)
        Me.btnGmapLink1.Name = "btnGmapLink1"
        Me.btnGmapLink1.Size = New System.Drawing.Size(32, 25)
        Me.btnGmapLink1.TabIndex = 3
        Me.btnGmapLink1.Text = "1"
        Me.btnGmapLink1.UseVisualStyleBackColor = True
        Me.btnGmapLink1.Visible = False
        '
        'btnGmapLink2
        '
        Me.btnGmapLink2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGmapLink2.Location = New System.Drawing.Point(511, 42)
        Me.btnGmapLink2.Name = "btnGmapLink2"
        Me.btnGmapLink2.Size = New System.Drawing.Size(32, 25)
        Me.btnGmapLink2.TabIndex = 4
        Me.btnGmapLink2.Text = "2"
        Me.btnGmapLink2.UseVisualStyleBackColor = True
        Me.btnGmapLink2.Visible = False
        '
        'btnGmapLink3
        '
        Me.btnGmapLink3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGmapLink3.Location = New System.Drawing.Point(547, 42)
        Me.btnGmapLink3.Name = "btnGmapLink3"
        Me.btnGmapLink3.Size = New System.Drawing.Size(32, 25)
        Me.btnGmapLink3.TabIndex = 5
        Me.btnGmapLink3.Text = "3"
        Me.btnGmapLink3.UseVisualStyleBackColor = True
        Me.btnGmapLink3.Visible = False
        '
        'lblSinryouTitle
        '
        Me.lblSinryouTitle.Location = New System.Drawing.Point(10, 78)
        Me.lblSinryouTitle.Name = "lblSinryouTitle"
        Me.lblSinryouTitle.Size = New System.Drawing.Size(58, 18)
        Me.lblSinryouTitle.TabIndex = 6
        Me.lblSinryouTitle.Text = "診療時間"
        '
        'txtSinryou
        '
        Me.txtSinryou.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSinryou.BackColor = System.Drawing.Color.White
        Me.txtSinryou.Location = New System.Drawing.Point(72, 74)
        Me.txtSinryou.Multiline = True
        Me.txtSinryou.Name = "txtSinryou"
        Me.txtSinryou.ReadOnly = True
        Me.txtSinryou.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSinryou.Size = New System.Drawing.Size(509, 44)
        Me.txtSinryou.TabIndex = 7
        '
        'lblBikouTitle
        '
        Me.lblBikouTitle.Location = New System.Drawing.Point(10, 128)
        Me.lblBikouTitle.Name = "lblBikouTitle"
        Me.lblBikouTitle.Size = New System.Drawing.Size(58, 18)
        Me.lblBikouTitle.TabIndex = 8
        Me.lblBikouTitle.Text = "備考"
        '
        'txtMemo
        '
        Me.txtMemo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMemo.BackColor = System.Drawing.Color.White
        Me.txtMemo.Location = New System.Drawing.Point(72, 124)
        Me.txtMemo.Multiline = True
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.ReadOnly = True
        Me.txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMemo.Size = New System.Drawing.Size(509, 100)
        Me.txtMemo.TabIndex = 9
        '
        'lblShareMemoTitle
        '
        Me.lblShareMemoTitle.Location = New System.Drawing.Point(10, 234)
        Me.lblShareMemoTitle.Name = "lblShareMemoTitle"
        Me.lblShareMemoTitle.Size = New System.Drawing.Size(58, 18)
        Me.lblShareMemoTitle.TabIndex = 10
        Me.lblShareMemoTitle.Text = "メモ"
        '
        'btnEditMemoTab1
        '
        Me.btnEditMemoTab1.Location = New System.Drawing.Point(8, 256)
        Me.btnEditMemoTab1.Name = "btnEditMemoTab1"
        Me.btnEditMemoTab1.Size = New System.Drawing.Size(58, 24)
        Me.btnEditMemoTab1.TabIndex = 11
        Me.btnEditMemoTab1.Text = "編集"
        Me.btnEditMemoTab1.UseVisualStyleBackColor = True
        '
        'txtMemo2
        '
        Me.txtMemo2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMemo2.BackColor = System.Drawing.Color.White
        Me.txtMemo2.Location = New System.Drawing.Point(72, 230)
        Me.txtMemo2.Multiline = True
        Me.txtMemo2.Name = "txtMemo2"
        Me.txtMemo2.ReadOnly = True
        Me.txtMemo2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMemo2.Size = New System.Drawing.Size(509, 100)
        Me.txtMemo2.TabIndex = 12
        '
        'lblRecentMntTitle
        '
        Me.lblRecentMntTitle.Location = New System.Drawing.Point(6, 340)
        Me.lblRecentMntTitle.Name = "lblRecentMntTitle"
        Me.lblRecentMntTitle.Size = New System.Drawing.Size(64, 18)
        Me.lblRecentMntTitle.TabIndex = 13
        Me.lblRecentMntTitle.Text = "最近の記録"
        '
        'lstMntLog
        '
        Me.lstMntLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstMntLog.HorizontalScrollbar = True
        Me.lstMntLog.Location = New System.Drawing.Point(72, 336)
        Me.lstMntLog.Name = "lstMntLog"
        Me.lstMntLog.Size = New System.Drawing.Size(509, 134)
        Me.lstMntLog.TabIndex = 14
        '
        'tabKisyu
        '
        Me.tabKisyu.Controls.Add(Me.btnCopyKisyu)
        Me.tabKisyu.Controls.Add(Me.lblPcTitle)
        Me.tabKisyu.Controls.Add(Me.txtPc0)
        Me.tabKisyu.Controls.Add(Me.txtPc1)
        Me.tabKisyu.Controls.Add(Me.lblPrtTitle)
        Me.tabKisyu.Controls.Add(Me.txtPrt0)
        Me.tabKisyu.Controls.Add(Me.txtPrt1)
        Me.tabKisyu.Controls.Add(Me.lblMnTitle)
        Me.tabKisyu.Controls.Add(Me.txtMn0)
        Me.tabKisyu.Controls.Add(Me.txtMn1)
        Me.tabKisyu.Controls.Add(Me.lblBcrTitle)
        Me.tabKisyu.Controls.Add(Me.txtBcr0)
        Me.tabKisyu.Controls.Add(Me.txtBcr1)
        Me.tabKisyu.Controls.Add(Me.lblHddTitle)
        Me.tabKisyu.Controls.Add(Me.txtHdd0)
        Me.tabKisyu.Controls.Add(Me.txtHdd1)
        Me.tabKisyu.Controls.Add(Me.lblMiniPrtTitle)
        Me.tabKisyu.Controls.Add(Me.txtMiniPrt0)
        Me.tabKisyu.Controls.Add(Me.txtMiniPrt1)
        Me.tabKisyu.Controls.Add(Me.lblNohinTitle)
        Me.tabKisyu.Controls.Add(Me.txtNohin)
        Me.tabKisyu.Controls.Add(Me.lblTantoTitle)
        Me.tabKisyu.Controls.Add(Me.txtTanto)
        Me.tabKisyu.Controls.Add(Me.lblLicenseTitle)
        Me.tabKisyu.Controls.Add(Me.txtLicense)
        Me.tabKisyu.Controls.Add(Me.lblLeaseTitle)
        Me.tabKisyu.Controls.Add(Me.txtSiharai)
        Me.tabKisyu.Controls.Add(Me.txtLeaseCo)
        Me.tabKisyu.Controls.Add(Me.txtLeaseStDate)
        Me.tabKisyu.Controls.Add(Me.txtLease1)
        Me.tabKisyu.Controls.Add(Me.txtLease2)
        Me.tabKisyu.Location = New System.Drawing.Point(4, 22)
        Me.tabKisyu.Name = "tabKisyu"
        Me.tabKisyu.Size = New System.Drawing.Size(592, 490)
        Me.tabKisyu.TabIndex = 1
        Me.tabKisyu.Text = "使用機種"
        Me.tabKisyu.UseVisualStyleBackColor = True
        '
        'btnCopyKisyu
        '
        Me.btnCopyKisyu.Location = New System.Drawing.Point(12, 10)
        Me.btnCopyKisyu.Name = "btnCopyKisyu"
        Me.btnCopyKisyu.Size = New System.Drawing.Size(120, 26)
        Me.btnCopyKisyu.TabIndex = 0
        Me.btnCopyKisyu.Text = "機種情報コピー"
        Me.btnCopyKisyu.UseVisualStyleBackColor = True
        '
        'lblPcTitle
        '
        Me.lblPcTitle.Location = New System.Drawing.Point(12, 46)
        Me.lblPcTitle.Name = "lblPcTitle"
        Me.lblPcTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblPcTitle.TabIndex = 1
        Me.lblPcTitle.Text = "本体"
        '
        'txtPc0
        '
        Me.txtPc0.BackColor = System.Drawing.Color.White
        Me.txtPc0.Location = New System.Drawing.Point(90, 42)
        Me.txtPc0.Name = "txtPc0"
        Me.txtPc0.ReadOnly = True
        Me.txtPc0.Size = New System.Drawing.Size(230, 20)
        Me.txtPc0.TabIndex = 2
        '
        'txtPc1
        '
        Me.txtPc1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPc1.BackColor = System.Drawing.Color.White
        Me.txtPc1.Location = New System.Drawing.Point(326, 42)
        Me.txtPc1.Name = "txtPc1"
        Me.txtPc1.ReadOnly = True
        Me.txtPc1.Size = New System.Drawing.Size(253, 20)
        Me.txtPc1.TabIndex = 3
        '
        'lblPrtTitle
        '
        Me.lblPrtTitle.Location = New System.Drawing.Point(12, 74)
        Me.lblPrtTitle.Name = "lblPrtTitle"
        Me.lblPrtTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblPrtTitle.TabIndex = 4
        Me.lblPrtTitle.Text = "プリンタ"
        '
        'txtPrt0
        '
        Me.txtPrt0.BackColor = System.Drawing.Color.White
        Me.txtPrt0.Location = New System.Drawing.Point(90, 70)
        Me.txtPrt0.Name = "txtPrt0"
        Me.txtPrt0.ReadOnly = True
        Me.txtPrt0.Size = New System.Drawing.Size(230, 20)
        Me.txtPrt0.TabIndex = 5
        '
        'txtPrt1
        '
        Me.txtPrt1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPrt1.BackColor = System.Drawing.Color.White
        Me.txtPrt1.Location = New System.Drawing.Point(326, 70)
        Me.txtPrt1.Name = "txtPrt1"
        Me.txtPrt1.ReadOnly = True
        Me.txtPrt1.Size = New System.Drawing.Size(253, 20)
        Me.txtPrt1.TabIndex = 6
        '
        'lblMnTitle
        '
        Me.lblMnTitle.Location = New System.Drawing.Point(12, 102)
        Me.lblMnTitle.Name = "lblMnTitle"
        Me.lblMnTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblMnTitle.TabIndex = 7
        Me.lblMnTitle.Text = "モニタ"
        '
        'txtMn0
        '
        Me.txtMn0.BackColor = System.Drawing.Color.White
        Me.txtMn0.Location = New System.Drawing.Point(90, 98)
        Me.txtMn0.Name = "txtMn0"
        Me.txtMn0.ReadOnly = True
        Me.txtMn0.Size = New System.Drawing.Size(230, 20)
        Me.txtMn0.TabIndex = 8
        '
        'txtMn1
        '
        Me.txtMn1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMn1.BackColor = System.Drawing.Color.White
        Me.txtMn1.Location = New System.Drawing.Point(326, 98)
        Me.txtMn1.Name = "txtMn1"
        Me.txtMn1.ReadOnly = True
        Me.txtMn1.Size = New System.Drawing.Size(253, 20)
        Me.txtMn1.TabIndex = 9
        '
        'lblBcrTitle
        '
        Me.lblBcrTitle.Location = New System.Drawing.Point(12, 130)
        Me.lblBcrTitle.Name = "lblBcrTitle"
        Me.lblBcrTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblBcrTitle.TabIndex = 10
        Me.lblBcrTitle.Text = "BCR"
        '
        'txtBcr0
        '
        Me.txtBcr0.BackColor = System.Drawing.Color.White
        Me.txtBcr0.Location = New System.Drawing.Point(90, 126)
        Me.txtBcr0.Name = "txtBcr0"
        Me.txtBcr0.ReadOnly = True
        Me.txtBcr0.Size = New System.Drawing.Size(230, 20)
        Me.txtBcr0.TabIndex = 11
        '
        'txtBcr1
        '
        Me.txtBcr1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBcr1.BackColor = System.Drawing.Color.White
        Me.txtBcr1.Location = New System.Drawing.Point(326, 126)
        Me.txtBcr1.Name = "txtBcr1"
        Me.txtBcr1.ReadOnly = True
        Me.txtBcr1.Size = New System.Drawing.Size(253, 20)
        Me.txtBcr1.TabIndex = 12
        '
        'lblHddTitle
        '
        Me.lblHddTitle.Location = New System.Drawing.Point(12, 158)
        Me.lblHddTitle.Name = "lblHddTitle"
        Me.lblHddTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblHddTitle.TabIndex = 13
        Me.lblHddTitle.Text = "BkUp(HDD)"
        '
        'txtHdd0
        '
        Me.txtHdd0.BackColor = System.Drawing.Color.White
        Me.txtHdd0.Location = New System.Drawing.Point(90, 154)
        Me.txtHdd0.Name = "txtHdd0"
        Me.txtHdd0.ReadOnly = True
        Me.txtHdd0.Size = New System.Drawing.Size(230, 20)
        Me.txtHdd0.TabIndex = 14
        '
        'txtHdd1
        '
        Me.txtHdd1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHdd1.BackColor = System.Drawing.Color.White
        Me.txtHdd1.Location = New System.Drawing.Point(326, 154)
        Me.txtHdd1.Name = "txtHdd1"
        Me.txtHdd1.ReadOnly = True
        Me.txtHdd1.Size = New System.Drawing.Size(253, 20)
        Me.txtHdd1.TabIndex = 15
        '
        'lblMiniPrtTitle
        '
        Me.lblMiniPrtTitle.Location = New System.Drawing.Point(12, 186)
        Me.lblMiniPrtTitle.Name = "lblMiniPrtTitle"
        Me.lblMiniPrtTitle.Size = New System.Drawing.Size(76, 18)
        Me.lblMiniPrtTitle.TabIndex = 16
        Me.lblMiniPrtTitle.Text = "小型プリンタ"
        '
        'txtMiniPrt0
        '
        Me.txtMiniPrt0.BackColor = System.Drawing.Color.White
        Me.txtMiniPrt0.Location = New System.Drawing.Point(90, 182)
        Me.txtMiniPrt0.Name = "txtMiniPrt0"
        Me.txtMiniPrt0.ReadOnly = True
        Me.txtMiniPrt0.Size = New System.Drawing.Size(230, 20)
        Me.txtMiniPrt0.TabIndex = 17
        '
        'txtMiniPrt1
        '
        Me.txtMiniPrt1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMiniPrt1.BackColor = System.Drawing.Color.White
        Me.txtMiniPrt1.Location = New System.Drawing.Point(326, 182)
        Me.txtMiniPrt1.Name = "txtMiniPrt1"
        Me.txtMiniPrt1.ReadOnly = True
        Me.txtMiniPrt1.Size = New System.Drawing.Size(253, 20)
        Me.txtMiniPrt1.TabIndex = 18
        '
        'lblNohinTitle
        '
        Me.lblNohinTitle.Location = New System.Drawing.Point(12, 222)
        Me.lblNohinTitle.Name = "lblNohinTitle"
        Me.lblNohinTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblNohinTitle.TabIndex = 19
        Me.lblNohinTitle.Text = "納品日"
        '
        'txtNohin
        '
        Me.txtNohin.BackColor = System.Drawing.Color.White
        Me.txtNohin.Location = New System.Drawing.Point(90, 218)
        Me.txtNohin.Name = "txtNohin"
        Me.txtNohin.ReadOnly = True
        Me.txtNohin.Size = New System.Drawing.Size(150, 20)
        Me.txtNohin.TabIndex = 20
        '
        'lblTantoTitle
        '
        Me.lblTantoTitle.Location = New System.Drawing.Point(252, 222)
        Me.lblTantoTitle.Name = "lblTantoTitle"
        Me.lblTantoTitle.Size = New System.Drawing.Size(42, 18)
        Me.lblTantoTitle.TabIndex = 21
        Me.lblTantoTitle.Text = "担当"
        '
        'txtTanto
        '
        Me.txtTanto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTanto.BackColor = System.Drawing.Color.White
        Me.txtTanto.Location = New System.Drawing.Point(296, 218)
        Me.txtTanto.Name = "txtTanto"
        Me.txtTanto.ReadOnly = True
        Me.txtTanto.Size = New System.Drawing.Size(283, 20)
        Me.txtTanto.TabIndex = 22
        '
        'lblLicenseTitle
        '
        Me.lblLicenseTitle.Location = New System.Drawing.Point(12, 252)
        Me.lblLicenseTitle.Name = "lblLicenseTitle"
        Me.lblLicenseTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblLicenseTitle.TabIndex = 23
        Me.lblLicenseTitle.Text = "ライセンス"
        '
        'txtLicense
        '
        Me.txtLicense.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLicense.BackColor = System.Drawing.Color.White
        Me.txtLicense.Location = New System.Drawing.Point(90, 248)
        Me.txtLicense.Name = "txtLicense"
        Me.txtLicense.ReadOnly = True
        Me.txtLicense.Size = New System.Drawing.Size(489, 20)
        Me.txtLicense.TabIndex = 24
        '
        'lblLeaseTitle
        '
        Me.lblLeaseTitle.Location = New System.Drawing.Point(12, 284)
        Me.lblLeaseTitle.Name = "lblLeaseTitle"
        Me.lblLeaseTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblLeaseTitle.TabIndex = 25
        Me.lblLeaseTitle.Text = "リース等"
        '
        'txtSiharai
        '
        Me.txtSiharai.BackColor = System.Drawing.Color.White
        Me.txtSiharai.Location = New System.Drawing.Point(90, 280)
        Me.txtSiharai.Name = "txtSiharai"
        Me.txtSiharai.ReadOnly = True
        Me.txtSiharai.Size = New System.Drawing.Size(80, 20)
        Me.txtSiharai.TabIndex = 26
        '
        'txtLeaseCo
        '
        Me.txtLeaseCo.BackColor = System.Drawing.Color.White
        Me.txtLeaseCo.Location = New System.Drawing.Point(176, 280)
        Me.txtLeaseCo.Name = "txtLeaseCo"
        Me.txtLeaseCo.ReadOnly = True
        Me.txtLeaseCo.Size = New System.Drawing.Size(200, 20)
        Me.txtLeaseCo.TabIndex = 27
        '
        'txtLeaseStDate
        '
        Me.txtLeaseStDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLeaseStDate.BackColor = System.Drawing.Color.White
        Me.txtLeaseStDate.Location = New System.Drawing.Point(382, 280)
        Me.txtLeaseStDate.Name = "txtLeaseStDate"
        Me.txtLeaseStDate.ReadOnly = True
        Me.txtLeaseStDate.Size = New System.Drawing.Size(197, 20)
        Me.txtLeaseStDate.TabIndex = 28
        '
        'txtLease1
        '
        Me.txtLease1.BackColor = System.Drawing.Color.White
        Me.txtLease1.Location = New System.Drawing.Point(90, 308)
        Me.txtLease1.Name = "txtLease1"
        Me.txtLease1.ReadOnly = True
        Me.txtLease1.Size = New System.Drawing.Size(240, 20)
        Me.txtLease1.TabIndex = 29
        '
        'txtLease2
        '
        Me.txtLease2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLease2.BackColor = System.Drawing.Color.White
        Me.txtLease2.Location = New System.Drawing.Point(336, 308)
        Me.txtLease2.Name = "txtLease2"
        Me.txtLease2.ReadOnly = True
        Me.txtLease2.Size = New System.Drawing.Size(243, 20)
        Me.txtLease2.TabIndex = 30
        '
        'tabJitaku
        '
        Me.tabJitaku.Controls.Add(Me.lblMhTelTitle)
        Me.tabJitaku.Controls.Add(Me.txtMhTel)
        Me.tabJitaku.Controls.Add(Me.lblMbTelTitle)
        Me.tabJitaku.Controls.Add(Me.txtMbTel)
        Me.tabJitaku.Controls.Add(Me.lblFaxTitle)
        Me.tabJitaku.Controls.Add(Me.txtFax)
        Me.tabJitaku.Controls.Add(Me.lblTelExTitle)
        Me.tabJitaku.Controls.Add(Me.btnTelExEdit)
        Me.tabJitaku.Controls.Add(Me.txtTelEx0)
        Me.tabJitaku.Controls.Add(Me.txtTelEx1)
        Me.tabJitaku.Controls.Add(Me.txtTelEx2)
        Me.tabJitaku.Controls.Add(Me.txtTelEx3)
        Me.tabJitaku.Controls.Add(Me.txtTelEx4)
        Me.tabJitaku.Controls.Add(Me.lblMhAddTitle)
        Me.tabJitaku.Controls.Add(Me.txtMhAdd)
        Me.tabJitaku.Controls.Add(Me.lblVupAddTitle)
        Me.tabJitaku.Controls.Add(Me.txtVupAdd)
        Me.tabJitaku.Controls.Add(Me.lblPcAddTitle)
        Me.tabJitaku.Controls.Add(Me.txtPcAdd)
        Me.tabJitaku.Location = New System.Drawing.Point(4, 22)
        Me.tabJitaku.Name = "tabJitaku"
        Me.tabJitaku.Size = New System.Drawing.Size(592, 490)
        Me.tabJitaku.TabIndex = 2
        Me.tabJitaku.Text = "自宅"
        Me.tabJitaku.UseVisualStyleBackColor = True
        '
        'lblMhTelTitle
        '
        Me.lblMhTelTitle.Location = New System.Drawing.Point(12, 16)
        Me.lblMhTelTitle.Name = "lblMhTelTitle"
        Me.lblMhTelTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblMhTelTitle.TabIndex = 0
        Me.lblMhTelTitle.Text = "自宅電話"
        '
        'txtMhTel
        '
        Me.txtMhTel.BackColor = System.Drawing.Color.White
        Me.txtMhTel.Location = New System.Drawing.Point(90, 12)
        Me.txtMhTel.Name = "txtMhTel"
        Me.txtMhTel.ReadOnly = True
        Me.txtMhTel.Size = New System.Drawing.Size(170, 20)
        Me.txtMhTel.TabIndex = 1
        '
        'lblMbTelTitle
        '
        Me.lblMbTelTitle.Location = New System.Drawing.Point(12, 44)
        Me.lblMbTelTitle.Name = "lblMbTelTitle"
        Me.lblMbTelTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblMbTelTitle.TabIndex = 2
        Me.lblMbTelTitle.Text = "携帯番号"
        '
        'txtMbTel
        '
        Me.txtMbTel.BackColor = System.Drawing.Color.White
        Me.txtMbTel.Location = New System.Drawing.Point(90, 40)
        Me.txtMbTel.Name = "txtMbTel"
        Me.txtMbTel.ReadOnly = True
        Me.txtMbTel.Size = New System.Drawing.Size(170, 20)
        Me.txtMbTel.TabIndex = 3
        '
        'lblFaxTitle
        '
        Me.lblFaxTitle.Location = New System.Drawing.Point(12, 72)
        Me.lblFaxTitle.Name = "lblFaxTitle"
        Me.lblFaxTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblFaxTitle.TabIndex = 4
        Me.lblFaxTitle.Text = "FAX番号"
        '
        'txtFax
        '
        Me.txtFax.BackColor = System.Drawing.Color.White
        Me.txtFax.Location = New System.Drawing.Point(90, 68)
        Me.txtFax.Name = "txtFax"
        Me.txtFax.ReadOnly = True
        Me.txtFax.Size = New System.Drawing.Size(170, 20)
        Me.txtFax.TabIndex = 5
        '
        'lblTelExTitle
        '
        Me.lblTelExTitle.Location = New System.Drawing.Point(272, 16)
        Me.lblTelExTitle.Name = "lblTelExTitle"
        Me.lblTelExTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblTelExTitle.TabIndex = 6
        Me.lblTelExTitle.Text = "その他電話"
        '
        'btnTelExEdit
        '
        Me.btnTelExEdit.Location = New System.Drawing.Point(272, 38)
        Me.btnTelExEdit.Name = "btnTelExEdit"
        Me.btnTelExEdit.Size = New System.Drawing.Size(66, 25)
        Me.btnTelExEdit.TabIndex = 7
        Me.btnTelExEdit.Text = "編集"
        Me.btnTelExEdit.UseVisualStyleBackColor = True
        '
        'txtTelEx0
        '
        Me.txtTelEx0.BackColor = System.Drawing.Color.White
        Me.txtTelEx0.Location = New System.Drawing.Point(346, 12)
        Me.txtTelEx0.Name = "txtTelEx0"
        Me.txtTelEx0.ReadOnly = True
        Me.txtTelEx0.Size = New System.Drawing.Size(115, 20)
        Me.txtTelEx0.TabIndex = 8
        '
        'txtTelEx1
        '
        Me.txtTelEx1.BackColor = System.Drawing.Color.White
        Me.txtTelEx1.Location = New System.Drawing.Point(465, 12)
        Me.txtTelEx1.Name = "txtTelEx1"
        Me.txtTelEx1.ReadOnly = True
        Me.txtTelEx1.Size = New System.Drawing.Size(115, 20)
        Me.txtTelEx1.TabIndex = 9
        '
        'txtTelEx2
        '
        Me.txtTelEx2.BackColor = System.Drawing.Color.White
        Me.txtTelEx2.Location = New System.Drawing.Point(346, 38)
        Me.txtTelEx2.Name = "txtTelEx2"
        Me.txtTelEx2.ReadOnly = True
        Me.txtTelEx2.Size = New System.Drawing.Size(115, 20)
        Me.txtTelEx2.TabIndex = 10
        '
        'txtTelEx3
        '
        Me.txtTelEx3.BackColor = System.Drawing.Color.White
        Me.txtTelEx3.Location = New System.Drawing.Point(465, 38)
        Me.txtTelEx3.Name = "txtTelEx3"
        Me.txtTelEx3.ReadOnly = True
        Me.txtTelEx3.Size = New System.Drawing.Size(115, 20)
        Me.txtTelEx3.TabIndex = 11
        '
        'txtTelEx4
        '
        Me.txtTelEx4.BackColor = System.Drawing.Color.White
        Me.txtTelEx4.Location = New System.Drawing.Point(346, 64)
        Me.txtTelEx4.Name = "txtTelEx4"
        Me.txtTelEx4.ReadOnly = True
        Me.txtTelEx4.Size = New System.Drawing.Size(115, 20)
        Me.txtTelEx4.TabIndex = 12
        '
        'lblMhAddTitle
        '
        Me.lblMhAddTitle.Location = New System.Drawing.Point(12, 104)
        Me.lblMhAddTitle.Name = "lblMhAddTitle"
        Me.lblMhAddTitle.Size = New System.Drawing.Size(72, 18)
        Me.lblMhAddTitle.TabIndex = 13
        Me.lblMhAddTitle.Text = "自宅住所"
        '
        'txtMhAdd
        '
        Me.txtMhAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMhAdd.BackColor = System.Drawing.Color.White
        Me.txtMhAdd.Location = New System.Drawing.Point(90, 100)
        Me.txtMhAdd.Multiline = True
        Me.txtMhAdd.Name = "txtMhAdd"
        Me.txtMhAdd.ReadOnly = True
        Me.txtMhAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMhAdd.Size = New System.Drawing.Size(489, 54)
        Me.txtMhAdd.TabIndex = 14
        '
        'lblVupAddTitle
        '
        Me.lblVupAddTitle.Location = New System.Drawing.Point(12, 168)
        Me.lblVupAddTitle.Name = "lblVupAddTitle"
        Me.lblVupAddTitle.Size = New System.Drawing.Size(76, 18)
        Me.lblVupAddTitle.TabIndex = 15
        Me.lblVupAddTitle.Text = "Vup送付先"
        Me.lblVupAddTitle.Visible = False
        '
        'txtVupAdd
        '
        Me.txtVupAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtVupAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtVupAdd.Location = New System.Drawing.Point(90, 164)
        Me.txtVupAdd.Multiline = True
        Me.txtVupAdd.Name = "txtVupAdd"
        Me.txtVupAdd.ReadOnly = True
        Me.txtVupAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtVupAdd.Size = New System.Drawing.Size(489, 68)
        Me.txtVupAdd.TabIndex = 16
        Me.txtVupAdd.Visible = False
        '
        'lblPcAddTitle
        '
        Me.lblPcAddTitle.Location = New System.Drawing.Point(12, 244)
        Me.lblPcAddTitle.Name = "lblPcAddTitle"
        Me.lblPcAddTitle.Size = New System.Drawing.Size(78, 18)
        Me.lblPcAddTitle.TabIndex = 17
        Me.lblPcAddTitle.Text = "機械設置場所"
        Me.lblPcAddTitle.Visible = False
        '
        'txtPcAdd
        '
        Me.txtPcAdd.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPcAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.txtPcAdd.Location = New System.Drawing.Point(90, 240)
        Me.txtPcAdd.Multiline = True
        Me.txtPcAdd.Name = "txtPcAdd"
        Me.txtPcAdd.ReadOnly = True
        Me.txtPcAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPcAdd.Size = New System.Drawing.Size(489, 68)
        Me.txtPcAdd.TabIndex = 18
        Me.txtPcAdd.Visible = False
        '
        'tabMnt
        '
        Me.tabMnt.Controls.Add(Me.splitMnt)
        Me.tabMnt.Controls.Add(Me.pnlMntTop)
        Me.tabMnt.Location = New System.Drawing.Point(4, 22)
        Me.tabMnt.Name = "tabMnt"
        Me.tabMnt.Size = New System.Drawing.Size(592, 490)
        Me.tabMnt.TabIndex = 3
        Me.tabMnt.Text = "メンテナンス"
        Me.tabMnt.UseVisualStyleBackColor = True
        '
        'splitMnt
        '
        Me.splitMnt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMnt.Location = New System.Drawing.Point(0, 60)
        Me.splitMnt.Name = "splitMnt"
        Me.splitMnt.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitMnt.Panel1
        '
        Me.splitMnt.Panel1.Controls.Add(Me.dgvMntUsr)
        '
        'splitMnt.Panel2
        '
        Me.splitMnt.Panel2.Controls.Add(Me.txtMntSelectedContent)
        Me.splitMnt.Size = New System.Drawing.Size(592, 430)
        Me.splitMnt.SplitterDistance = 280
        Me.splitMnt.TabIndex = 1
        '
        'dgvMntUsr
        '
        Me.dgvMntUsr.AllowUserToAddRows = False
        Me.dgvMntUsr.AllowUserToDeleteRows = False
        Me.dgvMntUsr.BackgroundColor = System.Drawing.Color.White
        Me.dgvMntUsr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMntUsr.Location = New System.Drawing.Point(0, 0)
        Me.dgvMntUsr.MultiSelect = False
        Me.dgvMntUsr.Name = "dgvMntUsr"
        Me.dgvMntUsr.ReadOnly = True
        Me.dgvMntUsr.RowHeadersVisible = False
        Me.dgvMntUsr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMntUsr.Size = New System.Drawing.Size(592, 280)
        Me.dgvMntUsr.TabIndex = 0
        '
        'txtMntSelectedContent
        '
        Me.txtMntSelectedContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtMntSelectedContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMntSelectedContent.Location = New System.Drawing.Point(0, 0)
        Me.txtMntSelectedContent.Multiline = True
        Me.txtMntSelectedContent.Name = "txtMntSelectedContent"
        Me.txtMntSelectedContent.ReadOnly = True
        Me.txtMntSelectedContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMntSelectedContent.Size = New System.Drawing.Size(592, 146)
        Me.txtMntSelectedContent.TabIndex = 0
        '
        'pnlMntTop
        '
        Me.pnlMntTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlMntTop.Controls.Add(Me.rdoMntSortSagyou)
        Me.pnlMntTop.Controls.Add(Me.rdoMntSortKijitsu)
        Me.pnlMntTop.Controls.Add(Me.chkMntKanryou)
        Me.pnlMntTop.Controls.Add(Me.chkMntAutoScroll)
        Me.pnlMntTop.Controls.Add(Me.lblMntCount)
        Me.pnlMntTop.Controls.Add(Me.btnMntAdd)
        Me.pnlMntTop.Controls.Add(Me.btnMntEdit)
        Me.pnlMntTop.Controls.Add(Me.btnMntMark)
        Me.pnlMntTop.Controls.Add(Me.btnMntFindTab)
        Me.pnlMntTop.Controls.Add(Me.btnMntListTab)
        Me.pnlMntTop.Controls.Add(Me.btnMntPrt)
        Me.pnlMntTop.Controls.Add(Me.btnMntOpt)
        Me.pnlMntTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMntTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlMntTop.Name = "pnlMntTop"
        Me.pnlMntTop.Size = New System.Drawing.Size(592, 60)
        Me.pnlMntTop.TabIndex = 0
        '
        'rdoMntSortSagyou
        '
        Me.rdoMntSortSagyou.Checked = True
        Me.rdoMntSortSagyou.Location = New System.Drawing.Point(10, 6)
        Me.rdoMntSortSagyou.Name = "rdoMntSortSagyou"
        Me.rdoMntSortSagyou.Size = New System.Drawing.Size(82, 20)
        Me.rdoMntSortSagyou.TabIndex = 0
        Me.rdoMntSortSagyou.TabStop = True
        Me.rdoMntSortSagyou.Text = "作業日順"
        Me.rdoMntSortSagyou.UseVisualStyleBackColor = True
        '
        'rdoMntSortKijitsu
        '
        Me.rdoMntSortKijitsu.Location = New System.Drawing.Point(96, 6)
        Me.rdoMntSortKijitsu.Name = "rdoMntSortKijitsu"
        Me.rdoMntSortKijitsu.Size = New System.Drawing.Size(72, 20)
        Me.rdoMntSortKijitsu.TabIndex = 1
        Me.rdoMntSortKijitsu.Text = "期日順"
        Me.rdoMntSortKijitsu.UseVisualStyleBackColor = True
        '
        'chkMntKanryou
        '
        Me.chkMntKanryou.Checked = True
        Me.chkMntKanryou.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMntKanryou.Location = New System.Drawing.Point(178, 6)
        Me.chkMntKanryou.Name = "chkMntKanryou"
        Me.chkMntKanryou.Size = New System.Drawing.Size(106, 20)
        Me.chkMntKanryou.TabIndex = 2
        Me.chkMntKanryou.Text = "完了分も表示"
        Me.chkMntKanryou.UseVisualStyleBackColor = True
        '
        'chkMntAutoScroll
        '
        Me.chkMntAutoScroll.Checked = True
        Me.chkMntAutoScroll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMntAutoScroll.Location = New System.Drawing.Point(290, 6)
        Me.chkMntAutoScroll.Name = "chkMntAutoScroll"
        Me.chkMntAutoScroll.Size = New System.Drawing.Size(160, 20)
        Me.chkMntAutoScroll.TabIndex = 3
        Me.chkMntAutoScroll.Text = "最新行へ自動スクロール"
        Me.chkMntAutoScroll.UseVisualStyleBackColor = True
        '
        'lblMntCount
        '
        Me.lblMntCount.AutoSize = True
        Me.lblMntCount.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblMntCount.Location = New System.Drawing.Point(460, 8)
        Me.lblMntCount.Name = "lblMntCount"
        Me.lblMntCount.Size = New System.Drawing.Size(29, 13)
        Me.lblMntCount.TabIndex = 4
        Me.lblMntCount.Text = "0件"
        '
        'btnMntAdd
        '
        Me.btnMntAdd.Location = New System.Drawing.Point(6, 30)
        Me.btnMntAdd.Name = "btnMntAdd"
        Me.btnMntAdd.Size = New System.Drawing.Size(84, 26)
        Me.btnMntAdd.TabIndex = 5
        Me.btnMntAdd.Text = "新規追加(&A)"
        Me.btnMntAdd.UseVisualStyleBackColor = True
        '
        'btnMntEdit
        '
        Me.btnMntEdit.Location = New System.Drawing.Point(93, 30)
        Me.btnMntEdit.Name = "btnMntEdit"
        Me.btnMntEdit.Size = New System.Drawing.Size(68, 26)
        Me.btnMntEdit.TabIndex = 6
        Me.btnMntEdit.Text = "編集(&E)"
        Me.btnMntEdit.UseVisualStyleBackColor = True
        '
        'btnMntMark
        '
        Me.btnMntMark.Location = New System.Drawing.Point(164, 30)
        Me.btnMntMark.Name = "btnMntMark"
        Me.btnMntMark.Size = New System.Drawing.Size(74, 26)
        Me.btnMntMark.TabIndex = 7
        Me.btnMntMark.Text = "強調検索"
        Me.btnMntMark.UseVisualStyleBackColor = True
        '
        'btnMntFindTab
        '
        Me.btnMntFindTab.Location = New System.Drawing.Point(241, 30)
        Me.btnMntFindTab.Name = "btnMntFindTab"
        Me.btnMntFindTab.Size = New System.Drawing.Size(74, 26)
        Me.btnMntFindTab.TabIndex = 8
        Me.btnMntFindTab.Text = "全文検索"
        Me.btnMntFindTab.UseVisualStyleBackColor = True
        '
        'btnMntListTab
        '
        Me.btnMntListTab.Location = New System.Drawing.Point(318, 30)
        Me.btnMntListTab.Name = "btnMntListTab"
        Me.btnMntListTab.Size = New System.Drawing.Size(74, 26)
        Me.btnMntListTab.TabIndex = 9
        Me.btnMntListTab.Text = "全件一覧"
        Me.btnMntListTab.UseVisualStyleBackColor = True
        '
        'btnMntPrt
        '
        Me.btnMntPrt.Location = New System.Drawing.Point(395, 30)
        Me.btnMntPrt.Name = "btnMntPrt"
        Me.btnMntPrt.Size = New System.Drawing.Size(72, 26)
        Me.btnMntPrt.TabIndex = 10
        Me.btnMntPrt.Text = "印刷(&P)"
        Me.btnMntPrt.UseVisualStyleBackColor = True
        '
        'btnMntOpt
        '
        Me.btnMntOpt.Location = New System.Drawing.Point(470, 30)
        Me.btnMntOpt.Name = "btnMntOpt"
        Me.btnMntOpt.Size = New System.Drawing.Size(72, 26)
        Me.btnMntOpt.TabIndex = 11
        Me.btnMntOpt.Text = "設定(&O)"
        Me.btnMntOpt.UseVisualStyleBackColor = True
        '
        'tabMemoMap
        '
        Me.tabMemoMap.Controls.Add(Me.splitMemoMap)
        Me.tabMemoMap.Location = New System.Drawing.Point(4, 22)
        Me.tabMemoMap.Name = "tabMemoMap"
        Me.tabMemoMap.Size = New System.Drawing.Size(592, 490)
        Me.tabMemoMap.TabIndex = 4
        Me.tabMemoMap.Text = "メモ・地図"
        Me.tabMemoMap.UseVisualStyleBackColor = True
        '
        'splitMemoMap
        '
        Me.splitMemoMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMemoMap.Location = New System.Drawing.Point(0, 0)
        Me.splitMemoMap.Name = "splitMemoMap"
        Me.splitMemoMap.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitMemoMap.Panel1
        '
        Me.splitMemoMap.Panel1.Controls.Add(Me.lblTabMemoTitle)
        Me.splitMemoMap.Panel1.Controls.Add(Me.btnEditMemo)
        Me.splitMemoMap.Panel1.Controls.Add(Me.txtPmemo)
        Me.splitMemoMap.Panel1.Controls.Add(Me.lblPcPMemoTitle)
        Me.splitMemoMap.Panel1.Controls.Add(Me.btnEditPMemo)
        Me.splitMemoMap.Panel1.Controls.Add(Me.txtPcPMemo)
        '
        'splitMemoMap.Panel2
        '
        Me.splitMemoMap.Panel2.Controls.Add(Me.picMap)
        Me.splitMemoMap.Panel2.Controls.Add(Me.pnlMapToolbar)
        Me.splitMemoMap.Size = New System.Drawing.Size(592, 490)
        Me.splitMemoMap.SplitterDistance = 158
        Me.splitMemoMap.TabIndex = 0
        '
        'lblTabMemoTitle
        '
        Me.lblTabMemoTitle.AutoSize = True
        Me.lblTabMemoTitle.Location = New System.Drawing.Point(8, 8)
        Me.lblTabMemoTitle.Name = "lblTabMemoTitle"
        Me.lblTabMemoTitle.Size = New System.Drawing.Size(116, 13)
        Me.lblTabMemoTitle.TabIndex = 0
        Me.lblTabMemoTitle.Text = "共有メモ (mnt.mdb):"
        '
        'btnEditMemo
        '
        Me.btnEditMemo.Location = New System.Drawing.Point(198, 3)
        Me.btnEditMemo.Name = "btnEditMemo"
        Me.btnEditMemo.Size = New System.Drawing.Size(90, 24)
        Me.btnEditMemo.TabIndex = 1
        Me.btnEditMemo.Text = "メモ編集"
        Me.btnEditMemo.UseVisualStyleBackColor = True
        '
        'txtPmemo
        '
        Me.txtPmemo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPmemo.BackColor = System.Drawing.Color.White
        Me.txtPmemo.Location = New System.Drawing.Point(8, 30)
        Me.txtPmemo.Multiline = True
        Me.txtPmemo.Name = "txtPmemo"
        Me.txtPmemo.ReadOnly = True
        Me.txtPmemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPmemo.Size = New System.Drawing.Size(280, 120)
        Me.txtPmemo.TabIndex = 2
        '
        'lblPcPMemoTitle
        '
        Me.lblPcPMemoTitle.AutoSize = True
        Me.lblPcPMemoTitle.Location = New System.Drawing.Point(296, 8)
        Me.lblPcPMemoTitle.Name = "lblPcPMemoTitle"
        Me.lblPcPMemoTitle.Size = New System.Drawing.Size(117, 13)
        Me.lblPcPMemoTitle.TabIndex = 3
        Me.lblPcPMemoTitle.Text = "Pメモ (このPC専用):"
        '
        'btnEditPMemo
        '
        Me.btnEditPMemo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEditPMemo.Location = New System.Drawing.Point(492, 3)
        Me.btnEditPMemo.Name = "btnEditPMemo"
        Me.btnEditPMemo.Size = New System.Drawing.Size(90, 24)
        Me.btnEditPMemo.TabIndex = 4
        Me.btnEditPMemo.Text = "Pメモ編集"
        Me.btnEditPMemo.UseVisualStyleBackColor = True
        '
        'txtPcPMemo
        '
        Me.txtPcPMemo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPcPMemo.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.txtPcPMemo.Location = New System.Drawing.Point(296, 30)
        Me.txtPcPMemo.Multiline = True
        Me.txtPcPMemo.Name = "txtPcPMemo"
        Me.txtPcPMemo.ReadOnly = True
        Me.txtPcPMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPcPMemo.Size = New System.Drawing.Size(286, 120)
        Me.txtPcPMemo.TabIndex = 5
        '
        'picMap
        '
        Me.picMap.BackColor = System.Drawing.Color.White
        Me.picMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picMap.Location = New System.Drawing.Point(0, 32)
        Me.picMap.Name = "picMap"
        Me.picMap.Size = New System.Drawing.Size(592, 296)
        Me.picMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picMap.TabIndex = 1
        Me.picMap.TabStop = False
        '
        'pnlMapToolbar
        '
        Me.pnlMapToolbar.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.pnlMapToolbar.Controls.Add(Me.btnDispMap)
        Me.pnlMapToolbar.Controls.Add(Me.lblMapStatus)
        Me.pnlMapToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMapToolbar.Location = New System.Drawing.Point(0, 0)
        Me.pnlMapToolbar.Name = "pnlMapToolbar"
        Me.pnlMapToolbar.Size = New System.Drawing.Size(592, 32)
        Me.pnlMapToolbar.TabIndex = 0
        '
        'btnDispMap
        '
        Me.btnDispMap.Location = New System.Drawing.Point(8, 3)
        Me.btnDispMap.Name = "btnDispMap"
        Me.btnDispMap.Size = New System.Drawing.Size(170, 25)
        Me.btnDispMap.TabIndex = 0
        Me.btnDispMap.Text = "地図の表示 (外部ビューア)"
        Me.btnDispMap.UseVisualStyleBackColor = True
        '
        'lblMapStatus
        '
        Me.lblMapStatus.AutoSize = True
        Me.lblMapStatus.Location = New System.Drawing.Point(188, 8)
        Me.lblMapStatus.Name = "lblMapStatus"
        Me.lblMapStatus.Size = New System.Drawing.Size(88, 13)
        Me.lblMapStatus.TabIndex = 1
        Me.lblMapStatus.Text = "地図画像: なし"
        '
        'pnlRightHeader
        '
        Me.pnlRightHeader.BackColor = System.Drawing.SystemColors.Control
        Me.pnlRightHeader.Controls.Add(Me.lblCodeTitle)
        Me.pnlRightHeader.Controls.Add(Me.txtCode)
        Me.pnlRightHeader.Controls.Add(Me.lblVerTitle)
        Me.pnlRightHeader.Controls.Add(Me.txtVer)
        Me.pnlRightHeader.Controls.Add(Me.lblSibuTitle)
        Me.pnlRightHeader.Controls.Add(Me.txtSibu)
        Me.pnlRightHeader.Controls.Add(Me.btnCopyBracket)
        Me.pnlRightHeader.Controls.Add(Me.lblSjTitle)
        Me.pnlRightHeader.Controls.Add(Me.txtSjNameF)
        Me.pnlRightHeader.Controls.Add(Me.txtSjName)
        Me.pnlRightHeader.Controls.Add(Me.lblJsTitle)
        Me.pnlRightHeader.Controls.Add(Me.txtJsNameF)
        Me.pnlRightHeader.Controls.Add(Me.txtJsName)
        Me.pnlRightHeader.Controls.Add(Me.lblTelTitle)
        Me.pnlRightHeader.Controls.Add(Me.txtTel)
        Me.pnlRightHeader.Controls.Add(Me.lblImeBadge)
        Me.pnlRightHeader.Controls.Add(Me.lblInputBadge)
        Me.pnlRightHeader.Controls.Add(Me.lblNetBadge)
        Me.pnlRightHeader.Controls.Add(Me.lblClickBadge)
        Me.pnlRightHeader.Controls.Add(Me.lblPMemoBadge)
        Me.pnlRightHeader.Controls.Add(Me.flpTags)
        Me.pnlRightHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlRightHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlRightHeader.Name = "pnlRightHeader"
        Me.pnlRightHeader.Size = New System.Drawing.Size(600, 178)
        Me.pnlRightHeader.TabIndex = 0
        '
        'lblCodeTitle
        '
        Me.lblCodeTitle.Location = New System.Drawing.Point(8, 7)
        Me.lblCodeTitle.Name = "lblCodeTitle"
        Me.lblCodeTitle.Size = New System.Drawing.Size(62, 18)
        Me.lblCodeTitle.TabIndex = 0
        Me.lblCodeTitle.Text = "コード"
        Me.lblCodeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.Color.White
        Me.txtCode.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtCode.Location = New System.Drawing.Point(75, 4)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(76, 20)
        Me.txtCode.TabIndex = 1
        '
        'lblVerTitle
        '
        Me.lblVerTitle.Location = New System.Drawing.Point(154, 7)
        Me.lblVerTitle.Name = "lblVerTitle"
        Me.lblVerTitle.Size = New System.Drawing.Size(30, 18)
        Me.lblVerTitle.TabIndex = 2
        Me.lblVerTitle.Text = "Ver"
        Me.lblVerTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVer
        '
        Me.txtVer.BackColor = System.Drawing.Color.White
        Me.txtVer.Location = New System.Drawing.Point(188, 4)
        Me.txtVer.Name = "txtVer"
        Me.txtVer.ReadOnly = True
        Me.txtVer.Size = New System.Drawing.Size(220, 20)
        Me.txtVer.TabIndex = 3
        '
        'lblSibuTitle
        '
        Me.lblSibuTitle.Location = New System.Drawing.Point(8, 32)
        Me.lblSibuTitle.Name = "lblSibuTitle"
        Me.lblSibuTitle.Size = New System.Drawing.Size(62, 20)
        Me.lblSibuTitle.TabIndex = 4
        Me.lblSibuTitle.Text = "支部名"
        Me.lblSibuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSibu
        '
        Me.txtSibu.BackColor = System.Drawing.Color.White
        Me.txtSibu.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSibu.Location = New System.Drawing.Point(75, 28)
        Me.txtSibu.Name = "txtSibu"
        Me.txtSibu.ReadOnly = True
        Me.txtSibu.Size = New System.Drawing.Size(118, 23)
        Me.txtSibu.TabIndex = 5
        '
        'btnCopyBracket
        '
        Me.btnCopyBracket.Location = New System.Drawing.Point(198, 28)
        Me.btnCopyBracket.Name = "btnCopyBracket"
        Me.btnCopyBracket.Size = New System.Drawing.Size(88, 25)
        Me.btnCopyBracket.TabIndex = 6
        Me.btnCopyBracket.Text = "コピー"
        Me.btnCopyBracket.UseVisualStyleBackColor = True
        '
        'lblSjTitle
        '
        Me.lblSjTitle.Location = New System.Drawing.Point(8, 66)
        Me.lblSjTitle.Name = "lblSjTitle"
        Me.lblSjTitle.Size = New System.Drawing.Size(62, 22)
        Me.lblSjTitle.TabIndex = 7
        Me.lblSjTitle.Text = "施術所"
        Me.lblSjTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSjNameF
        '
        Me.txtSjNameF.BackColor = System.Drawing.Color.White
        Me.txtSjNameF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSjNameF.Location = New System.Drawing.Point(75, 55)
        Me.txtSjNameF.Name = "txtSjNameF"
        Me.txtSjNameF.ReadOnly = True
        Me.txtSjNameF.Size = New System.Drawing.Size(225, 20)
        Me.txtSjNameF.TabIndex = 8
        '
        'txtSjName
        '
        Me.txtSjName.BackColor = System.Drawing.Color.White
        Me.txtSjName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSjName.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtSjName.Location = New System.Drawing.Point(75, 73)
        Me.txtSjName.Name = "txtSjName"
        Me.txtSjName.ReadOnly = True
        Me.txtSjName.Size = New System.Drawing.Size(225, 26)
        Me.txtSjName.TabIndex = 9
        '
        'lblJsTitle
        '
        Me.lblJsTitle.Location = New System.Drawing.Point(8, 114)
        Me.lblJsTitle.Name = "lblJsTitle"
        Me.lblJsTitle.Size = New System.Drawing.Size(62, 22)
        Me.lblJsTitle.TabIndex = 10
        Me.lblJsTitle.Text = "柔整師"
        Me.lblJsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtJsNameF
        '
        Me.txtJsNameF.BackColor = System.Drawing.Color.White
        Me.txtJsNameF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJsNameF.Location = New System.Drawing.Point(75, 102)
        Me.txtJsNameF.Name = "txtJsNameF"
        Me.txtJsNameF.ReadOnly = True
        Me.txtJsNameF.Size = New System.Drawing.Size(225, 20)
        Me.txtJsNameF.TabIndex = 11
        '
        'txtJsName
        '
        Me.txtJsName.BackColor = System.Drawing.Color.White
        Me.txtJsName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJsName.Font = New System.Drawing.Font("ＭＳ Ｐ明朝", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtJsName.Location = New System.Drawing.Point(75, 120)
        Me.txtJsName.Name = "txtJsName"
        Me.txtJsName.ReadOnly = True
        Me.txtJsName.Size = New System.Drawing.Size(225, 25)
        Me.txtJsName.TabIndex = 12
        '
        'lblTelTitle
        '
        Me.lblTelTitle.Location = New System.Drawing.Point(8, 152)
        Me.lblTelTitle.Name = "lblTelTitle"
        Me.lblTelTitle.Size = New System.Drawing.Size(62, 22)
        Me.lblTelTitle.TabIndex = 13
        Me.lblTelTitle.Text = "TEL"
        Me.lblTelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTel
        '
        Me.txtTel.BackColor = System.Drawing.Color.White
        Me.txtTel.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtTel.Location = New System.Drawing.Point(75, 147)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.ReadOnly = True
        Me.txtTel.Size = New System.Drawing.Size(225, 35)
        Me.txtTel.TabIndex = 14
        '
        'lblImeBadge
        '
        Me.lblImeBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblImeBadge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblImeBadge.Location = New System.Drawing.Point(310, 28)
        Me.lblImeBadge.Name = "lblImeBadge"
        Me.lblImeBadge.Size = New System.Drawing.Size(118, 22)
        Me.lblImeBadge.TabIndex = 15
        Me.lblImeBadge.Text = "IME:不明"
        Me.lblImeBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInputBadge
        '
        Me.lblInputBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInputBadge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblInputBadge.Location = New System.Drawing.Point(310, 54)
        Me.lblInputBadge.Name = "lblInputBadge"
        Me.lblInputBadge.Size = New System.Drawing.Size(118, 22)
        Me.lblInputBadge.TabIndex = 16
        Me.lblInputBadge.Text = "入力方式:不明"
        Me.lblInputBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNetBadge
        '
        Me.lblNetBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNetBadge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblNetBadge.Location = New System.Drawing.Point(310, 80)
        Me.lblNetBadge.Name = "lblNetBadge"
        Me.lblNetBadge.Size = New System.Drawing.Size(118, 22)
        Me.lblNetBadge.TabIndex = 17
        Me.lblNetBadge.Text = "ネット:不明"
        Me.lblNetBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblClickBadge
        '
        Me.lblClickBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClickBadge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblClickBadge.Location = New System.Drawing.Point(310, 106)
        Me.lblClickBadge.Name = "lblClickBadge"
        Me.lblClickBadge.Size = New System.Drawing.Size(118, 22)
        Me.lblClickBadge.TabIndex = 18
        Me.lblClickBadge.Text = "クリックモード:不明"
        Me.lblClickBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPMemoBadge
        '
        Me.lblPMemoBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPMemoBadge.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblPMemoBadge.Location = New System.Drawing.Point(310, 148)
        Me.lblPMemoBadge.Name = "lblPMemoBadge"
        Me.lblPMemoBadge.Size = New System.Drawing.Size(118, 22)
        Me.lblPMemoBadge.TabIndex = 19
        Me.lblPMemoBadge.Text = "Pメモ"
        Me.lblPMemoBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'flpTags
        '
        Me.flpTags.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpTags.Location = New System.Drawing.Point(436, 4)
        Me.flpTags.Name = "flpTags"
        Me.flpTags.Size = New System.Drawing.Size(158, 170)
        Me.flpTags.TabIndex = 20
        Me.flpTags.WrapContents = False
        '
        'splitRight
        '
        Me.splitRight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitRight.Location = New System.Drawing.Point(0, 0)
        Me.splitRight.Name = "splitRight"
        Me.splitRight.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitRight.Panel1
        '
        Me.splitRight.Panel1.Controls.Add(Me.dgvUsr)
        Me.splitRight.Panel1.Controls.Add(Me.pnlUsrGridTop)
        '
        'splitRight.Panel2
        '
        Me.splitRight.Panel2.Controls.Add(Me.dgvPrt)
        Me.splitRight.Panel2.Controls.Add(Me.pnlPrtTop)
        Me.splitRight.Size = New System.Drawing.Size(614, 692)
        Me.splitRight.SplitterDistance = 442
        Me.splitRight.SplitterWidth = 6
        Me.splitRight.TabIndex = 0
        '
        'dgvUsr
        '
        Me.dgvUsr.AllowUserToAddRows = False
        Me.dgvUsr.AllowUserToDeleteRows = False
        Me.dgvUsr.AllowUserToResizeRows = False
        Me.dgvUsr.BackgroundColor = System.Drawing.Color.White
        Me.dgvUsr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsr.Location = New System.Drawing.Point(0, 24)
        Me.dgvUsr.MultiSelect = False
        Me.dgvUsr.Name = "dgvUsr"
        Me.dgvUsr.ReadOnly = True
        Me.dgvUsr.RowHeadersVisible = False
        Me.dgvUsr.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsr.Size = New System.Drawing.Size(614, 418)
        Me.dgvUsr.TabIndex = 1
        '
        'pnlUsrGridTop
        '
        Me.pnlUsrGridTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.pnlUsrGridTop.Controls.Add(Me.lblUsrGridHeader)
        Me.pnlUsrGridTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlUsrGridTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlUsrGridTop.Name = "pnlUsrGridTop"
        Me.pnlUsrGridTop.Size = New System.Drawing.Size(614, 24)
        Me.pnlUsrGridTop.TabIndex = 0
        '
        'lblUsrGridHeader
        '
        Me.lblUsrGridHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUsrGridHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUsrGridHeader.ForeColor = System.Drawing.Color.White
        Me.lblUsrGridHeader.Location = New System.Drawing.Point(0, 0)
        Me.lblUsrGridHeader.Name = "lblUsrGridHeader"
        Me.lblUsrGridHeader.Size = New System.Drawing.Size(614, 24)
        Me.lblUsrGridHeader.TabIndex = 0
        Me.lblUsrGridHeader.Text = " ユーザー一覧"
        Me.lblUsrGridHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvPrt
        '
        Me.dgvPrt.AllowUserToAddRows = False
        Me.dgvPrt.AllowUserToDeleteRows = False
        Me.dgvPrt.AllowUserToResizeRows = False
        Me.dgvPrt.BackgroundColor = System.Drawing.Color.White
        Me.dgvPrt.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrt.Location = New System.Drawing.Point(0, 32)
        Me.dgvPrt.MultiSelect = False
        Me.dgvPrt.Name = "dgvPrt"
        Me.dgvPrt.ReadOnly = True
        Me.dgvPrt.RowHeadersVisible = False
        Me.dgvPrt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPrt.Size = New System.Drawing.Size(614, 212)
        Me.dgvPrt.TabIndex = 1
        '
        'pnlPrtTop
        '
        Me.pnlPrtTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.pnlPrtTop.Controls.Add(Me.lblPrtHeader)
        Me.pnlPrtTop.Controls.Add(Me.btnPrtAdd)
        Me.pnlPrtTop.Controls.Add(Me.btnPrtDel)
        Me.pnlPrtTop.Controls.Add(Me.btnPrtAllDel)
        Me.pnlPrtTop.Controls.Add(Me.btnPrtExec)
        Me.pnlPrtTop.Controls.Add(Me.btnPrt1F)
        Me.pnlPrtTop.Controls.Add(Me.btnPrt2F)
        Me.pnlPrtTop.Controls.Add(Me.btnPrtOpt)
        Me.pnlPrtTop.Controls.Add(Me.btnListExport)
        Me.pnlPrtTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPrtTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlPrtTop.Name = "pnlPrtTop"
        Me.pnlPrtTop.Size = New System.Drawing.Size(614, 32)
        Me.pnlPrtTop.TabIndex = 0
        '
        'lblPrtHeader
        '
        Me.lblPrtHeader.AutoSize = True
        Me.lblPrtHeader.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblPrtHeader.Location = New System.Drawing.Point(6, 8)
        Me.lblPrtHeader.Name = "lblPrtHeader"
        Me.lblPrtHeader.Size = New System.Drawing.Size(68, 13)
        Me.lblPrtHeader.TabIndex = 0
        Me.lblPrtHeader.Text = "印刷リスト"
        '
        'btnPrtAdd
        '
        Me.btnPrtAdd.Location = New System.Drawing.Point(98, 3)
        Me.btnPrtAdd.Name = "btnPrtAdd"
        Me.btnPrtAdd.Size = New System.Drawing.Size(52, 25)
        Me.btnPrtAdd.TabIndex = 1
        Me.btnPrtAdd.Text = "追加"
        Me.btnPrtAdd.UseVisualStyleBackColor = True
        '
        'btnPrtDel
        '
        Me.btnPrtDel.Location = New System.Drawing.Point(153, 3)
        Me.btnPrtDel.Name = "btnPrtDel"
        Me.btnPrtDel.Size = New System.Drawing.Size(52, 25)
        Me.btnPrtDel.TabIndex = 2
        Me.btnPrtDel.Text = "削除"
        Me.btnPrtDel.UseVisualStyleBackColor = True
        '
        'btnPrtAllDel
        '
        Me.btnPrtAllDel.Location = New System.Drawing.Point(208, 3)
        Me.btnPrtAllDel.Name = "btnPrtAllDel"
        Me.btnPrtAllDel.Size = New System.Drawing.Size(58, 25)
        Me.btnPrtAllDel.TabIndex = 3
        Me.btnPrtAllDel.Text = "全削除"
        Me.btnPrtAllDel.UseVisualStyleBackColor = True
        '
        'btnPrtExec
        '
        Me.btnPrtExec.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnPrtExec.Location = New System.Drawing.Point(272, 3)
        Me.btnPrtExec.Name = "btnPrtExec"
        Me.btnPrtExec.Size = New System.Drawing.Size(56, 25)
        Me.btnPrtExec.TabIndex = 4
        Me.btnPrtExec.Text = "印刷"
        Me.btnPrtExec.UseVisualStyleBackColor = True
        '
        'btnPrt1F
        '
        Me.btnPrt1F.Location = New System.Drawing.Point(331, 3)
        Me.btnPrt1F.Name = "btnPrt1F"
        Me.btnPrt1F.Size = New System.Drawing.Size(58, 25)
        Me.btnPrt1F.TabIndex = 5
        Me.btnPrt1F.Text = "1F封筒"
        Me.btnPrt1F.UseVisualStyleBackColor = True
        '
        'btnPrt2F
        '
        Me.btnPrt2F.Location = New System.Drawing.Point(392, 3)
        Me.btnPrt2F.Name = "btnPrt2F"
        Me.btnPrt2F.Size = New System.Drawing.Size(58, 25)
        Me.btnPrt2F.TabIndex = 6
        Me.btnPrt2F.Text = "2F封筒"
        Me.btnPrt2F.UseVisualStyleBackColor = True
        '
        'btnPrtOpt
        '
        Me.btnPrtOpt.Location = New System.Drawing.Point(453, 3)
        Me.btnPrtOpt.Name = "btnPrtOpt"
        Me.btnPrtOpt.Size = New System.Drawing.Size(68, 25)
        Me.btnPrtOpt.TabIndex = 7
        Me.btnPrtOpt.Text = "印刷設定"
        Me.btnPrtOpt.UseVisualStyleBackColor = True
        '
        'btnListExport
        '
        Me.btnListExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnListExport.Location = New System.Drawing.Point(527, 2)
        Me.btnListExport.Name = "btnListExport"
        Me.btnListExport.Size = New System.Drawing.Size(30, 27)
        Me.btnListExport.TabIndex = 8
        Me.btnListExport.UseVisualStyleBackColor = True
        '
        'tmrRrk
        '
        Me.tmrRrk.Interval = 1200
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1220, 780)
        Me.Controls.Add(Me.splitMain)
        Me.Controls.Add(Me.pnlTopBar)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(980, 680)
        Me.Name = "FrmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ユーザー検索 (UsrDspNet)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pnlTopBar.ResumeLayout(False)
        Me.pnlTopBar.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.tabDetail.ResumeLayout(False)
        Me.tabSinryou.ResumeLayout(False)
        Me.tabSinryou.PerformLayout()
        Me.tabKisyu.ResumeLayout(False)
        Me.tabKisyu.PerformLayout()
        Me.tabJitaku.ResumeLayout(False)
        Me.tabJitaku.PerformLayout()
        Me.tabMnt.ResumeLayout(False)
        Me.splitMnt.Panel1.ResumeLayout(False)
        Me.splitMnt.Panel2.ResumeLayout(False)
        Me.splitMnt.Panel2.PerformLayout()
        CType(Me.splitMnt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMnt.ResumeLayout(False)
        CType(Me.dgvMntUsr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMntTop.ResumeLayout(False)
        Me.pnlMntTop.PerformLayout()
        Me.tabMemoMap.ResumeLayout(False)
        Me.splitMemoMap.Panel1.ResumeLayout(False)
        Me.splitMemoMap.Panel1.PerformLayout()
        Me.splitMemoMap.Panel2.ResumeLayout(False)
        CType(Me.splitMemoMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMemoMap.ResumeLayout(False)
        CType(Me.picMap, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMapToolbar.ResumeLayout(False)
        Me.pnlMapToolbar.PerformLayout()
        Me.pnlRightHeader.ResumeLayout(False)
        Me.pnlRightHeader.PerformLayout()
        Me.splitRight.Panel1.ResumeLayout(False)
        Me.splitRight.Panel2.ResumeLayout(False)
        CType(Me.splitRight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitRight.ResumeLayout(False)
        CType(Me.dgvUsr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlUsrGridTop.ResumeLayout(False)
        CType(Me.dgvPrt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPrtTop.ResumeLayout(False)
        Me.pnlPrtTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
