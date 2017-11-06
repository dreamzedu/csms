using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class frmMonthlySalaryCalculation :UserControlBase
    {
        decimal SalaryRate, DAAmt, HRAAmt, PFAmt, SpecialIncentive, ESICAmt, LoanAmt, LICAmt;
        decimal OneDaySalary, TotalPaidDay, GeneratedAmount, MinusAmount, PlusAmount;
        
        public frmMonthlySalaryCalculation()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmSalaryCalculation_Load(object sender, EventArgs e)
        {
            Connection.FillComboMonthName(cmbMonth,true);
            Connection.FillComboYear(cmbYear, 2013, 2020 ,true);
        }

        private void cmbMonth_Validated(object sender, EventArgs e)
        {
            try
            {
                if (cmbMonth.SelectedIndex != 0 && cmbYear.SelectedIndex != 0)
                {
                    DataSet dsAttendance = Connection.GetDataSet("GetAttendanceByMonth '" + cmbMonth.SelectedIndex + "','" + cmbYear.Text + "'");
                     dataGridView1.Rows.Clear();
                    if (dsAttendance.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsAttendance.Tables[0].Rows.Count; i++)
                        {
                            if (i == 16)
                            {
                            }
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["EmployeeID"].Value = dsAttendance.Tables[0].Rows[i]["EmpNo"];
                            dataGridView1.Rows[i].Cells["Name"].Value = dsAttendance.Tables[0].Rows[i]["EmpName"];
                            dataGridView1.Rows[i].Cells["FatherName"].Value = dsAttendance.Tables[0].Rows[i]["FathersName"];
                            dataGridView1.Rows[i].Cells["Designation"].Value = dsAttendance.Tables[0].Rows[i]["Designation"];
                            dataGridView1.Rows[i].Cells["Present"].Value = dsAttendance.Tables[0].Rows[i]["Present"];
                            dataGridView1.Rows[i].Cells["Absent"].Value = dsAttendance.Tables[0].Rows[i]["Absent"];
                            dataGridView1.Rows[i].Cells["PaidLeave"].Value = dsAttendance.Tables[0].Rows[i]["PaidLeave"];
                            dataGridView1.Rows[i].Cells["WeekOff"].Value = dsAttendance.Tables[0].Rows[i]["WeekOff"];
                            DataSet dsSalary = Connection.GetDataSet("SELECT empno,Month(startdate) as StartDate, ISNULL(Month(enddate),'" + cmbMonth.SelectedIndex + "') AS EndDate, status, salaryrate, pf, lic, loan, rsa, aleave, balleave, pfnumber, el, elbal, splinctv,EnCLLeave, DA, HRA,IsActive, Ele, DAAmt, PFAmt, NetSalary, ESIC, ESICAmt, ML FROM  tbl_EmployeeSalaryInfo     WHERE    (empno = '" + dsAttendance.Tables[0].Rows[i]["EmpNo"] + "') and status=1 ");
                            if (dsSalary.Tables[0].Rows.Count > 0)
                            {
                                DataView dv = new DataView();
                                dv = dsSalary.Tables[0].DefaultView;
                                //if (Convert.ToInt32(dsSalary.Tables[0].Rows[0]["StartDate"]) > cmbMonth.SelectedIndex && Convert.ToInt32(dsSalary.Tables[0].Rows[0]["EndDate"]) > cmbMonth.SelectedIndex)
                                //{
                                //    dv.RowFilter = "StartDate <='" + cmbMonth.SelectedIndex + "' And EndDate >='" + cmbMonth.SelectedIndex + "'And empno='" + dsAttendance.Tables[0].Rows[i]["EmpNo"] + "'";
                                //}
                                //else if (Convert.ToInt32(dsSalary.Tables[0].Rows[0]["StartDate"]) == Convert.ToInt32(dsSalary.Tables[0].Rows[0]["EndDate"]) &&
                                //    Convert.ToInt32(dsSalary.Tables[0].Rows[0]["StartDate"]) ==cmbMonth.SelectedIndex)
                                //{
                                //    dv.RowFilter = " empno='" + dsAttendance.Tables[0].Rows[i]["EmpNo"] + "'";
                                //}
                                // else
                                //{
                                //    dv.RowFilter = "StartDate >='" + cmbMonth.SelectedIndex + "' And EndDate <='" + cmbMonth.SelectedIndex + "'And empno='" + dsAttendance.Tables[0].Rows[i]["EmpNo"] + "'";
                                //}
                                this.OneDaySalary = decimal.Round((Convert.ToDecimal(dv[0]["salaryrate"]) / DateTime.DaysInMonth(Convert.ToInt32(cmbYear.Text), cmbMonth.SelectedIndex)), 2);
                                dataGridView1.Rows[i].Cells["PFNo"].Value = dv[0]["pfnumber"];
                                this.SalaryRate = Convert.ToDecimal(dv[0]["salaryrate"]);
                                this.DAAmt = Convert.ToDecimal(dv[0]["DAAmt"]);
                                this.HRAAmt = Convert.ToDecimal(dv[0]["HRA"]);
                                this.SpecialIncentive = Convert.ToDecimal(dv[0]["rsa"]);
                                this.PFAmt = Convert.ToDecimal(dv[0]["PFAmt"]);
                                this.ESICAmt = Convert.ToDecimal(dv[0]["ESICAmt"]);
                                this.LoanAmt = Convert.ToDecimal(dv[0]["loan"]);
                                this.LICAmt = Convert.ToDecimal(dv[0]["lic"]);
                            }
                            dataGridView1.Rows[i].Cells["DaySalary"].Value = this.OneDaySalary;
                            dataGridView1.Rows[i].Cells["BasicSalary"].Value = this.SalaryRate;
                            dataGridView1.Rows[i].Cells["DAAmount"].Value = this.DAAmt;
                            dataGridView1.Rows[i].Cells["HRA"].Value = this.HRAAmt;
                            dataGridView1.Rows[i].Cells["SpecialIncentiveAmount"].Value = this.SpecialIncentive;
                            dataGridView1.Rows[i].Cells["PFAmount"].Value = this.PFAmt;
                            dataGridView1.Rows[i].Cells["ESICAmount"].Value = this.ESICAmt;
                            dataGridView1.Rows[i].Cells["LICAmount"].Value = this.LICAmt;
                            dataGridView1.Rows[i].Cells["LoanAmount"].Value = this.LoanAmt;
                            dataGridView1.Rows[i].Cells["LICAmount"].Value = this.LICAmt;
                            this.TotalPaidDay = ((Convert.ToInt32(dsAttendance.Tables[0].Rows[i]["Present"]) + Convert.ToInt32(dsAttendance.Tables[0].Rows[i]["PaidLeave"])
                                + Convert.ToInt32(dsAttendance.Tables[0].Rows[i]["WeekOff"])));
                            this.GeneratedAmount = this.TotalPaidDay * this.OneDaySalary;
                            this.PlusAmount = this.HRAAmt + this.DAAmt + this.SpecialIncentive;
                            this.MinusAmount = this.PFAmt + this.ESICAmt + this.LoanAmt + this.LICAmt;
                            dataGridView1.Rows[i].Cells["NetSalary"].Value = decimal.Round((this.GeneratedAmount + this.PlusAmount) - this.MinusAmount, 2);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Attendance Not Registered!", "Alert !!! ");
                        dataGridView1.Rows.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Mandatory Field!", "Alert !!! ");
                    dataGridView1.Rows.Clear();
                }
            }

            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        

        private void btnAttendanceBetweenReport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DataSet ds = Connection.GetDataSet(" SELECT schoolname, schooladdress, affiliate_by, logoimage  FROM tbl_school");
                DataTable dt = Connection.GetDataTableFromDataGridView(dataGridView1);
                DataView dv = Connection.GetDataSet("Select EmpNo,EmpName,AccountNo,BankName From tbl_EmployeeInfo").Tables[0].DefaultView;
                dt.Columns.Add("AccountNo"); dt.Columns.Add("BankName");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dv.RowFilter = "EmpNo =" + dt.Rows[i][0];
                    dt.Rows[i]["AccountNo"] = dv[0][2];
                    dt.Rows[i]["BankName"] = dv[0][3];
                }
                ds.Tables.Add(dt);
                rptSalaryStatementForBank cr1 = new rptSalaryStatementForBank();
                cr1.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                cr1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\SalaryStatementForBank.xsd");
                cr1.SetDataSource(ds);
                cr1.SetParameterValue("Month", new DateTime(Convert.ToInt16(cmbYear.Text), cmbMonth.SelectedIndex, 1));
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr1;
                s.Show();
            }
            else
            {
                MessageBox.Show("Record Not Shown.\n\tPlease Select Month And Press Tab Key.");
            }
        }

        private void btnreportforbank_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DataSet ds = Connection.GetDataSet(" SELECT schoolname, schooladdress, affiliate_by, logoimage  FROM tbl_school");
                DataTable dt = Connection.GetDataTableFromDataGridView(dataGridView1);
                ds.Tables.Add(dt);
                rptSalaryStatementForOther cr1 = new rptSalaryStatementForOther();
                cr1.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                cr1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\SalaryStatementForOther.xsd");
                cr1.SetDataSource(ds);
                cr1.SetParameterValue("Month", new DateTime(Convert.ToInt16(cmbYear.Text), cmbMonth.SelectedIndex, 1));
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr1;
                s.Show();
            }
            else
            {
                MessageBox.Show("Record Not Shown.\n\tPlease Select Month And Press Tab Key.");
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush sb = new SolidBrush(Color.Maroon))
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), new Font("Tahoma", 9F, FontStyle.Bold), sb, e.RowBounds.X + 3, e.RowBounds.Y + 3);
        }

        private void btnSalaryStatement_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DataSet ds = Connection.GetDataSet(" SELECT schoolname, schooladdress, affiliate_by, logoimage  FROM tbl_school");
                DataTable dt = Connection.GetDataTableFromDataGridView(dataGridView1);
                ds.Tables.Add(dt);
                SalaryStatement cr1 = new SalaryStatement();
                cr1.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                cr1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\SalaryStatement.xsd");
                cr1.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr1;
                s.Show();
            }
            else
            {
                MessageBox.Show("Record Not Shown.\n\tPlease Select Month And Press Tab Key.");
            }
        }

        private void frmMonthlySalaryCalculation_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);

        }
         
         
    }
}
