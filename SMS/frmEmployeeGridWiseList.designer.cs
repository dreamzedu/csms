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
            this.cmbEmpType = new System.Windows.Forms.ComboBox();
            this.chkOnlyActive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.dgv.Location = new System.Drawing.Point(66, 83);
            this.dgv.Margin = new System.Windows.Forms.Padding(4);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1193, 404);
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
            this.btnOk.Location = new System.Drawing.Point(1104, 495);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(155, 28);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Update";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(66, 494);
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
            this.btnincESIC.Location = new System.Drawing.Point(387, 95);
            this.btnincESIC.Margin = new System.Windows.Forms.Padding(4);
            this.btnincESIC.Name = "btnincESIC";
            this.btnincESIC.Size = new System.Drawing.Size(93, 28);
            this.btnincESIC.TabIndex = 5;
            this.btnincESIC.Text = "Ok";
            this.btnincESIC.UseVisualStyleBackColor = true;
            this.btnincESIC.Click += new System.EventHandler(this.btnincESIC_Click);
            // 
            // txtIncESIC
            // 
            this.txtIncESIC.Location = new System.Drawing.Point(257, 99);
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
            this.btnincpay.Location = new System.Drawing.Point(387, 134);
            this.btnincpay.Margin = new System.Windows.Forms.Padding(4);
            this.btnincpay.Name = "btnincpay";
            this.btnincpay.Size = new System.Drawing.Size(93, 28);
            this.btnincpay.TabIndex = 7;
            this.btnincpay.Text = "Ok";
            this.btnincpay.UseVisualStyleBackColor = true;
            this.btnincpay.Click += new System.EventHandler(this.btnincpay_Click);
            // 
            // txtincbasicpay
            // 
            this.txtincbasicpay.Location = new System.Drawing.Point(257, 138);
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
            this.btnpfamt.Location = new System.Drawing.Point(387, 56);
            this.btnpfamt.Margin = new System.Windows.Forms.Padding(4);
            this.btnpfamt.Name = "btnpfamt";
            this.btnpfamt.Size = new System.Drawing.Size(93, 28);
            this.btnpfamt.TabIndex = 3;
            this.btnpfamt.Text = "Ok";
            this.btnpfamt.UseVisualStyleBackColor = true;
            this.btnpfamt.Click += new System.EventHandler(this.btnpfamt_Click);
            // 
            // txtincpf
            // 
            this.txtincpf.Location = new System.Drawing.Point(257, 60);
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
            this.btnokda.Size = new System.Drawing.Size(93, 28);
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
            this.btnReset.Location = new System.Drawing.Point(941, 495);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(155, 28);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbEmpType
            // 
            this.cmbEmpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpType.FormattingEnabled = true;
            this.cmbEmpType.Location = new System.Drawing.Point(66, 52);
            this.cmbEmpType.Name = "cmbEmpType";
            this.cmbEmpType.Size = new System.Drawing.Size(121, 24);
            this.cmbEmpType.TabIndex = 5;
            // 
            // chkOnlyActive
            // 
            this.chkOnlyActive.AutoSize = true;
            this.chkOnlyActive.Checked = true;
            this.chkOnlyActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyActive.Location = new System.Drawing.Point(223, 55);
            this.chkOnlyActive.Name = "chkOnlyActive";
            this.chkOnlyActive.Size = new System.Drawing.Size(207, 21);
            this.chkOnlyActive.TabIndex = 6;
            this.chkOnlyActive.Text = "Show only active employees";
            this.chkOnlyActive.UseVisualStyleBackColor = true;
            this.chkOnlyActive.CheckedChanged += new System.EventHandler(this.chkOnlyActive_CheckedChanged);
            // 
            // frmEmployeeGridWiseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.chkOnlyActive);
            this.Controls.Add(this.cmbEmpType);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgv);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEmployeeGridWiseList";
            this.Size = new System.Drawing.Size(1329, 712);
            this.Tag = "1064";
            this.Load += new System.EventHandler(this.frmEmployeeGridWiseList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmEmployeeGridWiseList_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnOk;
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
        private System.Windows.Forms.ComboBox cmbEmpType;
        private System.Windows.Forms.CheckBox chkOnlyActive;
    }
}