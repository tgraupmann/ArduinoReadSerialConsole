using System;
using System.IO.Ports;
using System.Threading;

namespace ArduinoReadSerialConsole
{
    class Program
    {
        static SerialPort _sSerialPort;

        /// <summary>
        /// First arg is the portname
        /// Second arg is the baud rate
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                _sSerialPort = new SerialPort();
                string portName = "COM4";
                if (args.Length > 0 &&
                    !string.IsNullOrEmpty(args[0]))
                {
                    portName = args[0];
                }
                _sSerialPort.PortName = portName;
                int baudRate;
                if (args.Length <= 1 ||
                    string.IsNullOrEmpty(args[1]) ||
                    !int.TryParse(args[1], out baudRate))
                {
                    baudRate = 9600;
                }
                _sSerialPort.BaudRate = baudRate;
                _sSerialPort.ReadTimeout = 5000;
                _sSerialPort.Open();

                while (true)
                {
                    string line = _sSerialPort.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        Console.WriteLine("{0}", line);
                    }
                    Thread.Sleep(1);
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
