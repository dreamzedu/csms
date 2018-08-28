using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
namespace SMS.MpBoardMarksheet.ReportForm
{
    public partial class frmMPCCEMarkSheetM : UserControl
    {
        public frmMPCCEMarkSheetM()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        SqlDataReader dataReader = null;
        bool NonPrimaryFlage;
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Connection.GetDataSet("SELECT tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno,'Mast/Miss '+ tbl_student.name as name , 'Mr. '+ tbl_student.father as father, " +
                    "  'Mrs. '+ tbl_student.mother as mother, tbl_student.dob, tbl_student.C_address, tbl_student.m_tongue, tbl_student.casttype, tbl_student.bloodgroup,tbl_student.Height,tbl_student.Width,tbl_student.VisionL,tbl_student.VisionR,tbl_student.Teeth ,tbl_student.OHygiene,tbl_student.House,CASE WHEN tbl_student.CGPA IS NULL or tbl_student.CGPA='' THEN '..........' ELSE tbl_student.CGPA END as CGPA,CASE WHEN tbl_student.OGrade IS NULL or tbl_student.OGrade='' THEN '..........' ELSE tbl_student.OGrade END as OGrade, tbl_classstudent.stdtype,tbl_student.studentimage,  " +
                    "  tbl_student.marr_status AS Gender, tbl_student.studentphoto, tbl_student.phone, tbl_student.bldgroup AS Medium, tbl_tehsil.tehsil, tbl_district.district,  " +
                    "  tbl_district.statename, tbl_classmaster.classname, tbl_section.sectionname, tbl_classmaster.classname +' '+tbl_section.sectionname AS Class,  " +
                    "  tbl_sankay.sankayname AS Stream, ISNULL(tbl_StudentAttendance.Lectures, 0) AS [Total Lecture], ISNULL(tbl_StudentAttendance.PresentDays, 0) AS [Total Present], ISNULL(tbl_StudentAttendance.Per , 0) AS [Per]  " +
                    "  FROM tbl_section INNER JOIN  " +
                    "  tbl_sankay INNER JOIN  " +
                    "  tbl_classstudent ON tbl_sankay.sankaycode = tbl_classstudent.Stream INNER JOIN  " +
                    "  tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  " +
                    "  tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN  " +
                    "  tbl_session ON tbl_classstudent.sessioncode = tbl_session.sessioncode ON tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN  " +
                    "  tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN  " +
                    "  tbl_district ON tbl_student.distcode = tbl_district.distcode  Left join tbl_StudentAttendance on tbl_student .studentno = tbl_StudentAttendance .StudentNo " +
                    "  WHERE (tbl_section.sectioncode = '" + cmbScetion.SelectedValue + "') AND (tbl_classstudent.ClassNo ='" + cmbClass.SelectedValue + "')  " +
                    "  AND (tbl_session.sessioncode  = '" + cmbSession.SelectedValue + "') and  tbl_classstudent.stdtype<>'Ex-Student' Order By  tbl_student.name ;" +

                    " SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,logoimage FROM tbl_school ");

            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptCBSEMarksFrontDetail.xsd");
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            ShowAllReports cr = new ShowAllReports();
           
            s = new MpBoardMarksheet.ReportDesign.rptMCCEReportFormatFront();
            s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            s.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            s.SetDataSource(ds);
            s.SetParameterValue("Class", Connection.GetNextClass(cmbClass.Text.Trim()));

            cr.crystalReportViewer1.ReportSource = s;
            cr.crystalReportViewer1.Zoom(100);
            cr.Show();
        }

        private void btnBackView_Click(object sender, EventArgs e)
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            this.NonPrimaryFlage = Convert.ToBoolean(Connection.GetExecuteScalar("Select NonPrimary From tbl_ClassMaster Where ClassCode = '" + cmbClass.SelectedValue + "'"));

            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewMCCEMarksDetail] " + cmbClass.SelectedValue + "," + cmbScetion.SelectedValue + "," + school.CurrentSessionCode + "");
            DataTable dtStudentSkillsDetail = Connection.GetDataTable("Select (Case When t1.ExamCode=0 Then 'SA1_' When t1.ExamCode=1 Then 'SA2_' When t1.ExamCode=2 Then 'SA3_'  End) AS ExamCode , " +
                " t2.studentno StudentNo,t2.scholarno ScholarNo,t2.Name ,t1.SkillId ,t1.SkillName ,t1.Description ,t1.Grade  From ( " +
                " Select s2.ExamCode,s1.SkillId ,s1.SkillName ,s2.StudentNo ,s2.Description ,s2.Grade ,s2.ClassNo ,s2.SectionCode  From tbl_CCESkills s1,tbl_MCCEStudentSkills s2 Where s1.SkillId =s2.SkillId And " +
                " s2.SectionCode ='" + cmbScetion.SelectedValue + "' And s2.ClassNo='" + cmbClass.SelectedValue + "' And s2.SessionCode ='" + school.CurrentSessionCode + "') t1 ,( " +
                " Select s.studentno ,s.scholarno ,s.name,cs.classno ,cs.Section ,cs.Stream  From tbl_student s ,tbl_classstudent cs Where cs.studentno =s.studentno And cs.sessioncode ='" + school.CurrentSessionCode + "'" +
                " And cs.classno ='" + cmbClass.SelectedValue + "' And cs.Section ='" + cmbScetion.SelectedValue + "') t2 " +
                " Where t1.StudentNo =t2.studentno And t1.SectionCode =t2.Section And t1.ClassNo =t2.classno Order By t1.SkillId ,t1.SkillName");
            DataTable dt = dtStudentMarksDetail.DefaultView.ToTable(true, "SessionCode", "StudentNo", "ScholarNo");
            dtTable.Columns.Add("SessionCode", typeof(int)); Indexer++;
            dtTable.Columns.Add("ScholarNo", typeof(string)); Indexer++;
            dtTable.Columns.Add("Name", typeof(string)); Indexer++;
            dtTable.Columns.Add("Height", typeof(string)); Indexer++;
            dtTable.Columns.Add("Width", typeof(string)); Indexer++;
            for (int i = 1; i <= 9; i++)
            {
                dtTable.Columns.Add("SubCode_" + i, typeof(string)); Indexer++;
                dtTable.Columns["SubCode_" + i].DefaultValue = "00";
                dtTable.Columns.Add("Sub_" + i, typeof(string)); Indexer++;
            }
            for (int j = 9; j < dtStudentMarksDetail.Columns.Count; j++)
            {
                string Sub = dtStudentMarksDetail.Columns[j].ColumnName;
                for (int i = 1; i <= 9; i++)
                {
                    dtTable.Columns.Add("Sub_" + i + "_" + Sub, typeof(string)); Indexer++;
                }
            }

            for (int r = 0; r < 1; r++)
            {
                //string Exam = (r["ExamCode"].Equals("0"))?"FA1_":(r["ExamCode"].Equals("1"))?"FA2_":(r["ExamCode"].Equals("2"))?"SA1_":
                //    (r["ExamCode"].Equals("3"))?"FA3_":(r["ExamCode"].Equals("4"))?"FA4_":(r["ExamCode"].Equals("5"))?"SA2_":"";

                dataReader = Connection.GetDataReader("SELECT SkillId, SkillName, Status FROM tbl_CCESkills Order By SkillId");
                if (dataReader.HasRows)
                {
                    string Exam = (r.Equals(0)) ? "SA1_" : "SA2_";
                    while (dataReader.Read())
                    {
                        dtTable.Columns.Add(Exam + dataReader["SkillName"].ToString(), typeof(string));
                        dtTable.Columns.Add(Exam + dataReader["SkillName"].ToString() + "_G", typeof(string));
                    }
                }
                dataReader.Close();
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] Student = dtStudentMarksDetail.Select("StudentNo='" + dt.Rows[i]["StudentNo"] + "' And ScholarNo='" + dt.Rows[i]["ScholarNo"] + "'");
                DataRow NewRow = dtTable.NewRow();
                NewRow["SessionCode"] = Student[0]["SessionCode"]; NewRow["ScholarNo"] = Student[0]["ScholarNo"]; NewRow["Name"] = Student[0]["Name"];
                NewRow["Height"] = Student[0]["Height"]; NewRow["Width"] = Student[0]["Width"];
                for (int subject = 1; subject <= Student.Length; subject++)
                {
                    NewRow["SubCode_" + subject] = Student[subject - 1]["SubjectCode"];
                    NewRow["Sub_" + subject] = Student[subject - 1]["SubjectName"];
                }

                for (int subject = 1; subject <= Student.Length; subject++)
                {
                    for (int GetGrade = 11; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                    {
                        string tstr = string.Empty;
                        string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                        if(Student[subject - 1][Sub].ToString().Trim().Equals("-1"))
                            NewRow["Sub_" + subject + "_" + Sub] = "AB";
                        else
                            NewRow["Sub_" + subject + "_" + Sub] = Student[subject - 1][Sub];
                    }
                }

                if (dtStudentSkillsDetail != null)
                {
                    DataTable dtExam = dtStudentSkillsDetail.DefaultView.ToTable(true, "ExamCode");
                    DataTable dtSkill = dtStudentSkillsDetail.DefaultView.ToTable(true, "SkillId", "SkillName");

                    if (this.NonPrimaryFlage)
                    {
                        for (int Exam = 0; Exam < dtExam.Rows.Count; Exam++)
                        {
                            for (int skill = 0; skill < dtSkill.Rows.Count; skill++)
                            {
                                string DI = string.Empty;
                                string Grade = string.Empty;

                                DataRow[] desc = dtStudentSkillsDetail.Select("ExamCode='" + dtExam.Rows[Exam]["ExamCode"] + "' And SkillName='" + dtSkill.Rows[skill][1] + "' And StudentNo='" + dt.Rows[i]["StudentNo"] + "' And ScholarNo='" + dt.Rows[i]["ScholarNo"] + "'");
                                for (int des = 0; des < desc.Length; des++)
                                {
                                    DI = DI + desc[des]["SkillName"].ToString();
                                    Grade = desc[0]["Grade"].ToString();

                                   
 
                                }
                                NewRow[dtExam.Rows[Exam]["ExamCode"].ToString() + dtSkill.Rows[skill][1].ToString()] = DI.TrimEnd(',');
                                NewRow[dtExam.Rows[Exam]["ExamCode"].ToString() + dtSkill.Rows[skill][1].ToString() + "_G"] = Grade;
                            }
                        }
                    }
                    else
                    {
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
                                NewRow[Indexer] = desc[0][5]; Indexer++;
                                NewRow[Indexer] = desc[0][7]; Indexer++;
                            }
                        }
                        Indexer = N;
                    }
                }
                dtTable.Rows.Add(NewRow);
            }
            DataTable dtschool = Connection.GetDataTable("SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,logoimage,HOESIGN,PRINSIGN FROM tbl_school");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtTable);
            ds.Tables.Add(dtschool);
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptCBSEMarksBackDetail.xsd");
            int a = dtTable.Columns.Count;
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            if (cmbClass.Text.Trim().Equals("VI") || cmbClass.Text.Trim().Equals("VII") || cmbClass.Text.Trim().Equals("VIII") || cmbClass.Text.Trim().Equals("IX") || cmbClass.Text.Trim().Equals("X"))
            {
                s = new MpBoardMarksheet.ReportDesign.rptMCCEReportFormatBack();
            }
            else
            {
                s = new MpBoardMarksheet.ReportDesign.rptMCCEReportFormatBack_A();
            }

            s.SetDataSource(ds);
            s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            s.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;
            ShowAllReports cr = new ShowAllReports();
            cr.crystalReportViewer1.ReportSource = s;
            cr.crystalReportViewer1.Zoom(100);
            s.SetParameterValue("Class", cmbClass.Text.Trim());
            cr.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frmMPCCEMarkSheetM_Load(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSession, "select SessionCode,SessionName from tbl_session Group by SessionCode,SessionName");
                cmbSession.SelectedValue = school.CurrentSessionCode;
                Connection.FillComboBox(cmbClass, "select ClassCode,ClassName from tbl_classmaster Order By ClassOrder");
                this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
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
                Logger.LogError(ex); 
            }
        }

        private void frmMPCCEMarkSheetM_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
