using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace EncoderTester
{
    public class EncoderDevice
    {
        private static bool orientateLaser = true;

        private const double TICKS_PER_ROTATION = 8192 * 4;
        private const string REQUEST_DEGREES = "?";

        private WrappedSerialPort _devicePort;
        private double _tickOffset = 0;

        public EncoderDevice(WrappedSerialPort port)
        {
            _devicePort = port;
            _devicePort.Open();
            _devicePort.NewLine = "\r";
            if (orientateLaser)
            {
                Orientate();
                orientateLaser = false;
            }
        }

        public double GetTicks()
        {
            try
            {
                _devicePort.WriteLine(REQUEST_DEGREES);
                System.Threading.Thread.Sleep(100);
                string result = _devicePort.ReadExisting();
                Console.Out.WriteLine("result = {0}", result);
                if (result.Split(':').Length == 3)
                {
                    //Success
                    string ticks = result.Split(':')[0];
                    double numberOfTicks = int.Parse(ticks, NumberStyles.AllowHexSpecifier);
                    Console.Out.WriteLine("numberOfTicks = {0}", numberOfTicks);
                    numberOfTicks += _tickOffset;
                    Console.Out.WriteLine("offset number of ticks = {0}", numberOfTicks);
                    return numberOfTicks;
                }
            }
            catch (System.IO.IOException exc)
            {
                try
                {
                    //Location connection to the device
                    if (_devicePort != null)
                    {
                        _devicePort.Dispose();
                        _devicePort = null;
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("exc = {0}", e.ToString());
                }
            }
            catch (UnauthorizedAccessException exc)
            {
                try
                {
                    //Location connection to the device
                    if (_devicePort != null)
                    {
                        _devicePort.Dispose();
                        _devicePort = null;
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("exc = {0}", e);
                }
            }
            catch (Exception exc)
            {
                try
                {
                    //Location connection to the device
                    if (_devicePort != null)
                    {
                        _devicePort.Dispose();
                        _devicePort = null;
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("exc = {0}", e);
                }
            }
            return double.NegativeInfinity;
        }

        public double GetDegrees()
        {
            double numberOfTicks = GetTicks();
            if (numberOfTicks == double.NegativeInfinity)
            {
                return double.NegativeInfinity;
            }
            double degrees = 360 * (numberOfTicks % TICKS_PER_ROTATION) / TICKS_PER_ROTATION;
            Console.Out.WriteLine("degrees = {0}", degrees);

            return degrees;
        }

        public static bool _orienated;
        public static double _orientation;

        public void Orientate()
        {
            if (!_orienated)
            {
                _tickOffset = 0;
                double ticks = GetTicks();

                _tickOffset = (-1 * ticks) + (TICKS_PER_ROTATION / 4);
                _orientation = _tickOffset;
                _orienated = true;
            }
            else
            {
                _tickOffset = _orientation;
            }
        }

        public void Dispose()
        {
            try
            {
                if (_devicePort != null)
                {
                    _devicePort.Close();
                    _devicePort.Dispose();
                }
            }
            catch (Exception exc)
            {
                Console.Out.WriteLine("exc = {0}", exc);
            }
        }



    }
}
