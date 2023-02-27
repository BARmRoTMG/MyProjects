using System;

namespace FlightSimulator.Exceptions
{
    public class TerminalNotFoundException : Exception
    {
        public TerminalNotFoundException(string? message = null, Exception? inner = null)
           : base(message, inner) { }
    }
}
