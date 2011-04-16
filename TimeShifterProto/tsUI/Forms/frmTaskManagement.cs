using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using tsCoreStructures;
using tsPresenter.TaskManagement;

namespace tsUI.Forms
{
	public partial class FrmTaskManagement : Form, ITaskManagementView
	{
		public FrmTaskManagement()
		{
			InitializeComponent();
		}

		public List<ListViewItem> Applications
		{
			set
			{
				foreach (ListViewItem item in value)
					lvApplications.Items.Add((ListViewItem)item.Clone());
			}
			get
			{
				var res = new List<ListViewItem>();
				res.AddRange(lvApplications.Items.OfType<ListViewItem>());
				return res;
			}
		}

		public List<Image> AppIconsSmall
		{
			set
			{
				foreach (Image item in value)
					ilAppSmall.Images.Add(item ?? Properties.Resources.defAppS);
			}
			get
			{
				var res = new List<Image>();
				res.AddRange(ilAppSmall.Images.OfType<Image>());
				return res;
			}
		}

		public List<Image> AppIconsLarge
		{
			set
			{
				foreach (Image item in value)
					ilAppLarge.Images.Add(item ?? Properties.Resources.defAppL);
			}
			get 
			{
				var res = new List<Image>();
				res.AddRange(ilAppLarge.Images.OfType<Image>());
				return res;
			}
		}

		public List<TreeNode> Tasks
		{
			get
			{
				var res = new List<TreeNode>();
				res.AddRange(treeView1.Nodes.OfType<TreeNode>());
				return res;
			}
			set
			{
				foreach (TreeNode item in value)
					treeView1.Nodes.Add((TreeNode)item.Clone());
			}
		}

		private delegate void AddAppDelegate(TsApplication app);

		public void AddNewApplication(TsApplication app)
		{
			if (lvApplications.InvokeRequired)
				lvApplications.Invoke(new AddAppDelegate(AddApp), app);
			else AddApp(app);
		}

		public event EventHandler Save;
		public event NewTaskHandler NewTask;

		public void InvokeSave(EventArgs e)
		{
			EventHandler handler = Save;
			if (handler != null) handler(this, e);
		}

		public void InvokeNewTask(NewTaskHandlerArgs e)
		{
			NewTaskHandler handler = NewTask;
			if (handler != null) handler(this, e);
		}

		private void AddApp(TsApplication app)
		{
			ilAppLarge.Images.Add(app.LargeIcon ?? Properties.Resources.defAppL);
			ilAppSmall.Images.Add(app.SmallIcon ?? Properties.Resources.defAppS);
			lvApplications.Items.Add(new ListViewItem(app.Description, ilAppSmall.Images.Count - 1) {Tag = app});
		}

		private void toLargeIcons_Click(object sender, EventArgs e)
		{
			lvApplications.View = View.LargeIcon;
		}

		private void toSmallIcons_Click(object sender, EventArgs e)
		{
			lvApplications.View = View.SmallIcon;
		}

		private void FrmTaskManagement_FormClosed(object sender, FormClosedEventArgs e)
		{
			InvokeSave(new EventArgs());
		}

		private void AddTask(TsTask task)
		{
			TreeNode tn = new TreeNode(task.TaskName);
			if (!treeView1.Nodes.ContainsKey(task.TaskName))
				treeView1.Nodes.Add(tn);
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (textBox1.Text != String.Empty)
				{
					TsTask _task = new TsTask(textBox1.Text,textBox1.Text, DateTime.Now);
					AddTask(_task);
					InvokeNewTask(new NewTaskHandlerArgs(_task));
				}
					
				textBox1.Text = String.Empty;
			}
		}

	}
}
