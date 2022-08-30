using System;

namespace Logic_Manager.Exceptions
{
    public class AmountMinException : Exception
    {
        public AmountMinException() { }
        public AmountMinException(string message) : base(message) { }
        public AmountMinException(string message, Exception inner) : base(message, inner) { }

    }
}
