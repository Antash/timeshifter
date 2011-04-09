using System;
using System.Windows.Forms;
using tsPresenter;

namespace tsUI.Forms
{
	public partial class FrmSettings : Form, ISettingsView
	{
		private static FrmSettings _instanse;
		private SettingsPresenter _presenter;
		private bool _suppressEvents;

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
        	_presenter = new SettingsPresenter(this);
        	_suppressEvents = true;
        	_presenter.Initialize();
        	_suppressEvents = false;

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

		#endregion

		private void FrmSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			if (_suppressEvents)
				return;
			_presenter.Save();
			Hide();
		}
	}
}
