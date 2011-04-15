using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using tsCore.Classes;
using tsCoreStructures;
using tsDAL;

namespace tsPresenter.TaskManagement
{
	public class TaskManagementModel : ITaskManagementModel
	{
		private List<ListViewItem> _applications;
		private List<Image> _appIconSmall;
		private List<Image> _appIconLarge;
		private List<TreeNode> _tasks;
		
		//TODO : needs to be refactored
		readonly int _i;
		public TaskManagementModel()
		{
			_applications = new List<ListViewItem>();
			_appIconSmall = new List<Image>();
			_appIconLarge = new List<Image>();

			

			DataTableReader dr = TsAppCore.Instance.TaskDbs.GetApplications();

			while (dr.Read())
			{
				MemoryStream ms = new MemoryStream((byte[])dr.GetValue(1));
				MemoryStream ms2 = new MemoryStream((byte[])dr.GetValue(2));
				if (ms.Capacity > 0)
				{
					_appIconLarge.Add(Image.FromStream(ms2));
					_appIconSmall.Add(Image.FromStream(ms));
					_i++;
				}
				else
				{
					_appIconLarge.Add(null);
					_appIconSmall.Add(null);
					_i++;
				}
				_applications.Add(new ListViewItem(dr.GetValue(0).ToString(), _i - 1));
			}
			dr.Close();
			DataBaseStructure.Instance.Newapp += DataBaseStructure_Newapp;

			_tasks = new List<TreeNode>();

			DataTableReader dr_task = TsAppCore.Instance.TaskDbs.GetTasks();

			while (dr_task.Read())
			{

				_tasks.Add(new TreeNode(dr_task.GetValue(1).ToString()));
			}
			dr_task.Close();
			//DataBaseStructure.Instance.Newapp += DataBaseStructure_Newapp;

		}

		void DataBaseStructure_Newapp(object sender, NewapphandlerArgs args)
		{
			_applications.Add(new ListViewItem(args.App.Name, _appIconLarge.Count));
			_appIconLarge.Add(args.App.LargeIcon == null ? null : args.App.LargeIcon.ToBitmap());
			_appIconSmall.Add(args.App.SmallIcon == null ? null : args.App.SmallIcon.ToBitmap());
			InvokeNewApplication(new NewApplicationHandlerArgs(args.App));
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

		public event NewApplicationHandler NewApplication;
		public void AddNewTask(TsTask task)
		{
			TsAppCore.Instance.TaskDbs.NewTask(task);
		}

		public void InvokeNewApplication(NewApplicationHandlerArgs args)
		{
			NewApplicationHandler handler = NewApplication;
			if (handler != null) handler(this, args);
		}
	}
}
