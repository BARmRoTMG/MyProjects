using System;

namespace FlightControl.Models.Interfaces
{
    public interface ITerminal
    {
        bool isFree { get; set; }
        void NextTerminal(Flight currentFlight);
    }
}
