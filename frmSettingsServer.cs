using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KH_Video_Switcher
{
    public partial class frmSettingsServer : Form
    {
        public frmSettingsServer()
        {
            InitializeComponent();
        }
        private void frmSettingsServer_Load(object sender, EventArgs e)
        {
            string version = Application.ProductVersion;

            labelVersion.Text = $"Installed version: {version}";
        }

        private void btnShowOBSPASS_Click(object sender, EventArgs e)
        {
            // Toggle the UseSystemPasswordChar property
            if (textBoxOBSPASS.UseSystemPasswordChar)
            {
                textBoxOBSPASS.UseSystemPasswordChar = false;
                btnShowOBSPASS.Text = "Hide";
            }
            else
            {
                textBoxOBSPASS.UseSystemPasswordChar = true;
                btnShowOBSPASS.Text = "Show";
            }
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/aaroned/KH-Video-Switcher/releases";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
