using FlightSimulator.Entities;
using FlightSimulator.Enums;
using FlightSimulator.Exceptions;
using FlightSimulator.Interfaces;
using Logic.Interfaces;
using Logic.Logic;
using Microsoft.EntityFrameworkCore;
using System;
using t = System.Timers;

namespace Logic.Services
{
    public class TerminalService : ITerminalService
    {
        private readonly ITerminalRepository<Terminal> _terminalContext;
        //private readonly ILoggerRepository<Logger> _logger;
        private readonly IBasicRepository<Logger> _logger;

        private t.Timer _timer = new t.Timer(1000);
        private readonly t.Timer _flightTimer = new t.Timer();
        private Queue<Flight> _flightQueue = new Queue<Flight>();

        public TerminalService(IFlightRepository context, ITerminalRepository<Terminal> terminalContext, IBasicRepository<Logger> logger) //ILoggerRepository<Logger> logger
        {
            _terminalContext = terminalContext;
            _logger = logger;
        }

        public async Task<string> AddFutureFlight(Flight flightDto)
        {
            bool canStart = TimerLogic.CanStartTimer(_flightQueue);
            flightDto.Status = FlightStatus.InQueue;
            _flightQueue.Enqueue(flightDto);

            if (canStart)
            {
                TimerLogic.StartTimer(_flightQueue, _flightTimer);
                await ProcessFlight(_flightQueue.Dequeue());

                 await _logger.AddAsync(
                    new Logger
                    {
                        FlightNumber = flightDto.FlightNumber,
                        CurrentTerminal = flightDto.CurrentTerminal.ToString(),
                        EnterToTerminal = flightDto.FlightTime,
                    });
            }
            return $"{flightDto.FlightNumber} added to future flights.";
        }

        public async Task ProcessFlight(Flight flight)
        {
            await FromAirToTerminal2(flight);
            flight.Status = FlightStatus.InProcces;
            _timer.Elapsed += (s, e) => GoNextTerminal(flight);
            UpdateInterval(flight);
            _timer.Start();
        }

        public void UpdateInterval(Flight flight)
        {
            if (flight.CurrentTerminal != null)
                _timer.Interval = flight.CurrentTerminal.WaitTime * 1000;
            else
            {
                flight.Status = FlightStatus.Past;
                _timer.Stop();
            }
        }

        public void GoNextTerminal(Flight flight)
        {
            Next(flight);
            UpdateInterval(flight);
        }

        public async Task FromAirToTerminal2(Flight flight)
        {
            flight.Type = FlightType.Landing;
            flight.CurrentTerminal = await _terminalContext.GetTerminalByNumber(2);
            if (flight.CurrentTerminal == null)
            {
                throw new TerminalNotFoundException("Terminal 2 was not found.");
            }
            flight.CurrentTerminalId = flight.CurrentTerminal.Id;
            //_logger.Update(_logger.Get(flight.FlightNumber));
            //await _logger.UpdateAsync(new Logger { CurrentTerminal = flight.CurrentTerminal.ToString(), EnterToTerminal = flight.FlightTime, FlightNumber = flight.FlightNumber });
            //await _logger.AddAsync(new Logger { CurrentTerminal = flight.CurrentTerminal.ToString(), EnterToTerminal = flight.FlightTime, FlightNumber = flight.FlightNumber });
        }

        public void Next(Flight flight)
        {
            if (flight.CurrentTerminal != null)
            {
                flight.CurrentTerminal.NextTerminal(flight);
                //_logger.Update(_logger.Get(flight.FlightNumber));
                //_logger.UpdateAsync(await _logger.GetBasic(flight));
            }
            else
                _timer.Stop();
        }
    }
}
