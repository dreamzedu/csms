using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.Hostal
{
    public partial class FrmHostalFee :UserControlBase
    {
        public FrmHostalFee()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        
        DateTimePicker oDateTimePicker;
        school1 c = new school1();
        Boolean add_edit = false;
        string mysql;
        static int stuno = 0;
        private void ShowFeeDetails()
        {
            string mysql = string.Empty;
            DataSet ds = new DataSet();
            mysql = " SELECT    DateName( month , DateAdd( month , a.monthno , 0 ) - 1 ) as monthname,a.monthno, a.bedno,a.yearno,a.rechostelfee as Boarding_Fee,a.MessDays,a.recMessFee  as MessFee, a.feedate, a.feeno ";
            mysql = mysql + " FROM   tbl_hostelfee a where a.studentno=" + stuno;
            ds = Connection.GetDataSet(mysql);

            if (ds.Tables[0].Rows.Count > 0)
            {
                dtgbook.Rows.Clear();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        dtgbook.Rows.Add();

                        dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[0].Value = ds.Tables[0].Rows[i]["monthname"] + "-" + Convert.ToString(ds.Tables[0].Rows[i]["yearno"]);
                        dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[1].Value = ds.Tables[0].Rows[i]["boarding_fee"]==DBNull.Value? 0 : Convert.ToInt16(ds.Tables[0].Rows[i]["boarding_fee"]);
                        dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[2].Value = ds.Tables[0].Rows[i]["messdays"] == DBNull.Value ? 0 : Convert.ToInt16(ds.Tables[0].Rows[i]["messdays"]);
                        dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[3].Value = Convert.ToInt16(ds.Tables[0].Rows[i]["messfee"]);
                        if (ds.Tables[0].Rows[i]["feedate"] != null && ds.Tables[0].Rows[i]["feedate"] != DBNull.Value)
                        {
                            dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[4].Value = Convert.ToDateTime(ds.Tables[0].Rows[i]["feedate"]).ToShortDateString();
                        }
                        if (ds.Tables[0].Rows[i]["feeno"] != null && ds.Tables[0].Rows[i]["feeno"] !=  DBNull.Value)
                        {
                            dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[5].Value = Convert.ToInt32(ds.Tables[0].Rows[i]["feeno"]);
                        }
                        dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[6].Value = ds.Tables[0].Rows[i]["monthno"];
                        dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[7].Value = ds.Tables[0].Rows[i]["yearno"];
                        //dtgbook.Rows[dtgbook.Rows.Count - 1].Cells[4].Value = (ds.Tables[0].Rows[i]["bedno"]).ToString();
                    }
                    catch
                    {
                        //dtgbook.Rows.Clear();
                    }
                }
            }
            
        }
       
        private void FrmHostalFee_Load(object sender, EventArgs e)
        {
            c.getconnstr();
            
            //DesignForm.fromDesign1(this);
        }

       private void dtgbook_CellClick(object sender, DataGridViewCellEventArgs e)
       {
            if (oDateTimePicker != null) { oDateTimePicker.Visible = false; } 

            if (e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                    ShowDatePicker(e.ColumnIndex, e.RowIndex);
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

        private void ShowDatePicker(int colIndex, int rowIndex)
        {

            oDateTimePicker = new DateTimePicker();
            dtgbook.Controls.Add(oDateTimePicker);
            //oDateTimePicker.Text = "";
            oDateTimePicker.Format = DateTimePickerFormat.Short;
            Rectangle oRectangle = dtgbook.GetCellDisplayRectangle(colIndex, rowIndex, true);
            oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
            oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);
            oDateTimePicker.Validated += new EventHandler(dateTimePicker_OnValidated);
            oDateTimePicker.Visible = true;

        }

        private void dateTimePicker_OnValidated(object sender, EventArgs e)
        {
            dtgbook.CurrentCell.Value = oDateTimePicker.Text.ToString();
            oDateTimePicker.Visible = false;
        }


        /*public override void btnnew_Click(object sender, EventArgs e)
        {
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            ATxtScholar.Focus();
            //cmbmonth.SelectedIndex = 0;
            DesignForm.fromDesign2(this);
           
        }*/

        public override void btnsave_Click(object sender, EventArgs e)
        {

            SqlTransaction trn = null;
            try
            {
                if (dtgbook.IsCurrentCellDirty)
                {
                    dtgbook.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }


                mysql = "";

                for (int i = 0; i < dtgbook.Rows.Count; i++)
                {

                    object hostelFee = dtgbook.Rows[i].Cells[1].Value;
                    object messDays = dtgbook.Rows[i].Cells[2].Value;
                    object messFee = dtgbook.Rows[i].Cells[3].Value;
                    object date = dtgbook.Rows[i].Cells[4].Value;
                    object feeNo = dtgbook.Rows[i].Cells[5].Value;
                    object monthNo = dtgbook.Rows[i].Cells[6].Value;
                    object yearNo = dtgbook.Rows[i].Cells[7].Value;

                    if(date == null)
                    {
                        date = DateTime.Now.ToShortDateString();
                    }
                    double outVal;

                    if (hostelFee != null && !Double.TryParse(hostelFee.ToString(), out outVal))
                    {
                        MessageBox.Show("Only numeric value is allowed for hostel fee. Please fix the values.");
                        return;
                    }
                    if (messFee != null && !Double.TryParse(messFee.ToString(), out outVal))
                    {
                        MessageBox.Show("Only numeric value is allowed for mess fee. Please fix the values.");
                        return;
                    }
                    if (messDays != null && !Double.TryParse(messDays.ToString(), out outVal))
                    {
                        MessageBox.Show("Only numeric value is allowed for mess days. Please fix the values.");
                        return;
                    }

                    if (feeNo == null)
                    {
                        if (Convert.ToDouble(hostelFee.ToString()) > 0 || Convert.ToDouble(messFee.ToString()) > 0)
                        {
                            c.returnconn(c.myconn);
                            SqlCommand command = new SqlCommand("select isnull(max(feeno),0) as maxfee from tbl_hostelfee", c.myconn);
                            command.CommandTimeout = 120;
                            Int32 mfeeno;

                            object val = command.ExecuteScalar();

                            mfeeno = val == null ? 1001 : Convert.ToInt32(val) + 1;

                            mysql += "update tbl_hostelfee set rechostelfee=" + hostelFee + ",recmessfee=" + messFee + ",messdays=" + messDays + ", feeno=" + mfeeno + ",feedate= '" + date + "' where studentno='" + lblstudentno.Text + "' and sessioncode=" + school.CurrentSessionCode + " and monthno=" + monthNo + " and yearno=" + yearNo + ";";
                        }
                    }
                    else
                    {
                        mysql += "update tbl_hostelfee set rechostelfee=" + hostelFee + ",recmessfee=" + messFee + ",messdays=" + messDays + ", feedate= '" + date + "' where feeno='" + feeNo + "';" ;
                    }                    
                }
                if (!string.IsNullOrEmpty(mysql))
                {
                    c.returnconn(c.myconn);
                    trn = c.myconn.BeginTransaction();
                    c.connectsql(mysql, c.myconn, trn);
                    trn.Commit();
                    MessageBox.Show("Fee saved successfully.");
                    ShowFeeDetails();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Some error occurred while saving the fees.");
                Logger.LogError(ex);
                if (trn != null)
                    trn.Rollback();
            }

        }

        /*public void btnsave_Click(object sender, EventArgs e)
        {
            if (ATxtScholar.Text == "" || txthostelfee.Text == "" || txtmessdays.Text == "" || txtyear.Text == "" || txtmessfee.Text == "")
            {
                MessageBox.Show("Null Value Not Allowed");

            }

            else
            {
                SqlTransaction trn;


                if (add_edit == true)
                {
                    c.returnconn(c.myconn);
                    SqlCommand command = new SqlCommand("select isnull(max(feeno),0) as maxfee from tbl_hostelfee", c.myconn);
                    command.CommandTimeout = 120;
                    Int32 mfeeno;
                    mfeeno = 1001;
                    if (command.ExecuteScalar() != System.DBNull.Value)
                    {
                        mfeeno = Convert.ToInt32(command.ExecuteScalar()) + 1;
                    }
                    textBox1.Text = mfeeno.ToString();
                    c.returnconn(c.myconn);
                    trn = c.myconn.BeginTransaction();

                    try
                    {

                        if (txtmessdays.Text == "")
                        {
                            txtmessdays.Text = "0";
                        }

                        if (txtmessfee.Text == "")
                        {
                            txtmessfee.Text = "0";
                        }
                        mysql = "update tbl_hostelfee set rechostelfee=" + txthostelfee.Text + ",recmessfee=" + txtmessfee.Text + ",messdays=" + txtmessdays.Text + ", feeno=" + textBox1.Text + ",feedate= '" + dtpfee.Value.ToString("MM/dd/yyyy") + "' where studentno='" + lblstudentno.Text + "' and sessioncode=" + school.CurrentSessionCode + " and monthno=" + (cmbmonth.SelectedIndex + 1) + " and yearno=" + txtyear.Text;
                        c.connectsql(mysql, c.myconn, trn);
                        trn.Commit();
                        MessageBox.Show("Fee Saved..");

                        ShowFeeDetails();
                        DesignForm.fromDesign1(this);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex); MessageBox.Show(ex.Message);
                        trn.Rollback();
                    }

                }
                if (add_edit == false)
                {
                    c.returnconn(c.myconn);
                    trn = c.myconn.BeginTransaction();

                    try
                    {
                        DataSet ds = Connection.GetDataSet("select feeno from tbl_hostelfee where monthno='" + (cmbmonth.SelectedIndex + 1) + "'");
                        int feeno = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        ATxtScholar.Text = feeno.ToString();
                        string mysql1;
                        mysql1 = "update tbl_hostelfee set rechostelfee=" + txthostelfee.Text + ",recmessfee=" + txtmessfee.Text + ",messdays=" + txtmessdays.Text + ", feeno=" + textBox1.Text + ",feedate= '" + dtpfee.Value.ToString("MM/dd/yyyy") + "' where feeno='" + feeno + "'";
                        c.connectsql(mysql1, c.myconn, trn);
                        trn.Commit();
                        MessageBox.Show("Fee Saved..");
                        ShowFeeDetails();
                        DesignForm.fromDesign1(this);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex); MessageBox.Show(ex.Message);
                        trn.Rollback();
                    }
                }


                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
            }

        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
        }

        private void txtmessfee_TextChanged(object sender, EventArgs e)
        {
            bool b = ControlValidation.txtNumericStringIsValid(txtmessfee);
        }

        private void cmbmonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        public override void btnprint_Click(object sender, EventArgs e)
        {
            string mysql = " select '" + ATxtScholar.Text + "' as scholarno,'" + lblname.Text + "' as name,'" + lblfathername.Text + "' as father,'" + lblclass.Text + "' as class,'" + lblbedno.Text + "' as bedno,'" + textBox1.Text + "' as feeno,'" + dtpfee.Text + "' as feedate,'" + cmbmonth.Text + "' as month,'" + txtyear.Text + "' as year,'" + txtmessdays.Text + "' as messfee,'" + txtmessfee.Text + "' as boardingfee,'" + txtmessdays.Text + "' as messdays  from tbl_hostelfee  where  feeno=" + textBox1.Text + "  and sessioncode=" + school.CurrentSessionCode + " and  studentno=" + lblstudentno.Text;
            DataSet ds = new DataSet();
            ds.Clear();
            ds = Connection.GetDataSet(mysql);
            //      ds.WriteXml(@"D:\Barcodes\a\hostelfee.xsd");
            //ds.WriteXmlSchema(@"D:\Barcodes\a\BookReports.xsd");
            //hostfee cr = new hostfee();
            //cr.SetDataSource(ds);
            //
            //ShowAllReports s = new ShowAllReports();
            //s.crystalReportViewer1.ReportSource = cr;
            //s.Show();
        }

        private void txthostelfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Numeric Value");
            }
        }

        private void txtyear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Numeric Value");
            }
            
        }

        private void txtmessdays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Numeric Value");
            }
            
        }

        private void txthostelfee_TextChanged(object sender, EventArgs e)
        {
            bool b = ControlValidation.txtNumericStringIsValid(txthostelfee);
        }

        private void txtyear_TextChanged(object sender, EventArgs e)
        {
            bool b = ControlValidation.txtNumericStringIsValid(txtyear);
        }

        private void txtmessdays_TextChanged(object sender, EventArgs e)
        {
            bool b = ControlValidation.txtNumericStringIsValid(txtmessdays);
        }

        private void txtmessfee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Numeric Value");
            }
        }*/


        private void ATxtScholar_Leave(object sender, EventArgs e)
        {
            try
            {
                SqlDataReader reader;
                int count = 0;
                if (ATxtScholar.Text.Trim() != string.Empty)
                {
                    //int studentno;
                    c.returnconn(c.myconn);
                    string mysql;
                    mysql = "select * from tbl_student where scholarno='" + ATxtScholar.Text + "'";
                    SqlCommand com;
                    com = new SqlCommand(mysql, c.myconn);
                    reader = com.ExecuteReader();
                   
                    DataSet ds = Connection.GetDataSet("select count(*) from tbl_roomdet where studentno=(select top 1 studentno from tbl_student where scholarno='" + ATxtScholar.Text + "')");
                    if (ds.Tables[0].Rows.Count > 0)
                        count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    int i = 0;
                    if (reader.HasRows && count != 0)
                    {
                        reader.Read();
                        stuno = Convert.ToInt16(reader["studentno"]);
                        lblstudentno.Text = stuno.ToString();
                        lblfathername.Text = Convert.ToString(reader["father"]);
                        lblname.Text = Convert.ToString(reader["name"]);
                        reader.Close();
                        mysql = "select t.studentno,a.classno,b.classname+' '+c.sectionname as class,e.hostelname,d.bedno,e.hostelfee,e.messfee from tbl_classstudent t ,tbl_class a,tbl_classmaster b,tbl_section c ,tbl_hostel e,tbl_roomdet d";
                        mysql = mysql + " where b.classcode=a.classcode and c.sectioncode=a.sectioncode and t.classno=a.classno and t.sessioncode=" + school.CurrentSessionCode + " and t.studentno=" + stuno + " and t.studentno=d.studentno and d.hostelcode=e.hostelcode";
                        com = new SqlCommand(mysql, c.myconn);
                        reader = com.ExecuteReader();
                        i = 0;
                        if (reader.HasRows)
                        {
                            reader.Read();
                            //DataSet ds = Connection.GetDataSet("select feeno from tbl_hostelfee where studentno='"+studentno +"' and ");
                            //textBox1.Text = ds. Tables [0].Rows[0]["feeno"].ToString ();
                            lblclass.Text = Convert.ToString(reader["class"]);
                            lblbedno.Text = Convert.ToString(reader["hostelname"]) + "   " + Convert.ToString(reader["bedno"]);
                            lblhostelfee.Text = Convert.ToString(reader["hostelfee"]);
                            lblmessfee.Text = Convert.ToString(reader["messfee"]);
                            reader.Close();
                        }
                        else
                            reader.Close();



                        this.ShowFeeDetails();
                        c.GetMdiParent(this).ToggleSaveButton(true);
                    }
                    else
                    {
                        MessageBox.Show("Room not yet alloted to this student.");
                        dtgbook.DataSource = null;
                        
                        //ATxtScholar.Focus();
                    }
                }
                else
                {
                    dtgbook.DataSource = null;
                    c.GetMdiParent(this).ToggleSaveButton(false);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); throw ex;
            }
            
        }

        private void FrmHostalFee_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}

