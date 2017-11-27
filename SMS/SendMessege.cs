using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using SMSClientLib;
using System.Net;

namespace SMS
{
    public partial class SendMessege :UserControlBase
    {
        Boolean MessageService = false;
        school1 c = new school1();
        SqlDataReader DataReader = null ;
        SqlTransaction trn = null; 
        public SendMessege()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void SendMessege_Load(object sender, EventArgs e)
        {
            this.MessageService = Convert.ToBoolean(Connection.GetExecuteScalar("Select MessageService From tbl_School"));
            if (this.MessageService)
            {
                Connection.FillDropList(ref cmbclass, "Select ClassName,ClassCode From tbl_ClassMaster Order By ClassCode");
                Connection.FillComboBox(cmbSession, " select sessioncode,sessionname from tbl_session order by sessioncode ");
                cmbSession.SelectedValue = school.CurrentSessionCode;
                //30-March By Gtl Message Service Active/Deactive
                this.MessageService = Convert.ToBoolean(Connection.GetExecuteScalar("Select MessageService From tbl_School"));
                if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {

                }
                else
                {
                    MessageBox.Show("There Are Not Connection For Interner/Network Connection...\n\tPlease Check Internet Connection. ", "Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("You Are Not Authorised For Message Service...\n\tPlease Check Your Message Service. ", "Message Service", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void cmbclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            chkSelectAll.Checked = false;
            DataReader = Connection.GetDataReader("SELECT tbl_student.studentno as [Student No], tbl_student.scholarno as [Scholar No.], tbl_student.name as [Name]" +
                " , tbl_student.father as [Father], tbl_student.mother as [Mother], tbl_student.phone as [Mobile No.] "+
                " FROM tbl_classstudent INNER JOIN tbl_student ON tbl_classstudent.studentno = tbl_student.studentno INNER JOIN "+
                " tbl_classmaster ON tbl_classstudent.classno = tbl_classmaster.classcode where tbl_classmaster.classname='" + cmbclass.Text + "' "+
                " and tbl_classstudent.sessioncode='" + school.CurrentSessionCode + "' and (tbl_classstudent.stdtype<>'Ex-Student' or tbl_classstudent.stdtype<>'Terminate Student') order by tbl_student.name");
            if(DataReader.HasRows)
            {
                while(DataReader.Read())
                {
                    dataGridView1.Rows.Add(0,
                        DataReader["Student No"].ToString(),
                        DataReader["Scholar No."].ToString(),
                        DataReader["Name"].ToString(),
                        DataReader["Father"].ToString(),
                        DataReader["Mother"].ToString(),
                        DataReader["Mobile No."].ToString(),
                        "");
                }
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
           // this.Close();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            //int i = 0;
            //do
            //{
            //    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
            //    {
            //        string status = "";
            //        CookieContainer cookie = Login.Connect("9827802410", "9278", out status);
            //        string[] siteParameters = Login.GetSiteParameters(cookie);
            //        string messgeSentResult = SendSMS.Send_Processing(dataGridView1.Rows[i].Cells[5].Value.ToString(), textBox1.Text, cookie, siteParameters);
            //        // Connection.SMSSend(dataGridView1.Rows[i].Cells[5].Value.ToString (), textBox1.Text);
            //    }
            //    i++;
            //}
            //while (i <= dataGridView1.Rows.Count - 1);

            if(dataGridView1.RowCount > 0)
            {
                if (string.IsNullOrEmpty(txtMessage.Text.Trim()))
                {
                    MessageBox.Show("Please Check Message...");
                    txtMessage.Focus();
                }
                else
                {
                    if (DialogResult.Yes.Equals(MessageBox.Show("Are You Sure To Send This Text Message...", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                    {
                        //Short Messaging Services
                        #region "Messaging Services"
                        if (this.MessageService)
                        {
                            int ID = Convert.ToInt32(Connection.GetExecuteScalar("SELECT ISNULL(MAX(ID), 1) FROM tbl_MessageDetail"));
                            foreach (DataGridViewRow r in dataGridView1.Rows)
                            {
                                r.Cells["Status"].Value = "Pending";
                                r.Cells["Status"].Style.Font = new Font("Verdhana", 9F, FontStyle.Bold);
                                r.Cells["Status"].Style.ForeColor = Color.Gray;
                            }
                            trn = Connection.GetMyConnection().BeginTransaction();

                            try
                            {
                                foreach (DataGridViewRow r in dataGridView1.Rows)
                                {
                                    if (Convert.ToBoolean(r.Cells["Select"].Value))
                                    {
                                        if (!string.IsNullOrEmpty(r.Cells["MobileNo"].Value.ToString()))
                                        {
                                            Connection.SendSMS(r.Cells["MobileNo"].Value.ToString(), txtMessage.Text.Trim());
                                            r.Cells["Status"].Value = "Success";
                                            r.Cells["Status"].Style.ForeColor = Color.Green;
                                        }
                                        else
                                        {
                                            r.Cells["Status"].Value = "Not Success";
                                            r.Cells["Status"].Style.ForeColor = Color.Red;
                                        }
                                        Connection.SqlTransection("Insert InTo tbl_MessageDetail (ID, SessionCode, StudentNo, Message, Status, Date ) Values('" + ID++ + "'" +
                                         " ,'" + school.CurrentSessionCode + "', '" + r.Cells["StudentNo"].Value + "', N'" + txtMessage.Text.Trim().Replace("'", "''") + "'" +
                                         " ,'" + r.Cells["Status"].Value + "', '" + DateTime.Now + "')", Connection.MyConnection, trn);
                                    }
                                }
                                MessageBox.Show("Massage Sent Successfully", "Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                trn.Commit();
                            }
                            catch
                            {
                                trn.Rollback();
                            }
                        }
                    }
                        #endregion
                }
            }
            else
            {
                MessageBox.Show("Message can not send...", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void chkSelectAll_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelectAll.Checked == true)
                {
                    foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                    {
                        dgvr.Cells[0].Value = true;
                    }
                }
                else
                {
                    foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                    {
                        dgvr.Cells[0].Value = false;
                    }
                }
            }
            catch(Exception ex){Logger.LogError(ex); }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(), dataGridView1.Font, new SolidBrush(Color.Maroon), e.RowBounds.X + 3, e.RowBounds.Y + 5);
        } 

        private void btnMessageDetail_Click(object sender, EventArgs e)
        {
            gbxMessageDetail.Visible = true;
            cmbSession.Focus();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Groups.Clear();
            listView1.View = View.Details;
            listView1.Columns.Add("Scholar No.", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Name", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Father", 115, HorizontalAlignment.Left );
            listView1.Columns.Add("Mobile No.", 80, HorizontalAlignment.Center);
            listView1.Columns.Add("Class", 40, HorizontalAlignment.Center);
            listView1.Columns.Add("Message No.", 50, HorizontalAlignment.Right);
            listView1.Columns.Add("Message", 200, HorizontalAlignment.Center);
            listView1.Columns.Add("Message Status", 60, HorizontalAlignment.Center);
            listView1.Columns.Add("Message Sending Time", 100, HorizontalAlignment.Center);
            int Group = 0;

            DataReader = Connection.GetDataReader(" SELECT tbl_student.scholarno AS [Scholar No.], tbl_student.name AS Name, tbl_student.father AS Father " +
            " , tbl_student.phone AS [Mobile No], tbl_classmaster.classname + '-' + tbl_section.sectionname AS Class, tbl_MessageDetail.ID as [Message No.] " +
            " , tbl_MessageDetail.Message, tbl_MessageDetail.Status AS [Message Status], Convert(Varchar,tbl_MessageDetail.Date,6) AS [Message Sending Time]   " +
            "   FROM tbl_MessageDetail INNER JOIN tbl_student ON tbl_MessageDetail.StudentNo = tbl_student.studentno INNER JOIN tbl_classmaster INNER JOIN " +
            "   tbl_classstudent ON tbl_classmaster.classcode = tbl_classstudent.classno INNER JOIN tbl_section ON tbl_classstudent.Section = tbl_section.sectioncode ON " +
            "   tbl_student.studentno = tbl_classstudent.studentno WHERE (tbl_classstudent.sessioncode = '" + school.CurrentSessionCode + "') AND  " +
            "  (tbl_MessageDetail.Date BETWEEN '" + dateTimePicker1.Value.Date + "' AND '" + dateTimePicker2.Value + "') ORDER BY tbl_MessageDetail.ID");
            if (DataReader.HasRows)
            {
                while (DataReader.Read())
                {
                    Group = listView1.Groups.Add(new ListViewGroup(" "));
                    ListViewItem MessageListItem = listView1.Items.Insert(Group, DataReader["Scholar No."].ToString());
                    MessageListItem.SubItems.Add(new ListViewItem.ListViewSubItem(MessageListItem, DataReader["Name"].ToString()));
                    MessageListItem.SubItems.Add(new ListViewItem.ListViewSubItem(MessageListItem, DataReader["Father"].ToString()));
                    MessageListItem.SubItems.Add(new ListViewItem.ListViewSubItem(MessageListItem, DataReader["Mobile No"].ToString()));
                    MessageListItem.SubItems.Add(new ListViewItem.ListViewSubItem(MessageListItem, DataReader["Class"].ToString()));
                    MessageListItem.SubItems.Add(new ListViewItem.ListViewSubItem(MessageListItem, DataReader["Message No."].ToString()));
                    MessageListItem.SubItems.Add(new ListViewItem.ListViewSubItem(MessageListItem, DataReader["Message"].ToString()));
                    MessageListItem.SubItems.Add(new ListViewItem.ListViewSubItem(MessageListItem, DataReader["Message Status"].ToString()));
                    MessageListItem.SubItems.Add(new ListViewItem.ListViewSubItem(MessageListItem, DataReader["Message Sending Time"].ToString()));

                    MessageListItem.Group = listView1.Groups[Group];
                    Group++;
                }
            }
            DataReader.Close();
        }

        private void btnCloseView_Click(object sender, EventArgs e)
        {
            gbxMessageDetail.Visible = false;
        }

        private void SendMessege_Paint(object sender, PaintEventArgs e)
        {
            //public static void fromClear(Form f);
        }

       
    }
}
