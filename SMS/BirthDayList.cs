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
    public partial class BirthDayList :UserControlBase
    {
        DataSet ds = new DataSet();
        school1 c = new school1();
        public BirthDayList()
        {
            InitializeComponent();
        }

        private void BirthDayList_Load(object sender, EventArgs e)
        {
            try
            {
                c.getconnstr();
                DateTime dt = DateTime.Now;
                int Mon = dt.Month;
                int Day = dt.Day;
                dataGridView1.Visible = true;
                string str= "";
                str = " SELECT     tbl_student.scholarno, tbl_student.name, tbl_student.father, tbl_classmaster.classname +' - ' + tbl_section.sectionname as classname  FROM         tbl_classstudent INNER JOIN    tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN    tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode where tbl_classstudent.sessioncode='" + school .CurrentSessionCode.ToString() + "' and  Month(dob)='" + Mon + "' and Day(dob)='" + Day + "'  ";
                str =str + " Select schoolname from tbl_school ";
                ds = Connection.GetDataSet(str);
                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            ds.WriteXmlSchema(@"" + Connection.GetAccessPathId() + @"Barcodes\a\BirthList.xsd");
            BirthDayReports fr = new BirthDayReports();
            fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
            fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
            fr.SetDataSource(ds);
            ShowAllReports s = new ShowAllReports();
            s.crystalReportViewer1.ReportSource = fr;
            s.Show();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
