Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class FrmMntEdit
    Private Class SyainItem
        Public Property Code As String
        Public Property Name As String
        Public Overrides Function ToString() As String
            Return Name
        End Function
    End Class

    Private UpMode As Integer = 1
    Private TargetId As Long = 0
    Private TargetUcd As String = ""

    Private hznTxtSagyou As String = ""
    Private hznTxtSagyouTime As String = ""
    Private hznTxtKijitsu As String = ""
    Private hznCmbBunrui As String = ""
    Private hznTxtNaiyou As String = ""
    Private hznLblSyainCD As String = ""
    Private hznChkKanryou As Boolean = False
    Private hznInmVisit As Integer = 0

    Public Property SavedRecordId As Long = 0

    Public Sub EditDsp(ByVal ucd As String, ByVal cd As Long, ByVal mode As Integer)
        UpMode = mode
        TargetId = cd
        TargetUcd = GetNumAlp(ucd)

        ' 1. 分類リスト読込
        CmbBunrui.Items.Clear()
        Try
            Dim dtBunrui As DataTable = QueryDataTable("SELECT DISTINCT 分類 FROM メンテナンス記録", CnMntMdb)
            For Each r As DataRow In dtBunrui.Rows
                Dim b As String = TrimX(NulCut(r("分類")))
                If b <> "" AndAlso Not CmbBunrui.Items.Contains(b) Then
                    CmbBunrui.Items.Add(b)
                End If
            Next
        Catch
        End Try

        ' 2. ユーザー基本情報読込
        Try
            Dim dtUsr As DataTable = QueryDataTable("SELECT コード, 支部名, 施術所名, 柔整師名 FROM ユーザーデータ WHERE コード = " & GetUcdSql(TargetUcd), CnMplMdb)
            If dtUsr.Rows.Count > 0 Then
                Dim r As DataRow = dtUsr.Rows(0)
                LblUsrCd.Text = NulCut(r("コード"))
                LblSibu.Text = NulCut(r("支部名"))
                LblSjName.Text = NulCut(r("施術所名"))
                LblJsName.Text = NulCut(r("柔整師名"))
            Else
                LblUsrCd.Text = TargetUcd
                LblSibu.Text = ""
                LblSjName.Text = ""
                LblJsName.Text = ""
            End If
        Catch
        End Try

        ' 3. 社員マスター読込 (通常社員を先頭、カッコ付き・神奈川・他を後ろに配置)
        CmbSyain.Items.Clear()
        Dim deferredList As New List(Of SyainItem)()
        Try
            Dim dtSyain As DataTable = QueryDataTable("SELECT DISTINCT 社員コード, 社員名 FROM 社員マスター ORDER BY 社員コード", CnMntMdb)
            For Each r As DataRow In dtSyain.Rows
                Dim sName As String = TrimX(NulCut(r("社員名")))
                Dim sCode As String = TrimX(NulCut(r("社員コード")))
                If sName <> "" AndAlso sName <> "他" Then
                    Dim item As New SyainItem With {.Code = sCode, .Name = sName}
                    If Not sName.Contains("(") AndAlso Not sName.Contains("神奈川") AndAlso Not sName.Contains("他") Then
                        CmbSyain.Items.Add(item)
                    Else
                        deferredList.Add(item)
                    End If
                End If
            Next
            For Each item As SyainItem In deferredList
                CmbSyain.Items.Add(item)
            Next
        Catch
        End Try

        If mode = 1 Then
            ' 新規追加モード
            Me.Text = "メンテナンス記録の追加"
            LblID.Text = "新規追加"
            LblSakusei.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            LblSyainCD.Text = ""
            CmbSyain.SelectedIndex = -1
            CmbBunrui.Text = "修理"
            TxtSagyou.Text = DateTime.Now.ToString("yyyy/MM/dd")
            TxtSagyouTime.Text = DateTime.Now.ToString("HH:mm")
            TxtKijitsu.Text = DateTime.Now.ToString("yyyy/MM/dd")
            txtNaiyou.Text = ""
            ChkKanryou.Checked = True
            inmVisit.Value = 0
            CmdUpdate.Text = "追加(&A)"
            CmdDelete.Visible = False
        Else
            ' 編集モード
            Me.Text = "メンテナンス記録の編集"
            CmdUpdate.Text = "更新(&U)"
            CmdDelete.Visible = True

            Try
                Dim sql As String =
                    "SELECT メンテナンス記録.ID, 作成日, コード, メンテナンス記録.社員コード, 社員マスター.社員名, " &
                    "分類, 作業日, 内容, 期日, 完了, 訪問 " &
                    "FROM メンテナンス記録 LEFT JOIN 社員マスター ON メンテナンス記録.社員コード = 社員マスター.社員コード " &
                    "WHERE メンテナンス記録.ID = " & cd.ToString() & " AND 削除 = False"
                Dim dtMnt As DataTable = QueryDataTable(sql, CnMntMdb)
                If dtMnt.Rows.Count > 0 Then
                    Dim r As DataRow = dtMnt.Rows(0)
                    LblID.Text = NulCut(r("ID"))
                    LblSakusei.Text = MakeDateString(r("作成日"), StlYMDHMS)
                    LblUsrCd.Text = NulCut(r("コード"))
                    Dim syainCd As String = TrimX(NulCut(r("社員コード")))
                    LblSyainCD.Text = syainCd

                    For i As Integer = 0 To CmbSyain.Items.Count - 1
                        Dim si As SyainItem = TryCast(CmbSyain.Items(i), SyainItem)
                        If si IsNot Nothing AndAlso si.Code = syainCd Then
                            CmbSyain.SelectedIndex = i
                            Exit For
                        End If
                    Next

                    CmbBunrui.Text = NulCut(r("分類"))
                    If NulCut(r("作業日")) <> "" Then
                        TxtSagyou.Text = MakeDateString(r("作業日"), StlYMD)
                        TxtSagyouTime.Text = MakeDateString(r("作業日"), StlHM)
                    Else
                        TxtSagyou.Text = ""
                        TxtSagyouTime.Text = ""
                    End If
                    txtNaiyou.Text = NulCut(r("内容"))
                    TxtKijitsu.Text = MakeDateString(r("期日"), StlYMD)
                    ChkKanryou.Checked = NulCutBool(r("完了"))
                    Dim vCnt As Integer = CInt(NulCutN(r("訪問")))
                    If vCnt < inmVisit.Minimum Then vCnt = CInt(inmVisit.Minimum)
                    If vCnt > inmVisit.Maximum Then vCnt = CInt(inmVisit.Maximum)
                    inmVisit.Value = vCnt
                End If
            Catch ex As Exception
                MessageBox.Show("メンテナンス記録の取得に失敗しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If

        If ModeDbLocation = CnModeLocal Then
            CmdUpdate.Enabled = False
            CmdDelete.Enabled = False
            lblStatusGuide.Text = "※ローカルモードでは追加・更新・削除はできません"
        Else
            CmdUpdate.Enabled = True
            CmdDelete.Enabled = True
        End If

        SaveInitialSnapshot()
    End Sub

    Private Sub SaveInitialSnapshot()
        hznTxtSagyou = TxtSagyou.Text
        hznTxtSagyouTime = TxtSagyouTime.Text
        hznTxtKijitsu = TxtKijitsu.Text
        hznCmbBunrui = CmbBunrui.Text
        hznTxtNaiyou = txtNaiyou.Text
        hznLblSyainCD = LblSyainCD.Text
        hznChkKanryou = ChkKanryou.Checked
        hznInmVisit = CInt(inmVisit.Value)
    End Sub

    Private Function IsDirty() As Boolean
        If hznTxtSagyou <> TxtSagyou.Text Then Return True
        If hznTxtSagyouTime <> TxtSagyouTime.Text Then Return True
        If hznTxtKijitsu <> TxtKijitsu.Text Then Return True
        If hznCmbBunrui <> CmbBunrui.Text Then Return True
        If hznTxtNaiyou <> txtNaiyou.Text Then Return True
        If hznLblSyainCD <> LblSyainCD.Text Then Return True
        If hznChkKanryou <> ChkKanryou.Checked Then Return True
        If hznInmVisit <> CInt(inmVisit.Value) Then Return True
        Return False
    End Function

    Private Sub CmbSyain_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSyain.SelectedIndexChanged
        Dim si As SyainItem = TryCast(CmbSyain.SelectedItem, SyainItem)
        If si IsNot Nothing Then
            LblSyainCD.Text = si.Code
        End If
    End Sub

    Private Sub CmdOnaji_Click(sender As Object, e As EventArgs) Handles CmdOnaji.Click
        TxtKijitsu.Text = TxtSagyou.Text
    End Sub

    Private Sub CmdKongetsu_Click(sender As Object, e As EventArgs) Handles CmdKongetsu.Click
        TxtKijitsu.Text = GetEndDay(DateTime.Now.ToString("yyyy/MM"))
    End Sub

    Private Sub CmdRaigetsu_Click(sender As Object, e As EventArgs) Handles CmdRaigetsu.Click
        TxtKijitsu.Text = GetEndDay(DateTime.Now.AddMonths(1).ToString("yyyy/MM"))
    End Sub

    Private Function BuildOldMacBlock() As String
        Dim sb As New StringBuilder()
        Try
            Dim sql As String = "SELECT 前本体機種名, 前プリンター機種名, 前画面機種名, 前BCR機種名, 前HDD機種名, 前小型プリンター機種名 FROM ユーザーデータ WHERE コード = " & GetUcdSql(LblUsrCd.Text)
            Dim dt As DataTable = QueryDataTable(sql, CnMplMdb)
            If dt.Rows.Count > 0 Then
                Dim r As DataRow = dt.Rows(0)
                sb.AppendLine("----------------前使用機器----------------")
                sb.AppendLine("・前本体：" & NulCut(r("前本体機種名")))
                sb.AppendLine("・前画面：" & NulCut(r("前画面機種名")))
                sb.AppendLine("・前プリンタ：" & NulCut(r("前プリンター機種名")))
                sb.AppendLine("・前小型：" & NulCut(r("前小型プリンター機種名")))
                sb.AppendLine("・前BCR：" & NulCut(r("前BCR機種名")))
                sb.AppendLine("・前Backup：" & NulCut(r("前HDD機種名")))
                sb.AppendLine("------------------------------------------")
            End If
        Catch
        End Try
        Return sb.ToString()
    End Function

    Private Sub InsertTextAtCursor(ByVal insText As String)
        If String.IsNullOrEmpty(insText) Then Return
        Dim p As Integer = txtNaiyou.SelectionStart
        If p < 0 OrElse p > txtNaiyou.TextLength Then p = txtNaiyou.TextLength
        Dim s0 As String = txtNaiyou.Text.Substring(0, p)
        Dim s1 As String = txtNaiyou.Text.Substring(p)
        If s0.Length > 0 AndAlso Not s0.EndsWith(Environment.NewLine) Then
            s0 &= Environment.NewLine
        End If
        Dim combined As String = s0 & insText
        Dim newCaret As Integer = combined.Length
        txtNaiyou.Text = combined & s1
        txtNaiyou.SelectionStart = newCaret
        txtNaiyou.Focus()
    End Sub

    Private Sub cmdNouhinTmp_Click(sender As Object, e As EventArgs) Handles cmdNouhinTmp.Click
        Dim sb As New StringBuilder()
        Dim tplFile As String = "\\Nas001\ud4data\納品時テンプレ.txt"
        If File.Exists(tplFile) Then
            Try
                Dim lines() As String = File.ReadAllLines(tplFile, Encoding.GetEncoding(932))
                For Each line As String In lines
                    sb.AppendLine(line)
                Next
            Catch
            End Try
        End If
        sb.Append(BuildOldMacBlock())
        InsertTextAtCursor(sb.ToString())
    End Sub

    Private Sub cmdOldMac_Click(sender As Object, e As EventArgs) Handles cmdOldMac.Click
        InsertTextAtCursor(BuildOldMacBlock())
    End Sub

    Private Sub cmdCopy_Click(sender As Object, e As EventArgs) Handles cmdCopy.Click
        If Not String.IsNullOrEmpty(txtNaiyou.Text) Then
            Clipboard.SetText(txtNaiyou.Text)
            lblStatusGuide.Text = "内容をクリップボードにコピーしました"
        End If
    End Sub

    Private Sub CmdDelete_Click(sender As Object, e As EventArgs) Handles CmdDelete.Click
        If ModeDbLocation = CnModeLocal Then
            MessageBox.Show("ローカルモードでは無効です", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If UpMode <> 2 OrElse TargetId <= 0 Then Return

        If MessageBox.Show("表示中のメンテナンスデータを削除します", "データの削除", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) <> DialogResult.OK Then
            Return
        End If

        Try
            If CnMntMdb.State <> ConnectionState.Open Then CnMntMdb.Open()
            Dim sql As String = "UPDATE メンテナンス記録 SET 削除 = True, DeleteDate = ?, DeleteUser = ? WHERE ID = ?"
            Using cmd As New OleDbCommand(sql, CnMntMdb)
                cmd.Parameters.Add("DeleteDate", OleDbType.Date).Value = DateTime.Now
                cmd.Parameters.Add("DeleteUser", OleDbType.VarWChar).Value = GetPcName()
                cmd.Parameters.Add("ID", OleDbType.Integer).Value = CInt(TargetId)
                cmd.ExecuteNonQuery()
            End Using
            SavedRecordId = 0
            SaveInitialSnapshot()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("削除中にエラーが発生しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub CmdUpdate_Click(sender As Object, e As EventArgs) Handles CmdUpdate.Click
        If ModeDbLocation = CnModeLocal Then
            MessageBox.Show("ローカルモードでは無効です", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' 入力チェック
        If String.IsNullOrWhiteSpace(LblSyainCD.Text) Then
            MessageBox.Show("社員名を選択してください", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CmbSyain.Focus()
            Return
        End If

        Dim sagyouDt As DateTime
        Dim sagyouStr As String = TrimX(TxtSagyou.Text) & " " & TrimX(TxtSagyouTime.Text)
        If Not DateTime.TryParse(sagyouStr, sagyouDt) Then
            MessageBox.Show("作業日・時刻を正しく入力してください", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtSagyou.Focus()
            Return
        End If

        Dim kijitsuDt As DateTime
        If Not DateTime.TryParse(TrimX(TxtKijitsu.Text), kijitsuDt) Then
            MessageBox.Show("期日を正しく入力してください", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtKijitsu.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(CmbBunrui.Text) Then
            MessageBox.Show("分類を選択または入力してください", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            CmbBunrui.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNaiyou.Text) Then
            MessageBox.Show("内容を入力してください", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNaiyou.Focus()
            Return
        End If

        Try
            If CnMntMdb.State <> ConnectionState.Open Then CnMntMdb.Open()
            Dim nowDt As DateTime = DateTime.Now
            Dim pcName As String = GetPcName()
            Dim syainCdInt As Integer = CInt(Val(LblSyainCD.Text))

            If UpMode = 1 Then
                Dim sakuseiDt As DateTime = nowDt
                DateTime.TryParse(LblSakusei.Text, sakuseiDt)

                Dim sqlIns As String =
                    "INSERT INTO メンテナンス記録 ([作成日], [コード], [社員コード], [分類], [作業日], [内容], [期日], [完了], [削除], [訪問], [CreateDate], [CreateUser]) " &
                    "VALUES (?, ?, ?, ?, ?, ?, ?, ?, False, ?, ?, ?)"
                Using cmd As New OleDbCommand(sqlIns, CnMntMdb)
                    cmd.Parameters.Add("作成日", OleDbType.Date).Value = sakuseiDt
                    cmd.Parameters.Add("コード", OleDbType.VarWChar).Value = GetNumAlp(LblUsrCd.Text)
                    cmd.Parameters.Add("社員コード", OleDbType.Integer).Value = syainCdInt
                    cmd.Parameters.Add("分類", OleDbType.VarWChar).Value = TrimX(CmbBunrui.Text)
                    cmd.Parameters.Add("作業日", OleDbType.Date).Value = sagyouDt
                    cmd.Parameters.Add("内容", OleDbType.LongVarWChar).Value = txtNaiyou.Text
                    cmd.Parameters.Add("期日", OleDbType.Date).Value = kijitsuDt.Date
                    cmd.Parameters.Add("完了", OleDbType.Boolean).Value = ChkKanryou.Checked
                    cmd.Parameters.Add("訪問", OleDbType.Integer).Value = CInt(inmVisit.Value)
                    cmd.Parameters.Add("CreateDate", OleDbType.Date).Value = nowDt
                    cmd.Parameters.Add("CreateUser", OleDbType.VarWChar).Value = pcName
                    cmd.ExecuteNonQuery()
                End Using

                Using cmdId As New OleDbCommand("SELECT @@IDENTITY", CnMntMdb)
                    Dim objId As Object = cmdId.ExecuteScalar()
                    SavedRecordId = NulCutN(objId)
                End Using
            Else
                Dim sqlUpd As String =
                    "UPDATE メンテナンス記録 SET [社員コード] = ?, [分類] = ?, [作業日] = ?, [内容] = ?, [期日] = ?, [完了] = ?, [訪問] = ?, [LastEditDate] = ?, [LastEditUser] = ? " &
                    "WHERE [ID] = ?"
                Using cmd As New OleDbCommand(sqlUpd, CnMntMdb)
                    cmd.Parameters.Add("社員コード", OleDbType.Integer).Value = syainCdInt
                    cmd.Parameters.Add("分類", OleDbType.VarWChar).Value = TrimX(CmbBunrui.Text)
                    cmd.Parameters.Add("作業日", OleDbType.Date).Value = sagyouDt
                    cmd.Parameters.Add("内容", OleDbType.LongVarWChar).Value = txtNaiyou.Text
                    cmd.Parameters.Add("期日", OleDbType.Date).Value = kijitsuDt.Date
                    cmd.Parameters.Add("完了", OleDbType.Boolean).Value = ChkKanryou.Checked
                    cmd.Parameters.Add("訪問", OleDbType.Integer).Value = CInt(inmVisit.Value)
                    cmd.Parameters.Add("LastEditDate", OleDbType.Date).Value = nowDt
                    cmd.Parameters.Add("LastEditUser", OleDbType.VarWChar).Value = pcName
                    cmd.Parameters.Add("ID", OleDbType.Integer).Value = CInt(TargetId)
                    cmd.ExecuteNonQuery()
                End Using
                SavedRecordId = TargetId
            End If

            SaveInitialSnapshot()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("保存中にエラーが発生しました: " & ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmMntEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Me.DialogResult <> DialogResult.OK AndAlso IsDirty() Then
            If MessageBox.Show("データが更新されていますが、保存せずに終了してもいいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) = DialogResult.Cancel Then
                e.Cancel = True
            End If
        End If
    End Sub
End Class
