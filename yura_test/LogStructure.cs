using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class LogStructure
    {

        public int pid;
        public string ProcesName;
        public string WindowTitle;

        public LogStructure()
        {
            //это конструктор
        }
        public LogStructure(int pid, string ProcesName, string WindowTitle)
        {
            this.pid = pid;
            this.ProcesName = ProcesName;
            this.WindowTitle = WindowTitle;
        }
    }
}
