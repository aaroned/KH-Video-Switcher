using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            var clientModeSetting = ConfigurationManager.AppSettings["ClientMode"];
            var isClientMode = (clientModeSetting != null && clientModeSetting.ToLower() == "true");

            Application.Run(isClientMode ? (Form)new frmClient() : (Form)new frmServer());
        }
    }
}
