using System;

namespace NewPetShop.Data.Exceptions
{
    public class AnimalNotFoundException : Exception
    {
        public AnimalNotFoundException(string? message = null, Exception? inner = null)
            : base(message, inner) { }
    }
}
