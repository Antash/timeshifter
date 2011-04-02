using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using tsCore.Interfaces;
using tsWin;

namespace tsCore.Classes
{
	class WindowLogger : IBinaryIo, IXMLIo, IManaged
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
			_winTracker = new WindowTracker();
			_windowLog = new List<WindowLogStructure>();
			_lastRecord = new WindowLogStructure();
		}

		void WinTrackerActStateChanged(object sender, ActStateChangedHandlerArgs args)
		{
			if (args.NewPName != _lastRecord.ProcesName)
				InvokeAppChanged(new AppChangedEventArgs(_lastRecord.ProcesName));
			//TODO : add correct task id
			_lastRecord = new WindowLogStructure(args.NewPID,
			                                args.NewPName,
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

		public void ReadXml(string filename)
		{
			throw new NotImplementedException();
		}

		public void WriteXml(string filename)
		{
			throw new NotImplementedException();
		}

		public void Enable()
		{
			_winTracker.ActStateChanged += WinTrackerActStateChanged;
		}

		public void Disable()
		{
			_winTracker.ActStateChanged -= WinTrackerActStateChanged;
		}

		public void Manage(bool isEnable)
		{
			if (isEnable)
				Enable();
			else
				Disable();
		}
	}

	internal delegate void AppChangedHandler(object sender, AppChangedEventArgs args);

	internal class AppChangedEventArgs
	{
		public string ProcessName { get; private set; }

		public AppChangedEventArgs(string processName)
		{
			ProcessName = processName;
		}
	}
}
