using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient ;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class frmUpgradeSessionCode :UserControlBase
    {
        SqlDataAdapter DataAdapter;
        SqlTransaction Transection;
        SqlDataReader DataReader;
        DataTable Session;
        string cmdText = string.Empty;
        DataSet dtApplicationSetupPath = new DataSet("dtApplicationSetupPath");
        DataSet dtApplicationSetting = new DataSet("dtApplicationSetting");

        public frmUpgradeSessionCode()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmUpgradeSessionCode_Load(object sender, EventArgs e)
        {
            //Session Registration
            #region
            Session = new DataTable("Session");
            DataAdapter = new SqlDataAdapter("Select SessionCode,SessionName as [Session] ,Convert(Varchar,s_from,105) as [From] ,Convert(Varchar,s_to,105) as [To],SessionStatus as [Current Session] From tbl_Session", Connection.Conn());
            DataAdapter.Fill(Session);
            dataGridView1.DataSource = Session;
            dataGridView1.Columns["SessionCode"].Visible = false;
            dataGridView1.Columns["Session"].ReadOnly = dataGridView1.Columns["From"].ReadOnly = dataGridView1.Columns["To"].ReadOnly = true;
            DataReader = Connection.GetDataReader("Select MessageService, MessageSenderID, MessageUserName, MessagePassword From tbl_School");
            if (DataReader.HasRows)
            {
                DataReader.Read();
                chkMessageService.Checked = Convert.ToBoolean(DataReader["MessageService"]);
                btnActiveDeactive.Text = ((chkMessageService.Checked) ? "Active" : "Deactive").ToString();
                txtSenderID.Text = Convert.ToString(DataReader["MessageSenderID"]);
                if (!(DataReader["MessageUserName"].Equals(DBNull.Value) && DataReader["MessagePassword"].Equals(DBNull.Value)))
                {
                    txtUserName.Text = CryptorEngine.Decrypt(Convert.ToString(DataReader["MessageUserName"]), true);
                    txtPassword.Text = CryptorEngine.Decrypt(Convert.ToString(DataReader["MessagePassword"]), true);
                }
                DataReader.Close();
            }
            #endregion
            //Application Path Registration
            #region
            dtApplicationSetupPath.ReadXml(Application.StartupPath + @"\AppPaths.xml");
            dtgApplicationPath.Rows.Clear();
            foreach(DataColumn c in dtApplicationSetupPath.Tables [0].Columns)
            {
                foreach(DataRow r in dtApplicationSetupPath.Tables [0].Rows)
                {
                    dtgApplicationPath.Rows.Add(c.ColumnName, r[c.ColumnName]);
                }
            }
            #endregion
            //Application Setting
            #region
            dtApplicationSetting.ReadXml(Application.StartupPath + @"\SystemSetting.xml");
            foreach (DataColumn c in dtApplicationSetting.Tables[0].Columns)
            {
                foreach (DataRow r in dtApplicationSetting.Tables[0].Rows)
                {
                    ListViewItem Item = new ListViewItem(c.ColumnName);
                    Item.Checked = Convert.ToBoolean(r[c.ColumnName].ToString());
                    listView1.Items.Add(Item);
                }
            }
            #endregion
        }
  
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(dataGridView1.Rows[e.RowIndex].Cells["Current Session"].ColumnIndex)
                && Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["Current Session"].Value))
            {
                    for (int r = 0; r < Session.Rows.Count; r++)
                    {
                        if (Convert.ToBoolean(dataGridView1.Rows[r].Cells["Current Session"].Value))
                            dataGridView1.Rows[r].Cells["Current Session"].Value = 0;
                    }
                    dataGridView1.Rows[e.RowIndex].Cells["Current Session"].Value = 1; 
            } 
        }

        private void btnUpgradeSession_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes.Equals(MessageBox.Show("Are you sure to upgrade Session.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                Session.EndInit();
                dataGridView1.EndEdit();
                DataAdapter.UpdateCommand = new SqlCommandBuilder(DataAdapter).GetUpdateCommand();
                DataAdapter.Update(Session);
                MessageBox.Show("Session upgraded successfully.\n\t\tYour application will  restarting now.", "Success", MessageBoxButtons.OK , MessageBoxIcon.Information);
                Application.Exit();
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName(Application.ProductName))
                    p.Kill();
                System.Diagnostics.Process.Start(Application.StartupPath + @"\SMS.EXE");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), dataGridView1 .Font, new SolidBrush(Color.Maroon), e.RowBounds.X + 2, e.RowBounds.Y + 3);
        }

        private void chkMessageService_CheckStateChanged(object sender, EventArgs e)
        {
            btnActiveDeactive.Text = ((chkMessageService.Checked) ? "Active" : "Deactive").ToString();
            txtSenderID.Focus();
        }

        private void btnActiveDeactive_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes.Equals(MessageBox.Show("Are You Sure To " + ((chkMessageService.Checked) ? "Active" : "Deactive").ToString() + " Message Service ...", "Message Service", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
            {
                Transection = Connection.GetMyConnection().BeginTransaction();
                try
                { 
                    cmdText = "Update tbl_School Set MessageService = '" + chkMessageService.Checked + "',MessageSenderID = '"+ txtSenderID.Text.Trim() +"' "+
                        " ,MessageUserName = '" + CryptorEngine.Encrypt(txtUserName.Text.Trim(), true) + "' ,MessagePassword = '" + CryptorEngine.Encrypt(txtPassword.Text.Trim(), true) + "' ";
                    Connection.SqlTransection(cmdText, Connection.MyConnection, Transection);
                    Transection.Commit();
                    MessageBox.Show("Congratulation!!!\n\t Message Service " + ((chkMessageService.Checked) ? "Activated" : "Deactivated").ToString() + "...", "Message Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    Transection.Rollback();
                    MessageBox.Show("Sorry!!!\n\t Message Service Has Not " + ((chkMessageService.Checked) ? "Activated" : "Deactivated").ToString() + ".\n\t\tPlease Try Again...", "Message Service ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtSenderID_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSenderID.Text))
            {
                
                    btnActiveDeactive.Focus();
                
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            
        }

        private void dtgApplicationPath_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(0))
            {
                if (DialogResult.Yes.Equals(MessageBox.Show("Are You Sure To Add Or Update \" "+dtgApplicationPath[e.ColumnIndex ,e.RowIndex].FormattedValue.ToString() +
                    " \" Path?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                {
                    OpenFileDialog op = new OpenFileDialog();
                    op.ShowDialog();
                    if (!string.IsNullOrEmpty(op.FileName))
                    {
                        dtgApplicationPath.Rows[e.RowIndex].Cells["Path"].Value = op.FileName;
                    }
                }
            }
        }

        private void btnTitle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("Please Write Title Name.", "Add Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTitle.Clear();
                txtTitle.Focus();
            }
            else
            {
                dtgApplicationPath.Rows.Add(txtTitle.Text, "");
            }
        }

        private void btnSaveApplicationPath_Click(object sender, EventArgs e)
        {
            if (dtgApplicationPath.RowCount > 0)
            {
                dtApplicationSetupPath.Tables[0].Columns.Clear();
                dtApplicationSetupPath.Tables[0].Rows.Clear();
                foreach (DataGridViewRow r in dtgApplicationPath.Rows)
                {
                    dtApplicationSetupPath.Tables[0].Columns.Add(r.Cells["Title"].Value.ToString(), typeof(System.String));
                }
                DataRow R = dtApplicationSetupPath.Tables[0].NewRow();
                    foreach (DataGridViewRow r in dtgApplicationPath.Rows)
                    {
                        R[r.Cells["Title"].Value.ToString ()] = r.Cells["Path"].Value;
                    }
                dtApplicationSetupPath.Tables[0].Rows.Add(R);
                dtApplicationSetupPath.WriteXml(Application.StartupPath + @"\AppPaths.xml");
                MessageBox.Show("Path Saved...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddSetting_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtApplicationSetting.Text))
            {
                MessageBox.Show("Please Write Title Name.", "Add Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtApplicationSetting.Focus();
            }
            else
            {
                ListViewItem Item = new ListViewItem(txtApplicationSetting.Text.Trim().Replace(" ", ""));
                Item.Checked = true;
                listView1.Items.Add(Item);
                txtApplicationSetting.Clear();
            }
        }

        private void btnApplicationSetting_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                dtApplicationSetting.Tables[0].Columns.Clear();
                dtApplicationSetting.Tables[0].Rows.Clear();
                foreach (ListViewItem i in listView1 .Items)
                {
                    dtApplicationSetting.Tables[0].Columns.Add(i.Text.Trim().Replace(" ",""));
                }
                DataRow R = dtApplicationSetting.Tables[0].NewRow();
                foreach (ListViewItem i in listView1.Items)
                {
                    R[i.Text] = i.Checked;
                }
                dtApplicationSetting.Tables[0].Rows.Add(R);
                dtApplicationSetting.WriteXml(Application.StartupPath + @"\SystemSetting.xml");
                MessageBox.Show("Saved...", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmUpgradeSessionCode_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }    
    }
}