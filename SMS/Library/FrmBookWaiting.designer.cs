namespace SMS.Library
{
    partial class FrmBookWaiting
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
            this.txtBookNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bookno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wstdno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStudntName = new System.Windows.Forms.TextBox();
            this.txtEnrollNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBookName = new System.Windows.Forms.ComboBox();
            this.txtStudentBarCode = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBookNo
            // 
            this.txtBookNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBookNo.Location = new System.Drawing.Point(499, 55);
            this.txtBookNo.Name = "txtBookNo";
            this.txtBookNo.Size = new System.Drawing.Size(163, 21);
            this.txtBookNo.TabIndex = 23;
            this.txtBookNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBookNo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(375, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Book Title No";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookno,
            this.wstdno,
            this.wdate,
            this.WNo});
            this.dataGridView1.Location = new System.Drawing.Point(26, 167);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(636, 210);
            this.dataGridView1.TabIndex = 20;
            // 
            // bookno
            // 
            this.bookno.DataPropertyName = "bookno";
            this.bookno.HeaderText = "Book No";
            this.bookno.Name = "bookno";
            this.bookno.ReadOnly = true;
            // 
            // wstdno
            // 
            this.wstdno.DataPropertyName = "wstdno";
            this.wstdno.HeaderText = "Enrollment No";
            this.wstdno.Name = "wstdno";
            this.wstdno.ReadOnly = true;
            // 
            // wdate
            // 
            this.wdate.DataPropertyName = "wdate";
            this.wdate.HeaderText = "Date";
            this.wdate.Name = "wdate";
            this.wdate.ReadOnly = true;
            // 
            // WNo
            // 
            this.WNo.DataPropertyName = "WNo";
            this.WNo.HeaderText = "Waiting No";
            this.WNo.Name = "WNo";
            // 
            // txtStudntName
            // 
            this.txtStudntName.BackColor = System.Drawing.SystemColors.Window;
            this.txtStudntName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudntName.Location = new System.Drawing.Point(153, 128);
            this.txtStudntName.Name = "txtStudntName";
            this.txtStudntName.ReadOnly = true;
            this.txtStudntName.Size = new System.Drawing.Size(205, 21);
            this.txtStudntName.TabIndex = 22;
            // 
            // txtEnrollNo
            // 
            this.txtEnrollNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEnrollNo.Location = new System.Drawing.Point(499, 92);
            this.txtEnrollNo.Name = "txtEnrollNo";
            this.txtEnrollNo.Size = new System.Drawing.Size(163, 21);
            this.txtEnrollNo.TabIndex = 13;
            this.txtEnrollNo.TextChanged += new System.EventHandler(this.txtEnrollNo_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(23, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Student Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(375, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "Student EnrollNo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(23, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Student BarCode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(23, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Book Name";
            // 
            // cmbBookName
            // 
            this.cmbBookName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBookName.FormattingEnabled = true;
            this.cmbBookName.Location = new System.Drawing.Point(153, 54);
            this.cmbBookName.Name = "cmbBookName";
            this.cmbBookName.Size = new System.Drawing.Size(205, 23);
            this.cmbBookName.TabIndex = 12;
            this.cmbBookName.SelectedIndexChanged += new System.EventHandler(this.cmbBookName_SelectedIndexChanged);
            this.cmbBookName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBookName_KeyPress);
            // 
            // txtStudentBarCode
            // 
            this.txtStudentBarCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStudentBarCode.Location = new System.Drawing.Point(153, 92);
            this.txtStudentBarCode.Name = "txtStudentBarCode";
            this.txtStudentBarCode.Size = new System.Drawing.Size(205, 21);
            this.txtStudentBarCode.TabIndex = 19;
            this.txtStudentBarCode.TextChanged += new System.EventHandler(this.txtStudentBarCode_TextChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label25.Location = new System.Drawing.Point(276, 4);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(132, 24);
            this.label25.TabIndex = 205;
            this.label25.Text = "Book Waiting";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(621, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 42);
            this.button1.TabIndex = 246;
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
            this.btnsave.Location = new System.Drawing.Point(559, 119);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(62, 42);
            this.btnsave.TabIndex = 245;
            this.btnsave.Text = "Sa&ve";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // FrmBookWaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 408);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtBookNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtStudntName);
            this.Controls.Add(this.txtEnrollNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbBookName);
            this.Controls.Add(this.txtStudentBarCode);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBookWaiting";
            this.Text = "FrmBookWaiting";
            this.Load += new System.EventHandler(this.FrmBookWaiting_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBookWaiting_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBookNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtStudntName;
        private System.Windows.Forms.TextBox txtEnrollNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBookName;
        private System.Windows.Forms.TextBox txtStudentBarCode;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookno;
        private System.Windows.Forms.DataGridViewTextBoxColumn wstdno;
        private System.Windows.Forms.DataGridViewTextBoxColumn wdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn WNo;
    }
}