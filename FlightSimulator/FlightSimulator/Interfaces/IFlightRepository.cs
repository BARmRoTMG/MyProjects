using FlightSimulator.Entities;
using FlightSimulator.Enums;
using System;

namespace FlightSimulator.Interfaces
{
    public interface IFlightRepository : IBasicRepository<Flight>
    {
        Task<Flight> GetFlightByName(string flightNumber);
        Task<List<Flight>> GetFlightsByType(FlightType flightType);
        public Task<List<Flight>> GetFlightsByStatus(FlightStatus flightStatus);
        public Task UpdateFutureFlightsAsync();
    }
}
