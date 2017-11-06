namespace SMS
{
    partial class frmBusStopDetail
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
            this.btnReport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rdoBusStopDetail = new System.Windows.Forms.RadioButton();
            this.rdoClassWise = new System.Windows.Forms.RadioButton();
            this.gbxFilter = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkSection = new System.Windows.Forms.CheckBox();
            this.chkClassWise = new System.Windows.Forms.CheckBox();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbxFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(1045, 584);
            this.btnReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(120, 28);
            this.btnReport.TabIndex = 1;
            this.btnReport.Text = "Show &Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(53, 127);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1112, 449);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // rdoBusStopDetail
            // 
            this.rdoBusStopDetail.AutoSize = true;
            this.rdoBusStopDetail.BackColor = System.Drawing.Color.Transparent;
            this.rdoBusStopDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoBusStopDetail.ForeColor = System.Drawing.Color.White;
            this.rdoBusStopDetail.Location = new System.Drawing.Point(198, 61);
            this.rdoBusStopDetail.Margin = new System.Windows.Forms.Padding(4);
            this.rdoBusStopDetail.Name = "rdoBusStopDetail";
            this.rdoBusStopDetail.Size = new System.Drawing.Size(163, 24);
            this.rdoBusStopDetail.TabIndex = 4;
            this.rdoBusStopDetail.Text = "Bus Stop Detail";
            this.rdoBusStopDetail.UseVisualStyleBackColor = false;
            this.rdoBusStopDetail.CheckedChanged += new System.EventHandler(this.rdoBusStopDetail_CheckedChanged);
            // 
            // rdoClassWise
            // 
            this.rdoClassWise.AutoSize = true;
            this.rdoClassWise.BackColor = System.Drawing.Color.Transparent;
            this.rdoClassWise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoClassWise.ForeColor = System.Drawing.Color.White;
            this.rdoClassWise.Location = new System.Drawing.Point(198, 95);
            this.rdoClassWise.Margin = new System.Windows.Forms.Padding(4);
            this.rdoClassWise.Name = "rdoClassWise";
            this.rdoClassWise.Size = new System.Drawing.Size(126, 24);
            this.rdoClassWise.TabIndex = 5;
            this.rdoClassWise.Text = "Class Wise";
            this.rdoClassWise.UseVisualStyleBackColor = false;
            this.rdoClassWise.CheckedChanged += new System.EventHandler(this.rdoClassWise_CheckedChanged);
            // 
            // gbxFilter
            // 
            this.gbxFilter.BackColor = System.Drawing.Color.Transparent;
            this.gbxFilter.Controls.Add(this.txtSearch);
            this.gbxFilter.Controls.Add(this.chkSection);
            this.gbxFilter.Controls.Add(this.chkClassWise);
            this.gbxFilter.Controls.Add(this.cmbSection);
            this.gbxFilter.Controls.Add(this.cmbClass);
            this.gbxFilter.Enabled = false;
            this.gbxFilter.Location = new System.Drawing.Point(386, 52);
            this.gbxFilter.Margin = new System.Windows.Forms.Padding(4);
            this.gbxFilter.Name = "gbxFilter";
            this.gbxFilter.Padding = new System.Windows.Forms.Padding(4);
            this.gbxFilter.Size = new System.Drawing.Size(779, 64);
            this.gbxFilter.TabIndex = 6;
            this.gbxFilter.TabStop = false;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Red;
            this.txtSearch.Location = new System.Drawing.Point(532, 22);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(236, 26);
            this.txtSearch.TabIndex = 210;
            this.txtSearch.Text = "Search By Stop ";
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            // 
            // chkSection
            // 
            this.chkSection.AutoSize = true;
            this.chkSection.BackColor = System.Drawing.Color.Transparent;
            this.chkSection.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSection.ForeColor = System.Drawing.Color.White;
            this.chkSection.Location = new System.Drawing.Point(313, 23);
            this.chkSection.Margin = new System.Windows.Forms.Padding(4);
            this.chkSection.Name = "chkSection";
            this.chkSection.Size = new System.Drawing.Size(90, 23);
            this.chkSection.TabIndex = 50;
            this.chkSection.Text = "Section";
            this.chkSection.UseVisualStyleBackColor = false;
            this.chkSection.CheckedChanged += new System.EventHandler(this.chkSection_CheckedChanged);
            // 
            // chkClassWise
            // 
            this.chkClassWise.AutoSize = true;
            this.chkClassWise.BackColor = System.Drawing.Color.Transparent;
            this.chkClassWise.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClassWise.ForeColor = System.Drawing.Color.White;
            this.chkClassWise.Location = new System.Drawing.Point(12, 23);
            this.chkClassWise.Margin = new System.Windows.Forms.Padding(4);
            this.chkClassWise.Name = "chkClassWise";
            this.chkClassWise.Size = new System.Drawing.Size(118, 23);
            this.chkClassWise.TabIndex = 48;
            this.chkClassWise.Text = "Class Wise";
            this.chkClassWise.UseVisualStyleBackColor = false;
            this.chkClassWise.CheckedChanged += new System.EventHandler(this.chkClassWise_CheckedChanged);
            // 
            // cmbSection
            // 
            this.cmbSection.Enabled = false;
            this.cmbSection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSection.ForeColor = System.Drawing.Color.Blue;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(417, 21);
            this.cmbSection.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(84, 28);
            this.cmbSection.TabIndex = 51;
            this.cmbSection.Leave += new System.EventHandler(this.cmbSection_Leave);
            // 
            // cmbClass
            // 
            this.cmbClass.Enabled = false;
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.ForeColor = System.Drawing.Color.Blue;
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(144, 21);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(140, 28);
            this.cmbClass.TabIndex = 49;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            this.cmbClass.Leave += new System.EventHandler(this.cmbClass_Leave);
            // 
            // cmbSession
            // 
            this.cmbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.Blue;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(53, 87);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(116, 28);
            this.cmbSession.TabIndex = 7;
            this.cmbSession.SelectedIndexChanged += new System.EventHandler(this.cmbSession_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(53, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 54;
            this.label1.Text = "Session ";
            // 
            // frmBusStopDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSession);
            this.Controls.Add(this.gbxFilter);
            this.Controls.Add(this.rdoClassWise);
            this.Controls.Add(this.rdoBusStopDetail);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReport);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBusStopDetail";
            this.Size = new System.Drawing.Size(1169, 634);
            this.Tag = "1088";
            this.Load += new System.EventHandler(this.frmBusStopDetail_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmBusStopDetail_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbxFilter.ResumeLayout(false);
            this.gbxFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton rdoBusStopDetail;
        private System.Windows.Forms.RadioButton rdoClassWise;
        private System.Windows.Forms.GroupBox gbxFilter;
        private System.Windows.Forms.CheckBox chkSection;
        private System.Windows.Forms.CheckBox chkClassWise;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
    }
}