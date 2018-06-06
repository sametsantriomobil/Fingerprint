namespace FingerPrint
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.buttonConnect = new System.Windows.Forms.ToolStripButton();
            this.baudrateList = new System.Windows.Forms.ToolStripComboBox();
            this.portList = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusText2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.greenLoc = new System.Windows.Forms.PictureBox();
            this.blueLoc = new System.Windows.Forms.PictureBox();
            this.redLoc = new System.Windows.Forms.PictureBox();
            this.map = new System.Windows.Forms.PictureBox();
            this.btnAnchDel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Addr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RSSI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAnchAdd = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFpAdd = new System.Windows.Forms.Button();
            this.btnFpDel = new System.Windows.Forms.Button();
            this.serial_reader = new System.ComponentModel.BackgroundWorker();
            this.map_refresher = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.greenLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redLoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton4,
            this.toolStripButton6,
            this.toolStripButton5,
            this.toolStripSeparator1,
            this.toolStripButton3,
            this.toolStripButton1,
            this.buttonConnect,
            this.baudrateList,
            this.portList,
            this.toolStripSeparator2,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(784, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = global::FingerPrint.Properties.Resources.new_by_copy;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "New";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = global::FingerPrint.Properties.Resources.folder_2_open_128;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "Open";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = global::FingerPrint.Properties.Resources.bfa_save_simple_black_512x512;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "Save";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::FingerPrint.Properties.Resources.img_459359;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton3.Text = "Log in";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click_1);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::FingerPrint.Properties.Resources.map_7;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(114, 22);
            this.toolStripButton1.Text = "Select Floor Plan";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.buttonConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.buttonConnect.Image = ((System.Drawing.Image)(resources.GetObject("buttonConnect.Image")));
            this.buttonConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(56, 22);
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // baudrateList
            // 
            this.baudrateList.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.baudrateList.Name = "baudrateList";
            this.baudrateList.Size = new System.Drawing.Size(121, 25);
            // 
            // portList
            // 
            this.portList.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.portList.Name = "portList";
            this.portList.Size = new System.Drawing.Size(121, 25);
            this.portList.Click += new System.EventHandler(this.portList_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::FingerPrint.Properties.Resources.send_letter;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(53, 22);
            this.toolStripButton2.Text = "Send";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText,
            this.statusText2});
            this.statusBar.Location = new System.Drawing.Point(0, 339);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(784, 22);
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(12, 17);
            this.statusText.Text = "-";
            // 
            // statusText2
            // 
            this.statusText2.Name = "statusText2";
            this.statusText2.Size = new System.Drawing.Size(12, 17);
            this.statusText2.Text = "-";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.greenLoc);
            this.panel1.Controls.Add(this.blueLoc);
            this.panel1.Controls.Add(this.redLoc);
            this.panel1.Controls.Add(this.map);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 308);
            this.panel1.TabIndex = 6;
            // 
            // greenLoc
            // 
            this.greenLoc.Image = global::FingerPrint.Properties.Resources.green_location;
            this.greenLoc.Location = new System.Drawing.Point(370, 168);
            this.greenLoc.Name = "greenLoc";
            this.greenLoc.Size = new System.Drawing.Size(21, 32);
            this.greenLoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenLoc.TabIndex = 8;
            this.greenLoc.TabStop = false;
            this.greenLoc.Visible = false;
            // 
            // blueLoc
            // 
            this.blueLoc.Image = global::FingerPrint.Properties.Resources.blue_location;
            this.blueLoc.Location = new System.Drawing.Point(250, 138);
            this.blueLoc.Name = "blueLoc";
            this.blueLoc.Size = new System.Drawing.Size(21, 32);
            this.blueLoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueLoc.TabIndex = 7;
            this.blueLoc.TabStop = false;
            this.blueLoc.Visible = false;
            // 
            // redLoc
            // 
            this.redLoc.Image = global::FingerPrint.Properties.Resources.red_location;
            this.redLoc.Location = new System.Drawing.Point(326, 99);
            this.redLoc.Name = "redLoc";
            this.redLoc.Size = new System.Drawing.Size(21, 32);
            this.redLoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redLoc.TabIndex = 6;
            this.redLoc.TabStop = false;
            this.redLoc.Visible = false;
            // 
            // map
            // 
            this.map.Location = new System.Drawing.Point(3, 3);
            this.map.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(0, 0);
            this.map.TabIndex = 5;
            this.map.TabStop = false;
            this.map.Click += new System.EventHandler(this.map_Click);
            this.map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map_MouseMove);
            // 
            // btnAnchDel
            // 
            this.btnAnchDel.Location = new System.Drawing.Point(85, 6);
            this.btnAnchDel.Name = "btnAnchDel";
            this.btnAnchDel.Size = new System.Drawing.Size(77, 23);
            this.btnAnchDel.TabIndex = 1;
            this.btnAnchDel.Text = "Delete";
            this.btnAnchDel.UseVisualStyleBackColor = true;
            this.btnAnchDel.Click += new System.EventHandler(this.btnAnchDel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(538, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(246, 308);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(238, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Addr,
            this.RSSI});
            this.listView1.Location = new System.Drawing.Point(0, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(238, 276);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Addr
            // 
            this.Addr.Text = "Addr";
            this.Addr.Width = 119;
            // 
            // RSSI
            // 
            this.RSSI.Text = "RSSI";
            this.RSSI.Width = 119;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Controls.Add(this.btnAnchAdd);
            this.tabPage2.Controls.Add(this.btnAnchDel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(238, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Anchors";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.FullRowSelect = true;
            this.listView2.Location = new System.Drawing.Point(3, 35);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(229, 244);
            this.listView2.TabIndex = 11;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Addr";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "RSSI";
            this.columnHeader2.Width = 30;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "X";
            this.columnHeader3.Width = 74;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Y";
            this.columnHeader4.Width = 74;
            // 
            // btnAnchAdd
            // 
            this.btnAnchAdd.Location = new System.Drawing.Point(3, 6);
            this.btnAnchAdd.Name = "btnAnchAdd";
            this.btnAnchAdd.Size = new System.Drawing.Size(76, 23);
            this.btnAnchAdd.TabIndex = 0;
            this.btnAnchAdd.Text = "Add";
            this.btnAnchAdd.UseVisualStyleBackColor = true;
            this.btnAnchAdd.Click += new System.EventHandler(this.btnAnchAdd_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView3);
            this.tabPage3.Controls.Add(this.btnFpAdd);
            this.tabPage3.Controls.Add(this.btnFpDel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(238, 282);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "FingerPrints";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listView3.FullRowSelect = true;
            this.listView3.Location = new System.Drawing.Point(3, 36);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(229, 243);
            this.listView3.TabIndex = 13;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            this.listView3.SelectedIndexChanged += new System.EventHandler(this.listView3_SelectedIndexChanged_1);
            this.listView3.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.loogFP);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 25;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "X";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Y";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Measurements";
            // 
            // btnFpAdd
            // 
            this.btnFpAdd.Location = new System.Drawing.Point(3, 7);
            this.btnFpAdd.Name = "btnFpAdd";
            this.btnFpAdd.Size = new System.Drawing.Size(76, 23);
            this.btnFpAdd.TabIndex = 0;
            this.btnFpAdd.Text = "Add";
            this.btnFpAdd.UseVisualStyleBackColor = true;
            this.btnFpAdd.Click += new System.EventHandler(this.btnFpAdd_Click);
            // 
            // btnFpDel
            // 
            this.btnFpDel.Location = new System.Drawing.Point(85, 7);
            this.btnFpDel.Name = "btnFpDel";
            this.btnFpDel.Size = new System.Drawing.Size(77, 23);
            this.btnFpDel.TabIndex = 1;
            this.btnFpDel.Text = "Delete";
            this.btnFpDel.UseVisualStyleBackColor = true;
            this.btnFpDel.Click += new System.EventHandler(this.btnFpDel_Click);
            // 
            // serial_reader
            // 
            this.serial_reader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.serial_reader_DoWork_1);
            // 
            // map_refresher
            // 
            this.map_refresher.DoWork += new System.ComponentModel.DoWorkEventHandler(this.map_refresher_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FingerPrint";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.greenLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redLoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton buttonConnect;
        private System.Windows.Forms.ToolStripComboBox baudrateList;
        private System.Windows.Forms.ToolStripComboBox portList;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.PictureBox map;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.Button btnAnchDel;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.ComponentModel.BackgroundWorker serial_reader;
        private System.ComponentModel.BackgroundWorker map_refresher;
        private System.Windows.Forms.Button btnAnchAdd;
        private System.Windows.Forms.Button btnFpAdd;
        private System.Windows.Forms.Button btnFpDel;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel statusText2;
        private System.Windows.Forms.PictureBox redLoc;
        private System.Windows.Forms.PictureBox blueLoc;
        private System.Windows.Forms.PictureBox greenLoc;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Addr;
        private System.Windows.Forms.ColumnHeader RSSI;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}

