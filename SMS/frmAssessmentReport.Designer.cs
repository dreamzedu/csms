namespace SMS
{
    partial class frmAssessmentReport
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
            this.btnShow = new System.Windows.Forms.Button();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbScetion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackView = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(776, 56);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(92, 34);
            this.btnShow.TabIndex = 43;
            this.btnShow.Text = "S&how";
            this.btnShow.UseVisualStyleBackColor = true;
            // 
            // cmbSession
            // 
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(174, 61);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(160, 24);
            this.cmbSession.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(69, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Session";
            // 
            // cmbScetion
            // 
            this.cmbScetion.FormattingEnabled = true;
            this.cmbScetion.Location = new System.Drawing.Point(646, 62);
            this.cmbScetion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbScetion.Name = "cmbScetion";
            this.cmbScetion.Size = new System.Drawing.Size(107, 24);
            this.cmbScetion.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(557, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "Section";
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(425, 62);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(108, 24);
            this.cmbClass.TabIndex = 41;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(353, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Class";
            // 
            // btnBackView
            // 
            this.btnBackView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackView.Location = new System.Drawing.Point(1061, 642);
            this.btnBackView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBackView.Name = "btnBackView";
            this.btnBackView.Size = new System.Drawing.Size(147, 37);
            this.btnBackView.TabIndex = 48;
            this.btnBackView.Text = "View Back ";
            this.btnBackView.UseVisualStyleBackColor = true;
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.Location = new System.Drawing.Point(906, 642);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(147, 37);
            this.btnViewReport.TabIndex = 47;
            this.btnViewReport.Text = "View Front";
            this.btnViewReport.UseVisualStyleBackColor = true;
            // 
            // frmAssessmentReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnBackView);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbScetion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmAssessmentReport";
            this.Size = new System.Drawing.Size(1225, 690);
            this.Load += new System.EventHandler(this.frmAssessmentReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbScetion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBackView;
        private System.Windows.Forms.Button btnViewReport;
    }
}