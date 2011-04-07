using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tsPresenter
{
	public interface ISettingsView
	{
		bool IsAutostartEnabled { get; set; }
		bool IsCoreRunning { get; set; }
	}
}
