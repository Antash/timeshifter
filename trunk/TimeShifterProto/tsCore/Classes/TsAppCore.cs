using System;
using tsCore.Interfaces;
using tsCoreStructures;
using tsDAL;
using tsWin;
using System.Collections.Generic;

namespace tsCore.Classes
{
	public class TsAppCore : IManaged
	{
		private const string Filename = "demo.txt";
		private readonly WindowLogger _tsWinLogger;
		private readonly UserActLogger _tsUserActLogger;
		private readonly DataBaseStructure _taskDbs;
		private readonly List<TsTask> _taskList;
		private readonly List<TsApplication> _applicationList;
		private readonly Dictionary<string, UserActLogStructure> _tsUserActLog;

		private static volatile TsAppCore _instance;
		private static readonly object SyncRoot = new Object();

		public event TsApplication.NewApplicationHandler NewApplication;

		public void InvokeNewApplication(TsApplication.NewApplicationHandlerArgs args)
		{
			TsApplication.NewApplicationHandler handler = NewApplication;
			if (handler != null) handler(this, args);
		}

		protected TsAppCore()
		{
			_tsWinLogger = new WindowLogger();
			_tsUserActLogger = new UserActLogger();
			_tsUserActLog = new Dictionary<string, UserActLogStructure>();
			_taskDbs = new DataBaseStructure(Filename);
			_taskList = new List<TsTask>();
			_applicationList = new List<TsApplication>();

			ReadDataBase();

			_tsWinLogger.AppChanged += TsWinLoggerAppChanged;
			_tsWinLogger.StateChanged += TsWinLoggerStateChanged;
			_tsUserActLogger.SnapshotReady += _tsUserActLogger_SnapshotReady;
		}

		void _tsUserActLogger_SnapshotReady(object sender, UserActLogger.SnapshotReadyHandlerArgs args)
		{
			//TODO put here snapshot management code
			//UserActLogStructure snapshot = _tsUserActLogger.UActLog;
			//_tsUserActLogger.UActLog = new UserActLogStructure();
			//string pname = args.ProcessName;
			//string pdesc = args.ProcessDesc;
			//if (!_tsUserActLog.ContainsKey(pdesc ?? pname))
			//    _tsUserActLog.Add(pdesc ?? pname, snapshot);
			//else
			//    _tsUserActLog[pdesc ?? pname].Merge(snapshot);
		}

		void TsWinLoggerStateChanged(object sender, WindowLogger.AppWindowChangedHandlerArgs args)
		{
			var actApp = _applicationList.Find(app =>
										app.Name == args.Record.ProcesName &&
										app.Description == args.Record.ProcessDesc);
			if (actApp != null)
			{
				var wind = new TsWindow(args.Record.WindowTitle, args.Record.Ts);
				if (!actApp.RunningWindows.Contains(wind))
					actApp.RunningWindows.Add(wind);
			}
		}

		private void ReadDataBase()
		{
			var dr = _taskDbs.GetApplications();
			while (dr.Read())
			{
				_applicationList.Add((TsApplication)new TsApplication().FromDataReader(dr));
			}
			dr.Close();

			dr = _taskDbs.GetTasks();
			while (dr.Read())
			{
				_taskList.Add((TsTask)new TsTask().FromDataReader(dr));
			}
			dr.Close();
		}

		~TsAppCore()
		{
			_taskDbs.CreateBackUpDataBase(Filename);
			_tsWinLogger.WriteBinary(Filename + "win.txt");
		}

		void TsWinLoggerAppChanged(object sender, WindowLogger.AppChangedEventArgs args)
		{
			var app = new TsApplication(args.ProcessName, args.ProcessDesc);

			if (!_applicationList.Contains(app))
			{
				app.SmallIcon = IconHelper.GetApplicationIcon(app.Name, app.Description, false).ToBitmap();
				app.LargeIcon = IconHelper.GetApplicationIcon(app.Name, app.Description, true).ToBitmap();
				_applicationList.Add(app);
				_taskDbs.NewApplication(app.ToDataRow());
				InvokeNewApplication(new TsApplication.NewApplicationHandlerArgs(app));
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

		public bool IsRunning { get; private set; }

		public void Enable()
		{
			_tsWinLogger.Enable();
			_tsUserActLogger.Enable();
			IsRunning = true;
		}

		public void Disable()
		{
			_tsWinLogger.Disable();
			_tsUserActLogger.Disable();
			IsRunning = false;
		}

		public IEnumerable<TsApplication> Applications
		{
			get { return _applicationList; }
		}

		public IEnumerable<TsTask> Tasks
		{
			get { return _taskList; }
		}

		public void NewTask(TsTask task)
		{
			if (!_taskList.Contains(task))
			{
				_taskList.Add(task);
				_taskDbs.NewTask(task.ToDataRow());
			}
		}
	}
}
