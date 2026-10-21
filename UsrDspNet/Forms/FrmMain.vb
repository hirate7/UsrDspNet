Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class FrmMain
    Private currentCode As String = ""
    Private currentZip As String = ""
    Private currentAd1 As String = ""
    Private currentAd2 As String = ""
    Private currentMapFile As String = ""
    Private isUpdatingGrid As Boolean = False
    Private isRrkSelecting As Boolean = False
    Private findDialog As New FindDlg()
    Private mntListForm As FrmMnt = Nothing
    Private mntFindForm As FrmMntFind = Nothing

    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fMainForm = Me
        Try
            Dim icoPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usrdsp.ico")
            If File.Exists(icoPath) Then
                Me.Icon = New Icon(icoPath)
            End If
        Catch
        End Try

        InitSettings()

        If Not ConnectDatabases(True) Then
            Application.Exit()
            Return
        End If

        UpdateModeUI()
        UpdateDspModeStatus()
        stlPcName.Text = "PC: " & GetPcName()

        rdoMntSortSagyou.Checked = (OptionMntUsrSort = 1)
        rdoMntSortKijitsu.Checked = (OptionMntUsrSort = 2)
        chkMntKanryou.Checked = OptionMntUsrDspKanryou
        chkMntAutoScroll.Checked = OptionMntUsrAutoScroll

        LoadRrkHistory()
        DspFirst()
        FgPrtDsp()
    End Sub

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveRrkHistory()
        If picMap.Image IsNot Nothing Then
            picMap.Image.Dispose()
            picMap.Image = Nothing
        End If
        CloseDatabases()
    End Sub

    Private Sub UpdateModeUI()
        If ModeDbLocation = CnModeNet Then
            mnuNetworkMode.Checked = True
            mnuLocalMode.Checked = False
            lblModeBadge.Text = "ネットワーク接続"
            lblModeBadge.BackColor = Color.FromArgb(210, 242, 210)
            lblModeBadge.ForeColor = Color.DarkGreen
        Else
            mnuNetworkMode.Checked = False
            mnuLocalMode.Checked = True
            lblModeBadge.Text = "【ローカルモード】"
            lblModeBadge.BackColor = Color.FromArgb(255, 220, 200)
            lblModeBadge.ForeColor = Color.DarkRed
        End If
    End Sub

    Private Sub UpdateDspModeStatus()
        DspNormal = If(mnuDspNormal.Checked, "1", "9")
        DspSleep = If(mnuDspSleep.Checked, "3", "9")
        DspDelete = If(mnuDspDelete.Checked, "2", "9")
        stlDspMode.Text = GetDspModeStatusText()
    End Sub

    ' =========================================================================
    ' メニュー・ツールバー イベント
    ' =========================================================================
    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub mnuDbCopy_Click(sender As Object, e As EventArgs) Handles mnuDbCopy.Click
        Dim savedCode As String = currentCode
        If CopyNetworkDbToLocal() Then
            UpdateModeUI()
            DspFirst()
            If savedCode <> "" Then
                SelectUserByCode(savedCode)
            End If
        End If
    End Sub

    Private Sub mnuNetworkMode_Click(sender As Object, e As EventArgs) Handles mnuNetworkMode.Click
        If SwitchDbMode(CnModeNet) Then
            UpdateModeUI()
            If currentCode <> "" Then DisplayUserDetails(currentCode)
        End If
    End Sub

    Private Sub mnuLocalMode_Click(sender As Object, e As EventArgs) Handles mnuLocalMode.Click
        If SwitchDbMode(CnModeLocal) Then
            UpdateModeUI()
            If currentCode <> "" Then DisplayUserDetails(currentCode)
        End If
    End Sub

    Private Sub mnuDspMode_Changed(sender As Object, e As EventArgs) Handles mnuDspNormal.Click, mnuDspSleep.Click, mnuDspDelete.Click
        UpdateDspModeStatus()
    End Sub

    Private Sub btnFindName_Click(sender As Object, e As EventArgs) Handles btnFindName.Click, mnuFindName.Click
        FindUsr(1, 1)
    End Sub

    Private Sub btnFindCode_Click(sender As Object, e As EventArgs) Handles btnFindCode.Click, mnuFindCode.Click
        FindUsr(32, 0)
    End Sub

    Private Sub btnFindSibu_Click(sender As Object, e As EventArgs) Handles btnFindSibu.Click, mnuFindSibu.Click
        FindUsr(2, 0)
    End Sub

    Private Sub btnFindTel_Click(sender As Object, e As EventArgs) Handles btnFindTel.Click, mnuFindTel.Click
        FindUsr(4, 1)
    End Sub

    Private Sub btnFindPc_Click(sender As Object, e As EventArgs) Handles btnFindPc.Click, mnuFindPc.Click
        FindUsr(16, 1)
    End Sub

    Private Sub btnFindSn_Click(sender As Object, e As EventArgs) Handles btnFindSn.Click, mnuFindSn.Click
        FindUsr(8, 1)
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click, mnuFindAll.Click
        DspFirst()
    End Sub

    ' =========================================================================
    ' ユーザー一覧初期表示・検索処理 (DspFirst / FindUsr)
    ' =========================================================================
    Public Sub DspFirst()
        Dim sqlTxt As String = "SELECT 支部名, コード, 施術所名, 柔整師名, 電話番号, 削除, 〒, 住所1, 住所2, 分院Version, 本体機種名, 画面機種名, プリンター機種名, BCR機種名 " &
                               "FROM ユーザーデータ WHERE " & GetDspFilterSql() & " ORDER BY コード"
        stlSearchCond.Text = "検索条件: すべて"
        Me.Text = "検索 - 検索条件: すべて"
        LoadUserGrid(sqlTxt)
    End Sub

    Public Sub FindUsr(ByVal Mode As Integer, ByVal defaultOp As Integer)
        Dim fTxt As String = ""
        Dim op As Integer = defaultOp
        findDialog.FindInp(Mode, fTxt, op)
        If op = -1 Then Return

        If TrimX(fTxt) = "" Then op = 9

        Dim sqlBase As String = "SELECT 支部名, コード, 施術所名, 柔整師名, 電話番号, 削除, 〒, 住所1, 住所2, 分院Version, 本体機種名, 画面機種名, プリンター機種名, BCR機種名 FROM ユーザーデータ "
        Dim dspFilter As String = GetDspFilterSql()
        Dim sqlTxt As String = ""
        Dim condText As String = "すべて"

        Dim safeTxt As String = fTxt.Replace("""", """""")

        Select Case Mode
            Case 1 ' 名前
                Dim kanaTxt As String = cnvHg2Kk(safeTxt)
                Select Case op
                    Case 0
                        condText = $"名前 = {fTxt}*"
                        sqlTxt = $"{sqlBase} WHERE (フリガナ LIKE ""{kanaTxt}%"" OR 施術所ﾌﾘｶﾞﾅ LIKE ""{kanaTxt}%"" OR 施術所名 LIKE ""{safeTxt}%"" OR 柔整師名 LIKE ""{safeTxt}%"") AND {dspFilter} ORDER BY コード"
                    Case 1
                        condText = $"名前 = {fTxt} を含む"
                        sqlTxt = $"{sqlBase} WHERE (フリガナ LIKE ""%{kanaTxt}%"" OR 施術所ﾌﾘｶﾞﾅ LIKE ""%{kanaTxt}%"" OR 施術所名 LIKE ""%{safeTxt}%"" OR 柔整師名 LIKE ""%{safeTxt}%"") AND {dspFilter} ORDER BY コード"
                    Case 9
                        sqlTxt = $"{sqlBase} WHERE {dspFilter} ORDER BY コード"
                End Select

            Case 2 ' 支部
                Select Case op
                    Case 0
                        condText = $"支部 = {fTxt}*"
                        sqlTxt = $"{sqlBase} WHERE 支部名 LIKE ""{safeTxt}%"" AND {dspFilter} ORDER BY コード"
                    Case 1
                        condText = $"支部 = {fTxt} を含む"
                        sqlTxt = $"{sqlBase} WHERE 支部名 LIKE ""%{safeTxt}%"" AND {dspFilter} ORDER BY コード"
                    Case 9
                        sqlTxt = $"{sqlBase} WHERE {dspFilter} ORDER BY コード"
                End Select

            Case 4 ' 電話番号
                Dim numTxt As String = CutHf(safeTxt)
                Select Case op
                    Case 0
                        condText = $"電話番号 = {fTxt}*"
                        sqlTxt = $"{sqlBase} WHERE (コード IN (SELECT コード FROM 拡張データ WHERE 電話番号追加分1_ LIKE ""{numTxt}%"" OR 電話番号追加分2_ LIKE ""{numTxt}%"" OR 電話番号追加分3_ LIKE ""{numTxt}%"" OR 電話番号追加分4_ LIKE ""{numTxt}%"" OR 電話番号追加分5_ LIKE ""{numTxt}%"") " &
                                 $"OR 電話番号_ LIKE ""{numTxt}%"" OR 自宅電話_ LIKE ""{numTxt}%"" OR 携帯_ LIKE ""{numTxt}%"" OR FAX番号_ LIKE ""{numTxt}%"") AND {dspFilter} ORDER BY コード"
                    Case 1
                        condText = $"電話番号 = {fTxt} を含む"
                        sqlTxt = $"{sqlBase} WHERE (コード IN (SELECT コード FROM 拡張データ WHERE 電話番号追加分1_ LIKE ""%{numTxt}%"" OR 電話番号追加分2_ LIKE ""%{numTxt}%"" OR 電話番号追加分3_ LIKE ""%{numTxt}%"" OR 電話番号追加分4_ LIKE ""%{numTxt}%"" OR 電話番号追加分5_ LIKE ""%{numTxt}%"") " &
                                 $"OR 電話番号_ LIKE ""%{numTxt}%"" OR 自宅電話_ LIKE ""%{numTxt}%"" OR 携帯_ LIKE ""%{numTxt}%"" OR FAX番号_ LIKE ""%{numTxt}%"") AND {dspFilter} ORDER BY コード"
                    Case 9
                        sqlTxt = $"{sqlBase} WHERE {dspFilter} ORDER BY コード"
                End Select

            Case 8 ' S/N
                Select Case op
                    Case 0
                        condText = $"シリアルナンバー = {fTxt}*"
                        sqlTxt = $"{sqlBase} WHERE (本体SN LIKE ""{safeTxt}%"" OR 画面SN LIKE ""{safeTxt}%"" OR プリンターSN LIKE ""{safeTxt}%"" OR BCRSN LIKE ""{safeTxt}%"" OR HDDSN LIKE ""{safeTxt}%"") AND {dspFilter} ORDER BY コード"
                    Case 1
                        condText = $"シリアルナンバー = {fTxt} を含む"
                        sqlTxt = $"{sqlBase} WHERE (本体SN LIKE ""%{safeTxt}%"" OR 画面SN LIKE ""%{safeTxt}%"" OR プリンターSN LIKE ""%{safeTxt}%"" OR BCRSN LIKE ""%{safeTxt}%"" OR HDDSN LIKE ""%{safeTxt}%"") AND {dspFilter} ORDER BY コード"
                    Case 9
                        sqlTxt = $"{sqlBase} WHERE {dspFilter} ORDER BY コード"
                End Select

            Case 16 ' 製品名(型名)
                Select Case op
                    Case 0
                        condText = $"製品名 = {fTxt}*"
                        sqlTxt = $"{sqlBase} WHERE (本体機種名 LIKE ""{safeTxt}%"" OR 画面機種名 LIKE ""{safeTxt}%"" OR プリンター機種名 LIKE ""{safeTxt}%"" OR BCR機種名 LIKE ""{safeTxt}%"" OR HDD機種名 LIKE ""{safeTxt}%"") AND {dspFilter} ORDER BY コード"
                    Case 1
                        condText = $"製品名 = {fTxt} を含む"
                        sqlTxt = $"{sqlBase} WHERE (本体機種名 LIKE ""%{safeTxt}%"" OR 画面機種名 LIKE ""%{safeTxt}%"" OR プリンター機種名 LIKE ""%{safeTxt}%"" OR BCR機種名 LIKE ""%{safeTxt}%"" OR HDD機種名 LIKE ""%{safeTxt}%"") AND {dspFilter} ORDER BY コード"
                    Case 9
                        sqlTxt = $"{sqlBase} WHERE {dspFilter} ORDER BY コード"
                End Select

            Case 32 ' コード
                Select Case op
                    Case 0
                        condText = $"コード = {fTxt}*"
                        sqlTxt = $"{sqlBase} WHERE コード LIKE ""{safeTxt}%"" AND {dspFilter} ORDER BY コード"
                    Case 1
                        condText = $"コード = {fTxt} を含む"
                        sqlTxt = $"{sqlBase} WHERE コード LIKE ""%{safeTxt}%"" AND {dspFilter} ORDER BY コード"
                    Case 9
                        sqlTxt = $"{sqlBase} WHERE {dspFilter} ORDER BY コード"
                End Select
        End Select

        stlSearchCond.Text = "検索条件: " & condText
        Me.Text = "検索 - 検索条件: " & condText
        LoadUserGrid(sqlTxt)
    End Sub

    Private Sub LoadUserGrid(ByVal sqlTxt As String)
        Try
            isUpdatingGrid = True
            Dim dt As DataTable = QueryDataTable(sqlTxt, CnMplMdb)
            dgvUsr.DataSource = dt

            If dgvUsr.Columns.Contains("支部名") Then dgvUsr.Columns("支部名").Width = 72
            If dgvUsr.Columns.Contains("コード") Then dgvUsr.Columns("コード").Width = 58
            If dgvUsr.Columns.Contains("施術所名") Then dgvUsr.Columns("施術所名").Width = 145
            If dgvUsr.Columns.Contains("柔整師名") Then dgvUsr.Columns("柔整師名").Width = 95
            If dgvUsr.Columns.Contains("電話番号") Then dgvUsr.Columns("電話番号").Width = 100
            If dgvUsr.Columns.Contains("削除") Then dgvUsr.Columns("削除").Visible = False

            stlRecCount.Text = $"対象件数：{dt.Rows.Count}件"
            lblUsrGridHeader.Text = $" ユーザー一覧 ({dt.Rows.Count}件)"

            isUpdatingGrid = False

            If dt.Rows.Count > 0 Then
                If dgvUsr.Rows.Count > 0 Then
                    dgvUsr.ClearSelection()
                    dgvUsr.Rows(0).Selected = True
                End If
                Dim cd As String = TrimX(NulCut(dt.Rows(0)("コード")))
                DisplayUserDetails(cd)
            Else
                DisplayUserDetails("")
            End If
        Catch ex As Exception
            isUpdatingGrid = False
            MessageBox.Show("ユーザー検索中にエラーが発生しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub dgvUsr_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvUsr.CellFormatting
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvUsr.Rows.Count Then Return
        If dgvUsr.Columns.Contains("削除") Then
            Dim delVal As String = TrimX(NulCut(dgvUsr.Rows(e.RowIndex).Cells("削除").Value))
            If delVal = "2" Then
                e.CellStyle.BackColor = ColorFromVbLong(&HB493F7)
            ElseIf delVal = "3" Then
                e.CellStyle.BackColor = ColorFromVbLong(&HA69564)
                e.CellStyle.ForeColor = Color.White
            End If
        End If
    End Sub

    Private Sub dgvUsr_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUsr.SelectionChanged
        If isUpdatingGrid Then Return
        If dgvUsr.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvUsr.SelectedRows(0)
            Dim cd As String = TrimX(NulCut(row.Cells("コード").Value))
            If cd <> currentCode Then
                DisplayUserDetails(cd)
            End If
        End If
    End Sub

    Public Sub SelectUserByCode(ByVal targetCd As String)
        targetCd = GetNumAlp(targetCd)
        For Each row As DataGridViewRow In dgvUsr.Rows
            If GetNumAlp(NulCut(row.Cells("コード").Value)) = targetCd Then
                isUpdatingGrid = True
                dgvUsr.ClearSelection()
                row.Selected = True
                dgvUsr.FirstDisplayedScrollingRowIndex = row.Index
                isUpdatingGrid = False
                DisplayUserDetails(targetCd)
                Return
            End If
        Next
        ' グリッド内に無い場合も詳細表示を実行
        DisplayUserDetails(targetCd)
    End Sub

    ' =========================================================================
    ' ユーザー詳細表示 (LblCode_Change / Usrdsp 相当)
    ' =========================================================================
    Public Sub DisplayUserDetails(ByVal rawCd As String)
        tmrRrk.Stop()

        If String.IsNullOrWhiteSpace(rawCd) Then
            currentCode = ""
            ClearUserDetails()
            Return
        End If

        Dim cdSql As String = GetUcdSql(rawCd)
        currentCode = GetNumAlp(rawCd)
        txtCode.Text = currentCode

        Try
            Dim sql As String = $"SELECT * FROM ユーザーデータ WHERE コード = {cdSql} AND {GetDspFilterSql()}"
            Dim dt As DataTable = QueryDataTable(sql, CnMplMdb)
            If dt.Rows.Count = 0 Then
                ' フィルタ外でも直接指定時は取得試行
                dt = QueryDataTable($"SELECT * FROM ユーザーデータ WHERE コード = {cdSql}", CnMplMdb)
            End If

            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                txtSibu.Text = NulCut(r("支部名"))
                txtSjName.Text = NulCut(r("施術所名"))
                txtSjNameF.Text = NulCut(r("施術所ﾌﾘｶﾞﾅ"))
                txtJsName.Text = NulCut(r("柔整師名"))
                txtJsNameF.Text = NulCut(r("フリガナ"))

                Dim delFlag As String = TrimX(NulCut(r("削除")))
                Select Case delFlag
                    Case "2"
                        txtSjNameF.BackColor = ColorFromVbLong(&HB493F7)
                        txtSjName.BackColor = ColorFromVbLong(&HB493F7)
                        txtSjNameF.ForeColor = Color.Black
                        txtSjName.ForeColor = Color.Black
                    Case "3"
                        txtSjNameF.BackColor = ColorFromVbLong(&HA69564)
                        txtSjName.BackColor = ColorFromVbLong(&HA69564)
                        txtSjNameF.ForeColor = Color.White
                        txtSjName.ForeColor = Color.White
                    Case Else
                        txtSjNameF.BackColor = Color.White
                        txtSjName.BackColor = Color.White
                        txtSjNameF.ForeColor = Color.Black
                        txtSjName.ForeColor = Color.Black
                End Select

                txtTel.Text = NulCut(r("電話番号"))
                txtMhTel.Text = NulCut(r("自宅電話番号"))
                txtMbTel.Text = NulCut(r("携帯"))
                txtFax.Text = NulCut(r("FAX番号"))
                txtMhAdd.Text = NulCut(r("自宅〒")) & Environment.NewLine & NulCut(r("自宅住所"))

                txtVupAdd.Text = NulCut(r("VUP送付先〒")) & " " & NulCut(r("VUP送付先住所1")) & " " & NulCut(r("VUP送付先住所2")) & Environment.NewLine &
                                 NulCut(r("VUP送付先電話番号")) & Environment.NewLine &
                                 NulCut(r("VUP送付先屋号")) & "  " & NulCut(r("VUP送付先名前")) & "   (" & NulCut(r("VUP送付先備考")) & ")"

                txtPcAdd.Text = NulCut(r("機械設置場所〒")) & " " & NulCut(r("機械設置場所住所1")) & " " & NulCut(r("機械設置場所住所2")) & Environment.NewLine &
                                NulCut(r("機械設置場所電話番号")) & Environment.NewLine &
                                NulCut(r("機械設置場所屋号")) & "  " & NulCut(r("機械設置場所名前")) & "   (" & NulCut(r("機械設置場所備考")) & ")"

                Dim vupUse As Boolean = NulCutBool(r("VUP送付先使用"))
                Dim pcPlaceUse As Boolean = NulCutBool(r("機械設置場所使用"))

                lblVupAddTitle.Visible = vupUse
                txtVupAdd.Visible = vupUse
                lblPcAddTitle.Visible = pcPlaceUse
                txtPcAdd.Visible = pcPlaceUse

                If vupUse OrElse pcPlaceUse Then
                    txtTel.BackColor = ColorFromVbLong(&HE2F4FA)
                    txtAdd.BackColor = ColorFromVbLong(&HE2F4FA)
                    txtTel.ForeColor = ColorFromVbLong(&H1F88A7)
                    txtAdd.ForeColor = ColorFromVbLong(&H1F88A7)
                Else
                    txtTel.BackColor = Color.White
                    txtAdd.BackColor = Color.White
                    txtTel.ForeColor = Color.FromArgb(192, 0, 0)
                    txtAdd.ForeColor = Color.Black
                End If

                currentZip = NulCut(r("〒"))
                currentAd1 = NulCut(r("住所1"))
                currentAd2 = NulCut(r("住所2"))
                txtAdd.Text = currentZip & Environment.NewLine & currentAd1 & Environment.NewLine & currentAd2

                txtSinryou.Text = NulCut(r("診療時間"))
                txtVer.Text = NulCut(r("分院Version"))

                txtPc0.Text = NulCut(r("本体機種名"))
                txtPrt0.Text = NulCut(r("プリンター機種名"))
                txtMn0.Text = NulCut(r("画面機種名"))
                txtHdd0.Text = NulCut(r("HDD機種名"))
                txtBcr0.Text = NulCut(r("BCR機種名"))
                txtMiniPrt0.Text = If(dt.Columns.Contains("小型プリンター機種名"), NulCut(r("小型プリンター機種名")), "")

                txtPc1.Text = NulCut(r("本体SN"))
                txtPrt1.Text = NulCut(r("プリンターSN"))
                txtMn1.Text = NulCut(r("画面SN"))
                txtHdd1.Text = NulCut(r("HDDSN"))
                txtBcr1.Text = NulCut(r("BCRSN"))
                txtMiniPrt1.Text = If(dt.Columns.Contains("小型プリンターSN"), NulCut(r("小型プリンターSN")), "")

                Select Case CInt(Val(NulCut(r("回収方法"))))
                    Case 1
                        txtSiharai.Text = "リース"
                    Case 2
                        txtSiharai.Text = "現金"
                    Case Else
                        txtSiharai.Text = ""
                End Select

                txtLeaseCo.Text = NulCut(r("リース会社"))
                txtLeaseStDate.Text = NulCut(r("リース申込日"))
                txtLease1.Text = If(dt.Columns.Contains("ﾘｰｽ１"), NulCut(r("ﾘｰｽ１")), "")
                txtLease2.Text = If(dt.Columns.Contains("ﾘｰｽ2"), NulCut(r("ﾘｰｽ2")), "")

                txtMemo.Text = NulCut(r("備考"))
                txtNohin.Text = NulCut(r("納品年月日"))
                txtLicense.Text = TrimX(NulCut(r("保守開始"))) & "～" & TrimX(NulCut(r("保守満了")))
                txtTanto.Text = NulCut(r("担当"))

                ' ステータスタグ判定と生成
                BuildStatusTags(r, dt.Columns)

                ' 関連テーブル情報表示
                MemoDsp(currentCode)
                TelExDsp(currentCode)
                EtcInfoDsp(currentCode)
                PMemoCheck(currentCode)
                LstMntUsrDsp(currentCode)
                HfgMntUsrDsp(currentCode)
                MapDsp(currentCode)

                tmrRrk.Start()
            Else
                ClearUserDetails()
            End If
        Catch ex As Exception
            MessageBox.Show("ユーザー詳細の取得中にエラーが発生しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub BuildStatusTags(ByVal r As DataRow, ByVal cols As DataColumnCollection)
        flpTags.Controls.Clear()

        Dim verStr As String = NulCut(r("分院Version"))
        Dim bikouStr As String = NulCut(r("備考"))
        Dim delStr As String = TrimX(NulCut(r("削除")))
        Dim manryouStr As String = TrimX(NulCut(r("保守満了")))

        Dim buninF As Boolean = (InStr(verStr, "分院") > 0)
        Dim kaikeiF As Boolean = (InStr(verStr, "会計") > 0)
        Dim shinsatukenF As Boolean = (InStr(bikouStr, "新・診察券") > 0)

        Dim licenseErr As Boolean = False
        Dim verLower As String = LCase(CnvZH3(verStr))
        If delStr = "1" AndAlso (InStr(verLower, "xp") > 0 OrElse InStr(verLower, "vista") > 0 OrElse InStr(verLower, "w7") > 0 OrElse InStr(verLower, "w8") > 0) AndAlso manryouStr <> "**********" Then
            If Not buninF Then
                Dim parts() As String = manryouStr.Split("."c)
                If parts.Length = 3 Then
                    Dim y As Integer = CInt(Val(parts(0)))
                    Dim m As Integer = CInt(Val(parts(1)))
                    Dim d As Integer = CInt(Val(parts(2)))
                    If y < 1980 OrElse y > 2050 OrElse m < 1 OrElse m > 12 OrElse d < 1 OrElse d > 31 Then
                        licenseErr = True
                    ElseIf $"{y:0000}{m:00}{d:00}" < DateTime.Now.ToString("yyyyMMdd") Then
                        licenseErr = True
                    End If
                Else
                    licenseErr = True
                End If
            End If
        End If

        If licenseErr Then
            AddTagBadge("ライセンス期間確認", Color.Red, Color.White, True)
        End If
        If buninF Then
            AddTagBadge("分院", ColorFromVbLong(&H7E7E7E), Color.White, False)
        End If
        If kaikeiF Then
            AddTagBadge("会計処理", ColorFromVbLong(&HA5D9B2), ColorFromVbLong(&H234532), True)
        End If
        If shinsatukenF Then
            AddTagBadge("新・診察券システム", ColorFromVbLong(&H63EBFA), ColorFromVbLong(&H333333), True)
        End If
        If NulCutBool(r("VUP送付先使用")) Then
            AddTagBadge("Vup送付先別", Color.Blue, Color.White, False)
        End If
        If NulCutBool(r("機械設置場所使用")) Then
            AddTagBadge("機械設置場所別", ColorFromVbLong(&H468723), Color.White, False)
        End If
        If cols.Contains("小型プリンター使用") AndAlso NulCutBool(r("小型プリンター使用")) Then
            AddTagBadge("小型プリンター", ColorFromVbLong(&H80B3FF), Color.White, True)
        End If
        If cols.Contains("FDD情報") AndAlso NulCutN(r("FDD情報")) = 2 Then
            AddTagBadge("FDD外付け", ColorFromVbLong(&HB7EFFF), ColorFromVbLong(&H1D495A), True)
        End If

        Dim vupType As Integer = If(cols.Contains("VupType"), CInt(NulCutN(r("VupType"))), 0)
        Select Case vupType
            Case 1
                AddTagBadge("VUP:ネット", ColorFromVbLong(&HFFDFBF), Color.Navy, True, True)
            Case 2
                AddTagBadge("VUP:CD", ColorFromVbLong(&HD5F5FF), Color.FromArgb(128, 64, 0), True, True)
            Case Else
                AddTagBadge("VUP:未定", SystemColors.Control, SystemColors.ControlDarkDark, False, True)
        End Select
    End Sub

    Private Sub AddTagBadge(ByVal text As String, ByVal backColor As Color, ByVal foreColor As Color, ByVal isBold As Boolean, Optional ByVal clickableForEtc As Boolean = False)
        Dim lbl As New Label() With {
            .Text = text,
            .BackColor = backColor,
            .ForeColor = foreColor,
            .AutoSize = False,
            .Size = New Size(146, 20),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Margin = New Padding(0, 0, 0, 3),
            .BorderStyle = BorderStyle.FixedSingle,
            .Font = New Font("ＭＳ Ｐゴシック", 9.0!, If(isBold, FontStyle.Bold, FontStyle.Regular))
        }
        If clickableForEtc Then
            lbl.Cursor = Cursors.Hand
            AddHandler lbl.Click, AddressOf OpenEtcInfoEditor
        End If
        flpTags.Controls.Add(lbl)
    End Sub

    Private Sub ClearUserDetails()
        txtCode.Text = ""
        txtSibu.Text = ""
        txtSjName.Text = ""
        txtSjNameF.Text = ""
        txtSjName.BackColor = Color.White
        txtSjNameF.BackColor = Color.White
        txtJsName.Text = ""
        txtJsNameF.Text = ""
        txtTel.Text = ""
        txtMhTel.Text = ""
        txtMbTel.Text = ""
        txtFax.Text = ""
        txtTelEx0.Text = ""
        txtTelEx1.Text = ""
        txtTelEx2.Text = ""
        txtTelEx3.Text = ""
        txtTelEx4.Text = ""
        txtAdd.Text = ""
        currentZip = ""
        currentAd1 = ""
        currentAd2 = ""
        txtSinryou.Text = ""
        txtVer.Text = ""
        txtPc0.Text = ""
        txtPc1.Text = ""
        txtPrt0.Text = ""
        txtPrt1.Text = ""
        txtMn0.Text = ""
        txtMn1.Text = ""
        txtHdd0.Text = ""
        txtHdd1.Text = ""
        txtBcr0.Text = ""
        txtBcr1.Text = ""
        txtMiniPrt0.Text = ""
        txtMiniPrt1.Text = ""
        txtMemo.Text = ""
        txtMemo2.Text = ""
        txtPmemo.Text = ""
        txtPcPMemo.Text = ""
        txtNohin.Text = ""
        txtLicense.Text = ""
        txtTanto.Text = ""
        txtSiharai.Text = ""
        txtLeaseCo.Text = ""
        txtLeaseStDate.Text = ""
        txtLease1.Text = ""
        txtLease2.Text = ""
        flpTags.Controls.Clear()
        lstMntLog.Items.Clear()
        dgvMntUsr.DataSource = Nothing
        txtMntSelectedContent.Text = ""
        If picMap.Image IsNot Nothing Then
            picMap.Image.Dispose()
            picMap.Image = Nothing
        End If
    End Sub

    ' =========================================================================
    ' サブテーブル表示 (メモ / 貸出機 / 拡張データ / Pメモ / メンテ履歴 / 地図)
    ' =========================================================================
    Public Sub MemoDsp(ByVal CD As String)
        Try
            Dim sqlMemo As String = "SELECT UserCD, Memo FROM メモ WHERE UserCD = " & GetUcdSql(CD)
            Dim dt As DataTable = QueryDataTable(sqlMemo, CnMntMdb)
            If dt.Rows.Count > 0 Then
                Dim m As String = NulCut(dt.Rows(0)("Memo"))
                txtPmemo.Text = m
                txtMemo2.Text = m
            Else
                txtPmemo.Text = ""
                txtMemo2.Text = ""
            End If
        Catch
            txtPmemo.Text = ""
            txtMemo2.Text = ""
        End Try
    End Sub

    Public Sub TelExDsp(ByVal CD As String)
        txtTelEx0.Text = ""
        txtTelEx1.Text = ""
        txtTelEx2.Text = ""
        txtTelEx3.Text = ""
        txtTelEx4.Text = ""
        Try
            Dim sqlTelEx As String = "SELECT * FROM 拡張データ WHERE コード = " & GetUcdSql(CD)
            Dim dt As DataTable = QueryDataTable(sqlTelEx, CnMplMdb)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                txtTelEx0.Text = TrimX(NulCut(r("電話番号追加分1")))
                txtTelEx1.Text = TrimX(NulCut(r("電話番号追加分2")))
                txtTelEx2.Text = TrimX(NulCut(r("電話番号追加分3")))
                txtTelEx3.Text = TrimX(NulCut(r("電話番号追加分4")))
                txtTelEx4.Text = TrimX(NulCut(r("電話番号追加分5")))
            End If
        Catch
        End Try
    End Sub

    Public Sub PMemoCheck(ByVal CD As String)
        txtPcPMemo.Text = ""
        lblPMemoBadge.BackColor = SystemColors.Control
        Try
            Dim sqlPM As String = "SELECT * FROM PMemo WHERE コード = " & GetUcdSql(CD) & " AND PcName = '" & GetPcName().Replace("'", "''") & "'"
            Dim dt As DataTable = QueryDataTable(sqlPM, CnMntMdb)
            If dt.Rows.Count > 0 Then
                lblPMemoBadge.BackColor = ColorFromVbLong(&H80FFB6)
                txtPcPMemo.Text = NulCut(dt.Rows(0)("内容"))
            End If
        Catch
        End Try
    End Sub

    Public Sub EtcInfoDsp(ByVal CD As String)
        lblNetBadge.Text = "ネット:不明"
        lblNetBadge.BackColor = SystemColors.Control
        lblNetBadge.ForeColor = SystemColors.ControlDarkDark

        lblImeBadge.Text = "IME:不明"
        lblImeBadge.BackColor = SystemColors.Control
        lblImeBadge.ForeColor = SystemColors.ControlDarkDark

        lblInputBadge.Text = "入力方式:不明"
        lblInputBadge.BackColor = SystemColors.Control
        lblInputBadge.ForeColor = SystemColors.ControlDarkDark

        lblClickBadge.Text = "クリック:不明"
        lblClickBadge.BackColor = SystemColors.Control
        lblClickBadge.ForeColor = SystemColors.ControlDarkDark

        btnGmapLink1.Visible = False : btnGmapLink1.Tag = ""
        btnGmapLink2.Visible = False : btnGmapLink2.Tag = ""
        btnGmapLink3.Visible = False : btnGmapLink3.Tag = ""

        Try
            Dim sqlEtc As String = "SELECT * FROM 拡張データ WHERE コード = " & GetUcdSql(CD)
            Dim dt As DataTable = QueryDataTable(sqlEtc, CnMplMdb)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                Select Case NulCutN(r("ネット接続"))
                    Case 1
                        lblNetBadge.Text = "ネット:BB"
                        lblNetBadge.BackColor = ColorFromVbLong(&HCBDEA1)
                        lblNetBadge.ForeColor = Color.Black
                    Case 2
                        lblNetBadge.Text = "ネット:電話回線"
                        lblNetBadge.BackColor = ColorFromVbLong(&HB7EFFF)
                        lblNetBadge.ForeColor = ColorFromVbLong(&H1D495A)
                    Case 3
                        lblNetBadge.Text = "ネット:無し"
                        lblNetBadge.BackColor = ColorFromVbLong(&HA4CBD2)
                        lblNetBadge.ForeColor = Color.Black
                End Select

                Select Case NulCutN(r("IME"))
                    Case 1
                        lblImeBadge.Text = "MS-IME"
                        lblImeBadge.BackColor = ColorFromVbLong(&HFFCCC1)
                        lblImeBadge.ForeColor = ColorFromVbLong(&H991F00)
                    Case 2
                        lblImeBadge.Text = "ATOK"
                        lblImeBadge.BackColor = ColorFromVbLong(&HD9D9FF)
                        lblImeBadge.ForeColor = ColorFromVbLong(&HD9)
                End Select

                Select Case NulCutN(r("入力方式"))
                    Case 1
                        lblInputBadge.Text = "ローマ字入力"
                        lblInputBadge.BackColor = ColorFromVbLong(&HCBDEA1)
                        lblInputBadge.ForeColor = Color.Black
                    Case 2
                        lblInputBadge.Text = "かな入力"
                        lblInputBadge.BackColor = ColorFromVbLong(&HB7EFFF)
                        lblInputBadge.ForeColor = ColorFromVbLong(&H1D495A)
                    Case 3
                        lblInputBadge.Text = "Ｒ－かな 切替"
                        lblInputBadge.BackColor = ColorFromVbLong(&HFFD5E1)
                        lblInputBadge.ForeColor = ColorFromVbLong(&H811E66)
                End Select

                Select Case NulCutN(r("クリックモード"))
                    Case 1
                        lblClickBadge.Text = "シングルクリック"
                        lblClickBadge.BackColor = ColorFromVbLong(&HCBDEA1)
                        lblClickBadge.ForeColor = Color.Black
                    Case 2
                        lblClickBadge.Text = "ダブルクリック"
                        lblClickBadge.BackColor = ColorFromVbLong(&HB7EFFF)
                        lblClickBadge.ForeColor = ColorFromVbLong(&H1D495A)
                End Select

                Dim g1 As String = TrimX(NulCut(r("GMapLink1")))
                Dim g2 As String = TrimX(NulCut(r("GMapLink2")))
                Dim g3 As String = TrimX(NulCut(r("GMapLink3")))
                If g1 <> "" Then btnGmapLink1.Tag = g1 : btnGmapLink1.Visible = True
                If g2 <> "" Then btnGmapLink2.Tag = g2 : btnGmapLink2.Visible = True
                If g3 <> "" Then btnGmapLink3.Tag = g3 : btnGmapLink3.Visible = True
            End If
        Catch
        End Try
    End Sub

    Public Sub LstMntUsrDsp(ByVal CD As String)
        lstMntLog.Items.Clear()
        If String.IsNullOrEmpty(CD) Then Return
        Try
            Dim sqlTxt As String = "SELECT コード, ID, Format(作業日,'yyyy/mm/dd') AS sg, 分類, 内容, 削除 FROM メンテナンス記録 " &
                                   "WHERE コード = " & GetUcdSql(CD) & " AND 削除 = False ORDER BY 作業日, ID"
            Dim dt As DataTable = QueryDataTable(sqlTxt, CnMntMdb)
            For Each r As DataRow In dt.Rows
                Dim s0 As String = Microsoft.VisualBasic.Strings.Left(TrimX(NulCut(r("分類"))) & "　　　　　　", 6)
                Dim s1 As String = CutCR(NulCut(r("内容")))
                If s1.Length > 100 Then s1 = s1.Substring(0, 100)
                lstMntLog.Items.Add($"{NulCut(r("sg"))} {s0} {s1}")
            Next
            If lstMntLog.Items.Count > 0 Then
                lstMntLog.SelectedIndex = lstMntLog.Items.Count - 1
            End If
        Catch
        End Try
    End Sub

    Public Sub HfgMntUsrDsp(ByVal CD As String)
        If String.IsNullOrEmpty(CD) Then
            dgvMntUsr.DataSource = Nothing
            lblMntCount.Text = "0件"
            txtMntSelectedContent.Text = ""
            Return
        End If

        Try
            Dim sqlMnt As String = "SELECT メンテナンス記録.ID, Format(作業日,'yyyy/mm/dd') AS 作業日, コード, 分類, 内容, 社員マスター.社員名, Format(期日,'yyyy/mm/dd') AS 期日, 完了 " &
                                   "FROM メンテナンス記録 LEFT JOIN 社員マスター ON メンテナンス記録.社員コード = 社員マスター.社員コード"

            Dim sqlKanryou As String = If(chkMntKanryou.Checked, " WHERE (完了 = True OR 完了 = False) ", " WHERE 完了 = False ")
            Dim sqlCd As String = " AND コード = " & GetUcdSql(CD)
            Dim sqlBunrui As String = ""
            If OptionMntUsrBunrui = 1 Then
                sqlBunrui = " AND 分類 LIKE '%修理%' "
            ElseIf OptionMntUsrBunrui = 2 Then
                sqlBunrui = " AND 分類 LIKE '%開発%' "
            End If
            Dim sqlKijitsu As String = $" AND 期日 BETWEEN #{MakeDateString(OptionMntUsrKijitsuSt, StlYMD)}# AND #{MakeDateString(OptionMntUsrKijitsuEd, StlYMD)}#"
            Dim sqlSort As String = If(rdoMntSortSagyou.Checked, " AND 削除 = False ORDER BY 作業日, メンテナンス記録.ID", " AND 削除 = False ORDER BY 期日, メンテナンス記録.ID")

            Dim fullSql As String = sqlMnt & sqlKanryou & sqlCd & sqlBunrui & sqlKijitsu & sqlSort
            Dim dt As DataTable = QueryDataTable(fullSql, CnMntMdb)
            dgvMntUsr.DataSource = dt
            lblMntCount.Text = $"{dt.Rows.Count}件"

            ApplyMntGridFormattingAndScroll()
        Catch ex As Exception
            lblMntCount.Text = "読込エラー"
        End Try
    End Sub

    Private Sub ApplyMntGridFormattingAndScroll()
        If dgvMntUsr.Columns.Count = 0 Then Return
        If dgvMntUsr.Columns.Contains("ID") Then dgvMntUsr.Columns("ID").Width = 52
        If dgvMntUsr.Columns.Contains("作業日") Then dgvMntUsr.Columns("作業日").Width = 85
        If dgvMntUsr.Columns.Contains("コード") Then dgvMntUsr.Columns("コード").Width = 60
        If dgvMntUsr.Columns.Contains("分類") Then dgvMntUsr.Columns("分類").Width = 80
        If dgvMntUsr.Columns.Contains("内容") Then dgvMntUsr.Columns("内容").Width = 280
        If dgvMntUsr.Columns.Contains("社員名") Then dgvMntUsr.Columns("社員名").Width = 70
        If dgvMntUsr.Columns.Contains("期日") Then dgvMntUsr.Columns("期日").Width = 85
        If dgvMntUsr.Columns.Contains("完了") Then dgvMntUsr.Columns("完了").Width = 48

        If dgvMntUsr.Rows.Count > 0 Then
            If chkMntAutoScroll.Checked Then
                Dim lastIdx As Integer = dgvMntUsr.Rows.Count - 1
                dgvMntUsr.ClearSelection()
                dgvMntUsr.Rows(lastIdx).Selected = True
                Try
                    dgvMntUsr.FirstDisplayedScrollingRowIndex = lastIdx
                Catch
                End Try
            End If
        Else
            txtMntSelectedContent.Text = ""
        End If
    End Sub

    Private Sub tabDetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabDetail.SelectedIndexChanged
        If tabDetail.SelectedTab Is tabMnt Then
            ApplyMntGridFormattingAndScroll()
        End If
    End Sub

    Private Sub dgvMntUsr_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMntUsr.CellFormatting
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvMntUsr.Rows.Count Then Return
        Dim row As DataGridViewRow = dgvMntUsr.Rows(e.RowIndex)
        Dim isDone As Boolean = NulCutBool(row.Cells("完了").Value)
        Dim bunrui As String = TrimX(NulCut(row.Cells("分類").Value))
        Dim kijitsu As String = TrimX(NulCut(row.Cells("期日").Value))
        Dim todayStr As String = DateTime.Now.ToString("yyyy/MM/dd")

        Dim fgColor As Color = Color.Black
        Dim bkColor As Color = Color.White

        If Not isDone AndAlso kijitsu <> "" AndAlso kijitsu <= todayStr Then
            fgColor = ColorFromVbLong(&HC0&)
            bkColor = ColorFromVbLong(&HF0F0FF)
        Else
            Select Case bunrui
                Case "ユーザー情報"
                    fgColor = ColorFromVbLong(&H707070)
                    bkColor = ColorFromVbLong(&HFBF2E3)
                Case "契約"
                    fgColor = ColorFromVbLong(&H707070)
                    bkColor = ColorFromVbLong(&HEAF9EE)
                Case "変更"
                    fgColor = ColorFromVbLong(&H707070)
                    bkColor = ColorFromVbLong(&HDCECF1)
                Case "注文"
                    fgColor = ColorFromVbLong(&HF576F)
                    bkColor = ColorFromVbLong(&HD6F3F9)
                Case "営業"
                    fgColor = ColorFromVbLong(&H4D4D90)
                    bkColor = ColorFromVbLong(&HDCDCEC)
                Case Else
                    fgColor = If(isDone, SystemColors.ControlDarkDark, SystemColors.WindowText)
                    bkColor = Color.White
            End Select
        End If

        If Not row.DefaultCellStyle.BackColor.IsEmpty AndAlso row.DefaultCellStyle.BackColor <> Color.White Then
            bkColor = row.DefaultCellStyle.BackColor
        End If

        e.CellStyle.ForeColor = fgColor
        e.CellStyle.BackColor = bkColor
    End Sub

    Private Sub dgvMntUsr_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMntUsr.SelectionChanged
        If dgvMntUsr.SelectedRows.Count > 0 Then
            Dim r As DataGridViewRow = dgvMntUsr.SelectedRows(0)
            Dim header As String = $"【作業日】{NulCut(r.Cells("作業日").Value)}   【期日】{NulCut(r.Cells("期日").Value)}   【分類】{NulCut(r.Cells("分類").Value)}   【担当】{NulCut(r.Cells("社員名").Value)}   【完了】{If(NulCutBool(r.Cells("完了").Value), "完了", "未完了")}"
            txtMntSelectedContent.Text = header & Environment.NewLine & New String("-"c, 60) & Environment.NewLine & NulCut(r.Cells("内容").Value)
        End If
    End Sub

    Private Sub MntFilter_Changed(sender As Object, e As EventArgs) Handles rdoMntSortSagyou.CheckedChanged, chkMntKanryou.CheckedChanged, chkMntAutoScroll.CheckedChanged
        OptionMntUsrSort = If(rdoMntSortSagyou.Checked, 1, 2)
        OptionMntUsrDspKanryou = chkMntKanryou.Checked
        OptionMntUsrAutoScroll = chkMntAutoScroll.Checked
        If currentCode <> "" Then
            HfgMntUsrDsp(currentCode)
        End If
    End Sub

    Public Sub MapDsp(ByVal CD As String)
        If picMap.Image IsNot Nothing Then
            picMap.Image.Dispose()
            picMap.Image = Nothing
        End If
        currentMapFile = ""

        If String.IsNullOrEmpty(CD) Then
            lblMapStatus.Text = "地図画像: なし"
            btnDispMap.Enabled = False
            Return
        End If

        Dim mapFolder As String = If(ModeDbLocation = CnModeNet, OptionMapPath, OptionLcMapPath)
        Dim codeNorm As String = GetNumAlp(GetUcdSql(CD))

        Dim exts() As String = {".bmp", ".gif", ".jpg"}
        For Each ext As String In exts
            Dim candidate As String = Path.Combine(mapFolder, codeNorm & ext)
            If File.Exists(candidate) Then
                currentMapFile = candidate
            End If
        Next
        ' ローカルフォールバック
        If currentMapFile = "" AndAlso mapFolder <> OptionLcMapPath Then
            For Each ext As String In exts
                Dim candidate As String = Path.Combine(OptionLcMapPath, codeNorm & ext)
                If File.Exists(candidate) Then
                    currentMapFile = candidate
                End If
            Next
        End If

        If currentMapFile <> "" AndAlso File.Exists(currentMapFile) Then
            Try
                Using fs As New FileStream(currentMapFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                    picMap.Image = Image.FromStream(fs)
                End Using
                lblMapStatus.Text = "地図ファイル: " & Path.GetFileName(currentMapFile)
                btnDispMap.Enabled = True
            Catch ex As Exception
                lblMapStatus.Text = "地図読込エラー"
                btnDispMap.Enabled = False
            End Try
        Else
            lblMapStatus.Text = "地図画像: なし"
            btnDispMap.Enabled = False
        End If
    End Sub

    Private Sub btnDispMap_Click(sender As Object, e As EventArgs) Handles btnDispMap.Click
        If currentMapFile <> "" AndAlso File.Exists(currentMapFile) Then
            OpenUrlInBrowser(currentMapFile)
        End If
    End Sub

    ' =========================================================================
    ' 印刷リスト管理 (FgPrtDsp / 追加 / 削除 / 全削除)
    ' =========================================================================
    Public Sub FgPrtDsp()
        Try
            Dim dtOut As New DataTable()
            dtOut.Columns.Add("追加日", GetType(String))
            dtOut.Columns.Add("コード", GetType(String))
            dtOut.Columns.Add("支部", GetType(String))
            dtOut.Columns.Add("施術所名", GetType(String))
            dtOut.Columns.Add("柔整師名", GetType(String))
            dtOut.Columns.Add("ID", GetType(Integer))

            Dim dtPrt As DataTable = QueryDataTable("SELECT ID, ユーザーコード, 追加日 FROM 印刷リスト ORDER BY 追加日, ID", CnPrtMdb)
            For Each prtRow As DataRow In dtPrt.Rows
                Dim ucd As String = NulCut(prtRow("ユーザーコード"))
                Dim addDt As String = MakeDateString(prtRow("追加日"), StlYMD)
                Dim prtId As Integer = CInt(Val(NulCut(prtRow("ID"))))

                Dim sibu As String = ""
                Dim sjName As String = ""
                Dim jsName As String = ""

                Dim dtUsr As DataTable = QueryDataTable("SELECT コード, 支部名, 施術所名, 柔整師名 FROM ユーザーデータ WHERE コード = " & GetUcdSql(ucd), CnMplMdb)
                If dtUsr.Rows.Count > 0 Then
                    sibu = NulCut(dtUsr.Rows(0)("支部名"))
                    sjName = NulCut(dtUsr.Rows(0)("施術所名"))
                    jsName = NulCut(dtUsr.Rows(0)("柔整師名"))
                End If

                dtOut.Rows.Add(addDt, ucd, sibu, sjName, jsName, prtId)
            Next

            dgvPrt.DataSource = dtOut
            If dgvPrt.Columns.Contains("追加日") Then dgvPrt.Columns("追加日").Width = 75
            If dgvPrt.Columns.Contains("コード") Then dgvPrt.Columns("コード").Width = 58
            If dgvPrt.Columns.Contains("支部") Then dgvPrt.Columns("支部").Width = 75
            If dgvPrt.Columns.Contains("施術所名") Then dgvPrt.Columns("施術所名").Width = 140
            If dgvPrt.Columns.Contains("柔整師名") Then dgvPrt.Columns("柔整師名").Width = 90
            If dgvPrt.Columns.Contains("ID") Then dgvPrt.Columns("ID").Width = 45

            lblPrtHeader.Text = $"印刷リスト ({dtOut.Rows.Count}件)"
        Catch
        End Try
    End Sub

    Private Sub btnPrtAdd_Click(sender As Object, e As EventArgs) Handles btnPrtAdd.Click
        If String.IsNullOrWhiteSpace(currentCode) Then Return
        Try
            Dim sql As String = $"INSERT INTO 印刷リスト ([追加日], [ユーザーコード]) VALUES (#{DateTime.Now:yyyy/MM/dd}#, '{currentCode.Replace("'", "''")}')"
            ExecuteNonQuerySql(sql, CnPrtMdb)
            FgPrtDsp()
        Catch ex As Exception
            MessageBox.Show("印刷リストへの追加に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub btnPrtDel_Click(sender As Object, e As EventArgs) Handles btnPrtDel.Click
        If dgvPrt.SelectedRows.Count = 0 Then Return
        Dim r As DataGridViewRow = dgvPrt.SelectedRows(0)
        Dim delId As Integer = CInt(Val(NulCut(r.Cells("ID").Value)))
        Dim sibu As String = NulCut(r.Cells("支部").Value)
        Dim sjName As String = NulCut(r.Cells("施術所名").Value)
        If delId > 0 Then
            If MessageBox.Show($"印刷リストから {delId}:{sibu}:{sjName} を削除します", "削除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
                ExecuteNonQuerySql($"DELETE FROM 印刷リスト WHERE ID = {delId}", CnPrtMdb)
                FgPrtDsp()
            End If
        End If
    End Sub

    Private Sub btnPrtAllDel_Click(sender As Object, e As EventArgs) Handles btnPrtAllDel.Click
        If dgvPrt.Rows.Count = 0 Then Return
        If MessageBox.Show("印刷リストからすべて削除します", "全削除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.OK Then
            ExecuteNonQuerySql("DELETE FROM 印刷リスト", CnPrtMdb)
            FgPrtDsp()
        End If
    End Sub

    Private Sub dgvPrt_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPrt.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvPrt.Rows.Count Then Return
        Dim cd As String = TrimX(NulCut(dgvPrt.Rows(e.RowIndex).Cells("コード").Value))
        If cd <> "" Then
            SelectUserByCode(cd)
        End If
    End Sub

    ' =========================================================================
    ' クリップボードコピー & Googleマップ連携
    ' =========================================================================
    Private Sub btnCopyBracket_Click(sender As Object, e As EventArgs) Handles btnCopyBracket.Click
        Dim s As String = $"[{txtCode.Text}] ({txtSibu.Text}) {txtSjName.Text} [{txtVer.Text}] {txtTel.Text}" & Environment.NewLine
        Try
            Clipboard.SetText(s)
        Catch
        End Try
    End Sub

    Private Sub btnCopyKisyu_Click(sender As Object, e As EventArgs) Handles btnCopyKisyu.Click
        Dim sb As New StringBuilder()
        sb.AppendLine("【納品日】")
        sb.AppendLine(txtNohin.Text)
        sb.AppendLine()
        sb.AppendLine("【ライセンス期間】")
        sb.AppendLine(txtLicense.Text)
        sb.AppendLine()
        sb.AppendLine("【担当】")
        sb.AppendLine(txtTanto.Text)
        sb.AppendLine()
        sb.AppendLine("【使用機種】")
        sb.AppendLine($"{txtPc0.Text}  {txtPc1.Text}")
        sb.AppendLine($"{txtPrt0.Text}  {txtPrt1.Text}")
        sb.AppendLine($"{txtMn0.Text}  {txtMn1.Text}")
        sb.AppendLine($"{txtBcr0.Text}  {txtBcr1.Text}")
        sb.AppendLine($"{txtHdd0.Text}  {txtHdd1.Text}")
        sb.AppendLine()
        Try
            Clipboard.SetText(sb.ToString())
        Catch
        End Try
    End Sub

    Private Sub btnGoogleMap_Click(sender As Object, e As EventArgs) Handles btnGoogleMap.Click
        Dim addr As String = CnvZH2(TrimX(currentAd1) & TrimX(currentAd2))
        If addr <> "" Then
            Dim url As String = "https://www.google.co.jp/maps?hl=ja&q=" & UrlEncode(addr)
            OpenMap(url)
        End If
    End Sub

    Private Sub btnGmapLink_Click(sender As Object, e As EventArgs) Handles btnGmapLink1.Click, btnGmapLink2.Click, btnGmapLink3.Click
        Dim btn As Button = TryCast(sender, Button)
        If btn IsNot Nothing AndAlso btn.Tag IsNot Nothing Then
            Dim link As String = btn.Tag.ToString().Trim()
            If link <> "" Then
                OpenMap(link)
            End If
        End If
    End Sub

    ' =========================================================================
    ' 閲覧履歴 (rrk.txt) 読込・追記・保存
    ' =========================================================================
    Private Sub LoadRrkHistory()
        cmbRrk.Items.Clear()
        Dim rrkPath As String = Path.Combine(DbPath, "rrk.txt")
        If Not File.Exists(rrkPath) Then Return

        Try
            Dim enc As Encoding = Encoding.GetEncoding(932)
            For Each line As String In File.ReadAllLines(rrkPath, enc)
                Dim s As String = line.Trim().Trim(""""c)
                If s <> "" AndAlso Not s.StartsWith("99") Then
                    cmbRrk.Items.Add(s)
                End If
            Next
            If cmbRrk.Items.Count > 0 Then
                isRrkSelecting = True
                cmbRrk.SelectedIndex = cmbRrk.Items.Count - 1
                isRrkSelecting = False
            End If
        Catch
        End Try
    End Sub

    Private Sub tmrRrk_Tick(sender As Object, e As EventArgs) Handles tmrRrk.Tick
        tmrRrk.Stop()
        If currentCode <> "" AndAlso Not cmbRrk.Focused Then
            Dim entry As String = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss} : {currentCode} : {txtSjName.Text} : {txtJsName.Text}"
            isRrkSelecting = True
            cmbRrk.Items.Add(entry)
            cmbRrk.SelectedIndex = cmbRrk.Items.Count - 1
            isRrkSelecting = False
        End If
    End Sub

    Private Sub cmbRrk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRrk.SelectedIndexChanged
        If isRrkSelecting OrElse cmbRrk.SelectedItem Is Nothing Then Return
        Dim text As String = cmbRrk.SelectedItem.ToString()
        ' Format: "YYYY/MM/DD HH:MM:SS : 000000 : ..."
        Dim parts() As String = text.Split(New String() {" : "}, StringSplitOptions.None)
        If parts.Length >= 2 Then
            Dim cd As String = TrimX(parts(1))
            If cd <> "" AndAlso cd <> currentCode Then
                SelectUserByCode(cd)
            End If
        End If
    End Sub

    Private Sub SaveRrkHistory()
        If cmbRrk.Items.Count <= 0 Then Return
        Dim rrkPath As String = Path.Combine(DbPath, "rrk.txt")
        Try
            Dim startIdx As Integer = Math.Max(0, cmbRrk.Items.Count - 200)
            Dim lines As New List(Of String)()
            For i As Integer = startIdx To cmbRrk.Items.Count - 1
                lines.Add(cmbRrk.Items(i).ToString())
            Next
            File.WriteAllLines(rrkPath, lines, Encoding.GetEncoding(932))
        Catch
        End Try
    End Sub

    ' =========================================================================
    ' フェーズ2: メンテナンス記録追加・編集・検索 & 周辺データ編集
    ' =========================================================================
    Public Sub DisplayUserByCode(ByVal targetCd As String, Optional ByVal switchToMntTab As Boolean = False)
        SelectUserByCode(targetCd)
        If switchToMntTab Then
            tabDetail.SelectedTab = tabMnt
        End If
    End Sub

    Public Sub RefreshCurrentUserData()
        If String.IsNullOrWhiteSpace(currentCode) Then Return
        MemoDsp(currentCode)
        TelExDsp(currentCode)
        EtcInfoDsp(currentCode)
        PMemoCheck(currentCode)
        LstMntUsrDsp(currentCode)
        HfgMntUsrDsp(currentCode)
    End Sub

    Private Function GetCurrentUserBannerTitle() As String
        Return $"【{currentCode}】({txtSibu.Text}) {txtSjName.Text} [{txtJsName.Text}]"
    End Function

    Private Sub btnMntAdd_Click(sender As Object, e As EventArgs) Handles btnMntAdd.Click, mnuMntAdd.Click
        If String.IsNullOrWhiteSpace(currentCode) Then Return
        Using dlg As New FrmMntEdit()
            dlg.EditDsp(currentCode, 0, 1)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                LstMntUsrDsp(currentCode)
                HfgMntUsrDsp(currentCode)
                If mntListForm IsNot Nothing AndAlso Not mntListForm.IsDisposed Then
                    mntListForm.MntDsp()
                End If
            End If
        End Using
    End Sub

    Private Sub btnMntEdit_Click(sender As Object, e As EventArgs) Handles btnMntEdit.Click, mnuMntEdit.Click
        If String.IsNullOrWhiteSpace(currentCode) Then Return
        If dgvMntUsr.SelectedRows.Count = 0 Then
            MessageBox.Show("編集するメンテナンス記録を選択してください", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim mntId As Long = NulCutN(dgvMntUsr.SelectedRows(0).Cells("ID").Value)
        If mntId <= 0 Then Return

        Using dlg As New FrmMntEdit()
            dlg.EditDsp(currentCode, mntId, 2)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                LstMntUsrDsp(currentCode)
                HfgMntUsrDsp(currentCode)
                If mntListForm IsNot Nothing AndAlso Not mntListForm.IsDisposed Then
                    mntListForm.MntDsp()
                End If
            End If
        End Using
    End Sub

    Private Sub dgvMntUsr_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMntUsr.CellDoubleClick
        If e.RowIndex < 0 Then Return
        btnMntEdit.PerformClick()
    End Sub

    Private Sub lstMntLog_DoubleClick(sender As Object, e As EventArgs) Handles lstMntLog.DoubleClick
        tabDetail.SelectedTab = tabMnt
    End Sub

    Private Sub btnMntMark_Click(sender As Object, e As EventArgs) Handles btnMntMark.Click, mnuMntMark.Click
        tabDetail.SelectedTab = tabMnt
        Using dlg As New FrmMntMark(dgvMntUsr)
            dlg.ShowDialog(Me)
        End Using
    End Sub

    Private Sub btnMntFind_Click(sender As Object, e As EventArgs) Handles btnMntFind.Click, btnMntFindTab.Click, mnuMntFind.Click
        If mntFindForm Is Nothing OrElse mntFindForm.IsDisposed Then
            mntFindForm = New FrmMntFind()
            mntFindForm.Show(Me)
        Else
            mntFindForm.Activate()
        End If
    End Sub

    Private Sub btnMntList_Click(sender As Object, e As EventArgs) Handles btnMntList.Click, btnMntListTab.Click, mnuMntList.Click
        If mntListForm Is Nothing OrElse mntListForm.IsDisposed Then
            mntListForm = New FrmMnt()
            mntListForm.Show(Me)
        Else
            mntListForm.MntDsp()
            mntListForm.Activate()
        End If
    End Sub

    Private Sub OpenMemoEditor(sender As Object, e As EventArgs) Handles btnEditMemo.Click, btnEditMemoTab1.Click, txtMemo2.DoubleClick, txtPmemo.DoubleClick
        If String.IsNullOrWhiteSpace(currentCode) Then Return
        Using dlg As New FrmMemoEdit()
            dlg.LoadMemo(currentCode, GetCurrentUserBannerTitle())
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                MemoDsp(currentCode)
            End If
        End Using
    End Sub

    Private Sub OpenPMemoEditor(sender As Object, e As EventArgs) Handles btnEditPMemo.Click, lblPMemoBadge.Click, txtPcPMemo.DoubleClick
        If String.IsNullOrWhiteSpace(currentCode) Then Return
        Using dlg As New FrmPMemo()
            dlg.LoadPMemo(currentCode, GetCurrentUserBannerTitle())
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                PMemoCheck(currentCode)
            End If
        End Using
    End Sub

    Private Sub OpenTelExEditor(sender As Object, e As EventArgs) Handles btnTelExEdit.Click, txtTelEx0.DoubleClick, txtTelEx1.DoubleClick, txtTelEx2.DoubleClick, txtTelEx3.DoubleClick, txtTelEx4.DoubleClick
        If String.IsNullOrWhiteSpace(currentCode) Then Return
        Using dlg As New FrmTel2Add()
            dlg.LoadTelEx(currentCode, GetCurrentUserBannerTitle())
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                TelExDsp(currentCode)
            End If
        End Using
    End Sub

    Private Sub OpenEtcInfoEditor(sender As Object, e As EventArgs) Handles lblImeBadge.Click, lblInputBadge.Click, lblNetBadge.Click, lblClickBadge.Click
        If String.IsNullOrWhiteSpace(currentCode) Then Return
        Using dlg As New FrmEtc()
            dlg.LoadEtcInfo(currentCode, GetCurrentUserBannerTitle())
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                DisplayUserByCode(currentCode, False)
            End If
        End Using
    End Sub

    Private Sub mnuOptAll_Click(sender As Object, e As EventArgs) Handles mnuOptAll.Click
        OpenOptionsDialog(0)
    End Sub

    Private Sub mnuOptBrowser_Click(sender As Object, e As EventArgs) Handles mnuOptBrowser.Click
        OpenOptionsDialog(5)
    End Sub

    Private Sub btnMntOpt_Click(sender As Object, e As EventArgs) Handles btnMntOpt.Click
        OpenOptionsDialog(1)
    End Sub

    Private Sub btnPrtOpt_Click(sender As Object, e As EventArgs) Handles btnPrtOpt.Click
        OpenOptionsDialog(3)
    End Sub

    Private Sub btnPrtExec_Click(sender As Object, e As EventArgs) Handles btnPrtExec.Click, mnuPrtList.Click
        PrintPrtList(Me)
    End Sub

    Private Sub btnPrt1F_Click(sender As Object, e As EventArgs) Handles btnPrt1F.Click, mnuPrtEnv1.Click
        PrintEnvelope(1, Me)
    End Sub

    Private Sub btnPrt2F_Click(sender As Object, e As EventArgs) Handles btnPrt2F.Click, mnuPrtEnv2.Click
        PrintEnvelope(2, Me)
    End Sub

    Private Sub btnMntPrt_Click(sender As Object, e As EventArgs) Handles btnMntPrt.Click, mnuPrtMntUsr.Click
        If String.IsNullOrWhiteSpace(currentCode) Then Return
        PrintMntUsr(currentCode, Me)
    End Sub

    Private Sub mnuVupLabel_Click(sender As Object, e As EventArgs) Handles mnuVupLabel.Click
        Using dlg As New FrmSql()
            dlg.ShowDialog(Me)
        End Using
    End Sub

    Public Sub OpenOptionsDialog(Optional ByVal tabIndex As Integer = 0)
        Using dlg As New FrmOpt()
            dlg.OptDsp(tabIndex, Me)
            If dlg.SettingsChanged Then
                rdoMntSortSagyou.Checked = (OptionMntUsrSort = 1)
                rdoMntSortKijitsu.Checked = (OptionMntUsrSort = 2)
                chkMntKanryou.Checked = OptionMntUsrDspKanryou
                chkMntAutoScroll.Checked = OptionMntUsrAutoScroll

                If Not String.IsNullOrWhiteSpace(currentCode) Then
                    HfgMntUsrDsp(currentCode)
                End If
                If mntListForm IsNot Nothing AndAlso Not mntListForm.IsDisposed Then
                    mntListForm.MntDsp()
                End If
            End If
        End Using
    End Sub
End Class
