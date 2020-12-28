Imports System.IO
Module entrypoint

    Sub Main(ByVal args As String())
        Application.SetCompatibleTextRenderingDefault(True)

        If File.Exists(Application.StartupPath & "\NAudio.dll") Then
            MessageBox.Show("There ", "RingLightApp downloading...", Nothing, Nothing)
        Else
            Dim app As appFramework
            app = New appFramework(RingLight)
            app.Run(args)
        End If
    End Sub

End Module

Public Class appFramework
    Inherits ApplicationServices.WindowsFormsApplicationBase

    Public Sub New(ByVal main As Form)
        MyBase.New(ApplicationServices.AuthenticationMode.Windows)
        Me.EnableVisualStyles = True
        'Me.IsSingleInstance = True
        Me.ShutdownStyle = ApplicationServices.ShutdownMode.AfterAllFormsClose
        Me.MainForm = main

    End Sub

    'Protected Overrides Sub OnStartupNextInstance(ByVal eventArgs As ApplicationServices.StartupNextInstanceEventArgs)
    '    MyBase.OnStartupNextInstance(eventArgs)
    '    MessageBox.Show("Application is alrealy running.", "Coinapp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    'End Sub

End Class
