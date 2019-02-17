namespace SMS.Account
{
    partial class FrmAccount
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
            this.label11 = new System.Windows.Forms.Label();
            this.chksalary = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chksubledger = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.valcmbparent = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtacno = new System.Windows.Forms.TextBox();
            this.cmbnature = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.strcmbdrcr = new System.Windows.Forms.ComboBox();
            this.txtopenbalance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtpanno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.valcmbaccountgroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtaccountname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(1418, 833);
            this.textBox1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.textBox1.MaxLength = 30;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(362, 42);
            this.textBox1.TabIndex = 45;
            this.textBox1.Tag = "lf";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1050, 754);
            this.label11.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(220, 38);
            this.label11.TabIndex = 55;
            this.label11.Text = "Balance Date";
            // 
            // chksalary
            // 
            this.chksalary.AutoSize = true;
            this.chksalary.BackColor = System.Drawing.Color.Transparent;
            this.chksalary.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chksalary.ForeColor = System.Drawing.Color.White;
            this.chksalary.Location = new System.Drawing.Point(1929, 924);
            this.chksalary.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.chksalary.Name = "chksalary";
            this.chksalary.Size = new System.Drawing.Size(90, 37);
            this.chksalary.TabIndex = 43;
            this.chksalary.Tag = "issaldeduct";
            this.chksalary.Text = "No";
            this.chksalary.UseVisualStyleBackColor = false;
            this.chksalary.CheckedChanged += new System.EventHandler(this.chksalary_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(1526, 924);
            this.label10.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(372, 38);
            this.label10.TabIndex = 54;
            this.label10.Text = "Salary Deduction Head";
            // 
            // chksubledger
            // 
            this.chksubledger.AutoSize = true;
            this.chksubledger.BackColor = System.Drawing.Color.Transparent;
            this.chksubledger.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chksubledger.ForeColor = System.Drawing.Color.White;
            this.chksubledger.Location = new System.Drawing.Point(1418, 924);
            this.chksubledger.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.chksubledger.Name = "chksubledger";
            this.chksubledger.Size = new System.Drawing.Size(90, 37);
            this.chksubledger.TabIndex = 46;
            this.chksubledger.Tag = "subledger";
            this.chksubledger.Text = "No";
            this.chksubledger.UseVisualStyleBackColor = false;
            this.chksubledger.CheckedChanged += new System.EventHandler(this.chksubledger_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(1050, 926);
            this.label9.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(335, 38);
            this.label9.TabIndex = 53;
            this.label9.Text = "Sub Ledger Account";
            // 
            // valcmbparent
            // 
            this.valcmbparent.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbparent.ForeColor = System.Drawing.Color.Blue;
            this.valcmbparent.FormattingEnabled = true;
            this.valcmbparent.Location = new System.Drawing.Point(1418, 990);
            this.valcmbparent.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.valcmbparent.Name = "valcmbparent";
            this.valcmbparent.Size = new System.Drawing.Size(590, 43);
            this.valcmbparent.TabIndex = 48;
            this.valcmbparent.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1050, 998);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(256, 38);
            this.label8.TabIndex = 52;
            this.label8.Text = "Parent Account";
            // 
            // txtacno
            // 
            this.txtacno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtacno.ForeColor = System.Drawing.Color.Blue;
            this.txtacno.Location = new System.Drawing.Point(1776, 628);
            this.txtacno.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtacno.MaxLength = 30;
            this.txtacno.Name = "txtacno";
            this.txtacno.Size = new System.Drawing.Size(154, 42);
            this.txtacno.TabIndex = 51;
            this.txtacno.Tag = "accode";
            this.txtacno.Visible = false;
            // 
            // cmbnature
            // 
            this.cmbnature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbnature.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbnature.ForeColor = System.Drawing.Color.Blue;
            this.cmbnature.FormattingEnabled = true;
            this.cmbnature.Items.AddRange(new object[] {
            "Budgeted"});
            this.cmbnature.Location = new System.Drawing.Point(1418, 289);
            this.cmbnature.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.cmbnature.Name = "cmbnature";
            this.cmbnature.Size = new System.Drawing.Size(590, 43);
            this.cmbnature.TabIndex = 34;
            this.cmbnature.Tag = "budgtype";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1050, 296);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(268, 38);
            this.label7.TabIndex = 50;
            this.label7.Text = "Account Nature ";
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MM/yyyy";
            this.dtp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(1418, 750);
            this.dtp.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(250, 42);
            this.dtp.TabIndex = 42;
            this.dtp.Tag = "opdate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1050, 837);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 38);
            this.label6.TabIndex = 49;
            this.label6.Text = "L.F. No.";
            // 
            // strcmbdrcr
            // 
            this.strcmbdrcr.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strcmbdrcr.ForeColor = System.Drawing.Color.Blue;
            this.strcmbdrcr.FormattingEnabled = true;
            this.strcmbdrcr.Items.AddRange(new object[] {
            "Dr",
            "Cr"});
            this.strcmbdrcr.Location = new System.Drawing.Point(1690, 661);
            this.strcmbdrcr.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.strcmbdrcr.Name = "strcmbdrcr";
            this.strcmbdrcr.Size = new System.Drawing.Size(140, 43);
            this.strcmbdrcr.TabIndex = 40;
            this.strcmbdrcr.Tag = "acoptype";
            // 
            // txtopenbalance
            // 
            this.txtopenbalance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtopenbalance.ForeColor = System.Drawing.Color.Blue;
            this.txtopenbalance.Location = new System.Drawing.Point(1418, 663);
            this.txtopenbalance.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtopenbalance.MaxLength = 30;
            this.txtopenbalance.Name = "txtopenbalance";
            this.txtopenbalance.Size = new System.Drawing.Size(258, 42);
            this.txtopenbalance.TabIndex = 39;
            this.txtopenbalance.Tag = "acopbal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1050, 668);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 38);
            this.label5.TabIndex = 47;
            this.label5.Text = "Open. Balance";
            // 
            // txtpanno
            // 
            this.txtpanno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpanno.ForeColor = System.Drawing.Color.Blue;
            this.txtpanno.Location = new System.Drawing.Point(1418, 577);
            this.txtpanno.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtpanno.MaxLength = 30;
            this.txtpanno.Name = "txtpanno";
            this.txtpanno.Size = new System.Drawing.Size(590, 42);
            this.txtpanno.TabIndex = 38;
            this.txtpanno.Tag = "apanno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(1050, 583);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 38);
            this.label4.TabIndex = 44;
            this.label4.Text = "PAN No.";
            // 
            // txtaddress
            // 
            this.txtaddress.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaddress.ForeColor = System.Drawing.Color.Blue;
            this.txtaddress.Location = new System.Drawing.Point(1418, 378);
            this.txtaddress.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtaddress.MaxLength = 70;
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(590, 159);
            this.txtaddress.TabIndex = 36;
            this.txtaddress.Tag = "accaddress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1050, 378);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 38);
            this.label2.TabIndex = 41;
            this.label2.Text = "Address";
            // 
            // valcmbaccountgroup
            // 
            this.valcmbaccountgroup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbaccountgroup.ForeColor = System.Drawing.Color.Blue;
            this.valcmbaccountgroup.FormattingEnabled = true;
            this.valcmbaccountgroup.Location = new System.Drawing.Point(1418, 203);
            this.valcmbaccountgroup.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.valcmbaccountgroup.Name = "valcmbaccountgroup";
            this.valcmbaccountgroup.Size = new System.Drawing.Size(590, 43);
            this.valcmbaccountgroup.TabIndex = 33;
            this.valcmbaccountgroup.Tag = "actype";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1050, 211);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(264, 38);
            this.label3.TabIndex = 37;
            this.label3.Text = "Account Group ";
            // 
            // txtaccountname
            // 
            this.txtaccountname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaccountname.ForeColor = System.Drawing.Color.Blue;
            this.txtaccountname.Location = new System.Drawing.Point(1418, 124);
            this.txtaccountname.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtaccountname.MaxLength = 50;
            this.txtaccountname.Name = "txtaccountname";
            this.txtaccountname.Size = new System.Drawing.Size(590, 42);
            this.txtaccountname.TabIndex = 32;
            this.txtaccountname.Tag = "acname";
            this.txtaccountname.Validated += new System.EventHandler(this.txtaccountname_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1050, 130);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 38);
            this.label1.TabIndex = 35;
            this.label1.Text = "Account Name";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 35;
            this.listBox1.Location = new System.Drawing.Point(126, 124);
            this.listBox1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(876, 1054);
            this.listBox1.TabIndex = 31;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.Transparent;
            this.BtnSearch.BackgroundImage = global::SMS.Properties.Resources.searchbutton;
            this.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSearch.FlatAppearance.BorderSize = 0;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSearch.Location = new System.Drawing.Point(1058, 446);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(190, 110);
            this.BtnSearch.TabIndex = 57;
            this.BtnSearch.Text = " ";
            this.BtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // FrmAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.chksalary);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chksubledger);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.valcmbparent);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtacno);
            this.Controls.Add(this.cmbnature);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.strcmbdrcr);
            this.Controls.Add(this.txtopenbalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtpanno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.valcmbaccountgroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtaccountname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Name = "FrmAccount";
            this.Size = new System.Drawing.Size(2038, 1347);
            this.Load += new System.EventHandler(this.FrmAccount_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmAccount_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chksalary;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chksubledger;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox valcmbparent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtacno;
        private System.Windows.Forms.ComboBox cmbnature;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox strcmbdrcr;
        private System.Windows.Forms.TextBox txtopenbalance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtpanno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox valcmbaccountgroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtaccountname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button BtnSearch;
    }
}