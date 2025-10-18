using System.Net.Sockets;

namespace Lumanary
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            btnDiscover.Click += BtnDiscover_Click;
        }

        private void BtnDiscover_Click(object? sender, EventArgs e)
        {
            byte[] packet = new byte[36];

            UdpClient udpClient = new UdpClient();
            //udpClient.Send();
        }
    }

    public class PacketBuilder
    {
        public void SetSize(short size)
        {
            byte[] bytes = BitConverter.GetBytes(size);
            _packet[0] = bytes[0];
            _packet[1] = bytes[1];
        }

        private void SetProtocol(short protocol)
        {
            byte[] bytes = BitConverter.GetBytes(protocol);

        }

        private readonly byte[] _packet;
    }
}
