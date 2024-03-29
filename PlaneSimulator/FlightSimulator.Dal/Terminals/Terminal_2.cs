﻿using FlightSimulator.Dal.Entities;
using FlightSimulator.Data.Context;
using System;

namespace FlightSimulator.Dal.Terminals
{
    public class Terminal_2 : Terminal
    {
        public override void NextTerminal(Flight currentFlight, DataContext data)
        {
            Console.WriteLine(GetType().Name);
            var ter = data.Terminals.First(t => t.Id == 3);
            if (ter.IsFree)
                currentFlight.Terminal = ter;
        }
    }
}