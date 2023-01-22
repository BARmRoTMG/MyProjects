using System;

namespace FlightSimulator.Data.Exceptions
{
    public class DuplicateFlightException : Exception
    {
        public DuplicateFlightException(string? message = null, Exception? inner = null)
            : base(message, inner) { }
    }
}
