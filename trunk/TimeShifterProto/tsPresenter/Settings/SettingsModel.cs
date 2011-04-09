using tsCore.Classes;

namespace tsPresenter.Settings
{
	public class SettingsModel : ISettingsModel
	{
		public bool IsAutostartEnabled
		{
			get { return TsAppCore.Instance.IsAutostartEnabled; }
			set { TsAppCore.Instance.IsAutostartEnabled = value; }
		}

		public bool IsCoreRunning
		{
			get { return TsAppCore.Instance.IsCoreRunning; }
			set { TsAppCore.Instance.IsCoreRunning = value; }
		}
	}
}
