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
    public partial class FrmHostalVaccent :UserControlBase
    {
        public FrmHostalVaccent()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }

        private void btnVacatRoom_Click(object sender, EventArgs e)
        {
            DataSet dss = Connection.GetDataSet("select hostelcode from tbl_hostel where hostelname='" + cmbHostelName.Text + "'");
            int hostelcode = Convert.ToInt32(dss.Tables[0].Rows[0][0]);
            string mysql = "SELECT schoolname, schooladdress, affiliate_by, logoimage FROM tbl_school  SELECT  tbl_hostel.HostelName,convert(nvarchar(10),tbl_roomdet.allotmentdate,103) as  allotmentdate, tbl_roomdet.studentname, tbl_roomdet.bedno, tbl_roomdet.roomno FROM tbl_roomdet INNER JOIN tbl_hostel ON tbl_roomdet.hostelcode = tbl_hostel.Hostelcode WHERE tbl_roomdet.studentname IS NULL AND tbl_roomdet.hostelcode='" + hostelcode + "'";
            DataSet ds = new DataSet();
            ds.Clear();
            ds = Connection.GetDataSet(mysql);
            if (ds.Tables[1].Rows.Count > 0)
            {
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"\Barcodes\a\hostelVaccent.xsd");
                Hostal.ReportDesign.rptHostelVacat rh = new Hostal.ReportDesign.rptHostelVacat();
                rh.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                rh.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                rh.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.Text = "Room Vacated Report";
                s.crystalReportViewer1.ReportSource = rh;
                s.Show();
            }
            else
            {
                //===
                MessageBox.Show("Data not found.");
            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FrmHostalVaccent_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("select hostelname from tbl_hostel");
            cmbHostelName.DataSource = ds.Tables[0];
            cmbHostelName.DisplayMember = "hostelname";      
        }

        private void FrmHostalVaccent_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
