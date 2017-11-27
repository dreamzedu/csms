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
    public partial class FrmHostal :UserControlBase
    {
        public FrmHostal()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        school1 c = new school1();

        Boolean add_edit = false;
        private void FrmHostal_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            
            c.FillListBox("select * from tbl_hostel", "hostelname", "hostelcode", ref  listBox1);
            DesignForm.fromDesign1(this);
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtclassname.Focus();
            DesignForm.fromDesign2(this);
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtclassname.Text == "" && textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");

            }

            else
            {
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select max(hostelcode) from tbl_hostel", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 101;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(* ) from tbl_hostel where hostelname='" + txtclassname.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        txtclasscode.Text = mstudentno.ToString();
                        c.insertdata("tbl_hostel", c.myconn, this);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }
                    c.FillListBox("select * from tbl_hostel", "hostelname", "hostelcode", ref  listBox1);

                    DesignForm.fromDesign1(this);
                }
                if (add_edit == false)
                {
                    c.updatedata("tbl_hostel", c.myconn, this, "hostelcode", txtclasscode.Text);
                    DesignForm.fromDesign1(this);
                }
                MessageBox.Show("Record Saved...", "School");
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
                c.FillListBox("select * from tbl_hostel", "hostelname", "hostelcode", ref  listBox1);
            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign1(this);
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
            DesignForm.fromDesign1(this);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void txtclassname_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            try
            {
                String lstval = Convert.ToString(listBox1.SelectedValue);
                c.showdata("tbl_hostel", c.myconn, this, "hostelcode", lstval);
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {
            int k = Connection.Login("select count(*) from tbl_hostelroom where hostelcode='" + txtclasscode.Text + "'");
            int l = Connection.Login("select count(*) from tbl_hostelfee where hostelcode='" + txtclasscode.Text + "'");
            int m = Connection.Login("select count(*) from tbl_roomdet where hostelcode='" + txtclasscode.Text + "'");
            if (k > 0 || l > 0 || m > 0)
            { MessageBox.Show("You Can Not Deleted Hostel:-" + txtclassname.Text + " ,Because It Has A Refrence Of Another Palce"); }
            else
            {
                Connection.AllPerform("delete  from tbl_hostel where hostelname='" + txtclassname.Text + "' ");
                MessageBox.Show("Record Deleted");
            }
            c.cleartext(this);
            c.FillListBox("select * from tbl_hostel", "hostelname", "hostelcode", ref  listBox1);
        }

        private void FrmHostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Charcter value");
            }
        }

        private void FrmHostal_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
