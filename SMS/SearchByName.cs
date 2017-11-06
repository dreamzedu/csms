using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class SearchByName : Form
    {
        school c = new school();
        string classname,studno,name;
        public SearchByName()
        {
            InitializeComponent();
            //DesignForm.fromDesign(this);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                c.getconnstr();
                DataSet ds = Connection.GetDataSet("SELECT  tbl_student.studentno, tbl_student.scholarno,   tbl_student.scholarno as [Scholar No.], tbl_student.name as [Name], tbl_student.father as [Fathers Name], tbl_classmaster.classname as Class, tbl_section.sectionname as Section FROM         tbl_classstudent INNER JOIN    tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN    tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode where tbl_classstudent.sessioncode='" + school.CurrentSessionCode.ToString() + "' and tbl_student.name like '" + textBox1.Text + '%' + "' ");
                GVStudentDetails.DataSource = ds.Tables[0];
                GVStudentDetails.Columns[0].Visible = false;
                GVStudentDetails.Columns[1].Visible = false;
            }
            catch (Exception ex)
            {
            }
        }
        private void GVStudentDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Connection.Flag == "S")
                {
                    Connection.StudentBcode = GVStudentDetails.CurrentRow.Cells["scholarno"].Value.ToString();
                }
                else 
                {
                    Connection.StudentBcode = GVStudentDetails.CurrentRow.Cells["studentno"].Value.ToString();
                }
                this.Close();
            }
            catch { }
        }

        private void Pct_Close_Click(object sender, EventArgs e)
        {
            Connection.StudentBcode = "0"; this.Close();
        }

        private void SearchByName_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
         
    }
}
