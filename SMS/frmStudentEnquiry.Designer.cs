namespace SMS
{
    partial class frmStudentEnquiry
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
            this.strmtongue = new System.Windows.Forms.ComboBox();
            this.txtRegDate = new System.Windows.Forms.DateTimePicker();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.txtPaddtress = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpdob = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfather = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmother = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.strstdcategory = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.valcmbclass = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.strcmbsex = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // strmtongue
            // 
            this.strmtongue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.strmtongue.FormattingEnabled = true;
            this.strmtongue.Location = new System.Drawing.Point(608, 149);
            this.strmtongue.Margin = new System.Windows.Forms.Padding(4);
            this.strmtongue.Name = "strmtongue";
            this.strmtongue.Size = new System.Drawing.Size(199, 24);
            this.strmtongue.TabIndex = 7;
            this.strmtongue.Tag = "m_tongue";
            this.strmtongue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // txtRegDate
            // 
            this.txtRegDate.CustomFormat = "dd/MM/yyyy";
            this.txtRegDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtRegDate.Location = new System.Drawing.Point(608, 60);
            this.txtRegDate.Margin = new System.Windows.Forms.Padding(4);
            this.txtRegDate.Name = "txtRegDate";
            this.txtRegDate.Size = new System.Drawing.Size(199, 22);
            this.txtRegDate.TabIndex = 5;
            this.txtRegDate.Tag = "RegDate";
            this.txtRegDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.White;
            this.label38.Location = new System.Drawing.Point(467, 64);
            this.label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(99, 18);
            this.label38.TabIndex = 72;
            this.label38.Text = "Enquiry Date";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.Location = new System.Drawing.Point(564, 201);
            this.label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(36, 18);
            this.label37.TabIndex = 73;
            this.label37.Text = "+91";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNo.ForeColor = System.Drawing.Color.Blue;
            this.txtMobileNo.Location = new System.Drawing.Point(608, 194);
            this.txtMobileNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtMobileNo.MaxLength = 10;
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(199, 25);
            this.txtMobileNo.TabIndex = 8;
            this.txtMobileNo.Tag = "phone";
            this.txtMobileNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.Transparent;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label59.ForeColor = System.Drawing.Color.White;
            this.label59.Location = new System.Drawing.Point(467, 199);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(90, 18);
            this.label59.TabIndex = 65;
            this.label59.Text = "Mobile No.";
            // 
            // txtPaddtress
            // 
            this.txtPaddtress.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaddtress.ForeColor = System.Drawing.Color.Blue;
            this.txtPaddtress.Location = new System.Drawing.Point(211, 210);
            this.txtPaddtress.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaddtress.MaxLength = 500;
            this.txtPaddtress.Multiline = true;
            this.txtPaddtress.Name = "txtPaddtress";
            this.txtPaddtress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPaddtress.Size = new System.Drawing.Size(199, 53);
            this.txtPaddtress.TabIndex = 3;
            this.txtPaddtress.Tag = "txtPaddtress";
            this.txtPaddtress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.ForeColor = System.Drawing.Color.Blue;
            this.txtStudentName.Location = new System.Drawing.Point(211, 60);
            this.txtStudentName.Margin = new System.Windows.Forms.Padding(4);
            this.txtStudentName.MaxLength = 30;
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.Size = new System.Drawing.Size(199, 25);
            this.txtStudentName.TabIndex = 0;
            this.txtStudentName.Tag = "name";
            this.txtStudentName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(64, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 18);
            this.label2.TabIndex = 71;
            this.label2.Text = "Student\'s Name *";
            // 
            // dtpdob
            // 
            this.dtpdob.CustomFormat = "dd/MM/yyyy";
            this.dtpdob.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpdob.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdob.Location = new System.Drawing.Point(608, 103);
            this.dtpdob.Margin = new System.Windows.Forms.Padding(4);
            this.dtpdob.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dtpdob.MinDate = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dtpdob.Name = "dtpdob";
            this.dtpdob.Size = new System.Drawing.Size(199, 25);
            this.dtpdob.TabIndex = 6;
            this.dtpdob.Tag = "dob";
            this.dtpdob.Value = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.dtpdob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(467, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 18);
            this.label3.TabIndex = 70;
            this.label3.Text = "Date of Birth";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(64, 211);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 44);
            this.label4.TabIndex = 66;
            this.label4.Text = "Address (Permanent)";
            // 
            // txtfather
            // 
            this.txtfather.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfather.ForeColor = System.Drawing.Color.Blue;
            this.txtfather.Location = new System.Drawing.Point(211, 110);
            this.txtfather.Margin = new System.Windows.Forms.Padding(4);
            this.txtfather.MaxLength = 30;
            this.txtfather.Name = "txtfather";
            this.txtfather.Size = new System.Drawing.Size(199, 25);
            this.txtfather.TabIndex = 1;
            this.txtfather.Tag = "father";
            this.txtfather.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(64, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 18);
            this.label5.TabIndex = 68;
            this.label5.Text = "Father\'s Name *";
            // 
            // txtmother
            // 
            this.txtmother.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmother.ForeColor = System.Drawing.Color.Blue;
            this.txtmother.Location = new System.Drawing.Point(211, 160);
            this.txtmother.Margin = new System.Windows.Forms.Padding(4);
            this.txtmother.MaxLength = 30;
            this.txtmother.Name = "txtmother";
            this.txtmother.Size = new System.Drawing.Size(199, 25);
            this.txtmother.TabIndex = 2;
            this.txtmother.Tag = "mother";
            this.txtmother.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.White;
            this.label35.Location = new System.Drawing.Point(64, 162);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(123, 18);
            this.label35.TabIndex = 67;
            this.label35.Text = "Mother\'s Name";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(467, 154);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(122, 18);
            this.label29.TabIndex = 69;
            this.label29.Text = "Mother Tongue";
            // 
            // strstdcategory
            // 
            this.strstdcategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.strstdcategory.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strstdcategory.FormattingEnabled = true;
            this.strstdcategory.ItemHeight = 17;
            this.strstdcategory.Items.AddRange(new object[] {
            "GENERAL",
            "OBC",
            "SC",
            "ST"});
            this.strstdcategory.Location = new System.Drawing.Point(608, 240);
            this.strstdcategory.Margin = new System.Windows.Forms.Padding(4);
            this.strstdcategory.Name = "strstdcategory";
            this.strstdcategory.Size = new System.Drawing.Size(199, 25);
            this.strstdcategory.TabIndex = 9;
            this.strstdcategory.Tag = "casttype";
            this.strstdcategory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(467, 244);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 18);
            this.label7.TabIndex = 77;
            this.label7.Text = "Student Category";
            // 
            // valcmbclass
            // 
            this.valcmbclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbclass.ForeColor = System.Drawing.Color.Blue;
            this.valcmbclass.FormattingEnabled = true;
            this.valcmbclass.Location = new System.Drawing.Point(211, 288);
            this.valcmbclass.Margin = new System.Windows.Forms.Padding(4);
            this.valcmbclass.Name = "valcmbclass";
            this.valcmbclass.Size = new System.Drawing.Size(199, 25);
            this.valcmbclass.TabIndex = 4;
            this.valcmbclass.Tag = "";
            this.valcmbclass.Text = "-SELECT-";
            this.valcmbclass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(64, 286);
            this.label45.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(134, 18);
            this.label45.TabIndex = 162;
            this.label45.Text = "Admission Class";
            // 
            // strcmbsex
            // 
            this.strcmbsex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.strcmbsex.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strcmbsex.FormattingEnabled = true;
            this.strcmbsex.ItemHeight = 17;
            this.strcmbsex.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.strcmbsex.Location = new System.Drawing.Point(608, 286);
            this.strcmbsex.Margin = new System.Windows.Forms.Padding(4);
            this.strcmbsex.Name = "strcmbsex";
            this.strcmbsex.Size = new System.Drawing.Size(199, 25);
            this.strcmbsex.TabIndex = 10;
            this.strcmbsex.Tag = "marr_status";
            this.strcmbsex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentName_KeyPress);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.White;
            this.label39.Location = new System.Drawing.Point(467, 289);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(62, 18);
            this.label39.TabIndex = 164;
            this.label39.Text = "Gender";
            // 
            // frmStudentEnquiry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.strcmbsex);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.valcmbclass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.strmtongue);
            this.Controls.Add(this.txtRegDate);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txtMobileNo);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.txtPaddtress);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpdob);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtfather);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtmother);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.strstdcategory);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmStudentEnquiry";
            this.Size = new System.Drawing.Size(851, 427);
            this.Load += new System.EventHandler(this.frmStudentEnquiry_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmStudentEnquiry_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox strmtongue;
        private System.Windows.Forms.DateTimePicker txtRegDate;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpdob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtfather;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmother;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox strstdcategory;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox valcmbclass;
        private System.Windows.Forms.Label label45;
        public System.Windows.Forms.TextBox txtPaddtress;
        private System.Windows.Forms.ComboBox strcmbsex;
        private System.Windows.Forms.Label label39;
    }
}