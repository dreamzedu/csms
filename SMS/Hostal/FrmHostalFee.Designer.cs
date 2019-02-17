namespace SMS.Hostal
{
    partial class FrmHostalFee
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgbook = new System.Windows.Forms.DataGridView();
            this.feemonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.roomno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messdays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.beds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblmessfee = new System.Windows.Forms.Label();
            this.lblhostelfee = new System.Windows.Forms.Label();
            this.lblbedno = new System.Windows.Forms.Label();
            this.lblclass = new System.Windows.Forms.Label();
            this.lblfathername = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblstudentno = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ATxtScholar = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblfather = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgbook
            // 
            this.dtgbook.AllowUserToAddRows = false;
            this.dtgbook.AllowUserToDeleteRows = false;
            this.dtgbook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dtgbook.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgbook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgbook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgbook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.feemonth,
            this.roomno,
            this.messdays,
            this.beds,
            this.PayDate,
            this.FeeNo,
            this.MonthNo,
            this.YearNo});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgbook.DefaultCellStyle = dataGridViewCellStyle7;
            this.dtgbook.Location = new System.Drawing.Point(716, 103);
            this.dtgbook.Margin = new System.Windows.Forms.Padding(8);
            this.dtgbook.Name = "dtgbook";
            this.dtgbook.RowHeadersVisible = false;
            this.dtgbook.Size = new System.Drawing.Size(1274, 706);
            this.dtgbook.TabIndex = 22;
            this.dtgbook.TabStop = false;
            this.dtgbook.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgbook_CellClick);
            // 
            // feemonth
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.feemonth.DefaultCellStyle = dataGridViewCellStyle2;
            this.feemonth.HeaderText = "Month";
            this.feemonth.Name = "feemonth";
            this.feemonth.ReadOnly = true;
            this.feemonth.Width = 147;
            // 
            // roomno
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            this.roomno.DefaultCellStyle = dataGridViewCellStyle3;
            this.roomno.HeaderText = "Boarding Fee";
            this.roomno.Name = "roomno";
            this.roomno.Width = 236;
            // 
            // messdays
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info;
            this.messdays.DefaultCellStyle = dataGridViewCellStyle4;
            this.messdays.HeaderText = "Mess Days";
            this.messdays.Name = "messdays";
            this.messdays.Width = 205;
            // 
            // beds
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info;
            this.beds.DefaultCellStyle = dataGridViewCellStyle5;
            this.beds.HeaderText = "Mess Fee";
            this.beds.Name = "beds";
            this.beds.Width = 190;
            // 
            // PayDate
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            this.PayDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.PayDate.HeaderText = "Pay Date";
            this.PayDate.Name = "PayDate";
            this.PayDate.ReadOnly = true;
            this.PayDate.Width = 182;
            // 
            // FeeNo
            // 
            this.FeeNo.HeaderText = "Fee No";
            this.FeeNo.Name = "FeeNo";
            this.FeeNo.Visible = false;
            this.FeeNo.Width = 159;
            // 
            // MonthNo
            // 
            this.MonthNo.HeaderText = "MonthNo";
            this.MonthNo.Name = "MonthNo";
            this.MonthNo.Visible = false;
            this.MonthNo.Width = 182;
            // 
            // YearNo
            // 
            this.YearNo.HeaderText = "YearNo";
            this.YearNo.Name = "YearNo";
            this.YearNo.Visible = false;
            this.YearNo.Width = 158;
            // 
            // lblmessfee
            // 
            this.lblmessfee.AutoSize = true;
            this.lblmessfee.BackColor = System.Drawing.Color.Transparent;
            this.lblmessfee.ForeColor = System.Drawing.Color.Blue;
            this.lblmessfee.Location = new System.Drawing.Point(388, 580);
            this.lblmessfee.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblmessfee.Name = "lblmessfee";
            this.lblmessfee.Size = new System.Drawing.Size(24, 32);
            this.lblmessfee.TabIndex = 121;
            this.lblmessfee.Text = "-";
            // 
            // lblhostelfee
            // 
            this.lblhostelfee.AutoSize = true;
            this.lblhostelfee.BackColor = System.Drawing.Color.Transparent;
            this.lblhostelfee.ForeColor = System.Drawing.Color.Blue;
            this.lblhostelfee.Location = new System.Drawing.Point(388, 495);
            this.lblhostelfee.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblhostelfee.Name = "lblhostelfee";
            this.lblhostelfee.Size = new System.Drawing.Size(24, 32);
            this.lblhostelfee.TabIndex = 119;
            this.lblhostelfee.Text = "-";
            // 
            // lblbedno
            // 
            this.lblbedno.AutoSize = true;
            this.lblbedno.BackColor = System.Drawing.Color.Transparent;
            this.lblbedno.ForeColor = System.Drawing.Color.Blue;
            this.lblbedno.Location = new System.Drawing.Point(388, 412);
            this.lblbedno.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblbedno.Name = "lblbedno";
            this.lblbedno.Size = new System.Drawing.Size(24, 32);
            this.lblbedno.TabIndex = 117;
            this.lblbedno.Text = "-";
            // 
            // lblclass
            // 
            this.lblclass.AutoSize = true;
            this.lblclass.BackColor = System.Drawing.Color.Transparent;
            this.lblclass.ForeColor = System.Drawing.Color.Blue;
            this.lblclass.Location = new System.Drawing.Point(388, 332);
            this.lblclass.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblclass.Name = "lblclass";
            this.lblclass.Size = new System.Drawing.Size(24, 32);
            this.lblclass.TabIndex = 115;
            this.lblclass.Text = "-";
            // 
            // lblfathername
            // 
            this.lblfathername.AutoSize = true;
            this.lblfathername.BackColor = System.Drawing.Color.Transparent;
            this.lblfathername.ForeColor = System.Drawing.Color.Blue;
            this.lblfathername.Location = new System.Drawing.Point(388, 255);
            this.lblfathername.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblfathername.Name = "lblfathername";
            this.lblfathername.Size = new System.Drawing.Size(24, 32);
            this.lblfathername.TabIndex = 113;
            this.lblfathername.Text = "-";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.ForeColor = System.Drawing.Color.Blue;
            this.label26.Location = new System.Drawing.Point(1004, 744);
            this.label26.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(0, 32);
            this.label26.TabIndex = 110;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(1004, 744);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 32);
            this.label6.TabIndex = 111;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.White;
            this.label25.Location = new System.Drawing.Point(108, 40);
            this.label25.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(169, 38);
            this.label25.TabIndex = 109;
            this.label25.Text = "Scroll No.";
            this.label25.Visible = false;
            // 
            // lblstudentno
            // 
            this.lblstudentno.AutoSize = true;
            this.lblstudentno.BackColor = System.Drawing.Color.Transparent;
            this.lblstudentno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstudentno.ForeColor = System.Drawing.Color.White;
            this.lblstudentno.Location = new System.Drawing.Point(108, 40);
            this.lblstudentno.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblstudentno.Name = "lblstudentno";
            this.lblstudentno.Size = new System.Drawing.Size(169, 38);
            this.lblstudentno.TabIndex = 108;
            this.lblstudentno.Text = "Scroll No.";
            this.lblstudentno.Visible = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(108, 177);
            this.label24.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(105, 38);
            this.label24.TabIndex = 106;
            this.label24.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(108, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 38);
            this.label4.TabIndex = 107;
            this.label4.Text = "Name";
            // 
            // ATxtScholar
            // 
            this.ATxtScholar.Location = new System.Drawing.Point(388, 106);
            this.ATxtScholar.Margin = new System.Windows.Forms.Padding(8);
            this.ATxtScholar.Name = "ATxtScholar";
            this.ATxtScholar.Size = new System.Drawing.Size(306, 38);
            this.ATxtScholar.TabIndex = 6;
            this.ATxtScholar.Leave += new System.EventHandler(this.ATxtScholar_Leave);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(108, 406);
            this.label23.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(249, 38);
            this.label23.TabIndex = 104;
            this.label23.Text = "Hostel-Bed No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(108, 406);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(249, 38);
            this.label5.TabIndex = 105;
            this.label5.Text = "Hostel-Bed No.";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(108, 328);
            this.label22.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(104, 38);
            this.label22.TabIndex = 103;
            this.label22.Text = "Class";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(108, 328);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 38);
            this.label7.TabIndex = 102;
            this.label7.Text = "Class";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(108, 249);
            this.label21.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(214, 38);
            this.label21.TabIndex = 101;
            this.label21.Text = "Father Name";
            // 
            // lblfather
            // 
            this.lblfather.AutoSize = true;
            this.lblfather.BackColor = System.Drawing.Color.Transparent;
            this.lblfather.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfather.ForeColor = System.Drawing.Color.White;
            this.lblfather.Location = new System.Drawing.Point(108, 249);
            this.lblfather.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblfather.Name = "lblfather";
            this.lblfather.Size = new System.Drawing.Size(214, 38);
            this.lblfather.TabIndex = 100;
            this.lblfather.Text = "Father Name";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.Blue;
            this.lblname.Location = new System.Drawing.Point(388, 177);
            this.lblname.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(28, 38);
            this.lblname.TabIndex = 98;
            this.lblname.Text = "-";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(108, 106);
            this.label19.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(198, 38);
            this.label19.TabIndex = 97;
            this.label19.Text = "Scholar No.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(108, 106);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(198, 38);
            this.label8.TabIndex = 96;
            this.label8.Text = "Scholar No.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(108, 576);
            this.label18.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(165, 38);
            this.label18.TabIndex = 95;
            this.label18.Text = "Mess Fee";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(108, 491);
            this.label17.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(225, 38);
            this.label17.TabIndex = 93;
            this.label17.Text = "Boarding Fee";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(108, 576);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 38);
            this.label1.TabIndex = 94;
            this.label1.Text = "Mess Fee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(108, 491);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 38);
            this.label3.TabIndex = 92;
            this.label3.Text = "Boarding Fee";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(388, 38);
            this.textBox1.Margin = new System.Windows.Forms.Padding(8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(306, 38);
            this.textBox1.TabIndex = 20;
            this.textBox1.Visible = false;
            // 
            // FrmHostalFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dtgbook);
            this.Controls.Add(this.lblmessfee);
            this.Controls.Add(this.lblhostelfee);
            this.Controls.Add(this.lblbedno);
            this.Controls.Add(this.lblclass);
            this.Controls.Add(this.lblfathername);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblstudentno);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ATxtScholar);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblfather);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "FrmHostalFee";
            this.Size = new System.Drawing.Size(2030, 891);
            this.Load += new System.EventHandler(this.FrmHostalFee_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmHostalFee_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dtgbook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgbook;
        private System.Windows.Forms.Label lblmessfee;
        private System.Windows.Forms.Label lblhostelfee;
        private System.Windows.Forms.Label lblbedno;
        private System.Windows.Forms.Label lblclass;
        private System.Windows.Forms.Label lblfathername;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblstudentno;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ATxtScholar;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblfather;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn feemonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn roomno;
        private System.Windows.Forms.DataGridViewTextBoxColumn messdays;
        private System.Windows.Forms.DataGridViewTextBoxColumn beds;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearNo;
    }
}