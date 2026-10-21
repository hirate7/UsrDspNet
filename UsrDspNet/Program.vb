Imports System.Threading
Imports System.Windows.Forms

Public Module Program
    Private appMutex As Mutex

    <STAThread()>
    Public Sub Main()
        Dim createdNew As Boolean = False
        appMutex = New Mutex(True, "UsrDspNet_SingleInstance_Mutex", createdNew)
        If Not createdNew Then
            MessageBox.Show("すでにユーザー検索（UsrDspNet）が起動しています。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        fMainForm = New FrmMain()
        Application.Run(fMainForm)

        GC.KeepAlive(appMutex)
    End Sub
End Module
