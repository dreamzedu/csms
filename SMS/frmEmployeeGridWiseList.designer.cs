namespace SMS
{
    partial class frmEmployeeGridWiseList
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Empno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emptype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pfamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rsa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splinctv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aleave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.balleave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.el = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.elbal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.encashleave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.da = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESIC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESICAmt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isactive = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnincESIC = new System.Windows.Forms.Button();
            this.txtIncESIC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnincpay = new System.Windows.Forms.Button();
            this.txtincbasicpay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnpfamt = new System.Windows.Forms.Button();
            this.txtincpf = new System.Windows.Forms.TextBox();
            this.btnokda = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtincda = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowDrop = true;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Empno,
            this.empname,
            this.emptype,
            this.Salary,
            this.pf,
            this.pfamt,
            this.lic,
            this.loan,
            this.rsa,
            this.splinctv,
            this.aleave,
            this.balleave,
            this.el,
            this.elbal,
            this.encashleave,
            this.da,
            this.daamt,
            this.hra,
            this.ESIC,
            this.ESICAmt,
            this.isactive});
            this.dgv.Location = new System.Drawing.Point(66, 61);
            this.dgv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(688, 404);
            this.dgv.TabIndex = 0;
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError_1);
            // 
            // Empno
            // 
            this.Empno.HeaderText = "Employee No.";
            this.Empno.Name = "Empno";
            this.Empno.ReadOnly = true;
            // 
            // empname
            // 
            this.empname.HeaderText = "Employee Name";
            this.empname.Name = "empname";
            this.empname.ReadOnly = true;
            // 
            // emptype
            // 
            this.emptype.HeaderText = "Employee Type";
            this.emptype.Name = "emptype";
            this.emptype.ReadOnly = true;
            // 
            // Salary
            // 
            this.Salary.HeaderText = "Basic Salary (Amt.)";
            this.Salary.Name = "Salary";
            this.Salary.ReadOnly = true;
            // 
            // pf
            // 
            this.pf.HeaderText = "PF (%)";
            this.pf.Name = "pf";
            this.pf.ReadOnly = true;
            // 
            // pfamt
            // 
            this.pfamt.HeaderText = "PF Amount";
            this.pfamt.Name = "pfamt";
            this.pfamt.ReadOnly = true;
            // 
            // lic
            // 
            this.lic.HeaderText = "LIC (Amt.)";
            this.lic.Name = "lic";
            this.lic.ReadOnly = true;
            // 
            // loan
            // 
            this.loan.HeaderText = "Loan (Amt.)";
            this.loan.Name = "loan";
            this.loan.ReadOnly = true;
            // 
            // rsa
            // 
            this.rsa.HeaderText = "Special Allowence";
            this.rsa.Name = "rsa";
            this.rsa.ReadOnly = true;
            // 
            // splinctv
            // 
            this.splinctv.HeaderText = "Special Intencive";
            this.splinctv.Name = "splinctv";
            this.splinctv.ReadOnly = true;
            // 
            // aleave
            // 
            this.aleave.HeaderText = "Allow Leave";
            this.aleave.Name = "aleave";
            this.aleave.ReadOnly = true;
            // 
            // balleave
            // 
            this.balleave.HeaderText = "Bal Leave";
            this.balleave.Name = "balleave";
            this.balleave.ReadOnly = true;
            // 
            // el
            // 
            this.el.HeaderText = "EL";
            this.el.Name = "el";
            this.el.ReadOnly = true;
            // 
            // elbal
            // 
            this.elbal.HeaderText = "EL Bal";
            this.elbal.Name = "elbal";
            this.elbal.ReadOnly = true;
            // 
            // encashleave
            // 
            this.encashleave.HeaderText = "EN Cash Leave";
            this.encashleave.Name = "encashleave";
            this.encashleave.ReadOnly = true;
            // 
            // da
            // 
            this.da.HeaderText = "DA (%)";
            this.da.Name = "da";
            this.da.ReadOnly = true;
            this.da.Width = 60;
            // 
            // daamt
            // 
            this.daamt.HeaderText = "DA Amount";
            this.daamt.Name = "daamt";
            this.daamt.ReadOnly = true;
            // 
            // hra
            // 
            this.hra.HeaderText = "HRA (Amt.)";
            this.hra.Name = "hra";
            this.hra.ReadOnly = true;
            this.hra.Width = 60;
            // 
            // ESIC
            // 
            this.ESIC.HeaderText = "ESIC (%)";
            this.ESIC.Name = "ESIC";
            this.ESIC.ReadOnly = true;
            // 
            // ESICAmt
            // 
            this.ESICAmt.HeaderText = "ESIC Amt.";
            this.ESICAmt.Name = "ESICAmt";
            this.ESICAmt.ReadOnly = true;
            // 
            // isactive
            // 
            this.isactive.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.isactive.HeaderText = "IsActive";
            this.isactive.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.isactive.Name = "isactive";
            this.isactive.Width = 60;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(600, 532);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(155, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Update";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(600, 579);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(155, 28);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnincESIC);
            this.groupBox1.Controls.Add(this.txtIncESIC);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnincpay);
            this.groupBox1.Controls.Add(this.txtincbasicpay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnpfamt);
            this.groupBox1.Controls.Add(this.txtincpf);
            this.groupBox1.Controls.Add(this.btnokda);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtincda);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(66, 472);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(503, 186);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnincESIC
            // 
            this.btnincESIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnincESIC.Location = new System.Drawing.Point(387, 98);
            this.btnincESIC.Margin = new System.Windows.Forms.Padding(4);
            this.btnincESIC.Name = "btnincESIC";
            this.btnincESIC.Size = new System.Drawing.Size(93, 31);
            this.btnincESIC.TabIndex = 5;
            this.btnincESIC.Text = "Ok";
            this.btnincESIC.UseVisualStyleBackColor = true;
            this.btnincESIC.Click += new System.EventHandler(this.btnincESIC_Click);
            // 
            // txtIncESIC
            // 
            this.txtIncESIC.Location = new System.Drawing.Point(257, 100);
            this.txtIncESIC.Margin = new System.Windows.Forms.Padding(4);
            this.txtIncESIC.Name = "txtIncESIC";
            this.txtIncESIC.Size = new System.Drawing.Size(96, 22);
            this.txtIncESIC.TabIndex = 4;
            this.txtIncESIC.Text = "0";
            this.txtIncESIC.Leave += new System.EventHandler(this.txtIncESIC_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Increament ESIC(%)";
            // 
            // btnincpay
            // 
            this.btnincpay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnincpay.Location = new System.Drawing.Point(387, 137);
            this.btnincpay.Margin = new System.Windows.Forms.Padding(4);
            this.btnincpay.Name = "btnincpay";
            this.btnincpay.Size = new System.Drawing.Size(93, 31);
            this.btnincpay.TabIndex = 7;
            this.btnincpay.Text = "Ok";
            this.btnincpay.UseVisualStyleBackColor = true;
            this.btnincpay.Click += new System.EventHandler(this.btnincpay_Click);
            // 
            // txtincbasicpay
            // 
            this.txtincbasicpay.Location = new System.Drawing.Point(257, 140);
            this.txtincbasicpay.Margin = new System.Windows.Forms.Padding(4);
            this.txtincbasicpay.Name = "txtincbasicpay";
            this.txtincbasicpay.Size = new System.Drawing.Size(96, 22);
            this.txtincbasicpay.TabIndex = 6;
            this.txtincbasicpay.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Increament Basic Pay (%)";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnpfamt
            // 
            this.btnpfamt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpfamt.Location = new System.Drawing.Point(387, 59);
            this.btnpfamt.Margin = new System.Windows.Forms.Padding(4);
            this.btnpfamt.Name = "btnpfamt";
            this.btnpfamt.Size = new System.Drawing.Size(93, 31);
            this.btnpfamt.TabIndex = 3;
            this.btnpfamt.Text = "Ok";
            this.btnpfamt.UseVisualStyleBackColor = true;
            this.btnpfamt.Click += new System.EventHandler(this.btnpfamt_Click);
            // 
            // txtincpf
            // 
            this.txtincpf.Location = new System.Drawing.Point(257, 59);
            this.txtincpf.Margin = new System.Windows.Forms.Padding(4);
            this.txtincpf.Name = "txtincpf";
            this.txtincpf.Size = new System.Drawing.Size(96, 22);
            this.txtincpf.TabIndex = 2;
            this.txtincpf.Text = "0";
            this.txtincpf.Leave += new System.EventHandler(this.txtincpf_Leave);
            // 
            // btnokda
            // 
            this.btnokda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnokda.Location = new System.Drawing.Point(387, 17);
            this.btnokda.Margin = new System.Windows.Forms.Padding(4);
            this.btnokda.Name = "btnokda";
            this.btnokda.Size = new System.Drawing.Size(93, 31);
            this.btnokda.TabIndex = 1;
            this.btnokda.Text = "Ok";
            this.btnokda.UseVisualStyleBackColor = true;
            this.btnokda.Click += new System.EventHandler(this.btnokda_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Increament PF(%)";
            // 
            // txtincda
            // 
            this.txtincda.Location = new System.Drawing.Point(257, 21);
            this.txtincda.Margin = new System.Windows.Forms.Padding(4);
            this.txtincda.Name = "txtincda";
            this.txtincda.Size = new System.Drawing.Size(96, 22);
            this.txtincda.TabIndex = 0;
            this.txtincda.Text = "0";
            this.txtincda.Enter += new System.EventHandler(this.txtincda_Enter);
            this.txtincda.Leave += new System.EventHandler(this.txtincda_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Increament DA(%)";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(600, 485);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(155, 28);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(66, 472);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(503, 186);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(387, 95);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnincESIC_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(257, 97);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(96, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "0";
            this.textBox1.Leave += new System.EventHandler(this.txtIncESIC_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Increament ESIC(%)";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(387, 134);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 25);
            this.button2.TabIndex = 7;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnincpay_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(257, 137);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(96, 22);
            this.textBox2.TabIndex = 6;
            this.textBox2.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(229, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Increament Basic Pay (%)";
            this.label7.Click += new System.EventHandler(this.label3_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(387, 55);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 25);
            this.button3.TabIndex = 3;
            this.button3.Text = "Ok";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnpfamt_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(257, 58);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(96, 22);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "0";
            this.textBox3.Leave += new System.EventHandler(this.txtincpf_Leave);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(387, 16);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 25);
            this.button4.TabIndex = 1;
            this.button4.Text = "Ok";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnokda_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(8, 60);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Increament PF(%)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(257, 18);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(96, 22);
            this.textBox4.TabIndex = 0;
            this.textBox4.Text = "0";
            this.textBox4.Enter += new System.EventHandler(this.txtincda_Enter);
            this.textBox4.Leave += new System.EventHandler(this.txtincda_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 21);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(164, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Increament DA(%)";
            // 
            // frmEmployeeGridWiseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgv);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEmployeeGridWiseList";
            this.Size = new System.Drawing.Size(835, 712);
            this.Tag = "1064";
            this.Load += new System.EventHandler(this.frmEmployeeGridWiseList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmEmployeeGridWiseList_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnokda;
        private System.Windows.Forms.TextBox txtincda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnpfamt;
        private System.Windows.Forms.TextBox txtincpf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnincpay;
        private System.Windows.Forms.TextBox txtincbasicpay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnincESIC;
        private System.Windows.Forms.TextBox txtIncESIC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn Empno;
        private System.Windows.Forms.DataGridViewTextBoxColumn empname;
        private System.Windows.Forms.DataGridViewTextBoxColumn emptype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salary;
        private System.Windows.Forms.DataGridViewTextBoxColumn pf;
        private System.Windows.Forms.DataGridViewTextBoxColumn pfamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn lic;
        private System.Windows.Forms.DataGridViewTextBoxColumn loan;
        private System.Windows.Forms.DataGridViewTextBoxColumn rsa;
        private System.Windows.Forms.DataGridViewTextBoxColumn splinctv;
        private System.Windows.Forms.DataGridViewTextBoxColumn aleave;
        private System.Windows.Forms.DataGridViewTextBoxColumn balleave;
        private System.Windows.Forms.DataGridViewTextBoxColumn el;
        private System.Windows.Forms.DataGridViewTextBoxColumn elbal;
        private System.Windows.Forms.DataGridViewTextBoxColumn encashleave;
        private System.Windows.Forms.DataGridViewTextBoxColumn da;
        private System.Windows.Forms.DataGridViewTextBoxColumn daamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn hra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESIC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESICAmt;
        private System.Windows.Forms.DataGridViewComboBoxColumn isactive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label9;
    }
}