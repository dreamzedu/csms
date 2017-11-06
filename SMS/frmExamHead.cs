using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmExamHead :UserControlBase
    {
        school1 c = new school1();
        Boolean add_edit = false;
        string ExamCode;

        public frmExamHead()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmExamHead_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            c.FillListBox("SELECT [SessionCode] ,[ExamCode] ,[ExamName] ,[ExamOrder] ,[MaximumMarks] FROM [tbl_ExamHead] Order By ExamOrder ", "ExamName", "ExamCode", ref  listBox1);
            cmbExamOrder.Items.Clear();
            for (int i = 1; i <= listBox1.Items.Count; i++)
                cmbExamOrder.Items.Add(i);
             
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            txtExamName.Clear();
            // valcmbboard .Items.Add("-Select-");
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtExamName.Focus();
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {      
            if (txtExamName.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");
            }
            else
            {
                if (add_edit == true)
                {
                    this.ExamCode = Connection.GetExecuteScalar("Select ISNULL(Max(ExamCode)+1,101) from tbl_ExamHead").ToString ();

                    int i = Convert.ToInt32(Connection.GetExecuteScalar("Select count(*) from tbl_ExamHead where ExamName='" + txtExamName.Text + "'"));
                    if (i == 0)
                    { 
                        Connection.AllPerform("INSERT INTO [tbl_ExamHead] ([SessionCode] ,[ExamCode] ,[ExamName] ,[ExamOrder], [MaximumMarks])   VALUES ('"+school .CurrentSessionCode +"', '"+ this.ExamCode +"', '" + txtExamName.Text + "','" + cmbExamOrder.Text.Trim() + "','"+txtMaximumMarks .Text +"')");
                        MessageBox.Show("Record Saved...", "School");
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }
                }
                if (add_edit == false)
                {
                    Connection.AllPerform("UPDATE  [tbl_ExamHead] "+
                        "  SET [ExamName] = '" + txtExamName.Text + "', " +
                        "      [ExamOrder] = '" + cmbExamOrder.Text + "', " +
                        "      [MaximumMarks] = '" + txtMaximumMarks.Text + "' " +
                        "  WHERE [ExamCode] = '" + this.ExamCode + "' AND [SessionCode]  = '" + school.CurrentSessionCode + "' ");
                    MessageBox.Show("Record Updated...", "School");
                }

                c.FillListBox("SELECT [SessionCode] ,[ExamCode] ,[ExamName] ,[ExamOrder] ,[MaximumMarks] FROM [tbl_ExamHead] Order By ExamOrder ", "ExamName", "ExamCode", ref  listBox1);
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
            }
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ExamCode = listBox1.SelectedValue.ToString ();
                DataTable dt = Connection.GetDataTable("SELECT [ExamName] ,[ExamOrder] ,[MaximumMarks] FROM [tbl_ExamHead] WHERE [ExamCode]='" + this.ExamCode + "'");
                if (dt.Rows.Count > 0)
                {
                    txtExamName.Text = dt.Rows[0]["ExamName"].ToString();
                    txtMaximumMarks.Text = dt.Rows[0]["MaximumMarks"].ToString();
                    cmbExamOrder.Text = dt.Rows[0]["ExamOrder"].ToString();
                }
            }
            catch { }

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
              
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
