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

        public List<string> RecoverSelectedStudents(IList<string> selectedScholarNos)
        {
            List<string> unrecoveredStudents = new List<string>();
            foreach (string scholarNo in selectedScholarNos)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("RecoverDeletedStudents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OldScholarNo", scholarNo);
                    cmd.Parameters.AddWithValue("@NewScholarNo", null);
                    cmd.ExecuteNonQuery();
                }
                catch {
                    unrecoveredStudents.Add(scholarNo);
                }
            }
            return unrecoveredStudents;
        }

        public void RecoverStudent(string oldScholarNo, string newScholarNo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("RecoverDeletedStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OldScholarNo", oldScholarNo);
                if (newScholarNo != null)
                {
                    cmd.Parameters.AddWithValue("@NewScholarNo", newScholarNo);
                }
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
        }

        public bool IsStudentExists(string scholarNo)
        {
            bool isExists = false;
            try
            {
                SqlCommand cmd = new SqlCommand("select scholarNo from tbl_student where scholarNo="+scholarNo, con);
                
                //cmd.Parameters.AddWithValue("@scholarNo", scholarNo);
                object val = cmd.ExecuteScalar();

                if (val != null && val != DBNull.Value)
                    isExists = true;
            }
            catch
            {
                throw;
            }
            return isExists;
        }

        public string AutoGenerateScholarNo()
        {
            string scholarNo = "101";
            try
            {
                SqlCommand cmd = new SqlCommand("select max(scholarNo) from tbl_student", con);
                object val = cmd.ExecuteScalar();

                if (val != DBNull.Value)
                    scholarNo = (Convert.ToInt64(val) + 1).ToString();
            }
            catch
            {
                throw;
            }
            return scholarNo;
        
        }

    }
}
