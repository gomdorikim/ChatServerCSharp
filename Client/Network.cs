using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;
using Client.Packets;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public static class Network
    {
        public static TcpClient tcpclient;
        //public static Socket socket;
        public static NetworkStream stream;
        public static ListBox ChatBox;
        public static void Disconnect()
        {
            stream.Dispose();
            stream.Close();
        }
        public static void Connect(string ip, int port, string username, ListBox chatbox)
        {
            ChatBox = chatbox;
            int uid = 0;
            byte[] data = Encoding.ASCII.GetBytes(username);
            foreach (byte b in data) { uid += b; }
            ip.Replace("localhost", "127.0.0.1");
            ip = Dns.GetHostEntry(ip).AddressList[0].ToString().Contains(".") ? Dns.GetHostEntry(ip).AddressList[0].ToString() : Dns.GetHostEntry(ip).AddressList[1].ToString();
            IPAddress ipa = IPAddress.Parse(ip);
            EndPoint ipep = new IPEndPoint(ipa, port);
            tcpclient = new TcpClient(ip, port);
            //stream = new NetworkStream(socket);
            stream = tcpclient.GetStream();

            Thread listen = new Thread(new ThreadStart(Listen));
            listen.Start();

            //while (!sck.Connected) { Thread.Sleep(250); }
            SendPacket(new LoginPacket(uid).Make());
        }
        static void Listen()
        {
            byte[] instream = new byte[8192];
            //int readlength = (int)socket.ReceiveBufferSize;
            int readlength = (int)tcpclient.ReceiveBufferSize;
            stream.Read(instream, 0, readlength);
            Array.Resize<byte>(ref instream, readlength);
            Handle(instream);
        }
        static void Handle(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            Packet.GetPacketByID((byte)stream.ReadByte()).Receive(stream);
        }
        static void PacketSender(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            while (stream.Length > 0)
            {
                byte b = (byte)stream.ReadByte();
                Packet.GetPacketByID(b).Receive(stream);
            }
        }
        public static void SendPacket(Packet packet)
        {
            string s = "";
            foreach (byte b in packet.Payload) { s += b.ToString() + "-"; }
            File.AppendAllText("Log.txt", s + "\r\n\r\n");
            //if (packet == null) { GetChat("null packet...?"); return; }
            stream.Write(packet.Payload, 0, packet.Payload.Length);
        }
        public static void GetChat(string message)
        {
            ChatBox.Invoke((MethodInvoker)delegate
            {
                ChatBox.Items.Add(message);
            });
        }
    }
}
