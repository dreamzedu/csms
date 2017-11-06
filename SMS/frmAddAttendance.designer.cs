namespace SMS
{
    partial class frmAddAttendance
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblAttandanceDate = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmpId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attandence = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMonthAttendance = new System.Windows.Forms.Button();
            this.txtDateTo = new System.Windows.Forms.DateTimePicker();
            this.btnAttendanceBetweenReport = new System.Windows.Forms.Button();
            this.txtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAttandanceDate = new System.Windows.Forms.DateTimePicker();
            this.gbxAttendance = new System.Windows.Forms.GroupBox();
            this.btnShowAttendance = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxAttendance.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAttandanceDate
            // 
            this.lblAttandanceDate.AutoSize = true;
            this.lblAttandanceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttandanceDate.ForeColor = System.Drawing.Color.White;
            this.lblAttandanceDate.Location = new System.Drawing.Point(23, 19);
            this.lblAttandanceDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttandanceDate.Name = "lblAttandanceDate";
            this.lblAttandanceDate.Size = new System.Drawing.Size(129, 17);
            this.lblAttandanceDate.TabIndex = 0;
            this.lblAttandanceDate.Text = "Attendance Date";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmpId,
            this.EmpName,
            this.Attandence});
            this.dataGridView1.Location = new System.Drawing.Point(19, 58);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.Size = new System.Drawing.Size(609, 539);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // EmpId
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.EmpId.DefaultCellStyle = dataGridViewCellStyle2;
            this.EmpId.HeaderText = "Employee ID";
            this.EmpId.Name = "EmpId";
            this.EmpId.ReadOnly = true;
            this.EmpId.Width = 80;
            // 
            // EmpName
            // 
            this.EmpName.HeaderText = "Name";
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
            this.EmpName.Width = 200;
            // 
            // Attandence
            // 
            this.Attandence.HeaderText = "Present";
            this.Attandence.Items.AddRange(new object[] {
            "P",
            "A",
            "L",
            "W",
            "H"});
            this.Attandence.Name = "Attandence";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.Red;
            this.Label9.Location = new System.Drawing.Point(13, 80);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(105, 18);
            this.Label9.TabIndex = 6;
            this.Label9.Text = "L-Paid Leave";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.Red;
            this.Label8.Location = new System.Drawing.Point(13, 111);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(101, 18);
            this.Label8.TabIndex = 5;
            this.Label8.Text = "W-Week Off";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.Blue;
            this.Label3.Location = new System.Drawing.Point(13, 50);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(75, 18);
            this.Label3.TabIndex = 1;
            this.Label3.Text = "A-Absent";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.Color.Blue;
            this.Label2.Location = new System.Drawing.Point(13, 20);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(83, 18);
            this.Label2.TabIndex = 0;
            this.Label2.Text = "P-Present";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Label2);
            this.groupBox1.Controls.Add(this.Label9);
            this.groupBox1.Controls.Add(this.Label3);
            this.groupBox1.Controls.Add(this.Label8);
            this.groupBox1.Location = new System.Drawing.Point(636, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(165, 166);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attendance Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 140);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "H-Half Day";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMonthAttendance);
            this.groupBox2.Controls.Add(this.txtDateTo);
            this.groupBox2.Controls.Add(this.btnAttendanceBetweenReport);
            this.groupBox2.Controls.Add(this.txtDateFrom);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(636, 232);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(163, 364);
            this.groupBox2.TabIndex = 135;
            this.groupBox2.TabStop = false;
            // 
            // btnMonthAttendance
            // 
            this.btnMonthAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnMonthAttendance.Location = new System.Drawing.Point(6, 21);
            this.btnMonthAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.btnMonthAttendance.Name = "btnMonthAttendance";
            this.btnMonthAttendance.Size = new System.Drawing.Size(149, 62);
            this.btnMonthAttendance.TabIndex = 143;
            this.btnMonthAttendance.UseVisualStyleBackColor = true;
            this.btnMonthAttendance.Click += new System.EventHandler(this.btnMonthAttendance_Click);
            // 
            // txtDateTo
            // 
            this.txtDateTo.CustomFormat = "dd-MMM-yyyy";
            this.txtDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDateTo.Location = new System.Drawing.Point(6, 190);
            this.txtDateTo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDateTo.Name = "txtDateTo";
            this.txtDateTo.Size = new System.Drawing.Size(148, 26);
            this.txtDateTo.TabIndex = 144;
            // 
            // btnAttendanceBetweenReport
            // 
            this.btnAttendanceBetweenReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendanceBetweenReport.Location = new System.Drawing.Point(6, 240);
            this.btnAttendanceBetweenReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnAttendanceBetweenReport.Name = "btnAttendanceBetweenReport";
            this.btnAttendanceBetweenReport.Size = new System.Drawing.Size(149, 68);
            this.btnAttendanceBetweenReport.TabIndex = 4;
            this.btnAttendanceBetweenReport.Text = "View Attendance Between Date";
            this.btnAttendanceBetweenReport.UseVisualStyleBackColor = true;
            this.btnAttendanceBetweenReport.Click += new System.EventHandler(this.btnAttendanceBetweenReport_Click);
            // 
            // txtDateFrom
            // 
            this.txtDateFrom.CustomFormat = "dd-MMM-yyyy";
            this.txtDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDateFrom.Location = new System.Drawing.Point(6, 126);
            this.txtDateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.txtDateFrom.Name = "txtDateFrom";
            this.txtDateFrom.Size = new System.Drawing.Size(148, 26);
            this.txtDateFrom.TabIndex = 143;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(68, 170);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 17);
            this.label10.TabIndex = 140;
            this.label10.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 101);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 139;
            this.label6.Text = "From";
            // 
            // txtAttandanceDate
            // 
            this.txtAttandanceDate.CustomFormat = "dd-MMM-yyyy";
            this.txtAttandanceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAttandanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtAttandanceDate.Location = new System.Drawing.Point(160, 16);
            this.txtAttandanceDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtAttandanceDate.Name = "txtAttandanceDate";
            this.txtAttandanceDate.Size = new System.Drawing.Size(156, 26);
            this.txtAttandanceDate.TabIndex = 141;
            this.txtAttandanceDate.ValueChanged += new System.EventHandler(this.txtAttandanceDate_ValueChanged);
            this.txtAttandanceDate.Validated += new System.EventHandler(this.txtAttandanceDate_Validated);
            // 
            // gbxAttendance
            // 
            this.gbxAttendance.BackColor = System.Drawing.Color.Transparent;
            this.gbxAttendance.Controls.Add(this.btnShowAttendance);
            this.gbxAttendance.Controls.Add(this.lblAttandanceDate);
            this.gbxAttendance.Controls.Add(this.txtAttandanceDate);
            this.gbxAttendance.Controls.Add(this.groupBox1);
            this.gbxAttendance.Controls.Add(this.groupBox2);
            this.gbxAttendance.Controls.Add(this.dataGridView1);
            this.gbxAttendance.Location = new System.Drawing.Point(54, 51);
            this.gbxAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.gbxAttendance.Name = "gbxAttendance";
            this.gbxAttendance.Padding = new System.Windows.Forms.Padding(4);
            this.gbxAttendance.Size = new System.Drawing.Size(819, 619);
            this.gbxAttendance.TabIndex = 142;
            this.gbxAttendance.TabStop = false;
            // 
            // btnShowAttendance
            // 
            this.btnShowAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAttendance.Location = new System.Drawing.Point(388, 16);
            this.btnShowAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowAttendance.Name = "btnShowAttendance";
            this.btnShowAttendance.Size = new System.Drawing.Size(159, 28);
            this.btnShowAttendance.TabIndex = 142;
            this.btnShowAttendance.Text = "Show Attendance";
            this.btnShowAttendance.UseVisualStyleBackColor = true;
            this.btnShowAttendance.Click += new System.EventHandler(this.btnShowAttendance_Click);
            // 
            // frmAddAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.gbxAttendance);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmAddAttendance";
            this.Size = new System.Drawing.Size(961, 712);
            this.Load += new System.EventHandler(this.frmAddAttendance_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmAddAttendance_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxAttendance.ResumeLayout(false);
            this.gbxAttendance.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblAttandanceDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAttendanceBetweenReport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker txtAttandanceDate;
        private System.Windows.Forms.GroupBox gbxAttendance;
        private System.Windows.Forms.DateTimePicker txtDateTo;
        private System.Windows.Forms.DateTimePicker txtDateFrom;
        private System.Windows.Forms.Button btnShowAttendance;
        private System.Windows.Forms.Button btnMonthAttendance;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpId;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Attandence;
    }
}