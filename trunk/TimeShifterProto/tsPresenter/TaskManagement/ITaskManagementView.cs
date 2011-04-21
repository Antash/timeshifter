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
		event EventHandler Save;
		event TsTask.NewTaskHandler NewTask;
		// Тоха, мне нужен класс настроек гдя можно сделать событие, пока что через таски

		event TsTask.NewSettingsHandler NewSettings;
	}	
}
