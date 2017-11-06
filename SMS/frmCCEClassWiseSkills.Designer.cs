namespace SMS
{
    partial class frmCCEClassWiseSkills
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
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SkillId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Skills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbClass
            // 
            this.cmbClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(139, 58);
            this.cmbClass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(153, 28);
            this.cmbClass.TabIndex = 34;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(67, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Class";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.SkillId,
            this.Skills,
            this.Order});
            this.dataGridView1.Location = new System.Drawing.Point(67, 95);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(548, 527);
            this.dataGridView1.TabIndex = 147;
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 40;
            // 
            // SkillId
            // 
            this.SkillId.HeaderText = "SkillId";
            this.SkillId.Name = "SkillId";
            this.SkillId.ReadOnly = true;
            this.SkillId.Visible = false;
            // 
            // Skills
            // 
            this.Skills.HeaderText = "Skills";
            this.Skills.Name = "Skills";
            this.Skills.ReadOnly = true;
            this.Skills.Width = 250;
            // 
            // Order
            // 
            this.Order.HeaderText = "Order";
            this.Order.Name = "Order";
            this.Order.Width = 40;
            // 
            // frmCCEClassWiseSkills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCCEClassWiseSkills";
            this.Size = new System.Drawing.Size(663, 668);
            this.Load += new System.EventHandler(this.frmCCEClassWiseSkills_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmCCEClassWiseSkills_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn SkillId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Skills;
        private System.Windows.Forms.DataGridViewTextBoxColumn Order;
    }
}