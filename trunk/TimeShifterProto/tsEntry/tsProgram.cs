using System;
using System.Windows.Forms;
using tsCore.Classes;
using tsUI.Forms;

namespace tsEntry
{
	static class TsProgram
	{
		[STAThread]
		static void Main(string[] args)
		{
			TsAppCore.Instance.Enable();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (args.Length > 0)
				
			Application.Run(new WinFormsApplicationContext());
		}
	}

	class WpfApplicationContext : ApplicationContext
	{
		public WpfApplicationContext()
		{
			//TODO : add Wpf UI handling
		}
	}

	class WinFormsApplicationContext : ApplicationContext
	{
		private readonly FrmTray _mainForm;

		public WinFormsApplicationContext()
		{
			_mainForm = new FrmTray();
			_mainForm.FormClosed += MainFormFormClosed;
			_mainForm.Show();
		}

		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			ExitThread();
		}
	}
}
