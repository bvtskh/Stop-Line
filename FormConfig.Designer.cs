namespace SMT
{
    partial class frmConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfig));
            this.label13 = new System.Windows.Forms.Label();
            this.cbbStopbit = new System.Windows.Forms.ComboBox();
            this.cbbParity = new System.Windows.Forms.ComboBox();
            this.cbbDatabit = new System.Windows.Forms.ComboBox();
            this.cbbBaudrate = new System.Windows.Forms.ComboBox();
            this.lblRefresh = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbbSerialPort = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStop = new System.Windows.Forms.TextBox();
            this.txtRun = new System.Windows.Forms.TextBox();
            this.groupBoxDataMode = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtWaring = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWaring = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnTestSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.nSleepTime = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvLine = new System.Windows.Forms.DataGridView();
            this.clLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cbbLine = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.LinkLabel();
            this.btnSaveChanged = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxDataMode.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSleepTime)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label13.Location = new System.Drawing.Point(33, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Run:";
            // 
            // cbbStopbit
            // 
            this.cbbStopbit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStopbit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbStopbit.FormattingEnabled = true;
            this.cbbStopbit.Location = new System.Drawing.Point(101, 155);
            this.cbbStopbit.Name = "cbbStopbit";
            this.cbbStopbit.Size = new System.Drawing.Size(209, 21);
            this.cbbStopbit.TabIndex = 34;
            // 
            // cbbParity
            // 
            this.cbbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbParity.FormattingEnabled = true;
            this.cbbParity.Location = new System.Drawing.Point(101, 121);
            this.cbbParity.Name = "cbbParity";
            this.cbbParity.Size = new System.Drawing.Size(209, 21);
            this.cbbParity.TabIndex = 33;
            // 
            // cbbDatabit
            // 
            this.cbbDatabit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbDatabit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDatabit.FormattingEnabled = true;
            this.cbbDatabit.Location = new System.Drawing.Point(101, 87);
            this.cbbDatabit.Name = "cbbDatabit";
            this.cbbDatabit.Size = new System.Drawing.Size(209, 21);
            this.cbbDatabit.TabIndex = 32;
            // 
            // cbbBaudrate
            // 
            this.cbbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBaudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbBaudrate.FormattingEnabled = true;
            this.cbbBaudrate.Location = new System.Drawing.Point(101, 53);
            this.cbbBaudrate.Name = "cbbBaudrate";
            this.cbbBaudrate.Size = new System.Drawing.Size(209, 21);
            this.cbbBaudrate.TabIndex = 31;
            // 
            // lblRefresh
            // 
            this.lblRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRefresh.Location = new System.Drawing.Point(330, 20);
            this.lblRefresh.Name = "lblRefresh";
            this.lblRefresh.Size = new System.Drawing.Size(17, 21);
            this.lblRefresh.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Parity:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(47, 157);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 13);
            this.label18.TabIndex = 21;
            this.label18.Text = "Stop Bits:";
            // 
            // cbbSerialPort
            // 
            this.cbbSerialPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSerialPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbSerialPort.FormattingEnabled = true;
            this.cbbSerialPort.Location = new System.Drawing.Point(101, 19);
            this.cbbSerialPort.Name = "cbbSerialPort";
            this.cbbSerialPort.Size = new System.Drawing.Size(209, 21);
            this.cbbSerialPort.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Data Bits:";
            // 
            // txtStop
            // 
            this.txtStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtStop.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStop.ForeColor = System.Drawing.Color.White;
            this.txtStop.Location = new System.Drawing.Point(64, 55);
            this.txtStop.Name = "txtStop";
            this.txtStop.Size = new System.Drawing.Size(63, 20);
            this.txtStop.TabIndex = 0;
            this.txtStop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRun
            // 
            this.txtRun.BackColor = System.Drawing.Color.Green;
            this.txtRun.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRun.ForeColor = System.Drawing.Color.White;
            this.txtRun.Location = new System.Drawing.Point(64, 27);
            this.txtRun.Name = "txtRun";
            this.txtRun.Size = new System.Drawing.Size(63, 20);
            this.txtRun.TabIndex = 0;
            this.txtRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxDataMode
            // 
            this.groupBoxDataMode.Controls.Add(this.label11);
            this.groupBoxDataMode.Controls.Add(this.label8);
            this.groupBoxDataMode.Controls.Add(this.label7);
            this.groupBoxDataMode.Controls.Add(this.txtWaring);
            this.groupBoxDataMode.Controls.Add(this.label2);
            this.groupBoxDataMode.Controls.Add(this.btnWaring);
            this.groupBoxDataMode.Controls.Add(this.txtStop);
            this.groupBoxDataMode.Controls.Add(this.txtRun);
            this.groupBoxDataMode.Controls.Add(this.label15);
            this.groupBoxDataMode.Controls.Add(this.btnStop);
            this.groupBoxDataMode.Controls.Add(this.btnTestSend);
            this.groupBoxDataMode.Controls.Add(this.label13);
            this.groupBoxDataMode.Location = new System.Drawing.Point(43, 244);
            this.groupBoxDataMode.Name = "groupBoxDataMode";
            this.groupBoxDataMode.Size = new System.Drawing.Size(267, 123);
            this.groupBoxDataMode.TabIndex = 31;
            this.groupBoxDataMode.TabStop = false;
            this.groupBoxDataMode.Text = "Signal Tranning";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label11.Location = new System.Drawing.Point(170, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 13);
            this.label11.TabIndex = 38;
            this.label11.Text = "Tín hiệu cảnh báo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(170, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Tín hiệu NG";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(170, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Tín hiệu OK";
            // 
            // txtWaring
            // 
            this.txtWaring.BackColor = System.Drawing.Color.Yellow;
            this.txtWaring.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtWaring.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWaring.ForeColor = System.Drawing.Color.Black;
            this.txtWaring.Location = new System.Drawing.Point(64, 84);
            this.txtWaring.Name = "txtWaring";
            this.txtWaring.Size = new System.Drawing.Size(63, 20);
            this.txtWaring.TabIndex = 24;
            this.txtWaring.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(13, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Warning:";
            // 
            // btnWaring
            // 
            this.btnWaring.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnWaring.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWaring.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWaring.ForeColor = System.Drawing.Color.White;
            this.btnWaring.Image = global::SMT.Properties.Resources.Forward_Arrow_16px;
            this.btnWaring.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWaring.Location = new System.Drawing.Point(132, 84);
            this.btnWaring.Name = "btnWaring";
            this.btnWaring.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnWaring.Size = new System.Drawing.Size(31, 24);
            this.btnWaring.TabIndex = 26;
            this.btnWaring.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWaring.UseVisualStyleBackColor = false;
            this.btnWaring.Click += new System.EventHandler(this.btnWaring_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label15.Location = new System.Drawing.Point(31, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Stop:";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Image = global::SMT.Properties.Resources.Forward_Arrow_16px;
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop.Location = new System.Drawing.Point(132, 55);
            this.btnStop.Name = "btnStop";
            this.btnStop.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnStop.Size = new System.Drawing.Size(31, 24);
            this.btnStop.TabIndex = 23;
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnTestSend
            // 
            this.btnTestSend.BackColor = System.Drawing.Color.Green;
            this.btnTestSend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTestSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestSend.ForeColor = System.Drawing.Color.White;
            this.btnTestSend.Image = global::SMT.Properties.Resources.Forward_Arrow_16px;
            this.btnTestSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTestSend.Location = new System.Drawing.Point(133, 24);
            this.btnTestSend.Name = "btnTestSend";
            this.btnTestSend.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTestSend.Size = new System.Drawing.Size(31, 25);
            this.btnTestSend.TabIndex = 23;
            this.btnTestSend.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTestSend.UseVisualStyleBackColor = false;
            this.btnTestSend.Click += new System.EventHandler(this.btnTestSend_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Baudrate:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.nSleepTime);
            this.groupBox2.Controls.Add(this.cbbStopbit);
            this.groupBox2.Controls.Add(this.groupBoxDataMode);
            this.groupBox2.Controls.Add(this.cbbParity);
            this.groupBox2.Controls.Add(this.cbbDatabit);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.cbbBaudrate);
            this.groupBox2.Controls.Add(this.lblRefresh);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbbSerialPort);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(23, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(382, 393);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Port";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(312, 195);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "Miliseconds";
            // 
            // nSleepTime
            // 
            this.nSleepTime.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nSleepTime.Location = new System.Drawing.Point(101, 189);
            this.nSleepTime.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nSleepTime.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nSleepTime.Name = "nSleepTime";
            this.nSleepTime.Size = new System.Drawing.Size(209, 20);
            this.nSleepTime.TabIndex = 37;
            this.nSleepTime.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(36, 190);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 13);
            this.label16.TabIndex = 36;
            this.label16.Text = "Sleep Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Port Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLine);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.cbbLine);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Location = new System.Drawing.Point(411, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 393);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Line Settings";
            // 
            // dgvLine
            // 
            this.dgvLine.AllowUserToAddRows = false;
            this.dgvLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clLine});
            this.dgvLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLine.Location = new System.Drawing.Point(3, 53);
            this.dgvLine.Name = "dgvLine";
            this.dgvLine.RowHeadersVisible = false;
            this.dgvLine.Size = new System.Drawing.Size(314, 337);
            this.dgvLine.TabIndex = 42;
            // 
            // clLine
            // 
            this.clLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clLine.HeaderText = "Line";
            this.clLine.Name = "clLine";
            this.clLine.ReadOnly = true;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Green;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Image = global::SMT.Properties.Resources.trash_16;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(232, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnRemove.Size = new System.Drawing.Size(84, 30);
            this.btnRemove.TabIndex = 41;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Green;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Image = global::SMT.Properties.Resources.plus_16;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(139, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnAdd.Size = new System.Drawing.Size(84, 30);
            this.btnAdd.TabIndex = 40;
            this.btnAdd.Text = "&Add";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cbbLine
            // 
            this.cbbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbLine.FormattingEnabled = true;
            this.cbbLine.Location = new System.Drawing.Point(6, 19);
            this.cbbLine.Name = "cbbLine";
            this.cbbLine.Size = new System.Drawing.Size(129, 21);
            this.cbbLine.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label9.Location = new System.Drawing.Point(267, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 21);
            this.label9.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Location = new System.Drawing.Point(281, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 21);
            this.label10.TabIndex = 27;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUser.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(694, 5);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(51, 19);
            this.lblUser.TabIndex = 34;
            this.lblUser.TabStop = true;
            this.lblUser.Text = "Login";
            this.lblUser.Click += new System.EventHandler(this.lblUser_Click);
            // 
            // btnSaveChanged
            // 
            this.btnSaveChanged.BackColor = System.Drawing.Color.Green;
            this.btnSaveChanged.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanged.ForeColor = System.Drawing.Color.White;
            this.btnSaveChanged.Image = global::SMT.Properties.Resources.Save;
            this.btnSaveChanged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChanged.Location = new System.Drawing.Point(647, 456);
            this.btnSaveChanged.Name = "btnSaveChanged";
            this.btnSaveChanged.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnSaveChanged.Size = new System.Drawing.Size(75, 30);
            this.btnSaveChanged.TabIndex = 29;
            this.btnSaveChanged.Text = "&Save";
            this.btnSaveChanged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveChanged.UseVisualStyleBackColor = false;
            this.btnSaveChanged.Click += new System.EventHandler(this.btnSaveChanged_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 492);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(694, 22);
            this.statusStrip1.TabIndex = 35;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel1.Text = "Configuration";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 514);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSaveChanged);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 5, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.groupBoxDataMode.ResumeLayout(false);
            this.groupBoxDataMode.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nSleepTime)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLine)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSaveChanged;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ComboBox cbbStopbit;
        private System.Windows.Forms.ComboBox cbbParity;
        private System.Windows.Forms.ComboBox cbbDatabit;
        private System.Windows.Forms.ComboBox cbbBaudrate;
        private System.Windows.Forms.Label lblRefresh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnTestSend;
        private System.Windows.Forms.ComboBox cbbSerialPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStop;
        private System.Windows.Forms.TextBox txtRun;
        private System.Windows.Forms.GroupBox groupBoxDataMode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvLine;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbbLine;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn clLine;
        private System.Windows.Forms.TextBox txtWaring;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnWaring;
        private System.Windows.Forms.LinkLabel lblUser;
        private System.Windows.Forms.NumericUpDown nSleepTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}