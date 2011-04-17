using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.ComponentModel;

namespace tsWin
{
	public delegate void ProcessEventHandler(Win32_Process proc);

	public class ProcessWatcher : ManagementEventWatcher
	{
		// События процесса
		public event ProcessEventHandler ProcessCreated;
		public event ProcessEventHandler ProcessDeleted;
		public event ProcessEventHandler ProcessModified;

		// WMI WQL запросы
		static readonly string WMI_OPER_EVENT_QUERY = @"SELECT * FROM __InstanceOperationEvent WITHIN 1 WHERE TargetInstance ISA 'Win32_Process'"; // запрос на получения списка всех процессов
		static readonly string WMI_OPER_EVENT_QUERY_WITH_PROC = WMI_OPER_EVENT_QUERY + " and TargetInstance.Name = '{0}'"; // запрос на получение конкретного процесса по имени запущеного .exe файла

		public ProcessWatcher()
		{
			Init(string.Empty);
		}

		public ProcessWatcher(string processName)
		{
			Init(processName);
		}
		private void Init(string processName)
		{
			this.Query.QueryLanguage = "WQL";
			if (string.IsNullOrEmpty(processName))
			{
				this.Query.QueryString = WMI_OPER_EVENT_QUERY;
			}
			else
			{
				this.Query.QueryString =
				string.Format(WMI_OPER_EVENT_QUERY_WITH_PROC, processName);
			}

			this.EventArrived += new EventArrivedEventHandler(watcher_EventArrived);
		}

		private void watcher_EventArrived(object sender, EventArrivedEventArgs e)
		{
			string eventType = e.NewEvent.ClassPath.ClassName;
			Win32_Process proc = new Win32_Process(e.NewEvent["TargetInstance"] as ManagementBaseObject);

			// определяем какое событие произошло
			switch (eventType)
			{
				case "__InstanceCreationEvent":
					if (ProcessCreated != null)
						ProcessCreated(proc);
					break;
				case "__InstanceDeletionEvent":
					if (ProcessDeleted != null)
						ProcessDeleted(proc);
					break;
				case "__InstanceModificationEvent":
					if (ProcessModified != null)
						ProcessModified(proc); break;
			}
		}
	}
}
