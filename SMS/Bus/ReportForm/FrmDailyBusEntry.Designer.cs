namespace SMS.Bus.ReportForm
{
    partial class FrmDailyBusEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblBusNo = new System.Windows.Forms.Label();
            this.cmbBusNo = new System.Windows.Forms.ComboBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.BtnAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.label1.Location = new System.Drawing.Point(46, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Daily Bus Entry Detail";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(194, 88);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 31);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblBusNo
            // 
            this.lblBusNo.AutoSize = true;
            this.lblBusNo.BackColor = System.Drawing.Color.Transparent;
            this.lblBusNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBusNo.ForeColor = System.Drawing.Color.White;
            this.lblBusNo.Location = new System.Drawing.Point(20, 52);
            this.lblBusNo.Name = "lblBusNo";
            this.lblBusNo.Size = new System.Drawing.Size(56, 16);
            this.lblBusNo.TabIndex = 13;
            this.lblBusNo.Text = "Bus No.";
            // 
            // cmbBusNo
            // 
            this.cmbBusNo.FormattingEnabled = true;
            this.cmbBusNo.Location = new System.Drawing.Point(107, 50);
            this.cmbBusNo.Name = "cmbBusNo";
            this.cmbBusNo.Size = new System.Drawing.Size(174, 21);
            this.cmbBusNo.TabIndex = 12;
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(20, 88);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(87, 31);
            this.btnShow.TabIndex = 11;
            this.btnShow.Text = "Show ";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // BtnAll
            // 
            this.BtnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAll.Location = new System.Drawing.Point(107, 88);
            this.BtnAll.Name = "BtnAll";
            this.BtnAll.Size = new System.Drawing.Size(87, 31);
            this.BtnAll.TabIndex = 16;
            this.BtnAll.Text = "All";
            this.BtnAll.UseVisualStyleBackColor = true;
            this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
            // 
            // FrmDailyBusEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 140);
            this.Controls.Add(this.BtnAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblBusNo);
            this.Controls.Add(this.cmbBusNo);
            this.Controls.Add(this.btnShow);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDailyBusEntry";
            this.Text = "FrmDailyBusEntry";
            this.Load += new System.EventHandler(this.FrmDailyBusEntry_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDailyBusEntry_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblBusNo;
        private System.Windows.Forms.ComboBox cmbBusNo;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button BtnAll;
    }
}