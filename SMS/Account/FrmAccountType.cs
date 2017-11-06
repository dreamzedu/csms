using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.Account
{
    public partial class FrmAccountType :UserControlBase
    {

        school1 c = new school1();
        Boolean add_edit = false;
        public FrmAccountType()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close(); 
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            try
            {
               
                add_edit = true;
                c.GetMdiParent(this).DisableAllEditMenuButtons();
                txtaccountgroup.Focus();
                c.cleartext(this);
                DesignForm.fromDesign2(this);
            }
            catch { }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
            DesignForm.fromDesign1(this);
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            listBox1.Focus();
            c.GetMdiParent(this).ToggleDeleteButton(true);
            DesignForm.fromDesign2(this);
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {

        }

        public override void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void FrmAccountType_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            
            c.FillListBox("select * from tbl_actype", "acdesc", "actype", ref  listBox1);
            DesignForm.fromDesign1(this);
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtaccountgroup.Text == string.Empty)
            {

                MessageBox.Show("Null Value Not Allowed ");
            }
            else
            {
                txtfinal.Text = cmbfinalaccounttype.Text.Substring(0, 1);
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select isnull(max(actype),0) from tbl_actype", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 101;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(* ) from tbl_actype where acdesc='" + txtaccountgroup.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        txtactype.Text = mstudentno.ToString();
                        c.insertdata("tbl_actype", c.myconn, this);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }
                    DesignForm.fromDesign1(this);

                }
                if (add_edit == false)
                {
                    c.updatedata("tbl_actype", c.myconn, this, "actype", txtactype.Text);
                    DesignForm.fromDesign1(this);
                }

                MessageBox.Show("Record Saved...", "School");
                c.FillListBox("select * from tbl_actype", "acdesc", "actype", ref  listBox1);
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(listBox1.SelectedValue);
            c.showdata("tbl_actype", c.myconn, this, "actype", lstval);
        }

        private void txtaccountgroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Charcter value");
            }
            c.entertotab(e.KeyChar);
        }

        private void cmbfinalaccounttype_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Charcter value");
            }
            c.entertotab(e.KeyChar);
        }

        private void txtaccountgroup_Validated(object sender, EventArgs e)
        {
            txtaccountgroup.Text = txtaccountgroup.Text.ToUpper();
        }

        private void FrmAccountType_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
