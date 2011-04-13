using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tsCoreStructures;
using tsPresenter.Base;

namespace tsPresenter.TaskManagement
{
	public interface ITaskManagementModel : IModel
	{
		List<ListViewItem> Applications { get; set; }
		List<Image> AppIconsSmall { get; set; }
		List<Image> AppIconsLarge { get; set; }
		TreeNodeCollection Tasks { get; set; }

		event NewApplicationHandler NewApplication;
		event NewTaskHandler NewTask;
	}

	public delegate void NewApplicationHandler(object sender, NewApplicationHandlerArgs args);
	public delegate void NewTaskHandler(object sender, NewTaskHandlerArgs args);

	public class NewApplicationHandlerArgs
	{
		public TsApplication App { get; private set; }

		public NewApplicationHandlerArgs(TsApplication app)
		{
			App = app;
		}
	}

	public class NewTaskHandlerArgs
	{
		public TsTask Task { get; private set; }

		public NewTaskHandlerArgs(TsTask task)
		{
			Task = task;
		}
	}
}
