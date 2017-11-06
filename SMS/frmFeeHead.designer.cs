namespace SMS
{
    partial class framfeesetup
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
            this.btnprint = new System.Windows.Forms.Button();
            this.txtfeehead = new System.Windows.Forms.TextBox();
            this.cmbfeetype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtclasscode = new System.Windows.Forms.TextBox();
            this.rdoDualSlip = new System.Windows.Forms.RadioButton();
            this.rdoSingleSlip = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.White;
            this.btnprint.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(589, 364);
            this.btnprint.Margin = new System.Windows.Forms.Padding(4);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(13, 41);
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "&Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Visible = false;
            // 
            // txtfeehead
            // 
            this.txtfeehead.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfeehead.ForeColor = System.Drawing.Color.Blue;
            this.txtfeehead.Location = new System.Drawing.Point(108, 8);
            this.txtfeehead.Margin = new System.Windows.Forms.Padding(4);
            this.txtfeehead.Name = "txtfeehead";
            this.txtfeehead.Size = new System.Drawing.Size(203, 25);
            this.txtfeehead.TabIndex = 1;
            this.txtfeehead.Tag = "feeheads";
            this.txtfeehead.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtfeehead_KeyPress);
            // 
            // cmbfeetype
            // 
            this.cmbfeetype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbfeetype.FormattingEnabled = true;
            this.cmbfeetype.Items.AddRange(new object[] {
            "One Time Fee",
            "Regular Fee"});
            this.cmbfeetype.Location = new System.Drawing.Point(109, 55);
            this.cmbfeetype.Margin = new System.Windows.Forms.Padding(4);
            this.cmbfeetype.Name = "cmbfeetype";
            this.cmbfeetype.Size = new System.Drawing.Size(201, 25);
            this.cmbfeetype.TabIndex = 2;
            this.cmbfeetype.Tag = "feetype";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(4, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 134;
            this.label2.Text = "Fee Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 19);
            this.label1.TabIndex = 133;
            this.label1.Text = "Fee Heads";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(394, 63);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(237, 276);
            this.listBox1.TabIndex = 138;
            this.listBox1.TabStop = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // txtclasscode
            // 
            this.txtclasscode.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtclasscode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclasscode.ForeColor = System.Drawing.Color.Blue;
            this.txtclasscode.Location = new System.Drawing.Point(367, 347);
            this.txtclasscode.Margin = new System.Windows.Forms.Padding(4);
            this.txtclasscode.MaxLength = 30;
            this.txtclasscode.Name = "txtclasscode";
            this.txtclasscode.Size = new System.Drawing.Size(83, 25);
            this.txtclasscode.TabIndex = 0;
            this.txtclasscode.TabStop = false;
            this.txtclasscode.Tag = "feecode";
            this.txtclasscode.Visible = false;
            // 
            // rdoDualSlip
            // 
            this.rdoDualSlip.AutoSize = true;
            this.rdoDualSlip.BackColor = System.Drawing.Color.Transparent;
            this.rdoDualSlip.Checked = true;
            this.rdoDualSlip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoDualSlip.ForeColor = System.Drawing.Color.White;
            this.rdoDualSlip.Location = new System.Drawing.Point(177, 101);
            this.rdoDualSlip.Margin = new System.Windows.Forms.Padding(4);
            this.rdoDualSlip.Name = "rdoDualSlip";
            this.rdoDualSlip.Size = new System.Drawing.Size(107, 24);
            this.rdoDualSlip.TabIndex = 140;
            this.rdoDualSlip.TabStop = true;
            this.rdoDualSlip.Tag = "";
            this.rdoDualSlip.Text = "Dual Slip";
            this.rdoDualSlip.UseVisualStyleBackColor = false;
            this.rdoDualSlip.CheckedChanged += new System.EventHandler(this.rdoDualSlip_CheckedChanged);
            // 
            // rdoSingleSlip
            // 
            this.rdoSingleSlip.AutoSize = true;
            this.rdoSingleSlip.BackColor = System.Drawing.Color.Transparent;
            this.rdoSingleSlip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSingleSlip.ForeColor = System.Drawing.Color.White;
            this.rdoSingleSlip.Location = new System.Drawing.Point(177, 136);
            this.rdoSingleSlip.Margin = new System.Windows.Forms.Padding(4);
            this.rdoSingleSlip.Name = "rdoSingleSlip";
            this.rdoSingleSlip.Size = new System.Drawing.Size(120, 24);
            this.rdoSingleSlip.TabIndex = 141;
            this.rdoSingleSlip.Tag = "";
            this.rdoSingleSlip.Text = "Single Slip";
            this.rdoSingleSlip.UseVisualStyleBackColor = false;
            this.rdoSingleSlip.CheckedChanged += new System.EventHandler(this.rdoSingleSlip_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 101);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 19);
            this.label4.TabIndex = 142;
            this.label4.Text = "Fee Receipt Type";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rdoSingleSlip);
            this.panel2.Controls.Add(this.cmbfeetype);
            this.panel2.Controls.Add(this.rdoDualSlip);
            this.panel2.Controls.Add(this.txtfeehead);
            this.panel2.Location = new System.Drawing.Point(60, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 276);
            this.panel2.TabIndex = 143;
            // 
            // framfeesetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtclasscode);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "framfeesetup";
            this.Size = new System.Drawing.Size(685, 455);
            this.Tag = "1033";
            this.Load += new System.EventHandler(this.Framfeesetup_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.framfeesetup_Paint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.TextBox txtfeehead;
        private System.Windows.Forms.ComboBox cmbfeetype;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtclasscode;
        private System.Windows.Forms.RadioButton rdoDualSlip;
        private System.Windows.Forms.RadioButton rdoSingleSlip;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
    }
}