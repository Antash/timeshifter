﻿namespace test
{
	sealed partial class Form1
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lBnt = new System.Windows.Forms.Label();
			this.lPos = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lKeys = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(140, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "press Start";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(223, 9);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 35);
			this.button1.TabIndex = 1;
			this.button1.Text = "Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Current active PID:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "curr proc name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 59);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(157, 17);
			this.label4.TabIndex = 4;
			this.label4.Text = "curr window header text";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(304, 9);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 35);
			this.button2.TabIndex = 7;
			this.button2.Text = "once";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(11, 79);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(206, 345);
			this.richTextBox1.TabIndex = 8;
			this.richTextBox1.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lBnt);
			this.groupBox1.Controls.Add(this.lPos);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(223, 59);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(156, 77);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "mouse activity";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(57, 17);
			this.label5.TabIndex = 0;
			this.label5.Text = "position";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 49);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 17);
			this.label6.TabIndex = 1;
			this.label6.Text = "button";
			// 
			// lBnt
			// 
			this.lBnt.AutoSize = true;
			this.lBnt.Location = new System.Drawing.Point(69, 49);
			this.lBnt.Name = "lBnt";
			this.lBnt.Size = new System.Drawing.Size(32, 17);
			this.lBnt.TabIndex = 3;
			this.lBnt.Text = "lBtn";
			// 
			// lPos
			// 
			this.lPos.AutoSize = true;
			this.lPos.Location = new System.Drawing.Point(69, 20);
			this.lPos.Name = "lPos";
			this.lPos.Size = new System.Drawing.Size(35, 17);
			this.lPos.TabIndex = 2;
			this.lPos.Text = "lPos";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.lKeys);
			this.groupBox2.Location = new System.Drawing.Point(223, 142);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(156, 77);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "keyboard activity";
			// 
			// lKeys
			// 
			this.lKeys.AutoSize = true;
			this.lKeys.Location = new System.Drawing.Point(6, 28);
			this.lKeys.Name = "lKeys";
			this.lKeys.Size = new System.Drawing.Size(42, 17);
			this.lKeys.TabIndex = 4;
			this.lKeys.Text = "lKeys";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(388, 436);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lBnt;
		private System.Windows.Forms.Label lPos;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lKeys;
	}
}

