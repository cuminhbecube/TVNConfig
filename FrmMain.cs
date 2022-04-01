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
using Excel = Microsoft.Office.Interop.Excel;


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
        private TabPage tabPage8;
        private Panel panel16;
        private GroupBox groupBox8;
        private TextBox textBox2;
        private Panel panel15;
        private GroupBox groupBox9;
        private TextBox textBox1;
        private Panel panel4;
        private Panel panel11;
        private Panel panel19;
        private GroupBox groupBox12;
        private TextBox textBox23;
        private Panel panel18;
        private GroupBox groupBox11;
        private TextBox textBoxQISEND;
        private Panel panel17;
        private GroupBox groupBox10;
        private TextBox textBoxQISACK;
        private GroupBox groupBox7;
        private TextBox textBoxCQS;
        private Panel panel9;
        private GroupBox groupBox6;
        private TextBox textBoxQVBATT;
        private Panel panel6;
        private GroupBox groupBoxCRER;
        private TextBox textBoxCRER;
        private Panel panel3;
        private Panel panel10;
        private Panel panel8;
        private Panel panel7;
        private TextBox textBox25;
        private Label label38;
        private Panel panel2;
        private Panel panel14;
        private TextBox textBox22;
        private TextBox textBox21;
        private TextBox textBox20;
        private TextBox textBox19;
        private TextBox textBox18;
        private TextBox textBox17;
        private TextBox textBox16;
        private TextBox textBox15;
        private TextBox textBox12;
        private TextBox textBox11;
        private TextBox textBox10;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private TextBox textBox6;
        private Panel panel13;
        private Label label33;
        private Label label32;
        private Label label31;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label14;
        private Label label12;
        private Panel panel12;
        private Button button2;
        private Button button1;
        private Panel panel5;
        private Label label39;
        private TextBox textBoxImei2;
        private Label label37;
        private TextBox textBoxTime2;
        private TextBox textBoxCCID;
        private Label label34;
        private TextBox textBoxFwRev2;
        private TextBox textBoxBootloader2;
        private Label label35;
        private Label label36;
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
        private TextBox textBoxDeviceErrorMessage1;
        private GroupBox errorlog;
        private GroupBox gprs4gStartus;
        private TextBox textBoxGprsMessage1;
        private SplitContainer splitContainer3;
        private TextBox textBoxDeviceLogs;
        private CheckBox checkBoxDisplayGpsSentence;
        private CheckBox checkBoxAutoScrollDeviceLogs;
        private Button buttonClearLogs;
        private Button buttonClear1;
        private Splitter splitter1;
        private TabControl tabControlTestList;
        private CheckBox CheckboxUpdate;
        private Button buttonExportTXT;
        private Button button4;
        private Button buttonExImei;
        private Button buttonWriteLogs;
        private Button buttonReset;
        private TextBox textGPSstartus;
        private TextBox textBoxTempD;
        private SplitContainer splitContainer15;
        private SplitContainer splitContainer16;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
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
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panel16 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel19 = new System.Windows.Forms.Panel();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.panel18 = new System.Windows.Forms.Panel();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textBoxQISEND = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.textBoxQISACK = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBoxCQS = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBoxQVBATT = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBoxCRER = new System.Windows.Forms.GroupBox();
            this.textBoxCRER = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label39 = new System.Windows.Forms.Label();
            this.textBoxImei2 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.textBoxTime2 = new System.Windows.Forms.TextBox();
            this.textBoxCCID = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.textBoxFwRev2 = new System.Windows.Forms.TextBox();
            this.textBoxBootloader2 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
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
            this.textBoxCommandList = new System.Windows.Forms.TextBox();
            this.textBoxFwRev = new System.Windows.Forms.TextBox();
            this.textBoxCCID1 = new System.Windows.Forms.TextBox();
            this.textBoxBootloader = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxImei = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonWriteSettingToDevice = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxDisplayGpsSentence = new System.Windows.Forms.CheckBox();
            this.CheckboxUpdate = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoScrollDeviceLogs = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonExportTXT = new System.Windows.Forms.Button();
            this.buttonExImei = new System.Windows.Forms.Button();
            this.buttonClear1 = new System.Windows.Forms.Button();
            this.buttonClearLogs = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
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
            this.textBoxFirmwareFilePath1 = new System.Windows.Forms.TextBox();
            this.buttonRebootToDFUMode2 = new System.Windows.Forms.Button();
            this.buttonOpenFWFile = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.splitContainer15 = new System.Windows.Forms.SplitContainer();
            this.errorlog = new System.Windows.Forms.GroupBox();
            this.textBoxDeviceErrorMessage1 = new System.Windows.Forms.TextBox();
            this.gprs4gStartus = new System.Windows.Forms.GroupBox();
            this.textBoxGprsMessage1 = new System.Windows.Forms.TextBox();
            this.splitContainer16 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textGPSstartus = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBoxFirmwareUpdateLog1 = new System.Windows.Forms.ListBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.textBoxDeviceLogs = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.tabControlTestList = new System.Windows.Forms.TabControl();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
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
            this.tabPage8.SuspendLayout();
            this.panel16.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.panel15.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel19.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.panel18.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.panel17.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBoxCRER.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.errorlog.SuspendLayout();
            this.gprs4gStartus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer16)).BeginInit();
            this.splitContainer16.Panel1.SuspendLayout();
            this.splitContainer16.Panel2.SuspendLayout();
            this.splitContainer16.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.SuspendLayout();
            this.tabControlTestList.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelConnectingStatus,
            this.labelFirmwareUpdateProcess,
            this.progressBarFirmwareUpdate});
            this.statusStrip.Location = new System.Drawing.Point(0, 845);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1482, 22);
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip1";
            // 
            // labelConnectingStatus
            // 
            this.labelConnectingStatus.Name = "labelConnectingStatus";
            this.labelConnectingStatus.Size = new System.Drawing.Size(79, 17);
            this.labelConnectingStatus.Text = "Disconnected";
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
            this.progressBarFirmwareUpdate.ForeColor = System.Drawing.Color.Lime;
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
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.panel16);
            this.tabPage8.Controls.Add(this.panel15);
            this.tabPage8.Controls.Add(this.panel4);
            this.tabPage8.Controls.Add(this.panel3);
            this.tabPage8.Controls.Add(this.panel2);
            this.tabPage8.Location = new System.Drawing.Point(4, 34);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1474, 807);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Test List";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.groupBox8);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(548, 156);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(923, 648);
            this.panel16.TabIndex = 4;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox2);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(923, 648);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox8";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(3, 18);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(917, 627);
            this.textBox2.TabIndex = 1;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.groupBox9);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(203, 156);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(345, 648);
            this.panel15.TabIndex = 3;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBox1);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(345, 648);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "groupBox9";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(339, 627);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel11);
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(203, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1268, 120);
            this.panel4.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel19);
            this.panel11.Controls.Add(this.panel18);
            this.panel11.Controls.Add(this.panel17);
            this.panel11.Controls.Add(this.groupBox7);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(191, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1077, 120);
            this.panel11.TabIndex = 5;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.groupBox12);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel19.Location = new System.Drawing.Point(291, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(786, 120);
            this.panel19.TabIndex = 3;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox23);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox12.Location = new System.Drawing.Point(0, 0);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(786, 120);
            this.groupBox12.TabIndex = 0;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "SENT BYTE";
            // 
            // textBox23
            // 
            this.textBox23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox23.Location = new System.Drawing.Point(3, 18);
            this.textBox23.Multiline = true;
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(780, 99);
            this.textBox23.TabIndex = 0;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.groupBox11);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(217, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(74, 120);
            this.panel18.TabIndex = 2;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.textBoxQISEND);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(0, 0);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(74, 120);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "QISEND";
            // 
            // textBoxQISEND
            // 
            this.textBoxQISEND.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxQISEND.Location = new System.Drawing.Point(3, 18);
            this.textBoxQISEND.Multiline = true;
            this.textBoxQISEND.Name = "textBoxQISEND";
            this.textBoxQISEND.Size = new System.Drawing.Size(68, 99);
            this.textBoxQISEND.TabIndex = 0;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.groupBox10);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel17.Location = new System.Drawing.Point(92, 0);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(125, 120);
            this.panel17.TabIndex = 1;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.textBoxQISACK);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(0, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(125, 120);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "QISACK";
            // 
            // textBoxQISACK
            // 
            this.textBoxQISACK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxQISACK.Location = new System.Drawing.Point(3, 18);
            this.textBoxQISACK.Multiline = true;
            this.textBoxQISACK.Name = "textBoxQISACK";
            this.textBoxQISACK.Size = new System.Drawing.Size(119, 99);
            this.textBoxQISACK.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBoxCQS);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(92, 120);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "CSQ";
            // 
            // textBoxCQS
            // 
            this.textBoxCQS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCQS.Location = new System.Drawing.Point(3, 18);
            this.textBoxCQS.Multiline = true;
            this.textBoxCQS.Name = "textBoxCQS";
            this.textBoxCQS.Size = new System.Drawing.Size(86, 99);
            this.textBoxCQS.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.groupBox6);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(95, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(96, 120);
            this.panel9.TabIndex = 4;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxQVBATT);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(96, 120);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "QVBATT";
            // 
            // textBoxQVBATT
            // 
            this.textBoxQVBATT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxQVBATT.Location = new System.Drawing.Point(3, 18);
            this.textBoxQVBATT.Multiline = true;
            this.textBoxQVBATT.Name = "textBoxQVBATT";
            this.textBoxQVBATT.Size = new System.Drawing.Size(90, 99);
            this.textBoxQVBATT.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBoxCRER);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(95, 120);
            this.panel6.TabIndex = 3;
            // 
            // groupBoxCRER
            // 
            this.groupBoxCRER.Controls.Add(this.textBoxCRER);
            this.groupBoxCRER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCRER.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCRER.Name = "groupBoxCRER";
            this.groupBoxCRER.Size = new System.Drawing.Size(95, 120);
            this.groupBoxCRER.TabIndex = 0;
            this.groupBoxCRER.TabStop = false;
            this.groupBoxCRER.Text = "Backlog NO.";
            this.groupBoxCRER.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBoxCRER
            // 
            this.textBoxCRER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCRER.Location = new System.Drawing.Point(3, 18);
            this.textBoxCRER.Multiline = true;
            this.textBoxCRER.Name = "textBoxCRER";
            this.textBoxCRER.Size = new System.Drawing.Size(89, 99);
            this.textBoxCRER.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(203, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1268, 33);
            this.panel3.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(507, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(761, 33);
            this.panel10.TabIndex = 6;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(283, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(224, 33);
            this.panel8.TabIndex = 5;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.textBox25);
            this.panel7.Controls.Add(this.label38);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(283, 33);
            this.panel7.TabIndex = 4;
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(89, 8);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(184, 22);
            this.textBox25.TabIndex = 1;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 11);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(77, 16);
            this.label38.TabIndex = 0;
            this.label38.Text = "TimeStamp";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel14);
            this.panel2.Controls.Add(this.panel13);
            this.panel2.Controls.Add(this.panel12);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 801);
            this.panel2.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.textBox22);
            this.panel14.Controls.Add(this.textBox21);
            this.panel14.Controls.Add(this.textBox20);
            this.panel14.Controls.Add(this.textBox19);
            this.panel14.Controls.Add(this.textBox18);
            this.panel14.Controls.Add(this.textBox17);
            this.panel14.Controls.Add(this.textBox16);
            this.panel14.Controls.Add(this.textBox15);
            this.panel14.Controls.Add(this.textBox12);
            this.panel14.Controls.Add(this.textBox11);
            this.panel14.Controls.Add(this.textBox10);
            this.panel14.Controls.Add(this.textBox9);
            this.panel14.Controls.Add(this.textBox8);
            this.panel14.Controls.Add(this.textBox7);
            this.panel14.Controls.Add(this.textBox6);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(74, 204);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(126, 597);
            this.panel14.TabIndex = 3;
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(0, 410);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(100, 22);
            this.textBox22.TabIndex = 14;
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(0, 382);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(100, 22);
            this.textBox21.TabIndex = 13;
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(0, 354);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(100, 22);
            this.textBox20.TabIndex = 12;
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(0, 298);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(100, 22);
            this.textBox19.TabIndex = 11;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(0, 242);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(100, 22);
            this.textBox18.TabIndex = 10;
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(0, 214);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 22);
            this.textBox17.TabIndex = 9;
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(0, 326);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(100, 22);
            this.textBox16.TabIndex = 8;
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(0, 270);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(100, 22);
            this.textBox15.TabIndex = 7;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(0, 186);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(100, 22);
            this.textBox12.TabIndex = 6;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(0, 158);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(100, 22);
            this.textBox11.TabIndex = 5;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(0, 130);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 22);
            this.textBox10.TabIndex = 4;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(0, 102);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 22);
            this.textBox9.TabIndex = 3;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(0, 74);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 22);
            this.textBox8.TabIndex = 2;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(0, 46);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 22);
            this.textBox7.TabIndex = 1;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(0, 18);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 22);
            this.textBox6.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.label33);
            this.panel13.Controls.Add(this.label32);
            this.panel13.Controls.Add(this.label31);
            this.panel13.Controls.Add(this.label30);
            this.panel13.Controls.Add(this.label29);
            this.panel13.Controls.Add(this.label28);
            this.panel13.Controls.Add(this.label27);
            this.panel13.Controls.Add(this.label26);
            this.panel13.Controls.Add(this.label25);
            this.panel13.Controls.Add(this.label24);
            this.panel13.Controls.Add(this.label18);
            this.panel13.Controls.Add(this.label17);
            this.panel13.Controls.Add(this.label16);
            this.panel13.Controls.Add(this.label14);
            this.panel13.Controls.Add(this.label12);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel13.Location = new System.Drawing.Point(0, 204);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(74, 597);
            this.panel13.TabIndex = 3;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(11, 413);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 16);
            this.label33.TabIndex = 14;
            this.label33.Text = "label33";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(4, 273);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 16);
            this.label32.TabIndex = 13;
            this.label32.Text = "DCE";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(3, 357);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(52, 16);
            this.label31.TabIndex = 12;
            this.label31.Text = "label31";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(3, 329);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(54, 16);
            this.label30.TabIndex = 11;
            this.label30.Text = "label30";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 49);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 16);
            this.label29.TabIndex = 10;
            this.label29.Text = "I/O PIN";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(4, 245);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(32, 16);
            this.label28.TabIndex = 9;
            this.label28.Text = "DFT";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(3, 77);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(66, 16);
            this.label27.TabIndex = 8;
            this.label27.Text = "ADA VOL";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(4, 298);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 16);
            this.label26.TabIndex = 7;
            this.label26.Text = "label26";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 385);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 16);
            this.label25.TabIndex = 6;
            this.label25.Text = "label25";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(3, 217);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(43, 16);
            this.label24.TabIndex = 5;
            this.label24.Text = "HEAP";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 189);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 16);
            this.label18.TabIndex = 4;
            this.label18.Text = "TP I2C B";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 105);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 3;
            this.label17.Text = "ADB VOL";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 16);
            this.label16.TabIndex = 2;
            this.label16.Text = "TP I2C A";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(4, 133);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 16);
            this.label14.TabIndex = 1;
            this.label14.Text = "TEMP DS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "POWER";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.button2);
            this.panel12.Controls.Add(this.button1);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 150);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(200, 54);
            this.panel12.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "PAUSE";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "CLEAR";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel5.Controls.Add(this.label39);
            this.panel5.Controls.Add(this.textBoxImei2);
            this.panel5.Controls.Add(this.label37);
            this.panel5.Controls.Add(this.textBoxTime2);
            this.panel5.Controls.Add(this.textBoxCCID);
            this.panel5.Controls.Add(this.label34);
            this.panel5.Controls.Add(this.textBoxFwRev2);
            this.panel5.Controls.Add(this.textBoxBootloader2);
            this.panel5.Controls.Add(this.label35);
            this.panel5.Controls.Add(this.label36);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 150);
            this.panel5.TabIndex = 3;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(4, 123);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(39, 16);
            this.label39.TabIndex = 19;
            this.label39.Text = "IMEI";
            // 
            // textBoxImei2
            // 
            this.textBoxImei2.Location = new System.Drawing.Point(44, 120);
            this.textBoxImei2.Name = "textBoxImei2";
            this.textBoxImei2.Size = new System.Drawing.Size(150, 22);
            this.textBoxImei2.TabIndex = 18;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(4, 95);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(41, 16);
            this.label37.TabIndex = 17;
            this.label37.Text = "TIME";
            // 
            // textBoxTime2
            // 
            this.textBoxTime2.Location = new System.Drawing.Point(44, 92);
            this.textBoxTime2.Name = "textBoxTime2";
            this.textBoxTime2.Size = new System.Drawing.Size(150, 22);
            this.textBoxTime2.TabIndex = 16;
            // 
            // textBoxCCID
            // 
            this.textBoxCCID.Location = new System.Drawing.Point(44, 64);
            this.textBoxCCID.Name = "textBoxCCID";
            this.textBoxCCID.Size = new System.Drawing.Size(150, 22);
            this.textBoxCCID.TabIndex = 15;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(5, 67);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(38, 16);
            this.label34.TabIndex = 0;
            this.label34.Text = "CCID";
            // 
            // textBoxFwRev2
            // 
            this.textBoxFwRev2.Location = new System.Drawing.Point(87, 36);
            this.textBoxFwRev2.Name = "textBoxFwRev2";
            this.textBoxFwRev2.Size = new System.Drawing.Size(107, 22);
            this.textBoxFwRev2.TabIndex = 15;
            // 
            // textBoxBootloader2
            // 
            this.textBoxBootloader2.Location = new System.Drawing.Point(135, 8);
            this.textBoxBootloader2.Name = "textBoxBootloader2";
            this.textBoxBootloader2.Size = new System.Drawing.Size(59, 22);
            this.textBoxBootloader2.TabIndex = 2;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(4, 39);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(57, 16);
            this.label35.TabIndex = 11;
            this.label35.Text = "FW REV";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(5, 11);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(124, 16);
            this.label36.TabIndex = 3;
            this.label36.Text = "BOOTLOADER REV";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1474, 807);
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
            this.splitContainer1.Size = new System.Drawing.Size(1468, 801);
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
            this.splitContainer4.Size = new System.Drawing.Size(221, 801);
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
            this.splitContainer5.Panel1.Controls.Add(this.textBoxCommandList);
            this.splitContainer5.Panel1.Controls.Add(this.textBoxFwRev);
            this.splitContainer5.Panel1.Controls.Add(this.textBoxCCID1);
            this.splitContainer5.Panel1.Controls.Add(this.textBoxBootloader);
            this.splitContainer5.Panel1.Controls.Add(this.label41);
            this.splitContainer5.Panel1.Controls.Add(this.label1);
            this.splitContainer5.Panel1.Controls.Add(this.textBoxImei);
            this.splitContainer5.Panel1.Controls.Add(this.label11);
            this.splitContainer5.Panel1.Controls.Add(this.buttonWriteSettingToDevice);
            this.splitContainer5.Panel1.Controls.Add(this.label4);
            this.splitContainer5.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.AutoScroll = true;
            this.splitContainer5.Panel2.Controls.Add(this.checkBox1);
            this.splitContainer5.Panel2.Controls.Add(this.checkBox2);
            this.splitContainer5.Panel2.Controls.Add(this.checkBox3);
            this.splitContainer5.Panel2.Controls.Add(this.checkBoxDisplayGpsSentence);
            this.splitContainer5.Panel2.Controls.Add(this.CheckboxUpdate);
            this.splitContainer5.Panel2.Controls.Add(this.checkBoxAutoScrollDeviceLogs);
            this.splitContainer5.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer5.Panel2.Controls.Add(this.groupBoxLogs);
            this.splitContainer5.Panel2.Controls.Add(this.textBoxFirmwareFilePath1);
            this.splitContainer5.Panel2.Controls.Add(this.buttonRebootToDFUMode2);
            this.splitContainer5.Panel2.Controls.Add(this.buttonOpenFWFile);
            this.splitContainer5.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer5.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer5_Panel2_Paint);
            this.splitContainer5.Size = new System.Drawing.Size(221, 736);
            this.splitContainer5.SplitterDistance = 199;
            this.splitContainer5.TabIndex = 0;
            // 
            // textBoxCommandList
            // 
            this.textBoxCommandList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCommandList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCommandList.ForeColor = System.Drawing.Color.Blue;
            this.textBoxCommandList.Location = new System.Drawing.Point(0, 107);
            this.textBoxCommandList.Multiline = true;
            this.textBoxCommandList.Name = "textBoxCommandList";
            this.textBoxCommandList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCommandList.Size = new System.Drawing.Size(218, 57);
            this.textBoxCommandList.TabIndex = 1;
            this.textBoxCommandList.Text = "*300190,990,099#";
            // 
            // textBoxFwRev
            // 
            this.textBoxFwRev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFwRev.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFwRev.Location = new System.Drawing.Point(150, 9);
            this.textBoxFwRev.Name = "textBoxFwRev";
            this.textBoxFwRev.Size = new System.Drawing.Size(69, 22);
            this.textBoxFwRev.TabIndex = 1;
            this.textBoxFwRev.TextChanged += new System.EventHandler(this.textBoxFwRev_TextChanged);
            // 
            // textBoxCCID1
            // 
            this.textBoxCCID1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxCCID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCCID1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCCID1.Location = new System.Drawing.Point(54, 60);
            this.textBoxCCID1.Name = "textBoxCCID1";
            this.textBoxCCID1.ReadOnly = true;
            this.textBoxCCID1.Size = new System.Drawing.Size(164, 22);
            this.textBoxCCID1.TabIndex = 6;
            // 
            // textBoxBootloader
            // 
            this.textBoxBootloader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBootloader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBootloader.Location = new System.Drawing.Point(53, 9);
            this.textBoxBootloader.Name = "textBoxBootloader";
            this.textBoxBootloader.Size = new System.Drawing.Size(50, 22);
            this.textBoxBootloader.TabIndex = 38;
            this.textBoxBootloader.TextChanged += new System.EventHandler(this.textBoxBootloader_TextChanged);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(9, 63);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(42, 16);
            this.label41.TabIndex = 7;
            this.label41.Text = "CCID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "FW:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxImei
            // 
            this.textBoxImei.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxImei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxImei.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImei.Location = new System.Drawing.Point(53, 36);
            this.textBoxImei.Name = "textBoxImei";
            this.textBoxImei.ReadOnly = true;
            this.textBoxImei.Size = new System.Drawing.Size(165, 22);
            this.textBoxImei.TabIndex = 2;
            this.textBoxImei.TextChanged += new System.EventHandler(this.textBoxImei_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 37;
            this.label11.Text = "Blder:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // buttonWriteSettingToDevice
            // 
            this.buttonWriteSettingToDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWriteSettingToDevice.Location = new System.Drawing.Point(12, 170);
            this.buttonWriteSettingToDevice.Name = "buttonWriteSettingToDevice";
            this.buttonWriteSettingToDevice.Size = new System.Drawing.Size(195, 26);
            this.buttonWriteSettingToDevice.TabIndex = 24;
            this.buttonWriteSettingToDevice.Text = "Write Setting To Device";
            this.buttonWriteSettingToDevice.UseVisualStyleBackColor = true;
            this.buttonWriteSettingToDevice.Click += new System.EventHandler(this.buttonWriteSettingToDevice_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "IMEI:";
            // 
            // checkBoxDisplayGpsSentence
            // 
            this.checkBoxDisplayGpsSentence.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxDisplayGpsSentence.AutoSize = true;
            this.checkBoxDisplayGpsSentence.Checked = true;
            this.checkBoxDisplayGpsSentence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisplayGpsSentence.Location = new System.Drawing.Point(8, 390);
            this.checkBoxDisplayGpsSentence.Name = "checkBoxDisplayGpsSentence";
            this.checkBoxDisplayGpsSentence.Size = new System.Drawing.Size(85, 20);
            this.checkBoxDisplayGpsSentence.TabIndex = 0;
            this.checkBoxDisplayGpsSentence.Text = " GPS Logs";
            this.checkBoxDisplayGpsSentence.UseVisualStyleBackColor = true;
            this.checkBoxDisplayGpsSentence.CheckedChanged += new System.EventHandler(this.checkBoxDisplayGpsSentence_CheckedChanged);
            // 
            // CheckboxUpdate
            // 
            this.CheckboxUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckboxUpdate.AutoSize = true;
            this.CheckboxUpdate.Location = new System.Drawing.Point(8, 338);
            this.CheckboxUpdate.Name = "CheckboxUpdate";
            this.CheckboxUpdate.Size = new System.Drawing.Size(105, 20);
            this.CheckboxUpdate.TabIndex = 25;
            this.CheckboxUpdate.Text = "Auto Update";
            this.CheckboxUpdate.UseVisualStyleBackColor = true;
            this.CheckboxUpdate.CheckedChanged += new System.EventHandler(this.CheckboxUpdate_CheckedChanged);
            // 
            // checkBoxAutoScrollDeviceLogs
            // 
            this.checkBoxAutoScrollDeviceLogs.AutoSize = true;
            this.checkBoxAutoScrollDeviceLogs.Checked = true;
            this.checkBoxAutoScrollDeviceLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoScrollDeviceLogs.Location = new System.Drawing.Point(8, 364);
            this.checkBoxAutoScrollDeviceLogs.Name = "checkBoxAutoScrollDeviceLogs";
            this.checkBoxAutoScrollDeviceLogs.Size = new System.Drawing.Size(95, 20);
            this.checkBoxAutoScrollDeviceLogs.TabIndex = 24;
            this.checkBoxAutoScrollDeviceLogs.Text = "Auto scroll";
            this.checkBoxAutoScrollDeviceLogs.UseVisualStyleBackColor = true;
            this.checkBoxAutoScrollDeviceLogs.CheckedChanged += new System.EventHandler(this.checkBoxAutoScrollDeviceLogs_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExportTXT);
            this.groupBox3.Controls.Add(this.buttonExImei);
            this.groupBox3.Controls.Add(this.buttonClear1);
            this.groupBox3.Controls.Add(this.buttonClearLogs);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.buttonDefault);
            this.groupBox3.Controls.Add(this.buttonReset);
            this.groupBox3.Controls.Add(this.buttonWriteLogs);
            this.groupBox3.Controls.Add(this.buttonDeleteFlash);
            this.groupBox3.Controls.Add(this.buttonTvn05);
            this.groupBox3.Controls.Add(this.buttonTvn02);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(221, 167);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Config Button";
            // 
            // buttonExportTXT
            // 
            this.buttonExportTXT.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportTXT.Location = new System.Drawing.Point(5, 74);
            this.buttonExportTXT.Name = "buttonExportTXT";
            this.buttonExportTXT.Size = new System.Drawing.Size(100, 25);
            this.buttonExportTXT.TabIndex = 29;
            this.buttonExportTXT.Text = "Export Logs";
            this.buttonExportTXT.UseVisualStyleBackColor = true;
            this.buttonExportTXT.Click += new System.EventHandler(this.buttonExportTXT_Click);
            // 
            // buttonExImei
            // 
            this.buttonExImei.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExImei.Location = new System.Drawing.Point(124, 136);
            this.buttonExImei.Name = "buttonExImei";
            this.buttonExImei.Size = new System.Drawing.Size(93, 23);
            this.buttonExImei.TabIndex = 19;
            this.buttonExImei.Text = "Ex to Excel";
            this.buttonExImei.UseVisualStyleBackColor = true;
            this.buttonExImei.Click += new System.EventHandler(this.buttonExImei_Click);
            // 
            // buttonClear1
            // 
            this.buttonClear1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClear1.Location = new System.Drawing.Point(124, 105);
            this.buttonClear1.Name = "buttonClear1";
            this.buttonClear1.Size = new System.Drawing.Size(94, 25);
            this.buttonClear1.TabIndex = 26;
            this.buttonClear1.Text = "Clear All";
            this.buttonClear1.UseVisualStyleBackColor = true;
            this.buttonClear1.Click += new System.EventHandler(this.buttonClear1_Click);
            // 
            // buttonClearLogs
            // 
            this.buttonClearLogs.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearLogs.Location = new System.Drawing.Point(6, 105);
            this.buttonClearLogs.Name = "buttonClearLogs";
            this.buttonClearLogs.Size = new System.Drawing.Size(99, 25);
            this.buttonClearLogs.TabIndex = 27;
            this.buttonClearLogs.Text = "Clear Logs";
            this.buttonClearLogs.UseVisualStyleBackColor = true;
            this.buttonClearLogs.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(6, 136);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "Ex to Sheet";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // buttonDefault
            // 
            this.buttonDefault.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDefault.Location = new System.Drawing.Point(3, 21);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(73, 21);
            this.buttonDefault.TabIndex = 26;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonReset.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReset.Location = new System.Drawing.Point(78, 21);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(67, 21);
            this.buttonReset.TabIndex = 38;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonWriteLogs
            // 
            this.buttonWriteLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWriteLogs.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWriteLogs.Location = new System.Drawing.Point(124, 74);
            this.buttonWriteLogs.Name = "buttonWriteLogs";
            this.buttonWriteLogs.Size = new System.Drawing.Size(94, 25);
            this.buttonWriteLogs.TabIndex = 24;
            this.buttonWriteLogs.Text = "EX IMEI";
            this.buttonWriteLogs.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteFlash
            // 
            this.buttonDeleteFlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteFlash.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonDeleteFlash.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeleteFlash.Location = new System.Drawing.Point(149, 21);
            this.buttonDeleteFlash.Name = "buttonDeleteFlash";
            this.buttonDeleteFlash.Size = new System.Drawing.Size(73, 21);
            this.buttonDeleteFlash.TabIndex = 25;
            this.buttonDeleteFlash.Text = "Del flash";
            this.buttonDeleteFlash.UseVisualStyleBackColor = true;
            this.buttonDeleteFlash.Click += new System.EventHandler(this.buttonDeleteFlash_Click);
            // 
            // buttonTvn05
            // 
            this.buttonTvn05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTvn05.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTvn05.Location = new System.Drawing.Point(158, 48);
            this.buttonTvn05.Name = "buttonTvn05";
            this.buttonTvn05.Size = new System.Drawing.Size(57, 20);
            this.buttonTvn05.TabIndex = 36;
            this.buttonTvn05.Text = "TVN05";
            this.buttonTvn05.UseVisualStyleBackColor = true;
            this.buttonTvn05.Click += new System.EventHandler(this.buttonTvn05_Click);
            // 
            // buttonTvn02
            // 
            this.buttonTvn02.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTvn02.Location = new System.Drawing.Point(6, 46);
            this.buttonTvn02.Name = "buttonTvn02";
            this.buttonTvn02.Size = new System.Drawing.Size(61, 22);
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
            this.textBoxVbat.TextChanged += new System.EventHandler(this.textBox3_TextChanged_1);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(117, 79);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(44, 16);
            this.label40.TabIndex = 24;
            this.label40.Text = "VBAT:";
            this.label40.Click += new System.EventHandler(this.label40_Click);
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
            this.textBoxADB.TextChanged += new System.EventHandler(this.textBoxADB_TextChanged);
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
            this.textBoxADA.TextChanged += new System.EventHandler(this.textBoxADA_TextChanged);
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
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // textBoxTempA
            // 
            this.textBoxTempA.Location = new System.Drawing.Point(50, 125);
            this.textBoxTempA.Name = "textBoxTempA";
            this.textBoxTempA.Size = new System.Drawing.Size(38, 22);
            this.textBoxTempA.TabIndex = 9;
            this.textBoxTempA.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(50, 100);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(161, 22);
            this.textBoxTime.TabIndex = 8;
            this.textBoxTime.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBoxPower
            // 
            this.textBoxPower.Location = new System.Drawing.Point(50, 21);
            this.textBoxPower.Name = "textBoxPower";
            this.textBoxPower.Size = new System.Drawing.Size(48, 22);
            this.textBoxPower.TabIndex = 6;
            this.textBoxPower.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "TEMP";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "ADB:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
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
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "PWR:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // textBoxFirmwareFilePath1
            // 
            this.textBoxFirmwareFilePath1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxFirmwareFilePath1.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFirmwareFilePath1.Location = new System.Drawing.Point(5, 504);
            this.textBoxFirmwareFilePath1.Multiline = true;
            this.textBoxFirmwareFilePath1.Name = "textBoxFirmwareFilePath1";
            this.textBoxFirmwareFilePath1.Size = new System.Drawing.Size(140, 26);
            this.textBoxFirmwareFilePath1.TabIndex = 5;
            this.textBoxFirmwareFilePath1.TextChanged += new System.EventHandler(this.textBoxFirmwareFilePath1_TextChanged);
            // 
            // buttonRebootToDFUMode2
            // 
            this.buttonRebootToDFUMode2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRebootToDFUMode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonRebootToDFUMode2.Font = new System.Drawing.Font("Georgia", 12F);
            this.buttonRebootToDFUMode2.ForeColor = System.Drawing.SystemColors.Control;
            this.buttonRebootToDFUMode2.ImageKey = "(none)";
            this.buttonRebootToDFUMode2.Location = new System.Drawing.Point(0, 467);
            this.buttonRebootToDFUMode2.Name = "buttonRebootToDFUMode2";
            this.buttonRebootToDFUMode2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonRebootToDFUMode2.Size = new System.Drawing.Size(219, 31);
            this.buttonRebootToDFUMode2.TabIndex = 4;
            this.buttonRebootToDFUMode2.Text = "Start Update";
            this.buttonRebootToDFUMode2.UseVisualStyleBackColor = false;
            this.buttonRebootToDFUMode2.Click += new System.EventHandler(this.buttonRebootToBootloaderMode_Click);
            // 
            // buttonOpenFWFile
            // 
            this.buttonOpenFWFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenFWFile.AutoSize = true;
            this.buttonOpenFWFile.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenFWFile.Location = new System.Drawing.Point(151, 505);
            this.buttonOpenFWFile.Name = "buttonOpenFWFile";
            this.buttonOpenFWFile.Size = new System.Drawing.Size(68, 25);
            this.buttonOpenFWFile.TabIndex = 3;
            this.buttonOpenFWFile.Text = "Open file";
            this.buttonOpenFWFile.UseVisualStyleBackColor = true;
            this.buttonOpenFWFile.Click += new System.EventHandler(this.buttonOpenBinaryFWFile_Click);
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
            this.splitContainer2.Size = new System.Drawing.Size(1243, 801);
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
            this.splitContainer7.Size = new System.Drawing.Size(1243, 166);
            this.splitContainer7.SplitterDistance = 490;
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
            this.splitContainer15.Panel1.Controls.Add(this.errorlog);
            // 
            // splitContainer15.Panel2
            // 
            this.splitContainer15.Panel2.Controls.Add(this.gprs4gStartus);
            this.splitContainer15.Size = new System.Drawing.Size(490, 166);
            this.splitContainer15.SplitterDistance = 256;
            this.splitContainer15.TabIndex = 0;
            // 
            // errorlog
            // 
            this.errorlog.Controls.Add(this.textBoxDeviceErrorMessage1);
            this.errorlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorlog.Enabled = false;
            this.errorlog.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorlog.Location = new System.Drawing.Point(0, 0);
            this.errorlog.Name = "errorlog";
            this.errorlog.Size = new System.Drawing.Size(256, 166);
            this.errorlog.TabIndex = 0;
            this.errorlog.TabStop = false;
            this.errorlog.Text = "Error Logs";
            // 
            // textBoxDeviceErrorMessage1
            // 
            this.textBoxDeviceErrorMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDeviceErrorMessage1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeviceErrorMessage1.ForeColor = System.Drawing.Color.Red;
            this.textBoxDeviceErrorMessage1.Location = new System.Drawing.Point(3, 18);
            this.textBoxDeviceErrorMessage1.Multiline = true;
            this.textBoxDeviceErrorMessage1.Name = "textBoxDeviceErrorMessage1";
            this.textBoxDeviceErrorMessage1.Size = new System.Drawing.Size(250, 145);
            this.textBoxDeviceErrorMessage1.TabIndex = 1;
            // 
            // gprs4gStartus
            // 
            this.gprs4gStartus.Controls.Add(this.textBoxGprsMessage1);
            this.gprs4gStartus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gprs4gStartus.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gprs4gStartus.Location = new System.Drawing.Point(0, 0);
            this.gprs4gStartus.Name = "gprs4gStartus";
            this.gprs4gStartus.Size = new System.Drawing.Size(230, 166);
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
            this.textBoxGprsMessage1.Size = new System.Drawing.Size(224, 145);
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
            this.splitContainer16.Size = new System.Drawing.Size(749, 166);
            this.splitContainer16.SplitterDistance = 696;
            this.splitContainer16.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textGPSstartus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 166);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GPRS - 4G Status";
            // 
            // textGPSstartus
            // 
            this.textGPSstartus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textGPSstartus.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textGPSstartus.Location = new System.Drawing.Point(3, 18);
            this.textGPSstartus.Multiline = true;
            this.textGPSstartus.Name = "textGPSstartus";
            this.textGPSstartus.Size = new System.Drawing.Size(690, 145);
            this.textGPSstartus.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.listBoxFirmwareUpdateLog1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(49, 166);
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
            this.listBoxFirmwareUpdateLog1.Size = new System.Drawing.Size(43, 145);
            this.listBoxFirmwareUpdateLog1.TabIndex = 0;
            this.listBoxFirmwareUpdateLog1.SelectedIndexChanged += new System.EventHandler(this.listBoxFirmwareUpdateLog1_SelectedIndexChanged);
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
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer3.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer3_Panel2_Paint);
            this.splitContainer3.Size = new System.Drawing.Size(1240, 631);
            this.splitContainer3.SplitterDistance = 588;
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
            this.textBoxDeviceLogs.Size = new System.Drawing.Size(1240, 588);
            this.textBoxDeviceLogs.TabIndex = 18;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 631);
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
            // tabControlTestList
            // 
            this.tabControlTestList.Controls.Add(this.tabPage1);
            this.tabControlTestList.Controls.Add(this.tabPage8);
            this.tabControlTestList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTestList.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlTestList.ImageList = this.imageListTabControlLabel;
            this.tabControlTestList.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControlTestList.Location = new System.Drawing.Point(0, 0);
            this.tabControlTestList.Name = "tabControlTestList";
            this.tabControlTestList.SelectedIndex = 0;
            this.tabControlTestList.Size = new System.Drawing.Size(1482, 845);
            this.tabControlTestList.TabIndex = 35;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(112, 390);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 20);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = " GPS Logs";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(112, 338);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(105, 20);
            this.checkBox2.TabIndex = 39;
            this.checkBox2.Text = "Auto Update";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(112, 364);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(95, 20);
            this.checkBox3.TabIndex = 38;
            this.checkBox3.Text = "Auto scroll";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(1482, 867);
            this.Controls.Add(this.tabControlTestList);
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
            this.tabPage8.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel19.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.groupBoxCRER.ResumeLayout(false);
            this.groupBoxCRER.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
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
            this.errorlog.ResumeLayout(false);
            this.errorlog.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            this.tabControlTestList.ResumeLayout(false);
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
        }

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
                }
                else if (line.Contains("-E-") || line.Contains("-E0") ||
                     line.Contains("Can not") || line.Contains("can not") ||
                      line.Contains("failed") || line.Contains("fail") || line.Contains("false"))
                {
                    AppendLineToTextBox(textBoxDeviceErrorMessage1, line, true);
                }
                else if (line.Contains("-BLD-"))
                {
                    bootLoaderRxResponseQueue.Enqueue(line);
                    logEnable = false;
                }
                else if (line.Contains("+QVBATT"))
                {
                    AppendLineToTextBox(textBoxQVBATT, line, true);
                }
                if (line.Contains("-RtcInfo"))
                {
                    //string[] rtcInfo = line.Split(',');
                    //textBoxRtcInfo.Text = rtcInfo[1];
                }
                if (line.Contains("+QISACK:"))
                {
                    string[] rtcInfo = line.Split(':');
                    textBoxQISACK.Text = rtcInfo[1];
                }
                if (line.Contains("+QISEND"))
                {
                    string[] rtcInfo = line.Split('=',':');
                    textBoxQISEND.Text = rtcInfo[1];
                }
                if (line.Contains("+AT+CRER"))
                {
                    string[] rtcInfo = line.Split(':');
                    textBoxCRER.Text = rtcInfo[1];
                }

                else if (line.Contains("-I-DCE IMEI:"))
                {
                    string[] imei = line.Split(':');
                    textBoxImei.Text = imei[1];
                    textBoxImei2.Text = imei[1];
                }
                else if (line.Contains("+CCID:"))
                {
                    string[] CCID = line.Split(':');
                    textBoxCCID.Text = CCID[1];
                    textBoxCCID1.Text = CCID[1];
                }

                else if (line.Contains("-I-FW Version:"))
                {
                    var FW = Regex.Split(line, @"[\.]");
                    var var1 = bootloaderProcessing.FirmwareVersion[3].ToString();
                    var var2 = FW[FW.Length - 1];
                    textBoxFwRev.Text = var2 + " - " + var1;
                    textBoxFwRev2.Text = var2;

                    int fw1 = int.Parse(var1);
                    int fw2 = int.Parse(var2);
                    if (fw1 < fw2)
                    {
                        if(CheckboxUpdate.Checked)
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

                    var tempB = new Regex(@"C (\d*[.]\d*)*");
                    var groupsRHA = tempB.Match(line).Groups;

                    textBoxTempC.Text = groupsRHA[1].Value;

                    var tempD = new Regex(@"(\d*[.]\d*)* RH ,");
                    var groupsRHB = tempD.Match(line).Groups;

                    textBoxTempD.Text = groupsRHB[1].Value;

                    var tempC = new Regex(@"SHT30:  (\d*[.]\d*)*");
                    var grouptempa = tempC.Match(line).Groups;

                    textBoxTempA.Text = grouptempa[1].Value;
                }


                else if (line.Contains(" Bytes, @"))
                {
                    string[] time = line.Split('@');
                    textBoxTime.Text = time[1];
                    textBoxTime2.Text = time[1];
                }
                else if (line.Contains("+CSQ:"))
                {
                    string[] time = line.Split(':');
                    textBoxPos.Text = time[1];
                    textBoxCQS.Text = time[1];

                }
                else if (line.Contains("***************************"))
                {

                    var bootloader = new Regex(@"Rev(\d*[.]\d*)");
                    var groupbld = bootloader.Match(line).Groups;

                    textBoxBootloader.Text = groupbld[1].Value;
                }
                else if (line.Contains("-I--ADA:"))
                {
                    var regex = new Regex(@"ADB:(\d*[.]\d*)");
                    var groups = regex.Match(line).Groups;
                   // var regexb = new Regex(@"ADB:(\d*[.]\d*)");
                   // var groupb= regexb.Match(line).Groups;

                    textBoxADB.Text = groups[1].Value;
                   // textBoxADB.Text = groupb[1].Value;

                    var regex1 = new Regex(@"ADA:(\d*[.]\d*)V");
                    var groups1 = regex1.Match(line).Groups;

                    textBoxADA.Text = groups1[1].Value;

                    var regex2 = new Regex(@"Vbat:(\d*[.]\d*)V");
                    var groups2 = regex2.Match(line).Groups;

                    textBoxVbat.Text = groups2[1].Value;

                    var regex3 = new Regex(@"Vpower:(\d*[.]\d*)V");
                    var groups3 = regex3.Match(line).Groups;

                    textBoxPower.Text = groups3[1].Value;

                    var regex4 = new Regex(@"I/O:(\d*):");
                    var groups4 = regex4.Match(line).Groups; 
                    var regexc = new Regex(@"I/O |(\d*)");
                    var groupsc = regex4.Match(line).Groups;
                    textBoxIO.Text = groupsc[1].Value;
                    textBoxIO.Text = groups4[1].Value;
                    var regex5 = new Regex(@"Temp:(\d*[.]\d*)");
                    var groups5 = regex5.Match(line).Groups;

                    textBoxTempA.Text = groups5[1].Value;

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
                textBoxDeviceErrorMessage1.Text += "Written command to client: " + cmd + Environment.NewLine;
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
        const string CMD_TVN02 = "*000000,001,300190# \n  \r*300190,011,e-connect,,#\n  \r*300190,015,1,gps.tracking.vn,18860#\n  \r*300190,016,1,#\n  \r*300190,018,30,999#";
        const string CMD_TVN05 = "*000000,001,300190# \n  \r*300190,011,e-connect,,#\n  \r*300190,015,1,gps.tracking.vn,20022#\n  \r*300190,016,1,#\n  \r*300190,018,30,999#";
        const string CMD_TVND09 = "*000000,001,300190# \n  \r*300190,011,e-connect,,#\n  \r*300190,015,1,gps.tracking.vn,18888#\n  \r*300190,016,1,#\n  \r*300190,018,30,999#";
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxFwRev_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBoxFirmwareFilePath1_TextChanged(object sender, EventArgs e)
        {

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
            textBoxDeviceErrorMessage1.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBoxGprsMessage1.Clear();
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear1_Click(object sender, EventArgs e)
        {
            textBoxDeviceLogs.Clear();
            textBoxImei.Clear();
            textBoxDeviceErrorMessage1.Clear();
            textBoxGprsMessage1.Clear();
            textBoxDeviceLogs.Clear();
            textBoxImei.Clear();
            textBoxDeviceErrorMessage1.Clear();
            textBoxGprsMessage1.Clear();
            textBoxADA.Clear();
            textBoxADB.Clear();
            textBoxCCID1.Clear();
            textBoxCCID.Clear();
            textBoxCQS.Clear();
            textBoxDeviceErrorMessage.Clear();
            textBoxBootloader.Clear();
            textBoxBootloader2.Clear();
            textBoxFwRev.Clear();
            textBoxFwRev2.Clear();
            textBoxPower.Clear();
            textBoxQISACK.Clear();
            textBoxTempA.Clear();
            textBoxTempB.Clear();
            textBoxTempC.Clear();
            textBoxVbat.Clear();
            textBoxTime.Clear();
            textBoxPos.Clear();
            textBoxIO.Clear();
        }

        private void textBoxADB_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonTVND09_Click(object sender, EventArgs e)
        {
            if (isDeviceConnected)
            {
                // Read command from text box
                commandStrQueue.Enqueue(CMD_TVND09);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void textBoxADA_TextChanged(object sender, EventArgs e)
        {

        }

        private void splitContainer9_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer9_Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBoxBootloader_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAutoScrollDeviceLogs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxDisplayGpsSentence_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckboxUpdate_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            textBoxDeviceLogs.Clear();
        }

        private void textBoxImei_TextChanged(object sender, EventArgs e)
        {

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

        private void listBoxFirmwareUpdateLog1_SelectedIndexChanged(object sender, EventArgs e)
        {
                
        }

        private void splitContainer5_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
