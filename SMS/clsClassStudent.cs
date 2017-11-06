using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SMS
{
  public static  class clsClassStudent
    {
      public static int Update(int sessioncode, int studentno, string schappno, int schstatus, int schdisstatus)
      {
          int f = 0;
          SqlTransaction trn = null;
          SqlConnection conu = Connection.GetMyConnection();
          trn = conu.BeginTransaction();
          SqlCommand cmdu = new SqlCommand();
          cmdu.CommandText = "update tbl_classstudent set schappno=@schappno,schstatus=@schstatus,schdisstatus=@schdisstatus where studentno=@studentno and sessioncode=@sessioncode";
          cmdu.CommandType = CommandType.Text;
          cmdu.Connection = conu;
          cmdu.Transaction = trn;
          cmdu.Parameters.AddWithValue("@studentno", studentno);
          cmdu.Parameters.AddWithValue("@sessioncode", sessioncode);
          cmdu.Parameters.AddWithValue("@schappno", schappno);
          cmdu.Parameters.AddWithValue("@schstatus", schstatus);
          cmdu.Parameters.AddWithValue("@schdisstatus", schdisstatus);
          f = cmdu.ExecuteNonQuery();
          trn.Commit();
          conu.Close();
          return f;
      }
      public static DataTable GetData()
      {
          SqlConnection conu = Connection.Conn();
          SqlCommand cmdu = new SqlCommand();
          cmdu.CommandText = "SELECT     dbo.tbl_student.studentno,dbo.tbl_classstudent.classno,dbo.tbl_classstudent.Section, dbo.tbl_student.scholarno as [Scholar No], dbo.tbl_student.name as Name,  dbo.tbl_student.father as [Father Name], dbo.tbl_student.mother as [Mother Name], dbo.tbl_classmaster.classname as Class, dbo.tbl_section.sectionname as CSection,  dbo.tbl_classstudent.schappno as [Application No], case when   dbo.tbl_classstudent.schstatus =1 then 'SANCTION' else 'NOT SANCTION' end as Status,  case when  dbo.tbl_classstudent.schdisstatus=1 then 'RECEIVE' else 'NOT RECEIVE' end as [Distri. Status],  dbo.tbl_classstudent.sessioncode, dbo.tbl_session.sessionname  FROM         dbo.tbl_student INNER JOIN dbo.tbl_classstudent ON dbo.tbl_student.studentno = dbo.tbl_classstudent.studentno INNER JOIN dbo.tbl_classmaster ON dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode INNER JOIN  dbo.tbl_session ON dbo.tbl_classstudent.sessioncode = dbo.tbl_session.sessioncode INNER JOIN  dbo.tbl_section ON dbo.tbl_classstudent.Section = dbo.tbl_section.sectioncode where IsScholarship='True'";
          cmdu.CommandType = CommandType.Text;
          cmdu.Connection = conu;
          SqlDataAdapter da = new SqlDataAdapter(cmdu);
          DataTable dt = new DataTable();
          da.Fill(dt);
          return dt;
      }
      public static DataTable GetDataOfStudent()
      {
          SqlConnection conu = Connection.Conn();
          SqlCommand cmdu = new SqlCommand();
          cmdu.CommandText = "SELECT     studentno, name, scholarno, father, mother, phone, IsScholarship FROM         dbo.tbl_student where IsScholarship='True'";
          cmdu.CommandType = CommandType.Text;
          cmdu.Connection = conu;
          SqlDataAdapter da = new SqlDataAdapter(cmdu);
          DataTable dt = new DataTable();
          da.Fill(dt);
          return dt;
      }
      public static DataTable GetDataOfClassStudent()
      {
          SqlConnection conu = Connection.Conn();
          SqlCommand cmdu = new SqlCommand();
          cmdu.CommandText = "SELECT     dbo.tbl_classmaster.classname, dbo.tbl_classstudent.studentno, dbo.tbl_classstudent.schappno, CASE WHEN dbo.tbl_classstudent.schstatus = 1 THEN 'SANCTION' ELSE 'NOT SANCTION' END AS Status,   CASE WHEN dbo.tbl_classstudent.schdisstatus = 1 THEN 'RECEIVE' ELSE 'NOT RECEIVE' END AS [DistriStatus],   dbo.tbl_classstudent.sessioncode, dbo.tbl_classstudent.classno FROM         dbo.tbl_classstudent INNER JOIN    dbo.tbl_classmaster ON dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode ";
          cmdu.CommandType = CommandType.Text;
          cmdu.Connection = conu;
          SqlDataAdapter da = new SqlDataAdapter(cmdu);
          DataTable dt = new DataTable();
          da.Fill(dt);
          return dt;
      }
      public static DataTable GetDataForReport()
      {
          SqlConnection conu = Connection.Conn();
          SqlCommand cmdu = new SqlCommand();
          cmdu.CommandText = "SELECT     dbo.tbl_student.studentno, dbo.tbl_classstudent.classno, dbo.tbl_classstudent.Section, dbo.tbl_student.scholarno AS [Scholar No], dbo.tbl_student.name AS Name,   dbo.tbl_student.father AS [Father Name], dbo.tbl_student.mother AS [Mother Name], dbo.tbl_classmaster.classname AS Class,    dbo.tbl_section.sectionname AS CSection, dbo.tbl_classstudent.schappno AS [Application No],   CASE WHEN dbo.tbl_classstudent.schstatus = 1 THEN 'SANCTION' ELSE 'NOT SANCTION' END AS Status,   CASE WHEN dbo.tbl_classstudent.schdisstatus = 1 THEN 'RECEIVE' ELSE 'NOT RECEIVE' END AS [Distri. Status], dbo.tbl_classstudent.sessioncode,   dbo.tbl_session.sessionname, CONVERT(varchar, dbo.tbl_student.dob, 106) as dob, dbo.tbl_student.P_address, dbo.tbl_student.C_address, dbo.tbl_student.casttype, dbo.tbl_student.marr_status,   dbo.tbl_student.admissiondate, dbo.tbl_student.phone FROM         dbo.tbl_student INNER JOIN dbo.tbl_classstudent ON dbo.tbl_student.studentno = dbo.tbl_classstudent.studentno INNER JOIN  dbo.tbl_classmaster ON dbo.tbl_classstudent.classno = dbo.tbl_classmaster.classcode INNER JOIN  dbo.tbl_session ON dbo.tbl_classstudent.sessioncode = dbo.tbl_session.sessioncode INNER JOIN  dbo.tbl_section ON dbo.tbl_classstudent.Section = dbo.tbl_section.sectioncode WHERE     (dbo.tbl_student.IsScholarship = 'True')";
          cmdu.CommandType = CommandType.Text;
          cmdu.Connection = conu;
          SqlDataAdapter da = new SqlDataAdapter(cmdu);
          DataTable dt = new DataTable();
          da.Fill(dt);
          return dt;
      }
    }
}
