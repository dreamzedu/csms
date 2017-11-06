namespace SMS.Hostal.ReportForm
{
    partial class FrmStudentFee
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPerticularStudentFeeReport = new System.Windows.Forms.Label();
            this.tbnlblPerticularStudentFeeReport = new System.Windows.Forms.Button();
            this.lblScholarNo = new System.Windows.Forms.Label();
            this.txtScholarNo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(300, 71);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 176;
            this.btnCancel.Tag = "173";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblPerticularStudentFeeReport
            // 
            this.lblPerticularStudentFeeReport.AutoSize = true;
            this.lblPerticularStudentFeeReport.BackColor = System.Drawing.Color.Transparent;
            this.lblPerticularStudentFeeReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.lblPerticularStudentFeeReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.lblPerticularStudentFeeReport.Location = new System.Drawing.Point(121, 4);
            this.lblPerticularStudentFeeReport.Name = "lblPerticularStudentFeeReport";
            this.lblPerticularStudentFeeReport.Size = new System.Drawing.Size(188, 24);
            this.lblPerticularStudentFeeReport.TabIndex = 178;
            this.lblPerticularStudentFeeReport.Text = "Student Hostal Fee";
            // 
            // tbnlblPerticularStudentFeeReport
            // 
            this.tbnlblPerticularStudentFeeReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.tbnlblPerticularStudentFeeReport.ForeColor = System.Drawing.Color.Black;
            this.tbnlblPerticularStudentFeeReport.Location = new System.Drawing.Point(200, 71);
            this.tbnlblPerticularStudentFeeReport.Name = "tbnlblPerticularStudentFeeReport";
            this.tbnlblPerticularStudentFeeReport.Size = new System.Drawing.Size(100, 30);
            this.tbnlblPerticularStudentFeeReport.TabIndex = 175;
            this.tbnlblPerticularStudentFeeReport.Text = "Ok";
            this.tbnlblPerticularStudentFeeReport.UseVisualStyleBackColor = true;
            this.tbnlblPerticularStudentFeeReport.Click += new System.EventHandler(this.tbnlblPerticularStudentFeeReport_Click);
            // 
            // lblScholarNo
            // 
            this.lblScholarNo.AutoSize = true;
            this.lblScholarNo.BackColor = System.Drawing.Color.Transparent;
            this.lblScholarNo.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblScholarNo.ForeColor = System.Drawing.Color.White;
            this.lblScholarNo.Location = new System.Drawing.Point(31, 43);
            this.lblScholarNo.Name = "lblScholarNo";
            this.lblScholarNo.Size = new System.Drawing.Size(84, 16);
            this.lblScholarNo.TabIndex = 177;
            this.lblScholarNo.Text = "Scholar No";
            // 
            // txtScholarNo
            // 
            this.txtScholarNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScholarNo.Location = new System.Drawing.Point(160, 40);
            this.txtScholarNo.Name = "txtScholarNo";
            this.txtScholarNo.Size = new System.Drawing.Size(240, 23);
            this.txtScholarNo.TabIndex = 174;
            // 
            // FrmStudentFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(430, 130);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblPerticularStudentFeeReport);
            this.Controls.Add(this.tbnlblPerticularStudentFeeReport);
            this.Controls.Add(this.lblScholarNo);
            this.Controls.Add(this.txtScholarNo);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmStudentFee";
            this.Text = "FrmStudentFee";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmStudentFee_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblPerticularStudentFeeReport;
        private System.Windows.Forms.Button tbnlblPerticularStudentFeeReport;
        private System.Windows.Forms.Label lblScholarNo;
        private System.Windows.Forms.TextBox txtScholarNo;
    }
}