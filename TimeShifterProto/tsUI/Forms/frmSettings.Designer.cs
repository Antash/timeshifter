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
			this.bAutostart = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// bAutostart
			// 
			this.bAutostart.Location = new System.Drawing.Point(12, 12);
			this.bAutostart.Name = "bAutostart";
			this.bAutostart.Size = new System.Drawing.Size(130, 62);
			this.bAutostart.TabIndex = 0;
			this.bAutostart.Text = "bAutostart";
			this.bAutostart.UseVisualStyleBackColor = true;
			this.bAutostart.Click += new System.EventHandler(this.button1_Click);
			// 
			// FrmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(301, 103);
			this.Controls.Add(this.bAutostart);
			this.Name = "FrmSettings";
			this.Text = "frmSettings";
			this.Load += new System.EventHandler(this.FrmSettings_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button bAutostart;
	}
}