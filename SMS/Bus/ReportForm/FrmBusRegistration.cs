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
    public partial class FrmBusRegistration :UserControlBase
    {
        public FrmBusRegistration()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet(" SELECT   schoolname, schooladdress, affiliate_by, logoimage FROM   tbl_school   Select BusId,BusNo,RTONO,SeatsCapacity,BusMilej,ModelNo,ChechisNo,InitialReading,convert(nvarchar(20), PurchaseDate,103) as PurchaseDate,Company,convert(nvarchar(20), RegistrationIssueDate,103) as RegistrationIssueDate,convert(nvarchar(20), RegistrationExpiryDate,103) as RegistrationExpiryDate,Status from tbl_BusDetails  where BusNO='" + cmbBusNo.Text + "'    ");
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BusRegistrationInfo.xsd");
            Bus.ReportDesign.rptBusRegistrationInfo r = new Bus.ReportDesign.rptBusRegistrationInfo();
            r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            r.SetDataSource(ds);
            ShowAllReports f = new ShowAllReports();

            f.Text = "Bus Registration Information";
            f.crystalReportViewer1.ReportSource = r;
            f.Show();
        }

        private void FrmBusRegistration_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Connection.GetDataSet("select busno from tbl_BusDetails");
                cmbBusNo.DataSource = ds.Tables[0];
                cmbBusNo.DisplayMember = "BusNo";
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("SELECT   schoolname, schooladdress, affiliate_by, logoimage FROM   tbl_school  Select  BusId,BusNo,RTONO,SeatsCapacity,BusMilej,ModelNo,ChechisNo,InitialReading,convert(nvarchar(20), PurchaseDate,103) as PurchaseDate,Company,convert(nvarchar(20), RegistrationIssueDate,103) as RegistrationIssueDate,convert(nvarchar(20), RegistrationExpiryDate,103) as RegistrationExpiryDate,Status from tbl_BusDetails ");
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BusRegistrationInfo.xsd");
            Bus.ReportDesign.rptBusRegistrationInfo r = new Bus.ReportDesign.rptBusRegistrationInfo();
            r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            r.SetDataSource(ds);
            ShowAllReports f = new ShowAllReports();
            f.Text = "All Buses Registration Information";
            f.crystalReportViewer1.ReportSource = r;
            f.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();

        }

        private void cmbBusNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (Char)Keys.None;
        }

        private void FrmBusRegistration_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
