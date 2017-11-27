using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SMS.Bus
{
    public partial class FrmBusDeails :UserControlBase
    {
        public FrmBusDeails()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        school1 c = new school1();
        Boolean add_edit = false;
        public static string BusNo = string.Empty;
        public static int Busid = 0;
        private void getId()
        {
            int bus = 0;
            txtBusNo.Text = string.Empty;
            DataSet ds = Connection.GetDataSet("select * from tbl_BusDetails");
            bus = Convert.ToInt32(ds.Tables[0].Rows.Count);
            string s1 = "B-" + (bus + 1);
            txtBusNo.Text = s1;

        }
        private void resetControl(UserControl f)
        {
            foreach (Control c in f.Controls)
            {
                if (c is TextBox)
                { c.Text = ""; }
                if (c is DateTimePicker)
                { c.Text = DateTime.Now.ToString(); }
            }
        }
        private void showGrid()
        {
            DataSet ds = Connection.GetDataSet("select BusNo,RTONo,SeatsCapacity,busmilej BusMileage,ModelNo,ChechisNo,InitialReading,PurchaseDate,Company,RegistrationIssueDate,RegistrationExpiryDate,Status,BusId from tbl_BusDetails");
            dgv1.DataSource = ds.Tables[0];
            dgv1.Columns["Status"].Visible = false;
            dgv1.Columns["BusId"].Visible = false;
            resetControl(this);
            getId();
            DataSet ds2 = Connection.GetDataSet("select * from tbl_BusDetails");
            if (ds2.Tables[0].Rows.Count > 0)
            {
                DataSet ds1 = Connection.GetDataSet("Select max(Busno) from tbl_BusDetails");
                string s = ds1.Tables[0].Rows[0][0].ToString();
                string s2 = s.Remove(0, 2);
                int bus = 0;
                bus = Convert.ToInt32(s2);
                string s1 = "B-" + (bus + 1);
                txtBusNo.Text = s1;
            }
        }
        private void FrmBusDeails_Load(object sender, EventArgs e)
        {
            showGrid();
            dgv1.Enabled = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
            DesignForm.fromDesign1(this);
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            try
            {

                add_edit = true;   
                txtRTONo.Focus();
                c.cleartext(this);
                getId();
                c.GetMdiParent(this).DisableAllEditMenuButtons();
                DesignForm.fromDesign2(this);
                txtBusNo.Enabled = false;
                txtRTONo.Focus();
               
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        public override void btnedit_Click(object sender, EventArgs e)
        {

            DesignForm.fromDesign2(this);
            add_edit = false;
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            dgv1.Focus();
            dgv1.Enabled = true;
            c.GetMdiParent(this).ToggleDeleteButton(true);
            DesignForm.fromDesign2(this);
            txtBusNo.Enabled = false;
        }

        public override void btndelete_Click(object sender, EventArgs e)
        {
            if (add_edit == false)
            {
                int k = Connection.Login("select count (*) from tbl_StopsOfRootsOfBus where BusNo='" + txtBusNo.Text + "'");
                int l = Connection.Login("select count (*) from tbl_DieselDetails where BusNo='" + txtBusNo.Text + "'");
                int m = Connection.Login("select count (*) from tbl_DailyBusEntry where BusNo='" + txtBusNo.Text + "'");
                if (k > 0 || l > 0 || m > 0)
                { MessageBox.Show("You Can Not Deleted BusNO:-" + txtBusNo.Text + " ,Because It Has A Refrence Of Another Palce"); }
                else
                {
                    DialogResult d = MessageBox.Show("Are You Sure You Want To Delete Record.", "", MessageBoxButtons.YesNo);
                    if (d.ToString() == "Yes")
                    {
                        Connection.AllPerform("delete  from tbl_BusDetails where BusNo='" + txtBusNo.Text + "'");
                        showGrid();
                    }
                }
            }
        }
        int count = 0;
        public override void btnsave_Click(object sender, EventArgs e)
        {
            
            if (txtRTONo.Text == "" || txtSeatsCapacity.Text == "" || txtModelNo.Text == "" || txtInitailReading.Text == "" || txtCompany.Text == "" || txtChechisNo.Text == "" || txtBusMilej.Text == "")
            {
                MessageBox.Show("Please Fill Above Information Properly");
            }
            else
            {
               if (add_edit == true)
                {
                    count = 0;
                    DataSet ds = Connection.GetDataSet("select count(*) from tbl_BusDetails where BusNo='" + txtBusNo.Text + "'");
                    count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (count == 0)
                    {
                        Connection.AllPerform("insert into tbl_BusDetails values('" + txtBusNo.Text + "','" + txtRTONo.Text + "','" + txtSeatsCapacity.Text + "','" + txtBusMilej.Text + "','" + txtModelNo.Text + "','" + txtChechisNo.Text + "'," + txtInitailReading.Text + ",'" + DTP1.Value.ToString("MM/dd/yyyy") + "','" + txtCompany.Text + "','" + dtpRegIssueDate.Value.Date.ToString("MM-dd-yyyy") + "','" + dtpRegExpiryDate.Value.Date.ToString("MM-dd-yyyy") + "','1')");
                        MessageBox.Show("Record Saved.", "School");

                        showGrid();
                        txtRTONo.Focus();
                        dgv1.Enabled = false;
                        c.GetMdiParent(this).EnableAllEditMenuButtons();
                        
                    }
                    else { MessageBox.Show("This Bus No is Already Exist"); }
                }
                if (add_edit == false)
                {
                    if (BusNo.Trim() == txtBusNo.Text.Trim())
                    {
                        Connection.AllPerform("update tbl_BusDetails set BusNo='" + txtBusNo.Text + "',RTONO='" + txtRTONo.Text + "',SeatsCapacity='" + txtSeatsCapacity.Text + "',BusMilej='" + txtBusMilej.Text + "',ModelNo='" + txtModelNo.Text + "',ChechisNo='" + txtChechisNo.Text + "',InitialReading='" + txtInitailReading.Text + "',PurchaseDate='" + DTP1.Value.ToString("MM/dd/yyyy") + "',Company='" + txtCompany.Text + "',RegistrationIssueDate='" + dtpRegIssueDate.Value.Date.ToString("MM-dd-yyyy") + "',RegistrationExpiryDate='" + dtpRegExpiryDate.Value.Date.ToString("MM-dd-yyyy") + "' where BusId='" + Busid + "'");
                        MessageBox.Show("Record Update.", "School");
                        showGrid();
                        c.GetMdiParent(this).EnableAllEditMenuButtons();
                        
                        dgv1.Enabled = false;
                    }
                    else
                    {
                        count = 0;
                        DataSet ds = Connection.GetDataSet("select count(*) from tbl_BusDetails where BusNo='" + txtBusNo.Text + "'");
                        count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        if (count == 0)
                        {
                            Connection.AllPerform("update tbl_BusDetails set BusNo='" + txtBusNo.Text + "',RTONO='" + txtRTONo.Text + "',SeatsCapacity='" + txtSeatsCapacity.Text + "',BusMilej='" + txtBusMilej.Text + "',ModelNo='" + txtModelNo.Text + "',ChechisNo='" + txtChechisNo.Text + "',InitialReading='" + txtInitailReading.Text + "',PurchaseDate='" + DTP1.Value.ToString("MM/dd/yyyy") + "',Company='" + txtCompany.Text + "',RegistrationIssueDate='" + dtpRegIssueDate.Value.Date.ToString("MM-dd-yyyy") + "',RegistrationExpiryDate='" + dtpRegExpiryDate.Value.Date.ToString("MM-dd-yyyy") + "' where BusId='" + Busid + "'");
                            MessageBox.Show("Record Update.", "School");
                            showGrid();
                            dgv1.Enabled = false;
                            c.GetMdiParent(this).EnableAllEditMenuButtons();
                            
                        }
                        else { MessageBox.Show("This Bus No is Already Exist"); }
                    }
                }
            }
        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            DesignForm.fromDesign1(this);
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
            
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            //this.Close(); 
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv1.Rows.Count > 0)
                {


                    BusNo= txtBusNo.Text = dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtRTONo.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtSeatsCapacity.Text = dgv1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtBusMilej.Text = dgv1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtModelNo.Text = dgv1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtChechisNo.Text = dgv1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtInitailReading.Text = dgv1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    DTP1.Text = dgv1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    txtCompany.Text = dgv1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    dtpRegIssueDate.Text = dgv1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    dtpRegExpiryDate.Text = dgv1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    Busid =Convert.ToInt16(dgv1.Rows[e.RowIndex].Cells[12].Value.ToString());

                }
                else { }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void txtSeatsCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Numeric Value");
            }
        }

        private void txtBusMilej_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Numeric Value");
            }
        }

        private void txtInitailReading_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 'a' && e.KeyChar <= 'z')
            {
                e.Handled = true;
                MessageBox.Show("Enter Only Numeric Value");
            }
        }

        private void FrmBusDeails_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
    }
}


