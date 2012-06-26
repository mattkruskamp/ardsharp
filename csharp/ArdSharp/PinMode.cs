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
        Input = 0,
        Output = 1,
        InputPullup = 2
    }
}
