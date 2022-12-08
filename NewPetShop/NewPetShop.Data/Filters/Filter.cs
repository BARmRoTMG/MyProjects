using System;
using NewPetShop.Data.Entities;

namespace NewPetShop.Data.Filters
{
    public class Filter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        //public string Category { get; set; }
        public CategoryEnum? Category { get; set; }

        public override string ToString()
        {
            return $"page:{PageNumber};size{PageSize};{Name}";
        }
    }
}
