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
    public partial class frmDueFee :UserControlBase
    {
        DataTable dtTotalFee = new DataTable();
        DataTable dtPaidFee = new DataTable();
        DataTable dtAllFeeType = new DataTable();
        bool tisrte = false;
        school1 c = new school1();
        public  frmDueFee()
        {
            InitializeComponent(); //   DesignForm.fromDesign1(this);
            Connection.SetUserControlTheme(this);
        }

        private void frmclasswisefeedue_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbSession, " select sessioncode,sessionname from tbl_session order by sessioncode ");
            Connection.FillComboBox(cmbClass, " select classcode,classname from tbl_classmaster order by classcode ");
            cmbSession.SelectedValue = school.CurrentSessionCode;
            cmbStudentStatus.SelectedIndex = 0;

            this.cmbSession.SelectedIndexChanged += new System.EventHandler(this.cmbSession_SelectedIndexChanged);
            c.GetMdiParent(this).TogglePrintButton(true);
            LoadStudentFeeDetail();
        } 

        private void btnExit_Click(object sender, EventArgs e)
        {

            //this.Close();
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (ChkIdDueGreater.Checked)
                {
                    if (chkClassWise.Checked == true && chkSection.Checked == false)
                    {
                        DataView dv = dtTotalFee.DefaultView;
                        dv.RowFilter = "ClassNo='" + cmbClass.SelectedValue + "' And SessionCode='" + cmbSession.SelectedValue + "' and [Due Fee]>0";
                        dv.Sort = "Name";
                        dataGridView1.DataSource = dv;
                    }
                    else if (chkClassWise.Checked ==true && chkSection.Checked == true)
                    {
                        DataView dv = dtTotalFee.DefaultView;
                        dv.RowFilter = "ClassNo='" + cmbClass.SelectedValue + "' And SessionCode='" + cmbSession.SelectedValue + "' And SectionNo='" + cmbSection.SelectedValue + "' and [Due Fee]>0";
                        dv.Sort = "Name";
                        dataGridView1.DataSource = dv;
                    }
                    else
                    {
                        DataView dv = dtTotalFee.DefaultView;
                        dv.RowFilter = "[Due Fee]>0";
                        dv.Sort = "Name";
                        dataGridView1.DataSource = dv;
                    }
                }
                DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school");
                ds.Tables.Add(Connection.GetDataTableFromDataGridView(dataGridView1));
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\DueFee.xsd");
                rptDueFee fr1 = new rptDueFee();
                fr1.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                fr1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                fr1.SetDataSource(ds);
                ShowAllReports s1 = new ShowAllReports();
                s1.crystalReportViewer1.ReportSource = fr1;
                fr1.SetParameterValue("Session", cmbSession.Text);
                if (chkClassWise.Checked && !chkClassWise.Checked)
                    fr1.SetParameterValue("ReportTitle", cmbStudentStatus.Text + " Due Fee Detail For Class - " + cmbClass.Text.Trim());
                else if (chkClassWise.Checked && chkSection .Checked)
                    fr1.SetParameterValue("ReportTitle", cmbStudentStatus.Text + " Due Fee Detail For Class - " + cmbClass.Text.Trim() + " " + cmbSection.Text.Trim());
                else
                    fr1.SetParameterValue("ReportTitle", cmbStudentStatus.Text + " Due Fee Detail");
                s1.Show();
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSection, " SELECT tbl_section.sectioncode, tbl_section.sectionname FROM " +
                 " tbl_classstudent INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode " +
                 " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') And  (tbl_classstudent.sessioncode = " +
                 " '" + cmbSession .SelectedValue + "') GROUP BY tbl_section.sectioncode, tbl_section.sectionname " +
                 " Order by tbl_section.sectioncode");
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
        static bool tsch = false; static decimal schamt = 0;
        private void cmbSession_Leave(object sender, EventArgs e)
        {
        }

        private void LoadStudentFeeDetail()
        {
            try
            {
                dtTotalFee = Connection.GetDataTable(" SELECT tbl_classstudent.sessioncode as 'SessionCode',tbl_student.IsScholarship, tbl_student.studentno AS 'Student No.', tbl_student.scholarno AS 'Scholar No.', tbl_student.name AS 'Name', tbl_student.father AS 'Fathers Name' " +
                 " ,tbl_classmaster.classname + '-' + tbl_section.sectionname AS Class,tbl_student.phone, LTRIM(RTRIM(tbl_classstudent.stdtype)) AS 'Status', 0.00 AS [Fee Amount],(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopFee, 0) Else 0 End) AS [Bus Fee] " +
                 " , 0.00 AS 'Total Fee', 0.00 AS 'Paid Fee', 0.00 AS 'Late Fee', 0.00 AS 'Consession Fee', 0.00 AS 'Due Fee', tbl_classstudent.classno AS ClassNo, tbl_classstudent.Section AS SectionNo,tbl_classstudent.stream,tbl_student.IsRTE as RTE  FROM tbl_classstudent INNER JOIN tbl_student ON " +
                 "  tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN tbl_section ON tbl_classstudent.Section = " +
                 "  tbl_section.sectioncode LEFT OUTER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo WHERE (tbl_classstudent.stdtype IN ('Studying Student', 'New Student')) AND tbl_classstudent.SessionCode = '" + cmbSession.SelectedValue + "'" +
                 "  GROUP BY tbl_classstudent.sessioncode, tbl_student.studentno, tbl_student.scholarno, tbl_student.name, tbl_student.father, tbl_classstudent.stdtype, tbl_StopDetails.StopFee,tbl_classstudent.classno " +
                 " , tbl_classstudent.Section, tbl_classmaster.classname, tbl_section.sectionname,tbl_student.phone,tbl_classstudent.stream,tbl_student.busfacility,tbl_student.IsRTE,tbl_student.IsScholarship ORDER BY 'Student No.' ");

                dtPaidFee = Connection.GetDataTable(" SELECT fm.sessioncode AS SessionCode,fm.studentno AS [Student No.],SUM(fm.totfeeamt) AS [Paid Fee],SUM(fm.consession) AS [Conses Fee],SUM(fm.latefee) AS [Late Fee],cs.stream FROM tbl_FeeMaster fm inner join tbl_classstudent cs on cs.studentno=fm.studentno and fm.sessioncode=cs.sessioncode  GROUP BY fm.sessioncode, fm.studentno,cs.stream");

                dtAllFeeType = Connection.GetDataTable(" SELECT tbl_classfeeregular.sessioncode AS SessionCode, tbl_classfeeregular.classno AS ClassNo, ISNULL(SUM(tbl_classfeeregular.feeamt), 0) AS [Total Fee],tbl_feeheads.feetype as [FeeType] ,tbl_classfeeregular.stream,tbl_classfeeregular.RTE" +
                "  FROM tbl_classfeeregular INNER JOIN tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode WHERE (tbl_classfeeregular.sessioncode = '" + cmbSession.SelectedValue + "') " +
                "  GROUP BY tbl_classfeeregular.sessioncode, tbl_classfeeregular.classno, tbl_classfeeregular.feeamt, tbl_feeheads.feetype,tbl_classfeeregular.stream,tbl_classfeeregular.RTE ");

                for (int i = 0; i < dtTotalFee.Rows.Count; i++)
                {
                    decimal tdc = 0, tdl = 0;
                    object Obj = dtPaidFee.Compute("Sum([Paid Fee])", " SessionCode='" + cmbSession.SelectedValue + "' And  [Student No.]='" + dtTotalFee.Rows[i]["Student No."] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "' ");
                    object Objc = dtPaidFee.Compute("Sum([Conses Fee])", " SessionCode='" + cmbSession.SelectedValue + "' And  [Student No.]='" + dtTotalFee.Rows[i]["Student No."] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                    object Objl = dtPaidFee.Compute("Sum([Late Fee])", " SessionCode='" + cmbSession.SelectedValue + "' And  [Student No.]='" + dtTotalFee.Rows[i]["Student No."] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                    tdc = (Objc != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Objc), 2) : Convert.ToDecimal(0.00);
                    tdl = (Objl != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Objl), 2) : Convert.ToDecimal(0.00);
                    dtTotalFee.Rows[i]["Paid Fee"] = (Obj != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Obj), 2) : Convert.ToDecimal(0.00);
                    // if ( dtTotalFee.Rows[i]["Student No."].ToString().Equals("1109"))
                    tisrte = Convert.ToBoolean(dtTotalFee.Rows[i]["RTE"]);
                    string tstr = string.Empty;
                    //-For Scholarship amount .
                    if (string.IsNullOrEmpty(dtTotalFee.Rows[i]["IsScholarship"].ToString()))
                        tsch = false;
                    else
                        tsch = Convert.ToBoolean(dtTotalFee.Rows[i]["IsScholarship"]);
                    if (tsch)
                    {
                        tstr = Convert.ToString(Connection.GetExecuteScalar("select schamount from tbl_classstudent where sessioncode='" + school.CurrentSessionCode + "' and studentno='" + dtTotalFee.Rows[i]["Student No."] + "'"));
                        if (string.IsNullOrEmpty(tstr))
                        {
                            schamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetSchAmountByCat('" + cmbSession.SelectedValue + "','" + dtTotalFee.Rows[i]["Student No."] + "')"));
                        }
                        else
                        {
                            schamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetSchAmount('" + cmbSession.SelectedValue + "','" + dtTotalFee.Rows[i]["Student No."] + "')"));

                        }
                    }
                    else
                    {
                        //--write some code here.
                        schamt = 0;
                    }
                    //--end scholar ship amount
                    if (dtTotalFee.Rows[i]["Status"].ToString().Equals("Studying Student"))
                    {
                        if (tisrte)
                            Obj = dtAllFeeType.Compute("Sum([Total Fee])", "[FeeType]='1' and RTE='True' And SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                        else
                            Obj = dtAllFeeType.Compute("Sum([Total Fee])", "[FeeType]='1' And SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");

                        dtTotalFee.Rows[i]["Fee Amount"] = (Obj != DBNull.Value) ? Obj : Convert.ToDecimal(0.00);
                        dtTotalFee.Rows[i]["Total Fee"] = Math.Round((Convert.ToDecimal(dtTotalFee.Rows[i]["Fee Amount"]) + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])), 2);
                        dtTotalFee.Rows[i]["Due Fee"] = Math.Round(((Convert.ToDecimal(dtTotalFee.Rows[i]["Total Fee"]) - schamt) - (Convert.ToDecimal(dtTotalFee.Rows[i]["Paid Fee"]) + tdc)), 2);
                        dtTotalFee.Rows[i]["Consession Fee"] = Math.Round(tdc, 2);
                        dtTotalFee.Rows[i]["Late Fee"] = Math.Round(tdl, 2);
                    }
                    else if (dtTotalFee.Rows[i]["Status"].ToString().Equals("New Student"))
                    {
                        if (tisrte)
                            Obj = dtAllFeeType.Compute("Sum([Total Fee])", " RTE='True' and SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                        else
                            Obj = dtAllFeeType.Compute("Sum([Total Fee])", "SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                        dtTotalFee.Rows[i]["Fee Amount"] = (Obj != DBNull.Value) ? Obj : Convert.ToDecimal(0.00);
                        dtTotalFee.Rows[i]["Total Fee"] = Math.Round((Convert.ToDecimal(dtTotalFee.Rows[i]["Fee Amount"]) + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])), 2);
                        dtTotalFee.Rows[i]["Due Fee"] = Math.Round(((Convert.ToDecimal(dtTotalFee.Rows[i]["Total Fee"]) - schamt) - (Convert.ToDecimal(dtTotalFee.Rows[i]["Paid Fee"]) + tdc)), 2);
                        dtTotalFee.Rows[i]["Consession Fee"] = Math.Round(tdc, 2);
                        dtTotalFee.Rows[i]["Late Fee"] = Math.Round(tdl, 2);
                    }
                }

                dataGridView1.DataSource = dtTotalFee;
            }
            catch (Exception ex) { Logger.LogError(ex); }

        }
        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        private void chkClassWise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClassWise.Checked)
            {
                cmbClass.Enabled = true;
                chkSection.Enabled = true;
                cmbClass.Focus();
            }
            else
            {
                cmbClass.Enabled = false;
                cmbSection.Enabled = false;
                chkSection.Checked = false;
                chkSection.Enabled = false;
                if (dtTotalFee != null)
                {
                    DataView dv = dtTotalFee.DefaultView;
                    dv.RowFilter = GetFilter();
                    dataGridView1.DataSource = dv;
                }
            }
        }

        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection .Checked)
            {
                cmbSection .Enabled = true;
                cmbSection.Focus();
            }
            else
            {
                cmbSection.Enabled = false;
                if (dtTotalFee != null)
                {
                    DataView dv = dtTotalFee.DefaultView;
                    dv.RowFilter = GetFilter();
                    dv.Sort = "Name";
                    dataGridView1.DataSource = dv;
                }
            }
        }

        private void cmbClass_Leave(object sender, EventArgs e)
        {
            if (chkClassWise.Checked)
            {
                if (dtTotalFee != null)
                {
                    DataView dv = dtTotalFee.DefaultView;

                    dv.RowFilter = GetFilter();
                    dv.Sort = "Name";
                    dataGridView1.DataSource = dv;
                }
            } 
        }

        private void cmbSection_Leave(object sender, EventArgs e)
        {
            if (chkClassWise.Checked == chkSection.Checked==true)
            {
                if (dtTotalFee != null)
                {
                    DataView dv = dtTotalFee.DefaultView;
                    
                    dv.RowFilter = GetFilter();
                    dv.Sort = "Name";
                    dataGridView1.DataSource = dv;
                }
            }
        }

        private string GetFilter()
        {
            string filter = "SessionCode='" + cmbSession.SelectedValue + "'";
            if (chkSection.Checked)
                filter += " And SectionNo='" + cmbSection.SelectedValue + "'";

            if (chkClassWise.Checked)
                filter += " And ClassNo='" + cmbClass.SelectedValue + "'";

            if (cmbStudentStatus.SelectedIndex > 0)
                filter += " And Status='" + cmbStudentStatus.Text.Trim() + "'";
                   

            return filter;
        }
        private void cmbStudentStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dtTotalFee != null)
                {
                    DataView dv = dtTotalFee.DefaultView;
                    dv.RowFilter = GetFilter();
                    dv.Sort = "Name";
                    dataGridView1.DataSource = dv;
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void cmbSession_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void chkClassWise_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void cmbClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void chkSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void cmbSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void cmbStudentStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.Columns["SessionCode"].Visible = false;
                dataGridView1.Columns["Student No."].Visible = false;
                dataGridView1.Columns["Fee Amount"].Visible = false;
                dataGridView1.Columns["Bus Fee"].Visible = false;
                dataGridView1.Columns["SectionNo"].Visible = false;
                dataGridView1.Columns["ClassNo"].Visible = false;
                dataGridView1.Columns["IsScholarship"].Visible = false;
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(r.Cells["RTE"].Value))
                    {
                        r.DefaultCellStyle.ForeColor = Color.BlueViolet;

                    }

                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void frmDueFee_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentFeeDetail();
        }

       

 
    }
}
