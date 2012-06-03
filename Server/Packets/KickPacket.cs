using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Packets
{
    public class KickPacket : Packet
    {
        private string reason { get; set; }
        public KickPacket()
        {
            reason = "-";
            Payload = new byte[6];
        }
        public KickPacket(string reason)
        {
            this.reason = reason;
            Payload = new byte[5 + reason.Length];
        }
        public override byte id
        {
            get { return 255; }
        }
        public override void Receive(Client sender, Stream data)
        {
            sender.Close();
        }
        public override Packet Make()
        {
            AddPayLoad(255);
            AddPayLoad(WriteInt(reason.Length));
            AddPayLoad(WriteString(reason));
            return this;
        }
    }
}
