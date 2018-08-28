namespace SMS
{
    partial class frmdailyfeereport
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
            this.dtpfeedate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpfeedate
            // 
            this.dtpfeedate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.dtpfeedate.CustomFormat = "dd/MM/yyyy";
            this.dtpfeedate.Font = new System.Drawing.Font("Arial", 8.75F, System.Drawing.FontStyle.Bold);
            this.dtpfeedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfeedate.Location = new System.Drawing.Point(139, 56);
            this.dtpfeedate.Name = "dtpfeedate";
            this.dtpfeedate.Size = new System.Drawing.Size(142, 24);
            this.dtpfeedate.TabIndex = 0;
            this.dtpfeedate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpfeedate_KeyDown);
            this.dtpfeedate.Validated += new System.EventHandler(this.dtpfeedate_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(55, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 46;
            this.label4.Text = "Fee Date";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(55, 88);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(450, 218);
            this.dataGridView1.TabIndex = 48;
            // 
            // frmdailyfeereport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtpfeedate);
            this.Controls.Add(this.label4);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmdailyfeereport";
            this.Size = new System.Drawing.Size(552, 359);
            this.Tag = "1057";
            this.Load += new System.EventHandler(this.frmdailyfeereport_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmdailyfeereport_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpfeedate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}