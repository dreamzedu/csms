namespace SMS
{
    partial class frmSubjectForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtSubjectNo = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.cmbboard = new System.Windows.Forms.ComboBox();
            this.txtSubjectCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSubjectOrder = new System.Windows.Forms.ComboBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSubjectName
            // 
            this.txtSubjectName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSubjectName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectName.ForeColor = System.Drawing.Color.Blue;
            this.txtSubjectName.Location = new System.Drawing.Point(392, 32);
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
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(238, 34);
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
            this.listBox1.Location = new System.Drawing.Point(18, 31);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(182, 225);
            this.listBox1.TabIndex = 200;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnnew);
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Controls.Add(this.btnedit);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Location = new System.Drawing.Point(203, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 40);
            this.panel1.TabIndex = 11;
            this.panel1.TabStop = true;
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.White;
            this.btnnew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.Color.Black;
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnnew.Location = new System.Drawing.Point(2, 3);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(65, 36);
            this.btnnew.TabIndex = 3;
            this.btnnew.Text = "&New";
            this.btnnew.UseCompatibleTextRendering = true;
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.White;
            this.btnedit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.Black;
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnedit.Location = new System.Drawing.Point(68, 3);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(65, 36);
            this.btnedit.TabIndex = 4;
            this.btnedit.Text = "E&dit";
            this.btnedit.UseCompatibleTextRendering = true;
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.White;
            this.btndelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.Black;
            this.btndelete.Location = new System.Drawing.Point(134, 3);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(65, 36);
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Dele&te";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.Black;
            this.btncancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btncancel.Location = new System.Drawing.Point(266, 3);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(65, 36);
            this.btncancel.TabIndex = 2;
            this.btncancel.Text = "&Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnsave.Location = new System.Drawing.Point(200, 3);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(65, 36);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Sa&ve";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.White;
            this.btnprint.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.Red;
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnprint.Location = new System.Drawing.Point(565, 185);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(10, 31);
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "&Print";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Visible = false;
            // 
            // txtSubjectNo
            // 
            this.txtSubjectNo.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtSubjectNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubjectNo.ForeColor = System.Drawing.Color.Blue;
            this.txtSubjectNo.Location = new System.Drawing.Point(510, 185);
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
            this.label45.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label45.Location = new System.Drawing.Point(238, 101);
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
            this.cmbboard.Location = new System.Drawing.Point(392, 98);
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
            this.txtSubjectCode.Location = new System.Drawing.Point(392, 65);
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
            this.label3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label3.Location = new System.Drawing.Point(238, 67);
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
            this.label4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label4.Location = new System.Drawing.Point(238, 135);
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
            this.cmbSubjectOrder.Location = new System.Drawing.Point(392, 132);
            this.cmbSubjectOrder.Name = "cmbSubjectOrder";
            this.cmbSubjectOrder.Size = new System.Drawing.Size(80, 25);
            this.cmbSubjectOrder.TabIndex = 204;
            this.cmbSubjectOrder.Tag = "subjecttype";
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.Black;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexit.Location = new System.Drawing.Point(332, 3);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(65, 36);
            this.btnexit.TabIndex = 1;
            this.btnexit.Text = "E&xit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // frmSubjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(620, 279);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbSubjectOrder);
            this.Controls.Add(this.txtSubjectCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label45);
            this.Controls.Add(this.cmbboard);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.txtSubjectNo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtSubjectName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSubjectForm";
            this.Tag = "1117";
            this.Load += new System.EventHandler(this.Frmsubject_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Frmsubject_Paint);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSubjectName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtSubjectNo;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ComboBox cmbboard;
        private System.Windows.Forms.TextBox txtSubjectCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSubjectOrder;
        private System.Windows.Forms.Button btnexit;
    }
}