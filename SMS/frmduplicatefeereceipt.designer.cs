namespace SMS
{
    partial class frmduplicatefeereceipt
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
            this.txtfeeno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblschloarno = new System.Windows.Forms.Label();
            this.lblclass = new System.Windows.Forms.Label();
            this.lblfeemonth = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblsession = new System.Windows.Forms.Label();
            this.lblstudentno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // txtfeeno
            // 
            this.txtfeeno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfeeno.ForeColor = System.Drawing.Color.Blue;
            this.txtfeeno.Location = new System.Drawing.Point(188, 55);
            this.txtfeeno.MaxLength = 40;
            this.txtfeeno.Name = "txtfeeno";
            this.txtfeeno.Size = new System.Drawing.Size(182, 25);
            this.txtfeeno.TabIndex = 0;
            this.txtfeeno.Tag = "schoolname";
            this.txtfeeno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtfeeno_KeyDown);
            this.txtfeeno.Validated += new System.EventHandler(this.txtfeeno_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(56, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 29;
            this.label6.Text = "Fee No.";
            // 
            // lblschloarno
            // 
            this.lblschloarno.AutoSize = true;
            this.lblschloarno.BackColor = System.Drawing.Color.Transparent;
            this.lblschloarno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblschloarno.ForeColor = System.Drawing.Color.White;
            this.lblschloarno.Location = new System.Drawing.Point(185, 81);
            this.lblschloarno.Name = "lblschloarno";
            this.lblschloarno.Size = new System.Drawing.Size(15, 19);
            this.lblschloarno.TabIndex = 30;
            this.lblschloarno.Text = "-";
            // 
            // lblclass
            // 
            this.lblclass.AutoSize = true;
            this.lblclass.BackColor = System.Drawing.Color.Transparent;
            this.lblclass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclass.ForeColor = System.Drawing.Color.White;
            this.lblclass.Location = new System.Drawing.Point(185, 129);
            this.lblclass.Name = "lblclass";
            this.lblclass.Size = new System.Drawing.Size(15, 19);
            this.lblclass.TabIndex = 31;
            this.lblclass.Text = "-";
            // 
            // lblfeemonth
            // 
            this.lblfeemonth.AutoSize = true;
            this.lblfeemonth.BackColor = System.Drawing.Color.Transparent;
            this.lblfeemonth.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfeemonth.ForeColor = System.Drawing.Color.White;
            this.lblfeemonth.Location = new System.Drawing.Point(185, 153);
            this.lblfeemonth.Name = "lblfeemonth";
            this.lblfeemonth.Size = new System.Drawing.Size(15, 19);
            this.lblfeemonth.TabIndex = 32;
            this.lblfeemonth.Text = "-";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.White;
            this.lblname.Location = new System.Drawing.Point(185, 105);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(15, 19);
            this.lblname.TabIndex = 33;
            this.lblname.Text = "-";
            // 
            // lblsession
            // 
            this.lblsession.AutoSize = true;
            this.lblsession.BackColor = System.Drawing.Color.Transparent;
            this.lblsession.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsession.ForeColor = System.Drawing.Color.White;
            this.lblsession.Location = new System.Drawing.Point(185, 177);
            this.lblsession.Name = "lblsession";
            this.lblsession.Size = new System.Drawing.Size(15, 19);
            this.lblsession.TabIndex = 34;
            this.lblsession.Text = "-";
            // 
            // lblstudentno
            // 
            this.lblstudentno.AutoSize = true;
            this.lblstudentno.BackColor = System.Drawing.Color.Transparent;
            this.lblstudentno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstudentno.ForeColor = System.Drawing.Color.White;
            this.lblstudentno.Location = new System.Drawing.Point(56, 204);
            this.lblstudentno.Name = "lblstudentno";
            this.lblstudentno.Size = new System.Drawing.Size(89, 19);
            this.lblstudentno.TabIndex = 35;
            this.lblstudentno.Text = "studentno";
            this.lblstudentno.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 36;
            this.label1.Text = "Scholar No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(56, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 37;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(56, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 38;
            this.label3.Text = "Class";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(56, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 39;
            this.label4.Text = "Fee Month";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(56, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 19);
            this.label5.TabIndex = 40;
            this.label5.Text = "Session";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // frmduplicatefeereceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblstudentno);
            this.Controls.Add(this.lblsession);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.lblfeemonth);
            this.Controls.Add(this.lblclass);
            this.Controls.Add(this.lblschloarno);
            this.Controls.Add(this.txtfeeno);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmduplicatefeereceipt";
            this.Size = new System.Drawing.Size(419, 326);
            this.Tag = "1062";
            this.Load += new System.EventHandler(this.frmduplicatefeereceipt_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmduplicatefeereceipt_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtfeeno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblschloarno;
        private System.Windows.Forms.Label lblclass;
        private System.Windows.Forms.Label lblfeemonth;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblsession;
        private System.Windows.Forms.Label lblstudentno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}