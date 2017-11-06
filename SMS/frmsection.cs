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
    public partial class frmsection :UserControlBase
    {
        school1 c = new school1();

        Boolean add_edit = false;
        public frmsection()
        {
            InitializeComponent();    //DesignForm.fromDesign1(this);
            Connection.SetUserControlTheme(this);
        }

        private void frmsection_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            
            c.FillListBox("select * from tbl_section", "sectionname", "sectioncode", ref  listBox1);

            c.returnconn(c.myconn);
            SqlCommand command = new SqlCommand("select max(sectioncode) from tbl_section", c.myconn);
            command.CommandTimeout = 120;
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            //DesignForm.fromDesign2(this);
            txtsectionname.Text = "";
            txtsectionname.Enabled = true;
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtsectionname.Focus();

        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            //DesignForm.fromDesign2(this);
            txtsectionname.Enabled = true;
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();

        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsectionname.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed.");

            }

            else
            {
                if (txtsectionname.Text == "")
                {

                    MessageBox.Show("Null Value Not Allowed.");
                }
                else
                {

                    if (add_edit == true)
                    {
                        c.returnconn(c.myconn);
                        SqlCommand command = new SqlCommand("select max(sectioncode) from tbl_section", c.myconn);
                        command.CommandTimeout = 120;
                        Int32 mstudentno;
                        mstudentno = 101;
                        if (command.ExecuteScalar() != System.DBNull.Value)
                        {
                            mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                        }
                        DataSet ds = Connection.GetDataSet("select count(* ) from tbl_section where sectionname='" + txtsectionname.Text + "'");
                        int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        if (i == 0)
                        {
                            txtsectioncode.Text = mstudentno.ToString();
                            c.insertdata("tbl_section", c.myconn, this);
                            MessageBox.Show("Record Saved.", "School");
                        }
                        else
                        {
                            MessageBox.Show("Duplicate data not allowed.");
                        }

                    }
                    if (add_edit == false)
                    {
                       
                            //txtsectioncode.Text = mstudentno.ToString();
                            //c.insertdata("tbl_section", c.myconn, this);
                            c.updatedata("tbl_section", c.myconn, this, "sectioncode", txtsectioncode.Text);
                            MessageBox.Show("Record Update.", "School");


                        

                    }

                   
                    txtsectionname.Enabled = false ;
                    c.FillListBox("select * from tbl_section", "sectionname", "sectioncode", ref  listBox1);
                    c.GetMdiParent(this).EnableAllEditMenuButtons();
                    
                    //DesignForm.fromDesign1(this);

                }
            }
        }

        private void txtsectionname_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (char.IsLetter(e.KeyChar) == true)
            {

                if (txtsectionname.Text.Length < 2)
                {

                }
                else
                {
                    MessageBox.Show("Only One Char Section Name Allowed.");
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(listBox1.SelectedValue);
            c.showdata("tbl_section", c.myconn, this, "sectioncode", lstval);
        }

        private void txtsectionname_TextChanged(object sender, EventArgs e)
        {
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {
            int k = Connection.Login(" SELECT     COUNT(Section) AS Expr1   FROM         tbl_classstudent  WHERE     (Section = '" + txtsectioncode.Text + "')   ");
            if (k > 0)
            {
                MessageBox.Show("You Can Not Delete section Record.");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    Connection.AllPerform("delete  from tbl_section where sectionname='" + txtsectionname.Text + "' ");
                    MessageBox.Show("Record Deleted.");
                    Connection.AllPerform("Delete from tbl_classstudent where section='" + txtsectioncode.Text + "'");
                    c.FillListBox("select * from tbl_section", "sectionname", "sectioncode", ref  listBox1);
                    //DesignForm.fromClear(this);
                }
            }
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmsection_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }







    }
}