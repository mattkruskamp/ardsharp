using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArdSharp.Common;
using System.IO.Ports;
using System.Diagnostics;
using ArdSharp.Commands;

namespace ArdSharp
{
    public class SerialConnector : ISerialConnector
    {
        const int portNumber = 9600;
        SerialPort serialPort;

        public SerialConnector() { }

        public void ConnectAvailablePorts()
        {
            Debug.WriteLine("Connecting to any available port");

            string[] ports = SerialPort.GetPortNames();
            if (ports.Length < 1)
                Debug.WriteLine("There are no avaliable ports");

            // try to connect to all the ports
            foreach (string port in ports)
            {
                if (!Connect(port))
                    break;
            }
        }

        public bool Connect(string port)
        {
            Debug.WriteLine("Connecting to serial port: " + port);
            this.serialPort = new SerialPort(port, 9600);

            if (Detect())
            {
                Debug.WriteLine("Connected...");
                this.IsConnected = true;
                return true;
            }

            return false;
        }

        private bool Detect()
        {
            try
            {
                this.serialPort.Open();
                string returnMessage = SendRead(new HelloCommand());
                this.serialPort.Close();

                if (!returnMessage.Contains("hi"))
                {
                    Debug.WriteLine("Got a response, but it wasn't property formatted: " + returnMessage);
                    return false;
                }

                Debug.WriteLine("Arduino returned: " + returnMessage);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public void Send(Commands.Command command)
        {
            throw new NotImplementedException();
        }

        public string SendRead(Commands.Command command)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected
        {
            get;
            private set;
        }
    }
}
