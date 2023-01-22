using FlightControl.Models.Entities;
using FlightControl.Models.Interfaces;
using System;

namespace FlightControl.Logic.Terminals
{
    public class Terminal_1 : ITerminal
    {
        public static ITerminal Init { get; } = new Terminal_1();
        public bool isFree { get; set; }

        private Terminal_1() { }

        public void NextTerminal(Flight currentFlight)
        {
            //Console.WriteLine(GetType().Name);
            //currentFlight.Terminal = Terminal_2.Init;
            //isFree = false;
        }
    }
}
