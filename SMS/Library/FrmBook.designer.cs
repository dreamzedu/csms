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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.BtnSRefresh = new System.Windows.Forms.Button();
            this.BtnAddSubject = new System.Windows.Forms.Button();
            this.dtpopendate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnPRefresh
            // 
            this.BtnPRefresh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPRefresh.Location = new System.Drawing.Point(727, 136);
            this.BtnPRefresh.Name = "BtnPRefresh";
            this.BtnPRefresh.Size = new System.Drawing.Size(26, 25);
            this.BtnPRefresh.TabIndex = 179;
            this.BtnPRefresh.Text = "R";
            this.BtnPRefresh.UseVisualStyleBackColor = true;
            this.BtnPRefresh.Click += new System.EventHandler(this.BtnPRefresh_Click);
            // 
            // BtnAddPublisher
            // 
            this.BtnAddPublisher.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddPublisher.Location = new System.Drawing.Point(701, 136);
            this.BtnAddPublisher.Name = "BtnAddPublisher";
            this.BtnAddPublisher.Size = new System.Drawing.Size(26, 25);
            this.BtnAddPublisher.TabIndex = 178;
            this.BtnAddPublisher.Text = "..";
            this.BtnAddPublisher.UseVisualStyleBackColor = true;
            this.BtnAddPublisher.Click += new System.EventHandler(this.BtnAddPublisher_Click);
            // 
            // valcmbsubject
            // 
            this.valcmbsubject.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbsubject.ForeColor = System.Drawing.Color.Blue;
            this.valcmbsubject.FormattingEnabled = true;
            this.valcmbsubject.Items.AddRange(new object[] {
            "Studing",
            "Terminate"});
            this.valcmbsubject.Location = new System.Drawing.Point(474, 172);
            this.valcmbsubject.Name = "valcmbsubject";
            this.valcmbsubject.Size = new System.Drawing.Size(226, 23);
            this.valcmbsubject.TabIndex = 166;
            this.valcmbsubject.Tag = "subjectcode";
            this.valcmbsubject.Text = "Arts";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(356, 175);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 177;
            this.label7.Text = "Subject";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // valcmbpublisher
            // 
            this.valcmbpublisher.AllowDrop = true;
            this.valcmbpublisher.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbpublisher.ForeColor = System.Drawing.Color.Blue;
            this.valcmbpublisher.FormattingEnabled = true;
            this.valcmbpublisher.Items.AddRange(new object[] {
            "Studing",
            "Terminate"});
            this.valcmbpublisher.Location = new System.Drawing.Point(474, 137);
            this.valcmbpublisher.Name = "valcmbpublisher";
            this.valcmbpublisher.Size = new System.Drawing.Size(226, 23);
            this.valcmbpublisher.TabIndex = 165;
            this.valcmbpublisher.Tag = "publishcode";
            this.valcmbpublisher.Text = "Arts";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(356, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
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
            this.label5.Location = new System.Drawing.Point(356, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 175;
            this.label5.Text = "Book sub Title";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Blue;
            this.textBox3.Location = new System.Drawing.Point(474, 74);
            this.textBox3.MaxLength = 50;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(279, 21);
            this.textBox3.TabIndex = 163;
            this.textBox3.Tag = "booksubname";
            this.textBox3.Validated += new System.EventHandler(this.textBox3_Validated);
            // 
            // txtbookno
            // 
            this.txtbookno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbookno.ForeColor = System.Drawing.Color.Blue;
            this.txtbookno.Location = new System.Drawing.Point(692, 206);
            this.txtbookno.MaxLength = 20;
            this.txtbookno.Name = "txtbookno";
            this.txtbookno.Size = new System.Drawing.Size(59, 21);
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
            this.label2.Location = new System.Drawing.Point(356, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 173;
            this.label2.Text = "Author";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(474, 106);
            this.textBox2.MaxLength = 30;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(279, 21);
            this.textBox2.TabIndex = 164;
            this.textBox2.Tag = "author";
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(474, 238);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(110, 21);
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
            this.label4.Location = new System.Drawing.Point(356, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 172;
            this.label4.Text = "Rack No.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtbookopenqty
            // 
            this.txtbookopenqty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbookopenqty.ForeColor = System.Drawing.Color.Blue;
            this.txtbookopenqty.Location = new System.Drawing.Point(474, 206);
            this.txtbookopenqty.MaxLength = 20;
            this.txtbookopenqty.Name = "txtbookopenqty";
            this.txtbookopenqty.Size = new System.Drawing.Size(110, 21);
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
            this.label3.Location = new System.Drawing.Point(356, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 170;
            this.label3.Text = "Book Open Qty";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtbookname
            // 
            this.txtbookname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbookname.ForeColor = System.Drawing.Color.Blue;
            this.txtbookname.Location = new System.Drawing.Point(474, 42);
            this.txtbookname.MaxLength = 50;
            this.txtbookname.Name = "txtbookname";
            this.txtbookname.Size = new System.Drawing.Size(279, 21);
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
            this.label1.Location = new System.Drawing.Point(356, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 169;
            this.label1.Text = "Book Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(17, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(303, 274);
            this.listBox1.TabIndex = 171;
            this.listBox1.TabStop = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(243)))), ((int)(((byte)(222)))));
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnnew);
            this.panel3.Controls.Add(this.btnexit);
            this.panel3.Controls.Add(this.btnprint);
            this.panel3.Controls.Add(this.btnedit);
            this.panel3.Controls.Add(this.btndelete);
            this.panel3.Controls.Add(this.btncancel);
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Location = new System.Drawing.Point(326, 274);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(426, 42);
            this.panel3.TabIndex = 183;
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.White;
            this.btnnew.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.Color.Black;
            this.btnnew.Image = global::SMS.Properties.Resources.New;
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnew.Location = new System.Drawing.Point(-2, -2);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(66, 42);
            this.btnnew.TabIndex = 3;
            this.btnnew.Text = "&New";
            this.btnnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnew.UseCompatibleTextRendering = true;
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.Black;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexit.Location = new System.Drawing.Point(385, -2);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(40, 42);
            this.btnexit.TabIndex = 1;
            this.btnexit.Text = "E&xit";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.White;
            this.btnprint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.Black;
            this.btnprint.Image = global::SMS.Properties.Resources.Print1;
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(327, -2);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(58, 42);
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "&Print";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.White;
            this.btnedit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.Black;
            this.btnedit.Image = global::SMS.Properties.Resources.edit;
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.Location = new System.Drawing.Point(64, -2);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(64, 42);
            this.btnedit.TabIndex = 4;
            this.btnedit.Text = "E&dit";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnedit.UseCompatibleTextRendering = true;
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.White;
            this.btndelete.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.Black;
            this.btndelete.Image = global::SMS.Properties.Resources.Delete1;
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.Location = new System.Drawing.Point(128, -2);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(70, 42);
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Dele&te";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndelete.UseVisualStyleBackColor = false;
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.Black;
            this.btncancel.Image = global::SMS.Properties.Resources.cancel;
            this.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancel.Location = new System.Drawing.Point(258, -2);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(69, 42);
            this.btncancel.TabIndex = 2;
            this.btncancel.Text = "&Cancel";
            this.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.Image = global::SMS.Properties.Resources.save;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(198, -2);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(60, 42);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Sa&ve";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // BtnSRefresh
            // 
            this.BtnSRefresh.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSRefresh.Location = new System.Drawing.Point(727, 171);
            this.BtnSRefresh.Name = "BtnSRefresh";
            this.BtnSRefresh.Size = new System.Drawing.Size(26, 25);
            this.BtnSRefresh.TabIndex = 185;
            this.BtnSRefresh.Text = "R";
            this.BtnSRefresh.UseVisualStyleBackColor = true;
            this.BtnSRefresh.Click += new System.EventHandler(this.BtnSRefresh_Click);
            // 
            // BtnAddSubject
            // 
            this.BtnAddSubject.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddSubject.Location = new System.Drawing.Point(701, 171);
            this.BtnAddSubject.Name = "BtnAddSubject";
            this.BtnAddSubject.Size = new System.Drawing.Size(26, 25);
            this.BtnAddSubject.TabIndex = 184;
            this.BtnAddSubject.Text = "..";
            this.BtnAddSubject.UseVisualStyleBackColor = true;
            this.BtnAddSubject.Click += new System.EventHandler(this.BtnAddSubject_Click);
            // 
            // dtpopendate
            // 
            this.dtpopendate.Location = new System.Drawing.Point(602, 206);
            this.dtpopendate.Name = "dtpopendate";
            this.dtpopendate.Size = new System.Drawing.Size(84, 20);
            this.dtpopendate.TabIndex = 186;
            this.dtpopendate.Tag = "opendate";
            this.dtpopendate.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(332, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 19);
            this.label8.TabIndex = 180;
            this.label8.Text = "Book Details";
            // 
            // FrmBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(771, 337);
            this.Controls.Add(this.dtpopendate);
            this.Controls.Add(this.BtnSRefresh);
            this.Controls.Add(this.BtnAddSubject);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label8);
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
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBook";
            this.Text = "FrmBook";
            this.Load += new System.EventHandler(this.FrmBook_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBook_Paint);
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button BtnSRefresh;
        private System.Windows.Forms.Button BtnAddSubject;
        private System.Windows.Forms.DateTimePicker dtpopendate;
        private System.Windows.Forms.Label label8;
    }
}