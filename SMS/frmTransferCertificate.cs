using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging ;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class frmTransferCertificate :UserControlBase
    {
        string Format;
        DataView dvStudent;
        public frmTransferCertificate(string Format)
        {
            InitializeComponent(); 
            this.Format = Format;
            Connection.SetUserControlTheme(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dvStudent.RowFilter = "Name Like '"+textBox1.Text.Trim()+"%'";
                dataGridView1.DataSource = this.dvStudent;

                //if (cer == "CR")
                //{
                //    c.getconnstr();
                //    DataSet ds = Connection.GetDataSet("SELECT tbl_student.scholarno, tbl_student.name, tbl_student.father, tbl_classmaster.classname, tbl_section.sectionname FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN  tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode where tbl_classstudent.sessioncode='" + school.CurrentSessionCode.ToString() + "' and tbl_student.name like '" + textBox1.Text + "%' ");
                //    dataGridView1.DataSource = ds.Tables[0];
                //}
            }
            catch (Exception ex)
            {
            }
        }

        private void SearchByName_Load(object sender, EventArgs e)
        {
           
            Connection.FillComboBox(cmbsession, "select SessionCode, SessionName from tbl_Session Order By SessionCode");
            cmbsession.SelectedValue = school.CurrentSessionCode;
            this.dvStudent = Connection.GetDataTable("sp_AllExStudent '" + cmbsession.SelectedValue.ToString() + "'").DefaultView;
            Connection.FillComboBox(cmbPromotClass, "select ClassCode, ClassName from tbl_ClassMaster Order By ClassCode");
            Connection.FillComboBox(cmbAdmissionClass, "select ClassCode, ClassName from tbl_ClassMaster Order By ClassCode");
        } 

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Format.Equals("TC-Format-1"))
            {

                string str = " SELECT     tbl_student .scholarno AS [Scholar No], tbl_student .name AS Name, tbl_student .father AS [Father Name], tbl_student .mother AS [Mother Name],  " +
                    "   tbl_student .RegDate AS [Admission Date], tbl_student .dob AS [Birth Date], tbl_student .phone AS [Contact No],   " +
                    "   tbl_student .m_tongue AS [Mother Tongue], tbl_student .casttype AS Category, tbl_student .bloodgroup AS [Blood Group],   " +
                    "   CASE WHEN tbl_student .sp_challange = 'False' THEN 'No' ELSE 'Yes' END AS [Physically Challanged],  " +
                    "   tbl_student .SubCast AS [Sub-Cast], tbl_student .Cast, tbl_student .Religion, tbl_student .bldgroup AS Medium,   " +
                    "   tbl_student .marr_status AS Gender, tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class, tbl_sankay.sankayname AS Stream,   " +
                    "   tbl_classstudent.stdtype AS Status, tbl_session .sessionname AS Session, tbl_StopDetails.StopName AS [Bus Stop], tbl_tehsil.tehsil AS Tehsil,   " +
                    "   tbl_district.district AS District, tbl_district.statename AS State, tbl_classmaster.classname AS ClassName, tbl_section.sectionname AS SectionName,  " +
                    "   tbl_StudentAttendance.Lectures, tbl_StudentAttendance.PresentDays, tbl_StudentAttendance.Per,tbl_student.SSMId as [SSSM Id]   " +
                    "   FROM         tbl_student AS tbl_student  INNER JOIN  " +
                    "   tbl_classstudent ON tbl_student .studentno = tbl_classstudent.studentno INNER JOIN  " +
                    "   tbl_session AS tbl_session  ON tbl_classstudent.sessioncode = tbl_session .sessioncode INNER JOIN  " +
                    "   tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN  " +
                    "   tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN  " +
                    "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  " +
                    "   tbl_tehsil ON tbl_student .tehcode = tbl_tehsil.tehcode INNER JOIN  " +
                    "   tbl_district ON tbl_tehsil.distcode = tbl_district.distcode LEFT JOIN  " +
                    "   tbl_StudentAttendance ON tbl_student .studentno = tbl_StudentAttendance.StudentNo LEFT OUTER JOIN  " +
                    "   tbl_StopDetails ON tbl_student .BusStopNo = tbl_StopDetails.BusStopNo  " +
                    "   WHERE     (tbl_classstudent.sessioncode = '" + cmbsession.SelectedValue + "') AND (tbl_student .scholarno = '" + txtscholarno.Text.Trim() + "') ; " +

                    "   SELECT     tbl_session.sessionname, tbl_classmaster.classname  " +
                    "   FROM         tbl_student INNER JOIN  " +
                    "   tbl_session ON tbl_student.admsession = tbl_session.sessioncode INNER JOIN  " +
                    "   tbl_classstudent ON tbl_student.admsession = tbl_classstudent.sessioncode AND tbl_student.studentno = tbl_classstudent.studentno INNER JOIN  " +
                    "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode AND tbl_student.scholarno = '" + txtscholarno.Text.Trim() + "'; " +

                "   SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage, Website, logoimage as Watermark, SchoolCode, isnull(TCSrNo,0) as  TCSrNo,isnull(TCBookNo,0) as TCBookNo FROM tbl_school ;";
                DataSet ds = Connection.GetDataSet(str);
                byte[] ByteImage = (byte[])ds.Tables[2].Rows[0]["logoimage"];
                Bitmap bmp = Connection.GetImageFromByteArray(ByteImage);
                bmp = Connection.AdjustContrastOfImage(bmp, 80f);
                byte[] ByteImage1 = Connection.GetByteArrayFromImage(bmp);
                ds.Tables[2].Rows[0]["Watermark"] = Connection.GetByteArrayFromImage(bmp);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\TC.xsd");
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (DialogResult.Yes.Equals(MessageBox.Show("Are you sure io issue Trancefer Certificate for this Student?", "Book No.!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                    {
                        if (Convert.ToInt32(ds.Tables[2].Rows[0]["TCSrNo"]) > 150)
                        {
                            Connection.AllPerform("Update tbl_School Set TCSrNo = 101, TCBookNo = '" + (Convert.ToInt32(ds.Tables[2].Rows[0]["TCBookNo"]) + 1) + "' ");
                        }
                        else
                        {
                            Connection.AllPerform("Update tbl_School Set TCSrNo = '" + (Convert.ToInt32(ds.Tables[2].Rows[0]["TCSrNo"]) + 1) + "' ");
                        }
                        //Connection.AllPerform("Update tbl_Student Set stdtype='Ex-Student' Where ScholarNo='" + txtscholarno.Text.Trim() + "' ");
                        //Connection.AllPerform("Update tbl_classstudent Set stdtype='Ex-Student' Where studentno=dbo.GetStudentNo('" + txtscholarno.Text.Trim() + "') and sessioncode='" + school.CurrentSessionCode + "' ");
                    }
                    rptTCFormat1 fr = new rptTCFormat1();
                    fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    fr.SetDataSource(ds);
                    fr.SetParameterValue("Reason", txtReason.Text.Trim());
                    fr.SetParameterValue("Charecter", txtCharecter.Text.Trim());
                    fr.SetParameterValue("Class", cmbPromotClass.Text.Trim());
                    fr.SetParameterValue("NewSession", cmbsession .Text );      
                    fr.SetParameterValue("Date", dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"));
                    //fr.SetParameterValue("AdmissionClass", cmbAdmissionClass.Text.Trim());
                    //fr.SetParameterValue("NewClass", cmbPromotClass.Text.Trim());
                    //fr.SetParameterValue("NewSession", cmbsession.Text);
                   // fr.SetParameterValue("DateOfApplication", dateTimePicker2.Value.Date.ToString("dd/MM/yyyy"));
                    //fr.SetParameterValue("Remarks", txtRemarks.Text.Trim());
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = fr;
                    s.Show();
                }
            }
            else if (this.Format.Equals("TC-Format-2"))
            {
                string str = " SELECT tbl_student.scholarno AS [Scholar No], tbl_student.name AS Name, tbl_student.SSMId AS SSMId,tbl_student.father AS [Father Name], tbl_student.mother AS [Mother Name],  " +
                      "   Convert(varchar,tbl_student.RegDate,105) AS [Admission Date], Convert(varchar,tbl_student.dob,105) AS [Birth Date],   " +
                      "   tbl_student.phone AS [Contact No], tbl_student.m_tongue AS [Mother Tongue], tbl_student.casttype AS Category, tbl_student.bloodgroup as [Blood Group]," +
                      "   CASE WHEN tbl_student.sp_challange = 'False' THEN 'No' ELSE 'Yes' END AS [Physically Challanged], tbl_student.SubCast AS [Sub-Cast],   " +
                      "   tbl_student.Cast, tbl_student.Religion, tbl_student.bldgroup AS Medium, tbl_student.marr_status AS Gender,   " +
                      "   tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class, tbl_sankay.sankayname AS Stream,tbl_classstudent.stdtype as Status ,tbl_session.sessionname AS Session,   " +
                      "   tbl_StopDetails.StopName AS [Bus Stop], tbl_tehsil.tehsil AS Tehsil, tbl_district.district AS District, tbl_district.statename AS State,tbl_classmaster.classname  as ClassName,tbl_section.sectionname as SectionName  " +
                      "   FROM tbl_student INNER JOIN " +
                      "   tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno INNER JOIN  " +
                      "   tbl_session ON tbl_classstudent.sessioncode = tbl_session.sessioncode INNER JOIN  " +
                      "   tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN  " +
                      "   tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN  " +
                      "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  " +
                      "   tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN  " +
                      "   tbl_district ON tbl_tehsil.distcode = tbl_district.distcode LEFT OUTER JOIN  " +
                      "   tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo  " +
                      "   WHERE (tbl_classstudent.sessioncode = '" + cmbsession.SelectedValue + "') AND (tbl_student.scholarno = '" + txtscholarno.Text.Trim() + "') ";
                str = str + "   SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage, Website, logoimage as Watermark, SchoolCode, isnull(TCSrNo,0) as  TCSrNo,isnull(TCBookNo,0) as TCBookNo FROM tbl_school ";
                DataSet ds = Connection.GetDataSet(str);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\TC.xsd");
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count >0)
                {
                    rptTCFormat4 fr = new rptTCFormat4();
                    fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    fr.SetDataSource(ds);
                    fr.SetParameterValue("Result", txtresult.Text.Trim());
                    fr.SetParameterValue("Attadance", txtpercent.Text.Trim());
                    fr.SetParameterValue("Date", dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"));
                    fr.SetParameterValue("Charecter", txtCharecter.Text.Trim());
                    fr.SetParameterValue("IssueOfApplication", dateTimePicker2.Value.Date.ToString("dd/MM/yyyy"));
                    fr.SetParameterValue("PassedClass", cmbPromotClass.Text.Trim());
                    fr.SetParameterValue("AdmissionClass", cmbAdmissionClass.Text.Trim());
                    fr.SetParameterValue("NewClass", cmbPromotClass.Text.Trim());
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = fr;
                    s.Show();
                }
            }
            else if (this.Format.Equals("TC-Format-3"))
            {
                string str = " SELECT     tbl_student .scholarno AS [Scholar No], tbl_student .name AS Name, tbl_student .father AS [Father Name], tbl_student .mother AS [Mother Name],  "+
                    "   CONVERT(varchar, tbl_student .RegDate, 105) AS [Admission Date], tbl_student .dob AS [Birth Date], tbl_student .phone AS [Contact No],   "+
                    "   tbl_student .m_tongue AS [Mother Tongue], tbl_student .casttype AS Category, tbl_student .bloodgroup AS [Blood Group],   "+
                    "   CASE WHEN tbl_student .sp_challange = 'False' THEN 'No' ELSE 'Yes' END AS [Physically Challanged],  "+
                    "   tbl_student .SubCast AS [Sub-Cast], tbl_student .Cast, tbl_student .Religion, tbl_student .bldgroup AS Medium,   "+
                    "   tbl_student .marr_status AS Gender, tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class, tbl_sankay.sankayname AS Stream,   "+
                    "   tbl_classstudent.stdtype AS Status, tbl_session .sessionname AS Session, tbl_StopDetails.StopName AS [Bus Stop], tbl_tehsil.tehsil AS Tehsil,   " +
                    "   tbl_district.district AS District, tbl_district.statename AS State, tbl_classmaster.classname AS ClassName, tbl_section.sectionname AS SectionName,  "+
                    "   tbl_StudentAttendance.Lectures, tbl_StudentAttendance.PresentDays  "+
                    "   FROM         tbl_student AS tbl_student  INNER JOIN  "+
                    "   tbl_classstudent ON tbl_student .studentno = tbl_classstudent.studentno INNER JOIN  "+
                    "   tbl_session AS tbl_session  ON tbl_classstudent.sessioncode = tbl_session .sessioncode INNER JOIN  "+
                    "   tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN  "+
                    "   tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN  "+
                    "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  "+
                    "   tbl_tehsil ON tbl_student .tehcode = tbl_tehsil.tehcode INNER JOIN  "+
                    "   tbl_district ON tbl_tehsil.distcode = tbl_district.distcode LEFT JOIN  "+
                    "   tbl_StudentAttendance ON tbl_student .studentno = tbl_StudentAttendance.StudentNo LEFT OUTER JOIN  "+
                    "   tbl_StopDetails ON tbl_student .BusStopNo = tbl_StopDetails.BusStopNo  "+
                    "   WHERE     (tbl_classstudent.sessioncode = '"+cmbsession.SelectedValue+"') AND (tbl_student .scholarno = '"+txtscholarno.Text.Trim ()+"') ; "+
                   
                    "   SELECT     tbl_session.sessionname, tbl_classmaster.classname  "+
                    "   FROM         tbl_student INNER JOIN  "+
                    "   tbl_session ON tbl_student.admsession = tbl_session.sessioncode INNER JOIN  "+
                    "   tbl_classstudent ON tbl_student.admsession = tbl_classstudent.sessioncode AND tbl_student.studentno = tbl_classstudent.studentno INNER JOIN  " +
                    "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode AND tbl_student.scholarno = '" + txtscholarno.Text.Trim() + "'; "+

                "     SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage, Website, logoimage as Watermark, SchoolCode, isnull(TCSrNo,0) as  TCSrNo,isnull(TCBookNo,0) as TCBookNo FROM tbl_school ";
                DataSet ds = Connection.GetDataSet(str);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\TC.xsd");
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rptTCFormat4 fr = new rptTCFormat4();
                    fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    fr.SetDataSource(ds);
                    DataTable dt = Connection.GetDataTable("");
                    fr.SetParameterValue("Reason", txtReason.Text.Trim());
                    //fr.SetParameterValue("Charecter", txtCharecter.Text.Trim());
                    fr.SetParameterValue("Date", dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"));
                    fr.SetParameterValue("PassedClass", cmbPromotClass.Text.Trim());
                    fr.SetParameterValue("NewSession", cmbsession .Text);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = fr;
                    s.Show();
                }
            }
            else if (this.Format.Equals("TC-Format-4"))
            {
                string str = " SELECT     tbl_student .scholarno AS [Scholar No], tbl_student .name AS Name, tbl_student .father AS [Father Name], tbl_student .mother AS [Mother Name],  " +
                    "   tbl_student .RegDate AS [Admission Date], tbl_student .dob AS [Birth Date], tbl_student .phone AS [Contact No],   " +
                    "   tbl_student .SSMId AS [SSSMID], tbl_student .ChielId AS [Chiel Id], " +
                    "   tbl_student .m_tongue AS [Mother Tongue], tbl_student .casttype AS Category, tbl_student .bloodgroup AS [Blood Group],   " +
                    "   CASE WHEN tbl_student .sp_challange = 'False' THEN 'No' ELSE 'Yes' END AS [Physically Challanged],  " +
                    "   tbl_student .SubCast AS [Sub-Cast], tbl_student .Cast, tbl_student .Religion, tbl_student .bldgroup AS Medium,   " +
                    "   tbl_student .marr_status AS Gender, tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class, tbl_sankay.sankayname AS Stream,   " +
                    "   tbl_classstudent.stdtype AS Status, tbl_session .sessionname AS Session,(select top 1 s_to  from tbl_session where sessioncode<104 order by sessioncode desc) as s_to, tbl_StopDetails.StopName AS [Bus Stop], tbl_tehsil.tehsil AS Tehsil,   " +
                    "   tbl_district.district AS District, tbl_district.statename AS State, tbl_classmaster.classname AS ClassName, tbl_section.sectionname AS SectionName,  " +
                    "   tbl_StudentAttendance.Lectures, tbl_StudentAttendance.PresentDays, tbl_StudentAttendance.Per  " +
                    "   FROM         tbl_student AS tbl_student  INNER JOIN  " +
                    "   tbl_classstudent ON tbl_student .studentno = tbl_classstudent.studentno INNER JOIN  " +
                    "   tbl_session AS tbl_session  ON tbl_classstudent.sessioncode = tbl_session .sessioncode INNER JOIN  " +
                    "   tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN  " +
                    "   tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN  " +
                    "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  " +
                    "   tbl_tehsil ON tbl_student .tehcode = tbl_tehsil.tehcode INNER JOIN  " +
                    "   tbl_district ON tbl_tehsil.distcode = tbl_district.distcode LEFT JOIN  " +
                    "   tbl_StudentAttendance ON tbl_student .studentno = tbl_StudentAttendance.StudentNo LEFT OUTER JOIN  " +
                    "   tbl_StopDetails ON tbl_student .BusStopNo = tbl_StopDetails.BusStopNo  " +
                    "   WHERE     (tbl_classstudent.sessioncode = '" + cmbsession.SelectedValue + "') AND (tbl_student .scholarno = '" + txtscholarno.Text.Trim() + "') ; " +

                    "   SELECT     tbl_session.sessionname, tbl_session.s_to , tbl_classmaster.classname  " +
                    "   FROM         tbl_student INNER JOIN  " +
                    "   tbl_session ON tbl_student.admsession = tbl_session.sessioncode INNER JOIN  " +
                    "   tbl_classstudent ON tbl_student.admsession = tbl_classstudent.sessioncode AND tbl_student.studentno = tbl_classstudent.studentno INNER JOIN  " +
                    "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode AND tbl_student.scholarno = '" + txtscholarno.Text.Trim() + "'; " +

                "   SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage, Website, logoimage as Watermark, SchoolCode, isnull(TCSrNo,0) as  TCSrNo,isnull(TCBookNo,0) as TCBookNo FROM tbl_school ;";
                DataTable dtSubject = new DataTable("dtSubject");
                int i=1;
                while (i <= 8) { dtSubject.Columns.Add("Subject-" + i); i++; }
                SqlDataReader DataReader =Connection .GetDataReader("SELECT s1.subjectno, s1.subjectname, s1.subjecttype, s1.SubjectCode, s1.SubjectOrder FROM tbl_subject s1, tbl_subwiseclass s2 "+
                    " Where s1.subjectno = s2.subjectno AND s2.classno = "+
                    " (Select c.classno From tbl_student s, tbl_classstudent c Where s.studentno = c.studentno AND c.sessioncode = '"+cmbsession .SelectedValue +"' AND s.scholarno = '"+txtscholarno .Text .Trim ()+"') Order By SubjectOrder ");
                if (DataReader.HasRows)
                {
                    DataRow r = dtSubject.NewRow(); i = 0;
                    while (DataReader.Read())
                    {
                        if (i < 8) 
                            r[i] = DataReader["subjectname"]; i++; 
                    }
                    dtSubject.Rows.Add(r);
                }
                DataSet ds = Connection.GetDataSet(str);
                ds.Tables.Add(dtSubject);
                byte[] ByteImage = (byte[])ds.Tables[2].Rows[0]["logoimage"];
                Bitmap bmp = Connection.GetImageFromByteArray(ByteImage);
                bmp = Connection.AdjustContrastOfImage(bmp,70f); 
                byte[] ByteImage1 = Connection.GetByteArrayFromImage(bmp);
                ds.Tables[2].Rows[0]["Watermark"] = Connection.GetByteArrayFromImage(bmp);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\TC.xsd");
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (DialogResult.Yes.Equals(MessageBox.Show("Are you sure io issue Trancefer Certificate for this Student?", "Book No.!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                    {
                        if (Convert.ToInt32(ds.Tables[2].Rows[0]["TCSrNo"]) > 0)
                        {
                            Connection.AllPerform("Update tbl_School Set TCSrNo = '" + (Convert.ToInt32(ds.Tables[2].Rows[0]["TCSrNo"]) + 1) + "', TCBookNo = '" + (Convert.ToInt32(ds.Tables[2].Rows[0]["TCBookNo"]) + 1) + "' ");
                        }
                        else
                        {
                            Connection.AllPerform("Update tbl_School Set TCSrNo = '" + (Convert.ToInt32(ds.Tables[2].Rows[0]["TCSrNo"]) + 1) + "' ");
                        }
                        Connection.AllPerform("Update tbl_Student Set stdtype='Ex-Student' Where ScholarNo='"+txtscholarno.Text.Trim()+"' ");
                        Connection.AllPerform("Update tbl_classstudent Set stdtype='Ex-Student' Where studentno=dbo.GetStudentNo('" + txtscholarno.Text.Trim() + "') and sessioncode='" + school.CurrentSessionCode + "' ");
                    }
                    rptTCFormat4 fr = new rptTCFormat4();
                    fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    fr.SetDataSource(ds);
                    fr.SetParameterValue("Reason", txtReason.Text.Trim());
                    fr.SetParameterValue("Charecter", txtCharecter.Text.Trim());
                    fr.SetParameterValue("DateOfAdmission", dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"));
                    fr.SetParameterValue("AdmissionClass", cmbAdmissionClass.Text.Trim());
                    fr.SetParameterValue("NewClass", cmbPromotClass.Text.Trim());
                    fr.SetParameterValue("NewSession", cmbsession.Text);
                    fr.SetParameterValue("DateOfIssue", dateTimePicker2.Value.Date.ToString("dd/MM/yyyy"));
                    fr.SetParameterValue("DateOfApplication", dateTimePicker3.Value.Date.ToString("dd/MM/yyyy"));
                    fr.SetParameterValue("Result", txtresult.Text.Trim());
                    fr.SetParameterValue("Remarks", txtRemarks.Text.Trim());
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = fr;
                    s.Show();
                }
            }
            else if (this.Format.Equals("TC-Format-5"))
            {
                string str = " SELECT     tbl_student .scholarno AS [Scholar No],upper( tbl_student .SSMId) AS SSSMID,upper( tbl_student .name) AS Name,upper( tbl_student .father) AS [Father Name], upper(tbl_student .mother) AS [Mother Name],  " +
                    "  convert(nvarchar(10), tbl_student .RegDate,103) AS [Admission Date],upper(tbl_student .Wdob) as Wdob, tbl_student .dob AS [Birth Date], tbl_student .phone AS [Contact No],   " +
                    "   upper(tbl_student .m_tongue) AS [Mother Tongue],upper(tbl_student.C_address) as C_address, upper(tbl_student .casttype) AS Category, tbl_student .bloodgroup AS [Blood Group],   " +
                    "   CASE WHEN tbl_student .sp_challange = 'False' THEN 'No' ELSE 'Yes' END AS [Physically Challanged],  " +
                    "  upper( tbl_student .SubCast) AS [Sub-Cast], upper(tbl_student .Cast) as Cast, upper(tbl_student .Religion) as Religion, upper(tbl_student .bldgroup) AS Medium,   " +
                    "  upper( tbl_student .marr_status) AS Gender,upper( tbl_classmaster.classname + ' ' + tbl_section.sectionname) AS Class, upper(tbl_sankay.sankayname) AS Stream,   " +
                    "   upper(tbl_classstudent.stdtype) AS Status, tbl_session .sessionname AS Session, upper(tbl_StopDetails.StopName) AS [Bus Stop], upper(tbl_tehsil.tehsil) AS Tehsil,   " +
                    "   upper(tbl_district.district) AS District, upper(tbl_district.statename) AS State, upper(tbl_classmaster.classname) AS ClassName,upper( tbl_section.sectionname) AS SectionName,  " +
                    " convert(nvarchar(10), convert(numeric(10,0), tbl_StudentAttendance.Lectures)) as Lectures,convert(nvarchar(10), convert(numeric(10,0), tbl_StudentAttendance.PresentDays)) as PresentDays, tbl_StudentAttendance.Per  " +
                    "   FROM         tbl_student AS tbl_student  INNER JOIN  " +
                    "   tbl_classstudent ON tbl_student .studentno = tbl_classstudent.studentno INNER JOIN  " +
                    "   tbl_session AS tbl_session  ON tbl_classstudent.sessioncode = tbl_session .sessioncode INNER JOIN  " +
                    "   tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN  " +
                    "   tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN  " +
                    "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  " +
                    "   tbl_tehsil ON tbl_student .tehcode = tbl_tehsil.tehcode INNER JOIN  " +
                    "   tbl_district ON tbl_tehsil.distcode = tbl_district.distcode LEFT JOIN  " +
                    "   tbl_StudentAttendance ON tbl_student .studentno = tbl_StudentAttendance.StudentNo LEFT OUTER JOIN  " +
                    "   tbl_StopDetails ON tbl_student .BusStopNo = tbl_StopDetails.BusStopNo  " +
                    "   WHERE     (tbl_classstudent.sessioncode = '" + cmbsession.SelectedValue + "') AND (tbl_student .scholarno = '" + txtscholarno.Text.Trim() + "') ; " +

                    "   SELECT     tbl_session.sessionname,tbl_session.s_to, tbl_classmaster.classname  " +
                    "   FROM         tbl_student INNER JOIN  " +
                    "   tbl_session ON tbl_student.admsession = tbl_session.sessioncode INNER JOIN  " +
                    "   tbl_classstudent ON tbl_student.admsession = tbl_classstudent.sessioncode AND tbl_student.studentno = tbl_classstudent.studentno INNER JOIN  " +
                    "   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode AND tbl_student.scholarno = '" + txtscholarno.Text.Trim() + "'; " +

                "   SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage, Website, logoimage as Watermark, SchoolCode, isnull(TCSrNo,0) as  TCSrNo,isnull(TCBookNo,0) as TCBookNo FROM tbl_school ;";
                DataSet ds = Connection.GetDataSet(str);
                byte[] ByteImage = (byte[])ds.Tables[2].Rows[0]["logoimage"];
                Bitmap bmp = Connection.GetImageFromByteArray(ByteImage);
                bmp = Connection.AdjustContrastOfImage(bmp, 80f);
                byte[] ByteImage1 = Connection.GetByteArrayFromImage(bmp);
                ds.Tables[2].Rows[0]["Watermark"] = Connection.GetByteArrayFromImage(bmp);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\TC.xsd");
                dataGridView1.DataSource = ds.Tables[0];
                if (ds.Tables[0].Rows.Count > 0)
                {

                    if (DialogResult.Yes.Equals(MessageBox.Show("Are you sure io issue Trancefer Certificate for this Student?", "Book No.!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                    {
                        if (Convert.ToInt32(ds.Tables[2].Rows[0]["TCSrNo"]) > 150)
                        {
                            Connection.AllPerform("Update tbl_School Set TCSrNo = 101, TCBookNo = '" + (Convert.ToInt32(ds.Tables[2].Rows[0]["TCBookNo"]) + 1) + "' ");
                        }
                        else
                        {
                            Connection.AllPerform("Update tbl_School Set TCSrNo = '" + (Convert.ToInt32(ds.Tables[2].Rows[0]["TCSrNo"]) + 1) + "' ");
                        }
                        Connection.AllPerform("Update tbl_Student Set stdtype='Ex-Student' Where ScholarNo='" + txtscholarno.Text.Trim() + "' ");
                        Connection.AllPerform("Update tbl_classstudent Set stdtype='Ex-Student' Where studentno=dbo.GetStudentNo('" + txtscholarno.Text.Trim() + "') and sessioncode='" + school.CurrentSessionCode + "' ");
                    }
                    rptTCFormat5 fr = new rptTCFormat5();
                    fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    fr.SetDataSource(ds);
                    //fr.SetParameterValue("Reason", txtReason.Text.Trim());
                    //fr.SetParameterValue("Charecter", txtCharecter.Text.Trim().ToUpper());
                    //fr.SetParameterValue("Date", dateTimePicker1.Text.Trim());
                    //fr.SetParameterValue("TDate", dateTimePicker2.Text.Trim());
                    //fr.SetParameterValue("Class", cmbAdmissionClass.Text.Trim() + " ( " +Connection.GetClassDeails(cmbAdmissionClass.Text.Trim()) + " )");
                    //fr.SetParameterValue("NewClass", cmbPromotClass.Text.Trim() + " ( " + Connection.GetClassDeails(cmbPromotClass.Text.Trim()) + " )");
                    //fr.SetParameterValue("NewSession", cmbsession.Text);
                    //fr.SetParameterValue("Result", txtresult.Text.Trim());
                    //fr.SetParameterValue("Percent", txtpercent.Text.Trim());
                    fr.SetParameterValue("Result", txtresult.Text.Trim());
                    fr.SetParameterValue("Attadance", txtpercent.Text.Trim());
                    fr.SetParameterValue("Date", dateTimePicker1.Value.Date.ToString("dd/MM/yyyy"));
                    fr.SetParameterValue("Charecter", txtCharecter.Text.Trim());
                    fr.SetParameterValue("IssueOfApplication", dateTimePicker2.Value.Date.ToString("dd/MM/yyyy"));
                    fr.SetParameterValue("PassedClass", cmbPromotClass.Text.Trim());
                    fr.SetParameterValue("AdmissionClass", cmbAdmissionClass.Text.Trim());
                    fr.SetParameterValue("NewClass", cmbPromotClass.Text.Trim());
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = fr;
                    s.Show();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtscholarno.Text = row.Cells["Scholar No"].Value.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ////this.Close();
        }

        private void txtscholarno_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtscholarno.Text.Trim()))
            {
                cmbPromotClass.SelectedValue = Connection.GetExecuteScalar("Select ClassNo From tbl_ClassStudent c, tbl_Student s Where c.StudentNo=s.StudentNo "+
                    " And c.SessionCode='"+cmbsession.SelectedValue +"' And s.ScholarNo='"+txtscholarno.Text.Trim()+"'");
            }
        }

        private void frmTransferCertificate_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void cmbsession_Leave(object sender, EventArgs e)
        {
            this.dvStudent = Connection.GetDataTable("sp_AllStudent '" + cmbsession.SelectedValue.ToString() + "'").DefaultView;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.Columns["Photo"].Visible = false;

            }
            catch { }
        }

        
    }
}
