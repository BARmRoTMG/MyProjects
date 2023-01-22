using FlightSimulator.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightSimulator.Data.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<FlightQueues> FlightsQueues { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FlightControlDatabase;Integrated Security=True");
    }
}
