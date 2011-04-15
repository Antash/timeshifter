using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace tsWin
{
	/// <summary>
	/// This Class wrops Win32Api finctions via DllImport 
	/// and also have some useful utilities to work with windows
	/// </summary>
	internal class WinApiWrapper
	{
		/*
				private const int BuffLen = 100;
		*/

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int pid);

		/*
				[DllImport("user32.dll")]
				private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
		*/

		/// <summary>
		/// Gets name from specified process id
		/// </summary>
		/// <param name="pid">Process id</param>
		/// <returns>Process name String</returns>
		internal static string GetWindowProcName(int pid)
		{
			return pid != 0 ? Process.GetProcessById(pid).ProcessName : string.Empty;
		}

		/// <summary>
		/// Gets Description of the process by pid
		/// </summary>
		/// <param name="pid">Process id</param>
		/// <returns>Process description String</returns>
		internal static string GetProcDescription(int pid)
		{
			return pid != 0 ? FileVersionInfo.GetVersionInfo(GetProcExecutablePath(pid)).FileDescription.Trim() : string.Empty;
		}

		/// <summary>
		/// Gets executable path of specified process
		/// </summary>
		/// <param name="pName">Process name (like in task manager)</param>
		/// <returns>Path string</returns>
		internal static string GetProcExecutablePath(string pName)
		{
			Process[] p = Process.GetProcessesByName(pName);
			string path = string.Empty;
			if (p.Length > 0)
				path = p[0].MainModule.FileName;
			return path;
		}

		/// <summary>
		/// Gets executable path of specified process
		/// </summary>
		/// <param name="pName">Process name (like in task manager)</param>
		/// <param name="pDesc">Process description (like in task manager)</param>
		/// <returns>Path string</returns>
		internal static string GetProcExecutablePath(string pName, string pDesc)
		{
			Process[] ps = Process.GetProcessesByName(pName);
			string path = string.Empty;
			foreach (Process p in ps)
				if (FileVersionInfo.GetVersionInfo(p.MainModule.FileName).FileDescription == pDesc)
					path = p.MainModule.FileName;
			return path;
		}

		/// <summary>
		/// Gets executable path of specified process
		/// </summary>
		/// <param name="pid">Process id</param>
		/// <returns>Path string</returns>
		internal static string GetProcExecutablePath(int pid)
		{
			return pid != 0 ? Process.GetProcessById(pid).MainModule.FileName : string.Empty;
		}

		/// <summary>
		/// Returns Caption of main process window
		/// </summary>
		/// <param name="pid">Process id</param>
		/// <returns>Window Caption</returns>
		internal static string GetWindowTitle(int pid)
		{
			return pid != 0 ? Process.GetProcessById(pid).MainWindowTitle : string.Empty;

			//Old style function

			//IntPtr hwnd = GetForegroundWindow();
			//if (hwnd == (IntPtr)0)
			//    return "";
			//var sb = new StringBuilder(BuffLen);
			//GetWindowText(hwnd, sb, BuffLen);
			//return sb.ToString();
		}

		/// <summary>
		/// Gets active foreground window process id
		/// </summary>
		/// <returns>Process id</returns>
		internal static int GetActWindowPID()
		{
			int pid = 0;
			IntPtr hwnd = GetForegroundWindow();
			if (hwnd != (IntPtr)0)
				GetWindowThreadProcessId(hwnd, ref pid);
			return pid;
		}
	}
}
