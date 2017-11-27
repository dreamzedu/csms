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
    public partial class Subjectwiseclass :UserControlBase
    {
        school1 c = new school1();
        Boolean add_edit = false;
        int i = 0;
        string classno;
        string board;
     
        public Subjectwiseclass()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);//   DesignForm.fromDesign1(this);
        }

        private void Subjectwiseclass_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label45.Visible = false;
            valcmbclass.Visible = false;
            comboBox1.Visible = false;
            comboBox2.Visible = false;
            dtgbook.Visible = false;
            Connection.FillCombo(ref comboBox2, "SELECT DISTINCT subjecttype FROM tbl_subject ");
          //  valsankay.Visible = false;


            c.getconnstr();
            board = Connection.boardofstudey();
            if (board == "BOTH")
            {
                groupBox1.Visible = true;

            }
            else             
            {
                valcmbclass.Visible = true;
                label45.Visible = true;
            }
            Connection .FillCombo (ref valcmbclass ,"select distinct classname from tbl_classmaster ");
         
            //Connection .FillCombo (ref comboBox1,"select sankayname from tbl_sankay ");
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void valcmbclass_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox2.Visible = true;
            label2.Visible = true;
            dtgbook.Visible = true;
            DataSet ds = Connection.GetDataSet("Select classcode from tbl_classmaster where classname='" + valcmbclass.Text + "'");
            classno = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            int classcode;
            if (Convert.ToInt32(classno) > 110 && Convert.ToInt32(classno) < 113)
            {
                comboBox1.Visible = true;
                label1.Visible = true;
                comboBox1.DataSource = null;
                Connection.FillCombo(ref comboBox1, " select sankayname from tbl_sankay  WHERE     (sankayname != 'Common') order by sankayname");
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Visible = false;
                label1.Visible = false;
                comboBox1.DataSource = null;
                Connection.FillCombo(ref comboBox1, " SELECT     sankayname   FROM         tbl_sankay  WHERE     (sankayname = 'Common')  order by sankayname");
                comboBox1.SelectedIndex = 0;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            valcmbclass.Visible = true;
            label45.Visible = true;

            board = "MP BOARD";
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
            valcmbclass.Visible = true;
            label45.Visible = true;
            board = "CBSC BOARD";
        }

        private void valcmbclass_SelectedValueChanged(object sender, EventArgs e)
        {
            int classcode;
            if (Convert.ToInt32(valcmbclass.SelectedValue) >= 110)
            {
                comboBox1.Visible = true;
                label1.Visible = true ;
              //  valsankay.Visible = true;
                label1 .Visible =true ;
            }
            else
            {
               comboBox1.Visible = false;
                label1.Visible = false;
               // valsankay.Visible =false ;
                label1.Visible = false ;

            }
        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            c.getconnstr();
            dtgbook.Rows.Clear();
            c.returnconn(c.myconn);
            string mysql = "";

            mysql = "select subjectno,SubjectCode,subjectname,subjectno from tbl_subject where subjecttype ='" + comboBox2.Text + "'";

            SqlCommand com;
            com = new SqlCommand(mysql, c.myconn);
            SqlDataReader reader;
            reader = com.ExecuteReader();
            i = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    dtgbook.Rows.Add();
                    dtgbook.Rows[i].Cells[0].Value = reader["subjectno"];
                    dtgbook.Rows[i].Cells[1].Value = reader["SubjectCode"];
                    dtgbook.Rows[i].Cells[2].Value = reader["subjectname"];
                    DataSet ds = Connection.GetDataSet("select subjectno,convert(nvarchar(10), EDate,103) as EDate from tbl_subwiseclass where classno='" + classno + "' and subjectno= '" + dtgbook.Rows[i].Cells[0].Value.ToString() + "' and subjecttype='" + comboBox2.Text + "' and  sankayname= '" + comboBox1.Text + "' ");


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dtgbook.Rows[i].Cells[3].Value = true;
                        if (String.IsNullOrEmpty(ds.Tables[0].Rows[0]["EDate"].ToString()))
                        {
                            dtgbook.Rows[i].Cells[4].Value = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                        else
                            dtgbook.Rows[i].Cells[4].Value = ds.Tables[0].Rows[0]["EDate"].ToString();
                    }
                    else
                    {
                        dtgbook.Rows[i].Cells[3].Value = false;
                        dtgbook.Rows[i].Cells[4].Value = DateTime.Now.ToString("dd/MM/yyyy");
                    }


                    i++;
                }
                reader.Close();
                dtgbook.AllowUserToAddRows = false   ;
            }
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {

            DataSet ds = Connection.GetDataSet("SELECT tbl_subwiseclass.board, tbl_subwiseclass.subjecttype, tbl_subject.subjectname, tbl_subwiseclass.sankayname, tbl_school.schoolname, tbl_school.schooladdress, tbl_school.logoimage,tbl_school.affiliate_by, tbl_classmaster.classname    FROM         tbl_subject INNER JOIN                         tbl_subwiseclass ON tbl_subject.subjectno = tbl_subwiseclass.subjectno INNER JOIN                          tbl_school ON tbl_subwiseclass.board = tbl_school.affiliate_by INNER JOIN                          tbl_classmaster ON tbl_subwiseclass.classno = tbl_classmaster.classcode    WHERE     (tbl_subwiseclass.classno = '" + classno + "') order by tbl_subwiseclass.subjecttype ");
          
            if (ds != null)
            {
               // ds.WriteXmlSchema(@"D:\Barcodes\a\classwisesubject.xsd");
                classwisesubject fr = new classwisesubject();
                fr.SetDataSource(ds);
                ShowAllReports s = new ShowAllReports();
                s.crystalReportViewer1.ReportSource = fr;
                s.Show();
            }
        }

      

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dtgbook.Rows.Clear();
                c.returnconn(c.myconn);
                string mysql = "";

                mysql = "select subjectno,SubjectCode,subjectname,subjectno from tbl_subject where subjecttype ='" + comboBox2.Text + "'";

                SqlCommand com;
                com = new SqlCommand(mysql, c.myconn);
                SqlDataReader reader;
                reader = com.ExecuteReader();
                i = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dtgbook.Rows.Add();
                        dtgbook.Rows[i].Cells[0].Value = reader["subjectno"];
                        dtgbook.Rows[i].Cells[1].Value = reader["SubjectCode"];
                        dtgbook.Rows[i].Cells[2].Value = reader["subjectname"];
                        DataSet ds = Connection.GetDataSet("select subjectno,convert(nvarchar(10), EDate,103) as EDate from tbl_subwiseclass where classno='" + classno + "' and subjectno= '" + dtgbook.Rows[i].Cells[0].Value.ToString() + "' and subjecttype='" + comboBox2.Text + "' and  sankayname= '" + comboBox1.Text + "' ");


                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dtgbook.Rows[i].Cells[3].Value = true;
                            
                            if (String.IsNullOrEmpty(ds.Tables[0].Rows[0]["EDate"].ToString()))
                            {
                                dtgbook.Rows[i].Cells[4].Value = DateTime.Now.ToString("dd/MM/yyyy");
                            }
                            else
                                dtgbook.Rows[i].Cells[4].Value = ds.Tables[0].Rows[0]["EDate"].ToString();
                        }
                        else
                        {
                            dtgbook.Rows[i].Cells[3].Value = false;
                            dtgbook.Rows[i].Cells[4].Value = DateTime.Now.ToString("dd/MM/yyyy");
                        }

                        i++;
                    }
                    reader.Close();
                    dtgbook.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }

      

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (valcmbclass.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");

            }
            else
            {
                Connection.AllPerform("delete from tbl_subwiseclass where classno='" + classno + "' and  subjecttype='" + comboBox2.Text + "' and  sankayname='" + comboBox1.Text + "'");
                SqlTransaction trn;
                trn = c.myconn.BeginTransaction();
                string mysql;
                int i = 0;
                do
                {

                    if (Convert.ToBoolean(dtgbook.Rows[i].Cells[3].Value) == true)
                    {

                        Connection.AllPerform("insert into tbl_subwiseclass  (board,classno,subjecttype,sankayname,subjectno,EDate) values ('" + board + "','" + classno + "','" + comboBox2.Text + "','" + comboBox1.Text + "','" + dtgbook.Rows[i].Cells[0].Value + "','" + Connection.GetDateMMddyyyy((dtgbook.Rows[i].Cells[4].Value).ToString()) + "')");
                    }



                    i++;

                }
                while (i <= dtgbook.Rows.Count - 1);
                trn.Commit();
                MessageBox.Show("Saved..");
            }
                
          
        }
        DateTimePicker oDateTimePicker;
        private void dtgbook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                c.GetMdiParent(this).ToggleSaveButton(true);
                c.GetMdiParent(this).TogglePrintButton(true);
                string tdts = string.Empty;
                tdts = dtgbook.Rows[e.RowIndex].Cells[4].Value.ToString();
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dtgbook.Controls.Add(oDateTimePicker);

                // Setting the format (i.e. 2014-10-10)  
                //oDateTimePicker.Format = DateTimePickerFormat.Short;
                oDateTimePicker.Format = DateTimePickerFormat.Custom;
                oDateTimePicker.CustomFormat = "dd/MM/yyyy";
                oDateTimePicker.Value =Convert.ToDateTime(Connection.GetDateMMddyyyy(tdts));
                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dtgbook.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                oDateTimePicker.Visible = true;
            }  
        }
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dtgbook.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }

        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        private void Subjectwiseclass_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);

        }

        private void dgvApps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgbook.CurrentCell.GetType() == typeof(DataGridViewCheckBoxCell))
            {
                if (dtgbook.CurrentCell.IsInEditMode)
                {
                    if (dtgbook.IsCurrentCellDirty)
                    {
                        c.GetMdiParent(this).ToggleSaveButton(true);
                        c.GetMdiParent(this).TogglePrintButton(true);
                    }
                }
            }
        }
 
    }
}
