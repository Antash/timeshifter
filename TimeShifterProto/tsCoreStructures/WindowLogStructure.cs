using System;

namespace tsCore.Classes
{
    [Serializable]
    public class WindowLogStructure
    {
		public WindowLogStructure()
		{
			Pid = 0;
			TaskId = 0;
			ProcesName = "";
			WindowTitle = "";
			Ts = DateTime.MinValue;
		}

    	public WindowLogStructure(int pid, string procesName, string windowTitle, DateTime ts, int taskId)
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
