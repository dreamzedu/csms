using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SMS.Report.Fees.ReportDesign;

namespace SMS.Report.Fees.ReportForm
{
    public partial class frmDueFee :UserControlBase
    {
        DataTable dtTotalFee = new DataTable();
        DataTable dtPaidFee = new DataTable();
        DataTable dtAllFeeType = new DataTable();
        school c = new school();
        static string stutype = string.Empty,busfee=string.Empty,tstudentno=string.Empty;
        public frmDueFee()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
            //Connection.ChangeStyleOfForm(this);
        }

        private void frmDueFee_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void frmDueFee_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbSession, " select sessioncode,sessionname from tbl_session order by sessioncode ");
            Connection.FillComboBox(cmbClass, " select classcode,classname from tbl_classmaster order by classcode ");
            cmbSession.SelectedValue = school.CurrentSessionCode;
            cmbStudentStatus.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSection, " SELECT tbl_section.sectioncode, tbl_section.sectionname FROM " +
                 " tbl_classstudent INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode " +
                 " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') And  (tbl_classstudent.sessioncode = " +
                 " '" + cmbSession.SelectedValue + "') GROUP BY tbl_section.sectioncode, tbl_section.sectionname " +
                 " Order by tbl_section.sectioncode");
            }
            catch { }
        }
        static bool tsch = false, trte = false; static decimal schamt = 0; 
        public void GetDataStudent(int Studentno)
        {
                if (!string.IsNullOrEmpty(Studentno.ToString()))
                {
                    tstudentno = Studentno.ToString();
                    stutype = Convert.ToString(Connection.GetExecuteScalar("SELECT DISTINCT Ltrim(Rtrim(tbl_classstudent.stdtype))   FROM tbl_student INNER JOIN tbl_classstudent ON tbl_student.studentno = tbl_classstudent.studentno  WHERE     (tbl_student.studentno = '" + Studentno + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')    "));
                    DataSet ds = Connection.GetDataSet("SELECT  tbl_student.StudentNo,tbl_student.scholarno, tbl_student.name, tbl_student.father,tbl_student.phone,tbl_classmaster.ClassCode, tbl_classmaster.classname + ' ' + tbl_section.sectionname + ' ' + tbl_sankay.sankayname AS Classname,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.BusStopNo, '-') Else  '-' End) AS BusStopNo,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopName, '-') Else  '-' End) AS StopName,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopFee, 0) Else 0 End) AS StopFee,tbl_student.busfacility,tbl_student.IsRTE FROM tbl_classmaster INNER JOIN  " +
                     "  tbl_classstudent ON tbl_classmaster.classcode = tbl_classstudent.classno INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno LEFT OUTER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo " +
                     "  WHERE     (tbl_student.StudentNo = '" + Studentno + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblStudentName.Text = ds.Tables[0].Rows[0]["name"].ToString();
                        lblStudentSch.Text = ds.Tables[0].Rows[0]["scholarno"].ToString();
                        trte = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRTE"]);
                        dtPaidFee = Connection.GetDataTable("SELECT SUM(fr.consession) AS [ConsesFee],SUM(fr.latefee) AS [LateFee] FROM Tbl_Received fr    where fr.date<='" + Convert.ToDateTime(dtpDate.Value).ToString("MM/dd/yyyy") + "' and fr.studentno='" + Studentno + "'   ");
                        if (dtPaidFee.Rows.Count > 0)
                        {
                            lblStudentcfee.Text = dtPaidFee.Rows[0]["ConsesFee"].ToString();
                            lblStudentlfee.Text = dtPaidFee.Rows[0]["LateFee"].ToString();
                        }
                        else
                        {
                            lblStudentcfee.Text = "0";
                            lblStudentlfee.Text = "0";
                        }

                        dtPaidFee.Dispose();
                        DataTable dtFeeType = new DataTable();
                        dgvSStudent.DataSource = null;
                        if (stutype.Trim().Equals("Studying Student".Trim()))
                        {
                            //dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,convert(nvarchar(10), cfr.Date,103) as Date, cast(cfr.feeamt as numeric(18,2)) as Amount,cast(dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as numeric(18,2))as RAmount,cast((cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as numeric(18,2)) as BAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode  WHERE  (cfr.sessioncode = '" + school.CurrentSessionCode + "') And " +
                            //"   (st.studentno = '" + Studentno + "') AND (fh.feetype = '1') AND (cs.stdtype = '" + stutype + "')" +
                            //"   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode,cfr.Date");
                            if (trte)
                            {
                                dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as BAmount,0 as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode and cs.Stream=cfr.Stream   WHERE  (cfr.sessioncode = '" + school.CurrentSessionCode + "') And " +
                               "   (st.scholarno = '" + ds.Tables[0].Rows[0]["scholarno"].ToString() + "') AND (fh.feetype = '1') and cfr.RTE='True' AND (cs.stdtype = '" + stutype.Trim() + "')" +
                               "   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                                if (dtFeeType.Rows.Count > 0)
                                {
                                    if (Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) > 0)
                                    {
                                        decimal trcamt = 0;
                                        trcamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetRecAmountByHead(101,'" + school.CurrentSessionCode + "','" + ds.Tables[0].Rows[0]["StudentNo"].ToString() + "')"));
                                        dtFeeType.Rows.Add("101", "Bus Fee", ds.Tables[0].Rows[0]["StopFee"].ToString(), trcamt, Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) - trcamt);
                                    }
                                }
                            }
                            else
                            {
                                dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as BAmount,0 as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode and cs.Stream=cfr.Stream   WHERE  (cfr.sessioncode = '" + school.CurrentSessionCode + "') And " +
                                "   (st.scholarno = '" + ds.Tables[0].Rows[0]["scholarno"].ToString() + "') AND (fh.feetype = '1') AND (cs.stdtype = '" + stutype.Trim() + "')" +
                                "   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                                if (dtFeeType.Rows.Count > 0)
                                {
                                    if (Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) > 0)
                                    {
                                        decimal trcamt = 0;
                                        trcamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetRecAmountByHead(101,'" + school.CurrentSessionCode + "','" + ds.Tables[0].Rows[0]["StudentNo"].ToString() + "')"));
                                        dtFeeType.Rows.Add("101", "Bus Fee", ds.Tables[0].Rows[0]["StopFee"].ToString(), trcamt, Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) - trcamt);
                                    }
                                }
                            }
                        }
                        else if (stutype.Trim().Equals("New Student".Trim()))
                        {
                           // dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,convert(nvarchar(10), cfr.Date,103) as Date,  cast(cfr.feeamt as numeric(18,2)) as Amount,cast(dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as numeric(18,2))as RAmount,cast((cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as numeric(18,2)) as BAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode WHERE (cfr.sessioncode = '" + school.CurrentSessionCode + "') And" +
                           //"   (st.studentno = '" + Studentno + "')  AND (cs.stdtype = '" + stutype + "') " +
                           //"   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode,cfr.Date");
                            if (trte)
                            {
                                dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as BAmount,0 as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode and cs.Stream=cfr.Stream  WHERE (cfr.sessioncode = '" + school.CurrentSessionCode + "') And" +
                               "   (st.scholarno = '" + ds.Tables[0].Rows[0]["scholarno"].ToString() + "') and cfr.RTE='True'  AND (cs.stdtype = '" + stutype.Trim() + "') " +
                               "   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                                if (dtFeeType.Rows.Count > 0)
                                {
                                    if (Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) > 0)
                                    {
                                        decimal trcamt = 0;
                                        trcamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetRecAmountByHead(101,'" + school.CurrentSessionCode + "','" + ds.Tables[0].Rows[0]["StudentNo"].ToString() + "')"));
                                        dtFeeType.Rows.Add("101", "Bus Fee", ds.Tables[0].Rows[0]["StopFee"].ToString(), trcamt, Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) - trcamt);
                                    }
                                }
                            }
                            else
                            {
                                dtFeeType = Connection.GetDataTable("SELECT fh.feecode as FeeCode, fh.feeheads as FeeHead,  cfr.feeamt as Amount,dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno) as RAmount, (cfr.feeamt -dbo.GetRecAmountByHead(fh.feecode,cfr.sessioncode,st.studentno)) as BAmount,0 as PAmount    FROM tbl_classstudent cs INNER JOIN tbl_student st ON cs.studentno = st.studentno INNER JOIN tbl_classfeeregular cfr INNER JOIN     tbl_feeheads fh ON cfr.feecode = fh.feecode ON cs.classno = cfr.classno AND     cs.sessioncode = cfr.sessioncode and cs.Stream=cfr.Stream  WHERE (cfr.sessioncode = '" + school.CurrentSessionCode + "') And" +
                               "   (st.scholarno = '" + ds.Tables[0].Rows[0]["scholarno"].ToString() + "')  AND (cs.stdtype = '" + stutype.Trim() + "') " +
                               "   GROUP BY st.studentno, fh.feecode, fh.feeheads, cfr.feeamt,cfr.sessioncode");
                                if (dtFeeType.Rows.Count > 0)
                                {
                                    if (Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) > 0)
                                    {
                                        decimal trcamt = 0;
                                        trcamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetRecAmountByHead(101,'" + school.CurrentSessionCode + "','" + ds.Tables[0].Rows[0]["StudentNo"].ToString() + "')"));
                                        dtFeeType.Rows.Add("101", "Bus Fee", ds.Tables[0].Rows[0]["StopFee"].ToString(), trcamt, Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) - trcamt);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("You are not Elegible for submitted Fee...\n\tPlease Check Student Type From Student Master Form!!!");
                        }
                        if (dtFeeType.Rows.Count > 0)
                        {
                            dgvSStudent.DataSource = dtFeeType;
                        }
                        else
                        {
                            if (Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) > 0)
                            {
                                decimal trcamt = 0;
                                trcamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetRecAmountByHead(101,'" + school.CurrentSessionCode + "','" + ds.Tables[0].Rows[0]["StudentNo"].ToString() + "')"));
                                dtFeeType.Rows.Add("101", "Bus Fee", ds.Tables[0].Rows[0]["StopFee"].ToString(), trcamt, Convert.ToDecimal(ds.Tables[0].Rows[0]["StopFee"].ToString()) - trcamt);
                                dgvSStudent.DataSource = dtFeeType;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Student No Is Not Valid", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
               
            }
        }
        public void GetDataStudentDetails()
        {
            try
            {
                dtTotalFee = Connection.GetDataTable(" SELECT 'More Details..' as Details,tbl_student.IsScholarship, tbl_classstudent.sessioncode as 'SessionCode', tbl_student.studentno AS 'Student No.', tbl_student.scholarno AS 'Scholar No.', tbl_student.name AS 'Name', tbl_student.father AS 'Fathers Name' " +
                 " ,tbl_classmaster.classname + '-' + tbl_section.sectionname AS Class,tbl_student.phone,tbl_student.IsRTE, LTRIM(RTRIM(tbl_classstudent.stdtype)) AS 'Status', 0.00 AS [Fee Amount],(Case When tbl_student.busfacility=1 Then ISNULL(tbl_StopDetails.StopFee, 0) Else 0 End) AS [Bus Fee] " +
                 " , 0.00 AS 'Total Fee', 0.00 AS 'Paid Fee', 0.00 AS 'Late Fee', 0.00 AS 'Consession Fee', 0.00 AS 'Due Fee', tbl_classstudent.classno AS ClassNo, tbl_classstudent.Section AS SectionNo,tbl_classstudent.stream FROM tbl_classstudent INNER JOIN tbl_student ON " +
                 "  tbl_classstudent.studentno = tbl_student.studentno INNER JOIN tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN tbl_section ON tbl_classstudent.Section = " +
                 "  tbl_section.sectioncode LEFT OUTER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo WHERE (tbl_classstudent.stdtype IN ('Studying Student', 'New Student')) AND tbl_classstudent.SessionCode = '" + cmbSession.SelectedValue + "'" +
                 "  GROUP BY tbl_classstudent.sessioncode, tbl_student.studentno, tbl_student.scholarno, tbl_student.name, tbl_student.father, tbl_classstudent.stdtype, tbl_StopDetails.StopFee,tbl_classstudent.classno " +
                 " , tbl_classstudent.Section, tbl_classmaster.classname, tbl_section.sectionname,tbl_student.phone,tbl_classstudent.stream,tbl_student.busfacility,tbl_student.IsScholarship,tbl_student.IsRTE ORDER BY 'Student No.' ");

                dtPaidFee = Connection.GetDataTable("SELECT fr.sessioncode AS SessionCode,fr.studentno AS [Student No.],SUM(frd.RecAmount) AS [Paid Fee],dbo.GetConsAmount(fr.sessioncode, fr.studentno) AS [Conses Fee],dbo.GetLateAmount(fr.sessioncode, fr.studentno) AS [Late Fee],cs.stream FROM Tbl_Received fr inner join Tbl_ReceivedDetail frd on fr.RecId=frd.RecId and fr.sessioncode=frd.sessioncode inner join tbl_classstudent cs on cs.studentno=fr.studentno and fr.sessioncode=cs.sessioncode where fr.date<='" + Convert.ToDateTime(dtpDate.Value).ToString("MM/dd/yyyy") + "'  GROUP BY fr.sessioncode, fr.studentno,cs.stream ");

                dtAllFeeType = Connection.GetDataTable(" SELECT tbl_classfeeregular.sessioncode AS SessionCode, tbl_classfeeregular.classno AS ClassNo, ISNULL(SUM(tbl_classfeeregular.feeamt), 0) AS [Total Fee],tbl_feeheads.feetype as [FeeType] ,tbl_classfeeregular.stream,tbl_classfeeregular.Date,tbl_classfeeregular.RTE " +
                "  FROM tbl_classfeeregular INNER JOIN tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode WHERE (tbl_classfeeregular.sessioncode = '" + cmbSession.SelectedValue + "') " +
                "  GROUP BY tbl_classfeeregular.sessioncode, tbl_classfeeregular.classno, tbl_classfeeregular.feeamt, tbl_feeheads.feetype,tbl_classfeeregular.stream, tbl_classfeeregular.date,tbl_classfeeregular.RTE ");

                for (int i = 0; i < dtTotalFee.Rows.Count; i++)
                {
                    decimal tdc = 0, tdl = 0, tct = 0;
                    object Objct = 0.0;
                    trte = Convert.ToBoolean(dtTotalFee.Rows[i]["IsRTE"]);

                    object Obj = dtPaidFee.Compute("Sum([Paid Fee])", " SessionCode='" + cmbSession.SelectedValue + "' And  [Student No.]='" + dtTotalFee.Rows[i]["Student No."] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "' ");
                    object Objc = dtPaidFee.Compute("Sum([Conses Fee])", " SessionCode='" + cmbSession.SelectedValue + "' And  [Student No.]='" + dtTotalFee.Rows[i]["Student No."] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                    object Objl = dtPaidFee.Compute("Sum([Late Fee])", " SessionCode='" + cmbSession.SelectedValue + "' And  [Student No.]='" + dtTotalFee.Rows[i]["Student No."] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                    tdc = (Objc != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Objc), 2) : Convert.ToDecimal(0.00);
                    tdl = (Objl != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Objl), 2) : Convert.ToDecimal(0.00);
                    dtTotalFee.Rows[i]["Paid Fee"] = (Obj != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Obj), 2) : Convert.ToDecimal(0.00);
                    // if ( dtTotalFee.Rows[i]["Student No."].ToString().Equals("1109"))
                    string tstr = string.Empty;
                    //-For Scholarship amount .

                    if (string.IsNullOrEmpty(dtTotalFee.Rows[i]["IsScholarship"].ToString()))
                        tsch = false;
                    else
                        tsch = Convert.ToBoolean(dtTotalFee.Rows[i]["IsScholarship"]);
                    if (tsch)
                    {
                        tstr = Convert.ToString(Connection.GetExecuteScalar("select schamount from tbl_classstudent where sessioncode='" + school.CurrentSessionCode + "' and studentno='" + dtTotalFee.Rows[i]["Student No."] + "'"));
                        if (string.IsNullOrEmpty(tstr))
                        {
                            schamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetSchAmountByCat('" + cmbSession.SelectedValue + "','" + dtTotalFee.Rows[i]["Student No."] + "')"));
                        }
                        else
                        {
                            schamt = Convert.ToDecimal(Connection.GetExecuteScalar("select dbo.GetSchAmount('" + cmbSession.SelectedValue + "','" + dtTotalFee.Rows[i]["Student No."] + "')"));

                        }
                    }
                    else
                    {
                        //--write some code here.
                        schamt = 0;
                    }
                    //--end scholar ship amount

                    if (dtTotalFee.Rows[i]["Status"].ToString().Equals("Studying Student"))
                    {
                        if (trte)
                        {
                            Obj = dtAllFeeType.Compute("Sum([Total Fee])", "[FeeType]='1' and RTE='True' And SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                            Objct = dtAllFeeType.Compute("Sum([Total Fee])", "[FeeType]='1' and RTE='True' And SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "' and Date<='" + Convert.ToDateTime(dtpDate.Value).ToString() + "'");
                            tct = (Objct != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Objct), 2) : Convert.ToDecimal(0.00);
                            dtTotalFee.Rows[i]["Fee Amount"] = (Obj != DBNull.Value) ? Obj : Convert.ToDecimal(0.00);
                            dtTotalFee.Rows[i]["Total Fee"] = Math.Round((Convert.ToDecimal(dtTotalFee.Rows[i]["Fee Amount"]) + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])), 2);
                            dtTotalFee.Rows[i]["Due Fee"] = Math.Round((((tct + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])) - schamt) - (Convert.ToDecimal(dtTotalFee.Rows[i]["Paid Fee"]) )), 2);
                            //dtTotalFee.Rows[i]["Due Fee"] = Math.Round(Convert.ToDecimal(dtTotalFee.Rows[i]["Due Fee"])-tdc, 2);
                            dtTotalFee.Rows[i]["Consession Fee"] = Math.Round(tdc, 2);
                            dtTotalFee.Rows[i]["Late Fee"] = Math.Round(tdl, 2);
                        }
                        else
                        {
                            Obj = dtAllFeeType.Compute("Sum([Total Fee])", "[FeeType]='1' And SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                            Objct = dtAllFeeType.Compute("Sum([Total Fee])", "[FeeType]='1' And SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "' and Date<='" + Convert.ToDateTime(dtpDate.Value).ToString() + "'");
                            tct = (Objct != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Objct), 2) : Convert.ToDecimal(0.00);
                            dtTotalFee.Rows[i]["Fee Amount"] = (Obj != DBNull.Value) ? Obj : Convert.ToDecimal(0.00);
                            dtTotalFee.Rows[i]["Total Fee"] = Math.Round((Convert.ToDecimal(dtTotalFee.Rows[i]["Fee Amount"]) + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])), 2);
                            dtTotalFee.Rows[i]["Due Fee"] = Math.Round((((tct + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])) - schamt) - (Convert.ToDecimal(dtTotalFee.Rows[i]["Paid Fee"]) )), 2);
                            //dtTotalFee.Rows[i]["Due Fee"] = Math.Round(Convert.ToDecimal(dtTotalFee.Rows[i]["Due Fee"]) - tdc, 2);
                            dtTotalFee.Rows[i]["Consession Fee"] = Math.Round(tdc, 2);
                            dtTotalFee.Rows[i]["Late Fee"] = Math.Round(tdl, 2);

                        }
                    }
                    else if (dtTotalFee.Rows[i]["Status"].ToString().Equals("New Student"))
                    {
                        if (Convert.ToInt16(dtTotalFee.Rows[i]["Student No."]) == 1565)
                        {
                            //--
                            string s = string.Empty;
                        }
                        if (trte)
                        {
                            Obj = dtAllFeeType.Compute("Sum([Total Fee])", " RTE='True' and SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                            Objct = dtAllFeeType.Compute("Sum([Total Fee])", "RTE='True' and SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "' and Date<='" + Convert.ToDateTime(dtpDate.Value).ToString() + "'");
                            tct = (Objct != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Objct), 2) : Convert.ToDecimal(0.00);
                            dtTotalFee.Rows[i]["Fee Amount"] = (Obj != DBNull.Value) ? Obj : Convert.ToDecimal(0.00);
                            dtTotalFee.Rows[i]["Total Fee"] = Math.Round((Convert.ToDecimal(dtTotalFee.Rows[i]["Fee Amount"]) + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])), 2);
                            dtTotalFee.Rows[i]["Due Fee"] = Math.Round((((tct + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])) - schamt) - (Convert.ToDecimal(dtTotalFee.Rows[i]["Paid Fee"]) )), 2);
                            //dtTotalFee.Rows[i]["Due Fee"] = Math.Round(Convert.ToDecimal(dtTotalFee.Rows[i]["Due Fee"]) - tdc, 2);
                            dtTotalFee.Rows[i]["Consession Fee"] = Math.Round(tdc, 2);
                            dtTotalFee.Rows[i]["Late Fee"] = Math.Round(tdl, 2);
                        }
                        else
                        {
                            Obj = dtAllFeeType.Compute("Sum([Total Fee])", "SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "'");
                            Objct = dtAllFeeType.Compute("Sum([Total Fee])", "SessionCode='" + cmbSession.SelectedValue + "' And ClassNo='" + dtTotalFee.Rows[i]["ClassNo"] + "' And  stream='" + dtTotalFee.Rows[i]["stream"] + "' and Date<='" + Convert.ToDateTime(dtpDate.Value).ToString() + "'");
                            tct = (Objct != DBNull.Value) ? decimal.Round(Convert.ToDecimal(Objct), 2) : Convert.ToDecimal(0.00);
                            dtTotalFee.Rows[i]["Fee Amount"] = (Obj != DBNull.Value) ? Obj : Convert.ToDecimal(0.00);
                            dtTotalFee.Rows[i]["Total Fee"] = Math.Round((Convert.ToDecimal(dtTotalFee.Rows[i]["Fee Amount"]) + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])), 2);
                            dtTotalFee.Rows[i]["Due Fee"] = Math.Round((((tct + Convert.ToDecimal(dtTotalFee.Rows[i]["Bus Fee"])) - schamt) - (Convert.ToDecimal(dtTotalFee.Rows[i]["Paid Fee"]) )), 2);
                            //dtTotalFee.Rows[i]["Due Fee"] = Math.Round(Convert.ToDecimal(dtTotalFee.Rows[i]["Due Fee"]) - tdc, 2);
                            dtTotalFee.Rows[i]["Consession Fee"] = Math.Round(tdc, 2);
                            dtTotalFee.Rows[i]["Late Fee"] = Math.Round(tdl, 2);
                        }

                    }
                }

                dgvMStudent.DataSource = dtTotalFee;
            }
            catch { }
        }

        private void cmbSession_Leave(object sender, EventArgs e)
        {
            GetDataStudentDetails();
        }

        private void chkClassWise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClassWise.Checked)
            {
                cmbClass.Enabled = true;
                cmbClass.Focus();
            }
            else
            {
                cmbClass.Enabled = false;
            }
        }

        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection.Checked)
            {
                cmbSection.Enabled = true;
                cmbSection.Focus();
            }
            else
            {
                cmbSection.Enabled = false;
            }
        }

        private void cmbClass_Leave(object sender, EventArgs e)
        {
            if (chkClassWise.Checked)
            {
                DataView dv = dtTotalFee.DefaultView;
                dv.RowFilter = "ClassNo='" + cmbClass.SelectedValue + "' And SessionCode='" + cmbSession.SelectedValue + "'";
                dv.Sort = "Name";
                dgvMStudent.DataSource = dv;
            } 
        }

        private void cmbSection_Leave(object sender, EventArgs e)
        {
            if (chkClassWise.Checked == chkSection.Checked == true)
            {
                DataView dv = dtTotalFee.DefaultView;
                dv.RowFilter = "ClassNo='" + cmbClass.SelectedValue + "' And SessionCode='" + cmbSession.SelectedValue + "' And SectionNo='" + cmbSection.SelectedValue + "'";
                dv.Sort = "Name";
                dgvMStudent.DataSource = dv;
            }
        }

        private void cmbStudentStatus_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbStudentStatus.SelectedIndex > 0)
                {
                    DataView dv = dtTotalFee.DefaultView;
                    dv.RowFilter = "Status='" + cmbStudentStatus.Text.Trim() + "'";
                    dv.Sort = "Name";
                    dgvMStudent.DataSource = dv;
                }
                else
                {
                    DataView dv = dtTotalFee.DefaultView;
                    dv.Sort = "Name";
                    dgvMStudent.DataSource = dv;
                }
            }
            catch { }
        }

        private void cmbSession_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void chkClassWise_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void cmbClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void chkSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void cmbSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void cmbStudentStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void dgvMStudent_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvMStudent.Columns["SessionCode"].Visible = false;
                dgvMStudent.Columns["Student No."].Visible = false;
                dgvMStudent.Columns["Fee Amount"].Visible = false;
                dgvMStudent.Columns["Bus Fee"].Visible = false;
                dgvMStudent.Columns["SectionNo"].Visible = false;
                dgvMStudent.Columns["ClassNo"].Visible = false;
                dgvMStudent.Columns["stream"].Visible = false;
                dgvMStudent.Columns["IsScholarship"].Visible = false;
                dgvMStudent.Columns["Details"].DefaultCellStyle.ForeColor = Color.White;
                dgvMStudent.Columns["Details"].DefaultCellStyle.BackColor = Color.Blue;
                dgvSStudent.Visible = false;
                dgvMStudent.Visible = true;
            }
            catch { }
        }

        private void dgvMStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].ColumnIndex == 0)
                {
                    dgvSStudent.Visible = true;
                    dgvMStudent.Visible = false;
                    int  row = 0;
                    row = dgvMStudent.CurrentCell.RowIndex;
                    GetDataStudent(Convert.ToInt16(dgvMStudent["Student No.", row].Value));
                   
                }
            }
            catch { }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            GetDataStudentDetails();
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            if (dgvMStudent.Visible == true)
            {
                if (dgvMStudent.RowCount > 0)
                {
                    if (ChkIdDueGreater.Checked)
                    {
                        if (chkClassWise.Checked == true && chkSection.Checked == false)
                        {
                            DataView dv = dtTotalFee.DefaultView;
                            dv.RowFilter = "ClassNo='" + cmbClass.SelectedValue + "' And SessionCode='" + cmbSession.SelectedValue + "' and [Due Fee]>0";
                            dv.Sort = "Name";
                            dgvMStudent.DataSource = dv;
                        }
                        else if (chkClassWise.Checked == true && chkSection.Checked == true)
                        {
                            DataView dv = dtTotalFee.DefaultView;
                            dv.RowFilter = "ClassNo='" + cmbClass.SelectedValue + "' And SessionCode='" + cmbSession.SelectedValue + "' And SectionNo='" + cmbSection.SelectedValue + "' and [Due Fee]>0";
                            dv.Sort = "Name";
                            dgvMStudent.DataSource = dv;
                        }
                        else
                        {
                            DataView dv = dtTotalFee.DefaultView;
                            dv.RowFilter = "[Due Fee]>0";
                            dv.Sort = "Name";
                            dgvMStudent.DataSource = dv;
                        }
                    }
                    DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school");
                    ds.Tables.Add(Connection.GetDataTableFromDataGridView(dgvMStudent));
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\HDueFee.xsd");
                    rptHDueFee fr1 = new rptHDueFee();
                    fr1.SetDataSource(ds);
                    ShowAllReports s1 = new ShowAllReports();
                    s1.crystalReportViewer1.ReportSource = fr1;
                    fr1.SetParameterValue("Session", cmbSession.Text);
                    if (chkClassWise.Checked && !chkClassWise.Checked)
                        fr1.SetParameterValue("ReportTitle", cmbStudentStatus.Text + " Due Fee Detail For Class - " + cmbClass.Text.Trim());
                    else if (chkClassWise.Checked && chkSection.Checked)
                        fr1.SetParameterValue("ReportTitle", cmbStudentStatus.Text + " Due Fee Detail For Class - " + cmbClass.Text.Trim() + " " + cmbSection.Text.Trim());
                    else
                        fr1.SetParameterValue("ReportTitle", cmbStudentStatus.Text + " Due Fee Detail");
                    s1.Show();
                }
            }

            if (dgvSStudent.Visible == true)
            {
                if (dgvSStudent.RowCount > 0)
                {
                    DataSet ds = Connection.GetDataSet(" SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage   From   tbl_school  SELECT  tbl_student.StudentNo,tbl_student.scholarno, tbl_student.name, tbl_student.father,tbl_student.phone,tbl_classmaster.ClassCode, tbl_classmaster.classname + ' ' + tbl_section.sectionname + ' ' + tbl_sankay.sankayname AS Classname,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.BusStopNo, '-') Else  '-' End) AS BusStopNo,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopName, '-') Else  '-' End) AS StopName,(Case When busfacility=1 Then ISNULL(tbl_StopDetails.StopFee, 0) Else 0 End) AS StopFee FROM tbl_classmaster INNER JOIN  " +
                    "  tbl_classstudent ON tbl_classmaster.classcode = tbl_classstudent.classno INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno LEFT OUTER JOIN tbl_StopDetails ON tbl_student.BusStopNo = tbl_StopDetails.BusStopNo " +
                    "  WHERE     (tbl_student.StudentNo = '" + tstudentno + "') AND (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "')");
                    
                    //----

                    dtPaidFee = Connection.GetDataTable("SELECT SUM(fr.consession) AS [ConsesFee],SUM(fr.latefee) AS [LateFee] FROM Tbl_Received fr   where fr.date<='" + Convert.ToDateTime(dtpDate.Value).ToString("MM/dd/yyyy") + "' and fr.studentno='" + tstudentno + "' ");
                    //-------
                    ds.Tables.Add((DataTable)dgvSStudent.DataSource);
                    ds.Tables.Add(dtPaidFee);
                    ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\HSDueFee.xsd");
                    rptHSDueFee fr1 = new rptHSDueFee();
                    fr1.SetDataSource(ds);
                    ShowAllReports s1 = new ShowAllReports();
                    s1.crystalReportViewer1.ReportSource = fr1;
                    fr1.SetParameterValue("Session", cmbSession.Text);
                    fr1.SetParameterValue("ReportTitle", " Due Fee Detail");
                    s1.Show();
                }
            }
            
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            GetDataStudentDetails();
        }

       
        
    }
}
