using System;
using System.Data;
using System.IO;
using tsCoreFW;
using tsCoreStructures;
using tsCoreStructures.Base;

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

			_dtTaskApplication = new TaskApplication().BuildDataStructure();
			_ds.Tables.Add(_dtTaskApplication);
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

		public DataTableReader GetTaskApplicationSettings()
		{
			return _dtTaskApplication.CreateDataReader();
		}

		public void NewApplication(DataRow toDataRow)
		{
			_dtApplication.Rows.Add(toDataRow);
		}

		public void NewTask(DataRow task)
		{
			_dtTasks.Rows.Add(task);
		}

		public void AddTaskApplicationSetting(DataRow toDataRow)
		{
			_dtTaskApplication.Rows.Add(toDataRow);
		}

		public void DelTaskApplicationSetting(DataRow toDataRow)
		{
			_dtTaskApplication.Rows.Remove(_dtTaskApplication.Rows.Find(new[]{toDataRow[0], toDataRow[1]}));
		}
	}
}
