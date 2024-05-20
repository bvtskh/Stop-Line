namespace SMT
{
    partial class frmLineAddOrUpdate
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkTokusai = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkReload = new System.Windows.Forms.CheckBox();
            this.chkFeeder = new System.Windows.Forms.CheckBox();
            this.feederSpec = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLineID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVerify = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feederSpec)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbVerify);
            this.panel2.Controls.Add(this.chkTokusai);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.chkReload);
            this.panel2.Controls.Add(this.chkFeeder);
            this.panel2.Controls.Add(this.feederSpec);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtLineID);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 262);
            this.panel2.TabIndex = 3;
            // 
            // chkTokusai
            // 
            this.chkTokusai.AutoSize = true;
            this.chkTokusai.Checked = true;
            this.chkTokusai.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTokusai.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTokusai.Location = new System.Drawing.Point(125, 148);
            this.chkTokusai.Name = "chkTokusai";
            this.chkTokusai.Size = new System.Drawing.Size(143, 17);
            this.chkTokusai.TabIndex = 38;
            this.chkTokusai.Text = "Check Tokusai Confirm";
            this.chkTokusai.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(249, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Thời gian cảnh báo Feeder";
            // 
            // chkReload
            // 
            this.chkReload.AutoSize = true;
            this.chkReload.Checked = true;
            this.chkReload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReload.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkReload.Location = new System.Drawing.Point(126, 122);
            this.chkReload.Name = "chkReload";
            this.chkReload.Size = new System.Drawing.Size(96, 17);
            this.chkReload.TabIndex = 36;
            this.chkReload.Text = "Check Reload";
            this.chkReload.UseVisualStyleBackColor = true;
            // 
            // chkFeeder
            // 
            this.chkFeeder.AutoSize = true;
            this.chkFeeder.Checked = true;
            this.chkFeeder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFeeder.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFeeder.Location = new System.Drawing.Point(126, 93);
            this.chkFeeder.Name = "chkFeeder";
            this.chkFeeder.Size = new System.Drawing.Size(95, 17);
            this.chkFeeder.TabIndex = 35;
            this.chkFeeder.Text = "Check Feeder";
            this.chkFeeder.UseVisualStyleBackColor = true;
            // 
            // feederSpec
            // 
            this.feederSpec.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feederSpec.Location = new System.Drawing.Point(128, 60);
            this.feederSpec.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.feederSpec.Name = "feederSpec";
            this.feederSpec.Size = new System.Drawing.Size(117, 22);
            this.feederSpec.TabIndex = 34;
            this.feederSpec.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::SMT.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(126, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Saves ";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label3.Location = new System.Drawing.Point(35, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Feeder Spec:";
            // 
            // txtLineID
            // 
            this.txtLineID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineID.Location = new System.Drawing.Point(126, 26);
            this.txtLineID.Name = "txtLineID";
            this.txtLineID.Size = new System.Drawing.Size(119, 22);
            this.txtLineID.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(76, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Line:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 51);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 51);
            this.label1.TabIndex = 3;
            this.label1.Text = "Line Setting";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbVerify
            // 
            this.cbVerify.AutoSize = true;
            this.cbVerify.Checked = true;
            this.cbVerify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVerify.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVerify.Location = new System.Drawing.Point(125, 172);
            this.cbVerify.Name = "cbVerify";
            this.cbVerify.Size = new System.Drawing.Size(88, 17);
            this.cbVerify.TabIndex = 39;
            this.cbVerify.Text = "Check Verify";
            this.cbVerify.UseVisualStyleBackColor = true;
            // 
            // frmLineAddOrUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 313);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLineAddOrUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Line setting";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feederSpec)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLineID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkReload;
        private System.Windows.Forms.CheckBox chkFeeder;
        private System.Windows.Forms.NumericUpDown feederSpec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkTokusai;
        private System.Windows.Forms.CheckBox cbVerify;
    }
}