using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace krchhto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Base.args = args;
            Application.Run(new frmPageEditor());
        }
    }
}
