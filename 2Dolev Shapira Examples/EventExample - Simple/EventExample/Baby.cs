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
        public int PoopLevel { get; set; }


        // Declare the delegate (if using non-generic pattern).
        public delegate void PoopEventHandler(object sender, PoopEventArgs e);

        // Declare the event.
        public event PoopEventHandler PoopEvent;

        public Baby()
        {
        }

        public void Start(int pooEveryModulu)
        {
            for (PoopLevel = 0; PoopLevel <= 1000; PoopLevel++)
            {
                if (PoopLevel % pooEveryModulu == 0)
                    PoopEvent?.Invoke(this, new PoopEventArgs(PoopLevel));
            }
        }
    }
}
