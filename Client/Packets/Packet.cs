using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Packets;

namespace Client.Packets
{
    public abstract class Packet
    {
        public abstract byte id { get; }
        public abstract Packet Make();
        public abstract void Receive(Stream data);
        public byte[] Payload;

        public static Type[] Packets = new Type[] {
            typeof(PingPacket), // 0
            typeof(LoginPacket), // 1
            typeof(InvalidPacket), // 2
            typeof(InvalidPacket), // 3
            typeof(InvalidPacket), // 4
            typeof(InvalidPacket), // 5
            typeof(InvalidPacket), // 6
            typeof(InvalidPacket), // 7
            typeof(InvalidPacket), // 8
            typeof(InvalidPacket), // 9
            typeof(InvalidPacket), // 10
            typeof(InvalidPacket), // 11
            typeof(InvalidPacket), // 12
            typeof(InvalidPacket), // 13
            typeof(InvalidPacket), // 14
            typeof(InvalidPacket), // 15
            typeof(GlobalMessagePacket), // 16
            typeof(ChatMessagePacket), // 17
            typeof(PrivateMessagePacket), // 18
            typeof(InvalidPacket), // 19
            typeof(InvalidPacket), // 20
            typeof(InvalidPacket), // 21
            typeof(InvalidPacket), // 22
            typeof(InvalidPacket), // 23
            typeof(InvalidPacket), // 24
            typeof(InvalidPacket), // 25
            typeof(InvalidPacket), // 26
            typeof(InvalidPacket), // 27
            typeof(InvalidPacket), // 28
            typeof(InvalidPacket), // 29
            typeof(InvalidPacket), // 30
            typeof(InvalidPacket), // 31
            typeof(InvalidPacket), // 32
            typeof(InvalidPacket), // 33
            typeof(InvalidPacket), // 34
            typeof(InvalidPacket), // 35
            typeof(InvalidPacket), // 36
            typeof(InvalidPacket), // 37
            typeof(InvalidPacket), // 38
            typeof(InvalidPacket), // 39
            typeof(InvalidPacket), // 40
            typeof(InvalidPacket), // 41
            typeof(InvalidPacket), // 42
            typeof(InvalidPacket), // 43
            typeof(InvalidPacket), // 44
            typeof(InvalidPacket), // 45
            typeof(InvalidPacket), // 46
            typeof(InvalidPacket), // 47
            typeof(InvalidPacket), // 48
            typeof(InvalidPacket), // 49
            typeof(InvalidPacket), // 50
            typeof(InvalidPacket), // 51
            typeof(InvalidPacket), // 52
            typeof(InvalidPacket), // 53
            typeof(InvalidPacket), // 54
            typeof(InvalidPacket), // 55
            typeof(InvalidPacket), // 56
            typeof(InvalidPacket), // 57
            typeof(InvalidPacket), // 58
            typeof(InvalidPacket), // 59
            typeof(InvalidPacket), // 60
            typeof(InvalidPacket), // 61
            typeof(InvalidPacket), // 62
            typeof(InvalidPacket), // 63
            typeof(InvalidPacket), // 64
            typeof(InvalidPacket), // 65
            typeof(InvalidPacket), // 66
            typeof(InvalidPacket), // 67
            typeof(InvalidPacket), // 68
            typeof(InvalidPacket), // 69
            typeof(InvalidPacket), // 70
            typeof(InvalidPacket), // 71
            typeof(InvalidPacket), // 72
            typeof(InvalidPacket), // 73
            typeof(InvalidPacket), // 74
            typeof(InvalidPacket), // 75
            typeof(InvalidPacket), // 76
            typeof(InvalidPacket), // 77
            typeof(InvalidPacket), // 78
            typeof(InvalidPacket), // 79
            typeof(InvalidPacket), // 80
            typeof(InvalidPacket), // 81
            typeof(InvalidPacket), // 82
            typeof(InvalidPacket), // 83
            typeof(InvalidPacket), // 84
            typeof(InvalidPacket), // 85
            typeof(InvalidPacket), // 86
            typeof(InvalidPacket), // 87
            typeof(InvalidPacket), // 88
            typeof(InvalidPacket), // 89
            typeof(InvalidPacket), // 90
            typeof(InvalidPacket), // 91
            typeof(InvalidPacket), // 92
            typeof(InvalidPacket), // 93
            typeof(InvalidPacket), // 94
            typeof(InvalidPacket), // 95
            typeof(InvalidPacket), // 96
            typeof(InvalidPacket), // 97
            typeof(InvalidPacket), // 98
            typeof(InvalidPacket), // 99
            typeof(InvalidPacket), // 100
            typeof(InvalidPacket), // 101
            typeof(InvalidPacket), // 102
            typeof(InvalidPacket), // 103
            typeof(InvalidPacket), // 104
            typeof(InvalidPacket), // 105
            typeof(InvalidPacket), // 106
            typeof(InvalidPacket), // 107
            typeof(InvalidPacket), // 108
            typeof(InvalidPacket), // 109
            typeof(InvalidPacket), // 110
            typeof(InvalidPacket), // 111
            typeof(InvalidPacket), // 112
            typeof(InvalidPacket), // 113
            typeof(InvalidPacket), // 114
            typeof(InvalidPacket), // 115
            typeof(InvalidPacket), // 116
            typeof(InvalidPacket), // 117
            typeof(InvalidPacket), // 118
            typeof(InvalidPacket), // 119
            typeof(InvalidPacket), // 120
            typeof(InvalidPacket), // 121
            typeof(InvalidPacket), // 122
            typeof(InvalidPacket), // 123
            typeof(InvalidPacket), // 124
            typeof(InvalidPacket), // 125
            typeof(InvalidPacket), // 126
            typeof(InvalidPacket), // 127
            typeof(InvalidPacket), // 128
            typeof(InvalidPacket), // 129
            typeof(InvalidPacket), // 130
            typeof(InvalidPacket), // 131
            typeof(InvalidPacket), // 132
            typeof(InvalidPacket), // 133
            typeof(InvalidPacket), // 134
            typeof(InvalidPacket), // 135
            typeof(InvalidPacket), // 136
            typeof(InvalidPacket), // 137
            typeof(InvalidPacket), // 138
            typeof(InvalidPacket), // 139
            typeof(InvalidPacket), // 140
            typeof(InvalidPacket), // 141
            typeof(InvalidPacket), // 142
            typeof(InvalidPacket), // 143
            typeof(InvalidPacket), // 144
            typeof(InvalidPacket), // 145
            typeof(InvalidPacket), // 146
            typeof(InvalidPacket), // 147
            typeof(InvalidPacket), // 148
            typeof(InvalidPacket), // 149
            typeof(InvalidPacket), // 150
            typeof(InvalidPacket), // 151
            typeof(InvalidPacket), // 152
            typeof(InvalidPacket), // 153
            typeof(InvalidPacket), // 154
            typeof(InvalidPacket), // 155
            typeof(InvalidPacket), // 156
            typeof(InvalidPacket), // 157
            typeof(InvalidPacket), // 158
            typeof(InvalidPacket), // 159
            typeof(InvalidPacket), // 160
            typeof(InvalidPacket), // 161
            typeof(InvalidPacket), // 162
            typeof(InvalidPacket), // 163
            typeof(InvalidPacket), // 164
            typeof(InvalidPacket), // 165
            typeof(InvalidPacket), // 166
            typeof(InvalidPacket), // 167
            typeof(InvalidPacket), // 168
            typeof(InvalidPacket), // 169
            typeof(InvalidPacket), // 170
            typeof(InvalidPacket), // 171
            typeof(InvalidPacket), // 172
            typeof(InvalidPacket), // 173
            typeof(InvalidPacket), // 174
            typeof(InvalidPacket), // 175
            typeof(InvalidPacket), // 176
            typeof(InvalidPacket), // 177
            typeof(InvalidPacket), // 178
            typeof(InvalidPacket), // 179
            typeof(InvalidPacket), // 180
            typeof(InvalidPacket), // 181
            typeof(InvalidPacket), // 182
            typeof(InvalidPacket), // 183
            typeof(InvalidPacket), // 184
            typeof(InvalidPacket), // 185
            typeof(InvalidPacket), // 186
            typeof(InvalidPacket), // 187
            typeof(InvalidPacket), // 188
            typeof(InvalidPacket), // 189
            typeof(InvalidPacket), // 190
            typeof(InvalidPacket), // 191
            typeof(InvalidPacket), // 192
            typeof(InvalidPacket), // 193
            typeof(InvalidPacket), // 194
            typeof(InvalidPacket), // 195
            typeof(InvalidPacket), // 196
            typeof(InvalidPacket), // 197
            typeof(InvalidPacket), // 198
            typeof(InvalidPacket), // 199
            typeof(InvalidPacket), // 200
            typeof(InvalidPacket), // 201
            typeof(InvalidPacket), // 202
            typeof(InvalidPacket), // 203
            typeof(InvalidPacket), // 204
            typeof(InvalidPacket), // 205
            typeof(InvalidPacket), // 206
            typeof(InvalidPacket), // 207
            typeof(InvalidPacket), // 208
            typeof(InvalidPacket), // 209
            typeof(InvalidPacket), // 210
            typeof(InvalidPacket), // 211
            typeof(InvalidPacket), // 212
            typeof(InvalidPacket), // 213
            typeof(InvalidPacket), // 214
            typeof(InvalidPacket), // 215
            typeof(InvalidPacket), // 216
            typeof(InvalidPacket), // 217
            typeof(InvalidPacket), // 218
            typeof(InvalidPacket), // 219
            typeof(InvalidPacket), // 220
            typeof(InvalidPacket), // 221
            typeof(InvalidPacket), // 222
            typeof(InvalidPacket), // 223
            typeof(InvalidPacket), // 224
            typeof(InvalidPacket), // 225
            typeof(InvalidPacket), // 226
            typeof(InvalidPacket), // 227
            typeof(InvalidPacket), // 228
            typeof(InvalidPacket), // 229
            typeof(InvalidPacket), // 230
            typeof(InvalidPacket), // 231
            typeof(InvalidPacket), // 232
            typeof(InvalidPacket), // 233
            typeof(InvalidPacket), // 234
            typeof(InvalidPacket), // 235
            typeof(InvalidPacket), // 236
            typeof(InvalidPacket), // 237
            typeof(InvalidPacket), // 238
            typeof(InvalidPacket), // 239
            typeof(InvalidPacket), // 240
            typeof(InvalidPacket), // 241
            typeof(InvalidPacket), // 242
            typeof(InvalidPacket), // 243
            typeof(InvalidPacket), // 244
            typeof(InvalidPacket), // 245
            typeof(InvalidPacket), // 246
            typeof(InvalidPacket), // 247
            typeof(InvalidPacket), // 248
            typeof(InvalidPacket), // 249
            typeof(InvalidPacket), // 250
            typeof(InvalidPacket), // 251
            typeof(InvalidPacket), // 252
            typeof(InvalidPacket), // 253
            typeof(InvalidPacket), // 254
            typeof(KickPacket), // 255
        };
        public void AddPayLoad(byte b)
        {
            Payload = Payload.Concat(new byte[] { b }).ToArray();
        }
        public void AddPayLoad(byte[] bytes)
        {
            Payload = Payload.Concat(bytes).ToArray();
        }

        public static Packet GetPacketByID(PacketID packetid)
        {
            return (Packet)Activator.CreateInstance((Packets[(byte)packetid]));
        }

        public static Packet GetPacketByID(byte packetid)
        {
            Console.WriteLine("Tried creating packet: " + packetid);
            return (Packet)Activator.CreateInstance((Packets[(byte)packetid]));
        }
        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }


        public static byte[] WriteInt(int i)
        {
            return BitConverter.GetBytes(i);
        }
        public static byte[] WriteString(string s)
        {
            return Encoding.ASCII.GetBytes(s);
        }

        public static int ReadInt(Stream stream)
        {
            byte[] bytes = new byte[4];
            stream.Read(bytes, 0, 4);
            return BitConverter.ToInt32(bytes, 0);
        }
        public static string ReadString(Stream stream, int length)
        {
            byte[] bytes = new byte[length];
            stream.Read(bytes, 0, length);
            return Encoding.ASCII.GetString(bytes);
        }
    }
}
