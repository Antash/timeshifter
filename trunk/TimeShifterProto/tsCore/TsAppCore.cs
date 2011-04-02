using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tsWin;

namespace tsCore
{
	public class TsAppCore
	{
		private WindowLogger _tsWinLogger;
		private UserActLogger _tsUserActLogger;

		private static volatile TsAppCore _instance;
		private static readonly object SyncRoot = new Object();

		private TsAppCore()
		{
			_tsWinLogger = new WindowLogger();
			_tsUserActLogger = new UserActLogger();

			_tsWinLogger.AppChanged += _tsWinLogger_AppChanged;
		}

		void _tsWinLogger_AppChanged(object sender, EventArgs args)
		{
			throw new NotImplementedException();
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
	}
}
