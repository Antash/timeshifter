using System.Reflection;
using System.Windows.Forms;
using tsWin;

namespace tsUI.Forms
{
	public partial class FrmSettings : Form
	{
		private static FrmSettings _instanse;

		string assemblyLocation = Assembly.GetExecutingAssembly().Location;

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
			if (AutoStart.IsAutoStartEnabled(assemblyLocation))
			{
				AutoStart.UnSetAutoStart();
				this.button1.Text = "Включить старт при запуске системы";
			}
			else
			{
				AutoStart.SetAutoStart(assemblyLocation);
				this.button1.Text = "Отключить старт при запуске системы";
			}
		}
	}
}
