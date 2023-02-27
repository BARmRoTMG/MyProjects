using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace FlightSimulator.Interfaces
{
    public interface ILoggerRepository<T> where T : class
    {
        void Add(T entity);
        T Update(T entity);
        T Get (string flightNumber);
    }
}
