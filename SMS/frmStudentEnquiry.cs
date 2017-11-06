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
    public partial class frmStudentEnquiry :UserControlBase
    {
        public frmStudentEnquiry()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);

        }
        school c = new school();
        static int StuId = 0;
        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        public void Clear()
        {
            txtStudentName.Text = string.Empty;
            txtPaddtress.Text = string.Empty;
            txtfather.Text = string.Empty;
            txtmother.Text = string.Empty;
            txtMobileNo.Text = string.Empty;
        }
        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Fill Student Name!!!!");
                return;
            }
            else
            {
                SqlTransaction trn = null;
                trn = Connection.GetMyConnection().BeginTransaction();
                Connection.SqlTransection("Insert InTo tbl_student_enquiry(name, dob, P_address,father, mother,m_tongue, casttype,admclass,RegDate,phone,marr_status ) Values(" +
                  "'" + txtStudentName.Text + "','" + dtpdob.Value + "','" + txtPaddtress.Text + "','" + txtfather.Text + "','" + txtmother.Text + "', '"
                                + strmtongue.Text + "', '" + strstdcategory.Text + "', '" + valcmbclass.SelectedValue.ToString() + "', '" +
                                                    txtRegDate.Value + "', '" + txtMobileNo.Text + "', '" + strcmbsex.Text + "')", Connection.MyConnection, trn);
               
                trn.Commit();
                StuId = Convert.ToInt32(Connection.GetId("Select IsNull((Max(studentno)),0) From tbl_student_enquiry"));
                MessageBox.Show("Record save successfully!!!");
                Clear();
                

            }
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            string str = "";
            str = "SELECT     dbo.tbl_student_enquiry.name, dbo.tbl_student_enquiry.dob, dbo.tbl_student_enquiry.P_address, dbo.tbl_student_enquiry.father, dbo.tbl_student_enquiry.mother, dbo.tbl_student_enquiry.m_tongue, dbo.tbl_student_enquiry.casttype, dbo.tbl_student_enquiry.RegDate, dbo.tbl_student_enquiry.phone,dbo.tbl_student_enquiry.marr_status ,  dbo.tbl_classmaster.classname, dbo.tbl_student_enquiry.studentno FROM         dbo.tbl_classmaster INNER JOIN dbo.tbl_student_enquiry ON dbo.tbl_classmaster.classcode = dbo.tbl_student_enquiry.admclass where tbl_student_enquiry.studentno='" + StuId + "'";
            str = str + "SELECT     schoolname, schooladdress, affiliate_by, logoimage, schoolphone   FROM         tbl_school   ";
            str = str + "SELECT     CONVERT(varchar(10), GETDATE(), 103) AS Expr1";
            DataSet ds = Connection.GetDataSet(str);
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\Enquiry.xsd");
            Enquiryform fr = new Enquiryform();
            fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            fr.SetDataSource(ds);
            ShowAllReports s = new ShowAllReports();
            s.crystalReportViewer1.ReportSource = fr;
            s.Show();
        }

        private void frmStudentEnquiry_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(valcmbclass, "select distinct classcode,classname, ClassOrder from tbl_classmaster order by ClassOrder");
            Connection.FillCombo(ref strmtongue, "select distinct m_tongue from tbl_student where Datalength(m_tongue)>0");
            strstdcategory.SelectedIndex = 0;
            strcmbsex.SelectedIndex = 0;
            c.GetMdiParent(this).ToggleSaveButton(true);
            c.GetMdiParent(this).TogglePrintButton(true);
        }

        private void frmStudentEnquiry_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void txtStudentName_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }
    }
}
