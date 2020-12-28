
Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports NAudio.CoreAudioApi

Public Class RingLight

    Dim devices As MMDeviceCollection
    Dim enumerator As MMDeviceEnumerator
    Dim toggle As Boolean
    Dim trigger As Boolean
    Dim deviceIsReady As Boolean
    Dim working As Boolean
    Dim hidden As Boolean
    Dim started As Boolean
    Dim labelStatus As ToolStripStatusLabel
    Dim cfg As New config

    Dim muted As Boolean
    Dim pDevice As Integer = -1
    Dim track As Integer = 1
    Dim br As Integer
    Dim fx As Integer = -1
    Dim vs As String
    Dim deviceid As String
    Dim delay_time As Integer = 0
    Dim skip_sound As Integer = 0
    Dim play_sound As Integer = 0

    Private WithEvents device As MMDevice
    Private WithEvents notifyIcon As NotifyIcon
    Private Delegate Sub MyDelegate()
    Private WithEvents worker As BackgroundWorker
    Private WithEvents sound_timer As Timers.Timer
    Private WithEvents delay_timer As Timers.Timer
    Public WithEvents comPort As SerialPort

    Private Const SWP_NOSIZE As Integer = &H1
    Private Const SWP_NOMOVE As Integer = &H2
    Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Private Shared ReadOnly HWND_NOTOPMOST As New IntPtr(-2)

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As Integer) As Boolean
    End Function

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        If e.CloseReason = CloseReason.UserClosing Then
            If working = True OrElse started = True Then
                e.Cancel = True
                MsgBox("Stop any operation")
            End If
        End If
        MyBase.OnFormClosing(e)
    End Sub

    Private Sub RingLightController_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Ring Light App v" & Application.ProductVersion

        labelStatus = New ToolStripStatusLabel
        StatusStrip1.Items.Add(labelStatus)
        labelStatus.Text = "©VinStudios | http://facebook.com/VinStudiosFX"

        If File.Exists(Application.StartupPath & "\" & config.fxFile) Then
            Dim root As XElement = Nothing
            Try
                root = XDocument.Load(Application.StartupPath & "\" & config.fxFile).Root
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            If root IsNot Nothing Then
                If root.<effect>.Count <> 0 Then
                    combobox_light_effect.Items.Clear()
                    For i As Integer = 0 To root.<effect>.Count - 1
                        combobox_light_effect.Items.Add(root.<effect>(i).<name>.Value)
                    Next
                End If
            End If
        End If

        combobox_device_port.Items.AddRange(SerialPort.GetPortNames)

        If File.Exists(Application.StartupPath & "\" & config.configFile) Then

            Dim port As String = config.Read("port", "COM1")
            If combobox_device_port.Items.Contains(port) Then
                combobox_device_port.SelectedItem = port
            Else
                combobox_device_port.SelectedIndex = 0
                config.Write("port", "COM1")
            End If

            Dim baud As String = config.Read("baud", "9600")
            If combobox_device_baud.Items.Contains(baud) Then
                combobox_device_baud.SelectedItem = baud
            Else
                combobox_device_baud.SelectedIndex = 0
                config.Write("baud", "9600")
            End If

            Dim effect As Integer
            If Integer.TryParse(config.Read("effect", "0"), effect) Then
                If effect > combobox_light_effect.Items.Count - 1 Then
                    combobox_light_effect.SelectedIndex = 0
                Else
                    combobox_light_effect.SelectedIndex = effect
                End If
            Else
                combobox_light_effect.SelectedIndex = 0
            End If

            Dim bright As Integer
            If Integer.TryParse(config.Read("bright", "1"), bright) Then
                Select Case bright
                    Case < 1
                        numeric_brightness.Value = 1
                        config.Write("bright", "1")
                    Case > 255
                        numeric_brightness.Value = 255
                        config.Write("bright", "255")
                    Case Else
                        numeric_brightness.Value = bright
                End Select
            End If

            Dim trig As Integer
            If Integer.TryParse(config.Read("trig", "1"), trig) Then
                Select Case trig
                    Case < 1
                        trackbar_trigger.Value = 1
                        config.Write("trig", "1")
                    Case > 100
                        trackbar_trigger.Value = 100
                        config.Write("trig", "100")
                    Case Else
                        trackbar_trigger.Value = trig
                End Select
            End If

            Dim delay As Integer
            If Integer.TryParse(config.Read("delay", "0"), delay) Then
                Select Case delay
                    Case < 0
                        numeric_delay.Value = 0
                        config.Write("delay", "0")
                    Case > 10000
                        numeric_delay.Value = 10000
                        config.Write("delay", "10000")
                    Case Else
                        numeric_delay.Value = delay
                End Select
            End If

            Dim play As Integer
            If Integer.TryParse(config.Read("play", "0"), play) Then
                Select Case play
                    Case < 0
                        numeric_play.Value = 0
                        config.Write("play", "0")
                    Case > 10
                        numeric_play.Value = 10
                        config.Write("play", "10")
                    Case Else
                        numeric_play.Value = play
                End Select
            End If

            Dim skip As Integer
            If Integer.TryParse(config.Read("skip", "0"), skip) Then
                Select Case skip
                    Case < 0
                        numeric_skip.Value = 0
                        config.Write("skip", "0")
                    Case > 10
                        numeric_skip.Value = 10
                        config.Write("skip", "10")
                    Case Else
                        numeric_skip.Value = skip
                End Select
            End If

            Dim hide As Integer
            If Integer.TryParse(config.Read("hide", "0"), hide) Then
                If hide > 0 Then
                    checkbox_hide.Checked = True
                Else
                    config.Write("hide", "0")
                End If
            End If

        Else
            combobox_device_port.SelectedIndex = 0
            combobox_device_baud.SelectedIndex = 0
            combobox_light_effect.SelectedIndex = 0
        End If

        enumerator = New MMDeviceEnumerator()
        devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)

        combobox_audio.Items.AddRange(devices.ToArray)
        If Not combobox_audio.Items.Count = 0 Then
            device = devices.Item(0)
            pDevice = 0
            muted = device.AudioEndpointVolume.Mute
            AddHandler device.AudioEndpointVolume.OnVolumeNotification, AddressOf VolumeNotify
        Else
            combobox_audio.Items.Add("No active audio devices")
        End If
        combobox_audio.SelectedIndex = 0

        sound_timer = New Timers.Timer(10)
        If device IsNot Nothing Then
            sound_timer.Start()
        End If

        notifyIcon = New NotifyIcon
        notifyIcon.Icon = My.Resources.RingLight

    End Sub

    Private Sub VolumeNotify()
        muted = device.AudioEndpointVolume.Mute
    End Sub

    Private Sub notifyIcon_DoubleClick(sender As Object, e As MouseEventArgs) Handles notifyIcon.MouseDoubleClick
        If hidden = True Then
            hidden = False
            notifyIcon.Visible = False
            Me.Show()
            Me.WindowState = FormWindowState.Normal
            SetWindowPos(Me.Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
            SetWindowPos(Me.Handle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
        End If
    End Sub

    Private Sub cNotifyIcon_MouseMove(sender As Object, e As MouseEventArgs) Handles notifyIcon.MouseMove
        notifyIcon.Text = "Ring Light App v" & Application.ProductVersion
    End Sub

    Private Sub sound_timer_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles sound_timer.Elapsed

        If Me.IsHandleCreated Then
            If muted = False Then
                Me.BeginInvoke(New MyDelegate(Sub() progressbar_audio.Value = device.AudioMeterInformation.MasterPeakValue * (device.AudioEndpointVolume.MasterVolumeLevelScalar * 100) + 0.5))
            Else
                Me.BeginInvoke(New MyDelegate(Sub() progressbar_audio.Value = 0))
            End If
        End If

        If started = True Then
            If progressbar_audio.Value >= track Then
                toggle = True
            Else
                toggle = False
            End If

            If comPort.IsOpen() Then
                If toggle = True Then
                    If trigger = False Then
                        trigger = True

                        If numeric_play.Value <= 0 Then
                            comPort.Write("PLAY;")
                        Else
                            If play_sound <> 0 Then
                                comPort.Write("PLAY;")
                                If skip_sound <> 0 Then
                                    play_sound -= 1
                                End If
                            Else
                                skip_sound -= 1
                                If skip_sound <= 0 Then
                                    play_sound = numeric_play.Value
                                    skip_sound = numeric_skip.Value
                                End If
                            End If
                        End If
                    End If
                Else
                    If trigger = True Then
                        trigger = False
                        If numeric_delay.Value > 0 Then
                            If delay_timer IsNot Nothing AndAlso delay_timer.Enabled = False Then
                                delay_timer.Start()
                            End If
                        Else
                            comPort.Write("STOP;")
                        End If
                    End If
                End If
            End If
        End If

        'Me.BeginInvoke(New MyDelegate(Sub() labelStatus.Text = "play: " & play_sound & " skip: " & skip_sound))
        'Me.BeginInvoke(New MyDelegate(Sub() labelStatus.Text = "mute: " & muted))
    End Sub

    Private Sub delay_timer_Elapsed(sender As Object, e As Timers.ElapsedEventArgs) Handles delay_timer.Elapsed
        delay_time += 100
        If delay_time >= numeric_delay.Value Then
            delay_timer.Stop()
            delay_time = 0
            If comPort.IsOpen() Then
                comPort.Write("STOP;")
            End If
        End If
    End Sub

    Private Sub combobox_audio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combobox_audio.SelectedIndexChanged
        If device IsNot Nothing Then
            If Not (pDevice = combobox_audio.SelectedIndex) Then
                device = devices.Item(combobox_audio.SelectedIndex)
                muted = device.AudioEndpointVolume.Mute
                AddHandler device.AudioEndpointVolume.OnVolumeNotification, AddressOf VolumeNotify
            End If
        End If
    End Sub

    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs) Handles comPort.DataReceived
        Dim received As String = comPort.ReadTo(comPort.NewLine)
        If deviceIsReady Then
            If received = "BR" Then
                br = CType(comPort.ReadTo(comPort.NewLine), Integer)
            End If
            If received = "FX" Then
                fx = CType(comPort.ReadTo(comPort.NewLine), Integer)
            End If
            If received = "VS" Then
                vs = comPort.ReadTo(comPort.NewLine)
            End If
        Else
            If received = "VS_RLA" Then
                deviceid = comPort.ReadTo(comPort.NewLine)
                Dim decryptedId As String = cfg.Decrypt(deviceid & "==", "RLA")
                If Not decryptedId = "" Then
                    If decryptedId.Contains("RLA") Then
                        comPort.Write("OK;")
                    End If
                End If
            End If
            If received = "VINSTUDIOS_RLA" Then
                deviceIsReady = True
                Me.BeginInvoke(New MyDelegate(Sub() comPort.Write("FX=" & combobox_light_effect.SelectedIndex)))
                comPort.Write("BR=" & numeric_brightness.Value.ToString)
            End If
        End If
    End Sub

    Private Sub worker_DoWork(sender As Object, e As DoWorkEventArgs) Handles worker.DoWork
        working = True
        If started = False Then
            If comPort.IsOpen Then
                Thread.Sleep(3000)
                comPort.Write("VS_RLA;")
                Thread.Sleep(1000)
                If deviceIsReady = True Then
                    comPort.Write("BR?")
                    Thread.Sleep(1000)
                    comPort.Write("FX?")
                    Thread.Sleep(1000)
                    comPort.Write("VS?")
                    Thread.Sleep(1000)
                    Me.BeginInvoke(New MyDelegate(Sub() button_start.Enabled = True))
                    Me.BeginInvoke(New MyDelegate(Sub() button_start.Text = "Stop Ring Light"))
                    Me.BeginInvoke(New MyDelegate(Sub() labelStatus.Text = "Device (Version: " & vs & " | Brightness: " & br & " | Effect: " & fx & ")"))
                    started = True
                    If checkbox_hide.Checked = True Then
                        Me.BeginInvoke(New MyDelegate(Sub() Me.Hide()))
                        hidden = True
                        Me.BeginInvoke(New MyDelegate(Sub() notifyIcon.Visible = True))
                    End If
                Else
                    comPort.Close()
                    Me.BeginInvoke(New MyDelegate(Sub() MsgBox("Cannot communicate to device")))
                    Me.BeginInvoke(New MyDelegate(Sub() button_start.Enabled = True))
                    Me.BeginInvoke(New MyDelegate(Sub() ComponentStatus(True)))
                    Me.BeginInvoke(New MyDelegate(Sub() button_start.Text = "Start Ring Light"))
                    Me.BeginInvoke(New MyDelegate(Sub() labelStatus.Text = "Device not compatible. Select other device."))
                End If
            Else
                Me.BeginInvoke(New MyDelegate(Sub() button_start.Enabled = True))
                Me.BeginInvoke(New MyDelegate(Sub() ComponentStatus(True)))
                Me.BeginInvoke(New MyDelegate(Sub() button_start.Text = "Start Ring Light"))
            End If
        End If

        working = False
    End Sub

    Private Sub button_start_Click(sender As Object, e As EventArgs) Handles button_start.Click
        If started = False Then
            If comPort Is Nothing Then
                comPort = New SerialPort()
            End If

            Try
                comPort.BaudRate = CType(combobox_device_baud.Items(combobox_device_baud.SelectedIndex), Integer)
                comPort.PortName = combobox_device_port.Items(combobox_device_port.SelectedIndex)
                comPort.DtrEnable = True
                comPort.Open()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            config.Write("port", combobox_device_port.SelectedItem)
            config.Write("baud", combobox_device_baud.SelectedItem)
            config.Write("effect", combobox_light_effect.SelectedIndex)
            config.Write("bright", numeric_brightness.Value.ToString)
            config.Write("trig", trackbar_trigger.Value.ToString)
            config.Write("delay", numeric_delay.Value.ToString)
            config.Write("play", numeric_play.Value.ToString)
            config.Write("skip", numeric_skip.Value.ToString)
            config.Write("hide", If(checkbox_hide.Checked, "1", "0"))

            If numeric_delay.Value > 0 Then
                delay_timer = New Timers.Timer(100)
            End If

            If numeric_skip.Value > 0 Then
                skip_sound = numeric_skip.Value
            End If

            If numeric_play.Value > 0 Then
                play_sound = numeric_play.Value
            End If

            ComponentStatus(False)
            button_start.Enabled = False
            button_start.Text = "Starting pleas wait..."
            worker = New BackgroundWorker
            worker.RunWorkerAsync()

        Else
            If comPort.IsOpen Then
                Try
                    comPort.Write("STOP;")
                    comPort.Close()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If

            If comPort.IsOpen = False Then
                started = False
                trigger = False
                toggle = False
                vs = ""
                br = 0
                fx = -1
                deviceid = ""
                deviceIsReady = False

                If delay_timer IsNot Nothing Then
                    If delay_timer.Enabled = True Then
                        delay_timer.Stop()
                    End If
                    delay_timer.Dispose()
                End If
                delay_time = 0
                skip_sound = 0
                play_sound = 0

                If worker IsNot Nothing Then
                    worker.Dispose()
                End If
                If comPort IsNot Nothing Then
                    comPort.Dispose()
                End If

                ComponentStatus(True)
                button_start.Text = "Start Ring Light"
                labelStatus.Text = "©VinStudios | http://facebook.com/VinStudiosFX"
            End If

        End If

    End Sub

    Private Sub ComponentStatus(ByVal bool As Boolean)
        'GroupBox1.Enabled = bool
        combobox_device_port.Enabled = bool
        combobox_device_baud.Enabled = bool
        combobox_light_effect.Enabled = bool
        numeric_brightness.Enabled = bool
        combobox_audio.Enabled = bool
        progressbar_audio.Enabled = bool
        trackbar_trigger.Enabled = bool
        numeric_delay.Enabled = bool
        numeric_play.Enabled = bool
        numeric_skip.Enabled = bool
        checkbox_hide.Enabled = bool
    End Sub

    Private Sub RingLight_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            If started = True Then
                Dim dlgr As DialogResult = MessageBox.Show("Do you want to minimize to System Tray?", "Ring Light Controller", MessageBoxButtons.YesNo, MessageBoxIcon.None)
                If dlgr = DialogResult.Yes Then
                    Me.Hide()
                    hidden = True
                    notifyIcon.Visible = True
                End If
            End If
        End If
    End Sub

    Private Sub trackbar_trigger_ValueChanged(sender As Object, e As EventArgs) Handles trackbar_trigger.ValueChanged
        track = trackbar_trigger.Value
    End Sub

End Class
