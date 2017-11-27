using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace SMS.MpBoardMarksheet.ReportForm
{
    public partial class frmMPNewMark : UserControl
    {
        static string ttype = string.Empty;
        public frmMPNewMark(string TYPE)
        {
            InitializeComponent(); Connection.SetUserControlTheme(this); Connection.SetUserControlTheme(this);
            
            ttype = TYPE;
        }
        SqlDataReader dataReader = null;
        DataTable dtStudentCCESkillsLst = new DataTable();
        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frmMPCCMarksheetSHHSSA_Load(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSession, "select SessionCode,SessionName from tbl_session Group by SessionCode,SessionName");
                cmbSession.SelectedValue = school.CurrentSessionCode;
                Connection.FillComboBox(cmbClass, "select ClassCode,ClassName from tbl_classmaster Order By ClassOrder");
                Connection.FillComboBox(cmbSankay, " SELECT sankaycode, sankayname   FROM tbl_sankay order by sankayname");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Connection.GetDataSet("SELECT tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.admissiondate,tbl_student.scholarno, tbl_student.name as name , tbl_student.father as father, " +
                    "  tbl_student.mother as mother, tbl_student.dob, tbl_student.C_address, tbl_student.m_tongue, tbl_student.casttype, tbl_student.bloodgroup,tbl_student.Height,tbl_student.Width,tbl_student.VisionL,tbl_student.VisionR,tbl_student.Teeth ,tbl_student.OHygiene,tbl_student.House,CASE WHEN tbl_student.CGPA IS NULL or tbl_student.CGPA='' THEN '..........' ELSE tbl_student.CGPA END as CGPA,CASE WHEN tbl_student.OGrade IS NULL or tbl_student.OGrade='' THEN '..........' ELSE tbl_student.OGrade END as OGrade, tbl_classstudent.stdtype,tbl_student.studentimage,  " +
                    "  tbl_student.marr_status AS Gender, tbl_student.studentphoto, tbl_student.phone, tbl_student.bldgroup AS Medium, tbl_tehsil.tehsil, tbl_district.district,  " +
                    "  tbl_district.statename, tbl_classmaster.classname, tbl_section.sectionname, tbl_classmaster.classname +' '+tbl_section.sectionname AS Class,  " +
                    "  tbl_sankay.sankayname AS Stream, ISNULL(tbl_StudentAttendance.Lectures, 0) AS [Total Lecture], ISNULL(tbl_StudentAttendance.PresentDays, 0) AS [Total Present], ISNULL(tbl_StudentAttendance.Per , 0) AS [Per],tbl_StudentAttendance.RollNo ,tbl_student.SSMId,tbl_student.Wdob " +
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

                    " SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,SchoolCode,registrationno,logoimage FROM tbl_school ");

            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptCBSEMarksFrontDetail.xsd");
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            ShowAllReports cr = new ShowAllReports();
            if (ttype.Equals("MPCON"))
            s = new rptCCEReportFormat2();
            if (ttype.Equals("RNCON"))
                s = new rptCCEReportFormat2RNCON();
            if (ttype.Equals("EVEREST"))
                s = new rptEverestFrontFormate();
            s.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation;
            s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
            s.SetDataSource(ds);
            s.SetParameterValue("Class", Connection.GetNextClass(cmbClass.Text.Trim()));
            cr.crystalReportViewer1.ReportSource = s;
            cr.Show();

            //ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptCBSEMarksFrontDetail.xsd"); 
            //CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            //ShowAllReports cr = new ShowAllReports();
            //s = new rptCCEReportFormat2();
            ////s = new MpBoardMarksheet.ReportDesign.rptMPCCMarksheetSHHSSA_Front();
            //s.SetDataSource(ds);
            //cr.crystalReportViewer1.ReportSource = s;
            //cr.crystalReportViewer1.Zoom(75);
            //cr.Show();
        }
        public string GetZOV(string tstr)
        {
            string res = string.Empty;
            if (string.IsNullOrEmpty(tstr))
            {
                res = "0";
            }
            else
            {
                res = tstr;
            }
            return res;
        }

        public void GetMark_I_V()
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].EGetExamMarksDetailFull  " + cmbClass.SelectedValue + "," + school.CurrentSessionCode + "" + cmbScetion.SelectedValue + ",'" + cmbSankay.SelectedValue + "'");
           
            
            
            DataTable dtStudentSkillsDetail = Connection.GetDataTable("Select (Case When t1.ExamCode=0 Then 'TERMI_' When t1.ExamCode=1 Then 'TERMII_' End) AS ExamCode , " +
                " t2.studentno StudentNo,t2.scholarno ScholarNo,t2.Name ,t1.SkillId ,t1.SkillName ,t1.Description ,t1.Grade  From ( " +
                " Select s2.ExamCode,s1.SkillId ,s1.SkillName ,s2.StudentNo ,s2.Description ,s2.Grade ,s2.ClassNo ,s2.SectionCode  From tbl_CCESkills s1,tbl_MPSHHSSAStudentSkills s2 Where s1.SkillId =s2.SkillId And " +
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

                dtTable.Columns.Add("Sub_T" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_TG" + i, typeof(string)); Indexer++;
                dtTable.Columns["Sub_TG" + i].DefaultValue = "E";
            }
            for (int j = 18; j < dtStudentMarksDetail.Columns.Count; j++)
            {
                string Sub = dtStudentMarksDetail.Columns[j].ColumnName;
                for (int i = 1; i <= 10; i++)
                {
                    dtTable.Columns.Add("Sub_" + i + "_" + Sub, typeof(string)); Indexer++;
                    dtTable.Columns.Add("Sub_" + i + "_G" + Sub, typeof(string)); Indexer++;
                    dtTable.Columns["Sub_" + i + "_G" + Sub].DefaultValue = "E";

                }
            }
            for (int r = 0; r < 2; r++)
            {
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tmp1 = 0; int C = 0; int E = 0, tano = 0;
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
                            tano = 0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                                if (GetGrade == 18)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 70);
                                if (GetGrade == 19)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 50);
                                if (GetGrade == 20)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 100);
                                if (Student_C[C][Sub].Equals(DBNull.Value))
                                {
                                    // --
                                }
                                else
                                    tano = tano + (Convert.ToInt16(Student_C[C][Sub]));
                            }
                            NewRow["Sub_T" + k] = tano.ToString();
                            NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                        }
                        else if (C < 6 && tmp1 != 0)
                        {
                            if (C < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_C[C]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_C[C]["SubjectName"];
                                tano = 0;
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                                    if (GetGrade == 18)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 70);
                                    if (GetGrade == 19)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 50);
                                    if (GetGrade == 20)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 100);

                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                        tano = tano + (Convert.ToInt16(Student_C[C][Sub]));
                                }
                                NewRow["Sub_T" + k] = tano.ToString();
                                NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
                            tano = 0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                if (GetGrade == 18)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 70);
                                if (GetGrade == 19)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 50);
                                if (GetGrade == 20)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 100);
                                if (Student_E[E][Sub].Equals(DBNull.Value))
                                {
                                    // --
                                }
                                else
                                    tano = tano + (Convert.ToInt16(Student_E[E][Sub]));
                            }
                            NewRow["Sub_T" + k] = tano.ToString();
                            NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                        }
                        else if (E < 4 && tmp1 != 0)
                        {
                            if (E < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_E[E]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_E[E]["SubjectName"];
                                tano = 0;
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                    if (GetGrade == 18)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 70);
                                    if (GetGrade == 19)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 50);
                                    if (GetGrade == 20)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 100);
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                        tano = tano + (Convert.ToInt16(Student_E[E][Sub]));
                                }
                                NewRow["Sub_T" + k] = tano.ToString();
                                NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
            DataTable dtschool = Connection.GetDataTable("SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,logoimage,HOESIGN,PRINSIGN ,(select top 1 DATEADD(YY,1,s_from) from tbl_session where SessionStatus=1) as NODate FROM tbl_school");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtTable);
            ds.Tables.Add(dtschool);
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\dsMPCCMarksheetSHHSSA_Back.xsd");
            int a = dtTable.Columns.Count;
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            s = new MpBoardMarksheet.ReportDesign.rptMPCCMarksheetSHHSSA_Back_A();
            s.SetDataSource(ds);
            ShowAllReports cr = new ShowAllReports();
            cr.crystalReportViewer1.ReportSource = s;
            s.SetParameterValue("NCLASS", Connection.GetNextClass(cmbClass.Text.Trim()));
            cr.Show();
        }
        public void GetMark_VI_VIII()
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail_SHHSSA] " + cmbClass.SelectedValue + "," + cmbScetion.SelectedValue + "," + school.CurrentSessionCode + ",'M','" + cmbSankay.Text.ToString() + "'");
            DataTable dtStudentSkillsDetail = Connection.GetDataTable("Select (Case When t1.ExamCode=0 Then 'TERMI_' When t1.ExamCode=1 Then 'TERMII_' End) AS ExamCode , " +
                " t2.studentno StudentNo,t2.scholarno ScholarNo,t2.Name ,t1.SkillId ,t1.SkillName ,t1.Description ,t1.Grade  From ( " +
                " Select s2.ExamCode,s1.SkillId ,s1.SkillName ,s2.StudentNo ,s2.Description ,s2.Grade ,s2.ClassNo ,s2.SectionCode  From tbl_CCESkills s1,tbl_MPSHHSSAStudentSkills s2 Where s1.SkillId =s2.SkillId And " +
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

                dtTable.Columns.Add("Sub_T" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_TG" + i, typeof(string)); Indexer++;
                dtTable.Columns["Sub_TG" + i].DefaultValue = "E";
            }
            for (int j = 18; j < dtStudentMarksDetail.Columns.Count; j++)
            {
                string Sub = dtStudentMarksDetail.Columns[j].ColumnName;
                for (int i = 1; i <= 10; i++)
                {
                    dtTable.Columns.Add("Sub_" + i + "_" + Sub, typeof(string)); Indexer++;
                    dtTable.Columns.Add("Sub_" + i + "_G" + Sub, typeof(string)); Indexer++;
                    dtTable.Columns["Sub_" + i + "_G" + Sub].DefaultValue = "E";

                }
            }
            for (int r = 0; r < 2; r++)
            {
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tmp1 = 0; int C = 0; int E = 0, tano = 0;
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
                            tano = 0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                                if (GetGrade == 18)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 70);
                                if (GetGrade == 19)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 50);
                                if (GetGrade == 20)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 100);
                                if (Student_C[C][Sub].Equals(DBNull.Value))
                                {
                                    // --
                                }
                                else
                                    tano = tano + (Convert.ToInt16(Student_C[C][Sub]));
                            }
                            NewRow["Sub_T" + k] = tano.ToString();
                            NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                        }
                        else if (C < 6 && tmp1 != 0)
                        {
                            if (C < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_C[C]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_C[C]["SubjectName"];
                                tano = 0;
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                                    if (GetGrade == 18)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 70);
                                    if (GetGrade == 19)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 50);
                                    if (GetGrade == 20)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 100);
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                        tano = tano + (Convert.ToInt16(Student_C[C][Sub]));
                                }
                                NewRow["Sub_T" + k] = tano.ToString();
                                NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
                            tano = 0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                if (GetGrade == 18)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 70);
                                if (GetGrade == 19)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 50);
                                if (GetGrade == 20)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 100);
                                if (Student_E[E][Sub].Equals(DBNull.Value))
                                {
                                    // --
                                }
                                else
                                    tano = tano + (Convert.ToInt16(Student_E[E][Sub]));
                            }
                            NewRow["Sub_T" + k] = tano.ToString();
                            NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                        }
                        else if (E < 4 && tmp1 != 0)
                        {
                            if (E < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_E[E]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_E[E]["SubjectName"];
                                tano = 0;
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                    if (GetGrade == 18)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 70);
                                    if (GetGrade == 19)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 50);
                                    if (GetGrade == 20)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 100);
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                        tano = tano + (Convert.ToInt16(Student_E[E][Sub]));
                                }
                                NewRow["Sub_T" + k] = tano.ToString();
                                NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
            DataTable dtschool = Connection.GetDataTable("SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,logoimage,HOESIGN,PRINSIGN ,(select top 1 DATEADD(YY,1,s_from) from tbl_session where SessionStatus=1) as NODate FROM tbl_school");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtTable);
            ds.Tables.Add(dtschool);
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\dsMPCCMarksheetSHHSSA_Back.xsd");
            int a = dtTable.Columns.Count;
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            s = new MpBoardMarksheet.ReportDesign.rptMPCCMarksheetSHHSSA_Back_B();
            s.SetDataSource(ds);
            s.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            ShowAllReports cr = new ShowAllReports();
            cr.crystalReportViewer1.ReportSource = s;
            s.SetParameterValue("NCLASS", Connection.GetNextClass(cmbClass.Text.Trim()));
            cr.Show();
        }
        public void GetMark_IX()
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail_SHHSSA] " + cmbClass.SelectedValue + "," + cmbScetion.SelectedValue + "," + school.CurrentSessionCode + ",'M','" + cmbSankay.Text.ToString() + "'");
            DataTable dtStudentSkillsDetail = Connection.GetDataTable("Select (Case When t1.ExamCode=0 Then 'TERMI_' When t1.ExamCode=1 Then 'TERMII_' End) AS ExamCode , " +
                " t2.studentno StudentNo,t2.scholarno ScholarNo,t2.Name ,t1.SkillId ,t1.SkillName ,t1.Description ,t1.Grade  From ( " +
                " Select s2.ExamCode,s1.SkillId ,s1.SkillName ,s2.StudentNo ,s2.Description ,s2.Grade ,s2.ClassNo ,s2.SectionCode  From tbl_CCESkills s1,tbl_MPSHHSSAStudentSkills s2 Where s1.SkillId =s2.SkillId And " +
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

                dtTable.Columns.Add("Sub_Q10" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_H10" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_A80" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_TQHA" + i, typeof(string)); Indexer++;

            }
            for (int j = 18; j < dtStudentMarksDetail.Columns.Count; j++)
            {
                string Sub = dtStudentMarksDetail.Columns[j].ColumnName;
                for (int i = 1; i <= 10; i++)
                {
                    dtTable.Columns.Add("Sub_" + i + "_" + Sub, typeof(string)); Indexer++;
                    dtTable.Columns.Add("Sub_" + i + "_G" + Sub, typeof(string)); Indexer++;
                    dtTable.Columns["Sub_" + i + "_G" + Sub].DefaultValue = "E";

                }
            }
            for (int r = 0; r < 2; r++)
            {
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tmp1 = 0; int C = 0; int E = 0; decimal tano;
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
                            tano = 0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];

                                NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 100);
                                if (GetGrade == 18)
                                {
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_Q10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 19)
                                {
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_H10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 20)
                                {
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2);
                                        NewRow["Sub_A80" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2)).ToString();
                                    }
                                }

                            }
                            NewRow["Sub_TQHA" + k] = tano.ToString();

                        }
                        else if (C < 6 && tmp1 != 0)
                        {
                            if (C < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_C[C]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_C[C]["SubjectName"];
                                tano = 0;
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 100);
                                    if (GetGrade == 18)
                                    {
                                        if (Student_C[C][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_Q10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 19)
                                    {
                                        if (Student_C[C][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_H10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 20)
                                    {
                                        if (Student_C[C][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2);
                                            NewRow["Sub_A80" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2)).ToString();
                                        }
                                    }

                                }
                                NewRow["Sub_TQHA" + k] = tano.ToString();
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
                            tano = 0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 100);
                                if (GetGrade == 18)
                                {
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_Q10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 19)
                                {
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_H10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 20)
                                {
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2);
                                        NewRow["Sub_A80" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2)).ToString();
                                    }
                                }

                            }
                            NewRow["Sub_TQHA" + k] = tano.ToString();
                        }
                        else if (E < 4 && tmp1 != 0)
                        {
                            if (E < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_E[E]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_E[E]["SubjectName"];
                                tano = 0;
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 100);
                                    if (GetGrade == 18)
                                    {
                                        if (Student_E[E][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_Q10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 19)
                                    {
                                        if (Student_E[E][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_H10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 20)
                                    {
                                        if (Student_E[E][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2);
                                            NewRow["Sub_A80" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2)).ToString();
                                        }
                                    }

                                }
                                NewRow["Sub_TQHA" + k] = tano.ToString();
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
            DataTable dtschool = Connection.GetDataTable("SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,logoimage,HOESIGN,PRINSIGN ,(select top 1 DATEADD(YY,1,s_from) from tbl_session where SessionStatus=1) as NODate FROM tbl_school");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtTable);
            ds.Tables.Add(dtschool);
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\dsMPCCMarksheetSHHSSA_Back_IX.xsd");
            int a = dtTable.Columns.Count;
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            s = new MpBoardMarksheet.ReportDesign.rptMPCCMarksheetSHHSSA_Back_C();
            s.SetDataSource(ds);
            ShowAllReports cr = new ShowAllReports();
            cr.crystalReportViewer1.ReportSource = s;
            s.SetParameterValue("NCLASS", Connection.GetNextClass(cmbClass.Text.Trim()));
            cr.Show();
        }

        public void GetMark_XI()
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail_SHHSSA] " + cmbClass.SelectedValue + "," + cmbScetion.SelectedValue + "," + school.CurrentSessionCode + ",'M','" + cmbSankay.Text.ToString() + "'");
            DataTable dtStudentSkillsDetail = Connection.GetDataTable("Select (Case When t1.ExamCode=0 Then 'TERMI_' When t1.ExamCode=1 Then 'TERMII_' End) AS ExamCode , " +
                " t2.studentno StudentNo,t2.scholarno ScholarNo,t2.Name ,t1.SkillId ,t1.SkillName ,t1.Description ,t1.Grade  From ( " +
                " Select s2.ExamCode,s1.SkillId ,s1.SkillName ,s2.StudentNo ,s2.Description ,s2.Grade ,s2.ClassNo ,s2.SectionCode  From tbl_CCESkills s1,tbl_MPSHHSSAStudentSkills s2 Where s1.SkillId =s2.SkillId And " +
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

                dtTable.Columns.Add("Sub_Q10" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_H10" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_A80" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_PI10" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_PII10" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_PIII80" + i, typeof(string)); Indexer++;
                dtTable.Columns.Add("Sub_TQHA" + i, typeof(string)); Indexer++;

            }
            for (int j = 18; j < dtStudentMarksDetail.Columns.Count; j++)
            {
                string Sub = dtStudentMarksDetail.Columns[j].ColumnName;
                for (int i = 1; i <= 10; i++)
                {
                    dtTable.Columns.Add("Sub_" + i + "_" + Sub, typeof(string)); Indexer++;
                    dtTable.Columns.Add("Sub_" + i + "_G" + Sub, typeof(string)); Indexer++;
                    dtTable.Columns["Sub_" + i + "_G" + Sub].DefaultValue = "E";

                }
            }
            for (int r = 0; r < 2; r++)
            {
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tmp1 = 0; int C = 0; int E = 0; decimal tano, ptano;
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
                            tano = 0; ptano = 0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];

                                NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 100);
                                //--percent
                                if (GetGrade == 18)
                                {
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_Q10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 19)
                                {
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_H10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 20)
                                {
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2);
                                        NewRow["Sub_A80" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2)).ToString();
                                    }
                                }
                                //--end percent
                                //--paractical
                                if (GetGrade == 21)
                                {
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        ptano = ptano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_PI10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 22)
                                {
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        ptano = ptano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_PII10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 23)
                                {
                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        ptano = ptano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2);
                                        NewRow["Sub_PIII80" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2)).ToString();
                                    }
                                }
                                //--end practical

                            }
                            NewRow["Sub_TQHA" + k] = (tano+ptano).ToString();

                        }
                        else if (C < 6 && tmp1 != 0)
                        {
                            if (C < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_C[C]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_C[C]["SubjectName"];
                                tano = 0; ptano = 0;
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 100);
                                    if (GetGrade == 18)
                                    {
                                        if (Student_C[C][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_Q10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 19)
                                    {
                                        if (Student_C[C][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_H10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 20)
                                    {
                                        if (Student_C[C][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2);
                                            NewRow["Sub_A80" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2)).ToString();
                                        }
                                    }

                               //--paractical
                                    if (GetGrade == 21)
                                    {
                                        if (Student_C[C][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            ptano = ptano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_PI10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 22)
                                    {
                                        if (Student_C[C][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            ptano = ptano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_PII10" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 23)
                                    {
                                        if (Student_C[C][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            ptano = ptano + Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2);
                                            NewRow["Sub_PIII80" + k] = (Math.Round(((Convert.ToDecimal(Student_C[C][Sub]) * 80) / 100), 2)).ToString();
                                        }
                                    }
                                //--end practical

                            }
                            NewRow["Sub_TQHA" + k] = (tano+ptano).ToString();
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
                            tano = 0;ptano=0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 100);
                                if (GetGrade == 18)
                                {
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_Q10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 19)
                                {
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_H10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 20)
                                {
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2);
                                        NewRow["Sub_A80" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2)).ToString();
                                    }
                                }

                            //--paractical
                                if (GetGrade == 21)
                                {
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        ptano = ptano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_PI10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 22)
                                {
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        ptano = ptano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                        NewRow["Sub_PII10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                    }
                                }
                                if (GetGrade == 23)
                                {
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                    {
                                        ptano = ptano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2);
                                        NewRow["Sub_PIII80" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2)).ToString();
                                    }
                                }
                                //--end practical

                            }
                            NewRow["Sub_TQHA" + k] = (tano+ptano).ToString();
                        }
                        else if (E < 4 && tmp1 != 0)
                        {
                            if (E < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_E[E]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_E[E]["SubjectName"];
                                tano = 0;ptano=0;

                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGrade(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 100);
                                    if (GetGrade == 18)
                                    {
                                        if (Student_E[E][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_Q10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 19)
                                    {
                                        if (Student_E[E][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_H10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 20)
                                    {
                                        if (Student_E[E][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            tano = tano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2);
                                            NewRow["Sub_A80" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2)).ToString();
                                        }
                                    }

                                //--paractical
                                    if (GetGrade == 21)
                                    {
                                        if (Student_E[E][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            ptano = ptano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_PI10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 22)
                                    {
                                        if (Student_E[E][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            ptano = ptano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2);
                                            NewRow["Sub_PII10" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 10) / 100), 2)).ToString();
                                        }
                                    }
                                    if (GetGrade == 23)
                                    {
                                        if (Student_E[E][Sub].Equals(DBNull.Value))
                                        {
                                            // --
                                        }
                                        else
                                        {
                                            ptano = ptano + Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2);
                                            NewRow["Sub_PIII80" + k] = (Math.Round(((Convert.ToDecimal(Student_E[E][Sub]) * 80) / 100), 2)).ToString();
                                        }
                                    }
                                //--end practical

                            }
                            NewRow["Sub_TQHA" + k] = (tano+ptano).ToString();
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
            DataTable dtschool = Connection.GetDataTable("SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,logoimage,HOESIGN,PRINSIGN ,(select top 1 DATEADD(YY,1,s_from) from tbl_session where SessionStatus=1) as NODate FROM tbl_school");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtTable);
            ds.Tables.Add(dtschool);
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\dsMPCCMarksheetSHHSSA_Back_IX.xsd");
            int a = dtTable.Columns.Count;
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            s = new MpBoardMarksheet.ReportDesign.rptMPCCMarksheetSHHSSA_Back_D();
            s.SetDataSource(ds);
            ShowAllReports cr = new ShowAllReports();
            cr.crystalReportViewer1.ReportSource = s;
            s.SetParameterValue("NCLASS", Connection.GetNextClass(cmbClass.Text.Trim()));
            cr.Show();
        }

        public void GetMark_Nursary()
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail_SHHSSA] " + cmbClass.SelectedValue + "," + cmbScetion.SelectedValue + "," + school.CurrentSessionCode + ",'M','" + cmbSankay.Text.ToString() + "'");
            DataTable dtStudentSkillsDetail = Connection.GetDataTable("Select (Case When t1.ExamCode=0 Then 'TERMI_' When t1.ExamCode=1 Then 'TERMII_' End) AS ExamCode , " +
                " t2.studentno StudentNo,t2.scholarno ScholarNo,t2.Name ,t1.SkillId ,t1.SkillName ,t1.Description ,t1.Grade  From ( " +
                " Select s2.ExamCode,s1.SkillId ,s1.SkillName ,s2.StudentNo ,s2.Description ,s2.Grade ,s2.ClassNo ,s2.SectionCode  From tbl_CCESkills s1,tbl_MPSHHSSAStudentSkills s2 Where s1.SkillId =s2.SkillId And " +
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
                    dtTable.Columns.Add("Sub_" + i + "_G" + Sub, typeof(string)); Indexer++;
                    dtTable.Columns["Sub_" + i + "_G" + Sub].DefaultValue = "E";

                }
            }
            for (int r = 0; r < 2; r++)
            {
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
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int tmp1 = 0; int C = 0; int E = 0, tano = 0;
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
                            tano = 0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                                if (GetGrade == 18)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 30);
                                if (GetGrade == 19)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 30);
                                if (GetGrade == 20)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 30);
                                if (Student_C[C][Sub].Equals(DBNull.Value))
                                {
                                    // --
                                }
                                else
                                    tano = tano + (Convert.ToInt16(Student_C[C][Sub]));
                            }
                            //NewRow["Sub_T" + k] = tano.ToString();
                            //NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                        }
                        else if (C < 6 && tmp1 != 0)
                        {
                            if (C < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_C[C]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_C[C]["SubjectName"];
                                tano = 0;
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_C[C][Sub];
                                    if (GetGrade == 18)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 30);
                                    if (GetGrade == 19)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 30);
                                    if (GetGrade == 20)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_C[C][Sub].ToString())), 30);

                                    if (Student_C[C][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                        tano = tano + (Convert.ToInt16(Student_C[C][Sub]));
                                }
                                //NewRow["Sub_T" + k] = tano.ToString();
                                //NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
                            tano = 0;
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                if (GetGrade == 18)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 20);
                                if (GetGrade == 19)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 20);
                                if (GetGrade == 20)
                                    NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 20);
                                if (Student_E[E][Sub].Equals(DBNull.Value))
                                {
                                    // --
                                }
                                else
                                    tano = tano + (Convert.ToInt16(Student_E[E][Sub]));
                            }
                            //NewRow["Sub_T" + k] = tano.ToString();
                            //NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                        }
                        else if (E < 4 && tmp1 != 0)
                        {
                            if (E < tmp1)
                            {
                                NewRow["SubCode_" + k] = Student_E[E]["SubjectCode"];
                                NewRow["Sub_" + k] = Student_E[E]["SubjectName"];
                                tano = 0;
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = Student_E[E][Sub];
                                    if (GetGrade == 18)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 20);
                                    if (GetGrade == 19)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 20);
                                    if (GetGrade == 20)
                                        NewRow["Sub_" + k + "_G" + Sub] = Connection.GetGradePrimary(Convert.ToDecimal(GetZOV(Student_E[E][Sub].ToString())), 20);
                                    if (Student_E[E][Sub].Equals(DBNull.Value))
                                    {
                                        // --
                                    }
                                    else
                                        tano = tano + (Convert.ToInt16(Student_E[E][Sub]));
                                }
                                //NewRow["Sub_T" + k] = tano.ToString();
                                //NewRow["Sub_TG" + k] = Connection.GetGrade(Convert.ToDecimal(tano), 220);
                            }
                            else
                            {
                                for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                                {
                                    string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                                    NewRow["Sub_" + k + "_G" + Sub] = "";
                                }
                            }
                        }
                        else if (tmp1 == 0)
                        {
                            for (int GetGrade = 18; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = "";
                                NewRow["Sub_" + k + "_G" + Sub] = "";
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
            DataTable dtschool = Connection.GetDataTable("SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,logoimage,HOESIGN,PRINSIGN ,(select top 1 DATEADD(YY,1,s_from) from tbl_session where SessionStatus=1) as NODate FROM tbl_school");
            DataSet ds = new DataSet();
            ds.Tables.Add(dtTable);
            ds.Tables.Add(dtschool);
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\dsMPCCMarksheetSHHSSA_Back.xsd");
            int a = dtTable.Columns.Count;
            CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
            s = new MpBoardMarksheet.ReportDesign.rptMPCCMarksheetSHHSSA_Back_E();
            s.SetDataSource(ds);
            ShowAllReports cr = new ShowAllReports();
            cr.crystalReportViewer1.ReportSource = s;
            s.SetParameterValue("NCLASS", Connection.GetNextClass(cmbClass.Text.Trim()));
            cr.Show();
        }
        private void btnBackView_Click(object sender, EventArgs e)
        {
            DataTable dtTable = new DataTable("dtTable");
            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].EGetExamMarksDetailFull  " + cmbClass.SelectedValue + "," + school.CurrentSessionCode + "," + cmbScetion.SelectedValue + ",'" + cmbSankay.SelectedValue + "'");
            DataTable dtExam = dtStudentMarksDetail.DefaultView.ToTable(true, "Exam");
            DataTable dtSubject = dtStudentMarksDetail.DefaultView.ToTable(true, "SubjectCode", "subjectname");
            //DataTable dtStudent = dtStudentMarksDetail.DefaultView.ToTable(true, "scholarno");
            DataTable dtStudent = dtStudentMarksDetail.DefaultView.ToTable(true, "scholarno", "RollNo");


            DataTable dtSkillsDet = Connection.GetDataTable(string.Format("SELECT tbl_CCESkills.SkillId, tbl_CCESkills.SkillName, tbl_MPSHHSSAStudentSkills.Description, tbl_MPSHHSSAStudentSkills.Grade, tbl_MPSHHSSAStudentSkills.ExamCode, tbl_student.scholarno " +
                " FROM tbl_CCESkills INNER JOIN tbl_MPSHHSSAStudentSkills ON tbl_CCESkills.SkillId = tbl_MPSHHSSAStudentSkills.SkillId  INNER JOIN tbl_student ON tbl_MPSHHSSAStudentSkills.StudentNo = tbl_student.studentno "+ 
                " WHERE (tbl_MPSHHSSAStudentSkills.ExamCode in (0,1)) AND (tbl_MPSHHSSAStudentSkills.SessionCode = '{0}') AND (tbl_MPSHHSSAStudentSkills.SectionCode = '{1}') AND  "+
                " (tbl_MPSHHSSAStudentSkills.ClassNo = '{2}')",school.CurrentSessionCode ,cmbScetion.SelectedValue, cmbClass.SelectedValue));

            // CCE Skills Get Value
            try
            {

               // dtStudentCCESkillsLst = Connection.GetDataTable("[dbo].NewExamSkills  " + school.CurrentSessionCode + "," + cmbScetion.SelectedValue + "," + cmbClass.SelectedValue);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
                // throw;
            }


            

            if (dtExam != null)
            {
                #region Exam & Subjects
                for (int i = 0; i < 10; i++)
                {
                    //if (dtExam.Rows.Count > i)
                    {
                        dtTable.Columns.Add("Exam_" + i, typeof(string));
                        {
                            for (int j = 0; j < 11; j++)
                            {
                                // if (dtSubject.Rows.Count > j)
                                {
                                    dtTable.Columns.Add("Exam_" + i + "SubCode_" + j, typeof(string));
                                    dtTable.Columns.Add("Exam_" + i + "Sub_" + j, typeof(string));
                                    dtTable.Columns.Add("Exam_" + i + "MaxMarks_" + j, typeof(decimal));
                                    dtTable.Columns.Add("Exam_" + i + "ObtMarks_" + j, typeof(decimal));
                                    dtTable.Columns.Add("Exam_" + i + "PracMaxMarks_" + j, typeof(decimal));
                                    dtTable.Columns.Add("Exam_" + i + "PracMinMarks_" + j, typeof(decimal));
                                    dtTable.Columns.Add("Exam_" + i + "PracObtMarks_" + j, typeof(decimal));
                                }
                                //else
                                //{
                                //    break; 
                                //}
                            }
                        }
                    }
                    //else
                    //{
                    //    break;
                    //}
                }
                #endregion
                for (int k = dtStudentMarksDetail.Columns["scholarno"].Ordinal; k < dtStudentMarksDetail.Columns.Count; k++)
                {
                    dtTable.Columns.Add(dtStudentMarksDetail.Columns[k].ColumnName, typeof(object));
                }
                #region Skilles Detail

                DataTable dtskl = Connection.GetDataTable("SELECT SkillId, SkillName, Status FROM tbl_CCESkills WHERE (Status = 1)");

                int indexer = 0;
                while (indexer < 2)
                {
                    for (int k = 0; k < dtskl.Rows.Count; k++)
                    {
                        dtTable.Columns.Add(string.Format("{0}_{1}", dtskl.Rows[k]["SkillName"], indexer), typeof(string));
                    }
                    indexer++;
                }

                #endregion

                foreach (DataRow std in dtStudent.Rows)
                {
                    DataRow rw = dtTable.NewRow();
                    for (int i = 0; i < 10; i++)
                    {
                        if (dtExam.Rows.Count > i)
                        {
                            rw["Exam_" + i] = dtExam.Rows[i][0];
                            {
                                for (int j = 0; j < 11; j++)
                                {
                                    if (dtSubject.Rows.Count > j)
                                    {
                                        rw["Exam_" + i + "SubCode_" + j] = dtSubject.Rows[j][0];
                                        rw["Exam_" + i + "Sub_" + j] = dtSubject.Rows[j][1];
                                        DataRow[] row = dtStudentMarksDetail.Select("scholarno ='" + std["scholarno"] + "' and Exam ='" +
                                            dtExam.Rows[i]["Exam"] + "' and subjectname ='" + dtSubject.Rows[j]["subjectname"] + "'");
                                        if (row.Length > 0)
                                        {
                                            //var vv = dtExam.Rows[i][0];
                                            // var ass = row.CopyToDataTable().Select("Exam = " + dtExam.Rows[i][0]);
                                            rw["Exam_" + i + "MaxMarks_" + j] = row[0]["MaxMarks"];
                                            rw["Exam_" + i + "ObtMarks_" + j] = row[0]["MarksObtained"];
                                            rw["Exam_" + i + "PracMaxMarks_" + j] = row[0]["PractMax"];
                                            rw["Exam_" + i + "PracMinMarks_" + j] = row[0]["PractMin"];
                                            rw["Exam_" + i + "PracObtMarks_" + j] = row[0]["PractMarks"];
                                        }
                                    }
                                    else
                                    {
                                        ///break;
                                    }
                                }
                            }
                            foreach (DataRow r in dtskl.Rows)
                            {
                                DataRow[] res = dtSkillsDet.Select("ExamCode='" + i + "' and scholarno ='" + std["scholarno"] + "' and  SkillName ='" + r["SkillName"] + "'");
                                if (res.Length > 0)
                                    rw[string.Format("{0}_{1}", r["SkillName"], i)] = res[0]["Grade"];
                            }
                        }
                        else
                        {
                            ///break;
                        }
                    }
                    DataRow[] det = dtStudentMarksDetail.Select("scholarno ='" + std["scholarno"] + "'");
                    // Main Work done by Sir
                    //for (int k = dtTable.Columns["scholarno"].Ordinal; k <= dtTable.Columns["ExamId"].Ordinal; k++)
                    //{
                    //    rw[k] = det[0][dtTable.Columns[k].ColumnName];
                    //}
                    for (int k = dtTable.Columns["scholarno"].Ordinal; k <= dtTable.Columns["RollNo"].Ordinal; k++)
                    {
                        rw[k] = det[0][dtTable.Columns[k].ColumnName];
                    }
                    dtTable.Rows.Add(rw);
                    int x = dtTable.Rows.Count;
                }

                DataTable dtschool = Connection.GetDataTable("SELECT schoolname,schooladdress,schoolcity,schoolphone,affiliate_by,principal,registrationno,SchoolCode,logoimage,HOESIGN,PRINSIGN ,(select top 1 DATEADD(YY,1,s_from) from tbl_session where SessionStatus=1) as NODate FROM tbl_school");
                DataSet ds = new DataSet();
                ds.Tables.Add(dtTable);
                ds.Tables.Add(dtschool);
                //ds.Tables.Add(dtStudentCCESkillsLst);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\NewFormated.xsd");

                int a = dtTable.Columns.Count;
                CrystalDecisions.CrystalReports.Engine.ReportDocument s = null;
                if (cmbClass.Text.Trim().Equals("IX") || cmbClass.Text.Trim().Equals("IXHM") || cmbClass.Text.Trim().Equals("IXEM") || cmbClass.Text.Trim().Equals("X"))
            {
                if (ttype.Equals("MPCON"))
                    s = new MpBoardMarksheet.ReportDesign.rptMPCONIX();
                if(ttype.Equals("RNCON") )
                    s = new MpBoardMarksheet.ReportDesign.rptRNCONV();
                if (ttype.Equals("EVEREST"))
                    s = new MpBoardMarksheet.ReportDesign.EverestNewIX();
            }
            else if (cmbClass.Text.Trim().Equals("I") || cmbClass.Text.Trim().Equals("II") || cmbClass.Text.Trim().Equals("III") || cmbClass.Text.Trim().Equals("IV")
                  || cmbClass.Text.Trim().Equals("V")  || cmbClass.Text.Trim().Equals("IIIHM") || cmbClass.Text.Trim().Equals("IVHM")
                  || cmbClass.Text.Trim().Equals("VHM") || cmbClass.Text.Trim().Equals("IIIEM") || cmbClass.Text.Trim().Equals("IVEM")
                  || cmbClass.Text.Trim().Equals("VEM"))
            {
                if (ttype.Equals("MPCON"))
                    s = new MpBoardMarksheet.ReportDesign.rptSArvodaya1();
                if (ttype.Equals("RNCON"))
                    s = new MpBoardMarksheet.ReportDesign.rptRNCONV();
                  if (ttype.Equals("EVEREST"))
                      s = new MpBoardMarksheet.ReportDesign.EverestNew();
            }
                else if (cmbClass.Text.Trim().Equals("VI") || cmbClass.Text.Trim().Equals("VII") || cmbClass.Text.Trim().Equals("VIII") || cmbClass.Text.Trim().Equals("VIHM") || cmbClass.Text.Trim().Equals("VIIHM") || cmbClass.Text.Trim().Equals("VIIIHM") || cmbClass.Text.Trim().Equals("VIEM") || cmbClass.Text.Trim().Equals("VIIEM") || cmbClass.Text.Trim().Equals("VIIIEM"))
            {
                if (ttype.Equals("MPCON"))
                    s = new MpBoardMarksheet.ReportDesign.rptSArvodaya6();
                if (ttype.Equals("RNCON"))
                    s = new MpBoardMarksheet.ReportDesign.rptRNCONIX();
                if (ttype.Equals("EVEREST"))
                    s = new MpBoardMarksheet.ReportDesign.EverestNew();
            }
                else if (cmbClass.Text.Trim().Equals("L.K.G.") || cmbClass.Text.Trim().Equals("U.K.G.") || cmbClass.Text.Trim().Equals("NUR") || cmbClass.Text.Trim().Equals("LKG") || cmbClass.Text.Trim().Equals("UKG") || cmbClass.Text.Trim().Equals("NURSERY") || cmbClass.Text.Trim().Equals("IHM") || cmbClass.Text.Trim().Equals("IIHM") || cmbClass.Text.Trim().Equals("IEM") || cmbClass.Text.Trim().Equals("IIEM"))
                {
                    if (ttype.Equals("MPCON"))
                        s = new MpBoardMarksheet.ReportDesign.rptSArvodayaLKGNUR();
                    if (ttype.Equals("RNCON"))
                        s = new MpBoardMarksheet.ReportDesign.RNNURLKG();
                    if (ttype.Equals("EVEREST"))
                        s = new MpBoardMarksheet.ReportDesign.EverestNewNur();
                }
            else
            {
                if (ttype.Equals("MPCON"))
                    s = new MpBoardMarksheet.ReportDesign.rptSArvodaya11();
                if (ttype.Equals("RNCON"))
                    s = new MpBoardMarksheet.ReportDesign.rptRNCONIX();
                if (ttype.Equals("EVEREST"))
                    s = new MpBoardMarksheet.ReportDesign.EverestNew();
            }
                //s = new MpBoardMarksheet.ReportDesign.rptMPCONVIII();
                s.PrintOptions.PaperOrientation = PaperOrientation.DefaultPaperOrientation;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                s.SetDataSource(ds);
                ShowAllReports cr = new ShowAllReports();
                s.SetParameterValue("NCLASS", Connection.GetNextClass(cmbClass.Text.Trim()));
                cr.crystalReportViewer1.ReportSource = s;
                cr.Show();


             }
        }

    

            //if (Convert.ToInt16(cmbClass.SelectedValue) >= 101 && Convert.ToInt16(cmbClass.SelectedValue) < 106)
            //    GetMark_I_V();
            //else if (Convert.ToInt16(cmbClass.SelectedValue) >= 106 && Convert.ToInt16(cmbClass.SelectedValue) < 109)
            //    GetMark_VI_VIII();
            //else if (Convert.ToInt16(cmbClass.SelectedValue) == 109)
            //    GetMark_IX();
            //else if (Convert.ToInt16(cmbClass.SelectedValue) == 111)
            //    GetMark_XI();
            //else
            //    GetMark_Nursary();

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

        //private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        Connection.FillComboBox(cmbScetion, "SELECT tbl_class.sectioncode, tbl_section.sectionname FROM tbl_classmaster INNER JOIN  " +
        //            " tbl_class ON tbl_classmaster.classcode = tbl_class.classcode INNER JOIN tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode WHERE (tbl_classmaster.classcode = '" + cmbClass.SelectedValue + "') order by tbl_section.sectionname ");

        //        if (Convert.ToInt32(cmbClass.SelectedValue.ToString()) > 110 && Convert.ToInt32(cmbClass.SelectedValue.ToString()) < 113)
        //        {
        //            cmbSankay.DataSource = null;
        //            Connection.FillCombo(ref cmbSankay, " select sankayname from tbl_sankay  WHERE     (sankayname != 'Common') order by sankayname");
        //            cmbSankay.SelectedIndex = 0;
        //        }
        //        else
        //        {
        //            cmbSankay.DataSource = null;
        //            Connection.FillCombo(ref cmbSankay, " SELECT     sankayname   FROM         tbl_sankay  WHERE     (sankayname = 'Common')  order by sankayname");
        //            cmbSankay.SelectedIndex = 0;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private void frmMPCCMarksheetSHHSSA_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}
