// obiloveapi.Infrastructure/Data/DatabaseSeeder.cs
using System.Linq;
using obiloveapi.Domain.Entities;

namespace obiloveapi.Infrastructure.Data
{
    public static class DatabaseSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // If no provinces exist, add the Apayao province.
            if (!context.Provinces.Any())
            {
                context.Provinces.Add(new Province
                {
                    Name = "Apayao",
                    Abbreviation = "AP",
                    Latitude = 18.2000,   // Example latitude
                    Longitude = 121.3167   // Example longitude
                });
            }

            context.SaveChanges();
        }
    }
}
