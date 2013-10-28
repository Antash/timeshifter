using System;

namespace tsCoreStructures
{
	[Serializable]
	public class WindowLog
	{
		public WindowLog()
		{
		}

		public WindowLog(int pid,
			            string procesName,
			            string processDesc,
			            string windowTitle,
			            DateTime ts,
			            int taskId)
		{
			Pid = pid;
			TaskId = taskId;
			ProcesName = procesName;
			ProcessDesc = processDesc;
			WindowTitle = windowTitle;
			Ts = ts;
		}

		public int TaskId { get; set; }

		public DateTime Ts { get; set; }

		public int Pid { get; set; }

		public string ProcesName { get; set; }

		public string ProcessDesc { get; set; }

		public string WindowTitle { get; set; }
	}
}
