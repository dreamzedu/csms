namespace SMS
{
    partial class frmStopsDetails
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.BStopId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusStopNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Available = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(100, 1244);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(547, 39);
            this.label2.TabIndex = 137;
            this.label2.Text = "For New Stop Entry Press Ctrl+N";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToOrderColumns = true;
            this.dgv1.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BStopId,
            this.BusStopNo,
            this.StopName,
            this.Fee,
            this.Available});
            this.dgv1.Location = new System.Drawing.Point(108, 105);
            this.dgv1.Margin = new System.Windows.Forms.Padding(8);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(1870, 1108);
            this.dgv1.TabIndex = 136;
            this.dgv1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellEndEdit);
            // 
            // BStopId
            // 
            this.BStopId.DataPropertyName = "BStopId";
            this.BStopId.HeaderText = "BStopId";
            this.BStopId.Name = "BStopId";
            this.BStopId.Visible = false;
            // 
            // BusStopNo
            // 
            this.BusStopNo.DataPropertyName = "BusStopNo";
            this.BusStopNo.HeaderText = "Stop No.";
            this.BusStopNo.Name = "BusStopNo";
            // 
            // StopName
            // 
            this.StopName.DataPropertyName = "StopName";
            this.StopName.HeaderText = "Stop Name";
            this.StopName.Name = "StopName";
            this.StopName.Width = 300;
            // 
            // Fee
            // 
            this.Fee.DataPropertyName = "Fee";
            this.Fee.HeaderText = "Fee";
            this.Fee.Name = "Fee";
            // 
            // Available
            // 
            this.Available.DataPropertyName = "Available";
            this.Available.HeaderText = "Availavle";
            this.Available.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.Available.Name = "Available";
            this.Available.Width = 150;
            // 
            // frmStopsDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv1);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "frmStopsDetails";
            this.Size = new System.Drawing.Size(2056, 1337);
            this.Tag = "1111";
            this.Load += new System.EventHandler(this.frmStopsDetails_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmStopsDetails_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn BStopId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BusStopNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fee;
        private System.Windows.Forms.DataGridViewComboBoxColumn Available;
    }
}