using Nethereum.Hex.HexTypes;
using Nethereum.Util;
using Nethereum.Web3;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace GasTracker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (DuplicateProcess(Process.GetCurrentProcess()))
            {
                MessageBox.Show("Application is already running\nLook for it in the tray", "Program duplicate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(-1);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static private bool DuplicateProcess(Process process)
        {
            Process[] processes = Process.GetProcessesByName(process.ProcessName);
            if (processes.Length > 1)
                return true;
            else
                return false;
        }
    }
}

