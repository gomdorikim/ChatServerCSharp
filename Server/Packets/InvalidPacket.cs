using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Packets;

namespace Client.Packets
{
    public class InvalidPacket : Packet
    {
        private byte ByteID { get; set; }
        public InvalidPacket(byte id)
        {
            ByteID = id;
        }
        public override byte id
        {
            get { return ByteID; }
        }
        public override Packet Make()
        {
            return this;
        }
        public override void Receive(Server.Client sender, System.IO.Stream data)
        {
            
        }
    }
}
