using System;

namespace IntervalQueue.Data.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string? message = null, Exception? inner = null)
            : base(message, inner) { }
    }
}
