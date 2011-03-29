using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class DataBaseClass
    {
        private string _fileName;
        private DataSet _ds;
        private DataTable _dtTasks;

        public DataBaseClass()
        {
            _ds = new DataSet();
            _dtTasks = new DataTable("tasks");
            _dtTasks.Columns.Add("Discription", typeof(string));
            _dtTasks.Columns.Add("PlanTime", typeof(DateTime));

            //dt.Rows.Add(dr);
            //dt.Columns["fgf"].Unique
            _ds.Tables.Add(_dtTasks);
            //ds.Relations.Add(
            //ds.WriteXmlSchema("sch.txt");
            //ds.WriteXml("out.txt", XmlWriteMode.IgnoreSchema);
            //ds.ReadXmlSchema("sch.txt");
        }

        public DataBaseClass(string fileName)
        {
            _fileName = fileName;
            _ds.ReadXmlSchema(_fileName);
            //_dtTasks = _ds._dtTasks;
        }

        public void CreateShemaXml(string fileName)
        {
            _fileName = fileName;
            _ds.WriteXmlSchema(_fileName);
            
        }

    }
}
