using System.Windows.Forms;
using tsCore;
using tsCore.Classes;

namespace tsUI.Forms
{
	public partial class FrmSettings : Form
	{
		private static FrmSettings _instanse;

		private FrmSettings()
		{
			InitializeComponent();
		}

		public static FrmSettings Instance
		{
			get { return _instanse ?? (_instanse = new FrmSettings()); }
		}

        private void FrmSettings_Load(object sender, System.EventArgs e)
        {
            checkBoxAutostart.Text = "Старт при запуске системы";
        	checkBoxEnRoutine.Text = "Вкл/Выкл";
        }

		private void checkBoxAutostart_CheckedChanged(object sender, System.EventArgs e)
		{
			TsAppCore.Instance.SetAutostart(checkBoxAutostart.Checked);
		}

		private void checkBoxEnRoutine_CheckedChanged(object sender, System.EventArgs e)
		{
			TsAppCore.Instance.Manage(checkBoxEnRoutine.Checked);
		}
	}
}
