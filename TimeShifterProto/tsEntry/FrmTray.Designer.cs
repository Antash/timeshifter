﻿namespace tsEntry
{
	partial class FrmTray
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
			this.niTS = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStripTsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.taskManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripTsTray.SuspendLayout();
			this.SuspendLayout();
			// 
			// niTS
			// 
			this.niTS.ContextMenuStrip = this.contextMenuStripTsTray;
			this.niTS.Text = "TimeShifter";
			this.niTS.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niTS_MouseDoubleClick);
			// 
			// contextMenuStripTsTray
			// 
			this.contextMenuStripTsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskManagerToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStripTsTray.Name = "contextMenuStripTsTray";
			this.contextMenuStripTsTray.Size = new System.Drawing.Size(164, 122);
			// 
			// taskManagerToolStripMenuItem
			// 
			this.taskManagerToolStripMenuItem.Name = "taskManagerToolStripMenuItem";
			this.taskManagerToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
			this.taskManagerToolStripMenuItem.Text = "taskManager";
			this.taskManagerToolStripMenuItem.Click += new System.EventHandler(this.taskManagerToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
			this.settingsToolStripMenuItem.Text = "settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
			this.exitToolStripMenuItem.Text = "exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// reportToolStripMenuItem
			// 
			this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
			this.reportToolStripMenuItem.Size = new System.Drawing.Size(163, 24);
			this.reportToolStripMenuItem.Text = "report";
			this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
			// 
			// FrmTray
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(227, 211);
			this.Name = "FrmTray";
			this.Text = "frmTray";
			this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
			this.Load += new System.EventHandler(this.FrmTray_Load);
			this.contextMenuStripTsTray.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon niTS;
		private System.Windows.Forms.ContextMenuStrip contextMenuStripTsTray;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem taskManagerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
	}
}