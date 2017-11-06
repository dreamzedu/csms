using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class TempraryResult :UserControlBase
    {
        DataTable dtStudent = new DataTable("dtStudent");
        DataTable dtStudentField = new DataTable("dtStudentField");
        public TempraryResult()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
            if (!string.IsNullOrEmpty(o.FileName))
            {
                //Connection.FullPathOfExcelFile = o.FileName;
                DataSet ds = Connection.GetDataSetFromExcelFile("select *from [Sheet1$]");
                if(ds.Tables[0].Rows .Count >0)
                {
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.ShowDialog();
            if (!string.IsNullOrEmpty(o.FileName))
            {
                //Connection.FullPathOfExcelFile = o.FileName;
                DataSet ds = Connection.GetDataSetFromExcelFile("select *from [Sheet1$]");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridView2.DataSource = ds.Tables[0];
                }
            }
        }

        private void TempraryResult_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(comboBox1, "Select ClassCode, ClassName From tbl_ClassMaster Order By ClassCode");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int i = 0;
            if(dataGridView1.RowCount >0)
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                if (r.Cells[0].Value != null  && r.Cells[0].Value != "")
                {
                    Connection.AllPerform(" INSERT INTO [dbTemprary].[dbo].[tblStudent] ([ScholarNo] ,[Name] ,[Subject] ,[Jul] ,[Aug] " +
                        " ,[Sept] ,[Oct],[HY] ,[Dec] ,[Jan] ,[Feb] ,[Annual],[FinalGrade],[Attendance],[sssmid],[Class] ) " +
                        " VALUES ('" + r.Cells[0].Value + "','" + r.Cells[1].Value + "','EVS','" + r.Cells[2].Value + "' ," +
                        " '" + r.Cells[3].Value + "','" + r.Cells[4].Value + "','" + r.Cells[5].Value + "','" + r.Cells[6].Value + "','" + r.Cells[7].Value + "' " +
                        " ,'" + r.Cells[8].Value + "','" + r.Cells[9].Value + "','" + r.Cells[10].Value + "','" + r.Cells[11].Value + "','" + r.Cells[12].Value + "','" + r.Cells[13].Value + "','" + comboBox1.Text + "')");
                    i = r.Index;
                }
            }
            MessageBox.Show(i + " Record Saved.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (dataGridView2.RowCount > 0)
            foreach (DataGridViewRow r in dataGridView2.Rows)
            {
                Connection.AllPerform(" INSERT INTO [dbTemprary].[dbo].[tblF1] ([ScholarNo] ,[Name] ,[Literary] ,[Cultural] " +
                    " ,[Science] ,[Creativity] ,[Sprot] ,[Annual] ,[FinalGrade],[Class]) " +
                    " VALUES ('" + r.Cells[0].Value + "','" + r.Cells[1].Value + "','" + r.Cells[2].Value + "' ," +
                    " '" + r.Cells[3].Value + "','" + r.Cells[4].Value + "','" + r.Cells[5].Value + "','" + r.Cells[6].Value + "','" + r.Cells[7].Value + "' " +
                    " ,'" + r.Cells[8].Value + "','" + comboBox1 .Text + "')");
                i = r.Index;
            }
            MessageBox.Show(i + " Record Saved.");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (dataGridView2.RowCount > 0)
                foreach (DataGridViewRow r in dataGridView2.Rows)
                {
                    Connection.AllPerform(" INSERT INTO [dbTemprary].[dbo].[tblF2] ([ScholarNo] ,[Name] ,[Regularity] ,[Punctuality] ,[Cleanliness]  "+
                        " ,[Discipline] ,[CoOperation] ,[Environment] ,[Leadership] ,[Truthfulness] ,[Honesty] ,[Nature] ,[Annual] ,[FinalGrade] ,[Class]) "+
                        " VALUES ('" + r.Cells[0].Value + "','" + r.Cells[1].Value + "','" + r.Cells[2].Value + "' ," +
                        " '" + r.Cells[3].Value + "','" + r.Cells[4].Value + "','" + r.Cells[5].Value + "','" + r.Cells[6].Value + "','" + r.Cells[7].Value + "' " +
                        " ,'" + r.Cells[8].Value + "','" + r.Cells[9].Value + "','" + r.Cells[10].Value + "','" + r.Cells[11].Value + "','" + r.Cells[12].Value + "', "+
                        " '" + r.Cells[13].Value + "','" + comboBox1.Text + "')");
                    i = r.Index;
                }
            MessageBox.Show(i + " Record Saved.");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dtStudent.Columns.Clear(); dtStudent.Rows.Clear();

            dtStudent.Columns.Add("ScholarNo", typeof(string));
            dtStudent.Columns.Add("Name", typeof(string));
            dtStudent.Columns.Add("Class", typeof(string));
            dtStudent.Columns.Add("Subject", typeof(string));
            dtStudent.Columns.Add("July", typeof(string));
            dtStudent.Columns.Add("August", typeof(string));
            dtStudent.Columns.Add("September", typeof(string));
            dtStudent.Columns.Add("October", typeof(string));
            dtStudent.Columns.Add("HYExam", typeof(string));
            dtStudent.Columns.Add("Decmber", typeof(string));
            dtStudent.Columns.Add("January", typeof(string));
            dtStudent.Columns.Add("Febuary", typeof(string));
            dtStudent.Columns.Add("AnnExam", typeof(string));
            dtStudent.Columns.Add("Result", typeof(string));

            dtStudentField.Columns.Clear(); dtStudentField.Rows.Clear();

            dtStudentField.Columns.Add("ScholarNo", typeof(string));
            dtStudentField.Columns.Add("Name", typeof(string));
            dtStudentField.Columns.Add("Father", typeof(string));
            dtStudentField.Columns.Add("Mother", typeof(string));
            dtStudentField.Columns.Add("DBO", typeof(DateTime));
            dtStudentField.Columns.Add("Cast", typeof(string));
            dtStudentField.Columns.Add("Distic", typeof(string));
            dtStudentField.Columns.Add("Tehsil", typeof(string));
            dtStudentField.Columns.Add("BloodGroup", typeof(string));
            dtStudentField.Columns.Add("Literal", typeof(string));
            dtStudentField.Columns.Add("Cultural", typeof(string));
            dtStudentField.Columns.Add("Scientific", typeof(string));
            dtStudentField.Columns.Add("Creative", typeof(string));
            dtStudentField.Columns.Add("Games", typeof(string));
            dtStudentField.Columns.Add("FinalGrade1", typeof(string));
            dtStudentField.Columns.Add("Regularity", typeof(string));
            dtStudentField.Columns.Add("Pun", typeof(string));
            dtStudentField.Columns.Add("Clean", typeof(string));
            dtStudentField.Columns.Add("Discip", typeof(string));
            dtStudentField.Columns.Add("Spriti", typeof(string));
            dtStudentField.Columns.Add("Sensitivity", typeof(string));
            dtStudentField.Columns.Add("leadership", typeof(string));
            dtStudentField.Columns.Add("Truth", typeof(string));
            dtStudentField.Columns.Add("Honest", typeof(string));
            dtStudentField.Columns.Add("Attitude", typeof(string));
            dtStudentField.Columns.Add("FinalGrade2", typeof(string));
            dtStudentField.Columns.Add("Attendance", typeof(int));


                    DataTable dt = Connection.GetDataTable("SELECT [ScholarNo] ,[Name] ,[Subject] ,[Jul] ,[Aug] ,[Sept] ,[Oct]  "+
                        " ,[HY] ,[Dec] ,[Jan] ,[Feb] ,[Annual] ,[Attendance] ,[sssmid] ,[id] ,[FinalGrade] ,[Class] "+
                        " FROM [dbTemprary].[dbo].[tblStudent] Where Class = '"+comboBox1 .Text .Trim ()+"'");
                    if (dt.Rows.Count > 0)
                    {
                        DataTable dtsubject = dt.DefaultView.ToTable(true,"ScholarNo");
                        foreach (DataRow st in dtsubject.Rows)
                        {
                            DataRow[] r = dt.Select("ScholarNo='" + st["ScholarNo"] + "'");
                            if (r.Length > 0)
                            {
                                for (int i = 0; i < r.Length; i++)
                                {
                                    DataRow newrow = dtStudent.NewRow();
                                    newrow["ScholarNo"] = r[i]["ScholarNo"];
                                    newrow["Name"] = r[i]["Name"];
                                    newrow["Class"] = r[i]["Class"];
                                    newrow["Subject"] = r[i]["Subject"];
                                    newrow["July"] = r[i]["Jul"];
                                    newrow["August"] = r[i]["Aug"];
                                    newrow["September"] = r[i]["Sept"];
                                    newrow["October"] = r[i]["Oct"];
                                    newrow["HYExam"] = r[i]["HY"];
                                    newrow["Decmber"] = r[i]["Dec"];
                                    newrow["January"] = r[i]["Jan"];
                                    newrow["Febuary"] = r[i]["Feb"];
                                    newrow["AnnExam"] = r[i]["Annual"];
                                    newrow["Result"] = r[i]["FinalGrade"];
                                    dtStudent.Rows.Add(newrow);
                                }
                            }

                        }
                    }

                   foreach (DataRow st in dtStudent .Rows)
                    {
                        DataTable dtl = Connection.GetDataTable("SELECT [dbTemprary].[dbo].tblF1.ScholarNo,[dbTemprary].[dbo].tblF1.Name,[dbTemprary].[dbo].tblF1.Literary, [dbTemprary].[dbo].tblF1.Cultural, [dbTemprary].[dbo].tblF1.Science, " +
                            " [dbTemprary].[dbo].tblF1.Creativity, [dbTemprary].[dbo].tblF1.Sprot, [dbTemprary].[dbo].tblF1.Annual Annual1, [dbTemprary].[dbo].tblF1.FinalGrade FinalGrade1, [dbTemprary].[dbo].tblF2.Regularity, [dbTemprary].[dbo].tblF2.Punctuality,  " +
                            " [dbTemprary].[dbo].tblF2.Cleanliness, [dbTemprary].[dbo].tblF2.Discipline, [dbTemprary].[dbo].tblF2.CoOperation, [dbTemprary].[dbo].tblF2.Environment, [dbTemprary].[dbo].tblF2.Leadership, " +
                            " [dbTemprary].[dbo].tblF2.Truthfulness,[dbTemprary].[dbo]. tblF2.Honesty,[dbTemprary].[dbo]. tblF2.Nature,[dbTemprary].[dbo]. tblF2.Annual AS Annual2, [dbTemprary].[dbo].tblF2.FinalGrade AS FinalGrade2 " +
                            " FROM [dbTemprary].[dbo].tblF1 INNER JOIN [dbTemprary].[dbo].tblF2 ON [dbTemprary].[dbo].tblF1.ScholarNo =[dbTemprary].[dbo]. tblF2.ScholarNo AND [dbTemprary].[dbo].tblF1.Name = [dbTemprary].[dbo].tblF2.Name AND  " +
                            " [dbTemprary].[dbo].tblF1.Class = [dbTemprary].[dbo].tblF2.Class Where [dbTemprary].[dbo].tblF1.ScholarNo = '" + st["ScholarNo"] + "' AND [dbTemprary].[dbo].tblF1.Name ='" + st["Name"] + "'");

                        DataTable std = Connection.GetDataTable("SELECT tbl_student.name, tbl_student.dob, tbl_student.P_address, tbl_student.father, "+
                            " tbl_student.mother, tbl_student.m_tongue, tbl_student.casttype, tbl_student.bloodgroup, tbl_classstudent.stdtype, " +
                            " tbl_student.marr_status, tbl_tehsil.tehsil, tbl_district.district FROM tbl_student INNER JOIN "+
                            " tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN tbl_district ON tbl_tehsil.distcode = tbl_district.distcode "+
                            " Where tbl_student.name='" + st["Name"] + "'");

                        if (dtl.Rows.Count > 0)
                        {
                            DataRow r = dtStudentField.NewRow();

                            r["ScholarNo"] = dtl.Rows[0]["ScholarNo"];
                            r["Name"] = dtl.Rows[0]["Name"];
                            if (std.Rows.Count > 0)
                            {
                                r["Father"] = (std.Rows[0]["father"] != DBNull.Value) ? std.Rows[0]["father"] : null;
                                r["Mother"] = (std.Rows[0]["mother"] != DBNull.Value) ? std.Rows[0]["mother"] : null;
                                r["DBO"] = (std.Rows[0]["dob"] != DBNull.Value) ? std.Rows[0]["dob"] : null;
                                r["Cast"] = (std.Rows[0]["casttype"] != DBNull.Value) ? std.Rows[0]["casttype"] : null;
                                r["Distic"] = (std.Rows[0]["district"] != DBNull.Value) ? std.Rows[0]["district"] : null;
                                r["Tehsil"] = (std.Rows[0]["tehsil"] != DBNull.Value) ? std.Rows[0]["tehsil"] : null;
                                r["BloodGroup"] = (std.Rows[0]["bloodgroup"] != DBNull.Value) ? std.Rows[0]["bloodgroup"] : null;
                            }
                           r["Literal"] = dtl.Rows[0]["Literary"];
                           r["Cultural"] = dtl.Rows[0]["Cultural"];
                           r["Scientific"] = dtl.Rows[0]["Science"];
                           r["Creative"] = dtl.Rows[0]["Creativity"];
                           r["Games"] = dtl.Rows[0]["Sprot"];
                           r["FinalGrade1"] = dtl.Rows[0]["FinalGrade1"];
                           r["Regularity"] = dtl.Rows[0]["Regularity"]; 
                           r["Pun"] = dtl.Rows[0]["Punctuality"];
                           r["Clean"] = dtl.Rows[0]["Cleanliness"];
                           r["Discip"] = dtl.Rows[0]["Discipline"];
                           r["Spriti"] = dtl.Rows[0]["CoOperation"];
                           r["Sensitivity"] = dtl.Rows[0]["Environment"];
                           r["leadership"] = dtl.Rows[0]["Leadership"];
                           r["Truth"] = dtl.Rows[0]["Truthfulness"];
                           r["Honest"] = dtl.Rows[0]["Honesty"];
                           r["Attitude"] = dtl.Rows[0]["Nature"];
                           r["FinalGrade2"] = dtl.Rows[0]["FinalGrade2"];
                           r["Attendance"] = Connection.GetExecuteScalar("Select ISNULL(Attendance,0) From [dbTemprary].[dbo].tblStudent Where ScholarNo='" + r["ScholarNo"] + "' And Name='" + r["Name"] + "' AND Attendance IS NOT NULL");

                           dtStudentField.Rows.Add(r);


                        }

                    }
                   DataSet ds = Connection .GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage, Website, logoimage as Watermark, SchoolCode, TCSrNo , TCBookNo FROM tbl_school ");
                   ds.Tables.Add(dtStudent);
                   ds.Tables.Add(dtStudentField);
                   if (ds.Tables [0].Rows .Count  > 0)
                   {
                       ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\marksheet.xsd");
                       marksheet1 cr = new marksheet1();
                       cr.SetDataSource(ds);
                       ShowAllReports s = new ShowAllReports();
                       s.crystalReportViewer1.ReportSource = cr;
                       cr.SetParameterValue("CLASS", comboBox1.Text);
                       s.Show();
                   }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dtStudent.Columns.Clear(); dtStudent.Rows.Clear();

            dtStudent.Columns.Add("ScholarNo", typeof(string));
            dtStudent.Columns.Add("Name", typeof(string));
            dtStudent.Columns.Add("Class", typeof(string));
            dtStudent.Columns.Add("Subject", typeof(string));
            dtStudent.Columns.Add("July", typeof(string));
            dtStudent.Columns.Add("August", typeof(string));
            dtStudent.Columns.Add("September", typeof(string));
            dtStudent.Columns.Add("October", typeof(string));
            dtStudent.Columns.Add("HYExam", typeof(string));
            dtStudent.Columns.Add("Decmber", typeof(string));
            dtStudent.Columns.Add("January", typeof(string));
            dtStudent.Columns.Add("Febuary", typeof(string));
            dtStudent.Columns.Add("AnnExam", typeof(string));
            dtStudent.Columns.Add("Result", typeof(string));

            dtStudentField.Columns.Clear(); dtStudentField.Rows.Clear();

            dtStudentField.Columns.Add("ScholarNo", typeof(string));
            dtStudentField.Columns.Add("Name", typeof(string));
            dtStudentField.Columns.Add("Father", typeof(string));
            dtStudentField.Columns.Add("Mother", typeof(string));
            dtStudentField.Columns.Add("DBO", typeof(DateTime));
            dtStudentField.Columns.Add("Cast", typeof(string));
            dtStudentField.Columns.Add("Distic", typeof(string));
            dtStudentField.Columns.Add("Tehsil", typeof(string));
            dtStudentField.Columns.Add("BloodGroup", typeof(string));
            dtStudentField.Columns.Add("Literal", typeof(string));
            dtStudentField.Columns.Add("Cultural", typeof(string));
            dtStudentField.Columns.Add("Scientific", typeof(string));
            dtStudentField.Columns.Add("Creative", typeof(string));
            dtStudentField.Columns.Add("Games", typeof(string));
            dtStudentField.Columns.Add("FinalGrade1", typeof(string));
            dtStudentField.Columns.Add("Regularity", typeof(string));
            dtStudentField.Columns.Add("Pun", typeof(string));
            dtStudentField.Columns.Add("Clean", typeof(string));
            dtStudentField.Columns.Add("Discip", typeof(string));
            dtStudentField.Columns.Add("Spriti", typeof(string));
            dtStudentField.Columns.Add("Sensitivity", typeof(string));
            dtStudentField.Columns.Add("leadership", typeof(string));
            dtStudentField.Columns.Add("Truth", typeof(string));
            dtStudentField.Columns.Add("Honest", typeof(string));
            dtStudentField.Columns.Add("Attitude", typeof(string));
            dtStudentField.Columns.Add("FinalGrade2", typeof(string));
            dtStudentField.Columns.Add("Attendance", typeof(int));


            DataTable dt = Connection.GetDataTable("SELECT [ScholarNo] ,[Name] ,[Subject] ,[Jul] ,[Aug] ,[Sept] ,[Oct]  " +
                " ,[HY] ,[Dec] ,[Jan] ,[Feb] ,[Annual] ,[Attendance] ,[sssmid] ,[id] ,[FinalGrade] ,[Class] " +
                " FROM [dbTemprary].[dbo].[tblStudent] Where Class = '" + comboBox1.Text.Trim() + "'");
            if (dt.Rows.Count > 0)
            {
                DataTable dtsubject = dt.DefaultView.ToTable(true, "ScholarNo");
                foreach (DataRow st in dtsubject.Rows)
                {
                    DataRow[] r = dt.Select("ScholarNo='" + st["ScholarNo"] + "'");
                    if (r.Length > 0)
                    {
                        for (int i = 0; i < r.Length; i++)
                        {
                            DataRow newrow = dtStudent.NewRow();
                            newrow["ScholarNo"] = r[i]["ScholarNo"];
                            newrow["Name"] = r[i]["Name"];
                            newrow["Class"] = r[i]["Class"];
                            newrow["Subject"] = r[i]["Subject"];
                            newrow["July"] = r[i]["Jul"];
                            newrow["August"] = r[i]["Aug"];
                            newrow["September"] = r[i]["Sept"];
                            newrow["October"] = r[i]["Oct"];
                            newrow["HYExam"] = r[i]["HY"];
                            newrow["Decmber"] = r[i]["Dec"];
                            newrow["January"] = r[i]["Jan"];
                            newrow["Febuary"] = r[i]["Feb"];
                            newrow["AnnExam"] = r[i]["Annual"];
                            newrow["Result"] = r[i]["FinalGrade"];
                            dtStudent.Rows.Add(newrow);
                        }
                    }

                }
            }

            DataTable d = dtStudent.DefaultView.ToTable(true, "ScholarNo", "Name");
            foreach (DataRow st in d.Rows)
            {
                DataTable dtl = Connection.GetDataTable("SELECT [dbTemprary].[dbo].tblF1.ScholarNo,[dbTemprary].[dbo].tblF1.Name,[dbTemprary].[dbo].tblF1.Literary, [dbTemprary].[dbo].tblF1.Cultural, [dbTemprary].[dbo].tblF1.Science, " +
                    " [dbTemprary].[dbo].tblF1.Creativity, [dbTemprary].[dbo].tblF1.Sprot, [dbTemprary].[dbo].tblF1.Annual Annual1, [dbTemprary].[dbo].tblF1.FinalGrade FinalGrade1, [dbTemprary].[dbo].tblF2.Regularity, [dbTemprary].[dbo].tblF2.Punctuality,  " +
                    " [dbTemprary].[dbo].tblF2.Cleanliness, [dbTemprary].[dbo].tblF2.Discipline, [dbTemprary].[dbo].tblF2.CoOperation, [dbTemprary].[dbo].tblF2.Environment, [dbTemprary].[dbo].tblF2.Leadership, " +
                    " [dbTemprary].[dbo].tblF2.Truthfulness,[dbTemprary].[dbo]. tblF2.Honesty,[dbTemprary].[dbo]. tblF2.Nature,[dbTemprary].[dbo]. tblF2.Annual AS Annual2, [dbTemprary].[dbo].tblF2.FinalGrade AS FinalGrade2 " +
                    " FROM [dbTemprary].[dbo].tblF1 INNER JOIN [dbTemprary].[dbo].tblF2 ON [dbTemprary].[dbo].tblF1.ScholarNo =[dbTemprary].[dbo]. tblF2.ScholarNo AND [dbTemprary].[dbo].tblF1.Name = [dbTemprary].[dbo].tblF2.Name AND  " +
                    " [dbTemprary].[dbo].tblF1.Class = [dbTemprary].[dbo].tblF2.Class Where [dbTemprary].[dbo].tblF1.ScholarNo = '" + st["ScholarNo"] + "' AND [dbTemprary].[dbo].tblF1.Name ='" + st["Name"] + "'");

                DataTable std = Connection.GetDataTable("SELECT tbl_student.name, tbl_student.dob, tbl_student.P_address, tbl_student.father, " +
                    " tbl_student.mother, tbl_student.m_tongue, tbl_student.casttype, tbl_student.bloodgroup, tbl_classstudent.stdtype, " +
                    " tbl_student.marr_status, tbl_tehsil.tehsil, tbl_district.district FROM tbl_student INNER JOIN " +
                    " tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode INNER JOIN tbl_district ON tbl_tehsil.distcode = tbl_district.distcode " +
                    " Where tbl_student.name='" + st["Name"] + "'");

                if (dtl.Rows.Count > 0)
                {
                    DataRow r = dtStudentField.NewRow();

                    r["ScholarNo"] = dtl.Rows[0]["ScholarNo"];
                    r["Name"] = dtl.Rows[0]["Name"];
                    if (std.Rows.Count > 0)
                    {
                        r["Father"] = (std.Rows[0]["father"] != DBNull.Value) ? std.Rows[0]["father"] : null;
                        r["Mother"] = (std.Rows[0]["mother"] != DBNull.Value) ? std.Rows[0]["mother"] : null;
                        r["DBO"] = (std.Rows[0]["dob"] != DBNull.Value) ? std.Rows[0]["dob"] : null;
                        r["Cast"] = (std.Rows[0]["casttype"] != DBNull.Value) ? std.Rows[0]["casttype"] : null;
                        r["Distic"] = (std.Rows[0]["district"] != DBNull.Value) ? std.Rows[0]["district"] : null;
                        r["Tehsil"] = (std.Rows[0]["tehsil"] != DBNull.Value) ? std.Rows[0]["tehsil"] : null;
                        r["BloodGroup"] = (std.Rows[0]["bloodgroup"] != DBNull.Value) ? std.Rows[0]["bloodgroup"] : null;
                    }
                    r["Literal"] = dtl.Rows[0]["Literary"];
                    r["Cultural"] = dtl.Rows[0]["Cultural"];
                    r["Scientific"] = dtl.Rows[0]["Science"];
                    r["Creative"] = dtl.Rows[0]["Creativity"];
                    r["Games"] = dtl.Rows[0]["Sprot"];
                    r["FinalGrade1"] = dtl.Rows[0]["FinalGrade1"];
                    r["Regularity"] = dtl.Rows[0]["Regularity"];
                    r["Pun"] = dtl.Rows[0]["Punctuality"];
                    r["Clean"] = dtl.Rows[0]["Cleanliness"];
                    r["Discip"] = dtl.Rows[0]["Discipline"];
                    r["Spriti"] = dtl.Rows[0]["CoOperation"];
                    r["Sensitivity"] = dtl.Rows[0]["Environment"];
                    r["leadership"] = dtl.Rows[0]["Leadership"];
                    r["Truth"] = dtl.Rows[0]["Truthfulness"];
                    r["Honest"] = dtl.Rows[0]["Honesty"];
                    r["Attitude"] = dtl.Rows[0]["Nature"];
                    r["FinalGrade2"] = dtl.Rows[0]["FinalGrade2"];
                    r["Attendance"] = Connection.GetExecuteScalar("Select ISNULL(Attendance,0) From [dbTemprary].[dbo].tblStudent Where ScholarNo='" + r["ScholarNo"] + "' And Name='" + r["Name"] + "' AND Attendance IS NOT NULL");

                    dtStudentField.Rows.Add(r);


                }

            }
            DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage, Website, logoimage as Watermark, SchoolCode, TCSrNo , TCBookNo FROM tbl_school ");
            ds.Tables.Add(dtStudent);
            ds.Tables.Add(dtStudentField);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\marksheet.xsd");
                marksheet2 cr = new marksheet2();
                cr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr;
                cr.SetParameterValue("CLASS", comboBox1.Text);
                s.Show();
            }
        }
 
    }
}
