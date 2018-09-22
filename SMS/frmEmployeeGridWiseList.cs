using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmEmployeeGridWiseList :UserControlBase
    {
        DataSet dsEmpType;
        //decimal da,daamt,pf,pfamt,bs;
        public frmEmployeeGridWiseList()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        private void frmEmployeeGridWiseList_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kGRIDataSet1.tbl_teacher' table. You can move, or remove it, as needed.
           
            try
            {
                dsEmpType = Connection.GetDataSet("SELECT EmpTypeId, Detail, allowleaves FROM  tbl_EmployeeType");
                FillDropDwonList(dsEmpType);
                getEmployeeList();
               // this.dgv .EditingControlShowing +=new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);

                this.cmbEmpType.SelectedIndexChanged += new System.EventHandler(this.cmbEmpType_SelectedIndexChanged);
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void FillDropDwonList(DataSet dsEmpType)
        {
            DataTable tbl = dsEmpType.Tables[0].Copy();
                
            tbl.Rows.InsertAt(tbl.NewRow(), 0);
            tbl.Rows[0]["Detail"] = "All";
            tbl.Rows[0]["EmpTypeId"] = "-1";

            if (dsEmpType != null)
            {
                cmbEmpType.DataSource = tbl;
                cmbEmpType.DisplayMember = "Detail";
                cmbEmpType.ValueMember = "EmpTypeId";
            }

        }
      
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
                {
                    DialogResult result = MessageBox.Show("Are you sure to update employee data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                        {
                            int a = 0;
                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                string emptype = dgv.Rows[i].Cells[2].Value.ToString().Trim();
                                //DataSet ds = Connection.GetDataSet("select emptypeid from tbl_EmployeeType where detail=N'" + emptype + "'");
                                int id = Convert.ToInt32(emptype);
                                string isactive = dgv.Rows[i].Cells["isactive"].Value.ToString().Trim();
                                if (isactive == "Yes")
                                    a = 1;
                                else if (isactive == "No")
                                    a = 0;
                                int empno = Convert.ToInt32(dgv.Rows[i].Cells[0].Value.ToString());
                                string name = dgv.Rows[i].Cells[1].Value.ToString().Trim();
                                // string fname = dgv.Rows[i].Cells[2].Value.ToString().Trim();
                                // string contactno=(dgv.Rows[i].Cells[3].Value.ToString().Trim());
                                // string gender = dgv.Rows[i].Cells[4].Value.ToString().Trim();
                                //  DateTime doj = Convert.ToDateTime(dgv.Rows[i].Cells[5].Value.ToString());
                                // DateTime dob = Convert.ToDateTime(dgv.Rows[i].Cells[6].Value.ToString());
                                // string address = dgv.Rows[i].Cells[7].Value.ToString().Trim();
                                //  string designation = dgv.Rows[i].Cells[10].Value.ToString().Trim();
                                double srate = Convert.ToDouble(dgv.Rows[i].Cells[3].Value.ToString().Trim());
                                double pf = Convert.ToDouble(dgv.Rows[i].Cells[4].Value.ToString().Trim());
                                double pfamt = Convert.ToDouble(dgv.Rows[i].Cells[5].Value.ToString());
                                double lic = Convert.ToDouble(dgv.Rows[i].Cells[6].Value.ToString().Trim());
                                double loan = Convert.ToDouble(dgv.Rows[i].Cells[7].Value.ToString().Trim());
                                double rsa = Convert.ToDouble(dgv.Rows[i].Cells[8].Value.ToString().Trim());
                                int splinctv = Convert.ToInt32(dgv.Rows[i].Cells[9].Value.ToString().Trim());
                                int aleave = Convert.ToInt32(dgv.Rows[i].Cells[10].Value.ToString().Trim());
                                // double balleave = Convert.ToDouble(dgv.Rows[i].Cells[11].Value.ToString().Trim());
                                int el = Convert.ToInt32(dgv.Rows[i].Cells[12].Value.ToString().Trim());
                                //  int elbal = Convert.ToInt32(dgv.Rows[i].Cells[13].Value.ToString().Trim());
                                int enclleave = Convert.ToInt32(dgv.Rows[i].Cells[14].Value.ToString().Trim());
                                //string pfno = dgv.Rows[i].Cells[15].Value.ToString().Trim();

                                double da = Convert.ToDouble(dgv.Rows[i].Cells[15].Value.ToString().Trim());
                                double daamt = Convert.ToDouble(dgv.Rows[i].Cells[16].Value.ToString());
                                double hra = Convert.ToDouble(dgv.Rows[i].Cells[17].Value.ToString().Trim());
                                double ESICPer = Convert.ToDouble(dgv.Rows[i].Cells[18].Value.ToString().Trim());
                                double ESICAmt = Convert.ToDouble(dgv.Rows[i].Cells[19].Value.ToString().Trim());

                                //int ele = Convert.ToInt32(dss.Tables[0].Rows[0][1].ToString());
                                // double balleave = Convert.ToInt32(dss.Tables[0].Rows[0][2].ToString());
                                // int elbal = Convert.ToInt32(dss.Tables[0].Rows[0][3].ToString());

                                Connection.AllPerform("update tbl_EmployeeInfo set isactive='" + a + "',salaryrate='" + srate + "',pf='" + pf + "',lic='" + lic + "',loan='" + loan + "',rsa='" + rsa + "',aleave='" + aleave + "',el='" + el + "',splinctv='" + splinctv + "',enclleave='" + enclleave + "',EmpTypeId='" + id + "',da='" + da + "',hra='" + hra + "',pfamt='" + pfamt + "',daamt='" + daamt + "',ESIC='" + ESICPer + "',ESICAmt='" + ESICAmt + "' where empno='" + empno + "'");
                                //insertion for as on date...
                                DataSet dss = Connection.GetDataSet("select pfnumber from tbl_employeeinfo where empno='" + empno + "'");
                                string pfno = dss.Tables[0].Rows[0][0].ToString();

                                // DataSet dss = Connection.GetDataSet("select startdate,pfnumber,ele from tbl_employeesalaryinfo where empno='" + empno + "'");
                                //  DateTime sd = Convert.ToDateTime(ds.Tables[0].Rows[0][0].ToString());

                                string str2 = "update tbl_employeesalaryinfo set enddate='" + DateTime.Now + "',status='" + 2 + "' where empno='" + empno + "' and status=1";
                                Connection.AllPerform(str2);
                                string str3 = "INSERT INTO tbl_employeesalaryinfo(empno,startdate,status,salaryrate,pf,lic,loan,rsa,aleave,pfnumber,el,splinctv,EnCLLeave ,DA,HRA,isactive,esic,esicamt)" +
                                      "values('" + empno + "','" + DateTime.Now + "','" + 1 + "','" + srate + "','" + pf + "','" + lic + "','" + loan + "','" + rsa + "','" + aleave + "','" + pfno + "','" + el + "','" + splinctv + "','" + enclleave + "','" + da + "','" + hra + "','" + a + "','" + ESICPer + "','" + ESICAmt + "')";
                                Connection.AllPerform(str3);
                                //  Connection.AllPerform("update tbl_EmployeeSalaryInfo set isactive='" + a + "',salaryrate='" + srate + "',pf='" + pf + "',lic='" + lic + "',loan='" + loan + "',rsa='" + rsa + "',aleave='" + aleave + "',balleave='" + balleave + "',el='" + el + "',elbal='" + elbal + "',splinctv='" + splinctv + "',enclleave='" + enclleave + "',EmpTypeId='" + id + "',da='" + da + "',hra='" + hra + "',pfamt='" + pfamt + "',daamt='" + daamt + "' where empno='" + empno + "'");
                            }
                        MessageBox.Show("Employee data updated successfully.","Information",MessageBoxButtons .OK ,MessageBoxIcon.Information);
                        btnincESIC.Enabled = true;
                        btnincpay.Enabled = true;
                        btnokda.Enabled = true;
                        btnpfamt.Enabled = true;
                            }
            }     
                catch(Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Something went wrong. Please try again.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    getEmployeeList();
                }
        }
        
        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            int a = e.RowIndex;
            int b = e.ColumnIndex;
            string s = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
       
        }
        private void getEmployeeList()
        {
            dgv.Rows.Clear();
            DataGridViewComboBoxColumn dcmb = new DataGridViewComboBoxColumn();
            dcmb.HeaderText = "Employee Type";
            if (dsEmpType != null)
            {
                dcmb.DataSource = dsEmpType.Tables[0];
                dcmb.DisplayMember = "Detail";
                dcmb.ValueMember = "EmpTypeId";
            }
            DataSet ds = new DataSet();
            if (chkOnlyActive.Checked)
            {
                if (cmbEmpType.SelectedIndex == 0)
                {
                    ds = Connection.GetDataSet("SELECT EmpNo, EmpName,tbl_EmployeeType .Detail, salaryrate, pf,pfamt, lic, loan, rsa, splinctv, aleave, balleave,el, elbal, EnCLLeave, DA,daamt, HRA,ESIC,ESICAmt,IsActive  FROM tbl_EmployeeInfo inner join tbl_EmployeeType  on tbl_EmployeeInfo .EmpTypeId =tbl_EmployeeType .EmpTypeId  where IsActive=1 order by empno");
                }
                else
                {
                    ds = Connection.GetDataSet("SELECT EmpNo, EmpName,tbl_EmployeeType .Detail, salaryrate, pf,pfamt, lic, loan, rsa, splinctv, aleave, balleave,el, elbal, EnCLLeave, DA,daamt, HRA,ESIC,ESICAmt,IsActive  FROM tbl_EmployeeInfo inner join tbl_EmployeeType  on tbl_EmployeeInfo .EmpTypeId =tbl_EmployeeType .EmpTypeId  where IsActive=1 and tbl_EmployeeInfo .EmpTypeId=" + cmbEmpType.SelectedValue + " order by empno");
                }
            }
            else
            {
                if (cmbEmpType.SelectedIndex == 0)
                {
                    ds = Connection.GetDataSet("SELECT EmpNo, EmpName,tbl_EmployeeType .Detail, salaryrate, pf,pfamt, lic, loan, rsa, splinctv, aleave, balleave,el, elbal, EnCLLeave, DA,daamt, HRA,ESIC,ESICAmt,IsActive  FROM tbl_EmployeeInfo,tbl_EmployeeType  where tbl_EmployeeInfo .EmpTypeId =tbl_EmployeeType .EmpTypeId order by empno");
                }
                else
                {
                    ds = Connection.GetDataSet("SELECT EmpNo, EmpName,tbl_EmployeeType .Detail, salaryrate, pf,pfamt, lic, loan, rsa, splinctv, aleave, balleave,el, elbal, EnCLLeave, DA,daamt, HRA,ESIC,ESICAmt,IsActive  FROM tbl_EmployeeInfo,tbl_EmployeeType  where tbl_EmployeeInfo .EmpTypeId =tbl_EmployeeType .EmpTypeId and tbl_EmployeeInfo .EmpTypeId=" + cmbEmpType.SelectedValue + " order by empno");
                }
            }
            
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgv.Columns.RemoveAt(2);
                dgv.Columns.Insert(2, dcmb);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string active = "";
                    string g = ds.Tables[0].Rows[i][2].ToString().Trim();
                    int a = Convert.ToInt32(ds.Tables[0].Rows[i]["Isactive"].ToString().Trim());
                    if (a == 1)
                        active = "Yes";
                    else if (a == 0)
                        active = "No";
                    string d = ds.Tables[0].Rows[i]["Isactive"].ToString().Trim();

                    try
                    {

                        this.dgv.Rows.Add(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), g, ds.Tables[0].Rows[i][3].ToString(), ds.Tables[0].Rows[i][4].ToString(), ds.Tables[0].Rows[i][5].ToString(), ds.Tables[0].Rows[i][6].ToString(), ds.Tables[0].Rows[i][7].ToString(), ds.Tables[0].Rows[i][8].ToString(), ds.Tables[0].Rows[i][9].ToString(), ds.Tables[0].Rows[i][10].ToString(), ds.Tables[0].Rows[i][11].ToString(), ds.Tables[0].Rows[i][12].ToString(), ds.Tables[0].Rows[i][13].ToString(), ds.Tables[0].Rows[i][14].ToString(), ds.Tables[0].Rows[i][15].ToString(), ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][17].ToString(), ds.Tables[0].Rows[i][18].ToString(), ds.Tables[0].Rows[i][19].ToString(), active);

                    }

                    catch (Exception exc)
                    {
                        Logger.LogError(exc); 
                        MessageBox.Show(exc.Message);
                    }
                }

            }
            else
            {
                MessageBox.Show("There is no employee data available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void dgv_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            try { }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnokda_Click(object sender, EventArgs e)
        {
            try
            {

                decimal daper, daamt, bs,Curr_DAPer;
                 DialogResult result = MessageBox.Show("Are you sure to update DA amount for all employees?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (result == DialogResult.Yes)
                 {
                     for (int i = 0; dgv.Rows.Count > i; i++)
                     {
                         Curr_DAPer = Convert.ToDecimal(dgv.Rows[i].Cells["da"].Value.ToString());
                         daper = Convert.ToDecimal(txtincda.Text.Trim()) + Curr_DAPer;
                         bs = Convert.ToDecimal(dgv.Rows[i].Cells["Salary"].Value.ToString());
                         daamt = ((bs * daper) / 100);
                         dgv.Rows[i].Cells["da"].Value = daper;
                         dgv.Rows[i].Cells["daamt"].Value = daamt;
                     }
                     txtincda.Text = "0";
                     btnokda.Enabled = false;
                 }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void btnpfamt_Click(object sender, EventArgs e)
        {
            try
            {

                decimal pfper, pfamt, bs,Curr_PFPer;
                DialogResult result = MessageBox.Show("Are you sure to update PF amount for all employees?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (result == DialogResult.Yes)
                 {
                     for (int i = 0; dgv.Rows.Count > i; i++)
                     {
                         Curr_PFPer = Convert.ToDecimal(dgv.Rows[i].Cells["pf"].Value.ToString());
                         pfper = Convert.ToDecimal(txtincpf.Text) + Curr_PFPer;
                         bs = Convert.ToDecimal(dgv.Rows[i].Cells["Salary"].Value.ToString());
                         pfamt = ((bs * pfper) / 100);
                         dgv.Rows[i].Cells["pf"].Value = pfper;
                         dgv.Rows[i].Cells["pfamt"].Value = pfamt;
                     }
                     txtincpf.Text = "0";
                     btnpfamt .Enabled = false;
                 }
            }
            catch(Exception ex){Logger.LogError(ex); }

        }

        private void btnincpay_Click(object sender, EventArgs e)
        {
            try
            {
                decimal daper, daamt, pfper, pfamt, bsper, bsamt, bs,esicper,esicamt;
                DialogResult result = MessageBox.Show("Are you sure to update Basic Salary amount for all employees?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; dgv.Rows.Count > i; i++)
                    {
                        bsper = Convert.ToDecimal(txtincbasicpay.Text);
                        bs = Convert.ToDecimal(dgv.Rows[i].Cells["Salary"].Value.ToString());
                        daper = Convert.ToDecimal(dgv.Rows[i].Cells["da"].Value.ToString());
                        pfper = Convert.ToDecimal(dgv.Rows[i].Cells["pf"].Value.ToString());
                        esicper  = Convert.ToDecimal(dgv.Rows[i].Cells["esic"].Value.ToString());
                        bsamt = ((bs * bsper) / 100) + bs;
                        daamt = ((bsamt * daper) / 100);
                        pfamt = ((bsamt * pfper) / 100);
                        esicamt = ((bsamt * esicper ) / 100);
                        dgv.Rows[i].Cells["Salary"].Value = bsamt;
                        dgv.Rows[i].Cells["pfamt"].Value = pfamt;
                        dgv.Rows[i].Cells["daamt"].Value = daamt;
                        dgv.Rows[i].Cells["esicamt"].Value = esicamt;
                    }
                    txtincbasicpay.Text = "0";
                    btnincpay .Enabled = false;
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

        }

        private void btnincESIC_Click(object sender, EventArgs e)
        {
            try
            {

                decimal ESICPer, ESICAmt, bs, Curr_ESICPer;
                DialogResult result = MessageBox.Show("Are you sure to update ESIC amount for all employees?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        for (int i = 0; dgv.Rows.Count > i; i++)
                        {
                            Curr_ESICPer = Convert.ToDecimal(dgv.Rows[i].Cells["ESIC"].Value.ToString());
                            ESICPer = Convert.ToDecimal(txtIncESIC.Text) + Curr_ESICPer;
                            bs = Convert.ToDecimal(dgv.Rows[i].Cells["Salary"].Value.ToString());
                            ESICAmt = ((bs * ESICPer) / 100);
                            dgv.Rows[i].Cells["ESIC"].Value = ESICPer;
                            dgv.Rows[i].Cells["ESICAmt"].Value = ESICAmt;
                        }
                        txtIncESIC.Text = "0";
                        btnincESIC.Enabled = false;
                     }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtincda_Enter(object sender, EventArgs e)
        {
            txtincda.SelectAll();
        }

        private void txtincda_Leave(object sender, EventArgs e)
        {
            txtincpf.SelectAll();
        }

        private void txtincpf_Leave(object sender, EventArgs e)
        {
            txtIncESIC.SelectAll();
        }

        private void txtIncESIC_Leave(object sender, EventArgs e)
        {
            txtincbasicpay .SelectAll();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to reset all the records to original values?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    getEmployeeList();
                    //this.dgv .EditingControlShowing +=new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
                    txtincda.Text = "0";
                    txtincpf.Text = "0";
                    txtIncESIC.Text = "0";
                    txtincbasicpay.Text = "0";
                    btnokda.Enabled = true;
                    btnpfamt.Enabled = true;
                    btnincESIC.Enabled = true;
                    btnincpay.Enabled = true;
                }
                else
                {
                    return;
                }

            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void frmEmployeeGridWiseList_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }


        private void chkOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            getEmployeeList();
        }

        private void cmbEmpType_SelectedIndexChanged(object sender, EventArgs e)
        {
            getEmployeeList();
        }

    }
}
