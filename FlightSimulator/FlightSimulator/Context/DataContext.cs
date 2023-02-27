using FlightSimulator.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace FlightSimulator.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<Logger> Loggers { get; set; }

        public DataContext() //Resets Database Data
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
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

            base.OnModelCreating(builder);
        }
    }
}
