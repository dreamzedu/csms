using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class frmBusStopDetail :UserControlBase
    {
        DataTable dtStudent = new DataTable();
      
        public frmBusStopDetail()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        } 
   
        public override void btncancel_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        private void rdoBusStopDetail_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBusStopDetail.Checked)
            {
                gbxFilter.Enabled = chkClassWise.Checked =chkSection .Checked =false ;
                dataGridView1.DataSource = Connection.GetDataTable("SELECT StopName AS [Bus Stop Name], StopFee AS [Stop Fee] " +
                   " , CASE WHEN Status = 1 THEN 'Available' ELSE 'Not Available' END AS Status FROM tbl_StopDetails ");
                dataGridView1.Columns["Bus Stop Name"].Width = 300;
                dataGridView1.Columns["Bus Stop Name"].DefaultCellStyle.Font = new Font("Tahoma", 9.0F, FontStyle.Bold);
                dataGridView1.Columns["Stop Fee"].DefaultCellStyle.Font = new Font("Tahoma", 9.0F, FontStyle.Bold);
                dataGridView1.Columns["Stop Fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
            }
        } 

        private void rdoClassWise_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoClassWise.Checked)
            {
                gbxFilter.Enabled = true;
                DataView dv = dtStudent.DefaultView;
                dv.Sort = "Name";
                dataGridView1.DataSource = dv; 
            }
        }

        private void frmBusStopDetail_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbSession, " select sessioncode,sessionname from tbl_session order by sessioncode ");
            Connection.FillComboBox(cmbClass, " select classcode,classname from tbl_classmaster order by classcode ");
            cmbSession.SelectedValue = school.CurrentSessionCode;
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSection, " SELECT tbl_section.sectioncode, tbl_section.sectionname FROM " +
                 " tbl_classstudent INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode " +
                 " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') And  (tbl_classstudent.sessioncode = " +
                 " '" + cmbSession.SelectedValue + "') GROUP BY tbl_section.sectioncode, tbl_section.sectionname " +
                 " Order by tbl_section.sectioncode");

            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtStudent = Connection.GetDataTable("SELECT tbl_student.studentno AS [Student No.], tbl_student.scholarno AS [Scholar No.] " +
            " , tbl_student.name AS Name, tbl_student.father AS [Fathers Name],tbl_student.mother AS [Mothers Name], tbl_student.phone AS [Contact No.] " +
            " , tbl_classmaster.classname + ' - ' + tbl_section.sectionname AS Class,tbl_classmaster.classcode AS ClassCode, tbl_section.sectioncode AS SectionCode " +
            " , tbl_classstudent.sessioncode AS SessionCode,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopName, '-') Else  '-' End) AS  [Stop Name] FROM tbl_student INNER JOIN tbl_classstudent ON " +
            "   tbl_student.studentno = tbl_classstudent.studentno INNER JOIN tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN " +
            "   tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo " +
            "   WHERE (tbl_classstudent.stdtype IN ('New Student', 'Studying Student')) AND (tbl_classstudent.sessioncode = '" + cmbSession.SelectedValue + "')  " +
            "   GROUP BY tbl_student.studentno, tbl_student.scholarno, tbl_student.name, tbl_student.father, tbl_student.mother, tbl_student.phone, tbl_classmaster.classname " +
            " , tbl_section.sectionname, tbl_classmaster.classcode, tbl_section.sectioncode, tbl_classstudent.sessioncode,tbl_StopDetails.StopName,tbl_student.busfacility  ");
            dataGridView1.DataSource = dtStudent;
        }

        private void chkClassWise_CheckedChanged(object sender, EventArgs e)
        {
            if(chkClassWise.Checked)
                cmbClass.Enabled = true;
            else
                cmbClass.Enabled = false;
        }

        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection .Checked)
                cmbSection .Enabled = true;
            else
                cmbSection.Enabled = false;
        }

        private void cmbClass_Leave(object sender, EventArgs e)
        {
            try
            {
                if (chkClassWise.Checked)
                {
                    DataView dv = dtStudent.DefaultView;
                    dv.RowFilter = "SessionCode='" + cmbSession.SelectedValue + "' And ClassCode='" + cmbClass.SelectedValue + "'";
                    dv.Sort = "Name";
                    dataGridView1.DataSource = dv; 
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void cmbSection_Leave(object sender, EventArgs e)
        {
            try
            {
                if (chkSection.Checked)
                {
                    DataView dv = dtStudent.DefaultView;
                    dv.RowFilter = "SessionCode='" + cmbSession.SelectedValue + "' And ClassCode='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "'";
                    dv.Sort = "Name";
                    dataGridView1.DataSource = dv; 
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkClassWise.Checked)
                {
                    DataView dv = dtStudent.DefaultView;
                    dv.RowFilter = "SessionCode='" + cmbSession.SelectedValue + "' And ClassCode='" + cmbClass.SelectedValue + "' And [Stop Name] Like '" + txtSearch .Text .Trim () + "%'";
                    dv.Sort = "Name";
                    dataGridView1.DataSource = dv; 
                }
                else if (chkClassWise.Checked && chkSection.Checked)
                {
                    DataView dv = dtStudent.DefaultView;
                    dv.RowFilter = "SessionCode='" + cmbSession.SelectedValue + "' And ClassCode='" + cmbClass.SelectedValue + "' And SectionCode='" + cmbSection.SelectedValue + "' And [Stop Name] Like '" + txtSearch.Text.Trim() + "%'";
                    dv.Sort = "Name";
                    dataGridView1.DataSource = dv; 
                }
                else
                {
                    DataView dv = dtStudent.DefaultView;
                    dv.RowFilter = "SessionCode='" + cmbSession.SelectedValue + "' And [Stop Name] Like '" + txtSearch.Text.Trim() + "%'";
                    dv.Sort = "Name"; 
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }
 

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.Columns["SessionCode"].Visible = false;
                dataGridView1.Columns["SectionCode"].Visible = false;
                dataGridView1.Columns["ClassCode"].Visible = false;
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school");
                ds.Tables.Add(Connection.GetDataTableFromDataGridView(dataGridView1));
                if (rdoBusStopDetail.Checked)
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\StopDetail.xsd");
                    rptBusstopInfo r = new rptBusstopInfo();
                    r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    r.SetDataSource(ds);
                    ShowAllReports f = new ShowAllReports();
                    f.Text = "Report";
                    f.crystalReportViewer1.ReportSource = r;
                    r.SetParameterValue("ReportTitle", "Bus Stop Details");
                    f.Show();
                }
                else if (rdoClassWise.Checked)
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\ListOfStudentByBus.xsd");
                    rptBusstopClasswiseInfo r = new rptBusstopClasswiseInfo();
                    r.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    r.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    r.SetDataSource(ds);
                    txtSearch.Text = "Search By Stop";
                    ShowAllReports f = new ShowAllReports();
                    f.Text = "Report";
                    f.crystalReportViewer1.ReportSource = r;
                    if (chkClassWise.Checked && !chkSection.Checked)
                        r.SetParameterValue("ReportTitle", "Bus Stop Details For Class-"+ cmbClass .Text);
                    else if (chkClassWise.Checked && chkSection.Checked)
                        r.SetParameterValue("ReportTitle", "Bus Stop Details For Class-" + cmbClass.Text+"-"+cmbSection .Text );
                    else
                        r.SetParameterValue("ReportTitle", "Student Stop Details ");
                    f.Show();
                }
            }
        }

        private void frmBusStopDetail_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

       
    }
}
