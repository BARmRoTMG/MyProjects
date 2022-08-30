using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    class Father
    {
        Child c = new Child();

        public void Action(int counter)
        {
            c.Action(counter);
            c.myEvent += C_myEvent;
        }

        private void C_myEvent(object sender, CounterEventArgs e)
        {
            Console.WriteLine("counter is " + e.Counter);
        }
    }
}
