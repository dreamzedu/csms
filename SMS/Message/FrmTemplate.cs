using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace SMS.Message
{
    public partial class FrmTemplate :UserControlBase
    {

        public FrmTemplate()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        List<string> timeHH = new List<string>() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24" };
        List<string> timemm = new List<string>() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" };
        List<string> timess = new List<string>() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" };
        school1 c = new school1();
        public void GetTemplateN()
        {
            try
            {
                dgTemplate.Rows.Clear();
                string mysql = string.Empty; int i = 0;

                mysql = "select  TemplateId,Name, Description, Status, SchDate, SchTime from tbl_Template";
                SqlDataReader reader = Connection.GetDataReader(mysql);
                
                i = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dgTemplate.Rows.Add();
                        dgTemplate.Rows[i].Cells[0].Value = reader["TemplateId"];
                        dgTemplate.Rows[i].Cells[1].Value = reader["Name"];
                        dgTemplate.Rows[i].Cells[2].Value = reader["Description"];
                        dgTemplate.Rows[i].Cells[5].Value = reader["Status"];
                        if (String.IsNullOrEmpty(reader["SchDate"].ToString()))
                        {
                            dgTemplate.Rows[i].Cells[3].Value = DateTime.Now.ToString("dd/MM/yyyy");
                        }
                        else
                            dgTemplate.Rows[i].Cells[3].Value = Convert.ToDateTime(reader["SchDate"]).ToString("dd/MM/yyyy");
                        if (String.IsNullOrEmpty(reader["SchTime"].ToString()))
                        {
                            dgTemplate.Rows[i].Cells[4].Value = DateTime.Now.ToString("HH:mm:ss");
                        }
                        else
                            dgTemplate.Rows[i].Cells[4].Value = (reader["SchTime"]).ToString();

                        i++;
                    }
                    reader.Close();
                    dgTemplate.AllowUserToAddRows = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void GetTemplate()
        {
            string qry = "select *from tbl_Template";
           
            try
            {
                this.dgTemplate.Rows.Clear();
                DataSet ds = Connection.GetDataSet(qry);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        this.dgTemplate.Rows.Add(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString(), ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][3].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please Check Date Of Attendance!!!");
                    return;
                }
            }
            catch { }
            
        }
        private void Pct_Close_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        DateTimePicker oDateTimePicker;
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgTemplate.CurrentCell.Value = oDateTimePicker.Text.ToString();
        }
        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        public void SaveData()
        {
            try
            {
                SqlTransaction trn=null;
                trn = Connection.GetMyConnection().BeginTransaction();
                int i = 0;
                do
                {
                    Connection.SqlTransection("update tbl_Template set Description='" + dgTemplate.Rows[i].Cells["Description"].Value + "', Status='" + dgTemplate.Rows[i].Cells["Status"].Value + "', SchDate='" + Connection.GetDateMMddyyyy(dgTemplate.Rows[i].Cells["SchDate"].Value.ToString()) + "', SchTime='" + dgTemplate.Rows[i].Cells["SchTime"].Value + "' where TemplateId='" + dgTemplate.Rows[i].Cells["TemplateId"].Value + "' ", Connection.MyConnection, trn);
                    i++;

                }
                while (i <= dgTemplate.Rows.Count - 1);
                trn.Commit();
                MessageBox.Show("Saved..");
            }
            catch { }
        }
        
        public override void btnsave_Click(object sender, EventArgs e)
        {
            SaveData();
            GetTemplateN();

           
        }

        private void FrmTemplate_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        private void FrmTemplate_Load(object sender, EventArgs e)
        {
            GetTemplateN();
            c.GetMdiParent(this).ToggleSaveButton(true);
        }
        ComboBox cmbHH, cmbmm, cmbss; Button gbtnclose;
        private void dgTemplate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 3)
                {
                    string tdts = string.Empty;
                    tdts = dgTemplate.Rows[e.RowIndex].Cells[3].Value.ToString();
                    //Initialized a new DateTimePicker Control  
                    oDateTimePicker = new DateTimePicker();

                    //Adding DateTimePicker control into DataGridView   
                    dgTemplate.Controls.Add(oDateTimePicker);

                    // Setting the format (i.e. 2014-10-10)  
                    //oDateTimePicker.Format = DateTimePickerFormat.Short;
                    oDateTimePicker.Format = DateTimePickerFormat.Custom;
                    oDateTimePicker.CustomFormat = "dd/MM/yyyy";
                    oDateTimePicker.Value = Convert.ToDateTime(Connection.GetDateMMddyyyy(tdts));
                    // It returns the retangular area that represents the Display area for a cell  
                    Rectangle oRectangle = dgTemplate.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

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
                if (e.ColumnIndex == 4)
                {

                    string tdts = string.Empty;
                    tdts = dgTemplate.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string[] ss = tdts.Split(':');
                    //Initialized a new DateTimePicker Control  
                    cmbHH = new ComboBox();
                    cmbmm = new ComboBox();
                    cmbss = new ComboBox();
                    gbtnclose = new Button();
                    cmbHH.Name = "cmbHH_" + e.RowIndex.ToString();
                    cmbmm.Name = "cmbmm_" + e.RowIndex.ToString();
                    cmbss.Name = "cmbss_" + e.RowIndex.ToString();

                    gbtnclose.Name = "gbtnclose_" + e.RowIndex.ToString();
                    gbtnclose.Text = "X";
                    //Adding DateTimePicker control into DataGridView   
                    dgTemplate.Controls.Add(cmbHH);
                    dgTemplate.Controls.Add(cmbmm);
                    dgTemplate.Controls.Add(cmbss);
                    dgTemplate.Controls.Add(gbtnclose);
                    cmbHH.DataSource = timeHH;
                    cmbmm.DataSource = timemm;
                    cmbss.DataSource = timess;
                    cmbHH.Text = ss[0];
                    cmbmm.Text = ss[1];
                    cmbss.Text = ss[2];

                    Rectangle oRectangle = dgTemplate.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    cmbHH.Size = new Size(35, oRectangle.Height);
                    cmbHH.Location = new Point(oRectangle.X, oRectangle.Y);

                    cmbmm.Size = new Size(35, oRectangle.Height);
                    cmbmm.Location = new Point(oRectangle.X + 35, oRectangle.Y);

                    cmbss.Size = new Size(35, oRectangle.Height);
                    cmbss.Location = new Point(oRectangle.X + 70, oRectangle.Y);

                    gbtnclose.Size = new Size(20, 20);
                    gbtnclose.Location = new Point(oRectangle.X + 105, oRectangle.Y);

                    //cmbHH.Location = new Point(e.ColumnIndex, e.RowIndex);
                    //cmbmm.Location = new Point(e.ColumnIndex, e.RowIndex);
                    //cmbss.Location = new Point(e.ColumnIndex, e.RowIndex);

                    // An event attached to dateTimePicker Control which is fired when any date is selected  
                    gbtnclose.Click += new EventHandler(gbtnclose_Click);

                    // Setting the format (i.e. 2014-10-10)  
                    //oDateTimePicker.Format = DateTimePickerFormat.Short;

                }
            }
        }
        private void gbtnclose_Click(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgTemplate.CurrentCell.Value = cmbHH.SelectedValue.ToString()+":"+cmbmm.SelectedValue.ToString()+":"+cmbss.SelectedValue.ToString();
            cmbHH.Visible = false; cmbmm.Visible = false; cmbss.Visible = false; gbtnclose.Visible = false;
        }

        private void dgTemplate_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgTemplate.RowTemplate.Height = 80;
            dgTemplate.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
        }
       
    }
}
