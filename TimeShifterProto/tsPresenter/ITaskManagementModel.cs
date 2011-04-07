using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tsPresenter
{
	public interface ITaskManagementModel
	{
		List<ListViewItem> Applications { get; }
		List<Image> AppIconsSmall { get; }
		List<Image> AppIconsLarge { get; }
	}
}
