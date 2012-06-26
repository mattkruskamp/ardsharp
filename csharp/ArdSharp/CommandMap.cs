using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArdSharp
{
    /// <summary>
    /// A mapper for the serialization of the commands.
    /// </summary>
    public static class CommandMap
    {
        public static int Initialize = 100;

        public static int PinMode = 101;

        public static int DigitalWrite = 102;

        public static int DigitalRead = 103;
    }
}
