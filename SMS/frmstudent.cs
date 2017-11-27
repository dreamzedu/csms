using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class frmstudent :UserControlBase
    {
        string sectionNo;
        school1 c = new school1();
        Boolean add_edit = false;
        Boolean MessageService = false;
        string board;
        int nk;
        int gk;
        string classno;
        int classno1;
        int studentno;
        int j = 0;
        string status, tcflag = "N";
        private string PicturePath;
        private string PicturePath1;
        int classno2, sessioncode;

        public frmstudent()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
            Connection.SetUserControlTheme(this);
        }


        private void frmstudent_Load(object sender, EventArgs e)
        {
            try
            {
                //16-Aug By Gtl  strCmbReligion
                c.getconnstr();
                Connection.FillDropList(ref valcmbsession, " SELECT SessionName, SessionCode  FROM tbl_session Order By SessionCode");
                valcmbsession.SelectedValue = school.CurrentSessionCode;
                Connection.FillCombo(ref strCmbReligion, "select distinct Religion from tbl_student Where Datalength(Religion)>0 Order By Religion");
                Connection.FillCombo(ref strCmdSubCast, "select distinct SubCast from tbl_student Where Datalength(SubCast)>0  Order By SubCast");
                Connection.FillCombo(ref strCmbCast, "select distinct Cast from tbl_student Where Datalength(Cast)>0 Order By Cast");
                c.FillcomboBox("select distinct bcode from dbo.tbl_student where Datalength(bcode)>0  order by bcode", "bcode","bcode", ref strBCode);
                //30-March By Gtl Message Service Active/Deactive
                this.MessageService = Convert.ToBoolean(Connection.GetExecuteScalar("Select MessageService From tbl_School"));

                //Connection.FillCombo(ref valcmbsession, "select sessionname from tbl_session");
                DataSet ds545 = Connection.GetDataSet("Select Count(*) from tbl_student");
                int k = Convert.ToInt32(ds545.Tables[0].Rows[0][0]);
                if (k > 0)
                {
                    DataSet dstt = Connection.GetDataSet("Select Max(studentno) from tbl_student ");
                    if (dstt.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsty = Connection.GetDataSet("Select ScholarNo,name from tbl_student where studentno='" + dstt.Tables[0].Rows[0][0].ToString() + "'");
                        txtScholarNo.Text = dsty.Tables[0].Rows[0].ItemArray[0].ToString();
                        txtStudentName.Text = dsty.Tables[0].Rows[0].ItemArray[1].ToString();
                    }
                }
                button9.Visible = false;
                //DesignForm.fromDesign1(this);                
                txtbarnum.Visible = false;
                label19.Visible = false;
                valCmbBusStop.Visible = false;
                txtstudentno.Visible = false;
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                c.getconnstr();
                
                int cl = Connection.Login("Select Count(*) from tbl_classmaster ");
                if (cl == 0)
                {
                    //chield();
                    //   //this.Close();
                    frmclasssetup clsform = new frmclasssetup();
                    dateTimePicker1.Text = "01/01/1900";
                    Connection.SetUserControlTheme(clsform);

                    MDIParent1 mdi = (MDIParent1)this.FindForm();
                    mdi.ShowUserControl(clsform, "Class Setup");
                }
                else
                {
                    Connection.FillCombo(ref valcmbclass, "select distinct classname from tbl_classmaster");
                    Connection.FillCombo(ref strmtongue, "select distinct m_tongue from tbl_student where Datalength(m_tongue)>0");
                    //c.FillcomboBox("select a.classno,b.classname as class from tbl_class a,tbl_classmaster b,tbl_section c where b.classcode=a.classcode and c.sectioncode=a.sectioncode", "class", "classno", ref valcmbclass );
                    //c.FillcomboBox("select * from tbl_sankay order by sankayname", "sankayName", "sankaycode", ref valcmbfaculty);
                    int cl1 = Connection.Login("Select Count(*) from tbl_classmaster ");
                    if (cl1 == 0)
                    {
                    }
                    else
                    {
                        //c.FillcomboBox("select * from tbl_session order by sessioncode", "sessionName", "Sessioncode", ref valcmbsession);
                        c.FillcomboBox("select * from tbl_tehsil order by tehsil", "tehsil", "tehcode", ref valcmbtehsil);
                        c.FillcomboBox("select * from tbl_district order by district", "district", "distcode", ref valcmbdistrict);
                        c.FillcomboBox("select * from tbl_stopdetails order by stopname", "StopName", "BusStopNo", ref valCmbBusStop);
                        strbloodgroup.SelectedIndex = 0;
                        valcmbdistrict.SelectedIndex = 0;

                        //  valcmbsession.SelectedIndex = 0;
                        //     valcmbtehsil.SelectedIndex = 0;
                        // cmbmaritalstatus.SelectedIndex = 1;
                        strstdcategory.SelectedIndex = 0;
                        button5.Visible = false;
                        groupBox1.Visible = false;
                        strcmbfaculty.Visible = false;
                        label43.Visible = false;
                        lstCompalsary.Visible = false;
                        checkedListBox1.Visible = false;
                        Mandetory.Visible = false;
                        lblElective.Visible = false;
                        board = Connection.boardofstudey();
                        if (board == "BOTH")
                        {
                            groupBox1.Visible = true;

                        }
                        else
                        {

                            valcmbclass.Visible = true;
                            label45.Visible = true;
                        }

                    }
                }
                
            }
            catch (Exception ex) { Logger.LogError(ex); throw ex; }
            DataSet ds = Connection.GetDataSet("SELECT     classname, classcode FROM         tbl_classmaster order by ClassOrder");
            cmbClassName.DataSource = ds.Tables[0];
            cmbClassName.DisplayMember = ds.Tables[0].Columns["classname"].ToString();
            cmbClassName.ValueMember = ds.Tables[0].Columns["classcode"].ToString();
            strcmbAPPType.SelectedIndex = 0;
            DesignForm.fromDesign1(this);
            Connection.SetUserLevelAuth(c.GetMdiParent(this));
            c.GetMdiParent(this).EnableAllEditMenuButtons();
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            pbxBarCode.Visible = false;
            tabControl1.SelectedIndex = 0;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            

            DesignForm.fromDesign1(this);
            valcmbsession.Enabled = false;
            Connection.SetUserLevelAuth(c.GetMdiParent(this));
        }

        private void txtscholarno_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }
        public override void btnedit_Click(object sender, EventArgs e)
        {
            button9.Visible = true;
            pbxBarCode.Visible = false;
            tabControl1.SelectedIndex = 0;
            member_pic.Image = null;
            DesignForm.fromDesign2(this);
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            txtScholarNo.Focus();
            c.GetMdiParent(this).ToggleDeleteButton(true);
            valcmbsession.Enabled = false;
        }
        private void chkphychallanged_CheckedChanged(object sender, EventArgs e)
        {
            if (chkphychallanged.Checked == true)
            {
                chkphychallanged.Text = "Yes";
            }
            else
            {
                chkphychallanged.Text = "No";
            }
        }
        private void chkgapcirti_CheckedChanged(object sender, EventArgs e)
        {
            if (chkgapcirti.Checked == true)
            {
                chkgapcirti.Text = "Yes";
            }
            else
            {
                chkgapcirti.Text = "No";
            }
        }
        private void chkwanthostelfaci_CheckedChanged(object sender, EventArgs e)
        {
            if (chkwanthostelfaci.Checked == true)
            {
                chkwanthostelfaci.Text = "Hostelar";
            }
            else
            {
                chkwanthostelfaci.Text = "DayScholar";
            }

        }
        private void chkbelongrular_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkbelongrular.Checked == true)
            //{
            //    txtstudentno.Visible = true;
            //    label17.Visible = true;
            //    chkbelongrular.Text = "Yes";
            //}
            //else
            //{
            //    chkbelongrular.Text = "No";
            //    txtstudentno.Visible = false ;
            //    label17.Visible = false ;
            //}

        }
        private void txtobtained_TextChanged(object sender, EventArgs e)
        {

            try
            {
                double per = Convert.ToDouble(txtobtained.Text) * 100 / Convert.ToDouble(txtmarks.Text);
                txtpercantage.Text = per.ToString();
                if (per > 60)
                {
                    txtdivision.Text = "First..";
                    txtresult.Text = "Pass";
                }
                else if (per > 45)
                {
                    txtdivision.Text = "Second...";
                    txtresult.Text = "Pass";
                }
                else if (per > 33)
                {
                    txtdivision.Text = "Third..";
                    txtresult.Text = "Pass";
                }
                else if (per < 33)
                {
                    txtdivision.Text = "Fail..";
                    //groupBox2.Visible = false;
                    txtresult.Text = "fail";
                }
            }
            catch (Exception ex)
            { Logger.LogError(ex); }
        }
        private void txtobtained_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
            e.KeyChar = c.CHECKDECIMAL(e);
        }
        private void txtpercantage_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtpercantage.Text != "")
                {
                    if (Convert.ToInt32(txtpercantage.Text) > 100)
                    {

                        txtpercantage.Text = "";
                        MessageBox.Show("Invalid Percentage..", "School");
                        txtpercantage.Focus();
                    }
                }
            }
            catch (Exception ex)
            { Logger.LogError(ex); }
        }
        private void txtpercantage1_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtpercantage1.Text) > 100)
                {
                    txtpercantage1.Text = "";
                    MessageBox.Show("Invalid Percentage..", "School");
                    txtpercantage1.Focus();
                }
            }
            catch (Exception ex)
            { Logger.LogError(ex); }
        }
        private void txtpercantage2_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtpercantage.Text) > 100)
                {
                    txtpercantage.Text = "";
                    MessageBox.Show("Invalid Percentage..", "School");
                    txtpercantage.Focus();
                }
            }
            catch
            { }
        }
        private void txtpercantage3_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtpercantage3.Text) > 100)
                {
                    txtpercantage3.Text = "";
                    MessageBox.Show("Invalid Percentage..", "School");
                    txtpercantage3.Focus();
                }
            }
            catch
            { }
        }
        private void txtpercantage4_Validated(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtpercantage4.Text) > 100)
                {
                    txtpercantage4.Text = "";
                    MessageBox.Show("Invalid Percentage..", "School");
                    txtpercantage4.Focus();
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
        byte[] TData = null;
        private void txtscholarno_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtScholarNo.Text.Trim()))
            {
                try
                {
                    if (add_edit == true)
                    {
                        c.returnconn(c.myconn);
                        SqlCommand com = new SqlCommand("select studentno from tbl_student where scholarno='" + txtScholarNo.Text + "'", c.myconn);
                        SqlDataReader reader = com.ExecuteReader();
                        if (reader.HasRows)
                        {

                            MessageBox.Show("Scholar No. is Already Exists, Please Check..", "Student");
                            txtScholarNo.Text = "";
                            txtScholarNo.Focus();
                        }
                    }
                    if (add_edit == false)
                    {
                        if (Convert.ToInt16(Connection.GetExecuteScalar("Select Count(*) From tbl_Student Where ScholarNo='" + txtScholarNo.Text.Trim() + "'")) > 0)
                        {
                            tcflag = "N";
                            c.showstudentdata("tbl_student", c.myconn, this, "scholarno", txtScholarNo.Text);
                            //-----------
                            SqlConnection con = Connection.Conn();
                            SqlCommand cmd = new SqlCommand("select * from tbl_StudentDocs where StudentNo='" + txtstudentno.Text.Trim() + "'", con);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            con.Close();


                            if (dt.Rows.Count > 0)
                            {
                                //Get a stored PDF bytes
                                if (!string.IsNullOrEmpty(dt.Rows[0]["TCFile"].ToString()))
                                    TFBdtc = (byte[])dt.Rows[0]["TCFile"];
                                if (!string.IsNullOrEmpty(dt.Rows[0]["SOCFile"].ToString()))
                                    TFBdsoc = (byte[])dt.Rows[0]["SOCFile"];
                                if (!string.IsNullOrEmpty(dt.Rows[0]["SLCFile"].ToString()))
                                    TFBdslc = (byte[])dt.Rows[0]["SLCFile"];
                                if (!string.IsNullOrEmpty(dt.Rows[0]["DOBFile"].ToString()))
                                    TFBddob = (byte[])dt.Rows[0]["DOBFile"];
                                if (!string.IsNullOrEmpty(dt.Rows[0]["MSFile"].ToString()))
                                    TFBdms = (byte[])dt.Rows[0]["MSFile"];
                                if (!string.IsNullOrEmpty(dt.Rows[0]["ICFile"].ToString()))
                                    TFBdic = (byte[])dt.Rows[0]["ICFile"];
                                if (!string.IsNullOrEmpty(dt.Rows[0]["CCFile"].ToString()))
                                    TFBdcc = (byte[])dt.Rows[0]["CCFile"];


                                dtct = dt.Rows[0]["TCType"].ToString();
                                dsoct = dt.Rows[0]["SOCType"].ToString();
                                dslct = dt.Rows[0]["SLCType"].ToString();
                                ddobt = dt.Rows[0]["DOBType"].ToString();
                                dmst = dt.Rows[0]["MSType"].ToString();
                                dict = dt.Rows[0]["ICType"].ToString();
                                dcct = dt.Rows[0]["CCType"].ToString();
                            }
                            //-----------
                            tcflag = "Y";
                            DataTable dtClass = Connection.GetDataTable("SELECT tbl_classmaster.classname, tbl_section.sectionname, tbl_sankay.sankayname FROM tbl_classstudent " +
                                " INNER JOIN   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN   tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode where tbl_classstudent.sessioncode='" + school.CurrentSessionCode + "' and tbl_classstudent.studentno='" + txtstudentno.Text + "' ");

                            if (dtClass.Rows.Count > 0)
                            {
                                valcmbclass.Text = dtClass.Rows[0].ItemArray[0].ToString();
                                strsection.Text = dtClass.Rows[0].ItemArray[1].ToString();
                                strcmbfaculty.Text = dtClass.Rows[0].ItemArray[2].ToString();
                            }
                            else
                            {
                                string Student = Convert.ToString(Connection.GetExecuteScalar("Select ScholarNo+' / '+ Name from tbl_student where scholarno='" + txtScholarNo.Text + "' "));
                                MessageBox.Show(Student + "\n\tStudent record is not available in current session!!!\n\tPlease Check Records. ",
                                    "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                            string StudentNo = Convert.ToString(Connection.GetExecuteScalar("Select studentno from tbl_student where scholarno='" + txtScholarNo.Text + "' "));

                            DataSet ds15 = Connection.GetDataSet("select electivesubject from tbl_stdelectivesub where studentno='" + StudentNo + "'");

                            for (int s = 0; s < ds15.Tables[0].Rows.Count; s++)
                            {
                                string str1;
                                for (int i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
                                {
                                    string str2 = ds15.Tables[0].Rows[s].ItemArray[0].ToString();
                                    if (checkedListBox1.GetItemChecked(i))
                                    {
                                        str1 = checkedListBox1.Items[i].ToString();
                                    }
                                    else
                                    {
                                        str1 = checkedListBox1.Items[i].ToString();
                                        if (str1 == str2)
                                        {

                                            checkedListBox1.SetItemChecked(i, true);

                                        }
                                    }
                                }
                            }
                            #region
                            //try
                            //{
                            //    DataSet ds = Connection.GetDataSet("Select studentimage from tbl_Student where studentno ='" + StudentNo + "'");
                            //    if (string.IsNullOrEmpty(ds.Tables[0].Rows[0][0].ToString()))
                            //    {
                            //       DataSet dsi = new DataSet();
                            //       dsi = Connection.JGetDefaultImage();

                            //       if (dsi.Tables[0].Rows.Count > 0)
                            //        {
                            //            TData = (byte[])(dsi.Tables[0].Rows[0]["Image"]);
                            //            MemoryStream ms = new MemoryStream(TData);
                            //            member_pic.Image = Image.FromStream(ms);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        byte[] reading = (byte[])ds.Tables[0].Rows[0][0];
                            //        MemoryStream ms = new MemoryStream(reading);
                            //        member_pic.Image = Image.FromStream(ms);
                            //    }
                            //}
                            //catch (Exception ex) { Logger.LogError(ex); MessageBox.Show(ex.Message); }

                            //try
                            //{
                            //    DataSet ds66 = Connection.GetDataSet("Select docimage from tbl_Student where studentno ='" + StudentNo + "'");
                            //    if (string.IsNullOrEmpty(ds66.Tables[0].Rows[0][0].ToString()))
                            //    {
                            //        DataSet dsi = new DataSet();
                            //        dsi = Connection.JGetDefaultImage();

                            //        if (dsi.Tables[0].Rows.Count > 0)
                            //        {
                            //            TData = (byte[])(dsi.Tables[0].Rows[0]["Image"]);
                            //            MemoryStream ms = new MemoryStream(TData);
                            //            member_pic.Image = Image.FromStream(ms);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        byte[] reading1 = (byte[])ds66.Tables[0].Rows[0][0];
                            //        MemoryStream ms1 = new MemoryStream(reading1);
                            //        pictureBox2.Image = Image.FromStream(ms1);
                            //    }
                            //}
                            //catch(Exception ex){Logger.LogError(ex); }

                            //try
                            //{
                            //    DataSet dsBarCode = Connection.GetDataSet("Select barcode,barcodeimage from tbl_Student where studentno ='" + StudentNo + "'");
                            //    if (string.IsNullOrEmpty(dsBarCode.Tables[0].Rows[0][1].ToString()))
                            //    {
                            //        DataSet dsi = new DataSet();
                            //        dsi = Connection.JGetDefaultImage();

                            //        if (dsi.Tables[0].Rows.Count > 0)
                            //        {
                            //            TData = (byte[])(dsi.Tables[0].Rows[0]["Image"]);
                            //            MemoryStream ms = new MemoryStream(TData);
                            //            member_pic.Image = Image.FromStream(ms);
                            //        }
                            //    }
                            //    else
                            //    {
                            //        byte[] reading1 = (byte[])dsBarCode.Tables[0].Rows[0][1];
                            //        MemoryStream ms1 = new MemoryStream(reading1);
                            //        pbxBarCode.Image = Image.FromStream(ms1);

                            //        pbxBarCode.Visible = true;
                            //        txtbarnum.Text = dsBarCode.Tables[0].Rows[0]["barcode"].ToString();
                            //    }
                            //}
                            //catch(Exception ex){Logger.LogError(ex); }

                            ////  DataSet ds44 = Connection.GetDataSet("");

                            //DataSet ds2 = Connection.GetDataSet(" SELECT     tbl_subject.subjectname   FROM tbl_subwiseclass INNER JOIN tbl_subject ON tbl_subwiseclass.subjectno = tbl_subject.subjectno INNER JOIN tbl_classstudent ON tbl_subwiseclass.classno = tbl_classstudent.classno INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno   WHERE     (tbl_student.studentno = '" + StudentNo + "') AND (tbl_subwiseclass.subjecttype = 'Core Subject')     ");
                            //if(ds2.Tables[0].Rows.Count >0)
                            //    lstCompalsary.Text = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
                            //DataSet ds3 = Connection.GetDataSet(" SELECT     tbl_subject.subjectname FROM tbl_subwiseclass INNER JOIN tbl_subject ON tbl_subwiseclass.subjectno = tbl_subject.subjectno INNER JOIN tbl_classstudent ON tbl_subwiseclass.classno = tbl_classstudent.classno INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno   WHERE     (tbl_student.studentno = '" + StudentNo + "') AND (tbl_subwiseclass.subjecttype = 'Elective Subject')   ");
                            //if (ds3.Tables[0].Rows.Count > 0)
                            //    checkedListBox1.Text = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                            #endregion

                            //By GreAtul 04/01/215
                            #region
                            try
                            {
                                DataSet ds = Connection.GetDataSet("Select studentimage from tbl_Student where studentno ='" + StudentNo + "'");
                                byte[] reading = (byte[])ds.Tables[0].Rows[0][0];
                                MemoryStream ms = new MemoryStream(reading);
                                member_pic.Image = Image.FromStream(ms);
                            }
                            catch(Exception ex){Logger.LogError(ex); }

                            try
                            {
                                DataSet ds66 = Connection.GetDataSet("Select docimage from tbl_Student where studentno ='" + StudentNo + "'");
                                byte[] reading1 = (byte[])ds66.Tables[0].Rows[0][0];
                                MemoryStream ms1 = new MemoryStream(reading1);
                                pictureBox2.Image = Image.FromStream(ms1);
                            }
                            catch(Exception ex){Logger.LogError(ex); }

                            try
                            {
                                DataSet dsBarCode = Connection.GetDataSet("Select barcode,barcodeimage from tbl_Student where studentno ='" + StudentNo + "'");
                                byte[] reading1 = (byte[])dsBarCode.Tables[0].Rows[0][1];
                                MemoryStream ms1 = new MemoryStream(reading1);
                                pbxBarCode.Image = Image.FromStream(ms1);
                                pbxBarCode.Visible = true;
                                txtbarnum.Text = dsBarCode.Tables[0].Rows[0]["barcode"].ToString();
                            }
                            catch(Exception ex){Logger.LogError(ex); }

                            //  DataSet ds44 = Connection.GetDataSet("");

                            DataSet ds2 = Connection.GetDataSet(" SELECT     tbl_subject.subjectname   FROM tbl_subwiseclass INNER JOIN tbl_subject ON tbl_subwiseclass.subjectno = tbl_subject.subjectno INNER JOIN tbl_classstudent ON tbl_subwiseclass.classno = tbl_classstudent.classno INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno   WHERE     (tbl_student.studentno = '" + StudentNo + "') AND (tbl_subwiseclass.subjecttype = 'Core Subject')     ");
                            if (ds2.Tables[0].Rows.Count > 0)
                                lstCompalsary.Text = ds2.Tables[0].Rows[0].ItemArray[0].ToString();
                            DataSet ds3 = Connection.GetDataSet(" SELECT     tbl_subject.subjectname FROM tbl_subwiseclass INNER JOIN tbl_subject ON tbl_subwiseclass.subjectno = tbl_subject.subjectno INNER JOIN tbl_classstudent ON tbl_subwiseclass.classno = tbl_classstudent.classno INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno   WHERE     (tbl_student.studentno = '" + StudentNo + "') AND (tbl_subwiseclass.subjecttype = 'Elective Subject')   ");
                            if (ds3.Tables[0].Rows.Count > 0)
                                checkedListBox1.Text = ds3.Tables[0].Rows[0].ItemArray[0].ToString();
                            #endregion
                        }
                        else
                        {
                            if (DialogResult.No.Equals(MessageBox.Show("Student Record Not Found about \" " + txtScholarNo.Text.Trim() + "\" Scholar No...\n\n\tIf you want change Scholar No. Press Yes...", "Scholar No.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                            {
                                txtScholarNo.Focus();
                                return;
                            }
                            else
                            {
                                
                            }
                        }
                    }
                }
                catch (Exception ex)
                { Logger.LogError(ex); MessageBox.Show(ex.Message); }
            }
        }

        private void txtscholarno_Leave(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Connection.GetDataSet("Select Count(*) from tbl_student where scholarno='" + txtScholarNo.Text + "'");
                int k = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                if (k == 0)
                {
                    if (txtScholarNo.Text.Length > 0)
                    {
                        txtbarnum.Text = Guid.NewGuid().ToString().Replace("-", "").Trim().Substring(0, 10);
                        barcodectrl.BarCode = txtbarnum.Text;
                    }
                    else
                    {
                        txtbarnum.Text = "";
                        barcodectrl.BarCode = "";
                    }
                }
            }
            catch (Exception ex)
            { Logger.LogError(ex); }
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {

            // textBox1.Text = school.ToTitleCase(textBox1.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form clsform = new frmtehsil();
            clsform.StartPosition = FormStartPosition.CenterScreen;
            clsform.ShowDialog();
        }
        private void btntehrefresh_Click(object sender, EventArgs e)
        {
            c.FillcomboBox("SELECT     tbl_tehsil.*  FROM         tbl_tehsil INNER JOIN                       tbl_district ON tbl_tehsil.distcode = tbl_district.distcode  where district='" + valcmbdistrict.Text + "' ", "tehsil", "tehcode", ref valcmbtehsil);

        }
        private void txtstdname_Validated(object sender, EventArgs e)
        {
            txtStudentName.Text = school.ToTitleCase(txtStudentName.Text);
        }
        private void textBox11_Validated(object sender, EventArgs e)
        {
            // textBox11.Text = school.ToTitleCase(textBox11.Text);
        }
        private void txtaddress_Validated(object sender, EventArgs e)
        {
            //txtaddress.Text = school.ToTitleCase(txtaddress.Text);
        }
        private void textBox12_Validated(object sender, EventArgs e)
        {

            textBox12.Text = school.ToTitleCase(textBox12.Text);
        }
        private void txtfather_Validated(object sender, EventArgs e)
        {
            txtfather.Text = school.ToTitleCase(txtfather.Text);
        }
        private void textBox2_Validated(object sender, EventArgs e)
        {
            textBox2.Text = school.ToTitleCase(textBox2.Text);
        }

        private void txtfoccupation_Validated(object sender, EventArgs e)
        {
            txtfoccupation.Text = school.ToTitleCase(txtfoccupation.Text);
        }
        private void txtgargian_Validated(object sender, EventArgs e)
        {
            txtgargian.Text = school.ToTitleCase(txtgargian.Text);
        }

        private void txtgargianaddress_Validated(object sender, EventArgs e)
        {
            txtgargianaddress.Text = school.ToTitleCase(txtgargianaddress.Text);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            board = "MP BOARD";
            //valcmbclass.Visible = true;
            //label45.Visible = true;
        }

        public void fillByClass()
        {
            try
            {
                c.getconnstr();
                lstCompalsary.Visible = true;
                checkedListBox1.Visible = true;
                Mandetory.Visible = true;
                lblElective.Visible = true;
                strcmbfaculty.Visible = true;
                label43.Visible = true;


                // c.FillcomboBox( "SELECT     tbl_section.sectionname,tbl_section.sectioncode  FROM         tbl_class INNER JOIN                        tbl_classmaster ON tbl_class.classcode = tbl_classmaster.classcode INNER JOIN                       tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode where tbl_Classmaster.classname='" + valcmbclass.Text + "' ","sectionname","sectioncode",ref strsection);
                DataSet ds = Connection.GetDataSet("Select classcode from tbl_classmaster where classname='" + valcmbclass.Text + "'");
                classno = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                int classcode;
                if (Convert.ToInt32(classno) > 110 && Convert.ToInt32(classno) < 113)
                {
                    strcmbfaculty.Visible = true;
                    label43.Visible = true;

                    Connection.FillCombo(ref strcmbfaculty, "select sankayname from tbl_sankay where sankayName!='Common' order by sankayname");
                    strcmbfaculty.SelectedIndex = 0;

                }
                else
                {

                    // valcmbfaculty.Visible = true ;
                    label43.Visible = false;

                    Connection.FillCombo(ref strcmbfaculty, "select sankayname from tbl_sankay where sankayName='Common' order by sankayname");
                    strcmbfaculty.SelectedIndex = 0;
                    lstCompalsary.Items.Clear();
                    c.returnconn(c.myconn);
                    string mysql = "";
                    //mysql = "SELECT   tbl_classmaster.classname, tbl_classsubject.subjectno, tbl_sankay.sankayname FROM  tbl_classmaster INNER JOIN     tbl_classsubject ON tbl_classmaster.classcode = tbl_classsubject.classno CROSS JOIN  tbl_sankay where classno=" + valcmbclass.SelectedValue + " ";
                    // mysql = "SELECT    tbl_classsubject.subjectno, tbl_subject.subjectname, tbl_subject.subjecttype FROM   tbl_classsubject where classno="+classno +") INNER JOIN tbl_subject ON tbl_classsubject.subjectno = tbl_subject.subjectno";
                    // mysql = "SELECT     tbl_subject.subjectname FROM         tbl_subject INNER JOIN                        tbl_subwiseclass ON tbl_subject.subjectno = tbl_subwiseclass.subjectno where classno ='" + classno + "' and tbl_subwiseclass.subjecttype='Core Subject' and board='" + board + "'  ";
                    mysql = "SELECT     tbl_subject.subjectname FROM tbl_subject INNER JOIN tbl_subwiseclass ON tbl_subject.subjectno = tbl_subwiseclass.subjectno where classno='" + classno + "' and board='" + board + "' and tbl_subwiseclass.subjecttype='Core Subject' and  sankayname='" + strcmbfaculty.Text + "' ";
                    SqlCommand com;
                    com = new SqlCommand(mysql, c.myconn);
                    SqlDataReader reader;
                    c.getconnstr();
                    reader = com.ExecuteReader();
                    j = 0;
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {


                            lstCompalsary.Items.Add(reader["subjectname"].ToString());


                            j++;
                        }
                        reader.Close();

                    }
                    else
                    {
                        reader.Close();
                    }
                    reader.Close();
                    checkedListBox1.Items.Clear();
                    c.returnconn(c.myconn);
                    string mysql1 = "";
                    //mysql = "SELECT   tbl_classmaster.classname, tbl_classsubject.subjectno, tbl_sankay.sankayname FROM  tbl_classmaster INNER JOIN     tbl_classsubject ON tbl_classmaster.classcode = tbl_classsubject.classno CROSS JOIN  tbl_sankay where classno=" + valcmbclass.SelectedValue + " ";
                    // mysql = "SELECT    tbl_classsubject.subjectno, tbl_subject.subjectname, tbl_subject.subjecttype FROM   tbl_classsubject where classno="+classno +") INNER JOIN tbl_subject ON tbl_classsubject.subjectno = tbl_subject.subjectno";

                    mysql1 = "SELECT     tbl_subject.subjectname FROM         tbl_subject INNER JOIN                        tbl_subwiseclass ON tbl_subject.subjectno = tbl_subwiseclass.subjectno where classno='" + classno + "' and tbl_subwiseclass.subjecttype='Elective Subject' and board='" + board + "' and sankayname='" + strcmbfaculty.Text + "' ";
                    SqlCommand com1;
                    com1 = new SqlCommand(mysql1, c.myconn);
                    SqlDataReader reader1;
                    reader1 = com1.ExecuteReader();
                    j = 0;
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {


                            checkedListBox1.Items.Add(reader1["subjectname"].ToString());


                            j++;
                        }
                        reader1.Close();

                    }
                    else
                    {
                        reader1.Close();
                    }

                }
                Connection.FillCombo(ref strsection, "SELECT   distinct  tbl_section.sectionname  FROM         tbl_class INNER JOIN                        tbl_classmaster ON tbl_class.classcode = tbl_classmaster.classcode INNER JOIN                       tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode where tbl_Classmaster.classname='" + valcmbclass.Text + "' and  tbl_class.sankaycode=(select top 1 sankaycode from tbl_sankay where sankayname='" + strcmbfaculty.SelectedItem.ToString() + "' ) ");
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
        private void valcmbclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillByClass();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            strcmbfaculty.Visible = false;
            label43.Visible = false;
            lstCompalsary.Visible = false;
            checkedListBox1.Visible = false;
            Mandetory.Visible = false;
            lblElective.Visible = false;
            valcmbclass.Visible = true;
            label45.Visible = true;
            board = "BOARD CBSC";

        }
        private void valcmbfaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.getconnstr();
            lstCompalsary.Items.Clear();
            c.returnconn(c.myconn);
            string mysql = "";
            //mysql = "SELECT   tbl_classmaster.classname, tbl_classsubject.subjectno, tbl_sankay.sankayname FROM  tbl_classmaster INNER JOIN     tbl_classsubject ON tbl_classmaster.classcode = tbl_classsubject.classno CROSS JOIN  tbl_sankay where classno=" + valcmbclass.SelectedValue + " ";
            // mysql = "SELECT    tbl_classsubject.subjectno, tbl_subject.subjectname, tbl_subject.subjecttype FROM   tbl_classsubject where classno="+classno +") INNER JOIN tbl_subject ON tbl_classsubject.subjectno = tbl_subject.subjectno";

            mysql = "SELECT     tbl_subject.subjectname FROM         tbl_subject INNER JOIN                        tbl_subwiseclass ON tbl_subject.subjectno = tbl_subwiseclass.subjectno where classno ='" + classno + "' and tbl_subwiseclass.subjecttype='Core Subject' and board='" + board + "' and sankayname='" + strcmbfaculty.Text + "' ";
            SqlCommand com;
            com = new SqlCommand(mysql, c.myconn);
            SqlDataReader reader;
            reader = com.ExecuteReader();
            j = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {


                    lstCompalsary.Items.Add(reader["subjectname"].ToString());


                    j++;
                }
                reader.Close();

            }
            checkedListBox1.Items.Clear();
            c.returnconn(c.myconn);
            string mysql1 = "";
            //mysql = "SELECT   tbl_classmaster.classname, tbl_classsubject.subjectno, tbl_sankay.sankayname FROM  tbl_classmaster INNER JOIN     tbl_classsubject ON tbl_classmaster.classcode = tbl_classsubject.classno CROSS JOIN  tbl_sankay where classno=" + valcmbclass.SelectedValue + " ";
            // mysql = "SELECT    tbl_classsubject.subjectno, tbl_subject.subjectname, tbl_subject.subjecttype FROM   tbl_classsubject where classno="+classno +") INNER JOIN tbl_subject ON tbl_classsubject.subjectno = tbl_subject.subjectno";

            mysql1 = "SELECT     tbl_subject.subjectname FROM         tbl_subject INNER JOIN                        tbl_subwiseclass ON tbl_subject.subjectno = tbl_subwiseclass.subjectno where classno='" + classno + "' and tbl_subwiseclass.subjecttype='Elective Subject' and board='" + board + "' and sankayname='" + strcmbfaculty.Text + "' ";
            SqlCommand com1;
            com1 = new SqlCommand(mysql1, c.myconn);
            SqlDataReader reader1;
            reader1 = com1.ExecuteReader();
            j = 0;
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {


                    checkedListBox1.Items.Add(reader1["subjectname"].ToString());


                    j++;
                }
                reader1.Close();

            }

            Connection.FillCombo(ref strsection, "SELECT   distinct  tbl_section.sectionname  FROM         tbl_class INNER JOIN                        tbl_classmaster ON tbl_class.classcode = tbl_classmaster.classcode INNER JOIN                       tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode where tbl_Classmaster.classname='" + valcmbclass.Text + "' and  tbl_class.sankaycode=(select top 1 sankaycode from tbl_sankay where sankayname='" + strcmbfaculty.SelectedItem.ToString() + "' ) ");

        }
        private void button2_Click(object sender, EventArgs e)
        {
            label31.Visible = true;
            // button1.Visible = false;
            txtsubject2.Visible = true;
            txtrollno1.Visible = true;
            txtyear1.Visible = true;
            txtmarks1.Visible = true;
            txtobtained1.Visible = true;
            txtresult1.Visible = true;
            txtpercantage1.Visible = true;
            txtdivision1.Visible = true;
            textBox20.Visible = true;
            button2.Visible = false;
            button5.Visible = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            label32.Visible = true;
            //button5.Visible = false;
            txtsubject3.Visible = true;
            txtrollno2.Visible = true;
            txtyear2.Visible = true;
            txtmarks2.Visible = true;
            txtobtained2.Visible = true;
            txtresult2.Visible = true;
            txtpercantage2.Visible = true;
            txtdivision2.Visible = true;
            textBox19.Visible = true;
            // button2.Visible = false;
        }
        public override void btnprint_Click(object sender, EventArgs e)
        {
            string str = "";
            str = "  SELECT     tbl_session.sessionname, tbl_student.scholarno, tbl_student.studentno, UPPER(tbl_student.SSMId) AS SSMId, UPPER(tbl_student.ChielId) AS ChielId, UPPER(tbl_student.AdharNo)AS AdharNo, UPPER(tbl_student.name) AS name, UPPER(tbl_student.father) AS father,                           UPPER(tbl_student.mother) AS mother, CONVERT(varchar(12), tbl_student.dob, 106) AS dob, UPPER(tbl_student.P_address) AS P_address,                         UPPER(tbl_student.C_address) AS C_address, UPPER(tbl_student.m_tongue) AS m_tongue, tbl_student.fatheroccu, tbl_student.admissiondate,                         tbl_student.bldgroup, tbl_student.studentimage, tbl_student.barcodeimage,tbl_student.BusStopNo , tbl_student.tehcode, tbl_student.distcode,                         tbl_classmaster.classname, tbl_student.casttype, tbl_student.gargian, tbl_student.relation, tbl_student.fatherincome, tbl_student.bloodgroup,                         tbl_student.busfacility, tbl_student.hostelfacility, tbl_student.isbelongrural, tbl_student.ruralinformation, tbl_classstudent.stdtype, tbl_student.StudType,tbl_student.phone, tbl_student.Cast, tbl_student.SubCast, tbl_student.LastClass, tbl_student.lastschool, tbl_student.Religion  ,tbl_student.marr_status FROM         tbl_classstudent INNER JOIN                        tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN                        tbl_session ON tbl_classstudent.sessioncode = tbl_session.sessioncode INNER JOIN                        tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode    WHERE     (tbl_student.scholarno = '" + txtScholarNo.Text + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')    ";
            str = str + "SELECT     schoolname, schooladdress, affiliate_by, logoimage, schoolphone, registrationno, SchoolCode   FROM         tbl_school   ";
            str = str + "SELECT     CONVERT(varchar(10), GETDATE(), 103) AS Expr1";
            DataSet ds = Connection.GetDataSet(str);
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\Registration.xsd");
            if (chkIsPramote.Checked == true)
            {
                AdmissionformPramote fr = new AdmissionformPramote();
                fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                fr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = fr;
                s.Show();
            }
            else
            {
                Admissionform fr = new Admissionform();
                fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                fr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = fr;
                s.Show();
            }
            
            valcmbsession.Enabled = false;
            chkIsPramote.Checked = false;
        }
        public override void btndelete_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Connection.GetExecuteScalar("select count(*) from tbl_classstudent " +
                "   where studentno='" + txtstudentno.Text + "'")) > 0)
            {
                MessageBox.Show("You Can Not Delete Student Record ....");
            }
            else
            {
                DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record.", "", MessageBoxButtons.YesNo);
                if (d.ToString() == "Yes")
                {
                    SqlTransaction trn = null;
                    try
                    {
                        trn = Connection.GetMyConnection().BeginTransaction();

                        Connection.SqlTransection("Delete from tbl_Student where scholarno ='" + txtScholarNo.Text + "'",
                            Connection.MyConnection, trn);
                        trn.Commit();
                        MessageBox.Show("Record Deleted");
                    }
                    catch
                    {
                        trn.Rollback();
                    }
                    DesignForm.fromClear(this);
                }
            }
            valcmbsession.Enabled = false;
        }
        private void txtobtained3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double per = Convert.ToDouble(txtobtained3.Text) * 100 / Convert.ToDouble(txtmarks3.Text);
                txtpercantage3.Text = per.ToString();
                if (per > 60)
                {
                    txtdivision3.Text = "First..";
                    //groupBox2.Visible = true ;
                    txtresult3.Text = "Pass";
                }
                else if (per > 45)
                {
                    txtdivision3.Text = "Second...";
                    txtresult3.Text = "Pass";
                    // groupBox2.Visible = true;
                }
                else if (per > 33)
                {
                    txtdivision3.Text = "Third..";
                    txtresult3.Text = "Pass";
                    // groupBox2.Visible = true;
                }
                else if (per < 33)
                {
                    txtdivision3.Text = "Fail..";
                    txtresult3.Text = "Fail..";
                    //groupBox2.Visible = false;

                }
            }
            catch (Exception ex)
            { Logger.LogError(ex); }
        }
        private void txtobtained2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double per = Convert.ToDouble(txtobtained.Text) * 100 / Convert.ToDouble(txtmarks2.Text);
                txtpercantage2.Text = per.ToString();
                if (per > 60)
                {
                    txtdivision2.Text = "First..";
                    txtresult2.Text = "Pass";
                    //groupBox2.Visible = true;
                }
                else if (per > 45)
                {
                    txtdivision2.Text = "Second...";
                    txtresult2.Text = "Pass";
                    //groupBox2.Visible = true;
                }
                else if (per > 33)
                {
                    txtdivision2.Text = "Third..";
                    txtresult2.Text = "Pass";
                    //groupBox2.Visible = true;
                }
                else if (per < 33)
                {
                    txtdivision2.Text = "Fail..";
                    txtresult2.Text = "Fail.";
                    //groupBox2.Visible = false;
                }
            }
            catch (Exception ex)
            { Logger.LogError(ex); }
        }
        private void txtobtained1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double per = Convert.ToDouble(txtobtained1.Text) * 100 / Convert.ToDouble(txtmarks1.Text);
                txtpercantage1.Text = per.ToString();
                if (per > 60)
                {
                    txtdivision1.Text = "First..";
                    txtresult1.Text = "Pass";
                    //groupBox2.Visible = true;
                }
                else if (per > 45)
                {
                    txtdivision1.Text = "Second...";
                    txtresult1.Text = "Pass";
                    //groupBox2.Visible = true;

                }
                else if (per > 33)
                {
                    txtdivision1.Text = "Third..";
                    txtresult1.Text = "Pass";
                    // groupBox2.Visible = true;

                }
                else if (per < 33)
                {
                    txtdivision1.Text = "Fail..";
                    txtresult1.Text = "Fail.";
                    //groupBox2.Visible = false;

                }
            }
            catch (Exception ex)
            { Logger.LogError(ex); }
        }
        private void valcmbdistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.getconnstr();
            c.FillcomboBox("SELECT  tbl_tehsil.*  FROM tbl_tehsil INNER JOIN  tbl_district ON tbl_tehsil.distcode = tbl_district.distcode  where tbl_district.district='" + valcmbdistrict.Text + "' ", "tehsil", "tehcode", ref valcmbtehsil);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            c.FillcomboBox("select * from tbl_district order by district", "district", "distcode", ref  valcmbdistrict);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Thread backgroundThread = new Thread(threadStart);
            //backgroundThread.IsBackground = true;
            //backgroundThread.Start();

            Form clsform = new Distic_Setup();
            clsform.StartPosition = FormStartPosition.CenterScreen;
            clsform.ShowDialog();
        }
        private void txtscholarno_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            //if (char.IsDigit(e.KeyChar) == true)
            //{
            //    if (txtscholarno.Text.Length < 4)
            //    {

            //    }
            //    else
            //    {
            //        MessageBox.Show("Only 4 digit Scholar No Allowed..");
            //        e.Handled = true;

            //    }
            //}

            //if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            //{
            //    e.Handled = false;
            //}
            //else
            //{
            //    MessageBox.Show("Invalid Input");
            //    e.Handled = true;
            //}
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    Image image1 = Image.FromFile(openFileDialog1.FileName);
                    member_pic.Image = image1;
                    PicturePath = openFileDialog1.FileName;

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); MessageBox.Show(ex.Message);
            }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbusfacility.Checked == true)
            {
                label19.Visible = true;
                valCmbBusStop.Visible = true;
                chkbusfacility.Text = "Yes";
            }
            else
            {
                chkbusfacility.Text = "No";
                label19.Visible = false;
                valCmbBusStop.Visible = false;
            }
        }
        private void frmstudent_KeyPress_3(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            }
        }
        private void chkwanthostelfaci_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkwanthostelfaci.Checked == true)
            {
                chkwanthostelfaci.Text = "Yes";
            }
            else
            {
                chkwanthostelfaci.Text = "No";
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                checkBox7.Text = "Yes";
                gbxAPPDetails.Visible = true;
            }
            else
            {
                checkBox7.Text = "No";
                gbxAPPDetails.Visible = false;
            }
        }

        private void strsection_SelectedIndexChanged(object sender, EventArgs e)
        {

           c.GetMdiParent(this).ToggleSaveButton(true);
            DataSet ds = Connection.GetDataSet("SELECT     tbl_section.sectioncode  FROM         tbl_class INNER JOIN                        tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode INNER JOIN                        tbl_classmaster ON tbl_class.classcode = tbl_classmaster.classcode where classname='" + valcmbclass.Text + "' and sectionname='" + strsection.Text + "' ");
            sectionNo = ds.Tables[0].Rows[0].ItemArray[0].ToString();

            string str1 = "Select strength from tbl_class where classcode='" + classno.ToString() + "' and sectioncode='" + sectionNo.ToString() + "'";
            DataSet ds1 = Connection.GetDataSet(str1 + "Select count(*) from tbl_classstudent where classno='" + classno.ToString() + "' and sessioncode='" + school.CurrentSessionCode.ToString() + "' and section='" + sectionNo.ToString() + "'");
            int count = Convert.ToInt32(ds1.Tables[1].Rows[0][0]);

            int NoOfStudent = Convert.ToInt32(ds1.Tables[0].Rows[0].ItemArray[0].ToString());

            if (NoOfStudent < count)
            {
                MessageBox.Show("This Section is Full Please Select another section");
               c.GetMdiParent(this).ToggleSaveButton(false);
            }
            else
            {
               c.GetMdiParent(this).ToggleSaveButton(true);
            }
            if (add_edit == false)
            {
               c.GetMdiParent(this).ToggleSaveButton(true);
            }

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            }

        }
        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == true)
            {
                if (txtMobileNo.Text.Length < 11)
                {

                }
                else
                {
                    MessageBox.Show("Only Indian Mobile No.10 digit Allowed..");
                    e.Handled = false;

                }
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            }
        }
        private void txtresult_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            }
        }
        private void textBox18_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Invalid Input");
                e.Handled = true;
            }
        }
        public override void btnnew_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds545 = Connection.GetDataSet("Select Count(*) from tbl_student");
                int k = Convert.ToInt32(ds545.Tables[0].Rows[0][0]);
                if (k > 0)
                {
                    DataSet dstt = Connection.GetDataSet("Select Max(studentno) from tbl_student ");
                    if (dstt.Tables[0].Rows.Count > 0)
                    {
                        DataSet dsty = Connection.GetDataSet("Select ScholarNo,name from tbl_student where studentno='" + dstt.Tables[0].Rows[0][0].ToString() + "'");
                        txtScholarNo.Text = dsty.Tables[0].Rows[0].ItemArray[0].ToString();
                        txtStudentName.Text = dsty.Tables[0].Rows[0].ItemArray[1].ToString();
                        MessageBox.Show(" Your Last Scholar No Is : " + dsty.Tables[0].Rows[0].ItemArray[0].ToString() + " and Student Name Is  : " + dsty.Tables[0].Rows[0].ItemArray[1].ToString() + " Ok To Continue...", "Last Scholar Details");
                    }
                }
                button9.Visible = false;
                tabControl1.SelectedIndex = 0;
                fillByClass();
                DesignForm.fromDesign2(this);
                add_edit = true;
                c.GetMdiParent(this).DisableAllEditMenuButtons();
                tcflag = "Y";
               c.GetMdiParent(this).ToggleSaveButton(false);
                txtScholarNo.Text = string.Empty;
                txtStudentName.Text = string.Empty;
                txtfather.Text = string.Empty;
                // txtfincome = "";
                // txtfoccupation = "";
                txtgargian.Text = string.Empty;
                txtdivision.Text = string.Empty;
                //  textBox1.Text = "";
                textBox10.Text = string.Empty;
                textBox12.Text = string.Empty;
                txtMobileNo.Text = string.Empty;
                textBox17.Text = string.Empty;
                textBox18.Text = string.Empty;
                txtfoccupation.Text = string.Empty;
                txtfincome.Text = string.Empty;
                txtgargianaddress.Text = string.Empty;
                txtrelwithgargian.Text = string.Empty;
                strstdcategory.Text = string.Empty;
                strcurrentstatus.Text = string.Empty;
                member_pic.Image = null;

                barcodectrl.BarCode = string.Empty;
                textBox19.Text = string.Empty;
                txtgargian.Text = string.Empty;
                txtrelwithgargian.Text = string.Empty;
                txtgargianaddress.Text = string.Empty;
                txtfincome.Text = string.Empty;
                txtSSMId.Text = string.Empty;
                txtChielId.Text = string.Empty;
                txtParentId.Text = string.Empty;
                textBox4.Text = string.Empty;
                txtACNo.Text = string.Empty;
                txtAmount.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox20.Text = string.Empty;
                textBox21.Text = string.Empty;
                valCmbBusStop.Text = string.Empty;
                txtCatNo.Text = string.Empty;
                txtAdharNo.Text = string.Empty;
                txtAPPNo.Text = string.Empty;
                strcmbAPPType.SelectedIndex = 0;
                //---docs
                chktc.Checked = false;
                chksoc.Checked = false;
                chkslc.Checked = false;
                chkdob.Checked = false;
                chkms.Checked = false;
                chkic.Checked = false;
                chkcc.Checked = false;
                chkIsBPL.Checked = false;
                IsScholar.Checked = false;
                checkBox7.Checked = false;
                //---end docs


                c.cleartext(this);

                pbxBarCode.Visible = false;
                txtScholarNo.Focus();
                valcmbsession.Enabled = false;
            }
            catch(Exception ex){Logger.LogError(ex); }
            strstdcategory.Text = "GENERAL";
            strcurrentstatus.Text = "New Student";
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image image1 = Image.FromFile(openFileDialog1.FileName);
                    pictureBox2.Image = image1;
                    PicturePath1 = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); MessageBox.Show(ex.Message);
            }

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            //  
        }
        private void strsection_Validated(object sender, EventArgs e)
        {
            //DataSet ds = Connection.GetDataSet("SELECT     tbl_section.sectioncode  FROM         tbl_class INNER JOIN                        tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode INNER JOIN                        tbl_classmaster ON tbl_class.classcode = tbl_classmaster.classcode where classname='" + valcmbclass.Text + "' and sectionname='" + strsection.Text + "' ");
            //sectionNo = ds.Tables[0].Rows[0].ItemArray[0].ToString();

            //string str1 = "Select strength from tbl_class where classcode='" + classno.ToString() + "' and sectioncode='" + sectionNo.ToString() + "'";
            //DataSet ds1 = Connection.GetDataSet(str1 + "Select count(*) from tbl_classstudent where classno='" + classno.ToString() + "' and sessioncode='" + school .CurrentSessionCode.ToString() + "' and section='" + sectionNo.ToString() + "'");
            //int count = Convert.ToInt32(ds1.Tables[1].Rows[0][0]);

            //int NoOfStudent = Convert.ToInt32(ds1.Tables[0].Rows[0].ItemArray[0].ToString());

            //if (NoOfStudent < count)
            //{
            //    MessageBox.Show("This Section is Full Please Select another section");
            //   c.GetMdiParent(this).ToggleSaveButton(false);
            //}
            //else
            //{
            //   c.GetMdiParent(this).ToggleSaveButton(true);
            //}
        }
        private void txtstudentno_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }
        private void textBox19_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            SearchByName gb = new SearchByName();
            //Library.FrmGetStudentBarcode gb = new FrmGetStudentBarcode();
            Connection.Flag = "S";
            gb.ShowDialog();
            txtScholarNo.Text = Connection.StudentBcode;
            txtScholarNo.Focus();

        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        private void GetGridViewData()
        {
            //DataSet ds = Connection.GetDataSet("select name,dob,father,mother");
            //dataGridView1.DataSource = ds.Tables[0];
        }
        private void cmbClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = Connection.GetDataSet("select  classcode from tbl_classmaster where classname ='" + cmbClassName.Text + "'  ");
                classno2 = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());

                DataSet ds67 = Connection.GetDataSet("SELECT DISTINCT tbl_student.scholarno, tbl_student.name, tbl_student.P_address, tbl_student.father, tbl_student.phone, tbl_classmaster.classname,                         tbl_section.sectionname, tbl_sankay.sankayname, tbl_session.sessionname  FROM         tbl_classstudent INNER JOIN                        tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN                        tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN                        tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN                        tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN                        tbl_session ON tbl_classstudent.sessioncode = tbl_session.sessioncode  WHERE     (tbl_classstudent.classno = '" + cmbClassName.SelectedValue.ToString() + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')   ");
                dataGridView1.DataSource = ds67.Tables[0];

                DataSet ds6 = Connection.GetDataSet(" SELECT     COUNT(tbl_classstudent.studentno) AS Expr1  FROM         tbl_classstudent INNER JOIN                        tbl_student ON tbl_classstudent.studentno = tbl_student.studentno  WHERE     (tbl_classstudent.classno = '" + classno2.ToString() + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')   ");
                txtTotalStudent.Text = ds6.Tables[0].Rows[0].ItemArray[0].ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
                //  MessageBox.Show(ez.Message);
            }

            // DataSet ds56 =c
            ////string str = "SELECT tbl_student.scholarno, tbl_student.name, tbl_student.father, tbl_student.mother, tbl_student.dob, tbl_classmaster.classname  FROM tbl_student INNER JOIN tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno INNER JOIN                         tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.Classcode INNER JOIN  tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode   WHERE     (tbl_classmaster.classname = '" + cmbClassName.Text + "') ";
            //////str = str + " SELECT     schoolname, schooladdress, affiliate_by, logoimage   FROM         tbl_school ";
            ////DataSet ds1 = Connection.GetDataSet(str);
            ////dataGridView1.DataSource = ds1.Tables[0];               

        }

        private void strCmbReligion_Validated(object sender, EventArgs e)
        {
            strCmbReligion.Text = school.ToTitleCase(strCmbReligion.Text);
        }

        private void strCmdSubCast_Validated(object sender, EventArgs e)
        {
            strCmdSubCast.Text = school.ToTitleCase(strCmdSubCast.Text);
        }

        private void strCmbCast_Validated(object sender, EventArgs e)
        {
            strCmbCast.Text = school.ToTitleCase(strCmbCast.Text);
        }

        private void strmtongue_Validated(object sender, EventArgs e)
        {
            strmtongue.Text = school.ToTitleCase(strmtongue.Text);
        }

        static byte[] btimg = null;

        public bool GetShortImageBT(byte[] ibt)
        {
            //-------
            System.Drawing.Size s1 = new Size();
            s1.Height = 600;
            s1.Width = 500;
            const int limit = 50; float size = 0.0f;
            Image imgToResize;
            imgToResize = frmstudent.resizeImage(ibt, s1);
            //-------------

            MemoryStream ms = new MemoryStream();
            imgToResize.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            size = ibt.Length / 1024f;
            if (size > limit)
            {
                size = ms.ToArray().Length / 1024f;
                if (size > limit)
                {
                    MessageBox.Show("Uploading image size should be less then or equal to \n\n                50KB.");
                    return false;
                }
                else
                {
                    btimg = ms.ToArray();
                    return true;
                }
            }
            btimg = ibt;
            return true;
        }

        public bool Limit(string path)
        {
            if (path == null)
            {
                return true;

            }
            {
                //-------
                System.Drawing.Size s1 = new Size();
                s1.Height = 600;
                s1.Width = 500;
                const int limit = 50; float size = 0.0f;
                Image imgToResize;
                imgToResize = frmstudent.resizeImage(ToByteArray(path), s1);
                //-------------

                MemoryStream ms = new MemoryStream();
                imgToResize.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                size = ToByteArray(path).Length / 1024f;
                if (size > limit)
                {
                    size = ms.ToArray().Length / 1024f;
                    if (size > limit)
                    {
                        MessageBox.Show("Uploading image size should be less then or equal to \n\n                50KB.");
                        return false;
                    }
                    else
                    {
                        btimg = ms.ToArray();
                        return true;
                    }
                }
                btimg = ToByteArray(path);
                return true;
            }
        }
        public byte[] ToByteArray(string path)
        { byte[] buffer = File.ReadAllBytes(path); return buffer; }
        public static Bitmap ByteToImage(byte[] blob)
        {
            using (MemoryStream mStream = new MemoryStream())
            {
                mStream.Write(blob, 0, blob.Length);
                mStream.Seek(0, SeekOrigin.Begin);

                Bitmap bm = new Bitmap(mStream);
                return bm;
            }
        }
        private static Image resizeImage(byte[] tbimg, Size size)
        {

            Image imgToResize;

            MemoryStream ms = new MemoryStream(tbimg);
            imgToResize = Image.FromStream(ms);
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            c.getconnstr();
            DateTime dt;
            dt = dateTimePicker1.Value;
            lWdob.Text = Connection.GetDateIntoWord(dt.ToString("dd/MM/yyyy"));
            if (strcurrentstatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please Select Current Status of Student.");
                strcurrentstatus.Focus();
                return;
            }
            if (txtScholarNo.Text == "" && strsection.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");
            }
            else
            {
                if (Limit(PicturePath))
                {

                    if (add_edit == true)
                    {
                        c.returnconn(c.myconn);
                        SqlCommand command = new SqlCommand("select max(studentno) from tbl_student", c.myconn);
                        command.CommandTimeout = 120;
                        Int32 mstudentno;
                        status = "No";
                        mstudentno = 1001;
                        if (command.ExecuteScalar() != System.DBNull.Value)
                        {
                            mstudentno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                        }
                        txtstudentno.Text = mstudentno.ToString();
                        txtbarnum.Text = txtbarnum.Text.Substring(0, 10);
                        if (txtAmount.Text.Trim() == string.Empty)
                        {
                            txtAmount.Text = "0";
                        }
                        c.insertstudentdata("tbl_student", c.myconn, this);
                        SqlTransaction trn;

                        trn = c.myconn.BeginTransaction();

                        DataSet dssan = Connection.GetDataSet("Select sankaycode from tbl_sankay where sankayname='" + strcmbfaculty.Text + "'");
                        c.connectsql("insert into tbl_classstudent (studentno,classno,sessioncode,section,stream,stdtype) values ('" + txtstudentno.Text + "','" + classno + "','" + school.CurrentSessionCode + "','" + sectionNo + "','" + dssan.Tables[0].Rows[0].ItemArray[0].ToString() + "','" + strcurrentstatus.Text.Trim() + "')", c.myconn, trn);
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            if (checkedListBox1.GetItemChecked(i))
                            {
                                DataSet ds90 = Connection.GetDataSet("SELECT     subjectname   FROM         tbl_subject  WHERE     (subjectname  = '" + checkedListBox1.Items[i].ToString() + "') AND (subjecttype = 'Elective Subject')   ");
                                Connection.AllPerform("insert into tbl_stdelectivesub values ('" + txtstudentno.Text + "','" + ds90.Tables[0].Rows[0].ItemArray[0].ToString() + "','" + school.CurrentSessionCode + "','" + classno + "')");
                            }
                        }
                        string filename = @"" + Connection.GetAccessPathId() + @"Barcodes\" + txtbarnum.Text + ".bmp";
                        barcodectrl.SaveImage(filename);
                        FileStream fs;
                        fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                        //a byte array to read the image
                        byte[] picbyte = new byte[fs.Length];
                        fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));
                        System.Threading.Thread.Sleep(200);
                        fs.Flush();
                        fs.Close();
                        SqlConnection con = Connection.Conn();
                        string str1 = "Update tbl_Student set Barcodeimage=@Bimage where scholarno=@scholarno ";
                        SqlCommand cmd = new SqlCommand(str1, con);
                        cmd.Parameters.AddWithValue("@scholarno", txtScholarNo.Text);
                        cmd.Parameters.AddWithValue("@Bimage", picbyte);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        if (PicturePath1 != null)
                        {
                            FileStream fs2;
                            fs2 = new FileStream(PicturePath1, FileMode.Open, FileAccess.Read);
                            //a byte array to read the image
                            byte[] picbyte2 = new byte[fs2.Length];
                            fs2.Read(picbyte2, 0, System.Convert.ToInt32(fs2.Length));
                            System.Threading.Thread.Sleep(200);
                            fs2.Flush();
                            fs2.Close();
                            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Size.Width, Screen.PrimaryScreen.Bounds.Size.Height);
                            Graphics g = Graphics.FromImage(bmp);
                            g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                            g.Save();
                            bmp.Save(@"" + Connection.GetAccessPathId() + @"Images\" + txtScholarNo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Bmp);
                            SqlConnection con2 = Connection.Conn();
                            string str2 = "Update tbl_Student set docimage=@Dimage where scholarno=@scholarno ";
                            SqlCommand cmd1 = new SqlCommand(str2, con2);
                            cmd1.Parameters.AddWithValue("@scholarno", txtScholarNo.Text);
                            cmd1.Parameters.AddWithValue("@Dimage", picbyte2);
                            con2.Open();
                            cmd1.ExecuteNonQuery();
                            con2.Close();
                        }
                        if (PicturePath != null)
                        {
                            //-comment By ...
                            //FileStream fs1;
                            //fs1 = new FileStream(PicturePath, FileMode.Open, FileAccess.Read);
                            ////a byte array to read the image
                            //byte[] picbyte1 = new byte[fs1.Length];
                            //fs1.Read(picbyte1, 0, System.Convert.ToInt32(fs1.Length));
                            //System.Threading.Thread.Sleep(200);
                            //fs1.Flush();
                            //fs1.Close();
                            //---------------
                            Bitmap oBitmap = new Bitmap(ByteToImage(btimg));
                            Graphics oGraphic = Graphics.FromImage(oBitmap);
                            oBitmap.Save(@"" + Connection.GetAccessPathId() + @"Images\" + txtScholarNo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            oBitmap.Dispose();
                            oGraphic.Dispose();
                            SqlConnection con3 = Connection.Conn();
                            string str3 = "Update tbl_Student set studentimage=@Simage where scholarno=@scholarno ";
                            SqlCommand cmd3 = new SqlCommand(str3, con3);
                            cmd3.Parameters.AddWithValue("@scholarno", txtScholarNo.Text);
                            cmd3.Parameters.AddWithValue("@Simage", btimg);
                            con3.Open();
                            cmd3.ExecuteNonQuery();
                            con3.Close();
                            PicturePath = null;
                            btimg = null;
                        }
                        //For docs upload 
                        if (chktc.Checked)
                            UpdateTc(txtstudentno.Text.Trim());
                        if (chksoc.Checked)
                            UpdateSoc(txtstudentno.Text.Trim());
                        if (chkslc.Checked)
                            UpdateSlc(txtstudentno.Text.Trim());
                        if (chkdob.Checked)
                            UpdateDob(txtstudentno.Text.Trim());
                        if (chkms.Checked)
                            UpdateMs(txtstudentno.Text.Trim());
                        if (chkic.Checked)
                            UpdateIc(txtstudentno.Text.Trim());
                        if (chkcc.Checked)
                            UpdateCc(txtstudentno.Text.Trim());
                        //------
                        trn.Commit();

                        //Short Messaging Services
                        #region "Messaging Services"
                        if (this.MessageService)
                        {
                            DataTable dtStudent = Connection.GetDataTable("SELECT ISNULL(schoolname,'') as schoolname, schooladdress, schoolcity, ISNULL(schoolphone,'') as schoolphone, affiliate_by, " +
                                " principal, registrationno, logoimage, ISNULL(Website,'') as Website, MessageService,MessageSenderID,MessageUserName,MessagePassword FROM tbl_school");
                            try
                            {
                                if (!string.IsNullOrEmpty(txtMobileNo.Text))
                                {
                                    Connection.SendSMS(txtMobileNo.Text.Trim(),
                                        "Hello! " + txtStudentName.Text.Trim() +                     //Student Name 
                                        "\nyou have got admission in\nClass: " +
                                        valcmbclass.SelectedItem +
                                        "-" +
                                        strsection.Text.Trim() +                                     //Section
                                        "\nScholar No.: " + txtScholarNo.Text +                     //Scholar No.
                                        "\n" + dtStudent.Rows[0]["schoolname"].ToString() +         //School Name
                                        " for more detail contact on " +
                                        dtStudent.Rows[0]["schoolphone"].ToString() +               //Contact No.
                                        " and visit us:\n" +
                                        dtStudent.Rows[0]["Website"].ToString());                   //Website
                                }
                            }
                            catch (Exception ex) { Logger.LogError(ex); MessageBox.Show(ex.Message); }
                        }
                        #endregion

                        strmtongue.Items.Clear();
                        Connection.FillCombo(ref strmtongue, "select distinct m_tongue from tbl_student");

                    }
                    if (add_edit == false)
                    {
                        c.getconnstr();
                        c.updatestudentdata("tbl_student", c.myconn, this, "studentno", txtstudentno.Text);

                        Connection.AllPerform("update tbl_student set bloodgroup='" + strbloodgroup.Text + "' where studentno='" + txtstudentno.Text + "' ");
                        DataSet ds89 = Connection.GetDataSet("Select sankaycode from tbl_sankay where sankayname='" + strcmbfaculty.Text + "'");
                        int streamcode = Convert.ToInt32(ds89.Tables[0].Rows[0].ItemArray[0].ToString());

                        DataSet ds33 = Connection.GetDataSet("Select sectioncode from tbl_section where sectionname='" + strsection.Text + "' ");
                        sectionNo = ds33.Tables[0].Rows[0].ItemArray[0].ToString();
                        Connection.AllPerform(" update tbl_classstudent set classno='" + classno + "',section='" + sectionNo + "',stream='" + streamcode.ToString() + "',stdtype='" + strcurrentstatus.Text.Trim() + "' where studentno='" + txtstudentno.Text + "' and sessioncode='" + school.CurrentSessionCode + "'");
                        for (int i = 0; i < checkedListBox1.Items.Count; i++)
                        {
                            if (checkedListBox1.GetItemChecked(i))
                            {

                                DataSet ds90 = Connection.GetDataSet("SELECT     subjectname   FROM         tbl_subject  WHERE     (subjectname  = '" + checkedListBox1.Items[i].ToString() + "') AND (subjecttype = 'Elective Subject')   ");
                                Connection.AllPerform("update  tbl_stdelectivesub set electivesubject= '" + ds90.Tables[0].Rows[0].ItemArray[0].ToString() + "',sessionno= '" + school.CurrentSessionCode + "',classno='" + classno + "'where studentno='" + txtstudentno.Text + "'");

                            }
                        }
                        if (PicturePath1 != null)
                        {
                            FileStream fs2;
                            fs2 = new FileStream(PicturePath1, FileMode.Open, FileAccess.Read);
                            //a byte array to read the image
                            byte[] picbyte2 = new byte[fs2.Length];
                            fs2.Read(picbyte2, 0, System.Convert.ToInt32(fs2.Length));
                            System.Threading.Thread.Sleep(200);
                            fs2.Flush();
                            fs2.Close();
                            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Size.Width, Screen.PrimaryScreen.Bounds.Size.Height);
                            Graphics g = Graphics.FromImage(bmp);
                            g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                            g.Save();
                            bmp.Save(@"" + Connection.GetAccessPathId() + @"Images\" + txtScholarNo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Bmp);
                            SqlConnection con2 = Connection.Conn();
                            string str2 = "Update tbl_Student set docimage=@Dimage where scholarno=@scholarno ";

                            SqlCommand cmd1 = new SqlCommand(str2, con2);
                            cmd1.Parameters.AddWithValue("@scholarno", txtScholarNo.Text);
                            cmd1.Parameters.AddWithValue("@Dimage", picbyte2);
                            con2.Open();
                            cmd1.ExecuteNonQuery();
                            con2.Close();
                        }
                        if (PicturePath != null)
                        {
                            //comment by...
                            //FileStream fs1;
                            //fs1 = new FileStream(PicturePath, FileMode.Open, FileAccess.Read);
                            ////a byte array to read the image
                            //byte[] picbyte1 = new byte[fs1.Length];
                            //fs1.Read(picbyte1, 0, System.Convert.ToInt32(fs1.Length));
                            //System.Threading.Thread.Sleep(200);
                            //fs1.Flush();
                            //fs1.Close();
                            //------------- 



                            Bitmap oBitmap = new Bitmap(ByteToImage(btimg));
                            Graphics oGraphic = Graphics.FromImage(oBitmap);
                            oBitmap.Save(@"" + Connection.GetAccessPathId() + @"Images\" + txtScholarNo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                            oBitmap.Dispose();
                            oGraphic.Dispose();
                            SqlConnection con3 = Connection.Conn();
                            string str3 = "Update tbl_Student set studentimage=@Simage  where scholarno=@scholarno ";
                            SqlCommand cmd3 = new SqlCommand(str3, con3);
                            cmd3.Parameters.AddWithValue("@scholarno", txtScholarNo.Text);
                            cmd3.Parameters.AddWithValue("@Simage", btimg);


                            con3.Open();
                            cmd3.ExecuteNonQuery();
                            con3.Close();
                            PicturePath = null;

                        }
                        else
                        {
                            if (member_pic.Image != null)
                            {
                                btimg = imageToByteArray(member_pic.Image);
                                if (btimg.Length > 0)
                                {
                                    if (GetShortImageBT(btimg))
                                    {
                                        Bitmap oBitmap = new Bitmap(ByteToImage(btimg));
                                        Graphics oGraphic = Graphics.FromImage(oBitmap);
                                        oBitmap.Save(@"" + Connection.GetAccessPathId() + @"Images\" + txtScholarNo.Text + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                        oBitmap.Dispose();
                                        oGraphic.Dispose();
                                        SqlConnection con3 = Connection.Conn();
                                        string str3 = "Update tbl_Student set studentimage=@Simage  where scholarno=@scholarno ";
                                        SqlCommand cmd3 = new SqlCommand(str3, con3);
                                        cmd3.Parameters.AddWithValue("@scholarno", txtScholarNo.Text);
                                        cmd3.Parameters.AddWithValue("@Simage", btimg);


                                        con3.Open();
                                        cmd3.ExecuteNonQuery();
                                        con3.Close();
                                        PicturePath = null;
                                        btimg = null;
                                    }
                                }
                            }
                        }
                        //For docs upload 
                        if (chktc.Checked)
                            UpdateTc(txtstudentno.Text.Trim());
                        if (chksoc.Checked)
                            UpdateSoc(txtstudentno.Text.Trim());
                        if (chkslc.Checked)
                            UpdateSlc(txtstudentno.Text.Trim());
                        if (chkdob.Checked)
                            UpdateDob(txtstudentno.Text.Trim());
                        if (chkms.Checked)
                            UpdateMs(txtstudentno.Text.Trim());
                        if (chkic.Checked)
                            UpdateIc(txtstudentno.Text.Trim());
                        if (chkcc.Checked)
                            UpdateCc(txtstudentno.Text.Trim());
                        //------
                    }
                    if (this.MessageService && add_edit)
                        MessageBox.Show("Record Saved...\n\tMessage Sent To Parents...", "School");
                    else
                        MessageBox.Show("Record Saved...", "School");

                    c.GetMdiParent(this).EnableAllEditMenuButtons();
                    pbxBarCode.Visible = false;
                    
                    DesignForm.fromDesign1(this);
                    strmtongue.Items.Clear();
                    Connection.FillCombo(ref strmtongue, "select distinct m_tongue from tbl_student");
                }
                else { button6.Focus(); }
            }
            //}

            valcmbsession.Enabled = false;

        }
        private void IsScholar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmstudent_Paint(object sender, PaintEventArgs e)
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
        static string dtc, dsoc, dslc, ddob, dms, dic, dcc;
        static string dtct, dsoct, dslct, ddobt, dmst, dict, dcct;
        static byte[] FBdtc = null, FBdsoc = null, FBdslc = null, FBddob = null, FBdms = null, FBdic = null, FBdcc = null;
        static byte[] TFBdtc = null, TFBdsoc = null, TFBdslc = null, TFBddob = null, TFBdms = null, TFBdic = null, TFBdcc = null;
        public void GetTc()
        {
            dtc = string.Empty;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select file to be upload";
            //fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            fDialog.Filter = "PDF Files|*.pdf|Word Document File(*.doc)|*.doc|Word Document File(*.docx)|*.docx|Excel File(*.xlx)|*.xlx|Excel File(*.xlsx)|*.xlsx|Image File(*.jpg)|*.jpg|Image File(*.jpeg)|*.jpeg";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                dtc = fDialog.FileName.ToString();
            }
            else
            {
                chktc.Checked = false;
            }
        }
        public void UpdateTc(string StudentNo)
        {
            string filetype;
            string filename;

            if (!string.IsNullOrEmpty(dtc))
            {

                filename = dtc.Substring(Convert.ToInt32(dtc.LastIndexOf("\\")) + 1, dtc.Length - (Convert.ToInt32(dtc.LastIndexOf("\\")) + 1));
                filetype = dtc.Substring(Convert.ToInt32(dtc.LastIndexOf(".")) + 1, dtc.Length - (Convert.ToInt32(dtc.LastIndexOf(".")) + 1));

                //Validate user upload only specific bytes - un comment below lines if you need to validate only PDF files



                try
                {
                    // Open file to read using file path
                    FileStream FS = new FileStream(dtc, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // Add filestream to binary reader
                    BinaryReader BR = new BinaryReader(FS);

                    // get total byte length of the file
                    long allbytes = new FileInfo(dtc).Length;

                    // read entire file into buffer
                    FBdtc = BR.ReadBytes((Int32)allbytes);

                    // close all instances
                    FS.Close();
                    FS.Dispose();
                    BR.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Error during File Read " + ex.ToString());
                }
                int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_StudentDocs where StudentNo='" + StudentNo + "'"));
                string str1 = string.Empty;
                if (CCEID < 1)
                {
                    str1 = "insert into tbl_StudentDocs(StudentNo,TCFile,TCType) values(@StudentNo,@TCFile,@TCType)";
                }
                else
                {
                    str1 = "Update tbl_StudentDocs set TCFile=@TCFile,TCType=@TCType where StudentNo=@StudentNo ";
                }
                //Store File Bytes in database image filed 
                SqlConnection con = Connection.Conn();
                SqlCommand cmd = new SqlCommand(str1, con);
                cmd.Parameters.AddWithValue("@StudentNo", StudentNo);
                cmd.Parameters.AddWithValue("@TCFile", FBdtc);
                cmd.Parameters.AddWithValue("@TCType", filetype);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void GetSoc()
        {
            dsoc = string.Empty;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select file to be upload";
            //fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            fDialog.Filter = "PDF Files|*.pdf|Word Document File(*.doc)|*.doc|Word Document File(*.docx)|*.docx|Excel File(*.xlx)|*.xlx|Excel File(*.xlsx)|*.xlsx|Image File(*.jpg)|*.jpg|Image File(*.jpeg)|*.jpeg";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                dsoc = fDialog.FileName.ToString();
            }
            else
            {
                chksoc.Checked = false;
            }
        }
        public void UpdateSoc(string StudentNo)
        {
            string filetype;
            string filename;

            if (!string.IsNullOrEmpty(dsoc))
            {

                filename = dsoc.Substring(Convert.ToInt32(dsoc.LastIndexOf("\\")) + 1, dsoc.Length - (Convert.ToInt32(dsoc.LastIndexOf("\\")) + 1));
                filetype = dsoc.Substring(Convert.ToInt32(dsoc.LastIndexOf(".")) + 1, dsoc.Length - (Convert.ToInt32(dsoc.LastIndexOf(".")) + 1));

                //Validate user upload only specific bytes - un comment below lines if you need to validate only PDF files



                try
                {
                    // Open file to read using file path
                    FileStream FS = new FileStream(dsoc, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // Add filestream to binary reader
                    BinaryReader BR = new BinaryReader(FS);

                    // get total byte length of the file
                    long allbytes = new FileInfo(dsoc).Length;

                    // read entire file into buffer
                    FBdsoc = BR.ReadBytes((Int32)allbytes);

                    // close all instances
                    FS.Close();
                    FS.Dispose();
                    BR.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Error during File Read " + ex.ToString());
                }
                int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_StudentDocs where StudentNo='" + StudentNo + "'"));
                string str1 = string.Empty;
                if (CCEID < 1)
                {
                    str1 = "insert into tbl_StudentDocs(StudentNo,SOCFile,SOCType) values(@StudentNo,@SOCFile,@SOCType)";
                }
                else
                {
                    str1 = "Update tbl_StudentDocs set SOCFile=@SOCFile,SOCType=@SOCType where StudentNo=@StudentNo ";
                }
                //Store File Bytes in database image filed 
                SqlConnection con = Connection.Conn();
                SqlCommand cmd = new SqlCommand(str1, con);
                cmd.Parameters.AddWithValue("@StudentNo", StudentNo);
                cmd.Parameters.AddWithValue("@SOCFile", FBdsoc);
                cmd.Parameters.AddWithValue("@SOCType", filetype);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void GetSlc()
        {
            dslc = string.Empty;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select file to be upload";
            //fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            fDialog.Filter = "PDF Files|*.pdf|Word Document File(*.doc)|*.doc|Word Document File(*.docx)|*.docx|Excel File(*.xlx)|*.xlx|Excel File(*.xlsx)|*.xlsx|Image File(*.jpg)|*.jpg|Image File(*.jpeg)|*.jpeg";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                dslc = fDialog.FileName.ToString();
            }
            else
            {
                chkslc.Checked = false;
            }
        }
        public void UpdateSlc(string StudentNo)
        {
            string filetype;
            string filename;

            if (!string.IsNullOrEmpty(dslc))
            {

                filename = dslc.Substring(Convert.ToInt32(dslc.LastIndexOf("\\")) + 1, dslc.Length - (Convert.ToInt32(dslc.LastIndexOf("\\")) + 1));
                filetype = dslc.Substring(Convert.ToInt32(dslc.LastIndexOf(".")) + 1, dslc.Length - (Convert.ToInt32(dslc.LastIndexOf(".")) + 1));

                //Validate user upload only specific bytes - un comment below lines if you need to validate only PDF files



                try
                {
                    // Open file to read using file path
                    FileStream FS = new FileStream(dslc, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // Add filestream to binary reader
                    BinaryReader BR = new BinaryReader(FS);

                    // get total byte length of the file
                    long allbytes = new FileInfo(dslc).Length;

                    // read entire file into buffer
                    FBdslc = BR.ReadBytes((Int32)allbytes);

                    // close all instances
                    FS.Close();
                    FS.Dispose();
                    BR.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Error during File Read " + ex.ToString());
                }
                int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_StudentDocs where StudentNo='" + StudentNo + "'"));
                string str1 = string.Empty;
                if (CCEID < 1)
                {
                    str1 = "insert into tbl_StudentDocs(StudentNo,SLCFile,SLCType) values(@StudentNo,@SLCFile,@SLCType)";
                }
                else
                {
                    str1 = "Update tbl_StudentDocs set SLCFile=@SLCFile,SLCType=@SLCType where StudentNo=@StudentNo ";
                }
                //Store File Bytes in database image filed 
                SqlConnection con = Connection.Conn();
                SqlCommand cmd = new SqlCommand(str1, con);
                cmd.Parameters.AddWithValue("@StudentNo", StudentNo);
                cmd.Parameters.AddWithValue("@SLCFile", FBdslc);
                cmd.Parameters.AddWithValue("@SLCType", filetype);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void GetDob()
        {
            ddob = string.Empty;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select file to be upload";
            //fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            fDialog.Filter = "PDF Files|*.pdf|Word Document File(*.doc)|*.doc|Word Document File(*.docx)|*.docx|Excel File(*.xlx)|*.xlx|Excel File(*.xlsx)|*.xlsx|Image File(*.jpg)|*.jpg|Image File(*.jpeg)|*.jpeg";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                ddob = fDialog.FileName.ToString();
            }
            else
            {
                chkdob.Checked = false;
            }
        }
        public void UpdateDob(string StudentNo)
        {
            string filetype;
            string filename;

            if (!string.IsNullOrEmpty(ddob))
            {

                filename = ddob.Substring(Convert.ToInt32(ddob.LastIndexOf("\\")) + 1, ddob.Length - (Convert.ToInt32(ddob.LastIndexOf("\\")) + 1));
                filetype = ddob.Substring(Convert.ToInt32(ddob.LastIndexOf(".")) + 1, ddob.Length - (Convert.ToInt32(ddob.LastIndexOf(".")) + 1));

                //Validate user upload only specific bytes - un comment below lines if you need to validate only PDF files



                try
                {
                    // Open file to read using file path
                    FileStream FS = new FileStream(ddob, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // Add filestream to binary reader
                    BinaryReader BR = new BinaryReader(FS);

                    // get total byte length of the file
                    long allbytes = new FileInfo(ddob).Length;

                    // read entire file into buffer
                    FBddob = BR.ReadBytes((Int32)allbytes);

                    // close all instances
                    FS.Close();
                    FS.Dispose();
                    BR.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Error during File Read " + ex.ToString());
                }
                int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_StudentDocs where StudentNo='" + StudentNo + "'"));
                string str1 = string.Empty;
                if (CCEID < 1)
                {
                    str1 = "insert into tbl_StudentDocs(StudentNo,DOBFile,DOBType) values(@StudentNo,@DOBFile,@DOBType)";
                }
                else
                {
                    str1 = "Update tbl_StudentDocs set DOBFile=@DOBFile,DOBType=@DOBType where StudentNo=@StudentNo ";
                }
                //Store File Bytes in database image filed 
                SqlConnection con = Connection.Conn();
                SqlCommand cmd = new SqlCommand(str1, con);
                cmd.Parameters.AddWithValue("@StudentNo", StudentNo);
                cmd.Parameters.AddWithValue("@DOBFile", FBddob);
                cmd.Parameters.AddWithValue("@DOBType", filetype);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void GetMs()
        {
            dms = string.Empty;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select file to be upload";
            //fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            fDialog.Filter = "PDF Files|*.pdf|Word Document File(*.doc)|*.doc|Word Document File(*.docx)|*.docx|Excel File(*.xlx)|*.xlx|Excel File(*.xlsx)|*.xlsx|Image File(*.jpg)|*.jpg|Image File(*.jpeg)|*.jpeg";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                dms = fDialog.FileName.ToString();
            }
            else
            {
                chkms.Checked = false;
            }
        }
        public void UpdateMs(string StudentNo)
        {
            string filetype;
            string filename;

            if (!string.IsNullOrEmpty(dms))
            {

                filename = dms.Substring(Convert.ToInt32(dms.LastIndexOf("\\")) + 1, dms.Length - (Convert.ToInt32(dms.LastIndexOf("\\")) + 1));
                filetype = dms.Substring(Convert.ToInt32(dms.LastIndexOf(".")) + 1, dms.Length - (Convert.ToInt32(dms.LastIndexOf(".")) + 1));

                //Validate user upload only specific bytes - un comment below lines if you need to validate only PDF files



                try
                {
                    // Open file to read using file path
                    FileStream FS = new FileStream(dms, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // Add filestream to binary reader
                    BinaryReader BR = new BinaryReader(FS);

                    // get total byte length of the file
                    long allbytes = new FileInfo(dms).Length;

                    // read entire file into buffer
                    FBdms = BR.ReadBytes((Int32)allbytes);

                    // close all instances
                    FS.Close();
                    FS.Dispose();
                    BR.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Error during File Read " + ex.ToString());
                }
                int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_StudentDocs where StudentNo='" + StudentNo + "'"));
                string str1 = string.Empty;
                if (CCEID < 1)
                {
                    str1 = "insert into tbl_StudentDocs(StudentNo,MSFile,MSType) values(@StudentNo,@MSFile,@MSType)";
                }
                else
                {
                    str1 = "Update tbl_StudentDocs set MSFile=@MSFile,MSType=@MSType where StudentNo=@StudentNo ";
                }
                //Store File Bytes in database image filed 
                SqlConnection con = Connection.Conn();
                SqlCommand cmd = new SqlCommand(str1, con);
                cmd.Parameters.AddWithValue("@StudentNo", StudentNo);
                cmd.Parameters.AddWithValue("@MSFile", FBdms);
                cmd.Parameters.AddWithValue("@MSType", filetype);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void GetIc()
        {
            dic = string.Empty;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select file to be upload";
            //fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            fDialog.Filter = "PDF Files|*.pdf|Word Document File(*.doc)|*.doc|Word Document File(*.docx)|*.docx|Excel File(*.xlx)|*.xlx|Excel File(*.xlsx)|*.xlsx|Image File(*.jpg)|*.jpg|Image File(*.jpeg)|*.jpeg";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                dic = fDialog.FileName.ToString();
            }
            else
            {
                chkic.Checked = false;
            }
        }
        public void UpdateIc(string StudentNo)
        {
            string filetype;
            string filename;

            if (!string.IsNullOrEmpty(dic))
            {

                filename = dic.Substring(Convert.ToInt32(dic.LastIndexOf("\\")) + 1, dic.Length - (Convert.ToInt32(dic.LastIndexOf("\\")) + 1));
                filetype = dic.Substring(Convert.ToInt32(dic.LastIndexOf(".")) + 1, dic.Length - (Convert.ToInt32(dic.LastIndexOf(".")) + 1));

                //Validate user upload only specific bytes - un comment below lines if you need to validate only PDF files



                try
                {
                    // Open file to read using file path
                    FileStream FS = new FileStream(dic, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // Add filestream to binary reader
                    BinaryReader BR = new BinaryReader(FS);

                    // get total byte length of the file
                    long allbytes = new FileInfo(dic).Length;

                    // read entire file into buffer
                    FBdic = BR.ReadBytes((Int32)allbytes);

                    // close all instances
                    FS.Close();
                    FS.Dispose();
                    BR.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Error during File Read " + ex.ToString());
                }
                int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_StudentDocs where StudentNo='" + StudentNo + "'"));
                string str1 = string.Empty;
                if (CCEID < 1)
                {
                    str1 = "insert into tbl_StudentDocs(StudentNo,ICFile,ICType) values(@StudentNo,@ICFile,@ICType)";
                }
                else
                {
                    str1 = "Update tbl_StudentDocs set ICFile=@ICFile,ICType=@ICType where StudentNo=@StudentNo ";
                }
                //Store File Bytes in database image filed 
                SqlConnection con = Connection.Conn();
                SqlCommand cmd = new SqlCommand(str1, con);
                cmd.Parameters.AddWithValue("@StudentNo", StudentNo);
                cmd.Parameters.AddWithValue("@ICFile", FBdic);
                cmd.Parameters.AddWithValue("@ICType", filetype);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        public void GetCc()
        {
            dcc = string.Empty;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Select file to be upload";
            //fDialog.Filter = "PDF Files|*.pdf|All Files|*.*";
            fDialog.Filter = "PDF Files|*.pdf|Word Document File(*.doc)|*.doc|Word Document File(*.docx)|*.docx|Excel File(*.xlx)|*.xlx|Excel File(*.xlsx)|*.xlsx|Image File(*.jpg)|*.jpg|Image File(*.jpeg)|*.jpeg";
            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                dcc = fDialog.FileName.ToString();
            }
            else
            {
                chkcc.Checked = false;
            }
        }
        public void UpdateCc(string StudentNo)
        {
            string filetype;
            string filename;

            if (!string.IsNullOrEmpty(dcc))
            {

                filename = dcc.Substring(Convert.ToInt32(dcc.LastIndexOf("\\")) + 1, dcc.Length - (Convert.ToInt32(dcc.LastIndexOf("\\")) + 1));
                filetype = dcc.Substring(Convert.ToInt32(dcc.LastIndexOf(".")) + 1, dcc.Length - (Convert.ToInt32(dcc.LastIndexOf(".")) + 1));

                //Validate user upload only specific bytes - un comment below lines if you need to validate only PDF files



                try
                {
                    // Open file to read using file path
                    FileStream FS = new FileStream(dcc, System.IO.FileMode.Open, System.IO.FileAccess.Read);

                    // Add filestream to binary reader
                    BinaryReader BR = new BinaryReader(FS);

                    // get total byte length of the file
                    long allbytes = new FileInfo(dcc).Length;

                    // read entire file into buffer
                    FBdcc = BR.ReadBytes((Int32)allbytes);

                    // close all instances
                    FS.Close();
                    FS.Dispose();
                    BR.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Error during File Read " + ex.ToString());
                }
                int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_StudentDocs where StudentNo='" + StudentNo + "'"));
                string str1 = string.Empty;
                if (CCEID < 1)
                {
                    str1 = "insert into tbl_StudentDocs(StudentNo,CCFile,CCType) values(@StudentNo,@CCFile,@CCType)";
                }
                else
                {
                    str1 = "Update tbl_StudentDocs set CCFile=@CCFile,CCType=@CCType where StudentNo=@StudentNo ";
                }
                //Store File Bytes in database image filed 
                SqlConnection con = Connection.Conn();
                SqlCommand cmd = new SqlCommand(str1, con);
                cmd.Parameters.AddWithValue("@StudentNo", StudentNo);
                cmd.Parameters.AddWithValue("@CCFile", FBdcc);
                cmd.Parameters.AddWithValue("@CCType", filetype);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        private void chktc_CheckedChanged(object sender, EventArgs e)
        {
            if (tcflag.Equals("Y"))
                if (chktc.Checked)
                    GetTc();

        }

        private void chksoc_CheckedChanged(object sender, EventArgs e)
        {
            if (tcflag.Equals("Y"))
                if (chksoc.Checked)
                    GetSoc();
        }

        private void chkslc_CheckedChanged(object sender, EventArgs e)
        {
            if (tcflag.Equals("Y"))
                if (chkslc.Checked)
                    GetSlc();
        }

        private void chkdob_CheckedChanged(object sender, EventArgs e)
        {
            if (tcflag.Equals("Y"))
                if (chkdob.Checked)
                    GetDob();
        }

        private void chkms_CheckedChanged(object sender, EventArgs e)
        {
            if (tcflag.Equals("Y"))
                if (chkms.Checked)
                    GetMs();
        }

        private void chkic_CheckedChanged(object sender, EventArgs e)
        {
            if (tcflag.Equals("Y"))
                if (chkic.Checked)
                    GetIc();
        }

        private void chkcc_CheckedChanged(object sender, EventArgs e)
        {
            if (tcflag.Equals("Y"))
                if (chkcc.Checked)
                    GetCc();
        }
        private void pictc_Click(object sender, EventArgs e)
        {
            FileStream FS = null;
            byte[] dbbyte;
            SqlConnection con = Connection.Conn();
            SqlCommand cmd = new SqlCommand("select TCFile,TCType from tbl_StudentDocs where StudentNo='" + txtstudentno.Text.Trim() + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                //Get a stored PDF bytes
                dbbyte = (byte[])dt.Rows[0]["TCFile"];

                //store file Temporarily 
                string filepath = @"D:\\StudentTCDocs." + dt.Rows[0]["TCType"].ToString();


                //Assign File path create file
                FS = new FileStream(filepath, System.IO.FileMode.Create);

                //Write bytes to create file
                FS.Write(dbbyte, 0, dbbyte.Length);

                //Close FileStream instance
                FS.Close();


                // Open fila after write 

                //Create instance for process class
                Process Proc = new Process();

                //assign file path for process
                Proc.StartInfo.FileName = filepath;
                Proc.Start();
            }

        }

        private void txtfincome_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) && (!e.Shift)) ||
e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || e.KeyCode ==
Keys.Alt || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
e.KeyCode == Keys.Shift || e.KeyCode == Keys.Home || e.KeyCode ==
Keys.End || e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Enter))


                e.SuppressKeyPress = true;
        }


        private void lblCast_Click(object sender, EventArgs e)
        {

        }

        //private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    if (checkBox1.Checked)
        //    {
        //        txtStudentName.Font = new Font("Mangal", 10);
        //        txtfather.Font = new Font("Mangal", 10);
        //    }
        //    else

        //    {
        //        txtStudentName.Font = new Font("Times New Roman", 10);
        //        txtfather.Font = new Font("Times New Roman", 10);
        //    }
        //}








    }
}

