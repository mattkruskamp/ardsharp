/**
 * Author: Matt Kruskamp (http://www.cyberkruz.com)
 * Copyright (c) 2012
 * This software is released under the MIT license.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArdSharp.Common;
using System.IO.Ports;
using System.Diagnostics;
using System.Threading;

namespace ArdSharp
{
    /// <summary>
    /// Class using the serial port class to implement
    /// a connection to the Arduino interface.
    /// </summary>
    public class SerialConnector : ISerialConnector
    {
        const int portNumber = 9600;
        const int friendlyNumber = 42;
        const int backupNumber = 1;
        SerialPort serialPort;

        public SerialConnector() { }

        /// <summary>
        /// Attempts to connect to the arduino interface
        /// on any port available.
        /// </summary>
        /// <returns>
        /// Whether or not the connection was successful.
        /// </returns>
        public bool ConnectAvailablePorts()
        {
            Debug.WriteLine("Connecting to any available port");

            string[] ports = SerialPort.GetPortNames();
            if (ports.Length < 1)
                Debug.WriteLine("There are no avaliable ports");

            bool connected = false;

            // try to connect to all the ports
            foreach (string port in ports)
            {
                if (Connect(port))
                {
                    connected = true;
                    break;
                }
            }

            return connected;
        }

        /// <summary>
        /// Attempts to connect to the arduino interface
        /// on the string port specified.
        /// </summary>
        /// <param name="port">The port name of the connection.</param>
        /// <returns>
        /// Whether or not the connection was successful.
        /// </returns>
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

        /// <summary>
        /// Detects whether or not the connection succeeded.
        /// </summary>
        /// <returns>Whther or not the connection succeeded.</returns>
        private bool Detect()
        {
            try
            {
                this.serialPort.Open();
                string returnMessage = SendRead(new Command(100, 0, 0));
                this.serialPort.Close();

                if (!returnMessage.Contains("hi"))
                {
                    Debug.WriteLine("Got a response, but it wasn't property formatted: " + returnMessage);
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sends the specified command to the arduino interface.
        /// </summary>
        /// <param name="command">The command to send to the arduino.</param>
        public void Send(Command command)
        {
            byte[] buffer = GetBuffer(command);
            Debug.WriteLine(
                string.Format("Sending command - {0}|{1}|{2}|{3}",
                friendlyNumber, command.CommandNumber, 
                command.Pin, command.Value, backupNumber));
            this.serialPort.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Sends the specified command to the ardunino interface
        /// and reads the output sent back.
        /// </summary>
        /// <param name="command">The command to send.</param>
        /// <returns>
        /// The output sent back from the arduino
        /// </returns>
        public string SendRead(Command command)
        {
            // send out the command
            byte[] buffer = GetBuffer(command);
            Debug.WriteLine(
                string.Format("Sending command: - {0}|{1}|{2}|{3}",
                friendlyNumber, command.CommandNumber,
                command.Pin, command.Value, backupNumber));
            this.serialPort.Write(buffer, 0, buffer.Length);

            Thread.Sleep(500); // wait a sec

            // read it back
            int count = this.serialPort.BytesToRead;
            string returnMessage = "";
            int intReturnASCII = 0;
            while (count > 0)
            {
                intReturnASCII = this.serialPort.ReadByte();
                returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                count--;
            }

            Debug.WriteLine("Arduino sent back: " + returnMessage);

            return returnMessage;
        }

        /// <summary>
        /// Takes a command and generates a buffer of bytes from it.
        /// </summary>
        /// <param name="command">The command to parse.</param>
        /// <returns>A byte array to send to arduino.</returns>
        private byte[] GetBuffer(Command command)
        {
            byte[] buffer = new byte[5];
            buffer[0] = Convert.ToByte(friendlyNumber);
            buffer[1] = Convert.ToByte(command.CommandNumber);
            buffer[2] = Convert.ToByte(command.Pin);
            buffer[3] = Convert.ToByte(command.Value);
            buffer[4] = Convert.ToByte(backupNumber);
            return buffer;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is connected to
        /// the arduino.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        public bool IsConnected
        {
            get;
            private set;
        }

        /// <summary>
        /// Opens the direct arduino connection.
        /// </summary>
        public void Open()
        {
            if (this.serialPort.IsOpen)
                return;

            this.serialPort.Open();
        }

        /// <summary>
        /// Closes the direct arduino connection.
        /// </summary>
        public void Close()
        {
            if (!this.serialPort.IsOpen)
                return;

            this.serialPort.Close();
        }
    }
}
