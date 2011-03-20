using System;

namespace WindowsFormsApplication1
{
    [Serializable]
    class LogStructure
    {
        private int _pid;
        private string _procesName;
        private string _windowTitle;
        private DateTime _ts;
        public LogStructure()
        {
            _pid = 0;
            _procesName = "";
            _windowTitle = "";
            //это конструктор
        }
        public LogStructure(int pid, string procesName, string windowTitle, DateTime ts)
        {
            _pid = pid;
            _procesName = procesName;
            _windowTitle = windowTitle;
            _ts = ts;
        }

        public DateTime Ts
        {
            get { return _ts; }
            set { _ts = value; }
        }

        public int Pid
        {
            get { return _pid; }
             set { _pid = value; }
        }
        public string ProcesName
        {
            get { return _procesName; }
            set { _procesName = value; }
        }
        public string WindowTitle
        {
            get { return _windowTitle; }
            set { _windowTitle = value; }
        }
    }
}
