using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArdSharp.Commands
{
    public abstract class Command
    {
        public Command(int command, int pin, int value)
        {
            this.Pin = pin;
            this.CommandNumber = command;
            this.Value = value;
        }

        public int CommandNumber
        {
            get;
            private set;
        }

        public int Pin 
        { 
            get; 
            private set; 
        }

        public int Value
        {
            get;
            private set;
        }
    }
}
