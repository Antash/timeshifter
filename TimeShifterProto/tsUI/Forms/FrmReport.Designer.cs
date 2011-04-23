namespace tsUI.Forms
{
	partial class FrmReport
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
			this.gvReport = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.gvReport)).BeginInit();
			this.SuspendLayout();
			// 
			// gvReport
			// 
			this.gvReport.AllowUserToAddRows = false;
			this.gvReport.AllowUserToDeleteRows = false;
			this.gvReport.AllowUserToOrderColumns = true;
			this.gvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.gvReport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gvReport.Location = new System.Drawing.Point(0, 0);
			this.gvReport.Name = "gvReport";
			this.gvReport.ReadOnly = true;
			this.gvReport.RowTemplate.Height = 24;
			this.gvReport.Size = new System.Drawing.Size(515, 357);
			this.gvReport.TabIndex = 0;
			// 
			// FrmReport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(515, 357);
			this.Controls.Add(this.gvReport);
			this.Name = "FrmReport";
			this.Text = "FrmReport";
			((System.ComponentModel.ISupportInitialize)(this.gvReport)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView gvReport;
	}
}