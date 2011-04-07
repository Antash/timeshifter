using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tsPresenter;

namespace tsUI.Forms
{
	public partial class FrmTaskManagement : Form, ITaskManagementView
	{
		private TaskManagementPresenter _presenter;
		private bool _suppressEvents;

		public FrmTaskManagement()
		{
			InitializeComponent();
		}

		private void FrmTaskManagement_Load(object sender, EventArgs e)
		{
			_presenter = new TaskManagementPresenter(this, new TaskManagementModel());
			_suppressEvents = true;
			_presenter.Initialize();
			_suppressEvents = false;
		}

		public List<ListViewItem> Applications
		{
			set
			{
				foreach (ListViewItem item in value)
					lvApplications.Items.Add(item);
			}
		}

		public List<Image> AppIconsSmall
		{
			set
			{
				foreach (Image item in value)
					ilAppSmall.Images.Add(item);
			}
		}

		public List<Image> AppIconsLarge
		{
			set
			{
				foreach (Image item in value)
				{
					ilAppLarge.Images.Add(item);
					Bitmap img = new Bitmap( item) ;
					img.Save(item.GetHashCode()+".bmp");
				}
			}
		}
	}
}
