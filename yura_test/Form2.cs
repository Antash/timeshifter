using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
	public partial class Form2 : Form
	{
		public Form2(DataSet ds)
		{
			InitializeComponent();
			//dataGridView1.DataSource = ds.Tables [0];
			//treeView1.Nodes.
			//treeView1.DataBindings.Add("Nodes", ds, "TaskApplication");
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{

		}
	}
}
