namespace SMS
{
    partial class frmsankay
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
            this.txtsankayname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtsankaycode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtsankayname
            // 
            this.txtsankayname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsankayname.ForeColor = System.Drawing.Color.Blue;
            this.txtsankayname.Location = new System.Drawing.Point(9, 31);
            this.txtsankayname.Name = "txtsankayname";
            this.txtsankayname.Size = new System.Drawing.Size(172, 25);
            this.txtsankayname.TabIndex = 7;
            this.txtsankayname.Tag = "sankayname";
            this.txtsankayname.TextChanged += new System.EventHandler(this.txtsankayname_TextChanged);
            this.txtsankayname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsankayname_KeyPress_1);
            this.txtsankayname.Validated += new System.EventHandler(this.txtsankayname_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Stream  Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.Blue;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(310, 61);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(158, 174);
            this.listBox1.TabIndex = 31;
            this.listBox1.TabStop = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // txtsankaycode
            // 
            this.txtsankaycode.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtsankaycode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsankaycode.ForeColor = System.Drawing.Color.Blue;
            this.txtsankaycode.Location = new System.Drawing.Point(62, 120);
            this.txtsankaycode.MaxLength = 30;
            this.txtsankaycode.Name = "txtsankaycode";
            this.txtsankaycode.Size = new System.Drawing.Size(62, 25);
            this.txtsankaycode.TabIndex = 129;
            this.txtsankaycode.TabStop = false;
            this.txtsankaycode.Tag = "sankaycode";
            this.txtsankaycode.Visible = false;
            this.txtsankaycode.TextChanged += new System.EventHandler(this.txtsankaycode_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtsankayname);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtsankaycode);
            this.panel2.Location = new System.Drawing.Point(64, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 176);
            this.panel2.TabIndex = 131;
            // 
            // frmsankay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmsankay";
            this.Size = new System.Drawing.Size(484, 316);
            this.Tag = "28";
            this.Load += new System.EventHandler(this.frmsankay_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmsankay_Paint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtsankayname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtsankaycode;
        private System.Windows.Forms.Panel panel2;
    }
}