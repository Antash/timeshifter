using tsPresenter.Base;

namespace tsPresenter.Settings
{
	public interface ISettingsModel : IModel
	{
		bool IsAutostartEnabled { get; set; }
		bool IsCoreRunning { get; set; }
	}
}
