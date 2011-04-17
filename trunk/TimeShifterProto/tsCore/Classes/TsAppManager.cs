using System;
using tsWin;

namespace tsCore.Classes
{
	public class TsAppManager
	{
		private static readonly string AssemblyLocation = Environment.CommandLine;

		public static bool IsAutostartEnabled
		{
			get { return AutoStart.IsAutoStartEnabled(AssemblyLocation); }
			set { AutoStart.SetAutoStart(AssemblyLocation, value); }
		}

		public static bool IsCoreRunning
		{
			get { return TsAppCore.Instance.IsRunning; }
			set
			{
				if (value) 
					TsAppCore.Instance.Enable(); 
				else 
					TsAppCore.Instance.Disable();
			}
		}
	}
}
