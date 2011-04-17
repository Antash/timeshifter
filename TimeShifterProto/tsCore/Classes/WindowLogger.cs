﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using tsCore.Interfaces;
using tsCoreStructures;
using tsWin;

namespace tsCore.Classes
{
	class WindowLogger : IBinaryIo, IManaged
	{
		public event AppWindowChangedHandler StateChanged;

		public void InvokeAppWindowChanged(AppWindowChangedHandlerArgs args)
		{
			AppWindowChangedHandler handler = StateChanged;
			if (handler != null) handler(this, args);
		}

		public event AppChangedHandler AppChanged;

		public void InvokeAppChanged(AppChangedEventArgs args)
		{
			AppChangedHandler handler = AppChanged;
			if (handler != null) handler(this, args);
		}
		
		private readonly WindowTracker _winTracker;
		private List<WindowLogStructure> _windowLog;
		private WindowLogStructure _lastRecord;

		public WindowLogger()
		{
			_winTracker = new WindowTracker(false);
			_windowLog = new List<WindowLogStructure>();
			_lastRecord = new WindowLogStructure();
			_winTracker.ActApplicationChanged += WinTrackerActApplicationChanged;
			_winTracker.ActStateChanged += WinTrackerActStateChanged; 
		}

		void WinTrackerActApplicationChanged(object sender, WindowTracker.ActApplicationChangedHandlerArgs args)
		{
			InvokeAppChanged(new AppChangedEventArgs(args.NewPname, args.NewPdesc));
		}

		void WinTrackerActStateChanged(object sender, WindowTracker.ActStateChangedHandlerArgs args)
		{
			//TODO : add correct task id
			_lastRecord = new WindowLogStructure(args.NewPID,
			                                args.NewPName,
											args.NewPdesc,
			                                args.NewWindowText,
			                                DateTime.Now,
			                                0);
			InvokeAppWindowChanged(new AppWindowChangedHandlerArgs(_lastRecord));
			_windowLog.Add(_lastRecord);
		}

		public void ReadBinary(string filename)
		{
			using (Stream stream = File.Open(filename, FileMode.Open))
			{
				var bin = new BinaryFormatter();
				var tmp = (List<WindowLogStructure>)bin.Deserialize(stream);
				_windowLog = tmp;
			}
		}

		public void WriteBinary(string filename)
		{
			using (Stream stream = File.Open(filename, FileMode.Create))
			{
				var bin = new BinaryFormatter();
				bin.Serialize(stream, _windowLog);
			}
		}

		public void Enable()
		{
			_winTracker.Start();
		}

		public void Disable()
		{
			_winTracker.Stop();
		}

		internal delegate void AppWindowChangedHandler(object sender, AppWindowChangedHandlerArgs args);

		internal class AppWindowChangedHandlerArgs
		{
			public WindowLogStructure Record { get; private set; }

			public AppWindowChangedHandlerArgs(WindowLogStructure record)
			{
				Record = record;
			}
		}

		internal delegate void AppChangedHandler(object sender, AppChangedEventArgs args);

		internal class AppChangedEventArgs
		{
			public string ProcessName { get; private set; }
			public string ProcessDesc { get; private set; }

			public AppChangedEventArgs(string processName, string processDesc)
			{
				ProcessName = processName;
				ProcessDesc = processDesc;
			}
		}
	}
}
