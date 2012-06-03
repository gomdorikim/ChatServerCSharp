using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Network.Connect(txtIP.Text, (int)numPort.Value, txtUsername.Text, lstChat);
            //Network.Connect("127.0.0.1", 40000, "Wouto1997");
        }

        public void Network_ReceivedChat(object sender, string message)
        {
            Invoke((MethodInvoker)delegate
            {
                lstChat.Items.Add(message);
            });
        }

        private void btnSendChat_Click(object sender, EventArgs e)
        {
            Network.SendPacket(new Client.Packets.ChatMessagePacket(txtChat.Text, false).Make());
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
