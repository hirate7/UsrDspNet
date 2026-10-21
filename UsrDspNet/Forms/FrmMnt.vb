Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmMnt
    Private Structure UserBrief
        Public Sibu As String
        Public SjName As String
        Public JsName As String
        Public DelFlag As String
    End Structure

    Private UserCache As New Dictionary(Of String, UserBrief)(StringComparer.OrdinalIgnoreCase)
    Private IsLoading As Boolean = False

    Private Sub FrmMnt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        IsLoading = True
        SetupGrid()

        cmbSort.SelectedIndex = If(OptionMntSort = 2, 1, 0)
        chkDspKanryou.Checked = OptionMntDspKanryou
        txtKijitsuSt.Text = MakeDateString(OptionMntKijitsuSt, StlYMD)
        txtKijitsuEd.Text = MakeDateString(OptionMntKijitsuEd, StlYMD)
        Select Case OptionMntBunrui
            Case 1
                tabBunrui.SelectedTab = tabSyuuri
            Case 2
                tabBunrui.SelectedTab = tabKaihatsu
            Case Else
                tabBunrui.SelectedTab = tabSubete
        End Select

        BuildUserCache()
        IsLoading = False
        MntDsp()
    End Sub

    Private Sub SetupGrid()
        dgvMnt.Columns.Clear()
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ID", .HeaderText = "ID", .Width = 55})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "作業日", .HeaderText = "作業日", .Width = 88})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "支部", .HeaderText = "支部", .Width = 80})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "施術所名", .HeaderText = "施術所名", .Width = 175})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "分類", .HeaderText = "分類", .Width = 85})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "内容", .HeaderText = "内容", .Width = 310})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "期日", .HeaderText = "期日", .Width = 88})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "社員", .HeaderText = "社員", .Width = 75})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "完了", .HeaderText = "完了", .Width = 48})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "コード", .HeaderText = "コード", .Visible = False})
    End Sub

    Private Sub BuildUserCache()
        UserCache.Clear()
        Try
            Dim dt As DataTable = QueryDataTable("SELECT コード, 支部名, 施術所名, 柔整師名, 削除 FROM ユーザーデータ", CnMplMdb)
            For Each r As DataRow In dt.Rows
                Dim cd As String = TrimX(NulCut(r("コード")))
                If cd <> "" Then
                    Dim ub As New UserBrief With {
                        .Sibu = NulCut(r("支部名")),
                        .SjName = NulCut(r("施術所名")),
                        .JsName = NulCut(r("柔整師名")),
                        .DelFlag = NulCut(r("削除"))
                    }
                    UserCache(cd) = ub
                End If
            Next
        Catch
        End Try
    End Sub

    Public Sub MntDsp()
        If IsLoading Then Return
        IsLoading = True
        Me.Cursor = Cursors.WaitCursor

        OptionMntSort = If(cmbSort.SelectedIndex = 1, 2, 1)
        OptionMntDspKanryou = chkDspKanryou.Checked
        DateTime.TryParse(txtKijitsuSt.Text, OptionMntKijitsuSt)
        DateTime.TryParse(txtKijitsuEd.Text, OptionMntKijitsuEd)

        SaveSetting(AppTitleReg, "Options", "MntSort", OptionMntSort.ToString())
        SaveSetting(AppTitleReg, "Options", "MntKanryouDsp", OptionMntDspKanryou.ToString())
        SaveSetting(AppTitleReg, "Options", "MntKijitsuSt", MakeDateString(OptionMntKijitsuSt, StlYMD))
        SaveSetting(AppTitleReg, "Options", "MntKijitsuEd", MakeDateString(OptionMntKijitsuEd, StlYMD))

        Dim sqlKanryou As String = If(OptionMntDspKanryou, " WHERE (メンテナンス記録.完了 = True OR メンテナンス記録.完了 = False) ", " WHERE メンテナンス記録.完了 = False ")
        Dim sqlBunrui As String = ""
        If tabBunrui.SelectedTab Is tabSyuuri Then
            sqlBunrui = " AND メンテナンス記録.分類 LIKE '%修理%' "
        ElseIf tabBunrui.SelectedTab Is tabKaihatsu Then
            sqlBunrui = " AND メンテナンス記録.分類 LIKE '%開発%' "
        ElseIf tabBunrui.SelectedTab Is tabEigyou Then
            sqlBunrui = " AND メンテナンス記録.分類 LIKE '営業%' "
        ElseIf tabBunrui.SelectedTab Is tabHoka Then
            sqlBunrui = " AND メンテナンス記録.分類 LIKE '他%' "
        End If

        Dim sqlKijitsu As String = " AND メンテナンス記録.期日 BETWEEN #" & MakeDateString(OptionMntKijitsuSt, StlYMD) & "# AND #" & MakeDateString(OptionMntKijitsuEd, StlYMD) & "# "
        Dim sqlSort As String = If(OptionMntSort = 1, " AND メンテナンス記録.削除 = False ORDER BY メンテナンス記録.作業日, メンテナンス記録.ID", " AND メンテナンス記録.削除 = False ORDER BY メンテナンス記録.期日, メンテナンス記録.ID")

        Dim sql As String =
            "SELECT メンテナンス記録.ID, メンテナンス記録.作成日, メンテナンス記録.作業日, メンテナンス記録.分類, メンテナンス記録.内容, " &
            "メンテナンス記録.コード, メンテナンス記録.社員コード, 社員マスター.社員名, メンテナンス記録.期日, メンテナンス記録.完了 " &
            "FROM メンテナンス記録 LEFT JOIN 社員マスター ON メンテナンス記録.社員コード = 社員マスター.社員コード " &
            sqlKanryou & sqlBunrui & sqlKijitsu & sqlSort

        dgvMnt.Rows.Clear()
        Dim todayStr As String = DateTime.Now.ToString("yyyy/MM/dd")

        Try
            Dim dt As DataTable = QueryDataTable(sql, CnMntMdb)
            For Each r As DataRow In dt.Rows
                Dim ucd As String = TrimX(NulCut(r("コード")))
                Dim sibu As String = ""
                Dim sjName As String = ""
                Dim delMark As String = ""

                Dim ub As UserBrief = Nothing
                If UserCache.TryGetValue(ucd, ub) Then
                    sibu = ub.Sibu
                    If ub.DelFlag = "2" Then delMark = "※"
                    sjName = delMark & ub.SjName
                End If

                Dim sagyouStr As String = MakeDateString(r("作業日"), StlYMD)
                Dim kijitsuStr As String = MakeDateString(r("期日"), StlYMD)
                Dim isComp As Boolean = NulCutBool(r("完了"))

                Dim rowIdx As Integer = dgvMnt.Rows.Add(
                    NulCut(r("ID")),
                    sagyouStr,
                    sibu,
                    sjName,
                    NulCut(r("分類")),
                    CutCR(NulCut(r("内容"))),
                    kijitsuStr,
                    NulCut(r("社員名")),
                    If(isComp, "済", "未"),
                    ucd
                )

                Dim row As DataGridViewRow = dgvMnt.Rows(rowIdx)
                row.Tag = r

                Dim fg As Color = Color.Black
                If isComp Then
                    fg = Color.Gray
                Else
                    If kijitsuStr <> "" AndAlso String.CompareOrdinal(kijitsuStr, todayStr) <= 0 Then
                        fg = Color.FromArgb(192, 0, 0)
                    End If
                    If delMark = "※" Then
                        fg = Color.FromArgb(0, 0, 192)
                    End If
                End If
                row.DefaultCellStyle.ForeColor = fg
            Next
            lblCount.Text = dgvMnt.Rows.Count.ToString("#,##0") & "件"
        Catch ex As Exception
            MessageBox.Show("メンテナンス記録一覧の取得に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            IsLoading = False
            Me.Cursor = Cursors.Default
        End Try

        If dgvMnt.Rows.Count > 0 Then
            Dim lastIdx As Integer = dgvMnt.Rows.Count - 1
            dgvMnt.CurrentCell = dgvMnt.Rows(lastIdx).Cells("作業日")
            DisplayRowDetail(lastIdx)
        Else
            ClearDetail()
        End If
    End Sub

    Private Sub ClearDetail()
        LblID.Text = ""
        LblSakusei.Text = ""
        LblUCode.Text = ""
        LblSibu.Text = ""
        LblSjName.Text = ""
        LblJsName.Text = ""
        LblSagyou.Text = ""
        LblBunrui.Text = ""
        LblSyain.Text = ""
        LblKijitsu.Text = ""
        ChkKanryou.Checked = False
        TxtNaiyou.Text = ""
        CmdEdit.Enabled = False
        CmdDispUser.Enabled = False
    End Sub

    Private Sub DisplayRowDetail(ByVal rowIdx As Integer)
        If rowIdx < 0 OrElse rowIdx >= dgvMnt.Rows.Count Then
            ClearDetail()
            Return
        End If

        Dim row As DataGridViewRow = dgvMnt.Rows(rowIdx)
        Dim r As DataRow = TryCast(row.Tag, DataRow)
        If r Is Nothing Then Return

        Dim ucd As String = TrimX(NulCut(r("コード")))
        LblID.Text = "ID: " & NulCut(r("ID"))
        LblSakusei.Text = MakeDateString(r("作成日"), StlYMDHMS)
        LblUCode.Text = ucd

        Dim ub As UserBrief = Nothing
        If UserCache.TryGetValue(ucd, ub) Then
            LblSibu.Text = ub.Sibu
            LblSjName.Text = If(ub.DelFlag = "2", "※", "") & ub.SjName
            LblJsName.Text = ub.JsName
        Else
            LblSibu.Text = ""
            LblSjName.Text = ""
            LblJsName.Text = ""
        End If

        LblSagyou.Text = "作業: " & MakeDateString(r("作業日"), StlYMD) & " " & MakeDateString(r("作業日"), StlHM)
        LblBunrui.Text = "分類: " & NulCut(r("分類"))
        LblSyain.Text = "担当: " & NulCut(r("社員名"))
        LblKijitsu.Text = "期日: " & MakeDateString(r("期日"), StlYMD)
        ChkKanryou.Checked = NulCutBool(r("完了"))
        TxtNaiyou.Text = NulCut(r("内容"))

        CmdEdit.Enabled = True
        CmdDispUser.Enabled = (ucd <> "")
    End Sub

    Private Sub dgvMnt_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMnt.SelectionChanged
        If IsLoading Then Return
        If dgvMnt.CurrentRow Is Nothing Then Return
        DisplayRowDetail(dgvMnt.CurrentRow.Index)
    End Sub

    Private Sub tabBunrui_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabBunrui.SelectedIndexChanged
        If IsLoading Then Return
        MntDsp()
    End Sub

    Private Sub cmbSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSort.SelectedIndexChanged
        If IsLoading Then Return
        MntDsp()
    End Sub

    Private Sub chkDspKanryou_CheckedChanged(sender As Object, e As EventArgs) Handles chkDspKanryou.CheckedChanged
        If IsLoading Then Return
        MntDsp()
    End Sub

    Private Sub btnRangeAll_Click(sender As Object, e As EventArgs) Handles btnRangeAll.Click
        txtKijitsuSt.Text = "1999/01/01"
        txtKijitsuEd.Text = "2099/12/31"
        MntDsp()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        MntDsp()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim sortText As String = If(cmbSort.SelectedIndex = 1, "完了期日順", "作業日順")
        Dim kanryouText As String = If(chkDspKanryou.Checked, "表示する", "表示しない")
        Dim kijitsuText As String = txtKijitsuSt.Text & "～" & txtKijitsuEd.Text
        PrintMntList(dgvMnt, sortText, kanryouText, kijitsuText, Me)
    End Sub

    Private Sub btnOpt_Click(sender As Object, e As EventArgs) Handles btnOpt.Click
        Using dlg As New FrmOpt()
            dlg.OptDsp(2, Me)
            If dlg.SettingsChanged Then
                IsLoading = True
                cmbSort.SelectedIndex = If(OptionMntSort = 2, 1, 0)
                chkDspKanryou.Checked = OptionMntDspKanryou
                txtKijitsuSt.Text = MakeDateString(OptionMntKijitsuSt, StlYMD)
                txtKijitsuEd.Text = MakeDateString(OptionMntKijitsuEd, StlYMD)
                Select Case OptionMntBunrui
                    Case 1
                        tabBunrui.SelectedTab = tabSyuuri
                    Case 2
                        tabBunrui.SelectedTab = tabKaihatsu
                    Case Else
                        tabBunrui.SelectedTab = tabSubete
                End Select
                IsLoading = False
                MntDsp()
            End If
        End Using
    End Sub

    Private Sub CmdEdit_Click(sender As Object, e As EventArgs) Handles CmdEdit.Click
        If dgvMnt.CurrentRow Is Nothing Then Return
        Dim mntId As Long = NulCutN(dgvMnt.CurrentRow.Cells("ID").Value)
        Dim ucd As String = NulCut(dgvMnt.CurrentRow.Cells("コード").Value)
        If mntId <= 0 OrElse ucd = "" Then Return

        Using dlg As New FrmMntEdit()
            dlg.EditDsp(ucd, mntId, 2)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                MntDsp()
                If fMainForm IsNot Nothing Then
                    fMainForm.RefreshCurrentUserData()
                End If
            End If
        End Using
    End Sub

    Private Sub dgvMnt_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMnt.CellDoubleClick
        If e.RowIndex < 0 Then Return
        CmdEdit.PerformClick()
    End Sub

    Private Sub CmdDispUser_Click(sender As Object, e As EventArgs) Handles CmdDispUser.Click
        If String.IsNullOrWhiteSpace(LblUCode.Text) Then Return
        If fMainForm IsNot Nothing Then
            fMainForm.DisplayUserByCode(LblUCode.Text, True)
            fMainForm.Activate()
        End If
    End Sub
End Class
