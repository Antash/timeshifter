using System;
using System.Collections.Generic;

namespace tsCoreStructures
{
	public class TsWindow
	{
		public string Text { get; set; }
		public DateTime OpenTime { get; set; }
		public DateTime CloseTime { get; set; }
		public IEnumerable<UserActLogStructure> UserActSnapshots { get; set; }
	}
}
