using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace tsCoreStructures
{
	public class TsApplication
	{
		public string Name { get; set; }
		public Icon SmallIcon { get; set; }
		public Icon LargeIcon { get; set; }

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

		public TsApplication(string name, Icon smallIcon, Icon largeIcon)
			: this(name)
		{
			SmallIcon = smallIcon;
			LargeIcon = largeIcon;
		}


	}
}
