namespace ControlFreak.Models
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public static partial class NativeMethods
    {
        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, string lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UpdateWindow(IntPtr hWnd);
    }

    public static partial class NativeMethods
    {
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        public static readonly IntPtr HWND_TOP = new IntPtr(0);
        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        public static readonly uint SWP_NOSIZE = 0x0001;
        public static readonly uint SWP_NOMOVE = 0x0002;
        public static readonly uint SWP_NOZORDER = 0x0004;
        public static readonly uint SWP_NOREDRAW = 0x0008;
        public static readonly uint SWP_NOACTIVATE = 0x0010;
        public static readonly uint SWP_DRAWFRAME = 0x0020;
        public static readonly uint SWP_FRAMECHANGED = 0x0020;
        public static readonly uint SWP_SHOWWINDOW = 0x0040;
        public static readonly uint SWP_HIDEWINDOW = 0x0080;
        public static readonly uint SWP_NOCOPYBITS = 0x0100;
        public static readonly uint SWP_NOOWNERZORDER = 0x0200;
        public static readonly uint SWP_NOREPOSITION = 0x0200;
        public static readonly uint SWP_NOSENDCHANGING = 0x0400;
        public static readonly uint SWP_DEFERERASE = 0x2000;
        public static readonly uint SWP_ASYNCWINDOWPOS = 0x4000;
    }

    public static partial class NativeMethods
    {
        public static readonly uint WM_ENABLE = 0x000A;
        public static readonly uint WM_SETTEXT = 0x000C;
        public static readonly uint WM_GETTEXT = 0x000D;
        public static readonly uint WM_GETTEXTLENGTH = 0x000E;
    }
}
