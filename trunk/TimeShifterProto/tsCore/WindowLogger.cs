using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using tsWin;

namespace tsCore
{
	class WindowLogger : IBinaryIo, IXMLIo
	{
		public event AppChangedHandler AppChanged;

		public void InvokeAppChanged(EventArgs args)
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

			_winTracker.ActStateChanged += WinTrackerActStateChanged;
		}

		void WinTrackerActStateChanged(object sender, ActStateChangedHandlerArgs args)
		{
			//TODO : add correct task id
			_lastRecord = new WindowLogStructure(args.NewPID,
			                                args.NewPName,
			                                args.NewWindowText,
			                                DateTime.Now,
			                                0);
			_windowLog.Add(_lastRecord);
			InvokeAppChanged(new EventArgs());
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
	}

	internal delegate void AppChangedHandler(object sender, EventArgs args);
}
