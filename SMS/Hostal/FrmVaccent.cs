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
    public partial class FrmVaccent :UserControlBase
    {
        public FrmVaccent()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        school c = new school();

        Boolean add_edit = false;
        SqlDataReader reader;
        int i = 0;
        private void shwoList()
        {

            dtgbook.Rows.Clear();
            c.returnconn(c.myconn);
            string mysql = "";
            mysql = " select a.*,b.scholarno,b.name,b.father,c.class from tbl_roomdet a LEFT JOIN tbl_student b ON a.studentno=b.studentno LEFT JOIN  (select t.studentno,a.classno,b.classname+' '+c.sectionname as class from tbl_classstudent t ,tbl_class a,tbl_classmaster b,tbl_section c ";
            mysql = mysql + " where b.classcode=a.classcode and c.sectioncode=a.sectioncode and t.classno=a.classno and t.sessioncode=" + school.CurrentSessionCode + ") c ";
            mysql = mysql + " ON a.studentno=c.studentno   where hostelcode='" + valcmbclass.SelectedValue + "'";
            SqlCommand com;
            com = new SqlCommand(mysql, c.myconn);
            reader = com.ExecuteReader();
            int i = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dtgbook.Rows.Add();
                    dtgbook.Rows[i].Cells[0].Value = reader["Roomno"];
                    dtgbook.Rows[i].Cells[1].Value = reader["bedno"];
                    dtgbook.Rows[i].Cells[2].Value = reader["studentno"];
                    dtgbook.Rows[i].Cells[3].Value = reader["scholarno"];
                    dtgbook.Rows[i].Cells[4].Value = reader["name"];
                    dtgbook.Rows[i].Cells[5].Value = reader["class"];
                    i++;
                }
                reader.Close();
                dtgbook.AllowUserToAddRows = false;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            shwoList();
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            string strmessage = "Invalid Bed No.";

            if (txtbedno.Text.Length == 0)
            {
                goto mline;
                textBox1.Focus();
            }
            //check for existing for room-bed no
            c.returnconn(c.myconn);
            txtbedno.Text = txtbedno.Text.ToUpper();
            string mysql;
            mysql = "select * from tbl_roomdet where hostelcode=" + valcmbclass.SelectedValue + " and  bedno='" + txtbedno.Text + "'";
            SqlCommand com;
            com = new SqlCommand(mysql, c.myconn);
            reader = com.ExecuteReader();
            int i = 0;
            if (reader.HasRows)
            {
                reader.Read();
                int studentno = 0;
                string tstr=Convert.ToString(reader["studentno"]);
                if (string.IsNullOrEmpty(tstr))
                {
                    //do something
                }
                else
                {
                    try
                    {
                        studentno = Convert.ToInt16(reader["studentno"]);
                    }
                    catch
                    {
                    }
                }
                reader.Close();
                if (studentno != 0)
                {
                    SqlTransaction trn;
                    trn = c.myconn.BeginTransaction();
                    c.connectsql("update tbl_roomdet set studentno=null ,allotmentdate=null,studentname=null where studentno=" + lblstudentno.Text + " and  hostelcode=" + valcmbclass.SelectedValue + " and bedno='" + txtbedno.Text + "'", c.myconn, trn);
                    trn.Commit();
                    strmessage = "Room Vacated..";
                }
                else
                {
                    MessageBox.Show("Room/Bed Already Vacated...");
                }
            }
            else
            {
                goto mline;
            }

        mline:
            MessageBox.Show(strmessage);

            shwoList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close(); 
        }

        private void FrmVaccent_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            c.FillcomboBox("select hostelcode,hostelname from tbl_hostel order by hostelname", "hostelname", "hostelcode", ref valcmbclass);
            c.GetMdiParent(this).ToggleSaveButton(true);
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

        private void textBox1_Validated(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                DataSet ds = Connection.GetDataSet("select count(*) from tbl_student where scholarno='" + textBox1.Text + "'");
                if (Convert.ToInt32(ds.Tables[0].Rows[0][0]) == 0)
                { MessageBox.Show("Invalid Scholar No."); }
                else
                {
                    string mysql;
                    mysql = "select * from tbl_student where scholarno='" + textBox1.Text+"'";
                    SqlCommand com;
                    com = new SqlCommand(mysql, c.myconn);
                    reader = com.ExecuteReader();
                    int i = 0;
                    if (reader.HasRows)
                    {
                        reader.Read();
                        int studentno = Convert.ToInt16(reader["studentno"]);
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

        private void FrmVaccent_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
