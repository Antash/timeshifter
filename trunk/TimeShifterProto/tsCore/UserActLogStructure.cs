using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace tsCore
{
	[Serializable]
	class UserActLogStructure
	{
		public Dictionary<Keys, int> KeyLog { get; set; }
		public MouseActData MouseLog { get; set; }

		public UserActLogStructure()
		{
			KeyLog = new Dictionary<Keys, int>();
		}
	}

	[Serializable]
	class MouseActData
	{
		public Point LastPoint { get; set; }
		public Dictionary<MouseButtons, int> Clicks { get; set; }
		public long Delta { get; set; }
		public double Path { get; set; }

		public MouseActData()
		{
			Clicks = new Dictionary<MouseButtons, int>();
		}
	}
}
