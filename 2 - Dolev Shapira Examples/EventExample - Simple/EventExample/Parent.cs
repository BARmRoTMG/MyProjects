using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventExample
{
    class Parent
    {     
        Baby b = new Baby();
        public Parent()
        {
            b.PoopEvent += B_PoopEvent;
            b.Start(100);
        }

        private void B_PoopEvent(object sender, PoopEventArgs e)
        {
            Console.WriteLine("Hunger level when poop: " + e.HungerLevel);
        }
    }
}
