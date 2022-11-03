using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Exceptions
{
    public class EntityNotFoundException :Exception
    {
        public EntityNotFoundException(string? message = null, Exception? inner = null)
            : base(message, inner) { }
    }
}
