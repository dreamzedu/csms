namespace SMS
{
    partial class frmFeeCollectionByHead
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label13 = new System.Windows.Forms.Label();
            this.gbxStudentDetail = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.lblclass = new System.Windows.Forms.Label();
            this.btndelete = new System.Windows.Forms.Button();
            this.gbxFeeCollection = new System.Windows.Forms.GroupBox();
            this.txtschamt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtrecivedamt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtgfee = new System.Windows.Forms.DataGridView();
            this.FeeCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeeHead = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpfeedate = new System.Windows.Forms.DateTimePicker();
            this.lblfather = new System.Windows.Forms.Label();
            this.txtConsession = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblstdtype = new System.Windows.Forms.Label();
            this.txtdueamt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLateFee = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblBusStop = new System.Windows.Forms.Label();
            this.txtTotalFeeAmount = new System.Windows.Forms.TextBox();
            this.txtscholarno = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBusFee = new System.Windows.Forms.Label();
            this.txtPaidAmont = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvPaymentDetail = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbxFeeDetail = new System.Windows.Forms.GroupBox();
            this.txtFeeRcptNo = new System.Windows.Forms.TextBox();
            this.gbxStudentDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbxFeeCollection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgfee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentDetail)).BeginInit();
            this.gbxFeeDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label13.Location = new System.Drawing.Point(377, 270);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(192, 18);
            this.label13.TabIndex = 232;
            this.label13.Text = "Press F2 to View All Fee";
            // 
            // gbxStudentDetail
            // 
            this.gbxStudentDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbxStudentDetail.Controls.Add(this.dataGridView1);
            this.gbxStudentDetail.Location = new System.Drawing.Point(70, 100);
            this.gbxStudentDetail.Margin = new System.Windows.Forms.Padding(4);
            this.gbxStudentDetail.Name = "gbxStudentDetail";
            this.gbxStudentDetail.Padding = new System.Windows.Forms.Padding(4);
            this.gbxStudentDetail.Size = new System.Drawing.Size(1213, 492);
            this.gbxStudentDetail.TabIndex = 245;
            this.gbxStudentDetail.TabStop = false;
            this.gbxStudentDetail.Text = "Students Detail";
            this.gbxStudentDetail.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 19);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1205, 469);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label11.Location = new System.Drawing.Point(357, 233);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(221, 18);
            this.label11.TabIndex = 231;
            this.label11.Text = "Press F1 to Search Student.";
            // 
            // lblclass
            // 
            this.lblclass.AutoSize = true;
            this.lblclass.BackColor = System.Drawing.Color.Transparent;
            this.lblclass.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclass.ForeColor = System.Drawing.Color.White;
            this.lblclass.Location = new System.Drawing.Point(131, 193);
            this.lblclass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblclass.Name = "lblclass";
            this.lblclass.Size = new System.Drawing.Size(13, 18);
            this.lblclass.TabIndex = 202;
            this.lblclass.Text = "-";
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.White;
            this.btndelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.Red;
            this.btndelete.Location = new System.Drawing.Point(1303, 42);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(83, 27);
            this.btndelete.TabIndex = 247;
            this.btndelete.Text = "Dele&te";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Visible = false;
            // 
            // gbxFeeCollection
            // 
            this.gbxFeeCollection.BackColor = System.Drawing.Color.Transparent;
            this.gbxFeeCollection.Controls.Add(this.txtschamt);
            this.gbxFeeCollection.Controls.Add(this.label14);
            this.gbxFeeCollection.Controls.Add(this.txtrecivedamt);
            this.gbxFeeCollection.Controls.Add(this.label3);
            this.gbxFeeCollection.Controls.Add(this.dtgfee);
            this.gbxFeeCollection.Controls.Add(this.label13);
            this.gbxFeeCollection.Controls.Add(this.label2);
            this.gbxFeeCollection.Controls.Add(this.label11);
            this.gbxFeeCollection.Controls.Add(this.lblclass);
            this.gbxFeeCollection.Controls.Add(this.label8);
            this.gbxFeeCollection.Controls.Add(this.label7);
            this.gbxFeeCollection.Controls.Add(this.label9);
            this.gbxFeeCollection.Controls.Add(this.dtpfeedate);
            this.gbxFeeCollection.Controls.Add(this.lblfather);
            this.gbxFeeCollection.Controls.Add(this.txtConsession);
            this.gbxFeeCollection.Controls.Add(this.label29);
            this.gbxFeeCollection.Controls.Add(this.label12);
            this.gbxFeeCollection.Controls.Add(this.lblname);
            this.gbxFeeCollection.Controls.Add(this.lblstdtype);
            this.gbxFeeCollection.Controls.Add(this.txtdueamt);
            this.gbxFeeCollection.Controls.Add(this.label4);
            this.gbxFeeCollection.Controls.Add(this.txtLateFee);
            this.gbxFeeCollection.Controls.Add(this.label32);
            this.gbxFeeCollection.Controls.Add(this.label1);
            this.gbxFeeCollection.Controls.Add(this.label27);
            this.gbxFeeCollection.Controls.Add(this.lblBusStop);
            this.gbxFeeCollection.Controls.Add(this.txtTotalFeeAmount);
            this.gbxFeeCollection.Controls.Add(this.txtscholarno);
            this.gbxFeeCollection.Controls.Add(this.label26);
            this.gbxFeeCollection.Controls.Add(this.label33);
            this.gbxFeeCollection.Controls.Add(this.label5);
            this.gbxFeeCollection.Controls.Add(this.lblBusFee);
            this.gbxFeeCollection.Controls.Add(this.txtPaidAmont);
            this.gbxFeeCollection.Enabled = false;
            this.gbxFeeCollection.Location = new System.Drawing.Point(70, 100);
            this.gbxFeeCollection.Margin = new System.Windows.Forms.Padding(4);
            this.gbxFeeCollection.Name = "gbxFeeCollection";
            this.gbxFeeCollection.Padding = new System.Windows.Forms.Padding(4);
            this.gbxFeeCollection.Size = new System.Drawing.Size(1213, 492);
            this.gbxFeeCollection.TabIndex = 236;
            this.gbxFeeCollection.TabStop = false;
            this.gbxFeeCollection.Text = "Fee Submission";
            // 
            // txtschamt
            // 
            this.txtschamt.BackColor = System.Drawing.Color.White;
            this.txtschamt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtschamt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtschamt.ForeColor = System.Drawing.Color.Blue;
            this.txtschamt.Location = new System.Drawing.Point(147, 289);
            this.txtschamt.Margin = new System.Windows.Forms.Padding(4);
            this.txtschamt.MaxLength = 40;
            this.txtschamt.Name = "txtschamt";
            this.txtschamt.Size = new System.Drawing.Size(123, 25);
            this.txtschamt.TabIndex = 237;
            this.txtschamt.TabStop = false;
            this.txtschamt.Tag = "totfeeamt";
            this.txtschamt.Text = "0";
            this.txtschamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(8, 293);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(118, 18);
            this.label14.TabIndex = 236;
            this.label14.Text = "Scholar Amount";
            // 
            // txtrecivedamt
            // 
            this.txtrecivedamt.BackColor = System.Drawing.Color.Gainsboro;
            this.txtrecivedamt.Enabled = false;
            this.txtrecivedamt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrecivedamt.ForeColor = System.Drawing.Color.Blue;
            this.txtrecivedamt.Location = new System.Drawing.Point(476, 123);
            this.txtrecivedamt.Margin = new System.Windows.Forms.Padding(4);
            this.txtrecivedamt.MaxLength = 40;
            this.txtrecivedamt.Name = "txtrecivedamt";
            this.txtrecivedamt.ReadOnly = true;
            this.txtrecivedamt.Size = new System.Drawing.Size(145, 25);
            this.txtrecivedamt.TabIndex = 234;
            this.txtrecivedamt.TabStop = false;
            this.txtrecivedamt.Tag = "totfeeamt";
            this.txtrecivedamt.Text = "0";
            this.txtrecivedamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(315, 127);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 16);
            this.label3.TabIndex = 235;
            this.label3.Text = "Received Amount";
            // 
            // dtgfee
            // 
            this.dtgfee.AllowUserToAddRows = false;
            this.dtgfee.AllowUserToDeleteRows = false;
            this.dtgfee.AllowUserToResizeColumns = false;
            this.dtgfee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgfee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FeeCode,
            this.FeeHead,
            this.Amount,
            this.RAmount,
            this.BAmount,
            this.PAmount});
            this.dtgfee.Location = new System.Drawing.Point(628, 19);
            this.dtgfee.Margin = new System.Windows.Forms.Padding(4);
            this.dtgfee.Name = "dtgfee";
            this.dtgfee.RowHeadersVisible = false;
            this.dtgfee.RowHeadersWidth = 40;
            this.dtgfee.Size = new System.Drawing.Size(569, 423);
            this.dtgfee.TabIndex = 233;
            this.dtgfee.TabStop = false;
            this.dtgfee.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgfee_CellEndEdit);
            this.dtgfee.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgfee_EditingControlShowing);
            // 
            // FeeCode
            // 
            this.FeeCode.DataPropertyName = "FeeCode";
            this.FeeCode.HeaderText = "FeeCode";
            this.FeeCode.Name = "FeeCode";
            this.FeeCode.Visible = false;
            // 
            // FeeHead
            // 
            this.FeeHead.DataPropertyName = "FeeHead";
            this.FeeHead.HeaderText = "Fee Head";
            this.FeeHead.Name = "FeeHead";
            this.FeeHead.ReadOnly = true;
            this.FeeHead.Width = 150;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Amount.DefaultCellStyle = dataGridViewCellStyle5;
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 60;
            // 
            // RAmount
            // 
            this.RAmount.DataPropertyName = "RAmount";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RAmount.DefaultCellStyle = dataGridViewCellStyle6;
            this.RAmount.HeaderText = "Rec. Amount";
            this.RAmount.Name = "RAmount";
            this.RAmount.ReadOnly = true;
            this.RAmount.Width = 60;
            // 
            // BAmount
            // 
            this.BAmount.DataPropertyName = "BAmount";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BAmount.DefaultCellStyle = dataGridViewCellStyle7;
            this.BAmount.HeaderText = "Bal. Amount";
            this.BAmount.Name = "BAmount";
            this.BAmount.ReadOnly = true;
            this.BAmount.Width = 60;
            // 
            // PAmount
            // 
            this.PAmount.DataPropertyName = "PAmount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PAmount.DefaultCellStyle = dataGridViewCellStyle8;
            this.PAmount.HeaderText = "Paid Amount";
            this.PAmount.Name = "PAmount";
            this.PAmount.Width = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 196;
            this.label2.Text = "Scholar No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(8, 161);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 18);
            this.label8.TabIndex = 198;
            this.label8.Text = "father";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(8, 127);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 197;
            this.label7.Text = "Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 193);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 18);
            this.label9.TabIndex = 199;
            this.label9.Text = "Class";
            // 
            // dtpfeedate
            // 
            this.dtpfeedate.CustomFormat = "dd/ MM/yyyy";
            this.dtpfeedate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfeedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfeedate.Location = new System.Drawing.Point(131, 55);
            this.dtpfeedate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpfeedate.Name = "dtpfeedate";
            this.dtpfeedate.Size = new System.Drawing.Size(139, 26);
            this.dtpfeedate.TabIndex = 1;
            // 
            // lblfather
            // 
            this.lblfather.AutoSize = true;
            this.lblfather.BackColor = System.Drawing.Color.Transparent;
            this.lblfather.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfather.ForeColor = System.Drawing.Color.White;
            this.lblfather.Location = new System.Drawing.Point(131, 161);
            this.lblfather.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblfather.Name = "lblfather";
            this.lblfather.Size = new System.Drawing.Size(13, 18);
            this.lblfather.TabIndex = 201;
            this.lblfather.Text = "-";
            // 
            // txtConsession
            // 
            this.txtConsession.BackColor = System.Drawing.Color.White;
            this.txtConsession.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsession.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsession.ForeColor = System.Drawing.Color.Blue;
            this.txtConsession.Location = new System.Drawing.Point(476, 190);
            this.txtConsession.Margin = new System.Windows.Forms.Padding(4);
            this.txtConsession.MaxLength = 40;
            this.txtConsession.Name = "txtConsession";
            this.txtConsession.Size = new System.Drawing.Size(146, 25);
            this.txtConsession.TabIndex = 4;
            this.txtConsession.TabStop = false;
            this.txtConsession.Tag = "totfeeamt";
            this.txtConsession.Text = "0";
            this.txtConsession.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtConsession.TextChanged += new System.EventHandler(this.txtConsession_TextChanged);
            this.txtConsession.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConsession_KeyDown);
            this.txtConsession.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsession_KeyPress);
            this.txtConsession.Leave += new System.EventHandler(this.txtConsession_Leave);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.White;
            this.label29.Location = new System.Drawing.Point(8, 94);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(102, 18);
            this.label29.TabIndex = 203;
            this.label29.Text = "Student Type";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(315, 193);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 16);
            this.label12.TabIndex = 222;
            this.label12.Text = "Concession";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.White;
            this.lblname.Location = new System.Drawing.Point(131, 127);
            this.lblname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(13, 18);
            this.lblname.TabIndex = 200;
            this.lblname.Text = "-";
            // 
            // lblstdtype
            // 
            this.lblstdtype.AutoSize = true;
            this.lblstdtype.BackColor = System.Drawing.Color.Transparent;
            this.lblstdtype.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstdtype.ForeColor = System.Drawing.Color.White;
            this.lblstdtype.Location = new System.Drawing.Point(131, 94);
            this.lblstdtype.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblstdtype.Name = "lblstdtype";
            this.lblstdtype.Size = new System.Drawing.Size(13, 18);
            this.lblstdtype.TabIndex = 7;
            this.lblstdtype.Text = "-";
            // 
            // txtdueamt
            // 
            this.txtdueamt.BackColor = System.Drawing.Color.Gainsboro;
            this.txtdueamt.Enabled = false;
            this.txtdueamt.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdueamt.ForeColor = System.Drawing.Color.Blue;
            this.txtdueamt.Location = new System.Drawing.Point(476, 90);
            this.txtdueamt.Margin = new System.Windows.Forms.Padding(4);
            this.txtdueamt.MaxLength = 40;
            this.txtdueamt.Name = "txtdueamt";
            this.txtdueamt.ReadOnly = true;
            this.txtdueamt.Size = new System.Drawing.Size(145, 25);
            this.txtdueamt.TabIndex = 214;
            this.txtdueamt.TabStop = false;
            this.txtdueamt.Tag = "totfeeamt";
            this.txtdueamt.Text = "0";
            this.txtdueamt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 195;
            this.label4.Text = "Fee Date";
            // 
            // txtLateFee
            // 
            this.txtLateFee.BackColor = System.Drawing.Color.White;
            this.txtLateFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLateFee.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLateFee.ForeColor = System.Drawing.Color.Blue;
            this.txtLateFee.Location = new System.Drawing.Point(476, 158);
            this.txtLateFee.Margin = new System.Windows.Forms.Padding(4);
            this.txtLateFee.MaxLength = 40;
            this.txtLateFee.Name = "txtLateFee";
            this.txtLateFee.ShortcutsEnabled = false;
            this.txtLateFee.Size = new System.Drawing.Size(146, 25);
            this.txtLateFee.TabIndex = 3;
            this.txtLateFee.TabStop = false;
            this.txtLateFee.Tag = "latefee";
            this.txtLateFee.Text = "0";
            this.txtLateFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLateFee.TextChanged += new System.EventHandler(this.txtLateFee_TextChanged);
            this.txtLateFee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLateFee_KeyDown);
            this.txtLateFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLateFee_KeyPress);
            this.txtLateFee.Leave += new System.EventHandler(this.txtLateFee_Leave);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.White;
            this.label32.Location = new System.Drawing.Point(8, 225);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(73, 18);
            this.label32.TabIndex = 205;
            this.label32.Text = "Bus Stop";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(315, 161);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 220;
            this.label1.Text = "Late Fee";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(315, 94);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(92, 16);
            this.label27.TabIndex = 225;
            this.label27.Text = "Due Amount";
            // 
            // lblBusStop
            // 
            this.lblBusStop.AutoSize = true;
            this.lblBusStop.BackColor = System.Drawing.Color.Transparent;
            this.lblBusStop.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusStop.ForeColor = System.Drawing.Color.White;
            this.lblBusStop.Location = new System.Drawing.Point(131, 225);
            this.lblBusStop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusStop.Name = "lblBusStop";
            this.lblBusStop.Size = new System.Drawing.Size(13, 18);
            this.lblBusStop.TabIndex = 206;
            this.lblBusStop.Text = "-";
            // 
            // txtTotalFeeAmount
            // 
            this.txtTotalFeeAmount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtTotalFeeAmount.Enabled = false;
            this.txtTotalFeeAmount.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalFeeAmount.ForeColor = System.Drawing.Color.Blue;
            this.txtTotalFeeAmount.Location = new System.Drawing.Point(476, 22);
            this.txtTotalFeeAmount.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalFeeAmount.MaxLength = 40;
            this.txtTotalFeeAmount.Name = "txtTotalFeeAmount";
            this.txtTotalFeeAmount.ReadOnly = true;
            this.txtTotalFeeAmount.Size = new System.Drawing.Size(144, 25);
            this.txtTotalFeeAmount.TabIndex = 211;
            this.txtTotalFeeAmount.TabStop = false;
            this.txtTotalFeeAmount.Tag = "";
            this.txtTotalFeeAmount.Text = "0";
            this.txtTotalFeeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtscholarno
            // 
            this.txtscholarno.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtscholarno.ForeColor = System.Drawing.Color.Blue;
            this.txtscholarno.Location = new System.Drawing.Point(131, 22);
            this.txtscholarno.Margin = new System.Windows.Forms.Padding(4);
            this.txtscholarno.MaxLength = 40;
            this.txtscholarno.Name = "txtscholarno";
            this.txtscholarno.Size = new System.Drawing.Size(139, 25);
            this.txtscholarno.TabIndex = 0;
            this.txtscholarno.Tag = "studentno";
            this.txtscholarno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtscholarno_KeyPress);
            this.txtscholarno.Validated += new System.EventHandler(this.txtscholarno_Validated);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(315, 26);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(128, 16);
            this.label26.TabIndex = 224;
            this.label26.Text = "Total Fee Amount";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.White;
            this.label33.Location = new System.Drawing.Point(8, 258);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(67, 18);
            this.label33.TabIndex = 207;
            this.label33.Text = "Bus Fee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(315, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 219;
            this.label5.Text = "Paid Amount";
            // 
            // lblBusFee
            // 
            this.lblBusFee.AutoSize = true;
            this.lblBusFee.BackColor = System.Drawing.Color.Transparent;
            this.lblBusFee.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBusFee.ForeColor = System.Drawing.Color.White;
            this.lblBusFee.Location = new System.Drawing.Point(131, 258);
            this.lblBusFee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBusFee.Name = "lblBusFee";
            this.lblBusFee.Size = new System.Drawing.Size(13, 18);
            this.lblBusFee.TabIndex = 208;
            this.lblBusFee.Text = "-";
            // 
            // txtPaidAmont
            // 
            this.txtPaidAmont.BackColor = System.Drawing.Color.Gainsboro;
            this.txtPaidAmont.Enabled = false;
            this.txtPaidAmont.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaidAmont.ForeColor = System.Drawing.Color.Blue;
            this.txtPaidAmont.Location = new System.Drawing.Point(476, 57);
            this.txtPaidAmont.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaidAmont.MaxLength = 40;
            this.txtPaidAmont.Name = "txtPaidAmont";
            this.txtPaidAmont.ReadOnly = true;
            this.txtPaidAmont.Size = new System.Drawing.Size(144, 25);
            this.txtPaidAmont.TabIndex = 212;
            this.txtPaidAmont.TabStop = false;
            this.txtPaidAmont.Tag = "totfeeamt";
            this.txtPaidAmont.Text = "0";
            this.txtPaidAmont.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Red;
            this.txtSearch.Location = new System.Drawing.Point(606, 67);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(673, 30);
            this.txtSearch.TabIndex = 244;
            this.txtSearch.Text = "Search By Student Name";
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Validated += new System.EventHandler(this.txtSearch_Validated);
            // 
            // dgvPaymentDetail
            // 
            this.dgvPaymentDetail.AllowUserToAddRows = false;
            this.dgvPaymentDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPaymentDetail.Location = new System.Drawing.Point(4, 40);
            this.dgvPaymentDetail.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPaymentDetail.Name = "dgvPaymentDetail";
            this.dgvPaymentDetail.Size = new System.Drawing.Size(1205, 435);
            this.dgvPaymentDetail.TabIndex = 235;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(4, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 21);
            this.label10.TabIndex = 234;
            this.label10.Text = "Paid Fee";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(70, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 18);
            this.label6.TabIndex = 243;
            this.label6.Text = "Fee No.";
            // 
            // gbxFeeDetail
            // 
            this.gbxFeeDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbxFeeDetail.Controls.Add(this.dgvPaymentDetail);
            this.gbxFeeDetail.Controls.Add(this.label10);
            this.gbxFeeDetail.Location = new System.Drawing.Point(70, 100);
            this.gbxFeeDetail.Margin = new System.Windows.Forms.Padding(4);
            this.gbxFeeDetail.Name = "gbxFeeDetail";
            this.gbxFeeDetail.Padding = new System.Windows.Forms.Padding(4);
            this.gbxFeeDetail.Size = new System.Drawing.Size(1213, 427);
            this.gbxFeeDetail.TabIndex = 248;
            this.gbxFeeDetail.TabStop = false;
            this.gbxFeeDetail.Text = "Fee Detail";
            this.gbxFeeDetail.Visible = false;
            // 
            // txtFeeRcptNo
            // 
            this.txtFeeRcptNo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFeeRcptNo.ForeColor = System.Drawing.Color.Blue;
            this.txtFeeRcptNo.Location = new System.Drawing.Point(141, 72);
            this.txtFeeRcptNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtFeeRcptNo.MaxLength = 40;
            this.txtFeeRcptNo.Name = "txtFeeRcptNo";
            this.txtFeeRcptNo.ReadOnly = true;
            this.txtFeeRcptNo.Size = new System.Drawing.Size(156, 25);
            this.txtFeeRcptNo.TabIndex = 242;
            this.txtFeeRcptNo.TabStop = false;
            this.txtFeeRcptNo.Tag = "rcptno";
            this.txtFeeRcptNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFeeRcptNo_KeyDown);
            this.txtFeeRcptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFeeRcptNo_KeyPress);
            this.txtFeeRcptNo.Leave += new System.EventHandler(this.txtFeeRcptNo_Leave);
            this.txtFeeRcptNo.Validated += new System.EventHandler(this.txtFeeRcptNo_Validated);
            // 
            // frmFeeCollectionByHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.gbxStudentDetail);
            this.Controls.Add(this.gbxFeeDetail);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.gbxFeeCollection);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFeeRcptNo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFeeCollectionByHead";
            this.Size = new System.Drawing.Size(1293, 622);
            this.Load += new System.EventHandler(this.frmFeeCollectionByHead_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmFeeCollectionByHead_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFeeCollectionByHead_KeyDown);
            this.gbxStudentDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbxFeeCollection.ResumeLayout(false);
            this.gbxFeeCollection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgfee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentDetail)).EndInit();
            this.gbxFeeDetail.ResumeLayout(false);
            this.gbxFeeDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox gbxStudentDetail;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblclass;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.GroupBox gbxFeeCollection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpfeedate;
        private System.Windows.Forms.Label lblfather;
        private System.Windows.Forms.TextBox txtConsession;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblstdtype;
        private System.Windows.Forms.TextBox txtdueamt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLateFee;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblBusStop;
        private System.Windows.Forms.TextBox txtTotalFeeAmount;
        private System.Windows.Forms.TextBox txtscholarno;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBusFee;
        private System.Windows.Forms.TextBox txtPaidAmont;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvPaymentDetail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbxFeeDetail;
        private System.Windows.Forms.TextBox txtFeeRcptNo;
        private System.Windows.Forms.DataGridView dtgfee;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeHead;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn BAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAmount;
        private System.Windows.Forms.TextBox txtrecivedamt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtschamt;
        private System.Windows.Forms.Label label14;

    }
}