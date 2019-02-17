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
    public partial class FrmDailyBusEntry :UserControlBase
    {
        public FrmDailyBusEntry()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        school1 c = new school1();
        Boolean add_edit = false;
        public static string BusNo = string.Empty;
        public static int Busid = 0;
        int EntryNo;
        int DriverId;

        private void calC()
        {
            DataSet ds = Connection.GetDataSet("select BusMilej from tbl_BusDetails where BusNo='" + cmbBusNo.Text + "'");
            if (txtArrivalReading.Text.Trim() == string.Empty)
                txtArrivalReading.Text = "0.0";
            if (txtArrivalReading.Text.Trim() == string.Empty)
                txtDepartureReading.Text = "0.0";
            double AR = Convert.ToDouble(txtArrivalReading.Text);
            double DR = Convert.ToDouble(txtDepartureReading.Text);
            double ML = Convert.ToDouble(ds.Tables[0].Rows[0][0]);
            double LF = (AR - DR) / ML;
            txtLostFuel.Text = LF.ToString();
        }
        private void ShowData()
        {
            cmbShift.Items.Clear();
            cmbShift.Text = "Morning";
            cmbShift.Items.Add("Evening");
            cmbShift.Items.Add("Morning");
            cmbBusNo.DataSource = null;
            cmbBusNo.Items.Clear();
            DataSet ds = Connection.GetDataSet("select Busno from tbl_BusDetails ");
            DataSet dss = Connection.GetDataSet("select EntryNo,Shift,Rounds,BusNo,RootName RouteName,DepartureReading,ArrivalReading,DriverName,ConductorName,TeacherName,sdt DepartureTime,sat ArrivalTime,LostFuel,CurrentDate EntryDate,Status from tbl_DailyBusEntry ");
            dgv1.DataSource = dss.Tables[0];
            dgv1.Columns[4].Visible = false;
            cmbBusNo.DataSource = ds.Tables[0];
            cmbBusNo.DisplayMember = "Busno";
            cmbRounds.Items.Clear();
            cmbRounds.Text = "1";
            cmbRounds.Items.Add("1");
            cmbRounds.Items.Add("2");
            cmbRounds.Items.Add("3");
            txtArrivalReading.Text = "0.0";
            txtDepartureReading.Text = "0.0";
            txtLostFuel.Text = "0.0";
            DTP1.Text = DateTime.Now.ToString();
            DTPSDT.Text = DateTime.Now.ToString("T");
            DTPSAT.Text = DateTime.Now.ToString("T");
        }

        public override void btnnew_Click(object sender, EventArgs e)
        {
            try
            {
                add_edit = true;
                c.cleartext(this);
                c.GetMdiParent(this).DisableAllEditMenuButtons();
                DesignForm.fromDesign2(this);
            }
            catch (Exception ex) { Logger.LogError(ex); MessageBox.Show(ex.Message); }
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
                     Connection.AllPerform("delete from tbl_DailyBusEntry where BUSNO='" + cmbBusNo.Text + "' and EntryNo='" + EntryNo + "'");
                     ShowData();
                     c.cleartext(this);
                 }
            }
        }
        int count = 0;
        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (cmbShift.Text == "" || cmbBusNo.Text == "" || cmbDriverName.Text == "" || cmbRounds.Text == "" || txtArrivalReading.Text == "" || txtDepartureReading.Text == "" || DTPSAT.Text == "" || DTPSDT.Text == "" || DTP1.Text == "")
            {
                MessageBox.Show("Please fill all the details.");
            }
            else
            {
                if (add_edit == true)
                {
                    DataSet ds = Connection.GetDataSet("select count(*)  from tbl_DailyBusEntry where Shift='" + cmbShift.Text + "' and BusNo='" + cmbBusNo.Text + "'and Rounds='" + cmbRounds.Text + "' and CurrentDate='" + DTP1.Value.ToString("MM/dd/yyyy") + "'");
                    
                    count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    ds = new DataSet();
                    ds = Connection.GetDataSet("select isnull(max(EntryNo),0)+1  from tbl_DailyBusEntry ");
                    EntryNo = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                    if (count == 0)
                    {
                        Connection.AllPerform("insert into tbl_DailyBusEntry(Shift,Rounds,BusNo,RootName,"
                            +"DepartureReading,ArrivalReading,DriverName,ConductorName,TeacherName,SDT,"
                            + "SAT,LostFuel,CurrentDate,Status) values('" + cmbShift.Text + "','" 
                            + cmbRounds.Text + "','" + cmbBusNo.Text + "','0','" + txtDepartureReading.Text + "','" 
                            + txtArrivalReading.Text + "','" + cmbDriverName.Text + "','" + cmbConductorName.Text + "','" 
                            + cmbTeacherName.Text + "','" + DTPSDT.Text + "','" + DTPSAT.Text + "','" 
                            + txtLostFuel.Text + "','" + DTP1.Value.ToString("MM/dd/yyyy") + "','1')");


                        MessageBox.Show("Record Saved.");
                        ShowData();
                    }
                    else { MessageBox.Show("This Entry Exist"); }
                }
                if (add_edit == false)
                {
                    Connection.AllPerform("update tbl_DailyBusEntry set Shift='" + cmbShift.Text + "',Rounds='" + cmbRounds.Text + "', BusNo='" + cmbBusNo.Text + "',DepartureReading='" + txtDepartureReading.Text + "',ArrivalReading='" + txtArrivalReading.Text + "',DriverName='" + cmbDriverName.Text + "',ConductorName='" + cmbConductorName.Text + "',TeacherName='" + cmbTeacherName.Text + "',SDT='" + DTPSDT.Text + "',SAT='" + DTPSAT.Text + "',LostFuel='" + txtLostFuel.Text + "',CurrentDate='" + DTP1.Value.ToString("MM/dd/yyyy") + "' where BusNo='" + cmbBusNo.Text + "' and EntryNo='" + EntryNo + "'");
                    MessageBox.Show("Record Saved.");
                    ShowData();
                    dgv1.Enabled = false;
                }
            } cmbShift.Focus();
           

        }

        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv1.Rows.Count > 0)
                {
                    EntryNo = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    cmbShift.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cmbRounds.Text = dgv1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cmbBusNo.Text = dgv1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtDepartureReading.Text = dgv1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtArrivalReading.Text = dgv1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    cmbDriverName.Text = dgv1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    cmbConductorName.Text = dgv1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    cmbTeacherName.Text = dgv1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    DTPSDT.Text = dgv1.Rows[e.RowIndex].Cells[10].Value.ToString();
                    DTPSAT.Text = dgv1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    txtLostFuel.Text = dgv1.Rows[e.RowIndex].Cells[12].Value.ToString();
                    DTP1.Text = dgv1.Rows[e.RowIndex].Cells[13].Value.ToString();
                }
                else { }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void FrmDailyBusEntry_Load(object sender, EventArgs e)
        {
            try
            {
                ShowData();
                // DataSet ds2 = Connection.GetDataSet("select EmpTypeId from tbl_EmployeeType where Detail='Teacher'");
                DataSet ds3 = Connection.GetDataSet("select EmpName from tbl_EmployeeInfo where designation='Driver'  select EmpName from tbl_EmployeeInfo where designation='Conductor'  select EmpName from tbl_EmployeeInfo where EmpTypeId='1001' ");
                cmbDriverName.DataSource = ds3.Tables[0];
                cmbDriverName.DisplayMember = "EmpName";
                cmbConductorName.DataSource = ds3.Tables[1];
                cmbConductorName.DisplayMember = "EmpName";
                cmbTeacherName.DataSource = ds3.Tables[2];
                cmbTeacherName.DisplayMember = "EmpName";
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
                dgv1.Enabled = false;
                DesignForm.fromDesign1(this);

            }
            catch(Exception ex){Logger.LogError(ex); }
        }


        private void txtArrivalReading_TextChanged(object sender, EventArgs e)
        {
            if (txtArrivalReading.Text == string.Empty)
            { txtArrivalReading.Text = "0.0"; }
            calC();
        }

        private void txtDepartureReading_TextChanged(object sender, EventArgs e)
        {
            if (txtDepartureReading.Text == string.Empty)
            { txtDepartureReading.Text = "0.0"; }
            calC();
        }

        private void FrmDailyBusEntry_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }
        
    }
}

