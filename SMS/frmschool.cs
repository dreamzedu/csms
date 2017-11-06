using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;


namespace SMS
{
    public partial class frmschool :UserControlBase
    {
        school1 c = new school1();
        private string PicturePath;
        private string PicturePath_HOE;
        private string PicturePath_PRIN;
        Boolean add_edit = false;
        public frmschool()
        {
            InitializeComponent();
            Connection.SetUserControlTheme(this);
        }
        private void frmschool_Load(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                BtnHOE.Enabled = false;
                BtnPrincipal.Enabled = false;
                c.GetMdiParent(this).EnableAllEditMenuButtons();
                
                c.getconnstr();
                c.GetMdiParent(this).ToggleNewButton(false);
                c.GetMdiParent(this).ToggleDeleteButton(false);
                //c.showdata("tbl_school", c.myconn, this, "schoolname", "schoolname");
                DataSet ds = Connection.GetDataSet("SELECT schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, "+
                    " principal, registrationno, logoimage, Website, MessageService, MessageSenderID, "+
                    " MessageUserName, MessagePassword, SchoolCode,HOESIGN,PRINSIGN FROM tbl_school");
                txtinstitute.Text = ds.Tables[0].Rows[0]["schoolname"].ToString();
                txtaddress.Text = ds.Tables[0].Rows[0]["schooladdress"].ToString();
                txtcity.Text = ds.Tables[0].Rows[0]["schoolcity"].ToString();
                txtphone.Text = ds.Tables[0].Rows[0]["schoolphone"].ToString();
                txtaffiliate.Text = ds.Tables[0].Rows[0]["affiliate_by"].ToString();
                txtprincipal.Text = ds.Tables[0].Rows[0]["principal"].ToString();
                txtregno.Text = ds.Tables[0].Rows[0]["registrationno"].ToString();
                byte[] reading = (byte[])ds.Tables[0].Rows[0]["logoimage"];
                MemoryStream ms = new MemoryStream(reading);
                logo_image.Image = Image.FromStream(ms);
                reading = (byte[])ds.Tables[0].Rows[0]["HOESIGN"];
                ms = new MemoryStream(reading);
                ImgHoe.Image = Image.FromStream(ms);
                reading = (byte[])ds.Tables[0].Rows[0]["PRINSIGN"];
                ms = new MemoryStream(reading);
                ImgPrinc.Image = Image.FromStream(ms);
                txtWebsite.Text = ds.Tables[0].Rows[0]["Website"].ToString();
                txtSchoolCode.Text = ds.Tables[0].Rows[0]["SchoolCode"].ToString();
                //byte[] reading1 = (byte[])ds.Tables[0].Rows[0][35];
                //MemoryStream mss = new MemoryStream(reading1);
                //p2.Image = Image.FromStream(mss);
            }
            catch (Exception ex)
            {
            }
            
        }
        public override void btnnew_Click(object sender, EventArgs e)
        {
            DesignForm.fromDesign2(this);       
            add_edit = true;
            c.cleartext(this);
            c.GetMdiParent(this).DisableAllEditMenuButtons();
            //add_edit = true;
            //c.cleartext(this);
            //c.btndisable(btnnew,btnedit,btndelete,btnsave,btncancel,btnprint,null);
            txtinstitute.Focus();
        }
        public override void btncancel_Click(object sender, EventArgs e)
        {
            add_edit = false;
            button1.Enabled = false ;
            BtnHOE.Enabled = false;
            BtnPrincipal.Enabled = false;
            c.GetMdiParent(this).EnableAllEditMenuButtons();

            c.GetMdiParent(this).ToggleDeleteButton(false);
            c.GetMdiParent(this).ToggleNewButton(false);
        }
        public override void btnedit_Click(object sender, EventArgs e)
        {
            //int i = Connection.UserCheck("tbl_school");
            //if (i == 0)
            //{
                DesignForm.fromDesign2(this);
                txtinstitute.Enabled = false;
                txtcity.Enabled = false;
                button1.Enabled = true;
                BtnHOE.Enabled = true;
                BtnPrincipal.Enabled = true;
                add_edit = false;
                c.GetMdiParent(this).DisableAllEditMenuButtons();
                //txtinstitute.Focus();
               // Connection.UserEntery(Connection.username, "tbl_school");
            //}
            //else
            //{
                //MessageBox.Show("This Information is accessed by another user Please wait..");
           // }
        }
        private void btnexit_Click(object sender, EventArgs e)
        {
          
            //Connection.deleteUserEntery(Connection.username);
            //this.Close();
        }
        private void txtinstitute_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);          
        }
        private static Image resizeImage(byte[] tbimg, Size size)
        {

            Image imgToResize;

            MemoryStream ms = new MemoryStream(tbimg);
            imgToResize = Image.FromStream(ms);
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }

        public bool Limit(string path)
        {
            if (path == null)
            {
                return true;

            }
            {
                //-------
                System.Drawing.Size s1 = new Size();
                s1.Height = 600;
                s1.Width = 500;
                const int limit = 50; float size = 0.0f;
                Image imgToResize;
                imgToResize = frmschool.resizeImage(ToByteArray(path), s1);
                //-------------
                MemoryStream ms = new MemoryStream();
                imgToResize.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                size = ms.ToArray().Length / 1024f;
                size = ToByteArray(path).Length / 1024f;
                if (size > limit)
                {
                    size = ms.ToArray().Length / 1024f;
                    if (size > limit)
                    {
                        MessageBox.Show("Uploading image size should be less then or equal to \n\n                50KB.");
                        return false;
                    }
                    else
                        return true;
                }
                return true;
            }
        }

        public byte[] ToByteArray(string path)
        { byte[] buffer = File.ReadAllBytes(path); return buffer; }
        public void Update_HOESIGN()
        {
            if (PicturePath_HOE != null)
            {
                if (Limit(PicturePath_HOE))
                {
                    FileStream fs1;
                    fs1 = new FileStream(PicturePath_HOE, FileMode.Open, FileAccess.Read);
                    //a byte array to read the image
                    byte[] picbyte1 = new byte[fs1.Length];
                    fs1.Read(picbyte1, 0, System.Convert.ToInt32(fs1.Length));
                    System.Threading.Thread.Sleep(1000);
                    fs1.Flush();
                    fs1.Close();
                    string str1 = "Update tbl_school set HOESIGN=@simage  ";
                    SqlConnection con = Connection.Conn();
                    SqlCommand cmd = new SqlCommand(str1, con);

                    cmd.Parameters.AddWithValue("@simage", picbyte1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public void Update_PEINCSIGN()
        {
            if (PicturePath_PRIN != null)
            {
                if (Limit(PicturePath_PRIN))
                {
                    FileStream fs1;
                    fs1 = new FileStream(PicturePath_PRIN, FileMode.Open, FileAccess.Read);
                    //a byte array to read the image
                    byte[] picbyte1 = new byte[fs1.Length];
                    fs1.Read(picbyte1, 0, System.Convert.ToInt32(fs1.Length));
                    System.Threading.Thread.Sleep(1000);
                    fs1.Flush();
                    fs1.Close();
                    string str1 = "Update tbl_school set PRINSIGN=@simage  ";
                    SqlConnection con = Connection.Conn();
                    SqlCommand cmd = new SqlCommand(str1, con);

                    cmd.Parameters.AddWithValue("@simage", picbyte1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        public override void btnsave_Click(object sender, EventArgs e)
        {
            if (add_edit == true)
            {
                Connection.AllPerform("insert into tbl_school(schoolname, schooladdress, schoolcity, schoolphone, affiliate_by, principal, registrationno,Website,SchoolCode) values('" + txtinstitute.Text + "','" + txtaddress.Text + "','" + txtcity.Text + "','" + txtphone.Text + "','" + txtaffiliate.Text + "','" + txtprincipal.Text + "','" + txtregno.Text + "','"+txtWebsite.Text.Trim ()+"', '"+txtSchoolCode.Text .Trim ()+"')");

                // c.insertdata("tbl_school", c.myconn, this);
            }
            if (add_edit == false)
            {
                if (PicturePath != null)
                {
                    FileStream fs1;
                    fs1 = new FileStream(PicturePath, FileMode.Open, FileAccess.Read);
                    //a byte array to read the image
                    byte[] picbyte1 = new byte[fs1.Length];
                    fs1.Read(picbyte1, 0, System.Convert.ToInt32(fs1.Length));
                    System.Threading.Thread.Sleep(1000);
                    fs1.Flush();
                    fs1.Close();

                    Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Size.Width, Screen.PrimaryScreen.Bounds.Size.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                    g.Save();
                    bmp.Save(@"" + Connection.GetAccessPathId() + @"Images\" + txtinstitute.Text + ".jpg", ImageFormat.Bmp);

                    Bitmap oBitmap = new Bitmap(PicturePath);
                    Graphics oGraphic = Graphics.FromImage(oBitmap);
                    oBitmap.Save(@"" + Connection.GetAccessPathId() + @"Images\" + txtinstitute.Text + ".jpg", ImageFormat.Jpeg);
                    oBitmap.Dispose();
                    oGraphic.Dispose();
                    string str1 = "Update tbl_school set LOGOimage=@simage  ";
                    SqlConnection con = Connection.Conn();
                    SqlCommand cmd = new SqlCommand(str1, con);

                    cmd.Parameters.AddWithValue("@simage", picbyte1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Update_HOESIGN();
                Update_PEINCSIGN();

                //Connection.AllPerform("update tbl_school set  schoolname='" + txtinstitute.Text + "',schooladdress='" + txtaddress.Text + "',schoolcity='" + txtcity.Text + "',schoolphone='" + txtphone.Text + "',affiliate_by='" + txtaffiliate.Text + "',principal='" + txtprincipal.Text + "',registrationno='" + txtregno.Text + "',Website='" + txtWebsite.Text.Trim() + "', SchoolCode = '"+txtSchoolCode.Text.Trim()+"'");
                string updateqry = "update tbl_school set  schoolname=@schoolname,schooladdress=@schooladdress,schoolcity=@schoolcity,schoolphone=@schoolphone,affiliate_by=@affiliate_by,principal=@principal,registrationno=@registrationno,Website=@Website,SchoolCode=@SchoolCode";
                SqlConnection conu = Connection.Conn();
                SqlCommand cmdu = new SqlCommand(updateqry, conu);
                cmdu.Parameters.AddWithValue("@schoolname", txtinstitute.Text.Trim());
                cmdu.Parameters.AddWithValue("@schooladdress", txtaddress.Text.Trim());
                cmdu.Parameters.AddWithValue("@schoolcity", txtcity.Text.Trim());
                cmdu.Parameters.AddWithValue("@schoolphone", txtphone.Text.Trim());
                cmdu.Parameters.AddWithValue("@affiliate_by", txtaffiliate.Text.Trim());
                cmdu.Parameters.AddWithValue("@principal", txtprincipal.Text.Trim());
                cmdu.Parameters.AddWithValue("@registrationno", txtregno.Text.Trim());
                cmdu.Parameters.AddWithValue("@Website", txtWebsite.Text.Trim());
                cmdu.Parameters.AddWithValue("@SchoolCode", txtSchoolCode.Text.Trim());
                conu.Open();
                cmdu.ExecuteNonQuery();
                conu.Close();
                //c.connectsql("insert into tbl_classstudent (studentno,classno,sessioncode) values ('" + txtstudentno.Text + "','" + classno + "','" + valcmbsession.SelectedValue + "')", c.myconn, trn);
            } 
            MessageBox.Show("Record Saved...", "School");
            c.GetMdiParent(this).EnableAllEditMenuButtons();
            
            c.GetMdiParent(this).ToggleNewButton(false);
            c.GetMdiParent(this).ToggleDeleteButton(false);
            DesignForm.fromDesign1(this);
        }

        private void txtrelagularfeemonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            c.entertotab(e.KeyChar);
            e.KeyChar = c.CHECKDECIMAL(e); 
        }

        private void frmschool_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') )
            {
                e.Handled = true;
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    Image image1 = Image.FromFile(openFileDialog1.FileName);
                    logo_image .Image = image1;
                    PicturePath = openFileDialog1.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmschool_Paint(object sender, PaintEventArgs e)
        {
            ////public static void fromClear(Form f);
        }

        private void BtnHOE_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    Image image1 = Image.FromFile(openFileDialog1.FileName);
                    ImgHoe.Image = image1;
                    PicturePath_HOE = openFileDialog1.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnPrincipal_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    Image image1 = Image.FromFile(openFileDialog1.FileName);
                    ImgPrinc.Image = image1;
                    PicturePath_PRIN = openFileDialog1.FileName;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
        
       
    }
}
