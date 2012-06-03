using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Sockets;
using Server.Packets;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public static class Network
    {
        static Socket sck;
        public static void Disconnect()
        {
            sck.Disconnect(true);
            sck.Close();
            sck.Dispose();
        }
        public static void Connect(string ip, int port, string username)
        {
            int uid = 0;
            byte[] data = Encoding.ASCII.GetBytes(username);
            foreach (byte b in data) { uid += b; }
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Connect(ip, port);
            ip.Replace("localhost", "127.0.0.1");
            IPAddress ipa = Dns.GetHostEntry(ip).AddressList[0].ToString().Contains(".") ? Dns.GetHostEntry(ip).AddressList[0] : Dns.GetHostEntry(ip).AddressList[1];
            sck.Bind(new IPEndPoint(ipa, port));
            
            sck.Listen(10);
            sck.BeginAccept(callback, null);
            ReceivedData += new ReceivedDataHandler(PacketSender);
            //while (!sck.Connected) { Thread.Sleep(250); }
            SendPacket(new LoginPacket(uid).Make());
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
        static void callback(IAsyncResult ar)
        {
            while (true)
            {
                sck.EndAccept(ar);
                while (sck.Available < 1) { Thread.Sleep(100); }
                byte[] buf = new byte[16384];
                int rec = sck.Receive(buf, buf.Length, 0);
                if (rec < buf.Length)
                {
                    Array.Resize<byte>(ref buf, rec);
                }
                if (ReceivedData != null)
                {
                    ReceivedData(buf);
                }
                sck.BeginAccept(callback, null);
            }
        }
        public static void SendPacket(Packet packet)
        {
            sck.Send(packet.Payload);
        }
        public static void GetChat(string message)
        {
            ReceivedChat(message);
        }
        public delegate void ReceivedChatHandler(string message);
        public delegate void ReceivedDataHandler(byte[] data);
        public static event ReceivedDataHandler ReceivedData;
        public static event ReceivedChatHandler ReceivedChat;
    }
}
