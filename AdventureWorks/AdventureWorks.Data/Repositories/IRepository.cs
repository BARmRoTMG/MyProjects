using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<PageResponse<T>> Get(Filter filter = null);
        Task<T> Update(T entity);
        Task<T> Add(T entity);
        Task<T> Delete(int id);
    }
}
