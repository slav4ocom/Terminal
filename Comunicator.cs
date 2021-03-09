using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public static class Comunicator
    {
        private static readonly string _comName = "COM5";
        private static readonly int _baudRate = 115200;
        private static readonly Parity _parity = Parity.None;
        private static readonly int _dataBits = 8;
        private static readonly StopBits _stopBits = StopBits.One;
        

        static SerialPort myPort;

        public static void InitPort()
        {
            myPort = new SerialPort(_comName, _baudRate, _parity, _dataBits, _stopBits);
            myPort.Open();
        }

        public static void Close()
        {

            myPort.Close();
            myPort.Dispose();
        }

        public static void ShowPortInfo()
        {
            Console.WriteLine(myPort.PortName + "\r\n"
                + myPort.BaudRate + "\r\n"
                + myPort.Parity + "\r\n"
                + myPort.DataBits + "\r\n"
                + myPort.StopBits + "\r\n"
                );
        }

        public static async Task Receive()
        {
            byte[] receiveBuffer = new byte[4096];
            var numBytesReaden = await myPort.BaseStream.ReadAsync(receiveBuffer);
            //Console.WriteLine(numBytesReaden);
            Console.Write(Encoding.UTF8.GetString(receiveBuffer));
        }

        

        public static async Task SendString(string inputString)
        {
            if (inputString == "+++" || inputString == "\\0")
            {
                byte[] sendBuffer = Encoding.UTF8.GetBytes(inputString);
                await myPort.BaseStream.WriteAsync(sendBuffer);
            }
            else
            {
                byte[] sendBuffer = Encoding.UTF8.GetBytes(inputString + "\r\n");
                await myPort.BaseStream.WriteAsync(sendBuffer);

            }
        }

       

    }
}
