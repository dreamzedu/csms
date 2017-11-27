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
    public partial class frmDBServer : Form
    {
        public frmDBServer()
        {
            InitializeComponent();
        }

        private void frmDBServer_Load(object sender, EventArgs e)
        {

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtCommand.Text))
            {
                if (this.txtCommand.Text.StartsWith("SELECT", true, System.Globalization.CultureInfo.CurrentCulture))
                    try
                    {
                        this.dtgResult.DataSource = Connection.GetDataTable(this.txtCommand.Text.Trim());
                    }
                    catch(Exception ex){Logger.LogError(ex); }
                else
                {
                    try
                    {
                        lblResult .Text = Connection.AllPerform(this.txtCommand.Text.Trim()).ToString ();
                    }
                    catch(Exception ex){Logger.LogError(ex); }
                }

            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
