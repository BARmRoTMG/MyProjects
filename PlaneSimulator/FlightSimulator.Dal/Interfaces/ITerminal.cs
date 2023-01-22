using FlightSimulator.Dal.Entities;
using System;

namespace FlightSimulator.Data.Interfaces
{
    public interface ITerminal
    {
        bool IsFree { get; set; }
        void NextTerminal(Flight currentFlight);
    }
}
