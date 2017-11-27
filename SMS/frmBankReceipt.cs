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
    public partial class frmBankReceipt : Form
    {
        school c = new school();
        Boolean add_edit = false;
        SqlConnection con = new SqlConnection(); 
        string VoucherNo;
        string vouchNo;
        int VchNo;
        public frmBankReceipt()
        {
            InitializeComponent();
        }
        private void frmBankReceipt_Load(object sender, EventArgs e)
        {
            
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            c.getconnstr();
            //m.FillcomboBox("select * from tbl_LedgerAcc where BHM_COD in('140','587','588') order by BHM_DESH", "BHM_DESH", "BHM_COD", ref valcmbbank);
            c.FillcomboBox("select * from tbl_LedgerAcc where GRP_COD in (2) order by BHM_DESH", "BHM_DESH", "GRP_COD", ref valcmbbank);
            c.FillcomboBox("select * from tbl_LedgerAcc where GRP_COD NOT in(1)  order by BHM_DESH", "BHM_DESH", "GRP_COD", ref valcmbaccountgroup);          
            enableData();
            SqlConnection con = c.myconn;
        }
        private void enableData()
        {
            dtp.Enabled = false;
            valcmbbank.Enabled = false;
            valcmbaccountgroup.Enabled = false;           
            txtChkNo.Enabled = false;
            txtReceiptAmt.Enabled = false;
            txtChkDate.Enabled = false;
            txtNarration.Enabled = false;
            textBox3.Enabled = false;
        }
        private void DisableData()
        {
            dtp.Enabled = true;
            valcmbbank.Enabled = true;
            valcmbaccountgroup.Enabled = true;           
            txtChkNo.Enabled = true;
            txtReceiptAmt.Enabled = true;
            txtChkDate.Enabled = true;
            txtNarration.Enabled = true;
            textBox3.Enabled = true;
        }
        public void Enablecontrol()
        {
            valcmbbank.Enabled = true;
            valcmbaccountgroup.Enabled = true;
            txtChkNo.Enabled = true;
            txtChkDate.Enabled = true;
            txtReceiptAmt.Enabled = true;
            txtNarration.Enabled = true;
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
          
          
                add_edit = false;
                c.GetMdiParent(this).DisableAllEditMenuButtons();
                c.GetMdiParent(this).ToggleDeleteButton(true);
                txtvoucherno.ReadOnly = false;
                txtvoucherno.Focus();
                Enablecontrol();
           
        }
        public  void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();  
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        public void btnsave_Click(object sender, EventArgs e)
        {
            if (valcmbbank.Text == "" && valcmbaccountgroup.Text == "" && txtReceiptAmt.Text == "" && txtNarration.Text == "")
            {

                MessageBox.Show("Null Value Not Allowed ");
            }
            else
            {
                int Bank1;
                int Bank2;
                Bank1 = Convert.ToInt32(valcmbaccountgroup.SelectedValue);
                Bank2 = Convert.ToInt32(valcmbbank.SelectedValue);
                if (Bank1 == Bank2)
                {
                    MessageBox.Show("Both Accounts are same....");
                    goto mline;
                }
                c.returnconn(c.myconn);
                txtvchtype.Text = "BR";
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
                        mysql="insert into tbl_Voucher(YearNo,VchNo,VouchNo,VchType,VchDate,Remark,Status)values('"+ school.CurrentSessionCode+"','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + dtp.Value.Date + "','" + txtNarration.Text + "','AE')";
                        c.connectsql(mysql,c.myconn,trn);
                        mysql = "insert into tbl_VoucherDetail (YearNo,vchno,VouchNo,VchType,AccCode,VchDate,Amount,CashBankNo,ChequeNo,ChequeDate) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + valcmbbank.SelectedValue + "','" + dtp.Value.Date + "','" + txtReceiptAmt.Text + "',0,'" + txtChkNo.Text + "','" + txtChkDate.Value + "')";
                        c.connectsql(mysql, c.myconn, trn);
                        mysql = "insert into tbl_VoucherDetail (YearNo,vchno,VouchNo,VchType,AccCode,VchDate,Amount,CashBankNo,ChequeNo,ChequeDate) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + valcmbaccountgroup.SelectedValue + "','" + dtp.Value.Date + "'," + -1 * Convert.ToDecimal(txtReceiptAmt.Text) + ",'" + valcmbbank.SelectedValue + "','" + txtChkNo.Text + "','" + txtChkDate.Value + "')";
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
                if(add_edit==false)
                {
                    c.getconnstr();
                    c.returnconn(c.myconn);
                    SqlDataReader dr = null;
                    con = c.myconn;
                    dr = c.fillreader(ref dr, "select VchNo,Status from tbl_Voucher where vchtype='BR'  and VouchNo='" + txtvoucherno.Text + "'", con);
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
                    c.returnconn(c.myconn);
                    SqlTransaction trn;
                    trn = c.myconn.BeginTransaction();
                    try
                    {
                        string mysql;
                        mysql = "delete from tbl_Voucher where vchtype='BR'  and VouchNo='" + txtvoucherno.Text + "'";
                        c.connectsql(mysql, c.myconn, trn);
                        mysql = "delete from tbl_VoucherDetail where  vchtype='BR' and VouchNo='" + txtvoucherno.Text + "'";
                        c.connectsql(mysql, c.myconn, trn);
                        mysql = "insert into tbl_Voucher(YearNo,VchNo,VouchNo,VchType,VchDate,Remark,Status)values('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + dtp.Value.Date + "','" + txtNarration.Text + "','AE')";
                        c.connectsql(mysql, c.myconn, trn);
                        mysql = "insert into tbl_VoucherDetail (YearNo,vchno,VouchNo,VchType,AccCode,VchDate,Amount,CashBankNo,ChequeNo,ChequeDate) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + valcmbbank.SelectedValue + "','" + dtp.Value.Date + "','" + txtReceiptAmt.Text + "','" + valcmbbank.SelectedValue + "','" + txtChkNo.Text + "','" + txtChkDate.Value + "')";
                        c.connectsql(mysql, c.myconn, trn);
                        mysql = "insert into tbl_VoucherDetail (YearNo,vchno,VouchNo,VchType,AccCode,VchDate,Amount,CashBankNo,ChequeNo,ChequeDate) values ('" + school.CurrentSessionCode + "','" + VchNo + "','" + vouchNo + "','" + txtvchtype.Text + "','" + valcmbaccountgroup.SelectedValue + "','" + dtp.Value.Date + "'," + -1 * Convert.ToDecimal(txtReceiptAmt.Text) + ",0,'" + txtChkNo.Text + "','" + txtChkDate.Value + "')";
                        c.connectsql(mysql, c.myconn, trn);
                        trn.Commit();
                        MessageBox.Show("Record Update...");                        

                    }
                    catch( Exception ex)
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
        }
        public void btndelete_Click(object sender, EventArgs e)
        {
           
                add_edit = false;
                c.GetMdiParent(this).DisableAllEditMenuButtons();
                c.GetMdiParent(this).ToggleDeleteButton(true);
                txtvoucherno.ReadOnly = false;
                txtvoucherno.Focus();
           
        }      
        private void txtvoucherno_Validated(object sender, EventArgs e)
        {
            c.returnconn(c.myconn);
            SqlDataReader dr = null;
            SqlConnection myconn = c.myconn;
            dr = c.fillreader(ref dr, "SELECT tbl_VoucherDetail.VchDate, tbl_VoucherDetail.ChequeNo, tbl_VoucherDetail.ChequeDate, tbl_Voucher.Remark FROM tbl_Voucher INNER JOIN tbl_VoucherDetail ON tbl_Voucher.VouchNo = tbl_VoucherDetail.VouchNo WHERE (tbl_VoucherDetail.VouchNo = '"+txtvoucherno.Text+"') AND (tbl_VoucherDetail.VchType = 'BR')", myconn);
            if (dr.HasRows == true)
            {
                dr.Read();
                dtp.Text = dr["vchdate"].ToString();
                txtChkNo.Text = dr["ChequeNo"].ToString();
                txtChkDate.Text = dr["ChequeDate"].ToString();
                txtNarration.Text = dr["Remark"].ToString();
                dr.Close();
                SqlDataReader drd = null;
                SqlConnection conn = c.myconn;
                drd = c.fillreader(ref drd, "select Amount from tbl_VoucherDetail where CashBankNo>0 and VchType='BR' and Vouchno='" + txtvoucherno.Text + "'", conn);
                if (drd.HasRows == true)
                {
                    drd.Read();
                    txtReceiptAmt.Text = drd["Amount"].ToString();
                    drd.Close();
                }
            }
            else
            {
                MessageBox.Show("Voucher Not Found...");
            }
            dr.Close();
        }
        private void txtReceiptAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = c.CHECKDECIMAL(e);   
        }
        private void txtvoucherno_KeyDown(object sender, KeyEventArgs e)
        {
            //c.EnterTab(Convert.ToInt16(e.KeyValue));   
        }
        private void dtp_Validating(object sender, CancelEventArgs e)
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
