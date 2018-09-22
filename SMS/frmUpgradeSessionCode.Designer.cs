namespace SMS
{
    partial class frmUpgradeSessionCode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnUpgradeSession = new System.Windows.Forms.Button();
            this.gbxUpgradeSession = new System.Windows.Forms.GroupBox();
            this.chkMessageService = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSenderID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnActiveDeactive = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgApplicationPath = new System.Windows.Forms.DataGridView();
            this.Title = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Path = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnSaveApplicationPath = new System.Windows.Forms.Button();
            this.btnTitle = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnApplicationSetting = new System.Windows.Forms.Button();
            this.btnAddSetting = new System.Windows.Forms.Button();
            this.txtApplicationSetting = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbxUpgradeSession.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgApplicationPath)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView1.Location = new System.Drawing.Point(7, 23);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.DividerHeight = 1;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(728, 398);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // btnUpgradeSession
            // 
            this.btnUpgradeSession.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpgradeSession.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpgradeSession.ForeColor = System.Drawing.Color.White;
            this.btnUpgradeSession.Location = new System.Drawing.Point(567, 423);
            this.btnUpgradeSession.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpgradeSession.Name = "btnUpgradeSession";
            this.btnUpgradeSession.Size = new System.Drawing.Size(168, 34);
            this.btnUpgradeSession.TabIndex = 1;
            this.btnUpgradeSession.Text = "Upgrade Session";
            this.btnUpgradeSession.UseVisualStyleBackColor = false;
            this.btnUpgradeSession.Click += new System.EventHandler(this.btnUpgradeSession_Click);
            // 
            // gbxUpgradeSession
            // 
            this.gbxUpgradeSession.BackColor = System.Drawing.Color.Transparent;
            this.gbxUpgradeSession.Controls.Add(this.dataGridView1);
            this.gbxUpgradeSession.Controls.Add(this.btnUpgradeSession);
            this.gbxUpgradeSession.Location = new System.Drawing.Point(27, 38);
            this.gbxUpgradeSession.Margin = new System.Windows.Forms.Padding(4);
            this.gbxUpgradeSession.Name = "gbxUpgradeSession";
            this.gbxUpgradeSession.Padding = new System.Windows.Forms.Padding(4);
            this.gbxUpgradeSession.Size = new System.Drawing.Size(741, 464);
            this.gbxUpgradeSession.TabIndex = 4;
            this.gbxUpgradeSession.TabStop = false;
            this.gbxUpgradeSession.Text = "Upgrade Session";
            // 
            // chkMessageService
            // 
            this.chkMessageService.AutoSize = true;
            this.chkMessageService.BackColor = System.Drawing.Color.Transparent;
            this.chkMessageService.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMessageService.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMessageService.ForeColor = System.Drawing.Color.White;
            this.chkMessageService.Location = new System.Drawing.Point(8, 23);
            this.chkMessageService.Margin = new System.Windows.Forms.Padding(4);
            this.chkMessageService.Name = "chkMessageService";
            this.chkMessageService.Size = new System.Drawing.Size(200, 28);
            this.chkMessageService.TabIndex = 5;
            this.chkMessageService.Text = "Message Service";
            this.chkMessageService.UseVisualStyleBackColor = false;
            this.chkMessageService.CheckStateChanged += new System.EventHandler(this.chkMessageService_CheckStateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSenderID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnActiveDeactive);
            this.groupBox1.Controls.Add(this.chkMessageService);
            this.groupBox1.Location = new System.Drawing.Point(775, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(309, 214);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Service Active/Deactive";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(140, 128);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(153, 26);
            this.txtPassword.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(140, 91);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(153, 26);
            this.txtUserName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "User Name";
            // 
            // txtSenderID
            // 
            this.txtSenderID.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderID.Location = new System.Drawing.Point(140, 57);
            this.txtSenderID.Margin = new System.Windows.Forms.Padding(4);
            this.txtSenderID.Name = "txtSenderID";
            this.txtSenderID.Size = new System.Drawing.Size(153, 26);
            this.txtSenderID.TabIndex = 8;
            this.txtSenderID.Leave += new System.EventHandler(this.txtSenderID_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sender ID";
            // 
            // btnActiveDeactive
            // 
            this.btnActiveDeactive.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnActiveDeactive.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActiveDeactive.ForeColor = System.Drawing.Color.White;
            this.btnActiveDeactive.Location = new System.Drawing.Point(140, 162);
            this.btnActiveDeactive.Margin = new System.Windows.Forms.Padding(4);
            this.btnActiveDeactive.Name = "btnActiveDeactive";
            this.btnActiveDeactive.Size = new System.Drawing.Size(157, 39);
            this.btnActiveDeactive.TabIndex = 6;
            this.btnActiveDeactive.UseVisualStyleBackColor = false;
            this.btnActiveDeactive.Click += new System.EventHandler(this.btnActiveDeactive_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dtgApplicationPath);
            this.groupBox2.Controls.Add(this.btnSaveApplicationPath);
            this.groupBox2.Controls.Add(this.btnTitle);
            this.groupBox2.Controls.Add(this.txtTitle);
            this.groupBox2.Location = new System.Drawing.Point(27, 505);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(741, 226);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Application Path";
            // 
            // dtgApplicationPath
            // 
            this.dtgApplicationPath.AllowDrop = true;
            this.dtgApplicationPath.AllowUserToAddRows = false;
            this.dtgApplicationPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgApplicationPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Title,
            this.Path});
            this.dtgApplicationPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtgApplicationPath.Location = new System.Drawing.Point(4, 19);
            this.dtgApplicationPath.Margin = new System.Windows.Forms.Padding(4);
            this.dtgApplicationPath.Name = "dtgApplicationPath";
            this.dtgApplicationPath.Size = new System.Drawing.Size(733, 161);
            this.dtgApplicationPath.TabIndex = 11;
            this.dtgApplicationPath.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgApplicationPath_CellClick);
            this.dtgApplicationPath.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.Width = 160;
            // 
            // Path
            // 
            this.Path.HeaderText = "Path";
            this.Path.Name = "Path";
            this.Path.Width = 400;
            // 
            // btnSaveApplicationPath
            // 
            this.btnSaveApplicationPath.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveApplicationPath.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveApplicationPath.ForeColor = System.Drawing.Color.White;
            this.btnSaveApplicationPath.Location = new System.Drawing.Point(424, 185);
            this.btnSaveApplicationPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveApplicationPath.Name = "btnSaveApplicationPath";
            this.btnSaveApplicationPath.Size = new System.Drawing.Size(193, 34);
            this.btnSaveApplicationPath.TabIndex = 10;
            this.btnSaveApplicationPath.Text = "Save Application Path";
            this.btnSaveApplicationPath.UseVisualStyleBackColor = false;
            this.btnSaveApplicationPath.Click += new System.EventHandler(this.btnSaveApplicationPath_Click);
            // 
            // btnTitle
            // 
            this.btnTitle.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTitle.ForeColor = System.Drawing.Color.White;
            this.btnTitle.Location = new System.Drawing.Point(321, 185);
            this.btnTitle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTitle.Name = "btnTitle";
            this.btnTitle.Size = new System.Drawing.Size(97, 34);
            this.btnTitle.TabIndex = 3;
            this.btnTitle.Text = "Add New";
            this.btnTitle.UseVisualStyleBackColor = false;
            this.btnTitle.Click += new System.EventHandler(this.btnTitle_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(4, 192);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(307, 22);
            this.txtTitle.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.btnApplicationSetting);
            this.groupBox3.Controls.Add(this.btnAddSetting);
            this.groupBox3.Controls.Add(this.txtApplicationSetting);
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Location = new System.Drawing.Point(773, 258);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(311, 474);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "System Setting";
            // 
            // btnApplicationSetting
            // 
            this.btnApplicationSetting.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApplicationSetting.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplicationSetting.ForeColor = System.Drawing.Color.White;
            this.btnApplicationSetting.Location = new System.Drawing.Point(3, 431);
            this.btnApplicationSetting.Margin = new System.Windows.Forms.Padding(4);
            this.btnApplicationSetting.Name = "btnApplicationSetting";
            this.btnApplicationSetting.Size = new System.Drawing.Size(306, 37);
            this.btnApplicationSetting.TabIndex = 13;
            this.btnApplicationSetting.Text = "Save System Settings";
            this.btnApplicationSetting.UseVisualStyleBackColor = false;
            this.btnApplicationSetting.Click += new System.EventHandler(this.btnApplicationSetting_Click);
            // 
            // btnAddSetting
            // 
            this.btnAddSetting.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddSetting.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSetting.ForeColor = System.Drawing.Color.White;
            this.btnAddSetting.Location = new System.Drawing.Point(213, 399);
            this.btnAddSetting.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSetting.Name = "btnAddSetting";
            this.btnAddSetting.Size = new System.Drawing.Size(96, 30);
            this.btnAddSetting.TabIndex = 11;
            this.btnAddSetting.Text = "Add New";
            this.btnAddSetting.UseVisualStyleBackColor = false;
            this.btnAddSetting.Click += new System.EventHandler(this.btnAddSetting_Click);
            // 
            // txtApplicationSetting
            // 
            this.txtApplicationSetting.Location = new System.Drawing.Point(4, 403);
            this.txtApplicationSetting.Margin = new System.Windows.Forms.Padding(4);
            this.txtApplicationSetting.Name = "txtApplicationSetting";
            this.txtApplicationSetting.Size = new System.Drawing.Size(206, 22);
            this.txtApplicationSetting.TabIndex = 12;
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.listView1.Location = new System.Drawing.Point(4, 19);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(303, 372);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // frmUpgradeSessionCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbxUpgradeSession);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmUpgradeSessionCode";
            this.Size = new System.Drawing.Size(1111, 741);
            this.Load += new System.EventHandler(this.frmUpgradeSessionCode_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmUpgradeSessionCode_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbxUpgradeSession.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgApplicationPath)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnUpgradeSession;
        private System.Windows.Forms.GroupBox gbxUpgradeSession;
        private System.Windows.Forms.CheckBox chkMessageService;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnActiveDeactive;
        private System.Windows.Forms.TextBox txtSenderID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnSaveApplicationPath;
        private System.Windows.Forms.DataGridView dtgApplicationPath;
        private System.Windows.Forms.DataGridViewButtonColumn Title;
        private System.Windows.Forms.DataGridViewLinkColumn Path;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnApplicationSetting;
        private System.Windows.Forms.Button btnAddSetting;
        private System.Windows.Forms.TextBox txtApplicationSetting;
    }
}