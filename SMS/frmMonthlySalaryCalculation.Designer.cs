namespace SMS
{
    partial class frmMonthlySalaryCalculation
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
            this.gbxSalaryCalculation = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Present = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Absent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidLeave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeekOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaySalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DAAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HRA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialIncentiveAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LICAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoanAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESICAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalaryStatement = new System.Windows.Forms.Button();
            this.btnreportforbank = new System.Windows.Forms.Button();
            this.btnAttendanceBetweenReport = new System.Windows.Forms.Button();
            this.gbxSalaryCalculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSalaryCalculation
            // 
            this.gbxSalaryCalculation.BackColor = System.Drawing.Color.Transparent;
            this.gbxSalaryCalculation.Controls.Add(this.dataGridView1);
            this.gbxSalaryCalculation.Controls.Add(this.cmbYear);
            this.gbxSalaryCalculation.Controls.Add(this.label6);
            this.gbxSalaryCalculation.Controls.Add(this.cmbMonth);
            this.gbxSalaryCalculation.Controls.Add(this.label1);
            this.gbxSalaryCalculation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbxSalaryCalculation.Location = new System.Drawing.Point(98, 97);
            this.gbxSalaryCalculation.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.gbxSalaryCalculation.Name = "gbxSalaryCalculation";
            this.gbxSalaryCalculation.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.gbxSalaryCalculation.Size = new System.Drawing.Size(2688, 1159);
            this.gbxSalaryCalculation.TabIndex = 162;
            this.gbxSalaryCalculation.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID,
            this.StudentName,
            this.FatherName,
            this.Designation,
            this.Present,
            this.Absent,
            this.PaidLeave,
            this.WeekOff,
            this.BasicSalary,
            this.DaySalary,
            this.DAAmount,
            this.HRA,
            this.SpecialIncentiveAmount,
            this.PFNo,
            this.PFAmount,
            this.LICAmount,
            this.LoanAmount,
            this.ESICAmount,
            this.NetSalary});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(8, 109);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(2672, 1042);
            this.dataGridView1.TabIndex = 161;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // EmployeeID
            // 
            this.EmployeeID.HeaderText = "Employee ID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            // 
            // Name
            // 
            this.StudentName.HeaderText = "Name";
            this.StudentName.Name = "Name";
            this.StudentName.ReadOnly = true;
            // 
            // FatherName
            // 
            this.FatherName.HeaderText = "Father\'s Name";
            this.FatherName.Name = "FatherName";
            this.FatherName.ReadOnly = true;
            // 
            // Designation
            // 
            this.Designation.HeaderText = "Dasignation";
            this.Designation.Name = "Designation";
            this.Designation.ReadOnly = true;
            // 
            // Present
            // 
            this.Present.HeaderText = "Present";
            this.Present.Name = "Present";
            this.Present.ReadOnly = true;
            // 
            // Absent
            // 
            this.Absent.HeaderText = "Absent";
            this.Absent.Name = "Absent";
            this.Absent.ReadOnly = true;
            // 
            // PaidLeave
            // 
            this.PaidLeave.HeaderText = "Paid-Leave";
            this.PaidLeave.Name = "PaidLeave";
            this.PaidLeave.ReadOnly = true;
            // 
            // WeekOff
            // 
            this.WeekOff.HeaderText = "Week-Off";
            this.WeekOff.Name = "WeekOff";
            this.WeekOff.ReadOnly = true;
            // 
            // BasicSalary
            // 
            this.BasicSalary.HeaderText = "Basic Salary Rate";
            this.BasicSalary.Name = "BasicSalary";
            // 
            // DaySalary
            // 
            this.DaySalary.HeaderText = "One Day Salary";
            this.DaySalary.Name = "DaySalary";
            // 
            // DAAmount
            // 
            this.DAAmount.HeaderText = "D.A. Amt.";
            this.DAAmount.Name = "DAAmount";
            // 
            // HRA
            // 
            this.HRA.HeaderText = "H.R.A. Amt.";
            this.HRA.Name = "HRA";
            // 
            // SpecialIncentiveAmount
            // 
            this.SpecialIncentiveAmount.HeaderText = "Special Insentive";
            this.SpecialIncentiveAmount.Name = "SpecialIncentiveAmount";
            this.SpecialIncentiveAmount.ReadOnly = true;
            // 
            // PFNo
            // 
            this.PFNo.HeaderText = "P.F. No.";
            this.PFNo.Name = "PFNo";
            // 
            // PFAmount
            // 
            this.PFAmount.HeaderText = "P.F. Amt.";
            this.PFAmount.Name = "PFAmount";
            this.PFAmount.ReadOnly = true;
            // 
            // LICAmount
            // 
            this.LICAmount.HeaderText = "L.I.C. Amt.";
            this.LICAmount.Name = "LICAmount";
            this.LICAmount.ReadOnly = true;
            // 
            // LoanAmount
            // 
            this.LoanAmount.HeaderText = "Loan Amt.";
            this.LoanAmount.Name = "LoanAmount";
            this.LoanAmount.ReadOnly = true;
            // 
            // ESICAmount
            // 
            this.ESICAmount.HeaderText = "E.S.I.C. Amt.";
            this.ESICAmount.Name = "ESICAmount";
            this.ESICAmount.ReadOnly = true;
            // 
            // NetSalary
            // 
            this.NetSalary.HeaderText = "Net Salary";
            this.NetSalary.Name = "NetSalary";
            this.NetSalary.ReadOnly = true;
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(218, 46);
            this.cmbYear.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(236, 39);
            this.cmbYear.TabIndex = 160;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(582, 50);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 32);
            this.label6.TabIndex = 147;
            this.label6.Text = "Month";
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(702, 46);
            this.cmbMonth.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(418, 39);
            this.cmbMonth.TabIndex = 159;
            this.cmbMonth.Validated += new System.EventHandler(this.cmbMonth_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 32);
            this.label1.TabIndex = 148;
            this.label1.Text = "Select Year";
            // 
            // btnSalaryStatement
            // 
            this.btnSalaryStatement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSalaryStatement.Location = new System.Drawing.Point(1409, 1271);
            this.btnSalaryStatement.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnSalaryStatement.Name = "btnSalaryStatement";
            this.btnSalaryStatement.Size = new System.Drawing.Size(360, 74);
            this.btnSalaryStatement.TabIndex = 166;
            this.btnSalaryStatement.Text = "Salary Statement";
            this.btnSalaryStatement.UseVisualStyleBackColor = true;
            this.btnSalaryStatement.Click += new System.EventHandler(this.btnSalaryStatement_Click);
            // 
            // btnreportforbank
            // 
            this.btnreportforbank.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreportforbank.Location = new System.Drawing.Point(2283, 1271);
            this.btnreportforbank.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnreportforbank.Name = "btnreportforbank";
            this.btnreportforbank.Size = new System.Drawing.Size(498, 74);
            this.btnreportforbank.TabIndex = 165;
            this.btnreportforbank.Text = "Salary Statement For Other";
            this.btnreportforbank.UseVisualStyleBackColor = true;
            this.btnreportforbank.Click += new System.EventHandler(this.btnreportforbank_Click);
            // 
            // btnAttendanceBetweenReport
            // 
            this.btnAttendanceBetweenReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendanceBetweenReport.Location = new System.Drawing.Point(1785, 1271);
            this.btnAttendanceBetweenReport.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnAttendanceBetweenReport.Name = "btnAttendanceBetweenReport";
            this.btnAttendanceBetweenReport.Size = new System.Drawing.Size(482, 74);
            this.btnAttendanceBetweenReport.TabIndex = 163;
            this.btnAttendanceBetweenReport.Text = "Salary Statement For Bank";
            this.btnAttendanceBetweenReport.UseVisualStyleBackColor = true;
            this.btnAttendanceBetweenReport.Click += new System.EventHandler(this.btnAttendanceBetweenReport_Click);
            // 
            // frmMonthlySalaryCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnSalaryStatement);
            this.Controls.Add(this.btnreportforbank);
            this.Controls.Add(this.btnAttendanceBetweenReport);
            this.Controls.Add(this.gbxSalaryCalculation);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Name = "frmMonthlySalaryCalculation";
            this.Size = new System.Drawing.Size(2869, 1376);
            this.Load += new System.EventHandler(this.frmSalaryCalculation_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMonthlySalaryCalculation_Paint);
            this.gbxSalaryCalculation.ResumeLayout(false);
            this.gbxSalaryCalculation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSalaryCalculation;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalaryStatement;
        private System.Windows.Forms.Button btnreportforbank;
        private System.Windows.Forms.Button btnAttendanceBetweenReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Present;
        private System.Windows.Forms.DataGridViewTextBoxColumn Absent;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidLeave;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeekOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaySalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn DAAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn HRA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialIncentiveAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LICAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoanAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESICAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetSalary;
    }
}