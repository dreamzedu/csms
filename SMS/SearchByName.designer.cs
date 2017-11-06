namespace SMS
{
    partial class SearchByName
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GVStudentDetails = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Pct_Close = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GVStudentDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Close)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(166, 54);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student Name";
            // 
            // GVStudentDetails
            // 
            this.GVStudentDetails.AllowUserToAddRows = false;
            this.GVStudentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVStudentDetails.Location = new System.Drawing.Point(31, 84);
            this.GVStudentDetails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GVStudentDetails.Name = "GVStudentDetails";
            this.GVStudentDetails.Size = new System.Drawing.Size(797, 198);
            this.GVStudentDetails.TabIndex = 2;
            this.GVStudentDetails.DoubleClick += new System.EventHandler(this.GVStudentDetails_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(330, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "SearchByName";
            // 
            // Pct_Close
            // 
            this.Pct_Close.BackColor = System.Drawing.Color.Transparent;
            this.Pct_Close.BackgroundImage = global::SMS.Properties.Resources.edit_delete;
            this.Pct_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Pct_Close.Image = global::SMS.Properties.Resources.edit_delete;
            this.Pct_Close.Location = new System.Drawing.Point(835, 0);
            this.Pct_Close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pct_Close.Name = "Pct_Close";
            this.Pct_Close.Size = new System.Drawing.Size(24, 22);
            this.Pct_Close.TabIndex = 10;
            this.Pct_Close.TabStop = false;
            this.Pct_Close.Click += new System.EventHandler(this.Pct_Close_Click);
            // 
            // SearchByName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(859, 310);
            this.ControlBox = false;
            this.Controls.Add(this.Pct_Close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GVStudentDetails);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SearchByName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "1146";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SearchByName_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.GVStudentDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pct_Close)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView GVStudentDetails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox Pct_Close;
    }
}