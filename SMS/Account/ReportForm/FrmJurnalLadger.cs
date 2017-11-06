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
    public partial class FrmJurnalLadger :UserControlBase
    {
        public FrmJurnalLadger()
        {
            InitializeComponent();
        }
        school c = new school();
        private void FrmJurnalLadger_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            c.FillcomboBox("select acname,accode from tbl_account  order by acname", "acname", "accode", ref valcmbbank);
            dtpfrom.Value = c.GetFromDate(school.CurrentSessionCode);
            dtpto.Value = c.GetToDate(school.CurrentSessionCode);
        }

        public void GetStudentDetailsOld()
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
                string str = " SELECT  isnull(sum(case a.amttype when 'Dr' then a.vchamt else 0 end),0) AS Payment,  isnull(sum(case a.amttype when 'Cr' then a.vchamt else 0 end),0) AS Receipt,";
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

                //--------------------
                string actypet = string.Empty;
                string actypep = string.Empty;

                actypet = Convert.ToString(Connection.GetExecuteScalar("select actype from tbl_account  where accode='" + valcmbbank.SelectedValue + "'  "));
                actypep = Convert.ToString(Connection.GetExecuteScalar("select dbo.GetAccountCode('F')"));

                //--------------------
                SqlTransaction trn;
                if (actypet == actypep)
                {

                    trn = c.myconn.BeginTransaction();
                    c.connectsql("delete from tbl_accledger", c.myconn, trn);

                    DateTime mopdate = opdate.Date;

                    if (dtpfrom.Value.Date < opdate.Date)
                    {
                        dtpfrom.Value = opdate.Date;
                    }
                    //insert the opening balance
                    str = " Insert into tbl_accledger (accno,vchtype,vchdate,narration,receipt,payment,balance,baltype)  ";
                    str = str + "  select accode as accno,'Open. Bal.' as vchtype,'" + dtpfrom.Value.ToShortDateString() + "' as vchdate,'' as narration,0,0,isnull(acopbal,0) as  balance,(case acoptype when 'Cr' then 'Debit' else 'Credit' end) as baltype ";
                    str = str + " from tbl_account where accode=" + valcmbbank.SelectedValue;
                    c.connectsql(str, c.myconn, trn);
                    //update opening balance for gap period
                    if (mpay > 0)
                    {
                        c.connectsql("update tbl_accledger set balance = balance - " + mpay + " + " + mrec, c.myconn, trn);
                        c.connectsql("update tbl_accledger set balance = balance - dbo.GetAccountOpening('" + valcmbbank.SelectedValue + "')", c.myconn, trn);
                    }
                    else
                    {
                        c.connectsql("update tbl_accledger set balance = balance - " + mpay + " + " + mrec, c.myconn, trn);
                    }
                    //---------------------------------
                    //insert the voucher details for each entry date wise for the account
                    str = " Insert into tbl_accledger (accno,vchno,vchdate,vchtype,amttype,narration,payment,receipt,balance) ";
                    str = str + " SELECT a.accode as accno,b.vchno, b.vchdate,b.vchtype, (case a.amttype when 'Cr'  then  'Receipt' else  'Payment' end ) AS amttype, isnull(b.remark,'') as narration, ";
                    str = str + " (case a.amttype when 'Dr' then a.vchamt else 0 end) AS Payment, (case a.amttype when 'Cr' then a.vchamt else 0 end) AS Receipt,0 as balance  ";
                    str = str + " FROM tbl_voucherdet AS a, tbl_voucher AS b Where a.vchdate>='" + dtpfrom.Value.ToShortDateString() + "'";
                    str = str + " and  a.vchdate<='" + dtpto.Value.ToShortDateString() + "' and a.accode=" + valcmbbank.SelectedValue + " and a.sessioncode in (select distinct sessioncode from tbl_voucherdet where accode=a.accode) and  a.vchno = b.vchno and a.VCHTYPE = b.VCHTYPE and a.sessioncode=b.sessioncode ORDER BY b.vchdate ";
                    c.connectsql(str, c.myconn, trn);
                    trn.Commit();
                    //---------------------------------
                    mysql = "select " + "' Ledger of : " + valcmbbank.Text + "  For  " + dtpfrom.Text + " to " + dtpto.Text + "' as period,(select top 1 schoolname from tbl_school ) as SName,(select top 1 schooladdress from tbl_school ) as SAddress,accno,tbl_account.acname as accname,accdate,convert(varchar(10),vchdate,105) as cvchdate,vchdate,vchtype,vchno,narration,amt,receipt,payment,balance,baltype,recno,amttype  from tbl_accledger ,tbl_account where tbl_accledger.accno=tbl_account.accode order by vchdate";
                    DataSet ds = new DataSet();
                    ds.Clear();
                    ds = Connection.GetDataSet(mysql);
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BankBook.xsd");
                    //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                    JournalBook cr = new JournalBook();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    s.Show();
                }
                else
                {
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
                    str = " Insert into tbl_accledger (accno,vchno,vchdate,vchtype,amttype,narration,payment,receipt,balance) ";
                    str = str + " SELECT a.accode as accno,b.vchno, b.vchdate,b.vchtype, (case a.amttype when 'Cr'  then  'Receipt' else  'Payment' end ) AS amttype, isnull(b.remark,'') as narration, ";
                    str = str + " (case a.amttype when 'Dr' then a.vchamt else 0 end) AS Payment, (case a.amttype when 'Cr' then a.vchamt else 0 end) AS Receipt,0 as balance  ";
                    str = str + " FROM tbl_voucherdet AS a, tbl_voucher AS b Where a.vchdate>='" + dtpfrom.Value.ToShortDateString() + "'";
                    str = str + " and  a.vchdate<='" + dtpto.Value.ToShortDateString() + "' and a.accode=" + valcmbbank.SelectedValue + " and a.sessioncode in (select distinct sessioncode from tbl_voucherdet where accode=a.accode) and  a.vchno = b.vchno and a.VCHTYPE = b.VCHTYPE and a.sessioncode=b.sessioncode ORDER BY b.vchdate ";
                    c.connectsql(str, c.myconn, trn);
                    trn.Commit();

                    //---------------------------------
                    mysql = "select " + "' Ledger of : " + valcmbbank.Text + "  For  " + dtpfrom.Text + " to " + dtpto.Text + "' as period,(select top 1 schoolname from tbl_school ) as SName,(select top 1 schooladdress from tbl_school ) as SAddress,accno,tbl_account.acname as accname,accdate,convert(varchar(10),vchdate,105) as cvchdate,vchdate,vchtype,vchno,narration,amt,receipt,payment,balance,baltype,recno,amttype  from tbl_accledger ,tbl_account where tbl_accledger.accno=tbl_account.accode order by vchdate";
                    DataSet ds = new DataSet();
                    ds.Clear();
                    ds = Connection.GetDataSet(mysql);
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\OBankBook.xsd");
                    //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                    JournalBookO cr = new JournalBookO();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    s.Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetStudentDetails()
        {
            SqlTransaction trn = null;
            try
            {
              //  trn = c.myconn.BeginTransaction();
                DataSet dss = new DataSet();
                dss.Clear();
                dss = GetDatasetByTrn("GetStudentLadger " , school.CurrentSessionCode , valcmbbank.SelectedValue.ToString() , dtpfrom.Value , dtpto.Value, c.myconn, trn);
              //  trn.Commit();
                //---------------------------------
                dss.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BankBook.xsd");
                if (dss.Tables[0].Rows.Count > 0)
                {
                    //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                    LDStudentN cr = new LDStudentN();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    cr.SetDataSource(dss);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    s.Show();
                }
                else
                    MessageBox.Show("Racord not exist.", "Warnning:");
            }
            catch (Exception ex)
            {
               MessageBox.Show (ex.Message );
            }
        }
        public void GetCashDetails()
        {
            SqlTransaction trn = null;
            try
            {
                //  trn = c.myconn.BeginTransaction();
                DataSet dss = new DataSet();
                dss.Clear();
                dss = GetDatasetByTrn("GetCashLadger ", school.CurrentSessionCode, valcmbbank.SelectedValue.ToString(), dtpfrom.Value, dtpto.Value, c.myconn, trn);
                //  trn.Commit();
                //---------------------------------
                dss.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BankBook.xsd");
                if (dss.Tables[0].Rows.Count > 0)
                {
                    //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                    LDCash cr = new LDCash();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    cr.SetDataSource(dss);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    s.Show();
                }
                else
                    MessageBox.Show("Racord not exist.", "Warnning:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetBankDetails()
        {
            SqlTransaction trn = null;
            try
            {
                //  trn = c.myconn.BeginTransaction();
                DataSet dss = new DataSet();
                dss.Clear();
                dss = GetDatasetByTrn("GetBankLadger ", school.CurrentSessionCode, valcmbbank.SelectedValue.ToString(), dtpfrom.Value, dtpto.Value, c.myconn, trn);
                //  trn.Commit();
                //---------------------------------
                dss.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BankBook.xsd");
                if (dss.Tables[0].Rows.Count > 0)
                {
                    //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                    LDStudentN cr = new LDStudentN();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    cr.SetDataSource(dss);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    s.Show();
                }
                else
                    MessageBox.Show("Racord not exist.", "Warnning:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void GetEmployeeDetails()
        {
            SqlTransaction trn = null;
            try
            {
                //  trn = c.myconn.BeginTransaction();
                DataSet ds = new DataSet();
                ds.Clear();
                ds = GetDatasetByTrn("GetEmployeeLadger ", valcmbbank.SelectedValue.ToString(), dtpfrom.Value, dtpto.Value, c.myconn, trn);
                //  trn.Commit();
                //---------------------------------
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\EJBook.xsd");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                    LDEmployee cr = new LDEmployee();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    s.Show();
                }
                else
                    MessageBox.Show("Racord not exist.", "Warnning:");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            int CEID = Convert.ToInt16(Connection.GetId("select dbo.GetAccountCode('S')"));
            int CSID = Convert.ToInt16(Connection.GetId("select dbo.GetAccountCode('F')"));
            int CCID = Convert.ToInt16(Connection.GetId("select dbo.GetAccountCode('C')"));
            int CBID = Convert.ToInt16(Connection.GetId("select dbo.GetAccountCode('B')"));

            if (CSID == Convert.ToInt16(Connection.GetId("select dbo.GetACTypeCode('" + valcmbbank.SelectedValue.ToString() + "')")))
            GetStudentDetails();
            else if (CEID == Convert.ToInt16(Connection.GetId("select dbo.GetACTypeCode('" + valcmbbank.SelectedValue.ToString() + "')")))
                GetEmployeeDetails();
            else if (CCID == Convert.ToInt16(Connection.GetId("select dbo.GetACTypeCode('" + valcmbbank.SelectedValue.ToString() + "')")))
                GetCashDetails();
            else if (CBID == Convert.ToInt16(Connection.GetId("select dbo.GetACTypeCode('" + valcmbbank.SelectedValue.ToString() + "')")))
                GetBankDetails();
            else
            {
                GetStudentDetailsOld();
                //-----
            }
                
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchByName gb = new SearchByName();
            //Library.FrmGetStudentBarcode gb = new FrmGetStudentBarcode();
            Connection.Flag = "A";
            gb.ShowDialog();
            valcmbbank.SelectedValue = Connection.StudentBcode;
        }

        public DataSet GetDatasetByTrn(string msql, int scode, string accode, DateTime fdate, DateTime tdate, SqlConnection cnn, SqlTransaction sqltrn)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = cnn.CreateCommand();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            cmd.Transaction = sqltrn;
            cmd.CommandTimeout = 250;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = msql;
            // Add the input parameter and set its properties.
            SqlParameter SessionCode = new SqlParameter();
            SessionCode.ParameterName = "@SessionCode";
            SessionCode.SqlDbType = SqlDbType.Int;
            SessionCode.Direction = ParameterDirection.Input;
            SessionCode.Value = scode;
            SqlParameter Studentno = new SqlParameter();
            Studentno.ParameterName = "@Studentno";
            Studentno.SqlDbType = SqlDbType.Int;
            Studentno.Direction = ParameterDirection.Input;
            Studentno.Value = accode;
            SqlParameter Fdate = new SqlParameter();
            Fdate.ParameterName = "@Fdate";
            Fdate.SqlDbType = SqlDbType.DateTime;
            Fdate.Direction = ParameterDirection.Input;
            Fdate.Value = fdate;
            SqlParameter Tdate = new SqlParameter();
            Tdate.ParameterName = "@Tdate";
            Tdate.SqlDbType = SqlDbType.DateTime;
            Tdate.Direction = ParameterDirection.Input;
            Tdate.Value = tdate;
            // Add the parameter to the Parameters collection. 
            cmd.Parameters.Add(SessionCode);
            cmd.Parameters.Add(Studentno);
            cmd.Parameters.Add(Fdate);
            cmd.Parameters.Add(Tdate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }
        public DataSet GetDatasetByTrn(string msql, string accode, DateTime fdate, DateTime tdate, SqlConnection cnn, SqlTransaction sqltrn)
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = cnn.CreateCommand();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            cmd.Transaction = sqltrn;
            cmd.CommandTimeout = 250;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = msql;
            // Add the input parameter and set its properties.
            SqlParameter Studentno = new SqlParameter();
            Studentno.ParameterName = "@EmpID";
            Studentno.SqlDbType = SqlDbType.Int;
            Studentno.Direction = ParameterDirection.Input;
            Studentno.Value = accode;
            SqlParameter Fdate = new SqlParameter();
            Fdate.ParameterName = "@Fdate";
            Fdate.SqlDbType = SqlDbType.DateTime;
            Fdate.Direction = ParameterDirection.Input;
            Fdate.Value = fdate;
            SqlParameter Tdate = new SqlParameter();
            Tdate.ParameterName = "@Tdate";
            Tdate.SqlDbType = SqlDbType.DateTime;
            Tdate.Direction = ParameterDirection.Input;
            Tdate.Value = tdate;
            // Add the parameter to the Parameters collection. 
            cmd.Parameters.Add(Studentno);
            cmd.Parameters.Add(Fdate);
            cmd.Parameters.Add(Tdate);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.Dispose();
            return ds;
        }

        private void FrmJurnalLadger_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}


