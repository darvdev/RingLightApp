<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RingLight
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RingLight))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.combobox_audio = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.combobox_device_port = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.combobox_device_baud = New System.Windows.Forms.ComboBox()
        Me.button_start = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.numeric_pin = New System.Windows.Forms.NumericUpDown()
        Me.numeric_led = New System.Windows.Forms.NumericUpDown()
        Me.numeric_brightness = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.combobox_light_effect = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.progressbar_audio = New System.Windows.Forms.ProgressBar()
        Me.checkbox_hide = New System.Windows.Forms.CheckBox()
        Me.checkbox_sounds = New System.Windows.Forms.CheckBox()
        Me.trackbar_trigger = New System.Windows.Forms.TrackBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numeric_delay = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numeric_skip = New System.Windows.Forms.NumericUpDown()
        Me.numeric_play = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numeric_pin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numeric_led, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numeric_brightness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackbar_trigger, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numeric_delay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numeric_skip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numeric_play, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 219)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Audio Device"
        '
        'combobox_audio
        '
        Me.combobox_audio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combobox_audio.FormattingEnabled = True
        Me.combobox_audio.Location = New System.Drawing.Point(23, 235)
        Me.combobox_audio.Name = "combobox_audio"
        Me.combobox_audio.Size = New System.Drawing.Size(235, 21)
        Me.combobox_audio.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Device Port"
        '
        'combobox_device_port
        '
        Me.combobox_device_port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combobox_device_port.FormattingEnabled = True
        Me.combobox_device_port.Location = New System.Drawing.Point(115, 27)
        Me.combobox_device_port.Name = "combobox_device_port"
        Me.combobox_device_port.Size = New System.Drawing.Size(104, 21)
        Me.combobox_device_port.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Device Baud Rate"
        '
        'combobox_device_baud
        '
        Me.combobox_device_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combobox_device_baud.FormattingEnabled = True
        Me.combobox_device_baud.Items.AddRange(New Object() {"9600", "19200", "38400", "57600", "115200"})
        Me.combobox_device_baud.Location = New System.Drawing.Point(115, 54)
        Me.combobox_device_baud.Name = "combobox_device_baud"
        Me.combobox_device_baud.Size = New System.Drawing.Size(104, 21)
        Me.combobox_device_baud.TabIndex = 1
        '
        'button_start
        '
        Me.button_start.Location = New System.Drawing.Point(23, 415)
        Me.button_start.Name = "button_start"
        Me.button_start.Size = New System.Drawing.Size(235, 34)
        Me.button_start.TabIndex = 2
        Me.button_start.Text = "Start Ring Light"
        Me.button_start.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numeric_pin)
        Me.GroupBox1.Controls.Add(Me.numeric_led)
        Me.GroupBox1.Controls.Add(Me.numeric_brightness)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.combobox_light_effect)
        Me.GroupBox1.Controls.Add(Me.combobox_device_baud)
        Me.GroupBox1.Controls.Add(Me.combobox_device_port)
        Me.GroupBox1.Location = New System.Drawing.Point(23, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(235, 197)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ring Light Device"
        '
        'numeric_pin
        '
        Me.numeric_pin.Enabled = False
        Me.numeric_pin.Location = New System.Drawing.Point(115, 81)
        Me.numeric_pin.Maximum = New Decimal(New Integer() {13, 0, 0, 0})
        Me.numeric_pin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numeric_pin.Name = "numeric_pin"
        Me.numeric_pin.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.numeric_pin.Size = New System.Drawing.Size(104, 20)
        Me.numeric_pin.TabIndex = 2
        Me.numeric_pin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numeric_pin.Value = New Decimal(New Integer() {6, 0, 0, 0})
        '
        'numeric_led
        '
        Me.numeric_led.Enabled = False
        Me.numeric_led.Location = New System.Drawing.Point(114, 107)
        Me.numeric_led.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numeric_led.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numeric_led.Name = "numeric_led"
        Me.numeric_led.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.numeric_led.Size = New System.Drawing.Size(104, 20)
        Me.numeric_led.TabIndex = 2
        Me.numeric_led.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numeric_led.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'numeric_brightness
        '
        Me.numeric_brightness.Location = New System.Drawing.Point(114, 160)
        Me.numeric_brightness.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.numeric_brightness.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numeric_brightness.Name = "numeric_brightness"
        Me.numeric_brightness.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.numeric_brightness.Size = New System.Drawing.Size(104, 20)
        Me.numeric_brightness.TabIndex = 2
        Me.numeric_brightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numeric_brightness.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Light Effects"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 83)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Device Pin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Number of LED"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 162)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "LED Brightness "
        '
        'combobox_light_effect
        '
        Me.combobox_light_effect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combobox_light_effect.FormattingEnabled = True
        Me.combobox_light_effect.Items.AddRange(New Object() {"Rainbow", "Theatre Chase"})
        Me.combobox_light_effect.Location = New System.Drawing.Point(114, 133)
        Me.combobox_light_effect.Name = "combobox_light_effect"
        Me.combobox_light_effect.Size = New System.Drawing.Size(104, 21)
        Me.combobox_light_effect.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 459)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(284, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'progressbar_audio
        '
        Me.progressbar_audio.Location = New System.Drawing.Point(23, 262)
        Me.progressbar_audio.Name = "progressbar_audio"
        Me.progressbar_audio.Size = New System.Drawing.Size(235, 11)
        Me.progressbar_audio.TabIndex = 5
        '
        'checkbox_hide
        '
        Me.checkbox_hide.AutoSize = True
        Me.checkbox_hide.Location = New System.Drawing.Point(23, 387)
        Me.checkbox_hide.Name = "checkbox_hide"
        Me.checkbox_hide.Size = New System.Drawing.Size(88, 17)
        Me.checkbox_hide.TabIndex = 6
        Me.checkbox_hide.Text = "Hide on Start"
        Me.checkbox_hide.UseVisualStyleBackColor = True
        '
        'checkbox_sounds
        '
        Me.checkbox_sounds.AutoSize = True
        Me.checkbox_sounds.Enabled = False
        Me.checkbox_sounds.Location = New System.Drawing.Point(122, 387)
        Me.checkbox_sounds.Name = "checkbox_sounds"
        Me.checkbox_sounds.Size = New System.Drawing.Size(132, 17)
        Me.checkbox_sounds.TabIndex = 6
        Me.checkbox_sounds.Text = "Disable System Sound"
        Me.checkbox_sounds.UseVisualStyleBackColor = True
        '
        'trackbar_trigger
        '
        Me.trackbar_trigger.AutoSize = False
        Me.trackbar_trigger.LargeChange = 1
        Me.trackbar_trigger.Location = New System.Drawing.Point(16, 275)
        Me.trackbar_trigger.Maximum = 100
        Me.trackbar_trigger.Minimum = 1
        Me.trackbar_trigger.Name = "trackbar_trigger"
        Me.trackbar_trigger.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.trackbar_trigger.Size = New System.Drawing.Size(250, 20)
        Me.trackbar_trigger.TabIndex = 7
        Me.trackbar_trigger.TickStyle = System.Windows.Forms.TickStyle.None
        Me.trackbar_trigger.Value = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(20, 300)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(154, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Sounds stop delay (millisecond)"
        '
        'numeric_delay
        '
        Me.numeric_delay.Increment = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numeric_delay.Location = New System.Drawing.Point(185, 298)
        Me.numeric_delay.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numeric_delay.Name = "numeric_delay"
        Me.numeric_delay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.numeric_delay.Size = New System.Drawing.Size(73, 20)
        Me.numeric_delay.TabIndex = 2
        Me.numeric_delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(20, 352)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Sounds skip to start again"
        '
        'numeric_skip
        '
        Me.numeric_skip.Location = New System.Drawing.Point(185, 350)
        Me.numeric_skip.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numeric_skip.Name = "numeric_skip"
        Me.numeric_skip.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.numeric_skip.Size = New System.Drawing.Size(73, 20)
        Me.numeric_skip.TabIndex = 2
        Me.numeric_skip.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numeric_play
        '
        Me.numeric_play.Location = New System.Drawing.Point(185, 324)
        Me.numeric_play.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numeric_play.Name = "numeric_play"
        Me.numeric_play.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.numeric_play.Size = New System.Drawing.Size(73, 20)
        Me.numeric_play.TabIndex = 2
        Me.numeric_play.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(20, 326)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Sounds to play LED lights"
        '
        'RingLight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 481)
        Me.Controls.Add(Me.trackbar_trigger)
        Me.Controls.Add(Me.checkbox_sounds)
        Me.Controls.Add(Me.numeric_play)
        Me.Controls.Add(Me.numeric_skip)
        Me.Controls.Add(Me.numeric_delay)
        Me.Controls.Add(Me.checkbox_hide)
        Me.Controls.Add(Me.progressbar_audio)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.button_start)
        Me.Controls.Add(Me.combobox_audio)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(300, 520)
        Me.MinimumSize = New System.Drawing.Size(300, 450)
        Me.Name = "RingLight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numeric_pin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numeric_led, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numeric_brightness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackbar_trigger, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numeric_delay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numeric_skip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numeric_play, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents combobox_audio As ComboBox
    Friend WithEvents combobox_device_port As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents combobox_device_baud As ComboBox
    Friend WithEvents button_start As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents numeric_brightness As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents combobox_light_effect As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents progressbar_audio As ProgressBar
    Friend WithEvents numeric_led As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents numeric_pin As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents checkbox_hide As CheckBox
    Friend WithEvents checkbox_sounds As CheckBox
    Friend WithEvents trackbar_trigger As TrackBar
    Friend WithEvents Label8 As Label
    Friend WithEvents numeric_delay As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents numeric_skip As NumericUpDown
    Friend WithEvents numeric_play As NumericUpDown
    Friend WithEvents Label10 As Label
End Class
