using NewPetShop.Data.Filters;
using System;

namespace NewPetShop.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T Delete(int id);
        T Get(int id);
        FilterResponse<T> Get(Filter filter = null);
        T Update(T entity);
    }
}
