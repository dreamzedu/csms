namespace SMS
{
    partial class frmuserauth
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
            this.label45 = new System.Windows.Forms.Label();
            this.cmbUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstsubject = new System.Windows.Forms.CheckedListBox();
            this.chkListSubMenu = new System.Windows.Forms.CheckedListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.chkListMenu = new System.Windows.Forms.CheckedListBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnselect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCancelAll1 = new System.Windows.Forms.Button();
            this.btnCancelAll2 = new System.Windows.Forms.Button();
            this.btnASubMenucncl = new System.Windows.Forms.Button();
            this.btnASubAllSele = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.chkListASubMenu = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(227, 42);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(99, 19);
            this.label45.TabIndex = 156;
            this.label45.Text = "Select User";
            // 
            // cmbUser
            // 
            this.cmbUser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUser.ForeColor = System.Drawing.Color.Blue;
            this.cmbUser.FormattingEnabled = true;
            this.cmbUser.Location = new System.Drawing.Point(332, 40);
            this.cmbUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbUser.Name = "cmbUser";
            this.cmbUser.Size = new System.Drawing.Size(235, 25);
            this.cmbUser.TabIndex = 0;
            this.cmbUser.Tag = "";
            this.cmbUser.Validated += new System.EventHandler(this.valcmbclass_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 19);
            this.label1.TabIndex = 157;
            this.label1.Text = "Authorization for Menu Items";
            // 
            // lstsubject
            // 
            this.lstsubject.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstsubject.ForeColor = System.Drawing.Color.Blue;
            this.lstsubject.FormattingEnabled = true;
            this.lstsubject.Location = new System.Drawing.Point(53, 219);
            this.lstsubject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstsubject.Name = "lstsubject";
            this.lstsubject.Size = new System.Drawing.Size(91, 24);
            this.lstsubject.TabIndex = 160;
            // 
            // chkListSubMenu
            // 
            this.chkListSubMenu.FormattingEnabled = true;
            this.chkListSubMenu.Location = new System.Drawing.Point(343, 117);
            this.chkListSubMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkListSubMenu.Name = "chkListSubMenu";
            this.chkListSubMenu.Size = new System.Drawing.Size(268, 274);
            this.chkListSubMenu.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(593, 38);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 28);
            this.button3.TabIndex = 1;
            this.button3.Text = "Show";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chkListMenu
            // 
            this.chkListMenu.FormattingEnabled = true;
            this.chkListMenu.Location = new System.Drawing.Point(41, 117);
            this.chkListMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkListMenu.Name = "chkListMenu";
            this.chkListMenu.Size = new System.Drawing.Size(234, 274);
            this.chkListMenu.TabIndex = 3;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(279, 242);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 35);
            this.button5.TabIndex = 4;
            this.button5.Text = ">>";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(339, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(272, 19);
            this.label2.TabIndex = 168;
            this.label2.Text = "Authorization for Sub Menu Items";
            // 
            // btnselect
            // 
            this.btnselect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselect.Location = new System.Drawing.Point(343, 393);
            this.btnselect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(93, 28);
            this.btnselect.TabIndex = 5;
            this.btnselect.Text = "Select All";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(41, 393);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(93, 28);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCancelAll1
            // 
            this.btnCancelAll1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAll1.Location = new System.Drawing.Point(182, 393);
            this.btnCancelAll1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelAll1.Name = "btnCancelAll1";
            this.btnCancelAll1.Size = new System.Drawing.Size(93, 28);
            this.btnCancelAll1.TabIndex = 170;
            this.btnCancelAll1.Text = "Cancel All";
            this.btnCancelAll1.UseVisualStyleBackColor = true;
            this.btnCancelAll1.Click += new System.EventHandler(this.btnCancelAll1_Click);
            // 
            // btnCancelAll2
            // 
            this.btnCancelAll2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelAll2.Location = new System.Drawing.Point(518, 393);
            this.btnCancelAll2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelAll2.Name = "btnCancelAll2";
            this.btnCancelAll2.Size = new System.Drawing.Size(93, 28);
            this.btnCancelAll2.TabIndex = 171;
            this.btnCancelAll2.Text = "Cancel All";
            this.btnCancelAll2.UseVisualStyleBackColor = true;
            this.btnCancelAll2.Click += new System.EventHandler(this.btnCancelAll2_Click);
            // 
            // btnASubMenucncl
            // 
            this.btnASubMenucncl.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnASubMenucncl.Location = new System.Drawing.Point(854, 393);
            this.btnASubMenucncl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnASubMenucncl.Name = "btnASubMenucncl";
            this.btnASubMenucncl.Size = new System.Drawing.Size(93, 28);
            this.btnASubMenucncl.TabIndex = 176;
            this.btnASubMenucncl.Text = "Cancel All";
            this.btnASubMenucncl.UseVisualStyleBackColor = true;
            this.btnASubMenucncl.Click += new System.EventHandler(this.btnASubMenucncl_Click);
            // 
            // btnASubAllSele
            // 
            this.btnASubAllSele.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnASubAllSele.Location = new System.Drawing.Point(679, 393);
            this.btnASubAllSele.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnASubAllSele.Name = "btnASubAllSele";
            this.btnASubAllSele.Size = new System.Drawing.Size(93, 28);
            this.btnASubAllSele.TabIndex = 173;
            this.btnASubAllSele.Text = "Select All";
            this.btnASubAllSele.UseVisualStyleBackColor = true;
            this.btnASubAllSele.Click += new System.EventHandler(this.btnASubAllSele_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(675, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(272, 19);
            this.label4.TabIndex = 175;
            this.label4.Text = "Authorization for Sub Menu Items";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(615, 242);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(60, 35);
            this.button7.TabIndex = 172;
            this.button7.Text = ">>";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // chkListASubMenu
            // 
            this.chkListASubMenu.FormattingEnabled = true;
            this.chkListASubMenu.Location = new System.Drawing.Point(679, 117);
            this.chkListASubMenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkListASubMenu.Name = "chkListASubMenu";
            this.chkListASubMenu.Size = new System.Drawing.Size(268, 274);
            this.chkListASubMenu.TabIndex = 174;
            // 
            // frmuserauth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnASubMenucncl);
            this.Controls.Add(this.btnASubAllSele);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.chkListASubMenu);
            this.Controls.Add(this.btnCancelAll2);
            this.Controls.Add(this.btnCancelAll1);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnselect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.chkListMenu);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chkListSubMenu);
            this.Controls.Add(this.lstsubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.cmbUser);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmuserauth";
            this.Size = new System.Drawing.Size(962, 513);
            this.Tag = "3";
            this.Load += new System.EventHandler(this.frmuserauth_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmuserauth_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox cmbUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox lstsubject;
        private System.Windows.Forms.CheckedListBox chkListSubMenu;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckedListBox chkListMenu;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancelAll1;
        private System.Windows.Forms.Button btnCancelAll2;
        private System.Windows.Forms.Button btnASubMenucncl;
        private System.Windows.Forms.Button btnASubAllSele;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckedListBox chkListASubMenu;
    }
}