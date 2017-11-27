using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SMS.Account.ReportDesign;
using CrystalDecisions.Shared;

namespace SMS.Account.ReportForm
{
    public partial class TrialBalance :UserControlBase
    {
        public TrialBalance()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        school c = new school();
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //DateTime opdate = dtpfrom.Value.Date;
                c.returnconn(c.myconn);
                string mysql;
                mysql = " INSERT INTO TBL_ACCLEDGER (ACCNO,ACCNAME,PAYMENT,RECEIPT) ";
                mysql = mysql + " select  L.accno,L.accname,(case when L.clbal<0 then -1*L.clbal else 0 end) payment,(case when L.clbal>=0 then L.clbal else 0 end) receipt FROM ";
                mysql = mysql + " ( SELECT m.accode as accno, m.acname as accname,m.acoptype as baltype, isnull(m.opbal,0) as opbal, isnull(n.receipt,0) as receipt,isnull(n.payment,0) as payment,(isnull(m.opbal,0)+isnull(n.receipt,0)-isnull(n.payment,0)) as clbal  FROM ";
                mysql = mysql + " ( SELECT p.accode,p.acname,p.acoptype, (case when p.acoptype='Cr' then  -1 else 1 end) *isnull(p.acopbal,0) +isnull(q.receipt,0)-isnull(q.payment,0) AS opbal, 0 AS receipt, 0 AS payment, 0 AS CLBAL FROM tbl_account AS p  LEFT JOIN  ( SELECT  b.accode,isnull(sum(b.receipt),0) AS receipt, isnull(sum(b.payment),0) AS payment FROM   ( SELECT a.accode, sum(a.vchamt) AS Receipt, 0 AS payment FROM tbl_voucherdet AS a, tbl_voucher AS b  WHERE a.vchno=b.vchno  and a.vchdate>= (select opdate  from tbl_account where accode=a.accode)  and a.vchdate<'" + dtpfrom.Value.Date + "' and    a.vchtype=b.vchtype and  A.AMTtype='Dr' GROUP BY a.accode   UNION ALL   SELECT a.accode, 0 AS Receipt, sum(a.vchamt) AS payment FROM tbl_voucherdet AS a, tbl_voucher AS b  WHERE a.vchno=b.vchno  and a.vchdate>= (select opdate from tbl_account where accode=a.accode)   and a.vchdate<'" + dtpfrom.Value.Date + "'  and a.vchtype=b.vchtype and A.AMTtype='Cr' GROUP BY a.accode  )  b GROUP BY b.accode  )  AS q  ON p.accode=q.accode  )    m   LEFT JOIN  ";
                mysql = mysql + " (SELECT b.accode, 0 AS opbal,sum(b.receipt) AS receipt, sum(b.payment)  AS payment, 0 AS clbal FROM (SELECT a.accode, 0 AS OPBAL, sum(a.vchamt) AS Receipt, 0 AS payment, 0 AS CLBAL FROM tbl_voucherdet AS a, tbl_voucher AS b  WHERE a.vchno=b.vchno and a.vchdate>=  (select  (case  when opdate<'" + dtpfrom.Value.Date + "'  then opdate else '" + dtpfrom.Value.Date + "' end) as mdate from tbl_account where accode=a.accode) and a.vchdate<='" + dtpfrom.Value.Date + "' and   a.vchtype=b.vchtype and A.AMTtype='Dr' GROUP BY a.accode  UNION ALL SELECT a.accode, 0 AS Receipt, 0 AS OPBAL, sum(a.vchamt) AS payment, 0 AS CLBAL FROM tbl_voucherdet AS a, tbl_voucher AS b   WHERE a.vchno=b.vchno  and a.vchdate>=  (select (case  when opdate<'" + dtpfrom.Value.Date + "' then opdate else '" + dtpfrom.Value.Date + " ' end) as mdate from tbl_account  where accode=a.accode)  and a.vchdate<='" + dtpfrom.Value.Date + "'  and  a.vchtype=b.vchtype and A.AMTtype='Cr' group by a.accode) AS b GROUP BY b.accode )  n  ";
                mysql = mysql + " ON m.accode=n.accode ) L ";
                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                c.connectsql("delete from tbl_accledger", c.myconn, trn);
                //insert the opening balance
                c.connectsql(mysql, c.myconn, trn);
                trn.Commit();
                //---------------------------------
                mysql = "select ' Income/Expanse From " + dtpto.Text + " Upto " + dtpfrom.Text + "' as period,(select top 1 schoolname from tbl_school ) as SName,(select top 1 schooladdress from tbl_school ) as SAddress,accname,receipt,payment from(SELECT 'Fee' as accname,0 as receipt,SUM(isnull(  acl.payment,0)) as payment FROM TBL_ACCLEDGER acl INNER JOIN tbl_account tac on acl.accno=tac.accode where tac.actype=3 union all SELECT acl.accname, SUM(isnull(  acl.receipt,0)) as receipt,0 as payment FROM TBL_ACCLEDGER acl INNER JOIN tbl_account tac on acl.accno=tac.accode where  tac.actype not in (3,1) group by acl.accname)tbl_accledger where (receipt>0 or payment > 0) order by accname ";
                DataSet ds = new DataSet();
                ds.Clear();
                ds = Connection.GetDataSet(mysql);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\TrialBook.xsd");
                //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                TrialBook cr = new TrialBook();
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

        private void TrialBalance_Load(object sender, EventArgs e)
        {
            c.getconnstr(); 
        }

        private void TrialBalance_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

    }
}
