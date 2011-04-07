﻿using System;
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

			Application.Run(new FrmTray());
		}
	}
}