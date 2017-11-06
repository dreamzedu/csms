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

namespace SMS.MpBoardMarksheet
{
    public partial class FrmMPCCMarksheetMS : UserControl
    {
        DataTable dtStudentList = new DataTable("dtStudentList");
        DataTable dtFinallMarksOfStudentList = new DataTable("dtFinallMarksOfStudentList");
        SqlDataReader dataReader = null;
        bool ExamFlage = false;
        bool NonPrimaryFlage = false;
        decimal MaximumMarks;

        private string GetGradeNonPrimary(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 91 && ObtainMarks <= 100)
                Grade = "A1";
            else if (ObtainMarks >= 81 && ObtainMarks <= 90)
                Grade = "A2";
            else if (ObtainMarks >= 71 && ObtainMarks <= 80)
                Grade = "B1";
            else if (ObtainMarks >= 61 && ObtainMarks <= 70)
                Grade = "B2";
            else if (ObtainMarks >= 51 && ObtainMarks <= 60)
                Grade = "C1";
            else if (ObtainMarks >= 41 && ObtainMarks <= 50)
                Grade = "C2";
            else if (ObtainMarks >= 33 && ObtainMarks <= 40)
                Grade = "D";
            else if (ObtainMarks >= 21 && ObtainMarks <= 32)
                Grade = "E1";
            else if (ObtainMarks >= 0 && ObtainMarks <= 20)
                Grade = "E2";
            return Grade;
        }

        private string GetGradePrimary(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 90 && ObtainMarks <= 100)
                Grade = "A+";
            else if (ObtainMarks >= 75 && ObtainMarks <= 89)
                Grade = "A";
            else if (ObtainMarks >= 56 && ObtainMarks <= 74)
                Grade = "B";
            else if (ObtainMarks >= 35 && ObtainMarks <= 55)
                Grade = "C";
            else if (ObtainMarks >= 0 && ObtainMarks <= 35)
                Grade = "D";
            return Grade;
        }
        static string columnName = string.Empty;
        public FrmMPCCMarksheetMS()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }

        private void FrmMPCCMarksheetMS_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Order By ClassOrder");
            Connection.FillComboBox(cmbSection, "Select SectionCode ,SectionName From tbl_Section");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                    //if (!string.IsNullOrEmpty(cmbExam.Text))
                    //{
                    ////Data Table Here Starting
                    dtg.DataSource = null;
                    dtStudentList.Rows.Clear(); dtStudentList.Columns.Clear();
                    dtStudentList.Columns.Add("Student No", typeof(int));
                    dtStudentList.Columns.Add("Scholar No", typeof(string));
                    dtStudentList.Columns.Add("Name", typeof(string));
                    dataReader = Connection.GetDataReader("SELECT tbl_subject.subjectno, tbl_subject.subjectname,tbl_subwiseclass.subjecttype " +
                        " FROM tbl_subwiseclass INNER JOIN tbl_subject ON tbl_subwiseclass.subjectno = tbl_subject.subjectno " +
                        " WHERE (tbl_subwiseclass.classno = '" + cmbClass.SelectedValue + "') ORDER BY tbl_subject.SubjectOrder");
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            if (dataReader["subjecttype"].ToString() == "Elective Subject")
                            {
                                //Jul
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Jul", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Jul"].DefaultValue = "E";
                                //Aug
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Aug", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Aug"].DefaultValue = "E";
                                //Sep
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Sep", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Sep"].DefaultValue = "E";
                                //Oct
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Oct", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Oct"].DefaultValue = "E";
                                //HYEx
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_HYEx", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_HYEx"].DefaultValue = "E";
                                //Dec
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Dec", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Dec"].DefaultValue = "E";
                                //Jan
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Jan", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Jan"].DefaultValue = "E";
                                //Feb
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Feb", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Feb"].DefaultValue = "E";
                                //ANEx
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_ANEx", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_ANEx"].DefaultValue = "E";
                                //YeRes
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_YeRes", typeof(string));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_YeRes"].DefaultValue = "E";
                            }
                            else
                            {
                                //Jul
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Jul", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Jul"].DefaultValue = 0;
                                //Aug
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Aug", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Aug"].DefaultValue = 0;
                                //Sep
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Sep", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Sep"].DefaultValue = 0;
                                //Oct
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Oct", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Oct"].DefaultValue = 0;
                                //HYEx
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_HYEx", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_HYEx"].DefaultValue = 0;
                                //Dec
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Dec", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Dec"].DefaultValue = 0;
                                //Jan
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Jan", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Jan"].DefaultValue = 0;
                                //Feb
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_Feb", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_Feb"].DefaultValue = 0;
                                //ANEx
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_ANEx", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_ANEx"].DefaultValue = 0;
                                //YeRes
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString() + "_YeRes", typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString() + "_YeRes"].DefaultValue = 0;
                            }
                           

                        }
                        dataReader.Close();
                    }
                    ///
                    if (btnNew.Enabled.Equals(true))
                    {
                        int CCECcount = Convert.ToInt32(Connection.GetId("Select ISNULL(COUNT(StudentNo),0)  From tbl_MSCCEStudentMarks " +
                            " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                            " And SessionCode='" + school.CurrentSessionCode + "'   "));
                        if (CCECcount > 0)
                        {
                            MessageBox.Show("Record Already Exists!!!");
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

                            DataTable dtStudtntExamMarks = Connection.GetDataTable("[dbo].[GetViewMSCCEMarksDetail] " + cmbClass.SelectedValue + "," + cmbSection.SelectedValue + "," + school.CurrentSessionCode + "");
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
                                int i = 0, j = 0; string f = string.Empty;
                                DataRow[] row = dtStudtntExamMarks.Select("StudentNo='" + r["Student No"] + "'");
                                //for (int i = 0; i < row.Length; i++)
                                if (row.Length > 0)
                                {
                                    foreach (DataColumn c in dtStudentList.Columns)
                                    {
                                        if (!c.ColumnName.Contains("Student No") && !c.ColumnName.Contains("Scholar No")
                                            && !c.ColumnName.Contains("Name"))
                                        {
                                            string[] sec = c.ColumnName.Split('_');

                                            if (i == 0 && j == 0)
                                                f = sec[0].ToString();

                                            if (sec[0].ToString().Equals(f))
                                            {
                                                //---
                                                f = sec[0].ToString();
                                            }
                                            else
                                            {
                                                i++;
                                                f = sec[0].ToString();
                                            }
                                            if (c.DataType.Name.ToString().Equals("Decimal"))
                                            {
                                                j = 1;
                                                if (string.IsNullOrEmpty(row[i][sec[1].ToString()].ToString()))
                                                {
                                                    r[c.ColumnName] = 0;
                                                }
                                                else
                                                {
                                                    r[c.ColumnName] = row[i][sec[1].ToString()];
                                                }
                                            }
                                            else
                                            {
                                                j = 1;
                                                r[c.ColumnName] = row[i][sec[1].ToString()];
                                            }

                                            //r["Grade" + c.ColumnName] = row[i][cmbExam.Text.Trim() + " G"];
                                            dtStudentList.EndInit();

                                        }
                                    }
                                }
                            }
                            dtg.DataSource = dtStudentList;
                            dtg.Columns["Scholar No"].Frozen = true;
                            dtg.Columns["Name"].Frozen = true;
                            lblStatus.Text = "You Have Select " + cmbExam.Text;
                            chkLock.Checked = true;
                            tmr1.Enabled = true;
                        }
                    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Please Select Exam...", "");
                    //    cmbExam.Focus();
                    //}
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

        private void dtg_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dtg.RowCount > 0)
            {
                foreach (DataGridViewColumn dtgc in dtg.Columns)
                {
                    if (!dtgc.Name.Contains("Grade"))
                    {
                        string[] sec = dtgc.Name.Split('_');
                        dataReader = Connection.GetDataReader("SELECT subjectno, subjectname " +
                          " FROM tbl_subject WHERE (subjectno= '" + sec[0].ToString() + "')");
                        if (dataReader.HasRows)
                        {
                            dataReader.Read();
                            dtgc.HeaderText = sec[1].ToString() + dataReader["subjectname"].ToString();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
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

        private void tmr1_Tick(object sender, EventArgs e)
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            lblStatus.ForeColor = Color.FromKnownColor(randomColorName);
            chkLock.ForeColor = (chkLock.Checked) ? Color.FromKnownColor(randomColorName) : Color.White;
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

        private void dtg_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), dtg.Font, new SolidBrush(Color.Maroon), e.RowBounds.X + 2, e.RowBounds.Y + 3);
        }

        private void dtgSkills_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dtgSkills.Rows)
            {
                if (r.Cells["Name"].Value != DBNull.Value &&
                     r.Cells["Scholar No"].Value != DBNull.Value)
                {
                    r.DefaultCellStyle.BackColor = Color.LightGray;
                    //// r.Cells["Scholar No"].Style.ForeColor = Color.LightGray;
                    // r.Cells["Scholar No"].Style.BackColor = Color.LightGray;
                    //// r.Cells["Scholar No"].Style.ForeColor  = Color.LightGray; 

                    // r.DefaultCellStyle.BackColor = Color.DodgerBlue;
                    // r.DefaultCellStyle.ForeColor = Color.White; 
                }
            }

            foreach (DataGridViewColumn c in dtgSkills.Columns)
            {
                c.ReadOnly = true;
                if (c.Index > 2)
                {
                    c.ReadOnly = false;
                    this.dtgSkills.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
                    //if (c.Name.Contains("CheckBox") || c.Name.Contains("ObtainGrade"))
                    //{
                    //    c.Width = 20;
                    //    c.HeaderText = "";
                    //    if (c.Name.Contains("ObtainGrade"))
                    //    {
                    //        c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //        c.DefaultCellStyle.BackColor = Color.LightGray;
                    //        c.DefaultCellStyle.ForeColor = Color.Navy;
                    //    }

                    //    c.ReadOnly = false;
                    //}
                    if (!c.Name.Contains("CheckBox") && !c.Name.Contains("ObtainGrade"))
                    {
                        string[] colnm = c.Name.Split('_');
                        c.HeaderText = Convert.ToString(Connection.GetExecuteScalar("Select SkillName From tbl_CCESkills Where SkillId='" + colnm[0].ToString() + "'"));
                    }
                }
            }
            if (!this.NonPrimaryFlage)
            {
                foreach (DataGridViewColumn c in dtgSkills.Columns)
                    c.ReadOnly = false;
                dtgSkills.Columns["Student No"].ReadOnly = dtgSkills.Columns["Scholar No"].ReadOnly = dtgSkills.Columns["Name"].ReadOnly = true;
                this.dtgSkills.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            }

            dtgSkills.Columns["Student No"].Visible = false;
            dtgSkills.Columns["Scholar No"].Width = 80;
            dtgSkills.Columns["Name"].Width = 150;
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

        private void btnFinalSave_Click(object sender, EventArgs e)
        {
            SqlTransaction trn = null;
            try
            {
                if (!string.IsNullOrEmpty(cmbClass.Text) && !string.IsNullOrEmpty(cmbSection.Text))
                {
                    dtg.EndEdit();
                    if (dtg.RowCount > 0)
                    {
                        if (btnNew.Enabled)
                        {
                            string f = string.Empty;
                            trn = Connection.GetMyConnection().BeginTransaction();
                            int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_MSCCEStudentMarks"));

                            foreach (DataGridViewRow dr in dtg.Rows)
                            {
                                foreach (DataGridViewColumn dc in dtg.Columns)
                                {
                                    if (dc.Index > 2 && !dc.Name.Contains("Grade"))
                                    {
                                        string[] sec = dc.Name.Split('_');
                                        if (!sec[0].ToString().Equals(f))
                                        {
                                            Connection.SqlTransection("Insert InTo tbl_MSCCEStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, " + sec[1].ToString() + ") Values(" +
                                              "'" + CCEID + "','" + dr.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + sec[0].ToString() + "', " +
                                              "'" + school.CurrentSessionCode + "','" + dr.Cells[dc.Name].Value + "')", Connection.MyConnection, trn);
                                            f = sec[0].ToString();
                                        }
                                        else
                                        {
                                            Connection.SqlTransection("Update tbl_MSCCEStudentMarks Set " + sec[1].ToString() + "='" + dr.Cells[dc.Name].Value + "' " +
                                                " Where  StudentNo='" + dr.Cells["Student No"].Value + "' And ClassNo ='" + cmbClass.SelectedValue + "' And " +
                                                " SectionCode='" + cmbSection.SelectedValue + "' And  SubjectNo='" + sec[0].ToString() + "' And SessionCode='" + school.CurrentSessionCode + "' " +
                                                " ", Connection.MyConnection, trn);
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
                                int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_MSCCEStudentMarks"));
                                int CCECcount = Convert.ToInt32(Connection.GetId("select ISNULL(COUNT(StudentNo),0) From tbl_MSCCEStudentMarks where StudentNo='" + dr.Cells["Student No"].Value + "' and ClassNo='" + cmbClass.SelectedValue + "' and SessionCode='" + school.CurrentSessionCode + "'"));
                                if (CCECcount < 1)
                                {
                                    string f = string.Empty;
                                    trn = Connection.GetMyConnection().BeginTransaction();
                                    foreach (DataGridViewColumn dc in dtg.Columns)
                                    {
                                        if (dc.Index > 2 && !dc.Name.Contains("Grade"))
                                        {
                                            string[] sec = dc.Name.Split('_');
                                            if (!sec[0].ToString().Equals(f))
                                            {
                                                Connection.SqlTransection("Insert InTo tbl_MSCCEStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, " + sec[1].ToString() + ") Values(" +
                                              "'" + CCEID + "','" + dr.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + sec[0].ToString() + "', " +
                                              "'" + school.CurrentSessionCode + "','" + dr.Cells[dc.Name].Value + "')", Connection.MyConnection, trn);
                                                f = sec[0].ToString();
                                            }
                                            else
                                            {
                                                Connection.SqlTransection("Update tbl_MSCCEStudentMarks Set " + sec[1].ToString() + "='" + dr.Cells[dc.Name].Value + "' " +
                                               " Where  StudentNo='" + dr.Cells["Student No"].Value + "' And ClassNo ='" + cmbClass.SelectedValue + "' And " +
                                               " SectionCode='" + cmbSection.SelectedValue + "' And  SubjectNo='" + sec[0].ToString() + "' And SessionCode='" + school.CurrentSessionCode + "' " +
                                               " ", Connection.MyConnection, trn);
                                            }

                                        }
                                    }
                                    trn.Commit();
                                }
                                else
                                {
                                    trn = Connection.GetMyConnection().BeginTransaction();
                                    foreach (DataGridViewColumn dc in dtg.Columns)
                                    {
                                        if (dc.Index > 2 && !dc.Name.Contains("Grade"))
                                        {
                                            string[] sec = dc.Name.Split('_');
                                            Connection.SqlTransection("Update tbl_MSCCEStudentMarks Set " + sec[1].ToString() + "='" + dr.Cells[dc.Name].Value + "' " +
                                                " Where  StudentNo='" + dr.Cells["Student No"].Value + "' And ClassNo ='" + cmbClass.SelectedValue + "' And " +
                                                " SectionCode='" + cmbSection.SelectedValue + "' And  SubjectNo='" + sec[0].ToString() + "' And SessionCode='" + school.CurrentSessionCode + "' " +
                                                " ", Connection.MyConnection, trn);
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
                MessageBox.Show("Exception message:\n    " + ex.Message);
                trn.Rollback();
            }
        }
        public string GetGrade(int studno, string des, int excd)
        {
            string result = string.Empty;
            DataTable n = Connection.GetDataTable("select Grade from tbl_MSCCEStudentSkills " +
                              " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                              " And SessionCode='" + school.CurrentSessionCode + "' And StudentNo='" + studno + "' And Description='" + des + "' And ExamCode='" + excd + "'");
            if (n.Rows.Count > 0)
            {
                result = n.Rows[0]["Grade"].ToString();
            }
            else
            {
                result = string.Empty;
            }
            return result;
        }
        public string GetGradeToPrimary(int studno, string des, int excd)
        {
            string result = string.Empty;
            string[] colnm = des.Split('_');
            DataTable n = Connection.GetDataTable("select Grade from tbl_MSCCEStudentSkills " +
                              " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                              " And SessionCode='" + school.CurrentSessionCode + "' And StudentNo='" + studno + "' And SkillId='" + colnm[0].ToString() + "' And ExamCode='" + excd + "'");
            if (n.Rows.Count > 0)
            {
                result = n.Rows[0]["Grade"].ToString();
            }
            else
            {
                result = "0";
            }
            return result;
        }
        public Boolean GetStatus(int studno, string des, int excd)
        {
            Boolean result = false;
            DataTable n = Connection.GetDataTable("select Status from tbl_MSCCEStudentSkills " +
                              " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                              " And SessionCode='" + school.CurrentSessionCode + "' And StudentNo='" + studno + "' And Description='" + des + "' And ExamCode='" + excd + "' ");
            if (n.Rows.Count > 0)
            {
                result = Convert.ToBoolean(n.Rows[0]["Status"]);
            }
            else
            {
                result = false;
            }
            return result;
        }

        private void btnViewDesInd_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                    this.NonPrimaryFlage = Convert.ToBoolean(Connection.GetExecuteScalar("Select NonPrimary From tbl_ClassMaster Where ClassCode = '" + cmbClass.SelectedValue + "'"));
                   
                        DataTable dtStudent = new DataTable("dtStudent");
                        dtgSkills.DataSource = null;
                        dtStudent.Columns.Add("Student No", typeof(int));
                        dtStudent.Columns.Add("Scholar No", typeof(string));
                        dtStudent.Columns.Add("Name", typeof(string));

                        dataReader = Connection.GetDataReader("SELECT tbl_CCEClassSkill.SkillId, tbl_CCESkills.SkillName  " +
                          " FROM tbl_CCEClassSkill INNER JOIN tbl_CCESkills ON tbl_CCEClassSkill.SkillId = tbl_CCESkills.SkillId " +
                          " WHERE (tbl_CCEClassSkill.ClassCode = '" + cmbClass.SelectedValue + "') AND (tbl_CCEClassSkill.SessionCode = '" + school.CurrentSessionCode + "')  " +
                          " ORDER BY tbl_CCEClassSkill.SkillOrder");
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                //dtStudent.Columns.Add("CheckBox" + dataReader["SkillId"].ToString(), typeof(bool));
                                //dtStudent.Columns["CheckBox" + dataReader["SkillId"].ToString()].DefaultValue = false;
                                //dt.Columns.Add(dataReader["SkillName"].ToString(), typeof(string));
                                //dtStudent.Columns.Add(dataReader["SkillId"].ToString(), typeof(string));
                                dtStudent.Columns.Add(dataReader["SkillId"].ToString(), typeof(decimal));
                                dtStudent.Columns[dataReader["SkillId"].ToString()].DefaultValue = 0;
                                //dtStudent.Columns.Add(dataReader["SkillId"].ToString() + "_SA2", typeof(string));
                                //dtStudent.Columns.Add(dataReader["SkillId"].ToString() + "_SA3", typeof(string));
                                //dt.Columns.Add("ObtainGrade" + dataReader["SkillId"].ToString(), typeof(char));
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
                                    string[] cnm = dtStudent.Columns[c].ColumnName.Split('_'); int excode = 0;
                                    if (cnm.Length > 1)
                                    {
                                        if (cnm[1].ToString().Equals("SA1"))
                                            excode = 0;
                                        if (cnm[1].ToString().Equals("SA2"))
                                            excode = 1;
                                        if (cnm[1].ToString().Equals("SA3"))
                                            excode = 2;
                                    }
                                    row[dtStudent.Columns[c].ColumnName.ToString()] = GetGradeToPrimary(Convert.ToInt16(dataReader["StudentNo"]), dtStudent.Columns[c].ColumnName.ToString(), excode);
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
                   
                    dtgSkills.Columns["Scholar No"].Frozen = true;
                    dtgSkills.Columns["Name"].Frozen = true;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Please Select Exam...", "");
                    //    cmbExam.Focus();
                    //}
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

        private void btnSaveDesInd_Click(object sender, EventArgs e)
        {
            if (dtgSkills.RowCount > 0 &&
                DialogResult.Yes.Equals(MessageBox.Show("Are You Sure To Save Descriptive Indicators For Class \"" + cmbClass.Text + " " + cmbSection.Text + "\"?", "Descriptive Indicators", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                dtgSkills.EndEdit();
                SqlTransaction trn = null;
                string cmdText = string.Empty;
                int CCEID = Convert.ToInt32(Connection.GetExecuteScalar(" Select Min(CCEID) From tbl_MSCCEStudentMarks Where ClassNo='" + cmbClass.SelectedValue + "' " +
                    " And SectionCode='" + cmbSection.SelectedValue + "' And SessionCode='" + school.CurrentSessionCode + "'"));

                trn = Connection.GetMyConnection().BeginTransaction();
                try
                {
                    cmdText = " DELETE FROM tbl_MSCCEStudentSkills WHERE ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                        " And SessionCode='" + school.CurrentSessionCode + "' ";
                    Connection.SqlTransection(cmdText, Connection.MyConnection, trn);
                    
                    {
                        foreach (DataGridViewRow r in dtgSkills.Rows)
                        {
                            foreach (DataGridViewColumn c in dtgSkills.Columns)
                            {
                                if (c.Index > 2)
                                {
                                    string[] cnm = c.Name.Split('_'); int excode = 0;
                                    if (cnm.Length > 1)
                                    {
                                        if (cnm[1].ToString().Equals("SA1"))
                                            excode = 0;
                                        if (cnm[1].ToString().Equals("SA2"))
                                            excode = 1;
                                        if (cnm[1].ToString().Equals("SA3"))
                                            excode = 2;
                                    }
                                    cmdText = "INSERT INTO tbl_MSCCEStudentSkills(CCEID,SessionCode,SkillId,Grade,Status,StudentNo,ClassNo,SectionCode,ExamCode)  VALUES " +
                                       "('" + CCEID + "','" + school.CurrentSessionCode + "','" + cnm[0].ToString() + "','" + r.Cells[c.Name].Value + "'," +
                                       " 1,'" + r.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + excode + "')";
                                    Connection.SqlTransection(cmdText, Connection.MyConnection, trn);

                                }
                            }
                            if (!r.Cells["Name"].Value.Equals(DBNull.Value))
                                CCEID++;
                        }
                    }
                    trn.Commit();
                    MessageBox.Show("Descriptive Indicators Saved Successfully Of Class \"" + cmbClass.Text + " " + cmbSection.Text + "\"...", "Descriptive Indicators");
                    //  btnSaveDesInd.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Record Not Saved Please Try Again...");
                    trn.Rollback();
                    btnSaveDesInd.Enabled = false;
                }
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            btnEdit.Enabled = true;
            btnFinalSave.Enabled = false;
            btnShow.Enabled = false;
            btnNew.Focus();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSection, "SELECT tbl_class.sectioncode, tbl_section.sectionname FROM tbl_classmaster INNER JOIN  " +
                    " tbl_class ON tbl_classmaster.classcode = tbl_class.classcode INNER JOIN tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode WHERE (tbl_classmaster.classcode = '" + cmbClass.SelectedValue + "')");

            }
            catch { }
        }

        private void FrmMPCCMarksheetMS_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void tabPage5_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void dtg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dtg.CurrentCell.ColumnIndex;
            columnName = dtg.Columns[columnIndex].Name;
            TextInfo myTextInfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
            if (columnName.Contains("HYE"))
            {
                this.MaximumMarks = 50;

                if (dtg.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                {
                    string st = string.Empty;
                    st = Convert.ToString(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = myTextInfo.ToUpper(st);
                }
                else
                {
                    if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                    {
                        //--
                    }
                    else
                    {
                        MessageBox.Show("Please Fill Valide Marks.");
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }
                }

            }
            else if (columnName.Contains("ANE"))
            {
                this.MaximumMarks = 100;

                if (dtg.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                {
                    string st = string.Empty;
                    st = Convert.ToString(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = myTextInfo.ToUpper(st);
                }
                else
                {
                    if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks )
                    {
                        //---
                    }
                    else
                    {
                        MessageBox.Show("Please Fill Valide Marks.");
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }
                }

            }
            else if (columnName.Contains("YeRes"))
            {
                this.MaximumMarks = 20;

                if (dtg.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                {
                    string st = string.Empty;
                    st = Convert.ToString(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = myTextInfo.ToUpper(st);
                }
                else
                {
                    if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                    {
                        //---
                    }
                    else
                    {
                        MessageBox.Show("Please Fill Valide Marks.");
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }
                }

            }
            else
            {
                this.MaximumMarks = 10;

                if (dtg.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                {
                    string st = string.Empty;
                    st = Convert.ToString(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = myTextInfo.ToUpper(st);
                }
                else
                {
                    if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks )
                    {
                        //---
                    }
                    else
                    {
                        MessageBox.Show("Please Fill Valide Marks.");
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }
                }
            }
        }

        private void dtgSkills_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = dtgSkills.CurrentCell.ColumnIndex;
            columnName = dtgSkills.Columns[columnIndex].Name;
            TextInfo myTextInfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
            
                this.MaximumMarks = 18;

                if (dtgSkills.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                {
                    string st = string.Empty;
                    st = Convert.ToString(dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = myTextInfo.ToUpper(st);
                }
                else
                {
                    if (Convert.ToDecimal(dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                    {
                        //--
                    }
                    else
                    {
                        MessageBox.Show("Please Fill Valide Marks.");
                        dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                    }
                }

            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        
    }
}
