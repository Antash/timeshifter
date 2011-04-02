using System;
using System.Windows.Forms;
using tsUI.Forms;

namespace tsEntry
{
	static class TsProgram
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmTray());
		}
	}
}
