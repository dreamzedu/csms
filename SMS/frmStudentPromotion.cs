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
        DataView sessionData = null;
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
            DataSet ds = Connection.GetDataSet("Select * from tbl_session Order By S_from Desc");
            if (ds != null && ds.Tables.Count > 0)
                sessionData = ds.Tables[0].DefaultView;

            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
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
                    if (sessionData == null) return;

                    dataGridView1.Rows.Clear();
                    sessionData.RowFilter = "sessionCode='" + school.CurrentSessionCode + "'";
                    string sessionStartDate = sessionData.Table.Rows[0]["s_from"].ToString();
                    string sessionName = sessionData[0]["SessionName"].ToString();
  

                    sessionData.RowFilter = "s_from<'" + sessionStartDate + "' and SessionStatus=0";

                    if (sessionData.Count <= 0) return;

                    PrevSession = sessionData[0]["SessionCode"].ToString();
                    var prevSessionName = sessionData[0]["SessionName"].ToString();

                    lblStatus.ForeColor = Color.Blue;
                    lblStatus.Text = "Promotion from " + prevSessionName
                        + " to " + sessionName;

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
                        MessageBox.Show("Record is not available!", "Error");
                        cmbClass.Focus();
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

        int colorIndex = 1;
        private void tmr1_Tick(object sender, EventArgs e)
        {
            KnownColor[] names = new KnownColor[2]{KnownColor.Blue, KnownColor.BlueViolet};
            colorIndex = colorIndex % 2;
            KnownColor randomColorName = names[colorIndex];
            colorIndex++;
            lblStatus.ForeColor = Color.FromKnownColor(randomColorName); 
        }

        private void btnPromot_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (DialogResult.Yes.Equals(MessageBox.Show("Are you sure to promote Students of class "+cmbClass .Text +" to class of "+cmbPromotOn.Text +".", "Student Promotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                {
                    string CmdText = string.Empty;
                    trn = Connection.GetMyConnection().BeginTransaction();
                    try
                    {
                        if (this.Flage)
                        {
                            if (DialogResult.Yes.Equals(MessageBox.Show("If do you want to delete previous promoted Student of Class " + cmbPromotOn.Text + " \n\t\t,then click YES.", "Student Promotion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
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
                        MessageBox.Show("Students promoted Successfuly.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    if (DialogResult.Yes.Equals(MessageBox.Show("These Students are already promoted to new session.\n\n\tIf you want to update then click YES."
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
                MessageBox.Show("There are students records not shown.\n\tPlease check records."
                        , "Students Records", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        private void frmStudentPromotion_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        } 
    }
}
