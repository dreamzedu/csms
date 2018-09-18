namespace SMS.MpBoardMarksheet.ReportForm
{
    partial class frmMPCCEMarkSheetM
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
            this.btnBackView = new System.Windows.Forms.Button();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbScetion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBackView
            // 
            this.btnBackView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackView.Location = new System.Drawing.Point(571, 113);
            this.btnBackView.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackView.Name = "btnBackView";
            this.btnBackView.Size = new System.Drawing.Size(147, 37);
            this.btnBackView.TabIndex = 45;
            this.btnBackView.Text = "View Back ";
            this.btnBackView.UseVisualStyleBackColor = true;
            this.btnBackView.Click += new System.EventHandler(this.btnBackView_Click);
            // 
            // cmbSession
            // 
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(111, 49);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(160, 24);
            this.cmbSession.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 49;
            this.label3.Text = "Session";
            // 
            // cmbScetion
            // 
            this.cmbScetion.FormattingEnabled = true;
            this.cmbScetion.Location = new System.Drawing.Point(610, 48);
            this.cmbScetion.Margin = new System.Windows.Forms.Padding(4);
            this.cmbScetion.Name = "cmbScetion";
            this.cmbScetion.Size = new System.Drawing.Size(107, 24);
            this.cmbScetion.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(527, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "Section";
            // 
            // btnViewReport
            // 
            this.btnViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReport.Location = new System.Drawing.Point(417, 113);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(147, 37);
            this.btnViewReport.TabIndex = 44;
            this.btnViewReport.Text = "View Front";
            this.btnViewReport.UseVisualStyleBackColor = true;
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(381, 48);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(108, 24);
            this.cmbClass.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(312, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "Class";
            // 
            // frmMPCCEMarkSheetM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBackView);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbScetion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMPCCEMarkSheetM";
            this.Size = new System.Drawing.Size(757, 177);
            this.Load += new System.EventHandler(this.frmMPCCEMarkSheetM_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMPCCEMarkSheetM_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBackView;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbScetion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label1;
    }
}