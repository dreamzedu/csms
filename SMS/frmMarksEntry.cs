using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmMarksEntry :UserControlBase
    {
        DataTable dtStudentList = new DataTable("dtStudentList");
        DataTable dtFinallMarksOfStudentList = new DataTable("dtFinallMarksOfStudentList");
        SqlDataReader dataReader = null;
        decimal MaximumMarks = 100;
        bool ExamFlage = false;
        public frmMarksEntry()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmMarksEntry_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Group by  ClassCode,ClassName Order By ClassCode");
            Connection.FillComboBox(cmbSection, "Select SectionCode ,SectionName From tbl_Section");
            Connection.FillComboBox(cmbExam , "Select ExamCode ,ExamName From tbl_ExamHead Where SessionCode='"+school .CurrentSessionCode +"'  Order By ExamOrder ");
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                   // if (!string.IsNullOrEmpty(cmbExam.Text))
                    {
                        //Data Table Here Starting
                        dtg.DataSource = null;
                        dtStudentList.Rows.Clear(); dtStudentList.Columns.Clear();
                        dtStudentList.Columns.Add("Student No", typeof(int));
                        dtStudentList.Columns.Add("Scholar No", typeof(string));
                        dtStudentList.Columns.Add("Name", typeof(string));
                        dataReader = Connection.GetDataReader("SELECT tbl_subject.subjectno, tbl_subject.subjectname " +
                            " FROM tbl_subwiseclass INNER JOIN tbl_subject ON tbl_subwiseclass.subjectno = tbl_subject.subjectno " +
                            " WHERE (tbl_subwiseclass.classno = '" + cmbClass.SelectedValue + "') ORDER BY tbl_subject.SubjectOrder");
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(decimal));
                                dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = 0;
                                dtStudentList.Columns.Add("Grade" + dataReader["subjectno"].ToString(), typeof(string));
                                dtStudentList.Columns["Grade" + dataReader["subjectno"].ToString()].DefaultValue = "E";
                            }
                            dataReader.Close();
                        }

                        if (btnNew.Enabled.Equals(true))
                        {
                            if (dtStudentList.Columns.Count > 0)
                            {
                                dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                                    " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                                    " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') ORDER BY tbl_student.name ");
                                if (dataReader.HasRows)
                                {
                                    while (dataReader.Read())
                                    {
                                        dtStudentList.Rows.Add(
                                            dataReader["StudentNo"], dataReader["Scholar No."], dataReader["Name"]);
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
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') ORDER BY tbl_student.name");

                                DataTable dtStudtntExamMarks = Connection.GetDataTable("[dbo].[GetViewCCEMarksDetail] " + cmbClass.SelectedValue + "," + cmbSection.SelectedValue + "," + school.CurrentSessionCode + "");
                                if (dataReader.HasRows)
                                {
                                    while (dataReader.Read())
                                    {
                                        dtStudentList.Rows.Add(
                                            dataReader["StudentNo"], dataReader["Scholar No."], dataReader["Name"]);
                                    }
                                    dataReader.Close();
                                }
                                foreach (DataRow r in dtStudentList.Rows)
                                { 
                                    DataRow[] row = dtStudtntExamMarks.Select("StudentNo='" + r["Student No"] + "'");
                                    for (int i = 0; i < row.Length; i++)
                                    {
                                        foreach (DataColumn c in dtStudentList.Columns)
                                        {
                                            if (!c.ColumnName.Contains("Student No") && !c.ColumnName.Contains("Scholar No")
                                                && !c.ColumnName.Contains("Name") && !c.ColumnName.Contains("Grade"))
                                            {
                                                r[c.ColumnName] = row[i][cmbExam.Text.Trim()];
                                                r["Grade" + c.ColumnName] = row[i][cmbExam.Text.Trim() + " G"];
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

        private void dtg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {  
            if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
            {
                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) / this.MaximumMarks * 10);
                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGrade(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value) * 10);
            }
            else
            {
                MessageBox.Show("Please Fill Valide Marks.");
                dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
            }
        }
        private string GetGrade(decimal ObtainMarks)
        {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 90 && ObtainMarks <= 100)
                Grade = "A++";
            else if (ObtainMarks >= 80 && ObtainMarks <= 89)
                Grade = "A+";
            else if (ObtainMarks >= 75 && ObtainMarks <= 79)
                Grade = "A";
            else if (ObtainMarks >= 70 && ObtainMarks <= 74)
                Grade = "B++";
            else if (ObtainMarks >= 65 && ObtainMarks <= 69)
                Grade = "B+";
            else if (ObtainMarks >= 60 && ObtainMarks <= 64)
                Grade = "B";
            else if (ObtainMarks >= 55 && ObtainMarks <= 59)
                Grade = "C++";
            else if (ObtainMarks >= 50 && ObtainMarks <= 54)
                Grade = "C+";
            else if (ObtainMarks >= 45 && ObtainMarks <= 49)
                Grade = "C";
            else if (ObtainMarks >= 33 && ObtainMarks <= 44)
                Grade = "D";
            else if (ObtainMarks < 33)
                Grade = "E";
            return Grade;
        }
    }
}
