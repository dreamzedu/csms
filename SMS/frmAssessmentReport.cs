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
    public partial class frmAssessmentReport :UserControlBase
    {
        public frmAssessmentReport()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }

        private void frmAssessmentReport_Load(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbSession, "select SessionCode,SessionName from tbl_session Group by SessionCode,SessionName");
                cmbSession.SelectedValue = school.CurrentSessionCode;
                Connection.FillComboBox(cmbClass, "select ClassCode,ClassName from tbl_classmaster Group by  ClassCode,ClassName Order By ClassCode");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connection.FillComboBox(cmbScetion, "SELECT tbl_class.sectioncode, tbl_section.sectionname FROM tbl_classmaster INNER JOIN  " +
                    " tbl_class ON tbl_classmaster.classcode = tbl_class.classcode INNER JOIN tbl_section ON tbl_class.sectioncode = tbl_section.sectioncode WHERE (tbl_classmaster.classcode = '" + cmbClass.SelectedValue + "')");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        
    }
}
