﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using tscore;
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

        private Dictionary<Keys, int> keylog = new Dictionary<Keys, int>();

        public class mouselog
        {
            public long delta;
            public double path;
            public Dictionary<MouseButtons, int> mouseclicks = new Dictionary<MouseButtons, int>();
        }

        private mouselog mlog = new mouselog();
        WinApiWrapper w = new WinApiWrapper();
    	private UserActivityHook uah = new UserActivityHook();
        public Form1()
        {
            InitializeComponent();
            //initHooks();
			uah.Start();
			uah.OnMouseActivity += new MouseEventHandler(uah_OnMouseActivity);
			uah.KeyPress += new KeyPressEventHandler(uah_KeyPress);
            w.actWintaoTextChanged += new actWindowTextChangedHandler(w_actWintaoTextChanged);
            uah.KeyDown += new KeyEventHandler(uah_KeyDown);
            w.actPidChanged += new actPidChangedHandler(w_actPidChanged);
            w.actPNameChanged += new actPNameChangedHandler(w_actPNameChanged);
            Text = Class1.p;
            timer1.Start();
        }

        void uah_KeyDown(object sender, KeyEventArgs e)
        {
            Keys code = e.KeyCode;
            if (!keylog.ContainsKey(code))
                keylog.Add(code, 0);
            keylog[code]++;
        }

		void uah_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (lKeys.Text.Length > 10)
			{
				lKeys.Text = "";
			}
			lKeys.Text += e.KeyChar;
		}

        private Point oldlock;
        private bool f = false;
		void uah_OnMouseActivity(object sender, MouseEventArgs e)
		{
			lPos.Text = e.Location.ToString();
			lBnt.Text = e.Button.ToString();
            MouseButtons code = e.Button;
            
            if (!mlog.mouseclicks.ContainsKey(code))
                mlog.mouseclicks.Add(code, 0);
            mlog.mouseclicks[code] += e.Clicks;
		    mlog.delta += Math.Abs(e.Delta);
            
            if (f == false)
            {
                f = true;
                oldlock = new Point(e.X, e.Y);
            }
		    mlog.path += Math.Sqrt((e.Y - oldlock.Y)*(e.Y - oldlock.Y) + (e.X - oldlock.X)*(e.X - oldlock.X));
		    oldlock.X = e.X;
		    oldlock.Y = e.Y;
		}

        void w_actPNameChanged(object sender, actPNameChangedHandlerArgs args)
        {
            chText(label3, args.newText);
        }

        void w_actPidChanged(object sender, actPidChangedArgs args)
        {
            chText(label1, args.newPID.ToString());
           chText( richTextBox1, WinApiWrapper.getChild());            
        }

        void w_actWintaoTextChanged(object sender, actWindowTextChangedHandlerArgs args)
        {
            chText(label4, args.newText);
        }

        private delegate void stringDelegate(Control l, string s);

        private void chText(Control l, string text)
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
            listView1.Items.Clear();
            foreach (Keys k in keylog.Keys)
            {
                listView1.Items.Add(k + " - " + keylog[k]);
            }
            listView2.Items.Clear();
            listView2.Items.Add("delta: " + mlog.delta);
            listView2.Items.Add("path: " + mlog.path);
            foreach (MouseButtons k in mlog.mouseclicks.Keys)
            {
                listView2.Items.Add(k + " - " + mlog.mouseclicks[k]);
            }
            //button1.Text = w.invokes.ToString();
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
        	uah.Stop();
        	// rmHooks();
        }

		private void button2_Click(object sender, EventArgs e)
		{
		//	timer1_Tick(null, null);
		}

    }
}
