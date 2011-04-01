using System.Threading;

namespace tsWin
{
	class WindowTracker
	{
		public event ActPidChangedHandler ActPidChanged;
		public event ActPNameChangedHandler ActPNameChanged;
		public event ActWindowTextChangedHandler ActWindowTextChanged;

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

		private void TimerTick(object state)
		{
			int newPid = WinApiWrapper.GetActWindowPID();
			string newWTitle = WinApiWrapper.GetActWindowTitle();
			string newPName = WinApiWrapper.GetActWindowProcName();
			if (newPid != _actPid)
			{
				InvokeActPidChanged(new ActPidChangedArgs(newPid));
				_actPid = newPid;
			}
			if (newPName != _actPname)
			{
				InvokeActPNameChanged(new ActPNameChangedHandlerArgs(newPName));
				_actPname = newPName;
			}
			if (newWTitle != _actWinText)
			{
				InvokeActWindowTextChanged(new ActWindowTextChangedHandlerArgs(newWTitle));
				_actWinText = newWTitle;
			}
		}
	}

	public delegate void ActPNameChangedHandler(object sender, ActPNameChangedHandlerArgs args);

	public class ActPNameChangedHandlerArgs
	{
		private readonly string _newPName;

		public string NewPName
		{
			get { return _newPName; }
		}

		public ActPNameChangedHandlerArgs(string text)
		{
			_newPName = text;
		}
	}

	public delegate void ActWindowTextChangedHandler(object sender, ActWindowTextChangedHandlerArgs args);

	public class ActWindowTextChangedHandlerArgs
	{
		private readonly string _newText;

		public string NewText
		{
			get { return _newText; }
		}

		public ActWindowTextChangedHandlerArgs(string text)
		{
			_newText = text;
		}
	}

	public delegate void ActPidChangedHandler(object sender, ActPidChangedArgs args);

	public class ActPidChangedArgs
	{
		private readonly int _newPID;

		public int NewPID
		{
			get { return _newPID; }
		}

		public ActPidChangedArgs(int pid)
		{
			_newPID = pid;
		}
	}
}