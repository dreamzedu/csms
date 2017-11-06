namespace SMS.Account
{
    partial class FrmBankRec
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgbook = new System.Windows.Forms.DataGridView();
            this.accode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.narration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.valcmbbank = new System.Windows.Forms.ComboBox();
            this.txtsession = new System.Windows.Forms.TextBox();
            this.txtvchtype = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.valcmbaccountgroup = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtvoucherno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgbook
            // 
            this.dtgbook.AllowUserToAddRows = false;
            this.dtgbook.AllowUserToDeleteRows = false;
            this.dtgbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accode,
            this.acname,
            this.amount,
            this.narration});
            this.dtgbook.Location = new System.Drawing.Point(59, 188);
            this.dtgbook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.RowHeadersVisible = false;
            this.dtgbook.Size = new System.Drawing.Size(579, 215);
            this.dtgbook.TabIndex = 68;
            this.dtgbook.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtgbook_CellValidating);
            // 
            // accode
            // 
            this.accode.HeaderText = "accode";
            this.accode.MaxInputLength = 50;
            this.accode.Name = "accode";
            this.accode.Visible = false;
            // 
            // acname
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.acname.DefaultCellStyle = dataGridViewCellStyle1;
            this.acname.HeaderText = "Account Description";
            this.acname.Name = "acname";
            this.acname.ReadOnly = true;
            this.acname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.acname.Width = 220;
            // 
            // amount
            // 
            this.amount.HeaderText = "Amount";
            this.amount.Name = "amount";
            this.amount.Width = 70;
            // 
            // narration
            // 
            this.narration.HeaderText = "Narration";
            this.narration.MaxInputLength = 50;
            this.narration.Name = "narration";
            this.narration.Width = 140;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(59, 147);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 19);
            this.label7.TabIndex = 67;
            this.label7.Text = "Receipt From";
            // 
            // valcmbbank
            // 
            this.valcmbbank.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbbank.ForeColor = System.Drawing.Color.Blue;
            this.valcmbbank.FormattingEnabled = true;
            this.valcmbbank.Location = new System.Drawing.Point(221, 99);
            this.valcmbbank.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valcmbbank.Name = "valcmbbank";
            this.valcmbbank.Size = new System.Drawing.Size(415, 25);
            this.valcmbbank.TabIndex = 55;
            this.valcmbbank.Tag = "";
            // 
            // txtsession
            // 
            this.txtsession.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsession.ForeColor = System.Drawing.Color.Blue;
            this.txtsession.Location = new System.Drawing.Point(113, 515);
            this.txtsession.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtsession.MaxLength = 10;
            this.txtsession.Name = "txtsession";
            this.txtsession.Size = new System.Drawing.Size(44, 25);
            this.txtsession.TabIndex = 66;
            this.txtsession.Tag = "sessioncode";
            this.txtsession.Visible = false;
            // 
            // txtvchtype
            // 
            this.txtvchtype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvchtype.ForeColor = System.Drawing.Color.Blue;
            this.txtvchtype.Location = new System.Drawing.Point(64, 515);
            this.txtvchtype.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtvchtype.MaxLength = 10;
            this.txtvchtype.Name = "txtvchtype";
            this.txtvchtype.Size = new System.Drawing.Size(40, 25);
            this.txtvchtype.TabIndex = 65;
            this.txtvchtype.Tag = "vchtype";
            this.txtvchtype.Text = "BR";
            this.txtvchtype.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(60, 492);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 19);
            this.label5.TabIndex = 64;
            this.label5.Text = "Voucher Type";
            this.label5.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(221, 458);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox2.MaxLength = 100;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(415, 78);
            this.textBox2.TabIndex = 58;
            this.textBox2.Tag = "remark";
            // 
            // valcmbaccountgroup
            // 
            this.valcmbaccountgroup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbaccountgroup.ForeColor = System.Drawing.Color.Blue;
            this.valcmbaccountgroup.FormattingEnabled = true;
            this.valcmbaccountgroup.Location = new System.Drawing.Point(221, 144);
            this.valcmbaccountgroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valcmbaccountgroup.Name = "valcmbaccountgroup";
            this.valcmbaccountgroup.Size = new System.Drawing.Size(415, 25);
            this.valcmbaccountgroup.TabIndex = 56;
            this.valcmbaccountgroup.Tag = "";
            this.valcmbaccountgroup.Validated += new System.EventHandler(this.valcmbaccountgroup_Validated);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(505, 418);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(131, 25);
            this.textBox1.TabIndex = 57;
            this.textBox1.Tag = "";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtvoucherno
            // 
            this.txtvoucherno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtvoucherno.ForeColor = System.Drawing.Color.Blue;
            this.txtvoucherno.Location = new System.Drawing.Point(221, 56);
            this.txtvoucherno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtvoucherno.MaxLength = 30;
            this.txtvoucherno.Name = "txtvoucherno";
            this.txtvoucherno.ReadOnly = true;
            this.txtvoucherno.Size = new System.Drawing.Size(131, 25);
            this.txtvoucherno.TabIndex = 53;
            this.txtvoucherno.Tag = "vchno";
            this.txtvoucherno.Validated += new System.EventHandler(this.txtvoucherno_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(59, 458);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 19);
            this.label4.TabIndex = 63;
            this.label4.Text = "Voucher Narration";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(344, 421);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 19);
            this.label3.TabIndex = 62;
            this.label3.Text = "Receipt Amt.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(59, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 19);
            this.label2.TabIndex = 61;
            this.label2.Text = "Bank Account";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(59, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 60;
            this.label1.Text = "Voucher No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(376, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 19);
            this.label6.TabIndex = 59;
            this.label6.Text = "Voucher Date";
            // 
            // dtp
            // 
            this.dtp.CustomFormat = "dd/MM/yyyy";
            this.dtp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp.Location = new System.Drawing.Point(509, 56);
            this.dtp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(127, 25);
            this.dtp.TabIndex = 54;
            this.dtp.Tag = "vchdate";
            this.dtp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtp_KeyPress);
            // 
            // FrmBankRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dtgbook);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.valcmbbank);
            this.Controls.Add(this.txtsession);
            this.Controls.Add(this.txtvchtype);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.valcmbaccountgroup);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtvoucherno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtp);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBankRec";
            this.Size = new System.Drawing.Size(677, 633);
            this.Load += new System.EventHandler(this.FrmBankRec_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBankRec_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgbook;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox valcmbbank;
        private System.Windows.Forms.TextBox txtsession;
        private System.Windows.Forms.TextBox txtvchtype;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox valcmbaccountgroup;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtvoucherno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.DataGridViewTextBoxColumn accode;
        private System.Windows.Forms.DataGridViewTextBoxColumn acname;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn narration;
    }
}