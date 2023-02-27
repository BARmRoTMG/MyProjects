using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    class PoopEventArgs : EventArgs
    {
        public int HungerLevel { get; }

        public PoopEventArgs(int hungerLevel)
        {
            HungerLevel = hungerLevel;
        }
    }
}
