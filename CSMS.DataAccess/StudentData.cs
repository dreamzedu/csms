using CSMS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CSMS.DataAccess
{
    public class StudentData
    {
        private SqlConnection con;
        public StudentData(SqlConnection con)
        {
            this.con = con;
        }

        public IList<Student> GetBackupStudents(int sessionId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetBackupStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SessionId", sessionId);
                SqlDataReader reader = cmd.ExecuteReader();

                List<Student> students = new List<Student>();
                while (reader.Read())
	            {
                    students.Add(new Student(){
                        StudentNo = reader["studentno"].ToString(),
                        ScholarNo= reader["scholarno"].ToString(),
                        Class = reader["class"].ToString(),
                        DateOfAdmission = Convert.ToDateTime(reader["APPDate"]),
                        FatherName = reader["father"].ToString(),
                        Gender = reader["gender"].ToString(),
                        Name = reader["name"].ToString(),
                        Phone = reader["phone"].ToString(),
                        Section = reader["section"].ToString()
                    });
	         
                }
                return students;
            }
            catch { throw; }
        }

        public List<string> RecoverSelectedStudents(IList<string> selectedStudentNos)
        {
            List<string> unrecoveredStudents = new List<string>();
            foreach (string studentNo in selectedStudentNos)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("RecoverDeletedStudents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentNo", studentNo);
                    cmd.ExecuteNonQuery();
                }
                catch {
                    unrecoveredStudents.Add(studentNo);
                }
            }
            return unrecoveredStudents;
        }
    }
}
