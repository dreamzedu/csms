namespace SMS
{
    partial class frmSessionRecord
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
            this.lbSessionname = new System.Windows.Forms.ListBox();
            this.txtSessionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsessioncode = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSessionname
            // 
            this.lbSessionname.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSessionname.FormattingEnabled = true;
            this.lbSessionname.ItemHeight = 16;
            this.lbSessionname.Location = new System.Drawing.Point(400, 47);
            this.lbSessionname.Margin = new System.Windows.Forms.Padding(4);
            this.lbSessionname.Name = "lbSessionname";
            this.lbSessionname.Size = new System.Drawing.Size(165, 228);
            this.lbSessionname.TabIndex = 3;
            this.lbSessionname.SelectedIndexChanged += new System.EventHandler(this.lbSessionname_SelectedIndexChanged);
            // 
            // txtSessionName
            // 
            this.txtSessionName.Enabled = false;
            this.txtSessionName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSessionName.ForeColor = System.Drawing.Color.Blue;
            this.txtSessionName.Location = new System.Drawing.Point(157, 13);
            this.txtSessionName.Margin = new System.Windows.Forms.Padding(4);
            this.txtSessionName.MaxLength = 7;
            this.txtSessionName.Name = "txtSessionName";
            this.txtSessionName.Size = new System.Drawing.Size(164, 23);
            this.txtSessionName.TabIndex = 0;
            this.txtSessionName.Tag = "classname";
            this.txtSessionName.TextChanged += new System.EventHandler(this.txtSessionName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 132;
            this.label1.Text = "Session  Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtsessioncode
            // 
            this.txtsessioncode.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtsessioncode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsessioncode.ForeColor = System.Drawing.Color.Blue;
            this.txtsessioncode.Location = new System.Drawing.Point(137, 198);
            this.txtsessioncode.Margin = new System.Windows.Forms.Padding(4);
            this.txtsessioncode.MaxLength = 30;
            this.txtsessioncode.Name = "txtsessioncode";
            this.txtsessioncode.Size = new System.Drawing.Size(104, 23);
            this.txtsessioncode.TabIndex = 301;
            this.txtsessioncode.TabStop = false;
            this.txtsessioncode.Tag = "classcode";
            this.txtsessioncode.Visible = false;
            this.txtsessioncode.TextChanged += new System.EventHandler(this.txtsessioncode_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(157, 49);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(164, 22);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(157, 86);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(164, 22);
            this.dateTimePicker2.TabIndex = 2;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 138;
            this.label2.Text = "From Date";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 139;
            this.label3.Text = "To Date";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtsessioncode);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSessionName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.dateTimePicker2);
            this.panel2.Location = new System.Drawing.Point(52, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 228);
            this.panel2.TabIndex = 303;
            // 
            // frmSessionRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbSessionname);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSessionRecord";
            this.Size = new System.Drawing.Size(620, 356);
            this.Tag = "1108";
            this.Load += new System.EventHandler(this.frmSessionRecord_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmSessionRecord_Paint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbSessionname;
        private System.Windows.Forms.TextBox txtSessionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsessioncode;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
    }
}