using System;
using System.Runtime.InteropServices;
using System.Text;

namespace tsWin
{
	public class WinApiWrapper
	{
		private const int BuffLen = 100;

	    [DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
		private static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int pid);

		[DllImport("user32.dll")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetActWindowProcName()
        {
			return System.Diagnostics.Process.GetProcessById(GetActWindowPID()).ProcessName;
        }

		public static string GetActWindowTitle()
		{
			IntPtr hwnd = GetForegroundWindow();
			if (hwnd == (IntPtr)0)
				return "no active window";
			var sb = new StringBuilder(BuffLen);
			GetWindowText(hwnd, sb, BuffLen);
			return sb.ToString();
		}

		public static int GetActWindowPID()
		{
			int pid = 0;
			IntPtr hwnd = GetForegroundWindow();
			if (hwnd != (IntPtr)0)
				GetWindowThreadProcessId(hwnd, ref pid);
			return pid;
		}
	}
}
