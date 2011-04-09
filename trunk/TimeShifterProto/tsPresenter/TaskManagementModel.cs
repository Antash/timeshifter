using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tsCore;
using tsCore.Classes;
using tsCoreStructures;
using tsDAL;

namespace tsPresenter
{
	public class TaskManagementModel : ITaskManagementModel
	{
		private List<ListViewItem> _applications;
		private List<Image> _appIconSmall;
		private List<Image> _appIconLarge;

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
				MemoryStream ms = new MemoryStream((byte[])dr.GetValue(1));
				MemoryStream ms2 = new MemoryStream((byte[])dr.GetValue(2));
				if (ms.Capacity > 0)
				{
					_appIconLarge.Add(Image.FromStream(ms2));
					_appIconSmall.Add(Image.FromStream(ms));
					i++;
				}
				else
				{
					_appIconLarge.Add(null);
					_appIconSmall.Add(null);
					i++;
				}
				_applications.Add(new ListViewItem(dr.GetValue(0).ToString(), i - 1));
			}
			dr.Close();
			DataBaseStructure.Instance.Newapp += new Newapphandler(DataBaseStructure_Newapp);
		}

		void DataBaseStructure_Newapp(object sender, NewapphandlerArgs args)
		{
			InvokeNewApplication(new NewApplicationHandlerArgs(new TsApplication(args.App)));
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

		public event NewApplicationHandler NewApplication;

		public void InvokeNewApplication(NewApplicationHandlerArgs args)
		{
			NewApplicationHandler handler = NewApplication;
			if (handler != null) handler(this, args);
		}
	}
}
