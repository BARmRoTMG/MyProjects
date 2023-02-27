using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EventExample
{
    class Baby
    {
        

        public int HungerLevel { get; set; }
        public int PoopLevel { get; set; }


        // Declare the delegate (if using non-generic pattern).
        public delegate void PoopEventHandler(object sender, PoopEventArgs e);

        // Declare the event.
        public event PoopEventHandler PoopEvent;

        Timer poopTimer = new Timer();
        Timer hungerTimer = new Timer();

        public Baby(int poopLevel, int hungerLevel)
        {
            PoopLevel = PoopLevel;
            HungerLevel = hungerLevel;
            poopTimer.Interval = 1000;
            hungerTimer.Interval = 300;

            poopTimer.Elapsed += PoopTimer_Elapsed;
            hungerTimer.Elapsed += HungerTimer_Elapsed;

            poopTimer.Start();
            hungerTimer.Start();
        }

        private void HungerTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            HungerLevel--;
        }

        private void PoopTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PoopLevel--;

            if (PoopLevel == 0)
                PoopEvent(this, new PoopEventArgs(HungerLevel));
        }
    }
}
