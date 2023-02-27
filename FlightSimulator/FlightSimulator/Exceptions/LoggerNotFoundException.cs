using System;

namespace FlightSimulator.Exceptions
{
    public class LoggerNotFoundException : Exception
    {
        public LoggerNotFoundException(string? message = null, Exception? inner = null)
              : base(message, inner) { }
    }
}
