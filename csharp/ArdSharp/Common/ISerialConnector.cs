/**
 * Author: Matt Kruskamp (http://www.cyberkruz.com)
 * Copyright (c) 2012
 * This software is released under the MIT license.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArdSharp.Common
{
    /// <summary>
    /// Abstraction of serial connections specific to 
    /// the arduno connectors.
    /// </summary>
    public interface ISerialConnector
    {
        /// <summary>
        /// Attempts to connect to the arduino interface
        /// on the string port specified.
        /// </summary>
        /// <param name="port">The port name of the connection.</param>
        /// <returns>Whether or not the connection was successful.</returns>
        bool Connect(string port);

        /// <summary>
        /// Attempts to connect to the arduino interface
        /// on any port available.
        /// </summary>
        /// <returns>Whether or not the connection was successful.</returns>
        bool ConnectAvailablePorts();

        /// <summary>
        /// Opens the direct arduino connection.
        /// </summary>
        void Open();

        /// <summary>
        /// Closes the direct arduino connection.
        /// </summary>
        void Close();

        /// <summary>
        /// Sends the specified command to the arduino interface.
        /// </summary>
        /// <param name="command">The command to send to the arduino.</param>
        void Send(Command command);

        /// <summary>
        /// Sends the specified command to the ardunino interface
        /// and reads the output sent back.
        /// </summary>
        /// <param name="command">The command to send.</param>
        /// <returns>The output sent back from the arduino</returns>
        string SendRead(Command command);

        /// <summary>
        /// Gets a value indicating whether this instance is connected to
        /// the arduino.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </value>
        bool IsConnected { get; }
    }
}
