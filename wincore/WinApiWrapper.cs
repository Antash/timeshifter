using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace wincore
{
	public class WinApiWrapper
	{
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);

		[DllImport("user32.Dll")]
		static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);
		
		static string s = "";
		public static string getChild()
		{
			s = "";

			EnumChildWindows(GetForegroundWindow(), EnumWindow, (IntPtr)1);
			return s;
		}

		private static bool EnumWindow(IntPtr handle, IntPtr pointer)
		{
			StringBuilder sb = new StringBuilder(100);
			GetWindowText(handle, sb, 100);
			s += sb.ToString() + "\n";
			return true;
		}
	}
}
