Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmUsrRrkViewer
    Private TargetCode As String = ""
    Private TargetUserTitle As String = ""
    Private CurrentEntries As New List(Of UsrRrkEntry)()

    Public Sub ShowHistory(ByVal code As String, ByVal userTitle As String, Optional ByVal owner As IWin32Window = Nothing)
        TargetCode = GetNumAlp(code)
        TargetUserTitle = userTitle

        If owner IsNot Nothing Then
            Me.ShowDialog(owner)
        Else
            Me.ShowDialog()
        End If
    End Sub

    Private Sub FrmUsrRrkViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyAppIcon(Me)
        lblUserHeader.Text = $"修正履歴: {TargetUserTitle}"

        ' 個別履歴グリッドの列定義
        SetupIndividualGrids()

        ' 全件検索グリッドの列定義
        SetupAllSearchGrid()

        ' デフォルトの検索日時: 今日の 00:00:00
        dtpSearchDate.Value = DateTime.Today
        dtpSearchTime.Value = DateTime.Today

        ' 該当ユーザーの履歴を読み込み
        LoadUserHistory(TargetCode)
    End Sub

    Private Sub SetupIndividualGrids()
        ' 修正回一覧
        dgvEntries.Columns.Clear()
        dgvEntries.Columns.Add("colTime", "修正日時")
        dgvEntries.Columns.Add("colSyain", "担当者")
        dgvEntries.Columns.Add("colPc", "PC名")
        dgvEntries.Columns.Add("colCount", "項目数")

        dgvEntries.Columns("colTime").Width = 140
        dgvEntries.Columns("colSyain").Width = 85
        dgvEntries.Columns("colPc").Width = 85
        dgvEntries.Columns("colCount").Width = 60

        ' 変更詳細
        dgvChanges.Columns.Clear()
        dgvChanges.Columns.Add("colField", "変更項目")
        dgvChanges.Columns.Add("colBefore", "変更前")
        dgvChanges.Columns.Add("colAfter", "変更後")

        dgvChanges.Columns("colField").Width = 110
        dgvChanges.Columns("colBefore").Width = 170
        dgvChanges.Columns("colAfter").Width = 170
    End Sub

    Private Sub SetupAllSearchGrid()
        dgvAllResults.Columns.Clear()
        dgvAllResults.Columns.Add("colSearchTime", "修正日時")
        dgvAllResults.Columns.Add("colSearchCode", "コード")
        dgvAllResults.Columns.Add("colSearchName", "施術所名")
        dgvAllResults.Columns.Add("colSearchSyain", "担当者")
        dgvAllResults.Columns.Add("colSearchPc", "PC名")
        dgvAllResults.Columns.Add("colSearchChanges", "変更項目")

        dgvAllResults.Columns("colSearchTime").Width = 140
        dgvAllResults.Columns("colSearchCode").Width = 65
        dgvAllResults.Columns("colSearchName").Width = 180
        dgvAllResults.Columns("colSearchSyain").Width = 90
        dgvAllResults.Columns("colSearchPc").Width = 90
        dgvAllResults.Columns("colSearchChanges").Width = 220
    End Sub

    ''' <summary>
    ''' 指定ユーザーの履歴をDBから読み込んで表示
    ''' </summary>
    Public Sub LoadUserHistory(ByVal code As String)
        TargetCode = GetNumAlp(code)
        dgvEntries.Rows.Clear()
        dgvChanges.Rows.Clear()

        If String.IsNullOrWhiteSpace(TargetCode) Then
            lblUserHeader.Text = "ユーザー修正履歴 （ユーザー未選択）"
            tabControl.SelectedTab = tabAllSearch
            Return
        End If

        Dim json As String = ""
        Try
            If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    json = GetUserHistoryJson(TargetCode, cnNt)
                End Using
            Else
                json = GetUserHistoryJson(TargetCode, CnMplMdb)
            End If
        Catch ex As Exception
            MessageBox.Show("履歴の取得に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        CurrentEntries = DeserializeHistory(json)

        If CurrentEntries.Count = 0 Then
            lblUserHeader.Text = $"修正履歴: {TargetUserTitle} （※履歴はありません）"
            Return
        End If

        lblUserHeader.Text = $"修正履歴: {TargetUserTitle} （全 {CurrentEntries.Count} 件）"

        For i As Integer = 0 To CurrentEntries.Count - 1
            Dim ent As UsrRrkEntry = CurrentEntries(i)
            Dim syainDisp As String = If(String.IsNullOrWhiteSpace(ent.SyainName), ent.SyainCode, ent.SyainName)
            Dim rowIndex As Integer = dgvEntries.Rows.Add(ent.Timestamp, syainDisp, ent.PcName, ent.Changes.Count.ToString())
            dgvEntries.Rows(rowIndex).Tag = ent
        Next

        If dgvEntries.Rows.Count > 0 Then
            dgvEntries.Rows(0).Selected = True
            ShowChangesForEntry(CurrentEntries(0))
        End If
    End Sub

    Private Sub dgvEntries_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEntries.SelectionChanged
        If dgvEntries.SelectedRows.Count > 0 Then
            Dim ent As UsrRrkEntry = TryCast(dgvEntries.SelectedRows(0).Tag, UsrRrkEntry)
            If ent IsNot Nothing Then
                ShowChangesForEntry(ent)
            End If
        End If
    End Sub

    Private Sub ShowChangesForEntry(ByVal ent As UsrRrkEntry)
        dgvChanges.Rows.Clear()
        If ent Is Nothing OrElse ent.Changes Is Nothing Then Return

        For Each chg As UsrRrkChange In ent.Changes
            Dim rIdx As Integer = dgvChanges.Rows.Add(chg.Field, chg.Before, chg.After)
            ' 変更前と変更後の差分を強調
            dgvChanges.Rows(rIdx).Cells("colAfter").Style.ForeColor = Color.DarkGreen
            dgvChanges.Rows(rIdx).Cells("colBefore").Style.ForeColor = Color.DarkRed
        Next
    End Sub

    ''' <summary>
    ''' 指定日時以降の修正検索を実行
    ''' </summary>
    Private Sub btnSearchAll_Click(sender As Object, e As EventArgs) Handles btnSearchAll.Click
        Dim searchDate As DateTime = dtpSearchDate.Value.Date.Add(dtpSearchTime.Value.TimeOfDay)
        lblSearchResult.Text = "検索中..."
        lblSearchResult.ForeColor = Color.Blue
        btnSearchAll.Enabled = False
        Cursor = Cursors.WaitCursor
        dgvAllResults.Rows.Clear()
        Application.DoEvents()

        Try
            Dim dt As DataTable = Nothing
            Dim sql As String = "SELECT [コード], [施術所名], [履歴] FROM ユーザーデータ WHERE [履歴] IS NOT NULL AND [履歴] <> ''"

            If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    dt = QueryDataTable(sql, cnNt)
                End Using
            Else
                dt = QueryDataTable(sql, CnMplMdb)
            End If

            Dim matchCount As Integer = 0
            If dt IsNot Nothing Then
                For Each row As DataRow In dt.Rows
                    Dim cd As String = NulCut(row("コード"))
                    Dim sjName As String = NulCut(row("施術所名"))
                    Dim rrkJson As String = NulCut(row("履歴"))

                    Dim entries As List(Of UsrRrkEntry) = DeserializeHistory(rrkJson)
                    For Each ent As UsrRrkEntry In entries
                        Dim entryDt As DateTime
                        If DateTime.TryParse(ent.Timestamp, entryDt) AndAlso entryDt >= searchDate Then
                            ' 変更項目名のサマリー
                            Dim fieldNames As New List(Of String)()
                            For Each c As UsrRrkChange In ent.Changes
                                If Not fieldNames.Contains(c.Field) Then
                                    fieldNames.Add(c.Field)
                                End If
                            Next
                            Dim fieldSummary As String = String.Join(", ", fieldNames)
                            Dim syainDisp As String = If(String.IsNullOrWhiteSpace(ent.SyainName), ent.SyainCode, ent.SyainName)

                            Dim rIdx As Integer = dgvAllResults.Rows.Add(ent.Timestamp, cd, sjName, syainDisp, ent.PcName, fieldSummary)
                            dgvAllResults.Rows(rIdx).Tag = cd
                            matchCount += 1
                        End If
                    Next
                Next
            End If

            lblSearchResult.Text = $"{matchCount} 件該当しました。"
            lblSearchResult.ForeColor = If(matchCount > 0, Color.DarkGreen, Color.DarkOrange)
        Catch ex As Exception
            MessageBox.Show("検索中にエラーが発生しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            lblSearchResult.Text = "エラーが発生しました。"
            lblSearchResult.ForeColor = Color.Red
        Finally
            btnSearchAll.Enabled = True
            Cursor = Cursors.Default
        End Try
    End Sub

    ''' <summary>
    ''' 全件検索一覧をダブルクリックしたとき、該当ユーザーの個別履歴にジャンプ
    ''' </summary>
    Private Sub dgvAllResults_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAllResults.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvAllResults.Rows.Count Then Return
        Dim cd As String = TryCast(dgvAllResults.Rows(e.RowIndex).Tag, String)
        If Not String.IsNullOrWhiteSpace(cd) Then
            Dim name As String = NulCut(dgvAllResults.Rows(e.RowIndex).Cells("colSearchName").Value)
            TargetUserTitle = $"{cd}  {name}"
            LoadUserHistory(cd)
            tabControl.SelectedTab = tabIndividual
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Alt Or Keys.C) OrElse keyData = Keys.Escape Then
            Me.Close()
            Return True
        ElseIf keyData = (Keys.Alt Or Keys.S) Then
            If tabControl.SelectedTab Is tabAllSearch AndAlso btnSearchAll.Enabled Then
                btnSearchAll.PerformClick()
                Return True
            End If
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
