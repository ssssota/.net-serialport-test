using System;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;

class SerialPortTest {
    const string handshakeRequest = "HMT";
    const string handshakeResponse = "RDY";
    const string dataRequest = "DAT";
    private const string LF = "\n";

    static void Main(string[] args) {
        foreach (var s in SerialPort.GetPortNames()) {
            Console.WriteLine(s);
            var serialPort = new SerialPort(s, 9600);
            serialPort.ReadTimeout = 1000;
            serialPort.WriteTimeout = 1000;
            serialPort.RtsEnable = true;
            serialPort.DtrEnable = true;
            serialPort.NewLine = LF;
            serialPort.Open();
            while (!serialPort.IsOpen);
            serialPort.WriteLine(handshakeRequest);
            var res = serialPort.ReadLine().Trim(new char[] {'\r', '\n'});
            Console.WriteLine(res);
            if (res != handshakeResponse) return;
            serialPort.WriteLine(dataRequest);
            Console.WriteLine(serialPort.ReadLine());
            serialPort.Close();
        }
    }
}