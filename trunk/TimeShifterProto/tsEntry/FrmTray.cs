using System.Windows.Forms;
using tsPresenter.Settings;
using tsPresenter.TaskManagement;
using tsPresenter.Reports;
using tsUI.Forms;

namespace tsEntry
{
	public partial class FrmTray : Form
	{
		public FrmTray()
		{
			InitializeComponent();
			Icon = niTS.Icon = Properties.Resources.TrayIcon;
			niTS.Visible = true;

			_tmModel = new TaskManagementModel();
			_sModel = new SettingsModel();
			_repModel = new ReportsModel();
		}

		private readonly ITaskManagementModel _tmModel;
		private readonly ISettingsModel _sModel;
		private readonly IReportsModel _repModel;

		private void CreateTmView()
		{
			ITaskManagementView tmView = new FrmTaskManagement();
			new TaskManagementPresenter(_tmModel, tmView);
			tmView.Show();
		}

		private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void settingsToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			ISettingsView sView = FrmSettings.Instance;
			new SettingsPresenter(_sModel, sView);
			if (sView.Visible != true)
				sView.Show();
			else
				sView.BringToFront();
		}

		private void FrmTray_Load(object sender, System.EventArgs e)
		{
			BeginInvoke(new MethodInvoker(Hide));
		}

		private void taskManagerToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			CreateTmView();
		}

		private void niTS_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			CreateTmView();
		}

		private void reportToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			IReportsView repView = new FrmReport();
			_repModel.Update();
			new ReportsPresenter(_repModel, repView);
			repView.Show();
		}
	}
}
