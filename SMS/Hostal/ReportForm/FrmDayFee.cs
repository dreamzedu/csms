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
    public partial class FrmDayFee :UserControlBase
    {
        public FrmDayFee()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }

        private void FrmDayFee_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("select hostelname from tbl_hostel");
            cmbHostelName.DataSource = ds.Tables[0];
            cmbHostelName.DisplayMember = "HostelName";
        }

        private void btnEveryDayFee_Click(object sender, EventArgs e)
        {
            if (cmbHostelName.Text.Trim() == string.Empty)
            { MessageBox.Show("Please Select A Hostel"); }
            else
            {
                DataSet dss = Connection.GetDataSet("select hostelcode from tbl_hostel where HostelName='" + cmbHostelName.Text + "'");
                DataSet ds = Connection.GetDataSet("SELECT     tbl_hostel.HostelName, tbl_school.schoolname, tbl_school.schooladdress, tbl_school.affiliate_by, tbl_school.logoimage FROM  tbl_hostel CROSS JOIN tbl_school WHERE tbl_hostel.Hostelcode = '" + dss.Tables[0].Rows[0][0]
                    + "'  SELECT tbl_hostel.HostelName, tbl_hostelfee.roomno, tbl_hostelfee.bedno, tbl_hostelfee.studentname,  DateName( month , DateAdd( month , tbl_hostelfee.monthno , 0 ) - 1 ) as monthno, tbl_hostelfee.yearno, convert(nvarchar(10),tbl_hostelfee.feedate,103) as feedate, tbl_hostelfee.rechostelfee, tbl_hostelfee.recmessfee FROM  tbl_hostelfee INNER JOIN tbl_hostel ON tbl_hostelfee.hostelcode = tbl_hostel.Hostelcode WHERE  tbl_hostelfee.feedate ='" + cmbDate.Value.Date + "'  and tbl_Hostelfee.hostelCode='" + dss.Tables[0].Rows[0][0] + "'");

                if (ds.Tables[1].Rows.Count > 0)
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"\Barcodes\a\DailyHostelfee.xsd");
                    Hostal.ReportDesign.rptDailyHostelFee r = new Hostal.ReportDesign.rptDailyHostelFee();
                    r.SetDataSource(ds);
                    ShowAllReports f = new ShowAllReports();
                    r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    f.Text = "Daily Hostel Fee Report";
                    f.crystalReportViewer1.ReportSource = r;
                    f.Show();
                }
                else
                {
                    //------------------
                    MessageBox.Show("Data not found.");
                }
            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FrmDayFee_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
