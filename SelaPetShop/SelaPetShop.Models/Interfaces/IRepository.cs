using SelaPetShop.Models.Helpers;
using System;

namespace SelaPetShop.Models.Interfaces
{
    public interface IRepository<Tentity> where Tentity : class
    {
        Task<Tentity> Add(Tentity entity);
        Task<Tentity> Delete(int id);
        Task<Tentity> Get(int id);
        Task<FilterResponse<Tentity>> Get(Filter filter = null);
        Task<Tentity> Update(Tentity entity);
        Task<int> GetLastId();
    }
}
