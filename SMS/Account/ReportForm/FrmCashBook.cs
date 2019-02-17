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

namespace SMS.Account
{
    public partial class FrmCashBook :UserControlBase
    {
        public FrmCashBook()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        school c = new school();
        private void FrmCashBook_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            c.FillcomboBox("select acname,accode from tbl_account  where actype=dbo.GetAccountCode('C') order by acname", "acname", "accode", ref valcmbcash);
            c.FillcomboBox("select acname,accode from tbl_account  where actype=dbo.GetAccountCode('B') order by acname", "acname", "accode", ref valcmbbank);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (valcmbcash.SelectedValue == null || valcmbbank.SelectedValue == null)
                {
                    MessageBox.Show("Please select accounts. If you cannot see the accounts then you probably need to setup the account first.");
                    return;
                }
                DateTime cashopdate = dtpfrom.Value.Date;
                DateTime bankopdate = dtpfrom.Value.Date;
                decimal cashopbal = 0;
                decimal bankopbal = 0;
                c.returnconn(c.myconn);
                string mysql;
                mysql = "select isnull(acopbal,0) acopbal ,opdate from tbl_account where accode=" + valcmbcash.SelectedValue;
                SqlCommand com;
                com = new SqlCommand(mysql, c.myconn);
                SqlDataReader reader = com.ExecuteReader();
                int i = 0;
                if (reader.HasRows)
                {
                    reader.Read();
                    cashopbal = Convert.ToDecimal(reader["acopbal"]);
                    cashopdate = Convert.ToDateTime(reader["opdate"]);
                }
                reader.Close();
                //---------------------------
                mysql = "select isnull(acopbal,0) acopbal ,opdate from tbl_account where accode=" + valcmbbank.SelectedValue;
                //SqlCommand com;
                com = new SqlCommand(mysql, c.myconn);
                reader = com.ExecuteReader();
                i = 0;
                if (reader.HasRows)
                {
                    reader.Read();
                    bankopbal = Convert.ToDecimal(reader["acopbal"]);
                    bankopdate = Convert.ToDateTime(reader["opdate"]);
                }
                reader.Close();
                //---------------------------
                string str = " SELECT  isnull(sum(case a.amttype when 'Dr' then a.vchamt else 0 end),0) AS Receipt,  isnull(sum(case a.amttype when 'Cr' then a.vchamt else 0 end),0) AS Payment,";
                str = str + "  0 as balance  FROM tbl_voucherdet AS a ";
                str = str + " Where a.vchdate>='" + cashopdate.Date + "'";
                str = str + " and  a.vchdate<'" + dtpfrom.Value.ToShortDateString() + "' and a.accode=" + valcmbcash.SelectedValue + " and a.sessioncode=" + school.CurrentSessionCode + " ";
                com = new SqlCommand(str, c.myconn);
                reader = com.ExecuteReader();
                i = 0;
                decimal mcashrec = 0;
                decimal mcashpay = 0;
                if (reader.HasRows)
                {
                    reader.Read();
                    mcashrec = Convert.ToDecimal(reader["receipt"]);
                    mcashpay = Convert.ToDecimal(reader["payment"]);
                }
                cashopbal = cashopbal + mcashrec - mcashpay;
                reader.Close();
                //------------------------
                str = " SELECT  isnull(sum(case a.amttype when 'Dr' then a.vchamt else 0 end),0) AS Receipt,  isnull(sum(case a.amttype when 'Cr' then a.vchamt else 0 end),0) AS Payment,";
                str = str + "  0 as balance  FROM tbl_voucherdet AS a ";
                str = str + " Where a.vchdate>='" + bankopdate.Date + "'";
                str = str + " and  a.vchdate<'" + dtpfrom.Value.ToShortDateString() + "' and a.accode=" + valcmbbank.SelectedValue + " and a.sessioncode=" +school.CurrentSessionCode + " ";
                com = new SqlCommand(str, c.myconn);
                reader = com.ExecuteReader();
                i = 0;
                decimal mbankrec = 0;
                decimal mbankpay = 0;
                if (reader.HasRows)
                {
                    reader.Read();
                    mbankrec = Convert.ToDecimal(reader["receipt"]);
                    mbankpay = Convert.ToDecimal(reader["payment"]);
                }
                bankopbal = bankopbal + mbankrec - mbankpay;
                reader.Close();

                //----------------

                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                c.connectsql("delete from tbl_cashbook", c.myconn, trn);
                DateTime mopdate = cashopdate.Date;
                if (dtpfrom.Value.Date < cashopdate.Date)
                {
                    dtpfrom.Value = cashopdate.Date;
                }
                //insert the opening balance
                str = " Insert into tbl_cashbook (recno,r_date,r_particulars,r_cash,r_bank,isbold)  ";
                str = str + "  values  (0,'" + dtpfrom.Text + "' ,'Open. Bal.'," + cashopbal + "," + bankopbal + ",'Y')";
                c.connectsql(str, c.myconn, trn);
                trn.Commit();
                //---------------------------------
                //get all voucher of the day - fromdate
                //str =  " SELECT a.accode as accno,b.vchno, b.vchdate,b.vchtype, isnull(b.remarks,'') as narration,a.amttype , ";
                //str = str + " (case a.amttype when 'Cr' then a.vchamt else 0 end) AS Payment, (case a.amttype when 'Dr' then a.vchamt else 0 end) AS Receipt,c.acname,isnull(c.lf,'') as lf,c.actype,a.basicsal,isnull(a.vchnarr,'') as vchnarr,isnull(b.entrytype,'') as entrytype,isnull(a.salarytype,'') as salarytype  ";
                //str = str + " FROM tbl_voucherdet AS a, tbl_voucher AS b,tbl_account c  Where a.vchdate='"+ dtpfrom.Value.ToShortDateString()   +"'";
                //str = str + " and  a.sessioncode=" + school.CurrentSessionCode + " and  a.vchno = b.vchno and a.VCHTYPE = b.VCHTYPE and a.accode=c.accode order by b.entrytype desc,a.vchtype,vchno,a.entryno";
                str = " SELECT a.accode as accno,b.vchno, b.vchdate,b.vchtype, isnull(b.remark,'') as narration,a.amttype , ";
                str = str + " (case a.amttype when 'Dr' then a.vchamt else 0 end) AS Payment, (case a.amttype when 'Cr' then a.vchamt else 0 end) AS Receipt,( select top 1 (select top 1 acname from tbl_account where accode=ia.accode ) from tbl_voucherdet ia where ia.accode<>dbo.GetAccountCode('CS') and  ia.vchno=b.vchno and ia.vchtype=a.vchtype ) as acname ,isnull(c.lf,'') as lf,c.actype,isnull(a.basicsal,0) as basicsal,isnull(a.vchnarr,'') as vchnarr,isnull(null,'') as entrytype,isnull(a.salarytype,'') as salarytype  ";
                str = str + " FROM tbl_voucherdet AS a, tbl_voucher AS b,tbl_account c  Where (a.vchtype='JV' ";
                str = str + " or (a.vchtype='CP' and a.amttype='Dr') or (a.vchtype='CR' and a.amttype='Cr'))  and  a.vchdate='" + dtpfrom.Value.ToShortDateString() + "'";
                str = str + " and  a.sessioncode=" + school.CurrentSessionCode + " and  a.vchno = b.vchno and a.VCHTYPE = b.VCHTYPE and a.accode=c.accode and a.accode<>dbo.GetAccountCode('CS') order by a.vchtype,vchno,a.entryno";
                DataSet ds = new DataSet();
                c.filldataset(false, ref ds, str, c.myconn);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int rwcnt = 0;
                    int linecnt = 1;
                    decimal deduct = 0;
                    decimal pcash = 0;
                    decimal pbank = 0;
                    decimal rcash = 0;
                    decimal rbank = 0;
                    bool issubfound = false;
                    string isline = "N";
                    string basicparticulars;
                    string basicpay;
                    string vchtype = "";
                    bool rnarr = false;
                    bool pnarr = false;
                    int cplineno = 0;
                    int crlineno = 0;
                    int bplineno = 0;
                    int brlineno = 0;
                    int subcnt = 0;
                    int pline = 1;
                    int rline = 1;

                    basicparticulars = "";
                    basicpay = "";
                    while (rwcnt < ds.Tables[0].Rows.Count)
                    {

                        issubfound = false;
                        isline = "N";
                        vchtype = Convert.ToString(ds.Tables[0].Rows[rwcnt]["vchtype"]);
                        if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["vchtype"]) == "JV")
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["amttype"]) == "Cr")
                            {
                                if (rnarr == false)
                                {
                                    if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["Entrytype"]) == "S") //salary addition/deduction voucher
                                    {
                                        trn = c.myconn.BeginTransaction();
                                        //str = "insert into tbl_cashbook (recno,r_date,r_particulars,r_details) values (" + linecnt  + ",'"+ds.Tables[0].Rows[rwcnt]["vchno"]+"','" + ds.Tables[0].Rows[rwcnt]["narration"] + " - Deductions " + "',' ' )";
                                        str = "insert into tbl_cashbook (recno,r_date,r_particulars,r_details) values (" + linecnt + ",'','" + ds.Tables[0].Rows[rwcnt]["narration"] + " - Deductions " + "',' ' )";
                                        c.connectsql(str, c.myconn, trn);
                                        trn.Commit();
                                        linecnt++;
                                        rnarr = true; //means only only one time print
                                    }
                                }
                                str = "select a.acname,b.subledgamt,isnull(a.lf,'') as lf from tbl_account a,tbl_subledger b where b.amttype='Cr' and a.accode=b.subledgercode and b.sessioncode=" + school.CurrentSessionCode + " and b.vchno=" + ds.Tables[0].Rows[rwcnt]["vchno"] + " and vchtype='" + ds.Tables[0].Rows[rwcnt]["vchtype"] + "' and vchdate='" + dtpfrom.Value.Date + "'";
                                DataSet ds1 = new DataSet();
                                c.filldataset(false, ref ds1, str, c.myconn);
                                subcnt = 0;
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    while (subcnt < ds1.Tables[0].Rows.Count)
                                    {
                                        trn = c.myconn.BeginTransaction();
                                        str = "insert into tbl_cashbook (recno,r_lf,r_date,r_particulars,r_details) values (" + (linecnt) + ",'" + ds1.Tables[0].Rows[subcnt]["lf"] + "','','" + ds1.Tables[0].Rows[subcnt]["acname"] + " - " + ds1.Tables[0].Rows[subcnt]["narration"] + "'," + ds1.Tables[0].Rows[subcnt]["subledgamt"] + ")";
                                        c.connectsql(str, c.myconn, trn);
                                        trn.Commit();
                                        issubfound = true;
                                        linecnt++;
                                        subcnt++;
                                    }
                                }
                                if (issubfound == true)
                                {
                                    isline = "Y";
                                }

                                if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["basicsal"]) == "Y")
                                {
                                    basicparticulars = Convert.ToString(ds.Tables[0].Rows[rwcnt]["acname"]);
                                    basicpay = Convert.ToString(ds.Tables[0].Rows[rwcnt]["receipt"]);
                                }
                                else
                                {
                                    trn = c.myconn.BeginTransaction();
                                    //str = "insert into tbl_cashbook (recno,r_lf,r_date,r_particulars,r_details,isline) values (" + (linecnt + 1) + ",'" + ds.Tables[0].Rows[rwcnt]["lf"] + "','" + ds.Tables[0].Rows[rwcnt]["vchno"] + "','" + ds.Tables[0].Rows[rwcnt]["acname"] + " - " + ds.Tables[0].Rows[rwcnt]["vchnarr"] + "'," + ds.Tables[0].Rows[rwcnt]["receipt"] + ",'" + isline + "')";
                                    str = "insert into tbl_cashbook (recno,r_lf,r_date,r_particulars,r_details,isline) values (" + (linecnt + 1) + ",'" + ds.Tables[0].Rows[rwcnt]["lf"] + "','','" + ds.Tables[0].Rows[rwcnt]["acname"] + " - " + ds.Tables[0].Rows[rwcnt]["vchnarr"] + "'," + ds.Tables[0].Rows[rwcnt]["receipt"] + ",'" + isline + "')";
                                    c.connectsql(str, c.myconn, trn);
                                    trn.Commit();
                                    linecnt++;
                                }

                                if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["Salarytype"]) == "DE")
                                {
                                    deduct = deduct + Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["receipt"]);
                                }
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["amttype"]) == "Dr")
                            {
                                //seach debit account in subledger 
                                //trn = c.myconn.BeginTransaction();
                                //str = "insert into tbl_cashbook (recno,p_date,p_particulars,p_details) values (" + (rwcnt + 1) + ",'" + ds.Tables[0].Rows[rwcnt]["vchno"] + "','" + ds.Tables[0].Rows[rwcnt]["narration"] + "'," + ds.Tables[0].Rows[rwcnt]["payment"] + ")";
                                //c.connectsql(str, c.myconn, trn);
                                //trn.Commit();      
                                if (deduct > 0)
                                {
                                    trn = c.myconn.BeginTransaction();
                                    str = "insert into tbl_cashbook (recno,r_date,r_particulars,r_details,isline) values (" + (linecnt) + ",'','Less - Deductions ','" + deduct + "','Y')";
                                    c.connectsql(str, c.myconn, trn);
                                    trn.Commit();
                                    linecnt++;
                                }

                                if (pnarr == false)
                                {
                                    if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["Entrytype"]) == "S") //salary addition/deduction voucher
                                    {
                                        trn = c.myconn.BeginTransaction();
                                        str = "insert into tbl_cashbook (recno,p_date,p_particulars,p_details) values (" + linecnt + ",'','" + ds.Tables[0].Rows[rwcnt]["narration"] + "',' ' )";
                                        c.connectsql(str, c.myconn, trn);
                                        trn.Commit();
                                        linecnt++;
                                        pnarr = true; //means only only one time print
                                    }
                                }

                                str = "select a.acname,b.subledgamt,isnull(a.lf,'') as lf from tbl_account a,tbl_subledger b where  b.amttype='Dr' and a.accode=b.subledgercode and b.sessioncode=" + school.CurrentSessionCode + " and b.vchno=" + ds.Tables[0].Rows[rwcnt]["vchno"] + " and vchtype='" + ds.Tables[0].Rows[rwcnt]["vchtype"] + "' and vchdate='" + dtpfrom.Value.Date + "'";
                                DataSet ds1 = new DataSet();
                                c.filldataset(false, ref ds1, str, c.myconn);
                                subcnt = 0;
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    while (subcnt < ds1.Tables[0].Rows.Count)
                                    {
                                        trn = c.myconn.BeginTransaction();
                                        str = "insert into tbl_cashbook (recno,p_lf,p_date,p_particulars,p_details) values (" + (linecnt) + ",'" + ds1.Tables[0].Rows[subcnt]["lf"] + "','','" + ds1.Tables[0].Rows[subcnt]["acname"] + "'," + ds1.Tables[0].Rows[subcnt]["subledgamt"] + ")";
                                        c.connectsql(str, c.myconn, trn);
                                        trn.Commit();
                                        linecnt++;
                                        subcnt++;
                                    }
                                }
                                trn = c.myconn.BeginTransaction();
                                str = "insert into tbl_cashbook (recno,p_date,p_particulars,p_details,isline) values (" + (linecnt) + ",'" + ds.Tables[0].Rows[rwcnt]["vchno"] + "','" + ds.Tables[0].Rows[rwcnt]["acname"] + "'," + ds.Tables[0].Rows[rwcnt]["payment"] + ",'Y')";
                                c.connectsql(str, c.myconn, trn);
                                linecnt++;
                                trn.Commit();

                                if (deduct > 0)
                                {
                                    trn = c.myconn.BeginTransaction();
                                    str = "insert into tbl_cashbook (recno,p_date,p_particulars,p_details,isline) values (" + (linecnt) + ",'','Less - Deductions ','" + deduct + "','N')";
                                    c.connectsql(str, c.myconn, trn);
                                    trn.Commit();
                                    linecnt++;
                                }
                                if (basicpay != "")
                                {
                                    trn = c.myconn.BeginTransaction();
                                    str = "insert into tbl_cashbook (recno,p_date,p_particulars,p_details,isline) values (" + (linecnt) + ",'','" + basicparticulars + "'," + basicpay + ",'Y')";
                                    c.connectsql(str, c.myconn, trn);
                                    trn.Commit();
                                    linecnt++;
                                }
                            }
                            pline = linecnt;
                            rline = linecnt;
                        }
                        ////////////////////////
                        // Journal Voucher Part Finished
                        ///

                        if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["vchtype"]) == "CR")
                        {

                            if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["amttype"]) == "Cr")
                            {
                                crlineno = 0;
                                trn = c.myconn.BeginTransaction();
                                if (rline >= pline)
                                {
                                    str = "insert into tbl_cashbook (recno,r_date,r_particulars,r_cash) values (" + (rline) + ",'" + vchtype + " - " + ds.Tables[0].Rows[rwcnt]["vchno"] + "',' From : " + ds.Tables[0].Rows[rwcnt]["acname"] + "  -  " + ds.Tables[0].Rows[rwcnt]["narration"] + "'," + ds.Tables[0].Rows[rwcnt]["receipt"] + ")";
                                }
                                else
                                {
                                    str = " Update  tbl_cashbook set r_date='" + vchtype + " - " + ds.Tables[0].Rows[rwcnt]["vchno"] + "' , r_particulars = ' From : " + ds.Tables[0].Rows[rwcnt]["acname"] + "  -  " + ds.Tables[0].Rows[rwcnt]["narration"] + "',r_cash=" + ds.Tables[0].Rows[rwcnt]["receipt"] + " where recno = " + rline;
                                }
                                c.connectsql(str, c.myconn, trn);
                                trn.Commit();
                                rcash = rcash + Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["receipt"]);
                                crlineno = linecnt;
                                rline++;
                                linecnt++;
                                //cashopbal = cashopbal + Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["receipt"]);
                                str = "select a.acname,b.subledgamt,isnull(a.lf,'') as lf from tbl_account a,tbl_subledger b where a.accode=b.subledgercode and b.sessioncode=" + school.CurrentSessionCode + " and b.vchno=" + ds.Tables[0].Rows[rwcnt]["vchno"] + " and vchtype='" + ds.Tables[0].Rows[rwcnt]["vchtype"] + "' and vchdate='" + dtpfrom.Value.Date + "'";
                                DataSet ds1 = new DataSet();
                                c.filldataset(false, ref ds1, str, c.myconn);
                                subcnt = 0;
                                if (ds1.Tables[0].Rows.Count > 0)
                                {

                                    while (subcnt < ds1.Tables[0].Rows.Count)
                                    {
                                        trn = c.myconn.BeginTransaction();
                                        if (rline >= pline)
                                        {
                                            str = "insert into tbl_cashbook (recno,r_lf,r_date,r_particulars,r_details) values (" + (rline) + ",'" + ds1.Tables[0].Rows[subcnt]["lf"] + "','','To : " + ds1.Tables[0].Rows[subcnt]["acname"] + " -- " + ds1.Tables[0].Rows[subcnt]["narration"] + "'," + ds1.Tables[0].Rows[subcnt]["subledgamt"] + ")";
                                        }
                                        else
                                        {
                                            str = "update tbl_cashbook set r_lf='" + ds1.Tables[0].Rows[subcnt]["lf"] + "',r_date='' ,r_particulars = ' To : " + ds1.Tables[0].Rows[subcnt]["acname"] + " -- " + ds1.Tables[0].Rows[subcnt]["narration"] + "',r_details=" + ds1.Tables[0].Rows[subcnt]["subledgamt"] + " where recno=" + rline;
                                        }
                                        c.connectsql(str, c.myconn, trn);
                                        trn.Commit();
                                        rline++;
                                        linecnt++;
                                        subcnt++;
                                    }
                                }
                                if (subcnt > 0)
                                {
                                    trn = c.myconn.BeginTransaction();
                                    if (rline >= pline)
                                    {
                                        str = "insert into tbl_cashbook (recno,r_details,isline) values (" + (linecnt) + ",'" + ds.Tables[0].Rows[rwcnt]["receipt"] + "','Y')";
                                    }
                                    else
                                    {
                                        str = "update tbl_cashbook set r_details='" + ds.Tables[0].Rows[rwcnt]["receipt"] + "',isline='Y' where recno=" + rline;
                                    }
                                    c.connectsql(str, c.myconn, trn);
                                    trn.Commit();
                                    rline++;
                                    linecnt++;
                                    if (pline > rline)
                                    {
                                        rline = pline;
                                    }
                                    else
                                    {
                                        pline = rline;
                                    }
                                }
                            }
                        }
                        //cashopbal = cashopbal - Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["payment"]);
                        //cplineno
                        if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["vchtype"]) == "CP")
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["amttype"]) == "Dr")
                            {
                                cplineno = 0;
                                trn = c.myconn.BeginTransaction();
                                if (pline >= rline)
                                {
                                    str = "insert into tbl_cashbook (recno,p_date,p_particulars,p_cash) values (" + (pline) + ",'" + vchtype + " - " + ds.Tables[0].Rows[rwcnt]["vchno"] + "',' To : " + ds.Tables[0].Rows[rwcnt]["acname"] + "  -  " + ds.Tables[0].Rows[rwcnt]["narration"] + "'," + ds.Tables[0].Rows[rwcnt]["payment"] + ")";
                                }
                                else
                                {
                                    str = "update tbl_cashbook set p_date='" + vchtype + " - " + ds.Tables[0].Rows[rwcnt]["vchno"] + "' ,p_particulars=' To : " + ds.Tables[0].Rows[rwcnt]["acname"] + "  -  " + ds.Tables[0].Rows[rwcnt]["narration"] + "',p_cash=" + ds.Tables[0].Rows[rwcnt]["payment"] + " where recno=" + pline;
                                }
                                c.connectsql(str, c.myconn, trn);
                                trn.Commit();
                                bplineno = linecnt;
                                pcash = pcash + Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["payment"]);
                                pline++;
                                linecnt++;
                                //cashopbal = cashopbal - Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["payment"]);
                                str = "select a.acname,b.subledgamt,isnull(a.lf,'') as lf from tbl_account a,tbl_subledger b where a.accode=b.subledgercode and b.sessioncode=" + school.CurrentSessionCode + " and b.vchno=" + ds.Tables[0].Rows[rwcnt]["vchno"] + " and vchtype='" + ds.Tables[0].Rows[rwcnt]["vchtype"] + "' and vchdate='" + dtpfrom.Value.Date + "'";
                                DataSet ds1 = new DataSet();
                                c.filldataset(false, ref ds1, str, c.myconn);
                                subcnt = 0;
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    while (subcnt < ds1.Tables[0].Rows.Count)
                                    {
                                        trn = c.myconn.BeginTransaction();
                                        if (pline >= rline)
                                        {
                                            str = "insert into tbl_cashbook (recno,p_lf,p_date,p_particulars,p_details) values (" + (pline) + ",'" + ds1.Tables[0].Rows[subcnt]["lf"] + "','','" + ds1.Tables[0].Rows[subcnt]["acname"] + "'," + ds1.Tables[0].Rows[subcnt]["subledgamt"] + ")";
                                        }
                                        else
                                        {
                                            str = "update tbl_cashbook set recno=" + pline + ",p_lf='" + ds1.Tables[0].Rows[subcnt]["lf"] + "',p_date='' , p_particulars='" + ds1.Tables[0].Rows[subcnt]["acname"] + "',p_details='" + ds1.Tables[0].Rows[subcnt]["subledgamt"] + " where recno=" + pline;
                                        }
                                        c.connectsql(str, c.myconn, trn);
                                        trn.Commit();
                                        pline++;
                                        linecnt++;
                                        subcnt++;
                                    }
                                }
                                if (subcnt > 0)
                                {
                                    trn = c.myconn.BeginTransaction();
                                    if (pline > rline)
                                    {
                                        str = "insert into tbl_cashbook (recno,p_details,isline) values (" + (pline) + ",'" + ds.Tables[0].Rows[rwcnt]["Payment"] + "','Y')";
                                    }
                                    else
                                    {
                                        str = "update tbl_cashbook set p_details=" + ds.Tables[0].Rows[rwcnt]["Payment"] + ",isline='Y' where recno=" + pline;
                                    }
                                    c.connectsql(str, c.myconn, trn);
                                    trn.Commit();
                                    pline++;
                                    linecnt++;
                                    if (pline > rline)
                                    {
                                        rline = pline;
                                    }
                                    else
                                    {
                                        pline = rline;
                                    }

                                }
                            }
                        }
                        ///
                        //for bank receipt
                        ///

                        if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["vchtype"]) == "BR")
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["amttype"]) == "Cr")
                            {
                                brlineno = 0;
                                trn = c.myconn.BeginTransaction();
                                if (rline >= pline)
                                {
                                    str = "insert into tbl_cashbook (recno,r_date,r_particulars,r_bank) values (" + (rline) + ",'" + vchtype + " - " + ds.Tables[0].Rows[rwcnt]["vchno"] + "',' From : " + ds.Tables[0].Rows[rwcnt]["acname"] + "  -  " + ds.Tables[0].Rows[rwcnt]["narration"] + "'," + ds.Tables[0].Rows[rwcnt]["receipt"] + ")";
                                }
                                else
                                {
                                    str = " Update  tbl_cashbook set  r_date='" + vchtype + " - " + ds.Tables[0].Rows[rwcnt]["vchno"] + "' , r_particulars = ' From : " + ds.Tables[0].Rows[rwcnt]["acname"] + "  -  " + ds.Tables[0].Rows[rwcnt]["narration"] + "',r_bank=" + ds.Tables[0].Rows[rwcnt]["receipt"] + " where recno = " + rline;
                                }
                                c.connectsql(str, c.myconn, trn);
                                trn.Commit();
                                brlineno = linecnt;
                                rbank = rbank + Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["receipt"]);
                                rline++;
                                linecnt++;
                                bankopbal = bankopbal + Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["receipt"]);
                                str = "select a.acname,b.subledgamt,isnull(a.lf,'') as lf from tbl_account a,tbl_subledger b where a.accode=b.subledgercode and b.sessioncode=" + school.CurrentSessionCode + " and b.vchno=" + ds.Tables[0].Rows[rwcnt]["vchno"] + " and vchtype='" + ds.Tables[0].Rows[rwcnt]["vchtype"] + "' and vchdate='" + dtpfrom.Value.Date + "'";
                                DataSet ds1 = new DataSet();
                                c.filldataset(false, ref ds1, str, c.myconn);
                                subcnt = 0;
                                if (ds1.Tables[0].Rows.Count > 0)
                                {

                                    while (subcnt < ds1.Tables[0].Rows.Count)
                                    {
                                        trn = c.myconn.BeginTransaction();
                                        //str = "insert into tbl_cashbook (recno,r_lf,r_date,r_particulars,r_details) values (" + (linecnt) + ",'" + ds1.Tables[0].Rows[subcnt]["lf"] + "','','" + ds1.Tables[0].Rows[subcnt]["acname"] + " -- "+ds1.Tables[0].Rows[subcnt]["narration"] +"'," + ds1.Tables[0].Rows[subcnt]["subledgamt"] + ")";
                                        if (rline >= pline)
                                        {
                                            str = "insert into tbl_cashbook (recno,r_lf,r_date,r_particulars,r_details) values (" + (rline) + ",'" + ds1.Tables[0].Rows[subcnt]["lf"] + "','','To : " + ds1.Tables[0].Rows[subcnt]["acname"] + " -- " + ds1.Tables[0].Rows[subcnt]["narration"] + "'," + ds1.Tables[0].Rows[subcnt]["subledgamt"] + ")";
                                        }
                                        else
                                        {
                                            str = "update tbl_cashbook set r_lf='" + ds1.Tables[0].Rows[subcnt]["lf"] + "',r_date='' ,r_particulars = ' To : " + ds1.Tables[0].Rows[subcnt]["acname"] + " -- " + ds1.Tables[0].Rows[subcnt]["narration"] + "',r_details=" + ds1.Tables[0].Rows[subcnt]["subledgamt"] + " where recno=" + rline;
                                        }
                                        c.connectsql(str, c.myconn, trn);
                                        trn.Commit();
                                        rline++;
                                        linecnt++;
                                        subcnt++;
                                    }
                                }
                                if (subcnt > 0)
                                {
                                    trn = c.myconn.BeginTransaction();
                                    if (rline >= pline)
                                    {
                                        str = "insert into tbl_cashbook (recno,r_details,isline) values (" + (linecnt) + ",'" + ds.Tables[0].Rows[rwcnt]["receipt"] + "','Y')";
                                    }
                                    else
                                    {
                                        str = "update tbl_cashbook set r_details=" + ds.Tables[0].Rows[rwcnt]["receipt"] + ",isline='Y' where recno=" + rline;
                                    }
                                    c.connectsql(str, c.myconn, trn);
                                    trn.Commit();
                                    rline++;
                                    linecnt++;
                                    if (pline > rline)
                                    {
                                        rline = pline;
                                    }
                                    else
                                    {
                                        pline = rline;
                                    }
                                }
                            }
                        }
                        ///
                        /// for bank payment
                        ///
                        if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["vchtype"]) == "BP")
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[rwcnt]["amttype"]) == "Dr")
                            {
                                bplineno = 0;
                                trn = c.myconn.BeginTransaction();
                                if (pline >= rline)
                                {
                                    str = "insert into tbl_cashbook (recno,p_date,p_particulars,p_bank) values (" + (pline) + ",'" + vchtype + " - " + ds.Tables[0].Rows[rwcnt]["vchno"] + "',' To : " + ds.Tables[0].Rows[rwcnt]["acname"] + "  -  " + ds.Tables[0].Rows[rwcnt]["narration"] + "'," + ds.Tables[0].Rows[rwcnt]["payment"] + ")";
                                }
                                else
                                {
                                    str = "update tbl_cashbook set p_date='" + vchtype + " - " + ds.Tables[0].Rows[rwcnt]["vchno"] + "' ,p_particulars=' To : " + ds.Tables[0].Rows[rwcnt]["acname"] + "  -  " + ds.Tables[0].Rows[rwcnt]["narration"] + "',p_bank=" + ds.Tables[0].Rows[rwcnt]["payment"] + " where recno=" + pline;
                                }
                                c.connectsql(str, c.myconn, trn);
                                trn.Commit();
                                bplineno = linecnt;
                                pbank = pbank + Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["payment"]);
                                pline++;
                                linecnt++;
                                bankopbal = bankopbal - Convert.ToDecimal(ds.Tables[0].Rows[rwcnt]["payment"]);
                                str = "select a.acname,b.subledgamt,isnull(a.lf,'') as lf from tbl_account a,tbl_subledger b where a.accode=b.subledgercode and b.sessioncode=" + school.CurrentSessionCode + " and b.vchno=" + ds.Tables[0].Rows[rwcnt]["vchno"] + " and vchtype='" + ds.Tables[0].Rows[rwcnt]["vchtype"] + "' and vchdate='" + dtpfrom.Value.Date + "'";
                                DataSet ds1 = new DataSet();
                                c.filldataset(false, ref ds1, str, c.myconn);
                                subcnt = 0;
                                if (ds1.Tables[0].Rows.Count > 0)
                                {
                                    while (subcnt < ds1.Tables[0].Rows.Count)
                                    {
                                        trn = c.myconn.BeginTransaction();
                                        if (pline >= rline)
                                        {
                                            str = "insert into tbl_cashbook (recno,p_lf,p_date,p_particulars,p_details) values (" + (pline) + ",'" + ds1.Tables[0].Rows[subcnt]["lf"] + "','','" + ds1.Tables[0].Rows[subcnt]["acname"] + "'," + ds1.Tables[0].Rows[subcnt]["subledgamt"] + ")";
                                        }
                                        else
                                        {
                                            str = "update tbl_cashbook set p_lf='" + ds1.Tables[0].Rows[subcnt]["lf"] + "',p_date='' , p_particulars='" + ds1.Tables[0].Rows[subcnt]["acname"] + "',p_details='" + ds1.Tables[0].Rows[subcnt]["subledgamt"] + " where recno=" + pline;
                                        }

                                        //str = "insert into tbl_cashbook (recno,r_lf,p_date,p_particulars,p_details) values (" + (linecnt) + ",'" + ds1.Tables[0].Rows[subcnt]["lf"] + "','','" + ds1.Tables[0].Rows[subcnt]["acname"] + "'," + ds1.Tables[0].Rows[subcnt]["subledgamt"] + ")";
                                        c.connectsql(str, c.myconn, trn);
                                        trn.Commit();
                                        pline++;
                                        linecnt++;
                                        subcnt++;
                                    }

                                }
                                if (subcnt > 0)
                                {
                                    trn = c.myconn.BeginTransaction();
                                    if (pline >= rline)
                                    {
                                        str = "insert into tbl_cashbook (recno,p_details,isline) values (" + (linecnt) + ",'" + ds.Tables[0].Rows[rwcnt]["Payment"] + "','Y')";
                                    }
                                    else
                                    {
                                        str = "update tbl_cashbook set p_details='" + ds.Tables[0].Rows[rwcnt]["Payment"] + "',isline='Y' where recno=" + pline;
                                    }
                                    c.connectsql(str, c.myconn, trn);
                                    trn.Commit();
                                    pline++;
                                    linecnt++;
                                    if (pline > rline)
                                    {
                                        rline = pline;
                                    }
                                    else
                                    {
                                        pline = rline;
                                    }
                                }
                            }
                        }
                        rwcnt++;
                    }
                  
                    //-----------

                    str = " SELECT sum( (case a.amttype when 'Dr' then a.vchamt else 0 end)) AS Payment, sum((case a.amttype when 'Cr' then a.vchamt else 0 end)) AS Receipt ";
                    str = str + " FROM tbl_voucherdet AS a, tbl_voucher AS b,tbl_account c  Where (a.vchtype='JV'  ";
                    str = str + " or (a.vchtype='CP' and a.amttype='Dr') or (a.vchtype='CR' and a.amttype='Cr'))  and  a.vchdate='" + dtpfrom.Value.ToShortDateString() + "'";
                    str = str + " and  a.sessioncode=" + school.CurrentSessionCode + " and  a.vchno = b.vchno and a.VCHTYPE = b.VCHTYPE and a.accode=c.accode and a.accode<>dbo.GetAccountCode('CS')";
                    ds = new DataSet();
                    c.filldataset(false, ref ds, str, c.myconn);

                    //-----------
                    decimal pamt=0, ramt=0,rsamt=0;
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        pamt = Convert.ToDecimal(ds.Tables[0].Rows[0]["Payment"].ToString());
                        ramt = Convert.ToDecimal(ds.Tables[0].Rows[0]["Receipt"].ToString());
                    }
                    rsamt =( ramt+cashopbal)- pamt;
                    trn = c.myconn.BeginTransaction();
                    str = "insert into tbl_cashbook (recno) values (" + (linecnt) + " )";
                    c.connectsql(str, c.myconn, trn);
                    linecnt++;
                    str = "insert into tbl_cashbook (recno,p_date,p_particulars,p_cash,p_bank,isbold) values (" + (linecnt) + ",'" + "" + "','Closing Balance'," + rsamt + "," + bankopbal + ",'Y')";
                    c.connectsql(str, c.myconn, trn);
                    linecnt++;
                    str = "insert into tbl_cashbook (recno,r_particulars,r_details,r_cash,r_bank,p_particulars,p_details,p_cash,p_bank,isbold) values (" + (linecnt) + ",'Total '," + (ramt+ cashopbal) + ",0," + rbank + ",'Total '," + (pamt+rsamt) + ",0," + pbank + ",'Y')";
                    c.connectsql(str, c.myconn, trn);
                    trn.Commit();
                    linecnt++;
                }

                //---------------------------------
                //mysql = "select '',' For  " + dtpfrom.Text + " to " + dtpto.Text + "' as period,accno,accname,accdate,convert(varchar(10),vchdate,105) as vchdate,vchtype,vchno,narration,amt,receipt,payment,balance,baltype,recno,amttype  from tbl_accledger order by vchdate ";
                string str1 = "select '',' For  " + dtpfrom.Text + " to " + dtpto.Text + "' as period,(select top 1 schoolname from tbl_school ) as SName,(select top 1 schooladdress from tbl_school ) as SAddress,*  from tbl_cashbook order by recno";
                ds = new DataSet();
                ds.Clear();
                ds = Connection.GetDataSet(str1);
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\CashBook.xsd");
                //ds.WriteXmlSchema(@"D:\XSDSchema1.xsd");
                //Account.ReportDesign.CashBook
                Account.ReportDesign.CashBook cr = new Account.ReportDesign.CashBook();
                cr.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
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

       
        private void FrmCashBook_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        

        
    }
}
