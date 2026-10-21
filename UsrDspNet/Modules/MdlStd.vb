Imports System.Text
Imports System.Drawing

Public Module MdlStd
    Public Const StlYMD As Integer = 0
    Public Const StlYMDHMS As Integer = 1
    Public Const StlHM As Integer = 2
    Public Const StlSYMD As Integer = 3

    Private Const Zstr As String = "　０１２３４５６７８９ａｂｃｄｅｆｇｈｉｊｋｌｍｎｏｐｑｒｓｔｕｖｗｘｙｚＡＢＣＤＥＦＧＨＩＪＫＬＭＮＯＰＱＲＳＴＵＶＷＸＹＺ（）／－アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲンァィゥェォャュョッー，．゛゜＜＞。＠！「」＃＄、％・＆’＊：＋；［｛￥｜＝］｝？＾＿"
    Private Const Hstr As String = " 0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ()/-ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜｦﾝｧｨｩｪｫｬｭｮｯｰ,.ﾞﾟ<>｡@!｢｣#$､%･&'*:+;[{\|=]}?^_"

    Public Function NulCut(ByVal S As Object) As String
        If S Is Nothing OrElse IsDBNull(S) Then
            Return ""
        End If
        Return S.ToString()
    End Function

    Public Function NulCutN(ByVal S As Object) As Long
        If S Is Nothing OrElse IsDBNull(S) Then
            Return 0
        End If
        Return CLng(Val(S.ToString()))
    End Function

    Public Function NulCutBool(ByVal S As Object) As Boolean
        If S Is Nothing OrElse IsDBNull(S) Then
            Return False
        End If
        If TypeOf S Is Boolean Then Return CBool(S)
        Dim str As String = S.ToString().Trim().ToLowerInvariant()
        Return (str = "true" OrElse str = "-1" OrElse str = "1")
    End Function

    Public Function TrimX(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Return S.Trim(" "c, "　"c, ControlChars.Tab, ControlChars.NullChar, ControlChars.Cr, ControlChars.Lf)
    End Function

    Public Function TabCut(ByVal Str As String) As String
        If String.IsNullOrEmpty(Str) Then Return ""
        Return Str.Replace(ControlChars.Tab, " "c)
    End Function

    Public Function CutHf(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Dim sb As New StringBuilder(S.Length)
        For Each ch As Char In S
            If ch <> "-"c AndAlso ch <> "ｰ"c AndAlso ch <> "－"c AndAlso ch <> "ー"c Then
                sb.Append(ch)
            End If
        Next
        Return sb.ToString()
    End Function

    Public Function CutCR(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Return S.Replace(ControlChars.CrLf, " ").Replace(ControlChars.Cr, " ").Replace(ControlChars.Lf, " ")
    End Function

    Public Function CrLfTabCut(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Dim sb As New StringBuilder(S.Length)
        For Each ch As Char In S
            If ch <> ControlChars.Cr AndAlso ch <> ControlChars.Lf AndAlso ch <> ControlChars.Tab Then
                sb.Append(ch)
            End If
        Next
        Return sb.ToString()
    End Function

    Public Function CutSp(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Return S.Replace(" ", "").Replace("　", "")
    End Function

    Public Function TelEdit(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        If Len(Trim(S)) > 15 Then
            Return CutHf(S)
        Else
            Return S
        End If
    End Function

    Public Function CmpSpc(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Dim ss As String = S.Replace("　", " ")
        While ss.Contains("  ")
            ss = ss.Replace("  ", " ")
        End While
        Return ss
    End Function

    Public Function CnvHC2LC(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Return S.Replace(","c, "，"c)
    End Function

    Public Function AddWc(ByVal S As String) As String
        Return """" & S & """"
    End Function

    Public Function FmtLenB(ByVal S As String, Optional ByVal maxBytes As Integer = 64) As String
        If String.IsNullOrWhiteSpace(S) Then Return S
        Dim sjis As Encoding = Encoding.GetEncoding(932)
        Dim lines As New List(Of String)()
        Dim currentSb As New StringBuilder()
        Dim currentBytes As Integer = 0

        For Each ch As Char In S
            Dim charBytes As Integer = sjis.GetByteCount(New Char() {ch})
            If currentBytes + charBytes > maxBytes AndAlso currentSb.Length > 0 Then
                lines.Add(currentSb.ToString().Trim())
                currentSb.Clear()
                currentBytes = 0
            End If
            currentSb.Append(ch)
            currentBytes += charBytes
        Next
        If currentSb.Length > 0 Then
            lines.Add(currentSb.ToString().Trim())
        End If

        Dim nonEmpty As New List(Of String)()
        For i As Integer = 0 To lines.Count - 1
            If i = 0 OrElse lines(i) <> "" Then
                nonEmpty.Add(lines(i))
            End If
        Next
        Return String.Join(ControlChars.CrLf, nonEmpty)
    End Function

    Public Function GetNumS(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Const ChkStr As String = "0123456789０１２３４５６７８９"
        Const CnvStr As String = "01234567890123456789"
        Dim sb As New StringBuilder()
        For i As Integer = 1 To Len(S)
            Dim fs As String = Mid$(S, i, 1)
            Dim pnt As Integer = InStr(ChkStr, fs)
            If pnt > 0 Then
                sb.Append(Mid$(CnvStr, pnt, 1))
            End If
        Next
        Return sb.ToString()
    End Function

    Public Function GetNumN(ByVal S As String) As Long
        Return CLng(Val(GetNumS(S)))
    End Function

    ''' <summary>
    ''' ひらがな・全角カタカナを半角カタカナ（DB検索用）へ変換
    ''' </summary>
    Public Function cnvHg2Kk(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Dim HgStr(4) As String
        Dim KkStr(4) As String

        HgStr(0) = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをんぁぃぅぇぉゃゅょっ"
        KkStr(0) = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜｦﾝｧｨｩｪｫｬｭｮｯ"
        HgStr(1) = "アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲンァィゥェォャュョッ"
        KkStr(1) = "ｱｲｳｴｵｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾅﾆﾇﾈﾉﾊﾋﾌﾍﾎﾏﾐﾑﾒﾓﾔﾕﾖﾗﾘﾙﾚﾛﾜｦﾝｧｨｩｪｫｬｭｮｯ"
        HgStr(2) = "ヴがぎぐげござじずぜぞだぢづでどばびぶべぼ"
        KkStr(2) = "ｳｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾊﾋﾌﾍﾎ"
        HgStr(3) = "ガギグゲゴザジズゼゾダヂヅデドバビブベボ"
        KkStr(3) = "ｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾊﾋﾌﾍﾎ"
        HgStr(4) = "ぱぴぷぺぽパピプペポ"
        KkStr(4) = "ﾊﾋﾌﾍﾎﾊﾋﾌﾍﾎ"

        For J As Integer = 0 To 1
            Dim sb As New StringBuilder(S.Length)
            For i As Integer = 1 To Len(S)
                Dim ch As String = Mid$(S, i, 1)
                Dim idx As Integer = InStr(HgStr(J), ch)
                If idx > 0 Then
                    sb.Append(Mid$(KkStr(J), idx, 1))
                Else
                    sb.Append(ch)
                End If
            Next
            S = sb.ToString()
        Next

        For J As Integer = 2 To 3
            Dim sb As New StringBuilder()
            For i As Integer = 1 To Len(S)
                Dim ch As String = Mid$(S, i, 1)
                Dim idx As Integer = InStr(HgStr(J), ch)
                If idx > 0 Then
                    sb.Append(Mid$(KkStr(J), idx, 1)).Append("ﾞ")
                Else
                    sb.Append(ch)
                End If
            Next
            S = sb.ToString()
        Next

        If True Then
            Dim sb As New StringBuilder()
            For i As Integer = 1 To Len(S)
                Dim ch As String = Mid$(S, i, 1)
                Dim idx As Integer = InStr(HgStr(4), ch)
                If idx > 0 Then
                    sb.Append(Mid$(KkStr(4), idx, 1)).Append("ﾟ")
                Else
                    sb.Append(ch)
                End If
            Next
            S = sb.ToString()
        End If

        Return S
    End Function

    Public Function CnvHZ2(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Dim sb As New StringBuilder(S.Length)
        For i As Integer = 1 To Len(S)
            Dim c As String = Mid$(S, i, 1)
            Dim p As Integer = InStr(Hstr, c)
            If p > 0 Then
                sb.Append(Mid$(Zstr, p, 1))
            Else
                sb.Append(c)
            End If
        Next
        Return sb.ToString()
    End Function

    Public Function CnvZH2(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Dim sb As New StringBuilder(S.Length)
        For i As Integer = 1 To Len(S)
            Dim c As String = Mid$(S, i, 1)
            Dim p As Integer = InStr(Zstr, c)
            If p > 0 Then
                sb.Append(Mid$(Hstr, p, 1))
            Else
                sb.Append(c)
            End If
        Next
        Return sb.ToString()
    End Function

    Public Function CnvZH3(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Const ZDak As String = "ガギグゲゴザジズゼゾダヂヅデドバビブベボパピプペポヴ"
        Const HDak As String = "ｶﾞｷﾞｸﾞｹﾞｺﾞｻﾞｼﾞｽﾞｾﾞｿﾞﾀﾞﾁﾞﾂﾞﾃﾞﾄﾞﾊﾞﾋﾞﾌﾞﾍﾞﾎﾞﾊﾟﾋﾟﾌﾟﾍﾟﾎﾟｳﾞ"
        S = CnvZH2(S)
        Dim sb As New StringBuilder()
        For i As Integer = 1 To Len(S)
            Dim c As String = Mid$(S, i, 1)
            Dim n As Integer = InStr(ZDak, c)
            If n > 0 Then
                sb.Append(Mid$(HDak, n * 2 - 1, 2))
            Else
                sb.Append(c)
            End If
        Next
        Return sb.ToString()
    End Function

    Public Function CnvHZ3(ByVal S As String) As String
        If String.IsNullOrEmpty(S) Then Return ""
        Const ZDak As String = "ガギグゲゴザジズゼゾダヂヅデドバビブベボパピプペポヴ"
        Const HDak As String = "ｶﾞｷﾞｸﾞｹﾞｺﾞｻﾞｼﾞｽﾞｾﾞｿﾞﾀﾞﾁﾞﾂﾞﾃﾞﾄﾞﾊﾞﾋﾞﾌﾞﾍﾞﾎﾞﾊﾟﾋﾟﾌﾟﾍﾟﾎﾟｳﾞ"
        Dim sb As New StringBuilder()
        Dim i As Integer = 1
        While i <= Len(S)
            If i < Len(S) Then
                Dim twoChars As String = Mid$(S, i, 2)
                Dim n As Integer = InStr(HDak, twoChars)
                If n > 0 AndAlso (n Mod 2 = 1) Then
                    sb.Append(Mid$(ZDak, (n + 1) \ 2, 1))
                    i += 2
                    Continue While
                End If
            End If
            sb.Append(Mid$(S, i, 1))
            i += 1
        End While
        Return CnvHZ2(sb.ToString())
    End Function

    Public Function GetEndDay(ByVal ym As String) As String
        Try
            Dim dt As DateTime
            If DateTime.TryParse(ym & "/01", dt) Then
                Dim lastDay As Integer = DateTime.DaysInMonth(dt.Year, dt.Month)
                Return New DateTime(dt.Year, dt.Month, lastDay).ToString("yyyy/MM/dd")
            End If
        Catch
        End Try
        Dim nowDt As DateTime = DateTime.Now
        Return New DateTime(nowDt.Year, nowDt.Month, DateTime.DaysInMonth(nowDt.Year, nowDt.Month)).ToString("yyyy/MM/dd")
    End Function

    Public Function MakeDateString(ByVal DtObj As Object, Optional ByVal Styl As Integer = StlYMD) As String
        If DtObj Is Nothing OrElse IsDBNull(DtObj) Then Return ""
        Dim dt As DateTime
        If TypeOf DtObj Is DateTime Then
            dt = CDate(DtObj)
        ElseIf Not DateTime.TryParse(DtObj.ToString(), dt) Then
            Return DtObj.ToString()
        End If

        Select Case Styl
            Case StlYMD
                Return dt.ToString("yyyy/MM/dd")
            Case StlYMDHMS
                Return dt.ToString("yyyy/MM/dd HH:mm:ss")
            Case StlHM
                Return dt.ToString("HH:mm")
            Case StlSYMD
                Return dt.ToString("yy/MM/dd")
            Case Else
                Return dt.ToString("yyyy/MM/dd")
        End Select
    End Function

    Public Function GetPcName() As String
        Return Environment.MachineName
    End Function

    Public Function UrlEncode(ByVal strText As String) As String
        If String.IsNullOrEmpty(strText) Then Return ""
        Return Uri.EscapeDataString(strText)
    End Function

    ''' <summary>
    ''' VB6 の BGR カラー値 (0xBBGGRR) を .NET Color に変換
    ''' </summary>
    Public Function ColorFromVbLong(ByVal vbColor As Integer) As Color
        Return ColorTranslator.FromOle(vbColor)
    End Function
End Module
