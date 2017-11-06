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
    public partial class frmMPCCEMarkSheet : UserControl
    {
        public frmMPCCEMarkSheet()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        SqlDataReader dataReader = null;
        bool NonPrimaryFlage;
        public static decimal PerT1,PerT2,PerT3;
        public static int T1, T2, T3;
        private void btnViewReport_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Connection.GetDataSet("SELECT tbl_session.sessioncode, tbl_session.sessionname, tbl_student.studentno, tbl_student.scholarno,'Mast/Miss '+ tbl_student.name as name , 'Mr. '+ tbl_student.father as father, " +
                    "  'Mrs. '+ tbl_student.mother as mother,REPLACE(CONVERT(CHAR(15), tbl_student.dob, 106),' ','-') as dob,tbl_student.Wdob, tbl_student.C_address, tbl_student.m_tongue, tbl_student.casttype, tbl_student.bloodgroup,tbl_student.Height,tbl_student.Width,tbl_student.VisionL,tbl_student.VisionR,tbl_student.Teeth ,tbl_student.OHygiene,tbl_student.House,CASE WHEN tbl_student.CGPA IS NULL or tbl_student.CGPA='' THEN '..........' ELSE tbl_student.CGPA END as CGPA,CASE WHEN tbl_student.OGrade IS NULL or tbl_student.OGrade='' THEN '..........' ELSE tbl_student.OGrade END as OGrade, tbl_classstudent.stdtype,tbl_student.studentimage,  " +
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
            if (cmbClass.Text.Trim().Equals("IX") || cmbClass.Text.Trim().Equals("X"))
            {
                s = new rptCCEMarkFrontEnd();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLegal;
            }
            else if (cmbClass.Text.Trim().Equals("I") || cmbClass.Text.Trim().Equals("II") || cmbClass.Text.Trim().Equals("III") || cmbClass.Text.Trim().Equals("IV")
                || cmbClass.Text.Trim().Equals("V") || cmbClass.Text.Trim().Equals("VI") || cmbClass.Text.Trim().Equals("VII") || cmbClass.Text.Trim().Equals("VIII"))
            {
                s = new MpBoardMarksheet.ReportDesign.rptMPCCEReportFrontFormat2();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            }
            else
            {
                s = new rptCCEReportFormat3();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
            }
           
            s.SetDataSource(ds);
            ShowAllReports cr = new ShowAllReports();
            cr.crystalReportViewer1.ReportSource = s;
            cr.Show();
        }

        private void btnBackView_Click(object sender, EventArgs e)
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            this.NonPrimaryFlage = Convert.ToBoolean(Connection.GetExecuteScalar("Select NonPrimary From tbl_ClassMaster Where ClassCode = '" + cmbClass.SelectedValue + "'"));

            DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail] " + cmbClass.SelectedValue + "," + cmbScetion.SelectedValue + "," + school.CurrentSessionCode + "");
            DataTable dt = dtStudentMarksDetail.DefaultView.ToTable(true, "SessionCode", "StudentNo", "ScholarNo");
            dtTable.Columns.Add("SessionCode", typeof(int)); Indexer++;
            dtTable.Columns.Add("ScholarNo", typeof(string)); Indexer++;
            dtTable.Columns.Add("Name", typeof(string)); Indexer++;
            for (int i = 1; i <= 14; i++)
            {
                dtTable.Columns.Add("SubCode_" + i, typeof(string)); Indexer++;
                dtTable.Columns["SubCode_" + i].DefaultValue = "00";
                dtTable.Columns.Add("Sub_" + i, typeof(string)); Indexer++;
            }
            for (int j = 9; j < dtStudentMarksDetail.Columns.Count; j++)
            {
                string Sub = dtStudentMarksDetail.Columns[j].ColumnName;
                for (int i = 1; i <= 14; i++)
                {
                    dtTable.Columns.Add("Sub_" + i + "_" + Sub, typeof(string)); Indexer++;
                }
            }


            int tk = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PerT1 = 0; PerT2 = 0; PerT3 = 0;
                T1 =T2 =T3 = 0;
                DataRow[] Student = dtStudentMarksDetail.Select("StudentNo='" + dt.Rows[i]["StudentNo"] + "' And ScholarNo='" + dt.Rows[i]["ScholarNo"] + "'");
                DataRow NewRow = dtTable.NewRow();
                NewRow["SessionCode"] = Student[0]["SessionCode"]; 
                NewRow["ScholarNo"] = Student[0]["ScholarNo"]; 
                NewRow["Name"] = Student[0]["Name"];
                for (int k = 1; k <= 14; k++)
                {
                    if (k <= Student.Length - 4)
                    {
                        
                            NewRow["SubCode_" + k] = Student[k - 1]["SubjectCode"];
                            NewRow["Sub_" + k] = Student[k - 1]["SubjectName"];
                        
                            for (int GetGrade = 9; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                            {
                                string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                                NewRow["Sub_" + k + "_" + Sub] = Student[k - 1][Sub];
                                if (Sub == "TERMI")
                                {
                                    if (Student[k - 1][Sub].Equals(DBNull.Value) || Student[k - 1][Sub].Equals(string.Empty))
                                    {
                                        //-----------do something
                                    }
                                    else
                                    {
                                    PerT1 = PerT1 + Convert.ToDecimal(Student[k - 1][Sub]);
                                        if(Convert.ToDecimal(Student[k - 1][Sub])<34)
                                            T1=1;
                                    }
                                }
                                if (Sub == "TERMII")
                                {
                                    if (Student[k - 1][Sub].Equals(DBNull.Value) || Student[k - 1][Sub].Equals(string.Empty))
                                    {
                                        //-----------do something
                                    }
                                    else
                                    {
                                        PerT2 = PerT2 + Convert.ToDecimal(Student[k - 1][Sub]);
                                        if(Convert.ToDecimal(Student[k - 1][Sub])<34)
                                            T2=1;
                                    }
                                }
                                if (Sub == "TERMIII")
                                {
                                    if (Student[k - 1][Sub].Equals(DBNull.Value) || Student[k - 1][Sub].Equals(string.Empty))
                                    {
                                        //-----------do something
                                    }
                                    else
                                    {
                                        PerT3 = PerT3 + Convert.ToDecimal(Student[k - 1][Sub]);
                                        if(Convert.ToDecimal(Student[k - 1][Sub])<34)
                                            T3=1;
                                    }
                                }
                            }
                      
                    }
                    else if (k > Student.Length - 4 && k <= 6)
                    {
                        for (int GetGrade = 9; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                        {
                            string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                            NewRow["Sub_" + k + "_" + Sub] = "";
                        }
                    }
                    else if (k > 6 &&k<=10)
                    {
                        if (tk == 0)
                        {
                            tk = Student.Length - 4;
                            tk =  tk + 1;
                        }
                        else
                        {
                            tk++;
                        }
                        NewRow["SubCode_" + k] = Student[tk - 1]["SubjectCode"];
                        NewRow["Sub_" + k] = Student[tk - 1]["SubjectName"];

                        for (int GetGrade = 9; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                        {
                            string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                            NewRow["Sub_" + k + "_" + Sub] = Student[tk - 1][Sub];
                        }
                    }
                    else if (k ==11)
                    {
                        tk = Student.Length - 4;
                        for (int GetGrade = 9; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                        {
                            string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;

                            if (Sub == "TERMI")
                            {
                                if (PerT1 > 0)
                                    NewRow["Sub_" + k + "_" + Sub] = Math.Round(((PerT1 * 100) / (tk * 100)), 2);
                                else
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                            }

                            if (Sub == "TERMII")
                            {
                                if (PerT2 > 0)
                                    NewRow["Sub_" + k + "_" + Sub] = Math.Round(((PerT2 * 100) / (tk * 100)), 2);
                                else
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                            }
                            if (Sub == "TERMIII")
                            {
                                if (PerT3 > 0)
                                   NewRow["Sub_" + k + "_" + Sub] = Math.Round(((PerT3 * 100) / (tk * 100)), 2);
                                else
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                            }
                           
                                
                        }
                    }
                    else if (k == 12)
                    {
                        for (int GetGrade = 9; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                        {
                            string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                            if(Sub=="TERMI")
                                NewRow["Sub_" + k + "_" + Sub] = Sub+" TEACHER REMARK";
                            if (Sub == "TERMII")
                                NewRow["Sub_" + k + "_" + Sub] = Sub + " TEACHER REMARK";
                            if (Sub == "TERMIII")
                                NewRow["Sub_" + k + "_" + Sub] = Sub + " TEACHER REMARK";
                        }
                    }
                    else if (k == 13)
                    {
                        for (int GetGrade = 9; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                        {
                            string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                            if (Sub == "TERMI")
                            {
                                if (PerT1 > 0)
                                    NewRow["Sub_" + k + "_" + Sub] = PerT1;
                                else
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                            }
                                
                            if (Sub == "TERMII")
                            {
                                if (PerT2 > 0)
                                    NewRow["Sub_" + k + "_" + Sub] = PerT2;
                                else
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                            }
                            if (Sub == "TERMIII")
                            {
                                if (PerT3 > 0)
                                    NewRow["Sub_" + k + "_" + Sub] = PerT3;
                                else
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                            }
                        }
                    }
                    else if (k == 14)
                    {
                        for (int GetGrade = 9; GetGrade < dtStudentMarksDetail.Columns.Count; GetGrade++)
                        {
                            string Sub = dtStudentMarksDetail.Columns[GetGrade].ColumnName;
                            if (Sub == "TERMI")
                            {
                                if(PerT1 > 0)
                                    NewRow["Sub_" + k + "_" + Sub] = (PerT1 > 0 && T1 == 0) ? "Pass" : "Fail";
                                else
                                    NewRow["Sub_" + k + "_" + Sub] = "";

                            }
                            if (Sub == "TERMII")
                            {
                                if (PerT2 > 0)
                                    NewRow["Sub_" + k + "_" + Sub] = (PerT2 > 0 && T2 == 0) ? "Pass" : "Fail";
                                else
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                            }
                            if (Sub == "TERMIII")
                            {
                                if (PerT3 > 0)
                                    NewRow["Sub_" + k + "_" + Sub] = (PerT3 > 0 && T3 == 0) ? "Pass" : "Fail";
                                else
                                    NewRow["Sub_" + k + "_" + Sub] = "";
                            }
                        }
                    }
                }
                dtTable.Rows.Add(NewRow);
            }

            dtTable.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptMPCBSEMarksBackDetail.xsd");
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
                s = new MpBoardMarksheet.ReportDesign.rptMPCCEReportBackFormat2();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            }
            else
            {
                s = new rptCCEReportBackFormat3();
                s.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                s.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA3;
            }

            s.SetDataSource(dtTable);
            ShowAllReports cr = new ShowAllReports();
            s.SetParameterValue("class", cmbClass.Text.Trim());
            s.SetParameterValue("nclass", Connection.GetNextClass(cmbClass.Text.Trim()));
            s.SetParameterValue("nsession", Connection.GetNextSeesion());
            cr.crystalReportViewer1.ReportSource = s;
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

        private void frmMPCCEMarkSheet_Load(object sender, EventArgs e)
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

        private void frmMPCCEMarkSheet_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

    

       
    }
}
