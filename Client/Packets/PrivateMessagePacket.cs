using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Client.Packets
{
    public class PrivateMessagePacket : Packet
    {
        private string message { get; set; }
        private int user { get; set; }
        public PrivateMessagePacket(string message, int intendeduserid)
        {
            this.message = message;
            this.user = intendeduserid;
            Payload = new byte[9 + message.Length];
        }
        public override byte id
        {
            get { return 18; }
        }
        public override Packet Make()
        {
            AddPayLoad(18);
            AddPayLoad(WriteInt(user));
            AddPayLoad(WriteInt(message.Length));
            AddPayLoad(WriteString(message));
            return this;
        }
        public override void Receive(System.IO.Stream data)
        {
            int user = ReadInt(data);
            int length = ReadInt(data);
            string message = ReadString(data, length);
            //Call GUI
        }
    }
}
