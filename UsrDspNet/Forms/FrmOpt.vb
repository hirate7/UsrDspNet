Imports System.IO
Imports System.Windows.Forms

Public Class FrmOpt
    Private _initialTabIndex As Integer = 0
    Public Property SettingsChanged As Boolean = False

    Public Sub OptDsp(Optional ByVal tabIndex As Integer = 0, Optional ByVal owner As IWin32Window = Nothing)
        _initialTabIndex = tabIndex
        If owner IsNot Nothing Then
            Me.ShowDialog(owner)
        Else
            Me.ShowDialog()
        End If
    End Sub

    Private Sub FrmOpt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadOptionsToUi()
        If _initialTabIndex >= 0 AndAlso _initialTabIndex < tbsOpt.TabCount Then
            tbsOpt.SelectedIndex = _initialTabIndex
        End If
    End Sub

    Private Sub LoadOptionsToUi()
        ' Tab 1: DB & 起動時自動更新
        TxtLcMplMdb.Text = OptionLcMplMdb
        TxtNtMplMdb.Text = OptionNtMplMdb
        TxtNtMntMdb.Text = OptionNtMntMdb
        TxtLcPrtMdb.Text = OptionLcPrtMdb
        chkAutoCopyMntMdb.Checked = OptionAutoCopyDb

        ' Tab 2: メンテ(ユーザー別)
        If OptionMntUsrSort = 2 Then
            OptUsrKijitsu.Checked = True
        Else
            OptUsrSagyou.Checked = True
        End If

        Select Case OptionMntUsrBunrui
            Case 1
                OptUsrBunrui1.Checked = True
            Case 2
                OptUsrBunrui2.Checked = True
            Case Else
                OptUsrBunrui0.Checked = True
        End Select

        ChkUsrAutoScroll.Checked = OptionMntUsrAutoScroll
        ChkUsrKanryou.Checked = OptionMntUsrDspKanryou
        TxtUsrKijitsuSt.Text = MakeDateString(OptionMntUsrKijitsuSt)
        TxtUsrKijitsuEd.Text = MakeDateString(OptionMntUsrKijitsuEd)
        UpdateUsrKijitsuEnabled()

        ' Tab 3: 全メンテ記録
        If OptionMntSort = 2 Then
            OptKijitsu.Checked = True
        Else
            OptSagyou.Checked = True
        End If

        Select Case OptionMntBunrui
            Case 1
                OptBunrui1.Checked = True
            Case 2
                OptBunrui2.Checked = True
            Case Else
                OptBunrui0.Checked = True
        End Select

        ChkKanryou.Checked = OptionMntDspKanryou
        TxtKijitsuSt.Text = MakeDateString(OptionMntKijitsuSt)
        TxtKijitsuEd.Text = MakeDateString(OptionMntKijitsuEd)
        UpdateMntKijitsuEnabled()

        ' Tab 4: 印刷設定
        If OptionPrtMap Then
            OptMapTrue.Checked = True
        Else
            OptMapFalse.Checked = True
        End If

        If OptionPrtColor Then
            OptColor.Checked = True
        Else
            OptMono.Checked = True
        End If

        Select Case OptionPrtMei
            Case 1
                optMei1.Checked = True
            Case 2
                OptMei2.Checked = True
            Case Else
                OptMei4.Checked = True
        End Select

        ' Tab 5: メンテ印刷
        Dim rangeVal As Integer = Math.Max(1, Math.Min(999, OptionMntUsrPrtRangeN))
        Dim lineVal As Integer = Math.Max(1, Math.Min(9999, OptionMntUsrPrtMaxLine))
        numMntUsrPrtRangeN.Value = rangeVal
        numMntUsrPrtMaxLine.Value = lineVal

        ' Tab 6: ブラウザ設定
        txtBrouserPath.Text = OptionBrouserPath
    End Sub

    Private Sub OptUsrSort_CheckedChanged(sender As Object, e As EventArgs) Handles OptUsrSagyou.CheckedChanged, OptUsrKijitsu.CheckedChanged
        UpdateUsrKijitsuEnabled()
    End Sub

    Private Sub UpdateUsrKijitsuEnabled()
        Dim isKijitsu As Boolean = OptUsrKijitsu.Checked
        TxtUsrKijitsuSt.Enabled = isKijitsu
        TxtUsrKijitsuEd.Enabled = isKijitsu
    End Sub

    Private Sub OptMntSort_CheckedChanged(sender As Object, e As EventArgs) Handles OptSagyou.CheckedChanged, OptKijitsu.CheckedChanged
        UpdateMntKijitsuEnabled()
    End Sub

    Private Sub UpdateMntKijitsuEnabled()
        Dim isKijitsu As Boolean = OptKijitsu.Checked
        TxtKijitsuSt.Enabled = isKijitsu
        TxtKijitsuEd.Enabled = isKijitsu
    End Sub

    Private Function SaveOptionsFromUi() As Boolean
        ' 日付検証
        Dim usrSt As DateTime
        Dim usrEd As DateTime
        If Not DateTime.TryParse(TxtUsrKijitsuSt.Text.Trim(), usrSt) Then
            tbsOpt.SelectedTab = tabMntUsr
            TxtUsrKijitsuSt.Focus()
            MessageBox.Show("期日範囲の指定が正しくありません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If Not DateTime.TryParse(TxtUsrKijitsuEd.Text.Trim(), usrEd) Then
            tbsOpt.SelectedTab = tabMntUsr
            TxtUsrKijitsuEd.Focus()
            MessageBox.Show("期日範囲の指定が正しくありません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        Dim mntSt As DateTime
        Dim mntEd As DateTime
        If Not DateTime.TryParse(TxtKijitsuSt.Text.Trim(), mntSt) Then
            tbsOpt.SelectedTab = tabMnt
            TxtKijitsuSt.Focus()
            MessageBox.Show("期日範囲の指定が正しくありません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        If Not DateTime.TryParse(TxtKijitsuEd.Text.Trim(), mntEd) Then
            tbsOpt.SelectedTab = tabMnt
            TxtKijitsuEd.Focus()
            MessageBox.Show("期日範囲の指定が正しくありません。", "入力確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Tab 1: 起動時自動コピー
        OptionAutoCopyDb = chkAutoCopyMntMdb.Checked
        SaveSetting(AppTitleReg, "Settings", "chkAutoCopyMntMdb", If(OptionAutoCopyDb, "1", "0"))

        ' Tab 2: メンテ(ユーザー別)
        OptionMntUsrSort = If(OptUsrKijitsu.Checked, 2, 1)
        If OptUsrBunrui1.Checked Then
            OptionMntUsrBunrui = 1
        ElseIf OptUsrBunrui2.Checked Then
            OptionMntUsrBunrui = 2
        Else
            OptionMntUsrBunrui = 0
        End If
        OptionMntUsrAutoScroll = ChkUsrAutoScroll.Checked
        OptionMntUsrDspKanryou = ChkUsrKanryou.Checked
        OptionMntUsrKijitsuSt = usrSt
        OptionMntUsrKijitsuEd = usrEd

        SaveSetting(AppTitleReg, "Options", "MntUsrSort", OptionMntUsrSort.ToString())
        SaveSetting(AppTitleReg, "Options", "MntUsrBurui", OptionMntUsrBunrui.ToString())
        SaveSetting(AppTitleReg, "Options", "MntUsrAutoScroll", OptionMntUsrAutoScroll.ToString())
        SaveSetting(AppTitleReg, "Options", "MntUsrKanryouDsp", OptionMntUsrDspKanryou.ToString())
        SaveSetting(AppTitleReg, "Options", "MntUsrKijitsuSt", MakeDateString(OptionMntUsrKijitsuSt))
        SaveSetting(AppTitleReg, "Options", "MntUsrKijitsuEd", MakeDateString(OptionMntUsrKijitsuEd))

        ' Tab 3: 全メンテ記録
        OptionMntSort = If(OptKijitsu.Checked, 2, 1)
        If OptBunrui1.Checked Then
            OptionMntBunrui = 1
        ElseIf OptBunrui2.Checked Then
            OptionMntBunrui = 2
        Else
            OptionMntBunrui = 0
        End If
        OptionMntDspKanryou = ChkKanryou.Checked
        OptionMntKijitsuSt = mntSt
        OptionMntKijitsuEd = mntEd

        SaveSetting(AppTitleReg, "Options", "MntSort", OptionMntSort.ToString())
        SaveSetting(AppTitleReg, "Options", "MntBurui", OptionMntBunrui.ToString())
        SaveSetting(AppTitleReg, "Options", "MntKanryouDsp", OptionMntDspKanryou.ToString())
        SaveSetting(AppTitleReg, "Options", "MntKijitsuSt", MakeDateString(OptionMntKijitsuSt))
        SaveSetting(AppTitleReg, "Options", "MntKijitsuEd", MakeDateString(OptionMntKijitsuEd))

        ' Tab 4: 印刷設定
        OptionPrtMap = OptMapTrue.Checked
        OptionPrtColor = OptColor.Checked
        If optMei1.Checked Then
            OptionPrtMei = 1
        ElseIf OptMei2.Checked Then
            OptionPrtMei = 2
        Else
            OptionPrtMei = 4
        End If

        SaveSetting(AppTitleReg, "Options", "PrtMap", OptionPrtMap.ToString())
        SaveSetting(AppTitleReg, "Options", "PrtColor", OptionPrtColor.ToString())
        SaveSetting(AppTitleReg, "Options", "PrtMei", OptionPrtMei.ToString())

        ' Tab 5: メンテ印刷
        OptionMntUsrPrtRangeN = CInt(numMntUsrPrtRangeN.Value)
        OptionMntUsrPrtMaxLine = CInt(numMntUsrPrtMaxLine.Value)
        SaveSetting(AppTitleReg, "Options", "MntUsrPrtRangeN", OptionMntUsrPrtRangeN.ToString())
        SaveSetting(AppTitleReg, "Options", "MntUsrPrtMaxLine", OptionMntUsrPrtMaxLine.ToString())

        ' Tab 6: ブラウザ設定
        OptionBrouserPath = txtBrouserPath.Text.Trim()
        SaveSetting(AppTitleReg, "Options", "BrouserPath", OptionBrouserPath)

        SettingsChanged = True
        Return True
    End Function

    Private Sub cmdOK_Click(sender As Object, e As EventArgs) Handles cmdOK.Click
        If SaveOptionsFromUi() Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub cmdApply_Click(sender As Object, e As EventArgs) Handles cmdApply.Click
        SaveOptionsFromUi()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdBrowserRef_Click(sender As Object, e As EventArgs) Handles cmdBrowserRef.Click
        Using ofd As New OpenFileDialog()
            ofd.Title = "ブラウザ実行ファイルの選択"
            ofd.Filter = "実行ファイル (*.exe)|*.exe|すべてのファイル (*.*)|*.*"
            If Not String.IsNullOrWhiteSpace(txtBrouserPath.Text) AndAlso File.Exists(txtBrouserPath.Text) Then
                ofd.FileName = txtBrouserPath.Text
            Else
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
            End If
            If ofd.ShowDialog(Me) = DialogResult.OK Then
                txtBrouserPath.Text = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub btnBrowserDefault_Click(sender As Object, e As EventArgs) Handles btnBrowserDefault.Click
        txtBrouserPath.Text = ""
    End Sub

    Private Sub btnBrowserEdge_Click(sender As Object, e As EventArgs) Handles btnBrowserEdge.Click
        Dim edge86 As String = "C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"
        Dim edge64 As String = "C:\Program Files\Microsoft\Edge\Application\msedge.exe"
        If File.Exists(edge86) Then
            txtBrouserPath.Text = edge86
        ElseIf File.Exists(edge64) Then
            txtBrouserPath.Text = edge64
        Else
            txtBrouserPath.Text = edge86
        End If
    End Sub

    Private Sub btnBrowserChrome_Click(sender As Object, e As EventArgs) Handles btnBrowserChrome.Click
        Dim chrome64 As String = "C:\Program Files\Google\Chrome\Application\chrome.exe"
        Dim chrome86 As String = "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
        If File.Exists(chrome64) Then
            txtBrouserPath.Text = chrome64
        ElseIf File.Exists(chrome86) Then
            txtBrouserPath.Text = chrome86
        Else
            txtBrouserPath.Text = chrome64
        End If
    End Sub

    Private Sub btnBrowserFirefox_Click(sender As Object, e As EventArgs) Handles btnBrowserFirefox.Click
        Dim ff64 As String = "C:\Program Files\Mozilla Firefox\firefox.exe"
        Dim ff86 As String = "C:\Program Files (x86)\Mozilla Firefox\firefox.exe"
        If File.Exists(ff64) Then
            txtBrouserPath.Text = ff64
        ElseIf File.Exists(ff86) Then
            txtBrouserPath.Text = ff86
        Else
            txtBrouserPath.Text = ff64
        End If
    End Sub
End Class
