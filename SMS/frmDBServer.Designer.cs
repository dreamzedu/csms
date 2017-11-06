namespace SMS
{
    partial class frmDBServer
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
            this.dtgResult = new System.Windows.Forms.DataGridView();
            this.txtCommand = new System.Windows.Forms.RichTextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgResult
            // 
            this.dtgResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgResult.Location = new System.Drawing.Point(0, 189);
            this.dtgResult.Name = "dtgResult";
            this.dtgResult.Size = new System.Drawing.Size(896, 335);
            this.dtgResult.TabIndex = 0;
            // 
            // txtCommand
            // 
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtCommand.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCommand.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtCommand.Location = new System.Drawing.Point(0, 59);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(896, 130);
            this.txtCommand.TabIndex = 1;
            this.txtCommand.Text = "";
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRun.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRun.Location = new System.Drawing.Point(719, 13);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 40);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.DarkRed;
            this.lblResult.Location = new System.Drawing.Point(13, 13);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 16);
            this.lblResult.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(800, 14);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(70, 39);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmDBServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 524);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.dtgResult);
            this.Name = "frmDBServer";
            this.Text = "Database Server";
            this.Load += new System.EventHandler(this.frmDBServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgResult;
        private System.Windows.Forms.RichTextBox txtCommand;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnExit;
    }
}