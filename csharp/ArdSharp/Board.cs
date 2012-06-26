using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArdSharp.Common;

namespace ArdSharp
{
    public class Board : IBoard
    {
        public Board(ISerialConnector connector)
        {
            this.SerialConnector = connector;
        }

        public void Connect()
        {

        }

        public bool IsConnected
        {
            get;
            private set;
        }


        public ISerialConnector SerialConnector
        {
            get;
            private set;
        }
    }
}
