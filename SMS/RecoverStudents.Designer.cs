namespace SMS
{
    partial class RecoverStudents
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdvStudents = new System.Windows.Forms.DataGridView();
            this.btnRecover = new System.Windows.Forms.Button();
            this.lblNoRecords = new System.Windows.Forms.Label();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ScholarNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.studentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FatherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Section = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdmissionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdvStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // grdvStudents
            // 
            this.grdvStudents.AllowUserToAddRows = false;
            this.grdvStudents.AllowUserToDeleteRows = false;
            this.grdvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.ScholarNo,
            this.StudentNo,
            this.studentName,
            this.FatherName,
            this.Class,
            this.Section,
            this.Gender,
            this.AdmissionDate});
            this.grdvStudents.Location = new System.Drawing.Point(52, 57);
            this.grdvStudents.Name = "grdvStudents";
            this.grdvStudents.RowTemplate.Height = 24;
            this.grdvStudents.Size = new System.Drawing.Size(1268, 543);
            this.grdvStudents.TabIndex = 0;
            // 
            // btnRecover
            // 
            this.btnRecover.Location = new System.Drawing.Point(1102, 609);
            this.btnRecover.Name = "btnRecover";
            this.btnRecover.Size = new System.Drawing.Size(219, 28);
            this.btnRecover.TabIndex = 1;
            this.btnRecover.Text = "Recover Selected Records";
            this.btnRecover.UseVisualStyleBackColor = true;
            this.btnRecover.Click += new System.EventHandler(this.btnRecover_Click);
            // 
            // lblNoRecords
            // 
            this.lblNoRecords.AutoSize = true;
            this.lblNoRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoRecords.Location = new System.Drawing.Point(49, 609);
            this.lblNoRecords.Name = "lblNoRecords";
            this.lblNoRecords.Size = new System.Drawing.Size(168, 17);
            this.lblNoRecords.TabIndex = 2;
            this.lblNoRecords.Text = "No records to display.";
            // 
            // Select
            // 
            this.Select.Frozen = true;
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ScholarNo
            // 
            this.ScholarNo.DataPropertyName = "ScholarNo";
            this.ScholarNo.Frozen = true;
            this.ScholarNo.HeaderText = "Scholar No";
            this.ScholarNo.Name = "ScholarNo";
            this.ScholarNo.ReadOnly = true;
            // 
            // StudentNo
            // 
            this.StudentNo.DataPropertyName = "StudentNo";
            this.StudentNo.HeaderText = "Student No";
            this.StudentNo.Name = "StudentNo";
            this.StudentNo.ReadOnly = true;
            this.StudentNo.Visible = false;
            // 
            // studentName
            // 
            this.studentName.DataPropertyName = "Name";
            this.studentName.HeaderText = "Name";
            this.studentName.Name = "studentName";
            this.studentName.ReadOnly = true;
            // 
            // FatherName
            // 
            this.FatherName.DataPropertyName = "FatherName";
            this.FatherName.HeaderText = "Father Name";
            this.FatherName.Name = "FatherName";
            this.FatherName.ReadOnly = true;
            // 
            // Class
            // 
            this.Class.DataPropertyName = "Class";
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            this.Class.ReadOnly = true;
            // 
            // Section
            // 
            this.Section.DataPropertyName = "Section";
            this.Section.HeaderText = "Section";
            this.Section.Name = "Section";
            this.Section.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // AdmissionDate
            // 
            this.AdmissionDate.DataPropertyName = "DateOfAdmission";
            this.AdmissionDate.HeaderText = "Admission Date";
            this.AdmissionDate.Name = "AdmissionDate";
            this.AdmissionDate.ReadOnly = true;
            // 
            // RecoverStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoRecords);
            this.Controls.Add(this.btnRecover);
            this.Controls.Add(this.grdvStudents);
            this.Name = "RecoverStudents";
            this.Size = new System.Drawing.Size(1386, 661);
            this.Load += new System.EventHandler(this.RecoverStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdvStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdvStudents;
        private System.Windows.Forms.Button btnRecover;
        private System.Windows.Forms.Label lblNoRecords;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScholarNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn studentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FatherName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn Section;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdmissionDate;
    }
}
