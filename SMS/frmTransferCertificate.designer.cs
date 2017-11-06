namespace SMS
{
    partial class frmTransferCertificate
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnShow = new System.Windows.Forms.Button();
            this.cmbsession = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtscholarno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCharecter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbPromotClass = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbAdmissionClass = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtresult = new System.Windows.Forms.TextBox();
            this.txtpercent = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(482, 64);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 22);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(348, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(64, 94);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(739, 292);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(723, 658);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(80, 28);
            this.btnShow.TabIndex = 9;
            this.btnShow.Text = "&Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmbsession
            // 
            this.cmbsession.FormattingEnabled = true;
            this.cmbsession.Location = new System.Drawing.Point(204, 62);
            this.cmbsession.Margin = new System.Windows.Forms.Padding(4);
            this.cmbsession.Name = "cmbsession";
            this.cmbsession.Size = new System.Drawing.Size(116, 24);
            this.cmbsession.TabIndex = 0;
            this.cmbsession.Leave += new System.EventHandler(this.cmbsession_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(66, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Session Name";
            // 
            // txtscholarno
            // 
            this.txtscholarno.Location = new System.Drawing.Point(329, 403);
            this.txtscholarno.Margin = new System.Windows.Forms.Padding(4);
            this.txtscholarno.Name = "txtscholarno";
            this.txtscholarno.Size = new System.Drawing.Size(203, 22);
            this.txtscholarno.TabIndex = 2;
            this.txtscholarno.Leave += new System.EventHandler(this.txtscholarno_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(66, 405);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Scholar No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(66, 468);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Bears Charecter";
            // 
            // txtCharecter
            // 
            this.txtCharecter.Location = new System.Drawing.Point(330, 465);
            this.txtCharecter.Margin = new System.Windows.Forms.Padding(4);
            this.txtCharecter.MaxLength = 20;
            this.txtCharecter.Name = "txtCharecter";
            this.txtCharecter.Size = new System.Drawing.Size(236, 22);
            this.txtCharecter.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(66, 437);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Reason For Leaving";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(330, 435);
            this.txtReason.Margin = new System.Windows.Forms.Padding(4);
            this.txtReason.MaxLength = 120;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(473, 22);
            this.txtReason.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(66, 559);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 26;
            this.label7.Text = "Issue  Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(332, 497);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(143, 22);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // cmbPromotClass
            // 
            this.cmbPromotClass.FormattingEnabled = true;
            this.cmbPromotClass.Location = new System.Drawing.Point(685, 527);
            this.cmbPromotClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbPromotClass.Name = "cmbPromotClass";
            this.cmbPromotClass.Size = new System.Drawing.Size(119, 24);
            this.cmbPromotClass.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(513, 529);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Promote Class";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(66, 497);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Admission Date";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(513, 597);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 20);
            this.label11.TabIndex = 33;
            this.label11.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(604, 598);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemarks.MaxLength = 120;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(202, 22);
            this.txtRemarks.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(513, 497);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(150, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "Admission Class";
            // 
            // cmbAdmissionClass
            // 
            this.cmbAdmissionClass.FormattingEnabled = true;
            this.cmbAdmissionClass.Location = new System.Drawing.Point(685, 495);
            this.cmbAdmissionClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbAdmissionClass.Name = "cmbAdmissionClass";
            this.cmbAdmissionClass.Size = new System.Drawing.Size(119, 24);
            this.cmbAdmissionClass.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(70, 600);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 20);
            this.label12.TabIndex = 37;
            this.label12.Text = "Result";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(70, 630);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(174, 20);
            this.label13.TabIndex = 38;
            this.label13.Text = "Attendance Percent";
            // 
            // txtresult
            // 
            this.txtresult.Location = new System.Drawing.Point(329, 597);
            this.txtresult.Margin = new System.Windows.Forms.Padding(4);
            this.txtresult.MaxLength = 20;
            this.txtresult.Name = "txtresult";
            this.txtresult.Size = new System.Drawing.Size(145, 22);
            this.txtresult.TabIndex = 39;
            // 
            // txtpercent
            // 
            this.txtpercent.Location = new System.Drawing.Point(329, 627);
            this.txtpercent.Margin = new System.Windows.Forms.Padding(4);
            this.txtpercent.MaxLength = 20;
            this.txtpercent.Name = "txtpercent";
            this.txtpercent.Size = new System.Drawing.Size(145, 22);
            this.txtpercent.TabIndex = 40;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker2.Location = new System.Drawing.Point(329, 557);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(143, 22);
            this.dateTimePicker2.TabIndex = 41;
            this.dateTimePicker2.Value = new System.DateTime(2016, 6, 17, 15, 10, 10, 0);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(66, 529);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 20);
            this.label14.TabIndex = 42;
            this.label14.Text = "Application Date";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.CustomFormat = "dd-MMM-yyyy";
            this.dateTimePicker3.Location = new System.Drawing.Point(329, 527);
            this.dateTimePicker3.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(143, 22);
            this.dateTimePicker3.TabIndex = 43;
            this.dateTimePicker3.Value = new System.DateTime(2016, 6, 17, 15, 10, 10, 0);
            // 
            // frmTransferCertificate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dateTimePicker3);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.txtpercent);
            this.Controls.Add(this.txtresult);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbAdmissionClass);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbPromotClass);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCharecter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtscholarno);
            this.Controls.Add(this.cmbsession);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTransferCertificate";
            this.Size = new System.Drawing.Size(851, 707);
            this.Load += new System.EventHandler(this.SearchByName_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmTransferCertificate_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ComboBox cmbsession;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtscholarno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCharecter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbPromotClass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbAdmissionClass;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtresult;
        private System.Windows.Forms.TextBox txtpercent;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
    }
}