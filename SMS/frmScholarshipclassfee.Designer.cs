namespace SMS
{
    partial class frmScholarshipclassfee
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
            this.dtgfeeheads = new System.Windows.Forms.DataGridView();
            this.Pk_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Classcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgfeeheads)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgfeeheads
            // 
            this.dtgfeeheads.AllowUserToAddRows = false;
            this.dtgfeeheads.AllowUserToDeleteRows = false;
            this.dtgfeeheads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgfeeheads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pk_Id,
            this.Classcode,
            this.classname,
            this.Category,
            this.Amount});
            this.dtgfeeheads.Location = new System.Drawing.Point(57, 88);
            this.dtgfeeheads.Margin = new System.Windows.Forms.Padding(4);
            this.dtgfeeheads.Name = "dtgfeeheads";
            this.dtgfeeheads.Size = new System.Drawing.Size(545, 298);
            this.dtgfeeheads.TabIndex = 164;
            // 
            // Pk_Id
            // 
            this.Pk_Id.DataPropertyName = "Pk_Id";
            this.Pk_Id.HeaderText = "Column1";
            this.Pk_Id.Name = "Pk_Id";
            this.Pk_Id.Visible = false;
            // 
            // Classcode
            // 
            this.Classcode.DataPropertyName = "Classcode";
            this.Classcode.HeaderText = "Column1";
            this.Classcode.Name = "Classcode";
            this.Classcode.Visible = false;
            // 
            // classname
            // 
            this.classname.DataPropertyName = "classname";
            this.classname.HeaderText = "Class";
            this.classname.Name = "classname";
            this.classname.Visible = false;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            // 
            // cmbclass
            // 
            this.cmbclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Items.AddRange(new object[] {
            "Year Fee",
            "Regular Fee"});
            this.cmbclass.Location = new System.Drawing.Point(125, 57);
            this.cmbclass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(188, 25);
            this.cmbclass.TabIndex = 163;
            this.cmbclass.Text = "-Select-";
            this.cmbclass.SelectedIndexChanged += new System.EventHandler(this.cmbclass_SelectedIndexChanged);
            this.cmbclass.Validating += new System.ComponentModel.CancelEventHandler(this.cmbclass_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(54, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 166;
            this.label2.Text = "Class ";
            // 
            // frmScholarshipclassfee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtgfeeheads);
            this.Controls.Add(this.cmbclass);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmScholarshipclassfee";
            this.Size = new System.Drawing.Size(616, 438);
            this.Load += new System.EventHandler(this.frmScholarshipclassfee_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmScholarshipclassfee_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgfeeheads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgfeeheads;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pk_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Classcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn classname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}