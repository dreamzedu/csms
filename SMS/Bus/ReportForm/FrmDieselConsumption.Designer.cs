namespace SMS.Bus.ReportForm
{
    partial class FrmDieselConsumption
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
            this.lblStart = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpLastDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.lblBusNo = new System.Windows.Forms.Label();
            this.cmbBusNo = new System.Windows.Forms.ComboBox();
            this.BtnAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.BackColor = System.Drawing.Color.Transparent;
            this.lblStart.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStart.ForeColor = System.Drawing.Color.White;
            this.lblStart.Location = new System.Drawing.Point(66, 104);
            this.lblStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(89, 19);
            this.lblStart.TabIndex = 15;
            this.lblStart.Text = "Start Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(406, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Last Date";
            // 
            // dtpLastDate
            // 
            this.dtpLastDate.CustomFormat = "dd/MM/yyyy";
            this.dtpLastDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpLastDate.Location = new System.Drawing.Point(539, 101);
            this.dtpLastDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpLastDate.Name = "dtpLastDate";
            this.dtpLastDate.Size = new System.Drawing.Size(173, 22);
            this.dtpLastDate.TabIndex = 11;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(200, 101);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(173, 22);
            this.dtpStartDate.TabIndex = 9;
            // 
            // btnShowReport
            // 
            this.btnShowReport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShowReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowReport.Location = new System.Drawing.Point(458, 146);
            this.btnShowReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(123, 33);
            this.btnShowReport.TabIndex = 12;
            this.btnShowReport.Text = "Show";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // lblBusNo
            // 
            this.lblBusNo.AutoSize = true;
            this.lblBusNo.BackColor = System.Drawing.Color.Transparent;
            this.lblBusNo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblBusNo.ForeColor = System.Drawing.Color.White;
            this.lblBusNo.Location = new System.Drawing.Point(66, 59);
            this.lblBusNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusNo.Name = "lblBusNo";
            this.lblBusNo.Size = new System.Drawing.Size(75, 19);
            this.lblBusNo.TabIndex = 10;
            this.lblBusNo.Text = "Bus NO.";
            // 
            // cmbBusNo
            // 
            this.cmbBusNo.FormattingEnabled = true;
            this.cmbBusNo.Location = new System.Drawing.Point(200, 57);
            this.cmbBusNo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBusNo.Name = "cmbBusNo";
            this.cmbBusNo.Size = new System.Drawing.Size(512, 24);
            this.cmbBusNo.TabIndex = 8;
            // 
            // BtnAll
            // 
            this.BtnAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAll.Location = new System.Drawing.Point(589, 146);
            this.BtnAll.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAll.Name = "BtnAll";
            this.BtnAll.Size = new System.Drawing.Size(123, 33);
            this.BtnAll.TabIndex = 17;
            this.BtnAll.Text = "Show All";
            this.BtnAll.UseVisualStyleBackColor = true;
            this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
            // 
            // FrmDieselConsumption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.BtnAll);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpLastDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.lblBusNo);
            this.Controls.Add(this.cmbBusNo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmDieselConsumption";
            this.Size = new System.Drawing.Size(719, 183);
            this.Load += new System.EventHandler(this.FrmDieselConsumption_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDieselConsumption_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpLastDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Label lblBusNo;
        private System.Windows.Forms.ComboBox cmbBusNo;
        private System.Windows.Forms.Button BtnAll;
    }
}