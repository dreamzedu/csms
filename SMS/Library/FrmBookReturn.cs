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
    public partial class FrmBookReturn : UserControl
    {
        public FrmBookReturn()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        int lateday;
        int count;
        decimal grossTotal;
        private void txtStudentBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentBarCode.Text.Length >= 9)
                {
                    string guest_code = (txtStudentBarCode.Text.Substring(0, 10));

                    DataSet ds = Connection.GetDataSet("SELECT     studentimage    FROM         tbl_student  WHERE     (barcode = '" + txtStudentBarCode.Text + "')  ");
                    byte[] reading = null;
                    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                    {
                        reading = null;
                    }
                    else
                    {
                        reading = (byte[])ds.Tables[0].Rows[0][0];
                        MemoryStream ms = new MemoryStream(reading);
                        member_pic.Image = Image.FromStream(ms);
                        Sound s = new Sound();
                    }
                  

                    DataSet ds23 = Connection.GetDataSet("Select scholarno ,name  from tbl_Student where barcode='" + guest_code + "' ");
                    DataRow dr = ds23.Tables[0].Rows[0];
                    txtEnrollNo.Text = dr[0].ToString();
                    txtStudentName.Text = dr[1].ToString();
                    DataSet ds89 = Connection.GetDataSet("SELECT distinct tbl_book.rackno AS [Rack No],tbl_book.bookname AS [Book Name], tbl_book.booksubname AS [Book Sub Name], tbl_book.author AS [Author Name]  FROM tbl_booktitle INNER JOIN   tbl_book  ON tbl_booktitle.bookno = tbl_book.bookno INNER JOIN  tbl_student INNER JOIN   tbl_Issuebook ON tbl_student.scholarno = tbl_Issuebook.scholarno ON tbl_booktitle.booktitle = tbl_Issuebook.booktitle  WHERE (tbl_student.barcode = '" + guest_code + "')  ");

                    GVSudentBookDeails.DataSource = ds89.Tables[0];
                    txtBookBarcodeNo.Focus();

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }

        private void txtBookBarcodeNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentBarCode.Text == "")
                {
                    MessageBox.Show("Null value not Allowed..");
                }
                else
                {
                    if (txtBookBarcodeNo.Text.Length >= 9)
                    {
                        string guest_code = (txtBookBarcodeNo.Text.Trim());
                        Sound s = new Sound();

                        DataSet ds = Connection.GetDataSet("SELECT  tbl_book.bookname,tbl_booktitle.booktitle FROM            tbl_book INNER JOIN   tbl_booktitle ON tbl_book.bookno = tbl_booktitle.bookno inner join tbl_booktransaction on tbl_booktransaction.booktitleno=tbl_booktitle.booktitle  WHERE        (tbl_booktitle.barcodeno = '" + guest_code + "') and tbl_booktransaction.status='NO' ");             // dataGridView1.DataSource = ds.Tables[0];
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];

                            // txtBBookNo.Text = dr[0].ToString();
                            txtBookName.Text = dr[0].ToString();
                            txtBookNo.Text = dr[1].ToString();

                            DataSet ds44 = Connection.GetDataSet("SELECT  distinct    issuedate   FROM         tbl_booktransaction   WHERE     (booktitleno = '" + txtBookNo.Text + "') AND (studentcode = '" + txtEnrollNo.Text + "')  ");
                            DateTime StDate = Convert.ToDateTime(ds44.Tables[0].Rows[0].ItemArray[0].ToString());
                            DateTime EndDate = DateTime.Now;
                            TimeSpan t = EndDate.Subtract(StDate);
                            int Day = t.Days;
                            txtday.Text = Day.ToString();
                            if (Day > 10)
                            {
                                lateday = Day - 10;
                                // txtBookBarcodeNo.Clear();
                                txtBookBarcodeNo.Focus();
                                int Amt = lateday * 5;
                                txtpayamount.Text = Amt.ToString();

                                MessageBox.Show("Your day is left please You Pay Fine");
                            }
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1.Rows[i].Cells[1].Value.ToString() == txtBookNo.Text)
                                {
                                    if (MessageBox.Show("This Entry Already Exists .. Do You Want To delete It", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                    {
                                        dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                                        count = dataGridView1.Rows.Count;
                                        txtBookBarcodeNo.Focus();
                                        txtBookBarcodeNo.Text = "";
                                        return;


                                    }
                                    else
                                    {



                                        txtBookBarcodeNo.Focus();
                                        txtBookBarcodeNo.Text = "";
                                        return;

                                    }
                                }
                                else
                                {
                                    txtBookBarcodeNo.Focus();
                                    txtBookBarcodeNo.Text = "";

                                }
                            }

                            txtBookBarcodeNo.Text = "";
                            if (dataGridView1.RowCount < 4)
                            {


                                dataGridView1.Rows.Add();
                                dataGridView1[0, count].Value = "Delete";
                                dataGridView1[1, count].Value = txtBookNo.Text;
                                dataGridView1[2, count].Value = txtBookName.Text;
                                dataGridView1[3, count].Value = DateTime.Now.ToShortDateString();
                                dataGridView1[4, count].Value = txtEnrollNo.Text;
                                dataGridView1[5, count].Value = txtStudentName.Text;
                                dataGridView1[6, count].Value = txtday.Text;
                                dataGridView1[7, count].Value = txtpayamount.Text;
                                grossTotal += Convert.ToDecimal(dataGridView1.Rows[count].Cells[7].Value);
                                count++;
                                txtpaidamount.Text = grossTotal.ToString();
                                txtBookNo.Text = "";
                                txtBookName.Text = "";
                                txtBookBarcodeNo.Text = "";
                                txtBookBarcodeNo.Focus();


                            }
                            else
                            {

                                txtRemark.Focus();
                                txtBookBarcodeNo.Enabled = false;
                                txtBookBarcodeNo.ReadOnly = true;
                            }

                        }
                        else
                        {
                            MessageBox.Show("This book is not available.");
                        }
                        txtBookBarcodeNo.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
                MessageBox.Show("PLease check properly.. ");
                txtBookBarcodeNo.Text = "";
                txtBookBarcodeNo.Focus();
                //Logger.LogError(ex); MessageBox.Show(ex.Message);
                //txtBookBarcodeNo .Text = "Your Book Issued Limit is Over";
                //txtBookBarcodeNo.Enabled = false;
                //txtBookBarcodeNo.ReadOnly = true;
            }
        }

        private void FrmBookReturn_Load(object sender, EventArgs e)
        {
            txtStudentBarCode.Focus();
            txtpayamount.Text = "0";
            txtpaidamount.Text = "0";
        }

        
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count != 0)
                {

                    if (MessageBox.Show("Are you Sure to save these Records", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (txtRemark.Text == "")
                        {
                            MessageBox.Show("Remark value not null allowed..");

                        }
                        else
                        {


                            for (int k = 0; k < dataGridView1.Rows.Count; k++)
                            {
                                string Date = DateTime.Now.ToShortDateString();
                                Connection.AllPerform("Update tbl_booktitle Set Status='Yes' where booktitle ='" + dataGridView1.Rows[k].Cells[1].Value.ToString() + "' ");
                                Connection.AllPerform("Update tbl_booktransaction Set Status='Yes', receiptdate='" + DateTime.Now.ToShortDateString() + "' ,rcvdremark='" + txtRemark.Text + "' ,lateday ='" + dataGridView1.Rows[k].Cells[6].Value.ToString() + "',Amount ='" + textBox1.Text + "' where booktitleno='" + dataGridView1.Rows[k].Cells[1].Value.ToString() + "' ");
                                Connection.AllPerform("delete from tbl_Issuebook where scholarno ='" + txtEnrollNo.Text + "' and booktitle ='" + dataGridView1.Rows[k].Cells[1].Value.ToString() + "' ");


                            }
                            GVSudentBookDeails.DataSource = null;
                            txtEnrollNo.Enabled = false;
                            txtStudentName.Enabled = false;
                            txtBookBarcodeNo.Enabled = false;
                            txtBookName.Enabled = false;
                            dataGridView1.DataSource = null;
                            txtRemark.Text = "";
                            txtBookNo.Enabled = false;
                            MessageBox.Show("Book Return Successfully");
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

                Logger.LogError(ex); MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FrmBookReturn_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        
    }
}
