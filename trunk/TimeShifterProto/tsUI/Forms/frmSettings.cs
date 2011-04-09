using System;
using System.Windows.Forms;
using tsPresenter;
using tsPresenter.Settings;

namespace tsUI.Forms
{
	public partial class FrmSettings : Form, ISettingsView
	{
		private static FrmSettings _instanse;

		protected FrmSettings()
		{
			InitializeComponent();
		}

		public static FrmSettings Instance
		{
			get { return _instanse ?? (_instanse = new FrmSettings()); }
		}

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            checkBoxAutostart.Text = "Старт при запуске системы";
        	checkBoxEnRoutine.Text = "Вкл/Выкл";
        }

		#region Implementation of ISettingsView

		public bool IsAutostartEnabled
		{
			get { return checkBoxAutostart.Checked; }
			set { checkBoxAutostart.Checked = value; }
		}

		public bool IsCoreRunning
		{
			get { return checkBoxEnRoutine.Checked; }
			set { checkBoxEnRoutine.Checked = value; }
		}

		public event EventHandler DataChanged;

		public void InvokeDataChanged(EventArgs e)
		{
			EventHandler handler = DataChanged;
			if (handler != null) handler(this, e);
		}

		#endregion

		private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		private void checkBoxAutostart_CheckedChanged(object sender, EventArgs e)
		{
			InvokeDataChanged(new EventArgs());
		}

		private void checkBoxEnRoutine_CheckedChanged(object sender, EventArgs e)
		{
			InvokeDataChanged(new EventArgs());
		}
	}
}
