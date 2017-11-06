namespace SMS
{
    partial class frmDueFee
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
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chkClassWise = new System.Windows.Forms.CheckBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.cmbStudentStatus = new System.Windows.Forms.ComboBox();
            this.ChkIdDueGreater = new System.Windows.Forms.CheckBox();
            this.cachedBankReceipt1 = new SMS.Account.ReportDesign.CachedBankReceipt();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbClass
            // 
            this.cmbClass.Enabled = false;
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ForeColor = System.Drawing.Color.Blue;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(560, 59);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(106, 28);
            this.cmbClass.TabIndex = 2;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            this.cmbClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbClass_KeyPress);
            this.cmbClass.Leave += new System.EventHandler(this.cmbClass_Leave);
            // 
            // cmbSession
            // 
            this.cmbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.Blue;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(136, 59);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(88, 28);
            this.cmbSession.TabIndex = 0;
            this.cmbSession.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSession_KeyPress);
            this.cmbSession.Leave += new System.EventHandler(this.cmbSession_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 44;
            this.label1.Text = "Session ";
            // 
            // cmbSection
            // 
            this.cmbSection.Enabled = false;
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.ForeColor = System.Drawing.Color.Blue;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(825, 59);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(106, 28);
            this.cmbSection.TabIndex = 4;
            this.cmbSection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSection_KeyPress);
            this.cmbSection.Leave += new System.EventHandler(this.cmbSection_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(67, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(864, 387);
            this.dataGridView1.TabIndex = 58;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // chkClassWise
            // 
            this.chkClassWise.AutoSize = true;
            this.chkClassWise.BackColor = System.Drawing.Color.Transparent;
            this.chkClassWise.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClassWise.ForeColor = System.Drawing.Color.White;
            this.chkClassWise.Location = new System.Drawing.Point(443, 62);
            this.chkClassWise.Name = "chkClassWise";
            this.chkClassWise.Size = new System.Drawing.Size(118, 23);
            this.chkClassWise.TabIndex = 1;
            this.chkClassWise.Text = "Class Wise";
            this.chkClassWise.UseVisualStyleBackColor = false;
            this.chkClassWise.CheckedChanged += new System.EventHandler(this.chkClassWise_CheckedChanged);
            this.chkClassWise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkClassWise_KeyPress);
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.BackColor = System.Drawing.Color.Transparent;
            this.chkSection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSection.ForeColor = System.Drawing.Color.White;
            this.chkSection.Location = new System.Drawing.Point(693, 62);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(134, 23);
            this.chkSection.TabIndex = 3;
            this.chkSection.Text = "Section Wise";
            this.chkSection.UseVisualStyleBackColor = false;
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            this.chkSection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkSection_KeyPress);
            // 
            // cmbStudentStatus
            // 
            this.cmbStudentStatus.FormattingEnabled = true;
            this.cmbStudentStatus.Items.AddRange(new object[] {
            "All Student",
            "Studying Student",
            "New Student"});
            this.cmbStudentStatus.Location = new System.Drawing.Point(233, 61);
            this.cmbStudentStatus.Name = "cmbStudentStatus";
            this.cmbStudentStatus.Size = new System.Drawing.Size(156, 24);
            this.cmbStudentStatus.TabIndex = 5;
            this.cmbStudentStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbStudentStatus_KeyPress);
            this.cmbStudentStatus.Leave += new System.EventHandler(this.cmbStudentStatus_Leave);
            // 
            // ChkIdDueGreater
            // 
            this.ChkIdDueGreater.AutoSize = true;
            this.ChkIdDueGreater.BackColor = System.Drawing.Color.Transparent;
            this.ChkIdDueGreater.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkIdDueGreater.ForeColor = System.Drawing.Color.White;
            this.ChkIdDueGreater.Location = new System.Drawing.Point(67, 484);
            this.ChkIdDueGreater.Name = "ChkIdDueGreater";
            this.ChkIdDueGreater.Size = new System.Drawing.Size(197, 23);
            this.ChkIdDueGreater.TabIndex = 59;
            this.ChkIdDueGreater.Text = "Due Greater Then (0)";
            this.ChkIdDueGreater.UseVisualStyleBackColor = false;
            // 
            // frmDueFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.ChkIdDueGreater);
            this.Controls.Add(this.cmbStudentStatus);
            this.Controls.Add(this.chkSection);
            this.Controls.Add(this.chkClassWise);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClass);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmDueFee";
            this.Size = new System.Drawing.Size(987, 556);
            this.Tag = "1054";
            this.Load += new System.EventHandler(this.frmclasswisefeedue_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmDueFee_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkClassWise;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.ComboBox cmbStudentStatus;
        private System.Windows.Forms.CheckBox ChkIdDueGreater;
        private SMS.Account.ReportDesign.CachedBankReceipt cachedBankReceipt1;
    }
}