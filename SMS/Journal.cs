using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace SMS
{
    public partial class Journal : Form
    {
        school c = new school();
        DataGridViewComboBoxColumn AccountType;
        DataTable dt = new DataTable();       
        Boolean add_edit = false;       
        string VoucherNo;
        string vouchNo;
        int VchNo;
        SqlConnection con = new SqlConnection(); 
        public Journal()
        {
            InitializeComponent();
            
        }
        private void GetAccountType()
        {
            try
            {
                DataSet ds = Connection.GetDataSet("select BHM_COD,BHM_DESH from tbl_LedgerAcc  where GRP_COD not in (1,2)  order by GRP_COD");
                AccountType = (DataGridViewComboBoxColumn)dataGridView1.Columns["Account"];
                AccountType.DataSource = ds.Tables[0];
                AccountType.DisplayMember = "BHM_DESH";
                AccountType.ValueMember = "BHM_COD";              
            }
            catch { }
        }      
       
        private void Journal_Load(object sender, EventArgs e)
        {
            try
            {
                EnableControl();
                this.GetAccountType();
                //this.GetVoucherNo();
                SqlConnection con = c.myconn;
            }
            catch { }
           
        }
        private void EnableControl()
        {
            dataGridView1.Enabled = false;
            txtPayment.Enabled = false;
            txtReciept.Enabled = false;
            txtRemark.Enabled = false;
            dtp.Enabled = false;
        }
        private void DisableControl()
        {
            dataGridView1.Enabled = true;
            txtPayment.Enabled = true;
            txtReciept.Enabled = true;
            txtRemark.Enabled = true;
            dtp.Enabled = true;
        }
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try { 
            
            }
            catch { }
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Journal_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode.ToString() == "F3")
            {              
                dataGridView1.Rows.Add();               
            }
            if (e.KeyCode.ToString() == "F8")
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                double payment = 0; 
                double receipt = 0; 
                txtPayment.Text = "0";
                txtReciept.Text = "0";
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    int cnt;
                    int cnt1;
                    cnt = Convert.ToInt32(dataGridView1.Rows[i].Cells["Payment"].Value);
                    cnt1 = Convert.ToInt32(dataGridView1.Rows[i].Cells["Reciept"].Value);
                    if (dataGridView1.Rows[i].Cells["Payment"].Value == null || cnt == 0)
                    {
                        payment = 0;
                    }
                    else
                    {
                        payment = Convert.ToDouble(dataGridView1.Rows[i].Cells["Payment"].Value.ToString());
                    }
                    if (dataGridView1.Rows[i].Cells["Reciept"].Value == null || cnt1 == 0)
                    {
                        receipt = 0;
                    }
                    else
                    {
                        receipt = Convert.ToDouble(dataGridView1.Rows[i].Cells["Reciept"].Value.ToString());
                    }

                    txtReciept.Text = Convert.ToString(Convert.ToDouble(txtReciept.Text) + receipt);
                    txtPayment.Text = Convert.ToString(Convert.ToDouble(txtPayment.Text) + payment);
                }

            }
        }       
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                dataGridView1.Rows[e.RowIndex].Cells["Payment"].ReadOnly = false;
                dataGridView1.Rows[e.RowIndex].Cells["Reciept"].ReadOnly = false;
                double payment = 0; // Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value.ToString());
                double receipt = 0; //Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Reciept"].Value);

                if (dataGridView1.CurrentCell.ColumnIndex == 3)
                    if (dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value == null)
                    {
                        txtPayment.Text = "";
                    }
                    else
                    {
                        payment = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value.ToString());
                        txtPayment.Text = payment.ToString();
                    }
                if (payment > 0)
                {
                    dataGridView1.Rows[e.RowIndex].Cells["Reciept"].Value = 0;
                    dataGridView1.Rows[e.RowIndex].Cells["Reciept"].ReadOnly = true;
                }
                if (dataGridView1.CurrentCell.ColumnIndex == 2)
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells["Reciept"].Value == null)
                    {
                        txtReciept.Text = "";
                    }
                    else
                    {
                        receipt = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Reciept"].Value.ToString());
                        txtReciept.Text = receipt.ToString();
                    }

                    if (receipt > 0)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value = 0;
                        dataGridView1.Rows[e.RowIndex].Cells["Payment"].ReadOnly = true;
                    }
                }
                txtPayment.Text = "0";
                txtReciept.Text = "0";
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    int cnt;
                    int cnt1;
                    cnt = Convert.ToInt32(dataGridView1.Rows[i].Cells["Payment"].Value);
                    cnt1 = Convert.ToInt32(dataGridView1.Rows[i].Cells["Reciept"].Value);
                    if (dataGridView1.Rows[i].Cells["Payment"].Value == null || cnt == 0)
                    {
                        payment = 0;
                    }
                    else
                    {
                        payment = Convert.ToDouble(dataGridView1.Rows[i].Cells["Payment"].Value.ToString());
                    }
                    if (dataGridView1.Rows[i].Cells["Reciept"].Value == null || cnt1 == 0)
                    {
                        receipt = 0;
                    }
                    else
                    {
                        receipt = Convert.ToDouble(dataGridView1.Rows[i].Cells["Reciept"].Value.ToString());
                    }

                    txtReciept.Text = Convert.ToString(Convert.ToDouble(txtReciept.Text) + receipt);
                    txtPayment.Text = Convert.ToString(Convert.ToDouble(txtPayment.Text) + payment);
                }

            }
            catch { }
        }  
        private void GetPaymentReciept()
        {
            try
            {                
                dataGridView1.Rows[3].Cells["Payment"].ReadOnly = false;
                dataGridView1.Rows[2].Cells["Reciept"].ReadOnly = false;
                double payment = 0; // Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Payment"].Value.ToString());
                double receipt = 0; //Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Reciept"].Value);

                if (dataGridView1.CurrentCell.ColumnIndex == 3)
                    if (dataGridView1.Rows[3].Cells["Payment"].Value == null)
                    {
                        txtPayment.Text = "";
                    }
                    else
                    {
                        payment = Convert.ToDouble(dataGridView1.Rows[3].Cells["Payment"].Value.ToString());
                        txtPayment.Text = payment.ToString();
                    }
                if (payment > 0)
                {
                    dataGridView1.Rows[2].Cells["Reciept"].Value = 0;
                    dataGridView1.Rows[2].Cells["Reciept"].ReadOnly = true;
                }
                if (dataGridView1.CurrentCell.ColumnIndex == 2)
                {
                    if (dataGridView1.Rows[2].Cells["Reciept"].Value == null)
                    {
                        txtReciept.Text = "";
                    }
                    else
                    {
                        receipt = Convert.ToDouble(dataGridView1.Rows[2].Cells["Reciept"].Value.ToString());
                        txtReciept.Text = receipt.ToString();
                    }

                    if (receipt > 0)
                    {
                        dataGridView1.Rows[3].Cells["Payment"].Value = 0;
                        dataGridView1.Rows[3].Cells["Payment"].ReadOnly = true;
                    }
                }
                txtPayment.Text = "0";
                txtReciept.Text = "0";
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    int cnt;
                    int cnt1;
                    cnt = Convert.ToInt32(dataGridView1.Rows[i].Cells["Payment"].Value);
                    cnt1 = Convert.ToInt32(dataGridView1.Rows[i].Cells["Reciept"].Value);
                    if (dataGridView1.Rows[i].Cells["Payment"].Value == null || cnt == 0)
                    {
                        payment = 0;
                    }
                    else
                    {
                        payment = Convert.ToDouble(dataGridView1.Rows[i].Cells["Payment"].Value.ToString());
                    }
                    if (dataGridView1.Rows[i].Cells["Reciept"].Value == null || cnt1 == 0)
                    {
                        receipt = 0;
                    }
                    else
                    {
                        receipt = Convert.ToDouble(dataGridView1.Rows[i].Cells["Reciept"].Value.ToString());
                    }

                    txtReciept.Text = Convert.ToString(Convert.ToDouble(txtReciept.Text) + receipt);
                    txtPayment.Text = Convert.ToString(Convert.ToDouble(txtPayment.Text) + payment);
                }

            }
            catch { }

        }
        public void btnnew_Click(object sender, EventArgs e)
        {
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            DisableControl();
            dtp.Focus();
        }

        public void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
        }
        public void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                int ricept;
                int Payment;
                ricept = Convert.ToInt32(txtReciept.Text);
                Payment = Convert.ToInt32(txtPayment.Text);
                if (ricept != Payment)
                {
                    MessageBox.Show("Payment Amount and Reciept Amount Does not Match...Entry Cannot Saved..");
                }
                else
                {
                    c.getconnstr();
                    c.returnconn(c.myconn);
                    txtvchtype.Text = "JV";
                    if (add_edit == true)
                    {
                        SqlConnection con = c.myconn;
                        DateTime dt = dtp.Value;
                        Int32 VchNo = c.getvchno(txtvchtype.Text, ref dt, con);
                        vouchNo = c.getvouchernumber(txtvchtype.Text, ref dt, con);      //txtvchtype.Text +  dtp.Value.Date.ToString("ddMMyyyy") + VchNo;
                        txtvoucherno.Text = vouchNo;
                        SqlTransaction trn;
                        trn = c.myconn.BeginTransaction();
                        try
                        {
                            string mysql;
                            mysql = "insert into tbl_Voucher(yearno,VchNo,VouchNo,VchType,VchDate,Remark,status)values('" + school.CurrentSessionCode+ "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + dtp.Value.Date + "','" + txtRemark.Text + "','AE')";
                            c.connectsql(mysql,c.myconn, trn);
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                decimal pay = Convert.ToInt32(dataGridView1.Rows[i].Cells["Payment"].Value);
                                decimal rec = Convert.ToInt32(dataGridView1.Rows[i].Cells["Reciept"].Value);
                                if (pay == 0)
                                {
                                    mysql = "insert into tbl_VoucherDetail (yearno,vchno,VouchNo,VchType,AccCode,VchDate,Amount) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + dataGridView1.Rows[i].Cells["ACCOUNT"].Value.ToString() + "','" + dtp.Value.Date + "','" + rec + "')";
                                }
                                else
                                {
                                    mysql = "insert into tbl_VoucherDetail (yearno,vchno,VouchNo,VchType,AccCode,VchDate,Amount) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + dataGridView1.Rows[i].Cells["ACCOUNT"].Value.ToString() + "','" + dtp.Value.Date + "','" + -1 * pay + "')";
                                }
                                c.connectsql(mysql, c.myconn, trn);

                            }
                            trn.Commit();
                            MessageBox.Show("Record Saved...");


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            trn.Rollback();

                        }
                    }
                    if (add_edit == false)
                    {
                        c.getconnstr();
                        c.returnconn(c.myconn);
                        SqlDataReader dr = null;
                        con = c.myconn;
                        dr = c.fillreader(ref dr, "select VchNo from tbl_Voucher where vchtype='JV'  and VouchNo='" + txtvoucherno.Text + "'", con);
                        if (dr.HasRows == true)
                        {                           
                            dr.Read();
                            VchNo = Convert.ToInt16(dr[0]);
                            if (dr[1] == "AE")
                            {
                                MessageBox.Show("Voucher Not Made from Account Entry...");
                                dr.Close();
                                goto mline;
                            }
                        }
                        dr.Close();
                        SqlTransaction trn;
                        trn = c.myconn.BeginTransaction();
                        try
                        {
                            string mysql;
                            mysql = "delete from tbl_Voucher where vchtype='JV'  and VouchNo='" + txtvoucherno.Text + "'";
                            c.connectsql(mysql, c.myconn, trn);
                            mysql = "delete from tbl_VoucherDetail where  vchtype='JV' and VouchNo='" + txtvoucherno.Text + "'";
                            c.connectsql(mysql, c.myconn, trn);
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                decimal pay = Convert.ToInt32(dataGridView1.Rows[i].Cells["Payment"].Value);
                                decimal rec = Convert.ToInt32(dataGridView1.Rows[i].Cells["Reciept"].Value);
                                if (pay == 0)
                                {
                                    mysql = "insert into tbl_VoucherDetail (yearno,vchno,VouchNo,VchType,AccCode,VchDate,Amount) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + dataGridView1.Rows[i].Cells["ACCOUNT"].Value.ToString() + "','" + dtp.Value.Date + "'," + rec + "')";
                                }
                                else
                                {
                                    mysql = "insert into tbl_VoucherDetail (yearno,vchno,VouchNo,VchType,AccCode,VchDate,Amount) values ('" + school.CurrentSessionCode+ "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + dataGridView1.Rows[i].Cells["ACCOUNT"].Value.ToString() + "','" + dtp.Value.Date + "'," + -1 * pay + "')";
                                }
                                c.connectsql(mysql, c.myconn, trn);

                            }
                            trn.Commit();
                            MessageBox.Show("Record Update...");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            trn.Rollback();
                        }
                        trn.Dispose();
                       
                    }
                    mline:
                    c.GetMdiParent(this).EnableAllEditMenuButtons();
                    
                    DesignForm.fromDesign1(this);

                }
            }

            catch { }
        }      
        private void dtp_KeyDown(object sender, KeyEventArgs e)
        {
            //c.EnterTab(Convert.ToInt16(e.KeyValue));   
        }
        public void btnedit_Click(object sender, EventArgs e)
        {
            try
            {
                
               
                    add_edit = false;
                    c.GetMdiParent(this).DisableAllEditMenuButtons();
                    c.GetMdiParent(this).ToggleDeleteButton(true);
                    txtvoucherno.ReadOnly = false;
                    txtvoucherno.Focus();
                    dataGridView1.Enabled = true;
                    txtPayment.Enabled = true;
                    txtReciept.Enabled = true;
                    txtRemark.Enabled = true;
                    
               
            }
            catch
            {
            }
        }
        public void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
              
                    add_edit = false;
                    c.GetMdiParent(this).DisableAllEditMenuButtons();
                    c.GetMdiParent(this).ToggleDeleteButton(true);
                    txtvoucherno.ReadOnly = false;
                    txtvoucherno.Focus();
              
            }
            catch { }
        }
        private void txtvoucherno_Validated(object sender, EventArgs e)
        {
            c.getconnstr();
            //DataSet ds = Connection.GetDataSet("SELECT tbl_VoucherDetail.VchDate, tbl_VoucherDetail.Amount, tbl_VoucherDetail.AccCode, tbl_Voucher.Remark FROM tbl_Voucher INNER JOIN tbl_VoucherDetail ON tbl_Voucher.VouchNo = tbl_VoucherDetail.VouchNo WHERE (tbl_VoucherDetail.VouchNo = '" + txtvoucherno.Text + "') AND (tbl_VoucherDetail.VchType = 'JV')");
            DataSet ds = Connection.GetDataSet("SELECT     tbl_VoucherDetail.VchDate,(case when tbl_VoucherDetail.Amount>0 then tbl_VoucherDetail.Amount else 0 end) as rcpt,(case when tbl_VoucherDetail.Amount<0 then -1*tbl_VoucherDetail.Amount else 0 end ) as pymt, tbl_VoucherDetail.Amount, tbl_VoucherDetail.AccCode, tbl_Voucher.Remark, tbl_LedgerAcc.BHM_DESH FROM tbl_Voucher INNER JOIN tbl_VoucherDetail ON tbl_Voucher.VouchNo = tbl_VoucherDetail.VouchNo INNER JOIN tbl_LedgerAcc ON tbl_VoucherDetail.AccCode = tbl_LedgerAcc.BHM_COD WHERE (tbl_VoucherDetail.VouchNo = '" + txtvoucherno.Text + "') AND (tbl_VoucherDetail.VchType = 'JV')");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToDecimal(ds.Tables[0].Rows[i]["pymt"])> 0)
                    {
                        dtp.Text = ds.Tables[0].Rows[0]["VchDate"].ToString();
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i]["BHM_DESH"].ToString();                      
                        dataGridView1.Rows[i].Cells[3].Value = ds.Tables[0].Rows[i]["pymt"].ToString();
                        GetPaymentReciept();
                    }
                    if (Convert.ToDecimal(ds.Tables[0].Rows[i]["rcpt"]) > 0)
                    {

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[1].Value = ds.Tables[0].Rows[i]["BHM_DESH"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = ds.Tables[0].Rows[i]["rcpt"].ToString();
                        GetPaymentReciept();
                    }                   
                }
            }            
        }
        private void dtp_Validated(object sender, EventArgs e)
        {
            //try
            //{
            //    m.SYSLOCK_DATE();
            //    if (dtp.Value.Date < m.msys_lock_dt.Date || dtp.Value.Date > m.msys_lock_dt.Date)
            //    {
            //        MessageBox.Show("Please Enter System Date..");
            //        dtp.Focus();
            //    }
            //}
            //catch { }
        }
        private void dtp_Enter(object sender, EventArgs e)
        {
            //dtp.Value = DateTime.Now;
        }
     }        
 }
 

