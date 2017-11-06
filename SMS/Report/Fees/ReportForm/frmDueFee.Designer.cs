namespace SMS.Report.Fees.ReportForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbStudentStatus = new System.Windows.Forms.ComboBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.chkClassWise = new System.Windows.Forms.CheckBox();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.dgvMStudent = new System.Windows.Forms.DataGridView();
            this.ChkIdDueGreater = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dgvSStudent = new System.Windows.Forms.DataGridView();
            this.lblhstuname = new System.Windows.Forms.Label();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblStudentSch = new System.Windows.Forms.Label();
            this.lblhstusch = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStudentcfee = new System.Windows.Forms.Label();
            this.lblStudentlfee = new System.Windows.Forms.Label();
            this.btnDisplay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.label2.Location = new System.Drawing.Point(356, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 22);
            this.label2.TabIndex = 46;
            this.label2.Text = "Class Wise Fee Due";
            // 
            // cmbStudentStatus
            // 
            this.cmbStudentStatus.FormattingEnabled = true;
            this.cmbStudentStatus.Items.AddRange(new object[] {
            "All Student",
            "Studying Student",
            "New Student"});
            this.cmbStudentStatus.Location = new System.Drawing.Point(185, 38);
            this.cmbStudentStatus.Name = "cmbStudentStatus";
            this.cmbStudentStatus.Size = new System.Drawing.Size(156, 21);
            this.cmbStudentStatus.TabIndex = 53;
            this.cmbStudentStatus.Leave += new System.EventHandler(this.cmbStudentStatus_Leave);
            this.cmbStudentStatus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbStudentStatus_KeyPress);
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.BackColor = System.Drawing.Color.Transparent;
            this.chkSection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSection.ForeColor = System.Drawing.Color.White;
            this.chkSection.Location = new System.Drawing.Point(566, 38);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(75, 20);
            this.chkSection.TabIndex = 51;
            this.chkSection.Text = "Section";
            this.chkSection.UseVisualStyleBackColor = false;
            this.chkSection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkSection_KeyPress);
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            // 
            // chkClassWise
            // 
            this.chkClassWise.AutoSize = true;
            this.chkClassWise.BackColor = System.Drawing.Color.Transparent;
            this.chkClassWise.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClassWise.ForeColor = System.Drawing.Color.White;
            this.chkClassWise.Location = new System.Drawing.Point(349, 38);
            this.chkClassWise.Name = "chkClassWise";
            this.chkClassWise.Size = new System.Drawing.Size(95, 20);
            this.chkClassWise.TabIndex = 49;
            this.chkClassWise.Text = "Class Wise";
            this.chkClassWise.UseVisualStyleBackColor = false;
            this.chkClassWise.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkClassWise_KeyPress);
            this.chkClassWise.CheckedChanged += new System.EventHandler(this.chkClassWise_CheckedChanged);
            // 
            // cmbSection
            // 
            this.cmbSection.Enabled = false;
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.ForeColor = System.Drawing.Color.Blue;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(644, 36);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(106, 24);
            this.cmbSection.TabIndex = 52;
            this.cmbSection.Leave += new System.EventHandler(this.cmbSection_Leave);
            this.cmbSection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSection_KeyPress);
            // 
            // cmbSession
            // 
            this.cmbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.Blue;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(89, 36);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(88, 24);
            this.cmbSession.TabIndex = 48;
            this.cmbSession.Leave += new System.EventHandler(this.cmbSession_Leave);
            this.cmbSession.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSession_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(20, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Session ";
            // 
            // cmbClass
            // 
            this.cmbClass.Enabled = false;
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ForeColor = System.Drawing.Color.Blue;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(452, 36);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(106, 24);
            this.cmbClass.TabIndex = 50;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            this.cmbClass.Leave += new System.EventHandler(this.cmbClass_Leave);
            this.cmbClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbClass_KeyPress);
            // 
            // dgvMStudent
            // 
            this.dgvMStudent.AllowUserToAddRows = false;
            this.dgvMStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMStudent.Location = new System.Drawing.Point(17, 70);
            this.dgvMStudent.Name = "dgvMStudent";
            this.dgvMStudent.ReadOnly = true;
            this.dgvMStudent.Size = new System.Drawing.Size(868, 341);
            this.dgvMStudent.TabIndex = 59;
            this.dgvMStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMStudent_CellClick);
            this.dgvMStudent.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMStudent_DataBindingComplete);
            // 
            // ChkIdDueGreater
            // 
            this.ChkIdDueGreater.AutoSize = true;
            this.ChkIdDueGreater.BackColor = System.Drawing.Color.Transparent;
            this.ChkIdDueGreater.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkIdDueGreater.ForeColor = System.Drawing.Color.White;
            this.ChkIdDueGreater.Location = new System.Drawing.Point(485, 417);
            this.ChkIdDueGreater.Name = "ChkIdDueGreater";
            this.ChkIdDueGreater.Size = new System.Drawing.Size(159, 20);
            this.ChkIdDueGreater.TabIndex = 62;
            this.ChkIdDueGreater.Text = "Due Greater Then (0)";
            this.ChkIdDueGreater.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.Control;
            this.btnExit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(769, 412);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(119, 32);
            this.btnExit.TabIndex = 61;
            this.btnExit.Text = "Cl&ose";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(650, 411);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(119, 32);
            this.btnPrint.TabIndex = 60;
            this.btnPrint.Text = "O&K";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(758, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Date";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(796, 38);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(89, 20);
            this.dtpDate.TabIndex = 64;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // dgvSStudent
            // 
            this.dgvSStudent.AllowUserToAddRows = false;
            this.dgvSStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSStudent.Location = new System.Drawing.Point(17, 102);
            this.dgvSStudent.Name = "dgvSStudent";
            this.dgvSStudent.ReadOnly = true;
            this.dgvSStudent.Size = new System.Drawing.Size(868, 307);
            this.dgvSStudent.TabIndex = 65;
            this.dgvSStudent.Visible = false;
            // 
            // lblhstuname
            // 
            this.lblhstuname.AutoSize = true;
            this.lblhstuname.BackColor = System.Drawing.Color.Transparent;
            this.lblhstuname.Location = new System.Drawing.Point(24, 77);
            this.lblhstuname.Name = "lblhstuname";
            this.lblhstuname.Size = new System.Drawing.Size(35, 13);
            this.lblhstuname.TabIndex = 66;
            this.lblhstuname.Text = "Name";
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentName.Location = new System.Drawing.Point(93, 77);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(75, 13);
            this.lblStudentName.TabIndex = 67;
            this.lblStudentName.Text = "Student Name";
            // 
            // lblStudentSch
            // 
            this.lblStudentSch.AutoSize = true;
            this.lblStudentSch.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentSch.Location = new System.Drawing.Point(345, 77);
            this.lblStudentSch.Name = "lblStudentSch";
            this.lblStudentSch.Size = new System.Drawing.Size(103, 13);
            this.lblStudentSch.TabIndex = 69;
            this.lblStudentSch.Text = "Student Scholar No.";
            // 
            // lblhstusch
            // 
            this.lblhstusch.AutoSize = true;
            this.lblhstusch.BackColor = System.Drawing.Color.Transparent;
            this.lblhstusch.Location = new System.Drawing.Point(274, 77);
            this.lblhstusch.Name = "lblhstusch";
            this.lblhstusch.Size = new System.Drawing.Size(63, 13);
            this.lblhstusch.TabIndex = 68;
            this.lblhstusch.Text = "Scholar No.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(465, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Late Fee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(636, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 71;
            this.label5.Text = "Consession Fee";
            // 
            // lblStudentcfee
            // 
            this.lblStudentcfee.AutoSize = true;
            this.lblStudentcfee.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentcfee.Location = new System.Drawing.Point(724, 77);
            this.lblStudentcfee.Name = "lblStudentcfee";
            this.lblStudentcfee.Size = new System.Drawing.Size(122, 13);
            this.lblStudentcfee.TabIndex = 72;
            this.lblStudentcfee.Text = "Student Consession Fee";
            // 
            // lblStudentlfee
            // 
            this.lblStudentlfee.AutoSize = true;
            this.lblStudentlfee.BackColor = System.Drawing.Color.Transparent;
            this.lblStudentlfee.Location = new System.Drawing.Point(531, 77);
            this.lblStudentlfee.Name = "lblStudentlfee";
            this.lblStudentlfee.Size = new System.Drawing.Size(89, 13);
            this.lblStudentlfee.TabIndex = 73;
            this.lblStudentlfee.Text = "Student Late Fee";
            // 
            // btnDisplay
            // 
            this.btnDisplay.Location = new System.Drawing.Point(826, 70);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(59, 26);
            this.btnDisplay.TabIndex = 74;
            this.btnDisplay.Text = "Display";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // frmDueFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 461);
            //this.ControlBox = false;
            this.Controls.Add(this.dgvSStudent);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChkIdDueGreater);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvMStudent);
            this.Controls.Add(this.cmbStudentStatus);
            this.Controls.Add(this.chkSection);
            this.Controls.Add(this.chkClassWise);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblStudentSch);
            this.Controls.Add(this.lblhstusch);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.lblhstuname);
            this.Controls.Add(this.lblStudentlfee);
            this.Controls.Add(this.lblStudentcfee);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDisplay);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDueFee";
            this.Load += new System.EventHandler(this.frmDueFee_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmDueFee_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMStudent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSStudent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbStudentStatus;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.CheckBox chkClassWise;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.DataGridView dgvMStudent;
        private System.Windows.Forms.CheckBox ChkIdDueGreater;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DataGridView dgvSStudent;
        private System.Windows.Forms.Label lblhstuname;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblStudentSch;
        private System.Windows.Forms.Label lblhstusch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStudentcfee;
        private System.Windows.Forms.Label lblStudentlfee;
        private System.Windows.Forms.Button btnDisplay;
    }
}