namespace SMS
{
    partial class frmAcademicSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcademicSession));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.chkSetSession = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Academic Session";
            // 
            // cmbSession
            // 
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(203, 71);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(224, 24);
            this.cmbSession.TabIndex = 1;
            
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(190, 175);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 29);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // chkSetSession
            // 
            this.chkSetSession.AutoSize = true;
            this.chkSetSession.Checked = true;
            this.chkSetSession.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSetSession.Location = new System.Drawing.Point(203, 112);
            this.chkSetSession.Name = "chkSetSession";
            this.chkSetSession.Size = new System.Drawing.Size(235, 21);
            this.chkSetSession.TabIndex = 4;
            this.chkSetSession.Text = "Set as current academic session";
            this.chkSetSession.UseVisualStyleBackColor = true;
            // 
            // frmAcademicSession
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 251);
            this.ControlBox = false;
            this.Controls.Add(this.chkSetSession);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAcademicSession";
            this.ShowInTaskbar = false;
            this.Text = "Select Academic Session";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.CheckBox chkSetSession;
    }
}