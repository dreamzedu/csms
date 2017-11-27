using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Library
{
    public partial class FrmGetBookBarcode : Form
    {
        public FrmGetBookBarcode()
        {
            InitializeComponent();
        }
        school c = new school();
        string classname, studno, name;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                c.getconnstr();
                DataSet ds = Connection.GetDataSet("select tb.bookname as [Book Name],tb.booksubname as [Book Sub Name],tb.author as [Author],bt.booktitle as [Title],bt.prize as [Rs.],bt.BarcodeNo as [BarCode] from tbl_booktitle bt inner join tbl_book tb on bt.bookno=tb.bookno  where tb.bookname like '" + textBox1.Text + '%' + "' ");
                GVStudentDetails.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); throw ex;
            }
        }
        void chield()
        {
            foreach (Form chieldform in MdiChildren)
            {
                chieldform.Close();
            }
        }
        private void GVStudentDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Connection.BookBcode = GVStudentDetails.CurrentRow.Cells["BarCode"].Value.ToString();
                this.Close();
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Connection.BookBcode = "0";
            this.Close();
        }

        private void FrmGetBookBarcode_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
