using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS.Library.ReportForm
{
    public partial class FrmBarcodeSticker : UserControl
    {
        public FrmBarcodeSticker()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet(" SELECT     tbl_booktitle.booktitle, tbl_booktitle.BarcodeImage, tbl_booktitle.BarcodeNo, tbl_school.schoolname, tbl_school.schooladdress, tbl_school.affiliate_by,                      tbl_school.logoimage  FROM         tbl_booktitle CROSS JOIN      tbl_school   ");

            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\PrinBookBarcode.xsd");
            Library.ReportDesign.printcard fr = new Library.ReportDesign.printcard();
            fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            fr.SetDataSource(ds);
            ShowAllReports s = new ShowAllReports();
            s.crystalReportViewer1.ReportSource = fr;
            s.Show();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FrmBarcodeSticker_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet(" SELECT     tbl_booktitle.booktitle, tbl_booktitle.BarcodeImage, tbl_booktitle.BarcodeNo, tbl_school.schoolname, tbl_school.schooladdress, tbl_school.affiliate_by,                      tbl_school.logoimage  FROM         tbl_booktitle CROSS JOIN      tbl_school   ");
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void FrmBarcodeSticker_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
