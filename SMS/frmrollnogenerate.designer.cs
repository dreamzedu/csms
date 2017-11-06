namespace SMS
{
    partial class frmrollnogenerate
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
            this.label45 = new System.Windows.Forms.Label();
            this.valcmbclass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.valcmbexam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtrollno = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalLecture = new System.Windows.Forms.TextBox();
            this.btnStudentReport = new System.Windows.Forms.Button();
            this.datagridview1 = new System.Windows.Forms.DataGridView();
            this.studentno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scholarno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rollno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLecture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attendance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Per = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisionL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VisionR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Teeth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OHygiene = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bloodgroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.House = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CGPA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OGrade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).BeginInit();
            this.SuspendLayout();
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(72, 75);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(47, 17);
            this.label45.TabIndex = 160;
            this.label45.Text = "Class";
            // 
            // valcmbclass
            // 
            this.valcmbclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbclass.ForeColor = System.Drawing.Color.Blue;
            this.valcmbclass.FormattingEnabled = true;
            this.valcmbclass.Items.AddRange(new object[] {
            "Studing",
            "Terminate"});
            this.valcmbclass.Location = new System.Drawing.Point(125, 73);
            this.valcmbclass.Name = "valcmbclass";
            this.valcmbclass.Size = new System.Drawing.Size(86, 25);
            this.valcmbclass.TabIndex = 0;
            this.valcmbclass.Tag = "";
            this.valcmbclass.Text = "-Select-";
            this.valcmbclass.SelectedIndexChanged += new System.EventHandler(this.valcmbclass_SelectedIndexChanged);
            this.valcmbclass.Leave += new System.EventHandler(this.valcmbclass_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(712, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 19);
            this.label1.TabIndex = 161;
            this.label1.Text = "Exam";
            this.label1.Visible = false;
            // 
            // valcmbexam
            // 
            this.valcmbexam.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbexam.ForeColor = System.Drawing.Color.Blue;
            this.valcmbexam.FormattingEnabled = true;
            this.valcmbexam.Items.AddRange(new object[] {
            "External"});
            this.valcmbexam.Location = new System.Drawing.Point(770, 497);
            this.valcmbexam.Name = "valcmbexam";
            this.valcmbexam.Size = new System.Drawing.Size(89, 25);
            this.valcmbexam.TabIndex = 5;
            this.valcmbexam.Tag = "";
            this.valcmbexam.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(286, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 164;
            this.label2.Text = "Roll No Start From";
            // 
            // txtrollno
            // 
            this.txtrollno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrollno.Location = new System.Drawing.Point(434, 75);
            this.txtrollno.Name = "txtrollno";
            this.txtrollno.Size = new System.Drawing.Size(105, 25);
            this.txtrollno.TabIndex = 1;
            this.txtrollno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtrollno_KeyPress);
            this.txtrollno.Leave += new System.EventHandler(this.txtrollno_Leave);
            this.txtrollno.Validating += new System.ComponentModel.CancelEventHandler(this.Txtrollno_Validating);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.White;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReport.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.Black;
            this.btnReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReport.Location = new System.Drawing.Point(72, 487);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(204, 45);
            this.btnReport.TabIndex = 8;
            this.btnReport.Text = "&Report For Roll No.";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(631, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 168;
            this.label4.Text = "No. Of Lectures";
            // 
            // txtTotalLecture
            // 
            this.txtTotalLecture.Location = new System.Drawing.Point(760, 75);
            this.txtTotalLecture.Name = "txtTotalLecture";
            this.txtTotalLecture.Size = new System.Drawing.Size(97, 23);
            this.txtTotalLecture.TabIndex = 166;
            this.txtTotalLecture.Leave += new System.EventHandler(this.txtTotalLecture_Leave);
            // 
            // btnStudentReport
            // 
            this.btnStudentReport.BackColor = System.Drawing.Color.White;
            this.btnStudentReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnStudentReport.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentReport.ForeColor = System.Drawing.Color.Black;
            this.btnStudentReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStudentReport.Location = new System.Drawing.Point(282, 487);
            this.btnStudentReport.Name = "btnStudentReport";
            this.btnStudentReport.Size = new System.Drawing.Size(204, 45);
            this.btnStudentReport.TabIndex = 169;
            this.btnStudentReport.Text = "&Report For Attendance";
            this.btnStudentReport.UseVisualStyleBackColor = false;
            this.btnStudentReport.Click += new System.EventHandler(this.btnStudentReport_Click);
            // 
            // datagridview1
            // 
            this.datagridview1.AllowUserToAddRows = false;
            this.datagridview1.AllowUserToDeleteRows = false;
            this.datagridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentno,
            this.scholarno,
            this.rollno,
            this.Name,
            this.TotalLecture,
            this.Attendance,
            this.Per,
            this.phone,
            this.Height,
            this.Width,
            this.VisionL,
            this.VisionR,
            this.Teeth,
            this.OHygiene,
            this.bloodgroup,
            this.House,
            this.CGPA,
            this.OGrade});
            this.datagridview1.Location = new System.Drawing.Point(72, 107);
            this.datagridview1.Name = "datagridview1";
            this.datagridview1.Size = new System.Drawing.Size(785, 368);
            this.datagridview1.TabIndex = 170;
            this.datagridview1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview1_CellLeave);
            // 
            // studentno
            // 
            this.studentno.HeaderText = "Student no";
            this.studentno.Name = "studentno";
            this.studentno.Visible = false;
            this.studentno.Width = 90;
            // 
            // scholarno
            // 
            this.scholarno.HeaderText = "Scholar No";
            this.scholarno.Name = "scholarno";
            this.scholarno.ReadOnly = true;
            this.scholarno.Width = 90;
            // 
            // rollno
            // 
            this.rollno.HeaderText = "Roll No";
            this.rollno.Name = "rollno";
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 250;
            // 
            // TotalLecture
            // 
            this.TotalLecture.HeaderText = "Total Lecture";
            this.TotalLecture.Name = "TotalLecture";
            this.TotalLecture.ReadOnly = true;
            // 
            // Attendance
            // 
            this.Attendance.HeaderText = "Attendance";
            this.Attendance.Name = "Attendance";
            // 
            // Per
            // 
            this.Per.HeaderText = "Attendance(%)";
            this.Per.Name = "Per";
            this.Per.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            this.phone.HeaderText = "Mobile No";
            this.phone.Name = "phone";
            // 
            // Height
            // 
            this.Height.DataPropertyName = "Height";
            this.Height.HeaderText = "Height";
            this.Height.Name = "Height";
            // 
            // Width
            // 
            this.Width.DataPropertyName = "Width";
            this.Width.HeaderText = "Weight";
            this.Width.Name = "Width";
            // 
            // VisionL
            // 
            this.VisionL.DataPropertyName = "VisionL";
            this.VisionL.HeaderText = "Vision(L)";
            this.VisionL.Name = "VisionL";
            // 
            // VisionR
            // 
            this.VisionR.DataPropertyName = "VisionR";
            this.VisionR.HeaderText = "Vision(R)";
            this.VisionR.Name = "VisionR";
            // 
            // Teeth
            // 
            this.Teeth.DataPropertyName = "Teeth";
            this.Teeth.HeaderText = "Teeth";
            this.Teeth.Name = "Teeth";
            // 
            // OHygiene
            // 
            this.OHygiene.DataPropertyName = "OHygiene";
            this.OHygiene.HeaderText = "Oral hygiene";
            this.OHygiene.Name = "OHygiene";
            // 
            // bloodgroup
            // 
            this.bloodgroup.HeaderText = "Blood Group";
            this.bloodgroup.Items.AddRange(new object[] {
            "N/A",
            "A+",
            "B+",
            "AB+",
            "O+",
            "A-",
            "B-",
            "AB-",
            "O-"});
            this.bloodgroup.Name = "bloodgroup";
            // 
            // House
            // 
            this.House.HeaderText = "House";
            this.House.Name = "House";
            // 
            // CGPA
            // 
            this.CGPA.HeaderText = "CGPA";
            this.CGPA.Name = "CGPA";
            // 
            // OGrade
            // 
            this.OGrade.HeaderText = "Overall Grade";
            this.OGrade.Name = "OGrade";
            // 
            // frmrollnogenerate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.datagridview1);
            this.Controls.Add(this.btnStudentReport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalLecture);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.txtrollno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valcmbexam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.valcmbclass);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.Name = "frmrollnogenerate";
            this.Size = new System.Drawing.Size(910, 570);
            this.Load += new System.EventHandler(this.frmattandance_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmrollnogenerate_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox valcmbclass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox valcmbexam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtrollno;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalLecture;
        private System.Windows.Forms.Button btnStudentReport;
        private System.Windows.Forms.DataGridView datagridview1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentno;
        private System.Windows.Forms.DataGridViewTextBoxColumn scholarno;
        private System.Windows.Forms.DataGridViewTextBoxColumn rollno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLecture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Per;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Height;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisionL;
        private System.Windows.Forms.DataGridViewTextBoxColumn VisionR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Teeth;
        private System.Windows.Forms.DataGridViewTextBoxColumn OHygiene;
        private System.Windows.Forms.DataGridViewComboBoxColumn bloodgroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn House;
        private System.Windows.Forms.DataGridViewTextBoxColumn CGPA;
        private System.Windows.Forms.DataGridViewTextBoxColumn OGrade;
    }
}