namespace SMS.Message
{
    partial class FrmTemplate
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgTemplate = new System.Windows.Forms.DataGridView();
            this.TemplateId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTemplate
            // 
            this.dgTemplate.AllowUserToAddRows = false;
            this.dgTemplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTemplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TemplateId,
            this.Name,
            this.Description,
            this.SchDate,
            this.SchTime,
            this.Status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgTemplate.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgTemplate.Location = new System.Drawing.Point(63, 60);
            this.dgTemplate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgTemplate.Name = "dgTemplate";
            this.dgTemplate.RowHeadersWidth = 30;
            this.dgTemplate.RowTemplate.Height = 60;
            this.dgTemplate.Size = new System.Drawing.Size(947, 276);
            this.dgTemplate.TabIndex = 157;
            this.dgTemplate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTemplate_CellClick);
            this.dgTemplate.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgTemplate_DataBindingComplete);
            // 
            // TemplateId
            // 
            this.TemplateId.DataPropertyName = "TemplateId";
            this.TemplateId.HeaderText = "TemplateId";
            this.TemplateId.Name = "TemplateId";
            this.TemplateId.Visible = false;
            // 
            // Name
            // 
            this.Name.DataPropertyName = "Name";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Name.DefaultCellStyle = dataGridViewCellStyle1;
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 140;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 200;
            // 
            // SchDate
            // 
            this.SchDate.HeaderText = "Schedule Date";
            this.SchDate.Name = "SchDate";
            this.SchDate.Width = 80;
            // 
            // SchTime
            // 
            this.SchTime.HeaderText = "Schedule Time";
            this.SchTime.Name = "SchTime";
            this.SchTime.Width = 125;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Enable /Disable";
            this.Status.Name = "Status";
            // 
            // FrmTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgTemplate);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            //this.Name = "FrmTemplate";
            this.Size = new System.Drawing.Size(1024, 401);
            this.Load += new System.EventHandler(this.FrmTemplate_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmTemplate_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dgTemplate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchTime;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Status;
    }
}