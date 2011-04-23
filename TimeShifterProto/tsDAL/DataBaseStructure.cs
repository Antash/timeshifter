using System;
using System.Data;
using System.IO;
using System.Linq;
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

		public void NewApplication(TsApplication app)
		{
			_dtApplication.Rows.Add(app.ToDataRow());
		}

		public void NewTask(TsTask task)
		{
			_dtTasks.Rows.Add(task.ToDataRow());
		}

		public void DelTask(TsTask task)
		{
			_dtTasks.Rows.Remove(_dtTasks.Rows.Find(task.Id));
		}

		public void UpdateTask(TsTask task)
		{
			//TODO : very bad code!
			//refactoring is needed
			var q = (from oldTask in _dtTasks.AsEnumerable()
					where (int)oldTask["Id"] == task.Id
					select oldTask).First();
			q.SetField("ActualTimeToSpend", task.ActualTimeToSpend);
		}

		public void AddTaskApplicationSetting(DataRow toDataRow)
		{
			_dtTaskApplication.Rows.Add(toDataRow);
		}

		public void DelTaskApplicationSetting(DataRow toDataRow)
		{
			_dtTaskApplication.Rows.Remove(_dtTaskApplication.Rows.Find(new[]{toDataRow[0], toDataRow[1]}));
		}

		public DataTable CreateReport()
		{
			//TODO : needs to be refactored
			var q = (from oldTask in _dtTasks.AsEnumerable()
			         select new
			                	{
									name = oldTask.Field<string>("TaskName"),
									atts = oldTask.Field<TimeSpan>("ActualTimeToSpend")
			                	});
			var resRep = new DataTable();
			resRep.Columns.Add("name", typeof (string));
			resRep.Columns.Add("atts", typeof (TimeSpan));
			foreach (var r in q)
			{
				resRep.Rows.Add(r.name, r.atts);
			}
			return resRep;
		}
	}
}
