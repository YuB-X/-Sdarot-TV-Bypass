using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sdarot_TV_Bypass
{
    public partial class Form1 : Form
    {
        private Point lastPoint;

        public Form1()
        {
            InitializeComponent();
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

        private async void timer1_Tick(object sender, EventArgs e)
        {
            // oh hi skid 
            bypass.Stop();
            button2.Text = "Checking If you Not Gay...";
            await Task.Delay(1500);
            button2.Text = "Start Bypass...";
            await Task.Delay(1500);

            string query = "SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            foreach (ManagementObject adapter in searcher.Get())
            {
                string[] dnsServers = { "8.8.4.4" }; // Set the new DNS server here
                ManagementBaseObject dnsSettings = adapter.GetMethodParameters("SetDNSServerSearchOrder");
                dnsSettings["DNSServerSearchOrder"] = dnsServers;
                ManagementBaseObject setDns = adapter.InvokeMethod("SetDNSServerSearchOrder", dnsSettings, null);
            }

            await Task.Delay(1500);
            button2.Text = "Done Bypass";
            await Task.Delay(1500);
            button2.Text = "Open Sdarot.TV";
            await Task.Delay(2500);
            Process.Start("https://sdarot.buzz/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://youtube.com/@YuB-X");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
        }
    }
}
