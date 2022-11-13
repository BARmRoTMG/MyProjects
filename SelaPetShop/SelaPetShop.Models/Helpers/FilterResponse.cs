using System;

namespace SelaPetShop.Models.Helpers
{
    public class FilterResponse<T> : Filter where T : class
    {
        public Filter filter { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
