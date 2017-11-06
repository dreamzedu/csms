using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.Hostal
{
    public partial class FrmRoom :UserControlBase
    {
        public FrmRoom()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        school c = new school();
        Boolean add_edit = false;
        int i = 0;
        int count;
        public override void btnsave_Click(object sender, EventArgs e)
        {
            c.getconnstr();
            i = 0;
            c.returnconn(c.myconn);
            SqlTransaction trn;
            trn = c.myconn.BeginTransaction();
            try
            {


                Connection.AllPerform("delete tbl_hostelroom where hostelcode='" + valcmbclass.SelectedValue + "'");
                Connection.AllPerform("delete tbl_roomdet where hostelcode='" + valcmbclass.SelectedValue + "'");


                do
                {

                    string mysql = "";




                    if (dtgbook.Rows[i].Cells[0].Value != null)
                    {
                        mysql = "insert into tbl_hostelroom (hostelcode,roomno,totalbeds) values (" + valcmbclass.SelectedValue + "," + dtgbook.Rows[i].Cells[0].Value + "," + dtgbook.Rows[i].Cells[1].Value + ")";
                        c.connectsql(mysql, c.myconn, trn);
                    }
                    if (dtgbook.Rows[i].Cells[1].Value != null)
                    {
                        int totbed = Convert.ToInt16(dtgbook.Rows[i].Cells[1].Value);

                        for (int j = 0; j < totbed; j++)
                        {
                            string bedno = "";
                            switch (j)
                            {
                                case 0:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-A";
                                    break;
                                case 1:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-B";
                                    break;
                                case 2:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-C";
                                    break;
                                case 3:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-D";
                                    break;
                                case 4:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-E";
                                    break;
                                case 5:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-F";
                                    break;
                                case 6:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-G";
                                    break;
                                case 7:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-H";
                                    break;
                                case 8:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-I";
                                    break;
                                case 9:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-J";
                                    break;
                                case 10:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-K";
                                    break;
                                case 11:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-L";
                                    break;
                                case 12:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-M";
                                    break;
                                case 13:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-N";
                                    break;
                                case 14:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-O";
                                    break;
                                case 15:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-P";
                                    break;
                                case 16:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-Q";
                                    break;
                                case 17:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-R";
                                    break;
                                case 18:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-S";
                                    break;
                                case 19:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-T";
                                    break;
                                case 20:
                                    bedno = dtgbook.Rows[i].Cells[0].Value.ToString() + "-U";
                                    break;
                                default: break;
                            }

                            mysql = "insert into tbl_roomdet(hostelcode,roomno,bedno) values (" + valcmbclass.SelectedValue + "," + dtgbook.Rows[i].Cells[0].Value + ",'" + bedno + "')";
                            c.connectsql(mysql, c.myconn, trn);

                        }
                        //     }
                        // }
                    }

                    i++;

                    // }
                    // else { MessageBox.Show("Duplicate Data Not Allowed"); }
                }


                while (i <= dtgbook.Rows.Count - 1);
                trn.Commit();
                MessageBox.Show("Data Saved..", "School");

                //}
                //else { MessageBox.Show("duplicate entry not allowed"); } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trn.Rollback();
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FrmRoom_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            c.FillcomboBox("select hostelcode,hostelname from tbl_hostel order by hostelname", "hostelname", "hostelcode", ref valcmbclass);
            c.GetMdiParent(this).ToggleSaveButton(true);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                c.getconnstr();
                dtgbook.Rows.Clear();
                c.returnconn(c.myconn);
                string mysql = "";
                mysql = "select * from tbl_hostelroom where hostelcode='" + valcmbclass.SelectedValue + "'";
                DataSet ds = Connection.GetDataSet("select noofrooms from tbl_hostel where hostelcode='" + valcmbclass.SelectedValue + "'");
                int g = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                SqlCommand com;
                com = new SqlCommand(mysql, c.myconn);
                SqlDataReader reader;
                reader = com.ExecuteReader();
                i = 0;

                if (reader.HasRows)
                {
                    while (i < g)
                    {
                        if (reader.Read())
                        {
                            dtgbook.Rows.Add();
                            dtgbook.Rows[i].Cells[0].Value = reader["roomno"];
                            dtgbook.Rows[i].Cells[1].Value = reader["totalbeds"];
                        }
                        else { dtgbook.Rows.Add(); }
                        i++;


                    }

                    reader.Close();
                    dtgbook.AllowUserToAddRows = false;
                }
                else
                {
                    reader.Close();
                    mysql = "select * from tbl_hostel where hostelcode='" + valcmbclass.SelectedValue + "'";
                    com = new SqlCommand(mysql, c.myconn);
                    reader = com.ExecuteReader();
                    if (reader.HasRows)
                    {
                        int rooms = 1;
                        try
                        {
                            reader.Read();
                            if (reader["noofrooms"] == null)
                            {
                            }
                            else
                            {
                                rooms = Convert.ToInt16(reader["noofrooms"]);
                            }
                        }
                        catch
                        {
                        }
                        while (i < rooms)
                        {
                            dtgbook.Rows.Add();
                            i++;
                        }
                    }
                }
            }
            catch { }
        }

        public override void frm_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F3")
            {
                dtgbook.Rows.Add();
            }

            base.frm_keydown(sender, e);
        }

        private void FrmRoom_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

       

        
    }
}
