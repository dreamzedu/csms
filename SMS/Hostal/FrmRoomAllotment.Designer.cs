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
            this.lblstudentno = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.txtbedno = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblclass = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BedNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoomNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.ScholarNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblfather = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valcmbclass = new System.Windows.Forms.ComboBox();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hostel = new System.Windows.Forms.Label();
            this.dtgbook = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).BeginInit();
            this.SuspendLayout();
            // 
            // lblstudentno
            // 
            this.lblstudentno.AutoSize = true;
            this.lblstudentno.BackColor = System.Drawing.Color.Transparent;
            this.lblstudentno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstudentno.ForeColor = System.Drawing.Color.White;
            this.lblstudentno.Location = new System.Drawing.Point(831, 59);
            this.lblstudentno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstudentno.Name = "lblstudentno";
            this.lblstudentno.Size = new System.Drawing.Size(86, 19);
            this.lblstudentno.TabIndex = 87;
            this.lblstudentno.Text = "Scroll No.";
            this.lblstudentno.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(692, 153);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 86;
            this.label2.Text = "Name";
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.White;
            this.BtnSearch.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSearch.Location = new System.Drawing.Point(483, 55);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(115, 30);
            this.BtnSearch.TabIndex = 71;
            this.BtnSearch.Text = "&Select";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtbedno
            // 
            this.txtbedno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbedno.Location = new System.Drawing.Point(842, 299);
            this.txtbedno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbedno.Name = "txtbedno";
            this.txtbedno.Size = new System.Drawing.Size(141, 25);
            this.txtbedno.TabIndex = 74;
            this.txtbedno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbedno_KeyPress);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(842, 357);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 25);
            this.dateTimePicker1.TabIndex = 75;
            this.dateTimePicker1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dateTimePicker1_KeyPress);
            // 
            // lblclass
            // 
            this.lblclass.AutoSize = true;
            this.lblclass.BackColor = System.Drawing.Color.Transparent;
            this.lblclass.ForeColor = System.Drawing.Color.Blue;
            this.lblclass.Location = new System.Drawing.Point(838, 265);
            this.lblclass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblclass.Name = "lblclass";
            this.lblclass.Size = new System.Drawing.Size(0, 17);
            this.lblclass.TabIndex = 85;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(838, 202);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 84;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Blue;
            this.label7.Location = new System.Drawing.Point(838, 155);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 17);
            this.label7.TabIndex = 83;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(835, 105);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 25);
            this.textBox1.TabIndex = 73;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.Validated += new System.EventHandler(this.textBox1_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(692, 357);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 19);
            this.label6.TabIndex = 82;
            this.label6.Text = "Allotement Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(692, 299);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 19);
            this.label5.TabIndex = 81;
            this.label5.Text = "Room-Bed No.";
            // 
            // BedNo
            // 
            this.BedNo.HeaderText = "BedNo";
            this.BedNo.Name = "BedNo";
            this.BedNo.ReadOnly = true;
            this.BedNo.Width = 84;
            // 
            // RoomNo
            // 
            this.RoomNo.HeaderText = "RoomNo";
            this.RoomNo.Name = "RoomNo";
            this.RoomNo.ReadOnly = true;
            this.RoomNo.Width = 96;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(692, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 19);
            this.label4.TabIndex = 80;
            this.label4.Text = "Class";
            // 
            // ScholarNo
            // 
            this.ScholarNo.HeaderText = "ScholarNo";
            this.ScholarNo.Name = "ScholarNo";
            this.ScholarNo.ReadOnly = true;
            this.ScholarNo.Width = 109;
            // 
            // lblfather
            // 
            this.lblfather.AutoSize = true;
            this.lblfather.BackColor = System.Drawing.Color.Transparent;
            this.lblfather.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfather.ForeColor = System.Drawing.Color.White;
            this.lblfather.Location = new System.Drawing.Point(692, 199);
            this.lblfather.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfather.Name = "lblfather";
            this.lblfather.Size = new System.Drawing.Size(109, 19);
            this.lblfather.TabIndex = 79;
            this.lblfather.Text = "Father Name";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.White;
            this.lblname.Location = new System.Drawing.Point(838, 155);
            this.lblname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(53, 19);
            this.lblname.TabIndex = 78;
            this.lblname.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(692, 104);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 77;
            this.label1.Text = "Scholar No.";
            // 
            // Name
            // 
            this.Name.HeaderText = "StudentName";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            this.Name.Width = 131;
            // 
            // valcmbclass
            // 
            this.valcmbclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valcmbclass.ForeColor = System.Drawing.Color.Blue;
            this.valcmbclass.FormattingEnabled = true;
            this.valcmbclass.Items.AddRange(new object[] {
            "Year Fee",
            "Regular Fee"});
            this.valcmbclass.Location = new System.Drawing.Point(152, 56);
            this.valcmbclass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.valcmbclass.Name = "valcmbclass";
            this.valcmbclass.Size = new System.Drawing.Size(321, 25);
            this.valcmbclass.TabIndex = 70;
            // 
            // ClassName
            // 
            this.ClassName.HeaderText = "Class";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Width = 75;
            // 
            // Hostel
            // 
            this.Hostel.AutoSize = true;
            this.Hostel.BackColor = System.Drawing.Color.Transparent;
            this.Hostel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hostel.ForeColor = System.Drawing.Color.White;
            this.Hostel.Location = new System.Drawing.Point(64, 55);
            this.Hostel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Hostel.Name = "Hostel";
            this.Hostel.Size = new System.Drawing.Size(59, 19);
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
            this.Name,
            this.ClassName});
            this.dtgbook.Location = new System.Drawing.Point(56, 105);
            this.dtgbook.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.ReadOnly = true;
            this.dtgbook.RowHeadersVisible = false;
            this.dtgbook.Size = new System.Drawing.Size(608, 350);
            this.dtgbook.TabIndex = 72;
            // 
            // FrmRoomAllotment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblstudentno);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.txtbedno);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblclass);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblfather);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valcmbclass);
            this.Controls.Add(this.Hostel);
            this.Controls.Add(this.dtgbook);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            //this.Name = "FrmRoomAllotment";
            this.Size = new System.Drawing.Size(1022, 484);
            this.Load += new System.EventHandler(this.FrmRoomAllotment_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmRoomAllotment_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblstudentno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox txtbedno;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblclass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn BedNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn RoomNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScholarNo;
        private System.Windows.Forms.Label lblfather;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.ComboBox valcmbclass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.Label Hostel;
        private System.Windows.Forms.DataGridView dtgbook;
    }
}