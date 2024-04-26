using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoShutdown
{
    public partial class Form1 : Form
    {
        System.Threading.Timer timer;
        bool shutdown = true;

        public Form1()
        {
            InitializeComponent();
        }

        public static void ShutdownWithCmd(int secondsUntilShutdown)
        {
            string command = $"-s -t {secondsUntilShutdown}";
            if(File.Exists("C:\\Windows\\System32\\shutdown.exe"))
                Process.Start("C:\\Windows\\System32\\shutdown.exe", command);
            else if(File.Exists("C:\\Windows\\system32\\shutdown.exe"))
                Process.Start("C:\\Windows\\system32\\shutdown.exe", command);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer = new System.Threading.Timer((object state) => 
            {
                Debug.WriteLine("debug");
                if (shutdown) 
                {
                    Debug.WriteLine("shutdown");
                    ShutdownWithCmd(1);
                }
            }
            ,null,TimeSpan.FromSeconds(60),TimeSpan.FromSeconds(60));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shutdown = true;
            Debug.WriteLine("shutdown");
            ShutdownWithCmd(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shutdown=false;
            Debug.WriteLine("no shutdown");
            timer.Dispose();
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            shutdown = false;
            Debug.WriteLine("no shutdown");
            timer.Dispose();
            Application.Exit();
        }
    }
}
