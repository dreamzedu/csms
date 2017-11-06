namespace SMS.Library.ReportForm
{
    partial class FrmBookList
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label25 = new System.Windows.Forms.Label();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(963, 278);
            this.dataGridView1.TabIndex = 5;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label25.Location = new System.Drawing.Point(453, -2);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(94, 24);
            this.label25.TabIndex = 206;
            this.label25.Text = "Book List";
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.White;
            this.BtnExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExit.ForeColor = System.Drawing.Color.Black;
            this.BtnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnExit.Location = new System.Drawing.Point(942, 321);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(40, 42);
            this.BtnExit.TabIndex = 248;
            this.BtnExit.Text = "E&xit";
            this.BtnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnPrint
            // 
            this.BtnPrint.BackColor = System.Drawing.Color.White;
            this.BtnPrint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPrint.ForeColor = System.Drawing.Color.Black;
            this.BtnPrint.Image = global::SMS.Properties.Resources.save;
            this.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPrint.Location = new System.Drawing.Point(880, 321);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(62, 42);
            this.BtnPrint.TabIndex = 247;
            this.BtnPrint.Text = "Pri&nt";
            this.BtnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // FrmBookList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 380);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.dataGridView1);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmBookList";
            this.Text = "FrmBookList";
            this.Load += new System.EventHandler(this.FrmBookList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmBookList_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnPrint;
    }
}