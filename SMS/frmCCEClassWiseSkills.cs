using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmCCEClassWiseSkills :UserControlBase
    {
        SqlDataReader DataReader;
        SqlTransaction Transaction;
        string CmdText;
        school1 c1 = new school1();
        public frmCCEClassWiseSkills()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmCCEClassWiseSkills_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Order By ClassOrder");
            cmbClass.SelectedIndex = -1;
            cmbClass.Text = "--Select--";
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            c1.GetMdiParent(this).ToggleSaveButton(false);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            try
            {
                if (Convert.ToBoolean(Connection.GetExecuteScalar("SELECT COUNT(*) FROM tbl_CCEClassSkill Where ClassCode='" + cmbClass.SelectedValue + "' And SessionCode='" + school.CurrentSessionCode + "'")))
                {
                    DataReader = Connection.GetDataReader("Select CONVERT(bit, Case When ISNULL(t.ID,-1)=-1 then 0 else 1 end) as [Select], s.SkillId, s.SkillName AS [Skills], t.SkillOrder AS [Order] From tbl_CCESkills s Left Join "+
                        " (Select  ID, SessionCode, ClassCode, SkillId, SkillOrder from  tbl_CCEClassSkill Where SessionCode='" + school.CurrentSessionCode + "' AND ClassCode='" + cmbClass.SelectedValue + "') t ON s.SkillId = t.SkillId Order By t.SkillOrder");
                    if (DataReader.HasRows)
                    {
                        while (DataReader.Read())
                        {
                            dataGridView1.Rows.Add(DataReader["Select"], DataReader["SkillId"],
                                DataReader["Skills"], DataReader["Order"]);
                        }
                    }
                    DataReader.Close();
                }
                else
                {
                    DataReader = Connection.GetDataReader("SELECT Convert(Bit,0) AS [Select], SkillId , SkillName AS [Skills],'' AS [Order] From tbl_CCESkills Where Status=1");
                    if (DataReader.HasRows)
                    {
                        while (DataReader.Read())
                        {
                            dataGridView1.Rows.Add(DataReader["Select"], DataReader["SkillId"],
                                DataReader["Skills"], DataReader["Order"]);
                        }
                    }
                    DataReader.Close();
                }

                if(dataGridView1.Rows.Count >0)
                { c1.GetMdiParent(this).ToggleSaveButton(true); }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                Transaction = Connection.GetMyConnection().BeginTransaction();
                try
                {
                    this.CmdText = "Delete From tbl_CCEClassSkill Where ClassCode='" + cmbClass.SelectedValue + "' And SessionCode='" + school.CurrentSessionCode + "'";
                    Connection.SqlTransection(this.CmdText, Connection.MyConnection, this.Transaction);
                    foreach (DataGridViewRow r in dataGridView1.Rows)
                    {
                        if (Convert.ToBoolean(r.Cells["Select"].Value))
                        {
                            this.CmdText = "INSERT INTO [tbl_CCEClassSkill]([SessionCode] ,[ClassCode] ,[SkillId] ,[SkillOrder])" +
                                " VALUES ('" + school.CurrentSessionCode + "','" + cmbClass.SelectedValue + "','" + r.Cells["SkillId"].Value + "','" + r.Cells["Order"].Value + "')";
                            Connection.SqlTransection(this.CmdText, Connection.MyConnection, this.Transaction);
                        }
                    }
                    this.Transaction.Commit();
                    MessageBox.Show("Record saved successfully", "Skills");
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    this.Transaction.Rollback();
                }
            }
        }

        private void frmCCEClassWiseSkills_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        //private void fillByToolStripButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        this.tbl_CCESkillsTableAdapter1.FillBy(this.lISDataSet.tbl_CCESkills);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Windows.Forms.Logger.LogError(ex); MessageBox.Show(ex.Message);
        //    }

        //}
    }
}
