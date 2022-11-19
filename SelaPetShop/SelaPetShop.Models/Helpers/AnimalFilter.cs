using System;

namespace SelaPetShop.Models.Helpers
{
    public class AnimalFilter : Filter
    {
        public string? Name { get; set; }
        public TimeSpan? Birthdate { get; set; }
    }
}
