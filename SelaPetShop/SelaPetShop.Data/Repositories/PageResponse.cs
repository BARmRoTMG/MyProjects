using System;

namespace SelaPetShop.Data.Repositories
{
    public class PageResponse<T> : Filter where T : class
    {
        public int TotalCount { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
