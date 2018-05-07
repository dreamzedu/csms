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
    public partial class frmtehsil : Form
    {
        school1 c = new school1();

        Boolean add_edit = false;
     
        public frmtehsil()
        {
            InitializeComponent();    DesignForm.fromDesign1(this);
        }

        public  void btnnew_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
             add_edit = true;
            c.cleartext(this);
            c.btndisable(btnnew,btnedit,btndelete,btnsave,btncancel,btnprint,null);
            txtsankayname.Focus();
        
        }

        private void frmsankay_Load(object sender, EventArgs e)
        {


            c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, null);
            c.getconnstr();
            
            c.FillcomboBox("select * from tbl_district order by district", "district", "distcode", ref valcmbdistrict);       
            c.FillListBox("select * from tbl_tehsil order by tehsil", "tehsil", "tehcode", ref  listBox1);
           
            c.returnconn(c.myconn);
            SqlCommand command = new SqlCommand("select max(tehcode) from tbl_tehsil", c.myconn);
            command.CommandTimeout = 120;
            Int32 mstudentno;
            mstudentno = 1001;
            if (command.ExecuteScalar() != System.DBNull.Value)
            {
                mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
            }
            
        }

        public void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, null);
            
        
        }

        public void btnedit_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);
             add_edit = false;
             c.btndisable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, null);
        
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void btnsave_Click(object sender, EventArgs e)
        {
            if (txtsankayname.Text == "")
            {

                MessageBox.Show("Null Value Not Allowed ");
            }
            else
            {
                //c.datasave("tbl_school", c.myconn, this);
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select max(tehcode) from tbl_tehsil", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 1001;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(* ) from tbl_tehsil where tehsil='" + txtsankayname.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        txtsankaycode.Text = mstudentno.ToString();
                        c.insertdata("tbl_tehsil", c.myconn, this);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }

                }
                if (add_edit == false)
                {
                    c.updatedata("tbl_tehsil", c.myconn, this, "tehcode", txtsankaycode.Text);
                }
                c.FillListBox("select * from tbl_tehsil order by tehsil", "tehsil", "tehcode", ref  listBox1);
           
                MessageBox.Show("Record Saved...", "School");
                c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, null);
                
            }
        }

       

      

        private void txtsankayname_KeyPress_1(object sender, KeyPressEventArgs e)
        {
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
            c.showdata("tbl_tehsil", c.myconn, this, "tehcode", lstval);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtsankayname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= ',' && e.KeyChar <= '.'))
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Charcter value");
            }
        }

        public void btndelete_Click(object sender, EventArgs e)
        {
            int k = Connection.Login("select count(*) from tbl_student where tehcode ='" + txtsankaycode.Text + "'");
            if (k > 0)
            {
                MessageBox.Show("You Can Not Delete Student Record ...");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    Connection.AllPerform("delete  from tbl_tehsil where tehsil='" + txtsankayname.Text + "' ");
                    MessageBox.Show("Record Deleted");
                    c.FillListBox("select * from tbl_tehsil order by tehsil", "tehsil", "tehcode", ref  listBox1);
                    DesignForm.fromClear(this);
                }
            }
            
        }

        private void frmtehsil_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
            Connection.ChangeFormBackColor(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}