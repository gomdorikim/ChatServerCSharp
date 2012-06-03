using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Packets
{
    public class PrivateMessagePacket : Packet
    {
        private int user { get; set; }
        private string message { get; set; }
        public PrivateMessagePacket(string message, int userfrom)
        {
            this.message = message;
            user = userfrom;
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
        public override void Receive(Client sender, System.IO.Stream data)
        {
            int intendeduser = ReadInt(data);
            int length = ReadInt(data);
            string message = ReadString(data, length);
            foreach (Client c in Client.all)
            {
                if (c.ID == intendeduser)
                {
                    UConsole.Log("<" + sender.username + "->" + c.username + "> " + message);
                    c.SendPacket(new PrivateMessagePacket(message, sender.ID));
                }
            }
        }
    }
}
