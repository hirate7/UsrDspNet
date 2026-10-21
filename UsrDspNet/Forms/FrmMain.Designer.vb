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
    Public WithEvents MenuStrip1 As MenuStrip
    Public WithEvents mnuFile As ToolStripMenuItem
    Public WithEvents mnuDbCopy As ToolStripMenuItem
    Public WithEvents mnuSep1 As ToolStripSeparator
    Public WithEvents mnuNetworkMode As ToolStripMenuItem
    Public WithEvents mnuLocalMode As ToolStripMenuItem
    Public WithEvents mnuSep2 As ToolStripSeparator
    Public WithEvents mnuExit As ToolStripMenuItem
    Public WithEvents mnuView As ToolStripMenuItem
    Public WithEvents mnuDspNormal As ToolStripMenuItem
    Public WithEvents mnuDspSleep As ToolStripMenuItem
    Public WithEvents mnuDspDelete As ToolStripMenuItem
    Public WithEvents mnuSearch As ToolStripMenuItem
    Public WithEvents mnuFindName As ToolStripMenuItem
    Public WithEvents mnuFindCode As ToolStripMenuItem
    Public WithEvents mnuFindSibu As ToolStripMenuItem
    Public WithEvents mnuFindTel As ToolStripMenuItem
    Public WithEvents mnuFindPc As ToolStripMenuItem
    Public WithEvents mnuFindSn As ToolStripMenuItem
    Public WithEvents mnuSep3 As ToolStripSeparator
    Public WithEvents mnuFindAll As ToolStripMenuItem
    Public WithEvents mnuMnt As ToolStripMenuItem
    Public WithEvents mnuMntList As ToolStripMenuItem
    Public WithEvents mnuMntFind As ToolStripMenuItem
    Public WithEvents mnuSepMnt As ToolStripSeparator
    Public WithEvents mnuMntAdd As ToolStripMenuItem
    Public WithEvents mnuMntEdit As ToolStripMenuItem
    Public WithEvents mnuMntMark As ToolStripMenuItem
    Public WithEvents mnuOpt As ToolStripMenuItem
    Public WithEvents mnuOptAll As ToolStripMenuItem
    Public WithEvents mnuOptBrowser As ToolStripMenuItem
    Public WithEvents mnuPrt As ToolStripMenuItem
    Public WithEvents mnuPrtList As ToolStripMenuItem
    Public WithEvents mnuPrtEnv1 As ToolStripMenuItem
    Public WithEvents mnuPrtEnv2 As ToolStripMenuItem
    Public WithEvents mnuSepPrt1 As ToolStripSeparator
    Public WithEvents mnuPrtMntUsr As ToolStripMenuItem
    Public WithEvents mnuSepPrt2 As ToolStripSeparator
    Public WithEvents mnuVupLabel As ToolStripMenuItem

    ' Top Toolbar Panel
    Public WithEvents pnlTopBar As Panel
    Public WithEvents btnFindName As Button
    Public WithEvents btnFindCode As Button
    Public WithEvents btnFindSibu As Button
    Public WithEvents btnFindTel As Button
    Public WithEvents btnFindPc As Button
    Public WithEvents btnFindSn As Button
    Public WithEvents btnShowAll As Button
    Public WithEvents btnMntFind As Button
    Public WithEvents btnMntList As Button
    Public WithEvents lblRrkTitle As Label
    Public WithEvents cmbRrk As ComboBox
    Public WithEvents lblModeBadge As Label

    ' StatusStrip
    Public WithEvents StatusStrip1 As StatusStrip
    Public WithEvents stlSearchCond As ToolStripStatusLabel
    Public WithEvents stlRecCount As ToolStripStatusLabel
    Public WithEvents stlDspMode As ToolStripStatusLabel
    Public WithEvents stlPcName As ToolStripStatusLabel

    ' SplitContainers
    Public WithEvents splitMain As SplitContainer
    Public WithEvents splitRight As SplitContainer

    ' Right Upper: User Grid
    Public WithEvents pnlUsrGridTop As Panel
    Public WithEvents lblUsrGridHeader As Label
    Public WithEvents dgvUsr As DataGridView

    ' Right Lower: Print List Grid
    Public WithEvents pnlPrtTop As Panel
    Public WithEvents lblPrtHeader As Label
    Public WithEvents btnPrtAdd As Button
    Public WithEvents btnPrtDel As Button
    Public WithEvents btnPrtAllDel As Button
    Public WithEvents btnPrtExec As Button
    Public WithEvents btnPrt1F As Button
    Public WithEvents btnPrt2F As Button
    Public WithEvents btnPrtOpt As Button
    Public WithEvents dgvPrt As DataGridView

    ' Left: User Detail Header + Tabs
    Public WithEvents pnlRightHeader As Panel
    Public WithEvents lblCodeTitle As Label
    Public WithEvents txtCode As TextBox
    Public WithEvents lblVerTitle As Label
    Public WithEvents txtVer As TextBox
    Public WithEvents lblSibuTitle As Label
    Public WithEvents txtSibu As TextBox
    Public WithEvents lblPMemoBadge As Label

    Public WithEvents flpTags As FlowLayoutPanel

    Public WithEvents lblSjTitle As Label
    Public WithEvents txtSjNameF As TextBox
    Public WithEvents txtSjName As TextBox
    Public WithEvents lblJsTitle As Label
    Public WithEvents txtJsNameF As TextBox
    Public WithEvents txtJsName As TextBox
    Public WithEvents lblTelTitle As Label
    Public WithEvents txtTel As TextBox

    ' Extended status badges (Vertically stacked in middle column) & Copy button
    Public WithEvents lblImeBadge As Label
    Public WithEvents lblInputBadge As Label
    Public WithEvents lblNetBadge As Label
    Public WithEvents lblClickBadge As Label
    Public WithEvents btnCopyBracket As Button

    ' Detail TabControl
    Public WithEvents tabDetail As TabControl
    Public WithEvents tabSinryou As TabPage
    Public WithEvents tabKisyu As TabPage
    Public WithEvents tabJitaku As TabPage
    Public WithEvents tabMnt As TabPage
    Public WithEvents tabMemoMap As TabPage

    ' Tab 1: 住所・診療時間
    Public WithEvents lblAddTitle As Label
    Public WithEvents txtAdd As TextBox
    Public WithEvents btnGoogleMap As Button
    Public WithEvents btnGmapLink1 As Button
    Public WithEvents btnGmapLink2 As Button
    Public WithEvents btnGmapLink3 As Button
    Public WithEvents lblSinryouTitle As Label
    Public WithEvents txtSinryou As TextBox
    Public WithEvents lblBikouTitle As Label
    Public WithEvents txtMemo As TextBox
    Public WithEvents lblShareMemoTitle As Label
    Public WithEvents btnEditMemoTab1 As Button
    Public WithEvents txtMemo2 As TextBox
    Public WithEvents lblRecentMntTitle As Label
    Public WithEvents lstMntLog As ListBox

    ' Tab 2: 使用機種
    Public WithEvents lblPcTitle As Label
    Public WithEvents txtPc0 As TextBox
    Public WithEvents txtPc1 As TextBox
    Public WithEvents lblPrtTitle As Label
    Public WithEvents txtPrt0 As TextBox
    Public WithEvents txtPrt1 As TextBox
    Public WithEvents lblMnTitle As Label
    Public WithEvents txtMn0 As TextBox
    Public WithEvents txtMn1 As TextBox
    Public WithEvents lblBcrTitle As Label
    Public WithEvents txtBcr0 As TextBox
    Public WithEvents txtBcr1 As TextBox
    Public WithEvents lblHddTitle As Label
    Public WithEvents txtHdd0 As TextBox
    Public WithEvents txtHdd1 As TextBox
    Public WithEvents lblMiniPrtTitle As Label
    Public WithEvents txtMiniPrt0 As TextBox
    Public WithEvents txtMiniPrt1 As TextBox
    Public WithEvents lblNohinTitle As Label
    Public WithEvents txtNohin As TextBox
    Public WithEvents lblTantoTitle As Label
    Public WithEvents txtTanto As TextBox
    Public WithEvents lblLicenseTitle As Label
    Public WithEvents txtLicense As TextBox
    Public WithEvents lblLeaseTitle As Label
    Public WithEvents txtSiharai As TextBox
    Public WithEvents txtLeaseCo As TextBox
    Public WithEvents txtLeaseStDate As TextBox
    Public WithEvents txtLease1 As TextBox
    Public WithEvents txtLease2 As TextBox
    Public WithEvents btnCopyKisyu As Button

    ' Tab 3: 自宅・送付先
    Public WithEvents lblMhTelTitle As Label
    Public WithEvents txtMhTel As TextBox
    Public WithEvents lblMbTelTitle As Label
    Public WithEvents txtMbTel As TextBox
    Public WithEvents lblFaxTitle As Label
    Public WithEvents txtFax As TextBox
    Public WithEvents lblMhAddTitle As Label
    Public WithEvents txtMhAdd As TextBox
    Public WithEvents lblTelExTitle As Label
    Public WithEvents btnTelExEdit As Button
    Public WithEvents txtTelEx0 As TextBox
    Public WithEvents txtTelEx1 As TextBox
    Public WithEvents txtTelEx2 As TextBox
    Public WithEvents txtTelEx3 As TextBox
    Public WithEvents txtTelEx4 As TextBox
    Public WithEvents lblVupAddTitle As Label
    Public WithEvents txtVupAdd As TextBox
    Public WithEvents lblPcAddTitle As Label
    Public WithEvents txtPcAdd As TextBox

    ' Tab 4: メンテナンス
    Public WithEvents pnlMntTop As Panel
    Public WithEvents rdoMntSortSagyou As RadioButton
    Public WithEvents rdoMntSortKijitsu As RadioButton
    Public WithEvents chkMntKanryou As CheckBox
    Public WithEvents chkMntAutoScroll As CheckBox
    Public WithEvents lblMntCount As Label
    Public WithEvents btnMntAdd As Button
    Public WithEvents btnMntEdit As Button
    Public WithEvents btnMntMark As Button
    Public WithEvents btnMntFindTab As Button
    Public WithEvents btnMntListTab As Button
    Public WithEvents btnMntPrt As Button
    Public WithEvents btnMntOpt As Button
    Public WithEvents splitMnt As SplitContainer
    Public WithEvents dgvMntUsr As DataGridView
    Public WithEvents txtMntSelectedContent As TextBox

    ' Tab 5: メモ・地図
    Public WithEvents splitMemoMap As SplitContainer
    Public WithEvents lblTabMemoTitle As Label
    Public WithEvents btnEditMemo As Button
    Public WithEvents txtPmemo As TextBox
    Public WithEvents lblPcPMemoTitle As Label
    Public WithEvents btnEditPMemo As Button
    Public WithEvents txtPcPMemo As TextBox
    Public WithEvents pnlMapToolbar As Panel
    Public WithEvents lblMapStatus As Label
    Public WithEvents btnDispMap As Button
    Public WithEvents picMap As PictureBox

    ' Timer for viewing history (rrk.txt)
    Public WithEvents tmrRrk As Timer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim defaultFont As New System.Drawing.Font("ＭＳ Ｐゴシック", 9.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Dim boldFont As New System.Drawing.Font("ＭＳ Ｐゴシック", 9.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Dim sibuFont As New System.Drawing.Font("ＭＳ ゴシック", 11.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Dim sjFont As New System.Drawing.Font("ＭＳ Ｐ明朝", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Dim jsFont As New System.Drawing.Font("ＭＳ Ｐ明朝", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Dim telFont As New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))

        Me.SuspendLayout()

        ' --- MenuStrip ---
        Me.MenuStrip1 = New MenuStrip()
        Me.mnuFile = New ToolStripMenuItem("ファイル(&F)")
        Me.mnuDbCopy = New ToolStripMenuItem("最新のデータに更新(&U)")
        Me.mnuSep1 = New ToolStripSeparator()
        Me.mnuNetworkMode = New ToolStripMenuItem("ネットワークモード(&N)")
        Me.mnuLocalMode = New ToolStripMenuItem("ローカルモード(&L)")
        Me.mnuSep2 = New ToolStripSeparator()
        Me.mnuExit = New ToolStripMenuItem("ユーザー検索を終了する(&X)")
        Me.mnuFile.DropDownItems.AddRange(New ToolStripItem() {Me.mnuDbCopy, Me.mnuSep1, Me.mnuNetworkMode, Me.mnuLocalMode, Me.mnuSep2, Me.mnuExit})

        Me.mnuView = New ToolStripMenuItem("表示(&V)")
        Me.mnuDspNormal = New ToolStripMenuItem("通常データ(&N)") With {.Checked = True, .CheckOnClick = True}
        Me.mnuDspSleep = New ToolStripMenuItem("一時休止データ(&S)") With {.Checked = True, .CheckOnClick = True}
        Me.mnuDspDelete = New ToolStripMenuItem("削除データ(&D)") With {.Checked = False, .CheckOnClick = True}
        Me.mnuView.DropDownItems.AddRange(New ToolStripItem() {Me.mnuDspNormal, Me.mnuDspSleep, Me.mnuDspDelete})

        Me.mnuSearch = New ToolStripMenuItem("検索(&S)")
        Me.mnuFindName = New ToolStripMenuItem("名前で検索(&N)") With {.ShortcutKeys = Keys.F1}
        Me.mnuFindCode = New ToolStripMenuItem("コードで検索(&C)") With {.ShortcutKeys = Keys.F2}
        Me.mnuFindSibu = New ToolStripMenuItem("支部名で検索(&B)") With {.ShortcutKeys = Keys.F3}
        Me.mnuFindTel = New ToolStripMenuItem("電話番号で検索(&T)") With {.ShortcutKeys = Keys.F4}
        Me.mnuFindPc = New ToolStripMenuItem("製品名で検索(&P)") With {.ShortcutKeys = Keys.F5}
        Me.mnuFindSn = New ToolStripMenuItem("シリアルナンバーで検索(&S)") With {.ShortcutKeys = Keys.F6}
        Me.mnuSep3 = New ToolStripSeparator()
        Me.mnuFindAll = New ToolStripMenuItem("すべて表示(&A)")
        Me.mnuSearch.DropDownItems.AddRange(New ToolStripItem() {Me.mnuFindName, Me.mnuFindCode, Me.mnuFindSibu, Me.mnuFindTel, Me.mnuFindPc, Me.mnuFindSn, Me.mnuSep3, Me.mnuFindAll})

        Me.mnuMnt = New ToolStripMenuItem("メンテナンス(&M)")
        Me.mnuMntList = New ToolStripMenuItem("全メンテナンス記録一覧(&L)")
        Me.mnuMntFind = New ToolStripMenuItem("メンテナンス記録 全文検索(&F)")
        Me.mnuSepMnt = New ToolStripSeparator()
        Me.mnuMntAdd = New ToolStripMenuItem("メンテナンス記録の追加(&A)")
        Me.mnuMntEdit = New ToolStripMenuItem("メンテナンス記録の編集(&E)")
        Me.mnuMntMark = New ToolStripMenuItem("キーワード強調検索(&K)")
        Me.mnuMnt.DropDownItems.AddRange(New ToolStripItem() {Me.mnuMntList, Me.mnuMntFind, Me.mnuSepMnt, Me.mnuMntAdd, Me.mnuMntEdit, Me.mnuMntMark})

        Me.mnuOpt = New ToolStripMenuItem("設定(&O)")
        Me.mnuOptAll = New ToolStripMenuItem("環境設定(&O)...")
        Me.mnuOptBrowser = New ToolStripMenuItem("ブラウザ設定(&B)...")
        Me.mnuOpt.DropDownItems.AddRange(New ToolStripItem() {Me.mnuOptAll, Me.mnuOptBrowser})

        Me.mnuPrt = New ToolStripMenuItem("印刷(&P)")
        Me.mnuPrtList = New ToolStripMenuItem("印刷リストの印刷(&P)...")
        Me.mnuPrtEnv1 = New ToolStripMenuItem("封筒宛名印刷 1F [横](&1)...")
        Me.mnuPrtEnv2 = New ToolStripMenuItem("封筒宛名印刷 2F [縦](&2)...")
        Me.mnuSepPrt1 = New ToolStripSeparator()
        Me.mnuPrtMntUsr = New ToolStripMenuItem("表示中ユーザーのカルテ・メンテ記録印刷(&M)...")
        Me.mnuSepPrt2 = New ToolStripSeparator()
        Me.mnuVupLabel = New ToolStripMenuItem("バージョンアップ用ラベル印刷・佐川CSV出力(&V)...")
        Me.mnuPrt.DropDownItems.AddRange(New ToolStripItem() {Me.mnuPrtList, Me.mnuPrtEnv1, Me.mnuPrtEnv2, Me.mnuSepPrt1, Me.mnuPrtMntUsr, Me.mnuSepPrt2, Me.mnuVupLabel})

        Me.MenuStrip1.Items.AddRange(New ToolStripItem() {Me.mnuFile, Me.mnuView, Me.mnuSearch, Me.mnuMnt, Me.mnuPrt, Me.mnuOpt})

        ' --- Top Toolbar Panel ---
        Me.pnlTopBar = New Panel() With {.Size = New Size(1220, 40), .Dock = DockStyle.Top, .BackColor = System.Drawing.Color.FromArgb(235, 240, 248)}
        Me.btnFindName = New Button() With {.Text = "名前(F1)", .Location = New Point(8, 6), .Size = New Size(72, 28), .UseVisualStyleBackColor = True}
        Me.btnFindCode = New Button() With {.Text = "コード(F2)", .Location = New Point(82, 6), .Size = New Size(72, 28), .UseVisualStyleBackColor = True}
        Me.btnFindSibu = New Button() With {.Text = "支部(F3)", .Location = New Point(156, 6), .Size = New Size(72, 28), .UseVisualStyleBackColor = True}
        Me.btnFindTel = New Button() With {.Text = "電話(F4)", .Location = New Point(230, 6), .Size = New Size(72, 28), .UseVisualStyleBackColor = True}
        Me.btnFindPc = New Button() With {.Text = "型名(F5)", .Location = New Point(304, 6), .Size = New Size(72, 28), .UseVisualStyleBackColor = True}
        Me.btnFindSn = New Button() With {.Text = "S/N(F6)", .Location = New Point(378, 6), .Size = New Size(72, 28), .UseVisualStyleBackColor = True}
        Me.btnShowAll = New Button() With {.Text = "全件表示", .Location = New Point(452, 6), .Size = New Size(72, 28), .UseVisualStyleBackColor = True}
        Me.btnMntFind = New Button() With {.Text = "メンテ検索", .Location = New Point(530, 6), .Size = New Size(82, 28), .UseVisualStyleBackColor = True}
        Me.btnMntList = New Button() With {.Text = "全メンテ", .Location = New Point(614, 6), .Size = New Size(74, 28), .UseVisualStyleBackColor = True}

        Me.lblRrkTitle = New Label() With {.Text = "履歴:", .AutoSize = True, .Location = New Point(694, 13)}
        Me.cmbRrk = New ComboBox() With {.Location = New Point(732, 8), .Size = New Size(328, 24), .DropDownStyle = ComboBoxStyle.DropDownList, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}
        Me.lblModeBadge = New Label() With {.Text = "ネットワーク接続", .Location = New Point(1068, 7), .Size = New Size(144, 26), .TextAlign = ContentAlignment.MiddleCenter, .Font = boldFont, .BackColor = Color.FromArgb(210, 240, 210), .ForeColor = Color.DarkGreen, .BorderStyle = BorderStyle.FixedSingle, .Anchor = AnchorStyles.Top Or AnchorStyles.Right}

        Me.pnlTopBar.Controls.AddRange(New Control() {Me.btnFindName, Me.btnFindCode, Me.btnFindSibu, Me.btnFindTel, Me.btnFindPc, Me.btnFindSn, Me.btnShowAll, Me.btnMntFind, Me.btnMntList, Me.lblRrkTitle, Me.cmbRrk, Me.lblModeBadge})

        ' --- StatusStrip ---
        Me.StatusStrip1 = New StatusStrip()
        Me.stlSearchCond = New ToolStripStatusLabel("検索条件: すべて") With {.Width = 260, .AutoSize = False, .TextAlign = ContentAlignment.MiddleLeft, .BorderSides = ToolStripStatusLabelBorderSides.Right}
        Me.stlRecCount = New ToolStripStatusLabel("対象件数：0件") With {.Width = 140, .AutoSize = False, .TextAlign = ContentAlignment.MiddleLeft, .BorderSides = ToolStripStatusLabelBorderSides.Right}
        Me.stlDspMode = New ToolStripStatusLabel("[通常データ:表示する]") With {.Spring = True, .TextAlign = ContentAlignment.MiddleLeft, .BorderSides = ToolStripStatusLabelBorderSides.Right}
        Me.stlPcName = New ToolStripStatusLabel("") With {.Width = 160, .AutoSize = False, .TextAlign = ContentAlignment.MiddleCenter}
        Me.StatusStrip1.Items.AddRange(New ToolStripItem() {Me.stlSearchCond, Me.stlRecCount, Me.stlDspMode, Me.stlPcName})

        ' --- SplitContainers (Panel1 = Left [User Detail], Panel2 = Right [User Grid + Print List]) ---
        Me.splitMain = New SplitContainer() With {.Size = New Size(1220, 710), .Dock = DockStyle.Fill, .Orientation = Orientation.Vertical, .SplitterDistance = 600, .SplitterWidth = 6}
        Me.splitRight = New SplitContainer() With {.Size = New Size(614, 710), .Dock = DockStyle.Fill, .Orientation = Orientation.Horizontal, .SplitterDistance = 460, .SplitterWidth = 6}
        Me.splitMain.Panel2.Controls.Add(Me.splitRight)

        ' --- Right Upper: User Grid ---
        Me.pnlUsrGridTop = New Panel() With {.Dock = DockStyle.Top, .Height = 24, .BackColor = Color.FromArgb(60, 90, 140)}
        Me.lblUsrGridHeader = New Label() With {.Text = " ユーザー一覧", .ForeColor = Color.White, .Font = boldFont, .Dock = DockStyle.Fill, .TextAlign = ContentAlignment.MiddleLeft}
        Me.pnlUsrGridTop.Controls.Add(Me.lblUsrGridHeader)

        Me.dgvUsr = New DataGridView() With {
            .Dock = DockStyle.Fill,
            .ReadOnly = True,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .AllowUserToResizeRows = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .MultiSelect = False,
            .RowHeadersVisible = False,
            .BackgroundColor = Color.White,
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        }
        Me.splitRight.Panel1.Controls.Add(Me.dgvUsr)
        Me.splitRight.Panel1.Controls.Add(Me.pnlUsrGridTop)

        ' --- Right Lower: Print List ---
        Me.pnlPrtTop = New Panel() With {.Dock = DockStyle.Top, .Height = 32, .BackColor = Color.FromArgb(225, 230, 238)}
        Me.lblPrtHeader = New Label() With {.Text = "印刷リスト", .Font = boldFont, .Location = New Point(6, 8), .AutoSize = True}
        Me.btnPrtAdd = New Button() With {.Text = "追加", .Location = New Point(98, 3), .Size = New Size(52, 25), .UseVisualStyleBackColor = True}
        Me.btnPrtDel = New Button() With {.Text = "削除", .Location = New Point(153, 3), .Size = New Size(52, 25), .UseVisualStyleBackColor = True}
        Me.btnPrtAllDel = New Button() With {.Text = "全削除", .Location = New Point(208, 3), .Size = New Size(58, 25), .UseVisualStyleBackColor = True}
        Me.btnPrtExec = New Button() With {.Text = "印刷", .Font = boldFont, .Location = New Point(272, 3), .Size = New Size(56, 25), .UseVisualStyleBackColor = True}
        Me.btnPrt1F = New Button() With {.Text = "1F封筒", .Location = New Point(331, 3), .Size = New Size(58, 25), .UseVisualStyleBackColor = True}
        Me.btnPrt2F = New Button() With {.Text = "2F封筒", .Location = New Point(392, 3), .Size = New Size(58, 25), .UseVisualStyleBackColor = True}
        Me.btnPrtOpt = New Button() With {.Text = "印刷設定", .Location = New Point(453, 3), .Size = New Size(68, 25), .UseVisualStyleBackColor = True}
        Me.pnlPrtTop.Controls.AddRange(New Control() {Me.lblPrtHeader, Me.btnPrtAdd, Me.btnPrtDel, Me.btnPrtAllDel, Me.btnPrtExec, Me.btnPrt1F, Me.btnPrt2F, Me.btnPrtOpt})

        Me.dgvPrt = New DataGridView() With {
            .Dock = DockStyle.Fill,
            .ReadOnly = True,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .AllowUserToResizeRows = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .MultiSelect = False,
            .RowHeadersVisible = False,
            .BackgroundColor = Color.White
        }
        Me.splitRight.Panel2.Controls.Add(Me.dgvPrt)
        Me.splitRight.Panel2.Controls.Add(Me.pnlPrtTop)

        ' --- Left Panel: User Detail Header (Matches original VB6 PicPnl1 layout) ---
        Me.pnlRightHeader = New Panel() With {.Size = New Size(600, 178), .Dock = DockStyle.Top, .BackColor = SystemColors.Control}

        ' Left Column: コード, Ver, 支部名, コピー, 施術所, 柔整師, TEL
        Me.lblCodeTitle = New Label() With {.Text = "コード", .Location = New Point(8, 7), .Size = New Size(62, 18), .TextAlign = ContentAlignment.MiddleRight}
        Me.txtCode = New TextBox() With {.Location = New Point(75, 4), .Size = New Size(76, 22), .ReadOnly = True, .BackColor = Color.White, .Font = boldFont}

        Me.lblVerTitle = New Label() With {.Text = "Ver", .Location = New Point(154, 7), .Size = New Size(30, 18), .TextAlign = ContentAlignment.MiddleRight}
        Me.txtVer = New TextBox() With {.Location = New Point(188, 4), .Size = New Size(220, 22), .ReadOnly = True, .BackColor = Color.White}

        Me.lblSibuTitle = New Label() With {.Text = "支部名", .Location = New Point(8, 32), .Size = New Size(62, 20), .TextAlign = ContentAlignment.MiddleRight}
        Me.txtSibu = New TextBox() With {.Location = New Point(75, 28), .Size = New Size(118, 25), .ReadOnly = True, .BackColor = Color.White, .Font = sibuFont}
        Me.btnCopyBracket = New Button() With {.Text = "コピー", .Location = New Point(198, 28), .Size = New Size(88, 25), .UseVisualStyleBackColor = True}

        Me.lblSjTitle = New Label() With {.Text = "施術所", .Location = New Point(8, 66), .Size = New Size(62, 22), .TextAlign = ContentAlignment.MiddleRight}
        Me.txtSjNameF = New TextBox() With {.Location = New Point(75, 55), .Size = New Size(225, 19), .ReadOnly = True, .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle}
        Me.txtSjName = New TextBox() With {.Location = New Point(75, 73), .Size = New Size(225, 27), .ReadOnly = True, .BackColor = Color.White, .Font = sjFont, .BorderStyle = BorderStyle.FixedSingle}

        Me.lblJsTitle = New Label() With {.Text = "柔整師", .Location = New Point(8, 114), .Size = New Size(62, 22), .TextAlign = ContentAlignment.MiddleRight}
        Me.txtJsNameF = New TextBox() With {.Location = New Point(75, 102), .Size = New Size(225, 19), .ReadOnly = True, .BackColor = Color.White, .BorderStyle = BorderStyle.FixedSingle}
        Me.txtJsName = New TextBox() With {.Location = New Point(75, 120), .Size = New Size(225, 25), .ReadOnly = True, .BackColor = Color.White, .Font = jsFont, .BorderStyle = BorderStyle.FixedSingle}

        Me.lblTelTitle = New Label() With {.Text = "TEL", .Location = New Point(8, 152), .Size = New Size(62, 22), .TextAlign = ContentAlignment.MiddleRight}
        Me.txtTel = New TextBox() With {.Location = New Point(75, 147), .Size = New Size(225, 28), .ReadOnly = True, .BackColor = Color.White, .ForeColor = Color.FromArgb(192, 0, 0), .Font = telFont}

        ' Middle Column (X = 310): Vertically stacked IME, InputMode, Net, ClickMode, PMemo (Matches VB6 Left=4320 twips)
        Me.lblImeBadge = New Label() With {.Text = "IME:不明", .Location = New Point(310, 28), .Size = New Size(118, 22), .BorderStyle = BorderStyle.FixedSingle, .TextAlign = ContentAlignment.MiddleCenter, .Cursor = Cursors.Hand}
        Me.lblInputBadge = New Label() With {.Text = "入力方式:不明", .Location = New Point(310, 54), .Size = New Size(118, 22), .BorderStyle = BorderStyle.FixedSingle, .TextAlign = ContentAlignment.MiddleCenter, .Cursor = Cursors.Hand}
        Me.lblNetBadge = New Label() With {.Text = "ネット:不明", .Location = New Point(310, 80), .Size = New Size(118, 22), .BorderStyle = BorderStyle.FixedSingle, .TextAlign = ContentAlignment.MiddleCenter, .Cursor = Cursors.Hand}
        Me.lblClickBadge = New Label() With {.Text = "クリックモード:不明", .Location = New Point(310, 106), .Size = New Size(118, 22), .BorderStyle = BorderStyle.FixedSingle, .TextAlign = ContentAlignment.MiddleCenter, .Cursor = Cursors.Hand}
        Me.lblPMemoBadge = New Label() With {.Text = "Pメモ", .Location = New Point(310, 148), .Size = New Size(118, 22), .BorderStyle = BorderStyle.FixedSingle, .TextAlign = ContentAlignment.MiddleCenter, .Cursor = Cursors.Hand}

        ' Right Column (X = 436): Vertically stacked Status Tags (Matches VB6 picTag Left=6000 twips)
        Me.flpTags = New FlowLayoutPanel() With {
            .Location = New Point(436, 4),
            .Size = New Size(158, 170),
            .FlowDirection = FlowDirection.TopDown,
            .WrapContents = False
        }

        Me.pnlRightHeader.Controls.AddRange(New Control() {
            Me.lblCodeTitle, Me.txtCode, Me.lblVerTitle, Me.txtVer,
            Me.lblSibuTitle, Me.txtSibu, Me.btnCopyBracket,
            Me.lblSjTitle, Me.txtSjNameF, Me.txtSjName,
            Me.lblJsTitle, Me.txtJsNameF, Me.txtJsName,
            Me.lblTelTitle, Me.txtTel,
            Me.lblImeBadge, Me.lblInputBadge, Me.lblNetBadge, Me.lblClickBadge, Me.lblPMemoBadge,
            Me.flpTags
        })

        ' --- TabControl (5 Tabs) ---
        Me.tabDetail = New TabControl() With {.Size = New Size(600, 532), .Dock = DockStyle.Fill}
        Me.tabSinryou = New TabPage("住所・診療時間") With {.Size = New Size(592, 506), .UseVisualStyleBackColor = True}
        Me.tabKisyu = New TabPage("使用機種") With {.Size = New Size(592, 506), .UseVisualStyleBackColor = True}
        Me.tabJitaku = New TabPage("自宅") With {.Size = New Size(592, 506), .UseVisualStyleBackColor = True}
        Me.tabMnt = New TabPage("メンテナンス") With {.Size = New Size(592, 506), .UseVisualStyleBackColor = True}
        Me.tabMemoMap = New TabPage("メモ・地図") With {.Size = New Size(592, 506), .UseVisualStyleBackColor = True}
        Me.tabDetail.TabPages.AddRange(New TabPage() {Me.tabSinryou, Me.tabKisyu, Me.tabJitaku, Me.tabMnt, Me.tabMemoMap})

        ' === Tab 1: 住所・診療時間 ===
        Me.lblAddTitle = New Label() With {.Text = "住所", .Location = New Point(10, 14), .Size = New Size(58, 18)}
        Me.txtAdd = New TextBox() With {.Location = New Point(72, 10), .Size = New Size(395, 58), .Multiline = True, .ReadOnly = True, .BackColor = Color.White, .ScrollBars = ScrollBars.Vertical, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}
        Me.btnGoogleMap = New Button() With {.Text = "GoogleMap", .Location = New Point(475, 10), .Size = New Size(105, 28), .UseVisualStyleBackColor = True, .Anchor = AnchorStyles.Top Or AnchorStyles.Right}
        Me.btnGmapLink1 = New Button() With {.Text = "1", .Location = New Point(475, 42), .Size = New Size(32, 25), .UseVisualStyleBackColor = True, .Visible = False, .Anchor = AnchorStyles.Top Or AnchorStyles.Right}
        Me.btnGmapLink2 = New Button() With {.Text = "2", .Location = New Point(511, 42), .Size = New Size(32, 25), .UseVisualStyleBackColor = True, .Visible = False, .Anchor = AnchorStyles.Top Or AnchorStyles.Right}
        Me.btnGmapLink3 = New Button() With {.Text = "3", .Location = New Point(547, 42), .Size = New Size(32, 25), .UseVisualStyleBackColor = True, .Visible = False, .Anchor = AnchorStyles.Top Or AnchorStyles.Right}

        Me.lblSinryouTitle = New Label() With {.Text = "診療時間", .Location = New Point(10, 78), .Size = New Size(58, 18)}
        Me.txtSinryou = New TextBox() With {.Location = New Point(72, 74), .Size = New Size(509, 44), .Multiline = True, .ReadOnly = True, .BackColor = Color.White, .ScrollBars = ScrollBars.Vertical, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblBikouTitle = New Label() With {.Text = "備考", .Location = New Point(10, 128), .Size = New Size(58, 18)}
        Me.txtMemo = New TextBox() With {.Location = New Point(72, 124), .Size = New Size(509, 100), .Multiline = True, .ReadOnly = True, .BackColor = Color.White, .ScrollBars = ScrollBars.Vertical, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblShareMemoTitle = New Label() With {.Text = "メモ", .Location = New Point(10, 234), .Size = New Size(58, 18)}
        Me.btnEditMemoTab1 = New Button() With {.Text = "編集", .Location = New Point(8, 256), .Size = New Size(58, 24), .UseVisualStyleBackColor = True}
        Me.txtMemo2 = New TextBox() With {.Location = New Point(72, 230), .Size = New Size(509, 100), .Multiline = True, .ReadOnly = True, .BackColor = Color.White, .ScrollBars = ScrollBars.Vertical, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblRecentMntTitle = New Label() With {.Text = "最近の記録", .Location = New Point(6, 340), .Size = New Size(64, 18)}
        Me.lstMntLog = New ListBox() With {.Location = New Point(72, 336), .Size = New Size(509, 160), .HorizontalScrollbar = True, .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.tabSinryou.Controls.AddRange(New Control() {
            Me.lblAddTitle, Me.txtAdd, Me.btnGoogleMap, Me.btnGmapLink1, Me.btnGmapLink2, Me.btnGmapLink3,
            Me.lblSinryouTitle, Me.txtSinryou,
            Me.lblBikouTitle, Me.txtMemo,
            Me.lblShareMemoTitle, Me.btnEditMemoTab1, Me.txtMemo2,
            Me.lblRecentMntTitle, Me.lstMntLog
        })

        ' === Tab 2: 使用機種 ===
        Me.btnCopyKisyu = New Button() With {.Text = "機種情報コピー", .Location = New Point(12, 10), .Size = New Size(120, 26), .UseVisualStyleBackColor = True}

        Me.lblPcTitle = New Label() With {.Text = "本体", .Location = New Point(12, 46), .Size = New Size(72, 18)}
        Me.txtPc0 = New TextBox() With {.Location = New Point(90, 42), .Size = New Size(230, 23), .ReadOnly = True, .BackColor = Color.White}
        Me.txtPc1 = New TextBox() With {.Location = New Point(326, 42), .Size = New Size(253, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblPrtTitle = New Label() With {.Text = "プリンタ", .Location = New Point(12, 74), .Size = New Size(72, 18)}
        Me.txtPrt0 = New TextBox() With {.Location = New Point(90, 70), .Size = New Size(230, 23), .ReadOnly = True, .BackColor = Color.White}
        Me.txtPrt1 = New TextBox() With {.Location = New Point(326, 70), .Size = New Size(253, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblMnTitle = New Label() With {.Text = "モニタ", .Location = New Point(12, 102), .Size = New Size(72, 18)}
        Me.txtMn0 = New TextBox() With {.Location = New Point(90, 98), .Size = New Size(230, 23), .ReadOnly = True, .BackColor = Color.White}
        Me.txtMn1 = New TextBox() With {.Location = New Point(326, 98), .Size = New Size(253, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblBcrTitle = New Label() With {.Text = "BCR", .Location = New Point(12, 130), .Size = New Size(72, 18)}
        Me.txtBcr0 = New TextBox() With {.Location = New Point(90, 126), .Size = New Size(230, 23), .ReadOnly = True, .BackColor = Color.White}
        Me.txtBcr1 = New TextBox() With {.Location = New Point(326, 126), .Size = New Size(253, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblHddTitle = New Label() With {.Text = "BkUp(HDD)", .Location = New Point(12, 158), .Size = New Size(72, 18)}
        Me.txtHdd0 = New TextBox() With {.Location = New Point(90, 154), .Size = New Size(230, 23), .ReadOnly = True, .BackColor = Color.White}
        Me.txtHdd1 = New TextBox() With {.Location = New Point(326, 154), .Size = New Size(253, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblMiniPrtTitle = New Label() With {.Text = "小型プリンタ", .Location = New Point(12, 186), .Size = New Size(76, 18)}
        Me.txtMiniPrt0 = New TextBox() With {.Location = New Point(90, 182), .Size = New Size(230, 23), .ReadOnly = True, .BackColor = Color.White}
        Me.txtMiniPrt1 = New TextBox() With {.Location = New Point(326, 182), .Size = New Size(253, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblNohinTitle = New Label() With {.Text = "納品日", .Location = New Point(12, 222), .Size = New Size(72, 18)}
        Me.txtNohin = New TextBox() With {.Location = New Point(90, 218), .Size = New Size(150, 23), .ReadOnly = True, .BackColor = Color.White}

        Me.lblTantoTitle = New Label() With {.Text = "担当", .Location = New Point(252, 222), .Size = New Size(42, 18)}
        Me.txtTanto = New TextBox() With {.Location = New Point(296, 218), .Size = New Size(283, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblLicenseTitle = New Label() With {.Text = "ライセンス", .Location = New Point(12, 252), .Size = New Size(72, 18)}
        Me.txtLicense = New TextBox() With {.Location = New Point(90, 248), .Size = New Size(489, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblLeaseTitle = New Label() With {.Text = "リース等", .Location = New Point(12, 284), .Size = New Size(72, 18)}
        Me.txtSiharai = New TextBox() With {.Location = New Point(90, 280), .Size = New Size(80, 23), .ReadOnly = True, .BackColor = Color.White}
        Me.txtLeaseCo = New TextBox() With {.Location = New Point(176, 280), .Size = New Size(200, 23), .ReadOnly = True, .BackColor = Color.White}
        Me.txtLeaseStDate = New TextBox() With {.Location = New Point(382, 280), .Size = New Size(197, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}
        Me.txtLease1 = New TextBox() With {.Location = New Point(90, 308), .Size = New Size(240, 23), .ReadOnly = True, .BackColor = Color.White}
        Me.txtLease2 = New TextBox() With {.Location = New Point(336, 308), .Size = New Size(243, 23), .ReadOnly = True, .BackColor = Color.White, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.tabKisyu.Controls.AddRange(New Control() {
            Me.btnCopyKisyu,
            Me.lblPcTitle, Me.txtPc0, Me.txtPc1,
            Me.lblPrtTitle, Me.txtPrt0, Me.txtPrt1,
            Me.lblMnTitle, Me.txtMn0, Me.txtMn1,
            Me.lblBcrTitle, Me.txtBcr0, Me.txtBcr1,
            Me.lblHddTitle, Me.txtHdd0, Me.txtHdd1,
            Me.lblMiniPrtTitle, Me.txtMiniPrt0, Me.txtMiniPrt1,
            Me.lblNohinTitle, Me.txtNohin, Me.lblTantoTitle, Me.txtTanto,
            Me.lblLicenseTitle, Me.txtLicense,
            Me.lblLeaseTitle, Me.txtSiharai, Me.txtLeaseCo, Me.txtLeaseStDate, Me.txtLease1, Me.txtLease2
        })

        ' === Tab 3: 自宅 ===
        Me.lblMhTelTitle = New Label() With {.Text = "自宅電話", .Location = New Point(12, 16), .Size = New Size(72, 18)}
        Me.txtMhTel = New TextBox() With {.Location = New Point(90, 12), .Size = New Size(170, 23), .ReadOnly = True, .BackColor = Color.White}

        Me.lblMbTelTitle = New Label() With {.Text = "携帯番号", .Location = New Point(12, 44), .Size = New Size(72, 18)}
        Me.txtMbTel = New TextBox() With {.Location = New Point(90, 40), .Size = New Size(170, 23), .ReadOnly = True, .BackColor = Color.White}

        Me.lblFaxTitle = New Label() With {.Text = "FAX番号", .Location = New Point(12, 72), .Size = New Size(72, 18)}
        Me.txtFax = New TextBox() With {.Location = New Point(90, 68), .Size = New Size(170, 23), .ReadOnly = True, .BackColor = Color.White}

        Me.lblTelExTitle = New Label() With {.Text = "その他電話", .Location = New Point(272, 16), .Size = New Size(72, 18)}
        Me.btnTelExEdit = New Button() With {.Text = "編集", .Location = New Point(272, 38), .Size = New Size(66, 25), .UseVisualStyleBackColor = True}
        Me.txtTelEx0 = New TextBox() With {.Location = New Point(346, 12), .Size = New Size(115, 22), .ReadOnly = True, .BackColor = Color.White}
        Me.txtTelEx1 = New TextBox() With {.Location = New Point(465, 12), .Size = New Size(115, 22), .ReadOnly = True, .BackColor = Color.White}
        Me.txtTelEx2 = New TextBox() With {.Location = New Point(346, 38), .Size = New Size(115, 22), .ReadOnly = True, .BackColor = Color.White}
        Me.txtTelEx3 = New TextBox() With {.Location = New Point(465, 38), .Size = New Size(115, 22), .ReadOnly = True, .BackColor = Color.White}
        Me.txtTelEx4 = New TextBox() With {.Location = New Point(346, 64), .Size = New Size(115, 22), .ReadOnly = True, .BackColor = Color.White}

        Me.lblMhAddTitle = New Label() With {.Text = "自宅住所", .Location = New Point(12, 104), .Size = New Size(72, 18)}
        Me.txtMhAdd = New TextBox() With {.Location = New Point(90, 100), .Size = New Size(489, 54), .Multiline = True, .ReadOnly = True, .BackColor = Color.White, .ScrollBars = ScrollBars.Vertical, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblVupAddTitle = New Label() With {.Text = "Vup送付先", .Location = New Point(12, 168), .Size = New Size(76, 18), .Visible = False}
        Me.txtVupAdd = New TextBox() With {.Location = New Point(90, 164), .Size = New Size(489, 68), .Multiline = True, .ReadOnly = True, .BackColor = Color.FromArgb(250, 244, 226), .ScrollBars = ScrollBars.Vertical, .Visible = False, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.lblPcAddTitle = New Label() With {.Text = "機械設置場所", .Location = New Point(12, 244), .Size = New Size(78, 18), .Visible = False}
        Me.txtPcAdd = New TextBox() With {.Location = New Point(90, 240), .Size = New Size(489, 68), .Multiline = True, .ReadOnly = True, .BackColor = Color.FromArgb(250, 244, 226), .ScrollBars = ScrollBars.Vertical, .Visible = False, .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right}

        Me.tabJitaku.Controls.AddRange(New Control() {
            Me.lblMhTelTitle, Me.txtMhTel, Me.lblMbTelTitle, Me.txtMbTel, Me.lblFaxTitle, Me.txtFax,
            Me.lblTelExTitle, Me.btnTelExEdit, Me.txtTelEx0, Me.txtTelEx1, Me.txtTelEx2, Me.txtTelEx3, Me.txtTelEx4,
            Me.lblMhAddTitle, Me.txtMhAdd,
            Me.lblVupAddTitle, Me.txtVupAdd,
            Me.lblPcAddTitle, Me.txtPcAdd
        })

        ' === Tab 4: メンテナンス ===
        Me.pnlMntTop = New Panel() With {.Size = New Size(592, 60), .Dock = DockStyle.Top, .Height = 60, .BackColor = Color.FromArgb(235, 240, 248)}
        Me.rdoMntSortSagyou = New RadioButton() With {.Text = "作業日順", .Location = New Point(10, 6), .Size = New Size(82, 20), .Checked = True}
        Me.rdoMntSortKijitsu = New RadioButton() With {.Text = "期日順", .Location = New Point(96, 6), .Size = New Size(72, 20)}
        Me.chkMntKanryou = New CheckBox() With {.Text = "完了分も表示", .Location = New Point(178, 6), .Size = New Size(106, 20), .Checked = True}
        Me.chkMntAutoScroll = New CheckBox() With {.Text = "最新行へ自動スクロール", .Location = New Point(290, 6), .Size = New Size(160, 20), .Checked = True}
        Me.lblMntCount = New Label() With {.Text = "0件", .Location = New Point(460, 8), .AutoSize = True, .Font = boldFont}

        Me.btnMntAdd = New Button() With {.Text = "新規追加(&A)", .Location = New Point(6, 30), .Size = New Size(84, 26), .UseVisualStyleBackColor = True}
        Me.btnMntEdit = New Button() With {.Text = "編集(&E)", .Location = New Point(93, 30), .Size = New Size(68, 26), .UseVisualStyleBackColor = True}
        Me.btnMntMark = New Button() With {.Text = "強調検索", .Location = New Point(164, 30), .Size = New Size(74, 26), .UseVisualStyleBackColor = True}
        Me.btnMntFindTab = New Button() With {.Text = "全文検索", .Location = New Point(241, 30), .Size = New Size(74, 26), .UseVisualStyleBackColor = True}
        Me.btnMntListTab = New Button() With {.Text = "全件一覧", .Location = New Point(318, 30), .Size = New Size(74, 26), .UseVisualStyleBackColor = True}
        Me.btnMntPrt = New Button() With {.Text = "印刷(&P)", .Location = New Point(395, 30), .Size = New Size(72, 26), .UseVisualStyleBackColor = True}
        Me.btnMntOpt = New Button() With {.Text = "設定(&O)", .Location = New Point(470, 30), .Size = New Size(72, 26), .UseVisualStyleBackColor = True}

        Me.pnlMntTop.Controls.AddRange(New Control() {
            Me.rdoMntSortSagyou, Me.rdoMntSortKijitsu, Me.chkMntKanryou, Me.chkMntAutoScroll, Me.lblMntCount,
            Me.btnMntAdd, Me.btnMntEdit, Me.btnMntMark, Me.btnMntFindTab, Me.btnMntListTab, Me.btnMntPrt, Me.btnMntOpt
        })

        Me.splitMnt = New SplitContainer() With {.Size = New Size(592, 446), .Dock = DockStyle.Fill, .Orientation = Orientation.Horizontal, .SplitterDistance = 290}
        Me.dgvMntUsr = New DataGridView() With {
            .Dock = DockStyle.Fill,
            .ReadOnly = True,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .MultiSelect = False,
            .RowHeadersVisible = False,
            .BackgroundColor = Color.White
        }
        Me.txtMntSelectedContent = New TextBox() With {
            .Dock = DockStyle.Fill,
            .Multiline = True,
            .ReadOnly = True,
            .BackColor = Color.FromArgb(255, 255, 245),
            .ScrollBars = ScrollBars.Vertical,
            .Font = defaultFont
        }
        Me.splitMnt.Panel1.Controls.Add(Me.dgvMntUsr)
        Me.splitMnt.Panel2.Controls.Add(Me.txtMntSelectedContent)
        Me.tabMnt.Controls.Add(Me.splitMnt)
        Me.tabMnt.Controls.Add(Me.pnlMntTop)

        ' === Tab 5: メモ・地図 ===
        Me.splitMemoMap = New SplitContainer() With {.Size = New Size(592, 506), .Dock = DockStyle.Fill, .Orientation = Orientation.Horizontal, .SplitterDistance = 158}
        Me.splitMemoMap.Panel1.Size = New Size(592, 158)
        Me.lblTabMemoTitle = New Label() With {.Text = "共有メモ (mnt.mdb):", .Location = New Point(8, 8), .AutoSize = True}
        Me.btnEditMemo = New Button() With {.Text = "メモ編集", .Location = New Point(198, 3), .Size = New Size(90, 24), .UseVisualStyleBackColor = True}
        Me.txtPmemo = New TextBox() With {.Location = New Point(8, 30), .Size = New Size(280, 120), .Multiline = True, .ReadOnly = True, .BackColor = Color.White, .ScrollBars = ScrollBars.Vertical, .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left}
        Me.lblPcPMemoTitle = New Label() With {.Text = "Pメモ (このPC専用):", .Location = New Point(296, 8), .AutoSize = True}
        Me.btnEditPMemo = New Button() With {.Text = "Pメモ編集", .Location = New Point(492, 3), .Size = New Size(90, 24), .UseVisualStyleBackColor = True, .Anchor = AnchorStyles.Top Or AnchorStyles.Right}
        Me.txtPcPMemo = New TextBox() With {.Location = New Point(296, 30), .Size = New Size(286, 120), .Multiline = True, .ReadOnly = True, .BackColor = Color.FromArgb(240, 255, 245), .ScrollBars = ScrollBars.Vertical, .Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right}
        Me.splitMemoMap.Panel1.Controls.AddRange(New Control() {Me.lblTabMemoTitle, Me.btnEditMemo, Me.txtPmemo, Me.lblPcPMemoTitle, Me.btnEditPMemo, Me.txtPcPMemo})

        Me.pnlMapToolbar = New Panel() With {.Dock = DockStyle.Top, .Height = 32, .BackColor = Color.FromArgb(235, 240, 248)}
        Me.btnDispMap = New Button() With {.Text = "地図の表示 (外部ビューア)", .Location = New Point(8, 3), .Size = New Size(170, 25), .UseVisualStyleBackColor = True}
        Me.lblMapStatus = New Label() With {.Text = "地図画像: なし", .Location = New Point(188, 8), .AutoSize = True}
        Me.pnlMapToolbar.Controls.AddRange(New Control() {Me.btnDispMap, Me.lblMapStatus})

        Me.picMap = New PictureBox() With {.Dock = DockStyle.Fill, .SizeMode = PictureBoxSizeMode.Zoom, .BackColor = Color.White}
        Me.splitMemoMap.Panel2.Controls.Add(Me.picMap)
        Me.splitMemoMap.Panel2.Controls.Add(Me.pnlMapToolbar)
        Me.tabMemoMap.Controls.Add(Me.splitMemoMap)

        Me.splitMain.Panel1.Controls.Add(Me.tabDetail)
        Me.splitMain.Panel1.Controls.Add(Me.pnlRightHeader)

        ' --- Timer ---
        Me.tmrRrk = New Timer(Me.components) With {.Interval = 1200, .Enabled = False}

        ' --- Form Setup ---
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1220, 780)
        Me.MinimumSize = New System.Drawing.Size(980, 680)
        Me.Controls.Add(Me.splitMain)
        Me.Controls.Add(Me.pnlTopBar)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = defaultFont
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmMain"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Text = "ユーザー検索 (UsrDspNet)"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
