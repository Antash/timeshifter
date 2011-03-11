using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        // Code here=)
        //  ))) А по русски можно?
        // Теперь ты понял, почему нельзя?)
        // fucking russian!  ))) oh eee
        // а что переключаться лень? )ну тут скорее просто хороший тон - не использовать ничего кроме англ. 
        // у меня сейчас проект - так там комменты на немецком - не очень приятно.
        //хм.. ну для обучения думаю можно )это до=а
        //п а что это за модуль? модуль формы?
        //да. по сути ты можешь пока тут писать все что угодно, но лучше создать новый файтик и писать в нем.ю

        // покеж

        string keyName = "Time Shifter";
        string assemblyLocation = Assembly.GetExecutingAssembly().Location;  // Or the EXE path.

        public Form1()
        {
            InitializeComponent();
            // оч просто  эттыо ф10 ф11 ф5
            // понятно, внутрь через и дальше
            //ща иконку достану
            // а вот это что за модуль?
            TestClass tmp = new TestClass("dsf");
            this.Text = tmp.s;

            if (AvtoStart.IsAutoStartEnabled(keyName, assemblyLocation))
                this.button1.Text = "Отключить старт при запуске системы";
            else this.button1.Text = "Включить старт при запуске системы";

        }

        private void button1_Click(object sender, EventArgs e)
        {            // Set Auto-start.

            // Unset Auto-start.
            if (AvtoStart.IsAutoStartEnabled(keyName, assemblyLocation))
            {
                AvtoStart.UnSetAutoStart(keyName);
                this.button1.Text = "Включить старт при запуске системы";
            }
            else
            {
                AvtoStart.SetAutoStart(keyName, assemblyLocation);
                this.button1.Text = "Отключить старт при запуске системы";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //это событие загрузки формы
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        //короче такой вот щит
        // хрена се лего
    }
}
