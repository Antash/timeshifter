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
using wincore;

namespace test
{
    public partial class Form1 : Form
    {
		[DllImport("winhook.dll")]
		public static extern int getActWindowPID();

		[DllImport("winhook.dll")]
		public static extern void getActWindowChildren(StringBuilder s);

        [DllImport("winhook.dll")]
		[return: MarshalAs(UnmanagedType.LPWStr)]
		public static extern string getActWindowProcName();

        [DllImport("winhook.dll")]
        public static extern void getActWindowCaption(StringBuilder s);

        [DllImport("winhook.dll")]
        public static extern void initHooks();

        [DllImport("winhook.dll")]
        public static extern void rmHooks();

        WinApiWrapper w = new WinApiWrapper();

        public Form1()
        {
            InitializeComponent();
            initHooks();
            
            w.actWintaoTextChanged += new actWindowTextChangedHandler(w_actWintaoTextChanged);
            w.actPidChanged += new actPidChangedHandler(w_actPidChanged);
            w.actPNameChanged += new actPNameChangedHandler(w_actPNameChanged);
        }

        void w_actPNameChanged(object sender, actPNameChangedHandlerArgs args)
        {
            chText(label3, args.newText);
        }

        void w_actPidChanged(object sender, actPidChangedArgs args)
        {
            chText(label1, args.newPID.ToString());
        }

        void w_actWintaoTextChanged(object sender, actWindowTextChangedHandlerArgs args)
        {
            chText(label4, args.newText);
        }

        private delegate void stringDelegate(Label l, string s);

        private void chText(Label l, string text)
        {
            if (l.InvokeRequired)
            {
                stringDelegate sd = chText;
                this.Invoke(sd, new object[] { l, text });
                return;
            }

            l.Text = text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Text = w.invokes.ToString();
            //label1.Text = getActWindowPID().ToString();
            //label3.Text = getActWindowProcName();

            //StringBuilder s = new StringBuilder(1000);
            //getActWindowCaption(s);
            //label4.Text = s.ToString();

            //richTextBox1.Clear();
            //richTextBox1.Text = WinApiWrapper.getChild();

            //StringBuilder c = new StringBuilder(1000);
            //getActWindowChildren(c);
            //textBox1.Text = c.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            rmHooks();
        }

		private void button2_Click(object sender, EventArgs e)
		{
		//	timer1_Tick(null, null);
		}

    }
}
