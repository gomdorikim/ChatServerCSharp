using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Server.Packets
{
    public class ChatMessagePacket : Packet
    {
        private bool notify { get; set; }
        private string message { get; set; }
        public ChatMessagePacket(string message, bool notify)
        {
            this.message = message;
            Payload = new byte[9 + message.Length];
        }
        public override byte id
        {
            get { return 17; }
        }
        public override Packet Make()
        {
            AddPayLoad(17);
            AddPayLoad(WriteInt(message.Length));
            AddPayLoad(WriteString(message));
            AddPayLoad(WriteInt(notify ? 1 : 0));
            return this;
        }
        public override void Receive(System.IO.Stream data)
        {
            int length = ReadInt(data);
            string message = ReadString(data, length);
            bool not = ReadInt(data) == 1 ? true : false;
            Network.GetChat(message);
        }
    }
}
