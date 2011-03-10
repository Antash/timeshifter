using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace wincore
{
	public class WinApiWrapper
	{
        int actPid;
	    private string actPname;
	    private string actWinText;
	    public int invokes = 0;
        public WinApiWrapper()
        {
            AutoResetEvent autoEvent = new AutoResetEvent(false);
            t1 = new Timer(TimerTick, autoEvent, 0, 500);
        }

        public void TimerTick(object state)
        {
            string tmp;
            StringBuilder sb = new StringBuilder(100);
            IntPtr hwnd = GetForegroundWindow();
            if (hwnd != (IntPtr)0)
            {
                int pid = 0;
                GetWindowThreadProcessId(hwnd, ref pid);
                if (pid != actPid)
                {
                    if (actPidChanged != null)
                    {
                        actPidChanged(this, new actPidChangedArgs(pid));
                        invokes++;

                    }
                    actPid = pid;
                }
                tmp = getActWindowProcName();
                if (tmp != actPname)
                {
                    if (actPNameChanged != null)
                        actPNameChanged(this, new actPNameChangedHandlerArgs(tmp));
                    actPname = tmp;
                }
                GetWindowText(hwnd, sb, 100);
                tmp = sb.ToString();
                if (tmp != actWinText)
                {
                    if (actWintaoTextChanged != null)
                        actWintaoTextChanged(this, new actWindowTextChangedHandlerArgs(tmp));
                    actWinText = tmp;
                }
            }
        }

	    public event actPidChangedHandler actPidChanged;
        public event actPNameChangedHandler actPNameChanged;
        public event actWindowTextChangedHandler actWintaoTextChanged;
	    private Timer t1;

	    [DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int pid);

		[DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

		delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);

		[DllImport("user32.Dll")]
		static extern bool EnumChildWindows(IntPtr parentHandle, Win32Callback callback, IntPtr lParam);

	    [DllImport("user32.Dll")]
	    private static extern IntPtr GetTopWindow(IntPtr parentHandle);

        [DllImport("winhook.dll")]
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public static extern string getActWindowProcName();

		static string s = "";
		public static string getChild()
		{
			s = "";
		    IntPtr hwnd = GetForegroundWindow();
            while (hwnd != (IntPtr) 0)
            {
                StringBuilder sb = new StringBuilder(100);
                hwnd = GetTopWindow(hwnd);
                GetWindowText(hwnd, sb, 100);
                s += sb;
            }
		    //EnumChildWindows(GetForegroundWindow(), EnumWindow, (IntPtr)1);
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

    public delegate void actPNameChangedHandler(object sender, actPNameChangedHandlerArgs args);

    public class actPNameChangedHandlerArgs
    {
        public string newText;
        public actPNameChangedHandlerArgs()
        {

        }
        public actPNameChangedHandlerArgs(string Text)
        {
            newText = Text;
        }
    }

    public delegate void actWindowTextChangedHandler(object sender, actWindowTextChangedHandlerArgs args);

    public class actWindowTextChangedHandlerArgs
    {
        public string newText;
        public actWindowTextChangedHandlerArgs()
        {

        }
        public actWindowTextChangedHandlerArgs(string Text)
        {
            newText = Text;
        }
    }

    public delegate void actPidChangedHandler(object sender, actPidChangedArgs args);

    public class actPidChangedArgs
    {
                public int newPID;
        public actPidChangedArgs()
        {

        }
        public actPidChangedArgs(int pid)
        {
            newPID = pid;
        }
    }
}
