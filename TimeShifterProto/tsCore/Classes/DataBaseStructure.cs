using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace tsCore.Classes
{
	class DataBaseStructure
	{
		private DataSet _ds;
		private DataTable _dtTasks;
		private DataTable _dtApplication;
		private DataTable _dtTaskApplication;

		public DataBaseStructure()
		{
			BuildStructure();
		}

		private void BuildStructure()
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

			_dtTaskApplication = new DataTable("TaskApplication");

			_dtTaskApplication.Columns.Add("TaskId", typeof(int));
			_dtTaskApplication.Columns.Add("ApplicationId", typeof(int));
			_dtTaskApplication.Constraints.Add("TaskApplicationPK", new[] {
				_dtTaskApplication.Columns["TaskId"],
				_dtTaskApplication.Columns["ApplicationId"]},
				true);

			_ds.Relations.Add("TaskTaskApplicationFK", _dtTasks.Columns["Id"], _dtTaskApplication.Columns["TaskId"]);
			_ds.Relations.Add("ApplicationTaskApplicationFK", _dtApplication.Columns["Id"], _dtTaskApplication.Columns["ApplicationId"]);
		}

		public DataBaseStructure(string fileName)
		{
			//_fileName = fileName;
			//_ds.ReadXmlSchema(_fileName);
			LoadDataBase(fileName);
		}

		public void CreateSchemaXml(string fileName)
		{
			_ds.WriteXmlSchema(fileName);

		}

		public void CreateBackUpDataBase(string fileName)
		{
			_ds.WriteXml(fileName, XmlWriteMode.WriteSchema);
		}

		public void LoadDataBase(string fileName)
		{
			_ds.ReadXml(fileName);
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

		public void NewSettingsRule(int taskId, int applicationId)
		{
			var newLine = _dtTaskApplication.NewRow();
			newLine["TaskId"] = taskId;
			newLine["ApplicationId"] = applicationId;
			_dtTaskApplication.Rows.Add(newLine);
		}
	}
}
