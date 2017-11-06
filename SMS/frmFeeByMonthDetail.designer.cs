namespace SMS
{
    partial class frmFeeByMonthDetail
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
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbclassname = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chkClass = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSession
            // 
            this.cmbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.Blue;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(192, 56);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(157, 28);
            this.cmbSession.TabIndex = 0;
            this.cmbSession.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSession_KeyPress);
            this.cmbSession.Leave += new System.EventHandler(this.cmbSession_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 50;
            this.label1.Text = "Session Name";
            // 
            // cmbclassname
            // 
            this.cmbclassname.Enabled = false;
            this.cmbclassname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclassname.ForeColor = System.Drawing.Color.Blue;
            this.cmbclassname.FormattingEnabled = true;
            this.cmbclassname.Location = new System.Drawing.Point(547, 56);
            this.cmbclassname.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclassname.Name = "cmbclassname";
            this.cmbclassname.Size = new System.Drawing.Size(143, 28);
            this.cmbclassname.TabIndex = 2;
            this.cmbclassname.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbclassname_KeyPress);
            this.cmbclassname.Leave += new System.EventHandler(this.cmbclassname_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(1191, 558);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(64, 95);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1207, 455);
            this.dataGridView1.TabIndex = 57;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // chkClass
            // 
            this.chkClass.AutoSize = true;
            this.chkClass.BackColor = System.Drawing.Color.Transparent;
            this.chkClass.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkClass.ForeColor = System.Drawing.Color.White;
            this.chkClass.Location = new System.Drawing.Point(421, 59);
            this.chkClass.Margin = new System.Windows.Forms.Padding(4);
            this.chkClass.Name = "chkClass";
            this.chkClass.Size = new System.Drawing.Size(118, 23);
            this.chkClass.TabIndex = 1;
            this.chkClass.Text = "Class Wise";
            this.chkClass.UseVisualStyleBackColor = false;
            this.chkClass.CheckedChanged += new System.EventHandler(this.chkClass_CheckedChanged);
            this.chkClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkClass_KeyPress);
            // 
            // frmFeeByMonthDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.chkClass);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbclassname);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFeeByMonthDetail";
            this.Size = new System.Drawing.Size(1288, 598);
            this.Tag = "1130";
            this.Load += new System.EventHandler(this.frmFeeByMonthDetail_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmFeeByMonthDetail_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbclassname;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox chkClass;
    }
}