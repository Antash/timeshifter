using System;
using System.Windows.Forms;
using tsCore.Classes;

namespace tsEntry
{
	static class TsProgram
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			TsAppCore.Instance.Enable();

			Application.Run(new FrmTray());
		}
	}
}
