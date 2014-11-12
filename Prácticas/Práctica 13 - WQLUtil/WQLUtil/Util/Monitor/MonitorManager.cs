using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices; 

namespace WQLUtil.Util.Monitor
{
    
    public class MonitorManager
    {
        private static int WM_SYSCOMMAND = 0x0112;
        private static int SC_MONITORPOWER = 0xF170;
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        public static void ShootOn(int hWnd)
        {
            SendMessage(hWnd, WM_SYSCOMMAND , SC_MONITORPOWER ,1);
        }

        public static void ShutOff(int hWnd)
        {
            SendMessage(hWnd, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }
    }
}
