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
    public partial class frmCCESkillsI : Form
    {
        SqlTransaction trn = null;
        static int SubSkillID;
        public frmCCESkillsI()
        {
            InitializeComponent();
        }
        private void btnSaveThinkinskills_Click(object sender, EventArgs e)
        {
            try
            {
                if (string .IsNullOrEmpty (txtThinkingSkills.Text ))
                {
                    MessageBox.Show("Please enter Thinking Skill.");
                }
                else
                {
                    frmCCESkillsI.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdThinkingSkills.Tag + "','" + frmCCESkillsI.SubSkillID + "','" + txtThinkingSkills.Text + "')", Connection.MyConnection, trn);
                    // frmCCESkillsI.SubSkillID++;
                    // Connection.SqlTransection("Insert into tbl_ThinkingSkills(ThinkingSkills) values('" + txtThinkingSkills.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    // Connection.AllPerform("insert into tbl_ThinkingSkills(ThinkingSkills) values('" + txtThinkingSkills.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtThinkingSkills.Text = "";
                    txtGradeThinkingSills.Text = "";
                    txtThinkingSkills.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
            //this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //Form CBSE = new CBSCMarksheet();
            //CBSE.StartPosition = FormStartPosition.CenterScreen;
            //CBSE.Show();
        }
        void chield()
        {
            foreach (Form chieldform in MdiChildren)
            {
                chieldform.Close();
            }
        }

       

        private void frmThinkingSkills_Load(object sender, EventArgs e)
        {
            frmCCESkillsI.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    
            txtGradeThinkingSills.Enabled = false;
            txtThinkingSkills.Enabled = false;
            btnSaveThinkinskills.Visible = false;
            txtSocialSkills.Enabled = false;
            txtSocialSkillsGrade.Enabled = false;
            btnSaveThinkinskills.Visible = true;
            btnSaveSocialSkills.Visible = false;
            txtEmotionalSkills.Enabled = false;
            txtEmotionalSGrade.Enabled = false;
            btnSaveEmotionalS.Visible = false;
            txtWorkEducation.Enabled = false;
            txtWorkEduGrade.Enabled = false;
            btnSaveWorkEdu.Visible = false;
            txtVisualArts.Enabled = false;
            txtVisualArtsGrade.Enabled = false;
            btnVisualArts.Visible = false;
            txtPerformingArts.Enabled = false;
            txtPerformingAGrade.Enabled = false;
            btnPerformingArts.Visible = false;
        }

       

        private void rbdThinkingSkills_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbdThinkingSkills.Checked == true)
                {
                   
                    txtGradeThinkingSills.Enabled = true;
                    txtThinkingSkills.Enabled = true;
                    btnSaveThinkinskills.Visible =true;
                    txtSocialSkills.Enabled = false;
                    txtSocialSkillsGrade.Enabled = false;
                    btnSaveThinkinskills.Visible = false;
                    btnSaveSocialSkills.Visible = false;
                    txtEmotionalSGrade.Enabled = false;
                    txtEmotionalSkills.Enabled = false;
                    btnSaveEmotionalS.Visible = false;
                    btnSaveThinkinskills.Visible = true;
                    txtWorkEducation.Enabled = false;
                    txtWorkEduGrade.Enabled = false;
                    btnSaveWorkEdu.Visible = false;
                    txtVisualArts.Enabled = false;
                    txtVisualArtsGrade.Enabled = false;
                    btnVisualArts.Visible = false;
                    txtPerformingArts.Enabled = false;
                    txtPerformingAGrade.Enabled = false;
                    btnPerformingArts.Visible = false;
                    txtThinkingSkills.Focus();
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void rbdSocialSkills_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (rbdSocialSkills.Checked == true)
                {
                    
                    txtGradeThinkingSills.Enabled = false;
                    txtThinkingSkills.Enabled = false;
                    btnSaveThinkinskills.Visible = false;


                    txtSocialSkillsGrade.Enabled = true;
                    txtSocialSkills.Enabled = true;
                    btnSaveSocialSkills.Visible = true;
                    txtEmotionalSGrade.Enabled = false;
                    txtEmotionalSkills.Enabled = false;
                    btnSaveEmotionalS.Visible = false;
                    txtWorkEducation.Enabled = false;
                    txtWorkEduGrade.Enabled = false;
                    btnSaveWorkEdu.Visible = false;
                    txtVisualArts.Enabled = false;
                    txtVisualArtsGrade.Enabled = false;
                    btnVisualArts.Visible = false;
                    txtPerformingArts.Enabled = false;
                    txtPerformingAGrade.Enabled = false;
                    btnPerformingArts.Visible = false;
                    txtSocialSkills.Focus();
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnSaveSocialSkills_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSocialSkills.Text == "")
                {
                    MessageBox.Show("Please enter  Social Skill.");

                }
                else
                {

                    frmCCESkillsI.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdSocialSkills.Tag + "','" + frmCCESkillsI.SubSkillID + "','" + txtSocialSkills.Text.Trim () + "')", Connection.MyConnection, trn);
                    //frmCCESkillsI.SubSkillID++; 
                   // Connection.SqlTransection("insert into tbl_SocialSkills(SocialSkills) values('" + txtSocialSkills.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_SocialSkills(SocialSkills) values('" + txtSocialSkills.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtSocialSkillsGrade.Text = "";
                    txtSocialSkills.Text = "";
                    txtSocialSkills.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void btnSaveEmotionalS_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmotionalSkills.Text == "")
                {
                    MessageBox.Show("Please enter Emotional Skill.");

                }
                else
                {
                    frmCCESkillsI.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdEmotionalSkills.Tag + "','" + frmCCESkillsI.SubSkillID + "','" + txtEmotionalSkills.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsI.SubSkillID++; 
                   // Connection.SqlTransection("insert into tbl_EmotionalSkills(EmotionalSkills) values('" + txtEmotionalSkills.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_EmotionalSkills(EmotionalSkills) values('" + txtEmotionalSkills.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtEmotionalSGrade.Text = "";
                    txtEmotionalSkills.Text = "";
                    txtEmotionalSkills.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void rbdEmotionalSkills_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbdEmotionalSkills.Checked == true)
                {

                    txtGradeThinkingSills.Enabled = false;
                    txtThinkingSkills.Enabled = false;
                    btnSaveThinkinskills.Visible = false;
                    txtSocialSkillsGrade.Enabled = false;
                    txtSocialSkills.Enabled = false;
                    btnSaveSocialSkills.Visible = false;
                    txtEmotionalSGrade.Enabled = true;
                    txtEmotionalSkills.Enabled = true;
                    btnSaveEmotionalS.Visible = true;
                    txtWorkEducation.Enabled = false;
                    txtWorkEduGrade.Enabled = false;
                    btnSaveWorkEdu.Visible = false;
                    txtVisualArts.Enabled = false;
                    txtVisualArtsGrade.Enabled = false;
                    btnVisualArts.Visible = false;
                    txtPerformingArts.Enabled = false;
                    txtPerformingAGrade.Enabled = false;
                    btnPerformingArts.Visible = false;
                    txtEmotionalSkills.Focus();

                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnSaveWorkEdu_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtWorkEducation.Text == "")
                {
                    MessageBox.Show("Please enter Work Education.");

                }
                else
                {
                    frmCCESkillsI.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdWorkEducation .Tag + "','" + frmCCESkillsI.SubSkillID + "','" + txtWorkEducation.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsI.SubSkillID++; 
                    //Connection.SqlTransection("insert into tbl_WorkEducation(Workeducation) values('" + txtWorkEducation.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_WorkEducation(Workeducation) values('" + txtWorkEducation.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtWorkEducation.Text = "";
                    txtWorkEduGrade.Text = "";
                    txtWorkEducation.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }

        }

        private void rbdWorkEducation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbdWorkEducation.Checked == true)
                {

                    txtGradeThinkingSills.Enabled = false;
                    txtThinkingSkills.Enabled = false;
                    btnSaveThinkinskills.Visible = false;
                    txtSocialSkillsGrade.Enabled = false;
                    txtSocialSkills.Enabled = false;
                    btnSaveSocialSkills.Visible = false;
                    txtEmotionalSGrade.Enabled = false;
                    txtEmotionalSkills.Enabled = false;
                    btnSaveEmotionalS.Visible = false;
                    txtWorkEducation.Enabled = true;
                    txtWorkEduGrade.Enabled = true;
                    btnSaveWorkEdu.Visible = true;
                    txtVisualArts.Enabled = false;
                    txtVisualArtsGrade.Enabled = false;
                    btnVisualArts.Visible = false;
                    txtPerformingArts.Enabled = false;
                    txtPerformingAGrade.Enabled = false;
                    btnPerformingArts.Visible = false;
                    txtWorkEducation.Focus();
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnVisualArts_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtVisualArts.Text))
                {
                    MessageBox.Show("Please Enter Visual Art.");
                }
                else
                {
                    frmCCESkillsI.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdVisualArts.Tag + "','" + frmCCESkillsI.SubSkillID + "','" + txtVisualArts.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsI.SubSkillID++;
                    //Connection.SqlTransection("insert into tbl_VisualArts(VisualArts) values('" + txtVisualArts.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();

                    MessageBox.Show("Save Successfully.");
                    txtVisualArts.Text = "";
                    txtVisualArtsGrade.Text = "";
                    txtVisualArts.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void rbdVisualArts_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbdVisualArts.Checked == true)
                {

                    txtGradeThinkingSills.Enabled = false;
                    txtThinkingSkills.Enabled = false;
                    btnSaveThinkinskills.Visible = false;
                    txtSocialSkillsGrade.Enabled = false;
                    txtSocialSkills.Enabled = false;
                    btnSaveSocialSkills.Visible = false;
                    txtEmotionalSGrade.Enabled = false;
                    txtEmotionalSkills.Enabled = false;
                    btnSaveEmotionalS.Visible = false;
                    txtWorkEducation.Enabled = false;
                    txtWorkEduGrade.Enabled = false;
                    btnSaveWorkEdu.Visible = false;
                    txtVisualArts.Enabled = true;
                    txtVisualArtsGrade.Enabled = true;
                    btnVisualArts.Visible = true;
                    txtPerformingArts.Enabled = false;
                    txtPerformingAGrade.Enabled = false;
                    btnPerformingArts.Visible = false;
                    txtVisualArts.Focus();
                    

                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnPerformingArts_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPerformingArts.Text == "")
                {
                    MessageBox.Show("Please enter  Performing Arts.");

                }
                else
                {
                    frmCCESkillsI.SubSkillID = int.Parse(Connection.GetId("Select IsNull((Max(SubSkillId)+1),1001) From tbl_CCESubSkills"));
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Insert Into tbl_CCESubSkills( SkillId, SubSkillId, Discription)values('" + rbdPerformingArts.Tag + "','" + frmCCESkillsI.SubSkillID + "','" + txtPerformingArts.Text.Trim() + "')", Connection.MyConnection, trn);
                    //frmCCESkillsI.SubSkillID++; 
                    //Connection.SqlTransection("insert into tbl_PeformingArts(PeformingArts) values('" + txtPerformingArts.Text + "')", Connection.MyConnection, trn);
                    trn.Commit();
                    //Connection.AllPerform("insert into tbl_PeformingArts(PeformingArts) values('" + txtPerformingArts.Text + "')");
                    MessageBox.Show("Save Successfully.");
                    txtPerformingArts.Text = "";
                    txtPerformingAGrade.Text = "";
                    txtPerformingArts.Focus();
                }
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void rbdPerformingArts_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbdPerformingArts.Checked == true)
                {

                    txtGradeThinkingSills.Enabled = false;
                    txtThinkingSkills.Enabled = false;
                    btnSaveThinkinskills.Visible = false;
                    txtSocialSkillsGrade.Enabled = false;
                    txtSocialSkills.Enabled = false;
                    btnSaveSocialSkills.Visible = false;
                    txtEmotionalSGrade.Enabled = false;
                    txtEmotionalSkills.Enabled = false;
                    btnSaveEmotionalS.Visible = false;
                    txtWorkEducation.Enabled = false;
                    txtWorkEduGrade.Enabled = false;
                    btnSaveWorkEdu.Visible = false;
                    txtVisualArts.Enabled = false;
                    txtVisualArtsGrade.Enabled = false;
                    btnVisualArts.Visible = false;
                    txtPerformingArts.Enabled = true;
                    txtPerformingAGrade.Enabled = true;
                    btnPerformingArts.Visible = true;
                    txtPerformingArts.Focus();

                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsII (); 

            clsform.StartPosition = FormStartPosition.CenterScreen;

            this.Close();

            clsform.Show();
        }
    }
}
