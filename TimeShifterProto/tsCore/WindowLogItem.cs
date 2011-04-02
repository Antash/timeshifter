using System;

namespace tsCore
{
    [Serializable]
    class WindowLogItem
    {
    	public WindowLogItem(int pid, string procesName, string windowTitle, DateTime ts, int taskId)
        {
            Pid = pid;
        	TaskId = taskId;
        	ProcesName = procesName;
            WindowTitle = windowTitle;
            Ts = ts;
        }

    	public int TaskId { get; set; }

    	public DateTime Ts { get; set; }

    	public int Pid { get; set; }

    	public string ProcesName { get; set; }

    	public string WindowTitle { get; set; }
    }
}
