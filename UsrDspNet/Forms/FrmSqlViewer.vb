Imports System.Data
Imports System.Windows.Forms

Public Class FrmSqlViewer
    Public Sub LoadData(ByVal dt As DataTable)
        dgvList.Columns.Clear()
        dgvList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "No", .HeaderText = "No.", .Width = 55})
        dgvList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "コード", .HeaderText = "コード", .Width = 75})
        dgvList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "分院Version", .HeaderText = "Version", .Width = 140})
        dgvList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "支部名", .HeaderText = "支部名", .Width = 95})
        dgvList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "施術所名", .HeaderText = "施術所名", .Width = 175})
        dgvList.Columns.Add(New DataGridViewTextBoxColumn With {.Name = "柔整師名", .HeaderText = "柔整師名", .Width = 110})

        dgvList.Rows.Clear()
        If dt IsNot Nothing Then
            Dim idx As Integer = 0
            For Each r As DataRow In dt.Rows
                idx += 1
                dgvList.Rows.Add(
                    idx.ToString(),
                    NulCut(r("コード")),
                    NulCut(r("分院Version")),
                    NulCut(r("支部名")),
                    NulCut(r("施術所名")),
                    NulCut(r("柔整師名"))
                )
            Next
        End If
        lblCount.Text = $"対象件数: {dgvList.Rows.Count:#,##0} 件"
    End Sub

    Private Sub cmdClose_Click(sender As Object, e As EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        If e.RowIndex < 0 OrElse e.RowIndex >= dgvList.Rows.Count Then Return
        Dim cd As String = NulCut(dgvList.Rows(e.RowIndex).Cells("コード").Value)
        If cd <> "" AndAlso fMainForm IsNot Nothing Then
            fMainForm.DisplayUserByCode(cd, True)
        End If
    End Sub
End Class
