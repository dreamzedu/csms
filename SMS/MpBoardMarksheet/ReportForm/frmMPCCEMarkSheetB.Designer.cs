namespace SMS.MpBoardMarksheet.ReportForm
{
    partial class frmMPCCEMarkSheetB
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
            this.Btn_Format1 = new System.Windows.Forms.Button();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbScetion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Btn_Format1
            // 
            this.Btn_Format1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Format1.Location = new System.Drawing.Point(570, 107);
            this.Btn_Format1.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Format1.Name = "Btn_Format1";
            this.Btn_Format1.Size = new System.Drawing.Size(147, 37);
            this.Btn_Format1.TabIndex = 62;
            this.Btn_Format1.Text = "Show";
            this.Btn_Format1.UseVisualStyleBackColor = true;
            this.Btn_Format1.Click += new System.EventHandler(this.Btn_Format1_Click);
            // 
            // cmbSession
            // 
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(109, 50);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(160, 24);
            this.cmbSession.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(23, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 60;
            this.label3.Text = "Session";
            // 
            // cmbScetion
            // 
            this.cmbScetion.FormattingEnabled = true;
            this.cmbScetion.Location = new System.Drawing.Point(609, 49);
            this.cmbScetion.Margin = new System.Windows.Forms.Padding(4);
            this.cmbScetion.Name = "cmbScetion";
            this.cmbScetion.Size = new System.Drawing.Size(107, 24);
            this.cmbScetion.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(527, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "Section";
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(380, 50);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(108, 24);
            this.cmbClass.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(312, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 58;
            this.label1.Text = "Class";
            // 
            // frmMPCCEMarkSheetB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_Format1);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbScetion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMPCCEMarkSheetB";
            this.Size = new System.Drawing.Size(757, 176);
            this.Load += new System.EventHandler(this.frmMPCCEMarkSheetB_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMPCCEMarkSheetB_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Format1;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbScetion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label1;
    }
}