using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KH_Video_Switcher
{    class ToolStripEx : System.Windows.Forms.ToolStrip
    {
        protected override void WndProc(ref Message m)
        {
            // WM_MOUSEACTIVATE = 0x21
            if (m.Msg == 0x21 && this.CanFocus && !this.Focused)
            {
                this.Focus();
            }
            base.WndProc(ref m);
        }
    }
}
