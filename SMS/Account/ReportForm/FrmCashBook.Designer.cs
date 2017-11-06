namespace SMS.Account
{
    partial class FrmCashBook
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
            this.valcmbbank = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.valcmbcash = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // valcmbbank
            // 
            this.valcmbbank.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbbank.ForeColor = System.Drawing.Color.Blue;
            this.valcmbbank.FormattingEnabled = true;
            this.valcmbbank.Location = new System.Drawing.Point(218, 163);
            this.valcmbbank.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valcmbbank.Name = "valcmbbank";
            this.valcmbbank.Size = new System.Drawing.Size(347, 25);
            this.valcmbbank.TabIndex = 65;
            this.valcmbbank.Tag = "";
            this.valcmbbank.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(70, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 19);
            this.label3.TabIndex = 64;
            this.label3.Text = "Bank Account";
            this.label3.Visible = false;
            // 
            // valcmbcash
            // 
            this.valcmbcash.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbcash.ForeColor = System.Drawing.Color.Blue;
            this.valcmbcash.FormattingEnabled = true;
            this.valcmbcash.Location = new System.Drawing.Point(218, 110);
            this.valcmbcash.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valcmbcash.Name = "valcmbcash";
            this.valcmbcash.Size = new System.Drawing.Size(111, 25);
            this.valcmbcash.TabIndex = 63;
            this.valcmbcash.Tag = "";
            this.valcmbcash.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(70, 114);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 19);
            this.label2.TabIndex = 62;
            this.label2.Text = "Select Account";
            this.label2.Visible = false;
            // 
            // dtpto
            // 
            this.dtpto.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.CustomFormat = "dd/MM/yyyy";
            this.dtpto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpto.Location = new System.Drawing.Point(424, 108);
            this.dtpto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpto.Name = "dtpto";
            this.dtpto.Size = new System.Drawing.Size(141, 25);
            this.dtpto.TabIndex = 61;
            this.dtpto.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(385, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 19);
            this.label1.TabIndex = 60;
            this.label1.Text = "To ";
            this.label1.Visible = false;
            // 
            // dtpfrom
            // 
            this.dtpfrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrom.CustomFormat = "dd/MM/yyyy";
            this.dtpfrom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfrom.Location = new System.Drawing.Point(218, 64);
            this.dtpfrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.Size = new System.Drawing.Size(141, 25);
            this.dtpfrom.TabIndex = 59;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(70, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 58;
            this.label4.Text = "From Date";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.Black;
            this.btnOk.Location = new System.Drawing.Point(384, 59);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(181, 34);
            this.btnOk.TabIndex = 66;
            this.btnOk.Text = "&OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // FrmCashBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.valcmbbank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.valcmbcash);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpfrom);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmCashBook";
            this.Size = new System.Drawing.Size(569, 261);
            this.Load += new System.EventHandler(this.FrmCashBook_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmCashBook_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox valcmbbank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox valcmbcash;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOk;
    }
}