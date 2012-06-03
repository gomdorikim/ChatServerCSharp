using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Server.Packets
{
    public class GlobalMessagePacket : Packet
    {
        public GlobalMessagePacket()
        {

        }
        public override byte id { get { return 16; } }
        public override Packet Make()
        {
            return this;
        }
        public override void Receive(Stream data)
        {
            int l = ReadInt(data);
            Network.GetChat(ReadString(data, l));
        }
    }
}
