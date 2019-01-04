namespace SMS
{
    partial class PlaceHolderForm
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
            this.pnlButtonContainer = new System.Windows.Forms.Panel();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlButtonContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlButtonContainer
            // 
            this.pnlButtonContainer.BackColor = System.Drawing.SystemColors.Control;
            this.pnlButtonContainer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlButtonContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlButtonContainer.Controls.Add(this.btnnew);
            this.pnlButtonContainer.Controls.Add(this.btnexit);
            this.pnlButtonContainer.Controls.Add(this.btnprint);
            this.pnlButtonContainer.Controls.Add(this.btnedit);
            this.pnlButtonContainer.Controls.Add(this.btndelete);
            this.pnlButtonContainer.Controls.Add(this.btncancel);
            this.pnlButtonContainer.Controls.Add(this.btnsave);
            this.pnlButtonContainer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtonContainer.Location = new System.Drawing.Point(0, 403);
            this.pnlButtonContainer.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pnlButtonContainer.Name = "pnlButtonContainer";
            this.pnlButtonContainer.Size = new System.Drawing.Size(1250, 95);
            this.pnlButtonContainer.TabIndex = 183;
            // 
            // btnnew
            // 
            this.btnnew.BackColor = System.Drawing.Color.White;
            this.btnnew.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnnew.ForeColor = System.Drawing.Color.Black;
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnew.Location = new System.Drawing.Point(-5, -5);
            this.btnnew.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(176, 100);
            this.btnnew.TabIndex = 3;
            this.btnnew.Text = "&New";
            this.btnnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnew.UseCompatibleTextRendering = true;
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.Black;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexit.Location = new System.Drawing.Point(1027, -5);
            this.btnexit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(156, 100);
            this.btnexit.TabIndex = 1;
            this.btnexit.Text = "E&xit";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.White;
            this.btnprint.Enabled = false;
            this.btnprint.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.ForeColor = System.Drawing.Color.Black;
            this.btnprint.Image = global::SMS.Properties.Resources.Print1;
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnprint.Location = new System.Drawing.Point(872, -5);
            this.btnprint.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(155, 100);
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "&Print";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.White;
            this.btnedit.Enabled = false;
            this.btnedit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.Black;
            this.btnedit.Image = global::SMS.Properties.Resources.edit;
            this.btnedit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnedit.Location = new System.Drawing.Point(171, -5);
            this.btnedit.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(171, 100);
            this.btnedit.TabIndex = 4;
            this.btnedit.Text = "E&dit";
            this.btnedit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnedit.UseCompatibleTextRendering = true;
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.White;
            this.btndelete.Enabled = false;
            this.btndelete.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.Black;
            this.btndelete.Image = global::SMS.Properties.Resources.edit_delete;
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.Location = new System.Drawing.Point(341, -5);
            this.btndelete.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(187, 100);
            this.btndelete.TabIndex = 5;
            this.btndelete.Text = "Dele&te";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.Enabled = false;
            this.btncancel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.Black;
            this.btncancel.Image = global::SMS.Properties.Resources.cancel;
            this.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancel.Location = new System.Drawing.Point(688, -5);
            this.btncancel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(184, 100);
            this.btncancel.TabIndex = 2;
            this.btncancel.Text = "&Cancel";
            this.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.Enabled = false;
            this.btnsave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.Image = global::SMS.Properties.Resources.save;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(528, -5);
            this.btnsave.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(160, 100);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Sa&ve";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Location = new System.Drawing.Point(0, 5);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1250, 385);
            this.pnlMain.TabIndex = 184;
            // 
            // PlaceHolderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 498);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlButtonContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PlaceHolderForm";
            this.Text = "PlaceHolderForm";
            this.Load += new System.EventHandler(this.PlaceHolderForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PlaceHolderForm_KeyDown);
            this.pnlButtonContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtonContainer;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Panel pnlMain;
    }
}