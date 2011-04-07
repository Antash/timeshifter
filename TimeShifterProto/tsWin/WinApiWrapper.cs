using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace tsWin
{
	class WinApiWrapper
	{
		private const int BuffLen = 100;

		[DllImport("user32.dll")]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		private static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int pid);

		[DllImport("user32.dll")]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		[DllImport("shell32.dll")]
		private static extern uint ExtractIconEx(string szFileName,
										int nIconIndex,
										IntPtr[] phiconLarge,
										IntPtr[] phiconSmall,
										uint nIcons);

		[DllImport("user32.dll")]
		private static extern int DestroyIcon(IntPtr hIcon);

		internal static string GetWindowProcName(int pid)
		{
			return pid != 0 ? Process.GetProcessById(pid).ProcessName : string.Empty;
		}

		internal static string GetProcExecutablePath(string pName)
		{
			Process[] p = Process.GetProcessesByName(pName);
			string path = string.Empty;
			if (p.Length > 0)
				path = p[0].MainModule.FileName;
			return path;
		}

		internal static string GetProcExecutablePath(int pid)
		{
			return pid != 0 ? Process.GetProcessById(pid).MainModule.FileName : string.Empty;
		}

		internal static Icon GetProcIcon(string path)
		{
			return Icon.ExtractAssociatedIcon(path);
		}

		internal static string GetWindowTitle(int pid)
		{
			return pid != 0 ? Process.GetProcessById(pid).MainWindowTitle : string.Empty;
			//Old style function
			//IntPtr hwnd = GetForegroundWindow();
			//if (hwnd == (IntPtr)0)
			//    return "no active window";
			//var sb = new StringBuilder(BuffLen);
			//GetWindowText(hwnd, sb, BuffLen);
			//return sb.ToString();
		}

		internal static int GetActWindowPID()
		{
			int pid = 0;
			IntPtr hwnd = GetForegroundWindow();
			if (hwnd != (IntPtr)0)
				GetWindowThreadProcessId(hwnd, ref pid);
			return pid;
		}

		public static Icon ExtractIconFromExe(string file, bool isLarge)
		{
			var hDummy = new[] { IntPtr.Zero };
			var hIconEx = new[] { IntPtr.Zero };
			try
			{
				uint readIconCount = isLarge ?
									ExtractIconEx(file, 0, hIconEx, hDummy, 1) :
									ExtractIconEx(file, 0, hDummy, hIconEx, 1);

				if (readIconCount > 0 && hIconEx[0] != IntPtr.Zero)
				{
					var extractedIcon = (Icon)Icon.FromHandle(hIconEx[0]).Clone();
					return extractedIcon;
				}
				else
					return null;
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Could not extract icon", ex);
			}
			finally
			{
				// release resources
				foreach (IntPtr ptr in hIconEx)
					if (ptr != IntPtr.Zero)
						DestroyIcon(ptr);

				foreach (IntPtr ptr in hDummy)
					if (ptr != IntPtr.Zero)
						DestroyIcon(ptr);
			}
		}
	}
}
