﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.Library
{
    public partial class FrmPublisher : Form
    {
        public FrmPublisher()
        {
            InitializeComponent();
        }
        school c = new school();

        Boolean add_edit = false;
        private void btnnew_Click(object sender, EventArgs e)
        {
            add_edit = true;
            c.cleartext(this);
            c.btndisable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
            txtsankayname.Focus();
        }

        private void FrmPublisher_Load(object sender, EventArgs e)
        {
            c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
            c.getconnstr();
            btnnew.Focus();

            c.FillListBox("select * from tbl_publisher", "publishar", "publishcode", ref  listBox1);

            c.returnconn(c.myconn);
            SqlCommand command = new SqlCommand("select max(publishcode) from tbl_publisher", c.myconn);
            command.CommandTimeout = 120;
            Int32 mstudentno;
            mstudentno = 1001;
            if (command.ExecuteScalar() != System.DBNull.Value)
            {
                mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
            }
            
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.btndisable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
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
                    SqlCommand command = new SqlCommand("select max(publishcode) from tbl_publisher", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 1001;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(* ) from tbl_publisher where publishar='" + txtsankayname.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        txtsankaycode.Text = mstudentno.ToString();
                        c.insertdata("tbl_publisher", c.myconn, this);
                        c.FillListBox("select * from tbl_publisher", "publishar", "publishcode", ref  listBox1);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }

                }
                if (add_edit == false)
                {
                    c.updatedata("tbl_publisher", c.myconn, this, "publishcode", txtsankaycode.Text);
                    c.FillListBox("select * from tbl_publisher", "publishar", "publishcode", ref  listBox1);
                }
                MessageBox.Show("Record Saved...", "School");
                c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
                btnnew.Focus();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
            btnnew.Focus();
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(listBox1.SelectedValue);
            c.showdata("tbl_publisher", c.myconn, this, "publishcode", lstval);
        }

        private void txtsankayname_Validated(object sender, EventArgs e)
        {
            btnsave.Focus();
        }

        private void txtsankayname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Charcter value");
            }
            c.entertotab(e.KeyChar);
        }
    }
}
