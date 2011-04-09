using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tsCoreStructures;
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
					ilAppSmall.Images.Add(item ?? Properties.Resources.defAppS);
			}
		}

		public List<Image> AppIconsLarge
		{
			set
			{
				foreach (Image item in value)
					ilAppLarge.Images.Add(item ?? Properties.Resources.defAppL);
			}
		}

		private delegate void AddAppDelegate(TsApplication app);

		public void AddNewApplication(TsApplication app)
		{
			if (lvApplications.InvokeRequired)
				lvApplications.Invoke(new AddAppDelegate(AddApp), app);
			else AddApp(app);
		}

		private void AddApp(TsApplication app)
		{
			ilAppLarge.Images.Add(app.LargeIcon != null ? app.LargeIcon.ToBitmap() : Properties.Resources.defAppL);
			ilAppSmall.Images.Add(app.SmallIcon != null ? app.SmallIcon.ToBitmap() : Properties.Resources.defAppS);
			lvApplications.Items.Add(new ListViewItem(app.Name, ilAppSmall.Images.Count - 1));
		}

		private void toLargeIcons_Click(object sender, EventArgs e)
		{
			lvApplications.View = View.LargeIcon;
		}

		private void toSmallIcons_Click(object sender, EventArgs e)
		{
			lvApplications.View = View.SmallIcon;
		}
	}
}
