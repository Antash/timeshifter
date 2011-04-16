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
		List<TreeNode> Tasks { get; set; }
		event NewApplicationHandler NewApplication;
		void AddNewTask(TsTask task);
	}
}
