using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tsUI.Forms
{
	public partial class FrmTaskManagement : Form
	{
		public FrmTaskManagement()
		{
			InitializeComponent();
		}

		private void FrmTaskManagement_Load(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//TsAppCore.Instance.TaskDbs.NewTask(new TaskStructure("task1", "desk1", DateTime.Now));
			//treeView1.Nodes.Add("gfd", "task1");
		}
	}
}
