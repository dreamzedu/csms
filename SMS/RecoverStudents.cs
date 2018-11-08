using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSMS.DataAccess;
using CSMS.Entities;

namespace SMS
{
    public partial class RecoverStudents : UserControlBase
    {
        public RecoverStudents()
        {
            InitializeComponent();
        }

        private void RecoverStudents_Load(object sender, EventArgs e)
        {
            LoadBackupStudents();   
        }

        private void LoadBackupStudents()
        {
            try
            {
                StudentData std = new StudentData(Connection.GetMyConnection());
                IList<Student> students = std.GetBackupStudents(school1.CurrentSessionCode);
                grdvStudents.DataSource = students;

                if (students == null || students.Count == 0)
                {
                    btnRecover.Enabled = false;
                    lblNoRecords.Text = "No records available.";
                }
                else
                {
                    lblNoRecords.Text = string.Empty;
                    btnRecover.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Unable to load deleted students.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecover_Click(object sender, EventArgs e)
        {
            try
            {
                IList<string> selectedStudentNos = new List<string>();

                foreach (DataGridViewRow row in grdvStudents.Rows)
                {
                    if (row.Cells[0] is DataGridViewCheckBoxCell)
                    {
                        Boolean isSelected = Convert.ToBoolean(((DataGridViewCheckBoxCell)row.Cells[0]).Value);
                        if (isSelected)
                        {
                            selectedStudentNos.Add(row.Cells[1].Value.ToString());
                        }
                    }
                }

                if (selectedStudentNos.Count > 0)
                {
                    StudentData std = new StudentData(Connection.GetMyConnection());
                    List<string> unrecoveredStudents = std.RecoverSelectedStudents(selectedStudentNos);

                    List<string> unrecoveredScholarNos = new List<string>();
                    if(unrecoveredStudents.Count > 0)
                    {
                        List<Student> students = (List<Student>)grdvStudents.DataSource;
                        unrecoveredScholarNos = students.Where(x => unrecoveredStudents.Contains(x.StudentNo)).Select(x => x.ScholarNo).ToList<string>();
                    }

                    LoadBackupStudents();

                    if(unrecoveredStudents.Count == 0)
                    {
                        MessageBox.Show("Recovered deleted students successfully.");                     
                    }
                    else if(selectedStudentNos.Count == unrecoveredStudents.Count)
                    {
                        MessageBox.Show("Could not revocer any student.");
                    }
                    else
                    {
                        if(unrecoveredScholarNos != null)
                            MessageBox.Show("Recovered deleted students partially. \r\nFollowing scholars could not be recovered: \r\n" + string.Join(", ", unrecoveredScholarNos.ToArray()));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Unable to recover deleted students.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
