using System;
using System.Data;
using System.Drawing;
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

		public event AppAdd newApp;

		public void InvokeNewApp(AppAddArgs args)
		{
			AppAdd handler = newApp;
			if (handler != null) handler(this, args);
		}

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
			if (!_taskDbs.IsApplicationExist(pname))
			{
				_taskDbs.NewApplication(pname,
					IconHelper.GetApplicationIcon(pname, false),
					IconHelper.GetApplicationIcon(pname, true));
				//InvokeNewApp(new AppAddArgs(pname, WindowTracker.GetApplicationIcon(pname, false)));
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
			set { AutoStart.SetAutoStart(_assemblyLocation, value); }
		}

		public bool IsCoreRunning { get; set; }

		public void Enable()
		{
			_tsWinLogger.Enable();
			_tsUserActLogger.Enable();
			IsCoreRunning = true;
		}

		public void Disable()
		{
			_tsWinLogger.Disable();
			_tsUserActLogger.Disable();
			IsCoreRunning = false;
		}
	}

	public class AppAddArgs
	{
		public string Name { get; set; }
		public Icon Image { get; set; }
		public AppAddArgs(string name, Icon image)
		{
			Name = name;
			Image = image;
		}
	}

	public delegate void AppAdd(object sender, AppAddArgs args);
}
