namespace SMS
{
    partial class Subjectwiseclass
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
            this.valcmbclass = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.dtgbook = new System.Windows.Forms.DataGridView();
            this.subjectno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subincl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // valcmbclass
            // 
            this.valcmbclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbclass.ForeColor = System.Drawing.Color.Blue;
            this.valcmbclass.FormattingEnabled = true;
            this.valcmbclass.Items.AddRange(new object[] {
            "Studing",
            "Terminate"});
            this.valcmbclass.Location = new System.Drawing.Point(167, 46);
            this.valcmbclass.Margin = new System.Windows.Forms.Padding(4);
            this.valcmbclass.Name = "valcmbclass";
            this.valcmbclass.Size = new System.Drawing.Size(245, 25);
            this.valcmbclass.TabIndex = 0;
            this.valcmbclass.Tag = "";
            this.valcmbclass.Text = "-SELECT-";
            this.valcmbclass.SelectedIndexChanged += new System.EventHandler(this.valcmbclass_SelectedIndexChanged);
            this.valcmbclass.SelectedValueChanged += new System.EventHandler(this.valcmbclass_SelectedValueChanged);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(46, 48);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(52, 19);
            this.label45.TabIndex = 160;
            this.label45.Text = "Class";
            // 
            // dtgbook
            // 
            this.dtgbook.AllowUserToAddRows = false;
            this.dtgbook.AllowUserToDeleteRows = false;
            this.dtgbook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.subjectno,
            this.SubjectCode,
            this.subjectname,
            this.subincl,
            this.EDate});
            this.dtgbook.Location = new System.Drawing.Point(49, 164);
            this.dtgbook.Margin = new System.Windows.Forms.Padding(4);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.RowHeadersWidth = 4;
            this.dtgbook.Size = new System.Drawing.Size(552, 308);
            this.dtgbook.TabIndex = 158;
            this.dtgbook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgbook_CellClick);
            this.dtgbook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvApps_CellContentClick);
            // 
            // subjectno
            // 
            this.subjectno.HeaderText = "Subject No";
            this.subjectno.Name = "subjectno";
            this.subjectno.Visible = false;
            this.subjectno.Width = 70;
            // 
            // SubjectCode
            // 
            this.SubjectCode.HeaderText = "Subject Code";
            this.SubjectCode.Name = "SubjectCode";
            this.SubjectCode.ReadOnly = true;
            this.SubjectCode.Width = 96;
            // 
            // subjectname
            // 
            this.subjectname.HeaderText = "Subject Name";
            this.subjectname.Name = "subjectname";
            this.subjectname.ReadOnly = true;
            this.subjectname.Width = 140;
            // 
            // subincl
            // 
            this.subincl.HeaderText = "Include";
            this.subincl.Name = "subincl";
            this.subincl.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.subincl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.subincl.Width = 50;
            // 
            // EDate
            // 
            this.EDate.DataPropertyName = "EDate";
            this.EDate.HeaderText = "Date";
            this.EDate.Name = "EDate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(743, 46);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(96, 304);
            this.groupBox1.TabIndex = 184;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BOARD OF STUDEY";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(323, 23);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(118, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "CBSC BOARD";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(140, 23);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(102, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "MP BOARD";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 131);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 186;
            this.label1.Text = "Stream";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.Color.Blue;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(167, 88);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(245, 25);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.Tag = "";
            this.comboBox2.Text = "-SELECT-";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 19);
            this.label2.TabIndex = 188;
            this.label2.Text = "Subject Type";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.Blue;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Core Subject",
            "Elective Subject"});
            this.comboBox1.Location = new System.Drawing.Point(167, 131);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(245, 25);
            this.comboBox1.TabIndex = 189;
            this.comboBox1.Tag = "";
            this.comboBox1.Text = "-SELECT-";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Subjectwiseclass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.valcmbclass);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.dtgbook);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Subjectwiseclass";
            this.Size = new System.Drawing.Size(626, 566);
            this.Tag = "1160";
            this.Load += new System.EventHandler(this.Subjectwiseclass_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Subjectwiseclass_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox valcmbclass;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.DataGridView dtgbook;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectno;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn subincl;
        private System.Windows.Forms.DataGridViewTextBoxColumn EDate;
    }
}