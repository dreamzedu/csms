using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
namespace SMS
{
    public partial class frmNewCBSCMarksheet :UserControlBase
    {
        DataTable dtStudentList = new DataTable("dtStudentList");
        DataTable dtFinallMarksOfStudentList = new DataTable("dtFinallMarksOfStudentList");
        SqlDataReader dataReader = null;
        bool ExamFlage = false;
        bool NonPrimaryFlage = false;
        decimal MaximumMarks;
        school1 c = new school1();

        public frmNewCBSCMarksheet()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmNewCBSCMarksheet_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Order By ClassOrder");
            Connection.FillComboBox(cmbSection, "Select SectionCode ,SectionName From tbl_Section");
            c.GetMdiParent(this).EnableAllEditMenuButtons();
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
                                dtStudentList.Columns["Grade" + dataReader["subjectno"].ToString()].DefaultValue = "E2";
                            }
                            dataReader.Close();
                        }
                        ///
                        if (c.GetMdiParent(this).IsNewCommandEnabled)
                        {

                            DataTable n = Connection.GetDataTable("Select Top 1 FA1 ,FA2 ,SA1 ,FA3 ,FA4 ,SA2  From tbl_CCEStudentMarks " +
                                " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                                " And SessionCode='" + school.CurrentSessionCode + "'   ");
                            if (n.Rows.Count > 0)
                            {
                                if ("FA1".Equals(cmbExam.Text.Trim()))
                                {
                                    MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                else if ("FA2".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["FA1"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["FA2"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("SA1".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["FA1"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["FA2"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA2!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["SA1"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("FA3".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["FA1"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["FA2"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA2!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["SA1"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of SA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["FA3"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("FA4".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["FA1"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["FA2"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA2!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["SA1"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of SA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["FA3"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA3!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["FA4"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Already Exist!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else if ("SA2".Equals(cmbExam.Text.Trim()))
                                {
                                    if (n.Rows[0]["FA1"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["FA2"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA2!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["SA1"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of SA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["FA3"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA3!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (n.Rows[0]["FA4"].Equals(DBNull.Value))
                                    {
                                        MessageBox.Show("Please Fill Record Of FA4!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                    else if (!n.Rows[0]["SA2"].Equals(DBNull.Value))
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
                        else if (c.GetMdiParent(this).IsEditCommandEnabled)
                        {
                            if (dtStudentList.Columns.Count > 0)
                            {
                                dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                                    " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                                    " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                                    " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' ORDER BY tbl_student.name");

                                DataTable dtStudtntExamMarks = Connection.GetDataTable("[dbo].[GetViewCCEMarksDetail] " + cmbClass.SelectedValue + "," + cmbSection.SelectedValue + "," + school.CurrentSessionCode + "");
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
                                        foreach (DataColumn col in dtStudentList.Columns)
                                        {
                                            if (!col.ColumnName.Contains("Student No") && !col.ColumnName.Contains("Scholar No")
                                                && !col.ColumnName.Contains("Name") && !col.ColumnName.Contains("Grade"))
                                            {
                                                r[col.ColumnName] = row[i][cmbExam.Text.Trim()];
                                                r["Grade" + col.ColumnName] = row[i][cmbExam.Text.Trim() + " G"];
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

        private string GetGradeNonPrimary(decimal ObtainMarks)
            {
            string Grade = string.Empty;
            ObtainMarks = decimal.Round(ObtainMarks, MidpointRounding.AwayFromZero);
            if (ObtainMarks >= 91 && ObtainMarks <= 100)
                Grade = "A1";
            else if (ObtainMarks >= 81 && ObtainMarks <= 90)
                Grade = "A1";
            else if (ObtainMarks >= 71 && ObtainMarks <= 80)
                Grade = "A2";
            else if (ObtainMarks >= 61 && ObtainMarks <= 70)
                Grade = "B1";
            else if (ObtainMarks >= 51 && ObtainMarks <= 60)
                Grade = "B2";
            else if (ObtainMarks >= 41 && ObtainMarks <= 50)
                Grade = "C1";
            else if (ObtainMarks >= 33 && ObtainMarks <= 40)
                Grade = "C2";
            else if (ObtainMarks >= 21 && ObtainMarks <= 32)
                Grade = "D";
            else if (ObtainMarks >= 0 && ObtainMarks <= 20)
                Grade = "E1";
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

        private void dtg_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
            if (cmbExam.Text.Contains("FA"))
            {
                if (Convert.ToInt32(cmbClass.SelectedValue) <= 112)
                {
                this.MaximumMarks = 25;

                if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                {
                    
                    
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) / this.MaximumMarks * 10);
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGradeNonPrimary(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value) * 10);
                }
            
                 else
                {
                    MessageBox.Show("Please Fill Valide Marks.");
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
               }
                    else
                    {
                        this.MaximumMarks = 100;
                    if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks)
                    {

                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) / this.MaximumMarks * 10);
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGradeNonPrimary(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value) * 10);
                    }
                 else
                  {
                    MessageBox.Show("Please Fill Valide Marks.");
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                  }
               
                }
                
            }
    
            else if (cmbExam.Text.Contains("SA"))
            {
                this.MaximumMarks = 100;

                if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks && Convert.ToInt32(cmbClass.SelectedValue) <= 116)
                {
                    
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                       // dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGradeNonPrimary(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) / this.MaximumMarks * 10);
                        dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGradeNonPrimary(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value) * 10);
                    
                }
                else if (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) <= this.MaximumMarks && Convert.ToInt32(cmbClass.SelectedValue) > 116)
                {
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    // dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGradeNonPrimary(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = (Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) / this.MaximumMarks * 10);
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = this.GetGradeNonPrimary(Convert.ToDecimal(dtg.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value) * 10);
                }
                else
                {
                    MessageBox.Show("Please Fill Valide Marks.");
                    dtg.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                }
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
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
            lblStatus.ForeColor = System.Drawing.Color.FromKnownColor(randomColorName);
            chkLock.ForeColor = (chkLock.Checked) ? System.Drawing.Color.FromKnownColor(randomColorName) : System.Drawing.Color.White;
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
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), dtg.Font, new SolidBrush(System.Drawing.Color.Maroon), e.RowBounds.X + 2, e.RowBounds.Y + 3);
        }


        private void dtgSkills_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            foreach (DataGridViewRow r in dtgSkills.Rows)
            {
                if (r.Cells["Name"].Value != DBNull.Value &&
                     r.Cells["Scholar No"].Value != DBNull.Value)
                {
                    r.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
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
                    if (c.Name.Contains("CheckBox") || c.Name.Contains("ObtainGrade"))
                    {
                        c.Width = 20;
                        c.HeaderText = "";
                        if (c.Name.Contains("ObtainGrade"))
                        {
                            c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            c.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                            c.DefaultCellStyle.ForeColor = System.Drawing.Color.Navy;
                        }

                        c.ReadOnly = false;
                    }
                    if (!c.Name.Contains("CheckBox") && !c.Name.Contains("ObtainGrade"))
                    {
                        c.HeaderText = Convert.ToString(Connection.GetExecuteScalar("Select SkillName From tbl_CCESkills Where SkillId='" + c.Name + "'"));
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
                        if (cmbExam.Text.Trim().Equals("FA1") && c.GetMdiParent(this).IsNewCommandEnabled)
                        {
                            trn = Connection.GetMyConnection().BeginTransaction();
                            int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_CCEStudentMarks"));

                            foreach (DataGridViewRow dr in dtg.Rows)
                            {
                                foreach (DataGridViewColumn dc in dtg.Columns)
                                {
                                    if (dc.Index > 2 && !dc.Name.Contains("Grade"))
                                    {
                                        Connection.SqlTransection("Insert InTo tbl_CCEStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, FA1) Values(" +
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
                                int CCEID = Convert.ToInt32(Connection.GetId("Select IsNull((Max(CCEID)+1),1001) From tbl_CCEStudentMarks"));
                                int CCECcount = Convert.ToInt32(Connection.GetId("select ISNULL(COUNT(StudentNo),0) From tbl_CCEStudentMarks where StudentNo='" + dr.Cells["Student No"].Value + "' and ClassNo='" + cmbClass.SelectedValue + "' and SessionCode='" + school.CurrentSessionCode + "'"));
                                if (CCECcount < 1)
                                {
                                    trn = Connection.GetMyConnection().BeginTransaction();
                                    foreach (DataGridViewColumn dc in dtg.Columns)
                                    {
                                        if (dc.Index > 2 && !dc.Name.Contains("Grade"))
                                        {
                                            Connection.SqlTransection("Insert InTo tbl_CCEStudentMarks(CCEID, StudentNo, ClassNo,SectionCode, SubjectNo,SessionCode, FA1) Values(" +
                                              "'" + CCEID + "','" + dr.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + dc.Name + "', " +
                                              "'" + school.CurrentSessionCode + "','" + dr.Cells[dc.Name].Value + "')", Connection.MyConnection, trn);
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
                                            Connection.SqlTransection("Update tbl_CCEStudentMarks Set " + cmbExam.Text.Trim() + "='" + dr.Cells[dc.Name].Value + "' " +
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
                        c.GetMdiParent(this).ToggleNewButton(true); 
                       c.GetMdiParent(this).ToggleEditButton(true);
                       c.GetMdiParent(this).ToggleSaveButton(false);
                        btnShow.Enabled = false;
                        
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Exception message:\n    "+ex.Message);
                trn.Rollback();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()) && !txtSearch.Text.Equals("Search By Student Name"))
            {
                foreach (ListViewGroup g in listView1.Groups)
                {
                    string s1 = g.ToString().ToUpperInvariant();
                    string s2 = txtSearch.Text.Trim().ToUpperInvariant();
                    //if (g.ToString().ToUpperInvariant ().Contains(txtSearch.Text.Trim().ToUpperInvariant ()))
                    if (s1.Contains(s2))
                    {
                        g.ListView.Select();
                    }
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = "Search By Student Name";
        }

        private void btnShowFinalMarks_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                    dtFinallMarksOfStudentList.Rows.Clear();
                    dtFinallMarksOfStudentList.Columns.Clear();

                    dtFinallMarksOfStudentList.Columns.Add("Student No", typeof(int));
                    dtFinallMarksOfStudentList.Columns.Add("Scholar No", typeof(string));
                    dtFinallMarksOfStudentList.Columns.Add("Name", typeof(string));

                    dtFinallMarksOfStudentList.Columns.Add("Subject No", typeof(int));
                    dtFinallMarksOfStudentList.Columns.Add("Subject Code/Name", typeof(string));

                    dtFinallMarksOfStudentList.Columns.Add("FA1", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("FA1-10%", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("FA1 G", typeof(string));
                    dtFinallMarksOfStudentList.Columns.Add("FA2", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("FA2-10%", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("FA2 G", typeof(string));
                    dtFinallMarksOfStudentList.Columns.Add("FA1FA2-20%", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("SA1", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("SA1-30%", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("SA1 G", typeof(string));
                    dtFinallMarksOfStudentList.Columns.Add("FA1FA2SA1", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("Tot-1-G", typeof(string));

                    dtFinallMarksOfStudentList.Columns.Add("FA3", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("FA3-10%", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("FA3 G", typeof(string));
                    dtFinallMarksOfStudentList.Columns.Add("FA4", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("FA4-10%", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("FA4 G", typeof(string));
                    dtFinallMarksOfStudentList.Columns.Add("FA3FA4-20%", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("SA2", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("SA2-30%", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("SA2 G", typeof(string));
                    dtFinallMarksOfStudentList.Columns.Add("FA3FA4SA2", typeof(decimal));
                    dtFinallMarksOfStudentList.Columns.Add("Tot-2-G", typeof(string));

                    dtFinallMarksOfStudentList.Columns.Add("FA1FA2FA3FA4 G", typeof(string));  // dtFinallMarksOfStudentList.Columns["FA1FA2FA3FA4 G"].DefaultValue = "E2";
                    dtFinallMarksOfStudentList.Columns.Add("SA1SA2 G", typeof(string));        // dtFinallMarksOfStudentList.Columns["SA1SA2 G"].DefaultValue = "E2";
                    dtFinallMarksOfStudentList.Columns.Add("Finale Grade", typeof(string));    // dtFinallMarksOfStudentList.Columns["Finale Grade"].DefaultValue = "E2";
                    dtFinallMarksOfStudentList.Columns.Add("Grade Point", typeof(decimal)); dtFinallMarksOfStudentList.Columns["Grade Point"].DefaultValue = "0";
                    int GroupIndex = 0;
                    DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewCCEMarksDetail] " + cmbClass.SelectedValue + "," + cmbSection.SelectedValue + "," + school.CurrentSessionCode + "");

                    if (dtStudentMarksDetail.Rows.Count > 0)
                    {
                        DataTable dtStudent = dtStudentMarksDetail.DefaultView.ToTable(true, "studentno", "scholarno", "name");
                        DataTable dtSubjectMarks = dtStudentMarksDetail.DefaultView.ToTable(true, "subjectno", "SubjectCode", "subjectname");
                        if (dtStudent.Rows.Count > 0)
                        {
                            foreach (DataRow rStudent in dtStudent.Rows)
                            {
                                DataRow NewRow = dtFinallMarksOfStudentList.NewRow();
                                NewRow["Student No"] = rStudent["studentno"];
                                NewRow["Scholar No"] = rStudent["scholarno"];
                                NewRow["Name"] = rStudent["name"];
                                dtFinallMarksOfStudentList.Rows.Add(NewRow);
                                DataRow[] rws = dtStudentMarksDetail.Select("StudentNo='" + rStudent["studentno"] + "'");
                                for (int i = 0; i < rws.Length; i++)
                                {

                                    DataRow NewSubRow = dtFinallMarksOfStudentList.NewRow();
                                    NewSubRow["Student No"] = rws[i]["studentno"];
                                    NewSubRow["Scholar No"] = DBNull.Value;
                                    NewSubRow["Name"] = DBNull.Value;
                                    NewSubRow["Subject No"] = rws[i]["subjectno"];
                                    NewSubRow["Subject Code/Name"] = rws[i]["SubjectCode"].ToString() + "/" + rws[i]["subjectname"].ToString();
                                    NewSubRow["FA1"] = rws[i]["FA1"];
                                    NewSubRow["FA1-10%"] = rws[i]["FA1-10%"];
                                    NewSubRow["FA1 G"] = rws[i]["FA1 G"];
                                    NewSubRow["FA2"] = rws[i]["FA2"];
                                    NewSubRow["FA2-10%"] = rws[i]["FA2-10%"];
                                    NewSubRow["FA2 G"] = rws[i]["FA2 G"];
                                    NewSubRow["FA1FA2-20%"] = rws[i]["FA1FA2-20%"];
                                    NewSubRow["SA1"] = rws[i]["SA1"];
                                    NewSubRow["SA1-30%"] = rws[i]["SA1-30%"];
                                    NewSubRow["SA1 G"] = rws[i]["SA1 G"];
                                    NewSubRow["FA1FA2SA1"] = rws[i]["FA1FA2SA1"];
                                    NewSubRow["Tot-1-G"] = rws[i]["Tot-1-G"];

                                    NewSubRow["FA3"] = rws[i]["FA3"];
                                    NewSubRow["FA3-10%"] = rws[i]["FA3-10%"];
                                    NewSubRow["FA3 G"] = rws[i]["FA3 G"];
                                    NewSubRow["FA4"] = rws[i]["FA4"];
                                    NewSubRow["FA4-10%"] = rws[i]["FA4-10%"];
                                    NewSubRow["FA4 G"] = rws[i]["FA4 G"];
                                    NewSubRow["FA3FA4-20%"] = rws[i]["FA3FA4-20%"];
                                    NewSubRow["SA2"] = rws[i]["SA2"];
                                    NewSubRow["SA2-30%"] = rws[i]["SA2-30%"];
                                    NewSubRow["SA2 G"] = rws[i]["SA2 G"];
                                    NewSubRow["FA3FA4SA2"] = rws[i]["FA3FA4SA2"];
                                    NewSubRow["Tot-2-G"] = rws[i]["Tot-2-G"];

                                    NewSubRow["FA1FA2FA3FA4 G"] = rws[i]["FA1FA2FA3FA4 G"];
                                    NewSubRow["SA1SA2 G"] = rws[i]["SA1SA2 G"];
                                    NewSubRow["Finale Grade"] = rws[i]["Finale Grade"];
                                    NewSubRow["Grade Point"] = rws[i]["Grade Point"];

                                    dtFinallMarksOfStudentList.Rows.Add(NewSubRow);
                                }
                            }
                        }
                        dtgFinalEntry.DataSource = dtFinallMarksOfStudentList;
                        btnSaveFinalMarks.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Record Is Not Available!!!", "View Acadmin Performance");
                        cmbClass.Focus();
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

        private void dtgFinalEntry_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewColumn c in dtgFinalEntry.Columns)
                {
                    c.Visible = false;
                    c.ReadOnly = true;
                    c.Width = 50;
                }
                foreach (DataGridViewRow r in dtgFinalEntry.Rows)
                {
                    if (!r.Cells["Name"].Value.Equals(DBNull.Value))
                    {
                        r.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                        r.ReadOnly = true;
                    }
                }
                //dtgFinalEntry.Columns["Student No"].Visible =true ;
                dtgFinalEntry.Columns["Scholar No"].Visible = true;
                dtgFinalEntry.Columns["Name"].Visible = true;
                dtgFinalEntry.Columns["Name"].Width = 150;

                //dtgFinalEntry.Columns["Subject No"].Visible = true;
                dtgFinalEntry.Columns["Subject Code/Name"].Visible = true;
                dtgFinalEntry.Columns["Subject Code/Name"].Width = 150;

                dtgFinalEntry.Columns["FA1"].Visible = true;
                dtgFinalEntry.Columns["FA1 G"].Visible = true;
                dtgFinalEntry.Columns["FA2"].Visible = true;
                dtgFinalEntry.Columns["FA2 G"].Visible = true;
                dtgFinalEntry.Columns["SA1"].Visible = true;
                dtgFinalEntry.Columns["SA1 G"].Visible = true;
                dtgFinalEntry.Columns["FA1FA2SA1"].Visible = true;
                dtgFinalEntry.Columns["FA1FA2SA1"].Width = 80;
                dtgFinalEntry.Columns["Tot-1-G"].Visible = true;
                dtgFinalEntry.Columns["Tot-1-G"].Width = 80;

                dtgFinalEntry.Columns["FA3"].Visible = true;
                dtgFinalEntry.Columns["FA3 G"].Visible = true;
                dtgFinalEntry.Columns["FA4"].Visible = true;
                dtgFinalEntry.Columns["FA4 G"].Visible = true;
                dtgFinalEntry.Columns["SA2"].Visible = true;
                dtgFinalEntry.Columns["SA2 G"].Visible = true;
                dtgFinalEntry.Columns["FA3FA4SA2"].Visible = true;
                dtgFinalEntry.Columns["FA3FA4SA2"].Width = 80;
                dtgFinalEntry.Columns["Tot-2-G"].Visible = true;
                dtgFinalEntry.Columns["Tot-2-G"].Width = 80;

                dtgFinalEntry.Columns["FA1FA2FA3FA4 G"].Visible = true; dtgFinalEntry.Columns["FA1FA2FA3FA4 G"].ReadOnly = false;
                dtgFinalEntry.Columns["FA1FA2FA3FA4 G"].Width = 100;
                dtgFinalEntry.Columns["SA1SA2 G"].Visible = true; dtgFinalEntry.Columns["SA1SA2 G"].ReadOnly = false;
                dtgFinalEntry.Columns["SA1SA2 G"].Width = 80;
                dtgFinalEntry.Columns["Finale Grade"].Visible = true; dtgFinalEntry.Columns["Finale Grade"].ReadOnly = false;
                dtgFinalEntry.Columns["Finale Grade"].Width = 80;
                dtgFinalEntry.Columns["Grade Point"].Visible = true; dtgFinalEntry.Columns["Grade Point"].ReadOnly = false;
                dtgFinalEntry.Columns["Grade Point"].Width = 80;
            }
            catch { }

        }


        public string GetGrade(int studno,string des)
        {
            string result = string.Empty;
              DataTable n = Connection.GetDataTable("select Grade from tbl_CCEStudentSkills " +
                                " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                                " And SessionCode='" + school.CurrentSessionCode + "' And StudentNo='" + studno + "' And Description='" + des + "' And ExamCode='" + cmbExam.SelectedIndex + "'");
              if (n.Rows.Count > 0)
              {
                  result = n.Rows[0]["Grade"].ToString();
              }
              else
              {
                  result=string.Empty;
              }
            return result;
        }
        public string GetGradeToPrimary(int studno, string des)
        {
            string result = string.Empty;
            DataTable n = Connection.GetDataTable("select Grade from tbl_CCEStudentSkills " +
                              " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                              " And SessionCode='" + school.CurrentSessionCode + "' And StudentNo='" + studno + "' And SkillId='" + des + "' And ExamCode='" + cmbExam.SelectedIndex + "'");
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
        public Boolean GetStatus(int studno, string des)
        {
            Boolean result = false;
            DataTable n = Connection.GetDataTable("select Status from tbl_CCEStudentSkills " +
                              " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                              " And SessionCode='" + school.CurrentSessionCode + "' And StudentNo='" + studno + "' And Description='" + des + "' And ExamCode='" + cmbExam.SelectedIndex + "' ");
            if (n.Rows.Count > 0)
            {
                result =Convert.ToBoolean(n.Rows[0]["Status"]);
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
                    if (!string.IsNullOrEmpty(cmbExam.Text))
                    {
                        if (this.NonPrimaryFlage)
                        {
                            if (!cmbExam.Text.Equals("SA1") && !cmbExam.Text.Equals("SA2"))
                            {
                                MessageBox.Show("Please Select Exam carefully...");
                                cmbExam.Focus();
                                return;
                            }

                            int Counter = 0;
                            DataTable dt = new DataTable("dt");
                            DataTable dtStudent = new DataTable("dtStudent");

                            dt.Columns.Add("Student No", typeof(int));
                            dt.Columns.Add("Scholar No", typeof(string));
                            dt.Columns.Add("Name", typeof(string));

                            int MaxRowNumber = Convert.ToInt32(Connection.GetExecuteScalar("Select MAX(Num) as MaxRow  From (Select Count(v.SkillId) As Num From  " +
                                   " (Select s1.SkillId ,s1.SkillName ,s2 .SubSkillId ,s2.Discription From tbl_CCESkills s1, tbl_CCESubSkills s2  " +
                                   "  Where s1.SkillId =s2.SkillId) v Group By v.SkillId) t"));

                            DataTable dtSubSkillDetail = Connection.GetDataTable(" Select s1.SkillId ,s1.SkillName ,s2 .SubSkillId ,s2.Discription  From  " +
                                 " tbl_CCESkills s1, tbl_CCESubSkills s2 Where s1.SkillId =s2.SkillId  Order By s1.SkillId");

                            //dataReader = Connection.GetDataReader("SELECT SkillId, SkillName, Status FROM tbl_CCESkills Order By SkillId");
                            dataReader = Connection.GetDataReader("SELECT tbl_CCEClassSkill.SkillId, tbl_CCESkills.SkillName  " +
                                " FROM tbl_CCEClassSkill INNER JOIN tbl_CCESkills ON tbl_CCEClassSkill.SkillId = tbl_CCESkills.SkillId " +
                                " WHERE (tbl_CCEClassSkill.ClassCode = '" + cmbClass.SelectedValue + "') AND (tbl_CCEClassSkill.SessionCode = '" + school.CurrentSessionCode + "')  " +
                                " ORDER BY tbl_CCEClassSkill.SkillOrder");
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    dt.Columns.Add("CheckBox" + dataReader["SkillId"].ToString(), typeof(bool));
                                    dt.Columns["CheckBox" + dataReader["SkillId"].ToString()].DefaultValue = false;
                                    //dt.Columns.Add(dataReader["SkillName"].ToString(), typeof(string));
                                    dt.Columns.Add(dataReader["SkillId"].ToString(), typeof(string));
                                    dt.Columns.Add("ObtainGrade" + dataReader["SkillId"].ToString(), typeof(string));
                                }
                                dataReader.Close();
                            }

                            while (MaxRowNumber > Counter)
                            {
                                dt.Rows.Add(dt.NewRow());
                                Counter++;
                            }
                            //for (int c = 0; c < dt.Columns.Count; c++)
                            for (int c = 3; c < dt.Columns.Count; c++)
                            {
                                if (!dt.Columns[c].ColumnName.Contains("CheckBox") && !dt.Columns[c].ColumnName.Contains("ObtainGrade"))
                                {
                                    Counter = 0;
                                    //DataRow[] Rows = dtSubSkillDetail.Select("SkillName='" + dt.Columns[c].ColumnName + "'");
                                    DataRow[] Rows = dtSubSkillDetail.Select("SkillId='" + dt.Columns[c].ColumnName + "'");
                                    if (Rows.Length > 0)
                                    {
                                        for (int rws = 0; rws < dt.Rows.Count; rws++)
                                        {
                                            if (rws < Rows.Length)
                                            {
                                                dt.Rows[rws][c] = Rows[rws]["Discription"];
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (DataColumn c in dt.Columns)
                                dtStudent.Columns.Add(c.ColumnName, c.DataType);

                            dataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [StudentNo], tbl_student.scholarno as [Scholar No.], " +
                               " tbl_student.name as [Name] FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                               " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "') " +
                               " AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') and  tbl_classstudent.stdtype<>'Ex-Student' ORDER BY tbl_student.name");
                            if (dataReader.HasRows)
                            {
                               
                                while (dataReader.Read())
                                {
                                    bool Flage = true;
                                    int oi = 0;
                                    foreach (DataRow dtRow in dt.Rows)
                                    {
                                        DataRow row = dtStudent.NewRow();

                                        for (int i = 0; i < dtRow.ItemArray.Length; i++)
                                        {
                                            if (dt.Columns[i].ColumnName.Contains("ObtainGrade"))
                                            {
                                                dt.Rows[oi][i] = GetGrade(Convert.ToInt16(dataReader[0]), dt.Rows[oi][i - 1].ToString());
                                            }
                                            if (dt.Columns[i].ColumnName.Contains("CheckBox"))
                                            {
                                                dt.Rows[oi][i] = GetStatus(Convert.ToInt16(dataReader[0]), dt.Rows[oi][i + 1].ToString());
                                            }
                                        }
                                        row.ItemArray = dtRow.ItemArray;
                                        row["Student No"] = dataReader[0];
                                        row["Scholar No"] = DBNull.Value;
                                        row["Name"] = DBNull.Value;
                                        if (Flage)
                                        {
                                            row["Scholar No"] = dataReader[1];
                                            row["Name"] = dataReader[2];
                                            Flage = false;
                                        }
                                        dtStudent.Rows.Add(row);
                                        oi++;
                                    }
                                }
                                dataReader.Close();
                            }

                            dtgSkills.DataSource = dtStudent;
                            btnSaveDesInd.Enabled = true;
                        }
                        else
                        {
                            DataTable dtStudent = new DataTable("dtStudent");

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
                                    dtStudent.Columns.Add(dataReader["SkillId"].ToString(), typeof(string));
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

                                        row[dtStudent.Columns[c].ColumnName.ToString()] = GetGradeToPrimary(Convert.ToInt16(dataReader["StudentNo"]), dtStudent.Columns[c].ColumnName.ToString());
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

        private void btnSaveDesInd_Click(object sender, EventArgs e)
        {
            if (dtgSkills.RowCount > 0 &&
                DialogResult.Yes.Equals(MessageBox.Show("Are You Sure To Save Descriptive Indicators For Class \"" + cmbClass.Text + " " + cmbSection.Text + "\"?", "Descriptive Indicators", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                dtgSkills.EndEdit();
                SqlTransaction trn = null;
                string cmdText = string.Empty;
                int CCEID = Convert.ToInt32(Connection.GetExecuteScalar(" Select Min(CCEID) From tbl_CCEStudentMarks Where ClassNo='" + cmbClass.SelectedValue + "' " +
                    " And SectionCode='" + cmbSection.SelectedValue + "' And SessionCode='" + school.CurrentSessionCode + "'"));

                trn = Connection.GetMyConnection().BeginTransaction();
                try
                {
                    cmdText = " DELETE FROM tbl_CCEStudentSkills WHERE ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                        " And SessionCode='" + school.CurrentSessionCode + "' And ExamCode='" + cmbExam.SelectedIndex + "'";
                    Connection.SqlTransection(cmdText, Connection.MyConnection, trn);
                    if (this.NonPrimaryFlage)
                    {
                        foreach (DataGridViewRow r in dtgSkills.Rows)
                        {
                            foreach (DataGridViewColumn c in dtgSkills.Columns)
                            {
                                if (c.Index > 2)
                                {
                                    if (!c.Name.Contains("CheckBox") && !c.Name.Contains("ObtainGrade"))
                                    {
                                        if (Convert.ToBoolean(r.Cells["CheckBox" + c.Name].Value) && r.Cells[c.Name].Value.ToString() != string.Empty)
                                        {
                                            cmdText = "INSERT INTO tbl_CCEStudentSkills(CCEID,SessionCode,SkillId,Description,Grade,Status,StudentNo,ClassNo,SectionCode,ExamCode)  VALUES " +
                                               "('" + CCEID + "','" + school.CurrentSessionCode + "','" + c.Name + "','" + r.Cells[c.Name].Value + "'," +
                                               " '" + r.Cells["ObtainGrade" + c.Name].Value + "',1,'" + r.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + cmbExam.SelectedIndex + "')";
                                            Connection.SqlTransection(cmdText, Connection.MyConnection, trn);
                                        }
                                       
                                    }
                                }
                            }
                            if (!r.Cells["Name"].Value.Equals(DBNull.Value))
                                CCEID++;
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow r in dtgSkills.Rows)
                        {
                            foreach (DataGridViewColumn c in dtgSkills.Columns)
                            {
                                if (c.Index > 2)
                                {

                                    cmdText = "INSERT INTO tbl_CCEStudentSkills(CCEID,SessionCode,SkillId,Grade,Status,StudentNo,ClassNo,SectionCode,ExamCode)  VALUES " +
                                       "('" + CCEID + "','" + school.CurrentSessionCode + "','" + c.Name + "','" + r.Cells[c.Name].Value + "'," +
                                       " 1,'" + r.Cells["Student No"].Value + "','" + cmbClass.SelectedValue + "','" + cmbSection.SelectedValue + "','" + cmbExam.SelectedIndex + "')";
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

        private void dtgFinalEntry_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dtgFinalEntry.Rows[e.RowIndex].Cells["Grade Point"].ColumnIndex))
            {
                if (Convert.ToDecimal(dtgFinalEntry.Rows[e.RowIndex].Cells["Grade Point"].Value) >= 0 &&
                    Convert.ToDecimal(dtgFinalEntry.Rows[e.RowIndex].Cells["Grade Point"].Value) <= 10)
                {
                    dtgFinalEntry.Rows[e.RowIndex].Cells["Grade Point"].Value =
                        decimal.Round(Convert.ToDecimal(dtgFinalEntry.Rows[e.RowIndex].Cells["Grade Point"].Value), 1, MidpointRounding.AwayFromZero);
                }
                else
                {
                    MessageBox.Show("Invalid Entry...");
                    dtgFinalEntry.Rows[e.RowIndex].Cells["Grade Point"].Value = 0;
                }
            }
            else if (e.ColumnIndex.Equals(dtgFinalEntry.Rows[e.RowIndex].Cells["Finale Grade"].ColumnIndex) ||
                e.ColumnIndex.Equals(dtgFinalEntry.Rows[e.RowIndex].Cells["FA1FA2FA3FA4 G"].ColumnIndex) ||
                e.ColumnIndex.Equals(dtgFinalEntry.Rows[e.RowIndex].Cells["SA1SA2 G"].ColumnIndex))
            {
                if ((dtgFinalEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpperInvariant().Contains("A") ||
                    dtgFinalEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpperInvariant().Contains("B") ||
                    dtgFinalEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpperInvariant().Contains("C") ||
                    dtgFinalEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpperInvariant().Contains("E") ||
                    dtgFinalEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpperInvariant().Contains("F")) &&
                    dtgFinalEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length <= 2)
                {
                    dtgFinalEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtgFinalEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                }
                else
                {
                    MessageBox.Show("Invalid Entry...");
                    dtgFinalEntry.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "E2";
                }
            }
        }

        private void dtgFinalEntry_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
            }
            catch { }
        }


        private void btnSaveFinalMarks_Click(object sender, EventArgs e)
        {
            DataTable n = Connection.GetDataTable("Select Top 1 FA1 ,FA2 ,SA1 ,FA3 ,FA4 ,SA2  From tbl_CCEStudentMarks " +
                           " Where ClassNo='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' " +
                           " And SessionCode='" + school.CurrentSessionCode + "'   ");
            if (n.Rows.Count > 0)
            {
                if (n.Rows[0]["FA1"].Equals(DBNull.Value))
                {
                    MessageBox.Show("Please Fill Record Of FA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (n.Rows[0]["FA2"].Equals(DBNull.Value))
                {
                    MessageBox.Show("Please Fill Record Of FA2!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (n.Rows[0]["SA1"].Equals(DBNull.Value))
                {
                    MessageBox.Show("Please Fill Record Of SA1!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (n.Rows[0]["FA3"].Equals(DBNull.Value))
                {
                    MessageBox.Show("Please Fill Record Of FA3!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (n.Rows[0]["FA4"].Equals(DBNull.Value))
                {
                    MessageBox.Show("Please Fill Record Of FA4!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (n.Rows[0]["SA2"].Equals(DBNull.Value))
                {
                    MessageBox.Show("Please Fill Record Of SA2!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            SqlTransaction trn = null;
            dtgFinalEntry.EndEdit();
            trn = Connection.GetMyConnection().BeginTransaction();
            try
            {
                foreach (DataGridViewRow dr in dtgFinalEntry.Rows)
                {
                    if (dr.Cells["Subject Code/Name"].Value != DBNull.Value)
                    {
                        foreach (DataGridViewColumn dc in dtgFinalEntry.Columns)
                        {
                            if (dc.Index > 2 && dr.Cells["FA1FA2FA3FA4 G"].Value != DBNull.Value && dr.Cells["SA1SA2 G"].Value != DBNull.Value
                                && dr.Cells["Finale Grade"].Value != DBNull.Value && dr.Cells["Grade Point"].Value != DBNull.Value)
                            {
                                Connection.SqlTransection("Update tbl_CCEStudentMarks Set FA1FA2FA3FA4G='" + dr.Cells["FA1FA2FA3FA4 G"].Value + "', " +
                                    " SA1SA2G='" + dr.Cells["SA1SA2 G"].Value + "', FinalGrade='" + dr.Cells["Finale Grade"].Value + "', " +
                                    " GradePoint='" + dr.Cells["Grade Point"].Value + "' Where  StudentNo='" + dr.Cells["Student No"].Value + "' And " +
                                    " ClassNo ='" + cmbClass.SelectedValue + "' And  SectionCode='" + cmbSection.SelectedValue + "' And  " +
                                    " SubjectNo='" + dr.Cells["Subject No"].Value + "' And SessionCode='" + school.CurrentSessionCode + "'", Connection.MyConnection, trn);
                            }
                        }
                    }
                }
                trn.Commit();
                MessageBox.Show("Finale Grade And Point Saved ...");
                btnSaveFinalMarks.Enabled = false;
            }
            catch
            {
                trn.Rollback();
                MessageBox.Show("Record Not Saved Properly...\n\tSome Record Are Missing...");
                btnSaveFinalMarks.Enabled = false;
            }
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
           c.GetMdiParent(this).ToggleEditButton(false);
           c.GetMdiParent(this).ToggleSaveButton(true);
            btnShow.Enabled = true;
            cmbClass.Focus();
        }
        public override void btnedit_Click(object sender, EventArgs e)
        {
            c.GetMdiParent(this).ToggleNewButton(false);
            c.GetMdiParent(this).ToggleSaveButton(true);
            btnShow.Enabled = true;
            cmbClass.Focus();
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            c.GetMdiParent(this).ToggleNewButton(true);
           c.GetMdiParent(this).ToggleEditButton(true);
           c.GetMdiParent(this).ToggleSaveButton(false);
            btnShow.Enabled = false;
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
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

        private void btnViewAcadmincDetail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                    listView1.View = View.Details;
                    listView1.Items.Clear();
                    listView1.Columns.Clear();
                    listView1.Groups.Clear();

                    listView1.Columns.Add("Subject Code", 80, HorizontalAlignment.Left); listView1.Columns.Add("Subject", 150, HorizontalAlignment.Left);

                    listView1.Columns.Add("FA1", 40, HorizontalAlignment.Right); listView1.Columns.Add("FA1-10%", 60, HorizontalAlignment.Right); listView1.Columns.Add("FA1 G", 50, HorizontalAlignment.Center);
                    listView1.Columns.Add("FA2", 40, HorizontalAlignment.Right); listView1.Columns.Add("FA2-10%", 60, HorizontalAlignment.Right); listView1.Columns.Add("FA2 G", 50, HorizontalAlignment.Center);
                    listView1.Columns.Add("FA1FA2-20%", 80, HorizontalAlignment.Right); listView1.Columns.Add("FA1FA2 G", 80, HorizontalAlignment.Right);
                    listView1.Columns.Add("SA1", 40, HorizontalAlignment.Right); listView1.Columns.Add("SA1-30%", 60, HorizontalAlignment.Right); listView1.Columns.Add("SA1 G", 50, HorizontalAlignment.Center);
                    listView1.Columns.Add("FA1FA2SA1", 80, HorizontalAlignment.Right);
                    listView1.Columns.Add("Tot-1-G", 60, HorizontalAlignment.Center);

                    listView1.Columns.Add("FA3", 40, HorizontalAlignment.Right); listView1.Columns.Add("FA3-10%", 60, HorizontalAlignment.Right); listView1.Columns.Add("FA3 G", 50, HorizontalAlignment.Center);
                    listView1.Columns.Add("FA4", 40, HorizontalAlignment.Right); listView1.Columns.Add("FA4-10%", 60, HorizontalAlignment.Right); listView1.Columns.Add("FA4 G", 50, HorizontalAlignment.Center);
                    listView1.Columns.Add("FA3FA4-20%", 80, HorizontalAlignment.Right); listView1.Columns.Add("FA3FA4 G", 80, HorizontalAlignment.Right);
                    listView1.Columns.Add("SA2", 40, HorizontalAlignment.Right); listView1.Columns.Add("SA2-30%", 60, HorizontalAlignment.Right); listView1.Columns.Add("SA2 G", 50, HorizontalAlignment.Center);
                    listView1.Columns.Add("FA3FA4SA2", 80, HorizontalAlignment.Right);
                    listView1.Columns.Add("Tot-2-G", 60, HorizontalAlignment.Center);

                    listView1.Columns.Add("TOT-FA1FA2FA3FA4", 120, HorizontalAlignment.Center);
                    listView1.Columns.Add("FA1FA2FA3FA4 G", 120, HorizontalAlignment.Center);
                    listView1.Columns.Add("TOT-SA1SA2", 80, HorizontalAlignment.Center);
                    listView1.Columns.Add("SA1SA2 G", 80, HorizontalAlignment.Center);
                    listView1.Columns.Add("TOT-Marks", 80, HorizontalAlignment.Center);
                    listView1.Columns.Add("Finale Grade", 80, HorizontalAlignment.Center);
                    listView1.Columns.Add("Grade Point", 80, HorizontalAlignment.Right);

                    int GroupIndex = 0;
                    DataTable dtStudentMarksDetail = Connection.GetDataTable("[dbo].[GetViewCCEMarksDetail] " + cmbClass.SelectedValue + "," + cmbSection.SelectedValue + "," + school.CurrentSessionCode + "");

                    if (dtStudentMarksDetail.Rows.Count > 0)
                    {
                        DataTable dtStudent = dtStudentMarksDetail.DefaultView.ToTable(true, "studentno", "scholarno", "name");
                        DataTable dtSubjectMarks = dtStudentMarksDetail.DefaultView.ToTable(true, "subjectno", "SubjectCode", "subjectname");
                        if (dtStudent.Rows.Count > 0)
                        {
                            foreach (DataRow rStudent in dtStudent.Rows)
                            {
                                GroupIndex = listView1.Groups.Add(new ListViewGroup(rStudent["scholarno"].ToString() + " " + rStudent["name"].ToString()));
                                DataRow[] rws = dtStudentMarksDetail.Select("StudentNo='" + rStudent["studentno"] + "'");
                                for (int i = 0; i < rws.Length; i++)
                                {
                                    ListViewItem StudenItem = listView1.Items.Insert(GroupIndex, rws[i]["SubjectCode"].ToString());
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["subjectname"].ToString()));

                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA1"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA1-10%"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA1 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA2"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA2-10%"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA2 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA1FA2-20%"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA1FA2 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["SA1"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["SA1-30%"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["SA1 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA1FA2SA1"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["Tot-1-G"].ToString()));

                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA3"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA3-10%"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA3 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA4"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA4-10%"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA4 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA3FA4-20%"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA3FA4 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["SA2"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["SA2-30%"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["SA2 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA3FA4SA2"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["Tot-2-G"].ToString()));

                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["TOT-FA1FA2FA3FA4"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["FA1FA2FA3FA4 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["TOT-SA1SA2"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["SA1SA2 G"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["TOT-Marks"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["Finale Grade"].ToString()));
                                    StudenItem.SubItems.Add(new ListViewItem.ListViewSubItem(StudenItem, rws[i]["Grade Point"].ToString()));

                                    StudenItem.Group = listView1.Groups[GroupIndex];
                                }
                                GroupIndex++;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Record Is Not Available!!!", "View Acadmin Performance");
                        cmbClass.Focus();
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

        private void frmNewCBSCMarksheet_Paint(object sender, PaintEventArgs e)
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

        private void tabPage3_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void tabPage5_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

           

       

    }
}
