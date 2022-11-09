using System;

namespace SelaPetShop.Data.Repositories
{
    public class Filter
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }

        public override string ToString()
        {
            return $"page:{PageNumber};size{PageSize};{Name};{Category};";
        }
    }
}
