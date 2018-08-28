using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace SMS
{
    public partial class frmFeeByMonthDetail :UserControlBase
    {
        DataSet ds = new DataSet();
        school1 c = new school1();
        static string tmps = string.Empty;
        public frmFeeByMonthDetail(string s)
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
            Connection.SetUserControlTheme(this);
            tmps = s;
        }


        public override void btnprint_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount  > 0)
            {
                ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\rptFeeByMonthCollection.xsd");
                rptmonthfeecombination fr1 = new rptmonthfeecombination();
                fr1.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                fr1.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                fr1.SetDataSource(ds);
                ShowAllReports s1 = new ShowAllReports();
                s1.crystalReportViewer1.ReportSource = fr1;
                fr1 .SetParameterValue ("Session","Session: "+cmbSession.Text);
                if(chkClass.Checked)
                    fr1.SetParameterValue("ReportTitle", "Fee Collection For Class- " + cmbclassname.Text);
                else 
                     fr1 .SetParameterValue ("ReportTitle","Fee Collection");
                s1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////this.Close();
        }
        public void GetDetailsBySessionS()
        {
            ds = Connection.GetDataSet("select [scholarno] as 'Scholar No.',[name] as 'Name' ,[father] as 'Fathers Name' , [January] " +
                " ,[February],[March],[April],[May],[June],[July],[August],[September],[October],[November],[December] from  " +
                " (Select s.scholarno ,s.name ,s.father,DateName(month , DateAdd( month ,MONTH(f.rcptdate),0) - 1 ) as m  " +
                " ,ISNULL(f.totfeeamt,0) as Amt From tbl_Student s,tbl_FeeMaster f Where s.studentno =f.studentno And f.sessioncode='" + cmbSession.SelectedValue + "') as t " +
                " pivot ( sum(Amt) for m in( [January],[February],[March],[April],[May],[June],[July],[August],[September],[October],[November] " +
                " ,[December]) ) as pvt;" +
                "  SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage From   tbl_school");
            dataGridView1.DataSource = null;
            if (ds.Tables[0].Rows.Count > 0)
                dataGridView1.DataSource = ds.Tables[0];
        }
        public void GetDetailsBySessionH()
        {
            ds = Connection.GetDataSet("select [scholarno] as 'Scholar No.',[name] as 'Name' ,[father] as 'Fathers Name' , [January]  ,[February],[March],[April],[May],[June],[July],[August],[September],[October],[November],[December] from   (Select s.scholarno ,s.name ,s.father,DateName(month , DateAdd( month ,MONTH(f.date),0) - 1 ) as m   ,((dbo.GetRecAmount(f.RecId,f.sessioncode,s.studentno)+f.latefee)-f.consession) as Amt From tbl_Student s,Tbl_Received f Where s.studentno =f.studentno And f.sessioncode='" + cmbSession.SelectedValue + "') as t " +
                " pivot ( sum(Amt) for m in( [January],[February],[March],[April],[May],[June],[July],[August],[September],[October],[November] " +
                " ,[December]) ) as pvt;" +
                "  SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage From   tbl_school");
            dataGridView1.DataSource = null;
            if (ds.Tables[0].Rows.Count > 0)
                dataGridView1.DataSource = ds.Tables[0];
        }
        private void cmbSession_Leave(object sender, EventArgs e)
        {
            if (tmps.Equals("S"))
                GetDetailsBySessionS();
            else
                GetDetailsBySessionH();
        }

        private void frmFeeByMonthDetail_Load(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbSession, " select sessioncode,sessionname from tbl_session order by sessioncode ");
            Connection.FillComboBox(cmbclassname, " select classcode,classname from tbl_classmaster order by classcode ");
            cmbSession.SelectedValue = school.CurrentSessionCode;

            c.GetMdiParent(this).TogglePrintButton(true);
        } 

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }

        private void cmbSession_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void cmbclassname_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }
        public void GetDetailsByClassS()
        {
            if (cmbclassname.Enabled)
            {
                ds = Connection.GetDataSet("select [scholarno] as 'Scholar No.',[name] as 'Name' ,[father] as 'Fathers Name' , [January] " +
                    " ,[February],[March],[April],[May],[June],[July],[August], [September],[October],[November],[December] from  " +
                    " ( Select s.scholarno ,s.name ,s.father,DateName(month , DateAdd( month ,MONTH(f.rcptdate),0) - 1 ) as m   " +
                    " ,ISNULL(f.totfeeamt,0) as Amt From tbl_Student s ,tbl_FeeMaster f,tbl_classstudent cs  Where " +
                    " s.studentno =f.studentno And f.sessioncode='" + cmbSession.SelectedValue + "' And s.studentno =cs.studentno And cs.classno ='" + cmbclassname.SelectedValue + "') " +
                    " as t  pivot ( sum(Amt) for m in([January],[February],[March],[April],[May],[June],[July],[August] " +
                    " ,[September],[October],[November]  ,[December]) ) as pvt;" +
                    "  SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage From   tbl_school");
                dataGridView1.DataSource = null;
                if (ds.Tables[0].Rows.Count > 0)
                    dataGridView1.DataSource = ds.Tables[0];
            }
        }
        public void GetDetailsByClassH()
        {
            if (cmbclassname.Enabled)
            {
                ds = Connection.GetDataSet("select [scholarno] as 'Scholar No.',[name] as 'Name' ,[father] as 'Fathers Name' , [January]  ,[February],[March],[April],[May],[June],[July],[August], [September],[October],[November],[December] from   ( Select s.scholarno ,s.name ,s.father,DateName(month , DateAdd( month ,MONTH(f.date),0) - 1 ) as m    ,((dbo.GetRecAmount(f.RecId,f.sessioncode,s.studentno)+f.latefee)-f.consession) as Amt From tbl_Student s ,Tbl_Received f,tbl_classstudent cs   Where " +
                    " s.studentno =f.studentno And f.sessioncode='" + cmbSession.SelectedValue + "' And s.studentno =cs.studentno and cs.sessioncode=f.sessioncode And cs.classno ='" + cmbclassname.SelectedValue + "') " +
                    " as t  pivot ( sum(Amt) for m in([January],[February],[March],[April],[May],[June],[July],[August] " +
                    " ,[September],[October],[November]  ,[December]) ) as pvt;" +
                    "  SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno, logoimage From   tbl_school");
                dataGridView1.DataSource = null; 
                if (ds.Tables[0].Rows.Count > 0)
                    dataGridView1.DataSource = ds.Tables[0];
            }
        }
        private void cmbclassname_Leave(object sender, EventArgs e)
        {
            if (tmps.Equals("S"))
                GetDetailsByClassS();
            else
                GetDetailsByClassH();
        }

        private void chkClass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClass.Checked)
            {
                cmbclassname.Enabled = true;
            }
            else
            {
                cmbclassname.Enabled = false;
            }
        }

        private void chkClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void frmFeeByMonthDetail_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
         
 
    }
}
