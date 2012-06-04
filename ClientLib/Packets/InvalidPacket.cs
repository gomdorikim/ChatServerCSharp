using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Packets
{
    public class InvalidPacket : Packet
    {
        public override byte ID
        {
            get { return 0; }
        }
        public override Packet Receive(System.IO.Stream data)
        {
            throw new NotImplementedException();
        }
        public override Packet Make()
        {
            throw new NotImplementedException();
        }
    }
}
