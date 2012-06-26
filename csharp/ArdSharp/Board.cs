using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArdSharp.Common;
using System.Diagnostics;

namespace ArdSharp
{
    public class Board : IBoard
    {
        public Board(ISerialConnector connector)
        {
            this.SerialConnector = connector;
        }

        ~Board()
        {
            this.SerialConnector.Close();
            this.SerialConnector = null;
        }

        public virtual void Connect()
        {
            bool isConnected = this.SerialConnector.ConnectAvailablePorts();

            if (!isConnected)
            {
                Debug.WriteLine("Couldn't connect to any arduinos.");
                return;
            }

            this.SerialConnector.Open();
        }

        public ISerialConnector SerialConnector
        {
            get;
            private set;
        }

        public void PinMode(int pin, PinMode mode)
        {
            Debug.WriteLine(string.Format("Sending pin mode {0} to pin {1}", mode.ToString(), pin));
            SerialConnector.Send(
                new Command(CommandMap.PinMode, pin, (int)mode));
        }


        public void DigitalWrite(int pin, DigitalWriteMode mode)
        {
            Debug.WriteLine(string.Format("Sending digital write {0} to pin {1}", mode.ToString(), pin));
            SerialConnector.Send(
                new Command(CommandMap.DigitalWrite, pin, (int)mode));
        }
    }
}
