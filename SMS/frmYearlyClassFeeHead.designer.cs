namespace SMS
{
    partial class frmYearlyClassFeeHead
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
            this.Feecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeheads = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feeamt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RTE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.strcmbfaculty = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopyFrom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgfeeheads)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgfeeheads
            // 
            this.dtgfeeheads.AllowUserToAddRows = false;
            this.dtgfeeheads.AllowUserToDeleteRows = false;
            this.dtgfeeheads.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgfeeheads.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Feecode,
            this.feeheads,
            this.feeamt,
            this.Date,
            this.RTE});
            this.dtgfeeheads.Location = new System.Drawing.Point(57, 85);
            this.dtgfeeheads.Name = "dtgfeeheads";
            this.dtgfeeheads.Size = new System.Drawing.Size(673, 457);
            this.dtgfeeheads.TabIndex = 1;
            this.dtgfeeheads.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgfeeheads_CellClick);
            this.dtgfeeheads.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dtgfeeheads_DataError);
            this.dtgfeeheads.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgfeeheads_RowPostPaint);
            // 
            // Feecode
            // 
            this.Feecode.HeaderText = "Fee Code";
            this.Feecode.MaxInputLength = 5;
            this.Feecode.Name = "Feecode";
            this.Feecode.Visible = false;
            this.Feecode.Width = 80;
            // 
            // feeheads
            // 
            this.feeheads.HeaderText = "Fee Title";
            this.feeheads.MaxInputLength = 30;
            this.feeheads.Name = "feeheads";
            this.feeheads.Width = 220;
            // 
            // feeamt
            // 
            this.feeamt.HeaderText = "Yearly Fee Amount";
            this.feeamt.Name = "feeamt";
            this.feeamt.Width = 180;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.Width = 150;
            // 
            // RTE
            // 
            this.RTE.DataPropertyName = "RTE";
            this.RTE.HeaderText = "RTE";
            this.RTE.Name = "RTE";
            this.RTE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RTE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RTE.Width = 80;
            // 
            // cmbclass
            // 
            this.cmbclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Items.AddRange(new object[] {
            "Year Fee",
            "Regular Fee"});
            this.cmbclass.Location = new System.Drawing.Point(115, 54);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(142, 25);
            this.cmbclass.TabIndex = 0;
            this.cmbclass.Text = "-Select-";
            this.cmbclass.SelectedIndexChanged += new System.EventHandler(this.cmbclass_SelectedIndexChanged);
            this.cmbclass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbclass_KeyPress);
            this.cmbclass.Leave += new System.EventHandler(this.cmbclass_Leave);
            this.cmbclass.Validated += new System.EventHandler(this.cmbclass_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(57, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Class ";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label43.ForeColor = System.Drawing.Color.White;
            this.label43.Location = new System.Drawing.Point(275, 56);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(69, 20);
            this.label43.TabIndex = 162;
            this.label43.Text = "Stream";
            // 
            // strcmbfaculty
            // 
            this.strcmbfaculty.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strcmbfaculty.ForeColor = System.Drawing.SystemColors.WindowText;
            this.strcmbfaculty.FormattingEnabled = true;
            this.strcmbfaculty.Location = new System.Drawing.Point(350, 54);
            this.strcmbfaculty.Name = "strcmbfaculty";
            this.strcmbfaculty.Size = new System.Drawing.Size(116, 25);
            this.strcmbfaculty.TabIndex = 161;
            this.strcmbfaculty.Tag = "";
            this.strcmbfaculty.Text = "-Select-";
            this.strcmbfaculty.Leave += new System.EventHandler(this.strcmbfaculty_Leave);
            this.strcmbfaculty.Validated += new System.EventHandler(this.strcmbfaculty_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 546);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 16);
            this.label1.TabIndex = 163;
            this.label1.Text = "Note: Double Clink on Fee Amount value to edit the value";
            // 
            // btnCopyFrom
            // 
            this.btnCopyFrom.Location = new System.Drawing.Point(57, 569);
            this.btnCopyFrom.Name = "btnCopyFrom";
            this.btnCopyFrom.Size = new System.Drawing.Size(235, 28);
            this.btnCopyFrom.TabIndex = 164;
            this.btnCopyFrom.Text = "Copy fee from previous class";
            this.btnCopyFrom.UseVisualStyleBackColor = true;
            this.btnCopyFrom.Click += new System.EventHandler(this.btnCopyFrom_Click);
            // 
            // frmYearlyClassFeeHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnCopyFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.strcmbfaculty);
            this.Controls.Add(this.dtgfeeheads);
            this.Controls.Add(this.cmbclass);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmYearlyClassFeeHead";
            this.Size = new System.Drawing.Size(989, 781);
            this.Tag = "1087";
            this.Load += new System.EventHandler(this.frmregularfeeheads_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmYearlyClassFeeHead_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgfeeheads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgfeeheads;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox strcmbfaculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Feecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeheads;
        private System.Windows.Forms.DataGridViewTextBoxColumn feeamt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RTE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyFrom;
    }
}