using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Drawing;
using Button = System.Windows.Forms.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;
using TextBox = System.Windows.Forms.TextBox;


namespace SMS
{
    class DesignForm
    {

        public static void fromDesign(Form f)
        {
            f.BackColor = Color.FromArgb(146, 171, 189); //this code works
            f.Opacity =95;
            f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            f.ControlBox = false;

             float widthRatio = Screen.PrimaryScreen.Bounds.Width / 1024;
            float heightRatio = Screen.PrimaryScreen.Bounds.Height / 768f;
            SizeF scale = new SizeF(widthRatio, heightRatio);
            f.Scale(scale);


            foreach (Control cont in f.Controls)
            {

                //f.BackColor=new System .Drawing .Color(146, 171, 189);
              //  cont.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                if (cont is Label)
                {
                    Label l = (Label)cont;
                    //if (cont is GroupBox)
                    {
                        foreach (Control contt in cont.Controls)
                        {
                           // cont.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                            if (contt is Label)
                            {
                                Label ll = (Label)contt;
                                //ll.Font = new System.Drawing.Font("Arial", ll.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                ll.Font = new System.Drawing.Font("Arial", f.Font.Size, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                               
                                ll.ForeColor = Color.White;
                            }
                            if (contt is Button)
                            {
                                Button ll = (Button)contt;
                                ll.Font = new System.Drawing.Font("Candara", ll.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                                ll.ForeColor = Color.MidnightBlue;
                                ll.BackColor = Color.Transparent;
                                ll.TextAlign = ContentAlignment.MiddleCenter;
                                ll.FlatStyle = FlatStyle.Standard;
                                ll.BackgroundImage = null;
                            }
                        }
                    }
                   // l.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                   // l.ForeColor = Color.Red;
                }
                //------------------- 
                if (cont is Button)
                {
                   // cont.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                    Button l = (Button)cont;
                    // Candara, 11.25pt, style=Bold
                    l.Font = new System.Drawing.Font("Candara", l.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    l.ForeColor = Color.MidnightBlue;
                    l.BackColor = Color.Transparent;
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.FlatStyle = FlatStyle.Standard;
                    l.BackgroundImage = null;
                }

                //----------------
                if (cont is TextBox)
                {
                    TextBox l = (TextBox)cont;
                    l.ForeColor = Color.Black;
                }
                //------------------- 

                if (cont is Label)
                {
                    Label l = (Label)cont;
                  //  cont.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                    l.Font = new System.Drawing.Font("Arial", l.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    l.ForeColor = Color.White;
                    l.BackColor = Color.Transparent;
                }
                //------------

                if (cont is GroupBox)
                {
                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is Label)
                        {
                            Label l = (Label)contt;
                           // cont.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                            l.Font = new System.Drawing.Font("Arial", l.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            l.ForeColor = Color.White;
                        }
                        if (contt is Button)
                        {
                            Button l = (Button)contt;
                           // cont.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                            l.Font = new System.Drawing.Font("Candara", l.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            l.ForeColor = Color.MidnightBlue;
                            l.BackColor = Color.Transparent;
                            l.TextAlign = ContentAlignment.MiddleCenter;
                            l.FlatStyle = FlatStyle.Standard;
                            l.BackgroundImage = null;
                        }
                    }
                }
                if (cont is Panel)
                {
                    cont.BackColor = Color.FromArgb(146, 171, 189); //this code works
                    Panel p = (Panel)cont;
                    p.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is Label)
                        {
                            Label l = (Label)contt;
                          //  cont.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                            l.Font = new System.Drawing.Font("Arial", l.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            l.ForeColor = Color.White;
                        }
                        if (contt is Button)
                        {
                            Button l = (Button)contt;
                           // cont.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                            l.Font = new System.Drawing.Font("Candara", l.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            l.ForeColor = Color.MidnightBlue;
                            l.BackColor = Color.Transparent;
                            l.TextAlign = ContentAlignment.MiddleCenter;
                            l.FlatStyle = FlatStyle.Standard;
                            l.BackgroundImage = null;
                        }
                    }
                }
                //------------------- 
                if (cont is TabControl)
                {
                    TabControl t = (TabControl)cont;
                    t.BackColor = Color.FromArgb(146, 171, 189);
                    foreach (Control conttt in cont.Controls)
                    {
                        if (conttt is Label)
                        {
                            Label l = (Label)conttt;
                           // conttt.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                            l.Font = new System.Drawing.Font("Arial", l.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            l.ForeColor = Color.White;
                        }
                        if (conttt is Button)
                        {
                            Button l = (Button)conttt;
                           // conttt.Font = new Font("Arial", cont.Font.SizeInPoints * heightRatio * widthRatio);
                            l.Font = new System.Drawing.Font("Candara", l.Font.SizeInPoints * heightRatio * widthRatio, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                            l.ForeColor = Color.MidnightBlue;
                            l.BackColor = Color.Transparent;
                            l.TextAlign = ContentAlignment.MiddleCenter;
                        }
                    }
                }


                ///---------------------

            }
           // foreach (Control control in f.Controls)
           // {
               // control.Font = new Font("Verdana", control.Font.SizeInPoints * heightRatio * widthRatio);
          //  }
           
        }




        ///////////////////////////////


        public static void fromDesign1(Form f)
        {
            //f.BackColor = Color.FromArgb(146, 171, 189); //this code works
            //f.Opacity = 95;
            //f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //f.ControlBox = false;

            foreach (Control cont in f.Controls)
            {

                //f.BackColor=new System .Drawing .Color(146, 171, 189);

               
               
                if (cont is TextBox)
                {
                    TextBox l = (TextBox)cont;
                    l.Enabled = false;
                    l.ForeColor = Color.Black;
                }
                if (cont is ComboBox )
                {
                    ComboBox  l = (ComboBox )cont;
                    l.Enabled = false;
                    l.ForeColor = Color.Black;
                }
                if (cont is DateTimePicker)
                {
                    DateTimePicker d = (DateTimePicker)cont;
                    d.Enabled = false;
                    d.ForeColor = Color.Black;
                }
                if (cont is CheckBox)
                {
                    CheckBox c = (CheckBox)cont;
                    c.Enabled = false;
                  
                }

                if (cont is GroupBox)
                {
                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Enabled = false;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is ComboBox )
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Enabled = false;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is DateTimePicker)
                        {
                            DateTimePicker d = (DateTimePicker)contt;
                            d.Enabled = false;
                            d.ForeColor = Color.Black;
                        }
                        if (contt is CheckBox)
                        {
                            CheckBox c = (CheckBox)contt;
                            c.Enabled = false;
                           
                        }
                       
                    }
                }
                if (cont is Panel)
                {
                    
                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Enabled = false;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Enabled = false;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is DateTimePicker)
                        {
                            DateTimePicker d = (DateTimePicker)contt;
                            d.Enabled = false;
                            d.ForeColor = Color.Black;
                        }
                        if (contt is CheckBox)
                        {
                            CheckBox c = (CheckBox)contt;
                            c.Enabled = false;
                           
                        }
                    }
                }
                //------------------- 
                int i = 0;
                if (cont is TabControl)
                {
                     TabControl   PNL = (TabControl)cont;
                     foreach (TabPage tpg in PNL.TabPages)
                     {
                         foreach (Control contt in PNL.TabPages[i].Controls)
                         {

                             if (contt is TextBox)
                             {
                                 TextBox l = (TextBox)contt;
                                 l.Enabled = false;
                                 l.ForeColor = Color.Black;
                             }
                             if (contt is ComboBox)
                             {
                                 ComboBox l = (ComboBox)contt;
                                 l.Enabled = false;
                                 l.ForeColor = Color.Black;
                             }
                             if (contt is DateTimePicker)
                             {
                                 DateTimePicker d = (DateTimePicker)contt;
                                 d.Enabled = false;
                                 d.ForeColor = Color.Black;
                             }
                             if (contt is CheckBox)
                             {
                                 CheckBox c = (CheckBox)contt;
                                 c.Enabled = false;
                                 
                             }
                             
                         }
                         i++;
                     }
                }


                ///---------------------

            }

        }

        public static void fromDesign1(UserControl f)
        {
            //f.BackColor = Color.FromArgb(146, 171, 189); //this code works
            //f.Opacity = 95;
            //f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //f.ControlBox = false;

            foreach (Control cont in f.Controls)
            {

                //f.BackColor=new System .Drawing .Color(146, 171, 189);



                if (cont is TextBox)
                {
                    TextBox l = (TextBox)cont;
                    l.Enabled = false;
                    l.ForeColor = Color.Black;
                }
                if (cont is ComboBox)
                {
                    ComboBox l = (ComboBox)cont;
                    l.Enabled = false;
                    l.ForeColor = Color.Black;
                }
                if (cont is DateTimePicker)
                {
                    DateTimePicker d = (DateTimePicker)cont;
                    d.Enabled = false;
                    d.ForeColor = Color.Black;
                }
                if (cont is CheckBox)
                {
                    CheckBox c = (CheckBox)cont;
                    c.Enabled = false;

                }

                if (cont is GroupBox)
                {
                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Enabled = false;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Enabled = false;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is DateTimePicker)
                        {
                            DateTimePicker d = (DateTimePicker)contt;
                            d.Enabled = false;
                            d.ForeColor = Color.Black;
                        }
                        if (contt is CheckBox)
                        {
                            CheckBox c = (CheckBox)contt;
                            c.Enabled = false;

                        }

                    }
                }
                if (cont is Panel)
                {

                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Enabled = false;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Enabled = false;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is DateTimePicker)
                        {
                            DateTimePicker d = (DateTimePicker)contt;
                            d.Enabled = false;
                            d.ForeColor = Color.Black;
                        }
                        if (contt is CheckBox)
                        {
                            CheckBox c = (CheckBox)contt;
                            c.Enabled = false;

                        }
                    }
                }
                //------------------- 
                int i = 0;
                if (cont is TabControl)
                {
                    TabControl PNL = (TabControl)cont;
                    foreach (TabPage tpg in PNL.TabPages)
                    {
                        foreach (Control contt in PNL.TabPages[i].Controls)
                        {

                            if (contt is TextBox)
                            {
                                TextBox l = (TextBox)contt;
                                l.Enabled = false;
                                l.ForeColor = Color.Black;
                            }
                            if (contt is ComboBox)
                            {
                                ComboBox l = (ComboBox)contt;
                                l.Enabled = false;
                                l.ForeColor = Color.Black;
                            }
                            if (contt is DateTimePicker)
                            {
                                DateTimePicker d = (DateTimePicker)contt;
                                d.Enabled = false;
                                d.ForeColor = Color.Black;
                            }
                            if (contt is CheckBox)
                            {
                                CheckBox c = (CheckBox)contt;
                                c.Enabled = false;

                            }

                        }
                        i++;
                    }
                }


                ///---------------------

            }

        }
        
        
        ////////////////////////////////////////////////////////////



        public static void fromDesign2(Form f)
        {
            //f.BackColor = Color.FromArgb(146, 171, 189); //this code works
            //f.Opacity = 95;
            //f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //f.ControlBox = false;

            foreach (Control cont in f.Controls)
            {

                //f.BackColor=new System .Drawing .Color(146, 171, 189);



                if (cont is TextBox)
                {
                    TextBox l = (TextBox)cont;
                    l.Enabled = true;
                    l.ForeColor = Color.Black;
                }
                if (cont is ComboBox)
                {
                    ComboBox l = (ComboBox)cont;
                    l.Enabled = true;
                    l.ForeColor = Color.Black;
                }
                if (cont is DateTimePicker)
                {
                    DateTimePicker d = (DateTimePicker)cont;
                    d.Enabled = true;
                    d.ForeColor = Color.Black;
                }
                if (cont is CheckBox)
                {
                    CheckBox c = (CheckBox)cont;
                    c.Enabled = true;
                    
                }
                if (cont is GroupBox)
                {
                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Enabled = true;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Enabled = true;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is DateTimePicker)
                        {
                            DateTimePicker d = (DateTimePicker)contt;
                            d.Enabled = true;
                            d.ForeColor = Color.Black;
                        }
                        if (contt is CheckBox)
                        {
                            CheckBox c = (CheckBox)contt;
                            c.Enabled = true;
                           
                        }
                    }
                }
                if (cont is Panel)
                {

                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Enabled = true;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Enabled = true;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is DateTimePicker)
                        {
                            DateTimePicker d = (DateTimePicker)contt;
                            d.Enabled = true;
                            d.ForeColor = Color.Black;
                        }
                        if (contt is CheckBox)
                        {
                            CheckBox c = (CheckBox)contt;
                            c.Enabled = true;
                            
                        }
                    }
                }
                //------------------- 
                int i = 0;
                if (cont is TabControl)
                {
                    TabControl PNL = (TabControl)cont;
                    foreach (TabPage tpg in PNL.TabPages)
                    {
                        foreach (Control contt in PNL.TabPages[i].Controls)
                        {

                            if (contt is TextBox)
                            {
                                TextBox l = (TextBox)contt;
                                l.Enabled = true;
                                l.ForeColor = Color.Black;
                            }
                            if (contt is ComboBox)
                            {
                                ComboBox l = (ComboBox)contt;
                                l.Enabled = true;
                                l.ForeColor = Color.Black;
                            }
                            if (contt is DateTimePicker)
                            {
                                DateTimePicker d = (DateTimePicker)contt;
                                d.Enabled = true;
                                d.ForeColor = Color.Black;
                            }
                            if (contt is CheckBox)
                            {
                                CheckBox c = (CheckBox)contt;
                                c.Enabled = true;
                                
                            }
                            
                        }
                        i++;
                    }
                }


                ///---------------------

            }

        }

        public static void fromDesign2(UserControl f)
        {
            //f.BackColor = Color.FromArgb(146, 171, 189); //this code works
            //f.Opacity = 95;
            //f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //f.ControlBox = false;

            foreach (Control cont in f.Controls)
            {

                //f.BackColor=new System .Drawing .Color(146, 171, 189);



                if (cont is TextBox)
                {
                    TextBox l = (TextBox)cont;
                    l.Enabled = true;
                    l.ForeColor = Color.Black;
                }
                if (cont is ComboBox)
                {
                    ComboBox l = (ComboBox)cont;
                    l.Enabled = true;
                    l.ForeColor = Color.Black;
                }
                if (cont is DateTimePicker)
                {
                    DateTimePicker d = (DateTimePicker)cont;
                    d.Enabled = true;
                    d.ForeColor = Color.Black;
                }
                if (cont is CheckBox)
                {
                    CheckBox c = (CheckBox)cont;
                    c.Enabled = true;

                }
                if (cont is GroupBox)
                {
                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Enabled = true;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Enabled = true;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is DateTimePicker)
                        {
                            DateTimePicker d = (DateTimePicker)contt;
                            d.Enabled = true;
                            d.ForeColor = Color.Black;
                        }
                        if (contt is CheckBox)
                        {
                            CheckBox c = (CheckBox)contt;
                            c.Enabled = true;

                        }
                    }
                }
                if (cont is Panel)
                {

                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Enabled = true;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Enabled = true;
                            l.ForeColor = Color.Black;
                        }
                        if (contt is DateTimePicker)
                        {
                            DateTimePicker d = (DateTimePicker)contt;
                            d.Enabled = true;
                            d.ForeColor = Color.Black;
                        }
                        if (contt is CheckBox)
                        {
                            CheckBox c = (CheckBox)contt;
                            c.Enabled = true;

                        }
                    }
                }
                //------------------- 
                int i = 0;
                if (cont is TabControl)
                {
                    TabControl PNL = (TabControl)cont;
                    foreach (TabPage tpg in PNL.TabPages)
                    {
                        foreach (Control contt in PNL.TabPages[i].Controls)
                        {

                            if (contt is TextBox)
                            {
                                TextBox l = (TextBox)contt;
                                l.Enabled = true;
                                l.ForeColor = Color.Black;
                            }
                            if (contt is ComboBox)
                            {
                                ComboBox l = (ComboBox)contt;
                                l.Enabled = true;
                                l.ForeColor = Color.Black;
                            }
                            if (contt is DateTimePicker)
                            {
                                DateTimePicker d = (DateTimePicker)contt;
                                d.Enabled = true;
                                d.ForeColor = Color.Black;
                            }
                            if (contt is CheckBox)
                            {
                                CheckBox c = (CheckBox)contt;
                                c.Enabled = true;

                            }

                        }
                        i++;
                    }
                }


                ///---------------------

            }

        }


        ///////////////////////////////


        public static void fromClear(Form f)
        {
            //f.BackColor = Color.FromArgb(146, 171, 189); //this code works
            //f.Opacity = 95;
            //f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //f.ControlBox = false;

            foreach (Control cont in f.Controls)
            {

                //f.BackColor=new System .Drawing .Color(146, 171, 189);



                if (cont is TextBox)
                {
                    TextBox l = (TextBox)cont;
                    l.Clear();
                }
                if (cont is ComboBox)
                {
                    ComboBox l = (ComboBox)cont;
                    l.Text = "";
                }


                if (cont is GroupBox)
                {
                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Clear();
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Text = "";
                        }


                    }
                }
                if (cont is Panel)
                {

                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Clear();
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Text = "";
                        }

                    }
                }
                //------------------- 
                int i = 0;
                if (cont is TabControl)
                {
                    TabControl PNL = (TabControl)cont;
                    foreach (TabPage tpg in PNL.TabPages)
                    {
                        foreach (Control contt in PNL.TabPages[i].Controls)
                        {

                            if (contt is TextBox)
                            {
                                TextBox l = (TextBox)contt;
                                l.Clear();
                            }
                            if (contt is ComboBox)
                            {
                                ComboBox l = (ComboBox)contt;
                                l.Text = "";
                            }
                        }
                    }
                }


                ///---------------------

            }

        }

        public static void fromClear(UserControl f)
        {
            //f.BackColor = Color.FromArgb(146, 171, 189); //this code works
            //f.Opacity = 95;
            //f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //f.ControlBox = false;

            foreach (Control cont in f.Controls)
            {

                //f.BackColor=new System .Drawing .Color(146, 171, 189);



                if (cont is TextBox)
                {
                    TextBox l = (TextBox)cont;
                    l.Clear();
                }
                if (cont is ComboBox)
                {
                    ComboBox l = (ComboBox)cont;
                    l.Text = "";
                }


                if (cont is GroupBox)
                {
                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Clear();
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Text = "";
                        }


                    }
                }
                if (cont is Panel)
                {

                    foreach (Control contt in cont.Controls)
                    {
                        if (contt is TextBox)
                        {
                            TextBox l = (TextBox)contt;
                            l.Clear();
                        }
                        if (contt is ComboBox)
                        {
                            ComboBox l = (ComboBox)contt;
                            l.Text = "";
                        }

                    }
                }
                //------------------- 
                int i = 0;
                if (cont is TabControl)
                {
                    TabControl PNL = (TabControl)cont;
                    foreach (TabPage tpg in PNL.TabPages)
                    {
                        foreach (Control contt in PNL.TabPages[i].Controls)
                        {

                            if (contt is TextBox)
                            {
                                TextBox l = (TextBox)contt;
                                l.Clear();
                            }
                            if (contt is ComboBox)
                            {
                                ComboBox l = (ComboBox)contt;
                                l.Text = "";
                            }
                        }
                    }
                }


                ///---------------------

            }

        }


    }

     
}
