namespace SMS
{
    partial class frmEmployeeListView
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbempcategory = new System.Windows.Forms.ComboBox();
            this.btnok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Category ";
            // 
            // cmbempcategory
            // 
            this.cmbempcategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbempcategory.FormattingEnabled = true;
            this.cmbempcategory.Items.AddRange(new object[] {
            "All Employee"});
            this.cmbempcategory.Location = new System.Drawing.Point(213, 59);
            this.cmbempcategory.Margin = new System.Windows.Forms.Padding(4);
            this.cmbempcategory.Name = "cmbempcategory";
            this.cmbempcategory.Size = new System.Drawing.Size(225, 30);
            this.cmbempcategory.TabIndex = 2;
            // 
            // btnok
            // 
            this.btnok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnok.Location = new System.Drawing.Point(358, 114);
            this.btnok.Margin = new System.Windows.Forms.Padding(4);
            this.btnok.Name = "btnok";
            this.btnok.Size = new System.Drawing.Size(80, 28);
            this.btnok.TabIndex = 3;
            this.btnok.Text = "Ok";
            this.btnok.UseVisualStyleBackColor = true;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // frmEmployeeListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.cmbempcategory);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEmployeeListView";
            this.Size = new System.Drawing.Size(463, 165);
            this.Tag = "1065";
            this.Load += new System.EventHandler(this.frmEmployeeListView_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmEmployeeListView_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbempcategory;
        private System.Windows.Forms.Button btnok;

    }
}