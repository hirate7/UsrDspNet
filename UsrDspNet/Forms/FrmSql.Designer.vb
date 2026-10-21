<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSql
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
    Public WithEvents pnlGroup As System.Windows.Forms.Panel
    Public WithEvents optOsaka As System.Windows.Forms.RadioButton
    Public WithEvents optHyogo As System.Windows.Forms.RadioButton
    Public WithEvents optKojin As System.Windows.Forms.RadioButton
    Public WithEvents optKenju As System.Windows.Forms.RadioButton
    Public WithEvents optKakushin As System.Windows.Forms.RadioButton
    Public WithEvents optSoken As System.Windows.Forms.RadioButton
    Public WithEvents optZennichi As System.Windows.Forms.RadioButton
    Public WithEvents optIkusei As System.Windows.Forms.RadioButton

    Public WithEvents picKen As System.Windows.Forms.Panel
    Public WithEvents chkOsaka As System.Windows.Forms.CheckBox
    Public WithEvents chkHyogo As System.Windows.Forms.CheckBox
    Public WithEvents chkKyoto As System.Windows.Forms.CheckBox
    Public WithEvents chkOita As System.Windows.Forms.CheckBox
    Public WithEvents chkMie As System.Windows.Forms.CheckBox
    Public WithEvents chkNara As System.Windows.Forms.CheckBox
    Public WithEvents chkWakayama As System.Windows.Forms.CheckBox
    Public WithEvents chkEhime As System.Windows.Forms.CheckBox
    Public WithEvents lblKenAll As System.Windows.Forms.Label

    Public WithEvents pnlOs As System.Windows.Forms.Panel
    Public WithEvents chkXP As System.Windows.Forms.CheckBox
    Public WithEvents chkVista As System.Windows.Forms.CheckBox
    Public WithEvents chkWindows7 As System.Windows.Forms.CheckBox
    Public WithEvents chkWindows8 As System.Windows.Forms.CheckBox
    Public WithEvents chkWindows10 As System.Windows.Forms.CheckBox
    Public WithEvents chkWindows11 As System.Windows.Forms.CheckBox
    Public WithEvents chkWin16 As System.Windows.Forms.CheckBox
    Public WithEvents lblOsAll As System.Windows.Forms.Label

    Public WithEvents pnlBunin As System.Windows.Forms.Panel
    Public WithEvents optBunin As System.Windows.Forms.RadioButton
    Public WithEvents optNotBunin As System.Windows.Forms.RadioButton
    Public WithEvents optBAll As System.Windows.Forms.RadioButton

    Public WithEvents picKaikei As System.Windows.Forms.Panel
    Public WithEvents optKaikei As System.Windows.Forms.RadioButton
    Public WithEvents optNotKaikei As System.Windows.Forms.RadioButton
    Public WithEvents optKAll As System.Windows.Forms.RadioButton

    Public WithEvents pnlFdd As System.Windows.Forms.Panel
    Public WithEvents OptNoFdd As System.Windows.Forms.RadioButton
    Public WithEvents OptFdd As System.Windows.Forms.RadioButton
    Public WithEvents optFddAll As System.Windows.Forms.RadioButton

    Public WithEvents pnlVupType As System.Windows.Forms.Panel
    Public WithEvents lblVupType As System.Windows.Forms.Label
    Public WithEvents chkVupMitei As System.Windows.Forms.CheckBox
    Public WithEvents chkVupNet As System.Windows.Forms.CheckBox
    Public WithEvents chkVupCd As System.Windows.Forms.CheckBox

    Public WithEvents txtSql As System.Windows.Forms.TextBox
    Public WithEvents cmdSqlCheck As System.Windows.Forms.Button
    Public WithEvents lblCnt As System.Windows.Forms.Label
    Public WithEvents cmdMakeSql As System.Windows.Forms.Button
    Public WithEvents Command1 As System.Windows.Forms.Button

    Public WithEvents pnlActions As System.Windows.Forms.Panel
    Public WithEvents Command3 As System.Windows.Forms.Button
    Public WithEvents Command2 As System.Windows.Forms.Button
    Public WithEvents chkWC As System.Windows.Forms.CheckBox
    Public WithEvents cmdSagawa As System.Windows.Forms.Button
    Public WithEvents cmdSagawaAd As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlGroup = New System.Windows.Forms.Panel()
        Me.optOsaka = New System.Windows.Forms.RadioButton()
        Me.optHyogo = New System.Windows.Forms.RadioButton()
        Me.optKojin = New System.Windows.Forms.RadioButton()
        Me.optKenju = New System.Windows.Forms.RadioButton()
        Me.optKakushin = New System.Windows.Forms.RadioButton()
        Me.optSoken = New System.Windows.Forms.RadioButton()
        Me.optZennichi = New System.Windows.Forms.RadioButton()
        Me.optIkusei = New System.Windows.Forms.RadioButton()
        Me.picKen = New System.Windows.Forms.Panel()
        Me.chkOsaka = New System.Windows.Forms.CheckBox()
        Me.chkHyogo = New System.Windows.Forms.CheckBox()
        Me.chkKyoto = New System.Windows.Forms.CheckBox()
        Me.chkOita = New System.Windows.Forms.CheckBox()
        Me.chkMie = New System.Windows.Forms.CheckBox()
        Me.chkNara = New System.Windows.Forms.CheckBox()
        Me.chkWakayama = New System.Windows.Forms.CheckBox()
        Me.chkEhime = New System.Windows.Forms.CheckBox()
        Me.lblKenAll = New System.Windows.Forms.Label()
        Me.pnlOs = New System.Windows.Forms.Panel()
        Me.chkXP = New System.Windows.Forms.CheckBox()
        Me.chkVista = New System.Windows.Forms.CheckBox()
        Me.chkWindows7 = New System.Windows.Forms.CheckBox()
        Me.chkWindows8 = New System.Windows.Forms.CheckBox()
        Me.chkWindows10 = New System.Windows.Forms.CheckBox()
        Me.chkWindows11 = New System.Windows.Forms.CheckBox()
        Me.chkWin16 = New System.Windows.Forms.CheckBox()
        Me.lblOsAll = New System.Windows.Forms.Label()
        Me.pnlBunin = New System.Windows.Forms.Panel()
        Me.optBunin = New System.Windows.Forms.RadioButton()
        Me.optNotBunin = New System.Windows.Forms.RadioButton()
        Me.optBAll = New System.Windows.Forms.RadioButton()
        Me.picKaikei = New System.Windows.Forms.Panel()
        Me.optKaikei = New System.Windows.Forms.RadioButton()
        Me.optNotKaikei = New System.Windows.Forms.RadioButton()
        Me.optKAll = New System.Windows.Forms.RadioButton()
        Me.pnlFdd = New System.Windows.Forms.Panel()
        Me.OptNoFdd = New System.Windows.Forms.RadioButton()
        Me.OptFdd = New System.Windows.Forms.RadioButton()
        Me.optFddAll = New System.Windows.Forms.RadioButton()
        Me.pnlVupType = New System.Windows.Forms.Panel()
        Me.lblVupType = New System.Windows.Forms.Label()
        Me.chkVupMitei = New System.Windows.Forms.CheckBox()
        Me.chkVupNet = New System.Windows.Forms.CheckBox()
        Me.chkVupCd = New System.Windows.Forms.CheckBox()
        Me.txtSql = New System.Windows.Forms.TextBox()
        Me.cmdSqlCheck = New System.Windows.Forms.Button()
        Me.lblCnt = New System.Windows.Forms.Label()
        Me.cmdMakeSql = New System.Windows.Forms.Button()
        Me.Command1 = New System.Windows.Forms.Button()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.Command3 = New System.Windows.Forms.Button()
        Me.Command2 = New System.Windows.Forms.Button()
        Me.chkWC = New System.Windows.Forms.CheckBox()
        Me.cmdSagawa = New System.Windows.Forms.Button()
        Me.cmdSagawaAd = New System.Windows.Forms.Button()
        Me.pnlGroup.SuspendLayout()
        Me.picKen.SuspendLayout()
        Me.pnlOs.SuspendLayout()
        Me.pnlBunin.SuspendLayout()
        Me.picKaikei.SuspendLayout()
        Me.pnlFdd.SuspendLayout()
        Me.pnlVupType.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlGroup
        '
        Me.pnlGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlGroup.Controls.Add(Me.optOsaka)
        Me.pnlGroup.Controls.Add(Me.optHyogo)
        Me.pnlGroup.Controls.Add(Me.optKojin)
        Me.pnlGroup.Controls.Add(Me.optKenju)
        Me.pnlGroup.Controls.Add(Me.optKakushin)
        Me.pnlGroup.Controls.Add(Me.optSoken)
        Me.pnlGroup.Controls.Add(Me.optZennichi)
        Me.pnlGroup.Controls.Add(Me.optIkusei)
        Me.pnlGroup.Location = New System.Drawing.Point(8, 8)
        Me.pnlGroup.Name = "pnlGroup"
        Me.pnlGroup.Size = New System.Drawing.Size(674, 34)
        Me.pnlGroup.TabIndex = 0
        '
        'optOsaka
        '
        Me.optOsaka.Checked = True
        Me.optOsaka.Location = New System.Drawing.Point(8, 6)
        Me.optOsaka.Name = "optOsaka"
        Me.optOsaka.Size = New System.Drawing.Size(80, 20)
        Me.optOsaka.TabIndex = 0
        Me.optOsaka.TabStop = True
        Me.optOsaka.Text = "大阪社団"
        '
        'optHyogo
        '
        Me.optHyogo.Location = New System.Drawing.Point(92, 6)
        Me.optHyogo.Name = "optHyogo"
        Me.optHyogo.Size = New System.Drawing.Size(80, 20)
        Me.optHyogo.TabIndex = 1
        Me.optHyogo.Text = "兵庫社団"
        '
        'optKojin
        '
        Me.optKojin.Location = New System.Drawing.Point(176, 6)
        Me.optKojin.Name = "optKojin"
        Me.optKojin.Size = New System.Drawing.Size(80, 20)
        Me.optKojin.TabIndex = 2
        Me.optKojin.Text = "個人請求"
        '
        'optKenju
        '
        Me.optKenju.Location = New System.Drawing.Point(260, 6)
        Me.optKenju.Name = "optKenju"
        Me.optKenju.Size = New System.Drawing.Size(74, 20)
        Me.optKenju.TabIndex = 3
        Me.optKenju.Text = "健柔会"
        '
        'optKakushin
        '
        Me.optKakushin.Location = New System.Drawing.Point(338, 6)
        Me.optKakushin.Name = "optKakushin"
        Me.optKakushin.Size = New System.Drawing.Size(74, 20)
        Me.optKakushin.TabIndex = 4
        Me.optKakushin.Text = "革新会"
        '
        'optSoken
        '
        Me.optSoken.Location = New System.Drawing.Point(416, 6)
        Me.optSoken.Name = "optSoken"
        Me.optSoken.Size = New System.Drawing.Size(80, 20)
        Me.optSoken.TabIndex = 5
        Me.optSoken.Text = "柔整総研"
        '
        'optZennichi
        '
        Me.optZennichi.Location = New System.Drawing.Point(500, 6)
        Me.optZennichi.Name = "optZennichi"
        Me.optZennichi.Size = New System.Drawing.Size(60, 20)
        Me.optZennichi.TabIndex = 6
        Me.optZennichi.Text = "全日"
        '
        'optIkusei
        '
        Me.optIkusei.Location = New System.Drawing.Point(564, 6)
        Me.optIkusei.Name = "optIkusei"
        Me.optIkusei.Size = New System.Drawing.Size(74, 20)
        Me.optIkusei.TabIndex = 7
        Me.optIkusei.Text = "育成会"
        Me.optIkusei.Visible = False
        '
        'picKen
        '
        Me.picKen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picKen.Controls.Add(Me.chkOsaka)
        Me.picKen.Controls.Add(Me.chkHyogo)
        Me.picKen.Controls.Add(Me.chkKyoto)
        Me.picKen.Controls.Add(Me.chkOita)
        Me.picKen.Controls.Add(Me.chkMie)
        Me.picKen.Controls.Add(Me.chkNara)
        Me.picKen.Controls.Add(Me.chkWakayama)
        Me.picKen.Controls.Add(Me.chkEhime)
        Me.picKen.Controls.Add(Me.lblKenAll)
        Me.picKen.Location = New System.Drawing.Point(8, 46)
        Me.picKen.Name = "picKen"
        Me.picKen.Size = New System.Drawing.Size(674, 34)
        Me.picKen.TabIndex = 1
        Me.picKen.Visible = False
        '
        'chkOsaka
        '
        Me.chkOsaka.Checked = True
        Me.chkOsaka.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOsaka.Location = New System.Drawing.Point(12, 6)
        Me.chkOsaka.Name = "chkOsaka"
        Me.chkOsaka.Size = New System.Drawing.Size(56, 20)
        Me.chkOsaka.TabIndex = 0
        Me.chkOsaka.Text = "大阪"
        '
        'chkHyogo
        '
        Me.chkHyogo.Checked = True
        Me.chkHyogo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHyogo.Location = New System.Drawing.Point(72, 6)
        Me.chkHyogo.Name = "chkHyogo"
        Me.chkHyogo.Size = New System.Drawing.Size(56, 20)
        Me.chkHyogo.TabIndex = 1
        Me.chkHyogo.Text = "兵庫"
        '
        'chkKyoto
        '
        Me.chkKyoto.Checked = True
        Me.chkKyoto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKyoto.Location = New System.Drawing.Point(132, 6)
        Me.chkKyoto.Name = "chkKyoto"
        Me.chkKyoto.Size = New System.Drawing.Size(56, 20)
        Me.chkKyoto.TabIndex = 2
        Me.chkKyoto.Text = "京都"
        '
        'chkOita
        '
        Me.chkOita.Checked = True
        Me.chkOita.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOita.Location = New System.Drawing.Point(192, 6)
        Me.chkOita.Name = "chkOita"
        Me.chkOita.Size = New System.Drawing.Size(56, 20)
        Me.chkOita.TabIndex = 3
        Me.chkOita.Text = "大分"
        '
        'chkMie
        '
        Me.chkMie.Checked = True
        Me.chkMie.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMie.Location = New System.Drawing.Point(252, 6)
        Me.chkMie.Name = "chkMie"
        Me.chkMie.Size = New System.Drawing.Size(56, 20)
        Me.chkMie.TabIndex = 4
        Me.chkMie.Text = "三重"
        '
        'chkNara
        '
        Me.chkNara.Checked = True
        Me.chkNara.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNara.Location = New System.Drawing.Point(312, 6)
        Me.chkNara.Name = "chkNara"
        Me.chkNara.Size = New System.Drawing.Size(56, 20)
        Me.chkNara.TabIndex = 5
        Me.chkNara.Text = "奈良"
        '
        'chkWakayama
        '
        Me.chkWakayama.Checked = True
        Me.chkWakayama.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWakayama.Location = New System.Drawing.Point(372, 6)
        Me.chkWakayama.Name = "chkWakayama"
        Me.chkWakayama.Size = New System.Drawing.Size(68, 20)
        Me.chkWakayama.TabIndex = 6
        Me.chkWakayama.Text = "和歌山"
        '
        'chkEhime
        '
        Me.chkEhime.Checked = True
        Me.chkEhime.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEhime.Location = New System.Drawing.Point(444, 6)
        Me.chkEhime.Name = "chkEhime"
        Me.chkEhime.Size = New System.Drawing.Size(56, 20)
        Me.chkEhime.TabIndex = 7
        Me.chkEhime.Text = "愛媛"
        '
        'lblKenAll
        '
        Me.lblKenAll.AutoSize = True
        Me.lblKenAll.Location = New System.Drawing.Point(510, 8)
        Me.lblKenAll.Name = "lblKenAll"
        Me.lblKenAll.Size = New System.Drawing.Size(44, 13)
        Me.lblKenAll.TabIndex = 8
        Me.lblKenAll.Text = "すべて"
        Me.lblKenAll.Visible = False
        '
        'pnlOs
        '
        Me.pnlOs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlOs.Controls.Add(Me.chkXP)
        Me.pnlOs.Controls.Add(Me.chkVista)
        Me.pnlOs.Controls.Add(Me.chkWindows7)
        Me.pnlOs.Controls.Add(Me.chkWindows8)
        Me.pnlOs.Controls.Add(Me.chkWindows10)
        Me.pnlOs.Controls.Add(Me.chkWindows11)
        Me.pnlOs.Controls.Add(Me.chkWin16)
        Me.pnlOs.Controls.Add(Me.lblOsAll)
        Me.pnlOs.Location = New System.Drawing.Point(8, 84)
        Me.pnlOs.Name = "pnlOs"
        Me.pnlOs.Size = New System.Drawing.Size(674, 34)
        Me.pnlOs.TabIndex = 2
        '
        'chkXP
        '
        Me.chkXP.Checked = True
        Me.chkXP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkXP.Location = New System.Drawing.Point(12, 6)
        Me.chkXP.Name = "chkXP"
        Me.chkXP.Size = New System.Drawing.Size(50, 20)
        Me.chkXP.TabIndex = 0
        Me.chkXP.Text = "XP"
        '
        'chkVista
        '
        Me.chkVista.Checked = True
        Me.chkVista.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVista.Location = New System.Drawing.Point(68, 6)
        Me.chkVista.Name = "chkVista"
        Me.chkVista.Size = New System.Drawing.Size(60, 20)
        Me.chkVista.TabIndex = 1
        Me.chkVista.Text = "Vista"
        '
        'chkWindows7
        '
        Me.chkWindows7.Checked = True
        Me.chkWindows7.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWindows7.Location = New System.Drawing.Point(134, 6)
        Me.chkWindows7.Name = "chkWindows7"
        Me.chkWindows7.Size = New System.Drawing.Size(62, 20)
        Me.chkWindows7.TabIndex = 2
        Me.chkWindows7.Text = "Win7"
        '
        'chkWindows8
        '
        Me.chkWindows8.Checked = True
        Me.chkWindows8.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWindows8.Location = New System.Drawing.Point(202, 6)
        Me.chkWindows8.Name = "chkWindows8"
        Me.chkWindows8.Size = New System.Drawing.Size(62, 20)
        Me.chkWindows8.TabIndex = 3
        Me.chkWindows8.Text = "Win8"
        '
        'chkWindows10
        '
        Me.chkWindows10.Checked = True
        Me.chkWindows10.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWindows10.Location = New System.Drawing.Point(270, 6)
        Me.chkWindows10.Name = "chkWindows10"
        Me.chkWindows10.Size = New System.Drawing.Size(68, 20)
        Me.chkWindows10.TabIndex = 4
        Me.chkWindows10.Text = "Win10"
        '
        'chkWindows11
        '
        Me.chkWindows11.Checked = True
        Me.chkWindows11.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWindows11.Location = New System.Drawing.Point(344, 6)
        Me.chkWindows11.Name = "chkWindows11"
        Me.chkWindows11.Size = New System.Drawing.Size(68, 20)
        Me.chkWindows11.TabIndex = 5
        Me.chkWindows11.Text = "Win11"
        '
        'chkWin16
        '
        Me.chkWin16.Location = New System.Drawing.Point(418, 6)
        Me.chkWin16.Name = "chkWin16"
        Me.chkWin16.Size = New System.Drawing.Size(90, 20)
        Me.chkWin16.TabIndex = 6
        Me.chkWin16.Text = "Win(16bit)"
        '
        'lblOsAll
        '
        Me.lblOsAll.AutoSize = True
        Me.lblOsAll.Location = New System.Drawing.Point(520, 8)
        Me.lblOsAll.Name = "lblOsAll"
        Me.lblOsAll.Size = New System.Drawing.Size(44, 13)
        Me.lblOsAll.TabIndex = 7
        Me.lblOsAll.Text = "すべて"
        Me.lblOsAll.Visible = False
        '
        'pnlBunin
        '
        Me.pnlBunin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBunin.Controls.Add(Me.optBunin)
        Me.pnlBunin.Controls.Add(Me.optNotBunin)
        Me.pnlBunin.Controls.Add(Me.optBAll)
        Me.pnlBunin.Location = New System.Drawing.Point(8, 122)
        Me.pnlBunin.Name = "pnlBunin"
        Me.pnlBunin.Size = New System.Drawing.Size(674, 34)
        Me.pnlBunin.TabIndex = 3
        '
        'optBunin
        '
        Me.optBunin.Location = New System.Drawing.Point(16, 6)
        Me.optBunin.Name = "optBunin"
        Me.optBunin.Size = New System.Drawing.Size(100, 20)
        Me.optBunin.TabIndex = 0
        Me.optBunin.Text = "本院のみ"
        '
        'optNotBunin
        '
        Me.optNotBunin.Location = New System.Drawing.Point(124, 6)
        Me.optNotBunin.Name = "optNotBunin"
        Me.optNotBunin.Size = New System.Drawing.Size(100, 20)
        Me.optNotBunin.TabIndex = 1
        Me.optNotBunin.Text = "本院以外"
        '
        'optBAll
        '
        Me.optBAll.Checked = True
        Me.optBAll.Location = New System.Drawing.Point(330, 6)
        Me.optBAll.Name = "optBAll"
        Me.optBAll.Size = New System.Drawing.Size(70, 20)
        Me.optBAll.TabIndex = 2
        Me.optBAll.TabStop = True
        Me.optBAll.Text = "両方"
        '
        'picKaikei
        '
        Me.picKaikei.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picKaikei.Controls.Add(Me.optKaikei)
        Me.picKaikei.Controls.Add(Me.optNotKaikei)
        Me.picKaikei.Controls.Add(Me.optKAll)
        Me.picKaikei.Location = New System.Drawing.Point(8, 160)
        Me.picKaikei.Name = "picKaikei"
        Me.picKaikei.Size = New System.Drawing.Size(674, 34)
        Me.picKaikei.TabIndex = 4
        '
        'optKaikei
        '
        Me.optKaikei.Location = New System.Drawing.Point(16, 6)
        Me.optKaikei.Name = "optKaikei"
        Me.optKaikei.Size = New System.Drawing.Size(106, 20)
        Me.optKaikei.TabIndex = 0
        Me.optKaikei.Text = "会計処理のみ"
        '
        'optNotKaikei
        '
        Me.optNotKaikei.Location = New System.Drawing.Point(128, 6)
        Me.optNotKaikei.Name = "optNotKaikei"
        Me.optNotKaikei.Size = New System.Drawing.Size(106, 20)
        Me.optNotKaikei.TabIndex = 1
        Me.optNotKaikei.Text = "会計処理以外"
        '
        'optKAll
        '
        Me.optKAll.Checked = True
        Me.optKAll.Location = New System.Drawing.Point(330, 6)
        Me.optKAll.Name = "optKAll"
        Me.optKAll.Size = New System.Drawing.Size(70, 20)
        Me.optKAll.TabIndex = 2
        Me.optKAll.TabStop = True
        Me.optKAll.Text = "両方"
        '
        'pnlFdd
        '
        Me.pnlFdd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFdd.Controls.Add(Me.OptNoFdd)
        Me.pnlFdd.Controls.Add(Me.OptFdd)
        Me.pnlFdd.Controls.Add(Me.optFddAll)
        Me.pnlFdd.Location = New System.Drawing.Point(8, 198)
        Me.pnlFdd.Name = "pnlFdd"
        Me.pnlFdd.Size = New System.Drawing.Size(674, 34)
        Me.pnlFdd.TabIndex = 5
        '
        'OptNoFdd
        '
        Me.OptNoFdd.Location = New System.Drawing.Point(16, 6)
        Me.OptNoFdd.Name = "OptNoFdd"
        Me.OptNoFdd.Size = New System.Drawing.Size(106, 20)
        Me.OptNoFdd.TabIndex = 0
        Me.OptNoFdd.Text = "FDD無し のみ"
        '
        'OptFdd
        '
        Me.OptFdd.Location = New System.Drawing.Point(128, 6)
        Me.OptFdd.Name = "OptFdd"
        Me.OptFdd.Size = New System.Drawing.Size(106, 20)
        Me.OptFdd.TabIndex = 1
        Me.OptFdd.Text = "FDD無し 以外"
        '
        'optFddAll
        '
        Me.optFddAll.Checked = True
        Me.optFddAll.Location = New System.Drawing.Point(330, 6)
        Me.optFddAll.Name = "optFddAll"
        Me.optFddAll.Size = New System.Drawing.Size(70, 20)
        Me.optFddAll.TabIndex = 2
        Me.optFddAll.TabStop = True
        Me.optFddAll.Text = "両方"
        '
        'pnlVupType
        '
        Me.pnlVupType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlVupType.Controls.Add(Me.lblVupType)
        Me.pnlVupType.Controls.Add(Me.chkVupMitei)
        Me.pnlVupType.Controls.Add(Me.chkVupNet)
        Me.pnlVupType.Controls.Add(Me.chkVupCd)
        Me.pnlVupType.Location = New System.Drawing.Point(8, 236)
        Me.pnlVupType.Name = "pnlVupType"
        Me.pnlVupType.Size = New System.Drawing.Size(674, 34)
        Me.pnlVupType.TabIndex = 6
        '
        'lblVupType
        '
        Me.lblVupType.AutoSize = True
        Me.lblVupType.Location = New System.Drawing.Point(12, 8)
        Me.lblVupType.Name = "lblVupType"
        Me.lblVupType.Size = New System.Drawing.Size(125, 13)
        Me.lblVupType.TabIndex = 0
        Me.lblVupType.Text = "バージョンアップ方法:"
        '
        'chkVupMitei
        '
        Me.chkVupMitei.Location = New System.Drawing.Point(150, 6)
        Me.chkVupMitei.Name = "chkVupMitei"
        Me.chkVupMitei.Size = New System.Drawing.Size(70, 20)
        Me.chkVupMitei.TabIndex = 1
        Me.chkVupMitei.Text = "未定"
        '
        'chkVupNet
        '
        Me.chkVupNet.Location = New System.Drawing.Point(230, 6)
        Me.chkVupNet.Name = "chkVupNet"
        Me.chkVupNet.Size = New System.Drawing.Size(76, 20)
        Me.chkVupNet.TabIndex = 2
        Me.chkVupNet.Text = "ネット"
        '
        'chkVupCd
        '
        Me.chkVupCd.Checked = True
        Me.chkVupCd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVupCd.Location = New System.Drawing.Point(316, 6)
        Me.chkVupCd.Name = "chkVupCd"
        Me.chkVupCd.Size = New System.Drawing.Size(70, 20)
        Me.chkVupCd.TabIndex = 3
        Me.chkVupCd.Text = "CD"
        '
        'txtSql
        '
        Me.txtSql.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.txtSql.Location = New System.Drawing.Point(8, 276)
        Me.txtSql.Multiline = True
        Me.txtSql.Name = "txtSql"
        Me.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSql.Size = New System.Drawing.Size(674, 292)
        Me.txtSql.TabIndex = 7
        '
        'cmdSqlCheck
        '
        Me.cmdSqlCheck.Location = New System.Drawing.Point(8, 576)
        Me.cmdSqlCheck.Name = "cmdSqlCheck"
        Me.cmdSqlCheck.Size = New System.Drawing.Size(100, 28)
        Me.cmdSqlCheck.TabIndex = 8
        Me.cmdSqlCheck.Text = "件数確認"
        Me.cmdSqlCheck.UseVisualStyleBackColor = True
        '
        'lblCnt
        '
        Me.lblCnt.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCnt.Location = New System.Drawing.Point(116, 580)
        Me.lblCnt.Name = "lblCnt"
        Me.lblCnt.Size = New System.Drawing.Size(270, 24)
        Me.lblCnt.TabIndex = 9
        Me.lblCnt.Text = "0件 該当"
        '
        'cmdMakeSql
        '
        Me.cmdMakeSql.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 10.5!)
        Me.cmdMakeSql.Location = New System.Drawing.Point(382, 574)
        Me.cmdMakeSql.Name = "cmdMakeSql"
        Me.cmdMakeSql.Size = New System.Drawing.Size(110, 32)
        Me.cmdMakeSql.TabIndex = 10
        Me.cmdMakeSql.Text = "SQL文作成"
        Me.cmdMakeSql.UseVisualStyleBackColor = True
        '
        'Command1
        '
        Me.Command1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Command1.Location = New System.Drawing.Point(498, 574)
        Me.Command1.Name = "Command1"
        Me.Command1.Size = New System.Drawing.Size(184, 32)
        Me.Command1.TabIndex = 11
        Me.Command1.Text = "上記SQL文で印刷画面へ"
        Me.Command1.UseVisualStyleBackColor = True
        '
        'pnlActions
        '
        Me.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlActions.Controls.Add(Me.Command3)
        Me.pnlActions.Controls.Add(Me.Command2)
        Me.pnlActions.Controls.Add(Me.chkWC)
        Me.pnlActions.Controls.Add(Me.cmdSagawa)
        Me.pnlActions.Controls.Add(Me.cmdSagawaAd)
        Me.pnlActions.Location = New System.Drawing.Point(8, 612)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Size = New System.Drawing.Size(420, 150)
        Me.pnlActions.TabIndex = 12
        '
        'Command3
        '
        Me.Command3.Location = New System.Drawing.Point(10, 10)
        Me.Command3.Name = "Command3"
        Me.Command3.Size = New System.Drawing.Size(110, 28)
        Me.Command3.TabIndex = 0
        Me.Command3.Text = "画面表示"
        Me.Command3.UseVisualStyleBackColor = True
        '
        'Command2
        '
        Me.Command2.Location = New System.Drawing.Point(10, 44)
        Me.Command2.Name = "Command2"
        Me.Command2.Size = New System.Drawing.Size(110, 28)
        Me.Command2.TabIndex = 1
        Me.Command2.Text = "csv出力"
        Me.Command2.UseVisualStyleBackColor = True
        '
        'chkWC
        '
        Me.chkWC.Checked = True
        Me.chkWC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWC.Location = New System.Drawing.Point(132, 48)
        Me.chkWC.Name = "chkWC"
        Me.chkWC.Size = New System.Drawing.Size(190, 22)
        Me.chkWC.TabIndex = 2
        Me.chkWC.Text = "ダブルコーテーション付き"
        '
        'cmdSagawa
        '
        Me.cmdSagawa.Location = New System.Drawing.Point(10, 80)
        Me.cmdSagawa.Name = "cmdSagawa"
        Me.cmdSagawa.Size = New System.Drawing.Size(340, 28)
        Me.cmdSagawa.TabIndex = 3
        Me.cmdSagawa.Text = "飛脚メール便出力 （NAS001\開発\飛脚メール便）"
        Me.cmdSagawa.UseVisualStyleBackColor = True
        '
        'cmdSagawaAd
        '
        Me.cmdSagawaAd.Location = New System.Drawing.Point(10, 114)
        Me.cmdSagawaAd.Name = "cmdSagawaAd"
        Me.cmdSagawaAd.Size = New System.Drawing.Size(340, 28)
        Me.cmdSagawaAd.TabIndex = 4
        Me.cmdSagawaAd.Text = "佐川急便住所録 （NAS001\開発\佐川急便住所録）"
        Me.cmdSagawaAd.UseVisualStyleBackColor = True
        '
        'FrmSql
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 772)
        Me.Controls.Add(Me.pnlGroup)
        Me.Controls.Add(Me.picKen)
        Me.Controls.Add(Me.pnlOs)
        Me.Controls.Add(Me.pnlBunin)
        Me.Controls.Add(Me.picKaikei)
        Me.Controls.Add(Me.pnlFdd)
        Me.Controls.Add(Me.pnlVupType)
        Me.Controls.Add(Me.txtSql)
        Me.Controls.Add(Me.cmdSqlCheck)
        Me.Controls.Add(Me.lblCnt)
        Me.Controls.Add(Me.cmdMakeSql)
        Me.Controls.Add(Me.Command1)
        Me.Controls.Add(Me.pnlActions)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSql"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "バージョンアップ用ラベル印刷"
        Me.pnlGroup.ResumeLayout(False)
        Me.picKen.ResumeLayout(False)
        Me.picKen.PerformLayout()
        Me.pnlOs.ResumeLayout(False)
        Me.pnlOs.PerformLayout()
        Me.pnlBunin.ResumeLayout(False)
        Me.picKaikei.ResumeLayout(False)
        Me.pnlFdd.ResumeLayout(False)
        Me.pnlVupType.ResumeLayout(False)
        Me.pnlVupType.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
