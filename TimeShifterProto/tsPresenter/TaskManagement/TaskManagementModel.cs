using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using tsCore.Classes;
using tsCoreStructures;
using tsCoreStructures.Base;

namespace tsPresenter.TaskManagement
{
	public class TaskManagementModel : ITaskManagementModel
	{
		private List<ListViewItem> _applications;
		private List<Image> _appIconSmall;
		private List<Image> _appIconLarge;
		private List<TreeNode> _tasks;
		
		public TaskManagementModel()
		{
			_applications = new List<ListViewItem>();
			_appIconSmall = new List<Image>();
			_appIconLarge = new List<Image>();
			_tasks = new List<TreeNode>();

			foreach (TsApplication app in TsAppCore.Instance.Applications)
			{
				_applications.Add(new ListViewItem(app.Description, _appIconSmall.Count) {Name = app.Description, Tag = app});
				_appIconLarge.Add(app.LargeIcon);
				_appIconSmall.Add(app.LargeIcon);
			}

			TsAppCore.Instance.NewApplication += InstanceNewApplication;

			foreach (TsTask task in TsAppCore.Instance.Tasks)
			{
				_tasks.Add(new TreeNode(task.TaskName) {Tag = task});
			}
		}

		void InstanceNewApplication(object sender, TsApplication.NewApplicationHandlerArgs args)
		{
			_applications.Add(new ListViewItem(args.App.Description, _appIconLarge.Count) { Name = args.App.Description, Tag = args.App });
			_appIconLarge.Add(args.App.LargeIcon);
			_appIconSmall.Add(args.App.SmallIcon);
			InvokeNewApplication(new TsApplication.NewApplicationHandlerArgs(args.App));
		}

		public List<ListViewItem> Applications
		{
			get { return _applications; }
			set { _applications = value; }
		}

		public List<Image> AppIconsSmall
		{
			get { return _appIconSmall; }
			set { _appIconSmall = value; }
		}

		public List<Image> AppIconsLarge
		{
			get { return _appIconLarge; }
			set { _appIconLarge = value; }
		}

		public List<TreeNode> Tasks
		{
			get { return _tasks; }
			set { _tasks = value; }
		}

		public event TsApplication.NewApplicationHandler NewApplication;

		public void AddNewTask(TsTask task)
		{
			TsAppCore.Instance.NewTask(task);
		}

		public void InvokeNewApplication(TsApplication.NewApplicationHandlerArgs args)
		{
			TsApplication.NewApplicationHandler handler = NewApplication;
			if (handler != null) handler(this, args);
		}

		public void AddNewSetting(AssociativeBaseStruct.AssociativeHandlerArgs setting)
		{
			TsAppCore.Instance.ApplicationSettingControl(
				((TsTask)setting.Obj1).Id,
				((TsApplication)setting.Obj2).Id,
				setting.IsCreating);
		}
	}
}
