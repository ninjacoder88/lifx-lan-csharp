namespace LIFXLAN
{
    public class Packet
    {
        public int PacketSize { get; set; }

        //FRAME
        public bool[] Size { get; set; }//16
        public bool[] Protocol { get; set; }//12
        public bool Addressable { get; set; }//1
        public bool Tagged { get; set; }//1
        public bool[] Origin { get; set; }//2
        public bool[] Source { get; set; }//32

        //FRAME ADDRESS
        public bool[] Target { get; set; }//64
        public bool[] Reserved1 { get; set; }//48
        public bool ResponseRequired { get; set; }//1
        public bool AcknowledgeRequired { get; set; }//1
        public bool[] Reserved2 { get; set; }//6
        public bool[] Sequence { get; set; }//8

        //PROTOCOL HEADER
        public bool[] Reserved3 { get; set; }//64
        public bool[] Type { get; set; }//16
        public bool[] Reserved4 { get; set; }//16

        //PAYLOAD
        public bool[] Data { get; set; }
    }

    public class Frame
    {
        public bool[] Size {get;set;}//16
        public bool[] Protocol {get;set;}//12
        public bool Addressable { get; set; }//1
        public bool Tagged {get;set;}//1
        public bool[] Origin {get;set;}//2
        public bool[] Source {get;set;}//32
    }

    public class FrameAddress
    {
        public bool[] Target { get; set; }//64
        public bool[] Reserved1 { get; set; }//48
        public bool ResponseRequired { get; set; }//1
        public bool AcknowledgeRequired { get; set; }//1
        public bool[] Reserved2 { get; set; }//6
        public bool[] Sequence { get; set; }//8
    }

    public class ProtocolHeader
    {
        public bool[] Reserved1 { get; set; }//64
        public bool[] Type { get; set; }//16
        public bool[] Reserved2 { get; set; }//16
    }

    public class Payload
    {
        public bool[] Data { get; set; }
    }
}