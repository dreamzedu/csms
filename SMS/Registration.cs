using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;


namespace SMS
{
    public partial class Registration : Form
    {
       
        public Registration ()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Initialize();
            
        }

        private void Initialize()
        {
             SqlConnection LocalCon = Connection.Conn();
                    if (LocalCon.State != ConnectionState.Open)
                        LocalCon.Open();
            try
            {
                SqlDataReader rd = Connection.GetDataReader("select * from tbl_ProductReg");
                if (rd.Read())
                {
                    school sc = new school();
                    string key = rd["prodkey"].ToString();
                    string user = rd["username"].ToString();
                    string schoolName = rd["schoolname"].ToString();
                    string city = rd["city"].ToString();
                    string branch = rd["branchname"].ToString();

                    pnlActKey.Visible = true;
                    PopulateControls(key, user, schoolName, city, branch);

                    if (key == school.trialProdKey)
                    {
                        btnUseTrial.Enabled = false;
                        int days = GetDaysLeftForTrial();
                        if (days <= 0)
                        {
                            lblTrial.Text = "Your trial has expired. Please activate your product to continue using it.";
                        }
                        else
                        {
                            lblTrial.Text = "Your trial period is left for "+days+" days";
                        }
                    }
                    else
                    {
                        DisableAllControls();
                        lblTrial.Visible = false;

                        lblActive.Text = "Your product is activated";
                    }
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (LocalCon.State == ConnectionState.Open) LocalCon.Close();
            }
        }

        private int GetDaysLeftForTrial()
        {
            int daysLeft = 30;
            SqlConnection LocalCon = Connection.Conn();
            if (LocalCon.State != ConnectionState.Open)
                LocalCon.Open();
            try
            {
                SqlDataReader rd = Connection.GetDataReader("select * from SMSsystem");
                if (rd.Read())
                {
                    long regDate = Convert.ToInt64(rd["RegDate"]);

                    DateTime dt = DateTime.FromBinary(regDate);

                    daysLeft = dt.AddDays(30).Subtract(DateTime.Now).Days+1;

                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (LocalCon.State == ConnectionState.Open) LocalCon.Close();
            }

            return daysLeft;
        }

        private void PopulateControls(string key, string user, string schoolName, string city, string branch)
        {
            txtBranch.Text = branch;
            txtCity.Text = city;
            txtProdKey.Text = key;
            txtSchoolName.Text = schoolName;
            txtUserName.Text = user;
        
        }

        private void DisableAllControls()
        {
            txtBranch.Enabled = false;
            txtCity.Enabled = false;
            txtProdKey.Enabled = false;
            txtSchoolName.Enabled = false;
            txtUserName.Enabled = false;
            btnActProd.Enabled = false;
            btnActivateNow.Enabled = false;
            btnUseTrial.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlActKey.Visible = false;
        }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

         
            
              string ProperCase(string text)
              {
                  if (!string.IsNullOrEmpty(text))
                      return (System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text));
                  else
                      return "";
              }

        
              private void btnActProd_Click(object sender, EventArgs e)
              {
                  pnlActKey.Visible = true;
              }

        private void btnActivateNow_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            { 
                school c= new school();
                string prodKey = c.ConstructProductKey(txtSchoolName.Text.Replace(" ", "").Replace(".", ""),
                    txtCity.Text.Replace(" ", ""), DateTime.Today.Day.ToString(), DateTime.Now.Month.ToString(),
                    DateTime.Now.Year.ToString());
                if (IsValidAttempt())
                {
                    if (prodKey == txtProdKey.Text.Trim().ToUpper())
                    {
                        SqlConnection LocalCon = Connection.Conn();
                        if (LocalCon.State != ConnectionState.Open)
                            LocalCon.Open();
                        SqlTransaction LocalTrn = LocalCon.BeginTransaction();
                        try
                        {

                            DataSet dsSchool = Connection.GetDataSet("select * from tbl_school");

                            if (dsSchool.Tables[0].Rows.Count > 0)
                            {
                                Connection.SqlTransection(
                                    "Update tbl_school set schoolname = '" +
                                    ProperCase(txtSchoolName.Text).Trim().Replace("'", "''") +
                                    "', schoolcity='" + ProperCase(txtCity.Text).Trim() +
                                    "'", LocalCon, LocalTrn);
                            }
                            else
                            {
                                Connection.SqlTransection(
                                    "Insert Into tbl_school (schoolname, schoolcity) values ('" +
                                    ProperCase(txtSchoolName.Text).Trim().Replace("'", "''") +
                                    "', '" + ProperCase(txtCity.Text).Trim() + "')", LocalCon, LocalTrn);
                            }

                            Connection.SqlTransection(
                                "Delete from tbl_ProductReg; Insert Into tbl_ProductReg (schoolname, city, username, branchname,prodkey, regDate) values ('" +
                                ProperCase(txtSchoolName.Text).Trim().Replace("'", "''") +
                                "','" + ProperCase(txtCity.Text).Trim() +
                                "','" + ProperCase(txtUserName.Text).Trim() +
                                "','" + ProperCase(txtBranch.Text).Trim() +
                                "','" + txtProdKey.Text.Trim().ToUpper() +
                                "','" + DateTime.Now.ToShortDateString() +
                                "'" + ")", LocalCon, LocalTrn);


                            long dt = DateTime.Now.ToBinary();
                            SqlCommand cmd = LocalCon.CreateCommand();
                            cmd.CommandText = "Delete from SMSsystem;Insert Into SMSsystem values(@dt,@count,@time)";
                            cmd.Transaction = LocalTrn;

                            long time = 0;
                            cmd.Parameters.Add("@dt", dt);
                            cmd.Parameters.Add("@count", 1);
                            cmd.Parameters.Add("@time", time);

                            cmd.ExecuteNonQuery();

                            LocalTrn.Commit();
                            if (LocalCon.State == ConnectionState.Open)
                                LocalCon.Close();
                            MessageBox.Show("Your product activation is successful.");

                            if (this.Modal)
                            {
                                this.Close();
                            }
                            else
                            {

                                Loginform l = new Loginform();
                                l.Show();
                                this.Hide();
                                l.BringToFront();
                            }

                        }
                        catch (Exception ex)
                        {
                            LocalTrn.Rollback();
                            MessageBox.Show("Some error has occurred. Please Try Again.", "Error");
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid activation key.", "Error");
                        SqlConnection LocalCon = Connection.Conn();
                        if (LocalCon.State != ConnectionState.Open)
                            LocalCon.Open();

                        SqlCommand cmd = LocalCon.CreateCommand();
                        cmd.CommandText = "update tbl_RegAttempt set attempt=attempt+1, date = '" +
                                          DateTime.Now.ToShortDateString() + "'";
                        cmd.ExecuteNonQuery();
                        if (LocalCon.State == ConnectionState.Open)
                            LocalCon.Close();

                    }
                }

            }

        }

        private bool IsValidAttempt()
        {
            DataSet ds = Connection.GetDataSet("select * from tbl_RegAttempt");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dt;

                DateTime.TryParse(ds.Tables[0].Rows[0]["date"].ToString(), out dt);
                int attempt = Convert.ToInt16(ds.Tables[0].Rows[0]["attempt"]);

                if (string.Equals(dt.ToShortDateString(), DateTime.Today.ToShortDateString()))
                {
                    if (attempt >= 5)
                    {
                        MessageBox.Show("You have made more than permissible attempts and your account is blocked now.");
                        return false;
                    }
                }
                else
                {
                    SqlConnection LocalCon = Connection.Conn();
                    if (LocalCon.State != ConnectionState.Open)
                        LocalCon.Open();

                    SqlCommand cmd = LocalCon.CreateCommand();
                    cmd.CommandText = "update tbl_RegAttempt set attempt=1, date = '" +
                                      DateTime.Now.ToShortDateString() + "'";
                    cmd.ExecuteNonQuery();
                    if (LocalCon.State == ConnectionState.Open)
                        LocalCon.Close();
                }
            }
            else
            {
                SqlConnection LocalCon = Connection.Conn();
                if (LocalCon.State != ConnectionState.Open)
                    LocalCon.Open();

                SqlCommand cmd = LocalCon.CreateCommand();
                cmd.CommandText = "insert into tbl_RegAttempt(attempt, date) values(1, '" +
                                  DateTime.Now.ToShortDateString() + "')";
                cmd.ExecuteNonQuery();
                if (LocalCon.State == ConnectionState.Open)
                    LocalCon.Close();
            }
            return true;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtSchoolName.Text) || string.IsNullOrEmpty(txtBranch.Text)
                || string.IsNullOrEmpty(txtCity.Text) || string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Please enter the required fields");
                return false;
            }

            if (txtSchoolName.Text.Replace(" ", "").Replace(".", "").Length < 4)
            {
                MessageBox.Show("School name should have atleast four characters");
                return false;
            }
            if (txtCity.Text.Replace(" ", "").Replace(".", "").Length < 3)
            {
                MessageBox.Show("City name should have atleast three characters");
                return false;
            }

            return true;
        }

        private void btnUseTrial_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                SqlConnection LocalCon = Connection.Conn();
                if (LocalCon.State != ConnectionState.Open)
                    LocalCon.Open();
                SqlTransaction LocalTrn = LocalCon.BeginTransaction();
                try
                {
                    DataSet dsSchool = Connection.GetDataSet("select * from tbl_school");

                    if (dsSchool.Tables[0].Rows.Count > 0)
                    {
                        Connection.SqlTransection(
                            "Update tbl_school set schoolname = '" +
                            ProperCase(txtSchoolName.Text).Trim().Replace("'", "''") +
                            "', schoolcity='" + ProperCase(txtCity.Text).Trim() +
                            "'", LocalCon, LocalTrn);
                    }
                    else
                    {
                        Connection.SqlTransection(
                            "Insert Into tbl_school (schoolname, schoolcity) values ('" +
                            ProperCase(txtSchoolName.Text).Trim().Replace("'", "''") +
                            "', '" + ProperCase(txtCity.Text).Trim() + "')", LocalCon, LocalTrn);
                    }

                    Connection.SqlTransection(
                        "Delete from tbl_ProductReg; Insert Into tbl_ProductReg (schoolname, city, username, branchname,prodkey, regDate) values ('" +
                        ProperCase(txtSchoolName.Text).Trim().Replace("'", "''") +
                        "','" + ProperCase(txtCity.Text).Trim() +
                        "','" + ProperCase(txtUserName.Text).Trim() +
                        "','" + ProperCase(txtBranch.Text).Trim() +
                        "','" + school.trialProdKey +
                        "','" + DateTime.Now.ToShortDateString() +
                        "'" + ")", LocalCon, LocalTrn);


                    long dt = DateTime.Now.ToBinary();
                    SqlCommand cmd = LocalCon.CreateCommand();
                    cmd.CommandText = "Delete from SMSsystem;Insert Into SMSsystem values(@dt,@count,@time)";
                    cmd.Transaction = LocalTrn;
                    long time = 0;
                    cmd.Parameters.Add("@dt", dt);
                    cmd.Parameters.Add("@count", 1);
                    cmd.Parameters.Add("@time", time);

                    cmd.ExecuteNonQuery();
                    LocalTrn.Commit();

                    Loginform l = new Loginform();
                    l.Show();
                    this.Hide();
                    l.BringToFront();

                }
                catch (Exception ex)
                {
                    LocalTrn.Rollback();
                    MessageBox.Show("Some error has occurred. Please Try Again.", "Error");
                }

            }
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
            
    }
}
