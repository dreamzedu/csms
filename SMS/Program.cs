using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SMS
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new Splash());
            //Application.Run(new MDIParent1());
            //Application.Run(new Test.Form1());
            //Application.SetUnhandledExceptionMode( UnhandledExceptionMode.CatchException);
            
        }
    }
}
