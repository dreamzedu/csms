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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
            //DesignForm.fromDesign(this);
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("http://www.jsprsoft.com");
            
            Application.Exit();

        }

        private void Reminder_Load(object sender, EventArgs e)
        {
           
        }
    }
}
