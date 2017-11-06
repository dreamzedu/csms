namespace SMS
{
    partial class frmtehsil

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtsankaycode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.valcmbdistrict = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtsankayname
            // 
            this.txtsankayname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsankayname.ForeColor = System.Drawing.Color.Blue;
            this.txtsankayname.Location = new System.Drawing.Point(124, 9);
            this.txtsankayname.Name = "txtsankayname";
            this.txtsankayname.Size = new System.Drawing.Size(195, 25);
            this.txtsankayname.TabIndex = 156;
            this.txtsankayname.Tag = "tehsil";
            this.txtsankayname.TextChanged += new System.EventHandler(this.txtsankayname_TextChanged);
            this.txtsankayname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsankayname_KeyPress);
            this.txtsankayname.Validated += new System.EventHandler(this.txtsankayname_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Tehsil Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.Color.Blue;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(357, 60);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(183, 174);
            this.listBox1.TabIndex = 31;
            this.listBox1.TabStop = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnnew);
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.btnedit);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btncancel);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Location = new System.Drawing.Point(36, 268);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 42);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.SystemColors.Control;
            this.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnnew.ForeColor = System.Drawing.Color.Black;
            this.btnnew.Location = new System.Drawing.Point(0, 6);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(70, 28);
            this.btnnew.TabIndex = 0;
            this.btnnew.Text = "&New";
            this.btnnew.UseCompatibleTextRendering = true;
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.SystemColors.Control;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnexit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnexit.ForeColor = System.Drawing.Color.Black;
            this.btnexit.Location = new System.Drawing.Point(420, 6);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(70, 28);
            this.btnexit.TabIndex = 6;
            this.btnexit.Text = "E&xit";
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.SystemColors.Control;
            this.btnprint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnprint.ForeColor = System.Drawing.Color.Black;
            this.btnprint.Location = new System.Drawing.Point(350, 6);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(70, 28);
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "&Print";
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.SystemColors.Control;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnedit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnedit.ForeColor = System.Drawing.Color.Black;
            this.btnedit.Location = new System.Drawing.Point(70, 6);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(70, 28);
            this.btnedit.TabIndex = 1;
            this.btnedit.Text = "E&dit";
            this.btnedit.UseCompatibleTextRendering = true;
            this.btnedit.UseVisualStyleBackColor = true;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.SystemColors.Control;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btndelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btndelete.ForeColor = System.Drawing.Color.Black;
            this.btndelete.Location = new System.Drawing.Point(140, 6);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(70, 28);
            this.btndelete.TabIndex = 2;
            this.btndelete.Text = "Dele&te";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.SystemColors.Control;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btncancel.ForeColor = System.Drawing.Color.Black;
            this.btncancel.Location = new System.Drawing.Point(280, 6);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(70, 28);
            this.btncancel.TabIndex = 4;
            this.btncancel.Text = "&Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.SystemColors.Control;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.Location = new System.Drawing.Point(210, 6);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(70, 28);
            this.btnsave.TabIndex = 3;
            this.btnsave.Text = "Sa&ve";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtsankaycode
            // 
            this.txtsankaycode.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.txtsankaycode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsankaycode.ForeColor = System.Drawing.Color.Blue;
            this.txtsankaycode.Location = new System.Drawing.Point(239, 116);
            this.txtsankaycode.MaxLength = 30;
            this.txtsankaycode.Name = "txtsankaycode";
            this.txtsankaycode.Size = new System.Drawing.Size(62, 25);
            this.txtsankaycode.TabIndex = 129;
            this.txtsankaycode.TabStop = false;
            this.txtsankaycode.Tag = "tehcode";
            this.txtsankaycode.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 130;
            this.label2.Text = "District Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // valcmbdistrict
            // 
            this.valcmbdistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.valcmbdistrict.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbdistrict.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.valcmbdistrict.FormattingEnabled = true;
            this.valcmbdistrict.Items.AddRange(new object[] {
            "Studing",
            "Terminate"});
            this.valcmbdistrict.Location = new System.Drawing.Point(124, 56);
            this.valcmbdistrict.Name = "valcmbdistrict";
            this.valcmbdistrict.Size = new System.Drawing.Size(195, 25);
            this.valcmbdistrict.TabIndex = 160;
            this.valcmbdistrict.Tag = "distcode";
            this.valcmbdistrict.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtsankayname_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(198, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 24);
            this.label3.TabIndex = 161;
            this.label3.Text = "Tehsil Setup";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.valcmbdistrict);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtsankaycode);
            this.panel2.Controls.Add(this.txtsankayname);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(23, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 174);
            this.panel2.TabIndex = 162;
            // 
            // frmtehsil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(564, 322);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmtehsil";
            this.Tag = "28";
            this.Load += new System.EventHandler(this.frmsankay_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmtehsil_Paint);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtsankayname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtsankaycode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox valcmbdistrict;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
    }
}