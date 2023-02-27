using FlightSimulator.Entities;
using FlightSimulator.Enums;
using FlightSimulator.Interfaces;
using Logic.Dtos;
using Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirportServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : Controller
    {
        private readonly IFlightRepository _context;
        private readonly ITerminalService _terminalService;

        public AirportController(IFlightRepository context, ITerminalService terminalService)
        {
            _context = context;
            _terminalService = terminalService;
        }

        [HttpGet("get")]
        public async Task<IEnumerable<Flight>> GetFlights()
        {
            var flights = await _context.GetAll();
            return flights;
        }

        [HttpGet("futureFlight")]
        public async Task<List<Flight>> GetFutureFlight()
        {
            return await _context.GetFlightsByStatus(FlightStatus.Future);
        }

        [HttpPost("processFlights")]
        public async Task<ActionResult<string>> StartProcess(Flight planeDto)
        {
            return Ok(await _terminalService.AddFutureFlight(planeDto));
        }
    }
}