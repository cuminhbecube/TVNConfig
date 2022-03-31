namespace GenericHid
{
    partial class FrmFirmwareUpdate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.fraDeviceIdentifiers = new System.Windows.Forms.GroupBox();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.txtVendorID = new System.Windows.Forms.TextBox();
            this.lblVendorID = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.fraDeviceIdentifiers.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Firmware version:";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(12, 104);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Update";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "Reboot device";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(387, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open file";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 130);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(516, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // fraDeviceIdentifiers
            // 
            this.fraDeviceIdentifiers.Controls.Add(this.txtProductID);
            this.fraDeviceIdentifiers.Controls.Add(this.lblProductID);
            this.fraDeviceIdentifiers.Controls.Add(this.txtVendorID);
            this.fraDeviceIdentifiers.Controls.Add(this.lblVendorID);
            this.fraDeviceIdentifiers.Location = new System.Drawing.Point(212, 57);
            this.fraDeviceIdentifiers.Name = "fraDeviceIdentifiers";
            this.fraDeviceIdentifiers.Size = new System.Drawing.Size(260, 54);
            this.fraDeviceIdentifiers.TabIndex = 11;
            this.fraDeviceIdentifiers.TabStop = false;
            this.fraDeviceIdentifiers.Text = "Device Identifiers";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(200, 21);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(42, 20);
            this.txtProductID.TabIndex = 3;
            this.txtProductID.Text = "5750";
            // 
            // lblProductID
            // 
            this.lblProductID.Location = new System.Drawing.Point(134, 24);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(60, 23);
            this.lblProductID.TabIndex = 2;
            this.lblProductID.Text = "PID (hex):";
            // 
            // txtVendorID
            // 
            this.txtVendorID.Location = new System.Drawing.Point(68, 21);
            this.txtVendorID.Name = "txtVendorID";
            this.txtVendorID.Size = new System.Drawing.Size(42, 20);
            this.txtVendorID.TabIndex = 1;
            this.txtVendorID.Text = "0483";
            // 
            // lblVendorID
            // 
            this.lblVendorID.Location = new System.Drawing.Point(13, 24);
            this.lblVendorID.Name = "lblVendorID";
            this.lblVendorID.Size = new System.Drawing.Size(60, 23);
            this.lblVendorID.TabIndex = 0;
            this.lblVendorID.Text = "VID (hex):";
            // 
            // FrmFirmwareUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 152);
            this.Controls.Add(this.fraDeviceIdentifiers);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmFirmwareUpdate";
            this.Text = "FrmFirmwareUpdate";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.fraDeviceIdentifiers.ResumeLayout(false);
            this.fraDeviceIdentifiers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        internal System.Windows.Forms.GroupBox fraDeviceIdentifiers;
        internal System.Windows.Forms.TextBox txtProductID;
        internal System.Windows.Forms.Label lblProductID;
        internal System.Windows.Forms.TextBox txtVendorID;
        internal System.Windows.Forms.Label lblVendorID;
    }
}