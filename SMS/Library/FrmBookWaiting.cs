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
    public partial class FrmBookWaiting : UserControl
    {
        public FrmBookWaiting()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        school c = new school();
        private void FrmBookWaiting_Load(object sender, EventArgs e)
        {
            try
            {
                c.getconnstr();
                c.FillcomboBox("select * from tbl_Book order by bookName", "bookName", "bookno", ref cmbBookName);
                //Connection.FillComboBox(cmbBookName, "Select Distinct bookno,bookName from tbl_Book ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void txtStudentBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentBarCode.Text.Length > 5)
                {
                    string guest_code = (txtStudentBarCode.Text.Trim());
                    Sound s = new Sound();
                    DataSet ds = Connection.GetDataSet("Select scholarno ,name as StudentName from tbl_student where Barcode='" + guest_code + "' ");
                    DataRow dr = ds.Tables[0].Rows[0];
                    txtEnrollNo.Text = dr[0].ToString();
                    txtStudntName.Text = dr[1].ToString();

                    Connection.AllPerform("insert into tbl_BookWaiting(bookno,wstdno,wdate) values('" + txtBookNo.Text + "','" + txtEnrollNo.Text + "','" + DateTime.Now.ToShortDateString() + "')");

                    DataSet ds1 = Connection.GetDataSet("Select * from tbl_BookWaiting where bookno='" + txtBookNo.Text + "' order by wdate");
                    dataGridView1.DataSource = ds1.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbBookName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Connection.GetDataSet("SELECT        tbl_booktitle.booktitle FROM            tbl_book INNER JOIN                          tbl_booktitle ON tbl_book.bookno = tbl_booktitle.bookno where tbl_book.bookno='" + cmbBookName.SelectedValue.ToString() + "'");
                txtBookNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                DataSet ds1 = Connection.GetDataSet("Select * from tbl_BookWaiting where bookno='" + txtBookNo.Text + "' order by Wdate");
                dataGridView1.DataSource = ds1.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtEnrollNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Connection.GetDataSet("Select scholarno ,name  from tbl_Student where scholarno='" + txtEnrollNo.Text + "' ");
                DataRow dr = ds.Tables[0].Rows[0];
                txtEnrollNo.Text = dr[0].ToString();
                txtStudntName.Text = dr[1].ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Connection.GetDataSet("Select Count(*) from tbl_bookwaiting where bookno='" + txtBookNo.Text + "' ");
                int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                if (i >5)
                {
                    MessageBox.Show("Waiting List Is Full");
                }
                else
                {
                    
                    Connection.AllPerform("delete tbl_bookwaiting  where bookno='" + txtBookNo.Text + "'");
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        int ti = 0;
                        ti = Convert.ToInt16(r.Index) + 1;
                        Connection.AllPerform("Insert into tbl_bookwaiting values('" + r.Cells["bookno"].Value + "','" + r.Cells["wstdno"].Value + "','" + DateTime.Now.ToShortDateString() + "','" + ti + "')");
                    }
                    
                    MessageBox.Show("Record Insert");
                    DataSet ds1 = Connection.GetDataSet("Select * from tbl_BookWaiting where bookno='" + txtBookNo.Text + "' order by Wdate");
                    dataGridView1.DataSource = ds1.Tables[0];
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void cmbBookName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Charcter value");
            }
        }

        private void txtBookNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only numeric value");
            }
        }

        private void FrmBookWaiting_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        
    }
}
