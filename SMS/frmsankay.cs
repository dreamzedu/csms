using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmsankay :UserControlBase
    {
        school1 c = new school1();

        Boolean add_edit = false;

        public frmsankay()
        {
            InitializeComponent();    
            DesignForm.fromDesign1(this);
            Connection.SetUserControlTheme(this);
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            txtsankayname.Text = "";
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtsankayname.Focus();

        }

        private void frmsankay_Load(object sender, EventArgs e)
        {


            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            

            c.FillListBox("select * from tbl_sankay", "sankayname", "sankaycode", ref  listBox1);

            c.returnconn(c.myconn);
            SqlCommand command = new SqlCommand("select max(sankaycode) from tbl_sankay", c.myconn);
            command.CommandTimeout = 120;
            Int32 mstudentno;
            mstudentno = 1001;
            if (command.ExecuteScalar() != System.DBNull.Value)
            {
                mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
            }

        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            

        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsankayname.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");
            }
            else
            {//c.datasave("tbl_school", c.myconn, this);
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select max(sankaycode) from tbl_sankay", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 1001;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(* ) from tbl_sankay where sankayname='" + txtsankayname.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        txtsankaycode.Text = mstudentno.ToString();
                        c.insertdata("tbl_sankay", c.myconn, this);
                        MessageBox.Show("Record Saved.", "School");
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }

                }
                if (add_edit == false)
                {
                    if (Convert .ToInt32(listBox1.SelectedValue) == 1001)
                    {
                        MessageBox.Show("You Can Not Delete This Stream...");
                        return;
                    }
                    else 
                    {
                        c.updatedata("tbl_sankay", c.myconn, this, "sankaycode", txtsankaycode.Text);
                        MessageBox.Show("Record Updated.", "School");
                    }
                   
                }
       
                c.FillListBox("select * from tbl_sankay", "sankayname", "sankaycode", ref  listBox1);
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
            }
            DesignForm.fromDesign1 (this);
        }





        private void txtsankayname_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true)
            {
                if (txtsankayname.Text.Length < 10)
                {

                }
                else
                {
                    MessageBox.Show("Only Three Character Sankay Name Allowed..");
                    e.Handled = true;

                }
            }

            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            }
            c.entertotab(e.KeyChar);
        }

        private void txtsankayname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsankayname_Validated(object sender, EventArgs e)
        {
            txtsankayname.Text = school.ToTitleCase(txtsankayname.Text);
            
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(listBox1.SelectedValue);
            c.showdata("tbl_sankay", c.myconn, this, "sankaycode", lstval);
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {
            int k = Connection.Login("SELECT COUNT(*) AS Expr1   FROM tbl_classstudent  WHERE (Stream = '" + txtsankaycode.Text + "') ");
            if (k > 0)
            {
                MessageBox.Show("You Can Not Delete Stream Record.");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record.", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    Connection.AllPerform("delete from tbl_sankay where sankayname='" + txtsankayname.Text + "' ");
                    MessageBox.Show("Record Deleted."); 
                    c.FillListBox("select * from tbl_sankay", "sankayname", "sankaycode", ref  listBox1);

                    DesignForm.fromClear(this);
                }
            }
           
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtsankaycode_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmsankay_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);

        }


    }
}