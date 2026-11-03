<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsrRrkViewer
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
    Friend WithEvents lblUserHeader As System.Windows.Forms.Label
    Friend WithEvents tabControl As System.Windows.Forms.TabControl
    Friend WithEvents tabIndividual As System.Windows.Forms.TabPage
    Friend WithEvents tabAllSearch As System.Windows.Forms.TabPage
    Friend WithEvents splitIndividual As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvEntries As System.Windows.Forms.DataGridView
    Friend WithEvents dgvChanges As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlSearchTop As System.Windows.Forms.Panel
    Friend WithEvents lblSince As System.Windows.Forms.Label
    Friend WithEvents dtpSearchDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpSearchTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearchAll As System.Windows.Forms.Button
    Friend WithEvents lblSearchResult As System.Windows.Forms.Label
    Friend WithEvents dgvAllResults As System.Windows.Forms.DataGridView

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim dataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim dataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblUserHeader = New System.Windows.Forms.Label()
        Me.tabControl = New System.Windows.Forms.TabControl()
        Me.tabIndividual = New System.Windows.Forms.TabPage()
        Me.splitIndividual = New System.Windows.Forms.SplitContainer()
        Me.dgvEntries = New System.Windows.Forms.DataGridView()
        Me.dgvChanges = New System.Windows.Forms.DataGridView()
        Me.tabAllSearch = New System.Windows.Forms.TabPage()
        Me.dgvAllResults = New System.Windows.Forms.DataGridView()
        Me.pnlSearchTop = New System.Windows.Forms.Panel()
        Me.lblSearchResult = New System.Windows.Forms.Label()
        Me.btnSearchAll = New System.Windows.Forms.Button()
        Me.dtpSearchTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpSearchDate = New System.Windows.Forms.DateTimePicker()
        Me.lblSince = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.pnlTop.SuspendLayout()
        Me.tabControl.SuspendLayout()
        Me.tabIndividual.SuspendLayout()
        CType(Me.splitIndividual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitIndividual.Panel1.SuspendLayout()
        Me.splitIndividual.Panel2.SuspendLayout()
        Me.splitIndividual.SuspendLayout()
        CType(Me.dgvEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvChanges, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabAllSearch.SuspendLayout()
        CType(Me.dgvAllResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSearchTop.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.pnlTop.Controls.Add(Me.lblUserHeader)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(820, 38)
        Me.pnlTop.TabIndex = 0
        '
        'lblUserHeader
        '
        Me.lblUserHeader.AutoSize = True
        Me.lblUserHeader.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblUserHeader.Location = New System.Drawing.Point(12, 11)
        Me.lblUserHeader.Name = "lblUserHeader"
        Me.lblUserHeader.Size = New System.Drawing.Size(127, 15)
        Me.lblUserHeader.TabIndex = 0
        Me.lblUserHeader.Text = "ユーザー修正履歴"
        '
        'tabControl
        '
        Me.tabControl.Controls.Add(Me.tabIndividual)
        Me.tabControl.Controls.Add(Me.tabAllSearch)
        Me.tabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl.Font = New System.Drawing.Font("MS UI Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.tabControl.Location = New System.Drawing.Point(0, 38)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.SelectedIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(820, 464)
        Me.tabControl.TabIndex = 1
        '
        'tabIndividual
        '
        Me.tabIndividual.Controls.Add(Me.splitIndividual)
        Me.tabIndividual.Location = New System.Drawing.Point(4, 23)
        Me.tabIndividual.Name = "tabIndividual"
        Me.tabIndividual.Padding = New System.Windows.Forms.Padding(3)
        Me.tabIndividual.Size = New System.Drawing.Size(812, 437)
        Me.tabIndividual.TabIndex = 0
        Me.tabIndividual.Text = "個別ユーザー修正履歴"
        Me.tabIndividual.UseVisualStyleBackColor = True
        '
        'splitIndividual
        '
        Me.splitIndividual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitIndividual.Location = New System.Drawing.Point(3, 3)
        Me.splitIndividual.Name = "splitIndividual"
        '
        'splitIndividual.Panel1
        '
        Me.splitIndividual.Panel1.Controls.Add(Me.dgvEntries)
        '
        'splitIndividual.Panel2
        '
        Me.splitIndividual.Panel2.Controls.Add(Me.dgvChanges)
        Me.splitIndividual.Size = New System.Drawing.Size(806, 431)
        Me.splitIndividual.SplitterDistance = 330
        Me.splitIndividual.TabIndex = 0
        '
        'dgvEntries
        '
        Me.dgvEntries.AllowUserToAddRows = False
        Me.dgvEntries.AllowUserToDeleteRows = False
        Me.dgvEntries.AllowUserToResizeRows = False
        Me.dgvEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEntries.BackgroundColor = System.Drawing.Color.White
        Me.dgvEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEntries.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEntries.Location = New System.Drawing.Point(0, 0)
        Me.dgvEntries.MultiSelect = False
        Me.dgvEntries.Name = "dgvEntries"
        Me.dgvEntries.ReadOnly = True
        Me.dgvEntries.RowHeadersVisible = False
        Me.dgvEntries.RowTemplate.Height = 24
        Me.dgvEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEntries.Size = New System.Drawing.Size(330, 431)
        Me.dgvEntries.TabIndex = 0
        '
        'dgvChanges
        '
        Me.dgvChanges.AllowUserToAddRows = False
        Me.dgvChanges.AllowUserToDeleteRows = False
        Me.dgvChanges.AllowUserToResizeRows = False
        Me.dgvChanges.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvChanges.BackgroundColor = System.Drawing.Color.White
        Me.dgvChanges.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvChanges.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvChanges.Location = New System.Drawing.Point(0, 0)
        Me.dgvChanges.MultiSelect = False
        Me.dgvChanges.Name = "dgvChanges"
        Me.dgvChanges.ReadOnly = True
        Me.dgvChanges.RowHeadersVisible = False
        Me.dgvChanges.RowTemplate.Height = 24
        Me.dgvChanges.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvChanges.Size = New System.Drawing.Size(472, 431)
        Me.dgvChanges.TabIndex = 0
        '
        'tabAllSearch
        '
        Me.tabAllSearch.Controls.Add(Me.dgvAllResults)
        Me.tabAllSearch.Controls.Add(Me.pnlSearchTop)
        Me.tabAllSearch.Location = New System.Drawing.Point(4, 23)
        Me.tabAllSearch.Name = "tabAllSearch"
        Me.tabAllSearch.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAllSearch.Size = New System.Drawing.Size(812, 437)
        Me.tabAllSearch.TabIndex = 1
        Me.tabAllSearch.Text = "指定日時以降の修正検索"
        Me.tabAllSearch.UseVisualStyleBackColor = True
        '
        'dgvAllResults
        '
        Me.dgvAllResults.AllowUserToAddRows = False
        Me.dgvAllResults.AllowUserToDeleteRows = False
        Me.dgvAllResults.AllowUserToResizeRows = False
        Me.dgvAllResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAllResults.BackgroundColor = System.Drawing.Color.White
        Me.dgvAllResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAllResults.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAllResults.Location = New System.Drawing.Point(3, 45)
        Me.dgvAllResults.MultiSelect = False
        Me.dgvAllResults.Name = "dgvAllResults"
        Me.dgvAllResults.ReadOnly = True
        Me.dgvAllResults.RowHeadersVisible = False
        Me.dgvAllResults.RowTemplate.Height = 24
        Me.dgvAllResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAllResults.Size = New System.Drawing.Size(806, 389)
        Me.dgvAllResults.TabIndex = 1
        '
        'pnlSearchTop
        '
        Me.pnlSearchTop.Controls.Add(Me.lblSearchResult)
        Me.pnlSearchTop.Controls.Add(Me.btnSearchAll)
        Me.pnlSearchTop.Controls.Add(Me.dtpSearchTime)
        Me.pnlSearchTop.Controls.Add(Me.dtpSearchDate)
        Me.pnlSearchTop.Controls.Add(Me.lblSince)
        Me.pnlSearchTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSearchTop.Location = New System.Drawing.Point(3, 3)
        Me.pnlSearchTop.Name = "pnlSearchTop"
        Me.pnlSearchTop.Size = New System.Drawing.Size(806, 42)
        Me.pnlSearchTop.TabIndex = 0
        '
        'lblSearchResult
        '
        Me.lblSearchResult.AutoSize = True
        Me.lblSearchResult.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblSearchResult.ForeColor = System.Drawing.Color.Blue
        Me.lblSearchResult.Location = New System.Drawing.Point(450, 15)
        Me.lblSearchResult.Name = "lblSearchResult"
        Me.lblSearchResult.Size = New System.Drawing.Size(0, 12)
        Me.lblSearchResult.TabIndex = 4
        '
        'btnSearchAll
        '
        Me.btnSearchAll.Location = New System.Drawing.Point(325, 8)
        Me.btnSearchAll.Name = "btnSearchAll"
        Me.btnSearchAll.Size = New System.Drawing.Size(105, 26)
        Me.btnSearchAll.TabIndex = 3
        Me.btnSearchAll.Text = "検索開始(&S)"
        Me.btnSearchAll.UseVisualStyleBackColor = True
        '
        'dtpSearchTime
        '
        Me.dtpSearchTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpSearchTime.Location = New System.Drawing.Point(220, 10)
        Me.dtpSearchTime.Name = "dtpSearchTime"
        Me.dtpSearchTime.ShowUpDown = True
        Me.dtpSearchTime.Size = New System.Drawing.Size(90, 20)
        Me.dtpSearchTime.TabIndex = 2
        '
        'dtpSearchDate
        '
        Me.dtpSearchDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpSearchDate.Location = New System.Drawing.Point(95, 10)
        Me.dtpSearchDate.Name = "dtpSearchDate"
        Me.dtpSearchDate.Size = New System.Drawing.Size(115, 20)
        Me.dtpSearchDate.TabIndex = 1
        '
        'lblSince
        '
        Me.lblSince.AutoSize = True
        Me.lblSince.Location = New System.Drawing.Point(10, 14)
        Me.lblSince.Name = "lblSince"
        Me.lblSince.Size = New System.Drawing.Size(81, 13)
        Me.lblSince.TabIndex = 0
        Me.lblSince.Text = "指定日時以降:"
        '
        'pnlBottom
        '
        Me.pnlBottom.Controls.Add(Me.btnClose)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 502)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(820, 42)
        Me.pnlBottom.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(705, 7)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(105, 28)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "閉じる(&C)"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FrmUsrRrkViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(820, 544)
        Me.Controls.Add(Me.tabControl)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlTop)
        Me.MinimizeBox = False
        Me.Name = "FrmUsrRrkViewer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ユーザー修正履歴ビューアー"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlTop.PerformLayout()
        Me.tabControl.ResumeLayout(False)
        Me.tabIndividual.ResumeLayout(False)
        Me.splitIndividual.Panel1.ResumeLayout(False)
        Me.splitIndividual.Panel2.ResumeLayout(False)
        CType(Me.splitIndividual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitIndividual.ResumeLayout(False)
        CType(Me.dgvEntries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvChanges, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabAllSearch.ResumeLayout(False)
        CType(Me.dgvAllResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSearchTop.ResumeLayout(False)
        Me.pnlSearchTop.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

End Class
