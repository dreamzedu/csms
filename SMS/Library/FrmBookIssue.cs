using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SMS.Library
{
    public partial class FrmBookIssue : UserControl
    {
        public FrmBookIssue()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
       static int count = 0;
        private void FrmBookIssue_Load(object sender, EventArgs e)
        {
            txtStudEnrollNo.Focus();
            Connection.StudentBcode = "0";
            Connection.BookBcode = "0";
            count = 0;
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex == 0)
                {
                    if (MessageBox.Show("Are you Sure to delete these Records?", "School", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                        count = dataGridView1.Rows.Count;
                    }

                }
            }
            catch { }
        }

        public void GetStudentDetails()
        {
            if (Connection.StudentBcode == "0")
                return;
            try
            {

                if (txtEnrollNo.Text.Length >= 9)
                {
                    string guest_code = (txtEnrollNo.Text.Substring(0, 10));

                    DataSet ds = Connection.GetDataSet("SELECT     studentimage    FROM         tbl_student  WHERE     (barcode = '" + txtEnrollNo.Text + "')  ");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0][0].Equals(DBNull.Value))
                        {
                        }
                        else
                        {
                            byte[] reading = (byte[])ds.Tables[0].Rows[0][0];
                            MemoryStream ms = new MemoryStream(reading);
                            member_pic.Image = Image.FromStream(ms);
                        }
                    }
                    txtBookNo.Focus();
                    Sound s = new Sound();
                    DataSet ds23 = Connection.GetDataSet("Select scholarno ,name  from tbl_Student where barcode='" + guest_code + "' ");
                    DataRow dr = ds23.Tables[0].Rows[0];
                    txtStudEnrollNo.Text = dr[0].ToString();
                    TxtStuSchaler.Text = txtStudEnrollNo.Text;
                    txtStudentName.Text = dr[1].ToString();
                }

            }
            catch (Exception ex)
            {
            }
        }
        public void GetBookDetails()
        {
            if (Connection.BookBcode == "0")
                return;
            try
            {
                if (txtStudEnrollNo.Text == "")
                {
                    MessageBox.Show("Null value not Allowed..");
                }
                else
                {
                    if (txtBookNo.Text.Length > 9)
                    {

                        string guest_code = txtBookNo.Text.Trim();
                        TxtBno.Text = guest_code;
                        Sound s = new Sound();
                        DataSet ds = Connection.GetDataSet("SELECT  tbl_book.bookname,tbl_booktitle.*  FROM   tbl_book INNER JOIN  " +
                            "  tbl_booktitle ON tbl_book.bookno = tbl_booktitle.bookno   WHERE   (tbl_booktitle.barcodeno = '" + TxtBno.Text + "') ");
                        //dataGridView1.DataSource = ds;
                        DataRow dr = ds.Tables[0].Rows[0];
                        // txtBBookNo.Text = dr[0].ToString();
                        txtBookName.Text = dr[0].ToString();
                        txtBBookNo.Text = dr[1].ToString();
                        TxtBno.Text = dr[1].ToString();
                        if (dataGridView1.RowCount < 4)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int r = 0; r < ds.Tables[0].Rows.Count; r++)
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1[0, count].Value = "Delete";
                                    dataGridView1[1, count].Value = ds.Tables[0].Rows[r]["booktitle"].ToString();
                                    dataGridView1[2, count].Value = ds.Tables[0].Rows[r]["bookname"].ToString();
                                    dataGridView1[3, count].Value = DateTime.Now.ToShortDateString();
                                    dataGridView1[4, count].Value = txtStudEnrollNo.Text;
                                    dataGridView1[5, count].Value = txtStudentName.Text;
                                    dataGridView1[6, count].Value = ds.Tables[0].Rows[r]["bookno"].ToString();
                                    count++;
                                }
                                txtBookNo.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Your Book Issued Limit is Over.", "");
                            txtRemark.Focus();
                            txtBookNo.Text = "Your Book Issued Limit is Over";
                            txtBookNo.Enabled = false;
                            txtBookNo.ReadOnly = true;
                             
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtEnrollNo_TextChanged(object sender, EventArgs e)
        {
            //GetStudentDetails();
        }

        private void txtBookNo_TextChanged(object sender, EventArgs e)
        {
            //GetBookDetails();
        }

       

        private void txtBBookNo_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    TxtBno.Text = txtBBookNo.Text;
            //    Sound s = new Sound();
            //    DataSet ds = Connection.GetDataSet("SELECT        tbl_book.bookname,tbl_booktitle.BarcodeNo FROM            tbl_book INNER JOIN   tbl_booktitle ON tbl_book.bookno = tbl_booktitle.bookno  WHERE        (tbl_booktitle.booktitle = '" + TxtBno.Text + "') ");             // dataGridView1.DataSource = ds.Tables[0];
            //    DataRow dr = ds.Tables[0].Rows[0];
            //    // txtBBookNo.Text = dr[0].ToString();
            //    txtBookName.Text = dr[0].ToString();
            //    txtBookNo.Text = dr[1].ToString();
            //    txtRemark.Focus();


            //}
            //catch (Exception ex)
            //{

            //}
        }

       
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {

                    if (MessageBox.Show("Are you Sure to save these Records", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        DataSet ds2 = Connection.GetDataSet("Select Count(*) from tbl_IssueBook where scholarno ='" + txtStudEnrollNo.Text + "' ");
                        int i = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
                        if (i > 4)
                        {
                            MessageBox.Show("Your Book Issued Limit is Over");
                        }
                        else
                        {
                            for (int k = 0; k < dataGridView1.Rows.Count; k++)
                            {
                                string Date = DateTime.Now.ToShortDateString();
                                Connection.AllPerform("Insert Into tbl_IssueBook(scholarno,booktitle,date,bookno) values('" + txtStudEnrollNo.Text + "','" + dataGridView1.Rows[k].Cells[1].Value.ToString() + "','" + Date + "','" + dataGridView1.Rows[k].Cells[6].Value.ToString() + "')");
                                Connection.AllPerform("Insert Into tbl_booktransaction(booktitleno,studentcode,issuedate,issueremark,Status) values('" + dataGridView1.Rows[k].Cells[1].Value.ToString() + "','" + txtStudEnrollNo.Text + "','" + DateTime.Now.ToShortDateString() + "','" + txtRemark.Text + "','NO')");
                                Connection.AllPerform("Update  tbl_Booktitle Set Status='NO' where booktitle='" + dataGridView1.Rows[k].Cells[1].Value.ToString() + "'");
                            }

                            MessageBox.Show("Book Issued Successfully");
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Blank Record is not Saved \n Do you want to Continue", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dataGridView1.Rows.Clear();

                        txtBookNo.Focus();
                    }
                    else
                    {
                        //this.Close();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
       
        private void BtnGetSBarcode_Click(object sender, EventArgs e)
        {
            Library.FrmGetStudentBarcode gb = new FrmGetStudentBarcode();
            gb.ShowDialog();
            txtEnrollNo.Text = Connection.StudentBcode;
            txtBookNo.Text = Connection.BookBcode;
            //this is for new student
            dataGridView1.Rows.Clear();
            count = 0;
            //end
            GetStudentDetails();
            if (txtEnrollNo.Text.Trim() == string.Empty || txtEnrollNo.Text.Trim() == "0" || (txtEnrollNo.Text.Trim().Equals(DBNull.Value)))
            {
                //--
            }
            else
            {
                GetBookDetails();
            }
        }

        private void BtnGetBBarcode_Click(object sender, EventArgs e)
        {
            Library.FrmGetBookBarcode gb = new FrmGetBookBarcode();
            gb.ShowDialog();
            txtEnrollNo.Text = Connection.StudentBcode;
            txtBookNo.Text = Connection.BookBcode;
           
            GetStudentDetails();
            if (txtEnrollNo.Text.Trim() == string.Empty || txtEnrollNo.Text.Trim() == "0" || (txtEnrollNo.Text.Trim().Equals(DBNull.Value)))
            {
                //--
            }
            else
            {
                GetBookDetails();
            }
        }

        private void FrmBookIssue_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

       

       

        
        
    }
}

