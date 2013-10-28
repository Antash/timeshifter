using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace tsWin
{
	/// <summary>
	/// This Class wrops Win32Api finctions via DllImport 
	/// and also have some useful utilities to work with windows
	/// </summary>
	internal class WinApiWrapper
	{
		private const int BuffLen = 200;

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int pid);

		[DllImport("user32.dll")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

		[DllImport("user32.dll")]
		private static extern IntPtr GetDesktopWindow();

		[DllImport("user32.dll")]
		private static extern IntPtr GetShellWindow();

		[DllImport("user32.dll")]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		[DllImport("user32.dll")]
		private static extern bool EnumWindows(EnumWindowsProc lpfn, IntPtr lParam);

		[DllImport("user32.dll")]
		private static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc lpfn, IntPtr lParam);

		[DllImport("user32.dll")]
		private static extern bool EnumThreadWindows(IntPtr dwThreadId, EnumWindowsProc lpfn, IntPtr lParam);


		private static int i;
		private static string t;
		private static bool EnumWinProc(IntPtr hWnd, IntPtr lParam)
		{
			if (hWnd != hShellWindow)
			{
				int windowPid = 0;
				if (!IsWindowVisible(hWnd))
					return true;
				int l = GetWindowTextLength(hWnd);
				if (l == 0)
					return true;
				GetWindowThreadProcessId(hWnd, ref windowPid);
				if (windowPid != currentProcessID)
					return true;
				var sb = new StringBuilder(l);
				GetWindowText(hWnd, sb, l + 1);
				if (!dictWindows.ContainsKey(hWnd)) dictWindows.Add(hWnd, sb.ToString());
			}
			return true;
		}

		private static IntPtr hShellWindow = GetShellWindow();
		static IDictionary<IntPtr, String> dictWindows = new Dictionary<IntPtr, string>();
		private static int currentProcessID;


		 internal static void GetOpenWindowsFromPID(int processID)
		 {
			dictWindows.Clear();
		 	currentProcessID = processID;
			EnumWindows(EnumWinProc, IntPtr.Zero);
		 }

		internal static void EnumWin(int pid)
		{
			GetOpenWindowsFromPID(pid);
			i = 0;
			t = "";
			//	EnumThreadWindows((IntPtr) pid, EnumWinProc, IntPtr.Zero);
			//EnumChildWindows(GetShellWindow(), EnumWinProc, IntPtr.Zero);
			//	EnumWindows(EnumWinProc, IntPtr.Zero);
			//	EnumChildWindows(GetForegroundWindow(), EnumWinProc, IntPtr.Zero);
		}

		/// <summary>
		/// Gets name from specified process id
		/// </summary>
		/// <param name="pid">Process id</param>
		/// <returns>Process name String</returns>
		internal static string GetWindowProcName(int pid)
		{
            if (pid <= 0)
                throw new ArgumentException("Process id should be >= 0.");
			return Process.GetProcessById(pid).ProcessName;
		}

		/// <summary>
		/// Gets Description of the process by pid
		/// </summary>
		/// <param name="pid">Process id</param>
		/// <returns>Process description String</returns>
		internal static string GetProcDescription(int pid)
		{
            if (pid <= 0)
		        throw new ArgumentException("Process id should be >= 0.");
		    var path = GetProcExecutablePath(pid);
		    try
		    {
                return FileVersionInfo.GetVersionInfo(path).FileDescription;
		    }
		    catch (Exception)
		    {
                // Any problem during reading executable details
                //TODO : log error here
                return string.Empty;
		    }
		}

		/// <summary>
		/// Gets executable path of specified process
		/// </summary>
		/// <param name="pName">Process name (like in task manager)</param>
		/// <returns>Path string</returns>
		[Obsolete("This metod is unstable, use GetProcExecutablePath(string pName, string pDesc) instead")]
		internal static string GetProcExecutablePath(string pName)
		{
			Process[] p = Process.GetProcessesByName(pName);
			return p.Length > 0 ? p[0].MainModule.FileName : string.Empty;
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
				try
				{
					if (FileVersionInfo.GetVersionInfo(p.MainModule.FileName).FileDescription == pDesc)
						path = p.MainModule.FileName;
				}
				catch (Exception)
				{
					//NOTE! this unsecure code is nesessary to prevent wrong failure
				}
			return path;
		}

		/// <summary>
		/// Gets executable path of specified process
		/// </summary>
		/// <param name="pid">Process id</param>
		/// <returns>Path string</returns>
		internal static string GetProcExecutablePath(int pid)
		{
		    if (pid <= 0)
		        throw new ArgumentException("Process id should be >= 0.");
		    try
		    {
		        return Process.GetProcessById(pid).MainModule.FileName;
		    }
		    catch (Exception)
		    {
		        throw new MemberAccessException("Cannot extract executable path.");
		    }
		}

		/// <summary>
		/// Returns Caption of main process window
		/// </summary>
		/// <param name="pid">Process id</param>
		/// <returns>Window Caption</returns>
		internal static string GetWindowTitle(int pid)
		{
            if (pid <= 0)
                throw new ArgumentException("Process id should be >= 0.");
			return Process.GetProcessById(pid).MainWindowTitle;
		}

		/// <summary>
		/// Returns Caption of top active window
		/// </summary>
		/// <returns>Window Caption</returns>
		internal static string GetWindowTitle()
		{
			IntPtr hwnd = GetForegroundWindow();
			if (hwnd == (IntPtr)0)
				return String.Empty;
			var sb = new StringBuilder(BuffLen);
			GetWindowText(hwnd, sb, BuffLen);
			return sb.ToString();
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
