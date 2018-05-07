namespace SMS
{
    partial class frmclasswisestudent
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnclasswise = new System.Windows.Forms.Button();
            this.btnsectionwise = new System.Windows.Forms.Button();
            this.cmbStudentStatus = new System.Windows.Forms.ComboBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.chkClassWise = new System.Windows.Forms.CheckBox();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.strCmbReligion = new System.Windows.Forms.ComboBox();
            this.strstdcategory = new System.Windows.Forms.ComboBox();
            this.chkphychallanged = new System.Windows.Forms.CheckBox();
            this.Chkcategory = new System.Windows.Forms.CheckBox();
            this.Chkreligion = new System.Windows.Forms.CheckBox();
            this.chkRTE = new System.Windows.Forms.CheckBox();
            this.Chkgender = new System.Windows.Forms.CheckBox();
            this.cmbgender = new System.Windows.Forms.ComboBox();
            this.chkAdhar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(66, 124);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(853, 379);
            this.dataGridView1.TabIndex = 160;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // btnclasswise
            // 
            this.btnclasswise.BackColor = System.Drawing.Color.White;
            this.btnclasswise.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnclasswise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclasswise.ForeColor = System.Drawing.Color.Black;
            this.btnclasswise.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnclasswise.Location = new System.Drawing.Point(66, 506);
            this.btnclasswise.Name = "btnclasswise";
            this.btnclasswise.Size = new System.Drawing.Size(104, 65);
            this.btnclasswise.TabIndex = 164;
            this.btnclasswise.Text = "&Class Wise Report";
            this.btnclasswise.UseVisualStyleBackColor = false;
            this.btnclasswise.Visible = false;
            this.btnclasswise.Click += new System.EventHandler(this.btnclasswise_Click);
            // 
            // btnsectionwise
            // 
            this.btnsectionwise.BackColor = System.Drawing.Color.White;
            this.btnsectionwise.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnsectionwise.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsectionwise.ForeColor = System.Drawing.Color.Black;
            this.btnsectionwise.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnsectionwise.Location = new System.Drawing.Point(171, 506);
            this.btnsectionwise.Name = "btnsectionwise";
            this.btnsectionwise.Size = new System.Drawing.Size(109, 64);
            this.btnsectionwise.TabIndex = 165;
            this.btnsectionwise.Text = "&Section Wise Report";
            this.btnsectionwise.UseVisualStyleBackColor = false;
            this.btnsectionwise.Visible = false;
            this.btnsectionwise.Click += new System.EventHandler(this.btnsectionwise_Click);
            // 
            // cmbStudentStatus
            // 
            this.cmbStudentStatus.FormattingEnabled = true;
            this.cmbStudentStatus.Items.AddRange(new object[] {
            "All Student",
            "Studying Student",
            "New Student"});
            this.cmbStudentStatus.Location = new System.Drawing.Point(237, 59);
            this.cmbStudentStatus.Name = "cmbStudentStatus";
            this.cmbStudentStatus.Size = new System.Drawing.Size(182, 24);
            this.cmbStudentStatus.TabIndex = 171;
            this.cmbStudentStatus.SelectedIndexChanged += new System.EventHandler(this.cmbStudentStatus_SelectedIndexChanged);
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.BackColor = System.Drawing.Color.Transparent;
            this.chkSection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSection.ForeColor = System.Drawing.Color.White;
            this.chkSection.Location = new System.Drawing.Point(710, 58);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(134, 23);
            this.chkSection.TabIndex = 169;
            this.chkSection.Text = "Section Wise";
            this.chkSection.UseVisualStyleBackColor = false;
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            // 
            // chkClassWise
            // 
            this.chkClassWise.AutoSize = true;
            this.chkClassWise.BackColor = System.Drawing.Color.Transparent;
            this.chkClassWise.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClassWise.ForeColor = System.Drawing.Color.White;
            this.chkClassWise.Location = new System.Drawing.Point(469, 57);
            this.chkClassWise.Name = "chkClassWise";
            this.chkClassWise.Size = new System.Drawing.Size(118, 23);
            this.chkClassWise.TabIndex = 167;
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
            this.cmbSection.Location = new System.Drawing.Point(845, 57);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(70, 28);
            this.cmbSection.TabIndex = 170;
            this.cmbSection.SelectedIndexChanged += new System.EventHandler(this.cmbSection_SelectedIndexChanged);
            this.cmbSection.Leave += new System.EventHandler(this.cmbSection_Leave);
            // 
            // cmbSession
            // 
            this.cmbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.Blue;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(141, 58);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(90, 28);
            this.cmbSession.TabIndex = 166;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 173;
            this.label1.Text = "Session ";
            // 
            // cmbClass
            // 
            this.cmbClass.Enabled = false;
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ForeColor = System.Drawing.Color.Blue;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(591, 56);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(77, 28);
            this.cmbClass.TabIndex = 168;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            this.cmbClass.Leave += new System.EventHandler(this.cmbClass_Leave);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.White;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnPrint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPrint.Location = new System.Drawing.Point(839, 509);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(80, 28);
            this.btnPrint.TabIndex = 174;
            this.btnPrint.Text = "O&K";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // strCmbReligion
            // 
            this.strCmbReligion.Enabled = false;
            this.strCmbReligion.FormattingEnabled = true;
            this.strCmbReligion.Location = new System.Drawing.Point(378, 94);
            this.strCmbReligion.Name = "strCmbReligion";
            this.strCmbReligion.Size = new System.Drawing.Size(96, 24);
            this.strCmbReligion.TabIndex = 221;
            this.strCmbReligion.Tag = "Religion";
            this.strCmbReligion.SelectedIndexChanged += new System.EventHandler(this.strCmbReligion_SelectedIndexChanged);
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
            this.strstdcategory.Location = new System.Drawing.Point(698, 93);
            this.strstdcategory.Name = "strstdcategory";
            this.strstdcategory.Size = new System.Drawing.Size(96, 25);
            this.strstdcategory.TabIndex = 222;
            this.strstdcategory.Tag = "casttype";
            this.strstdcategory.Text = "-Select-";
            this.strstdcategory.SelectedIndexChanged += new System.EventHandler(this.strstdcategory_SelectedIndexChanged);
            // 
            // chkphychallanged
            // 
            this.chkphychallanged.AutoSize = true;
            this.chkphychallanged.BackColor = System.Drawing.Color.Transparent;
            this.chkphychallanged.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkphychallanged.ForeColor = System.Drawing.Color.White;
            this.chkphychallanged.Location = new System.Drawing.Point(320, 509);
            this.chkphychallanged.Name = "chkphychallanged";
            this.chkphychallanged.Size = new System.Drawing.Size(201, 23);
            this.chkphychallanged.TabIndex = 224;
            this.chkphychallanged.Tag = " ";
            this.chkphychallanged.Text = "Physically Challanged";
            this.chkphychallanged.UseVisualStyleBackColor = false;
            this.chkphychallanged.CheckedChanged += new System.EventHandler(this.chkphychallanged_CheckedChanged);
            // 
            // Chkcategory
            // 
            this.Chkcategory.AutoSize = true;
            this.Chkcategory.BackColor = System.Drawing.Color.Transparent;
            this.Chkcategory.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkcategory.ForeColor = System.Drawing.Color.White;
            this.Chkcategory.Location = new System.Drawing.Point(522, 95);
            this.Chkcategory.Name = "Chkcategory";
            this.Chkcategory.Size = new System.Drawing.Size(170, 23);
            this.Chkcategory.TabIndex = 225;
            this.Chkcategory.Text = "Student Category";
            this.Chkcategory.UseVisualStyleBackColor = false;
            this.Chkcategory.CheckedChanged += new System.EventHandler(this.Chkcategory_CheckedChanged);
            // 
            // Chkreligion
            // 
            this.Chkreligion.AutoSize = true;
            this.Chkreligion.BackColor = System.Drawing.Color.Transparent;
            this.Chkreligion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkreligion.ForeColor = System.Drawing.Color.White;
            this.Chkreligion.Location = new System.Drawing.Point(278, 95);
            this.Chkreligion.Name = "Chkreligion";
            this.Chkreligion.Size = new System.Drawing.Size(94, 23);
            this.Chkreligion.TabIndex = 226;
            this.Chkreligion.Text = "Religion";
            this.Chkreligion.UseVisualStyleBackColor = false;
            this.Chkreligion.CheckedChanged += new System.EventHandler(this.Chkreligion_CheckedChanged);
            // 
            // chkRTE
            // 
            this.chkRTE.AutoSize = true;
            this.chkRTE.BackColor = System.Drawing.Color.Transparent;
            this.chkRTE.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRTE.ForeColor = System.Drawing.Color.White;
            this.chkRTE.Location = new System.Drawing.Point(638, 509);
            this.chkRTE.Name = "chkRTE";
            this.chkRTE.Size = new System.Drawing.Size(64, 23);
            this.chkRTE.TabIndex = 227;
            this.chkRTE.Tag = "IsRTE";
            this.chkRTE.Text = "RTE";
            this.chkRTE.UseVisualStyleBackColor = false;
            this.chkRTE.CheckedChanged += new System.EventHandler(this.chkRTE_CheckedChanged);
            // 
            // Chkgender
            // 
            this.Chkgender.AutoSize = true;
            this.Chkgender.BackColor = System.Drawing.Color.Transparent;
            this.Chkgender.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chkgender.ForeColor = System.Drawing.Color.White;
            this.Chkgender.Location = new System.Drawing.Point(66, 96);
            this.Chkgender.Name = "Chkgender";
            this.Chkgender.Size = new System.Drawing.Size(89, 23);
            this.Chkgender.TabIndex = 245;
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
            this.cmbgender.Location = new System.Drawing.Point(156, 95);
            this.cmbgender.Name = "cmbgender";
            this.cmbgender.Size = new System.Drawing.Size(75, 24);
            this.cmbgender.TabIndex = 244;
            this.cmbgender.Tag = "Religion";
            this.cmbgender.SelectedIndexChanged += new System.EventHandler(this.cmbgender_SelectedIndexChanged);
            // 
            // chkAdhar
            // 
            this.chkAdhar.AutoSize = true;
            this.chkAdhar.BackColor = System.Drawing.Color.Transparent;
            this.chkAdhar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAdhar.ForeColor = System.Drawing.Color.White;
            this.chkAdhar.Location = new System.Drawing.Point(527, 509);
            this.chkAdhar.Name = "chkAdhar";
            this.chkAdhar.Size = new System.Drawing.Size(105, 23);
            this.chkAdhar.TabIndex = 246;
            this.chkAdhar.Tag = "AdharNo";
            this.chkAdhar.Text = "Adhar No";
            this.chkAdhar.UseVisualStyleBackColor = false;
            this.chkAdhar.CheckedChanged += new System.EventHandler(this.chkAdhar_CheckedChanged);
            // 
            // frmclasswisestudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.chkAdhar);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.Chkgender);
            this.Controls.Add(this.cmbgender);
            this.Controls.Add(this.chkRTE);
            this.Controls.Add(this.Chkreligion);
            this.Controls.Add(this.Chkcategory);
            this.Controls.Add(this.chkphychallanged);
            this.Controls.Add(this.strstdcategory);
            this.Controls.Add(this.strCmbReligion);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbStudentStatus);
            this.Controls.Add(this.chkSection);
            this.Controls.Add(this.chkClassWise);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.btnsectionwise);
            this.Controls.Add(this.btnclasswise);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmclasswisestudent";
            this.Size = new System.Drawing.Size(955, 619);
            this.Tag = "1055";
            this.Load += new System.EventHandler(this.frmclasswisestudent_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmclasswisestudent_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnclasswise;
        private System.Windows.Forms.Button btnsectionwise;
        private System.Windows.Forms.ComboBox cmbStudentStatus;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.CheckBox chkClassWise;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox strCmbReligion;
        private System.Windows.Forms.ComboBox strstdcategory;
        private System.Windows.Forms.CheckBox chkphychallanged;
        private System.Windows.Forms.CheckBox Chkcategory;
        private System.Windows.Forms.CheckBox Chkreligion;
        private System.Windows.Forms.CheckBox chkRTE;
        private System.Windows.Forms.CheckBox Chkgender;
        private System.Windows.Forms.ComboBox cmbgender;
        private System.Windows.Forms.CheckBox chkAdhar;
    }
}