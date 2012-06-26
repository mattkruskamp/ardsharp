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
using System.Diagnostics;

namespace ArdSharp
{
    /// <summary>
    /// Concrete implementation of a base arduino board.
    /// </summary>
    public class Board : IBoard
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        /// <param name="connector">The connector.</param>
        public Board(ISerialConnector connector)
        {
            this.SerialConnector = connector;
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Board"/> is reclaimed by garbage collection.
        /// </summary>
        ~Board()
        {
            this.SerialConnector.Close();
            this.SerialConnector = null;
        }

        /// <summary>
        /// Connects to an arduino. Tries multiple ports.
        /// </summary>
        public virtual void Connect()
        {
            bool isConnected = this.SerialConnector.ConnectAvailablePorts();

            if (!isConnected)
            {
                Debug.WriteLine("Couldn't connect to any arduinos.");
                return;
            }

            this.SerialConnector.Open();
        }

        /// <summary>
        /// Gets the serial connector used for the connection.
        /// </summary>
        public ISerialConnector SerialConnector
        {
            get;
            private set;
        }

        /// <summary>
        /// Sets the basic mode for a particular pin.
        /// </summary>
        /// <param name="pin">The pin to set the mode on.</param>
        /// <param name="mode">The mode.</param>
        public void PinMode(int pin, PinMode mode)
        {
            Debug.WriteLine(string.Format("Sending pin mode {0} to pin {1}", mode.ToString(), pin));
            SerialConnector.Send(
                new Command(CommandMap.PinMode, pin, (int)mode));
        }

        /// <summary>
        /// Write a HIGH or a LOW value to a digital pin.
        /// </summary>
        /// <param name="pin">The pin to write.</param>
        /// <param name="mode">The write mode value.</param>
        public void DigitalWrite(int pin, DigitalMode mode)
        {
            Debug.WriteLine(string.Format("Sending digital write {0} to pin {1}", mode.ToString(), pin));
            SerialConnector.Send(
                new Command(CommandMap.DigitalWrite, pin, (int)mode));
        }

        /// <summary>
        /// Reads the value from a specified digital pin, either HIGH or LOW.
        /// </summary>
        /// <param name="pin">The pin to read from.</param>
        /// <returns>The digitalmode from the pin.</returns>
        public DigitalMode DigitalRead(int pin)
        {
            Debug.WriteLine(string.Format("Sending digital read to pin {0}", pin));
            string message = SerialConnector.SendRead(new Command(CommandMap.DigitalRead, pin, 0));
            int tryMessage;
            if (!int.TryParse(message, out tryMessage))
                throw new InvalidOperationException("The arduino passed back invalid data about the port.");
            return (DigitalMode)tryMessage;
        }
    }
}
