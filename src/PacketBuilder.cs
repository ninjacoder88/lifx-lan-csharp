using System;
using System.Collections.Generic;
using System.Text;

namespace LIFXLAN
{
    public class PacketBuilder
    {
        public PacketBuilder()
        {
            Packet = new Packet();
        }

        public Packet Build()
        {
            Packet.Protocol = Convert.ToString(1024, 2).PadLeft(12, '0').ToBoolArray();
            Packet.Addressable = true;
            Packet.Origin = Convert.ToString(0, 2).PadLeft(2, '0').ToBoolArray();
            Packet.Reserved1 = Convert.ToString(0, 2).PadLeft(48, '0').ToBoolArray();
            Packet.Reserved2 = Convert.ToString(0, 2).PadLeft(6, '0').ToBoolArray();
            Packet.Reserved3 = Convert.ToString(0, 2).PadLeft(64, '0').ToBoolArray();
            Packet.Reserved4 = Convert.ToString(0, 2).PadLeft(16, '0').ToBoolArray();

            //compute total size
            int size = 64 + 128 + 96 + Packet.Data.Length;
            Packet.Size = Convert.ToString(size, 2).PadLeft(16, '0').ToBoolArray();
            Packet.PacketSize = size;

            return Packet;
        }

        public PacketBuilder IsTagged(bool value)
        {
            Packet.Tagged = value;
            return this;
        }

        public PacketBuilder AddSource(uint id)
        {
            Packet.Source = Convert.ToString(id, 2).PadLeft(32, '0').ToBoolArray();
            return this;
        }

        public PacketBuilder AddTarget(long id)
        {
            Packet.Target = Convert.ToString(id, 2).PadLeft(64, '0').ToBoolArray();
            return this;
        }

        public PacketBuilder ResponseRequired(bool value)
        {
            Packet.ResponseRequired = value;
            return this;
        }

        public PacketBuilder AcknowledgeRequire(bool value)
        {
            Packet.AcknowledgeRequired = value;
            return this;
        }

        public PacketBuilder AddSequence(sbyte value)
        {
            Packet.Sequence = Convert.ToString(value, 2).PadLeft(8, '0').ToBoolArray();
            return this;
        }

        public PacketBuilder SetType(short value)
        {
            Packet.Type = Convert.ToString(value, 2).PadLeft(16, '0').ToBoolArray();
            return this;
        }


        public PacketBuilder SetPayload(int value)
        {
            Packet.Data = new bool[0];
            return this;
        }

        private Packet Packet { get; set; }
    }

    public static class StringExtensions
    {
        public static bool[] ToBoolArray(this string str)
        {
            bool[] array = new bool[str.Length];
            var charArray = str.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                array[i] = charArray[i] == '1' ? true : false;
            }
            return array;
        }
    }
}
