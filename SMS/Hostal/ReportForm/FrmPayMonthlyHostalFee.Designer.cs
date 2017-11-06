namespace SMS.Hostal.ReportForm
{
    partial class FrmPayMonthlyHostalFee
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
            this.btnDueFee = new System.Windows.Forms.Button();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.cmbHostelName = new System.Windows.Forms.ComboBox();
            this.lblHostel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDueFee
            // 
            this.btnDueFee.BackColor = System.Drawing.SystemColors.Control;
            this.btnDueFee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDueFee.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDueFee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDueFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDueFee.ForeColor = System.Drawing.Color.Black;
            this.btnDueFee.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDueFee.Location = new System.Drawing.Point(709, 101);
            this.btnDueFee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDueFee.Name = "btnDueFee";
            this.btnDueFee.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnDueFee.Size = new System.Drawing.Size(93, 37);
            this.btnDueFee.TabIndex = 196;
            this.btnDueFee.Text = "Ok";
            this.btnDueFee.UseVisualStyleBackColor = false;
            this.btnDueFee.Click += new System.EventHandler(this.btnDueFee_Click);
            // 
            // cmbMonth
            // 
            this.cmbMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "JAN",
            "FEB",
            "MAR",
            "APR",
            "MAY",
            "JUN",
            "JUL",
            "AUG",
            "SEP",
            "OCT",
            "NOV",
            "DEC"});
            this.cmbMonth.Location = new System.Drawing.Point(665, 56);
            this.cmbMonth.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(137, 28);
            this.cmbMonth.TabIndex = 195;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.BackColor = System.Drawing.Color.Transparent;
            this.lblMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.ForeColor = System.Drawing.Color.White;
            this.lblMonth.Location = new System.Drawing.Point(528, 61);
            this.lblMonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(119, 20);
            this.lblMonth.TabIndex = 198;
            this.lblMonth.Text = "Select Month";
            // 
            // cmbHostelName
            // 
            this.cmbHostelName.BackColor = System.Drawing.Color.White;
            this.cmbHostelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHostelName.FormattingEnabled = true;
            this.cmbHostelName.Location = new System.Drawing.Point(225, 56);
            this.cmbHostelName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbHostelName.Name = "cmbHostelName";
            this.cmbHostelName.Size = new System.Drawing.Size(293, 28);
            this.cmbHostelName.TabIndex = 194;
            // 
            // lblHostel
            // 
            this.lblHostel.AutoSize = true;
            this.lblHostel.BackColor = System.Drawing.Color.Transparent;
            this.lblHostel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblHostel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostel.ForeColor = System.Drawing.Color.White;
            this.lblHostel.Location = new System.Drawing.Point(69, 61);
            this.lblHostel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHostel.Name = "lblHostel";
            this.lblHostel.Size = new System.Drawing.Size(123, 20);
            this.lblHostel.TabIndex = 199;
            this.lblHostel.Text = "Select Hostel";
            // 
            // FrmPayMonthlyHostalFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblHostel);
            this.Controls.Add(this.cmbHostelName);
            this.Controls.Add(this.btnDueFee);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.cmbMonth);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmPayMonthlyHostalFee";
            this.Size = new System.Drawing.Size(844, 160);
            this.Load += new System.EventHandler(this.FrmPayMonthlyHostalFee_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmPayMonthlyHostalFee_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDueFee;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.ComboBox cmbHostelName;
        private System.Windows.Forms.Label lblHostel;
    }
}