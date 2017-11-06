using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS.Hostal.ReportForm
{
    public partial class FrmStudentFee :UserControlBase
    {
        public FrmStudentFee()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }

        private void tbnlblPerticularStudentFeeReport_Click(object sender, EventArgs e)
        {
            if (txtScholarNo.Text.Trim() == string.Empty)
            { MessageBox.Show("Field Required"); }
            else
            {
                string mysql = "select studentno from tbl_student where scholarno='" + txtScholarNo.Text + "'";
                DataSet ds = new DataSet();
                ds.Clear();
                ds = Connection.GetDataSet(mysql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int studentno = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    DataSet ds1 = Connection.GetDataSet("select StudentNo from tbl_roomdet where studentno='" + studentno + "'");
                    if (ds1 != null && ds1.Tables.Count != 0 && ds1.Tables[0].Rows.Count != 0)
                    {
                        string mysql1 = "SELECT schoolname, schooladdress, affiliate_by, logoimage FROM tbl_school  SELECT  tbl_hostel.HostelName, tbl_hostelfee.roomno, tbl_hostelfee.bedno, tbl_hostelfee.studentname,  DateName( month , DateAdd( month , tbl_hostelfee.monthno , 0 ) - 1 ) as monthno, tbl_hostelfee.yearno, convert(nvarchar(10),tbl_hostelfee.feedate,103) as feedate, tbl_hostelfee.rechostelfee, tbl_hostelfee.recmessfee FROM tbl_hostelfee INNER JOIN  tbl_hostel ON tbl_hostelfee.hostelcode = tbl_hostel.Hostelcode WHERE  tbl_hostelfee.studentno ='" + studentno + "' ";
                        DataSet dss = new DataSet();
                        dss.Clear();
                        dss = Connection.GetDataSet(mysql1);
                        if (dss.Tables[1].Rows.Count > 0)
                        {
                            dss.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"\Barcodes\a\Hostelfee.xsd");
                            Hostal.ReportDesign.rptHostelFee r = new Hostal.ReportDesign.rptHostelFee();
                            r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                            r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                            r.SetDataSource(dss);
                            ShowAllReports f = new ShowAllReports();
                            f.Text = "Hostel Fee By Student";
                            f.crystalReportViewer1.ReportSource = r;
                            f.Show();
                        }
                        else
                        {
                            //--------
                            MessageBox.Show("Data not found.");
                        }
                    }
                    else { MessageBox.Show("Room Not Attoted To This Student"); }
                }
                else { MessageBox.Show("Scholar No. NOt Available"); }

            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FrmStudentFee_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
        
    }
}
