using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace tsCoreStructures
{
	[Serializable]
	public class UserActLogStructure
	{
		public Dictionary<Keys, int> KeyLog { get; set; }
		public MouseActData MouseLog { get; set; }

		public UserActLogStructure()
		{
			KeyLog = new Dictionary<Keys, int>();
			MouseLog = new MouseActData();
		}

		public void Merge(UserActLogStructure additionLog)
		{
			MouseLog.Merge(additionLog.MouseLog);
			foreach (Keys k in additionLog.KeyLog.Keys)
			{
				if (!KeyLog.ContainsKey(k))
					KeyLog.Add(k, 0);
				KeyLog[k] += additionLog.KeyLog[k];
			}
		}
	}

	[Serializable]
	public class MouseActData
	{
		public Point LastPoint { get; set; }
		public Dictionary<MouseButtons, int> Clicks { get; set; }
		public long Delta { get; set; }
		public double Path { get; set; }

		public MouseActData()
		{
			Clicks = new Dictionary<MouseButtons, int>();
		}

		public void Merge(MouseActData additionLog)
		{
			LastPoint = additionLog.LastPoint;
			Delta += additionLog.Delta;
			Path += additionLog.Path;
			foreach (MouseButtons mb in additionLog.Clicks.Keys)
			{
				if (!Clicks.ContainsKey(mb))
					Clicks.Add(mb, 0);
				Clicks[mb] += additionLog.Clicks[mb];
			}
		}
	}
}
