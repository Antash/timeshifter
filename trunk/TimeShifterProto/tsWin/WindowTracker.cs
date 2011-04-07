using System.Drawing;
using System.Threading;

namespace tsWin
{
	public class WindowTracker
	{
		public event ActPidChangedHandler ActPidChanged;
		public event ActPNameChangedHandler ActPNameChanged;
		public event ActWindowTextChangedHandler ActWindowTextChanged;
		public event ActStateChangedHandler ActStateChanged;

		public void InvokeActStateChanged(ActStateChangedHandlerArgs args)
		{
			ActStateChangedHandler handler = ActStateChanged;
			if (handler != null) handler(this, args);
		}

		private void InvokeActPidChanged(ActPidChangedArgs args)
		{
			ActPidChangedHandler handler = ActPidChanged;
			if (handler != null) handler(this, args);
		}

		private void InvokeActPNameChanged(ActPNameChangedHandlerArgs args)
		{
			ActPNameChangedHandler handler = ActPNameChanged;
			if (handler != null) handler(this, args);
		}

		private void InvokeActWindowTextChanged(ActWindowTextChangedHandlerArgs args)
		{
			ActWindowTextChangedHandler handler = ActWindowTextChanged;
			if (handler != null) handler(this, args);
		}

		private Timer _t1;
		private int _actPid;
		private string _actPname;
		private string _actWinText;
		private const long TickPeriod = 500;

		public WindowTracker()
		{
			var autoEvent = new AutoResetEvent(false);
			_t1 = new Timer(TimerTick, autoEvent, 0, TickPeriod);
		}

		public static Icon GetApplicationIcon(string appName, bool isLarge)
		{
			var extractor = new IconExtractor(WinApiWrapper.GetProcExecutablePath(appName));
			return extractor.GetIcon(0);
		}

		private void TimerTick(object state)
		{
			bool isDirty = false;
			int newPid = WinApiWrapper.GetActWindowPID();
            string newWTitle = WinApiWrapper.GetWindowTitle(newPid);
            string newPName = WinApiWrapper.GetWindowProcName(newPid);

			if (newPid != _actPid)
			{
				InvokeActPidChanged(new ActPidChangedArgs(newPid));
				_actPid = newPid;
				isDirty = true;
			}
			if (newPName != _actPname)
			{
				InvokeActPNameChanged(new ActPNameChangedHandlerArgs(newPName));
				_actPname = newPName;
				isDirty = true;
			}
			if (newWTitle != _actWinText)
			{
				InvokeActWindowTextChanged(new ActWindowTextChangedHandlerArgs(newWTitle));
				_actWinText = newWTitle;
				isDirty = true;
			}
			if (isDirty)
			{
				InvokeActStateChanged(new ActStateChangedHandlerArgs(_actPid, _actPname, _actWinText));
			}
		}
	}

	public delegate void ActStateChangedHandler(object sender, ActStateChangedHandlerArgs args);

	public class ActStateChangedHandlerArgs
	{
		public string NewPName { get; private set; }
		public string NewWindowText { get; private set; }
		public int NewPID { get; private set; }

		public ActStateChangedHandlerArgs(int newPID, string newPName, string newWindowText)
		{
			NewPID = newPID;
			NewPName = newPName;
			NewWindowText = newWindowText;
		}
	}

	public delegate void ActPNameChangedHandler(object sender, ActPNameChangedHandlerArgs args);

	public class ActPNameChangedHandlerArgs
	{
		public string NewPName { get; private set; }

		public ActPNameChangedHandlerArgs(string newPName)
		{
			NewPName = newPName;
		}
	}

	public delegate void ActWindowTextChangedHandler(object sender, ActWindowTextChangedHandlerArgs args);

	public class ActWindowTextChangedHandlerArgs
	{
		public string NewWindowText { get; private set; }

		public ActWindowTextChangedHandlerArgs(string newWindowText)
		{
			NewWindowText = newWindowText;
		}
	}

	public delegate void ActPidChangedHandler(object sender, ActPidChangedArgs args);

	public class ActPidChangedArgs
	{
		public int NewPID { get; private set; }

		public ActPidChangedArgs(int newPID)
		{
			NewPID = newPID;
		}
	}
}