using System;
using tsPresenter.Base;

namespace tsPresenter.Settings
{
	public interface ISettingsView : IView
	{
		bool IsAutostartEnabled { get; set; }
		bool IsCoreRunning { get; set; }
		event EventHandler DataChanged;
	}
}
