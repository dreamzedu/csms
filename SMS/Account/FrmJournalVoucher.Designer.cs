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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtRefNo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgbook
            // 
            this.dtgbook.AllowUserToAddRows = false;
            this.dtgbook.AllowUserToDeleteRows = false;
            this.dtgbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acname,
            this.amount});
            this.dtgbook.Location = new System.Drawing.Point(91, 382);
            this.dtgbook.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.Size = new System.Drawing.Size(1541, 610);
            this.dtgbook.TabIndex = 57;
            this.dtgbook.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgbook_CellValidating);
            this.dtgbook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgbook_KeyDown);
            // 
            // acname
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.acname.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.strcmbdrcr.Location = new System.Drawing.Point(1486, 272);
            this.strcmbdrcr.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.strcmbdrcr.Name = "strcmbdrcr";
            this.strcmbdrcr.Size = new System.Drawing.Size(140, 43);
            this.strcmbdrcr.TabIndex = 54;
            this.strcmbdrcr.Tag = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1232, 279);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(225, 38);
            this.label7.TabIndex = 66;
            this.label7.Text = "Amount Type";
            // 
            // valcmbbank
            // 
            this.valcmbbank.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbbank.ForeColor = System.Drawing.Color.Blue;
            this.valcmbbank.FormattingEnabled = true;
            this.valcmbbank.Location = new System.Drawing.Point(403, 272);
            this.valcmbbank.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.valcmbbank.Name = "valcmbbank";
            this.valcmbbank.Size = new System.Drawing.Size(783, 43);
            this.valcmbbank.TabIndex = 53;
            this.valcmbbank.Tag = "";
            // 
            // txtsession
            // 
            this.txtsession.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsession.ForeColor = System.Drawing.Color.Blue;
            this.txtsession.Location = new System.Drawing.Point(992, 148);
            this.txtsession.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtsession.MaxLength = 10;
            this.txtsession.Name = "txtsession";
            this.txtsession.Size = new System.Drawing.Size(257, 42);
            this.txtsession.TabIndex = 65;
            this.txtsession.Tag = "sessioncode";
            this.txtsession.Visible = false;
            // 
            // txtvchtype
            // 
            this.txtvchtype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvchtype.ForeColor = System.Drawing.Color.Blue;
            this.txtvchtype.Location = new System.Drawing.Point(1006, 84);
            this.txtvchtype.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtvchtype.MaxLength = 10;
            this.txtvchtype.Name = "txtvchtype";
            this.txtvchtype.Size = new System.Drawing.Size(153, 42);
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
            this.label5.Location = new System.Drawing.Point(691, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 38);
            this.label5.TabIndex = 63;
            this.label5.Text = "Voucher Type";
            this.label5.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(310, 1081);
            this.textBox2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBox2.MaxLength = 100;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1316, 97);
            this.textBox2.TabIndex = 55;
            this.textBox2.Tag = "Remark";
            // 
            // txtvchamt
            // 
            this.txtvchamt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvchamt.ForeColor = System.Drawing.Color.Blue;
            this.txtvchamt.Location = new System.Drawing.Point(1368, 1007);
            this.txtvchamt.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtvchamt.MaxLength = 10;
            this.txtvchamt.Name = "txtvchamt";
            this.txtvchamt.ReadOnly = true;
            this.txtvchamt.Size = new System.Drawing.Size(257, 42);
            this.txtvchamt.TabIndex = 56;
            this.txtvchamt.TabStop = false;
            this.txtvchamt.Tag = "";
            this.txtvchamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtvoucherno
            // 
            this.txtvoucherno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvoucherno.ForeColor = System.Drawing.Color.Blue;
            this.txtvoucherno.Location = new System.Drawing.Point(363, 84);
            this.txtvoucherno.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtvoucherno.MaxLength = 30;
            this.txtvoucherno.Name = "txtvoucherno";
            this.txtvoucherno.ReadOnly = true;
            this.txtvoucherno.Size = new System.Drawing.Size(257, 42);
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
            this.label4.Location = new System.Drawing.Point(91, 1081);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 38);
            this.label4.TabIndex = 62;
            this.label4.Text = "Remarks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1040, 1011);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(226, 38);
            this.label3.TabIndex = 61;
            this.label3.Text = "Voucher Amt.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(83, 279);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 38);
            this.label2.TabIndex = 60;
            this.label2.Text = "Payment Account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(83, 89);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 38);
            this.label1.TabIndex = 59;
            this.label1.Text = "Voucher No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(83, 184);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 38);
            this.label6.TabIndex = 58;
            this.label6.Text = "Voucher Date";
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MM/yyyy";
            this.dtp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(376, 179);
            this.dtp.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(249, 42);
            this.dtp.TabIndex = 52;
            this.dtp.Tag = "vchdate";
            this.dtp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtp_KeyPress);
            // 
            // txtRefNo
            // 
            this.txtRefNo.Location = new System.Drawing.Point(99, 1135);
            this.txtRefNo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(135, 38);
            this.txtRefNo.TabIndex = 68;
            this.txtRefNo.Tag = "RefNo";
            this.txtRefNo.Visible = false;
            // 
            // FrmJournalVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtRefNo);
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
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FrmJournalVoucher";
            this.Size = new System.Drawing.Size(1677, 1381);
            this.Load += new System.EventHandler(this.FrmJournalVoucher_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmJournalVoucher_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.TextBox txtRefNo;
    }
}