using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;


namespace SMS
{
    public partial class FrmTrialBalance : Form
    {

        SqlConnection con = new SqlConnection();
        school c = new school();
        public FrmTrialBalance()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmTrialBalance_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            SqlConnection con = c.myconn;
        }
        private void button1_Click(object sender, EventArgs e)        
        {
            try
            {
                DateTime opdate = dtpfrom.Value.Date;
                c.returnconn(c.myconn);
                string mysql;
                mysql = "INSERT INTO TBL_LEDGER (ACCNO,ACCNAME,openbal,Reciept,PAYMENT) ";
                mysql = mysql + "select L.accno,l.accname,L.opbal,l.receipt,L.payment FROM  (";
                mysql=mysql+"SELECT m.BHM_COD  as accno,m.BHM_DES,  m.BHM_DESH as accname,(case when m.opbal>0 then 'Cr' else 'Dr' end) as baltype, isnull(m.opbal,0) as opbal,  isnull(n.receipt,0) as receipt,isnull(n.payment,0) as payment,(isnull(m.opbal,0)+isnull(n.receipt,0)- isnull(n.payment,0)) as clbal  FROM  (";
                mysql = mysql + "SELECT p.GRP_COD,p.BHM_COD  ,p.BHM_DESH,p.BHM_DES, isnull(p.ope_bld,0) +isnull(q.receipt,0)-isnull(q.payment,0) AS opbal, 0 AS receipt, 0 AS payment, 0 AS CLBAL  FROM tbl_LedgerAcc  AS p    LEFT JOIN   ( SELECT  b.acccode,isnull(sum(b.receipt),0) AS receipt, isnull(sum(b.payment),0) AS payment FROM  ( SELECT a.AccCode ,sum(a.Amount) AS Receipt, 0 AS payment FROM tbl_VoucherDetail AS a,  tbl_voucher AS b  WHERE a.VouchNo=b.VouchNo   and a.vchdate>= (select OpenDate  from tbl_LedgerAcc where bhm_cod=a.AccCode)  and   a.vchdate<'" + dtpfrom.Value.Date + "' and    a.vchtype=b.vchtype and  A.amount>0 GROUP BY a.AccCode    UNION ALL    SELECT a.AccCode, 0 AS Receipt, sum(a.Amount) AS payment FROM tbl_VoucherDetail AS a, tbl_voucher AS b  WHERE a.vchno=b.vchno and a.VchDate> (select OpenDate from tbl_LedgerAcc where BHM_COD=a.AccCode)   and a.vchdate<'" + dtpfrom.Value.Date + "'  and a.VchType=b.VchType and A.Amount < 0 GROUP BY a.AccCode )  b GROUP BY b.AccCode  )   AS q   ON p.BHM_COD =q.acccode ) m   ";
                mysql=mysql+"LEFT JOIN  (SELECT b.AccCode, 0 AS opbal,sum(b.receipt) AS receipt, sum(b.payment)  AS payment, 0 AS clbal FROM (";
                mysql = mysql + "SELECT a.AccCode, 0 AS OPBAL, sum(a.Amount) AS Receipt, 0 AS payment, 0 AS CLBAL FROM tbl_VoucherDetail AS a,   tbl_voucher AS b  WHERE a.vchno=b.vchno and a.vchdate=  (select  (case  when OpenDate<='" + dtpfrom.Value.Date + "'  then OpenDate else '" + dtpfrom.Value.Date + "' end) as mdate from tbl_LedgerAcc where BHM_COD=a.AccCode) and   a.vchdate<'" + dtpfrom.Value.Date + "' and   a.vchtype=b.vchtype and A.Amount >0 GROUP BY a.AccCode  ";
                mysql = mysql + "UNION ALL SELECT a.AccCode, 0 AS Receipt, 0 AS OPBAL, sum(a.Amount) AS payment, 0 AS CLBAL FROM tbl_VoucherDetail AS a,   tbl_voucher AS b   WHERE a.vchno=b.vchno  and a.vchdate>=  (select (case  when OpenDate<='" + dtpfrom.Value.Date + "' then OpenDate else '" + dtpfrom.Value.Date + "' end) as mdate from tbl_LedgerAcc  where BHM_COD =a.AccCode )  and a.vchdate<'" + dtpfrom.Value.Date + "'  and  a.vchtype=b.vchtype and A.Amount <0  group by a.AccCode ) AS b  ";
                mysql=mysql+"GROUP BY b.AccCode )  n   ON m.BHM_COD =n.AccCode ) L order by L.BHM_DES ";
                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                c.connectsql("delete from tbl_ledger", c.myconn, trn);
                //insert the opening balance
                c.connectsql(mysql, c.myconn, trn);
                trn.Commit();
                //--------------------------------- Crystal Report -------------------


                string str1 = "select '','" + dtpfrom.Text + " ' as period,*  from tbl_Ledger order by VchDate,VchNo,VchType";
                DataSet ds = new DataSet();
                ds.Clear();
                str1 = str1 + " SELECT     Schoolname + ' - ( ' + Schoolcity + ' ) ' as Schoolname, Schoolcity  FROM         tbl_School";
                ds = Connection.GetDataSet(str1);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\TrialBalance.xsd");
                RptTrialBalance cr = new RptTrialBalance();
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

        private void dtpfrom_KeyDown(object sender, KeyEventArgs e)
        {
            //c.EnterTab(Convert.ToInt16(e.KeyValue));   
        }
    }
}
