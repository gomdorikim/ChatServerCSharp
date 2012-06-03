using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Server.Packets
{
    public class LoginPacket : Packet
    {
        private int UserID { get; set; }
        public LoginPacket(int UserID)
        {
            this.UserID = UserID;
            Payload = new byte[37];
        }
        public override byte id
        {
            get { return 1; }
        }
        public override void Receive(Stream data)
        {
            int l1 = ReadInt(data);
            string connected_users = ReadString(data, l1);
            string[] users = connected_users.Split('§');
            connected_users = connected_users.Replace("§", ", ");
            int l2 = ReadInt(data);
            string motd = ReadString(data, l2);
            Network.GetChat("[Server]: Users online: " + connected_users);
            Network.GetChat("[Server]: " + motd);
        }
        public override Packet Make()
        {
            AddPayLoad(1);
            AddPayLoad(WriteInt(UserID));
            AddPayLoad(WriteString(RandomString(32)));
            return this;
        }
    }
}
