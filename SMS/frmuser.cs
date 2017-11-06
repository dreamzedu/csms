using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmuser :UserControlBase
    {
        school1 c = new school1();
        Boolean add_edit = false;
        public frmuser()
        {
            InitializeComponent();     //DesignForm.fromDesign1(this);
            //DesignForm.fromDesign(this);DesignForm.fromDesign(this);
            Connection.SetUserControlTheme(this);
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            //DesignForm.fromDesign2(this);
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtpassword.Enabled = true;
            txtuser.Enabled = true;
            CmbUserRole.Enabled = true;
            txtuser.Focus(); 

        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            //DesignForm.fromDesign2(this);
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtpassword.Enabled = true;
            txtuser.Enabled = true;
            CmbUserRole.Enabled = true;
            txtuser.Focus(); 
        }
        
        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtuser .Text =="" || txtpassword .Text =="")
            {
                MessageBox.Show("User Name and Password values are mandatory ");
            }
            else
            {
                //c.datasave("tbl_school", c.myconn, this);
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select max(usercode) from tbl_user", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 1001;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(* ) from MasterUser where lower(userId)='" + txtuser.Text.Trim().ToLower() + "'", Connection.GetUserDbConnection());
                    
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {

                        txtusercode.Text = mstudentno.ToString();
                        txtpassword.Text = CryptorEngine.Encrypt(txtpassword.Text.Trim(), true);
                   //     txtuser.Text = CryptorEngine.Encrypt(txtuser.Text, true);
                        c.executesql("insert into MasterUser (userId, pwd,  masterUserId, isPrimaryUser, dbUserId, dbUserPwd, dbName, UserLevel, roleId, userCode ) values('" + txtuser.Text.Trim() + "','" + txtpassword.Text + "','" + school1.CurrentUser.UserId + "',false,'" + school1.CurrentUser.DbUserId + "','" + school1.CurrentUser.DbUserPwd + "','" + school1.CurrentUser.DbName + "'," + CmbUserRole.SelectedValue + "," + CmbUserRole.SelectedValue + ",'" + mstudentno.ToString() + "');", Connection.GetUserDbConnection());
                        c.insertdata("MasterUser", Connection.GetUserDbConnection(), this);
                        MessageBox.Show("Record Saved...", "");
                        //this.Hide();
                        DataSet ds2 = Connection.GetDataSet("Select Count(*) from tbl_Userauth ");
                        int ij = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
                        if (ij == 0)
                        {
                            MDIParent1 mdiForm = (MDIParent1)this.FindForm();
                            mdiForm.ShowUserControl(new frmuserauth(), "Set User Permissions");
                            //Form mainForm = new frmuserauth();
                            //mainForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }



                }
                if (add_edit == false)
                {
                    txtpassword.Text = CryptorEngine.Encrypt(txtpassword.Text, true);
                 //   txtuser.Text = CryptorEngine.Encrypt(txtuser.Text, true);
                    c.updatedata("MasterUser", Connection.GetUserDbConnection(), this, "usercode", txtusercode.Text);
                    MessageBox.Show("Record Saved...", "School");
                }
                
                c.FillListBox("select * from MasterUser where parentUserId='" + school1.CurrentUser.UserId + "'",Connection.GetUserDbConnection(), "userId", "usercode", ref  lstbxUser);
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
                //DesignForm.fromDesign1(this);
            }
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

        private void frmuser_Load(object sender, EventArgs e)
        {
            //DesignForm.fromDesign1(this); 
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            
            c.FillListBox("select * from MasterUser  where parentUserId='" + school1.CurrentUser.UserId + "' and UserCode<>1001 order by userId",Connection.GetUserDbConnection(), "userId", "usercode", ref  lstbxUser);  
           // c.FillListBox("select * from tbl_user", "username", "usercode", ref  listBox1);  

        }
        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void btnsave_Leave(object sender, EventArgs e)
        {
            
        }

       

        private void btnsave_Validating(object sender, CancelEventArgs e)
        {

        }

        private void txtuser_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= ',' && e.KeyChar <= '.') )
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Charcter value");
            }
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {
            Connection.ExecuteNonQuery("delete  from MasterUser where userId='" + txtuser.Text + "' ", Connection.GetUserDbConnection());
            MessageBox.Show("Record Deleted");
            c.FillListBox("select * from MasterUser  where parentUserId='" + school1.CurrentUser.UserId + "' UserCode<>1001 order by userId",Connection.GetUserDbConnection(), "userId", "usercode", ref  lstbxUser);
            c.cleartext(this);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(lstbxUser.SelectedValue);
            //string userlvl = Convert.ToString(listBox1.SelectedIndex);
            c.showdata("MasterUser", Connection.GetUserDbConnection(), this, "usercode", lstval);
           // txtuser.Text = CryptorEngine.Decrypt (txtuser.Text, true);
            txtpassword.Text = CryptorEngine.Decrypt(txtpassword.Text, true);
            //DataSet ds34 = Connection.GetDataSet("select UserLevel from tbl_user where usercode='1001'");

            //if (userlvl == "2")
            //{
            //   c.GetMdiParent(this).ToggleEditButton(false);
            //    btndelete.Enabled = false;
            //   c.GetMdiParent(this).ToggleSaveButton(false);
            //}
            //else
            //{
            //   c.GetMdiParent(this).ToggleEditButton(true);
            //    c.GetMdiParent(this).ToggleDeleteButton(true);
            //   c.GetMdiParent(this).ToggleSaveButton(true);
            //}


        }
         

    }
}
