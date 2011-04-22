namespace tsUI.Forms
{
	partial class FrmTaskManagement
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.lvApplications = new System.Windows.Forms.ListView();
			this.cmsAppList = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
			this.toSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
			this.ilAppLarge = new System.Windows.Forms.ImageList(this.components);
			this.ilAppSmall = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.cmsAppList.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.treeView1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.lvApplications, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(591, 379);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(298, 2);
			this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(290, 27);
			this.panel2.TabIndex = 3;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(3, 33);
			this.treeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(289, 344);
			this.treeView1.TabIndex = 0;
			this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
			// 
			// lvApplications
			// 
			this.lvApplications.CheckBoxes = true;
			this.lvApplications.ContextMenuStrip = this.cmsAppList;
			this.lvApplications.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvApplications.LargeImageList = this.ilAppLarge;
			this.lvApplications.Location = new System.Drawing.Point(298, 33);
			this.lvApplications.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lvApplications.Name = "lvApplications";
			this.lvApplications.Size = new System.Drawing.Size(290, 344);
			this.lvApplications.SmallImageList = this.ilAppSmall;
			this.lvApplications.TabIndex = 1;
			this.lvApplications.UseCompatibleStateImageBehavior = false;
			this.lvApplications.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvApplications_ItemChecked);
			this.lvApplications.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvApplications_ItemDrag);
			this.lvApplications.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvApplications_DragDrop);
			this.lvApplications.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
			// 
			// cmsAppList
			// 
			this.cmsAppList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toLargeIcons,
            this.toSmallIcons});
			this.cmsAppList.Name = "cmsAppList";
			this.cmsAppList.Size = new System.Drawing.Size(164, 52);
			// 
			// toLargeIcons
			// 
			this.toLargeIcons.Name = "toLargeIcons";
			this.toLargeIcons.Size = new System.Drawing.Size(163, 24);
			this.toLargeIcons.Text = "toLargeIcons";
			this.toLargeIcons.Click += new System.EventHandler(this.toLargeIcons_Click);
			// 
			// toSmallIcons
			// 
			this.toSmallIcons.Name = "toSmallIcons";
			this.toSmallIcons.Size = new System.Drawing.Size(163, 24);
			this.toSmallIcons.Text = "toSmallIcons";
			this.toSmallIcons.Click += new System.EventHandler(this.toSmallIcons_Click);
			// 
			// ilAppLarge
			// 
			this.ilAppLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ilAppLarge.ImageSize = new System.Drawing.Size(48, 48);
			this.ilAppLarge.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// ilAppSmall
			// 
			this.ilAppSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.ilAppSmall.ImageSize = new System.Drawing.Size(24, 24);
			this.ilAppSmall.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 2);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(289, 27);
			this.panel1.TabIndex = 2;
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Margin = new System.Windows.Forms.Padding(4);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(289, 26);
			this.textBox1.TabIndex = 0;
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			// 
			// FrmTaskManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(591, 379);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "FrmTaskManagement";
			this.Text = "TaskManagement";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTaskManagement_FormClosed);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.cmsAppList.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ListView lvApplications;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ImageList ilAppSmall;
		private System.Windows.Forms.ImageList ilAppLarge;
		private System.Windows.Forms.ContextMenuStrip cmsAppList;
		private System.Windows.Forms.ToolStripMenuItem toLargeIcons;
		private System.Windows.Forms.ToolStripMenuItem toSmallIcons;
		private System.Windows.Forms.TextBox textBox1;
	}
}