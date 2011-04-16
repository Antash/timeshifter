using System;
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
		private const string Filename = "demo.txt";
		private readonly WindowLogger _tsWinLogger;
		private readonly UserActLogger _tsUserActLogger;
		private readonly DataBaseStructure _taskDbs;
		private readonly List<TsTask> _taskList;
		private readonly List<TsApplication> _applicationList;
		private readonly Dictionary<string, UserActLogStructure> _tsUserActLog;

		private static volatile TsAppCore _instance;
		private static readonly object SyncRoot = new Object();

		public event NewApplicationHandler NewApplication;

		public void InvokeNewApplication(NewApplicationHandlerArgs args)
		{
			NewApplicationHandler handler = NewApplication;
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
		}

		private void ReadDataBase()
		{
			var dr = _taskDbs.GetApplications();
			while (dr.Read())
			{
				_applicationList.Add((TsApplication) new TsApplication().FromDataReader(dr));
			}
			dr.Close();

			dr = _taskDbs.GetTasks();
			while (dr.Read())
			{
				_taskList.Add((TsTask) new TsTask().FromDataReader(dr));
			}
			dr.Close();
		}

		~TsAppCore()
		{
			_taskDbs.CreateBackUpDataBase(Filename);
			_tsWinLogger.WriteBinary(Filename + "win.txt");
		}

		void TsWinLoggerAppChanged(object sender, AppChangedEventArgs args)
		{
			UserActLogStructure snapshot = _tsUserActLogger.UActLog;
			_tsUserActLogger.UActLog = new UserActLogStructure();
			string pname = args.ProcessName;
			string pdesc = args.ProcessDesc;
			if (!_tsUserActLog.ContainsKey(pdesc ?? pname))
				_tsUserActLog.Add(pdesc ?? pname, snapshot);
			else
				_tsUserActLog[pdesc ?? pname].Merge(snapshot);

			var app = new TsApplication(pname, pdesc);

			if (!_applicationList.Contains(app))
			{
				app.SmallIcon = IconHelper.GetApplicationIcon(pname, pdesc, false).ToBitmap();
				app.LargeIcon = IconHelper.GetApplicationIcon(pname, pdesc, true).ToBitmap();
				_applicationList.Add(app);
				_taskDbs.NewApplication(app.ToDataRow());
				InvokeNewApplication(new NewApplicationHandlerArgs(app));
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
}
