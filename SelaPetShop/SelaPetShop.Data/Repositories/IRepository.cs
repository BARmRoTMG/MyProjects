using System;

namespace SelaPetShop.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<PageResponse<T>> Get(Filter filter = null);
        Task<T> Update(T entity);
        Task<T> Add(T entity);
        Task<T> Delete(int id);
        Task<T> Register(T user);
        Task<T> Login(T user);
    }
}
