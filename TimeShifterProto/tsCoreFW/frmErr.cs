using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tsCoreFW
{
	public partial class FrmErr : Form
	{
		public FrmErr()
		{
			InitializeComponent();
		}

		private void btnok_Click(object sender, EventArgs e)
		{
			Close();
		}

		public void Init(string errMsg)
		{
			errbox.Text = errMsg;
		}

		public void Init(string errModule, string errMsg)
		{
			lModule.Text = errModule;
			errbox.Text = errMsg;
		}
	}
}
