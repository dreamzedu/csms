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
    public partial class FrmRoomAllotment :UserControlBase
    {
        public FrmRoomAllotment()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        string studentName = "";

        string mysql = "";
        school c = new school();
        Boolean add_edit = false;
        SqlDataReader reader;
        int messfee = 0;
        int hostelfee = 0;
        int i = 0;
        private void FrmRoomAllotment_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            c.FillcomboBox("select hostelcode,hostelname from tbl_hostel order by hostelname", "hostelname", "hostelcode", ref valcmbclass);
      c.GetMdiParent(this).ToggleSaveButton(true);
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || txtbedno.Text == "")
            { MessageBox.Show("field not blanked"); textBox1.Focus(); }
            else
            {
                i = 0;
                if (txtbedno.Text.Length < 1)
                {
                    return;
                }
                txtbedno.Text = txtbedno.Text.ToUpper();
                c.returnconn(c.myconn);
                txtbedno.Text = txtbedno.Text.ToUpper();
                DataSet ds = Connection.GetDataSet("select studentno  from tbl_roomdet where  bedno='" + txtbedno.Text + "'");
                DataSet d1 = Connection.GetDataSet("select count(*) from tbl_roomdet where studentno='" + lblstudentno.Text + "'");
                DataSet dsss = Connection.GetDataSet("select count(*) from tbl_roomdet where studentno='" + lblstudentno.Text + "' and  bedno='" + txtbedno.Text + "'");
                string studentno3 = Convert.ToString(ds.Tables[0].Rows[0][0]);
                int studentno1 = Convert.ToInt32(d1.Tables[0].Rows[0][0]);
                int studentno2 = Convert.ToInt32(dsss.Tables[0].Rows[0][0]);
                if (studentno2 <= 0 && studentno3 == "" && studentno1 <= 0)
                {
                    try
                    {
                        SqlTransaction trn;
                        trn = c.myconn.BeginTransaction();
                        Connection.AllPerform("update tbl_roomdet set studentno='" + lblstudentno.Text + "',studentname='" + lblname.Text + "',allotmentdate='" + dateTimePicker1.Value + "' where hostelcode='" + valcmbclass.SelectedValue + "' and bedno='" + txtbedno.Text + "'");
                        DataSet dss = Connection.GetDataSet("select count(*) from tbl_hostelfee where studentno='" + lblstudentno.Text + "'");
                        int count = Convert.ToInt32(dss.Tables[0].Rows[0][0]);
                        if (count == 0)
                        {

                            DataSet d = Connection.GetDataSet("select roomno from tbl_roomdet where hostelcode=" + valcmbclass.SelectedValue + " and  bedno='" + txtbedno.Text + "'");
                            int roomno = Convert.ToInt32(d.Tables[0].Rows[0][0]);
                            DataSet dd = Connection.GetDataSet("select name from tbl_student where scholarno='" + textBox1.Text + "'");
                            studentName = dd.Tables[0].Rows[0][0].ToString();


                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",5," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",6," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",7," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",8," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",9," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",10," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",11," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",12," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",1," + c.pdate2.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",2," + c.pdate2.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",3," + c.pdate2.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + lblstudentno.Text + ",'" + studentName + "'," + valcmbclass.SelectedValue + ",'" + roomno + "','" + txtbedno.Text + "'," + school.CurrentSessionCode + ",4," + c.pdate2.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            trn.Commit();
                        }
                        else
                        {
                            string roomno = txtbedno.Text;

                            DataSet d11 = Connection.GetDataSet("select roomno from tbl_roomdet where hostelcode=" + valcmbclass.SelectedValue + " and  bedno='" + txtbedno.Text + "'");
                            int rno = Convert.ToInt32(d11.Tables[0].Rows[0][0]);



                            Connection.AllPerform("update tbl_hostelfee set studentno='" + lblstudentno.Text + "',studentname='" + lblname.Text + "',hostelcode='" + valcmbclass.SelectedValue + "',roomno='" + rno + "',bedno='" + txtbedno.Text + "',sessioncode='" + school.CurrentSessionCode + "' where studentno='" + lblstudentno.Text + "'");
                        }
                        MessageBox.Show("room alloted");

                       showList();


                    }
                    catch
                    {
                        //  MessageBox.Show(exx.Message.ToString());
                    }

                }
                else
                {
                    MessageBox.Show("Room/Bed Already Alloted...");
                }
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        private void showList()
        {
            dtgbook.Rows.Clear();
            mysql = " select a.*,b.scholarno,b.name,b.father,c.class from tbl_roomdet a LEFT JOIN tbl_student b ON a.studentno=b.studentno LEFT JOIN  (select t.studentno,a.classno,b.classname+' '+c.sectionname as class from tbl_classstudent t ,tbl_class a,tbl_classmaster b,tbl_section c ";
            mysql = mysql + " where b.classcode=a.classcode and c.sectioncode=a.sectioncode and t.classno=a.classno and t.sessioncode=" + school.CurrentSessionCode + ") c ";
            mysql = mysql + " ON a.studentno=c.studentno   where hostelcode='" + valcmbclass.SelectedValue + "' order by a.roomno,a.bedno";
            SqlCommand com;
            com = new SqlCommand(mysql, c.myconn);
            reader = com.ExecuteReader();
            i = 0;
            if (reader.HasRows)
            {
                try
                {
                    while (reader.Read())
                    {
                        dtgbook.Rows.Add();
                        dtgbook.Rows[i].Cells[0].Value = Convert.ToInt32(reader["Roomno"]);
                        dtgbook.Rows[i].Cells[1].Value = reader["bedno"];
                        dtgbook.Rows[i].Cells[2].Value = reader["scholarno"];
                        dtgbook.Rows[i].Cells[3].Value = reader["name"];
                        dtgbook.Rows[i].Cells[4].Value = reader["class"];
                        // dtgbook.Rows[i].Cells[5].Value = reader[""];
                        i++;
                    }

                }
                catch(Exception ex){Logger.LogError(ex); };

            } reader.Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dtgbook.Rows.Clear();
            c.returnconn(c.myconn);

            showList();



            mysql = "select * from tbl_hostel where hostelcode=" + valcmbclass.SelectedValue;
            SqlCommand com = new SqlCommand(mysql, c.myconn);
            reader = com.ExecuteReader();
            i = 0;
            if (reader.HasRows)
            {
                reader.Read();
                hostelfee = Convert.ToInt16(reader["hostelfee"]);
                messfee = Convert.ToInt16(reader["messfee"]);
            }
            reader.Close();
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            int studentno;
            if (textBox1.Text != "")
            {
                c.returnconn(c.myconn);

                DataSet ds = Connection.GetDataSet("select count(*) from tbl_student where scholarno='" + textBox1.Text + "'");
                if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
                { MessageBox.Show("Invalid Scholar No."); }
                else
                {
                    //string mysql;
                    mysql = "select * from tbl_student where scholarno='" + textBox1.Text + "'";
                    SqlCommand com;
                    com = new SqlCommand(mysql, c.myconn);
                    reader = com.ExecuteReader();
                    i = 0;
                    if (reader.HasRows)
                    {
                        reader.Read();
                        studentno = Convert.ToInt32(reader["studentno"]);
                        lblstudentno.Text = studentno.ToString();
                        label8.Text = Convert.ToString(reader["father"]);
                        lblname.Text = Convert.ToString(reader["name"]);
                        reader.Close();
                        mysql = "select t.studentno,a.classno,b.classname+' '+c.sectionname as class from tbl_classstudent t ,tbl_class a,tbl_classmaster b,tbl_section c ";
                        mysql = mysql + " where b.classcode=a.classcode and c.sectioncode=a.sectioncode and t.classno=a.classno and t.sessioncode=" + school.CurrentSessionCode + " and t.studentno=" + studentno;
                        com = new SqlCommand(mysql, c.myconn);
                        reader = com.ExecuteReader();
                        i = 0;
                        if (reader.HasRows)
                        {
                            reader.Read();
                            lblclass.Text = Convert.ToString(reader["class"]);
                        }
                        reader.Close();
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void txtbedno_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void FrmRoomAllotment_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

       
    }
}
