using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SMS
{
    public static class Logger
    {
        public static void LogError(Exception ex)
        {
            try { 
            SqlConnection con  = Connection.GetUserDbConnection();
                SqlCommand cmd = new SqlCommand("insert into CsmsLogs(logDate, logType, logText, appUser) values('"+DateTime.Now.ToLongDateString()+"','error','"+ ex.Message+":     :"+ ex.StackTrace+"', '"+ school.CurrentUser != null? school.CurrentUser.UserId: string.Empty +"') ", con);
                cmd.ExecuteNonQuery();
            }
            catch { }

        }

        public static void LogError(string msg)
        {
            try
            {
                SqlConnection con = Connection.GetUserDbConnection();
                SqlCommand cmd = new SqlCommand("insert into CsmsLogs(logDate, logType, logText, appUser) values('" + DateTime.Now.ToLongDateString() + "','error','" + msg + "', '" + school.CurrentUser != null ? school.CurrentUser.UserId : string.Empty + "') ", con);
                cmd.ExecuteNonQuery();
            }
            catch { }
        }

    }
}
