using System;
using System.Collections.Generic;
//using System.Linq;
using System.Windows.Forms;
using RAHMS.Forms;

namespace RAHMS
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
            Application.Run(new Frm_Login());
            Application.ApplicationExit += Application_ApplicationExit;
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
        }
    }
}
