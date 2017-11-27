using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class frmAddAttendance :UserControlBase
    {
        string str1 = "";
       school c1 = new school();
        public frmAddAttendance()
        {
            InitializeComponent();   // DesignForm.fromDesign1(this);
            Connection.SetUserControlTheme(this);
        }    

        public override void btnsave_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[2].Value == null)
                {
                    MessageBox.Show("Please Fill All Field Properly!");
                    return;
                }
            }
            // this changes i have done for bareli school date 10/02/2016. i put !=true and i comment all previous work//
            if (btnShowAttendance.Visible !=true)
            {
                if (DialogResult.Yes.Equals(MessageBox.Show("Are You Sure To Save Attendance Date Of \" " + txtAttandanceDate.Text + " \" ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                {
                    System.Data.SqlClient.SqlTransaction trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Delete From tbl_Attendance Where AttendanceDate = '"+txtAttandanceDate.Value.Date.ToString("MM/dd/yyyy")+"'",
                        Connection.MyConnection, trn);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        //foreach (DataGridViewRow r in dataGridView1.Rows)
                        //{
                            Connection.AllPerform("insert into tbl_Attendance (EmpNo, AttendanceDate, Attendance)values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + txtAttandanceDate.Text + "','" + dataGridView1.Rows[i].Cells[2].Value + "')");
                            //Connection.SqlTransection("insert into tbl_Attendance (EmpNo, AttendanceDate, Attendance, TimeIn, TimeOut) "+
                            //    " Values('" + r.Cells[0].Value + "','" + txtAttandanceDate.Text + "','" +
                            //    r.Cells[2].Value + "','" + r.Cells[5].Value + "','" + 
                            //    r.Cells[6].Value + "')",
                            //    Connection .MyConnection , trn );
                        //}
                    }
                    trn.Commit();
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataSet ds11 = Connection.GetDataSet("select count(*) from tbl_Attendance where AttendanceDate='" + txtAttandanceDate.Value.Date + "' and empNo='" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "'");
                    if (ds11.Tables[0].Rows[0][0].ToString() == "0")
                    {
                        Connection.AllPerform("insert into tbl_Attendance (EmpNo, AttendanceDate, Attendance)values('" + dataGridView1.Rows[i].Cells[0].Value + "','" + txtAttandanceDate.Text + "','" + dataGridView1.Rows[i].Cells[2].Value + "')");
                    }
                }
            }
            str1 = "SELECT     schoolname, schooladdress, affiliate_by, logoimage  FROM tbl_school";
            str1 = str1 + " SELECT tbl_Attendance.EmpNo, tbl_EmployeeInfo.EmpName, tbl_Attendance.Attendance,tbl_Attendance.AttendanceDate FROM tbl_Attendance INNER JOIN tbl_EmployeeInfo ON tbl_Attendance.EmpNo = tbl_EmployeeInfo.EmpNo WHERE (tbl_Attendance.AttendanceDate = '" + txtAttandanceDate.Value .Date  + "') order by tbl_Attendance.EmpNo";
            DataSet ds = Connection.GetDataSet(str1 );
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\TodaysAttendance.xsd");
            AttendanceReport cr1 = new AttendanceReport();
            cr1.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            cr1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            cr1.SetDataSource(ds);
            ShowAllReports  s = new ShowAllReports ();
            s.crystalReportViewer1.ReportSource = cr1;
            s.Show();
        }

        private void btnAttendanceBetweenReport_Click(object sender, EventArgs e)
        {
            DataSet dsAttendance = Connection.GetDataSet("GetAttendanceBetWeenDate '" + txtDateFrom.Value.Date + "','" + txtDateTo.Value.Date + "'     SELECT     schoolname, schooladdress, affiliate_by, logoimage  FROM         tbl_school");
            if (dsAttendance.Tables[0].Rows.Count > 0)
            {
                AttendanceDateBetween cr1 = new AttendanceDateBetween();
                cr1.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                cr1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                dsAttendance.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\AttendanceDateBetween.xsd");
                cr1.SetDataSource(dsAttendance);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr1;
                s.Show();
            }
            else
            {
                MessageBox.Show("Attendance Not Registered.");
                return;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        void GetEmployeeList()
        {
            try
            {
                this.dataGridView1.Rows.Clear();
                DataSet ds = Connection.GetDataSet("SELECT EI.EmpNo, EI.EmpName FROM tbl_EmployeeInfo EI INNER JOIN tbl_EmployeeSalaryInfo ESI on EI.EmpNo=ESI.empno and ESI.status=1 Where EI.IsActive=1 And EI.DOJ<='" + txtAttandanceDate.Value.Date + "' group by  EI.EmpNo, EI.EmpName order by EI.empNo");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        this.dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(),"P");
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Date Of Attendance!!!");
                    return;
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtAttandanceDate_Validated(object sender, EventArgs e)
        {
            this.GetEmployeeList();
            btnMonthAttendance.Text = btnMonthAttendance.Text = "Save Attendance Month Of " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(txtAttandanceDate.Value.Month);               
        }

        private void frmAddAttendance_Load(object sender, EventArgs e)
        {
            c1.GetMdiParent(this).ToggleSaveButton(true);
            this.GetEmployeeList();
            if (Convert.ToBoolean(Connection.GetAttributeObjectFromXMLFile("SystemSetting", "AttendanceMachine")))
            {
                btnMonthAttendance.Visible =  btnShowAttendance.Visible = true;
                btnMonthAttendance.Text = "Save Attendance Month Of " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(txtAttandanceDate.Value.Month);
                //DataSet dsMachineAttendance = Connection.GetDataSetFromXMLFile("SystemSetting");
            }
            else
            {
                btnMonthAttendance.Visible = btnShowAttendance.Visible = false;
                dataGridView1.Rows.Clear();
            }
            
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        private void btnShowAttendance_Click(object sender, EventArgs e)
        {
            Connection.SetValue_0_For_MS_Access_1_For_MS_Excel = 0;
            Connection.MSAccessFileInfoFullName = Convert.ToString(Connection.GetAttributeObjectFromXMLFile("Mahanta", "AttendanceMachinePath"));
            DataTable dsMachineAttendance = Connection.GetDataTableFromExcelFile("Select EmployeeID, InTime, OutTime, StatusCode "+
                " From AttendanceLogs Where AttendanceDate = #" + txtAttandanceDate.Value.Date.ToString("MM/dd/yyyy")  + "#");
            if (dsMachineAttendance.Rows.Count > 0)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                DataGridViewTextBoxColumn EmployeeId = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn Name = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn InTime = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn OutTime = new DataGridViewTextBoxColumn();
                DataGridViewComboBoxColumn StatusCode = new DataGridViewComboBoxColumn();
                DataGridViewTextBoxColumn TInTime = new DataGridViewTextBoxColumn();
                DataGridViewTextBoxColumn TOutTime = new DataGridViewTextBoxColumn();
                //EmployeeId.Name = "EmployeeId"; Name.Name = "Name";
                //StatusCode.Name = "StatusCode"; InTime.Name = "InTime"; OutTime.Name = "OutTime";
                //TInTime.Name = "TInTime"; TOutTime.Name = "TOutTime";
                EmployeeId.HeaderText = "Employee Id";
                Name.HeaderText = "Name";
                InTime.HeaderText = "In Time";
                OutTime.HeaderText = "Out Time";
                StatusCode.HeaderText = "Status";
                EmployeeId.Width = 60; Name.Width = 180;
                StatusCode.Width = 50; InTime.Width = 60; OutTime.Width = 60;
                TInTime.Visible = TOutTime.Visible = false;
                InTime.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                OutTime.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; 
                StatusCode.Items.AddRange(new object[] {"P", "A", "L", "W", "H"});
                dataGridView1.Columns.Add(EmployeeId); dataGridView1.Columns.Add(Name);
                dataGridView1.Columns.Add(StatusCode); dataGridView1.Columns.Add(InTime);
                dataGridView1.Columns.Add(OutTime); dataGridView1.Columns.Add(TInTime);
                dataGridView1.Columns.Add(TOutTime);
                this.dataGridView1.Rows.Clear();
                DataTable dtEmployee = Connection.GetDataTable("SELECT EmpNo, EmpName, AttendanceID FROM tbl_EmployeeInfo Where IsActive=1 And DOJ<='" + txtAttandanceDate.Value.Date + "' group by  EmpNo, EmpName, AttendanceID order by empNo");
                if (dtEmployee.Rows.Count > 0)
                {
                    dsMachineAttendance.Columns.Add("EmpNo", typeof(int));
                    dsMachineAttendance.Columns.Add("Name", typeof(string));
                    dsMachineAttendance.Columns.Add("TInTime", typeof(string));
                    dsMachineAttendance.Columns.Add("TOutTime", typeof(string));
                    foreach (DataRow r in dsMachineAttendance.Rows)
                    {
                        DataRow[] Records = dtEmployee.Select("AttendanceID = '" + r["EmployeeID"] + "'", "EmpName");
                        if (Records.Length > 0)
                        {
                            r["EmpNo"] = Records[0]["EmpNo"];
                            r["Name"] = Records[0]["EmpName"];
                            r["StatusCode"] = (r["StatusCode"].ToString().Contains("W")) ? "W" : (r["StatusCode"].ToString().Contains("½P")) ? "H" : r["StatusCode"];
                            r["InTime"] = (r["StatusCode"].Equals("A")) ? "" : r["InTime"];
                            r["OutTime"] = (r["StatusCode"].Equals("A")) ? "" : r["OutTime"];
                            r["TInTime"] = r["InTime"];
                            r["TOutTime"] = r["OutTime"];
                        }
                        dsMachineAttendance.AcceptChanges();
                        r.SetModified();
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Date Of Attendance!!!");
                    return;
                }
                dsMachineAttendance.DefaultView.Sort = "Name";
                foreach (DataRow i in dsMachineAttendance.Rows)
                {
                    if (i["Name"].Equals(DBNull.Value))
                        continue;
                        dataGridView1.Rows.Add(i["EmpNo"], i["Name"], i["StatusCode"],
                            (i["InTime"].Equals("")) ? "" : Convert.ToDateTime(i["InTime"]).ToString("HH:MM tt"),
                            (i["OutTime"].Equals("")) ? "" : Convert.ToDateTime(i["OutTime"]).ToString("HH:MM tt"),
                             i["TInTime"], i["TOutTime"]);
                }
            }
            else
            {
                MessageBox.Show("Record Has Not Found.\n\tPlease Fill Manual Or Please Check Date Of Attendance!!!");
                return;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try { }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnMonthAttendance_Click(object sender, EventArgs e)
        {
            if (btnShowAttendance.Visible)
            {
                if (DialogResult.Yes.Equals(MessageBox.Show("Are You Sure To Save Attendance Date Of \" " + txtAttandanceDate.Text + " \" ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                {
                    Connection.SetValue_0_For_MS_Access_1_For_MS_Excel = 0;
                    Connection.MSAccessFileInfoFullName = Convert.ToString(Connection.GetAttributeObjectFromXMLFile("Mahanta", "AttendanceMachinePath"));
                    DataTable dsMachineAttendance = Connection.GetDataTableFromExcelFile("Select EmployeeID, AttendanceDate, InTime, OutTime, StatusCode " +
                        " From AttendanceLogs Where MONTH(AttendanceDate) = MONTH(#" + txtAttandanceDate.Value.Date  + "#) And  "+
                        " YEAR(AttendanceDate) = YEAR(#" + txtAttandanceDate.Value.Date  + "#)");
                    if (dsMachineAttendance.Rows.Count > 0)
                    {
                        DataTable dtEmployee = Connection.GetDataTable("SELECT EmpNo, EmpName, AttendanceID FROM tbl_EmployeeInfo Where IsActive=1 And DOJ<='" + txtAttandanceDate.Value.Date + "' group by  EmpNo, EmpName, AttendanceID order by empNo");
                        if (dtEmployee.Rows.Count > 0)
                        {
                            dsMachineAttendance.Columns.Add("EmpNo", typeof(int));
                            foreach (DataRow r in dsMachineAttendance.Rows)
                            {
                                DataRow[] Records = dtEmployee.Select("AttendanceID = '" + r["EmployeeID"] + "'", "EmpName");
                                if (Records.Length > 0)
                                {
                                    r["EmpNo"] = Records[0]["EmpNo"];
                                    r["StatusCode"] = (r["StatusCode"].ToString().Contains("W")) ? "W" : (r["StatusCode"].ToString().Contains("½P")) ? "H" : r["StatusCode"];
                                }
                                dsMachineAttendance.AcceptChanges();
                                r.SetModified();
                            }
                            System.Data.SqlClient.SqlTransaction trn = Connection.GetMyConnection().BeginTransaction();

                            Connection.SqlTransection("Delete From tbl_Attendance Where MONTH(AttendanceDate) = '" +
                                txtAttandanceDate.Value.Month + "' And YEAR(AttendanceDate) = '" + txtAttandanceDate.Value.Year + "'",
                                Connection.MyConnection, trn);

                            foreach (DataRow r in dsMachineAttendance.Rows)
                            {
                              
                                if (r["EmpNo"].Equals(DBNull.Value))
                                    continue;
                                Connection.SqlTransection("insert into tbl_Attendance (EmpNo, AttendanceDate, Attendance, TimeIn, TimeOut) " +
                                    " Values('" + r["EmpNo"] + "','" + r["AttendanceDate"] + "','" +
                                    r["StatusCode"] + "','" + r["InTime"] + "','" + r["OutTime"] + "')",
                                    Connection.MyConnection, trn);
                            }
                            trn.Commit();
                            MessageBox.Show("Saved...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void frmAddAttendance_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void txtAttandanceDate_ValueChanged(object sender, EventArgs e)
        {
            this.GetEmployeeList();
            btnMonthAttendance.Text = btnMonthAttendance.Text = "Save Attendance Month Of " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(txtAttandanceDate.Value.Month);        
        }
    }
}
