namespace SMS.MpBoardMarksheet
{
    partial class FrmMPCCMarksheetMS
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
            this.cmbExam = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkLock = new System.Windows.Forms.CheckBox();
            this.tmr1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnSaveDesInd = new System.Windows.Forms.Button();
            this.btnViewDesInd = new System.Windows.Forms.Button();
            this.dtgSkills = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtg = new System.Windows.Forms.DataGridView();
            this.label212 = new System.Windows.Forms.Label();
            this.label211 = new System.Windows.Forms.Label();
            this.label210 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbAcadminSkills = new System.Windows.Forms.TabControl();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSkills)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.tbAcadminSkills.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbExam
            // 
            this.cmbExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExam.FormattingEnabled = true;
            this.cmbExam.Items.AddRange(new object[] {
            "FA1",
            "FA2",
            "FA3",
            "FA4",
            "SA1",
            "SA2",
            "SA3"});
            this.cmbExam.Location = new System.Drawing.Point(675, 4);
            this.cmbExam.Margin = new System.Windows.Forms.Padding(4);
            this.cmbExam.Name = "cmbExam";
            this.cmbExam.Size = new System.Drawing.Size(129, 26);
            this.cmbExam.TabIndex = 182;
            this.cmbExam.Visible = false;
            // 
            // btnShow
            // 
            this.btnShow.Enabled = false;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(540, 42);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(92, 30);
            this.btnShow.TabIndex = 184;
            this.btnShow.Text = "S&how";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(551, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 188;
            this.label3.Text = "Select Exam";
            this.label3.Visible = false;
            // 
            // cmbSection
            // 
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(362, 44);
            this.cmbSection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(129, 26);
            this.cmbSection.TabIndex = 181;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(279, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 183;
            this.label2.Text = "Section";
            // 
            // cmbClass
            // 
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(88, 44);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(137, 26);
            this.cmbClass.TabIndex = 179;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblStatus.Location = new System.Drawing.Point(1082, 47);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(155, 24);
            this.lblStatus.TabIndex = 189;
            this.lblStatus.Text = "                             ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 180;
            this.label1.Text = "Class ";
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.BackColor = System.Drawing.Color.Transparent;
            this.chkLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLock.ForeColor = System.Drawing.Color.Transparent;
            this.chkLock.Location = new System.Drawing.Point(969, 43);
            this.chkLock.Margin = new System.Windows.Forms.Padding(4);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(76, 29);
            this.chkLock.TabIndex = 186;
            this.chkLock.Text = "Lock";
            this.chkLock.UseVisualStyleBackColor = false;
            this.chkLock.CheckedChanged += new System.EventHandler(this.chkLock_CheckedChanged);
            // 
            // tmr1
            // 
            this.tmr1.Interval = 1000;
            this.tmr1.Tick += new System.EventHandler(this.tmr1_Tick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnSaveDesInd);
            this.tabPage5.Controls.Add(this.btnViewDesInd);
            this.tabPage5.Controls.Add(this.dtgSkills);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(1379, 611);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Descriptive Indicators";
            this.tabPage5.UseVisualStyleBackColor = true;
            this.tabPage5.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage5_Paint);
            // 
            // btnSaveDesInd
            // 
            this.btnSaveDesInd.Enabled = false;
            this.btnSaveDesInd.Location = new System.Drawing.Point(1113, 571);
            this.btnSaveDesInd.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveDesInd.Name = "btnSaveDesInd";
            this.btnSaveDesInd.Size = new System.Drawing.Size(257, 36);
            this.btnSaveDesInd.TabIndex = 152;
            this.btnSaveDesInd.Text = "&Save Descriptive Indicators";
            this.btnSaveDesInd.UseVisualStyleBackColor = true;
            this.btnSaveDesInd.Click += new System.EventHandler(this.btnSaveDesInd_Click);
            // 
            // btnViewDesInd
            // 
            this.btnViewDesInd.Location = new System.Drawing.Point(856, 571);
            this.btnViewDesInd.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewDesInd.Name = "btnViewDesInd";
            this.btnViewDesInd.Size = new System.Drawing.Size(257, 36);
            this.btnViewDesInd.TabIndex = 151;
            this.btnViewDesInd.Text = "&View Descriptive Indicators";
            this.btnViewDesInd.UseVisualStyleBackColor = true;
            this.btnViewDesInd.Click += new System.EventHandler(this.btnViewDesInd_Click);
            // 
            // dtgSkills
            // 
            this.dtgSkills.AllowUserToAddRows = false;
            this.dtgSkills.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dtgSkills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgSkills.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgSkills.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgSkills.Location = new System.Drawing.Point(5, 9);
            this.dtgSkills.Margin = new System.Windows.Forms.Padding(4);
            this.dtgSkills.Name = "dtgSkills";
            this.dtgSkills.RowHeadersWidth = 4;
            this.dtgSkills.RowTemplate.Height = 25;
            this.dtgSkills.Size = new System.Drawing.Size(1365, 558);
            this.dtgSkills.TabIndex = 0;
            this.dtgSkills.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgSkills_CellEndEdit);
            this.dtgSkills.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgSkills_DataBindingComplete);
            this.dtgSkills.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgSkills_DataError);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtg);
            this.tabPage1.Controls.Add(this.label212);
            this.tabPage1.Controls.Add(this.label211);
            this.tabPage1.Controls.Add(this.label210);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1379, 611);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Academic Performance";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Paint += new System.Windows.Forms.PaintEventHandler(this.tabPage1_Paint);
            // 
            // dtg
            // 
            this.dtg.AllowDrop = true;
            this.dtg.AllowUserToAddRows = false;
            this.dtg.ColumnHeadersHeight = 20;
            this.dtg.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtg.Location = new System.Drawing.Point(4, 4);
            this.dtg.Margin = new System.Windows.Forms.Padding(4);
            this.dtg.Name = "dtg";
            this.dtg.Size = new System.Drawing.Size(1371, 544);
            this.dtg.TabIndex = 0;
            this.dtg.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_CellEndEdit);
            this.dtg.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtg_DataBindingComplete);
            this.dtg.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtg_DataError);
            this.dtg.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtg_RowPostPaint);
            // 
            // label212
            // 
            this.label212.AutoSize = true;
            this.label212.BackColor = System.Drawing.Color.Transparent;
            this.label212.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label212.ForeColor = System.Drawing.Color.DarkRed;
            this.label212.Location = new System.Drawing.Point(4, 591);
            this.label212.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label212.Name = "label212";
            this.label212.Size = new System.Drawing.Size(396, 17);
            this.label212.TabIndex = 142;
            this.label212.Text = " Final FA,SA,Over All Grades  are given by Teachers.";
            // 
            // label211
            // 
            this.label211.AutoSize = true;
            this.label211.BackColor = System.Drawing.Color.Transparent;
            this.label211.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label211.ForeColor = System.Drawing.Color.DarkRed;
            this.label211.Location = new System.Drawing.Point(55, 572);
            this.label211.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label211.Name = "label211";
            this.label211.Size = new System.Drawing.Size(314, 17);
            this.label211.TabIndex = 141;
            this.label211.Text = "SA Marks Enter Between 0 to 100  Marks. ";
            // 
            // label210
            // 
            this.label210.AutoSize = true;
            this.label210.BackColor = System.Drawing.Color.Transparent;
            this.label210.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label210.ForeColor = System.Drawing.Color.DarkRed;
            this.label210.Location = new System.Drawing.Point(8, 551);
            this.label210.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label210.Name = "label210";
            this.label210.Size = new System.Drawing.Size(353, 17);
            this.label210.TabIndex = 140;
            this.label210.Text = "Note : FA Marks Enter  Between 0 To 10 Marks.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1131, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "TERM I+TERM II";
            // 
            // tbAcadminSkills
            // 
            this.tbAcadminSkills.Controls.Add(this.tabPage1);
            this.tbAcadminSkills.Controls.Add(this.tabPage5);
            this.tbAcadminSkills.Location = new System.Drawing.Point(21, 82);
            this.tbAcadminSkills.Margin = new System.Windows.Forms.Padding(4);
            this.tbAcadminSkills.Name = "tbAcadminSkills";
            this.tbAcadminSkills.SelectedIndex = 0;
            this.tbAcadminSkills.Size = new System.Drawing.Size(1387, 640);
            this.tbAcadminSkills.TabIndex = 187;
            // 
            // FrmMPCCMarksheetMS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbExam);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbAcadminSkills);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkLock);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMPCCMarksheetMS";
            this.Size = new System.Drawing.Size(1429, 742);
            this.Tag = "FrmMPCCMarksheetMS";
            this.Load += new System.EventHandler(this.FrmMPCCMarksheetMS_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmMPCCMarksheetMS_Paint);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSkills)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.tbAcadminSkills.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbExam;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLock;
        private System.Windows.Forms.Timer tmr1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnSaveDesInd;
        private System.Windows.Forms.Button btnViewDesInd;
        private System.Windows.Forms.DataGridView dtgSkills;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dtg;
        private System.Windows.Forms.Label label212;
        private System.Windows.Forms.Label label211;
        private System.Windows.Forms.Label label210;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tbAcadminSkills;
    }
}