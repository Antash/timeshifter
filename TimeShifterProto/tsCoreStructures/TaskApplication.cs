using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using tsCoreStructures.Base;

namespace tsCoreStructures
{
	public class TaskApplication : TsBaseStruct
	{
		[DataBaseColumn(IsPrimaryKey = true)]
		public int TaskId { get; set; }

		[DataBaseColumn(IsPrimaryKey = true)]
		public int ApplicationId { get; set; }

		[DataBaseColumn]
		public TimeSpan SpendTime { get; set; }
	}
}
