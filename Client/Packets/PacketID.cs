using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Packets
{
    public enum PacketID : byte
    {
        PingPacket = 0,
        LoginPacket = 1,
        GlobalMessagePacket = 16,
        ChatMessagePacket = 17,
        KickPacket = 255,
    }
}
