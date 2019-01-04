namespace SMS
{
    partial class ConfirmNewScholarNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmNewScholarNo));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtScholarNo = new System.Windows.Forms.TextBox();
            this.lblSnoExists = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAutoGenerate = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblScholarNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(636, 418);
            this.btnOk.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 54);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(818, 418);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 54);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtScholarNo
            // 
            this.txtScholarNo.Location = new System.Drawing.Point(332, 194);
            this.txtScholarNo.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtScholarNo.Name = "txtScholarNo";
            this.txtScholarNo.Size = new System.Drawing.Size(196, 38);
            this.txtScholarNo.TabIndex = 3;
            // 
            // lblSnoExists
            // 
            this.lblSnoExists.AutoSize = true;
            this.lblSnoExists.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSnoExists.Location = new System.Drawing.Point(138, 45);
            this.lblSnoExists.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSnoExists.Name = "lblSnoExists";
            this.lblSnoExists.Size = new System.Drawing.Size(636, 36);
            this.lblSnoExists.TabIndex = 4;
            this.lblSnoExists.Text = "A student with same Scholar No already exists.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 124);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1441, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "If you want to recover this student with different scholar no then please enter a" +
    " new scholar no and click \'OK\'";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 194);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 36);
            this.label3.TabIndex = 6;
            this.label3.Text = "New Scholar No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 322);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(813, 36);
            this.label4.TabIndex = 7;
            this.label4.Text = "If you DO NOT want to recover this record then click \'Cancel\'";
            // 
            // btnAutoGenerate
            // 
            this.btnAutoGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoGenerate.Location = new System.Drawing.Point(578, 190);
            this.btnAutoGenerate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAutoGenerate.Name = "btnAutoGenerate";
            this.btnAutoGenerate.Size = new System.Drawing.Size(254, 54);
            this.btnAutoGenerate.TabIndex = 8;
            this.btnAutoGenerate.Text = "Auto Generate";
            this.btnAutoGenerate.UseVisualStyleBackColor = true;
            this.btnAutoGenerate.Click += new System.EventHandler(this.btnAutoGenerate_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(40, 250);
            this.lblError.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 31);
            this.lblError.TabIndex = 9;
            // 
            // lblScholarNo
            // 
            this.lblScholarNo.AutoSize = true;
            this.lblScholarNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScholarNo.Location = new System.Drawing.Point(40, 48);
            this.lblScholarNo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblScholarNo.Name = "lblScholarNo";
            this.lblScholarNo.Size = new System.Drawing.Size(0, 36);
            this.lblScholarNo.TabIndex = 10;
            // 
            // ConfirmNewScholarNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1796, 589);
            this.ControlBox = false;
            this.Controls.Add(this.lblScholarNo);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnAutoGenerate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSnoExists);
            this.Controls.Add(this.txtScholarNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfirmNewScholarNo";
            this.ShowInTaskbar = false;
            this.Text = "Confirm New ScholarNo";
            this.Load += new System.EventHandler(this.ConfirmNewScholarNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtScholarNo;
        private System.Windows.Forms.Label lblSnoExists;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAutoGenerate;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblScholarNo;
    }
}