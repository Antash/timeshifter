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
		TreeNodeCollection Tasks { get; set; }
		void AddNewApplication(TsApplication app);
		void AddNewTask(TsTask task);
		event EventHandler Save;
	}
}
