using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.MpBoardMarksheet.ReportForm
{
    public partial class frmMPCCEMarkSheetS : UserControl
    {
        public frmMPCCEMarkSheetS()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        SqlDataReader dataReader = null;
        private void Btn_Format1_Click(object sender, EventArgs e)
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            //this.NonPrimaryFlage = Convert.ToBoolean(Connection.GetExecuteScalar("Select NonPrimary From tbl_ClassMaster Where ClassCode = '" + cmbClass.SelectedValue + "'"));

            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail_Format1] " + cmbClass.SelectedValue + "," + cmbScetion.SelectedValue + "," + school.CurrentSessionCode + "");
            DataTable dtStudentSkillsDetail = Connection.GetDataTable("Select (Case When t1.ExamCode=0 Then 'TERMI_' When t1.ExamCode=1 Then 'TERMII_' End) AS ExamCode , " +
                " t2.studentno StudentNo,t2.scholarno ScholarNo,t2.Name ,t1.SkillId ,t1.SkillName ,t1.Description ,t1.Grade  From ( " +
                " Select s2.ExamCode,s1.SkillId ,s1.SkillName ,s2.StudentNo ,s2.Description ,s2.Grade ,s2.ClassNo ,s2.SectionCode  From tbl_CCESkills s1,tbl_MPCCEStudentSkills s2 Where s1.SkillId =s2.SkillId And " +
                " s2.SectionCode ='" + cmbScetion.SelectedValue + "' And s2.ClassNo='" + cmbClass.SelectedValue + "' And s2.SessionCode ='" + school.CurrentSessionCode + "') t1 ,( " +
                " Select s.studentno ,s.scholarno ,s.name,cs.classno ,cs.Section ,cs.Stream  From tbl_student s ,tbl_classstudent cs Where cs.studentno =s.studentno And cs.sessioncode ='" + school.CurrentSessionCode + "'" +
                " And cs.classno ='" + cmbClass.SelectedValue + "' And cs.Section ='" + cmbScetion.SelectedValue + "') t2 " +
                " Where t1.StudentNo =t2.studentno And t1.SectionCode =t2.Section And t1.ClassNo =t2.classno Order By t1.SkillId ,t1.SkillName");
            DataTable dt = dtStudentMarksDetail.DefaultView.ToTable(true, "SessionCode", "StudentNo", "ScholarNo");
            dtTable.Columns.Add("SessionCode", typeof(int)); Indexer++;
            dtTable.Columns.Add("sessionname", typeof(string)); Indexer++;
            dtTable.Columns.Add("scholarno", typeof(string)); Indexer++;
            dtTable.Columns.Add("name", typeof(string)); Indexer++;
            dtTable.Columns.Add("RollNo", typeof(string)); Indexer++;
            dtTable.Columns.Add("father", typeof(string)); Indexer++;
            dtTable.Columns.Add("mother", typeof(string)); Indexer++;
            dtTable.Columns.Add("dob", typeof(string)); Indexer++;
            dtTable.Columns.Add("SSMId", typeof(string)); Indexer++;
            dtTable.Columns.Add("classname", typeof(string)); Indexer++;
            dtTable.Columns.Add("studentimage", typeof(byte[])); Indexer++;
            dtTable.Columns.Add("Wdob", typeof(string)); Indexer++;
            for (int i = 1; i <= 10; i++)
            {
                dtTable.Columns.Add("SubCode_" + i, typeof(string)); Indexer++;
                dtTable.Columns["SubCode_" + i].DefaultValue = "00";
                dtTable.Columns.Add("Sub_" + i, typeof(string)); Indexer++;
            }
            for (int j = 18; j < dtStudentMarksDetail.Columns.Count; j++)
            {
                string Sub = dtStudentMarksDetail.Columns[j].ColumnName;
                for (int i = 1; i <= 10; i++)
                {
                    dtTable.Columns.Add("Sub_" + i + "_" + Sub, typeof(string)); Indexer++;
                }
            }
            //Add Skills Details
            for (int r = 0; r < 2; r++)
            {
                //string Exam = (r["ExamCode"].Equals("0"))?"FA1_":(r["ExamCode"].Equals("1"))?"FA2_":(r["ExamCode"].Equals("2"))?"SA1_":
                //    (r["ExamCode"].Equals("3"))?"FA3_":(r["ExamCode"].Equals("4"))?"FA4_":(r["ExamCode"].Equals("5"))?"SA2_":"";

                dataReader = Connection.GetDataReader("SELECT SkillId, SkillName, Status FROM tbl_CCESkills Order By SkillId");
                if (dataReader.HasRows)
                {
                    string Exam = (r.Equals(0)) ? "TERMI_" : "TERMII_";
                    while (dataReader.Read())
                    {
                        dtTable.Columns.Add(Exam + dataReader["SkillName"].ToString(), typeof(string));
                        dtTable.Columns.Add(Exam + dataReader["SkillName"].ToString() + "_G", typeof(string));
                    }
                }
                dataReader.Close();
            }

            //dataReader = Connection.GetDataReader("SELECT SkillId, SkillName, Status FROM tbl_CCESkills Order By SkillId");
            //if (dataReader.HasRows)
            //{
            //    string Exam = "TERMI_" ;
            //    while (dataReader.Read())
            //    {
            //        dtTable.Columns.Add(Exam + dataReader["SkillName"].ToString(), typeof(string));
            //        dtTable.Columns.Add(Exam + dataReader["SkillName"].ToString() + "_G", typeof(string));
            //    }
            //}
            //dataReader.Close();

            //End Skills Details

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tmp1 = 0; int C = 0; int E = 0;
                DataRow[] Student_C = dtStudentMarksDetail.Select("StudentNo='" + dt.Rows[i]["StudentNo"] + "' And ScholarNo='" + dt.Rows[i]["ScholarNo"] + "' And subjecttype='Core Subject'");
                DataRow[] Student_E = dtStudentMarksDetail.Select("StudentNo='" + dt.Rows[i]["StudentNo"] + "' And ScholarNo='" + dt.Rows[i]["ScholarNo"] + "' And subjecttype='Elective Subject'");
                DataRow NewRow = dtTable.NewRow();
                NewRow["SessionCode"] = Student_C[0]["SessionCode"];
                NewRow["sessionname"] = Student_C[0]["sessionname"];
                NewRow["scholarno"] = Student_C[0]["scholarno"];
                NewRow["name"] = Student_C[0]["name"];
                NewRow["RollNo"] = Student_C[0]["RollNo"];
                NewRow["father"] = Student_C[0]["father"];
                NewRow["mother"] = Student_C[0]["mother"];
                NewRow["dob"] = Student_C[0]["dob"];
                NewRow["SSMId"] = Student_C[0]["SSMId"];
                NewRow["classname"] = Student_C[0]["classname"];
                
                if (string.IsNullOrEmpty(Convert.ToString(Student_C[0]["studentimage"])))
                {
                    NewRow["studentimage"] = null;
                }
                else
                {
                    byte[] ByteImage = (byte[])Student_C[0]["studentimage"];
                    Bitmap bmp = Connection.GetImageFromByteArray(ByteImage);
                    //bmp = Connection.AdjustContrastOfImage(bmp, 80f);
                    NewRow["studentimage"] = Connection.GetByteArrayFromImage(bmp);
                }
                NewRow["Wdob"] = Student_C[0]["Wdob"];
                for (int k = 1; k <= 10; k++)
                {
                    if (k <= 6)
                    {
                        tmp1 = Student_C.Length;

                        if (tmp1 == 6)
                        {
                            NewRow["SubCode_" + k] = Student_C[C]["SubjectCode"];
                            NewRow["Sub_" + k] = Student_C[C]["SubjectName"];

                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                            }
                        }
                        else if (C < 6 && tmp1 != 0)
                        {
                            if (C < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_C[C]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_C[C]["SubjectName"];

                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                                }
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                            }
                        }

                        C++;

                    }
                    else if (k > 6 && k <= 10)
                    {
                        tmp1 = Student_E.Length;

                        if (tmp1 == 4)
                        {
                            NewRow["SubCode_" + k] = Student_E[E]["SubjectCode"];
                            NewRow["Sub_" + k] = Student_E[E]["SubjectName"];

                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                            }
                        }
                        else if (E < 4 && tmp1 != 0)
                        {
                            if (E < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_E[E]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_E[E]["SubjectName"];

                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                }
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                            }
                        }

                        E++;
                    }
                }
                if (dtStudentSkillsDetail != null)
                {
                    DataTable dtExam = dtStudentSkillsDetail.DefaultView.ToTable(true, "ExamCode");
                    DataTable dtSkill = dtStudentSkillsDetail.DefaultView.ToTable(true, "SkillId", "SkillName");

                        int N = Indexer;
                        DataView dv = dtExam.DefaultView;
                        dv.Sort = "ExamCode asc";
                        DataTable sortedDT = dv.ToTable();
                        //dtExam.DefaultView.Sort = "ExamCode asc";
                        for (int Exam = 0; Exam < sortedDT.Rows.Count; Exam++)
                        {
                            for (int skill = 0; skill < dtSkill.Rows.Count; skill++)
                            {
                                DataRow[] desc = dtStudentSkillsDetail.Select("ExamCode='" + sortedDT.Rows[Exam]["ExamCode"] + "' And SkillName='" + dtSkill.Rows[skill][1] + "' And StudentNo='" + dt.Rows[i]["StudentNo"] + "' And ScholarNo='" + dt.Rows[i]["ScholarNo"] + "'");
                                if (desc.Count() > 0)
                                {
                                    NewRow[Indexer] = desc[0][5]; Indexer++;
                                    NewRow[Indexer] = desc[0][7]; Indexer++;
                                }
                            }
                        }
                        Indexer = N;
                    
                }
                dtTable.Rows.Add(NewRow);
            }
            DataTable dtschool = Connection.GetDataTable("SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,logoimage,HOESIGN,PRINSIGN FROM tbl_school");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtTable);
            ds.Tables.Add(dtschool);
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptMPCBSEMarksBackDetailFormat_S.xsd");
            int a = dtTable.Columns.Count;
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            if (cmbClass.Text.Trim().Equals("IX") || cmbClass.Text.Trim().Equals("X"))
            {
                s = new MpBoardMarksheet.ReportDesign.rptMPMarksheetFormat_D();
            }
            else if (cmbClass.Text.Trim().Equals("I") || cmbClass.Text.Trim().Equals("II") || cmbClass.Text.Trim().Equals("III") || cmbClass.Text.Trim().Equals("IV")
                  || cmbClass.Text.Trim().Equals("V"))
            {
                s = new MpBoardMarksheet.ReportDesign.rptMPMarksheetFormat_B();
            }
            else if (cmbClass.Text.Trim().Equals("VI") || cmbClass.Text.Trim().Equals("VII") || cmbClass.Text.Trim().Equals("VIII") || cmbClass.Text.Trim().Equals("IX"))
            {
                s = new MpBoardMarksheet.ReportDesign.rptMPMarksheetFormat_C();
            }
            else
            {
                s = new MpBoardMarksheet.ReportDesign.rptMPMarksheetFormat_A();
            }

            s.SetDataSource(ds);

            ShowAllReports cr = new ShowAllReports();

            cr.crystalReportViewer1.ReportSource = s;
            s.SetParameterValue("NCLASS", Connection.GetNextClass(cmbClass.Text.Trim()));

            cr.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbScetion, "SELECT tbl_class.sectioncode, tbl_section.sectionname FROM tbl_classmaster INNER JOIN  " +
                    " tbl_class ON tbl_classmaster.classcode = tbl_class.classcode INNER JOIN tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode WHERE (tbl_classmaster.classcode = '" + cmbClass.SelectedValue + "')");
            }
            catch (Exception ex)
            {

            }
        }

        private void frmMPCCEMarkSheetS_Load(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSession, "select SessionCode,SessionName from tbl_session Group by SessionCode,SessionName");
                cmbSession.SelectedValue = school.CurrentSessionCode;
                Connection.FillComboBox(cmbClass, "select ClassCode,ClassName from tbl_classmaster Order By ClassOrder");
            }
            catch (Exception ex)
            {

            }
        }

        private void frmMPCCEMarkSheetS_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
