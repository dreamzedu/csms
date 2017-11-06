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
    public partial class frmCCESkillsII : Form
    {
        SqlTransaction trn = null;
        static int SubSkillID;
        public frmCCESkillsII()
        {
            InitializeComponent();
        }


        private void AddSkills2_Load(object sender, EventArgs e)
        {
            frmCCESkillsII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));

            txtAttitudeTeacher.Enabled = false;
            txtAttitudeTeacGrade.Enabled = false;
            txtAttitudeTeacher.Enabled = false;
            btnSaveAttitudeTeacher.Visible = true;
            txtAttitudeSchMates.Enabled = false;
            txtAttitudeSchMatesGr.Enabled = false;
            btnSaveAttitudeSchMates.Visible = false;
            txtAttitudeProEnvGrade.Enabled = false;
            txtAttitudeSchProEnv.Enabled = false;
            btnSaveAttitudeProEnv.Visible = false;
            txtValueSkills.Enabled = false;
            txtValueSkillsGrade.Enabled = false;
            btnValueSkills.Visible = false;
            txtLiterarySkills.Enabled = false;
            txtLiterarySkillsGrade.Enabled = false;
            btnLiterarySkills.Visible = false;
            txtScientificSkills.Enabled = false;
            txtScientificSkillsGrade.Enabled = false;
            btnScientifisSkills.Visible = false;
            txtICT.Enabled = false;
            txtICTGrade.Enabled = false;
            btnICT.Visible = false;
            txtOrganizationalSkills.Enabled = false;
            txtOrganizationalSkillsGrade.Enabled = false;
            btnOrganizationalSkills.Visible = false;

        }

        private void btnAttitudeTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAttitudeTeacher.Text == "")
                {
                    MessageBox.Show("Please enter Attitude towards Teacher Skill.");

                }
                else
                {
                    frmCCESkillsII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdAttitudeTeacher.Tag + "','" + frmCCESkillsII.SubSkillID + "','" + txtAttitudeTeacher.Text.Trim() + "')", Connection.MyConnection, trn);
                    //Connection.SqlTransection("insert into tbl_AttitudeTeacher(AttitudeTeacher) values('" + txtAttitudeTeacher.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_AttitudeTeacher(AttitudeTeacher) values('" + txtAttitudeTeacher.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtAttitudeTeacher.Text = "";
                    txtAttitudeTeacGrade.Text = "";
                    txtAttitudeTeacher.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void rbdAttitudeTeacher_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdAttitudeTeacher.Checked == true)
            {
                txtAttitudeTeacGrade.Enabled = true;
                txtAttitudeTeacher.Enabled = true;
                btnSaveAttitudeTeacher.Visible = true;
                txtAttitudeSchMates.Enabled = false;
                txtAttitudeSchMatesGr.Enabled = false;
                btnSaveAttitudeSchMates.Visible = false;
                txtAttitudeProEnvGrade.Enabled = false;
                txtAttitudeSchProEnv.Enabled = false;
                btnSaveAttitudeProEnv.Visible = false;
                txtValueSkills.Enabled = false;
                txtValueSkillsGrade.Enabled = false;
                btnValueSkills.Visible = false;
                txtLiterarySkills.Enabled = false;
                txtLiterarySkillsGrade.Enabled = false;
                btnLiterarySkills.Visible = false;
                txtScientificSkills.Enabled = false;
                txtScientificSkillsGrade.Enabled = false;
                btnScientifisSkills.Visible = false;
                txtICT.Enabled = false;
                txtICTGrade.Enabled = false;
                btnICT.Visible = false;
                txtOrganizationalSkills.Enabled = false;
                txtOrganizationalSkillsGrade.Enabled = false;
                btnOrganizationalSkills.Visible = false;
                txtAttitudeTeacher.Focus();
            }
        }

        private void btnSaveAttitudeSchMates_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAttitudeSchMates.Text == "")
                {
                    MessageBox.Show("Please enter Attitude towards SchoolMates  Skill.");

                }
                else
                {
                    frmCCESkillsII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdAttitudesSchmates.Tag + "','" + frmCCESkillsII.SubSkillID + "','" + txtAttitudeSchMates.Text.Trim() + "')", Connection.MyConnection, trn);
                    // frmCCESkillsII.SubSkillID++;
                    //Connection.SqlTransection("insert into tbl_AttitudeSchoolMates(AttitudeSchoolMates) values('" + txtAttitudeSchMates.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    // Connection.AllPerform("insert into tbl_AttitudeSchoolMates(AttitudeSchoolMates) values('" + txtAttitudeSchMates.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtAttitudeSchMates.Text = "";
                    txtAttitudeSchMatesGr.Text = "";
                    txtAttitudeSchMates.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void rbdAttitudesSchmates_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdAttitudesSchmates.Checked == true)
            {
                txtAttitudeTeacGrade.Enabled = false;
                txtAttitudeTeacher.Enabled = false;
                btnSaveAttitudeTeacher.Visible = false;
                txtAttitudeSchMates.Enabled = true;
                txtAttitudeSchMatesGr.Enabled = true;
                btnSaveAttitudeSchMates.Visible = true;
                txtAttitudeProEnvGrade.Enabled = false;
                txtAttitudeSchProEnv.Enabled = false;
                btnSaveAttitudeProEnv.Visible = false;
                txtValueSkills.Enabled = false;
                txtValueSkillsGrade.Enabled = false;
                btnValueSkills.Visible = false;
                txtLiterarySkills.Enabled = false;
                txtLiterarySkillsGrade.Enabled = false;
                btnLiterarySkills.Visible = false;
                txtScientificSkills.Enabled = false;
                txtScientificSkillsGrade.Enabled = false;
                btnScientifisSkills.Visible = false;
                txtICT.Enabled = false;
                txtICTGrade.Enabled = false;
                btnICT.Visible = false;
                txtOrganizationalSkills.Enabled = false;
                txtOrganizationalSkillsGrade.Enabled = false;
                btnOrganizationalSkills.Visible = false;
                txtAttitudeSchMates.Focus();
            }
        }

        private void btnSaveAttitudeProEnv_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAttitudeSchProEnv.Text == "")
                {
                    MessageBox.Show("Please enter Attitude towards School programmes and Environment Skill.");

                }
                else
                {
                    frmCCESkillsII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdAttitudesSchProgEnv.Tag + "','" + frmCCESkillsII.SubSkillID + "','" + txtAttitudeSchProEnv.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsII.SubSkillID++;
                    //Connection.SqlTransection("insert into tbl_AttitudeSchoolProEnv(AttitudeSchProEnv) values('" + txtAttitudeSchProEnv.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_AttitudeSchoolProEnv(AttitudeSchProEnv) values('" + txtAttitudeSchProEnv.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtAttitudeSchProEnv.Text = "";
                    txtAttitudeProEnvGrade.Text = "";
                    txtAttitudeSchProEnv.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void rbdAttitudesSchProgEnv_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdAttitudesSchProgEnv.Checked == true)
            {
                txtAttitudeTeacGrade.Enabled = false;
                txtAttitudeTeacher.Enabled = false;
                btnSaveAttitudeTeacher.Visible = false;
                txtAttitudeSchMates.Enabled = false;
                txtAttitudeSchMatesGr.Enabled = false;
                btnSaveAttitudeSchMates.Visible = false;
                txtAttitudeProEnvGrade.Enabled = true;
                txtAttitudeSchProEnv.Enabled = true;
                btnSaveAttitudeProEnv.Visible = true;
                txtValueSkills.Enabled = false;
                txtValueSkillsGrade.Enabled = false;
                btnValueSkills.Visible = false;
                txtLiterarySkills.Enabled = false;
                txtLiterarySkillsGrade.Enabled = false;
                btnLiterarySkills.Visible = false;
                txtScientificSkills.Enabled = false;
                txtScientificSkillsGrade.Enabled = false;
                btnScientifisSkills.Visible = false;
                txtICT.Enabled = false;
                txtICTGrade.Enabled = false;
                btnICT.Visible = false;
                txtOrganizationalSkills.Enabled = false;
                txtOrganizationalSkillsGrade.Enabled = false;
                btnOrganizationalSkills.Visible = false;
                txtAttitudeSchProEnv.Focus();
            }
        }

        private void btnValueSkills_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValueSkills.Text == "")
                {
                    MessageBox.Show("Please enter Value Skill.");

                }
                else
                {
                    frmCCESkillsII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdValueSkills.Tag + "','" + frmCCESkillsII.SubSkillID + "','" + txtValueSkills.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsII.SubSkillID++;
                    //Connection.SqlTransection("insert into tbl_ValueSkills(valueSkills) values('" + txtValueSkills.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_ValueSkills(valueSkills) values('" + txtValueSkills.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtValueSkills.Text = "";
                    txtValueSkillsGrade.Text = "";
                    txtValueSkills.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void rbdValueSkills_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdValueSkills.Checked == true)
            {
                txtAttitudeTeacGrade.Enabled = false;
                txtAttitudeTeacher.Enabled = false;
                btnSaveAttitudeTeacher.Visible = false;
                txtAttitudeSchMates.Enabled = false;
                txtAttitudeSchMatesGr.Enabled = false;
                btnSaveAttitudeSchMates.Visible = false;
                txtAttitudeProEnvGrade.Enabled = false;
                txtAttitudeSchProEnv.Enabled = false;
                btnSaveAttitudeProEnv.Visible = false;
                txtValueSkills.Enabled = true;
                txtValueSkillsGrade.Enabled = true;
                btnValueSkills.Visible = true;
                txtLiterarySkills.Enabled = false;
                txtLiterarySkillsGrade.Enabled = false;
                btnLiterarySkills.Visible = false;
                txtScientificSkills.Enabled = false;
                txtScientificSkillsGrade.Enabled = false;
                btnScientifisSkills.Visible = false;
                txtICT.Enabled = false;
                txtICTGrade.Enabled = false;
                btnICT.Visible = false;
                txtOrganizationalSkills.Enabled = false;
                txtOrganizationalSkillsGrade.Enabled = false;
                btnOrganizationalSkills.Visible = false;
                txtValueSkills.Focus();
            }
        }

        private void btnICT_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtICT.Text == "")
                {
                    MessageBox.Show("Please enter Information Skill.");

                }
                else
                {
                    frmCCESkillsII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdInfoCommTech.Tag + "','" + frmCCESkillsII.SubSkillID + "','" + txtICT.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsII.SubSkillID++;
                    //Connection.SqlTransection("insert into tbl_ICTSkills(ICTSkills) values('" + txtICT.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_ICTSkills(ICTSkills) values('" + txtICT.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtICT.Text = "";
                    txtICTGrade.Text = "";
                    txtICT.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void rbdLiteraryCreativeSkills_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdLiteraryCreativeSkills.Checked == true)
            {
                txtAttitudeTeacGrade.Enabled = false;
                txtAttitudeTeacher.Enabled = false;
                btnSaveAttitudeTeacher.Visible = false;
                txtAttitudeSchMates.Enabled = false;
                txtAttitudeSchMatesGr.Enabled = false;
                btnSaveAttitudeSchMates.Visible = false;
                txtAttitudeProEnvGrade.Enabled = false;
                txtAttitudeSchProEnv.Enabled = false;
                btnSaveAttitudeProEnv.Visible = false;
                txtValueSkills.Enabled = false;
                txtValueSkillsGrade.Enabled = false;
                btnValueSkills.Visible = false;
                txtLiterarySkills.Enabled = true;
                txtLiterarySkillsGrade.Enabled = true;
                btnLiterarySkills.Visible = true;
                txtScientificSkills.Enabled = false;
                txtScientificSkillsGrade.Enabled = false;
                btnScientifisSkills.Visible = false;
                txtICT.Enabled = false;
                txtICTGrade.Enabled = false;
                btnICT.Visible = false;
                txtOrganizationalSkills.Enabled = false;
                txtOrganizationalSkillsGrade.Enabled = false;
                btnOrganizationalSkills.Visible = false;
                txtLiterarySkills.Focus();
            }
        }

        private void rbdScientificSkills_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdScientificSkills.Checked == true)
            {
                txtAttitudeTeacGrade.Enabled = false;
                txtAttitudeTeacher.Enabled = false;
                btnSaveAttitudeTeacher.Visible = false;
                txtAttitudeSchMates.Enabled = false;
                txtAttitudeSchMatesGr.Enabled = false;
                btnSaveAttitudeSchMates.Visible = false;
                txtAttitudeProEnvGrade.Enabled = false;
                txtAttitudeSchProEnv.Enabled = false;
                btnSaveAttitudeProEnv.Visible = false;
                txtValueSkills.Enabled = false;
                txtValueSkillsGrade.Enabled = false;
                btnValueSkills.Visible = false;
                txtLiterarySkills.Enabled = false;
                txtLiterarySkillsGrade.Enabled = false;
                btnLiterarySkills.Visible = false;
                txtScientificSkills.Enabled = true;
                txtScientificSkillsGrade.Enabled = true;
                btnScientifisSkills.Visible = true;
                txtICT.Enabled = false;
                txtICTGrade.Enabled = false;
                btnICT.Visible = false;
                txtOrganizationalSkills.Enabled = false;
                txtOrganizationalSkillsGrade.Enabled = false;
                btnOrganizationalSkills.Visible = false;
                txtScientificSkills.Focus();
            }
        }

        private void rbdInfoCommTech_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdInfoCommTech.Checked == true)
            {
                txtAttitudeTeacGrade.Enabled = false;
                txtAttitudeTeacher.Enabled = false;
                btnSaveAttitudeTeacher.Visible = false;
                txtAttitudeSchMates.Enabled = false;
                txtAttitudeSchMatesGr.Enabled = false;
                btnSaveAttitudeSchMates.Visible = false;
                txtAttitudeProEnvGrade.Enabled = false;
                txtAttitudeSchProEnv.Enabled = false;
                btnSaveAttitudeProEnv.Visible = false;
                txtValueSkills.Enabled = false;
                txtValueSkillsGrade.Enabled = false;
                btnValueSkills.Visible = false;
                txtLiterarySkills.Enabled = false;
                txtLiterarySkillsGrade.Enabled = false;
                btnLiterarySkills.Visible = false;
                txtScientificSkills.Enabled = false;
                txtScientificSkillsGrade.Enabled = false;
                btnScientifisSkills.Visible = false;
                txtICT.Enabled = true;
                txtICTGrade.Enabled = true;
                btnICT.Visible = true;
                txtOrganizationalSkills.Enabled = false;
                txtOrganizationalSkillsGrade.Enabled = false;
                btnOrganizationalSkills.Visible = false;
                txtICT.Focus();
            }

        }

        private void rbdOrganizationalSkills_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdOrganizationalSkills.Checked == true)
            {
                txtAttitudeTeacGrade.Enabled = false;
                txtAttitudeTeacher.Enabled = false;
                btnSaveAttitudeTeacher.Visible = false;
                txtAttitudeSchMates.Enabled = false;
                txtAttitudeSchMatesGr.Enabled = false;
                btnSaveAttitudeSchMates.Visible = false;
                txtAttitudeProEnvGrade.Enabled = false;
                txtAttitudeSchProEnv.Enabled = false;
                btnSaveAttitudeProEnv.Visible = false;
                txtValueSkills.Enabled = false;
                txtValueSkillsGrade.Enabled = false;
                btnValueSkills.Visible = false;
                txtLiterarySkills.Enabled = false;
                txtLiterarySkillsGrade.Enabled = false;
                btnLiterarySkills.Visible = false;
                txtScientificSkills.Enabled = false;
                txtScientificSkillsGrade.Enabled = false;
                btnScientifisSkills.Visible = false;
                txtICT.Enabled = false;
                txtICTGrade.Enabled = false;
                btnICT.Visible = false;
                txtOrganizationalSkills.Enabled = true;
                txtOrganizationalSkillsGrade.Enabled = true;
                btnOrganizationalSkills.Visible = true;
                txtOrganizationalSkills.Focus();
            }
        }

        private void btnLiterarySkills_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLiterarySkills.Text == "")
                {
                    MessageBox.Show("Please enter Literary Skill.");
                }
                else
                {
                    frmCCESkillsII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdLiteraryCreativeSkills.Tag + "','" + frmCCESkillsII.SubSkillID + "','" + txtLiterarySkills.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsII.SubSkillID++;
                    //Connection.SqlTransection("insert into tbl_LitrarySkills(LitrarySkills) values('" + txtLiterarySkills.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_LitrarySkills(LitrarySkills) values('" + txtLiterarySkills.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtLiterarySkills.Text = "";
                    txtLiterarySkillsGrade.Text = "";
                    txtLiterarySkills.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void btnScientifisSkills_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtScientificSkills.Text == "")
                {
                    MessageBox.Show("Please enter Scientific Skill.");

                }
                else
                {
                    frmCCESkillsII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdScientificSkills.Tag + "','" + frmCCESkillsII.SubSkillID + "','" + txtScientificSkills.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsII.SubSkillID++;
                    //Connection.SqlTransection("insert into tbl_ScientificSkills(ScientificSkills) values('" + txtScientificSkills.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_ScientificSkills(ScientificSkills) values('" + txtScientificSkills.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtScientificSkills.Text = "";
                    txtScientificSkillsGrade.Text = "";
                    txtScientificSkills.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void btnOrganizationalSkills_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtOrganizationalSkills.Text == "")
                {
                    MessageBox.Show("Please enter Organization Skill.");

                }
                else
                {

                    frmCCESkillsII.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdOrganizationalSkills .Tag + "','" + frmCCESkillsII.SubSkillID + "','" + txtOrganizationalSkills .Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsII.SubSkillID++;
                    //Connection.SqlTransection("insert into tbl_OrganizationalSkills(OrganizationalSkills) values('" + txtOrganizationalSkills.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_OrganizationalSkills(OrganizationalSkills) values('" + txtOrganizationalSkills.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtOrganizationalSkills.Text = "";
                    txtOrganizationalSkillsGrade.Text = "";
                    txtOrganizationalSkills.Focus();
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


            //Form CBSE = new CBSCMarksheet();
            //CBSE.StartPosition = FormStartPosition.CenterScreen;
            //CBSE.Show();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsIII();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsI();
            clsform.StartPosition = FormStartPosition.CenterScreen;
            clsform.Show();
            this.Close();
        }
    }
}
