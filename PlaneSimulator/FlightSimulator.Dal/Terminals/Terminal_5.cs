using FlightSimulator.Dal.Entities;
using FlightSimulator.Data.Interfaces;
using System;

namespace FlightSimulator.Dal.Terminals
{
    class Terminal_5 : ITerminal
    {
        public bool IsFree { get; set; } = true;
        public static ITerminal Init { get; } = new Terminal_5();
        private Terminal_5() { }
        public void NextTerminal(Flight currentFlight)
        {
            Console.WriteLine(GetType().Name);
            if (Terminal_6.Init.IsFree)
                currentFlight.Terminal = (Terminal)Terminal_6.Init;
            else if (Terminal_7.Init.IsFree)
                currentFlight.Terminal = (Terminal)Terminal_7.Init;
        }
    }
}
