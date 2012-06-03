using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Server.Packets
{
    public class KickPacket : Packet
    {
        public KickPacket()
        {
            Payload = new byte[1];
        }
        public override byte id
        {
            get { return 255; }
        }
        public override void Receive(Stream data)
        {
            int l = ReadInt(data);
            Network.GetChat("- " + ReadString(data, l));
            Network.Disconnect();
        }
        public override Packet Make()
        {
            AddPayLoad(255);
            return this;
        }
    }
}
