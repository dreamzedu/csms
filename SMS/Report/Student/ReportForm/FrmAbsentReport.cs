using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Report.Student.ReportForm
{
    public partial class FrmAbsentReport :UserControlBase
    {
        school1 c1 = new school1();
        public FrmAbsentReport()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        
        public void GetAttendanceDetails(DateTime fdt, DateTime tdt)
        {
            DataSet ds = new DataSet();
            string qry = "SELECT     dbo.tbl_student.scholarno as [Scholar No], dbo.tbl_student.name as Name, dbo.tbl_classmaster.classname as Class,dbo.tbl_section.sectionname as Section,convert(nvarchar(10), dbo.tbl_StudentAttendancedet.AttendanceDate,103)   as [Attendance Date],  case when dbo.tbl_StudentAttendancedet.Attendance='True' then 'Present' else 'Absent' end as Attendance FROM         dbo.tbl_student INNER JOIN dbo.tbl_StudentAttendancedet ON dbo.tbl_student.studentno = dbo.tbl_StudentAttendancedet.studentno INNER JOIN dbo.tbl_classstudent ON dbo.tbl_student.studentno = dbo.tbl_classstudent.studentno INNER JOIN dbo.tbl_classmaster ON dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode INNER JOIN  dbo.tbl_section ON dbo.tbl_classstudent.Section = dbo.tbl_section.sectioncode where dbo.tbl_classstudent.classno='" + cmbClass.SelectedValue.ToString() + "' and dbo.tbl_classstudent.Section='" + cmbSection.SelectedValue.ToString() + "' and dbo.tbl_classstudent.sessioncode='" + school.CurrentSessionCode + "' and dbo.tbl_StudentAttendancedet.AttendanceDate between '" + fdt.ToString("MM/dd/yyyy") + "' and '" + tdt.ToString("MM/dd/yyyy") + "' and dbo.tbl_StudentAttendancedet.Attendance='False'  order by dbo.tbl_StudentAttendancedet.AttendanceDate";
            ds = Connection.GetDataSet(qry);
            dataGridView1.DataSource = ds.Tables[0];

        }
        private void FrmAbsentReport_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void FrmAbsentReport_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Order By ClassOrder");
            Connection.FillComboBox(cmbSection, "Select SectionCode ,SectionName From tbl_Section");
            cmbType.SelectedIndex = 0;
            cmbType.Text = "Daily";
            c1.GetMdiParent(this).TogglePrintButton(true);
            

        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            DataTable dt = Connection.GetDataTableFromDataGridView(dataGridView1);
            if (dt != null)
            {
                DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school");
                ds.Tables.Add();
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\AbsentReport.xsd");
                Report.Student.ReportDesign.rptStudentAbsent sa = new Report.Student.ReportDesign.rptStudentAbsent();
                sa.SetDataSource(ds);
                ShowAllReports s1 = new ShowAllReports();
                s1.crystalReportViewer1.ReportSource = sa;
                s1.Show();
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DateTime dt,dtt;
            dtt=dt = DateTime.Now;
            if (cmbType.SelectedItem.ToString().Equals("Daily"))
            {
                GetAttendanceDetails(dt,dtt);
            }
            else if (cmbType.SelectedItem.ToString().Equals("Weekly"))
            {
                dtt = dtt.AddDays(7);
                GetAttendanceDetails(dt,dtt);
            }
            else if (cmbType.SelectedItem.ToString().Equals("Monthly"))
            {
                dtt = dtt.AddMonths(1);
                GetAttendanceDetails(dt,dtt);
            }
            else if (cmbType.SelectedItem.ToString().Equals("Yearly"))
            {
                dtt = dtt.AddYears(1);
                GetAttendanceDetails(dt, dtt);
            }
        }

       
        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
    }
}
