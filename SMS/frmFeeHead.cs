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
    public partial class framfeesetup :UserControlBase
    {
        school1 c = new school1();

        Boolean add_edit = false;
        public framfeesetup()
        {           
            InitializeComponent();    DesignForm.fromDesign1(this);
            Connection.SetUserControlTheme(this);
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtfeehead.Focus();
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
        }

        private void Framfeesetup_Load(object sender, EventArgs e)
        {
            ////////Refundable Fee
            ////////Regular Fee
            ////////Yearly Fee
            ////////Occasional Fee
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            
            c.FillListBox("select DISTINCT feecode,feeheads from tbl_feeheads order by feeheads", "feeheads", "feecode", ref listBox1);
            rdoDualSlip.Checked =Convert.ToBoolean(Connection.GetExecuteScalar("Select DualSlipType From tbl_FeeHeads")) ? true : false;
            cmbfeetype.SelectedIndex = 0;

        }

        private void txtfeehead_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= ',' && e.KeyChar <= '.')) // ||  || (e.KeyChar >= '/' && e.KeyChar <= '[') || (e.KeyChar >= ';' && e.KeyChar <= '"') || (e.KeyChar >= '{' && e.KeyChar <= '}') || (e.KeyChar >= '{' && e.KeyChar <= '}') || (e.KeyChar >= ' ' && e.KeyChar <= '-') || (e.KeyChar >= '}' && e.KeyChar <= '('))
            {
                e.Handled = true;

            }
           
           c.entertotab(e.KeyChar);
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtfeehead.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");
            }
            else
            {
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select DISTINCT max(feecode) from tbl_feeheads", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 101;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(*) from tbl_feeheads where feeheads='" + txtfeehead.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        txtclasscode.Text = mstudentno.ToString();
                        c.insertdata("tbl_feeheads", c.myconn, this);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }

                }
                if (add_edit == false)
                {
                    c.updatedata("tbl_feeheads", c.myconn, this, "feecode", txtclasscode.Text);
                }

                c.FillListBox("select DISTINCT feecode,feeheads from tbl_feeheads order by feeheads", "feeheads", "feecode", ref listBox1);
                MessageBox.Show("Record Saved...", "School");
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                Connection.AllPerform("Update tbl_feeheads SET DualSlipType='"+((rdoDualSlip.Checked)?true:false).ToString()+"'");
                
            }
            DesignForm.fromDesign1(this);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(listBox1.SelectedValue);
            c.showdata("tbl_feeheads", c.myconn, this, "feecode", lstval);
            string BusFee = txtclasscode.Text;
            if (BusFee == "101")
            {
               c.GetMdiParent(this).ToggleEditButton(false);
                c.GetMdiParent(this).ToggleEditButton(false);
               c.GetMdiParent(this).ToggleSaveButton(false);
            }
            else
            {
               c.GetMdiParent(this).ToggleEditButton(true);
                c.GetMdiParent(this).ToggleDeleteButton(true);
               c.GetMdiParent(this).ToggleSaveButton(true);
            }
          
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            string BusFee = txtclasscode.Text;
            if (BusFee == "101")
            {
               c.GetMdiParent(this).ToggleEditButton(false);
               c.GetMdiParent(this).ToggleEditButton(false);
               c.GetMdiParent(this).ToggleSaveButton(false);
            }
            else
            {
               c.GetMdiParent(this).ToggleEditButton(true);
               c.GetMdiParent(this).ToggleSaveButton(true);
                c.GetMdiParent(this).ToggleDeleteButton(true);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {
            int k = Connection.Login("select count(*) from tbl_classfeeregular where feecode='" + txtclasscode.Text + "'");
            if (k > 0)
            {
                MessageBox.Show("You Can Not Delete Fee Heads Record ...");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    Connection.AllPerform("delete  from tbl_feeheads where feeheads='" + txtfeehead.Text + "' ");
                    txtfeehead.Text = "";
                    MessageBox.Show("Record Deleted");
                    c.FillListBox("select DISTINCT feecode,feeheads from tbl_feeheads order by feeheads", "feeheads", "feecode", ref listBox1);

                    DesignForm.fromClear(this);
                }
            }
        }
         
        private void rdoDualSlip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDualSlip.Checked)
                rdoSingleSlip.Checked = false;
        }

        private void rdoSingleSlip_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSingleSlip.Checked)
                rdoDualSlip.Checked = false;
        }

        private void framfeesetup_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
