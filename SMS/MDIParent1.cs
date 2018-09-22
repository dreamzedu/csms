using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SMS.Account.ReportForm;
using System.Diagnostics;
using System.Linq;
//using Microsoft.Office.Interop;

namespace SMS
{

    public partial class MDIParent1 : Form
    {
        string UserName, UserCode, Session;
        private int childFormNumber = 0;
        private DateTime startDateTime = DateTime.Now;
        Timer pollingTimer = new Timer();
        int pollingInterval = 3600000;

        public MDIParent1()
        {
            InitializeComponent();
            //school.CurrentSessionCode = Convert.ToInt32(Connection.GetExecuteScalar("Select SessionCode From tbl_Session Where SessionStatus=1"));
            
        }

        public MDIParent1(string UserCode, string UserName)
        {
            InitializeComponent();

            this.Session = school1.CurrentSessionName; //Convert.ToString(Connection.GetExecuteScalar("Select SessionName From tbl_Session Where SessionStatus=1"));
            this.UserName = UserName;
            this.UserCode = UserCode;
            this.ControlBox = true;
            Connection.UserLevel = Convert.ToInt16(Connection.GetExecuteScalar("Select top 1 UserLevel From MasterUser Where UserId='" + school1.CurrentUser.UserId.Trim() + "'", Connection.GetUserDbConnection()));
            Connection.UserName = UserName;

            this.Text = "CSMS " + Application.ProductVersion + "  |  User Login : " + UserName + "  |  Session: " + this.Session;

            // Setting a polling timer for 1 hour which can be used for checking login, subscription or update messages
            pollingTimer.Interval = pollingInterval;// 3600000;
            pollingTimer.Tick += pollingTimer_Tick;
            pollingTimer.Start();
            //User Authorisation
            #region
            try
            {
                if (!this.UserCode.Equals("1001"))
                {
                    foreach (ToolStripMenuItem Menu in this.menuStrip.Items)
                    {
                        if (Menu.Tag != null && Menu.Tag != "")
                        {
                            Menu.Visible = false;
                            foreach (ToolStripMenuItem SubMenu in Menu.DropDownItems)
                            {
                                if (SubMenu.Tag != null && SubMenu.Tag != "")
                                {
                                    SubMenu.Visible = false;
                                    foreach (ToolStripMenuItem SubAMenu in SubMenu.DropDownItems)
                                    {
                                        if (SubAMenu.Tag != null && SubAMenu.Tag != "")
                                        {
                                            SubAMenu.Visible = false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    foreach (ToolStripItem item in toolStrip1.Items)
                        if (item.DisplayStyle.Equals(ToolStripItemDisplayStyle.Image) && !item.Tag.Equals("$$$$$$$$$$"))
                            item.Visible = false;

                    DataTable dt = Connection.GetDataTable("Select menucode as MenuCode from tbl_userauth where usercode='" + this.UserCode + "'", Connection.GetUserDbConnection());
                    //Sub Menu Authorisation By Gtl
                    #region
                    try
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            DataRow[] rw = dt.Select("MenuCode='" + dr["MenuCode"] + "'", "");

                            if (rw.Length > 0)
                            {
                                foreach (ToolStripMenuItem Menu in this.menuStrip.Items)
                                {
                                    if (Menu.Tag != null && Menu.Tag != "" && Menu.Tag != "$$$$$$$$$$")
                                    {
                                        if (Menu.Tag.Equals(rw[0].ItemArray[0]))
                                        {
                                            Menu.Visible = true;
                                            break;
                                        }
                                        else
                                            continue;
                                    }
                                }
                                foreach (ToolStripMenuItem Menu in this.menuStrip.Items)
                                {
                                    foreach (ToolStripMenuItem SubMenu in Menu.DropDownItems)
                                    {
                                        if (SubMenu.Tag != null && SubMenu.Tag != "" && SubMenu.Tag != "$$$$$$$$$$")
                                        {
                                            if (SubMenu.Tag.Equals(rw[0].ItemArray[0]))
                                            {
                                                SubMenu.Visible = true;
                                            }
                                        }
                                        foreach (ToolStripMenuItem SubAMenu in SubMenu.DropDownItems)
                                        {
                                            //if (SubAMenu.Tag.Equals("New Employee"))
                                            if (SubAMenu.Tag != null && SubAMenu.Tag != "" && SubAMenu.Tag != "$$$$$$$$$$")
                                            {
                                                if (SubAMenu.Tag.Equals(rw[0].ItemArray[0]))
                                                    SubAMenu.Visible = true;
                                            }
                                            else
                                                continue;
                                        }
                                    }
                                }
                                //Button Authorisation By Gtl
                                #region
                                foreach (ToolStripItem item in toolStrip1.Items)
                                {
                                    if (item.DisplayStyle.Equals(ToolStripItemDisplayStyle.Image))
                                        if (item.Tag.Equals(rw[0].ItemArray[0]))
                                            item.Visible = true;

                                }
                                #endregion
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex); MessageBox.Show(ex.Message);
                    }
                    #endregion


                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); MessageBox.Show(ex.Message);
            }
            #endregion
        }

        void pollingTimer_Tick(object sender, EventArgs e)
        {
            if(!IsUserActive())
            {
                ExitApplication();
            }
        }

        private bool IsUserActive()
        {
            SqlConnection con = Connection.GetUserDbConnection();

            //DataSet ds = Connection.GetDataSet("Select * from MasterUser where UserName='" + txtUserName.Text.Trim() + "' and UserPassword='" + Pass.Trim() + "'; ");
            SqlDataAdapter adp = new SqlDataAdapter("Select IsActive, ActivationValidTill, ActivatedOn from MasterUser where lower(userId)='" + school.CurrentUser.UserId.ToLower() + "' and IsActive = 1 and ActivatedOn <= getdate() and ActivationValidTill >= getdate(); ", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["ActivationValidTill"]);

                if (DateTime.Now > date)
                {
                    MessageBox.Show("Your subscription has expired, please contact our sales to renew your subscription.");

                    return false;
                }
                return true;
            }
            else
            {
                MessageBox.Show("Your subscription has expired, please contact our sales to renew your subscription.");

                return false;
            }
        }

        public bool IsNewCommandEnabled {
            get { return btnNew.Enabled; }
        }

        public bool IsEditCommandEnabled
        {
            get { return btnSave.Enabled; }
        }

        public bool IsSaveCommandEnabled
        {
            get { return btnSave.Enabled; }
        }

        public bool IsPrintCommandEnabled
        {
            get { return btnPrint.Enabled; }
        }

        public bool IsDeleteCommandEnabled
        {
            get { return btnDelete.Enabled; }
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }
        void chield()
        {
            foreach (Form chieldform in MdiChildren)
            {
                chieldform.Close();
            }
        }

        private void GetChieldForm(Form ChieldForm)
        {
            ChieldForm.MdiParent = this;
            ChieldForm.StartPosition = FormStartPosition.CenterScreen;
            ChieldForm.AutoScroll = false;
            ChieldForm.Show();
            // lblStatus.Text = Tag;
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void studentMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmstudent(),sender);
        }
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void ExitApplication()
        {
            if (pollingTimer != null)
            {
                try
                {
                    pollingTimer.Stop();
                }
                catch { }
            }
            Environment.Exit(0);
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName(Application.ProductName))
                p.Kill();
        }


        private void sessionMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmSessionRecord(), sender);
        }
        private void classMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmclasssetup(),sender);
        }
        private void sectionMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmsection(),sender);
        }

        private void streamMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmsankay(),sender);
        }
        private void subjectMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Frmsubject(),sender);
        }
        private void classSectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmclass(),sender);
        }
        private void subjectClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Subjectwiseclass(),sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmschool(), sender);
        }

        private void yearlyClassFeeHeadsMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmYearlyClassFeeHead(),sender);
        }

        private void duplicateFeeReceiptSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmduplicatefeereceipt("S"), sender);
        }

        private void classWiseStudentsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmclasswisestudent(),sender);
        }

        private void birthDayListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new BirthDayList(),sender);
        }
        private void sendSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new SendMessege(),sender);
        }

        private void dailyFeesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmdailyfeereport("S"), sender);
        }

        private void transactionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new FeeTransection("S"), sender);
        }

        private void totalFeeDetailClassWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmFeeByMonthDetail("S"), sender);
        }

        private void addNewUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            UserControl ctrl = new frmuser();
            ShowUserControl(ctrl, sender);
        }

        public void ShowUserControl(UserControl ctrl, object sender)
        {
            this.btnCancel.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnPrint.Enabled = false;
            this.btnNew.Enabled = false;

            //lblMainHeading.Text = ((ToolStripMenuItem)sender).Text;
            if (sender is ToolStripMenuItem)
                lblMainHeading.Text = ((ToolStripMenuItem)sender).Text;
            else if (sender is ToolStripButton)
                lblMainHeading.Text = ((ToolStripButton)sender).Text;

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;

            
        }

        public void ShowUserControl(UserControl ctrl, string title)
        {
            this.btnCancel.Enabled = false;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnPrint.Enabled = false;
            this.btnNew.Enabled = false;

            lblMainHeading.Text = title;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(ctrl);
            ctrl.Dock = DockStyle.Fill;
        }

        private void userAuthorizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmuserauth(), sender);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Loginform frm = (new Loginform());
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams mdiCp = base.CreateParams;
                mdiCp.ClassStyle = 512;
                return mdiCp;
            }
        }

        private void terminateStudentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new TerminateStudentList(),sender);
        }

        private void toolStripStatusLabel6_Click(object sender, EventArgs e)
        {
            String URL = "";
            System.Diagnostics.Process.Start(URL);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //this.Text = "SCHOOL MANAGEMENT SYSTEM (" + "Version " + Application.ProductVersion + ") User Login :- " + UserName + "  (JSPR Software Solution)  " + " Session: " + this.Session + "      Date  :-  " + DateTime.Now.ToString("dd/MM/yyyy") + "   Time :-  " + DateTime.Now.ToLongTimeString();
            //this.Text = "SCHOOL MANAGEMENT SYSTEM " + " User Login :- " + UserName + "  " + "       Date  :-  " + DateTime.Now.ToString("dd/MM/yyyy") + "   Time :-  " + DateTime.Now.ToLongTimeString();
        }

        private void personelINFOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmDetail(),sender);
        }

        private void cCEMarkesDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmCBSCMarksheet(),sender);
        }

        private void newEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmNewEmployee(),sender);
        }

        private void employeeListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmEmployeeListView(),sender);
        }

        private void employeeLitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmEmployeeGridWiseList(),sender);
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmAddAttendance(),sender);
        }

        private void salaryCalculationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmMonthlySalaryCalculation(),sender);
        }

        private void salaryPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmNewSalaryPayment(),sender);
        }


        private void busStoppageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmStopsDetails(),sender);
        }

        private void recieptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Account.FrmCashRec(),sender);
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Account.FrmCashPyt(),sender);
        }

        private void bankRecieptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Account.FrmBankRec(),sender);
        }

        private void bankPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Account.FrmBankPyt(),sender);
        }

        private void cashBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Account.FrmCashBook(),sender);
        }

        private void bankBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Account.ReportForm.FrmBankBook(),sender);
        }

        private void journalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new FrmJurnalLadger(),sender);
        }

        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new TrialBalance(),sender);
        }

        private void schoolDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmschool(), sender);
        }

        private void tQuickSearch_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmDetail(),sender);
        }

        private void journalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Account.FrmJournalVoucher(),sender);
        }
         
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmDetail(),sender);
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmstudent(),sender);
        }

        private void btnPayroll_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmMonthlySalaryCalculation(),sender);
        }

        private void btnEmployeeAttendance_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmAddAttendance(),sender);
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmNewEmployee(),sender);
        }

        private void btnFee_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmFeeCollectionByHead(), sender);
        }

        void DatabaseBackup()
        {
            //Connection.AllPerform(@"BackUp Database " + Connection.Conn().Database + " To Disk='D:\\Barcodes\\a\\" + Connection.Conn().Database + DateTime.Now.ToString("_ddMMMyyyy_") + DateTime.Now.Hour + "H" + DateTime.Now.Minute + "Min" + DateTime.Now.Second + "Sec" + DateTime.Now.ToString("tt")+".BAK" + "' With Format,Stats=10");
            Connection.AllPerform(@"BackUp Database " + Connection.Conn().Database + " To Disk='" + @"" + Connection.GetAccessPathId() + @"Barcodes\a\" + Connection.Conn().Database + DateTime.Now.ToString("_ddMMMyyyy_") + DateTime.Now.Hour + "H" + DateTime.Now.Minute + "Min" + DateTime.Now.ToString("tt") + ".BAK" + "' With Format,Stats=10");
            //System.IO.File.SetAttributes("D:\\Barcodes\\a\\" + Connection.Conn().Database + DateTime.Now.ToString("_ddMMMyyyy_") + DateTime.Now.Hour + "H" + DateTime.Now.Minute + "Min" + DateTime.Now.ToString("tt")+".BAK", System.IO.FileAttributes.Hidden);
        }

        private void bkgProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            bkgProcess.ReportProgress(1);
            this.DatabaseBackup();
            bkgProcess.ReportProgress(100);
        }

        private void bkgProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                Application.UseWaitCursor = false;
                MessageBox.Show("Backup Compeleted Successfully.", "Backup...", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                bkgProcess.CancelAsync();
                bkgProcess.Dispose();
            }
        }

        private void bkgProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.progressStatus.Value = e.ProgressPercentage;
        }

        private void btnDatabaseBackup_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "...";
                Application.UseWaitCursor = true;
                bkgProcess.RunWorkerAsync();
                //System.Threading.Thread t = new System.Threading.Thread(DatabaseBackup);
                //t.Start();
                //System.Threading.Thread.Sleep(6000);
                //Application.UseWaitCursor = false;
                //t.Abort();
                lblStatus.Text = "Backup Started! Please Wait...";
                //MessageBox.Show("Backup compeleted Successfully.", "Backup...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //lblStatus.Text = "Status";
               
            }
            catch(Exception ex){Logger.LogError(ex); }
        }


        private void btnLink_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("");
            }
            catch(Exception ex){Logger.LogError(ex); }
        } 

        private void newCCEMarksDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmNewCBSCMarksheet (),sender);
        }

        private void newAddSkillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmCCESkills(),sender);
        }
        private void newCBSEMarksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmNewCCEMarkSheet("LIS"), sender);
        }         

        private void promoteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmStudentPromotion(),sender);
        }

        private void calculaterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Calc.exe");
        }

        private void notepadF9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"Notepad.exe");
        }

        private void MDIParent1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode.Equals(Keys.F8))
                    System.Diagnostics.Process.Start(@"Calc.exe");
                else if (e.KeyCode.Equals(Keys.F9))
                    System.Diagnostics.Process.Start(@"Notepad.exe");
                else
                {
                   ((UserControlBase)pnlMain.Controls[0]).frm_keydown(sender, e);
                }

            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void messageToStudentsParentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new SendMessege(),sender);
        }

        private void ControlPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmUpgradeSessionCode(),sender);
        }      

        

        private void rollNoGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmrollnogenerate (),sender);
        }

        private void classWiseFeesDuesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmDueFee (),sender);
        }

        private void btnDueFee_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmDueFee (),sender);
        }

        private void marksEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmMarksEntry (),sender);
        }

        private void feeHeadsMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new framfeesetup(),sender);
        }

        private void yearlyClassFeeHeadsMasterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowUserControl(new frmYearlyClassFeeHead (),sender);
        }

        private void examHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmExamHead (),sender);
        }

        private void viewMaeksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmAssessmentReport (),sender);
        } 

        private void tempraryMarksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new TempraryResult (),sender);
        }

        private void format1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmTransferCertificate("TC-Format-1"), sender);
        } 

        private void format2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmTransferCertificate("TC-Format-2"), sender);        
        }

        private void format1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmTransferCertificate("TC-Format-3"), sender);        
        }

        private void format1ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmTransferCertificate("TC-Format-4"), sender);
        }

        private void smartCardGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new samrtcard (),sender);
        }

        private void classSkillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmCCEClassWiseSkills (),sender);
        }

        private void NfeeSearch_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmFeeCollectionByHead(),sender);
        }

        private void accountGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Account.FrmAccountType(),sender);
        }

        private void accountHeadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Account.FrmAccount(),sender);
        }
        private void BusDetailstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Bus.FrmBusDeails(),sender);
        }
        
        private void busStopMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmStopsDetails(),sender);
        }

        private void dailyBusEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Bus.FrmDailyBusEntry(),sender);
        }

        private void dieselDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Bus.FrmDisealDetail(),sender);
        }

        private void busStudentDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmBusStopDetail(),sender);
        }

        private void dieselConsumptionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Bus.ReportForm.FrmDieselConsumption(),sender);
        }

        private void busRegistrationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Bus.ReportForm.FrmBusRegistration(),sender);
        }

        private void dailyBusReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Bus.ReportForm.FrmDailyBusEntry(),sender);
        }

        private void bookMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Library.FrmBook(),sender);
        }

        private void bookTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Library.FmTitle(),sender);
        }

        private void bookIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Library.FrmBookIssue(),sender);
        }

        private void bookReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Library.FrmBookReturn(),sender);
        }

        private void bookReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Library.FrmBookWaiting(),sender);
        }

        private void booksListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Library.ReportForm.FrmBookList(),sender);
        }

        private void printBarcodeCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Library.ReportForm.FrmBarcodeSticker(),sender);
        }

        private void hostelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.FrmHostal(),sender);
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.FrmRoom(),sender);
        }

        private void accomodationAllotementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.FrmRoomAllotment(),sender);
        }

        private void hostelRegularFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.FrmHostalFee(),sender);
        }

        private void roomVacantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.FrmVaccent(),sender);
        }

        private void schloarShipDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Report.Student.ReportForm.FrmScholarship(),sender);
        }

        private void tmptestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new TempraryResult(),sender);
        }

        private void newCCEMarksDetailToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.FrmMPCCMarksheet(),sender);
        }

        private void newMPCBSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.ReportForm.frmMPCCEMarkSheet(),sender);
        }

        private void roomAllotedReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.ReportForm.FrmRoomAllotment(),sender);
        }

        private void roomVacantReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.ReportForm.FrmHostalVaccent(),sender);
        }

        private void hostelStudentFeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.ReportForm.FrmStudentFee(),sender);
        }

        private void dailyHostelFeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.ReportForm.FrmDayFee(),sender);
        }

        private void monthlyDueFeeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.ReportForm.FrmDueHostalFee(),sender);
        }

        private void monthlyFeeReceiptReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Hostal.ReportForm.FrmPayMonthlyHostalFee(),sender);
        }

        private void btnDueFee_Click_1(object sender, EventArgs e)
        {
            ShowUserControl(new frmDueFee(),sender);
        }

        private void feeCallectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmFeeCollecton(),sender);
        }

        private void MDIParent1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void menuStrip_Paint(object sender, PaintEventArgs e)
        {
            Connection.ChangeFormBackColor(this, e);
        }

        private void toolStrip1_Paint(object sender, PaintEventArgs e)
        {
            ////public static void fromClear(Form f);
        }

        private void frmDesigneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void statusStrip_Paint(object sender, PaintEventArgs e)
        {
            Connection.ChangeFormBackColor(this, e);
        }

        private void newCCEMarksDetailBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.FrmMPCCMarksheetS(),sender);
        }

        private void newMPCBSEMarksheetBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.ReportForm.frmMPCCEMarkSheetB(),sender);
        }
        //private void agrodPubToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowUserControl(new MpBoardMarksheet.ReportForm.FormCCEAgrod(),sender);
        //}
        private void newMPCBSEMarksheetCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.ReportForm.frmMPCCEMarkSheetS(),sender);
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            this.pnlMain.BackColor = Color.FromArgb(207, 226, 223);

            frmAcademicSession fas = new frmAcademicSession();
            fas.StartPosition = FormStartPosition.CenterParent;
            fas.ShowDialog();
            this.Session = school1.CurrentSessionName;
            this.Text += school1.CurrentSessionName;
            //SqlConnection LocalCon = Connection.Conn();
            //if (LocalCon.State != ConnectionState.Open)
            //    LocalCon.Open();

            //SqlCommand cmd = LocalCon.CreateCommand();
            //cmd.CommandText = "Update SMSsystem set RunCount = RunCount +" +1;
            //cmd.ExecuteNonQuery();
            //LocalCon.Close();
        }

        private void newCCEMarksDetailBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.FrmMPCCMarksheetM(),sender);
        }

        private void NfeeSearch_Click_1(object sender, EventArgs e)
        {
            ShowUserControl(new frmFeeCollectionByHead(),sender);
        }

        private void newMPCBSEMarksheetDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.ReportForm.frmMPCCEMarkSheetM(),sender);
        }

        private void newCCEMarksDetailDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.FrmMPCCMarksheetMS(),sender);
        }

        private void newMPMarksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.ReportForm.frmMPCCEMarkSheetMS(),sender);
        }

        private void utilityToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void attandanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmStudentAttendance(),sender);
        }

        private void sMSTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Message.FrmTemplate(),sender);
        }

        private void frmDesigneReprotToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void absentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Report.Student.ReportForm.FrmAbsentReport(),sender);
        }

        private void format5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmTransferCertificate("TC-Format-5"), sender);
        }

        private void studentEnquiryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmStudentEnquiry(),sender);
        }

        private void headWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Report.Fees.ReportForm.frmDueFee(),sender);
        }

        private void dailyFeesReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmdailyfeereport("H"), sender);
        }

        private void transactionReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowUserControl(new FeeTransection("H"), sender);
        }

        private void feeCollectionDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmFeeByMonthDetail("H"), sender);
        }

        private void feeCollectionByHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmFeeCollectionByHead(),sender);
        }

        private void duplicateFeeReceiptByHeadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmduplicatefeereceipt("H"), sender);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmScholarshipclassfee(),sender);
        }

        private void scholarshipStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmScholarshipStatus(),sender);
        }

        private void scholarshipStatusToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowUserControl(new Report.Student.ReportForm.frmScholarshipStatus(),sender);
        }

        private void newCCEMarksDetailSHHSSAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.FrmMPCCMarksheetSHHSSA(),sender);
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.ReportForm.frmMPCCMarksheetSHHSSA(),sender);
        }

        private void rEPORTToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mPBoardPaternToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agrodPubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmNewCCEMarkSheet("AGRO"), sender);
        }

        private void daffodilsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmNewCCEMarkSheet("DAFFO"), sender);
        }

        private void yathahrtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new frmNewCCEMarkSheet("Yatharth"), sender);
        }

        private void everestSchoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.ReportForm.frmMPNewMark("MPCON"), sender);
        }

        private void rNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.ReportForm.frmMPNewMark("RNCON"), sender);
        }

        private void everestAcademyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowUserControl(new MpBoardMarksheet.ReportForm.frmMPNewMark("EVEREST"), sender);
        }

        private void activationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registration r = new Registration();
            r.ShowDialog();
        }

        private void pInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductInfo info = new frmProductInfo();
            info.ShowDialog();
        }

        public void btnnew_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btnnew_Click(sender, e);
        }

        public void btnedit_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btnedit_Click(sender, e);
        }

        public void btndelete_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btndelete_Click(sender, e);
        }

        public void btnsave_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btnsave_Click(sender, e);
        }

        public void btncancel_Click(object sender, EventArgs e)
        {
            ((UserControlBase)this.pnlMain.Controls[0]).btncancel_Click(sender, e);
        }

        public void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                ((UserControlBase)this.pnlMain.Controls[0]).btnprint_Click(sender, e);
            }
            catch(Exception ex)
            {
                if (ex.Message.Contains("Crystal Reports"))
                {
                    MessageBox.Show("Print Error: Looks like Crystal Reports not installed properly on your machine. Please download and install 32 or 64 bit Crystal Reports as per your machine architecture from following Url");
                }
                else
                    throw ex;
            }
        }



        internal void DisableAllEditMenuButtons()
        {
            this.btnCancel.Enabled = true;
            this.btnEdit.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnDelete.Enabled = false;
            this.btnPrint.Enabled = true;
            this.btnNew.Enabled = false;
        }

        internal void EnableAllEditMenuButtons()
        {
            this.btnCancel.Enabled = false;
            this.btnEdit.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnDelete.Enabled = true;
            this.btnPrint.Enabled = true;
            this.btnNew.Enabled = true;
        }

        internal void ToggleNewButton(bool enable)
        {
            this.btnNew.Enabled = enable;
        }

        internal void ToggleEditButton(bool enable)
        {
            if (enable)
            {
                if (Connection.UserLevel == 1 || Connection.UserName.ToUpper().Equals("CSMS"))
                {
                    this.btnEdit.Enabled = enable;
                }
            }
            else
            {
                this.btnEdit.Enabled = enable;
            }
        }

        internal void ToggleDeleteButton(bool enable)
        {            
            if(enable)
            {
                if (Connection.UserLevel == 1 || Connection.UserName.ToUpper().Equals("CSMS"))
                {
                    this.btnDelete.Enabled = enable;
                }
            }
            else
            {
                this.btnDelete.Enabled = enable;
            }
        }

        internal void ToggleCancelButton(bool enable)
        {
            this.btnCancel.Enabled = enable;
        }

        internal void ToggleSaveButton(bool enable)
        {
            this.btnSave.Enabled = enable;
        }

        internal void TogglePrintButton(bool enable)
        {
            this.btnPrint.Enabled = enable;
        }
        
        // These logic can be moved inside the button event call itself but that will need more effort to complete as it will impact all pages.
        internal void AfterNewClick()
        {
            btnCancel.Enabled = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }

        internal void AfterEditClick()
        {
            btnCancel.Enabled = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;            
            btnSave.Enabled = true;
        }

        internal void AfterSaveClick()
        {
            btnCancel.Enabled = false;
            btnNew.Enabled = true;
            if (Connection.UserLevel == 1 || Connection.UserName.ToUpper().Equals("CSMS"))
            {
                btnEdit.Enabled = true;
            }
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }

        internal void AfterCancelClick()
        {
            btnCancel.Enabled = false;
            btnNew.Enabled = true;
            if (Connection.UserLevel == 1 || Connection.UserName.ToUpper().Equals("CSMS"))
            {
                btnEdit.Enabled = true;
            }
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }

        private void createDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"cmd.exe scripts\createdb.vbs");
        }

        private void databaseToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDBServer d = new frmDBServer();
            d.Show();
        }

       
    }
}