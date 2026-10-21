<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FindDlg
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
    Public WithEvents CmbFind As System.Windows.Forms.ComboBox
    Public WithEvents OptPrefix As System.Windows.Forms.RadioButton
    Public WithEvents OptContains As System.Windows.Forms.RadioButton
    Public WithEvents OKButton As System.Windows.Forms.Button
    Public WithEvents CancelBtn As System.Windows.Forms.Button
    Public WithEvents LblKm As System.Windows.Forms.Label
    Private WithEvents pnlLine As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CmbFind = New System.Windows.Forms.ComboBox()
        Me.OptPrefix = New System.Windows.Forms.RadioButton()
        Me.OptContains = New System.Windows.Forms.RadioButton()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.CancelBtn = New System.Windows.Forms.Button()
        Me.LblKm = New System.Windows.Forms.Label()
        Me.pnlLine = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'LblKm
        '
        Me.LblKm.AutoSize = True
        Me.LblKm.Location = New System.Drawing.Point(12, 10)
        Me.LblKm.Name = "LblKm"
        Me.LblKm.Size = New System.Drawing.Size(175, 15)
        Me.LblKm.TabIndex = 5
        Me.LblKm.Text = "検索する文字を入力してください"
        '
        'CmbFind
        '
        Me.CmbFind.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CmbFind.Location = New System.Drawing.Point(12, 34)
        Me.CmbFind.Name = "CmbFind"
        Me.CmbFind.Size = New System.Drawing.Size(310, 24)
        Me.CmbFind.TabIndex = 0
        '
        'pnlLine
        '
        Me.pnlLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlLine.Location = New System.Drawing.Point(12, 68)
        Me.pnlLine.Name = "pnlLine"
        Me.pnlLine.Size = New System.Drawing.Size(310, 2)
        Me.pnlLine.TabIndex = 6
        '
        'OptPrefix
        '
        Me.OptPrefix.AutoSize = True
        Me.OptPrefix.Location = New System.Drawing.Point(16, 78)
        Me.OptPrefix.Name = "OptPrefix"
        Me.OptPrefix.Size = New System.Drawing.Size(158, 19)
        Me.OptPrefix.TabIndex = 1
        Me.OptPrefix.Text = "先頭が一致するものを検索"
        Me.OptPrefix.UseVisualStyleBackColor = True
        '
        'OptContains
        '
        Me.OptContains.AutoSize = True
        Me.OptContains.Checked = True
        Me.OptContains.Location = New System.Drawing.Point(16, 102)
        Me.OptContains.Name = "OptContains"
        Me.OptContains.Size = New System.Drawing.Size(166, 19)
        Me.OptContains.TabIndex = 2
        Me.OptContains.TabStop = True
        Me.OptContains.Text = "指定した文字を含むものを検索"
        Me.OptContains.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(338, 12)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(90, 30)
        Me.OKButton.TabIndex = 3
        Me.OKButton.Text = "検索"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'CancelBtn
        '
        Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelBtn.Location = New System.Drawing.Point(338, 48)
        Me.CancelBtn.Name = "CancelBtn"
        Me.CancelBtn.Size = New System.Drawing.Size(90, 30)
        Me.CancelBtn.TabIndex = 4
        Me.CancelBtn.Text = "キャンセル"
        Me.CancelBtn.UseVisualStyleBackColor = True
        '
        'FindDlg
        '
        Me.AcceptButton = Me.OKButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CancelBtn
        Me.ClientSize = New System.Drawing.Size(442, 134)
        Me.Controls.Add(Me.LblKm)
        Me.Controls.Add(Me.CmbFind)
        Me.Controls.Add(Me.pnlLine)
        Me.Controls.Add(Me.OptPrefix)
        Me.Controls.Add(Me.OptContains)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.CancelBtn)
        Me.Font = New System.Drawing.Font("ＭＳ Ｐゴシック", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindDlg"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "検索"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
End Class
