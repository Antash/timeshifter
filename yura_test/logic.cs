using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class Logic
    {
        wincore.WinApiWrapper wp;
        public List<LogStructure> log;
        private LogStructure lastrecord;
        public Logic()
        {
            log = new List<LogStructure>();
            wp = new wincore.WinApiWrapper();
            lastrecord = new LogStructure();
            wp.actPidChanged += new wincore.actPidChangedHandler(wp_actPidChanged);
            wp.actPNameChanged += new wincore.actPNameChangedHandler(wp_actPNameChanged);
            wp.actWintaoTextChanged += new wincore.actWindowTextChangedHandler(wp_actWintaoTextChanged);
        }

        void wp_actWintaoTextChanged(object sender, wincore.actWindowTextChangedHandlerArgs args)
        {
            lastrecord = new LogStructure(lastrecord.Pid , lastrecord.ProcesName, args.newText, DateTime.Now);
            log.Add(lastrecord);
         //  throw new NotImplementedException();
        }

        void wp_actPNameChanged(object sender, wincore.actPNameChangedHandlerArgs args)
        {
            lastrecord = new LogStructure(lastrecord.Pid, args.newText, lastrecord.WindowTitle, DateTime.Now);
            log.Add(lastrecord);
          //  throw new NotImplementedException();
        }

        void wp_actPidChanged(object sender, wincore.actPidChangedArgs args)
        {
            lastrecord = new LogStructure(args.newPID, lastrecord.ProcesName, lastrecord.WindowTitle, DateTime.Now);
            log.Add(lastrecord);
            
            //throw new NotImplementedException();
        }
    }
}
