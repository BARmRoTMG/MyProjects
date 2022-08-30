using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    class CounterEventArgs : EventArgs
    {
        public int Counter { get; set; }

        public CounterEventArgs(int counter)
        {
            Counter = counter;
        }
    }
}
