namespace SMS
{
    partial class frmuser
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
            this.lstbxUser = new System.Windows.Forms.ListBox();
            this.CmbUserRole = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtusercode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstbxUser
            // 
            this.lstbxUser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxUser.FormattingEnabled = true;
            this.lstbxUser.ItemHeight = 17;
            this.lstbxUser.Location = new System.Drawing.Point(377, 55);
            this.lstbxUser.Name = "lstbxUser";
            this.lstbxUser.Size = new System.Drawing.Size(195, 191);
            this.lstbxUser.TabIndex = 5;
            this.lstbxUser.TabStop = false;
            this.lstbxUser.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // CmbUserRole
            // 
            this.CmbUserRole.AllowDrop = true;
            this.CmbUserRole.Enabled = false;
            this.CmbUserRole.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUserRole.ForeColor = System.Drawing.Color.Blue;
            this.CmbUserRole.FormattingEnabled = true;
            this.CmbUserRole.Items.AddRange(new object[] {
            "Chief",
            "Operator"});
            this.CmbUserRole.Location = new System.Drawing.Point(114, 77);
            this.CmbUserRole.Name = "CmbUserRole";
            this.CmbUserRole.Size = new System.Drawing.Size(181, 25);
            this.CmbUserRole.TabIndex = 2;
            this.CmbUserRole.Tag = "userlevel";
            this.CmbUserRole.Text = "Chief";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 19);
            this.label6.TabIndex = 56;
            this.label6.Text = "User Level";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 19);
            this.label5.TabIndex = 55;
            this.label5.Text = "User Name";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtuser
            // 
            this.txtuser.Enabled = false;
            this.txtuser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.ForeColor = System.Drawing.Color.Blue;
            this.txtuser.Location = new System.Drawing.Point(113, 11);
            this.txtuser.MaxLength = 15;
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(181, 25);
            this.txtuser.TabIndex = 0;
            this.txtuser.Tag = "username";
            this.txtuser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtuser_KeyPress_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 54;
            this.label2.Text = "Password";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtpassword
            // 
            this.txtpassword.Enabled = false;
            this.txtpassword.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.ForeColor = System.Drawing.Color.Blue;
            this.txtpassword.Location = new System.Drawing.Point(114, 45);
            this.txtpassword.MaxLength = 15;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(181, 25);
            this.txtpassword.TabIndex = 1;
            this.txtpassword.Tag = "userpassword";
            // 
            // txtusercode
            // 
            this.txtusercode.Enabled = false;
            this.txtusercode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusercode.ForeColor = System.Drawing.Color.Blue;
            this.txtusercode.Location = new System.Drawing.Point(216, 110);
            this.txtusercode.MaxLength = 50;
            this.txtusercode.Name = "txtusercode";
            this.txtusercode.Size = new System.Drawing.Size(79, 25);
            this.txtusercode.TabIndex = 4;
            this.txtusercode.Tag = "usercode";
            this.txtusercode.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtpassword);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtusercode);
            this.panel2.Controls.Add(this.txtuser);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.CmbUserRole);
            this.panel2.Location = new System.Drawing.Point(54, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 188);
            this.panel2.TabIndex = 58;
            // 
            // frmuser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lstbxUser);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmuser";
            this.Size = new System.Drawing.Size(582, 330);
            this.Tag = "2";
            this.Load += new System.EventHandler(this.frmuser_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxUser;
        private System.Windows.Forms.ComboBox CmbUserRole;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtusercode;
        private System.Windows.Forms.Panel panel2;
    }
}