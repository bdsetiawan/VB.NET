Imports System
Imports System.Threading
Imports System.IO.Ports
Imports System.ComponentModel
'Imports System.Net.NetworkInformation
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Collections.Specialized.BitVector32
Imports System.IO
Imports System.Runtime.InteropServices
'Imports System.Net.Http
'Imports System.Data.Odbc
'Imports Microsoft.Office.Interop.Excel
Imports System.Runtime.InteropServices.ComTypes
Imports System.Reflection
Imports System.Diagnostics.Contracts
Imports System.Xml.Schema
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ListView
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button
'Imports OpenGear

Imports System.Net
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Imports System.Reflection.Emit
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic.Logging
Imports System.Windows.Shell
Imports System.Windows.Controls
'Imports Microsoft.SqlServer.Server

'Imports System.Runtime.Remoting.Messaging
'Imports System.Windows.Forms.AxHost
'Imports VB = Microsoft.VisualBasic
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
'Imports System.Windows.Forms.VisualStyles
'Imports System.Net.Http
'Imports System.Net.Security
'Imports Microsoft.Office.Interop
'Imports Excel = Microsoft.Office.Interop.Excel
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement
'Imports GemBox.Spreadsheet

Module MyVariables
    Public Upgrade_Firm_process As String '= ""
    Public Flexy_Pasang As String '= ""
    Public fail_reason, fail1, fail2, fail3, fail4 As String
    Public path_log1 As String = "D:\SIERRA_TEST\Firmware_1\result_1\"  'update_
    Public path_log2 As String = "D:\SIERRA_TEST\Firmware_2\result_2\"  'update_
End Module
Module Wait_Function
    Public Sub Delay(ByVal dblsecs As Double)
        Const onesec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(onesec)
        dblWaitTil = Now.AddSeconds(onesec).AddSeconds(dblsecs)
        Do Until Now > dblWaitTil
            Application.DoEvents()
        Loop
    End Sub

End Module



Public Class FW_UPDATE1

    Dim myPort, myPortPS As Array
    'Dim workbook As Workbook = New Workbook()
    'Dim Testing_end As DateTime

    'Dim LED_Check_result As String

    Public Property IntLists As Object
    'Public Property ExcelFile As Object
    'Public Property MyExcel As Object

    'Public Property DB_PATH = @"" 
    'Public Property BindingList<Employee> EmpList = New BindingList<Employee>()
    'Public Property Excel.Workbook MyBook = null
    'Private Static Excel.Application MyApp = null;
    'Private Static Excel.Worksheet MySheet = null;
    'Private Static int lastRow=0;
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data


    'Dim str As String = "server=10.218.164.222\SQLEXPRESS;database=Console_Manager;uid=sa;password=sapassword;"  'ok
    Dim str As String = "server=10.218.164.217,1433;database=Console_Manager;uid=sa;password=sapassword;"  'ok remote

    'Dim str As String = "server=10.218.164.221\SQLEXPRESS;database=Console_Manager;uid=test_user;password=test_user1;"  'ok
    'Dim str As String = "server=10.218.164.221\SQLEXPRESS;database=TestDB;uid=sa;password=sapassword;"
    Dim conn As New SqlConnection(str)

    Dim intResponse1, intResponse2, intResponse3, intResponse4, intResponse5, intResponse6, intResponse7 As Integer



    Dim n, No_ As Long ' = 0
    Dim testing_batal As String

    'PASS/NOT PASS
    Dim dataMAC_result,
        dataPN_result,
        dataPassword_result,
        dataVPD_result,
        dataPOST_result,
        dataEOS_result,
        dataImage_result,
        dataPersonalityTest_result,
        dataMemAddrs_result,
        dataChecksector_result,
        dataTimerTest_result,
        ModuleReady_result,
        statusfinaltest_result,
        data_Loopback_result As String

    Dim dataTestingport3A_result,
        dataTestingport3B_result,
        dataTestingport3C_result,
        dataTestingport3D_result,
        dataTestingport2A_result,
        dataTestingport2B_result,
        dataTestingport2C_result,
        dataTestingport2D_result,
        dataTestingport1A_result,
        dataTestingport1B_result,
        dataTestingport1C_result,
        dataTestingport1D_result,
        dataTestingport0A_result,
        dataTestingport0B_result,
        dataTestingport0C_result,
        dataTestingport0D_result As String

    Dim RWObyOperator, From_RichTextBox3 As String

    Dim Log_File_Data,
        XML_File_Data,
        IMAGE_File_Data As String

    Dim CekMACDB As String
    Dim CekMAC() As String
    Dim GetMAC1, GetMAC2, GETMAC3, GETMAC4 As String
    Dim GetMAC1_new, GetMAC2_new, GetMAC3_new, GetMAC4_new As String

    Dim Power_data, Current_data As String

    Dim MAC1, MAC2, MAC3, MAC4, MACsw0 As String
    Dim self_test, GreenLED_on, OrangeLED_on, offLED, LED_sequence As String
    Dim verify_all_mac, write_all_mac As String
    Dim Primary_fail, Secondary_fail, Device_fail, Upgrade_Firm, imei_log As String



    'Private data As New List(Of String())
    Dim csvPath As String


    'Dim arr() As String
    Dim s1, s2, s3, s4 As Long

    Dim row_new As Long


    'Dim BootLoaderPN_tester, POSTPN_Tester, EOSPN_Tester As String
    'Dim BootLoaderVB_tester, POSTVB_Tester, EOSVB_Tester As String


    'read from embeded test
    Dim BootLoaderPN_tester_val_embd,
        POSTPN_Tester_val_embd,
        EOSPN_Tester_val_embd,
        BootLoaderVB_tester_val_embd,
        POSTVB_Tester_val_embd,
        EOSVB_Tester_val_embd,
        MAC_VMtester_value_short_embd,
        MAC_VMtester_value_long_embd As String

    Dim ScanPackingNum As String

    Dim Model_PN_val_ref,
        Build_Num_val_ref,
        ProductName_val_ref,
        BootLoaderPN_tester_val_ref,
        POSTPN_Tester_val_ref,
        EOSPN_Tester_val_ref,
        BootLoaderVB_tester_val_ref,
        POSTVB_Tester_val_ref,
        EOSVB_Tester_val_ref,
        Passw_Avail_val_ref As String

    Dim testFCTnumber_val_ref,
        testFirmnumber_val_ref As Integer

    'MATCH/NOT MATCH
    Dim BootLoaderPN_tester_result,
        POSTPN_Tester_result,
        EOSPN_Tester_result,
        BootLoaderVB_tester_result,
        POSTVB_Tester_result,
        EOSVB_Tester_result,
        MAC_Check_result As String





    Public Sub Delay1(ByVal dblsecs As Double)
        Const onesec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(onesec)
        dblWaitTil = Now.AddSeconds(onesec).AddSeconds(dblsecs)
        Do Until Now > dblWaitTil
            Application.DoEvents()

        Loop
    End Sub


    Private Sub CheckBoxShowCOM_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowCOM.CheckedChanged
        If CheckBoxShowCOM.Checked = True Then
            'If CheckBoxShowCOM.CheckedChanged() = vbTrue Then
            PanelCOM.Show()
            'Me.Size = New System.Drawing.Size(490, 800)
        Else
            PanelCOM.Hide()
            'Me.Size = New System.Drawing.Size(490, 595)
        End If

        'PanelCOM.Show()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        refresh_op_name_()
    End Sub

    Private Sub Button1_Click_3(sender As Object, e As EventArgs) Handles Button1.Click
        refresh_op_name_()
    End Sub
    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click 'refresh RWO, operator name, dll
        refresh_op_name_()
    End Sub

    Sub refresh_op_name_()

        ComboBoxRWO_Id.Items.Clear()
        filePath5_ = "D:\SIERRA_TEST\Data\RWOID.txt"
        ComboBoxRWO_Id.Items.AddRange(System.IO.File.ReadAllLines(filePath5_))
        ComboBoxRWO_Id.Text = ComboBoxRWO_Id.Items(0).ToString()


        ComboBoxOpName.Items.Clear()
        filePath6_ = "D:\SIERRA_TEST\Data\Operator_Name.txt"
        ComboBoxOpName.Items.AddRange(System.IO.File.ReadAllLines(filePath6_))
        ComboBoxOpName.Text = ComboBoxOpName.Items(0).ToString()

        ComboBoxBadgeId.Items.Clear()
        filePath7_ = "D:\SIERRA_TEST\Data\BadgeID.txt"
        ComboBoxBadgeId.Items.AddRange(System.IO.File.ReadAllLines(filePath7_))
        ComboBoxBadgeId.Text = ComboBoxBadgeId.Items(0).ToString()

    End Sub


    Dim row_ As Long
    'Dim TestingDateStart As DateTime
    Dim TestingtimeEnd As DateTime
    Dim TestingtimeStart As DateTime
    Dim TestingtimeStart_awal As DateTime
    Dim TestingtimeStart_fct As DateTime

    'Dim Duration As TimeSpan

    Dim Receive_Text As String


    Dim filePath1_,
        filePath2_,
        filePath3_,
        filePath4_,
        filePath5_,
        filePath6_,
        filePath7_,
        filePath8_,
        filepath1a,
        filepath1b As String

    'Dim byteMAC As Byte


    Sub RWO_CEK()
        '-------------------------cek RWO from MAC-----------------------
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls 'Tls12
        Dim json As String = New System.Net.WebClient().DownloadString("http://10.206.110.46/production/production.asmx/searchwip?serialnumber=" & SerialTextBox.Text)

        'https://www.newtonsoft.com/json/help/html/SelectToken.htm
        Dim parsejson As JObject = JObject.Parse(json)
        Dim theRWO = parsejson.SelectToken("wip[0].RWO").ToString() 'arti [] untuk memilih RWO di atasnya atau bawahnya tp masih di dalam wip


        ComboBoxRWO_Id.Text = theRWO

        If ComboBoxRWO_Id.Text = "" Then
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "RWO ID", "NO DATA, check RWO Aegis, or manual input", Color.Orange)
            testing_batal = "YES"
            MessageBox.Show("Please check RWO Aegis, or manual input", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBoxRWO_Id.Select()
            Exit Sub
        End If
        '----------------------------------------------------------------

    End Sub
    Private Sub CheckBoxRWO_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRWO.CheckedChanged
        If CheckBoxRWO.Checked = True Then
            ComboBoxRWO_Id.Enabled = True
            filePath5_ = "D:\SIERRA_TEST\Data\RWOID.txt"
            ComboBoxRWO_Id.Items.AddRange(System.IO.File.ReadAllLines(filePath5_))
            ComboBoxRWO_Id.Text = ComboBoxRWO_Id.Items(0).ToString()
        Else
            ComboBoxRWO_Id.Enabled = False
        End If


    End Sub
    Private Sub ComboBoxRWO_Id_SelectedIndexChanged(sender As Object, e As KeyEventArgs) Handles ComboBoxRWO_Id.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim writer5 As New StreamWriter("D:\SIERRA_TEST\Data\RWOID.txt")
            ComboBoxRWO_Id.Text = ComboBoxRWO_Id.Text.ToUpper()
            writer5.WriteLine(ComboBoxRWO_Id.Text)
            writer5.Close()
            'Form50000792_01.OperatorBadgeIDTextBox.Text = ComboBoxBadgeID.Text


        End If
    End Sub

    Private Sub FW_UPDATE1_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        'CheckBoxRWO.Checked = False
        ComboBoxModel.Select()


        'update_
        'pc opg-225
        '#1 
        'ComboBoxCOMModTester.Text = "COM15"
        '#2 
        'ComboBoxCOMModTester.Text = "COM17" 

        'pc port server
        '#1
        'ComboBoxCOMModTester.Text = "COM13"
        '#2
        'ComboBoxCOMModTester.Text = "COM15" 



        'On Error GoTo ErrorHandler

        'Application.EnableVisualStyles()
        'Application.SetCompatibleTextRenderingDefault(True)
        'Application.SetCompatibleTextRenderingDefault(False)
        'Me.WindowState = FormWindowState.Maximized
        Me.Size = New System.Drawing.Size(950, 820)
        MaximizeBox = False

        CheckBoxAutoCOM_DUT.Checked = True

        ForceStopBT.BackColor = Color.LightBlue
        ERASE_PROG.BackColor = Color.LightBlue
        PanelCOM.Hide()


        ComboBoxKGB.Hide()
        ComboBoxVoltTest.Hide()
        Label2.Hide()

        'myPort = IO.Ports.SerialPort.GetPortNames()
        'ComboBoxCOMModTester.Items.AddRange(myPort)

        'myPortPS = IO.Ports.SerialPort.GetPortNames()
        'ComboBoxCOMPS.Items.AddRange(myPortPS)

        SendBT.Enabled = False
        'TODO: This line of code loads data into the 'Testing1DataSet.TesterPort' table. You can move, or remove it, as needed.
        'Me.TesterPortTableAdapter.Fill(Me.Testing1DataSet.TesterPort)


        Total_Test_TimeTextBox.Text = "00:00:00"

        Date_testDate.Text = Format(Now, "dd-MMM-yyyy") 'samakan format ini dengan csv/excel




        LabelProgressBarFirm.Text = ""
        LabelProgressBarFCT.Text = ""

        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss") ' HH=jam 00-23, hh=AM atau PM
        'TestingtimeStart = TestingtimeStart1.Text
        'RWO_IdTextBox.Select()

        ResultTextBoxFCT.Clear()
        TextBoxFirmwCheck.Clear()
        ResultTextBoxFCT.BackColor = Color.White
        TextBoxFirmwCheck.BackColor = Color.White


        'edit
        'RWO_IdTextBox.Text = Model_Menu_Form.ComboBoxRWO.Text
        'Operator_testTextBox.Text = Model_Menu_Form.ComboBoxOpName.Text
        'OperatorBadgeIDTextBox.Text = Model_Menu_Form.ComboBoxBadgeID.Text

        'ComboBox1.Text = "Please Select COM"
        'ComboBox2.Text = "Please Select Baud Rate"
        'RWO_IdTextBox.Text = "Please Input RWO ID"
        'Operator_testTextBox.Text = "Please Input Operator Name"
        'OperatorBadgeIDTextBox.Text = "Please Input Operator Badge ID"


        'ComboBoxCOMModTester.Text = ComboBoxCOMModTester.Text
        'ComboBoxBRModTester.Text = ComboBoxBRModTester.Text
        'ComboBoxCOMPS.Text = ComboBoxCOMPS.Text
        'ComboBoxBaudRPS.Text = ComboBoxBaudRPS.Text



        filepath1a = "D:\SIERRA_TEST\Data\COM_ModTester1.txt" 'update_
        ComboBoxCOMModTester.Items.AddRange(System.IO.File.ReadAllLines(filepath1a))
        'ComboBoxRWO.Text.LastIndexOf(System.IO.File.ReadAllLines(filePath2))
        'ComboBoxRWO.Text = ComboBoxRWO.Items.IndexOf(2)
        ComboBoxCOMModTester.Text = ComboBoxCOMModTester.Items(0).ToString()
        'ComboBoxRWO.Items.Clear()

        'filePath1b = "D:\SIERRA_TEST\Data\COM_ModTester2.txt"
        'ComboBoxCOMModTester.Items.AddRange(System.IO.File.ReadAllLines(filePath1b))
        'ComboBoxRWO.Text.LastIndexOf(System.IO.File.ReadAllLines(filePath2))
        'ComboBoxRWO.Text = ComboBoxRWO.Items.IndexOf(2)
        'ComboBoxCOMModTester.Text = ComboBoxCOMModTester.Items(0).ToString()
        'ComboBoxRWO.Items.Clear()


        filePath2_ = "D:\SIERRA_TEST\Data\BR_ModTester.txt"
        ComboBoxBRModTester.Items.AddRange(System.IO.File.ReadAllLines(filePath2_))
        ComboBoxBRModTester.Text = ComboBoxBRModTester.Items(0).ToString()
        'ComboBoxOpName.Items.Clear()

        filePath3_ = "D:\SIERRA_TEST\Data\COM_PS.txt"
        ComboBoxCOMPS.Items.AddRange(System.IO.File.ReadAllLines(filePath3_))
        ComboBoxCOMPS.Text = ComboBoxCOMPS.Items(0).ToString()
        'ComboBoxBadgeID.Items.Clear()

        filePath4_ = "D:\SIERRA_TEST\Data\BR_PS.txt"
        ComboBoxBaudRPS.Items.AddRange(System.IO.File.ReadAllLines(filePath4_))
        ComboBoxBaudRPS.Text = ComboBoxBaudRPS.Items(0).ToString()
        'ComboBoxBadgeID.Items.Clear()






        filePath5_ = "D:\SIERRA_TEST\Data\RWOID.txt"
        ComboBoxRWO_Id.Items.AddRange(System.IO.File.ReadAllLines(filePath5_))
        ComboBoxRWO_Id.Text = ComboBoxRWO_Id.Items(0).ToString()

        'filePath5_ = "D:\SIERRA_TEST\Data\RWOID.txt"
        'RWO_IdTextBox.Text = (System.IO.File.ReadAllLines(filePath5_)).ToString
        'Using textReader As New System.IO.StreamReader(filePath5_)
        'RWO_IdTextBox.Text = textReader.ReadToEnd()
        'End Using
        'RWO_IdTextBox.Enabled = False
        'ComboBoxRWO.Text.LastIndexOf(System.IO.File.ReadAllLines(filePath2))
        'ComboBoxRWO.Text = ComboBoxRWO.Items.IndexOf(2)
        'ComboBoxRWO.Text = ComboBoxRWO.Items(0).ToString()
        'ComboBoxRWO.Items.Clear()


        filePath6_ = "D:\SIERRA_TEST\Data\Operator_Name.txt"
        ComboBoxOpName.Items.AddRange(System.IO.File.ReadAllLines(filePath6_))
        ComboBoxOpName.Text = ComboBoxOpName.Items(0).ToString()

        'filePath6_ = "D:\SIERRA_TEST\Data\Operator_Name.txt"
        'Using textReader As New System.IO.StreamReader(filePath6_)
        'Operator_testTextBox.Text = textReader.ReadToEnd()
        'End Using
        'Operator_testTextBox.Enabled = False
        'Operator_testTextBox.Text = System.IO.File.ReadAllLines(filePath6_).ToString
        'ComboBoxOpName.Text = ComboBoxOpName.Items(0).ToString()
        'ComboBoxOpName.Items.Clear()


        filePath7_ = "D:\SIERRA_TEST\Data\BadgeID.txt"
        ComboBoxBadgeId.Items.AddRange(System.IO.File.ReadAllLines(filePath7_))
        ComboBoxBadgeId.Text = ComboBoxBadgeId.Items(0).ToString()


        'filePath8_ = "D:\SIERRA_TEST\Data\Model.txt"
        'ComboBoxModel.Items.Clear()
        'ComboBoxModel.Items.AddRange(System.IO.File.ReadAllLines(filePath8_))
        'ComboBoxModel.Text = ComboBoxModel.Items(0).ToString()



        'Dim index As Integer
        'Index = ComboBoxModel.FindString(ComboBoxModel.Text)
        'ComboBoxModel.SelectedIndex = index

        'filePath7_ = "D:\SIERRA_TEST\Data\BadgeID.txt"
        'Using textReader As New System.IO.StreamReader(filePath7_)
        'OperatorBadgeIDTextBox.Text = textReader.ReadToEnd()
        'End Using
        'OperatorBadgeIDTextBox.Enabled = False
        'OperatorBadgeIDTextBox.Text = System.IO.File.ReadAllLines(filePath7_).ToString
        'ComboBoxBadgeID.Text = ComboBoxBadgeID.Items(0).ToString()
        'ComboBoxBadgeID.Items.Clear()



        '-----------------------------------------------------

        'ComboBox1.Text = "COM14"
        'COMPSComboBox.Text = "COM3"

        'SerialPort1.PortName = "COM13"
        'SerialPort1.BaudRate = 9600
        'SerialPort1.Open()
        'ComboBox1.Text = "COM13"
        'ComboBox2.Text = "9600"


        'SerialPortPS.PortName = "COM9"
        'SerialPortPS.BaudRate = 9600
        'SerialPortPS.Open()
        'COMPSComboBox.Text = "COM9"
        'BaudRPSComboBox.Text = "9600"



        '-----------------------------------------------------

        'ok
        DataGridView1.Columns.Add("No_", "No")
        DataGridView1.Columns.Add("Test Function_", "Test Function")
        DataGridView1.Columns.Add("Result_", "Result")
        DataGridView1.Columns.Add("Testing_Time", "Testing Time")

        With DataGridView1.ColumnHeadersDefaultCellStyle
            .BackColor = Color.LightGray
            .ForeColor = Color.White
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(DataGridView1.Font, FontStyle.Bold)
        End With



        '.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Rows(1).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DataGridView1.Columns(3).HeaderText = DataGridViewContentAlignment.MiddleCenter


        'DataGridView1.Columns[0].Width = 30
        'DataGridView1.Columns[1].Width = 250
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.Refresh()
        DataGridView1.AutoResizeColumns()

        Exit Sub

        '-------------------------------------------------------
        'show data table into datagrid2

        '-------------------------------------------------------
        'get reference value from SQL:

        'Dim txtName As String
        'Dim cmd_init As String = "SELECT [ModelPN] FROM [Console_Manager].[dbo].[Tbl_Console_Manager] WHERE ([Model_Build_Num] = '" & LabelModBuildNumber.Text & "' )"
        'Dim adapter As New SqlDataAdapter(cmd_show, conn)
        'txtName = IIf(IsDBNull(cmd_init.ExecuteScalar, "", cmd_init.ExecuteScalar))
        'txtName = cmd_init.
        'RichTextBox1.Text = txtName

        'DataGridView1.Rows(i).Cells(0).Value

        'sqlconn1 = New SqlConnection("Data Source=DESKTOP-FLP3OI6\SQLEXPRESS;Integrated Security=SSPI;")

        'retry1:
        conn.Open()

        'If LabelIPSQL.Text = "SQL Server IP  << Connection Test Fail" Then
        'If conn Is Nothing Then
        ''MsgBox("SERVER DOWN")
        'Dim result As Integer = MessageBox.Show("SERVER DOWN.. check/restart PC Server", "TESTING #1", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error)
        'If result = DialogResult.Abort Or result = DialogResult.Ignore Then
        'Me.Close()
        'End If

        'If result = DialogResult.Retry Then
        'GoTo retry1
        'End If
        'End If

        Dim strSQL_select As String = "SELECT 
         [Model_Build_Num]
         ,[ModelPN]
         ,[Test_NumFCT]
         ,[Test_NumFirm]
         ,[Product Name]
         ,[Boot-Loader PN]
         ,[Boot-Loader PN VB Rel]
         ,[Boot-Loader V0]
         ,[Boot-Loader V1]
         ,[POST PN]
         ,[POST PN VB Rel]
         ,[EOS PN]
         ,[EOS PN VB Rel]
         FROM [Console_Manager].[dbo].[Tbl_Initial_Data] WHERE [Model_Build_Num] = '" & LabelModBuildNumber.Text & "' And [ModelPN] = '" & LabelPartNumber.Text & "'"

        Dim sqlku As SqlCommand = New SqlCommand(strSQL_select, conn)

        'Dim sqlku As SqlCommand = New SqlCommand(strselect_sql, sqlconn1)
        Dim myReader As SqlDataReader
        myReader = sqlku.ExecuteReader
        sqlku = Nothing
        While myReader.Read()
            'RichTextBox1.Text &= myReader("Model") & vbCr
            'RichTextBox1.Text &= myReader("Operator_test") & vbCr
            'RichTextBox1.Text &= myReader("Station_test_Id") & vbCr
            Build_Num_val_ref = myReader("Model_Build_Num").trim()
            Model_PN_val_ref = myReader("ModelPN").trim()
            testFCTnumber_val_ref = myReader("Test_NumFCT").trim()
            testFirmnumber_val_ref = myReader("Test_NumFirm").trim()
            ProductName_val_ref = myReader("Product Name").trim()
            BootLoaderPN_tester_val_ref = myReader("Boot-Loader PN").trim()
            BootLoaderVB_tester_val_ref = myReader("Boot-Loader PN VB Rel").trim()
            POSTPN_Tester_val_ref = myReader("POST PN").trim()
            POSTVB_Tester_val_ref = myReader("POST PN VB Rel").trim()
            EOSPN_Tester_val_ref = myReader("EOS PN").trim()
            EOSVB_Tester_val_ref = myReader("EOS PN VB Rel").trim()
            '.replace(" ", "")

        End While
        conn.Close()



        LabelIPSQL.Text = "10.218.164.222   << Connection Test OK"


        sql2datagrid2()
        coloring_datagrid2()




        Exit Sub
        '+++++++++++++++++++++++++++++++++++++++
        '---------------------------------------
        'OK
        'Dim dt As DataTable = New DataTable
        DataGridView2.Columns.Add("No ", "No")
        DataGridView2.Columns.Add("Model/Build Number ", "Model/Build Number")
        DataGridView2.Columns.Add("RWO Id ", "RWO Id")
        DataGridView2.Columns.Add("Operator Name ", "Operator Name")
        DataGridView2.Columns.Add("Operator BadgeID ", "Operator BadgeID")
        DataGridView2.Columns.Add("Date Test ", "Date Test")
        DataGridView2.Columns.Add("Start Time ", "Start Time")
        DataGridView2.Columns.Add("End Time ", "End Time")
        DataGridView2.Columns.Add("Duration Test Time ", "Duration Test Time")
        DataGridView2.Columns.Add("ProductName ", "ProductName")
        DataGridView2.Columns.Add("MAC Scan ", "MAC Scan")
        DataGridView2.Columns.Add("Part Num Scan ", "Part Num Scan")
        DataGridView2.Columns.Add("Serial Num Scan ", "Serial Num Scan")
        DataGridView2.Columns.Add("VPD ", "VPD")
        DataGridView2.Columns.Add("POST ", "POST")
        DataGridView2.Columns.Add("EOS ", "EOS")
        DataGridView2.Columns.Add("Image loaded ", "Image loaded")
        DataGridView2.Columns.Add("Password Scan ", "Password Scan")
        DataGridView2.Columns.Add("Personality Test ", "Personality Test")
        DataGridView2.Columns.Add("Mem Addrs RAM test ", "Mem Addrs RAM test")
        DataGridView2.Columns.Add("Check sector locks ", "Check sector locks")
        DataGridView2.Columns.Add("Timer Test ", "Timer Test")

        DataGridView2.Columns.Add("Testing port 0 ", "Testing port 0")
        DataGridView2.Columns.Add("Testing port 0 (4-wire) ", "Testing port 0 (4-wire)")
        DataGridView2.Columns.Add("Testing port 0 (4-wire + term) ", "Testing port 0 (4-wire + term)")
        DataGridView2.Columns.Add("Testing port 0 (2-wire) ", "Testing port 0 (2-wire)")
        DataGridView2.Columns.Add("Testing port 1 ", "Testing port 1")
        DataGridView2.Columns.Add("Testing port 1 (4-wire) ", "Testing port 1 (4-wire)")
        DataGridView2.Columns.Add("Testing port 1 (4-wire + term) ", "Testing port 1 (4-wire + term)")
        DataGridView2.Columns.Add("Testing port 1 (2-wire) ", "Testing port 1 (2-wire)")
        DataGridView2.Columns.Add("Testing port 2 ", "Testing port 2")
        DataGridView2.Columns.Add("Testing port 2 (4-wire) ", "Testing port 2 (4-wire)")
        DataGridView2.Columns.Add("Testing port 2 (4-wire + term) ", "Testing port 2 (4-wire + term)")
        DataGridView2.Columns.Add("Testing port 2 (2-wire) ", "Testing port 2 (2-wire)")
        DataGridView2.Columns.Add("Testing port 3 ", "Testing port 3")
        DataGridView2.Columns.Add("Testing port 3 (4-wire) ", "Testing port 3 (4-wire)")
        DataGridView2.Columns.Add("Testing port 3 (4-wire + term) ", "Testing port 3 (4-wire + term)")
        DataGridView2.Columns.Add("Testing port 3 (2-wire) ", "Testing port 3 (2-wire)")
        DataGridView2.Columns.Add("FINAL FCT ", "FINAL FCT")

        DataGridView2.Columns.Add("MAC_Check ", "MAC_Check")
        DataGridView2.Columns.Add("BootLoaderPN_Firm ", "BootLoaderPN_Firm")
        DataGridView2.Columns.Add("POSTPN_Firm ", "POSTPN_Firm")
        DataGridView2.Columns.Add("EOSPN_Firm ", "EOSPN_Firm")
        DataGridView2.Columns.Add("BootLoaderVers.Firm ", "BootLoaderVBVers.Firm")
        DataGridView2.Columns.Add("POSTVBVers.Firm ", "POSTVBVers.Firm")
        DataGridView2.Columns.Add("EOSVBVers.Firm ", "EOSVBVers.Firm")
        DataGridView2.Columns.Add("FINAL FIRMWARE CHECK ", "FINAL FIRMWARE CHECK")
        '(nama header yg muncul di csv/text/dipanggil, nama header yg muncul di gridview)
        'nama header tidak harus sama dengan nama variable cell value

        'DataGridView2.DataSource = dt
        With DataGridView2.ColumnHeadersDefaultCellStyle
            .BackColor = Color.LightGray
            .ForeColor = Color.White
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(DataGridView2.Font, FontStyle.Bold)
        End With
        DataGridView2.AllowUserToAddRows = False
        DataGridView2.Refresh()
        DataGridView2.AutoResizeColumns()



        '---------------------------------------------------------------
        'read existing csv, convert to datagridview:
        Dim lines() As String
        Dim vals() As String

        lines = File.ReadAllLines("D:\SIERRA_TEST\DB.csv")

        For i As Long = 1 To lines.Length - 1 Step +1 'start from i=1=> without header  (membaca ada berapa garis)

            vals = lines(i).ToString().Split(",")  'membaca 1 garis dan split
            Dim row(vals.Length - 1) As String

            For j As Long = 0 To vals.Length - 1 Step +1

                row(j) = vals(j).Trim()  'proses trim per kata

                'If DataGridView1.Rows(i).Cells(row(j)).Value = "Fail" Then
                'If DataGridView1.Rows(i).Cells("Fail") Then
                'DataGridView2.Rows.Add(row) = Color.IndianRed 'ok
                'DataGridView2.Rows(i).DefaultCellStyle.BackColor = Color.IndianRed 'ok



            Next j

            DataGridView2.Rows.Add(row) 'input valuenya dalam cell


        Next i
        '-------------------------------------------------------------


        'Dim rowindex2 As Long



        For row_ = 1 To File.ReadAllLines("D:\SIERRA_TEST\Data\Initial Data.csv").Count

            'If GetValue(row, 1) = "50000792-01" Then
            If GetValue(row_, 1) = LabelModBuildNumber.Text Then 'Model_Menu_Form.ComboBox1.Text Then  
                'MsgBox(row & ", " & col & " = " & value)
                Build_Num_val_ref = GetValue(row_, 1)
                Model_PN_val_ref = GetValue(row_, 2)
                testFCTnumber_val_ref = GetValue(row_, 3)
                testFirmnumber_val_ref = GetValue(row_, 4)
                ProductName_val_ref = GetValue(row_, 5)
                BootLoaderPN_tester_val_ref = GetValue(row_, 6)
                BootLoaderVB_tester_val_ref = GetValue(row_, 7)
                POSTPN_Tester_val_ref = GetValue(row_, 10)
                POSTVB_Tester_val_ref = GetValue(row_, 11)
                EOSPN_Tester_val_ref = GetValue(row_, 12)
                EOSVB_Tester_val_ref = GetValue(row_, 13)

            End If
        Next

        Exit Sub

ErrorHandler:
        Throw New Exception(Err.Number & ": " & Err.Description)


    End Sub


    Private Sub RefreshPS_Click(sender As Object, e As EventArgs) Handles RefreshPS.Click
        'COMPSComboBox.Text = ""
        ComboBoxCOMPS.Items.Clear()
        'myPort = IO.Ports.SerialPort.GetPortNames()
        'ComboBox1.Items.AddRange(myPort)

        myPortPS = IO.Ports.SerialPort.GetPortNames()
        For i = 0 To UBound(myPortPS)
            ComboBoxCOMPS.Items.Add(myPortPS(i))
        Next

        ComboBoxBaudRPS.Items.Add("9600")
        ComboBoxBaudRPS.Items.Add("38400")
        ComboBoxBaudRPS.Items.Add("57600")
        ComboBoxBaudRPS.Items.Add("115200")
        'Set ComboBox1 text to first available port
        'COMPSComboBox.Text = COMPSComboBox.Items.Item(0)
        'Set SerialPort1 portname to first available port

        'COMPSComboBox.Text = "COM6"
        'ComboBox1.Text = "COM8"
        'BaudRPSComboBox.Text = "9600"
        'SerialPortPS.PortName = COMPSComboBox.Text
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles RefreshBT.Click 'refresh COM button
        'GetSerialPortNames()

        'ok for listing COM
        'ComboBox1.Text = ""
        ComboBoxCOMModTester.Items.Clear()
        'myPort = IO.Ports.SerialPort.GetPortNames()
        'ComboBox1.Items.AddRange(myPort)

        myPort = IO.Ports.SerialPort.GetPortNames()
        For i = 0 To UBound(myPort)
            ComboBoxCOMModTester.Items.Add(myPort(i))
        Next


        ComboBoxBRModTester.Items.Add("9600")
        ComboBoxBRModTester.Items.Add("38400")
        ComboBoxBRModTester.Items.Add("57600")
        ComboBoxBRModTester.Items.Add("115200")
        'Set ComboBox1 text to first available port
        'ComboBox1.Text = ComboBox1.Items.Item(0)
        'Set SerialPort1 portname to first available port

        'ComboBox1.Text = "COM13"
        'ComboBox1.Text = "COM8"
        'ComboBox2.Text = "9600"
        'SerialPort1.PortName = ComboBox1.Text


        'Set remaining port attributes
        'SerialPort1.BaudRate = 19200
        'SerialPort1.Parity = IO.Ports.Parity.None
        'SerialPort1.StopBits = IO.Ports.StopBits.One
        'SerialPort1.DataBits = 8

    End Sub


    Sub serial_DUT_auto_connect_FW_update()
        ComboBoxCOMModTester.Items.Clear()
        'myPort = IO.Ports.SerialPort.GetPortNames()
        'ComboBox1.Items.AddRange(myPort)

        myPort = IO.Ports.SerialPort.GetPortNames()
        For i = 0 To UBound(myPort)
            ComboBoxCOMModTester.Items.Add(myPort(i))

            'If myPort(i) <> "COM1" And myPort(i) <> "COM3" Then
            If myPort(i) <> "COM1" Then
                'MsgBox(myPort(i))
                ComboBoxCOMModTester.Text = myPort(i)
                DUTConnect()
            End If
        Next


        ComboBoxBRModTester.Items.Add("115200")
    End Sub
    Sub serial_DUT_auto_connect()
        ComboBoxCOMModTester.Items.Clear()
        'myPort = IO.Ports.SerialPort.GetPortNames()
        'ComboBox1.Items.AddRange(myPort)

        myPort = IO.Ports.SerialPort.GetPortNames()
        For i = 0 To UBound(myPort)
            ComboBoxCOMModTester.Items.Add(myPort(i))

            'If myPort(i) <> "COM1" And myPort(i) <> "COM3" Then
            If myPort(i) <> "COM1" Then
                'MsgBox(myPort(i))
                ComboBoxCOMModTester.Text = myPort(i)
                DUTConnect()
            End If
        Next

        ComboBoxBRModTester.Items.Add("9600")
        ComboBoxBRModTester.Items.Add("38400")
        ComboBoxBRModTester.Items.Add("57600")
        ComboBoxBRModTester.Items.Add("115200")
    End Sub
    Private Sub ConnectDUT_Click(sender As Object, e As EventArgs) Handles ConnectDUT.Click
        If ConnectDUT.Text Like "Connect DUT" Then
            DUTConnect()
        ElseIf ConnectDUT.Text Like "Disconnect DUT" Then
            DUTDisconnect()
        End If
    End Sub

    Private Sub PSConnectSerial_Click(sender As Object, e As EventArgs) Handles PSConnectSerial.Click
        If PSConnectSerial.Text Like "Connect PS" Then
            PSConnect()
        ElseIf PSConnectSerial.Text Like "Disconnect PS" Then
            PSDisconnect()
        End If
    End Sub
    'Private Sub ConnectBT_Click(sender As System.Object, e As System.EventArgs) Handles ConnectBT.Click
    'On Error GoTo error_connectBT
    Private Sub DUTConnect()
        If ComboBoxCOMModTester.Text = "" _
           Or ComboBoxCOMModTester.Text = "Select COM" _
           Or ComboBoxBRModTester.Text = "" _
           Or ComboBoxBRModTester.Text = "Select Baud Rate" Then

            MessageBox.Show("Check COM or Baud Rate, then click Connect", "TESTING #1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ConnectDUT.BackColor = Color.IndianRed
            'PSTestBT.BackColor = Color.IndianRed
            ComboBoxCOMModTester.Select()
            DUTDisconnect()
            Exit Sub
        End If

        If (ComboBoxCOMPS.Text <> ComboBoxCOMModTester.Text) Then 'And SerialPortPS.IsOpen() = False Then
            'jgn gunakan comboBox.selecteditem karena bisa ada error
            Try
                DUTDisconnect()


                SerialPort1.PortName = ComboBoxCOMModTester.Text
                SerialPort1.BaudRate = ComboBoxBRModTester.Text

                SerialPort1.Open()

                SerialPort1.DiscardOutBuffer()
                SerialPort1.DiscardInBuffer()



                ConnectDUT.Text = "Disconnect DUT"


                'SerialPort1.ReadBufferSize = 10000
                'SerialPort1.WriteBufferSize = 10000



                'ConnectDUT.Enabled = False
                SendBT.Enabled = True
                'DisconnectBT.Enabled = True
                'SerialPort1.DataBits
                'SerialPort1.DiscardNull
                'SerialPort1.Encoding
                'SerialPort1.ReadBufferSize
                'SerialPort1.BytesToRead

                If SerialPort1.IsOpen() = True Then
                    ConnectDUT.BackColor = Color.LightGreen
                End If

                Dim writer5 As New StreamWriter("D:\SIERRA_TEST\Data\COM_ModTester.txt")
                writer5.WriteLine(ComboBoxCOMModTester.Text)
                writer5.Close()

                Dim writer6 As New StreamWriter("D:\SIERRA_TEST\Data\BR_ModTester.txt")
                writer6.WriteLine(ComboBoxBRModTester.Text)
                writer6.Close()

            Catch ex As Exception
                ConnectDUT.Text = "Connect DUT"
                MsgBox(ex.Message, 262144)
                'Exit Sub
                'Debug.WriteLine("Serial COM can't connect :", ex)
            End Try

        Else
            MsgBox("COM sudah digunakan atau tukar COM lainnya", 262144)
            'Exit Sub
        End If


        'SerialPort1.ReadTimeout() = 100000
        'SerialPort1.WriteTimeout() = 100000

        'exit sub
        'error_connectBT:
        'MessageBox.Show("The Displayed text in the messagebox", 
        '"the text displayed in the title bar", MessageBoxButtons.YesNoCancel, 
        ' MessageBoxIcon.Error, MessageBoxDefaultButton.Button2)
        'MessageBox.Show("Please set COM# and BaudRate", "", MessageBoxButtons.OK,MessageBoxIcon.Error)
    End Sub


    Private Sub PSConnect()
        If ComboBoxCOMPS.Text = "" _
           Or ComboBoxCOMPS.Text = "Select COM" _
           Or ComboBoxBaudRPS.Text = "" _
           Or ComboBoxBaudRPS.Text = "Select Baud Rate" Then

            MessageBox.Show("Check COM or Baud Rate, then click Connect", "TESTING #1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PSConnectSerial.BackColor = Color.IndianRed
            'PSTestBT.BackColor = Color.IndianRed
            ComboBoxCOMPS.Select()
            Exit Sub
        End If

        If (ComboBoxCOMPS.Text <> ComboBoxCOMModTester.Text) Then 'And SerialPort1.IsOpen() = False Then
            'jgn gunakan comboBox.selecteditem karena bisa ada error

            Try
                'If SerialPortPS.IsOpen() = False Then
                PSConnectSerial.Text = "Disconnect PS"
                SerialPortPS.PortName = ComboBoxCOMPS.Text
                SerialPortPS.BaudRate = ComboBoxBaudRPS.Text
                SerialPortPS.Open()
                'PSConnectSerial.Enabled = False
                SendBT.Enabled = True

                'PSDisConnectSerial.Enabled = True
                'SerialPort1.DataBits
                'SerialPort1.DiscardNull
                'SerialPort1.Encoding
                'SerialPort1.ReadBufferSize
                'SerialPort1.BytesToRead
                If SerialPortPS.IsOpen() = True Then
                    PSConnectSerial.BackColor = Color.LightGreen
                    'PSTestBT.BackColor = Color.LightGreen

                End If

                Dim writer7 As New StreamWriter("D:\SIERRA_TEST\Data\COM_PS.txt")
                writer7.WriteLine(ComboBoxCOMPS.Text)
                writer7.Close()

                Dim writer8 As New StreamWriter("D:\SIERRA_TEST\Data\BR_PS.txt")
                writer8.WriteLine(ComboBoxBaudRPS.Text)
                writer8.Close()
                'End If

            Catch ex As Exception
                PSConnectSerial.Text = "Connect PS"
                MsgBox(ex.Message, 262144)
                'Debug.WriteLine("Serial COM can't connect :", ex)
            End Try
        Else
            MsgBox("COM sudah digunakan atau tukar COM lainnya", 262144)
        End If
    End Sub



    Private ReceiveProcRunning As Boolean
    Private SerialPortClosing As Boolean
    Dim Message As String
    Sub DUTDisconnect()



        Do Until ReceiveProcRunning = False
            Thread.Sleep(1)    'add System.Threading reference
        Loop


        If SerialPort1.IsOpen() = True Then
            ConnectDUT.Text = "Connect DUT"



            SerialPort1.Close()

            ConnectDUT.Enabled = True
            SendBT.Enabled = False
            'DisconnectBT.Enabled = False
            ConnectDUT.BackColor = Color.White

            'LabelInfo.Text = "Serial Tester NOT connected!"


        End If



        If SerialPortClosing = False Then
            ReceiveProcRunning = True
            Try
                Message = (SerialPort1.ReadTo("</msg>")) & "</msg>"
                'XMLBuffer.Enqueue(Message)
            Catch ex As Exception
                'MsgBox(ex.Message)
                'MsgBox(SerialPortClosing)
                'MsgBox(ReceiveProcRunning)

                'MyLog.Write("[port_DataReceived] " & Err.Description, LogError)
            End Try
            ReceiveProcRunning = False
        End If

    End Sub

    'Private Sub PSDisConnectSerial_Click(sender As Object, e As EventArgs) Handles PSDisConnectSerial.Click
    Private Sub PSDisconnect()
        If SerialPortPS.IsOpen() = True Then
            PSConnectSerial.Text = "Connect PS"


            SerialPortPS.Close()

            PSConnectSerial.Enabled = True
            SendBT.Enabled = False
            'PSDisConnectSerial.Enabled = False
            PSConnectSerial.BackColor = Color.White

            'PSConnectSerial.BackColor = Color.IndianRed
            'PSTestBT.BackColor = Color.IndianRed

            'LabelInfo.Text = "Serial Power Supply NOT connected!"
        End If
    End Sub
    '----------------------send data to serial--------------------------
    Private Sub SendBT_Click(sender As System.Object, e As System.EventArgs) Handles SendBT.Click



        'RichTextBox1.Text = "kkjflkdsajflsa"
        SerialPort1.WriteLine(TextBox1.Text)
        'SerialPort1.Write(TextBox1.Text & vbCr)
        'SerialPort1.Write(RichTextBox2.Text & vbCr) 'concatenate with \n
        'RichTextBox2.Select()
        'SerialPort1.DiscardOutBuffer()
        'SerialPort1.DiscardInBuffer()

        'SerialPort1.DiscardOutBuffer()
        'SerialPort1.DiscardInBuffer()
        'SerialPort1.ReadTimeout() = 100000
        'SerialPort1.WriteTimeout() = 100000
    End Sub



    Sub save_log_218_nga_dipakai()  'nga dipakai
        If ComboBoxModel.Text = "OPG-409218" Then
            If OrangeLED_on = "" Then
                OrangeLED_on = "NA"
            End If
            If GreenLED_on = "" Then
                GreenLED_on = "NA"
            End If
            If offLED = "" Then
                offLED = "NA"
            End If
        End If
    End Sub

    Sub save_log_FW_update()
        Dim sb = New System.Text.StringBuilder()
        'sb.Append("Software Name                 :  Open Gear Test Station " + ComboBoxModel.Text + vbNewLine)
        'sb.Append("Test Station ID               :  TS1" + vbNewLine)
        sb.Append("Operator Name                  :  " + ComboBoxOpName.Text.ToUpper() + vbNewLine)
        sb.Append("Operator ID                    :  " + ComboBoxBadgeId.Text + vbNewLine)
        'sb.Append("SN Modem                      :  " + SerialTextBox.Text + vbNewLine)
        sb.Append("Model                          :  " + ComboBoxModel.Text + vbNewLine)
        sb.Append("IMEI Modem                     :  " + IMEITextBox1.Text + vbNewLine)
        'sb.Append("Product Line                  :  EM8008-4E" + vbNewLine)
        'sb.Append("Product Model                 :  409225" + vbNewLine)
        sb.Append("Date                           :  " + Format(Now, "dd-MMM-yyyy") + vbNewLine) 'samakan format ini dengan csv/excel
        sb.Append("Time                           :  " + TestingtimeStart_awal.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("Start Test Time                :  " + TestingtimeStart_fct.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("End Test Time                  :  " + TestingtimeEnd.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("Total Test Time                :  " + Total_Test_TimeTextBox.Text + vbNewLine)
        sb.Append("Upgrade Firmware               :  " + Upgrade_Firm_process + vbNewLine)
        sb.Append("Overall Firmware Version       :  " + all_firm + vbNewLine)
        sb.Append("Overall Test Result            :  " + statusfinaltest_result + vbNewLine)
        sb.Append(vbNewLine)



        sb.Append("Verify ATT version             :  " + att + vbNewLine)
        sb.Append("Verify GENERIC version         :  " + generic + vbNewLine)
        sb.Append("Verify TELUS version           :  " + telus + vbNewLine)
        sb.Append("Verify TMO version             :  " + tmo + vbNewLine)
        sb.Append("Verify ROGERS version          :  " + rogers + vbNewLine)
        sb.Append("Verify VERIZON version         :  " + verizon + vbNewLine)
        sb.Append("Verify Prefer-Current version  :  " + prefer_current + vbNewLine)


        sb.Append(vbNewLine)
        sb.Append("-----------------------------------------------------" + vbNewLine)
        sb.Append(vbNewLine)
        sb.Append(RichTextBox1.Text)



        'tambahkan ini jika ingin memunculkan detail LOG generate by modem
        'Delay(6)
        'sb.Append(vbNewLine)
        'sb.Append("------------------------DETAIL LOG-----------------------------" + vbNewLine)
        'sb.Append(vbNewLine)
        'sb.Append(RichTextBox2.Text)

        'If ResultTextBoxFCT.Text = "PASS" Then

        RichTextBox1.Text = sb.ToString



        '=================================================================================================
        Dim sPath1 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG\", ComboBoxModel.Text)
        'Dim sPath2 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG\" + ComboBoxModel.Text + "\", ComboBoxRWO_Id.Text)
        'Dim sw As StreamWriter



        'If Not IO.Directory.Exists(sPath1) And Not IO.Directory.Exists(sPath2) Then
        If Not IO.Directory.Exists(sPath1) Then
            'If Not IO.Directory.Exists(sPath1) Then
            'IO.Directory.CreateDirectory(sPath1)
            'End If
            IO.Directory.CreateDirectory(sPath1)
            'MsgBox("folder created")
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG\" + ComboBoxModel.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            'WriteLine(RichTextBox1.Text = "dfds")

            Log_File_Data = ExcelDialog.FileName


            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)

        Else
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG\" + ComboBoxModel.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            Log_File_Data = ExcelDialog.FileName
            'Log_File_Data = MACTextBox.Text + "_" + PartNumberTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"

            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)
        End If
    End Sub



    Sub save_log_FW_update2()
        Dim sb = New System.Text.StringBuilder()
        'sb.Append("Software Name                 :  Open Gear Test Station " + ComboBoxModel.Text + vbNewLine)
        'sb.Append("Test Station ID               :  TS1" + vbNewLine)
        sb.Append("Operator Name                  :  " + ComboBoxOpName.Text.ToUpper() + vbNewLine)
        sb.Append("Operator ID                    :  " + ComboBoxBadgeId.Text + vbNewLine)
        'sb.Append("SN Modem                      :  " + SerialTextBox.Text + vbNewLine)
        sb.Append("Model                          :  " + ComboBoxModel.Text + vbNewLine)
        sb.Append("IMEI Modem                     :  " + IMEITextBox1.Text + vbNewLine)
        'sb.Append("Product Line                  :  EM8008-4E" + vbNewLine)
        'sb.Append("Product Model                 :  409225" + vbNewLine)
        sb.Append("Date                           :  " + Format(Now, "dd-MMM-yyyy") + vbNewLine) 'samakan format ini dengan csv/excel
        sb.Append("Time                           :  " + TestingtimeStart_awal.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("Start Test Time                :  " + TestingtimeStart_fct.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("End Test Time                  :  " + TestingtimeEnd.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("Total Test Time                :  " + Total_Test_TimeTextBox.Text + vbNewLine)
        sb.Append("Upgrade Firmware               :  " + Upgrade_Firm_process + vbNewLine)
        sb.Append("Overall Test Result            :  " + statusfinaltest_result + vbNewLine)
        sb.Append("Primary Fail                   :  " + Primary_fail + vbNewLine)
        sb.Append("Secondary Fail                 :  " + Secondary_fail + vbNewLine)
        sb.Append("Device Fail                    :  " + Device_fail + vbNewLine)

        sb.Append(vbNewLine)



        'sb.Append("Verify ATT version             :  " + att + vbNewLine)
        'sb.Append("Verify GENERIC version         :  " + generic + vbNewLine)
        'sb.Append("Verify TELUS version           :  " + telus + vbNewLine)
        'sb.Append("Verify TMO version             :  " + tmo + vbNewLine)
        'sb.Append("Verify US-CELLULAR version     :  " + rogers + vbNewLine)
        'sb.Append("Verify VERIZON version         :  " + verizon + vbNewLine)
        'sb.Append("Verify Prefer-Current version  :  " + prefer_current + vbNewLine)


        'sb.Append(vbNewLine)
        'sb.Append("-----------------------------------------------------" + vbNewLine)
        'sb.Append(vbNewLine)
        sb.Append(RichTextBox1.Text)

        'tambahkan ini jika ingin memunculkan detail LOG generate by modem
        'Delay(6)
        'sb.Append(vbNewLine)
        'sb.Append("------------------------DETAIL LOG-----------------------------" + vbNewLine)
        'sb.Append(vbNewLine)
        'sb.Append(RichTextBox2.Text)

        'If ResultTextBoxFCT.Text = "PASS" Then

        RichTextBox1.Text = sb.ToString



        '=================================================================================================
        Dim sPath1 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG\", ComboBoxModel.Text)
        'Dim sPath2 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG\" + ComboBoxModel.Text + "\", ComboBoxRWO_Id.Text)
        'Dim sw As StreamWriter



        'If Not IO.Directory.Exists(sPath1) And Not IO.Directory.Exists(sPath2) Then
        If Not IO.Directory.Exists(sPath1) Then
            'If Not IO.Directory.Exists(sPath1) Then
            'IO.Directory.CreateDirectory(sPath1)
            'End If
            IO.Directory.CreateDirectory(sPath1)
            'MsgBox("folder created")
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG\" + ComboBoxModel.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            'WriteLine(RichTextBox1.Text = "dfds")

            Log_File_Data = ExcelDialog.FileName


            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)

        Else
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG\" + ComboBoxModel.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            Log_File_Data = ExcelDialog.FileName
            'Log_File_Data = MACTextBox.Text + "_" + PartNumberTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"

            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)
        End If
    End Sub

    Sub save_log() 'richtextbox1

        'If LED_sequence = "" Then
        'LED_sequence = ""
        'End If

        Dim sb = New System.Text.StringBuilder()
        'sb.Append("==========================SUMMARY TEST====================")
        'sb.Append(vbNewLine)
        sb.Append("Software Name             :  Open Gear Test Station " + ComboBoxModel.Text + vbNewLine)
        sb.Append("Test Station ID           :  TS1" + vbNewLine)
        sb.Append("Operator Name             :  " + ComboBoxOpName.Text.ToUpper() + vbNewLine)
        sb.Append("Operator ID               :  " + ComboBoxBadgeId.Text + vbNewLine)
        sb.Append("SN DUT                    :  " + SerialTextBox.Text + vbNewLine)
        'sb.Append("Model                     :  409225" + vbNewLine)
        sb.Append("Model                     :  " + Trim(Mid(ComboBoxModel.Text, 5, 15)) + vbNewLine)
        'sb.Append("Product Line             :  EM8008-4E" + vbNewLine)
        'sb.Append("Product Model            :  409225" + vbNewLine)
        sb.Append("Date                      :  " + Format(Now, "dd-MMM-yyyy") + vbNewLine) 'samakan format ini dengan csv/excel
        sb.Append("Time                      :  " + TestingtimeStart_awal.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("Start Test Time           :  " + TestingtimeStart1.Text + vbNewLine)
        sb.Append("End Test Time             :  " + TestingtimeEnd.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("Total Test Time           :  " + Total_Test_TimeTextBox.Text + vbNewLine)

        sb.Append("MAC Net 1 Assigned        :  " + GetMAC1 + vbNewLine)
        sb.Append("MAC Net 2 Assigned        :  " + GetMAC2 + vbNewLine)

        If ComboBoxModel.Text = "OPG-409218" Then
            sb.Append("MAC Net 3 Assigned        :  " + GETMAC3 + vbNewLine)
            sb.Append("MAC Net 4 Assigned        :  " + GETMAC4 + vbNewLine)
        End If
        If ComboBoxModel.Text = "OPG-409259" Or ComboBoxModel.Text = "OPG-409225" Then
            sb.Append("MAC sw0   Assigned        :  " + GETMAC3 + vbNewLine)
        End If
        sb.Append("Bootloader Revision       :  EM8000 Bootloader 1.9.0-p.1" + vbNewLine)
        sb.Append("MFG Image Revision        :  EM8000 USB Stick with MFG Image (Dev Signed) 1.8.0-p.3" + vbNewLine)
        sb.Append("Power (W)                 :  " + Power_data + vbNewLine)
        sb.Append("Current (A)               :  " + Current_data + vbNewLine)
        sb.Append("LED Sequence              :  " + LED_sequence + vbNewLine)

        'sb.Append("LED Blink Check           :  " + LED_Check_result + vbNewLine)
        sb.Append("Overall Test Result       :  " + statusfinaltest_result + vbNewLine)
        'sb.Append("Voltage Testing           :  " + "" + "VDC" + vbNewLine)
        'sb.Append("Current Testing           :  " + "" + "ADC" + vbNewLine)

        sb.Append("-----------------------------------------------------" + vbNewLine)
        'sb.Append(vbNewLine)
        sb.Append("Login Status : " + login_status + vbNewLine)
        sb.Append("Write MAC# on Net 1 Status : " + write_MAC1 + vbNewLine)
        sb.Append("Write MAC# on Net 2 Status : " + write_MAC2 + vbNewLine)
        If ComboBoxModel.Text = "OPG-409259" Or ComboBoxModel.Text = "OPG-409225" Then
            sb.Append("Write MAC# on sw0   Status : " + write_MACsw0 + vbNewLine)
        End If

        If ComboBoxModel.Text = "OPG-409218" Then
            sb.Append("Write MAC# on Net 3 Status : " + write_MAC3 + vbNewLine)
            sb.Append("Write MAC# on Net 4 Status : " + write_MAC4 + vbNewLine)
        End If
        sb.Append("Reboot DUT Status : " + reboot_DUT + vbNewLine)
        sb.Append("Verification MAC# on Net 1 Status : " + verify_MAC1 + vbNewLine)
        sb.Append("Verification MAC# on Net 2 Status : " + verify_MAC2 + vbNewLine)
        If ComboBoxModel.Text = "OPG-409259" Or ComboBoxModel.Text = "OPG-409225" Then
            sb.Append("Verification MAC# on sw0   Status : " + verify_MACsw0 + vbNewLine)
        End If

        If ComboBoxModel.Text = "OPG-409218" Then
            sb.Append("Verification MAC# on Net 3 Status : " + verify_MAC3 + vbNewLine)
            sb.Append("Verification MAC# on Net 4 Status : " + verify_MAC4 + vbNewLine)
        End If
        sb.Append("Loopback DUT Status : " + loopback + vbNewLine)
        sb.Append("Selftest DUT Status : " + self_test + vbNewLine)

        sb.Append("=======================ORIGINAL LOG=======================")
        sb.Append(vbNewLine)
        sb.Append(RichTextBox1.Text)

        'If ResultTextBoxFCT.Text = "PASS" Then
        sb.Append(vbNewLine)
        'sb.Append("==========================================================" + vbNewLine)
        'sb.Append("Checksector Test                                  |" + dataChecksector_result + "|" + vbNewLine)
        'Check sector tidak ada di digione sp
        'sb.Append("Personality Test                                  |" + dataPersonalityTest_result + "|" + vbNewLine)
        'sb.Append("Mem Addrs RAM Test                                |" + dataMemAddrs_result + "|" + vbNewLine)
        'sb.Append(vbNewLine)
        sb.Append("=============================END==========================" + vbNewLine)
        'End If
        'TextBox.Rtf = sb.ToString
        RichTextBox1.Text = sb.ToString



        '=================================================================================================
        Dim sPath1 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG\", ComboBoxModel.Text)
        Dim sPath2 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG\" + ComboBoxModel.Text + "\", ComboBoxRWO_Id.Text)
        'Dim sw As StreamWriter



        'If Not IO.Directory.Exists(sPath1) And Not IO.Directory.Exists(sPath2) Then
        If Not IO.Directory.Exists(sPath2) Then
            If Not IO.Directory.Exists(sPath1) Then
                IO.Directory.CreateDirectory(sPath1)
            End If
            IO.Directory.CreateDirectory(sPath2)
            'MsgBox("folder created")
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            'WriteLine(RichTextBox1.Text = "dfds")

            Log_File_Data = ExcelDialog.FileName


            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)

        Else
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            Log_File_Data = ExcelDialog.FileName
            'Log_File_Data = MACTextBox.Text + "_" + PartNumberTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"

            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)
        End If

    End Sub
    Sub parsing_summary()


        For i As Integer = 0 To RichTextBox1.Lines.Count - 1
            Dim line As String = RichTextBox1.Lines(i)


            If line.Contains("| PASS |") Or line.Contains("| FAIL |") Then

                RichTextBox2.Text = RichTextBox2.Text & line & vbCrLf
            End If



        Next
        RichTextBox2.Text = Replace(RichTextBox2.Text, "| PASS |", ": PASS")

        RichTextBox2.Text = Replace(RichTextBox2.Text, "| FAIL |", ": FAIL")




    End Sub
    Sub save_log_summary()

        'If LED_sequence = "" Then
        'LED_sequence = ""
        'End If


        Dim sb = New System.Text.StringBuilder()
        'sb.Append("==========================SUMMARY TEST====================")
        'sb.Append(vbNewLine)
        sb.Append("Software Name             :  Open Gear Test Station " + ComboBoxModel.Text + vbNewLine)
        sb.Append("Test Station ID           :  TS1" + vbNewLine)
        sb.Append("Operator Name             :  " + ComboBoxOpName.Text.ToUpper() + vbNewLine)
        sb.Append("Operator ID               :  " + ComboBoxBadgeId.Text + vbNewLine)
        sb.Append("SN DUT                    :  " + SerialTextBox.Text + vbNewLine)
        'sb.Append("Model                     :  409225" + vbNewLine)
        sb.Append("Model                     :  " + Trim(Mid(ComboBoxModel.Text, 5, 15)) + vbNewLine)
        'sb.Append("Product Line             :  EM8008-4E" + vbNewLine)
        'sb.Append("Product Model            :  409225" + vbNewLine)
        sb.Append("Date                      :  " + Format(Now, "dd-MMM-yyyy") + vbNewLine) 'samakan format ini dengan csv/excel
        sb.Append("Time                      :  " + TestingtimeStart_awal.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("Start Test Time           :  " + TestingtimeStart1.Text + vbNewLine)
        sb.Append("End Test Time             :  " + TestingtimeEnd.ToString("HH':'mm':'ss") + vbNewLine)
        sb.Append("Total Test Time           :  " + Total_Test_TimeTextBox.Text + vbNewLine)

        'sb.Append("RWO Id                    :  " + ComboBoxRWO_Id.Text + vbNewLine)
        'sb.Append("Password Scan             :  " + PasswordTextBox.Text + vbNewLine)
        'sb.Append("Product Name              :  " + ProductName_val_ref + vbNewLine)

        sb.Append("MAC Net 1 Assigned        :  " + GetMAC1 + vbNewLine)
        sb.Append("MAC Net 2 Assigned        :  " + GetMAC2 + vbNewLine)

        If ComboBoxModel.Text = "OPG-409218" Then
            sb.Append("MAC Net 3 Assigned        :  " + GETMAC3 + vbNewLine)
            sb.Append("MAC Net 4 Assigned        :  " + GETMAC4 + vbNewLine)
        End If

        If ComboBoxModel.Text = "OPG-409259" Or ComboBoxModel.Text = "OPG-409225" Then
            sb.Append("MAC sw0   Assigned        :  " + GETMAC3 + vbNewLine)
        End If

        sb.Append("Bootloader Revision       :  EM8000 Bootloader 1.9.0-p.1" + vbNewLine)
        sb.Append("MFG Image Revision        :  EM8000 USB Stick with MFG Image (Dev Signed) 1.8.0-p.3" + vbNewLine)
        sb.Append("Power (W)                 :  " + Power_data + vbNewLine)
        sb.Append("Current (A)               :  " + Current_data + vbNewLine)
        sb.Append("LED Sequence              :  " + LED_sequence + vbNewLine)
        'sb.Append("LED Sequence              :  PASS" + vbNewLine)
        'sb.Append("LED Blink Check           :  " + LED_Check_result + vbNewLine)
        sb.Append("Overall Test Result       :  " + statusfinaltest_result + vbNewLine)
        'sb.Append("Voltage Testing           :  " + "" + "VDC" + vbNewLine)
        'sb.Append("Current Testing           :  " + "" + "ADC" + vbNewLine)



        sb.Append("-----------------------------------------------------" + vbNewLine)
        'sb.Append(vbNewLine)
        sb.Append("Login Status : " + login_status + vbNewLine)
        sb.Append("Write MAC# on Net 1 Status : " + write_MAC1 + vbNewLine)
        sb.Append("Write MAC# on Net 2 Status : " + write_MAC2 + vbNewLine)
        If ComboBoxModel.Text = "OPG-409259" Or ComboBoxModel.Text = "OPG-409225" Then
            sb.Append("Write MAC# on sw0   Status : " + write_MACsw0 + vbNewLine)
        End If
        If ComboBoxModel.Text = "OPG-409218" Then
            sb.Append("Write MAC# on Net 3 Status : " + write_MAC3 + vbNewLine)
            sb.Append("Write MAC# on Net 4 Status : " + write_MAC4 + vbNewLine)
        End If
        sb.Append("Reboot DUT Status : " + reboot_DUT + vbNewLine)
        sb.Append("Verification MAC# on Net 1 Status : " + verify_MAC1 + vbNewLine)
        sb.Append("Verification MAC# on Net 2 Status : " + verify_MAC2 + vbNewLine)
        If ComboBoxModel.Text = "OPG-409259" Or ComboBoxModel.Text = "OPG-409225" Then
            sb.Append("Verification MAC# on sw0   Status : " + verify_MACsw0 + vbNewLine)
        End If
        If ComboBoxModel.Text = "OPG-409218" Then
            sb.Append("Verification MAC# on Net 3 Status : " + verify_MAC3 + vbNewLine)
            sb.Append("Verification MAC# on Net 4 Status : " + verify_MAC4 + vbNewLine)
        End If
        sb.Append("Loopback DUT Status : " + loopback + vbNewLine)
        sb.Append("Selftest DUT Status : " + self_test + vbNewLine)
        sb.Append(RichTextBox2.Text)


        RichTextBox2.Text = sb.ToString


        '=================================================================================================
        'Dim sPath1 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG_SUMMARY\", ComboBoxModel.Text)
        'Dim sPath2 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG_SUMMARY\" + ComboBoxModel.Text + "\", ComboBoxRWO_Id.Text)
        'Dim sw As StreamWriter




        'If Not IO.Directory.Exists(sPath1) And Not IO.Directory.Exists(sPath2) Then
        If Not IO.Directory.Exists("D:\SIERRA_TEST\LOG_SUMMARY\") Then
            'If Not IO.Directory.Exists(sPath1) Then
            'IO.Directory.CreateDirectory(sPath1)
            'End If
            'IO.Directory.CreateDirectory(sPath2)
            'MsgBox("folder created")
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_SUMMARY\" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            'ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_SUMMARY\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"

            'WriteLine(RichTextBox1.Text = "dfds")

            Log_File_Data = ExcelDialog.FileName


            RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)

        Else
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_SUMMARY\" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            'ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_SUMMARY\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"

            Log_File_Data = ExcelDialog.FileName
            'Log_File_Data = MACTextBox.Text + "_" + PartNumberTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"

            RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)
        End If

    End Sub



    Dim Newtext, Temp_txt As String
    Sub clean_Log()


        'SendKeys.Send("{Delete}")
        'Dim LineToDelete As Integer = 10
        'List(Of String) lines = RichTextBox1.Lines.ToList()
        'lines.Remove(LineToDelete)
        'RichTextBox1.Lines = lines.ToArray()
        'Dim sb_log = New System.Text.StringBuilder()

        Dim linesCountlog As Long = RichTextBox1.Lines.Count
        'MsgBox(linesCount)
        'RichTextBox1.Text &= "AT"

        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by?"), "Scan in 12 character unique password followed by [Enter] : ************")


        For i = 0 To linesCountlog - 1

            If RichTextBox1.Lines(i).Contains("Password must be 12 characters") Then
                Dim start_index As Long = RichTextBox1.GetFirstCharIndexFromLine(i)
                Dim count As Long = RichTextBox1.Lines(i).Length
                If count < 71 Then
                    RichTextBox1.Text = RichTextBox1.Text.Remove(start_index, count)
                End If
            End If

            If RichTextBox1.Lines(i).Contains("Scan in last 6 digits of MAC") Then
                Dim start_index As Long = RichTextBox1.GetFirstCharIndexFromLine(i)
                Dim count As Long = RichTextBox1.Lines(i).Length
                If count < 66 Then
                    RichTextBox1.Text = RichTextBox1.Text.Remove(start_index, count)
                    'DeleteLine RichTextBox1
                End If
            End If

            'RichTextBox1.AppendText(RichTextBox1.Lines(i))
            'logRichTextBox.ScrollToCaret()

            'If RichTextBox1.Lines(i).Contains("Manufacturing Diagnostics") Then
            'If Not (RichTextBox1.Lines(i).Contains("")) Then
            'If Not (RichTextBox1.Lines(i) = "") Then
            If RichTextBox1.Lines(i).Contains("12 character") Then
                Dim start_index As Long = RichTextBox1.GetFirstCharIndexFromLine(i)
                Dim count As Long = RichTextBox1.Lines(i).Length
                If count < 71 Then
                    RichTextBox1.Text = RichTextBox1.Text.Remove(start_index, count)
                End If
            End If

            If RichTextBox1.Lines(i).Contains("Scan in 12 character unique password") Then

                Dim start_index As Long = RichTextBox1.GetFirstCharIndexFromLine(i)
                Dim count As Long = RichTextBox1.Lines(i).Length
                If count < 71 Then

                    RichTextBox1.Text = RichTextBox1.Text.Remove(start_index, count)
                End If

                'RichTextBox1.Text = RichTextBox1.DeleteLine(i)
                'removeLine(i)
                'DeleteLine(i)
                'RichTextBox1.Text.Select(start_index, count)
                'RichTextBox1.Select(start_index, count)
                'RichTextBox1.replace()
                '
                'var lineCollection = New List < String > (lineArray)


                '
                'RichTextBox1.Text = Replace(RichTextBox1.Text, RichTextBox1.Lines(i), Environment.NewLine)

                'SendKeys.Send("{delete}")

                'RichTextBox1.Lines(i).Take(1).ToArray
                'End If

                'OK
                'RichTextBox1.Select(start_index, count)
                'RichTextBox1.SelectedText = ""



                'RichTextBox1.Text = RichTextBox1.line(i).AppendText("")

                'LEBIH BAIK DIHAPUS SEMUA KEMUDIAN TAMBAHKAN MANUAL

                'sb.Replace("==========================SUMMARY TEST====================", "========================TEST IN PROGRESS==================")
                'sb_log.Append(i)
                'sb_log.Append(RichTextBox1.Text)
                'sb_log.Append(vbNewLine)
                'sb.Append("=======================ORIGINAL LOG=======================")
                'TextBox.Rtf = sb.ToString
                'RichTextBox2.Text = sb_log.ToString

                'RichTextBox1.Contains("Manufacturing Diagnostics")
                'RichTextBox1.Select()
                'RichTextBox1.SelectedText.Remove(i)
                'RichTextBox1.Lines(i).Remove(i)
                'Dim sb = New System.Text.StringBuilder(i)
                'RichTextBox1.RemoveAt(2)
                'RichTextBox1.Select(0, RichTextBox1.GetFirstCharIndexFromLine(i - 2))
                'RichTextBox1.SelectedText = "Scan in 12 character unique password followed by [Enter] : ************"
                'RichTextBox1.AppendText(Environment.NewLine)
                'RichTextBox1.Lines(i).= RichTextBox1.AppendText("Scan in 12 character unique password followed by [Enter] : ************")

                'RichTextBox1.Lines(i - 2) = "Scan in 12 character unique password followed by [Enter] : ************"
                'RichTextBox1.line
                '
                'RichTextBox1.Text = Replace(RichTextBox1.Text, RichTextBox1.Lines(i - 2), "Scan in 12 character unique password followed by [Enter] : ************", , 1)
                'MsgBox("ada")
                'Exit For
            End If

            If RichTextBox1.Lines(i).Contains("Manufacturing Diagnostics") Then
                'Dim start_index As Long = RichTextBox1.GetFirstCharIndexFromLine(i)
                'Dim count As Long = RichTextBox1.Lines(i).Length
                'Temp_txt = "Scan in 12 character unique password followed by [Enter] : ************"
                'RichTextBox1.Text &= RichTextBox1.Lines(i - 2).Insert(start_index, count)
                'RichTextBox1.Text &= RichTextBox1.Lines(i - 2)
                'MsgBox(RichTextBox1.Lines(i - 2))
            End If

            If RichTextBox1.Lines(i) = "" Then
                'RichTextBox1.Lines(i).AppendText("\r\n")
            End If

            linesCountlog = RichTextBox1.Lines.Count

        Next


        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Invalid character entered for password"), "")
        'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by?"), "")

        '=================================
        'ListBox1.Text = RichTextBox1.Text

        'Dim lst As New ListBox

        ' ListBox1.Add(lst)


        'convert richtextbox to listbox
        For Each cosa As String In RichTextBox1.Lines
            If Not (cosa = "") Then
                If cosa = "press space to continue ... " Then
                    ListBox1.Items.Add(cosa)
                    ListBox1.Items.Add(vbNewLine)
                    ListBox1.Items.Add(vbNewLine)
                Else
                    ListBox1.Items.Add(cosa)
                    ListBox1.Items.Add(vbNewLine)
                End If
            End If
        Next


        'For i = 1 To ListBox1.Items.Count
        ' If ListBox1.Items(i).Contains("Manufacturing Diagnostics") Then
        'ListBox1.Items(i - 2).Add("Scan in 12 character unique password followed by [Enter] :  ***********")
        'ListBox1.Items(i - 1).Add(vbNewLine)
        'End If

        'Next


        RichTextBox1.Clear()

        'convert listbox to richtextbox
        For i = 0 To ListBox1.Items.Count - 1
            RichTextBox1.Text &= ListBox1.Items(i)
            RichTextBox1.Text &= vbNewLine
        Next


        Exit Sub
        '=====================================================================





        Dim linesCountlog_list As Long = ListBox1.Items.Count
        'MsgBox(linesCount)

        For i = 0 To linesCountlog_list - 1

            If ListBox1.Items(i - 1) = "" And ListBox1.Items(i) = "" And ListBox1.Items(i + 1) = "" Then
                ListBox1.Items.RemoveAt(i)
            End If
            If ListBox1.Items(i).Contains("MAC") Then
                ListBox1.Items.RemoveAt(i)
            End If
        Next

        'RichTextBox1.Text = ListBox1.Text

        '=============================================


        Exit Sub
        Newtext = Regex.Replace(Newtext, "", "", RegexOptions.Multiline)
        RichTextBox1.Text = Newtext
        RichTextBox1.Refresh()

        Exit Sub
        'ExcelDialog.FileName = "D:\SIERRA_TEST\LOG\" + Build_Num_val_ref + "\" + ComboBoxRWO_Id.Text + "\" + MACTextBox.Text + "_" + PartNumberTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
        'WriteLine(RichTextBox1.Text = "dfds")


        'RichTextBoxTemp.Clear()
        'RichTextBoxTemp.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)


        'sw = File.AppendText(ExcelDialog.FileName)
        'sw.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXX")
        'sw.WriteLine("KKKKKKKKKKKKKKKKKKKKKKKKKKKK")
        'sw.Close()

        'RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
        'RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)

        Exit Sub
        'Dim sb(i) = New System.Text.StringBuilder()

        'If Regex.IsMatch(RichTextBox1.Text, Regex.Escape("Scan in last 6 digits of MAC address, followed by [Enter] : ")) Then
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in last 6 digits of MAC address, followed by [Enter] : "), "")
        'End If
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Password must be 12 characters"), "")
        'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by?"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Invalid character entered for password"), "")
        'If Regex.IsMatch(RichTextBox1.Text, Regex.Escape("Scan in last 6 digits of MAC address, followed by [Enter] : ")) Then
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : ***********"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : **********"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : *********"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : ********"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : *******"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : ******"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : *****"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : ****"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : ***"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : **"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by [Enter] : *"), "")
        'End If
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Scan in 12 character unique password followed by?"), "Scan in 12 character unique password followed by [Enter] : ************")


        'https://www.vbforums.com/showthread.php?624747-RESOLVED-Delete-Lines-from-RichTextBox
        'RichTextBox1.GetCharIndexFromPosition(RichTextBox1.GetPositionFromCharIndex(RichTextBox1.SelectionStart))
        'RichTextBox1.SelectionLength = RichTextBox1.Text.IndexOf("\n", 0) + 1
        'RichTextBox1.SelectedText = ""





        'Exit Sub


        Exit Sub

        'RichTextBox1 = Regex.Replace(RichTextBox1, @"^\s+$[\r\n]*", "", RegexOptions.Multiline)
        'RichTextBox1.Text = RichTextBox1
        'RichTextBox1.Refresh()
        'RichTextBox2.Text &= SerialPort1.BytesToRead
        'SerialPort1.Read(RXbuffer, 0, Byte_Size)
        Dim lst As New ListBox

        'Me.Controls.Add(lst)
        For Each cosa As String In Me.RichTextBox1.Lines
            lst.Items.Add(cosa)
        Next
        lst.Items.RemoveAt(2) 'the integer value must be the line that you want to remove -1  
        Me.RichTextBox1.Text = String.Empty
        For i As Integer = 0 To lst.Items.Count - 1
            If Me.RichTextBox1.Text = String.Empty Then
                Me.RichTextBox1.Text = lst.Items.Item(i)
            Else
                Me.RichTextBox1.Text = Me.RichTextBox1.Text & Environment.NewLine & lst.Items.Item(i).ToString
            End If
        Next



        'Char charToReplace = (Char)(e.KeyChar + 1)    '// substitute replacement char
        'textBox1.SelectedText = New String(charToReplace, 1)
        'e.Handled = True

    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click  'convert rich1 to summary
        RichTextBox2.Clear()
        'TextBox2.Clear()
        parsing_summary_225_convert()
        save_log_summary_225_convert()

    End Sub
    Sub save_log_summary_225_convert()


        'If ComboBoxModel.Text = "OPG-409225" Then
        If LED_sequence = "" Then
            LED_sequence = "NA"
        End If
        'End If



        Dim sb = New System.Text.StringBuilder()
        'sb.Append("==========================SUMMARY TEST====================")
        'sb.Append(vbNewLine)
        sb.Append("Software Name             :  Open Gear Test Station OPG-409225" + vbNewLine)
        sb.Append("Test Station ID           :  TS1" + vbNewLine)
        sb.Append("Operator Name             :  " + ComboBoxOpName.Text.ToUpper() + vbNewLine)
        sb.Append("Operator ID               :  " + ComboBoxBadgeId.Text + vbNewLine)
        'sb.Append("SN DUT                    :  " + SerialTextBox.Text + vbNewLine)
        sb.Append("SN DUT                    :  " + SN_data + vbNewLine)
        sb.Append("Model                     :  409225" + vbNewLine)
        'sb.Append("Date                      :  " + Format(Now, "dd-MMM-yyyy") + vbNewLine) 'samakan format ini dengan csv/excel
        'sb.Append("Time                      :  " + TestingtimeStart_awal.ToString("HH':'mm':'ss") + vbNewLine)
        'sb.Append("Start Test Time           :  " + TestingtimeStart1.Text + vbNewLine)
        'sb.Append("End Test Time             :  " + TestingtimeEnd.ToString("HH':'mm':'ss") + vbNewLine)
        'sb.Append("Total Test Time           :  " + Total_Test_TimeTextBox.Text + vbNewLine)
        sb.Append("Date                      :  " + Date_data + vbNewLine) 'samakan format ini dengan csv/excel
        sb.Append("Time                      :  " + Time_data + vbNewLine)
        sb.Append("Start Test Time           :  " + Start_data + vbNewLine)
        sb.Append("End Test Time             :  " + End_data + vbNewLine)
        sb.Append("Total Test Time           :  " + Duration_data + vbNewLine)

        'sb.Append("RWO Id                    :  " + ComboBoxRWO_Id.Text + vbNewLine)



        'sb.Append("Password Scan             :  " + PasswordTextBox.Text + vbNewLine)

        'sb.Append("Product Name              :  " + ProductName_val_ref + vbNewLine)

        sb.Append("MAC Net 1 Assigned        :  " + GetMAC1 + vbNewLine)
        sb.Append("MAC Net 2 Assigned        :  " + GetMAC2 + vbNewLine)
        sb.Append("MAC sw0   Assigned        :  " + GETMAC3 + vbNewLine)
        sb.Append("Bootloader Revision       :  EM8000 Bootloader 1.9.0-p.1" + vbNewLine)
        sb.Append("MFG Image Revision        :  EM8000 USB Stick with MFG Image (Dev Signed) 1.8.0-p.3" + vbNewLine)
        sb.Append("Power (W)                 :  " + Power_data + vbNewLine)
        sb.Append("Current (A)               :  " + Current_data + vbNewLine)
        'sb.Append("LED Sequence              :  " + LED_sequence + vbNewLine)
        sb.Append("LED Sequence              :  PASS" + vbNewLine)
        'sb.Append("LED Blink Check           :  " + LED_Check_result + vbNewLine)
        sb.Append("Overall Test Result       :  FAIL" + vbNewLine)
        'sb.Append("Voltage Testing           :  " + "" + "VDC" + vbNewLine)
        'sb.Append("Current Testing           :  " + "" + "ADC" + vbNewLine)




        'If ComboBoxModel.Text = "OPG-409225" Then

        'If write_all_mac = "PASS" Then
        'sb.Append("Write MAC# on Net 1 Status : PASS" & vbNewLine)
        'sb.Append("Write MAC# on Net 2 Status : PASS" & vbNewLine)
        'sb.Append("Write MAC# on sw0   Status : PASS" & vbNewLine)
        'End If

        'If verify_all_mac = "PASS" Then
        'sb.Append("Verify MAC# on Net 1 Status : PASS" & vbNewLine)
        'sb.Append("Verify MAC# on Net 2 Status : PASS" & vbNewLine)
        'sb.Append("Verify MAC# on sw0   Status : PASS" & vbNewLine)
        'End If
        'sb.Append("LED SEQUENCE              :  " + LED_sequence + vbNewLine)

        'End If
        'sb.Append("All LED ON                :  " + allLED_on)
        'sb.Append("LED                      :  " + Total_Test_TimeTextBox.Text + vbNewLine)
        'sb.Append(vbNewLine)
        'sb.Append(vbNewLine)
        sb.Append("-----------------------------------------------------" + vbNewLine)
        'sb.Append(vbNewLine)
        sb.Append("Login Status : PASS" + vbNewLine)
        sb.Append("Write MAC# on Net 1 Status : PASS" + vbNewLine)
        sb.Append("Write MAC# on Net 2 Status : PASS" + vbNewLine)
        sb.Append("Write MAC# on sw0   Status : PASS" + vbNewLine)
        sb.Append("Reboot DUT Status : PASS" + vbNewLine)
        sb.Append("Verification MAC# on Net 1 Status : PASS" + vbNewLine)
        sb.Append("Verification MAC# on Net 2 Status : PASS" + vbNewLine)
        sb.Append("Verification MAC# on sw0   Status : PASS" + vbNewLine)
        sb.Append("Loopback DUT Status : PASS" + vbNewLine)
        sb.Append("Selftest DUT Status : FAIL" + vbNewLine)
        sb.Append(RichTextBox2.Text)

        'If ResultTextBoxFCT.Text = "PASS" Then
        'sb.Append(vbNewLine)
        'sb.Append("==========================================================" + vbNewLine)
        'sb.Append("Checksector Test                                  |" + dataChecksector_result + "|" + vbNewLine)
        'Check sector tidak ada di digione sp
        'sb.Append("Personality Test                                  |" + dataPersonalityTest_result + "|" + vbNewLine)
        'sb.Append("Mem Addrs RAM Test                                |" + dataMemAddrs_result + "|" + vbNewLine)
        'sb.Append(vbNewLine)
        'sb.Append("=============================END==========================" + vbNewLine)
        'End If
        'TextBox.Rtf = sb.ToString
        RichTextBox2.Text = sb.ToString





        Exit Sub ' hapus



        '=================================================================================================
        Dim sPath1 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG_SUMMARY\", ComboBoxModel.Text)
        Dim sPath2 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG_SUMMARY\" + ComboBoxModel.Text + "\", ComboBoxRWO_Id.Text)
        'Dim sw As StreamWriter



        'If Not IO.Directory.Exists(sPath1) And Not IO.Directory.Exists(sPath2) Then
        If Not IO.Directory.Exists(sPath2) Then
            If Not IO.Directory.Exists(sPath1) Then
                IO.Directory.CreateDirectory(sPath1)
            End If
            IO.Directory.CreateDirectory(sPath2)
            'MsgBox("folder created")
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_SUMMARY\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            'WriteLine(RichTextBox1.Text = "dfds")

            Log_File_Data = ExcelDialog.FileName


            RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)

        Else
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_SUMMARY\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            Log_File_Data = ExcelDialog.FileName
            'Log_File_Data = MACTextBox.Text + "_" + PartNumberTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"

            RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)
        End If

    End Sub

    Dim SN_data, Date_data, Time_data, Start_data, End_data, Duration_data, Power_data_raw, SN_raw, Date_raw, Time_data_raw, Start_data_raw, End_data_raw, Duration_data_raw As String

    Sub reset_value_convert()

        CekMACDB = ""

        GetMAC1 = ""
        GetMAC2 = ""
        GETMAC3 = ""
        GETMAC4 = ""
        GetMAC1_new = ""
        GetMAC2_new = ""
        GetMAC3_new = ""
        GetMAC4_new = ""

        Power_data = ""
        Current_data = ""

        MAC1 = ""
        MAC2 = ""
        MAC3 = ""
        MAC4 = ""
        MACsw0 = ""

        SN_data = ""
        Date_data = ""
        Time_data = ""
        Start_data = ""
        End_data = ""
        Duration_data = ""
        Power_data_raw = ""
        SN_raw = ""
        Date_raw = ""
        Time_data_raw = ""
        Start_data_raw = ""
        End_data_raw = ""
        Duration_data_raw = ""
    End Sub
    Sub parsing_summary_225_convert()
        'If RichTextBox2.Text.Contains("selftest-local --exclude slow") Then
        'RichTextBox2.Clear()
        'End If


        'MsgBox(Trim(InStr(7, RichTextBox1.Text, "Total, current =", CompareMethod.Text)))
        'MsgBox(Trim(InStr(RichTextBox1.Text, "Total, current =")))

        'Exit Sub

        reset_value_convert()



        For i As Integer = 0 To RichTextBox1.Lines.Count - 1
            Dim line As String = RichTextBox1.Lines(i)

            'Dim read_power As String
            If line.Contains("Total, current =") Then
                ' Process the line here
                'Console.WriteLine(line)


                Power_data_raw = line '& vbCrLf
                Power_data_raw = Replace(Power_data_raw, "Verify Power Consumption :: Check for total current/power use and ... ......Total, current = ", "")
                Power_data_raw = Replace(Power_data_raw, "p", "")
                Power_data_raw = Replace(Power_data_raw, "o", "")
                Power_data_raw = Replace(Power_data_raw, "w", "")
                Power_data_raw = Replace(Power_data_raw, ",", "")



                Power_data = Trim(Mid(Power_data_raw, 10, 30))
                Power_data = Trim(Replace(Power_data, "W", ""))
                Power_data = Trim(Replace(Power_data, "p", ""))
                Power_data = Trim(Replace(Power_data, "o", ""))
                Power_data = Trim(Replace(Power_data, "w", ""))
                Power_data = Trim(Replace(Power_data, "e", ""))
                Power_data = Trim(Replace(Power_data, "r", ""))
                Power_data = Trim(Replace(Power_data, "=", ""))

                Current_data = Trim(Mid(Power_data_raw, 1, 6))
                Current_data = Trim(Replace(Current_data, "A", ""))


                MsgBox(Power_data & "___" & Power_data_raw)
            End If


            If line.Contains("SN DUT                    :  ") Then

                SN_raw = line '& vbCrLf
                SN_raw = Replace(SN_raw, "SN DUT                    :  ", "")

                SN_data = Trim(Mid(SN_raw, 1, 40))

            End If

            If line.Contains("Date                      :  ") Then

                Date_raw = line '& vbCrLf
                Date_raw = Replace(Date_raw, "Date                      :  ", "")

                Date_data = Trim(Mid(Date_raw, 1, 40))

            End If


            If line.Contains("Time                      :  ") Then

                Time_data_raw = line '& vbCrLf
                Time_data_raw = Replace(Time_data_raw, "Time                      :  ", "")

                Time_data = Trim(Mid(Time_data_raw, 1, 40))

            End If

            If line.Contains("Start Test                :  ") Then

                Start_data_raw = line '& vbCrLf
                Start_data_raw = Replace(Start_data_raw, "Start Test                :  ", "")

                Start_data = Trim(Mid(Start_data_raw, 1, 40))

            End If


            If line.Contains("End Test                  :  ") Then

                End_data_raw = line '& vbCrLf
                End_data_raw = Replace(End_data_raw, "End Test                  :  ", "")

                End_data = Trim(Mid(End_data_raw, 1, 40))

            End If

            If line.Contains("Testing Time Duration     :  ") Then

                Duration_data_raw = line '& vbCrLf
                Duration_data_raw = Replace(Duration_data_raw, "Testing Time Duration     :  ", "")

                Duration_data = Trim(Mid(Duration_data_raw, 1, 40))

            End If

            If line.Contains("| PASS |") Or line.Contains("| FAIL |") Then

                RichTextBox2.Text = RichTextBox2.Text & line & vbCrLf
            End If



        Next
        RichTextBox2.Text = Replace(RichTextBox2.Text, "| PASS |", ": PASS")

        RichTextBox2.Text = Replace(RichTextBox2.Text, "| FAIL |", ": FAIL")


        Try

            'CekMACDB = GetMac(SN_data)

            CekMAC = CekMACDB.Split(",")
            GetMAC1 = CekMAC(0)
            GetMAC2 = CekMAC(1)
            GETMAC3 = CekMAC(2)

        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & "Or serial number not valid")
        End Try


        'RichTextBox2.Text = Regex.Replace(RichTextBox2.Text, Regex.Escape("[32m"), "")
        'RichTextBox2.Text = Regex.Replace(RichTextBox2.Text, Regex.Escape("[0m"), "")
        'RichTextBox2.Text = Regex.Replace(RichTextBox2.Text, Regex.Escape(""), "")
        'RichTextBox2.Text = Regex.Replace(RichTextBox2.Text, Regex.Escape("=============================================================================="), "")


    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click 'browse file
        RichTextBox1.Clear()
        ' Displays an OpenFileDialog so the user can select a Cursor.
        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.Filter = "Text Files|*.txt"
        openFileDialog1.Title = "Select a Text File"

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then


            Dim extension = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("."))
            'Dim filename = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\")) 'nok

            Dim copyToDir = Path.GetDirectoryName(openFileDialog1.FileName)
            Dim filename = Path.GetFileName(openFileDialog1.FileName)
            'Dim newPath = Path.Combine(copyToDir, file)

            filename = Replace(filename, ".txt", "") 'remove 'txt
            filename = Trim(Mid(filename, 14, 100)) 'remove 1st mac
            TextBox2.Text = filename

            If extension = ".txt" Then

                'RichTextBox1.Text = FileIO.FileSystem.ReadAllText(openFileDialog1.FileName)

                'RichTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText)  'RTF file
                RichTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText) 'TEXT file ok
            End If

        End If
    End Sub


    Sub save_log_RAW()


        Dim sb = New System.Text.StringBuilder()

        sb.Append(vbNewLine)
        sb.Append(RichTextBox3.Text)

        'If ResultTextBoxFCT.Text = "PASS" Then
        sb.Append(vbNewLine)

        RichTextBox3.Text = sb.ToString



        '=================================================================================================
        Dim sPath1 As String = IO.Path.Combine("D:\SIERRA_TEST\Data\raw\", ComboBoxModel.Text)
        Dim sPath2 As String = IO.Path.Combine("D:\SIERRA_TEST\Data\raw\" + ComboBoxModel.Text + "\", ComboBoxRWO_Id.Text)
        'Dim sw As StreamWriter



        'If Not IO.Directory.Exists(sPath1) And Not IO.Directory.Exists(sPath2) Then
        If Not IO.Directory.Exists(sPath2) Then
            If Not IO.Directory.Exists(sPath1) Then
                IO.Directory.CreateDirectory(sPath1)
            End If
            IO.Directory.CreateDirectory(sPath2)
            'MsgBox("folder created")
            ExcelDialog.FileName = "D:\SIERRA_TEST\Data\raw\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            'WriteLine(RichTextBox1.Text = "dfds")

            Log_File_Data = ExcelDialog.FileName


            RichTextBox3.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox3.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)

        Else
            ExcelDialog.FileName = "D:\SIERRA_TEST\Data\raw\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            Log_File_Data = ExcelDialog.FileName
            'Log_File_Data = MACTextBox.Text + "_" + PartNumberTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"

            RichTextBox3.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox3.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)
        End If

    End Sub
    Sub save_log_ORI()


        Dim sb = New System.Text.StringBuilder()

        sb.Append(vbNewLine)
        sb.Append(RichTextBox1.Text)

        'If ResultTextBoxFCT.Text = "PASS" Then
        sb.Append(vbNewLine)

        RichTextBox1.Text = sb.ToString



        '=================================================================================================
        Dim sPath1 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG_ORI\", ComboBoxModel.Text)
        Dim sPath2 As String = IO.Path.Combine("D:\SIERRA_TEST\LOG_ORI\" + ComboBoxModel.Text + "\", ComboBoxRWO_Id.Text)
        'Dim sw As StreamWriter



        'If Not IO.Directory.Exists(sPath1) And Not IO.Directory.Exists(sPath2) Then
        If Not IO.Directory.Exists(sPath2) Then
            If Not IO.Directory.Exists(sPath1) Then
                IO.Directory.CreateDirectory(sPath1)
            End If
            IO.Directory.CreateDirectory(sPath2)
            'MsgBox("folder created")
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_ORI\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            'WriteLine(RichTextBox1.Text = "dfds")

            Log_File_Data = ExcelDialog.FileName


            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)

        Else
            ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_ORI\" + ComboBoxModel.Text + "\" + ComboBoxRWO_Id.Text + "\" + IMEITextBox1.Text + "_" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"
            Log_File_Data = ExcelDialog.FileName
            'Log_File_Data = MACTextBox.Text + "_" + PartNumberTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_" + ResultTextBoxFCT.Text + ".txt"

            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
            RichTextBox1.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)
        End If

    End Sub

    Private Function ImageToStream(ByVal fileName As String) As Byte()
        Dim stream As New MemoryStream()
tryagain:
        Try
            Dim image As New Bitmap(fileName)
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg)
        Catch ex As Exception
            GoTo tryagain
        End Try
        Return stream.ToArray()
    End Function

    Sub import_XML2SQL() 'ok import file txt to SQL, bisa muncul di datagrid
        Dim cmd_text As New SqlCommand
        Dim sql_text As String

        '!!!jika text masih path, maka open atau import dulu ke richtex box, kemudian encoding dibawah
        '!!!GUNAKAN TYPE DATA VARCHAR(MAX) DI SQL!!! spy bisa langsung dilihat log di sql dan datagrid
        Dim memString As String = From_RichTextBox3 'Log_File_Data   'gunakan rich textbox jgn file path krn hanya menyimpan path saja bukan isi text

        'convert string to stream

        Dim buffer As Byte() = Encoding.ASCII.GetBytes(memString)

        Dim ms As New MemoryStream(buffer)
        'write to file OK
        'Dim file As New FileStream("d:\file.txt", FileMode.Create, FileAccess.Write)
        'ms.WriteTo(file)
        'file.Close()
        'ms.Close()


        'conn = GetConnect()
        conn.Open()



        '!!!GUNAKAN TYPE DATA VARCHAR(MAX) DI SQL!!! jika NVARCHAR(MAX) maka karakter tidak terbaca dan aneh
        sql_text = "UPDATE [dbo].[Tbl_Console_Manager] SET [XML_FILE]=@file WHERE ([Part Num Scan]='" & MACTextBox2.Text & "' AND [Start Time]='" & TestingtimeStart1.Text & "' AND [End Time]='" & TestingtimeEnd.ToString("HH':'mm':'ss") & "')"  'OK



        cmd_text.Connection = conn
        cmd_text.CommandText = sql_text
        'cmd_text.Parameters.Add("@filepath", SqlType.VarChar).Value = txtfilepath.Text
        cmd_text.Parameters.AddWithValue("@file", ms)  'ok
        'cmd_text.Parameters.Add("@file", SqlDbType.Binary).Value = ms  'ok
        cmd_text.ExecuteNonQuery()
        cmd_text.Parameters.Clear()
        conn.Close()
        ms.Close()


        Call sql2datagrid2()

        'tambahkan cara mengecilkan gambar di datagrid

        Call coloring_datagrid2()
    End Sub

    Sub import_LOG2SQL() 'ok import file txt to SQL, bisa muncul di datagrid
        Dim cmd_text As New SqlCommand
        Dim sql_text As String
        'Dim filebyte() As Byte
        'Dim arrImage() As Byte ' = ImageToStream(fName)

        'Dim mstream As New System.IO.MemoryStream()
        'PictureBox2.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg) 'ok gambar lebih ringan dan bisa karena sudah di compress ke jpeg
        'PictureBox2.Image.Save(mstream, PictureBox2.Image.RawFormat) 'ok, proses lebih lama karena gambar tidak dicompress
        'RichTextBox1.Text.Save(mstream, RichTextBox1.Text)
        'RichTextBox1.SaveFile(mstream, RichTextBoxStreamType.PlainText)
        'PdfDocument1.FilePath = fd.FileName
        'filepath = "C:\Users\bsetiawan\Downloads\port server blink__.png"

        'filebyte = mstream.GetBuffer()
        'Dim FileSize = mstream.Length
        'mstream.Close()

        '!!!jika text masih path, maka open atau import dulu ke richtex box, kemudian encoding dibawah
        '!!!GUNAKAN TYPE DATA VARCHAR(MAX) DI SQL!!! spy bisa langsung dilihat log di sql dan datagrid
        Dim memString As String = RichTextBox1.Text 'Log_File_Data   'gunakan rich textbox jgn file path krn hanya menyimpan path saja bukan isi text
        'Dim memString As PictureBox = PictureBox2
        ' convert string to stream

        Dim buffer As Byte() = Encoding.ASCII.GetBytes(memString)

        Dim ms As New MemoryStream(buffer)
        'write to file OK
        'Dim file As New FileStream("d:\file.txt", FileMode.Create, FileAccess.Write)
        'ms.WriteTo(file)
        'file.Close()
        'ms.Close()


        'conn = GetConnect()
        conn.Open()

        'filebyte = System.IO.File.ReadAllBytes(fd.FileName)

        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [Log_File_Data]=@IMAGE WHERE (proid=" & Val(txtPLU.Text) & ")"
        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [IMAGE_FILE]=@IMAGE WHERE ([End Time]='" & TestingtimeEnd.ToString("HH':'mm':'ss") & "')"  'OK
        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [IMAGE_FILE]=@IMAGE WHERE ([Part Num Scan]='" & PartNumberTextBox.Text & "')"  'OK
        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [IMAGE_FILE]=@IMAGE WHERE ([Part Num Scan]='" & PartNumberTextBox.Text & "' AND [Start Time]='" & TestingtimeStart1.Text & "' AND [End Time]='" & TestingtimeEnd.ToString("HH':'mm':'ss") & "')"  'OK
        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [LOG_FILE]=@IMAGE WHERE ([Part Num Scan]='" & PartNumberTextBox.Text & "' AND [Start Time]='" & TestingtimeStart1.Text & "' AND [End Time]='" & TestingtimeEnd.ToString("HH':'mm':'ss") & "')"  'OK

        '!!!GUNAKAN TYPE DATA VARCHAR(MAX) DI SQL!!! jika NVARCHAR(MAX) maka karakter tidak terbaca dan aneh
        sql_text = "UPDATE [dbo].[Tbl_Console_Manager] SET [LOG_FILE]=@file WHERE ([Part Num Scan]='" & MACTextBox2.Text & "' AND [Start Time]='" & TestingtimeStart1.Text & "' AND [End Time]='" & TestingtimeEnd.ToString("HH':'mm':'ss") & "')"  'OK



        cmd_text.Connection = conn
        cmd_text.CommandText = sql_text
        'cmd_text.Parameters.Add("@filepath", SqlType.VarChar).Value = txtfilepath.Text
        cmd_text.Parameters.AddWithValue("@file", ms)  'ok
        'cmd_text.Parameters.Add("@file", SqlDbType.Binary).Value = ms  'ok
        cmd_text.ExecuteNonQuery()
        cmd_text.Parameters.Clear()
        conn.Close()
        ms.Close()


        Call sql2datagrid2()

        'tambahkan cara mengecilkan gambar di datagrid

        Call coloring_datagrid2()
    End Sub

    Sub import_image2SQL() 'OK BERHASIL UNTUK IMPORT IMAGE ke SQL, bisa muncul di datagrid
        'Dim IMAGE As String
        Dim cmd_image As New SqlCommand
        Dim sql_image As String
        Dim arrImage() As Byte

        'jika picture masih path, maka open atau import dulu ke picture box, kemudian save ke dengan mstream ke format jpeg

        Dim mstream As New System.IO.MemoryStream()
        PictureBox2.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg) 'ok gambar lebih ringan dan bisa karena sudah di compress ke jpeg
        'PictureBox2.Image.Save(mstream, PictureBox2.Image.RawFormat) 'ok, proses lebih lama karena gambar tidak dicompress
        'RichTextBox1.Text.Save(mstream, RichTextBox1.Text)
        'RichTextBox1.Text.Save(mstream, RichTextBoxStreamType.PlainText)

        'IMAGE = "C:\Users\bsetiawan\Downloads\port server blink__.png"
        arrImage = mstream.GetBuffer()
        Dim FileSize = mstream.Length
        mstream.Close()

        'conn = GetConnect()
        conn.Open()




        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [Log_File_Data]=@IMAGE WHERE (proid=" & Val(txtPLU.Text) & ")"
        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [IMAGE_FILE]=@IMAGE WHERE ([End Time]='" & TestingtimeEnd.ToString("HH':'mm':'ss") & "')"  'OK
        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [IMAGE_FILE]=@IMAGE WHERE ([Part Num Scan]='" & PartNumberTextBox.Text & "')"  'OK
        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [IMAGE_FILE]=@IMAGE WHERE ([Part Num Scan]='" & PartNumberTextBox.Text & "' AND [Start Time]='" & TestingtimeStart1.Text & "' AND [End Time]='" & TestingtimeEnd.ToString("HH':'mm':'ss") & "')"  'OK
        'sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [LOG_FILE]=@IMAGE WHERE ([Part Num Scan]='" & PartNumberTextBox.Text & "' AND [Start Time]='" & TestingtimeStart1.Text & "' AND [End Time]='" & TestingtimeEnd.ToString("HH':'mm':'ss") & "')"  'OK

        '!!!GUNAKAN TYPE DATA IMAGE DI SQL!!! ATAU GUNAKAN [varbinary](MAX) sama2 ok bisa langsung muncul di datagrid
        sql_image = "UPDATE [dbo].[Tbl_Console_Manager] SET [IMAGE_FILE]=@IMAGE WHERE ([Part Num Scan]='" & MACTextBox2.Text & "' AND [Start Time]='" & TestingtimeStart1.Text & "' AND [End Time]='" & TestingtimeEnd.ToString("HH':'mm':'ss") & "')"  'OK



        cmd_image.Connection = conn
        cmd_image.CommandText = sql_image
        cmd_image.Parameters.AddWithValue("@IMAGE", arrImage)
        cmd_image.ExecuteNonQuery()
        cmd_image.Parameters.Clear()
        conn.Close()



        Call sql2datagrid2()

        'tambahkan cara mengecilkan gambar di datagrid

        Call coloring_datagrid2()
    End Sub
    Function GetValue(row As Integer, col As Integer) As String
        'https://stackoverflow.com/questions/62584487/reading-a-specific-value-in-a-cell-in-a-csv-file-in-vb-net
        Dim csvPath = "D:/SIERRA_TEST/Data/Initial Data.csv"
        Dim result As String = String.Empty
        Dim lines = File.ReadAllLines(csvPath)
        If row < lines.Length Then
            Dim cols = lines(row).Split(","c)
            If col < cols.Length Then
                result = cols(col)
            End If
        End If
        Return result
    End Function
    '----------------------disconnect COM--------------------------
    Private Sub DisconnectBT_Click(sender As System.Object, e As System.EventArgs) Handles DisconnectBT.Click

        If SerialPort1.IsOpen() = True Then


            SerialPort1.Close()

            ConnectDUT.Enabled = True
            SendBT.Enabled = False
            'DisconnectBT.Enabled = False
            ConnectDUT.BackColor = Color.IndianRed

            LabelInfo.Text = "Serial Tester NOT connected!"
        End If

    End Sub

    Private Sub PSDisConnectSerial_Click(sender As Object, e As EventArgs) Handles PSDisConnectSerial.Click

        If SerialPortPS.IsOpen() = True Then


            SerialPortPS.Close()

            PSConnectSerial.Enabled = True
            SendBT.Enabled = False
            'PSDisConnectSerial.Enabled = False
            'ConnectBT.BackColor = Color.IndianRed

            PSConnectSerial.BackColor = Color.IndianRed
            'PSTestBT.BackColor = Color.IndianRed

            LabelInfo.Text = "Serial Power Supply NOT connected!"
        End If
    End Sub

    Dim Firm_miss As String




    Private Sub Form_Port_Server_TESTING_1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'If MessageBox.Show("Apakah yakin menutup aplikasi ini?", "Close TESTING #1", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        'conn.Close()


        'Dim pProcess1() As Process = System.Diagnostics.Process.GetProcessesByName(LabelModBuildNumber.Text + "_TESTING_1") 'jgn pakai exe, langsung kill form

        'For Each p As Process In pProcess1
        'p.Kill()
        'System.Diagnostics.Process.Start("parsing_v2")
        'p.Start()
        'Next

        'Dim pProcess2() As Process = System.Diagnostics.Process.GetProcessesByName("Form_" + LabelModBuildNumber.Text + "_TESTING_1") 'jgn pakai exe, langsung kill form

        'For Each p As Process In pProcess2
        'p.Kill()
        'System.Diagnostics.Process.Start("parsing_v2")
        'p.Start()
        'Next



        'update_
        Dim pProcess3() As Process = System.Diagnostics.Process.GetProcessesByName("FW_UPDATE1") 'jgn pakai exe, langsung kill form

        For Each p As Process In pProcess3
            p.Kill()
            'System.Diagnostics.Process.Start("parsing_v2")
            'p.Start()
        Next


        Environment.Exit(0)
        'Application.Exit()
        Close()
        End
        'Else
        'e.Cancel = True
        'End If
    End Sub





    'Private Sub SerialPort1_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
    Private Sub SerialPort1_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'RichTextBox1.Text &= SerialPort1.ReadLine() 'readline ada max baris yg muncul di richtextbox
        'RichTextBoxTemp.Text &= SerialPort1.ReadLine()

        ReceivedText(SerialPort1.ReadExisting())
        'ReceivedText(SerialPort1.ReadChar()) 'no
        'ReceivedText(SerialPort1.ReadLine())
        If e.ToString.Contains("SerialDataReceived") = True Then
            'n = n + 1
            'RichTextBoxTemp.Text &= n & vbCr
            'RichTextBoxTemp.Clear()
        End If





    End Sub




    Private Sub SerialPortPS_DataReceived(sender As System.Object, e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPortPS.DataReceived


        'ReceivedText(SerialPortPS.ReadLine())
        ReceivedText(SerialPortPS.ReadExisting())
        If e.ToString.Contains("SerialDataReceived") = True Then
            'n = n + 1
            'RichTextBoxTemp.Text &= n & vbCr
            'RichTextBoxTemp.Clear()
        End If


    End Sub


    '----------------------function read serial/incoming data--------------------------
    Private Sub ReceivedText(ByVal [text] As String)
        'Me.RichTextBox1.Text &= [text] '+ vbNewLine ' &= append text
        'Me.RichTextBoxTemp.Text &= [text] '+ vbNewLine 
        'Exit Sub

        If Me.RichTextBox1.InvokeRequired Then
            'tanpa ini tidak bisa muncul data serial
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else

            'Dim fine As String = Mid([text], 7, 3)
            'Dim list As Integer = ListBox3.Items.Add(fine)
            'lakukan replace disini

            Me.RichTextBox1.Text &= [text] '+ vbNewLine ' &= append text
            replace_symbol()  ' COMPARE LOG WITHOUT AND WITH THIS!!!!!!!
            'Me.RichTextBox2.Text &= [text] '+ vbNewLine 
            Me.RichTextBoxTemp.Text &= [text] '+ vbNewLine 
            Me.RichTextBox3.Text &= [text] '+ vbNewLine 



        End If
    End Sub

    Sub reset_value()


        'SerialPort1.ReadBufferSize = 10000
        'SerialPort1.DiscardOutBuffer()
        'SerialPort1.DiscardInBuffer()

        TestingtimeStart1.Clear()
        Total_Test_TimeTextBox.Text = "00:00:00"
        TestingtimeStart1.Text = Format(Now, "HH:mm:ss") ' HH=jam 00-23, hh=AM atau PM
        TestingtimeStart = TestingtimeStart1.Text

        If CheckBoxRWO.Checked = False Then
            ComboBoxRWO_Id.Text = ""
        End If

        RichTextBoxTemp.Clear()
        'RichTextBox1.Clear()
        RichTextBox2.Clear()
        RichTextBox3.Clear()


        IMEITextBox1.Clear()
        MACTextBox2.Clear()
        MACTextBox3.Clear()
        MACTextBox4.Clear()
        MACsw0TextBox.Clear()
        SerialTextBox.Clear()


        TextBox1.Clear()
        ListBox1.Items.Clear()


        ResultTextBoxFCT.Clear()
        TextBoxFirmwCheck.Clear()
        ResultTextBoxFCT.BackColor = Color.White
        TextBoxFirmwCheck.BackColor = Color.White


        AT_count = 0

        GetMAC1 = ""
        GetMAC2 = ""
        GETMAC3 = ""
        GETMAC4 = ""

        GetMAC1_new = ""
        GetMAC2_new = ""
        GetMAC3_new = ""
        GetMAC4_new = ""

        CekMACDB = ""

        MAC1 = ""
        MAC2 = ""
        MAC3 = ""
        MAC4 = ""
        MACsw0 = ""

        'x1 = Nothing ' sama saja dengan blank (tapi bukan zero)
        'x2 = Nothing
        testing_batal = ""


        fail1 = ""
        fail2 = ""
        fail3 = ""
        fail4 = ""

        Primary_fail = ""
        Secondary_fail = ""
        imei_log = ""
        Upgrade_Firm = ""

        impref1 = ""
        impref2 = ""
        impref3 = ""
        impref4 = ""
        impref5 = ""


        att = ""
        generic = ""
        telus = ""
        tmo = ""
        rogers = ""
        verizon = ""
        prefer_current = ""
        all_firm = ""

        Upgrade_Firm_process = ""
        ModuleReady_result = ""
        statusfinaltest_result = ""

        login_status = ""
        write_MAC1 = ""
        write_MAC2 = ""
        write_MAC3 = ""
        write_MACsw0 = ""
        write_MAC4 = ""

        verify_MAC1 = ""
        verify_MAC2 = ""
        verify_MAC3 = ""
        verify_MACsw0 = ""
        verify_MAC4 = ""
        reboot_DUT = ""
        loopback = ""

        self_test = ""
        LED_sequence = ""
        write_all_mac = ""
        verify_all_mac = ""
        Device_fail = ""

        Power_data = ""
        Current_data = ""
        SN_data = ""


        intResponse1 = Nothing
        intResponse2 = Nothing
        intResponse3 = Nothing
        intResponse4 = Nothing
        intResponse5 = Nothing
        intResponse6 = Nothing
        intResponse7 = Nothing
        'MAC_VMtester_value_long_embd = ""
        'MAC_VMtester_value_short_embd = ""
    End Sub


    Dim countx As Integer = 0
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click 'cek mac manual



    End Sub






    Sub get_power_current()
        For i As Integer = 0 To RichTextBox1.Lines.Count - 1
            Dim line As String = RichTextBox1.Lines(i)

            'Dim read_power As String
            If line.Contains("Total, current =") Then
                ' Process the line here
                'Console.WriteLine(line)


                Power_data_raw = line '& vbCrLf
                Power_data_raw = Replace(Power_data_raw, "Verify Power Consumption :: Check for total current/power use and ... ......Total, current = ", "")
                Power_data_raw = Replace(Power_data_raw, "p", "")
                Power_data_raw = Replace(Power_data_raw, "o", "")
                Power_data_raw = Replace(Power_data_raw, "w", "")
                Power_data_raw = Replace(Power_data_raw, "e", "")
                Power_data_raw = Replace(Power_data_raw, "r", "")
                Power_data_raw = Replace(Power_data_raw, ",", "")



                Power_data = Trim(Mid(Power_data_raw, 10, 30))
                Power_data = Trim(Replace(Power_data, "W", ""))
                Power_data = Trim(Replace(Power_data, "p", ""))
                Power_data = Trim(Replace(Power_data, "o", ""))
                Power_data = Trim(Replace(Power_data, "w", ""))
                Power_data = Trim(Replace(Power_data, "e", ""))
                Power_data = Trim(Replace(Power_data, "r", ""))
                Power_data = Trim(Replace(Power_data, "=", ""))

                Current_data = Trim(Mid(Power_data_raw, 1, 6))
                Current_data = Trim(Replace(Current_data, "A", ""))


                'MsgBox(Power_data & "___" & Power_data_raw)
            End If

        Next
    End Sub
    Private Sub Start_BT_Click(sender As Object, e As EventArgs) Handles Start_BT.Click 'start FCT

        If CheckBoxAutoCOM_DUT.Checked = True Then
            'serial_DUT_auto_connect()
        End If


        MsgBox("Pastikan Modem SIERRA sudah terpasang dengan benar")

        reset_value()
        reset_datagrid()


        Dim sPath1 As String = IO.Path.Combine("D:\SIERRA_TEST\Firmware_1\", "result_1") 'update_
        IO.Directory.CreateDirectory(sPath1)

        '---------------------empty folder log------------------------

        For Each filex As String In My.Computer.FileSystem.GetFiles(path_log1) 'update_
            ListBox1.Items.Add(IO.Path.GetFileName(filex))  ' bisa dipakai jika ingin di list dalam listbox
        Next

        If ListBox1.Items.Count > 0 Then
            'delete semua isi folder
            For Each filex As String In My.Computer.FileSystem.GetFiles(path_log1) 'update_
                If System.IO.File.Exists(path_log1 & IO.Path.GetFileName(filex)) = True Then
                    System.IO.File.Delete(path_log1 & IO.Path.GetFileName(filex))
                End If
            Next
        End If
        '---------------------------------------------

        'Delay(10)


        RichTextBox1.Clear() ' klik start terlebih dahulu, kemudian pasang power ke DUT




        TestingtimeStart1.Text = Format(Now, "HH:mm:ss") ' HH=jam 00-23, hh=AM atau PM
        TestingtimeStart_awal = TestingtimeStart1.Text

        Date_testDate.Text = Format(Now, "dd-MMM-yyyy") 'samakan format ini dengan csv/excel

        'RichTextBox1.Clear()
        'SerialPortPS.Write("OUT0" & vbCr)

        ProgressBarFCT.Minimum = 0
        ProgressBarFCT.Maximum = 5 'ADMIN.TextBoxTestNum.Text 'depent how many test, seharusnya 14

        ProgressBarFCT.Value = 0
        'LabelProgressBarFCT.Text = "TESTING : IN PROGRESS... Please WAIT..."
        StopBT.BackColor = Color.White


        'ProgressBarFirm.Value = 0
        'ProgressBarFirm.Maximum = testFirmnumber_val_ref
        LabelProgressBarFirm.Text = ""







        'SerialPort1.Close()
        'SerialPortPS.Close()

        'SerialPort1.PortName = ComboBoxCOMModTester.Text
        'SerialPort1.Open()
        'ConnectBT.BackColor = Color.LightGreen
        'ConnectBT.Enabled = False

        'SerialPortPS.PortName = ComboBoxCOMPS.Text
        'SerialPortPS.Open()
        'PSConnectSerial.BackColor = Color.LightGreen
        'PSConnectSerial.Enabled = False



        Dim writer9 As New StreamWriter("D:\SIERRA_TEST\Data\Model.txt")
        writer9.WriteLine(ComboBoxModel.Text)
        writer9.Close()

        If ComboBoxModel.Text = "" Then
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "CANCEL", Color.Orange)
            MessageBox.Show("Pilih terlebih dahulu MODEL!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ComboBoxModel.Select()
            DUTDisconnect()
            Exit Sub
        End If


        If ComboBoxOpName.Text = "" _
            Or ComboBoxOpName.Text = "Please Input Operator Name" Then
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "CANCEL", Color.Orange)
            MessageBox.Show("Please fill Name of operator", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ComboBoxOpName.Select()
            DUTDisconnect()
            Exit Sub
        End If

        'ComboBoxOpName.Text = ComboBoxOpName.Text.ToUpper()

        If ComboBoxBadgeId.Text = "" _
            Or ComboBoxBadgeId.Text = "Please Input Operator Badge ID" Then
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "CANCEL", Color.Orange)
            MessageBox.Show("Please fill Employee ID", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ComboBoxBadgeId.Select()
            DUTDisconnect()
            Exit Sub
        End If



        collect_data()

        Exit Sub

        '--------------------------------------------------------


        SendBT.Enabled = True

        If SerialPort1.IsOpen() = False Then
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "CANCEL", Color.Orange)
            MessageBox.Show("Please Connect USB C/COM DUT", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ConnectDUT.Select()
            DUTDisconnect()
            Exit Sub
        End If


        'If SerialPortPS.IsOpen() = False Then
        'MessageBox.Show("Please Connect COM Power Supply", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'PSConnectSerial.Select()
        'Exit Sub
        'End If

        If ComboBoxCOMModTester.Text = "" _
           Or ComboBoxCOMModTester.Text = "Please Select COM DUT" Then
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "CANCEL", Color.Orange)
            MessageBox.Show("Select #COM", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBoxCOMModTester.Select()
            DUTDisconnect()
            Exit Sub
        End If



        If ComboBoxBRModTester.Text = "" _
           Or ComboBoxBRModTester.Text = "Please Select Baud Rate DUT" Then
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "CANCEL", Color.Orange)
            MessageBox.Show("Select Baud Rate", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ComboBoxBRModTester.Select()
            DUTDisconnect()
            Exit Sub
        End If



        TimerDetect.Stop()
        TimerDetect218.Stop()
        TimerDetect225.Stop()


        TimerDetect.Enabled() = False
        TimerDetect218.Enabled() = False
        TimerDetect225.Enabled() = False






        'On Error Resume Next
        TestingtimeStart1.Text = Format(Now, "HH:mm:ss") ' HH=jam 00-23, hh=AM atau PM
        TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeStart = Format(Now, "HH:mm:ss")
        Date_testDate.Text = Format(Now, "dd-MMM-yyyy") 'samakan format ini dengan csv/excel



        'If ComboBoxRWO_Id.Text = "" _
        '    Or ComboBoxRWO_Id.Text = "Please Input RWO ID" Then
        'MessageBox.Show("Please fill RWO ID", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'ComboBoxRWO_Id.Select()
        'Exit Sub
        'End If



        '------------------------------------------------------------------------------
        If ComboBoxModel.Text = "OPG-409218" Then '4 MAC (1barcode MAC, 1 barcode serial) 3 MAC generate sendiri dengan cara diurutkan
            collect_data_218()
        End If

        If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409258" Or ComboBoxModel.Text = "OPG-409259" Or ComboBoxModel.Text = "OPG-409260" Then
            collect_data()
        End If





    End Sub


    Private Sub collect_data()


        If IMEITextBox1.Text.Length <> 15 Then
            'TextBoxScan.Text = ""
            Do Until IMEITextBox1.Text.Length = 15
                IMEITextBox1.Text = ""
                'SerialNumTextBox.Text = InputBox("Scan Serial Number ID (9 digit)", "TESTING #1 :", "SE33975449", 500, 450)  'input box
                IMEITextBox1.Text = InputBox("Scan IMEI (15 digit)", "", "", 500, 450)  'input box
                'If e.KeyCode = Keys.Enter Then


                'End If
                If IMEITextBox1.Text = "" Then
                    'stop_process()
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "IMEI Scan", "CANCEL", Color.Orange)
                    testing_batal = "YES"
                    DUTDisconnect()
                    Exit Sub
                End If
            Loop
        End If

        IMEITextBox1.Text = Replace(IMEITextBox1.Text, ":", "")


        'TIME START FCT

        TestingtimeStart1.Text = Format(Now, "HH:mm:ss") ' HH=jam 00-23, hh=AM atau PM
        TestingtimeStart_fct = TestingtimeStart1.Text
        TestingtimeStart = Format(Now, "HH:mm:ss")  'dipakai untuk datagrid timing
        Date_testDate.Text = Format(Now, "dd-MMM-yyyy") 'samakan format ini dengan csv/excel

        add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "Modem FW Update")


        'add_row_grid_INPROGRESS_WAIT(DataGridView1.RowCount + 1)
        'Delay(10)  'ditambahkan delay spy tidak ada initial fail karena modem COM belum muncul
        'row_grid_REMOVE_WAIT(DataGridView1.RowCount)

        'row_grid_PASS(DataGridView1.RowCount)
        row_grid_counting(DataGridView1.RowCount, "WAIT 10 s")
        Delay(1)
        row_grid_counting(DataGridView1.RowCount, "WAIT 9 s")
        Delay(1)
        row_grid_counting(DataGridView1.RowCount, "WAIT 8 s")
        Delay(1)
        row_grid_counting(DataGridView1.RowCount, "WAIT 7 s")
        Delay(1)
        row_grid_counting(DataGridView1.RowCount, "WAIT 6 s")
        Delay(1)
        row_grid_counting(DataGridView1.RowCount, "WAIT 5 s")
        Delay(1)
        row_grid_counting(DataGridView1.RowCount, "WAIT 4 s")
        Delay(1)
        row_grid_counting(DataGridView1.RowCount, "WAIT 3 s")
        Delay(1)
        row_grid_counting(DataGridView1.RowCount, "WAIT 2 s")
        Delay(1)
        row_grid_counting(DataGridView1.RowCount, "IN PROGRESS...")
        Delay(1)





        CMDAutomate()



        Exit Sub
        '------------------------------------------------------------
        If SerialTextBox.Text.Length <> 28 Then
            Do Until SerialTextBox.Text.Length = 28
                SerialTextBox.Text = ""
                'SerialNumTextBox.Text = InputBox("Scan Serial Number ID (10 digit)", "TESTING #1 :", "SE33975449", 500, 450)  'input box
                SerialTextBox.Text = InputBox("Scan Serial (28 digit)", "", "", 500, 450)  'input box
                If SerialTextBox.Text = "" Then
                    'stop_process()
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Serial Scan", "CANCEL", Color.Orange)
                    testing_batal = "YES"
                    DUTDisconnect()
                    Exit Sub
                End If
            Loop
        End If





        If Trim(Mid(SerialTextBox.Text, 1, 6)) = "409225" Or
           Trim(Mid(SerialTextBox.Text, 1, 6)) = "409258" Or
           Trim(Mid(SerialTextBox.Text, 1, 6)) = "409259" Or
           Trim(Mid(SerialTextBox.Text, 1, 6)) = "409260" Then
            If Trim(Mid(ComboBoxModel.Text, 5, 15)) <> Trim(Mid(SerialTextBox.Text, 1, 6)) Then
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "CANCEL, wrong model!", Color.Orange)
                MsgBox("Pilih MODEL yg benar : OPG-" & Trim(Mid(SerialTextBox.Text, 1, 6)))
                DUTDisconnect()
                Exit Sub
            End If
        End If




        If CheckBoxRWO.Checked = False Then
            Try
                RWO_CEK()
            Catch ex As Exception

                reset_datagrid()
                reset_value()
                testing_batal = "YES"
                'Disconnect()
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "RWO Aegis Server", "FAIL", Color.IndianRed)
                MsgBox("check again RWO from AEGIS server..." & vbNewLine & vbNewLine &
                   "" & ex.Message, 262144)
                Delay(2)
                DUTDisconnect()
                Exit Sub
            End Try
        End If

        '----------------------------------------------------------------



        Dim hexString As String = Nothing

        'hexString = TextBoxScan.Text.Trim
        hexString = Trim(Mid(IMEITextBox1.Text, 6, 20))
        'MsgBox(hexString)
        'hexString = Trim(MACTextBox.Text)
        'MsgBox(hexString)

        'convert into decimal
        Dim decValue As Integer = 0
        decValue = CInt("&H" & hexString) 'hanya untuk digit kecil



        MACTextBox2.Text = "0013C" & Hex(decValue + 1)

        If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409259" Then
            MACsw0TextBox.Text = "0013C" & Hex(decValue + 2)
        End If




        'get_mac_dll_225()

        Try
            'CekMACDB = GetMac(SerialTextBox.Text)

            CekMAC = CekMACDB.Split(",")
            GetMAC1 = CekMAC(0)
            GetMAC2 = CekMAC(1)
            If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409259" Then
                GETMAC3 = CekMAC(2)
            End If
        Catch ex As Exception
            DUTDisconnect()
            MsgBox(ex.Message & vbNewLine & "Or serial number not valid")
        End Try



        GetMAC1_new = Replace(GetMAC1, ":", "")
        GetMAC2_new = Replace(GetMAC2, ":", "")

        If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409259" Then
            GetMAC3_new = Replace(GETMAC3, ":", "")
        End If


        If IMEITextBox1.Text = GetMAC1_new Then
            IMEITextBox1.Text = GetMAC1_new
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Check MAC #1", "MATCH : " & GetMAC1, Color.LightGreen)
        Else
            'MsgBox("Testing CANCEL MAC #1 not match")
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Check MAC #1", "NOT MATCH : " & GetMAC1, Color.Orange)
            DUTDisconnect()
            Exit Sub
        End If

        If MACTextBox2.Text = GetMAC2_new Then
            MACTextBox2.Text = GetMAC2_new
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Check MAC #2", "MATCH : " & GetMAC2, Color.LightGreen)
        Else
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Check MAC #2", "NOT MATCH : " & GetMAC2, Color.Orange)
            'MsgBox("Testing CANCEL MAC #2 not match")
            DUTDisconnect()
            Exit Sub
        End If


        If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409259" Then
            If MACsw0TextBox.Text = GetMAC3_new Then
                MACsw0TextBox.Text = GetMAC3_new
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Check MAC sw0", "MATCH : " & GETMAC3, Color.LightGreen)
            Else
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Check MAC sw0", "NOT MATCH : " & GETMAC3, Color.Orange)
                'MsgBox("Testing CANCEL MAC sw0 not match")
                DUTDisconnect()
                Exit Sub
            End If
        End If


        MAC1 = "rwmac net1 --mac " & IMEITextBox1.Text & " --init" '& vbNewLine & vbNewLine
        MAC2 = "rwmac net2 --mac " & MACTextBox2.Text & " --init" '& vbNewLine & vbNewLine

        If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409259" Then
            MACsw0 = "rwmac sw0 --mac " & MACsw0TextBox.Text & " --init" '& vbNewLine & vbNewLine
        End If


        'PasswordTextBox.Text = "NA"

        TestingtimeStart1.Text = Format(Now, "HH:mm:ss") ' HH=jam 00-23, hh=AM atau PM
        TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeStart = Format(Now, "HH:mm:ss")
        Date_testDate.Text = Format(Now, "dd-MMM-yyyy") 'samakan format ini dengan csv/excel

        MsgBox("Pasang POWER ON ke DUT sekarang")
        add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "DUT Autoboot")

        TimerDetect.Start()
        TimerDetect.Enabled = True

    End Sub

    Sub CMDAutomate()

        'ok bisa keluar datanya tapi data programing nya tidak keluar
        Dim commandxx As String

        'update_
        'pc opg-225
        '#1 COM15
        'commandxx = "fdt2.exe -d g5k -usbhub 2 -usbport 1 -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>
        '>>> old command ok : commandxx = "fdt2.exe -d g5k -usbhub " & HUB_FW.Text & " -usbport " & PORT_FW.Text & " -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu  -log RESULT_1" ' if user want to pass any argum>

        'new firmware:
        commandxx = "fdt2.exe -d g5k -usbhub " & HUB_FW.Text & " -usbport " & PORT_FW.Text & " -multi -f SWI9X50C_01.14.22.00_TELUS_001.029_000.nvu SWI9X50C_01.14.22.00_TMO_002.020_000.nvu SWI9X50C_01.14.24.00.cwe SWI9X50C_01.14.24.00_VERIZON_002.064_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.059_001.nvu SWI9X50C_01.14.13.00.cwe SWI9X50C_01.14.13.00_ROGERS_002.021_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.059_001.nvu -log RESULT_1"

        '#2 COM17
        'commandxx = "fdt2.exe -d g5k -usbhub 2 -usbport 4 -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>


        'pc port server
        '#1 COM13
        'commandxx = "fdt2.exe -d g5k -usbhub 6 -usbport 1 -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>

        '#2 COM15
        'commandxx = "fdt2.exe -d g5k -usbhub 6 -usbport 4 -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>
        'https://www.vbforums.com/showthread.php?497424-RESOLVED-Close-Command-Prompt-programmatically

        Dim myprocess As New Process
        Dim StartInfo As New System.Diagnostics.ProcessStartInfo
        StartInfo.FileName = "cmd.exe" 'starts cmd window
        'StartInfo.Arguments = "/K " + commandxx + " -s:Result.txt"
        'StartInfo.WindowStyle = ProcessWindowStyle.Minimized
        StartInfo.RedirectStandardInput = True
        StartInfo.RedirectStandardOutput = True
        StartInfo.CreateNoWindow = True '<---- if you want to not create a window
        StartInfo.UseShellExecute = False 'required to redirect
        StartInfo.Verb = "runas" 'required to redirect


        myprocess.StartInfo = StartInfo
        myprocess.Start()

        'Exit Sub

        Dim SR As System.IO.StreamReader = myprocess.StandardOutput
        Dim SW As System.IO.StreamWriter = myprocess.StandardInput
        SW.WriteLine("D:") ' & commandxx)  
        SW.WriteLine("cd D:\SIERRA_TEST\Firmware_1\") ' & commandxx)  'update_
        'SW.WriteLine("cd D:\SIERRA_TEST\Firmware_2\") ' & commandxx)   'update_
        'SW.WriteLine(commandxx + " > D:\""Local Host.txt""")
        SW.WriteLine(commandxx) 'jika >> maka akan append dengan Text sebelumnya
        'SW.WriteLine(commandxx + " >D:\Result.txt") 'jika >> maka akan append dengan Text sebelumnya
        'SW.WriteLine(commandxx + " -l Result.txt") 'jika >> maka akan append dengan Text sebelumnya
        'SW.WriteLine("ping 10.218.164.220") 
        'SW.WriteLine("cd c:\g5k")


        'row_grid_REMOVE_WAIT(DataGridView1.RowCount)

        'SerialPort1.Write(New Byte() {3}, 0, 1) 'Ctrl+C ok
        'SerialPort1.Write(New Byte() {4}, 0, 1) 'Ctrl+D

        'Delay1(10)
        'SW.WriteLine("q")
        'SW.WriteLine("quit") 'exits command prompt window, wajib pakai

        'SW.WriteLine("^C") 'exits command prompt window, wajib pakai
        SW.WriteLine("exit") 'exits command prompt window, wajib pakai
        RichTextBox1.Text &= SR.ReadToEnd.ToString '& vbNewLine
        myprocess.Close()
        SW.Close()
        SR.Close()
        'myprocess.Kill()

        'SW.WriteLine("exit") 'exits command prompt window, wajib pakai

        'MsgBox("Close cmd prompt firmware upgrade 1")


        'myprocess.WaitForExit()
        'String Res = File.ReadAllText(output)

        'File.Delete(output)

        '---------------------------------------------------
        For Each filex As String In My.Computer.FileSystem.GetFiles(path_log1) 'update_
            'ListBox1.Items.Add(IO.Path.GetFileName(filex))  ' bisa dipakai jika ingin di list dalam listbox


            TextBox1.Text = (IO.Path.GetFileName(filex))

            'load text to richtext box
            RichTextBox2.Text = File.ReadAllText(path_log1 & TextBox1.Text)

            'move sekaligus rename (source and target same ip / internal pc)
            'https://stackoverflow.com/questions/40130549/copying-a-folder-and-its-contents-in-vb-net
            'Directory.Move(path_log1 & TextBox1.Text, "D:\SIERRA_TEST\Firmware_1\log_original_1\" & IMEITextBox1.Text & "_" & TextBox1.Text) 'update_

        Next





        If RichTextBox2.Text.Contains("Final update status: SUCCESSFUL") = True And
            RichTextBox2.Text.Contains("Firmware update succeeded") = True Then
            fail_reason = ""
            Upgrade_Firm_process = "PASS"
            row_grid_PASS(DataGridView1.RowCount)


            'cek imei jika salah scan  (very slow)
            'If RichTextBox2.Text.Contains("IMEI:") = True Then
            'get_imei_number_from_log()
            'fail_reason = "WRONG SCAN IMEI!!"
            'Upgrade_Firm_process = "FAIL"
            'row_grid_FAIL_reason(DataGridView1.RowCount, "WRONG SCAN IMEI")
            'End If


            'cek imei jika salah scan  (faster)
            If RichTextBox2.Text.Contains("IMEI: " & IMEITextBox1.Text) = False Then

                fail_reason = "WRONG IMEI SCAN!!"
                Upgrade_Firm_process = "FAIL"
                add_row_grid_RESULT(DataGridView1.RowCount + 1, "WRONG IMEI SCAN", "FAIL", Color.IndianRed)


                statusfinaltest_result = "WRONG IMEI SCAN"
                ResultTextBoxFCT.Text = "FAIL"
                ResultTextBoxFCT.BackColor = Color.IndianRed
                add_row_grid_RESULT_BOLD_FCT(DataGridView1.RowCount + 1, "Overall FCT", "FAIL", Color.IndianRed)


                TestingtimeEnd = DateTime.Now
                Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart_fct).ToString("hh':'mm':'ss")


                save_log_FW_update2()
                add_DB_all()



                MsgBox("TESTING FAIL, SALAH SCAN IMEI!" & vbNewLine & vbNewLine &
                       "ULANGI update firmware dan scan IMEI yang benar")
            End If


            If RichTextBox2.Text.Contains("IMEI: " & IMEITextBox1.Text) = True Then
                Delay(5)
                AT_COM_()
            End If

        End If





        If RichTextBox2.Text.Contains("Firmware update failed") = True Then
            row_grid_FAIL(DataGridView1.RowCount)

            'fail_reason = fail1 & fail2 & fail3 & fail4
            get_failure_primary_secondary()
            fail_reason = Primary_fail & vbNewLine & Secondary_fail & vbNewLine & Device_fail
            'Primary_fail
            'Secondary_fail
            Upgrade_Firm_process = "FAIL"

            statusfinaltest_result = "FAIL"
            ResultTextBoxFCT.Text = "FAIL"
            ResultTextBoxFCT.BackColor = Color.IndianRed
            add_row_grid_RESULT_BOLD_FCT(DataGridView1.RowCount + 1, "Overall FCT", "FAIL", Color.IndianRed)


            TestingtimeEnd = DateTime.Now
            Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart_fct).ToString("hh':'mm':'ss")


            save_log_FW_update2()
            add_DB_all()

            MsgBox("TESTING FAIL")

            'RichTextBox2.Clear()
            'ListBox1.Items.Clear()
            'TextBox1.Clear()

        End If

        Directory.Move(path_log1 & TextBox1.Text, "D:\SIERRA_TEST\Firmware_1\log_original_1\" & IMEITextBox1.Text & "_" & Upgrade_Firm_process & "_" & TextBox1.Text) 'update_

        '---------------------------------------------------


        Exit Sub

        Form_Fail.ShowDialog()



        If Upgrade_Firm_process = "PASS" Then
            fail_reason = ""
            row_grid_PASS(DataGridView1.RowCount)

            Delay(5)
            AT_COM_()
        End If


        If Upgrade_Firm_process = "FAIL" Then
            'Upgrade_Firm_process = "FAIL"
            row_grid_FAIL(DataGridView1.RowCount)



            fail_reason = fail1 & fail2 & fail3 & fail4


            'MsgBox(fail_reason)

            statusfinaltest_result = "FAIL"
            ResultTextBoxFCT.Text = "FAIL"
            ResultTextBoxFCT.BackColor = Color.IndianRed
            add_row_grid_RESULT_BOLD_FCT(DataGridView1.RowCount + 1, "Overall FCT", "FAIL", Color.IndianRed)



            TestingtimeEnd = DateTime.Now
            Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart_fct).ToString("hh':'mm':'ss")


            save_log_FW_update2()
            add_DB_all()

            MsgBox("TESTING FAIL")
        End If






        Exit Sub

        Using form = New Form() With {.TopMost = True} 'update_
            intResponse1 = MessageBox.Show(form, "Apakah proses Upgrade Firmware berhasil?", "FW Update 1", vbYesNo)
        End Using

        If intResponse1 = vbYes Then
            Upgrade_Firm_process = "PASS"
            row_grid_PASS(DataGridView1.RowCount)
        End If

        If intResponse1 = vbNo Then

            Form_Fail.Show()

            Upgrade_Firm_process = "FAIL"
            row_grid_FAIL(DataGridView1.RowCount)

            'fail_reason

            statusfinaltest_result = "FAIL"
            ResultTextBoxFCT.Text = "FAIL"
            ResultTextBoxFCT.BackColor = Color.IndianRed
            add_row_grid_RESULT_BOLD(DataGridView1.RowCount + 1, "Overall FCT", "FAIL", Color.IndianRed)

            save_log_FW_update2()


        End If


    End Sub

    Private Sub Button8_Click_2(sender As Object, e As EventArgs) Handles Button8.Click

        'test123_new2()
        'test123_init()

        'get_imei_number_from_log()

        'MsgBox(imei_log)

        If RichTextBox1.Text.Contains("SWI9X50C_01.14.22.00") Then
            impref5 = "PASS"
        Else
            impref5 = "FAIL"
        End If

        MsgBox(impref5)

    End Sub

    Sub test123_new2() 'ok bisa jalan, tapi exe wajib di seting run as admin. dan bisa dipindah ke richtextbox1.
        'kekurangan cara ini: mouse jgn dipindah karena mouse fokus ke jendela cmd promt saja, jika ada error maka akan kirim send key terus --coba gunakan try dulu 
        'coba sendkey ke ke form tertentu.
        Dim commandxx As String
        commandxx = "fdt2.exe -d g5k -usbhub " & HUB_FW.Text & " -usbport " & PORT_FW.Text & " -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' -log D:\SIERRA_TEST\Firmware_1" ' if user want to pass any argum>
        Dim commandprompt As Integer

        commandprompt = Shell("c:\windows\system32\cmd.exe", AppWinStyle.NormalFocus, True, 1000)
        'commandprompt = Shell("D:\SIERRA_TEST\Firmware_1\fdt2.exe", AppWinStyle.NormalFocus, True, 1000)
        AppActivate(commandprompt)
        My.Computer.Keyboard.SendKeys("D:")
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys("cd D:\SIERRA_TEST\Firmware_1\")
        'My.Computer.Keyboard.SendKeys("netsh")
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys(commandxx)
        My.Computer.Keyboard.SendKeys("{Enter}")

        Delay(15)
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys(Chr(94) & Chr(97)) '^a  --select all
        My.Computer.Keyboard.SendKeys(Chr(94) & Chr(97)) '^a  --select all
        My.Computer.Keyboard.SendKeys(Chr(94) & Chr(99)) '^c  --copy
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys("exit")
        My.Computer.Keyboard.SendKeys("{Enter}")
        'Exit Sub

        Me.RichTextBox1.Select()
        My.Computer.Keyboard.SendKeys(Chr(94) & Chr(118)) '^v  --paste


        'My.Computer.Keyboard.SendKeys(Chr(34) & "d:" & Chr(34))


        'Delay(20)

        'My.Computer.Keyboard.SendKeys(Chr(94) & Chr(97))
        'My.Computer.Keyboard.SendKeys("{Enter}")

    End Sub
    Sub test123_new1() 'ok bisa jalan, jika exe di seting run as admin. dan bisa dipindah ke richtextbox1.
        'kekurangan cara ini: mouse jgn dipindah karena mouse fokus ke jendela cmd promt saja, jika ada error maka akan kirim send key terus --coba gunakan try dulu 
        'coba sendkey ke ke form tertentu.
        Dim commandxx As String
        commandxx = "fdt2.exe -d g5k -usbhub " & HUB_FW.Text & " -usbport " & PORT_FW.Text & " -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' -log D:\SIERRA_TEST\Firmware_1" ' if user want to pass any argum>
        Dim commandprompt As Integer

        commandprompt = Shell("c:\windows\system32\cmd.exe", AppWinStyle.NormalFocus, True, 1000)
        'commandprompt = Shell("D:\SIERRA_TEST\Firmware_1\fdt2.exe", AppWinStyle.NormalFocus, True, 1000)
        AppActivate(commandprompt)
        My.Computer.Keyboard.SendKeys("D:")
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys("cd D:\SIERRA_TEST\Firmware_1\")
        'My.Computer.Keyboard.SendKeys("netsh")
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys(commandxx)
        My.Computer.Keyboard.SendKeys("{Enter}")

        Delay(15)
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys(Chr(94) & Chr(97)) '^a  --select all
        My.Computer.Keyboard.SendKeys(Chr(94) & Chr(97)) '^a  --select all
        My.Computer.Keyboard.SendKeys(Chr(94) & Chr(99)) '^c  --copy
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys("{Enter}")
        My.Computer.Keyboard.SendKeys("exit")
        My.Computer.Keyboard.SendKeys("{Enter}")
        'Exit Sub

        Me.RichTextBox1.Select()
        My.Computer.Keyboard.SendKeys(Chr(94) & Chr(118)) '^v  --paste


        'My.Computer.Keyboard.SendKeys(Chr(34) & "d:" & Chr(34))


        'Delay(20)

        'My.Computer.Keyboard.SendKeys(Chr(94) & Chr(97))
        'My.Computer.Keyboard.SendKeys("{Enter}")

    End Sub
    Sub test123_init()  'cara ini masih NOK

        'ok bisa keluar datanya tapi data programing nya tidak keluar
        Dim commandxx As String

        'update_
        'pc opg-225
        '#1 COM15
        'commandxx = "fdt2.exe -d g5k -usbhub 2 -usbport 1 -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>
        commandxx = "fdt2.exe -d g5k -usbhub " & HUB_FW.Text & " -usbport " & PORT_FW.Text & " -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -log RESULT_1" ' if user want to pass any argum>
        'commandxx = "fdt2.exe -s g5k -usbhub " & HUB_FW.Text & " -usbport " & PORT_FW.Text & " -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>



        '#2 COM17
        'commandxx = "fdt2.exe -d g5k -usbhub 2 -usbport 4 -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>


        'pc port server
        '#1 COM13
        'commandxx = "fdt2.exe -d g5k -usbhub 6 -usbport 1 -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>

        '#2 COM15
        'commandxx = "fdt2.exe -d g5k -usbhub 6 -usbport 4 -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>
        'https://www.vbforums.com/showthread.php?497424-RESOLVED-Close-Command-Prompt-programmatically

        Dim myprocess As New Process
        Dim StartInfo As New System.Diagnostics.ProcessStartInfo
        StartInfo.FileName = "cmd.exe" 'starts cmd window
        'StartInfo.Arguments = "/K " + commandxx + " -s:Result.txt"
        'StartInfo.WindowStyle = ProcessWindowStyle.Minimized
        StartInfo.RedirectStandardInput = True
        StartInfo.RedirectStandardOutput = True
        StartInfo.CreateNoWindow = True '<---- if you want to not create a window
        StartInfo.UseShellExecute = False 'required to redirect
        StartInfo.Verb = "runas" 'required to redirect


        myprocess.StartInfo = StartInfo
        myprocess.Start()

        'Exit Sub

        Dim SR As System.IO.StreamReader = myprocess.StandardOutput
        Dim SW As System.IO.StreamWriter = myprocess.StandardInput
        SW.WriteLine("D:") ' & commandxx)  
        SW.WriteLine("cd D:\SIERRA_TEST\Firmware_1\") ' & commandxx)  'update_
        'SW.WriteLine("cd D:\SIERRA_TEST\Firmware_2\") ' & commandxx)   'update_
        'SW.WriteLine(commandxx + " > D:\""Local Host.txt""")
        SW.WriteLine(commandxx) 'jika >> maka akan append dengan Text sebelumnya
        'SW.WriteLine(commandxx + " >D:\Result.txt") 'jika >> maka akan append dengan Text sebelumnya
        'SW.WriteLine(commandxx + " -l Result.txt") 'jika >> maka akan append dengan Text sebelumnya
        'SW.WriteLine("ping 10.218.164.220") 
        'SW.WriteLine("cd c:\g5k")


        'row_grid_REMOVE_WAIT(DataGridView1.RowCount)

        'SerialPort1.Write(New Byte() {3}, 0, 1) 'Ctrl+C ok
        'SerialPort1.Write(New Byte() {4}, 0, 1) 'Ctrl+D

        'Delay1(10)
        'SW.WriteLine("q")
        'SW.WriteLine("quit") 'exits command prompt window, wajib pakai

        'SW.WriteLine("^C") 'exits command prompt window, wajib pakai

        'Delay(10)
        'AppActivate(commandprompt)
        'System.Windows.Forms.SendKeys.Send(Chr(94) & Chr(97))

        'My.Computer.Keyboard.SendKeys("{Enter}")
        'My.Computer.Keyboard.SendKeys(Chr(94) & Chr(97)) '^a  --select all
        'My.Computer.Keyboard.SendKeys(Chr(94) & Chr(97)) '^a  --select all
        'My.Computer.Keyboard.SendKeys(Chr(94) & Chr(99)) '^c  --copy
        'My.Computer.Keyboard.SendKeys("{Enter}")
        'My.Computer.Keyboard.SendKeys("{Enter}")


        'Me.RichTextBox1.Select()
        'My.Computer.Keyboard.SendKeys(Chr(94) & Chr(118)) '^v  --paste
        'SW.WriteLine(Chr(94) & Chr(97))
        'SW.WriteLine(Chr(94) & Chr(97))
        'SW.WriteLine(Chr(94) & Chr(99))
        'SW.WriteLine("{Enter}")

        SW.WriteLine("exit") 'exits command prompt window, wajib pakai
        RichTextBox1.Text &= SR.ReadToEnd.ToString '& vbNewLine
        myprocess.Close()
        SW.Close()
        SR.Close()

        'My.Computer.Keyboard.SendKeys("{Enter}")
        'My.Computer.Keyboard.SendKeys(Chr(94) & Chr(97)) '^a  --select all

        'myprocess.Kill()

        'SW.WriteLine("exit") 'exits command prompt window, wajib pakai

        'MsgBox("Close cmd prompt firmware upgrade 1")


        'myprocess.WaitForExit()
        'String Res = File.ReadAllText(output)

        'File.Delete(output)
    End Sub
    Sub test123()
        Dim commandxx As String
        commandxx = "fdt2.exe -d g5k -usbhub " & HUB_FW.Text & " -usbport " & PORT_FW.Text & " -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' -log D:\SIERRA_TEST\Firmware_1" ' if user want to pass any argum>
        'commandxx = "fdt2.exe -d g5k -fd D:\SIERRA_TEST\Firmware_1 -log Result1.txt -usbhub " & HUB_FW.Text & " -usbport " & PORT_FW.Text & " -multi -f SWI9X50C_01.14.03.00.cwe SWI9X50C_01.14.03.00_US-CELLULAR_002.011_001.nvu SWI9X50C_01.14.03.00_TELUS_001.013_003.nvu SWI9X50C_01.14.03.00_TMO_002.005_004.nvu SWI9X50C_01.14.20.00.cwe SWI9X50C_01.14.20.00_VERIZON_002.058_000.nvu SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_ATT_002.071_001.nvu SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu -mi -impref SWI9X50C_01.14.22.00.cwe SWI9X50C_01.14.22.00_GENERIC_002.057_000.nvu" ' if user want to pass any argum>


        Dim myprocess As New Process
        Dim StartInfo As New System.Diagnostics.ProcessStartInfo
        StartInfo.FileName = "D:\SIERRA_TEST\Firmware_1\fdt2.exe" 'starts cmd window
        'StartInfo.FileName = "cmd" 'starts cmd window
        'StartInfo.Arguments = "/k " + commandxx '+ " >D:\Result2.txt"
        StartInfo.Arguments = commandxx + " >D:\Result2.txt"
        'StartInfo.WindowStyle = ProcessWindowStyle.Minimized

        StartInfo.CreateNoWindow = False '<---- if you want to not create a window
        StartInfo.UseShellExecute = True 'required to redirect

        myprocess.StartInfo = StartInfo
        myprocess.Start()


    End Sub

    Sub get_imei_number_from_log()
        For i As Integer = 0 To RichTextBox2.Lines.Count - 1
            Dim line As String = RichTextBox2.Lines(i)

            'Dim read_power As String
            If line.Contains("IMEI:") Then

                'image_version = Trim(Replace(image_version, " manufacturing /dev/ttymxc3", ""))


                imei_log = Trim(line) '& vbCrLf
                imei_log = Trim(Mid(imei_log, 46, 1000))

            End If


        Next
    End Sub

    Sub get_failure_primary_secondary()
        For i As Integer = 0 To RichTextBox2.Lines.Count - 1
            Dim line As String = RichTextBox2.Lines(i)

            'Dim read_power As String
            If line.Contains("Primary error code:") Then

                'image_version = Trim(Replace(image_version, " manufacturing /dev/ttymxc3", ""))


                Primary_fail = Trim(line) '& vbCrLf
                Primary_fail = Trim(Mid(Primary_fail, 46, 1000))

            End If

            If line.Contains("Secondary error code:") Then
                Secondary_fail = Trim(line) '& vbCrLf
                Secondary_fail = Trim(Mid(Secondary_fail, 46, 1000))

            End If

            If line.Contains("Device error code:") Then
                Device_fail = Trim(line) '& vbCrLf
                Device_fail = Trim(Mid(Device_fail, 46, 1000))

            End If

        Next
    End Sub
    Sub add_DB_PASS()



        Try
            'On Error GoTo error1

            'Dim cmd_edit As SqlCommand = New SqlCommand _
            '("DELETE FROM [U120].[dbo].[Tbl_Initial_Data] WHERE ([Model_Build_Num] = '" & ComboBoxBuildNumber.Text & "')", conn)
            'cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = userName

            'No = DataGridView1.RowCount + 1

            'DataGridView1.ClearSelection()

            Dim cmd_edit As SqlCommand = New SqlCommand _
        ("INSERT INTO [U120].[dbo].[Modem_Sierra_log_PASS] 
        ([Operator Name]
        ,[Operator BadgeID]
        ,[Date Test] 
        ,[Start Time] 
        ,[Model] 
        ,[IMEI] 
        ,[Status]  
        ,[Failure]) 
         VALUES
        ('" & ComboBoxOpName.Text.ToUpper() & "'
        ,'" & ComboBoxBadgeId.Text.ToUpper() & "'
        ,'" & Date_testDate.Text.ToUpper() & "'
        ,'" & TestingtimeStart1.Text & "'
        ,'" & ComboBoxModel.Text.ToUpper() & "'
        ,'" & IMEITextBox1.Text.ToUpper() & "'
        ,'" & statusfinaltest_result.ToUpper() & "'
        ,'" & fail_reason.ToUpper() & "')", conn)


            conn.Open()
            cmd_edit.ExecuteNonQuery()
            conn.Close()



            'Dim cmd_short As SqlCommand = New SqlCommand _
            '("SELECT * FROM [U120].[dbo].[Tbl_Initial_Data]  ORDER BY [No] ASC", conn)

            'conn.Open()
            'cmd_short.ExecuteNonQuery()
            'conn.Close()


            'show_sql2datagrid()

            'refresh_combo_new()
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)

        End Try
    End Sub
    Sub add_DB_all()



        Try
            'On Error GoTo error1

            'Dim cmd_edit As SqlCommand = New SqlCommand _
            '("DELETE FROM [U120].[dbo].[Tbl_Initial_Data] WHERE ([Model_Build_Num] = '" & ComboBoxBuildNumber.Text & "')", conn)
            'cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = userName

            'No = DataGridView1.RowCount + 1

            'DataGridView1.ClearSelection()

            Dim cmd_edit As SqlCommand = New SqlCommand _
        ("INSERT INTO [U120].[dbo].[Modem_Sierra_log_ALL] 
        ([Operator Name]
        ,[Operator BadgeID]
        ,[Date Test] 
        ,[Start Time] 
        ,[Model] 
        ,[IMEI] 
        ,[Status]  
        ,[Failure]) 
         VALUES
        ('" & ComboBoxOpName.Text.ToUpper() & "'
        ,'" & ComboBoxBadgeId.Text.ToUpper() & "'
        ,'" & Date_testDate.Text.ToUpper() & "'
        ,'" & TestingtimeStart1.Text & "'
        ,'" & ComboBoxModel.Text.ToUpper() & "'
        ,'" & IMEITextBox1.Text.ToUpper() & "'
        ,'" & statusfinaltest_result.ToUpper() & "'
        ,'" & fail_reason.ToUpper() & "')", conn)




            conn.Open()
            cmd_edit.ExecuteNonQuery()
            conn.Close()



            'Dim cmd_short As SqlCommand = New SqlCommand _
            '("SELECT * FROM [U120].[dbo].[Tbl_Initial_Data]  ORDER BY [No] ASC", conn)

            'conn.Open()
            'cmd_short.ExecuteNonQuery()
            'conn.Close()


            'show_sql2datagrid()

            'refresh_combo_new()
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.Message)

        End Try
    End Sub

    Sub dial_modem_atcom()
        Try

            'If My.Computer.Ports.SerialPortNames() = True Then
            Using com As IO.Ports.SerialPort = My.Computer.Ports.OpenSerialPort(ComboBoxCOMModTester.Text, 115200)
                'com.DtrEnable = True
                'com12.Write("ATDT 555-0100" & vbCrLf)
                RichTextBox1.Text &= vbNewLine
                com.Write("AT" & vbCrLf)
                'txtOutput.Text &= vbNewLine
                'Delay(1)
                RichTextBox1.Text &= com.ReadExisting() & vbNewLine 'jgn diganti readline jadi hang 
                'Delay(2)

                RichTextBox1.Text &= vbNewLine
                com.Write("AT!IMAGE?" & vbCrLf)
                'com.Write(Chr(13))
                'com.Write(New Byte() {10}, 0, 1)
                'com.Write("AT" & vbCrLf)
                'txtOutput.Text &= vbNewLine
                'Delay(1)
                RichTextBox1.Text &= com.ReadExisting() & vbNewLine
                'Delay(2)


                RichTextBox1.Text &= vbNewLine
                com.Write("AT!IMPREF?" & vbCrLf)
                'txtOutput.Text &= vbNewLine
                RichTextBox1.Text &= com.ReadExisting() & vbNewLine
                'Delay(2)

                RichTextBox1.Text &= vbNewLine
                com.Write("AT+GMR" & vbCrLf)
                'txtOutput.Text &= vbNewLine
                RichTextBox1.Text &= com.ReadExisting() & vbNewLine
                'Delay(2)

            End Using
            'End If

        Catch ex As Exception

            MsgBox(ex.Message & vbNewLine & vbNewLine &
                   "KLIK TOMBOL 'AT COMMAND' KEMBALI!")
        End Try
    End Sub
    Dim AT_count As Integer = 0

    'Private Sub AT_COM_Click_2(sender As Object, e As EventArgs) Handles AT_COM.Click
    Sub AT_COM_()
        AT_count = AT_count + 1


        If ComboBoxModel.Text = "" Then
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "CANCEL", Color.Orange)
            MessageBox.Show("Pilih terlebih dahulu OPG MODEL!", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ComboBoxModel.Select()
            DUTDisconnect()
            Exit Sub
        End If

        'RichTextBox1.Clear()
        'add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "AT COM")

        'row_grid_Done(DataGridView1.RowCount)
        add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "Get AT COMMAND")
        Delay(2)
        dial_modem_atcom()
        Delay(2)
        dial_modem_atcom()
        Delay(2)
        dial_modem_atcom()
        Delay(2)
        parsing_FW_version()

        'update jika ganti firmware
        If att = "PASS" And generic = "PASS" And telus = "PASS" And tmo = "PASS" And rogers = "PASS" And verizon = "PASS" And impref1 = "PASS" And impref2 = "PASS" And impref3 = "PASS" And impref4 = "PASS" And impref5 = "PASS" And
            Upgrade_Firm_process = "PASS" Then
            statusfinaltest_result = "PASS"
            ResultTextBoxFCT.Text = "PASS"
            ResultTextBoxFCT.BackColor = Color.LightGreen
            add_row_grid_RESULT_BOLD_FCT(DataGridView1.RowCount + 1, "Overall FCT", "PASS", Color.LightGreen)

            If AT_count = 1 Then
                add_DB_PASS()
                add_DB_all()
            End If


        Else
            statusfinaltest_result = "FAIL"
            ResultTextBoxFCT.Text = "FAIL"
            ResultTextBoxFCT.BackColor = Color.IndianRed
            add_row_grid_RESULT_BOLD_FCT(DataGridView1.RowCount + 1, "Overall FCT", "FAIL", Color.IndianRed)

            'If AT_count = 1 Then
            fail_reason = "AT COMM: Firmware version not match"
            add_DB_all()
            'End If
        End If



        'TestingtimeStart = TestingtimeStart1.Text
        TestingtimeEnd = DateTime.Now
        Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart_fct).ToString("hh':'mm':'ss")
        MsgBox("Testing SELESAI, RESULT : " & statusfinaltest_result & vbNewLine & vbNewLine &
               "Silahkan CABUT dan PASANG MODEM yang BARU")

        'TAMBAHKAN EDIT DB

        save_log_FW_update()

        RichTextBox2.Clear()

    End Sub

    Dim att, generic, telus, tmo, rogers, verizon, impref1, impref2, impref3, impref4, impref5, prefer_current, all_firm As String

    Private Sub AT_COM_Click(sender As Object, e As EventArgs) Handles AT_COM.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Re_checkAT_Click(sender As Object, e As EventArgs) Handles Re_checkAT.Click
        RichTextBox1.Clear()
        reset_datagrid()
        add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "Get AT COMMAND")
        Delay(2)
        dial_modem_atcom()
        Delay(2)
        dial_modem_atcom()
        Delay(2)
        dial_modem_atcom()
        Delay(2)

        parsing_FW_version()

    End Sub

    Sub parsing_FW_version()   'update jika ganti firmware
        'row_grid_REMOVE_WAIT(DataGridView1.RowCount)
        row_grid_Done(DataGridView1.RowCount)
        If RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.071_001 01.14.22.00_ATT") Then
            att = "PASS"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify ATT_version", "MATCH", Color.LightGreen)
        ElseIf RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.071_001 01.14.22.00_ATT") = False Then
            att = "FAIL"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify ATT_version", "FAIL", Color.IndianRed)
        End If


        If RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.059_001 01.14.22.00_GENERIC") Then
            generic = "PASS"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify GENERIC_version", "MATCH", Color.LightGreen)
        ElseIf RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.059_001 01.14.22.00_GENERIC") = False Then
            generic = "FAIL"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify GENERIC_version", "FAIL", Color.IndianRed)
        End If


        If RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.021_000 01.14.13.00_ROGERS") Then
            rogers = "PASS"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify ROGERS_version", "MATCH", Color.LightGreen)
        ElseIf RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.021_000 01.14.13.00_ROGERS") = False Then
            rogers = "FAIL"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify ROGERS_version", "FAIL", Color.IndianRed)
        End If



        If RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      001.029_000 01.14.22.00_TELUS") Then
            telus = "PASS"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify TELUS_version", "MATCH", Color.LightGreen)
        ElseIf RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      001.029_000 01.14.22.00_TELUS") = False Then
            telus = "FAIL"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify TELUS_version", "FAIL", Color.IndianRed)
        End If



        If RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.020_000 01.14.22.00_TMO") Then
            tmo = "PASS"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify TMO_version", "MATCH", Color.LightGreen)
        ElseIf RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.020_000 01.14.22.00_TMO") = False Then
            tmo = "FAIL"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify TMO_version", "FAIL", Color.IndianRed)
        End If




        If RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.064_000 01.14.24.00_VERIZON") Then
            verizon = "PASS"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify Verizon_version", "MATCH", Color.LightGreen)
        ElseIf RichTextBox1.Text.Contains("PRI  FF   GOOD   0   0 0      002.064_000 01.14.24.00_VERIZON") = False Then
            verizon = "FAIL"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Verify Verizon_version", "FAIL", Color.IndianRed)
        End If



        If RichTextBox1.Text.Contains("preferred fw version:    01.14.22.00") And RichTextBox1.Text.Contains("current fw version:      01.14.22.00") Then
            impref1 = "PASS"
        Else
            impref1 = "FAIL"

        End If


        If RichTextBox1.Text.Contains("preferred carrier name:  GENERIC") And RichTextBox1.Text.Contains("current carrier name:    GENERIC") Then
            impref2 = "PASS"
        Else
            impref2 = "FAIL"
        End If


        If RichTextBox1.Text.Contains("preferred config name:   GENERIC_002.059_001") And RichTextBox1.Text.Contains("current config name:     GENERIC_002.059_001") Then
            impref3 = "PASS"
        Else
            impref3 = "FAIL"
        End If

        If RichTextBox1.Text.Contains("preferred subpri index:  000") And RichTextBox1.Text.Contains("preferred subpri index:  000") Then
            impref4 = "PASS"
        Else
            impref4 = "FAIL"
        End If

        If RichTextBox1.Text.Contains("SWI9X50C_01.14.22.00") Then
            impref5 = "PASS"
        Else
            impref5 = "FAIL"
        End If


        If impref1 = "PASS" And impref2 = "PASS" And impref3 = "PASS" And impref4 = "PASS" Then
            prefer_current = "PASS"
            'row_grid_Done(DataGridView1.RowCount)
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Prefer-Current Version", "MATCH", Color.LightGreen)

        Else
            prefer_current = "FAIL"
            'row_grid_Done(DataGridView1.RowCount)
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Prefer-Current Version", "NOT MATCH", Color.IndianRed)


        End If

        If att = "PASS" And generic = "PASS" And telus = "PASS" And tmo = "PASS" And rogers = "PASS" And verizon = "PASS" And impref5 = "PASS" Then
            all_firm = "PASS"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "All Firmware Version", "MATCH", Color.LightGreen)
        Else
            all_firm = "FAIL"
            add_row_grid_RESULT(DataGridView1.RowCount + 1, "Several Firmware Version", "NOT MATCH", Color.IndianRed)
        End If

        'MsgBox(att & ";" & generic & ";" & telus & ";" & tmo & ";" & rogers & ";" & verizon & ";" & impref5)



    End Sub


    Dim login_status, write_MAC1, write_MAC2, write_MAC3, write_MACsw0, write_MAC4 As String
    Dim verify_MAC1, verify_MAC2, verify_MAC3, verify_MACsw0, verify_MAC4 As String
    Dim reboot_DUT, loopback As String


    Private Sub TimerDetect_Tick(sender As Object, e As EventArgs) Handles TimerDetect.Tick
        If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
            row_grid_Done(DataGridView1.RowCount)
            TimerDetect.Stop()
            TimerDetect.Enabled = False


            If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
                SerialPort1.WriteLine("root")
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")

                Delay(1)
                'If RichTextBoxTemp.Text.Contains("manufacturing login: root") Then
                SerialPort1.WriteLine("OGtest1")


                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Done", Color.LightGreen)

            End If

            'Delay(0.3)

            '7[r[999;999H[6n8re --update

            'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")

            If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409259" Then

                Delay(5)
                SerialPort1.Write("" & vbCr)

                Delay(0.3)
                RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")



                SerialPort1.WriteLine("rwfirmware --update") 'update firmware
                Delay(15)



                If RichTextBoxTemp.Text.Contains("root@manufacturing:") Then

                    RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:"), "XXXXXX")
                    add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "DUT Reboot")
                    SerialPort1.WriteLine("reboot")
                    'ElseIf RichTextBoxTemp.Text.Contains("root@manufacturing:") = False Then
                    'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:"), "XXXXXX")

                    'Else
                    'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL, no response", Color.Orange)
                    'statusfinaltest_result = "FAIL"
                    'save_log()
                    'Exit Sub
                End If





                'SerialPort1.WriteLine("")

                Delay(5)
                SerialPort1.Write("" & vbCr)

                Delay(0.3)
                RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
                'Timer2.Enabled() = True
                'Timer2.Start()

                Delay(60)


                If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
                    row_grid_Done(DataGridView1.RowCount)
                    SerialPort1.WriteLine("root")
                    RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")

                    Delay(1)
                    'If RichTextBoxTemp.Text.Contains("manufacturing login: root") Then
                    SerialPort1.WriteLine("OGtest1")

                    'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Password"), "XXXXXX")
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Done", Color.LightGreen)
                ElseIf RichTextBoxTemp.Text.Contains("Opengear Manufacturing") = False Then
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Fail", Color.Orange)
                    'GoTo failure259
                    statusfinaltest_result = "FAIL"
                    save_log()
                    DUTDisconnect()
                    Exit Sub
                End If
            End If



            Delay(5)
            SerialPort1.Write("" & vbCr)

            Delay(0.3)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
            'Delay(1)
            'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")



            Delay(6)
            SerialPort1.WriteLine(MAC1) 'write MAC1
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Write MAC #1", "Done", Color.LightGreen)
            write_MAC1 = "PASS"

            Delay(6)
            SerialPort1.WriteLine(MAC2) 'write MAC2
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Write MAC #2", "Done", Color.LightGreen)
            write_MAC2 = "PASS"



            If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409259" Then
                Delay(6)
                SerialPort1.WriteLine(MACsw0) 'write MAC sw0
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Write MAC sw0", "Done", Color.LightGreen)
                write_MACsw0 = "PASS"
            End If

            Delay(5)
            SerialPort1.WriteLine("reboot")
            RichTextBoxTemp.Clear()
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "DUT Reboot")

            If RichTextBoxTemp.Text.Contains("root@manufacturing:~# reboot") Then
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:~# reboot"), "XXXXXX")
                write_all_mac = "PASS"
            End If




            Delay(60)
            If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
                reboot_DUT = "PASS"
                RichTextBoxTemp.Clear()
                row_grid_Done(DataGridView1.RowCount)
                SerialPort1.WriteLine("root")
                Delay(2)
                SerialPort1.WriteLine("OGtest1")
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Done", Color.LightGreen)
                login_status = "PASS"
            ElseIf RichTextBoxTemp.Text.Contains("Opengear Manufacturing") = False Then
                row_grid_FAIL(DataGridView1.RowCount)
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL, no booting response", Color.Orange)
                'GoTo failure259

                statusfinaltest_result = "FAIL"
                save_log()
                DUTDisconnect()
                Exit Sub
            End If

            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("manufacturing login"), "XXXXXX")


            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Password"), "XXXXXX")

            'Delay(5)
            'SerialPort1.Write("" & vbCr)
            'Delay(1)

            Delay(5)
            SerialPort1.Write("" & vbCr)

            Delay(0.3)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
            'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
            Delay(2)


            If RichTextBoxTemp.Text.Contains("root@manufacturing:") Then
                RichTextBoxTemp.Clear()
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:"), "XXXXXX")

                'ElseIf RichTextBoxTemp.Text.Contains("root@manufacturing:~#") = False Then
                '   add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL, no response", Color.Orange)
                'GoTo failure259

                'statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If
            'SerialPort1.WriteLine("")

            Delay(0.3)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")



            Delay(3)
            SerialPort1.WriteLine("rwmac net1") 'verify MAC1
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC1", "Done", Color.LightGreen)
            verify_MAC1 = "PASS"

            Delay(3)
            SerialPort1.WriteLine("rwmac net2") 'verify MAC2
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC2", "Done", Color.LightGreen)
            verify_MAC2 = "PASS"


            If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409259" Then
                Delay(3)
                SerialPort1.WriteLine("rwmac sw0") 'verify MACsw0
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC sw0", "Done", Color.LightGreen)
                verify_MACsw0 = "PASS"
            End If

            Delay(3)
            SerialPort1.WriteLine("loopback")
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "Loopback")


            If RichTextBoxTemp.Text.Contains("root@manufacturing:~# loopback") Then
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:~# loopback"), "XXXXXX")
                verify_all_mac = "PASS"
            End If

            Delay(12)
            'SendKeys.SendWait("^C")
            'SendKeys.Send("^C")
            'SendKeys.Send("^c")
            'SendKeys.Send("^C")
            'SerialPort1.Write("^C" & vbCr)
            SerialPort1.Write(New Byte() {3}, 0, 1) 'Ctrl+C ok
            'SerialPort1.Write(New Byte() {4}, 0, 1) 'Ctrl+D
            'SerialPort1.Write("u" & vbCr) 'u
            'InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C)
            'SerialPort1.WriteLine("^C")

            If ComboBoxModel.Text = "OPG-409225" Then
                If RichTextBoxTemp.Text.Contains("LLLLLLLL LL  LLLL") Then
                    loopback = "PASS"
                    row_grid_PASS(DataGridView1.RowCount)

                    'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
                    'add_row_grid_RESULT(DataGridView1.RowCount + 1, "Loopback", "PASS", Color.LightGreen)
                ElseIf RichTextBoxTemp.Text.Contains("LLLLLLLL LL  LLLL") = False Then
                    row_grid_FAIL(DataGridView1.RowCount)
                    add_row_grid_RESULT(DataGridView1.RowCount + 1, "FCT", "FAIL, Loopback", Color.IndianRed)
                    'GoTo failure259

                    loopback = "FAIL"
                    statusfinaltest_result = "FAIL"

                    'save_log()
                    'Exit Sub
                End If
            End If


            If ComboBoxModel.Text = "OPG-409259" Then
                If RichTextBoxTemp.Text.Contains("LLLL---- LL  LLLL") Then
                    loopback = "PASS"
                    row_grid_PASS(DataGridView1.RowCount)

                    'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
                    'add_row_grid_RESULT(DataGridView1.RowCount + 1, "Loopback", "PASS", Color.LightGreen)
                ElseIf RichTextBoxTemp.Text.Contains("LLLL---- LL  LLLL") = False Then
                    row_grid_FAIL(DataGridView1.RowCount)
                    add_row_grid_RESULT(DataGridView1.RowCount + 1, "FCT", "FAIL, Loopback", Color.IndianRed)
                    'GoTo failure259

                    loopback = "FAIL"
                    statusfinaltest_result = "FAIL"

                    'save_log()
                    'Exit Sub
                End If
            End If


            If ComboBoxModel.Text = "OPG-409260" Then
                If RichTextBoxTemp.Text.Contains("LLLLLLLL LL") Then
                    loopback = "PASS"
                    row_grid_PASS(DataGridView1.RowCount)

                    'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
                    'add_row_grid_RESULT(DataGridView1.RowCount + 1, "Loopback", "PASS", Color.LightGreen)
                ElseIf RichTextBoxTemp.Text.Contains("LLLLLLLL LL") = False Then
                    row_grid_FAIL(DataGridView1.RowCount)
                    add_row_grid_RESULT(DataGridView1.RowCount + 1, "FCT", "FAIL, Loopback", Color.IndianRed)
                    'GoTo failure259

                    loopback = "FAIL"
                    statusfinaltest_result = "FAIL"

                    'save_log()
                    'Exit Sub
                End If
            End If

            If ComboBoxModel.Text = "OPG-409258" Then
                If RichTextBoxTemp.Text.Contains("LLLL---- LL") Then
                    loopback = "PASS"
                    row_grid_PASS(DataGridView1.RowCount)

                    'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
                    'add_row_grid_RESULT(DataGridView1.RowCount + 1, "Loopback", "PASS", Color.LightGreen)
                ElseIf RichTextBoxTemp.Text.Contains("LLLL---- LL") = False Then
                    row_grid_FAIL(DataGridView1.RowCount)
                    add_row_grid_RESULT(DataGridView1.RowCount + 1, "FCT", "FAIL, Loopback", Color.IndianRed)
                    'GoTo failure259

                    loopback = "FAIL"
                    statusfinaltest_result = "FAIL"

                    'save_log()
                    'Exit Sub
                End If
            End If




            Delay(2)

            'SerialPort1.DiscardOutBuffer()
            'SerialPort1.DiscardInBuffer()

            SerialPort1.WriteLine("selftest-local --exclude slow")
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "Self Test")

            Delay(40)

            'SerialPort1.DiscardOutBuffer()
            'SerialPort1.DiscardInBuffer()




            'Delay(2)

            If RichTextBoxTemp.Text.Contains("selftest                                                              | [32mPASS[0m |") Then

                row_grid_PASS(DataGridView1.RowCount)
                self_test = "PASS"
                add_row_grid_INPROGRESS_WAIT(DataGridView1.RowCount + 1)
                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Selftest", "PASS", Color.LightGreen)
            ElseIf RichTextBoxTemp.Text.Contains("selftest                                                              | [31mFAIL[0m |") Then

                row_grid_FAIL(DataGridView1.RowCount)
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.IndianRed)
                add_row_grid_INPROGRESS_WAIT(DataGridView1.RowCount + 1)



                '[31mF[0m[32m.[0m[32m.[0m[32m.[0m
                '| [31mFAIL[0m |
                replace_symbol()

                TestingtimeEnd = DateTime.Now
                Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
                'ResultTextBoxFCT.BackColor = Color.IndianRed
                'ResultTextBoxFCT.Text = "FAIL"
                self_test = "FAIL"
                statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If

            replace_symbol()
            '----------------------------------------------------------------
            Delay(10)
            If RichTextBoxTemp.Text.Contains("root@manufacturing:") Then
                row_grid_REMOVE_WAIT(DataGridView1.RowCount)
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:"), "XXXXXX")
                add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "LED SEQUENCE")
                SerialPort1.WriteLine("leds-sequence")
                RichTextBoxTemp.Clear()

                'Dim intRespons1 As Integer
                Using form = New Form() With {.TopMost = True}
                    intResponse1 = MessageBox.Show(form, "Apakah LED SEQUENCE sudah benar?", "LED SEQUENCE", vbYesNo)
                End Using
                If intResponse1 = vbYes Then
                    LED_sequence = "PASS"
                    row_grid_PASS_LED(DataGridView1.RowCount)

                End If

                If intResponse1 = vbNo Then
                    LED_sequence = "FAIL"
                    row_grid_FAIL(DataGridView1.RowCount)
                    'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.IndianRed)

                    statusfinaltest_result = "FAIL"
                    'save_log()
                    'Exit Sub
                End If

                'row_grid_PASS(DataGridView1.RowCount)

                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Selftest", "PASS", Color.LightGreen)


                'ElseIf RichTextBoxTemp.Text.Contains("root@manufacturing:") = False Then
                'row_grid_FAIL(DataGridView1.RowCount)
                '   add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.Orange)

                'TestingtimeEnd = DateTime.Now
                'Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
                ' ResultTextBoxFCT.BackColor = Color.IndianRed
                'ResultTextBoxFCT.Text = "FAIL"
                'statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If
            TestingtimeEnd = DateTime.Now
            Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
            Start_BT.Enabled = True
            StopBT.Enabled = True
            Start_BT.BackColor = Color.Orange

            If ComboBoxModel.Text = "OPG-409225" Or ComboBoxModel.Text = "OPG-409259" Then
                If self_test = "PASS" And LED_sequence = "PASS" And loopback = "PASS" And reboot_DUT = "PASS" And login_status = "PASS" And
                 write_MAC1 = "PASS" And write_MAC2 = "PASS" And write_MAC3 = "PASS" And
                verify_MAC1 = "PASS" And verify_MAC2 = "PASS" And verify_MAC3 = "PASS" Then
                    ResultTextBoxFCT.Text = "PASS"
                    ResultTextBoxFCT.BackColor = Color.LightGreen
                    statusfinaltest_result = ResultTextBoxFCT.Text
                    add_row_grid_RESULT_BOLD(DataGridView1.RowCount + 1, "Overall FCT", "PASS", Color.LightGreen)
                Else
                    ResultTextBoxFCT.Text = "FAIL"
                    ResultTextBoxFCT.BackColor = Color.IndianRed
                    statusfinaltest_result = ResultTextBoxFCT.Text
                    add_row_grid_RESULT_BOLD(DataGridView1.RowCount + 1, "Overall FCT", "FAIL", Color.IndianRed)
                End If
            End If


            If ComboBoxModel.Text = "OPG-409258" Or ComboBoxModel.Text = "OPG-409260" Then
                If self_test = "PASS" And LED_sequence = "PASS" And loopback = "PASS" And reboot_DUT = "PASS" And
                login_status = "PASS" And write_MAC1 = "PASS" And write_MAC2 = "PASS" And
                                         verify_MAC1 = "PASS" And verify_MAC2 = "PASS" Then
                    ResultTextBoxFCT.Text = "PASS"
                    ResultTextBoxFCT.BackColor = Color.LightGreen
                    statusfinaltest_result = ResultTextBoxFCT.Text
                    add_row_grid_RESULT_BOLD(DataGridView1.RowCount + 1, "Overall FCT", "PASS", Color.LightGreen)
                Else
                    ResultTextBoxFCT.Text = "FAIL"
                    ResultTextBoxFCT.BackColor = Color.IndianRed
                    statusfinaltest_result = ResultTextBoxFCT.Text
                    add_row_grid_RESULT_BOLD(DataGridView1.RowCount + 1, "Overall FCT", "FAIL", Color.IndianRed)
                End If
            End If



            get_power_current()

            save_log_ORI()
            save_log()
            save_log_RAW()

            parsing_summary()

            save_log_summary()


            DUTDisconnect()

            MsgBox("TESTING SELESAI." & vbNewLine & vbNewLine & "RESULT FCT: " & statusfinaltest_result & vbNewLine & vbNewLine _
                   & "Silahkan cabut power supply dan pasang DUT baru")


            RichTextBoxTemp.Clear()
            RichTextBox2.Clear()
            RichTextBox3.Clear()

        End If
    End Sub

    Private Sub collect_data_218()
        If IMEITextBox1.Text.Length <> 17 Then
            'TextBoxScan.Text = ""
            Do Until IMEITextBox1.Text.Length = 17
                IMEITextBox1.Text = ""
                'SerialNumTextBox.Text = InputBox("Scan Serial Number ID (9 digit)", "TESTING #1 :", "SE33975449", 500, 450)  'input box
                IMEITextBox1.Text = InputBox("Scan MAC #1 (12 digit)", "", "", 500, 450)  'input box
                'If e.KeyCode = Keys.Enter Then


                'End If
                If IMEITextBox1.Text = "" Then
                    'stop_process()
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #1 Scan", "CANCEL", Color.Orange)
                    testing_batal = "YES"
                    Exit Sub
                End If
            Loop
        End If

        IMEITextBox1.Text = Replace(IMEITextBox1.Text, ":", "")



        If SerialTextBox.Text.Length <> 10 Then
            Do Until SerialTextBox.Text.Length = 10
                SerialTextBox.Text = ""
                'SerialNumTextBox.Text = InputBox("Scan Serial Number ID (10 digit)", "TESTING #1 :", "SE33975449", 500, 450)  'input box
                SerialTextBox.Text = InputBox("Scan Serial (10 digit)", "", "", 500, 450)  'input box
                If SerialTextBox.Text = "" Then
                    'stop_process()
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Serial Scan", "CANCEL", Color.Orange)
                    testing_batal = "YES"
                    Exit Sub
                End If
            Loop
        End If

        'SerialNumTextBox.Text = "NA"

        'RWObyOperator = ComboBoxRWO_Id.Text
        '-------------------------cek RWO from MAC-----------------------
        '9680500059 = KGB OPG-218
        If SerialTextBox.Text <> "9680500059" Then 'And MACTextBox1.Text <> "0013C60C7D6E" Then

            If CheckBoxRWO.Checked = False Then
                Try
                    RWO_CEK()
                Catch ex As Exception

                    reset_datagrid()
                    reset_value()
                    testing_batal = "YES"
                    'Disconnect()
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "RWO Aegis Server", "FAIL", Color.IndianRed)
                    MsgBox("check again RWO from AEGIS server..." & vbNewLine & vbNewLine &
                   "" & ex.Message, 262144)
                    Delay(2)
                    Exit Sub
                End Try
            End If
        End If
        'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls 'Tls12
        'Dim json As String = New System.Net.WebClient().DownloadString("http://10.206.110.46/production/production.asmx/searchwip?serialnumber=" & SerialTextBox.Text)

        'https://www.newtonsoft.com/json/help/html/SelectToken.htm
        'Dim parsejson As JObject = JObject.Parse(json)
        'Dim theRWO = parsejson.SelectToken("wip[0].RWO").ToString() 'arti [] untuk memilih RWO di atasnya atau bawahnya tp masih di dalam wip


        'ComboBoxRWO_Id.Text = theRWO

        'If ComboBoxRWO_Id.Text = "" Then
        'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "RWO ID", "NO DATA, check RWO Aegis, or manual input", Color.Orange)
        'testing_batal = "YES"
        'MessageBox.Show("Please check RWO Aegis, or manual input", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'ComboBoxRWO_Id.Select()
        'Exit Sub
        'End If


        'Dim thePackingNum '= parsejson.SelectToken("wip[0].ASSEMBLYNAME").ToString() 'arti [] untuk memilih RWO di atasnya atau bawahnya tp masih di dalam wip

        '----------------------------------------------------------------



        Dim hexString As String = Nothing

        'hexString = TextBoxScan.Text.Trim
        hexString = Trim(Mid(IMEITextBox1.Text, 6, 20))
        'MsgBox(hexString)
        'hexString = Trim(MACTextBox.Text)
        'MsgBox(hexString)

        'convert into decimal
        Dim decValue As Integer = 0
        decValue = CInt("&H" & hexString) 'hanya untuk digit kecil

        'MAC1 = "rwmac net1 --mac " & MACTextBox1.Text & " --init" '& vbNewLine & vbNewLine
        'MAC2 = "rwmac net2 --mac 0013C6" & Hex(decValue + 1) & " --init" '& vbNewLine & vbNewLine
        'MAC3 = "rwmac net3 --mac 0013C6" & Hex(decValue + 2) & " --init" '& vbNewLine & vbNewLine
        'MAC4 = "rwmac net4 --mac 0013C6" & Hex(decValue + 3) & " --init" '& vbNewLine & vbNewLine

        MACTextBox2.Text = "0013C" & Hex(decValue + 1)
        MACTextBox3.Text = "0013C" & Hex(decValue + 2)
        MACTextBox4.Text = "0013C" & Hex(decValue + 3)

        If SerialTextBox.Text <> "9680500059" Then 'And MACTextBox1.Text <> "0013C60C7D6E" Then
            '9680500059 = KGB OPG-218
            Try
                'CekMACDB = GetMac(SerialTextBox.Text)  'get from dll/database kirno

                CekMAC = CekMACDB.Split(",")
                GetMAC1 = CekMAC(0)
                GetMAC2 = CekMAC(1)
                GETMAC3 = CekMAC(2)
                GETMAC4 = CekMAC(3)
            Catch ex As Exception
                MsgBox(ex.Message & vbNewLine & "Or serial number not valid")
            End Try



            GetMAC1_new = Replace(GetMAC1, ":", "")
            GetMAC2_new = Replace(GetMAC2, ":", "")
            GetMAC3_new = Replace(GETMAC3, ":", "")
            GetMAC4_new = Replace(GETMAC4, ":", "")


            If IMEITextBox1.Text = GetMAC1_new Then
                IMEITextBox1.Text = GetMAC1_new
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #1", "MATCH : " & GetMAC1, Color.LightGreen)
            Else
                'MsgBox("Testing CANCEL MAC #1 not match")
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #1", "NOT MATCH", Color.Orange)
                Exit Sub
            End If

            If MACTextBox2.Text = GetMAC2_new Then
                MACTextBox2.Text = GetMAC2_new
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #2", "MATCH : " & GetMAC2, Color.LightGreen)
            Else
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #2", "NOT MATCH", Color.Orange)
                'MsgBox("Testing CANCEL MAC #2 not match")
                Exit Sub
            End If

            If MACTextBox3.Text = GetMAC3_new Then
                MACTextBox3.Text = GetMAC3_new
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #3", "MATCH : " & GETMAC3, Color.LightGreen)
            Else
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #3", "NOT MATCH", Color.Orange)
                'MsgBox("Testing CANCEL MAC sw0 not match")
                Exit Sub
            End If

            If MACTextBox4.Text = GetMAC4_new Then
                MACTextBox4.Text = GetMAC4_new
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #4", "MATCH : " & GETMAC4, Color.LightGreen)
            Else
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #4", "NOT MATCH", Color.Orange)
                'MsgBox("Testing CANCEL MAC sw0 not match")
                Exit Sub
            End If

        End If


        MAC1 = "rwmac net1 --mac " & IMEITextBox1.Text & " --init" '& vbNewLine & vbNewLine
        MAC2 = "rwmac net2 --mac " & MACTextBox2.Text & " --init" '& vbNewLine & vbNewLine
        MAC3 = "rwmac net3 --mac " & MACTextBox3.Text & " --init" '& vbNewLine & vbNewLine
        MAC4 = "rwmac net4 --mac " & MACTextBox4.Text & " --init" '& vbNewLine & vbNewLine



        'PasswordTextBox.Text = "NA"

        TestingtimeStart1.Text = Format(Now, "HH:mm:ss") ' HH=jam 00-23, hh=AM atau PM
        TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeStart = Format(Now, "HH:mm:ss")
        Date_testDate.Text = Format(Now, "dd-MMM-yyyy") 'samakan format ini dengan csv/excel
        'RichTextBox1.("\r\nOperator and Badge ID harus diisi\r\n", False)

        'SerialPort1.WriteLine(" ")

        'Delay(4)

        'SerialPortPS.Write("OUT0" & vbCr)
        'Delay(3)
        'wait(2000)
        'SerialPortPS.Write("OUT1" & vbCr)
        'wait(4000)

        'SerialPortPS.Write("VSET1:" & ComboBoxVoltTest.Text & vbCr)


        'SerialPortPS.Write("VSET1:12.00" & vbCr)
        'SerialPortPS.Write("ISET1:1.000" & vbCr)
        MsgBox("Pasang POWER ON ke DUT sekarang")

        add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "DUT Autoboot")

        TimerDetect218.Start()
        TimerDetect218.Enabled = True

    End Sub

    Private Sub TimerDetect218_Tick(sender As Object, e As EventArgs) Handles TimerDetect218.Tick
        If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
            row_grid_Done(DataGridView1.RowCount)

            TimerDetect218.Stop()
            TimerDetect218.Enabled = False


            If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
                SerialPort1.WriteLine("root")
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")

                Delay(1)
                'If RichTextBoxTemp.Text.Contains("manufacturing login: root") Then
                SerialPort1.WriteLine("OGtest1")
                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Password"), "XXXXXX")
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Done", Color.LightGreen)
                'ElseIf RichTextBoxTemp.Text.Contains("Opengear Manufacturing") = False Then
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Fail", Color.Orange)
                'statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If



            Delay(5)
            SerialPort1.Write("" & vbCr)
            Delay(1)
            If RichTextBoxTemp.Text.Contains("root@manufacturing:") = False Then
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:"), "XXXXXX")
                'Else
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL, no response after login", Color.Orange)
                statusfinaltest_result = "FAIL"
                save_log()
                Exit Sub
            End If

            'SerialPort1.WriteLine("")

            Delay(0.5)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
            'Timer2.Enabled() = True
            'Timer2.Start()

            Delay(6)
            SerialPort1.WriteLine(MAC1)
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Write MAC #1", "Done", Color.LightGreen)

            Delay(6)
            SerialPort1.WriteLine(MAC2)
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Write MAC #2", "Done", Color.LightGreen)

            Delay(6)
            SerialPort1.WriteLine(MAC3)
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Write MAC #3", "Done", Color.LightGreen)

            Delay(6)
            SerialPort1.WriteLine(MAC4)
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Write MAC #4", "Done", Color.LightGreen)

            Delay(6)
            SerialPort1.WriteLine("reboot")
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "DUT Reboot")

            If RichTextBoxTemp.Text.Contains("root@manufacturing:~# reboot") Then
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:~# reboot"), "XXXXXX")
                write_all_mac = "PASS"
            End If


            '7[r[999;999H[6nroot@manufacturing:~# 
            'Delay(15)

            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing"), "XXXXXX")


            'Timer2.Enabled() = False

            'Delay(40)
            'ReceivedDataTimer.Enabled() = True
            'ReceivedDataTimer.Start()

            'ProgressBarTimerFCT.Enabled() = True
            'ProgressBarTimerFCT.Start()


            'RichTextBox1.Clear()


            Delay(100)
            If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
                RichTextBoxTemp.Clear()
                row_grid_Done(DataGridView1.RowCount)
                SerialPort1.WriteLine("root")
                Delay(2)
                SerialPort1.WriteLine("OGtest1")
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Re-Login", "Done", Color.LightGreen)
            ElseIf RichTextBoxTemp.Text.Contains("Opengear Manufacturing") = False Then
                row_grid_FAIL(DataGridView1.RowCount)
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL, no booting response", Color.Orange)
                statusfinaltest_result = "FAIL"
                save_log()
                DUTDisconnect()
                Exit Sub


            End If

            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("manufacturing login"), "XXXXXX")


            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Password"), "XXXXXX")

            Delay(5)
            SerialPort1.Write("" & vbCr)
            Delay(1)
            If RichTextBoxTemp.Text.Contains("root@manufacturing:~#") Then
                RichTextBoxTemp.Clear()
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:~#"), "XXXXXX")

            ElseIf RichTextBoxTemp.Text.Contains("root@manufacturing:~#") = False Then
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL, no response after login", Color.Orange)
                statusfinaltest_result = "FAIL"
                save_log()
                DUTDisconnect()
                Exit Sub
            End If
            'SerialPort1.WriteLine("")

            Delay(0.3)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
            '7[r[999;999H[6n


            Delay(5)
            SerialPort1.WriteLine("rwmac net1")
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC1", "Done", Color.LightGreen)

            Delay(5)
            SerialPort1.WriteLine("rwmac net2")
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC2", "Done", Color.LightGreen)

            Delay(5)
            SerialPort1.WriteLine("rwmac net3")
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC3", "Done", Color.LightGreen)

            Delay(5)
            SerialPort1.WriteLine("rwmac net4")
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC4", "Done", Color.LightGreen)

            Delay(5)
            SerialPort1.WriteLine("loopback")
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "Loopback")

            If RichTextBoxTemp.Text.Contains("root@manufacturing:~# loopback") Then
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:~# loopback"), "XXXXXX")
                verify_all_mac = "PASS"
            End If


            Delay(12)
            'SendKeys.SendWait("^C")
            'SendKeys.Send("^C")
            'SendKeys.Send("^c")
            'SendKeys.Send("^C")
            'SerialPort1.Write("^C" & vbCr)
            SerialPort1.Write(New Byte() {3}, 0, 1) 'Ctrl+C ok
            'SerialPort1.Write(New Byte() {4}, 0, 1) 'Ctrl+D
            'SerialPort1.Write("u" & vbCr) 'u
            'InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C)
            'SerialPort1.WriteLine("^C")
            If RichTextBoxTemp.Text.Contains("-- LLLL") Then
                row_grid_PASS(DataGridView1.RowCount)

                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")
                'add_row_grid_RESULT(DataGridView1.RowCount + 1, "Loopback", "PASS", Color.LightGreen)


            ElseIf RichTextBoxTemp.Text.Contains("-- LLLL") = False Then
                row_grid_FAIL(DataGridView1.RowCount)
                'add_row_grid_RESULT(DataGridView1.RowCount + 1, "FCT", "FAIL, Loopback", Color.IndianRed)

                statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If



            Delay(2)
            SerialPort1.WriteLine("selftest-local --exclude slow")
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "Self Test")


            Delay(15)


            If RichTextBoxTemp.Text.Contains("selftest                                                              | [32mPASS[0m |") Then
                row_grid_PASS(DataGridView1.RowCount)
                self_test = "PASS"
                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Selftest", "PASS", Color.LightGreen)
            ElseIf RichTextBoxTemp.Text.Contains("selftest                                                              | [32mFAIL[0m |") Then
                row_grid_FAIL(DataGridView1.RowCount)
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.IndianRed)

                statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If

            'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[32m"), "")
            'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[0m"), "")
            'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape(""), "")
            replace_symbol()

            '----------------------------------------------------------------
            Delay(3)
            If RichTextBoxTemp.Text.Contains("root@manufacturing:~#") Then
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:~#"), "XXXXXX")
                add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "GREEN LED ON")
                SerialPort1.WriteLine("leds on green")


                'Dim intRespons1 As Integer
                Using form = New Form() With {.TopMost = True}
                    intResponse1 = MessageBox.Show(form, "Apakah LED MENYALA HIJAU?", "LED GREEN", vbYesNo)
                End Using
                If intResponse1 = vbYes Then
                    GreenLED_on = "PASS"
                    row_grid_PASS_LED(DataGridView1.RowCount)

                End If

                If intResponse1 = vbNo Then
                    GreenLED_on = "FAIL"
                    row_grid_FAIL(DataGridView1.RowCount)
                    'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.IndianRed)

                    statusfinaltest_result = "FAIL"
                    'save_log()
                    'Exit Sub
                End If

                'row_grid_PASS(DataGridView1.RowCount)

                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Selftest", "PASS", Color.LightGreen)
            ElseIf RichTextBoxTemp.Text.Contains("root@manufacturing:~#") = False Then
                row_grid_FAIL(DataGridView1.RowCount)
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.Orange)

                statusfinaltest_result = "FAIL"
                save_log()
                DUTDisconnect()
                Exit Sub
            End If

            '---------------------------------------------------------------------

            Delay(5)
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "ORANGE LED ON")
            SerialPort1.WriteLine("leds on orange")
            Using form = New Form() With {.TopMost = True}
                intResponse2 = MessageBox.Show(form, "Apakah LED MENYALA ORANGE?", "LED ORANGE", vbYesNo)
            End Using
            If intResponse2 = vbYes Then
                OrangeLED_on = "PASS"
                row_grid_PASS_LED(DataGridView1.RowCount)

            End If

            If intResponse2 = vbNo Then
                OrangeLED_on = "FAIL"
                row_grid_FAIL(DataGridView1.RowCount)
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.IndianRed)

                statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If


            '---------------------------------------------------------------------

            Delay(5)
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "ALL LED OFF")
            SerialPort1.WriteLine("leds off")
            Using form = New Form() With {.TopMost = True}
                intResponse3 = MessageBox.Show(form, "Apakah LED MATI semua?", "LED OFF", vbYesNo)
            End Using
            If intResponse3 = vbYes Then
                offLED = "PASS"
                row_grid_PASS_LED(DataGridView1.RowCount)

            End If

            If intResponse3 = vbNo Then
                offLED = "FAIL"
                row_grid_FAIL(DataGridView1.RowCount)
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.IndianRed)
                statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If


            '[32m
            '[0m




            TestingtimeEnd = DateTime.Now
            Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")

            Start_BT.Enabled = True
            StopBT.Enabled = True
            Start_BT.BackColor = Color.Orange





            'IMAGE_File_Data = "NA"

            If self_test = "PASS" And GreenLED_on = "PASS" And OrangeLED_on = "PASS" And offLED = "PASS" Then
                ResultTextBoxFCT.Text = "PASS"
                ResultTextBoxFCT.BackColor = Color.LightGreen
                statusfinaltest_result = ResultTextBoxFCT.Text
                add_row_grid_RESULT_BOLD(DataGridView1.RowCount + 1, "Overall FCT", "PASS", Color.LightGreen)
            Else
                ResultTextBoxFCT.Text = "FAIL"
                ResultTextBoxFCT.BackColor = Color.IndianRed
                statusfinaltest_result = ResultTextBoxFCT.Text
                add_row_grid_RESULT_BOLD(DataGridView1.RowCount + 1, "Overall FCT", "FAIL", Color.IndianRed)
            End If



            get_power_current()

            save_log_ORI()
            save_log()

            save_log_RAW()

            parsing_summary()
            save_log_summary()

            DUTDisconnect()

            MsgBox("TESTING SELESAI." & vbNewLine & vbNewLine & "RESULT FCT: " & statusfinaltest_result & vbNewLine & vbNewLine _
                   & "Silahkan cabut power supply dan pasang DUT baru")

            'SerialPortPS.Write("OUT0" & vbCr)
            'RichTextBox1.Clear()

            RichTextBoxTemp.Clear()
            RichTextBox2.Clear()
            RichTextBox3.Clear()

        End If




    End Sub



    Private Sub collect_data_225()  'nga dipakai
        If IMEITextBox1.Text.Length <> 17 Then
            'TextBoxScan.Text = ""
            Do Until IMEITextBox1.Text.Length = 17
                IMEITextBox1.Text = ""
                'SerialNumTextBox.Text = InputBox("Scan Serial Number ID (9 digit)", "TESTING #1 :", "SE33975449", 500, 450)  'input box
                IMEITextBox1.Text = InputBox("Scan MAC #1 (12 digit)", "", "", 500, 450)  'input box
                'If e.KeyCode = Keys.Enter Then


                'End If
                If IMEITextBox1.Text = "" Then
                    'stop_process()
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #1 Scan", "CANCEL", Color.Orange)
                    testing_batal = "YES"
                    Exit Sub
                End If
            Loop
        End If

        IMEITextBox1.Text = Replace(IMEITextBox1.Text, ":", "")



        If SerialTextBox.Text.Length <> 28 Then
            Do Until SerialTextBox.Text.Length = 28
                SerialTextBox.Text = ""
                'SerialNumTextBox.Text = InputBox("Scan Serial Number ID (10 digit)", "TESTING #1 :", "SE33975449", 500, 450)  'input box
                SerialTextBox.Text = InputBox("Scan Serial (28 digit)", "", "", 500, 450)  'input box
                If SerialTextBox.Text = "" Then
                    'stop_process()
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Serial Scan", "CANCEL", Color.Orange)
                    testing_batal = "YES"
                    Exit Sub
                End If
            Loop
        End If




        If CheckBox1.Checked = False Then
            Try
                RWO_CEK()
            Catch ex As Exception

                reset_datagrid()
                reset_value()
                testing_batal = "YES"
                'Disconnect()
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "RWO Aegis Server", "FAIL", Color.IndianRed)
                MsgBox("check again RWO from AEGIS server..." & vbNewLine & vbNewLine &
                   "" & ex.Message, 262144)
                Delay(2)
                Exit Sub
            End Try
        End If

        '----------------------------------------------------------------



        Dim hexString As String = Nothing

        'hexString = TextBoxScan.Text.Trim
        hexString = Trim(Mid(IMEITextBox1.Text, 6, 20))
        'MsgBox(hexString)
        'hexString = Trim(MACTextBox.Text)
        'MsgBox(hexString)

        'convert into decimal
        Dim decValue As Integer = 0
        decValue = CInt("&H" & hexString) 'hanya untuk digit kecil



        MACTextBox2.Text = "0013C" & Hex(decValue + 1)
        MACsw0TextBox.Text = "0013C" & Hex(decValue + 2)


        'get_mac_dll_225()

        Try
            'CekMACDB = GetMac(SerialTextBox.Text)

            CekMAC = CekMACDB.Split(",")
            GetMAC1 = CekMAC(0)
            GetMAC2 = CekMAC(1)
            GETMAC3 = CekMAC(2)
        Catch ex As Exception
            MsgBox(ex.Message & vbNewLine & "Or serial number not valid")
        End Try



        GetMAC1_new = Replace(GetMAC1, ":", "")
        GetMAC2_new = Replace(GetMAC2, ":", "")
        GetMAC3_new = Replace(GETMAC3, ":", "")


        If IMEITextBox1.Text = GetMAC1_new Then
            IMEITextBox1.Text = GetMAC1_new
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #1", "MATCH : " & GetMAC1, Color.LightGreen)
        Else
            'MsgBox("Testing CANCEL MAC #1 not match")
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #1", "NOT MATCH : " & GetMAC1, Color.Orange)
            Exit Sub
        End If

        If MACTextBox2.Text = GetMAC2_new Then
            MACTextBox2.Text = GetMAC2_new
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #2", "MATCH : " & GetMAC2, Color.LightGreen)
        Else
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #2", "NOT MATCH : " & GetMAC2, Color.Orange)
            'MsgBox("Testing CANCEL MAC #2 not match")
            Exit Sub
        End If

        If MACsw0TextBox.Text = GetMAC3_new Then
            MACsw0TextBox.Text = GetMAC3_new
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC sw0", "MATCH : " & GETMAC3, Color.LightGreen)
        Else
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC sw0", "NOT MATCH : " & GETMAC3, Color.Orange)
            'MsgBox("Testing CANCEL MAC sw0 not match")
            Exit Sub
        End If


        MAC1 = "rwmac net1 --mac " & IMEITextBox1.Text & " --init" '& vbNewLine & vbNewLine
        MAC2 = "rwmac net2 --mac " & MACTextBox2.Text & " --init" '& vbNewLine & vbNewLine
        MACsw0 = "rwmac sw0 --mac " & MACsw0TextBox.Text & " --init" '& vbNewLine & vbNewLine



        'PasswordTextBox.Text = "NA"

        TestingtimeStart1.Text = Format(Now, "HH:mm:ss") ' HH=jam 00-23, hh=AM atau PM
        TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeStart = Format(Now, "HH:mm:ss")
        Date_testDate.Text = Format(Now, "dd-MMM-yyyy") 'samakan format ini dengan csv/excel

        MsgBox("Pasang power on ke DUT sekarang")
        add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "DUT Autoboot")

        TimerDetect225.Start()
        TimerDetect225.Enabled = True

    End Sub


    Private Sub TimerDetect225_Tick(sender As Object, e As EventArgs) Handles TimerDetect225.Tick  'nga dipakai
        If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
            row_grid_Done(DataGridView1.RowCount)
            TimerDetect225.Stop()
            TimerDetect225.Enabled = False


            If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
                SerialPort1.WriteLine("root")
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")

                Delay(1)
                'If RichTextBoxTemp.Text.Contains("manufacturing login: root") Then
                SerialPort1.WriteLine("OGtest1")

                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Password"), "XXXXXX")
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Done", Color.LightGreen)
            ElseIf RichTextBoxTemp.Text.Contains("Opengear Manufacturing") = False Then
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Fail", Color.Orange)
                'GoTo failure225
                statusfinaltest_result = "FAIL"
                save_log()
                Exit Sub
            End If

            'Delay(0.3)

            '7[r[999;999H[6n8re --update

            'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")



            Delay(5)
            SerialPort1.Write("" & vbCr)

            Delay(0.3)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")


            SerialPort1.WriteLine("rwfirmware --update") 'update firmware
            Delay(15)



            If RichTextBoxTemp.Text.Contains("root@manufacturing:") Then

                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:"), "XXXXXX")
                add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "DUT Reboot")
                SerialPort1.WriteLine("reboot")
                'ElseIf RichTextBoxTemp.Text.Contains("root@manufacturing:") = False Then
                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:"), "XXXXXX")

                'Else
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL, no response", Color.Orange)
                'statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If

            'SerialPort1.WriteLine("")

            Delay(5)
            SerialPort1.Write("" & vbCr)

            Delay(0.3)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
            'Timer2.Enabled() = True
            'Timer2.Start()

            Delay(60)

            If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
                row_grid_Done(DataGridView1.RowCount)
                SerialPort1.WriteLine("root")
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")

                Delay(1)
                'If RichTextBoxTemp.Text.Contains("manufacturing login: root") Then
                SerialPort1.WriteLine("OGtest1")

                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Password"), "XXXXXX")
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Done", Color.LightGreen)
            ElseIf RichTextBoxTemp.Text.Contains("Opengear Manufacturing") = False Then
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Fail", Color.Orange)
                'GoTo failure225
                statusfinaltest_result = "FAIL"
                save_log()
                Exit Sub
            End If


            Delay(5)
            SerialPort1.Write("" & vbCr)

            Delay(0.3)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
            'Delay(1)
            'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")



            Delay(6)
            SerialPort1.WriteLine(MAC1) 'write MAC1
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #1", "Done", Color.LightGreen)
            write_MAC1 = "PASS"

            Delay(6)
            SerialPort1.WriteLine(MAC2) 'write MAC2
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC #2", "Done", Color.LightGreen)
            write_MAC2 = "PASS"

            Delay(6)
            SerialPort1.WriteLine(MACsw0) 'write MAC sw0
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "MAC sw0", "Done", Color.LightGreen)
            write_MACsw0 = "PASS"


            Delay(6)
            SerialPort1.WriteLine("reboot")
            RichTextBoxTemp.Clear()
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "DUT Reboot")

            If RichTextBoxTemp.Text.Contains("root@manufacturing:~# reboot") Then
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:~# reboot"), "XXXXXX")
                write_all_mac = "PASS"
            End If




            Delay(60)
            If RichTextBoxTemp.Text.Contains("Opengear Manufacturing") Then
                reboot_DUT = "PASS"
                RichTextBoxTemp.Clear()
                row_grid_Done(DataGridView1.RowCount)
                SerialPort1.WriteLine("root")
                Delay(2)
                SerialPort1.WriteLine("OGtest1")
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Login", "Done", Color.LightGreen)
                login_status = "PASS"
                'ElseIf RichTextBoxTemp.Text.Contains("Opengear Manufacturing") = False Then
                'row_grid_FAIL(DataGridView1.RowCount)
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL, no booting response", Color.Orange)
                'GoTo failure225

                'statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If

            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("manufacturing login"), "XXXXXX")


            'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Password"), "XXXXXX")

            'Delay(5)
            'SerialPort1.Write("" & vbCr)
            'Delay(1)

            Delay(5)
            SerialPort1.Write("" & vbCr)

            Delay(0.3)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
            'RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")
            Delay(2)


            If RichTextBoxTemp.Text.Contains("root@manufacturing:") Then
                RichTextBoxTemp.Clear()
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:"), "XXXXXX")

                'ElseIf RichTextBoxTemp.Text.Contains("root@manufacturing:~#") = False Then
                '   add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL, no response", Color.Orange)
                'GoTo failure225

                'statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If
            'SerialPort1.WriteLine("")

            Delay(0.3)
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")



            Delay(5)
            SerialPort1.WriteLine("rwmac net1")
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC1", "Done", Color.LightGreen)
            verify_MAC1 = "PASS"

            Delay(5)
            SerialPort1.WriteLine("rwmac net2")
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC2", "Done", Color.LightGreen)
            verify_MAC2 = "PASS"


            Delay(5)
            SerialPort1.WriteLine("rwmac sw0")
            add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Verify MAC sw0", "Done", Color.LightGreen)
            verify_MACsw0 = "PASS"


            Delay(5)
            SerialPort1.WriteLine("loopback")
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "Loopback")


            If RichTextBoxTemp.Text.Contains("root@manufacturing:~# loopback") Then
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:~# loopback"), "XXXXXX")
                verify_all_mac = "PASS"
            End If

            Delay(12)
            'SendKeys.SendWait("^C")
            'SendKeys.Send("^C")
            'SendKeys.Send("^c")
            'SendKeys.Send("^C")
            'SerialPort1.Write("^C" & vbCr)
            SerialPort1.Write(New Byte() {3}, 0, 1) 'Ctrl+C ok
            'SerialPort1.Write(New Byte() {4}, 0, 1) 'Ctrl+D
            'SerialPort1.Write("u" & vbCr) 'u
            'InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C)
            'SerialPort1.WriteLine("^C")
            If RichTextBoxTemp.Text.Contains("LLLLLLLL LL  LLLL") Then
                loopback = "PASS"
                row_grid_PASS(DataGridView1.RowCount)

                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
                'add_row_grid_RESULT(DataGridView1.RowCount + 1, "Loopback", "PASS", Color.LightGreen)
            ElseIf RichTextBoxTemp.Text.Contains("LLLLLLLL LL  LLLL") = False Then
                row_grid_FAIL(DataGridView1.RowCount)
                add_row_grid_RESULT(DataGridView1.RowCount + 1, "FCT", "FAIL, Loopback", Color.IndianRed)
                'GoTo failure225

                loopback = "FAIL"
                statusfinaltest_result = "FAIL"

                'save_log()
                'Exit Sub
            End If



            Delay(2)

            'SerialPort1.DiscardOutBuffer()
            'SerialPort1.DiscardInBuffer()

            SerialPort1.WriteLine("selftest-local --exclude slow")
            add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "Self Test")

            Delay(40)

            'SerialPort1.DiscardOutBuffer()
            'SerialPort1.DiscardInBuffer()




            'Delay(2)

            If RichTextBoxTemp.Text.Contains("selftest                                                              | [32mPASS[0m |") Then
                'RichTextBoxTemp.Clear()
                row_grid_PASS(DataGridView1.RowCount)
                self_test = "PASS"
                add_row_grid_INPROGRESS_WAIT(DataGridView1.RowCount + 1)
                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing"), "XXXXXX")
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Selftest", "PASS", Color.LightGreen)
            ElseIf RichTextBoxTemp.Text.Contains("selftest                                                              | [31mFAIL[0m |") Then
                'RichTextBoxTemp.Clear()
                row_grid_FAIL(DataGridView1.RowCount)
                add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.IndianRed)
                add_row_grid_INPROGRESS_WAIT(DataGridView1.RowCount + 1)


                RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[31m"), "")
                RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[32m"), "")
                RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[0m"), "")
                RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape(""), "")


                TestingtimeEnd = DateTime.Now
                Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
                ResultTextBoxFCT.BackColor = Color.IndianRed
                ResultTextBoxFCT.Text = "FAIL"
                self_test = "FAIL"
                statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If


            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[31m"), "")
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[32m"), "")
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[0m"), "")
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape(""), "")
            RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Verify Ethernet Controller Presence :: Confirm i210 Ethernet contr... F"), "")


            '----------------------------------------------------------------
            Delay(10)
            If RichTextBoxTemp.Text.Contains("root@manufacturing:") Then
                row_grid_REMOVE_WAIT(DataGridView1.RowCount)
                RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("root@manufacturing:"), "XXXXXX")
                add_row_grid_INPROGRESS(DataGridView1.RowCount + 1, "LED SEQUENCE")
                SerialPort1.WriteLine("leds-sequence")
                RichTextBoxTemp.Clear()

                'Dim intRespons1 As Integer
                Using form = New Form() With {.TopMost = True}
                    intResponse1 = MessageBox.Show(form, "Apakah LED SEQUENCE sudah benar?", "LED SEQUENCE", vbYesNo)
                End Using
                If intResponse1 = vbYes Then
                    LED_sequence = "PASS"
                    row_grid_PASS_LED(DataGridView1.RowCount)

                End If

                If intResponse1 = vbNo Then
                    LED_sequence = "FAIL"
                    row_grid_FAIL(DataGridView1.RowCount)
                    add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.IndianRed)

                    statusfinaltest_result = "FAIL"
                    'save_log()
                    'Exit Sub
                End If

                'row_grid_PASS(DataGridView1.RowCount)

                'RichTextBoxTemp.Text = Regex.Replace(RichTextBoxTemp.Text, Regex.Escape("Opengear Manufacturing 1.7.1"), "XXXXXX")
                'add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "Selftest", "PASS", Color.LightGreen)


                'ElseIf RichTextBoxTemp.Text.Contains("root@manufacturing:") = False Then
                'row_grid_FAIL(DataGridView1.RowCount)
                '   add_row_grid_RESULT_NOTIME(DataGridView1.RowCount + 1, "FCT", "FAIL", Color.Orange)

                '   TestingtimeEnd = DateTime.Now
                '  Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
                ' ResultTextBoxFCT.BackColor = Color.IndianRed
                'ResultTextBoxFCT.Text = "FAIL"
                'statusfinaltest_result = "FAIL"
                'save_log()
                'Exit Sub
            End If







            TestingtimeEnd = DateTime.Now
            Total_Test_TimeTextBox.Text = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")

            Start_BT.Enabled = True
            StopBT.Enabled = True
            Start_BT.BackColor = Color.Orange





            'IMAGE_File_Data = "NA"

            If self_test = "PASS" And LED_sequence = "PASS" Then
                ResultTextBoxFCT.Text = "PASS"
                ResultTextBoxFCT.BackColor = Color.LightGreen
                statusfinaltest_result = ResultTextBoxFCT.Text
                add_row_grid_RESULT_BOLD(DataGridView1.RowCount + 1, "FCT and LED", "PASS", Color.LightGreen)
            Else
                ResultTextBoxFCT.Text = "FAIL"
                ResultTextBoxFCT.BackColor = Color.IndianRed
                statusfinaltest_result = ResultTextBoxFCT.Text
                add_row_grid_RESULT_BOLD(DataGridView1.RowCount + 1, "FCT and LED", "FAIL", Color.IndianRed)
            End If




            get_power_current()

            save_log_ORI()
            save_log()
            save_log_RAW()

            parsing_summary()

            save_log_summary()

            DUTDisconnect()

            MsgBox("TESTING SELESAI." & vbNewLine & vbNewLine & "RESULT FCT: " & statusfinaltest_result & vbNewLine & vbNewLine _
                   & "Silahkan cabut power supply dan pasang DUT baru")


            RichTextBoxTemp.Clear()
            RichTextBox2.Clear()
            RichTextBox3.Clear()

        End If




    End Sub




    Private Sub ForceStopBT_Click(sender As Object, e As EventArgs) Handles ForceStopBT.Click

        'conn.Close()

        'Dim pProcess1() As Process = System.Diagnostics.Process.GetProcessesByName(LabelModBuildNumber.Text + "_Testing1") 'jgn pakai exe, langsung kill form

        'For Each p As Process In pProcess1
        'p.Kill()
        'System.Diagnostics.Process.Start("parsing_v2")
        'p.Start()

        'Next

        'Dim pProcess2() As Process = System.Diagnostics.Process.GetProcessesByName("Form_" + LabelModBuildNumber.Text + "_Testing1") 'jgn pakai exe, langsung kill form

        'For Each p As Process In pProcess2
        'p.Kill()
        'System.Diagnostics.Process.Start("parsing_v2")
        'p.Start()
        'Next
        DUTDisconnect()

        Dim pProcess3() As Process = System.Diagnostics.Process.GetProcessesByName("OPG-TESTING1") 'jgn pakai exe, langsung kill form

        For Each p As Process In pProcess3
            p.Kill()
            'System.Diagnostics.Process.Start("parsing_v2")
            'p.Start()
        Next


        Environment.Exit(0)
        'Application.Exit()
        Close()
        End
    End Sub




    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub AdminToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdminToolStripMenuItem.Click
        'Passw.Show()
    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click 'save log for convert


        'ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_convert\" + SerialTextBox.Text + "_" + Format(Now, "ddMMyyyy") + "_" + TestingtimeStart.ToString("HHmmss") + "_FAIL.txt"

        ExcelDialog.FileName = "D:\SIERRA_TEST\LOG_convert\" + TextBox2.Text + ".txt"


        'WriteLine(RichTextBox1.Text = "dfds")

        Log_File_Data = ExcelDialog.FileName


        RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)  'bisa digunakan
        RichTextBox2.SaveFile(ExcelDialog.FileName, RichTextBoxStreamType.PlainText)

        TextBox2.Clear()

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        ComboBoxKGB.Hide()
        ComboBoxVoltTest.Hide()
        Label2.Hide()
        ComboBoxOpName.Text = ""
        ComboBoxBadgeId.Text = ""
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        'MsgBox("This application develop")
    End Sub






    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles PSTestBT.Click ' test power supply tenma
        If ComboBoxCOMPS.Text = "" _
           Or ComboBoxCOMPS.Text = "Select COM" _
           Or ComboBoxBaudRPS.Text = "" _
           Or ComboBoxBaudRPS.Text = "Select Baud Rate" Then

            MessageBox.Show("Check COM or Baud Rate, then click Connect", "TESTING #1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PSConnectSerial.BackColor = Color.IndianRed

            ComboBoxCOMPS.Select()
            Exit Sub
        End If



        'RichTextBox1.Clear()

        SerialPortPS.Write("OUT0" & vbCr)

        'For i = 1 To 20
        'Threading.Thread.Sleep(100)
        'Application.DoEvents()
        'Next
        Delay(4)

        'ok
        SerialPortPS.Write("*IDN?" & vbCr)
        SerialPortPS.Write("VSET1:" & ComboBoxVoltTest.Text & vbCr)
        SerialPortPS.Write("OUT1" & vbCr)

        'SerialPortPS.Write("VSET1:24.00" & vbCr)
        SerialPortPS.Write("ISET1:1.000" & vbCr)
        SerialPortPS.Write("VSET1?" & vbCr)
        SerialPortPS.Write("IOUT1?" & vbCr)
        SerialPortPS.Write("OCP0" & vbCr) 'jgn diaktifkan karena  PS akan sering auto cut off arus, walaupun arus melonjak sedikit

        'For i = 1 To 20
        'Threading.Thread.Sleep(100)
        'Application.DoEvents()
        'Next
        Delay(0.1)



        If SerialPortPS.IsOpen() = True And RichTextBoxTemp.Text.Contains("TENMA") Then
            'RichTextBox1.Clear()
            'RichTextBox1.Text &= vbNewLine & "Power supply connection OK" & vbNewLine
            LabelInfo.Text = "Power supply connection OK and SET to 1Amp, and " & ComboBoxVoltTest.Text & "VDC"
            'PSConnectSerial.BackColor = Color.LightGreen
            'PSTestBT.BackColor = Color.LightGreen
        Else
            LabelInfo.Text = "Power supply connection NOK"
        End If



        'If Not RichTextBoxTemp.Text.Contains("TENMA") Then
        'RichTextBox1.Text &= vbNewLine & "Power supply connection NOK, cek serial connection or RESTART Power Supply" & vbNewLine
        'MessageBox.Show("Power supply connection NOK" + vbNewLine + vbNewLine + "Cek serial connection or RESTART Power Supply", "", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'PSConnectSerial.BackColor = Color.IndianRed
        'PSTestBT.BackColor = Color.IndianRed
        'End If
        'ok
        'SerialPort1.WriteLine("OUT1")
        'SerialPort1.WriteLine("*IDN?")
        'SerialPort1.WriteLine("VSET1?")
        'SerialPort1.WriteLine("IOUT1?")

        'nok
        'SerialPort1.Write("OUT1")
        'SerialPort1.Write("*IDN?")
        'SerialPort1.Write("VSET1?")
        'SerialPort1.Write("IOUT1?")
    End Sub

    Private Sub MACBarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MACBarcodeToolStripMenuItem.Click
        'Form_MAC.Show()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles RestartModTesterBT.Click


        SerialPortPS.Write("OUT0" & vbCr)

        'For i = 1 To 20
        'Threading.Thread.Sleep(100)
        'Application.DoEvents()
        'Next
        'wait(2000)
        Delay(4)

        'SerialPortPS.Write("VSET1:" & ComboBoxVoltTest.Text & vbCr)
        SerialPortPS.Write("VSET1:12.00" & vbCr)
        SerialPortPS.Write("ISET1:1.000" & vbCr)
        SerialPortPS.Write("OUT1" & vbCr)

        'SerialPortPS.Write("VSET1:24.00" & vbCr)


        'wait(4000)

        Start_BT.Enabled = True
    End Sub



    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        RichTextBox1.Clear()
    End Sub





    Sub wait(ByVal interval As Long)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged
        RichTextBox1.Select()
        RichTextBox1.Select(RichTextBox1.Text.Length, 0)
    End Sub

    Sub stop_process()
        Total_Test_TimeTextBox.Text = "00:00:00"
        Start_BT.Enabled = True
        StopBT.Enabled = True
        Start_BT.BackColor = Color.Orange
        ResultTextBoxFCT.Clear()
        ResultTextBoxFCT.BackColor = Color.White

        RichTextBox1.Clear()
        'DataGridView1.ClearSelection()

        IMEITextBox1.Clear()
        MACTextBox2.Clear()
        MACsw0TextBox.Clear()
        SerialTextBox.Clear()
        DataGridView1.Rows.Clear()
        'If MyProcess IsNot Nothing Then MyProcess.Kill()
        'End ' it will close application
    End Sub



    Private Sub StopBT_Click(sender As Object, e As EventArgs) Handles StopBT.Click
        'SerialPort1.ReadTimeout() = "1"
        'OperationAbortedException()
        'Thread.ResetAbort()
        'Thread.CurrentThread.Abort()

        'Environment.Exit(0)
        'Application.Exit()
        'Close()
        'end
        'me.close()
        'forceExitTimer()
        'Dim forceExitTimer = New Threading.Timer(Sub() End, Nothing, 2500, Timeout.Infinite)
        'Application.Exit()
        'forceExitTimer()
        DUTDisconnect()

        Me.Cursor = Cursors.Default




        ResultTextBoxFCT.Clear()
        TextBoxFirmwCheck.Clear()
        ResultTextBoxFCT.BackColor = Color.White
        TextBoxFirmwCheck.BackColor = Color.White

        ProgressBarFCT.Value = 0
        LabelProgressBarFCT.Text = ""

        ProgressBarFirm.Value = 0
        LabelProgressBarFirm.Text = ""

        'SerialPort1.Close()

        'Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("parsing_v2") 'jgn pakai exe, langsung kill form

        'For Each p As Process In pProcess
        'p.Kill()
        'System.Diagnostics.Process.Start("parsing_v2")
        'p.Start()
        'Next




        'ConnectBT.Enabled = True
        'SendBT.Enabled = False
        'DisconnectBT.Enabled = False
        'ConnectBT.BackColor = Color.IndianRed
        Start_BT.Enabled = True
        StopBT.BackColor = Color.Orange
        Start_BT.BackColor = Color.White


        'Call stop_process()


        Exit Sub



        'If Not File.Exists("op.exe") Then
        'MsgBox("op.exe not found!", MsgBoxStyle.Critical, "Error")
        'Application.Exit()
        'End If
        'IO.Directory.CreateDirectory('files')

        'MsgBox("Are you sure you want to exit?", vbYesNo+vbQuestion,"Thanking You")

    End Sub


    'Private Sub RichTextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox2.KeyDown
    'https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.keys?view=windowsdesktop-7.0&redirectedfrom=MSDN
    'If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.D Then
    'If e.Modifiers = Keys.Control And Keys.D Then

    'RichTextBox2.Text &= "Ctrl+D"
    'RichTextBox2.Text &= Keys.Control AndAlso e.KeyCode = Keys.D 'bernilai TRUE jika klik Ctrl+D
    'unitPriceTxtBox.Text = Clipboard.GetText()
    'End If

    'End Sub

    'Dim _timer As Timers.Timer

    'Sub New()
    ' This call is required by the designer.
    'InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    '_timer = New Timers.Timer()
    '_timer.AutoReset = False
    '_timer.Interval = 1000
    '_timer.SynchronizingObject = Me

    'End Sub


    'Dim myQueue As Queue(Of String) = New Queue(Of String)

    'Dim LineIn As New System.IO.StreamReader(RichTextBox1.Text)
    'Dim counter As Integer

    'Dim tim As Windows.Forms.Timer
    'Private Sub SetUpTimer()
    '    tim = New Timer
    '    tim.Interval = 1000 'milliseconds
    '    tim.Enabled = False
    ' AddHandler() tim.Tick, AddressOf tempBT_Click

    'End Sub

    '<DllImport("ICATCOM.dll", SetLastError:=True)> Shared Function ICATCom_IsConnected _
    '(ByRef ClassGuid As System.Guid,
    'ByVal hwndParent As Int32) _
    'As Int32
    'End Function

    Sub replace_symbol()
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")

        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("7[r[999;999H[6nroot@manufacturing:~#"), "")

        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[31mF"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[31m"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[32m"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[0m"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("[0m"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape(""), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Verify Ethernet Controller Presence :: Confirm i210 Ethernet contr... F"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Verify Pinout Ports Switching Multiple X2 :: Confirm pinout switch... .F"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Verify Baud Rate :: Test Serial ports for lowest and highest baud ... F..."), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Verify Baud Rate :: Test Serial ports for lowest and highest baud ... F"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Verify Pinout Ports Switching Multiple X1 :: Confirm pinout switch... .F"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("??05>??????>~??&??~??????????J?????M????????????.?\????l?v7???\?7??????????????7???H?????????z????????F??????y??????r??D?p??}^?^????????0??????????????6e????????7?????>??????;????!?0???????????{p??????1??????X??????????z??~B????????4??????|`???? ~??#?????:???????>?>?s?~???^????>??????>|v???7?????????????????{???????????????????????t????8???:???????:?????????8??????????~????w??????????<~??????7|???nB>?'?r???~??????_??w??B????????4???|????e??<?w??????0?????A????????0???????r??{??????c??^??????8l???>??P?7??????&;????????????????????????"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("????7?~???~?:w?;????z???z?????????????>?????7??l???E?8y??s;?>????????<????|8???>???7??????|???????????!?t??>??????z????????????????????~3????????>????????/?????|????n??????#|??f??????>?????_<??????~??? ????0{??}?	?8z???zx?????????????>??????????????"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Read Power 2 :: Check power value power-2/power1_input                F"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Read Current 2 :: Check current value power-2/curr1_input             F"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Read Voltage 2 :: Check voltage value power-2/in1_input               F"), "")
        RichTextBox1.Text = Regex.Replace(RichTextBox1.Text, Regex.Escape("Verify Power Consumption :: Check for total current/power use and ... .F......"), "")


    End Sub
    Private Sub tempBT_Click(sender As Object, e As EventArgs) Handles tempBT.Click ', Temp

        replace_symbol()
        Exit Sub
        get_power_current()
        MsgBox(Power_data & " ---- " & Current_data)
        'serial_DUT_auto_connect()
        Exit Sub
        DUTDisconnect()
        Exit Sub
        'parsing_summary()
        'Exit Sub
        Using form = New Form() With {.TopMost = True}
            intResponse3 = MessageBox.Show(form, "Apakah LED MATI semua?", "LED OFF", vbYesNo)
        End Using
        'Dim iPort As Integer
        'Dim sn As String = "QT00806688"
        'iPort = ICATCom_IsConnected(sn)
        Exit Sub


        Dim com_port As IO.Ports.SerialPort = Nothing

        'com_port = My.Computer.Ports.OpenSerialPort(ComboBox1.Text)
        'com_port = My.Computer.Ports.OpenSerialPort("COM3")
        'com_port.ReadTimeout = 10000

        Do
            'Dim Incoming As String = com_port.ReadLine(RichTextBox1.Text.Contains("nama"))
            Dim Incoming As String = SerialPort1.ReadLine(RichTextBox1.Text.Contains("nama"))
            'Dim Outgoing As String = com_port.Write()
            'SerialPort1.Write("g" & vbCr) 
            If Incoming Is Nothing Then
                Exit Do
            Else
                'returnStr &= Incoming & vbCrLf
                RichTextBox2.Text &= Incoming & vbCrLf
            End If
        Loop


        'If com_port IsNot Nothing Then com_port.Close()


    End Sub



    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick  'ok clock
        'If myQueue.Count > 0 Then
        'TextBox1.Text += myQueue.Dequeue '& vbCrLf
        'End If
        '-------------------------------------

        'ok create clock and date realtime
        'Timer1.Enabled = False
        Timer1.Interval = 500 '1000=1detik, 500=0.5detik
        Timer1.Start()
        'counter = counter + 1
        'RichTextBox2.Text = TimeString
        'Date_Label.Text = DateString
        Clock_Label.Text = TimeString
        'RichTextBox2.Text &= TimeString
        'RichTextBox2.Text &= vbCrLf
        'RichTextBox2.Text &= counter

        'Date_testDateTimePicker.Text = DateString '.ToString("ddMMyyy")
        'TestingtimeStart1.Text = TimeString

        'Time.Format(Now, "HH:mm:ss")

        'DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
        '------------------------------------------------

        Exit Sub

        'samakan format date_testDate dengan csv/excel dengan format dd-MMM-yyyy spy bisa terhitung dengan benar
        Dim count_Test_Today = (From row As DataGridViewRow In DataGridView2.Rows
                                Where row.Cells("Date Test").Value = Date_testDate.Text And
                         row.Cells("No").Value IsNot DBNull.Value
                                Select row.Cells("Date Test").Value).Count()

        Dim count_FAIL = (From row As DataGridViewRow In DataGridView2.Rows
                          Where row.Cells("FINAL FCT").Value = "FAIL" Or
                              row.Cells("FINAL FIRMWARE CHECK").Value = "NOT MATCH" And
                              row.Cells("Date Test").Value = Date_testDate.Text And
                         row.Cells("No").Value IsNot DBNull.Value
                          Select row.Cells("FINAL FCT").Value).Count()

        Dim count_PASS = (From row As DataGridViewRow In DataGridView2.Rows
                          Where row.Cells("FINAL FCT").Value = "PASS" And
                              row.Cells("FINAL FIRMWARE CHECK").Value = "MATCH" And
                              row.Cells("Date Test").Value = Date_testDate.Text And
                         row.Cells("No").Value IsNot DBNull.Value
                          Select row.Cells("FINAL FCT").Value).Count()

        TestTodayOKLabel.Text = "#Test OK : " & count_PASS & " of " & count_Test_Today

        TestTodayFAILLabel.Text = "#Test FAIL : " & count_FAIL & " of " & count_Test_Today



    End Sub

    'Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged ' jika ada perubahan text maka akan pagedown

    '    RichTextBox1.Focus()
    '    SendKeys.Send("{PGDN 10}") 'multiple times PgDn

    'RichTextBox1.ResumeLayout()
    'RichTextBox1.SelectionStart = RichTextBox1.TextLength

    'RichTextBox1.ScrollToCaret()
    'RichTextBox1.Select()

    'RichTextBox1.SuspendLayout()
    'RichTextBox1.AutoScrollOffset = AutoScrollPosition


    'RichTextBox1.Font = New Font(RichTextBox1.Font.FontFamily, RichTextBox1.Font.Size + 1, RichTextBox1.Font.Style)

    'RichTextBox1.Font.Height = 10

    'With RichTextBox1.Font
    '.Size = 10
    '.FontFamily
    'End With

    'RichTextBox1.Font.Size = 10
    'RichTextBox1.Focus()
    'RichTextBox1.Height = 10 ' untuk menseting tinggi box
    'SendKeys.Send("^{END}")
    'SendKeys.Send("{PGDN 10}") 'multiple times PgDn

    'Application.SendKeys "{PGDN}"
    'SendKeys ("<rollup>")
    'SendKeys ("<Down>")
    'RichTextBox1.SelectionFont = New Font("Consolas", 10, FontStyle.Regular)

    'RichTextBox1.ScrollToEnd()


    'End Sub




    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'simulate1, sukses membaca tiap line dari serial incoming, tetapi looping terus menurus sehingga LAGGING

        'Receive_Text = SerialPort1.Read()
        'Receive_Text = SerialPort1.ReadLine()
        'SerialPort1.Write("1" & vbCr)
        'Receive_Text = SerialPort1.ReadExisting()
        'wait(1000)
        'Receive_Text = SerialPort1.ReadLine()
        'SerialPort1.ReadTimeout = 1000
        'Me.Invoke(New Receive_Text(AddressOf updatetext), Receive_Text)
        'RichTextBox2.Clear()
        'RichTextBox2.Text = SerialPort1.ReadLine()

        Do While True
            'Try
            Receive_Text = SerialPort1.ReadLine  'jangan gunakan readline()
            'SerialPort1.ReadTimeout = 1000
            'RaiseEvent PortData(Receive_Text)
            'System.Threading.Thread.Sleep(0)
            'My.Application.DoEvents()
            RichTextBox1.Text &= Receive_Text
            If Receive_Text.Contains("Scan in last 6 digits of MAC address, followed by [Enter] :") Then
                'Receive_Text = SerialPort1.ReadLine()
                'RichTextBox2.Text = Receive_Text
                'If Receive_Text = "Scan in last 6 digits of MAC address, followed by [Enter] :" Then
                'If RichTextBox1.Text.Contains("Scan in last 6 digits of MAC address, followed by [Enter] :") Then
                RichTextBox2.Text &= "data MAC diterima" + vbNewLine
                'Exit Do
                'MsgBox("data diterima")
                'Else
                'Exit Do
            End If

            If Receive_Text.Contains("Enter 10 digit part number as NNNNNNNNNN followed by [Enter]:") Then
                'Receive_Text = SerialPort1.ReadLine()
                'RichTextBox2.Text = Receive_Text
                'If Receive_Text = "Scan in last 6 digits of MAC address, followed by [Enter] :" Then
                'If RichTextBox1.Text.Contains("Scan in last 6 digits of MAC address, followed by [Enter] :") Then
                RichTextBox2.Text &= "data PN diterima" + vbNewLine
                'Exit Do
                'MsgBox("data diterima")
                'Else
                'Exit Do
            End If
            'Catch ex As Exception
            'Exit Do
            'Catch
            If Receive_Text.Contains("FAIL") Then
                MsgBox("FAIL")
                'Exit Sub
                Exit Do
            End If
            'End Try
        Loop


        'For i = 1 To 30
        'Threading.Thread.Sleep(100)
        'Application.DoEvents()
        'Next
        RichTextBox2.Text &= "sukses"
    End Sub



    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ERASE_PROG.Click 'ok
        'If Not RichTextBoxTemp.Text.Contains("Enter choice (ESC to exit-Diagnostic Tests)[thmMVR123456] :") Then
        'MessageBox.Show("RESTART the test module until ready to ERASE", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Exit Sub
        'End If

        'If RichTextBoxTemp.Text.Contains("Enter choice (ESC to exit-Diagnostic Tests)[thmMVR123456] :") Then
        ProgressBarFirm.Value = 0
        LabelProgressBarFirm.Text = ""

        ProgressBarFCT.Minimum = 0 'dipinjam untuk erase, bukan FCT
        ProgressBarFCT.Maximum = 6 'dipinjam untuk erase, bukan FCT 
        LabelProgressBarFCT.Text = "ERASE IN PROGRES... Please WAIT..."  'dipinjam untuk erase, bukan FCT 


        RichTextBox1.Clear()
        RichTextBoxTemp.Clear()
        '----------------------------------------
        Total_Test_TimeTextBox.Text = "00:00:00"
        Start_BT.Enabled = False
        StopBT.Enabled = True
        Start_BT.BackColor = Color.Orange
        ResultTextBoxFCT.Clear()
        ResultTextBoxFCT.BackColor = Color.White
        TextBoxFirmwCheck.Clear()
        TextBoxFirmwCheck.BackColor = Color.White

        DataGridView1.Rows.Clear()

        '------------------------------------------------------------------------------
        ProgressBarFCT.Value = 1

        SerialPortPS.Write("OUT0" & vbCr)
        Delay(2)
        'wait(2000)
        ProgressBarFCT.Value = 2

        SerialPortPS.Write("VSET1:" & ComboBoxVoltTest.Text & vbCr)
        SerialPortPS.Write("OUT1" & vbCr)
        Delay(2)
        'wait(3000)
        'Start_BT.Enabled = True

        ProgressBarFCT.Value = 3
        '------------------------------------------------------------------------------

        'MsgBox("Nyalakan LED ORANGE, abaikan jika sudah menyala")


        TestingtimeStart1.Text = Format(Now, "HH:mm:ss") ' HH=jam 00-23, hh=AM atau PM
        TestingtimeStart = TestingtimeStart1.Text

        'DataGridView1.Rows.Add(1, "ERASE PROGRAM", "IN PROGRESS... Please WAIT...", "")
        'SerialPortPS.WriteLine("OUT0" & vbCr)

        'For i = 1 To 10
        'Threading.Thread.Sleep(100)
        'Application.DoEvents()
        'Next

        'SerialPortPS.WriteLine("OUT1" & vbCr)
        'wait(3000)

        SerialPort1.Write(New Byte() {4}, 0, 1) 'Ctrl+D
        SerialPort1.Write("u" & vbCr) 'u

        Delay(2)
        'wait(2000)
        ProgressBarFCT.Value = 4

        SerialPort1.Write(New Byte() {4}, 0, 1) 'Ctrl+D
        SerialPort1.Write("c" & vbCr) 'c


        'MsgBox("turn switch ON (until orange LED ON)")

        'For i = 1 To 10
        ' Threading.Thread.Sleep(100)
        ' Application.DoEvents()
        'Next
        Delay(2)
        'wait(2000)
        ProgressBarFCT.Value = 5

        'MsgBox("Nyalakan LED ORANGE fixture test")
        SerialPort1.Write("f" & vbCr)

        'wait(1000)
        '-------------------------------

        '-------------------------

        Start_BT.Enabled = True



    End Sub

    Private Sub frmConsole_Move()
        'Private Sub frmConsole_Move(sender As Object, e As EventArgs) Handles MyBase.Move
        If Me.WindowState = FormWindowState.Minimized Then 'after
            PictureBox1.Hide()

            'Me.Size = New System.Drawing.Size(400, 270)
            Me.Size = New System.Drawing.Size(490, 595)
            Me.WindowState = FormWindowState.Normal

            Start_BT.Size = New System.Drawing.Size(168, 56)
            Start_BT.Location = New Point(49, 11)

            ForceStopBT.Size = New System.Drawing.Size(135, 30)
            ForceStopBT.Location = New Point(256, 0)

            StopBT.Size = New System.Drawing.Size(135, 38)
            StopBT.Location = New Point(256, 36)

            LabelPartNumber.Location = New Point(213, 230)
            LabelModBuildNumber.Location = New Point(9, 225)

            ERASE_PROG.Size = New System.Drawing.Size(159, 32)
            ERASE_PROG.Location = New Point(235, 517)

            CheckBoxShowCOM.Location = New Point(418, 526)
            PanelCOM.Location = New Point(0, 551)

            RichTextBox2.Hide()

            'Me.Location = New Point(padre.GMapControl.Location.X, padre.GMapControl.Location.Y + 1000)
            'Me.TopMost = True
            'borderform.RoundedRectangle(Me)
            'roundCorners(Me)
        ElseIf Me.WindowState = FormWindowState.Maximized Then 'before
            PictureBox1.Show()


            Me.Size = New System.Drawing.Size(1620, 920)
            Me.WindowState = FormWindowState.Maximized

            Start_BT.Size = New System.Drawing.Size(178, 86)
            Start_BT.Location = New Point(493, 14)

            ForceStopBT.Size = New System.Drawing.Size(135, 30)
            ForceStopBT.Location = New Point(710, 11)

            StopBT.Size = New System.Drawing.Size(135, 56)
            StopBT.Location = New Point(710, 44)

            LabelPartNumber.Location = New Point(2, 230)
            LabelModBuildNumber.Location = New Point(1181, 106)


            ERASE_PROG.Size = New System.Drawing.Size(171, 68)
            ERASE_PROG.Location = New Point(713, 727)

            CheckBoxShowCOM.Location = New Point(21, 665)

            RichTextBox2.Show()
            PanelCOM.Location = New Point(0, 688)

            'Me.Location = New Point(padre.Location.X + padre.GMapControl.Width * 0.9, padre.Location.Y)
        End If
    End Sub



    Private Sub add_row_grid_RESULT_NOTIME(n, test_name, result, color)
        ' TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeEnd = DateTime.Now
        DataGridView1.Rows.Add()
        DataGridView1.Rows(n - 1).Cells(0).Value = n
        DataGridView1.Rows(n - 1).Cells(1).Value = test_name
        DataGridView1.Rows(n - 1).Cells(2).Value = result
        DataGridView1.Rows(n - 1).Cells(3).Value = ""
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = color
        DataGridView1.AutoResizeColumns()
        DataGridView1.Rows(n - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub
    Private Sub add_row_grid_INPROGRESS(n, test_name)
        'TestingtimeStart1.Text = Format("HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeEnd = DateTime.Now
        DataGridView1.Rows.Add()
        DataGridView1.Rows(n - 1).Cells(0).Value = n
        DataGridView1.Rows(n - 1).Cells(1).Value = test_name
        DataGridView1.Rows(n - 1).Cells(2).Value = "WAIT.."
        DataGridView1.Rows(n - 1).Cells(3).Value = ""
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.LightBlue
        DataGridView1.AutoResizeColumns()
        DataGridView1.Rows(n - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub

    Private Sub add_row_grid_INPROGRESS_WAIT(n)
        'TestingtimeStart1.Text = Format("HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeEnd = DateTime.Now
        DataGridView1.Rows.Add()
        DataGridView1.Rows(n - 1).Cells(0).Value = ""
        DataGridView1.Rows(n - 1).Cells(1).Value = "WAIT..."
        'DataGridView1.Rows(n - 1).Cells(2).Value = ""
        'DataGridView1.Rows(n - 1).Cells(3).Value = ""
        DataGridView1.Rows(n - 1).Cells(1).Style.BackColor = Color.LightYellow
        DataGridView1.AutoResizeColumns()
        DataGridView1.Rows(n - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub


    Private Sub row_grid_REMOVE_WAIT(n)
        If DataGridView1.Rows(n - 1).Cells(1).Value = "WAIT..." Then
            DataGridView1.Rows.RemoveAt(n - 1) 'ok untuk delete
        End If
    End Sub
    Private Sub add_row_grid_RESULT(n, test_name, result, color)
        ' TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text

        DataGridView1.Rows.Add()
        DataGridView1.Rows(n - 1).Cells(0).Value = n
        DataGridView1.Rows(n - 1).Cells(1).Value = test_name
        DataGridView1.Rows(n - 1).Cells(2).Value = result
        TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(3).Value = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
        TestingtimeStart = Format(Now, "HH:mm:ss")
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = color
        DataGridView1.AutoResizeColumns()
        DataGridView1.Rows(n - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub
    Private Sub add_row_grid_RESULT_BOLD(n, test_name, result, color)
        ' TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text

        DataGridView1.Rows.Add()
        DataGridView1.Rows(n - 1).Cells(0).Value = n
        DataGridView1.Rows(n - 1).Cells(1).Value = test_name
        DataGridView1.Rows(n - 1).Cells(2).Value = result
        DataGridView1.Rows(n - 1).Cells(2).Style.Font = New Font("Verdana", 11, FontStyle.Bold)
        TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(3).Value = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
        TestingtimeStart = Format(Now, "HH:mm:ss")
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = color
        DataGridView1.AutoResizeColumns()
        DataGridView1.Rows(n - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub

    Private Sub add_row_grid_RESULT_BOLD_FCT(n, test_name, result, color)
        ' TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text

        DataGridView1.Rows.Add()
        DataGridView1.Rows(n - 1).Cells(0).Value = n
        DataGridView1.Rows(n - 1).Cells(1).Value = test_name
        DataGridView1.Rows(n - 1).Cells(2).Value = result
        DataGridView1.Rows(n - 1).Cells(2).Style.Font = New Font("Verdana", 11, FontStyle.Bold)
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = color
        DataGridView1.AutoResizeColumns()
        DataGridView1.Rows(n - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub


    Private Sub row_grid_FAIL(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(2).Value = "FAIL"
        'DataGridView1.Rows(n - 1).Cells(2).Style.Font = New Font("Verdana", 11, FontStyle.Bold)
        DataGridView1.Rows(n - 1).Cells(3).Value = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
        TestingtimeStart = Format(Now, "HH:mm:ss")
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.IndianRed
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub
    Private Sub row_grid_FAIL_reason(n, reason)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(2).Value = "FAIL"
        'DataGridView1.Rows(n - 1).Cells(2).Style.Font = New Font("Verdana", 11, FontStyle.Bold)
        DataGridView1.Rows(n - 1).Cells(3).Value = reason
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.IndianRed
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub
    Private Sub row_grid_PASS(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(2).Value = "PASS"
        DataGridView1.Rows(n - 1).Cells(3).Value = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
        TestingtimeStart = Format(Now, "HH:mm:ss")
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.LightGreen
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1

    End Sub

    'Dim countx As Integer
    Private Sub row_grid_counting(n, countx)

        DataGridView1.Rows(n - 1).Cells(2).Value = countx

        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.LightBlue
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1

    End Sub
    Private Sub row_grid_PASS_LED(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(2).Value = "PASS"
        DataGridView1.Rows(n - 1).Cells(3).Value = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
        TestingtimeStart = Format(Now, "HH:mm:ss")
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.LightGreen
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1

    End Sub

    Private Sub row_grid_PASS_FCT(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text

        DataGridView1.Rows(n - 1).Cells(2).Value = "PASS"
        DataGridView1.Rows(n - 1).Cells(2).Style.Font = New Font("Verdana", 11, FontStyle.Bold)
        TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(3).Value = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
        TestingtimeStart = Format(Now, "HH:mm:ss")
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.LightGreen
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1

        'OK
        'With DataGridView1.Rows(n - 1).Cells(2).Style
        '.Font = New Font(DataGridView1.Font, FontStyle.Bold)
        'End With
    End Sub

    Private Sub row_grid_FAIL_FCT(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text

        DataGridView1.Rows(n - 1).Cells(2).Value = "FAIL"
        DataGridView1.Rows(n - 1).Cells(2).Style.Font = New Font("Verdana", 11, FontStyle.Bold)
        TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(3).Value = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
        TestingtimeStart = Format(Now, "HH:mm:ss")
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.IndianRed
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub

    Private Sub row_grid_Done(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(2).Value = "Done"
        DataGridView1.Rows(n - 1).Cells(3).Value = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
        TestingtimeStart = Format(Now, "HH:mm:ss")
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.LightGreen
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub

    Private Sub row_grid_Done_previousUP(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(2).Value = "Already UP"
        DataGridView1.Rows(n - 1).Cells(3).Value = ""
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.LightGreen
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub

    Private Sub row_grid_WAIT(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(2).Value = "WAIT.."
        DataGridView1.Rows(n - 1).Cells(3).Value = ""
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.LightBlue
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub

    Private Sub row_grid_CANCEL(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(2).Value = "CANCEL"
        DataGridView1.Rows(n - 1).Cells(3).Value = ""
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.Orange
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub



    Private Sub row_grid_YES(n)
        'TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text
        'TestingtimeEnd = DateTime.Now
        'DataGridView1.Rows(n - 1).Cells(0).Value = 1
        DataGridView1.Rows(n - 1).Cells(2).Value = "YES"
        DataGridView1.Rows(n - 1).Cells(3).Value = ""
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = Color.LightGreen
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub


    Private Sub row_grid_RESULT(n, test_name, result, color)
        ' TestingtimeStart1.Text = Format(Now, "HH:mm:ss")
        'TestingtimeStart = TestingtimeStart1.Text

        'DataGridView1.Rows.Add()
        DataGridView1.Rows(n - 1).Cells(0).Value = n
        DataGridView1.Rows(n - 1).Cells(1).Value = test_name
        DataGridView1.Rows(n - 1).Cells(2).Value = result
        TestingtimeEnd = DateTime.Now
        DataGridView1.Rows(n - 1).Cells(3).Value = (TestingtimeEnd - TestingtimeStart).ToString("hh':'mm':'ss")
        TestingtimeStart = Format(Now, "HH:mm:ss")
        DataGridView1.Rows(n - 1).Cells(2).Style.BackColor = color
        DataGridView1.AutoResizeColumns()
        DataGridView1.Rows(n - 1).Cells(0).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(2).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.Rows(n - 1).Cells(3).Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.RowCount - 1
    End Sub


    Sub reset_datagrid()


        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            'DirectCast(row.DataBoundItem, DataRowView).Delete()
            DataGridView1.Rows.Remove(row)
        Next

        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            'DirectCast(row.DataBoundItem, DataRowView).Delete()
            DataGridView1.Rows.Remove(row)
        Next

        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            'DirectCast(row.DataBoundItem, DataRowView).Delete()
            DataGridView1.Rows.Remove(row)
        Next

        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            'DirectCast(row.DataBoundItem, DataRowView).Delete()
            DataGridView1.Rows.Remove(row)
        Next

        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            'DirectCast(row.DataBoundItem, DataRowView).Delete()
            DataGridView1.Rows.Remove(row)
        Next

        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            'DirectCast(row.DataBoundItem, DataRowView).Delete()
            DataGridView1.Rows.Remove(row)
        Next

        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            'DirectCast(row.DataBoundItem, DataRowView).Delete()
            DataGridView1.Rows.Remove(row)
        Next
        DataGridView1.Refresh()
        'Me.TestTableTableAdapter.Update(TestDBDataSet.TestTable)
    End Sub

    Private Sub LabelProductNumber_Click(sender As Object, e As EventArgs) Handles LabelPartNumber.Click

    End Sub

    Private Sub OperatorBadgeID_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SerialNum_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Total_Test_TimeLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MACLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TimeLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Date_testLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ModelLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SN_DUTLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Operator_testLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RWO_IdLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Total_Test_TimeTextBox_TextChanged(sender As Object, e As EventArgs) Handles Total_Test_TimeTextBox.TextChanged

    End Sub

    Private Sub LabelModBuildNumber_Click(sender As Object, e As EventArgs) Handles LabelModBuildNumber.Click

    End Sub

    Private Sub Clock_Label_Click(sender As Object, e As EventArgs) Handles Clock_Label.Click

    End Sub

    Private Sub Date_Label_Click(sender As Object, e As EventArgs) Handles Date_Label.Click

    End Sub

    Private Sub TextBoxFirmwCheck_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFirmwCheck.TextChanged

    End Sub

    Private Sub TestTodayFAILLabel_Click(sender As Object, e As EventArgs) Handles TestTodayFAILLabel.Click

    End Sub

    Private Sub RichTextBoxTemp_TextChanged(sender As Object, e As EventArgs) Handles RichTextBoxTemp.TextChanged

    End Sub

    Private Sub ResultTextBoxFCT_TextChanged(sender As Object, e As EventArgs) Handles ResultTextBoxFCT.TextChanged

    End Sub

    Private Sub ProgressBarFCT_Click(sender As Object, e As EventArgs) Handles ProgressBarFCT.Click

    End Sub

    Private Sub SerialNumTextBox_TextChanged(sender As Object, e As EventArgs) Handles MACsw0TextBox.TextChanged

    End Sub

    Private Sub LabelInfo_Click(sender As Object, e As EventArgs) Handles LabelInfo.Click

    End Sub

    Private Sub LabelProgressBarFirm_Click(sender As Object, e As EventArgs) Handles LabelProgressBarFirm.Click

    End Sub

    Private Sub ProgressBarFirm_Click(sender As Object, e As EventArgs) Handles ProgressBarFirm.Click

    End Sub

    Private Sub ComboBoxBaudRPS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBaudRPS.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxCOMPS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCOMPS.SelectedIndexChanged

    End Sub

    Private Sub LabelProgressBarFCT_Click(sender As Object, e As EventArgs) Handles LabelProgressBarFCT.Click

    End Sub

    Private Sub TestingtimeStart1_TextChanged(sender As Object, e As EventArgs) Handles TestingtimeStart1.TextChanged

    End Sub

    Private Sub PartNumberTextBox_TextChanged(sender As Object, e As EventArgs) Handles MACTextBox2.TextChanged

    End Sub

    Private Sub PasswordTextBox_TextChanged(sender As Object, e As EventArgs) Handles SerialTextBox.TextChanged

    End Sub

    Private Sub MACTextBox_TextChanged(sender As Object, e As EventArgs) Handles IMEITextBox1.TextChanged

    End Sub

    Private Sub TestTodayOKLabel_Click(sender As Object, e As EventArgs) Handles TestTodayOKLabel.Click

    End Sub

    Private Sub Date_testDate_TextChanged(sender As Object, e As EventArgs) Handles Date_testDate.TextChanged

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub ExcelDialog_FileOk(sender As Object, e As CancelEventArgs) Handles ExcelDialog.FileOk

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ComboBoxBRModTester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBRModTester.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub RichTextBox2_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox2.TextChanged

    End Sub

    Private Sub ComboBoxCOMModTester_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCOMModTester.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxRWO_Id_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxRWO_Id.SelectedIndexChanged, ComboBoxRWO_Id.KeyDown

    End Sub

    Private Sub ComboBoxOpName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxOpName.SelectedIndexChanged

    End Sub

    Private Sub ComboBoxBadgeId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxBadgeId.SelectedIndexChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

    End Sub

    Private Sub PanelCOM_Paint(sender As Object, e As PaintEventArgs) Handles PanelCOM.Paint

    End Sub



    Sub coloring_datagrid2()
        Dim rowindex2 As Long

        For Each dgr2 As DataGridViewRow In DataGridView2.Rows



            If dgr2.Cells("FINAL FCT").Value = "PASS" And dgr2.Cells("FINAL FIRMWARE CHECK").Value = "MATCH" Then
                rowindex2 = dgr2.Cells("FINAL FCT").RowIndex
                DataGridView2.Rows(rowindex2).DefaultCellStyle.BackColor = Color.LightGreen 'ok
                'ComboBoxModelPN.Items.Add(dgr.Cells("ModelPN").Value)
            End If

            'dgr.Cells("ModelPN").Value = ComboBoxModelPN.Text
            If dgr2.Cells("FINAL FCT").Value = "FAIL" Or dgr2.Cells("FINAL FIRMWARE CHECK").Value = "NOT MATCH" Or
                    dgr2.Cells("FINAL FCT").Value = "" Or dgr2.Cells("FINAL FIRMWARE CHECK").Value = "" Then
                rowindex2 = dgr2.Cells("FINAL FCT").RowIndex
                DataGridView2.Rows(rowindex2).DefaultCellStyle.BackColor = Color.LightGray 'ok
                'ComboBoxModelPN.Items.Add(dgr.Cells("ModelPN").Value)
            End If


            If dgr2.Cells("Model/Build Number").Value = "" Or dgr2.Cells("RWO Id").Value = "" Then
                rowindex2 = dgr2.Cells("Model/Build Number").RowIndex
                DataGridView2.Rows(rowindex2).DefaultCellStyle.BackColor = Color.White 'ok
                'ComboBoxModelPN.Items.Add(dgr.Cells("ModelPN").Value)
                'DataGridView2.Rows.RemoveAt(rowindex2)
            End If

        Next
    End Sub
    Sub sql2datagrid2()
        'export table SQL to datagrid
        Dim cmd_show As String = "SELECT * FROM [Console_Manager].[dbo].[Tbl_Console_Manager]"
        Dim adapter As New SqlDataAdapter(cmd_show, conn)
        Dim tabeluser As New DataTable
        adapter.Fill(tabeluser)
        DataGridView2.DataSource = tabeluser

        With DataGridView2.ColumnHeadersDefaultCellStyle
            .BackColor = Color.LightGray
            .ForeColor = Color.White
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(DataGridView1.Font, FontStyle.Bold)
        End With

        DataGridView2.AllowUserToAddRows = False
        DataGridView2.Refresh()
        'DataGridView2.AutoResizeColumns()



        Exit Sub
        'DataGridViewTextBoxColumn idColumn = New DataGridViewTextBoxColumn()
        'idColumn.HeaderText = "ID"
        'idColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        'idColumn.Resizable = DataGridViewTriState.False
        'idColumn.ReadOnly = True
        'idColumn.Width = 20

        Exit Sub
        'DataGridView2.AutoSizeColumnsMode = ColumnHeader

        'DataGridView2.AutoResizeRowHeadersWidth()

        Dim col As DataGridViewTextBoxColumn = New DataGridViewTextBoxColumn()
        col.HeaderText = "LOG_FILE"
        col.Width = 50

        'DataGridViewRow Row = DataGridView.Rows[0]
        'DataGridView2.Rows(49).Height = 50
        DataGridView2.Columns(47).Width = 5
        DataGridView2.Columns(48).Width = 5
        DataGridView2.Columns(49).Width = 5
        DataGridView2.Columns(50).Width = 5
        DataGridView2.Columns.Item("LOG_FILE").Width = 5
        DataGridView2.Columns.Item("XML_FILE").Width = 5
        DataGridView2.Columns.Item("IMAGE_FILE").Width = 5

    End Sub


    Function GetValueOpName(row As Integer, col As Integer) As String 'update_
        'https://stackoverflow.com/questions/62584487/reading-a-specific-value-in-a-cell-in-a-csv-file-in-vb-net
        Dim csvPath = "D:/SIERRA_TEST/Data/OperatorName.csv"
        Dim result As String = String.Empty
        Dim lines = File.ReadAllLines(csvPath)
        If row < lines.Length Then
            Dim cols = lines(row).Split(","c)
            If col < cols.Length Then
                result = cols(col)
            End If
        End If
        Return result
    End Function
    Private Sub ComboBoxBadgeID_SelectedIndexChanged(sender As Object, e As KeyEventArgs) Handles ComboBoxBadgeId.KeyDown 'update_
        If e.KeyCode = Keys.Enter Then
            Dim writer4 As New StreamWriter("D:\SIERRA_TEST\Data\BadgeID.txt")
            ComboBoxBadgeId.Text = ComboBoxBadgeId.Text.ToUpper()
            writer4.WriteLine(ComboBoxBadgeId.Text)
            writer4.Close()
            'Form50000792_01.OperatorBadgeIDTextBox.Text = ComboBoxBadgeID.Text

            For row_ = 1 To File.ReadAllLines("D:\SIERRA_TEST\Data\OperatorName.csv").Count


                If GetValueOpName(row_, 0) = ComboBoxBadgeId.Text Then 'untuk combo gunakan text bukan SelectedItem 
                    'MsgBox("found it")
                    'Build_Num_val_ref = GetValue(row_, 1)
                    ComboBoxOpName.Text = GetValueOpName(row_, 1)

                    Dim writer3 As New StreamWriter("D:\SIERRA_TEST\Data\Operator_Name.txt")
                    ComboBoxOpName.Text = ComboBoxOpName.Text.ToUpper()
                    writer3.WriteLine(ComboBoxOpName.Text)
                    writer3.Close()
                    'Form50000792_01.Operator_testTextBox.Text = ComboBoxOpName.Text

                End If
            Next
        End If
    End Sub
End Class
