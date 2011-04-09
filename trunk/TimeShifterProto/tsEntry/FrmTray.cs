using System.Windows.Forms;
using tsUI.Forms;

namespace tsEntry
{
	public partial class FrmTray : Form
	{
		public FrmTray()
		{
			InitializeComponent();
			niTS.Icon = Properties.Resources.TrayIcon;
			niTS.Visible = true;
		}

		private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void settingsToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			if (FrmSettings.Instance.Visible != true)
				FrmSettings.Instance.Show();
			else
				FrmSettings.Instance.BringToFront();
		}

		private void FrmTray_Load(object sender, System.EventArgs e)
		{
			BeginInvoke(new MethodInvoker(Hide));

		//	new FrmTaskManagement().Show();
		}

		private void taskManagerToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			new FrmTaskManagement().Show();
		}
	}
}
