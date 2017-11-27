using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.Shared;

namespace SMS.Account.ReportForm
{
    public partial class FrmBankBook :UserControlBase
    {
        public FrmBankBook()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        school c = new school();
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime opdate = dtpfrom.Value.Date;
                c.returnconn(c.myconn);
                string mysql;
                mysql = "select opdate from tbl_account where accode=" + valcmbbank.SelectedValue;
                SqlCommand com;
                com = new SqlCommand(mysql, c.myconn);
                SqlDataReader reader = com.ExecuteReader();
                int i = 0;
                if (reader.HasRows)
                {
                    reader.Read();
                    opdate = Convert.ToDateTime(reader["opdate"]);
                }
                reader.Close();
                string str = " SELECT  isnull(sum(case a.amttype when 'Cr' then a.vchamt else 0 end),0) AS receipt,  isnull(sum(case a.amttype when 'Dr' then a.vchamt else 0 end),0) AS payment,";
                str = str + "  0 as balance  FROM tbl_voucherdet AS a ";
                str = str + " Where a.vchdate>='" + opdate.Date + "'";
                str = str + " and  a.vchdate<'" + dtpfrom.Value.ToShortDateString() + "' and a.accode=" + valcmbbank.SelectedValue + " and a.sessioncode=" + school.CurrentSessionCode + " ";
                com = new SqlCommand(str, c.myconn);
                reader = com.ExecuteReader();
                i = 0;
                decimal mrec = 0;
                decimal mpay = 0;
                if (reader.HasRows)
                {
                    reader.Read();
                    mrec = Convert.ToDecimal(reader["receipt"]);
                    mpay = Convert.ToDecimal(reader["payment"]);
                }
                reader.Close();
                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                c.connectsql("delete from tbl_accledger", c.myconn, trn);

                DateTime mopdate = opdate.Date;

                if (dtpfrom.Value.Date < opdate.Date)
                {
                    dtpfrom.Value = opdate.Date;
                }
                //insert the opening balance
                str = " Insert into tbl_accledger (accno,vchtype,vchdate,narration,receipt,payment,balance,baltype)  ";
                str = str + "  select accode as accno,'Open. Bal.' as vchtype,'" + dtpfrom.Value.ToShortDateString() + "' as vchdate,'' as narration,0,0,isnull(acopbal,0) as  balance,(case acoptype when 'Cr' then 'Credit' else 'Debit' end) as baltype ";
                str = str + " from tbl_account where accode=" + valcmbbank.SelectedValue;
                c.connectsql(str, c.myconn, trn);
                //update opening balance for gap period
                c.connectsql("update tbl_accledger set balance = balance - " + mpay + " + " + mrec, c.myconn, trn);
                //---------------------------------
                //insert the voucher details for each entry date wise for the account
                //str = " Insert into tbl_accledger (accno,vchno,vchdate,vchtype,amttype,narration,receipt,payment,balance) ";
                //str = str + " SELECT a.accode as accno,b.vchno, b.vchdate,b.vchtype, (case a.amttype when 'Cr'  then 'Receipt' else  'Payment'  end ) AS amttype, isnull(b.remarks,'') as narration, ";
                //str = str + " (case a.amttype when 'Cr' then a.vchamt else 0 end) AS Receipt, (case a.amttype when 'Dr' then a.vchamt else 0 end) AS payment,0 as balance  ";
                //str = str + " FROM tbl_voucherdet AS a, tbl_voucher AS b Where  (a.vchtype='JV'  or (a.vchtype='BP' and a.amttype='Dr') or (a.vchtype='BR' and a.amttype='Cr')  or (a.vchtype='CP' and a.amttype='Dr') or (a.vchtype='CR' and a.amttype='Cr'))  and a.vchdate>='" + dtpfrom.Value.ToShortDateString() + "'";
                //str = str + " and  a.vchdate<='" + dtpto.Value.ToShortDateString() + "' and a.accode=" + valcmbbank.SelectedValue + " and a.sessioncode=" + school.CurrentSessionCode + " and  a.vchno = b.vchno and a.VCHTYPE = b.VCHTYPE ORDER BY b.vchdate ";

                str = " Insert into tbl_accledger (accno,accname,vchno,vchdate,vchtype,amttype,narration,receipt,payment,balance) ";
                str = str + " SELECT a.accode as accno,c.acname as accname,b.vchno, b.vchdate,b.vchtype, (case a.amttype when 'Cr'  then 'Receipt' else  'Payment'  end ) AS amttype, isnull(b.remark,'') as narration, ";
                str = str + " (case a.amttype when 'Cr' then a.vchamt else 0 end) AS Receipt, (case a.amttype when 'Dr' then a.vchamt else 0 end) AS payment,0 as balance  ";
                str = str + " FROM (SELECT a.* FROM tbl_voucherdet a , tbl_voucherdet b where a.vchtype=b.vchtype and a.vchno=b.vchno and b.accode=" + valcmbbank.SelectedValue + ")   AS a, tbl_voucher AS b,tbl_account as c Where   (a.vchtype='JV'  or (a.vchtype='BP' and a.amttype='Dr') or (a.vchtype='BR' and a.amttype='Cr')  or (a.vchtype='CP' and a.amttype='Dr') or (a.vchtype='CR' and a.amttype='Cr'))  and a.vchdate>='" + dtpfrom.Value.ToShortDateString() + "'";
                str = str + " and  a.vchdate<='" + dtpto.Value.ToShortDateString() + "' and a.sessioncode=" + school.CurrentSessionCode + " and  a.vchno = b.vchno and a.VCHTYPE = b.VCHTYPE  and a.accode=c.accode ORDER BY b.vchdate ";


                c.connectsql(str, c.myconn, trn);
                trn.Commit();
                //---------------------------------
                mysql = "select '" + valcmbbank.Text + "' as bank,' For  " + dtpfrom.Text + " to " + dtpto.Text + "' as period,(select top 1 schoolname from tbl_school ) as SName,(select top 1 schooladdress from tbl_school ) as SAddress,accno,isnull(accname,'') as accname,isnull(accdate,'') as accdate,convert(varchar(10),vchdate,105) as vchdate,vchtype,isnull(vchno,'') as vchno,narration,isnull(amt,0) as amt,receipt,payment,balance,isnull(baltype,'') as baltype,isnull(recno,'') as recno,isnull(amttype,'') as amttype  from tbl_accledger order by vchdate";
                DataSet ds = new DataSet();
                ds.Clear();
                ds = Connection.GetDataSet(mysql);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BankBook.xsd");
                //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                Account.ReportDesign.BankBook cr = new Account.ReportDesign.BankBook();
                cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;

                cr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr;
                s.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close(); 
        }

        private void FrmBankBook_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            c.FillcomboBox("select acname,accode from tbl_account  where actype=dbo.GetAccountCode('B') order by acname", "acname", "accode", ref valcmbbank);
        }

        private void FrmBankBook_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

       
    }
}
