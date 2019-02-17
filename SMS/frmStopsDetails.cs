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
            try
            {
                if (dgv1.RowCount > 0)
                {
                    if (DialogResult.Yes.Equals(MessageBox.Show("Are you sure to save Stop detail.", "Stop Details", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                    {
                        dtStopDetail.EndInit();
                        dgv1.EndEdit();
                        string sql = "";

                        foreach (DataRow row in dtStopDetail.Rows)
                        {
                            sql += "UPDATE [tbl_StopDetails] SET [Status] = " + (row["Available"].ToString().ToLower() == "yes"? 1: 0) + ", [BusStopNo] = '" + row["BusStopNo"] + "', [StopName] = '" + row["StopName"] + "', [StopFee] = " + row["Fee"] + " WHERE [BStopId] = " + row["BStopId"] + ";";
                        }

                        if (!string.IsNullOrEmpty(sql))
                        {
                            SqlCommand cmd = new SqlCommand(sql, Connection.GetMyConnection());
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Record saved successfully.", "Stop Detail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Some error occurred while saving the records. Please verify the input data and the internet connection.");
            }
        }

        private void frmStopsDetails_Load(object sender, EventArgs e)
        {
            //this.KeyPreview = true;
            DataAdapter = new SqlDataAdapter("Select BStopId, BusStopNo, StopName , StopFee as Fee, Case When Status=1 Then 'Yes' Else 'No' End as Available From tbl_StopDetails  Order By BusStopNo", Connection.Conn());
            DataAdapter.Fill(dtStopDetail);
            dgv1.DataSource = dtStopDetail;
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
            dtStopDetail.Rows[dtStopDetail.Rows.Count - 1]["Available"] = "Yes";
            dtStopDetail.Rows[dtStopDetail.Rows.Count - 1]["BusStopNo"] = "S-" + dtStopDetail.Rows.Count;
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
                    }
                    catch
                    {
                        dgv1.Rows[e.RowIndex].Cells["Fee"].Value = 0;
                    }
                }
                else if (dgv1.CurrentCell.ColumnIndex.Equals(dgv1.Rows[e.RowIndex].Cells["StopName"].ColumnIndex))
                {
                    try
                    {
                        dgv1.Rows[e.RowIndex].Cells["StopName"].Value = school.toproper(dgv1.Rows[e.RowIndex].Cells["StopName"].Value.ToString());
                    }
                    catch
                    {
                        dgv1.Rows[e.RowIndex].Cells["StopName"].Value = "";
                    }
                }
            }
        }

        private void frmStopsDetails_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}

