namespace tsEntry
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTray));
			this.niTS = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStripTsTray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.taskManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStripTsTray.SuspendLayout();
			this.SuspendLayout();
			// 
			// niTS
			// 
			this.niTS.ContextMenuStrip = this.contextMenuStripTsTray;
			this.niTS.Text = "TimeShifter";
			// 
			// contextMenuStripTsTray
			// 
			this.contextMenuStripTsTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskManagerToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.contextMenuStripTsTray.Name = "contextMenuStripTsTray";
			this.contextMenuStripTsTray.Size = new System.Drawing.Size(164, 98);
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
			// FrmTray
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(175, 66);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmTray";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "frmTray";
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
	}
}