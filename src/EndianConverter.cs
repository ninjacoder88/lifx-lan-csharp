using System;
using System.Collections.Generic;
using System.Text;

namespace LIFXLAN
{
    public class EndianConverter
    {
        public byte[] ToLittleEndian(byte[] source)
        {
            byte[] destination = new byte[source.Length];
            for(int i = 0; i < source.Length; i += 2)
            {
                destination[i] = source[i+1];
                destination[i + 1] = source[1];
            }
            return destination;
        }

        public bool[] ToLittleEndian(bool[] source)
        {
            bool[] destination = new bool[source.Length];

            for(int i = 0; i < source.Length; i++)
            {
                //var temp = source[i];
                destination[i] = source[i + 8];
                destination[i + 8] = source[i];

                if (i % 8 == 7)
                {
                    i += 8;
                }
            }

            return destination;
        }
    }
}
