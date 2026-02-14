using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoUpdaterDotNET;

namespace KH_Video_Switcher
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

            // Customize the update notification
            AutoUpdater.ShowSkipButton = true;  // Let users skip this version
            AutoUpdater.ShowRemindLaterButton = true;  // Remind me later option
            AutoUpdater.Mandatory = false;  // Don't force update
            AutoUpdater.ReportErrors = true;
            AutoUpdater.DownloadPath = Environment.CurrentDirectory;
            AutoUpdater.RunUpdateAsAdmin = false;

            // Check for updates on startup
            AutoUpdater.Start("https://raw.githubusercontent.com/aaroned/KH-Video-Switcher/add-autoupdater/update.xml");


            var clientModeSetting = ConfigurationManager.AppSettings["ClientMode"];
            var isClientMode = (clientModeSetting != null && clientModeSetting.ToLower() == "true");

            Application.Run(isClientMode ? (Form)new frmClient() : (Form)new frmServer());
        }
    }
}
