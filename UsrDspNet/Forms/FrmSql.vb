Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class FrmSql
    Private _isInitializing As Boolean = False

    Private Sub FrmSql_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyAppIcon(Me)
        MakeSql()
    End Sub

    Private Function GetVerStr(ByVal ver As String) As String
        Dim verStr As String = ""
        If InStr(ver, "個") > 0 Then verStr = "P-"
        If InStr(ver, "革") > 0 Then verStr = "KK-"
        If InStr(ver, "総") > 0 Then verStr = "JS-"
        If InStr(ver, "健") > 0 Then verStr = "KJ-"
        If InStr(ver, "全") > 0 Then verStr = "ZN-"

        If verStr = "" Then
            If InStr(ver, "大阪") > 0 Then verStr = "O-"
            If InStr(ver, "兵庫") > 0 Then verStr = "H-"
        End If
        Return verStr
    End Function

    Private Sub FilterControl_Changed(sender As Object, e As EventArgs) Handles _
        optOsaka.CheckedChanged, optHyogo.CheckedChanged, optKojin.CheckedChanged,
        optKenju.CheckedChanged, optKakushin.CheckedChanged, optSoken.CheckedChanged,
        optZennichi.CheckedChanged, optIkusei.CheckedChanged,
        chkOsaka.CheckedChanged, chkHyogo.CheckedChanged, chkKyoto.CheckedChanged,
        chkOita.CheckedChanged, chkMie.CheckedChanged, chkNara.CheckedChanged,
        chkWakayama.CheckedChanged, chkEhime.CheckedChanged,
        chkXP.CheckedChanged, chkVista.CheckedChanged, chkWindows7.CheckedChanged,
        chkWindows8.CheckedChanged, chkWindows10.CheckedChanged, chkWindows11.CheckedChanged,
        chkWin16.CheckedChanged,
        optBunin.CheckedChanged, optNotBunin.CheckedChanged, optBAll.CheckedChanged,
        optKaikei.CheckedChanged, optNotKaikei.CheckedChanged, optKAll.CheckedChanged,
        OptNoFdd.CheckedChanged, OptFdd.CheckedChanged, optFddAll.CheckedChanged,
        chkVupMitei.CheckedChanged, chkVupNet.CheckedChanged, chkVupCd.CheckedChanged

        If _isInitializing Then Return

        If optOsaka.Checked OrElse optHyogo.Checked Then
            picKen.Visible = False
            chkWin16.Visible = True
        ElseIf optZennichi.Checked Then
            picKen.Visible = False
            chkWin16.Visible = False
        ElseIf optKojin.Checked Then
            picKen.Visible = True
            chkWin16.Visible = True
        Else
            picKen.Visible = True
            If chkWin16.Checked Then
                _isInitializing = True
                chkWin16.Checked = False
                chkWindows7.Checked = True
                _isInitializing = False
            End If
            chkWin16.Visible = False
        End If

        MakeSql()
    End Sub

    Private Sub cmdMakeSql_Click(sender As Object, e As EventArgs) Handles cmdMakeSql.Click
        MakeSql()
    End Sub

    Public Sub MakeSql()
        Dim sb As New StringBuilder()
        sb.AppendLine("SELECT * From ユーザーデータ ")
        sb.AppendLine(" Where (ユーザーデータ.削除 like ""%1%"" )  ")
        sb.AppendLine(" and not (ユーザーデータ.分院Version like ""%分院%"") ")

        If optOsaka.Checked Then
            sb.AppendLine("  and (ユーザーデータ.分院Version like ""%大阪%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%個%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%健%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%革%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%育%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%総%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%全%"") ")
            AppendOsFilter(sb, True)
            AppendBuninFilter(sb)
        ElseIf optHyogo.Checked Then
            sb.AppendLine("  and (ユーザーデータ.分院Version like ""%兵庫%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%個%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%健%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%革%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%育%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%総%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%全%"") ")
            AppendOsFilter(sb, True)
            AppendBuninFilter(sb)
        ElseIf optKojin.Checked Then
            sb.AppendLine("  and (ユーザーデータ.分院Version like ""%個%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%健%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%革%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%育%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%総%"") ")
            sb.AppendLine("  and not (ユーザーデータ.分院Version like ""%全%"") ")
            AppendOsFilter(sb, True)
            AppendKenFilter(sb)
            AppendBuninFilter(sb)
        ElseIf optKenju.Checked Then
            sb.AppendLine("  and (ユーザーデータ.分院Version like ""%健%"") ")
            AppendOsFilter(sb, False)
            AppendKenFilter(sb)
            AppendBuninFilter(sb)
        ElseIf optKakushin.Checked Then
            sb.AppendLine("  and (ユーザーデータ.分院Version like ""%革%"") ")
            AppendOsFilter(sb, False)
            AppendKenFilter(sb)
            AppendBuninFilter(sb)
        ElseIf optIkusei.Checked Then
            sb.AppendLine("  and (ユーザーデータ.分院Version like ""%育%"") ")
            AppendOsFilter(sb, False)
            AppendKenFilter(sb)
            AppendBuninFilter(sb)
        ElseIf optSoken.Checked Then
            sb.AppendLine("  and (ユーザーデータ.分院Version like ""%総%"") ")
            AppendOsFilter(sb, False)
            AppendKenFilter(sb)
            AppendBuninFilter(sb)
        ElseIf optZennichi.Checked Then
            sb.AppendLine("  and (ユーザーデータ.分院Version like ""全%"") ")
            AppendOsFilter(sb, False)
            sb.AppendLine(" and (((ユーザーデータ.分院Version like ""%高知%"") or (ユーザーデータ.分院Version like ""%大阪%"")))")
            AppendBuninFilter(sb)
        End If

        If optKaikei.Checked Then sb.AppendLine(" and (ユーザーデータ.分院Version like ""%会計%"") ")
        If optNotKaikei.Checked Then sb.AppendLine(" and not (ユーザーデータ.分院Version like ""%会計%"") ")

        If OptFdd.Checked Then sb.AppendLine(" and (ユーザーデータ.FDD情報 < 3 or ユーザーデータ.FDD情報 is null) ")
        If OptNoFdd.Checked Then sb.AppendLine(" and (ユーザーデータ.FDD情報 = 3) ")

        AppendVupTypeFilter(sb)

        sb.AppendLine(" ORDER BY ユーザーデータ.コード")

        txtSql.Text = sb.ToString()
        CheckSqlCount()
    End Sub

    Private Sub AppendOsFilter(ByVal sb As StringBuilder, ByVal includeWin16 As Boolean)
        Dim parts As New List(Of String)()
        If chkXP.Checked Then parts.Add("(ユーザーデータ.分院Version Like ""%XP%"")")
        If chkVista.Checked Then parts.Add("(ユーザーデータ.分院Version Like ""%VISTA%"")")
        If chkWindows7.Checked Then parts.Add("(ユーザーデータ.分院Version Like ""%W7%"")")
        If chkWindows8.Checked Then parts.Add("(ユーザーデータ.分院Version Like ""%W8%"")")
        If chkWindows10.Checked Then parts.Add("(ユーザーデータ.分院Version Like ""%W10%"")")
        If chkWindows11.Checked Then parts.Add("(ユーザーデータ.分院Version Like ""%W11%"")")
        If includeWin16 AndAlso chkWin16.Checked Then parts.Add("(ユーザーデータ.分院Version Like ""%WIN%"")")

        If parts.Count > 0 Then
            sb.AppendLine(" and (" & String.Join(Environment.NewLine & " or ", parts) & ")")
        End If
    End Sub

    Private Sub AppendKenFilter(ByVal sb As StringBuilder)
        Dim parts As New List(Of String)()
        If chkOsaka.Checked Then
            parts.Add("(ユーザーデータ.分院Version like ""%大阪%"")")
            If chkWin16.Checked Then parts.Add("(ユーザーデータ.分院Version like ""%大%"")")
        End If
        If chkHyogo.Checked Then parts.Add("(ユーザーデータ.分院Version like ""%兵庫%"")")
        If chkKyoto.Checked Then parts.Add("(ユーザーデータ.分院Version like ""%京都%"")")
        If chkOita.Checked Then parts.Add("(ユーザーデータ.分院Version like ""%大分%"")")
        If chkMie.Checked Then parts.Add("(ユーザーデータ.分院Version like ""%三重%"")")
        If chkNara.Checked Then parts.Add("(ユーザーデータ.分院Version like ""%奈良%"")")
        If chkWakayama.Checked Then parts.Add("(ユーザーデータ.分院Version like ""%和歌山%"")")
        If chkEhime.Checked Then parts.Add("(ユーザーデータ.分院Version like ""%愛媛%"")")

        If parts.Count > 0 Then
            sb.AppendLine(" and (" & String.Join(Environment.NewLine & " or ", parts) & ")")
        End If
    End Sub

    Private Sub AppendBuninFilter(ByVal sb As StringBuilder)
        If optBunin.Checked Then sb.AppendLine(" and (ユーザーデータ.分院Version like ""%本院%"") ")
        If optNotBunin.Checked Then sb.AppendLine(" and not (ユーザーデータ.分院Version like ""%本院%"") ")
    End Sub

    Private Sub AppendVupTypeFilter(ByVal sb As StringBuilder)
        Dim parts As New List(Of String)()
        If chkVupMitei.Checked Then parts.Add("(ユーザーデータ.VupType = 0 or ユーザーデータ.VupType is null)")
        If chkVupNet.Checked Then parts.Add("(ユーザーデータ.VupType = 1)")
        If chkVupCd.Checked Then parts.Add("(ユーザーデータ.VupType = 2)")

        If parts.Count > 0 Then
            sb.AppendLine(" and (" & String.Join(" or ", parts) & ")")
        Else
            sb.AppendLine(" and (ユーザーデータ.VupType = 99)")
        End If
    End Sub

    Private Sub cmdSqlCheck_Click(sender As Object, e As EventArgs) Handles cmdSqlCheck.Click
        CheckSqlCount()
    End Sub

    Private Sub CheckSqlCount()
        Try
            Dim dt As DataTable = QueryDataTable(txtSql.Text, CnMplMdb)
            If dt.Rows.Count > 0 Then
                lblCnt.ForeColor = Color.Black
                lblCnt.Text = $"{dt.Rows.Count:#,##0}件 該当"
            Else
                lblCnt.ForeColor = Color.Red
                lblCnt.Text = "該当無し、またはSQL文が無効"
            End If
        Catch
            lblCnt.ForeColor = Color.Red
            lblCnt.Text = "該当無し、またはSQL文が無効"
        End Try
    End Sub

    Private Function ResolveOutputFilePath(ByVal defaultNetworkDir As String, ByVal defaultFileName As String, ByVal filter As String) As String
        Try
            If ModeDbLocation = CnModeNet AndAlso Directory.Exists(defaultNetworkDir) Then
                Return Path.Combine(defaultNetworkDir, defaultFileName)
            End If
        Catch
        End Try

        Using sfd As New SaveFileDialog()
            sfd.Title = "出力先ファイルの選択"
            sfd.FileName = defaultFileName
            sfd.Filter = filter
            If sfd.ShowDialog(Me) = DialogResult.OK Then
                Return sfd.FileName
            End If
        End Using
        Return ""
    End Function

    ' 画面表示 (Command3)
    Private Sub Command3_Click(sender As Object, e As EventArgs) Handles Command3.Click
        Try
            Dim dt As DataTable = QueryDataTable(txtSql.Text, CnMplMdb)
            Using viewer As New FrmSqlViewer()
                viewer.LoadData(dt)
                viewer.ShowDialog(Me)
            End Using
        Catch ex As Exception
            MessageBox.Show("SQL実行エラー: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ' CSV出力 (Command2)
    Private Sub Command2_Click(sender As Object, e As EventArgs) Handles Command2.Click
        Dim defaultFile As String = "UD" & DateTime.Now.ToString("yy年MM月dd日 HH時mm分ss秒") & ".csv"
        Dim outPath As String = ResolveOutputFilePath("\\Nas001\開発\ユーザーデータテキスト出力", defaultFile, "CSVファイル (*.csv)|*.csv")
        If String.IsNullOrEmpty(outPath) Then Return

        Try
            Dim dt As DataTable = QueryDataTable(txtSql.Text, CnMplMdb)
            Dim sjis As Encoding = Encoding.GetEncoding(932)

            Using sw As New StreamWriter(outPath, False, sjis)
                Dim headers As New List(Of String)()
                For Each col As DataColumn In dt.Columns
                    headers.Add(AddWc(col.ColumnName))
                Next
                sw.WriteLine(String.Join(",", headers))

                For Each r As DataRow In dt.Rows
                    Dim vals As New List(Of String)()
                    For Each col As DataColumn In dt.Columns
                        Select Case col.ColumnName
                            Case "VUP送付先使用", "請求書送付先使用", "機械設置場所使用"
                                vals.Add(If(NulCutBool(r(col)), "1", "0"))
                            Case Else
                                Dim v As String = CnvHC2LC(NulCut(r(col)))
                                vals.Add(If(chkWC.Checked, AddWc(v), v))
                        End Select
                    Next
                    sw.WriteLine(String.Join(",", vals))
                Next
            End Using

            MessageBox.Show(outPath & " に出力しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("CSV出力に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ' 飛脚メール便出力 (cmdSagawa)
    Private Sub cmdSagawa_Click(sender As Object, e As EventArgs) Handles cmdSagawa.Click
        Dim defaultFile As String = "UD" & DateTime.Now.ToString("yy年MM月dd日 HH時mm分ss秒") & ".csv"
        Dim outPath As String = ResolveOutputFilePath("\\Nas001\開発\飛脚メール便", defaultFile, "CSVファイル (*.csv)|*.csv")
        If String.IsNullOrEmpty(outPath) Then Return

        Try
            Dim dt As DataTable = QueryDataTable(txtSql.Text, CnMplMdb)
            Dim sjis As Encoding = Encoding.GetEncoding(932)

            Using sw As New StreamWriter(outPath, False, sjis)
                For Each r As DataRow In dt.Rows
                    Dim verStr As String = GetVerStr(NulCut(r("分院Version")))
                    Dim vupF As Boolean = NulCutBool(r("VUP送付先使用"))
                    Dim vupYago As String
                    Dim vupJName As String
                    Dim vupPost As String
                    Dim vupAd1 As String
                    Dim vupAd2 As String
                    Dim vupAd3 As String = ""
                    Dim vupTel As String

                    If vupF Then
                        vupYago = CnvHC2LC(NulCut(r("VUP送付先屋号")))
                        vupJName = CnvHC2LC(NulCut(r("VUP送付先名前")))
                        vupPost = CnvHC2LC(NulCut(r("VUP送付先〒")))
                        vupAd1 = CnvHC2LC(NulCut(r("VUP送付先住所1")))
                        vupAd2 = CnvHC2LC(NulCut(r("VUP送付先住所2")))
                        vupTel = CnvHC2LC(NulCut(r("VUP送付先電話番号")))
                    Else
                        vupYago = CnvHC2LC(NulCut(r("施術所名")))
                        vupJName = CnvHC2LC(NulCut(r("柔整師名")))
                        vupPost = CnvHC2LC(NulCut(r("〒")))
                        vupAd1 = CnvHC2LC(NulCut(r("住所1")))
                        vupAd2 = CnvHC2LC(NulCut(r("住所2")))
                        vupTel = CnvHC2LC(NulCut(r("電話番号")))
                    End If

                    If dt.Columns.Contains("飛脚メール便使用") AndAlso NulCutBool(r("飛脚メール便使用")) Then
                        vupYago = CnvHC2LC(NulCut(r("飛脚メール便名称1")))
                        vupJName = CnvHC2LC(NulCut(r("飛脚メール便名称2")))
                        vupAd1 = CnvHC2LC(NulCut(r("飛脚メール便住所1")))
                        vupAd2 = CnvHC2LC(NulCut(r("飛脚メール便住所2")))
                        vupAd3 = CnvHC2LC(NulCut(r("飛脚メール便住所3")))
                    End If

                    Dim s As String = "00," & verStr & CnvHC2LC(NulCut(r("コード"))) & "," &
                                      vupTel & "," & vupPost & "," & vupAd1 & "," & vupAd2 & "," & vupAd3 & ","
                    If Trim(vupYago) <> "" Then
                        s &= vupYago & "," & If(vupJName <> "", vupJName & " 先生,", ",")
                    ElseIf vupJName <> "" Then
                        s &= vupJName & " 先生,(" & CnvHC2LC(NulCut(r("施術所名"))) & "),"
                    Else
                        s &= ",,"
                    End If
                    s &= "184175150009"
                    sw.WriteLine(s)
                Next
            End Using

            MessageBox.Show(outPath & " に出力しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("飛脚メール便CSV出力に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ' 佐川急便住所録出力 (cmdSagawaAd)
    Private Sub cmdSagawaAd_Click(sender As Object, e As EventArgs) Handles cmdSagawaAd.Click
        Dim defaultFile As String = "UD" & DateTime.Now.ToString("yy年MM月dd日 HH時mm分ss秒") & ".csv"
        Dim outPath As String = ResolveOutputFilePath("\\Nas001\開発\佐川急便住所録", defaultFile, "CSVファイル (*.csv)|*.csv")
        If String.IsNullOrEmpty(outPath) Then Return

        Try
            Dim dt As DataTable = QueryDataTable(txtSql.Text, CnMplMdb)
            Dim sjis As Encoding = Encoding.GetEncoding(932)

            Using sw As New StreamWriter(outPath, False, sjis)
                For Each r As DataRow In dt.Rows
                    Dim verStr As String = "D" & GetVerStr(NulCut(r("分院Version")))
                    Dim vupF As Boolean = NulCutBool(r("VUP送付先使用"))
                    Dim vupYago As String
                    Dim vupJName As String
                    Dim vupPost As String
                    Dim vupAd1 As String
                    Dim vupAd2 As String
                    Dim vupAd3 As String = ""
                    Dim vupTel As String

                    If vupF Then
                        vupYago = CnvHC2LC(NulCut(r("VUP送付先屋号")))
                        vupJName = CnvHC2LC(NulCut(r("VUP送付先名前")))
                        vupPost = CnvHC2LC(NulCut(r("VUP送付先〒")))
                        vupAd1 = CnvHC2LC(NulCut(r("VUP送付先住所1")))
                        vupAd2 = CnvHC2LC(NulCut(r("VUP送付先住所2")))
                        vupTel = CnvHC2LC(NulCut(r("VUP送付先電話番号")))
                    Else
                        vupYago = CnvHC2LC(NulCut(r("施術所名")))
                        vupJName = CnvHC2LC(NulCut(r("柔整師名")))
                        vupPost = CnvHC2LC(NulCut(r("〒")))
                        vupAd1 = CnvHC2LC(NulCut(r("住所1")))
                        vupAd2 = CnvHC2LC(NulCut(r("住所2")))
                        vupTel = CnvHC2LC(NulCut(r("電話番号")))
                    End If

                    If dt.Columns.Contains("飛脚メール便使用") AndAlso NulCutBool(r("飛脚メール便使用")) Then
                        vupYago = CnvHC2LC(NulCut(r("飛脚メール便名称1")))
                        vupJName = CnvHC2LC(NulCut(r("飛脚メール便名称2")))
                        vupAd1 = CnvHC2LC(NulCut(r("飛脚メール便住所1")))
                        vupAd2 = CnvHC2LC(NulCut(r("飛脚メール便住所2")))
                        vupAd3 = CnvHC2LC(NulCut(r("飛脚メール便住所3")))
                    End If

                    Dim s As String = verStr & CnvHC2LC(NulCut(r("コード"))) & ",," & vupTel & ",99,," &
                                      vupPost & "," & vupAd1 & "," & vupAd2 & "," & vupAd3 & ","
                    If Trim(vupYago) <> "" Then
                        s &= vupYago & "," & If(vupJName <> "", vupJName & ",", ",")
                    ElseIf vupJName <> "" Then
                        s &= vupJName & ",(" & CnvHC2LC(NulCut(r("施術所名"))) & "),"
                    Else
                        s &= ",,"
                    End If
                    s &= "0,0,,,,,,,"
                    sw.WriteLine(s)
                Next
            End Using

            MessageBox.Show(outPath & " に出力しました", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("佐川急便住所録出力に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    ' 上記SQL文で印刷画面へ (Command1)
    Private Sub Command1_Click(sender As Object, e As EventArgs) Handles Command1.Click
        Dim defaultFile As String = "VupLbl " & DateTime.Now.ToString("yy年MM月dd日 HH時mm分ss秒") & ".txt"
        Dim outPath As String = ResolveOutputFilePath("\\nas001\ud4data\Vupラベル処理\text", defaultFile, "テキストファイル (*.txt)|*.txt")
        If String.IsNullOrEmpty(outPath) Then Return

        Try
            Dim dt As DataTable = QueryDataTable(txtSql.Text, CnMplMdb)
            Dim sjis As Encoding = Encoding.GetEncoding(932)

            Using sw As New StreamWriter(outPath, False, sjis)
                Dim headers As New List(Of String)()
                For Each col As DataColumn In dt.Columns
                    headers.Add(TrimX(col.ColumnName))
                Next
                sw.WriteLine(String.Join(";", headers))

                For Each r As DataRow In dt.Rows
                    Dim vals As New List(Of String)()
                    For Each col As DataColumn In dt.Columns
                        Select Case col.ColumnName
                            Case "VUP送付先使用", "請求書送付先使用", "機械設置場所使用"
                                vals.Add(If(NulCutBool(r(col)), "1", "0"))
                            Case Else
                                vals.Add(NulCut(r(col)))
                        End Select
                    Next
                    sw.WriteLine(String.Join(";", vals))
                Next
            End Using

            Dim vupExe As String = Path.Combine(ProgramFilesFolder, "UsrDspM\VupLabel.exe")
            Dim vupExe86 As String = "C:\Program Files (x86)\UsrDspM\VupLabel.exe"
            If File.Exists(vupExe) Then
                Process.Start(vupExe, """" & outPath & """")
            ElseIf File.Exists(vupExe86) Then
                Process.Start(vupExe86, """" & outPath & """")
            Else
                MessageBox.Show("ラベルデータを出力しました:" & Environment.NewLine & outPath, "出力完了", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("ラベルデータ出力に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class
