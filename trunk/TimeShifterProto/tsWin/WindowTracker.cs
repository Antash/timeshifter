using System.Threading;

namespace tsWin
{
	/// <summary>
	/// This class 
	/// </summary>
	public class WindowTracker
	{
		#region public events

		public event ActPidChangedHandler ActPidChanged;
		public event ActPNameChangedHandler ActPNameChanged;
		public event ActWindowTextChangedHandler ActWindowTextChanged;

		/// <summary>
		/// Indicates that current state of active user application fully changed
		/// </summary>
		public event ActStateChangedHandler ActStateChanged;

		#endregion

		#region event invocators

		private void InvokeActStateChanged(ActStateChangedHandlerArgs args)
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

		#endregion

		private readonly Timer _t1;
		private int _actPid;
		private string _actPname;
		private string _actWinText;
		private const long TickPeriod = 500;

		/// <summary>
		/// Initialize a new instance of WindowTracker class
		/// </summary>
		public WindowTracker()
		{
			var autoEvent = new AutoResetEvent(false);
			// Start timer ticks
			_t1 = new Timer(TimerTick, autoEvent, 0, TickPeriod);
		}

		~WindowTracker()
		{
			_t1.Dispose();
		}

		/// <summary>
		/// Procedure handles timer ticks 
		/// </summary>
		/// <param name="state">Service parmeter</param>
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

	#region delegates and event args

	public delegate void ActStateChangedHandler(object sender, ActStateChangedHandlerArgs args);

	public class ActStateChangedHandlerArgs
	{
		/// <summary>
		/// Process name
		/// </summary>
		public string NewPName { get; private set; }

		/// <summary>
		/// Window text
		/// </summary>
		public string NewWindowText { get; private set; }

		/// <summary>
		/// Process pid
		/// </summary>
		public int NewPID { get; private set; }

		/// <summary>
		/// Initialize a new instance of ActStateChangedHandlerArgs
		/// </summary>
		/// <param name="newPID">Process id</param>
		/// <param name="newPName">Process name</param>
		/// <param name="newWindowText">Window text</param>
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
		/// <summary>
		/// Process name
		/// </summary>
		public string NewPName { get; private set; }

		/// <summary>
		/// Initialize a new instance of ActPNameChangedHandlerArgs
		/// </summary>
		/// <param name="newPName">Process name</param>
		public ActPNameChangedHandlerArgs(string newPName)
		{
			NewPName = newPName;
		}
	}

	public delegate void ActWindowTextChangedHandler(object sender, ActWindowTextChangedHandlerArgs args);

	public class ActWindowTextChangedHandlerArgs
	{
		/// <summary>
		/// Window text
		/// </summary>
		public string NewWindowText { get; private set; }

		/// <summary>
		/// Initialize a new instance of ActWindowTextChangedHandlerArgs
		/// </summary>
		/// <param name="newWindowText">Window text</param>
		public ActWindowTextChangedHandlerArgs(string newWindowText)
		{
			NewWindowText = newWindowText;
		}
	}

	public delegate void ActPidChangedHandler(object sender, ActPidChangedArgs args);

	public class ActPidChangedArgs
	{
		/// <summary>
		/// Process id
		/// </summary>
		public int NewPID { get; private set; }

		/// <summary>
		/// Initialize a new instance of ActPidChangedArgs
		/// </summary>
		/// <param name="newPID">Process id</param>
		public ActPidChangedArgs(int newPID)
		{
			NewPID = newPID;
		}
	}

	#endregion
}