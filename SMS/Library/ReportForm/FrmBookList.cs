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
    public partial class FrmBookList : UserControl
    {
        public FrmBookList()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        DataSet ds = new DataSet();
        

       

        private void FrmBookList_Load(object sender, EventArgs e)
        {
            ds.Clear();
            ds = Connection.GetDataSet("SELECT        tbl_book.bookname, tbl_booktitle.booktitle as AccessionNo, tbl_book.author, tbl_booktitle.edition, tbl_booktitle.publicationyr, tbl_booktitle.prize, tbl_booktitle.granttype  FROM            tbl_book INNER JOIN                          tbl_booktitle ON tbl_book.bookno = tbl_booktitle.bookno  select *from tbl_school");
            dataGridView1.DataSource = ds.Tables[0];
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BookReports.xml");
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            SMS.Library.ReportDesign.BookDetail cr = new SMS.Library.ReportDesign.BookDetail();
            cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            cr.SetDataSource(ds);
            ShowAllReports s = new ShowAllReports();
            s.crystalReportViewer1.ReportSource = cr;
            s.Show(); 
        }

        private void FrmBookList_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
