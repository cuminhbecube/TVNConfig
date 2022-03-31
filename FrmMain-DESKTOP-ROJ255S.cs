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
        private TextBox textBoxDeviceLogs;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel labelConnectingStatus;
        private ToolStripStatusLabel labelFirmwareUpdateProcess;
        private ToolStripProgressBar progressBarFirmwareUpdate;
        private Button buttonCopyTextBoxRcvData;
        private Button buttonWriteSettingToDevice;
        private TextBox textBoxCommandList;
        private Label label4;
        private TextBox textBoxImei;
        private ComboBox comboBox1;
        private TextBox textBox14;
        private TextBox textBox13;
        private Label label19;
        private TextBox textBoxDeviceErrorMessage;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private Splitter splitter1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private SplitContainer splitContainer4;
        private Button buttonRefreshComPortList;
        private Button buttonOpenComPort;
        private ComboBox comboBoxComPortBaudRate;
        private ComboBox comboBoxComPortList;
        private Label label21;
        private Label label20;
        private SplitContainer splitContainer5;
        private SplitContainer splitContainer6;
        private SplitContainer splitContainer9;
        private GroupBox groupBox4;
        private Label label23;
        private Label label22;
        private GroupBox groupBox3;
        private SplitContainer splitContainer7;
        private SplitContainer splitContainer3;
        private TabPage tabPage5;
        private CheckBox checkBoxAutoScrollDeviceLogs;
        private SplitContainer splitContainer8;
        private SplitContainer splitContainer10;
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
        private Button button7;
        private Button buttonClear1;
        private Button buttonClear;
        private Button button3;
        private CheckBox checkBoxDisplayGpsSentence;
        private Button buttonExit;
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
        private GroupBox groupBox5;
        private Button buttonRebootToDFUMode2;
        private Button buttonOpenFWFile;
        private GroupBox errorlog;
        private GroupBox gprs4gStartus;
        private TextBox textBoxDeviceErrorMessage1;
        private ListBox listBoxFirmwareUpdateLog1;
        private TextBox textBoxGprsMessage1;
        private TextBox textBoxFirmwareFilePath1;
        private TextBox textBoxFwRev;
        private Label label1;
        private Button buttonDefault;
        private Button buttonDeleteFlash;
        private Button buttonTvn05;
        private Button buttonTvn02;
        private Panel panel1;
        private GroupBox groupBoxLogs;
        private Label label5;
        private Label label3;
        private Label label6;
        private TextBox textBoxTempA;
        private TextBox textBoxTime;
        private TextBox textBoxPower;
        private Label label8;
        private Label label7;
        private Label label9;
        private TextBox textBoxPos;
        private TextBox textBoxADB;
        private TextBox textBoxTempB;
        private TextBox textBoxADA;
        private TextBox textBoxIO;
        private Label label10;
        private Button buttonTVND09;
        private TextBox textBoxBootloader;
        private Label label11;
        private TabPage tabPage6;

        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.textBoxDeviceLogs = new System.Windows.Forms.TextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.labelConnectingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelFirmwareUpdateProcess = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarFirmwareUpdate = new System.Windows.Forms.ToolStripProgressBar();
            this.buttonCopyTextBoxRcvData = new System.Windows.Forms.Button();
            this.buttonWriteSettingToDevice = new System.Windows.Forms.Button();
            this.textBoxCommandList = new System.Windows.Forms.TextBox();
            this.textBoxImei = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxDeviceErrorMessage = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
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
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonTvn05 = new System.Windows.Forms.Button();
            this.buttonTvn02 = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.buttonDeleteFlash = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFwRev = new System.Windows.Forms.TextBox();
            this.textBoxFirmwareFilePath1 = new System.Windows.Forms.TextBox();
            this.buttonRebootToDFUMode2 = new System.Windows.Forms.Button();
            this.buttonOpenFWFile = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBoxFirmwareUpdateLog1 = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxLogs = new System.Windows.Forms.GroupBox();
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
            this.textBoxDeviceErrorMessage1 = new System.Windows.Forms.TextBox();
            this.errorlog = new System.Windows.Forms.GroupBox();
            this.gprs4gStartus = new System.Windows.Forms.GroupBox();
            this.textBoxGprsMessage1 = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.checkBoxDisplayGpsSentence = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoScrollDeviceLogs = new System.Windows.Forms.CheckBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonClear1 = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
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
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxIO = new System.Windows.Forms.TextBox();
            this.buttonTVND09 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxBootloader = new System.Windows.Forms.TextBox();
            this.statusStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.Panel1.SuspendLayout();
            this.splitContainer9.Panel2.SuspendLayout();
            this.splitContainer9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxLogs.SuspendLayout();
            this.gprs4gStartus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
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
            this.SuspendLayout();
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
            this.textBoxDeviceLogs.Size = new System.Drawing.Size(958, 470);
            this.textBoxDeviceLogs.TabIndex = 18;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelConnectingStatus,
            this.labelFirmwareUpdateProcess,
            this.progressBarFirmwareUpdate});
            this.statusStrip.Location = new System.Drawing.Point(0, 727);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(1229, 22);
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
            // buttonCopyTextBoxRcvData
            // 
            this.buttonCopyTextBoxRcvData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCopyTextBoxRcvData.Location = new System.Drawing.Point(459, 4);
            this.buttonCopyTextBoxRcvData.Name = "buttonCopyTextBoxRcvData";
            this.buttonCopyTextBoxRcvData.Size = new System.Drawing.Size(91, 32);
            this.buttonCopyTextBoxRcvData.TabIndex = 22;
            this.buttonCopyTextBoxRcvData.Text = "Copy";
            this.buttonCopyTextBoxRcvData.UseVisualStyleBackColor = true;
            this.buttonCopyTextBoxRcvData.Click += new System.EventHandler(this.buttonCopyTextBoxRcvData_Click);
            // 
            // buttonWriteSettingToDevice
            // 
            this.buttonWriteSettingToDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWriteSettingToDevice.Location = new System.Drawing.Point(0, 65);
            this.buttonWriteSettingToDevice.Name = "buttonWriteSettingToDevice";
            this.buttonWriteSettingToDevice.Size = new System.Drawing.Size(250, 26);
            this.buttonWriteSettingToDevice.TabIndex = 24;
            this.buttonWriteSettingToDevice.Text = "Write Setting To Device";
            this.buttonWriteSettingToDevice.UseVisualStyleBackColor = true;
            this.buttonWriteSettingToDevice.Click += new System.EventHandler(this.buttonWriteSettingToDevice_Click);
            // 
            // textBoxCommandList
            // 
            this.textBoxCommandList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCommandList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCommandList.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCommandList.ForeColor = System.Drawing.Color.Blue;
            this.textBoxCommandList.Location = new System.Drawing.Point(1, 1);
            this.textBoxCommandList.Multiline = true;
            this.textBoxCommandList.Name = "textBoxCommandList";
            this.textBoxCommandList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCommandList.Size = new System.Drawing.Size(250, 60);
            this.textBoxCommandList.TabIndex = 1;
            this.textBoxCommandList.Text = "*300190,990,099#";
            // 
            // textBoxImei
            // 
            this.textBoxImei.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxImei.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxImei.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImei.Location = new System.Drawing.Point(55, 13);
            this.textBoxImei.Name = "textBoxImei";
            this.textBoxImei.ReadOnly = true;
            this.textBoxImei.Size = new System.Drawing.Size(194, 22);
            this.textBoxImei.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "IMEI:";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(170, 10);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(73, 20);
            this.textBox14.TabIndex = 5;
            this.textBox14.Text = "300190";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(44, 10);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(74, 20);
            this.textBox13.TabIndex = 3;
            this.textBox13.Text = "000000";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "TVN02",
            "TVN05"});
            this.comboBox1.Location = new System.Drawing.Point(3, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(244, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "TVN02";
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ImageList = this.imageListTabControlLabel;
            this.tabControl1.ItemSize = new System.Drawing.Size(200, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1229, 727);
            this.tabControl1.TabIndex = 35;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1221, 689);
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
            this.splitContainer1.Size = new System.Drawing.Size(1215, 683);
            this.splitContainer1.SplitterDistance = 250;
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
            this.splitContainer4.Size = new System.Drawing.Size(250, 683);
            this.splitContainer4.SplitterDistance = 61;
            this.splitContainer4.TabIndex = 0;
            // 
            // buttonRefreshComPortList
            // 
            this.buttonRefreshComPortList.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRefreshComPortList.Location = new System.Drawing.Point(158, 34);
            this.buttonRefreshComPortList.Name = "buttonRefreshComPortList";
            this.buttonRefreshComPortList.Size = new System.Drawing.Size(89, 23);
            this.buttonRefreshComPortList.TabIndex = 5;
            this.buttonRefreshComPortList.Text = "Refresh";
            this.buttonRefreshComPortList.UseVisualStyleBackColor = true;
            this.buttonRefreshComPortList.Click += new System.EventHandler(this.buttonRefreshComPortList_Click);
            // 
            // buttonOpenComPort
            // 
            this.buttonOpenComPort.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenComPort.Location = new System.Drawing.Point(158, 8);
            this.buttonOpenComPort.Name = "buttonOpenComPort";
            this.buttonOpenComPort.Size = new System.Drawing.Size(89, 23);
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
            this.comboBoxComPortBaudRate.Size = new System.Drawing.Size(97, 24);
            this.comboBoxComPortBaudRate.TabIndex = 3;
            // 
            // comboBoxComPortList
            // 
            this.comboBoxComPortList.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxComPortList.FormattingEnabled = true;
            this.comboBoxComPortList.Location = new System.Drawing.Point(55, 7);
            this.comboBoxComPortList.Name = "comboBoxComPortList";
            this.comboBoxComPortList.Size = new System.Drawing.Size(97, 24);
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
            this.splitContainer5.Panel1.Controls.Add(this.splitContainer6);
            this.splitContainer5.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.AutoScroll = true;
            this.splitContainer5.Panel2.Controls.Add(this.textBoxFirmwareFilePath1);
            this.splitContainer5.Panel2.Controls.Add(this.buttonRebootToDFUMode2);
            this.splitContainer5.Panel2.Controls.Add(this.buttonOpenFWFile);
            this.splitContainer5.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer5.Panel2.Controls.Add(this.label4);
            this.splitContainer5.Panel2.Controls.Add(this.textBoxImei);
            this.splitContainer5.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer5.Size = new System.Drawing.Size(250, 618);
            this.splitContainer5.SplitterDistance = 235;
            this.splitContainer5.TabIndex = 0;
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.splitContainer9);
            this.splitContainer6.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.textBoxBootloader);
            this.splitContainer6.Panel2.Controls.Add(this.label11);
            this.splitContainer6.Panel2.Controls.Add(this.label1);
            this.splitContainer6.Panel2.Controls.Add(this.textBoxFwRev);
            this.splitContainer6.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer6.Size = new System.Drawing.Size(250, 235);
            this.splitContainer6.SplitterDistance = 205;
            this.splitContainer6.TabIndex = 0;
            // 
            // splitContainer9
            // 
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer9.Location = new System.Drawing.Point(0, 0);
            this.splitContainer9.Name = "splitContainer9";
            this.splitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer9.Panel1
            // 
            this.splitContainer9.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer9.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer9.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer9.Panel2
            // 
            this.splitContainer9.Panel2.Controls.Add(this.buttonTVND09);
            this.splitContainer9.Panel2.Controls.Add(this.buttonTvn05);
            this.splitContainer9.Panel2.Controls.Add(this.buttonTvn02);
            this.splitContainer9.Panel2.Controls.Add(this.buttonDefault);
            this.splitContainer9.Panel2.Controls.Add(this.buttonDeleteFlash);
            this.splitContainer9.Panel2.Controls.Add(this.buttonWriteSettingToDevice);
            this.splitContainer9.Panel2.Controls.Add(this.textBoxCommandList);
            this.splitContainer9.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer9.Size = new System.Drawing.Size(250, 205);
            this.splitContainer9.SplitterDistance = 31;
            this.splitContainer9.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox14);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.textBox13);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(250, 31);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Password";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(124, 13);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 14);
            this.label23.TabIndex = 3;
            this.label23.Text = "New";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(11, 13);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(27, 14);
            this.label22.TabIndex = 0;
            this.label22.Text = "Old";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 31);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model";
            // 
            // buttonTvn05
            // 
            this.buttonTvn05.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTvn05.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTvn05.Location = new System.Drawing.Point(177, 98);
            this.buttonTvn05.Name = "buttonTvn05";
            this.buttonTvn05.Size = new System.Drawing.Size(72, 33);
            this.buttonTvn05.TabIndex = 36;
            this.buttonTvn05.Text = "TVN05";
            this.buttonTvn05.UseVisualStyleBackColor = true;
            this.buttonTvn05.Click += new System.EventHandler(this.buttonTvn05_Click);
            // 
            // buttonTvn02
            // 
            this.buttonTvn02.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTvn02.Location = new System.Drawing.Point(0, 97);
            this.buttonTvn02.Name = "buttonTvn02";
            this.buttonTvn02.Size = new System.Drawing.Size(73, 34);
            this.buttonTvn02.TabIndex = 1;
            this.buttonTvn02.Text = "TVN02";
            this.buttonTvn02.UseVisualStyleBackColor = true;
            this.buttonTvn02.Click += new System.EventHandler(this.buttonTvn02_Click);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDefault.Location = new System.Drawing.Point(0, 136);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(118, 31);
            this.buttonDefault.TabIndex = 26;
            this.buttonDefault.Text = "Default setting";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // buttonDeleteFlash
            // 
            this.buttonDeleteFlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteFlash.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonDeleteFlash.Location = new System.Drawing.Point(126, 136);
            this.buttonDeleteFlash.Name = "buttonDeleteFlash";
            this.buttonDeleteFlash.Size = new System.Drawing.Size(124, 31);
            this.buttonDeleteFlash.TabIndex = 25;
            this.buttonDeleteFlash.Text = "Delete flash";
            this.buttonDeleteFlash.UseVisualStyleBackColor = true;
            this.buttonDeleteFlash.Click += new System.EventHandler(this.buttonDeleteFlash_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 36;
            this.label1.Text = "FW:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxFwRev
            // 
            this.textBoxFwRev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFwRev.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxFwRev.Location = new System.Drawing.Point(37, 8);
            this.textBoxFwRev.Name = "textBoxFwRev";
            this.textBoxFwRev.Size = new System.Drawing.Size(64, 22);
            this.textBoxFwRev.TabIndex = 1;
            this.textBoxFwRev.TextChanged += new System.EventHandler(this.textBoxFwRev_TextChanged);
            // 
            // textBoxFirmwareFilePath1
            // 
            this.textBoxFirmwareFilePath1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxFirmwareFilePath1.Font = new System.Drawing.Font("Times New Roman", 6F);
            this.textBoxFirmwareFilePath1.Location = new System.Drawing.Point(0, 353);
            this.textBoxFirmwareFilePath1.Multiline = true;
            this.textBoxFirmwareFilePath1.Name = "textBoxFirmwareFilePath1";
            this.textBoxFirmwareFilePath1.Size = new System.Drawing.Size(166, 26);
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
            this.buttonRebootToDFUMode2.Location = new System.Drawing.Point(-3, 291);
            this.buttonRebootToDFUMode2.Name = "buttonRebootToDFUMode2";
            this.buttonRebootToDFUMode2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonRebootToDFUMode2.Size = new System.Drawing.Size(254, 56);
            this.buttonRebootToDFUMode2.TabIndex = 4;
            this.buttonRebootToDFUMode2.Text = "Start Update";
            this.buttonRebootToDFUMode2.UseVisualStyleBackColor = false;
            this.buttonRebootToDFUMode2.Click += new System.EventHandler(this.buttonRebootToBootloaderMode_Click);
            // 
            // buttonOpenFWFile
            // 
            this.buttonOpenFWFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOpenFWFile.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOpenFWFile.Location = new System.Drawing.Point(170, 353);
            this.buttonOpenFWFile.Name = "buttonOpenFWFile";
            this.buttonOpenFWFile.Size = new System.Drawing.Size(80, 28);
            this.buttonOpenFWFile.TabIndex = 3;
            this.buttonOpenFWFile.Text = "Open file";
            this.buttonOpenFWFile.UseVisualStyleBackColor = true;
            this.buttonOpenFWFile.Click += new System.EventHandler(this.buttonOpenBinaryFWFile_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.listBoxFirmwareUpdateLog1);
            this.groupBox5.Location = new System.Drawing.Point(-3, 46);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 239);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Update log";
            // 
            // listBoxFirmwareUpdateLog1
            // 
            this.listBoxFirmwareUpdateLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFirmwareUpdateLog1.Font = new System.Drawing.Font("Times New Roman", 15F);
            this.listBoxFirmwareUpdateLog1.FormattingEnabled = true;
            this.listBoxFirmwareUpdateLog1.ItemHeight = 22;
            this.listBoxFirmwareUpdateLog1.Location = new System.Drawing.Point(3, 18);
            this.listBoxFirmwareUpdateLog1.Name = "listBoxFirmwareUpdateLog1";
            this.listBoxFirmwareUpdateLog1.Size = new System.Drawing.Size(246, 218);
            this.listBoxFirmwareUpdateLog1.TabIndex = 0;
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
            this.splitContainer2.Size = new System.Drawing.Size(961, 683);
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
            this.splitContainer7.Panel1.Controls.Add(this.panel1);
            this.splitContainer7.Panel1.Controls.Add(this.textBoxDeviceErrorMessage1);
            this.splitContainer7.Panel1.Controls.Add(this.errorlog);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.gprs4gStartus);
            this.splitContainer7.Size = new System.Drawing.Size(961, 166);
            this.splitContainer7.SplitterDistance = 490;
            this.splitContainer7.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxLogs);
            this.panel1.Location = new System.Drawing.Point(269, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 165);
            this.panel1.TabIndex = 2;
            // 
            // groupBoxLogs
            // 
            this.groupBoxLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBoxLogs.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxLogs.Location = new System.Drawing.Point(0, 0);
            this.groupBoxLogs.Name = "groupBoxLogs";
            this.groupBoxLogs.Size = new System.Drawing.Size(220, 165);
            this.groupBoxLogs.TabIndex = 0;
            this.groupBoxLogs.TabStop = false;
            this.groupBoxLogs.Text = "Signal Indicator";
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
            this.textBoxTempB.Size = new System.Drawing.Size(76, 22);
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
            this.textBoxPos.Size = new System.Drawing.Size(162, 22);
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
            this.textBoxTempA.Size = new System.Drawing.Size(76, 22);
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
            // textBoxDeviceErrorMessage1
            // 
            this.textBoxDeviceErrorMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDeviceErrorMessage1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDeviceErrorMessage1.ForeColor = System.Drawing.Color.Red;
            this.textBoxDeviceErrorMessage1.Location = new System.Drawing.Point(3, 26);
            this.textBoxDeviceErrorMessage1.Multiline = true;
            this.textBoxDeviceErrorMessage1.Name = "textBoxDeviceErrorMessage1";
            this.textBoxDeviceErrorMessage1.Size = new System.Drawing.Size(265, 136);
            this.textBoxDeviceErrorMessage1.TabIndex = 1;
            // 
            // errorlog
            // 
            this.errorlog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorlog.Enabled = false;
            this.errorlog.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorlog.Location = new System.Drawing.Point(0, 0);
            this.errorlog.Name = "errorlog";
            this.errorlog.Size = new System.Drawing.Size(490, 166);
            this.errorlog.TabIndex = 0;
            this.errorlog.TabStop = false;
            this.errorlog.Text = "Error Logs";
            // 
            // gprs4gStartus
            // 
            this.gprs4gStartus.Controls.Add(this.textBoxGprsMessage1);
            this.gprs4gStartus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gprs4gStartus.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gprs4gStartus.Location = new System.Drawing.Point(0, 0);
            this.gprs4gStartus.Name = "gprs4gStartus";
            this.gprs4gStartus.Size = new System.Drawing.Size(467, 166);
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
            this.textBoxGprsMessage1.Size = new System.Drawing.Size(461, 145);
            this.textBoxGprsMessage1.TabIndex = 0;
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
            this.splitContainer3.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer10);
            this.splitContainer3.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer3.Size = new System.Drawing.Size(958, 513);
            this.splitContainer3.SplitterDistance = 470;
            this.splitContainer3.TabIndex = 1;
            // 
            // splitContainer10
            // 
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer10.Location = new System.Drawing.Point(0, 0);
            this.splitContainer10.Name = "splitContainer10";
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.checkBoxDisplayGpsSentence);
            this.splitContainer10.Panel1.Controls.Add(this.checkBoxAutoScrollDeviceLogs);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.buttonExit);
            this.splitContainer10.Panel2.Controls.Add(this.button7);
            this.splitContainer10.Panel2.Controls.Add(this.buttonClear1);
            this.splitContainer10.Panel2.Controls.Add(this.buttonClear);
            this.splitContainer10.Panel2.Controls.Add(this.button3);
            this.splitContainer10.Panel2.Controls.Add(this.buttonCopyTextBoxRcvData);
            this.splitContainer10.Size = new System.Drawing.Size(958, 39);
            this.splitContainer10.SplitterDistance = 246;
            this.splitContainer10.TabIndex = 0;
            // 
            // checkBoxDisplayGpsSentence
            // 
            this.checkBoxDisplayGpsSentence.AutoSize = true;
            this.checkBoxDisplayGpsSentence.Checked = true;
            this.checkBoxDisplayGpsSentence.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDisplayGpsSentence.Location = new System.Drawing.Point(-1, 19);
            this.checkBoxDisplayGpsSentence.Name = "checkBoxDisplayGpsSentence";
            this.checkBoxDisplayGpsSentence.Size = new System.Drawing.Size(85, 20);
            this.checkBoxDisplayGpsSentence.TabIndex = 0;
            this.checkBoxDisplayGpsSentence.Text = " GPS Logs";
            this.checkBoxDisplayGpsSentence.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoScrollDeviceLogs
            // 
            this.checkBoxAutoScrollDeviceLogs.AutoSize = true;
            this.checkBoxAutoScrollDeviceLogs.Checked = true;
            this.checkBoxAutoScrollDeviceLogs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoScrollDeviceLogs.Location = new System.Drawing.Point(-1, 0);
            this.checkBoxAutoScrollDeviceLogs.Name = "checkBoxAutoScrollDeviceLogs";
            this.checkBoxAutoScrollDeviceLogs.Size = new System.Drawing.Size(95, 20);
            this.checkBoxAutoScrollDeviceLogs.TabIndex = 24;
            this.checkBoxAutoScrollDeviceLogs.Text = "Auto scroll";
            this.checkBoxAutoScrollDeviceLogs.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonExit.Location = new System.Drawing.Point(570, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(138, 39);
            this.buttonExit.TabIndex = 28;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Location = new System.Drawing.Point(228, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(132, 33);
            this.button7.TabIndex = 27;
            this.button7.Text = "Stop Write To File";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // buttonClear1
            // 
            this.buttonClear1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear1.Location = new System.Drawing.Point(366, 4);
            this.buttonClear1.Name = "buttonClear1";
            this.buttonClear1.Size = new System.Drawing.Size(91, 33);
            this.buttonClear1.TabIndex = 26;
            this.buttonClear1.Text = "Clear";
            this.buttonClear1.UseVisualStyleBackColor = true;
            this.buttonClear1.Click += new System.EventHandler(this.buttonClear1_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(366, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(0, 33);
            this.buttonClear.TabIndex = 25;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click_1);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(91, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(131, 33);
            this.button3.TabIndex = 24;
            this.button3.Text = "Start Write To File";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 513);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(117, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "IO:";
            // 
            // textBoxIO
            // 
            this.textBoxIO.Location = new System.Drawing.Point(148, 18);
            this.textBoxIO.Name = "textBoxIO";
            this.textBoxIO.Size = new System.Drawing.Size(63, 22);
            this.textBoxIO.TabIndex = 23;
            // 
            // buttonTVND09
            // 
            this.buttonTVND09.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTVND09.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTVND09.Location = new System.Drawing.Point(79, 98);
            this.buttonTVND09.Name = "buttonTVND09";
            this.buttonTVND09.Size = new System.Drawing.Size(92, 33);
            this.buttonTVND09.TabIndex = 37;
            this.buttonTVND09.Text = "TVN03 - D09";
            this.buttonTVND09.UseVisualStyleBackColor = true;
            this.buttonTVND09.Click += new System.EventHandler(this.buttonTVND09_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(120, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 16);
            this.label11.TabIndex = 37;
            this.label11.Text = "Bootloader:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // textBoxBootloader
            // 
            this.textBoxBootloader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBootloader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBootloader.Location = new System.Drawing.Point(199, 8);
            this.textBoxBootloader.Name = "textBoxBootloader";
            this.textBoxBootloader.Size = new System.Drawing.Size(50, 22);
            this.textBoxBootloader.TabIndex = 38;
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(1229, 749);
            this.Controls.Add(this.tabControl1);
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
            this.tabControl1.ResumeLayout(false);
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
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            this.splitContainer6.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.splitContainer9.Panel1.ResumeLayout(false);
            this.splitContainer9.Panel2.ResumeLayout(false);
            this.splitContainer9.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel1.PerformLayout();
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBoxLogs.ResumeLayout(false);
            this.groupBoxLogs.PerformLayout();
            this.gprs4gStartus.ResumeLayout(false);
            this.gprs4gStartus.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel1.PerformLayout();
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
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

                //LstResults.SelectedIndex = LstResults.Items.Count - 1;

                ////  If the list box is getting too large, trim its contents by removing the earliest data.

                //if (LstResults.Items.Count > 1000)
                //{
                //	Int32 count;
                //	for (count = 1; count <= 500; count++)
                //	{
                //		LstResults.Items.RemoveAt(4);
                //	}
                //}
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
                // Init variable
                listBoxLog = new ListBoxLog(listBoxFirmwareUpdateLog1);
                // Init timer 
                //timerSerialPortRxDataParsing.Interval = SERIAL_PORT_DATA_HANDLER_INTERVAL;
                // Init display
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
                    AppendLineToTextBox(textBoxDeviceErrorMessage1, line, true);
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
                if (line.Contains("-RtcInfo"))
                {
                    //string[] rtcInfo = line.Split(',');
                    //textBoxRtcInfo.Text = rtcInfo[1];
                }
                else if (line.Contains("-I-DCE IMEI:"))
                {
                    string[] imei = line.Split(':');
                    textBoxImei.Text = imei[1];
                }
                else if (line.Contains("-I-FW Version:"))
                {
                    string[] FW = line.Split(':');
                    textBoxFwRev.Text = FW[1];
                }
                else if (line.Contains(" Bytes, @"))
                {
                    string[] time = line.Split('@');
                    textBoxTime.Text = time[1];
                }
                else if (line.Contains("+CSQ:"))
                {
                    string[] time = line.Split(':');
                    textBoxPos.Text = time[1];
                }
                else if (line.Contains("***************"))
                {
                    string[] time = line.Split('r');
                    textBoxBootloader.Text = time[1];
                }
                else if (line.Contains("-I--ADA:"))
                {
                    string[] voltageInfo = line.Split(',',':');
                    textBoxPower.Text = voltageInfo[5];
                    textBoxADB.Text = voltageInfo[2];
                    textBoxADA.Text = voltageInfo[1];
                    textBoxTempA.Text = voltageInfo[9];
                    textBoxIO.Text = voltageInfo[3];

                }
             

                else if (line.Contains("Temp:"))
                {
                    string[] time = line.Split(':');
                    textBoxTempA.Text = time[1];
                }
                else if (line.Contains(""))
                {
                    //string[] voltageInfo = line.Split(',');
                    //textBoxPwrVol.Text = voltageInfo[1];
                    //textBoxBatVol.Text = voltageInfo[2];
                    //textBoxAdaVol.Text = voltageInfo[3];
                    //textBoxAdbVol.Text = voltageInfo[4];
                }
                else if (line.Contains("-IoStatus"))
                {
                    //string[] statusInfo = line.Split(',');
                    //Byte ioStatus = Convert.ToByte(statusInfo[1]);
                    //if ((ioStatus & 0x08) == 0x08)
                    //{
                    //    textBoxDigitalIn1.Text = "On";
                    //}
                    //else
                    //{
                    //    textBoxDigitalIn1.Text = "Off";
                    //}
                    //if ((ioStatus & 0x10) == 0x10)
                    //{
                    //    textBoxDigitalIn2.Text = "On";
                    //}
                    //else
                    //{
                    //    textBoxDigitalIn2.Text = "Off";
                    //}
                }
                else if (line.Contains("-GpsInfo"))
                {
                    //string[] gpsInfo = line.Split(',');
                    //textBoxGpsStatus.Text = gpsInfo[1];
                    //textBoxGpsLocation.Text = gpsInfo[2] + ", " + gpsInfo[3];
                }
                else if (line.Contains("-SysInfo"))
                {
                    string[] sysInfo = line.Split(',');
                    //if (sysInfo.Length < 3)
                    //{
                    //    textBoxDeviceParameter.Text += (Environment.NewLine + sysInfo[1]);
                    //}
                    //else if(sysInfo.Length == 3)
                    //{
                    //    textBoxDeviceParameter.Text += (Environment.NewLine + sysInfo[1] + "," + sysInfo[2]);
                    //}
                    //else if (sysInfo.Length == 4)
                    //{
                    //    textBoxDeviceParameter.Text += (Environment.NewLine + sysInfo[1] + "," + sysInfo[2] + "," + sysInfo[3]);
                    //}
                    //else if (sysInfo.Length == 5)
                    //{
                    //    textBoxDeviceParameter.Text += (Environment.NewLine + sysInfo[1] + "," + sysInfo[2] + "," + sysInfo[3] + "," + sysInfo[4]);
                    //}
                    //textBoxDeviceParameter.SelectionStart = textBoxDeviceParameter.Text.Length;
                    //textBoxDeviceParameter.ScrollToCaret();
                    //textBoxDeviceParameter.Refresh();
                }

                // Add log to main display
                if (logEnable == true)
                {
                    AppendLineToTextBox(textBoxDeviceLogs, line, checkBoxAutoScrollDeviceLogs.Checked);
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
                        bootloaderProcessing.WaitingForResponseTimeoutCounter = 0;
                        packetNACKCounter = 0;
                        // Send next packet
                        int respPacketNo;
                        string[] field = respLine.Split(',');
                        respPacketNo = Convert.ToInt32(field[4]);

                        // Clear resp queue
                        bootLoaderRxResponseQueue.Clear();
                        if (respPacketNo < (bootloaderProcessing.TotalPacket - 1))
                        {
                            listBoxLog.Log(Level.Info, String.Format("Get ack response packet of packet no {0}, send next data packet", respPacketNo));
                            bootLoaderTxPacketQueue.Enqueue(bootloaderProcessing.PacketList[respPacketNo + 1]);
                        }
                        else
                        {
                            listBoxLog.Log(Level.Info, String.Format("Get ack response packet of packet no {0}, stop fw update", respPacketNo));
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxDeviceLogs.Clear();
        }

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            textBoxDeviceLogs.Clear();
            textBoxImei.Clear();
            textBoxDeviceErrorMessage1.Clear();
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
    }
}
