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
using Microsoft.SqlServer.Server;

namespace SMS
{
    public partial class frmYearlyClassFeeHead :UserControlBase
    {

        school1 c = new school1();
        int classno;

        //Boolean add_edit = false;

        public frmYearlyClassFeeHead()
        {
            InitializeComponent();    //DesignForm.fromDesign1(this);
            Connection.SetUserControlTheme(this);
        }

        private void frmregularfeeheads_Load(object sender, EventArgs e)
        {
            c.GetMdiParent(this).ToggleSaveButton(true);
            c.GetMdiParent(this).TogglePrintButton(true); //.EnableAllEditMenuButtons();
            c.getconnstr();
            
           // c.FillcomboBox("select a.classno,b.classname as class from tbl_class a,tbl_classmaster b,tbl_section c where b.classcode=a.classcode and c.sectioncode=a.sectioncode", "class", "classno", ref cmbclass);
            //MessageBox.Show(c.myconn.ConnectionString);  
            c.FillcomboBox("select classcode,classname from tbl_classmaster  order by classcode", "classname", "classcode", ref cmbclass);
            cmbclass.SelectedIndex = 0;
        }

        private void cmbclass_Validated(object sender, EventArgs e)
        {
            //string classno;
            //DataSet ds = Connection.GetDataSet("Select classcode from tbl_classmaster where classname='" + cmbclass.Text + "'");
            //classno = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            ////-------for stream--------
            //if (Convert.ToInt32(classno) > 110 && Convert.ToInt32(classno) < 113)
            //{
            //    strcmbfaculty.Visible = true;
            //    label43.Visible = true;

            //    Connection.FillComboBox(strcmbfaculty, "select sankaycode,sankayname from tbl_sankay where sankayName!='Common' order by sankayname");
            //    strcmbfaculty.SelectedIndex = 0;
            //}
            //else
            //{
            //    strcmbfaculty.Visible = true;
            //    label43.Visible = true;

            //    Connection.FillComboBox(strcmbfaculty, "select sankaycode,sankayname from tbl_sankay where sankayName='Common' order by sankayname");
            //    strcmbfaculty.SelectedIndex = 0;
            //}
            ////------------------------
            //strcmbfaculty.Focus();
        }
       

      public override void btnsave_Click(object sender, EventArgs e)
      {
          int i = 0;
          //if (add_edit == true)
          //{
              c.returnconn(c.myconn);
              SqlTransaction trn = c.myconn.BeginTransaction();
              c.connectsql("delete from tbl_classfeeregular where sessioncode='" + school.CurrentSessionCode + "' and  classno='" + cmbclass.SelectedValue + "' and stream=" + strcmbfaculty.SelectedValue + "", c.myconn, trn);
              do
              {
                  bool TRTE = false;
                  if (string.IsNullOrEmpty(dtgfeeheads.Rows[i].Cells["RTE"].Value.ToString()))
                      TRTE = false;
                  else
                  TRTE = Convert.ToBoolean(dtgfeeheads.Rows[i].Cells["RTE"].Value);
                  c.connectsql("insert into tbl_classfeeregular (sessioncode,classno,feecode,feeamt,stream,Date,RTE) values (" + school.CurrentSessionCode + "," + cmbclass.SelectedValue + "," + dtgfeeheads.Rows[i].Cells["feecode"].Value + "," + Convert.ToDecimal(dtgfeeheads.Rows[i].Cells["feeamt"].Value) + "," + strcmbfaculty.SelectedValue + ",'" + Connection.GetDateMMddyyyy((dtgfeeheads.Rows[i].Cells[3].Value).ToString()) + "','" + TRTE + "')", c.myconn, trn);
                  i++;
              }
              while (i < dtgfeeheads.Rows.Count);
              trn.Commit();
              MessageBox.Show("Data Saved..", "School");
              //add_edit = false;
              //c.GetMdiParent(this).EnableAllEditMenuButtons();
          //}
          //else
          //{
          //    if (add_edit == false)
          //    {
          //        SqlTransaction trn = c.myconn.BeginTransaction();
          //        c.connectsql("delete from tbl_classfeeregular where sessioncode='" + school.CurrentSessionCode + "' and  classno='" + cmbclass.SelectedValue + "' and stream=" + strcmbfaculty.SelectedValue + "", c.myconn, trn);
          //        do
          //        {
          //            bool TRTE = false;
          //             if(string.IsNullOrEmpty(dtgfeeheads.Rows[i].Cells["RTE"].Value.ToString()))
          //                 TRTE=false;
          //            else
          //                TRTE = Convert.ToBoolean(dtgfeeheads.Rows[i].Cells["RTE"].Value);
          //            c.connectsql("insert into tbl_classfeeregular (sessioncode,classno,feecode,feeamt,stream,Date,RTE) values (" + school.CurrentSessionCode + "," + cmbclass.SelectedValue + "," + dtgfeeheads.Rows[i].Cells["feecode"].Value + "," + Convert.ToDecimal(dtgfeeheads.Rows[i].Cells["feeamt"].Value) + "," + strcmbfaculty.SelectedValue + ",'" + Connection.GetDateMMddyyyy((dtgfeeheads.Rows[i].Cells[3].Value).ToString()) + "','"+TRTE+"')", c.myconn, trn);
          //           // c.connectsql("update tbl_classfeeregular set feeamt = " + dtgfeeheads.Rows[i].Cells["feeamt"].Value + " where sessioncode=" + school .CurrentSessionCode + " and classno=" + cmbclass.SelectedValue + "  and feecode=" + dtgfeeheads.Rows[i].Cells["feecode"].Value, c.myconn, trn);
          //            i++;
          //        }
          //        while (i < dtgfeeheads.Rows.Count);
          //        trn.Commit();
          //        MessageBox.Show("Data Saved..", "School");
          //        add_edit = false;
          //        c.GetMdiParent(this).EnableAllEditMenuButtons();
          //    }
          //    DesignForm.fromDesign1(this);
          //}
      }

      //private void btnexit_Click(object sender, EventArgs e)
      //{
      //    //this.Close(); 
      //}

      //public override void btnnew_Click(object sender, EventArgs e)
      //{
      //    DesignForm.fromDesign2(this);
      //    add_edit = true;
      //    c.cleartext(this);
      //    c.GetMdiParent(this).DisableAllEditMenuButtons();
      //    cmbclass.Focus();
      //}

      //public override void btnedit_Click(object sender, EventArgs e)
      //{
      //    DesignForm.fromDesign2(this);
      //    add_edit = false;
      //    c.GetMdiParent(this).DisableAllEditMenuButtons();
      //}

      //public override void btncancel_Click(object sender, EventArgs e)
      //{
      //    add_edit = false;
      //    c.GetMdiParent(this).EnableAllEditMenuButtons();
      //}

      private void cmbclass_KeyPress(object sender, KeyPressEventArgs e)
      {
          c.entertotab(e.KeyChar);
      } 

      private void cmbclass_SelectedIndexChanged(object sender, EventArgs e)
      {
          c.getconnstr();
      }

      public override void btnprint_Click(object sender, EventArgs e)
      {    
          DataSet ds3=Connection .GetDataSet ("select classcode from tbl_classmaster where classname='"+cmbclass .Text +"'");
          classno = Convert.ToInt32(ds3.Tables[0].Rows[0].ItemArray[0].ToString());
          string str = "";
          str = " SELECT tbl_feeheads.feeheads, tbl_classfeeregular.feeamt, '" + cmbclass.Text + "' as ClassName FROM tbl_classfeeregular INNER JOIN tbl_feeheads ON tbl_classfeeregular.feecode = tbl_feeheads.feecode inner join tbl_sankay ts on ts.sankaycode=tbl_classfeeregular.Stream WHERE (tbl_classfeeregular.classno = '" + classno.ToString() + "' and tbl_classfeeregular.Stream='" + strcmbfaculty.SelectedValue.ToString() + "' )";
          str = str + "select sum(feeamt) from tbl_classfeeregular where classno='" + classno.ToString() + "'";
          str = str + "SELECT schoolname, schooladdress, logoimage FROM tbl_school";
          DataSet ds4 = Connection.GetDataSet(str );
          if (ds4 != null)
          {
              //ds4.WriteXmlSchema(@"D:\Barcodes\a\regularFeeInfo.xsd");
              regularFeeInfo fr = new regularFeeInfo();
              fr.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
              fr.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
              fr.SetDataSource(ds4);
              ShowAllReports s = new ShowAllReports();
              s.crystalReportViewer1.ReportSource = fr;
              s.Show();
          }
      }
 

      private void dtgfeeheads_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
      {
          Connection.SetDataGridViewRowPostPaint(dtgfeeheads, e);
      }

      private void strcmbfaculty_Validated(object sender, EventArgs e)
      {
          //c.returnconn(c.myconn);
          //int i = 0;
          //string FeeHeades = string.Empty;
          //DataSet ds1 = Connection.GetDataSet("select  count(*) from tbl_classfeeregular a,tbl_feeheads b where a.feecode=b.feecode and a.sessioncode=" + school.CurrentSessionCode + " and a.classno='" + cmbclass.SelectedValue + "' and a.stream='" + strcmbfaculty.SelectedValue + "' and b.feecode!='101'and a.feecode!='101'");
          //int n = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
          //SqlCommand com = new SqlCommand("select  a.* ,b.feeheads from tbl_classfeeregular a,tbl_feeheads b where a.feecode=b.feecode and a.sessioncode=" + school.CurrentSessionCode + " and b.feecode!='101'and a.feecode!='101' and a.classno=" + cmbclass.SelectedValue + " and a.stream='" + strcmbfaculty.SelectedValue + "' Order By Feecode", c.myconn);
          //SqlDataReader reader = com.ExecuteReader();
          //if (reader.HasRows)
          //{
          //    dtgfeeheads.Rows.Clear();
          //    while (reader.Read())
          //    {
          //        dtgfeeheads.Rows.Add();


          //        dtgfeeheads.Rows[i].Cells[0].Value = reader["feecode"];
          //        dtgfeeheads.Rows[i].Cells[1].Value = reader["feeheads"];
          //        dtgfeeheads.Rows[i].Cells[2].Value = reader["feeamt"];
          //        dtgfeeheads.Rows[i].Cells[4].Value = reader["RTE"];

          //        if (string.IsNullOrEmpty(FeeHeades))
          //            FeeHeades = dtgfeeheads.Rows[i].Cells[1].Value.ToString();
          //        else
          //            FeeHeades = FeeHeades + "," + dtgfeeheads.Rows[i].Cells[1].Value.ToString();
          //        DataSet ds = Connection.GetDataSet("select convert(nvarchar(10), Date,103) as Date from tbl_classfeeregular where sessioncode='" + school.CurrentSessionCode + "' and classno='" + cmbclass.SelectedValue.ToString() + "' and feecode= '" + dtgfeeheads.Rows[i].Cells[0].Value.ToString() + "' and stream='" + strcmbfaculty.SelectedValue.ToString() + "' select s_to from tbl_session where sessioncode='" + school.CurrentSessionCode + "' ");

          //        if (ds.Tables[0].Rows.Count > 0)
          //        {
          //            if (String.IsNullOrEmpty(ds.Tables[0].Rows[0]["Date"].ToString()))
          //            {
          //                dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(ds.Tables[1].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
          //            }
          //            else
          //                dtgfeeheads.Rows[i].Cells[3].Value = ds.Tables[0].Rows[0]["Date"].ToString();
          //        }
          //        else
          //        {
          //            dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(ds.Tables[1].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
          //        }

          //        i++;

          //        if (n == i)
          //        {
          //            FeeHeades = FeeHeades.Replace(",", "','");
          //            FeeHeades = "'" + FeeHeades + "'";

          //            DataSet dsi = Connection.GetDataSet("select feecode,feeheads,'0' as feeamt,'False' as RTE   from tbl_feeheads where feecode!='101' And feeheads Not in (" + FeeHeades + ") Order By FeeCode");
          //            for (int l = 0; l < dsi.Tables[0].Rows.Count; l++)
          //            {
          //                dtgfeeheads.Rows.Add();
          //                DataRow dr = dsi.Tables[0].Rows[l];
          //                dtgfeeheads.Rows[i].Cells[0].Value = dr[0].ToString();
          //                dtgfeeheads.Rows[i].Cells[1].Value = dr[1].ToString();
          //                dtgfeeheads.Rows[i].Cells[2].Value = dr[2].ToString();
          //                dtgfeeheads.Rows[i].Cells[4].Value = dr[3].ToString();

          //                DataSet dsin = Connection.GetDataSet("select convert(nvarchar(10), Date,103) as Date from tbl_classfeeregular where sessioncode='" + school.CurrentSessionCode + "' and classno='" + cmbclass.SelectedValue.ToString() + "' and feecode= '" + dr[0].ToString() + "' and stream='" + strcmbfaculty.SelectedValue.ToString() + "' select s_to from tbl_session where sessioncode='" + school.CurrentSessionCode + "' ");

          //                if (dsin.Tables[0].Rows.Count > 0)
          //                {
          //                    if (String.IsNullOrEmpty(dsin.Tables[0].Rows[0]["Date"].ToString()))
          //                    {
          //                        dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(dsin.Tables[1].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
          //                    }
          //                    else
          //                        dtgfeeheads.Rows[i].Cells[3].Value = dsin.Tables[0].Rows[0]["Date"].ToString();
          //                }
          //                else
          //                {
          //                    dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(dsin.Tables[1].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
          //                }

          //                i++;
          //            }
          //        }

          //    }
          //    dtgfeeheads.Columns["feecode"].Width = 50;
          //    dtgfeeheads.Columns["feecode"].Visible = false;
          //    dtgfeeheads.Columns[1].ReadOnly = true;
          //    //add_edit = false;
          //    reader.Close();

          //}
          //else
          //{
          //    if (reader.IsClosed == false)
          //    {
          //        reader.Close();
          //    }
          //    com = new SqlCommand("select feecode,feeheads,'0' as feeamt,'False' as RTE   from tbl_feeheads where feecode!='101' ", c.myconn);
          //    DataSet dsin = Connection.GetDataSet("select s_to from tbl_session where sessioncode='" + school.CurrentSessionCode + "' ");
          //    // where feetype in (2)
          //    reader = com.ExecuteReader();
          //    if (reader.HasRows)
          //    {
          //        dtgfeeheads.Rows.Clear();
          //        while (reader.Read())
          //        {

                      
          //            dtgfeeheads.Rows.Add();
          //            dtgfeeheads.Rows[i].Cells[0].Value = reader["feecode"];
          //            dtgfeeheads.Rows[i].Cells[1].Value = reader["feeheads"];
          //            dtgfeeheads.Rows[i].Cells[2].Value = reader["feeamt"];
          //            dtgfeeheads.Rows[i].Cells[4].Value = reader["RTE"];
          //            if(dsin.Tables[0].Rows.Count>0)
          //                dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(dsin.Tables[0].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
          //            else
          //                dtgfeeheads.Rows[i].Cells[3].Value = DateTime.Now.ToString("dd/MM/yyyy");
          //            i++;
          //        }
          //        dtgfeeheads.Columns["feecode"].Width = 50;
          //        dtgfeeheads.Columns["feecode"].Visible = false;
          //        dtgfeeheads.Columns[1].ReadOnly = true;
          //        //add_edit = true;
          //    }
          //}
          //dtgfeeheads.Focus();
      }


      private void frmYearlyClassFeeHead_Paint(object sender, PaintEventArgs e)
      {
          //public static void fromClear(Form f);
      }
      DateTimePicker oDateTimePicker;
      private void dtgfeeheads_CellClick(object sender, DataGridViewCellEventArgs e)
      {
          if (e.ColumnIndex == 3)
          {
              string tdts = string.Empty;
              tdts = dtgfeeheads.Rows[e.RowIndex].Cells[3].Value.ToString();
              //Initialized a new DateTimePicker Control  
              oDateTimePicker = new DateTimePicker();

              //Adding DateTimePicker control into DataGridView   
              dtgfeeheads.Controls.Add(oDateTimePicker);

              // Setting the format (i.e. 2014-10-10)  
              //oDateTimePicker.Format = DateTimePickerFormat.Short;
              oDateTimePicker.Format = DateTimePickerFormat.Custom;
              oDateTimePicker.CustomFormat = "dd/MM/yyyy";
              oDateTimePicker.Value = Convert.ToDateTime(Connection.GetDateMMddyyyy(tdts));
              // It returns the retangular area that represents the Display area for a cell  
              Rectangle oRectangle = dtgfeeheads.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

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
          dtgfeeheads.CurrentCell.Value = oDateTimePicker.Text.ToString();
      }

      void oDateTimePicker_CloseUp(object sender, EventArgs e)
      {
          // Hiding the control after use   
          oDateTimePicker.Visible = false;
      }

      //public override void btndelete_Click(object sender, EventArgs e)
      //{

      //}

      private void dtgfeeheads_DataError(object sender, DataGridViewDataErrorEventArgs e)
      {
          try
          {

          }
          catch(Exception ex)
          {
              Logger.LogError(ex); 
          }
      }

      private void cmbclass_Leave(object sender, EventArgs e)
      {
          string classno;
          DataSet ds = Connection.GetDataSet("Select classcode from tbl_classmaster where classname='" + cmbclass.Text + "'");
          classno = ds.Tables[0].Rows[0].ItemArray[0].ToString();
          //-------for stream--------
          if (Convert.ToInt32(classno) > 110 && Convert.ToInt32(classno) < 113)
          {
              strcmbfaculty.Visible = true;
              label43.Visible = true;

              Connection.FillComboBox(strcmbfaculty, "select sankaycode,sankayname from tbl_sankay where sankayName!='Common' order by sankayname");
              strcmbfaculty.SelectedIndex = 0;
          }
          else
          {
              strcmbfaculty.Visible = true;
              label43.Visible = true;

              Connection.FillComboBox(strcmbfaculty, "select sankaycode,sankayname from tbl_sankay where sankayName='Common' order by sankayname");
              strcmbfaculty.SelectedIndex = 0;
          }
          //------------------------
          strcmbfaculty.Focus();
      }

      private void strcmbfaculty_Leave(object sender, EventArgs e)
      {
          if (strcmbfaculty.SelectedValue != null)
              LoadFeeStructure(cmbclass.SelectedValue.ToString(), strcmbfaculty.SelectedValue.ToString());
      }

        private void LoadFeeStructure(string clsCode, string strmCode)
        {
            c.returnconn(c.myconn);
            int i = 0;
            string FeeHeades = string.Empty;
            DataSet ds1 = Connection.GetDataSet("select  count(*) from tbl_classfeeregular a,tbl_feeheads b where a.feecode=b.feecode and a.sessioncode=" + school.CurrentSessionCode + " and a.classno='" + clsCode + "' and a.stream='" + strmCode + "' and b.feecode!='101'and a.feecode!='101'");
            int n = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
            SqlCommand com = new SqlCommand("select  a.* ,b.feeheads from tbl_classfeeregular a,tbl_feeheads b where a.feecode=b.feecode and a.sessioncode=" + school.CurrentSessionCode + " and b.feecode!='101'and a.feecode!='101' and a.classno=" + clsCode + " and a.stream='" + strmCode + "' Order By Feecode", c.myconn);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                dtgfeeheads.Rows.Clear();
                while (reader.Read())
                {
                    dtgfeeheads.Rows.Add();


                    dtgfeeheads.Rows[i].Cells[0].Value = reader["feecode"];
                    dtgfeeheads.Rows[i].Cells[1].Value = reader["feeheads"];
                    dtgfeeheads.Rows[i].Cells[2].Value = reader["feeamt"];
                    dtgfeeheads.Rows[i].Cells[4].Value = reader["RTE"];

                    if (string.IsNullOrEmpty(FeeHeades))
                        FeeHeades = dtgfeeheads.Rows[i].Cells[1].Value.ToString();
                    else
                        FeeHeades = FeeHeades + "," + dtgfeeheads.Rows[i].Cells[1].Value.ToString();
                    DataSet ds = Connection.GetDataSet("select convert(nvarchar(10), Date,103) as Date from tbl_classfeeregular where sessioncode='" + school.CurrentSessionCode + "' and classno='" + clsCode + "' and feecode= '" + dtgfeeheads.Rows[i].Cells[0].Value.ToString() + "' and stream='" + strmCode + "' select s_to from tbl_session where sessioncode='" + school.CurrentSessionCode + "' ");

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (String.IsNullOrEmpty(ds.Tables[0].Rows[0]["Date"].ToString()))
                        {
                            dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(ds.Tables[1].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
                        }
                        else
                            dtgfeeheads.Rows[i].Cells[3].Value = ds.Tables[0].Rows[0]["Date"].ToString();
                    }
                    else
                    {
                        dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(ds.Tables[1].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
                    }

                    i++;

                    if (n == i)
                    {
                        FeeHeades = FeeHeades.Replace(",", "','");
                        FeeHeades = "'" + FeeHeades + "'";

                        DataSet dsi = Connection.GetDataSet("select feecode,feeheads,'0' as feeamt,'False' as RTE   from tbl_feeheads where feecode!='101' And feeheads Not in (" + FeeHeades + ") Order By FeeCode");
                        for (int l = 0; l < dsi.Tables[0].Rows.Count; l++)
                        {
                            dtgfeeheads.Rows.Add();
                            DataRow dr = dsi.Tables[0].Rows[l];
                            dtgfeeheads.Rows[i].Cells[0].Value = dr[0].ToString();
                            dtgfeeheads.Rows[i].Cells[1].Value = dr[1].ToString();
                            dtgfeeheads.Rows[i].Cells[2].Value = dr[2].ToString();
                            dtgfeeheads.Rows[i].Cells[4].Value = dr[3].ToString();

                            DataSet dsin = Connection.GetDataSet("select convert(nvarchar(10), Date,103) as Date from tbl_classfeeregular where sessioncode='" + school.CurrentSessionCode + "' and classno='" + clsCode + "' and feecode= '" + dr[0].ToString() + "' and stream='" + strmCode + "' select s_to from tbl_session where sessioncode='" + school.CurrentSessionCode + "' ");

                            if (dsin.Tables[0].Rows.Count > 0)
                            {
                                if (String.IsNullOrEmpty(dsin.Tables[0].Rows[0]["Date"].ToString()))
                                {
                                    dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(dsin.Tables[1].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
                                }
                                else
                                    dtgfeeheads.Rows[i].Cells[3].Value = dsin.Tables[0].Rows[0]["Date"].ToString();
                            }
                            else
                            {
                                dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(dsin.Tables[1].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
                            }

                            i++;
                        }
                    }

                }
                dtgfeeheads.Columns["feecode"].Width = 50;
                dtgfeeheads.Columns["feecode"].Visible = false;
                dtgfeeheads.Columns[1].ReadOnly = true;
                //add_edit = false;
                reader.Close();
            }
            else
            {
                if (reader.IsClosed == false)
                {
                    reader.Close();
                }
                com = new SqlCommand("select feecode,feeheads,'0' as feeamt,'False' as RTE   from tbl_feeheads where feecode!='101' ", c.myconn);
                DataSet dsin = Connection.GetDataSet("select s_to from tbl_session where sessioncode='" + school.CurrentSessionCode + "' ");
                // where feetype in (2)
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    dtgfeeheads.Rows.Clear();
                    while (reader.Read())
                    {


                        dtgfeeheads.Rows.Add();
                        dtgfeeheads.Rows[i].Cells[0].Value = reader["feecode"];
                        dtgfeeheads.Rows[i].Cells[1].Value = reader["feeheads"];
                        dtgfeeheads.Rows[i].Cells[2].Value = reader["feeamt"];
                        dtgfeeheads.Rows[i].Cells[4].Value = reader["RTE"];
                        if (dsin.Tables[0].Rows.Count > 0)
                            dtgfeeheads.Rows[i].Cells[3].Value = Convert.ToDateTime(dsin.Tables[0].Rows[0]["s_to"]).ToString("dd/MM/yyyy");
                        else
                            dtgfeeheads.Rows[i].Cells[3].Value = DateTime.Now.ToString("dd/MM/yyyy");
                        i++;
                    }
                    dtgfeeheads.Columns["feecode"].Width = 50;
                    dtgfeeheads.Columns["feecode"].Visible = false;
                    dtgfeeheads.Columns[1].ReadOnly = true;
                    //add_edit = true;
                }
            }
            dtgfeeheads.Focus();
        }
      private void btnCopyFrom_Click(object sender, EventArgs e)
      {
          if (dtgfeeheads.RowCount > 0)
          {
              if (cmbclass.SelectedIndex == 0)
              {
                  MessageBox.Show("Please select a higher class.");
              }
              else
              {
                  string prevClsCode = Connection.GetPreviousClass(cmbclass.SelectedValue.ToString().Trim());
                  LoadFeeStructure(prevClsCode.Trim(), strcmbfaculty.SelectedValue.ToString().Trim());
              }
          }
          else
          {
              MessageBox.Show("Please select a class and stream first");
          }
      }
      

    }
}
