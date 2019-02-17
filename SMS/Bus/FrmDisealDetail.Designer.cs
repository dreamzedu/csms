namespace SMS.Bus
{
    partial class FrmDisealDetail
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
            this.DTPCurrent = new System.Windows.Forms.DateTimePicker();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.DTP1 = new System.Windows.Forms.DateTimePicker();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.txtBusReading = new System.Windows.Forms.TextBox();
            this.lblBusReading = new System.Windows.Forms.Label();
            this.txtDieselRate = new System.Windows.Forms.TextBox();
            this.lblDieselRate = new System.Windows.Forms.Label();
            this.lblDieselPuringDate = new System.Windows.Forms.Label();
            this.txtPuredDiesel = new System.Windows.Forms.TextBox();
            this.lblPuresDiesel = new System.Windows.Forms.Label();
            this.txtDieselAvailable = new System.Windows.Forms.TextBox();
            this.lblAvailableDiesel = new System.Windows.Forms.Label();
            this.cmbBusNo = new System.Windows.Forms.ComboBox();
            this.lblBusNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // DTPCurrent
            // 
            this.DTPCurrent.CustomFormat = "dd/MM/yyyy";
            this.DTPCurrent.Enabled = false;
            this.DTPCurrent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTPCurrent.Location = new System.Drawing.Point(516, 663);
            this.DTPCurrent.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.DTPCurrent.Name = "DTPCurrent";
            this.DTPCurrent.Size = new System.Drawing.Size(284, 38);
            this.DTPCurrent.TabIndex = 29;
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDate.ForeColor = System.Drawing.Color.White;
            this.lblCurrentDate.Location = new System.Drawing.Point(108, 668);
            this.lblCurrentDate.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(182, 38);
            this.lblCurrentDate.TabIndex = 38;
            this.lblCurrentDate.Text = "Entry Date";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(520, 581);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.ReadOnly = true;
            this.txtAmount.Size = new System.Drawing.Size(284, 38);
            this.txtAmount.TabIndex = 28;
            this.txtAmount.Text = "0.0";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.White;
            this.lblAmount.Location = new System.Drawing.Point(108, 587);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(135, 38);
            this.lblAmount.TabIndex = 37;
            this.lblAmount.Text = "Amount";
            // 
            // DTP1
            // 
            this.DTP1.CustomFormat = "dd/MM/yyyy";
            this.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP1.Location = new System.Drawing.Point(520, 265);
            this.DTP1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.DTP1.Name = "DTP1";
            this.DTP1.Size = new System.Drawing.Size(282, 38);
            this.DTP1.TabIndex = 24;
            // 
            // dgv1
            // 
            this.dgv1.AllowDrop = true;
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(854, 107);
            this.dgv1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.Size = new System.Drawing.Size(1058, 601);
            this.dgv1.TabIndex = 30;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            // 
            // txtBusReading
            // 
            this.txtBusReading.Location = new System.Drawing.Point(516, 424);
            this.txtBusReading.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtBusReading.Name = "txtBusReading";
            this.txtBusReading.Size = new System.Drawing.Size(284, 38);
            this.txtBusReading.TabIndex = 26;
            this.txtBusReading.Text = "0.0";
            // 
            // lblBusReading
            // 
            this.lblBusReading.AutoSize = true;
            this.lblBusReading.BackColor = System.Drawing.Color.Transparent;
            this.lblBusReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusReading.ForeColor = System.Drawing.Color.White;
            this.lblBusReading.Location = new System.Drawing.Point(108, 430);
            this.lblBusReading.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblBusReading.Name = "lblBusReading";
            this.lblBusReading.Size = new System.Drawing.Size(215, 38);
            this.lblBusReading.TabIndex = 35;
            this.lblBusReading.Text = "Bus Reading";
            // 
            // txtDieselRate
            // 
            this.txtDieselRate.Location = new System.Drawing.Point(520, 500);
            this.txtDieselRate.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtDieselRate.Name = "txtDieselRate";
            this.txtDieselRate.Size = new System.Drawing.Size(284, 38);
            this.txtDieselRate.TabIndex = 27;
            this.txtDieselRate.Text = "0.0";
            this.txtDieselRate.TextChanged += new System.EventHandler(this.txtDieselRate_TextChanged);
            // 
            // lblDieselRate
            // 
            this.lblDieselRate.AutoSize = true;
            this.lblDieselRate.BackColor = System.Drawing.Color.Transparent;
            this.lblDieselRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselRate.ForeColor = System.Drawing.Color.White;
            this.lblDieselRate.Location = new System.Drawing.Point(108, 506);
            this.lblDieselRate.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDieselRate.Name = "lblDieselRate";
            this.lblDieselRate.Size = new System.Drawing.Size(197, 38);
            this.lblDieselRate.TabIndex = 36;
            this.lblDieselRate.Text = "Diesel Rate";
            // 
            // lblDieselPuringDate
            // 
            this.lblDieselPuringDate.AutoSize = true;
            this.lblDieselPuringDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDieselPuringDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDieselPuringDate.ForeColor = System.Drawing.Color.White;
            this.lblDieselPuringDate.Location = new System.Drawing.Point(108, 269);
            this.lblDieselPuringDate.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblDieselPuringDate.Name = "lblDieselPuringDate";
            this.lblDieselPuringDate.Size = new System.Drawing.Size(326, 38);
            this.lblDieselPuringDate.TabIndex = 33;
            this.lblDieselPuringDate.Text = "Diesel Pouring Date";
            // 
            // txtPuredDiesel
            // 
            this.txtPuredDiesel.Location = new System.Drawing.Point(516, 349);
            this.txtPuredDiesel.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtPuredDiesel.Name = "txtPuredDiesel";
            this.txtPuredDiesel.Size = new System.Drawing.Size(284, 38);
            this.txtPuredDiesel.TabIndex = 25;
            this.txtPuredDiesel.Text = "0.0";
            this.txtPuredDiesel.TextChanged += new System.EventHandler(this.txtPuredDiesel_TextChanged);
            // 
            // lblPuresDiesel
            // 
            this.lblPuresDiesel.AutoSize = true;
            this.lblPuresDiesel.BackColor = System.Drawing.Color.Transparent;
            this.lblPuresDiesel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuresDiesel.ForeColor = System.Drawing.Color.White;
            this.lblPuresDiesel.Location = new System.Drawing.Point(108, 353);
            this.lblPuresDiesel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblPuresDiesel.Name = "lblPuresDiesel";
            this.lblPuresDiesel.Size = new System.Drawing.Size(207, 38);
            this.lblPuresDiesel.TabIndex = 34;
            this.lblPuresDiesel.Text = "Diesel Filled";
            // 
            // txtDieselAvailable
            // 
            this.txtDieselAvailable.Location = new System.Drawing.Point(516, 190);
            this.txtDieselAvailable.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.txtDieselAvailable.Name = "txtDieselAvailable";
            this.txtDieselAvailable.Size = new System.Drawing.Size(284, 38);
            this.txtDieselAvailable.TabIndex = 23;
            // 
            // lblAvailableDiesel
            // 
            this.lblAvailableDiesel.AutoSize = true;
            this.lblAvailableDiesel.BackColor = System.Drawing.Color.Transparent;
            this.lblAvailableDiesel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableDiesel.ForeColor = System.Drawing.Color.White;
            this.lblAvailableDiesel.Location = new System.Drawing.Point(108, 196);
            this.lblAvailableDiesel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblAvailableDiesel.Name = "lblAvailableDiesel";
            this.lblAvailableDiesel.Size = new System.Drawing.Size(265, 38);
            this.lblAvailableDiesel.TabIndex = 32;
            this.lblAvailableDiesel.Text = "Diesel Available";
            // 
            // cmbBusNo
            // 
            this.cmbBusNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusNo.FormattingEnabled = true;
            this.cmbBusNo.Location = new System.Drawing.Point(516, 110);
            this.cmbBusNo.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.cmbBusNo.Name = "cmbBusNo";
            this.cmbBusNo.Size = new System.Drawing.Size(284, 39);
            this.cmbBusNo.TabIndex = 22;
            // 
            // lblBusNo
            // 
            this.lblBusNo.AutoSize = true;
            this.lblBusNo.BackColor = System.Drawing.Color.Transparent;
            this.lblBusNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNo.ForeColor = System.Drawing.Color.White;
            this.lblBusNo.Location = new System.Drawing.Point(108, 110);
            this.lblBusNo.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblBusNo.Name = "lblBusNo";
            this.lblBusNo.Size = new System.Drawing.Size(141, 38);
            this.lblBusNo.TabIndex = 31;
            this.lblBusNo.Text = "Bus No.";
            // 
            // FrmDisealDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.DTPCurrent);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.DTP1);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.txtBusReading);
            this.Controls.Add(this.lblBusReading);
            this.Controls.Add(this.txtDieselRate);
            this.Controls.Add(this.lblDieselRate);
            this.Controls.Add(this.lblDieselPuringDate);
            this.Controls.Add(this.txtPuredDiesel);
            this.Controls.Add(this.lblPuresDiesel);
            this.Controls.Add(this.txtDieselAvailable);
            this.Controls.Add(this.lblAvailableDiesel);
            this.Controls.Add(this.cmbBusNo);
            this.Controls.Add(this.lblBusNo);
            this.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.Name = "FrmDisealDetail";
            this.Size = new System.Drawing.Size(1956, 812);
            this.Load += new System.EventHandler(this.FrmDisealDetail_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDisealDetail_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DTPCurrent;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.DateTimePicker DTP1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.TextBox txtBusReading;
        private System.Windows.Forms.Label lblBusReading;
        private System.Windows.Forms.TextBox txtDieselRate;
        private System.Windows.Forms.Label lblDieselRate;
        private System.Windows.Forms.Label lblDieselPuringDate;
        private System.Windows.Forms.TextBox txtPuredDiesel;
        private System.Windows.Forms.Label lblPuresDiesel;
        private System.Windows.Forms.TextBox txtDieselAvailable;
        private System.Windows.Forms.Label lblAvailableDiesel;
        private System.Windows.Forms.ComboBox cmbBusNo;
        private System.Windows.Forms.Label lblBusNo;
    }
}