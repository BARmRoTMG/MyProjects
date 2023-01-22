using FlightSimulator.Dal.Entities;
using FlightSimulator.Data.Context;
using System;

namespace FlightSimulator.Dal.Terminals
{
    public class Terminal_3 : Terminal
    {
        public override void NextTerminal(Flight currentFlight, DataContext data)
        {
            Console.WriteLine("Finish");
        }
    }
}
