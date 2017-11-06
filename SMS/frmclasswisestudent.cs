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
    public partial class frmclasswisestudent :UserControlBase
    {
        school1 c = new school1();
        DataTable dtStudentDetail = new DataTable();
        public frmclasswisestudent()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        private void frmclasswisestudent_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbSession, " select sessioncode,sessionname from tbl_session order by sessioncode ");
            Connection.FillComboBox(cmbClass, " select classcode,classname from tbl_classmaster order by classcode ");
            Connection.FillCombo(ref strCmbReligion, "select Religion from tbl_student Where Datalength(Religion)>0 Group By Religion Order By Religion");
            cmbSession.SelectedValue = school.CurrentSessionCode;
            cmbStudentStatus.SelectedIndex = 0;
            strstdcategory.SelectedIndex = 0;
            strCmbReligion.SelectedIndex = 0;
            cmbgender.SelectedIndex = 0;

        }         
         
        private void btnsectionwise_Click(object sender, EventArgs e)
        {
            try { }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\t Please Select Class or Section Properly...");
            }
        }

        private void chkClassWise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClassWise.Checked)
            {
                cmbClass.Enabled = true;
                cmbClass.Focus();
                GetFilterRecord();
            }
            else
            {
                GetFilterRecord();
                cmbClass.Enabled = false;
            }
        }

        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection.Checked)
            {
                cmbSection.Enabled = true;
                cmbSection.Focus();
                if (chkClassWise.Checked == true)
                    GetFilterRecord();
                else
                    chkSection.Checked = false;
            }
            else
            {
                cmbSection.Enabled = false;
                if (chkClassWise.Checked == true)
                    GetFilterRecord();
                else
                    chkSection.Checked = false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chkClassWise.Checked==true)
            GetFilterRecord();
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtStudentDetail = Connection.GetDataTable("sp_AllStudent '"+cmbSession .SelectedValue +"'");
                if (dtStudentDetail.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dtStudentDetail;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                        {
                            ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                            break;
                        }
                }
            }
            catch { }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.Columns["ClassCode"].Visible = false;
                dataGridView1.Columns["SectionCode"].Visible = false;
                dataGridView1.Columns["Photo"].Visible = false;
            }
            catch { }

        }
 
        private void cmbSection_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school");
                    ds.Tables.Add((DataTable)dataGridView1.DataSource);
                    if (dataGridView1.RowCount > 0)
                    {
                        ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\StudentDetails.xsd");
                        rptStudentDetail cr = new rptStudentDetail();
                        cr.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                        cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                        cr.SetDataSource(ds);
                        ShowAllReports s = new ShowAllReports();
                        s.crystalReportViewer1.ReportSource = cr;
                        if (chkClassWise.Checked && !chkSection.Checked)
                            cr.SetParameterValue("ReportTitle", cmbStudentStatus.Text + " Details For Class-" + cmbClass.Text);
                        else if (chkClassWise.Checked && chkSection.Checked)
                            cr.SetParameterValue("ReportTitle", cmbStudentStatus.Text + " Details For Class-" + cmbClass.Text + "-" + cmbSection.Text);
                        else
                            cr.SetParameterValue("ReportTitle", cmbStudentStatus.Text + " Details");
                        s.Show();
                    }
                }
                else
                {

                }
            }
            catch { }

        }

        private void cmbStudentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFilterRecord();
        }

        private void cmbClass_Leave(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbSection, " SELECT tbl_section.sectioncode, tbl_section.sectionname FROM " +
            " tbl_classstudent INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode " +
            " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') And  (tbl_classstudent.sessioncode = " +
            " '" + cmbSession.SelectedValue + "') GROUP BY tbl_section.sectioncode, tbl_section.sectionname " +
            " Order by tbl_section.sectioncode");
        }

        
        private void btnclasswise_Click(object sender, EventArgs e)
        {

        }

        public void GetFilterRecord()
        {
            DataTable tdt = null; 
            try
            {
                if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 0
                   if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes'";
                       

                        dv.Sort = "Name";
                        //tdt = (DataTable)dv.ToTable();
                        dataGridView1.DataSource = (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true  &&chkRTE.Checked==true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 1
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' ";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 2
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 3
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 4
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }

                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 5
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 6
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 7
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 8
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and SectionCode=" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and SectionCode=" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and SectionCode=" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "SectionCode=" + cmbSection.SelectedValue+"'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }

                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 9
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue+"'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 10
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and SectionCode=" + cmbSection.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "SectionCode=" + cmbSection.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'"; ;
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }

                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 11
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }


                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 12
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 13
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 14
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 15
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and SectionCode=" + cmbSection.SelectedValue + " and Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 16
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and ClassCode='" + cmbClass.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and ClassCode='" + cmbClass.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and ClassCode='" + cmbClass.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "ClassCode='" + cmbClass.SelectedValue+"'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }

                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 17
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode='" + cmbClass.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and ClassCode='" + cmbClass.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode='" + cmbClass.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and ClassCode='" + cmbClass.SelectedValue+"'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 18
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes'  and ClassCode='" + cmbClass.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "'  and ClassCode='" + cmbClass.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and ClassCode='" + cmbClass.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "ClassCode='" + cmbClass.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }

                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 19
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes'  and [Physically Challanged]='Yes' and ClassCode='" + cmbClass.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "'  and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 20
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = " ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 21
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes'  and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "'  and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 22
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 23
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 24
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 25
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 26
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 27
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 28
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 29
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 30
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex == 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 31
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 32
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes'  and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "'  and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 33
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                  
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {

                    //contition 34
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 35
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {

                    //contition 36
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }

                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 37
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes'  and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "'  and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 38
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 39
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "'and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 40
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
					
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 41
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 42
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 43
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 44
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 45
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'  and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'  and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'  and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "'  and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 46
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == false && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 47
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 48
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + "";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode='" + cmbClass.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode='" + cmbClass.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + "";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 49
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + "";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + "";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + "";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + "";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 50
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 51
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 52
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                { 
                    //contition 53
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 54
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == false && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 55
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 56
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 57
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "'  and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 58
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == false && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 59
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == false)
                {
                    //contition 60
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == false && chkphychallanged.Checked == true)
                {
                    //contition 61
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and   Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and   Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and   Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and   Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == false)
                {
                    //contition 62
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else if (cmbStudentStatus.SelectedIndex != 0 && chkClassWise.Checked == true && chkSection.Checked == true && Chkreligion.Checked == true && Chkcategory.Checked == true && chkphychallanged.Checked == true)
                {
                    //contition 63
                    if (Chkgender.Checked == false && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[RTE]='Yes' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                   else if (Chkgender.Checked == true  &&chkRTE.Checked==false)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else if (Chkgender.Checked == true && chkRTE.Checked == true)
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "Gender='" + cmbgender.SelectedItem.ToString() + "' and  [RTE]='Yes' and [Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                    else
                    {
                        dataGridView1.DataSource = dtStudentDetail = Connection.GetDataTable("sp_AllStudent '" + cmbSession.SelectedValue + "'");
                        DataView dv = dtStudentDetail.DefaultView;
                        dv.RowFilter = "[Physically Challanged]='Yes' and  Status='" + cmbStudentStatus.SelectedItem.ToString() + "' and ClassCode=" + cmbClass.SelectedValue + " and  SectionCode='" + cmbSection.SelectedValue + "' and  Religion='" + strCmbReligion.SelectedItem.ToString() + "' and  Category='" + strstdcategory.SelectedItem.ToString() + "'";
                        dv.Sort = "Name";
                        dataGridView1.DataSource= (DataTable)dv.ToTable();
                    }
                }
                else
                { 
                
                }
                tdt = (DataTable)dataGridView1.DataSource;
                DataView tdv = tdt.DefaultView;
                if (chkAdhar.Checked == true)
                {
                    tdv.RowFilter = "AdharNo is null or AdharNo=''";
                }
                tdv.Sort = "Name";
                dataGridView1.DataSource = (DataTable)tdv.ToTable();
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                        break;
                    }
            }
            catch (Exception ex) { throw ex; }

        }
        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFilterRecord();
        }

        private void strCmbReligion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFilterRecord();
        }

        private void strstdcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFilterRecord();
        }
        private void chkphychallanged_CheckedChanged(object sender, EventArgs e)
        {
            GetFilterRecord();
        }
        private void Chkreligion_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkreligion.Checked)
            {
                strCmbReligion.Enabled = true;
                strCmbReligion.Focus();
                GetFilterRecord();
            }
            else
            {
                strCmbReligion.Enabled = false;
                GetFilterRecord();
            }
        }

        private void Chkcategory_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkcategory.Checked)
            {
                strstdcategory.Enabled = true;
                strstdcategory.Focus();
                GetFilterRecord();
            }
            else
            {
                strstdcategory.Enabled = false;
                GetFilterRecord();
            }
        }

        private void frmclasswisestudent_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void Chkgender_CheckedChanged(object sender, EventArgs e)
        {
            if (Chkgender.Checked)
            {
                cmbgender.Enabled = true;
                cmbgender.Focus();
                GetFilterRecord();
            }
            else
            {
                cmbgender.Enabled = false;
                GetFilterRecord();
            }
        }

        private void cmbgender_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetFilterRecord();
        }

        private void chkRTE_CheckedChanged(object sender, EventArgs e)
        {
            GetFilterRecord();
        }

        private void chkAdhar_CheckedChanged(object sender, EventArgs e)
        {
            GetFilterRecord();
        }

       
   
    }
}


