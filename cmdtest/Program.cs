using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using test;
using WpfTest;
using Application = System.Windows.Forms.Application;

namespace cmdtest
{
	static class Program
	{
		[STAThread]
		static void Main()//string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new Form1());
			Window w = new MainWindow();
			//w.Show();
			Application.Run(new WPFApplicationContext());
		}
	}
	public class WPFApplicationContext : ApplicationContext
	{
		public WPFApplicationContext()
		{
			Window w = new MainWindow();
			w.Show();
			w.Closed += new EventHandler(w_Closed);
			/*делаем что хотим*/
		}

		void w_Closed(object sender, EventArgs e)
		{
			this.ExitThread();
			//throw new NotImplementedException();
		}
	}
}
