namespace SMS.MpBoardMarksheet
{
    partial class FrmMPCCMarksheetS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtg = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label210 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblStatus = new System.Windows.Forms.Label();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbExam = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.tbAcadminSkills = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dtgSkills = new System.Windows.Forms.DataGridView();
            this.btnSaveDesInd = new System.Windows.Forms.Button();
            this.btnViewDesInd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tbAcadminSkills.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSkills)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg
            // 
            this.dtg.AllowDrop = true;
            this.dtg.AllowUserToAddRows = false;
            this.dtg.ColumnHeadersHeight = 20;
            this.dtg.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtg.Location = new System.Drawing.Point(4, 4);
            this.dtg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtg.Name = "dtg";
            this.dtg.Size = new System.Drawing.Size(1371, 544);
            this.dtg.TabIndex = 0;
            this.dtg.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_CellEndEdit);
            this.dtg.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_DataBindingComplete);
            this.dtg.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtg_DataError);
            this.dtg.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtg_RowPostPaint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1104, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "TERM I+TERM II";
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.BackColor = System.Drawing.Color.Transparent;
            this.label210.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label210.ForeColor = System.Drawing.Color.DarkRed;
            this.label210.Location = new System.Drawing.Point(9, 570);
            this.label210.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(386, 17);
            this.label210.TabIndex = 140;
            this.label210.Text = "Note : TERM Marks Enter  Between 0 To 100 Marks.";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtg);
            this.tabPage1.Controls.Add(this.label210);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1379, 611);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Academic Performance";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage1_Paint);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStatus.Location = new System.Drawing.Point(1078, 47);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(155, 24);
            this.lblStatus.TabIndex = 178;
            this.lblStatus.Text = "                             ";
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.BackColor = System.Drawing.Color.Transparent;
            this.chkLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLock.ForeColor = System.Drawing.Color.Transparent;
            this.chkLock.Location = new System.Drawing.Point(966, 45);
            this.chkLock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(76, 29);
            this.chkLock.TabIndex = 174;
            this.chkLock.Text = "Lock";
            this.chkLock.UseVisualStyleBackColor = false;
            this.chkLock.CheckedChanged += new System.EventHandler(this.chkLock_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(536, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 177;
            this.label3.Text = "Select Exam";
            // 
            // cmbExam
            // 
            this.cmbExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExam.FormattingEnabled = true;
            this.cmbExam.Items.AddRange(new object[] {
            "TERM I",
            "TERM II",
            "TERM III"});
            this.cmbExam.Location = new System.Drawing.Point(661, 46);
            this.cmbExam.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbExam.Name = "cmbExam";
            this.cmbExam.Size = new System.Drawing.Size(129, 26);
            this.cmbExam.TabIndex = 171;
            // 
            // btnShow
            // 
            this.btnShow.Enabled = false;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(808, 44);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(92, 30);
            this.btnShow.TabIndex = 173;
            this.btnShow.Text = "S&how";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // tbAcadminSkills
            // 
            this.tbAcadminSkills.Controls.Add(this.tabPage1);
            this.tbAcadminSkills.Controls.Add(this.tabPage2);
            this.tbAcadminSkills.Location = new System.Drawing.Point(19, 78);
            this.tbAcadminSkills.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbAcadminSkills.Name = "tbAcadminSkills";
            this.tbAcadminSkills.SelectedIndex = 0;
            this.tbAcadminSkills.Size = new System.Drawing.Size(1387, 640);
            this.tbAcadminSkills.TabIndex = 176;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dtgSkills);
            this.tabPage2.Controls.Add(this.btnSaveDesInd);
            this.tabPage2.Controls.Add(this.btnViewDesInd);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(1379, 611);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Descriptive Indicators";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage2_Paint);
            // 
            // dtgSkills
            // 
            this.dtgSkills.AllowUserToAddRows = false;
            this.dtgSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSkills.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSkills.Location = new System.Drawing.Point(7, 0);
            this.dtgSkills.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgSkills.Name = "dtgSkills";
            this.dtgSkills.RowHeadersWidth = 4;
            this.dtgSkills.RowTemplate.Height = 25;
            this.dtgSkills.Size = new System.Drawing.Size(1365, 558);
            this.dtgSkills.TabIndex = 155;
            this.dtgSkills.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSkills_CellEndEdit);
            this.dtgSkills.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgSkills_DataBindingComplete);
            this.dtgSkills.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgSkills_DataError);
            // 
            // btnSaveDesInd
            // 
            this.btnSaveDesInd.Enabled = false;
            this.btnSaveDesInd.Location = new System.Drawing.Point(1115, 566);
            this.btnSaveDesInd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveDesInd.Name = "btnSaveDesInd";
            this.btnSaveDesInd.Size = new System.Drawing.Size(257, 36);
            this.btnSaveDesInd.TabIndex = 154;
            this.btnSaveDesInd.Text = "&Save Descriptive Indicators";
            this.btnSaveDesInd.UseVisualStyleBackColor = true;
            this.btnSaveDesInd.Click += new System.EventHandler(this.btnSaveDesInd_Click);
            // 
            // btnViewDesInd
            // 
            this.btnViewDesInd.Location = new System.Drawing.Point(847, 566);
            this.btnViewDesInd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewDesInd.Name = "btnViewDesInd";
            this.btnViewDesInd.Size = new System.Drawing.Size(257, 36);
            this.btnViewDesInd.TabIndex = 153;
            this.btnViewDesInd.Text = "&View Descriptive Indicators";
            this.btnViewDesInd.UseVisualStyleBackColor = true;
            this.btnViewDesInd.Click += new System.EventHandler(this.btnViewDesInd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(276, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 172;
            this.label2.Text = "Section";
            // 
            // cmbSection
            // 
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(360, 46);
            this.cmbSection.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(129, 26);
            this.cmbSection.TabIndex = 170;
            // 
            // cmbClass
            // 
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(87, 46);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(137, 26);
            this.cmbClass.TabIndex = 169;
            // 
            // tmr1
            // 
            this.tmr1.Interval = 1000;
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(19, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 168;
            this.label1.Text = "Class ";
            // 
            // FrmMPCCMarksheetS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMPCCMarksheetS";
            this.Size = new System.Drawing.Size(1444, 738);
            this.Load += new System.EventHandler(this.FrmMPCCMarksheetS_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMPCCMarksheetS_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tbAcadminSkills.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSkills)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label210;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbExam;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.TabControl tbAcadminSkills;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSaveDesInd;
        private System.Windows.Forms.Button btnViewDesInd;
        private System.Windows.Forms.DataGridView dtgSkills;
    }
}