using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class frmNewSalaryPayment :UserControlBase
    {
        decimal SalaryRate, DAAmt, HRAAmt, PFAmt, SpecialIncentive, ESICAmt, LoanAmt, LICAmt;
        decimal OneDaySalary, TotalPaidDay, GeneratedAmount, MinusAmount, PlusAmount;
        public frmNewSalaryPayment()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frmNewSalaryPayment_Load(object sender, EventArgs e)
        {
            Connection.FillComboMonthName(cmbMonth, true);
            Connection.FillComboYear(cmbYear, 2013, 2018, true);
        }

        private void cmbMonth_Validated(object sender, EventArgs e)
        {
            try
            {
                if (cmbMonth.SelectedIndex != 0 && cmbYear.SelectedIndex != 0)
                {
                    DataSet dsAttendance = Connection.GetDataSet("GetAttendanceByMonth '" + cmbMonth.SelectedIndex + "','" + cmbYear.Text + "'");
                    //   DataSet dsSalary = Connection.GetDataSet("SELECT empno, startdate, enddate, status, salaryrate, pf, lic, loan, rsa, aleave, balleave, pfnumber, el, elbal, splinctv, EnCLLeave, DA, HRA, SalaryNo, IsActive, Ele, DAAmt, PFAmt, NetSalary, ESIC, ESICAmt, ML, FROM tbl_EmployeeSalaryInfo WHERE (enddate IS NULL) OR (MONTH(enddate) <= '" + cmbMonth.SelectedIndex + "') And OR (Year(enddate) <= '" + cmbYear.Text + "')");
                    dataGridView1.Rows.Clear();
                    if (dsAttendance.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dsAttendance.Tables[0].Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["Paid"].Value = false;
                            dataGridView1.Rows[i].Cells["EmployeeID"].Value = dsAttendance.Tables[0].Rows[i]["EmpNo"];
                            dataGridView1.Rows[i].Cells["Name"].Value = dsAttendance.Tables[0].Rows[i]["EmpName"];
                            dataGridView1.Rows[i].Cells["FatherName"].Value = dsAttendance.Tables[0].Rows[i]["FathersName"];
                            dataGridView1.Rows[i].Cells["Designation"].Value = dsAttendance.Tables[0].Rows[i]["Designation"];
                            dataGridView1.Rows[i].Cells["AccountNo"].Value = dsAttendance.Tables[0].Rows[i]["AccountNo"];
                            dataGridView1.Rows[i].Cells["BankName"].Value = dsAttendance.Tables[0].Rows[i]["BankName"];
                            DataSet dsSalary = Connection.GetDataSet("SELECT empno,Month(startdate) as StartDate, ISNULL(Month(enddate),'" + cmbMonth.SelectedIndex + "') AS EndDate, status, salaryrate, pf, lic, loan, rsa, aleave, balleave, pfnumber, el, elbal, splinctv,EnCLLeave, DA, HRA, IsActive, Ele, DAAmt, PFAmt, NetSalary, ESIC, ESICAmt, ML FROM  tbl_EmployeeSalaryInfo WHERE     (empno = '" + dsAttendance.Tables[0].Rows[i]["EmpNo"] + "') and status=1 ");
                            if (dsSalary.Tables[0].Rows.Count > 0)
                            {
                                DataView dv = new DataView();
                                dv = dsSalary.Tables[0].DefaultView;
                                //dv.RowFilter = "StartDate<='" + cmbMonth.SelectedIndex + "' And EndDate>='" + cmbMonth.SelectedIndex + "'And empno='" + dsAttendance.Tables[0].Rows[i]["EmpNo"] + "'";
                                this.OneDaySalary = decimal.Round((Convert.ToDecimal(dv[0]["salaryrate"]) / DateTime.DaysInMonth(Convert.ToInt32(cmbYear.Text), cmbMonth.SelectedIndex)), 2);
                                this.SalaryRate = Convert.ToDecimal(dv[0]["salaryrate"]);
                                this.DAAmt = Convert.ToDecimal(dv[0]["DAAmt"]);
                                this.HRAAmt = Convert.ToDecimal(dv[0]["HRA"]);
                                this.SpecialIncentive = Convert.ToDecimal(dv[0]["rsa"]);
                                this.PFAmt = Convert.ToDecimal(dv[0]["PFAmt"]);
                                this.ESICAmt = Convert.ToDecimal(dv[0]["ESICAmt"]);
                                this.LoanAmt = Convert.ToDecimal(dv[0]["loan"]);
                                this.LICAmt = Convert.ToDecimal(dv[0]["lic"]);
                            }
                            dataGridView1.Rows[i].Cells["BasicSalary"].Value = this.SalaryRate;
                            this.TotalPaidDay = ((Convert.ToInt32(dsAttendance.Tables[0].Rows[i]["Present"]) + Convert.ToInt32(dsAttendance.Tables[0].Rows[i]["PaidLeave"])
                                + Convert.ToInt32(dsAttendance.Tables[0].Rows[i]["WeekOff"])));
                            this.GeneratedAmount = this.TotalPaidDay * this.OneDaySalary;
                            this.PlusAmount = this.HRAAmt + this.DAAmt + this.SpecialIncentive;
                            this.MinusAmount = this.PFAmt + this.ESICAmt + this.LoanAmt + this.LICAmt;
                            dataGridView1.Rows[i].Cells["NetSalary"].Value = decimal.Round((this.GeneratedAmount + this.PlusAmount) - this.MinusAmount, 2);
                            dataGridView1.Rows[i].Cells["PaymentType"].Value = "Cash";
                        }
                        SqlDataReader drPaidSalary = Connection.GetDataReader("SELECT EmpNo, PaymentYear, PaymentMonth, PaymentDate, BasicSalary, NetSalary, PaidSalary, RemainingSalary, PaymentType, BankName, ChequeNo,AccountNo, PaidStatus, Status FROM tbl_NewSalaryPayment WHERE  (PaymentMonth ='" + cmbMonth.SelectedIndex + "') AND (PaymentYear = '" + cmbYear.Text + "') AND (Status = 1) ORDER BY EmpNo");
                        if (drPaidSalary != null)
                        {
                            while (drPaidSalary.Read())
                            {
                                foreach (DataGridViewRow rw in dataGridView1.Rows)
                                {
                                    if (rw.Cells["EmployeeID"].Value.ToString().Equals(drPaidSalary["EmpNo"].ToString()))
                                    {
                                        rw.Cells["Paid"].Value = drPaidSalary["PaidStatus"];
                                        rw.Cells["Payment"].Value = drPaidSalary["PaidSalary"];
                                        rw.Cells["PaymentType"].Value = drPaidSalary["PaymentType"];
                                        rw.Cells["ChequeNo"].Value = drPaidSalary["ChequeNo"];
                                        rw.Cells["BankName"].Value = drPaidSalary["BankName"];
                                        rw.Cells["AccountNo"].Value = drPaidSalary["AccountNo"];
                                        rw.DefaultCellStyle.BackColor = Color.LightGray;
                                        rw.DefaultCellStyle.ForeColor = Color.Green;
                                        rw.ReadOnly = true;
                                    }
                                }
                            }
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

            catch(Exception ex){Logger.LogError(ex); }
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["Payment"].ColumnIndex)
                {
                    decimal d = 0;

                    if (decimal.TryParse(dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value.ToString(), out d))
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value = decimal.Round(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value), 2);
                    }
                    else
                        dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value = d;
                }
                else if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Rows[e.RowIndex].Cells["PaymentType"].ColumnIndex)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["PaymentType"].Value.ToString() == "Cash")
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["ChequeNo"].ReadOnly = true;
                        dataGridView1.Rows[e.RowIndex].Cells["BankName"].ReadOnly = true;
                        dataGridView1.Rows[e.RowIndex].Cells["AccountNo"].ReadOnly = true;
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["ChequeNo"].ReadOnly = false;
                        dataGridView1.Rows[e.RowIndex].Cells["BankName"].ReadOnly = true;
                        dataGridView1.Rows[e.RowIndex].Cells["AccountNo"].ReadOnly = true;
                    }
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value != null)
                {
                    if (Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value) > 0)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Paid"].Value = true;
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                        dataGridView1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
                else
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Paid"].Value = false;
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnMakePayment_Click(object sender, EventArgs e)
        {
            if (cmbMonth.SelectedIndex != 0 && cmbYear.SelectedIndex != 0)
            {
                SqlTransaction trn = Connection.GetMyConnection().BeginTransaction();
                try
                {
                    trn.Commit();
                    foreach (DataGridViewRow rw in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(rw.Cells["Paid"].FormattedValue) != false && rw.ReadOnly != true)
                        {
                            trn = Connection.GetMyConnection().BeginTransaction();
                            Connection.SqlTransection("INSERT INTO tbl_NewSalaryPayment( EmpNo, PaymentYear, PaymentMonth, PaymentDate, BasicSalary, NetSalary, PaidSalary, RemainingSalary, PaymentType, BankName, ChequeNo,AccountNo, PaidStatus, Status ) " +
                            " Values('" + rw.Cells["EmployeeID"].Value + "','" + cmbYear.Text + "','" + cmbMonth.SelectedIndex + "','" + dtpPaymentDate.Value.Date + "','" + rw.Cells["BasicSalary"].Value + "','" + rw.Cells["NetSalary"].Value + "',  " +
                            " '" + rw.Cells["Payment"].Value + "','" + (Convert.ToDecimal(rw.Cells["NetSalary"].Value) - Convert.ToDecimal(rw.Cells["Payment"].Value)) + "','" + rw.Cells["PaymentType"].Value + "','" + rw.Cells["BankName"].Value + "','" +
                            rw.Cells["ChequeNo"].Value + "','" + rw.Cells["AccountNo"].Value + "','true','1')", Connection.MyConnection, trn);
                            trn.Commit();
                            int Pytid = Convert.ToInt32(Connection.GetId("select max(PayId) from tbl_NewSalaryPayment"));
                            DateTime EDT;
                            trn = Connection.GetMyConnection().BeginTransaction();
                            int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_account where accode='" + rw.Cells["EmployeeID"].Value + "' and actype=dbo.GetAccountCode('S')"));
                            EDT = Convert.ToDateTime(Connection.GetId("select DOJ total from tbl_EmployeeInfo where EmpNo='" + rw.Cells["EmployeeID"].Value + "'"));
                            if (CCEID < 1)
                            {
                                Connection.SqlTransection("insert into dbo.tbl_account(accode, acname, actype, acopbal, acoptype, apanno, accaddress, budgtype, opdate, subledger,lf,issaldeduct) " +
                                " values ('" + rw.Cells["EmployeeID"].Value + "',dbo.GetEName('" + rw.Cells["EmployeeID"].Value
                                + "'),dbo.GetAccountCode('S'),0,'Dr','none','none',0,'" + EDT + "',0,'1',0)",
                                Connection.MyConnection, trn);
                            }

                            //insert Voucher main
                            Connection.SqlTransection("insert into dbo.tbl_Voucher(VchNo, VchType, VchDate, Remark, sessioncode) " +
                            " values ('" + Pytid + "','JV','" + dtpPaymentDate.Value.Date + "','Paid Sailary to Employee','" +
                            school.CurrentSessionCode + "')",
                            Connection.MyConnection, trn);

                            //insert Voucher Detail Dr
                            Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                                school.CurrentSessionCode + "','JV','" + Pytid + "',dbo.GetAccountCode('CS'),'" +
                                (Convert.ToDecimal(rw.Cells["Payment"].Value)) + "','" +
                                dtpPaymentDate.Value.Date + "','Cr','S')",
                            Connection.MyConnection, trn);
                            //insert Voucher Detail Cr
                            Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                                school.CurrentSessionCode + "','JV','" + Pytid + "','" + rw.Cells["EmployeeID"].Value + "','" +
                                (Convert.ToDecimal(rw.Cells["Payment"].Value)) + "','" +
                                dtpPaymentDate.Value.Date + "','Dr','M')",
                            Connection.MyConnection, trn);
                            if (rw.Cells["PaymentType"].Value.ToString() == "Cash")
                            {

                            }
                            trn.Commit();
                            
                        }
                    }
                    MessageBox.Show("Payment Record Save Successfully.", "Alert !!! ");
                    dataGridView1.Rows.Clear();
                    
                }
                catch
                {
                    trn.Rollback();
                    MessageBox.Show("Payment Transection Not Saved !!!\n\tPlease Try Again.", "Alert !!! ");
                }
            }
            else
            {
                MessageBox.Show("Please Select Mandatory Field!", "Alert !!! ");
                dataGridView1.Rows.Clear();
            }
        }

        private void btnSalaryPaymentReport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DataSet ds = Connection.GetDataSet(" SELECT schoolname, schooladdress, affiliate_by, logoimage  FROM tbl_school");
                DataTable dt = Connection.GetDataTableFromDataGridView(dataGridView1);
                ds.Tables.Add(dt);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\SalaryPaymentRecord.xsd");
                rptSalaryPaymentRecord cr1 = new rptSalaryPaymentRecord();
                cr1.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                cr1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                cr1.SetDataSource(ds);
                cr1.SetParameterValue("Month", new DateTime(Convert.ToInt16(cmbYear.Text), cmbMonth.SelectedIndex, 1));
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr1;
                s.Show();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //using (SolidBrush sb = new SolidBrush(Color.Maroon))
            //    e.Graphics.DrawString((e.RowIndex + 1).ToString(), new Font("Tahoma", 9F, FontStyle.Bold), sb, e.RowBounds.X + 3, e.RowBounds.Y + 3);
        }

        private void frmNewSalaryPayment_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}