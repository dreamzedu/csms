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
    public partial class frmCashReceipt : Form
    {
        school c = new school();             
        Boolean add_edit = false;
        string VoucherNo;
        string vouchNo;
        int VchNo;
        int BHM_DES = 0;
        SqlConnection con = new SqlConnection(); 
        public frmCashReceipt()
        {
            InitializeComponent();
        }
        private void frmCashReceipt_Load(object sender, EventArgs e)
        {
              
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();                     
            //m.FillcomboBox("select * from tbl_LedgerAcc  where GRP_COD not in (1)  order by BHM_DES", "BHM_DES", "BHM_COD", ref valcmbaccountgroup);
            //c.FillcomboBox("select * from tbl_LedgerAcc  where GRP_COD not in (1)  order by BHM_DESH", "BHM_DESH", "BHM_COD", ref valcmbaccountgroup);
            Connection.FillComboBox(valcmbaccountgroup, "select BHM_COD,BHM_DESH from tbl_LedgerAcc  where GRP_COD not in (1)  order by BHM_DESH");
            enableData();   
            SqlConnection con = c.myconn;
        }
        private void enableData()
        {
            dtp.Enabled = false;
            valcmbaccountgroup.Enabled = false;
            txtReceiptAmt.Enabled = false;
            txtRemark.Enabled = false;        

        }
        private void DisableData()
        {
            dtp.Enabled = true;
            valcmbaccountgroup.Enabled = true;
            txtReceiptAmt.Enabled = true;
            txtRemark.Enabled = true;         

        }
        public void btnnew_Click(object sender, EventArgs e)
        {            
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            DisableData();
            dtp.Focus();
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
                    valcmbaccountgroup.Enabled = true;
                    txtReceiptAmt.Enabled = true;
                    txtRemark.Enabled = true;         
                
            }
            catch
            {
            }
        }      
        public void btnsave_Click(object sender, EventArgs e)
        {
            int BHM_DES=0;
            SqlCommand command1 = new SqlCommand("select BHM_COD from tbl_LedgerAcc where BHM_COD=1", c.myconn);
            SqlDataReader reader1 = command1.ExecuteReader();
            int i = 0;
            if (reader1.HasRows)
            {
                reader1.Read();
                BHM_DES = Convert.ToInt16(reader1["BHM_COD"]);
                if (BHM_DES != 1)
                {
                    MessageBox.Show("Cannot Select Cash Account..");
                    reader1.Close();
                    goto mline;
                }
            }
            c.returnconn(c.myconn);
            txtvchtype.Text = "CR";
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
                    mysql = "insert into tbl_Voucher(YearNo,VchNo,VouchNo,VchType,VchDate,Remark)values('"+school.CurrentSessionCode+"','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + dtp.Value.Date + "','" + txtRemark.Text + "')";
                    c.connectsql(mysql, c.myconn, trn);
                    mysql = "insert into tbl_VoucherDetail (YearNo,vchno,VouchNo,VchType,AccCode,VchDate,Amount,cashbankno) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + BHM_DES + "','" + dtp.Value.Date + "'," + txtReceiptAmt.Text + ",0)";
                    c.connectsql(mysql, c.myconn, trn);
                    mysql = "insert into tbl_VoucherDetail (YearNo,vchno,VouchNo,VchType,AccCode,VchDate,Amount,cashbankno) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + valcmbaccountgroup.SelectedValue + "','" + dtp.Value.Date + "'," + -1 * Convert.ToDecimal(txtReceiptAmt.Text) + ",'" + BHM_DES + "')";
                    c.connectsql(mysql, c.myconn, trn);
                    trn.Commit();
                    MessageBox.Show("Record Saved...");
                }
                catch(Exception ex)
                {
                    Logger.LogError(ex); MessageBox.Show(ex.Message);
                    trn.Rollback();
                }
                trn.Dispose();
            }
            if (add_edit == false)
            {
                c.getconnstr();
                c.returnconn(c.myconn);
                SqlDataReader dr = null;
                con = c.myconn;
                dr = c.fillreader(ref dr, "select VchNo from tbl_Voucher where vchtype='CR'  and VouchNo='" + txtvoucherno.Text + "'", con);
                if (dr.HasRows == true)
                {
                    dr.Read();
                    VchNo = Convert.ToInt16(dr[0]);
                }
                dr.Close();               
                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                try
                {
                    string mysql;
                    mysql = "delete from tbl_Voucher where vchtype='CR'  and VouchNo='" + txtvoucherno.Text + "'";
                    c.connectsql(mysql, c.myconn, trn);
                    mysql = "delete from tbl_VoucherDetail where  vchtype='CR' and VouchNo='" + txtvoucherno.Text + "'";
                    c.connectsql(mysql, c.myconn, trn);
                    mysql = "insert into tbl_Voucher(YearNo,VchNo,VouchNo,VchType,VchDate,Remark)values('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + dtp.Value.Date + "','" + txtRemark.Text + "')";
                    c.connectsql(mysql, c.myconn, trn);
                    mysql = "insert into tbl_VoucherDetail (YearNo,vchno,VouchNo,VchType,AccCode,VchDate,Amount,cashbankno) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + BHM_DES + "','" + dtp.Value.Date + "'," + txtReceiptAmt.Text + "," + BHM_DES + ")";
                    c.connectsql(mysql, c.myconn, trn);
                    mysql = "insert into tbl_VoucherDetail (YearNo,vchno,VouchNo,VchType,AccCode,VchDate,Amount,cashbankno) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + valcmbaccountgroup.SelectedValue + "','" + dtp.Value.Date + "'," + -1 * Convert.ToDecimal(txtReceiptAmt.Text) + ",0)";
                    c.connectsql(mysql, c.myconn, trn);
                    trn.Commit();
                    MessageBox.Show("Record Update...");
                }
                catch(Exception ex)
                {
                    Logger.LogError(ex); MessageBox.Show(ex.Message);
                    trn.Rollback();
                }
                trn.Dispose();
            }
            mline:
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
            DesignForm.fromDesign1(this);            
            } 
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void btncancel_Click(object sender, EventArgs e)
        {            
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            txtvoucherno.ReadOnly = true;
            valcmbaccountgroup.Enabled = false;
            txtReceiptAmt.Enabled = false;
            txtRemark.Enabled = false;
            
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
            catch(Exception ex){Logger.LogError(ex); }


        }
        private void dtp_KeyDown(object sender, KeyEventArgs e)
        {
            //c.EnterTab(Convert.ToInt16(e.KeyValue));   
        }
        private void txtReceiptAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = c.CHECKDECIMAL(e);   
        }
        private void txtvoucherno_Validated(object sender, EventArgs e)
        {
            if (txtvoucherno.Text != "")
            {
                c.getconnstr();
                c.returnconn(c.myconn);
                SqlDataReader dr = null;
                SqlConnection myconn = c.myconn;
                dr = c.fillreader(ref dr, "select BHM_COD from tbl_LedgerAcc where BHM_COD=1", myconn);
                if (dr.HasRows == true)
                {
                    dr.Read();
                    BHM_DES = Convert.ToInt16(dr["BHM_COD"]);
                }
                dr.Close();
                string mstr;
                mstr = "SELECT tbl_VoucherDetail.VouchNo, tbl_VoucherDetail.VchType, tbl_VoucherDetail.VchDate, tbl_LedgerAcc.BHM_DES, tbl_Voucher.Remark FROM tbl_LedgerAcc INNER JOIN tbl_VoucherDetail ON tbl_LedgerAcc.BHM_COD = tbl_VoucherDetail.AccCode INNER JOIN tbl_Voucher ON tbl_VoucherDetail.VouchNo = tbl_Voucher.VouchNo WHERE (tbl_VoucherDetail.VouchNo = '" + txtvoucherno.Text + "') AND (tbl_VoucherDetail.CashBankNo = '1')";             
                dr = c.fillreader(ref dr, mstr, myconn);
                if (dr.HasRows == true)
                {
                    dr.Read();
                    dtp.Text = dr["VchDate"].ToString();
                    valcmbaccountgroup.Text  = dr["BHM_DES"].ToString();
                    txtRemark.Text = dr["Remark"].ToString();
                    dr.Close();
                    SqlDataReader drd = null;
                    SqlConnection conn = c.myconn;
                    drd = c.fillreader(ref drd, "select Amount from tbl_VoucherDetail where CashBankNo='0'", conn);
                    if (drd.HasRows == true)
                    {
                        drd.Read();
                        txtReceiptAmt.Text = drd["Amount"].ToString();
                        drd.Close();
                    }
                }
                dr.Close();                
            }
            else
            {
                MessageBox.Show("Voucher Invalid...");
            }
        
        }
        private void valcmbaccountgroup_Validated(object sender, EventArgs e)
        {
            txtReceiptAmt.Focus(); 
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
            //catch(Exception ex){Logger.LogError(ex); }
        }
        private void dtp_Enter(object sender, EventArgs e)
        {
            //dtp.Value = DateTime.Now;
        }       
     }
}

