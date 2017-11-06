using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmStopsDetails :UserControlBase
    {
        SqlDataAdapter DataAdapter = null;
        DataTable dtStopDetail = new DataTable("dtStopDetail");
        school1 c1 = new school1();
        public frmStopsDetails()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (dgv1.RowCount > 0)
            {
                if (DialogResult.Yes.Equals(MessageBox.Show("Are you sure to save Stop detail.", "Stop Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                {
                    dtStopDetail.EndInit();
                    dgv1.EndEdit();
                    DataAdapter.UpdateCommand = new SqlCommandBuilder(DataAdapter).GetUpdateCommand();
                    DataAdapter.Update(dtStopDetail);
                    MessageBox.Show("Record Saved Successfully.", "Stop Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }
            }
        }

        private void frmStopsDetails_Load(object sender, EventArgs e)
        {
            //this.KeyPreview = true;
            DataAdapter = new SqlDataAdapter("Select BStopId,Status, BusStopNo as [Stop No.], StopName as [Stop Name], StopFee as [Fee], Case When Status=1 Then 'Yes' Else 'No' End as Available From tbl_StopDetails  Order By BusStopNo", Connection.Conn());
            DataAdapter.Fill(dtStopDetail);
            dgv1.DataSource = dtStopDetail;
            dgv1.Columns["BStopId"].Visible = false;
            dgv1.Columns["Stop No."].ReadOnly = dgv1.Columns["Available"].ReadOnly = true;
            dgv1.Columns["Fee"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv1.Columns["Available"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns["Status"].Width = 50;
            dgv1.Columns["Stop No."].Width = 80;
            dgv1.Columns["Stop Name"].Width = 200;
            dgv1.Columns["Fee"].Width = 120;
            dgv1.Columns["Available"].Width = 100;
            c1.GetMdiParent(this).ToggleSaveButton(true);
            c1.GetMdiParent(this).ToggleNewButton(true);
        }       

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            dtStopDetail.Rows.Add(dtStopDetail.NewRow());
            dtStopDetail.Rows[dtStopDetail.Rows.Count - 1]["Status"] = 1;
            dtStopDetail.Rows[dtStopDetail.Rows.Count - 1]["Stop No."] = "S-" + dtStopDetail.Rows.Count;
            dtStopDetail.Rows[dtStopDetail.Rows.Count - 1]["Fee"] = 0;
        }

        private void dgv1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dgv1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != "")
            {
                if (dgv1.CurrentCell.ColumnIndex.Equals(dgv1.Rows[e.RowIndex].Cells["Fee"].ColumnIndex))
                {
                    try
                    {
                        dgv1.Rows[e.RowIndex].Cells["Fee"].Value = Convert.ToDecimal(dgv1.Rows[e.RowIndex].Cells["Fee"].Value);
                        dgv1.Rows[e.RowIndex].Cells["Available"].Value = "Yes";
                    }
                    catch
                    {
                        dgv1.Rows[e.RowIndex].Cells["Fee"].Value = 0;
                    }
                }
                else if (dgv1.CurrentCell.ColumnIndex.Equals(dgv1.Rows[e.RowIndex].Cells["Stop Name"].ColumnIndex))
                {
                    try
                    {
                        dgv1.Rows[e.RowIndex].Cells["Stop Name"].Value = school.toproper(dgv1.Rows[e.RowIndex].Cells["Stop Name"].Value.ToString());
                    }
                    catch
                    {
                        dgv1.Rows[e.RowIndex].Cells["Stop Name"].Value = "";
                    }
                }
                else if (dgv1.CurrentCell.ColumnIndex.Equals(dgv1.Rows[e.RowIndex].Cells["Status"].ColumnIndex))
                {
                    dgv1.Rows[e.RowIndex].Cells["Available"].Value = (Convert.ToBoolean(dgv1.Rows[e.RowIndex].Cells["Status"].Value)) ? "Yes" : "No";
                }
            }
        }

        private void frmStopsDetails_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}

