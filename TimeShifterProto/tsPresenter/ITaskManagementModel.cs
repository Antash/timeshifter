using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tsCoreStructures;

namespace tsPresenter
{
	public interface ITaskManagementModel
	{
		List<ListViewItem> Applications { get; }
		List<Image> AppIconsSmall { get; }
		List<Image> AppIconsLarge { get; }
		event NewApplicationHandler NewApplication;
	}

	public delegate void NewApplicationHandler(object sender, NewApplicationHandlerArgs args);

	public class NewApplicationHandlerArgs
	{
		public TsApplication App { get; private set; }

		public NewApplicationHandlerArgs(TsApplication app)
		{
			App = app;
		}
	}
}
