namespace SMS
{
    partial class frmclasssetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtclassname = new System.Windows.Forms.TextBox();
            this.txtclasscode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.strcmbClassOrder = new System.Windows.Forms.ComboBox();
            this.CmbPrimaryGroup = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(311, 46);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(139, 180);
            this.listBox1.TabIndex = 100;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Class  Name";
            // 
            // txtclassname
            // 
            this.txtclassname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtclassname.Enabled = false;
            this.txtclassname.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclassname.ForeColor = System.Drawing.Color.Blue;
            this.txtclassname.Location = new System.Drawing.Point(112, 11);
            this.txtclassname.MaxLength = 20;
            this.txtclassname.Name = "txtclassname";
            this.txtclassname.Size = new System.Drawing.Size(124, 23);
            this.txtclassname.TabIndex = 1;
            this.txtclassname.Tag = "classname";
            this.txtclassname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtclassname_KeyPress_1);
            // 
            // txtclasscode
            // 
            this.txtclasscode.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtclasscode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclasscode.ForeColor = System.Drawing.Color.Blue;
            this.txtclasscode.Location = new System.Drawing.Point(364, 1);
            this.txtclasscode.MaxLength = 30;
            this.txtclasscode.Name = "txtclasscode";
            this.txtclasscode.Size = new System.Drawing.Size(39, 23);
            this.txtclasscode.TabIndex = 0;
            this.txtclasscode.TabStop = false;
            this.txtclasscode.Tag = "classcode";
            this.txtclasscode.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 19);
            this.label3.TabIndex = 102;
            this.label3.Text = "Class Order";
            // 
            // strcmbClassOrder
            // 
            this.strcmbClassOrder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strcmbClassOrder.ForeColor = System.Drawing.Color.Blue;
            this.strcmbClassOrder.FormattingEnabled = true;
            this.strcmbClassOrder.Location = new System.Drawing.Point(112, 80);
            this.strcmbClassOrder.Name = "strcmbClassOrder";
            this.strcmbClassOrder.Size = new System.Drawing.Size(80, 25);
            this.strcmbClassOrder.TabIndex = 205;
            this.strcmbClassOrder.Tag = "ClassOrder";
            // 
            // CmbPrimaryGroup
            // 
            this.CmbPrimaryGroup.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbPrimaryGroup.ForeColor = System.Drawing.Color.Blue;
            this.CmbPrimaryGroup.FormattingEnabled = true;
            this.CmbPrimaryGroup.Items.AddRange(new object[] {
            "Pre-Primary",
            "Non-Pre-Primary"});
            this.CmbPrimaryGroup.Location = new System.Drawing.Point(112, 46);
            this.CmbPrimaryGroup.Name = "CmbPrimaryGroup";
            this.CmbPrimaryGroup.Size = new System.Drawing.Size(124, 25);
            this.CmbPrimaryGroup.TabIndex = 207;
            this.CmbPrimaryGroup.Tag = "NonPrimary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 206;
            this.label4.Text = "Class Group";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.CmbPrimaryGroup);
            this.panel2.Controls.Add(this.txtclassname);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.strcmbClassOrder);
            this.panel2.Location = new System.Drawing.Point(50, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(246, 180);
            this.panel2.TabIndex = 208;
            // 
            // frmclasssetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtclasscode);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmclasssetup";
            this.Size = new System.Drawing.Size(540, 335);
            this.Tag = "9";
            this.Load += new System.EventHandler(this.frmclasssetup_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmclasssetup_Paint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtclassname;
        private System.Windows.Forms.TextBox txtclasscode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox strcmbClassOrder;
        private System.Windows.Forms.ComboBox CmbPrimaryGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
    }
}