using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EncoderTester;

namespace TestEncoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var comPort = "";
            if (args.Count() < 1)
            {
                Console.WriteLine("Please pass in the com port");
                comPort = Console.ReadLine();
                comPort = comPort.Trim();
            }
            else
            {
                comPort = args[0];
            }
            WrappedSerialPort port = new WrappedSerialPort(comPort, 115200, "Encoder Device");
            port.Diagnostics += OnDiagnostics;

            EncoderDevice device = new EncoderDevice(port);
            var startDegrees = device.GetDegrees();

            Console.WriteLine("First measurement taken please turn the encoder 180 degrees, and press enter");
            Console.ReadLine();

            var endDegrees = device.GetDegrees();

            Console.Out.WriteLine(string.Format("First measurement {0:N2} Second {1:N2}", startDegrees, endDegrees));
            Console.Out.WriteLine("Encoder is good");

            Console.ReadLine();

        }

        private static void OnDiagnostics(object sender, DiagnosticData e)
        {
            File.AppendAllLines("test.txt", new string[] { e.Data } );
        }
    }
}
