using FlightSimulator.Dal.Entities;
using FlightSimulator.Data.Interfaces;
using System;

namespace FlightSimulator.Dal.Terminals
{
    class Terminal_7 : ITerminal
    {
        public bool IsFree { get; set; } = true;
        public static ITerminal Init { get; } = new Terminal_7();
        private Terminal_7() { }
        public void NextTerminal(Flight currentFlight)
        {
            Console.WriteLine(GetType().Name);
            if (Terminal_8.Init.IsFree)
                currentFlight.Terminal = (Terminal)Terminal_8.Init;
        }
    }
}
