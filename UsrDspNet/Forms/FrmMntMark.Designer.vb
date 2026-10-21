Imports System.Drawing
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMntMark
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
    Friend WithEvents lblPrompt As Label
    Friend WithEvents cmbMark As ComboBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnClose As Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblPrompt = New Label()
        Me.cmbMark = New ComboBox()
        Me.btnSearch = New Button()
        Me.btnClear = New Button()
        Me.btnClose = New Button()
        Me.SuspendLayout()

        Me.AutoScaleDimensions = New SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(390, 118)
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Font = New Font("MS UI Gothic", 9.75!)
        Me.Name = "FrmMntMark"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.Text = "メンテナンス記録内 キーワード強調検索"

        Me.lblPrompt.Text = "検索・強調表示するキーワードを入力してください:"
        Me.lblPrompt.Location = New Point(12, 12)
        Me.lblPrompt.Size = New Size(360, 20)

        Me.cmbMark.Location = New Point(12, 36)
        Me.cmbMark.Size = New Size(364, 24)
        Me.cmbMark.Font = New Font("ＭＳ ゴシック", 10.5!)
        Me.cmbMark.ImeMode = ImeMode.On

        Me.btnSearch.Text = "検索・マーク(&F)"
        Me.btnSearch.Font = New Font("MS UI Gothic", 9.75!, FontStyle.Bold)
        Me.btnSearch.Location = New Point(95, 74)
        Me.btnSearch.Size = New Size(110, 32)

        Me.btnClear.Text = "解除(&R)"
        Me.btnClear.Location = New Point(211, 74)
        Me.btnClear.Size = New Size(78, 32)

        Me.btnClose.Text = "閉じる(&C)"
        Me.btnClose.Location = New Point(295, 74)
        Me.btnClose.Size = New Size(82, 32)

        Me.AcceptButton = Me.btnSearch
        Me.CancelButton = Me.btnClose

        Me.Controls.AddRange(New Control() {Me.lblPrompt, Me.cmbMark, Me.btnSearch, Me.btnClear, Me.btnClose})
        Me.ResumeLayout(False)
    End Sub
End Class
