using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tsCoreStructures;
using tsPresenter.Base;

namespace tsPresenter.TaskManagement
{
	public interface ITaskManagementView : IView
	{
		List<ListViewItem> Applications { get;  set; }
		List<Image> AppIconsSmall { get; set; }
		List<Image> AppIconsLarge { get; set; }
		List<TreeNode> Tasks { get; set; }
		void AddNewApplication(TsApplication app);
		//void AddNewTask(TsTask task);
		event EventHandler Save;
		event NewTaskHandler NewTask;

	}	
	public delegate void NewTaskHandler(object sender, NewTaskHandlerArgs args);

	public class NewTaskHandlerArgs
	{
		public TsTask Task { get; private set; }

		public NewTaskHandlerArgs(TsTask task)
		{
			Task = task;
		}
	}
}
