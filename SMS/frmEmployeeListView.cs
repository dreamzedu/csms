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
    public partial class frmEmployeeListView :UserControlBase
    {
        DataSet ds = new DataSet();
        public frmEmployeeListView()
        {
            InitializeComponent(); //   DesignForm.fromDesign1(this);
            Connection.SetUserControlTheme(this);
        }

        private void frmEmployeeListView_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("select Detail from tbl_EmployeeType order by Detail");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                cmbempcategory.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
            cmbempcategory.SelectedIndex = 0;
        }

        private void btncancle_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (cmbempcategory.Text != "")
            {
                string select = cmbempcategory.SelectedItem.ToString();
                string str;
                if (select == "All Employee")
                {
                    //str = "select convert(varchar, EmpNo),EmpName,FathersName,Gender,Address,convert(varchar,doj,103)DOJ,convert(varchar,dob,103)DOB,IsActive,tbl_EmployeeType .Detail Employee_Type, designation Designation,salaryrate Salary,rsa Spl_All,pf PF,lic Lic,loan Loan,splinctv Spl_Inc,pfnumber PF_No,aleave A_Leave,balleave Bal_Leave,el El,elbal ElBal,enclleave EnCashLeave,contactno Contact_No,da DA,daamt,pfamt,hra HRA,ESIC,ESICAmt from tbl_employeeinfo,tbl_EmployeeType where tbl_EmployeeInfo .EmpTypeId =tbl_EmployeeType .EmpTypeId  ";
                    //str = str + " SELECT schoolname, schooladdress, affiliate_by, logoimage FROM tbl_school ";
                    //ds = Connection.GetDataSet(str);
                    str = "SELECT     tbl_EmployeeInfo.EmpNo, tbl_EmployeeInfo.EmpName, tbl_EmployeeInfo.FathersName, tbl_EmployeeInfo.Address, tbl_EmployeeInfo.DOJ, tbl_EmployeeInfo.DOB, tbl_EmployeeInfo.Gender, tbl_EmployeeInfo.salaryrate, tbl_EmployeeInfo.pf, tbl_EmployeeInfo.lic, tbl_EmployeeInfo.loan, tbl_EmployeeInfo.designation, tbl_EmployeeInfo.photo, tbl_EmployeeInfo.rsa, tbl_EmployeeInfo.pfnumber, tbl_EmployeeInfo.splinctv, tbl_EmployeeInfo.HRA, tbl_EmployeeInfo.contactno, tbl_EmployeeInfo.DAAmt, tbl_EmployeeInfo.PFAmt, tbl_EmployeeInfo.ESICAmt,  tbl_EmployeeInfo.AccountNo, tbl_EmployeeInfo.BankName, tbl_EmployeeInfo.DA, tbl_EmployeeInfo.ESIC, tbl_EmployeeType.Detail FROM         tbl_EmployeeInfo INNER JOIN      tbl_EmployeeType ON tbl_EmployeeInfo.EmpTypeId = tbl_EmployeeType.EmpTypeId  ";
                    str = str + " SELECT schoolname, schooladdress, affiliate_by, logoimage FROM tbl_school ";
                    ds = Connection.GetDataSet(str);
                }
                else
                {
                    //str = "select convert(varchar, EmpNo),EmpName,FathersName,Gender,Address,convert(varchar,doj,103)DOJ,convert(varchar,dob,103)DOB,IsActive,tbl_EmployeeType .Detail Employee_Type, designation Designation,salaryrate Salary,rsa Spl_All,pf PF,lic Lic,loan Loan,splinctv Spl_Inc,pfnumber PF_No,aleave A_Leave,balleave Bal_Leave,el El,elbal ElBal,enclleave EnCashLeave,contactno Contact_No,da DA,daamt,pfamt,hra HRA,ESIC,ESICAmt from tbl_employeeinfo,tbl_EmployeeType where tbl_EmployeeInfo .EmpTypeId =tbl_EmployeeType .EmpTypeId and tbl_EmployeeType.Detail='" + select + "'";
                    //str = str + " SELECT schoolname, schooladdress, affiliate_by, logoimage FROM tbl_school ";
                    //ds = Connection.GetDataSet(str);
                    str = "SELECT     tbl_EmployeeInfo.EmpNo, tbl_EmployeeInfo.EmpName, tbl_EmployeeInfo.FathersName, tbl_EmployeeInfo.Address, tbl_EmployeeInfo.DOJ, tbl_EmployeeInfo.DOB, tbl_EmployeeInfo.Gender, tbl_EmployeeInfo.salaryrate, tbl_EmployeeInfo.pf, tbl_EmployeeInfo.lic, tbl_EmployeeInfo.loan, tbl_EmployeeInfo.designation, tbl_EmployeeInfo.photo, tbl_EmployeeInfo.rsa, tbl_EmployeeInfo.pfnumber, tbl_EmployeeInfo.splinctv, tbl_EmployeeInfo.HRA, tbl_EmployeeInfo.contactno, tbl_EmployeeInfo.DAAmt, tbl_EmployeeInfo.PFAmt, tbl_EmployeeInfo.ESICAmt,  tbl_EmployeeInfo.AccountNo, tbl_EmployeeInfo.BankName, tbl_EmployeeInfo.DA, tbl_EmployeeInfo.ESIC, tbl_EmployeeType.Detail FROM         tbl_EmployeeInfo INNER JOIN      tbl_EmployeeType ON tbl_EmployeeInfo.EmpTypeId = tbl_EmployeeType.EmpTypeId Where tbl_EmployeeType.Detail=N'" + select + "'";
                    str = str + " SELECT schoolname, schooladdress, affiliate_by, logoimage FROM tbl_school ";
                    ds = Connection.GetDataSet(str);
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("There is no Record.");
                    return;
                }
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\EmployeeListReport.xsd");
                rptEmployeeList rl = new rptEmployeeList();
                rl.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                rl.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                rl.SetDataSource(ds);
                ShowAllReports f = new ShowAllReports();
                f.crystalReportViewer1.ReportSource = rl;
                f.Show();
            }
            else
            {
                MessageBox.Show("Please Select Any One Category.");
            }
          

        }

        private void frmEmployeeListView_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
