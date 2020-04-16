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

namespace TCPClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpClient client;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            fieldStatus.Invoke((MethodInvoker)delegate ()
            {
                fieldStatus.Text += e.MessageString;
            });
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            btnConnect.Enabled = false;
            client.Connect(fieldIP.Text, Convert.ToInt32(fieldPort.Text));
            fieldStatus.Text += "Connected";
           
            



        }

        private void btnSend_Click(object sender, EventArgs e)
        {
           
            client.WriteLineAndGetReply(fieldTxt.Text, TimeSpan.FromSeconds(2));
            
            
        }
    }
}
