using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace EncoderTester
{
    public class WrappedSerialPort
    {
        private readonly string _descriptiveName;
        private SerialPort _port;

        public WrappedSerialPort(string comPort, int baudRate, string descriptiveName)
        {
            _descriptiveName = descriptiveName;
            _port = new SerialPort(comPort, baudRate);

            _port.DataReceived += OnDataReceived;
            _port.ErrorReceived += OnErrorRecieved;
        }

        private void OnErrorRecieved(object sender, SerialErrorReceivedEventArgs e)
        {
            if (ErrorReceived != null)
            {
                WriteText("Error with event type : " + e.EventType.ToString());
                ErrorReceived.Invoke(sender, e);
            }
        }

        public EventHandler<DiagnosticData> Diagnostics;

        private void WriteText(string text)
        {
            string fullText = string.Format("** {0} ** {1}", _descriptiveName, text);
            if (Diagnostics != null)
            {
                Diagnostics(this, new DiagnosticData(fullText));
            }
            //Console.Out.WriteLine(fullText);
        }

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (DataReceived != null)
            {
                WriteText("DataReceived " + e.EventType.ToString());
                DataReceived.Invoke(sender, e);
            }
        }

        public int DataBits
        {
            get { return _port.DataBits; }
            set { _port.DataBits = value; }
        }

        public StopBits StopBits
        {
            get { return _port.StopBits; }
            set { _port.StopBits = value; }
        }

        public string NewLine
        {
            get { return _port.NewLine; }
            set { _port.NewLine = value; }
        }

        public int ReadTimeout
        {
            get { return _port.ReadTimeout; }
            set { _port.ReadTimeout = value; }
        }

        public bool IsOpen
        {
            get { return _port.IsOpen; }
        }

        public string PortName
        {
            get { return _port.PortName; }
        }

        public Parity Parity
        {
            get { return _port.Parity; }
            set { _port.Parity = value; }
        }

        public int WriteTimeout
        {
            get { return _port.WriteTimeout; }
            set { _port.WriteTimeout = value; }
        }

        public event EventHandler<SerialDataReceivedEventArgs> DataReceived;
        public event EventHandler<SerialErrorReceivedEventArgs> ErrorReceived;

        public void Open()
        {
            _port.Open();
        }

        public string ReadExisting()
        {
            var readExisting = _port.ReadExisting();
            WriteText("ReadExisting : " + readExisting);
            return readExisting;
        }

        public void Close()
        {
            _port.Close();
        }

        public void Dispose()
        {
            _port.Dispose();
        }

        public void WriteLine(string value)
        {
            WriteText("WriteLine : " + value);
            _port.WriteLine(value);
        }

        public void DiscardInBuffer()
        {
            _port.DiscardInBuffer();
        }

        public void DiscardOutBuffer()
        {
            _port.DiscardOutBuffer();
        }

        public void Write(string value)
        {
            WriteText("Write : " + value);
            _port.Write(value);
        }
    }

    public class DiagnosticData : EventArgs
    {
        public DiagnosticData(string data)
        {
            Data = data;
        }

        public string Data { get; set; }
    }
}
