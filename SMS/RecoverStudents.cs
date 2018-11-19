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
                IList<string> selectedScholarNos = new List<string>();

                foreach (DataGridViewRow row in grdvStudents.Rows)
                {
                    if (row.Cells[0] is DataGridViewCheckBoxCell)
                    {
                        Boolean isSelected = Convert.ToBoolean(((DataGridViewCheckBoxCell)row.Cells[0]).Value);
                        if (isSelected)
                        {
                            selectedScholarNos.Add(row.Cells[2].Value.ToString());
                        }
                    }
                }

                if (selectedScholarNos.Count > 0)
                {
                    StudentData std = new StudentData(Connection.GetMyConnection());
                    List<string> unrecoveredScholarNos = new List<string>();

                    foreach (var scholarNo in selectedScholarNos)
                    {
                        try
                        {
                            if (std.IsStudentExists(scholarNo))
                            {
                                ConfirmNewScholarNo cnsn = new ConfirmNewScholarNo();
                                if (cnsn.ShowDialog() == DialogResult.OK)
                                {
                                    std.RecoverStudent(scholarNo, cnsn.scholarNo);
                                }
                                else
                                {
                                    unrecoveredScholarNos.Add(scholarNo);
                                }
                            }
                            else
                            {
                                std.RecoverStudent(scholarNo, null);
                            }
                        }
                        catch(Exception ex)
                        {
                            Logger.LogError(ex);
                            unrecoveredScholarNos.Add(scholarNo);
                        }
                    }
                                        
                    LoadBackupStudents();

                    if(unrecoveredScholarNos.Count == 0)
                    {
                        MessageBox.Show("Recovered deleted students successfully.");                     
                    }
                    else if(selectedScholarNos.Count == unrecoveredScholarNos.Count)
                    {
                        MessageBox.Show("Could not recover any student.");
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
