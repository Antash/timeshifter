using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace tsCoreStructures
{
	public class TsApplication
	{
		public bool IsRunning { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Icon SmallIcon { get; set; }
		public Icon LargeIcon { get; set; }
		public List<TsWindow> RunningWindows { get; set; }
		public List<TsWindow> AllWindows { get; set; }

		public TsApplication(TsApplication app)
		{
			Name = app.Name;
			SmallIcon = app.SmallIcon;
			LargeIcon = app.LargeIcon;
		}

		public TsApplication(string name)
		{
			Name = name;
		}

		public TsApplication(string name, string description, Icon smallIcon, Icon largeIcon)
			: this(name)
		{
			Description = description;
			SmallIcon = smallIcon;
			LargeIcon = largeIcon;
		}
	}
}
