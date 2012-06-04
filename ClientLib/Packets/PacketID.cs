using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Packets
{
    public enum PacketID : byte
    {
        PingPacket = 0,
        LoginPacket = 1,
        InvalidPacket = 2,
        InvalidPacket = 3,
        InvalidPacket = 4,
        InvalidPacket = 5,
        InvalidPacket = 6,
        InvalidPacket = 7,
        InvalidPacket = 8,
        InvalidPacket = 9,
        InvalidPacket = 10,
        InvalidPacket = 11,
        InvalidPacket = 12,
        InvalidPacket = 13,
        InvalidPacket = 14,
        InvalidPacket = 15,
        GlobalMessagePacket = 16,
        ChatMessagePacket = 17,
        KickPacket = 255,
    }
}
