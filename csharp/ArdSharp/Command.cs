using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArdSharp
{
    /// <summary>
    /// Class encapsulating a command sent to the
    /// ardunio interface.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="pin">The pin.</param>
        /// <param name="value">The value.</param>
        public Command(int command, int pin, int value)
        {
            this.Pin = pin;
            this.CommandNumber = command;
            this.Value = value;
        }

        /// <summary>
        /// Gets the command number sent to the arduino.
        /// </summary>
        public int CommandNumber
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the pin number sent to the arduino.
        /// </summary>
        public int Pin 
        { 
            get; 
            private set; 
        }

        /// <summary>
        /// Gets the value number sent to the arduino.
        /// </summary>
        public int Value
        {
            get;
            private set;
        }
    }
}
