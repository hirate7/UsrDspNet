Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class FrmEtc
    Private TargetCode As String = ""
    Private OldNetN As Integer = 0
    Private OldImeN As Integer = 0
    Private OldInputModeN As Integer = 0
    Private OldClickModeN As Integer = 0
    Private OldGmap1 As String = ""
    Private OldGmap2 As String = ""
    Private OldGmap3 As String = ""
    Private OldVupType As Integer = 0

    Public Sub LoadEtcInfo(ByVal code As String, ByVal userTitle As String)
        TargetCode = GetNumAlp(code)
        lblUser.Text = userTitle
        grpGmapLink.Visible = OptionUseGmapLink

        Dim netN As Integer = 0
        Dim imeN As Integer = 0
        Dim inputN As Integer = 0
        Dim clickN As Integer = 0
        Dim g1 As String = ""
        Dim g2 As String = ""
        Dim g3 As String = ""
        Dim vupN As Integer = 0

        Try
            Dim dt As DataTable = Nothing
            Dim dtUsr As DataTable = Nothing
            If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    EnsureVupTypeColumn(cnNt)
                    dt = QueryDataTable("SELECT * FROM 拡張データ WHERE コード = " & GetUcdSql(TargetCode), cnNt)
                    dtUsr = QueryDataTable("SELECT VupType FROM ユーザーデータ WHERE コード = " & GetUcdSql(TargetCode), cnNt)
                End Using
            Else
                dt = QueryDataTable("SELECT * FROM 拡張データ WHERE コード = " & GetUcdSql(TargetCode), CnMplMdb)
                dtUsr = QueryDataTable("SELECT VupType FROM ユーザーデータ WHERE コード = " & GetUcdSql(TargetCode), CnMplMdb)
            End If

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                netN = CInt(NulCutN(r("ネット接続")))
                imeN = CInt(NulCutN(r("IME")))
                inputN = CInt(NulCutN(r("入力方式")))
                clickN = CInt(NulCutN(r("クリックモード")))
                g1 = NulCut(r("GMapLink1"))
                g2 = NulCut(r("GMapLink2"))
                g3 = NulCut(r("GMapLink3"))
            End If
            If dtUsr IsNot Nothing AndAlso dtUsr.Rows.Count > 0 Then
                vupN = CInt(NulCutN(dtUsr.Rows(0)("VupType")))
            End If
        Catch
        End Try

        Dim imeOpts() As RadioButton = {optIme0, optIme1, optIme2}
        If imeN >= 0 AndAlso imeN <= 2 Then imeOpts(imeN).Checked = True Else optIme0.Checked = True

        Dim inputOpts() As RadioButton = {optInput0, optInput1, optInput2, optInput3}
        If inputN >= 0 AndAlso inputN <= 3 Then inputOpts(inputN).Checked = True Else optInput0.Checked = True

        Dim netOpts() As RadioButton = {optNet0, optNet1, optNet2, optNet3}
        If netN >= 0 AndAlso netN <= 3 Then netOpts(netN).Checked = True Else optNet0.Checked = True

        Dim clickOpts() As RadioButton = {optClick0, optClick1, optClick2}
        If clickN >= 0 AndAlso clickN <= 2 Then clickOpts(clickN).Checked = True Else optClick0.Checked = True

        Dim vupOpts() As RadioButton = {optVup0, optVup1, optVup2}
        If vupN >= 0 AndAlso vupN <= 2 Then vupOpts(vupN).Checked = True Else optVup0.Checked = True

        txtGMapLink0.Text = g1
        txtGMapLink1.Text = g2
        txtGMapLink2.Text = g3

        OldNetN = netN
        OldImeN = imeN
        OldInputModeN = inputN
        OldClickModeN = clickN
        OldGmap1 = g1
        OldGmap2 = g2
        OldGmap3 = g3
        OldVupType = vupN
    End Sub

    Private Function GetSelectedIndex(ByVal radios() As RadioButton) As Integer
        For i As Integer = 0 To radios.Length - 1
            If radios(i).Checked Then Return i
        Next
        Return 0
    End Function

    Private Sub UpsertEtcOnConnection(ByVal cn As OleDbConnection, ByVal netN As Integer, ByVal imeN As Integer, ByVal inputN As Integer, ByVal clickN As Integer, ByVal g1 As String, ByVal g2 As String, ByVal g3 As String, ByVal vupN As Integer)
        If cn Is Nothing Then Return
        If cn.State <> ConnectionState.Open Then cn.Open()
        EnsureVupTypeColumn(cn)

        Using cmdVup As New OleDbCommand("UPDATE ユーザーデータ SET [VupType] = ? WHERE [コード] = ?", cn)
            cmdVup.Parameters.Add("vup", OleDbType.UnsignedTinyInt).Value = CByte(vupN)
            cmdVup.Parameters.Add("cd", OleDbType.VarWChar).Value = TargetCode
            cmdVup.ExecuteNonQuery()
        End Using

        Dim dt As DataTable = QueryDataTable("SELECT ID FROM 拡張データ WHERE コード = " & GetUcdSql(TargetCode), cn)
        If dt.Rows.Count > 0 Then
            Dim sqlUpd As String =
                "UPDATE 拡張データ SET [ネット接続] = ?, [IME] = ?, [入力方式] = ?, [クリックモード] = ?, [GMapLink1] = ?, [GMapLink2] = ?, [GMapLink3] = ? WHERE [コード] = ?"
            Using cmd As New OleDbCommand(sqlUpd, cn)
                cmd.Parameters.Add("net", OleDbType.VarWChar).Value = netN.ToString()
                cmd.Parameters.Add("ime", OleDbType.VarWChar).Value = imeN.ToString()
                cmd.Parameters.Add("inp", OleDbType.VarWChar).Value = inputN.ToString()
                cmd.Parameters.Add("clk", OleDbType.VarWChar).Value = clickN.ToString()
                cmd.Parameters.Add("g1", OleDbType.VarWChar).Value = g1
                cmd.Parameters.Add("g2", OleDbType.VarWChar).Value = g2
                cmd.Parameters.Add("g3", OleDbType.VarWChar).Value = g3
                cmd.Parameters.Add("cd", OleDbType.VarWChar).Value = TargetCode
                cmd.ExecuteNonQuery()
            End Using
        Else
            Dim sqlIns As String =
                "INSERT INTO 拡張データ ([コード], [ネット接続], [IME], [入力方式], [クリックモード], [GMapLink1], [GMapLink2], [GMapLink3]) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"
            Using cmd As New OleDbCommand(sqlIns, cn)
                cmd.Parameters.Add("cd", OleDbType.VarWChar).Value = TargetCode
                cmd.Parameters.Add("net", OleDbType.VarWChar).Value = netN.ToString()
                cmd.Parameters.Add("ime", OleDbType.VarWChar).Value = imeN.ToString()
                cmd.Parameters.Add("inp", OleDbType.VarWChar).Value = inputN.ToString()
                cmd.Parameters.Add("clk", OleDbType.VarWChar).Value = clickN.ToString()
                cmd.Parameters.Add("g1", OleDbType.VarWChar).Value = g1
                cmd.Parameters.Add("g2", OleDbType.VarWChar).Value = g2
                cmd.Parameters.Add("g3", OleDbType.VarWChar).Value = g3
                cmd.ExecuteNonQuery()
            End Using
        End If
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        If ModeDbLocation = CnModeLocal Then
            MessageBox.Show("ローカルモードでは無効です", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim imeN As Integer = GetSelectedIndex(New RadioButton() {optIme0, optIme1, optIme2})
        Dim inputN As Integer = GetSelectedIndex(New RadioButton() {optInput0, optInput1, optInput2, optInput3})
        Dim netN As Integer = GetSelectedIndex(New RadioButton() {optNet0, optNet1, optNet2, optNet3})
        Dim clickN As Integer = GetSelectedIndex(New RadioButton() {optClick0, optClick1, optClick2})
        Dim vupN As Integer = GetSelectedIndex(New RadioButton() {optVup0, optVup1, optVup2})
        Dim g1 As String = TrimX(txtGMapLink0.Text)
        Dim g2 As String = TrimX(txtGMapLink1.Text)
        Dim g3 As String = TrimX(txtGMapLink2.Text)

        Dim changed As Boolean = (imeN <> OldImeN) OrElse (inputN <> OldInputModeN) OrElse (netN <> OldNetN) OrElse (clickN <> OldClickModeN) OrElse (g1 <> OldGmap1) OrElse (g2 <> OldGmap2) OrElse (g3 <> OldGmap3) OrElse (vupN <> OldVupType)

        If changed Then
            Try
                If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                    Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                        cnNt.Open()
                        UpsertEtcOnConnection(cnNt, netN, imeN, inputN, clickN, g1, g2, g3, vupN)
                    End Using
                End If

                UpsertEtcOnConnection(CnMplMdb, netN, imeN, inputN, clickN, g1, g2, g3, vupN)

                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show("その他の情報の更新に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try
        End If

        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class
