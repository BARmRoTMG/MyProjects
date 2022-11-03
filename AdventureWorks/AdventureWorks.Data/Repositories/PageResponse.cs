using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repositories
{
    public class PageResponse<T> : Filter where T : class
    {
        public int TotalCount { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
