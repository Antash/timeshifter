using System;
using tsPresenter.Base;

namespace tsPresenter.Settings
{
	public interface ISettingsView : IView
	{
		bool IsAutostartEnabled { get; set; }
		bool IsCoreRunning { get; set; }
		bool Visible { get; set; }
		event EventHandler DataChanged;
		void Show();
		void BringToFront();
	}
}
