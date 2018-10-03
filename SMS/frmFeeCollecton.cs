using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class frmFeeCollecton :UserControlBase
    {
        Boolean MessageService = false;
        DataView dvStudent;
        static int StudentNo;
        static int AFlag;
        static int ClassCode;
        static bool trte = false, tsch=false;
        static string MobileNoOfStudentParent = string.Empty;
        school c = new school();
        public frmFeeCollecton()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmFeeCollecton_Load(object sender, EventArgs e)
        {
            dvStudent = Connection.GetDataSet("sp_AllStudent " + school.CurrentSessionCode).Tables[0].DefaultView;
            //30-March By Gtl Message Service Active/Deactive
            this.MessageService = Convert.ToBoolean(Connection.GetExecuteScalar("Select MessageService From tbl_School"));
            Connection.SetUserLevelAuth(c.GetMdiParent(this));
            //c.GetMdiParent(this).EnableAllEditMenuButtons();
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

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_Validated(object sender, EventArgs e)
        {
        //    gbxStudentDetail.Visible = false;
            txtSearch.Text = "Search By Student Name";
        }

        void ClearControl()
        {
            txtTotalFeeAmount.Text = txtFeeAmount.Text = txtLateFee.Text = txtPaidAmont.Text = txtrecivedamt.Text
                = txtConsession.Text = txtdueamt.Text = txtschamt.Text = "0";
            //dtpfeedate.Value = DateTime.Now;
        }

        private void txtscholarno_Validated(object sender, EventArgs e)
        {
            if (!txtFeeRcptNo.Enabled)
            {
                if (!string.IsNullOrEmpty(txtscholarno.Text))
                {
                    lblstdtype.Text = Convert.ToString(Connection.GetExecuteScalar("SELECT DISTINCT Ltrim(Rtrim(tbl_classstudent.stdtype))   FROM tbl_student INNER JOIN tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno  WHERE     (tbl_student.scholarno = '" + txtscholarno.Text + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')    "));
                    DataSet ds = Connection.GetDataSet("SELECT  tbl_student.StudentNo, tbl_student.name, tbl_student.father,tbl_student.phone,tbl_classmaster.ClassCode, tbl_classmaster.classname + ' ' + tbl_section.sectionname + ' ' + tbl_sankay.sankayname AS Classname,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.BusStopNo, '-') Else  '-' End) AS BusStopNo,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopName, '-') Else  '-' End) AS StopName,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopFee, 0) Else 0 End) AS StopFee,tbl_student.IsRTE,tbl_student.IsScholarship FROM tbl_classmaster INNER JOIN  " +
                     "  tbl_classstudent ON tbl_classmaster.classcode = tbl_classstudent.classno INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno LEFT OUTER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo " +
                     "  WHERE     (tbl_student.scholarno = '" + txtscholarno.Text.Trim() + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        frmFeeCollecton.StudentNo = (int)(ds.Tables[0].Rows[0]["StudentNo"]);
                        frmFeeCollecton.ClassCode = (int)ds.Tables[0].Rows[0]["ClassCode"];
                        lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        lblfather.Text = ds.Tables[0].Rows[0]["father"].ToString();
                        lblclass.Text = ds.Tables[0].Rows[0]["Classname"].ToString();
                        lblBusStop.Text = ds.Tables[0].Rows[0]["StopName"].ToString();
                        lblBusFee.Text = ds.Tables[0].Rows[0]["StopFee"].ToString();
                        MobileNoOfStudentParent = ds.Tables[0].Rows[0]["Phone"].ToString();
                        trte = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRTE"]);
                        string tstr = string.Empty;
                        //-For Scholarship amount .
                        if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["IsScholarship"].ToString()))
                            tsch = false;
                        else
                            tsch = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsScholarship"]);
                        if (tsch)
                        {
                            tstr = Convert.ToString(Connection.GetExecuteScalar("select schamount from tbl_classstudent where sessioncode='" + school.CurrentSessionCode + "' and studentno='" + frmFeeCollecton.StudentNo + "'"));
                            if (string.IsNullOrEmpty(tstr))
                            {
                                txtschamt.Text = Convert.ToString(Connection.GetExecuteScalar("select dbo.GetSchAmountByCat('" + school.CurrentSessionCode + "','" + frmFeeCollecton.StudentNo + "')"));
                                if (string.IsNullOrEmpty(txtschamt.Text.Trim()))
                                    txtschamt.Text = "0";
                                txtschamt.Enabled = true;
                            }
                            else
                            {
                                txtschamt.Text = Convert.ToString(Connection.GetExecuteScalar("select dbo.GetSchAmount('" + school.CurrentSessionCode + "','" + frmFeeCollecton.StudentNo + "')"));
                                if (string.IsNullOrEmpty(txtschamt.Text.Trim()))
                                    txtschamt.Text = "0";
                                txtschamt.Enabled = false;

                            }
                        }
                        else
                        {
                            //--write some code here.
                            txtschamt.Text = string.Empty;
                            txtschamt.Enabled = false;
                        }
                        //--end scholar ship amount
                        DataTable dtFeeType = new DataTable();
                        if (lblstdtype.Text.Trim().Equals("Studying Student".Trim()))
                        {
                            if (trte)
                            {
                                dtFeeType = Connection.GetDataTable("SELECT tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads , tbl_classfeeregular.feeamt, tbl_feeheads.feetype  " +
                                "   FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classfeeregular INNER JOIN  " +
                                "   tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode ON tbl_classstudent.classno = tbl_classfeeregular.classno AND  " +
                                "   tbl_classstudent.sessioncode = tbl_classfeeregular.sessioncode and tbl_classstudent.stream=tbl_classfeeregular.stream  WHERE  (tbl_classfeeregular.sessioncode = '" + school.CurrentSessionCode + "') And " +
                                "   (tbl_student.studentno = '" + frmFeeCollecton.StudentNo + "') AND (tbl_feeheads.feetype = '1') and tbl_classfeeregular.RTE='True' AND (tbl_classstudent.stdtype = '" + lblstdtype.Text.Trim() + "')" +
                                "   GROUP BY tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads, tbl_classfeeregular.feeamt, tbl_feeheads.feetype");
                            }
                            else
                            {
                                dtFeeType = Connection.GetDataTable("SELECT tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads , tbl_classfeeregular.feeamt, tbl_feeheads.feetype  " +
                                "   FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classfeeregular INNER JOIN  " +
                                "   tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode ON tbl_classstudent.classno = tbl_classfeeregular.classno AND  " +
                                "   tbl_classstudent.sessioncode = tbl_classfeeregular.sessioncode and tbl_classstudent.stream=tbl_classfeeregular.stream  WHERE  (tbl_classfeeregular.sessioncode = '" + school.CurrentSessionCode + "') And " +
                                "   (tbl_student.studentno = '" + frmFeeCollecton.StudentNo + "') AND (tbl_feeheads.feetype = '1') AND (tbl_classstudent.stdtype = '" + lblstdtype.Text.Trim() + "')" +
                                "   GROUP BY tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads, tbl_classfeeregular.feeamt, tbl_feeheads.feetype");
                            }
                        }
                        else if (lblstdtype.Text.Trim().Equals("New Student".Trim()))
                        {
                            if (trte)
                            {
                                dtFeeType = Connection.GetDataTable("SELECT tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads , tbl_classfeeregular.feeamt, tbl_feeheads.feetype  " +
                                  "   FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classfeeregular INNER JOIN  " +
                                  "   tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode ON tbl_classstudent.classno = tbl_classfeeregular.classno AND  " +
                                  "   tbl_classstudent.sessioncode = tbl_classfeeregular.sessioncode and tbl_classstudent.stream=tbl_classfeeregular.stream  WHERE (tbl_classfeeregular.sessioncode = '" + school.CurrentSessionCode + "') And" +
                                  "   (tbl_student.studentno = '" + frmFeeCollecton.StudentNo + "') and tbl_classfeeregular.RTE='True' AND (tbl_classstudent.stdtype = '" + lblstdtype.Text.Trim() + "') " +
                                  "   GROUP BY tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads, tbl_classfeeregular.feeamt, tbl_feeheads.feetype");
                            }
                            else
                            {
                                dtFeeType = Connection.GetDataTable("SELECT tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads , tbl_classfeeregular.feeamt, tbl_feeheads.feetype  " +
                               "   FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classfeeregular INNER JOIN  " +
                               "   tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode ON tbl_classstudent.classno = tbl_classfeeregular.classno AND  " +
                               "   tbl_classstudent.sessioncode = tbl_classfeeregular.sessioncode and tbl_classstudent.stream=tbl_classfeeregular.stream  WHERE (tbl_classfeeregular.sessioncode = '" + school.CurrentSessionCode + "') And" +
                               "   (tbl_student.studentno = '" + frmFeeCollecton.StudentNo + "')  AND (tbl_classstudent.stdtype = '" + lblstdtype.Text.Trim() + "') " +
                               "   GROUP BY tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads, tbl_classfeeregular.feeamt, tbl_feeheads.feetype");
                            }
                        }
                        else
                        {
                            MessageBox.Show("You are not eligible for submitted Fee...\n\tPlease Check Student Type From Student Master Form!!!");
                        }
                        dtgfee.Rows.Clear();
                        if (dtFeeType.Rows.Count > 0)
                        {
                            txtTotalFeeAmount.Text = "0";
                            if (Convert.ToDecimal(lblBusFee.Text) > 0)
                            {
                                dtgfee.Rows.Add("101", "Bus Fee", lblBusFee.Text);
                                txtTotalFeeAmount.Text = lblBusFee.Text;
                            }
                            foreach (DataRow dr in dtFeeType.Rows)
                            {
                                dtgfee.Rows.Add(dr["feecode"], dr["feeheads"], dr["feeamt"]);
                                txtTotalFeeAmount.Text = (decimal.Parse(txtTotalFeeAmount.Text) + decimal.Parse(dr["feeamt"].ToString())).ToString();
                            }
                        }
                        else 
                        {
                            txtTotalFeeAmount.Text = "0";
                            if (Convert.ToDecimal(lblBusFee.Text) > 0)
                            {
                                dtgfee.Rows.Add("101", "Bus Fee", lblBusFee.Text);
                                txtTotalFeeAmount.Text = lblBusFee.Text;
                            }
                        }

                        //*************************

                        DataTable dt = Connection.GetDataTable("SELECT rcptno AS [Rcpt. No.], CONVERT(varchar, rcptdate, 106) AS Date " +
                     " , dueamount AS [Due Amt.], totfeeamt AS [Rcv. Amt.], latefee AS [Late Fee],consession AS [Fee Consession] FROM tbl_feemaster " +
                     "   WHERE     (sessioncode = '" + school.CurrentSessionCode + "') AND (studentno = '" + frmFeeCollecton.StudentNo + "')");
                        if (dt.Rows.Count > 0)
                            dgvPaymentDetail.DataSource = dt;

                        SqlDataReader datareader = Connection.GetDataReader("SELECT sessioncode, studentno, ISNULL(SUM(rcvdamt), 0) AS RcvAmt " +
                            " , ISNULL(SUM(totfeeamt), 0) AS TotFeeAmt FROM tbl_feemaster WHERE sessioncode='" + school.CurrentSessionCode + "'  " +
                            " And studentno='" + frmFeeCollecton.StudentNo + "' GROUP BY sessioncode, studentno");

                        if (datareader != null)
                        {
                            if (datareader.HasRows)
                            {
                                datareader.Read();
                                if (tsch)
                                {
                                    txtPaidAmont.Text = (decimal.Parse(datareader["RcvAmt"].ToString()) + decimal.Parse(txtschamt.Text)).ToString();
                                }
                                else
                                {
                                    txtPaidAmont.Text = (datareader["RcvAmt"]).ToString();
                                }

                                if (txtPaidAmont.Text.Equals(txtTotalFeeAmount.Text))
                                {
                                    MessageBox.Show("Fee Already Paid...", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    txtscholarno.SelectAll();
                                }
                                else
                                {
                                    txtPaidAmont.Text = (datareader["RcvAmt"]).ToString();
                                }
                            }
                        }

                        txtFeeRcptNo.Text = Convert.ToString(Connection.GetExecuteScalar("select IsNull((Max(rcptno)+1),101) from tbl_feemaster where sessioncode=" + school.CurrentSessionCode));
                        this.TotalPaid();
                    }
                    else
                    {
                        MessageBox.Show("Scholar No. Is Not Valide", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
        private void dtgfee_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dtgfee, e);
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        private void txtConsession_TextChanged(object sender, EventArgs e)
        {
            this.NetPayment();
        }

        void NetPayment()
        {
            try
            {
                txtrecivedamt.Text = (decimal.Round(decimal.Parse(txtFeeAmount.Text) +
                    decimal.Parse(txtLateFee.Text) -
                     decimal.Parse(txtConsession.Text), 2)).ToString();
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        void TotalPaid()
        {
            try
            {
                if (tsch)
                {
                    txtdueamt.Text = (decimal.Parse(txtTotalFeeAmount.Text) -
                                        (decimal.Parse(txtPaidAmont.Text) + decimal.Parse(txtschamt.Text))).ToString();
                }
                else
                {
                    txtdueamt.Text = (decimal.Parse(txtTotalFeeAmount.Text) -
                    decimal.Parse(txtPaidAmont.Text)).ToString();
                }

            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtFeeAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(decimal.Parse(txtdueamt.Text) >= (decimal.Parse(txtFeeAmount.Text))))
                {
                    MessageBox.Show("Please Enter Fee Amount Carefully.", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtFeeAmount.Text = "0";
                    txtFeeAmount.SelectAll();
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
            this.NetPayment();
        }

        private void txtLateFee_TextChanged(object sender, EventArgs e)
        {
            this.NetPayment();
        }

        private void txtTotalFeeAmount_TextChanged(object sender, EventArgs e)
        {
            this.TotalPaid();
        }

        private void txtPaidAmont_TextChanged(object sender, EventArgs e)
        {
            this.TotalPaid();
        }

        private void txtdueamt_TextChanged(object sender, EventArgs e)
        {
            this.TotalPaid();
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            AFlag = 0;
            SqlTransaction trn = null;
            string Itdate = string.Empty,TDate=string.Empty;
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
                    TDate = Convert.ToString(Connection.GetExecuteScalar("select max(rcptdate) from tbl_feemaster where studentno='" + frmFeeCollecton.StudentNo + "'"));
                    //if (cdt.ToString("dd/MM/yyyy").Equals(ddt.ToString("dd/MM/yyyy")))
                    //{
                   
                    Itdate = Convert.ToString(Connection.GetExecuteScalar("select s_from from tbl_session where sessioncode=(select min(sessioncode) from tbl_feemaster where studentno='" + frmFeeCollecton.StudentNo + "')"));
                    if (Itdate == string.Empty)
                    {
                        Itdate = Convert.ToString(Connection.GetExecuteScalar("select s_from from tbl_session where sessioncode='" + school.CurrentSessionCode + "'"));
                    }
                        if (txtFeeRcptNo.Enabled == false)
                        {
                            trn = Connection.GetMyConnection().BeginTransaction();
                            c.getconnstr();
                            Connection.SqlTransection("insert into tbl_feemaster(sessioncode, rcptno, studentno, rcptdate, rcvdamt, totalpaidfee, dueamount, latefee, totfeeamt, monthname,consession) " +
                             " values ('" + school.CurrentSessionCode + "','" + txtFeeRcptNo.Text + "','" + frmFeeCollecton.StudentNo + "','" + dtpfeedate.Value.Date + "' ,'" + txtFeeAmount.Text + "'," +
                             " '" + txtrecivedamt.Text + "','" + (decimal.Parse(txtdueamt.Text) - (decimal.Parse(txtFeeAmount.Text))) + "','" + txtLateFee.Text + "'," +
                             " '" + txtrecivedamt.Text + "','" + MonthName + "' ,'" + txtConsession.Text + "')",
                             Connection.MyConnection, trn);
                            if (tsch)
                            {
                                Connection.SqlTransection("update  tbl_classstudent set schamount='" + txtschamt.Text.Trim() + "' " +
                                " where sessioncode='" + school.CurrentSessionCode + "' and studentno='" + frmFeeCollecton.StudentNo + "'",
                                Connection.MyConnection, trn);
                            }
                            int CCEID = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_account where accode='" + frmFeeCollecton.StudentNo + "' and actype=dbo.GetAccountCode('F')"));
                            if (CCEID < 1)
                            {
                                
                                Connection.SqlTransection("insert into dbo.tbl_account(accode, acname, actype, acopbal, acoptype, apanno, accaddress, budgtype, opdate, subledger,lf,issaldeduct) " +
                                " values ('" + frmFeeCollecton.StudentNo + "',dbo.GetSName('" + frmFeeCollecton.StudentNo
                                + "'),dbo.GetAccountCode('F'),0,'Cr','none','none',0,'" + Itdate + "',0,'1',0)",
                                Connection.MyConnection, trn);
                            }

                            ////------------------ this is previous session receipt entry----------
                            trn.Commit();
                            DataSet ds = new DataSet();
                            ds = Connection.GetDataSet("select distinct sessioncode from dbo.Tbl_Received where studentno='" + frmFeeCollecton.StudentNo + "'");
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    int icnt = 0;
                                    icnt = Convert.ToInt32(Connection.GetId("select count(*) total from tbl_voucherdet where accode='" + frmFeeCollecton.StudentNo + "' and sessioncode='" + ds.Tables[0].Rows[i]["sessioncode"].ToString() + "'"));
                                    if (icnt < 1)
                                    {
                                        AFlag = 1;
                                        DataSet ids = new DataSet();
                                        ids = Connection.GetDataSet("select sessioncode,RecId as rcptno,studentno,date as rcptdate,dbo.GetRecAmount(RecId,sessioncode,studentno) as rcvdamt,consession,latefee from Tbl_Received where studentno='" + frmFeeCollecton.StudentNo + "' and sessioncode='" + ds.Tables[0].Rows[i]["sessioncode"].ToString() + "' order by rcptno");
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
                                                    ids.Tables[0].Rows[j]["sessioncode"].ToString() + "','JV','" + ids.Tables[0].Rows[j]["rcptno"].ToString() + "','" + frmFeeCollecton.StudentNo + "','" +
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
                            ////--------------------------------------------- end previous year transaction----------------------
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
                                    ((decimal.Parse(txtLateFee.Text) + decimal.Parse(txtFeeAmount.Text)) - decimal.Parse(txtConsession.Text)) + "','" +
                                    dtpfeedate.Value.Date + "','Dr','S')",
                                Connection.MyConnection, trn);

                                //insert Voucher Detail Cr
                                Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                                    school.CurrentSessionCode + "','JV','" + txtFeeRcptNo.Text + "','" + frmFeeCollecton.StudentNo + "','" +
                                    ((decimal.Parse(txtLateFee.Text) + decimal.Parse(txtFeeAmount.Text)) - decimal.Parse(txtConsession.Text)) + "','" +
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
                                            "\nReceived Amount: " + txtFeeAmount.Text +
                                            "\nDue Amount: " + (decimal.Parse(txtdueamt.Text) - (decimal.Parse(txtFeeAmount.Text))) +
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
                                MessageBox.Show("Record saved successfully.\n\tMessage Sent!!!", "School");
                            else
                                MessageBox.Show("Record saved successfully.");
                        }
                        else
                        {
                            trn = Connection.GetMyConnection().BeginTransaction();
                            c.getconnstr();
                            Connection.SqlTransection("Update tbl_feemaster SET rcptdate ='" + dtpfeedate.Value.Date + "' , rcvdamt='" + txtFeeAmount.Text + "', totalpaidfee='" + txtrecivedamt.Text + "', dueamount='" + (decimal.Parse(txtdueamt.Text) - (decimal.Parse(txtFeeAmount.Text))) + "' " +
                            " , latefee='" + txtLateFee.Text + "', totfeeamt='" + txtrecivedamt.Text + "', monthname='" + MonthName + "',consession='" + txtConsession.Text + "' " +
                            " Where SessionCode='" + school.CurrentSessionCode + "' And rcptno='" + txtFeeRcptNo.Text + "' And studentno='" + frmFeeCollecton.StudentNo + "' And Status='True'  ",
                            Connection.MyConnection, trn);

                            //*--delete prvious voucher-------------
                            c.connectsql("delete from tbl_voucherdet where sessioncode=" + school.CurrentSessionCode + " and vchtype='JV' and amttype='Cr' and vchno=" + txtFeeRcptNo.Text, Connection.MyConnection, trn);
                            c.connectsql("delete from tbl_voucherdet where sessioncode=" + school.CurrentSessionCode + " and vchtype='JV' and amttype='Dr' and vchno=" + txtFeeRcptNo.Text, Connection.MyConnection, trn);
                            //*------------------
                            //insert Voucher Detail Cr
                            Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                                school.CurrentSessionCode + "','JV','" + txtFeeRcptNo.Text + "',dbo.GetAccountCode('CS'),'" +
                                ((decimal.Parse(txtLateFee.Text) + decimal.Parse(txtFeeAmount.Text)) - decimal.Parse(txtConsession.Text)) + "','" +
                                dtpfeedate.Value.Date + "','Dr','S')",
                            Connection.MyConnection, trn);
                            //insert Voucher Detail Dr
                            Connection.SqlTransection("insert into tbl_voucherdet (sessioncode,vchtype,vchno,accode,vchamt,vchdate,amttype,type) values ('" +
                                school.CurrentSessionCode + "','JV','" + txtFeeRcptNo.Text + "','" + frmFeeCollecton.StudentNo + "','" +
                                ((decimal.Parse(txtLateFee.Text) + decimal.Parse(txtFeeAmount.Text)) - decimal.Parse(txtConsession.Text)) + "','" +
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
                                            "\nReceived Amount: " + txtFeeAmount.Text +
                                            "\nDue Amount: " + (decimal.Parse(txtdueamt.Text) - (decimal.Parse(txtFeeAmount.Text))) +
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

        public override void btnprint_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("SELECT tbl_student.studentno, tbl_student.scholarno, tbl_student.name, tbl_student.dob, tbl_classmaster.classname + ' ' + tbl_section.sectionname AS Class " +
                " , tbl_session.sessionname, tbl_tehsil.tehsil, tbl_district.district, tbl_district.statename, tbl_student.P_address, tbl_student.C_address, tbl_student.father,tbl_student.mother " +
                " , tbl_student.casttype, tbl_student.bloodgroup, tbl_student.marr_status AS gender, tbl_student.phone, (CASE WHEN tbl_student.busfacility = 1 THEN tbl_StopDetails.StopName ELSE ISNULL(tbl_student.P_address,tbl_tehsil.tehsil) END) AS StopName " +
                " , tbl_StopDetails.StopFee, tbl_feemaster.rcptno " +
                " , tbl_feemaster.rcptdate, tbl_feemaster.rcvdamt, tbl_feemaster.totalpaidfee, tbl_feemaster.dueamount, tbl_feemaster.latefee, tbl_feemaster.totfeeamt, tbl_feemaster.monthname " +
                " , tbl_feemaster.consession FROM tbl_section INNER JOIN tbl_session INNER JOIN tbl_feemaster ON tbl_session.sessioncode = tbl_feemaster.sessioncode INNER JOIN tbl_student ON  " +
                "   tbl_feemaster.studentno = tbl_student.studentno INNER JOIN tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno AND tbl_session.sessioncode = tbl_classstudent.sessioncode  " +
                "   INNER JOIN tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode ON tbl_section.sectioncode = tbl_classstudent.Section INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode " +
                "   INNER JOIN tbl_district ON tbl_student.distcode = tbl_district.distcode INNER JOIN tbl_tehsil ON tbl_student.tehcode = tbl_tehsil.tehcode AND tbl_district.distcode = tbl_tehsil.distcode LEFT OUTER JOIN  " +
                "   tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo WHERE (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') AND (tbl_feemaster.rcptno = '" + txtFeeRcptNo.Text.Trim() + "'); " +
                "   SELECT schoolname, schooladdress, affiliate_by, logoimage, schoolcity, schoolphone, principal, registrationno FROM tbl_school ");

            try
            {
                bool b = Convert.ToBoolean(Connection.GetExecuteScalar("Select DualSlipType From tbl_FeeHeads"));
                if (b)
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptFeeReceipt.xsd");
                    rptFeeSlip cr = new rptFeeSlip();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    s.crystalReportViewer1.ReportSource = cr;
                    cr.SetParameterValue("Title", "FEE RECEIPT");
                    s.Show();

                }
                else
                {
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptFeeReceiptSingle.xsd");
                    rptFeeSlipSingle cr = new rptFeeSlipSingle();
                    cr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    //cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                    cr.SetDataSource(ds);
                    ShowAllReports s = new ShowAllReports();
                    // System.Drawing.Printing.PaperSize pr = new System.Drawing.Printing.PaperSize("Atul", 4, 6);
                    //Size sz = new Size(4, 6);
                    s.crystalReportViewer1.ReportSource = cr;
                    cr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelopePersonal;
                    s.Show();
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        public override void frm_keydown(object sender, KeyEventArgs e)
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
                gbxStudentDetail.Visible = false;

            base.frm_keydown(sender, e);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
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

        private void dgvPaymentDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dgvPaymentDetail, e);
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

        private void txtFeeRcptNo_Validated(object sender, EventArgs e)
        {
            if (txtFeeRcptNo.Enabled && !string.IsNullOrEmpty(txtFeeRcptNo.Text.Trim()))
            {
                DataTable sdr = Connection.GetDataTable("Declare @i int Declare @d datetime set @i=(SELECT COUNT(*) FROM tbl_FeeMaster " +
                " WHERE rcptno = '" + txtFeeRcptNo.Text.Trim() + "' AND sessioncode = '" + school.CurrentSessionCode + "' AND rcptdate < " +
                " (Select Max(rcptdate) FROM tbl_FeeMaster WHERE Status = 'true' AND sessioncode = '" + school.CurrentSessionCode + "' AND studentno =" +
                " (SELECT studentno FROM tbl_FeeMaster WHERE Status = 'true' AND sessioncode ='" + school.CurrentSessionCode + "' AND rcptno = '" + txtFeeRcptNo.Text.Trim() + "'))) " +
                " set @d=(Select Max(rcptdate)FROM tbl_FeeMaster WHERE Status = 'true' AND sessioncode = '" + school.CurrentSessionCode + "' AND studentno = " +
                " (SELECT studentno FROM tbl_FeeMaster WHERE Status = 'true' AND sessioncode = '" + school.CurrentSessionCode + "' AND rcptno ='" + txtFeeRcptNo.Text.Trim() + "')) " +
                " Select @i,Convert(Varchar,@d,106) ");
                if (sdr.Rows.Count > 0)
                {
                    if (Convert.ToInt32(sdr.Rows[0][0]) == 0)
                    {
                        frmFeeCollecton.StudentNo = Convert.ToInt32(Connection.GetExecuteScalar("SELECT ISNULL(studentno,-1000) FROM tbl_FeeMaster WHERE (rcptno = '" + txtFeeRcptNo.Text.Trim() + "') AND (sessioncode = '" + school.CurrentSessionCode + "')"));
                        DataTable dtStudent = Connection.GetDataTable("SELECT  tbl_student.StudentNo,tbl_student.ScholarNo, tbl_student.name, tbl_student.father,tbl_classmaster.ClassCode, tbl_classmaster.classname + ' ' + tbl_section.sectionname + ' ' + tbl_sankay.sankayname AS Classname, ISNULL(tbl_StopDetails.BusStopNo, '-') AS BusStopNo, ISNULL(tbl_StopDetails.StopName, '-') AS StopName, (Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopFee, 0) Else 0 End) AS StopFee, LTRIM(RTRIM(tbl_classstudent.stdtype)) AS Status,tbl_student.IsRTE,tbl_student.IsScholarship FROM tbl_classmaster INNER JOIN  " +
                         "  tbl_classstudent ON tbl_classmaster.classcode = tbl_classstudent.classno INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno LEFT OUTER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo " +
                         "  WHERE (tbl_student.StudentNo = '" + frmFeeCollecton.StudentNo + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')");
                        if (dtStudent.Rows.Count > 0)
                        {
                            frmFeeCollecton.StudentNo = (int)(dtStudent.Rows[0]["StudentNo"]);
                            frmFeeCollecton.ClassCode = (int)dtStudent.Rows[0]["ClassCode"];
                            lblname.Text = dtStudent.Rows[0]["name"].ToString();
                            lblfather.Text = dtStudent.Rows[0]["father"].ToString();
                            lblclass.Text = dtStudent.Rows[0]["Classname"].ToString();
                            lblBusStop.Text = dtStudent.Rows[0]["StopName"].ToString();
                            lblBusFee.Text = dtStudent.Rows[0]["StopFee"].ToString();
                            lblstdtype.Text = dtStudent.Rows[0]["Status"].ToString();
                            txtscholarno.Text = dtStudent.Rows[0]["ScholarNo"].ToString();
                            trte = Convert.ToBoolean(dtStudent.Rows[0]["IsRTE"]);
                            string tstr = string.Empty;
                            //-For Scholarship amount .
                            tsch = Convert.ToBoolean(dtStudent.Rows[0]["IsScholarship"]);
                            if (tsch)
                            {
                                tstr = Convert.ToString(Connection.GetExecuteScalar("select schamount from tbl_classstudent where sessioncode='" + school.CurrentSessionCode + "' and studentno='" + frmFeeCollecton.StudentNo + "'"));
                                if (string.IsNullOrEmpty(tstr))
                                {
                                    txtschamt.Text = Convert.ToString(Connection.GetExecuteScalar("select dbo.GetSchAmountByCat('" + school.CurrentSessionCode + "','" + frmFeeCollecton.StudentNo + "')"));
                                    if (string.IsNullOrEmpty(txtschamt.Text.Trim()))
                                        txtschamt.Text = "0";
                                    txtschamt.Enabled = true;
                                }
                                else
                                {
                                    txtschamt.Text = Convert.ToString(Connection.GetExecuteScalar("select dbo.GetSchAmount('" + school.CurrentSessionCode + "','" + frmFeeCollecton.StudentNo + "')"));
                                    if (string.IsNullOrEmpty(txtschamt.Text.Trim()))
                                        txtschamt.Text = "0";
                                    txtschamt.Enabled = false;

                                }
                            }
                            else
                            {
                                //--write some code here.
                                txtschamt.Text = string.Empty;
                                txtschamt.Enabled = false;
                            }
                            DataTable dtFeeType = new DataTable();
                            if (lblstdtype.Text.Trim().Equals("Studying Student".Trim()))
                            {
                                if (trte)
                                {

                                    dtFeeType = Connection.GetDataTable("SELECT tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads , tbl_classfeeregular.feeamt, tbl_feeheads.feetype  " +
                                    "   FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classfeeregular INNER JOIN  " +
                                    "   tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode ON tbl_classstudent.classno = tbl_classfeeregular.classno AND  " +
                                    "   tbl_classstudent.sessioncode = tbl_classfeeregular.sessioncode and tbl_classstudent.stream=tbl_classfeeregular.stream  WHERE  (tbl_classfeeregular.sessioncode = '" + school.CurrentSessionCode + "') And " +
                                    "   (tbl_student.studentno = '" + frmFeeCollecton.StudentNo + "') AND (tbl_feeheads.feetype = '1') and tbl_classfeeregular.RTE='True' AND (tbl_classstudent.stdtype = '" + lblstdtype.Text.Trim() + "')" +
                                    "   GROUP BY tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads, tbl_classfeeregular.feeamt, tbl_feeheads.feetype");
                                }
                                else
                                {

                                    dtFeeType = Connection.GetDataTable("SELECT tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads , tbl_classfeeregular.feeamt, tbl_feeheads.feetype  " +
                                    "   FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classfeeregular INNER JOIN  " +
                                    "   tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode ON tbl_classstudent.classno = tbl_classfeeregular.classno AND  " +
                                    "   tbl_classstudent.sessioncode = tbl_classfeeregular.sessioncode and tbl_classstudent.stream=tbl_classfeeregular.stream  WHERE  (tbl_classfeeregular.sessioncode = '" + school.CurrentSessionCode + "') And " +
                                    "   (tbl_student.studentno = '" + frmFeeCollecton.StudentNo + "') AND (tbl_feeheads.feetype = '1') AND (tbl_classstudent.stdtype = '" + lblstdtype.Text.Trim() + "')" +
                                    "   GROUP BY tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads, tbl_classfeeregular.feeamt, tbl_feeheads.feetype");
                                }
                            }
                            else if (lblstdtype.Text.Trim().Equals("New Student".Trim()))
                            {
                                if (trte)
                                {
                                    dtFeeType = Connection.GetDataTable("SELECT tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads , tbl_classfeeregular.feeamt, tbl_feeheads.feetype  " +
                                   "   FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classfeeregular INNER JOIN  " +
                                   "   tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode ON tbl_classstudent.classno = tbl_classfeeregular.classno AND  " +
                                   "   tbl_classstudent.sessioncode = tbl_classfeeregular.sessioncode and tbl_classstudent.stream=tbl_classfeeregular.stream  WHERE (tbl_classfeeregular.sessioncode = '" + school.CurrentSessionCode + "') And" +
                                   "   (tbl_student.studentno = '" + frmFeeCollecton.StudentNo + "') and tbl_classfeeregular.RTE='True' AND (tbl_classstudent.stdtype = '" + lblstdtype.Text.Trim() + "') " +
                                   "   GROUP BY tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads, tbl_classfeeregular.feeamt, tbl_feeheads.feetype");
                                }
                                else
                                {
                                    dtFeeType = Connection.GetDataTable("SELECT tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads , tbl_classfeeregular.feeamt, tbl_feeheads.feetype  " +
                                   "   FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classfeeregular INNER JOIN  " +
                                   "   tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode ON tbl_classstudent.classno = tbl_classfeeregular.classno AND  " +
                                   "   tbl_classstudent.sessioncode = tbl_classfeeregular.sessioncode and tbl_classstudent.stream=tbl_classfeeregular.stream  WHERE (tbl_classfeeregular.sessioncode = '" + school.CurrentSessionCode + "') And" +
                                   "   (tbl_student.studentno = '" + frmFeeCollecton.StudentNo + "')  AND (tbl_classstudent.stdtype = '" + lblstdtype.Text.Trim() + "') " +
                                   "   GROUP BY tbl_student.studentno, tbl_feeheads.feecode, tbl_feeheads.feeheads, tbl_classfeeregular.feeamt, tbl_feeheads.feetype");
                                }
                            }
                            else
                            {
                                MessageBox.Show("You are not eligible for submitted Fee.\n\tPlease Check Student Type From Student Master Form!!!");
                            }
                            dtgfee.Rows.Clear();
                            if (dtFeeType.Rows.Count > 0)
                            {
                                txtTotalFeeAmount.Text = "0";
                                if (Convert.ToDecimal(lblBusFee.Text) > 0)
                                {
                                    dtgfee.Rows.Add("101", "Bus Fee", lblBusFee.Text);
                                    txtTotalFeeAmount.Text = lblBusFee.Text;
                                }
                                foreach (DataRow dr in dtFeeType.Rows)
                                {
                                    dtgfee.Rows.Add(dr["feecode"], dr["feeheads"], dr["feeamt"]);
                                    txtTotalFeeAmount.Text = (decimal.Parse(txtTotalFeeAmount.Text) + decimal.Parse(dr["feeamt"].ToString())).ToString();
                                }
                            }
                            else
                            {
                                txtTotalFeeAmount.Text = "0";
                                if (Convert.ToDecimal(lblBusFee.Text) > 0)
                                {
                                    dtgfee.Rows.Add("101", "Bus Fee", lblBusFee.Text);
                                    txtTotalFeeAmount.Text = lblBusFee.Text;
                                }
                            }
                            DataTable dt = Connection.GetDataTable("SELECT rcptno AS [Rcpt. No.], CONVERT(varchar, rcptdate, 106) AS Date " +
                            " , dueamount AS [Due Amt.], totfeeamt AS [Rcv. Amt.], latefee AS [Late Fee],consession AS [Fee Consession] FROM tbl_feemaster " +
                            "   WHERE  rcptno<>'" + txtFeeRcptNo.Text.Trim() + "' AND  (sessioncode = '" + school.CurrentSessionCode + "') AND (studentno = '" + frmFeeCollecton.StudentNo + "')");
                            if (dt.Rows.Count > 0)
                                dgvPaymentDetail.DataSource = dt;

                            ////In LIS 13-Apr-2014
                            //SqlDataReader datareader = Connection.GetDataReader("SELECT sessioncode, studentno, ISNULL(SUM(rcvdamt), 0) AS RcvAmt " +
                            //    " , ISNULL(SUM(totfeeamt), 0) AS TotFeeAmt FROM tbl_feemaster WHERE   rcptno<>'" + txtFeeRcptNo.Text.Trim() + "' AND " +
                            //    "   sessioncode='" + school.CurrentSessionCode + "' And studentno='" + frmFeeCollecton.StudentNo + "' GROUP BY sessioncode, studentno");


                            SqlDataReader datareader = Connection.GetDataReader("SELECT sessioncode, studentno, ISNULL(SUM(rcvdamt), 0) AS RcvAmt " +
                                " , ISNULL(SUM(totfeeamt), 0) AS TotFeeAmt FROM tbl_feemaster WHERE   rcptno='" + txtFeeRcptNo.Text.Trim() + "' AND " +
                                "   sessioncode='" + school.CurrentSessionCode + "' And studentno='" + frmFeeCollecton.StudentNo + "' GROUP BY sessioncode, studentno");
                            //created abcd
                            SqlDataReader datareader1 = Connection.GetDataReader("SELECT sessioncode, studentno, ISNULL(SUM(rcvdamt), 0) AS RcvAmt " +
                            " , ISNULL(SUM(totfeeamt), 0) AS TotFeeAmt FROM tbl_feemaster WHERE sessioncode='" + school.CurrentSessionCode + "'  " +
                            " And studentno='" + frmFeeCollecton.StudentNo + "' GROUP BY sessioncode, studentno");
                            string Totpad = string.Empty;
                            if (datareader1 != null)
                            {
                                datareader1.Read();
                                Totpad = (datareader1["RcvAmt"]).ToString();
                            }
                            //end abcd
                            if (datareader != null)
                            {
                                datareader.Read();
                                txtPaidAmont.Text = Convert.ToString(Convert.ToDecimal(Totpad)- Convert.ToDecimal(datareader["RcvAmt"]));
                                if (txtPaidAmont.Text.Equals(txtTotalFeeAmount.Text))
                                {
                                    MessageBox.Show("Fee already paid...", "Fee Paid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            DataTable dtFee = Connection.GetDataTable("SELECT rcptno, studentno, rcptdate, rcvdamt, totalpaidfee, dueamount, latefee " +
                                " , totfeeamt, consession FROM tbl_FeeMaster WHERE (rcptno = '" + txtFeeRcptNo.Text.Trim() + "') AND (sessioncode = '" + school.CurrentSessionCode + "')");
                            if (dtFee.Rows.Count > 0)
                            {

                                if (tsch)
                                    txtdueamt.Text = (Convert.ToDecimal(dtFee.Rows[0]["dueamount"]) - Convert.ToDecimal(txtschamt.Text.Trim())).ToString();
                                else
                                    txtdueamt.Text = dtFee.Rows[0]["dueamount"].ToString();
                                //txtdueamt.Text = (Convert.ToString(Convert.ToDecimal(dtFee.Rows[0]["dueamount"])));
                                txtLateFee.Text = dtFee.Rows[0]["latefee"].ToString();
                                txtConsession.Text = dtFee.Rows[0]["consession"].ToString();
                                txtFeeAmount.Text = dtFee.Rows[0]["rcvdamt"].ToString();
                                dtpfeedate.Value = (DateTime)dtFee.Rows[0]["rcptdate"];
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

        private void dtpfeedate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals((object)Keys.Enter) || e.KeyCode.Equals((object)Keys.Tab))
            {
                txtFeeAmount.SelectAll();
                txtFeeAmount.Focus();
            }
        }

        private void txtFeeAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals((object)Keys.Enter) || e.KeyCode.Equals((object)Keys.Tab))
            {
                txtLateFee.SelectAll();
                txtLateFee.Focus();
            }
        }

        private void txtLateFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals((object)Keys.Enter) || e.KeyCode.Equals((object)Keys.Tab))
            {
                txtConsession.SelectAll();
                txtConsession.Focus();
            }
        }

        private void txtConsession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals((object)Keys.Enter) || e.KeyCode.Equals((object)Keys.Tab))
            {
                
            }
        }

        private void dtpfeedate_Leave(object sender, EventArgs e)
        {
            txtFeeAmount.SelectAll();
            txtFeeAmount.Focus();
        }

        private void txtFeeAmount_Leave(object sender, EventArgs e)
        {
            txtLateFee.SelectAll();
            txtLateFee.Focus();
        }

        private void txtLateFee_Leave(object sender, EventArgs e)
        {
            txtConsession.SelectAll();
            txtConsession.Focus();
        }

        private void txtConsession_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnsave_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnprint_Leave(object sender, EventArgs e)
        {
            
        }

        private void txtFeeRcptNo_Leave(object sender, EventArgs e)
        {
            dtpfeedate.Focus();
        }

        private void txtFeeRcptNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                dtpfeedate.Focus();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gbxStudentDetail.Visible = false;
                txtscholarno.Text = dataGridView1.Rows[e.RowIndex].Cells["Scholar No"].Value as string;
                txtscholarno.Focus();
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gbxStudentDetail.Visible = false;
                txtscholarno.Text = dataGridView1.Rows[e.RowIndex].Cells["Scholar No"].Value as string;
                txtscholarno.Focus();
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void frmFeeCollecton_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
              

     }
}

