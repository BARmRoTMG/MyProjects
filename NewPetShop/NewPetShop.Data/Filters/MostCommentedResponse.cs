using NewPetShop.Data.Entities;
using System;

namespace NewPetShop.Data.Filters
{
    public class MostCommentedResponse<T> : Animal where T : class
    {
        public IEnumerable<T> Data { get; set; }
    }
}
