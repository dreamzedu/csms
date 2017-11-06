namespace SMS
{
    partial class frmBankReceipt
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
            this.btnnew = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.txtChkNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtChkDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.valcmbbank = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtvchtype = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNarration = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.valcmbaccountgroup = new System.Windows.Forms.ComboBox();
            this.txtReceiptAmt = new System.Windows.Forms.TextBox();
            this.txtvoucherno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btndelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.White;
            this.btnnew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.Color.Black;
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnnew.Location = new System.Drawing.Point(13, 4);
            this.btnnew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(75, 28);
            this.btnnew.TabIndex = 0;
            this.btnnew.Text = "&New";
            this.btnnew.UseCompatibleTextRendering = true;
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            this.btnnew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.Black;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexit.Location = new System.Drawing.Point(475, 4);
            this.btnexit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(75, 28);
            this.btnexit.TabIndex = 6;
            this.btnexit.Text = "E&xit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            this.btnexit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(29, 133);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 19);
            this.label7.TabIndex = 77;
            this.label7.Text = "Receipt From";
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.White;
            this.btnprint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.Black;
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(398, 4);
            this.btnprint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 28);
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "&Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.White;
            this.btnedit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.Black;
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnedit.Location = new System.Drawing.Point(90, 4);
            this.btnedit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(75, 28);
            this.btnedit.TabIndex = 1;
            this.btnedit.Text = "&Edit";
            this.btnedit.UseCompatibleTextRendering = true;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            this.btnedit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // txtChkNo
            // 
            this.txtChkNo.Location = new System.Drawing.Point(193, 176);
            this.txtChkNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChkNo.MaxLength = 10;
            this.txtChkNo.Name = "txtChkNo";
            this.txtChkNo.Size = new System.Drawing.Size(177, 22);
            this.txtChkNo.TabIndex = 6;
            this.txtChkNo.Tag = "ChkNo";
            this.txtChkNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(460, 181);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 19);
            this.label11.TabIndex = 82;
            this.label11.Text = "Cheque Date";
            // 
            // txtChkDate
            // 
            this.txtChkDate.CustomFormat = "dd/MM/yyyy";
            this.txtChkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtChkDate.Location = new System.Drawing.Point(589, 181);
            this.txtChkDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChkDate.Name = "txtChkDate";
            this.txtChkDate.Size = new System.Drawing.Size(133, 22);
            this.txtChkDate.TabIndex = 7;
            this.txtChkDate.Tag = "ChkDate";
            this.txtChkDate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(25, 178);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 19);
            this.label10.TabIndex = 81;
            this.label10.Text = "Cheque No";
            // 
            // valcmbbank
            // 
            this.valcmbbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valcmbbank.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbbank.ForeColor = System.Drawing.Color.Black;
            this.valcmbbank.FormattingEnabled = true;
            this.valcmbbank.Location = new System.Drawing.Point(196, 91);
            this.valcmbbank.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valcmbbank.Name = "valcmbbank";
            this.valcmbbank.Size = new System.Drawing.Size(529, 28);
            this.valcmbbank.TabIndex = 2;
            this.valcmbbank.Tag = "";
            this.valcmbbank.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(980, 101);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(87, 22);
            this.textBox3.TabIndex = 9;
            this.textBox3.Tag = "ClearStatus";
            this.textBox3.Text = "No";
            this.textBox3.Visible = false;
            // 
            // txtvchtype
            // 
            this.txtvchtype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvchtype.ForeColor = System.Drawing.Color.Blue;
            this.txtvchtype.Location = new System.Drawing.Point(1027, 105);
            this.txtvchtype.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtvchtype.MaxLength = 10;
            this.txtvchtype.Name = "txtvchtype";
            this.txtvchtype.Size = new System.Drawing.Size(79, 25);
            this.txtvchtype.TabIndex = 59;
            this.txtvchtype.Tag = "vchtype";
            this.txtvchtype.Text = "BR";
            this.txtvchtype.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(991, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 19);
            this.label5.TabIndex = 76;
            this.label5.Text = "Voucher Type";
            this.label5.Visible = false;
            // 
            // txtNarration
            // 
            this.txtNarration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNarration.ForeColor = System.Drawing.Color.Black;
            this.txtNarration.Location = new System.Drawing.Point(193, 254);
            this.txtNarration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNarration.MaxLength = 100;
            this.txtNarration.Multiline = true;
            this.txtNarration.Name = "txtNarration";
            this.txtNarration.Size = new System.Drawing.Size(532, 59);
            this.txtNarration.TabIndex = 10;
            this.txtNarration.Tag = "remarks";
            this.txtNarration.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnsave.Location = new System.Drawing.Point(244, 4);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 28);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Sa&ve";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            this.btnsave.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // valcmbaccountgroup
            // 
            this.valcmbaccountgroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valcmbaccountgroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbaccountgroup.ForeColor = System.Drawing.Color.Black;
            this.valcmbaccountgroup.FormattingEnabled = true;
            this.valcmbaccountgroup.Location = new System.Drawing.Point(196, 133);
            this.valcmbaccountgroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valcmbaccountgroup.Name = "valcmbaccountgroup";
            this.valcmbaccountgroup.Size = new System.Drawing.Size(529, 28);
            this.valcmbaccountgroup.TabIndex = 3;
            this.valcmbaccountgroup.Tag = "";
            this.valcmbaccountgroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // txtReceiptAmt
            // 
            this.txtReceiptAmt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceiptAmt.ForeColor = System.Drawing.Color.Blue;
            this.txtReceiptAmt.Location = new System.Drawing.Point(193, 212);
            this.txtReceiptAmt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtReceiptAmt.MaxLength = 10;
            this.txtReceiptAmt.Name = "txtReceiptAmt";
            this.txtReceiptAmt.Size = new System.Drawing.Size(177, 25);
            this.txtReceiptAmt.TabIndex = 8;
            this.txtReceiptAmt.Tag = "";
            this.txtReceiptAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtReceiptAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            this.txtReceiptAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReceiptAmt_KeyPress);
            // 
            // txtvoucherno
            // 
            this.txtvoucherno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvoucherno.ForeColor = System.Drawing.Color.Blue;
            this.txtvoucherno.Location = new System.Drawing.Point(197, 50);
            this.txtvoucherno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtvoucherno.MaxLength = 30;
            this.txtvoucherno.Name = "txtvoucherno";
            this.txtvoucherno.ReadOnly = true;
            this.txtvoucherno.Size = new System.Drawing.Size(256, 25);
            this.txtvoucherno.TabIndex = 1;
            this.txtvoucherno.Tag = "vchno";
            this.txtvoucherno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            this.txtvoucherno.Validated += new System.EventHandler(this.txtvoucherno_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(25, 256);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 19);
            this.label4.TabIndex = 75;
            this.label4.Text = "Voucher Narration";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(25, 215);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 74;
            this.label3.Text = "Receipt Amt.";
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.White;
            this.btndelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.Black;
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btndelete.Location = new System.Drawing.Point(167, 4);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 28);
            this.btndelete.TabIndex = 2;
            this.btndelete.Text = "Dele&te";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            this.btndelete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 73;
            this.label2.Text = "Bank Account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(29, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 72;
            this.label1.Text = "Voucher No";
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.Black;
            this.btncancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btncancel.Location = new System.Drawing.Point(321, 4);
            this.btncancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 28);
            this.btncancel.TabIndex = 4;
            this.btncancel.Text = "&Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            this.btncancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(463, 57);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 71;
            this.label6.Text = "Voucher Date";
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MM/yyyy";
            this.dtp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(596, 50);
            this.dtp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(127, 25);
            this.dtp.TabIndex = 1;
            this.dtp.Tag = "vchdate";
            this.dtp.Enter += new System.EventHandler(this.dtp_Enter);
            this.dtp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtvoucherno_KeyDown);
            this.dtp.Validating += new System.ComponentModel.CancelEventHandler(this.dtp_Validating);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnnew);
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.btnedit);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Location = new System.Drawing.Point(96, 341);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 44);
            this.panel1.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(377, 214);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 19);
            this.label12.TabIndex = 97;
            this.label12.Text = "Rs.";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label25.Location = new System.Drawing.Point(278, -3);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(168, 29);
            this.label25.TabIndex = 207;
            this.label25.Text = "Bank Receipt";
            // 
            // frmBankReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SMS.Properties.Resources.img27;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(760, 425);
            this.ControlBox = false;
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtChkNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtChkDate);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.valcmbbank);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtvchtype);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNarration);
            this.Controls.Add(this.valcmbaccountgroup);
            this.Controls.Add(this.txtReceiptAmt);
            this.Controls.Add(this.txtvoucherno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtp);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBankReceipt";
            this.Text = "Bank Receipt";
            this.Load += new System.EventHandler(this.frmBankReceipt_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.TextBox txtChkNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker txtChkDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox valcmbbank;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtvchtype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNarration;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.ComboBox valcmbaccountgroup;
        private System.Windows.Forms.TextBox txtReceiptAmt;
        private System.Windows.Forms.TextBox txtvoucherno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label25;
    }
}