Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.IO
Imports System.Windows.Forms

Public Module MdlPrt
    Public Const CsStp As Integer = 1                 ' 終了位置ステップ指定
    Public Const CsLnP As Integer = 2                 ' 枠を印刷する
    Public Const CsDrawWidth1 As Integer = 4          ' 枠の太さ..1
    Public Const CsDrawWidth3 As Integer = 8          ' 枠の太さ..3
    Public Const CsDrawWidth5 As Integer = 16         ' 枠の太さ..5
    Public Const CsFntBold As Integer = 32            ' 文字を太字で
    Public Const CsFntUnder As Integer = 64           ' 文字にアンダーライン
    Public Const CsFntItalic As Integer = 128         ' 文字を斜体に
    Public Const CsLeftTop As Integer = 256           ' 文字印刷位置  左詰 上
    Public Const CsLeftMiddle As Integer = 512        ' 文字印刷位置  左詰 中
    Public Const CsLeftBottom As Integer = 1024       ' 文字印刷位置  左詰 下
    Public Const CsCenterTop As Integer = 2048        ' 文字印刷位置  中央 上
    Public Const CsCenterMiddle As Integer = 4096     ' 文字印刷位置  中央 中
    Public Const CsCenterBottom As Integer = 8192     ' 文字印刷位置  中央 下
    Public Const CsRightTop As Integer = 16384        ' 文字印刷位置  右詰 上
    Public Const CsRightMiddle As Integer = 32768     ' 文字印刷位置  右詰 中
    Public Const CsRightBottom As Integer = 65536     ' 文字印刷位置  右詰 下
    Public Const CsDsSolid As Integer = 131072        ' 線種   実線
    Public Const CsDsDash As Integer = 262144         ' 線種   破線
    Public Const CsDsDot As Integer = 524288          ' 線種   点線
    Public Const CsDsDashDot As Integer = 1048576     ' 線種   一点鎖線
    Public Const CsDef As Integer = CsStp + CsLnP

    Private Const FnGt As String = "ＭＳ ゴシック"
    Private Const FnMn As String = "ＭＳ 明朝"

    ''' <summary>
    ''' VB6 MdlPrt.PrintStr の .NET Graphics (Millimeter単位) 互換実装
    ''' </summary>
    Public Sub PrintStr(ByVal g As Graphics, ByVal S As String, ByVal FName As String, ByVal FSize As Single, ByVal X1 As Single, ByVal Y1 As Single, ByVal X2 As Single, ByVal Y2 As Single, ByVal Sw As Integer)
        g.PageUnit = GraphicsUnit.Millimeter

        If Sw = 0 Then
            Sw = CsStp + CsLnP + CsDrawWidth1 + CsLeftMiddle + CsDsSolid
        End If

        Dim ww As Single = If((Sw And CsStp) <> 0, X2, X2 - X1)
        Dim hh As Single = If((Sw And CsStp) <> 0, Y2, Y2 - Y1)
        If ww <= 0 OrElse hh <= 0 Then Return

        ' 枠の太さ設定 (mm換算)
        Dim penWidthMm As Single = 0.18F
        Dim swn As Integer = (Sw And CsDrawWidth1) + (Sw And CsDrawWidth3) + (Sw And CsDrawWidth5)
        Select Case swn
            Case CsDrawWidth3
                penWidthMm = 0.35F
            Case CsDrawWidth5
                penWidthMm = 0.55F
            Case Else
                penWidthMm = 0.18F
        End Select

        ' 枠の線種設定
        Dim dashStyle As DashStyle = DashStyle.Solid
        swn = (Sw And CsDsSolid) + (Sw And CsDsDash) + (Sw And CsDsDot) + (Sw And CsDsDashDot)
        Select Case swn
            Case CsDsDash
                dashStyle = DashStyle.Dash
            Case CsDsDot
                dashStyle = DashStyle.Dot
            Case CsDsDashDot
                dashStyle = DashStyle.DashDot
            Case Else
                dashStyle = DashStyle.Solid
        End Select

        ' 枠印刷
        If (Sw And CsLnP) <> 0 Then
            Using p As New Pen(Color.Black, penWidthMm)
                p.DashStyle = dashStyle
                g.DrawRectangle(p, X1, Y1, ww, hh)
            End Using
        End If

        If String.IsNullOrEmpty(S) Then Return

        Dim fontName As String = If(String.IsNullOrWhiteSpace(FName), FnGt, FName.Trim())
        Dim curSize As Single = If(FSize <= 0, 12.0F, FSize)

        Dim fStyle As FontStyle = FontStyle.Regular
        If (Sw And CsFntBold) <> 0 Then fStyle = fStyle Or FontStyle.Bold
        If (Sw And CsFntItalic) <> 0 Then fStyle = fStyle Or FontStyle.Italic
        If (Sw And CsFntUnder) <> 0 Then fStyle = fStyle Or FontStyle.Underline

        Dim sf As StringFormat = StringFormat.GenericTypographic
        Dim lw As Single = 0
        Dim th As Single = 0

        While curSize > 1.5F
            Using testFont As New Font(fontName, curSize, fStyle, GraphicsUnit.Point)
                Dim sz As SizeF = g.MeasureString(S, testFont, 10000, sf)
                lw = sz.Width
                th = sz.Height
                If lw <= ww - 0.8F AndAlso th <= hh - 0.2F Then
                    Exit While
                End If
            End Using
            curSize -= 0.5F
        End While

        Using drawFont As New Font(fontName, Math.Max(1.5F, curSize), fStyle, GraphicsUnit.Point)
            Dim sz As SizeF = g.MeasureString(S, drawFont, 10000, sf)
            lw = sz.Width
            th = sz.Height

            Dim cx As Single = X1 + 0.5F
            Dim cy As Single = Y1 + ((hh - th) / 2.0F)

            swn = (Sw And CsLeftTop) + (Sw And CsLeftMiddle) + (Sw And CsLeftBottom) +
                  (Sw And CsCenterTop) + (Sw And CsCenterMiddle) + (Sw And CsCenterBottom) +
                  (Sw And CsRightTop) + (Sw And CsRightMiddle) + (Sw And CsRightBottom)

            Select Case swn
                Case CsLeftTop
                    cx = X1 + 0.5F
                    cy = Y1 + 0.4F
                Case CsLeftMiddle
                    cx = X1 + 0.5F
                    cy = Y1 + ((hh - th) / 2.0F)
                Case CsLeftBottom
                    cx = X1 + 0.5F
                    cy = Y1 + (hh - th - 0.4F)
                Case CsCenterTop
                    cx = X1 + ((ww - lw) / 2.0F)
                    cy = Y1 + 0.4F
                Case CsCenterMiddle
                    cx = X1 + ((ww - lw) / 2.0F)
                    cy = Y1 + ((hh - th) / 2.0F)
                Case CsCenterBottom
                    cx = X1 + ((ww - lw) / 2.0F)
                    cy = Y1 + (hh - th - 0.4F)
                Case CsRightTop
                    cx = X1 + (ww - lw - 0.5F)
                    cy = Y1 + 0.4F
                Case CsRightMiddle
                    cx = X1 + (ww - lw - 0.5F)
                    cy = Y1 + ((hh - th) / 2.0F)
                Case CsRightBottom
                    cx = X1 + (ww - lw - 0.5F)
                    cy = Y1 + (hh - th - 0.4F)
            End Select

            Dim prevClip As Region = g.Clip
            g.SetClip(New RectangleF(X1, Y1, ww, hh))
            g.DrawString(S, drawFont, Brushes.Black, cx, cy, sf)
            g.Clip = prevClip
        End Using
    End Sub

    Private Function FindMapFilePath(ByVal cd As String) As String
        Dim code6 As String = GetNumAlp(cd)
        Dim exts() As String = {".gif", ".jpg", ".png", ".bmp"}
        Dim folders As New List(Of String)()
        If ModeDbLocation = CnModeNet AndAlso Not String.IsNullOrWhiteSpace(OptionMapPath) Then
            folders.Add(OptionMapPath)
        End If
        If Not String.IsNullOrWhiteSpace(OptionLcMapPath) Then
            folders.Add(OptionLcMapPath)
        End If
        folders.Add("C:\UsrDsp\map")

        For Each folder In folders
            For Each ext In exts
                Try
                    Dim p As String = Path.Combine(folder, code6 & ext)
                    If File.Exists(p) Then Return p
                Catch
                End Try
            Next
        Next
        Return ""
    End Function

    Private Sub DrawMapInBox(ByVal g As Graphics, ByVal cd As String, ByVal boxX As Single, ByVal boxY As Single, ByVal maxW As Single, ByVal maxH As Single)
        If Not OptionPrtMap Then Return
        Dim mapFile As String = FindMapFilePath(cd)
        If String.IsNullOrEmpty(mapFile) Then Return

        Try
            Using fs As New FileStream(mapFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                Using srcImg As Image = Image.FromStream(fs)
                    Dim imgWmm As Single = CSng(srcImg.Width * 25.4 / Math.Max(72.0F, srcImg.HorizontalResolution))
                    Dim imgHmm As Single = CSng(srcImg.Height * 25.4 / Math.Max(72.0F, srcImg.VerticalResolution))

                    Dim psX As Single = maxW / Math.Max(1.0F, imgWmm)
                    Dim psY As Single = maxH / Math.Max(1.0F, imgHmm)
                    Dim ps As Single = Math.Min(psX, psY)

                    Dim drawW As Single = imgWmm
                    Dim drawH As Single = imgHmm
                    If imgWmm > maxW OrElse imgHmm > maxH Then
                        drawW = imgWmm * ps
                        drawH = imgHmm * ps
                    End If

                    If OptionPrtColor Then
                        g.DrawImage(srcImg, New RectangleF(boxX, boxY, drawW, drawH))
                    Else
                        ' モノクロ変換描画
                        Using ia As New ImageAttributes()
                            Dim cm As New ColorMatrix(New Single()() {
                                New Single() {0.299F, 0.299F, 0.299F, 0, 0},
                                New Single() {0.587F, 0.587F, 0.587F, 0, 0},
                                New Single() {0.114F, 0.114F, 0.114F, 0, 0},
                                New Single() {0, 0, 0, 1, 0},
                                New Single() {0, 0, 0, 0, 1}
                            })
                            ia.SetColorMatrix(cm)
                            Dim destPts() As PointF = {
                                New PointF(boxX, boxY),
                                New PointF(boxX + drawW, boxY),
                                New PointF(boxX, boxY + drawH)
                            }
                            g.DrawImage(srcImg, destPts, New RectangleF(0, 0, srcImg.Width, srcImg.Height), GraphicsUnit.Pixel, ia)
                        End Using
                    End If
                End Using
            End Using
        Catch
        End Try
    End Sub

    ' =========================================================================
    ' 1. 印刷リストの印刷 (OptionPrtMei = 1, 2, 4)
    ' =========================================================================
    Public Sub PrintPrtList(Optional ByVal owner As IWin32Window = Nothing)
        Dim dtPrt As DataTable = QueryDataTable("SELECT * FROM 印刷リスト", CnPrtMdb)
        If dtPrt.Rows.Count = 0 Then
            MessageBox.Show("印刷リストにユーザーが登録されていません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim codes As New List(Of String)()
        For Each r As DataRow In dtPrt.Rows
            Dim cd As String = TrimX(NulCut(r("ユーザーコード")))
            If cd <> "" Then codes.Add(cd)
        Next
        If codes.Count = 0 Then Return

        Using pd As New PrintDocument()
            pd.DocumentName = "ユーザー情報印刷"
            pd.DefaultPageSettings.Landscape = False
            pd.DefaultPageSettings.Color = (OptionPrtColor AndAlso OptionPrtMap)

            Using dlg As New PrintDialog()
                dlg.Document = pd
                dlg.UseEXDialog = True
                If dlg.ShowDialog(owner) <> DialogResult.OK Then Return
            End Using

            Dim curIdx As Integer = 0
            Dim itemsPerPage As Integer = If(OptionPrtMei = 1, 1, If(OptionPrtMei = 2, 2, 4))

            AddHandler pd.PrintPage,
                Sub(sender As Object, e As PrintPageEventArgs)
                    Dim g As Graphics = e.Graphics
                    g.PageUnit = GraphicsUnit.Millimeter

                    Dim stX As Single = 5.0F
                    Dim stY As Single = If(itemsPerPage = 1, 2.0F, 5.0F)
                    Dim nowX As Single = stX
                    Dim nowY As Single = stY
                    Dim lnCnt As Integer = 0

                    While curIdx < codes.Count AndAlso lnCnt < itemsPerPage
                        Dim ucd As String = codes(curIdx)
                        curIdx += 1
                        lnCnt += 1

                        If itemsPerPage = 4 Then
                            DrawUserItemMei4(g, ucd, stX, nowY)
                        ElseIf itemsPerPage = 2 Then
                            DrawUserItemMei2(g, ucd, stX, nowY)
                        Else
                            DrawUserItemMei1(g, ucd, stX, nowY)
                        End If
                    End While

                    e.HasMorePages = (curIdx < codes.Count)
                End Sub

            pd.Print()
        End Using
    End Sub

    Private Sub DrawUserCommonHeader(ByVal g As Graphics, ByVal rMpl As DataRow, ByVal stX As Single, ByRef nowY As Single, ByVal delMark As String)
        Dim nowX As Single = stX
        PrintStr(g, "コード", FnMn, 11, nowX, nowY, 20, 4, CsDef + CsDrawWidth3)
        nowX += 20
        PrintStr(g, NulCut(rMpl("コード")), FnMn, 11, nowX, nowY, 20, 4, CsDef)
        nowX += 20

        PrintStr(g, "Version", FnMn, 11, nowX, nowY, 15, 4, CsDef + CsDrawWidth3)
        nowX += 15
        PrintStr(g, NulCut(rMpl("分院Version")), FnMn, 11, nowX, nowY, 45, 4, CsDef)
        nowX += 45

        PrintStr(g, "印刷リスト追加日", FnMn, 11, nowX, nowY, 30, 4, CsDef + CsDrawWidth3)
        nowX += 30
        PrintStr(g, "", FnMn, 11, nowX, nowY, 20, 4, CsDef)

        nowX = stX
        nowY += 4

        PrintStr(g, "施術所名", FnMn, 11, nowX, nowY, 20, 8, CsDef + CsDrawWidth3)
        nowX += 20
        PrintStr(g, NulCut(rMpl("支部名")), FnMn, 16, nowX, nowY, 20, 8, CsStp)
        nowX += 20

        PrintStr(g, NulCut(rMpl("施術所ﾌﾘｶﾞﾅ")), FnMn, 11, nowX, nowY, 60, 3, CsStp)
        PrintStr(g, "", FnMn, 11, nowX, nowY, 60, 8, CsDef)
        nowY += 2
        PrintStr(g, delMark & NulCut(rMpl("施術所名")), FnMn, 16, nowX, nowY, 60, 6, CsStp)
        nowX += 60
        nowY -= 2

        PrintStr(g, NulCut(rMpl("フリガナ")), FnMn, 11, nowX, nowY, 50, 3, CsStp)
        nowY += 2
        PrintStr(g, NulCut(rMpl("柔整師名")), FnMn, 16, nowX, nowY, 50, 6, CsStp)
        nowX = stX
        nowY += 6

        PrintStr(g, "TEL", FnMn, 11, nowX, nowY, 20, 6, CsDef + CsDrawWidth3)
        nowX += 20
        PrintStr(g, NulCut(rMpl("電話番号")), FnMn, 16, nowX, nowY, 45, 6, CsDef)
        nowX += 45

        PrintStr(g, "自宅TEL", FnMn, 11, nowX, nowY, 15, 6, CsDef + CsDrawWidth3)
        nowX += 15
        PrintStr(g, NulCut(rMpl("自宅電話番号")), FnMn, 12, nowX, nowY, 30, 6, CsDef)
        nowX += 30

        PrintStr(g, "携帯", FnMn, 11, nowX, nowY, 10, 6, CsDef + CsDrawWidth3)
        nowX += 10
        PrintStr(g, NulCut(rMpl("携帯")), FnMn, 12, nowX, nowY, 30, 6, CsDef)
        nowX = stX
        nowY += 6

        PrintStr(g, "住所", FnMn, 11, nowX, nowY, 20, 6, CsDef + CsDrawWidth3)
        nowX += 20
        PrintStr(g, "〒" & Trim(NulCut(rMpl("〒"))), FnMn, 16, nowX, nowY, 20, 6, CsDef)
        nowX += 20
        PrintStr(g, Trim(NulCut(rMpl("住所1"))) & Trim(NulCut(rMpl("住所2"))), FnMn, 16, nowX, nowY, 110, 6, CsDef)
        nowY += 6

        PrintStr(g, "診療時間", FnMn, 11, stX, nowY, 20, 6, CsDef + CsDrawWidth3)
        PrintStr(g, NulCut(rMpl("診療時間")), FnMn, 16, stX + 20, nowY, 130, 6, CsDef)
        nowY += 6
    End Sub

    Private Sub DrawBikouBlock(ByVal g As Graphics, ByVal bikouText As String, ByVal stX As Single, ByRef nowY As Single)
        PrintStr(g, "備考", FnMn, 11, stX, nowY, 20, 13, CsDef + CsDrawWidth3)
        Dim nowX As Single = stX + 20
        PrintStr(g, "", FnMn, 11, nowX, nowY, 130, 13, CsDef)
        If Not String.IsNullOrWhiteSpace(bikouText) Then
            Dim lines() As String = bikouText.Split(New String() {ControlChars.CrLf, ControlChars.Lf}, StringSplitOptions.None)
            Dim ss As String = CnvHZ3(String.Join("　", lines))
            If ss.Length <= 150 Then
                ss = ss.PadRight(150, "　"c)
                For i As Integer = 0 To 2
                    PrintStr(g, Mid$(ss, i * 50 + 1, 50), FnMn, 14, nowX, nowY + i * 4, 130, 4, CsStp)
                Next
            Else
                ss = ss.PadRight(320, "　"c)
                For i As Integer = 0 To 3
                    PrintStr(g, Mid$(ss, i * 80 + 1, 80), FnMn, 14, nowX, nowY + i * 3, 130, 3, CsStp)
                Next
            End If
        End If
        nowY += 13
    End Sub

    Private Sub DrawMemoBlockLarge(ByVal g As Graphics, ByVal memoText As String, ByVal stX As Single, ByRef nowY As Single)
        PrintStr(g, "メモ", FnMn, 11, stX, nowY, 20, 40, CsDef + CsDrawWidth3)
        Dim nowX As Single = stX + 20
        PrintStr(g, "", FnMn, 11, nowX, nowY, 130, 40, CsDef)
        If Not String.IsNullOrWhiteSpace(memoText) Then
            Dim lines() As String = memoText.Split(New String() {ControlChars.CrLf, ControlChars.Lf}, StringSplitOptions.None)
            Dim ss As String = CnvHZ3(String.Join("　", lines))
            If ss.Length <= 300 Then
                ss = ss.PadRight(320, "　"c)
                For i As Integer = 0 To 7
                    PrintStr(g, Mid$(ss, i * 40 + 1, 40), FnMn, 14, nowX, nowY + i * 5, 130, 5, CsStp)
                Next
            ElseIf ss.Length <= 500 Then
                ss = ss.PadRight(500, "　"c)
                For i As Integer = 0 To 9
                    PrintStr(g, Mid$(ss, i * 50 + 1, 50), FnMn, 14, nowX, nowY + i * 4, 130, 4, CsStp)
                Next
            Else
                ss = ss.PadRight(1040, "　"c)
                For i As Integer = 0 To 12
                    PrintStr(g, Mid$(ss, i * 80 + 1, 80), FnMn, 14, nowX, nowY + i * 3, 130, 3, CsStp)
                Next
            End If
        End If
        nowY += 40
    End Sub

    Private Sub DrawKisyuBlock(ByVal g As Graphics, ByVal rMpl As DataRow, ByVal stX As Single, ByRef nowY As Single, ByVal drawSmallMap As Boolean)
        PrintStr(g, "使用機種", FnMn, 11, stX, nowY, 20, 30, CsDef + CsDrawWidth3)
        Dim nowX As Single = stX + 20
        PrintStr(g, "", FnMn, 11, nowX, nowY, 80, 30, CsDef + CsDrawWidth3)
        PrintStr(g, "", FnMn, 11, stX + 100, nowY, 50, 40, CsDef + CsDrawWidth3)

        PrintStr(g, "納品年月日", FnMn, 11, nowX, nowY, 20, 5, CsDef + CsDrawWidth3)
        PrintStr(g, NulCut(rMpl("納品年月日")), FnMn, 11, nowX + 20, nowY, 60, 5, CsDef)

        Dim kisyuRows As Tuple(Of String, String, String)() = {
            Tuple.Create("本　体　", NulCut(rMpl("本体機種名")), NulCut(rMpl("本体SN"))),
            Tuple.Create("画　面　", NulCut(rMpl("画面機種名")), NulCut(rMpl("画面SN"))),
            Tuple.Create("プリンタ", NulCut(rMpl("プリンター機種名")), NulCut(rMpl("プリンターSN"))),
            Tuple.Create("ＢＣＲ　", NulCut(rMpl("BCR機種名")), NulCut(rMpl("BCRSN"))),
            Tuple.Create("ＨＤＤ　", NulCut(rMpl("HDD機種名")), NulCut(rMpl("HDDSN")))
        }
        For idx As Integer = 0 To kisyuRows.Length - 1
            Dim rowY As Single = nowY + 5 * (idx + 1)
            PrintStr(g, kisyuRows(idx).Item1, FnMn, 11, nowX, rowY, 10, 5, CsDef + CsDrawWidth3)
            PrintStr(g, kisyuRows(idx).Item2, FnMn, 11, nowX + 10, rowY, 40, 5, CsDef)
            PrintStr(g, kisyuRows(idx).Item3, FnMn, 11, nowX + 50, rowY, 30, 5, CsDef)
        Next

        If drawSmallMap AndAlso OptionPrtMap Then
            DrawMapInBox(g, NulCut(rMpl("コード")), stX + 100.5F, nowY + 0.5F, 49.0F, 39.0F)
        End If
        nowY += 30
    End Sub

    Private Sub DrawKikaiSettiBlock(ByVal g As Graphics, ByVal rMpl As DataRow, ByVal stX As Single, ByRef nowY As Single)
        PrintStr(g, "機械設置", FnMn, 11, stX, nowY, 20, 10, CsDef + CsDrawWidth3)
        Dim nowX As Single = stX + 20
        Dim ss1 As String = ""
        Dim ss2 As String = ""
        If NulCutBool(rMpl("機械設置場所使用")) Then
            ss1 = NulCut(rMpl("機械設置場所〒")) & " " & NulCut(rMpl("機械設置場所住所1")) & " " & NulCut(rMpl("機械設置場所住所2")) & " " & NulCut(rMpl("機械設置場所電話番号"))
            ss2 = NulCut(rMpl("機械設置場所屋号")) & " " & NulCut(rMpl("機械設置場所名前"))
            Dim bikou As String = NulCut(rMpl("機械設置場所備考"))
            If bikou.Length > 10 Then
                ss2 &= " (" & bikou & "...)"
            ElseIf bikou.Length > 0 Then
                ss2 &= " (" & bikou & ")"
            End If
        End If
        PrintStr(g, ss1, FnMn, 16, nowX, nowY, 130, 5, CsDef)
        nowY += 5
        PrintStr(g, ss2, FnMn, 16, nowX, nowY, 130, 5, CsDef)
        nowY += 5
    End Sub

    ' 4件/ページ
    Private Sub DrawUserItemMei4(ByVal g As Graphics, ByVal ucd As String, ByVal stX As Single, ByRef nowY As Single)
        Dim dtMpl As DataTable = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(ucd), CnMplMdb)
        If dtMpl.Rows.Count = 0 Then Return
        Dim rMpl As DataRow = dtMpl.Rows(0)
        Dim delMark As String = If(NulCut(rMpl("削除")) = "2", "※", "")

        Dim dtMemo As DataTable = QueryDataTable("SELECT * FROM メモ WHERE UserCD = " & GetUcdSql(ucd), CnMntMdb)
        Dim memoText As String = If(dtMemo.Rows.Count > 0, NulCut(dtMemo.Rows(0)("Memo")), "")

        PrintStr(g, "", FnMn, 9, stX - 0.1F, nowY - 0.1F, 150.2F, 66.2F, CsDef + CsDrawWidth3)

        If OptionPrtMap Then
            DrawMapInBox(g, ucd, stX + 152.0F, nowY, 50.0F, 50.0F)
        End If

        DrawUserCommonHeader(g, rMpl, stX, nowY, delMark)
        DrawBikouBlock(g, NulCut(rMpl("備考")), stX, nowY)

        ' メモ欄 (高さ13mm)
        PrintStr(g, "メモ", FnMn, 11, stX, nowY, 20, 13, CsDef + CsDrawWidth3)
        Dim nowX As Single = stX + 20
        PrintStr(g, "", FnMn, 11, nowX, nowY, 130, 13, CsDef)
        PrintStr(g, "納品年月日 :" & NulCut(rMpl("納品年月日")), FnMn, 14, nowX, nowY, 130, 4, CsStp)
        If Not String.IsNullOrWhiteSpace(memoText) Then
            Dim s() As String = memoText.Split(New String() {ControlChars.CrLf, ControlChars.Lf}, StringSplitOptions.None)
            If s.Length = 1 Then
                PrintStr(g, CrLfTabCut(memoText), FnMn, 14, nowX, nowY + 4, 130, 4, CsStp)
            ElseIf s.Length = 2 Then
                PrintStr(g, s(0), FnMn, 14, nowX, nowY + 4, 130, 4, CsStp)
                PrintStr(g, s(1), FnMn, 14, nowX, nowY + 8, 130, 4, CsStp)
            Else
                Dim ss As String = String.Join(" ", s)
                If ss.Length <= 80 Then
                    PrintStr(g, ss, FnMn, 14, nowX, nowY + 8, 130, 4, CsStp)
                ElseIf ss.Length <= 120 Then
                    Dim half As Integer = (ss.Length + 1) \ 2
                    PrintStr(g, ss.Substring(0, half), FnMn, 14, nowX, nowY + 4, 130, 4, CsStp)
                    PrintStr(g, ss.Substring(half), FnMn, 14, nowX, nowY + 8, 130, 4, CsStp)
                Else
                    Dim third As Integer = (ss.Length + 1) \ 3
                    PrintStr(g, ss.Substring(0, third), FnMn, 14, nowX, nowY + 3, 130, 4, CsStp)
                    PrintStr(g, ss.Substring(third, third), FnMn, 14, nowX, nowY + 6, 130, 4, CsStp)
                    PrintStr(g, ss.Substring(third * 2), FnMn, 14, nowX, nowY + 9, 130, 4, CsStp)
                End If
            End If
        End If
        nowY += 13

        DrawKikaiSettiBlock(g, rMpl, stX, nowY)
        nowY += 5
    End Sub

    ' 2件/ページ
    Private Sub DrawUserItemMei2(ByVal g As Graphics, ByVal ucd As String, ByVal stX As Single, ByRef nowY As Single)
        Dim dtMpl As DataTable = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(ucd), CnMplMdb)
        If dtMpl.Rows.Count = 0 Then Return
        Dim rMpl As DataRow = dtMpl.Rows(0)
        Dim delMark As String = If(NulCut(rMpl("削除")) = "2", "※", "")

        Dim dtMemo As DataTable = QueryDataTable("SELECT * FROM メモ WHERE UserCD = " & GetUcdSql(ucd), CnMntMdb)
        Dim memoText As String = If(dtMemo.Rows.Count > 0, NulCut(dtMemo.Rows(0)("Memo")), "")

        PrintStr(g, "", FnMn, 9, stX - 0.1F, nowY - 0.1F, 150.2F, 123.2F, CsDef + CsDrawWidth3)
        PrintStr(g, "", FnMn, 9, stX - 0.1F, nowY - 0.1F, 150.2F, 133.2F, CsDef + CsDrawWidth3)

        DrawUserCommonHeader(g, rMpl, stX, nowY, delMark)
        DrawBikouBlock(g, NulCut(rMpl("備考")), stX, nowY)
        DrawMemoBlockLarge(g, memoText, stX, nowY)
        DrawKisyuBlock(g, rMpl, stX, nowY, True)

        ' その他欄 (10mm)
        PrintStr(g, "その他", FnMn, 11, stX, nowY, 20, 10, CsDef + CsDrawWidth3)
        PrintStr(g, " ", FnMn, 16, stX + 20, nowY, 80, 10, CsDef)
        nowY += 10

        DrawKikaiSettiBlock(g, rMpl, stX, nowY)
        nowY += 5
    End Sub

    ' 1件/ページ (地図 大)
    Private Sub DrawUserItemMei1(ByVal g As Graphics, ByVal ucd As String, ByVal stX As Single, ByRef nowY As Single)
        Dim dtMpl As DataTable = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(ucd), CnMplMdb)
        If dtMpl.Rows.Count = 0 Then Return
        Dim rMpl As DataRow = dtMpl.Rows(0)
        Dim delMark As String = If(NulCut(rMpl("削除")) = "2", "※", "")

        Dim dtMemo As DataTable = QueryDataTable("SELECT * FROM メモ WHERE UserCD = " & GetUcdSql(ucd), CnMntMdb)
        Dim memoText As String = If(dtMemo.Rows.Count > 0, NulCut(dtMemo.Rows(0)("Memo")), "")

        PrintStr(g, "", FnMn, 9, stX - 0.1F, nowY - 0.1F, 150.2F, 123.2F, CsDef + CsDrawWidth3)
        PrintStr(g, "", FnMn, 9, stX - 0.1F, nowY - 0.1F, 150.2F, 133.2F, CsDef + CsDrawWidth3)

        DrawUserCommonHeader(g, rMpl, stX, nowY, delMark)
        DrawBikouBlock(g, NulCut(rMpl("備考")), stX, nowY)
        DrawMemoBlockLarge(g, memoText, stX, nowY)
        DrawKisyuBlock(g, rMpl, stX, nowY, False)

        PrintStr(g, "その他", FnMn, 11, stX, nowY, 20, 10, CsDef + CsDrawWidth3)
        PrintStr(g, " ", FnMn, 16, stX + 20, nowY, 80, 10, CsDef)
        nowY += 10

        DrawKikaiSettiBlock(g, rMpl, stX, nowY)

        ' 地図 大 (100mm高)
        PrintStr(g, "地図", FnMn, 11, stX, nowY, 20, 100, CsDef + CsDrawWidth3)
        PrintStr(g, " ", FnMn, 11, stX + 20, nowY, 130, 100, CsDef + CsDrawWidth3)
        If OptionPrtMap Then
            DrawMapInBox(g, ucd, stX + 20.5F, nowY + 0.5F, 128.0F, 98.0F)
        End If
        nowY += 105
    End Sub

    ' =========================================================================
    ' 2. 封筒宛名印刷 (1F = 横向き / 2F = 縦向き)
    ' =========================================================================
    Public Sub PrintEnvelope(ByVal mode As Integer, Optional ByVal owner As IWin32Window = Nothing)
        Dim dtPrt As DataTable = QueryDataTable("SELECT * FROM 印刷リスト", CnPrtMdb)
        If dtPrt.Rows.Count = 0 Then
            MessageBox.Show("印刷リストにユーザーが登録されていません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim codes As New List(Of String)()
        For Each r As DataRow In dtPrt.Rows
            Dim cd As String = TrimX(NulCut(r("ユーザーコード")))
            If cd <> "" Then codes.Add(cd)
        Next
        If codes.Count = 0 Then Return

        Using pd As New PrintDocument()
            pd.DocumentName = If(mode = 1, "封筒印刷(1F)", "封筒印刷(2F)")
            pd.DefaultPageSettings.Landscape = (mode = 1)

            Using dlg As New PrintDialog()
                dlg.Document = pd
                dlg.UseEXDialog = True
                If dlg.ShowDialog(owner) <> DialogResult.OK Then Return
            End Using

            Dim curIdx As Integer = 0
            AddHandler pd.PrintPage,
                Sub(sender As Object, e As PrintPageEventArgs)
                    Dim g As Graphics = e.Graphics
                    g.PageUnit = GraphicsUnit.Millimeter

                    Dim ucd As String = codes(curIdx)
                    curIdx += 1

                    Dim dtMpl As DataTable = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(ucd), CnMplMdb)
                    If dtMpl.Rows.Count > 0 Then
                        Dim rMpl As DataRow = dtMpl.Rows(0)
                        Dim baseOffsetY As Single = If(mode = 1, 100.0F, 50.0F)

                        PrintStr(g, "〒" & NulCut(rMpl("〒")), FnMn, 14, 20, baseOffsetY, 30, 7, CsStp)
                        PrintStr(g, Trim(NulCut(rMpl("住所1"))) & Trim(NulCut(rMpl("住所2"))), FnMn, 16, 20, baseOffsetY + 5, 110, 8, CsStp)
                        PrintStr(g, NulCut(rMpl("施術所名")), FnMn, 16, 25, baseOffsetY + 13, 60, 6, CsStp)

                        Dim jsName As String = Trim(NulCut(rMpl("柔整師名")))
                        If jsName = "" Then
                            PrintStr(g, "    御担当者 様", FnMn, 16, 35, baseOffsetY + 19, 70, 8, CsStp)
                        Else
                            PrintStr(g, jsName & " 様", FnMn, 22, 35, baseOffsetY + 19, 70, 8, CsStp)
                        End If

                        PrintStr(g, "[" & Trim(NulCut(rMpl("コード"))) & " " & NulCut(rMpl("分院Version")) & "]", FnMn, 12, 80, baseOffsetY + 40, 50, 5, CsStp)
                    End If

                    e.HasMorePages = (curIdx < codes.Count)
                End Sub

            pd.Print()
        End Using
    End Sub

    ' =========================================================================
    ' 3. 個別ユーザーのカルテ＋メンテナンス記録印刷 (PrintMntUsr)
    ' =========================================================================
    Public Sub PrintMntUsr(ByVal ucd As String, Optional ByVal owner As IWin32Window = Nothing)
        If String.IsNullOrWhiteSpace(ucd) Then Return

        Dim dtMpl As DataTable = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(ucd), CnMplMdb)
        If dtMpl.Rows.Count = 0 Then Return
        Dim rMpl As DataRow = dtMpl.Rows(0)
        Dim delMark As String = If(NulCut(rMpl("削除")) = "2", "※", "")

        Dim dtMemo As DataTable = QueryDataTable("SELECT * FROM メモ WHERE UserCD = " & GetUcdSql(ucd), CnMntMdb)
        Dim memoText As String = If(dtMemo.Rows.Count > 0, NulCut(dtMemo.Rows(0)("Memo")), "")

        Dim dtExtra As DataTable = QueryDataTable("SELECT * FROM 拡張データ WHERE コード = " & GetUcdSql(ucd), CnMplMdb)

        ' 対象メンテナンス記録を取得
        Dim stDate As DateTime = DateTime.Now.AddYears(-Math.Max(1, OptionMntUsrPrtRangeN))
        Dim sqlMnt As String =
            "SELECT メンテナンス記録.*, 社員マスター.社員名 " &
            "FROM メンテナンス記録 LEFT JOIN 社員マスター ON メンテナンス記録.社員コード = 社員マスター.社員コード " &
            "WHERE メンテナンス記録.コード = " & GetUcdSql(ucd) &
            " AND メンテナンス記録.削除 = False " &
            " AND メンテナンス記録.作業日 >= #" & stDate.ToString("yyyy/MM/dd") & "# " &
            "ORDER BY メンテナンス記録.作業日, メンテナンス記録.ID"
        Dim dtMnt As DataTable = QueryDataTable(sqlMnt, CnMntMdb)

        Using pd As New PrintDocument()
            pd.DocumentName = "ユーザーカルテ・メンテナンス記録 (" & ucd & ")"
            pd.DefaultPageSettings.Landscape = False

            Using dlg As New PrintDialog()
                dlg.Document = pd
                dlg.UseEXDialog = True
                If dlg.ShowDialog(owner) <> DialogResult.OK Then Return
            End Using

            Dim pg As Integer = 1
            Dim mntIdx As Integer = 0

            AddHandler pd.PrintPage,
                Sub(sender As Object, e As PrintPageEventArgs)
                    Dim g As Graphics = e.Graphics
                    g.PageUnit = GraphicsUnit.Millimeter

                    Dim stX As Single = 5.0F
                    Dim stY As Single = 5.0F
                    Dim nowX As Single = stX
                    Dim nowY As Single = stY

                    If pg = 1 Then
                        ' 1ページ目上部: ユーザーカルテ枠
                        PrintStr(g, "", FnMn, 9, stX - 0.1F, nowY - 0.1F, 150.2F, 123.2F, CsDef + CsDrawWidth3)
                        PrintStr(g, "", FnMn, 9, stX - 0.1F, nowY - 0.1F, 150.2F, 133.2F, CsDef + CsDrawWidth3)

                        DrawUserCommonHeader(g, rMpl, stX, nowY, delMark)
                        DrawBikouBlock(g, NulCut(rMpl("備考")), stX, nowY)
                        DrawMemoBlockLarge(g, memoText, stX, nowY)
                        DrawKisyuBlock(g, rMpl, stX, nowY, False)

                        ' その他 (拡張データ)
                        PrintStr(g, "その他", FnMn, 11, stX, nowY, 20, 10, CsDef + CsDrawWidth3)
                        Dim etcS As String = " "
                        Dim telEx1 As String = ""
                        Dim telEx2 As String = ""
                        If dtExtra.Rows.Count > 0 Then
                            Dim rx As DataRow = dtExtra.Rows(0)
                            Select Case NulCutN(rx("ネット接続"))
                                Case 1 : etcS &= "ネット:BB、"
                                Case 2 : etcS &= "ネット:電話回線、"
                                Case 3 : etcS &= "ネット:無し、"
                            End Select
                            Select Case NulCutN(rx("IME"))
                                Case 1 : etcS &= "MS-IME、"
                                Case 2 : etcS &= "ATOK、"
                            End Select
                            Select Case NulCutN(rx("入力方式"))
                                Case 1 : etcS &= "ローマ字入力、"
                                Case 2 : etcS &= "かな入力、"
                                Case 3 : etcS &= "Ｒ－かな 切替、"
                            End Select
                            Select Case NulCutN(rx("クリックモード"))
                                Case 1 : etcS &= "シングルクリック"
                                Case 2 : etcS &= "ダブルクリック"
                            End Select
                            telEx1 = " " & NulCut(rx("電話番号追加分1")) & "  " & NulCut(rx("電話番号追加分2")) & "  " & NulCut(rx("電話番号追加分3"))
                            telEx2 = " " & NulCut(rx("電話番号追加分4")) & "  " & NulCut(rx("電話番号追加分5"))
                        End If
                        PrintStr(g, etcS, FnMn, 11, stX + 20, nowY, 80, 3.4F, CsDef)
                        PrintStr(g, telEx1, FnMn, 11, stX + 20, nowY + 3.4F, 80, 3.3F, CsDef)
                        PrintStr(g, telEx2, FnMn, 11, stX + 20, nowY + 6.7F, 80, 3.3F, CsDef)
                        nowY += 10

                        DrawKikaiSettiBlock(g, rMpl, stX, nowY)
                        nowY += 5
                    End If

                    ' メンテナンス記録ヘッダー
                    PrintStr(g, " メンテナンス記録 ", FnMn, 16, stX, nowY, 170, 8, CsDef)
                    PrintStr(g, Trim(NulCut(rMpl("コード"))) & " : " & NulCut(rMpl("支部名")) & " : " & NulCut(rMpl("施術所名")) & " : " & pg.ToString() & "Page", FnMn, 16, stX + 70, nowY, 95, 5, CsStp)
                    nowY += 8

                    PrintStr(g, "日付", FnMn, 16, stX, nowY, 20, 4, CsDef)
                    PrintStr(g, "作業内容", FnMn, 16, stX + 20, nowY, 120, 4, CsDef)
                    PrintStr(g, "担当", FnMn, 16, stX + 140, nowY, 20, 4, CsDef)
                    PrintStr(g, "完了", FnMn, 16, stX + 160, nowY, 10, 4, CsDef)
                    nowY += 4

                    While mntIdx < dtMnt.Rows.Count
                        Dim rm As DataRow = dtMnt.Rows(mntIdx)
                        Dim rawLines() As String = TrimX(NulCut(rm("内容"))).Split(New String() {ControlChars.CrLf, ControlChars.Lf}, StringSplitOptions.None)
                        Dim sList As New List(Of String)(rawLines)

                        If sList.Count > OptionMntUsrPrtMaxLine Then
                            Dim omitted As Integer = sList.Count - OptionMntUsrPrtMaxLine
                            sList.RemoveRange(OptionMntUsrPrtMaxLine, omitted)
                            sList.Add("")
                            sList.Add("＜ － ※ ※ ※ ※ ※ 以下、" & omitted.ToString() & "行 省略 ※ ※ ※ ※ ※ － ＞")
                        End If

                        Dim wrappedLines As New List(Of String)()
                        For Each ln In sList
                            Dim wrapped As String = FmtLenB(ln, 64)
                            wrappedLines.AddRange(wrapped.Split(New String() {ControlChars.CrLf, ControlChars.Lf}, StringSplitOptions.None))
                        Next
                        If wrappedLines.Count = 0 Then wrappedLines.Add("")

                        Dim blockH As Single = wrappedLines.Count * 4.0F
                        If nowY + blockH > 265.0F AndAlso nowY > stY + 20.0F Then
                            pg += 1
                            e.HasMorePages = True
                            Return
                        End If

                        Dim rowStartY As Single = nowY
                        PrintStr(g, MakeDateString(rm("作業日"), StlYMD), FnMn, 11, stX, rowStartY, 20, 4, CsStp)
                        PrintStr(g, NulCut(rm("分類")), FnMn, 11, stX + 20, rowStartY, 20, 4, CsStp)

                        For i As Integer = 0 To wrappedLines.Count - 1
                            PrintStr(g, wrappedLines(i), FnMn, 11, stX + 40, nowY, 100, 4, CsStp)
                            nowY += 4.0F
                        Next

                        PrintStr(g, NulCut(rm("社員名")), FnMn, 11, stX + 140, rowStartY, 20, 4, CsStp)
                        PrintStr(g, If(NulCutBool(rm("完了")), "済み", "  "), FnMn, 11, stX + 160, rowStartY, 10, 4, CsStp)

                        PrintStr(g, "", FnMn, 11, stX, rowStartY, 20, blockH, CsDef)
                        PrintStr(g, "", FnMn, 11, stX + 20, rowStartY, 20, blockH, CsDef)
                        PrintStr(g, "", FnMn, 11, stX + 40, rowStartY, 100, blockH, CsDef)
                        PrintStr(g, "", FnMn, 11, stX + 140, rowStartY, 20, blockH, CsDef)
                        PrintStr(g, "", FnMn, 11, stX + 160, rowStartY, 10, blockH, CsDef)

                        mntIdx += 1
                        If nowY > 265.0F AndAlso mntIdx < dtMnt.Rows.Count Then
                            pg += 1
                            e.HasMorePages = True
                            Return
                        End If
                    End While

                    e.HasMorePages = False
                End Sub

            pd.Print()
        End Using
    End Sub

    ' =========================================================================
    ' 4. 全メンテナンス記録一覧の印刷 (Mnt.frm -> mntPrint)
    ' =========================================================================
    Public Sub PrintMntList(ByVal dgv As DataGridView, ByVal sortText As String, ByVal kanryouText As String, ByVal kijitsuText As String, Optional ByVal owner As IWin32Window = Nothing)
        If dgv Is Nothing OrElse dgv.Rows.Count = 0 Then
            MessageBox.Show("印刷するメンテナンス記録がありません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Const lnMax As Integer = 13
        Const intvl As Single = 20.0F
        Dim meiCnt As Integer = dgv.Rows.Count
        Dim pgMax As Integer = ((meiCnt - 1) \ lnMax) + 1
        Dim prtDateTime As DateTime = DateTime.Now

        Using pd As New PrintDocument()
            pd.DocumentName = "全メンテナンス記録一覧"
            pd.DefaultPageSettings.Landscape = False

            Using dlg As New PrintDialog()
                dlg.Document = pd
                dlg.UseEXDialog = True
                If dlg.ShowDialog(owner) <> DialogResult.OK Then Return
            End Using

            Dim curPage As Integer = 1
            AddHandler pd.PrintPage,
                Sub(sender As Object, e As PrintPageEventArgs)
                    Dim g As Graphics = e.Graphics
                    g.PageUnit = GraphicsUnit.Millimeter

                    Dim offsetX As Single = 5.0F
                    Using fHeader As New Font(FnGt, 9.0F, FontStyle.Regular, GraphicsUnit.Point)
                        g.DrawString($"* * メンテナンス記録 * *  ( 並替:{sortText} / 完了分:{kanryouText} / 期日表示期間:{kijitsuText} )  Page {curPage}/{pgMax}",
                                     fHeader, Brushes.Black, offsetX + 10.0F, 7.0F)
                    End Using

                    For j As Integer = 1 To lnMax
                        Dim rowIdx As Integer = (curPage - 1) * lnMax + (j - 1)
                        If rowIdx >= meiCnt Then Exit For

                        Dim row As DataGridViewRow = dgv.Rows(rowIdx)
                        Dim topY As Single = j * intvl - 7.0F

                        Using pOuter As New Pen(Color.Black, 0.45F)
                            g.DrawRectangle(pOuter, offsetX + 10.0F, topY, 185.0F, 18.0F)
                        End Using
                        Using pInner As New Pen(Color.Black, 0.25F)
                            g.DrawRectangle(pInner, offsetX + 10.0F, topY, 21.0F, 6.0F)
                            g.DrawRectangle(pInner, offsetX + 31.0F, topY, 35.0F, 6.0F)
                            g.DrawRectangle(pInner, offsetX + 66.0F, topY, 20.0F, 6.0F)
                            g.DrawRectangle(pInner, offsetX + 86.0F, topY, 45.0F, 6.0F)
                            g.DrawRectangle(pInner, offsetX + 131.0F, topY, 31.0F, 6.0F)
                            g.DrawRectangle(pInner, offsetX + 162.0F, topY, 15.0F, 6.0F)
                            g.DrawRectangle(pInner, offsetX + 177.0F, topY, 18.0F, 6.0F)
                        End Using

                        Dim txtId As String = TrimX(NulCut(row.Cells("ID").Value))
                        Dim txtWkDate As String = TrimX(NulCut(row.Cells("作業日").Value))
                        Dim txtSibu As String = TrimX(NulCut(row.Cells("支部").Value))
                        Dim txtJYago As String = TrimX(NulCut(row.Cells("施術所名").Value))
                        Dim sContent As String = (CmpSpc(CutCR(NulCut(row.Cells("内容").Value))) & New String(" "c, 200))
                        Dim txtNaiyo1 As String = Mid$(sContent, 1, 55)
                        Dim txtNaiyo2 As String = Mid$(sContent, 56, 55)
                        Dim txtNaiyo3 As String = Mid$(sContent, 111, 55)
                        Dim txtLmtDate As String = TrimX(NulCut(row.Cells("期日").Value))
                        Dim txtTanto As String = TrimX(NulCut(row.Cells("社員").Value))
                        Dim txtComp As String = TrimX(NulCut(row.Cells("完了").Value))

                        Dim dtLmt As DateTime
                        Dim isOverdue As Boolean = (DateTime.TryParse(txtLmtDate, dtLmt) AndAlso dtLmt.Date < DateTime.Now.Date AndAlso txtComp <> "済")
                        Dim isDeletedUser As Boolean = txtJYago.StartsWith("※")

                        Dim markStr As String = "　"
                        Dim hdrFontName As String = FnMn
                        Dim hdrBrush As Brush = Brushes.Black

                        If isOverdue Then
                            markStr = "■"
                            hdrFontName = FnGt
                            hdrBrush = Brushes.Red
                        End If
                        If isDeletedUser Then
                            markStr = "×"
                            hdrFontName = FnGt
                            hdrBrush = Brushes.MediumBlue
                        End If

                        Using fRowHdr As New Font(hdrFontName, 10.5F, FontStyle.Regular, GraphicsUnit.Point)
                            Dim yHdr As Single = topY + 0.8F
                            g.DrawString(markStr & "ID:" & txtId, fRowHdr, hdrBrush, offsetX + 10.8F, yHdr)
                            g.DrawString("作業日:" & txtWkDate, fRowHdr, hdrBrush, offsetX + 31.8F, yHdr)
                            g.DrawString(Microsoft.VisualBasic.Strings.Left(txtSibu & "　　　　", 4), fRowHdr, hdrBrush, offsetX + 66.8F, yHdr)
                            g.DrawString(Microsoft.VisualBasic.Strings.Left(txtJYago & "　　　　　　　　　　", 10), fRowHdr, hdrBrush, offsetX + 86.8F, yHdr)
                            g.DrawString("期日:" & txtLmtDate, fRowHdr, hdrBrush, offsetX + 131.8F, yHdr)
                            g.DrawString(Microsoft.VisualBasic.Strings.Left(txtTanto & "   ", 3), fRowHdr, hdrBrush, offsetX + 163.0F, yHdr)
                            g.DrawString("完了:" & txtComp, fRowHdr, hdrBrush, offsetX + 178.0F, yHdr)
                        End Using

                        Using fBody As New Font(FnMn, 9.0F, FontStyle.Regular, GraphicsUnit.Point)
                            g.DrawString(txtNaiyo1, fBody, Brushes.Black, offsetX + 12.0F, topY + 6.3F)
                            g.DrawString(txtNaiyo2, fBody, Brushes.Black, offsetX + 12.0F, topY + 10.1F)
                            g.DrawString(txtNaiyo3, fBody, Brushes.Black, offsetX + 12.0F, topY + 13.9F)
                        End Using
                    Next

                    Using fFooter As New Font(FnGt, 9.5F, FontStyle.Regular, GraphicsUnit.Point)
                        g.DrawString("印刷日時:" & prtDateTime.ToString("yyyy年MM月dd日 HH時mm分ss秒"), fFooter, Brushes.Black, offsetX + 125.0F, 273.0F)
                        g.DrawString("期日を過ぎているデータは ■マーク", fFooter, Brushes.Red, offsetX + 125.0F, 279.0F)
                    End Using

                    If curPage < pgMax Then
                        curPage += 1
                        e.HasMorePages = True
                    Else
                        e.HasMorePages = False
                    End If
                End Sub

            pd.Print()
        End Using
    End Sub
End Module
