using FlightSimulator.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace FlightSimulator.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }

        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=AirportDatabase;Integrated Security=True;Trusted_Connection=true");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Terminal_2>();
            builder.Entity<Terminal_3>();
            builder.Entity<Terminal_4>();
            builder.Entity<Terminal_5>();
            builder.Entity<Terminal_6>();
            builder.Entity<Terminal_7>();
            builder.Entity<Terminal_8>();

            //builder.Entity<Logger>()
            //  .HasOne(l => l.Terminal)
            //  .WithMany()
            //  .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);
        }

        //public DataContext() : base("AirportDatabase")
        //{
        //    Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
        //}
    }
}
