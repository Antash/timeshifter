using System;
using System.Data;
using System.IO;
using tsCoreFW;
using tsCoreStructures;

namespace tsDAL
{
	public class DataBaseStructure
	{
		private readonly DataSet _ds;
		private DataTable _dtTasks;
		private DataTable _dtApplication;
		private DataTable _dtTaskApplication;

		public DataBaseStructure(string fileName)
		{
			_ds = new DataSet();
			BuildStructure();
			LoadDataBase(fileName);
		}

		private void BuildStructure()
		{
			_dtTasks = new TsTask().BuildDataStructure();
			_ds.Tables.Add(_dtTasks);

			_dtApplication = new TsApplication().BuildDataStructure();
			_ds.Tables.Add(_dtApplication);

			//_dtTaskApplication = new DataTable("TaskApplication");

			//_dtTaskApplication.Columns.Add("TaskId", typeof(int));
			//_dtTaskApplication.Columns.Add("ApplicationId", typeof(string));
			//_dtTaskApplication.Constraints.Add("TaskApplicationPK", new[] {
			//    _dtTaskApplication.Columns["TaskId"],
			//    _dtTaskApplication.Columns["ApplicationId"]},
			//    true);

			//_ds.Tables.Add(_dtTaskApplication);

			//_ds.Relations.Add("TaskTaskApplicationFK",
			//    _ds.Tables["Tasks"].Columns["Id"],
			//    _ds.Tables["TaskApplication"].Columns["TaskId"]);
			//_ds.Relations.Add("ApplicationTaskApplicationFK",
			//    _ds.Tables["Application"].Columns["ApplicationName"],
			//    _ds.Tables["TaskApplication"].Columns["ApplicationId"]);
		}

		public void CreateSchemaXml(string fileName)
		{
			_ds.WriteXmlSchema(fileName);
		}

		public void CreateBackUpDataBase(string fileName)
		{
			_ds.WriteXml(fileName);
		}

		public void LoadDataBase(string fileName)
		{
			try
			{
				if (File.Exists(fileName))
					_ds.ReadXml(fileName);
			}
			catch (Exception e)
			{
				ErrorManager.Instance.RiseError("DAL", e.Message);
			}
		}

		public DataTableReader GetApplications()
		{
			return _dtApplication.CreateDataReader();
		}

		public DataTableReader GetTasks()
		{
			return _dtTasks.CreateDataReader();
		}

		public void NewApplication(DataRow toDataRow)
		{
			_dtApplication.Rows.Add(toDataRow);
		}

		public void NewTask(DataRow task)
		{
			_dtTasks.Rows.Add(task);
		}
	}
}
