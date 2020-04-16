using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpServer server;



        private void Form1_Load(object sender, EventArgs e)
        {
            server = new SimpleTcpServer();
            server.Delimiter = 0x13;
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;

        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            fieldStatus.Invoke((MethodInvoker)delegate ()
            {
                fieldStatus.Text = e.MessageString;
                e.ReplyLine(string.Format($"Your massage is: {e.MessageString}"));

            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fieldStatus.Text += "Server is running";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(fieldIP.Text);
            server.Start(ip, Convert.ToInt32(fieldPort.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
        }
    }
}
