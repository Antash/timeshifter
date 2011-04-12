using System;
using System.Data;
using System.Drawing;
using System.IO;
using tsCoreFW;
using tsCoreStructures;

namespace tsDAL
{
	public class DataBaseStructure
	{
		public event Newapphandler Newapp;

		public void InvokeNewapp(NewapphandlerArgs args)
		{
			Newapphandler handler = Newapp;
			if (handler != null) handler(this, args);
		}

		private readonly DataSet _ds;
		private DataTable _dtTasks;
		private DataTable _dtApplication;
		private DataTable _dtTaskApplication;

		private static volatile DataBaseStructure _instance;
		private static readonly object SyncRoot = new Object();

		public static DataBaseStructure Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (SyncRoot)
					{
						if (_instance == null)
							_instance = new DataBaseStructure();
					}
				}
				return _instance;
			}
		}

		protected DataBaseStructure()
		{
			_ds = new DataSet();
			BuildStructure();
		}

		internal DataSet Ds
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
			_dtApplication.Columns.Add("SmallIcon", typeof(Byte[]));
			_dtApplication.Columns.Add("LargeIcon", typeof(Byte[]));
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
			_ds.WriteXml(fileName, XmlWriteMode.WriteSchema);
		}

		public void LoadDataBase(string fileName)
		{
			try
			{
				_ds.ReadXml(fileName);
			}
			catch (FileNotFoundException)
			{
				//	BuildStructure();
			}
			catch (Exception e)
			{
				ErrorManager.Instance.RiseError("DAL", e.Message);
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
			var ic = new IconConverter();
			var newLine = _ds.Tables["Application"].NewRow();
			newLine["ApplicationName"] = applicationName;
			newLine["SmallIcon"] = ic.ConvertTo(smallIcon, typeof (byte[]));
			newLine["LargeIcon"] = ic.ConvertTo(largeIcon, typeof (byte[]));
			try
			{
				_ds.Tables["Application"].Rows.Add(newLine);
				InvokeNewapp(new NewapphandlerArgs(new TsApplication(applicationName, smallIcon, largeIcon)));
			}
			catch (Exception e)
			{
				ErrorManager.Instance.RiseError("DAL", e.Message);
			}
		}

		public DataTableReader GetApplications()
		{
			return _ds.Tables["Application"].CreateDataReader();
		}

		public void NewSettingsRule(int taskId, int applicationId)
		{
			var newLine = _dtTaskApplication.NewRow();
			newLine["TaskId"] = taskId;
			newLine["ApplicationId"] = applicationId;
			_dtTaskApplication.Rows.Add(newLine);
		}

		public bool IsApplicationExist(string applicationName)
		{
			return _ds.Tables["Application"].Rows.Find(applicationName) != null;
		}

		public void Initialize(string demoTxt)
		{
			LoadDataBase(demoTxt);
		}
	}

	public delegate void Newapphandler(object sender, NewapphandlerArgs args);

	public class NewapphandlerArgs
	{
		public TsApplication App { get; private set; }

		public NewapphandlerArgs(TsApplication app)
		{
			App = app;
		}
	}
}
