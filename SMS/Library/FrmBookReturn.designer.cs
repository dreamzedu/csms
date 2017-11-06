namespace SMS.Library
{
    partial class FrmBookReturn
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label25 = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BooktitleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btndelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ScholarNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Noofday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payamount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GVSudentBookDeails = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtpaidamount = new System.Windows.Forms.TextBox();
            this.txtpayamount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtday = new System.Windows.Forms.TextBox();
            this.member_pic = new System.Windows.Forms.PictureBox();
            this.Remark = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBookName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBookNo = new System.Windows.Forms.TextBox();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEnrollNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBookBarcodeNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStudentBarCode = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSudentBookDeails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.member_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label25.Location = new System.Drawing.Point(296, 4);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(125, 24);
            this.label25.TabIndex = 242;
            this.label25.Text = "Return Book";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // BookName
            // 
            this.BookName.HeaderText = "Book Name";
            this.BookName.Name = "BookName";
            // 
            // BooktitleNo
            // 
            this.BooktitleNo.HeaderText = "Book Title No.";
            this.BooktitleNo.Name = "BooktitleNo";
            // 
            // btndelete
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btndelete.DefaultCellStyle = dataGridViewCellStyle5;
            this.btndelete.HeaderText = "Delete ";
            this.btndelete.Name = "btndelete";
            this.btndelete.Text = "Delete ";
            this.btndelete.ToolTipText = "delete";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Tomato;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btndelete,
            this.BooktitleNo,
            this.BookName,
            this.Date,
            this.ScholarNo,
            this.StudentName,
            this.Noofday,
            this.payamount});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.Location = new System.Drawing.Point(30, 220);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Tomato;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Tomato;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.Size = new System.Drawing.Size(657, 173);
            this.dataGridView1.TabIndex = 238;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ScholarNo
            // 
            this.ScholarNo.HeaderText = "Scholar No.";
            this.ScholarNo.Name = "ScholarNo";
            // 
            // StudentName
            // 
            this.StudentName.HeaderText = "Student Name";
            this.StudentName.Name = "StudentName";
            this.StudentName.ReadOnly = true;
            // 
            // Noofday
            // 
            this.Noofday.HeaderText = "No.of Day";
            this.Noofday.Name = "Noofday";
            // 
            // payamount
            // 
            this.payamount.HeaderText = "Pay Amount";
            this.payamount.Name = "payamount";
            // 
            // GVSudentBookDeails
            // 
            this.GVSudentBookDeails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVSudentBookDeails.Location = new System.Drawing.Point(360, 64);
            this.GVSudentBookDeails.Name = "GVSudentBookDeails";
            this.GVSudentBookDeails.ReadOnly = true;
            this.GVSudentBookDeails.RowHeadersVisible = false;
            this.GVSudentBookDeails.Size = new System.Drawing.Size(240, 150);
            this.GVSudentBookDeails.TabIndex = 241;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(261, 493);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 15);
            this.label10.TabIndex = 240;
            this.label10.Text = "Recieved Amount";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(381, 492);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 239;
            this.textBox1.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(36, 494);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 15);
            this.label8.TabIndex = 237;
            this.label8.Text = "Paid Amount";
            // 
            // txtpaidamount
            // 
            this.txtpaidamount.Enabled = false;
            this.txtpaidamount.Location = new System.Drawing.Point(145, 489);
            this.txtpaidamount.Name = "txtpaidamount";
            this.txtpaidamount.ReadOnly = true;
            this.txtpaidamount.Size = new System.Drawing.Size(100, 20);
            this.txtpaidamount.TabIndex = 223;
            // 
            // txtpayamount
            // 
            this.txtpayamount.Location = new System.Drawing.Point(145, 454);
            this.txtpayamount.Name = "txtpayamount";
            this.txtpayamount.ReadOnly = true;
            this.txtpayamount.Size = new System.Drawing.Size(100, 20);
            this.txtpayamount.TabIndex = 234;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(36, 459);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 236;
            this.label7.Text = "Pay Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(292, 460);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 15);
            this.label6.TabIndex = 235;
            this.label6.Text = "No Of Day";
            // 
            // txtday
            // 
            this.txtday.Location = new System.Drawing.Point(379, 457);
            this.txtday.Name = "txtday";
            this.txtday.ReadOnly = true;
            this.txtday.Size = new System.Drawing.Size(100, 20);
            this.txtday.TabIndex = 233;
            // 
            // member_pic
            // 
            this.member_pic.Location = new System.Drawing.Point(606, 80);
            this.member_pic.Name = "member_pic";
            this.member_pic.Size = new System.Drawing.Size(81, 105);
            this.member_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.member_pic.TabIndex = 232;
            this.member_pic.TabStop = false;
            // 
            // Remark
            // 
            this.Remark.AutoSize = true;
            this.Remark.BackColor = System.Drawing.Color.Transparent;
            this.Remark.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remark.ForeColor = System.Drawing.Color.White;
            this.Remark.Location = new System.Drawing.Point(31, 413);
            this.Remark.Name = "Remark";
            this.Remark.Size = new System.Drawing.Size(57, 16);
            this.Remark.TabIndex = 231;
            this.Remark.Text = "Remark";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(111, 399);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(576, 41);
            this.txtRemark.TabIndex = 225;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(30, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 230;
            this.label9.Text = "Book Name";
            // 
            // txtBookName
            // 
            this.txtBookName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookName.Location = new System.Drawing.Point(144, 181);
            this.txtBookName.Name = "txtBookName";
            this.txtBookName.Size = new System.Drawing.Size(210, 21);
            this.txtBookName.TabIndex = 221;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(29, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 16);
            this.label5.TabIndex = 229;
            this.label5.Text = "Accession No";
            // 
            // txtBookNo
            // 
            this.txtBookNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookNo.Location = new System.Drawing.Point(144, 145);
            this.txtBookNo.Name = "txtBookNo";
            this.txtBookNo.Size = new System.Drawing.Size(210, 21);
            this.txtBookNo.TabIndex = 220;
            // 
            // txtStudentName
            // 
            this.txtStudentName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentName.Location = new System.Drawing.Point(471, 37);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(216, 21);
            this.txtStudentName.TabIndex = 224;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(355, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 226;
            this.label4.Text = "Student Name";
            // 
            // txtEnrollNo
            // 
            this.txtEnrollNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnrollNo.Location = new System.Drawing.Point(144, 73);
            this.txtEnrollNo.Name = "txtEnrollNo";
            this.txtEnrollNo.Size = new System.Drawing.Size(210, 21);
            this.txtEnrollNo.TabIndex = 216;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(29, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 222;
            this.label3.Text = "Enroll No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 219;
            this.label2.Text = "Book Barcode";
            // 
            // txtBookBarcodeNo
            // 
            this.txtBookBarcodeNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookBarcodeNo.Location = new System.Drawing.Point(144, 109);
            this.txtBookBarcodeNo.Name = "txtBookBarcodeNo";
            this.txtBookBarcodeNo.Size = new System.Drawing.Size(210, 21);
            this.txtBookBarcodeNo.TabIndex = 218;
            this.txtBookBarcodeNo.TextChanged += new System.EventHandler(this.txtBookBarcodeNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 217;
            this.label1.Text = "Student Barcode";
            // 
            // txtStudentBarCode
            // 
            this.txtStudentBarCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentBarCode.Location = new System.Drawing.Point(144, 37);
            this.txtStudentBarCode.Name = "txtStudentBarCode";
            this.txtStudentBarCode.Size = new System.Drawing.Size(210, 21);
            this.txtStudentBarCode.TabIndex = 215;
            this.txtStudentBarCode.TextChanged += new System.EventHandler(this.txtStudentBarCode_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(647, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 42);
            this.button1.TabIndex = 244;
            this.button1.Text = "E&xit";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.Image = global::SMS.Properties.Resources.save;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(575, 446);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(72, 42);
            this.btnsave.TabIndex = 243;
            this.btnsave.Text = "Ret&urn";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // FrmBookReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(716, 530);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.GVSudentBookDeails);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtpaidamount);
            this.Controls.Add(this.txtpayamount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtday);
            this.Controls.Add(this.member_pic);
            this.Controls.Add(this.Remark);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBookName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBookNo);
            this.Controls.Add(this.txtStudentName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEnrollNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBookBarcodeNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtStudentBarCode);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBookReturn";
            this.Text = "FrmBookReturn";
            this.Load += new System.EventHandler(this.FrmBookReturn_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBookReturn_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GVSudentBookDeails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.member_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BooktitleNo;
        private System.Windows.Forms.DataGridViewButtonColumn btndelete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScholarNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Noofday;
        private System.Windows.Forms.DataGridViewTextBoxColumn payamount;
        private System.Windows.Forms.DataGridView GVSudentBookDeails;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtpaidamount;
        private System.Windows.Forms.TextBox txtpayamount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtday;
        private System.Windows.Forms.PictureBox member_pic;
        private System.Windows.Forms.Label Remark;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBookName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBookNo;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEnrollNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBookBarcodeNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStudentBarCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsave;

    }
}