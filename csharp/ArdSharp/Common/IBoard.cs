using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArdSharp.Common
{
    public interface IBoard
    {
        void Connect();

        ISerialConnector SerialConnector { get; }
    }
}
