using System;
using tsCore.Interfaces;
using tsWin;
using System.Collections.Generic;

namespace tsCore.Classes
{
	public class TsAppCore : IManaged
	{
		private readonly WindowLogger _tsWinLogger;
		private readonly UserActLogger _tsUserActLogger;

		private Dictionary<string, UserActLogStructure> _tsUserActLog;

		private static volatile TsAppCore _instance;
		private static readonly object SyncRoot = new Object();

		private TsAppCore()
		{
			_tsWinLogger = new WindowLogger();
			_tsUserActLogger = new UserActLogger();
			_tsUserActLog = new Dictionary<string, UserActLogStructure>();

			_tsWinLogger.AppChanged += _tsWinLogger_AppChanged;
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

		public void SetAutostart(bool @checked)
		{
			if (@checked)
				AutoStart.SetAutoStart(_assemblyLocation);
			else
				AutoStart.UnSetAutoStart();
		}

		public void Enable()
		{
			_tsWinLogger.Enable();
			_tsUserActLogger.Enable();
		}

		public void Disable()
		{
			_tsWinLogger.Disable();
			_tsUserActLogger.Disable();
		}

		public void Manage(bool isEnable)
		{
			if (isEnable) 
				Enable();
			else
				Disable();
		}
	}
}
