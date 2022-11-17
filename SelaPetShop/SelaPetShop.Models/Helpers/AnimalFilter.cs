using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaPetShop.Models.Helpers
{
    public class AnimalFilter : Filter
    {
        public string? Name { get; set; }
        public TimeSpan? Age { get; set; }
        //public IEnumerable<string> whatisthis { get; set; }
    }
}
