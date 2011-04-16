using System;
using System.Collections.Generic;
using System.Data;

namespace tsCoreStructures
{
	public class TsTask : TsBaseStruct, IEquatable<TsTask>
	{
		protected static DataTable StructTable;

		[DataBaseColumn(true)]
		public int Id { get; set; }

		[DataBaseColumn]
		public string TaskName { get; set; }

		[DataBaseColumn]
		public DateTime BeginTime { get; set; }

		public DateTime EndTime { get; set; }

		public TimeSpan PlanTimeToSpend { get; set; }

		public TimeSpan ActualTimeToSpend { get; set; }

		[DataBaseColumn]
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

		public bool Equals(TsTask other)
		{
			return TaskName == other.TaskName;
		}

		public DataRow ToDataRow()
		{
			return ToDataRow(StructTable);
		}

		public new DataTable BuildDataStructure()
		{
			return StructTable = base.BuildDataStructure();
		}
	}

	public delegate void NewTaskHandler(object sender, NewTaskHandlerArgs args);

	public class NewTaskHandlerArgs
	{
		public TsTask Task { get; private set; }

		public NewTaskHandlerArgs(TsTask task)
		{
			Task = task;
		}
	}
}
