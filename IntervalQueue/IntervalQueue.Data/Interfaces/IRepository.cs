using System;

namespace IntervalQueue.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Add(T customer);
        T Delete(int id);
        T Get(int id);
        List<T> GetAll();
    }
}
