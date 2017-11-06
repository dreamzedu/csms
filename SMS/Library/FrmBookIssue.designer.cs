namespace SMS.Library
{
    partial class FrmBookIssue
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btndelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.BooktitleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScholarNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.member_pic = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.txtBBookNo = new System.Windows.Forms.TextBox();
            this.txtStudEnrollNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBookNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEnrollNo = new System.Windows.Forms.TextBox();
            this.TxtBno = new System.Windows.Forms.TextBox();
            this.TxtStuSchaler = new System.Windows.Forms.TextBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.BtnGetBBarcode = new System.Windows.Forms.Button();
            this.BtnGetSBarcode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.member_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(284, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 22);
            this.label8.TabIndex = 225;
            this.label8.Text = "Issued Book";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Tomato;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btndelete,
            this.BooktitleNo,
            this.BookName,
            this.Date,
            this.ScholarNo,
            this.StudentName,
            this.bookno});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(25, 208);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Tomato;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(645, 157);
            this.dataGridView1.TabIndex = 224;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btndelete
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btndelete.DefaultCellStyle = dataGridViewCellStyle2;
            this.btndelete.HeaderText = "Delete ";
            this.btndelete.Name = "btndelete";
            this.btndelete.Text = "Delete ";
            this.btndelete.ToolTipText = "delete";
            // 
            // BooktitleNo
            // 
            this.BooktitleNo.HeaderText = "Book Title No.";
            this.BooktitleNo.Name = "BooktitleNo";
            this.BooktitleNo.ReadOnly = true;
            // 
            // BookName
            // 
            this.BookName.HeaderText = "Book Name";
            this.BookName.Name = "BookName";
            this.BookName.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // ScholarNo
            // 
            this.ScholarNo.HeaderText = "Scholar No.";
            this.ScholarNo.Name = "ScholarNo";
            this.ScholarNo.ReadOnly = true;
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "Student Name";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            // 
            // bookno
            // 
            this.bookno.DataPropertyName = "bookno";
            this.bookno.HeaderText = "bno";
            this.bookno.Name = "bookno";
            this.bookno.Visible = false;
            // 
            // member_pic
            // 
            this.member_pic.Location = new System.Drawing.Point(575, 44);
            this.member_pic.Name = "member_pic";
            this.member_pic.Size = new System.Drawing.Size(95, 115);
            this.member_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.member_pic.TabIndex = 223;
            this.member_pic.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(39, 387);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 16);
            this.label7.TabIndex = 222;
            this.label7.Text = "Issued Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(163, 387);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(507, 42);
            this.txtRemark.TabIndex = 212;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(407, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 221;
            this.label6.Text = "Book Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(27, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 220;
            this.label5.Text = "Accession No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 219;
            this.label4.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 218;
            this.label3.Text = "Scholar No";
            // 
            // txtBookName
            // 
            this.txtBookName.Location = new System.Drawing.Point(499, 172);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.ReadOnly = true;
            this.txtBookName.Size = new System.Drawing.Size(171, 20);
            this.txtBookName.TabIndex = 217;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Location = new System.Drawing.Point(164, 139);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(198, 20);
            this.txtStudentName.TabIndex = 216;
            // 
            // txtBBookNo
            // 
            this.txtBBookNo.Location = new System.Drawing.Point(164, 173);
            this.txtBBookNo.Name = "txtBBookNo";
            this.txtBBookNo.Size = new System.Drawing.Size(198, 20);
            this.txtBBookNo.TabIndex = 210;
            this.txtBBookNo.TextChanged += new System.EventHandler(this.txtBBookNo_TextChanged);
            // 
            // txtStudEnrollNo
            // 
            this.txtStudEnrollNo.Location = new System.Drawing.Point(164, 105);
            this.txtStudEnrollNo.Name = "txtStudEnrollNo";
            this.txtStudEnrollNo.ReadOnly = true;
            this.txtStudEnrollNo.Size = new System.Drawing.Size(198, 20);
            this.txtStudEnrollNo.TabIndex = 208;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 209;
            this.label2.Text = "Book Barcode";
            // 
            // txtBookNo
            // 
            this.txtBookNo.Location = new System.Drawing.Point(164, 71);
            this.txtBookNo.Name = "txtBookNo";
            this.txtBookNo.Size = new System.Drawing.Size(198, 20);
            this.txtBookNo.TabIndex = 206;
            this.txtBookNo.TextChanged += new System.EventHandler(this.txtBookNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 207;
            this.label1.Text = "Student Barcode";
            // 
            // txtEnrollNo
            // 
            this.txtEnrollNo.Location = new System.Drawing.Point(164, 37);
            this.txtEnrollNo.Name = "txtEnrollNo";
            this.txtEnrollNo.Size = new System.Drawing.Size(199, 20);
            this.txtEnrollNo.TabIndex = 205;
            this.txtEnrollNo.TextChanged += new System.EventHandler(this.txtEnrollNo_TextChanged);
            // 
            // TxtBno
            // 
            this.TxtBno.Location = new System.Drawing.Point(369, 71);
            this.TxtBno.Name = "TxtBno";
            this.TxtBno.Size = new System.Drawing.Size(100, 20);
            this.TxtBno.TabIndex = 227;
            // 
            // TxtStuSchaler
            // 
            this.TxtStuSchaler.Location = new System.Drawing.Point(369, 37);
            this.TxtStuSchaler.Name = "TxtStuSchaler";
            this.TxtStuSchaler.Size = new System.Drawing.Size(100, 20);
            this.TxtStuSchaler.TabIndex = 226;
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.Black;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexit.Location = new System.Drawing.Point(630, 435);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(40, 42);
            this.btnexit.TabIndex = 229;
            this.btnexit.Text = "E&xit";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.Image = global::SMS.Properties.Resources.save;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(570, 435);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(60, 42);
            this.btnsave.TabIndex = 228;
            this.btnsave.Text = "Sa&ve";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // BtnGetBBarcode
            // 
            this.BtnGetBBarcode.BackColor = System.Drawing.Color.White;
            this.BtnGetBBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnGetBBarcode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGetBBarcode.ForeColor = System.Drawing.Color.Black;
            this.BtnGetBBarcode.Location = new System.Drawing.Point(470, 70);
            this.BtnGetBBarcode.Name = "BtnGetBBarcode";
            this.BtnGetBBarcode.Size = new System.Drawing.Size(86, 22);
            this.BtnGetBBarcode.TabIndex = 230;
            this.BtnGetBBarcode.Text = "Get Barcode";
            this.BtnGetBBarcode.UseVisualStyleBackColor = false;
            this.BtnGetBBarcode.Click += new System.EventHandler(this.BtnGetBBarcode_Click);
            // 
            // BtnGetSBarcode
            // 
            this.BtnGetSBarcode.BackColor = System.Drawing.Color.White;
            this.BtnGetSBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnGetSBarcode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGetSBarcode.ForeColor = System.Drawing.Color.Black;
            this.BtnGetSBarcode.Location = new System.Drawing.Point(470, 36);
            this.BtnGetSBarcode.Name = "BtnGetSBarcode";
            this.BtnGetSBarcode.Size = new System.Drawing.Size(86, 22);
            this.BtnGetSBarcode.TabIndex = 231;
            this.BtnGetSBarcode.Text = "Get Barcode";
            this.BtnGetSBarcode.UseVisualStyleBackColor = false;
            this.BtnGetSBarcode.Click += new System.EventHandler(this.BtnGetSBarcode_Click);
            // 
            // FrmBookIssue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(695, 495);
            this.Controls.Add(this.BtnGetSBarcode);
            this.Controls.Add(this.BtnGetBBarcode);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.TxtBno);
            this.Controls.Add(this.TxtStuSchaler);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.member_pic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBookName);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.txtBBookNo);
            this.Controls.Add(this.txtStudEnrollNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBookNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEnrollNo);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBookIssue";
            this.Text = "FrmBookIssue";
            this.Load += new System.EventHandler(this.FrmBookIssue_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBookIssue_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.member_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox member_pic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.TextBox txtBBookNo;
        private System.Windows.Forms.TextBox txtStudEnrollNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtBno;
        private System.Windows.Forms.TextBox TxtStuSchaler;
        private System.Windows.Forms.DataGridViewButtonColumn btndelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn BooktitleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScholarNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookno;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button BtnGetBBarcode;
        private System.Windows.Forms.Button BtnGetSBarcode;
        public System.Windows.Forms.TextBox txtEnrollNo;
        public System.Windows.Forms.TextBox txtBookNo;
    }
}