using FlightSimulator.Context;
using System;
using System.Linq;

namespace FlightSimulator.Entities.Extentions
{
    public static class LoggerExtention
    {
        public static void UpdateLog(this DataContext data, Flight flight)
        {
            var log = data.Loggers.First(l => l.Flight.Id == flight.Id && l.ExitFromTerminal == null);
            log.ExitFromTerminal = DateTime.Now;

            if (flight.CurrentTerminal != null)
                data.AddLog(flight);
            else
                log.Terminal = null;

            data.SaveChanges();
        }

        public static void AddLog(this DataContext data, Flight flight)
        {
            var log = new Logger { Terminal = flight.CurrentTerminal, Flight = flight, EnterToTerminal = DateTime.Now };
            data.Loggers.Add(log);
            data.SaveChanges();
        }
    }
}
