using System;
using System.Net;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography;
using System.Reflection;



using System.Data.OleDb;
using System.Globalization;
using System.Web;
using System.Web.UI;
using CWeb=System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CWebC=System.Web.Configuration;
using System.Web.SessionState;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SMS
{
    class Connection
    {
       public Connection()
        {
           
        }

       static Connection()
       {
           UserDbName = System.Configuration.ConfigurationManager.AppSettings["userDbName"];
           UserDbUserName = CryptorEngine.Decrypt(System.Configuration.ConfigurationManager.AppSettings["userDbUserName"], true);
           UserDbPwd = CryptorEngine.Decrypt(System.Configuration.ConfigurationManager.AppSettings["userDbPwd"], true);
           UserDbServer = System.Configuration.ConfigurationManager.AppSettings["userDbServer"];

           if (string.IsNullOrEmpty(UserDbPwd))
           {
               UserDbConnectionString = string.Concat("server=", UserDbServer, ";database=", UserDbName, ";integrated security=true");
           }
           else
           {
               UserDbConnectionString = string.Concat("server=", UserDbServer, ";database=", UserDbName, ";uid=", UserDbUserName, ";password=", UserDbPwd);
           }
       }

        private static string[] arrayOld;
        public static string MResponseId = string.Empty;
        private static string AccessPathId = string.Empty;
        private static string ConnectionString = string.Empty;
        private static string UserDbConnectionString;// = "server=103.235.105.60;database=dreamzedu_users;uid=dreamzedu_user_1234567;password=Dreamzedu@1234567";
        private static string MessageSenderID = string.Empty;
        private static string MessageUserName = string.Empty;
        private static string MessagePassword = string.Empty;
        public static string BookBcode;
        public static string StudentBcode;
        public static string Flag;
        public static string FullPathOfExcelFile;
        public static Int16 SetValue_0_For_MS_Access_1_For_MS_Excel;
        public static string MSAccessFileInfoFullName;
        public static string MSExcelFileInfoFullName;
        public static string UserDbServer;
        public static string UserDbName;
        public static string UserDbUserName;
        public static string UserDbPwd;


        public static string GetGrade(decimal obtm, int maxm)
        {
            string res = string.Empty;
            obtm = Math.Round(obtm, 0);
            obtm = (obtm * 100) / maxm;
            if (obtm >= 75 && obtm <= 100)
                res = "A";
            else if (obtm >= 60 && obtm < 75)
                res = "B";
            else if (obtm >= 45 && obtm < 60)
                res = "C";
            else if (obtm >= 33 && obtm < 45)
                res = "D";
            else if (obtm >= 0 && obtm < 33)
                res = "E";
            return res;
        }
        public static string GetGradePrimary(decimal obtm, int maxm)
        {
            string res = string.Empty;
            obtm = Math.Round(obtm, 0);
            obtm = (obtm * 100) / maxm;
            if (obtm >= 90 && obtm <= 100)
                res = "A+";
            else if (obtm >= 75 && obtm <89)
                res = "A";
            else if (obtm >= 60 && obtm < 75)
                res = "B";
            else if (obtm >= 45 && obtm < 60)
                res = "C";
            else if (obtm >= 33 && obtm < 45)
                res = "D";
            else if (obtm >= 0 && obtm < 33)
                res = "E";
            return res;
        }
        public static string GetConnectionString()
        {
            try
            {
                if (string.IsNullOrEmpty(Connection.ConnectionString))
                {
                    Connection.ConnectionString = "server=" + school1.CurrentUser.DbServer + ";database=" + school1.CurrentUser.DbName + ";uid=" + school1.CurrentUser.DbUserId + ";password=" + school1.CurrentUser.DbUserPwd + ";";
                    
                    // This logic is for debug mode when the database is running locally and for those user who has setup local database
                    if (string.IsNullOrEmpty(school1.CurrentUser.DbUserPwd) || school1.CurrentUser.DbServer.Contains("sqlexpress"))
                    {
                        Connection.ConnectionString = "server=" + school1.CurrentUser.DbServer + ";database=" + school1.CurrentUser.DbName + ";integrated security=true;";
                 
                    }

                    SqlConnection con = new SqlConnection(ConnectionString);

                    try
                    {
                        con.Open();
                        con.Close();
                    }
                    catch
                    {
                        MessageBox.Show(
                            "Cannot connect to the database. Please check if the database is setup correctly");
                        Application.Exit();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Database connection detail not provided. Please contact your database admin.");
                Application.Exit();
            }
            return ConnectionString; 
        }

        public static string GetMessageSenderID()
        {
            try
            {
                if (string.IsNullOrEmpty(Connection.MessageSenderID))
                {
                    string ConnectionPath = Application.StartupPath;
                    FileStream fs = new FileStream(ConnectionPath + @"\messageid.dll", FileMode.Open, FileAccess.Read);
                    //FileStream fs = new FileStream("C:\\WINDOWS\\inf\\messageid.dll", FileMode.Open, FileAccess.Read);
                    //FileStream fs = new FileStream("C:\\WINXP\\ime\\messageid.dll", FileMode.Open, FileAccess.Read);
                    StreamReader oRead = new StreamReader(fs);
                    Connection.MessageSenderID = (string)oRead.ReadToEnd();
                    oRead.Close();
                    fs.Close();
                }
            }
            catch
            {
            }
            return MessageSenderID;
        }

        public static string GetAccessPathId()
        {
            try
            {
                if (string.IsNullOrEmpty(Connection.AccessPathId))
                {
                    string ConnectionPath = Application.StartupPath;
                    FileStream fs = new FileStream(ConnectionPath + @"\pathid.dll", FileMode.Open, FileAccess.Read);
                    //FileStream fs = new FileStream("C:\\WINDOWS\\inf\\pathid.dll", FileMode.Open, FileAccess.Read);
                    //FileStream fs = new FileStream("C:\\WINXP\\ime\\pathid.dll", FileMode.Open, FileAccess.Read);
                    StreamReader oRead = new StreamReader(fs);
                    Connection.AccessPathId = (string)oRead.ReadToEnd();
                    oRead.Close();
                    fs.Close();
                }
            }
            catch
            {
            }
            return AccessPathId;
        }

        public static void SetUserControlTheme(System.Windows.Forms.UserControl userControl)
        {
            //Graphics g = e.Graphics;
            //Rectangle rect = new Rectangle(0, 0, frm.Size.Width, frm.Size.Height);
            //LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(100, 160, 150),
            //    Color.FromArgb(100, 160, 150), LinearGradientMode.ForwardDiagonal);
            ////LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(50, 200, 250), Color.FromArgb(220, 250, 250), LinearGradientMode.Vertical);
            ////LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(100, 160, 100), Color.FromArgb(60, 130, 60), LinearGradientMode.ForwardDiagonal);
            //g.FillRectangle(brush, rect);

            userControl.BackColor = Color.FromArgb(207, 226, 223);
            //userControl.BackColor = Color.FromArgb(220, 230, 241);
           
            SetLabelColor(userControl);
            
        }

        private static void SetLabelColor(System.Windows.Forms.Control ctrl)
        {
            if(ctrl == null)
                return;

            if (ctrl is Label)
            { 
                if(ctrl.Text=="*")
                {
                    ctrl.ForeColor = Color.Red;
                }
                else
                {
                    ctrl.ForeColor = Color.FromArgb(70, 70, 70);
                }
                return;
            }
            else if (ctrl is ComboBox || ctrl is RadioButton || ctrl is CheckBox)
            {
                ctrl.ForeColor = Color.FromArgb(70, 70, 70);
                return;
            }
            else if (ctrl.Controls.Count > 0 )
            {
                foreach (System.Windows.Forms.Control childCtrl in ctrl.Controls)
                {
                    SetLabelColor(childCtrl);
                    
                }
            }
            else
            {
                return;
            }
            return;

        }

        public static void ChangeFormBackColor(Form frm, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, frm.Size.Width, frm.Size.Height);
            LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(100, 160, 150), Color.FromArgb(100, 160, 150), LinearGradientMode.ForwardDiagonal);
            //LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(50, 200, 250), Color.FromArgb(220, 250, 250), LinearGradientMode.Vertical);
            //LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(100, 160, 100), Color.FromArgb(60, 130, 60), LinearGradientMode.ForwardDiagonal);
            g.FillRectangle(brush, rect);

            // Create string to draw.
            //String drawString = "Dreamz Education Software Solutions";

            // Create font and brush.
            //Font drawFont = new Font("Arial", 24);
            //SolidBrush drawBrush = new SolidBrush(Color.Blue);

            // Create point for upper-left corner of drawing.
            //PointF drawPoint = new PointF(10.0F, 4.0F);

            // Draw string to screen.
            //e.Graphics.DrawString(drawString, drawFont, drawBrush, drawPoint);
            //g.DrawString(drawString, drawFont, drawBrush, drawPoint);
            brush.Dispose();
        }

        public static void ChangeStyleOfForm(Form frm)
        {
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.ControlBox = false;
            frm.Text = string.Empty;
        }
        public static string GetNextSeesion()
        {
            string TSession = Convert.ToString(Connection.GetId("select convert(nvarchar(10), datepart(yyyy,dateadd(yy,1,s_from)))+'-'+SUBSTRING ( convert(nvarchar(10), datepart(yy,dateadd(yy,1,s_to))),3,2) from tbl_session where sessioncode='" + school.CurrentSessionCode + "'"));
            return TSession;
        }
        public static DateTime GetFromatDate(string dt)
        {
            DateTime dtf = DateTime.ParseExact(dt, "d/M/yyyy", CultureInfo.InvariantCulture);
            return dtf;
        }
        public static string GetNextClass(string str)
        {

            string res = string.Empty;
            str = str.ToUpper();
            if (str.Equals("NUR") || str.Equals("NURSERY"))
            {
                if(str.Equals("NUR"))
                res = "LKG";
                if (str.Equals("NURSERY"))
                    res = "LKG";
            }
            else if (str.Equals("LKG") || str.Equals("KG-I"))
            {
                if (str.Equals("LKG"))
                    res = "UKG";
                if (str.Equals("KG-I"))
                    res = "KG-II";
            }
            else if (str.Equals("UKG") || str.Equals("KG-II"))
            {
                res = "I";
            }
            if (str.Equals("I"))
            {
                res = "II";
            }
            else if (str.Equals("II"))
            {
                res = "III";
            }
            else if (str.Equals("III"))
            {
                res = "IV";
            }
            else if (str.Equals("IV"))
            {
                res = "V";
            }
            else if (str.Equals("V"))
            {
                res = "VI";
            }
            else if (str.Equals("VI"))
            {
                res = "VII";
            }
            else if (str.Equals("VII"))
            {
                res = "VIII";
            }
            else if (str.Equals("VIII"))
            {
                res = "IX";
            }
            else if (str.Equals("IX"))
            {
                res = "X";
            }
            else if (str.Equals("X"))
            {
                res = "XI";
            }
            else if (str.Equals("XI"))
            {
                res = "XII";
            }
            return res;

        }

        public static string GetPreviousClass(string clsCode)
        {
            string prevClsCode = "";
            try
            {
                DataSet ds = Connection.GetDataSet("select top 1 classcode, classname, classorder from tbl_classmaster where classorder = (select classorder from tbl_classmaster where classcode = '" + clsCode + "')  -1;");

                if ( ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    prevClsCode = ds.Tables[0].Rows[0]["classcode"].ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
            }
            return prevClsCode;
        }
        public static string GetClassDeails(string str)
        {

            string res = string.Empty;
            str = str.ToUpper();
            if (str.Equals("NUR") || str.Equals("NURSERY"))
            {
                res = "NURSERY";
            }
            else if (str.Equals("LKG") || str.Equals("KG-I"))
            {

                res = "LKG";
              
            }
            else if (str.Equals("UKG") || str.Equals("KG-II"))
            {
                res = "UKG";
            }
            if (str.Equals("I"))
            {
                res = "First";
            }
            else if (str.Equals("II"))
            {
                res = "Second";
            }
            else if (str.Equals("III"))
            {
                res = "Third";
            }
            else if (str.Equals("IV"))
            {
                res = "Forth";
            }
            else if (str.Equals("V"))
            {
                res = "Fifth";
            }
            else if (str.Equals("VI"))
            {
                res = "Sixth";
            }
            else if (str.Equals("VII"))
            {
                res = "Seventh";
            }
            else if (str.Equals("VIII"))
            {
                res = "Eighth";
            }
            else if (str.Equals("IX"))
            {
                res = "Nineth";
            }
            else if (str.Equals("X"))
            {
                res = "Tenth";
            }
            else if (str.Equals("XI"))
            {
                res = "Eleventh";
            }
            else if (str.Equals("XII"))
            {
                res = "Twelveth";
            }
            return res;

        }
        public static SqlCommand cmd; 
        public static byte[] dbbyte;
        public static int UserLevel=0;
        public static string UserName=string.Empty;

        public static void SetUserLevelAuth(MDIParent1 frm)
        {
            frm.ToggleNewButton(true);
            frm.TogglePrintButton(true);

            if (Connection.UserLevel == 1 || Connection.UserName.ToUpper().Equals("DESS"))
            {
                frm.ToggleEditButton(true);
                frm.ToggleDeleteButton(true);
            }
            else
            {
                frm.ToggleEditButton(false);
                frm.ToggleDeleteButton(false);
            }
        }

        public static int GetDocuments(string schno,string doctype)
        {
            FileStream FS = null;
            
           
            string filepath=string.Empty;
            SqlConnection con = Connection.Conn();
            if (doctype.Equals("TC"))
                cmd = new SqlCommand("select TCFile,TCType from tbl_StudentDocs where StudentNo=dbo.GetStudentNo('" + schno.Trim() + "')", con);
            if (doctype.Equals("SC"))
            cmd = new SqlCommand("select SOCFile,SOCType from tbl_StudentDocs where StudentNo=dbo.GetStudentNo('" + schno.Trim() + "')", con);
            if (doctype.Equals("SLC"))
            cmd = new SqlCommand("select SLCFile,SLCType from tbl_StudentDocs where StudentNo=dbo.GetStudentNo('" + schno.Trim() + "')", con);
            if (doctype.Equals("DOB"))
            cmd = new SqlCommand("select DOBFile,DOBType from tbl_StudentDocs where StudentNo=dbo.GetStudentNo('" + schno.Trim() + "')", con);
            if (doctype.Equals("MSC"))
            cmd = new SqlCommand("select MSFile,MSType from tbl_StudentDocs where StudentNo=dbo.GetStudentNo('" + schno.Trim() + "')", con);
            if (doctype.Equals("ITC"))
            cmd = new SqlCommand("select ICFile,ICType from tbl_StudentDocs where StudentNo=dbo.GetStudentNo('" + schno.Trim() + "')", con);
            if (doctype.Equals("CC"))
            cmd = new SqlCommand("select CCFile,CCType from tbl_StudentDocs where StudentNo=dbo.GetStudentNo('" + schno.Trim() + "')", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                //Get a stored PDF bytes

                if (doctype.Equals("TC"))
                {
                    dbbyte = (byte[])dt.Rows[0]["TCFile"];
                    filepath = @"" + Connection.GetAccessPathId() + @"StudentDocs\" + schno + "_StudentTCDocs." + dt.Rows[0]["TCType"].ToString();
                }
                if (doctype.Equals("SC"))
                {
                    dbbyte = (byte[])dt.Rows[0]["SOCFile"];
                    filepath = @"" + Connection.GetAccessPathId() + @"StudentDocs\" +schno+ "_StudentSportDocs." + dt.Rows[0]["SOCType"].ToString();
                }
                if (doctype.Equals("SLC"))
                {
                    dbbyte = (byte[])dt.Rows[0]["SLCFile"];
                    filepath = @"" + Connection.GetAccessPathId() + @"StudentDocs\" +schno +"_StudentSLCDocs." + dt.Rows[0]["SLCType"].ToString();
                }
                if (doctype.Equals("DOB"))
                {
                    dbbyte = (byte[])dt.Rows[0]["DOBFile"];
                    filepath = @"" + Connection.GetAccessPathId() + @"StudentDocs\" + schno+"_StudentDOBDocs." + dt.Rows[0]["DOBType"].ToString();
                }
                if (doctype.Equals("MSC"))
                {
                    dbbyte = (byte[])dt.Rows[0]["MSFile"];
                    filepath = @"" + Connection.GetAccessPathId() + @"StudentDocs\" +schno+ "_StudentMarksheetDocs." + dt.Rows[0]["MSType"].ToString();
                }
                if (doctype.Equals("ITC"))
                {
                    dbbyte = (byte[])dt.Rows[0]["ICFile"];
                    filepath = @"" + Connection.GetAccessPathId() + @"StudentDocs\" +schno+ "_StudentIncomeTaxDocs." + dt.Rows[0]["ICType"].ToString();
                }
                if (doctype.Equals("CC"))
                {
                    dbbyte = (byte[])dt.Rows[0]["CCFile"];
                    filepath = @"" + Connection.GetAccessPathId() + @"StudentDocs\" +schno+ "_StudentCastDocs." + dt.Rows[0]["CCType"].ToString();
                }

                


                //Assign File path create file
                FS = new FileStream(filepath, System.IO.FileMode.Create);

                //Write bytes to create file
                FS.Write(dbbyte, 0, dbbyte.Length);

                //Close FileStream instance
                FS.Close();


                // Open fila after write 

                //Create instance for process class
                Process Proc = new Process();

                //assign file path for process
                Proc.StartInfo.FileName = filepath;
                Proc.Start();
                return 1;
            }
            else
                return 0;
        }
        #region Convert Date into string
        //-----------------------------------------------
        static string[] ordinals =
     {
         "First",
         "Second",
         "Third",
         "Fourth",
         "Fifth",
         "Sixth",
         "Seventh",
         "Eighth",
         "Ninth",
         "Tenth",
         "Eleventh",
         "Twelfth",
         "Thirteenth",
         "Fourteenth",
         "Fifteenth",
         "Sixteenth",
         "Seventeenth",
         "Eighteenth",
         "Nineteenth",
         "Twentieth",
         "Twenty First",
         "Twenty Second",
         "Twenty Third",
         "Twenty Fourth",
         "Twenty Fifth",
         "Twenty Sixth",
         "Twenty Seventh",
         "Twenty Eighth",
         "Twenty Ninth",
         "Thirtieth",
         "Thirty First",
    };
        static string DateToWords(string ddMMyyyy)
        {
            int day = int.Parse(ddMMyyyy.Substring(0, 2));
            int month = int.Parse(ddMMyyyy.Substring(3, 2));
            DateTime dtm = new DateTime(1, month, 1);
            int year = int.Parse(ddMMyyyy.Substring(6, 4));
            return ordinals[day - 1] + " " + dtm.ToString("MMMM") + " " + NumberToText(year, false) + "";
        }
        static string NumberToText(int number, bool isUK)
        {
            if (number == 0) return "Zero";
            string and = isUK ? "and " : ""; // deals with UK or US numbering
            if (number == -2147483648) return "Minus Two Billion One Hundred " + and +
            "Forty Seven Million Four Hundred " + and + "Eighty Three Thousand " +
            "Six Hundred " + and + "Forty Eight";
            int[] num = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (number < 0)
            {
                sb.Append("Minus ");
                number = -number;
            }
            string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };
            string[] words1 = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };
            string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
            string[] words3 = { "Thousand ", "Million ", "Billion " };
            num[0] = number % 1000;           // units
            num[1] = number / 1000;
            num[2] = number / 1000000;
            num[1] = num[1] - 1000 * num[2];  // thousands
            num[3] = number / 1000000000;     // billions
            num[2] = num[2] - 1000 * num[3];  // millions
            for (int i = 3; i > 0; i--)
            {
                if (num[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (num[i] == 0) continue;
                u = num[i] % 10;              // ones
                t = num[i] / 10;
                h = num[i] / 100;             // hundreds
                t = t - 10 * h;               // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i < first) sb.Append(and);
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd();
        }
        public static string GetDateIntoWord(string date)
        {
            string WDate=string.Empty;
            WDate = DateToWords(date);
            return WDate;


        }
        //------------------------------------------------
#endregion

      
        public static SqlConnection Conn()
        {
            SqlConnection con = new SqlConnection(Connection.GetConnectionString()); 
            return con; 
        }

        public static SqlConnection MyConnection;

        public static SqlConnection GetMyConnection()
        {
            Connection.MyConnection = Connection.Conn();

            if (Connection.MyConnection.State != ConnectionState.Open)
                Connection.MyConnection.Open();
            return Connection.MyConnection;
        }

        public static SqlConnection UserDbConnection;

        public static SqlConnection GetUserDbConnection()
        {
            Connection.UserDbConnection = new SqlConnection(UserDbConnectionString);

            if (Connection.UserDbConnection.State != ConnectionState.Open)
            {
                try
                {
                    Connection.UserDbConnection.Open();
                }
                catch(Exception ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Cannot connect to database. Please check your internet connection or firewall.");
                }
            }

            return Connection.UserDbConnection;
        }

        public static void UserEntery(string name, string tablename)
        {
            Connection.AllPerform("insert into tbl_UseDetail (UserName,TableName)values('" + name + "','" + tablename + "')");
        }

        public static int UserCheck(string tablename)
        {
            DataSet ds = Connection.GetDataSet("select count(*) from tbl_UseDetail where TableName='" + tablename + "'");
            int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return i;
        }

        public static void deleteUserEntery(string name)
        {
            Connection.AllPerform("Delete from tbl_UseDetail where UserName='" + name + "'");
        }

        public static string NewCode(string str)
        {
            DataSet ds = Connection.GetDataSet("Select CodeNo from tbl_Code where CodeName='" + str + "'");
            int i = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            i = i + 1;
            return i.ToString();
        }

        public static void CodeUpdate(string str1, string str2)
        {
            Connection.AllPerform("Update tbl_Code set CodeNo='"+str2 +"' where CodeName='"+str1 +"'");
        }

        public static  void SqlTransection(string CmdText, SqlConnection Connection, SqlTransaction TransectionObject)
        {
            try
            {

                SqlCommand cmd = Connection.CreateCommand();
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                cmd.Transaction = TransectionObject;
                cmd.CommandTimeout = 250;
                cmd.CommandText = CmdText;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
                MessageBox.Show(
                    "There is some issue in your database setup. Please contact your vendor with below information.\n" +
                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        public static DataSet GetDataSet(string str)
        {
            try
            {
                SqlConnection con = Connection.Conn();
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex); 
                MessageBox.Show(
                    "There is some issue in your database setup. Please contact your vendor with below information.\n" +
                    ex.Message,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
                return null;
            }
        }

        public static DataSet GetDataSet(string cmd, SqlConnection con)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
                MessageBox.Show(
                    "There is some issue in your database setup. Please contact your vendor with below information.\n" +
                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public static DataTable GetDataTable(string cmdText)
        {
            try
            {
                SqlConnection con = Connection.Conn();
                SqlDataAdapter da = new SqlDataAdapter(cmdText, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
                MessageBox.Show(
                    "There is some issue in your database setup. Please contact your vendor with below information.\n" +
                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                Environment.Exit(0);
                return null;
            }
        }

        public static DataTable GetDataTable(string cmdText, SqlConnection con)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmdText, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex); 
                MessageBox.Show(
                    "There is some issue in your database setup. Please contact your vendor with below information.\n" +
                    ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void FillCheckedListBox(CheckedListBox CheckedListBoxObject, string cmdText)
        {
            DataTable dt = Connection.GetDataTable(cmdText);
            if(dt!=null)
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                        CheckedListBoxObject.Items.Add(dr[1]);
                }
        }
 
        public static void FillDropList(ref ComboBox  ddl, string str)
        {
            DataSet ds = Connection.GetDataSet(str);
            ddl.DataSource = ds.Tables[0];
            ddl.DisplayMember  = ds.Tables[0].Columns[0].ToString();
            ddl.ValueMember  = ds.Tables[0].Columns[1].ToString();
        }

        public static void SetEnterKeyTo(System.Windows.Forms.Control ControlObject, KeyEventArgs e)
        {
            if (Keys.Enter.Equals(e.KeyCode))
                ControlObject.Focus();
        }

        public static void SetDataGridViewRowPostPaint(DataGridView DataGridViewObject, DataGridViewRowPostPaintEventArgs e)
        {
            using (System.Drawing.SolidBrush b=new System.Drawing.SolidBrush(System.Drawing.Color.Maroon))
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), DataGridViewObject.Font
                    ,b , e.RowBounds.X + 3, e.RowBounds.Y + 5);
        }

        public static void SMSSend(string MNo, string Msg)
        {
            // string MNo = TextBox1.Text;
            // string Msg = TextBox2.Text;
            WebClient client = new WebClient();
            string baseurl = "http://sms.yourbulksms.com/sendhttp.php?user=10334&password=incept&mobiles=" + MNo + "&message=" + Msg + "&sender=incept";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
            //  Response.Write("MessageSend Successfully");
        }  

        public static string GetDropDownId(string str)
        {
            DataSet ds = Connection.GetDataSet(str);
            return ds.Tables[0].Rows[0].ItemArray[0].ToString();

        }
        public static int AllPerform(string str)
         {
            SqlConnection con = Connection.Conn();
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }

        public static int ExecuteNonQuery(string cmdStr, SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand(cmdStr, con);

            if(con.State == ConnectionState.Closed)
                con.Open();

            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public static DateTime GetDateMMddyyyy(string ddmmyyyy)
        {
           // string d = "25/02/2012";
            DateTime dt = DateTime.ParseExact(ddmmyyyy, "d/M/yyyy", CultureInfo.InvariantCulture);
            // for both "1/1/2000" or "25/1/2000" formats
            //string newString = dt.ToString("MM/dd/yyyy");
            return dt;
        }
        public static DateTime GetTimeHHmmss(string ddmmyyyy)
        {
            string d = DateTime.Now.ToString("dd/MM/yyy");
            d = d +" "+ ddmmyyyy;

            DateTime dt = DateTime.ParseExact(d, "d/M/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            // for both "1/1/2000" or "25/1/2000" formats
            //string newString = dt.ToString("MM/dd/yyyy");
            return dt;
        }
        public static void ShowData(ref DataGridView  dg, string str)
        {
            DataSet ds = Connection.GetDataSet(str);
            dg.DataSource = ds.Tables[0];
        }

        public static int Login(string str)
        {

            DataSet ds = Connection.GetDataSet(str);
            int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return i;

        }

        public static string AutoId1(string str, string str1)
        {
            DataSet ds = Connection.GetDataSet(str);
            int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            return str1 + (i + 1);
        }

        public static void AddDataInCheckList(ref CheckedListBox  chk, string str)
        {
            DataSet ds = Connection.GetDataSet(str);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                chk.Items.Add(dr[0].ToString() + "-" + dr[1].ToString());
            }
        }

        public static void AddDataInCheckList1(ref CheckedListBox chk, string str)
        {
            DataSet ds = Connection.GetDataSet(str);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                chk.Items.Add(dr[0].ToString() );

            }
        }

        //public static void TwoFieldInDropDown1(ref DropDownList ddl, string str)
        //{
        //    DataSet ds = Connection.GetDataSet(str);
        //    ddl.Items.Clear();

        //    ddl.DataSource = ds.Tables[0];
        //    ddl.DataTextField = ds.Tables[0].Columns[0].ToString() + "-" + ds.Tables[0].Columns[1].ToString();
        //    ddl.DataValueField = ds.Tables[0].Columns[0].ToString() + "-" + ds.Tables[0].Columns[1].ToString();
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, "---SELECT---");
        //}

        public static void TwoFieldInDropDown(ref ComboBox  ddl, string str)
        {
            ddl.Items.Clear();
            ddl.Items.Add("--Select--");
            DataSet ds = Connection.GetDataSet(str);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                ddl.Items.Add(dr[0].ToString() + "-" + dr[1].ToString());
            }
        }

        public static void FillCombo(ref ComboBox ddl, string str)
        {
            ddl.Items.Clear(); 
            DataSet ds = Connection.GetDataSet(str);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                ddl.Items.Add(dr[0].ToString());
            }
        }

        public static void FillComboBox(ComboBox ComboBoxObject, string cmdText)
        {
            DataTable dt = Connection.GetDataTable(cmdText);
            if(dt.Rows .Count >0)            
            {
                ComboBoxObject.DataSource = dt;
                ComboBoxObject.ValueMember=dt.Columns[0].ToString ();
                ComboBoxObject.DisplayMember = dt.Columns[1].ToString();
            }
        }
        //public static void CustomerName(ref DropDownList ddl)
        //{
        //    DataSet ds = Connection.GetDataSet("Select FirstName +'-'+LastName as CustomerName,CustomerId from tblCustomerMaster");
        //    //ddlCustomerName.Items.Add("--Select--");
        //    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //{
        //    //    DataRow dr = ds.Tables[0].Rows[i];
        //    //    ddlCustomerName.Items.Add(dr[0].ToString() + "-" + dr[1].ToString());

        //    //}
        //    ddl.Items.Clear();

        //    ddl.DataSource = ds.Tables[0];
        //    ddl.DataTextField = ds.Tables[0].Columns[0].ToString();
        //    ddl.DataValueField = ds.Tables[0].Columns[1].ToString();
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, "---SELECT---");
        //}
        //public static void CustomerNameForOrderEntry(ref DropDownList ddl, string CompantName)
        //{
        //    DataSet ds = Connection.GetDataSet("SELECT        tblCustomerMaster.FirstName+'-'+tblCustomerMaster.LastName as CustomerName, tblCustomerMaster.CustomerId  FROM            tblCustomerCompany INNER JOIN                          tblCompanyMaster ON tblCustomerCompany.CompanyId = tblCompanyMaster.CompanyId INNER JOIN                          tblCustomerMaster ON tblCustomerCompany.CustomerId = tblCustomerMaster.CustomerId where tblCompanyMaster.CompanyName='" + CompantName + "'");
        //    //ddlCustomerName.Items.Add("--Select--");
        //    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    //{
        //    //    DataRow dr = ds.Tables[0].Rows[i];
        //    //    ddlCustomerName.Items.Add(dr[0].ToString() + "-" + dr[1].ToString());

        //    //}
        //    ddl.Items.Clear();

        //    ddl.DataSource = ds.Tables[0];
        //    ddl.DataTextField = ds.Tables[0].Columns[0].ToString();
        //    ddl.DataValueField = ds.Tables[0].Columns[1].ToString();
        //    ddl.DataBind();
        //    ddl.Items.Insert(0, "---SELECT---");
        //}
        //public static void SMSSend(string MNo, string Msg)
        //{
        //    // string MNo = TextBox1.Text;
        //    // string Msg = TextBox2.Text;
        //    WebClient client = new WebClient();
        //    string baseurl = "http://sms.yourbulksms.com/sendhttp.php?user=10334&password=incept&mobiles=" + MNo + "&message=" + Msg + "&sender=incept";
        //    Stream data = client.OpenRead(baseurl);(local)
        //    StreamReader reader = new StreamReader(data);
        //    string s = reader.ReadToEnd();
        //    data.Close();
        //    reader.Close();
        //    //  Response.Write("MessageSend Successfully");
        //}

        private static void GetDetailOfCustomerMessageService()
        {
            if (string.IsNullOrEmpty(Connection.MessageSenderID) &&
                string.IsNullOrEmpty(Connection.MessageUserName) &&
                string.IsNullOrEmpty(Connection.MessagePassword))
            {
                DataTable dtDetailOfMessageService = Connection.GetDataTable("SELECT ISNULL(schoolname,'') as schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, " +
                    " principal, registrationno, logoimage, ISNULL(Website,'') as Website, MessageService, MessageSenderID,MessageUserName,MessagePassword FROM tbl_school");
                Connection.MessageSenderID = dtDetailOfMessageService.Rows[0]["MessageSenderID"].ToString();
                Connection.MessageUserName = dtDetailOfMessageService.Rows[0]["MessageUserName"].ToString();
                Connection.MessagePassword = dtDetailOfMessageService.Rows[0]["MessagePassword"].ToString();
            }
        }

        public static void SendSMS(string MSISDN_Id, string TextMessage)
        {
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                //System.Xml.XmlDocument XDoc = new System.Xml.XmlDocument();  
                //XDoc.Load(Application.StartupPath + @"\Mahanta.xml");  
                //Connection.GetDetailOfCustomerMessageService();
                //HttpWebRequest MyWebRequest = (HttpWebRequest)WebRequest.Create(XDoc.DocumentElement["MessageAPIConfig"].InnerText.Trim().Replace("MessageUserName",
                //    CryptorEngine.Decrypt(Connection.MessageUserName,true)).Replace("MessagePassword",
                //    CryptorEngine.Decrypt(Connection.MessagePassword ,true)).Replace("MSISDN_Id",MSISDN_Id).Replace("TextMessage",TextMessage).Replace("MessageSenderID",Connection.MessageSenderID));

                 //string sid = Connection.GetMessageSenderID();
                // string s  = "http://smszone.us/xml-transconnectunicode-api.php?username=" + CryptorEngine.Decrypt(Connection.MessageUserName, true) + "&password=" + CryptorEngine.Decrypt(Connection.MessagePassword, true) +
                   // "&mobile=" + MSISDN_Id + "&message=" + TextMessage + "&senderid=" + Connection.MessageSenderID + "";*
                string sid = Connection.GetMessageSenderID();
                string s = "http://smszone.us/xml-transconnect-api.php?username=school123&password=school123&mobiles=" + MSISDN_Id + "&message=" + TextMessage + "&sender=" + sid; 
                
                // lakshy

                // http://sms.junksms.in/xml-transconnectunicode-api.php?username=MessageUserName&amp;password=MessagePassword&amp;mobile=MSISDN_Id&amp;message=TextMessage&amp;senderid=MessageSenderID
                // :http://smszone.us/xml-transconnect-api.php?username=XXXXX&password=XXXXXX&mobile=XXXXXXX&message=XXXXXX&senderid=XXXXX
                //s = "http://msg.cyberinformatic.in/api/sendhttp.php?authkey=68215ACcGLIVQI5394c1e1&mobiles=7415342500&message=Hi...&sender=GRATUL&route=1";
                //-----------HERE CODE FOR MESSAGE -----------71771AuiDvedh50ed48b mahesh memorial /68217ABZIrfDxD953945b7a lis/88110APlOBIJY559a362b rnconvent guna
                //string autkey = Convert.ToString(Connection.GetExecuteScalar("Select MessageSenderID From tbl_School where MessageService='True'"));
                //string sid = Connection.GetMessageSenderID();
                //byte[] bytes = Encoding.Default.GetBytes(TextMessage);
                //string enc = Encoding.UTF8.GetString(bytes);
                //string userName = CryptorEngine.Decrypt(Connection.MessageUserName, true);
                //string userPassword = CryptorEngine.Decrypt(Connection.MessagePassword, true);
                //string s = "http://smszone.us/xml-transconnect-api.php?=username=" + CryptorEngine.Decrypt(Connection.MessageUserName, true) + "&password=" + CryptorEngine.Decrypt(Connection.MessagePassword, true) + "&mobile=" + MSISDN_Id + "&message=" + TextMessage + "&senderid=" + sid;
               // s = "http://msg.cyberinformatic.in/api/sendhttp.php?authkey=" + autkey + "&mobiles=" + MSISDN_Id + "&message=" + TextMessage + "&Unicode=1&sender=" + sid;
                HttpWebRequest MyWebRequest = (HttpWebRequest)WebRequest.Create(s);
                
                try
                {
                    HttpWebResponse MyWebResponse = (HttpWebResponse)MyWebRequest.GetResponse();
                    System.IO.StreamReader respStreamReader = new System.IO.StreamReader(MyWebResponse.GetResponseStream());
                    MResponseId = respStreamReader.ReadToEnd();
                    respStreamReader.Close();
                    MyWebResponse.Close();
                }
                catch (ProtocolViolationException ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Text Message can not be send to the destination.\n\tPlease Check Text Message...");
                }

                catch (WebException ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("There Are Server Problem.\n\tPlease Wait...");
                }

                catch (System.InvalidOperationException ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Previous Message Sending Under Process.\n\tPlease Wait...");
                }

                catch (System.NotSupportedException ex)
                {
                    Logger.LogError(ex); 
                    MessageBox.Show("Text Message format is not supported by server.\n\tPlease Check...");
                }

            }
            else
            {
                MessageBox.Show("There are no Internet/Network connection...\n\tPlease check your Internet Connection. ", "Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static string AutoCode(string str)
        {
            DataSet ds = Connection.GetDataSet("Select CodeNo from tblCode where CodeName = '" + str + "' ");
            int CodeNo = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            CodeNo = CodeNo + 1;
            return CodeNo.ToString();
        }

        public static void IdUpdate(string CodeNo, string CodeName)
        {
            Connection.AllPerform("Update tblCode set CodeNo = '" + CodeNo.ToString() + "'  Where CodeName = '" + CodeName.ToString() + "' ");
        }

        public static void GroupClear(Form f)
        {
            foreach (System.Windows.Forms.Control cont in f.Controls)
            {
                if (cont is TextBox)
                {
                    cont.Text = "";
                } 
            }
        }
         
        public static void ComboIndexChk(ref   ComboBox cmb, string str1)
        {
            DataSet ds = Connection.GetDataSet(str1);
            arrayOld = new string[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                arrayOld[i] = dr[0].ToString();
            }
            string item = cmb.Text;
            item = item.ToLower();
            cmb.Items.Clear();
            List<string> list = new List<string>();

            for (int i = 0; i < arrayOld.Length; i++)
            {
                if (arrayOld[i].ToLower().Contains(item))
                    list.Add(arrayOld[i]);
            }
            if (item != String.Empty)
                foreach (string str in list)
                    cmb.Items.Add(str);
            else
                cmb.Items.AddRange(arrayOld);
            cmb.SelectionStart = item.Length;
            cmb.DroppedDown = true;
        }

        public static string boardofstudey()
        {
            DataSet ds = Connection.GetDataSet("select affiliate_by from tbl_school");
            string board=ds .Tables [0].Rows [0].ItemArray [0].ToString ();
            return board; 
        }

        public static string getclassno(string str)
        {
            DataSet ds = Connection.GetDataSet("select classcode from tbl_classmaster where classname='"+str +"'");
               return ds.Tables[0].Rows[0].ItemArray[0].ToString();
        }


        public static SqlDataReader GetDataReader(string CmdText)
        {
            SqlConnection con = Connection.Conn ();
            SqlCommand cmd = new SqlCommand(CmdText, con);
            if (con.State != ConnectionState.Open)
                con.Open();
            SqlDataReader dr = cmd.ExecuteReader(); 
                return dr; 
        }         

        public static object GetExecuteScalar(string CmdText)
        {
            SqlConnection con = Connection.Conn ();
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


        public static object GetExecuteScalar(string CmdText, SqlConnection con)
        {
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

        public static DataTable GetDataTableFromDataGridView(DataGridView DataGridViewObject)
        {
            if (DataGridViewObject.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                if (DataGridViewObject.RowCount > 0)
                {
                    foreach (DataGridViewColumn dgvc in DataGridViewObject.Columns)
                        dt.Columns.Add(dgvc.Name);
                    foreach (DataGridViewRow dgvr in DataGridViewObject.Rows)
                    {
                        DataRow dr = dt.NewRow();
                        foreach (DataGridViewColumn dgvc in DataGridViewObject.Columns)
                        {
                            dr[dgvc.Name] = dgvr.Cells[dgvc.Name].Value;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            else
                return null;
        }

        public static DataTable GetDataTableFromDataGridViewDefaultDataType(DataGridView DataGridViewObject)
        {
            if (DataGridViewObject.Rows.Count > 0)
            {
                DataTable dt = new DataTable();
                if (DataGridViewObject.RowCount > 0)
                {
                    foreach (DataGridViewColumn dgvc in DataGridViewObject.Columns)
                        dt.Columns.Add(dgvc.Name, dgvc.ValueType);
                    foreach (DataGridViewRow dgvr in DataGridViewObject.Rows)
                    {
                        DataRow dr = dt.NewRow();
                        foreach (DataGridViewColumn dgvc in DataGridViewObject.Columns)
                        {
                            dr[dgvc.Name] = dgvr.Cells[dgvc.Name].Value;
                        }
                        dt.Rows.Add(dr);
                    }
                }
                return dt;
            }
            else
                return null;
        }

        public static void FillComboMonthName(ComboBox Cmb,bool SelectDefaultMonth)
        {
            Cmb.Items.Add("-Select Month-");
            for (int i = 1; i <= 12; i++)
                Cmb.Items.Add(System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(i));
            if(SelectDefaultMonth) 
                Cmb.SelectedIndex = DateTime.Now.Month;
            else
                Cmb.SelectedIndex = 0;
        }
        public static void FillComboYear(ComboBox Cmb, int FromYear, int ToYear, bool SelectDefaultYear)
        {
            Cmb.Items.Add("-Select Year-");
            for (int i = FromYear; i <= ToYear; i++)
                Cmb.Items.Add(i);
            if (SelectDefaultYear) 
                Cmb.SelectedItem =DateTime.Now .Year ;
            else
                Cmb.SelectedIndex = 0;
        }
        public static void SaveDataGridViewAsExcelFile(DataGridView DataGridViewObject,DataSet ds)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Excel Worksheets (*.xls)|*.*";
            sv.FileName = "StudentDetails";
            if (DialogResult.OK == sv.ShowDialog())
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn col in DataGridViewObject.Columns)
                {
                    dt.Columns.Add(col.HeaderText, col.ValueType);
                }
                int count = 0;
                foreach (DataGridViewRow row in DataGridViewObject.Rows)
                {
                    if (count < DataGridViewObject.Rows.Count )
                    {
                        dt.Rows.Add();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.ValueType.Name.Equals("Byte[]"))
                            {
                                byte[] ByteImage=null;
                                if(string.IsNullOrEmpty(cell.Value.ToString()))
                                {
                                    ByteImage=null;
                                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] =null;
                                }
                                else
                                {
                                    ByteImage = (byte[])cell.Value;
                                    //Bitmap bmp = Connection.GetImageFromByteArray(ByteImage);
                                    dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = null;
                                }
                                
                                
                                //bmp = Connection.AdjustContrastOfImage(bmp, 80f);

                                
                            }
                            else
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                        }
                    }
                    count++;
                }
                System.Web.UI.WebControls.GridView gv = new System.Web.UI.WebControls.GridView();
                gv.DataSource = ds.Tables[0];
                gv.DataBind();


                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        gv.AllowPaging = false;
                        //  Create a table to contain the grid
                        System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();

                        //  include the gridline settings
                        table.GridLines = gv.GridLines;

                        gv.Style["font-family"] = "Tahoma";
                        //  add the header row to the table

                        if (gv.HeaderRow != null)
                        {
                            gv.HeaderRow.BackColor = System.Drawing.Color.Lavender;
                            gv.HeaderRow.ForeColor = System.Drawing.Color.Green;

                            table.Rows.Add(gv.HeaderRow);
                        }
                        //  add each of the data rows to the table
                        foreach (CWeb.GridViewRow row in gv.Rows)
                        {
                            table.Rows.Add(row);
                        }
                        //  add the footer row to the table
                        if (gv.FooterRow != null)
                        {
                            table.Rows.Add(gv.FooterRow);
                        }
                        htw.WriteLine("<br>");
                        // htw.WriteLine("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                        htw.WriteLine("</p>");
                        //  render the table into the htmlwriter
                        table.RenderControl(htw);
                        //  render the htmlwriter into the response
                    }

                    Encoding utf16 = Encoding.GetEncoding(1254);
                    byte[] output = utf16.GetBytes(Convert.ToString(sw));
                    FileStream fs = new FileStream(sv.FileName + ".xls", FileMode.Create);
                    BinaryWriter bw = new BinaryWriter(fs);
                    bw.Write(output, 0, output.Length);
                    bw.Flush();
                    bw.Close();
                    fs.Close();
                    MessageBox.Show("File Saved Successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
                
            
        }
  
        public static string GetId(string CommandStatement)
        {
            string str =Convert.ToString (Connection .GetExecuteScalar(CommandStatement));
            return str;
        }

        public static System.Drawing.Bitmap GetImageFromByteArray(byte[] ByteArrayOfImage)
        {
            MemoryStream ms = new MemoryStream(ByteArrayOfImage);
            //Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);            
            return new System.Drawing.Bitmap(System.Drawing.Bitmap.FromStream(ms));
        }

        public static byte[] GetByteArrayFromImage(System.Drawing.Bitmap ImageForByteArray)
        {
            MemoryStream ms = new MemoryStream();
            ImageForByteArray.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray(); ;
        }


        public static System.Drawing.Bitmap AdjustContrastOfImage(System.Drawing.Bitmap Image, float ContrastValue)
        {
            float Value = ContrastValue * 0.01f;
            //This line set the brightness value of image in domainUpDown control withrange -100 to 100.
            //And below we demine single type array in 5 x 5 matrix
            float[][] colorMatrixElements = {
              new float[] {1,0,0,0,0},
              new float[] {0,1,0,0,0},
              new float[] {0,0,1,0,0},
              new float[] {0,0,0,1,0},
              new float[] {Value, Value, Value, 0, 1}  };
            //Define colormatrix
            ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            Image _img = Image;
            Graphics _g = default(Graphics);
            Bitmap bm_dest = new Bitmap(Convert.ToInt32(_img.Width), Convert.ToInt32(_img.Height));
            _g = Graphics.FromImage(bm_dest);
            _g.DrawImage(_img, new Rectangle(0, 0, bm_dest.Width + 1, bm_dest.Height + 1), 0, 0, bm_dest.Width + 1, bm_dest.Height + 1, GraphicsUnit.Pixel, imageAttributes);
            return  bm_dest;
        }



        public static OleDbConnection ConnectionStringToExcelExcelFile()
        {
            System.IO.FileInfo xlsFileInfo = new System.IO.FileInfo(FullPathOfExcelFile);
            //  string connectionString = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes'", xlsFileInfo.FullName);

            string connectionString = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=Yes'", xlsFileInfo.FullName);


            return new OleDbConnection(connectionString);
        }

        public static void AllPerformFromExcelFile(string Query)
        {
            //"select *from [Sheet1$] ";
            OleDbConnection con = Connection.ConnectionStringToExcelExcelFile();
            OleDbCommand cmd = new OleDbCommand(Query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataSet GetDataSetFromExcelFile(string Query)
        {
            OleDbConnection con = Connection.ConnectionStringToExcelExcelFile();
            OleDbDataAdapter da = new OleDbDataAdapter(Query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public static void SetEnterKey(char KeyCharecter)
        {
            if (KeyCharecter.Equals('\r')) 
                SendKeys.Send("{Tab}"); 
        }

        public static DataSet JGetDefaultImage()
        {
            Connection dcon = new Connection();

            DataSet ds = new DataSet();
            ds = GetDataSet("select *from DefaultImage");
            return ds;


        }
        public static OleDbConnection ConnectionStringToOleDbConnection()
        {
            List<string> ConnectionStringOLEDB = new List<string>{
            String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};",
            Connection.MSAccessFileInfoFullName),
            String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=Yes'",
            Connection.MSExcelFileInfoFullName)};
            return new OleDbConnection(ConnectionStringOLEDB[SetValue_0_For_MS_Access_1_For_MS_Excel]);
        }

        public static DataTable GetDataTableFromExcelFile(string Query)
        {
            OleDbConnection con = Connection.ConnectionStringToOleDbConnection();
            OleDbDataAdapter da = new OleDbDataAdapter(Query, con);
            DataTable ds = new DataTable();
            da.Fill(ds);
            return ds;
        }
        public static DataSet GetDataSetFromXMLFile(string FileNameWithOutExtension)
        {
            DataSet ds = new DataSet("ds");
            ds.ReadXml(Application.StartupPath + @"\" + FileNameWithOutExtension + ".XML");
            return ds;
        }
        public static object GetAttributeObjectFromXMLFile(string FileNameWithOutExtension, string AttributeName)
        {
            DataSet ds = Connection.GetDataSetFromXMLFile(FileNameWithOutExtension);
            object Obj = ds.Tables[0].Rows[0][AttributeName];
            return Obj;
        }
    }
}
