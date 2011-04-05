using System;
using System.Data;
using System.Drawing;
using tsCore.Classes;

namespace tsDAL
{
	public class DataBaseStructure
	{
		private DataSet _ds;
		private DataTable _dtTasks;
		private DataTable _dtApplication;
		private DataTable _dtTaskApplication;

		public DataBaseStructure()
		{
			_ds = new DataSet();
			BuildStructure();
		}

		internal DataSet DS
		{
			get { return _ds; }
		}

		private void BuildStructure()
		{
			_dtTasks = new DataTable("Tasks");

			_dtTasks.Columns.Add("Id", typeof(int));
			_dtTasks.Columns["Id"].Unique = true;
			_dtTasks.Columns["Id"].AutoIncrement = true;
			_dtTasks.Columns.Add("TaskName", typeof(string));
			_dtTasks.Columns.Add("Discription", typeof(string));
			_dtTasks.Columns.Add("PlanTime", typeof(DateTime));

			_ds.Tables.Add(_dtTasks);

			_dtApplication = new DataTable("Application");

			//_dtApplication.Columns.Add("Id", typeof(int));
			//_dtApplication.Columns["Id"].Unique = true;
			//_dtApplication.Columns["Id"].AutoIncrement = true;
			_dtApplication.Columns.Add("ApplicationName", typeof(string));
			_dtApplication.Columns.Add("SmallIcon", typeof(Icon));
			_dtApplication.Columns.Add("LargeIcon", typeof(Icon));
			_dtApplication.Constraints.Add("PK", _dtApplication.Columns["ApplicationName"], true);
			_ds.Tables.Add(_dtApplication);

			_dtTaskApplication = new DataTable("TaskApplication");

			_dtTaskApplication.Columns.Add("TaskId", typeof(int));
			_dtTaskApplication.Columns.Add("ApplicationId", typeof(string));
			_dtTaskApplication.Constraints.Add("TaskApplicationPK", new[] {
				_dtTaskApplication.Columns["TaskId"],
				_dtTaskApplication.Columns["ApplicationId"]},
				true);

			_ds.Tables.Add(_dtTaskApplication);

			_ds.Relations.Add("TaskTaskApplicationFK",
				_ds.Tables["Tasks"].Columns["Id"],
				_ds.Tables["TaskApplication"].Columns["TaskId"]);
			_ds.Relations.Add("ApplicationTaskApplicationFK",
				_ds.Tables["Application"].Columns["ApplicationName"],
				_ds.Tables["TaskApplication"].Columns["ApplicationId"]);
		}

		public DataBaseStructure(string fileName)
			: this()
		{
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
			try
			{
				_ds.ReadXml(fileName);
			}
			catch (Exception)
			{
				//	BuildStructure();
			}
		}

		public void NewTask(TaskStructure task)
		{
			var newLine = _dtTasks.NewRow();
			newLine["TaskName"] = task.TaskName;
			newLine["PlanTime"] = task.PlanTime;
			newLine["Discription"] = task.Discription;
			_dtTasks.Rows.Add(newLine);
		}

		public void NewApplication(string applicationName, Icon smallIcon, Icon largeIcon)
		{
			var newLine = _dtApplication.NewRow();
			newLine["ApplicationName"] = applicationName;
			newLine["SmallIcon"] = smallIcon;
			newLine["LargeIcon"] = largeIcon;
			_dtApplication.Rows.Add(newLine);
		}

		public void NewSettingsRule(int taskId, int applicationId)
		{
			var newLine = _dtTaskApplication.NewRow();
			newLine["TaskId"] = taskId;
			newLine["ApplicationId"] = applicationId;
			_dtTaskApplication.Rows.Add(newLine);
		}

		public bool ApplicationExist(string applicationName)
		{
			return _ds.Tables["Application"].Rows.Find(applicationName) != null;
		}
	}
}
