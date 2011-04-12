namespace tsCoreFW
{
	partial class FrmErr
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
			this.btnok = new System.Windows.Forms.Button();
			this.errbox = new System.Windows.Forms.RichTextBox();
			this.lModule = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnok
			// 
			this.btnok.Location = new System.Drawing.Point(196, 113);
			this.btnok.Name = "btnok";
			this.btnok.Size = new System.Drawing.Size(75, 29);
			this.btnok.TabIndex = 0;
			this.btnok.Text = "btnok";
			this.btnok.UseVisualStyleBackColor = true;
			this.btnok.Click += new System.EventHandler(this.btnok_Click);
			// 
			// errbox
			// 
			this.errbox.Location = new System.Drawing.Point(12, 33);
			this.errbox.Name = "errbox";
			this.errbox.Size = new System.Drawing.Size(259, 74);
			this.errbox.TabIndex = 1;
			this.errbox.Text = "";
			// 
			// lModule
			// 
			this.lModule.AutoSize = true;
			this.lModule.Location = new System.Drawing.Point(12, 9);
			this.lModule.Name = "lModule";
			this.lModule.Size = new System.Drawing.Size(89, 17);
			this.lModule.TabIndex = 2;
			this.lModule.Text = "Modulename";
			// 
			// FrmErr
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(283, 154);
			this.Controls.Add(this.lModule);
			this.Controls.Add(this.errbox);
			this.Controls.Add(this.btnok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmErr";
			this.Text = "frmErr";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnok;
		private System.Windows.Forms.RichTextBox errbox;
		private System.Windows.Forms.Label lModule;
	}
}