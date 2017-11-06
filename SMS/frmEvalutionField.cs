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
    public partial class frmEvalutionField : Form
    {
        school c = new school();
        Boolean add_edit = false;
        string ActivityCode;
        public frmEvalutionField()
        {
            InitializeComponent();
        }

        public void btnnew_Click(object sender, EventArgs e)
        {
            txtQuality.Clear();
            cmbField.SelectedIndex = 0;
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtQuality.Focus();
        }

        public void btnedit_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
        }

        private void frmEvalutionField_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            c.FillListBox("SELECT [SessionCode] ,[ActivityID] ,[ActivityName] ,[ActivityField] ,[MaximumMarks] ,[ActivityOrder] FROM [tbl_ExamActivity] Order By ActivityOrder ", "ActivityName", "ActivityID", ref  listBox1);
            cmbExamOrder.Items.Clear();
            for (int i = 1; i <= listBox1.Items.Count; i++)
                cmbExamOrder.Items.Add(i);
             
        }

        public void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
              
        }

        public void btnsave_Click(object sender, EventArgs e)
        {
            if (txtQuality.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");
            }
            else
            {
                if (add_edit == true)
                {
                    this.ActivityCode = Connection.GetExecuteScalar("Select ISNULL(Max(ActivityID)+1,101) from tbl_ExamActivity").ToString();

                    int i = Convert.ToInt32(Connection.GetExecuteScalar("Select count(*) from tbl_ExamActivity where ActivityName='" + txtQuality.Text + "'"));
                    if (i == 0)
                    {
                        Connection.AllPerform("INSERT INTO [tbl_ExamActivity] ([SessionCode] ,[ActivityID] ,[ActivityName] ,[ActivityField] ,[MaximumMarks] ,[ActivityOrder]) VALUES " +
                            " ('" + school.CurrentSessionCode + "', '" + this.ActivityCode + "', '" + txtQuality.Text + "','" + cmbField .SelectedIndex + "','" + txtMaximumMarks.Text + "','" + cmbExamOrder.Text.Trim() + "')");
                        MessageBox.Show("Record Saved...", "School");
                    }
                    else
                    {
                        MessageBox.Show("Duplicate data not allowed");
                    }
                }
                if (add_edit == false)
                {
                    Connection.AllPerform("UPDATE  [tbl_ExamActivity] "+
                        " SET [ActivityName] = '"+txtQuality .Text +"' ,"+
                        " [ActivityField] = '"+cmbField.SelectedIndex +"' ,"+
                        " [MaximumMarks] = '"+ txtMaximumMarks .Text  +"' ,"+
                        " [ActivityOrder] = '" + cmbExamOrder.Text + "' ," +
                        " WHERE [ActivityID] = '" + this.ActivityCode + "' AND [SessionCode]  = '" + school.CurrentSessionCode + "' ");
                    MessageBox.Show("Record Updated...", "School");
                }

                c.FillListBox("SELECT [SessionCode] ,[ActivityID] ,[ActivityName] ,[ActivityField] ,[MaximumMarks] ,[ActivityOrder] FROM [tbl_ExamActivity] Order By ActivityOrder ", "ActivityName", "ActivityID", ref  listBox1);
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
