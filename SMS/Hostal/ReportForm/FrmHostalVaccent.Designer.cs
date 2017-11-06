namespace SMS.Hostal.ReportForm
{
    partial class FrmHostalVaccent
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
            this.btnVacatRoom = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.label3.Location = new System.Drawing.Point(139, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 24);
            this.label3.TabIndex = 193;
            this.label3.Text = "Room Vaccent ";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(300, 71);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 190;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // cmbHostelName
            // 
            this.cmbHostelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHostelName.FormattingEnabled = true;
            this.cmbHostelName.Location = new System.Drawing.Point(148, 40);
            this.cmbHostelName.Name = "cmbHostelName";
            this.cmbHostelName.Size = new System.Drawing.Size(252, 24);
            this.cmbHostelName.TabIndex = 188;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 192;
            this.label2.Text = "Select Hostel";
            // 
            // btnVacatRoom
            // 
            this.btnVacatRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnVacatRoom.ForeColor = System.Drawing.Color.Black;
            this.btnVacatRoom.Location = new System.Drawing.Point(200, 71);
            this.btnVacatRoom.Name = "btnVacatRoom";
            this.btnVacatRoom.Size = new System.Drawing.Size(100, 30);
            this.btnVacatRoom.TabIndex = 189;
            this.btnVacatRoom.Text = "Ok";
            this.btnVacatRoom.UseVisualStyleBackColor = true;
            this.btnVacatRoom.Click += new System.EventHandler(this.btnVacatRoom_Click);
            // 
            // FrmHostalVaccent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(430, 130);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbHostelName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnVacatRoom);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmHostalVaccent";
            this.Text = "FrmHostalVaccent";
            this.Load += new System.EventHandler(this.FrmHostalVaccent_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmHostalVaccent_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbHostelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVacatRoom;
    }
}