using FlightSimulator.Entities;
using System;

namespace FlightSimulator.Interfaces
{
    public interface IBasicRepository<T>
    {
        Task AddAsync(T model);
        Task UpdateAsync(T model);
        Task<List<T>> GetAll();
        Task<T> GetBasic(Flight flight);
    }
}
