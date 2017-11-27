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
    public partial class frmdailyfeereport :UserControlBase
    {
        school1 c = new school1();
        DataSet ds = new DataSet();
        static string tmps = string.Empty;

        public frmdailyfeereport(string S)
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
            Connection.SetUserControlTheme(this);
            tmps = S;

            //  DesignForm.fromDesign1(this);
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            ////this.Close();
        }

        private void dtpfeedate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnPrint .Focus();
        }
        public void FillGridForS()
        {
            try
            {
                ds = Connection.GetDataSet("SELECT distinct tbl_session.sessionname, tbl_sankay.sankayname, tbl_classmaster.classname, tbl_section.sectionname, tbl_student.scholarno, tbl_student.name,  " +
                     " tbl_student.dob, tbl_student.P_address, tbl_student.father, tbl_student.mother, tbl_student.m_tongue, tbl_student.casttype, tbl_student.phone, tbl_student.SubCast, tbl_student.Religion " +
                     " , tbl_FeeMaster.rcptno,convert(varchar,tbl_FeeMaster.rcptdate,103) rcptdate, tbl_FeeMaster.rcvdamt, tbl_FeeMaster.totalpaidfee, tbl_FeeMaster.dueamount, tbl_FeeMaster.latefee, tbl_FeeMaster.totfeeamt, tbl_FeeMaster.monthname " +
                     " , tbl_FeeMaster.consession FROM tbl_student INNER JOIN tbl_FeeMaster ON tbl_student.studentno = tbl_FeeMaster.studentno INNER JOIN tbl_classmaster INNER JOIN tbl_classstudent ON " +
                     " tbl_classmaster.classcode = tbl_classstudent.classno ON tbl_FeeMaster.studentno = tbl_classstudent.studentno INNER JOIN tbl_session ON tbl_FeeMaster.sessioncode = tbl_session.sessioncode AND  " +
                     " tbl_classstudent.sessioncode = tbl_session.sessioncode INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN  " +
                     " tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode  Where  tbl_FeeMaster.rcptdate='" + dtpfeedate.Value.Date.ToString("MM/dd/yyyy") + "' Order by  tbl_FeeMaster.rcptno ;" +
                     "  SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
        public void FillGridForH()
        {
            try
            {
                ds = Connection.GetDataSet("SELECT distinct tbl_session.sessionname, tbl_sankay.sankayname, tbl_classmaster.classname, tbl_section.sectionname, tbl_student.scholarno, tbl_student.name,   tbl_student.dob, tbl_student.P_address, tbl_student.father, tbl_student.mother, tbl_student.m_tongue, tbl_student.casttype, tbl_student.phone, tbl_student.SubCast, tbl_student.Religion  , tfr.RecId as rcptno,convert(varchar,tfr.date,103) rcptdate, dbo.GetRecAmount(tfr.RecId,tbl_classstudent.sessioncode,tbl_student.studentno) as rcvdamt, ((dbo.GetRecAmount(tfr.RecId,tbl_classstudent.sessioncode,tbl_student.studentno)+tfr.latefee)-tfr.consession) as totalpaidfee, tfr.dueamount, tfr.latefee,  ((dbo.GetRecAmount(tfr.RecId,tbl_classstudent.sessioncode,tbl_student.studentno)+tfr.latefee)-tfr.consession) as totfeeamt,DateName( month , DateAdd( month , DATEPART(mm,tfr.date) , -1 ) ) as monthname  , tfr.consession FROM tbl_student INNER JOIN Tbl_Received tfr ON tbl_student.studentno = tfr.studentno  INNER JOIN tbl_classmaster INNER JOIN tbl_classstudent ON  tbl_classmaster.classcode = tbl_classstudent.classno ON tfr.studentno = tbl_classstudent.studentno INNER JOIN tbl_session ON tfr.sessioncode = tbl_session.sessioncode AND   tbl_classstudent.sessioncode = tbl_session.sessioncode INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN   tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode Where  tfr.date='" + dtpfeedate.Value.Date.ToString("MM/dd/yyyy") + "' Order by   tfr.RecId ;" +
                     "  SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
        public void GetFeeDetailsS()
        {
            try
            {
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\DailyFeeRcpt.xsd");
                rptDailyFeeReport fr = new rptDailyFeeReport();
                fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                fr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = fr;
                s.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }
        public void GetFeeDetailsH()
        {
            try
            {
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\DailyFeeRcpt.xsd");
                rptDailyFeeReport fr = new rptDailyFeeReport();
                fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                fr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = fr;
                s.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            if (tmps.Equals("S"))
            {
                GetFeeDetailsS();
            }
            else
            {
                GetFeeDetailsH();
            }
        }

        private void dtpfeedate_Validated(object sender, EventArgs e)
        {
            if (tmps.Equals("S"))
            {
                FillGridForS();
            }
            else
            {
                FillGridForH();
            }
        }

        private void frmdailyfeereport_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
