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

    public partial class Frmsubject :UserControlBase
    {
        school1 c = new school1();
        Boolean add_edit = false;
        IParent parentForm;
     
        public Frmsubject()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        public Frmsubject(IParent parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

       
        public override void btnnew_Click(object sender, EventArgs e)
        {
            txtSubjectName.Text = "";
          // valcmbboard .Items.Add("-Select-");
            add_edit = true;
            c.cleartext(this);
            //parentForm.DisableAllEditMenuButtons();
            parentForm.AfterNewClick();
            txtSubjectName.Focus();
            cmbboard.SelectedIndex = 0;
        }

        private void Frmsubject_Load(object sender, EventArgs e)
        {
            if(parentForm == null)
            {
                parentForm = c.GetMdiParent(this);
            }
            //parentForm.EnableAllEditMenuButtons();
            parentForm.ToggleNewButton(true);
            parentForm.TogglePrintButton(true);
            
            c.getconnstr();
            c.FillListBox("Select subjectno,subjectname,SubjectCode ,SubjectOrder from tbl_subject Group By subjectno,subjectname,SubjectCode ,SubjectOrder Order By SubjectOrder ", "subjectname", "subjectno", ref  listBox1);
            cmbSubjectOrder.Items.Clear();
            for (int i = 1; i <= listBox1.Items.Count; i++)
                cmbSubjectOrder.Items.Add(i);
                    
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            //parentForm.EnableAllEditMenuButtons();
            parentForm.AfterCancelClick();
            parentForm.ToggleEditButton(false);
        }

        public override void btnedit_Click(object sender, EventArgs e)
        { 
            add_edit = false;
            //parentForm.DisableAllEditMenuButtons();
            parentForm.AfterEditClick();
        }

      

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                String lstval = Convert.ToString(listBox1.SelectedValue);
                DataSet ds67 = Connection.GetDataSet("select subjectname ,subjecttype,subjectno,SubjectCode,SubjectOrder from tbl_subject where subjectname = '" + listBox1.Text + "'");
                txtSubjectName.Text = ds67.Tables[0].Rows[0].ItemArray[0].ToString();
                cmbboard.Text = ds67.Tables[0].Rows[0].ItemArray[1].ToString();
                txtSubjectNo.Text = ds67.Tables[0].Rows[0].ItemArray[2].ToString();
                txtSubjectCode.Text = ds67.Tables[0].Rows[0].ItemArray[3].ToString();
                cmbSubjectOrder.Text = ds67.Tables[0].Rows[0].ItemArray[4].ToString();

                parentForm.ToggleEditButton(true);
                parentForm.ToggleDeleteButton(true);
                //c.showdata("tbl_subject", c.myconn, this, "subjectno", lstval);
            }
        }
        
        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (txtSubjectName.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");
            }
            else
            {
                if (add_edit == true)
                {
                  
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select distinct max(subjectno) from tbl_subject", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mstudentno;
                    mstudentno = 101;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    DataSet ds = Connection.GetDataSet("select count(*) from tbl_subject where subjectname='" + txtSubjectName.Text + "'");
                    int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (i == 0)
                    {
                       txtSubjectNo.Text = mstudentno.ToString();
                       Connection.AllPerform("insert into tbl_subject values ('" + txtSubjectNo.Text + "','" + txtSubjectName.Text.Trim() + "','" + cmbboard.Text + "','" + txtSubjectCode.Text.Trim() + "','" + cmbSubjectOrder.Text.Trim() + "')");
                       MessageBox.Show("Record Saved.", "School");
                     // c.insertdata("tbl_subject", c.myconn, this);
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }
                }
                if (add_edit == false)
                {

                    Connection.AllPerform("update tbl_subject set subjectname='" + txtSubjectName.Text.Trim() + "',subjecttype='" + cmbboard.Text.Trim() + "',SubjectCode='" + txtSubjectCode.Text.Trim() + "',SubjectOrder='" + cmbSubjectOrder.Text.Trim() + "' where subjectno='" + txtSubjectNo.Text + "'");
                        //c.updatedata("tbl_subject", c.myconn, this, "subjectno", txtsubjectcode.Text);
                        MessageBox.Show("Record Updated.", "School");
                }

                c.FillListBox("Select subjectno,subjectname,SubjectCode ,SubjectOrder from tbl_subject Group By subjectno,subjectname,SubjectCode ,SubjectOrder Order By SubjectOrder ", "subjectname", "subjectno", ref  listBox1);
                //parentForm.EnableAllEditMenuButtons();
                parentForm.AfterSaveClick();
                parentForm.ToggleEditButton(false);
            }
            //DesignForm.fromDesign1(this);
        }
       
         

        public override void btndelete_Click(object sender, EventArgs e)
        {
            int k = Connection.Login("SELECT     COUNT(*) AS Expr1  FROM         tbl_subwiseclass  WHERE     (subjectno = '" + txtSubjectNo.Text + "')   ");
            if (k > 0)
            {
                MessageBox.Show("You Cannot Delete Subject.");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    Connection.AllPerform("delete  from tbl_subject where subjectno='" + txtSubjectNo.Text + "' ");
                    Connection.AllPerform("Delete from tbl_subwiseclass where subjectno ='" + txtSubjectNo.Text + "'");
                    MessageBox.Show("Record Deleted.");
                    c.FillListBox("select distinct subjectno,subjectname from tbl_subject Order By subjectno", "subjectname", "subjectno", ref  listBox1);
                    DesignForm.fromClear(this);

                    parentForm.AfterDeleteClick();
                }
            }
          
            
        }

        private void txtSubjectName_Validating(object sender, CancelEventArgs e)
        {
           //ControlValidation.CheckalphasOnly(txtSubjectName, e);
        }

        private void Frmsubject_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);

        }    
    }
}