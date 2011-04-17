using tsCore.Classes;

namespace tsPresenter.Settings
{
	public class SettingsModel : ISettingsModel
	{
		public bool IsAutostartEnabled
		{
			get { return TsAppManager.IsAutostartEnabled; }
			set { TsAppManager.IsAutostartEnabled = value; }
		}

		public bool IsCoreRunning
		{
			get { return TsAppManager.IsCoreRunning; }
			set { TsAppManager.IsCoreRunning = value; }
		}
	}
}
