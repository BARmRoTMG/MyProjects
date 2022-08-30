using System;

namespace Logic_Manager.Exceptions
{
    public class PriceMinOrMaxException : Exception
    {
        public PriceMinOrMaxException() { }
        public PriceMinOrMaxException(string message) : base(message) { }
        public PriceMinOrMaxException (string message, Exception inner) : base(message, inner) { }
    }
}
