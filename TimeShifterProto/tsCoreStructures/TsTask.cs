using System;
using System.Collections.Generic;
using System.Data;
using tsCoreStructures.Base;

namespace tsCoreStructures
{
	/// <summary>
	/// This class represens structute of task
	/// </summary>
	public class TsTask : TsBaseStruct, IEquatable<TsTask>
	{
		/// <summary>
		/// Table contains class data structure
		/// </summary>
		protected static DataTable StructTable;

		/// <summary>
		/// Unique task id
		/// </summary>
		[DataBaseColumn(true)]
		public int Id { get; set; }

		/// <summary>
		/// Task name
		/// </summary>
		[DataBaseColumn]
		public string TaskName { get; set; }

		/// <summary>
		/// Time when task started
		/// </summary>
		[DataBaseColumn]
		public DateTime BeginTime { get; set; }

		/// <summary>
		/// Time when the task ended
		/// </summary>
		[DataBaseColumn]
		public DateTime EndTime { get; set; }

		/// <summary>
		/// Planned time to finish task
		/// </summary>
		[DataBaseColumn]
		public TimeSpan PlanTimeToSpend { get; set; }

		/// <summary>
		/// Actual finish time
		/// </summary>
		[DataBaseColumn]
		public TimeSpan ActualTimeToSpend { get; set; }

		/// <summary>
		/// Short description of the task
		/// </summary>
		[DataBaseColumn]
		public string Discription { get; set; }

		/// <summary>
		/// Applications which are used in this task
		/// </summary>
		public List<TsApplication> AssignedApplications { get; set; }

		#region constructors

		/// <summary>
		/// Creates new instance of TsApplication
		/// </summary>
		public TsTask()
		{
			AssignedApplications = new List<TsApplication>();
		}

		public TsTask(string taskName, string taskDiscription, DateTime ts)
			: this()
		{
			TaskName = taskName;
			Discription = taskDiscription;
			BeginTime = ts;
		}

		public TsTask(int id, string taskName, string taskDiscription, DateTime ts)
			: this(taskName, taskDiscription, ts)
		{
			Id = id;
		}

		#endregion

		/// <summary>
		/// Class comparer
		/// </summary>
		/// <param name="other">Other class copy</param>
		/// <returns>Returns true if copies are equals</returns>
		public bool Equals(TsTask other)
		{
			return TaskName == other.TaskName;
		}

		#region delegates & event args

		public delegate void NewTaskHandler(object sender, NewTaskHandlerArgs args);

		public class NewTaskHandlerArgs
		{
			public TsTask Task { get; private set; }

			public NewTaskHandlerArgs(TsTask task)
			{
				Task = task;
			}
		}

		#endregion
	}
}
