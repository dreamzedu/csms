using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SMS.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex pattern = new Regex(@"^[<]{1}[<]{1}[a-zA-z0-9]+[>]{1}[>]{1}$");

            if (pattern.IsMatch(textBox1.Text))
            {
                //Do something
                
            }
            else
            {
                
            }
        }
    }
}
