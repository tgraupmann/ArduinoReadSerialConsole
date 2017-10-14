using System;
using System.IO.Ports;
using System.Threading;

namespace ArduinoReadSerialConsole
{
    class Program
    {
        static SerialPort _sSerialPort;
        static void Main(string[] args)
        {
            try
            {
                _sSerialPort = new SerialPort();
                _sSerialPort.PortName = "COM4";
                _sSerialPort.BaudRate = 9600;
                _sSerialPort.ReadTimeout = 5000;
                _sSerialPort.Open();

                while (true)
                {
                    Console.WriteLine("{0}: {1}", DateTime.Now, _sSerialPort.ReadLine());
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                Console.Error.WriteLine();
            }
            finally
            {
                _sSerialPort.Close();
            }
        }
    }
}
