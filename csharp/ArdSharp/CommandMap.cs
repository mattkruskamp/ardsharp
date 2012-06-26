/**
 * Author: Matt Kruskamp (http://www.cyberkruz.com)
 * Copyright (c) 2012
 * This software is released under the MIT license.
 */
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

        public static int AnalogWrite = 105;

        public static int AnalogRead = 106;
    }
}
