using System;
using System.IO.Ports;
using System.Threading.Tasks;

class ReadTest
{
    static string portName = "COM7";
    static int baudRate = 9600;
    static void Main(string[] args)
    {
        var sp = new SerialPort(portName, baudRate);
        sp.RtsEnable = true;
        sp.ReadTimeout = 1000;
        sp.Open();
        sp.Write(new byte[] {0x0f}, 0, 1);
        Console.WriteLine(sp.ReadByte());
    }
}