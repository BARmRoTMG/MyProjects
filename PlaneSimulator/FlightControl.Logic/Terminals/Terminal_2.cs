using FlightControl.Models.Entities;
using FlightControl.Models.Interfaces;
using System;

namespace FlightControl.Logic.Terminals
{
    public class Terminal_2 : ITerminal
    {
        public bool isFree { get; set; }
        private Terminal_2()
        {

        }

        public void NextTerminal(Flight currentFlight)
        {
            //Console.WriteLine(GetType().Name);
            //currentFlight.Terminal = Terminal_2.Init;
        }
    }
}