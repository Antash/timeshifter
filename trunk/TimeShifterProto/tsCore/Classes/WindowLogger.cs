using System;
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
			_winTracker.ActStateChanged += WinTrackerActStateChanged; 
		}

		void WinTrackerActStateChanged(object sender, ActStateChangedHandlerArgs args)
		{
			if (args.NewPdesc != _lastRecord.ProcesDesc && !String.IsNullOrEmpty(args.NewPdesc))
			{
				InvokeAppChanged(new AppChangedEventArgs(args.NewPName, args.NewPdesc));
			}
			//TODO : add correct task id
			_lastRecord = new WindowLogStructure(args.NewPID,
			                                args.NewPName,
											args.NewPdesc,
			                                args.NewWindowText,
			                                DateTime.Now,
			                                0);
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
