using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Server.Packets;

namespace Server
{
    class Program
    {
        static Listener l;
        static void Main(string[] args)
        {
            Server.Motd = UConsole.GetString("MOTD ?");
            int port = UConsole.GetInt("What port should the sever listen to?");

            l = new Listener(port);
            l.SocketAccepted += new Listener.SocketAcceptedHandler(l_SocketAccepted);
            l.Start();
           Console.Read();
        }
        static void l_SocketAccepted(Socket e)
        {
            UConsole.Log("New connection: {0}", e.RemoteEndPoint);
            Client client = new Client(e);
            client.Received += new Client.ClientReceivedHandler(client_Received);
            client.Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);
        }
        static void client_Disconnected(Client sender)
        {
            UConsole.Log(sender.username + " disconnected");
            foreach (Client c in Client.all) { c.SendPacket(new Packets.GlobalMessagePacket(sender.username + " disconnected").Make()); }
        }
        static void client_Received(Client sender, byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            while (stream.Length > 0)
            {
                byte b = (byte)stream.ReadByte();
                UConsole.Log("Received packet ID: " + b);
                //Packet.GetPacketByID((byte)stream.ReadByte()).Receive(sender, stream);
                Packet.GetPacketByID(b).Receive(sender, stream);
            }
        }
    }
}
