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
    public partial class frmrollnogenerate :UserControlBase
    {
        school1 c = new school1();
        Boolean add_edit = false;
        int SectionCode;
        DataSet dsStudent;
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = Connection.Conn();

        public frmrollnogenerate()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmattandance_Load(object sender, EventArgs e)
        {
            valcmbexam.SelectedIndex = 0;
            c.getconnstr();
            c.FillcomboBox("select b.classcode,b.classname+' '+c.sectionname as class from tbl_class a,tbl_classmaster b,tbl_section c where b.classcode=a.classcode and c.sectioncode=a.sectioncode", "class", "classcode", ref valcmbclass);
            c.FillcomboBox("select examno,examname from tbl_examtype", "examname", "examno", ref valcmbexam);
            c.GetMdiParent(this).ToggleSaveButton(true);
        }

        private void Txtrollno_Validating(object sender, CancelEventArgs e)
        {
            ControlValidation.CheckNumericValueOnly(txtrollno, e);
        }



        private void txtrollno_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.CHECKNUM(e);
        }

        private void datagridview1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(datagridview1, e);
        }

        private void btnGetStudentList_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (datagridview1.RowCount > 0)
            {
                string Session = Convert.ToString(Connection.GetExecuteScalar("Select sessionname from tbl_session where sessioncode='" + school.CurrentSessionCode + "'"));
                DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage  ,'" + Session + "' as Session FROM tbl_school  ");
                ds.Tables.Add(Connection.GetDataTableFromDataGridView(datagridview1));
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\RollNoGen.xsd");
                rptRollNoGen cr = new rptRollNoGen();
                cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                cr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr;
                cr.SetParameterValue("ReportTitle", "Roll No. List For Class : " + valcmbclass.Text);
                s.Show();
            }
            else
            {
                MessageBox.Show("Please Check Student Record.", "", MessageBoxButtons.OK);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void valcmbclass_Leave(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                datagridview1.Rows.Clear();
                string[] sec = valcmbclass.Text.Split(' ');
                this.SectionCode = Convert.ToInt32(Connection.GetExecuteScalar("Select sectioncode from tbl_section where sectionname='" + sec[1].ToString() + "'"));
                string mysql = " SELECT tbl_student.studentno, tbl_student.scholarno, tbl_student.name, tbl_StudentAttendance.RollNo, tbl_StudentAttendance.Lectures " +
     " ,  tbl_StudentAttendance.PresentDays, tbl_StudentAttendance.Per,tbl_student.phone,tbl_student.Height,tbl_student.Width,tbl_student.VisionL,tbl_student.VisionR,tbl_student.Teeth ,tbl_student.OHygiene,tbl_student.bloodgroup,tbl_student.House,tbl_student.CGPA,tbl_student.OGrade FROM tbl_student INNER JOIN tbl_classstudent ON  " +
     "    tbl_student.studentno = tbl_classstudent.studentno LEFT OUTER JOIN tbl_StudentAttendance ON  " +
     "    tbl_classstudent.sessioncode = tbl_StudentAttendance.SessionCode AND tbl_student.studentno = tbl_StudentAttendance.StudentNo and   tbl_classstudent.section=tbl_StudentAttendance.sectionno " +
     "    WHERE (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') AND (tbl_classstudent.classno = '" + valcmbclass.SelectedValue + "') " +
     "    AND (tbl_classstudent.Section = '" + this.SectionCode + "') AND (tbl_classstudent.stdtype in ('New Student','Studying Student')) GROUP BY tbl_student.studentno, tbl_student.scholarno, tbl_student.name " +
     " , tbl_StudentAttendance.RollNo, tbl_StudentAttendance.Lectures ,tbl_StudentAttendance.PresentDays, tbl_StudentAttendance.Per,tbl_student.phone,tbl_student.Height,tbl_student.Width,tbl_student.VisionL,tbl_student.VisionR,tbl_student.Teeth ,tbl_student.OHygiene,tbl_student.bloodgroup,tbl_student.House,tbl_student.CGPA,tbl_student.OGrade Order By  tbl_student.name";

                dsStudent = Connection.GetDataSet(mysql);
                //            SqlDataAdapter da = new SqlDataAdapter("SELECT SessionCode, ExamNo, StudentNo, PresentDays, RollNo, Lectures " +
                //" , Per, ClassNo, SectionNo, Status FROM tbl_StudentAttendance Where SessionCode='"
                //+ school.CurrentSessionCode + "' And ClassNo='" + valcmbclass.SelectedValue + "' And SectionNo='" + this.SectionCode + "' ", Connection.Conn());

                cmd.Connection = con;
                cmd.CommandText = "SELECT SessionCode, ExamNo, StudentNo, PresentDays, RollNo, Lectures " +
                 " , Per, ClassNo, SectionNo, Status FROM tbl_StudentAttendance Where SessionCode='"
                 + school.CurrentSessionCode + "' And ClassNo='" + valcmbclass.SelectedValue + "' And SectionNo='" + this.SectionCode + "' ";

                da.SelectCommand = cmd;

                da.Fill(ds);
                ds.Tables[0].PrimaryKey =
     new DataColumn[] { ds.Tables[0].Columns[0], ds.Tables[0].Columns[2] };

                SqlCommand com = new SqlCommand(mysql, c.myconn);
                SqlDataReader reader = com.ExecuteReader();
                int i = 0;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        datagridview1.Rows.Add();
                        datagridview1.Rows[i].Cells[0].Value = reader["studentno"];
                        datagridview1.Rows[i].Cells[1].Value = reader["scholarno"];
                        datagridview1.Rows[i].Cells[2].Value = reader["rollno"];
                        datagridview1.Rows[i].Cells[3].Value = reader["name"];
                        datagridview1.Rows[i].Cells[4].Value = reader["Lectures"];
                        datagridview1.Rows[i].Cells[5].Value = reader["PresentDays"];
                        datagridview1.Rows[i].Cells[6].Value = reader["Per"];
                        datagridview1.Rows[i].Cells[7].Value = reader["phone"];
                        datagridview1.Rows[i].Cells[8].Value = reader["Height"];
                        datagridview1.Rows[i].Cells[9].Value = reader["Width"];
                        datagridview1.Rows[i].Cells[10].Value = reader["VisionL"];
                        datagridview1.Rows[i].Cells[11].Value = reader["VisionR"];
                        datagridview1.Rows[i].Cells[12].Value = reader["Teeth"];
                        datagridview1.Rows[i].Cells[13].Value = reader["OHygiene"];
                        datagridview1.Rows[i].Cells[14].Value = reader["bloodgroup"];
                        datagridview1.Rows[i].Cells[15].Value = reader["House"];
                        datagridview1.Rows[i].Cells[16].Value = reader["CGPA"];
                        datagridview1.Rows[i].Cells[17].Value = reader["OGrade"];
                        i++;
                    }
                    reader.Close();
                }
                else
                {
                    reader.Close();
                }
                if (Convert.ToInt32(valcmbclass.SelectedValue.ToString()) >= 101 && Convert.ToInt32(valcmbclass.SelectedValue.ToString()) <= 108)
                {
                    datagridview1.Columns["House"].Visible = true;
                    datagridview1.Columns["CGPA"].Visible = true;
                    datagridview1.Columns["OGrade"].Visible = true;
                }
                else
                {
                    datagridview1.Columns["House"].Visible = false;
                    datagridview1.Columns["CGPA"].Visible = false;
                    datagridview1.Columns["OGrade"].Visible = false;
                }
            }
            catch (Exception ex) { MessageBox.Show("this is leave exception area." + ex.Message); }
        }

        private void valcmbclass_SelectedIndexChanged(object sender, EventArgs e)
          {
            try
            {
                string[] sec = valcmbclass.Text.Split(' ');
                this.SectionCode = Convert.ToInt32(Connection.GetExecuteScalar("Select sectioncode from tbl_section where sectionname='" + sec[1].ToString() + "'"));
                txtrollno.Text = Convert.ToString(Connection.GetExecuteScalar("SELECT isnull(MIN(RollNo),101) AS RollNo FROM tbl_StudentAttendance " +
                 " WHERE (ClassNo = '" + valcmbclass.SelectedValue + "') AND (SectionNo = '" + this.SectionCode + "') AND (SessionCode = '" + school.CurrentSessionCode + "')"));
                txtTotalLecture.Text = Convert.ToString(Connection.GetExecuteScalar("SELECT isnull(Lectures,260) FROM tbl_StudentAttendance " +
                  " WHERE (ClassNo = '" + valcmbclass.SelectedValue + "') AND (SectionNo = '" + this.SectionCode + "') AND (SessionCode = '" + school.CurrentSessionCode + "') " +
                  " GROUP BY Lectures"));

                foreach (DataGridViewRow r in datagridview1.Rows)
                {
                    if (r.Cells["TotalLecture"].Value.ToString() == string.Empty)
                    {
                        r.Cells["TotalLecture"].Value = txtTotalLecture.Text;
                        r.Cells["Attendance"].Value = 0;
                        r.Cells["Per"].Value = 0.00;
                    }
                }
            }
            catch { MessageBox.Show("this is index change exception area."); }
        }

        private void txtTotalLecture_Leave(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in datagridview1.Rows)
                {
                    r.Cells["TotalLecture"].Value = txtTotalLecture.Text;
                    r.Cells["Attendance"].Value = 0;
                    r.Cells["Per"].Value = 0.00;
                }
            }
            catch { }
        }

        private void txtrollno_Leave(object sender, EventArgs e)
        {
            try
            {
                int RollNo = Convert.ToInt32(txtrollno.Text);
                foreach (DataGridViewRow r in datagridview1.Rows)
                {
                    r.Cells["rollno"].Value = RollNo++;
                    r.Cells["rollno"].ReadOnly = false;
                }
                foreach (DataGridViewRow r in datagridview1.Rows)
                {
                    if (r.Cells["TotalLecture"].Value.ToString() == string.Empty)
                    {
                        r.Cells["TotalLecture"].Value = txtTotalLecture.Text;
                        r.Cells["Attendance"].Value = 0;
                        r.Cells["Per"].Value = 0.00;
                    }
                }
            }
            catch { }
        }



        public override void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                if (ds.Tables[0].Rows.Count == 0)
                {
                    foreach (DataGridViewRow dr in datagridview1.Rows)
                    {
                        DataRow r = ds.Tables[0].NewRow();
                        r["SessionCode"] = school.CurrentSessionCode;
                        r["ExamNo"] = valcmbexam.SelectedIndex;
                        r["StudentNo"] = dr.Cells[0].Value;
                        r["PresentDays"] = dr.Cells["Attendance"].Value;
                        r["RollNo"] = dr.Cells["rollno"].Value;
                        r["Lectures"] = dr.Cells["TotalLecture"].Value;
                        r["Per"] = dr.Cells["Per"].Value;
                        r["ClassNo"] = valcmbclass.SelectedValue;
                        r["SectionNo"] = this.SectionCode;
                        r["Status"] = true;
                        ds.Tables[0].Rows.Add(r);
                        //----------for change mobile no add health status ----
                        string UpdateQuery = "update tbl_student set phone='" + dr.Cells["phone"].Value
                            + "',Height='" + dr.Cells["Height"].Value
                            + "',Width='" + dr.Cells["Width"].Value
                            + "',VisionL='" + dr.Cells["VisionL"].Value
                            + "',VisionR='" + dr.Cells["VisionR"].Value
                            + "',Teeth='" + dr.Cells["Teeth"].Value
                            + "',OHygiene='" + dr.Cells["OHygiene"].Value
                            + "',bloodgroup='" + dr.Cells["bloodgroup"].Value
                         + "',House='" + dr.Cells["House"].Value
                          + "',CGPA='" + dr.Cells["CGPA"].Value
                           + "',OGrade='" + dr.Cells["OGrade"].Value
                            + "' where StudentNo='" + dr.Cells[0].Value + "'";
                        c.executesql(UpdateQuery, c.myconn);
                        //----------End Area--------------------------
                    }
                    SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                    da.Update(ds);
                    MessageBox.Show("Record Saved Successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ds.Tables[0].Rows.Count != datagridview1.Rows.Count && datagridview1.Rows.Count > 0)
                {
                    string mstr = "delete tbl_StudentAttendance Where SessionCode='" + school.CurrentSessionCode + "' And ClassNo='" + valcmbclass.SelectedValue + "' And SectionNo='" + this.SectionCode + "'";
                    int f = 0;
                    f = Connection.AllPerform(mstr);
                    ds.Tables[0].Rows.Clear();
                    foreach (DataGridViewRow dr in datagridview1.Rows)
                    {
                        DataRow r = ds.Tables[0].NewRow();
                        r["SessionCode"] = school.CurrentSessionCode;
                        r["ExamNo"] = valcmbexam.SelectedIndex;
                        r["StudentNo"] = dr.Cells[0].Value;
                        r["PresentDays"] = dr.Cells["Attendance"].Value;
                        r["RollNo"] = dr.Cells["rollno"].Value;
                        r["Lectures"] = dr.Cells["TotalLecture"].Value;
                        r["Per"] = dr.Cells["Per"].Value;
                        r["ClassNo"] = valcmbclass.SelectedValue;
                        r["SectionNo"] = this.SectionCode;
                        r["Status"] = true;
                        ds.Tables[0].Rows.Add(r);
                        //----------for change mobile no add health status ----
                        string UpdateQuery = "update tbl_student set phone='" + dr.Cells["phone"].Value
                            + "',Height='" + dr.Cells["Height"].Value
                            + "',Width='" + dr.Cells["Width"].Value
                            + "',VisionL='" + dr.Cells["VisionL"].Value
                            + "',VisionR='" + dr.Cells["VisionR"].Value
                            + "',Teeth='" + dr.Cells["Teeth"].Value
                            + "',OHygiene='" + dr.Cells["OHygiene"].Value
                            + "',bloodgroup='" + dr.Cells["bloodgroup"].Value
                             + "',House='" + dr.Cells["House"].Value
                          + "',CGPA='" + dr.Cells["CGPA"].Value
                           + "',OGrade='" + dr.Cells["OGrade"].Value
                            + "' where StudentNo='" + dr.Cells[0].Value + "'";
                        c.executesql(UpdateQuery, c.myconn);
                        //----------End Area--------------------------
                    }
                    SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                    da.Update(ds);
                    MessageBox.Show("Record Updated Successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string mstr = "delete tbl_StudentAttendance Where SessionCode='" + school.CurrentSessionCode + "' And ClassNo='" + valcmbclass.SelectedValue + "' And SectionNo='" + this.SectionCode + "'";
                    int f = 0;
                    f = Connection.AllPerform(mstr);
                    ds.Tables[0].Rows.Clear();
                    foreach (DataGridViewRow dr in datagridview1.Rows)
                    {
                        DataRow r = ds.Tables[0].NewRow();
                        r["SessionCode"] = school.CurrentSessionCode;
                        r["ExamNo"] = valcmbexam.SelectedIndex;
                        r["StudentNo"] = dr.Cells[0].Value;
                        r["PresentDays"] = dr.Cells["Attendance"].Value;
                        r["RollNo"] = dr.Cells["rollno"].Value;
                        r["Lectures"] = dr.Cells["TotalLecture"].Value;
                        r["Per"] = dr.Cells["Per"].Value;
                        r["ClassNo"] = valcmbclass.SelectedValue;
                        r["SectionNo"] = this.SectionCode;
                        r["Status"] = true;
                        ds.Tables[0].Rows.Add(r);
                        //----------for change mobile no add health status ----
                        string UpdateQuery = "update tbl_student set phone='" + dr.Cells["phone"].Value
                            + "',Height='" + dr.Cells["Height"].Value
                            + "',Width='" + dr.Cells["Width"].Value
                            + "',VisionL='" + dr.Cells["VisionL"].Value
                            + "',VisionR='" + dr.Cells["VisionR"].Value
                            + "',Teeth='" + dr.Cells["Teeth"].Value
                            + "',OHygiene='" + dr.Cells["OHygiene"].Value
                            + "',bloodgroup='" + dr.Cells["bloodgroup"].Value
                             + "',House='" + dr.Cells["House"].Value
                          + "',CGPA='" + dr.Cells["CGPA"].Value
                           + "',OGrade='" + dr.Cells["OGrade"].Value
                            + "' where StudentNo='" + dr.Cells[0].Value + "'";
                        c.executesql(UpdateQuery, c.myconn);
                        //----------End Area--------------------------
                    }
                    SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                    da.Update(ds);
                    //foreach (DataRow r in ds.Tables[0].Rows)
                    //{
                    //    ds.Tables[0].Rows[i].BeginEdit();
                    //    SqlCommandBuilder cmb = new SqlCommandBuilder(da);
                    //    //  r["SessionCode"] = school.CurrentSessionCode;
                    //    r["ExamNo"] = valcmbexam.SelectedIndex;
                    //    //  r["StudentNo"] =datagridview1.Rows[i].Cells[0].Value;
                    //    r["PresentDays"] = datagridview1.Rows[i].Cells["Attendance"].Value;
                    //    r["RollNo"] = datagridview1.Rows[i].Cells["rollno"].Value;
                    //    r["Lectures"] = datagridview1.Rows[i].Cells["TotalLecture"].Value;
                    //    r["Per"] = datagridview1.Rows[i].Cells["Per"].Value;
                    //    r["ClassNo"] = valcmbclass.SelectedValue;
                    //    r["SectionNo"] = this.SectionCode;
                    //    r["Status"] = true;
                    //    r.EndEdit(); da.UpdateCommand = cmb.GetUpdateCommand();
                    //    da.Update(ds);
                    //    //----------for change mobile no add health status ----
                    //    string UpdateQuery = "update tbl_student set phone='" + datagridview1.Rows[i].Cells["phone"].Value
                    //        + "',Height='" + datagridview1.Rows[i].Cells["Height"].Value
                    //        + "',Width='" + datagridview1.Rows[i].Cells["Width"].Value
                    //        + "',VisionL='" + datagridview1.Rows[i].Cells["VisionL"].Value
                    //        + "',VisionR='" + datagridview1.Rows[i].Cells["VisionR"].Value
                    //        + "',Teeth='" + datagridview1.Rows[i].Cells["Teeth"].Value
                    //        + "',OHygiene='" + datagridview1.Rows[i].Cells["OHygiene"].Value
                    //        + "' where StudentNo='" + datagridview1.Rows[i].Cells[0].Value + "'";
                    //    c.executesql(UpdateQuery, c.myconn);
                    //    //----------End Area--------------------------
                    //    i++;
                    //}
                    MessageBox.Show("Record Updated Successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnStudentReport_Click(object sender, EventArgs e)
        {
            if (datagridview1.RowCount > 0)
            {
                string Session = Convert.ToString(Connection.GetExecuteScalar("Select sessionname from tbl_session where sessioncode='" + school.CurrentSessionCode + "'"));
                DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage  ,'" + Session + "' as Session FROM tbl_school  ");
                ds.Tables.Add(Connection.GetDataTableFromDataGridView(datagridview1));
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\StudentAttendance.xsd");
                rptStudentAttendance cr = new rptStudentAttendance();
                cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                cr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr;
                cr.SetParameterValue("ReportTitle", "Student Attendance For Class : " + valcmbclass.Text);
                s.Show();
            }
            else
            {
                MessageBox.Show("Please Check Student Record.", "", MessageBoxButtons.OK);
            }
        }

        private void datagridview1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    try
                    {
                        datagridview1.EndEdit();
                        if (Convert.ToDecimal(datagridview1.Rows[e.RowIndex].Cells[4].Value) >= Convert.ToDecimal(datagridview1.Rows[e.RowIndex].Cells[5].Value))
                        {
                            if (datagridview1.Rows[e.RowIndex].Cells[5].Value == null)
                            {
                                datagridview1.Rows[e.RowIndex].Cells[5].Value = 0;
                            }
                            datagridview1.Rows[e.RowIndex].Cells[6].Value = Math.Round(Convert.ToDecimal(datagridview1.Rows[e.RowIndex].Cells[5].Value) / (
                             Convert.ToDecimal(datagridview1.Rows[e.RowIndex].Cells[4].Value)
                             * Convert.ToDecimal(0.01)), 2);
                        }
                        else
                        {
                            MessageBox.Show("Please Fill Valid Attendance.");
                            datagridview1.Rows[e.RowIndex].Cells[5].Value = 0;
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void frmrollnogenerate_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }




    }
}
