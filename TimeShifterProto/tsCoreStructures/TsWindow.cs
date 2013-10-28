using System;
using System.Collections.Generic;

namespace tsCoreStructures
{
	public class TsWindow : IEquatable<TsWindow>
	{
		public string Text { get; set; }
		public DateTime OpenTime { get; set; }
		public DateTime CloseTime { get; set; }
		public List<UserActLog> UserActSnapshots { get; set; }

		public TsWindow()
		{
			UserActSnapshots = new List<UserActLog>();
		}

		public TsWindow(string text, DateTime openTime)
			:this()
		{
			Text = text;
			OpenTime = openTime;
		}

		public bool Equals(TsWindow other)
		{
			return Text == other.Text;
		}
	}
}
