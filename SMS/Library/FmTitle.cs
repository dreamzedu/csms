using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace SMS.Library
{
    public partial class FmTitle : UserControl
    {
        public FmTitle()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        school c = new school();
        bool add_edit;
        static string txtbarnum = string.Empty;
        private void FmTitle_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            c.FillcomboBox("select * from tbl_book", "bookname", "bookno", ref  valcmbbook);
        }

        private void BtnShowBook_Click(object sender, EventArgs e)
        {
            dtgbook.Rows.Clear();
            c.returnconn(c.myconn);
            string mysql = "";
            mysql = "select * from tbl_booktitle where bookno='" + valcmbbook.SelectedValue + "'";
            SqlCommand com;
            com = new SqlCommand(mysql, c.myconn);
            SqlDataReader reader;
            reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                int i = 0;

                while (reader.Read())
                {
                    dtgbook.Rows.Add();
                    dtgbook.Rows[i].Cells[0].Value = reader["bookno"];
                    dtgbook.Rows[i].Cells[1].Value = reader["booktitle"];
                    dtgbook.Rows[i].Cells[2].Value = reader["prize"];
                    dtgbook.Rows[i].Cells[3].Value = reader["granttype"];
                    dtgbook.Rows[i].Cells[4].Value = reader["edition"];
                    dtgbook.Rows[i].Cells[5].Value = reader["noofpages"];
                    dtgbook.Rows[i].Cells[6].Value = reader["publicationyr"];
                    i++;
                }
                reader.Close();
                dtgbook.AllowUserToAddRows = false;
            }
        }

        

        private void dtgbook_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                try
                {
                    if (dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                    {
                        goto mline;
                    }
                    c.returnconn(c.myconn);
                    string mysql = "select * from tbl_booktitle where booktitle=" + dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    SqlCommand com = new SqlCommand(mysql, c.myconn);
                    SqlDataReader reader = com.ExecuteReader();
                    int book1 = 0;
                    int book2 = 0;

                    if (reader.HasRows)
                    {
                        reader.Read();
                        book1 = Convert.ToInt16(reader["bookno"]);
                        book2 = Convert.ToInt16(dtgbook.Rows[e.RowIndex].Cells[0].Value);
                        if (book1 == book2)
                        {
                            int i = 0;
                            bool foundinsamerow = false;
                            do
                            {
                                if (dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                                {
                                }
                                else
                                {
                                    book1 = Convert.ToInt16(dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                                    book2 = Convert.ToInt16(dtgbook.Rows[i].Cells[1].Value);
                                    if (book1 == book2) // !! (e.RowIndex == i)
                                    {
                                        if (e.RowIndex == i)
                                        {
                                            foundinsamerow = true;
                                        }
                                        else
                                        {
                                            foundinsamerow = false;
                                            //MessageBox.Show("Book Title  Already Exists for other Book..", "KGRI");
                                            //dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                                        }
                                    }
                                    else
                                    {
                                        // MessageBox.Show("Book Title  Already Exists for other Book..", "KGRI");
                                        // dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                                    }
                                }
                                i++;
                            }
                            while (i <= dtgbook.Rows.Count - 1);
                            if (foundinsamerow == false)
                            {
                                MessageBox.Show("Book Title  Already Exists for other Book..", "School");
                                dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";

                            }

                        }
                        else
                        {
                            MessageBox.Show("Book Title  Already Exists for other Book..", "School");
                            dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        }

                    }
                    else
                    {
                        int i = 0;
                        bool foundinotherrow = false;
                        book1 = Convert.ToInt16(dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        do
                        {
                            book2 = Convert.ToInt16(dtgbook.Rows[i].Cells[1].Value);
                            if (book1 == book2) // !! (e.RowIndex == i)
                            {
                                if (e.RowIndex == i)
                                {
                                    foundinotherrow = false;
                                }
                                else
                                {
                                    foundinotherrow = true;
                                }
                            }
                            else
                            {

                            }
                            i++;
                        }
                        while (i <= dtgbook.Rows.Count - 1);
                        if (book1 == book2 && foundinotherrow == true)
                        {
                            MessageBox.Show("Book Title  Already Exists for other Book..", "School");
                            dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        }
                    }
                mline:
                    Console.Write("");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dtgbook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F3")
            {
                dtgbook.Rows.Add();
                dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[0].Value = valcmbbook.SelectedValue;
            }
        }

   

        private void dtgbook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgbook.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    c.returnconn(c.myconn);
                    string mysql = "";
                    mysql = "select a.*,b.subjectname,c.publishar from tbl_book a,dbo.tbl_subject b,tbl_publisher c  where a.publishcode=c.publishcode and a.subjectcode=b.subjectno and a.bookno='" + valcmbbook.SelectedValue + "'";
                    SqlCommand com;
                    com = new SqlCommand(mysql, c.myconn);
                    SqlDataReader reader;
                    reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        label5.Text = Convert.ToString(reader["bookname"]);
                        label2.Text = Convert.ToString(reader["author"]);
                        label7.Text = Convert.ToString(reader["subjectname"]);
                        label6.Text = Convert.ToString(reader["publishar"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void btnsave_Click(object sender, EventArgs e)
        {

            if (dtgbook.Rows.Count < 1)
                return;

            c.returnconn(c.myconn);
            int i = 0;
            SqlTransaction trn;
            trn = c.myconn.BeginTransaction();
            try
            {
                //---------
                string mysql = "";
                mysql = "select * from tbl_booktitle where bookno='" + valcmbbook.SelectedValue + "'";
                SqlCommand com;
                com = new SqlCommand(mysql, c.myconn, trn);
                SqlDataReader reader;
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    i = 0;

                    while (reader.Read())
                    {
                        string filename = @"" + Connection.GetAccessPathId() + @"Barcodes\b\" + reader["BarcodeNo"] + ".bmp";
                        if (System.IO.File.Exists(filename)) { System.IO.File.Delete(filename); }
                        i++;
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }
                //---------
                c.connectsql("delete from tbl_booktitle where bookno=" + valcmbbook.SelectedValue, c.myconn, trn);
                i = 0;
                do
                {
                    if (dtgbook.Rows[i].Cells[1].Value != null)
                    {
                        txtbarnum = Guid.NewGuid().ToString().Replace("-", "").Trim().Substring(0, 10);
                        barcodectrl.BarCode = txtbarnum;
                        c.connectsql("insert into tbl_booktitle (bookno,booktitle,prize,Granttype,Edition,noofpages,publicationyr,barcodeno) values (" + dtgbook.Rows[i].Cells[0].Value + "," + dtgbook.Rows[i].Cells[1].Value + "," + dtgbook.Rows[i].Cells[2].Value + ",'" + dtgbook.Rows[i].Cells[3].Value + "','" + dtgbook.Rows[i].Cells[4].Value + "'," + dtgbook.Rows[i].Cells[5].Value + "," + dtgbook.Rows[i].Cells[6].Value + ",'" + txtbarnum + "')", c.myconn, trn);
                        //----------
                        string filename = @"" + Connection.GetAccessPathId() + @"\Barcodes\b\" + txtbarnum + ".bmp";

                        barcodectrl.SaveImage(filename);
                        FileStream fs;
                        fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                        //a byte array to read the image
                        byte[] picbyte = new byte[fs.Length];
                        fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                        System.Threading.Thread.Sleep(200);
                        fs.Flush();
                        fs.Close();
                        //----------

                        string str1 = "Update dbo.tbl_booktitle set BarcodeImage=@Bimage where booktitle=@booktitle ";
                        SqlCommand cmd = new SqlCommand(str1, c.myconn, trn);
                        cmd.Parameters.AddWithValue("@booktitle", dtgbook.Rows[i].Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Bimage", picbyte);
                        cmd.ExecuteNonQuery();
                        //----------
                        //dtgbook.Rows[i].Cells[7].Value = barcodectrl.BarCode;

                    }
                    i++;
                }
                while (i <= dtgbook.Rows.Count - 1);
                trn.Commit();
                MessageBox.Show("Data Saved..", "School");
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
                trn.Rollback();
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FmTitle_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        

        

        
    }
}
