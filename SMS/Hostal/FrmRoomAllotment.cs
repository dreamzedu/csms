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
        DateTimePicker oDateTimePicker;
        const string allotText = "Allot Bed";
        const string vacateText = "Vacate Bed";
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
      //c.GetMdiParent(this).ToggleSaveButton(true);
        }

        /*public override void btnsave_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || txtbedno.Text == "")
            { MessageBox.Show("fields should not be blank"); }
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
        }*/

        private void showList()
        {
            dtgbook.Rows.Clear();
            mysql = " select a.*,b.scholarno,b.studentno, b.name,b.father,c.class from tbl_roomdet a LEFT JOIN tbl_student b ON a.studentno=b.studentno LEFT JOIN  (select t.studentno,a.classno,b.classname+' '+c.sectionname as class from tbl_classstudent t ,tbl_class a,tbl_classmaster b,tbl_section c ";
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

                        if (reader["scholarno"] != DBNull.Value && reader["scholarno"] != null)
                        {
                            dtgbook.Rows[i].Cells[7].Value = "Vacate Bed";
                            dtgbook.Rows[i].Cells[7].Style.ForeColor = Color.Red;
                            dtgbook.Rows[i].Cells[2].ReadOnly = true;
                            dtgbook.Rows[i].Cells[5].ReadOnly = true;
                            dtgbook.Rows[i].Cells[6].Style.BackColor = Color.LightYellow;
                        }
                        else
                        {
                            dtgbook.Rows[i].Cells[7].Value = "Allot Bed";
                            dtgbook.Rows[i].Cells[7].Style.ForeColor = Color.Green;
                            dtgbook.Rows[i].Cells[2].Style.BackColor = Color.LightYellow;
                            dtgbook.Rows[i].Cells[5].Style.BackColor = Color.LightYellow;
                            dtgbook.Rows[i].Cells[6].ReadOnly = true;
                        }

                        dtgbook.Rows[i].Cells[8].Value = reader["studentno"];
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

        /*private void textBox1_Validated(object sender, EventArgs e)
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
        }*/

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

        private void dtgbook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (oDateTimePicker != null) { oDateTimePicker.Visible = false; } 

            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 7)
                {
                    RoomAllotmentDetail rad = new RoomAllotmentDetail()
                    {
                        roomNo = dtgbook.CurrentRow.Cells[0].Value == null ? 0 : Convert.ToInt32(dtgbook.CurrentRow.Cells[0].Value),
                        bedNo = dtgbook.CurrentRow.Cells[1].Value as string,
                        scholarNo = dtgbook.CurrentRow.Cells[2].Value as string,
                        studentName = dtgbook.CurrentRow.Cells[3].Value as string,
                        allotDate = dtgbook.CurrentRow.Cells[5].Value as string,
                        vacateDate = dtgbook.CurrentRow.Cells[6].Value as string,
                        studentNo = dtgbook.CurrentRow.Cells[8].Value == null ? 0 : Convert.ToInt32(dtgbook.CurrentRow.Cells[8].Value)
                    };
                 
                    if(dtgbook.CurrentCell.Value.ToString() == allotText)
                    {
                        AllotBed(rad);
                    }
                    else
                    {
                        VacateBed(rad);
                    }

                }
                else if ((e.ColumnIndex == 5 || e.ColumnIndex == 6 ) && !dtgbook.CurrentCell.ReadOnly)
                {
                    ShowDatePicker(e.ColumnIndex, e.RowIndex);
                    dtgbook.CurrentCell.Value = oDateTimePicker.Text.ToString();
                }
            }
        }

        private void VacateBed(RoomAllotmentDetail rad)
        {
            if (dtgbook.IsCurrentCellDirty)
            {
                dtgbook.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }


            if (string.IsNullOrEmpty(rad.vacateDate))
            {
                MessageBox.Show("Please enter date of vacating the room");
            }
           
            SqlTransaction trn;
            trn = c.myconn.BeginTransaction();
            c.connectsql("update tbl_roomdet set studentno=null ,allotmentdate=null,studentname=null where studentno=" + rad.studentNo + " and  hostelcode=" + valcmbclass.SelectedValue + " and bedno='" + rad.bedNo + "'", c.myconn, trn);
            //string sql="";
            //if (c.pdate1.Year == Convert.ToDateTime(rad.vacateDate).Year)
            //{
            //    for (int i = Convert.ToDateTime(rad.vacateDate).Month+1; i <= 12; i++)
            //    {
            //        sql += "delete from tbl_hostelfee where studentno=" + rad.studentNo + " and bedno = " + rad.bedNo + " and monthno= " + i + "  and sessioncode=" + school.CurrentSessionCode + ";";
            //    }
            //}
            //else if (c.pdate2.Year == Convert.ToDateTime(rad.vacateDate).Year)
            //{
            //    for (int i = Convert.ToDateTime(rad.vacateDate).Month + 1; i < 5; i++)
            //    {
            //        sql += "delete from tbl_hostelfee where studentno=" + rad.studentNo + " and bedno = " + rad.bedNo + " and monthno= " + i + "  and sessioncode=" + school.CurrentSessionCode + ";";
            //    }
            //}

            //c.connectsql(sql, c.myconn, trn);
                         
            trn.Commit();
            MessageBox.Show("Room vacated successfully.");              
           
            showList();
        }

        private void AllotBed(RoomAllotmentDetail rad)
        {
            if (dtgbook.IsCurrentCellDirty)
            {
                dtgbook.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }

            if (string.IsNullOrEmpty(rad.scholarNo))
            { 
                MessageBox.Show("Please enter Scholar Number"); 
            }
            else if (string.IsNullOrEmpty(rad.studentName))
            {
                MessageBox.Show("Scholar Name should not be empty, ensure that you have entered correct Scholar Number.");
            }
            else if (string.IsNullOrEmpty(rad.allotDate))
            {
                MessageBox.Show("Please enter Allotment Date.");
            }
            else
            {
                i = 0;
                if (string.IsNullOrEmpty(rad.bedNo))
                {
                    return;
                }

                c.returnconn(c.myconn);
                DataSet ds = Connection.GetDataSet("select studentno  from tbl_roomdet where  bedno='" + rad.bedNo + "'");
                DataSet d1 = Connection.GetDataSet("select count(*) from tbl_roomdet where studentno='" + rad.studentNo + "'");
                DataSet dsss = Connection.GetDataSet("select count(*) from tbl_roomdet where studentno='" + rad.studentNo + "' and  bedno='" + rad.bedNo + "'");
                string studentno3 = Convert.ToString(ds.Tables[0].Rows[0][0]);
                int studentno1 = Convert.ToInt32(d1.Tables[0].Rows[0][0]);
                int studentno2 = Convert.ToInt32(dsss.Tables[0].Rows[0][0]);
                if (studentno2 <= 0 && studentno3 == "" && studentno1 <= 0)
                {
                    try
                    {
                        SqlTransaction trn;
                        trn = c.myconn.BeginTransaction();
                        Connection.AllPerform("update tbl_roomdet set studentno='" + rad.studentNo + "',studentname='" + rad.studentName + "',allotmentdate='" + rad.allotDate + "' where hostelcode='" + valcmbclass.SelectedValue + "' and bedno='" + rad.bedNo + "'");
                        DataSet dss = Connection.GetDataSet("select count(*) from tbl_hostelfee where studentno='" + rad.studentNo + "'");
                        int count = Convert.ToInt32(dss.Tables[0].Rows[0][0]);
                        if (count == 0)
                        {
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",5," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",6," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",7," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",8," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",9," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",10," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",11," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",12," + c.pdate1.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",1," + c.pdate2.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",2," + c.pdate2.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",3," + c.pdate2.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            c.connectsql("insert into tbl_hostelfee (studentno,studentname,hostelcode,roomno,bedno,sessioncode,monthno,yearno,hostelfee,messfee,rechostelfee,recmessfee) values (" + rad.studentNo + ",'" + rad.studentName + "'," + valcmbclass.SelectedValue + ",'" + rad.roomNo + "','" + rad.bedNo + "'," + school.CurrentSessionCode + ",4," + c.pdate2.Year + "," + hostelfee + "," + messfee + ",'" + 0 + "','" + 0 + "')", c.myconn, trn);
                            trn.Commit();
                        }
                        else
                        {                         

                            Connection.AllPerform("update tbl_hostelfee set studentno='" + rad.studentNo + "',studentname='" + rad.studentName + "',hostelcode='" + valcmbclass.SelectedValue + "',roomno='" + rad.roomNo + "',bedno='" + rad.bedNo + "',sessioncode='" + school.CurrentSessionCode + "' where studentno='" + rad.studentNo + "'");
                        }
                        MessageBox.Show("Room alloted successfully.");

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
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dtgbook.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        private void ShowDatePicker(int colIndex, int rowIndex)
        {

            oDateTimePicker = new DateTimePicker();
            dtgbook.Controls.Add(oDateTimePicker);
            //oDateTimePicker.Text = "";
            oDateTimePicker.Format = DateTimePickerFormat.Short;
            Rectangle oRectangle = dtgbook.GetCellDisplayRectangle(colIndex, rowIndex, true);
            oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
            oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);
            oDateTimePicker.Validated += new EventHandler(dateTimePicker_OnValidated);
            oDateTimePicker.Visible = true;

        }

        private void dateTimePicker_OnValidated(object sender, EventArgs e)
        {
            dtgbook.CurrentCell.Value = oDateTimePicker.Text.ToString();
            oDateTimePicker.Visible = false;
        }



        private void dtgbook_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex > -1)
            {
                if(dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    PopulateStudentDetailInTheGrid(e.RowIndex, e.ColumnIndex, dtgbook.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }

        }

        private void PopulateStudentDetailInTheGrid(int roIndex, int colIndex, string scholarNo)
        {
            int studentno;
            if (scholarNo != "")
            {
                c.returnconn(c.myconn);

                object val = Connection.GetExecuteScalar("select count(*) from tbl_student where scholarno='" + scholarNo + "'");
                if (val != null && Convert.ToInt32(val) == 0)
                { 
                    MessageBox.Show("Invalid Scholar No.");
                    dtgbook.CurrentCell.Value = "";
                }
                else
                {

                    SqlCommand com;
                    mysql = "select b.classname+' '+c.sectionname as class, s.name, s.studentno from tbl_classstudent t inner join tbl_class a on t.classno=a.classno "
                            + " inner join tbl_classmaster b on b.classcode=a.classcode "
                            + " inner join tbl_section c on c.sectioncode=a.sectioncode "
                            + " inner join tbl_student s on s.studentno = t.studentno "
                            + " where t.sessioncode=" + school.CurrentSessionCode + " and s.scholarno='" + scholarNo + "'";
                    com = new SqlCommand(mysql, c.myconn);
                    reader = com.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        dtgbook.Rows[roIndex].Cells[colIndex + 2].Value = Convert.ToString(reader["class"]);
                        dtgbook.Rows[roIndex].Cells[colIndex + 1].Value = reader["name"];
                        dtgbook.Rows[roIndex].Cells[8].Value = reader["studentno"];
                    }
                    reader.Close();

                }
            }
        }

       
    }

    public class RoomAllotmentDetail
    {
        public string bedNo;
        public Int32 roomNo;
        public string scholarNo;
        public string allotDate;
        public string vacateDate;
        public string studentName;
        public Int32 studentNo;
    }
}
