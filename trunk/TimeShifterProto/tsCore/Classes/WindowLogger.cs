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
		
		//+++ Yura: add new event checking for new process

		//public event AppNewProcessStarted AppNewProcess;

		//public void InvokeNewProcessStarted(AppChangedEventArgs args)
		//{
		//	AppNewProcessStarted newProcess = AppNewProcess;
		//	if (newProcess != null) newProcess(this, args);
		//}
		//--- Yura: add new event checking for new process



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
				//+++ Yura: add new event checking for new process
				// Тоха в каком месте будет храниться созданный в начале работы проги класс DataBaseStructure?
				// Мне нужен тут доступ к созданному экземпляру, для проверки на наличие подобного процесса
				//--- Yura: add new event checking for new process
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

	//+++ Yura: add new event checking for new process

	//internal delegate void AppNewProcessStarted(object sender, AppChangedEventArgs args);

	//--- Yura: add new event checking for new process

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
