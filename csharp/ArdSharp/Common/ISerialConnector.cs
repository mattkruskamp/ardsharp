using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArdSharp.Commands;

namespace ArdSharp.Common
{
    /// <summary>
    /// Abstraction of serial connections specific to 
    /// the arduno connectors.
    /// </summary>
    public interface ISerialConnector
    {
        bool Connect(string port);

        void Send(Command command);

        string SendRead(Command command);

        bool IsConnected { get; }
    }
}
