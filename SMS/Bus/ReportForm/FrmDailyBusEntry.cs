using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS.Bus.ReportForm
{
    public partial class FrmDailyBusEntry :UserControlBase
    {
        public FrmDailyBusEntry()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Connection.GetDataSet("SELECT ROW_NUMBER() OVER (ORDER BY tbl_BusDetails.BusNo) AS Serial,tbl_BusDetails.BusNo, tbl_DailyBusEntry.DriverName, tbl_DailyBusEntry.ConductorName, convert(nvarchar(20), tbl_DailyBusEntry.CurrentDate,103) as CurrentDate, tbl_DailyBusEntry.TeacherName,tbl_DailyBusEntry.RootName FROM tbl_BusDetails INNER JOIN tbl_DailyBusEntry ON tbl_BusDetails.BusNo = tbl_DailyBusEntry.BusNo where tbl_BusDetails.BusNo = '" + cmbBusNo.Text + "'  SELECT   schoolname, schooladdress, affiliate_by, logoimage FROM   tbl_school");
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\DailyBusInfo.xsd");
            Bus.ReportDesign.rptDailyBusEntryInfo r = new Bus.ReportDesign.rptDailyBusEntryInfo();
            r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            r.SetDataSource(ds);
            ShowAllReports f = new ShowAllReports();
            f.Text = "Daily Bus Entry Report";
            f.crystalReportViewer1.ReportSource = r;
            f.Show();
        }

        private void FrmDailyBusEntry_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                 ds = Connection.GetDataSet("select busno from tbl_BusDetails");
                cmbBusNo.DataSource = ds.Tables[0];
                cmbBusNo.DisplayMember = "BusNo";
            }
            catch { }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Connection.GetDataSet("SELECT ROW_NUMBER() OVER (ORDER BY tbl_BusDetails.BusNo) AS Serial,tbl_BusDetails.BusNo, tbl_DailyBusEntry.DriverName, tbl_DailyBusEntry.ConductorName, convert(nvarchar(20), tbl_DailyBusEntry.CurrentDate,103) as CurrentDate, tbl_DailyBusEntry.TeacherName,tbl_DailyBusEntry.RootName FROM tbl_BusDetails INNER JOIN tbl_DailyBusEntry ON tbl_BusDetails.BusNo = tbl_DailyBusEntry.BusNo order by  tbl_DailyBusEntry.BusNo   SELECT   schoolname, schooladdress, affiliate_by, logoimage FROM   tbl_school");
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\DailyBusInfo.xsd");
            Bus.ReportDesign.rptDailyBusEntryInfoAll r = new Bus.ReportDesign.rptDailyBusEntryInfoAll();
            r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            r.SetDataSource(ds);
            ShowAllReports f = new ShowAllReports();
            f.Text = "Bus Detail Report";
            f.crystalReportViewer1.ReportSource = r;
            f.Show();
        }

        private void FrmDailyBusEntry_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
