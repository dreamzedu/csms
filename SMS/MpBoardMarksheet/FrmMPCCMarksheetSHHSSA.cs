using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace SMS.MpBoardMarksheet
{
    public partial class FrmMPCCMarksheetSHHSSA : UserControl
    {
        public FrmMPCCMarksheetSHHSSA()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        DataTable dtStudentList = new DataTable("dtStudentList");
        SqlDataReader dataReader = null;
        bool ExamFlage = false;
        bool NonPrimaryFlage = false;
        decimal MaximumMarks;
        static string columnName = string.Empty;
        private void FrmMPCCMarksheetSHHSSA_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void FrmMPCCMarksheetSHHSSA_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Order By ClassOrder");
            Connection.FillComboBox(cmbSection, "Select SectionCode ,SectionName From tbl_Section order by SectionName");
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);

        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSection, "SELECT tbl_class.sectioncode, tbl_section.sectionname FROM tbl_classmaster INNER JOIN  " +
                    " tbl_class ON tbl_classmaster.classcode = tbl_class.classcode INNER JOIN tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode WHERE (tbl_classmaster.classcode = '" + cmbClass.SelectedValue + "')");

                if (Convert.ToInt32(cmbClass.SelectedValue.ToString()) > 110 && Convert.ToInt32(cmbClass.SelectedValue.ToString()) < 113)
                {
                    cmbSankay.DataSource = null;
                    Connection.FillComboBox(cmbSankay, " select sankaycode,sankayname from tbl_sankay  WHERE     (sankayname != 'Common') order by sankayname");
                    cmbSankay.SelectedIndex = 0;
                }
                else
                {
                    cmbSankay.DataSource = null;
                    Connection.FillComboBox(cmbSankay, " SELECT     sankaycode,sankayname   FROM         tbl_sankay  WHERE     (sankayname = 'Common')  order by sankayname");
                    cmbSankay.SelectedIndex = 0;
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
        public void GetDetailsofI_V()
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                    if (!string.IsNullOrEmpty(cmbExam.Text))
                    {
                        ////Data Table Here Starting
                        dtg.DataSource = null; string tsubcode = string.Empty;
                        dtStudentList.Rows.Clear(); dtStudentList.Columns.Clear();
                        dtStudentList.Columns.Add("Student No", typeof(int));
                        dtStudentList.Columns.Add("Scholar No", typeof(string));
                        dtStudentList.Columns.Add("Name", typeof(string));
                        dataReader = Connection.GetDataReader("SELECT tbl_subject.subjectno, tbl_subject.subjectname,tbl_subwiseclass.subjecttype " +
                            " FROM tbl_subwiseclass INNER JOIN tbl_subject ON tbl_subwiseclass.subjectno = tbl_subject.subjectno " +
                            " WHERE (tbl_subwiseclass.classno = '" + cmbClass.SelectedValue + "') ORDER BY tbl_subject.SubjectOrder");
                        tsubcode = "0";
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                if (cmbExam.Text.ToString() == "TERM I" || cmbExam.Text.ToString() == "TERM II" || cmbExam.Text.ToString() == "TERM III")
                                {
                                    
                                        dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(decimal));
                                        dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = 0;
                                        dtStudentList.Columns.Add("Grade" + dataReader["subjectno"].ToString(), typeof(string));
                                        dtStudentList.Columns["Grade" + dataReader["subjectno"].ToString()].DefaultValue = "E";
                                        tsubcode = dataReader["subjectno"].ToString();
                                    
                                }
                                else
                                {
                                    dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(decimal));
                                    dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = 0;
                                    tsubcode = dataReader["subjectno"].ToString();
                                    
                                }
                            }
                            dataReader.Close();
                        }
                        ///
                        if (btnNew.Enabled.Equals(true))
                        {

                            DataTable n = Connection.GetDataTable("Select Top 1 TERMI ,TERMII ,TERMIII,TERMIP ,TERMIIP ,TERMIIIP  From tbl_MPSHHSSAStudentMarks " +
                                " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                                " And SessionCode='" + school.CurrentSessionCode + "'   ");
                            if (n.Rows.Count > 0)
                            {
                                if ("TERM I".Equals(cmbExam.Text.Trim()))
                                {
                                    MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else if ("TERM II".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["TERMI"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of TERM I!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["TERMII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM III".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["TERMI"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of TERM II!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["TERMII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of TERM II!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["TERMIII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM I P".Equals(cmbExam.Text.Trim()))
                                {
                                    if (!n.Rows[0]["TERMIP"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM II P".Equals(cmbExam.Text.Trim()))
                                {
                                    if (!n.Rows[0]["TERMIIP"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM III P".Equals(cmbExam.Text.Trim()))
                                {
                                    if (!n.Rows[0]["TERMIIIP"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                            }
                            else if (!cmbExam.Text.Trim().Equals("TERM I"))
                            {
                                MessageBox.Show("!!! Warrning : \n\t Please select TERM I");
                                return;
                            }

                            if (dtStudentList.Columns.Count > 0)
                            {
                                dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                                    " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                                    " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' ORDER BY tbl_student.name ");
                                if (dataReader.HasRows)
                                {
                                    while (dataReader.Read())
                                    {
                                        dtStudentList.Rows.Add(
                                            dataReader[0], dataReader[1], dataReader[2]);
                                    }
                                    dataReader.Close();
                                }
                                dtg.DataSource = dtStudentList;
                                lblStatus.Text = "You Have Select " + cmbExam.Text;
                                chkLock.Checked = true;
                                tmr1.Enabled = true;
                            }
                        }
                        else if (btnEdit.Enabled.Equals(true))
                        {
                            if (dtStudentList.Columns.Count > 0)
                            {
                                dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                                    " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                                    " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' ORDER BY tbl_student.name");

                                DataTable dtStudtntExamMarks = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail_SHHSSA] " + cmbClass.SelectedValue + "," + cmbSection.SelectedValue + "," + school.CurrentSessionCode + ",'E','" + cmbSankay.Text.ToString() + "'");
                                if (dataReader.HasRows)
                                {
                                    while (dataReader.Read())
                                    {
                                        dtStudentList.Rows.Add(
                                            dataReader[0], dataReader[1], dataReader[2]);
                                    }
                                    dataReader.Close();
                                }
                                foreach (DataRow r in dtStudentList.Rows)
                                {
                                    int i = 0;
                                    DataRow[] row = dtStudtntExamMarks.Select("StudentNo='" + r["Student No"] + "'");
                                    //for (int i = 0; i < row.Length; i++)
                                    if (row.Length > 0)
                                    {
                                        foreach (DataColumn c in dtStudentList.Columns)
                                        {
                                            if (!c.ColumnName.Contains("Student No") && !c.ColumnName.Contains("Scholar No")
                                                && !c.ColumnName.Contains("Name") && !c.ColumnName.Contains("Grade"))
                                            {
                                                string exm = string.Empty;
                                                if (cmbExam.Text.Trim() == "TERM I")
                                                    exm = "TERMI";
                                                else if (cmbExam.Text.Trim() == "TERM II")
                                                    exm = "TERMII";
                                                else if (cmbExam.Text.Trim() == "TERM III")
                                                    exm = "TERMIII";
                                                else if (cmbExam.Text.Trim() == "TERM I P")
                                                    exm = "TERMIP";
                                                else if (cmbExam.Text.Trim() == "TERM II P")
                                                    exm = "TERMIIP";
                                                else if (cmbExam.Text.Trim() == "TERM III P")
                                                    exm = "TERMIIIP";
                                                r[c.ColumnName] = row[i][exm];
                                                decimal tval = 0;
                                                if (row[i][exm].Equals(DBNull.Value))
                                                    tval = 0;
                                                else
                                                    tval = Convert.ToDecimal(row[i][exm]);
                                                if (exm == "TERMI")
                                                {
                                                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) <= 108 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 115)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 70);        // 70 number ka
                                                    else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 109 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 111)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 100);



                                                }
                                                else if (exm == "TERMII")
                                                {
                                                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) <= 108 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 115)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 50);   //50 Number ka
                                                    else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 109 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 111)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 100);
                                                }
                                                else if (exm == "TERMIII")
                                                {
                                                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) <= 111 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 115)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 100);
                                                }
                                                dtStudentList.EndInit();
                                                i++;
                                            }
                                        }
                                    }
                                }
                                dtg.DataSource = dtStudentList;
                                lblStatus.Text = "You Have Select " + cmbExam.Text;
                                chkLock.Checked = true;
                                tmr1.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Exam...", "");
                        cmbExam.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Section First!!!", "Section");
                    cmbSection.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Select Class First!!!", "Class");
                cmbClass.Focus();
            }
        }

        public void GetDetailsof_XI()
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                    if (!string.IsNullOrEmpty(cmbExam.Text))
                    {
                        ////Data Table Here Starting
                        dtg.DataSource = null; string tsubcode = string.Empty;
                        dtStudentList.Rows.Clear(); dtStudentList.Columns.Clear();
                        dtStudentList.Columns.Add("Student No", typeof(int));
                        dtStudentList.Columns.Add("Scholar No", typeof(string));
                        dtStudentList.Columns.Add("Name", typeof(string));
                        dataReader = Connection.GetDataReader("SELECT tbl_subject.subjectno, tbl_subject.subjectname,tbl_subwiseclass.subjecttype " +
                            " FROM tbl_subwiseclass INNER JOIN tbl_subject ON tbl_subwiseclass.subjectno = tbl_subject.subjectno " +
                            " WHERE (tbl_subwiseclass.classno = '" + cmbClass.SelectedValue + "') and tbl_subwiseclass.sankayname='"+cmbSankay.Text.ToString()+"' ORDER BY tbl_subject.SubjectOrder");
                       
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                if (cmbExam.Text.ToString() == "TERM I" || cmbExam.Text.ToString() == "TERM II" || cmbExam.Text.ToString() == "TERM III")
                                {

                                    dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(decimal));
                                    dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = 0;
                                    dtStudentList.Columns.Add("Grade" + dataReader["subjectno"].ToString(), typeof(string));
                                    dtStudentList.Columns["Grade" + dataReader["subjectno"].ToString()].DefaultValue = "E";
                                    tsubcode = dataReader["subjectno"].ToString();

                                }
                                else
                                {
                                    dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(decimal));
                                    dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = 0;
                                    tsubcode = dataReader["subjectno"].ToString();

                                }
                            }
                            dataReader.Close();
                        }
                        ///
                        if (btnNew.Enabled.Equals(true))
                        {

                            DataTable n = Connection.GetDataTable("Select Top 1 TERMI ,TERMII ,TERMIII,TERMIP ,TERMIIP ,TERMIIIP  From tbl_MPSHHSSAStudentMarks " +
                                " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                                " And SessionCode='" + school.CurrentSessionCode + "' and Stream='" + cmbSankay.SelectedValue.ToString() + "'");
                            if (n.Rows.Count > 0)
                            {
                                if ("TERM I".Equals(cmbExam.Text.Trim()))
                                {
                                    MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else if ("TERM II".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["TERMI"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of TERM I!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["TERMII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM III".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["TERMI"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of TERM II!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["TERMII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of TERM II!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["TERMIII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM I P".Equals(cmbExam.Text.Trim()))
                                {
                                    if (!n.Rows[0]["TERMIP"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM II P".Equals(cmbExam.Text.Trim()))
                                {
                                    if (!n.Rows[0]["TERMIIP"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM III P".Equals(cmbExam.Text.Trim()))
                                {
                                    if (!n.Rows[0]["TERMIIIP"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                            }
                            else if (!cmbExam.Text.Trim().Equals("TERM I"))
                            {
                                MessageBox.Show("!!! Warrning : \n\t Please select TERM I");
                                return;
                            }

                            if (dtStudentList.Columns.Count > 0)
                            {
                                dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                                    " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                                    " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' and tbl_classstudent.Stream=(select top 1 sankaycode from tbl_sankay where sankayname='" + cmbSankay.Text.ToString() + "') ORDER BY tbl_student.name ");
                                if (dataReader.HasRows)
                                {
                                    while (dataReader.Read())
                                    {
                                        dtStudentList.Rows.Add(
                                            dataReader[0], dataReader[1], dataReader[2]);
                                    }
                                    dataReader.Close();
                                }
                                dtg.DataSource = dtStudentList;
                                lblStatus.Text = "You Have Select " + cmbExam.Text;
                                chkLock.Checked = true;
                                tmr1.Enabled = true;
                            }
                        }
                        else if (btnEdit.Enabled.Equals(true))
                        {
                            if (dtStudentList.Columns.Count > 0)
                            {
                                dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                                    " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                                    " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' and tbl_classstudent.Stream=(select top 1 sankaycode from tbl_sankay where sankayname='" + cmbSankay.Text.ToString() + "') ORDER BY tbl_student.name");

                                DataTable dtStudtntExamMarks = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail_SHHSSA] " + cmbClass.SelectedValue + "," + cmbSection.SelectedValue + "," + school.CurrentSessionCode + ",'E','" + cmbSankay.Text.ToString() + "'");
                                if (dataReader.HasRows)
                                {
                                    while (dataReader.Read())
                                    {
                                        dtStudentList.Rows.Add(
                                            dataReader[0], dataReader[1], dataReader[2]);
                                    }
                                    dataReader.Close();
                                }
                                foreach (DataRow r in dtStudentList.Rows)
                                {
                                    int i = 0;
                                    DataRow[] row = dtStudtntExamMarks.Select("StudentNo='" + r["Student No"] + "'");
                                    //for (int i = 0; i < row.Length; i++)
                                    if (row.Length > 0)
                                    {
                                        foreach (DataColumn c in dtStudentList.Columns)
                                        {
                                            if (!c.ColumnName.Contains("Student No") && !c.ColumnName.Contains("Scholar No")
                                                && !c.ColumnName.Contains("Name") && !c.ColumnName.Contains("Grade"))
                                            {
                                                string exm = string.Empty;
                                                if (cmbExam.Text.Trim() == "TERM I")
                                                    exm = "TERMI";
                                                else if (cmbExam.Text.Trim() == "TERM II")
                                                    exm = "TERMII";
                                                else if (cmbExam.Text.Trim() == "TERM III")
                                                    exm = "TERMIII";
                                                else if (cmbExam.Text.Trim() == "TERM I P")
                                                    exm = "TERMIP";
                                                else if (cmbExam.Text.Trim() == "TERM II P")
                                                    exm = "TERMIIP";
                                                else if (cmbExam.Text.Trim() == "TERM III P")
                                                    exm = "TERMIIIP";
                                                r[c.ColumnName] = row[i][exm];
                                                decimal tval = 0;
                                                if (row[i][exm].Equals(DBNull.Value))
                                                    tval = 0;
                                                else
                                                    tval = Convert.ToDecimal(row[i][exm]);
                                                if (exm == "TERMI")
                                                {
                                                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) <= 108)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 70);          // 70---------
                                                    else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 109 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 111)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 100);



                                                }
                                                else if (exm == "TERMII")
                                                {
                                                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) <= 108)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 50);        // 50----------------
                                                    else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 109 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 111)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 100);
                                                }
                                                else if (exm == "TERMIII")
                                                {
                                                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) <= 111)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 100);
                                                }
                                                dtStudentList.EndInit();
                                                i++;
                                            }
                                        }
                                    }
                                }
                                dtg.DataSource = dtStudentList;
                                lblStatus.Text = "You Have Select " + cmbExam.Text;
                                chkLock.Checked = true;
                                tmr1.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Exam...", "");
                        cmbExam.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Section First!!!", "Section");
                    cmbSection.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Select Class First!!!", "Class");
                cmbClass.Focus();
            }
        }


        public void GetDetailsofNursary()
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                    if (!string.IsNullOrEmpty(cmbExam.Text))
                    {
                        ////Data Table Here Starting
                        dtg.DataSource = null; string tsubcode = string.Empty;
                        dtStudentList.Rows.Clear(); dtStudentList.Columns.Clear();
                        dtStudentList.Columns.Add("Student No", typeof(int));
                        dtStudentList.Columns.Add("Scholar No", typeof(string));
                        dtStudentList.Columns.Add("Name", typeof(string));
                        dataReader = Connection.GetDataReader("SELECT tbl_subject.subjectno, tbl_subject.subjectname,tbl_subwiseclass.subjecttype " +
                            " FROM tbl_subwiseclass INNER JOIN tbl_subject ON tbl_subwiseclass.subjectno = tbl_subject.subjectno " +
                            " WHERE (tbl_subwiseclass.classno = '" + cmbClass.SelectedValue + "') ORDER BY tbl_subject.SubjectOrder");
                        tsubcode = "0";
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                if (cmbExam.Text.ToString() == "TERM I" || cmbExam.Text.ToString() == "TERM II" || cmbExam.Text.ToString() == "TERM III")
                                {

                                    dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(decimal));
                                    dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = 0;
                                    dtStudentList.Columns.Add("Grade" + dataReader["subjectno"].ToString(), typeof(string));
                                    dtStudentList.Columns["Grade" + dataReader["subjectno"].ToString()].DefaultValue = "E";
                                    tsubcode = dataReader["subjectno"].ToString();

                                }
                                else
                                {
                                    dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(decimal));
                                    dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = 0;
                                    tsubcode = dataReader["subjectno"].ToString();

                                }
                            }
                            dataReader.Close();
                        }
                        ///
                        if (btnNew.Enabled.Equals(true))
                        {

                            DataTable n = Connection.GetDataTable("Select Top 1 TERMI ,TERMII ,TERMIII,TERMIP ,TERMIIP ,TERMIIIP  From tbl_MPSHHSSAStudentMarks " +
                                " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                                " And SessionCode='" + school.CurrentSessionCode + "'   ");
                            if (n.Rows.Count > 0)
                            {
                                if ("TERM I".Equals(cmbExam.Text.Trim()))
                                {
                                    MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else if ("TERM II".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["TERMI"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of TERM I!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["TERMII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM III".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["TERMI"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of TERM II!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["TERMII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of TERM II!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["TERMIII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM I P".Equals(cmbExam.Text.Trim()))
                                {
                                    if (!n.Rows[0]["TERMIP"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM II P".Equals(cmbExam.Text.Trim()))
                                {
                                    if (!n.Rows[0]["TERMIIP"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM III P".Equals(cmbExam.Text.Trim()))
                                {
                                    if (!n.Rows[0]["TERMIIIP"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }

                            }
                            else if (!cmbExam.Text.Trim().Equals("TERM I"))
                            {
                                MessageBox.Show("!!! Warrning : \n\t Please select TERM I");
                                return;
                            }

                            if (dtStudentList.Columns.Count > 0)
                            {
                                dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                                    " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                                    " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' ORDER BY tbl_student.name ");
                                if (dataReader.HasRows)
                                {
                                    while (dataReader.Read())
                                    {
                                        dtStudentList.Rows.Add(
                                            dataReader[0], dataReader[1], dataReader[2]);
                                    }
                                    dataReader.Close();
                                }
                                dtg.DataSource = dtStudentList;
                                lblStatus.Text = "You Have Select " + cmbExam.Text;
                                chkLock.Checked = true;
                                tmr1.Enabled = true;
                            }
                        }
                        else if (btnEdit.Enabled.Equals(true))
                        {
                            if (dtStudentList.Columns.Count > 0)
                            {
                                dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                                    " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                                    " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' ORDER BY tbl_student.name");

                                DataTable dtStudtntExamMarks = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail_SHHSSA] " + cmbClass.SelectedValue + "," + cmbSection.SelectedValue + "," + school.CurrentSessionCode + ",'E','" + cmbSankay.Text.ToString() + "'");
                                if (dataReader.HasRows)
                                {
                                    while (dataReader.Read())
                                    {
                                        dtStudentList.Rows.Add(
                                            dataReader[0], dataReader[1], dataReader[2]);
                                    }
                                    dataReader.Close();
                                }
                                foreach (DataRow r in dtStudentList.Rows)
                                {
                                    int i = 0;
                                    DataRow[] row = dtStudtntExamMarks.Select("StudentNo='" + r["Student No"] + "'");
                                    //for (int i = 0; i < row.Length; i++)
                                    if (row.Length > 0)
                                    {
                                        foreach (DataColumn c in dtStudentList.Columns)
                                        {
                                            if (!c.ColumnName.Contains("Student No") && !c.ColumnName.Contains("Scholar No")
                                                && !c.ColumnName.Contains("Name") && !c.ColumnName.Contains("Grade"))
                                            {
                                                string exm = string.Empty;
                                                if (cmbExam.Text.Trim() == "TERM I")
                                                    exm = "TERMI";
                                                else if (cmbExam.Text.Trim() == "TERM II")
                                                    exm = "TERMII";
                                                else if (cmbExam.Text.Trim() == "TERM III")
                                                    exm = "TERMIII";
                                                else if (cmbExam.Text.Trim() == "TERM I P")
                                                    exm = "TERMIP";
                                                else if (cmbExam.Text.Trim() == "TERM II P")
                                                    exm = "TERMIIP";
                                                else if (cmbExam.Text.Trim() == "TERM III P")
                                                    exm = "TERMIIIP";
                                                r[c.ColumnName] = row[i][exm];
                                                decimal tval = 0;
                                                if (row[i][exm].Equals(DBNull.Value))
                                                    tval = 0;
                                                else
                                                    tval = Convert.ToDecimal(row[i][exm]);
                                                if (exm == "TERMI")
                                                {
                                                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) <= 108)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 70);        // 70 ka hai------
                                                    else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 109 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 111)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 100);



                                                }
                                                else if (exm == "TERMII")
                                                {
                                                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) <= 108)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 50);        // 50 ka hai--------------------
                                                    else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 109 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 111)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 100);
                                                }
                                                else if (exm == "TERMIII")
                                                {
                                                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) <= 111)
                                                        r["Grade" + c.ColumnName] = this.GetGrade(tval, 100);
                                                }
                                                dtStudentList.EndInit();
                                                i++;
                                            }
                                        }
                                    }
                                }
                                dtg.DataSource = dtStudentList;
                                lblStatus.Text = "You Have Select " + cmbExam.Text;
                                chkLock.Checked = true;
                                tmr1.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select Exam...", "");
                        cmbExam.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Section First!!!", "Section");
                    cmbSection.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Select Class First!!!", "Class");
                cmbClass.Focus();
            }
        }



        private void btnShow_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cmbClass.SelectedValue) >= 101 && Convert.ToInt16(cmbClass.SelectedValue) < 106 ||  Convert.ToInt16(cmbClass.SelectedValue) == 115)
            {
                if (cmbExam.Text.Trim().ToString().Equals("TERM I") || cmbExam.Text.Trim().ToString().Equals("TERM II") || cmbExam.Text.Trim().ToString().Equals("TERM III"))
                    GetDetailsofI_V();
                else
                    MessageBox.Show("!!! Warnning \n\t Please select proper Exam. ");
            }
            else if (Convert.ToInt16(cmbClass.SelectedValue) >= 106 && Convert.ToInt16(cmbClass.SelectedValue) < 109)
            {
                if (cmbExam.Text.Trim().ToString().Equals("TERM I") || cmbExam.Text.Trim().ToString().Equals("TERM II") || cmbExam.Text.Trim().ToString().Equals("TERM III") || cmbExam.Text.Trim().ToString().Equals("TERM III P"))
                    GetDetailsofI_V();
                else
                    MessageBox.Show("!!! Warnning \n\t Please select proper Exam. ");
            }
            else if (Convert.ToInt16(cmbClass.SelectedValue) == 109)
            {
                if (cmbExam.Text.Trim().ToString().Equals("TERM I") || cmbExam.Text.Trim().ToString().Equals("TERM II") || cmbExam.Text.Trim().ToString().Equals("TERM III"))
                    GetDetailsofI_V();
                else
                    MessageBox.Show("!!! Warnning \n\t Please select proper Exam. ");
            }
            else if (Convert.ToInt16(cmbClass.SelectedValue) == 111)
            {
                if (cmbExam.Text.Trim().ToString().Equals("TERM I") || cmbExam.Text.Trim().ToString().Equals("TERM II") || cmbExam.Text.Trim().ToString().Equals("TERM III") || cmbExam.Text.Trim().ToString().Equals("TERM I P") || cmbExam.Text.Trim().ToString().Equals("TERM II P") || cmbExam.Text.Trim().ToString().Equals("TERM III P"))
                    GetDetailsof_XI();
                else
                    MessageBox.Show("!!! Warnning \n\t Please select proper Exam. ");
            }
            else
            {

                if (cmbExam.Text.Trim().ToString().Equals("TERM I") || cmbExam.Text.Trim().ToString().Equals("TERM II") || cmbExam.Text.Trim().ToString().Equals("TERM III"))
                    GetDetailsofNursary();
                else
                    MessageBox.Show("!!! Warnning \n\t Please select proper Exam. ");
                
            }
        }

        private void chkLock_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLock.Checked)
            {
                btnShow.Enabled = cmbExam.Enabled = false;
            }
            else
            {
                btnShow.Enabled = cmbExam.Enabled = true;
                dtg.DataSource = null;
                lblStatus.Text = string.Empty;
                cmbExam.Focus();
            }
        }

        private void dtg_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                MessageBox.Show("Please Fill Valide Marks.");
            }
            catch
            {

            }
        }
        public string GetGrade(decimal obtm, int maxm)
        {
            string res = string.Empty;
            obtm = Math.Round(obtm, 0);
            obtm = (obtm * 100) / maxm;
            if (obtm >= 75 && obtm <= 100)
                res = "A";
            else if (obtm >= 60 && obtm < 75)
                res = "B";
            else if (obtm >= 45 && obtm < 60)
                res = "C";
            else if (obtm >= 33 && obtm < 45)
                res = "D";
            else if (obtm >= 0 && obtm < 33)
                res = "E";
            return res;
        }

        private void dtg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TextInfo myTextInfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
            string str = string.Empty;
            int columnIndex = dtg.CurrentCell.ColumnIndex;
            columnName = dtg.Columns[columnIndex].HeaderText;
            
            if (cmbExam.Text.Equals("TERM I"))
            {
                if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 111 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 109)
                    this.MaximumMarks = 100;
                else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) < 115 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 115)
                    this.MaximumMarks = 70;    // 70 
                //else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) > 112 && columnName.Contains("ORAL"))
                    //this.MaximumMarks = 20;
                //else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) > 112 && !columnName.Contains("ORAL"))
                    //this.MaximumMarks = 30;

                if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                {

                    str = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText.ToString().Trim();
                
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) > 115)
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = Connection.GetGradePrimary(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16( this.MaximumMarks));
                    else
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));
                }
                else
                {
                    MessageBox.Show("Please Fill Valide Marks.");
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));
                }

            }
            else if (cmbExam.Text.Equals("TERM II"))
            {
                if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 111 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 109)
                    this.MaximumMarks = 100;
                else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) >= 101 && Convert.ToInt16(cmbClass.SelectedValue.ToString()) < 115 || Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 115)
                    this.MaximumMarks = 50;       // 50-----------------
                //else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) > 112 && columnName.Contains("ORAL"))
                //    this.MaximumMarks = 20;
                //else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) > 112 && !columnName.Contains("ORAL"))
                //    this.MaximumMarks = 30;

                if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                {
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) > 115)
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = Connection.GetGradePrimary(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));
                        else
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));
                }
                else
                {
                    MessageBox.Show("Please Fill Valide Marks.");
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));
                }
            }
            else if (cmbExam.Text.Equals("TERM III"))
            {
                
                //if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) > 112 && columnName.Contains("ORAL"))
                //    this.MaximumMarks = 20;
                //else if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) > 112 && !columnName.Contains("ORAL"))
                //    this.MaximumMarks = 30;
                //else
                    this.MaximumMarks = 100;
                if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                {

                    str = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText.ToString().Trim();

                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) > 115)
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = Connection.GetGradePrimary(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));
                    else
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));


                }
                else
                {
                    MessageBox.Show("Please Fill Valide Marks.");
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));
                }
            }
            else if (cmbExam.Text.Equals("TERM I P"))
            {
                this.MaximumMarks = 25;
                if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                {
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
                else
                {
                    MessageBox.Show("Please Fill Valide Marks.");
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));
                }
            }
            else if (cmbExam.Text.Equals("TERM II P"))
            {
                this.MaximumMarks = 25;
                if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                {
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
                else
                {
                    MessageBox.Show("Please Fill Valide Marks.");
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value), Convert.ToInt16(this.MaximumMarks));
                }
            }
            else if (cmbExam.Text.Equals("TERM III P"))
            {
                if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 111)
                    this.MaximumMarks = 25;
                else
                    this.MaximumMarks = 20;
                if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                {
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                }
                else
                {
                    MessageBox.Show("Please Fill Valide Marks.");
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }
        }

        private void dtg_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtg.RowCount > 0)
            {
                foreach (DataGridViewColumn dtgc in dtg.Columns)
                {
                    if (!dtgc.Name.Contains("Grade"))
                    {
                        dataReader = Connection.GetDataReader("SELECT subjectno, subjectname " +
                          " FROM tbl_subject WHERE (subjectno= '" + dtgc.Name + "')");
                        if (dataReader.HasRows)
                        {
                            dataReader.Read();
                            dtgc.HeaderText = dataReader["subjectname"].ToString();
                            dataReader.Close();
                        }
                        dtgc.Width = 80;
                        dtgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    else if (dtgc.Name.Contains("Grade"))
                    {
                        dtgc.ReadOnly = true;
                        dtgc.HeaderText = "Grade";
                        dtgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dtgc.Width = 40;
                    }
                }

                dtg.Columns[0].Visible = false;
                dtg.Columns[1].ReadOnly = true;
                dtg.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtg.Columns[2].ReadOnly = true;
                dtg.Columns[2].Width = 120;
                dtg.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            }
        }

        private void dtg_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), dtg.Font, new SolidBrush(Color.Maroon), e.RowBounds.X + 2, e.RowBounds.Y + 3);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnFinalSave.Enabled = true;
            btnShow.Enabled = true;
            cmbClass.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = false;
            btnFinalSave.Enabled = true;
            btnShow.Enabled = true;
            cmbClass.Focus();
        }

        private void btnFinalSave_Click(object sender, EventArgs e)
        {
            SqlTransaction trn = null;
            try
            {
                if (!string.IsNullOrEmpty(cmbClass.Text) && !string.IsNullOrEmpty(cmbSection.Text) &&
                    !string.IsNullOrEmpty(cmbExam.Text))
                {
                    dtg.EndEdit();
                    if (dtg.RowCount > 0)
                    {
                        if (cmbExam.Text.Trim().Equals("TERM I") && btnNew.Enabled)
                        {
                            trn = Connection.GetMyConnection().BeginTransaction();
                            int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_MPSHHSSAStudentMarks"));

                            foreach (DataGridViewRow dr in dtg.Rows)
                            {
                                foreach (DataGridViewColumn dc in dtg.Columns)
                                {
                                    if (dc.Index > 2)
                                    {
                                        if (!dc.Name.Contains("Grade"))
                                        {
                                            Connection.SqlTransection("Insert InTo tbl_MPSHHSSAStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, TERMI,Stream) Values(" +
                                              "'" + CCEID + "','" + dr.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + dc.Name + "', " +
                                              "'" + school.CurrentSessionCode + "','" + dr.Cells[dc.Name].Value + "','" + cmbSankay.SelectedValue.ToString() + "')", Connection.MyConnection, trn);
                                        }
                                    }
                                }
                                CCEID++;
                            }
                            trn.Commit();
                        }
                        else
                        {



                            foreach (DataGridViewRow dr in dtg.Rows)
                            {
                                int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_MPSHHSSAStudentMarks"));
                                int CCECcount = Convert.ToInt32(Connection.GetId("select ISNULL(COUNT(StudentNo),0) From tbl_MPSHHSSAStudentMarks where StudentNo='" + dr.Cells["Student No"].Value + "' and ClassNo='" + cmbClass.SelectedValue + "' and SessionCode='" + school.CurrentSessionCode + "'"));
                                if (CCECcount < 1)
                                {
                                    trn = Connection.GetMyConnection().BeginTransaction();
                                    foreach (DataGridViewColumn dc in dtg.Columns)
                                    {
                                        if (dc.Index > 2)
                                        {
                                            if (!dc.Name.Contains("Grade"))
                                            {
                                                Connection.SqlTransection("Insert InTo tbl_MPSHHSSAStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, TERMI,Stream) Values(" +
                                                  "'" + CCEID + "','" + dr.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + dc.Name + "', " +
                                                  "'" + school.CurrentSessionCode + "','" + dr.Cells[dc.Name].Value + "','" + cmbSankay.SelectedValue.ToString() + "')", Connection.MyConnection, trn);
                                            }
                                        }
                                    }
                                    trn.Commit();
                                }
                                else
                                {
                                    trn = Connection.GetMyConnection().BeginTransaction();
                                    string EXM = string.Empty;
                                    if (cmbExam.Text.Trim() == "TERM I")
                                        EXM = "TERMI";
                                    else if (cmbExam.Text.Trim() == "TERM II")
                                        EXM = "TERMII";
                                    else if (cmbExam.Text.Trim() == "TERM III")
                                        EXM = "TERMIII";
                                    else if (cmbExam.Text.Trim() == "TERM I P")
                                        EXM = "TERMIP";
                                    else if (cmbExam.Text.Trim() == "TERM II P")
                                        EXM = "TERMIIP";
                                    else if (cmbExam.Text.Trim() == "TERM III P")
                                        EXM = "TERMIIIP";

                                    foreach (DataGridViewColumn dc in dtg.Columns)
                                    {
                                        if (dc.Index > 2)
                                        {

                                            if (!dc.Name.Contains("Grade"))
                                            {
                                                Connection.SqlTransection("Update tbl_MPSHHSSAStudentMarks Set " + EXM + "='" + dr.Cells[dc.Name].Value + "' " +
                                                    " Where  StudentNo='" + dr.Cells["Student No"].Value + "' And ClassNo ='" + cmbClass.SelectedValue + "' And " +
                                                    " SectionCode='" + cmbSection.SelectedValue + "' And  SubjectNo='" + dc.Name + "' And SessionCode='" + school.CurrentSessionCode + "' " +
                                                    " ", Connection.MyConnection, trn);
                                            }
                                        }
                                    }
                                    trn.Commit();
                                }
                            }
                        }

                        MessageBox.Show("Saved...");
                        btnNew.Enabled = true;
                        btnEdit.Enabled = true;
                        btnFinalSave.Enabled = false;
                        btnShow.Enabled = false;
                        btnNew.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
                MessageBox.Show("Exception message:\n    " + ex.Message);
                trn.Rollback();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnFinalSave.Enabled = false;
            btnShow.Enabled = false;
            btnNew.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            lblStatus.ForeColor = Color.FromKnownColor(randomColorName);
            chkLock.ForeColor = (chkLock.Checked) ? Color.FromKnownColor(randomColorName) : Color.White;
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
        public string GetGradeToPrimary(int studno, string des, int f)
        {
            string result = string.Empty;
            DataTable n = Connection.GetDataTable("select Grade from tbl_MPSHHSSAStudentSkills " +
                              " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                              " And SessionCode='" + school.CurrentSessionCode + "' And StudentNo='" + studno + "' And SkillId='" + des + "' And ExamCode='" + cmbExam.SelectedIndex + "'");
            if (n.Rows.Count > 0)
            {
                result = n.Rows[0]["Grade"].ToString();
            }
            else
            {
                if (f == 0)
                    result = string.Empty;
                else
                    result = "0";

            }
            return result;
        }
        private void btnViewDesInd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {

                    if (!string.IsNullOrEmpty(cmbExam.Text))
                    {
                        if (cmbClass.Text.Equals("IX"))
                        {
                            if (cmbExam.Text.Equals("TERM III"))
                            {
                                MessageBox.Show("Please Select Exam carefully...");
                                //cmbExam.Focus();
                                //return;
                            }
                            DataTable dtStudent = new DataTable("dtStudent");

                            dtStudent.Columns.Add("Student No", typeof(int));
                            dtStudent.Columns.Add("Scholar No", typeof(string));
                            dtStudent.Columns.Add("Name", typeof(string));
                            //dtgSkills.DataSource = dtStudent;
                            dataReader = Connection.GetDataReader("SELECT tbl_CCEClassSkill.SkillId, tbl_CCESkills.SkillName  " +
                              " FROM tbl_CCEClassSkill INNER JOIN tbl_CCESkills ON tbl_CCEClassSkill.SkillId = tbl_CCESkills.SkillId " +
                              " WHERE (tbl_CCEClassSkill.ClassCode = '" + cmbClass.SelectedValue + "') AND (tbl_CCEClassSkill.SessionCode = '" + school.CurrentSessionCode + "')  " +
                              " ORDER BY tbl_CCEClassSkill.SkillOrder");
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    if (dataReader["SkillName"].ToString().Contains("Science") && cmbExam.Text.Equals("TERM II"))
                                    {
                                        dtStudent.Columns.Add(dataReader["SkillId"].ToString(), typeof(int));
                                        dtStudent.Columns[dataReader["SkillId"].ToString()].DefaultValue = "0";
                                        dtStudent.Columns.Add("Grade" + dataReader["SkillId"].ToString(), typeof(string));
                                        dtStudent.Columns["Grade" + dataReader["SkillId"].ToString()].DefaultValue = "E";
                                    }
                                    if (cmbExam.Text.Equals("TERM I"))
                                    {

                                        if (dataReader["SkillName"].ToString().Contains("Science"))
                                        {
                                            dtStudent.Columns.Add(dataReader["SkillId"].ToString(), typeof(int));
                                            dtStudent.Columns[dataReader["SkillId"].ToString()].DefaultValue = "0";
                                            dtStudent.Columns.Add("Grade" + dataReader["SkillId"].ToString(), typeof(string));
                                            dtStudent.Columns["Grade" + dataReader["SkillId"].ToString()].DefaultValue = "E";
                                        }
                                        else
                                        {
                                            dtStudent.Columns.Add(dataReader["SkillId"].ToString(), typeof(string));
                                        }

                                    }

                                }
                                dataReader.Close();
                            }

                            dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                              " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                              " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "') " +
                              " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' ORDER BY tbl_student.name");
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {

                                    DataRow row = dtStudent.NewRow();
                                    for (int c = 3; c < dtStudent.Columns.Count; c++)
                                    {
                                        if (dtStudent.Columns[c].ColumnName.ToString().Contains("Grade"))
                                        {
                                            if (cmbExam.Text.Equals("TERM I"))
                                                row[dtStudent.Columns[c].ColumnName.ToString()] = GetGrade(Convert.ToDecimal(GetGradeToPrimary(Convert.ToInt16(dataReader["StudentNo"]), dtStudent.Columns[c - 1].ColumnName.ToString(), 1)),13);
                                            if (cmbExam.Text.Equals("TERM II"))
                                                row[dtStudent.Columns[c].ColumnName.ToString()] = GetGrade(Convert.ToDecimal(GetGradeToPrimary(Convert.ToInt16(dataReader["StudentNo"]), dtStudent.Columns[c - 1].ColumnName.ToString(), 1)),25);
                                        }
                                        if (!dtStudent.Columns[c].ColumnName.ToString().Contains("Grade"))
                                        {
                                            if (dtStudent.Columns[c].DataType.Name.ToString().Equals("Int32"))
                                            {
                                                row[dtStudent.Columns[c].ColumnName.ToString()] = GetGradeToPrimary(Convert.ToInt16(dataReader["StudentNo"]), dtStudent.Columns[c].ColumnName.ToString(), 1);
                                            }
                                            if (!dtStudent.Columns[c].DataType.Name.ToString().Equals("Int32"))
                                            {
                                                row[dtStudent.Columns[c].ColumnName.ToString()] = GetGradeToPrimary(Convert.ToInt16(dataReader["StudentNo"]), dtStudent.Columns[c].ColumnName.ToString(), 0);
                                            }

                                        }

                                    }
                                    row["Student No"] = dataReader["StudentNo"];
                                    row["Scholar No"] = dataReader["Scholar No."];
                                    row["Name"] = dataReader["Name"];

                                    dtStudent.Rows.Add(row);
                                }
                                dataReader.Close();
                            }


                            dtgSkills.DataSource = dtStudent;
                            btnSaveDesInd.Enabled = true;
                        }
                        else
                        {
                            if (cmbExam.Text.Equals("TERM II") || cmbExam.Text.Equals("TERM III"))
                            {
                                MessageBox.Show("Please Select Exam carefully...");
                                //cmbExam.Focus();
                                //return;
                            }
                            DataTable dtStudent = new DataTable("dtStudent");

                            dtStudent.Columns.Add("Student No", typeof(int));
                            dtStudent.Columns.Add("Scholar No", typeof(string));
                            dtStudent.Columns.Add("Name", typeof(string));
                            //dtgSkills.DataSource = dtStudent;
                            dataReader = Connection.GetDataReader("SELECT tbl_CCEClassSkill.SkillId, tbl_CCESkills.SkillName  " +
                              " FROM tbl_CCEClassSkill INNER JOIN tbl_CCESkills ON tbl_CCEClassSkill.SkillId = tbl_CCESkills.SkillId " +
                              " WHERE (tbl_CCEClassSkill.ClassCode = '" + cmbClass.SelectedValue + "') AND (tbl_CCEClassSkill.SessionCode = '" + school.CurrentSessionCode + "')  " +
                              " ORDER BY tbl_CCEClassSkill.SkillOrder");
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    dtStudent.Columns.Add(dataReader["SkillId"].ToString(), typeof(string));
                                }
                                dataReader.Close();
                            }

                            dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                              " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                              " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "') " +
                              " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' ORDER BY tbl_student.name");
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {

                                    DataRow row = dtStudent.NewRow();
                                    for (int c = 3; c < dtStudent.Columns.Count; c++)
                                    {
                                        row[dtStudent.Columns[c].ColumnName.ToString()] = GetGradeToPrimary(Convert.ToInt16(dataReader["StudentNo"]), dtStudent.Columns[c].ColumnName.ToString(), 0);
                                    }
                                    row["Student No"] = dataReader["StudentNo"];
                                    row["Scholar No"] = dataReader["Scholar No."];
                                    row["Name"] = dataReader["Name"];

                                    dtStudent.Rows.Add(row);
                                }
                                dataReader.Close();
                            }


                            dtgSkills.DataSource = dtStudent;
                            btnSaveDesInd.Enabled = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Select Exam...", "");
                        cmbExam.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Section First!!!", "Section");
                    cmbSection.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please Select Class First!!!", "Class");
                cmbClass.Focus();
            }
        }

        private void dtgSkills_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                // MessageBox.Show("Please Fill Valide Grade.");
            }
            catch
            {

            }
        }

        private void dtgSkills_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn c in dtgSkills.Columns)
            {
                c.ReadOnly = true;
                if (c.Index > 2)
                {
                    if (c.Name.Contains("Grade"))
                    {
                        c.ReadOnly = true;
                        c.HeaderText = "Grade";
                        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        c.Width = 40;
                    }
                    else
                    {
                        c.ReadOnly = false;
                        c.HeaderText = Convert.ToString(Connection.GetExecuteScalar("Select SkillName From tbl_CCESkills Where SkillId='" + c.Name + "'"));
                    }
                }
            }
            dtgSkills.Columns["Student No"].Visible = false;
            dtgSkills.Columns["Scholar No"].Width = 80;
            dtgSkills.Columns["Name"].Width = 150;
        }

        private void btnSaveDesInd_Click(object sender, EventArgs e)
        {
            if (dtgSkills.RowCount > 0 &&
               DialogResult.Yes.Equals(MessageBox.Show("Are You Sure To Save Descriptive Indicators For Class \"" + cmbClass.Text + " " + cmbSection.Text + "\"?", "Descriptive Indicators", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                dtgSkills.EndEdit();
                SqlTransaction trn = null;
                string cmdText = string.Empty;
                int CCEID = Convert.ToInt32(Connection.GetExecuteScalar(" Select Min(CCEID) From tbl_MPSHHSSAStudentMarks Where ClassNo='" + cmbClass.SelectedValue + "' " +
                    " And SectionCode='" + cmbSection.SelectedValue + "' And SessionCode='" + school.CurrentSessionCode + "'"));

                trn = Connection.GetMyConnection().BeginTransaction();
                try
                {
                    cmdText = " DELETE FROM tbl_MPSHHSSAStudentSkills WHERE ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                        " And SessionCode='" + school.CurrentSessionCode + "' And ExamCode='" + cmbExam.SelectedIndex + "'";
                    Connection.SqlTransection(cmdText, Connection.MyConnection, trn);

                    foreach (DataGridViewRow r in dtgSkills.Rows)
                    {
                        foreach (DataGridViewColumn c in dtgSkills.Columns)
                        {
                            if (c.Index > 2)
                            {
                                if (c.Name.Contains("Grade"))
                                {
                                    //--------
                                }
                                else
                                {
                                    cmdText = "INSERT INTO tbl_MPSHHSSAStudentSkills(CCEID,SessionCode,SkillId,Grade,Status,StudentNo,ClassNo,SectionCode,ExamCode)  VALUES " +
                                       "('" + CCEID + "','" + school.CurrentSessionCode + "','" + c.Name + "','" + r.Cells[c.Name].Value + "'," +
                                       " 1,'" + r.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + cmbExam.SelectedIndex + "')";
                                    Connection.SqlTransection(cmdText, Connection.MyConnection, trn);
                                }

                            }
                        }
                        if (!r.Cells["Name"].Value.Equals(DBNull.Value))
                            CCEID++;
                    }
                    trn.Commit();
                    MessageBox.Show("Descriptive Indicators Saved Successfully Of Class \"" + cmbClass.Text + " " + cmbSection.Text + "\"...", "Descriptive Indicators");
                    tbAcadminSkills.SelectedTab = tabPage1;
                    //  btnSaveDesInd.Enabled = false;

                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Record Not Saved Please Try Again...");
                    trn.Rollback();
                    btnSaveDesInd.Enabled = false;
                }
            }
        }
        static int tr = 0;
        private void dtgSkills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tr = 0;
            tr = e.RowIndex;
            if (e.ColumnIndex > 2 && e.RowIndex > -1)
            {
                string st = string.Empty;
                st = dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = st.ToUpper();
            }
        }

        private void dtgSkills_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            int rindx = 0;
            if (tr == e.RowIndex)
                rindx = e.RowIndex;
            else
                rindx = e.RowIndex - 1;

            if (e.ColumnIndex > 2 && rindx > -1 && tr != -1)
            {
                string st = string.Empty;
                st = dtgSkills.Rows[rindx].Cells[e.ColumnIndex].Value.ToString();
                dtgSkills.Rows[rindx].Cells[e.ColumnIndex].Value = st.ToUpper();
            }
        }

        private void dtgSkills_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cmbClass.Text.Equals("IX"))
            {
                if (e.ColumnIndex > 2 && e.RowIndex > -1)
                {

                    if (dtgSkills.Columns[e.ColumnIndex].ValueType.Name.ToString() == "Int32")
                    {
                        Int16 st = 0;
                        st = Convert.ToInt16(dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        if (cmbExam.Text.Equals("TERM I"))
                        {
                            if (st <= 13)
                            {
                                dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = GetGrade(Convert.ToDecimal(st),13);
                            }
                            else
                            {
                                MessageBox.Show("PleaseFill Valide Marks.");
                                dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                                dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value),13);
                            }
                        }
                        if (cmbExam.Text.Equals("TERM II"))
                        {
                            if (st <= 25)
                            {
                                dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = GetGrade(Convert.ToDecimal(st),25);
                            }
                            else
                            {
                                MessageBox.Show("PleaseFill Valide Marks.");
                                dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                                dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value),25);
                            }
                        }
                    }
                    if (dtgSkills.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                    {
                        string st = string.Empty;
                        st = dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                        dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = st.ToUpper();
                    }
                }
            }
            else
            {
                if (e.ColumnIndex > 2 && e.RowIndex > -1)
                {
                    string st = string.Empty;
                    st = dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = st.ToUpper();
                }
            }

        }

        
    }
}
