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
    public partial class FrmPayMonthlyHostalFee :UserControlBase
    {
        public FrmPayMonthlyHostalFee()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }

        private void btnDueFee_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Text.Trim() == string.Empty|| cmbHostelName.Text.Trim() == string.Empty)
            { MessageBox.Show("Please Select A Month"); }
            else
            {
                DataSet dss = Connection.GetDataSet("select Hostelcode from tbl_hostel where HostelName='" + cmbHostelName.Text + "'");
                int i = cmbMonth.SelectedIndex;
                i = i + 1;
                string mysql = "SELECT tbl_school.schoolname, tbl_school.schooladdress, tbl_school.affiliate_by, tbl_school.logoimage, tbl_hostel.HostelName FROM tbl_hostel CROSS JOIN tbl_school  where tbl_hostel.hostelcode='" + dss.Tables[0].Rows[0][0] + "'  select hostelcode,roomno,bedno,sessioncode,studentno,studentname,DateName( month , DateAdd( month , tbl_hostelfee.monthno , 0 ) - 1 ) as monthno,yearno,hostelfee,messfee,feedate,feeno,rechostelfee,recmessfee,messdays from tbl_hostelfee where monthno='" + i + "' and rechostelfee!='" + 0.00 + "' and recmessfee!='" + 0.00 + "'  and Hostelcode='" + dss.Tables[0].Rows[0][0] + "' ";
                DataSet ds = new DataSet();
                ds = Connection.GetDataSet(mysql);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"\Barcodes\a\HostelfeeMothwise.xsd");
                    Hostal.ReportDesign.rptMonthviseHostelFee r = new Hostal.ReportDesign.rptMonthviseHostelFee();
                    r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    r.SetDataSource(ds);
                    ShowAllReports f = new ShowAllReports();
                    f.Text = "Paid Hostel Fee By Month";
                    f.crystalReportViewer1.ReportSource = r;
                    f.Show();
                }
                else
                {
                    //====
                    MessageBox.Show("Data not found.");
                }
            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            //this.Close();

        }

        private void FrmPayMonthlyHostalFee_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("select HostelName from tbl_hostel");
            cmbHostelName.DataSource = ds.Tables[0];
            cmbHostelName.DisplayMember = "HostelName";
            cmbMonth.SelectedIndex = 0;
        }

        private void FrmPayMonthlyHostalFee_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
