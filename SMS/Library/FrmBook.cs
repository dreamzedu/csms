using System;
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
    public partial class FrmBook : UserControlBase
    {
        public FrmBook()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        school1 c = new school1();

        Boolean add_edit = false;

        private void BtnAddPublisher_Click(object sender, EventArgs e)
        {
            PlaceHolderForm frm = new PlaceHolderForm("Publisher Master");
            Library.FrmPublisher clsform = new Library.FrmPublisher(frm);
                      
            frm.AddChildControl(clsform);
            this.Enabled = false;
            frm.ShowDialog();
            this.Enabled = true;
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            //c.btndisable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
            txtbookname.Focus();
            DesignForm.fromDesign2(this);
        }


        public override void btnedit_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
              
            //c.btndisable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
            txtbookname.Focus();
            DesignForm.fromDesign2(this);
        }


        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtbookname.Text == "" || textBox2.Text == "" || textBox3.Text == "" || txtbookopenqty.Text == "" || textBox1.Text == "" || string.IsNullOrEmpty(valcmbpublisher.SelectedItem.ToString()) || string.IsNullOrEmpty(valcmbsubject.SelectedValue.ToString()))
            {

                MessageBox.Show("Please fill/select all the fields.");
            }
            else
            {
                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select max(bookno) from tbl_book", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 1001;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(* ) from tbl_book where bookname='" + txtbookname.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                        txtbookno.Text = mstudentno.ToString();
                        c.insertdata("tbl_book", c.myconn, this);
                        c.cleartext(this);
                        DesignForm.fromDesign1(this);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }

                }
                if (add_edit == false)
                {
                    c.updatedata("tbl_book", c.myconn, this, "bookno", txtbookno.Text);
                    c.cleartext(this);
                    DesignForm.fromDesign1(this);
                }

                MessageBox.Show("Record Saved...", "School");
                c.FillListBox("select * from tbl_book", "bookname", "bookno", ref  listBox1);
                //c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                c.GetMdiParent(this).ToggleEditButton(false);
                c.GetMdiParent(this).ToggleDeleteButton(false);
                //btnnew.Focus();

            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            //c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.GetMdiParent(this).ToggleDeleteButton(false);
            c.GetMdiParent(this).ToggleEditButton(false);
            DesignForm.fromDesign1(this);
        }

        private void FrmBook_Load(object sender, EventArgs e)
        {
            //c.btnenable(btnnew, btnedit, btndelete, btnsave, btncancel, btnprint, btnexit);
            
            c.GetMdiParent(this).ToggleNewButton(true);
            c.GetMdiParent(this).TogglePrintButton(true);
           
            c.getconnstr();
            c.FillcomboBox("select * from tbl_publisher order by publishar", "publishar", "publishcode", ref valcmbpublisher);
            c.FillcomboBox("select * from tbl_subject order by subjectname", "subjectname", "subjectno", ref valcmbsubject);
            c.FillListBox("select * from tbl_book", "bookname", "bookno", ref  listBox1);
            //btnnew.Focus();
            DesignForm.fromDesign1(this);
        }

        private void BtnAddSubject_Click(object sender, EventArgs e)
        {
            PlaceHolderForm frm = new PlaceHolderForm("Subject Master");
            Frmsubject clsform = new Frmsubject(frm);
            frm.AddChildControl(clsform);
            this.Enabled = false;
            frm.ShowDialog();
            this.Enabled = true;
        }

        private void BtnSRefresh_Click(object sender, EventArgs e)
        {
            c.FillcomboBox("select * from tbl_subject order by subjectname", "subjectname", "subjectno", ref valcmbsubject);
        }

        private void BtnPRefresh_Click(object sender, EventArgs e)
        {
            c.FillcomboBox("select * from tbl_publisher order by publishar", "publishar", "publishcode", ref valcmbpublisher);
        }

        private void txtbookname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Charcter value");
            }
        }

        private void textBox3_Validated(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.ToUpper();  
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Charcter value");
            }
        }

        private void txtbookopenqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Numeric  value");
            }
        }

       

        private void listBox1_Click(object sender, EventArgs e)
        {
            String lstval = Convert.ToString(listBox1.SelectedValue);
            c.showdata("tbl_book", c.myconn, this, "bookno", lstval);
            c.GetMdiParent(this).ToggleEditButton(true);
            c.GetMdiParent(this).ToggleDeleteButton(false);              
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Numeric  value");
            }
        }

       
        private void FrmBook_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
