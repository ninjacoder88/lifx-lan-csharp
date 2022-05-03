using System;
using System.Collections.Generic;
using System.Text;

namespace LIFXLAN
{
    public class PacketSerializer
    {
        public bool[] Serialize(Packet packet)
        {
            bool[] packetBits = new bool[packet.PacketSize];

            int p = 0;
            for (int i = 0; i < packet.Size.Length; i++)
                packetBits[p++] = packet.Size[i];

            for (int i = 0; i < packet.Origin.Length; i++)
                packetBits[p++] = packet.Origin[i];

            packetBits[p++] = packet.Tagged;
            packetBits[p++] = packet.Addressable;

            for (int i = 0; i < packet.Protocol.Length; i++)
                packetBits[p++] = packet.Protocol[i];

            for (int i = 0; i < packet.Source.Length; i++)
                packetBits[p++] = packet.Source[i];


            for (int i = 0; i < packet.Target.Length; i++)
                packetBits[p++] = packet.Target[i];

            for (int i = 0; i < packet.Reserved1.Length; i++)
                packetBits[p++] = packet.Reserved1[i];

            for (int i = 0; i < packet.Reserved2.Length; i++)
                packetBits[p++] = packet.Reserved2[i];

            packetBits[p++] = packet.AcknowledgeRequired;
            packetBits[p++] = packet.ResponseRequired;

            for (int i = 0; i < packet.Sequence.Length; i++)
                packetBits[p++] = packet.Sequence[i];


            for (int i = 0; i < packet.Reserved3.Length; i++)
                packetBits[p++] = packet.Reserved3[i];

            for (int i = 0; i < packet.Type.Length; i++)
                packetBits[p++] = packet.Type[i];

            for (int i = 0; i < packet.Reserved4.Length; i++)
                packetBits[p++] = packet.Reserved4[i];

            for (int i = 0; i < packet.Data.Length; i++)
                packetBits[p++] = packet.Data[i];

            return packetBits;
        }
    }
}
