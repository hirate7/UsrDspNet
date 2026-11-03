Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class FrmUsrEdit
    Private TargetCode As String = ""

    Public Property SelectedDel As String = "1"

    Private OldDel As String = "1"
    Private OldVer As String = ""
    Private OldSibu As String = ""
    Private OldTel As String = ""
    Private OldSjName As String = ""
    Private OldSjNameF As String = ""
    Private OldJsName As String = ""
    Private OldJsNameF As String = ""
    Private OldZip As String = ""
    Private OldAd1 As String = ""
    Private OldAd2 As String = ""
    Private OldSinryou As String = ""
    Private OldMemo As String = ""

    Public Function LoadUserInfo(ByVal code As String, ByVal userTitle As String) As Boolean
        TargetCode = GetNumAlp(code)
        If Not CheckAndAcquireUserLock(TargetCode, Me) Then Return False
        lblUser.Text = userTitle
        lblTantoInfo.Text = If(String.IsNullOrWhiteSpace(OptionDefaultSyainName), "担当: 未設定", $"担当: {OptionDefaultSyainName}")

        ' コンボボックスの選択肢読み込み（mpl.mdbから既存データを重複排除＆ソートして取得）
        PopulateCandidates(cmbVer, "分院Version")
        PopulateCandidates(cmbSibu, "支部名")

        ' 現在のデータを取得
        Dim dt As DataTable = Nothing
        Try
            If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    EnsureRrkColumn(cnNt)
                    dt = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(TargetCode), cnNt)
                End Using
            Else
                EnsureRrkColumn(CnMplMdb)
                dt = QueryDataTable("SELECT * FROM ユーザーデータ WHERE コード = " & GetUcdSql(TargetCode), CnMplMdb)
            End If

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                OldDel = TrimX(NulCut(r("削除")))
                If OldDel <> "2" AndAlso OldDel <> "3" Then OldDel = "1"
                OldVer = NulCut(r("分院Version"))
                OldSibu = NulCut(r("支部名"))
                OldTel = NulCut(r("電話番号"))
                OldSjName = NulCut(r("施術所名"))
                OldSjNameF = NulCut(r("施術所ﾌﾘｶﾞﾅ"))
                OldJsName = NulCut(r("柔整師名"))
                OldJsNameF = NulCut(r("フリガナ"))
                OldZip = NulCut(r("〒"))
                OldAd1 = NulCut(r("住所1"))
                OldAd2 = NulCut(r("住所2"))
                OldSinryou = CutCR(NulCut(r("診療時間")))
                OldMemo = CutCR(NulCut(r("備考")))
            End If
        Catch ex As Exception
            MessageBox.Show("ユーザー情報の取得に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        Select Case OldDel
            Case "2"
                rdoDel2.Checked = True
            Case "3"
                rdoDel3.Checked = True
            Case Else
                rdoDel1.Checked = True
        End Select

        SelectedDel = OldDel
        cmbVer.Text = OldVer
        cmbSibu.Text = OldSibu
        txtTel.Text = OldTel
        txtSjName.Text = OldSjName
        txtSjNameF.Text = OldSjNameF
        txtJsName.Text = OldJsName
        txtJsNameF.Text = OldJsNameF
        txtZip.Text = OldZip
        txtAd1.Text = OldAd1
        txtAd2.Text = OldAd2
        txtSinryou.Text = OldSinryou
        txtMemo.Text = OldMemo
        Return True
    End Function

    ''' <summary>
    ''' mpl.mdbから指定カラムの既存データを重複無くソートしてコンボボックスに設定
    ''' </summary>
    Private Sub PopulateCandidates(ByVal cmb As ComboBox, ByVal columnName As String)
        cmb.Items.Clear()
        Try
            Dim dt As DataTable = Nothing
            Dim sql As String = $"SELECT DISTINCT [{columnName}] FROM ユーザーデータ WHERE [{columnName}] IS NOT NULL AND [{columnName}] <> '' ORDER BY [{columnName}]"

            If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                    cnNt.Open()
                    dt = QueryDataTable(sql, cnNt)
                End Using
            Else
                dt = QueryDataTable(sql, CnMplMdb)
            End If

            If dt IsNot Nothing Then
                For Each row As DataRow In dt.Rows
                    Dim val As String = NulCut(row(0))
                    If val <> "" AndAlso Not cmb.Items.Contains(val) Then
                        cmb.Items.Add(val)
                    End If
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub UpdateUserOnConnection(ByVal cn As OleDbConnection,
                                       ByVal del As String,
                                       ByVal ver As String, ByVal sibu As String,
                                       ByVal tel As String, ByVal sjName As String, ByVal sjNameF As String,
                                       ByVal jsName As String, ByVal jsNameF As String,
                                       ByVal zip As String, ByVal ad1 As String, ByVal ad2 As String,
                                       ByVal sinryou As String, ByVal memo As String,
                                       ByVal historyJson As String)
        If cn Is Nothing Then Return
        If cn.State <> ConnectionState.Open Then cn.Open()
        EnsureRrkColumn(cn)

        Dim sql As String = "UPDATE ユーザーデータ SET " &
            "[削除] = ?, " &
            "[分院Version] = ?, [支部名] = ?, " &
            "[電話番号] = ?, [施術所名] = ?, [施術所ﾌﾘｶﾞﾅ] = ?, " &
            "[柔整師名] = ?, [フリガナ] = ?, " &
            "[〒] = ?, [住所1] = ?, [住所2] = ?, " &
            "[診療時間] = ?, [備考] = ?, [履歴] = ? " &
            "WHERE [コード] = ?"

        Using cmd As New OleDbCommand(sql, cn)
            cmd.Parameters.Add("del", OleDbType.VarWChar).Value = ToDbStr(del)
            cmd.Parameters.Add("ver", OleDbType.VarWChar).Value = ToDbStr(ver)
            cmd.Parameters.Add("sibu", OleDbType.VarWChar).Value = ToDbStr(sibu)
            cmd.Parameters.Add("tel", OleDbType.VarWChar).Value = ToDbStr(tel)
            cmd.Parameters.Add("sj", OleDbType.VarWChar).Value = ToDbStr(sjName)
            cmd.Parameters.Add("sjf", OleDbType.VarWChar).Value = ToDbStr(sjNameF)
            cmd.Parameters.Add("js", OleDbType.VarWChar).Value = ToDbStr(jsName)
            cmd.Parameters.Add("jsf", OleDbType.VarWChar).Value = ToDbStr(jsNameF)
            cmd.Parameters.Add("zip", OleDbType.VarWChar).Value = ToDbStr(zip)
            cmd.Parameters.Add("ad1", OleDbType.VarWChar).Value = ToDbStr(ad1)
            cmd.Parameters.Add("ad2", OleDbType.VarWChar).Value = ToDbStr(ad2)
            cmd.Parameters.Add("sin", OleDbType.VarWChar).Value = ToDbStr(sinryou)
            cmd.Parameters.Add("memo", OleDbType.VarWChar).Value = ToDbStr(memo)
            cmd.Parameters.Add("rrk", OleDbType.LongVarWChar).Value = ToDbStr(historyJson)
            cmd.Parameters.Add("cd", OleDbType.VarWChar).Value = TargetCode
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ''' <summary>
    ''' 診療時間・備考のテキストボックスでEnterキーによる改行挿入を抑止
    ''' </summary>
    Private Sub txtNoEnter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSinryou.KeyDown, txtMemo.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
        End If
    End Sub

    ''' <summary>
    ''' 貼り付け等で改行文字（CR/LF）が混入した場合に半角スペースへ自動変換
    ''' </summary>
    Private Sub txtNoNewline_TextChanged(sender As Object, e As EventArgs) Handles txtSinryou.TextChanged, txtMemo.TextChanged
        Dim tb As TextBox = TryCast(sender, TextBox)
        If tb Is Nothing Then Return
        If tb.Text.Contains(vbCr) OrElse tb.Text.Contains(vbLf) Then
            Dim selStart As Integer = tb.SelectionStart
            Dim newText As String = tb.Text.Replace(vbCrLf, " ").Replace(vbCr, " ").Replace(vbLf, " ")
            tb.Text = newText
            tb.SelectionStart = Math.Min(selStart, tb.Text.Length)
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Not ValidateUserLockForSave(TargetCode, Me) Then Return
        If ModeDbLocation = CnModeLocal Then
            MessageBox.Show("ローカルモードでは更新できません。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim del As String = If(rdoDel2.Checked, "2", If(rdoDel3.Checked, "3", "1"))
        Dim ver As String = TrimX(cmbVer.Text)
        Dim sibu As String = TrimX(cmbSibu.Text)
        Dim tel As String = TrimX(txtTel.Text)
        Dim sjName As String = TrimX(txtSjName.Text)
        Dim sjNameF As String = TrimX(txtSjNameF.Text)
        Dim jsName As String = TrimX(txtJsName.Text)
        Dim jsNameF As String = TrimX(txtJsNameF.Text)
        Dim zip As String = TrimX(txtZip.Text)
        Dim ad1 As String = TrimX(txtAd1.Text)
        Dim ad2 As String = TrimX(txtAd2.Text)
        Dim sinryou As String = TrimX(CutCR(txtSinryou.Text))
        Dim memo As String = TrimX(CutCR(txtMemo.Text))

        Dim changed As Boolean = (del <> OldDel) OrElse (ver <> OldVer) OrElse (sibu <> OldSibu) OrElse
                                 (tel <> OldTel) OrElse (sjName <> OldSjName) OrElse (sjNameF <> OldSjNameF) OrElse
                                 (jsName <> OldJsName) OrElse (jsNameF <> OldJsNameF) OrElse
                                 (zip <> OldZip) OrElse (ad1 <> OldAd1) OrElse (ad2 <> OldAd2) OrElse
                                 (sinryou <> OldSinryou) OrElse (memo <> OldMemo)

        If changed Then
            Dim changes As New List(Of UsrRrkChange)()
            If del <> OldDel Then
                Dim delName As Func(Of String, String) = Function(d)
                    Select Case d
                        Case "2" : Return "2:削除"
                        Case "3" : Return "3:一時休止"
                        Case Else : Return "1:通常"
                    End Select
                End Function
                AddChangeIfDifferent(changes, "削除区分", delName(OldDel), delName(del))
            End If
            AddChangeIfDifferent(changes, "Ver", OldVer, ver)
            AddChangeIfDifferent(changes, "支部名", OldSibu, sibu)
            AddChangeIfDifferent(changes, "TEL", OldTel, tel)
            AddChangeIfDifferent(changes, "施術所名称", OldSjName, sjName)
            AddChangeIfDifferent(changes, "施術所フリガナ", OldSjNameF, sjNameF)
            AddChangeIfDifferent(changes, "柔整師名", OldJsName, jsName)
            AddChangeIfDifferent(changes, "柔整師フリガナ", OldJsNameF, jsNameF)
            AddChangeIfDifferent(changes, "郵便番号", OldZip, zip)
            AddChangeIfDifferent(changes, "住所1", OldAd1, ad1)
            AddChangeIfDifferent(changes, "住所2", OldAd2, ad2)
            AddChangeIfDifferent(changes, "診療時間", OldSinryou, sinryou)
            AddChangeIfDifferent(changes, "備考", OldMemo, memo)

            Dim existingJson As String = ""
            Try
                If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                    Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                        cnNt.Open()
                        existingJson = GetUserHistoryJson(TargetCode, cnNt)
                    End Using
                Else
                    existingJson = GetUserHistoryJson(TargetCode, CnMplMdb)
                End If
            Catch
            End Try

            Dim newHistoryJson As String = AppendHistoryJson(existingJson, OptionDefaultSyainCode, OptionDefaultSyainName, changes)

            Try
                If ModeDbLocation = CnModeNet AndAlso CheckNetworkFileExists(OptionNtMplMdb, 1500) Then
                    Using cnNt As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" & OptionNtMplMdb & "';")
                        cnNt.Open()
                        UpdateUserOnConnection(cnNt, del, ver, sibu, tel, sjName, sjNameF, jsName, jsNameF, zip, ad1, ad2, sinryou, memo, newHistoryJson)
                    End Using
                End If

                UpdateUserOnConnection(CnMplMdb, del, ver, sibu, tel, sjName, sjNameF, jsName, jsNameF, zip, ad1, ad2, sinryou, memo, newHistoryJson)

                SelectedDel = del
                Me.DialogResult = DialogResult.OK
            Catch ex As Exception
                MessageBox.Show("ユーザー情報の更新に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return
            End Try
        Else
            Me.DialogResult = DialogResult.Cancel
        End If

        Me.Close()
    End Sub

    Private Sub FrmUsrEdit_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ReleaseUserLock(TargetCode)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Using dlg As New FrmUsrRrkViewer()
            dlg.ShowHistory(TargetCode, lblUser.Text, Me)
        End Using
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        If keyData = (Keys.Alt Or Keys.U) Then
            btnOk.PerformClick()
            Return True
        ElseIf keyData = (Keys.Alt Or Keys.C) Then
            btnCancel.PerformClick()
            Return True
        ElseIf keyData = (Keys.Alt Or Keys.H) Then
            btnHistory.PerformClick()
            Return True
        ElseIf keyData = Keys.Escape Then
            ' Escキーでの誤終了を防止
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

End Class
