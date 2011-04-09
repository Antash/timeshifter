﻿namespace tsUI.Forms
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
			this.button1 = new System.Windows.Forms.Button();
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
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(591, 379);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(298, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(290, 33);
			this.panel2.TabIndex = 3;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Location = new System.Drawing.Point(3, 42);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(289, 334);
			this.treeView1.TabIndex = 0;
			// 
			// lvApplications
			// 
			this.lvApplications.ContextMenuStrip = this.cmsAppList;
			this.lvApplications.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvApplications.LargeImageList = this.ilAppLarge;
			this.lvApplications.Location = new System.Drawing.Point(298, 42);
			this.lvApplications.Name = "lvApplications";
			this.lvApplications.Size = new System.Drawing.Size(290, 334);
			this.lvApplications.SmallImageList = this.ilAppSmall;
			this.lvApplications.TabIndex = 1;
			this.lvApplications.UseCompatibleStateImageBehavior = false;
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
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(289, 33);
			this.panel1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(78, 33);
			this.button1.TabIndex = 1;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// FrmTaskManagement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(591, 379);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "FrmTaskManagement";
			this.Text = "TaskManagement";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTaskManagement_FormClosed);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.cmsAppList.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ListView lvApplications;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ImageList ilAppSmall;
		private System.Windows.Forms.ImageList ilAppLarge;
		private System.Windows.Forms.ContextMenuStrip cmsAppList;
		private System.Windows.Forms.ToolStripMenuItem toLargeIcons;
		private System.Windows.Forms.ToolStripMenuItem toSmallIcons;
	}
}