using FlightSimulator.Entities;
using System;

namespace FlightSimulator.Interfaces
{
    public interface ITerminalRepository<T>
    {
        Task<Terminal> GetTerminalByNumber(int num);
    }
}
