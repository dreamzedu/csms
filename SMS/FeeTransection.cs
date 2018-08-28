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
    public partial class FeeTransection :UserControlBase
    {
        DataSet ds=new DataSet ();
        static string tmps = string.Empty;
        school1 c = new school1();

        public FeeTransection(string s)
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
            Connection.SetUserControlTheme(this);
            tmps = s;
            
            //    DesignForm.fromDesign1(this);
        }

        public void GetDetailsS()
        {
            ds = Connection.GetDataSet("SELECT tbl_student.scholarno AS 'Scholar No.', tbl_student.name AS Name, tbl_student.father AS 'Fathers Name' " +
                       " , tbl_student.mother AS 'Mothers Name', tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class, tbl_student.phone AS 'Mob. No.' " +
                       " , tbl_FeeMaster.rcptno AS 'Rcpt No.', CONVERT(varchar, tbl_FeeMaster.rcptdate, 103) AS 'Date', tbl_FeeMaster.latefee AS 'Late Fee' " +
                       " , tbl_FeeMaster.consession AS 'Con. Amt.', tbl_FeeMaster.totfeeamt AS 'Paid Fee', tbl_FeeMaster.dueamount AS 'Due Fee' FROM tbl_student  " +
                       " INNER JOIN tbl_FeeMaster ON tbl_student.studentno = tbl_FeeMaster.studentno INNER JOIN tbl_classmaster INNER JOIN tbl_classstudent ON  " +
                       " tbl_classmaster.classcode = tbl_classstudent.classno ON tbl_FeeMaster.studentno = tbl_classstudent.studentno INNER JOIN tbl_session ON  " +
                       " tbl_FeeMaster.sessioncode = tbl_session.sessioncode AND tbl_classstudent.sessioncode = tbl_session.sessioncode INNER JOIN tbl_section ON " +
                       " tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode  " +
                       " WHERE     (tbl_FeeMaster.rcptdate BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "') Order By tbl_FeeMaster.rcptno; " +
                       " SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage, " +
                       " '" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "' as StartDate,'" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") +
                       " ' as EndDate From   tbl_school");
            dataGridView1.DataSource = ds.Tables[0];  
        }
        public void GetDetailsH()
        {
            ds = Connection.GetDataSet("SELECT tbl_student.scholarno AS 'Scholar No.', tbl_student.name AS Name, tbl_student.father AS 'Fathers Name'  , tbl_student.mother AS 'Mothers Name', tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class, tbl_student.phone AS 'Mob. No.'  ,  tfr.RecId  AS 'Rcpt No.', CONVERT(varchar, tfr.date, 103) AS 'Date', tfr.latefee AS 'Late Fee'  , tfr.consession AS 'Con. Amt.', ((dbo.GetRecAmount(tfr.RecId,tbl_classstudent.sessioncode,tbl_student.studentno)+tfr.latefee)-tfr.consession) AS 'Paid Fee', tfr.dueamount AS 'Due Fee' FROM tbl_student   INNER JOIN Tbl_Received tfr ON tbl_student.studentno = tfr.studentno  INNER JOIN tbl_classmaster INNER JOIN tbl_classstudent ON   tbl_classmaster.classcode = tbl_classstudent.classno ON tfr.studentno = tbl_classstudent.studentno INNER JOIN tbl_session ON   tfr.sessioncode = tbl_session.sessioncode AND tbl_classstudent.sessioncode = tbl_session.sessioncode INNER JOIN tbl_section ON  tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode WHERE     (tfr.date BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value.Date + "') Order By tfr.RecId; " +
                       " SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage, " +
                       " '" + dateTimePicker1.Value.Date.ToString("dd-MMM-yyyy") + "' as StartDate,'" + dateTimePicker2.Value.Date.ToString("dd-MMM-yyyy") +
                       " ' as EndDate From   tbl_school");
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (tmps.Equals("S"))
                GetDetailsS();
            else
                GetDetailsH();
           
        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            ////this.Close();
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\AllFeeTransaction.xsd");
                rptAllTransactionReport fr = new rptAllTransactionReport();
                fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                fr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = fr;
                s.Show();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        private void FeeTransection_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void FeeTransection_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).TogglePrintButton(true);
        }
         
    }
}
