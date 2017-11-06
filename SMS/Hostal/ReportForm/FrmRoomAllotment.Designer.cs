namespace SMS.Hostal.ReportForm
{
    partial class FrmRoomAllotment
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
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cmbHostelName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAllottRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.label3.Location = new System.Drawing.Point(129, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 24);
            this.label3.TabIndex = 189;
            this.label3.Text = "Allot Position Report";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(331, 71);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 30);
            this.btnCancel.TabIndex = 186;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbHostelName
            // 
            this.cmbHostelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHostelName.FormattingEnabled = true;
            this.cmbHostelName.Location = new System.Drawing.Point(175, 40);
            this.cmbHostelName.Name = "cmbHostelName";
            this.cmbHostelName.Size = new System.Drawing.Size(240, 24);
            this.cmbHostelName.TabIndex = 184;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(41, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 188;
            this.label2.Text = "Select Hostel";
            // 
            // btnAllottRoom
            // 
            this.btnAllottRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAllottRoom.ForeColor = System.Drawing.Color.Black;
            this.btnAllottRoom.Location = new System.Drawing.Point(247, 71);
            this.btnAllottRoom.Name = "btnAllottRoom";
            this.btnAllottRoom.Size = new System.Drawing.Size(84, 30);
            this.btnAllottRoom.TabIndex = 185;
            this.btnAllottRoom.Text = "Ok";
            this.btnAllottRoom.UseVisualStyleBackColor = true;
            this.btnAllottRoom.Click += new System.EventHandler(this.btnAllottRoom_Click);
            // 
            // FrmRoomAllotment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(430, 130);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbHostelName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAllottRoom);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRoomAllotment";
            this.Text = "FrmRoomAllotment";
            this.Load += new System.EventHandler(this.FrmRoomAllotment_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmRoomAllotment_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbHostelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAllottRoom;
    }
}