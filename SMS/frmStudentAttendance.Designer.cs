namespace SMS
{
    partial class frmStudentAttendance
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
            this.lblAttandanceDate = new System.Windows.Forms.Label();
            this.txtAttandanceDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnShow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.studentno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scholarno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAttandanceDate
            // 
            this.lblAttandanceDate.AutoSize = true;
            this.lblAttandanceDate.BackColor = System.Drawing.Color.Transparent;
            this.lblAttandanceDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblAttandanceDate.ForeColor = System.Drawing.Color.White;
            this.lblAttandanceDate.Location = new System.Drawing.Point(66, 67);
            this.lblAttandanceDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAttandanceDate.Name = "lblAttandanceDate";
            this.lblAttandanceDate.Size = new System.Drawing.Size(149, 20);
            this.lblAttandanceDate.TabIndex = 145;
            this.lblAttandanceDate.Text = "Attendance Date";
            // 
            // txtAttandanceDate
            // 
            this.txtAttandanceDate.CustomFormat = "dd-MM-yyyy";
            this.txtAttandanceDate.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAttandanceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtAttandanceDate.Location = new System.Drawing.Point(223, 67);
            this.txtAttandanceDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtAttandanceDate.Name = "txtAttandanceDate";
            this.txtAttandanceDate.Size = new System.Drawing.Size(156, 26);
            this.txtAttandanceDate.TabIndex = 146;
            // 
            // cmbSection
            // 
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(775, 65);
            this.cmbSection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(129, 26);
            this.cmbSection.TabIndex = 149;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(695, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 150;
            this.label2.Text = "Section";
            // 
            // cmbClass
            // 
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(498, 67);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(137, 26);
            this.cmbClass.TabIndex = 147;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(427, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 148;
            this.label1.Text = "Class ";
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(960, 63);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(131, 28);
            this.btnShow.TabIndex = 151;
            this.btnShow.Text = "S&how";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.studentno,
            this.scholarno,
            this.EmpName,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(70, 108);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1021, 319);
            this.dataGridView1.TabIndex = 152;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // studentno
            // 
            this.studentno.DataPropertyName = "studentno";
            this.studentno.HeaderText = "studentno";
            this.studentno.Name = "studentno";
            this.studentno.Visible = false;
            // 
            // scholarno
            // 
            this.scholarno.DataPropertyName = "scholarno";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.scholarno.DefaultCellStyle = dataGridViewCellStyle1;
            this.scholarno.HeaderText = "Scholar No";
            this.scholarno.Name = "scholarno";
            this.scholarno.ReadOnly = true;
            this.scholarno.Width = 140;
            // 
            // EmpName
            // 
            this.EmpName.HeaderText = "Name";
            this.EmpName.Name = "EmpName";
            this.EmpName.ReadOnly = true;
            this.EmpName.Width = 200;
            // 
            // Status
            // 
            this.Status.HeaderText = "Absent/Present";
            this.Status.Name = "Status";
            // 
            // frmStudentAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAttandanceDate);
            this.Controls.Add(this.txtAttandanceDate);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStudentAttendance";
            this.Size = new System.Drawing.Size(1108, 512);
            this.Load += new System.EventHandler(this.frmStudentAttendance_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmStudentAttendance_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAttandanceDate;
        private System.Windows.Forms.DateTimePicker txtAttandanceDate;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentno;
        private System.Windows.Forms.DataGridViewTextBoxColumn scholarno;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmpName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
    }
}