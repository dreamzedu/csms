namespace SMS.Account
{
    partial class FrmJournalVoucher
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label41 = new System.Windows.Forms.Label();
            this.dtgbook = new System.Windows.Forms.DataGridView();
            this.acname = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strcmbdrcr = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.valcmbbank = new System.Windows.Forms.ComboBox();
            this.txtsession = new System.Windows.Forms.TextBox();
            this.txtvchtype = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtvchamt = new System.Windows.Forms.TextBox();
            this.txtvoucherno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Arial", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label41.Location = new System.Drawing.Point(232, 4);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(165, 24);
            this.label41.TabIndex = 19;
            this.label41.Text = "Journal Voucher";
            // 
            // dtgbook
            // 
            this.dtgbook.AllowUserToAddRows = false;
            this.dtgbook.AllowUserToDeleteRows = false;
            this.dtgbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acname,
            this.amount});
            this.dtgbook.Location = new System.Drawing.Point(27, 166);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.Size = new System.Drawing.Size(578, 256);
            this.dtgbook.TabIndex = 57;
            this.dtgbook.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgbook_CellValidating);
            this.dtgbook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgbook_KeyDown);
            // 
            // acname
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
            this.acname.DefaultCellStyle = dataGridViewCellStyle4;
            this.acname.HeaderText = "Account Description";
            this.acname.Name = "acname";
            this.acname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.acname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.acname.Width = 450;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.Width = 60;
            // 
            // strcmbdrcr
            // 
            this.strcmbdrcr.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strcmbdrcr.ForeColor = System.Drawing.Color.Blue;
            this.strcmbdrcr.FormattingEnabled = true;
            this.strcmbdrcr.Items.AddRange(new object[] {
            "Dr",
            "Cr"});
            this.strcmbdrcr.Location = new System.Drawing.Point(550, 120);
            this.strcmbdrcr.Name = "strcmbdrcr";
            this.strcmbdrcr.Size = new System.Drawing.Size(55, 23);
            this.strcmbdrcr.TabIndex = 54;
            this.strcmbdrcr.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(455, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 66;
            this.label7.Text = "Amount Type";
            // 
            // valcmbbank
            // 
            this.valcmbbank.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbbank.ForeColor = System.Drawing.Color.Blue;
            this.valcmbbank.FormattingEnabled = true;
            this.valcmbbank.Location = new System.Drawing.Point(144, 120);
            this.valcmbbank.Name = "valcmbbank";
            this.valcmbbank.Size = new System.Drawing.Size(296, 23);
            this.valcmbbank.TabIndex = 53;
            this.valcmbbank.Tag = "";
            // 
            // txtsession
            // 
            this.txtsession.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsession.ForeColor = System.Drawing.Color.Blue;
            this.txtsession.Location = new System.Drawing.Point(365, 68);
            this.txtsession.MaxLength = 10;
            this.txtsession.Name = "txtsession";
            this.txtsession.Size = new System.Drawing.Size(99, 21);
            this.txtsession.TabIndex = 65;
            this.txtsession.Tag = "sessioncode";
            this.txtsession.Visible = false;
            // 
            // txtvchtype
            // 
            this.txtvchtype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvchtype.ForeColor = System.Drawing.Color.Blue;
            this.txtvchtype.Location = new System.Drawing.Point(370, 41);
            this.txtvchtype.MaxLength = 10;
            this.txtvchtype.Name = "txtvchtype";
            this.txtvchtype.Size = new System.Drawing.Size(60, 21);
            this.txtvchtype.TabIndex = 64;
            this.txtvchtype.Tag = "vchtype";
            this.txtvchtype.Text = "JV";
            this.txtvchtype.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(252, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 63;
            this.label5.Text = "Voucher Type";
            this.label5.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(109, 459);
            this.textBox2.MaxLength = 100;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(496, 43);
            this.textBox2.TabIndex = 55;
            this.textBox2.Tag = "Remark";
            // 
            // txtvchamt
            // 
            this.txtvchamt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvchamt.ForeColor = System.Drawing.Color.Blue;
            this.txtvchamt.Location = new System.Drawing.Point(506, 428);
            this.txtvchamt.MaxLength = 10;
            this.txtvchamt.Name = "txtvchamt";
            this.txtvchamt.ReadOnly = true;
            this.txtvchamt.Size = new System.Drawing.Size(99, 21);
            this.txtvchamt.TabIndex = 56;
            this.txtvchamt.TabStop = false;
            this.txtvchamt.Tag = "";
            this.txtvchamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtvoucherno
            // 
            this.txtvoucherno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvoucherno.ForeColor = System.Drawing.Color.Blue;
            this.txtvoucherno.Location = new System.Drawing.Point(129, 41);
            this.txtvoucherno.MaxLength = 30;
            this.txtvoucherno.Name = "txtvoucherno";
            this.txtvoucherno.ReadOnly = true;
            this.txtvoucherno.Size = new System.Drawing.Size(99, 21);
            this.txtvoucherno.TabIndex = 51;
            this.txtvoucherno.Tag = "vchno";
            this.txtvoucherno.Validated += new System.EventHandler(this.txtvoucherno_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 459);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 62;
            this.label4.Text = "Remarks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(383, 430);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "Voucher Amt.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(24, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 60;
            this.label2.Text = "Payment Account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 59;
            this.label1.Text = "Voucher No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(24, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 16);
            this.label6.TabIndex = 58;
            this.label6.Text = "Voucher Date";
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MM/yyyy";
            this.dtp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(134, 81);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(96, 21);
            this.dtp.TabIndex = 52;
            this.dtp.Tag = "vchdate";
            this.dtp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtp_KeyPress);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Controls.Add(this.btnnew);
            this.panel3.Controls.Add(this.btnexit);
            this.panel3.Controls.Add(this.btnprint);
            this.panel3.Controls.Add(this.btnedit);
            this.panel3.Controls.Add(this.btndelete);
            this.panel3.Controls.Add(this.btncancel);
            this.panel3.Controls.Add(this.btnsave);
            this.panel3.Location = new System.Drawing.Point(98, 509);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(433, 48);
            this.panel3.TabIndex = 67;
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.White;
            this.btnnew.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.Color.Black;
            this.btnnew.Image = global::SMS.Properties.Resources.New;
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnew.Location = new System.Drawing.Point(1, 4);
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
            this.btnexit.Location = new System.Drawing.Point(388, 4);
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
            this.btnprint.Location = new System.Drawing.Point(330, 4);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(58, 42);
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "&Print";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.White;
            this.btnedit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.Black;
            this.btnedit.Image = global::SMS.Properties.Resources.edit;
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.Location = new System.Drawing.Point(67, 4);
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
            this.btndelete.Location = new System.Drawing.Point(131, 4);
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
            this.btncancel.Location = new System.Drawing.Point(261, 4);
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
            this.btnsave.Location = new System.Drawing.Point(201, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(60, 42);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Sa&ve";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(30, 482);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(53, 20);
            this.txtRefNo.TabIndex = 68;
            this.txtRefNo.Tag = "RefNo";
            this.txtRefNo.Visible = false;
            // 
            // FrmJournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(629, 579);
            this.Controls.Add(this.txtRefNo);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dtgbook);
            this.Controls.Add(this.strcmbdrcr);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.valcmbbank);
            this.Controls.Add(this.txtsession);
            this.Controls.Add(this.txtvchtype);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtvchamt);
            this.Controls.Add(this.txtvoucherno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.label41);
           // this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.KeyPreview = true;
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
            this.Name = "FrmJournalVoucher";
            this.Text = "FrmJournalVoucher";
            this.Load += new System.EventHandler(this.FrmJournalVoucher_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmJournalVoucher_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.DataGridView dtgbook;
        private System.Windows.Forms.DataGridViewComboBoxColumn acname;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.ComboBox strcmbdrcr;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox valcmbbank;
        private System.Windows.Forms.TextBox txtsession;
        private System.Windows.Forms.TextBox txtvchtype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtvchamt;
        private System.Windows.Forms.TextBox txtvoucherno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtRefNo;
    }
}