using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Report.Student.ReportForm
{
    public partial class frmScholarshipStatus :UserControlBase
    {
        public frmScholarshipStatus()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        static int itId = 0, FLAG = 0;
        public void FillGrid()
        {
            DataTable dt = clsClassStudent.GetDataForReport();
            DataView dv = dt.DefaultView;//dsDetail.Tables[0].DefaultView;
            if (chkSanction.Checked == false && chkReceive.Checked == false && chkClassWise.Checked == false && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Section='" + cmbSection.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == false && chkReceive.Checked == false && chkClassWise.Checked == true && chkSection.Checked == false)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and classno='" + cmbClass.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == false && chkReceive.Checked == false && chkClassWise.Checked == true && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Section='" + cmbSection.SelectedValue.ToString() + "' and classno='" + cmbClass.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == false && chkReceive.Checked == true && chkClassWise.Checked == false && chkSection.Checked == false)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and [Distri. Status]='RECEIVE'";
            }
            else if (chkSanction.Checked == false && chkReceive.Checked == true && chkClassWise.Checked == false && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and [Distri. Status]='RECEIVE' and Section='" + cmbSection.SelectedValue.ToString() + "' ";
            }
            else if (chkSanction.Checked == false && chkReceive.Checked == true && chkClassWise.Checked == true && chkSection.Checked == false)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and [Distri. Status]='RECEIVE' and classno='" + cmbClass.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == false && chkReceive.Checked == true && chkClassWise.Checked == true && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and [Distri. Status]='RECEIVE' and Section='" + cmbSection.SelectedValue.ToString() + "' and classno='" + cmbClass.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == true && chkReceive.Checked == false && chkClassWise.Checked == false && chkSection.Checked == false)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Status='SANCTION'";
            }
            else if (chkSanction.Checked == true && chkReceive.Checked == false && chkClassWise.Checked == false && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Status='SANCTION' and Section='" + cmbSection.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == true && chkReceive.Checked == false && chkClassWise.Checked == true && chkSection.Checked == false)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Status='SANCTION' and classno='" + cmbClass.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == true && chkReceive.Checked == false && chkClassWise.Checked == true && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Status='SANCTION' and Section='" + cmbSection.SelectedValue.ToString() + "' and classno='" + cmbClass.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == true && chkReceive.Checked == true && chkClassWise.Checked == false && chkSection.Checked == false)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Status='SANCTION' and [Distri. Status]='RECEIVE' ";
            }
            else if (chkSanction.Checked == true && chkReceive.Checked == true && chkClassWise.Checked == false && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Status='SANCTION' and [Distri. Status]='RECEIVE' and Section='" + cmbSection.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == true && chkReceive.Checked == true && chkClassWise.Checked == true && chkSection.Checked == false)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Status='SANCTION' and [Distri. Status]='RECEIVE' and classno='" + cmbClass.SelectedValue.ToString() + "'";
            }
            else if (chkSanction.Checked == true && chkReceive.Checked == true && chkClassWise.Checked == true && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Status='SANCTION' and [Distri. Status]='RECEIVE' and Section='" + cmbSection.SelectedValue.ToString() + "' and classno='" + cmbClass.SelectedValue.ToString() + "'";
            }
            else
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "'";
            }

            if (dv.Table.Rows.Count > 0)
            {
                dgvScholarDetails.DataSource = dv;
            }
        }
        private void frmScholarshipStatus_Load(object sender, EventArgs e)
        {
            itId = FLAG = 0;
            Connection.FillComboBox(cmbSession, " select sessioncode,sessionname from tbl_session order by sessioncode ");
            Connection.FillComboBox(cmbClass, " select classcode,classname from tbl_classmaster order by classcode ");
            cmbSession.SelectedValue = school.CurrentSessionCode;
            FillGrid();
        }

        private void cmbClass_Leave(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbSection, " SELECT tbl_section.sectioncode, tbl_section.sectionname FROM " +
           " tbl_classstudent INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode " +
           " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') And  (tbl_classstudent.sessioncode = " +
           " '" + cmbSession.SelectedValue + "') GROUP BY tbl_section.sectioncode, tbl_section.sectionname " +
           " Order by tbl_section.sectioncode");
        }

        private void dgvScholarDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvScholarDetails.Columns["studentno"].Visible = false;
                dgvScholarDetails.Columns["classno"].Visible = false;
                dgvScholarDetails.Columns["Section"].Visible = false;
                dgvScholarDetails.Columns["sessioncode"].Visible = false;
                dgvScholarDetails.Columns["sessionname"].Visible = false;
                dgvScholarDetails.DefaultCellStyle.ForeColor = Color.Black;
                dgvScholarDetails.DefaultCellStyle.BackColor = Color.White;

            }
            catch { }
        }

        private void chkClassWise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClassWise.Checked)
            {
                cmbClass.Enabled = true;
                cmbClass.Focus();
                FillGrid();
            }
            else
            {
                cmbClass.Enabled = false;
                FillGrid();
            }
        }

        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection.Checked)
            {
                cmbSection.Enabled = true;
                cmbSection.Focus();
                FillGrid();
            }
            else
            {
                cmbSection.Enabled = false;
                FillGrid();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void frmScholarshipStatus_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvScholarDetails.RowCount > 0)
                {
                    DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school");
                    ds.Tables.Add(Connection.GetDataTableFromDataGridView(dgvScholarDetails));
                    if (dgvScholarDetails.RowCount > 0)
                    {
                        ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\StudentScholarStatus.xsd");
                        Report.Student.ReportDesign.rptScholarshipStatus cr = new Report.Student.ReportDesign.rptScholarshipStatus();
                        cr.SetDataSource(ds);
                        ShowAllReports s = new ShowAllReports();
                        s.crystalReportViewer1.ReportSource = cr;
                        s.Show();
                    }
                }
                else
                {

                }
            }
            catch { }
        }

        private void chkSanction_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSanction.Checked == true)
                chkSanction.Text = "SANCTION";
            else
                chkSanction.Text = "NOT SANCTION";
            FillGrid();
        }

        private void chkReceive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReceive.Checked == true)
                chkReceive.Text = "RECEIVE";
            else
                chkReceive.Text = "NOT RECEIVE";
            FillGrid();
        }

        private void btnAYS_Click(object sender, EventArgs e)
        {
            int Indexer = 0;
            DataTable dtTable = new DataTable("dtTable");
            DataTable dt = clsClassStudent.GetDataOfStudent();
            DataTable dtschstatus = clsClassStudent.GetDataOfClassStudent();
            dtTable.Columns.Add("studentno", typeof(int)); Indexer++;
            dtTable.Columns.Add("name", typeof(string)); Indexer++;
            dtTable.Columns.Add("scholarno", typeof(string)); Indexer++;
            dtTable.Columns.Add("father", typeof(string)); Indexer++;
            dtTable.Columns.Add("mother", typeof(string)); Indexer++;
            dtTable.Columns.Add("phone", typeof(string)); Indexer++;
            dtTable.Columns.Add("schappno_I", typeof(string)); Indexer++;
            dtTable.Columns.Add("Status_I", typeof(string)); Indexer++;
            dtTable.Columns.Add("DistriStatus_I", typeof(string)); Indexer++;
            dtTable.Columns.Add("schappno_II", typeof(string)); Indexer++;
            dtTable.Columns.Add("Status_II", typeof(string)); Indexer++;
            dtTable.Columns.Add("DistriStatus_II", typeof(string)); Indexer++;
            dtTable.Columns.Add("schappno_III", typeof(string)); Indexer++;
            dtTable.Columns.Add("Status_III", typeof(string)); Indexer++;
            dtTable.Columns.Add("DistriStatus_III", typeof(string)); Indexer++;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow[] Student101 = dtschstatus.Select("studentno='" + dt.Rows[i]["studentno"] + "' And classno='101'");
                DataRow[] Student102 = dtschstatus.Select("studentno='" + dt.Rows[i]["studentno"] + "' And classno='102'");
                DataRow[] Student103 = dtschstatus.Select("studentno='" + dt.Rows[i]["studentno"] + "' And classno='103'");

                DataRow NewRow = dtTable.NewRow();
                NewRow["studentno"] = dt.Rows[i]["studentno"]; NewRow["name"] = dt.Rows[i]["name"];
                NewRow["scholarno"] = dt.Rows[i]["scholarno"]; NewRow["father"] = dt.Rows[i]["father"];
                NewRow["mother"] = dt.Rows[i]["mother"]; NewRow["phone"] = dt.Rows[i]["phone"];
                if (Student101.Length > 0)
                {
                    NewRow["schappno_I"] = Student101[0]["schappno"]; NewRow["Status_I"] = Student101[0]["Status"]; NewRow["DistriStatus_I"] = Student101[0]["DistriStatus"];
                }
                else
                {
                    NewRow["schappno_I"] = ""; NewRow["Status_I"] = ""; NewRow["DistriStatus_I"] = "";
                }
                if (Student102.Length > 0)
                {
                    NewRow["schappno_II"] = Student102[0]["schappno"]; NewRow["Status_II"] = Student102[0]["Status"]; NewRow["DistriStatus_II"] = Student102[0]["DistriStatus"];
                }
                else
                {
                    NewRow["schappno_II"] = ""; NewRow["Status_II"] = ""; NewRow["DistriStatus_II"] = "";
                }
                if (Student103.Length > 0)
                {
                    NewRow["schappno_III"] = Student103[0]["schappno"]; NewRow["Status_III"] = Student103[0]["Status"]; NewRow["DistriStatus_III"] = Student103[0]["DistriStatus"];
                }
                else
                {
                    NewRow["schappno_III"] = ""; NewRow["Status_III"] = ""; NewRow["DistriStatus_III"] = "";
                }
                
               
                
                
                dtTable.Rows.Add(NewRow);
            }
            DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school");
            ds.Tables.Add(dtTable);
            if (dgvScholarDetails.RowCount > 0)
            {
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\StudentSchStsThreeYear.xsd");
                Report.Student.ReportDesign.rptScholarshipStatusComplete cr = new Report.Student.ReportDesign.rptScholarshipStatusComplete();
                cr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr;
                s.Show();
            }
        }

       
    }
}
