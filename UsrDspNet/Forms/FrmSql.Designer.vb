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

        ' 1. 団体区分パネル
        Me.pnlGroup.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlGroup.Location = New System.Drawing.Point(8, 8)
        Me.pnlGroup.Size = New System.Drawing.Size(674, 34)
        Me.optOsaka.Text = "大阪社団" : Me.optOsaka.Location = New System.Drawing.Point(8, 6) : Me.optOsaka.Size = New System.Drawing.Size(80, 20) : Me.optOsaka.Checked = True
        Me.optHyogo.Text = "兵庫社団" : Me.optHyogo.Location = New System.Drawing.Point(92, 6) : Me.optHyogo.Size = New System.Drawing.Size(80, 20)
        Me.optKojin.Text = "個人請求" : Me.optKojin.Location = New System.Drawing.Point(176, 6) : Me.optKojin.Size = New System.Drawing.Size(80, 20)
        Me.optKenju.Text = "健柔会" : Me.optKenju.Location = New System.Drawing.Point(260, 6) : Me.optKenju.Size = New System.Drawing.Size(74, 20)
        Me.optKakushin.Text = "革新会" : Me.optKakushin.Location = New System.Drawing.Point(338, 6) : Me.optKakushin.Size = New System.Drawing.Size(74, 20)
        Me.optSoken.Text = "柔整総研" : Me.optSoken.Location = New System.Drawing.Point(416, 6) : Me.optSoken.Size = New System.Drawing.Size(80, 20)
        Me.optZennichi.Text = "全日" : Me.optZennichi.Location = New System.Drawing.Point(500, 6) : Me.optZennichi.Size = New System.Drawing.Size(60, 20)
        Me.optIkusei.Text = "育成会" : Me.optIkusei.Location = New System.Drawing.Point(564, 6) : Me.optIkusei.Size = New System.Drawing.Size(74, 20) : Me.optIkusei.Visible = False
        Me.pnlGroup.Controls.AddRange(New System.Windows.Forms.Control() {Me.optOsaka, Me.optHyogo, Me.optKojin, Me.optKenju, Me.optKakushin, Me.optSoken, Me.optZennichi, Me.optIkusei})

        ' 2. 府県パネル
        Me.picKen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picKen.Location = New System.Drawing.Point(8, 46)
        Me.picKen.Size = New System.Drawing.Size(674, 34)
        Me.picKen.Visible = False
        Me.chkOsaka.Text = "大阪" : Me.chkOsaka.Location = New System.Drawing.Point(12, 6) : Me.chkOsaka.Size = New System.Drawing.Size(56, 20) : Me.chkOsaka.Checked = True
        Me.chkHyogo.Text = "兵庫" : Me.chkHyogo.Location = New System.Drawing.Point(72, 6) : Me.chkHyogo.Size = New System.Drawing.Size(56, 20) : Me.chkHyogo.Checked = True
        Me.chkKyoto.Text = "京都" : Me.chkKyoto.Location = New System.Drawing.Point(132, 6) : Me.chkKyoto.Size = New System.Drawing.Size(56, 20) : Me.chkKyoto.Checked = True
        Me.chkOita.Text = "大分" : Me.chkOita.Location = New System.Drawing.Point(192, 6) : Me.chkOita.Size = New System.Drawing.Size(56, 20) : Me.chkOita.Checked = True
        Me.chkMie.Text = "三重" : Me.chkMie.Location = New System.Drawing.Point(252, 6) : Me.chkMie.Size = New System.Drawing.Size(56, 20) : Me.chkMie.Checked = True
        Me.chkNara.Text = "奈良" : Me.chkNara.Location = New System.Drawing.Point(312, 6) : Me.chkNara.Size = New System.Drawing.Size(56, 20) : Me.chkNara.Checked = True
        Me.chkWakayama.Text = "和歌山" : Me.chkWakayama.Location = New System.Drawing.Point(372, 6) : Me.chkWakayama.Size = New System.Drawing.Size(68, 20) : Me.chkWakayama.Checked = True
        Me.chkEhime.Text = "愛媛" : Me.chkEhime.Location = New System.Drawing.Point(444, 6) : Me.chkEhime.Size = New System.Drawing.Size(56, 20) : Me.chkEhime.Checked = True
        Me.lblKenAll.Text = "すべて" : Me.lblKenAll.Location = New System.Drawing.Point(510, 8) : Me.lblKenAll.AutoSize = True : Me.lblKenAll.Visible = False
        Me.picKen.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkOsaka, Me.chkHyogo, Me.chkKyoto, Me.chkOita, Me.chkMie, Me.chkNara, Me.chkWakayama, Me.chkEhime, Me.lblKenAll})

        ' 3. OSパネル
        Me.pnlOs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlOs.Location = New System.Drawing.Point(8, 84)
        Me.pnlOs.Size = New System.Drawing.Size(674, 34)
        Me.chkXP.Text = "XP" : Me.chkXP.Location = New System.Drawing.Point(12, 6) : Me.chkXP.Size = New System.Drawing.Size(50, 20) : Me.chkXP.Checked = True
        Me.chkVista.Text = "Vista" : Me.chkVista.Location = New System.Drawing.Point(68, 6) : Me.chkVista.Size = New System.Drawing.Size(60, 20) : Me.chkVista.Checked = True
        Me.chkWindows7.Text = "Win7" : Me.chkWindows7.Location = New System.Drawing.Point(134, 6) : Me.chkWindows7.Size = New System.Drawing.Size(62, 20) : Me.chkWindows7.Checked = True
        Me.chkWindows8.Text = "Win8" : Me.chkWindows8.Location = New System.Drawing.Point(202, 6) : Me.chkWindows8.Size = New System.Drawing.Size(62, 20) : Me.chkWindows8.Checked = True
        Me.chkWindows10.Text = "Win10" : Me.chkWindows10.Location = New System.Drawing.Point(270, 6) : Me.chkWindows10.Size = New System.Drawing.Size(68, 20) : Me.chkWindows10.Checked = True
        Me.chkWindows11.Text = "Win11" : Me.chkWindows11.Location = New System.Drawing.Point(344, 6) : Me.chkWindows11.Size = New System.Drawing.Size(68, 20) : Me.chkWindows11.Checked = True
        Me.chkWin16.Text = "Win(16bit)" : Me.chkWin16.Location = New System.Drawing.Point(418, 6) : Me.chkWin16.Size = New System.Drawing.Size(90, 20)
        Me.lblOsAll.Text = "すべて" : Me.lblOsAll.Location = New System.Drawing.Point(520, 8) : Me.lblOsAll.AutoSize = True : Me.lblOsAll.Visible = False
        Me.pnlOs.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkXP, Me.chkVista, Me.chkWindows7, Me.chkWindows8, Me.chkWindows10, Me.chkWindows11, Me.chkWin16, Me.lblOsAll})

        ' 4. 本院パネル
        Me.pnlBunin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBunin.Location = New System.Drawing.Point(8, 122)
        Me.pnlBunin.Size = New System.Drawing.Size(674, 34)
        Me.optBunin.Text = "本院のみ" : Me.optBunin.Location = New System.Drawing.Point(16, 6) : Me.optBunin.Size = New System.Drawing.Size(100, 20)
        Me.optNotBunin.Text = "本院以外" : Me.optNotBunin.Location = New System.Drawing.Point(124, 6) : Me.optNotBunin.Size = New System.Drawing.Size(100, 20)
        Me.optBAll.Text = "両方" : Me.optBAll.Location = New System.Drawing.Point(330, 6) : Me.optBAll.Size = New System.Drawing.Size(70, 20) : Me.optBAll.Checked = True
        Me.pnlBunin.Controls.AddRange(New System.Windows.Forms.Control() {Me.optBunin, Me.optNotBunin, Me.optBAll})

        ' 5. 会計処理パネル
        Me.picKaikei.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picKaikei.Location = New System.Drawing.Point(8, 160)
        Me.picKaikei.Size = New System.Drawing.Size(674, 34)
        Me.optKaikei.Text = "会計処理のみ" : Me.optKaikei.Location = New System.Drawing.Point(16, 6) : Me.optKaikei.Size = New System.Drawing.Size(106, 20)
        Me.optNotKaikei.Text = "会計処理以外" : Me.optNotKaikei.Location = New System.Drawing.Point(128, 6) : Me.optNotKaikei.Size = New System.Drawing.Size(106, 20)
        Me.optKAll.Text = "両方" : Me.optKAll.Location = New System.Drawing.Point(330, 6) : Me.optKAll.Size = New System.Drawing.Size(70, 20) : Me.optKAll.Checked = True
        Me.picKaikei.Controls.AddRange(New System.Windows.Forms.Control() {Me.optKaikei, Me.optNotKaikei, Me.optKAll})

        ' 6. FDDパネル
        Me.pnlFdd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFdd.Location = New System.Drawing.Point(8, 198)
        Me.pnlFdd.Size = New System.Drawing.Size(674, 34)
        Me.OptNoFdd.Text = "FDD無し のみ" : Me.OptNoFdd.Location = New System.Drawing.Point(16, 6) : Me.OptNoFdd.Size = New System.Drawing.Size(106, 20)
        Me.OptFdd.Text = "FDD無し 以外" : Me.OptFdd.Location = New System.Drawing.Point(128, 6) : Me.OptFdd.Size = New System.Drawing.Size(106, 20)
        Me.optFddAll.Text = "両方" : Me.optFddAll.Location = New System.Drawing.Point(330, 6) : Me.optFddAll.Size = New System.Drawing.Size(70, 20) : Me.optFddAll.Checked = True
        Me.pnlFdd.Controls.AddRange(New System.Windows.Forms.Control() {Me.OptNoFdd, Me.OptFdd, Me.optFddAll})

        ' 7. バージョンアップ方法パネル
        Me.pnlVupType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlVupType.Location = New System.Drawing.Point(8, 236)
        Me.pnlVupType.Size = New System.Drawing.Size(674, 34)
        Me.lblVupType.Text = "バージョンアップ方法:" : Me.lblVupType.Location = New System.Drawing.Point(12, 8) : Me.lblVupType.AutoSize = True
        Me.chkVupMitei.Text = "未定" : Me.chkVupMitei.Location = New System.Drawing.Point(150, 6) : Me.chkVupMitei.Size = New System.Drawing.Size(70, 20) : Me.chkVupMitei.Checked = True
        Me.chkVupNet.Text = "ネット" : Me.chkVupNet.Location = New System.Drawing.Point(230, 6) : Me.chkVupNet.Size = New System.Drawing.Size(76, 20) : Me.chkVupNet.Checked = True
        Me.chkVupCd.Text = "CD" : Me.chkVupCd.Location = New System.Drawing.Point(316, 6) : Me.chkVupCd.Size = New System.Drawing.Size(70, 20) : Me.chkVupCd.Checked = True
        Me.pnlVupType.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblVupType, Me.chkVupMitei, Me.chkVupNet, Me.chkVupCd})

        ' SQLテキストボックス
        Me.txtSql.Font = New System.Drawing.Font("ＭＳ ゴシック", 11.25!)
        Me.txtSql.Location = New System.Drawing.Point(8, 276)
        Me.txtSql.Multiline = True
        Me.txtSql.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSql.Size = New System.Drawing.Size(674, 292)

        ' SQL確認・生成・印刷ボタン群
        Me.cmdSqlCheck.Location = New System.Drawing.Point(8, 576)
        Me.cmdSqlCheck.Size = New System.Drawing.Size(100, 28)
        Me.cmdSqlCheck.Text = "件数確認"
        Me.cmdSqlCheck.UseVisualStyleBackColor = True

        Me.lblCnt.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblCnt.Location = New System.Drawing.Point(116, 580)
        Me.lblCnt.Size = New System.Drawing.Size(270, 24)
        Me.lblCnt.Text = "0件 該当"

        Me.cmdMakeSql.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 10.5!)
        Me.cmdMakeSql.Location = New System.Drawing.Point(392, 574)
        Me.cmdMakeSql.Size = New System.Drawing.Size(110, 32)
        Me.cmdMakeSql.Text = "SQL文作成"
        Me.cmdMakeSql.UseVisualStyleBackColor = True

        Me.Command1.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Command1.Location = New System.Drawing.Point(510, 574)
        Me.Command1.Size = New System.Drawing.Size(172, 32)
        Me.Command1.Text = "上記SQL文で印刷画面へ"
        Me.Command1.UseVisualStyleBackColor = True

        ' 下部出力パネル (Picture2)
        Me.pnlActions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlActions.Location = New System.Drawing.Point(8, 612)
        Me.pnlActions.Size = New System.Drawing.Size(420, 150)

        Me.Command3.Location = New System.Drawing.Point(10, 10)
        Me.Command3.Size = New System.Drawing.Size(110, 28)
        Me.Command3.Text = "画面表示"
        Me.Command3.UseVisualStyleBackColor = True

        Me.Command2.Location = New System.Drawing.Point(10, 44)
        Me.Command2.Size = New System.Drawing.Size(110, 28)
        Me.Command2.Text = "csv出力"
        Me.Command2.UseVisualStyleBackColor = True

        Me.chkWC.Checked = True
        Me.chkWC.Location = New System.Drawing.Point(132, 48)
        Me.chkWC.Size = New System.Drawing.Size(190, 22)
        Me.chkWC.Text = "ダブルコーテーション付き"

        Me.cmdSagawa.Location = New System.Drawing.Point(10, 80)
        Me.cmdSagawa.Size = New System.Drawing.Size(340, 28)
        Me.cmdSagawa.Text = "飛脚メール便出力 （NAS001\開発\飛脚メール便）"
        Me.cmdSagawa.UseVisualStyleBackColor = True

        Me.cmdSagawaAd.Location = New System.Drawing.Point(10, 114)
        Me.cmdSagawaAd.Size = New System.Drawing.Size(340, 28)
        Me.cmdSagawaAd.Text = "佐川急便住所録 （NAS001\開発\佐川急便住所録）"
        Me.cmdSagawaAd.UseVisualStyleBackColor = True

        Me.pnlActions.Controls.AddRange(New System.Windows.Forms.Control() {Me.Command3, Me.Command2, Me.chkWC, Me.cmdSagawa, Me.cmdSagawaAd})

        ' FrmSql
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 772)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {
            Me.pnlGroup, Me.picKen, Me.pnlOs, Me.pnlBunin, Me.picKaikei, Me.pnlFdd, Me.pnlVupType,
            Me.txtSql, Me.cmdSqlCheck, Me.lblCnt, Me.cmdMakeSql, Me.Command1, Me.pnlActions
        })
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
