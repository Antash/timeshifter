using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tsCore.Classes;

namespace tsPresenter
{
	public class SettingsPresenter
	{
		private readonly ISettingsView _view;

		public SettingsPresenter(ISettingsView view)
		{
			_view = view;
		}

		public void Initialize()
		{
			_view.IsAutostartEnabled = TsAppCore.Instance.IsAutostartEnabled;
			_view.IsCoreRunning = TsAppCore.Instance.IsCoreRunning;
		}


		public void Save()
		{
			TsAppCore.Instance.IsAutostartEnabled = _view.IsAutostartEnabled;
			TsAppCore.Instance.IsCoreRunning = _view.IsCoreRunning;
		}
	}
}
