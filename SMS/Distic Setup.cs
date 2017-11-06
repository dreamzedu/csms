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
    public partial class Distic_Setup : Form
    {
        school c = new school();

        Boolean add_edit = false;
        public Distic_Setup()
        {
            InitializeComponent();    DesignForm.fromDesign1(this);
            //Connection.SetUserControlTheme(this);
        }

        public void btnnew_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = true;
            c.cleartext(this);
            //c.GetMdiParent(this).DisableAllEditMenuButtons();
            c.btndisable(btnnew,btnedit,btndelete, btnsave,btncancel,btnprint,btnedit);
            txtsankayname.Focus();
        }

        public void btnedit_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
            add_edit = false;
            c.btndisable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnedit);
        }

        public void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsankayname.Text == "")
            {

                MessageBox.Show("Null Value Not Allowed ");
            }
            else
            {
                if (add_edit == true)
                {
                    DataSet ds = Connection.GetDataSet("select count(* ) from tbl_district where district='" + txtsankayname.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        Connection.AllPerform("insert into tbl_district values('" + txtsankayname.Text + "','" + valcmbdistrict.Text + "')");
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }
                    showList();
                }
                if (add_edit == false)
                {
                 Connection.AllPerform("UPDATE TBL_DISTRICT SET  district='"+txtsankayname .Text +"', statename='"+valcmbdistrict.Text+"'  where distcode='"+txtsankaycode .Text +"'");
                  //c.updatedata("tbl_district", c.myconn, this, "district", txtsankaycode.Text);
                }
               
                c.FillListBox("SELECT     distinct distcode, district  FROM         tbl_district  order by district", "district", "statename", ref  listBox1);
                MessageBox.Show("Record Saved...", "School");
                c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnedit);
                


            }
        }

        public void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnedit);
            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Distic_Setup_Load(object sender, EventArgs e)
        {
            c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnedit);
            c.getconnstr();
            
            showList();
           
            //c.FillListBox("select * from tbl_district order by district", "district", "distcode", ref  listBox1);

        }
        private void showList()
        { 
            c.FillListBox("SELECT     distinct distcode, district  FROM         tbl_district  order by district", "district","statename", ref  listBox1);
        }

        public void btndelete_Click(object sender, EventArgs e)
        {

            int k = Connection.Login("select count(*) from tbl_tehsil where distcode='" + txtsankaycode.Text + "'");
            if (k > 0)
            {
                MessageBox.Show("You Can Not Delete Student Record ...");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    Connection.AllPerform("Delete from tbl_district where distcode ='" + txtsankaycode.Text + "'");
                    Connection.AllPerform("Delete from tbl_tehsil where distcode='" + txtsankaycode.Text + "'");
                    MessageBox.Show("Record Deleted");
                    c.FillListBox("SELECT     distinct distcode, district  FROM  tbl_district  order by district", "district", "statename", ref  listBox1);
                    DesignForm.fromClear(this);
                }
            }
        }

        private void txtsankayname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Only Charcter Value Allowed..");
                e.Handled = true;
            }
           
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(listBox1.SelectedValue);
            DataSet ds1 = Connection.GetDataSet(" SELECT      district, statename,distcode   FROM         tbl_district where district='"+listBox1 .Text +"'  ");
            txtsankayname.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            valcmbdistrict.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            txtsankaycode.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();

        }

        private void txtsankayname_Validated(object sender, EventArgs e)
        {
            txtsankayname.Text = school.ToTitleCase(txtsankayname.Text);
        }

        private void Distic_Setup_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
            Connection.ChangeFormBackColor(this, e);
        }
    }
}
