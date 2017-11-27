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
    public partial class FrmAccount :UserControlBase
    {
        school1 c = new school1();
        Boolean add_edit = false;
        public FrmAccount()
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
                txtaccountname.Focus();
                c.cleartext(this);
                DesignForm.fromDesign2(this);
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            BtnSearch.Visible = false;
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
            BtnSearch.Visible = true;
            DesignForm.fromDesign2(this);
        }

        private void FrmAccount_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            c.FillcomboBox("select * from tbl_actype order by acdesc", "acdesc", "actype", ref valcmbaccountgroup);
            c.FillListBox("select * from tbl_account", "acname", "accode", ref  listBox1);
            c.FillcomboBox("select * from tbl_account", "acname", "accode", ref  valcmbparent);
            
            BtnSearch.Visible = false;
            DesignForm.fromDesign1(this);
        }

        private void btnnew_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void txtaccountname_Validated(object sender, EventArgs e)
        {
            txtaccountname.Text = txtaccountname.Text.ToUpper();
        }

        public void FillAccountDetails(String lstval)
        {
            c.showdata("tbl_account", c.myconn, this, "accode", lstval);


            string CCEID = Connection.GetId("select isnull(actype,0) as actype  from tbl_account where accode='" + lstval + "'");
            if (CCEID.Equals(string.Empty))
            {
                MessageBox.Show("Account not created.");
                c.cleartext(this);
            }
            else
            {
                if (chksubledger.Checked == true)
                {
                    SqlCommand command = new SqlCommand("select accode from tbl_subledger_account where subledgercode=" + lstval, c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        valcmbparent.SelectedValue = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(listBox1.SelectedValue);

            FillAccountDetails(lstval);
        }

        private void chksubledger_CheckedChanged(object sender, EventArgs e)
        {
            if (chksubledger.Checked == true)
            {
                chksubledger.Text = "Yes";
            }
            else
            {
                chksubledger.Text = "No";


            }
        }

        private void chksalary_CheckedChanged(object sender, EventArgs e)
        {
            if (chksalary.Checked == true)
            {
                chksalary.Text = "Yes";
            }
            else
            {
                chksalary.Text = "No";
            }
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtaccountname.Text == string.Empty)
            {

                MessageBox.Show("Null Value Not Allowed ");
            }
            else
            {

                //c.datasave("tbl_account", c.myconn, this);
                //c.datasave ("insert into tbl_account values ('" +txtaccountname  + "','" + cmbaccountgroup.Text + "','" + txtaddress.Text + "','" + txtpanno.Text + "','" + txtopenbalance.Text + "')");
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    //SqlCommand command = new SqlCommand("select max(accode) from tbl_account where actype not in (dbo.GetAccountCode('F'),dbo.GetAccountCode('S'))", c.myconn);
                    SqlCommand command = new SqlCommand("select max(accode) from tbl_account ", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 10001;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(* ) from tbl_account where acname='" + txtaccountname.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        txtacno.Text = mstudentno.ToString();
                        c.insertdata("tbl_account", c.myconn, this);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }

                    if (chksubledger.Checked == true)
                    {
                        SqlTransaction trn;
                        trn = c.myconn.BeginTransaction();
                        c.connectsql("insert into tbl_subledger_account (subledgercode,accode) values (" + txtacno.Text + "," + valcmbparent.SelectedValue + ")", c.myconn, trn);
                        trn.Commit();
                        BtnSearch.Visible = false;
                    }
                    DesignForm.fromDesign1(this);

                }
                if (add_edit == false)
                {
                    c.updatedata("tbl_account", c.myconn, this, "accode", txtacno.Text);
                    SqlCommand command = new SqlCommand("select count(accode) from tbl_subledger_account where subledgercode=" + txtacno.Text, c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 10001;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar());
                    }
                    if (mstudentno != 0)
                    {
                        command = new SqlCommand("select count(accode) from tbl_subledger where subledgercode=" + txtacno.Text, c.myconn);
                        command.CommandTimeout = 120;
                        Int32 mstudentno1;
                        mstudentno1 = 0;
                        if (command.ExecuteScalar() != System.DBNull.Value)
                        {
                            mstudentno1 = Convert.ToInt32(command.ExecuteScalar());
                        }
                        if (chksubledger.Checked == false)
                        {
                            if (mstudentno1 != 0)
                            {
                                MessageBox.Show("Cannot Delete , Records already Exists in Sub Ledger file..");
                            }
                            else
                            {
                                c.getconnstr();
                                SqlTransaction trn;
                                trn = c.myconn.BeginTransaction();
                                c.connectsql("delete  from tbl_subledger_account where subledgercode=" + txtacno.Text, c.myconn, trn);
                                trn.Commit();
                            }
                        }
                    }

                    if (chksubledger.Checked == true)
                    {

                        SqlTransaction trn;
                        trn = c.myconn.BeginTransaction();
                        c.connectsql("delete  from tbl_subledger_account where subledgercode=" + txtacno.Text, c.myconn, trn);
                        c.connectsql("insert into tbl_subledger_account (subledgercode,accode) values ('" + txtacno.Text + "','" + valcmbparent.SelectedValue + "')", c.myconn, trn);
                        trn.Commit();
                    }
                    BtnSearch.Visible = false;
                    DesignForm.fromDesign1(this);
                }

                MessageBox.Show("Record Saved...", "School");
                c.FillListBox("select * from tbl_account", "acname", "accode", ref  listBox1);
                c.FillcomboBox("select * from tbl_account", "acname", "accode", ref  valcmbparent);
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
            }
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchByName gb = new SearchByName();
            //Library.FrmGetStudentBarcode gb = new FrmGetStudentBarcode();
            Connection.Flag = "A";
            gb.ShowDialog();
            FillAccountDetails(Connection.StudentBcode);
            txtaccountname.Focus();
        }

        private void FrmAccount_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

       
    }
}
