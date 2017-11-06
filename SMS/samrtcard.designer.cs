namespace SMS
{
    partial class samrtcard
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
            this.label45 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.btnBarcode = new System.Windows.Forms.Button();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNormarl = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnAdminCard = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbExam = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(63, 84);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1173, 510);
            this.dataGridView1.TabIndex = 165;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(61, 54);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(52, 19);
            this.label45.TabIndex = 162;
            this.label45.Text = "Class";
            // 
            // cmbClass
            // 
            this.cmbClass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ForeColor = System.Drawing.Color.Blue;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Items.AddRange(new object[] {
            "Studing",
            "Terminate"});
            this.cmbClass.Location = new System.Drawing.Point(121, 50);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(197, 25);
            this.cmbClass.TabIndex = 0;
            this.cmbClass.Tag = "";
            this.cmbClass.Leave += new System.EventHandler(this.cmbClass_Leave);
            // 
            // btnBarcode
            // 
            this.btnBarcode.BackColor = System.Drawing.SystemColors.Control;
            this.btnBarcode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBarcode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarcode.ForeColor = System.Drawing.Color.Black;
            this.btnBarcode.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBarcode.Location = new System.Drawing.Point(751, 602);
            this.btnBarcode.Margin = new System.Windows.Forms.Padding(4);
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(157, 28);
            this.btnBarcode.TabIndex = 1;
            this.btnBarcode.Text = "&Barcoded";
            this.btnBarcode.UseVisualStyleBackColor = true;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // cmbSection
            // 
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.ForeColor = System.Drawing.Color.Blue;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(431, 49);
            this.cmbSection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(92, 28);
            this.cmbSection.TabIndex = 171;
            this.cmbSection.Validated += new System.EventHandler(this.cmbSection_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(355, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 172;
            this.label2.Text = "Section";
            // 
            // btnNormarl
            // 
            this.btnNormarl.BackColor = System.Drawing.SystemColors.Control;
            this.btnNormarl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNormarl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNormarl.ForeColor = System.Drawing.Color.Black;
            this.btnNormarl.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNormarl.Location = new System.Drawing.Point(916, 602);
            this.btnNormarl.Margin = new System.Windows.Forms.Padding(4);
            this.btnNormarl.Name = "btnNormarl";
            this.btnNormarl.Size = new System.Drawing.Size(157, 28);
            this.btnNormarl.TabIndex = 173;
            this.btnNormarl.Text = "Identity &Card";
            this.btnNormarl.UseVisualStyleBackColor = true;
            this.btnNormarl.Click += new System.EventHandler(this.btnNormarl_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.chkSelectAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSelectAll.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelectAll.ForeColor = System.Drawing.Color.White;
            this.chkSelectAll.Location = new System.Drawing.Point(63, 607);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(111, 25);
            this.chkSelectAll.TabIndex = 174;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnAdminCard
            // 
            this.btnAdminCard.BackColor = System.Drawing.SystemColors.Control;
            this.btnAdminCard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdminCard.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminCard.ForeColor = System.Drawing.Color.Black;
            this.btnAdminCard.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdminCard.Location = new System.Drawing.Point(1081, 602);
            this.btnAdminCard.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdminCard.Name = "btnAdminCard";
            this.btnAdminCard.Size = new System.Drawing.Size(157, 28);
            this.btnAdminCard.TabIndex = 175;
            this.btnAdminCard.Text = "Admit Ca&rd ";
            this.btnAdminCard.UseVisualStyleBackColor = true;
            this.btnAdminCard.Click += new System.EventHandler(this.btnAdminCard_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(551, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 177;
            this.label3.Text = "Select Exam";
            // 
            // cmbExam
            // 
            this.cmbExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExam.FormattingEnabled = true;
            this.cmbExam.Items.AddRange(new object[] {
            "FA1",
            "FA2",
            "SA1",
            "FA3",
            "FA4",
            "SA2"});
            this.cmbExam.Location = new System.Drawing.Point(678, 49);
            this.cmbExam.Margin = new System.Windows.Forms.Padding(4);
            this.cmbExam.Name = "cmbExam";
            this.cmbExam.Size = new System.Drawing.Size(140, 26);
            this.cmbExam.TabIndex = 176;
            // 
            // samrtcard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbExam);
            this.Controls.Add(this.btnAdminCard);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnNormarl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBarcode);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.cmbClass);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "samrtcard";
            this.Size = new System.Drawing.Size(1289, 660);
            this.Tag = "1144";
            this.Load += new System.EventHandler(this.samrtcard_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.samrtcard_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBarcode;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNormarl;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnAdminCard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbExam;
    }
}