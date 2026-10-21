Imports System.Data
Imports System.Windows.Forms

Public Class FindDlg
    Private prssBtn As Integer = 1
    Private Shared bfrFmode As Integer = -1

    Private Sub FindDlg_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        CmbFind.Focus()
        CmbFind.SelectAll()
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        prssBtn = 0
        CmbFind.Text = TrimX(TabCut(CmbFind.Text))
        Me.DialogResult = DialogResult.OK
        Me.Hide()
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        prssBtn = 1
        Me.DialogResult = DialogResult.Cancel
        Me.Hide()
    End Sub

    Public Sub FindInp(ByVal FMode As Integer, ByRef FTxt As String, ByRef Op As Integer)
        If Op = 0 Then
            OptPrefix.Checked = True
        Else
            OptContains.Checked = True
        End If

        Dim filterSql As String = GetDspFilterSql()

        Select Case FMode
            Case 1
                Me.Text = "名前で検索"
                CmbFind.ImeMode = ImeMode.Hiragana
                CmbFind.Items.Clear()
                CmbFind.Text = ""
            Case 4
                Me.Text = "電話番号で検索"
                CmbFind.ImeMode = ImeMode.Disable
                CmbFind.Items.Clear()
                CmbFind.Text = ""
            Case 2
                Me.Text = "支部名で検索"
                CmbFind.ImeMode = ImeMode.Hiragana
                If FMode <> bfrFmode OrElse CmbFind.Items.Count = 0 Then
                    CmbFind.Items.Clear()
                    Try
                        Dim sqlTxt As String = "SELECT コード, 支部名 FROM ユーザーデータ WHERE " & filterSql & " ORDER BY コード"
                        Dim dt As DataTable = QueryDataTable(sqlTxt, CnMplMdb)
                        Dim prevSibu As String = ""
                        Dim added As New HashSet(Of String)()
                        For Each r As DataRow In dt.Rows
                            Dim sibu As String = TrimX(NulCut(r("支部名")))
                            If sibu <> "" AndAlso sibu <> prevSibu Then
                                If Not added.Contains(sibu) Then
                                    CmbFind.Items.Add(sibu)
                                    added.Add(sibu)
                                End If
                                prevSibu = sibu
                            End If
                        Next
                    Catch
                    End Try
                End If
                CmbFind.Text = ""
            Case 8
                Me.Text = "シリアルナンバーで検索"
                CmbFind.ImeMode = ImeMode.Disable
                CmbFind.Items.Clear()
                CmbFind.Text = ""
            Case 16
                Me.Text = "製品名で検索"
                CmbFind.ImeMode = ImeMode.NoControl
                If FMode <> bfrFmode OrElse CmbFind.Items.Count = 0 Then
                    CmbFind.Items.Clear()
                    PopulateDistinctMachineItems("--- 本体 ---", "本体機種名", filterSql)
                    PopulateDistinctMachineItems("--- 画面 ---", "画面機種名", filterSql)
                    PopulateDistinctMachineItems("--- プリンター ---", "プリンター機種名", filterSql)
                    PopulateDistinctMachineItems("--- ＢＣＲ ---", "BCR機種名", filterSql)
                End If
                CmbFind.Text = ""
            Case 32
                Me.Text = "コードで検索"
                CmbFind.ImeMode = ImeMode.Disable
                CmbFind.Items.Clear()
                CmbFind.Text = ""
        End Select

        bfrFmode = FMode
        prssBtn = 1
        Me.ShowDialog()

        If prssBtn = 0 Then
            FTxt = CmbFind.Text
            If OptPrefix.Checked Then
                Op = 0
            Else
                Op = 1
            End If
        Else
            FTxt = ""
            Op = -1
        End If
    End Sub

    Private Sub PopulateDistinctMachineItems(ByVal headerText As String, ByVal colName As String, ByVal filterSql As String)
        CmbFind.Items.Add(headerText)
        Try
            Dim sqlTxt As String = $"SELECT DISTINCT [{colName}] FROM ユーザーデータ WHERE {filterSql} ORDER BY [{colName}]"
            Dim dt As DataTable = QueryDataTable(sqlTxt, CnMplMdb)
            For Each r As DataRow In dt.Rows
                Dim v As String = TrimX(NulCut(r(colName)))
                If v <> "" Then
                    CmbFind.Items.Add(v)
                End If
            Next
        Catch
        End Try
    End Sub
End Class
