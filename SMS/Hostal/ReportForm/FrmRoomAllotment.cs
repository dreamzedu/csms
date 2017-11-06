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
    public partial class FrmRoomAllotment :UserControlBase
    {
        public FrmRoomAllotment()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }

        private void btnAllottRoom_Click(object sender, EventArgs e)
        {
            if (cmbHostelName.Text.Trim() == string.Empty)
            { MessageBox.Show("Please Select A Hostel"); }
            else
            {
                DataSet dss = Connection.GetDataSet("select hostelcode from tbl_hostel where hostelname='" + cmbHostelName.Text + "'  ");
                int hostelcode = Convert.ToInt32(dss.Tables[0].Rows[0][0]);
                string mysql = "SELECT     tbl_hostel.HostelName, tbl_school.schoolname, tbl_school.schooladdress, tbl_school.affiliate_by, tbl_school.logoimage FROM  tbl_hostel CROSS JOIN tbl_school WHERE tbl_hostel.Hostelcode = '" + hostelcode + "'  SELECT  convert(nvarchar(10),allotmentdate,103) as allotmentdate,studentname,bedno,roomno FROM tbl_roomdet where studentname IS NOT NULL AND hostelcode='" + hostelcode + "' ";
                DataSet ds = new DataSet();
                ds.Clear();
                ds = Connection.GetDataSet(mysql);
                if (ds.Tables[1].Rows.Count > 0)
                {
                    
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"\Barcodes\a\hostelallot.xsd");
                    Hostal.ReportDesign.rptHostelAllotPosition rh = new Hostal.ReportDesign.rptHostelAllotPosition();
                    rh.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    rh.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    rh.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    s.Text = "Room Alloted Report";
                    s.crystalReportViewer1.ReportSource = rh;
                    s.Show();
                }
                else
                {
                    //========
                    MessageBox.Show("Data not found.");
                }
            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FrmRoomAllotment_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("select hostelname from tbl_hostel ");
            cmbHostelName.DataSource = ds.Tables[0];
            cmbHostelName.DisplayMember = "hostelname";  
        }

        private void FrmRoomAllotment_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
