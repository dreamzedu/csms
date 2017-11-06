using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SMS
{
    public partial class Splash : Form
    {
        //P = "mb9RGQpVyIXz2VsqOWhF4Q=="
        private int i;

        public Splash()
        {
            InitializeComponent();

        }

        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblApplicationVer.Text = "Version " + Application.ProductVersion;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(35);
            if (progressBar1.Value == 1000) timer1.Stop();
            i = i + 1;
            if (i > 3)
            {
                timer1.Stop();
                //CheckForSubcription();

                GoToLogin();
            }
        }

        private void GoToLogin()
        {
            Loginform lf = new Loginform();
            this.Hide();
            lf.Show();
            lf.BringToFront();
        }

        private void CheckForSubcription()
        {
            DataSet dschk = Connection.GetDataSet("Select * from tbl_ProductReg ");
            if (dschk.Tables[0].Rows.Count < 1)
            {
                Registration r = new Registration();
                this.Hide();
                r.Show();
                r.BringToFront();
            }
            else
            {
                if (dschk.Tables[0].Rows[0]["prodkey"] == null || string.Equals(dschk.Tables[0].Rows[0]["prodkey"] , school.trialProdKey) || string.IsNullOrEmpty(dschk.Tables[0].Rows[0]["prodkey"].ToString()))
                {
                    DataSet dsTrial = Connection.GetDataSet("Select * from SMSsystem ");
                    long regDate = Convert.ToInt64(dsTrial.Tables[0].Rows[0]["RegDate"]);

                    DateTime dt = DateTime.FromBinary(regDate);
                    long runTime = Convert.ToInt64(dsTrial.Tables[0].Rows[0]["RunTime"]);

                    int daysLeft = dt.AddDays(30).Subtract(DateTime.Now).Days + 1;

                    int runCount = Convert.ToInt32(dsTrial.Tables[0].Rows[0]["RunCount"]);

                    int daysUsed = dt.AddSeconds(runTime).Subtract(dt).Days;

                    if (daysLeft <= 0 || daysUsed > 30 || runCount > 45)
                    {
                        this.Hide();
                        MessageBox.Show("Your trial subscription has ended. Please activate your product.", "Subscription Ended", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Registration r = new Registration();
                        r.Show();
                        r.BringToFront();
                    }
                    else if (daysLeft < 15)
                    {
                        if (MessageBox.Show(
                            "Your trial will end in " + daysLeft + " days. Would you like to activate your product now?",
                            "Alert", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.Hide();
                            Registration r = new Registration();
                            r.Show();
                            r.BringToFront();
                        }
                        else
                        {
                            Loginform lf = new Loginform();
                            this.Hide();
                            lf.Show();
                            lf.BringToFront();
                        }

                    }
                    else
                    {
                        Loginform lf = new Loginform();
                        this.Hide();
                        lf.Show();
                        lf.BringToFront();
                    }
                }

                else
                {
                    DataSet dsSchool = Connection.GetDataSet("Select schoolname, schoolcity from tbl_school ");

                    DataSet dsTrial = Connection.GetDataSet("Select * from SMSsystem ");
                    long regDate = Convert.ToInt64(dsTrial.Tables[0].Rows[0]["RegDate"]);

                    DateTime dt = DateTime.FromBinary(regDate);

                    school sc = new school();
                    string pKey = sc.ConstructProductKey(dsSchool.Tables[0].Rows[0]["schoolname"].ToString().Replace(" ", "").Replace(".", ""),
                        dsSchool.Tables[0].Rows[0]["schoolcity"].ToString().Replace(" ", ""), dt.Day.ToString(), dt.Month.ToString(), dt.Year.ToString());

                    if (string.Equals(dschk.Tables[0].Rows[0]["prodkey"] , pKey))
                    {
                        DateTime dtnew = DateTime.Now;
                        TimeSpan t = dtnew.Subtract(dt);
                        int k = t.Days;
                        if (k > 365)
                        {
                            MessageBox.Show("Your Subscription has expired.");
                            Help r = new Help();
                            r.Show();
                            this.Hide();
                            r.BringToFront();
                        }
                        else
                        {
                            if (k > 350 && k < 365)
                            {
                                int l1 = 365 - k;
                                MessageBox.Show("Number of days left " + l1.ToString() +
                                                ", please renew your Subscription.");
                            }

                            Loginform lf = new Loginform();
                            this.Hide();
                            lf.Show();
                            lf.BringToFront();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Your Product Key is invalid. Please contact our support team for help.");
                        Help r = new Help();
                        r.Show();
                        this.Hide();
                        r.BringToFront();
                    }
                }
            }

        }
    }
}

