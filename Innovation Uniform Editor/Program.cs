using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Innovation_Uniform_Editor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
                Application.Run(new Main(args[0]));
            else
                Application.Run(new Main());
        }
    }
}
