namespace SMS
{
    partial class frmsection
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
            this.txtsectionname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtsectioncode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtsectionname
            // 
            this.txtsectionname.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtsectionname.Enabled = false;
            this.txtsectionname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsectionname.ForeColor = System.Drawing.Color.Blue;
            this.txtsectionname.Location = new System.Drawing.Point(57, 71);
            this.txtsectionname.Name = "txtsectionname";
            this.txtsectionname.Size = new System.Drawing.Size(198, 25);
            this.txtsectionname.TabIndex = 0;
            this.txtsectionname.Tag = "sectionname";
            this.txtsectionname.TextChanged += new System.EventHandler(this.txtsectionname_TextChanged);
            this.txtsectionname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsectionname_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Section  Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.Blue;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(289, 49);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(131, 123);
            this.listBox1.TabIndex = 35;
            this.listBox1.TabStop = false;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // txtsectioncode
            // 
            this.txtsectioncode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsectioncode.ForeColor = System.Drawing.Color.Blue;
            this.txtsectioncode.Location = new System.Drawing.Point(153, 143);
            this.txtsectioncode.Name = "txtsectioncode";
            this.txtsectioncode.Size = new System.Drawing.Size(62, 25);
            this.txtsectioncode.TabIndex = 13;
            this.txtsectioncode.Tag = "sectioncode";
            this.txtsectioncode.Visible = false;
            // 
            // frmsection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtsectioncode);
            this.Controls.Add(this.txtsectionname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmsection";
            this.Size = new System.Drawing.Size(477, 281);
            this.Tag = "10";
            this.Load += new System.EventHandler(this.frmsection_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmsection_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtsectionname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtsectioncode;
    }
}