namespace SMS.Bus.ReportForm
{
    partial class FrmBusRegistration
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
            this.BtnAll = new System.Windows.Forms.Button();
            this.lblBusNo = new System.Windows.Forms.Label();
            this.cmbBusNo = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnAll
            // 
            this.BtnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAll.Location = new System.Drawing.Point(297, 108);
            this.BtnAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAll.Name = "BtnAll";
            this.BtnAll.Size = new System.Drawing.Size(116, 38);
            this.BtnAll.TabIndex = 22;
            this.BtnAll.Text = "All Bus";
            this.BtnAll.UseVisualStyleBackColor = true;
            this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
            // 
            // lblBusNo
            // 
            this.lblBusNo.AutoSize = true;
            this.lblBusNo.BackColor = System.Drawing.Color.Transparent;
            this.lblBusNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBusNo.ForeColor = System.Drawing.Color.White;
            this.lblBusNo.Location = new System.Drawing.Point(66, 64);
            this.lblBusNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusNo.Name = "lblBusNo";
            this.lblBusNo.Size = new System.Drawing.Size(72, 19);
            this.lblBusNo.TabIndex = 19;
            this.lblBusNo.Text = "Bus No.";
            // 
            // cmbBusNo
            // 
            this.cmbBusNo.FormattingEnabled = true;
            this.cmbBusNo.Location = new System.Drawing.Point(182, 62);
            this.cmbBusNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBusNo.Name = "cmbBusNo";
            this.cmbBusNo.Size = new System.Drawing.Size(231, 24);
            this.cmbBusNo.TabIndex = 18;
            this.cmbBusNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbBusNo_KeyPress);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(173, 108);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(116, 38);
            this.btnShow.TabIndex = 17;
            this.btnShow.Text = "Show ";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // FrmBusRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.BtnAll);
            this.Controls.Add(this.lblBusNo);
            this.Controls.Add(this.cmbBusNo);
            this.Controls.Add(this.btnShow);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBusRegistration";
            this.Size = new System.Drawing.Size(449, 195);
            this.Load += new System.EventHandler(this.FrmBusRegistration_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBusRegistration_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAll;
        private System.Windows.Forms.Label lblBusNo;
        private System.Windows.Forms.ComboBox cmbBusNo;
        private System.Windows.Forms.Button btnShow;
    }
}