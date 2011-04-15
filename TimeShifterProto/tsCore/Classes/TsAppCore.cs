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
		private readonly Dictionary<string, TsApplication> _applicationList;
		private readonly Dictionary<string, UserActLogStructure> _tsUserActLog;

		private static volatile TsAppCore _instance;
		private static readonly object SyncRoot = new Object();

		protected TsAppCore()
		{
			_tsWinLogger = new WindowLogger();
			_tsUserActLogger = new UserActLogger();
			_tsUserActLog = new Dictionary<string, UserActLogStructure>();
			_taskDbs = DataBaseStructure.Instance;
			_taskDbs.Initialize(Filename);
			_taskList = new List<TsTask>();
			_applicationList = new Dictionary<string, TsApplication>();
			_tsWinLogger.AppChanged += _tsWinLogger_AppChanged;
		}

		~TsAppCore()
		{
			_taskDbs.CreateBackUpDataBase(Filename);
			_tsWinLogger.WriteBinary(Filename + "win.txt");
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
			string pdesc = args.ProcessDesc;
			if (!_tsUserActLog.ContainsKey(pdesc))
				_tsUserActLog.Add(pdesc, snapshot);
			else
				_tsUserActLog[pdesc].Merge(snapshot);

			if (!_applicationList.ContainsKey(pdesc))
				_applicationList.Add(pdesc, new TsApplication(
					pname,
					pdesc,
					IconHelper.GetApplicationIcon(pname, pdesc, false),
					IconHelper.GetApplicationIcon(pname, pdesc, true)));
			//NOTE 2 Yura: This is more correct way!)))
			if (!_taskDbs.IsApplicationExist(pname))
			{
				_taskDbs.NewApplication(pdesc,
					IconHelper.GetApplicationIcon(pname, pdesc, false),
					IconHelper.GetApplicationIcon(pname, pdesc, true));
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
}
