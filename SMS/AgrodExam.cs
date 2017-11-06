using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class AgrodExam :UserControlBase
    {
        SqlDataReader dataReader = null;
        bool NonPrimaryFlage;
        public AgrodExam()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
         private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frmNewCCEMarkSheet_Load(object sender, EventArgs e)
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

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            DataSet ds=new DataSet ();
            ds = Connection.GetDataSet("SELECT tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno,'Mr/Miss. '+ tbl_student.name as name , 'Mr. '+ tbl_student.father as father, " +
                    "  'Mrs. '+ tbl_student.mother as mother, tbl_student.dob, tbl_student.C_address, tbl_student.m_tongue, tbl_student.casttype, tbl_student.bloodgroup,tbl_student.Height,tbl_student.Width,tbl_student.VisionL,tbl_student.VisionR,tbl_student.Teeth ,tbl_student.OHygiene,tbl_student.House,CASE WHEN tbl_student.CGPA IS NULL or tbl_student.CGPA='' THEN '..........' ELSE tbl_student.CGPA END as CGPA,CASE WHEN tbl_student.OGrade IS NULL or tbl_student.OGrade='' THEN '..........' ELSE tbl_student.OGrade END as OGrade, tbl_classstudent.stdtype,tbl_student.studentimage,  " +
                    "  tbl_student.marr_status AS Gender, tbl_student.studentphoto, tbl_student.phone, tbl_student.bldgroup AS Medium, tbl_tehsil.tehsil, tbl_district.district,  "+
                    "  tbl_district.statename, tbl_classmaster.classname, tbl_section.sectionname, tbl_classmaster.classname +' '+tbl_section.sectionname AS Class,  " +
                    "  tbl_sankay.sankayname AS Stream, ISNULL(tbl_StudentAttendance.Lectures, 0) AS [Total Lecture], ISNULL(tbl_StudentAttendance.PresentDays, 0) AS [Total Present], ISNULL(tbl_StudentAttendance.Per , 0) AS [Per]  " +
                    "  FROM tbl_section INNER JOIN  "+
                    "  tbl_sankay INNER JOIN  "+
                    "  tbl_classstudent ON tbl_sankay.sankaycode = tbl_classstudent.Stream INNER JOIN  "+
                    "  tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  "+
                    "  tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN  "+
                    "  tbl_session ON tbl_classstudent.sessioncode = tbl_session.sessioncode ON tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN  "+
                    "  tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN  "+
                    "  tbl_district ON tbl_student.distcode = tbl_district.distcode  Left join tbl_StudentAttendance on tbl_student .studentno = tbl_StudentAttendance .StudentNo " +
                    "  WHERE (tbl_section.sectioncode = '" + cmbScetion.SelectedValue + "') AND (tbl_classstudent.ClassNo ='" + cmbClass.SelectedValue + "')  "+
                    "  AND (tbl_session.sessioncode  = '" + cmbSession.SelectedValue + "') and  tbl_classstudent.stdtype<>'Ex-Student' Order By  tbl_student.name ;" +

                    " SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,logoimage FROM tbl_school ");
 
            ds.WriteXmlSchema(@""+Connection.GetAccessPathId()+@"Barcodes\a\rptCBSEMarksFrontDetail.xsd"); 
            CrystalDecisions.CrystalReports.Engine.ReportDocument s=null ;
            rptCCEReportFormat3 s3 = new rptCCEReportFormat3();
            s3.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
            s3.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
            ShowAllReports cr = new ShowAllReports();
            if (cmbClass.Text.Trim().Equals("IX") || cmbClass.Text.Trim().Equals("X"))
            {
                s = new rptCCEMarkFrontEnd();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal;
                s.SetDataSource(ds);
                cr.crystalReportViewer1.ReportSource = s;
            }
            else if (cmbClass.Text.Trim().Equals("I") || cmbClass.Text.Trim().Equals("II") || cmbClass.Text.Trim().Equals("III") || cmbClass.Text.Trim().Equals("IV")
                || cmbClass.Text.Trim().Equals("V") || cmbClass.Text.Trim().Equals("VI") || cmbClass.Text.Trim().Equals("VII") || cmbClass.Text.Trim().Equals("VIII"))
            {
                s = new rptCCEReportFormat2();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
                s.SetDataSource(ds);
                s.SetParameterValue("Class", Connection.GetNextClass(cmbClass.Text.Trim()));
                cr.crystalReportViewer1.ReportSource = s;
            }
            else
            {
                
                
               
                s3.SetDataSource(ds);
                s3.SetParameterValue("Class", Connection.GetNextClass(cmbClass.Text.Trim()));
                cr.crystalReportViewer1.ReportSource = s3;
            }
            
           
           
            
            cr.crystalReportViewer1.Zoom(54);
            cr.Show();
        }
      
        private void btnBackView_Click(object sender, EventArgs e)
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            this.NonPrimaryFlage = Convert.ToBoolean(Connection.GetExecuteScalar("Select NonPrimary From tbl_ClassMaster Where ClassCode = '" + cmbClass.SelectedValue + "'"));
           
            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewCCEMarksDetail] " + cmbClass.SelectedValue + "," + cmbScetion.SelectedValue + "," + school.CurrentSessionCode + "");
            DataTable dtStudentSkillsDetail = Connection.GetDataTable("Select (Case When t1.ExamCode=0 Then 'FA1_' When t1.ExamCode=1 Then 'FA2_' When t1.ExamCode=2 Then 'SA1_' When t1.ExamCode=3 Then 'FA3_' When t1.ExamCode=4 Then 'FA4_' When t1.ExamCode=5 Then 'SA2_' End) AS ExamCode , "+
                " t2.studentno StudentNo,t2.scholarno ScholarNo,t2.Name ,t1.SkillId ,t1.SkillName ,t1.Description ,t1.Grade  From ( " +
                " Select s2.ExamCode,s1.SkillId ,s1.SkillName ,s2.StudentNo ,s2.Description ,s2.Grade ,s2.ClassNo ,s2.SectionCode  From tbl_CCESkills s1,tbl_CCEStudentSkills s2 Where s1.SkillId =s2.SkillId And " +
                " s2.SectionCode ='"+cmbScetion .SelectedValue +"' And s2.ClassNo='"+cmbClass .SelectedValue +"' And s2.SessionCode ='"+ school .CurrentSessionCode  +"') t1 ,( "+
                " Select s.studentno ,s.scholarno ,s.name,cs.classno ,cs.Section ,cs.Stream  From tbl_student s ,tbl_classstudent cs Where cs.studentno =s.studentno And cs.sessioncode ='" + school.CurrentSessionCode + "'"+
                " And cs.classno ='" + cmbClass.SelectedValue + "' And cs.Section ='"+cmbScetion .SelectedValue +"') t2 "+
                " Where t1.StudentNo =t2.studentno And t1.SectionCode =t2.Section And t1.ClassNo =t2.classno Order By t1.SkillId ,t1.SkillName");
            DataTable dt = dtStudentMarksDetail.DefaultView.ToTable(true, "SessionCode", "StudentNo", "ScholarNo");
            dtTable.Columns.Add("SessionCode", typeof(int)); Indexer++;
            dtTable.Columns.Add("ScholarNo", typeof(string)); Indexer++;
            dtTable.Columns.Add("Name", typeof(string)); Indexer++;
            dtTable.Columns.Add("Height", typeof(string)); Indexer++;
            dtTable.Columns.Add("Width", typeof(string)); Indexer++;
            for (int i = 1; i <= 8; i++)
            {
                dtTable.Columns.Add("SubCode_" + i, typeof(string)); Indexer++;
                dtTable.Columns["SubCode_" + i].DefaultValue = "00";
                dtTable.Columns.Add("Sub_" + i, typeof(string)); Indexer++;
            }
            for (int j = 9; j < dtStudentMarksDetail.Columns .Count ; j++)
            {
                string Sub = dtStudentMarksDetail.Columns[j].ColumnName;
                for (int i = 1; i <= 8; i++)
                {
                    dtTable.Columns.Add("Sub_" + i + "_" + Sub, typeof(string)); Indexer++;
                }
            }

            for (int r = 0; r < 2; r++)
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
                    for (int GetGrade = 9; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                    {
                        string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
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
                                    DI = DI + desc[des]["Description"].ToString();
                                    Grade = desc[0]["Grade"].ToString();
                                }
                                NewRow[dtExam.Rows[Exam]["ExamCode"].ToString() + dtSkill.Rows[skill][1].ToString()] = DI.TrimEnd(',')+".";
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

            dtTable.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptCBSEMarksBackDetail.xsd");
            int a = dtTable.Columns.Count;
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            if (cmbClass.Text.Trim().Equals("IX") || cmbClass.Text.Trim().Equals("X"))
            {
                s = new rptCCEReportBackFormat1();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal;
            }
            else if (cmbClass.Text.Trim().Equals("I") || cmbClass.Text.Trim().Equals("II") || cmbClass.Text.Trim().Equals("III") || cmbClass.Text.Trim().Equals("IV")
                  || cmbClass.Text.Trim().Equals("V") || cmbClass.Text.Trim().Equals("VI") || cmbClass.Text.Trim().Equals("VII") || cmbClass.Text.Trim().Equals("VIII"))
            {
                s = new rptCCEReportBackFormat2N();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
            }
            else
            {
                s = new rptCCEReportBackFormat3();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
            }

            s.SetDataSource(dtTable);
            ShowAllReports cr = new ShowAllReports();
            cr.crystalReportViewer1.ReportSource = s;
            s.SetParameterValue("Class", cmbClass.Text.Trim ());
            cr.Show();
        }

        private void frmNewCCEMarkSheet_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void btnViewReport_Click_1(object sender, EventArgs e)
        {

        }  
          
    }
}
