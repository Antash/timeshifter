﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using std;
using wintracer;

namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = WinTracerMain.getWindowPID().ToString();
            unsafe
            {
                label3.Text = charToString(WinTracerMain.getWindowProcName());
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
