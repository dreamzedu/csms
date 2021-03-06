﻿namespace SMS.Library
{
    partial class FmTitle
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
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.barcodectrl = new DSBarCode.BarCodeCtrl();
            this.BtnShowBook = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgbook = new System.Windows.Forms.DataGridView();
            this.bookno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.booktitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Granttype = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Edition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noofpage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Publyr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clbar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valcmbbook = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(21, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 190;
            this.label7.Text = "Subject";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(439, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 189;
            this.label2.Text = "Author";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(21, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 16);
            this.label5.TabIndex = 188;
            this.label5.Text = "Book sub Title";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // barcodectrl
            // 
            this.barcodectrl.BarCode = "";
            this.barcodectrl.BarCodeHeight = 50;
            this.barcodectrl.FooterFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.barcodectrl.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.barcodectrl.HeaderText = "BarCode Demo";
            this.barcodectrl.LeftMargin = 10;
            this.barcodectrl.Location = new System.Drawing.Point(603, 144);
            this.barcodectrl.Name = "barcodectrl";
            this.barcodectrl.ShowFooter = false;
            this.barcodectrl.ShowHeader = false;
            this.barcodectrl.Size = new System.Drawing.Size(193, 78);
            this.barcodectrl.TabIndex = 187;
            this.barcodectrl.TopMargin = 10;
            this.barcodectrl.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Center;
            this.barcodectrl.Visible = false;
            this.barcodectrl.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small;
            // 
            // BtnShowBook
            // 
            this.BtnShowBook.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowBook.Location = new System.Drawing.Point(695, 29);
            this.BtnShowBook.Name = "BtnShowBook";
            this.BtnShowBook.Size = new System.Drawing.Size(86, 34);
            this.BtnShowBook.TabIndex = 182;
            this.BtnShowBook.Text = "&Select Book";
            this.BtnShowBook.UseVisualStyleBackColor = true;
            this.BtnShowBook.Click += new System.EventHandler(this.BtnShowBook_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(21, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 186;
            this.label1.Text = "Book Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtgbook
            // 
            this.dtgbook.AllowUserToAddRows = false;
            this.dtgbook.AllowUserToDeleteRows = false;
            this.dtgbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookno,
            this.booktitle,
            this.prize,
            this.Granttype,
            this.Edition,
            this.noofpage,
            this.Publyr,
            this.clbar});
            this.dtgbook.Location = new System.Drawing.Point(19, 144);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.Size = new System.Drawing.Size(762, 213);
            this.dtgbook.TabIndex = 183;
            this.dtgbook.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgbook_CellValidated);
            this.dtgbook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgbook_KeyDown);
            this.dtgbook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgbook_CellContentClick);
            // 
            // bookno
            // 
            this.bookno.HeaderText = "Book No";
            this.bookno.Name = "bookno";
            this.bookno.ReadOnly = true;
            this.bookno.Width = 80;
            // 
            // booktitle
            // 
            this.booktitle.HeaderText = "Title No";
            this.booktitle.Name = "booktitle";
            this.booktitle.Width = 80;
            // 
            // prize
            // 
            this.prize.HeaderText = "Price";
            this.prize.Name = "prize";
            // 
            // Granttype
            // 
            this.Granttype.HeaderText = "Grant By";
            this.Granttype.Items.AddRange(new object[] {
            "Autonomous",
            "UGC",
            "Book Bank",
            "Development",
            "Donated"});
            this.Granttype.Name = "Granttype";
            this.Granttype.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Granttype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Granttype.Width = 150;
            // 
            // Edition
            // 
            this.Edition.HeaderText = "Edition";
            this.Edition.Name = "Edition";
            // 
            // noofpage
            // 
            this.noofpage.HeaderText = "No Of Pages";
            this.noofpage.Name = "noofpage";
            // 
            // Publyr
            // 
            this.Publyr.HeaderText = "Publication Yr.";
            this.Publyr.Name = "Publyr";
            // 
            // clbar
            // 
            this.clbar.HeaderText = "BarCode";
            this.clbar.Name = "clbar";
            this.clbar.Visible = false;
            this.clbar.Width = 150;
            // 
            // valcmbbook
            // 
            this.valcmbbook.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbbook.FormattingEnabled = true;
            this.valcmbbook.Location = new System.Drawing.Point(107, 35);
            this.valcmbbook.Name = "valcmbbook";
            this.valcmbbook.Size = new System.Drawing.Size(571, 23);
            this.valcmbbook.TabIndex = 181;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(439, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 191;
            this.label6.Text = "Publishers";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.label41.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label41.Location = new System.Drawing.Point(357, 4);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(86, 19);
            this.label41.TabIndex = 192;
            this.label41.Text = "Book Title";
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.White;
            this.btnsave.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.Black;
            this.btnsave.Image = global::SMS.Properties.Resources.save;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(680, 69);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(60, 42);
            this.btnsave.TabIndex = 193;
            this.btnsave.Text = "Sa&ve";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.White;
            this.btnexit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexit.ForeColor = System.Drawing.Color.Black;
            this.btnexit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexit.Location = new System.Drawing.Point(740, 69);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(40, 42);
            this.btnexit.TabIndex = 194;
            this.btnexit.Text = "E&xit";
            this.btnexit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(19, 360);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 16);
            this.label3.TabIndex = 195;
            this.label3.Text = "For Add Book Title Click on Grid and Press Ctrl+F3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FmTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(801, 382);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnShowBook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgbook);
            this.Controls.Add(this.valcmbbook);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.barcodectrl);
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.KeyPreview = true;
            this.Name = "FmTitle";
            this.Text = "FmTitle";
            this.Load += new System.EventHandler(this.FmTitle_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FmTitle_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private DSBarCode.BarCodeCtrl barcodectrl;
        private System.Windows.Forms.Button BtnShowBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgbook;
        private System.Windows.Forms.ComboBox valcmbbook;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookno;
        private System.Windows.Forms.DataGridViewTextBoxColumn booktitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn prize;
        private System.Windows.Forms.DataGridViewComboBoxColumn Granttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn Edition;
        private System.Windows.Forms.DataGridViewTextBoxColumn noofpage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Publyr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clbar;
        private System.Windows.Forms.Label label3;
    }
}