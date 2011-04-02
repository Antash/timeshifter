using System;
using System.Collections.Generic;
using tsWin;

namespace tsCore
{
	class WindowLogger
	{
		private WindowTracker _winTracker;
		private List<WindowLogItem> _windowLog;
		private WindowLogItem _lastRecord;

		public WindowLogger()
		{
			_winTracker = new WindowTracker();
			_windowLog = new List<WindowLogItem>();

			_winTracker.ActStateChanged += WinTrackerActStateChanged;
		}

		void WinTrackerActStateChanged(object sender, ActStateChangedHandlerArgs args)
		{
			//TODO : add correct task id
			_lastRecord = new WindowLogItem(args.NewPID,
			                                args.NewPName,
			                                args.NewWindowText,
			                                DateTime.Now,
			                                0);
			_windowLog.Add(_lastRecord);
		}

		public bool WriteLogToBinary(string filename)
		{
			throw new NotImplementedException();
		}

		public bool ReadLogToBinary(string filename)
		{
			throw new NotImplementedException();
		}

		public bool WriteLogToText(string filename)
		{
			throw new NotImplementedException();
		}

		public bool ReadLogToText(string filename)
		{
			throw new NotImplementedException();
		}
	}
}
