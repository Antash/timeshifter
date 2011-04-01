using System.Windows.Forms;
using tsWin;

namespace tsUI.Forms
{
	public partial class FrmSettings : Form
	{
		private static FrmSettings _instanse;

	    private readonly string _assemblyLocation = System.Environment.CommandLine;

		private FrmSettings()
		{
			InitializeComponent();
		}

		public static FrmSettings Instance
		{
			get { return _instanse ?? (_instanse = new FrmSettings()); }
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (AutoStart.IsAutoStartEnabled(_assemblyLocation))
			{
				AutoStart.UnSetAutoStart();
				bAutostart.Text = "Включить старт при запуске системы";
			}
			else
			{
				AutoStart.SetAutoStart(_assemblyLocation);
				bAutostart.Text = "Отключить старт при запуске системы";
			}
		}

        private void FrmSettings_Load(object sender, System.EventArgs e)
        {
            bAutostart.Text = "Включить старт при запуске системы";
        }
	}
}
