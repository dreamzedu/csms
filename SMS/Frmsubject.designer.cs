namespace SMS
{
    partial class Frmsubject
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
            this.txtSubjectName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtSubjectNo = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.cmbboard = new System.Windows.Forms.ComboBox();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSubjectOrder = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubjectName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectName.ForeColor = System.Drawing.Color.Blue;
            this.txtSubjectName.Location = new System.Drawing.Point(140, 8);
            this.txtSubjectName.Name = "txtSubjectName";
            this.txtSubjectName.Size = new System.Drawing.Size(208, 25);
            this.txtSubjectName.TabIndex = 0;
            this.txtSubjectName.Tag = "subjectname";
            this.txtSubjectName.Validating += new System.ComponentModel.CancelEventHandler(this.txtSubjectName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Subject Name";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(423, 58);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(182, 225);
            this.listBox1.TabIndex = 200;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // txtSubjectNo
            // 
            this.txtSubjectNo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtSubjectNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectNo.ForeColor = System.Drawing.Color.Blue;
            this.txtSubjectNo.Location = new System.Drawing.Point(586, 286);
            this.txtSubjectNo.MaxLength = 30;
            this.txtSubjectNo.Name = "txtSubjectNo";
            this.txtSubjectNo.Size = new System.Drawing.Size(22, 25);
            this.txtSubjectNo.TabIndex = 130;
            this.txtSubjectNo.TabStop = false;
            this.txtSubjectNo.Tag = "subjectno";
            this.txtSubjectNo.Visible = false;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.BackColor = System.Drawing.Color.Transparent;
            this.label45.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.White;
            this.label45.Location = new System.Drawing.Point(3, 76);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(133, 19);
            this.label45.TabIndex = 165;
            this.label45.Text = "Type Of Subject";
            // 
            // cmbboard
            // 
            this.cmbboard.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbboard.ForeColor = System.Drawing.Color.Blue;
            this.cmbboard.FormattingEnabled = true;
            this.cmbboard.Items.AddRange(new object[] {
            "Core Subject",
            "Elective Subject"});
            this.cmbboard.Location = new System.Drawing.Point(140, 74);
            this.cmbboard.Name = "cmbboard";
            this.cmbboard.Size = new System.Drawing.Size(208, 25);
            this.cmbboard.TabIndex = 1;
            this.cmbboard.Tag = "subjecttype";
            this.cmbboard.Text = "-SELECT-";
            // 
            // txtSubjectCode
            // 
            this.txtSubjectCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubjectCode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectCode.ForeColor = System.Drawing.Color.Blue;
            this.txtSubjectCode.Location = new System.Drawing.Point(140, 41);
            this.txtSubjectCode.Name = "txtSubjectCode";
            this.txtSubjectCode.Size = new System.Drawing.Size(208, 25);
            this.txtSubjectCode.TabIndex = 202;
            this.txtSubjectCode.Tag = "SubjectCode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.label3.TabIndex = 203;
            this.label3.Text = "Subject Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 205;
            this.label4.Text = "Order Of List";
            // 
            // cmbSubjectOrder
            // 
            this.cmbSubjectOrder.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSubjectOrder.ForeColor = System.Drawing.Color.Blue;
            this.cmbSubjectOrder.FormattingEnabled = true;
            this.cmbSubjectOrder.Location = new System.Drawing.Point(140, 108);
            this.cmbSubjectOrder.Name = "cmbSubjectOrder";
            this.cmbSubjectOrder.Size = new System.Drawing.Size(80, 25);
            this.cmbSubjectOrder.TabIndex = 204;
            this.cmbSubjectOrder.Tag = "subjecttype";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtSubjectName);
            this.panel2.Controls.Add(this.cmbSubjectOrder);
            this.panel2.Controls.Add(this.cmbboard);
            this.panel2.Controls.Add(this.txtSubjectCode);
            this.panel2.Controls.Add(this.label45);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(57, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 225);
            this.panel2.TabIndex = 206;
            // 
            // Frmsubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtSubjectNo);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frmsubject";
            this.Size = new System.Drawing.Size(667, 357);
            this.Tag = "1117";
            this.Load += new System.EventHandler(this.Frmsubject_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Frmsubject_Paint);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox txtSubjectNo;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox cmbboard;
        private System.Windows.Forms.TextBox txtSubjectCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSubjectOrder;
        private System.Windows.Forms.Panel panel2;
    }
}