using System;

namespace LIFXLAN
{
    public class BitToByteTransformer
    {
        public byte[] Transform(bool[] source)
        {
            if (source.Length % 8 != 0)
                throw new Exception("Source bit count is not divisible by 8");

            int byteCount = source.Length / 8;

            byte[] destination = new byte[byteCount];

            for(int i = 0; i < byteCount; i++)
            {
                bool[] subSource = new bool[8];
                string bits = "";
                for(int j = 0; j < 8; j++)
                {
                    var index = (i * 8) + j;
                    subSource[j] = source[index];
                    bits += subSource[j] == true ? "1" : "0";
                }
                destination[i] = Convert.ToByte(bits, 2);
            }

            return destination;
        }

        public bool[] Transform(byte[] source)
        {
            int bitCount = source.Length * 8;

            bool[] desination = new bool[bitCount];

            for(int i = 0; i < source.Length; i++)
            {
                byte b = source[i];


            }

            return desination;
        }
    }
}
