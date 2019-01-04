namespace SMS.Library
{
    partial class FrmPublisher
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
            this.txtsankaycode = new System.Windows.Forms.TextBox();
            this.txtsankayname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // txtsankaycode
            // 
            this.txtsankaycode.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtsankaycode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsankaycode.ForeColor = System.Drawing.Color.Blue;
            this.txtsankaycode.Location = new System.Drawing.Point(1024, 17);
            this.txtsankaycode.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtsankaycode.MaxLength = 30;
            this.txtsankaycode.Name = "txtsankaycode";
            this.txtsankaycode.Size = new System.Drawing.Size(145, 42);
            this.txtsankaycode.TabIndex = 133;
            this.txtsankaycode.TabStop = false;
            this.txtsankaycode.Tag = "Publishcode";
            this.txtsankaycode.Visible = false;
            // 
            // txtsankayname
            // 
            this.txtsankayname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsankayname.ForeColor = System.Drawing.Color.Blue;
            this.txtsankayname.Location = new System.Drawing.Point(384, 79);
            this.txtsankayname.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtsankayname.Name = "txtsankayname";
            this.txtsankayname.Size = new System.Drawing.Size(791, 42);
            this.txtsankayname.TabIndex = 131;
            this.txtsankayname.Tag = "publishar";
            this.txtsankayname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsankayname_KeyPress);
            this.txtsankayname.Validated += new System.EventHandler(this.txtsankayname_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(45, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 38);
            this.label1.TabIndex = 130;
            this.label1.Text = "Publisher  Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.Blue;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 35;
            this.listBox1.Location = new System.Drawing.Point(45, 141);
            this.listBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1132, 249);
            this.listBox1.TabIndex = 132;
            this.listBox1.TabStop = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // FrmPublisher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtsankaycode);
            this.Controls.Add(this.txtsankayname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FrmPublisher";
            this.Size = new System.Drawing.Size(1227, 597);
            this.Load += new System.EventHandler(this.FrmPublisher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtsankaycode;
        private System.Windows.Forms.TextBox txtsankayname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}