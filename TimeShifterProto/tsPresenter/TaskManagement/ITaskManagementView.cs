using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tsCoreStructures;
using tsCoreStructures.Base;
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
		event EventHandler Save;
		event TsTask.NewTaskHandler NewTask;
		event AssociativeBaseStruct.AssociativeHandler NewSettings;
	}	
}
