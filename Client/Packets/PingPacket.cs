using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Client.Packets
{
    public class PingPacket : Packet
    {
        private string pingkey { get; set; }
        public PingPacket()
        {
            this.pingkey = RandomString(64);
            Payload = new byte[0];
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
            Network.SendPacket(new PingPacket().Make());
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
