namespace SMS.Library
{
    partial class FrmGetStudentBarcode
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
            this.GVStudentDetails = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Pct_Close = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GVStudentDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // GVStudentDetails
            // 
            this.GVStudentDetails.AllowUserToAddRows = false;
            this.GVStudentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVStudentDetails.Location = new System.Drawing.Point(16, 82);
            this.GVStudentDetails.Name = "GVStudentDetails";
            this.GVStudentDetails.Size = new System.Drawing.Size(598, 161);
            this.GVStudentDetails.TabIndex = 6;
            this.GVStudentDetails.DoubleClick += new System.EventHandler(this.GVStudentDetails_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(96, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Student Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(318, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(234, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search By Name";
            // 
            // Pct_Close
            // 
            this.Pct_Close.BackColor = System.Drawing.Color.Transparent;
            this.Pct_Close.BackgroundImage = global::SMS.Properties.Resources.edit_delete;
            this.Pct_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pct_Close.Image = global::SMS.Properties.Resources.edit_delete;
            this.Pct_Close.Location = new System.Drawing.Point(613, 0);
            this.Pct_Close.Name = "Pct_Close";
            this.Pct_Close.Size = new System.Drawing.Size(18, 16);
            this.Pct_Close.TabIndex = 9;
            this.Pct_Close.TabStop = false;
            this.Pct_Close.Click += new System.EventHandler(this.Pct_Close_Click);
            // 
            // FrmGetStudentBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(631, 263);
            this.ControlBox = false;
            this.Controls.Add(this.Pct_Close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GVStudentDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmGetStudentBarcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmGetStudentBarcode_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.GVStudentDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GVStudentDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Pct_Close;

    }
}