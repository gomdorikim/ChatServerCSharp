using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Packets
{
    public class GlobalMessagePacket : Packet
    {
        private string message { get; set; }
        private int length { get; set; }
        public GlobalMessagePacket(string message)
        {
            this.message = message;
            this.length = message.Length;
            Payload = new byte[length + 5];
        }
        public override byte id { get { return 16; } }
        public override Packet Make()
        {
            AddPayLoad(16);
            AddPayLoad(BitConverter.GetBytes(length));
            AddPayLoad(Encoding.ASCII.GetBytes(message));
            return this;
        }
        public override void Receive(Client sender, Stream data)
        {
            int i = ReadInt(data);
            ReadString(data, i);
        }
    }
}
