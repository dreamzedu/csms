namespace SMS.Report.Student.ReportForm
{
    partial class frmScholarshipStatus
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.chkClassWise = new System.Windows.Forms.CheckBox();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.dgvScholarDetails = new System.Windows.Forms.DataGridView();
            this.chkReceive = new System.Windows.Forms.CheckBox();
            this.chkSanction = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAYS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholarDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(287, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(390, 24);
            this.label2.TabIndex = 187;
            this.label2.Text = "Student Scholar Ship Application Details";
            // 
            // cmbSection
            // 
            this.cmbSection.Enabled = false;
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.ForeColor = System.Drawing.Color.Blue;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(675, 53);
            this.cmbSection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(92, 28);
            this.cmbSection.TabIndex = 4;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.BackColor = System.Drawing.Color.Transparent;
            this.chkSection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSection.ForeColor = System.Drawing.Color.White;
            this.chkSection.Location = new System.Drawing.Point(533, 58);
            this.chkSection.Margin = new System.Windows.Forms.Padding(4);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(134, 23);
            this.chkSection.TabIndex = 3;
            this.chkSection.Text = "Section Wise";
            this.chkSection.UseVisualStyleBackColor = false;
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            // 
            // chkClassWise
            // 
            this.chkClassWise.AutoSize = true;
            this.chkClassWise.BackColor = System.Drawing.Color.Transparent;
            this.chkClassWise.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClassWise.ForeColor = System.Drawing.Color.White;
            this.chkClassWise.Location = new System.Drawing.Point(254, 60);
            this.chkClassWise.Margin = new System.Windows.Forms.Padding(4);
            this.chkClassWise.Name = "chkClassWise";
            this.chkClassWise.Size = new System.Drawing.Size(118, 23);
            this.chkClassWise.TabIndex = 1;
            this.chkClassWise.Text = "Class Wise";
            this.chkClassWise.UseVisualStyleBackColor = false;
            this.chkClassWise.CheckedChanged += new System.EventHandler(this.chkClassWise_CheckedChanged);
            // 
            // cmbSession
            // 
            this.cmbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.Blue;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(103, 56);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(116, 28);
            this.cmbSession.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 186;
            this.label1.Text = "Session ";
            // 
            // cmbClass
            // 
            this.cmbClass.Enabled = false;
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ForeColor = System.Drawing.Color.Blue;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(380, 55);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(101, 28);
            this.cmbClass.TabIndex = 2;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            this.cmbClass.Leave += new System.EventHandler(this.cmbClass_Leave);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(755, 92);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(101, 28);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dgvScholarDetails
            // 
            this.dgvScholarDetails.AllowUserToAddRows = false;
            this.dgvScholarDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScholarDetails.Location = new System.Drawing.Point(5, 129);
            this.dgvScholarDetails.Margin = new System.Windows.Forms.Padding(4);
            this.dgvScholarDetails.Name = "dgvScholarDetails";
            this.dgvScholarDetails.ReadOnly = true;
            this.dgvScholarDetails.Size = new System.Drawing.Size(1007, 378);
            this.dgvScholarDetails.TabIndex = 10;
            this.dgvScholarDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvScholarDetails_DataBindingComplete);
            // 
            // chkReceive
            // 
            this.chkReceive.AutoSize = true;
            this.chkReceive.BackColor = System.Drawing.Color.Transparent;
            this.chkReceive.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkReceive.ForeColor = System.Drawing.Color.White;
            this.chkReceive.Location = new System.Drawing.Point(456, 97);
            this.chkReceive.Margin = new System.Windows.Forms.Padding(4);
            this.chkReceive.Name = "chkReceive";
            this.chkReceive.Size = new System.Drawing.Size(155, 23);
            this.chkReceive.TabIndex = 6;
            this.chkReceive.Text = "NOT RECEIVED";
            this.chkReceive.UseVisualStyleBackColor = false;
            this.chkReceive.CheckedChanged += new System.EventHandler(this.chkReceive_CheckedChanged);
            // 
            // chkSanction
            // 
            this.chkSanction.AutoSize = true;
            this.chkSanction.BackColor = System.Drawing.Color.Transparent;
            this.chkSanction.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkSanction.ForeColor = System.Drawing.Color.White;
            this.chkSanction.Location = new System.Drawing.Point(87, 97);
            this.chkSanction.Margin = new System.Windows.Forms.Padding(4);
            this.chkSanction.Name = "chkSanction";
            this.chkSanction.Size = new System.Drawing.Size(156, 23);
            this.chkSanction.TabIndex = 5;
            this.chkSanction.Text = "NOT SANCTION";
            this.chkSanction.UseVisualStyleBackColor = false;
            this.chkSanction.CheckedChanged += new System.EventHandler(this.chkSanction_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(291, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 19);
            this.label5.TabIndex = 192;
            this.label5.Text = "Distribution Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 100);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 19);
            this.label4.TabIndex = 191;
            this.label4.Text = "Status";
            // 
            // btnAYS
            // 
            this.btnAYS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAYS.Location = new System.Drawing.Point(858, 92);
            this.btnAYS.Margin = new System.Windows.Forms.Padding(4);
            this.btnAYS.Name = "btnAYS";
            this.btnAYS.Size = new System.Drawing.Size(152, 28);
            this.btnAYS.TabIndex = 8;
            this.btnAYS.Text = "All Year Status";
            this.btnAYS.UseVisualStyleBackColor = true;
            this.btnAYS.Click += new System.EventHandler(this.btnAYS_Click);
            // 
            // frmScholarshipStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAYS);
            this.Controls.Add(this.chkReceive);
            this.Controls.Add(this.chkSanction);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvScholarDetails);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.chkSection);
            this.Controls.Add(this.chkClassWise);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClass);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmScholarshipStatus";
            this.Size = new System.Drawing.Size(1017, 512);
            this.Load += new System.EventHandler(this.frmScholarshipStatus_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmScholarshipStatus_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScholarDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.CheckBox chkClassWise;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView dgvScholarDetails;
        private System.Windows.Forms.CheckBox chkReceive;
        private System.Windows.Forms.CheckBox chkSanction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAYS;
    }
}