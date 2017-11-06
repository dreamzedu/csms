namespace SMS.Account
{
    partial class FrmAccountType
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
            this.txtfinal = new System.Windows.Forms.TextBox();
            this.txtactype = new System.Windows.Forms.TextBox();
            this.cmbfinalaccounttype = new System.Windows.Forms.ComboBox();
            this.txtaccountgroup = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtfinal
            // 
            this.txtfinal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfinal.ForeColor = System.Drawing.Color.Blue;
            this.txtfinal.Location = new System.Drawing.Point(776, 191);
            this.txtfinal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtfinal.MaxLength = 30;
            this.txtfinal.Name = "txtfinal";
            this.txtfinal.Size = new System.Drawing.Size(72, 25);
            this.txtfinal.TabIndex = 16;
            this.txtfinal.Tag = "acsidestr";
            this.txtfinal.Visible = false;
            // 
            // txtactype
            // 
            this.txtactype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtactype.ForeColor = System.Drawing.Color.Blue;
            this.txtactype.Location = new System.Drawing.Point(776, 147);
            this.txtactype.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtactype.MaxLength = 30;
            this.txtactype.Name = "txtactype";
            this.txtactype.Size = new System.Drawing.Size(72, 25);
            this.txtactype.TabIndex = 15;
            this.txtactype.Tag = "actype";
            this.txtactype.Visible = false;
            // 
            // cmbfinalaccounttype
            // 
            this.cmbfinalaccounttype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbfinalaccounttype.ForeColor = System.Drawing.Color.Blue;
            this.cmbfinalaccounttype.FormattingEnabled = true;
            this.cmbfinalaccounttype.Items.AddRange(new object[] {
            "Income",
            "Expenditure",
            "Assets",
            "Libility"});
            this.cmbfinalaccounttype.Location = new System.Drawing.Point(573, 106);
            this.cmbfinalaccounttype.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbfinalaccounttype.Name = "cmbfinalaccounttype";
            this.cmbfinalaccounttype.Size = new System.Drawing.Size(273, 25);
            this.cmbfinalaccounttype.TabIndex = 14;
            this.cmbfinalaccounttype.Tag = "acside";
            this.cmbfinalaccounttype.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbfinalaccounttype_KeyPress);
            // 
            // txtaccountgroup
            // 
            this.txtaccountgroup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtaccountgroup.ForeColor = System.Drawing.Color.Blue;
            this.txtaccountgroup.Location = new System.Drawing.Point(573, 61);
            this.txtaccountgroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtaccountgroup.MaxLength = 30;
            this.txtaccountgroup.Name = "txtaccountgroup";
            this.txtaccountgroup.Size = new System.Drawing.Size(273, 25);
            this.txtaccountgroup.TabIndex = 13;
            this.txtaccountgroup.Tag = "acdesc";
            this.txtaccountgroup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtaccountgroup_KeyPress);
            this.txtaccountgroup.Validated += new System.EventHandler(this.txtaccountgroup_Validated);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(63, 59);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(289, 259);
            this.listBox1.TabIndex = 12;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(404, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Final Account Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(404, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "Account Group ";
            // 
            // FrmAccountType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtfinal);
            this.Controls.Add(this.txtactype);
            this.Controls.Add(this.cmbfinalaccounttype);
            this.Controls.Add(this.txtaccountgroup);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmAccountType";
            this.Size = new System.Drawing.Size(905, 340);
            this.Load += new System.EventHandler(this.FrmAccountType_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmAccountType_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfinal;
        private System.Windows.Forms.TextBox txtactype;
        private System.Windows.Forms.ComboBox cmbfinalaccounttype;
        private System.Windows.Forms.TextBox txtaccountgroup;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}