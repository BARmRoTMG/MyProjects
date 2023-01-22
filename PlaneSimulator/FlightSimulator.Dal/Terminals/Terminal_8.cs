using FlightSimulator.Dal.Entities;
using FlightSimulator.Data.Interfaces;
using System;

namespace FlightSimulator.Dal.Terminals
{
    class Terminal_8 : ITerminal
    {
        public bool IsFree { get; set; } = true;
        public static ITerminal Init { get; } = new Terminal_8();
        private Terminal_8() { }
        public void NextTerminal(Flight currentFlight)
        {
            currentFlight.IsLanding = true;
            Console.WriteLine(GetType().Name);
            if (Terminal_4.Init.IsFree)
                currentFlight.Terminal = (Terminal)Terminal_4.Init;
        }
    }
}
