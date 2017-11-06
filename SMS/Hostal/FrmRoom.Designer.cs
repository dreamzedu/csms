namespace SMS.Hostal
{
    partial class FrmRoom
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
            this.BtnSearch = new System.Windows.Forms.Button();
            this.valcmbclass = new System.Windows.Forms.ComboBox();
            this.beds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtgbook = new System.Windows.Forms.DataGridView();
            this.Hostel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSearch.Location = new System.Drawing.Point(357, 55);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(95, 28);
            this.BtnSearch.TabIndex = 58;
            this.BtnSearch.Text = "&Show";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // valcmbclass
            // 
            this.valcmbclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbclass.ForeColor = System.Drawing.Color.Blue;
            this.valcmbclass.FormattingEnabled = true;
            this.valcmbclass.Items.AddRange(new object[] {
            "Year Fee",
            "Regular Fee"});
            this.valcmbclass.Location = new System.Drawing.Point(132, 55);
            this.valcmbclass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valcmbclass.Name = "valcmbclass";
            this.valcmbclass.Size = new System.Drawing.Size(216, 25);
            this.valcmbclass.TabIndex = 57;
            // 
            // beds
            // 
            this.beds.HeaderText = "No.of Beds";
            this.beds.Name = "beds";
            this.beds.Width = 107;
            // 
            // roomno
            // 
            this.roomno.HeaderText = "Room No.";
            this.roomno.Name = "roomno";
            // 
            // dtgbook
            // 
            this.dtgbook.AllowUserToAddRows = false;
            this.dtgbook.AllowUserToDeleteRows = false;
            this.dtgbook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.roomno,
            this.beds});
            this.dtgbook.Location = new System.Drawing.Point(55, 92);
            this.dtgbook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.RowHeadersVisible = false;
            this.dtgbook.Size = new System.Drawing.Size(397, 297);
            this.dtgbook.TabIndex = 54;
            // 
            // Hostel
            // 
            this.Hostel.AutoSize = true;
            this.Hostel.BackColor = System.Drawing.Color.Transparent;
            this.Hostel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hostel.ForeColor = System.Drawing.Color.White;
            this.Hostel.Location = new System.Drawing.Point(51, 58);
            this.Hostel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Hostel.Name = "Hostel";
            this.Hostel.Size = new System.Drawing.Size(59, 19);
            this.Hostel.TabIndex = 53;
            this.Hostel.Text = "Hostel";
            // 
            // FrmRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.valcmbclass);
            this.Controls.Add(this.dtgbook);
            this.Controls.Add(this.Hostel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmRoom";
            this.Size = new System.Drawing.Size(460, 474);
            this.Load += new System.EventHandler(this.FrmRoom_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmRoom_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.ComboBox valcmbclass;
        private System.Windows.Forms.DataGridViewTextBoxColumn beds;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomno;
        private System.Windows.Forms.DataGridView dtgbook;
        private System.Windows.Forms.Label Hostel;
    }
}