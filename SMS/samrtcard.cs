using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class samrtcard :UserControlBase
    {
        public samrtcard()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void samrtcard_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbClass, "Select ClassCode, ClassName from tbl_classmaster Order By ClassCode");
            cmbExam.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void cmbClass_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClass.Text))
            {
                DataTable dt = new DataTable();

                Connection.FillComboBox(cmbSection, "SELECT  tbl_section.sectioncode, tbl_section.sectionname  FROM tbl_class INNER JOIN tbl_classmaster ON tbl_class.classcode = tbl_classmaster.classcode INNER JOIN tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode where tbl_Classmaster.classcode='" + cmbClass.SelectedValue + "' ");

                DataSet ds = Connection.GetDataSet(" SELECT CONVERT(bit, 0) AS [Select], tbl_student.StudentNo,tbl_student.scholarno AS [Scholar No.], tbl_student.name AS Name, tbl_student.father AS Father,  " +
                  "  tbl_student.mother AS Mother, tbl_student.phone AS [Contact No.], tbl_classmaster.classname + '-' + tbl_section.sectionname AS Class,   " +
                  "  tbl_sankay.sankayname AS Stream, tbl_student.dob AS [Date of Birth], tbl_student.bloodgroup AS [Blood Group], tbl_student.C_address AS Address,   " +
                  "  tbl_student.barcodeimage AS Barcode, tbl_student.studentimage AS Photo, tbl_school.schoolname, tbl_school.schooladdress, tbl_school.schoolcity,   " +
                  "  tbl_school.schoolphone, tbl_school.affiliate_by, tbl_school.principal, tbl_school.registrationno, tbl_school.logoimage, tbl_school.Website, tbl_school.logoimage AS Watermark,   " +
                  "  tbl_school.SchoolCode,tbl_school.HOESIGN,tbl_school.PRINSIGN FROM tbl_student INNER JOIN   " +
                  "  tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno INNER JOIN  " +
                  "  tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  " +
                  "  tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN  " +
                  "  tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN  " +
                  "  tbl_session ON tbl_classstudent.sessioncode = tbl_session.sessioncode CROSS JOIN  tbl_school  " +
                  "  WHERE (tbl_classstudent.stdtype IN ('Studying Student', 'New Student')) AND  (tbl_session.sessioncode = '" + school.CurrentSessionCode + "') AND " +
                  "  (tbl_classmaster.classcode = '" + cmbClass.SelectedValue + "') ");
                if (ds.Tables[0].Rows.Count > 0)
                    dataGridView1.DataSource = ds.Tables[0];
                chkSelectAll.Checked = false;
            }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns["Select"].HeaderText = "";
            dataGridView1.Columns["Select"].Width = 40;
            dataGridView1.Columns["Scholar No."].Width = 70;
            dataGridView1.Columns["Name"].Width = 120;
            dataGridView1.Columns["Father"].Width = 120;
            dataGridView1.Columns["Mother"].Width = 120;
            dataGridView1.Columns["Contact No."].Width = 80;
            dataGridView1.Columns["Class"].Width = 50;
            dataGridView1.Columns["Stream"].Width = 80;
            dataGridView1.Columns["Blood Group"].Width = 60;
            dataGridView1.Columns["Date of Birth"].Width = 70;
            dataGridView1.Columns["StudentNo"].Visible = false;
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                if (c.Index > 12)
                    c.Visible = false;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
                r.Cells["Select"].Value = chkSelectAll.Checked;
        }

        private void cmbSection_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClass.Text) && !string.IsNullOrEmpty(cmbSection.Text))
            {
                DataSet ds = Connection.GetDataSet(" SELECT CONVERT(bit, 0) AS [Select], tbl_student.StudentNo,tbl_student.scholarno AS [Scholar No.], tbl_student.name AS Name, tbl_student.father AS Father,  " +
                    "  tbl_student.mother AS Mother, tbl_student.phone AS [Contact No.], tbl_classmaster.classname + '-' + tbl_section.sectionname AS Class,   " +
                    "  tbl_sankay.sankayname AS Stream, tbl_student.dob AS [Date of Birth], tbl_student.bloodgroup AS [Blood Group], tbl_student.P_address AS Address,   " +
                    "  tbl_student.barcodeimage AS Barcode, tbl_student.studentimage AS Photo, tbl_school.schoolname, tbl_school.schooladdress, tbl_school.schoolcity,   " +
                    "  tbl_school.schoolphone, tbl_school.affiliate_by, tbl_school.principal, tbl_school.registrationno, tbl_school.logoimage, tbl_school.Website, tbl_school.logoimage AS Watermark,   " +
                    "  tbl_school.SchoolCode,tbl_school.HOESIGN,tbl_school.PRINSIGN FROM tbl_student INNER JOIN   " +
                    "  tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno INNER JOIN  " +
                    "  tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  " +
                    "  tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN  " +
                    "  tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN  " +
                    "  tbl_session ON tbl_classstudent.sessioncode = tbl_session.sessioncode CROSS JOIN  tbl_school  " +
                    "  WHERE (tbl_classstudent.stdtype IN ('Studying Student', 'New Student')) AND  (tbl_session.sessioncode = '" + school.CurrentSessionCode + "') AND " +
                    "  (tbl_classmaster.classcode = '" + cmbClass.SelectedValue + "') And (tbl_section.sectioncode = '" + cmbSection.SelectedValue + "' )");
                if (ds.Tables[0].Rows.Count > 0)
                    dataGridView1.DataSource = ds.Tables[0];
                chkSelectAll.Checked = false;
            }
        }
        byte[] TData = null;
        private void btnBarcode_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtStudent = Connection.GetDataTableFromDataGridViewDefaultDataType(dataGridView1);
                DataRow[] r = dtStudent.Select("Select='True'", "Name");
                if (r.Length > 0)
                {
                    if (string.IsNullOrEmpty(dtStudent.Rows[0]["logoimage"].ToString()))
                    {
                        DataSet dsi = new DataSet();
                        dsi = Connection.JGetDefaultImage();

                        if (dsi.Tables[0].Rows.Count > 0)
                        {
                            TData = (byte[])(dsi.Tables[0].Rows[0]["Image"]);
                            //byte[] ByteImage = (byte[])dtStudent.Rows[0]["logoimage"];
                            Bitmap bmp = Connection.GetImageFromByteArray(TData);
                            bmp = Connection.AdjustContrastOfImage(bmp, 80f);
                            byte[] ByteImage1 = Connection.GetByteArrayFromImage(bmp);
                            dtStudent = r.CopyToDataTable();
                            dtStudent.TableName = "Student Details";
                            dtStudent.Rows[0]["Watermark"] = Connection.GetByteArrayFromImage(bmp);
                        }
                    }
                    else
                    {
                        byte[] ByteImage = (byte[])dtStudent.Rows[0]["logoimage"];
                        Bitmap bmp = Connection.GetImageFromByteArray(ByteImage);
                        bmp = Connection.AdjustContrastOfImage(bmp, 80f);
                        byte[] ByteImage1 = Connection.GetByteArrayFromImage(bmp);
                        dtStudent = r.CopyToDataTable();
                        dtStudent.TableName = "Student Details";
                        dtStudent.Rows[0]["Watermark"] = Connection.GetByteArrayFromImage(bmp);
                    }

                    dtStudent.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\SmartCard.xsd");
                    rptStudentSmartCardWithBarcode fr = new rptStudentSmartCardWithBarcode();
                    fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    fr.SetDataSource(dtStudent);
                    ShowAllReports s = new ShowAllReports();
                    s.Text = "Smart/Identity Card";
                    s.crystalReportViewer1.ReportSource = fr;
                    s.Show();
                }
                else
                {
                    MessageBox.Show("Please Select Student...");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Some error occurred while performing this operation. Please try again or contact your vendor if error persists.");
                Logger.LogError(ex);
            }
        }

        private void btnNormarl_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtStudent = Connection.GetDataTableFromDataGridViewDefaultDataType(dataGridView1);
                if (dtStudent != null)
                {
                    DataRow[] r = dtStudent.Copy().Select("Select='True'", "Name");
                    if (r != null && r.Length > 0)
                    {
                        if (string.IsNullOrEmpty(dtStudent.Rows[0]["logoimage"].ToString()))
                        {
                            DataSet dsi = new DataSet();
                            dsi = Connection.JGetDefaultImage();

                            if (dsi.Tables[0].Rows.Count > 0)
                            {
                                TData = (byte[])(dsi.Tables[0].Rows[0]["Image"]);
                                //byte[] ByteImage = (byte[])dtStudent.Rows[0]["logoimage"];
                                Bitmap bmp = Connection.GetImageFromByteArray(TData);
                                bmp = Connection.AdjustContrastOfImage(bmp, 80f);
                                byte[] ByteImage1 = Connection.GetByteArrayFromImage(bmp);
                                dtStudent = r.CopyToDataTable();
                                dtStudent.TableName = "Student Details";
                                dtStudent.Rows[0]["Watermark"] = Connection.GetByteArrayFromImage(bmp);
                            }
                        }
                        else
                        {
                            byte[] ByteImage = (byte[])dtStudent.Rows[0]["logoimage"];
                            Bitmap bmp = Connection.GetImageFromByteArray(ByteImage);
                            bmp = Connection.AdjustContrastOfImage(bmp, 80f);
                            byte[] ByteImage1 = Connection.GetByteArrayFromImage(bmp);
                            dtStudent = r.CopyToDataTable();
                            dtStudent.TableName = "Student Details";
                            dtStudent.Rows[0]["Watermark"] = Connection.GetByteArrayFromImage(bmp);
                        }
                        dtStudent.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\SmartCard.xsd");
                        rptStudentSmartCardWithoutBarcode fr = new rptStudentSmartCardWithoutBarcode();
                        fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                        fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                        fr.SetDataSource(dtStudent);
                        ShowAllReports s = new ShowAllReports();
                        s.Text = "Smart/Identity Card";

                        fr.SetParameterValue("Title", "IDENTITY CARD");
                        fr.SetParameterValue("ICStatus", true);
                        fr.DataDefinition.FormulaFields["RollNo"].Text = "'0'";
                        s.crystalReportViewer1.ReportSource = fr;
                        s.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please Select Student...");
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Student...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occurred while performing this operation. Please try again or contact your vendor if error persists.");
                Logger.LogError(ex);
            }
        }

        private void btnAdminCard_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtStudent = Connection.GetDataTableFromDataGridViewDefaultDataType(dataGridView1);
                DataRow[] r = dtStudent.Copy().Select("Select='True'", "Name");
                if (r.Length > 0)
                {
                    if (string.IsNullOrEmpty(dtStudent.Rows[0]["logoimage"].ToString()))
                    {
                        DataSet dsi = new DataSet();
                        dsi = Connection.JGetDefaultImage();

                        if (dsi.Tables[0].Rows.Count > 0)
                        {
                            TData = (byte[])(dsi.Tables[0].Rows[0]["Image"]);
                            //byte[] ByteImage = (byte[])dtStudent.Rows[0]["logoimage"];
                            Bitmap bmp = Connection.GetImageFromByteArray(TData);
                            bmp = Connection.AdjustContrastOfImage(bmp, 80f);
                            byte[] ByteImage1 = Connection.GetByteArrayFromImage(bmp);
                            dtStudent = r.CopyToDataTable();
                            dtStudent.TableName = "Student Details";
                            dtStudent.Rows[0]["Watermark"] = Connection.GetByteArrayFromImage(bmp);
                        }
                    }
                    else
                    {
                        byte[] ByteImage = (byte[])dtStudent.Rows[0]["logoimage"];
                        Bitmap bmp = Connection.GetImageFromByteArray(ByteImage);
                        bmp = Connection.AdjustContrastOfImage(bmp, 80f);
                        byte[] ByteImage1 = Connection.GetByteArrayFromImage(bmp);
                        dtStudent = r.CopyToDataTable();
                        dtStudent.TableName = "Student Details";
                        dtStudent.Rows[0]["Watermark"] = null;
                    }

                    dtStudent.Columns.Add("RollNo", typeof(string));
                    foreach (DataRow Row in dtStudent.Rows)
                    {
                        object obj = Connection.GetExecuteScalar("Select RollNo From tbl_StudentAttendance Where " +
                            " SessionCode='" + school.CurrentSessionCode + "' And ClassNo='" + cmbClass.SelectedValue + "' " +
                            " And StudentNo='" + Row["StudentNo"] + "'");
                        Row["RollNo"] = (obj != null) ? obj : "0";
                    }

                    dtStudent.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\SmartCard.xsd");
                    rptStudentSmartCardWithoutBarcode fr = new rptStudentSmartCardWithoutBarcode();
                    fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    fr.SetDataSource(dtStudent);
                    ShowAllReports s = new ShowAllReports();
                    s.Text = "Smart/Identity Card";
                    s.crystalReportViewer1.ReportSource = fr;

                    string ex = string.Empty;
                    ex = "ADMIT CARD [ " + cmbExam.Text.ToString() + " ]";
                    fr.SetParameterValue("Title", ex);
                    fr.SetParameterValue("ICStatus", false);
                    //dtStudent.Dispose();
                    s.Show();
                }
                else
                {
                    MessageBox.Show("Please Select Student...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occurred while performing this operation. Please try again or contact your vendor if error persists.");
                Logger.LogError(ex);
            }
        }

        private void samrtcard_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }



    }
}
