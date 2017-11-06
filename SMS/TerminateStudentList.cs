using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SMS
{
    public partial class TerminateStudentList :UserControlBase
    { 
        string str = "";
        DataSet ds = new DataSet();
        public TerminateStudentList()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        private void TerminateStudentList_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbSession, " select sessioncode,sessionname from tbl_session order by sessioncode ");
        }
 
        private void cmbSession_Leave(object sender, EventArgs e)
        {
            try
            {
                ds = Connection.GetDataSet(" SELECT  tbl_student.scholarno AS [Scholar No.], tbl_student.name AS Name, tbl_student.father AS [Fathers Name] "+
                  " , CONVERT(varchar, tbl_student.dob, 106) AS [Birth Date], tbl_classmaster.classname + ' - ' + tbl_section.sectionname AS Class "+
                  " , tbl_sankay.sankayname AS Stream,tbl_session.sessionname AS Session FROM tbl_session INNER JOIN tbl_classstudent ON  "+
                  "   tbl_session.sessioncode = tbl_classstudent.sessioncode INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN "+
                  "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode "+
                  "   INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode WHERE (tbl_classstudent.stdtype='Terminate Student'  or tbl_classstudent.stdtype='Ex-Student') " +
                  "   AND (tbl_session.sessioncode = '" + cmbSession .SelectedValue + "') ORDER BY tbl_classmaster.classcode, tbl_student.name ; "+
                  "   SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school ");
                  dataGridView1.DataSource = ds.Tables[0];
            }
            catch 
            { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            try
            { 
                if (dataGridView1 .RowCount >0)
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\TerminateStudentList.xsd");
                    TerminateStudentReport fr = new TerminateStudentReport();
                    fr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = fr;
                    fr.SetParameterValue("ReportTitle", "Terminated Student Details");
                    s.Show();
                }
                else
                {
                    MessageBox.Show("Plese Select Session Name Properly..");
                }
            }
            catch  
            { }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        private void TerminateStudentList_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
