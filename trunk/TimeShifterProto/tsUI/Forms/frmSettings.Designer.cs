namespace tsUI.Forms
{
	partial class FrmSettings
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
			this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
			this.checkBoxEnRoutine = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// checkBoxAutostart
			// 
			this.checkBoxAutostart.AutoSize = true;
			this.checkBoxAutostart.Location = new System.Drawing.Point(9, 10);
			this.checkBoxAutostart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkBoxAutostart.Name = "checkBoxAutostart";
			this.checkBoxAutostart.Size = new System.Drawing.Size(116, 17);
			this.checkBoxAutostart.TabIndex = 0;
			this.checkBoxAutostart.Text = "checkBoxAutostart";
			this.checkBoxAutostart.UseVisualStyleBackColor = true;
			this.checkBoxAutostart.CheckedChanged += new System.EventHandler(this.checkBoxAutostart_CheckedChanged);
			// 
			// checkBoxEnRoutine
			// 
			this.checkBoxEnRoutine.AutoSize = true;
			this.checkBoxEnRoutine.Location = new System.Drawing.Point(9, 32);
			this.checkBoxEnRoutine.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkBoxEnRoutine.Name = "checkBoxEnRoutine";
			this.checkBoxEnRoutine.Size = new System.Drawing.Size(124, 17);
			this.checkBoxEnRoutine.TabIndex = 1;
			this.checkBoxEnRoutine.Text = "checkBoxEnRoutine";
			this.checkBoxEnRoutine.UseVisualStyleBackColor = true;
			this.checkBoxEnRoutine.CheckedChanged += new System.EventHandler(this.checkBoxEnRoutine_CheckedChanged);
			// 
			// FrmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(226, 84);
			this.Controls.Add(this.checkBoxEnRoutine);
			this.Controls.Add(this.checkBoxAutostart);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FrmSettings";
			this.Text = "frmSettings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSettings_FormClosing);
			this.Load += new System.EventHandler(this.FrmSettings_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBoxAutostart;
		private System.Windows.Forms.CheckBox checkBoxEnRoutine;

	}
}