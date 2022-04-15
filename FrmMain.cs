using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using System.Text;
using System.IO.Ports;
using System.Text.RegularExpressions;
using OfficeOpenXml;
//using Excel = Microsoft.Office.Interop.Excel;


namespace TVNConfigSW
{
    public partial class FrmMain : Form
    {
        #region '"Windows Form Designer generated code "'
        public FrmMain()
        //: base()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }
        // Form overrides dispose to clean up the component list.
        protected override void Dispose(bool Disposing1)
        {
            if (Disposing1)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(Disposing1);
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel labelConnectingStatus;
        private ToolStripStatusLabel labelFirmwareUpdateProcess;
        private ToolStripProgressBar progressBarFirmwareUpdate;
        private Label label19;
        private TextBox textBoxDeviceErrorMessage;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private SplitContainer splitContainer8;
        private SplitContainer splitContainer11;
        private SplitContainer splitContainer12;
        private Button buttonRebootToDFUMode;
        private SplitContainer splitContainer13;
        private SplitContainer splitContainer14;
        private GroupBox groupBox1;
        private Button buttonOpenBinaryFWFile;
        private TextBox textBoxFirmwareFilePath;
        private System.IO.Ports.SerialPort serialPort;
        private ListBox listBoxFirmwareUpdateLog;
        private System.Windows.Forms.Timer timerSerialPortRxDataParsing;
        private ImageList imageListTabControlLabel;
        private TextBox textBoxGprsMessage;
        private TextBox textBoxGpsMessage;
        private Label label2;
        private TabPage tabPage7;
        private Label label15;
        private TextBox txbPacketParserOutput;
        private Label label13;
        private Button btnParsePacket;
        private TextBox txbPacketHexStringInput;
        private NotifyIcon notifyIcon1;
        private TabPage tabPage1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer4;
        private Button buttonRefreshComPortList;
        private Button buttonOpenComPort;
        private ComboBox comboBoxComPortBaudRate;
        private ComboBox comboBoxComPortList;
        private Label label21;
        private Label label20;
        private SplitContainer splitContainer5;
        private SplitContainer splitContainer9;
        private Button buttonTvn05;
        private Button buttonTvn02;
        private Button buttonDefault;
        private Button buttonDeleteFlash;
        private Button buttonWriteSettingToDevice;
        private TextBox textBoxCommandList;
        private TextBox textBoxBootloader;
        private Label label11;
        private Label label1;
        private TextBox textBoxFwRev;
        private Label label41;
        private TextBox textBoxCCID1;
        private TextBox textBoxFirmwareFilePath1;
        private Button buttonRebootToDFUMode2;
        private Button buttonOpenFWFile;
        private GroupBox groupBox5;
        private ListBox listBoxFirmwareUpdateLog1;
        private Label label4;
        private TextBox textBoxImei;
        private SplitContainer splitContainer2;
        private SplitContainer splitContainer7;
        private GroupBox groupBoxLogs;
        private TextBox textBoxTempC;
        private TextBox textBoxVbat;
        private Label label40;
        private TextBox textBoxIO;
        private Label label10;
        private TextBox textBoxADB;
        private TextBox textBoxTempB;
        private TextBox textBoxADA;
        private TextBox textBoxPos;
        private Label label9;
        private TextBox textBoxTempA;
        private TextBox textBoxTime;
        private TextBox textBoxPower;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private GroupBox gprs4gStartus;
        private TextBox textBoxGprsMessage1;
        private SplitContainer splitContainer3;
        private TextBox textBoxDeviceLogs;
        private CheckBox checkBoxDisplayGpsSentence;
        private CheckBox checkBoxAutoScrollDeviceLogs;
        private Button buttonClearLogs;
        private Button buttonClear1;
        private Splitter splitter1;
        private TabControl tabConvert;
        private CheckBox CheckboxUpdate;
        private Button buttonExportTXT;
        private Button buttonAddData;
        private Button buttonSaveData;
        private Button buttonWriteLogs;
        private Button buttonReset;
        private TextBox textGPSstartus;
        private TextBox textBoxTempD;
        private SplitContainer splitContainer15;
        private SplitContainer splitContainer16;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private CheckBox checkBoxGPRS4Glogs;
        private CheckBox checkBoxErrorLog;
        private GroupBox groupBox4;
        private Button buttonTvnTest;
        private GroupBox groupBox13;
        private TextBox textBoxErrorLog;
        private RadioButton radioButton1;
        private TabPage tabPage8;
        private PageSetupDialog pageSetupDialog1;
        private PageSetupDialog pageSetupDialog2;
        private SplitContainer splitContainer6;
        private TextBox textBoxBootloaderdata;
        private TextBox textBoxImeidevice;
        private Label label12;
        private TextBox textBoxCCIDSim;
        private Label label14;
        private Label label16;
        private TextBox textBoxFWVer;
        private Label label17;
        private TextBox textBoxHR2;
        private TextBox textBoxHR1;
        private TextBox textBoxVbat1;
        private Label label18;
        private TextBox textBoxIO1;
        private Label label22;
        private TextBox textBoxADB1;
        private TextBox textBoxTempB1;
        private TextBox textBoxADA1;
        private TextBox textBoxCSQ1;
        private Label label23;
        private TextBox textBoxTempA1;
        private TextBox textBoxTimeDatalog;
        private TextBox textBoxPW1;
        private Label label24;
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private SplitContainer splitContainer10;
        private GroupBox groupBox6;
        private Label label29;
        private GroupBox Function;
        private GroupBox groupBox7;
        private DataGridView dataGridViewLogs;
        private Button button5;
        private Button button3;
        private Button button2;
        private Button button1;
        private TabPage tabPage9;
        private SplitContainer splitContainer17;
        private GroupBox groupBox8;
        private TextBox textBoxLogsData;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label48;
        private TextBox textBoxDriverID;
        private TextBox textBoxDriverIDLength;
        private TextBox textBoxDrive10h;
        private TextBox textBoxDriver4h;
        private TextBox textBoxDriverDataLength;
        private TextBox textBoxSpeedLength;
        private TextBox textBoxSpeedData;
        private TextBox textBoxKMperDay;
        private TextBox textBoxADBData;
        private TextBox textBoxADAData;
        private TextBox textBoxIOStatus;
        private TextBox textBoxPowerSupply;
        private TextBox textBoxTerminalStatus;
        private TextBox textBoxEventID;
        private TextBox textBoxStatusLength;
        private Label label49;
        private Label label50;
        private Label label52;
        private Label label53;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label58;
        private Label label59;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label36;
        private Label label38;
        private Label label39;
        private TextBox textBoxEVPError;
        private TextBox textBoxEHPError;
        private TextBox textBoxGpsStatus;
        private TextBox textBoxGpsSpeed;
        private TextBox textBoxGpsTime;
        private TextBox textBoxLong;
        private TextBox textBoxAlt;
        private TextBox textBoxLat;
        private TextBox textBoxGPSLength;
        private TextBox textBoxFrame;
        private TextBox textBoxPacketSNum;
        private TextBox textBoxDeviceDTC;
        private TextBox textBoxImeiData;
        private TextBox textBoxProtocol;
        private TextBox textBoxLength;
        private Label label61;
        private Label label60;
        private Label label57;
        private Label label51;
        private Label label47;
        private Label label37;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label77;
        private TextBox textBoxEndMark;
        private Label label78;
        private TextBox textBoxChecksum;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Label label67;
        private TextBox textBoxSpareData;
        private TextBox textBoxSpareInfoLength;
        private TextBox textBoxWireData;
        private TextBox textBoxWireType;
        private TextBox textBoxWireInfoLength;
        private TextBox textBoxComType;
        private TextBox textBoxComData;
        private TextBox textBoxCOMInfoLength;
        private TextBox textBoxLAC;
        private TextBox textBoxCellID;
        private TextBox textBoxSatellite;
        private TextBox textBoxGPSRssi;
        private TextBox textBoxGSMRssi;
        private TextBox textBoxLBSInfoLength;
        private TextBox textBoxDriveName;
        private Label label68;
        private Label label69;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private Label label74;
        private Label label75;
        private Label label76;
        private TabPage tabPage6;

        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labelConnectingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelFirmwareUpdateProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarFirmwareUpdate = new System.Windows.Forms.ToolStripProgressBar();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxDeviceErrorMessage = new System.Windows.Forms.TextBox();
            this.imageListTabControlLabel = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxGprsMessage = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBoxGpsMessage = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.splitContainer11 = new System.Windows.Forms.SplitContainer();
            this.splitContainer12 = new System.Windows.Forms.SplitContainer();
            this.buttonRebootToDFUMode = new System.Windows.Forms.Button();
            this.splitContainer13 = new System.Windows.Forms.SplitContainer();
            this.splitContainer14 = new System.Windows.Forms.SplitContainer();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxFirmwareFilePath = new System.Windows.Forms.TextBox();
            this.buttonOpenBinaryFWFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxFirmwareUpdateLog = new System.Windows.Forms.ListBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.txbPacketParserOutput = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnParsePacket = new System.Windows.Forms.Button();
            this.txbPacketHexStringInput = new System.Windows.Forms.TextBox();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timerSerialPortRxDataParsing = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.buttonRefreshComPortList = new System.Windows.Forms.Button();
            this.buttonOpenComPort = new System.Windows.Forms.Button();
            this.comboBoxComPortBaudRate = new System.Windows.Forms.ComboBox();
            this.comboBoxComPortList = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxFwRev = new System.Windows.Forms.TextBox();
            this.textBoxImei = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCCID1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBootloader = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.textBoxCommandList = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonTvnTest = new System.Windows.Forms.Button();
            this.buttonExportTXT = new System.Windows.Forms.Button();
            this.buttonSaveData = new System.Windows.Forms.Button();
            this.buttonClear1 = new System.Windows.Forms.Button();
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.buttonAddData = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonWriteLogs = new System.Windows.Forms.Button();
            this.buttonDeleteFlash = new System.Windows.Forms.Button();
            this.buttonTvn05 = new System.Windows.Forms.Button();
            this.buttonTvn02 = new System.Windows.Forms.Button();
            this.groupBoxLogs = new System.Windows.Forms.GroupBox();
            this.textBoxTempD = new System.Windows.Forms.TextBox();
            this.textBoxTempC = new System.Windows.Forms.TextBox();
            this.textBoxVbat = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.textBoxIO = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxADB = new System.Windows.Forms.TextBox();
            this.textBoxTempB = new System.Windows.Forms.TextBox();
            this.textBoxADA = new System.Windows.Forms.TextBox();
            this.textBoxPos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxTempA = new System.Windows.Forms.TextBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxPower = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonRebootToDFUMode2 = new System.Windows.Forms.Button();
            this.buttonWriteSettingToDevice = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.splitContainer15 = new System.Windows.Forms.SplitContainer();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.textBoxErrorLog = new System.Windows.Forms.TextBox();
            this.gprs4gStartus = new System.Windows.Forms.GroupBox();
            this.textBoxGprsMessage1 = new System.Windows.Forms.TextBox();
            this.splitContainer16 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textGPSstartus = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBoxFirmwareUpdateLog1 = new System.Windows.Forms.ListBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.textBoxDeviceLogs = new System.Windows.Forms.TextBox();
            this.checkBoxGPRS4Glogs = new System.Windows.Forms.CheckBox();
            this.textBoxFirmwareFilePath1 = new System.Windows.Forms.TextBox();
            this.buttonOpenFWFile = new System.Windows.Forms.Button();
            this.checkBoxErrorLog = new System.Windows.Forms.CheckBox();
            this.CheckboxUpdate = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoScrollDeviceLogs = new System.Windows.Forms.CheckBox();
            this.checkBoxDisplayGpsSentence = new System.Windows.Forms.CheckBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.tabConvert = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.textBoxImeidevice = new System.Windows.Forms.TextBox();
            this.textBoxTempA1 = new System.Windows.Forms.TextBox();
            this.textBoxPW1 = new System.Windows.Forms.TextBox();
            this.textBoxHR2 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxTimeDatalog = new System.Windows.Forms.TextBox();
            this.textBoxHR1 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBoxFWVer = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxVbat1 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxCSQ1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.textBoxIO1 = new System.Windows.Forms.TextBox();
            this.textBoxADA1 = new System.Windows.Forms.TextBox();
            this.textBoxCCIDSim = new System.Windows.Forms.TextBox();
            this.textBoxBootloaderdata = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxTempB1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxADB1 = new System.Windows.Forms.TextBox();
            this.Function = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dataGridViewLogs = new System.Windows.Forms.DataGridView();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.splitContainer17 = new System.Windows.Forms.SplitContainer();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBoxLogsData = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.textBoxEndMark = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.textBoxChecksum = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.textBoxSpareData = new System.Windows.Forms.TextBox();
            this.textBoxSpareInfoLength = new System.Windows.Forms.TextBox();
            this.textBoxWireData = new System.Windows.Forms.TextBox();
            this.textBoxWireType = new System.Windows.Forms.TextBox();
            this.textBoxWireInfoLength = new System.Windows.Forms.TextBox();
            this.textBoxComType = new System.Windows.Forms.TextBox();
            this.textBoxComData = new System.Windows.Forms.TextBox();
            this.textBoxCOMInfoLength = new System.Windows.Forms.TextBox();
            this.textBoxLAC = new System.Windows.Forms.TextBox();
            this.textBoxCellID = new System.Windows.Forms.TextBox();
            this.textBoxSatellite = new System.Windows.Forms.TextBox();
            this.textBoxGPSRssi = new System.Windows.Forms.TextBox();
            this.textBoxGSMRssi = new System.Windows.Forms.TextBox();
            this.textBoxLBSInfoLength = new System.Windows.Forms.TextBox();
            this.textBoxDriveName = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.textBoxDriverID = new System.Windows.Forms.TextBox();
            this.textBoxDriverIDLength = new System.Windows.Forms.TextBox();
            this.textBoxDrive10h = new System.Windows.Forms.TextBox();
            this.textBoxDriver4h = new System.Windows.Forms.TextBox();
            this.textBoxDriverDataLength = new System.Windows.Forms.TextBox();
            this.textBoxSpeedLength = new System.Windows.Forms.TextBox();
            this.textBoxSpeedData = new System.Windows.Forms.TextBox();
            this.textBoxKMperDay = new System.Windows.Forms.TextBox();
            this.textBoxADBData = new System.Windows.Forms.TextBox();
            this.textBoxADAData = new System.Windows.Forms.TextBox();
            this.textBoxIOStatus = new System.Windows.Forms.TextBox();
            this.textBoxPowerSupply = new System.Windows.Forms.TextBox();
            this.textBoxTerminalStatus = new System.Windows.Forms.TextBox();
            this.textBoxEventID = new System.Windows.Forms.TextBox();
            this.textBoxStatusLength = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.textBoxEVPError = new System.Windows.Forms.TextBox();
            this.textBoxEHPError = new System.Windows.Forms.TextBox();
            this.textBoxGpsStatus = new System.Windows.Forms.TextBox();
            this.textBoxGpsSpeed = new System.Windows.Forms.TextBox();
            this.textBoxGpsTime = new System.Windows.Forms.TextBox();
            this.textBoxLong = new System.Windows.Forms.TextBox();
            this.textBoxAlt = new System.Windows.Forms.TextBox();
            this.textBoxLat = new System.Windows.Forms.TextBox();
            this.textBoxGPSLength = new System.Windows.Forms.TextBox();
            this.textBoxFrame = new System.Windows.Forms.TextBox();
            this.textBoxPacketSNum = new System.Windows.Forms.TextBox();
            this.textBoxDeviceDTC = new System.Windows.Forms.TextBox();
            this.textBoxImeiData = new System.Windows.Forms.TextBox();
            this.textBoxProtocol = new System.Windows.Forms.TextBox();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.pageSetupDialog2 = new System.Windows.Forms.PageSetupDialog();
            this.statusStrip.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).BeginInit();
            this.splitContainer11.Panel1.SuspendLayout();
            this.splitContainer11.Panel2.SuspendLayout();
            this.splitContainer11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).BeginInit();
            this.splitContainer12.Panel1.SuspendLayout();
            this.splitContainer12.Panel2.SuspendLayout();
            this.splitContainer12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).BeginInit();
            this.splitContainer13.Panel1.SuspendLayout();
            this.splitContainer13.Panel2.SuspendLayout();
            this.splitContainer13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer14)).BeginInit();
            this.splitContainer14.Panel1.SuspendLayout();
            this.splitContainer14.Panel2.SuspendLayout();
            this.splitContainer14.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBoxLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer15)).BeginInit();
            this.splitContainer15.Panel1.SuspendLayout();
            this.splitContainer15.Panel2.SuspendLayout();
            this.splitContainer15.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.gprs4gStartus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer16)).BeginInit();
            this.splitContainer16.Panel1.SuspendLayout();
            this.splitContainer16.Panel2.SuspendLayout();
            this.splitContainer16.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.SuspendLayout();
            this.tabConvert.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.Function.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).BeginInit();
            this.tabPage9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer17)).BeginInit();
            this.splitContainer17.Panel1.SuspendLayout();
            this.splitContainer17.Panel2.SuspendLayout();
            this.splitContainer17.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelConnectingStatus,
            this.labelFirmwareUpdateProcess,
            this.progressBarFirmwareUpdate});
            this.statusStrip.Location = new System.Drawing.Point(0, 866);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1435, 22);
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip1";
            // 
            // labelConnectingStatus
            // 
            this.labelConnectingStatus.Name = "labelConnectingStatus";
            this.labelConnectingStatus.Size = new System.Drawing.Size(79, 17);
            this.labelConnectingStatus.Text = "Disconnected";
            this.labelConnectingStatus.Click += new System.EventHandler(this.labelConnectingStatus_Click);
            // 
            // labelFirmwareUpdateProcess
            // 
            this.labelFirmwareUpdateProcess.Margin = new System.Windows.Forms.Padding(700, 3, 0, 2);
            this.labelFirmwareUpdateProcess.Name = "labelFirmwareUpdateProcess";
            this.labelFirmwareUpdateProcess.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelFirmwareUpdateProcess.Size = new System.Drawing.Size(146, 17);
            this.labelFirmwareUpdateProcess.Text = "Firmware Update Process: ";
            // 
            // progressBarFirmwareUpdate
            // 
            this.progressBarFirmwareUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBarFirmwareUpdate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBarFirmwareUpdate.Maximum = 0;
            this.progressBarFirmwareUpdate.Name = "progressBarFirmwareUpdate";
            this.progressBarFirmwareUpdate.RightToLeftLayout = true;
            this.progressBarFirmwareUpdate.Size = new System.Drawing.Size(200, 16);
            this.progressBarFirmwareUpdate.Step = 0;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "Device warning and error";
            // 
            // textBoxDeviceErrorMessage
            // 
            this.textBoxDeviceErrorMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDeviceErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDeviceErrorMessage.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeviceErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.textBoxDeviceErrorMessage.Location = new System.Drawing.Point(3, 3);
            this.textBoxDeviceErrorMessage.MaxLength = 0;
            this.textBoxDeviceErrorMessage.Multiline = true;
            this.textBoxDeviceErrorMessage.Name = "textBoxDeviceErrorMessage";
            this.textBoxDeviceErrorMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDeviceErrorMessage.Size = new System.Drawing.Size(1250, 595);
            this.textBoxDeviceErrorMessage.TabIndex = 33;
            // 
            // imageListTabControlLabel
            // 
            this.imageListTabControlLabel.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTabControlLabel.ImageStream")));
            this.imageListTabControlLabel.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTabControlLabel.Images.SetKeyName(0, "gps_PNG10.png");
            this.imageListTabControlLabel.Images.SetKeyName(1, "images.png");
            this.imageListTabControlLabel.Images.SetKeyName(2, "firmware_update__645152.png");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxDeviceErrorMessage);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.ImageIndex = 1;
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1256, 601);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Error Log";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBoxGprsMessage);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1256, 601);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "GPRS Status";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxGprsMessage
            // 
            this.textBoxGprsMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGprsMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxGprsMessage.ForeColor = System.Drawing.Color.Black;
            this.textBoxGprsMessage.Location = new System.Drawing.Point(3, 3);
            this.textBoxGprsMessage.MaxLength = 0;
            this.textBoxGprsMessage.Multiline = true;
            this.textBoxGprsMessage.Name = "textBoxGprsMessage";
            this.textBoxGprsMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxGprsMessage.Size = new System.Drawing.Size(1250, 595);
            this.textBoxGprsMessage.TabIndex = 34;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBoxGpsMessage);
            this.tabPage4.ImageIndex = 0;
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1256, 601);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "GPS Status";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBoxGpsMessage
            // 
            this.textBoxGpsMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGpsMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxGpsMessage.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGpsMessage.ForeColor = System.Drawing.Color.Black;
            this.textBoxGpsMessage.Location = new System.Drawing.Point(3, 3);
            this.textBoxGpsMessage.MaxLength = 0;
            this.textBoxGpsMessage.Multiline = true;
            this.textBoxGpsMessage.Name = "textBoxGpsMessage";
            this.textBoxGpsMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxGpsMessage.Size = new System.Drawing.Size(1250, 595);
            this.textBoxGpsMessage.TabIndex = 35;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1256, 601);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Edit Model";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.splitContainer11);
            this.tabPage6.ImageIndex = 2;
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1256, 601);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "FW Update";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // splitContainer11
            // 
            this.splitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer11.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer11.Location = new System.Drawing.Point(0, 0);
            this.splitContainer11.Name = "splitContainer11";
            this.splitContainer11.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer11.Panel1
            // 
            this.splitContainer11.Panel1.Controls.Add(this.splitContainer12);
            // 
            // splitContainer11.Panel2
            // 
            this.splitContainer11.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer11.Size = new System.Drawing.Size(1256, 601);
            this.splitContainer11.SplitterDistance = 53;
            this.splitContainer11.TabIndex = 0;
            // 
            // splitContainer12
            // 
            this.splitContainer12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer12.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer12.Location = new System.Drawing.Point(0, 0);
            this.splitContainer12.Name = "splitContainer12";
            // 
            // splitContainer12.Panel1
            // 
            this.splitContainer12.Panel1.Controls.Add(this.buttonRebootToDFUMode);
            // 
            // splitContainer12.Panel2
            // 
            this.splitContainer12.Panel2.Controls.Add(this.splitContainer13);
            this.splitContainer12.Size = new System.Drawing.Size(1256, 53);
            this.splitContainer12.SplitterDistance = 216;
            this.splitContainer12.TabIndex = 0;
            // 
            // buttonRebootToDFUMode
            // 
            this.buttonRebootToDFUMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRebootToDFUMode.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRebootToDFUMode.Location = new System.Drawing.Point(0, 0);
            this.buttonRebootToDFUMode.Name = "buttonRebootToDFUMode";
            this.buttonRebootToDFUMode.Size = new System.Drawing.Size(216, 53);
            this.buttonRebootToDFUMode.TabIndex = 20;
            this.buttonRebootToDFUMode.Text = "Start Update";
            this.buttonRebootToDFUMode.UseVisualStyleBackColor = true;
            this.buttonRebootToDFUMode.Click += new System.EventHandler(this.buttonRebootToBootloaderMode_Click);
            // 
            // splitContainer13
            // 
            this.splitContainer13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer13.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer13.Location = new System.Drawing.Point(0, 0);
            this.splitContainer13.Name = "splitContainer13";
            // 
            // splitContainer13.Panel1
            // 
            this.splitContainer13.Panel1.Controls.Add(this.splitContainer14);
            // 
            // splitContainer13.Panel2
            // 
            this.splitContainer13.Panel2.Controls.Add(this.buttonOpenBinaryFWFile);
            this.splitContainer13.Size = new System.Drawing.Size(1036, 53);
            this.splitContainer13.SplitterDistance = 882;
            this.splitContainer13.TabIndex = 0;
            // 
            // splitContainer14
            // 
            this.splitContainer14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer14.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer14.Location = new System.Drawing.Point(0, 0);
            this.splitContainer14.Name = "splitContainer14";
            // 
            // splitContainer14.Panel1
            // 
            this.splitContainer14.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer14.Panel2
            // 
            this.splitContainer14.Panel2.Controls.Add(this.textBoxFirmwareFilePath);
            this.splitContainer14.Size = new System.Drawing.Size(882, 53);
            this.splitContainer14.SplitterDistance = 86;
            this.splitContainer14.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 46);
            this.label2.TabIndex = 0;
            this.label2.Text = "File\r\nname:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxFirmwareFilePath
            // 
            this.textBoxFirmwareFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFirmwareFilePath.Location = new System.Drawing.Point(0, 0);
            this.textBoxFirmwareFilePath.Multiline = true;
            this.textBoxFirmwareFilePath.Name = "textBoxFirmwareFilePath";
            this.textBoxFirmwareFilePath.Size = new System.Drawing.Size(792, 53);
            this.textBoxFirmwareFilePath.TabIndex = 0;
            // 
            // buttonOpenBinaryFWFile
            // 
            this.buttonOpenBinaryFWFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenBinaryFWFile.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenBinaryFWFile.Location = new System.Drawing.Point(0, 0);
            this.buttonOpenBinaryFWFile.Name = "buttonOpenBinaryFWFile";
            this.buttonOpenBinaryFWFile.Size = new System.Drawing.Size(150, 53);
            this.buttonOpenBinaryFWFile.TabIndex = 0;
            this.buttonOpenBinaryFWFile.Text = "Open File";
            this.buttonOpenBinaryFWFile.UseVisualStyleBackColor = true;
            this.buttonOpenBinaryFWFile.Click += new System.EventHandler(this.buttonOpenBinaryFWFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxFirmwareUpdateLog);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1256, 544);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bootloader logs";
            // 
            // listBoxFirmwareUpdateLog
            // 
            this.listBoxFirmwareUpdateLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFirmwareUpdateLog.FormattingEnabled = true;
            this.listBoxFirmwareUpdateLog.Location = new System.Drawing.Point(3, 16);
            this.listBoxFirmwareUpdateLog.Name = "listBoxFirmwareUpdateLog";
            this.listBoxFirmwareUpdateLog.Size = new System.Drawing.Size(1250, 525);
            this.listBoxFirmwareUpdateLog.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(0, 0);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(200, 100);
            this.tabPage7.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.label15.TabIndex = 0;
            // 
            // txbPacketParserOutput
            // 
            this.txbPacketParserOutput.Location = new System.Drawing.Point(0, 0);
            this.txbPacketParserOutput.Name = "txbPacketParserOutput";
            this.txbPacketParserOutput.Size = new System.Drawing.Size(100, 20);
            this.txbPacketParserOutput.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.label13.TabIndex = 0;
            // 
            // btnParsePacket
            // 
            this.btnParsePacket.Location = new System.Drawing.Point(0, 0);
            this.btnParsePacket.Name = "btnParsePacket";
            this.btnParsePacket.Size = new System.Drawing.Size(75, 23);
            this.btnParsePacket.TabIndex = 0;
            // 
            // txbPacketHexStringInput
            // 
            this.txbPacketHexStringInput.Location = new System.Drawing.Point(0, 0);
            this.txbPacketHexStringInput.Name = "txbPacketHexStringInput";
            this.txbPacketHexStringInput.Size = new System.Drawing.Size(100, 20);
            this.txbPacketHexStringInput.TabIndex = 0;
            // 
            // splitContainer8
            // 
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            this.splitContainer8.Size = new System.Drawing.Size(639, 166);
            this.splitContainer8.SplitterDistance = 560;
            this.splitContainer8.TabIndex = 0;
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // timerSerialPortRxDataParsing
            // 
            this.timerSerialPortRxDataParsing.Interval = 10;
            this.timerSerialPortRxDataParsing.Tick += new System.EventHandler(this.timerSerialPortDataHandler_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1427, 828);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Device Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer4);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(1421, 822);
            this.splitContainer1.SplitterDistance = 221;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.buttonRefreshComPortList);
            this.splitContainer4.Panel1.Controls.Add(this.buttonOpenComPort);
            this.splitContainer4.Panel1.Controls.Add(this.comboBoxComPortBaudRate);
            this.splitContainer4.Panel1.Controls.Add(this.comboBoxComPortList);
            this.splitContainer4.Panel1.Controls.Add(this.label21);
            this.splitContainer4.Panel1.Controls.Add(this.label20);
            this.splitContainer4.Panel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer4.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer4.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer4.Size = new System.Drawing.Size(221, 822);
            this.splitContainer4.SplitterDistance = 61;
            this.splitContainer4.TabIndex = 0;
            // 
            // buttonRefreshComPortList
            // 
            this.buttonRefreshComPortList.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefreshComPortList.Location = new System.Drawing.Point(141, 33);
            this.buttonRefreshComPortList.Name = "buttonRefreshComPortList";
            this.buttonRefreshComPortList.Size = new System.Drawing.Size(66, 23);
            this.buttonRefreshComPortList.TabIndex = 5;
            this.buttonRefreshComPortList.Text = "Refresh";
            this.buttonRefreshComPortList.UseVisualStyleBackColor = true;
            this.buttonRefreshComPortList.Click += new System.EventHandler(this.buttonRefreshComPortList_Click);
            // 
            // buttonOpenComPort
            // 
            this.buttonOpenComPort.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenComPort.Location = new System.Drawing.Point(141, 7);
            this.buttonOpenComPort.Name = "buttonOpenComPort";
            this.buttonOpenComPort.Size = new System.Drawing.Size(67, 23);
            this.buttonOpenComPort.TabIndex = 4;
            this.buttonOpenComPort.Text = "Open";
            this.buttonOpenComPort.UseVisualStyleBackColor = true;
            this.buttonOpenComPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // comboBoxComPortBaudRate
            // 
            this.comboBoxComPortBaudRate.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxComPortBaudRate.FormattingEnabled = true;
            this.comboBoxComPortBaudRate.Items.AddRange(new object[] {
            "115200",
            "4800",
            "57600",
            "9600"});
            this.comboBoxComPortBaudRate.Location = new System.Drawing.Point(55, 33);
            this.comboBoxComPortBaudRate.Name = "comboBoxComPortBaudRate";
            this.comboBoxComPortBaudRate.Size = new System.Drawing.Size(80, 24);
            this.comboBoxComPortBaudRate.TabIndex = 3;
            // 
            // comboBoxComPortList
            // 
            this.comboBoxComPortList.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxComPortList.FormattingEnabled = true;
            this.comboBoxComPortList.Location = new System.Drawing.Point(55, 7);
            this.comboBoxComPortList.Name = "comboBoxComPortList";
            this.comboBoxComPortList.Size = new System.Drawing.Size(80, 24);
            this.comboBoxComPortList.TabIndex = 2;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(6, 37);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 16);
            this.label21.TabIndex = 1;
            this.label21.Text = "Baud:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 11);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(38, 16);
            this.label20.TabIndex = 0;
            this.label20.Text = "Port:";
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            this.splitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer5.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.AutoScroll = true;
            this.splitContainer5.Panel2.Controls.Add(this.textBoxCommandList);
            this.splitContainer5.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer5.Panel2.Controls.Add(this.groupBoxLogs);
            this.splitContainer5.Panel2.Controls.Add(this.buttonRebootToDFUMode2);
            this.splitContainer5.Panel2.Controls.Add(this.buttonWriteSettingToDevice);
            this.splitContainer5.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer5.Size = new System.Drawing.Size(221, 757);
            this.splitContainer5.SplitterDistance = 118;
            this.splitContainer5.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxFwRev);
            this.groupBox4.Controls.Add(this.textBoxImei);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.textBoxCCID1);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.textBoxBootloader);
            this.groupBox4.Controls.Add(this.label41);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(221, 118);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Config Info";
            // 
            // textBoxFwRev
            // 
            this.textBoxFwRev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFwRev.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFwRev.Location = new System.Drawing.Point(145, 25);
            this.textBoxFwRev.Name = "textBoxFwRev";
            this.textBoxFwRev.Size = new System.Drawing.Size(69, 22);
            this.textBoxFwRev.TabIndex = 1;
            // 
            // textBoxImei
            // 
            this.textBoxImei.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxImei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxImei.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImei.Location = new System.Drawing.Point(48, 52);
            this.textBoxImei.Name = "textBoxImei";
            this.textBoxImei.ReadOnly = true;
            this.textBoxImei.Size = new System.Drawing.Size(165, 22);
            this.textBoxImei.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "IMEI:";
            // 
            // textBoxCCID1
            // 
            this.textBoxCCID1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxCCID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCCID1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCCID1.Location = new System.Drawing.Point(48, 80);
            this.textBoxCCID1.Name = "textBoxCCID1";
            this.textBoxCCID1.ReadOnly = true;
            this.textBoxCCID1.Size = new System.Drawing.Size(165, 22);
            this.textBoxCCID1.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 16);
            this.label11.TabIndex = 37;
            this.label11.Text = "Blder:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "FW:";
            // 
            // textBoxBootloader
            // 
            this.textBoxBootloader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBootloader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBootloader.Location = new System.Drawing.Point(48, 25);
            this.textBoxBootloader.Name = "textBoxBootloader";
            this.textBoxBootloader.Size = new System.Drawing.Size(50, 22);
            this.textBoxBootloader.TabIndex = 38;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(4, 83);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(43, 16);
            this.label41.TabIndex = 7;
            this.label41.Text = "CCID:";
            // 
            // textBoxCommandList
            // 
            this.textBoxCommandList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCommandList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCommandList.ForeColor = System.Drawing.Color.Blue;
            this.textBoxCommandList.Location = new System.Drawing.Point(1, 338);
            this.textBoxCommandList.Multiline = true;
            this.textBoxCommandList.Name = "textBoxCommandList";
            this.textBoxCommandList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCommandList.Size = new System.Drawing.Size(215, 45);
            this.textBoxCommandList.TabIndex = 1;
            this.textBoxCommandList.Text = "*300190,990,099#";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.buttonTvnTest);
            this.groupBox3.Controls.Add(this.buttonExportTXT);
            this.groupBox3.Controls.Add(this.buttonSaveData);
            this.groupBox3.Controls.Add(this.buttonClear1);
            this.groupBox3.Controls.Add(this.buttonClearLogs);
            this.groupBox3.Controls.Add(this.buttonAddData);
            this.groupBox3.Controls.Add(this.buttonDefault);
            this.groupBox3.Controls.Add(this.buttonReset);
            this.groupBox3.Controls.Add(this.buttonWriteLogs);
            this.groupBox3.Controls.Add(this.buttonDeleteFlash);
            this.groupBox3.Controls.Add(this.buttonTvn05);
            this.groupBox3.Controls.Add(this.buttonTvn02);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(-1, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 167);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Config Button";
            // 
            // buttonTvnTest
            // 
            this.buttonTvnTest.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTvnTest.Location = new System.Drawing.Point(144, 46);
            this.buttonTvnTest.Margin = new System.Windows.Forms.Padding(5);
            this.buttonTvnTest.Name = "buttonTvnTest";
            this.buttonTvnTest.Padding = new System.Windows.Forms.Padding(1);
            this.buttonTvnTest.Size = new System.Drawing.Size(73, 22);
            this.buttonTvnTest.TabIndex = 39;
            this.buttonTvnTest.Text = "TVNTest";
            this.buttonTvnTest.UseVisualStyleBackColor = true;
            this.buttonTvnTest.Click += new System.EventHandler(this.buttonTvnTest_Click);
            // 
            // buttonExportTXT
            // 
            this.buttonExportTXT.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportTXT.Location = new System.Drawing.Point(3, 74);
            this.buttonExportTXT.Margin = new System.Windows.Forms.Padding(5);
            this.buttonExportTXT.Name = "buttonExportTXT";
            this.buttonExportTXT.Padding = new System.Windows.Forms.Padding(1);
            this.buttonExportTXT.Size = new System.Drawing.Size(100, 25);
            this.buttonExportTXT.TabIndex = 29;
            this.buttonExportTXT.Text = "Export Logs";
            this.buttonExportTXT.UseVisualStyleBackColor = true;
            this.buttonExportTXT.Click += new System.EventHandler(this.buttonExportTXT_Click);
            // 
            // buttonSaveData
            // 
            this.buttonSaveData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveData.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveData.Location = new System.Drawing.Point(124, 136);
            this.buttonSaveData.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSaveData.Name = "buttonSaveData";
            this.buttonSaveData.Padding = new System.Windows.Forms.Padding(1);
            this.buttonSaveData.Size = new System.Drawing.Size(94, 23);
            this.buttonSaveData.TabIndex = 19;
            this.buttonSaveData.Text = "Save Data";
            this.buttonSaveData.UseVisualStyleBackColor = true;
            this.buttonSaveData.Click += new System.EventHandler(this.buttonExImei_Click);
            // 
            // buttonClear1
            // 
            this.buttonClear1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear1.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear1.Location = new System.Drawing.Point(124, 105);
            this.buttonClear1.Margin = new System.Windows.Forms.Padding(5);
            this.buttonClear1.Name = "buttonClear1";
            this.buttonClear1.Padding = new System.Windows.Forms.Padding(1);
            this.buttonClear1.Size = new System.Drawing.Size(94, 25);
            this.buttonClear1.TabIndex = 26;
            this.buttonClear1.Text = "Clear All";
            this.buttonClear1.UseVisualStyleBackColor = true;
            this.buttonClear1.Click += new System.EventHandler(this.buttonClear1_Click);
            // 
            // buttonClearLogs
            // 
            this.buttonClearLogs.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearLogs.Location = new System.Drawing.Point(3, 105);
            this.buttonClearLogs.Margin = new System.Windows.Forms.Padding(5);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Padding = new System.Windows.Forms.Padding(1);
            this.buttonClearLogs.Size = new System.Drawing.Size(99, 25);
            this.buttonClearLogs.TabIndex = 27;
            this.buttonClearLogs.Text = "Clear Logs";
            this.buttonClearLogs.UseVisualStyleBackColor = true;
            this.buttonClearLogs.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // buttonAddData
            // 
            this.buttonAddData.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddData.Location = new System.Drawing.Point(3, 136);
            this.buttonAddData.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAddData.Name = "buttonAddData";
            this.buttonAddData.Padding = new System.Windows.Forms.Padding(1);
            this.buttonAddData.Size = new System.Drawing.Size(99, 23);
            this.buttonAddData.TabIndex = 20;
            this.buttonAddData.Text = "Ex to Data";
            this.buttonAddData.UseVisualStyleBackColor = true;
            this.buttonAddData.Click += new System.EventHandler(this.buttonAddData_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonDefault.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDefault.Location = new System.Drawing.Point(3, 21);
            this.buttonDefault.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Padding = new System.Windows.Forms.Padding(1);
            this.buttonDefault.Size = new System.Drawing.Size(73, 21);
            this.buttonDefault.TabIndex = 26;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(77, 21);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(5);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Padding = new System.Windows.Forms.Padding(1);
            this.buttonReset.Size = new System.Drawing.Size(67, 21);
            this.buttonReset.TabIndex = 38;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonWriteLogs
            // 
            this.buttonWriteLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWriteLogs.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWriteLogs.Location = new System.Drawing.Point(125, 74);
            this.buttonWriteLogs.Margin = new System.Windows.Forms.Padding(5);
            this.buttonWriteLogs.Name = "buttonWriteLogs";
            this.buttonWriteLogs.Padding = new System.Windows.Forms.Padding(1);
            this.buttonWriteLogs.Size = new System.Drawing.Size(94, 25);
            this.buttonWriteLogs.TabIndex = 24;
            this.buttonWriteLogs.Text = "EX IMEI";
            this.buttonWriteLogs.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteFlash
            // 
            this.buttonDeleteFlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteFlash.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonDeleteFlash.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteFlash.Location = new System.Drawing.Point(144, 21);
            this.buttonDeleteFlash.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDeleteFlash.Name = "buttonDeleteFlash";
            this.buttonDeleteFlash.Padding = new System.Windows.Forms.Padding(1);
            this.buttonDeleteFlash.Size = new System.Drawing.Size(73, 21);
            this.buttonDeleteFlash.TabIndex = 25;
            this.buttonDeleteFlash.Text = "Del flash";
            this.buttonDeleteFlash.UseVisualStyleBackColor = true;
            this.buttonDeleteFlash.Click += new System.EventHandler(this.buttonDeleteFlash_Click);
            // 
            // buttonTvn05
            // 
            this.buttonTvn05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTvn05.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTvn05.Location = new System.Drawing.Point(77, 46);
            this.buttonTvn05.Margin = new System.Windows.Forms.Padding(5);
            this.buttonTvn05.Name = "buttonTvn05";
            this.buttonTvn05.Padding = new System.Windows.Forms.Padding(1);
            this.buttonTvn05.Size = new System.Drawing.Size(67, 22);
            this.buttonTvn05.TabIndex = 36;
            this.buttonTvn05.Text = "TVN05";
            this.buttonTvn05.UseVisualStyleBackColor = true;
            this.buttonTvn05.Click += new System.EventHandler(this.buttonTvn05_Click);
            // 
            // buttonTvn02
            // 
            this.buttonTvn02.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTvn02.Location = new System.Drawing.Point(3, 46);
            this.buttonTvn02.Margin = new System.Windows.Forms.Padding(5);
            this.buttonTvn02.Name = "buttonTvn02";
            this.buttonTvn02.Padding = new System.Windows.Forms.Padding(1);
            this.buttonTvn02.Size = new System.Drawing.Size(73, 22);
            this.buttonTvn02.TabIndex = 1;
            this.buttonTvn02.Text = "TVN02";
            this.buttonTvn02.UseVisualStyleBackColor = true;
            this.buttonTvn02.Click += new System.EventHandler(this.buttonTvn02_Click);
            // 
            // groupBoxLogs
            // 
            this.groupBoxLogs.Controls.Add(this.textBoxTempD);
            this.groupBoxLogs.Controls.Add(this.textBoxTempC);
            this.groupBoxLogs.Controls.Add(this.textBoxVbat);
            this.groupBoxLogs.Controls.Add(this.label40);
            this.groupBoxLogs.Controls.Add(this.textBoxIO);
            this.groupBoxLogs.Controls.Add(this.label10);
            this.groupBoxLogs.Controls.Add(this.textBoxADB);
            this.groupBoxLogs.Controls.Add(this.textBoxTempB);
            this.groupBoxLogs.Controls.Add(this.textBoxADA);
            this.groupBoxLogs.Controls.Add(this.textBoxPos);
            this.groupBoxLogs.Controls.Add(this.label9);
            this.groupBoxLogs.Controls.Add(this.textBoxTempA);
            this.groupBoxLogs.Controls.Add(this.textBoxTime);
            this.groupBoxLogs.Controls.Add(this.textBoxPower);
            this.groupBoxLogs.Controls.Add(this.label8);
            this.groupBoxLogs.Controls.Add(this.label7);
            this.groupBoxLogs.Controls.Add(this.label6);
            this.groupBoxLogs.Controls.Add(this.label5);
            this.groupBoxLogs.Controls.Add(this.label3);
            this.groupBoxLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxLogs.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLogs.Name = "groupBoxLogs";
            this.groupBoxLogs.Size = new System.Drawing.Size(221, 165);
            this.groupBoxLogs.TabIndex = 0;
            this.groupBoxLogs.TabStop = false;
            this.groupBoxLogs.Text = "Signal Indicator";
            // 
            // textBoxTempD
            // 
            this.textBoxTempD.Location = new System.Drawing.Point(173, 125);
            this.textBoxTempD.Name = "textBoxTempD";
            this.textBoxTempD.Size = new System.Drawing.Size(38, 22);
            this.textBoxTempD.TabIndex = 27;
            // 
            // textBoxTempC
            // 
            this.textBoxTempC.Location = new System.Drawing.Point(91, 125);
            this.textBoxTempC.Name = "textBoxTempC";
            this.textBoxTempC.Size = new System.Drawing.Size(38, 22);
            this.textBoxTempC.TabIndex = 26;
            // 
            // textBoxVbat
            // 
            this.textBoxVbat.Location = new System.Drawing.Point(165, 74);
            this.textBoxVbat.Name = "textBoxVbat";
            this.textBoxVbat.Size = new System.Drawing.Size(46, 22);
            this.textBoxVbat.TabIndex = 25;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(117, 79);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(44, 16);
            this.label40.TabIndex = 24;
            this.label40.Text = "VBAT:";
            // 
            // textBoxIO
            // 
            this.textBoxIO.Location = new System.Drawing.Point(165, 18);
            this.textBoxIO.Name = "textBoxIO";
            this.textBoxIO.Size = new System.Drawing.Size(46, 22);
            this.textBoxIO.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(117, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "IO:";
            // 
            // textBoxADB
            // 
            this.textBoxADB.Location = new System.Drawing.Point(165, 46);
            this.textBoxADB.Name = "textBoxADB";
            this.textBoxADB.Size = new System.Drawing.Size(46, 22);
            this.textBoxADB.TabIndex = 21;
            // 
            // textBoxTempB
            // 
            this.textBoxTempB.Location = new System.Drawing.Point(135, 125);
            this.textBoxTempB.Name = "textBoxTempB";
            this.textBoxTempB.Size = new System.Drawing.Size(38, 22);
            this.textBoxTempB.TabIndex = 20;
            // 
            // textBoxADA
            // 
            this.textBoxADA.Location = new System.Drawing.Point(49, 47);
            this.textBoxADA.Name = "textBoxADA";
            this.textBoxADA.Size = new System.Drawing.Size(49, 22);
            this.textBoxADA.TabIndex = 18;
            // 
            // textBoxPos
            // 
            this.textBoxPos.Location = new System.Drawing.Point(50, 75);
            this.textBoxPos.Name = "textBoxPos";
            this.textBoxPos.Size = new System.Drawing.Size(48, 22);
            this.textBoxPos.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "CSQ:";
            // 
            // textBoxTempA
            // 
            this.textBoxTempA.Location = new System.Drawing.Point(50, 125);
            this.textBoxTempA.Name = "textBoxTempA";
            this.textBoxTempA.Size = new System.Drawing.Size(38, 22);
            this.textBoxTempA.TabIndex = 9;
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(50, 100);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(161, 22);
            this.textBoxTime.TabIndex = 8;
            // 
            // textBoxPower
            // 
            this.textBoxPower.Location = new System.Drawing.Point(50, 21);
            this.textBoxPower.Name = "textBoxPower";
            this.textBoxPower.Size = new System.Drawing.Size(48, 22);
            this.textBoxPower.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "TEMP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "ADB:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "ADA:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "TIME";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "PWR:";
            // 
            // buttonRebootToDFUMode2
            // 
            this.buttonRebootToDFUMode2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRebootToDFUMode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRebootToDFUMode2.Font = new System.Drawing.Font("Georgia", 12F);
            this.buttonRebootToDFUMode2.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonRebootToDFUMode2.ImageKey = "(none)";
            this.buttonRebootToDFUMode2.Location = new System.Drawing.Point(-3, 590);
            this.buttonRebootToDFUMode2.Name = "buttonRebootToDFUMode2";
            this.buttonRebootToDFUMode2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonRebootToDFUMode2.Size = new System.Drawing.Size(225, 48);
            this.buttonRebootToDFUMode2.TabIndex = 4;
            this.buttonRebootToDFUMode2.Text = "Start Update";
            this.buttonRebootToDFUMode2.UseVisualStyleBackColor = false;
            this.buttonRebootToDFUMode2.Click += new System.EventHandler(this.buttonRebootToBootloaderMode_Click);
            // 
            // buttonWriteSettingToDevice
            // 
            this.buttonWriteSettingToDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWriteSettingToDevice.Location = new System.Drawing.Point(3, 389);
            this.buttonWriteSettingToDevice.Name = "buttonWriteSettingToDevice";
            this.buttonWriteSettingToDevice.Size = new System.Drawing.Size(209, 26);
            this.buttonWriteSettingToDevice.TabIndex = 24;
            this.buttonWriteSettingToDevice.Text = "Write Setting To Device";
            this.buttonWriteSettingToDevice.UseVisualStyleBackColor = true;
            this.buttonWriteSettingToDevice.Click += new System.EventHandler(this.buttonWriteSettingToDevice_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer7);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Panel2.Controls.Add(this.splitter1);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer2.Size = new System.Drawing.Size(1196, 822);
            this.splitContainer2.SplitterDistance = 166;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.AutoScroll = true;
            this.splitContainer7.Panel1.Controls.Add(this.splitContainer15);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer16);
            this.splitContainer7.Size = new System.Drawing.Size(1196, 166);
            this.splitContainer7.SplitterDistance = 739;
            this.splitContainer7.TabIndex = 0;
            // 
            // splitContainer15
            // 
            this.splitContainer15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer15.Location = new System.Drawing.Point(0, 0);
            this.splitContainer15.Name = "splitContainer15";
            // 
            // splitContainer15.Panel1
            // 
            this.splitContainer15.Panel1.Controls.Add(this.groupBox13);
            // 
            // splitContainer15.Panel2
            // 
            this.splitContainer15.Panel2.Controls.Add(this.gprs4gStartus);
            this.splitContainer15.Size = new System.Drawing.Size(739, 166);
            this.splitContainer15.SplitterDistance = 385;
            this.splitContainer15.TabIndex = 0;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.textBoxErrorLog);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox13.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(0, 0);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(385, 166);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Error Logs";
            // 
            // textBoxErrorLog
            // 
            this.textBoxErrorLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxErrorLog.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxErrorLog.Location = new System.Drawing.Point(3, 18);
            this.textBoxErrorLog.Multiline = true;
            this.textBoxErrorLog.Name = "textBoxErrorLog";
            this.textBoxErrorLog.Size = new System.Drawing.Size(379, 145);
            this.textBoxErrorLog.TabIndex = 1;
            // 
            // gprs4gStartus
            // 
            this.gprs4gStartus.Controls.Add(this.textBoxGprsMessage1);
            this.gprs4gStartus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gprs4gStartus.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gprs4gStartus.Location = new System.Drawing.Point(0, 0);
            this.gprs4gStartus.Name = "gprs4gStartus";
            this.gprs4gStartus.Size = new System.Drawing.Size(350, 166);
            this.gprs4gStartus.TabIndex = 0;
            this.gprs4gStartus.TabStop = false;
            this.gprs4gStartus.Text = "GPRS - 4G Status";
            // 
            // textBoxGprsMessage1
            // 
            this.textBoxGprsMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxGprsMessage1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGprsMessage1.Location = new System.Drawing.Point(3, 18);
            this.textBoxGprsMessage1.Multiline = true;
            this.textBoxGprsMessage1.Name = "textBoxGprsMessage1";
            this.textBoxGprsMessage1.Size = new System.Drawing.Size(344, 145);
            this.textBoxGprsMessage1.TabIndex = 0;
            // 
            // splitContainer16
            // 
            this.splitContainer16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer16.Location = new System.Drawing.Point(0, 0);
            this.splitContainer16.Name = "splitContainer16";
            // 
            // splitContainer16.Panel1
            // 
            this.splitContainer16.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer16.Panel2
            // 
            this.splitContainer16.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer16.Size = new System.Drawing.Size(453, 166);
            this.splitContainer16.SplitterDistance = 257;
            this.splitContainer16.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textGPSstartus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 166);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GPS Logs";
            // 
            // textGPSstartus
            // 
            this.textGPSstartus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textGPSstartus.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGPSstartus.Location = new System.Drawing.Point(3, 18);
            this.textGPSstartus.Multiline = true;
            this.textGPSstartus.Name = "textGPSstartus";
            this.textGPSstartus.Size = new System.Drawing.Size(251, 145);
            this.textGPSstartus.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.listBoxFirmwareUpdateLog1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(192, 166);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Update log";
            // 
            // listBoxFirmwareUpdateLog1
            // 
            this.listBoxFirmwareUpdateLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFirmwareUpdateLog1.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold);
            this.listBoxFirmwareUpdateLog1.FormattingEnabled = true;
            this.listBoxFirmwareUpdateLog1.ItemHeight = 24;
            this.listBoxFirmwareUpdateLog1.Location = new System.Drawing.Point(3, 18);
            this.listBoxFirmwareUpdateLog1.Name = "listBoxFirmwareUpdateLog1";
            this.listBoxFirmwareUpdateLog1.Size = new System.Drawing.Size(186, 145);
            this.listBoxFirmwareUpdateLog1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(3, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.textBoxDeviceLogs);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.checkBoxGPRS4Glogs);
            this.splitContainer3.Panel2.Controls.Add(this.textBoxFirmwareFilePath1);
            this.splitContainer3.Panel2.Controls.Add(this.buttonOpenFWFile);
            this.splitContainer3.Panel2.Controls.Add(this.checkBoxErrorLog);
            this.splitContainer3.Panel2.Controls.Add(this.CheckboxUpdate);
            this.splitContainer3.Panel2.Controls.Add(this.checkBoxAutoScrollDeviceLogs);
            this.splitContainer3.Panel2.Controls.Add(this.checkBoxDisplayGpsSentence);
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer3.Size = new System.Drawing.Size(1193, 652);
            this.splitContainer3.SplitterDistance = 620;
            this.splitContainer3.TabIndex = 1;
            // 
            // textBoxDeviceLogs
            // 
            this.textBoxDeviceLogs.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxDeviceLogs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDeviceLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDeviceLogs.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeviceLogs.HideSelection = false;
            this.textBoxDeviceLogs.Location = new System.Drawing.Point(0, 0);
            this.textBoxDeviceLogs.MaxLength = 0;
            this.textBoxDeviceLogs.Multiline = true;
            this.textBoxDeviceLogs.Name = "textBoxDeviceLogs";
            this.textBoxDeviceLogs.ReadOnly = true;
            this.textBoxDeviceLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDeviceLogs.Size = new System.Drawing.Size(1193, 620);
            this.textBoxDeviceLogs.TabIndex = 18;
            // 
            // checkBoxGPRS4Glogs
            // 
            this.checkBoxGPRS4Glogs.AutoSize = true;
            this.checkBoxGPRS4Glogs.Checked = true;
            this.checkBoxGPRS4Glogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxGPRS4Glogs.Location = new System.Drawing.Point(312, 5);
            this.checkBoxGPRS4Glogs.Name = "checkBoxGPRS4Glogs";
            this.checkBoxGPRS4Glogs.Size = new System.Drawing.Size(116, 20);
            this.checkBoxGPRS4Glogs.TabIndex = 37;
            this.checkBoxGPRS4Glogs.Text = " GPRS-4G Logs";
            this.checkBoxGPRS4Glogs.UseVisualStyleBackColor = true;
            // 
            // textBoxFirmwareFilePath1
            // 
            this.textBoxFirmwareFilePath1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFirmwareFilePath1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirmwareFilePath1.Location = new System.Drawing.Point(849, 2);
            this.textBoxFirmwareFilePath1.Multiline = true;
            this.textBoxFirmwareFilePath1.Name = "textBoxFirmwareFilePath1";
            this.textBoxFirmwareFilePath1.Size = new System.Drawing.Size(252, 26);
            this.textBoxFirmwareFilePath1.TabIndex = 5;
            // 
            // buttonOpenFWFile
            // 
            this.buttonOpenFWFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenFWFile.AutoSize = true;
            this.buttonOpenFWFile.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenFWFile.Location = new System.Drawing.Point(1107, 2);
            this.buttonOpenFWFile.Name = "buttonOpenFWFile";
            this.buttonOpenFWFile.Size = new System.Drawing.Size(68, 25);
            this.buttonOpenFWFile.TabIndex = 3;
            this.buttonOpenFWFile.Text = "Open file";
            this.buttonOpenFWFile.UseVisualStyleBackColor = true;
            this.buttonOpenFWFile.Click += new System.EventHandler(this.buttonOpenBinaryFWFile_Click);
            // 
            // checkBoxErrorLog
            // 
            this.checkBoxErrorLog.AutoSize = true;
            this.checkBoxErrorLog.Checked = true;
            this.checkBoxErrorLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxErrorLog.Location = new System.Drawing.Point(434, 5);
            this.checkBoxErrorLog.Name = "checkBoxErrorLog";
            this.checkBoxErrorLog.Size = new System.Drawing.Size(92, 20);
            this.checkBoxErrorLog.TabIndex = 38;
            this.checkBoxErrorLog.Text = "Error Logs";
            this.checkBoxErrorLog.UseVisualStyleBackColor = true;
            // 
            // CheckboxUpdate
            // 
            this.CheckboxUpdate.AutoSize = true;
            this.CheckboxUpdate.Location = new System.Drawing.Point(9, 5);
            this.CheckboxUpdate.Name = "CheckboxUpdate";
            this.CheckboxUpdate.Size = new System.Drawing.Size(105, 20);
            this.CheckboxUpdate.TabIndex = 25;
            this.CheckboxUpdate.Text = "Auto Update";
            this.CheckboxUpdate.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoScrollDeviceLogs
            // 
            this.checkBoxAutoScrollDeviceLogs.AutoSize = true;
            this.checkBoxAutoScrollDeviceLogs.Checked = true;
            this.checkBoxAutoScrollDeviceLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoScrollDeviceLogs.Location = new System.Drawing.Point(120, 5);
            this.checkBoxAutoScrollDeviceLogs.Name = "checkBoxAutoScrollDeviceLogs";
            this.checkBoxAutoScrollDeviceLogs.Size = new System.Drawing.Size(95, 20);
            this.checkBoxAutoScrollDeviceLogs.TabIndex = 24;
            this.checkBoxAutoScrollDeviceLogs.Text = "Auto scroll";
            this.checkBoxAutoScrollDeviceLogs.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisplayGpsSentence
            // 
            this.checkBoxDisplayGpsSentence.AutoSize = true;
            this.checkBoxDisplayGpsSentence.Checked = true;
            this.checkBoxDisplayGpsSentence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisplayGpsSentence.Location = new System.Drawing.Point(221, 5);
            this.checkBoxDisplayGpsSentence.Name = "checkBoxDisplayGpsSentence";
            this.checkBoxDisplayGpsSentence.Size = new System.Drawing.Size(85, 20);
            this.checkBoxDisplayGpsSentence.TabIndex = 0;
            this.checkBoxDisplayGpsSentence.Text = " GPS Logs";
            this.checkBoxDisplayGpsSentence.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 652);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // splitContainer9
            // 
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer9.Location = new System.Drawing.Point(0, 0);
            this.splitContainer9.Name = "splitContainer9";
            this.splitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer9.Size = new System.Drawing.Size(150, 100);
            this.splitContainer9.TabIndex = 0;
            // 
            // tabConvert
            // 
            this.tabConvert.Controls.Add(this.tabPage1);
            this.tabConvert.Controls.Add(this.tabPage8);
            this.tabConvert.Controls.Add(this.tabPage9);
            this.tabConvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConvert.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabConvert.ImageList = this.imageListTabControlLabel;
            this.tabConvert.ItemSize = new System.Drawing.Size(200, 30);
            this.tabConvert.Location = new System.Drawing.Point(0, 0);
            this.tabConvert.Name = "tabConvert";
            this.tabConvert.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabConvert.SelectedIndex = 0;
            this.tabConvert.Size = new System.Drawing.Size(1435, 866);
            this.tabConvert.TabIndex = 35;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.splitContainer6);
            this.tabPage8.Location = new System.Drawing.Point(4, 34);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1427, 828);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Data list";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(3, 3);
            this.splitContainer6.Name = "splitContainer6";
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.splitContainer10);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.groupBox7);
            this.splitContainer6.Size = new System.Drawing.Size(1421, 822);
            this.splitContainer6.SplitterDistance = 299;
            this.splitContainer6.TabIndex = 0;
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.Location = new System.Drawing.Point(0, 0);
            this.splitContainer10.Name = "splitContainer10";
            this.splitContainer10.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.groupBox6);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.Function);
            this.splitContainer10.Size = new System.Drawing.Size(299, 822);
            this.splitContainer10.SplitterDistance = 366;
            this.splitContainer10.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.textBoxImeidevice);
            this.groupBox6.Controls.Add(this.textBoxTempA1);
            this.groupBox6.Controls.Add(this.textBoxPW1);
            this.groupBox6.Controls.Add(this.textBoxHR2);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.textBoxTimeDatalog);
            this.groupBox6.Controls.Add(this.textBoxHR1);
            this.groupBox6.Controls.Add(this.label25);
            this.groupBox6.Controls.Add(this.textBoxFWVer);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.textBoxVbat1);
            this.groupBox6.Controls.Add(this.label23);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.label18);
            this.groupBox6.Controls.Add(this.textBoxCSQ1);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.textBoxIO1);
            this.groupBox6.Controls.Add(this.textBoxADA1);
            this.groupBox6.Controls.Add(this.textBoxCCIDSim);
            this.groupBox6.Controls.Add(this.textBoxBootloaderdata);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.textBoxTempB1);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.textBoxADB1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(299, 366);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Data Logs";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(12, 206);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(66, 16);
            this.label29.TabIndex = 67;
            this.label29.Text = "Humidity";
            // 
            // textBoxImeidevice
            // 
            this.textBoxImeidevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxImeidevice.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxImeidevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxImeidevice.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImeidevice.Location = new System.Drawing.Point(126, 90);
            this.textBoxImeidevice.Name = "textBoxImeidevice";
            this.textBoxImeidevice.ReadOnly = true;
            this.textBoxImeidevice.Size = new System.Drawing.Size(154, 22);
            this.textBoxImeidevice.TabIndex = 66;
            // 
            // textBoxTempA1
            // 
            this.textBoxTempA1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTempA1.Location = new System.Drawing.Point(123, 174);
            this.textBoxTempA1.Name = "textBoxTempA1";
            this.textBoxTempA1.Size = new System.Drawing.Size(81, 22);
            this.textBoxTempA1.TabIndex = 54;
            // 
            // textBoxPW1
            // 
            this.textBoxPW1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPW1.Location = new System.Drawing.Point(81, 233);
            this.textBoxPW1.Name = "textBoxPW1";
            this.textBoxPW1.Size = new System.Drawing.Size(68, 22);
            this.textBoxPW1.TabIndex = 52;
            // 
            // textBoxHR2
            // 
            this.textBoxHR2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHR2.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHR2.Location = new System.Drawing.Point(208, 202);
            this.textBoxHR2.Name = "textBoxHR2";
            this.textBoxHR2.Size = new System.Drawing.Size(72, 22);
            this.textBoxHR2.TabIndex = 65;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(12, 181);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 16);
            this.label24.TabIndex = 51;
            this.label24.Text = "Temp";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 16);
            this.label17.TabIndex = 43;
            this.label17.Text = "CCID SIM Card:";
            // 
            // textBoxTimeDatalog
            // 
            this.textBoxTimeDatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTimeDatalog.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTimeDatalog.Location = new System.Drawing.Point(126, 146);
            this.textBoxTimeDatalog.Name = "textBoxTimeDatalog";
            this.textBoxTimeDatalog.Size = new System.Drawing.Size(154, 22);
            this.textBoxTimeDatalog.TabIndex = 53;
            // 
            // textBoxHR1
            // 
            this.textBoxHR1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHR1.Location = new System.Drawing.Point(123, 202);
            this.textBoxHR1.Name = "textBoxHR1";
            this.textBoxHR1.Size = new System.Drawing.Size(81, 22);
            this.textBoxHR1.TabIndex = 64;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(177, 263);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 16);
            this.label25.TabIndex = 50;
            this.label25.Text = "ADB:";
            // 
            // textBoxFWVer
            // 
            this.textBoxFWVer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFWVer.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFWVer.Location = new System.Drawing.Point(126, 35);
            this.textBoxFWVer.Name = "textBoxFWVer";
            this.textBoxFWVer.Size = new System.Drawing.Size(155, 22);
            this.textBoxFWVer.TabIndex = 46;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(16, 262);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 16);
            this.label26.TabIndex = 49;
            this.label26.Text = "ADA Vol:";
            // 
            // textBoxVbat1
            // 
            this.textBoxVbat1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVbat1.Location = new System.Drawing.Point(225, 287);
            this.textBoxVbat1.Name = "textBoxVbat1";
            this.textBoxVbat1.Size = new System.Drawing.Size(66, 22);
            this.textBoxVbat1.TabIndex = 63;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(16, 291);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 16);
            this.label23.TabIndex = 55;
            this.label23.Text = "CSQ:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 42);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 16);
            this.label16.TabIndex = 44;
            this.label16.Text = "Firmware:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 150);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(96, 16);
            this.label27.TabIndex = 48;
            this.label27.Text = "Time data logs";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(177, 292);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 16);
            this.label18.TabIndex = 62;
            this.label18.Text = "VBAT:";
            // 
            // textBoxCSQ1
            // 
            this.textBoxCSQ1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCSQ1.Location = new System.Drawing.Point(81, 287);
            this.textBoxCSQ1.Name = "textBoxCSQ1";
            this.textBoxCSQ1.Size = new System.Drawing.Size(68, 22);
            this.textBoxCSQ1.TabIndex = 56;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(11, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 16);
            this.label14.TabIndex = 45;
            this.label14.Text = "Bootloader:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(14, 236);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 16);
            this.label28.TabIndex = 47;
            this.label28.Text = "Power:";
            // 
            // textBoxIO1
            // 
            this.textBoxIO1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIO1.Location = new System.Drawing.Point(225, 231);
            this.textBoxIO1.Name = "textBoxIO1";
            this.textBoxIO1.Size = new System.Drawing.Size(66, 22);
            this.textBoxIO1.TabIndex = 61;
            // 
            // textBoxADA1
            // 
            this.textBoxADA1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxADA1.Location = new System.Drawing.Point(80, 259);
            this.textBoxADA1.Name = "textBoxADA1";
            this.textBoxADA1.Size = new System.Drawing.Size(69, 22);
            this.textBoxADA1.TabIndex = 57;
            // 
            // textBoxCCIDSim
            // 
            this.textBoxCCIDSim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCCIDSim.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxCCIDSim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCCIDSim.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCCIDSim.Location = new System.Drawing.Point(126, 118);
            this.textBoxCCIDSim.Name = "textBoxCCIDSim";
            this.textBoxCCIDSim.ReadOnly = true;
            this.textBoxCCIDSim.Size = new System.Drawing.Size(154, 22);
            this.textBoxCCIDSim.TabIndex = 42;
            // 
            // textBoxBootloaderdata
            // 
            this.textBoxBootloaderdata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBootloaderdata.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBootloaderdata.Location = new System.Drawing.Point(126, 63);
            this.textBoxBootloaderdata.Name = "textBoxBootloaderdata";
            this.textBoxBootloaderdata.Size = new System.Drawing.Size(155, 22);
            this.textBoxBootloaderdata.TabIndex = 40;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(177, 234);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 16);
            this.label22.TabIndex = 60;
            this.label22.Text = "IO:";
            // 
            // textBoxTempB1
            // 
            this.textBoxTempB1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTempB1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTempB1.Location = new System.Drawing.Point(208, 174);
            this.textBoxTempB1.Name = "textBoxTempB1";
            this.textBoxTempB1.Size = new System.Drawing.Size(72, 22);
            this.textBoxTempB1.TabIndex = 58;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 16);
            this.label12.TabIndex = 39;
            this.label12.Text = "IMEI device:";
            // 
            // textBoxADB1
            // 
            this.textBoxADB1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxADB1.Location = new System.Drawing.Point(225, 259);
            this.textBoxADB1.Name = "textBoxADB1";
            this.textBoxADB1.Size = new System.Drawing.Size(66, 22);
            this.textBoxADB1.TabIndex = 59;
            // 
            // Function
            // 
            this.Function.Controls.Add(this.button5);
            this.Function.Controls.Add(this.button3);
            this.Function.Controls.Add(this.button2);
            this.Function.Controls.Add(this.button1);
            this.Function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Function.Location = new System.Drawing.Point(0, 0);
            this.Function.Name = "Function";
            this.Function.Size = new System.Drawing.Size(299, 452);
            this.Function.TabIndex = 0;
            this.Function.TabStop = false;
            this.Function.Text = "Function";
            this.Function.Enter += new System.EventHandler(this.Function_Enter);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(80, 151);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(134, 24);
            this.button5.TabIndex = 3;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(80, 121);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 24);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 91);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 24);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dataGridViewLogs);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1118, 822);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "groupBox7";
            // 
            // dataGridViewLogs
            // 
            this.dataGridViewLogs.AllowUserToOrderColumns = true;
            this.dataGridViewLogs.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLogs.Location = new System.Drawing.Point(3, 18);
            this.dataGridViewLogs.Name = "dataGridViewLogs";
            this.dataGridViewLogs.Size = new System.Drawing.Size(1112, 801);
            this.dataGridViewLogs.TabIndex = 0;
            this.dataGridViewLogs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLogs_CellContentClick);
            // 
            // tabPage9
            // 
            this.tabPage9.Controls.Add(this.splitContainer17);
            this.tabPage9.Location = new System.Drawing.Point(4, 34);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(1427, 828);
            this.tabPage9.TabIndex = 2;
            this.tabPage9.Text = "Logs Data";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // splitContainer17
            // 
            this.splitContainer17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer17.Location = new System.Drawing.Point(3, 3);
            this.splitContainer17.Name = "splitContainer17";
            this.splitContainer17.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer17.Panel1
            // 
            this.splitContainer17.Panel1.Controls.Add(this.groupBox8);
            // 
            // splitContainer17.Panel2
            // 
            this.splitContainer17.Panel2.Controls.Add(this.label77);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxEndMark);
            this.splitContainer17.Panel2.Controls.Add(this.label78);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxChecksum);
            this.splitContainer17.Panel2.Controls.Add(this.label62);
            this.splitContainer17.Panel2.Controls.Add(this.label63);
            this.splitContainer17.Panel2.Controls.Add(this.label64);
            this.splitContainer17.Panel2.Controls.Add(this.label65);
            this.splitContainer17.Panel2.Controls.Add(this.label66);
            this.splitContainer17.Panel2.Controls.Add(this.label67);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxSpareData);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxSpareInfoLength);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxWireData);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxWireType);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxWireInfoLength);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxComType);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxComData);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxCOMInfoLength);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxLAC);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxCellID);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxSatellite);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxGPSRssi);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxGSMRssi);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxLBSInfoLength);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxDriveName);
            this.splitContainer17.Panel2.Controls.Add(this.label68);
            this.splitContainer17.Panel2.Controls.Add(this.label69);
            this.splitContainer17.Panel2.Controls.Add(this.label70);
            this.splitContainer17.Panel2.Controls.Add(this.label71);
            this.splitContainer17.Panel2.Controls.Add(this.label72);
            this.splitContainer17.Panel2.Controls.Add(this.label73);
            this.splitContainer17.Panel2.Controls.Add(this.label74);
            this.splitContainer17.Panel2.Controls.Add(this.label75);
            this.splitContainer17.Panel2.Controls.Add(this.label76);
            this.splitContainer17.Panel2.Controls.Add(this.label42);
            this.splitContainer17.Panel2.Controls.Add(this.label43);
            this.splitContainer17.Panel2.Controls.Add(this.label44);
            this.splitContainer17.Panel2.Controls.Add(this.label45);
            this.splitContainer17.Panel2.Controls.Add(this.label46);
            this.splitContainer17.Panel2.Controls.Add(this.label48);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxDriverID);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxDriverIDLength);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxDrive10h);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxDriver4h);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxDriverDataLength);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxSpeedLength);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxSpeedData);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxKMperDay);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxADBData);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxADAData);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxIOStatus);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxPowerSupply);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxTerminalStatus);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxEventID);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxStatusLength);
            this.splitContainer17.Panel2.Controls.Add(this.label49);
            this.splitContainer17.Panel2.Controls.Add(this.label50);
            this.splitContainer17.Panel2.Controls.Add(this.label52);
            this.splitContainer17.Panel2.Controls.Add(this.label53);
            this.splitContainer17.Panel2.Controls.Add(this.label54);
            this.splitContainer17.Panel2.Controls.Add(this.label55);
            this.splitContainer17.Panel2.Controls.Add(this.label56);
            this.splitContainer17.Panel2.Controls.Add(this.label58);
            this.splitContainer17.Panel2.Controls.Add(this.label59);
            this.splitContainer17.Panel2.Controls.Add(this.label33);
            this.splitContainer17.Panel2.Controls.Add(this.label34);
            this.splitContainer17.Panel2.Controls.Add(this.label35);
            this.splitContainer17.Panel2.Controls.Add(this.label36);
            this.splitContainer17.Panel2.Controls.Add(this.label38);
            this.splitContainer17.Panel2.Controls.Add(this.label39);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxEVPError);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxEHPError);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxGpsStatus);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxGpsSpeed);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxGpsTime);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxLong);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxAlt);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxLat);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxGPSLength);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxFrame);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxPacketSNum);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxDeviceDTC);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxImeiData);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxProtocol);
            this.splitContainer17.Panel2.Controls.Add(this.textBoxLength);
            this.splitContainer17.Panel2.Controls.Add(this.label61);
            this.splitContainer17.Panel2.Controls.Add(this.label60);
            this.splitContainer17.Panel2.Controls.Add(this.label57);
            this.splitContainer17.Panel2.Controls.Add(this.label51);
            this.splitContainer17.Panel2.Controls.Add(this.label47);
            this.splitContainer17.Panel2.Controls.Add(this.label37);
            this.splitContainer17.Panel2.Controls.Add(this.label32);
            this.splitContainer17.Panel2.Controls.Add(this.label31);
            this.splitContainer17.Panel2.Controls.Add(this.label30);
            this.splitContainer17.Panel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer17.Size = new System.Drawing.Size(1421, 822);
            this.splitContainer17.SplitterDistance = 220;
            this.splitContainer17.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBoxLogsData);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1421, 220);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Logs Data Send To Server";
            // 
            // textBoxLogsData
            // 
            this.textBoxLogsData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLogsData.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxLogsData.Location = new System.Drawing.Point(3, 31);
            this.textBoxLogsData.Multiline = true;
            this.textBoxLogsData.Name = "textBoxLogsData";
            this.textBoxLogsData.Size = new System.Drawing.Size(1415, 186);
            this.textBoxLogsData.TabIndex = 0;
            // 
            // label77
            // 
            this.label77.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(756, 458);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(71, 19);
            this.label77.TabIndex = 117;
            this.label77.Text = "End Mark";
            // 
            // textBoxEndMark
            // 
            this.textBoxEndMark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEndMark.Location = new System.Drawing.Point(902, 455);
            this.textBoxEndMark.Name = "textBoxEndMark";
            this.textBoxEndMark.Size = new System.Drawing.Size(209, 26);
            this.textBoxEndMark.TabIndex = 116;
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(280, 458);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(73, 19);
            this.label78.TabIndex = 115;
            this.label78.Text = "Checksum";
            // 
            // textBoxChecksum
            // 
            this.textBoxChecksum.Location = new System.Drawing.Point(426, 455);
            this.textBoxChecksum.Name = "textBoxChecksum";
            this.textBoxChecksum.Size = new System.Drawing.Size(209, 26);
            this.textBoxChecksum.TabIndex = 114;
            // 
            // label62
            // 
            this.label62.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(1007, 385);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(118, 19);
            this.label62.TabIndex = 113;
            this.label62.Text = "Spare Info Length";
            // 
            // label63
            // 
            this.label63.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(1007, 413);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(78, 19);
            this.label63.TabIndex = 112;
            this.label63.Text = "Spare Data";
            // 
            // label64
            // 
            this.label64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(1007, 357);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(85, 19);
            this.label64.TabIndex = 111;
            this.label64.Text = "1-Wire Data";
            // 
            // label65
            // 
            this.label65.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(1007, 329);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(86, 19);
            this.label65.TabIndex = 110;
            this.label65.Text = "1-Wire Type";
            this.label65.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label66
            // 
            this.label66.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(1007, 301);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(125, 19);
            this.label66.TabIndex = 109;
            this.label66.Text = "1-Wire Info Length";
            // 
            // label67
            // 
            this.label67.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(1007, 273);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(79, 19);
            this.label67.TabIndex = 108;
            this.label67.Text = "COM Data";
            // 
            // textBoxSpareData
            // 
            this.textBoxSpareData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSpareData.Location = new System.Drawing.Point(1153, 410);
            this.textBoxSpareData.Name = "textBoxSpareData";
            this.textBoxSpareData.Size = new System.Drawing.Size(209, 26);
            this.textBoxSpareData.TabIndex = 107;
            // 
            // textBoxSpareInfoLength
            // 
            this.textBoxSpareInfoLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSpareInfoLength.Location = new System.Drawing.Point(1153, 382);
            this.textBoxSpareInfoLength.Name = "textBoxSpareInfoLength";
            this.textBoxSpareInfoLength.Size = new System.Drawing.Size(209, 26);
            this.textBoxSpareInfoLength.TabIndex = 106;
            // 
            // textBoxWireData
            // 
            this.textBoxWireData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWireData.Location = new System.Drawing.Point(1153, 354);
            this.textBoxWireData.Name = "textBoxWireData";
            this.textBoxWireData.Size = new System.Drawing.Size(209, 26);
            this.textBoxWireData.TabIndex = 105;
            // 
            // textBoxWireType
            // 
            this.textBoxWireType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWireType.Location = new System.Drawing.Point(1153, 326);
            this.textBoxWireType.Name = "textBoxWireType";
            this.textBoxWireType.Size = new System.Drawing.Size(209, 26);
            this.textBoxWireType.TabIndex = 104;
            // 
            // textBoxWireInfoLength
            // 
            this.textBoxWireInfoLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWireInfoLength.Location = new System.Drawing.Point(1153, 298);
            this.textBoxWireInfoLength.Name = "textBoxWireInfoLength";
            this.textBoxWireInfoLength.Size = new System.Drawing.Size(209, 26);
            this.textBoxWireInfoLength.TabIndex = 103;
            // 
            // textBoxComType
            // 
            this.textBoxComType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxComType.Location = new System.Drawing.Point(1153, 242);
            this.textBoxComType.Name = "textBoxComType";
            this.textBoxComType.Size = new System.Drawing.Size(209, 26);
            this.textBoxComType.TabIndex = 102;
            // 
            // textBoxComData
            // 
            this.textBoxComData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxComData.Location = new System.Drawing.Point(1153, 270);
            this.textBoxComData.Name = "textBoxComData";
            this.textBoxComData.Size = new System.Drawing.Size(209, 26);
            this.textBoxComData.TabIndex = 101;
            // 
            // textBoxCOMInfoLength
            // 
            this.textBoxCOMInfoLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCOMInfoLength.Location = new System.Drawing.Point(1153, 214);
            this.textBoxCOMInfoLength.Name = "textBoxCOMInfoLength";
            this.textBoxCOMInfoLength.Size = new System.Drawing.Size(209, 26);
            this.textBoxCOMInfoLength.TabIndex = 100;
            // 
            // textBoxLAC
            // 
            this.textBoxLAC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLAC.Location = new System.Drawing.Point(1153, 186);
            this.textBoxLAC.Name = "textBoxLAC";
            this.textBoxLAC.Size = new System.Drawing.Size(209, 26);
            this.textBoxLAC.TabIndex = 99;
            // 
            // textBoxCellID
            // 
            this.textBoxCellID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCellID.Location = new System.Drawing.Point(1153, 158);
            this.textBoxCellID.Name = "textBoxCellID";
            this.textBoxCellID.Size = new System.Drawing.Size(209, 26);
            this.textBoxCellID.TabIndex = 98;
            // 
            // textBoxSatellite
            // 
            this.textBoxSatellite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSatellite.Location = new System.Drawing.Point(1153, 130);
            this.textBoxSatellite.Name = "textBoxSatellite";
            this.textBoxSatellite.Size = new System.Drawing.Size(209, 26);
            this.textBoxSatellite.TabIndex = 97;
            // 
            // textBoxGPSRssi
            // 
            this.textBoxGPSRssi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGPSRssi.Location = new System.Drawing.Point(1153, 102);
            this.textBoxGPSRssi.Name = "textBoxGPSRssi";
            this.textBoxGPSRssi.Size = new System.Drawing.Size(209, 26);
            this.textBoxGPSRssi.TabIndex = 96;
            // 
            // textBoxGSMRssi
            // 
            this.textBoxGSMRssi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGSMRssi.Location = new System.Drawing.Point(1153, 74);
            this.textBoxGSMRssi.Name = "textBoxGSMRssi";
            this.textBoxGSMRssi.Size = new System.Drawing.Size(209, 26);
            this.textBoxGSMRssi.TabIndex = 95;
            // 
            // textBoxLBSInfoLength
            // 
            this.textBoxLBSInfoLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLBSInfoLength.Location = new System.Drawing.Point(1153, 46);
            this.textBoxLBSInfoLength.Name = "textBoxLBSInfoLength";
            this.textBoxLBSInfoLength.Size = new System.Drawing.Size(209, 26);
            this.textBoxLBSInfoLength.TabIndex = 94;
            // 
            // textBoxDriveName
            // 
            this.textBoxDriveName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDriveName.Location = new System.Drawing.Point(1153, 18);
            this.textBoxDriveName.Name = "textBoxDriveName";
            this.textBoxDriveName.Size = new System.Drawing.Size(209, 26);
            this.textBoxDriveName.TabIndex = 93;
            // 
            // label68
            // 
            this.label68.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(1007, 217);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(119, 19);
            this.label68.TabIndex = 92;
            this.label68.Text = "COM Info Length";
            // 
            // label69
            // 
            this.label69.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(1007, 245);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(80, 19);
            this.label69.TabIndex = 91;
            this.label69.Text = "COM Type";
            // 
            // label70
            // 
            this.label70.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(1007, 189);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(40, 19);
            this.label70.TabIndex = 90;
            this.label70.Text = "LAC";
            // 
            // label71
            // 
            this.label71.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(1007, 133);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(62, 19);
            this.label71.TabIndex = 89;
            this.label71.Text = "Satellites";
            // 
            // label72
            // 
            this.label72.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(1007, 161);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(53, 19);
            this.label72.TabIndex = 88;
            this.label72.Text = "Cell ID";
            // 
            // label73
            // 
            this.label73.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(1007, 105);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(75, 19);
            this.label73.TabIndex = 87;
            this.label73.Text = "GPS RSSI";
            // 
            // label74
            // 
            this.label74.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(1007, 77);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(80, 19);
            this.label74.TabIndex = 86;
            this.label74.Text = "GSM RSSI";
            // 
            // label75
            // 
            this.label75.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(1007, 49);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(110, 19);
            this.label75.TabIndex = 85;
            this.label75.Text = "LBS Info Length";
            // 
            // label76
            // 
            this.label76.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(1007, 21);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(88, 19);
            this.label76.TabIndex = 84;
            this.label76.Text = "Driver Name";
            // 
            // label42
            // 
            this.label42.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(531, 385);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(112, 19);
            this.label42.TabIndex = 83;
            this.label42.Text = "Driver ID Length";
            // 
            // label43
            // 
            this.label43.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(531, 413);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(67, 19);
            this.label43.TabIndex = 82;
            this.label43.Text = "Driver ID";
            // 
            // label44
            // 
            this.label44.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(531, 357);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(104, 19);
            this.label44.TabIndex = 81;
            this.label44.Text = "Driver 10h /day";
            // 
            // label45
            // 
            this.label45.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(531, 329);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(141, 19);
            this.label45.TabIndex = 80;
            this.label45.Text = "Driver 4h Continously";
            // 
            // label46
            // 
            this.label46.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(531, 301);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(125, 19);
            this.label46.TabIndex = 79;
            this.label46.Text = "Driver Data Length";
            // 
            // label48
            // 
            this.label48.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(531, 273);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(92, 19);
            this.label48.TabIndex = 78;
            this.label48.Text = "Speed  data/s";
            // 
            // textBoxDriverID
            // 
            this.textBoxDriverID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDriverID.Location = new System.Drawing.Point(692, 410);
            this.textBoxDriverID.Name = "textBoxDriverID";
            this.textBoxDriverID.Size = new System.Drawing.Size(209, 26);
            this.textBoxDriverID.TabIndex = 77;
            // 
            // textBoxDriverIDLength
            // 
            this.textBoxDriverIDLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDriverIDLength.Location = new System.Drawing.Point(692, 382);
            this.textBoxDriverIDLength.Name = "textBoxDriverIDLength";
            this.textBoxDriverIDLength.Size = new System.Drawing.Size(209, 26);
            this.textBoxDriverIDLength.TabIndex = 76;
            // 
            // textBoxDrive10h
            // 
            this.textBoxDrive10h.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDrive10h.Location = new System.Drawing.Point(692, 354);
            this.textBoxDrive10h.Name = "textBoxDrive10h";
            this.textBoxDrive10h.Size = new System.Drawing.Size(209, 26);
            this.textBoxDrive10h.TabIndex = 75;
            // 
            // textBoxDriver4h
            // 
            this.textBoxDriver4h.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDriver4h.Location = new System.Drawing.Point(692, 326);
            this.textBoxDriver4h.Name = "textBoxDriver4h";
            this.textBoxDriver4h.Size = new System.Drawing.Size(209, 26);
            this.textBoxDriver4h.TabIndex = 74;
            // 
            // textBoxDriverDataLength
            // 
            this.textBoxDriverDataLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDriverDataLength.Location = new System.Drawing.Point(692, 298);
            this.textBoxDriverDataLength.Name = "textBoxDriverDataLength";
            this.textBoxDriverDataLength.Size = new System.Drawing.Size(209, 26);
            this.textBoxDriverDataLength.TabIndex = 73;
            // 
            // textBoxSpeedLength
            // 
            this.textBoxSpeedLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSpeedLength.Location = new System.Drawing.Point(692, 242);
            this.textBoxSpeedLength.Name = "textBoxSpeedLength";
            this.textBoxSpeedLength.Size = new System.Drawing.Size(209, 26);
            this.textBoxSpeedLength.TabIndex = 72;
            // 
            // textBoxSpeedData
            // 
            this.textBoxSpeedData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSpeedData.Location = new System.Drawing.Point(692, 270);
            this.textBoxSpeedData.Name = "textBoxSpeedData";
            this.textBoxSpeedData.Size = new System.Drawing.Size(209, 26);
            this.textBoxSpeedData.TabIndex = 71;
            // 
            // textBoxKMperDay
            // 
            this.textBoxKMperDay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxKMperDay.Location = new System.Drawing.Point(692, 214);
            this.textBoxKMperDay.Name = "textBoxKMperDay";
            this.textBoxKMperDay.Size = new System.Drawing.Size(209, 26);
            this.textBoxKMperDay.TabIndex = 70;
            // 
            // textBoxADBData
            // 
            this.textBoxADBData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxADBData.Location = new System.Drawing.Point(692, 186);
            this.textBoxADBData.Name = "textBoxADBData";
            this.textBoxADBData.Size = new System.Drawing.Size(209, 26);
            this.textBoxADBData.TabIndex = 69;
            // 
            // textBoxADAData
            // 
            this.textBoxADAData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxADAData.Location = new System.Drawing.Point(692, 158);
            this.textBoxADAData.Name = "textBoxADAData";
            this.textBoxADAData.Size = new System.Drawing.Size(209, 26);
            this.textBoxADAData.TabIndex = 68;
            // 
            // textBoxIOStatus
            // 
            this.textBoxIOStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIOStatus.Location = new System.Drawing.Point(692, 130);
            this.textBoxIOStatus.Name = "textBoxIOStatus";
            this.textBoxIOStatus.Size = new System.Drawing.Size(209, 26);
            this.textBoxIOStatus.TabIndex = 67;
            // 
            // textBoxPowerSupply
            // 
            this.textBoxPowerSupply.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPowerSupply.Location = new System.Drawing.Point(692, 102);
            this.textBoxPowerSupply.Name = "textBoxPowerSupply";
            this.textBoxPowerSupply.Size = new System.Drawing.Size(209, 26);
            this.textBoxPowerSupply.TabIndex = 66;
            // 
            // textBoxTerminalStatus
            // 
            this.textBoxTerminalStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTerminalStatus.Location = new System.Drawing.Point(692, 74);
            this.textBoxTerminalStatus.Name = "textBoxTerminalStatus";
            this.textBoxTerminalStatus.Size = new System.Drawing.Size(209, 26);
            this.textBoxTerminalStatus.TabIndex = 65;
            // 
            // textBoxEventID
            // 
            this.textBoxEventID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEventID.Location = new System.Drawing.Point(692, 46);
            this.textBoxEventID.Name = "textBoxEventID";
            this.textBoxEventID.Size = new System.Drawing.Size(209, 26);
            this.textBoxEventID.TabIndex = 64;
            // 
            // textBoxStatusLength
            // 
            this.textBoxStatusLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatusLength.Location = new System.Drawing.Point(692, 18);
            this.textBoxStatusLength.Name = "textBoxStatusLength";
            this.textBoxStatusLength.Size = new System.Drawing.Size(209, 26);
            this.textBoxStatusLength.TabIndex = 63;
            // 
            // label49
            // 
            this.label49.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(531, 217);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(95, 19);
            this.label49.TabIndex = 62;
            this.label49.Text = "Total KM/day";
            // 
            // label50
            // 
            this.label50.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(531, 245);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(121, 19);
            this.label50.TabIndex = 61;
            this.label50.Text = "Speed Info Length";
            // 
            // label52
            // 
            this.label52.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(531, 189);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(41, 19);
            this.label52.TabIndex = 60;
            this.label52.Text = "ADB";
            // 
            // label53
            // 
            this.label53.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(531, 133);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(67, 19);
            this.label53.TabIndex = 59;
            this.label53.Text = "IO Status";
            // 
            // label54
            // 
            this.label54.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(531, 161);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(42, 19);
            this.label54.TabIndex = 58;
            this.label54.Text = "ADA";
            // 
            // label55
            // 
            this.label55.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(531, 105);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(136, 19);
            this.label55.TabIndex = 57;
            this.label55.Text = "Power Supply Status";
            // 
            // label56
            // 
            this.label56.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(531, 77);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(101, 19);
            this.label56.TabIndex = 56;
            this.label56.Text = "Terminal Status";
            // 
            // label58
            // 
            this.label58.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(531, 49);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(63, 19);
            this.label58.TabIndex = 55;
            this.label58.Text = "Event ID";
            // 
            // label59
            // 
            this.label59.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(531, 21);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(119, 19);
            this.label59.TabIndex = 54;
            this.label59.Text = "Status Info Length";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(37, 385);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(73, 19);
            this.label33.TabIndex = 53;
            this.label33.Text = "EHP Error";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(37, 413);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(73, 19);
            this.label34.TabIndex = 52;
            this.label34.Text = "EVP Error";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(37, 357);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(143, 19);
            this.label35.TabIndex = 51;
            this.label35.Text = "GPS Angle and Status";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(37, 329);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(81, 19);
            this.label36.TabIndex = 50;
            this.label36.Text = "GPS Speed";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(37, 301);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(71, 19);
            this.label38.TabIndex = 49;
            this.label38.Text = "GPS Time";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(37, 273);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(56, 19);
            this.label39.TabIndex = 48;
            this.label39.Text = "Altitude";
            // 
            // textBoxEVPError
            // 
            this.textBoxEVPError.Location = new System.Drawing.Point(195, 410);
            this.textBoxEVPError.Name = "textBoxEVPError";
            this.textBoxEVPError.Size = new System.Drawing.Size(150, 26);
            this.textBoxEVPError.TabIndex = 47;
            // 
            // textBoxEHPError
            // 
            this.textBoxEHPError.Location = new System.Drawing.Point(195, 382);
            this.textBoxEHPError.Name = "textBoxEHPError";
            this.textBoxEHPError.Size = new System.Drawing.Size(150, 26);
            this.textBoxEHPError.TabIndex = 46;
            // 
            // textBoxGpsStatus
            // 
            this.textBoxGpsStatus.Location = new System.Drawing.Point(195, 354);
            this.textBoxGpsStatus.Name = "textBoxGpsStatus";
            this.textBoxGpsStatus.Size = new System.Drawing.Size(150, 26);
            this.textBoxGpsStatus.TabIndex = 45;
            // 
            // textBoxGpsSpeed
            // 
            this.textBoxGpsSpeed.Location = new System.Drawing.Point(195, 326);
            this.textBoxGpsSpeed.Name = "textBoxGpsSpeed";
            this.textBoxGpsSpeed.Size = new System.Drawing.Size(150, 26);
            this.textBoxGpsSpeed.TabIndex = 44;
            // 
            // textBoxGpsTime
            // 
            this.textBoxGpsTime.Location = new System.Drawing.Point(195, 298);
            this.textBoxGpsTime.Name = "textBoxGpsTime";
            this.textBoxGpsTime.Size = new System.Drawing.Size(150, 26);
            this.textBoxGpsTime.TabIndex = 43;
            // 
            // textBoxLong
            // 
            this.textBoxLong.Location = new System.Drawing.Point(195, 242);
            this.textBoxLong.Name = "textBoxLong";
            this.textBoxLong.Size = new System.Drawing.Size(150, 26);
            this.textBoxLong.TabIndex = 42;
            // 
            // textBoxAlt
            // 
            this.textBoxAlt.Location = new System.Drawing.Point(195, 270);
            this.textBoxAlt.Name = "textBoxAlt";
            this.textBoxAlt.Size = new System.Drawing.Size(150, 26);
            this.textBoxAlt.TabIndex = 41;
            // 
            // textBoxLat
            // 
            this.textBoxLat.Location = new System.Drawing.Point(195, 214);
            this.textBoxLat.Name = "textBoxLat";
            this.textBoxLat.Size = new System.Drawing.Size(150, 26);
            this.textBoxLat.TabIndex = 40;
            // 
            // textBoxGPSLength
            // 
            this.textBoxGPSLength.Location = new System.Drawing.Point(195, 186);
            this.textBoxGPSLength.Name = "textBoxGPSLength";
            this.textBoxGPSLength.Size = new System.Drawing.Size(150, 26);
            this.textBoxGPSLength.TabIndex = 39;
            // 
            // textBoxFrame
            // 
            this.textBoxFrame.Location = new System.Drawing.Point(195, 158);
            this.textBoxFrame.Name = "textBoxFrame";
            this.textBoxFrame.Size = new System.Drawing.Size(150, 26);
            this.textBoxFrame.TabIndex = 38;
            // 
            // textBoxPacketSNum
            // 
            this.textBoxPacketSNum.Location = new System.Drawing.Point(195, 130);
            this.textBoxPacketSNum.Name = "textBoxPacketSNum";
            this.textBoxPacketSNum.Size = new System.Drawing.Size(150, 26);
            this.textBoxPacketSNum.TabIndex = 37;
            // 
            // textBoxDeviceDTC
            // 
            this.textBoxDeviceDTC.Location = new System.Drawing.Point(195, 102);
            this.textBoxDeviceDTC.Name = "textBoxDeviceDTC";
            this.textBoxDeviceDTC.Size = new System.Drawing.Size(150, 26);
            this.textBoxDeviceDTC.TabIndex = 36;
            // 
            // textBoxImeiData
            // 
            this.textBoxImeiData.Location = new System.Drawing.Point(195, 74);
            this.textBoxImeiData.Name = "textBoxImeiData";
            this.textBoxImeiData.Size = new System.Drawing.Size(150, 26);
            this.textBoxImeiData.TabIndex = 35;
            // 
            // textBoxProtocol
            // 
            this.textBoxProtocol.Location = new System.Drawing.Point(195, 46);
            this.textBoxProtocol.Name = "textBoxProtocol";
            this.textBoxProtocol.Size = new System.Drawing.Size(150, 26);
            this.textBoxProtocol.TabIndex = 34;
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(195, 18);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(150, 26);
            this.textBoxLength.TabIndex = 33;
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(37, 217);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(58, 19);
            this.label61.TabIndex = 29;
            this.label61.Text = "Latitude";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(37, 245);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(69, 19);
            this.label60.TabIndex = 28;
            this.label60.Text = "Longitude";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(37, 189);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(111, 19);
            this.label57.TabIndex = 25;
            this.label57.Text = "GPS Info Length";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(37, 133);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(143, 19);
            this.label51.TabIndex = 19;
            this.label51.Text = "Packet Serial Number";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(37, 161);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(132, 19);
            this.label47.TabIndex = 15;
            this.label47.Text = "Frame Control Field";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(37, 105);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(84, 19);
            this.label37.TabIndex = 7;
            this.label37.Text = "Device RTC";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(37, 77);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(42, 19);
            this.label32.TabIndex = 2;
            this.label32.Text = "IMEI";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(37, 49);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(110, 19);
            this.label31.TabIndex = 1;
            this.label31.Text = "Protocol number";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(37, 21);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 19);
            this.label30.TabIndex = 0;
            this.label30.Text = "Length";
            // 
            // radioButton1
            // 
            this.radioButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(186, 868);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(152, 19);
            this.radioButton1.TabIndex = 40;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Disconnected to Server";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(1435, 888);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.tabConvert);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(21, 28);
            this.MinimumSize = new System.Drawing.Size(1024, 700);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TVNConfigSW";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.FrmMain_Closed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.splitContainer11.Panel1.ResumeLayout(false);
            this.splitContainer11.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).EndInit();
            this.splitContainer11.ResumeLayout(false);
            this.splitContainer12.Panel1.ResumeLayout(false);
            this.splitContainer12.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).EndInit();
            this.splitContainer12.ResumeLayout(false);
            this.splitContainer13.Panel1.ResumeLayout(false);
            this.splitContainer13.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).EndInit();
            this.splitContainer13.ResumeLayout(false);
            this.splitContainer14.Panel1.ResumeLayout(false);
            this.splitContainer14.Panel1.PerformLayout();
            this.splitContainer14.Panel2.ResumeLayout(false);
            this.splitContainer14.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer14)).EndInit();
            this.splitContainer14.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBoxLogs.ResumeLayout(false);
            this.groupBoxLogs.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.splitContainer15.Panel1.ResumeLayout(false);
            this.splitContainer15.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer15)).EndInit();
            this.splitContainer15.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.gprs4gStartus.ResumeLayout(false);
            this.gprs4gStartus.PerformLayout();
            this.splitContainer16.Panel1.ResumeLayout(false);
            this.splitContainer16.Panel2.ResumeLayout(false);
            this.splitContainer16.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer16)).EndInit();
            this.splitContainer16.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            this.tabConvert.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.Function.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).EndInit();
            this.tabPage9.ResumeLayout(false);
            this.splitContainer17.Panel1.ResumeLayout(false);
            this.splitContainer17.Panel2.ResumeLayout(false);
            this.splitContainer17.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer17)).EndInit();
            this.splitContainer17.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Transfer controlling flags

        private Boolean isDeviceConnected = false;

        #endregion

        private readonly int SERIAL_PORT_DATA_HANDLER_INTERVAL = 10;

        private static ListBoxLog listBoxLog;

        // Constants for extern calls to various scrollbar functions
        private const int SB_VERT = 0x1;
        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 0x4;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetScrollPos(IntPtr hWnd, int nBar);
        [DllImport("user32.dll")]
        private static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport("user32.dll")]
        private static extern bool PostMessageA(IntPtr hWnd, int nBar, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool GetScrollRange(IntPtr hWnd, int nBar, out int lpMinPos, out int lpMaxPos);

        private enum FormActions
        {
            AddTextToTextBoxRcvData,
            DisableInputReportBufferSize,
            EnableGetInputReportInterruptTransfer,
            EnableInputReportBufferSize,
            EnableSendOutputReportInterrupt,
            ScrollToBottomOfTextBoxRcvData,
            SetConnectingStatusLabel
        }

        //  This delegate has the same parameters as AccessForm.
        //  Used in accessing the application's form from a different thread.

        private delegate void MarshalDataToForm(FormActions action, String textToAdd);

        ///  <param name="action"> a FormActions member that names the action to perform on the form</param>
        ///  <param name="formText"> text that the form displays or the code uses for 
        ///  another purpose. Actions that don't use text ignore this parameter. </param>

        private void AccessForm(FormActions action, String formText)
        {
            try
            {
                //  Select an action to perform on the form:

                switch (action)
                {
                    case FormActions.SetConnectingStatusLabel:

                        labelConnectingStatus.Text = formText;
                        break;
                }
            }
            catch (Exception ex)
            {
                DisplayException(Name, ex);
                throw;
            }
        }

        /// <summary>
        /// Close the handle and FileStreams for a device.
        /// </summary>
        /// 
        private void CloseCommunications()
        {
            try
            {
                if (serialPort.IsOpen == true)
                {
                    serialPort.Close();
                }
            }
            catch (Exception e)
            {
            }
        }

        ///  <summary>
        ///  Perform shutdown operations.
        ///  </summary>

        private void FrmMain_Closed(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                Shutdown();
            }
            catch (Exception ex)
            {
                DisplayException(Name, ex);
                throw;
            }
        }

        ///  <summary>
        ///  Perform startup operations.
        ///  </summary>
        #region Event
        private void FrmMain_Load(Object eventSender, EventArgs eventArgs)
        {
            try
            {
                Startup();
            }
            catch (Exception ex)
            {
                DisplayException(Name, ex);
                throw;
            }
            CreateColumForDataGridView();
            EnableControls(false, true);
        }

        #endregion

        ///  <summary>
        ///  Initialize the elements on the form.
        ///  </summary>

        private void InitializeDisplay()
        {
            try
            {
                comboBoxComPortBaudRate.SelectedIndex = 0;
                RefreshComportList();
                if (comboBoxComPortList.Items.Count > 0)
                {
                    string selectedPortName = string.Empty;
                    for (int i = 0; i < comboBoxComPortList.Items.Count; i++)
                    {
                        selectedPortName = comboBoxComPortList.Items[i].ToString();
                        if (selectedPortName == Properties.Settings.Default.ComPortName)
                        {
                            comboBoxComPortList.SelectedIndex = i;
                        }
                    }
                    Properties.Settings.Default.ComPortName = selectedPortName;
                    Properties.Settings.Default.Save();
                }

                buttonOpenComPort.PerformClick();

                // Check binary firmware file
                if (File.Exists(Properties.Settings.Default.LastOpenFirmwareFilePath))
                {
                    textBoxFirmwareFilePath1.Text = Properties.Settings.Default.LastOpenFirmwareFilePath;
                }
            }
            catch (Exception ex)
            {
                DisplayException(Name, ex);
                throw;
            }
        }

        ///  <summary>
        ///  Enables accessing a form's controls from another thread 
        ///  </summary>
        ///  
        ///  <param name="action"> a FormActions member that names the action to perform on the form </param>
        ///  <param name="textToDisplay"> text that the form displays or the code uses for 
        ///  another purpose. Actions that don't use text ignore this parameter.  </param>

        private void MyMarshalDataToForm(FormActions action, String textToDisplay)
        {
            try
            {
                object[] args = { action, textToDisplay };
                //  The AccessForm routine contains the code that accesses the form.
                MarshalDataToForm marshalDataToFormDelegate = AccessForm;
                //  Execute AccessForm, passing the parameters in args.
                Invoke(marshalDataToFormDelegate, args);
            }
            catch (Exception ex)
            {
                DisplayException(Name, ex);
                throw;
            }
        }

        ///  <summary>
        ///  Scroll to the bottom of the list box and trim as needed.
        ///  </summary>

        private void ScrollToBottomOfRcvDataTextBox()
        {
            try
            {
                //textBoxReceivedData.Focus();
                textBoxDeviceLogs.SelectionStart = textBoxDeviceLogs.Text.Length;
                textBoxDeviceLogs.ScrollToCaret();
                textBoxDeviceLogs.Refresh();


            }
            catch (Exception ex)
            {
                DisplayException(Name, ex);
                throw;
            }
        }

        private void Shutdown()
        {
            try
            {
                CloseCommunications();
            }
            catch (Exception ex)
            {
                DisplayException(Name, ex);
                throw;
            }
        }

        ///  <summary>
        ///  Perform actions that must execute when the program starts.
        ///  </summary>

        private void Startup()
        {
            try
            {

                listBoxLog = new ListBoxLog(listBoxFirmwareUpdateLog1);

                InitializeDisplay();
            }
            catch (Exception ex)
            {
                DisplayException(Name, ex);
                throw;
            }
        }

        ///  <summary>
        ///  Provides a central mechanism for exception handling.
        ///  Displays a message box that describes the exception.
        ///  </summary>
        ///  
        ///  <param name="moduleName"> the module where the exception occurred. </param>
        ///  <param name="e"> the exception </param>

        internal static void DisplayException(String moduleName, Exception e)
        {
            //  Create an error message.
            String message = "Exception: " + e.Message + Environment.NewLine + "Module: " + moduleName + Environment.NewLine + "Method: " + e.TargetSite.Name;

            const String caption = "Unexpected Exception";

            MessageBox.Show(message, caption, MessageBoxButtons.OK);
            Debug.Write(message);

            // Get the last error and display it. 

            Int32 error = Marshal.GetLastWin32Error();

            Debug.WriteLine("The last Win32 Error was: " + error);
        }

        private void buttonClearTextBoxRcvData_Click(object sender, EventArgs e)
        {
            textBoxDeviceLogs.Clear();

            textBoxImei.Clear();


            textBoxDeviceErrorMessage.Clear();

        }


        private void buttonCopyTextBoxRcvData_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxDeviceLogs.Text);
        }

        #region Comport device managerment
        private List<string> GetAllAvailblePorts()
        {
            List<string> comPortList = new List<string>();
            foreach (String portName in SerialPort.GetPortNames())
            {
                comPortList.Add(portName);
            }
            return comPortList;
        }
        private void RefreshComportList()
        {
            comboBoxComPortList.Items.Clear();
            List<string> portList = GetAllAvailblePorts();
            if (portList.Count > 0)
            {
                foreach (string portName in portList)
                {
                    comboBoxComPortList.Items.Add(portName);
                }
                comboBoxComPortList.SelectedIndex = 0;
            }
        }
        private void buttonRefreshComPortList_Click(object sender, EventArgs e)
        {
            RefreshComportList();
        }
        private void buttonOpenPort_Click(object sender, EventArgs e)
        {
            bool isTryOpenPort = false;
            try
            {
                if (serialPort.IsOpen == false)
                {
                    if (comboBoxComPortList.Items.Count > 0)
                    {
                        isTryOpenPort = true;
                        serialPort.PortName = comboBoxComPortList.SelectedItem.ToString();
                        serialPort.BaudRate = Convert.ToInt32(comboBoxComPortBaudRate.SelectedItem.ToString());
                        serialPort.DataBits = 8;
                        serialPort.StopBits = StopBits.One;
                        serialPort.Handshake = Handshake.None;
                        serialPort.Parity = Parity.None;
                        serialPort.Open();
                        buttonOpenComPort.Text = "Close";
                        buttonOpenComPort.BackColor = System.Drawing.Color.LightGreen;
                        timerSerialPortRxDataParsing.Start();
                        labelConnectingStatus.Text = "Connected via " + comboBoxComPortList.SelectedItem.ToString();
                        isDeviceConnected = true;
                        Properties.Settings.Default.ComPortName = comboBoxComPortList.SelectedItem.ToString();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("No availble port");
                    }
                }
                else
                {
                    serialPort.Close();
                    buttonOpenComPort.Text = "Open";
                    timerSerialPortRxDataParsing.Stop();
                    labelConnectingStatus.Text = "Disconnected";
                    buttonOpenComPort.BackColor = System.Drawing.Color.LightGray;
                    isDeviceConnected = false;
                }
            }
            catch (Exception ex)
            {
                if (isTryOpenPort == true)
                {
                    MessageBox.Show("Can not open " + serialPort.PortName);
                }
                return;
            }
        }
        #endregion

        #region Serial Tx/Rx data handler

        //private Queue<Byte> serialRxQueue = new Queue<Byte>();
        private ConcurrentQueue<Byte[]> serialPortRcvBufferQueue = new ConcurrentQueue<byte[]>();

        private ConcurrentQueue<string> commandStrQueue = new ConcurrentQueue<string>();

        private Queue<string> rcvLinesQueue = new Queue<string>();

        private Queue<string> bootLoaderRxResponseQueue = new Queue<string>();

        private ConcurrentQueue<Byte[]> bootLoaderTxPacketQueue = new ConcurrentQueue<byte[]>();

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int numByteToRead = serialPort.BytesToRead;
            byte[] buffer = new byte[numByteToRead];
            serialPort.Read(buffer, 0, numByteToRead);
            serialPortRcvBufferQueue.Enqueue(buffer);
        }

        private int devideLogUpdateCounter = 0;

        private Byte[] bufferRemainStoreNormalMode = new Byte[4096];

        private int byteRemainStoreNormalModeCount = 0;

        void ReadLogLineFromSerialPort()
        {
            int readByte = 0;
            // Get all buffer in queue
            List<Byte[]> bufferList = new List<byte[]>();
            while (!serialPortRcvBufferQueue.IsEmpty)
            {
                Byte[] buffer;
                serialPortRcvBufferQueue.TryDequeue(out buffer);
                bufferList.Add(buffer);
                readByte += buffer.Length;
            }

            Byte[] totalBuffer = new Byte[readByte + byteRemainStoreNormalModeCount];
            int totalBufferHead = 0;
            int totalBufferTail = 0;

            // Add remain byte from last time
            if (byteRemainStoreNormalModeCount > 0)
            {
                Buffer.BlockCopy(bufferRemainStoreNormalMode, 0, totalBuffer, totalBufferTail, byteRemainStoreNormalModeCount);
                totalBufferTail += byteRemainStoreNormalModeCount;
                byteRemainStoreNormalModeCount = 0;
            }

            // Copy all read byte into totalBuffer
            for (int i = 0; i < bufferList.Count; i++)
            {
                if (bufferList[i].Length > 0)
                {
                    Buffer.BlockCopy(bufferList[i], 0, totalBuffer, totalBufferTail, bufferList[i].Length);
                    totalBufferTail += bufferList[i].Length;
                }
            }

            // Find line from totalBuffer
            for (int i = 0; i < totalBuffer.Length; i++)
            {
                if (totalBuffer[i] == 0x0D || totalBuffer[i] == 0x0A)
                {
                    int copylen = i - totalBufferHead;
                    if (copylen > 0)
                    {
                        Byte[] lineBuffer = new Byte[copylen];
                        Buffer.BlockCopy(totalBuffer, totalBufferHead, lineBuffer, 0, copylen);
                        rcvLinesQueue.Enqueue(serialPort.Encoding.GetString(lineBuffer));
                        // Pass all the 0x0A and 0x0D
                        for (; i < totalBuffer.Length; i++)
                        {
                            if (totalBuffer[i] != 0x0A && totalBuffer[i] != 0x0D) // go to next line
                            {
                                break;
                            }
                        }
                        totalBufferHead = i;
                    }
                }
            }

            // Save the remain of totalBuffer to bufferRemainStore
            if (totalBufferHead < totalBuffer.Length)
            {
                byteRemainStoreNormalModeCount = totalBuffer.Length - totalBufferHead;
                if (byteRemainStoreNormalModeCount > bufferRemainStoreNormalMode.Length)
                {
                    byteRemainStoreNormalModeCount = bufferRemainStoreNormalMode.Length;
                }
                Buffer.BlockCopy(totalBuffer, totalBufferHead, bufferRemainStoreNormalMode, 0, byteRemainStoreNormalModeCount);
            }
        }

        void ParseLogMessage(string line)
        {
            line = line.Trim('\r', '\n', ' ', '\t');
            bool logEnable = true;
            //text = text.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            if (line.Length > 0)
            {
                if (line[0] == '$')
                {
                    AppendLineToTextBox(textGPSstartus, line, true);
                    if (checkBoxDisplayGpsSentence.Checked == false)
                    {
                        logEnable = false;
                    }
                }
                else if ((line.Contains("+QISEND")) ||
                    (line.Contains("+QISACK")) ||
                    (line.Contains("7E")) ||
                    (line.Contains("+CSQ")))
                {
                    AppendLineToTextBox(textBoxGprsMessage1, line, true);
                    if (checkBoxGPRS4Glogs.Checked == false)
                    {
                        logEnable = false;
                    }
                }
                if (line.Contains("7E"))
                {
                    AppendLineToTextBox(textBoxLogsData, line, true);
                    string length = line.Substring(2,4);
                    textBoxLength.Text = length;
                    string Protocolnumber = line.Substring(6,4);
                    textBoxProtocol.Text = Protocolnumber;
                    string imei = line.Substring(11,15);
                    textBoxImeiData.Text = imei;
                    string timeDTC = line.Substring(26,12);
                    textBoxDeviceDTC.Text = timeDTC;
                    string packetNum = line.Substring(38,4);
                    textBoxPacketSNum.Text = packetNum;
                    string Frame = line.Substring(42,2);
                    textBoxFrame.Text = Frame;
                    if (line.Substring(42, 2)=="E8")
                    {
                        string GPSlength = line.Substring(44, 2);
                        textBoxGPSLength.Text = GPSlength;
                        string Lat = line.Substring(46, 8);
                        textBoxLat.Text = Lat;
                        string Long = line.Substring(54, 8);
                        textBoxLong.Text = Long;
                        string Alt = line.Substring(62, 4);
                        textBoxAlt.Text = Alt;
                        string GPSTime = line.Substring(66, 12);
                        textBoxGpsTime.Text = GPSTime;
                        string GPSSpeed = line.Substring(78, 4);
                        textBoxGpsSpeed.Text = GPSSpeed;
                        string GPSStatus = line.Substring(82, 4);
                        textBoxGpsStatus.Text = GPSStatus;
                        string EHPError = line.Substring(86, 2);
                        textBoxEHPError.Text = EHPError;
                        var EVPError = line.Substring(88, 2);
                        textBoxEVPError.Text = EVPError;
                        var StatusLength = line.Substring(90, 2);
                        textBoxStatusLength.Text = StatusLength;
                        var EventID = line.Substring(92, 8);
                        textBoxEventID.Text = EventID;
                        var TerminalStatus = line.Substring(100, 8);
                        textBoxTerminalStatus.Text = TerminalStatus;
                        var PowerStatus = line.Substring(108, 4);
                        textBoxPowerSupply.Text = PowerStatus;
                        var IOStatus = line.Substring(112, 2);
                        textBoxIOStatus.Text = IOStatus;
                        var ADA = line.Substring(114, 4);
                        textBoxADAData.Text = ADA;
                        var ADB = line.Substring(118, 4);
                        textBoxADBData.Text = ADB;
                        var TotalKMday = line.Substring(122, 6);
                        textBoxKMperDay.Text = TotalKMday;
                        var SpeedLength = line.Substring(128, 2);
                        textBoxSpeedLength.Text = SpeedLength;
                        var SpeedData = line.Substring(2, 4);
                        //textBoxSpeedData.Text = SpeedData;
                        var Drive4h = line.Substring(2, 4);
                        //textBoxDriver4h.Text = Drive4h;
                        var Drive10h = line.Substring(2, 4);
                        //textBoxDrive10h.Text = Drive10h;
                        var IDLength = line.Substring(2, 4);
                        //textBoxDriverDataLength.Text = IDLength;
                        var DriveID = line.Substring(2, 4);
                        //textBoxDriverID.Text = DriveID;
                        var DriveName = line.Substring(2, 4);
                        //textBoxDriveName.Text = DriveName;

                        var ComLength = line.Substring(line.Length - 16, 4);
                        //textBoxCOMInfoLength.Text = ComLength;
                        var ComType = line.Substring(2, 4);
                        //textBoxComType.Text = ComType;
                        var ComData = line.Substring(2, 4);
                        //textBoxComData.Text = ComData;
                        var WireLength = line.Substring(2, 4);
                        //textBoxWireInfoLength.Text = WireLength;
                        var WireType = line.Substring(2, 4);
                        //textBoxWireType.Text = WireType;
                        var WireData = line.Substring(2, 4);
                        //textBoxWireData.Text = WireData;
                        var SpareLength = line.Substring(2, 4);
                        //textBoxSpareInfoLength.Text = SpareLength;

                    }
                    var LBSLength = line.Substring(line.Length - 28, 2);
                    textBoxLBSInfoLength.Text = LBSLength;
                    var GSMRSSI = line.Substring(line.Length - 26, 2);
                    textBoxGSMRssi.Text = GSMRSSI;
                    var GPSRSSI = line.Substring(line.Length - 24, 2);
                    textBoxGPSRssi.Text = GPSRSSI;
                    var Satellites = line.Substring(line.Length - 22, 2);
                    textBoxSatellite.Text = Satellites;
                    var CellID = line.Substring(20, 8);
                    textBoxCellID.Text = CellID;
                    var LAC = line.Substring(line.Length - 12, 4);
                    textBoxLAC.Text = LAC;
                    
                    var Checksum = line.Substring(line.Length - 8, 4);
                    textBoxChecksum.Text = Checksum;
                    var EndMark = line.Substring(line.Length - 4, 4);
                    textBoxEndMark.Text = EndMark;

                }

                else if (line.Contains("-E-") || line.Contains("-E0") ||
                     line.Contains("Can not") || line.Contains("can not") ||
                      line.Contains("failed") || line.Contains("fail") || line.Contains("false"))
                {
                    AppendLineToTextBox(textBoxErrorLog, line, true);
                    if (checkBoxErrorLog.Checked == false)
                    {
                        logEnable = false;
                    }
                }
                else if (line.Contains("-BLD-"))
                {
                    bootLoaderRxResponseQueue.Enqueue(line);
                    logEnable = false;
                }

                if (line.Contains("-RtcInfo"))
                {
                    //string[] rtcInfo = line.Split(',');
                    //textBoxRtcInfo.Text = rtcInfo[1];
                }


                else if (line.Contains("-I-DCE IMEI:"))
                {
                    string[] imei = line.Split(':');
                    textBoxImei.Text = imei[1];
                    textBoxImeidevice.Text = imei[1];
                }
                else if (line.Contains("-I-SimCard CCID:"))
                {
                    string[] CCID = line.Split(':');
                    textBoxCCID1.Text = CCID[1];
                    textBoxCCIDSim.Text = CCID[1];
                }

                else if (line.Contains("-I-FW Version:"))
                {
                    string[] fwer = line.Split(':'); 
                    var FW = Regex.Split(line, @"[\.]");
                    var var1 = bootloaderProcessing.FirmwareVersion[3].ToString();
                    var var2 = FW[FW.Length - 1];
                    textBoxFwRev.Text = var2 + " - " + var1;
                    textBoxFWVer.Text = fwer[1];

                    int fw1 = int.Parse(var1);
                    int fw2 = int.Parse(var2);
                    if (fw1 < fw2)
                    {
                        if (CheckboxUpdate.Checked)
                        {
                            buttonRebootToDFUMode2.PerformClick();

                        }

                    }

                }
                else if (line.Contains("-I-Get data Sensor SHT30:"))
                {
                    var tempA = new Regex(@"RH; (\d*[.]\d*)*");
                    var groups = tempA.Match(line).Groups;

                    textBoxTempB.Text = groups[1].Value;
                    textBoxTempB1.Text = groups[1].Value;

                    var tempB = new Regex(@"C (\d*[.]\d*)*");
                    var groupsRHA = tempB.Match(line).Groups;

                    textBoxTempC.Text = groupsRHA[1].Value;
                    textBoxHR1.Text = groupsRHA[1].Value;

                    var tempD = new Regex(@"(\d*[.]\d*)* RH ,");
                    var groupsRHB = tempD.Match(line).Groups;

                    textBoxTempD.Text = groupsRHB[1].Value;
                    textBoxHR2.Text = groupsRHB[1].Value;

                    var tempC = new Regex(@"SHT30:  (\d*[.]\d*)*");
                    var grouptempa = tempC.Match(line).Groups;

                    textBoxTempA.Text = grouptempa[1].Value;
                    textBoxTempA1.Text = grouptempa[1].Value;

                }


                else if (line.Contains("-I-TxPacket"))
                {
                    string[] time = line.Split('-');
                    textBoxTime.Text = time[3];
                    textBoxTimeDatalog.Text = time[3];
                }

                else if (line.Contains("+CSQ:"))
                {
                    string[] time = line.Split(':');
                    textBoxPos.Text = time[1];
                    textBoxCSQ1.Text = time[1];

                }
                else if (line.Contains("***************************"))
                {

                    var bootloader = new Regex(@"Rev(\d*[.]\d*)");
                    var groupbld = bootloader.Match(line).Groups;

                    textBoxBootloader.Text = groupbld[1].Value;
                    textBoxBootloaderdata.Text = groupbld[1].Value;
                }
                else if (line.Contains("-I--ADA:"))
                {
                    var regex = new Regex(@"ADB:(\d*[.]\d*)");
                    var groups = regex.Match(line).Groups;
                    // var regexb = new Regex(@"ADB:(\d*[.]\d*)");
                    // var groupb= regexb.Match(line).Groups;

                    textBoxADB.Text = groups[1].Value;
                    textBoxADB1.Text = groups[1].Value;
                    // textBoxADB.Text = groupb[1].Value;

                    var regex1 = new Regex(@"ADA:(\d*[.]\d*)V");
                    var groups1 = regex1.Match(line).Groups;

                    textBoxADA.Text = groups1[1].Value;
                    textBoxADA1.Text = groups1[1].Value;

                    var regex2 = new Regex(@"Vbat:(\d*[.]\d*)V");
                    var groups2 = regex2.Match(line).Groups;

                    textBoxVbat.Text = groups2[1].Value;
                    textBoxVbat1.Text = groups2[1].Value;

                    var regex3 = new Regex(@"Vpower:(\d*[.]\d*)V");
                    var groups3 = regex3.Match(line).Groups;

                    textBoxPower.Text = groups3[1].Value;
                    textBoxPW1.Text = groups3[1].Value;

                    var regex4 = new Regex(@"I/O: (\d*),");
                    var groups4 = regex4.Match(line).Groups;
                    var regexc = new Regex(@"I/O : (\d*)");
                    var groupsc = regexc.Match(line).Groups;
                    textBoxIO.Text = groupsc[1].Value;
                    textBoxIO.Text = groups4[1].Value;
                    textBoxIO1.Text = groups4[1].Value;
                    var regex5 = new Regex(@"Temp:(\d*[.]\d*)");
                    var groups5 = regex5.Match(line).Groups;

                    textBoxTempA.Text = groups5[1].Value;
                    textBoxTempA1.Text = groups5[1].Value;

                }


                else if (line.Contains("Temp:"))
                {
                    string[] time = line.Split(':');
                    textBoxTempA.Text = time[1];
                }




                // Add log to main display
                if (logEnable == true)
                {
                    AppendLineToTextBox(textBoxDeviceLogs, line, checkBoxAutoScrollDeviceLogs.Checked); //System.Windows.Forms.Timer.
                }
            }
        }

        private void timerSerialPortDataHandler_Tick(object sender, EventArgs e)
        {
            timerSerialPortRxDataParsing.Stop();

            // Read and parse log message, store result into queue
            ReadLogLineFromSerialPort();

            // Check and send command to device
            if (!commandStrQueue.IsEmpty)
            {
                string cmd;
                commandStrQueue.TryDequeue(out cmd);
                serialPort.WriteLine(cmd);
                //listBoxLog.Log(Level.Info, "Written command to client: " + cmd);
                textBoxErrorLog.Text += "Written command to client: " + cmd + Environment.NewLine;
            }

            // Check and send bootloader packet to device
            if (!bootLoaderTxPacketQueue.IsEmpty)
            {
                Byte[] bootloaderPacket;
                bootLoaderTxPacketQueue.TryDequeue(out bootloaderPacket);
                serialPort.Write(bootloaderPacket, 0, bootloaderPacket.Length);
            }

            // Processing bootloader Rx/Tx packet
            if (bootloaderProcessing.IsValid == true)
            {
                BootloaderProcessingHandler();
            }

            // Display log message
            if (devideLogUpdateCounter++ > 50)
            {
                int numberOfLine = rcvLinesQueue.Count;
                if (numberOfLine > 0)
                {
                    for (int i = 0; i < numberOfLine; i++)
                    {
                        ParseLogMessage(rcvLinesQueue.Dequeue());
                    }
                }

                //textBoxDeviceLogs.Text += serialPortReceivedBuffer.ToString() ;
                //serialPortReceivedBuffer.Clear();
                //if (checkBoxAutoScrollDeviceLogs.Checked)
                //{
                //    textBoxDeviceLogs.SelectionStart = textBoxDeviceLogs.Text.Length;
                //    textBoxDeviceLogs.ScrollToCaret();
                //    textBoxDeviceLogs.Refresh();
                //}
            }
            timerSerialPortRxDataParsing.Start();
        }

        private void AppendLineToTextBox(TextBox textbox, string text, bool autoscroll)
        {
            int savedVpos = GetScrollPos(textbox.Handle, SB_VERT);
            textbox.AppendText(text + Environment.NewLine);
            if (autoscroll)
            {
                int VSmin, VSmax;
                GetScrollRange(textbox.Handle, SB_VERT, out VSmin, out VSmax);
                int sbOffset = (int)((textbox.ClientSize.Height - SystemInformation.HorizontalScrollBarHeight) / (textbox.Font.Height));
                savedVpos = VSmax - sbOffset;
            }
            SetScrollPos(textbox.Handle, SB_VERT, savedVpos, true);
            PostMessageA(textbox.Handle, WM_VSCROLL, SB_THUMBPOSITION + 0x10000 * savedVpos, 0);
        }

        #endregion

        #region Bootloader processing

        BootloaderProcessing bootloaderProcessing = new BootloaderProcessing();
        private string binaryFirmwareFilePath = string.Empty;
        const string CMD_REBOOT_INTO_BOOTLOADER_MODE = "*TVN686,993#";
        const string CMD_DEFAULT_FIRWARE = "*300190,990,099#";
        const string CMD_DELETE_FLASH = "*300190,500#";
        const string CMD_RESET = "*300190,991#";
        const string CMD_TVN02 = "*000000,001,300190#\n\r*300190,011,e-connect,,#\n\r*300190,015,1,gps.tracking.vn,18860#\n\r*300190,016,1,#\n\r*300190,018,30,999#";
        const string CMD_TVN05 = "*000000,001,300190#\n\r*300190,011,e-connect,,#\n\r*300190,015,1,gps.tracking.vn,20022#\n\r*300190,016,1,#\n\r*300190,018,30,999#";
        const string CMD_TVNTest = "*000000,001,300190#\n\r*300190,011,e-connect,,#\n\r*300190,015,1,gps.tracking.vn,19860#\n\r*300190,016,1,#\n\r*300190,018,30,999#";
        private void buttonOpenBinaryFWFile_Click(object sender, EventArgs e)
        {
            // Load directory of picture and init image infor
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png) |*.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFile.Filter = "Binary firmware files (*.bin) |*.bin";

            string fileDir = string.Empty;
            try
            {
                fileDir = Path.GetDirectoryName(Properties.Settings.Default.LastOpenFirmwareFilePath);
            }
            catch (Exception ex)
            {

            }
            if (Directory.Exists(fileDir))
            {
                openFile.InitialDirectory = fileDir;
            }

            bootloaderProcessing.IsValid = false;
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    // display file name
                    textBoxFirmwareFilePath1.Text = openFile.FileName;
                    textBoxFirmwareFilePath1.Focus();
                    textBoxFirmwareFilePath1.SelectionStart = textBoxFirmwareFilePath.Text.Length;
                    textBoxFirmwareFilePath1.ScrollToCaret();
                    textBoxFirmwareFilePath1.Refresh();

                    if (bootloaderProcessing.ReadBinaryFile(openFile.FileName) == true)
                    {
                        listBoxLog.Log(Level.Info, String.Format("Read file successfully, fimware version {0}.{1}.{2}.{3}",
                            bootloaderProcessing.FirmwareVersion[0],
                            bootloaderProcessing.FirmwareVersion[1],
                            bootloaderProcessing.FirmwareVersion[2],
                            bootloaderProcessing.FirmwareVersion[3]));
                        listBoxLog.Log(Level.Info, "Total packet: " + bootloaderProcessing.TotalPacket.ToString());
                        bootloaderProcessing.IsValid = true;

                        // Save file name
                        textBoxFirmwareFilePath1.Text = openFile.FileName;
                        Properties.Settings.Default.LastOpenFirmwareFilePath = openFile.FileName;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        listBoxLog.Log(Level.Error, String.Format("Read file failed"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File access error!");
                }
            }

        }
        private void buttonOpenFWFile_Click(object sender, EventArgs e)
        {
            // Load directory of picture and init image infor
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png) |*.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFile.Filter = "Binary firmware files (*.bin) |*.bin";

            string fileDir = string.Empty;
            try
            {
                fileDir = Path.GetDirectoryName(Properties.Settings.Default.LastOpenFirmwareFilePath);
            }
            catch (Exception ex)
            {

            }
            if (Directory.Exists(fileDir))
            {
                openFile.InitialDirectory = fileDir;
            }

            bootloaderProcessing.IsValid = false;
            DialogResult result = openFile.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    // display file name
                    textBoxFirmwareFilePath1.Text = openFile.FileName;
                    textBoxFirmwareFilePath1.Focus();
                    textBoxFirmwareFilePath1.SelectionStart = textBoxFirmwareFilePath.Text.Length;
                    textBoxFirmwareFilePath1.ScrollToCaret();
                    textBoxFirmwareFilePath1.Refresh();

                    if (bootloaderProcessing.ReadBinaryFile(openFile.FileName) == true)
                    {
                        listBoxLog.Log(Level.Info, String.Format("Read file successfully, fimware version {0}.{1}.{2}.{3}",
                            bootloaderProcessing.FirmwareVersion[0],
                            bootloaderProcessing.FirmwareVersion[1],
                            bootloaderProcessing.FirmwareVersion[2],
                            bootloaderProcessing.FirmwareVersion[3]));
                        listBoxLog.Log(Level.Info, "Total packet: " + bootloaderProcessing.TotalPacket.ToString());
                        bootloaderProcessing.IsValid = true;

                        // Save file name
                        textBoxFirmwareFilePath1.Text = openFile.FileName;
                        Properties.Settings.Default.LastOpenFirmwareFilePath = openFile.FileName;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        listBoxLog.Log(Level.Error, String.Format("Read file failed"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File access error!");
                }
            }

        }
        private void buttonRebootToBootloaderMode_Click(object sender, EventArgs e)
        {
            if (isDeviceConnected)
            {
                // Open file
                if (File.Exists(Properties.Settings.Default.LastOpenFirmwareFilePath))
                {
                    textBoxFirmwareFilePath.Text = Properties.Settings.Default.LastOpenFirmwareFilePath;
                    try
                    {
                        // display file name
                        textBoxFirmwareFilePath1.Focus();
                        textBoxFirmwareFilePath1.SelectionStart = textBoxFirmwareFilePath1.Text.Length;
                        textBoxFirmwareFilePath1.ScrollToCaret();
                        textBoxFirmwareFilePath1.Refresh();

                        if (bootloaderProcessing.ReadBinaryFile(Properties.Settings.Default.LastOpenFirmwareFilePath) == true)
                        {
                            listBoxLog.Log(Level.Info, String.Format("Read file successfully, fimware version {0}.{1}.{2}.{3}",
                                bootloaderProcessing.FirmwareVersion[0],
                                bootloaderProcessing.FirmwareVersion[1],
                                bootloaderProcessing.FirmwareVersion[2],
                                bootloaderProcessing.FirmwareVersion[3]));
                            listBoxLog.Log(Level.Info, "Total packet: " + bootloaderProcessing.PacketList.Count.ToString());
                            bootloaderProcessing.IsValid = true;
                        }
                        else
                        {
                            listBoxLog.Log(Level.Error, String.Format("Read file failed, please open file again"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("File access error, please open again!");
                    }
                }

                if (bootloaderProcessing.IsValid == true)
                {
                    // Clear Rx queue
                    bootLoaderRxResponseQueue.Clear();
                    listBoxLog.Log(Level.Verbose, String.Format("Clear bootLoaderRxResponseQueue"));
                    // Send command
                    commandStrQueue.Enqueue(CMD_REBOOT_INTO_BOOTLOADER_MODE);

                    bootloaderProcessing.State = BootloaderProcessingState.WAITING_DEVICE_BOOTUP;
                    bootloaderProcessing.NextTxPacketNo = 0;
                    bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
                    // Add addition query state command into Tx queue
                    bootLoaderTxPacketQueue.Enqueue(bootloaderProcessing.CommandQueryDeviceState);
                    bootLoaderTxPacketQueue.Enqueue(bootloaderProcessing.CommandQueryDeviceState);

                    // update process bar
                    progressBarFirmwareUpdate.Maximum = bootloaderProcessing.TotalPacket;
                    progressBarFirmwareUpdate.Value = 0;
                }
                else
                {
                    MessageBox.Show("Please open a correct binary file");
                }
            }
            else
            {
                MessageBox.Show("Port is not openned");
            }
        }

        private int packetNACKCounter = 0;
        private void BootloaderProcessingHandler()
        {
            if (bootloaderProcessing.State == BootloaderProcessingState.WAITING_DEVICE_BOOTUP)
            {
                if (bootLoaderRxResponseQueue.Count > 0)
                {
                    string resp = bootLoaderRxResponseQueue.Dequeue();
                    if (resp.Contains("-BLD-START") || resp.Contains("-BLD-ACK"))
                    {
                        bootloaderProcessing.State = BootloaderProcessingState.SEND_CMD_ERASE;
                        listBoxLog.Log(Level.Info, String.Format("Device entered bootloader mode, start programing..."));
                        progressBarFirmwareUpdate.Value++;
                    }
                }
                else
                {
                    if (bootloaderProcessing.WaitingForResponseTimeoutCounter == (5000 / SERIAL_PORT_DATA_HANDLER_INTERVAL))
                    {
                        // Send command one more time
                        //commandStrQueue.Enqueue(CMD_REBOOT_INTO_BOOTLOADER_MODE);
                        // Add addition query state command into Tx queue
                        bootLoaderTxPacketQueue.Enqueue(bootloaderProcessing.CommandQueryDeviceState);
                    }
                }

                if (bootloaderProcessing.State == BootloaderProcessingState.WAITING_DEVICE_BOOTUP)
                {
                    bootloaderProcessing.WaitingForResponseTimeoutCounter++;
                    if (bootloaderProcessing.WaitingForResponseTimeoutCounter >= (30000 / SERIAL_PORT_DATA_HANDLER_INTERVAL))
                    {
                        bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
                        listBoxLog.Log(Level.Error, String.Format("Device can not enter bootloader mode, fw update is cancelled, please reboot device"));
                        bootloaderProcessing.IsValid = false;
                        bootloaderProcessing.State = BootloaderProcessingState.IDLE;
                    }
                }
            }
            else if (bootloaderProcessing.State == BootloaderProcessingState.SEND_CMD_ERASE)
            {
                // Clear resp queue
                bootLoaderRxResponseQueue.Clear();
                bootLoaderTxPacketQueue.Enqueue(bootloaderProcessing.PacketList[0]);
                bootloaderProcessing.State = BootloaderProcessingState.SEND_NEXT_DATAPACKET;
                bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
            }
            else if (bootloaderProcessing.State == BootloaderProcessingState.SEND_NEXT_DATAPACKET)
            {
                if (bootLoaderRxResponseQueue.Count > 0)
                {
                    string respLine = bootLoaderRxResponseQueue.Dequeue();
                    if (respLine.Contains("-BLD-ACK"))
                    {
                        if (progressBarFirmwareUpdate.Value < progressBarFirmwareUpdate.Maximum)
                        {
                            progressBarFirmwareUpdate.Value++;
                        }
                        //bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
                        packetNACKCounter = 0;
                        // Send next packet
                        int respPacketNo;
                        string[] field = respLine.Split(',');
                        respPacketNo = Convert.ToInt32(field[4]);

                        // Clear resp queue
                        bootLoaderRxResponseQueue.Clear();
                        if (respPacketNo < (bootloaderProcessing.TotalPacket - 1))
                        {
                            listBoxLog.Log(Level.Info, String.Format("Packet no {0}", respPacketNo));
                            bootLoaderTxPacketQueue.Enqueue(bootloaderProcessing.PacketList[respPacketNo + 1]);
                        }
                        else
                        {
                            listBoxLog.Log(Level.Info, String.Format("Packet no {0}, stop fw update", respPacketNo));
                            bootloaderProcessing.IsValid = false;
                            bootloaderProcessing.State = BootloaderProcessingState.IDLE;
                            progressBarFirmwareUpdate.Value = 0;
                        }
                        return;
                    }
                    else if (respLine.Contains("-BLD-NACK"))
                    {
                        bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
                        // Send packet again
                        int respPacketNo;
                        string[] field = respLine.Split(',');
                        respPacketNo = Convert.ToInt32(field[4]);
                        listBoxLog.Log(Level.Warning, String.Format("Get not ack response packet of packet no {0}, send data packet agian", respPacketNo));
                        bootLoaderTxPacketQueue.Enqueue(bootloaderProcessing.PacketList[respPacketNo]);
                        if (packetNACKCounter++ > 10)
                        {
                            listBoxLog.Log(Level.Error, String.Format("Packet number {0} Not Ack = {1}, fw update is cancelled, please reboot device", respPacketNo, packetNACKCounter));
                            bootloaderProcessing.State = BootloaderProcessingState.IDLE;
                            bootloaderProcessing.IsValid = false;
                            progressBarFirmwareUpdate.Value = 0;
                        }
                        return;
                    }
                    else if (respLine.Contains("-BLD-ERROR"))
                    {
                        bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
                        UInt64 errorAddress = 0;
                        UInt64 writtenValue = 0;
                        UInt64 readBackValue = 0;
                        // Get value from response
                        bootloaderProcessing.IsValid = false;
                        progressBarFirmwareUpdate.Value = 0;
                        bootloaderProcessing.State = BootloaderProcessingState.IDLE;
                        listBoxLog.Log(Level.Error, String.Format("Programming error @ {0:X8}H, written = {1:X8}H, read back = {2:X8}H", errorAddress, writtenValue, readBackValue));
                        return;
                    }
                    else if (!respLine.Contains("-BLD-START"))
                    {
                        bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
                        listBoxLog.Log(Level.Error, String.Format("Unknown device response \"{0}\", fw update is cancelled, please reboot device ", respLine));
                        bootloaderProcessing.IsValid = false;
                        bootloaderProcessing.State = BootloaderProcessingState.IDLE;
                        progressBarFirmwareUpdate.Value = 0;
                    }
                    if (bootloaderProcessing.State == BootloaderProcessingState.SEND_NEXT_DATAPACKET)
                    {
                        bootloaderProcessing.WaitingForResponseTimeoutCounter++;
                        if (bootloaderProcessing.WaitingForResponseTimeoutCounter >= (30000 / SERIAL_PORT_DATA_HANDLER_INTERVAL))
                        {
                            bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
                            listBoxLog.Log(Level.Error, String.Format("Waiting response from device is timedout, fw update is cancelled, please reboot device"));
                            bootloaderProcessing.State = BootloaderProcessingState.IDLE;
                            bootloaderProcessing.IsValid = false;
                            progressBarFirmwareUpdate.Value = 0;
                        }
                    }
                }
                if (bootloaderProcessing.State == BootloaderProcessingState.SEND_NEXT_DATAPACKET)
                {
                    bootloaderProcessing.WaitingForResponseTimeoutCounter++;
                    if (bootloaderProcessing.WaitingForResponseTimeoutCounter >= (15000 / SERIAL_PORT_DATA_HANDLER_INTERVAL))
                    {
                        bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
                        listBoxLog.Log(Level.Error, String.Format("Waiting response from device is timedout, fw update is cancelled, please reboot device"));
                        bootloaderProcessing.State = BootloaderProcessingState.IDLE;
                        bootloaderProcessing.IsValid = false;
                        progressBarFirmwareUpdate.Value = 0;
                    }
                }
            }
        }

        #endregion

        [STAThread]
        internal static void Main() { Application.Run(new FrmMain()); }
        private static FrmMain _transDefaultFormFrmMain;
        internal static FrmMain TransDefaultFormFrmMain
        {
            get
            {
                if (_transDefaultFormFrmMain == null)
                {
                    _transDefaultFormFrmMain = new FrmMain();
                }
                return _transDefaultFormFrmMain;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            //progressBarFirmwareUpdate.Loca
            int formWith = this.Width;
            //MessageBox.Show(formWith.ToString());
            labelFirmwareUpdateProcess.Margin = new Padding(formWith - 550, 3, 0, 2);
        }

        private void buttonWriteSettingToDevice_Click(object sender, EventArgs e)
        {
            if (isDeviceConnected)
            {
                // Read command from text box
                string[] commands = textBoxCommandList.Text.Split('\r', '\n');
                foreach (string cmd in commands)
                {
                    string message = cmd.Trim() + Environment.NewLine;
                    if (message.Length > 6 && ((message[0] == '*') || (message[0] == '@')))
                    {
                        commandStrQueue.Enqueue(message);
                        //listBoxLog.Log(Level.Info, "Enqueue command to client: " + cmd);
                    }
                }
            }
        }


        private void buttonDefault_Click(object sender, EventArgs e)
        {
            if (isDeviceConnected)
            {
                // Read command from text box
                commandStrQueue.Enqueue(CMD_DEFAULT_FIRWARE);
            }

        }

        private void buttonDeleteFlash_Click(object sender, EventArgs e)
        {
            if (isDeviceConnected)
            {
                // Read command from text box
                commandStrQueue.Enqueue(CMD_DELETE_FLASH);
            }
        }

        private void buttonTvn02_Click(object sender, EventArgs e)
        {
            if (isDeviceConnected)
            {
                // Read command from text box
                commandStrQueue.Enqueue(CMD_TVN02);
            }
        }

        private void buttonTvn05_Click(object sender, EventArgs e)
        {
            if (isDeviceConnected)
            {
                // Read command from text box
                commandStrQueue.Enqueue(CMD_TVN05);
            }
        }

        private void buttonClearLog_Click(object sender, EventArgs e)
        {
            textBoxErrorLog.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxGprsMessage1.Clear();
        }
        #region Method


        void CreateColumForDataGridView()
        {
            var colIMEI = new DataGridViewTextBoxColumn();
            var colCCID = new DataGridViewTextBoxColumn();
            var colBootloader = new DataGridViewTextBoxColumn();
            var colFirmware = new DataGridViewTextBoxColumn();
            var colTime = new DataGridViewTextBoxColumn();
            var colTempA = new DataGridViewTextBoxColumn();
            var colTempB = new DataGridViewTextBoxColumn();
            var colPower = new DataGridViewTextBoxColumn();
            var colIO = new DataGridViewTextBoxColumn();
            var colCSQ = new DataGridViewTextBoxColumn();
            var colADA = new DataGridViewTextBoxColumn();
            var colADB = new DataGridViewTextBoxColumn();

            colIMEI.HeaderText = "Imei";
            colCCID.HeaderText = "CCID";
            colFirmware.HeaderText = "Firmware";
            colBootloader.HeaderText = "Bld";
            colTime.HeaderText = "TimeLogs";
            colCSQ.HeaderText = "CSQ";
            colPower.HeaderText = "Power";
            colTempA.HeaderText = "TempA";
            colTempB.HeaderText = "TempB";
            colIO.HeaderText = "IO";
            colADA.HeaderText = "ADA";
            colADB.HeaderText = "ADB";

            colIMEI.Width = 220;
            colCCID.Width = 250;

            dataGridViewLogs.Columns.AddRange(new DataGridViewColumn[] { colIMEI, colFirmware, colCCID, colBootloader, colTime, colTempA, colTempB, colCSQ, colIO, colADA, colADB });

        }

        void LoadListView()
        {
            dataGridViewLogs.DataSource = ListImei.Instance.ListImeiDevice;
        }
        #endregion

        void EnableControls(bool isEnableTextBox, bool isEnableDataGridView)
        {
            textBoxFWVer.Enabled = textBoxBootloaderdata.Enabled = textBoxImeidevice.Enabled = textBoxCCIDSim.Enabled = textBoxCCIDSim.Enabled = textBoxTimeDatalog.Enabled = textBoxTempA1.Enabled = textBoxTempB1.Enabled = textBoxHR1.Enabled = textBoxHR2.Enabled = textBoxPW1.Enabled = textBoxIO1.Enabled = textBoxADA1.Enabled = textBoxADB1.Enabled = textBoxCSQ1.Enabled = textBoxVbat1.Enabled = isEnableTextBox;
            dataGridViewLogs.Enabled = isEnableDataGridView;
        }
        private void buttonClear1_Click(object sender, EventArgs e)
        {
            textBoxDeviceLogs.Clear();
            textBoxImei.Clear();
            textBoxErrorLog.Clear();
            textBoxGprsMessage1.Clear();
            textBoxDeviceLogs.Clear();
            textBoxImei.Clear();
            textBoxGprsMessage1.Clear();
            textBoxADA.Clear();
            textBoxADB.Clear();
            textBoxCCID1.Clear();
            textBoxDeviceErrorMessage.Clear();
            textBoxBootloader.Clear();
            textBoxFwRev.Clear();
            textBoxPower.Clear();
            textBoxTempA.Clear();
            textBoxTempB.Clear();
            textBoxTempC.Clear();
            textBoxVbat.Clear();
            textBoxTime.Clear();
            textBoxPos.Clear();
            textBoxIO.Clear();
            listBoxFirmwareUpdateLog1.ClearSelected();
            textBoxGprsMessage.Clear();
            textBoxGpsMessage.Clear();
            textBoxTempD.Clear();
            textGPSstartus.Clear();

        }


        private void button7_Click_1(object sender, EventArgs e)
        {
            textBoxDeviceLogs.Clear();
            textBoxGprsMessage1.Clear();
            textBoxErrorLog.Clear();
            textBoxGpsMessage.Clear();
        }


        private void buttonExportTXT_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "(*.txt)|*.txt";
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string  path = saveFileDialog.FileName;  
                for (int i = 0; i < path.Length; i++)
                {
                    File.AppendAllText(path, textBoxDeviceLogs.Text);
                }


                MessageBox.Show("EXPORT LOGS!");
            }
        }

        private void buttonExImei_Click(object sender, EventArgs e)
        {
            string colImei = textBoxImeidevice.Text;
            string colCCID = textBoxCCIDSim.Text;
            string colBootloader = textBoxBootloaderdata.Text; 
            string colTime = textBoxTimeDatalog.Text;
            string colFirmware = textBoxFWVer.Text;
            string colTempA = textBoxTempA1.Text;
            string colTempB = textBoxTempB1.Text;
            string colPower = textBoxPower.Text;
            string colIO = textBoxIO1.Text;
            string colCSQ = textBoxCSQ1.Text;
            string colADA = textBoxADA1.Text;
            string colADB =  textBoxADB1.Text;

            EnableControls(false, true);
            LoadListView();
           /* var colIMEI = new DataGridViewTextBoxColumn();
            var colCCID = new DataGridViewTextBoxColumn();
            var colBootloader = new DataGridViewTextBoxColumn();
            var colFirmware = new DataGridViewTextBoxColumn();
            var colTime = new DataGridViewTextBoxColumn();
            var colTempA = new DataGridViewTextBoxColumn();
            var colTempB = new DataGridViewTextBoxColumn();
            var colPower = new DataGridViewTextBoxColumn();
            var colIO = new DataGridViewTextBoxColumn();
            var colCSQ = new DataGridViewTextBoxColumn();
            var colADA = new DataGridViewTextBoxColumn();
            var colADB = new DataGridViewTextBoxColumn();
           */

        }
        private void ExportExcel(string path)
        {
           // Excel.Application application = new Excel.Application();
           // application.Application.Workbooks.Add(Type.Missing);
           // for (int i = 0; i < DataGridCell.Columns.Count; i++)
          //  {d = DataGridView
           // }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            if (isDeviceConnected)
            {
                // Read command from text box
                commandStrQueue.Enqueue(CMD_RESET);
            }
        }



        private void buttonTvnTest_Click(object sender, EventArgs e)
        {
            if (isDeviceConnected)
            {
                // Read command from text box
                commandStrQueue.Enqueue(CMD_TVNTest);
            }
        }

        private void labelConnectingStatus_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonU8ToText_Click(object sender, EventArgs e)
        {
           /* uint crc8(uint data, uint crc)
            {
                uint i = data ^ crc;
                crc = 0;
                if (i & 0x01) crc ^= 0x5e;
            }*/
        }

        private void dataGridViewLogs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Function_Enter(object sender, EventArgs e)
        {

        }

        private void buttonAddData_Click(object sender, EventArgs e)
        {
            EnableControls(true, false);
        }
    }
}
