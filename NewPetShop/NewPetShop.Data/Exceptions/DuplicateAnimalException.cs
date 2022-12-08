using System;

namespace NewPetShop.Data.Exceptions
{
    public class DuplicateAnimalException : Exception
    {
        public DuplicateAnimalException(string? message = null, Exception? inner = null)
            : base(message, inner) { }
    }
}
