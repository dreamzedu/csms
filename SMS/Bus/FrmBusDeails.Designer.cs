namespace SMS.Bus
{
    partial class FrmBusDeails
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
            this.dtpRegExpiryDate = new System.Windows.Forms.DateTimePicker();
            this.lblRegiExpiryDate = new System.Windows.Forms.Label();
            this.dtpRegIssueDate = new System.Windows.Forms.DateTimePicker();
            this.lblRegIssueDate = new System.Windows.Forms.Label();
            this.txtInitailReading = new System.Windows.Forms.TextBox();
            this.lblInitailReading = new System.Windows.Forms.Label();
            this.DTP1 = new System.Windows.Forms.DateTimePicker();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblPurchasingDate = new System.Windows.Forms.Label();
            this.txtChechisNo = new System.Windows.Forms.TextBox();
            this.lblChechisNO = new System.Windows.Forms.Label();
            this.txtModelNo = new System.Windows.Forms.TextBox();
            this.lblModelNO = new System.Windows.Forms.Label();
            this.txtBusMilej = new System.Windows.Forms.TextBox();
            this.lblMilej = new System.Windows.Forms.Label();
            this.txtSeatsCapacity = new System.Windows.Forms.TextBox();
            this.lblSeats = new System.Windows.Forms.Label();
            this.txtRTONo = new System.Windows.Forms.TextBox();
            this.lblRTONO = new System.Windows.Forms.Label();
            this.txtBusNo = new System.Windows.Forms.TextBox();
            this.lblBusNo = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpRegExpiryDate
            // 
            this.dtpRegExpiryDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRegExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegExpiryDate.Location = new System.Drawing.Point(258, 398);
            this.dtpRegExpiryDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpRegExpiryDate.Name = "dtpRegExpiryDate";
            this.dtpRegExpiryDate.Size = new System.Drawing.Size(150, 22);
            this.dtpRegExpiryDate.TabIndex = 45;
            // 
            // lblRegiExpiryDate
            // 
            this.lblRegiExpiryDate.AutoSize = true;
            this.lblRegiExpiryDate.BackColor = System.Drawing.Color.Transparent;
            this.lblRegiExpiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegiExpiryDate.ForeColor = System.Drawing.Color.White;
            this.lblRegiExpiryDate.Location = new System.Drawing.Point(60, 401);
            this.lblRegiExpiryDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegiExpiryDate.Name = "lblRegiExpiryDate";
            this.lblRegiExpiryDate.Size = new System.Drawing.Size(190, 18);
            this.lblRegiExpiryDate.TabIndex = 44;
            this.lblRegiExpiryDate.Text = "Registration Expiry Date";
            // 
            // dtpRegIssueDate
            // 
            this.dtpRegIssueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpRegIssueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRegIssueDate.Location = new System.Drawing.Point(258, 364);
            this.dtpRegIssueDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpRegIssueDate.Name = "dtpRegIssueDate";
            this.dtpRegIssueDate.Size = new System.Drawing.Size(150, 22);
            this.dtpRegIssueDate.TabIndex = 43;
            // 
            // lblRegIssueDate
            // 
            this.lblRegIssueDate.AutoSize = true;
            this.lblRegIssueDate.BackColor = System.Drawing.Color.Transparent;
            this.lblRegIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegIssueDate.ForeColor = System.Drawing.Color.White;
            this.lblRegIssueDate.Location = new System.Drawing.Point(60, 367);
            this.lblRegIssueDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegIssueDate.Name = "lblRegIssueDate";
            this.lblRegIssueDate.Size = new System.Drawing.Size(184, 18);
            this.lblRegIssueDate.TabIndex = 42;
            this.lblRegIssueDate.Text = "Registration Issue Date";
            // 
            // txtInitailReading
            // 
            this.txtInitailReading.Location = new System.Drawing.Point(258, 262);
            this.txtInitailReading.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtInitailReading.Name = "txtInitailReading";
            this.txtInitailReading.Size = new System.Drawing.Size(150, 22);
            this.txtInitailReading.TabIndex = 33;
            this.txtInitailReading.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInitailReading_KeyPress);
            // 
            // lblInitailReading
            // 
            this.lblInitailReading.AutoSize = true;
            this.lblInitailReading.BackColor = System.Drawing.Color.Transparent;
            this.lblInitailReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitailReading.ForeColor = System.Drawing.Color.White;
            this.lblInitailReading.Location = new System.Drawing.Point(60, 265);
            this.lblInitailReading.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInitailReading.Name = "lblInitailReading";
            this.lblInitailReading.Size = new System.Drawing.Size(113, 18);
            this.lblInitailReading.TabIndex = 40;
            this.lblInitailReading.Text = "Initial Reading";
            // 
            // DTP1
            // 
            this.DTP1.CustomFormat = "dd/MM/yyyy";
            this.DTP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP1.Location = new System.Drawing.Point(258, 297);
            this.DTP1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DTP1.Name = "DTP1";
            this.DTP1.Size = new System.Drawing.Size(150, 22);
            this.DTP1.TabIndex = 34;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(258, 329);
            this.txtCompany.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(150, 22);
            this.txtCompany.TabIndex = 35;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.White;
            this.lblCompany.Location = new System.Drawing.Point(60, 331);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(79, 18);
            this.lblCompany.TabIndex = 25;
            this.lblCompany.Text = "Company";
            // 
            // lblPurchasingDate
            // 
            this.lblPurchasingDate.AutoSize = true;
            this.lblPurchasingDate.BackColor = System.Drawing.Color.Transparent;
            this.lblPurchasingDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPurchasingDate.ForeColor = System.Drawing.Color.White;
            this.lblPurchasingDate.Location = new System.Drawing.Point(60, 297);
            this.lblPurchasingDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPurchasingDate.Name = "lblPurchasingDate";
            this.lblPurchasingDate.Size = new System.Drawing.Size(124, 18);
            this.lblPurchasingDate.TabIndex = 21;
            this.lblPurchasingDate.Text = " Purchase Date\r\n";
            // 
            // txtChechisNo
            // 
            this.txtChechisNo.Location = new System.Drawing.Point(258, 228);
            this.txtChechisNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChechisNo.Name = "txtChechisNo";
            this.txtChechisNo.Size = new System.Drawing.Size(150, 22);
            this.txtChechisNo.TabIndex = 32;
            // 
            // lblChechisNO
            // 
            this.lblChechisNO.AutoSize = true;
            this.lblChechisNO.BackColor = System.Drawing.Color.Transparent;
            this.lblChechisNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChechisNO.ForeColor = System.Drawing.Color.White;
            this.lblChechisNO.Location = new System.Drawing.Point(60, 230);
            this.lblChechisNO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChechisNO.Name = "lblChechisNO";
            this.lblChechisNO.Size = new System.Drawing.Size(101, 18);
            this.lblChechisNO.TabIndex = 22;
            this.lblChechisNO.Text = "Chassis No.";
            // 
            // txtModelNo
            // 
            this.txtModelNo.Location = new System.Drawing.Point(258, 196);
            this.txtModelNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtModelNo.Name = "txtModelNo";
            this.txtModelNo.Size = new System.Drawing.Size(150, 22);
            this.txtModelNo.TabIndex = 31;
            // 
            // lblModelNO
            // 
            this.lblModelNO.AutoSize = true;
            this.lblModelNO.BackColor = System.Drawing.Color.Transparent;
            this.lblModelNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelNO.ForeColor = System.Drawing.Color.White;
            this.lblModelNO.Location = new System.Drawing.Point(60, 198);
            this.lblModelNO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModelNO.Name = "lblModelNO";
            this.lblModelNO.Size = new System.Drawing.Size(86, 18);
            this.lblModelNO.TabIndex = 19;
            this.lblModelNO.Text = "Model No.";
            // 
            // txtBusMilej
            // 
            this.txtBusMilej.Location = new System.Drawing.Point(258, 162);
            this.txtBusMilej.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBusMilej.Name = "txtBusMilej";
            this.txtBusMilej.Size = new System.Drawing.Size(150, 22);
            this.txtBusMilej.TabIndex = 30;
            this.txtBusMilej.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusMilej_KeyPress);
            // 
            // lblMilej
            // 
            this.lblMilej.AutoSize = true;
            this.lblMilej.BackColor = System.Drawing.Color.Transparent;
            this.lblMilej.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMilej.ForeColor = System.Drawing.Color.White;
            this.lblMilej.Location = new System.Drawing.Point(60, 166);
            this.lblMilej.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMilej.Name = "lblMilej";
            this.lblMilej.Size = new System.Drawing.Size(100, 18);
            this.lblMilej.TabIndex = 20;
            this.lblMilej.Text = "Bus Mileage";
            // 
            // txtSeatsCapacity
            // 
            this.txtSeatsCapacity.Location = new System.Drawing.Point(258, 132);
            this.txtSeatsCapacity.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSeatsCapacity.Name = "txtSeatsCapacity";
            this.txtSeatsCapacity.Size = new System.Drawing.Size(150, 22);
            this.txtSeatsCapacity.TabIndex = 29;
            this.txtSeatsCapacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSeatsCapacity_KeyPress);
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.BackColor = System.Drawing.Color.Transparent;
            this.lblSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeats.ForeColor = System.Drawing.Color.White;
            this.lblSeats.Location = new System.Drawing.Point(60, 134);
            this.lblSeats.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(121, 18);
            this.lblSeats.TabIndex = 23;
            this.lblSeats.Text = "Seats Capacity";
            // 
            // txtRTONo
            // 
            this.txtRTONo.Location = new System.Drawing.Point(258, 95);
            this.txtRTONo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRTONo.Name = "txtRTONo";
            this.txtRTONo.Size = new System.Drawing.Size(150, 22);
            this.txtRTONo.TabIndex = 28;
            // 
            // lblRTONO
            // 
            this.lblRTONO.AutoSize = true;
            this.lblRTONO.BackColor = System.Drawing.Color.Transparent;
            this.lblRTONO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRTONO.ForeColor = System.Drawing.Color.White;
            this.lblRTONO.Location = new System.Drawing.Point(60, 97);
            this.lblRTONO.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRTONO.Name = "lblRTONO";
            this.lblRTONO.Size = new System.Drawing.Size(75, 18);
            this.lblRTONO.TabIndex = 26;
            this.lblRTONO.Text = "RTO No.";
            // 
            // txtBusNo
            // 
            this.txtBusNo.Enabled = false;
            this.txtBusNo.Location = new System.Drawing.Point(258, 59);
            this.txtBusNo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBusNo.Name = "txtBusNo";
            this.txtBusNo.Size = new System.Drawing.Size(150, 22);
            this.txtBusNo.TabIndex = 27;
            // 
            // lblBusNo
            // 
            this.lblBusNo.AutoSize = true;
            this.lblBusNo.BackColor = System.Drawing.Color.Transparent;
            this.lblBusNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusNo.ForeColor = System.Drawing.Color.White;
            this.lblBusNo.Location = new System.Drawing.Point(60, 62);
            this.lblBusNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusNo.Name = "lblBusNo";
            this.lblBusNo.Size = new System.Drawing.Size(69, 18);
            this.lblBusNo.TabIndex = 24;
            this.lblBusNo.Text = "Bus No.";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(441, 57);
            this.dgv1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv1.Name = "dgv1";
            this.dgv1.ReadOnly = true;
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.Size = new System.Drawing.Size(515, 366);
            this.dgv1.TabIndex = 41;
            this.dgv1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellClick);
            // 
            // FrmBusDeails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dtpRegExpiryDate);
            this.Controls.Add(this.lblRegiExpiryDate);
            this.Controls.Add(this.dtpRegIssueDate);
            this.Controls.Add(this.lblRegIssueDate);
            this.Controls.Add(this.txtInitailReading);
            this.Controls.Add(this.lblInitailReading);
            this.Controls.Add(this.DTP1);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblPurchasingDate);
            this.Controls.Add(this.txtChechisNo);
            this.Controls.Add(this.lblChechisNO);
            this.Controls.Add(this.txtModelNo);
            this.Controls.Add(this.lblModelNO);
            this.Controls.Add(this.txtBusMilej);
            this.Controls.Add(this.lblMilej);
            this.Controls.Add(this.txtSeatsCapacity);
            this.Controls.Add(this.lblSeats);
            this.Controls.Add(this.txtRTONo);
            this.Controls.Add(this.lblRTONO);
            this.Controls.Add(this.txtBusNo);
            this.Controls.Add(this.lblBusNo);
            this.Controls.Add(this.dgv1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmBusDeails";
            this.Size = new System.Drawing.Size(969, 474);
            this.Load += new System.EventHandler(this.FrmBusDeails_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBusDeails_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpRegExpiryDate;
        private System.Windows.Forms.Label lblRegiExpiryDate;
        private System.Windows.Forms.DateTimePicker dtpRegIssueDate;
        private System.Windows.Forms.Label lblRegIssueDate;
        private System.Windows.Forms.TextBox txtInitailReading;
        private System.Windows.Forms.Label lblInitailReading;
        private System.Windows.Forms.DateTimePicker DTP1;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblPurchasingDate;
        private System.Windows.Forms.TextBox txtChechisNo;
        private System.Windows.Forms.Label lblChechisNO;
        private System.Windows.Forms.TextBox txtModelNo;
        private System.Windows.Forms.Label lblModelNO;
        private System.Windows.Forms.TextBox txtBusMilej;
        private System.Windows.Forms.Label lblMilej;
        private System.Windows.Forms.TextBox txtSeatsCapacity;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.TextBox txtRTONo;
        private System.Windows.Forms.Label lblRTONO;
        private System.Windows.Forms.TextBox txtBusNo;
        private System.Windows.Forms.Label lblBusNo;
        private System.Windows.Forms.DataGridView dgv1;
    }
}