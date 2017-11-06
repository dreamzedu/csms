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
    public partial class FrmDieselConsumption :UserControlBase
    {
        public FrmDieselConsumption()
        {
            InitializeComponent();
        }

        private void FrmDieselConsumption_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("select busno from tbl_busDetails");
            cmbBusNo.DataSource = ds.Tables[0];
            cmbBusNo.DisplayMember = "busno";
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (cmbBusNo.Text == "")
            { MessageBox.Show("Please Select A Bus Must"); }
            else
            {
                DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, affiliate_by, logoimage  FROM  tbl_school  select ROW_NUMBER() OVER (ORDER BY BusEntry) AS Serial,BusEntry,BusNo,DieselAvailable,convert(nvarchar(20), PuredDate,103) as PuredDate,PuredDiesel,BusReading,DieselRate,Amount,CurrentDate,Status from tbl_dieselDetails where BusNo='" + cmbBusNo.Text + "' and PuredDate between '" + dtpStartDate.Value.Date + "' and '" + dtpLastDate.Value.Date + "'  select (max(busreading)-min(busreading)) from tbl_DieselDetails where BusNo='" + cmbBusNo.Text + "' and PuredDate between '" + dtpStartDate.Value.Date + "' and '" + dtpLastDate.Value.Date + "'");
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\DieselConsumption.xsd");
                Bus.ReportDesign.rptDieselReportOfBus r = new Bus.ReportDesign.rptDieselReportOfBus();
                r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;

                r.SetDataSource(ds);
                ShowAllReports f = new ShowAllReports();
                f.Text = "Diesel Report";
                f.crystalReportViewer1.ReportSource = r;
                f.Show();
            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, affiliate_by, logoimage  FROM  tbl_school  select  ROW_NUMBER() OVER (ORDER BY BusEntry) AS Serial,BusEntry,BusNo,DieselAvailable,convert(nvarchar(20), PuredDate,103) as PuredDate,PuredDiesel,BusReading,DieselRate,Amount,CurrentDate,Status from tbl_dieselDetails where PuredDate between '" + dtpStartDate.Value.Date + "' and '" + dtpLastDate.Value.Date + "'  select (max(busreading)-min(busreading)) from tbl_DieselDetails where PuredDate between '" + dtpStartDate.Value.Date + "' and '" + dtpLastDate.Value.Date + "'");
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\DieselConsumption.xsd");
            Bus.ReportDesign.rptDieselReportOfBus r = new Bus.ReportDesign.rptDieselReportOfBus();
            r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            r.SetDataSource(ds);
            ShowAllReports f = new ShowAllReports();
            f.Text = "Diesel Report Of All Buses";
            f.crystalReportViewer1.ReportSource = r;
            f.Show();
        }

        private void FrmDieselConsumption_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        
    }
}
