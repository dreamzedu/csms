namespace SMS
{
    partial class frmclass
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.valcmbclass = new System.Windows.Forms.ComboBox();
            this.valcmbsection = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.valcmbsankay = new System.Windows.Forms.ComboBox();
            this.txtclasscode = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Class ";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(308, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(184, 191);
            this.listBox1.TabIndex = 1;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Section";
            // 
            // valcmbclass
            // 
            this.valcmbclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbclass.ForeColor = System.Drawing.Color.Blue;
            this.valcmbclass.FormattingEnabled = true;
            this.valcmbclass.Location = new System.Drawing.Point(87, 12);
            this.valcmbclass.Name = "valcmbclass";
            this.valcmbclass.Size = new System.Drawing.Size(140, 25);
            this.valcmbclass.TabIndex = 2;
            this.valcmbclass.Tag = "classcode";
            this.valcmbclass.Text = "-Select-";
            this.valcmbclass.SelectedIndexChanged += new System.EventHandler(this.valcmbclass_SelectedIndexChanged);
            this.valcmbclass.SelectedValueChanged += new System.EventHandler(this.valcmbclass_SelectedValueChanged);
            this.valcmbclass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            this.valcmbclass.Leave += new System.EventHandler(this.valcmbclass_Leave);
            this.valcmbclass.Validated += new System.EventHandler(this.valcmbclass_Validated);
            // 
            // valcmbsection
            // 
            this.valcmbsection.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbsection.ForeColor = System.Drawing.Color.Blue;
            this.valcmbsection.FormattingEnabled = true;
            this.valcmbsection.Location = new System.Drawing.Point(87, 57);
            this.valcmbsection.Name = "valcmbsection";
            this.valcmbsection.Size = new System.Drawing.Size(140, 25);
            this.valcmbsection.TabIndex = 3;
            this.valcmbsection.Tag = "sectioncode";
            this.valcmbsection.Text = "-Select-";
            this.valcmbsection.SelectedIndexChanged += new System.EventHandler(this.valcmbsection_SelectedIndexChanged);
            this.valcmbsection.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stream";
            // 
            // valcmbsankay
            // 
            this.valcmbsankay.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbsankay.ForeColor = System.Drawing.Color.Blue;
            this.valcmbsankay.FormattingEnabled = true;
            this.valcmbsankay.Location = new System.Drawing.Point(87, 102);
            this.valcmbsankay.Name = "valcmbsankay";
            this.valcmbsankay.Size = new System.Drawing.Size(140, 25);
            this.valcmbsankay.TabIndex = 4;
            this.valcmbsankay.Tag = "sankaycode";
            this.valcmbsankay.Text = "-Select-";
            this.valcmbsankay.SelectedIndexChanged += new System.EventHandler(this.cmbsankay_SelectedIndexChanged);
            this.valcmbsankay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            this.valcmbsankay.Validating += new System.ComponentModel.CancelEventHandler(this.cmbsankay_Validating);
            // 
            // txtclasscode
            // 
            this.txtclasscode.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtclasscode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclasscode.ForeColor = System.Drawing.Color.Blue;
            this.txtclasscode.Location = new System.Drawing.Point(156, 147);
            this.txtclasscode.MaxLength = 30;
            this.txtclasscode.Name = "txtclasscode";
            this.txtclasscode.Size = new System.Drawing.Size(63, 25);
            this.txtclasscode.TabIndex = 41;
            this.txtclasscode.TabStop = false;
            this.txtclasscode.Tag = "classno";
            this.txtclasscode.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(87, 147);
            this.textBox1.MaxLength = 30;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(63, 25);
            this.textBox1.TabIndex = 5;
            this.textBox1.Tag = "strength";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Strength";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.valcmbclass);
            this.panel2.Controls.Add(this.valcmbsection);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtclasscode);
            this.panel2.Controls.Add(this.valcmbsankay);
            this.panel2.Location = new System.Drawing.Point(53, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(235, 191);
            this.panel2.TabIndex = 42;
            // 
            // frmclass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmclass";
            this.Size = new System.Drawing.Size(546, 316);
            this.Tag = "1052";
            this.Load += new System.EventHandler(this.frmclass_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmclass_Paint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox valcmbclass;
        private System.Windows.Forms.ComboBox valcmbsection;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox valcmbsankay;
        private System.Windows.Forms.TextBox txtclasscode;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
    }
}