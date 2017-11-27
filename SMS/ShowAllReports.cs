using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports;  

namespace SMS
{
    public partial class ShowAllReports : Form
    {
        public ShowAllReports()
        {
            InitializeComponent();    DesignForm.fromDesign1(this);
        }

        private void crystalReportViewer1_Error(object source, CrystalDecisions.Windows.Forms.ExceptionEventArgs e)
        {
            try
            {
            }
            catch(Exception ex){Logger.LogError(ex); }
        }
    }
}
