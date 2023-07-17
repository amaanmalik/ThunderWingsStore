using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using ThunderWings.Api.Models.Domain;

namespace ThunderWings.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id="1",
                    Name ="Customer001",
                    StreetAddress = "Test St",
                    City = "Eros",
                    PostalCode = "123abc",
                    State = "Texas"
                },
                new ApplicationUser{
                    Id = "2",
                    Name = "Customer002",
                    StreetAddress = "Test St",
                    City = "Eros",
                    PostalCode = "123abc",
                    State = "Texas"
                }
                );

            modelBuilder.Entity<Aircraft>().HasData(
                new Aircraft
                {
                    Id = 1,
                    Name = "F-22 Raptor",
                    Manufacturer = "Lockheed Martin",
                    Country = "United States of America",
                    Role = "Air superiority fighter",
                    TopSpeed = 1498,
                    Price = 150000000
                },
                new Aircraft
                {
                    Id = 2,
                    Name = "F-22 Raptor",
                    Manufacturer = "Lockheed Martin",
                    Country = "United States of America",
                    Role = "Air superiority fighter",
                    TopSpeed = 1498,
                    Price = 150000000
                },
                new Aircraft
                {
                    Id = 3,
                    Name = "Su-57",
                    Manufacturer = "Sukhoi",
                    Country = "Russia",
                    Role = "Air superiority fighter",
                    TopSpeed = 1520,
                    Price = 70000000
                },
                new Aircraft
                {
                    Id = 4,
                    Name = "Eurofighter Typhoon",
                    Manufacturer = "Airbus, BAE Systems, Leonardo, and others",
                    Country = "European consortium (Germany, Spain, Italy, and the United Kingdom)",
                    Role = "Multirole fighter",
                    TopSpeed = 1550,
                    Price = 100000000
                },
                new Aircraft
                {
                    Id = 5,
                    Name = "F-15 Eagle",
                    Manufacturer = "Boeing",
                    Country = "United States of America",
                    Role = "Air superiority fighter",
                    TopSpeed = 1650,
                    Price = 30000000
                },
                new Aircraft
                {
                    Id = 6,
                    Name = "Rafale",
                    Manufacturer = "Dassault Aviation",
                    Country = "France",
                    Role = "Multirole fighter",
                    TopSpeed = 1912,
                    Price = 80000000
                },
                new Aircraft
                {
                    Id = 7,
                    Name = "J-20",
                    Manufacturer = "Chengdu Aerospace Corporation",
                    Country = "China",
                    Role = "Air superiority fighter",
                    TopSpeed = 1305,
                    Price = 110000000
                },
                new Aircraft
                {
                    Id = 8,
                    Name = "Gripen E",
                    Manufacturer = "Saab",
                    Country = "Sweden",
                    Role = "Multirole fighter",
                    TopSpeed = 1372,
                    Price = 85000000
                },
                new Aircraft
                {
                    Id = 9,
                    Name = "MiG-35",
                    Manufacturer = "Mikoyan",
                    Country = "Russia",
                    Role = "Multirole fighter",
                    TopSpeed = 1491,
                    Price = 40000000
                },
                new Aircraft
                {
                    Id = 10,
                    Name = "F/A-18 Super Hornet",
                    Manufacturer = "Boeing",
                    Country = "United States of America",
                    Role = "Multirole fighter",
                    TopSpeed = 1190,
                    Price = 70000000
                },
                new Aircraft
                {
                    Id = 11,
                    Name = "HAL Tejas",
                    Manufacturer = "Hindustan Aeronautics Limited (HAL)",
                    Country = "India",
                    Role = "Multirole fighter",
                    TopSpeed = 1370,
                    Price = 40000000
                }
                );
        }
    }
}
