using FlightSimulator.Context;
using FlightSimulator.Entities;
using FlightSimulator.Exceptions;
using FlightSimulator.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;

namespace FlightSimulator.Repository
{
    public class TerminalRepository : ITerminalRepository<Terminal>
    {
        private readonly DataContext _context;

        public TerminalRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Terminal> GetTerminalByNumber(int num)
        {
            var ter = await _context.Terminals.FirstAsync(t => t.TerminalNumber == num);

            if (ter != null)
                return ter;
            else
                throw new TerminalNotFoundException($"Terminal {num} was not found.");
        }
    }
}
