namespace SMS.Library
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
            this.label7.Location = new System.Drawing.Point(56, 260);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 38);
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
            this.label2.Location = new System.Drawing.Point(1171, 179);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 38);
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
            this.label5.Location = new System.Drawing.Point(56, 179);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 38);
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
            this.barcodectrl.Location = new System.Drawing.Point(1608, 343);
            this.barcodectrl.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.barcodectrl.Name = "barcodectrl";
            this.barcodectrl.ShowFooter = false;
            this.barcodectrl.ShowHeader = false;
            this.barcodectrl.Size = new System.Drawing.Size(515, 186);
            this.barcodectrl.TabIndex = 187;
            this.barcodectrl.TopMargin = 10;
            this.barcodectrl.VertAlign = DSBarCode.BarCodeCtrl.AlignType.Center;
            this.barcodectrl.Visible = false;
            this.barcodectrl.Weight = DSBarCode.BarCodeCtrl.BarCodeWeight.Small;
            // 
            // BtnShowBook
            // 
            this.BtnShowBook.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowBook.Location = new System.Drawing.Point(1853, 71);
            this.BtnShowBook.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.BtnShowBook.Name = "BtnShowBook";
            this.BtnShowBook.Size = new System.Drawing.Size(229, 59);
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
            this.label1.Location = new System.Drawing.Point(56, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 38);
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
            this.dtgbook.Location = new System.Drawing.Point(51, 343);
            this.dtgbook.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.Size = new System.Drawing.Size(2032, 508);
            this.dtgbook.TabIndex = 183;
            this.dtgbook.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgbook_CellContentClick);
            this.dtgbook.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgbook_CellValidated);
            this.dtgbook.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgbook_KeyDown);
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
            this.valcmbbook.Location = new System.Drawing.Point(285, 83);
            this.valcmbbook.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.valcmbbook.Name = "valcmbbook";
            this.valcmbbook.Size = new System.Drawing.Size(1516, 43);
            this.valcmbbook.TabIndex = 181;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1171, 260);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 38);
            this.label6.TabIndex = 191;
            this.label6.Text = "Publishers";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(51, 858);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(807, 38);
            this.label3.TabIndex = 195;
            this.label3.Text = "For Add Book Title Click on Grid and Press Ctrl+F3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // FmTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BtnShowBook);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgbook);
            this.Controls.Add(this.valcmbbook);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.barcodectrl);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FmTitle";
            this.Size = new System.Drawing.Size(2136, 911);
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