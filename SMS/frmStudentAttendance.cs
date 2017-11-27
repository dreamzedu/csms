using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

namespace SMS
{
    public partial class frmStudentAttendance :UserControlBase
    {
        school1 c = new school1();
        Boolean MessageService = false;
        public frmStudentAttendance()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);

            //CultureInfo cultureInfo = new CultureInfo("ne-NP");
            //Thread.CurrentThread.CurrentCulture = cultureInfo;

            // Use the Hebrew calendar for formatting and interpreting dates and times
            //cultureInfo.DateTimeFormat.Calendar = new HebrewCalendar();

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
            //CultureInfo sa = new CultureInfo("hi-IN", false);
            ////sa.DateTimeFormat.Calendar = new System.Globalization.HijriCalendar();
            //// Sets the culture to Arabic (Saudi Arabia)
            //Thread.CurrentThread.CurrentCulture = sa;
            //// Sets the UI culture to Arabic (Saudi Arabia)
            //Thread.CurrentThread.CurrentUICulture = sa;

            //Thread.CurrentThread.CurrentCulture = new CultureInfo("hi-IN");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("hi-IN");
            //txtAttandanceDate.Format = DateTimePickerFormat.Custom;
            //txtAttandanceDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern;
        }
        public void GetStudent()
        {
            string qry = string.Empty;
            int CCEID = Convert.ToInt32(Connection.GetId("select COUNT(*) from tbl_StudentAttendancedet where SectionNo='" + cmbSection.SelectedValue.ToString() + "' and ClassNo='" + cmbClass.SelectedValue.ToString() + "' and SessionCode='" + school.CurrentSessionCode + "' and AttendanceDate='" + Connection.GetDateMMddyyyy (txtAttandanceDate.Value.ToString("dd/MM/yyyy"))+ "'"));
            if (CCEID > 0)
            {
                qry = "SELECT     dbo.tbl_student.studentno, dbo.tbl_student.scholarno, dbo.tbl_student.name, isnull(dbo.tbl_StudentAttendancedet.Attendance,'True') as Attendance FROM         dbo.tbl_student LEFT OUTER JOIN      dbo.tbl_classstudent ON dbo.tbl_student.studentno = dbo.tbl_classstudent.studentno LEFT OUTER JOIN   dbo.tbl_StudentAttendancedet ON dbo.tbl_student.studentno = dbo.tbl_StudentAttendancedet.studentno where  (dbo.tbl_classstudent.ClassNo = '" + cmbClass.SelectedValue.ToString() + "') AND (dbo.tbl_classstudent.Section = '" + cmbSection.SelectedValue.ToString() + "') and dbo.tbl_classstudent.sessioncode='" + school.CurrentSessionCode + "' and dbo.tbl_StudentAttendancedet.AttendanceDate = '" + Connection.GetDateMMddyyyy(txtAttandanceDate.Value.ToString("dd/MM/yyyy")) + "' ";
            }
            else
            {
                qry = "SELECT     dbo.tbl_student.studentno, dbo.tbl_student.scholarno, dbo.tbl_student.name, 'True' as Attendance FROM         dbo.tbl_student LEFT OUTER JOIN      dbo.tbl_classstudent ON dbo.tbl_student.studentno = dbo.tbl_classstudent.studentno where  (dbo.tbl_classstudent.ClassNo = '" + cmbClass.SelectedValue.ToString() + "') AND (dbo.tbl_classstudent.Section = '" + cmbSection.SelectedValue.ToString() + "') and dbo.tbl_classstudent.sessioncode='" + school.CurrentSessionCode + "' ";
            }
            try
            {
                this.dataGridView1.Rows.Clear();
                DataSet ds = Connection.GetDataSet(qry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        this.dataGridView1.Rows.Add(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][3].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Date Of Attendance!!!");
                    return;
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        public string  SendMessage(int stuno,string name,string cl,System.Data.SqlClient.SqlTransaction trn)
        {
            string m_Content = @"select Description,Status from tbl_Template where TemplateId=1",rstr=string.Empty;
            DataSet ds = new DataSet();
            ds = Connection.GetDataSet(m_Content);
            if (ds.Tables[0].Rows.Count > 0)
            {
                m_Content = ds.Tables[0].Rows[0]["Description"].ToString();
                string[] ss = m_Content.Split(new string[] { " ", "\r", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> LabelAttary = new List<string>();
                foreach (string s in ss)
                {
                    if (Regex.IsMatch(s, "^[<]{1}[A-Za-z1-9]+[>]{1}$"))
                    {
                        if (s.Equals("<studentsname>"))
                        {
                            m_Content = m_Content.Replace(s, name);
                        }
                        if (s.Equals("<classname>"))
                        {
                            m_Content = m_Content.Replace(s, cl);
                        }
                    }
                    
                }
                #region "Messaging Services"
                if ( this.MessageService==true && ds.Tables[0].Rows[0]["Status"].ToString().Equals("True"))
                {
                    DataTable dtStudent = Connection.GetDataTable("select Phone from tbl_student where studentno='"+stuno+"'");
                    if (dtStudent.Rows.Count > 0)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(dtStudent.Rows[0]["Phone"].ToString()))
                            {
                                Connection.SendSMS(dtStudent.Rows[0]["Phone"].ToString(),
                                    m_Content);
                                Connection.SqlTransection("insert into MessageLog (StudentEmpNo, Description, MobileNo, Date, ResponseId) " +
                        " Values('" + stuno + "','" + m_Content + "','" +
                        dtStudent.Rows[0]["Phone"].ToString() + "','" + DateTime.Now.ToString() + "','" +Connection.MResponseId
                         + "')",
                        Connection.MyConnection, trn);
                                rstr = "True";
                            }
                        }
                        catch(Exception ex){Logger.LogError(ex); }
                    }
                }
                else
                    rstr = "False";
                #endregion

                

            }
            return rstr;

            

        }
        private void frmStudentAttendance_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode ,ClassName From tbl_ClassMaster Order By ClassOrder");
            Connection.FillComboBox(cmbSection, "Select SectionCode ,SectionName From tbl_Section");
            this.MessageService = Convert.ToBoolean(Connection.GetExecuteScalar("Select MessageService From tbl_School"));
            c.GetMdiParent(this).ToggleSaveButton(true);
           
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            GetStudent();
        }
        public string SaveData()
        {
            string res = string.Empty;
            System.Data.SqlClient.SqlTransaction trn = Connection.GetMyConnection().BeginTransaction();
            Connection.SqlTransection("Delete From tbl_StudentAttendancedet Where AttendanceDate = '" + Connection.GetDateMMddyyyy(txtAttandanceDate.Value.Date.ToString("dd/MM/yyyy")) + "' and SessionCode='" +
                    school.CurrentSessionCode + "'",
                Connection.MyConnection, trn);
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                Connection.SqlTransection("insert into tbl_StudentAttendancedet (studentno, AttendanceDate, Attendance, ClassNo, SectionNo,SessionCode) " +
                    " Values('" + r.Cells[0].Value + "','" + Connection.GetDateMMddyyyy(txtAttandanceDate.Value.ToString("dd/MM/yyyy")) + "','" +
                    r.Cells[3].Value + "','" + cmbClass.SelectedValue.ToString() + "','" +
                    cmbSection.SelectedValue.ToString() + "','" +
                    school.CurrentSessionCode + "')",
                    Connection.MyConnection, trn);
                if (r.Cells[3].Value.ToString().Equals("False"))
                {
                    res=SendMessage(Convert.ToInt16(r.Cells[0].Value), r.Cells[2].Value.ToString(), cmbClass.SelectedValue.ToString(), trn);

                }
            }
            trn.Commit();
            return res;
           
        }
        public override void btnsave_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (DialogResult.Yes.Equals(MessageBox.Show("Are You Sure To Save Attendance Date Of \" " + txtAttandanceDate.Text + " \" ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                string res = string.Empty;
                res = SaveData();
                if (this.MessageService==true && res.Equals("True"))
                    MessageBox.Show("Attendance Transaction Completed...\n\tMessage Sent!!!", "School");
                else
                    MessageBox.Show("Attendance Transaction Completed...");

            }
        }

        private void Pct_Close_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frmStudentAttendance_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        

      
    }
}
