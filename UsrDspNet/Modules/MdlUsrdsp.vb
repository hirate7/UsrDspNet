Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Text
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Module MdlUsrdsp
    Public Const AppTitleReg As String = "UsrDspM"

    Public Const CnModeNet As Integer = 0
    Public Const CnModeLocal As Integer = 1

    Public fMainForm As FrmMain

    Public CnMplMdb As OleDbConnection
    Public CnMntMdb As OleDbConnection
    Public CnPrtMdb As OleDbConnection

    Public MplDBActive As Boolean
    Public MntDbActive As Boolean
    Public PrtDbActive As Boolean

    Public ModeDbLocation As Integer = CnModeLocal

    Public DbPath As String
    Public ProgramFilesFolder As String
    Public MyDocumentsFolder As String

    Public OptionNtMplMdb As String
    Public OptionNtMntMdb As String
    Public OptionLcMplMdb As String
    Public OptionLcMntMdb As String
    Public OptionLcPrtMdb As String

    Public OptionMapPath As String
    Public OptionLcMapPath As String
    Public OptionBrouserPath As String
    Public OptionUseGmapLink As Boolean = True

    Public OptionMntSort As Integer = 1
    Public OptionMntDspKanryou As Boolean = True
    Public OptionMntKijitsuSt As DateTime = New DateTime(1999, 1, 1)
    Public OptionMntKijitsuEd As DateTime = New DateTime(2099, 12, 31)
    Public OptionMntBunrui As Integer = 0

    Public OptionMntUsrSort As Integer = 1
    Public OptionMntUsrDspKanryou As Boolean = True
    Public OptionMntUsrAutoScroll As Boolean = True
    Public OptionMntUsrKijitsuSt As DateTime = New DateTime(1999, 1, 1)
    Public OptionMntUsrKijitsuEd As DateTime = New DateTime(2099, 12, 31)
    Public OptionMntUsrBunrui As Integer = 0
    Public OptionMntUsrPrtRangeN As Integer = 3
    Public OptionMntUsrPrtMaxLine As Integer = 30

    Public OptionPrtColor As Boolean = False
    Public OptionPrtMap As Boolean = True
    Public OptionPrtMei As Integer = 4
    Public OptionAutoCopyDb As Boolean = False

    ' 表示対象フラグ ("1"=通常, "2"=削除, "3"=一時休止, "9"=非表示)
    Public DspNormal As String = "1"
    Public DspDelete As String = "9"
    Public DspSleep As String = "3"

    Public Structure UserInfo
        Public CD As String
        Public Yago As String
        Public YagoC As String
        Public Name As String
        Public NameC As String
        Public Post As String
        Public Add1 As String
        Public Add2 As String
        Public Tel As String
        Public Keitai As String
    End Structure

    Public UInfo As UserInfo

    Public Sub InitSettings()
        ProgramFilesFolder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
        MyDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        DbPath = Path.Combine(MyDocumentsFolder, "UsrDspData")

        If Not Directory.Exists(DbPath) Then
            Try
                Directory.CreateDirectory(DbPath)
            Catch
            End Try
        End If

        OptionMntSort = CInt(Val(GetSetting(AppTitleReg, "Options", "MntSort", "1")))
        If OptionMntSort < 1 OrElse OptionMntSort > 2 Then OptionMntSort = 1
        OptionMntDspKanryou = CBool(GetSetting(AppTitleReg, "Options", "MntKanryouDsp", "True"))
        DateTime.TryParse(GetSetting(AppTitleReg, "Options", "MntKijitsuSt", "1999/01/01"), OptionMntKijitsuSt)
        DateTime.TryParse(GetSetting(AppTitleReg, "Options", "MntKijitsuEd", "2099/12/31"), OptionMntKijitsuEd)
        OptionMntBunrui = CInt(Val(GetSetting(AppTitleReg, "Options", "MntBurui", "0")))

        OptionMntUsrSort = CInt(Val(GetSetting(AppTitleReg, "Options", "MntUsrSort", "1")))
        If OptionMntUsrSort < 1 OrElse OptionMntUsrSort > 2 Then OptionMntUsrSort = 1
        OptionMntUsrDspKanryou = CBool(GetSetting(AppTitleReg, "Options", "MntUsrKanryouDsp", "True"))
        OptionMntUsrAutoScroll = CBool(GetSetting(AppTitleReg, "Options", "MntUsrAutoScroll", "True"))
        DateTime.TryParse(GetSetting(AppTitleReg, "Options", "MntUsrKijitsuSt", "1999/01/01"), OptionMntUsrKijitsuSt)
        DateTime.TryParse(GetSetting(AppTitleReg, "Options", "MntUsrKijitsuEd", "2099/12/31"), OptionMntUsrKijitsuEd)
        OptionMntUsrBunrui = CInt(Val(GetSetting(AppTitleReg, "Options", "MntUsrBurui", "0")))
        OptionMntUsrPrtRangeN = CInt(Val(GetSetting(AppTitleReg, "Options", "MntUsrPrtRangeN", "3")))
        OptionMntUsrPrtMaxLine = CInt(Val(GetSetting(AppTitleReg, "Options", "MntUsrPrtMaxLine", "30")))

        OptionNtMplMdb = "\\nas001\ud4data\Mpl.mdb"
        OptionNtMntMdb = "\\nas001\ud4data\Mnt.mdb"

        OptionLcMplMdb = Path.Combine(DbPath, "Mpl.mdb")
        OptionLcMntMdb = Path.Combine(DbPath, "Mnt.mdb")
        OptionLcPrtMdb = Path.Combine(DbPath, "Prt.mdb")

        ' もし Documents\UsrDspData に Mpl.mdb が無く C:\UsrDsp にある場合はフォールバック
        If Not File.Exists(OptionLcMplMdb) AndAlso File.Exists("C:\UsrDsp\mpl.mdb") Then
            OptionLcMplMdb = "C:\UsrDsp\mpl.mdb"
        End If
        If Not File.Exists(OptionLcMntMdb) AndAlso File.Exists("C:\UsrDsp\mnt.mdb") Then
            OptionLcMntMdb = "C:\UsrDsp\mnt.mdb"
        End If

        OptionPrtColor = CBool(GetSetting(AppTitleReg, "Options", "PrtColor", "False"))
        OptionPrtMap = CBool(GetSetting(AppTitleReg, "Options", "PrtMap", "True"))
        OptionPrtMei = CInt(Val(GetSetting(AppTitleReg, "Options", "PrtMei", "4")))

        OptionMapPath = "\\nas001\ud4data\map"
        OptionLcMapPath = Path.Combine(DbPath, "map")
        If Not Directory.Exists(OptionLcMapPath) Then
            Try
                Directory.CreateDirectory(OptionLcMapPath)
            Catch
            End Try
        End If

        OptionBrouserPath = GetSetting(AppTitleReg, "Options", "BrouserPath", "")
        OptionUseGmapLink = True
        OptionAutoCopyDb = (Val(GetSetting(AppTitleReg, "Settings", "chkAutoCopyMntMdb", "0")) = 1)

        DspNormal = "1"
        DspDelete = "9"
        DspSleep = "3"
    End Sub

    Public Function CheckNetworkFileExists(ByVal filePath As String, Optional ByVal timeoutMs As Integer = 1800) As Boolean
        Try
            Dim t As Task(Of Boolean) = Task.Run(Function() File.Exists(filePath))
            If t.Wait(timeoutMs) Then
                Return t.Result
            End If
        Catch
        End Try
        Return False
    End Function

    Public Function ConnectDatabases(Optional ByVal showNetworkWarning As Boolean = True) As Boolean
        MplDBActive = True
        MntDbActive = True
        PrtDbActive = True

        ' 1. ネットワーク疎通確認 ＆ 起動時自動データコピー
        Dim netAvailable As Boolean = CheckNetworkFileExists(OptionNtMplMdb, 1800)
        If Not netAvailable Then
            If showNetworkWarning Then
                MessageBox.Show("ネットワークデータに接続できません。 ローカルモードに切換えます", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            ModeDbLocation = CnModeLocal
        Else
            ModeDbLocation = CnModeNet
            If showNetworkWarning AndAlso OptionAutoCopyDb Then
                Try
                    If CnMplMdb IsNot Nothing AndAlso CnMplMdb.State = ConnectionState.Open Then CnMplMdb.Close()
                    If CnMntMdb IsNot Nothing AndAlso CnMntMdb.State = ConnectionState.Open Then CnMntMdb.Close()

                    Dim mdbDummy As String = Path.Combine(DbPath, "mdbfile.tmp")
                    File.Copy(OptionNtMplMdb, mdbDummy, True)
                    File.Copy(mdbDummy, OptionLcMplMdb, True)
                    File.Delete(mdbDummy)

                    If CheckNetworkFileExists(OptionNtMntMdb, 1500) Then
                        File.Copy(OptionNtMntMdb, mdbDummy, True)
                        File.Copy(mdbDummy, OptionLcMntMdb, True)
                        File.Delete(mdbDummy)
                    End If

                    FrmMessage.MsgDisp("ユーザーデータを更新しました", 1200)
                Catch
                End Try
            End If
        End If

        ' 2. メープルユーザーDB (ローカル)
        Try
            If CnMplMdb IsNot Nothing AndAlso CnMplMdb.State = ConnectionState.Open Then CnMplMdb.Close()
            CnMplMdb = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionLcMplMdb & "';")
            CnMplMdb.Open()
            EnsureVupTypeColumn(CnMplMdb)
        Catch ex As Exception
            MplDBActive = False
            MessageBox.Show(OptionLcMplMdb & " に接続できません。" & Environment.NewLine & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        If ModeDbLocation = CnModeNet Then
            Try
                Using cnNtMpl As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNtMpl.Open()
                    EnsureVupTypeColumn(cnNtMpl)
                End Using
            Catch
            End Try
        End If

        ' 3. メンテナンスDB
        Dim mntTarget As String = If(ModeDbLocation = CnModeNet, OptionNtMntMdb, OptionLcMntMdb)
        Try
            If CnMntMdb IsNot Nothing AndAlso CnMntMdb.State = ConnectionState.Open Then CnMntMdb.Close()
            CnMntMdb = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & mntTarget & "';")
            CnMntMdb.Open()
        Catch ex As Exception
            ' ネットワーク側が開けなかった場合ローカルへフォールバック試行
            If ModeDbLocation = CnModeNet AndAlso File.Exists(OptionLcMntMdb) Then
                Try
                    ModeDbLocation = CnModeLocal
                    CnMntMdb = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionLcMntMdb & "';")
                    CnMntMdb.Open()
                Catch ex2 As Exception
                    MntDbActive = False
                    MessageBox.Show(mntTarget & " に接続できません。" & Environment.NewLine & ex2.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            Else
                MntDbActive = False
                MessageBox.Show(mntTarget & " に接続できません。" & Environment.NewLine & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
        End Try

        ' 4. 印刷リストDB (ローカル)
        Try
            If CnPrtMdb IsNot Nothing AndAlso CnPrtMdb.State = ConnectionState.Open Then CnPrtMdb.Close()
            CnPrtMdb = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionLcPrtMdb & "';")
            CnPrtMdb.Open()
        Catch ex As Exception
            PrtDbActive = False
            MessageBox.Show(OptionLcPrtMdb & " に接続できません。" & Environment.NewLine & ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

        Return True
    End Function

    Public Function SwitchDbMode(ByVal targetMode As Integer) As Boolean
        If targetMode = CnModeNet Then
            If Not CheckNetworkFileExists(OptionNtMntMdb, 2000) Then
                MessageBox.Show("ネットワークデータベースが確認出来ません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        Try
            If CnMntMdb IsNot Nothing AndAlso CnMntMdb.State = ConnectionState.Open Then CnMntMdb.Close()
            Dim targetPath As String = If(targetMode = CnModeNet, OptionNtMntMdb, OptionLcMntMdb)
            CnMntMdb = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & targetPath & "';")
            CnMntMdb.Open()
            ModeDbLocation = targetMode
            MntDbActive = True
            Return True
        Catch ex As Exception
            MessageBox.Show("データベースの切替に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try
    End Function

    Public Function CopyNetworkDbToLocal() As Boolean
        If Not CheckNetworkFileExists(OptionNtMplMdb, 2000) Then
            MessageBox.Show("ネットワークデータベースが確認出来ません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If MessageBox.Show("[nas001]にあるデータをローカルPCにコピーします。", "データコピー", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
            Return False
        End If

        Try
            If CnMplMdb IsNot Nothing AndAlso CnMplMdb.State = ConnectionState.Open Then CnMplMdb.Close()
            If CnMntMdb IsNot Nothing AndAlso CnMntMdb.State = ConnectionState.Open Then CnMntMdb.Close()

            Dim mdbDummy As String = Path.Combine(DbPath, "mdbfile.tmp")
            File.Copy(OptionNtMplMdb, mdbDummy, True)
            File.Copy(mdbDummy, OptionLcMplMdb, True)
            File.Delete(mdbDummy)

            File.Copy(OptionNtMntMdb, mdbDummy, True)
            File.Copy(mdbDummy, OptionLcMntMdb, True)
            File.Delete(mdbDummy)

            ConnectDatabases(False)
            FrmMessage.MsgDisp("ユーザーデータを更新しました", 1500)
            Return True
        Catch ex As Exception
            MessageBox.Show("データベースのコピーに失敗しました。" & Environment.NewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ConnectDatabases(False)
            Return False
        End Try
    End Function

    Public Sub EnsureVupTypeColumn(ByVal cn As OleDbConnection)
        If cn Is Nothing Then Return
        Try
            If cn.State <> ConnectionState.Open Then cn.Open()
            Dim dt As New DataTable()
            Using da As New OleDbDataAdapter("SELECT TOP 1 * FROM ユーザーデータ", cn)
                da.Fill(dt)
            End Using
            If Not dt.Columns.Contains("VupType") Then
                Using cmd As New OleDbCommand("ALTER TABLE ユーザーデータ ADD COLUMN VupType BYTE", cn)
                    cmd.ExecuteNonQuery()
                End Using
                Using cmdInit As New OleDbCommand("UPDATE ユーザーデータ SET VupType = 0 WHERE VupType IS NULL", cn)
                    cmdInit.ExecuteNonQuery()
                End Using
            End If
        Catch
        End Try
    End Sub

    Public Sub CloseDatabases()
        Try
            If CnMplMdb IsNot Nothing AndAlso CnMplMdb.State = ConnectionState.Open Then CnMplMdb.Close()
        Catch
        End Try
        Try
            If CnMntMdb IsNot Nothing AndAlso CnMntMdb.State = ConnectionState.Open Then CnMntMdb.Close()
        Catch
        End Try
        Try
            If CnPrtMdb IsNot Nothing AndAlso CnPrtMdb.State = ConnectionState.Open Then CnPrtMdb.Close()
        Catch
        End Try
    End Sub

    Public Function QueryDataTable(ByVal sql As String, ByVal cn As OleDbConnection) As DataTable
        Dim dt As New DataTable()
        If cn Is Nothing Then Return dt
        If cn.State <> ConnectionState.Open Then cn.Open()
        Using da As New OleDbDataAdapter(sql, cn)
            da.Fill(dt)
        End Using
        Return dt
    End Function

    Public Function ExecuteNonQuerySql(ByVal sql As String, ByVal cn As OleDbConnection) As Integer
        If cn Is Nothing Then Return 0
        If cn.State <> ConnectionState.Open Then cn.Open()
        Using cmd As New OleDbCommand(sql, cn)
            Return cmd.ExecuteNonQuery()
        End Using
    End Function

    Public Function GetUcdSql(ByVal Ss As Object) As String
        Dim sVal As String = NulCut(Ss)
        Dim sss As String = "000000" & sVal
        Return "'" & GetNumAlp(sss) & "'"
    End Function

    Public Function GetNumAlp(ByVal S As String) As String
        S = TrimX(S)
        If S = "" Then
            Return "000000"
        Else
            Dim ss As String = "000000"
            Const allowed As String = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
            For i As Integer = 1 To Len(S)
                Dim ch As String = Mid$(S, i, 1)
                If InStr(allowed, ch) > 0 Then
                    ss &= ch
                End If
            Next
            Return Right$(ss, 6)
        End If
    End Function

    Public Sub OpenUrlInBrowser(ByVal urlOrPath As String)
        If String.IsNullOrWhiteSpace(urlOrPath) Then Return
        Try
            If Not String.IsNullOrWhiteSpace(OptionBrouserPath) AndAlso File.Exists(OptionBrouserPath) AndAlso Not OptionBrouserPath.ToLowerInvariant().EndsWith("iexplore.exe") Then
                Process.Start(OptionBrouserPath, urlOrPath)
            Else
                Process.Start(New ProcessStartInfo(urlOrPath) With {.UseShellExecute = True})
            End If
        Catch ex As Exception
            MessageBox.Show("ブラウザまたはファイルが起動出来ませんでした。" & Environment.NewLine & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Public Sub OpenMap(ByVal url As String)
        OpenUrlInBrowser(url)
    End Sub

    Public Sub OpenYamatoInfo(ByVal No As String)
        Dim openLink As String = "https://www.google.co.jp/search?hl=ja&q=%E3%83%A4%E3%83%9E%E3%83%88+" & Uri.EscapeDataString(No)
        OpenUrlInBrowser(openLink)
    End Sub

    Public Sub GetUserInfo(ByVal CD As String)
        If (UInfo.CD = CD) AndAlso (CD <> "") Then Return

        UInfo = New UserInfo()
        Try
            Dim sqlStd As String = "SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(CD)
            Dim dt As DataTable = QueryDataTable(sqlStd, CnMplMdb)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                UInfo.YagoC = NulCut(r("施術所ﾌﾘｶﾞﾅ"))
                UInfo.Yago = NulCut(r("施術所名"))
                UInfo.CD = NulCut(r("コード"))
                UInfo.NameC = NulCut(r("フリガナ"))
                UInfo.Name = NulCut(r("柔整師名"))
                UInfo.Add1 = NulCut(r("住所1"))
                UInfo.Add2 = NulCut(r("住所2"))
                UInfo.Post = NulCut(r("〒"))
                UInfo.Keitai = NulCut(r("携帯"))
                UInfo.Tel = NulCut(r("電話番号"))
            End If
        Catch
        End Try
    End Sub

    Public Function GetUI_Yago(ByVal CD As String) As String
        GetUserInfo(CD)
        Return UInfo.Yago
    End Function

    Public Function GetDspFilterSql() As String
        Return "((削除 = """ & DspNormal & """) or (削除 = """ & DspDelete & """) or (削除 = """ & DspSleep & """))"
    End Function

    Public Function GetDspModeStatusText() As String
        Dim s As String = ""
        If DspNormal = "1" Then
            s &= "[通常データ:表示する] "
        Else
            s &= "[通常データ:表示しない] "
        End If
        If DspSleep = "3" Then
            s &= "[一時休止データ:表示する] "
        Else
            s &= "[一時休止データ:表示しない] "
        End If
        If DspDelete = "2" Then
            s &= "[削除データ:表示する] "
        Else
            s &= "[削除データ:表示しない] "
        End If
        Return s
    End Function

    Private _cachedAppIcon As Icon = Nothing

    Public Function GetAppIcon() As Icon
        If _cachedAppIcon IsNot Nothing Then Return _cachedAppIcon
        Try
            Dim asm As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
            Using stream As Stream = asm.GetManifestResourceStream("UsrDspNet.usrdsp.ico")
                If stream IsNot Nothing Then
                    _cachedAppIcon = New Icon(stream)
                    Return _cachedAppIcon
                End If
            End Using
        Catch
        End Try

        Try
            _cachedAppIcon = Icon.ExtractAssociatedIcon(Reflection.Assembly.GetExecutingAssembly().Location)
            If _cachedAppIcon IsNot Nothing Then Return _cachedAppIcon
        Catch
        End Try

        Try
            Dim icoPath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usrdsp.ico")
            If File.Exists(icoPath) Then
                _cachedAppIcon = New Icon(icoPath)
                Return _cachedAppIcon
            End If
        Catch
        End Try

        Return Nothing
    End Function

    Public Sub ApplyAppIcon(ByVal f As Form)
        If f Is Nothing Then Return
        Dim ico As Icon = GetAppIcon()
        If ico IsNot Nothing Then
            f.Icon = ico
        End If
    End Sub
End Module
