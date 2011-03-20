using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
        Logic l = new Logic ();
        public Form1()
        {
            DataSet ds = new DataSet ();
            DataTable dt = new DataTable("tasks");
            dt.Columns.Add("fgf");
            DataRow dr = dt.NewRow();
            dr[0] = "dfgdg";
            dt.Rows.Add(dr);
            //dt.Columns["fgf"].Unique
            ds.Tables.Add(dt);
            //ds.Relations.Add(
            ds.WriteXmlSchema("sch.txt");
            ds.WriteXml("out.txt", XmlWriteMode.IgnoreSchema);
            ds.ReadXmlSchema("sch.txt");
            InitializeComponent();
            //ds.
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

        private void button2_Click(object sender, EventArgs e)
        {
            using (Stream stream = File.Open("data.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, l.log);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Stream stream = File.Open("data.bin", FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();

                var tmp = (List<LogStructure >)bin.Deserialize(stream);
                l.log = tmp;
                //foreach (LogStructure i in tmp)
                //{
                //    Console.WriteLine("{0}, {1}, {2}",
                //        lizard.Type,
                //        lizard.Number,
                //        lizard.Healthy);
                //}
            }

        }
        //короче такой вот щит
        // хрена се лего
    }
}
