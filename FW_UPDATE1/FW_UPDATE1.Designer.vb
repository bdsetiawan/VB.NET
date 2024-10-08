<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FW_UPDATE1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim MACLabel As System.Windows.Forms.Label
        Dim Label5 As System.Windows.Forms.Label
        Dim Label7 As System.Windows.Forms.Label
        Dim Label8 As System.Windows.Forms.Label
        Dim Label4 As System.Windows.Forms.Label
        Dim Label3 As System.Windows.Forms.Label
        Dim Total_Test_TimeLabel As System.Windows.Forms.Label
        Dim OperatorBadgeID As System.Windows.Forms.Label
        Dim SerialNum As System.Windows.Forms.Label
        Dim TimeLabel As System.Windows.Forms.Label
        Dim Date_testLabel As System.Windows.Forms.Label
        Dim SN_DUTLabel As System.Windows.Forms.Label
        Dim Operator_testLabel As System.Windows.Forms.Label
        Dim RWO_IdLabel As System.Windows.Forms.Label
        Dim ModelLabel As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FW_UPDATE1))
        Me.ExcelDialog = New System.Windows.Forms.SaveFileDialog()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MACBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Re_checkAT = New System.Windows.Forms.Button()
        Me.MACTextBox4 = New System.Windows.Forms.TextBox()
        Me.MACTextBox3 = New System.Windows.Forms.TextBox()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.CheckBoxShowCOM = New System.Windows.Forms.CheckBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.AT_COM = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CheckBoxRWO = New System.Windows.Forms.CheckBox()
        Me.ComboBoxModel = New System.Windows.Forms.ComboBox()
        Me.StopBT = New System.Windows.Forms.Button()
        Me.Start_BT = New System.Windows.Forms.Button()
        Me.LabelProgressBarFCT = New System.Windows.Forms.Label()
        Me.TestingtimeStart1 = New System.Windows.Forms.TextBox()
        Me.MACTextBox2 = New System.Windows.Forms.TextBox()
        Me.SerialTextBox = New System.Windows.Forms.TextBox()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.IMEITextBox1 = New System.Windows.Forms.TextBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ERASE_PROG = New System.Windows.Forms.Button()
        Me.TimerDetect = New System.Windows.Forms.Timer(Me.components)
        Me.TimerDetect218 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ComboBoxKGB = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.LabelIPSQL = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBoxVoltTest = New System.Windows.Forms.ComboBox()
        Me.PanelCOM = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.PORT_FW = New System.Windows.Forms.ComboBox()
        Me.HUB_FW = New System.Windows.Forms.ComboBox()
        Me.CheckBoxAutoCOM_DUT = New System.Windows.Forms.CheckBox()
        Me.ComboBoxCOMModTester = New System.Windows.Forms.ComboBox()
        Me.ConnectDUT = New System.Windows.Forms.Button()
        Me.RefreshBT = New System.Windows.Forms.Button()
        Me.ComboBoxBRModTester = New System.Windows.Forms.ComboBox()
        Me.PSTestBT = New System.Windows.Forms.Button()
        Me.ComboBoxCOMPS = New System.Windows.Forms.ComboBox()
        Me.PSConnectSerial = New System.Windows.Forms.Button()
        Me.RefreshPS = New System.Windows.Forms.Button()
        Me.ComboBoxBaudRPS = New System.Windows.Forms.ComboBox()
        Me.DisconnectBT = New System.Windows.Forms.Button()
        Me.PSDisConnectSerial = New System.Windows.Forms.Button()
        Me.LabelInfo = New System.Windows.Forms.Label()
        Me.RestartModTesterBT = New System.Windows.Forms.Button()
        Me.TextBoxTemp = New System.Windows.Forms.TextBox()
        Me.ForceStopBT = New System.Windows.Forms.Button()
        Me.TestTodayOKLabel = New System.Windows.Forms.Label()
        Me.TimerDetect225 = New System.Windows.Forms.Timer(Me.components)
        Me.Date_testDate = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBoxBadgeId = New System.Windows.Forms.ComboBox()
        Me.ComboBoxOpName = New System.Windows.Forms.ComboBox()
        Me.ComboBoxRWO_Id = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SendBT = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxFirmwCheck = New System.Windows.Forms.TextBox()
        Me.tempBT = New System.Windows.Forms.Button()
        Me.ResultTextBoxFCT = New System.Windows.Forms.TextBox()
        Me.Total_Test_TimeTextBox = New System.Windows.Forms.TextBox()
        Me.LabelModBuildNumber = New System.Windows.Forms.Label()
        Me.Clock_Label = New System.Windows.Forms.Label()
        Me.LabelProgressBarFirm = New System.Windows.Forms.Label()
        Me.TestTodayFAILLabel = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.RichTextBoxTemp = New System.Windows.Forms.RichTextBox()
        Me.MACsw0TextBox = New System.Windows.Forms.TextBox()
        Me.ProgressBarFirm = New System.Windows.Forms.ProgressBar()
        Me.ProgressBarFCT = New System.Windows.Forms.ProgressBar()
        Me.Date_Label = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.LabelPartNumber = New System.Windows.Forms.Label()
        Me.SerialPortPS = New System.IO.Ports.SerialPort(Me.components)
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        MACLabel = New System.Windows.Forms.Label()
        Label5 = New System.Windows.Forms.Label()
        Label7 = New System.Windows.Forms.Label()
        Label8 = New System.Windows.Forms.Label()
        Label4 = New System.Windows.Forms.Label()
        Label3 = New System.Windows.Forms.Label()
        Total_Test_TimeLabel = New System.Windows.Forms.Label()
        OperatorBadgeID = New System.Windows.Forms.Label()
        SerialNum = New System.Windows.Forms.Label()
        TimeLabel = New System.Windows.Forms.Label()
        Date_testLabel = New System.Windows.Forms.Label()
        SN_DUTLabel = New System.Windows.Forms.Label()
        Operator_testLabel = New System.Windows.Forms.Label()
        RWO_IdLabel = New System.Windows.Forms.Label()
        ModelLabel = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCOM.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MACLabel
        '
        MACLabel.AutoSize = True
        MACLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        MACLabel.Location = New System.Drawing.Point(60, 241)
        MACLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        MACLabel.Name = "MACLabel"
        MACLabel.Size = New System.Drawing.Size(98, 36)
        MACLabel.TabIndex = 539
        MACLabel.Text = "IMEI :"
        '
        'Label5
        '
        Label5.AutoSize = True
        Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label5.Location = New System.Drawing.Point(25, 191)
        Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New System.Drawing.Size(135, 39)
        Label5.TabIndex = 565
        Label5.Text = "Model :"
        '
        'Label7
        '
        Label7.AutoSize = True
        Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label7.Location = New System.Drawing.Point(1345, 239)
        Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New System.Drawing.Size(148, 24)
        Label7.TabIndex = 597
        Label7.Text = "MAC #3 Scan :"
        Label7.Visible = False
        '
        'Label8
        '
        Label8.AutoSize = True
        Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label8.Location = New System.Drawing.Point(1344, 270)
        Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New System.Drawing.Size(148, 24)
        Label8.TabIndex = 595
        Label8.Text = "MAC #4 Scan :"
        Label8.Visible = False
        '
        'Label4
        '
        Label4.AutoSize = True
        Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label4.Location = New System.Drawing.Point(400, 241)
        Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New System.Drawing.Size(154, 26)
        Label4.TabIndex = 527
        Label4.Text = "FIRMWARE :"
        Label4.Visible = False
        '
        'Label3
        '
        Label3.AutoSize = True
        Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Label3.Location = New System.Drawing.Point(26, 132)
        Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New System.Drawing.Size(219, 31)
        Label3.TabIndex = 525
        Label3.Text = "TEST RESULT:"
        '
        'Total_Test_TimeLabel
        '
        Total_Test_TimeLabel.AutoSize = True
        Total_Test_TimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Total_Test_TimeLabel.Location = New System.Drawing.Point(784, 47)
        Total_Test_TimeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Total_Test_TimeLabel.Name = "Total_Test_TimeLabel"
        Total_Test_TimeLabel.Size = New System.Drawing.Size(192, 29)
        Total_Test_TimeLabel.TabIndex = 520
        Total_Test_TimeLabel.Text = "Tot. Test Time:"
        '
        'OperatorBadgeID
        '
        OperatorBadgeID.AutoSize = True
        OperatorBadgeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        OperatorBadgeID.Location = New System.Drawing.Point(599, 243)
        OperatorBadgeID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        OperatorBadgeID.Name = "OperatorBadgeID"
        OperatorBadgeID.Size = New System.Drawing.Size(179, 20)
        OperatorBadgeID.TabIndex = 552
        OperatorBadgeID.Text = "Operator Badge ID :"
        '
        'SerialNum
        '
        SerialNum.AutoSize = True
        SerialNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerialNum.Location = New System.Drawing.Point(1384, 207)
        SerialNum.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        SerialNum.Name = "SerialNum"
        SerialNum.Size = New System.Drawing.Size(109, 24)
        SerialNum.TabIndex = 551
        SerialNum.Text = "MAC sw0 :"
        SerialNum.Visible = False
        '
        'TimeLabel
        '
        TimeLabel.AutoSize = True
        TimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        TimeLabel.Location = New System.Drawing.Point(922, 153)
        TimeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        TimeLabel.Name = "TimeLabel"
        TimeLabel.Size = New System.Drawing.Size(109, 20)
        TimeLabel.TabIndex = 537
        TimeLabel.Text = "Start Time :"
        '
        'Date_testLabel
        '
        Date_testLabel.AutoSize = True
        Date_testLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Date_testLabel.Location = New System.Drawing.Point(634, 158)
        Date_testLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Date_testLabel.Name = "Date_testLabel"
        Date_testLabel.Size = New System.Drawing.Size(104, 20)
        Date_testLabel.TabIndex = 536
        Date_testLabel.Text = "Date Test :"
        '
        'SN_DUTLabel
        '
        SN_DUTLabel.AutoSize = True
        SN_DUTLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SN_DUTLabel.Location = New System.Drawing.Point(39, 187)
        SN_DUTLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        SN_DUTLabel.Name = "SN_DUTLabel"
        SN_DUTLabel.Size = New System.Drawing.Size(75, 24)
        SN_DUTLabel.TabIndex = 532
        SN_DUTLabel.Text = "Serial :"
        SN_DUTLabel.Visible = False
        '
        'Operator_testLabel
        '
        Operator_testLabel.AutoSize = True
        Operator_testLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Operator_testLabel.Location = New System.Drawing.Point(631, 203)
        Operator_testLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Operator_testLabel.Name = "Operator_testLabel"
        Operator_testLabel.Size = New System.Drawing.Size(149, 20)
        Operator_testLabel.TabIndex = 531
        Operator_testLabel.Text = "Operator Name :"
        '
        'RWO_IdLabel
        '
        RWO_IdLabel.AutoSize = True
        RWO_IdLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        RWO_IdLabel.Location = New System.Drawing.Point(746, 193)
        RWO_IdLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        RWO_IdLabel.Name = "RWO_IdLabel"
        RWO_IdLabel.Size = New System.Drawing.Size(86, 20)
        RWO_IdLabel.TabIndex = 530
        RWO_IdLabel.Text = "RWO Id :"
        RWO_IdLabel.Visible = False
        '
        'ModelLabel
        '
        ModelLabel.AutoSize = True
        ModelLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        ModelLabel.Location = New System.Drawing.Point(1345, 176)
        ModelLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        ModelLabel.Name = "ModelLabel"
        ModelLabel.Size = New System.Drawing.Size(148, 24)
        ModelLabel.TabIndex = 534
        ModelLabel.Text = "MAC #2 Scan :"
        ModelLabel.Visible = False
        '
        'ExcelDialog
        '
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(183, 26)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(183, 26)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(183, 26)
        Me.AdminToolStripMenuItem.Text = "Admin"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolStripMenuItem, Me.LogoutToolStripMenuItem, Me.AboutToolStripMenuItem, Me.MACBarcodeToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(60, 24)
        Me.MenuToolStripMenuItem.Text = "Login"
        '
        'MACBarcodeToolStripMenuItem
        '
        Me.MACBarcodeToolStripMenuItem.Name = "MACBarcodeToolStripMenuItem"
        Me.MACBarcodeToolStripMenuItem.Size = New System.Drawing.Size(183, 26)
        Me.MACBarcodeToolStripMenuItem.Text = "MAC Barcode"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(531, 353)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 601
        Me.Button8.Text = "Button8"
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'Re_checkAT
        '
        Me.Re_checkAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Re_checkAT.Location = New System.Drawing.Point(941, 905)
        Me.Re_checkAT.Name = "Re_checkAT"
        Me.Re_checkAT.Size = New System.Drawing.Size(279, 46)
        Me.Re_checkAT.TabIndex = 600
        Me.Re_checkAT.Text = "Re-Check AT Command"
        Me.Re_checkAT.UseVisualStyleBackColor = True
        '
        'MACTextBox4
        '
        Me.MACTextBox4.Enabled = False
        Me.MACTextBox4.Location = New System.Drawing.Point(1507, 273)
        Me.MACTextBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.MACTextBox4.Name = "MACTextBox4"
        Me.MACTextBox4.Size = New System.Drawing.Size(501, 22)
        Me.MACTextBox4.TabIndex = 596
        Me.MACTextBox4.Visible = False
        '
        'MACTextBox3
        '
        Me.MACTextBox3.Enabled = False
        Me.MACTextBox3.Location = New System.Drawing.Point(1507, 241)
        Me.MACTextBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.MACTextBox3.Name = "MACTextBox3"
        Me.MACTextBox3.Size = New System.Drawing.Size(501, 22)
        Me.MACTextBox3.TabIndex = 598
        Me.MACTextBox3.Visible = False
        '
        'Button11
        '
        Me.Button11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.Location = New System.Drawing.Point(725, 793)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(217, 61)
        Me.Button11.TabIndex = 594
        Me.Button11.Text = "BROWSE"
        Me.Button11.UseVisualStyleBackColor = True
        Me.Button11.Visible = False
        '
        'Button10
        '
        Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.Location = New System.Drawing.Point(725, 957)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(217, 61)
        Me.Button10.TabIndex = 518
        Me.Button10.Text = "SAVE"
        Me.Button10.UseVisualStyleBackColor = True
        Me.Button10.Visible = False
        '
        'Button9
        '
        Me.Button9.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.Location = New System.Drawing.Point(725, 875)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(217, 61)
        Me.Button9.TabIndex = 592
        Me.Button9.Text = "CONVERT"
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'CheckBoxShowCOM
        '
        Me.CheckBoxShowCOM.AutoSize = True
        Me.CheckBoxShowCOM.Location = New System.Drawing.Point(688, 922)
        Me.CheckBoxShowCOM.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBoxShowCOM.Name = "CheckBoxShowCOM"
        Me.CheckBoxShowCOM.Size = New System.Drawing.Size(133, 20)
        Me.CheckBoxShowCOM.TabIndex = 578
        Me.CheckBoxShowCOM.Text = "Show COM Panel"
        Me.CheckBoxShowCOM.UseVisualStyleBackColor = True
        '
        'SerialPort1
        '
        '
        'AT_COM
        '
        Me.AT_COM.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.AT_COM.Location = New System.Drawing.Point(539, 21)
        Me.AT_COM.Margin = New System.Windows.Forms.Padding(4)
        Me.AT_COM.Name = "AT_COM"
        Me.AT_COM.Size = New System.Drawing.Size(237, 81)
        Me.AT_COM.TabIndex = 599
        Me.AT_COM.Text = "AT Command 1"
        Me.AT_COM.UseVisualStyleBackColor = True
        Me.AT_COM.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(566, 759)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(550, 22)
        Me.TextBox2.TabIndex = 593
        Me.TextBox2.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1006, 827)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 32)
        Me.Label6.TabIndex = 591
        '
        'CheckBoxRWO
        '
        Me.CheckBoxRWO.AutoSize = True
        Me.CheckBoxRWO.Location = New System.Drawing.Point(725, 195)
        Me.CheckBoxRWO.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBoxRWO.Name = "CheckBoxRWO"
        Me.CheckBoxRWO.Size = New System.Drawing.Size(18, 17)
        Me.CheckBoxRWO.TabIndex = 590
        Me.CheckBoxRWO.UseVisualStyleBackColor = True
        Me.CheckBoxRWO.Visible = False
        '
        'ComboBoxModel
        '
        Me.ComboBoxModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxModel.FormattingEnabled = True
        Me.ComboBoxModel.Items.AddRange(New Object() {"29001031 Rev A", "29000965 Rev B"})
        Me.ComboBoxModel.Location = New System.Drawing.Point(184, 197)
        Me.ComboBoxModel.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxModel.Name = "ComboBoxModel"
        Me.ComboBoxModel.Size = New System.Drawing.Size(400, 33)
        Me.ComboBoxModel.TabIndex = 589
        '
        'StopBT
        '
        Me.StopBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.StopBT.Location = New System.Drawing.Point(703, 28)
        Me.StopBT.Margin = New System.Windows.Forms.Padding(4)
        Me.StopBT.Name = "StopBT"
        Me.StopBT.Size = New System.Drawing.Size(180, 69)
        Me.StopBT.TabIndex = 522
        Me.StopBT.Text = "STOP"
        Me.StopBT.UseVisualStyleBackColor = True
        Me.StopBT.Visible = False
        '
        'Start_BT
        '
        Me.Start_BT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Start_BT.Location = New System.Drawing.Point(420, 21)
        Me.Start_BT.Margin = New System.Windows.Forms.Padding(4)
        Me.Start_BT.Name = "Start_BT"
        Me.Start_BT.Size = New System.Drawing.Size(212, 81)
        Me.Start_BT.TabIndex = 521
        Me.Start_BT.Text = "FW UPDATE 1"
        Me.Start_BT.UseVisualStyleBackColor = True
        '
        'LabelProgressBarFCT
        '
        Me.LabelProgressBarFCT.AutoSize = True
        Me.LabelProgressBarFCT.BackColor = System.Drawing.Color.Transparent
        Me.LabelProgressBarFCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelProgressBarFCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProgressBarFCT.Location = New System.Drawing.Point(42, 121)
        Me.LabelProgressBarFCT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelProgressBarFCT.Name = "LabelProgressBarFCT"
        Me.LabelProgressBarFCT.Size = New System.Drawing.Size(65, 20)
        Me.LabelProgressBarFCT.TabIndex = 562
        Me.LabelProgressBarFCT.Text = "Label4"
        Me.LabelProgressBarFCT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelProgressBarFCT.Visible = False
        '
        'TestingtimeStart1
        '
        Me.TestingtimeStart1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TestingtimeStart1.Location = New System.Drawing.Point(1044, 150)
        Me.TestingtimeStart1.Margin = New System.Windows.Forms.Padding(4)
        Me.TestingtimeStart1.Name = "TestingtimeStart1"
        Me.TestingtimeStart1.Size = New System.Drawing.Size(151, 26)
        Me.TestingtimeStart1.TabIndex = 538
        Me.TestingtimeStart1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MACTextBox2
        '
        Me.MACTextBox2.Enabled = False
        Me.MACTextBox2.Location = New System.Drawing.Point(1510, 178)
        Me.MACTextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.MACTextBox2.Name = "MACTextBox2"
        Me.MACTextBox2.Size = New System.Drawing.Size(501, 22)
        Me.MACTextBox2.TabIndex = 535
        Me.MACTextBox2.Visible = False
        '
        'SerialTextBox
        '
        Me.SerialTextBox.Enabled = False
        Me.SerialTextBox.Location = New System.Drawing.Point(131, 188)
        Me.SerialTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.SerialTextBox.Name = "SerialTextBox"
        Me.SerialTextBox.Size = New System.Drawing.Size(501, 22)
        Me.SerialTextBox.TabIndex = 533
        Me.SerialTextBox.Visible = False
        '
        'RichTextBox3
        '
        Me.RichTextBox3.Location = New System.Drawing.Point(1176, 1007)
        Me.RichTextBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(811, 96)
        Me.RichTextBox3.TabIndex = 584
        Me.RichTextBox3.Text = ""
        Me.RichTextBox3.Visible = False
        '
        'IMEITextBox1
        '
        Me.IMEITextBox1.Enabled = False
        Me.IMEITextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IMEITextBox1.Location = New System.Drawing.Point(184, 247)
        Me.IMEITextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.IMEITextBox1.Name = "IMEITextBox1"
        Me.IMEITextBox1.Size = New System.Drawing.Size(400, 30)
        Me.IMEITextBox1.TabIndex = 540
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1217, 973)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(100, 28)
        Me.Button5.TabIndex = 576
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        Me.Button5.Visible = False
        '
        'ERASE_PROG
        '
        Me.ERASE_PROG.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ERASE_PROG.Location = New System.Drawing.Point(941, 939)
        Me.ERASE_PROG.Margin = New System.Windows.Forms.Padding(4)
        Me.ERASE_PROG.Name = "ERASE_PROG"
        Me.ERASE_PROG.Size = New System.Drawing.Size(228, 84)
        Me.ERASE_PROG.TabIndex = 559
        Me.ERASE_PROG.Text = "ERASE PROGRAM"
        Me.ERASE_PROG.UseVisualStyleBackColor = True
        Me.ERASE_PROG.Visible = False
        '
        'TimerDetect
        '
        '
        'TimerDetect218
        '
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(364, 644)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(160, 22)
        Me.TextBox1.TabIndex = 588
        Me.TextBox1.Visible = False
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(1046, 822)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(220, 62)
        Me.Button6.TabIndex = 587
        Me.Button6.Text = "check mac dll"
        Me.Button6.UseVisualStyleBackColor = True
        Me.Button6.Visible = False
        '
        'ComboBoxKGB
        '
        Me.ComboBoxKGB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxKGB.FormattingEnabled = True
        Me.ComboBoxKGB.Items.AddRange(New Object() {"Non KGB", "KGB"})
        Me.ComboBoxKGB.Location = New System.Drawing.Point(1217, 935)
        Me.ComboBoxKGB.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxKGB.Name = "ComboBoxKGB"
        Me.ComboBoxKGB.Size = New System.Drawing.Size(160, 25)
        Me.ComboBoxKGB.TabIndex = 519
        Me.ComboBoxKGB.Text = "Non KGB"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(1176, 951)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 583
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'LabelIPSQL
        '
        Me.LabelIPSQL.AutoSize = True
        Me.LabelIPSQL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelIPSQL.Location = New System.Drawing.Point(1214, 905)
        Me.LabelIPSQL.Name = "LabelIPSQL"
        Me.LabelIPSQL.Size = New System.Drawing.Size(306, 18)
        Me.LabelIPSQL.TabIndex = 582
        Me.LabelIPSQL.Text = "SQL Server IP  << Connection Test Fail"
        Me.LabelIPSQL.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(641, 793)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 16)
        Me.Label2.TabIndex = 580
        Me.Label2.Text = "Voltage Testing"
        '
        'ComboBoxVoltTest
        '
        Me.ComboBoxVoltTest.FormattingEnabled = True
        Me.ComboBoxVoltTest.Items.AddRange(New Object() {"24.00", "12.00", "9.00"})
        Me.ComboBoxVoltTest.Location = New System.Drawing.Point(650, 813)
        Me.ComboBoxVoltTest.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxVoltTest.Name = "ComboBoxVoltTest"
        Me.ComboBoxVoltTest.Size = New System.Drawing.Size(93, 24)
        Me.ComboBoxVoltTest.TabIndex = 579
        Me.ComboBoxVoltTest.Text = "24.00"
        '
        'PanelCOM
        '
        Me.PanelCOM.Controls.Add(Me.Label10)
        Me.PanelCOM.Controls.Add(Me.Label9)
        Me.PanelCOM.Controls.Add(Me.PORT_FW)
        Me.PanelCOM.Controls.Add(Me.HUB_FW)
        Me.PanelCOM.Controls.Add(Me.CheckBoxAutoCOM_DUT)
        Me.PanelCOM.Controls.Add(Me.ComboBoxCOMModTester)
        Me.PanelCOM.Controls.Add(Me.ConnectDUT)
        Me.PanelCOM.Controls.Add(Me.RefreshBT)
        Me.PanelCOM.Controls.Add(Me.ComboBoxBRModTester)
        Me.PanelCOM.Controls.Add(Me.PSTestBT)
        Me.PanelCOM.Controls.Add(Me.ComboBoxCOMPS)
        Me.PanelCOM.Controls.Add(Me.PSConnectSerial)
        Me.PanelCOM.Controls.Add(Me.RefreshPS)
        Me.PanelCOM.Controls.Add(Me.ComboBoxBaudRPS)
        Me.PanelCOM.Controls.Add(Me.DisconnectBT)
        Me.PanelCOM.Controls.Add(Me.PSDisConnectSerial)
        Me.PanelCOM.Controls.Add(Me.LabelInfo)
        Me.PanelCOM.Controls.Add(Me.RestartModTesterBT)
        Me.PanelCOM.Location = New System.Drawing.Point(22, 784)
        Me.PanelCOM.Margin = New System.Windows.Forms.Padding(4)
        Me.PanelCOM.Name = "PanelCOM"
        Me.PanelCOM.Size = New System.Drawing.Size(629, 234)
        Me.PanelCOM.TabIndex = 577
        Me.PanelCOM.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 134)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 16)
        Me.Label10.TabIndex = 437
        Me.Label10.Text = "PORT"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(65, 95)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 16)
        Me.Label9.TabIndex = 436
        Me.Label9.Text = "HUB"
        '
        'PORT_FW
        '
        Me.PORT_FW.FormattingEnabled = True
        Me.PORT_FW.Location = New System.Drawing.Point(136, 128)
        Me.PORT_FW.Name = "PORT_FW"
        Me.PORT_FW.Size = New System.Drawing.Size(121, 24)
        Me.PORT_FW.TabIndex = 435
        '
        'HUB_FW
        '
        Me.HUB_FW.FormattingEnabled = True
        Me.HUB_FW.Location = New System.Drawing.Point(136, 91)
        Me.HUB_FW.Name = "HUB_FW"
        Me.HUB_FW.Size = New System.Drawing.Size(121, 24)
        Me.HUB_FW.TabIndex = 434
        '
        'CheckBoxAutoCOM_DUT
        '
        Me.CheckBoxAutoCOM_DUT.AutoSize = True
        Me.CheckBoxAutoCOM_DUT.Location = New System.Drawing.Point(270, 13)
        Me.CheckBoxAutoCOM_DUT.Name = "CheckBoxAutoCOM_DUT"
        Me.CheckBoxAutoCOM_DUT.Size = New System.Drawing.Size(18, 17)
        Me.CheckBoxAutoCOM_DUT.TabIndex = 433
        Me.CheckBoxAutoCOM_DUT.UseVisualStyleBackColor = True
        Me.CheckBoxAutoCOM_DUT.Visible = False
        '
        'ComboBoxCOMModTester
        '
        Me.ComboBoxCOMModTester.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCOMModTester.FormattingEnabled = True
        Me.ComboBoxCOMModTester.Location = New System.Drawing.Point(59, 46)
        Me.ComboBoxCOMModTester.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxCOMModTester.Name = "ComboBoxCOMModTester"
        Me.ComboBoxCOMModTester.Size = New System.Drawing.Size(160, 25)
        Me.ComboBoxCOMModTester.TabIndex = 240
        Me.ComboBoxCOMModTester.Text = "Select COM"
        '
        'ConnectDUT
        '
        Me.ConnectDUT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ConnectDUT.Location = New System.Drawing.Point(49, 4)
        Me.ConnectDUT.Margin = New System.Windows.Forms.Padding(4)
        Me.ConnectDUT.Name = "ConnectDUT"
        Me.ConnectDUT.Size = New System.Drawing.Size(248, 34)
        Me.ConnectDUT.TabIndex = 242
        Me.ConnectDUT.Text = "Connect DUT"
        Me.ConnectDUT.UseVisualStyleBackColor = True
        Me.ConnectDUT.Visible = False
        '
        'RefreshBT
        '
        Me.RefreshBT.BackgroundImage = CType(resources.GetObject("RefreshBT.BackgroundImage"), System.Drawing.Image)
        Me.RefreshBT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RefreshBT.Location = New System.Drawing.Point(13, 43)
        Me.RefreshBT.Margin = New System.Windows.Forms.Padding(4)
        Me.RefreshBT.Name = "RefreshBT"
        Me.RefreshBT.Size = New System.Drawing.Size(37, 28)
        Me.RefreshBT.TabIndex = 243
        Me.RefreshBT.UseVisualStyleBackColor = True
        Me.RefreshBT.Visible = False
        '
        'ComboBoxBRModTester
        '
        Me.ComboBoxBRModTester.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxBRModTester.FormattingEnabled = True
        Me.ComboBoxBRModTester.Location = New System.Drawing.Point(239, 46)
        Me.ComboBoxBRModTester.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxBRModTester.Name = "ComboBoxBRModTester"
        Me.ComboBoxBRModTester.Size = New System.Drawing.Size(160, 25)
        Me.ComboBoxBRModTester.TabIndex = 247
        Me.ComboBoxBRModTester.Text = "Select Baud Rate"
        Me.ComboBoxBRModTester.Visible = False
        '
        'PSTestBT
        '
        Me.PSTestBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PSTestBT.Location = New System.Drawing.Point(421, 139)
        Me.PSTestBT.Margin = New System.Windows.Forms.Padding(4)
        Me.PSTestBT.Name = "PSTestBT"
        Me.PSTestBT.Size = New System.Drawing.Size(145, 71)
        Me.PSTestBT.TabIndex = 271
        Me.PSTestBT.Tag = "Set Power Supply Voltage=24V, Current Max=1A"
        Me.PSTestBT.Text = "Test PS/  Restart Tester"
        Me.PSTestBT.UseVisualStyleBackColor = True
        Me.PSTestBT.Visible = False
        '
        'ComboBoxCOMPS
        '
        Me.ComboBoxCOMPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxCOMPS.FormattingEnabled = True
        Me.ComboBoxCOMPS.Location = New System.Drawing.Point(66, 191)
        Me.ComboBoxCOMPS.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxCOMPS.Name = "ComboBoxCOMPS"
        Me.ComboBoxCOMPS.Size = New System.Drawing.Size(160, 25)
        Me.ComboBoxCOMPS.TabIndex = 272
        Me.ComboBoxCOMPS.Text = "Select COM"
        Me.ComboBoxCOMPS.Visible = False
        '
        'PSConnectSerial
        '
        Me.PSConnectSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PSConnectSerial.Location = New System.Drawing.Point(58, 149)
        Me.PSConnectSerial.Margin = New System.Windows.Forms.Padding(4)
        Me.PSConnectSerial.Name = "PSConnectSerial"
        Me.PSConnectSerial.Size = New System.Drawing.Size(246, 34)
        Me.PSConnectSerial.TabIndex = 273
        Me.PSConnectSerial.Text = "Connect PS"
        Me.PSConnectSerial.UseVisualStyleBackColor = True
        Me.PSConnectSerial.Visible = False
        '
        'RefreshPS
        '
        Me.RefreshPS.BackgroundImage = CType(resources.GetObject("RefreshPS.BackgroundImage"), System.Drawing.Image)
        Me.RefreshPS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.RefreshPS.Location = New System.Drawing.Point(19, 188)
        Me.RefreshPS.Margin = New System.Windows.Forms.Padding(4)
        Me.RefreshPS.Name = "RefreshPS"
        Me.RefreshPS.Size = New System.Drawing.Size(39, 28)
        Me.RefreshPS.TabIndex = 274
        Me.RefreshPS.UseVisualStyleBackColor = True
        Me.RefreshPS.Visible = False
        '
        'ComboBoxBaudRPS
        '
        Me.ComboBoxBaudRPS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxBaudRPS.FormattingEnabled = True
        Me.ComboBoxBaudRPS.Location = New System.Drawing.Point(246, 191)
        Me.ComboBoxBaudRPS.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxBaudRPS.Name = "ComboBoxBaudRPS"
        Me.ComboBoxBaudRPS.Size = New System.Drawing.Size(160, 25)
        Me.ComboBoxBaudRPS.TabIndex = 275
        Me.ComboBoxBaudRPS.Text = "Select Baud Rate"
        Me.ComboBoxBaudRPS.Visible = False
        '
        'DisconnectBT
        '
        Me.DisconnectBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DisconnectBT.Location = New System.Drawing.Point(239, 4)
        Me.DisconnectBT.Margin = New System.Windows.Forms.Padding(4)
        Me.DisconnectBT.Name = "DisconnectBT"
        Me.DisconnectBT.Size = New System.Drawing.Size(161, 34)
        Me.DisconnectBT.TabIndex = 279
        Me.DisconnectBT.Text = "Disconnect"
        Me.DisconnectBT.UseVisualStyleBackColor = True
        Me.DisconnectBT.Visible = False
        '
        'PSDisConnectSerial
        '
        Me.PSDisConnectSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PSDisConnectSerial.Location = New System.Drawing.Point(246, 149)
        Me.PSDisConnectSerial.Margin = New System.Windows.Forms.Padding(4)
        Me.PSDisConnectSerial.Name = "PSDisConnectSerial"
        Me.PSDisConnectSerial.Size = New System.Drawing.Size(161, 34)
        Me.PSDisConnectSerial.TabIndex = 280
        Me.PSDisConnectSerial.Text = "Disconnect"
        Me.PSDisConnectSerial.UseVisualStyleBackColor = True
        Me.PSDisConnectSerial.Visible = False
        '
        'LabelInfo
        '
        Me.LabelInfo.AutoSize = True
        Me.LabelInfo.Location = New System.Drawing.Point(55, 167)
        Me.LabelInfo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelInfo.Name = "LabelInfo"
        Me.LabelInfo.Size = New System.Drawing.Size(0, 16)
        Me.LabelInfo.TabIndex = 286
        Me.LabelInfo.Visible = False
        '
        'RestartModTesterBT
        '
        Me.RestartModTesterBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RestartModTesterBT.Location = New System.Drawing.Point(421, 38)
        Me.RestartModTesterBT.Margin = New System.Windows.Forms.Padding(4)
        Me.RestartModTesterBT.Name = "RestartModTesterBT"
        Me.RestartModTesterBT.Size = New System.Drawing.Size(163, 82)
        Me.RestartModTesterBT.TabIndex = 432
        Me.RestartModTesterBT.Text = "OFF-ON Power Supply"
        Me.RestartModTesterBT.UseVisualStyleBackColor = True
        Me.RestartModTesterBT.Visible = False
        '
        'TextBoxTemp
        '
        Me.TextBoxTemp.Location = New System.Drawing.Point(678, 1010)
        Me.TextBoxTemp.Name = "TextBoxTemp"
        Me.TextBoxTemp.Size = New System.Drawing.Size(171, 22)
        Me.TextBoxTemp.TabIndex = 585
        Me.TextBoxTemp.Visible = False
        '
        'ForceStopBT
        '
        Me.ForceStopBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForceStopBT.Location = New System.Drawing.Point(1029, 91)
        Me.ForceStopBT.Margin = New System.Windows.Forms.Padding(4)
        Me.ForceStopBT.Name = "ForceStopBT"
        Me.ForceStopBT.Size = New System.Drawing.Size(180, 37)
        Me.ForceStopBT.TabIndex = 523
        Me.ForceStopBT.Text = "Force STOP"
        Me.ForceStopBT.UseVisualStyleBackColor = True
        '
        'TestTodayOKLabel
        '
        Me.TestTodayOKLabel.AutoSize = True
        Me.TestTodayOKLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TestTodayOKLabel.Location = New System.Drawing.Point(1170, 55)
        Me.TestTodayOKLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TestTodayOKLabel.Name = "TestTodayOKLabel"
        Me.TestTodayOKLabel.Size = New System.Drawing.Size(137, 29)
        Me.TestTodayOKLabel.TabIndex = 549
        Me.TestTodayOKLabel.Text = "#Test OK :"
        Me.TestTodayOKLabel.Visible = False
        '
        'TimerDetect225
        '
        '
        'Date_testDate
        '
        Me.Date_testDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_testDate.Location = New System.Drawing.Point(750, 150)
        Me.Date_testDate.Margin = New System.Windows.Forms.Padding(4)
        Me.Date_testDate.Name = "Date_testDate"
        Me.Date_testDate.Size = New System.Drawing.Size(161, 26)
        Me.Date_testDate.TabIndex = 548
        Me.Date_testDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(13, 32)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(286, 70)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 547
        Me.PictureBox1.TabStop = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(1292, 211)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox2.TabIndex = 574
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(1292, 199)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox1.TabIndex = 573
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'ComboBoxBadgeId
        '
        Me.ComboBoxBadgeId.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxBadgeId.FormattingEnabled = True
        Me.ComboBoxBadgeId.Location = New System.Drawing.Point(799, 238)
        Me.ComboBoxBadgeId.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxBadgeId.Name = "ComboBoxBadgeId"
        Me.ComboBoxBadgeId.Size = New System.Drawing.Size(400, 33)
        Me.ComboBoxBadgeId.TabIndex = 572
        '
        'ComboBoxOpName
        '
        Me.ComboBoxOpName.Enabled = False
        Me.ComboBoxOpName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxOpName.FormattingEnabled = True
        Me.ComboBoxOpName.Location = New System.Drawing.Point(799, 199)
        Me.ComboBoxOpName.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxOpName.Name = "ComboBoxOpName"
        Me.ComboBoxOpName.Size = New System.Drawing.Size(400, 33)
        Me.ComboBoxOpName.TabIndex = 571
        '
        'ComboBoxRWO_Id
        '
        Me.ComboBoxRWO_Id.Enabled = False
        Me.ComboBoxRWO_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxRWO_Id.FormattingEnabled = True
        Me.ComboBoxRWO_Id.Location = New System.Drawing.Point(842, 190)
        Me.ComboBoxRWO_Id.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxRWO_Id.Name = "ComboBoxRWO_Id"
        Me.ComboBoxRWO_Id.Size = New System.Drawing.Size(400, 33)
        Me.ComboBoxRWO_Id.TabIndex = 570
        Me.ComboBoxRWO_Id.Visible = False
        '
        'Button4
        '
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Location = New System.Drawing.Point(1207, 241)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(33, 28)
        Me.Button4.TabIndex = 569
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(1292, 246)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(18, 17)
        Me.CheckBox3.TabIndex = 575
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Location = New System.Drawing.Point(1207, 204)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(33, 28)
        Me.Button3.TabIndex = 567
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(1250, 193)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(33, 28)
        Me.Button1.TabIndex = 568
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'SendBT
        '
        Me.SendBT.Location = New System.Drawing.Point(192, 644)
        Me.SendBT.Margin = New System.Windows.Forms.Padding(4)
        Me.SendBT.Name = "SendBT"
        Me.SendBT.Size = New System.Drawing.Size(87, 28)
        Me.SendBT.TabIndex = 541
        Me.SendBT.Text = "SendBT"
        Me.SendBT.UseVisualStyleBackColor = True
        Me.SendBT.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 652)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 20)
        Me.Label1.TabIndex = 544
        Me.Label1.Text = "Send Data to TESTER:"
        Me.Label1.Visible = False
        '
        'TextBoxFirmwCheck
        '
        Me.TextBoxFirmwCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxFirmwCheck.Location = New System.Drawing.Point(364, 269)
        Me.TextBoxFirmwCheck.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxFirmwCheck.Name = "TextBoxFirmwCheck"
        Me.TextBoxFirmwCheck.Size = New System.Drawing.Size(225, 37)
        Me.TextBoxFirmwCheck.TabIndex = 528
        Me.TextBoxFirmwCheck.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxFirmwCheck.Visible = False
        '
        'tempBT
        '
        Me.tempBT.Location = New System.Drawing.Point(405, 801)
        Me.tempBT.Margin = New System.Windows.Forms.Padding(4)
        Me.tempBT.Name = "tempBT"
        Me.tempBT.Size = New System.Drawing.Size(179, 28)
        Me.tempBT.TabIndex = 553
        Me.tempBT.Text = "temp"
        Me.tempBT.UseVisualStyleBackColor = True
        Me.tempBT.Visible = False
        '
        'ResultTextBoxFCT
        '
        Me.ResultTextBoxFCT.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResultTextBoxFCT.Location = New System.Drawing.Point(273, 122)
        Me.ResultTextBoxFCT.Margin = New System.Windows.Forms.Padding(4)
        Me.ResultTextBoxFCT.Name = "ResultTextBoxFCT"
        Me.ResultTextBoxFCT.Size = New System.Drawing.Size(311, 49)
        Me.ResultTextBoxFCT.TabIndex = 526
        Me.ResultTextBoxFCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Total_Test_TimeTextBox
        '
        Me.Total_Test_TimeTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Total_Test_TimeTextBox.Location = New System.Drawing.Point(993, 34)
        Me.Total_Test_TimeTextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.Total_Test_TimeTextBox.Name = "Total_Test_TimeTextBox"
        Me.Total_Test_TimeTextBox.Size = New System.Drawing.Size(233, 49)
        Me.Total_Test_TimeTextBox.TabIndex = 524
        Me.Total_Test_TimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelModBuildNumber
        '
        Me.LabelModBuildNumber.AutoSize = True
        Me.LabelModBuildNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelModBuildNumber.Location = New System.Drawing.Point(1668, 121)
        Me.LabelModBuildNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelModBuildNumber.Name = "LabelModBuildNumber"
        Me.LabelModBuildNumber.Size = New System.Drawing.Size(69, 29)
        Me.LabelModBuildNumber.TabIndex = 566
        Me.LabelModBuildNumber.Text = "OPG"
        Me.LabelModBuildNumber.Visible = False
        '
        'Clock_Label
        '
        Me.Clock_Label.AutoSize = True
        Me.Clock_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Clock_Label.Location = New System.Drawing.Point(1752, 935)
        Me.Clock_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Clock_Label.Name = "Clock_Label"
        Me.Clock_Label.Size = New System.Drawing.Size(137, 52)
        Me.Clock_Label.TabIndex = 555
        Me.Clock_Label.Text = "Clock"
        '
        'LabelProgressBarFirm
        '
        Me.LabelProgressBarFirm.AutoSize = True
        Me.LabelProgressBarFirm.BackColor = System.Drawing.Color.Transparent
        Me.LabelProgressBarFirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelProgressBarFirm.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProgressBarFirm.Location = New System.Drawing.Point(42, 174)
        Me.LabelProgressBarFirm.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelProgressBarFirm.Name = "LabelProgressBarFirm"
        Me.LabelProgressBarFirm.Size = New System.Drawing.Size(65, 20)
        Me.LabelProgressBarFirm.TabIndex = 564
        Me.LabelProgressBarFirm.Text = "Label4"
        Me.LabelProgressBarFirm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LabelProgressBarFirm.Visible = False
        '
        'TestTodayFAILLabel
        '
        Me.TestTodayFAILLabel.AutoSize = True
        Me.TestTodayFAILLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TestTodayFAILLabel.Location = New System.Drawing.Point(1152, 98)
        Me.TestTodayFAILLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TestTodayFAILLabel.Name = "TestTodayFAILLabel"
        Me.TestTodayFAILLabel.Size = New System.Drawing.Size(153, 29)
        Me.TestTodayFAILLabel.TabIndex = 561
        Me.TestTodayFAILLabel.Text = "#Test FAIL :"
        Me.TestTodayFAILLabel.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1068, 942)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 557
        Me.Button2.Text = "simulate1"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(46, 269)
        Me.Button7.Margin = New System.Windows.Forms.Padding(4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(79, 28)
        Me.Button7.TabIndex = 560
        Me.Button7.Text = "clear"
        Me.Button7.UseVisualStyleBackColor = True
        Me.Button7.Visible = False
        '
        'RichTextBoxTemp
        '
        Me.RichTextBoxTemp.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBoxTemp.Location = New System.Drawing.Point(624, 882)
        Me.RichTextBoxTemp.Margin = New System.Windows.Forms.Padding(4)
        Me.RichTextBoxTemp.Name = "RichTextBoxTemp"
        Me.RichTextBoxTemp.Size = New System.Drawing.Size(1457, 198)
        Me.RichTextBoxTemp.TabIndex = 558
        Me.RichTextBoxTemp.Text = ""
        Me.RichTextBoxTemp.Visible = False
        '
        'MACsw0TextBox
        '
        Me.MACsw0TextBox.Enabled = False
        Me.MACsw0TextBox.Location = New System.Drawing.Point(1510, 209)
        Me.MACsw0TextBox.Margin = New System.Windows.Forms.Padding(4)
        Me.MACsw0TextBox.Name = "MACsw0TextBox"
        Me.MACsw0TextBox.Size = New System.Drawing.Size(501, 22)
        Me.MACsw0TextBox.TabIndex = 550
        Me.MACsw0TextBox.Visible = False
        '
        'ProgressBarFirm
        '
        Me.ProgressBarFirm.Location = New System.Drawing.Point(10, 121)
        Me.ProgressBarFirm.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBarFirm.Name = "ProgressBarFirm"
        Me.ProgressBarFirm.Size = New System.Drawing.Size(579, 38)
        Me.ProgressBarFirm.TabIndex = 563
        Me.ProgressBarFirm.Tag = ""
        Me.ProgressBarFirm.Visible = False
        '
        'ProgressBarFCT
        '
        Me.ProgressBarFCT.Location = New System.Drawing.Point(12, 110)
        Me.ProgressBarFCT.Margin = New System.Windows.Forms.Padding(4)
        Me.ProgressBarFCT.Name = "ProgressBarFCT"
        Me.ProgressBarFCT.Size = New System.Drawing.Size(579, 38)
        Me.ProgressBarFCT.TabIndex = 556
        Me.ProgressBarFCT.Visible = False
        '
        'Date_Label
        '
        Me.Date_Label.AutoSize = True
        Me.Date_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Date_Label.Location = New System.Drawing.Point(1442, 924)
        Me.Date_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Date_Label.Name = "Date_Label"
        Me.Date_Label.Size = New System.Drawing.Size(118, 52)
        Me.Date_Label.TabIndex = 554
        Me.Date_Label.Text = "Date"
        Me.Date_Label.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(1218, 907)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(864, 116)
        Me.ListBox1.TabIndex = 581
        Me.ListBox1.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1924, 30)
        Me.MenuStrip1.TabIndex = 586
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DataGridView1
        '
        Me.DataGridView1.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(751, 285)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 51
        Me.DataGridView1.Size = New System.Drawing.Size(475, 614)
        Me.DataGridView1.TabIndex = 545
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(1107, 432)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 51
        Me.DataGridView2.Size = New System.Drawing.Size(686, 427)
        Me.DataGridView2.TabIndex = 546
        Me.DataGridView2.Visible = False
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Font = New System.Drawing.Font("Consolas", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox2.Location = New System.Drawing.Point(770, 303)
        Me.RichTextBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(967, 444)
        Me.RichTextBox2.TabIndex = 543
        Me.RichTextBox2.Text = ""
        Me.RichTextBox2.Visible = False
        '
        'LabelPartNumber
        '
        Me.LabelPartNumber.AutoSize = True
        Me.LabelPartNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPartNumber.Location = New System.Drawing.Point(3, 237)
        Me.LabelPartNumber.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelPartNumber.Name = "LabelPartNumber"
        Me.LabelPartNumber.Size = New System.Drawing.Size(221, 29)
        Me.LabelPartNumber.TabIndex = 542
        Me.LabelPartNumber.Text = "Part Number (PN)"
        Me.LabelPartNumber.Visible = False
        '
        'SerialPortPS
        '
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.RichTextBox1.Location = New System.Drawing.Point(8, 285)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(735, 614)
        Me.RichTextBox1.TabIndex = 529
        Me.RichTextBox1.Text = ""
        Me.RichTextBox1.WordWrap = False
        '
        'FW_UPDATE1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1924, 1055)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Re_checkAT)
        Me.Controls.Add(MACLabel)
        Me.Controls.Add(Label5)
        Me.Controls.Add(Me.MACTextBox4)
        Me.Controls.Add(Me.MACTextBox3)
        Me.Controls.Add(Label7)
        Me.Controls.Add(Label8)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.CheckBoxShowCOM)
        Me.Controls.Add(Me.AT_COM)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CheckBoxRWO)
        Me.Controls.Add(Me.ComboBoxModel)
        Me.Controls.Add(Me.StopBT)
        Me.Controls.Add(Me.Start_BT)
        Me.Controls.Add(Me.LabelProgressBarFCT)
        Me.Controls.Add(Me.TestingtimeStart1)
        Me.Controls.Add(Me.MACTextBox2)
        Me.Controls.Add(Me.SerialTextBox)
        Me.Controls.Add(Me.RichTextBox3)
        Me.Controls.Add(Me.IMEITextBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.ERASE_PROG)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.ComboBoxKGB)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LabelIPSQL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBoxVoltTest)
        Me.Controls.Add(Me.PanelCOM)
        Me.Controls.Add(Me.TextBoxTemp)
        Me.Controls.Add(Me.ForceStopBT)
        Me.Controls.Add(Me.TestTodayOKLabel)
        Me.Controls.Add(Me.Date_testDate)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ComboBoxBadgeId)
        Me.Controls.Add(Me.ComboBoxOpName)
        Me.Controls.Add(Me.ComboBoxRWO_Id)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.SendBT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxFirmwCheck)
        Me.Controls.Add(Label4)
        Me.Controls.Add(Label3)
        Me.Controls.Add(Total_Test_TimeLabel)
        Me.Controls.Add(Me.tempBT)
        Me.Controls.Add(Me.ResultTextBoxFCT)
        Me.Controls.Add(Me.Total_Test_TimeTextBox)
        Me.Controls.Add(Me.LabelModBuildNumber)
        Me.Controls.Add(Me.Clock_Label)
        Me.Controls.Add(Me.LabelProgressBarFirm)
        Me.Controls.Add(OperatorBadgeID)
        Me.Controls.Add(SerialNum)
        Me.Controls.Add(TimeLabel)
        Me.Controls.Add(Date_testLabel)
        Me.Controls.Add(Me.TestTodayFAILLabel)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(SN_DUTLabel)
        Me.Controls.Add(Operator_testLabel)
        Me.Controls.Add(RWO_IdLabel)
        Me.Controls.Add(Me.RichTextBoxTemp)
        Me.Controls.Add(ModelLabel)
        Me.Controls.Add(Me.MACsw0TextBox)
        Me.Controls.Add(Me.ProgressBarFirm)
        Me.Controls.Add(Me.ProgressBarFCT)
        Me.Controls.Add(Me.Date_Label)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.LabelPartNumber)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FW_UPDATE1"
        Me.Text = "Sierra FIRMWARE Update 1"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCOM.ResumeLayout(False)
        Me.PanelCOM.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ExcelDialog As SaveFileDialog
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdminToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MACBarcodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Button8 As Button
    Friend WithEvents Re_checkAT As Button
    Friend WithEvents MACTextBox4 As TextBox
    Friend WithEvents MACTextBox3 As TextBox
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents CheckBoxShowCOM As CheckBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents AT_COM As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents CheckBoxRWO As CheckBox
    Friend WithEvents ComboBoxModel As ComboBox
    Friend WithEvents StopBT As Button
    Friend WithEvents Start_BT As Button
    Friend WithEvents LabelProgressBarFCT As Label
    Friend WithEvents TestingtimeStart1 As TextBox
    Friend WithEvents MACTextBox2 As TextBox
    Friend WithEvents SerialTextBox As TextBox
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents IMEITextBox1 As TextBox
    Friend WithEvents Button5 As Button
    Friend WithEvents ERASE_PROG As Button
    Friend WithEvents TimerDetect As Timer
    Friend WithEvents TimerDetect218 As Timer
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button6 As Button
    Friend WithEvents ComboBoxKGB As ComboBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents LabelIPSQL As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboBoxVoltTest As ComboBox
    Friend WithEvents PanelCOM As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents PORT_FW As ComboBox
    Friend WithEvents HUB_FW As ComboBox
    Friend WithEvents CheckBoxAutoCOM_DUT As CheckBox
    Friend WithEvents ComboBoxCOMModTester As ComboBox
    Friend WithEvents ConnectDUT As Button
    Friend WithEvents RefreshBT As Button
    Friend WithEvents ComboBoxBRModTester As ComboBox
    Friend WithEvents PSTestBT As Button
    Friend WithEvents ComboBoxCOMPS As ComboBox
    Friend WithEvents PSConnectSerial As Button
    Friend WithEvents RefreshPS As Button
    Friend WithEvents ComboBoxBaudRPS As ComboBox
    Friend WithEvents DisconnectBT As Button
    Friend WithEvents PSDisConnectSerial As Button
    Friend WithEvents LabelInfo As Label
    Friend WithEvents RestartModTesterBT As Button
    Friend WithEvents TextBoxTemp As TextBox
    Friend WithEvents ForceStopBT As Button
    Friend WithEvents TestTodayOKLabel As Label
    Friend WithEvents TimerDetect225 As Timer
    Friend WithEvents Date_testDate As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ComboBoxBadgeId As ComboBox
    Friend WithEvents ComboBoxOpName As ComboBox
    Friend WithEvents ComboBoxRWO_Id As ComboBox
    Friend WithEvents Button4 As Button
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents SendBT As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxFirmwCheck As TextBox
    Friend WithEvents tempBT As Button
    Friend WithEvents ResultTextBoxFCT As TextBox
    Friend WithEvents Total_Test_TimeTextBox As TextBox
    Friend WithEvents LabelModBuildNumber As Label
    Friend WithEvents Clock_Label As Label
    Friend WithEvents LabelProgressBarFirm As Label
    Friend WithEvents TestTodayFAILLabel As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents RichTextBoxTemp As RichTextBox
    Friend WithEvents MACsw0TextBox As TextBox
    Friend WithEvents ProgressBarFirm As ProgressBar
    Friend WithEvents ProgressBarFCT As ProgressBar
    Friend WithEvents Date_Label As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents LabelPartNumber As Label
    Friend WithEvents SerialPortPS As IO.Ports.SerialPort
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
