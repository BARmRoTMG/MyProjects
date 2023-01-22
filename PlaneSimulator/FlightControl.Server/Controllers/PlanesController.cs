using FlightSimulator.Dal.Entities;
using FlightSimulator.Data.Context;
using FlightSimulator.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightControl.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanesController : Controller
    {
        private readonly IRepository<Flight, Terminal> _context;

        System.Timers.Timer timer = new System.Timers.Timer(5000);

        public PlanesController(IRepository<Flight, Terminal> context)
        {
            _context = context;
            timer.Elapsed += (s, e) => _context.InsertToTerminal();
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            var flights = await _context.GetAll();
            return flights;
        }

        [HttpPost]
        public async Task<IActionResult> AddFlight(Flight flight)
        {
            await _context.Add(flight);

            return NoContent();
        }
    }
}
