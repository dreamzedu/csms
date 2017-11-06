namespace SMS
{
    partial class frmExamHead
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtExamName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbExamOrder = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaximumMarks = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(68, 62);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(218, 304);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // txtExamName
            // 
            this.txtExamName.Location = new System.Drawing.Point(478, 62);
            this.txtExamName.Margin = new System.Windows.Forms.Padding(4);
            this.txtExamName.Name = "txtExamName";
            this.txtExamName.Size = new System.Drawing.Size(216, 26);
            this.txtExamName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(304, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Exam Name";
            // 
            // cmbExamOrder
            // 
            this.cmbExamOrder.FormattingEnabled = true;
            this.cmbExamOrder.Location = new System.Drawing.Point(478, 132);
            this.cmbExamOrder.Name = "cmbExamOrder";
            this.cmbExamOrder.Size = new System.Drawing.Size(73, 28);
            this.cmbExamOrder.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(304, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Exam Name Order";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(304, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Maximum Marks";
            // 
            // txtMaximumMarks
            // 
            this.txtMaximumMarks.Location = new System.Drawing.Point(478, 97);
            this.txtMaximumMarks.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaximumMarks.Name = "txtMaximumMarks";
            this.txtMaximumMarks.Size = new System.Drawing.Size(73, 26);
            this.txtMaximumMarks.TabIndex = 5;
            this.txtMaximumMarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmExamHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaximumMarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbExamOrder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtExamName);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmExamHead";
            this.Size = new System.Drawing.Size(770, 399);
            this.Load += new System.EventHandler(this.frmExamHead_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtExamName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbExamOrder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaximumMarks;
    }
}