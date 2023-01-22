using FlightSimulator.Dal.Entities;
using FlightSimulator.Data.Interfaces;
using System;

namespace FlightSimulator.Dal.Terminals
{
    class Terminal_4 : ITerminal
    {
        public bool IsFree { get; set; } = true;
        public static ITerminal Init { get; } = new Terminal_4();

        private Terminal_4() { }
        public void NextTerminal(Flight currentFlight)
        {
            Console.WriteLine(GetType().Name);

            if (currentFlight.IsLanding)
                Console.WriteLine("Finish");
            else if (Terminal_5.Init.IsFree)
                currentFlight.Terminal = (Terminal)Terminal_5.Init;
        }
    }
}
