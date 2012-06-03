using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Server.Packets
{
    public class PingPacket : Packet
    {
        private string pingkey { get; set; }
        public PingPacket(string pingkey)
        {
            this.pingkey = pingkey;
            Payload = new byte[65];
        }
        public override byte id
        {
            get { return 0; }
        }
        public override void Receive(Stream data)
        {
            Network.GetChat("Received a ping");
            byte[] bytes = new byte[64];
            data.Read(bytes, 0, 64);
            Network.SendPacket(new PingPacket(Encoding.ASCII.GetString(bytes)).Make());
        }
        public override Packet Make()
        {
            Network.GetChat("Sent a ping");
            AddPayLoad(0);
            AddPayLoad(WriteString(pingkey));
            return this;
        }
    }
}
