using System.Windows.Forms;

namespace tsUI.Forms
{
	public partial class FrmTray : Form
	{
		public FrmTray()
		{
			InitializeComponent();
		}

		private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void settingsToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			if (FrmSettings.Instance.Visible != true)
			{
				FrmSettings.Instance.Show();
			}
			else
			{
				FrmSettings.Instance.BringToFront();
			}
		}
	}
}
