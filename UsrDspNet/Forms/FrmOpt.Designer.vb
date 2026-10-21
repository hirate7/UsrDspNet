<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOpt
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
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
    Public WithEvents tbsOpt As System.Windows.Forms.TabControl
    Public WithEvents tabMain As System.Windows.Forms.TabPage
    Public WithEvents tabMntUsr As System.Windows.Forms.TabPage
    Public WithEvents tabMnt As System.Windows.Forms.TabPage
    Public WithEvents tabPrt As System.Windows.Forms.TabPage
    Public WithEvents tabMntUsrPrt As System.Windows.Forms.TabPage
    Public WithEvents tabBrowser As System.Windows.Forms.TabPage

    ' Tab 1: 全般・DB
    Public WithEvents grpDb As System.Windows.Forms.GroupBox
    Public WithEvents lblLcMpl As System.Windows.Forms.Label
    Public WithEvents TxtLcMplMdb As System.Windows.Forms.TextBox
    Public WithEvents lblNtMpl As System.Windows.Forms.Label
    Public WithEvents TxtNtMplMdb As System.Windows.Forms.TextBox
    Public WithEvents lblNtMnt As System.Windows.Forms.Label
    Public WithEvents TxtNtMntMdb As System.Windows.Forms.TextBox
    Public WithEvents lblLcPrt As System.Windows.Forms.Label
    Public WithEvents TxtLcPrtMdb As System.Windows.Forms.TextBox
    Public WithEvents chkAutoCopyMntMdb As System.Windows.Forms.CheckBox

    ' Tab 2: メンテ(ユーザー別)
    Public WithEvents grpUsrSort As System.Windows.Forms.GroupBox
    Public WithEvents OptUsrSagyou As System.Windows.Forms.RadioButton
    Public WithEvents OptUsrKijitsu As System.Windows.Forms.RadioButton
    Public WithEvents grpUsrBunrui As System.Windows.Forms.GroupBox
    Public WithEvents OptUsrBunrui0 As System.Windows.Forms.RadioButton
    Public WithEvents OptUsrBunrui1 As System.Windows.Forms.RadioButton
    Public WithEvents OptUsrBunrui2 As System.Windows.Forms.RadioButton
    Public WithEvents ChkUsrAutoScroll As System.Windows.Forms.CheckBox
    Public WithEvents ChkUsrKanryou As System.Windows.Forms.CheckBox
    Public WithEvents lblUsrKijitsu As System.Windows.Forms.Label
    Public WithEvents TxtUsrKijitsuSt As System.Windows.Forms.TextBox
    Public WithEvents lblUsrKijitsuWave As System.Windows.Forms.Label
    Public WithEvents TxtUsrKijitsuEd As System.Windows.Forms.TextBox

    ' Tab 3: 全メンテ記録
    Public WithEvents grpMntSort As System.Windows.Forms.GroupBox
    Public WithEvents OptSagyou As System.Windows.Forms.RadioButton
    Public WithEvents OptKijitsu As System.Windows.Forms.RadioButton
    Public WithEvents grpMntBunrui As System.Windows.Forms.GroupBox
    Public WithEvents OptBunrui0 As System.Windows.Forms.RadioButton
    Public WithEvents OptBunrui1 As System.Windows.Forms.RadioButton
    Public WithEvents OptBunrui2 As System.Windows.Forms.RadioButton
    Public WithEvents ChkKanryou As System.Windows.Forms.CheckBox
    Public WithEvents lblMntKijitsu As System.Windows.Forms.Label
    Public WithEvents TxtKijitsuSt As System.Windows.Forms.TextBox
    Public WithEvents lblMntKijitsuWave As System.Windows.Forms.Label
    Public WithEvents TxtKijitsuEd As System.Windows.Forms.TextBox

    ' Tab 4: 印刷設定
    Public WithEvents grpPrtMap As System.Windows.Forms.GroupBox
    Public WithEvents OptMapTrue As System.Windows.Forms.RadioButton
    Public WithEvents OptMapFalse As System.Windows.Forms.RadioButton
    Public WithEvents grpPrtColor As System.Windows.Forms.GroupBox
    Public WithEvents OptMono As System.Windows.Forms.RadioButton
    Public WithEvents OptColor As System.Windows.Forms.RadioButton
    Public WithEvents grpPrtMei As System.Windows.Forms.GroupBox
    Public WithEvents optMei1 As System.Windows.Forms.RadioButton
    Public WithEvents OptMei2 As System.Windows.Forms.RadioButton
    Public WithEvents OptMei4 As System.Windows.Forms.RadioButton

    ' Tab 5: メンテ印刷
    Public WithEvents grpMntUsrPrt As System.Windows.Forms.GroupBox
    Public WithEvents lblPrtRange1 As System.Windows.Forms.Label
    Public WithEvents numMntUsrPrtRangeN As System.Windows.Forms.NumericUpDown
    Public WithEvents lblPrtRange2 As System.Windows.Forms.Label
    Public WithEvents lblPrtMaxLine1 As System.Windows.Forms.Label
    Public WithEvents numMntUsrPrtMaxLine As System.Windows.Forms.NumericUpDown
    Public WithEvents lblPrtMaxLine2 As System.Windows.Forms.Label

    ' Tab 6: ブラウザ設定
    Public WithEvents grpBrowser As System.Windows.Forms.GroupBox
    Public WithEvents lblBrowserPath As System.Windows.Forms.Label
    Public WithEvents txtBrouserPath As System.Windows.Forms.TextBox
    Public WithEvents cmdBrowserRef As System.Windows.Forms.Button
    Public WithEvents btnBrowserDefault As System.Windows.Forms.Button
    Public WithEvents btnBrowserEdge As System.Windows.Forms.Button
    Public WithEvents btnBrowserChrome As System.Windows.Forms.Button
    Public WithEvents btnBrowserFirefox As System.Windows.Forms.Button

    ' Bottom Buttons
    Public WithEvents cmdOK As System.Windows.Forms.Button
    Public WithEvents cmdCancel As System.Windows.Forms.Button
    Public WithEvents cmdApply As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tbsOpt = New System.Windows.Forms.TabControl()
        Me.tabMain = New System.Windows.Forms.TabPage()
        Me.tabMntUsr = New System.Windows.Forms.TabPage()
        Me.tabMnt = New System.Windows.Forms.TabPage()
        Me.tabPrt = New System.Windows.Forms.TabPage()
        Me.tabMntUsrPrt = New System.Windows.Forms.TabPage()
        Me.tabBrowser = New System.Windows.Forms.TabPage()

        Me.grpDb = New System.Windows.Forms.GroupBox()
        Me.lblLcMpl = New System.Windows.Forms.Label()
        Me.TxtLcMplMdb = New System.Windows.Forms.TextBox()
        Me.lblNtMpl = New System.Windows.Forms.Label()
        Me.TxtNtMplMdb = New System.Windows.Forms.TextBox()
        Me.lblNtMnt = New System.Windows.Forms.Label()
        Me.TxtNtMntMdb = New System.Windows.Forms.TextBox()
        Me.lblLcPrt = New System.Windows.Forms.Label()
        Me.TxtLcPrtMdb = New System.Windows.Forms.TextBox()
        Me.chkAutoCopyMntMdb = New System.Windows.Forms.CheckBox()

        Me.grpUsrSort = New System.Windows.Forms.GroupBox()
        Me.OptUsrSagyou = New System.Windows.Forms.RadioButton()
        Me.OptUsrKijitsu = New System.Windows.Forms.RadioButton()
        Me.grpUsrBunrui = New System.Windows.Forms.GroupBox()
        Me.OptUsrBunrui0 = New System.Windows.Forms.RadioButton()
        Me.OptUsrBunrui1 = New System.Windows.Forms.RadioButton()
        Me.OptUsrBunrui2 = New System.Windows.Forms.RadioButton()
        Me.ChkUsrAutoScroll = New System.Windows.Forms.CheckBox()
        Me.ChkUsrKanryou = New System.Windows.Forms.CheckBox()
        Me.lblUsrKijitsu = New System.Windows.Forms.Label()
        Me.TxtUsrKijitsuSt = New System.Windows.Forms.TextBox()
        Me.lblUsrKijitsuWave = New System.Windows.Forms.Label()
        Me.TxtUsrKijitsuEd = New System.Windows.Forms.TextBox()

        Me.grpMntSort = New System.Windows.Forms.GroupBox()
        Me.OptSagyou = New System.Windows.Forms.RadioButton()
        Me.OptKijitsu = New System.Windows.Forms.RadioButton()
        Me.grpMntBunrui = New System.Windows.Forms.GroupBox()
        Me.OptBunrui0 = New System.Windows.Forms.RadioButton()
        Me.OptBunrui1 = New System.Windows.Forms.RadioButton()
        Me.OptBunrui2 = New System.Windows.Forms.RadioButton()
        Me.ChkKanryou = New System.Windows.Forms.CheckBox()
        Me.lblMntKijitsu = New System.Windows.Forms.Label()
        Me.TxtKijitsuSt = New System.Windows.Forms.TextBox()
        Me.lblMntKijitsuWave = New System.Windows.Forms.Label()
        Me.TxtKijitsuEd = New System.Windows.Forms.TextBox()

        Me.grpPrtMap = New System.Windows.Forms.GroupBox()
        Me.OptMapTrue = New System.Windows.Forms.RadioButton()
        Me.OptMapFalse = New System.Windows.Forms.RadioButton()
        Me.grpPrtColor = New System.Windows.Forms.GroupBox()
        Me.OptMono = New System.Windows.Forms.RadioButton()
        Me.OptColor = New System.Windows.Forms.RadioButton()
        Me.grpPrtMei = New System.Windows.Forms.GroupBox()
        Me.optMei1 = New System.Windows.Forms.RadioButton()
        Me.OptMei2 = New System.Windows.Forms.RadioButton()
        Me.OptMei4 = New System.Windows.Forms.RadioButton()

        Me.grpMntUsrPrt = New System.Windows.Forms.GroupBox()
        Me.lblPrtRange1 = New System.Windows.Forms.Label()
        Me.numMntUsrPrtRangeN = New System.Windows.Forms.NumericUpDown()
        Me.lblPrtRange2 = New System.Windows.Forms.Label()
        Me.lblPrtMaxLine1 = New System.Windows.Forms.Label()
        Me.numMntUsrPrtMaxLine = New System.Windows.Forms.NumericUpDown()
        Me.lblPrtMaxLine2 = New System.Windows.Forms.Label()

        Me.grpBrowser = New System.Windows.Forms.GroupBox()
        Me.lblBrowserPath = New System.Windows.Forms.Label()
        Me.txtBrouserPath = New System.Windows.Forms.TextBox()
        Me.cmdBrowserRef = New System.Windows.Forms.Button()
        Me.btnBrowserDefault = New System.Windows.Forms.Button()
        Me.btnBrowserEdge = New System.Windows.Forms.Button()
        Me.btnBrowserChrome = New System.Windows.Forms.Button()
        Me.btnBrowserFirefox = New System.Windows.Forms.Button()

        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdApply = New System.Windows.Forms.Button()

        Me.tbsOpt.SuspendLayout()
        Me.tabMain.SuspendLayout()
        Me.grpDb.SuspendLayout()
        Me.tabMntUsr.SuspendLayout()
        Me.grpUsrSort.SuspendLayout()
        Me.grpUsrBunrui.SuspendLayout()
        Me.tabMnt.SuspendLayout()
        Me.grpMntSort.SuspendLayout()
        Me.grpMntBunrui.SuspendLayout()
        Me.tabPrt.SuspendLayout()
        Me.grpPrtMap.SuspendLayout()
        Me.grpPrtColor.SuspendLayout()
        Me.grpPrtMei.SuspendLayout()
        Me.tabMntUsrPrt.SuspendLayout()
        Me.grpMntUsrPrt.SuspendLayout()
        CType(Me.numMntUsrPrtRangeN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMntUsrPrtMaxLine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBrowser.SuspendLayout()
        Me.grpBrowser.SuspendLayout()
        Me.SuspendLayout()

        '
        'tbsOpt
        '
        Me.tbsOpt.Controls.Add(Me.tabMain)
        Me.tbsOpt.Controls.Add(Me.tabMntUsr)
        Me.tbsOpt.Controls.Add(Me.tabMnt)
        Me.tbsOpt.Controls.Add(Me.tabPrt)
        Me.tbsOpt.Controls.Add(Me.tabMntUsrPrt)
        Me.tbsOpt.Controls.Add(Me.tabBrowser)
        Me.tbsOpt.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.tbsOpt.Location = New System.Drawing.Point(10, 10)
        Me.tbsOpt.Name = "tbsOpt"
        Me.tbsOpt.SelectedIndex = 0
        Me.tbsOpt.Size = New System.Drawing.Size(580, 340)
        Me.tbsOpt.TabIndex = 0

        '
        'tabMain (全般・DB)
        '
        Me.tabMain.Controls.Add(Me.grpDb)
        Me.tabMain.Controls.Add(Me.chkAutoCopyMntMdb)
        Me.tabMain.Location = New System.Drawing.Point(4, 23)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.Padding = New System.Windows.Forms.Padding(8)
        Me.tabMain.Size = New System.Drawing.Size(572, 313)
        Me.tabMain.TabIndex = 0
        Me.tabMain.Text = "データベース"
        Me.tabMain.UseVisualStyleBackColor = True

        Me.grpDb.Controls.Add(Me.lblLcMpl)
        Me.grpDb.Controls.Add(Me.TxtLcMplMdb)
        Me.grpDb.Controls.Add(Me.lblNtMpl)
        Me.grpDb.Controls.Add(Me.TxtNtMplMdb)
        Me.grpDb.Controls.Add(Me.lblNtMnt)
        Me.grpDb.Controls.Add(Me.TxtNtMntMdb)
        Me.grpDb.Controls.Add(Me.lblLcPrt)
        Me.grpDb.Controls.Add(Me.TxtLcPrtMdb)
        Me.grpDb.Location = New System.Drawing.Point(16, 14)
        Me.grpDb.Name = "grpDb"
        Me.grpDb.Size = New System.Drawing.Size(536, 220)
        Me.grpDb.TabIndex = 0
        Me.grpDb.TabStop = False
        Me.grpDb.Text = "データベースファイルパス"

        Me.lblLcMpl.AutoSize = True
        Me.lblLcMpl.Location = New System.Drawing.Point(16, 26)
        Me.lblLcMpl.Text = "メープル ユーザーデータベース (ローカル):"
        Me.TxtLcMplMdb.Location = New System.Drawing.Point(16, 44)
        Me.TxtLcMplMdb.ReadOnly = True
        Me.TxtLcMplMdb.Size = New System.Drawing.Size(500, 20)

        Me.lblNtMpl.AutoSize = True
        Me.lblNtMpl.Location = New System.Drawing.Point(16, 74)
        Me.lblNtMpl.Text = "メープル ユーザーデータベース (ネットワーク):"
        Me.TxtNtMplMdb.Location = New System.Drawing.Point(16, 92)
        Me.TxtNtMplMdb.ReadOnly = True
        Me.TxtNtMplMdb.Size = New System.Drawing.Size(500, 20)

        Me.lblNtMnt.AutoSize = True
        Me.lblNtMnt.Location = New System.Drawing.Point(16, 122)
        Me.lblNtMnt.Text = "メンテナンス データベース:"
        Me.TxtNtMntMdb.Location = New System.Drawing.Point(16, 140)
        Me.TxtNtMntMdb.ReadOnly = True
        Me.TxtNtMntMdb.Size = New System.Drawing.Size(500, 20)

        Me.lblLcPrt.AutoSize = True
        Me.lblLcPrt.Location = New System.Drawing.Point(16, 170)
        Me.lblLcPrt.Text = "印刷用ワークデータベース:"
        Me.TxtLcPrtMdb.Location = New System.Drawing.Point(16, 188)
        Me.TxtLcPrtMdb.ReadOnly = True
        Me.TxtLcPrtMdb.Size = New System.Drawing.Size(500, 20)

        Me.chkAutoCopyMntMdb.AutoSize = True
        Me.chkAutoCopyMntMdb.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 10.5!, System.Drawing.FontStyle.Bold)
        Me.chkAutoCopyMntMdb.Location = New System.Drawing.Point(24, 252)
        Me.chkAutoCopyMntMdb.Name = "chkAutoCopyMntMdb"
        Me.chkAutoCopyMntMdb.Size = New System.Drawing.Size(260, 18)
        Me.chkAutoCopyMntMdb.TabIndex = 1
        Me.chkAutoCopyMntMdb.Text = "起動時にローカルデータを更新する"
        Me.chkAutoCopyMntMdb.UseVisualStyleBackColor = True

        '
        'tabMntUsr (メンテ(ユーザー別))
        '
        Me.tabMntUsr.Controls.Add(Me.grpUsrSort)
        Me.tabMntUsr.Controls.Add(Me.grpUsrBunrui)
        Me.tabMntUsr.Controls.Add(Me.ChkUsrAutoScroll)
        Me.tabMntUsr.Controls.Add(Me.ChkUsrKanryou)
        Me.tabMntUsr.Controls.Add(Me.lblUsrKijitsu)
        Me.tabMntUsr.Controls.Add(Me.TxtUsrKijitsuSt)
        Me.tabMntUsr.Controls.Add(Me.lblUsrKijitsuWave)
        Me.tabMntUsr.Controls.Add(Me.TxtUsrKijitsuEd)
        Me.tabMntUsr.Location = New System.Drawing.Point(4, 23)
        Me.tabMntUsr.Name = "tabMntUsr"
        Me.tabMntUsr.Padding = New System.Windows.Forms.Padding(8)
        Me.tabMntUsr.Size = New System.Drawing.Size(572, 313)
        Me.tabMntUsr.TabIndex = 1
        Me.tabMntUsr.Text = "メンテ(ユーザー別)"
        Me.tabMntUsr.UseVisualStyleBackColor = True

        Me.grpUsrSort.Controls.Add(Me.OptUsrSagyou)
        Me.grpUsrSort.Controls.Add(Me.OptUsrKijitsu)
        Me.grpUsrSort.Location = New System.Drawing.Point(24, 20)
        Me.grpUsrSort.Size = New System.Drawing.Size(220, 100)
        Me.grpUsrSort.TabStop = False
        Me.grpUsrSort.Text = "ソート順"

        Me.OptUsrSagyou.AutoSize = True
        Me.OptUsrSagyou.Location = New System.Drawing.Point(24, 30)
        Me.OptUsrSagyou.Text = "作業日順"
        Me.OptUsrKijitsu.AutoSize = True
        Me.OptUsrKijitsu.Location = New System.Drawing.Point(24, 62)
        Me.OptUsrKijitsu.Text = "完了期日順"

        Me.grpUsrBunrui.Controls.Add(Me.OptUsrBunrui0)
        Me.grpUsrBunrui.Controls.Add(Me.OptUsrBunrui1)
        Me.grpUsrBunrui.Controls.Add(Me.OptUsrBunrui2)
        Me.grpUsrBunrui.Location = New System.Drawing.Point(270, 20)
        Me.grpUsrBunrui.Size = New System.Drawing.Size(220, 120)
        Me.grpUsrBunrui.TabStop = False
        Me.grpUsrBunrui.Text = "表示する分類"

        Me.OptUsrBunrui0.AutoSize = True
        Me.OptUsrBunrui0.Location = New System.Drawing.Point(24, 28)
        Me.OptUsrBunrui0.Text = "すべて"
        Me.OptUsrBunrui1.AutoSize = True
        Me.OptUsrBunrui1.Location = New System.Drawing.Point(24, 56)
        Me.OptUsrBunrui1.Text = "修理のみ"
        Me.OptUsrBunrui2.AutoSize = True
        Me.OptUsrBunrui2.Location = New System.Drawing.Point(24, 84)
        Me.OptUsrBunrui2.Text = "開発のみ"

        Me.ChkUsrAutoScroll.AutoSize = True
        Me.ChkUsrAutoScroll.Location = New System.Drawing.Point(32, 140)
        Me.ChkUsrAutoScroll.Text = "最下行に自動スクロールする"

        Me.ChkUsrKanryou.AutoSize = True
        Me.ChkUsrKanryou.Location = New System.Drawing.Point(32, 174)
        Me.ChkUsrKanryou.Text = "完了分も表示する"

        Me.lblUsrKijitsu.AutoSize = True
        Me.lblUsrKijitsu.Location = New System.Drawing.Point(32, 218)
        Me.lblUsrKijitsu.Text = "完了期日の範囲:"

        Me.TxtUsrKijitsuSt.Location = New System.Drawing.Point(150, 214)
        Me.TxtUsrKijitsuSt.Size = New System.Drawing.Size(110, 20)

        Me.lblUsrKijitsuWave.AutoSize = True
        Me.lblUsrKijitsuWave.Location = New System.Drawing.Point(268, 218)
        Me.lblUsrKijitsuWave.Text = "～"

        Me.TxtUsrKijitsuEd.Location = New System.Drawing.Point(292, 214)
        Me.TxtUsrKijitsuEd.Size = New System.Drawing.Size(110, 20)

        '
        'tabMnt (全メンテ記録)
        '
        Me.tabMnt.Controls.Add(Me.grpMntSort)
        Me.tabMnt.Controls.Add(Me.grpMntBunrui)
        Me.tabMnt.Controls.Add(Me.ChkKanryou)
        Me.tabMnt.Controls.Add(Me.lblMntKijitsu)
        Me.tabMnt.Controls.Add(Me.TxtKijitsuSt)
        Me.tabMnt.Controls.Add(Me.lblMntKijitsuWave)
        Me.tabMnt.Controls.Add(Me.TxtKijitsuEd)
        Me.tabMnt.Location = New System.Drawing.Point(4, 23)
        Me.tabMnt.Name = "tabMnt"
        Me.tabMnt.Padding = New System.Windows.Forms.Padding(8)
        Me.tabMnt.Size = New System.Drawing.Size(572, 313)
        Me.tabMnt.TabIndex = 2
        Me.tabMnt.Text = "全メンテ記録"
        Me.tabMnt.UseVisualStyleBackColor = True

        Me.grpMntSort.Controls.Add(Me.OptSagyou)
        Me.grpMntSort.Controls.Add(Me.OptKijitsu)
        Me.grpMntSort.Location = New System.Drawing.Point(24, 20)
        Me.grpMntSort.Size = New System.Drawing.Size(220, 100)
        Me.grpMntSort.TabStop = False
        Me.grpMntSort.Text = "ソート順"

        Me.OptSagyou.AutoSize = True
        Me.OptSagyou.Location = New System.Drawing.Point(24, 30)
        Me.OptSagyou.Text = "作業日順"
        Me.OptKijitsu.AutoSize = True
        Me.OptKijitsu.Location = New System.Drawing.Point(24, 62)
        Me.OptKijitsu.Text = "完了期日順"

        Me.grpMntBunrui.Controls.Add(Me.OptBunrui0)
        Me.grpMntBunrui.Controls.Add(Me.OptBunrui1)
        Me.grpMntBunrui.Controls.Add(Me.OptBunrui2)
        Me.grpMntBunrui.Location = New System.Drawing.Point(270, 20)
        Me.grpMntBunrui.Size = New System.Drawing.Size(220, 120)
        Me.grpMntBunrui.TabStop = False
        Me.grpMntBunrui.Text = "表示する分類"

        Me.OptBunrui0.AutoSize = True
        Me.OptBunrui0.Location = New System.Drawing.Point(24, 28)
        Me.OptBunrui0.Text = "すべて"
        Me.OptBunrui1.AutoSize = True
        Me.OptBunrui1.Location = New System.Drawing.Point(24, 56)
        Me.OptBunrui1.Text = "修理のみ"
        Me.OptBunrui2.AutoSize = True
        Me.OptBunrui2.Location = New System.Drawing.Point(24, 84)
        Me.OptBunrui2.Text = "開発のみ"

        Me.ChkKanryou.AutoSize = True
        Me.ChkKanryou.Location = New System.Drawing.Point(32, 160)
        Me.ChkKanryou.Text = "完了分も表示する"

        Me.lblMntKijitsu.AutoSize = True
        Me.lblMntKijitsu.Location = New System.Drawing.Point(32, 208)
        Me.lblMntKijitsu.Text = "完了期日の範囲:"

        Me.TxtKijitsuSt.Location = New System.Drawing.Point(150, 204)
        Me.TxtKijitsuSt.Size = New System.Drawing.Size(110, 20)

        Me.lblMntKijitsuWave.AutoSize = True
        Me.lblMntKijitsuWave.Location = New System.Drawing.Point(268, 208)
        Me.lblMntKijitsuWave.Text = "～"

        Me.TxtKijitsuEd.Location = New System.Drawing.Point(292, 204)
        Me.TxtKijitsuEd.Size = New System.Drawing.Size(110, 20)

        '
        'tabPrt (印刷設定)
        '
        Me.tabPrt.Controls.Add(Me.grpPrtMap)
        Me.tabPrt.Controls.Add(Me.grpPrtColor)
        Me.tabPrt.Controls.Add(Me.grpPrtMei)
        Me.tabPrt.Location = New System.Drawing.Point(4, 23)
        Me.tabPrt.Name = "tabPrt"
        Me.tabPrt.Padding = New System.Windows.Forms.Padding(8)
        Me.tabPrt.Size = New System.Drawing.Size(572, 313)
        Me.tabPrt.TabIndex = 3
        Me.tabPrt.Text = "印刷設定"
        Me.tabPrt.UseVisualStyleBackColor = True

        Me.grpPrtMap.Controls.Add(Me.OptMapTrue)
        Me.grpPrtMap.Controls.Add(Me.OptMapFalse)
        Me.grpPrtMap.Location = New System.Drawing.Point(24, 20)
        Me.grpPrtMap.Size = New System.Drawing.Size(220, 100)
        Me.grpPrtMap.TabStop = False
        Me.grpPrtMap.Text = "地図の印刷"

        Me.OptMapTrue.AutoSize = True
        Me.OptMapTrue.Location = New System.Drawing.Point(24, 30)
        Me.OptMapTrue.Text = "地図付き"
        Me.OptMapFalse.AutoSize = True
        Me.OptMapFalse.Location = New System.Drawing.Point(24, 62)
        Me.OptMapFalse.Text = "地図なし"

        Me.grpPrtColor.Controls.Add(Me.OptMono)
        Me.grpPrtColor.Controls.Add(Me.OptColor)
        Me.grpPrtColor.Location = New System.Drawing.Point(270, 20)
        Me.grpPrtColor.Size = New System.Drawing.Size(220, 100)
        Me.grpPrtColor.TabStop = False
        Me.grpPrtColor.Text = "地図の色"

        Me.OptMono.AutoSize = True
        Me.OptMono.Location = New System.Drawing.Point(24, 30)
        Me.OptMono.Text = "モノクロ"
        Me.OptColor.AutoSize = True
        Me.OptColor.Location = New System.Drawing.Point(24, 62)
        Me.OptColor.Text = "カラー"

        Me.grpPrtMei.Controls.Add(Me.optMei1)
        Me.grpPrtMei.Controls.Add(Me.OptMei2)
        Me.grpPrtMei.Controls.Add(Me.OptMei4)
        Me.grpPrtMei.Location = New System.Drawing.Point(24, 140)
        Me.grpPrtMei.Size = New System.Drawing.Size(466, 120)
        Me.grpPrtMei.TabStop = False
        Me.grpPrtMei.Text = "1ページの明細数"

        Me.optMei1.AutoSize = True
        Me.optMei1.Location = New System.Drawing.Point(24, 28)
        Me.optMei1.Text = "1件 (地図 大)"
        Me.OptMei2.AutoSize = True
        Me.OptMei2.Location = New System.Drawing.Point(24, 56)
        Me.OptMei2.Text = "2件"
        Me.OptMei4.AutoSize = True
        Me.OptMei4.Location = New System.Drawing.Point(24, 84)
        Me.OptMei4.Text = "4件"

        '
        'tabMntUsrPrt (メンテ印刷)
        '
        Me.tabMntUsrPrt.Controls.Add(Me.grpMntUsrPrt)
        Me.tabMntUsrPrt.Location = New System.Drawing.Point(4, 23)
        Me.tabMntUsrPrt.Name = "tabMntUsrPrt"
        Me.tabMntUsrPrt.Padding = New System.Windows.Forms.Padding(8)
        Me.tabMntUsrPrt.Size = New System.Drawing.Size(572, 313)
        Me.tabMntUsrPrt.TabIndex = 4
        Me.tabMntUsrPrt.Text = "メンテ印刷"
        Me.tabMntUsrPrt.UseVisualStyleBackColor = True

        Me.grpMntUsrPrt.Controls.Add(Me.lblPrtRange1)
        Me.grpMntUsrPrt.Controls.Add(Me.numMntUsrPrtRangeN)
        Me.grpMntUsrPrt.Controls.Add(Me.lblPrtRange2)
        Me.grpMntUsrPrt.Controls.Add(Me.lblPrtMaxLine1)
        Me.grpMntUsrPrt.Controls.Add(Me.numMntUsrPrtMaxLine)
        Me.grpMntUsrPrt.Controls.Add(Me.lblPrtMaxLine2)
        Me.grpMntUsrPrt.Location = New System.Drawing.Point(24, 24)
        Me.grpMntUsrPrt.Size = New System.Drawing.Size(500, 160)
        Me.grpMntUsrPrt.TabStop = False
        Me.grpMntUsrPrt.Text = "メンテナンス記録の印刷範囲"

        Me.lblPrtRange1.AutoSize = True
        Me.lblPrtRange1.Location = New System.Drawing.Point(28, 42)
        Me.lblPrtRange1.Text = "作業日"

        Me.numMntUsrPrtRangeN.Location = New System.Drawing.Point(84, 38)
        Me.numMntUsrPrtRangeN.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numMntUsrPrtRangeN.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMntUsrPrtRangeN.Size = New System.Drawing.Size(70, 20)
        Me.numMntUsrPrtRangeN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numMntUsrPrtRangeN.Value = New Decimal(New Integer() {3, 0, 0, 0})

        Me.lblPrtRange2.AutoSize = True
        Me.lblPrtRange2.Location = New System.Drawing.Point(162, 42)
        Me.lblPrtRange2.Text = "年以内を印刷する"

        Me.lblPrtMaxLine1.AutoSize = True
        Me.lblPrtMaxLine1.Location = New System.Drawing.Point(28, 92)
        Me.lblPrtMaxLine1.Text = "内容は1件につき"

        Me.numMntUsrPrtMaxLine.Location = New System.Drawing.Point(142, 88)
        Me.numMntUsrPrtMaxLine.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numMntUsrPrtMaxLine.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numMntUsrPrtMaxLine.Size = New System.Drawing.Size(80, 20)
        Me.numMntUsrPrtMaxLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numMntUsrPrtMaxLine.Value = New Decimal(New Integer() {30, 0, 0, 0})

        Me.lblPrtMaxLine2.AutoSize = True
        Me.lblPrtMaxLine2.Location = New System.Drawing.Point(230, 92)
        Me.lblPrtMaxLine2.Text = "行目まで印刷する"

        '
        'tabBrowser (ブラウザ設定)
        '
        Me.tabBrowser.Controls.Add(Me.grpBrowser)
        Me.tabBrowser.Location = New System.Drawing.Point(4, 23)
        Me.tabBrowser.Name = "tabBrowser"
        Me.tabBrowser.Padding = New System.Windows.Forms.Padding(8)
        Me.tabBrowser.Size = New System.Drawing.Size(572, 313)
        Me.tabBrowser.TabIndex = 5
        Me.tabBrowser.Text = "ブラウザ設定"
        Me.tabBrowser.UseVisualStyleBackColor = True

        Me.grpBrowser.Controls.Add(Me.lblBrowserPath)
        Me.grpBrowser.Controls.Add(Me.txtBrouserPath)
        Me.grpBrowser.Controls.Add(Me.cmdBrowserRef)
        Me.grpBrowser.Controls.Add(Me.btnBrowserDefault)
        Me.grpBrowser.Controls.Add(Me.btnBrowserEdge)
        Me.grpBrowser.Controls.Add(Me.btnBrowserChrome)
        Me.grpBrowser.Controls.Add(Me.btnBrowserFirefox)
        Me.grpBrowser.Location = New System.Drawing.Point(16, 20)
        Me.grpBrowser.Size = New System.Drawing.Size(536, 240)
        Me.grpBrowser.TabStop = False
        Me.grpBrowser.Text = "地図・Web検索の起動ブラウザ設定"

        Me.lblBrowserPath.AutoSize = True
        Me.lblBrowserPath.Location = New System.Drawing.Point(20, 32)
        Me.lblBrowserPath.Text = "ブラウザ実行ファイルのパス (空欄の場合はOSの既定ブラウザで開きます):"

        Me.txtBrouserPath.Location = New System.Drawing.Point(20, 56)
        Me.txtBrouserPath.Size = New System.Drawing.Size(420, 20)

        Me.cmdBrowserRef.Location = New System.Drawing.Point(448, 54)
        Me.cmdBrowserRef.Size = New System.Drawing.Size(70, 24)
        Me.cmdBrowserRef.Text = "参照..."
        Me.cmdBrowserRef.UseVisualStyleBackColor = True

        Me.btnBrowserDefault.Location = New System.Drawing.Point(20, 100)
        Me.btnBrowserDefault.Size = New System.Drawing.Size(230, 32)
        Me.btnBrowserDefault.Text = "OSの標準ブラウザを使用 (空欄)"
        Me.btnBrowserDefault.UseVisualStyleBackColor = True

        Me.btnBrowserEdge.Location = New System.Drawing.Point(268, 100)
        Me.btnBrowserEdge.Size = New System.Drawing.Size(230, 32)
        Me.btnBrowserEdge.Text = "Microsoft Edge をセット"
        Me.btnBrowserEdge.UseVisualStyleBackColor = True

        Me.btnBrowserChrome.Location = New System.Drawing.Point(20, 144)
        Me.btnBrowserChrome.Size = New System.Drawing.Size(230, 32)
        Me.btnBrowserChrome.Text = "Google Chrome をセット"
        Me.btnBrowserChrome.UseVisualStyleBackColor = True

        Me.btnBrowserFirefox.Location = New System.Drawing.Point(268, 144)
        Me.btnBrowserFirefox.Size = New System.Drawing.Size(230, 32)
        Me.btnBrowserFirefox.Text = "Mozilla Firefox をセット"
        Me.btnBrowserFirefox.UseVisualStyleBackColor = True

        '
        'Bottom Buttons
        '
        Me.cmdOK.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.cmdOK.Location = New System.Drawing.Point(308, 360)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(88, 30)
        Me.cmdOK.TabIndex = 1
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True

        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.cmdCancel.Location = New System.Drawing.Point(404, 360)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(88, 30)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "キャンセル"
        Me.cmdCancel.UseVisualStyleBackColor = True

        Me.cmdApply.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.cmdApply.Location = New System.Drawing.Point(500, 360)
        Me.cmdApply.Name = "cmdApply"
        Me.cmdApply.Size = New System.Drawing.Size(88, 30)
        Me.cmdApply.TabIndex = 3
        Me.cmdApply.Text = "適用(&A)"
        Me.cmdApply.UseVisualStyleBackColor = True

        '
        'FrmOpt
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(600, 402)
        Me.Controls.Add(Me.tbsOpt)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdApply)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOpt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "環境設定"

        Me.tbsOpt.ResumeLayout(False)
        Me.tabMain.ResumeLayout(False)
        Me.tabMain.PerformLayout()
        Me.grpDb.ResumeLayout(False)
        Me.grpDb.PerformLayout()
        Me.tabMntUsr.ResumeLayout(False)
        Me.tabMntUsr.PerformLayout()
        Me.grpUsrSort.ResumeLayout(False)
        Me.grpUsrSort.PerformLayout()
        Me.grpUsrBunrui.ResumeLayout(False)
        Me.grpUsrBunrui.PerformLayout()
        Me.tabMnt.ResumeLayout(False)
        Me.tabMnt.PerformLayout()
        Me.grpMntSort.ResumeLayout(False)
        Me.grpMntSort.PerformLayout()
        Me.grpMntBunrui.ResumeLayout(False)
        Me.grpMntBunrui.PerformLayout()
        Me.tabPrt.ResumeLayout(False)
        Me.grpPrtMap.ResumeLayout(False)
        Me.grpPrtMap.PerformLayout()
        Me.grpPrtColor.ResumeLayout(False)
        Me.grpPrtColor.PerformLayout()
        Me.grpPrtMei.ResumeLayout(False)
        Me.grpPrtMei.PerformLayout()
        Me.tabMntUsrPrt.ResumeLayout(False)
        Me.grpMntUsrPrt.ResumeLayout(False)
        Me.grpMntUsrPrt.PerformLayout()
        CType(Me.numMntUsrPrtRangeN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMntUsrPrtMaxLine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBrowser.ResumeLayout(False)
        Me.grpBrowser.ResumeLayout(False)
        Me.grpBrowser.PerformLayout()
        Me.ResumeLayout(False)
    End Sub
End Class
