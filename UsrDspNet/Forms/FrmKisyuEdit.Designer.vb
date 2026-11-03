<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKisyuEdit
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
    Friend WithEvents lblPc As System.Windows.Forms.Label
    Friend WithEvents txtPc0 As System.Windows.Forms.TextBox
    Friend WithEvents lblPcSn As System.Windows.Forms.Label
    Friend WithEvents txtPc1 As System.Windows.Forms.TextBox
    Friend WithEvents lblPrt As System.Windows.Forms.Label
    Friend WithEvents cmbPrt0 As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrtSn As System.Windows.Forms.Label
    Friend WithEvents txtPrt1 As System.Windows.Forms.TextBox
    Friend WithEvents lblMn As System.Windows.Forms.Label
    Friend WithEvents txtMn0 As System.Windows.Forms.TextBox
    Friend WithEvents lblMnSn As System.Windows.Forms.Label
    Friend WithEvents txtMn1 As System.Windows.Forms.TextBox
    Friend WithEvents lblBcr As System.Windows.Forms.Label
    Friend WithEvents cmbBcr0 As System.Windows.Forms.ComboBox
    Friend WithEvents lblBcrSn As System.Windows.Forms.Label
    Friend WithEvents txtBcr1 As System.Windows.Forms.TextBox
    Friend WithEvents lblHdd As System.Windows.Forms.Label
    Friend WithEvents cmbHdd0 As System.Windows.Forms.ComboBox
    Friend WithEvents lblHddSn As System.Windows.Forms.Label
    Friend WithEvents txtHdd1 As System.Windows.Forms.TextBox
    Friend WithEvents lblMiniPrt As System.Windows.Forms.Label
    Friend WithEvents cmbMiniPrt0 As System.Windows.Forms.ComboBox
    Friend WithEvents lblMiniPrtSn As System.Windows.Forms.Label
    Friend WithEvents txtMiniPrt1 As System.Windows.Forms.TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnHistory As System.Windows.Forms.Button
    Friend WithEvents lblTantoInfo As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblPc = New System.Windows.Forms.Label()
        Me.txtPc0 = New System.Windows.Forms.TextBox()
        Me.lblPcSn = New System.Windows.Forms.Label()
        Me.txtPc1 = New System.Windows.Forms.TextBox()
        Me.lblPrt = New System.Windows.Forms.Label()
        Me.cmbPrt0 = New System.Windows.Forms.ComboBox()
        Me.lblPrtSn = New System.Windows.Forms.Label()
        Me.txtPrt1 = New System.Windows.Forms.TextBox()
        Me.lblMn = New System.Windows.Forms.Label()
        Me.txtMn0 = New System.Windows.Forms.TextBox()
        Me.lblMnSn = New System.Windows.Forms.Label()
        Me.txtMn1 = New System.Windows.Forms.TextBox()
        Me.lblBcr = New System.Windows.Forms.Label()
        Me.cmbBcr0 = New System.Windows.Forms.ComboBox()
        Me.lblBcrSn = New System.Windows.Forms.Label()
        Me.txtBcr1 = New System.Windows.Forms.TextBox()
        Me.lblHdd = New System.Windows.Forms.Label()
        Me.cmbHdd0 = New System.Windows.Forms.ComboBox()
        Me.lblHddSn = New System.Windows.Forms.Label()
        Me.txtHdd1 = New System.Windows.Forms.TextBox()
        Me.lblMiniPrt = New System.Windows.Forms.Label()
        Me.cmbMiniPrt0 = New System.Windows.Forms.ComboBox()
        Me.lblMiniPrtSn = New System.Windows.Forms.Label()
        Me.txtMiniPrt1 = New System.Windows.Forms.TextBox()
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
        Me.pnlTop.Size = New System.Drawing.Size(650, 32)
        Me.pnlTop.TabIndex = 26
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
        'lblPc
        '
        Me.lblPc.Location = New System.Drawing.Point(16, 48)
        Me.lblPc.Name = "lblPc"
        Me.lblPc.Size = New System.Drawing.Size(95, 20)
        Me.lblPc.TabIndex = 0
        Me.lblPc.Text = "本体"
        '
        'txtPc0
        '
        Me.txtPc0.Location = New System.Drawing.Point(114, 45)
        Me.txtPc0.Name = "txtPc0"
        Me.txtPc0.Size = New System.Drawing.Size(225, 23)
        Me.txtPc0.TabIndex = 1
        '
        'lblPcSn
        '
        Me.lblPcSn.Location = New System.Drawing.Point(346, 48)
        Me.lblPcSn.Name = "lblPcSn"
        Me.lblPcSn.Size = New System.Drawing.Size(32, 20)
        Me.lblPcSn.TabIndex = 2
        Me.lblPcSn.Text = "SN"
        '
        'txtPc1
        '
        Me.txtPc1.Location = New System.Drawing.Point(382, 45)
        Me.txtPc1.Name = "txtPc1"
        Me.txtPc1.Size = New System.Drawing.Size(252, 23)
        Me.txtPc1.TabIndex = 3
        '
        'lblPrt
        '
        Me.lblPrt.Location = New System.Drawing.Point(16, 80)
        Me.lblPrt.Name = "lblPrt"
        Me.lblPrt.Size = New System.Drawing.Size(95, 20)
        Me.lblPrt.TabIndex = 4
        Me.lblPrt.Text = "プリンタ"
        '
        'cmbPrt0
        '
        Me.cmbPrt0.FormattingEnabled = True
        Me.cmbPrt0.Location = New System.Drawing.Point(114, 77)
        Me.cmbPrt0.Name = "cmbPrt0"
        Me.cmbPrt0.Size = New System.Drawing.Size(225, 24)
        Me.cmbPrt0.TabIndex = 5
        '
        'lblPrtSn
        '
        Me.lblPrtSn.Location = New System.Drawing.Point(346, 80)
        Me.lblPrtSn.Name = "lblPrtSn"
        Me.lblPrtSn.Size = New System.Drawing.Size(32, 20)
        Me.lblPrtSn.TabIndex = 6
        Me.lblPrtSn.Text = "SN"
        '
        'txtPrt1
        '
        Me.txtPrt1.Location = New System.Drawing.Point(382, 77)
        Me.txtPrt1.Name = "txtPrt1"
        Me.txtPrt1.Size = New System.Drawing.Size(252, 23)
        Me.txtPrt1.TabIndex = 7
        '
        'lblMn
        '
        Me.lblMn.Location = New System.Drawing.Point(16, 112)
        Me.lblMn.Name = "lblMn"
        Me.lblMn.Size = New System.Drawing.Size(95, 20)
        Me.lblMn.TabIndex = 8
        Me.lblMn.Text = "モニタ"
        '
        'txtMn0
        '
        Me.txtMn0.Location = New System.Drawing.Point(114, 109)
        Me.txtMn0.Name = "txtMn0"
        Me.txtMn0.Size = New System.Drawing.Size(225, 23)
        Me.txtMn0.TabIndex = 9
        '
        'lblMnSn
        '
        Me.lblMnSn.Location = New System.Drawing.Point(346, 112)
        Me.lblMnSn.Name = "lblMnSn"
        Me.lblMnSn.Size = New System.Drawing.Size(32, 20)
        Me.lblMnSn.TabIndex = 10
        Me.lblMnSn.Text = "SN"
        '
        'txtMn1
        '
        Me.txtMn1.Location = New System.Drawing.Point(382, 109)
        Me.txtMn1.Name = "txtMn1"
        Me.txtMn1.Size = New System.Drawing.Size(252, 23)
        Me.txtMn1.TabIndex = 11
        '
        'lblBcr
        '
        Me.lblBcr.Location = New System.Drawing.Point(16, 144)
        Me.lblBcr.Name = "lblBcr"
        Me.lblBcr.Size = New System.Drawing.Size(95, 20)
        Me.lblBcr.TabIndex = 12
        Me.lblBcr.Text = "BCR"
        '
        'cmbBcr0
        '
        Me.cmbBcr0.FormattingEnabled = True
        Me.cmbBcr0.Location = New System.Drawing.Point(114, 141)
        Me.cmbBcr0.Name = "cmbBcr0"
        Me.cmbBcr0.Size = New System.Drawing.Size(225, 24)
        Me.cmbBcr0.TabIndex = 13
        '
        'lblBcrSn
        '
        Me.lblBcrSn.Location = New System.Drawing.Point(346, 144)
        Me.lblBcrSn.Name = "lblBcrSn"
        Me.lblBcrSn.Size = New System.Drawing.Size(32, 20)
        Me.lblBcrSn.TabIndex = 14
        Me.lblBcrSn.Text = "SN"
        '
        'txtBcr1
        '
        Me.txtBcr1.Location = New System.Drawing.Point(382, 141)
        Me.txtBcr1.Name = "txtBcr1"
        Me.txtBcr1.Size = New System.Drawing.Size(252, 23)
        Me.txtBcr1.TabIndex = 15
        '
        'lblHdd
        '
        Me.lblHdd.Location = New System.Drawing.Point(16, 176)
        Me.lblHdd.Name = "lblHdd"
        Me.lblHdd.Size = New System.Drawing.Size(95, 20)
        Me.lblHdd.TabIndex = 16
        Me.lblHdd.Text = "BkUp(HDD)"
        '
        'cmbHdd0
        '
        Me.cmbHdd0.FormattingEnabled = True
        Me.cmbHdd0.Location = New System.Drawing.Point(114, 173)
        Me.cmbHdd0.Name = "cmbHdd0"
        Me.cmbHdd0.Size = New System.Drawing.Size(225, 24)
        Me.cmbHdd0.TabIndex = 17
        '
        'lblHddSn
        '
        Me.lblHddSn.Location = New System.Drawing.Point(346, 176)
        Me.lblHddSn.Name = "lblHddSn"
        Me.lblHddSn.Size = New System.Drawing.Size(32, 20)
        Me.lblHddSn.TabIndex = 18
        Me.lblHddSn.Text = "SN"
        '
        'txtHdd1
        '
        Me.txtHdd1.Location = New System.Drawing.Point(382, 173)
        Me.txtHdd1.Name = "txtHdd1"
        Me.txtHdd1.Size = New System.Drawing.Size(252, 23)
        Me.txtHdd1.TabIndex = 19
        '
        'lblMiniPrt
        '
        Me.lblMiniPrt.Location = New System.Drawing.Point(16, 208)
        Me.lblMiniPrt.Name = "lblMiniPrt"
        Me.lblMiniPrt.Size = New System.Drawing.Size(95, 20)
        Me.lblMiniPrt.TabIndex = 20
        Me.lblMiniPrt.Text = "小型プリンタ"
        '
        'cmbMiniPrt0
        '
        Me.cmbMiniPrt0.FormattingEnabled = True
        Me.cmbMiniPrt0.Location = New System.Drawing.Point(114, 205)
        Me.cmbMiniPrt0.Name = "cmbMiniPrt0"
        Me.cmbMiniPrt0.Size = New System.Drawing.Size(225, 24)
        Me.cmbMiniPrt0.TabIndex = 21
        '
        'lblMiniPrtSn
        '
        Me.lblMiniPrtSn.Location = New System.Drawing.Point(346, 208)
        Me.lblMiniPrtSn.Name = "lblMiniPrtSn"
        Me.lblMiniPrtSn.Size = New System.Drawing.Size(32, 20)
        Me.lblMiniPrtSn.TabIndex = 22
        Me.lblMiniPrtSn.Text = "SN"
        '
        'txtMiniPrt1
        '
        Me.txtMiniPrt1.Location = New System.Drawing.Point(382, 205)
        Me.txtMiniPrt1.Name = "txtMiniPrt1"
        Me.txtMiniPrt1.Size = New System.Drawing.Size(252, 23)
        Me.txtMiniPrt1.TabIndex = 23
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(414, 252)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(105, 30)
        Me.btnOk.TabIndex = 24
        Me.btnOk.Text = "登録(&U)"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(529, 252)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(105, 30)
        Me.btnCancel.TabIndex = 25
        Me.btnCancel.Text = "キャンセル(&C)"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnHistory
        '
        Me.btnHistory.Location = New System.Drawing.Point(15, 252)
        Me.btnHistory.Name = "btnHistory"
        Me.btnHistory.Size = New System.Drawing.Size(110, 30)
        Me.btnHistory.TabIndex = 26
        Me.btnHistory.Text = "修正履歴(&H)..."
        Me.btnHistory.UseVisualStyleBackColor = True
        '
        'lblTantoInfo
        '
        Me.lblTantoInfo.AutoSize = True
        Me.lblTantoInfo.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblTantoInfo.ForeColor = System.Drawing.SystemColors.GrayText
        Me.lblTantoInfo.Location = New System.Drawing.Point(135, 260)
        Me.lblTantoInfo.Name = "lblTantoInfo"
        Me.lblTantoInfo.Size = New System.Drawing.Size(65, 13)
        Me.lblTantoInfo.TabIndex = 27
        Me.lblTantoInfo.Text = "担当: 未設定"
        '
        'FrmKisyuEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 296)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnHistory)
        Me.Controls.Add(Me.lblTantoInfo)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.txtMiniPrt1)
        Me.Controls.Add(Me.lblMiniPrtSn)
        Me.Controls.Add(Me.cmbMiniPrt0)
        Me.Controls.Add(Me.lblMiniPrt)
        Me.Controls.Add(Me.txtHdd1)
        Me.Controls.Add(Me.lblHddSn)
        Me.Controls.Add(Me.cmbHdd0)
        Me.Controls.Add(Me.lblHdd)
        Me.Controls.Add(Me.txtBcr1)
        Me.Controls.Add(Me.lblBcrSn)
        Me.Controls.Add(Me.cmbBcr0)
        Me.Controls.Add(Me.lblBcr)
        Me.Controls.Add(Me.txtMn1)
        Me.Controls.Add(Me.lblMnSn)
        Me.Controls.Add(Me.txtMn0)
        Me.Controls.Add(Me.lblMn)
        Me.Controls.Add(Me.txtPrt1)
        Me.Controls.Add(Me.lblPrtSn)
        Me.Controls.Add(Me.cmbPrt0)
        Me.Controls.Add(Me.lblPrt)
        Me.Controls.Add(Me.txtPc1)
        Me.Controls.Add(Me.lblPcSn)
        Me.Controls.Add(Me.txtPc0)
        Me.Controls.Add(Me.lblPc)
        Me.Controls.Add(Me.pnlTop)
        Me.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmKisyuEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "機種情報編集"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
