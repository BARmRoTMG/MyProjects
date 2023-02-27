using FlightSimulator.Entities;
using System;

namespace Logic.Interfaces
{
    public interface ITerminalService
    {
        Task ProcessFlight(Flight flight);
        void UpdateInterval(Flight flight);
        void GoNextTerminal(Flight flight);
        Task FromAirToTerminal2(Flight flight);
        void Next(Flight flight);
        Task<string> AddFutureFlight(Flight flightDto);
    }
}
