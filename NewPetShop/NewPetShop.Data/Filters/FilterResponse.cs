using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPetShop.Data.Filters
{
    public class FilterResponse<T> : Filter where T : class
    {
        public Filter filter { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
