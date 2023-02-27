using FlightSimulator.Context;
using FlightSimulator.Entities;
using FlightSimulator.Enums;
using FlightSimulator.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace FlightSimulator.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DataContext _context;

        public FlightRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Flight model)
        {
            _context.Flights.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Flight>> GetAll() => await _context.Flights.ToListAsync();

        public Task<Flight> GetBasic(Flight flight)
        {
            throw new NotImplementedException();
        }

        public async Task<Flight> GetFlightByName(string flightNumber) => await _context.Flights.SingleOrDefaultAsync(f => f.FlightNumber == flightNumber);

        public async Task<List<Flight>> GetFlightsByStatus(FlightStatus flightStatus) => await _context.Flights.Where(f => f.Status == flightStatus).ToListAsync();

        public async Task<List<Flight>> GetFlightsByType(FlightType flightType) => await _context.Flights.Where(f => f.Type == flightType).ToListAsync();

        public async Task UpdateAsync(Flight model)
        {
            _context.Flights.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFutureFlightsAsync()
        {
            var flightToUpdate = await _context.Flights.Where(f => f.Status == FlightStatus.Future && f.FlightTime < DateTime.Now).ToListAsync();
            foreach (var item in flightToUpdate)
            {
                item.Status = FlightStatus.Past;
                _context.Flights.Update(item);
            }
            await _context.SaveChangesAsync();
        }
    }
}
