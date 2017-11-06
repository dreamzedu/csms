namespace SMS
{
    partial class frmNewSalaryPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxSalaryCalculation = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Paid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BasicSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Designation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BankName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMakePayment = new System.Windows.Forms.Button();
            this.btnSalaryPaymentReport = new System.Windows.Forms.Button();
            this.gbxSalaryCalculation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSalaryCalculation
            // 
            this.gbxSalaryCalculation.BackColor = System.Drawing.Color.Transparent;
            this.gbxSalaryCalculation.Controls.Add(this.label2);
            this.gbxSalaryCalculation.Controls.Add(this.dtpPaymentDate);
            this.gbxSalaryCalculation.Controls.Add(this.dataGridView1);
            this.gbxSalaryCalculation.Controls.Add(this.cmbYear);
            this.gbxSalaryCalculation.Controls.Add(this.label6);
            this.gbxSalaryCalculation.Controls.Add(this.cmbMonth);
            this.gbxSalaryCalculation.Controls.Add(this.label1);
            this.gbxSalaryCalculation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSalaryCalculation.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbxSalaryCalculation.Location = new System.Drawing.Point(48, 51);
            this.gbxSalaryCalculation.Margin = new System.Windows.Forms.Padding(4);
            this.gbxSalaryCalculation.Name = "gbxSalaryCalculation";
            this.gbxSalaryCalculation.Padding = new System.Windows.Forms.Padding(4);
            this.gbxSalaryCalculation.Size = new System.Drawing.Size(1493, 542);
            this.gbxSalaryCalculation.TabIndex = 163;
            this.gbxSalaryCalculation.TabStop = false;
            this.gbxSalaryCalculation.Text = "Salary Payment";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(547, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 163;
            this.label2.Text = "Date";
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpPaymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentDate.Location = new System.Drawing.Point(623, 21);
            this.dtpPaymentDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(147, 24);
            this.dtpPaymentDate.TabIndex = 162;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Paid,
            this.EmployeeID,
            this.Name,
            this.FatherName,
            this.BasicSalary,
            this.Designation,
            this.NetSalary,
            this.Payment,
            this.PaymentType,
            this.ChequeNo,
            this.BankName,
            this.AccountNo});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(4, 52);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 4;
            this.dataGridView1.Size = new System.Drawing.Size(1485, 486);
            this.dataGridView1.TabIndex = 161;
            this.dataGridView1.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValidated);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            this.dataGridView1.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowValidated);
            // 
            // Paid
            // 
            this.Paid.HeaderText = "Paid";
            this.Paid.Name = "Paid";
            this.Paid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Paid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Paid.Width = 50;
            // 
            // EmployeeID
            // 
            this.EmployeeID.HeaderText = "Employee ID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            this.EmployeeID.Width = 80;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 120;
            // 
            // FatherName
            // 
            this.FatherName.HeaderText = "Father\'s Name";
            this.FatherName.Name = "FatherName";
            this.FatherName.ReadOnly = true;
            this.FatherName.Width = 120;
            // 
            // BasicSalary
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BasicSalary.DefaultCellStyle = dataGridViewCellStyle1;
            this.BasicSalary.HeaderText = "Basic Salary";
            this.BasicSalary.Name = "BasicSalary";
            // 
            // Designation
            // 
            this.Designation.HeaderText = "Designation";
            this.Designation.Name = "Designation";
            this.Designation.ReadOnly = true;
            // 
            // NetSalary
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NetSalary.DefaultCellStyle = dataGridViewCellStyle2;
            this.NetSalary.HeaderText = "Net Salary";
            this.NetSalary.Name = "NetSalary";
            this.NetSalary.ReadOnly = true;
            // 
            // Payment
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Payment.DefaultCellStyle = dataGridViewCellStyle3;
            this.Payment.HeaderText = "Payment";
            this.Payment.Name = "Payment";
            // 
            // PaymentType
            // 
            this.PaymentType.HeaderText = "Payment Mode";
            this.PaymentType.Items.AddRange(new object[] {
            "Cash",
            "Cheque"});
            this.PaymentType.Name = "PaymentType";
            // 
            // ChequeNo
            // 
            this.ChequeNo.HeaderText = "Cheque No.";
            this.ChequeNo.Name = "ChequeNo";
            this.ChequeNo.ReadOnly = true;
            // 
            // BankName
            // 
            this.BankName.DataPropertyName = "BankName";
            this.BankName.HeaderText = "Bank Name";
            this.BankName.Name = "BankName";
            // 
            // AccountNo
            // 
            this.AccountNo.HeaderText = "Account No.";
            this.AccountNo.Name = "AccountNo";
            this.AccountNo.ReadOnly = true;
            this.AccountNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(84, 20);
            this.cmbYear.Margin = new System.Windows.Forms.Padding(4);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(120, 26);
            this.cmbYear.TabIndex = 160;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(227, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 147;
            this.label6.Text = "Month";
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Location = new System.Drawing.Point(313, 20);
            this.cmbMonth.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(211, 26);
            this.cmbMonth.TabIndex = 159;
            this.cmbMonth.Validated += new System.EventHandler(this.cmbMonth_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 148;
            this.label1.Text = "Year";
            // 
            // btnMakePayment
            // 
            this.btnMakePayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnMakePayment.Location = new System.Drawing.Point(1209, 597);
            this.btnMakePayment.Margin = new System.Windows.Forms.Padding(4);
            this.btnMakePayment.Name = "btnMakePayment";
            this.btnMakePayment.Size = new System.Drawing.Size(200, 37);
            this.btnMakePayment.TabIndex = 166;
            this.btnMakePayment.Text = "Make Payment";
            this.btnMakePayment.UseVisualStyleBackColor = true;
            this.btnMakePayment.Click += new System.EventHandler(this.btnMakePayment_Click);
            // 
            // btnSalaryPaymentReport
            // 
            this.btnSalaryPaymentReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSalaryPaymentReport.Location = new System.Drawing.Point(1417, 597);
            this.btnSalaryPaymentReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalaryPaymentReport.Name = "btnSalaryPaymentReport";
            this.btnSalaryPaymentReport.Size = new System.Drawing.Size(120, 37);
            this.btnSalaryPaymentReport.TabIndex = 167;
            this.btnSalaryPaymentReport.Text = "View Report";
            this.btnSalaryPaymentReport.UseVisualStyleBackColor = true;
            this.btnSalaryPaymentReport.Click += new System.EventHandler(this.btnSalaryPaymentReport_Click);
            // 
            // frmNewSalaryPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnSalaryPaymentReport);
            this.Controls.Add(this.btnMakePayment);
            this.Controls.Add(this.gbxSalaryCalculation);
            this.Margin = new System.Windows.Forms.Padding(4);
            //this.Name = "frmNewSalaryPayment";
            this.Size = new System.Drawing.Size(1547, 649);
            this.Load += new System.EventHandler(this.frmNewSalaryPayment_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmNewSalaryPayment_Paint);
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
        private System.Windows.Forms.Button btnMakePayment;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalaryPaymentReport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BasicSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Designation;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Payment;
        private System.Windows.Forms.DataGridViewComboBoxColumn PaymentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BankName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountNo;
    }
}