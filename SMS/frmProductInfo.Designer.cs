namespace SMS
{
    partial class frmProductInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductInfo));
            this.lblProdName = new System.Windows.Forms.Label();
            this.lblProdVersion = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblProdName
            // 
            this.lblProdName.AutoSize = true;
            this.lblProdName.Location = new System.Drawing.Point(132, 17);
            this.lblProdName.Name = "lblProdName";
            this.lblProdName.Size = new System.Drawing.Size(46, 17);
            this.lblProdName.TabIndex = 0;
            this.lblProdName.Text = "CSMS";
            // 
            // lblProdVersion
            // 
            this.lblProdVersion.AutoSize = true;
            this.lblProdVersion.Location = new System.Drawing.Point(132, 50);
            this.lblProdVersion.Name = "lblProdVersion";
            this.lblProdVersion.Size = new System.Drawing.Size(28, 17);
            this.lblProdVersion.TabIndex = 1;
            this.lblProdVersion.Text = "5.6";
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(132, 83);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(220, 68);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "Dreamz Education Software Solutions Pvt Ltd";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Product Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Version:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Developed By:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Copyright:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(92, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(271, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "All Rights Reserved by Dreamz Education";
            // 
            // frmProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 218);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblProdVersion);
            this.Controls.Add(this.lblProdName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProductInfo";
            this.Text = "Product Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProdName;
        private System.Windows.Forms.Label lblProdVersion;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}