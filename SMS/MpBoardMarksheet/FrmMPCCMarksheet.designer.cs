namespace SMS.MpBoardMarksheet
{
    partial class FrmMPCCMarksheet
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
            this.components = new System.ComponentModel.Container();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cmbExam = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnFinalSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtg = new System.Windows.Forms.DataGridView();
            this.label210 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAcadminSkills = new System.Windows.Forms.TabControl();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.tbAcadminSkills.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStatus.Location = new System.Drawing.Point(767, 38);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 19);
            this.lblStatus.TabIndex = 160;
            this.lblStatus.Text = "                             ";
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.BackColor = System.Drawing.Color.Transparent;
            this.chkLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLock.ForeColor = System.Drawing.Color.Transparent;
            this.chkLock.Location = new System.Drawing.Point(690, 33);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(69, 28);
            this.chkLock.TabIndex = 156;
            this.chkLock.Text = "Lock";
            this.chkLock.UseVisualStyleBackColor = false;
            this.chkLock.CheckedChanged += new System.EventHandler(this.chkLock_CheckedChanged);
            // 
            // tmr1
            // 
            this.tmr1.Interval = 1000;
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(398, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 159;
            this.label3.Text = "Select Exam.";
            // 
            // cmbExam
            // 
            this.cmbExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExam.FormattingEnabled = true;
            this.cmbExam.Items.AddRange(new object[] {
            "TERM I",
            "TERM II",
            "TERM III"});
            this.cmbExam.Location = new System.Drawing.Point(504, 34);
            this.cmbExam.Name = "cmbExam";
            this.cmbExam.Size = new System.Drawing.Size(75, 23);
            this.cmbExam.TabIndex = 153;
            // 
            // btnShow
            // 
            this.btnShow.Enabled = false;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(596, 29);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(69, 32);
            this.btnShow.TabIndex = 155;
            this.btnShow.Text = "S&how";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(215, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 154;
            this.label2.Text = "Section";
            // 
            // cmbSection
            // 
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(288, 34);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(98, 23);
            this.cmbSection.TabIndex = 152;
            // 
            // cmbClass
            // 
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(98, 34);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(104, 23);
            this.cmbClass.TabIndex = 151;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(22, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 150;
            this.label1.Text = "Class ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(999, 29);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 32);
            this.btnClose.TabIndex = 157;
            this.btnClose.Text = "C&lose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCancel);
            this.tabPage1.Controls.Add(this.btnNew);
            this.tabPage1.Controls.Add(this.btnEdit);
            this.tabPage1.Controls.Add(this.btnFinalSave);
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.dtg);
            this.tabPage1.Controls.Add(this.label210);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1042, 487);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Academic Performance";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage1_Paint);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(767, 452);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(131, 34);
            this.btnCancel.TabIndex = 148;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(374, 452);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(131, 34);
            this.btnNew.TabIndex = 147;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(505, 452);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(131, 34);
            this.btnEdit.TabIndex = 146;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnFinalSave
            // 
            this.btnFinalSave.Enabled = false;
            this.btnFinalSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalSave.Location = new System.Drawing.Point(636, 452);
            this.btnFinalSave.Name = "btnFinalSave";
            this.btnFinalSave.Size = new System.Drawing.Size(131, 34);
            this.btnFinalSave.TabIndex = 144;
            this.btnFinalSave.Text = "&Save";
            this.btnFinalSave.UseVisualStyleBackColor = true;
            this.btnFinalSave.Click += new System.EventHandler(this.btnFinalSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(898, 452);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(131, 34);
            this.btnExit.TabIndex = 145;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtg
            // 
            this.dtg.AllowDrop = true;
            this.dtg.AllowUserToAddRows = false;
            this.dtg.ColumnHeadersHeight = 20;
            this.dtg.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtg.Location = new System.Drawing.Point(3, 3);
            this.dtg.Name = "dtg";
            this.dtg.Size = new System.Drawing.Size(1036, 442);
            this.dtg.TabIndex = 0;
            this.dtg.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtg_RowPostPaint);
            this.dtg.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_CellEndEdit);
            this.dtg.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtg_DataError);
            this.dtg.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_DataBindingComplete);
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.BackColor = System.Drawing.Color.Transparent;
            this.label210.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label210.ForeColor = System.Drawing.Color.DarkRed;
            this.label210.Location = new System.Drawing.Point(7, 463);
            this.label210.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(307, 13);
            this.label210.TabIndex = 140;
            this.label210.Text = "Note : TERM Marks Enter  Between 0 To 100 Marks.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(828, 16);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "TERM I+TERM II";
            // 
            // tbAcadminSkills
            // 
            this.tbAcadminSkills.Controls.Add(this.tabPage1);
            this.tbAcadminSkills.Location = new System.Drawing.Point(12, 67);
            this.tbAcadminSkills.Name = "tbAcadminSkills";
            this.tbAcadminSkills.SelectedIndex = 0;
            this.tbAcadminSkills.Size = new System.Drawing.Size(1050, 513);
            this.tbAcadminSkills.TabIndex = 158;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(457, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 22);
            this.label4.TabIndex = 167;
            this.label4.Text = "CCE Marks Detail";
            // 
            // FrmMPCCMarksheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1085, 602);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.chkLock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbExam);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.tbAcadminSkills);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMPCCMarksheet";
            this.Text = "FrmMPCCMarksheet";
            this.Load += new System.EventHandler(this.FrmMPCCMarksheet_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMPCCMarksheet_Paint);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.tbAcadminSkills.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbExam;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnFinalSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dtg;
        private System.Windows.Forms.Label label210;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tbAcadminSkills;
        private System.Windows.Forms.Label label4;

    }
}