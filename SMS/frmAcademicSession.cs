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
    public partial class frmAcademicSession : Form
    {
        int seletedCode; 
        public frmAcademicSession()
        {
            InitializeComponent();
            Connection.FillDropList(ref cmbSession, " SELECT sessionname, sessioncode  FROM tbl_session order by s_from desc ");
            cmbSession.SelectedValue = Convert.ToInt32(Connection.GetExecuteScalar("Select SessionCode From tbl_Session Where SessionStatus=1"));
            seletedCode = Convert.ToInt32(cmbSession.SelectedValue);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            school.CurrentSessionCode = Convert.ToInt32(cmbSession.SelectedValue);
            school1.CurrentSessionCode = Convert.ToInt32(cmbSession.SelectedValue);


            school.CurrentSessionName = cmbSession.Text;
            school1.CurrentSessionName = cmbSession.Text;
                        
            this.Close();

            if(chkSetSession.Checked && seletedCode != school.CurrentSessionCode)
            {
                Connection.ExecuteNonQuery("update tbl_Session set SessionStatus=0", Connection.GetMyConnection());
                Connection.ExecuteNonQuery("update tbl_Session set SessionStatus=1 where SessionCode=" + school.CurrentSessionCode, Connection.GetMyConnection());
                
            }
        }
    }
}
