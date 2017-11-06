using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

namespace SMS
{
    public partial class frmduplicatefeereceipt :UserControlBase
    {
        school1 c = new school1();
        static string tmps = string.Empty;
        public frmduplicatefeereceipt( string S)
        {
            InitializeComponent(); 
            Connection.SetUserControlTheme(this);
            tmps = S;
        }
        Bitmap memoryImage;

        public void GetDuplicateFessHP()
        {
            DataSet ds = Connection.GetDataSet("GetRecPrint " + school.CurrentSessionCode + "," + txtfeeno.Text.Trim());
            try
            {
                bool b = Convert.ToBoolean(Connection.GetExecuteScalar("Select DualSlipType From tbl_FeeHeads"));
                if (b)
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptFeeReceiptNew.xsd");
                    rptFeeSlipNew cr = new rptFeeSlipNew();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    //cr.SetParameterValue("Title", "FEE RECEIPT");
                    s.Show();

                }
                else
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptFeeReceiptSingleNew.xsd");
                    rptFeeSlipSingleNew cr = new rptFeeSlipSingleNew();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    //cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    // System.Drawing.Printing.PaperSize pr = new System.Drawing.Printing.PaperSize("Atul", 4, 6);
                    Size sz = new Size(4, 6);
                    s.crystalReportViewer1.ReportSource = cr;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelopePersonal;
                    s.Show();
                }
            }
            catch { }
        }
        public void GetDuplicateFessH()
        {
            
            try
            {
                if (!string.IsNullOrEmpty(txtfeeno.Text))
                {
                    DataSet ds = Connection.GetDataSet("GetRecPrint " + school.CurrentSessionCode + "," + txtfeeno.Text.Trim());
                    if (ds.Tables[0].Rows.Count > 0)
                    {

                        lblstudentno.Text = Convert.ToString(Convert.ToInt16(ds.Tables[0].Rows[0]["studentno"]));
                        lblschloarno.Text = Convert.ToString(ds.Tables[0].Rows[0]["scholarno"]);
                        lblfeemonth.Text = Convert.ToDateTime(ds.Tables[2].Rows[0]["rdate"]).ToString("MMMM");
                        lblclass.Text = Convert.ToString(ds.Tables[0].Rows[0]["Class"]);
                        lblname.Text = Convert.ToString(ds.Tables[0].Rows[0]["name"]);
                        lblsession.Text = Convert.ToString(ds.Tables[0].Rows[0]["sessionname"]);

                    }
                    else
                    {
                        MessageBox.Show("No Record Available About Fee Receipt No. \"" + txtfeeno.Text + "\"", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtfeeno.SelectAll();
                        txtfeeno.Focus();
                    }
                }
            }
            catch { }
        }

        public void GetDuplicateFessSP()
        {
            DataSet ds = Connection.GetDataSet("SELECT tbl_student.studentno, tbl_student.scholarno, tbl_student.name, tbl_student.dob, tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class " +
               " , tbl_session.sessionname, tbl_tehsil.tehsil, tbl_district.district, tbl_district.statename, tbl_student.P_address, tbl_student.C_address, tbl_student.father,tbl_student.mother " +
               " , tbl_student.casttype, tbl_student.bloodgroup, tbl_student.marr_status AS gender, tbl_student.phone, (CASE WHEN tbl_student.busfacility = 1 THEN tbl_StopDetails.StopName ELSE ISNULL(tbl_student.P_address,tbl_tehsil.tehsil) END) AS StopName " +
               " , tbl_StopDetails.StopFee, tbl_feemaster.rcptno " +
               " , tbl_feemaster.rcptdate, tbl_feemaster.rcvdamt, tbl_feemaster.totalpaidfee, tbl_feemaster.dueamount, tbl_feemaster.latefee, tbl_feemaster.totfeeamt, tbl_feemaster.monthname " +
               " , tbl_feemaster.consession FROM tbl_section INNER JOIN tbl_session INNER JOIN tbl_feemaster ON tbl_session.sessioncode = tbl_feemaster.sessioncode INNER JOIN tbl_student ON  " +
               "   tbl_feemaster.studentno = tbl_student.studentno INNER JOIN tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno AND tbl_session.sessioncode = tbl_classstudent.sessioncode  " +
               "   INNER JOIN tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode ON tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode " +
               "   INNER JOIN tbl_district ON tbl_student.distcode = tbl_district.distcode INNER JOIN tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode AND tbl_district.distcode = tbl_tehsil.distcode LEFT OUTER JOIN  " +
               "   tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo WHERE (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') AND (tbl_feemaster.rcptno = '" + txtfeeno.Text.Trim() + "'); " +
               "   SELECT schoolname, schooladdress, affiliate_by, logoimage, schoolcity, schoolphone, principal, registrationno FROM tbl_school ");
            try
            {
                bool b = Convert.ToBoolean(Connection.GetExecuteScalar("Select DualSlipType From tbl_FeeHeads"));
                if (b)
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptFeeReceipt.xsd");
                    rptFeeSlip cr = new rptFeeSlip();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    cr.SetParameterValue("Title", "DUPLICATE FEE RECEIPT");
                    s.Show();

                }
                else
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptFeeReceiptSingle.xsd");
                    rptFeeSlipSingle cr = new rptFeeSlipSingle();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    //System.Drawing.Printing.PaperSize pr = new System.Drawing.Printing.PaperSize("Atul", 4, 5.5);
                    //Size sz = new Size(4, 6); 
                    s.crystalReportViewer1.ReportSource = cr;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelopePersonal;
                    s.Show();
                }
            }
            catch { }
        }
        public void GetDuplicateFessS()
        {
            try
            {
                if (!string.IsNullOrEmpty(txtfeeno.Text))
                {
                    SqlDataReader reader = Connection.GetDataReader("SELECT tbl_student.studentno, tbl_student.scholarno, tbl_student.name, tbl_student.dob, tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class " +
                " , tbl_session.sessionname, tbl_tehsil.tehsil, tbl_district.district, tbl_district.statename, tbl_student.P_address, tbl_student.C_address, tbl_student.father,tbl_student.mother " +
                " , tbl_student.casttype, tbl_student.bloodgroup, tbl_student.marr_status AS gender, tbl_student.phone, (CASE WHEN tbl_student.busfacility = 1 THEN tbl_StopDetails.StopName ELSE ISNULL(tbl_student.P_address,tbl_tehsil.tehsil) END) AS StopName " +
                " , tbl_StopDetails.StopFee, tbl_feemaster.rcptno " +
                " , tbl_feemaster.rcptdate, tbl_feemaster.rcvdamt, tbl_feemaster.totalpaidfee, tbl_feemaster.dueamount, tbl_feemaster.latefee, tbl_feemaster.totfeeamt, tbl_feemaster.monthname " +
                " , tbl_feemaster.consession FROM tbl_section INNER JOIN tbl_session INNER JOIN tbl_feemaster ON tbl_session.sessioncode = tbl_feemaster.sessioncode INNER JOIN tbl_student ON  " +
                "   tbl_feemaster.studentno = tbl_student.studentno INNER JOIN tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno AND tbl_session.sessioncode = tbl_classstudent.sessioncode  " +
                "   INNER JOIN tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode ON tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode " +
                "   INNER JOIN tbl_district ON tbl_student.distcode = tbl_district.distcode INNER JOIN tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode AND tbl_district.distcode = tbl_tehsil.distcode LEFT OUTER JOIN  " +
                "   tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo WHERE (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') AND (tbl_feemaster.rcptno = '" + txtfeeno.Text.Trim() + "');");

                    if (reader != null)
                    {
                        reader.Read();
                        lblstudentno.Text = Convert.ToString(Convert.ToInt16(reader["studentno"]));
                        lblschloarno.Text = Convert.ToString(reader["scholarno"]);
                        lblfeemonth.Text = Convert.ToString(reader["monthname"]);
                        lblclass.Text = Convert.ToString(reader["Class"]);
                        lblname.Text = Convert.ToString(reader["name"]);
                        lblsession.Text = Convert.ToString(reader["sessionname"]);
                        reader.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Record Available About Fee Receipt No. \"" + txtfeeno.Text + "\"", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtfeeno.SelectAll();
                        txtfeeno.Focus();
                    }
                }
            }
            catch
            {
            }
           
        }
        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(
                this.Location.X, this.Location.Y, 0, 0, s);
        }
        public override void btnprint_Click(object sender, EventArgs e)
        {
            if (tmps.Equals("S"))
                GetDuplicateFessSP();
            else
                GetDuplicateFessHP();
        }

        private void txtfeeno_Validated(object sender, EventArgs e)
        {
            if (tmps.Equals("S"))
                GetDuplicateFessS();
            else
                GetDuplicateFessH();
        }

        private void frmduplicatefeereceipt_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            txtfeeno.SelectAll();
            txtfeeno.Focus();
            c.GetMdiParent(this).TogglePrintButton(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////this.Close();
        }

        private void txtfeeno_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void frmduplicatefeereceipt_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

    }
}
