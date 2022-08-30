using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace EventExample
{
    class Child
    {
        Timer t = new Timer(100);
        int counter;
        public delegate void CounterEventHandler(object sender, CounterEventArgs eventArgs);
        public event CounterEventHandler myEvent;


        public Child()
        {
            t.Elapsed += ReturnFunction;
            t.Start();
        }

        public void Action(int counter)
        {
            this.counter = counter;
        }

        public void ReturnFunction(object sender, ElapsedEventArgs e)
        {

            if (counter % 2 == 0)
                myEvent(this, new CounterEventArgs(counter));
            counter--;
        }
    }
}
