namespace SMS.Hostal.ReportForm
{
    partial class FrmDayFee
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
            this.cmbHostelName = new System.Windows.Forms.ComboBox();
            this.lblHostelName = new System.Windows.Forms.Label();
            this.btnEveryDayFee = new System.Windows.Forms.Button();
            this.cmbDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbHostelName
            // 
            this.cmbHostelName.FormattingEnabled = true;
            this.cmbHostelName.Location = new System.Drawing.Point(186, 56);
            this.cmbHostelName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbHostelName.Name = "cmbHostelName";
            this.cmbHostelName.Size = new System.Drawing.Size(196, 24);
            this.cmbHostelName.TabIndex = 181;
            // 
            // lblHostelName
            // 
            this.lblHostelName.AutoSize = true;
            this.lblHostelName.BackColor = System.Drawing.Color.Transparent;
            this.lblHostelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostelName.ForeColor = System.Drawing.Color.White;
            this.lblHostelName.Location = new System.Drawing.Point(55, 59);
            this.lblHostelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHostelName.Name = "lblHostelName";
            this.lblHostelName.Size = new System.Drawing.Size(118, 20);
            this.lblHostelName.TabIndex = 186;
            this.lblHostelName.Text = "Hostel Name";
            // 
            // btnEveryDayFee
            // 
            this.btnEveryDayFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnEveryDayFee.ForeColor = System.Drawing.Color.Black;
            this.btnEveryDayFee.Location = new System.Drawing.Point(479, 89);
            this.btnEveryDayFee.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEveryDayFee.Name = "btnEveryDayFee";
            this.btnEveryDayFee.Size = new System.Drawing.Size(133, 37);
            this.btnEveryDayFee.TabIndex = 183;
            this.btnEveryDayFee.Text = "View";
            this.btnEveryDayFee.UseVisualStyleBackColor = true;
            this.btnEveryDayFee.Click += new System.EventHandler(this.btnEveryDayFee_Click);
            // 
            // cmbDate
            // 
            this.cmbDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDate.CustomFormat = "dd/MM/yyyy";
            this.cmbDate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.cmbDate.Location = new System.Drawing.Point(479, 56);
            this.cmbDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDate.Name = "cmbDate";
            this.cmbDate.Size = new System.Drawing.Size(132, 25);
            this.cmbDate.TabIndex = 182;
            this.cmbDate.Tag = "rcptdate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(383, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 185;
            this.label4.Text = "Fee Date";
            // 
            // FrmDayFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.cmbHostelName);
            this.Controls.Add(this.lblHostelName);
            this.Controls.Add(this.btnEveryDayFee);
            this.Controls.Add(this.cmbDate);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDayFee";
            this.Size = new System.Drawing.Size(616, 165);
            this.Load += new System.EventHandler(this.FrmDayFee_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDayFee_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbHostelName;
        private System.Windows.Forms.Label lblHostelName;
        private System.Windows.Forms.Button btnEveryDayFee;
        private System.Windows.Forms.DateTimePicker cmbDate;
        private System.Windows.Forms.Label label4;
    }
}