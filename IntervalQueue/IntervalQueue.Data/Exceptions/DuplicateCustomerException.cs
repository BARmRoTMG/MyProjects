using System;

namespace IntervalQueue.Data.Exceptions
{
    public class DuplicateCustomerException : Exception
    {
        public DuplicateCustomerException(string? message = null, Exception? inner = null)
                : base(message, inner) { }
    }
}