using System;
using System.Data;
using tsCore.Interfaces;
using tsCoreStructures;
using tsDAL;
using tsWin;
using System.Collections.Generic;

namespace tsCore.Classes
{
	public class TsAppCore : IManaged
	{
		private string _filename = "demo.txt";
		private readonly WindowLogger _tsWinLogger;
		private readonly UserActLogger _tsUserActLogger;
		private DataBaseStructure _taskDbs;

		private Dictionary<string, UserActLogStructure> _tsUserActLog;

		private static volatile TsAppCore _instance;
		private static readonly object SyncRoot = new Object();

		private TsAppCore()
		{
			_tsWinLogger = new WindowLogger();
			_tsUserActLogger = new UserActLogger();
			_tsUserActLog = new Dictionary<string, UserActLogStructure>();
			_taskDbs = new DataBaseStructure(_filename);
			_tsWinLogger.AppChanged += _tsWinLogger_AppChanged;
		}

		~TsAppCore()
		{
			_taskDbs.CreateBackUpDataBase(_filename);
			_tsWinLogger.WriteBinary(_filename + "win.txt");
		}

		public DataBaseStructure TaskDbs
		{
			get { return _taskDbs; }
		}

		void _tsWinLogger_AppChanged(object sender, AppChangedEventArgs args)
		{
			UserActLogStructure snapshot = _tsUserActLogger.UActLog;
			_tsUserActLogger.UActLog = new UserActLogStructure();
			string pname = args.ProcessName;
			if (!_tsUserActLog.ContainsKey(pname))
				_tsUserActLog.Add(pname, snapshot);
			else
				_tsUserActLog[pname].Merge(snapshot);

			//NOTE 2 Yura: This is more correct way!
			if (!_taskDbs.ApplicationExist(pname))
			{
				_taskDbs.NewApplication(pname,
					WindowTracker.GetApplicationIcon(pname, false),
					WindowTracker.GetApplicationIcon(pname, true));
			}
		}

		public static TsAppCore Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (SyncRoot)
					{
						if (_instance == null)
							_instance = new TsAppCore();
					}
				}
				return _instance;
			}
		}

		private readonly string _assemblyLocation = Environment.CommandLine;

		public bool IsAutostartEnabled
		{
			get { return AutoStart.IsAutoStartEnabled(_assemblyLocation); }
			set
			{
				if (value)
					AutoStart.SetAutoStart(_assemblyLocation);
				else
					AutoStart.UnSetAutoStart();
			}
		}

		public bool IsEnabled { get; set; }

		public void Enable()
		{
			_tsWinLogger.Enable();
			_tsUserActLogger.Enable();
			IsEnabled = true;
		}

		public void Disable()
		{
			_tsWinLogger.Disable();
			_tsUserActLogger.Disable();
			IsEnabled = false;
		}
	}
}
