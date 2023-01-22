using System;

namespace FlightSimulator.Data.Exceptions
{
    public class FlightNotFoundException : Exception
    {
        public FlightNotFoundException(string? message = null, Exception? inner = null)
            : base(message, inner) { }
    }
}
