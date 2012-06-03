using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Packets
{
    public class LoginPacket : Packet
    {
        public LoginPacket()
        {

        }
        public override byte id
        {
            get { return 1; }
        }
        public override void Receive(Client sender, Stream data)
        {
            int UID = ReadInt(data);
            sender.username = "Generic" + UID.ToString();
            ReadString(data, 32); // Auth key.. for later use
        }
        public override Packet Make()
        {
            string users = "";
            foreach (Client c in Client.all)
            {
                users += c;
                users += '§';
            }
            users = users.Remove(users.Length - 1);
            Payload = new byte[9 + users.Length + Server.Motd.Length];
            AddPayLoad(1);
            AddPayLoad(WriteInt(users.Length));
            AddPayLoad(WriteString(users));
            AddPayLoad(WriteInt(Server.Motd.Length));
            AddPayLoad(WriteString(Server.Motd));
            return this;
        }
    }
}
