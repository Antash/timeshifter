using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tsCoreStructures;

namespace tsPresenter
{
	public interface ITaskManagementView
	{
		List<ListViewItem> Applications { set; }
		List<Image> AppIconsSmall { set; }
		List<Image> AppIconsLarge { set; }
		void AddNewApplication(TsApplication app);
	}
}
