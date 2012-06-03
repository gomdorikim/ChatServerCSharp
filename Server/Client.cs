using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Server
{
    public class Client
    {
        public string username { get; set; }
        public string ID { get; private set; }
        public IPEndPoint EndPoint { get; private set; }
        public static List<Client> all;
        Socket sck;
        Thread ping;
        public Client(Socket accepted)
        {
            sck = accepted;
            ID = Guid.NewGuid().ToString();
            EndPoint = (IPEndPoint)sck.RemoteEndPoint;
            sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
            username = "";
            UConsole.Log("{0}", this);
            all.Add(this);
        }
        public static void Broadcast(string message)
        {
            if (Client.all.Count != 0)
            foreach (Client c in Client.all)
            {
                c.SendPacket(new Packets.GlobalMessagePacket(message).Make());
            }
        }
        void callback(IAsyncResult ar)
        {
            try
            {
                sck.EndReceive(ar);
                byte[] buf = new byte[16384];
                int rec = sck.Receive(buf, buf.Length, 0);
                if (rec < buf.Length)
                {
                    Array.Resize<byte>(ref buf, rec);
                }
                if (Received != null)
                {
                    Received(this, buf);
                }
                while (sck.Available == 0) { Thread.Sleep(100); }
                sck.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
            }
            catch (System.Exception ex)
            {
                UConsole.Log("Client.cs:80 " + ex.Message);
                UConsole.Log(ex.ToString());
                Close();

                if (Disconnected != null)
                {
                    Disconnected(this);
                }
            }
        }
        public void Close()
        {
            all.Remove(this);
            sck.Close();
            sck.Dispose();
        }
        public void SendPacket(Packets.Packet packet)
        {
            UConsole.Log("Sending packet ID: " + packet.Payload[0]);
            sck.Send(packet.Payload);
        }
        public delegate void ClientReceivedHandler(Client sender, byte[] data);
        public delegate void ClientDisconnectedHandler(Client sender);
        public event ClientReceivedHandler Received;
        public event ClientDisconnectedHandler Disconnected;
    }
    
}
