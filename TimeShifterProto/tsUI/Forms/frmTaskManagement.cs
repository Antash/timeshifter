﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using tsCoreStructures;
using tsCoreStructures.Base;
using tsPresenter.TaskManagement;

namespace tsUI.Forms
{
	public partial class FrmTaskManagement : Form, ITaskManagementView
	{
		private bool _supressChecked;

		public FrmTaskManagement()
		{
			_supressChecked = true;
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
				int inc = 0;
				foreach (TreeNode item in value)
				{
					treeView1.Nodes.Add((TreeNode)item.Clone());
					foreach (TsApplication assignedApp in ((tsCoreStructures.TsTask)(item.Tag)).AssignedApplications)
					{
						treeView1.Nodes[inc].Nodes.Add(assignedApp.Description, assignedApp.Description);
						//lvApplications.Items[assignedApp.Description].Checked = true;
						//Applications.Find(assignedApp)
					}
					inc += 1;
				}
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
		public event TsTask.NewTaskHandler NewTask;
		public event AssociativeBaseStruct.AssociativeHandler NewSettings;

		public void InvokeSave(EventArgs e)
		{
			EventHandler handler = Save;
			if (handler != null) handler(this, e);
		}

		public void InvokeNewTask(TsTask.NewTaskHandlerArgs e)
		{
			TsTask.NewTaskHandler handler = NewTask;
			if (handler != null) handler(this, e);
		}

		private void AddApp(TsApplication app)
		{
			if (lvApplications.Items.Find(app.Id.ToString(), false).Length > 0)
				return;
			ilAppLarge.Images.Add(app.LargeIcon ?? Properties.Resources.defAppL);
			ilAppSmall.Images.Add(app.SmallIcon ?? Properties.Resources.defAppS);
			lvApplications.Items.Add(new ListViewItem(app.Description, ilAppSmall.Images.Count - 1) { Name = app.Id.ToString(), Tag = app });
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
			TreeNode tn = new TreeNode(task.TaskName) { Name = task.TaskName, Tag = task };
			if (!treeView1.Nodes.ContainsKey(task.TaskName))
				treeView1.Nodes.Add(tn);
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (textBox1.Text != String.Empty)
				{
					TsTask _task = new TsTask(textBox1.Text, textBox1.Text, DateTime.Now);
					InvokeNewTask(new TsTask.NewTaskHandlerArgs(_task));
					AddTask(_task);
				}

				textBox1.Text = String.Empty;
			}
		}

		private void treeView1_DragEnter(object sender, DragEventArgs e)
		{

		}

		private void lvApplications_DragDrop(object sender, DragEventArgs e)
		{

		}

		private void lvApplications_ItemDrag(object sender, ItemDragEventArgs e)
		{

		}

		private void lvApplications_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (_supressChecked || !lvApplications.Focused)
				return;
			//NOTE 2 Юра: так красивше.
			//надо еще добавить такую штуку, чтобы чекбоксы появлялись 
			//только при выделении нодов первого уровня в дереве
			//и соответственно галоски в них сами расставлялись в соответсявии с 
			//дочерними нодами

			//и самое главное - сделать обработку всего этого в презентере и модели

			// Обратная связь оказалась не нужна.
			// Все прекрасно работает, так как объекты передаются по ссылкам и все изменения 
			// произошедшие внутри видны сдесь.
			// единственное что, сначала надо, чтобы отработало событие. 
			// А потом работать с актуальным объектом

			if (treeView1.SelectedNode != null && treeView1.SelectedNode.Parent == null)
			{
				InvokeNewSettings(
					new AssociativeBaseStruct.AssociativeHandlerArgs(
						(TsBaseStruct)treeView1.SelectedNode.Tag,
						(TsBaseStruct)e.Item.Tag,
						e.Item.Checked));

				if (e.Item.Checked)
				{
					treeView1.SelectedNode.Nodes.Add(e.Item.Text, e.Item.Text);
				}
				else
				{
					treeView1.SelectedNode.Nodes.RemoveByKey(e.Item.Text);
				}
			}
		}

		public void InvokeNewSettings(AssociativeBaseStruct.AssociativeHandlerArgs e)
		{
			AssociativeBaseStruct.AssociativeHandler handler = NewSettings;
			if (handler != null) handler(this, e);
		}

		private void FrmTaskManagement_Load(object sender, EventArgs e)
		{
			_supressChecked = false;
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Parent == null)
			{
				lvApplications.Visible = true;
				TsTask currentTask = (TsTask)e.Node.Tag;
				_supressChecked = true;

				foreach (ListViewItem appItem in lvApplications.Items)
				{
					TsApplication currentApp = (TsApplication)appItem.Tag;
					if (currentTask.AssignedApplications.Find(a => a.PID == currentApp.PID) == null)
					{ appItem.Checked = false; }
					else
					{ appItem.Checked = true; }
				}

				_supressChecked = false;
			}
			else
			{
				lvApplications.Visible = false;
			}
		}
	}
}
