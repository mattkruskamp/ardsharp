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

        /// <summary>
        /// Reads the value from a specified digital pin, either HIGH or LOW.
        /// </summary>
        /// <param name="pin">The pin to read from.</param>
        /// <returns>The digitalmode from the pin.</returns>
        DigitalMode DigitalRead(int pin);

        /// <summary>
        /// Writes an analog value (PWM wave) to a pin. Can be used to light a LED at 
        /// varying brightnesses or drive a motor at various speeds.
        /// </summary>
        /// <param name="pin">The pin to write.</param>
        /// <param name="value">The value from 0 to 255 to set to.</param>
        void AnalogWrite(int pin, int value);

        /// <summary>
        /// Reads the value from a specified analog pin.
        /// </summary>
        /// <param name="pin">The pin to read from.</param>
        /// <returns>A value of the pin from 0 to 1023.</returns>
        int AnalogRead(int pin);
    }
}
