using System;

namespace FlightSimulator.Data.Interfaces
{
    public interface IRepository<Tflight, Tterminal>
    {
        Task<IEnumerable<Tflight>> GetAll();
        Task<Tflight> GetById(int id);
        Task Add(Tflight entity);
        Task Delete(int id);
        Task UpdateLogger(Tflight entity, Tterminal terminal);
        Task InsertToTerminal();
    }
}
