namespace SMS.Library
{
    partial class FrmBook
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
            this.dtpopendate = new System.Windows.Forms.DateTimePicker();
            this.BtnSRefresh = new System.Windows.Forms.Button();
            this.BtnAddSubject = new System.Windows.Forms.Button();
            this.BtnPRefresh = new System.Windows.Forms.Button();
            this.BtnAddPublisher = new System.Windows.Forms.Button();
            this.valcmbsubject = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.valcmbpublisher = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtbookno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbookopenqty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbookname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // dtpopendate
            // 
            this.dtpopendate.Location = new System.Drawing.Point(733, 464);
            this.dtpopendate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtpopendate.Name = "dtpopendate";
            this.dtpopendate.Size = new System.Drawing.Size(217, 38);
            this.dtpopendate.TabIndex = 186;
            this.dtpopendate.Tag = "opendate";
            this.dtpopendate.Visible = false;
            // 
            // BtnSRefresh
            // 
            this.BtnSRefresh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSRefresh.Location = new System.Drawing.Point(1067, 381);
            this.BtnSRefresh.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnSRefresh.Name = "BtnSRefresh";
            this.BtnSRefresh.Size = new System.Drawing.Size(69, 60);
            this.BtnSRefresh.TabIndex = 185;
            this.BtnSRefresh.Text = "R";
            this.BtnSRefresh.UseVisualStyleBackColor = true;
            this.BtnSRefresh.Click += new System.EventHandler(this.BtnSRefresh_Click);
            // 
            // BtnAddSubject
            // 
            this.BtnAddSubject.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSubject.Location = new System.Drawing.Point(997, 381);
            this.BtnAddSubject.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnAddSubject.Name = "BtnAddSubject";
            this.BtnAddSubject.Size = new System.Drawing.Size(69, 60);
            this.BtnAddSubject.TabIndex = 184;
            this.BtnAddSubject.Text = "..";
            this.BtnAddSubject.UseVisualStyleBackColor = true;
            this.BtnAddSubject.Click += new System.EventHandler(this.BtnAddSubject_Click);
            // 
            // BtnPRefresh
            // 
            this.BtnPRefresh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPRefresh.Location = new System.Drawing.Point(1067, 297);
            this.BtnPRefresh.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnPRefresh.Name = "BtnPRefresh";
            this.BtnPRefresh.Size = new System.Drawing.Size(69, 60);
            this.BtnPRefresh.TabIndex = 179;
            this.BtnPRefresh.Text = "R";
            this.BtnPRefresh.UseVisualStyleBackColor = true;
            this.BtnPRefresh.Click += new System.EventHandler(this.BtnPRefresh_Click);
            // 
            // BtnAddPublisher
            // 
            this.BtnAddPublisher.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddPublisher.Location = new System.Drawing.Point(997, 297);
            this.BtnAddPublisher.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnAddPublisher.Name = "BtnAddPublisher";
            this.BtnAddPublisher.Size = new System.Drawing.Size(69, 60);
            this.BtnAddPublisher.TabIndex = 178;
            this.BtnAddPublisher.Text = "..";
            this.BtnAddPublisher.UseVisualStyleBackColor = true;
            this.BtnAddPublisher.Click += new System.EventHandler(this.BtnAddPublisher_Click);
            // 
            // valcmbsubject
            // 
            this.valcmbsubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valcmbsubject.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbsubject.ForeColor = System.Drawing.Color.Blue;
            this.valcmbsubject.FormattingEnabled = true;
            this.valcmbsubject.Items.AddRange(new object[] {
            "Studing",
            "Terminate"});
            this.valcmbsubject.Location = new System.Drawing.Point(392, 383);
            this.valcmbsubject.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.valcmbsubject.Name = "valcmbsubject";
            this.valcmbsubject.Size = new System.Drawing.Size(596, 43);
            this.valcmbsubject.TabIndex = 166;
            this.valcmbsubject.Tag = "subjectcode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(77, 390);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 38);
            this.label7.TabIndex = 177;
            this.label7.Text = "Subject";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // valcmbpublisher
            // 
            this.valcmbpublisher.AllowDrop = true;
            this.valcmbpublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valcmbpublisher.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbpublisher.ForeColor = System.Drawing.Color.Blue;
            this.valcmbpublisher.FormattingEnabled = true;
            this.valcmbpublisher.Items.AddRange(new object[] {
            "Studing",
            "Terminate"});
            this.valcmbpublisher.Location = new System.Drawing.Point(392, 300);
            this.valcmbpublisher.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.valcmbpublisher.Name = "valcmbpublisher";
            this.valcmbpublisher.Size = new System.Drawing.Size(596, 43);
            this.valcmbpublisher.TabIndex = 165;
            this.valcmbpublisher.Tag = "publishcode";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(77, 307);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 38);
            this.label6.TabIndex = 176;
            this.label6.Text = "Publishers";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(77, 154);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 38);
            this.label5.TabIndex = 175;
            this.label5.Text = "Book sub Title";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Blue;
            this.textBox3.Location = new System.Drawing.Point(392, 149);
            this.textBox3.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(737, 42);
            this.textBox3.TabIndex = 163;
            this.textBox3.Tag = "booksubname";
            this.textBox3.Validated += new System.EventHandler(this.textBox3_Validated);
            // 
            // txtbookno
            // 
            this.txtbookno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbookno.ForeColor = System.Drawing.Color.Blue;
            this.txtbookno.Location = new System.Drawing.Point(973, 464);
            this.txtbookno.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtbookno.MaxLength = 20;
            this.txtbookno.Name = "txtbookno";
            this.txtbookno.Size = new System.Drawing.Size(151, 42);
            this.txtbookno.TabIndex = 174;
            this.txtbookno.Tag = "bookno";
            this.txtbookno.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(77, 231);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 38);
            this.label2.TabIndex = 173;
            this.label2.Text = "Author";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(392, 226);
            this.textBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBox2.MaxLength = 30;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(737, 42);
            this.textBox2.TabIndex = 164;
            this.textBox2.Tag = "author";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(392, 541);
            this.textBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(287, 42);
            this.textBox1.TabIndex = 168;
            this.textBox1.Tag = "rackno";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(77, 545);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 38);
            this.label4.TabIndex = 172;
            this.label4.Text = "Rack No.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtbookopenqty
            // 
            this.txtbookopenqty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbookopenqty.ForeColor = System.Drawing.Color.Blue;
            this.txtbookopenqty.Location = new System.Drawing.Point(392, 464);
            this.txtbookopenqty.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtbookopenqty.MaxLength = 20;
            this.txtbookopenqty.Name = "txtbookopenqty";
            this.txtbookopenqty.Size = new System.Drawing.Size(287, 42);
            this.txtbookopenqty.TabIndex = 167;
            this.txtbookopenqty.Tag = "openqty";
            this.txtbookopenqty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbookopenqty_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(77, 469);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 38);
            this.label3.TabIndex = 170;
            this.label3.Text = "Book Open Qty";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtbookname
            // 
            this.txtbookname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbookname.ForeColor = System.Drawing.Color.Blue;
            this.txtbookname.Location = new System.Drawing.Point(392, 73);
            this.txtbookname.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtbookname.MaxLength = 50;
            this.txtbookname.Name = "txtbookname";
            this.txtbookname.Size = new System.Drawing.Size(737, 42);
            this.txtbookname.TabIndex = 162;
            this.txtbookname.Tag = "bookname";
            this.txtbookname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbookname_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 78);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 38);
            this.label1.TabIndex = 169;
            this.label1.Text = "Book Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 35;
            this.listBox1.Location = new System.Drawing.Point(1217, 73);
            this.listBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(801, 634);
            this.listBox1.TabIndex = 171;
            this.listBox1.TabStop = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // FrmBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dtpopendate);
            this.Controls.Add(this.BtnSRefresh);
            this.Controls.Add(this.BtnAddSubject);
            this.Controls.Add(this.BtnPRefresh);
            this.Controls.Add(this.BtnAddPublisher);
            this.Controls.Add(this.valcmbsubject);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.valcmbpublisher);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtbookno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbookopenqty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtbookname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FrmBook";
            this.Size = new System.Drawing.Size(2056, 804);
            this.Load += new System.EventHandler(this.FrmBook_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBook_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnPRefresh;
        private System.Windows.Forms.Button BtnAddPublisher;
        private System.Windows.Forms.ComboBox valcmbsubject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox valcmbpublisher;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtbookno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbookopenqty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbookname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnSRefresh;
        private System.Windows.Forms.Button BtnAddSubject;
        private System.Windows.Forms.DateTimePicker dtpopendate;
    }
}