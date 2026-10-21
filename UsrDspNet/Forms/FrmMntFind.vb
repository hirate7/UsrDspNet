Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class FrmMntFind
    Private IsGridLoading As Boolean = False

    Private Sub FrmMntFind_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupGrid()
        GenerateSql()
    End Sub

    Private Sub SetupGrid()
        dgvMnt.Columns.Clear()
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "ID", .HeaderText = "ID", .Width = 55})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "コード", .HeaderText = "コード", .Width = 65})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "作業日", .HeaderText = "作業日", .Width = 88})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "分類", .HeaderText = "分類", .Width = 90})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "内容", .HeaderText = "内容", .Width = 360})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "社員名", .HeaderText = "担当", .Width = 75})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "期日", .HeaderText = "期日", .Width = 88})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "完了", .HeaderText = "完了", .Width = 48})
        dgvMnt.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "削除", .HeaderText = "削除", .Width = 48, .Visible = False})
    End Sub

    Private Sub GenerateSql()
        Dim kw0 As String = TrimX(txtFind0.Text).Replace("'", "''")
        Dim kw1 As String = TrimX(txtFind1.Text).Replace("'", "''")
        Dim kw2 As String = TrimX(txtFind2.Text).Replace("'", "''")

        Dim modeOp As String = If(optFindAnd.Checked, " AND ", " OR ")
        Dim kwParts As New List(Of String)()
        If kw0 <> "" Then kwParts.Add("内容 LIKE '%" & kw0 & "%'")
        If kw1 <> "" Then kwParts.Add("内容 LIKE '%" & kw1 & "%'")
        If kw2 <> "" Then kwParts.Add("内容 LIKE '%" & kw2 & "%'")

        Dim kwClause As String = String.Join(modeOp, kwParts.ToArray())

        Dim sqlBase As String =
            "SELECT メンテナンス記録.ID, Format(作業日,'yyyy/mm/dd') AS sdate, コード, 分類, 内容, " &
            "社員マスター.社員名, Format(期日,'yyyy/mm/dd') AS kdate, 完了, 削除 " &
            "FROM メンテナンス記録 LEFT JOIN 社員マスター ON メンテナンス記録.社員コード = 社員マスター.社員コード" & Environment.NewLine

        If kwClause = "" Then
            txtSql.Text = sqlBase & "WHERE [メンテナンス記録.削除] = False ORDER BY [作業日], [メンテナンス記録.ID]"
        Else
            txtSql.Text = sqlBase & "WHERE [メンテナンス記録.削除] = False AND (" & kwClause & ") ORDER BY [作業日], [メンテナンス記録.ID]"
        End If
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind0.TextChanged, txtFind1.TextChanged, txtFind2.TextChanged
        GenerateSql()
    End Sub

    Private Sub optFind_CheckedChanged(sender As Object, e As EventArgs) Handles optFindAnd.CheckedChanged, optFindOr.CheckedChanged
        GenerateSql()
    End Sub

    Private Sub cmdMakeSql_Click(sender As Object, e As EventArgs) Handles cmdMakeSql.Click
        GenerateSql()
    End Sub

    Private Sub ClearDetails()
        cmdDispUserData.Enabled = False
        txtUsrCode.Text = ""
        txtSibu.Text = ""
        txtYago.Text = ""
        txtName.Text = ""
        txtPc.Text = ""
        txtDisplay.Text = ""
        txtPrinter.Text = ""
        txtBCR.Text = ""
        txtBkup.Text = ""
        txtMiniPrinter.Text = ""

        rtbNaiyou.Text = ""
        txtSagyoubi.Text = ""
        txtBunrui.Text = ""
        txtSyain.Text = ""
        txtKijitu.Text = ""
        chkComp.Checked = False
        lblDeletedLog.Visible = False
    End Sub

    Private Sub cmdFind_Click(sender As Object, e As EventArgs) Handles cmdFind.Click
        If String.IsNullOrWhiteSpace(txtSql.Text) Then
            GenerateSql()
        End If
        If String.IsNullOrWhiteSpace(txtSql.Text) Then Return

        ClearDetails()
        lblCnt.ForeColor = Color.Blue
        lblCnt.Text = "検索中..."
        Application.DoEvents()

        Me.Cursor = Cursors.WaitCursor
        IsGridLoading = True
        dgvMnt.Rows.Clear()

        Try
            Dim dt As DataTable = QueryDataTable(TrimX(txtSql.Text), CnMntMdb)
            For Each r As DataRow In dt.Rows
                Dim isComp As Boolean = NulCutBool(r("完了"))
                Dim isDel As Boolean = NulCutBool(r("削除"))
                dgvMnt.Rows.Add(
                    NulCut(r("ID")),
                    NulCut(r("コード")),
                    NulCut(r("sdate")),
                    NulCut(r("分類")),
                    CutCR(NulCut(r("内容"))),
                    NulCut(r("社員名")),
                    NulCut(r("kdate")),
                    If(isComp, "済", "未"),
                    If(isDel, "1", "0")
                )
                dgvMnt.Rows(dgvMnt.Rows.Count - 1).Tag = NulCut(r("内容"))
            Next

            lblCnt.ForeColor = Color.Black
            lblCnt.Text = dgvMnt.Rows.Count.ToString("#,##0") & "件 該当"
        Catch ex As Exception
            lblCnt.ForeColor = Color.Red
            lblCnt.Text = "エラー"
            MessageBox.Show("検索に失敗しました: " & ex.Message, "データベースエラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            IsGridLoading = False
            Me.Cursor = Cursors.Default
        End Try

        If dgvMnt.Rows.Count > 0 Then
            Dim lastIdx As Integer = dgvMnt.Rows.Count - 1
            dgvMnt.CurrentCell = dgvMnt.Rows(lastIdx).Cells("作業日")
            DisplaySelectedRow(lastIdx)
        End If
    End Sub

    Private Sub dgvMnt_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMnt.SelectionChanged
        If IsGridLoading Then Return
        If dgvMnt.CurrentRow Is Nothing Then Return
        DisplaySelectedRow(dgvMnt.CurrentRow.Index)
    End Sub

    Private Sub DisplaySelectedRow(ByVal rowIdx As Integer)
        If rowIdx < 0 OrElse rowIdx >= dgvMnt.Rows.Count Then Return
        Dim row As DataGridViewRow = dgvMnt.Rows(rowIdx)

        Dim fullText As String = If(row.Tag IsNot Nothing, row.Tag.ToString(), NulCut(row.Cells("内容").Value))
        rtbNaiyou.Text = fullText
        txtSagyoubi.Text = NulCut(row.Cells("作業日").Value)
        txtBunrui.Text = NulCut(row.Cells("分類").Value)
        txtSyain.Text = NulCut(row.Cells("社員名").Value)
        txtKijitu.Text = NulCut(row.Cells("期日").Value)
        chkComp.Checked = (NulCut(row.Cells("完了").Value) = "済")
        lblDeletedLog.Visible = (NulCut(row.Cells("削除").Value) = "1")

        ApplyKeywordMarkers()

        Dim ucd As String = NulCut(row.Cells("コード").Value)
        txtUsrCode.Text = ucd
        LoadUserSummary(ucd)
    End Sub

    Private Sub LoadUserSummary(ByVal ucd As String)
        cmdDispUserData.Enabled = False
        txtSibu.Text = ""
        txtYago.Text = ""
        txtName.Text = ""
        txtPc.Text = ""
        txtDisplay.Text = ""
        txtPrinter.Text = ""
        txtMiniPrinter.Text = ""
        txtBCR.Text = ""
        txtBkup.Text = ""

        If String.IsNullOrWhiteSpace(ucd) Then Return

        Try
            Dim dt As DataTable = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(ucd), CnMplMdb)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                Dim isDel As Boolean = (NulCut(r("削除")) = "2")
                Dim bg As Color = If(isDel, ColorFromVbLong(&HB493F7), Color.White)
                txtSibu.BackColor = bg
                txtYago.BackColor = bg
                txtName.BackColor = bg

                txtSibu.Text = NulCut(r("支部名"))
                txtYago.Text = NulCut(r("施術所名"))
                txtName.Text = NulCut(r("柔整師名"))

                txtPc.Text = "本体: " & NulCut(r("本体機種名"))
                txtDisplay.Text = "画面: " & NulCut(r("画面機種名"))
                txtPrinter.Text = "ﾌﾟﾘﾝﾀ: " & NulCut(r("プリンター機種名"))
                txtMiniPrinter.Text = "小型: " & NulCut(r("小型プリンター機種名"))
                txtBCR.Text = "BCR: " & NulCut(r("BCR機種名"))
                txtBkup.Text = "Backup: " & NulCut(r("HDD機種名"))

                cmdDispUserData.Enabled = True
            End If
        Catch
        End Try
    End Sub

    Private Sub ApplyKeywordMarkers()
        If String.IsNullOrEmpty(rtbNaiyou.Text) Then Return

        rtbNaiyou.SelectAll()
        rtbNaiyou.SelectionColor = Color.Black
        rtbNaiyou.SelectionFont = rtbNaiyou.Font
        rtbNaiyou.SelectionLength = 0

        Dim kwBoxes() As TextBox = {txtFind0, txtFind1, txtFind2}
        Dim kwColors() As Color = {
            Color.FromArgb(&HAA, 0, 0),
            Color.FromArgb(0, 0, &HBB),
            Color.FromArgb(0, &H88, 0)
        }
        Dim highlightFont As New Font(rtbNaiyou.Font, FontStyle.Bold Or FontStyle.Underline)
        Dim bodyLower As String = rtbNaiyou.Text.ToLowerInvariant()

        For i As Integer = 0 To 2
            Dim kw As String = TrimX(kwBoxes(i).Text)
            If kw <> "" Then
                Dim kwLower As String = kw.ToLowerInvariant()
                Dim pos As Integer = bodyLower.IndexOf(kwLower, 0, StringComparison.Ordinal)
                While pos >= 0
                    rtbNaiyou.Select(pos, kw.Length)
                    rtbNaiyou.SelectionColor = kwColors(i)
                    rtbNaiyou.SelectionFont = highlightFont
                    pos = bodyLower.IndexOf(kwLower, pos + kw.Length, StringComparison.Ordinal)
                End While
            End If
        Next

        rtbNaiyou.SelectionStart = 0
        rtbNaiyou.SelectionLength = 0
    End Sub

    Private Sub cmdMarker_Click(sender As Object, e As EventArgs) Handles cmdMarker.Click
        ApplyKeywordMarkers()
    End Sub

    Private Sub cmdDispUserData_Click(sender As Object, e As EventArgs) Handles cmdDispUserData.Click
        If String.IsNullOrWhiteSpace(txtUsrCode.Text) Then Return
        If fMainForm IsNot Nothing Then
            fMainForm.DisplayUserByCode(txtUsrCode.Text, True)
            fMainForm.Activate()
        End If
        Me.Close()
    End Sub

    Private Sub cmdEditMnt_Click(sender As Object, e As EventArgs) Handles cmdEditMnt.Click
        If dgvMnt.CurrentRow Is Nothing Then Return
        Dim mntId As Long = NulCutN(dgvMnt.CurrentRow.Cells("ID").Value)
        Dim ucd As String = NulCut(dgvMnt.CurrentRow.Cells("コード").Value)
        If mntId <= 0 OrElse ucd = "" Then Return

        Using dlg As New FrmMntEdit()
            dlg.EditDsp(ucd, mntId, 2)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                cmdFind.PerformClick()
                If fMainForm IsNot Nothing Then
                    fMainForm.RefreshCurrentUserData()
                End If
            End If
        End Using
    End Sub

    Private Sub dgvMnt_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMnt.CellDoubleClick
        If e.RowIndex < 0 Then Return
        cmdEditMnt.PerformClick()
    End Sub
End Class
