namespace SMS.Report.Student.ReportForm
{
    partial class FrmScholarship
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
            this.Chkreligion = new System.Windows.Forms.CheckBox();
            this.Chkcategory = new System.Windows.Forms.CheckBox();
            this.chkphychallanged = new System.Windows.Forms.CheckBox();
            this.strstdcategory = new System.Windows.Forms.ComboBox();
            this.strCmbReligion = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.cmbStudentStatus = new System.Windows.Forms.ComboBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.chkClassWise = new System.Windows.Forms.CheckBox();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Chkgender = new System.Windows.Forms.CheckBox();
            this.cmbgender = new System.Windows.Forms.ComboBox();
            this.chkIsScholar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Chkreligion
            // 
            this.Chkreligion.AutoSize = true;
            this.Chkreligion.BackColor = System.Drawing.Color.Transparent;
            this.Chkreligion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkreligion.ForeColor = System.Drawing.Color.White;
            this.Chkreligion.Location = new System.Drawing.Point(399, 105);
            this.Chkreligion.Margin = new System.Windows.Forms.Padding(4);
            this.Chkreligion.Name = "Chkreligion";
            this.Chkreligion.Size = new System.Drawing.Size(94, 23);
            this.Chkreligion.TabIndex = 241;
            this.Chkreligion.Text = "Religion";
            this.Chkreligion.UseVisualStyleBackColor = false;
            this.Chkreligion.CheckedChanged += new System.EventHandler(this.Chkreligion_CheckedChanged);
            // 
            // Chkcategory
            // 
            this.Chkcategory.AutoSize = true;
            this.Chkcategory.BackColor = System.Drawing.Color.Transparent;
            this.Chkcategory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkcategory.ForeColor = System.Drawing.Color.White;
            this.Chkcategory.Location = new System.Drawing.Point(668, 104);
            this.Chkcategory.Margin = new System.Windows.Forms.Padding(4);
            this.Chkcategory.Name = "Chkcategory";
            this.Chkcategory.Size = new System.Drawing.Size(170, 23);
            this.Chkcategory.TabIndex = 240;
            this.Chkcategory.Text = "Student Category";
            this.Chkcategory.UseVisualStyleBackColor = false;
            this.Chkcategory.CheckedChanged += new System.EventHandler(this.Chkcategory_CheckedChanged);
            // 
            // chkphychallanged
            // 
            this.chkphychallanged.AutoSize = true;
            this.chkphychallanged.BackColor = System.Drawing.Color.Transparent;
            this.chkphychallanged.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkphychallanged.ForeColor = System.Drawing.Color.White;
            this.chkphychallanged.Location = new System.Drawing.Point(1019, 105);
            this.chkphychallanged.Margin = new System.Windows.Forms.Padding(4);
            this.chkphychallanged.Name = "chkphychallanged";
            this.chkphychallanged.Size = new System.Drawing.Size(201, 23);
            this.chkphychallanged.TabIndex = 239;
            this.chkphychallanged.Tag = " ";
            this.chkphychallanged.Text = "Physically Challanged";
            this.chkphychallanged.UseVisualStyleBackColor = false;
            this.chkphychallanged.CheckedChanged += new System.EventHandler(this.chkphychallanged_CheckedChanged);
            // 
            // strstdcategory
            // 
            this.strstdcategory.Enabled = false;
            this.strstdcategory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strstdcategory.FormattingEnabled = true;
            this.strstdcategory.ItemHeight = 17;
            this.strstdcategory.Items.AddRange(new object[] {
            "GENERAL",
            "OBC",
            "SC",
            "ST"});
            this.strstdcategory.Location = new System.Drawing.Point(846, 103);
            this.strstdcategory.Margin = new System.Windows.Forms.Padding(4);
            this.strstdcategory.Name = "strstdcategory";
            this.strstdcategory.Size = new System.Drawing.Size(120, 25);
            this.strstdcategory.TabIndex = 238;
            this.strstdcategory.Tag = "casttype";
            this.strstdcategory.Text = "-Select-";
            // 
            // strCmbReligion
            // 
            this.strCmbReligion.Enabled = false;
            this.strCmbReligion.FormattingEnabled = true;
            this.strCmbReligion.Location = new System.Drawing.Point(501, 103);
            this.strCmbReligion.Margin = new System.Windows.Forms.Padding(4);
            this.strCmbReligion.Name = "strCmbReligion";
            this.strCmbReligion.Size = new System.Drawing.Size(127, 24);
            this.strCmbReligion.TabIndex = 237;
            this.strCmbReligion.Tag = "Religion";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.Control;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(1217, 622);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(120, 28);
            this.btnPrint.TabIndex = 235;
            this.btnPrint.Text = "O&K";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // cmbStudentStatus
            // 
            this.cmbStudentStatus.FormattingEnabled = true;
            this.cmbStudentStatus.Items.AddRange(new object[] {
            "All Student",
            "Studying Student",
            "New Student"});
            this.cmbStudentStatus.Location = new System.Drawing.Point(399, 55);
            this.cmbStudentStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cmbStudentStatus.Name = "cmbStudentStatus";
            this.cmbStudentStatus.Size = new System.Drawing.Size(241, 24);
            this.cmbStudentStatus.TabIndex = 233;
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.BackColor = System.Drawing.Color.Transparent;
            this.chkSection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSection.ForeColor = System.Drawing.Color.White;
            this.chkSection.Location = new System.Drawing.Point(1019, 53);
            this.chkSection.Margin = new System.Windows.Forms.Padding(4);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(90, 23);
            this.chkSection.TabIndex = 231;
            this.chkSection.Text = "Section";
            this.chkSection.UseVisualStyleBackColor = false;
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            // 
            // chkClassWise
            // 
            this.chkClassWise.AutoSize = true;
            this.chkClassWise.BackColor = System.Drawing.Color.Transparent;
            this.chkClassWise.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClassWise.ForeColor = System.Drawing.Color.White;
            this.chkClassWise.Location = new System.Drawing.Point(739, 56);
            this.chkClassWise.Margin = new System.Windows.Forms.Padding(4);
            this.chkClassWise.Name = "chkClassWise";
            this.chkClassWise.Size = new System.Drawing.Size(118, 23);
            this.chkClassWise.TabIndex = 229;
            this.chkClassWise.Text = "Class Wise";
            this.chkClassWise.UseVisualStyleBackColor = false;
            this.chkClassWise.CheckedChanged += new System.EventHandler(this.chkClassWise_CheckedChanged);
            // 
            // cmbSection
            // 
            this.cmbSection.Enabled = false;
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.ForeColor = System.Drawing.Color.Blue;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(1117, 51);
            this.cmbSection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(92, 28);
            this.cmbSection.TabIndex = 232;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            // 
            // cmbSession
            // 
            this.cmbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.Blue;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(252, 55);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(116, 28);
            this.cmbSession.TabIndex = 228;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(168, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 234;
            this.label1.Text = "Session ";
            // 
            // cmbClass
            // 
            this.cmbClass.Enabled = false;
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ForeColor = System.Drawing.Color.Blue;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(865, 53);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(101, 28);
            this.cmbClass.TabIndex = 230;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            this.cmbClass.Leave += new System.EventHandler(this.cmbClass_Leave);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(54, 139);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1283, 466);
            this.dataGridView1.TabIndex = 227;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Chkgender
            // 
            this.Chkgender.AutoSize = true;
            this.Chkgender.BackColor = System.Drawing.Color.Transparent;
            this.Chkgender.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkgender.ForeColor = System.Drawing.Color.White;
            this.Chkgender.Location = new System.Drawing.Point(172, 105);
            this.Chkgender.Margin = new System.Windows.Forms.Padding(4);
            this.Chkgender.Name = "Chkgender";
            this.Chkgender.Size = new System.Drawing.Size(89, 23);
            this.Chkgender.TabIndex = 243;
            this.Chkgender.Text = "Gender";
            this.Chkgender.UseVisualStyleBackColor = false;
            this.Chkgender.CheckedChanged += new System.EventHandler(this.Chkgender_CheckedChanged);
            // 
            // cmbgender
            // 
            this.cmbgender.Enabled = false;
            this.cmbgender.FormattingEnabled = true;
            this.cmbgender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbgender.Location = new System.Drawing.Point(269, 105);
            this.cmbgender.Margin = new System.Windows.Forms.Padding(4);
            this.cmbgender.Name = "cmbgender";
            this.cmbgender.Size = new System.Drawing.Size(99, 24);
            this.cmbgender.TabIndex = 242;
            this.cmbgender.Tag = "Religion";
            // 
            // chkIsScholar
            // 
            this.chkIsScholar.AutoSize = true;
            this.chkIsScholar.BackColor = System.Drawing.Color.Transparent;
            this.chkIsScholar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsScholar.ForeColor = System.Drawing.Color.White;
            this.chkIsScholar.Location = new System.Drawing.Point(875, 622);
            this.chkIsScholar.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsScholar.Name = "chkIsScholar";
            this.chkIsScholar.Size = new System.Drawing.Size(91, 23);
            this.chkIsScholar.TabIndex = 244;
            this.chkIsScholar.Text = "Scholar";
            this.chkIsScholar.UseVisualStyleBackColor = false;
            this.chkIsScholar.CheckedChanged += new System.EventHandler(this.chkIsScholar_CheckedChanged);
            // 
            // FrmScholarship
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.chkIsScholar);
            this.Controls.Add(this.Chkgender);
            this.Controls.Add(this.cmbgender);
            this.Controls.Add(this.Chkreligion);
            this.Controls.Add(this.Chkcategory);
            this.Controls.Add(this.chkphychallanged);
            this.Controls.Add(this.strstdcategory);
            this.Controls.Add(this.strCmbReligion);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbStudentStatus);
            this.Controls.Add(this.chkSection);
            this.Controls.Add(this.chkClassWise);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmScholarship";
            this.Size = new System.Drawing.Size(1337, 679);
            this.Load += new System.EventHandler(this.FrmScholarship_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmScholarship_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox Chkreligion;
        private System.Windows.Forms.CheckBox Chkcategory;
        private System.Windows.Forms.CheckBox chkphychallanged;
        private System.Windows.Forms.ComboBox strstdcategory;
        private System.Windows.Forms.ComboBox strCmbReligion;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cmbStudentStatus;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.CheckBox chkClassWise;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox Chkgender;
        private System.Windows.Forms.ComboBox cmbgender;
        private System.Windows.Forms.CheckBox chkIsScholar;
    }
}