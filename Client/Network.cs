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
        public static bool firstping = true;
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

            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Connect(ip, port);
            sck.BeginAccept(callback, null);
            ReceivedData += new ReceivedDataHandler(PacketSender);
            //while (!sck.Connected) { Thread.Sleep(250); }
            SendPacket(new LoginPacket()).Make());
        }
        static void PacketSender(byte[] data)
        {

        }
        public static Packet GetPacketByID(PacketID packetid)
        {
            return (Packet)Activator.CreateInstance((Packets.Packets[(byte)packetid]));
        }

        public static Packet GetPacketByID(byte packetid)
        {
            return (Packet)Activator.CreateInstance((Packets.Packets[(byte)packetid]));
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
