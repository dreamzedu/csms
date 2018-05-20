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
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(AppDomain_UnhandledException);
            Application.ApplicationExit += Application_ApplicationExit;      

            Application.Run(new Splash());
            //Application.Run(new MDIParent1());
            //Application.Run(new Test.Form1());
            //Application.SetUnhandledExceptionMode( UnhandledExceptionMode.CatchException);
            
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (Connection.MyConnection != null && (Connection.MyConnection.State == System.Data.ConnectionState.Open || Connection.MyConnection.State == System.Data.ConnectionState.Fetching || Connection.MyConnection.State == System.Data.ConnectionState.Executing))
            {
                try
                {
                    Connection.MyConnection.Close();
                }
                catch
                { }

            }

            if (Connection.UserDbConnection != null && Connection.UserDbConnection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    Connection.UserDbConnection.Close();
                }
                catch
                { }

            }
        }

        private static void AppDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception exception;

            exception = e.ExceptionObject as Exception;
            if (exception != null)
            {
                Logger.LogError(exception);
                
            }

            MessageBox.Show("Some critical error occurred in the application. Closing the application now.");
            Application.Exit();
            Environment.Exit(0);
        }

       

        private static void HandleException(Exception exception)
        {
            if (SystemInformation.UserInteractive)
            {
                using (ThreadExceptionDialog dialog = new ThreadExceptionDialog(exception))
                {
                    if (dialog.ShowDialog() == DialogResult.Cancel)
                        return;
                }
                Application.Exit();
                Environment.Exit(0);
            }
        }
    }
}
