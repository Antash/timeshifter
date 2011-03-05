using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
		[DllImport("winhook.dll")]
		public static extern int getActWindowPID();

        [DllImport("winhook.dll")]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		public static extern string getActWindowProcName();

        [DllImport("winhook.dll")]
        public static extern void getActWindowCaption(StringBuilder s);

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = getActWindowPID().ToString();
            label3.Text = getActWindowProcName();
            StringBuilder s = new StringBuilder(500);
            getActWindowCaption(s);
            label4.Text = s.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

    }
}
