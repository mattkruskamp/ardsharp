using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArdSharp.Common
{
    /// <summary>
    /// The abstraction of the board controller.
    /// </summary>
    public interface IBoard
    {
        /// <summary>
        /// Connects to an arduino.
        /// </summary>
        void Connect();

        /// <summary>
        /// Gets the serial connector used for the connection.
        /// </summary>
        ISerialConnector SerialConnector { get; }

        /// <summary>
        /// Sets the basic mode for a particular pin.
        /// </summary>
        /// <param name="pin">The pin to set the mode on.</param>
        /// <param name="mode">The mode.</param>
        void PinMode(int pin, PinMode mode);

        /// <summary>
        /// Write a HIGH or a LOW value to a digital pin.
        /// </summary>
        /// <param name="pin">The pin to write.</param>
        /// <param name="mode">The write mode value.</param>
        void DigitalWrite(int pin, DigitalMode mode);
    }
}
