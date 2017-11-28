using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.IO;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
namespace SMS
{
    partial class Loginform : Form
    {
        school c = new school();
        public static int CurrentSessionCode;
        string U = "com_1", P = "12345678";//"dess", P="Winserver";
        public Loginform()
        {
            InitializeComponent();
            //DesignForm.fromDesign(this);

            // DesignForm.fromDesign1(this);
            //DesignForm.fromDesign1(this);

            //  Initialize the AboutBox to display the product information from the assembly information.
            //  Change assembly information settings for your application through either:                
            //  - Project->Properties->Application->Assembly Information                                 
            //  - AssemblyInfo.cs                                                                        
            //  this.Text = String.Format("About {0}", AssemblyTitle);   
            

        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                // Get all Title attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                // Get all Description attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                // Get all Product attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                // Get all Copyright attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                // Get all Company attributes on this assembly
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        public void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        public static void ProcessDirectory(string targetDirectory)
        {
            //// Process the list of files found in the directory.
            //// string[] fileEntries = Directory.GetFiles(targetDirectory);
            //// foreach (string fileName in fileEntries)
            //// ProcessFile(fileName);
            //// Recurse into subdirectories of this directory.

            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        
        private void btnok_Click(object sender, EventArgs e)
        {
            //school.CurrentSessionCode = Convert.ToInt32(cmbsession.SelectedValue.ToString());

            string Pass = CryptorEngine.Encrypt(txtPassword.Text.Trim(), true);
            SqlConnection con = Connection.GetUserDbConnection();
            
            //DataSet ds = Connection.GetDataSet("Select * from MasterUser where UserName='" + txtUserName.Text.Trim() + "' and UserPassword='" + Pass.Trim() + "'; ");
            SqlDataAdapter adp = new SqlDataAdapter("Select * from MasterUser where lower(userId)='" + txtUserName.Text.Trim().ToLower() + "' and pwd='" + Pass + "'; ", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds != null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count >0)
            {
                school1.CurrentUser = new CSMSUser();
                school1.CurrentUser.UserId = ds.Tables[0].Rows[0]["userId"].ToString();
                school1.CurrentUser.Name = ds.Tables[0].Rows[0]["name"].ToString();
                school1.CurrentUser.Phone = ds.Tables[0].Rows[0]["phone"].ToString();
                school1.CurrentUser.Address = ds.Tables[0].Rows[0]["address"].ToString();
                school1.CurrentUser.Email = ds.Tables[0].Rows[0]["email"].ToString();
                school1.CurrentUser.School = ds.Tables[0].Rows[0]["school"].ToString();
                school1.CurrentUser.IsPrimaryUser = Convert.ToBoolean(ds.Tables[0].Rows[0]["isPrimaryUser"]);
                school1.CurrentUser.DbName = ds.Tables[0].Rows[0]["dbName"].ToString();
                school1.CurrentUser.DbUserPwd = ds.Tables[0].Rows[0]["dbUserPwd"].ToString();
                school1.CurrentUser.DbUserId = ds.Tables[0].Rows[0]["dbUserId"].ToString();
                school1.CurrentUser.RoleId = Convert.ToInt16(ds.Tables[0].Rows[0]["roleId"]);
                school1.CurrentUser.UserCode = Convert.ToInt32(ds.Tables[0].Rows[0]["UserCode"]);
                school1.CurrentUser.ActivationValidTill = Convert.ToDateTime(ds.Tables[0].Rows[0]["ActivationValidTill"]);
                school1.CurrentUser.ActivatedOn = Convert.ToDateTime(ds.Tables[0].Rows[0]["ActivatedOn"]);
                school1.CurrentUser.IsActive = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsActive"]);

                // Initializing it for school class as well because it is still in use many places
                school.CurrentUser = school1.CurrentUser;

                SetupAppPaths();

                bool isActive = IsUserActive();
                                

                if (isActive)
                {
                    MDIParent1 main = new MDIParent1(school1.CurrentUser.UserCode.ToString(), school1.CurrentUser.Name);
                    this.Hide();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("Your user account is in inactive state, please contact your vendor for further assistance.");
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Invalid USER NAME/PASSWORD");
            }

            con.Close();

            //DataSet dschk = Connection.GetDataSet("Select * from SMSsystem ");
            //if (dschk.Tables[0].Rows.Count < 1)
            //{
            //    Registration r = new Registration();
            //    r.Show();
            //}
            //else
            //{

            //    DataSet dschk1 = Connection.GetDataSet("Select * from SMSsystem ");
            //    if (dschk1.Tables[0].Rows.Count < 1)
            //    {
            //        Connection.AllPerform("Insert Into SMSsystem values('" + DateTime.Now.ToShortDateString() + "')");
            //    }
            //    else
            //    {
            //        DateTime dt = Convert.ToDateTime(dschk1.Tables[0].Rows[0].ItemArray[0].ToString());
            //        DateTime dtnew = DateTime.Now;
            //        TimeSpan t = dtnew.Subtract(dt);
            //        int k = t.Days;
            //        if (k > 365)
            //        {
            //            MessageBox.Show("Your Subscription has Expired ? ");
            //            Reminder r = new Reminder();
            //            r.Show();
            //            this.Hide();                         
            //        }

            //        else
            //        {

            //            DateTime dt1 = Convert.ToDateTime(dschk1.Tables[0].Rows[0].ItemArray[0].ToString());
            //            DateTime dtnew1 = DateTime.Now;
            //            TimeSpan t1 = dtnew.Subtract(dt);
            //            int k1 = t1.Days;
            //            if (k1 > 350 && k1 < 365)
            //            {
            //                int l1 = 365 - k1;
            //                MessageBox.Show("No Of Days Left " + l1.ToString() + "  Please Renew Your Subscription");
            //            }
            //            string Pass = CryptorEngine.Encrypt(txtPassword.Text, true);
            //            //string Pass1 = CryptorEngine.Decrypt(txtPassword.Text, true);
            //            DataSet ds = Connection.GetDataSet("Select Count(*) from tbl_User where UserName='" + txtUserName.Text.Trim () + "' and UserPassword='" + Pass.Trim () + "'; "+
            //                "Select UserCode,UserName From tbl_User Where UserName='" + txtUserName.Text.Trim() + "' and UserPassword='" + Pass.Trim() + "';");
            //            int i = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            //            if (txtUserName.Text.Trim().Equals(SMS.Splash.U) && SMS.Splash.P.Equals(CryptorEngine.Encrypt(txtPassword.Text, true)))
            //            {
            //                this.Hide();
            //                Splash su = new Splash(SMS.Splash.U, SMS.Splash.P);
            //                su.Show();
            //            }
            //           else if (i == 1)
            //            {
            //                this.Hide();
            //                // MessageBox.Show("Welcome To  School Management System ", "Microdigit Software Technologies Pvt Ltd ");
            //                Splash su = new Splash(ds.Tables[1].Rows[0]["UserCode"].ToString(), ds.Tables[1].Rows[0]["UserName"].ToString());
            //                //Form mainForm = new mdikgri(textBox1.Text);
            //                // Make it a child of this MDI form before showing it.
            //                // mainForm.Show();
            //                su.Show();
            //            }
            //            else
            //            {

            //                MessageBox.Show("Invalid USER NAME/PASSWORD");
            //                DataSet ds1 = Connection.GetDataSet("Select Count(*) from tbl_User ");
            //                int ii = Convert.ToInt32(ds1.Tables[0].Rows[0][0]);
            //                if (ii == 0)
            //                {
            //                    MessageBox.Show("Pleace Create a User Account.");
            //                    Form mainForm = new frmuser();
            //                    mainForm.Show();
            //                }
            //                else
            //                {
            //                    DataSet ds2 = Connection.GetDataSet("Select Count(*) from tbl_Userauth ");
            //                    int ij = Convert.ToInt32(ds2.Tables[0].Rows[0][0]);
            //                    if (ij == 0)
            //                    {
            //                        Form mainForm = new frmuserauth();
            //                        mainForm.Show();
            //                    }
            //                }

            //            }
            //            //Form mainForm = new mdikgri();
            //            //mainForm.Show();               
            //        }
            //    }
            //    //}
            //}
        }

        private bool IsUserActive()
        {
            string Pass = CryptorEngine.Encrypt(txtPassword.Text.Trim(), true);
            SqlConnection con = Connection.GetUserDbConnection();
            
            //DataSet ds = Connection.GetDataSet("Select * from MasterUser where UserName='" + txtUserName.Text.Trim() + "' and UserPassword='" + Pass.Trim() + "'; ");
            SqlDataAdapter adp = new SqlDataAdapter("Select IsActive, ActivationValidTill, ActivatedOn from MasterUser where lower(userId)='" + txtUserName.Text.Trim().ToLower() + "' and pwd='" + Pass + "' and IsActive = 1 and ActivatedOn <= getdate() and ActivationValidTill >= getdate(); ", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DateTime date = Convert.ToDateTime(ds.Tables[0].Rows[0]["ActivationValidTill"]);
                
                if(DateTime.Now.AddDays(30) > date)
                {
                    int dateDiff = DateTime.Now.AddDays(30).Subtract(date).Days;
                    MessageBox.Show("Your subscription is expiring in next " + dateDiff + " days, please renew your subscription to avoid disruption in your business.");
                
                }
                return true;
            }
            else
            {
                MessageBox.Show("Your subscription has expired, please contact our sales to renew your subscription.");

                return false;
            }
        }
        private void Loginform_Load(object sender, EventArgs e)
        {
            //c.FillcomboBox("select * from tbl_section order by sectionname", "sectionname", "sectioncode", ref  valcmbsection);
            //Connection.FillDropList(ref cmbsession, " SELECT sessionname, sessioncode  FROM tbl_session  ");
            //cmbsession.SelectedValue = Loginform.CurrentSessionCode = Convert.ToInt32(Connection.GetExecuteScalar("Select SessionCode From tbl_Session Where SessionStatus=1"));

#if DEBUG
            txtUserName.Text = U;
            txtPassword.Text = P;
#endif
                   

            txtUserName.Focus();
            //WithoutLogin();
        } 

        private void SetupAppPaths()
        {
            try
            {
                string[] path1 = new string[4];
                path1[0] = @"" + Connection.GetAccessPathId() + "Barcodes";
                path1[1] = @"" + Connection.GetAccessPathId() + "Images";
                path1[2] = @"" + Connection.GetAccessPathId() + "PhotoImages";
                path1[3] = @"" + Connection.GetAccessPathId() + "StudentDocs";

                foreach (string path in path1)
                {
                    if (Directory.Exists(path))
                    {
                        // This path is a directory
                        ProcessDirectory(path);
                    }

                    else
                    {
                        if (path == @"" + Connection.GetAccessPathId() + "Barcodes")
                        {
                            string activeDir = @"" + Connection.GetAccessPathId() + "Barcodes";

                            //Create a new subfolder under the current active folder
                            string newPath = System.IO.Path.Combine(activeDir, "a");

                            // Create the subfolder
                            System.IO.Directory.CreateDirectory(newPath);

                            string newPathb = System.IO.Path.Combine(activeDir, "b");

                            // Create the subfolder
                            System.IO.Directory.CreateDirectory(newPathb);

                            string fileLoc = @"" + Connection.GetAccessPathId() + @"Barcodes\a\sample.txt";
                            FileStream fs = new FileStream(fileLoc, FileMode.Create, FileAccess.ReadWrite);
                            StreamWriter sw = new StreamWriter(fs);
                            sw.Write(Connection.GetConnectionString());

                            sw.Close();
                            fs.Close();

                            string fileLoc1 = @"" + Connection.GetAccessPathId() + @"Barcodes\a\mdst.txt";
                            FileStream fs1 = new FileStream(fileLoc1, FileMode.Create, FileAccess.ReadWrite);
                            StreamWriter sw1 = new StreamWriter(fs1);
                            sw1.Write("0");
                            sw1.Close();
                            fs1.Close();
                        }
                        if (path == @"" + Connection.GetAccessPathId() + "Images")
                        {
                            string activeDir1 = @"" + Connection.GetAccessPathId() + "Images";

                            //Create a new subfolder under the current active folder
                            string newPath1 = System.IO.Path.Combine(activeDir1, "a");

                            // Create the subfolder
                            System.IO.Directory.CreateDirectory(newPath1);

                        }
                        if (path == @"" + Connection.GetAccessPathId() + "PhotoImages")
                        {
                            string activeDir2 = @"" + Connection.GetAccessPathId() + "PhotoImages";

                            //Create a new subfolder under the current active folder
                            string newPath2 = System.IO.Path.Combine(activeDir2, "a");

                            // Create the subfolder
                            System.IO.Directory.CreateDirectory(newPath2);
                        }
                        if (path == @"" + Connection.GetAccessPathId() + "StudentDocs")
                        {
                            string activeDir2 = @"" + Connection.GetAccessPathId() + "StudentDocs";

                            // Create the subfolder
                            System.IO.Directory.CreateDirectory(activeDir2);
                        }
                        //MessageBox.Show ("{0} is not a valid file or directory.", path);
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex); 
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
        }

        private void cmbsession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
                btnok.Focus();
        }

        private void Loginform_Paint(object sender, PaintEventArgs e)
        {
            Connection.ChangeFormBackColor(this, e);
        }

        private void Loginform_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        

    }
}
