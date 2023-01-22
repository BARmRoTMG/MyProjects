using FlightSimulator.Dal.Entities;
using FlightSimulator.Data.Interfaces;
using System;

namespace FlightSimulator.Dal.Terminals
{
    class Terminal_6 : ITerminal
    {
        public bool IsFree { get; set; } = true;
        public static ITerminal Init { get; } = new Terminal_6();
        private Terminal_6() { }
        public void NextTerminal(Flight currentFlight)
        {
            Console.WriteLine(GetType().Name);
            if (Terminal_8.Init.IsFree)
                currentFlight.Terminal = (Terminal)Terminal_8.Init;
        }
    }
}
