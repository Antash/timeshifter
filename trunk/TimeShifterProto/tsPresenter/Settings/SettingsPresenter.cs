using System;
using tsPresenter.Base;

namespace tsPresenter.Settings
{
	public class SettingsPresenter : Presenter
	{
		public SettingsPresenter(
			ISettingsModel model, 
			ISettingsView view) 
			: base(model, view)
		{
			Initialize();
		}

		protected override void WireUpEvents()
		{
			((ISettingsView)View).DataChanged += SettingsPresenterDataChanged;
		}

		void SettingsPresenterDataChanged(object sender, EventArgs e)
		{
			SetModelPropertiesFromView();
		}

		protected override sealed void Initialize()
		{
			SetViewPropertiesFromModel();
			WireUpEvents();
		}
	}
}
