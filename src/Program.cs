using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace LIFXLAN 
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            var packet = new PacketBuilder()
                                .IsTagged(true)
                                .AddSource(135797531)
                                .AddTarget(0)
                                .ResponseRequired(true)
                                .AcknowledgeRequire(true)
                                .AddSequence(50)
                                .SetType(2)
                                .SetPayload(0)
                                .Build();

            var serializedPacket = new PacketSerializer().Serialize(packet);

            Console.WriteLine(string.Join("", serializedPacket.Select(x => x == true ? "1" : "0")));

            var litteEndianSerializedPacket = new EndianConverter().ToLittleEndian(serializedPacket);

            Console.WriteLine(string.Join("", litteEndianSerializedPacket.Select(x => x == true ? "1" : "0")));

            var packetBytes = new BitToByteTransformer().Transform(litteEndianSerializedPacket);

            Console.WriteLine(string.Join(" ", packetBytes.Select(x => (int)x)));

            //var littleEndianPacket = new EndianConverter().ToLittleEndian(packetBytes);

            //var input = string.Join("", packet.Select(x => x == true ? "1" : "0"));
            //int numOfBytes = input.Length / 8;
            //byte[] bytes = new byte[numOfBytes];
            //for (int i = 0; i < numOfBytes; ++i)
            //{
            //    var b = Convert.ToByte(input.Substring(8 * i, 8), 2);
            //    bytes[i] = b;
            //    Console.Write($"{b}\t");
            //}
            //Console.WriteLine(input);



            UdpClient client = new UdpClient();
            //client.Client.Bind(new IPEndPoint(IPAddress.Any, 56700));

            //var from = new IPEndPoint(0, 0);
            //Task.Run(() =>
            //{
            //    while (true)
            //    {
            //        var recBuffer = client.Receive(ref from);

            //        foreach (var b in recBuffer)
            //            Console.Write($"{b}\t");

            //        Console.WriteLine();
            //    }
            //});


            client.Send(packetBytes, packetBytes.Length, "255.255.255.255", 56700);

            Console.ReadLine();
        }
    }
}
