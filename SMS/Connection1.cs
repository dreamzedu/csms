using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace SMS
{

    /// <summary>
    /// Summary description for cONNECTION
    /// </summary>
    public class Connection1
    {
        public Connection1()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static SqlConnection conn()
        {           
            // SqlConnection con = new SqlConnection("Data Source=sharedmssql3.znetindia.net,1234;Initial Catalog=sunny;User ID=microdigit;Password=Mqqq.123");
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Sunny;User ID=sa;Password=DbAdmin.123");
            return con;
        }
        public static DataSet getData(string str)
        {
            SqlConnection con = Connection1.conn();
            SqlDataAdapter da = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public static void AllPer(string str)
        {
            SqlConnection con = Connection1.conn();
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void SqlTransection(string msql, SqlConnection cnn, SqlTransaction sqltrn)
        {
            SqlCommand cmd = cnn.CreateCommand();
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
            }
            cmd.Transaction = sqltrn;
            cmd.CommandTimeout = 250;
            cmd.CommandText = msql;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public static SqlDataReader GetDataReader(string CmdText)
        {
            SqlConnection con = Connection1.conn();
            SqlCommand cmd = new SqlCommand(CmdText, con);
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                return dr;
            }
            else
                return null;
        }

        public static object GetExecuteScalar(string CmdText)
        {
            SqlConnection con = Connection1.conn();
            SqlCommand cmd = new SqlCommand(CmdText, con);
            if (con.State != ConnectionState.Open)
                con.Open();
            object obj = cmd.ExecuteScalar();
            con.Close();
            if (obj != DBNull.Value)
                return obj;
            else
                return null;
        }

        public static string GetMacAddressNew()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        } 
    }
}

