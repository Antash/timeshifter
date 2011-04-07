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
			this.checkBoxAutostart.Location = new System.Drawing.Point(12, 12);
			this.checkBoxAutostart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxAutostart.Name = "checkBoxAutostart";
			this.checkBoxAutostart.Size = new System.Drawing.Size(147, 21);
			this.checkBoxAutostart.TabIndex = 0;
			this.checkBoxAutostart.Text = "checkBoxAutostart";
			this.checkBoxAutostart.UseVisualStyleBackColor = true;
			// 
			// checkBoxEnRoutine
			// 
			this.checkBoxEnRoutine.AutoSize = true;
			this.checkBoxEnRoutine.Location = new System.Drawing.Point(12, 39);
			this.checkBoxEnRoutine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxEnRoutine.Name = "checkBoxEnRoutine";
			this.checkBoxEnRoutine.Size = new System.Drawing.Size(156, 21);
			this.checkBoxEnRoutine.TabIndex = 1;
			this.checkBoxEnRoutine.Text = "checkBoxEnRoutine";
			this.checkBoxEnRoutine.UseVisualStyleBackColor = true;
			// 
			// FrmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(301, 103);
			this.Controls.Add(this.checkBoxEnRoutine);
			this.Controls.Add(this.checkBoxAutostart);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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