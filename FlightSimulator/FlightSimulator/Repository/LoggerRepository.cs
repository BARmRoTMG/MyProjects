using FlightSimulator.Context;
using FlightSimulator.Entities;
using FlightSimulator.Exceptions;
using FlightSimulator.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace FlightSimulator.Repository
{
    public class LoggerRepository : IBasicRepository<Logger> //ILoggerRepository<Logger>
    {
        private readonly DataContext _context;

        public LoggerRepository(DataContext context)
        {
            _context = context;
        }

        //public void Add(Logger entity)
        //{
        //    _context.Loggers.Add(entity);
        //    _context.SaveChanges();
        //}

        //public Logger Get(string flightNumber)
        //{
        //    return _context.Loggers.First(l => l.FlightNumber == flightNumber);
        //}

        //public Logger Update(Logger entity)
        //{
        //    _context.Loggers.Update(entity);
        //    _context.Entry(entity).State = EntityState.Modified;
        //    _context.SaveChanges();

        //    return entity;
        //}

        public async Task AddAsync(Logger model)
        {
            await _context.Loggers.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Logger>> GetAll()
        {
            return await _context.Loggers.ToListAsync();
        }

        public async Task UpdateAsync(Logger model)
        {
            var log = await _context.Loggers.FirstOrDefaultAsync(l => l.Id == model.Id && l.ExitFromTerminal == default);

            if (log != null)
            {
                if (model.ExitFromTerminal != null)
                    log.ExitFromTerminal = model.ExitFromTerminal;
                else
                    log.ExitFromTerminal = DateTime.Now;

                _context.Update(log);
            }
            else
                throw new LoggerNotFoundException($"Log for flight {model.FlightNumber}, was not found.");

            await _context.SaveChangesAsync();
        }

        public async Task<Logger> GetBasic(Flight flight)
        {
            if (flight.FlightNumber == null)
                throw new FlightNotFoundException($"A flight with the number {flight.FlightNumber} was not found.");
            else
                return await _context.Loggers.FirstOrDefaultAsync(l => l.FlightNumber == flight.FlightNumber);
        }
    }
}