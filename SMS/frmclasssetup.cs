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
    public partial class frmclasssetup :UserControlBase
    {
        school1 c = new school1();
        Boolean add_edit = false;
        public frmclasssetup()
        {
            InitializeComponent(); 
            Connection.SetUserControlTheme(this);
        }
        private void frmclasssetup_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            
            c.FillListBox("select distinct * from tbl_classmaster order by ClassOrder", "classname", "classcode", ref  listBox1);
            c.returnconn(c.myconn);
            SqlCommand command = new SqlCommand("select max(classcode) from tbl_classmaster", c.myconn);
            command.CommandTimeout = 120;
            Int32 mstudentno;
            mstudentno = 1001;
            if (command.ExecuteScalar() != System.DBNull.Value)
            {
                mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
            }
            strcmbClassOrder.Items.Clear();
            for (int i = 1; i <= listBox1.Items.Count; i++)
                strcmbClassOrder.Items.Add(i);
        }
        private void txtclassname_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        public override void btnedit_Click(object sender, EventArgs e)
        {
            txtclassname.Enabled = true;
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtclassname.Focus();
        }
        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
        }
        public override void btnnew_Click(object sender, EventArgs e)
        {          
            txtclassname.Text = "";
            txtclassname.Enabled = true;
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtclassname.Focus();
        }
        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtclassname.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");
            }
            else
            {
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select max(classcode) from tbl_classmaster", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 101;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    txtclasscode.Text = mstudentno.ToString();
                    DataSet ds = Connection.GetDataSet("select count(*) from tbl_classmaster where classname='" + txtclassname.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        c.insertdata("tbl_classmaster", c.myconn, this);
                        MessageBox.Show("Record Saved.", "School");
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }

                }
                if (add_edit == false)
                { 
                    
                    c.updatedata("tbl_classmaster", c.myconn, this, "classcode", txtclasscode.Text);
                    MessageBox.Show("Record Update.", "School");
                }
                
                txtclassname.Enabled = false ;
                c.FillListBox("select * from tbl_classmaster order by ClassOrder", "classname,", "classcode", ref  listBox1);
                // c.FillListBox ( "select  classname COUNT(*) as DupeCount FROM tbl_classmaster GROUP BY classname HAVING COUNT(*) > 1 Order By classname");

                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
            }           
        } 

        public override void btndelete_Click(object sender, EventArgs e)
        {
            int k = Connection.Login("select count(*) from tbl_classstudent where classno='" + txtclasscode.Text + "'");
            if (k > 0)
            {
                MessageBox.Show("You Can Not Delete Class Record.");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record.", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    Connection.AllPerform("delete  from tbl_classmaster where classname='" + txtclassname.Text + "' ");
                    Connection.AllPerform("Delete from tbl_classstudent where classno='" + txtclasscode.Text + "'");
                    MessageBox.Show("Record Deleted.");

                    c.FillListBox("select * from tbl_classmaster order by classcode", "classname,", "classcode", ref  listBox1);
                    //DesignForm.fromClear(this);
                }
            }    
        }
        private void txtclassname_KeyPress_1(object sender, KeyPressEventArgs e)
        {           
            //if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            //{
            //    if (char.IsLetter(e.KeyChar) == true)
            //    {
            //        if (txtclassname.Text.Length < 3)
            //        {
            //            e.Handled = true;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Only Three Character Class Name Allowed..");
            //            txtclassname.Clear();

            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Input");
            //   // e.Handled = false;
            //}
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                c.showdata("tbl_classmaster", c.myconn, this, "classcode", listBox1 .SelectedValue.ToString () );
            }
            catch { }
        }

        private void frmclasssetup_Paint(object sender, PaintEventArgs e)
        {
            ////public static void fromClear(Form f);
        }
         
    }
}