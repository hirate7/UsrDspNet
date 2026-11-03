<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsrEdit
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
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

    Friend WithEvents pnlTop As System.Windows.Forms.Panel
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents lblDel As System.Windows.Forms.Label
    Friend WithEvents rdoDel1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDel2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDel3 As System.Windows.Forms.RadioButton
    Friend WithEvents lblVer As System.Windows.Forms.Label
    Friend WithEvents cmbVer As System.Windows.Forms.ComboBox
    Friend WithEvents lblSibu As System.Windows.Forms.Label
    Friend WithEvents cmbSibu As System.Windows.Forms.ComboBox
    Friend WithEvents lblTel As System.Windows.Forms.Label
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents lblSjName As System.Windows.Forms.Label
    Friend WithEvents txtSjName As System.Windows.Forms.TextBox
    Friend WithEvents lblSjNameF As System.Windows.Forms.Label
    Friend WithEvents txtSjNameF As System.Windows.Forms.TextBox
    Friend WithEvents lblJsName As System.Windows.Forms.Label
    Friend WithEvents txtJsName As System.Windows.Forms.TextBox
    Friend WithEvents lblJsNameF As System.Windows.Forms.Label
    Friend WithEvents txtJsNameF As System.Windows.Forms.TextBox
    Friend WithEvents lblZip As System.Windows.Forms.Label
    Friend WithEvents txtZip As System.Windows.Forms.TextBox
    Friend WithEvents lblAd1 As System.Windows.Forms.Label
    Friend WithEvents txtAd1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAd2 As System.Windows.Forms.Label
    Friend WithEvents txtAd2 As System.Windows.Forms.TextBox
    Friend WithEvents lblSinryou As System.Windows.Forms.Label
    Friend WithEvents txtSinryou As System.Windows.Forms.TextBox
    Friend WithEvents lblBikou As System.Windows.Forms.Label
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents lblTantoInfo As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblDel = New System.Windows.Forms.Label()
        Me.rdoDel1 = New System.Windows.Forms.RadioButton()
        Me.rdoDel2 = New System.Windows.Forms.RadioButton()
        Me.rdoDel3 = New System.Windows.Forms.RadioButton()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.cmbVer = New System.Windows.Forms.ComboBox()
        Me.lblSibu = New System.Windows.Forms.Label()
        Me.cmbSibu = New System.Windows.Forms.ComboBox()
        Me.lblTel = New System.Windows.Forms.Label()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.lblSjName = New System.Windows.Forms.Label()
        Me.txtSjName = New System.Windows.Forms.TextBox()
        Me.lblSjNameF = New System.Windows.Forms.Label()
        Me.txtSjNameF = New System.Windows.Forms.TextBox()
        Me.lblJsName = New System.Windows.Forms.Label()
        Me.txtJsName = New System.Windows.Forms.TextBox()
        Me.lblJsNameF = New System.Windows.Forms.Label()
        Me.txtJsNameF = New System.Windows.Forms.TextBox()
        Me.lblZip = New System.Windows.Forms.Label()
        Me.txtZip = New System.Windows.Forms.TextBox()
        Me.lblAd1 = New System.Windows.Forms.Label()
        Me.txtAd1 = New System.Windows.Forms.TextBox()
        Me.lblAd2 = New System.Windows.Forms.Label()
        Me.txtAd2 = New System.Windows.Forms.TextBox()
        Me.lblSinryou = New System.Windows.Forms.Label()
        Me.txtSinryou = New System.Windows.Forms.TextBox()
        Me.lblBikou = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnHistory = New System.Windows.Forms.Button()
        Me.lblTantoInfo = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.pnlTop.Controls.Add(Me.lblUser)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(666, 32)
        Me.pnlTop.TabIndex = 30
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(12, 8)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(100, 16)
        Me.lblUser.TabIndex = 0
        Me.lblUser.Text = "ユーザー情報"
        '
        'lblDel
        '
        Me.lblDel.Location = New System.Drawing.Point(16, 47)
        Me.lblDel.Name = "lblDel"
        Me.lblDel.Size = New System.Drawing.Size(60, 20)
        Me.lblDel.TabIndex = 0
        Me.lblDel.Text = "区分"
        '
        'rdoDel1
        '
        Me.rdoDel1.AutoSize = True
        Me.rdoDel1.Location = New System.Drawing.Point(85, 45)
        Me.rdoDel1.Name = "rdoDel1"
        Me.rdoDel1.Size = New System.Drawing.Size(76, 20)
        Me.rdoDel1.TabIndex = 1
        Me.rdoDel1.TabStop = True
        Me.rdoDel1.Text = "1.通常"
        Me.rdoDel1.UseVisualStyleBackColor = True
        '
        'rdoDel2
        '
        Me.rdoDel2.AutoSize = True
        Me.rdoDel2.Location = New System.Drawing.Point(195, 45)
        Me.rdoDel2.Name = "rdoDel2"
        Me.rdoDel2.Size = New System.Drawing.Size(76, 20)
        Me.rdoDel2.TabIndex = 2
        Me.rdoDel2.TabStop = True
        Me.rdoDel2.Text = "2.削除"
        Me.rdoDel2.UseVisualStyleBackColor = True
        '
        'rdoDel3
        '
        Me.rdoDel3.AutoSize = True
        Me.rdoDel3.Location = New System.Drawing.Point(305, 45)
        Me.rdoDel3.Name = "rdoDel3"
        Me.rdoDel3.Size = New System.Drawing.Size(96, 20)
        Me.rdoDel3.TabIndex = 3
        Me.rdoDel3.TabStop = True
        Me.rdoDel3.Text = "3.一時休止"
        Me.rdoDel3.UseVisualStyleBackColor = True
        '
        'lblVer
        '
        Me.lblVer.Location = New System.Drawing.Point(16, 82)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(60, 20)
        Me.lblVer.TabIndex = 4
        Me.lblVer.Text = "Ver"
        '
        'cmbVer
        '
        Me.cmbVer.FormattingEnabled = True
        Me.cmbVer.Location = New System.Drawing.Point(76, 79)
        Me.cmbVer.Name = "cmbVer"
        Me.cmbVer.Size = New System.Drawing.Size(160, 24)
        Me.cmbVer.TabIndex = 5
        '
        'lblSibu
        '
        Me.lblSibu.Location = New System.Drawing.Point(248, 82)
        Me.lblSibu.Name = "lblSibu"
        Me.lblSibu.Size = New System.Drawing.Size(60, 20)
        Me.lblSibu.TabIndex = 6
        Me.lblSibu.Text = "支部名"
        '
        'cmbSibu
        '
        Me.cmbSibu.FormattingEnabled = True
        Me.cmbSibu.Location = New System.Drawing.Point(312, 79)
        Me.cmbSibu.Name = "cmbSibu"
        Me.cmbSibu.Size = New System.Drawing.Size(150, 24)
        Me.cmbSibu.TabIndex = 7
        '
        'lblTel
        '
        Me.lblTel.Location = New System.Drawing.Point(474, 82)
        Me.lblTel.Name = "lblTel"
        Me.lblTel.Size = New System.Drawing.Size(42, 20)
        Me.lblTel.TabIndex = 8
        Me.lblTel.Text = "TEL"
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(520, 79)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(130, 23)
        Me.txtTel.TabIndex = 9
        '
        'lblSjName
        '
        Me.lblSjName.Location = New System.Drawing.Point(16, 116)
        Me.lblSjName.Name = "lblSjName"
        Me.lblSjName.Size = New System.Drawing.Size(95, 20)
        Me.lblSjName.TabIndex = 10
        Me.lblSjName.Text = "施術所名称"
        '
        'txtSjName
        '
        Me.txtSjName.Location = New System.Drawing.Point(115, 113)
        Me.txtSjName.Name = "txtSjName"
        Me.txtSjName.Size = New System.Drawing.Size(535, 23)
        Me.txtSjName.TabIndex = 11
        '
        'lblSjNameF
        '
        Me.lblSjNameF.Location = New System.Drawing.Point(16, 148)
        Me.lblSjNameF.Name = "lblSjNameF"
        Me.lblSjNameF.Size = New System.Drawing.Size(95, 20)
        Me.lblSjNameF.TabIndex = 12
        Me.lblSjNameF.Text = "施術所カナ"
        '
        'txtSjNameF
        '
        Me.txtSjNameF.Location = New System.Drawing.Point(115, 145)
        Me.txtSjNameF.Name = "txtSjNameF"
        Me.txtSjNameF.Size = New System.Drawing.Size(535, 23)
        Me.txtSjNameF.TabIndex = 13
        '
        'lblJsName
        '
        Me.lblJsName.Location = New System.Drawing.Point(16, 180)
        Me.lblJsName.Name = "lblJsName"
        Me.lblJsName.Size = New System.Drawing.Size(95, 20)
        Me.lblJsName.TabIndex = 14
        Me.lblJsName.Text = "柔整師名"
        '
        'txtJsName
        '
        Me.txtJsName.Location = New System.Drawing.Point(115, 177)
        Me.txtJsName.Name = "txtJsName"
        Me.txtJsName.Size = New System.Drawing.Size(210, 23)
        Me.txtJsName.TabIndex = 15
        '
        'lblJsNameF
        '
        Me.lblJsNameF.Location = New System.Drawing.Point(340, 180)
        Me.lblJsNameF.Name = "lblJsNameF"
        Me.lblJsNameF.Size = New System.Drawing.Size(75, 20)
        Me.lblJsNameF.TabIndex = 16
        Me.lblJsNameF.Text = "フリガナ"
        '
        'txtJsNameF
        '
        Me.txtJsNameF.Location = New System.Drawing.Point(420, 177)
        Me.txtJsNameF.Name = "txtJsNameF"
        Me.txtJsNameF.Size = New System.Drawing.Size(230, 23)
        Me.txtJsNameF.TabIndex = 17
        '
        'lblZip
        '
        Me.lblZip.Location = New System.Drawing.Point(16, 214)
        Me.lblZip.Name = "lblZip"
        Me.lblZip.Size = New System.Drawing.Size(95, 20)
        Me.lblZip.TabIndex = 18
        Me.lblZip.Text = "郵便番号"
        '
        'txtZip
        '
        Me.txtZip.Location = New System.Drawing.Point(115, 211)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.Size = New System.Drawing.Size(140, 23)
        Me.txtZip.TabIndex = 19
        '
        'lblAd1
        '
        Me.lblAd1.Location = New System.Drawing.Point(16, 246)
        Me.lblAd1.Name = "lblAd1"
        Me.lblAd1.Size = New System.Drawing.Size(95, 20)
        Me.lblAd1.TabIndex = 20
        Me.lblAd1.Text = "住所1"
        '
        'txtAd1
        '
        Me.txtAd1.Location = New System.Drawing.Point(115, 243)
        Me.txtAd1.Name = "txtAd1"
        Me.txtAd1.Size = New System.Drawing.Size(535, 23)
        Me.txtAd1.TabIndex = 21
        '
        'lblAd2
        '
        Me.lblAd2.Location = New System.Drawing.Point(16, 278)
        Me.lblAd2.Name = "lblAd2"
        Me.lblAd2.Size = New System.Drawing.Size(95, 20)
        Me.lblAd2.TabIndex = 22
        Me.lblAd2.Text = "住所2"
        '
        'txtAd2
        '
        Me.txtAd2.Location = New System.Drawing.Point(115, 275)
        Me.txtAd2.Name = "txtAd2"
        Me.txtAd2.Size = New System.Drawing.Size(535, 23)
        Me.txtAd2.TabIndex = 23
        '
        'lblSinryou
        '
        Me.lblSinryou.Location = New System.Drawing.Point(16, 312)
        Me.lblSinryou.Name = "lblSinryou"
        Me.lblSinryou.Size = New System.Drawing.Size(95, 20)
        Me.lblSinryou.TabIndex = 24
        Me.lblSinryou.Text = "診療時間"
        '
        'txtSinryou
        '
        Me.txtSinryou.Location = New System.Drawing.Point(115, 309)
        Me.txtSinryou.Multiline = True
        Me.txtSinryou.Name = "txtSinryou"
        Me.txtSinryou.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSinryou.Size = New System.Drawing.Size(535, 60)
        Me.txtSinryou.TabIndex = 25
        '
        'lblBikou
        '
        Me.lblBikou.Location = New System.Drawing.Point(16, 382)
        Me.lblBikou.Name = "lblBikou"
        Me.lblBikou.Size = New System.Drawing.Size(95, 20)
        Me.lblBikou.TabIndex = 26
        Me.lblBikou.Text = "備考"
        '
        'txtMemo
        '
        Me.txtMemo.Location = New System.Drawing.Point(115, 379)
        Me.txtMemo.Multiline = True
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMemo.Size = New System.Drawing.Size(535, 80)
        Me.txtMemo.TabIndex = 27
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(425, 472)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(105, 32)
        Me.btnOk.TabIndex = 28
        Me.btnOk.Text = "登録(&U)"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(545, 472)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 32)
        Me.btnCancel.TabIndex = 29
        Me.btnCancel.Text = "キャンセル(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Location = New System.Drawing.Point(15, 472)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(110, 32)
        Me.btnHistory.TabIndex = 30
        Me.btnHistory.Text = "修正履歴(&H)..."
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'lblTantoInfo
        '
        Me.lblTantoInfo.AutoSize = True
        Me.lblTantoInfo.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTantoInfo.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblTantoInfo.Location = New System.Drawing.Point(135, 481)
        Me.lblTantoInfo.Name = "lblTantoInfo"
        Me.lblTantoInfo.Size = New System.Drawing.Size(65, 13)
        Me.lblTantoInfo.TabIndex = 31
        Me.lblTantoInfo.Text = "担当: 未設定"
        '
        'FrmUsrEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 516)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.lblTantoInfo)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.lblBikou)
        Me.Controls.Add(Me.txtSinryou)
        Me.Controls.Add(Me.lblSinryou)
        Me.Controls.Add(Me.txtAd2)
        Me.Controls.Add(Me.lblAd2)
        Me.Controls.Add(Me.txtAd1)
        Me.Controls.Add(Me.lblAd1)
        Me.Controls.Add(Me.txtZip)
        Me.Controls.Add(Me.lblZip)
        Me.Controls.Add(Me.txtJsNameF)
        Me.Controls.Add(Me.lblJsNameF)
        Me.Controls.Add(Me.txtJsName)
        Me.Controls.Add(Me.lblJsName)
        Me.Controls.Add(Me.txtSjNameF)
        Me.Controls.Add(Me.lblSjNameF)
        Me.Controls.Add(Me.txtSjName)
        Me.Controls.Add(Me.lblSjName)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.lblTel)
        Me.Controls.Add(Me.cmbSibu)
        Me.Controls.Add(Me.lblSibu)
        Me.Controls.Add(Me.cmbVer)
        Me.Controls.Add(Me.lblVer)
        Me.Controls.Add(Me.rdoDel3)
        Me.Controls.Add(Me.rdoDel2)
        Me.Controls.Add(Me.rdoDel1)
        Me.Controls.Add(Me.lblDel)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUsrEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ユーザー基本情報・住所編集"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
