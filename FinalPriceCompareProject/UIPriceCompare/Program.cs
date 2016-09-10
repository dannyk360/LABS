using System;
using System.Windows.Forms;
using BULogic;

namespace UIPriceCompare
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ProgramLogic.InitChains();
            Application.Run(new Form1());
        }
    }
}