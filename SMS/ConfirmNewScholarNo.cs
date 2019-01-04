using CSMS.DataAccess;
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
    public partial class ConfirmNewScholarNo : Form
    {
        public string scholarNo = "";
        public ConfirmNewScholarNo(string existingScholarNo)
        {
            InitializeComponent();
            lblScholarNo.Text = existingScholarNo + ": ";
        }


        private void btnAutoGenerate_Click(object sender, EventArgs e)
        {
            StudentData sd = new StudentData(Connection.GetMyConnection());
            txtScholarNo.Text = sd.AutoGenerateScholarNo();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtScholarNo.Text))
            {
                lblError.Text = "Please enter scholar no";
            }
            else{

                StudentData std = new StudentData(Connection.GetMyConnection());
                if (std.IsStudentExists(txtScholarNo.Text.Trim()))
                {
                    lblError.Text = "Scholar No already exists, please enter a new scholar no or auto generate.";
                }
                else
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.scholarNo = txtScholarNo.Text;
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfirmNewScholarNo_Load(object sender, EventArgs e)
        {
            lblSnoExists.Location = new Point(lblScholarNo.Location.X + lblScholarNo.Width + 2, lblSnoExists.Location.Y);
        }
    }
}
