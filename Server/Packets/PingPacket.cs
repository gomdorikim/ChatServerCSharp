using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Packets
{
    public class PingPacket : Packet
    {
        public PingPacket()
        {
            Payload = new byte[65];
        }
        public override byte id
        {
            get { return 0; }
        }
        public override void Receive(Client sender, Stream data)
        {
            
        }
        public override Packet Make()
        {
            AddPayLoad(0);
            AddPayLoad(Encoding.ASCII.GetBytes(RandomString(64)));
            return this;
        }
    }
}
