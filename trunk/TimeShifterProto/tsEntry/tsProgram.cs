using System;
using System.Reflection;
using System.Windows.Forms;
using tsUI;
using tsUI.Forms;

namespace tsEntry
{
	static class TsProgram
	{
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmTray());
		}
	}
}
