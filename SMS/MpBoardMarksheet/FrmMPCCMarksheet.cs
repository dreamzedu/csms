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
    public partial class FrmMPCCMarksheet : UserControl
    {
        public FrmMPCCMarksheet()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        DataTable dtStudentList = new DataTable("dtStudentList");
        SqlDataReader dataReader = null;
        bool ExamFlage = false;
        bool NonPrimaryFlage = false;
        decimal MaximumMarks;

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSection, "SELECT tbl_class.sectioncode, tbl_section.sectionname FROM tbl_classmaster INNER JOIN  " +
                    " tbl_class ON tbl_classmaster.classcode = tbl_class.classcode INNER JOIN tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode WHERE (tbl_classmaster.classcode = '" + cmbClass.SelectedValue + "')");

            }
            catch { }
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
                                    dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(string));
                                    dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = "";
                                }
                                else
                                {
                                    dtStudentList.Columns.Add(dataReader["subjectno"].ToString(), typeof(decimal));
                                    dtStudentList.Columns[dataReader["subjectno"].ToString()].DefaultValue = 0;
                                }
                            }
                            dataReader.Close();
                        }
                        ///
                        if (btnNew.Enabled.Equals(true))
                        {

                            DataTable n = Connection.GetDataTable("Select Top 1 TERMI ,TERMII ,TERMIII  From tbl_MPCCEStudentMarks " +
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
                                    //for (int i = 0; i < row.Length; i++)
                                    if (row.Length > 0)
                                    {
                                        foreach (DataColumn c in dtStudentList.Columns)
                                        {
                                            if (!c.ColumnName.Contains("Student No") && !c.ColumnName.Contains("Scholar No")
                                                && !c.ColumnName.Contains("Name"))
                                            {
                                                string exm = string.Empty;
                                                if (cmbExam.Text.Trim() == "TERM I")
                                                    exm = "TERMI";
                                                else if (cmbExam.Text.Trim() == "TERM II")
                                                    exm = "TERMII";
                                                else
                                                    exm = "TERMIII";
                                                r[c.ColumnName] = row[i][exm];
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
            if (cmbExam.Text.Contains("TERM"))
            {
                this.MaximumMarks = 100;
                if (dtg.Columns[e.ColumnIndex].ValueType.Name.ToString() == "String")
                {
                    string st = string.Empty;
                    st=Convert.ToString(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = myTextInfo.ToUpper(st);
                }
                else
                {
                    if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                    {
                        if (Convert.ToInt32(cmbClass.SelectedValue) <= 110)
                        {
                            dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Fill Valide Marks.");
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
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
                            int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_MPCCEStudentMarks"));

                            foreach (DataGridViewRow dr in dtg.Rows)
                            {
                                foreach (DataGridViewColumn dc in dtg.Columns)
                                {
                                    if (dc.Index > 2)
                                    {
                                        Connection.SqlTransection("Insert InTo tbl_MPCCEStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, TERMI) Values(" +
                                          "'" + CCEID + "','" + dr.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + dc.Name + "', " +
                                          "'" + school.CurrentSessionCode + "','" + dr.Cells[dc.Name].Value + "')", Connection.MyConnection, trn);
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
                                        if (dc.Index > 2 )
                                        {
                                            Connection.SqlTransection("Insert InTo tbl_MPCCEStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, TERMI) Values(" +
                                              "'" + CCEID + "','" + dr.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + dc.Name + "', " +
                                              "'" + school.CurrentSessionCode + "','" + dr.Cells[dc.Name].Value + "')", Connection.MyConnection, trn);
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
                                        if (dc.Index > 2 )
                                        {
                                            Connection.SqlTransection("Update tbl_MPCCEStudentMarks Set " + EXM + "='" + dr.Cells[dc.Name].Value + "' " +
                                                " Where  StudentNo='" + dr.Cells["Student No"].Value + "' And ClassNo ='" + cmbClass.SelectedValue + "' And " +
                                                " SectionCode='" + cmbSection.SelectedValue + "' And  SubjectNo='" + dc.Name + "' And SessionCode='" + school.CurrentSessionCode + "' " +
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void FrmMPCCMarksheet_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Order By ClassOrder");
            Connection.FillComboBox(cmbSection, "Select SectionCode ,SectionName From tbl_Section");
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

        private void FrmMPCCMarksheet_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

       

        
    }
}

