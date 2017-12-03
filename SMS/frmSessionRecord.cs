using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS
{
    public partial class frmSessionRecord :UserControlBase
    {
        int count;
        school1 c = new school1();
        public frmSessionRecord()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtSessionName.Text == "")
            {
                MessageBox.Show("Session Name is Not Entered.");
            }
            else
            {
                if (count == 1)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select max(sessioncode) from tbl_session", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 101;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    txtsessioncode.Text = mstudentno.ToString();

                    DataSet ds = Connection.GetDataSet("select count(*) from tbl_session where sessionname='" + txtSessionName.Text + "'");
                    int n = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    if (n == 0)
                    {
                        Connection.AllPerform("insert into tbl_session(sessioncode,s_from,s_to,sessionname)values('" + txtsessioncode.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','" + dateTimePicker2.Value.ToShortDateString() + "','" + txtSessionName.Text + "')");
                        MessageBox.Show("Session Name Saved");
                        GetSessionList();
                        SaveFalse();
                        txtSessionName.Enabled = false ;
                        dateTimePicker1.Enabled = false;
                        dateTimePicker2.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Session Name Alreddy Exist.");
                    }
                }
                if (count == 2)
                {
                    //DataSet ds = Connection.GetDataSet("select count(*) from tbl_session where sessionname='" + txtSessionName.Text + "'");
                    DataSet ds = Connection.GetDataSet("select count(*) from tbl_session where sessioncode='" + txtsessioncode.Text + "'");
                    int n = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                    if (n == 1)
                    {
                        Connection.AllPerform("update tbl_session set sessionname='" + txtSessionName.Text + "', s_from='" + dateTimePicker1.Value.ToShortDateString() + "' ,s_to='" + dateTimePicker2.Value.ToShortDateString() + "'  where sessioncode='" + txtsessioncode.Text + "'");
                        MessageBox.Show("Session Name Updated Successfully.");
                        GetSessionList();
                        SaveFalse();
                    }
                    else
                    {
                        MessageBox.Show("Session Name Alreddy Exist.");
                    }
                }
            }
        }
        private void frmSessionRecord_Load(object sender, EventArgs e)
        {            
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
            c.getconnstr();
            GetSessionList();
            //lbSessionname_SelectedIndexChanged(lbSessionname, new EventArgs());
            //txtSessionName.Clear();
            txtSessionName.Focus();
        }
        private void SaveTrue()
        {
           c.GetMdiParent(this).ToggleSaveButton(true);
           c.GetMdiParent(this).ToggleEditButton(false);
           c.GetMdiParent(this).ToggleCancelButton(true);
        }
        private void SaveFalse()
        {
           c.GetMdiParent(this).ToggleSaveButton(false);
           c.GetMdiParent(this).ToggleEditButton(true);
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
           
            //this.Close();
        }      
        private void GetSessionList()
        {
            DataSet ds = Connection.GetDataSet("select distinct sessionname,sessioncode from tbl_session order by sessionname");
            if (ds.Tables[0].Rows.Count >0)
            {
                lbSessionname.DisplayMember = ds.Tables[0].Columns["sessionname"].ToString();
                lbSessionname.ValueMember = ds.Tables[0].Columns["sessioncode"].ToString();
                lbSessionname.DataSource = ds.Tables[0];
            }
        }
        private void lbSessionname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Connection.GetDataSet("Select * from tbl_session where sessioncode='" + lbSessionname.SelectedValue.ToString() + "'");
                txtSessionName.Text = lbSessionname.Text;
                txtsessioncode.Text = lbSessionname.SelectedValue.ToString();
                dateTimePicker1.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                dateTimePicker2.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                SaveFalse();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); MessageBox.Show(ex.Message);
            }
        }
        public override void btnedit_Click(object sender, EventArgs e)
        {


            c.GetMdiParent(this).ToggleNewButton(false);
           c.GetMdiParent(this).ToggleSaveButton(true);
           c.GetMdiParent(this).ToggleCancelButton(true);
            count = 2;
            txtSessionName.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
          
        }
        public override void btnnew_Click(object sender, EventArgs e)
        {            
            count = 1;
            txtSessionName.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            SaveTrue();
            txtSessionName.Clear();
            txtSessionName.Focus();
        }
        public override void btndelete_Click(object sender, EventArgs e)
        {
            int k = Connection.Login("select count(*) from tbl_classstudent where sessioncode ='" + txtsessioncode .Text + "'");
            if (k > 0)
            {
                MessageBox.Show("!!! You Can Not Delete Session  Record.");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    Connection.AllPerform("Delete from tbl_session where sessioncode='" + txtsessioncode.Text + "'");
                    MessageBox.Show("Record Deleted");
                    GetSessionList();                  
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public override void btnprint_Click(object sender, EventArgs e)
        {

        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            c.GetMdiParent(this).ToggleNewButton(true);
            c.GetMdiParent(this).ToggleEditButton(false);
            c.GetMdiParent(this).ToggleSaveButton(false);
            c.GetMdiParent(this).ToggleCancelButton(false);
        }

        private void txtSessionName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtsessioncode_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmSessionRecord_Paint(object sender, PaintEventArgs e)
        {
            ////public static void fromClear(Form f);
        }
    }
}
