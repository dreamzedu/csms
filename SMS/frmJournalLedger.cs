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
    public partial class frmJournalLedger : Form
    {
        school c = new school();         
        SqlConnection con = new SqlConnection();
        public frmJournalLedger()
        {
            InitializeComponent();
        }
        private void frmJournalLedger_Load(object sender, EventArgs e)
        {
           c.getconnstr();
           c.FillcomboBox("select BHM_DESH,BHM_COD from tbl_LedgerAcc  where GRP_COD not in(1,2) order by BHM_DESH", "BHM_DESH", "BHM_COD", ref valcmbcash);
            SqlConnection con =c.myconn;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //-------For Select Opening Date -------

                DateTime Cashopdate = dtpfrom.Value.Date;
                decimal CashopBal = 0;
               c.getconnstr();
               c.returnconn(c.myconn);
                SqlDataReader dr = null;
                con =c.myconn;
                dr =c.fillreader(ref dr, "select isnull(OPE_BLD,0) OPE_BLD ,OpenDate from tbl_LedgerAcc where BHM_COD='"+valcmbcash.SelectedValue+"'", con);
                if (dr.HasRows == true)
                {
                    dr.Read();
                    CashopBal = Convert.ToDecimal(dr["OPE_BLD"]);
                    Cashopdate = Convert.ToDateTime(dr["OpenDate"]);
                }
                dr.Close();

                //-------For Select Opening Balance -------

                c.getconnstr();
                c.returnconn(c.myconn);               
                con =c.myconn;
                dr =c.fillreader(ref dr, "select ISNULL(a.Receipt,0) as receipt,ISNULL(a.Payment ,0) as payment,a.balance  from  (SELECT SUM((case  when a.Amount < 0 then -1*a.Amount else 0 end)) AS Receipt,SUM((case  when a.Amount >= 0 then a.Amount else 0 end)) AS Payment,0 as balance  FROM tbl_VoucherDetail AS a  Where a.CashBankNo=0 and a.VchDate>='" + Cashopdate.Date + "' and  a.VchDate<'" + dtpfrom.Value.ToShortDateString() + "' and a.AccCode=" + valcmbcash.SelectedValue + " and a.YearNo=" +school.CurrentSessionCode+ ") a ", con);
                decimal Cashrec = 0;
                decimal Cashpay = 0;
                if (dr.HasRows == true)
                {
                    dr.Read();
                    Cashrec = Convert.ToDecimal(dr["receipt"]);
                    Cashpay = Convert.ToDecimal(dr["payment"]);
                }
                CashopBal = CashopBal + Cashrec - Cashpay;
                dr.Close();

                //--------------insert the opening balance-------

               c.getconnstr();
               c.returnconn(c.myconn);           
                SqlTransaction trn;
                trn =c.myconn.BeginTransaction();               
                string mysql;
                mysql = "delete from tbl_Ledger";
               c.connectsql(mysql,c.myconn, trn);
                if (dtpfrom.Value.Date < Cashopdate.Date)
                {
                        dtpfrom.Value = Cashopdate.Date;
                }

                mysql = " Insert into tbl_Ledger (recordno,YearNo,vchdate,accname,Reciept,Payment,balance)  ";
                if (CashopBal > 0)
                {
                    Cashrec = CashopBal;
                    Cashpay = 0;
                }
                else
                {
                    Cashrec = 0;
                    Cashpay = CashopBal;

                }
                mysql = mysql + "  values  (0," +school.CurrentSessionCode+ ",'" + dtpfrom.Value + "' ,'Opening Balance'," + Cashrec + "," + Cashpay + "," + CashopBal + ")";
               c.connectsql(mysql,c.myconn, trn);
                trn.Commit();

                //--------------Get all voucher of the day - from date-------

               c.getconnstr();
               c.returnconn(c.myconn);              
                trn =c.myconn.BeginTransaction();
                mysql = "insert into tbl_Ledger (recordno,yearno,accno,accname,vchno,vchdate,vchtype,remark,vchamt,Reciept,Payment) ";
                mysql = mysql + " SELECT 1  as recordno ,0 as yearno,a.AccCode as Accno,c.bhm_desh as accname, b.VouchNo, b.VchDate,b.VchType,remark ,a.Amount as vchamt,";
                mysql = mysql + "  (case when a.Amount >= 0 then a.Amount else 0 end) AS Reciept,(case  when (a.Amount) < 0 then -1*a.Amount else 0 end) AS Payment ";
                mysql = mysql + " FROM tbl_VoucherDetail AS a, tbl_Voucher AS b,tbl_LedgerAcc c  Where  ";
                mysql = mysql + "  a.VchDate>='" + dtpfrom.Value.Date + "' and  a.VchDate<='" + dtpto.Value.Date + "'  and  a.YearNo='" +school.CurrentSessionCode+ "' and   ";
                mysql = mysql + "  a.VouchNo  = b.VouchNo  and a.VchType = b.VchType and a.AccCode=c.BHM_COD and a.AccCode='" + valcmbcash.SelectedValue.ToString() + "' ";
                mysql = mysql + "  order by b.VchDate,b.VouchNo,b.VchType  ";
               c.connectsql(mysql,c.myconn, trn);
                trn.Commit();
                //--------------Crystel Report-------              

                string str1 = "select '" + valcmbcash.Text + "' as bank ,' For  " + dtpfrom.Text + " to " + dtpto.Text + "' as period,*  from tbl_Ledger order by VchDate,VchNo,VchType";
                DataSet ds = new DataSet();
                ds.Clear();
                str1 = str1 + " SELECT     Schoolname + ' - ( ' + Schoolcity + ' ) ' as Schoolname, Schoolcity  FROM         tbl_School";
                ds = Connection.GetDataSet(str1);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\JournalLedger.xsd");
                RptJournalLedger cr = new RptJournalLedger();
                cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                cr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = cr;
                s.Show();

            }
            catch(Exception ex)
            {
                Logger.LogError(ex); MessageBox.Show(ex.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void valcmbcash_KeyDown(object sender, KeyEventArgs e)
        {
           //c.EnterTab(Convert.ToInt16(e.KeyValue));   
        }     
      
    }
}
