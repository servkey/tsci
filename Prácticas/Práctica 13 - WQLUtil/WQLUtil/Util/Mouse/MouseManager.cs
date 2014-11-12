using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Diagnostics;
using System.Runtime.InteropServices;
namespace WQLUtil.Util.Mouse
{
    public class MouseManager
    {
    //    private static LowLevelMouseProc _proc = HookCallback;
    //    private static IntPtr _hookID = IntPtr.Zero;
        private WQLUtil.Util.Mouse.UserActivityHook hook = new WQLUtil.Util.Mouse.UserActivityHook();
        public UserActivityHook Hook
        {
            get
            {
                return hook;
            }
            set
            {
                hook = value;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        public const int MOUSEEVENTF_RIGHTUP = 0x10;



        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
       
        [DllImport("user32.dll")]
        public static extern bool SetCursorPos(int X, int Y);

        public static void RightClick(int x, int y)
        {
            WQLUtil.Util.Mouse.MouseManager.mouse_event(WQLUtil.Util.Mouse.MouseManager.MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
        }

        public static void LeftClick(int x, int y)
        {
            WQLUtil.Util.Mouse.MouseManager.mouse_event(WQLUtil.Util.Mouse.MouseManager.MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        public static void LeftClickExt(int x, int y)
        {
            WQLUtil.Util.Mouse.MouseManager.mouse_event(WQLUtil.Util.Mouse.MouseManager.MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        }

        public static void SetCursor(int x, int y)
        {
            WQLUtil.Util.Mouse.MouseManager.SetCursorPos(x, y);
            WQLUtil.Util.Mouse.MouseManager.LeftClick(x, y);
        }
    }
}

