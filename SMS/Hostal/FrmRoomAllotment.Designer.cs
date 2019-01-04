namespace SMS.Hostal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.valcmbclass = new System.Windows.Forms.ComboBox();
            this.Hostel = new System.Windows.Forms.Label();
            this.dtgbook = new System.Windows.Forms.DataGridView();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BedNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScholarNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StdName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeAllocationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllocateDeallocate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.StudentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.White;
            this.BtnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.Location = new System.Drawing.Point(966, 107);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(8);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(230, 58);
            this.BtnSearch.TabIndex = 71;
            this.BtnSearch.Text = "&Select";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // valcmbclass
            // 
            this.valcmbclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbclass.ForeColor = System.Drawing.Color.Blue;
            this.valcmbclass.FormattingEnabled = true;
            this.valcmbclass.Items.AddRange(new object[] {
            "Year Fee",
            "Regular Fee"});
            this.valcmbclass.Location = new System.Drawing.Point(304, 108);
            this.valcmbclass.Margin = new System.Windows.Forms.Padding(8);
            this.valcmbclass.Name = "valcmbclass";
            this.valcmbclass.Size = new System.Drawing.Size(638, 43);
            this.valcmbclass.TabIndex = 70;
            // 
            // Hostel
            // 
            this.Hostel.AutoSize = true;
            this.Hostel.BackColor = System.Drawing.Color.Transparent;
            this.Hostel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hostel.ForeColor = System.Drawing.Color.White;
            this.Hostel.Location = new System.Drawing.Point(128, 107);
            this.Hostel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Hostel.Name = "Hostel";
            this.Hostel.Size = new System.Drawing.Size(116, 38);
            this.Hostel.TabIndex = 76;
            this.Hostel.Text = "Hostel";
            // 
            // dtgbook
            // 
            this.dtgbook.AllowUserToAddRows = false;
            this.dtgbook.AllowUserToDeleteRows = false;
            this.dtgbook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgbook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RoomNo,
            this.BedNo,
            this.ScholarNo,
            this.StdName,
            this.ClassName,
            this.AllocationDate,
            this.DeAllocationDate,
            this.AllocateDeallocate,
            this.StudentNo});
            this.dtgbook.Location = new System.Drawing.Point(112, 203);
            this.dtgbook.Margin = new System.Windows.Forms.Padding(8);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.RowHeadersVisible = false;
            this.dtgbook.Size = new System.Drawing.Size(1984, 678);
            this.dtgbook.TabIndex = 72;
            this.dtgbook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgbook_CellClick);
            this.dtgbook.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgbook_CellEndEdit);
            // 
            // RoomNo
            // 
            this.RoomNo.HeaderText = "RoomNo";
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.ReadOnly = true;
            this.RoomNo.Width = 186;
            // 
            // BedNo
            // 
            this.BedNo.HeaderText = "BedNo";
            this.BedNo.Name = "BedNo";
            this.BedNo.ReadOnly = true;
            this.BedNo.Width = 158;
            // 
            // ScholarNo
            // 
            this.ScholarNo.HeaderText = "ScholarNo";
            this.ScholarNo.Name = "ScholarNo";
            this.ScholarNo.Width = 210;
            // 
            // StdName
            // 
            this.StdName.HeaderText = "StudentName";
            this.StdName.Name = "StdName";
            this.StdName.ReadOnly = true;
            this.StdName.Width = 251;
            // 
            // ClassName
            // 
            this.ClassName.HeaderText = "Class";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Width = 143;
            // 
            // AllocationDate
            // 
            this.AllocationDate.HeaderText = "Allocation Date";
            this.AllocationDate.Name = "AllocationDate";
            this.AllocationDate.Width = 251;
            // 
            // DeAllocationDate
            // 
            this.DeAllocationDate.HeaderText = "De-Allocation Date ";
            this.DeAllocationDate.Name = "DeAllocationDate";
            this.DeAllocationDate.Width = 298;
            // 
            // AllocateDeallocate
            // 
            this.AllocateDeallocate.HeaderText = "Allot Bed";
            this.AllocateDeallocate.Name = "AllocateDeallocate";
            this.AllocateDeallocate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllocateDeallocate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AllocateDeallocate.Width = 176;
            // 
            // StudentNo
            // 
            this.StudentNo.HeaderText = "Student No";
            this.StudentNo.Name = "StudentNo";
            this.StudentNo.Visible = false;
            this.StudentNo.Width = 201;
            // 
            // FrmRoomAllotment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.valcmbclass);
            this.Controls.Add(this.Hostel);
            this.Controls.Add(this.dtgbook);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "FrmRoomAllotment";
            this.Size = new System.Drawing.Size(2160, 938);
            this.Load += new System.EventHandler(this.FrmRoomAllotment_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmRoomAllotment_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.ComboBox valcmbclass;
        private System.Windows.Forms.Label Hostel;
        private System.Windows.Forms.DataGridView dtgbook;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScholarNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StdName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllocationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeAllocationDate;
        private System.Windows.Forms.DataGridViewButtonColumn AllocateDeallocate;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNo;
    }
}