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
    public partial class frmStudentPromotion :UserControlBase
    {
        SqlDataReader dataReader = null;
        string PrevSession = string.Empty;
        string ClassStream = string.Empty;
        SqlTransaction trn = null;
        bool Flage = false;
        public frmStudentPromotion()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frmStudentPromotion_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Group by  ClassCode,ClassName Order By ClassCode");
            Connection.FillComboBox(cmbPromotOn, "Select ClassCode ,ClassName From tbl_ClassMaster Group by  ClassCode,ClassName Order By ClassCode");
            Connection.FillComboBox(cmbSection, "Select SectionCode ,SectionName From tbl_Section");
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                if (!string.IsNullOrEmpty(cmbSection.Text))
                {
                    dataGridView1.Rows.Clear();
                    PrevSession = Connection.GetExecuteScalar("Select Top 1 SessionCode From tbl_session Where sessioncode<'" + school.CurrentSessionCode + "' And SessionStatus =0 Order By SessionCode Desc").ToString();
                    lblStatus.Text = "Promotion From " + Connection.GetExecuteScalar("Select SessionName From tbl_session Where sessioncode ='" + PrevSession + "' ").ToString()
                        +" To "+ Connection.GetExecuteScalar("Select SessionName From tbl_session Where sessioncode ='" + school.CurrentSessionCode + "' ").ToString() + " .";

                    dataReader = Connection.GetDataReader("SELECT tbl_student.studentno, tbl_student.scholarno, tbl_student.name, tbl_student.father, tbl_student.mother "+
                      " ,convert(varchar,tbl_student.dob,105) ,convert(varchar,tbl_student.RegDate,105),tbl_sankay.sankayname,tbl_classstudent.stdtype,tbl_sankay.sankaycode FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno " +
                      " INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode " +
                      " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') AND (tbl_classstudent.Section = '" + cmbSection.SelectedValue + "')  " +
                      " AND (tbl_classstudent.sessioncode =  " + PrevSession + ") AND (tbl_student.stdtype in ('Studying Student','New Student')) ORDER BY tbl_student.name "); 

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            this.ClassStream = dataReader["sankaycode"].ToString();
                             dataGridView1.Rows.Add(0,dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString(),
                                 dataReader[3].ToString(), dataReader[4].ToString(), dataReader[5].ToString(),dataReader[6].ToString()
                                 , dataReader[7].ToString(), dataReader[8].ToString()); 
                        }
                        dataReader.Close();
                        tmr1.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Record Is Not Available!!!", "");
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

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
                r.Cells["Chk"].Value = true;
        }

        private void btnCancelAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
                r.Cells["Chk"].Value = false;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), dataGridView1.Font, new SolidBrush(Color.Maroon), e.RowBounds.X + 2, e.RowBounds.Y + 3);
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            lblStatus.ForeColor = Color.FromKnownColor(randomColorName); 
        }

        private void btnPromot_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (DialogResult.Yes.Equals(MessageBox.Show("Are You Sure to Promote Students of Class "+cmbClass .Text +" to Class of "+cmbPromotOn.Text +".", "Student Promotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                {
                    string CmdText = string.Empty;
                    trn = Connection.GetMyConnection().BeginTransaction();
                    try
                    {
                        if (this.Flage)
                        {
                            if (DialogResult.Yes.Equals(MessageBox.Show("If do you want to delete previous promoted Student of Class " + cmbPromotOn.Text + " \n\t\tthen please choose Yes button of Dialog.", "Student Promotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                            {
                                CmdText = "Delete From tbl_ClassStudent Where SessionCode='" + school.CurrentSessionCode + "' And ClassNo='" + cmbPromotOn.SelectedValue + "' And Section='" + cmbSection.SelectedValue + "' And Stream='" + this.ClassStream + "'";
                                Connection.SqlTransection(CmdText, Connection.MyConnection, trn);
                                this.Flage = false;
                            }
                        }
                        foreach (DataGridViewRow r in dataGridView1.Rows)
                        {
                            if (Convert.ToBoolean(r.Cells["Chk"].Value))
                            {
                                CmdText = "Insert InTo tbl_classstudent (sessioncode, classno, studentno, Section, Stream,stdtype) Values ('" + school.CurrentSessionCode + "', " +
                                    " '" + cmbPromotOn.SelectedValue + "','" + r.Cells["StudentNo"].Value + "','" + cmbSection.SelectedValue + "','" + this.ClassStream + "','Studying Student') ";
                                Connection.SqlTransection(CmdText, Connection.MyConnection, trn);

                                CmdText = "Update tbl_Student Set stdtype='Studying Student' Where StudentNo = '" + r.Cells["StudentNo"].Value + "' ";
                                Connection.SqlTransection(CmdText, Connection.MyConnection, trn);
                            }
                        }
                        trn.Commit();
                        MessageBox.Show("Student Promotion Successfull...", "Promotion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Rows.Clear();
                    }
                    catch
                    {
                        trn.Rollback();
                    }
                }
            }
        }

        private void cmbPromotOn_Leave(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                bool flage = (Convert.ToInt32(Connection.GetExecuteScalar("Select Count(*) From tbl_ClassStudent Where SessionCode='" + school.CurrentSessionCode + "' " +
                    " And ClassNo='" + cmbPromotOn.SelectedValue + "' And Section='" + cmbSection.SelectedValue + "'")) > 0) ? true : false;
                if (flage)
                {
                    if (DialogResult.Yes.Equals(MessageBox.Show("These Students are already Promoted New Session...\n\n\tIf You Want Update Press Yes!!!"
                        , "Promotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                    {
                        this.Flage = true;
                        btnPromot.Enabled = true;
                        return;
                    }
                    else
                        btnPromot.Enabled = false;
                }
                else
                {
                    btnPromot.Enabled = true;
                    btnPromot.Focus();
                }
            }
            else
            {
                MessageBox.Show("There are Students Records not shown.\n\tPlease Check records."
                        , "Students Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void frmStudentPromotion_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        } 
    }
}
