using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Domain
{
    public class TestDbContext : DbContext
    {
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        static TestDbContext()
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<VehicleType>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<VehicleType>();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=DemoEnumIssue;Username=postgres;Password=root");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
