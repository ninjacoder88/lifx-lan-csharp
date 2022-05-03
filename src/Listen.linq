<Query Kind="Program">
  <Namespace>System.Net</Namespace>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	UdpClient client = new UdpClient();
    client.Client.Bind(new IPEndPoint(IPAddress.Any, 56700));

    var from = new IPEndPoint(0, 0);
    await Task.Run(() =>
    {
        while (true)
        {
            var recBuffer = client.Receive(ref from);

            foreach (var b in recBuffer)
			{
				//Console.Write($"{b} ");
				Console.Write(string.Join("", ConvertByteToBoolArray(b).Select(x => x == true ? "1" : "0")));
			}
                

            Console.WriteLine();
        }
    });
}

private static bool[] ConvertByteToBoolArray(byte b)
{
    // prepare the return result
    bool[] result = new bool[8];

    // check each bit in the byte. if 1 set to true, if 0 set to false
    for (int i = 0; i < 8; i++)
        result[i] = (b & (1 << i)) == 0 ? false : true;

    // reverse the array
    Array.Reverse(result);

    return result;
}

// You can define other methods, fields, classes and namespaces here
