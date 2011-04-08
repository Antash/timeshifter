﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tsCore;
using tsCore.Classes;

namespace tsPresenter
{
	public class TaskManagementModel : ITaskManagementModel
	{
		private List<ListViewItem> _applications;
		private List<Image> _appIconSmall;
		private List<Image> _appIconLarge;
		public event newapp rebing;

		public void InvokeRebing(EventArgs args)
		{
			newapp handler = rebing;
			if (handler != null) handler(this, args);
		}

		int i = 0;
		public TaskManagementModel()
		{
			_applications = new List<ListViewItem>();
			_appIconSmall = new List<Image>();
			_appIconLarge = new List<Image>();

			ImageConverter ic = new ImageConverter();

			DataTableReader dr = TsAppCore.Instance.TaskDbs.GetApplications();
			
			while (dr.Read())
			{
				MemoryStream ms = new MemoryStream((byte[]) dr.GetValue(1));
				MemoryStream ms2 = new MemoryStream((byte[])dr.GetValue(2));
				if (ms.Capacity > 0)
				{
					_appIconLarge.Add(Image.FromStream(ms2));
					_appIconSmall.Add(Image.FromStream(ms));
					i++;
				}
				_applications.Add(new ListViewItem(dr.GetValue(0).ToString(), i-1));
			}
			dr.Close();
			TsAppCore.Instance.newApp += new AppAdd(Instance_newApp);
		}

		void Instance_newApp(object sender, AppAddArgs args)
		{
			if (args.Image != null)
			{
				_appIconLarge.Add(args.Image.ToBitmap());
				_appIconSmall.Add(args.Image.ToBitmap());
			}
			else
			{
				_appIconLarge.Add(_appIconLarge[i - 1]);
				_appIconSmall.Add(_appIconSmall[i - 1]);
			}
			i++;
			_applications.Add(new ListViewItem(args.Name, i - 1));
			InvokeRebing(new EventArgs());
		}

		public List<ListViewItem> Applications
		{
			get { return _applications; }
		}

		public List<Image> AppIconsSmall
		{
			get { return _appIconSmall; }
		}

		public List<Image> AppIconsLarge
		{
			get { return _appIconLarge; }
		}
	}

	public delegate void newapp(object sender, EventArgs args);
}
