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
    public partial class frmCCESkillsIII : Form
    {
        static int SubSkillID;
        public frmCCESkillsIII()
        {
            InitializeComponent();
        }

        private void rbdHealthPhy_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdHealthPhy.Checked == true)
            {
                txtHealthPhyEdu.Enabled = true;
                txtHealthPhyEduGrade.Enabled = true;
                btnHealthPhy.Visible = true;
                txtHealthPhyEdu.Focus();
            }
            else
            {
                txtHealthPhyEdu.Enabled = false;
                btnHealthPhy.Visible = false;
            }
        }

        private void FrmAddSkills3_Load(object sender, EventArgs e)
        {
            frmCCESkillsIII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
           
            txtHealthPhyEdu.Enabled = false;
            txtHealthPhyEduGrade.Enabled = false;
            btnHealthPhy.Visible = false;
            rbdHealthPhy.Checked = false;

        }

        private void btnHealthPhy_Click(object sender, EventArgs e)
        {
            SqlTransaction trn = null;
            try
            {
               
                if (txtHealthPhyEdu.Text == "")
                {
                    MessageBox.Show("Please enter Health & Physical Activities.");

                }
                else
                {
                    frmCCESkillsIII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdHealthPhy .Tag + "','" + frmCCESkillsIII.SubSkillID + "','" + txtHealthPhyEdu.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsIII.SubSkillID++; 
                    //Connection.SqlTransection("insert into tbl_HealthPhyEducation(HealthPhyEdu) values('" + txtHealthPhyEdu.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    // Connection.AllPerform("insert into tbl_HealthPhyEducation(HealthPhyEdu) values('" + txtHealthPhyEdu.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtHealthPhyEdu.Text = "";
                    txtHealthPhyEduGrade.Text = "";
                    txtHealthPhyEdu.Focus();
                }
            }
            catch 
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
