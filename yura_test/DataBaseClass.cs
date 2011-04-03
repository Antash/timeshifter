using System;
using System.Data;


namespace WindowsFormsApplication1
{
	class DataBaseClass
	{
		private string _fileName;
		private DataSet _ds;
		private DataTable _dtTasks;
		private DataTable _dtApplication;
		private DataTable _stTaskApplication;

		public DataBaseClass()
		{
			_ds = new DataSet();
			_dtTasks = new DataTable("Tasks");

			_dtTasks.Columns.Add("Id", typeof(int));
			_dtTasks.Columns["Id"].Unique = true;
			_dtTasks.Columns["Id"].AutoIncrement = true;
			_dtTasks.Columns.Add("TaskName", typeof(string));
			_dtTasks.Columns.Add("Discription", typeof(string));
			_dtTasks.Columns.Add("PlanTime", typeof(DateTime));

			_ds.Tables.Add(_dtTasks);

			_dtApplication = new DataTable("Application");

			_dtApplication.Columns.Add("Id", typeof(int));
			_dtApplication.Columns["Id"].Unique = true;
			_dtApplication.Columns["Id"].AutoIncrement = true;
			_dtApplication.Columns.Add("ApplicationName", typeof(string));

			_ds.Tables.Add(_dtApplication);

			_stTaskApplication = new DataTable("TaskApplication");

			_stTaskApplication.Columns.Add("TaskId", typeof(int));
			//_stTaskApplication.Columns["TaskId"].
			_stTaskApplication.Columns.Add("ApplicationId", typeof(int));
			_stTaskApplication.Constraints.Add("pk", new[] {
				_stTaskApplication.Columns[0],
				_stTaskApplication.Columns[1]}, true);

			TaskStructure task1 = new TaskStructure("Task1", "Discription1", DateTime.Now);
			NewTask(task1);
			TaskStructure task2 = new TaskStructure("Task2", "Discription2", DateTime.Now);
			NewTask(task2);

		}

		public DataBaseClass(string fileName)
		{
			_fileName = fileName;
			_ds.ReadXmlSchema(_fileName);
		}

		public void CreateSchemaXml(string fileName)
		{
			_fileName = fileName;
			_ds.WriteXmlSchema(_fileName);

		}

		public void CreateBackUpDataBase(string fileName)
		{
			_fileName = fileName;
			_ds.WriteXml(_fileName, XmlWriteMode.WriteSchema);

		}

		public void LoadDataBase(string fileName)
		{
			_fileName = fileName;
			_ds.ReadXml(_fileName);

		}

		public void NewTask(TaskStructure task)
		{
			var newLine = _dtTasks.NewRow();
			newLine["TaskName"] = task.TaskName;
			newLine["PlanTime"] = task.PlanTime;
			newLine["Discription"] = task.Discription;
			_dtTasks.Rows.Add(newLine);
		}

		public void NewApplication(string applicationName)
		{
			var newLine = _dtApplication.NewRow();
			newLine["ApplicationName"] = applicationName;
			_dtApplication.Rows.Add(newLine);
		}

		public void NewSettingsRule(int taskId, int applicationID)
		{
			var newLine = _stTaskApplication.NewRow();
			newLine["TaskId"] = taskId;
			newLine["ApplicationId"] = applicationID;
			_stTaskApplication.Rows.Add(newLine);
		}

	}
}
