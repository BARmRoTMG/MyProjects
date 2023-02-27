using System;

namespace FlightSimulator.Exceptions
{
    public class FlightNotFoundException : Exception
    {
        public FlightNotFoundException(string? message = null, Exception? inner = null)
              : base(message, inner) { }
    }
}
