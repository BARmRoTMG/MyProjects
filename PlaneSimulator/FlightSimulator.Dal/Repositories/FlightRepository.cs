using FlightSimulator.Dal.Entities;
using FlightSimulator.Data.Context;
using FlightSimulator.Data.Exceptions;
using FlightSimulator.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace FlightSimulator.Data.Repositories
{
    public class FlightRepository : IRepository<Flight, Terminal>
    {
        private readonly DataContext _context;

        public FlightRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Flight entity)
        {
            await _context.AddAsync(entity);
            await _context.Loggers.AddAsync(new Logger { Flight = entity, In = DateTime.Now });
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var flight = await GetById(id);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Flight>> GetAll()
        {
            var flights = await _context.Flights.ToListAsync();

            return flights;
        }

        public async Task<Flight> GetById(int id)
        {
            var flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);

            if (flight == null)
                throw new FlightNotFoundException($"Flight with id {id} was not found.");

            return flight;
        }

        public async Task InsertToTerminal()
        {
            var flight = await _context.FlightsQueues.FirstOrDefaultAsync();

            if (flight != null)
            {
                var plane = flight.Flights.FirstOrDefault();
                if (plane != null)
                {
                    var terminal = await _context.Terminals.FirstAsync(t => t.Number == 2);
                    if (terminal.Flight == null)
                    {
                        terminal.Flight = plane;
                        flight.Flights.Remove(plane);
                        await UpdateLogger(plane, terminal);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        public async Task UpdateLogger(Flight entity, Terminal terminal)
        {
            var before = await _context.Loggers.FirstAsync(l => l.Flight.Id == entity.Id && l.Out == null);
            before.Out = DateTime.Now;
            before.Flight = null;
            _context.Loggers.Add(new Logger { Flight = entity, Terminal = terminal, In = DateTime.Now });
        }
    }
}
