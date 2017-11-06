namespace SMS
{
    partial class SendMessege
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbclass = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StudentNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScholarNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Father = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mother = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnMessageDetail = new System.Windows.Forms.Button();
            this.gbxMessageDetail = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbSession = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbxMessageDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(235, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Class";
            // 
            // cmbclass
            // 
            this.cmbclass.FormattingEnabled = true;
            this.cmbclass.Location = new System.Drawing.Point(340, 60);
            this.cmbclass.Margin = new System.Windows.Forms.Padding(4);
            this.cmbclass.Name = "cmbclass";
            this.cmbclass.Size = new System.Drawing.Size(167, 24);
            this.cmbclass.TabIndex = 4;
            this.cmbclass.SelectedIndexChanged += new System.EventHandler(this.cmbclass_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.StudentNo,
            this.ScholarNo,
            this.StudentName,
            this.Father,
            this.Mother,
            this.MobileNo,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(68, 98);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1144, 405);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Select
            // 
            this.Select.HeaderText = "Select";
            this.Select.Name = "Select";
            this.Select.Width = 40;
            // 
            // StudentNo
            // 
            this.StudentNo.HeaderText = "StudentNo";
            this.StudentNo.Name = "StudentNo";
            this.StudentNo.ReadOnly = true;
            this.StudentNo.Visible = false;
            // 
            // ScholarNo
            // 
            this.ScholarNo.HeaderText = "Scholar No.";
            this.ScholarNo.Name = "ScholarNo";
            this.ScholarNo.ReadOnly = true;
            this.ScholarNo.Width = 80;
            // 
            // Name
            // 
            this.StudentName.HeaderText = "Name";
            this.StudentName.Name = "Name";
            this.StudentName.ReadOnly = true;
            this.StudentName.Width = 150;
            // 
            // Father
            // 
            this.Father.HeaderText = "Father";
            this.Father.Name = "Father";
            this.Father.ReadOnly = true;
            this.Father.Width = 150;
            // 
            // Mother
            // 
            this.Mother.HeaderText = "Mother";
            this.Mother.Name = "Mother";
            this.Mother.ReadOnly = true;
            this.Mother.Width = 150;
            // 
            // MobileNo
            // 
            this.MobileNo.HeaderText = "Mobile No.";
            this.MobileNo.Name = "MobileNo";
            this.MobileNo.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // txtMessage
            // 
            this.txtMessage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(200, 511);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(1011, 59);
            this.txtMessage.TabIndex = 7;
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Location = new System.Drawing.Point(884, 578);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(164, 42);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.Location = new System.Drawing.Point(1048, 578);
            this.btnclose.Margin = new System.Windows.Forms.Padding(4);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(164, 42);
            this.btnclose.TabIndex = 9;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(68, 512);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Massage";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.chkSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.chkSelectAll.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.chkSelectAll.Location = new System.Drawing.Point(68, 60);
            this.chkSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(112, 24);
            this.chkSelectAll.TabIndex = 13;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = false;
            this.chkSelectAll.CheckStateChanged += new System.EventHandler(this.chkSelectAll_CheckStateChanged);
            // 
            // btnMessageDetail
            // 
            this.btnMessageDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessageDetail.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnMessageDetail.Location = new System.Drawing.Point(720, 578);
            this.btnMessageDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnMessageDetail.Name = "btnMessageDetail";
            this.btnMessageDetail.Size = new System.Drawing.Size(164, 42);
            this.btnMessageDetail.TabIndex = 15;
            this.btnMessageDetail.Text = "Earlier Message Detail";
            this.btnMessageDetail.UseVisualStyleBackColor = true;
            this.btnMessageDetail.Click += new System.EventHandler(this.btnMessageDetail_Click);
            // 
            // gbxMessageDetail
            // 
            this.gbxMessageDetail.BackColor = System.Drawing.Color.Transparent;
            this.gbxMessageDetail.Controls.Add(this.btnView);
            this.gbxMessageDetail.Controls.Add(this.listView1);
            this.gbxMessageDetail.Controls.Add(this.label5);
            this.gbxMessageDetail.Controls.Add(this.label6);
            this.gbxMessageDetail.Controls.Add(this.dateTimePicker2);
            this.gbxMessageDetail.Controls.Add(this.dateTimePicker1);
            this.gbxMessageDetail.Controls.Add(this.cmbSession);
            this.gbxMessageDetail.Controls.Add(this.label4);
            this.gbxMessageDetail.Location = new System.Drawing.Point(63, 60);
            this.gbxMessageDetail.Margin = new System.Windows.Forms.Padding(4);
            this.gbxMessageDetail.Name = "gbxMessageDetail";
            this.gbxMessageDetail.Padding = new System.Windows.Forms.Padding(4);
            this.gbxMessageDetail.Size = new System.Drawing.Size(1156, 560);
            this.gbxMessageDetail.TabIndex = 16;
            this.gbxMessageDetail.TabStop = false;
            this.gbxMessageDetail.Text = "Sent Message Detail";
            this.gbxMessageDetail.Visible = false;
            // 
            // btnView
            // 
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.Color.Black;
            this.btnView.Location = new System.Drawing.Point(737, 23);
            this.btnView.Margin = new System.Windows.Forms.Padding(4);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(120, 28);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.Location = new System.Drawing.Point(4, 66);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1148, 490);
            this.listView1.TabIndex = 180;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(527, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 19);
            this.label5.TabIndex = 179;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(287, 30);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 19);
            this.label6.TabIndex = 178;
            this.label6.Text = "From";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(563, 26);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(135, 26);
            this.dateTimePicker2.TabIndex = 2;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(345, 27);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // cmbSession
            // 
            this.cmbSession.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSession.ForeColor = System.Drawing.Color.Blue;
            this.cmbSession.FormattingEnabled = true;
            this.cmbSession.Location = new System.Drawing.Point(97, 26);
            this.cmbSession.Margin = new System.Windows.Forms.Padding(4);
            this.cmbSession.Name = "cmbSession";
            this.cmbSession.Size = new System.Drawing.Size(148, 27);
            this.cmbSession.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 30);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 19);
            this.label4.TabIndex = 175;
            this.label4.Text = "Session ";
            // 
            // SendMessege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.gbxMessageDetail);
            this.Controls.Add(this.btnMessageDetail);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbclass);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SendMessege";
            this.Size = new System.Drawing.Size(1279, 676);
            this.Tag = "1149";
            this.Load += new System.EventHandler(this.SendMessege_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SendMessege_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbxMessageDetail.ResumeLayout(false);
            this.gbxMessageDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbclass;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScholarNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Father;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mother;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button btnMessageDetail;
        private System.Windows.Forms.GroupBox gbxMessageDetail;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cmbSession;
        private System.Windows.Forms.Label label4;
    }
}