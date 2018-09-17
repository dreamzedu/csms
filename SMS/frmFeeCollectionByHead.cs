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
    public partial class frmFeeCollectionByHead :UserControlBase
    {
        public frmFeeCollectionByHead()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        Boolean MessageService = false;
        DataView dvStudent;
        static int StudentNo;
        static int ClassCode;
        static int AFlag;
        static bool trte = false;
        static string MobileNoOfStudentParent = string.Empty;
        school c = new school();
        void ClearControl()
        {
            txtTotalFeeAmount.Text = txtLateFee.Text = txtPaidAmont.Text = txtrecivedamt.Text
                = txtConsession.Text = txtdueamt.Text = "0";
            dtpfeedate.Value = DateTime.Now;
        }
        void TotalPaid()
        {
            try
            {
                txtdueamt.Text = (decimal.Parse(txtTotalFeeAmount.Text) -
                     decimal.Parse(txtPaidAmont.Text)).ToString();
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
        private void txtscholarno_Validated(object sender, EventArgs e)
        {
            if (!txtFeeRcptNo.Enabled)
            {
                if (!string.IsNullOrEmpty(txtscholarno.Text))
                {
                    lblstdtype.Text = Convert.ToString(Connection.GetExecuteScalar("SELECT DISTINCT Ltrim(Rtrim(tbl_classstudent.stdtype))   FROM tbl_student INNER JOIN tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno  WHERE     (tbl_student.scholarno = '" + txtscholarno.Text + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')    "));
                    DataSet ds = Connection.GetDataSet("SELECT  tbl_student.StudentNo, tbl_student.name, tbl_student.father,tbl_student.phone,tbl_classmaster.ClassCode, tbl_classmaster.classname + ' ' + tbl_section.sectionname + ' ' + tbl_sankay.sankayname AS Classname,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.BusStopNo, '-') Else  '-' End) AS BusStopNo,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopName, '-') Else  '-' End) AS StopName,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopFee, 0) Else 0 End) AS StopFee,tbl_student.IsRTE FROM tbl_classmaster INNER JOIN  " +
                     "  tbl_classstudent ON tbl_classmaster.classcode = tbl_classstudent.classno INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno LEFT OUTER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo " +
                     "  WHERE     (tbl_student.scholarno = '" + txtscholarno.Text.Trim() + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        frmFeeCollectionByHead.StudentNo = (int)(ds.Tables[0].Rows[0]["StudentNo"]);
                        frmFeeCollectionByHead.ClassCode = (int)ds.Tables[0].Rows[0]["ClassCode"];
                        lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        lblfather.Text = ds.Tables[0].Rows[0]["father"].ToString();
                        lblclass.Text = ds.Tables[0].Rows[0]["Classname"].ToString();
                        lblBusStop.Text = ds.Tables[0].Rows[0]["StopName"].ToString();
                        lblBusFee.Text = ds.Tables[0].Rows[0]["StopFee"].ToString();
                        MobileNoOfStudentParent = ds.Tables[0].Rows[0]["Phone"].ToString();
                        trte = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRTE"]);
                        DataTable dtFeeType = new DataTable();
                        if (lblstdtype.Text.Trim().Equals("Studying Student".Trim()))
                        {
                            if (trte)
                            {
                                dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as BAmount,0 as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  WHERE  (cfr.sessioncode = '" + school.CurrentSessionCode + "') And " +
                               "   (st.scholarno = '" + txtscholarno.Text.Trim() + "') AND (fh.feetype = '1') and cfr.RTE='True' AND (cs.stdtype = '" + lblstdtype.Text.Trim() + "')" +
                               "   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                            }
                            else
                            {
                                dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as BAmount,0 as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  WHERE  (cfr.sessioncode = '" + school.CurrentSessionCode + "') And " +
                                "   (st.scholarno = '" + txtscholarno.Text.Trim() + "') AND (fh.feetype = '1') AND (cs.stdtype = '" + lblstdtype.Text.Trim() + "')" +
                                "   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                            }
                        }
                        else if (lblstdtype.Text.Trim().Equals("New Student".Trim()))
                        {
                            if (trte)
                            {
                                dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as BAmount,0 as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode WHERE (cfr.sessioncode = '" + school.CurrentSessionCode + "') And" +
                               "   (st.scholarno = '" + txtscholarno.Text.Trim() + "') and cfr.RTE='True'  AND (cs.stdtype = '" + lblstdtype.Text.Trim() + "') " +
                               "   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                            }
                            else
                            {
                                dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as BAmount,0 as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode WHERE (cfr.sessioncode = '" + school.CurrentSessionCode + "') And" +
                               "   (st.scholarno = '" + txtscholarno.Text.Trim() + "')  AND (cs.stdtype = '" + lblstdtype.Text.Trim() + "') " +
                               "   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                            }
                        }
                        else
                        {
                            MessageBox.Show("You are not Elegible for submitted Fee...\n\tPlease Check Student Type From Student Master Form!!!");
                        }
                        dtgfee.Rows.Clear();
                        if (dtFeeType.Rows.Count > 0)
                        {
                            txtTotalFeeAmount.Text = "0";
                            if (Convert.ToDecimal(lblBusFee.Text) > 0)
                            {
                                decimal trcamt = 0;
                                trcamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetRecAmountByHead(101,'" + school.CurrentSessionCode + "','" + frmFeeCollectionByHead.StudentNo + "')"));
                                dtgfee.Rows.Add("101", "Bus Fee", lblBusFee.Text, trcamt, Convert.ToDecimal(lblBusFee.Text) - trcamt, 0);
                                txtTotalFeeAmount.Text = lblBusFee.Text;
                            }
                            foreach (DataRow dr in dtFeeType.Rows)
                            {
                                dtgfee.Rows.Add(dr["FeeCode"], dr["FeeHead"], dr["Amount"], dr["RAmount"], dr["BAmount"], dr["PAmount"]);
                                txtTotalFeeAmount.Text = (decimal.Parse(txtTotalFeeAmount.Text) + decimal.Parse(dr["Amount"].ToString())).ToString();
                            }
                        }

                        //*************************

                        DataTable dt = Connection.GetDataTable("select r.RecId as [Rcpt. No.] ,CONVERT(varchar, r.date, 106) AS Date,dbo.GetDueAmount(r.RecId,r.sessioncode,r.studentno)  AS [Due Amt.], isnull(sum(recamount),0) as [Rcv. Amt.],r.latefee AS [Late Fee],r.consession AS [Fee Consession] from  Tbl_Received  r inner join Tbl_ReceivedDetail rd  on r.RecId=rd.RecId and r.sessioncode=rd.sessioncode where     (r.sessioncode = '" + school.CurrentSessionCode + "') AND (r.studentno = '" + frmFeeCollectionByHead.StudentNo + "') group by r.RecId,r.latefee,r.consession,r.sessioncode,r.studentno,r.date");
                        if (dt.Rows.Count > 0)
                            dgvPaymentDetail.DataSource = dt;

                        SqlDataReader datareader = Connection.GetDataReader("select  isnull(sum(recamount),0) as recamount from  Tbl_Received  r inner join Tbl_ReceivedDetail rd  on r.RecId=rd.RecId and r.sessioncode=rd.sessioncode  where r.sessioncode='" + school.CurrentSessionCode + "'  " +
                            " And r.studentno='" + frmFeeCollectionByHead.StudentNo + "'");

                        if (datareader != null)
                        {
                            if (datareader.HasRows)
                            {
                                datareader.Read();
                                txtPaidAmont.Text = (datareader["recamount"]).ToString();

                                if (txtPaidAmont.Text.Equals(txtTotalFeeAmount.Text))
                                {
                                    MessageBox.Show("Fee Already Paid...", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtscholarno.SelectAll();
                                }
                            }
                        }

                        txtFeeRcptNo.Text = Convert.ToString(Connection.GetExecuteScalar("select dbo.GetTbl_ReceivedId('" + school.CurrentSessionCode + "')"));
                        this.TotalPaid();
                    }
                    else
                    {
                        MessageBox.Show("Scholar No. Is Not Valid", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtscholarno.SelectAll();
                        txtscholarno.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Scholar No.", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtscholarno_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
         && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void frmFeeCollectionByHead_Load(object sender, EventArgs e)
        {
            dvStudent = Connection.GetDataSet("sp_AllStudent " + school.CurrentSessionCode).Tables[0].DefaultView;
            //30-March By Gtl Message Service Active/Deactive
            this.MessageService = Convert.ToBoolean(Connection.GetExecuteScalar("Select MessageService From tbl_School"));
            Connection.SetUserLevelAuth(c.GetMdiParent(this));
            gbxFeeDetail.Location = gbxFeeCollection.Location;
            gbxStudentDetail.Location = gbxFeeCollection.Location;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_Validated(object sender, EventArgs e)
        {
            gbxStudentDetail.Visible = false;
            txtSearch.Text = "Search By Student Name";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()) && !txtSearch.Text.Equals("Search By Student Name"))
            {
                dvStudent.RowFilter = ("Name Like '" + txtSearch.Text.Trim() + "%'");
                if (dvStudent.RowFilter.Length > 0)
                {
                    gbxStudentDetail.Visible = true;
                    dataGridView1.DataSource = dvStudent;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                        {
                            ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                            break;
                        }
                }
                else
                {

                    dataGridView1.DataSource = dvStudent;
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                        {
                            ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                            break;
                        }
                }
            }
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            gbxFeeCollection.Enabled = true;
            this.ClearControl();
           c.GetMdiParent(this).ToggleSaveButton(true);
           c.GetMdiParent(this).ToggleEditButton(false);
            c.GetMdiParent(this).ToggleNewButton(false);
            c.GetMdiParent(this).ToggleCancelButton(true);
            txtFeeRcptNo.Enabled = false;
            txtscholarno.Enabled = true;
            txtscholarno.SelectAll();
            txtscholarno.Focus();
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            gbxFeeCollection.Enabled = true;
            this.ClearControl();
           c.GetMdiParent(this).ToggleSaveButton(true);
            c.GetMdiParent(this).ToggleNewButton(false);
           c.GetMdiParent(this).ToggleEditButton(false);
           c.GetMdiParent(this).ToggleCancelButton(true);
            txtscholarno.Enabled = false;
            txtFeeRcptNo.Enabled = true;
            txtFeeRcptNo.ReadOnly = false;
            txtFeeRcptNo.Focus();
        }
        static decimal TRecFee = 0;
        public override void btnsave_Click(object sender, EventArgs e)
        {
            SqlTransaction trn = null;
            try
            {
                string MonthName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dtpfeedate.Value.Month);
                if (string.IsNullOrEmpty(txtscholarno.Text))
                {
                    MessageBox.Show("Scholar No. Not Available.");
                }
                else
                {
                    DateTime cdt = DateTime.Now;
                    DateTime ddt = dtpfeedate.Value;
                    string Itdate = string.Empty;
                    //if (cdt.ToString("dd/MM/yyyy").Equals(ddt.ToString("dd/MM/yyyy")))
                    //{

                    if (txtFeeRcptNo.Enabled == false)
                    {
                        trn = Connection.GetMyConnection().BeginTransaction();
                        c.getconnstr();
                        decimal tpdamt = 0;
                        for (int rows = 0; rows < dtgfee.Rows.Count; rows++)
                        {
                            decimal ramt = Convert.ToDecimal(dtgfee.Rows[rows].Cells["PAmount"].Value.ToString());
                            if (ramt > 0)
                            {
                                tpdamt = tpdamt + ramt;
                            }

                        }
                        txtFeeRcptNo.Text = Convert.ToString(Connection.GetExecuteScalar("select dbo.GetTbl_ReceivedId('" + school.CurrentSessionCode + "')"));
                        Connection.SqlTransection("insert into Tbl_Received(sessioncode,RecId, studentno, date, latefee,consession,dueamount) " +
                        " values ('" + school.CurrentSessionCode + "',dbo.GetTbl_ReceivedId('" + school.CurrentSessionCode + "'),'" + frmFeeCollectionByHead.StudentNo + "','" + dtpfeedate.Value.Date + "' ,'" + txtLateFee.Text + "','" + txtConsession.Text + "','" + (decimal.Parse(txtdueamt.Text) - tpdamt) + "')",
                        Connection.MyConnection, trn);
                        //----------A*A-------
                        for (int rows = 0; rows < dtgfee.Rows.Count; rows++)
                        {
                            decimal ramt = Convert.ToDecimal(dtgfee.Rows[rows].Cells["PAmount"].Value.ToString());
                            if (ramt > 0)
                            {
                                Connection.SqlTransection("insert into Tbl_ReceivedDetail(RecDId,RecId, feecode, RecAmount,sessioncode) " +
                             " values (dbo.GetTbl_ReceivedDetailId(), dbo.GetTbl_ReceivedMaxId('" + school.CurrentSessionCode + "'),'" + dtgfee.Rows[rows].Cells["FeeCode"].Value.ToString() + "','" + dtgfee.Rows[rows].Cells["PAmount"].Value.ToString() + "','" + school.CurrentSessionCode + "')",
                             Connection.MyConnection, trn);
                                TRecFee = TRecFee + decimal.Parse(dtgfee.Rows[rows].Cells["PAmount"].Value.ToString());
                            }

                        }
                        //---------------------

                        trn.Commit();
                        Itdate = Convert.ToString(Connection.GetExecuteScalar("select s_from from tbl_session where sessioncode=(select min(sessioncode) from Tbl_Received where studentno='" + frmFeeCollectionByHead.StudentNo + "')"));
                        if (Itdate == string.Empty)
                        {
                            Itdate = Convert.ToString(Connection.GetExecuteScalar("select s_from from tbl_session where sessioncode='" + school.CurrentSessionCode + "'"));
                        }
                        int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_account where accode='" + frmFeeCollectionByHead.StudentNo + "' and actype=dbo.GetAccountCode('F')"));
                        trn = Connection.GetMyConnection().BeginTransaction();
                        if (CCEID < 1)
                        {

                            Connection.SqlTransection("insert into dbo.tbl_account(accode, acname, actype, acopbal, acoptype, apanno, accaddress, budgtype, opdate, subledger,lf,issaldeduct) " +
                            " values ('" + frmFeeCollectionByHead.StudentNo + "',dbo.GetSName('" + frmFeeCollectionByHead.StudentNo
                            + "'),dbo.GetAccountCode('F'),0,'Cr','none','none',0,'" + Itdate + "',0,'1',0)",
                            Connection.MyConnection, trn);
                        }
                        ////------------------ this is previous session receipt entry----------
                        trn.Commit();
                        DataSet ds = new DataSet();
                        ds = Connection.GetDataSet("select distinct sessioncode from tbl_feemaster where studentno='" + frmFeeCollectionByHead.StudentNo + "'");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                int icnt = 0;
                                icnt = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_voucherdet where accode='" + frmFeeCollectionByHead.StudentNo + "' and sessioncode='" + ds.Tables[0].Rows[i]["sessioncode"].ToString() + "'"));
                                if (icnt < 1)
                                {
                                    AFlag = 1;
                                    DataSet ids = new DataSet();
                                    ids = Connection.GetDataSet("select * from tbl_feemaster where studentno='" + frmFeeCollectionByHead.StudentNo + "' and sessioncode='" + ds.Tables[0].Rows[i]["sessioncode"].ToString() + "' order by rcptno");
                                    trn = Connection.GetMyConnection().BeginTransaction();
                                    if (ids.Tables[0].Rows.Count > 0)
                                    {

                                        for (int j = 0; j < ids.Tables[0].Rows.Count; j++)
                                        {
                                            //insert Voucher main
                                            Connection.SqlTransection("insert into dbo.tbl_Voucher(VchNo, VchType, VchDate, Remark, sessioncode) " +
                                            " values ('" + ids.Tables[0].Rows[j]["rcptno"].ToString() + "','JV','" + ids.Tables[0].Rows[j]["rcptdate"].ToString() + "','Paid Fee By Student','" +
                                            ids.Tables[0].Rows[j]["sessioncode"].ToString() + "')",
                                            Connection.MyConnection, trn);

                                            //insert Voucher Detail Dr

                                            Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                                                ids.Tables[0].Rows[j]["sessioncode"].ToString() + "','JV','" + ids.Tables[0].Rows[j]["rcptno"].ToString() + "',dbo.GetAccountCode('CS'),'" +
                                                ((decimal.Parse(ids.Tables[0].Rows[j]["latefee"].ToString()) + decimal.Parse(ids.Tables[0].Rows[j]["rcvdamt"].ToString())) - decimal.Parse(ids.Tables[0].Rows[j]["consession"].ToString())) + "','" +
                                                ids.Tables[0].Rows[j]["rcptdate"].ToString() + "','Dr','S')",
                                            Connection.MyConnection, trn);

                                            //insert Voucher Detail Cr
                                            Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                                                ids.Tables[0].Rows[j]["sessioncode"].ToString() + "','JV','" + ids.Tables[0].Rows[j]["rcptno"].ToString() + "','" + frmFeeCollectionByHead.StudentNo + "','" +
                                                ((decimal.Parse(ids.Tables[0].Rows[j]["latefee"].ToString()) + decimal.Parse(ids.Tables[0].Rows[j]["rcvdamt"].ToString())) - decimal.Parse(ids.Tables[0].Rows[j]["consession"].ToString())) + "','" +
                                                ids.Tables[0].Rows[j]["rcptdate"].ToString() + "','Cr','M')",
                                            Connection.MyConnection, trn);
                                        }

                                    }
                                    trn.Commit();
                                }
                                else
                                {
                                    //do something.....
                                }

                            }
                        }
                        ////--------------------------------------------- end previous year transaction------------
                        if (AFlag == 0)
                        {
                            trn = Connection.GetMyConnection().BeginTransaction();

                            //insert Voucher main
                            Connection.SqlTransection("insert into dbo.tbl_Voucher(VchNo, VchType, VchDate, Remark, sessioncode) " +
                            " values ('" + txtFeeRcptNo.Text + "','JV','" + dtpfeedate.Value.Date + "','Paid Fee By Student','" +
                            school.CurrentSessionCode + "')",
                            Connection.MyConnection, trn);

                            //insert Voucher Detail Dr

                            Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                                school.CurrentSessionCode + "','JV','" + txtFeeRcptNo.Text + "',dbo.GetAccountCode('CS'),'" +
                                ((decimal.Parse(txtLateFee.Text) + tpdamt) - decimal.Parse(txtConsession.Text)) + "','" +
                                dtpfeedate.Value.Date + "','Dr','S')",
                            Connection.MyConnection, trn);

                            //insert Voucher Detail Cr
                            Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                                school.CurrentSessionCode + "','JV','" + txtFeeRcptNo.Text + "','" + frmFeeCollectionByHead.StudentNo + "','" +
                                ((decimal.Parse(txtLateFee.Text) + tpdamt) - decimal.Parse(txtConsession.Text)) + "','" +
                                dtpfeedate.Value.Date + "','Cr','M')",
                            Connection.MyConnection, trn);


                            trn.Commit();
                        }

                        //Short Messaging Services
                        #region "Messaging Services"
                        if (this.MessageService)
                        {
                            DataTable dtStudent = Connection.GetDataTable("SELECT ISNULL(schoolname,'') as schoolname, schooladdress, schoolcity, ISNULL(schoolphone,0) as schoolphone, affiliate_by, " +
                                " principal, registrationno, logoimage, ISNULL(Website,'') as Website, MessageService,MessageSenderID,MessageUserName,MessagePassword FROM tbl_school");
                            try
                            {
                                if (!string.IsNullOrEmpty(MobileNoOfStudentParent))
                                {
                                    Connection.SendSMS(MobileNoOfStudentParent,
                                        "Thank you for submitting your Fee" +
                                        "\nReceived Amount: " + TRecFee.ToString() +
                                        "\nDue Amount: " + (decimal.Parse(txtdueamt.Text) - TRecFee) +
                                        "\n" + dtStudent.Rows[0]["schoolname"].ToString() +         //School Name
                                        " for more detail contact on " +
                                        dtStudent.Rows[0]["schoolphone"].ToString() +               //Contact No.
                                        " and visit us:\n" +
                                        dtStudent.Rows[0]["Website"].ToString());                   //Website
                                }
                            }
                            catch(Exception ex){Logger.LogError(ex); }
                        }
                        #endregion
                        if (this.MessageService)
                            MessageBox.Show("Fee Transaction Completed...\n\tMessage Sent!!!", "School");
                        else
                            MessageBox.Show("Fee Transaction Completed...");
                    }
                    else
                    {
                        trn = Connection.GetMyConnection().BeginTransaction();
                        c.getconnstr();

                        Connection.SqlTransection("Update Tbl_Received SET date ='" + dtpfeedate.Value.Date + "' ,  latefee='" + txtLateFee.Text + "',consession='" + txtConsession.Text + "' " +
                        " Where SessionCode='" + school.CurrentSessionCode + "' And RecId='" + txtFeeRcptNo.Text + "' And studentno='" + frmFeeCollectionByHead.StudentNo + "' And Status='True'  ",
                        Connection.MyConnection, trn);

                        Connection.SqlTransection("delete Tbl_ReceivedDetail  Where  RecId='" + txtFeeRcptNo.Text + "'",
                        Connection.MyConnection, trn);
                        decimal tpdamt = 0;

                        //----------A*A-------
                        for (int rows = 0; rows < dtgfee.Rows.Count; rows++)
                        {
                            decimal ramt = Convert.ToDecimal(dtgfee.Rows[rows].Cells["PAmount"].Value.ToString());
                            if (ramt > 0)
                            {
                                Connection.SqlTransection("insert into Tbl_ReceivedDetail(RecDId,RecId, feecode, RecAmount,SessionCode) " +
                             " values (dbo.GetTbl_ReceivedDetailId(), '" + txtFeeRcptNo.Text.Trim() + "','" + dtgfee.Rows[rows].Cells["FeeCode"].Value.ToString() + "','" + dtgfee.Rows[rows].Cells["PAmount"].Value.ToString() + "','" + school.CurrentSessionCode + "')",
                             Connection.MyConnection, trn);
                                TRecFee = TRecFee + decimal.Parse(dtgfee.Rows[rows].Cells["PAmount"].Value.ToString());
                                tpdamt = tpdamt + ramt;
                            }

                        }
                        //---------------------

                        //*--delete prvious voucher-------------
                        c.connectsql("delete from tbl_voucherdet where sessioncode=" + school.CurrentSessionCode + " and vchtype='JV' and amttype='Cr' and vchno=" + txtFeeRcptNo.Text, Connection.MyConnection, trn);
                        c.connectsql("delete from tbl_voucherdet where sessioncode=" + school.CurrentSessionCode + " and vchtype='JV' and amttype='Dr' and vchno=" + txtFeeRcptNo.Text, Connection.MyConnection, trn);
                        //*------------------
                        //insert Voucher Detail Cr
                        Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                            school.CurrentSessionCode + "','JV','" + txtFeeRcptNo.Text + "',dbo.GetAccountCode('CS'),'" +
                            ((decimal.Parse(txtLateFee.Text) + tpdamt) - decimal.Parse(txtConsession.Text)) + "','" +
                            dtpfeedate.Value.Date + "','Dr','S')",
                        Connection.MyConnection, trn);
                        //insert Voucher Detail Dr
                        Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                            school.CurrentSessionCode + "','JV','" + txtFeeRcptNo.Text + "','" + frmFeeCollectionByHead.StudentNo + "','" +
                            ((decimal.Parse(txtLateFee.Text) + tpdamt) - decimal.Parse(txtConsession.Text)) + "','" +
                            dtpfeedate.Value.Date + "','Cr','M')",
                        Connection.MyConnection, trn);
                        trn.Commit();



                        //Short Messaging Services
                        #region "Messaging Services"
                        if (this.MessageService)
                        {
                            DataTable dtStudent = Connection.GetDataTable("SELECT ISNULL(schoolname,'') as schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, " +
                                " principal, registrationno, logoimage, ISNULL(Website,'') as Website, MessageService,MessageSenderID,MessageUserName,MessagePassword FROM tbl_school");
                            try
                            {
                                if (!string.IsNullOrEmpty(MobileNoOfStudentParent))
                                {
                                    Connection.SendSMS(MobileNoOfStudentParent,
                                        "Thank you for submitting your Fee" +
                                        "\nReceived Amount: " + TRecFee +
                                        "\nDue Amount: " + (decimal.Parse(txtdueamt.Text) - TRecFee) +
                                        "\n" + dtStudent.Rows[0]["schoolname"].ToString() +         //School Name
                                        " for more detail visit us:\n" +
                                        dtStudent.Rows[0]["Website"].ToString());                   //Website
                                }
                            }
                            catch(Exception ex){Logger.LogError(ex); }
                        }
                        #endregion
                        if (this.MessageService)
                            MessageBox.Show("Fee Transaction Completed...\n\tMessage Sent!!!", "School");
                        else
                            MessageBox.Show("Fee Transaction Completed...");
                    }
                    gbxFeeCollection.Enabled = false;
                   c.GetMdiParent(this).ToggleSaveButton(false);
                   c.GetMdiParent(this).ToggleNewButton(true);
                   c.GetMdiParent(this).ToggleEditButton(true);
                   c.GetMdiParent(this).ToggleCancelButton(false);
                    txtFeeRcptNo.Enabled = false;
                    c.GetMdiParent(this).TogglePrintButton(true);
                    this.ClearControl();
                    //}
                    //else
                    //    MessageBox.Show("Please select Current Date.", "School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                trn.Rollback();
                MessageBox.Show("Fee Transaction Is Not Completed.\n\tPlease Try Again.");
                Logger.LogError(ex); 
               c.GetMdiParent(this).ToggleSaveButton(false);
            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            gbxFeeCollection.Enabled = false;
           c.GetMdiParent(this).ToggleSaveButton(false);
            txtFeeRcptNo.Enabled = false;
            c.GetMdiParent(this).ToggleNewButton(true);
           c.GetMdiParent(this).ToggleEditButton(true);
           c.GetMdiParent(this).ToggleCancelButton(false);
           c.GetMdiParent(this).TogglePrintButton(false);
            
            this.ClearControl();
            
            Connection.SetUserLevelAuth(c.GetMdiParent(this));
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
                /*DataSet ds = Connection.GetDataSet("SELECT tbl_student.studentno, tbl_student.scholarno, tbl_student.name, tbl_student.dob, tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class " +
                " , tbl_session.sessionname,  tbl_student.marr_status AS gender, tbl_student.phone, (CASE WHEN tbl_student.busfacility = 1 THEN tbl_StopDetails.StopName ELSE ISNULL(tbl_student.P_address,tbl_tehsil.tehsil) END) AS StopName " +
                " , tbl_StopDetails.StopFee, tbl_feemaster.rcptno " +
                " , tbl_feemaster.rcptdate, tbl_feemaster.rcvdamt, tbl_feemaster.totalpaidfee, tbl_feemaster.dueamount, tbl_feemaster.latefee, tbl_feemaster.totfeeamt, tbl_feemaster.monthname " +
                " , tbl_feemaster.consession FROM tbl_section INNER JOIN tbl_session INNER JOIN tbl_feemaster ON tbl_session.sessioncode = tbl_feemaster.sessioncode INNER JOIN tbl_student ON  " +
                "   tbl_feemaster.studentno = tbl_student.studentno INNER JOIN tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno AND tbl_session.sessioncode = tbl_classstudent.sessioncode  " +
                "   INNER JOIN tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode ON tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode " +
                "   INNER JOIN tbl_district ON tbl_student.distcode = tbl_district.distcode INNER JOIN tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode AND tbl_district.distcode = tbl_tehsil.distcode LEFT OUTER JOIN  " +
                "   tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo WHERE (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') AND (tbl_feemaster.rcptno = '" + txtFeeRcptNo.Text.Trim() + "'); " +
                "   SELECT schoolname, schooladdress, affiliate_by, logoimage, schoolcity, schoolphone, principal, registrationno FROM tbl_school ");*/
            DataSet ds = Connection.GetDataSet("GetRecPrint " + school.CurrentSessionCode + "," + txtFeeRcptNo.Text.Trim());
            try
            {
                bool b = Convert.ToBoolean(Connection.GetExecuteScalar("Select DualSlipType From tbl_FeeHeads"));
                if (b)
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptFeeReceiptNew.xsd");
                    rptFeeSlipNew cr = new rptFeeSlipNew();
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    //cr.SetParameterValue("Title", "FEE RECEIPT");
                    s.Show();

                }
                else
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptFeeReceiptSingleNew.xsd");
                    rptFeeSlipSingleNew cr = new rptFeeSlipSingleNew();
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    // System.Drawing.Printing.PaperSize pr = new System.Drawing.Printing.PaperSize("Atul", 4, 6);
                    Size sz = new Size(4, 6);
                    s.crystalReportViewer1.ReportSource = cr;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelopePersonal;
                    s.Show();
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }


        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtscholarno.Text = dataGridView1.Rows[e.RowIndex].Cells["Scholar No"].Value as string;
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.Columns["ClassCode"].Visible = false;
                dataGridView1.Columns["SectionCode"].Visible = false;
                dataGridView1.Columns["Photo"].Visible = false;

            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["Scholar No"].ColumnIndex))
                {
                    txtscholarno.Text = dataGridView1.Rows[e.RowIndex].Cells["Scholar No"].Value as string;
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtFeeRcptNo_Leave(object sender, EventArgs e)
        {
            dtpfeedate.Focus();
        }

        private void txtFeeRcptNo_Validated(object sender, EventArgs e)
        {
            if (txtFeeRcptNo.Enabled && !string.IsNullOrEmpty(txtFeeRcptNo.Text.Trim()))
            {
                DataTable sdr = Connection.GetDataTable("Declare @i int Declare @d datetime set @i=(SELECT COUNT(*) FROM Tbl_Received " +
                " WHERE RecId = '" + txtFeeRcptNo.Text.Trim() + "' AND sessioncode = '" + school.CurrentSessionCode + "' AND date < " +
                " (Select Max(date) FROM Tbl_Received WHERE Status = 'true' AND sessioncode = '" + school.CurrentSessionCode + "' AND studentno =" +
                " (SELECT studentno FROM Tbl_Received WHERE Status = 'true' AND sessioncode ='" + school.CurrentSessionCode + "' AND RecId = '" + txtFeeRcptNo.Text.Trim() + "'))) " +
                " set @d=(Select Max(date)FROM Tbl_Received WHERE Status = 'true' AND sessioncode = '" + school.CurrentSessionCode + "' AND studentno = " +
                " (SELECT studentno FROM Tbl_Received WHERE Status = 'true' AND sessioncode = '" + school.CurrentSessionCode + "' AND RecId ='" + txtFeeRcptNo.Text.Trim() + "')) " +
                " Select @i,Convert(Varchar,@d,106) ");
                if (sdr.Rows.Count > 0)
                {
                    if (Convert.ToInt32(sdr.Rows[0][0]) == 0)
                    {
                        frmFeeCollectionByHead.StudentNo = Convert.ToInt32(Connection.GetExecuteScalar("SELECT ISNULL(studentno,-1000) FROM Tbl_Received WHERE (RecId = '" + txtFeeRcptNo.Text.Trim() + "') AND (sessioncode = '" + school.CurrentSessionCode + "')"));
                        DataTable dtStudent = Connection.GetDataTable("SELECT  tbl_student.StudentNo,tbl_student.ScholarNo, tbl_student.name, tbl_student.father,tbl_classmaster.ClassCode, tbl_classmaster.classname + ' ' + tbl_section.sectionname + ' ' + tbl_sankay.sankayname AS Classname,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.BusStopNo, '-') Else  '-' End) AS BusStopNo,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopName, '-') Else  '-' End) AS StopName,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopFee, 0) Else 0 End) AS StopFee, LTRIM(RTRIM(tbl_classstudent.stdtype)) AS Status,tbl_student.IsRTE FROM tbl_classmaster INNER JOIN  " +
                         "  tbl_classstudent ON tbl_classmaster.classcode = tbl_classstudent.classno INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno LEFT OUTER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo " +
                         "  WHERE (tbl_student.StudentNo = '" + frmFeeCollectionByHead.StudentNo + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')");
                        if (dtStudent.Rows.Count > 0)
                        {
                            frmFeeCollectionByHead.StudentNo = (int)(dtStudent.Rows[0]["StudentNo"]);
                            frmFeeCollectionByHead.ClassCode = (int)dtStudent.Rows[0]["ClassCode"];
                            lblname.Text = dtStudent.Rows[0]["name"].ToString();
                            lblfather.Text = dtStudent.Rows[0]["father"].ToString();
                            lblclass.Text = dtStudent.Rows[0]["Classname"].ToString();
                            lblBusStop.Text = dtStudent.Rows[0]["StopName"].ToString();
                            lblBusFee.Text = dtStudent.Rows[0]["StopFee"].ToString();
                            lblstdtype.Text = dtStudent.Rows[0]["Status"].ToString();
                            txtscholarno.Text = dtStudent.Rows[0]["ScholarNo"].ToString();
                            DataTable dtFeeType = new DataTable();
                            if (lblstdtype.Text.Trim().Equals("Studying Student".Trim()))
                            {
                                dtFeeType = Connection.GetDataTable("GetRecDetailFor " + school.CurrentSessionCode + "," + txtFeeRcptNo.Text.Trim() + ",'Studying Student'");
                                //    dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,'" + txtFeeRcptNo.Text.Trim() + "') as RAmount, (cfr.feeamt -dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,'" + txtFeeRcptNo.Text.Trim() + "')) as BAmount,dbo.GetRecAmountByHeadRecCurrent(fh.feecode,cfr.sessioncode,st.studentno,'" + txtFeeRcptNo.Text.Trim() + "') as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  WHERE  (cfr.sessioncode = '" + school.CurrentSessionCode + "') And " +
                                //"   (st.scholarno = '" + txtscholarno.Text.Trim() + "') AND (fh.feetype = '1') AND (cs.stdtype = '" + lblstdtype.Text.Trim() + "')" +
                                //"   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                            }
                            else if (lblstdtype.Text.Trim().Equals("New Student".Trim()))
                            {
                                dtFeeType = Connection.GetDataTable("GetRecDetailFor " + school.CurrentSessionCode + "," + txtFeeRcptNo.Text.Trim() + ",'New Student'");
                                //   dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,'" + txtFeeRcptNo.Text.Trim() + "') as RAmount, (cfr.feeamt -dbo.GetRecAmountByHeadRec(fh.feecode,cfr.sessioncode,st.studentno,'" + txtFeeRcptNo.Text.Trim() + "')) as BAmount,dbo.GetRecAmountByHeadRecCurrent(fh.feecode,cfr.sessioncode,st.studentno,'" + txtFeeRcptNo.Text.Trim() + "') as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  WHERE  (cfr.sessioncode = '" + school.CurrentSessionCode + "') And " +
                                //"   (st.scholarno = '" + txtscholarno.Text.Trim() + "')  AND (cs.stdtype = '" + lblstdtype.Text.Trim() + "')" +
                                //"   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                            }
                            else
                            {
                                MessageBox.Show("You are not Elegible for submitted Fee...\n\tPlease Check Student Type From Student Master Form!!!");
                            }
                            dtgfee.Rows.Clear();
                            if (dtFeeType.Rows.Count > 0)
                            {
                                txtTotalFeeAmount.Text = "0";
                                if (Convert.ToDecimal(lblBusFee.Text) > 0)
                                {
                                    //dtgfee.Rows.Add("101", "Bus Fee", lblBusFee.Text,0,0,0);
                                    txtTotalFeeAmount.Text = lblBusFee.Text;
                                }
                                foreach (DataRow dr in dtFeeType.Rows)
                                {
                                    dtgfee.Rows.Add(dr["FeeCode"], dr["FeeHead"], dr["Amount"], dr["RAmount"], dr["BAmount"], dr["PAmount"]);
                                    txtTotalFeeAmount.Text = (decimal.Parse(txtTotalFeeAmount.Text) + decimal.Parse(dr["Amount"].ToString())).ToString();
                                }
                            }
                            DataTable dt = Connection.GetDataTable("select r.RecId as [Rcpt. No.] ,CONVERT(varchar, r.date, 106) AS Date,dbo.GetDueAmount(r.RecId,r.sessioncode,r.studentno)  AS [Due Amt.], isnull(sum(recamount),0) as [Rcv. Amt.],r.latefee AS [Late Fee],r.consession AS [Fee Consession] from  Tbl_Received  r inner join Tbl_ReceivedDetail rd  on r.RecId=rd.RecId and r.sessioncode=rd.sessioncode where     (r.sessioncode = '" + school.CurrentSessionCode + "') AND (r.studentno = '" + frmFeeCollectionByHead.StudentNo + "') group by r.RecId,r.latefee,r.consession,r.sessioncode,r.studentno,r.date");
                            if (dt.Rows.Count > 0)
                                dgvPaymentDetail.DataSource = dt;

                            ////In LIS 13-Apr-2014
                            //SqlDataReader datareader = Connection.GetDataReader("SELECT sessioncode, studentno, ISNULL(SUM(rcvdamt), 0) AS RcvAmt " +
                            //    " , ISNULL(SUM(totfeeamt), 0) AS TotFeeAmt FROM tbl_feemaster WHERE   RecId<>'" + txtFeeRcptNo.Text.Trim() + "' AND " +
                            //    "   sessioncode='" + school.CurrentSessionCode + "' And studentno='" + frmFeeCollecton.StudentNo + "' GROUP BY sessioncode, studentno");


                            SqlDataReader datareader = Connection.GetDataReader("select  isnull(sum(recamount),0) as recamount from  Tbl_Received  r inner join Tbl_ReceivedDetail rd  on r.RecId=rd.RecId and r.sessioncode=rd.sessioncode where r.sessioncode='" + school.CurrentSessionCode + "'  " +
                            " And r.studentno='" + frmFeeCollectionByHead.StudentNo + "'");

                            if (datareader != null)
                            {
                                datareader.Read();
                                txtPaidAmont.Text = (datareader["recamount"]).ToString();
                                if (txtPaidAmont.Text.Equals(txtTotalFeeAmount.Text))
                                {
                                    MessageBox.Show("Fee Already Paid...", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            DataTable dtFee = Connection.GetDataTable("select convert(varchar, r.RecId) as RecId,  date,dbo.GetDueAmount(r.RecId,r.sessioncode,r.studentno) as DueAmount, isnull(sum(recamount),0) as RecAmount,dbo.Num_ToWords(isnull(sum(recamount),0)) as Word,r.latefee,r.consession from  Tbl_Received  r inner join Tbl_ReceivedDetail rd  on r.RecId=rd.RecId and r.sessioncode=rd.sessioncode WHERE (r.RecId = '" + txtFeeRcptNo.Text.Trim() + "') AND (r.sessioncode = '" + school.CurrentSessionCode + "') group by r.RecId,r.latefee,r.consession,r.sessioncode,r.studentno,r.date");
                            if (dtFee.Rows.Count > 0)
                            {
                                //txtFeeAmount.Text = dtFee.Rows[0]["rcvdamt"].ToString();
                                txtdueamt.Text = dtFee.Rows[0]["DueAmount"].ToString();
                                txtLateFee.Text = dtFee.Rows[0]["latefee"].ToString();
                                txtConsession.Text = dtFee.Rows[0]["consession"].ToString();
                                dtpfeedate.Value = (DateTime)dtFee.Rows[0]["date"];
                                dtpfeedate.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Receipt No. Invadid.\n\tPlease Check Records.", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFeeRcptNo.SelectAll();
                            txtFeeRcptNo.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Attention!!!\n\tNow You Can Not Edit This Transaction About Receipt No. \"" + txtFeeRcptNo.Text.Trim() + "\"\n Because Fee Already Collected On Date " + sdr.Rows[0][1].ToString() + " Of This Student.", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFeeRcptNo.SelectAll();
                        txtFeeRcptNo.Focus();
                    }
                }
            }
        }

        private void txtFeeRcptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                dtpfeedate.Focus();
        }

        private void dgvPaymentDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dgvPaymentDetail, e);
        }

        private void txtLateFee_Leave(object sender, EventArgs e)
        {
            txtConsession.SelectAll();
            txtConsession.Focus();
        }

        private void txtLateFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals((object)Keys.Enter) || e.KeyCode.Equals((object)Keys.Tab))
            {
                txtConsession.SelectAll();
                txtConsession.Focus();
            }
        }
        void NetPayment()
        {
            try
            {
                decimal tramt = 0;
                for (int rows = 0; rows < dtgfee.Rows.Count; rows++)
                {
                    decimal ramt = Convert.ToDecimal(dtgfee.Rows[rows].Cells["PAmount"].Value.ToString());
                    if (ramt > 0)
                    {
                        tramt += ramt;
                    }

                }
                txtrecivedamt.Text = (decimal.Round((tramt +
                     decimal.Parse(txtLateFee.Text)) -
                      decimal.Parse(txtConsession.Text), 2)).ToString();

            }
            catch(Exception ex){Logger.LogError(ex); }
        }
        private void txtLateFee_TextChanged(object sender, EventArgs e)
        {
            this.NetPayment();
        }

        private void txtConsession_TextChanged(object sender, EventArgs e)
        {
            this.NetPayment();
        }

        private void txtConsession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals((object)Keys.Enter) || e.KeyCode.Equals((object)Keys.Tab))
            {
                
            }
        }

        private void txtConsession_Leave(object sender, EventArgs e)
        {
            
        }

        private void frmFeeCollectionByHead_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtSearch.Focus();
                gbxStudentDetail.Visible = true;
                gbxFeeDetail.Visible = false;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                gbxStudentDetail.Visible = false;
                gbxFeeDetail.Visible = false;
            }
            else if (e.KeyCode == Keys.F2)
            {
                gbxStudentDetail.Visible = false;
                gbxFeeDetail.Visible = true;
            }
            else
            {

                gbxStudentDetail.Visible = false;
                gbxFeeDetail.Visible = false;

            }
        }

        private void dtgfee_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dtgfee.CurrentCell.ColumnIndex == 5)
            {

                e.Control.KeyPress += new KeyPressEventHandler(gvAppSummary_KeyPress);
            }
        }

        private void gvAppSummary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
          && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void dtgfee_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            NetPayment();
            int c = 0, rintex = 0, row = 0;
            decimal rval = 0, bal = 0;
            c = dtgfee.RowCount;
            rintex = dtgfee.CurrentCell.RowIndex + 1;
            row = dtgfee.CurrentCell.RowIndex;
            bal = Convert.ToDecimal(dtgfee[4, row].Value);
            rval = Convert.ToDecimal(dtgfee[dtgfee.CurrentCell.ColumnIndex, row].Value);
            if (rval <= bal)
            {
                if (c == rintex)
                    txtLateFee.Focus();
            }
            else
            {

                //dtgfee.Rows[dtgfee.CurrentCell.RowIndex].Cells[dtgfee.CurrentCell.ColumnIndex].Selected = true;
                //dtgfee.BringToFront();

                dtgfee.CurrentCell = dtgfee.Rows[row].Cells[dtgfee.CurrentCell.ColumnIndex];
                dtgfee.CurrentCell.Selected = true;
                dtgfee[dtgfee.CurrentCell.ColumnIndex, row].Selected = true;
                MessageBox.Show("Recevied amount is less or equal to balance Amount.");
                dtgfee.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 0;
                NetPayment();

            }
        }

        private void txtFeeRcptNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
         && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtLateFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
         && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtConsession_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
         && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void frmFeeCollectionByHead_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);

        }

    }
}
