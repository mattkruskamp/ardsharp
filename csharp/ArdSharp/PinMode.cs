using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArdSharp
{
    /// <summary>
    /// The arduino documentation pinmode INPUT, 
    /// OUTPUT, and INPUTPULLUP constants.
    /// </summary>
    public enum PinMode
    {
        /// <summary>
        /// INPUT constant for arduino.
        /// </summary>
        Input = 0,

        /// <summary>
        /// OUTPUT constant for arduino.
        /// </summary>
        Output = 1,

        /// <summary>
        /// INPUT_PULLUP for arduino.
        /// </summary>
        InputPullup = 2
    }
}
