using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace SMS
{
    public partial class frmCBSCMarksheet :UserControlBase
    {
        static int StudentNo;
        static int ClassNo;
        bool b;
        double hindiFa1, hindiFa2, hindiFa3, hindiFa4, hindiSa1, hindiSa2, EngFa1, EngFa2, EngFa3, EngFa4, EngSa1, EngSa2, SanFa1, SanFa2, SanFa3, SanFa4, SanSa1, SanSa2, MFa1, MFa2, MFa3, MFa4, MSa1, MSa2, ScFa1, ScFa2, ScFa3, ScFa4, ScSa1, ScSa2, SSoFa1, SSoFa2, SSoFa3, SSoFa4, SSoSa1, SSoSa2, ComFa1, ComFa2, ComFa3, ComFa4, ComSa1, ComSa2;
        double HFa1Per, HFa2Per, HFa3Per, HFa4Per, HSa1Per, HSa2Per, totalHTerm1, totalHTerm2, EngFa1Per, EngFa2Per, EngFa3Per, EngFa4Per, EngSa1Per, EngSa2Per, totalEngTerm1, totalEngTerm2, SanFa1Per, SanFa2Per, SanFa3Per, SanFa4Per, SanSa1Per, SanSa2Per, totalSanTerm1, totalSanTerm2, MFa1Per, MFa2Per, MFa3Per, MFa4Per, MSa1Per, MSa2Per, totalMTerm1, totalMTerm2, ScFa1Per, ScFa2Per, ScFa3Per, ScFa4Per, ScSa1Per, ScSa2Per, totalScTerm1, totalScTerm2, SSoFa1Per, SSoFa2Per, SsoFa3Per, SSoFa4Per, SSoSa1Per, SSoSa2Per, totalSSoTerm1, totalSSoTerm2, ComFa1Per, ComFa2Per, ComFa3Per, ComFa4Per, ComSa1Per, ComSa2Per, totalComTerm1, totalComTerm2, HT1T2, ET1T2, SanT1T2, ScT1T2, SSoT1T2, MT1T2, ComT1T2, HSa1Sa2, ESa1Sa2, MSa1Sa2, ScSa1Sa2, SSoSa1Sa2, ComSa1Sa2, SanSa1Sa2;
        public frmCBSCMarksheet()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void btnTSAdd_Click(object sender, EventArgs e)
        {   
            Form clsform = new frmCCESkillsI();
            
            clsform.StartPosition = FormStartPosition.CenterScreen;
           
            clsform.Show();
            try
            {




                DataSet ds1 = Connection.GetDataSet("select distinct ThinkingSkills from tbl_ThinkingSkills Group By ThinkingSkills");
                chkThinkingSkills.Items.Clear();
                for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds1.Tables[0].Rows[i];
                    chkThinkingSkills.Items.Add(dr[0].ToString());

                }
                
            }
            catch(Exception ex){Logger.LogError(ex); }
            
        }


        private void ControlEnable(bool b)
        {
            tabControl1.Enabled = b;
            txtScholarNo.Enabled = b;
            txtStudentName.Enabled = b;
            txtFatherName.Enabled = b;
            txtClass.Enabled = b;
            btnFinalSave.Enabled = b;
            btnEdit.Enabled = b;
            btnDelete.Enabled = b;
        }
       


        private void CBSCMarksheet_Load(object sender, EventArgs e)
        {
            //txtHindiFa1.Text = "0";
            //txtHindiFa2.Text = "0";
            //txtHindiFa3.Text = "0";
            //txtHindiFa4.Text = "0";
            //txtHindiSa1.Text = "0";
            //txtHindiSa2.Text = "0";
            //txtEnglishFa1.Text = "0";
            //txtEnglishFa2.Text = "0";
            //txtEnglishFa3.Text = "0";
            //txtEnglishFa4.Text = "0";
            //txtEnglishSa1.Text = "0";
            //txtEnglishSA2.Text = "0";
            //txtSanskritFa1.Text = "0";
            //txtSanskritFa2.Text = "0";
            //txtSanskritFa3.Text = "0";
            //txtSanskritFa4.Text = "0";
            //txtSanskritSa1.Text = "0";
            //txtSanskritSa2.Text = "0";
            //txtScienceFa1.Text = "0";
            //txtScienceFa2.Text = "0";
            //txtScienceFa3.Text = "0";
            //txtScienceFa4.Text = "0";
            //txtScienceSa1.Text = "0";
            //txtScienceSa2.Text = "0";
            //txtSocialScienceFa1.Text = "0";
            //txtSocialScienceFa2.Text = "0";
            //txtSocialScienceFa3.Text = "0";
            //txtSocialScienceFa4.Text = "0";
            //txtSocialScienceSa1.Text = "0";
            //txtSocialScienceSa2.Text = "0";
            //txtComputerFa1.Text = "0";
            //txtComputerFa2.Text = "0";
            //txtComputerFa3.Text = "0";
            //txtComputerFa4.Text = "0";
            //txtComputerSa1.Text = "0";
            //txtComputerSa2.Text = "0";
            //txtMathematicsFa1.Text = "0";
            //txtMathematicsFa2.Text = "0";
            //txtMathematicsFa3.Text = "0";
            //txtMathematicsFa4.Text = "0";
            //txtMathematicsSa1.Text = "0";
            //txtMathematicsSA2.Text = "0";
            //txtHinFa1FA2Fa3Fa4.Text = "0";
            //txtHinSA1SA2.Text = "0";
            //txtEngFa1Fa2FA3FA4.Text = "0";
            //txtEngSa1SA2.Text = "0";
            //txtMathsFa1Fa2FA3FA4.Text = "0";
            //txtMathsSa1Sa2.Text = "0";
            //txtSansFa1Fa2FA3FA4.Text = "0";
            //txtSansSa1SA2.Text = "0";
            //txtScieFa1Fa2Fa3FA4.Text = "0";
            //txtScieSa1Sa2.Text = "0";
            //txtSScieFa1Fa2Fa3fa4.Text = "0";
            //txtSScieSa1Sa2.Text = "0";
            //txtComFA1Fa2FA3FA4.Text = "0";
            //txtComSa1Sa2.Text = "0";

            foreach (Control cl in this.Controls)
            {
                if (cl is TabControl)
                {
                    int i = 0;
                    foreach (TabPage tpg in tabControl1.TabPages)
                    {
                        foreach (Control tcl in tabControl1.TabPages[i].Controls)
                        {
                            if (tcl is CheckedListBox)
                            {
                                CheckedListBox ChkLstBx = (CheckedListBox)tcl;
                                Connection.FillCheckedListBox(ChkLstBx, "SELECT tbl_CCESubSkills.SubSkillId, tbl_CCESubSkills.Discription FROM tbl_CCESkills " +
                                  "  INNER JOIN tbl_CCESubSkills ON tbl_CCESkills.SkillId = tbl_CCESubSkills.SkillId WHERE (tbl_CCESkills.SkillId = '" + ChkLstBx.Tag + "')");
                            }
                        }
                        i++;
                    }

                }
            }
            this.ControlEnable(false);

         

          //  DataSetData();
           
        }

        public void DataSetData()
        {
            //For fillCheckedListbox Data
            try
            {
                DataSet ds = Connection.GetDataSet("select distinct ThinkingSkills from tbl_ThinkingSkills Group By ThinkingSkills");
                //cmbThinkingSkills.DataSource = ds.Tables[0];
                //cmbThinkingSkills.DisplayMember = ds.Tables[0].Columns["ThinkingSkills"].ToString();
                //cmbThinkingSkills.ValueMember = ds.Tables[0].Columns["ThinkingSId"].ToString();
                chkThinkingSkills.Items.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataRow dr = ds.Tables[0].Rows[i];
                    chkThinkingSkills.Items.Add(dr[0].ToString());

                }
                chkSocialList.Items.Clear();
                DataSet ds1 = Connection.GetDataSet("select distinct SocialSkills from tbl_SocialSkills Group By SocialSkills ");
              
                for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                {
                    DataRow dr1 = ds1.Tables[0].Rows[j];
                    chkSocialList.Items.Add(dr1[0].ToString());
                }

                chkEmotionalSkillslist.Items.Clear();
                DataSet ds2 = Connection.GetDataSet("select distinct EmotionalSkills from tbl_EmotionalSkills Group By EmotionalSkills");
                for (int k = 0; k < ds2.Tables[0].Rows.Count; k++)
                {
                    DataRow dr2 = ds2.Tables[0].Rows[k];
                    chkEmotionalSkillslist.Items.Add(dr2[0].ToString());
                }

               
                DataSet ds3 = Connection.GetDataSet("select distinct Workeducation from tbl_WorkEducation Group By Workeducation");
                chkWorkEduList.Items.Clear();
                for (int l = 0; l < ds3.Tables[0].Rows.Count; l++)
                {
                    DataRow dr3 = ds3.Tables[0].Rows[l];
                    chkWorkEduList.Items.Add(dr3[0].ToString());
                }

               
                DataSet ds4 = Connection.GetDataSet("select distinct VisualArts from tbl_VisualArts Group By VisualArts");
                chkVisualArtlist.Items.Clear();
                for (int m = 0; m < ds4.Tables[0].Rows.Count; m++)
                {
                    DataRow dr4 = ds4.Tables[0].Rows[m];
                    chkVisualArtlist.Items.Add(dr4[0].ToString());
                }

                DataSet ds5 = Connection.GetDataSet("select distinct PeformingArts from tbl_PeformingArts Group By PeformingArts");

                chkPerformingArtList.Items.Clear();
                for (int f = 0; f < ds5.Tables[0].Rows.Count; f++)
                {
                    DataRow dr5 = ds5.Tables[0].Rows[f];
                    chkPerformingArtList.Items.Add(dr5[0].ToString());
                }

                DataSet ds6 = Connection.GetDataSet("select distinct AttitudeTeacher from tbl_AttitudeTeacher Group By AttitudeTeacher");
                chkAttitudeTeacherList.Items.Clear();
                for (int a = 0; a < ds6.Tables[0].Rows.Count; a++)
                {
                    DataRow dr6 = ds6.Tables[0].Rows[a];
                    chkAttitudeTeacherList.Items.Add(dr6[0].ToString());
                }
                DataSet ds7 = Connection.GetDataSet("select distinct AttitudeSchoolMates from tbl_AttitudeSchoolMates Group By AttitudeSchoolMates");
                chkAttitudeSchoolmatesList.Items.Clear();
               
                for (int s = 0; s < ds7.Tables[0].Rows.Count; s++)
                {
                    DataRow dr7 = ds7.Tables[0].Rows[s];
                    chkAttitudeSchoolmatesList.Items.Add(dr7[0].ToString());
                }
                
                DataSet ds8 = Connection.GetDataSet("select distinct AttitudeSchProEnv from tbl_AttitudeSchoolProEnv");
                chkattitudeschprolist.Items.Clear();
                for (int d = 0; d < ds8.Tables[0].Rows.Count; d++)
                {
                    DataRow dr8 = ds8.Tables[0].Rows[d];
                    chkattitudeschprolist.Items.Add(dr8[0].ToString());
                }
                DataSet ds9 = Connection.GetDataSet("select distinct ValueSkills from tbl_ValueSkills");
                chkValueSkillsList.Items.Clear();
                for (int r = 0; r < ds9.Tables[0].Rows.Count; r++)
                {
                    DataRow dr9 = ds9.Tables[0].Rows[r];
                    chkValueSkillsList.Items.Add(dr9[0].ToString());
                }
                DataSet ds10 = Connection.GetDataSet("select distinct LitrarySkills from tbl_LitrarySkills");

                chkLiteraryList.Items.Clear();
                for (int e = 0; e < ds10.Tables[0].Rows.Count; e++)
                {
                    DataRow dr10 = ds10.Tables[0].Rows[e];
                    chkLiteraryList.Items.Add(dr10[0].ToString());
                }
                DataSet ds11 = Connection.GetDataSet("select distinct ScientificSkills from tbl_ScientificSkills");

                chkScientificSkillsList.Items.Clear();
                for (int w = 0; w < ds11.Tables[0].Rows.Count; w++)
                {
                    DataRow dr11 = ds11.Tables[0].Rows[w];
                    chkScientificSkillsList.Items.Add(dr11[0].ToString());
                }
                DataSet ds12 = Connection.GetDataSet("select distinct OrganizationalSkills from tbl_OrganizationalSkills");
                chkOrganizationSList.Items.Clear();
                for (int t = 0; t < ds12.Tables[0].Rows.Count; t++)
                {
                    DataRow dr12 = ds12.Tables[0].Rows[t];
                    chkOrganizationSList.Items.Add(dr12[0].ToString());
                }
                DataSet ds13 = Connection.GetDataSet("select distinct ICTSkills from tbl_ICTSkills");
                chkInformationCommList.Items.Clear();
                for (int h = 0; h < ds13.Tables[0].Rows.Count; h++)
                {
                    DataRow dr13 = ds13.Tables[0].Rows[h];
                    chkInformationCommList.Items.Add(dr13[0].ToString());
                }
                DataSet ds14 = Connection.GetDataSet("select distinct HealthPhyEdu from tbl_HealthPhyEducation");

                chkHealthPhyList.Items.Clear();
                for (int y = 0; y < ds14.Tables[0].Rows.Count; y++)
                {
                    DataRow dr14 = ds14.Tables[0].Rows[y];
                    chkHealthPhyList.Items.Add(dr14[0].ToString());
                }


            }
            catch(Exception ex){Logger.LogError(ex); }
        } 

        private void btnSaveSocialSkills_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsI();

            clsform.StartPosition = FormStartPosition.CenterScreen;
           
            clsform.Show();
            try
            {
                DataSet ds = Connection.GetDataSet("select distinct SocialSkills from tbl_SocialSkills");
                
                    //cmbSocialSkills.DataSource = ds.Tables[0];
                    //cmbSocialSkills.DisplayMember = ds.Tables[0].Columns["SocialSkills"].ToString();
                    //cmbSocialSkills.ValueMember = ds.Tables[0].Columns["SocialSId"].ToString();
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        DataRow dr = ds.Tables[0].Rows[j];
                        chkSocialList.Items.Add(dr[0].ToString());
                    }
               
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnEmotionalSkills_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsI();

            clsform.StartPosition = FormStartPosition.CenterScreen;
           
            clsform.Show();
            try
            {
                DataSet ds = Connection.GetDataSet("select distinct EmotionalSkills from tbl_EmotionalSkills");
               
                //cmbEmotionalSkills.DataSource = ds.Tables[0];
                //cmbEmotionalSkills.DisplayMember = ds.Tables[0].Columns["EmotionalSkills"].ToString();
                //cmbEmotionalSkills.ValueMember = ds.Tables[0].Columns["EmotionalSId"].ToString();
                chkEmotionalSkillslist.Items.Clear();
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds.Tables[0].Rows[j];
                    chkEmotionalSkillslist.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnWorkeducation_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsI();

            clsform.StartPosition = FormStartPosition.CenterScreen;
           
            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct Workeducation from tbl_WorkEducation");
                chkWorkEduList.Items.Clear();
              
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkWorkEduList.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnPerformingArts_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsI();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct PeformingArts from tbl_PeformingArts");

                chkPerformingArtList.Items.Clear();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkPerformingArtList.Items.Add(dr[0].ToString());
                }

            }
            catch(Exception ex){Logger.LogError(ex); }

        }

        private void btnVisualArts_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsI();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct VisualArts from tbl_VisualArts");
                chkVisualArtlist.Items.Clear();
                //cmbVisualArts.DataSource = ds2.Tables[0];
                //cmbVisualArts.DisplayMember = ds2.Tables[0].Columns["VisualArts"].ToString();
                //cmbVisualArts.ValueMember = ds2.Tables[0].Columns["VisualAId"].ToString();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkVisualArtlist.Items.Add(dr[0].ToString());
                }

            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnAttitudeTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                
                Form clsform = new frmCCESkillsII();

                clsform.StartPosition = FormStartPosition.CenterScreen;

                clsform.Show();

                DataSet ds3 = Connection.GetDataSet("select distinct AttitudeTeacher from tbl_AttitudeTeacher");

                //cmbAttitudeTeacher.DataSource = ds3.Tables[0];
                //cmbAttitudeTeacher.DisplayMember = ds3.Tables[0].Columns["AttitudeTeacher"].ToString();
                //cmbAttitudeTeacher.ValueMember = ds3.Tables[0].Columns["AttitudeTeachId"].ToString();
                chkAttitudeTeacherList.Items.Clear();
                for (int j = 0; j < ds3.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds3.Tables[0].Rows[j];
                    chkAttitudeTeacherList.Items.Add(dr[0].ToString());
                }
            }
            catch{}
            
        }

        private void btnAttitudeSchMates_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsII();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct AttitudeSchoolMates from tbl_AttitudeSchoolMates");

                //cmbAttitudeSchoolMates.DataSource = ds2.Tables[0];
                //cmbAttitudeSchoolMates.DisplayMember = ds2.Tables[0].Columns["AttitudeSchoolMates"].ToString();
                //cmbAttitudeSchoolMates.ValueMember = ds2.Tables[0].Columns["AttitudeSchMatesId"].ToString();
                chkAttitudeSchoolmatesList.Items.Clear();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkAttitudeSchoolmatesList.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnAttitudeSchProgrammes_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsII();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct AttitudeSchProEnv from tbl_AttitudeSchoolProEnv");

                //cmbAttitudeSchProgram.DataSource = ds2.Tables[0];
                //cmbAttitudeSchProgram.DisplayMember = ds2.Tables[0].Columns["AttitudeSchProEnv"].ToString();
                //cmbAttitudeSchProgram.ValueMember = ds2.Tables[0].Columns["AttitudeSchProEnvId"].ToString();
                chkattitudeschprolist.Items.Clear();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkattitudeschprolist.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex){Logger.LogError(ex); }

        }

        private void btnValueSkills_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsII();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct ValueSkills from tbl_ValueSkills");

                //cmbValueSkills.DataSource = ds2.Tables[0];
                //cmbValueSkills.DisplayMember = ds2.Tables[0].Columns["ValueSkills"].ToString();
                //cmbValueSkills.ValueMember = ds2.Tables[0].Columns["ValueSkillsId"].ToString();

                chkValueSkillsList.Items.Clear();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkValueSkillsList.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnLiterarySkills_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsII();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct LitrarySkills from tbl_LitrarySkills");

                //cmbLiterarySkills.DataSource = ds2.Tables[0];
                //cmbLiterarySkills.DisplayMember = ds2.Tables[0].Columns["LitrarySkills"].ToString();
                //cmbLiterarySkills.ValueMember = ds2.Tables[0].Columns["LitrarySkillsId"].ToString();

                chkLiteraryList.Items.Clear();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkLiteraryList.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnScientificSkills_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsII();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct ScientificSkills from tbl_ScientificSkills");

                //cmbScientificSkills.DataSource = ds2.Tables[0];
                //cmbScientificSkills.DisplayMember = ds2.Tables[0].Columns["ScientificSkills"].ToString();
                //cmbScientificSkills.ValueMember = ds2.Tables[0].Columns["ScientificSId"].ToString();
                chkScientificSkillsList.Items.Clear();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkScientificSkillsList.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnOrganizationalSkills_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsII();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct OrganizationalSkills from tbl_OrganizationalSkills");

                //cmbOrganizationalSkills.DataSource = ds2.Tables[0];
                //cmbOrganizationalSkills.DisplayMember = ds2.Tables[0].Columns["OrganizationalSkills"].ToString();
                //cmbOrganizationalSkills.ValueMember = ds2.Tables[0].Columns["OrganizationalSId"].ToString();
                chkOrganizationSList.Items.Clear();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkOrganizationSList.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnInfoTechSkills_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsII();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct ICTSkills from tbl_ICTSkills");

                //cmbInformationSkills.DataSource = ds2.Tables[0];
                //cmbInformationSkills.DisplayMember = ds2.Tables[0].Columns["ICTSkills"].ToString();
                //cmbInformationSkills.ValueMember = ds2.Tables[0].Columns["ICTSkillsId"].ToString();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkInformationCommList.Items.Add(dr[0].ToString());
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnHealthPhyEdu_Click(object sender, EventArgs e)
        {
            Form clsform = new frmCCESkillsIII();

            clsform.StartPosition = FormStartPosition.CenterScreen;

            clsform.Show();
            try
            {
                DataSet ds2 = Connection.GetDataSet("select distinct HealthPhyEdu from tbl_HealthPhyEducation");

                //cmbHealthPhyEdu.DataSource = ds2.Tables[0];
                //cmbHealthPhyEdu.DisplayMember = ds2.Tables[0].Columns["HealthPhyEdu"].ToString();
                //cmbHealthPhyEdu.ValueMember = ds2.Tables[0].Columns["HealthPhyEduId"].ToString();
                for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                {
                    DataRow dr = ds2.Tables[0].Rows[j];
                    chkHealthPhyList.Items.Add(dr[0].ToString());
                }
                
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void btnFinalSave_Click(object sender, EventArgs e)
        {
            SqlTransaction trn = null;
            try
            {
                if (!string.IsNullOrEmpty(txtScholarNo.Text) && !string.IsNullOrEmpty(txtStudentName.Text) &&
                    !string.IsNullOrEmpty(txtFatherName.Text) && !string.IsNullOrEmpty(txtClass.Text))
                {                
                    trn = Connection.GetMyConnection().BeginTransaction();
                    if (dataGridView1.RowCount > 0)
                    {
                        int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_CCEStudentMarks"));

                        foreach (DataGridViewRow dr in dataGridView1.Rows)
                        {
                            Connection.SqlTransection("Insert InTo tbl_CCEStudentMarks(CCEID, StudentNo, ClassNo, SubjectNo,SessionCode, FA1, FA2, SA1, FA3, FA4, SA2, FA1FA2FA3FA4G, SA1SA2G, FinalGrade,GradePoint) Values(" +
                              "'" + CCEID + "','" + frmCBSCMarksheet.StudentNo + "','" + frmCBSCMarksheet.ClassNo + "','" + dr.Cells["SubjectCode"].Value + "','" + school.CurrentSessionCode + "','" + dr.Cells["FA1"].Value + "' " +
                              ",'" + dr.Cells["FA2"].Value + "','" + dr.Cells["SA1"].Value + "','" + dr.Cells["FA3"].Value + "','" + dr.Cells["FA4"].Value + "','" + dr.Cells["SA2"].Value + "','" + dr.Cells["FA1FA2FA3FA4G"].Value + "'" +
                              ",'" + dr.Cells["SA1SA2G"].Value + "','" + dr.Cells["FinalGrade"].Value + "','" + dr.Cells["GradePoint"].Value + "')", Connection.MyConnection, trn);
                        }
                            string Skills = string.Empty;
                            for (int i = 0; i < chkThinkingSkills.Items.Count; i++)
                            {
                                if (chkThinkingSkills.GetItemChecked(i))
                                {
                                    Skills += chkThinkingSkills.Items[i].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                             ",'" + chkThinkingSkills.Tag + "','" + Skills + "','" + txtThinkingSG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int j = 0; j < chkSocialList.Items.Count; j++)
                            {
                                if (chkSocialList.GetItemChecked(j))
                                {
                                    Skills += chkSocialList.Items[j].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkSocialList.Tag + "','" + Skills + "','" + txtSocialSG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int k = 0; k < chkEmotionalSkillslist.Items.Count; k++)
                            {
                                if (chkEmotionalSkillslist.GetItemChecked(k))
                                {
                                    Skills += chkEmotionalSkillslist.Items[k].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkEmotionalSkillslist.Tag + "','" + Skills + "','" + txtEmotionalSG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int l = 0; l < chkWorkEduList.Items.Count; l++)
                            {
                                if (chkWorkEduList.GetItemChecked(l))
                                {
                                    Skills += chkWorkEduList.Items[l].ToString() + ",";
                                }
                            }

                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkWorkEduList.Tag + "','" + Skills + "','" + txtWorkEduG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int s = 0; s < chkVisualArtlist.Items.Count; s++)
                            {
                                if (chkVisualArtlist.GetItemChecked(s))
                                {
                                    Skills += chkVisualArtlist.Items[s].ToString() + ",";
                                }
                            }

                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkVisualArtlist.Tag + "','" + Skills + "','" + txtVisualSG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int a = 0; a < chkPerformingArtList.Items.Count; a++)
                            {
                                if (chkPerformingArtList.GetItemChecked(a))
                                {
                                    Skills += chkPerformingArtList.Items[a].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkPerformingArtList.Tag + "','" + Skills + "','" + txtPerformingSG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int w = 0; w < chkAttitudeTeacherList.Items.Count; w++)
                            {
                                if (chkAttitudeTeacherList.GetItemChecked(w))
                                {
                                    Skills += chkAttitudeTeacherList.Items[w].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkAttitudeTeacherList.Tag + "','" + Skills + "','" + txtAttitudeTechG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int c = 0; c < chkAttitudeSchoolmatesList.Items.Count; c++)
                            {
                                if (chkAttitudeSchoolmatesList.GetItemChecked(c))
                                {
                                    Skills += chkAttitudeSchoolmatesList.Items[c].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkAttitudeSchoolmatesList.Tag + "','" + Skills + "','" + txtAttitudeScMatesG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int z = 0; z < chkattitudeschprolist.Items.Count; z++)
                            {
                                if (chkattitudeschprolist.GetItemChecked(z))
                                {
                                    Skills += chkattitudeschprolist.Items[z].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkattitudeschprolist.Tag + "','" + Skills + "','" + txtAttitudeScProG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int h = 0; h < chkValueSkillsList.Items.Count; h++)
                            {
                                if (chkValueSkillsList.GetItemChecked(h))
                                {
                                    Skills += chkValueSkillsList.Items[h].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkValueSkillsList.Tag + "','" + Skills + "','" + txtValueSG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int t = 0; t < chkLiteraryList.Items.Count; t++)
                            {
                                if (chkLiteraryList.GetItemChecked(t))
                                {
                                    Skills += chkLiteraryList.Items[t].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkLiteraryList.Tag + "','" + Skills + "','" + txtLitrarySG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int n = 0; n < chkScientificSkillsList.Items.Count; n++)
                            {
                                if (chkScientificSkillsList.GetItemChecked(n))
                                {
                                    Skills += chkScientificSkillsList.Items[n].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkScientificSkillsList.Tag + "','" + Skills + "','" + txtScientificSG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int v = 0; v < chkInformationCommList.Items.Count; v++)
                            {
                                if (chkInformationCommList.GetItemChecked(v))
                                {
                                    Skills += chkInformationCommList.Items[v].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkInformationCommList.Tag + "','" + Skills + "','" + txtInformationSG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int q = 0; q < chkOrganizationSList.Items.Count; q++)
                            {
                                if (chkOrganizationSList.GetItemChecked(q))
                                {
                                    Skills += chkOrganizationSList.Items[q].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkOrganizationSList.Tag + "','" + Skills + "','" + txtOrgnizationSG.Text.Trim() + "')", Connection.MyConnection, trn);

                            Skills = string.Empty;
                            for (int y = 0; y < chkHealthPhyList.Items.Count; y++)
                            {
                                if (chkHealthPhyList.GetItemChecked(y))
                                {
                                    Skills += chkHealthPhyList.Items[y].ToString() + ",";
                                }
                            }
                            Connection.SqlTransection("INSERT INTO tbl_CCEStudentSkills(CCEID, SessionCode, SkillId, Description, Grade )VALUES ('" + CCEID + "','" + school.CurrentSessionCode + "' " +
                            ",'" + chkHealthPhyList.Tag + "','" + Skills + "','" + txtHealthSG.Text.Trim() + "')", Connection.MyConnection, trn);
                    }
                    
                    trn.Commit();
                    MessageBox.Show("Record Saved Successfully.");
                    dataGridView1.Rows.Clear();
                    this.ControlEnable(false);
                }
                else
                {
                    MessageBox.Show("Some Record Missing.\n\tPlease Check Student Details.");
                    txtScholarNo.SelectAll();
                }     
            }
            catch(Exception ex)
            {
                Logger.LogError(ex); 
                trn.Rollback();
                MessageBox.Show("Record Not Saved!!!\n\tSome Record Missing.....");
            }
        }

        private void cmbThinkingSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string s = string.Empty;
            //int n = cmbThinkingSkills.Items.Count;

            //for (int i = 0; i <= n; i++)
            //{
            //    s = s + ';' + cmbThinkingSkills.Text;
            //    textBox1.Text = s;
            //}
        }
     
        private void txtThinkingSG_TextChanged(object sender, EventArgs e)
        {
             CheckGrade(txtThinkingSG);
        }

        public void CheckGrade(System.Windows.Forms.TextBox  t)
        {
            try
            {
                if (!string.IsNullOrEmpty(t.Text.Trim()))
                {
                    if (t.Text.Trim().StartsWith("A") || t.Text.Trim().StartsWith("B")
                        || t.Text.Trim().StartsWith("C") || t.Text.Trim().StartsWith("D")
                        || t.Text.Trim().StartsWith("E"))
                    {
                        
                    }
                    else { MessageBox.Show("Please enter Valid Grade...");
                    t.Clear();
                    }
                }
            }
            catch
            { }
        }

        private void txtSocialSG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtSocialSG);
        }

        private void txtEmotionalSG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtEmotionalSG);
        }

        private void txtWorkEduG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtWorkEduG);
        }

        private void txtVisualSG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtVisualSG);
        }

        private void txtPerformingSG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtPerformingSG);
        }

        private void txtAttitudeTechG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtAttitudeTechG);
        }

        private void txtAttitudeScMatesG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtAttitudeScMatesG);
        }

        private void txtAttitudeScProG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtAttitudeScProG);
        }

        private void txtValueSG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtValueSG);
        }

        private void txtLitrarySG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtLitrarySG);
        }

        private void txtScientificSG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtScientificSG);
        }

        private void txtInformationSG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtInformationSG);
        }

        private void txtOrgnizationSG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtOrgnizationSG);
        }

        private void txtHealthSG_TextChanged(object sender, EventArgs e)
        {
            CheckGrade(txtHealthSG);
        }


        private void txtRollNumber_Validated(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtScholarNo.Text.Trim()))
                {
                    if (Convert.ToInt32(Connection.GetExecuteScalar("Select Count(*) From tbl_CCEStudentMarks Where StudentNo='" + frmCBSCMarksheet.StudentNo  + "' And Status=1 And SessionCode='"+school .CurrentSessionCode +"'")) > 0)
                    {
                        if (DialogResult.No.Equals(MessageBox.Show("Already Exist.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                        {
                            txtScholarNo.SelectAll();
                            txtScholarNo.Focus();
                        }
                        else
                        {
                            SqlDataReader  dr=Connection.GetDataReader ("SELECT tbl_CCEStudentMarks.CCEID, tbl_CCEStudentMarks.ClassNo, tbl_CCEStudentMarks.SubjectNo, tbl_subject.subjectname, tbl_CCEStudentMarks.FA1   "+
                             ", tbl_CCEStudentMarks.FA2, tbl_CCEStudentMarks.SA1, tbl_CCEStudentMarks.FA3, tbl_CCEStudentMarks.FA4, tbl_CCEStudentMarks.SA2, tbl_CCEStudentMarks.FA1FA2FA3FA4G, tbl_CCEStudentMarks.SA1SA2G "+
                             ", tbl_CCEStudentMarks.FinalGrade, tbl_CCEStudentMarks.GradePoint FROM tbl_CCEStudentMarks INNER JOIN tbl_subject ON tbl_CCEStudentMarks.SubjectNo = tbl_subject.subjectno WHERE  "+
                             " (tbl_CCEStudentMarks.SessionCode = '" + school.CurrentSessionCode + "') AND (tbl_CCEStudentMarks.StudentNo = '" + frmCBSCMarksheet.StudentNo + "') ORDER BY tbl_CCEStudentMarks.CCEID");
                            if (!dr.Equals(null))
                            {
                                dataGridView1.Rows.Clear();
                                int i = 0;
                                while  (dr.Read())
                                {
                                    dataGridView1.Rows.Add();
                                    dataGridView1.Rows[i].Cells["SubjectCode"].Value = dr["SubjectNo"];
                                    dataGridView1.Rows[i].Cells["Subject"].Value =dr["subjectname"];
                                    dataGridView1.Rows[i].Cells["FA1"].Value = dr["FA1"];
                                    dataGridView1.Rows[i].Cells["FA2"].Value = dr["FA2"];
                                    dataGridView1.Rows[i].Cells["FA3"].Value = dr["FA3"];
                                    dataGridView1.Rows[i].Cells["FA4"].Value = dr["FA4"];
                                    dataGridView1.Rows[i].Cells["SA1"].Value = dr["SA1"];
                                    dataGridView1.Rows[i].Cells["SA2"].Value = dr["SA2"];
                                    dataGridView1.Rows[i].Cells["FA1FA2FA3FA4G"].Value = dr["FA1FA2FA3FA4G"];
                                    dataGridView1.Rows[i].Cells["SA1SA2G"].Value = dr["SA1SA2G"];
                                    dataGridView1.Rows[i].Cells["FinalGrade"].Value = dr["FinalGrade"];
                                    dataGridView1.Rows[i].Cells["GradePoint"].Value = dr["GradePoint"];
                                    i++;
                                }
                            }
                        }                        
                    }
                    else
                    {
                        DataTable dt = Connection.GetDataTable("SELECT tbl_subject.subjectno, tbl_subject.subjectname FROM tbl_subject INNER JOIN tbl_subwiseclass ON tbl_subject.subjectno = tbl_subwiseclass.subjectno INNER JOIN   tbl_classstudent "+
                            " INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno ON tbl_subwiseclass.classno = tbl_classstudent.classno WHERE (tbl_student.scholarno = '"+txtScholarNo.Text .Trim ()+"') AND (tbl_classstudent.sessioncode = '"+school.CurrentSessionCode +"')");
                        int i = 0;
                        dataGridView1.Rows.Clear();
                        foreach (DataRow dr in dt.Rows)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["SubjectCode"].Value = dr["subjectno"];
                            dataGridView1.Rows[i].Cells["Subject"].Value = dr["subjectname"];
                            dataGridView1.Rows[i].Cells["FA1"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA2"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA1G"].Value = "E2";
                            dataGridView1.Rows[i].Cells["FA2G"].Value = "E2";
                            dataGridView1.Rows[i].Cells["FA3"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA4"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA3G"].Value = "E2";
                            dataGridView1.Rows[i].Cells["FA4G"].Value = "E2";
                            //dataGridView1.Rows[i].Cells["FA1"].Value = 0;
                            //dataGridView1.Rows[i].Cells["FA1"].Value = 0;
                            dataGridView1.Rows[i].Cells["SA1"].Value = 0;
                            dataGridView1.Rows[i].Cells["SA2"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA1FA2SA1"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA3FA4SA2"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA1FA2SA1P"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA3FA4SA2P"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA1FA2FA3FA4"].Value = 0;
                            dataGridView1.Rows[i].Cells["FA1FA2SA1G"].Value = "E2";
                            dataGridView1.Rows[i].Cells["FA3FA4SA2G"].Value = "E2";
                            dataGridView1.Rows[i].Cells["SA1SA2"].Value = 0;
                            i++;
                        }
                        b = true;
                    }
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
 
        private string GetGrade(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 91 && ObtainMarks <= 100)
                Grade = "A1";
            else if (ObtainMarks >= 81 && ObtainMarks <= 90)
                Grade = "A2";
            else if (ObtainMarks >= 71 && ObtainMarks <=80)
                Grade = "B1";
            else if (ObtainMarks >= 61 && ObtainMarks <= 70)
                Grade = "B2";
            else if (ObtainMarks >= 51 && ObtainMarks <= 60)
                Grade = "C1";
            else if (ObtainMarks >=41 && ObtainMarks <= 50)
                Grade = "C2";
            else if (ObtainMarks >=33 && ObtainMarks <= 40)
                Grade = "D";
            else if (ObtainMarks >= 21 && ObtainMarks <= 32)
                Grade = "E1";
            else if (ObtainMarks >= 0 && ObtainMarks <= 20)
                Grade = "E2";
            return Grade;
        }

        private void dataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               // if (b)
                {
                    decimal Zero = 0;
                    if (dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["FA1"].ColumnIndex) ||
                        dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["FA2"].ColumnIndex) ||
                        dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["FA3"].ColumnIndex) ||
                        dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["FA4"].ColumnIndex) ||
                        dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["SA1"].ColumnIndex) ||
                        dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["SA2"].ColumnIndex))
                    {
                        if (decimal.TryParse(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out Zero))
                        {
                            // dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            if (!(dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["SA1"].ColumnIndex) ||
                                dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["SA2"].ColumnIndex)) &&
                                ((Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA1"].Value) >= 0 &&
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA1"].Value) <= 25) ||
                            (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA2"].Value) >= 0 &&
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA2"].Value) <= 25) ||
                            (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA3"].Value) >= 0 &&
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA3"].Value) <= 25) ||
                            (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA4"].Value) >= 0 &&
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA4"].Value) <= 25)))
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex+1].Value =(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)/25*10);
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex+1].Value = this.GetGrade(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value) * 10);
                            }
                            else if ((dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex)&&
                                (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA1"].Value) >= 0 &&
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA1"].Value) <= 100) ||
                            (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA2"].Value) >=0 &&
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA2"].Value) <=100)))
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                                //dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)*decimal.Parse("0.01") * 30);
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));                            
                            }
                            else
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                            }

                            dataGridView1.Rows[e.RowIndex].Cells["FA1FA2SA1"].Value =decimal.Round(
                                 Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA1"].Value) +
                                 Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA2"].Value) +
                                 Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA1"].Value),2);

                            dataGridView1.Rows[e.RowIndex].Cells["FA1FA2SA1P"].Value =decimal.Round(
                                (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA1"].Value) / 25 * 10) +
                                (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA2"].Value) / 25 * 10) +
                                (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA1"].Value) * decimal.Parse("0.01") * 30),2);

                            dataGridView1.Rows[e.RowIndex].Cells["FA1FA2SA1G"].Value =
                                this.GetGrade(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA1FA2SA1P"].Value)*2);

                            dataGridView1.Rows[e.RowIndex].Cells["FA3FA4SA2"].Value =decimal.Round(
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA3"].Value) +
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA4"].Value) +
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA2"].Value),2);

                            dataGridView1.Rows[e.RowIndex].Cells["FA3FA4SA2P"].Value =decimal .Round (
                                (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA3"].Value) / 25 * 10) +
                                (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA4"].Value) / 25 * 10) +
                                (Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA2"].Value) * decimal.Parse("0.01") * 30),2);

                            dataGridView1.Rows[e.RowIndex].Cells["FA3FA4SA2G"].Value =
                               this.GetGrade(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA3FA4SA2P"].Value) * 2);

                            dataGridView1.Rows[e.RowIndex].Cells["FA1FA2FA3FA4"].Value =decimal.Round((( 
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA1"].Value) +
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA2"].Value) +
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA3"].Value) +
                                Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA4"].Value))*decimal.Parse("0.01")*40),2);

                            dataGridView1.Rows[e.RowIndex].Cells["FA1FA2FA3FA4G"].Value=
                                 this.GetGrade(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["FA1FA2FA3FA4"].Value) * 2);

                            dataGridView1.Rows[e.RowIndex].Cells["SA1SA2"].Value = decimal.Round(((
                               Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA1"].Value) +
                               Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA2"].Value)) * decimal.Parse("0.01") * 60), 2);

                            dataGridView1.Rows[e.RowIndex].Cells["SA1SA2G"].Value =
                                 this.GetGrade(Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["SA1SA2"].Value) * 2);

                        }
                        else
                        {
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = Zero;
                        }
                    }
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            this.ControlEnable(true);
            txtScholarNo.Focus();
        }

        private void txtScholarNo_Enter(object sender, EventArgs e)
        {
            txtScholarNo.SelectAll();
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {
            SqlTransaction trn = null;
            if((MessageBox.Show("Are You Sure To Delete "+txtStudentName.Text+" S/D/O "+txtFatherName.Text+"  Record.\nPress Yes.","",MessageBoxButtons .YesNo ,MessageBoxIcon.Question).Equals(DialogResult.Yes)))
            {
                try
                {
                    trn = Connection.GetMyConnection().BeginTransaction();
                    Connection.SqlTransection("Update tbl_CCEStudentMarks Set Status=0 where StudentNo='" + frmCBSCMarksheet.StudentNo + "'  And Status=1 And SessionCode='"+school .CurrentSessionCode +"'", Connection.MyConnection, trn);
                    Connection.SqlTransection("Update tbl_CCEStudentSkills Set Status=0 where Status=1 And SessionCode='" + school.CurrentSessionCode + "' And tbl_CCEStudentSkills.CCEID=dbo.tbl_CCEStudentSkills.CCEID", Connection.MyConnection, trn);
                    trn.Commit();
                    MessageBox.Show(txtStudentName.Text + " S/D/O " + txtFatherName.Text + "  Record Deleted Successfully.", "", MessageBoxButtons.YesNo);
                }
                catch
                {
                    trn.Rollback();
                    MessageBox.Show("Record Has Not Deleted.\n\tPlease Try Again!!!", "!!!", MessageBoxButtons.OK);
                }
            }
        }

        private void txtScholarNo_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtScholarNo.Text.Trim()))
                {
                    DataSet ds = Connection.GetDataSet("SELECT tbl_classmaster.classcode,tbl_classmaster.classname, tbl_classstudent.studentno, tbl_student.name, tbl_student.father FROM  tbl_classmaster INNER JOIN tbl_classstudent ON tbl_classmaster.classcode = tbl_classstudent.classno INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno WHERE (tbl_student.scholarno = '" + txtScholarNo.Text.Trim() + "')");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        frmCBSCMarksheet.ClassNo = int.Parse(ds.Tables[0].Rows[0]["classcode"].ToString());
                        frmCBSCMarksheet.StudentNo = int.Parse(ds.Tables[0].Rows[0]["studentno"].ToString());
                        txtStudentName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        txtFatherName.Text = ds.Tables[0].Rows[0]["father"].ToString();
                        txtClass.Text = ds.Tables[0].Rows[0]["classname"].ToString();
                    }
                }
            }
            catch
            { }
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {

        }

    }
}
