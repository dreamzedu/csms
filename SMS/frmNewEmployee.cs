using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;  

namespace SMS
{
    public partial class frmNewEmployee :UserControlBase
    {
        int count = 0;
        school c = new school();
        byte[] EmpImage;
        private string PicturePath = string.Empty;
        Image img, imgClear;
        String photo = "F:\\Data\\BlankImg.jpeg";
        decimal daamt, daper, basic, hra, pfper, pfamt, esicper, esicamt, SalaryRate;
        string gender;
        int isactive,ispermanent;        
        ErrorProvider errorProvider1 = new ErrorProvider();
        TextInfo myTextInfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;


        public frmNewEmployee()
        {
            InitializeComponent(); 
            Connection.SetUserControlTheme(this);
        }
        private void frmNewEmployee_Load(object sender, EventArgs e)
        {
            try
            {
                img = imgemployee.Image;
                imgClear = img;
                c.getconnstr();
                DataSet dsEmpType = Connection.GetDataSet("SELECT EmpTypeId, Detail, allowleaves FROM  tbl_EmployeeType");
                if (dsEmpType != null)
                {
                    cmbEmpType.DataSource = dsEmpType.Tables[0];
                    cmbEmpType.DisplayMember = "Detail";
                    cmbEmpType.ValueMember = "EmpTypeId";
                    cmbEmpType.Text = "-Select-";
                }
                txtEmployeeNo.Text = Connection.NewCode("EMP");
                EnabledFalseAllControl();
                Connection.SetUserLevelAuth(c.GetMdiParent(this));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }
       
        public override void btnsave_Click(object sender, EventArgs e)
        {
            SqlTransaction trn = null;

            
            try
            {
                //if( EmpImage!=null)
               
                    if (txtEmployeeNo.Text != "")
                    {
                        int a = checkMandatary();
                        if (a == 1)
                        {
                            return;
                        }
                        if (rdoMale.Checked == true)
                            gender = "M";
                        else
                            gender = "F";
                        if (chkIsActive.Checked == true)
                            isactive = 1;
                        else
                            isactive = 0;
                        if (CHKPermanent.Checked == true)
                            ispermanent = 1;
                        else
                            ispermanent = 0;
                        trn = Connection.GetMyConnection().BeginTransaction();
                        Connection.SqlTransection("insert into tbl_employeeinfo (EmpNo,EmpTypeId, EmpName,Qualification,Experience, DOJ, DOB, Gender, FathersName, Address, IsActive, salaryrate, pf, lic, loan, designation, photo, rsa, aleave,pfnumber, el, splinctv, EnCLLeave, DA, HRA, contactno, DAAmt, PFAmt, NetSalary,ESIC,ESICAmt,AccountNo,BankName,ML,IsPermanent) values('" + txtEmployeeNo.Text + "','" + cmbEmpType.SelectedValue + "','" + myTextInfo.ToTitleCase(txtEmpName.Text) + "', '" + txtQualification.Text + "','" + txtExperience.Text + "','" + dtpDOJ.Value + "','" + dtpDOB.Value + "','" + gender + "','" + myTextInfo.ToTitleCase(txtFatherName.Text) + "','" + txtAddress.Text + "','" + isactive + "','" + txtsalaryrate.Text + "','" + txtpfPer.Text + "','" + txtLICdeduction.Text + "','" + txtLoanDeduction.Text + "','" + txtDesignation.Text + "','" + EmpImage + "','" + txtSpcAllowence.Text + "','" + txtAllowedCL.Text + "','" + txtPFno.Text + "','" + txtAllowedEL.Text + "','" + txtSpcIncentive.Text + "','" + txtAllowedCL.Text + "','" + txtda.Text + "','" + txthra.Text + "','" + txtcontactno.Text + "','" + txtdaamt.Text + "','" + txtpfamt.Text + "','" + txtsalaryrate.Text + "','" + txtESICPer.Text + "','" + txtESICAmt.Text + "','" + txtAccountNo.Text + "','" + txtBankName.Text + "','" + txtML.Text + "','" + ispermanent + "')", Connection.MyConnection, trn);
                        Connection.SqlTransection("insert into tbl_employeesalaryinfo (empno, startdate, status, salaryrate, pf, lic, loan, rsa, aleave, pfnumber, el, splinctv, EnCLLeave, DA, HRA, IsActive, DAAmt, PFAmt, NetSalary,ESIC,ESICAmt,ML) values('" + txtEmployeeNo.Text + "','" + dtpDOJ.Value + "',1,'" + txtsalaryrate.Text + "','" + txtpfPer.Text + "','" + txtLICdeduction.Text + "','" + txtLoanDeduction.Text + "','" + txtSpcAllowence.Text + "','" + txtAllowedCL.Text + "','" + txtPFno.Text + "','" + txtAllowedEL.Text + "','" + txtSpcIncentive.Text + "','" + txtAllowedCL.Text + "','" + txtda.Text + "','" + txthra.Text + "','" + isactive + "','" + txtdaamt.Text + "','" + txtpfamt.Text + "','" + txtsalaryrate.Text + "','" + txtESICPer.Text + "','" + txtESICAmt.Text + "','" + txtML.Text + "')", Connection.MyConnection, trn);
                        string mstudentno = Convert.ToString(Connection.GetExecuteScalar("select IsNull((max(accode)+1),1001) from tbl_account"));
                        int i = Convert.ToInt32(Connection.GetExecuteScalar("select count(*) from tbl_account where acname='" + txtEmpName.Text + "'"));
                        if (i == 0)
                        {
                            txtacno.Text = mstudentno;
                            Connection.SqlTransection("insert into tbl_account (accode,acname,actype,acopbal,acoptype,accaddress,budgtype,opdate,subledger,issaldeduct) values(" + txtacno.Text + ",'" + txtEmpName.Text + "',14,0,'Dr','" + txtAddress.Text + "',0,'" + dtpDOJ.Value + "',1,0)", Connection.MyConnection, trn);
                        }
                        Connection.SqlTransection("insert into tbl_subledger_account (subledgercode,accode) values ('" + txtacno.Text + "','116')", Connection.MyConnection, trn);
                        Connection.SqlTransection("Update tbl_Code set CodeNo='" + txtEmployeeNo.Text.Trim() + "' where CodeName='EMP'", Connection.MyConnection, trn);
                        trn.Commit();
                        if (!string.IsNullOrEmpty(PicturePath))
                        {
                            if (Limit(PicturePath))
                            {

                                Bitmap oBitmap = new Bitmap(ByteToImage(btimg));
                                Graphics oGraphic = Graphics.FromImage(oBitmap);
                                oBitmap.Save(@"" + Connection.GetAccessPathId() + @"Images\a\" + txtEmployeeNo.Text + ".jpg", ImageFormat.Jpeg);
                                oBitmap.Dispose();
                                oGraphic.Dispose();

                                SqlConnection con = Connection.Conn();
                                SqlCommand cmd = new SqlCommand("update tbl_employeeinfo set photo=@photo where Empno='" + txtEmployeeNo.Text + "'", con);
                                cmd.Parameters.AddWithValue("@photo", btimg);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        MessageBox.Show("Record Saved Successfully.");
                        clearAllControl();
                    }
                    else
                    {
                        MessageBox.Show("Please Insert Record Carefully.");
                        return;
                    }
            }
            catch (Exception ex)
            {
                trn.Rollback();
                Logger.LogError(ex); 
                MessageBox.Show("Some Record Missin!!! \n\tPlease Try Again.");
            }
        }
         
        private void cmbEmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //DataSet ds = Connection.GetDataSet("select emptypeid from tbl_EmployeeType  where Detail='" + cmbEmpType.SelectedItem.ToString() + "'");
                //if (ds.Tables[0].Rows[0][0] != DBNull.Value)
                //{
                //    EnpTypeID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                //}
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            //OpenFileDialog  photo=new OpenFileDialog ();
            try
            {
               // openFileDialog1.InitialDirectory = @"c:\";
                OpenFileDialog op = new OpenFileDialog();
                DialogResult result = op.ShowDialog();
                op.Filter = "[JPEG,JPG]|*.jpg";

                if (result == DialogResult.OK)
                {
                    //photo = openFileDialog1.FileName;
                    //imgemployee.ImageLocation = photo;
                    //imgemployee.Image = 
                    string ext=Path .GetExtension (op.FileName );                                
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".jpe" || ext == ".gif" || ext == ".bmp" || ext == ".png" || ext == ".JPG" || ext == ".JPEG" || ext == ".JPE" || ext == ".GIF" || ext == ".BMP" || ext == ".PNG")
                {
                    Bitmap bmp = new Bitmap(op.FileName);
                    imgemployee.Image = (Image)bmp;
                    EmpImage = ImageToByte(imgemployee.Image);                    
                    PicturePath = op.FileName;
                    count = 1;
                }
                    else 
                {
                    MessageBox .Show ("Only Image Allowed.");
                    return ;
                }
                }
                else
                {
                    count = 0;
                   
                  //  EmpImage = ImageToByte(img);
                }
            }
            catch(Exception ex) 
            {
                Logger.LogError(ex); MessageBox.Show(ex.Message);
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ////this.Close();
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            EmpImage = ImageToByte(imgemployee.Image);
            txtEmployeeNo.ReadOnly = true;
            clearAllControl();
            //btnUpdate.Enabled = false;            
           c.GetMdiParent(this).ToggleSaveButton(true);
            EnabledTrueAllControl ();
            txtEmpName.Focus();
            Connection.SetUserLevelAuth(c.GetMdiParent(this));
           
        }
        private void clearAllControl()
        {
            txtEmployeeNo.Text = "";
            txtEmpName.Text = "";
            txtFatherName.Text = "";
            txtcontactno.Text = "";
            cmbEmpType.Text = "";
            txtDesignation.Text = "";
            txtQualification.Text = "";
            txtExperience.Text="";
            dtpDOJ.Text = DateTime.Now.ToShortDateString();
            dtpDOB.Text = "01/01/1900";
            txtAddress.Text = "";
            txtsalaryrate.Text = "0";
            txtda.Text = "0";
            txtdaamt.Text = "0";
            txtSpcAllowence.Text = "0";
            txthra.Text = "0";
            txtSpcIncentive.Text = "0";
            txtLICdeduction.Text = "0";
            txtLoanDeduction.Text = "0";
            txtPFno.Text = "0";
            txtpfPer.Text = "0";
            txtpfamt.Text = "0";
            txtAllowedEL.Text = "0";
            txtAllowedCL.Text = "0";
            rdoMale.Checked = true;
            txtESICAmt.Text = "0"; ;
            txtESICPer.Text = "0"; ;
            txtAccountNo.Text = "";
            txtBankName.Text = "";
            txtML.Text  = "0";
            imgemployee.Image = imgClear;
            // imgemployee.ImageLocation = "F:\\Data\\BlankImg.jpeg";
            txtEmployeeNo.ReadOnly = true;
            txtEmpName.Focus();
           c.GetMdiParent(this).ToggleEditButton(true);
            //btnUpdate.Enabled = false;
            txtML.Enabled = true;
            txtEmployeeNo.Text = Connection.NewCode("EMP");
            gbxSalaryRateChange.Visible = false;
            txtMachineID.Text = "";
            lblMID.Visible = txtMachineID.Visible = false;
            txtEmpName.Focus();
      }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            clearAllControl();
            Connection.SetUserLevelAuth(c.GetMdiParent(this));
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                txtEmployeeNo.ReadOnly = false;
                txtEmployeeNo.SelectAll();
                txtEmployeeNo.Focus();
                // btnSave.Text = "Update";
                //btnUpdate.Enabled = true;
               c.GetMdiParent(this).ToggleEditButton(false);
               c.GetMdiParent(this).ToggleSaveButton(false);
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtEmployeeNo_Validated(object sender, EventArgs e)
        {
            try
            {
                if (txtEmployeeNo.ReadOnly == false)
                {
                    EnabledTrueAllControl();
                    string s = "  select EmpTypeId,EmpName,Qualification,Experience, DOJ,DOB,Gender,FathersName,Address,IsActive,salaryrate,pf,lic,loan,designation,photo,rsa,aleave,ele,pfnumber,el,elbal,splinctv,EnCLLeave,contactno,DA,hra,ESIC,ESICAmt,AccountNo,BankName,IsPermanent,Qualification, Experience, AttendanceID from tbl_EmployeeInfo  where  EmpNo='" + txtEmployeeNo.Text.Trim() + "' ";
                    DataSet ds = Connection.GetDataSet(s);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int n = Convert.ToInt32(ds.Tables[0].Rows[0]["emptypeid"].ToString());
                        DataSet ds1 = Connection.GetDataSet("select detail from tbl_employeetype where emptypeid='" + n + "'");
                        string gen = ds.Tables[0].Rows[0]["gender"].ToString().Trim();
                        if (gen == "M")
                        {
                            rdoMale.Checked = true;
                            rdoFemale.Checked = false;
                        }
                        else
                        {
                            rdoFemale.Checked = true;
                            rdoMale.Checked = false;
                        }
                        
                        if (ds.Tables[0].Rows[0]["isactive"].ToString() == "1")
                            chkIsActive.Checked = true;
                        else
                            chkIsActive.Checked = false;
                        if (ds.Tables[0].Rows[0]["IsPermanent"].ToString() == "1")
                            CHKPermanent.Checked = true;
                        else
                            CHKPermanent.Checked = false;
                        // imgemployee.ImageLocation = getImageData(txtEmployeeNo.Text.Trim());
                        txtEmpName.Text = ds.Tables[0].Rows[0]["EmpName"].ToString();
                        txtFatherName.Text = ds.Tables[0].Rows[0]["FathersName"].ToString();
                        cmbEmpType.Text = ds1.Tables[0].Rows[0][0].ToString();
                        txtDesignation.Text = ds.Tables[0].Rows[0]["designation"].ToString();
                        dtpDOJ.Text = ds.Tables[0].Rows[0]["doj"].ToString();
                        dtpDOB.Text = ds.Tables[0].Rows[0]["dob"].ToString();
                        txtQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
                        txtExperience.Text = ds.Tables[0].Rows[0]["Experience"].ToString();
                        txtAddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                        txtsalaryrate.Text = ds.Tables[0].Rows[0]["salaryrate"].ToString();
                        txtSpcAllowence.Text = ds.Tables[0].Rows[0]["rsa"].ToString();
                        txtPFno.Text = ds.Tables[0].Rows[0]["pfnumber"].ToString();
                        txtpfPer.Text = ds.Tables[0].Rows[0]["pf"].ToString();
                        txtLICdeduction.Text = ds.Tables[0].Rows[0]["lic"].ToString();
                        txtLoanDeduction.Text = ds.Tables[0].Rows[0]["loan"].ToString();
                        txtSpcIncentive.Text = ds.Tables[0].Rows[0]["splinctv"].ToString();
                        txtAllowedCL.Text = ds.Tables[0].Rows[0]["aleave"].ToString();
                        txtClEnjoyed.Text = ds.Tables[0].Rows[0]["enclleave"].ToString();
                        txtAllowedEL.Text = ds.Tables[0].Rows[0]["el"].ToString();
                        txtELenjoyed.Text = ds.Tables[0].Rows[0]["ele"].ToString();
                        txtcontactno.Text = ds.Tables[0].Rows[0]["contactno"].ToString();
                        txtda.Text = ds.Tables[0].Rows[0]["da"].ToString();
                        txthra.Text = ds.Tables[0].Rows[0]["hra"].ToString();
                        txtESICPer.Text = ds.Tables[0].Rows[0]["ESIC"].ToString();
                        txtESICAmt.Text = ds.Tables[0].Rows[0]["ESICAmt"].ToString();
                        txtAccountNo.Text = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                        txtBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                        txtMachineID .Text = ds.Tables[0].Rows[0]["AttendanceID"].ToString();
                        ////7-Aug By Gtl
                        SalaryRate = Convert .ToDecimal(ds.Tables[0].Rows[0]["salaryrate"]);

                        try
                        {
                            byte[] b = (byte[])ds.Tables[0].Rows[0]["photo"];
                            imgemployee.Image = ByteToImage(b);
                            EmpImage = ImageToByte(imgemployee.Image);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex); 
                        }
                        lblMID.Visible = txtMachineID.Visible = true;
                        txtsalaryrate.Focus();                   
                }
                    else
                    {
                        MessageBox.Show("Record is not availabe about this identity.");
                        txtEmployeeNo.ReadOnly = true;
                        clearAllControl();
                        EnabledFalseAllControl ();
                        return;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex); MessageBox.Show(ex.Message);
               // clearAllControl();
            }
        }
        private string getImageData(string empno)
        {
            string sp ="";
            DataSet ds1 = Connection.GetDataSet("select photo from tbl_employeeinfo where empno='" + empno + "'");
            Byte[] s = (Byte[])ds1.Tables[0].Rows[0][0];
            ASCIIEncoding ascii = new ASCIIEncoding();
            char[] charArray = ascii.GetChars(s);
            for (int i = 0; i < charArray.Length; i++)
            {
                sp += charArray[i];
            }
            return sp;
        }

           

        private void txtsalaryrate_TextChanged(object sender, EventArgs e)
        {
            if (txtsalaryrate.Text == "")
            {
                txtsalaryrate.Text = "0";
                txtsalaryrate.SelectAll();
            }
            if (ControlValidation.CheckNumericValueOnly1(txtsalaryrate))
            {
                calculateDA();
            }          

        }
        private void calculateDA()
        {
            //basic = Convert.ToDecimal(txtsalaryrate.Text);
            //daper = Convert.ToDecimal(txtda.Text);
            //daamt = (basic * daper) / 100;
            //txtdaamt.Text = Convert.ToString(daamt);
            //esicper  = Convert.ToDecimal(txtESICPer .Text);
            //esicamt  = (basic * esicper) / 100;
            //txtESICAmt.Text = Convert.ToString(esicamt);
            //pfper = Convert.ToDecimal(txtpfPer.Text);
            //pfamt = (basic * pfper ) / 100;
            //txtpfamt.Text = Convert.ToString(pfamt); 

            ///////******************   8-Agu By Gtl For Saraswati Shishu Mandir,
            try
            {
                basic = Convert.ToDecimal(txtsalaryrate.Text);
                daper = Convert.ToDecimal(txtda.Text);
                daamt = (basic * daper) / 100;
                txtdaamt.Text = Convert.ToString(daamt);
                esicper = Convert.ToDecimal(txtESICPer.Text);
                esicamt = (basic * esicper) / 100;
                txtESICAmt.Text = Convert.ToString(esicamt);
                pfper = Convert.ToDecimal(txtpfPer.Text);
                pfamt = ((basic + daamt) * pfper) / 100;
                txtpfamt.Text = Convert.ToString(pfamt);
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
      
        private void txtAddress_Leave(object sender, EventArgs e)
        {
            txtsalaryrate.SelectAll();
        }

        private void txtSpcAllowence_Leave(object sender, EventArgs e)
        {
            txtda.SelectAll();
        }

        private void txtsalaryrate_Leave(object sender, EventArgs e)
        {
            txtSpcAllowence.SelectAll();
        }

        private void txtda_Leave(object sender, EventArgs e)
        {
            txthra.SelectAll();
        }

        private void txthra_Leave(object sender, EventArgs e)
        {
            txtPFno.SelectAll();
        }

        private void txtPFno_Leave(object sender, EventArgs e)
        {
            txtpfPer.SelectAll();
        }

        private void txtLICdeduction_Leave(object sender, EventArgs e)
        {
            txtLoanDeduction.SelectAll();
        }

        private void txtPFcontribution_Leave(object sender, EventArgs e)
        {
            txtda.SelectAll();
        }

        private void txtLoanDeduction_Leave(object sender, EventArgs e)
        {
            txtSpcIncentive.SelectAll();
        }

        private void txtSpcIncentive_Leave(object sender, EventArgs e)
        {
            txtAllowedCL.SelectAll();
        }

        private void txtAllowedCL_Leave(object sender, EventArgs e)
        {
            txtAllowedEL.SelectAll();
        }

        private void txtEmpName_Validating(object sender, CancelEventArgs e)
        {
           ControlValidation.checkEmptyTextBox(txtEmpName );
        }

        private void txtFatherName_Validating(object sender, CancelEventArgs e)
        {
            ControlValidation.CheckalphasOnly(txtFatherName, e);
            txtFatherName.Text = myTextInfo.ToTitleCase(txtFatherName.Text);
        }

        private void txtDesignation_Validating(object sender, CancelEventArgs e)
        {
            //ControlValidation.CheckalphasOnly(txtDesignation , e);
        }

        private void txtsalaryrate_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!txtEmployeeNo.ReadOnly)
                    if (SalaryRate != Convert.ToDecimal(txtsalaryrate.Text))
                    {
                        MessageBox.Show("Salary Rate Is Increased.,\n Please Select Salary Start Date! ", "Attension !!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gbxSalaryRateChange.Visible = true;
                        txtOldSalaryRate.Text = SalaryRate.ToString();
                    }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtcontactno_Validating(object sender, CancelEventArgs e)
        {
            ControlValidation.CheckMobileNumber(txtcontactno, e);
        }

        private void txtSpcAllowence_TextChanged(object sender, EventArgs e)
        {
            if (txtda.Text == "")
            {
                txtSpcAllowence.Text = "0";
                txtSpcAllowence.SelectAll();
            }
            ControlValidation.CheckNumericValueOnly1(txtSpcAllowence );

        }

        private void txtda_TextChanged(object sender, EventArgs e)
        {
           // ControlValidation.CheckNumericValueOnly1(txtda );
            //calculateDA();
            if (txtda.Text == "")
            {
                txtda.Text = "0";
                txtda.SelectAll();
            }
            if (ControlValidation.CheckNumericValueOnly1(txtda))
            {
                calculateDA();
            }
        }

        private void txthra_TextChanged(object sender, EventArgs e)
        {
            if (txthra.Text == "")
            {
                txthra.Text = "0";
                txthra.SelectAll();
            }
            ControlValidation.CheckNumericValueOnly1(txthra);
        }

        private void txtPFcontribution_TextChanged(object sender, EventArgs e)
        {
            //ControlValidation.CheckNumericValueOnly1(txtpfPer);
            //calculateDA();
            if (txtpfPer.Text == "")
            {
                txtpfPer.Text = "0";
                txtpfPer.SelectAll();
            }
            if (ControlValidation.CheckNumericValueOnly1(txtpfPer))
            {
                calculateDA();
            }
            
        }

        private void txtLICdeduction_TextChanged(object sender, EventArgs e)
        {
            if (txtLICdeduction.Text == "")
            {
                txtLICdeduction.Text = "0";
                txtLICdeduction.SelectAll();
            }
            ControlValidation.CheckNumericValueOnly1(txtLICdeduction);
        }

        private void txtLoanDeduction_TextChanged(object sender, EventArgs e)
        {
            if (txtLoanDeduction.Text == "")
            {
                txtLoanDeduction.Text = "0";
                txtLoanDeduction.SelectAll();
            }
            ControlValidation.CheckNumericValueOnly1(txtLoanDeduction );
        }

        private void txtSpcIncentive_TextChanged(object sender, EventArgs e)
        {
            if (txtSpcIncentive.Text == "")
            {
                txtSpcIncentive.Text = "0";
                txtSpcIncentive.SelectAll();
            }
            ControlValidation.CheckNumericValueOnly1(txtSpcIncentive );
        }

        private void txtAllowedCL_TextChanged(object sender, EventArgs e)
        {
            ControlValidation.CheckNumericValueOnly1(txtAllowedCL);
        }

        private void txtAllowedEL_TextChanged(object sender, EventArgs e)
        {
            ControlValidation.CheckNumericValueOnly1(txtAllowedEL);
        }
         
        private void txtFatherName_TextChanged(object sender, EventArgs e)
        {
            //ControlValidation.checkEmptyTextBox(txtFatherName);
            
        }

        private void txtEmpName_TextChanged(object sender, EventArgs e)
        {
            //ControlValidation.checkEmptyTextBox(txtEmpName);
        }

        private void txtDesignation_TextChanged(object sender, EventArgs e)
        {
            ControlValidation.checkEmptyTextBox(txtDesignation);
        }

        private void txtEmpName_Leave(object sender, EventArgs e)
        {
            ControlValidation.checkEmptyTextBox(txtEmpName);
           txtEmpName.Text =myTextInfo.ToTitleCase(txtEmpName.Text);
        }
        private int checkMandatary()
        {
            if (txtEmpName.Text == "")
            {
                MessageBox.Show("Enter Employee Name!", "Error");
                txtEmpName.Focus();
                return 1;
            }
            else if (txtFatherName .Text == "")
            {
                MessageBox.Show("Enter Employee Father or Husband Name!", "Error");
                txtFatherName.Focus();
                return 1;
            }
           
            else if (txtDesignation.Text == "")
            {
                MessageBox.Show("Enter Designation of Employee!", "Error ");
                txtDesignation.Focus();
                return 1;
            }
            else if (txtAddress.Text == "")
            {
                MessageBox.Show("Enter Adress!", "Error ");
                txtAddress.Focus();
                return 1;
            }
           
            else
            {
                return 0;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlTransaction trn = null;
            DialogResult res = new DialogResult();
            TextInfo myTextInfo = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo;
            try
            {
                //if( EmpImage!=null)
                
                        res = MessageBox.Show("Are You Sure To Perform This Operation?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            int a = checkMandatary();
                            if (a == 1)
                                return;
                            if (rdoMale.Checked == true)
                                gender = "M";
                            else
                                gender = "F";
                            if (chkIsActive.Checked == true)
                                isactive = 1;
                            else
                                isactive = 0;

                            if (CHKPermanent.Checked == true)
                                ispermanent = 1;
                            else
                                ispermanent = 0;

                            trn = Connection.GetMyConnection().BeginTransaction();
                            Connection.SqlTransection("update tbl_employeeinfo set EmpTypeId='" + cmbEmpType.SelectedValue + "', EmpName='" + myTextInfo.ToTitleCase(txtEmpName.Text) + "', Qualification = '" + txtQualification.Text + "',Experience = '" + txtExperience.Text + "' ,DOJ='" + dtpDOJ.Value + "', DOB='" + dtpDOB.Value + "', Gender='" + gender + "', FathersName='" + myTextInfo.ToTitleCase(txtFatherName.Text) + "', Address='" + txtAddress.Text + "', IsActive='" + isactive + "', salaryrate='" + txtsalaryrate.Text + "', pf='" + txtpfPer.Text + "', lic='" + txtLICdeduction.Text + "', loan='" + txtLoanDeduction.Text + "', designation=N'" + txtDesignation.Text + "', photo='" + EmpImage + "', rsa='" + txtSpcAllowence.Text + "', aleave='" + txtAllowedCL.Text + "',pfnumber='" + txtPFno.Text + "', el='" + txtAllowedEL.Text + "', splinctv='" + txtSpcIncentive.Text + "', EnCLLeave='" + txtAllowedCL.Text + "', DA='" + txtda.Text + "', HRA='" + txthra.Text + "', contactno='" + txtcontactno.Text + "', DAAmt='" + txtdaamt.Text + "', PFAmt='" + txtpfamt.Text + "', NetSalary='" + txtsalaryrate.Text + "',esic='" + txtESICPer.Text + "',esicamt='" + txtESICAmt.Text + "',accountno='" + txtAccountNo.Text + "',bankname='" + txtBankName.Text + "',ML='" + txtML.Text + "',IsPermanent='" + ispermanent + "', AttendanceID='" + txtMachineID.Text.Trim() + "' where empno='" + txtEmployeeNo.Text + "'", Connection.MyConnection, trn);
                            Connection.SqlTransection("update tbl_employeesalaryinfo set IsActive='" + isactive + "', pf='" + txtpfPer.Text + "', lic='" + txtLICdeduction.Text + "', loan='" + txtLoanDeduction.Text + "', rsa='" + txtSpcAllowence.Text + "', aleave='" + txtAllowedCL.Text + "',pfnumber='" + txtPFno.Text + "', el='" + txtAllowedEL.Text + "', splinctv='" + txtSpcIncentive.Text + "', EnCLLeave='" + txtAllowedCL.Text + "', DA='" + txtda.Text + "', HRA='" + txthra.Text + "', DAAmt='" + txtdaamt.Text + "', PFAmt='" + txtpfamt.Text + "', NetSalary='" + txtsalaryrate.Text + "',esic='" + txtESICPer.Text + "',esicamt='" + txtESICAmt.Text + "',ML='" + txtML.Text + "' where empno='" + txtEmployeeNo.Text + "'", Connection.MyConnection, trn);
                            // Connection.AllPerform();
                            if (SalaryRate != Convert.ToDecimal(txtsalaryrate.Text))
                            {
                                DateTime dtl = dtpSalaryChange.Value.Date.Subtract(new TimeSpan(1, 0, 0, 0));
                                Connection.SqlTransection("update tbl_employeesalaryinfo set enddate='" + dtl.Date + "',status =0 where empno='" + txtEmployeeNo.Text + "' and status=1 ", Connection.MyConnection, trn);
                                Connection.SqlTransection("insert into tbl_employeesalaryinfo (empno, startdate, status, salaryrate, pf, lic, loan, rsa, aleave, pfnumber, el, splinctv, EnCLLeave, DA, HRA, IsActive,DAAmt, PFAmt, NetSalary,ESIC,ESICAmt,ML) values('" + txtEmployeeNo.Text + "','" + dtpSalaryChange.Value + "',1,'" + txtsalaryrate.Text + "','" + txtpfPer.Text + "','" + txtLICdeduction.Text + "','" + txtLoanDeduction.Text + "','" + txtSpcAllowence.Text + "','" + txtAllowedCL.Text + "','" + txtPFno.Text + "','" + txtAllowedEL.Text + "','" + txtSpcIncentive.Text + "','" + txtAllowedCL.Text + "','" + txtda.Text + "','" + txthra.Text + "','" + isactive + "','" + txtdaamt.Text + "','" + txtpfamt.Text + "','" + txtsalaryrate.Text + "','" + txtESICPer.Text + "','" + txtESICAmt.Text + "','" + txtML.Text + "')", Connection.MyConnection, trn);
                            }
                            trn.Commit();
                            try
                            {
                                if (!string.IsNullOrEmpty(PicturePath))
                                {
                                    if (Limit(PicturePath))
                                    {

                                        Bitmap oBitmap = new Bitmap(ByteToImage(btimg));
                                        Graphics oGraphic = Graphics.FromImage(oBitmap);
                                        oBitmap.Save(@"" + Connection.GetAccessPathId() + @"Images\a\" + txtEmployeeNo.Text + ".jpg", ImageFormat.Jpeg);
                                        oBitmap.Dispose();
                                        oGraphic.Dispose();

                                        SqlConnection con = Connection.Conn();
                                        SqlCommand cmd = new SqlCommand("update tbl_employeeinfo set photo=@photo where Empno='" + txtEmployeeNo.Text + "'", con);
                                        cmd.Parameters.AddWithValue("@photo", btimg);
                                        con.Open();
                                        cmd.ExecuteNonQuery();
                                        con.Close();
                                    }
                                }
                            }
                            catch(Exception ex){Logger.LogError(ex); }
                            MessageBox.Show("Employee Record Updated!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            clearAllControl();
                           c.GetMdiParent(this).ToggleEditButton(true);
                            //btnUpdate.Enabled = false;
                            gbxSalaryRateChange.Visible = false;
                        }
                        else
                        {
                            clearAllControl();
                        }
                  
            }
            catch (Exception ex)
            {
                trn.Rollback();
                Logger.LogError(ex); 
                MessageBox.Show("Some Record Missing!!!\n\tPlease Try Again.", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }           
        }

        static byte[] btimg = null;
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
                imgToResize = frmNewEmployee.resizeImage(ToByteArray(path), s1);
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
        private byte[] ImageToByte(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
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
     
        private void EnabledTrueAllControl()
        {
            txtEmpName.Enabled = true;
            txtFatherName.Enabled = true;
            cmbEmpType.Enabled = true;
            txtDesignation.Enabled = true;
            txtQualification.Enabled = true;
            txtExperience.Enabled = true;
            dtpDOJ.Enabled = true;
            dtpDOB.Enabled = true;
            txtAddress.Enabled = true;
            txtsalaryrate.Enabled = true;
            txtSpcAllowence.Enabled = true;
            txtPFno.Enabled = true;
            txtpfPer.Enabled = true;
            txtLICdeduction.Enabled = true;
            txtLoanDeduction.Enabled = true;
            txtSpcIncentive.Enabled = true;
            txtAllowedCL.Enabled = true;
            txtClEnjoyed.Enabled = true;
            txtAllowedEL.Enabled = true;
            txtELenjoyed.Enabled = true;
            txtcontactno.Enabled = true;
            txtda.Enabled = true;
            txthra.Enabled = true;
            txtESICPer.Enabled = true;
            //txtESICAMT.Enabled = true;
            txtBankName .Enabled = true;
            txtAccountNo .Enabled = true;
            GroupBGender.Enabled = true;
            chkIsActive.Enabled = true;
            CHKPermanent.Enabled = true;
            txtML.Enabled = true;
        }
        private void EnabledFalseAllControl()
        {
            txtEmpName.Enabled = false;
            txtFatherName.Enabled = false;
            cmbEmpType.Enabled = false;
            txtDesignation.Enabled = false;
            txtExperience.Enabled = false;
            txtQualification.Enabled = false;
            dtpDOJ.Enabled = false;
            dtpDOB.Enabled = false;
            txtAddress.Enabled = false;
            txtsalaryrate.Enabled = false;
            txtSpcAllowence.Enabled = false;
            txtPFno.Enabled = false;
            txtpfPer.Enabled = false;
            txtLICdeduction.Enabled = false;
            txtLoanDeduction.Enabled = false;
            txtSpcIncentive.Enabled = false;
            txtAllowedCL.Enabled = false;
            txtClEnjoyed.Enabled = false;
            txtAllowedEL.Enabled = false;
            txtELenjoyed.Enabled = false;
            txtcontactno.Enabled = false;
            txtda.Enabled = false;
            txthra.Enabled = false;
            txtESICPer.Enabled = false;
            //txtESICAMT.Enabled = true;
            txtBankName.Enabled = false;
            txtAccountNo.Enabled = false;
            GroupBGender.Enabled = false;
            chkIsActive.Enabled = false;
            CHKPermanent.Enabled = false;
            txtML.Enabled = false ;
        }

        private void txtESICPer_TextChanged(object sender, EventArgs e)
        {
            if (txtpfPer.Text == "")
            {
                txtpfPer.Text = "0";
                txtpfPer.SelectAll();
            }
            if (ControlValidation.CheckNumericValueOnly1(txtpfPer))
            {
                calculateDA();
            }
        }

        private void txtEmpName_KeyPress(object sender, KeyPressEventArgs e)
        {
            Connection.SetEnterKey(e.KeyChar);
        }

        

        private void frmNewEmployee_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void GroupBNewEmployee_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void tabPage2_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        }
}