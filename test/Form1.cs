using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
		[DllImport("winhook.dll")]
		public static extern int getActWindowPID();
		[DllImport("winhook.dll", CharSet = CharSet.Ansi, ExactSpelling = true,
		   CallingConvention = CallingConvention.Cdecl,
		    EntryPoint="getActWindowPID")]
		//[return: MarshalAs(UnmanagedType.LPWStr)]
		public static extern IntPtr getActWindowProcName();
		[DllImport("winhook.dll")]
		//[return: MarshalAs(UnmanagedType.LPWStr)]
		public static extern string getActWindowCaption();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = getActWindowPID().ToString();
            unsafe
            {
            	//getActWindowProcName();
            	//label3.Text = charToString(getActWindowProcName());
            	//label4.Text = charToString(getActWindowCaption());
            	label3.Text = Marshal.PtrToStringAnsi(getActWindowProcName());
            	//label4.Text = Marshal.PtrToStringAnsi(getActWindowCaption());

            }
        }

        private unsafe string charToString(char *str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; str[i] != '\0';i++)
                sb.Append(str[i]);
            return sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
