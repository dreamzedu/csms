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
    public partial class FrmMPCCMarksheetS : UserControlBase
    {
        public FrmMPCCMarksheetS()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        DataTable dtStudentList = new DataTable("dtStudentList");
        SqlDataReader dataReader = null;
        bool ExamFlage = false;
        bool NonPrimaryFlage = false;
        decimal MaximumMarks;
        school1 c = new school1();

        private void FrmMPCCMarksheetS_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Order By ClassOrder");
            Connection.FillComboBox(cmbSection, "Select SectionCode ,SectionName From tbl_Section");

            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            c.GetMdiParent(this).ToggleNewButton(true);
            c.GetMdiParent(this).ToggleEditButton(true);
            ToggleAllControls(false);
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSection, "SELECT tbl_class.sectioncode, tbl_section.sectionname FROM tbl_classmaster INNER JOIN  " +
                    " tbl_class ON tbl_classmaster.classcode = tbl_class.classcode INNER JOIN tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode WHERE (tbl_classmaster.classcode = '" + cmbClass.SelectedValue + "')");

            }
            catch(Exception ex){Logger.LogError(ex); }
        }
        private string GetGrade50(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 38 && ObtainMarks <= 50)
                Grade = "A";
            else if (ObtainMarks >= 30 && ObtainMarks <= 37)
                Grade = "B";
            else if (ObtainMarks >= 22 && ObtainMarks <= 29)
                Grade = "C";
            else if (ObtainMarks >= 17 && ObtainMarks <= 24)
                Grade = "D";
            else if (ObtainMarks >= 0 && ObtainMarks <= 16)
                Grade = "E";
            return Grade;
        }
       
        private string GetGrade100(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 75 && ObtainMarks <= 100)
                Grade = "A";
            else if (ObtainMarks >= 60 && ObtainMarks <= 74)
                Grade = "B";
            else if (ObtainMarks >= 45 && ObtainMarks <= 59)
                Grade = "C";
            else if (ObtainMarks >= 33 && ObtainMarks <= 44)
                Grade = "D";
            else if (ObtainMarks >= 0 && ObtainMarks <= 32)
                Grade = "E";
            return Grade;
        }
        private string GetGrade37(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 28 && ObtainMarks <= 37)
                Grade = "A";
            else if (ObtainMarks >= 23 && ObtainMarks <= 27)
                Grade = "B";
            else if (ObtainMarks >= 17 && ObtainMarks <= 22)
                Grade = "C";
            else if (ObtainMarks >= 12 && ObtainMarks <= 16)
                Grade = "D";
            else if (ObtainMarks >= 0 && ObtainMarks <= 11)
                Grade = "E";
            return Grade;
        }
        private string GetGrade75(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 57 && ObtainMarks <= 75)
                Grade = "A";
            else if (ObtainMarks >= 45 && ObtainMarks <= 56)
                Grade = "B";
            else if (ObtainMarks >= 34 && ObtainMarks <= 44)
                Grade = "C";
            else if (ObtainMarks >= 25 && ObtainMarks <= 33)
                Grade = "D";
            else if (ObtainMarks >= 0 && ObtainMarks <= 24)
                Grade = "E";
            return Grade;
        }
        private string GetGrade13(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 11 && ObtainMarks <= 13)
                Grade = "A";
            else if (ObtainMarks >= 9 && ObtainMarks <= 10)
                Grade = "B";
            else if (ObtainMarks >= 7 && ObtainMarks <= 8)
                Grade = "C";
            else if (ObtainMarks >= 4 && ObtainMarks <= 6)
                Grade = "D";
            else if (ObtainMarks >= 0 && ObtainMarks <= 3)
                Grade = "E";
            return Grade;
        }
        private string GetGrade25(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 20 && ObtainMarks <= 25)
                Grade = "A";
            else if (ObtainMarks >= 16 && ObtainMarks <= 19)
                Grade = "B";
            else if (ObtainMarks >= 12 && ObtainMarks <= 15)
                Grade = "C";
            else if (ObtainMarks >= 8 && ObtainMarks <= 11)
                Grade = "D";
            else if (ObtainMarks >= 0 && ObtainMarks <= 7)
                Grade = "E";
            return Grade;
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                    if (!string.IsNullOrEmpty(cmbExam.Text))
                    {
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
                                    dtStudentList.Columns.Add( dataReader["subjectno"].ToString(), typeof(string));
                                    dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = "E";
                                }
                                else
                                {
                                    dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(decimal));
                                    dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = 0;
                                    dtStudentList.Columns.Add("Grade" + dataReader["subjectno"].ToString(), typeof(string));
                                    dtStudentList.Columns["Grade" + dataReader["subjectno"].ToString()].DefaultValue = "E";
                                   
                                }
                               
                            }
                            dataReader.Close();
                        }
                        ///
                        if (c.GetMdiParent(this).IsNewCommandEnabled)
                        {

                            DataTable n = Connection.GetDataTable("Select Top 1 TERMI ,TERMII ,TERMIII  From tbl_MPCCEStudentMarks " +
                                " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                                " And SessionCode='" + school.CurrentSessionCode + "'   ");
                            if (n.Rows.Count > 0)
                            {
                                if (cmbClass.Text.Equals("IX") || cmbClass.Text.Equals("XI"))
                                {
                                    if ("TERM I".Equals(cmbExam.Text.Trim()))
                                    {
                                        MessageBox.Show("Record already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else
                                    {
                                       
                                        return;
                                    }
                                }
                                else
                                {

                                }
                                if ("TERM I".Equals(cmbExam.Text.Trim()))
                                {
                                    MessageBox.Show("Record already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else if ("TERM II".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["TERMI"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please enter record for TERM I", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["TERMII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Record already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("TERM III".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["TERMI"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please enter record for TERM II", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["TERMII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please enter record for TERM II!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["TERMIII"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Record already exist!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
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
                                lblStatus.Text = "You have selected " + cmbExam.Text;
                                chkLock.Checked = true;
                                tmr1.Enabled = true;
                            }
                        }
                        else if (c.GetMdiParent(this).IsEditCommandEnabled)
                        {
                            if (dtStudentList.Columns.Count > 0)
                            {
                                dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                                    " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                                    " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' ORDER BY tbl_student.name");

                                DataTable dtStudtntExamMarks = Connection.GetDataTable("[dbo].[GetViewMPCCEMarksDetail] " + cmbClass.SelectedValue + "," + cmbSection.SelectedValue + "," + school.CurrentSessionCode + "");
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
                                    
                                    if (row.Length > 0)
                                    {
                                        //for (int i = 0; i < row.Length; i++)
                                        {
                                            foreach (DataColumn dc in dtStudentList.Columns)
                                            {
                                                if (!dc.ColumnName.Contains("Student No") && !dc.ColumnName.Contains("Scholar No")
                                                    && !dc.ColumnName.Contains("Name") && !dc.ColumnName.Contains("Grade"))
                                                {
                                                    string exm = string.Empty;
                                                    if (cmbExam.Text.Trim() == "TERM I")
                                                        exm = "TERMI";
                                                    else if (cmbExam.Text.Trim() == "TERM II")
                                                        exm = "TERMII";
                                                    else
                                                        exm = "TERMIII";
                                                    
                                                    decimal tval = 0;
                                                    if (row[i][exm].Equals(DBNull.Value) || string.IsNullOrEmpty(row[i][exm].ToString()))
                                                        tval = 0;
                                                    else
                                                    {
                                                        if (decimal.TryParse(row[i][exm].ToString(), out tval))
                                                        {
                                                            //tval = Convert.ToDecimal(row[i][exm]);
                                                            r[dc.ColumnName] = tval;
                                                            if (exm == "TERMI")
                                                                r["Grade" + dc.ColumnName] = this.GetGrade50(tval);
                                                            else
                                                                r["Grade" + dc.ColumnName] = this.GetGrade100(tval);
                                                        }
                                                        else
                                                        {
                                                            r[dc.ColumnName] = row[i][exm].ToString();
                                                        }

                                                        
                                                    }
                                                    

                                                    dtStudentList.EndInit();
                                                    i++;
                                                }
                                            }
                                        }
                                    }
                                }
                                dtg.DataSource = dtStudentList;
                                lblStatus.Text = "You have selected " + cmbExam.Text;
                                chkLock.Checked = true;
                                tmr1.Enabled = true;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select Exam.", "Error");
                        cmbExam.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please select Section first!", "Error");
                    cmbSection.Focus();
                }
            }
            else
            {
                MessageBox.Show("Please select Class first!", "Error");
                cmbClass.Focus();
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

        private void dtg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
                    {
            TextInfo myTextInfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
            string str = string.Empty;
            if (cmbExam.Text.Equals("TERM I"))
            {
                this.MaximumMarks = 50;
                if (dtg.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                {
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                }
                else
                {
                        str = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText.ToString().Trim();
                        if (Convert.ToInt16(cmbClass.SelectedValue.ToString()) == 109)
                        {
                            this.MaximumMarks = 100;
                            if (str.Equals("SCIENCE") && cmbClass.Text.Equals("IX") )
                            {
                                if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= 75)
                                {
                                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade75(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                                }
                                else
                                {
                                    MessageBox.Show("Please enter valid marks.");
                                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade75(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                                }

                            }
                            else if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                            {




                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade100(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));

                            }
                            else
                            {
                                MessageBox.Show("Please enter valid marks.");
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade100(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                            }
                        }
                        else if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                        {




                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade50(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));

                        }
                        else
                        {
                            MessageBox.Show("Please enter valid marks.");
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade50(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                        }
                }

            }
            else if (cmbExam.Text.Equals("TERM II"))
            {
                this.MaximumMarks = 50;
                if (dtg.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                {
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                }
                else
                {
                    if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                    {

                        str = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText.ToString().Trim();
                        if (str.Equals("SCIENCE") && cmbClass.Text.Equals("IX"))
                        {
                            if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= 75)
                            {
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade75(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                            }
                            else
                            {
                                MessageBox.Show("Please enter valid marks.");
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade75(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                            }
                        }
                        else
                        {
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade100(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter valid marks.");
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade100(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                    }
                }
            }
            else
            {
                this.MaximumMarks = 100;
                if (dtg.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                {
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                }
                else
                {
                    if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                    {

                        str = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText.ToString().Trim();
                        if (str.Equals("SCIENCE") && cmbClass.Text.Equals("IX"))
                        {
                            if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= 75)
                            {
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade75(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                            }
                            else
                            {
                                MessageBox.Show("Please enter valid marks.");
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade75(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                            }
                        }
                        else
                        {
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade100(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please enter valid marks.");
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade100(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                    }
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

        public override void btnnew_Click(object sender, EventArgs e)
        {
            c.GetMdiParent(this).ToggleEditButton(false);
            c.GetMdiParent(this).ToggleSaveButton(true);
            c.GetMdiParent(this).ToggleCancelButton(true);
            c.GetMdiParent(this).ToggleDeleteButton(false);
            ToggleAllControls(true);
            cmbClass.Focus();

        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            c.GetMdiParent(this).ToggleNewButton(false);
            c.GetMdiParent(this).ToggleSaveButton(true);
            c.GetMdiParent(this).ToggleCancelButton(true);
            ToggleAllControls(true);

            cmbClass.Focus();
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            c.GetMdiParent(this).ToggleNewButton(true);
            c.GetMdiParent(this).ToggleEditButton(true);
            c.GetMdiParent(this).ToggleSaveButton(false);
            c.GetMdiParent(this).ToggleCancelButton(false);

            ToggleAllControls(false);
            tmr1.Stop();
            dtg.DataSource = null;
            lblStatus.Text = string.Empty;
        }

        private void ToggleAllControls(bool flag)
        {
            cmbClass.Enabled = flag;
            cmbSection.Enabled = flag;
            cmbExam.Enabled = flag;
            btnShow.Enabled = flag;
        }

        public override void btnsave_Click(object sender, EventArgs e)
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
                        if (cmbExam.Text.Trim().Equals("TERM I") && c.GetMdiParent(this).IsNewCommandEnabled)
                        {
                            trn = Connection.GetMyConnection().BeginTransaction();
                            int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_MPCCEStudentMarks"));

                            foreach (DataGridViewRow dr in dtg.Rows)
                            {
                                foreach (DataGridViewColumn dc in dtg.Columns)
                                {
                                    if (dc.Index > 2)
                                    {
                                        if (!dc.Name.Contains("Grade"))
                                        {
                                            Connection.SqlTransection("Insert InTo tbl_MPCCEStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, TERMI) Values(" +
                                              "'" + CCEID + "','" + dr.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + dc.Name + "', " +
                                              "'" + school.CurrentSessionCode + "','" + dr.Cells[dc.Name].Value + "')", Connection.MyConnection, trn);
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
                                int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_MPCCEStudentMarks"));
                                int CCECcount = Convert.ToInt32(Connection.GetId("select ISNULL(COUNT(StudentNo),0) From tbl_MPCCEStudentMarks where StudentNo='" + dr.Cells["Student No"].Value + "' and ClassNo='" + cmbClass.SelectedValue + "' and SessionCode='" + school.CurrentSessionCode + "'"));
                                if (CCECcount < 1)
                                {
                                    trn = Connection.GetMyConnection().BeginTransaction();
                                    foreach (DataGridViewColumn dc in dtg.Columns)
                                    {
                                        if (dc.Index > 2)
                                        {
                                            if (!dc.Name.Contains("Grade"))
                                            {
                                                Connection.SqlTransection("Insert InTo tbl_MPCCEStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, TERMI) Values(" +
                                                  "'" + CCEID + "','" + dr.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + dc.Name + "', " +
                                                  "'" + school.CurrentSessionCode + "','" + dr.Cells[dc.Name].Value + "')", Connection.MyConnection, trn);
                                            }
                                        }
                                    }
                                    trn.Commit();
                                }
                                else
                                {
                                    trn = Connection.GetMyConnection().BeginTransaction();
                                    string EXM = string.Empty;
                                    if (cmbExam.Text.Trim() == "TERM II")
                                        EXM = "TERMII";
                                    else if (cmbExam.Text.Trim() == "TERM III")
                                        EXM = "TERMIII";
                                    else
                                        EXM = "TERMI";

                                    foreach (DataGridViewColumn dc in dtg.Columns)
                                    {
                                        if (dc.Index > 2)
                                        {

                                            if (!dc.Name.Contains("Grade"))
                                            {
                                                Connection.SqlTransection("Update tbl_MPCCEStudentMarks Set " + EXM + "='" + dr.Cells[dc.Name].Value + "' " +
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

                        MessageBox.Show("Record saved successfully.");

                        c.GetMdiParent(this).ToggleNewButton(true);
                        c.GetMdiParent(this).ToggleEditButton(true);
                        c.GetMdiParent(this).ToggleSaveButton(false);
                        c.GetMdiParent(this).ToggleCancelButton(false);

                        ToggleAllControls(false);
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

        private void tmr1_Tick(object sender, EventArgs e)
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            lblStatus.ForeColor = Color.FromKnownColor(randomColorName);
            chkLock.ForeColor = (chkLock.Checked) ? Color.FromKnownColor(randomColorName) : Color.White;
        }

        private void FrmMPCCMarksheetS_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
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
            DataTable n = Connection.GetDataTable("select Grade from tbl_MPCCEStudentSkills " +
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
                        if (cmbClass.Text.Equals("IX")||cmbClass.Text.Equals("XI"))
                        {
                            if (cmbExam.Text.Equals("TERM III")||cmbExam.Text.Equals("TERM II"))
                            {
                                MessageBox.Show("Please Select Exam carefully...");
                                cmbExam.Focus();
                                return;
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
                                   
                                    if (cmbExam.Text.Equals("TERM I"))
                                    {

                                          dtStudent.Columns.Add(dataReader["SkillId"].ToString(), typeof(int));
                                          dtStudent.Columns[dataReader["SkillId"].ToString()].DefaultValue = "0";
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
                                        
                                        if (!dtStudent.Columns[c].ColumnName.ToString().Contains("Grade"))
                                        {
                                            if (dtStudent.Columns[c].DataType.Name.ToString().Equals("Int32"))
                                            {
                                                row[dtStudent.Columns[c].ColumnName.ToString()] = GetGradeToPrimary(Convert.ToInt16(dataReader["StudentNo"]), dtStudent.Columns[c].ColumnName.ToString(), 1);
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

        private void dtgSkills_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.MaximumMarks = 25;
            if (Convert.ToDecimal(dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
            {
                dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }
            else
            {
                MessageBox.Show("Please Fill Valide Marks.");
                dtgSkills.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
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
                int CCEID = Convert.ToInt32(Connection.GetExecuteScalar(" Select Min(CCEID) From tbl_MPCCEStudentMarks Where ClassNo='" + cmbClass.SelectedValue + "' " +
                    " And SectionCode='" + cmbSection.SelectedValue + "' And SessionCode='" + school.CurrentSessionCode + "'"));

                trn = Connection.GetMyConnection().BeginTransaction();
                try
                {
                    cmdText = " DELETE FROM tbl_MPCCEStudentSkills WHERE ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
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
                                    cmdText = "INSERT INTO tbl_MPCCEStudentSkills(CCEID,SessionCode,SkillId,Grade,Status,StudentNo,ClassNo,SectionCode,ExamCode)  VALUES " +
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

    }
}
