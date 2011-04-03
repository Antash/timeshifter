using System;

namespace WindowsFormsApplication1
{
    class TaskStructure
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public DateTime PlanTime { get; set; }
        public string Discription { get; set; }

        public TaskStructure()
        {

            Id = 0;
            TaskName = "";            
            Discription = "";
            PlanTime = DateTime.MinValue;
            //это конструктор
        }       
        public TaskStructure(string taskName, string taskDiscription, DateTime ts)
        {
            TaskName = taskName;
            Discription = taskDiscription;
            PlanTime = ts;
        }
           public TaskStructure(int id, string taskName, string taskDiscription, DateTime ts)
        {
            Id = id;
            TaskName = taskName; 
            Discription = taskDiscription;
            PlanTime = ts;
        }
    }
}
