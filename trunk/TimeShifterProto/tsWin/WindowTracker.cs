﻿using System.Threading;

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
		public event ActPDescChangedHandler ActPDescChanged;
		public event ActApplicationChangedHandler ActApplicationChanged;
		public event ActWindowTextChangedHandler ActWindowTextChanged;

		/// <summary>
		/// Indicates that current state of active user application fully changed
		/// </summary>
		public event ActStateChangedHandler ActStateChanged;

		#endregion

		#region event invocators

		public void InvokeActApplicationChanged(ActApplicationChangedHandlerArgs args)
		{
			ActApplicationChangedHandler handler = ActApplicationChanged;
			if (handler != null) handler(this, args);
		}

		public void InvokeActPDescChanged(ActPDescChangedHandlerArgs args)
		{
			ActPDescChangedHandler handler = ActPDescChanged;
			if (handler != null) handler(this, args);
		}

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

		private Timer _t1;
		private readonly ProcessWatcher _processWatcher;
		private int _actPid;
		private string _actPname;
		private string _actPdesc;
		private string _actWinText;
		private const long TickPeriod = 1000;

		/// <summary>
		/// Initialize a new instance of WindowTracker class
		/// </summary>
		public WindowTracker (bool startListening)
		{
			_processWatcher = new ProcessWatcher();
			_processWatcher.ProcessDeleted += _processWatcher_ProcessDeleted;
			if (startListening)
				Start();
		}

		/// <summary>
		/// Invokes when some process closed
		/// </summary>
		/// <param name="proc">Process info instance</param>
		void _processWatcher_ProcessDeleted(Win32_Process proc)
		{
		}

		/// <summary>
		/// Starts listen timer
		/// </summary>
		public void Start()
		{
			var autoEvent = new AutoResetEvent (false);
			// Start timer ticks
			_t1 = new Timer (TimerTick, autoEvent, 0, TickPeriod);
			_processWatcher.Start();
		}
		
		/// <summary>
		/// Stops listen timer
		/// </summary>
		public void Stop()
		{
			_t1.Dispose();
			_processWatcher.Stop();
		}
		
		/// <summary>
		/// Stops listen Timer while disposing object
		/// </summary>
		~WindowTracker()
		{
			Stop();
		}

		/// <summary>
		/// Procedure handles timer ticks 
		/// </summary>
		/// <param name="state">Service parmeter</param>
		private void TimerTick(object state)
		{
			bool invokeStateChRequired = false;
			bool invokeAppChRequired = false;
			int newPid = WinApiWrapper.GetActWindowPID();

			// No active process detected
			if (newPid == 0)
				return;

			string newWTitle = WinApiWrapper.GetWindowTitle();
			string newPName = WinApiWrapper.GetWindowProcName(newPid);
			string newPdesc = WinApiWrapper.GetProcDescription(newPid);

			if (newPid != _actPid)
			{
				InvokeActPidChanged(new ActPidChangedArgs(newPid));
				_actPid = newPid;
				invokeStateChRequired = true;
			}
			if (newPName != _actPname)
			{
				InvokeActPNameChanged(new ActPNameChangedHandlerArgs(newPName));
				_actPname = newPName;
				invokeStateChRequired = true;
				invokeAppChRequired = true;
			}
			if (newPdesc != _actPdesc)
			{
				InvokeActPDescChanged(new ActPDescChangedHandlerArgs(newPdesc));
				_actPdesc = newPdesc;
				invokeStateChRequired = true;
				invokeAppChRequired = true;
			}
			if (newWTitle != _actWinText)
			{
				InvokeActWindowTextChanged(new ActWindowTextChangedHandlerArgs(newWTitle));
				_actWinText = newWTitle;
				invokeStateChRequired = true;
			}

			if (invokeAppChRequired)
				InvokeActApplicationChanged(new ActApplicationChangedHandlerArgs(newPName, newPdesc));

			//State changed event must be invoked last
			if (invokeStateChRequired)
				InvokeActStateChanged(new ActStateChangedHandlerArgs(newPid, newPName, newPdesc, newWTitle));
		}

		#region delegates and event args

		public delegate void ActApplicationChangedHandler(object sender, ActApplicationChangedHandlerArgs args);

		public class ActApplicationChangedHandlerArgs
		{
			/// <summary>
			/// Process name
			/// </summary>
			public string NewPname { get; private set; }

			/// <summary>
			/// Process description
			/// </summary>
			public string NewPdesc { get; private set; }

			/// <summary>
			/// Initialize a new instance of ActPDescChangedHandlerArgs
			/// </summary>
			/// <param name="newPname">Process name</param>
			/// <param name="newPdesc">Process description</param>
			public ActApplicationChangedHandlerArgs(string newPname, string newPdesc)
			{
				NewPname = newPname;
				NewPdesc = newPdesc;
			}
		}

		public delegate void ActPDescChangedHandler(object sender, ActPDescChangedHandlerArgs args);

		public class ActPDescChangedHandlerArgs
		{
			/// <summary>
			/// Process description
			/// </summary>
			public string NewPdesc { get; private set; }

			/// <summary>
			/// Initialize a new instance of ActPDescChangedHandlerArgs
			/// </summary>
			/// <param name="newPdesc">Process description</param>
			public ActPDescChangedHandlerArgs(string newPdesc)
			{
				NewPdesc = newPdesc;
			}
		}

		public delegate void ActStateChangedHandler(object sender, ActStateChangedHandlerArgs args);

		public class ActStateChangedHandlerArgs
		{
			/// <summary>
			/// Process name
			/// </summary>
			public string NewPName { get; private set; }

			/// <summary>
			/// Process description
			/// </summary>
			public string NewPdesc { get; private set; }

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
			/// <param name="newPdesc">Process description</param>
			/// <param name="newWindowText">Window text</param>
			public ActStateChangedHandlerArgs(int newPID, string newPName, string newPdesc, string newWindowText)
			{
				NewPID = newPID;
				NewPName = newPName;
				NewPdesc = newPdesc;
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
}