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
    public partial class frmScholarshipStatus :UserControlBase
    {
        school1 c1 = new school1();
        public frmScholarshipStatus()
        {
            InitializeComponent(); Connection.SetUserControlTheme(this);
        }
        public void FillGrid()
        {
            DataTable dt = clsClassStudent.GetData();
            DataView dv = dt.DefaultView;//dsDetail.Tables[0].DefaultView;
            if (chkClassWise.Checked == false && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Section='"+cmbSection.SelectedValue.ToString()+"'";
            }
            else if (chkClassWise.Checked == true && chkSection.Checked == false)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and classno='"+cmbClass.SelectedValue.ToString()+"'";
            }
            else if (chkClassWise.Checked == true && chkSection.Checked == true)
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "' and Section='" + cmbSection.SelectedValue.ToString() + "' and classno='" + cmbClass.SelectedValue.ToString() + "'";
            }
            else
            {
                dv.RowFilter = "sessioncode='" + cmbSession.SelectedValue.ToString() + "'";
            }
           
            if (dv.Table.Rows.Count > 0)
            {
                dgvScholarDetails.DataSource = dv;
            }
        }
        private void frmScholarshipStatus_Load(object sender, EventArgs e)
        {
            itId = FLAG = 0;
            Connection.FillComboBox(cmbSession, " select sessioncode,sessionname from tbl_session order by sessioncode ");
            Connection.FillComboBox(cmbClass, " select classcode,classname from tbl_classmaster order by classcode ");
            cmbSession.SelectedValue = school.CurrentSessionCode;
            FillGrid();
            c1.GetMdiParent(this).ToggleSaveButton(true);
            c1.GetMdiParent(this).ToggleCancelButton(true);
        }

        private void cmbClass_Leave(object sender, EventArgs e)
        {
            Connection.FillComboBox(cmbSection, " SELECT tbl_section.sectioncode, tbl_section.sectionname FROM " +
            " tbl_classstudent INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode " +
            " WHERE (tbl_classstudent.classno = '" + cmbClass.SelectedValue + "') And  (tbl_classstudent.sessioncode = " +
            " '" + cmbSession.SelectedValue + "') GROUP BY tbl_section.sectioncode, tbl_section.sectionname " +
            " Order by tbl_section.sectioncode");

        }

        private void dgvScholarDetails_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvScholarDetails.Columns["studentno"].Visible = false;
                dgvScholarDetails.Columns["classno"].Visible = false;
                dgvScholarDetails.Columns["Section"].Visible = false;
                dgvScholarDetails.Columns["sessioncode"].Visible = false;
                dgvScholarDetails.Columns["sessionname"].Visible = false;
                dgvScholarDetails.DefaultCellStyle.ForeColor = Color.Black;
                dgvScholarDetails.DefaultCellStyle.BackColor = Color.White;
                
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void chkClassWise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClassWise.Checked)
            {
                cmbClass.Enabled = true;
                cmbClass.Focus();
                FillGrid();
            }
            else
            {
                cmbClass.Enabled = false;
                FillGrid();
            }
        }

        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection.Checked)
            {
                cmbSection.Enabled = true;
                cmbSection.Focus();
                FillGrid();
            }
            else
            {
                cmbSection.Enabled = false;
                FillGrid();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        public void ResetControl()
        {
            txtAppNo.Text = string.Empty;
            chkReceive.Checked = false;
            chkSanction.Checked = false;
            lblScholar.Text = "0";
        }
        public override void btnsave_Click(object sender, EventArgs e)
        {
            int f = 0;
            if (itId > 0)
            {
                f = clsClassStudent.Update(Convert.ToInt16(cmbSession.SelectedValue.ToString()), itId, txtAppNo.Text.Trim(), (chkSanction.Checked == true) ? 1 : 0, (chkReceive.Checked == true) ? 1 : 0);
                if (f > 0)
                    MessageBox.Show("!!! Record Save Successfully.");
                FillGrid();
                ResetControl();
                itId = FLAG = 0;
            }
            else
                MessageBox.Show("!! Select Student.");
        }

        private void frmScholarshipStatus_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
        static int itId = 0,FLAG=0;
        private void dgvScholarDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                
                    int row = 0;
                    row = dgvScholarDetails.CurrentCell.RowIndex;
                    itId = Convert.ToInt16(dgvScholarDetails["studentno", row].Value);
                    lblScholar.Text = Convert.ToString(dgvScholarDetails["Scholar No", row].Value);
                    txtAppNo.Text = Convert.ToString(dgvScholarDetails["Application No", row].Value);
                    chkSanction.Checked = (Convert.ToString(dgvScholarDetails["Status", row].Value) == "SANCTION") ? true : false;
                    chkReceive.Checked = (Convert.ToString(dgvScholarDetails["Distri. Status", row].Value) == "RECEIVE") ? true : false; 

                    //dgvScholarDetails.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Blue;
                    //dgvScholarDetails.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.RoyalBlue;
                    //dgvScholarDetails.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
                    FLAG = 1;

            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void chkSanction_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSanction.Checked == true)
                chkSanction.Text = "SANCTION";
            else
                chkSanction.Text = "NOT SANCTION";
        }

        private void chkReceive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReceive.Checked == true)
                chkReceive.Text = "RECEIVE";
            else
                chkReceive.Text = "NOT RECEIVE";
        }

        private void cmbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void cmbSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            ResetControl();
            itId = FLAG = 0;
        }
    }
}
