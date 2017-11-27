using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS.Bus
{
    public partial class FrmDisealDetail :UserControlBase
    {
        public FrmDisealDetail()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        school1 c = new school1();
        Boolean add_edit = false;
        public static string BusNo = string.Empty;
        public static int Busid = 0;
        public static int BusEntry = 0;
        private void showGrid()
        {
            DataSet ds = Connection.GetDataSet("select BusEntry,BusNo,DieselAvailable,Pureddate PouredDate,pureddiesel PouredDiesel,BusReading,DieselRate,Amount,CurrentDate EntryDate,Status from tbl_DieselDetails");
            dgv1.DataSource = ds.Tables[0];
            DataSet dss = Connection.GetDataSet("select Busno from tbl_BusDetails");
            cmbBusNo.DataSource = dss.Tables[0];
            cmbBusNo.DisplayMember = "BusNo";
            txtDieselAvailable.Text = "";
            txtBusReading.Text = "0.0";
            txtPuredDiesel.Text = "0.0";
            txtDieselRate.Text = "0.0";
            txtAmount.Text = "0.0";
            DTP1.Text = DateTime.Now.ToString();
            DTPCurrent.Text = DateTime.Now.ToString();


        }
        private void CalCulation()
        {
            double puredDiesel = Convert.ToDouble(txtPuredDiesel.Text);
            double DieselRate = Convert.ToDouble(txtDieselRate.Text);
            double Amount = Convert.ToDouble(puredDiesel * DieselRate);
            txtAmount.Text = Amount.ToString();
        }
        public override void btnnew_Click(object sender, EventArgs e)
        {
            try
            {

                add_edit = true;
                c.GetMdiParent(this).DisableAllEditMenuButtons();
                cmbBusNo.Focus();
                c.cleartext(this);
                DesignForm.fromDesign2(this);
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {
            
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            DesignForm.fromDesign2(this);
            dgv1.Focus();
            dgv1.Enabled = true;
            c.GetMdiParent(this).ToggleDeleteButton(true);
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {
            if (add_edit == false)
            {
                 DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record.", "", MessageBoxButtons.YesNo);
                 if (d.ToString() == "Yes")
                 {
                     Connection.AllPerform("delete  from tbl_DieselDetails where BusEntry='" + BusEntry + "'");
                     c.cleartext(this);
                     BusEntry = 0;
                     showGrid();
                 }
            }
        }
        int count = 0;
        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (cmbBusNo.Text == "" || txtAmount.Text == "" || txtBusReading.Text == "" || txtDieselAvailable.Text == "" || txtDieselRate.Text == "" || txtPuredDiesel.Text == "" || DTP1.Text == "" || DTPCurrent.Text == "")
            { MessageBox.Show("Please Fill Above Information Properly"); }
            else
            {

                if (add_edit == true)
                {
                    DataSet ds = Connection.GetDataSet("select count(*) from tbl_DieselDetails where BusNo='" + cmbBusNo.Text + "' and PuredDate='" + DTP1.Value.ToString("MM/dd/yyyy") + "'");
                    count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (count == 0)
                    {
                        Connection.AllPerform("insert into tbl_DieselDetails values('" + cmbBusNo.Text + "','" + txtDieselAvailable.Text + "','" + DTP1.Value.ToString("MM/dd/yyyy") + "','" + txtPuredDiesel.Text + "','" + txtBusReading.Text + "','" + txtDieselRate.Text + "','" + txtAmount.Text + "','" + DTPCurrent.Value.ToString("MM/dd/yyyy") + "','1')");
                        MessageBox.Show("Record Saved...", "School");

                        showGrid();
                        cmbBusNo.Focus();
                        dgv1.Enabled = false;
                        c.GetMdiParent(this).EnableAllEditMenuButtons();
                        
                        DesignForm.fromDesign1(this);
                    }
                    else { MessageBox.Show("Today's Entry Of This Bus had Done"); }
                }
                if (add_edit == false)
                {
                    Connection.AllPerform("update tbl_DieselDetails set BusNo='" + cmbBusNo.Text + "',DieselAvailable='" + txtDieselAvailable.Text + "',PuredDate='" + DTP1.Value.ToString("MM/dd/yyyy") + "',PuredDiesel='" + txtPuredDiesel.Text + "',BusReading='" + txtBusReading.Text + "',DieselRate='" + txtDieselRate.Text + "',Amount='" + txtAmount.Text + "',CurrentDate='" + DTPCurrent.Value.ToString("MM/dd/yyyy") + "' where BusEntry='" + BusEntry + "' and PuredDate='" + DTP1.Value.ToString("MM/dd/yyyy") + "'");

                    MessageBox.Show("Record Update...", "School");
                    BusEntry = 0;
                    showGrid();
                    cmbBusNo.Focus();
                    dgv1.Enabled = false;
                    c.GetMdiParent(this).EnableAllEditMenuButtons();
                    
                    DesignForm.fromDesign1(this);
                }

            } 
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
            c.cleartext(this);
            BusEntry = 0;
            dgv1.Enabled = false;
            DesignForm.fromDesign1(this);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close(); 
        }

        private void FrmDisealDetail_Load(object sender, EventArgs e)
        {
            showGrid();
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
            DesignForm.fromDesign1(this);
            dgv1.Enabled = false;
        }

        private void txtPuredDiesel_TextChanged(object sender, EventArgs e)
        {
            if (txtPuredDiesel.Text == "")
            {
                txtPuredDiesel.Text = "0.0";
            }

            CalCulation();
        }

        private void txtDieselRate_TextChanged(object sender, EventArgs e)
        {
            if (txtDieselRate.Text == "")
            {
                txtDieselRate.Text = "0.0";
            }

            CalCulation();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv1.Rows.Count > 0)
                {
                    BusEntry =Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cmbBusNo.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDieselAvailable.Text = dgv1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    DTP1.Text = dgv1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtPuredDiesel.Text = dgv1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtBusReading.Text = dgv1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtDieselRate.Text = dgv1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    txtAmount.Text = dgv1.Rows[e.RowIndex].Cells[7].Value.ToString();
                }
                else { }
            }
            catch
            { }
        }

        private void FrmDisealDetail_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

    }
}

