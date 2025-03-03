// obiloveapi.Infrastructure/Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using obiloveapi.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace obiloveapi.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Region> Regions { get; set; }
        
        // Additional DbSets for City, Barangay, etc.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API configurations (if any) go here.
        }
    }
}
