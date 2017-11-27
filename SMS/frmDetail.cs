using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Web.UI;




namespace SMS
{
    public partial class frmDetail : System.Windows.Forms.UserControl
    {
        school c = new school();
        DataSet dsDetail;
        public frmDetail()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void txtscholarno_Validated(object sender, EventArgs e)
        {
           // DataSet dsDetail = Connection.GetDataSet("SELECT tbl_classmaster.classname, tbl_section.sectionname, tbl_sankay.sankayname  FROM         tbl_classstudent INNER JOIN   tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode INNER JOIN  tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode INNER JOIN   tbl_sankay ON tbl_classstudent.Stream = tbl_sankay.sankaycode where tbl_classstudent.sessioncode='" + valcmbsession.SelectedValue.ToString() + "' and tbl_classstudent.studentno='" + txtstudentno.Text + "' ");
        }

        private void frmDetail_Load(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetDataSet("SELECT sessionname, sessioncode  FROM tbl_session Order By sessioncode;" +
                " SELECT ClassName, ClassCode  FROM tbl_ClassMaster Order By ClassCode;");
            foreach (DataRow rw in ds.Tables[0].Rows)
                cmbSession.Items.Add(rw["sessionname"].ToString());
            foreach (DataRow rw in ds.Tables[1].Rows)
                cmbClass.Items.Add(rw["ClassName"].ToString());

            dsDetail = Connection.GetDataSet("sp_AllStudent '" + school.CurrentSessionCode + "'");
            if (dsDetail.Tables[0].Rows.Count > 0)
            {
                //  btnGenerateExcel.Enabled = true;
             dataGridView1.DataSource = dsDetail.Tables[0];
            }
        }
 
 
       
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtName.Text.Trim()))
                    if (dsDetail.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = dsDetail.Tables[0].DefaultView;
                        dv.RowFilter = "[Name] Like '" + txtName.Text.Trim() + "%'";
                        if (dv.Table.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dv;
                            //  btnGenerateExcel.Enabled = true;
                        }
                        else
                        {
                            dataGridView1.DataSource = dsDetail.Tables[0];
                            //  btnGenerateExcel.Enabled = true;
                        }
                    }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtScholarNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtScholarNo.Text.Trim()))
                if (dsDetail.Tables[0].Rows.Count > 0)
                {
                    DataView dv = dsDetail.Tables[0].DefaultView;
                    dv.RowFilter = "[Scholar No] Like '" + txtScholarNo.Text.Trim() + "%'";
                    if (dv.Table.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dv;
                        // btnGenerateExcel.Enabled = true;
                    }
                    else
                    {
                        dataGridView1.DataSource = dsDetail.Tables[0];
                        // btnGenerateExcel.Enabled = true;
                    }
                }
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbSession.Text.Trim()))
            {
                dataGridView1.DataSource = null;
                dsDetail = Connection.GetDataSet("sp_AllStudent '" +
                    Connection.GetExecuteScalar("Select SessionCode From tbl_Session where SessionName='" + cmbSession.Text.Trim() + "'").ToString() + "'");
                if (dsDetail.Tables[0].Rows.Count > 0)
                {
                    // btnGenerateExcel.Enabled = true;
                    dataGridView1.DataSource = dsDetail.Tables[0];
                }
                
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbClass.Text.Trim()))
                {
                    if (dsDetail.Tables[0].Rows.Count > 0)
                    {
                        DataView dv = dsDetail.Tables[0].DefaultView;

                        dv.RowFilter = "[ClassCode] = '" + Convert.ToInt32(Connection.GetExecuteScalar("Select ClassCode From tbl_ClassMaster Where ClassName='" + cmbClass.SelectedItem.ToString() + "'")) + "'";
                        if (dv.Table.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dv.ToTable();
                            //   btnGenerateExcel.Enabled = true;
                        }
                        else
                        {
                            dataGridView1.DataSource = dsDetail.Tables[0];
                            //  btnGenerateExcel.Enabled = true;
                        }
                    }
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void frmDetail_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode.Equals(Keys.Escape))
            //    this.Close();
        }

        private void btnGenerateExcelFile_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                if (MessageBox.Show("Are You Sure To Generate File In Excel Format?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    Connection.SaveDataGridViewAsExcelFile(dataGridView1, dsDetail);
                
            }
            else
                MessageBox.Show("There Are No Record...");
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Connection.SetDataGridViewRowPostPaint(dataGridView1, e);
        }
    
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dataGridView1.RowTemplate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

                dataGridView1.Columns["ClassCode"].Visible = false;
                dataGridView1.Columns["SectionCode"].Visible = false;
                dataGridView1.Columns["Photo"].Visible = true;
                dataGridView1.Columns["Scholar No"].Width = 60;
                dataGridView1.RowTemplate.Height = 80;
                ((DataGridViewImageColumn)dataGridView1.Columns["Photo"]).ImageLayout = DataGridViewImageCellLayout.Stretch;
               
                foreach (DataGridViewRow r in dataGridView1.Rows)
                {


                    dataGridView1.Rows[r.Index].Cells["TC"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Rows[r.Index].Cells["SLC"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Rows[r.Index].Cells["Marksheet"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Rows[r.Index].Cells["Income Tax"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Rows[r.Index].Cells["Cast Certificate"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Rows[r.Index].Cells["Sport"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Rows[r.Index].Cells["DOB"].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    
                    if (r.Cells["RTE"].Value.Equals("Yes"))
                    {
                        r.DefaultCellStyle.ForeColor = Color.BlueViolet;
                    }
                    if (r.Cells["Scholarship"].Value.Equals("Yes"))
                    {
                        r.DefaultCellStyle.ForeColor = Color.Blue;
                    }

                    if (r.Cells["TC"].Value.Equals("Yes"))
                    {
                        dataGridView1.Rows[r.Index].Cells["TC"].Style.BackColor = Color.Green;
                        dataGridView1.Rows[r.Index].Cells["TC"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["TC"].Width = 60;
                    }
                    else
                    {
                        dataGridView1.Rows[r.Index].Cells["TC"].Style.BackColor = Color.Red;
                        dataGridView1.Rows[r.Index].Cells["TC"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["TC"].Width = 60;
                    }
                    if (r.Cells["SLC"].Value.Equals("Yes"))
                    {
                        dataGridView1.Rows[r.Index].Cells["SLC"].Style.BackColor = Color.Green;
                        dataGridView1.Rows[r.Index].Cells["SLC"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["SLC"].Width = 60;
                    }
                    else
                    {
                        dataGridView1.Rows[r.Index].Cells["SLC"].Style.BackColor = Color.Red;
                        dataGridView1.Rows[r.Index].Cells["SLC"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["SLC"].Width = 60;
                    }
                    if (r.Cells["Marksheet"].Value.Equals("Yes"))
                    {
                        dataGridView1.Rows[r.Index].Cells["Marksheet"].Style.BackColor = Color.Green;
                        dataGridView1.Rows[r.Index].Cells["Marksheet"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["Marksheet"].Width = 60;
                    }
                    else
                    {
                        dataGridView1.Rows[r.Index].Cells["Marksheet"].Style.BackColor = Color.Red;
                        dataGridView1.Rows[r.Index].Cells["Marksheet"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["Marksheet"].Width = 60;
                    }
                    if (r.Cells["Income Tax"].Value.Equals("Yes"))
                    {
                        dataGridView1.Rows[r.Index].Cells["Income Tax"].Style.BackColor = Color.Green;
                        dataGridView1.Rows[r.Index].Cells["Income Tax"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["Income Tax"].Width = 60;
                    }
                    else
                    {
                        dataGridView1.Rows[r.Index].Cells["Income Tax"].Style.BackColor = Color.Red;
                        dataGridView1.Rows[r.Index].Cells["Income Tax"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["Income Tax"].Width = 60;

                    }
                    if (r.Cells["Cast Certificate"].Value.Equals("Yes"))
                    {
                        dataGridView1.Rows[r.Index].Cells["Cast Certificate"].Style.BackColor = Color.Green;
                        dataGridView1.Rows[r.Index].Cells["Cast Certificate"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["Cast Certificate"].Width = 60;
                    }
                    else
                    {
                        dataGridView1.Rows[r.Index].Cells["Cast Certificate"].Style.BackColor = Color.Red;
                        dataGridView1.Rows[r.Index].Cells["Cast Certificate"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["Cast Certificate"].Width = 60;
                    }
                    if (r.Cells["Sport"].Value.Equals("Yes"))
                    {
                        dataGridView1.Rows[r.Index].Cells["Sport"].Style.BackColor = Color.Green;
                        dataGridView1.Rows[r.Index].Cells["Sport"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["Sport"].Width = 60;
                    }
                    else
                    {
                        dataGridView1.Rows[r.Index].Cells["Sport"].Style.BackColor = Color.Red;
                        dataGridView1.Rows[r.Index].Cells["Sport"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["Sport"].Width = 60;
                    }
                    if (r.Cells["DOB"].Value.Equals("Yes"))
                    {
                        dataGridView1.Rows[r.Index].Cells["DOB"].Style.BackColor = Color.Green;
                        dataGridView1.Rows[r.Index].Cells["DOB"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["DOB"].Width = 60;
                    }
                    else
                    {
                        dataGridView1.Rows[r.Index].Cells["DOB"].Style.BackColor = Color.Red;
                        dataGridView1.Rows[r.Index].Cells["DOB"].Style.ForeColor = Color.White;
                        dataGridView1.Columns["DOB"].Width = 60;
                    }
                }

            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void frmDetail_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = 0,f=0;
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name.ToString() == "TC")
                {
                    
                    row = dataGridView1.CurrentCell.RowIndex;
                    if (dataGridView1["TC", row].Value.Equals("Yes"))
                        f=Connection.GetDocuments(Convert.ToString(dataGridView1["Scholar No", row].Value), "TC");
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name.ToString() == "SLC")
                {
                    row = dataGridView1.CurrentCell.RowIndex;
                    if (dataGridView1["SLC", row].Value.Equals("Yes"))
                        f = Connection.GetDocuments(Convert.ToString(dataGridView1["Scholar No", row].Value), "SLC");
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name.ToString() == "Marksheet")
                {
                    row = dataGridView1.CurrentCell.RowIndex;
                    if (dataGridView1["Marksheet", row].Value.Equals("Yes"))
                        f = Connection.GetDocuments(Convert.ToString(dataGridView1["Scholar No", row].Value), "MSC");
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name.ToString() == "Income Tax")
                {
                    row = dataGridView1.CurrentCell.RowIndex;
                    if (dataGridView1["Income Tax", row].Value.Equals("Yes"))
                        f = Connection.GetDocuments(Convert.ToString(dataGridView1["Scholar No", row].Value), "ITC");
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name.ToString() == "Cast Certificate")
                {
                    row = dataGridView1.CurrentCell.RowIndex;
                    if (dataGridView1["Cast Certificate", row].Value.Equals("Yes"))
                        f = Connection.GetDocuments(Convert.ToString(dataGridView1["Scholar No", row].Value), "CC");
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name.ToString() == "Sport")
                {
                    row = dataGridView1.CurrentCell.RowIndex;
                    if (dataGridView1["Sport", row].Value.Equals("Yes"))
                        f = Connection.GetDocuments(Convert.ToString(dataGridView1["Scholar No", row].Value), "SC");
                }
                if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.Name.ToString() == "DOB")
                {
                    row = dataGridView1.CurrentCell.RowIndex;
                    if (dataGridView1["DOB", row].Value.Equals("Yes"))
                        f = Connection.GetDocuments(Convert.ToString(dataGridView1["Scholar No", row].Value), "DOB");
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        
    }
}
