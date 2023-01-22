using FlightSimulator.Entities;
using FlightSimulator.Interfaces;
using Logic.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirportServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : Controller
    {
        private readonly IFlightRepository _context;

        public AirportController(IFlightRepository context)
        {
            _context = context;
        }

        [HttpGet("get")]
        public async Task<IEnumerable<Flight>> GetFlights()
        {
            var flights = await _context.GetAll();
            return flights;
        }
    }
}
