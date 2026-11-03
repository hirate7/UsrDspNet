Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Forms

Public Module Program
    Private appMutex As Mutex

    <DllImport("shell32.dll", SetLastError:=True)>
    Private Function SetCurrentProcessExplicitAppUserModelID(<MarshalAs(UnmanagedType.LPWStr)> ByVal AppID As String) As Integer
    End Function

    <STAThread()>
    Public Sub Main()
        Try
            SetCurrentProcessExplicitAppUserModelID("Maple.UsrDspNet.App.1")
        Catch
        End Try

        Dim allowMulti As Boolean = False
        Try
            Dim s As String = Microsoft.VisualBasic.Interaction.GetSetting(AppTitleReg, "Options", "AllowMultiInstance", "False")
            If Not Boolean.TryParse(s, allowMulti) OrElse Not allowMulti Then
                Dim s2 As String = Microsoft.VisualBasic.Interaction.GetSetting("UsrDspNet", "Options", "AllowMultiInstance", "False")
                Boolean.TryParse(s2, allowMulti)
            End If
        Catch
        End Try

        Dim createdNew As Boolean = False
        appMutex = New Mutex(True, "UsrDspNet_SingleInstance_Mutex", createdNew)
        If Not createdNew Then
            If allowMulti Then
                IsSecondaryInstance = True
            Else
                MessageBox.Show("すでにユーザー検索（UsrDspNet）が起動しています。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
        End If

        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        fMainForm = New FrmMain()
        Application.Run(fMainForm)

        GC.KeepAlive(appMutex)
    End Sub
End Module
