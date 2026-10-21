Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmMntMark
    Private TargetGrid As DataGridView

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal grid As DataGridView)
        InitializeComponent()
        TargetGrid = grid
    End Sub

    Private Sub FrmMntMark_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim raw As String = GetSetting(AppTitleReg, "Settings", "MarkTextHistory", "エラー,プリンタ,,,,,,,,,,,,,,,,,,")
        Dim parts() As String = raw.Split(","c)
        cmbMark.Items.Clear()
        For Each p As String In parts
            Dim t As String = TrimX(p)
            If t <> "" AndAlso Not cmbMark.Items.Contains(t) Then
                cmbMark.Items.Add(t)
            End If
        Next
        If cmbMark.Items.Count > 0 Then
            cmbMark.Text = cmbMark.Items(0).ToString()
        End If
    End Sub

    Private Sub SaveHistory(ByVal kw As String)
        Dim list As New List(Of String)()
        list.Add(kw)
        For Each item As Object In cmbMark.Items
            Dim s As String = TrimX(item.ToString())
            If s <> "" AndAlso s <> kw AndAlso list.Count < 20 Then
                list.Add(s)
            End If
        Next
        While list.Count < 20
            list.Add("")
        End While
        SaveSetting(AppTitleReg, "Settings", "MarkTextHistory", String.Join(",", list.ToArray()))
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim kw As String = TrimX(cmbMark.Text)
        If kw = "" Then Return
        If kw.Contains(",") Then
            MessageBox.Show("カンマは使えません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        SaveHistory(kw)

        If TargetGrid Is Nothing AndAlso fMainForm IsNot Nothing Then
            TargetGrid = fMainForm.dgvMntUsr
        End If
        If TargetGrid Is Nothing Then Return

        Dim normKw As String = CnvHZ3(kw.ToLowerInvariant())
        Dim markCnt As Integer = 0
        Dim firstMatchIdx As Integer = -1

        For Each row As DataGridViewRow In TargetGrid.Rows
            Dim content As String = NulCut(row.Cells("内容").Value)
            Dim normContent As String = CnvHZ3(content.ToLowerInvariant())
            If normContent.Contains(normKw) Then
                markCnt += 1
                row.DefaultCellStyle.BackColor = ColorFromVbLong(&H46F2C7) ' 強調色
                If firstMatchIdx = -1 Then firstMatchIdx = row.Index
            Else
                row.DefaultCellStyle.BackColor = Color.White
            End If
        Next

        If markCnt = 0 Then
            MessageBox.Show("見つかりませんでした", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If firstMatchIdx >= 0 Then
                TargetGrid.CurrentCell = TargetGrid.Rows(firstMatchIdx).Cells("作業日")
            End If
            MessageBox.Show(markCnt.ToString("#,##0") & "件 該当", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If TargetGrid Is Nothing AndAlso fMainForm IsNot Nothing Then
            TargetGrid = fMainForm.dgvMntUsr
        End If
        If TargetGrid IsNot Nothing Then
            For Each row As DataGridViewRow In TargetGrid.Rows
                row.DefaultCellStyle.BackColor = Color.White
            Next
        End If
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
