using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeAreDevs_API;

namespace Leaf_Client
{
    public partial class Main : Form
    {
        ExploitAPI module = new ExploitAPI();
        public Main()
        {
            InitializeComponent();
        }
        Point lastPoint;

        private void button1_Click(object sender, EventArgs e)
        {
            fadeout.Start();
        }

        private void fadeout_Tick(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                this.Close();
            }
            Opacity -= .1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkinjected.Start();

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;

            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;

            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;

            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;

            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;

            if (Opacity == 1)
            {
                Opacity = 0;
            }

            fadein.Start();
        }

        private void fadein_Tick(object sender, EventArgs e)
        {
            if (Opacity == 1)
            {
                fadein.Stop();
            }
            Opacity += .1;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            module.LaunchExploit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Clear();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(fastColoredTextBox1.Text);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                fastColoredTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            module.SendLuaScript(fastColoredTextBox1.Text);
        }

        private void checkinjected_Tick(object sender, EventArgs e)
        {
            if (module.isAPIAttached())
            {
                label2.Text = "Injected.";

            }
            else
            {
                label2.Text = "Not Injected.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process[] roblox = Process.GetProcesses();

            foreach (Process openedroblox in roblox)

            {

                bool flag = openedroblox.ProcessName == "RobloxPlayerBeta";

                if (flag)

                {

                    openedroblox.Kill();

                }

            }
        }
    }
}
