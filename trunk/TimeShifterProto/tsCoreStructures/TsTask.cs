using System;
using System.Collections.Generic;

namespace tsCoreStructures
{
	public class TsTask
	{
		public int Id { get; set; }
		public string TaskName { get; set; }
		public DateTime BeginTime { get; set; }
		public DateTime EndTime { get; set; }
		public TimeSpan PlanTimeToSpend { get; set; }
		public TimeSpan ActualTimeToSpend { get; set; }
		public string Discription { get; set; }
		public List<TsApplication> AssignedApplications { get; set; }

		public TsTask()
		{
			Id = 0;
			TaskName = "";
			Discription = "";
			BeginTime = DateTime.MinValue;
		}

		public TsTask(string taskName, string taskDiscription, DateTime ts)
		{
			TaskName = taskName;
			Discription = taskDiscription;
			BeginTime = ts;
		}

		public TsTask(int id, string taskName, string taskDiscription, DateTime ts)
		{
			Id = id;
			TaskName = taskName;
			Discription = taskDiscription;
			BeginTime = ts;
		}
	}
}
