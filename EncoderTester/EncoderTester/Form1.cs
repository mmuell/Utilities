using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncoderTester
{
    public partial class Form1 : Form
    {
        private EncoderDevice _encoder;

        public Form1()
        {
            InitializeComponent();

            Load += OnControlLoad;
            FormClosed += FormOnClosed;
        }

        private void FormOnClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CleanupDevice();
            }
            catch
            {
                
            }
        }

        private void OnControlLoad(object sender, EventArgs e)
        {
            SerialPortsCB.Items.Clear();
            foreach (var portName in SerialPort.GetPortNames())
            {
                SerialPortsCB.Items.Add(portName);
            }
            if (SerialPortsCB.Items.Count > 0)
            {
                SerialPortsCB.SelectedIndex = 0;
            }
            if (CommandCB.Items.Count > 0)
            {
                CommandCB.SelectedIndex = 0;
            }
        }

        private void ConnectPB_Click(object sender, EventArgs e)
        {
            try
            {
                var wrappedSerialPort = new WrappedSerialPort((string) SerialPortsCB.SelectedItem, 9600, "Encoder Device");
                wrappedSerialPort.Diagnostics += OnDiagnostics;
                wrappedSerialPort.WriteTimeout = 250;
                _encoder = new EncoderDevice(wrappedSerialPort);
                _encoder.Orientate();
            }
            catch (Exception exception)
            {
                WriteMessage(exception.ToString());
            }
        }

        private void OnDiagnostics(object sender, DiagnosticData e)
        {
            WriteMessage(e.Data);
        }

        private delegate void WriteMessageDel(string message);

        private void WriteMessage(string message)
        {
            if (this.InvokeRequired)
            {
                WriteMessageDel del = WriteMessage;
                del.Invoke(message);
                return;
            }

            OutputET.Text = string.Concat(string.Format("Ouput at {0}", DateTime.Now.ToShortTimeString()), " --> ", message, Environment.NewLine, Environment.NewLine, OutputET.Text);
        }

        private void DisconnectPB_Click(object sender, EventArgs e)
        {
            try
            {
                CleanupDevice();
            }
            catch (Exception exception)
            {
                WriteMessage(exception.ToString());
            }
        }

        private void CleanupDevice()
        {
            if (_encoder != null)
            {
                _encoder.Dispose();
                _encoder = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((string)CommandCB.SelectedItem == "GetTicks")
            {
                var response = _encoder.GetTicks();
                WriteMessage(response.ToString("N6"));    
            }
            else
            {
                var response = _encoder.GetDegrees();
                WriteMessage(response.ToString("N6"));    
            }
            
        }

    }
}
